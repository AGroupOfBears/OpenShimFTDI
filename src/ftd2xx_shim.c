#define WIN32_LEAN_AND_MEAN
#include "ftd2xx_shim.h"

#include <stdarg.h>
#include <stdint.h>
#include <stdio.h>
#include <string.h>

#define SHIM_VERSION "0.1.1"
#define FAKE_DESCRIPTION "OpenPort 2.0 FTDI Bridge"
#define FAKE_SERIAL "OP20SHIM01"
#define FAKE_HANDLE_VALUE ((uintptr_t)0xF7D20001UL)
#define RX_FIFO_CAPACITY (64U * 1024U)

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
} ShimState;

static HMODULE g_module;
static CRITICAL_SECTION g_state_lock;
static CRITICAL_SECTION g_log_lock;
static BOOL g_locks_ready;
static FILE *g_log_file;
static ShimState g_state;

static void reset_open_state_locked(void)
{
    ZeroMemory(&g_state, sizeof(g_state));
    g_state.handle = (FT_HANDLE)FAKE_HANDLE_VALUE;
    g_state.baud_rate = 9600;
    g_state.word_length = 8;
    g_state.stop_bits = 0;
    g_state.parity = 0;
    g_state.latency_timer = 16;
    g_state.usb_in_size = 4096;
    g_state.usb_out_size = 4096;
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

BOOL WINAPI DllMain(HINSTANCE instance, DWORD reason, LPVOID reserved)
{
    (void)reserved;
    if (reason == DLL_PROCESS_ATTACH) {
        g_module = instance;
        InitializeCriticalSection(&g_state_lock);
        InitializeCriticalSection(&g_log_lock);
        g_locks_ready = TRUE;
        reset_open_state_locked();
        DisableThreadLibraryCalls(instance);
    } else if (reason == DLL_PROCESS_DETACH && g_locks_ready) {
        if (g_log_file != NULL) {
            fflush(g_log_file);
            fclose(g_log_file);
            g_log_file = NULL;
        }
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
            /* Be permissive for wrappers that put the count in the second slot. */
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
        /* A compatibility fallback used by a few old managed wrappers. */
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
        g_state.opened = TRUE;
        *pHandle = g_state.handle;
        result = *pHandle;
    }
    LeaveCriticalSection(&g_state_lock);

    log_message("FT_Open(device=%lu, handle_out=%p) -> status=%lu, handle=%p",
                (unsigned long)deviceNumber, (void *)pHandle,
                (unsigned long)status, result);
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

    /*
     * TuneECU 2.5.5 passes FT_LIST_BY_INDEX through to FT_OpenEx, producing
     * 0x40000002 for a description open. Real D2XX tolerates that legacy
     * combination, so only inspect the low FT_OPEN_BY_* selector bits here.
     */
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
        g_state.opened = TRUE;
        *pHandle = g_state.handle;
        result = *pHandle;
    }
    LeaveCriticalSection(&g_state_lock);

    log_message("FT_OpenEx(arg=%p, flags=0x%08lX, open_flags=0x%08lX, selector=%s, value=%s, handle_out=%p) -> status=%lu, handle=%p",
                pvArg1, (unsigned long)dwFlags, (unsigned long)open_flags, selector,
                text != NULL ? text : "<non-string>", (void *)pHandle,
                (unsigned long)status, result);
    return status;
}

FT_STATUS WINAPI FT_Close(FT_HANDLE ftHandle)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
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
    FT_STATUS status;
    DWORD actual = 0;
    HANDLE event_to_signal = NULL;

    if (lpdwBytesWritten != NULL) {
        *lpdwBytesWritten = 0;
    }

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK && lpdwBytesWritten == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (status == FT_OK && dwBytesToWrite > 0 && lpBuffer == NULL) {
        status = FT_INVALID_PARAMETER;
    } else if (status == FT_OK) {
        g_state.tx_count = dwBytesToWrite;
        actual = (DWORD)fifo_push_locked((const BYTE *)lpBuffer,
                                         (size_t)dwBytesToWrite);
        g_state.tx_count = 0;
        *lpdwBytesWritten = actual;
        if (actual > 0 && (g_state.event_mask & FT_EVENT_RXCHAR) != 0) {
            event_to_signal = g_state.event_handle;
        }
        if (actual != dwBytesToWrite) {
            status = FT_INSUFFICIENT_RESOURCES;
        }
    }
    LeaveCriticalSection(&g_state_lock);

    if (event_to_signal != NULL) {
        SetEvent(event_to_signal);
    }
    log_transfer("FT_Write", ftHandle, (const BYTE *)lpBuffer,
                 dwBytesToWrite, actual, status);
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
SIMPLE_HANDLE_SETTER(FT_SetBreakOn, break_on, TRUE, ", break=on")
SIMPLE_HANDLE_SETTER(FT_SetBreakOff, break_on, FALSE, ", break=off")

FT_STATUS WINAPI FT_SetBaudRate(FT_HANDLE ftHandle, DWORD dwBaudRate)
{
    FT_STATUS status;
    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        g_state.baud_rate = dwBaudRate;
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

    EnterCriticalSection(&g_state_lock);
    status = check_handle_locked(ftHandle);
    if (status == FT_OK) {
        rx_before = g_state.rx_count;
        tx_before = g_state.tx_count;
        if ((dwMask & FT_PURGE_RX) != 0) {
            g_state.rx_head = 0;
            g_state.rx_tail = 0;
            g_state.rx_count = 0;
        }
        if ((dwMask & FT_PURGE_TX) != 0) {
            g_state.tx_count = 0;
        }
    }
    LeaveCriticalSection(&g_state_lock);
    log_message("FT_Purge(handle=%p, mask=0x%08lX) -> status=%lu, cleared_rx=%lu, cleared_tx=%lu",
                ftHandle, (unsigned long)dwMask, (unsigned long)status,
                (unsigned long)(((dwMask & FT_PURGE_RX) != 0) ? rx_before : 0),
                (unsigned long)(((dwMask & FT_PURGE_TX) != 0) ? tx_before : 0));
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

    log_message("FT_GetStatus(handle=%p, rx_out=%p, tx_out=%p, event_out=%p) -> status=%lu, rx=%lu, tx=%lu, events=0x%08lX",
                ftHandle, (void *)lpdwAmountInRxQueue, (void *)lpdwAmountInTxQueue,
                (void *)lpdwEventStatus, (unsigned long)status,
                (unsigned long)rx, (unsigned long)tx, (unsigned long)events);
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
    log_message("FT_SetEventNotification(handle=%p, mask=0x%08lX, event=%p) -> status=%lu%s",
                ftHandle, (unsigned long)dwEventMask, pvArg,
                (unsigned long)status,
                event_to_signal != NULL ? ", signaled=pending-rx" : "");
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
    log_message("FT_SetLatencyTimer(handle=%p, latency_ms=%u) -> status=%lu",
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
