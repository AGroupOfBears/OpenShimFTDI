#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#include "ftd2xx_shim.h"
#include "../include/openshim_ipc.h"

#include <stdarg.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define SHIM_VERSION "0.2.0"
#define FAKE_DESCRIPTION "OpenPort 2.0 FTDI Bridge"
#define FAKE_SERIAL "OP20SHIM01"
#define FAKE_HANDLE_VALUE ((uintptr_t)0xF7D20001UL)
#define RX_FIFO_CAPACITY (64U * 1024U)

typedef enum {
    BACKEND_MODE_IPC = 0,
    BACKEND_MODE_LOOPBACK = 1
} BackendMode;

typedef enum {
    FAST_INIT_IDLE = 0,
    FAST_INIT_BAUD_360,
    FAST_INIT_BREAK_ON,
    FAST_INIT_BREAK_OFF,
    FAST_INIT_ZERO_SENT,
    FAST_INIT_WAIT_START_COMM
} FastInitState;

typedef enum {
    FIVE_BAUD_STATE_IDLE = 0,
    FIVE_BAUD_STATE_AWAITING_INIT = 1
} FiveBaudState;

typedef struct ShimState {
    BOOL opened;
    FT_HANDLE handle;

    BYTE rx_fifo[RX_FIFO_CAPACITY];
    size_t rx_head;
    size_t rx_tail;
    size_t rx_count;
    size_t tx_count;

    DWORD event_mask;
    HANDLE event_handle;

    DWORD baud_rate;
    UCHAR word_length;
    UCHAR stop_bits;
    UCHAR parity;
    USHORT flow_control;
    UCHAR xon;
    UCHAR xoff;
    DWORD read_timeout;
    DWORD write_timeout;
    UCHAR latency_timer;
    DWORD usb_in_size;
    DWORD usb_out_size;
    BOOL dtr;
    BOOL rts;
    BOOL break_on;

    BackendMode backend_mode;
    FastInitState fast_init_state;
    DWORD break_toggle_count;

    /* 5-baud break detection & handshake */
    uint32_t break_bit_count;
    uint32_t break_bit_accumulator;
    DWORD    last_break_time;
    uint8_t  last_break_val;
    FiveBaudState five_baud_state;
    uint8_t  expected_init;
    uint8_t  expected_ack;
    DWORD    five_baud_timestamp;
    BOOL     five_baud_rx_ready;
} ShimState;

typedef struct IpcClient {
    BOOL wsa_initialized;
    SOCKET sock;
    HANDLE reader_thread;
    volatile BOOL reader_running;
    CRITICAL_SECTION send_lock;
    CRITICAL_SECTION reply_lock;
    HANDLE reply_event;
    uint32_t seq_counter;

    /* Pending reply state */
    uint32_t waiting_seq;
    ipc_header_t reply_hdr;
    BYTE reply_payload[OPENSHIM_MAX_PAYLOAD];
    uint32_t reply_payload_len;

    /* Remote hardware state */
    BOOL device_opened;
    uint32_t device_id;
    BOOL channel_connected;
    uint32_t channel_id;
} IpcClient;

static HMODULE g_module;
static CRITICAL_SECTION g_state_lock;
static CRITICAL_SECTION g_log_lock;
static BOOL g_locks_ready;
static FILE *g_log_file;
static ShimState g_state;
static IpcClient g_ipc;

static void log_message(const char *format, ...);
static void log_transfer(const char *name, FT_HANDLE handle, const BYTE *data,
                         DWORD requested, DWORD actual, FT_STATUS status);
static size_t fifo_push_locked(const BYTE *data, size_t length);
static size_t fifo_pop_locked(BYTE *data, size_t length);
static FT_STATUS ensure_ipc_channel_connected_locked(void);

static void reset_open_state_locked(void)
{
    g_state.opened = FALSE;
    g_state.handle = (FT_HANDLE)FAKE_HANDLE_VALUE;
    g_state.rx_head = 0;
    g_state.rx_tail = 0;
    g_state.rx_count = 0;
    g_state.tx_count = 0;
    g_state.baud_rate = 9600;
    g_state.word_length = 8;
    g_state.stop_bits = 0;
    g_state.parity = 0;
    g_state.flow_control = 0;
    g_state.xon = 0x11;
    g_state.xoff = 0x13;
    g_state.read_timeout = 0;
    g_state.write_timeout = 0;
    g_state.latency_timer = 16;
    g_state.usb_in_size = 4096;
    g_state.usb_out_size = 4096;
    g_state.dtr = FALSE;
    g_state.rts = FALSE;
    g_state.break_on = FALSE;
    g_state.fast_init_state = FAST_INIT_IDLE;
    g_state.break_toggle_count = 0;
    g_state.break_bit_count = 0;
    g_state.break_bit_accumulator = 0;
    g_state.last_break_time = 0;
    g_state.last_break_val = 1;
    g_state.five_baud_state = FIVE_BAUD_STATE_IDLE;
    g_state.expected_init = 0;
    g_state.expected_ack = 0;
    g_state.five_baud_timestamp = 0;
    g_state.five_baud_rx_ready = FALSE;

    const char *env_backend = getenv("OPENSHIM_BACKEND");
    if (env_backend != NULL && _stricmp(env_backend, "loopback") == 0) {
        g_state.backend_mode = BACKEND_MODE_LOOPBACK;
    } else {
        g_state.backend_mode = BACKEND_MODE_IPC;
    }
}

static FILE *open_log_locked(void)
{
    char path[MAX_PATH];
    char *slash;

    if (g_log_file != NULL) {
        return g_log_file;
    }

    path[0] = '\0';
    if (g_module != NULL && GetModuleFileNameA(g_module, path, MAX_PATH) > 0) {
        path[MAX_PATH - 1] = '\0';
        slash = strrchr(path, '\\');
        if (slash == NULL) {
            slash = strrchr(path, '/');
        }
        if (slash != NULL) {
            slash[1] = '\0';
            if (strlen(path) + strlen("ftd2xx-shim.log") < MAX_PATH) {
                strcat(path, "ftd2xx-shim.log");
                g_log_file = fopen(path, "a");
            }
        }
    }

    if (g_log_file == NULL) {
        g_log_file = fopen("ftd2xx-shim.log", "a");
    }
    return g_log_file;
}

static void log_prefix_locked(FILE *fp)
{
    SYSTEMTIME now;
    GetLocalTime(&now);
    fprintf(fp,
            "[%04u-%02u-%02u %02u:%02u:%02u.%03u] [tick=%010lu] [tid=%lu] ",
            (unsigned)now.wYear, (unsigned)now.wMonth, (unsigned)now.wDay,
            (unsigned)now.wHour, (unsigned)now.wMinute, (unsigned)now.wSecond,
            (unsigned)now.wMilliseconds, (unsigned long)GetTickCount(),
            (unsigned long)GetCurrentThreadId());
}

static void log_message(const char *format, ...)
{
    FILE *fp;
    va_list args;

    if (!g_locks_ready) {
        return;
    }
    EnterCriticalSection(&g_log_lock);
    fp = open_log_locked();
    if (fp != NULL) {
        log_prefix_locked(fp);
        va_start(args, format);
        vfprintf(fp, format, args);
        va_end(args);
        fputc('\n', fp);
        fflush(fp);
    }
    LeaveCriticalSection(&g_log_lock);
}

static void log_transfer(const char *name, FT_HANDLE handle, const BYTE *data,
                         DWORD requested, DWORD actual, FT_STATUS status)
{
    FILE *fp;
    DWORD i;

    if (!g_locks_ready) {
        return;
    }
    EnterCriticalSection(&g_log_lock);
    fp = open_log_locked();
    if (fp != NULL) {
        log_prefix_locked(fp);
        fprintf(fp,
                "%s(handle=%p, buffer=%p, requested=%lu) -> status=%lu, actual=%lu, data=",
                name, handle, (const void *)data, (unsigned long)requested,
                (unsigned long)status, (unsigned long)actual);
        if (data == NULL || actual == 0) {
            fputs("<empty>", fp);
        } else {
            for (i = 0; i < actual; ++i) {
                fprintf(fp, "%s%02X", i == 0 ? "" : " ", (unsigned)data[i]);
            }
        }
        fputc('\n', fp);
        fflush(fp);
    }
    LeaveCriticalSection(&g_log_lock);
}

static FT_STATUS check_handle_locked(FT_HANDLE handle)
{
    if (!g_state.opened || handle == NULL || handle != g_state.handle) {
        return FT_INVALID_HANDLE;
    }
    return FT_OK;
}

static void copy_device_string(PVOID destination, const char *value)
{
    if (destination != NULL) {
        memcpy(destination, value, strlen(value) + 1U);
    }
}

static size_t fifo_push_locked(const BYTE *data, size_t length)
{
    size_t written = 0;
    while (written < length && g_state.rx_count < RX_FIFO_CAPACITY) {
        g_state.rx_fifo[g_state.rx_tail] = data[written];
        g_state.rx_tail = (g_state.rx_tail + 1U) % RX_FIFO_CAPACITY;
        ++g_state.rx_count;
        ++written;
    }
    return written;
}

static size_t fifo_pop_locked(BYTE *data, size_t length)
{
    size_t read = 0;
    while (read < length && g_state.rx_count > 0U) {
        data[read] = g_state.rx_fifo[g_state.rx_head];
        g_state.rx_head = (g_state.rx_head + 1U) % RX_FIFO_CAPACITY;
        --g_state.rx_count;
        ++read;
    }
    return read;
}

/* Sockets & IPC Client Helpers */

static int ipc_send_all(SOCKET s, const void *buf, int len)
{
    const char *p = (const char *)buf;
    while (len > 0) {
        int n = send(s, p, len, 0);
        if (n <= 0) return -1;
        p += n;
        len -= n;
    }
    return 0;
}

static int ipc_recv_all(SOCKET s, void *buf, int len)
{
    char *p = (char *)buf;
    while (len > 0) {
        int n = recv(s, p, len, 0);
        if (n <= 0) return -1;
        p += n;
        len -= n;
    }
    return 0;
}

/* Background thread receiving packets from helper */
static DWORD WINAPI ipc_reader_thread_proc(LPVOID param)
{
    (void)param;
    log_message("[ipc] Background RX reader thread started");

    uint8_t payload_buf[OPENSHIM_MAX_PAYLOAD];

    while (g_ipc.reader_running) {
        ipc_header_t hdr;
        if (ipc_recv_all(g_ipc.sock, &hdr, sizeof(hdr)) != 0) {
            log_message("[ipc] Connection closed or read error in reader thread");
            break;
        }

        if (hdr.magic != OPENSHIM_IPC_MAGIC || hdr.version != OPENSHIM_IPC_VERSION) {
            log_message("[ipc] Invalid header magic 0x%08X or version %u", hdr.magic, hdr.version);
            break;
        }

        if (hdr.payload_len > sizeof(payload_buf)) {
            log_message("[ipc] Payload len %u exceeds maximum buffer", hdr.payload_len);
            break;
        }

        if (hdr.payload_len > 0) {
            if (ipc_recv_all(g_ipc.sock, payload_buf, (int)hdr.payload_len) != 0) {
                log_message("[ipc] Error reading payload in reader thread");
                break;
            }
        }

        if (hdr.command_id == IPC_CMD_RX_DATA) {
            /* Asynchronous push of received or loopback bytes */
            if (hdr.payload_len >= sizeof(ipc_push_rx_data_t)) {
                const ipc_push_rx_data_t *rx_hdr = (const ipc_push_rx_data_t *)payload_buf;
                const BYTE *data_bytes = payload_buf + sizeof(ipc_push_rx_data_t);
                uint32_t data_len = rx_hdr->data_len;

                HANDLE event_to_signal = NULL;
                EnterCriticalSection(&g_state_lock);
                if (g_state.opened) {
                    size_t pushed = fifo_push_locked(data_bytes, data_len);
                    if (pushed > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
                        event_to_signal = g_state.event_handle;
                    }
                }
                LeaveCriticalSection(&g_state_lock);

                if (event_to_signal != NULL) {
                    SetEvent(event_to_signal);
                }
                log_message("[ipc] RX push received: %u bytes (status=%u), queued into RX FIFO",
                            data_len, rx_hdr->rx_status);
            }
        } else {
            /* Command reply */
            EnterCriticalSection(&g_ipc.reply_lock);
            g_ipc.reply_hdr = hdr;
            g_ipc.reply_payload_len = hdr.payload_len;
            if (hdr.payload_len > 0) {
                memcpy(g_ipc.reply_payload, payload_buf, hdr.payload_len);
            }
            SetEvent(g_ipc.reply_event);
            LeaveCriticalSection(&g_ipc.reply_lock);
        }
    }

    log_message("[ipc] Background RX reader thread exiting");
    return 0;
}

static FT_STATUS ipc_send_command_sync(uint16_t cmd_id, const void *payload, uint32_t payload_len,
                                      ipc_header_t *out_hdr, void *out_payload, uint32_t max_out_len)
{
    if (g_ipc.sock == INVALID_SOCKET) {
        return FT_IO_ERROR;
    }

    EnterCriticalSection(&g_ipc.send_lock);

    EnterCriticalSection(&g_ipc.reply_lock);
    uint32_t seq = ++g_ipc.seq_counter;
    g_ipc.waiting_seq = seq;
    ResetEvent(g_ipc.reply_event);
    LeaveCriticalSection(&g_ipc.reply_lock);

    ipc_header_t req_hdr;
    req_hdr.magic = OPENSHIM_IPC_MAGIC;
    req_hdr.version = OPENSHIM_IPC_VERSION;
    req_hdr.command_id = cmd_id;
    req_hdr.seq_id = seq;
    req_hdr.status = 0;
    req_hdr.payload_len = payload_len;

    if (ipc_send_all(g_ipc.sock, &req_hdr, sizeof(req_hdr)) != 0) {
        LeaveCriticalSection(&g_ipc.send_lock);
        log_message("[ipc] Failed to send command %u header", cmd_id);
        return FT_IO_ERROR;
    }

    if (payload_len > 0 && payload != NULL) {
        if (ipc_send_all(g_ipc.sock, payload, (int)payload_len) != 0) {
            LeaveCriticalSection(&g_ipc.send_lock);
            log_message("[ipc] Failed to send command %u payload", cmd_id);
            return FT_IO_ERROR;
        }
    }

    LeaveCriticalSection(&g_ipc.send_lock);

    DWORD wait_res = WaitForSingleObject(g_ipc.reply_event, 5000);
    if (wait_res != WAIT_OBJECT_0) {
        log_message("[ipc] Timeout waiting for command %u reply", cmd_id);
        return FT_IO_ERROR;
    }

    EnterCriticalSection(&g_ipc.reply_lock);
    if (out_hdr != NULL) {
        *out_hdr = g_ipc.reply_hdr;
    }

    if (out_payload != NULL && g_ipc.reply_payload_len > 0) {
        uint32_t copy_len = g_ipc.reply_payload_len < max_out_len ? g_ipc.reply_payload_len : max_out_len;
        memcpy(out_payload, g_ipc.reply_payload, copy_len);
    }

    uint32_t status = g_ipc.reply_hdr.status;
    LeaveCriticalSection(&g_ipc.reply_lock);

    return (status == IPC_STATUS_OK) ? FT_OK : FT_IO_ERROR;
}

static FT_STATUS ipc_connect_backend(void)
{
    if (g_ipc.sock != INVALID_SOCKET) {
        return FT_OK;
    }

    if (!g_ipc.wsa_initialized) {
        WSADATA wsa;
        if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0) {
            log_message("[ipc] WSAStartup failed");
            return FT_DEVICE_NOT_FOUND;
        }
        g_ipc.wsa_initialized = TRUE;
    }

    SOCKET s = socket(AF_INET, SOCK_STREAM, 0);
    if (s == INVALID_SOCKET) {
        log_message("[ipc] socket creation failed");
        return FT_DEVICE_NOT_FOUND;
    }

    int nodelay = 1;
    setsockopt(s, IPPROTO_TCP, TCP_NODELAY, (const char *)&nodelay, sizeof(nodelay));

    uint16_t port = OPENSHIM_DEFAULT_PORT;
    const char *env_port = getenv("OPENSHIM_IPC_PORT");
    if (env_port != NULL && env_port[0] != '\0') {
        port = (uint16_t)atoi(env_port);
    }

    struct sockaddr_in addr;
    memset(&addr, 0, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_port = htons(port);
    addr.sin_addr.s_addr = inet_addr(OPENSHIM_DEFAULT_HOST);

    log_message("[ipc] Connecting to helper at %s:%u...", OPENSHIM_DEFAULT_HOST, port);
    if (connect(s, (struct sockaddr *)&addr, sizeof(addr)) != 0) {
        log_message("[ipc] Connect failed (error %d)", WSAGetLastError());
        closesocket(s);
        return FT_DEVICE_NOT_FOUND;
    }

    g_ipc.sock = s;
    g_ipc.reader_running = TRUE;
    g_ipc.reader_thread = CreateThread(NULL, 0, ipc_reader_thread_proc, NULL, 0, NULL);
    if (g_ipc.reader_thread == NULL) {
        log_message("[ipc] Failed to create reader thread");
        g_ipc.reader_running = FALSE;
        closesocket(s);
        g_ipc.sock = INVALID_SOCKET;
        return FT_INSUFFICIENT_RESOURCES;
    }

    /* Send IPC_CMD_OPEN to open backend device only (PassThruOpen) */
    ipc_req_open_t req;
    req.device_index = 0;
    ipc_header_t resp_hdr;
    ipc_resp_open_t resp_payload;

    FT_STATUS status = ipc_send_command_sync(IPC_CMD_OPEN, &req, sizeof(req),
                                             &resp_hdr, &resp_payload, sizeof(resp_payload));
    if (status != FT_OK) {
        log_message("[ipc] Helper CMD_OPEN failed (status=%u)", resp_hdr.status);
        g_ipc.reader_running = FALSE;
        closesocket(g_ipc.sock);
        g_ipc.sock = INVALID_SOCKET;
        CloseHandle(g_ipc.reader_thread);
        g_ipc.reader_thread = NULL;
        return FT_DEVICE_NOT_FOUND;
    }

    g_ipc.device_opened = TRUE;
    g_ipc.device_id = resp_payload.device_id;
    g_ipc.channel_connected = FALSE;
    g_ipc.channel_id = 0;

    log_message("[ipc] Backend device opened successfully: DeviceID=%u, Desc='%s'",
                g_ipc.device_id, resp_payload.description);
    return FT_OK;
}

static void ipc_disconnect_backend(void)
{
    if (g_ipc.sock == INVALID_SOCKET) {
        return;
    }

    log_message("[ipc] Closing backend connection...");
    if (g_ipc.channel_connected) {
        ipc_req_disconnect_t req_disc;
        req_disc.channel_id = g_ipc.channel_id;
        ipc_send_command_sync(IPC_CMD_DISCONNECT, &req_disc, sizeof(req_disc), NULL, NULL, 0);
        g_ipc.channel_connected = FALSE;
        g_ipc.channel_id = 0;
    }

    if (g_ipc.device_opened) {
        ipc_send_command_sync(IPC_CMD_CLOSE, NULL, 0, NULL, NULL, 0);
        g_ipc.device_opened = FALSE;
        g_ipc.device_id = 0;
    }

    g_ipc.reader_running = FALSE;
    closesocket(g_ipc.sock);
    g_ipc.sock = INVALID_SOCKET;

    if (g_ipc.reader_thread != NULL) {
        WaitForSingleObject(g_ipc.reader_thread, 1000);
        CloseHandle(g_ipc.reader_thread);
        g_ipc.reader_thread = NULL;
    }
}

static FT_STATUS ensure_ipc_channel_connected_locked(void)
{
    if (g_ipc.channel_connected) {
        return FT_OK;
    }
    if (!g_ipc.device_opened) {
        return FT_DEVICE_NOT_OPENED;
    }

    /* Defer protocol connection until required: connect with ISO14230 */
    uint32_t baud = g_state.baud_rate;
    if (baud == 360 || baud == 0) {
        baud = 10400;
    }

    ipc_req_connect_t req;
    req.device_id = g_ipc.device_id;
    req.protocol_id = 4; /* ISO14230 */
    req.flags = 0;
    req.baud_rate = baud;

    log_message("[ipc] Performing deferred PassThruConnect: proto=4 (ISO14230), baud=%u", baud);
    ipc_header_t resp_hdr;
    ipc_resp_connect_t resp;

    FT_STATUS st = ipc_send_command_sync(IPC_CMD_CONNECT, &req, sizeof(req),
                                         &resp_hdr, &resp, sizeof(resp));
    if (st == FT_OK) {
        g_ipc.channel_connected = TRUE;
        g_ipc.channel_id = resp.channel_id;
        log_message("[ipc] PassThruConnect succeeded, ChannelID=%u", g_ipc.channel_id);
        return FT_OK;
    } else {
        log_message("[ipc] PassThruConnect failed (status=%u)", resp_hdr.status);
        return FT_IO_ERROR;
    }
}

/* DllMain */

BOOL WINAPI DllMain(HINSTANCE instance, DWORD reason, LPVOID reserved)
{
    (void)reserved;
    if (reason == DLL_PROCESS_ATTACH) {
        g_module = instance;
        InitializeCriticalSection(&g_state_lock);
        InitializeCriticalSection(&g_log_lock);
        InitializeCriticalSection(&g_ipc.send_lock);
        InitializeCriticalSection(&g_ipc.reply_lock);
        g_ipc.reply_event = CreateEvent(NULL, FALSE, FALSE, NULL);
        g_ipc.sock = INVALID_SOCKET;
        g_locks_ready = TRUE;
        reset_open_state_locked();
        DisableThreadLibraryCalls(instance);
    } else if (reason == DLL_PROCESS_DETACH && g_locks_ready) {
        ipc_disconnect_backend();
        if (g_ipc.reply_event != NULL) {
            CloseHandle(g_ipc.reply_event);
            g_ipc.reply_event = NULL;
        }
        if (g_ipc.wsa_initialized) {
            WSACleanup();
            g_ipc.wsa_initialized = FALSE;
        }
        if (g_log_file != NULL) {
            fflush(g_log_file);
            fclose(g_log_file);
            g_log_file = NULL;
        }
        DeleteCriticalSection(&g_ipc.reply_lock);
        DeleteCriticalSection(&g_ipc.send_lock);
        DeleteCriticalSection(&g_log_lock);
        DeleteCriticalSection(&g_state_lock);
        g_locks_ready = FALSE;
    }
    return TRUE;
}

FT_STATUS WINAPI FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs)
{
    FT_STATUS status = FT_OK;
    if (lpdwNumDevs == NULL) {
        status = FT_INVALID_PARAMETER;
    } else {
        *lpdwNumDevs = 1;
    }
    log_message("FT_CreateDeviceInfoList(count_out=%p) -> status=%lu, count=%lu",
                (void *)lpdwNumDevs, (unsigned long)status,
                (unsigned long)(lpdwNumDevs != NULL ? *lpdwNumDevs : 0));
    return status;
}

FT_STATUS WINAPI FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD dwFlags)
{
    FT_STATUS status = FT_OK;
    const char *kind = "description";
    const char *mode = "unknown";
    uintptr_t index = 0;

    if ((dwFlags & FT_OPEN_BY_SERIAL_NUMBER) != 0) {
        kind = "serial";
    }

    if ((dwFlags & FT_LIST_NUMBER_ONLY) != 0) {
        mode = "number-only";
        if (pArg1 != NULL) {
            *(DWORD *)pArg1 = 1;
        } else if (pArg2 != NULL) {
            *(DWORD *)pArg2 = 1;
        } else {
            status = FT_INVALID_PARAMETER;
        }
    } else if ((dwFlags & FT_LIST_BY_INDEX) != 0) {
        mode = "by-index";
        index = (uintptr_t)pArg1;
        if (index != 0U) {
            status = FT_DEVICE_NOT_FOUND;
        } else if (pArg2 == NULL) {
            status = FT_INVALID_PARAMETER;
        } else {
            copy_device_string(pArg2,
                               strcmp(kind, "serial") == 0 ? FAKE_SERIAL : FAKE_DESCRIPTION);
        }
    } else if ((dwFlags & FT_LIST_ALL) != 0) {
        char **buffers = (char **)pArg1;
        mode = "list-all";
        if (pArg2 != NULL) {
            *(DWORD *)pArg2 = 1;
        }
        if (buffers == NULL || buffers[0] == NULL) {
            status = FT_INVALID_PARAMETER;
        } else {
            copy_device_string(buffers[0],
                               strcmp(kind, "serial") == 0 ? FAKE_SERIAL : FAKE_DESCRIPTION);
        }
    } else {
        mode = "fallback-description";
        if (pArg2 == NULL) {
            status = FT_INVALID_PARAMETER;
        } else {
            copy_device_string(pArg2, FAKE_DESCRIPTION);
        }
    }

    log_message("FT_ListDevices(arg1=%p, arg2=%p, flags=0x%08lX, mode=%s, kind=%s, index=%lu) -> status=%lu",
                pArg1, pArg2, (unsigned long)dwFlags, mode, kind,
                (unsigned long)index, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_Open(DWORD deviceNumber, FT_HANDLE *pHandle)
{
    FT_STATUS status = FT_OK;
    FT_HANDLE result = NULL;

    EnterCriticalSection(&g_state_lock);
    if (pHandle == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (deviceNumber != 0) {
        *pHandle = NULL;
        status = FT_DEVICE_NOT_FOUND;
    } else {
        reset_open_state_locked();
        if (g_state.backend_mode == BACKEND_MODE_IPC) {
            status = ipc_connect_backend();
        }
        if (status == FT_OK) {
            g_state.opened = TRUE;
            *pHandle = g_state.handle;
            result = *pHandle;
        } else {
            *pHandle = NULL;
        }
    }
    LeaveCriticalSection(&g_state_lock);

    log_message("FT_Open(device=%lu, handle_out=%p) -> status=%lu, handle=%p (backend=%s)",
                (unsigned long)deviceNumber, (void *)pHandle,
                (unsigned long)status, result,
                g_state.backend_mode == BACKEND_MODE_IPC ? "IPC" : "LOOPBACK");
    return status;
}

FT_STATUS WINAPI FT_OpenEx(PVOID pvArg1, DWORD dwFlags, FT_HANDLE *pHandle)
{
    FT_STATUS status = FT_OK;
    FT_HANDLE result = NULL;
    const char *selector = "index";
    const char *text = NULL;
    BOOL matches = FALSE;
    DWORD open_flags = dwFlags & (FT_OPEN_BY_SERIAL_NUMBER |
                                  FT_OPEN_BY_DESCRIPTION |
                                  FT_OPEN_BY_LOCATION);

    if (open_flags == FT_OPEN_BY_DESCRIPTION) {
        selector = "description";
        text = (const char *)pvArg1;
        matches = text != NULL && strcmp(text, FAKE_DESCRIPTION) == 0;
    } else if (open_flags == FT_OPEN_BY_SERIAL_NUMBER) {
        selector = "serial";
        text = (const char *)pvArg1;
        matches = text != NULL && strcmp(text, FAKE_SERIAL) == 0;
    } else if (open_flags == FT_OPEN_BY_LOCATION) {
        selector = "location";
        matches = (uintptr_t)pvArg1 == 0U;
    } else {
        matches = (uintptr_t)pvArg1 == 0U;
    }

    EnterCriticalSection(&g_state_lock);
    if (pHandle == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (!matches) {
        *pHandle = NULL;
        status = FT_DEVICE_NOT_FOUND;
    } else {
        reset_open_state_locked();
        if (g_state.backend_mode == BACKEND_MODE_IPC) {
            status = ipc_connect_backend();
        }
        if (status == FT_OK) {
            g_state.opened = TRUE;
            *pHandle = g_state.handle;
            result = *pHandle;
        } else {
            *pHandle = NULL;
        }
    }
    LeaveCriticalSection(&g_state_lock);

    log_message("FT_OpenEx(arg=%p, flags=0x%08lX, open_flags=0x%08lX, selector=%s, value=%s, handle_out=%p) -> status=%lu, handle=%p (backend=%s)",
                pvArg1, (unsigned long)dwFlags, (unsigned long)open_flags, selector,
                text != NULL ? text : "<non-string>", (void *)pHandle,
                (unsigned long)status, result,
                g_state.backend_mode == BACKEND_MODE_IPC ? "IPC" : "LOOPBACK");
    return status;
}

FT_STATUS WINAPI FT_Close(FT_HANDLE ftHandle)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        if (g_state.backend_mode == BACKEND_MODE_IPC) {
            ipc_disconnect_backend();
        }
        reset_open_state_locked();
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_Close(handle=%p) -> status=%lu (state reset)",
                ftHandle, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_Read(FT_HANDLE ftHandle, LPVOID lpBuffer,
                         DWORD dwBytesToRead, LPDWORD lpdwBytesReturned)
{
    FT_STATUS status;
    DWORD actual = 0;
    HANDLE event_to_signal = NULL;

    if (lpdwBytesReturned != NULL) {
        *lpdwBytesReturned = 0;
    }

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK && lpdwBytesReturned == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (status == FT_OK && dwBytesToRead > 0 && lpBuffer == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (status == FT_OK) {
        actual = (DWORD)fifo_pop_locked((BYTE *)lpBuffer, (size_t)dwBytesToRead);
        *lpdwBytesReturned = actual;
        if (g_state.rx_count > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
            event_to_signal = g_state.event_handle;
        }
    }
    LeaveCriticalSection(&g_state_lock);

    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_transfer("FT_Read", ftHandle, (const BYTE *)lpBuffer,
                 dwBytesToRead, actual, status);
    return status;
}

FT_STATUS WINAPI FT_Write(FT_HANDLE ftHandle, LPVOID lpBuffer,
                          DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten)
{
    FT_STATUS status = FT_OK;
    DWORD actual = 0;
    HANDLE event_to_signal = NULL;

    if (lpdwBytesWritten != NULL) {
        *lpdwBytesWritten = 0;
    }

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK && lpdwBytesWritten == NULL) {
        status = FT_INVALID_PARAMETER;
        LeaveCriticalSection(&g_state_lock);
        return status;
    }
    if (status == FT_OK && dwBytesToWrite > 0 && lpBuffer == NULL) {
        status = FT_INVALID_PARAMETER;
        LeaveCriticalSection(&g_state_lock);
        return status;
    }
    if (status != FT_OK) {
        LeaveCriticalSection(&g_state_lock);
        return status;
    }

    const BYTE *data = (const BYTE *)lpBuffer;

    /* Check five-baud handshake timeout/reset */
    if (g_state.five_baud_state == FIVE_BAUD_STATE_AWAITING_INIT) {
        DWORD elapsed = GetTickCount() - g_state.five_baud_timestamp;
        if (elapsed > 5000) {
            log_message("[FIVE_BAUD] Handshake state timed out (%lu ms > 5000 ms); resetting to IDLE",
                        (unsigned long)elapsed);
            g_state.five_baud_state = FIVE_BAUD_STATE_IDLE;
        }
    }

    if (g_state.five_baud_state == FIVE_BAUD_STATE_AWAITING_INIT) {
        if (dwBytesToWrite == 1 && data[0] == g_state.expected_init) {
            /* This is TuneECU transmitting inverted keybyte 2 (~KB2) */
            log_message("[FIVE_BAUD] Intercepted expected ~KB2 write (0x%02X); virtualizing handshake",
                        data[0]);

            /* 1. Do NOT transmit to hardware / IPC */
            *lpdwBytesWritten = 1;
            actual = 1;

            /* 2. Provide expected FTDI write echo locally in RX FIFO */
            fifo_push_locked(data, 1);

            /* 3. Inject expected_ack (~Address) into RX FIFO */
            BYTE ack = g_state.expected_ack;
            fifo_push_locked(&ack, 1);
            log_message("[FIVE_BAUD] Injected write echo 0x%02X and expected_ack 0x%02X into RX FIFO",
                        data[0], ack);

            /* 4. Signal FT_EVENT_RXCHAR if registered */
            if (g_state.rx_count > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
                event_to_signal = g_state.event_handle;
            }

            /* 5. Clear five-baud handshake state */
            g_state.five_baud_state = FIVE_BAUD_STATE_IDLE;

            LeaveCriticalSection(&g_state_lock);
            if (event_to_signal != NULL) {
                SetEvent(event_to_signal);
            }
            log_transfer("FT_Write", ftHandle, data, dwBytesToWrite, actual, FT_OK);
            return FT_OK;
        } else {
            /* Unrelated write or wrong ~KB2: DO NOT SUPPRESS. Reset handshake state */
            log_message("[FIVE_BAUD] Write (%lu bytes, byte[0]=0x%02X) did not match expected_init (0x%02X); not suppressing, resetting to IDLE",
                        (unsigned long)dwBytesToWrite, data[0], g_state.expected_init);
            g_state.five_baud_state = FIVE_BAUD_STATE_IDLE;
            /* Fall through to normal write path */
        }
    }

    /* Check KWP FAST_INIT sequence recognition */
    if (g_state.backend_mode == BACKEND_MODE_IPC &&
        g_state.fast_init_state == FAST_INIT_BREAK_OFF &&
        dwBytesToWrite == 1 && data[0] == 0x00) {
        /* TuneECU sends the 25ms low pulse byte (0x00) at 360 baud */
        log_message("[FAST_INIT] Recognized 25ms low-pulse 0x00 byte at 360 baud");
        g_state.fast_init_state = FAST_INIT_ZERO_SENT;
        *lpdwBytesWritten = 1;
        LeaveCriticalSection(&g_state_lock);
        log_transfer("FT_Write", ftHandle, data, dwBytesToWrite, 1, FT_OK);
        return FT_OK;
    }

    if (g_state.backend_mode == BACKEND_MODE_IPC &&
        g_state.fast_init_state == FAST_INIT_WAIT_START_COMM &&
        dwBytesToWrite > 0 && (data[0] == 0x81 || (dwBytesToWrite >= 4 && data[3] == 0x81))) {
        /* TuneECU sends the KWP StartCommunication frame */
        log_message("[FAST_INIT] Recognized StartCommunication frame; dispatching CMD_FAST_INIT to helper");
        g_state.fast_init_state = FAST_INIT_IDLE;

        status = ensure_ipc_channel_connected_locked();
        if (status == FT_OK) {
            uint8_t fi_buf[sizeof(ipc_req_fast_init_t) + 256];
            ipc_req_fast_init_t *fi_req = (ipc_req_fast_init_t *)fi_buf;
            fi_req->channel_id = g_ipc.channel_id;
            fi_req->tx_flags = 0;
            fi_req->timeout_ms = g_state.write_timeout ? g_state.write_timeout : 500;
            fi_req->data_len = dwBytesToWrite;
            memcpy(fi_buf + sizeof(ipc_req_fast_init_t), data, dwBytesToWrite);

            /* Release lock during network call */
            LeaveCriticalSection(&g_state_lock);

            ipc_header_t resp_hdr;
            uint8_t resp_buf[OPENSHIM_MAX_PAYLOAD];
            status = ipc_send_command_sync(IPC_CMD_FAST_INIT, fi_buf,
                                           sizeof(ipc_req_fast_init_t) + dwBytesToWrite,
                                           &resp_hdr, resp_buf, sizeof(resp_buf));

            EnterCriticalSection(&g_state_lock);
            /* Fast-init request was transmitted on the line */
            *lpdwBytesWritten = dwBytesToWrite;
            actual = dwBytesToWrite;

            /* Push echo of the 0x81 request into local RX FIFO so TuneECU can read it */
            log_message("[LOCAL_ECHO] FAST_INIT synthetic local echo");
            fifo_push_locked(data, dwBytesToWrite);

            /* If helper returned fast-init response bytes, queue them into RX FIFO */
            if (status == FT_OK && resp_hdr.payload_len >= sizeof(ipc_resp_fast_init_t)) {
                const ipc_resp_fast_init_t *fi_resp = (const ipc_resp_fast_init_t *)resp_buf;
                if (fi_resp->rx_data_len > 0) {
                    const BYTE *rx_data = resp_buf + sizeof(ipc_resp_fast_init_t);
                    fifo_push_locked(rx_data, fi_resp->rx_data_len);
                    log_message("[FAST_INIT] Queued %u bytes ECU fast-init response into RX FIFO",
                                fi_resp->rx_data_len);
                }
            }
            if (g_state.rx_count > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
                event_to_signal = g_state.event_handle;
            }
            status = FT_OK;
        }
        LeaveCriticalSection(&g_state_lock);

        if (event_to_signal != NULL) {
            SetEvent(event_to_signal);
        }
        log_transfer("FT_Write", ftHandle, data, dwBytesToWrite, actual, status);
        return status;
    }

    if (g_state.backend_mode == BACKEND_MODE_LOOPBACK) {
        /* Synthetic loopback for testing */
        g_state.tx_count = dwBytesToWrite;
        actual = (DWORD)fifo_push_locked(data, (size_t)dwBytesToWrite);
        g_state.tx_count = 0;
        *lpdwBytesWritten = actual;
        if (actual > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
            event_to_signal = g_state.event_handle;
        }
        if (actual != dwBytesToWrite) {
            status = FT_INSUFFICIENT_RESOURCES;
        }
        LeaveCriticalSection(&g_state_lock);
    } else {
        /* IPC backend mode */
        status = ensure_ipc_channel_connected_locked();
        if (status != FT_OK) {
            LeaveCriticalSection(&g_state_lock);
            return status;
        }

        uint8_t write_buf[sizeof(ipc_req_write_t) + OPENSHIM_MAX_PAYLOAD];
        ipc_req_write_t *req = (ipc_req_write_t *)write_buf;
        req->channel_id = g_ipc.channel_id;
        req->tx_flags = 0;
        req->timeout_ms = g_state.write_timeout ? g_state.write_timeout : 500;
        req->data_len = dwBytesToWrite;
        memcpy(write_buf + sizeof(ipc_req_write_t), data, dwBytesToWrite);

        LeaveCriticalSection(&g_state_lock);

        ipc_header_t resp_hdr;
        ipc_resp_write_t resp;
        status = ipc_send_command_sync(IPC_CMD_WRITE, write_buf,
                                       sizeof(ipc_req_write_t) + dwBytesToWrite,
                                       &resp_hdr, &resp, sizeof(resp));

        EnterCriticalSection(&g_state_lock);
        if (status == FT_OK) {
            actual = resp.bytes_written;
            *lpdwBytesWritten = actual;
            // Provide instant synthetic echo to satisfy TuneECU's FTDI expectations,
            // because we are dropping hardware TX Loopback in the helper.
            log_message("[LOCAL_ECHO] FT_Write IPC synthetic local echo");
            fifo_push_locked(data, actual);
            if (actual > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
                event_to_signal = g_state.event_handle;
            }
        }
        LeaveCriticalSection(&g_state_lock);
    }

    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_transfer("FT_Write", ftHandle, data, dwBytesToWrite, actual, status);
    return status;
}

#define SIMPLE_HANDLE_SETTER(function_name, field_name, value_expression, format_text, ...) \
    FT_STATUS WINAPI function_name(FT_HANDLE ftHandle)                                      \
    {                                                                                        \
        FT_STATUS status;                                                                    \
        EnterCriticalSection(&g_state_lock);                                                 \
        status = check_handle_locked(ftHandle);                                              \
        if (status == FT_OK) {                                                               \
            g_state.field_name = (value_expression);                                         \
        }                                                                                    \
        LeaveCriticalSection(&g_state_lock);                                                 \
        log_message(#function_name "(handle=%p) -> status=%lu" format_text,                  \
                    ftHandle, (unsigned long)status, ##__VA_ARGS__);                          \
        return status;                                                                       \
    }

SIMPLE_HANDLE_SETTER(FT_SetDtr, dtr, TRUE, ", dtr=1")
SIMPLE_HANDLE_SETTER(FT_ClrDtr, dtr, FALSE, ", dtr=0")
SIMPLE_HANDLE_SETTER(FT_SetRts, rts, TRUE, ", rts=1")
SIMPLE_HANDLE_SETTER(FT_ClrRts, rts, FALSE, ", rts=0")

static void execute_five_baud_init_locked(uint8_t target_address, HANDLE *event_to_signal)
{
    if (g_state.backend_mode == BACKEND_MODE_LOOPBACK) {
        uint8_t kb1, kb2;
        if (target_address == 0x33) {
            kb1 = 0x08;
            kb2 = 0x08;
        } else if (target_address == 0xD5) {
            kb1 = 0xD9;
            kb2 = 0x8F;
        } else {
            kb1 = 0x08;
            kb2 = 0x08;
        }
        BYTE resp_bytes[3] = { 0x55, kb1, kb2 };
        log_message("[LOCAL_ECHO] 5-BAUD synthetic local response");
            fifo_push_locked(resp_bytes, 3);

        g_state.five_baud_state = FIVE_BAUD_STATE_AWAITING_INIT;
        g_state.expected_init = (uint8_t)(kb2 ^ 0xFF);
        g_state.expected_ack = (uint8_t)(target_address ^ 0xFF);
        g_state.five_baud_timestamp = GetTickCount();
        g_state.five_baud_rx_ready = TRUE;

        log_message("[FIVE_BAUD] Loopback: queued [0x55, 0x%02X, 0x%02X], expected_init=0x%02X, expected_ack=0x%02X",
                    kb1, kb2, g_state.expected_init, g_state.expected_ack);

        if (g_state.rx_count > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
            *event_to_signal = g_state.event_handle;
        }
        return;
    }

    /* IPC backend mode */
    FT_STATUS status = ensure_ipc_channel_connected_locked();
    if (status != FT_OK) {
        log_message("[FIVE_BAUD] Failed to connect IPC channel (status=%lu)", (unsigned long)status);
        return;
    }

    ipc_req_five_baud_init_t req;
    req.channel_id = g_ipc.channel_id;
    req.target_address = target_address;
    memset(req.pad, 0, sizeof(req.pad));

    LeaveCriticalSection(&g_state_lock);

    ipc_header_t resp_hdr;
    ipc_resp_five_baud_init_t resp;
    status = ipc_send_command_sync(IPC_CMD_FIVE_BAUD_INIT, &req, sizeof(req),
                                   &resp_hdr, &resp, sizeof(resp));

    EnterCriticalSection(&g_state_lock);

    if (status == FT_OK && resp_hdr.status == IPC_STATUS_OK && resp.num_keybytes >= 2) {
        uint8_t kb1 = 0, kb2 = 0;
        BYTE norm_bytes[3];
        norm_bytes[0] = 0x55;

        if (resp.keybytes[0] == 0x55 && resp.num_keybytes >= 3) {
            kb1 = resp.keybytes[1];
            kb2 = resp.keybytes[2];
            norm_bytes[1] = kb1;
            norm_bytes[2] = kb2;
        } else {
            kb1 = resp.keybytes[0];
            kb2 = resp.keybytes[1];
            norm_bytes[1] = kb1;
            norm_bytes[2] = kb2;
        }

        fifo_push_locked(norm_bytes, 3);

        g_state.five_baud_state = FIVE_BAUD_STATE_AWAITING_INIT;
        g_state.expected_init = (uint8_t)(kb2 ^ 0xFF);
        g_state.expected_ack = (uint8_t)(target_address ^ 0xFF);
        g_state.five_baud_timestamp = GetTickCount();
        g_state.five_baud_rx_ready = TRUE;

        log_message("[FIVE_BAUD] IPC success: queued [0x55, 0x%02X, 0x%02X], expected_init=0x%02X, expected_ack=0x%02X",
                    kb1, kb2, g_state.expected_init, g_state.expected_ack);

        if (g_state.rx_count > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
            *event_to_signal = g_state.event_handle;
        }
    } else {
        log_message("[FIVE_BAUD] IPC call failed (transport_status=%lu, ipc_status=%u, num_keybytes=%u)",
                    (unsigned long)status, resp_hdr.status, resp.num_keybytes);
    }
}

static void handle_break_bit_locked(uint8_t bit, HANDLE *event_to_signal)
{
    // Timing-based 5-baud decoder
    DWORD now = GetTickCount();
    

    if (g_state.break_bit_count > 0 && (now - g_state.last_break_time) > 3000) {
        log_message("[FIVE_BAUD] Break train timed out (>3000ms); resetting accumulator");
        g_state.break_bit_count = 0;
        g_state.break_bit_accumulator = 0;
        g_state.last_break_val = 1;
        if (bit == 0) { // start bit?
            g_state.last_break_time = now;
            g_state.last_break_val = 0;
        }
        return;
    }

    if (g_state.fast_init_state != FAST_INIT_IDLE) {
        // If we are actively in a FAST_INIT initialization, ignore break bits as 5-baud
        return;
    }

    if (bit != g_state.last_break_val) {
        DWORD time_spent = now - g_state.last_break_time;
        // ~200ms per bit (5 baud)
        DWORD num_bits = (time_spent + 100) / 200;
        
        log_message("DEBUG_TRANSITION bit=%d last=%d count=%ld time_spent=%ld num_bits=%ld", bit, g_state.last_break_val, (long)g_state.break_bit_count, time_spent, num_bits);
        
        int is_first = 0;
        if (g_state.break_bit_count == 0 && bit == 0 && g_state.last_break_val == 1) {
            num_bits = 0;
            is_first = 1;
            log_message("[FIVE_BAUD] Initial transition to LOW detected");
                    }
        
        if (num_bits == 0 && !is_first) num_bits = 1; // Catch transitions that were too fast
        
        for (DWORD i = 0; i < num_bits && g_state.break_bit_count < 10; i++) {
            g_state.break_bit_accumulator |= ((uint32_t)g_state.last_break_val << g_state.break_bit_count);
            g_state.break_bit_count++;
        }
        
        g_state.last_break_time = now;
        g_state.last_break_val = bit;
    }
}

static void check_five_baud_completion_locked(HANDLE *event_to_signal) {
    if (g_state.break_bit_count > 0 && g_state.break_bit_count < 10 && g_state.last_break_val == 1) {
        DWORD now = GetTickCount();
        DWORD time_spent = now - g_state.last_break_time;
        DWORD num_bits = (time_spent + 100) / 200;
        if (g_state.break_bit_count + num_bits >= 10) {
            num_bits = 10 - g_state.break_bit_count;
            for (DWORD i = 0; i < num_bits; i++) {
                g_state.break_bit_accumulator |= (1 << g_state.break_bit_count);
                g_state.break_bit_count++;
            }
        }
    }
    
    if (g_state.break_bit_count == 10) {
        uint32_t pat = g_state.break_bit_accumulator;
        g_state.break_bit_count = 0;
        g_state.break_bit_accumulator = 0;
        
        // Start bit 0 (bit0), Stop bit 1 (bit9)
        if ((pat & 0x01) == 0x00 && ((pat >> 9) & 0x01) == 0x01) {
            uint8_t addr = (uint8_t)((pat >> 1) & 0xFF);
            if (addr == 0x33 || addr == 0xD5) {
                log_message("[FIVE_BAUD] Recognized 10-bit sequence (via timing) for address 0x%02X", addr);
                execute_five_baud_init_locked(addr, event_to_signal);
            } else {
                log_message("[FIVE_BAUD] 10-bit valid but unhandled address 0x%02X (pat=0x%03X)", addr, pat);
            }
        } else {
            log_message("[FIVE_BAUD] 10-bit framing invalid: pattern=0x%03X", pat);
        }
    }
}

FT_STATUS WINAPI FT_SetBreakOn(FT_HANDLE ftHandle)
{
    FT_STATUS status;
    HANDLE event_to_signal = NULL;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.break_on = TRUE;
        if (g_state.fast_init_state == FAST_INIT_BAUD_360) {
                        g_state.fast_init_state = FAST_INIT_BREAK_ON;
            log_message("[FAST_INIT] Transitioned to FAST_INIT_BREAK_ON");
        }

        /* 5-baud break bit-banging detection (Break On = Space = 0) */
        handle_break_bit_locked(0, &event_to_signal);
        check_five_baud_completion_locked(&event_to_signal);
    }
    LeaveCriticalSection(&g_state_lock);
    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_message("FT_SetBreakOn(handle=%p) -> status=%lu, break=on",
                ftHandle, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetBreakOff(FT_HANDLE ftHandle)
{
    FT_STATUS status;
    HANDLE event_to_signal = NULL;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.break_on = FALSE;
        if (g_state.fast_init_state == FAST_INIT_BREAK_ON) {
            g_state.fast_init_state = FAST_INIT_BREAK_OFF;
            log_message("[FAST_INIT] Transitioned to FAST_INIT_BREAK_OFF");
        }

        /* 5-baud break bit-banging detection (Break Off = Mark = 1) */
        handle_break_bit_locked(1, &event_to_signal);
        check_five_baud_completion_locked(&event_to_signal);
    }
    LeaveCriticalSection(&g_state_lock);
    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_message("FT_SetBreakOff(handle=%p) -> status=%lu, break=off",
                ftHandle, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetBaudRate(FT_HANDLE ftHandle, DWORD dwBaudRate)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.baud_rate = dwBaudRate;
    g_state.break_bit_count = 0;
    g_state.break_bit_accumulator = 0;

        if (dwBaudRate == 360) {
            /* KWP FAST_INIT sequence start: 360 baud low pulse */
            g_state.fast_init_state = FAST_INIT_BAUD_360;
            log_message("[FAST_INIT] Detected baud=360; entering FAST_INIT_BAUD_360 state. Not sending 360 to J2534.");
        } else if (dwBaudRate == 10400 && g_state.fast_init_state == FAST_INIT_ZERO_SENT) {
            g_state.fast_init_state = FAST_INIT_WAIT_START_COMM;
            log_message("[FAST_INIT] Baud restored to 10400; waiting for StartCommunication frame.");
        } else {
            /* Ordinary baud rate update */
            if (g_state.backend_mode == BACKEND_MODE_IPC && g_ipc.channel_connected) {
                ipc_req_set_config_t req;
                req.channel_id = g_ipc.channel_id;
                req.parameter = 1; /* CONFIG_DATA_RATE */
                req.value = dwBaudRate;
                LeaveCriticalSection(&g_state_lock);

                ipc_header_t resp_hdr;
                ipc_send_command_sync(IPC_CMD_SET_CONFIG, &req, sizeof(req), &resp_hdr, NULL, 0);

                EnterCriticalSection(&g_state_lock);
                log_message("[ipc] PassThruIoctl(SET_CONFIG, DATA_RATE=%lu) -> status=%u",
                            (unsigned long)dwBaudRate, resp_hdr.status);
            }
        }
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetBaudRate(handle=%p, baud=%lu) -> status=%lu",
                ftHandle, (unsigned long)dwBaudRate, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetDataCharacteristics(FT_HANDLE ftHandle, UCHAR uWordLength,
                                            UCHAR uStopBits, UCHAR uParity)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.word_length = uWordLength;
        g_state.stop_bits = uStopBits;
        g_state.parity = uParity;
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetDataCharacteristics(handle=%p, word_length=%u, stop_bits=%u, parity=%u) -> status=%lu",
                ftHandle, (unsigned)uWordLength, (unsigned)uStopBits,
                (unsigned)uParity, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetFlowControl(FT_HANDLE ftHandle, USHORT usFlowControl,
                                   UCHAR uXon, UCHAR uXoff)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.flow_control = usFlowControl;
        g_state.xon = uXon;
        g_state.xoff = uXoff;
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetFlowControl(handle=%p, flow=0x%04X, xon=0x%02X, xoff=0x%02X) -> status=%lu",
                ftHandle, (unsigned)usFlowControl, (unsigned)uXon,
                (unsigned)uXoff, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_Purge(FT_HANDLE ftHandle, DWORD dwMask)
{
    FT_STATUS status;
    size_t rx_before = 0;
    size_t tx_before = 0;
    HANDLE event_to_signal = NULL;

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        if (g_state.break_bit_count == 9 && g_state.last_break_val == 1) {
            // TuneECU calls FT_Purge ~7ms after the final HIGH transition.
            // Explicitly finalize the frame by assuming the Stop bit.
            g_state.break_bit_accumulator |= (1 << 9);
            g_state.break_bit_count = 10;
        }
        if (g_state.break_bit_count > 0 && g_state.last_break_val == 1) {
            check_five_baud_completion_locked(&event_to_signal);
        }
        rx_before = g_state.rx_count;
        tx_before = g_state.tx_count;
        if (g_state.five_baud_rx_ready) {
            /* Preserve 5-baud keybytes in RX FIFO */
            g_state.five_baud_rx_ready = FALSE;
            log_message("[FIVE_BAUD] FT_Purge: Preserved 5-baud keybytes in RX FIFO");
        } else {
            if ((dwMask & FT_PURGE_RX) != 0) {
                g_state.rx_head = 0;
                g_state.rx_tail = 0;
                g_state.rx_count = 0;
            }
        }
        if ((dwMask & FT_PURGE_TX) != 0) {
            g_state.tx_count = 0;
        }

        if (g_state.backend_mode == BACKEND_MODE_IPC && g_ipc.channel_connected) {
            uint32_t ch_id = g_ipc.channel_id;
            LeaveCriticalSection(&g_state_lock);

            if ((dwMask & FT_PURGE_RX) != 0) {
                ipc_req_clear_buffer_t req = { ch_id };
                ipc_send_command_sync(IPC_CMD_CLEAR_RX, &req, sizeof(req), NULL, NULL, 0);
            }
            if ((dwMask & FT_PURGE_TX) != 0) {
                ipc_req_clear_buffer_t req = { ch_id };
                ipc_send_command_sync(IPC_CMD_CLEAR_TX, &req, sizeof(req), NULL, NULL, 0);
            }

            EnterCriticalSection(&g_state_lock);
        }
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_Purge(handle=%p, mask=0x%08lX) -> status=%lu, cleared_rx=%lu, cleared_tx=%lu",
                ftHandle, (unsigned long)dwMask, (unsigned long)status,
                (unsigned long)(((dwMask & FT_PURGE_RX) != 0) ? rx_before : 0),
                (unsigned long)(((dwMask & FT_PURGE_TX) != 0) ? tx_before : 0));
    if (event_to_signal != NULL) SetEvent(event_to_signal);
    return status;
}

FT_STATUS WINAPI FT_SetTimeouts(FT_HANDLE ftHandle, DWORD dwReadTimeout,
                                DWORD dwWriteTimeout)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.read_timeout = dwReadTimeout;
        g_state.write_timeout = dwWriteTimeout;
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetTimeouts(handle=%p, read_ms=%lu, write_ms=%lu) -> status=%lu",
                ftHandle, (unsigned long)dwReadTimeout,
                (unsigned long)dwWriteTimeout, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_GetStatus(FT_HANDLE ftHandle, LPDWORD lpdwAmountInRxQueue,
                              LPDWORD lpdwAmountInTxQueue, LPDWORD lpdwEventStatus)
{
    FT_STATUS status;
    DWORD rx = 0;
    DWORD tx = 0;
    DWORD events = 0;

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK && (lpdwAmountInRxQueue == NULL ||
                            lpdwAmountInTxQueue == NULL ||
                            lpdwEventStatus == NULL)) {
        status = FT_INVALID_PARAMETER;
    } else if (status == FT_OK) {
        rx = (DWORD)g_state.rx_count;
        tx = (DWORD)g_state.tx_count;
        events = rx > 0 ? FT_EVENT_RXCHAR : 0;
        *lpdwAmountInRxQueue = rx;
        *lpdwAmountInTxQueue = tx;
        *lpdwEventStatus = events;
    }
    LeaveCriticalSection(&g_state_lock);

    static int getstatus_dropped = 0;
    if (rx == 0 && tx == 0 && events == 0 && status == FT_OK) {
        getstatus_dropped++;
    } else {
        if (getstatus_dropped > 0) {
            log_message("    (suppressed %d idle FT_GetStatus calls)", getstatus_dropped);
            getstatus_dropped = 0;
        }
        log_message("FT_GetStatus(handle=%p, rx_out=%p, tx_out=%p, event_out=%p) -> status=%lu, rx=%lu, tx=%lu, events=0x%08lX",
                    ftHandle, (void *)lpdwAmountInRxQueue, (void *)lpdwAmountInTxQueue,
                    (void *)lpdwEventStatus, (unsigned long)status,
                    (unsigned long)rx, (unsigned long)tx, (unsigned long)events);
    }
    return status;
}

FT_STATUS WINAPI FT_SetEventNotification(FT_HANDLE ftHandle, DWORD dwEventMask,
                                         PVOID pvArg)
{
    FT_STATUS status;
    HANDLE event_to_signal = NULL;

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.event_mask = dwEventMask;
        g_state.event_handle = (HANDLE)pvArg;
        if (g_state.rx_count > 0 && (dwEventMask & FT_EVENT_RXCHAR) != 0) {
            event_to_signal = g_state.event_handle;
        }
    }
    LeaveCriticalSection(&g_state_lock);

    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_message("FT_SetEventNotification(handle=%p, mask=0x%08lX, event=%p) -> status=%lu",
                ftHandle, (unsigned long)dwEventMask, pvArg,
                (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetLatencyTimer(FT_HANDLE ftHandle, UCHAR ucLatency)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.latency_timer = ucLatency;
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetLatencyTimer(handle=%p, latency=%u) -> status=%lu",
                ftHandle, (unsigned)ucLatency, (unsigned long)status);
    return status;
}

FT_STATUS WINAPI FT_SetUSBParameters(FT_HANDLE ftHandle, DWORD dwInTransferSize,
                                     DWORD dwOutTransferSize)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.usb_in_size = dwInTransferSize;
        g_state.usb_out_size = dwOutTransferSize;
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_SetUSBParameters(handle=%p, in_size=%lu, out_size=%lu) -> status=%lu",
                ftHandle, (unsigned long)dwInTransferSize,
                (unsigned long)dwOutTransferSize, (unsigned long)status);
    return status;
}
