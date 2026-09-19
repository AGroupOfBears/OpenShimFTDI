#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include <signal.h>
#include <dlfcn.h>
#include <pthread.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <time.h>

#include "../../include/openshim_ipc.h"
#define J2534_TX_MSG_TYPE 0x00000001

/* J2534 Types and Constants */
#define PM_DATA_LEN 4128

typedef struct {
    unsigned long Parameter;
    unsigned long Value;
} J2534_SCONFIG;

typedef struct {
    unsigned long NumOfParams;
    J2534_SCONFIG *ConfigPtr;
} J2534_SCONFIG_LIST;

typedef struct {
    unsigned long ProtocolID;
    unsigned long RxStatus;
    unsigned long TxFlags;
    unsigned long Timestamp;
    unsigned long DataSize;
    unsigned long ExtraDataIndex;
    unsigned char Data[PM_DATA_LEN];
} J2534_PASSTHRU_MSG;

typedef struct {
    unsigned long NumOfBytes;
    unsigned char *BytePtr;
} J2534_SBYTE_ARRAY;

enum J2534_IoctlID {
    J2534_GET_CONFIG = 1,
    J2534_SET_CONFIG = 2,
    J2534_READ_VBATT = 3,
    J2534_FIVE_BAUD_INIT = 4,
    J2534_FAST_INIT = 5,
    J2534_CLEAR_TX_BUFFER = 7,
    J2534_CLEAR_RX_BUFFER = 8
};

enum J2534_ConfigParam {
    CONFIG_DATA_RATE = 1,
    CONFIG_LOOPBACK = 3,
    CONFIG_NODE_ADDRESS = 4,
    CONFIG_NETWORK_LINE = 5,
    CONFIG_P1_MIN = 6,
    CONFIG_P1_MAX = 7,
    CONFIG_P2_MIN = 8,
    CONFIG_P2_MAX = 9,
    CONFIG_P3_MIN = 10,
    CONFIG_P3_MAX = 11,
    CONFIG_P4_MIN = 12,
    CONFIG_P4_MAX = 13,
    CONFIG_W1 = 14,
    CONFIG_W2 = 15,
    CONFIG_W3 = 16,
    CONFIG_W4 = 17,
    CONFIG_W5 = 18,
    CONFIG_TIDLE = 19,
    CONFIG_TINIL = 20,
    CONFIG_TWUP = 21,
    CONFIG_PARITY = 22,
    CONFIG_BIT_SAMPLE_POINT = 23,
    CONFIG_SYNC_JUMP_WIDTH = 24,
    CONFIG_T1_MAX = 25,
    CONFIG_T2_MAX = 26,
    CONFIG_T3_MAX = 27,
    CONFIG_T4_MAX = 28,
    CONFIG_T5_MAX = 29,
    CONFIG_ISO15765_BS = 30,
    CONFIG_ISO15765_STMIN = 31,
    CONFIG_DATA_BITS = 32,
    CONFIG_FIVE_BAUD_MOD = 33,
    CONFIG_BS_TX = 34,
    CONFIG_STMIN_TX = 35,
    CONFIG_T3_MIN = 36,
    CONFIG_T4_MIN = 37,
    CONFIG_W0 = 38
};

/* Function pointer prototypes */
typedef int32_t (*fn_PassThruOpen)(const void *pName, unsigned long *pDeviceID);
typedef int32_t (*fn_PassThruClose)(const unsigned long DeviceID);
typedef int32_t (*fn_PassThruConnect)(const unsigned long DeviceID, const unsigned long ProtocolID,
                                      const unsigned long Flags, const unsigned long Baudrate,
                                      unsigned long *pChannelID);
typedef int32_t (*fn_PassThruDisconnect)(const unsigned long ChannelID);
typedef int32_t (*fn_PassThruReadMsgs)(const unsigned long ChannelID, J2534_PASSTHRU_MSG *pMsg,
                                       unsigned long *pNumMsgs, const unsigned long Timeout);
typedef int32_t (*fn_PassThruWriteMsgs)(const unsigned long ChannelID, const J2534_PASSTHRU_MSG *pMsg,
                                        unsigned long *pNumMsgs, const unsigned long Timeout);
typedef int32_t (*fn_PassThruStartMsgFilter)(const unsigned long ChannelID, unsigned long FilterType,
                                             const J2534_PASSTHRU_MSG *pMaskMsg,
                                             const J2534_PASSTHRU_MSG *pPatternMsg,
                                             const J2534_PASSTHRU_MSG *pFlowControlMsg,
                                             unsigned long *pMsgID);
typedef int32_t (*fn_PassThruStopMsgFilter)(const unsigned long ChannelID, const unsigned long MsgID);
typedef int32_t (*fn_PassThruIoctl)(const unsigned long ChannelID, const unsigned long IoctlID,
                                    const void *pInput, void *pOutput);
typedef int32_t (*fn_PassThruGetLastError)(char *pErrorDescription);

static struct {
    void *lib_handle;
    fn_PassThruOpen PassThruOpen;
    fn_PassThruClose PassThruClose;
    fn_PassThruConnect PassThruConnect;
    fn_PassThruDisconnect PassThruDisconnect;
    fn_PassThruReadMsgs PassThruReadMsgs;
    fn_PassThruWriteMsgs PassThruWriteMsgs;
    fn_PassThruStartMsgFilter PassThruStartMsgFilter;
    fn_PassThruStopMsgFilter PassThruStopMsgFilter;
    fn_PassThruIoctl PassThruIoctl;
    fn_PassThruGetLastError PassThruGetLastError;
} g_j2534;

static pthread_mutex_t g_j2534_lock = PTHREAD_MUTEX_INITIALIZER;

typedef struct {
    int client_fd;
    pthread_mutex_t send_lock;
    pthread_t rx_thread;
    volatile bool rx_thread_running;

    bool device_open;
    unsigned long device_id;

    bool channel_connected;
    unsigned long channel_id;
    unsigned long protocol_id;
    unsigned long current_baud;
} client_context_t;

static volatile sig_atomic_t g_running = 1;

static void sig_handler(int signum)
{
    (void)signum;
    g_running = 0;
}

static void log_timestamp(void)
{
    struct timespec ts;
    clock_gettime(CLOCK_REALTIME, &ts);
    struct tm tm_info;
    localtime_r(&ts.tv_sec, &tm_info);
    char time_str[32];
    strftime(time_str, sizeof(time_str), "%Y-%m-%d %H:%M:%S", &tm_info);
    printf("[%s.%03ld] [helper] ", time_str, ts.tv_nsec / 1000000);
}

static void log_hexdump(const char *prefix, const uint8_t *data, size_t len)
{
    log_timestamp();
    printf("%s (len=%zu):", prefix, len);
    if (len == 0 || data == NULL) {
        printf(" <empty>\n");
        return;
    }
    for (size_t i = 0; i < len; ++i) {
        printf(" %02X", data[i]);
    }
    printf("\n");
    fflush(stdout);
}

static int send_all(int fd, const void *buf, size_t len)
{
    const uint8_t *p = (const uint8_t *)buf;
    while (len > 0) {
        ssize_t n = write(fd, p, len);
        if (n <= 0) {
            if (n < 0 && (errno == EINTR || errno == EAGAIN)) continue;
            return -1;
        }
        p += n;
        len -= n;
    }
    return 0;
}

static int recv_all(int fd, void *buf, size_t len)
{
    uint8_t *p = (uint8_t *)buf;
    while (len > 0) {
        ssize_t n = read(fd, p, len);
        if (n <= 0) {
            if (n < 0 && (errno == EINTR || errno == EAGAIN)) continue;
            return -1;
        }
        p += n;
        len -= n;
    }
    return 0;
}

static int send_ipc_reply(client_context_t *ctx, uint16_t cmd_id, uint32_t seq_id,
                          uint32_t status, const void *payload, uint32_t payload_len)
{
    ipc_header_t hdr;
    hdr.magic = OPENSHIM_IPC_MAGIC;
    hdr.version = OPENSHIM_IPC_VERSION;
    hdr.command_id = cmd_id;
    hdr.seq_id = seq_id;
    hdr.status = status;
    hdr.payload_len = payload_len;

    pthread_mutex_lock(&ctx->send_lock);
    int ret = send_all(ctx->client_fd, &hdr, sizeof(hdr));
    if (ret == 0 && payload_len > 0 && payload != NULL) {
        ret = send_all(ctx->client_fd, payload, payload_len);
    }
    pthread_mutex_unlock(&ctx->send_lock);
    return ret;
}

static int push_ipc_rx_data(client_context_t *ctx, uint32_t channel_id, uint32_t rx_status,
                            uint32_t timestamp, const uint8_t *data, uint32_t data_len)
{
    ipc_push_rx_data_t push_hdr;
    push_hdr.channel_id = channel_id;
    push_hdr.rx_status = rx_status;
    push_hdr.timestamp = timestamp;
    push_hdr.data_len = data_len;

    uint32_t total_payload = sizeof(push_hdr) + data_len;
    ipc_header_t hdr;
    hdr.magic = OPENSHIM_IPC_MAGIC;
    hdr.version = OPENSHIM_IPC_VERSION;
    hdr.command_id = IPC_CMD_RX_DATA;
    hdr.seq_id = 0;
    hdr.status = IPC_STATUS_OK;
    hdr.payload_len = total_payload;

    pthread_mutex_lock(&ctx->send_lock);
    int ret = send_all(ctx->client_fd, &hdr, sizeof(hdr));
    if (ret == 0) {
        ret = send_all(ctx->client_fd, &push_hdr, sizeof(push_hdr));
    }
    if (ret == 0 && data_len > 0 && data != NULL) {
        ret = send_all(ctx->client_fd, data, data_len);
    }
    pthread_mutex_unlock(&ctx->send_lock);
    return ret;
}

/* Background thread to continuously read J2534 messages and push them to client */
static void *rx_worker_thread(void *arg)
{
    client_context_t *ctx = (client_context_t *)arg;
    log_timestamp();
    printf("RX worker thread started for channel=%lu\n", ctx->channel_id);

    while (ctx->rx_thread_running && g_running) {
        if (!ctx->channel_connected || ctx->channel_id == 0) {
            usleep(10000);
            continue;
        }

        J2534_PASSTHRU_MSG msg;
        memset(&msg, 0, sizeof(msg));
        unsigned long num_msgs = 1;

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruReadMsgs(ctx->channel_id, &msg, &num_msgs, 5);
        pthread_mutex_unlock(&g_j2534_lock);

        if (ret == 0 && num_msgs > 0 && msg.DataSize > 0) {
            const char *label = "UNKNOWN";
            if (msg.RxStatus & J2534_TX_MSG_TYPE) {
                label = "HW_TX_INDICATION";
            } else if (msg.RxStatus == 0) {
                label = "ECU_RX";
            } else {
                label = "HW_RX";
            }
            log_timestamp();
            printf("[%s] Chan=%lu Prot=0x%04X, Status=0x%08X (flags=%04lX), TxFlg=%08X, DataSize=%lu\n",
                   label, ctx->channel_id, (unsigned int)msg.ProtocolID, (unsigned int)msg.RxStatus, msg.RxStatus & 0xFFFF, (unsigned int)msg.TxFlags, msg.DataSize);
            log_hexdump(label, msg.Data, msg.DataSize);

            if (msg.RxStatus & 0x00000001) { /* J2534_TX_MSG_TYPE */
                // Drop J2534 hardware TX echoes. The shim provides synchronous synthetic 
                // echo internally to satisfy TuneECU's FTDI expectations instantly.
                continue;
            }
            if (push_ipc_rx_data(ctx, ctx->channel_id, (uint32_t)msg.RxStatus,
                                 (uint32_t)msg.Timestamp, msg.Data, (uint32_t)msg.DataSize) != 0) {
                log_timestamp();
                printf("Failed to push RX data to client socket; exiting RX thread\n");
                break;
            }
        } else {
            usleep(5000);
        }
    }

    log_timestamp();
    printf("RX worker thread terminating for channel=%lu\n", ctx->channel_id);
    return NULL;
}

static void stop_rx_thread(client_context_t *ctx)
{
    if (ctx->rx_thread_running) {
        ctx->rx_thread_running = false;
        pthread_join(ctx->rx_thread, NULL);
    }
}

static void start_rx_thread(client_context_t *ctx)
{
    stop_rx_thread(ctx);
    ctx->rx_thread_running = true;
    pthread_create(&ctx->rx_thread, NULL, rx_worker_thread, ctx);
}

/* J2534 library dynamic loader */
static int load_j2534_library(const char *custom_path)
{
    const char *paths[] = {
        custom_path,
        "./j2534.so",
        "reference/j2534/nikolakozina-j2534/j2534/j2534.so",
        "/usr/local/lib/j2534.so",
        "/usr/lib/j2534.so",
        NULL
    };

    void *h = NULL;
    const char *loaded_path = NULL;

    for (size_t i = 0; paths[i] != NULL; ++i) {
        if (paths[i][0] == '\0') continue;
        h = dlopen(paths[i], RTLD_NOW);
        if (h != NULL) {
            loaded_path = paths[i];
            break;
        }
    }

    if (h == NULL) {
        log_timestamp();
        fprintf(stderr, "ERROR: Could not load j2534.so from any candidate location: %s\n", dlerror());
        return -1;
    }

    g_j2534.lib_handle = h;
    g_j2534.PassThruOpen = (fn_PassThruOpen)dlsym(h, "PassThruOpen");
    g_j2534.PassThruClose = (fn_PassThruClose)dlsym(h, "PassThruClose");
    g_j2534.PassThruConnect = (fn_PassThruConnect)dlsym(h, "PassThruConnect");
    g_j2534.PassThruDisconnect = (fn_PassThruDisconnect)dlsym(h, "PassThruDisconnect");
    g_j2534.PassThruReadMsgs = (fn_PassThruReadMsgs)dlsym(h, "PassThruReadMsgs");
    g_j2534.PassThruWriteMsgs = (fn_PassThruWriteMsgs)dlsym(h, "PassThruWriteMsgs");
    g_j2534.PassThruStartMsgFilter = (fn_PassThruStartMsgFilter)dlsym(h, "PassThruStartMsgFilter");
    g_j2534.PassThruStopMsgFilter = (fn_PassThruStopMsgFilter)dlsym(h, "PassThruStopMsgFilter");
    g_j2534.PassThruIoctl = (fn_PassThruIoctl)dlsym(h, "PassThruIoctl");
    g_j2534.PassThruGetLastError = (fn_PassThruGetLastError)dlsym(h, "PassThruGetLastError");

    if (!g_j2534.PassThruOpen || !g_j2534.PassThruClose || !g_j2534.PassThruConnect ||
        !g_j2534.PassThruDisconnect || !g_j2534.PassThruReadMsgs || !g_j2534.PassThruWriteMsgs ||
        !g_j2534.PassThruIoctl) {
        log_timestamp();
        fprintf(stderr, "ERROR: Failed to resolve essential J2534 entry points in %s\n", loaded_path);
        dlclose(h);
        return -1;
    }

    log_timestamp();
    printf("Successfully loaded J2534 library from: %s\n", loaded_path);
    return 0;
}

/* Dispatch incoming command */
static void handle_client_command(client_context_t *ctx, const ipc_header_t *hdr, const uint8_t *payload)
{
    log_timestamp();
    printf("RECV cmd=%u seq=%u len=%u\n", hdr->command_id, hdr->seq_id, hdr->payload_len);

    switch (hdr->command_id) {
    case IPC_CMD_PING: {
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, NULL, 0);
        break;
    }

    case IPC_CMD_OPEN: {
        if (ctx->device_open) {
            log_timestamp();
            printf("OPEN: device already open (id=%lu)\n", ctx->device_id);
            ipc_resp_open_t resp;
            memset(&resp, 0, sizeof(resp));
            resp.device_id = (uint32_t)ctx->device_id;
            strncpy(resp.description, "Tactrix OpenPort 2.0", sizeof(resp.description) - 1);
            strncpy(resp.firmware_version, "OpenPort 2.0 J2534", sizeof(resp.firmware_version) - 1);
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
            break;
        }

        unsigned long dev_id = 0;
        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruOpen(NULL, &dev_id);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruOpen() -> %d (dev_id=%lu)\n", ret, dev_id);

        if (ret == 0) {
            ctx->device_open = true;
            ctx->device_id = dev_id;
            ipc_resp_open_t resp;
            memset(&resp, 0, sizeof(resp));
            resp.device_id = (uint32_t)dev_id;
            strncpy(resp.description, "Tactrix OpenPort 2.0", sizeof(resp.description) - 1);
            strncpy(resp.firmware_version, "OpenPort 2.0 J2534", sizeof(resp.firmware_version) - 1);
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
        } else {
            uint32_t err = (ret == 8 /* J2534_ERR_DEVICE_NOT_CONNECTED */) ?
                            IPC_STATUS_ERR_NO_HARDWARE : IPC_STATUS_ERR_J2534_FAILED;
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, err, NULL, 0);
        }
        break;
    }

    case IPC_CMD_CLOSE: {
        stop_rx_thread(ctx);
        pthread_mutex_lock(&g_j2534_lock);
        if (ctx->channel_connected) {
            g_j2534.PassThruDisconnect(ctx->channel_id);
            ctx->channel_connected = false;
            ctx->channel_id = 0;
        }
        if (ctx->device_open) {
            g_j2534.PassThruClose(ctx->device_id);
            ctx->device_open = false;
            ctx->device_id = 0;
        }
        pthread_mutex_unlock(&g_j2534_lock);
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, NULL, 0);
        break;
    }

    case IPC_CMD_CONNECT: {
        if (!ctx->device_open) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_connect_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_connect_t *req = (const ipc_req_connect_t *)payload;
        unsigned long ch_id = 0;

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruConnect(ctx->device_id, req->protocol_id, req->flags,
                                              req->baud_rate, &ch_id);
        log_timestamp();
        printf("PassThruConnect(dev=%lu, proto=%u, flags=0x%x, baud=%u) -> %d (ch_id=%lu)\n",
               ctx->device_id, req->protocol_id, req->flags, req->baud_rate, ret, ch_id);

        if (ret == 0) {
            ctx->channel_connected = true;
            ctx->channel_id = ch_id;
            ctx->protocol_id = req->protocol_id;
            ctx->current_baud = req->baud_rate;

            /* Enable LOOPBACK = 1 by default so TX frames echo back to the shim */
            J2534_SCONFIG cfg;
            cfg.Parameter = CONFIG_LOOPBACK;
            cfg.Value = 1;
            J2534_SCONFIG_LIST cfgList;
            cfgList.NumOfParams = 1;
            cfgList.ConfigPtr = &cfg;
            int32_t loop_ret = g_j2534.PassThruIoctl(ch_id, J2534_SET_CONFIG, &cfgList, NULL);
            log_timestamp();
            printf("Set LOOPBACK=1 -> %d\n", loop_ret);

            /* Install Pass-All filter (mask=0, pattern=0) */
            J2534_PASSTHRU_MSG maskMsg;
            memset(&maskMsg, 0, sizeof(maskMsg));
            maskMsg.ProtocolID = req->protocol_id;
            maskMsg.DataSize = 1;
            maskMsg.Data[0] = 0x00;

            J2534_PASSTHRU_MSG patternMsg;
            memset(&patternMsg, 0, sizeof(patternMsg));
            patternMsg.ProtocolID = req->protocol_id;
            patternMsg.DataSize = 1;
            patternMsg.Data[0] = 0x00;

            unsigned long filterId = 0;
            int32_t filter_ret = g_j2534.PassThruStartMsgFilter(ch_id, 1 /* PASS_FILTER */,
                                                               &maskMsg, &patternMsg, NULL, &filterId);
            log_timestamp();
            printf("Start Pass-All Filter -> %d (filter_id=%lu)\n", filter_ret, filterId);
            pthread_mutex_unlock(&g_j2534_lock);

            /* Start background RX worker thread */
            start_rx_thread(ctx);

            ipc_resp_connect_t resp;
            resp.channel_id = (uint32_t)ch_id;
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
        } else {
            pthread_mutex_unlock(&g_j2534_lock);
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        }
        break;
    }

    case IPC_CMD_DISCONNECT: {
        stop_rx_thread(ctx);
        pthread_mutex_lock(&g_j2534_lock);
        if (ctx->channel_connected) {
            g_j2534.PassThruDisconnect(ctx->channel_id);
            ctx->channel_connected = false;
            ctx->channel_id = 0;
        }
        pthread_mutex_unlock(&g_j2534_lock);
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, NULL, 0);
        break;
    }

    case IPC_CMD_SET_CONFIG: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_set_config_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_set_config_t *req = (const ipc_req_set_config_t *)payload;
        J2534_SCONFIG cfg;
        cfg.Parameter = req->parameter;
        cfg.Value = req->value;
        J2534_SCONFIG_LIST cfgList;
        cfgList.NumOfParams = 1;
        cfgList.ConfigPtr = &cfg;

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruIoctl(ctx->channel_id, J2534_SET_CONFIG, &cfgList, NULL);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruIoctl(SET_CONFIG, param=%u, val=%u) -> %d\n", req->parameter, req->value, ret);
        if (ret == 0 && req->parameter == CONFIG_DATA_RATE) {
            ctx->current_baud = req->value;
        }
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, ret == 0 ? IPC_STATUS_OK : IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        break;
    }

    case IPC_CMD_CLEAR_RX: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruIoctl(ctx->channel_id, J2534_CLEAR_RX_BUFFER, NULL, NULL);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruIoctl(CLEAR_RX_BUFFER) -> %d\n", ret);
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, ret == 0 ? IPC_STATUS_OK : IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        break;
    }

    case IPC_CMD_CLEAR_TX: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruIoctl(ctx->channel_id, J2534_CLEAR_TX_BUFFER, NULL, NULL);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruIoctl(CLEAR_TX_BUFFER) -> %d\n", ret);
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, ret == 0 ? IPC_STATUS_OK : IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        break;
    }

    case IPC_CMD_WRITE: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_write_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_write_t *req = (const ipc_req_write_t *)payload;
        if (hdr->payload_len < sizeof(ipc_req_write_t) + req->data_len || req->data_len > PM_DATA_LEN) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const uint8_t *data = payload + sizeof(ipc_req_write_t);
        log_hexdump("WRITE-TX", data, req->data_len);

        J2534_PASSTHRU_MSG msg;
        memset(&msg, 0, sizeof(msg));
        msg.ProtocolID = ctx->protocol_id;
        msg.TxFlags = req->tx_flags;
        msg.DataSize = req->data_len;
        memcpy(msg.Data, data, req->data_len);

        unsigned long num_msgs = 1;
        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruWriteMsgs(ctx->channel_id, &msg, &num_msgs, req->timeout_ms ? req->timeout_ms : 500);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruWriteMsgs() -> %d (num=%lu)\n", ret, num_msgs);

        if (ret == 0) {
            ipc_resp_write_t resp;
            resp.bytes_written = req->data_len;
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
        } else {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        }
        break;
    }

    case IPC_CMD_READ: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        const ipc_req_read_t *req = (const ipc_req_read_t *)payload;
        J2534_PASSTHRU_MSG msg;
        memset(&msg, 0, sizeof(msg));
        unsigned long num = 1;

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruReadMsgs(ctx->channel_id, &msg, &num, req->timeout_ms ? req->timeout_ms : 100);
        pthread_mutex_unlock(&g_j2534_lock);

        if (ret == 0 && num > 0) {
            uint32_t resp_len = sizeof(ipc_resp_read_t) + msg.DataSize;
            uint8_t *buf = malloc(resp_len);
            if (buf) {
                ipc_resp_read_t *resp = (ipc_resp_read_t *)buf;
                resp->num_msgs = (uint32_t)num;
                resp->total_bytes = (uint32_t)msg.DataSize;
                memcpy(buf + sizeof(ipc_resp_read_t), msg.Data, msg.DataSize);
                send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, buf, resp_len);
                free(buf);
            } else {
                send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_GENERAL, NULL, 0);
            }
        } else {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, ret == 9 ? IPC_STATUS_ERR_TIMEOUT : IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        }
        break;
    }

    case IPC_CMD_FAST_INIT: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_fast_init_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_fast_init_t *req = (const ipc_req_fast_init_t *)payload;
        const uint8_t *tx_data = payload + sizeof(ipc_req_fast_init_t);

        log_hexdump("FAST_INIT-TX", tx_data, req->data_len);

        J2534_PASSTHRU_MSG txMsg;
        memset(&txMsg, 0, sizeof(txMsg));
        txMsg.ProtocolID = ctx->protocol_id;
        txMsg.TxFlags = req->tx_flags;
        txMsg.DataSize = req->data_len;
        memcpy(txMsg.Data, tx_data, req->data_len);

        J2534_PASSTHRU_MSG rxMsg;
        memset(&rxMsg, 0, sizeof(rxMsg));

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruIoctl(ctx->channel_id, J2534_FAST_INIT, &txMsg, &rxMsg);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruIoctl(FAST_INIT) -> %d (rx_len=%lu, RxStatus=0x%08X, ExtraDataIndex=%lu)\n", 
               ret, (unsigned long)rxMsg.DataSize, (unsigned int)rxMsg.RxStatus, (unsigned long)rxMsg.ExtraDataIndex);

        if (ret == 0) {
            if (rxMsg.DataSize > 0) {
                log_hexdump("FAST_INIT-RX", rxMsg.Data, rxMsg.DataSize);
            }
            uint32_t resp_len = sizeof(ipc_resp_fast_init_t) + rxMsg.DataSize;
            uint8_t *buf = malloc(resp_len);
            if (buf) {
                ipc_resp_fast_init_t *resp = (ipc_resp_fast_init_t *)buf;
                resp->rx_data_len = (uint32_t)rxMsg.DataSize;
                if (rxMsg.DataSize > 0) {
                    memcpy(buf + sizeof(ipc_resp_fast_init_t), rxMsg.Data, rxMsg.DataSize);
                }
                send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, buf, resp_len);
                free(buf);
            } else {
                send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_GENERAL, NULL, 0);
            }
        } else {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        }
        break;
    }

    case IPC_CMD_START_FILTER: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_start_filter_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_start_filter_t *req = (const ipc_req_start_filter_t *)payload;
        const uint8_t *mask_ptr = payload + sizeof(ipc_req_start_filter_t);
        const uint8_t *pattern_ptr = mask_ptr + req->mask_len;

        J2534_PASSTHRU_MSG maskMsg;
        memset(&maskMsg, 0, sizeof(maskMsg));
        maskMsg.ProtocolID = ctx->protocol_id;
        maskMsg.DataSize = req->mask_len;
        memcpy(maskMsg.Data, mask_ptr, req->mask_len);

        J2534_PASSTHRU_MSG patternMsg;
        memset(&patternMsg, 0, sizeof(patternMsg));
        patternMsg.ProtocolID = ctx->protocol_id;
        patternMsg.DataSize = req->pattern_len;
        memcpy(patternMsg.Data, pattern_ptr, req->pattern_len);

        unsigned long filterId = 0;
        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruStartMsgFilter(ctx->channel_id, req->filter_type,
                                                    &maskMsg, &patternMsg, NULL, &filterId);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruStartMsgFilter(type=%u) -> %d (filter_id=%lu)\n", req->filter_type, ret, filterId);

        if (ret == 0) {
            ipc_resp_start_filter_t resp;
            resp.filter_id = (uint32_t)filterId;
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
        } else {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_J2534_FAILED, NULL, 0);
        }
        break;
    }

    case IPC_CMD_FIVE_BAUD_INIT: {
        if (!ctx->channel_connected) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_CONNECTED, NULL, 0);
            break;
        }
        if (hdr->payload_len < sizeof(ipc_req_five_baud_init_t)) {
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_INVALID_PARAM, NULL, 0);
            break;
        }
        const ipc_req_five_baud_init_t *req = (const ipc_req_five_baud_init_t *)payload;
        log_timestamp();
        printf("FIVE_BAUD_INIT target_address=0x%02X\n", req->target_address);

        uint8_t target_addr = req->target_address;
        J2534_SBYTE_ARRAY in_arr;
        in_arr.NumOfBytes = 1;
        in_arr.BytePtr = &target_addr;

        uint8_t out_buf[16];
        memset(out_buf, 0, sizeof(out_buf));
        J2534_SBYTE_ARRAY out_arr;
        out_arr.NumOfBytes = sizeof(out_buf);
        out_arr.BytePtr = out_buf;

        pthread_mutex_lock(&g_j2534_lock);
        int32_t ret = g_j2534.PassThruIoctl(ctx->channel_id, J2534_FIVE_BAUD_INIT, &in_arr, &out_arr);
        pthread_mutex_unlock(&g_j2534_lock);

        log_timestamp();
        printf("PassThruIoctl(FIVE_BAUD_INIT) -> %d (num_keybytes=%lu)\n", ret, out_arr.NumOfBytes);

        if (ret == 0) {
            if (out_arr.NumOfBytes > 0) {
                log_hexdump("FIVE_BAUD_INIT-RX", out_arr.BytePtr, out_arr.NumOfBytes);
            }
            ipc_resp_five_baud_init_t resp;
            memset(&resp, 0, sizeof(resp));
            uint32_t copy_len = (uint32_t)out_arr.NumOfBytes;
            if (copy_len > sizeof(resp.keybytes)) {
                copy_len = sizeof(resp.keybytes);
            }
            resp.num_keybytes = copy_len;
            memcpy(resp.keybytes, out_arr.BytePtr, copy_len);

            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_OK, &resp, sizeof(resp));
        } else {
            uint32_t err = (ret == 9 /* J2534_ERR_TIMEOUT */) ?
                            IPC_STATUS_ERR_TIMEOUT : IPC_STATUS_ERR_J2534_FAILED;
            send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, err, NULL, 0);
        }
        break;
    }

    default:
        log_timestamp();
        printf("WARNING: Unknown command ID %u\n", hdr->command_id);
        send_ipc_reply(ctx, hdr->command_id, hdr->seq_id, IPC_STATUS_ERR_NOT_SUPPORTED, NULL, 0);
        break;
    }
}

/* Service a single client connection */
static void service_client(int client_fd)
{
    client_context_t ctx;
    memset(&ctx, 0, sizeof(ctx));
    ctx.client_fd = client_fd;
    pthread_mutex_init(&ctx.send_lock, NULL);

    log_timestamp();
    printf("Client connected on fd=%d\n", client_fd);

    uint8_t payload_buf[OPENSHIM_MAX_PAYLOAD];

    while (g_running) {
        ipc_header_t hdr;
        int r = recv_all(client_fd, &hdr, sizeof(hdr));
        if (r != 0) {
            log_timestamp();
            printf("Client disconnected or error reading header on fd=%d\n", client_fd);
            break;
        }

        if (hdr.magic != OPENSHIM_IPC_MAGIC || hdr.version != OPENSHIM_IPC_VERSION) {
            log_timestamp();
            printf("ERROR: Bad magic (0x%08X) or version (%u) from client on fd=%d\n",
                   hdr.magic, hdr.version, client_fd);
            break;
        }

        if (hdr.payload_len > sizeof(payload_buf)) {
            log_timestamp();
            printf("ERROR: Payload too large (%u bytes) on fd=%d\n", hdr.payload_len, client_fd);
            break;
        }

        if (hdr.payload_len > 0) {
            r = recv_all(client_fd, payload_buf, hdr.payload_len);
            if (r != 0) {
                log_timestamp();
                printf("Error reading payload on fd=%d\n", client_fd);
                break;
            }
        }

        handle_client_command(&ctx, &hdr, payload_buf);
    }

    stop_rx_thread(&ctx);
    pthread_mutex_lock(&g_j2534_lock);
    if (ctx.channel_connected) {
        g_j2534.PassThruDisconnect(ctx.channel_id);
    }
    if (ctx.device_open) {
        g_j2534.PassThruClose(ctx.device_id);
    }
    pthread_mutex_unlock(&g_j2534_lock);
    close(client_fd);
    pthread_mutex_destroy(&ctx.send_lock);

    log_timestamp();
    printf("Client session ended on fd=%d\n", client_fd);
}

int main(int argc, char *argv[])
{
    uint16_t port = OPENSHIM_DEFAULT_PORT;
    const char *custom_j2534 = "";

    for (int i = 1; i < argc; ++i) {
        if (strcmp(argv[i], "--port") == 0 && i + 1 < argc) {
            port = (uint16_t)atoi(argv[++i]);
        } else if (strcmp(argv[i], "--j2534") == 0 && i + 1 < argc) {
            custom_j2534 = argv[++i];
        } else if (strcmp(argv[i], "--help") == 0 || strcmp(argv[i], "-h") == 0) {
            printf("Usage: %s [--port <port>] [--j2534 <path_to_j2534.so>]\n", argv[0]);
            return 0;
        }
    }

    signal(SIGINT, sig_handler);
    signal(SIGTERM, sig_handler);
    signal(SIGPIPE, SIG_IGN);

    log_timestamp();
    printf("Starting OpenShim Native Linux Helper (port=%u)...\n", port);

    if (load_j2534_library(custom_j2534) != 0) {
        fprintf(stderr, "Fatal: Unable to initialize J2534 subsystem.\n");
        return 1;
    }

    int server_fd = socket(AF_INET, SOCK_STREAM, 0);
    if (server_fd < 0) {
        perror("socket");
        return 1;
    }

    int opt = 1;
    setsockopt(server_fd, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));

    struct sockaddr_in addr;
    memset(&addr, 0, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_port = htons(port);
    /* Strict localhost binding: 127.0.0.1 ONLY */
    inet_pton(AF_INET, OPENSHIM_DEFAULT_HOST, &addr.sin_addr);

    if (bind(server_fd, (struct sockaddr *)&addr, sizeof(addr)) < 0) {
        perror("bind 127.0.0.1");
        close(server_fd);
        return 1;
    }

    if (listen(server_fd, 5) < 0) {
        perror("listen");
        close(server_fd);
        return 1;
    }

    log_timestamp();
    printf("Listening strictly on %s:%u\n", OPENSHIM_DEFAULT_HOST, port);

    while (g_running) {
        struct sockaddr_in client_addr;
        socklen_t client_len = sizeof(client_addr);
        int client_fd = accept(server_fd, (struct sockaddr *)&client_addr, &client_len);
        if (client_fd < 0) {
            if (errno == EINTR) continue;
            perror("accept");
            break;
        }

        char client_ip[INET_ADDRSTRLEN];
        inet_ntop(AF_INET, &client_addr.sin_addr, client_ip, sizeof(client_ip));
        log_timestamp();
        printf("Accepted connection from %s:%u\n", client_ip, ntohs(client_addr.sin_port));

        service_client(client_fd);
    }

    close(server_fd);
    if (g_j2534.lib_handle) {
        dlclose(g_j2534.lib_handle);
    }

    log_timestamp();
    printf("Helper server shut down cleanly.\n");
    return 0;
}
