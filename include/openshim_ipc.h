#ifndef OPENSHIM_IPC_H
#define OPENSHIM_IPC_H

#include <stdint.h>

#define OPENSHIM_IPC_MAGIC        0x4F505348U /* "OPSH" */
#define OPENSHIM_IPC_VERSION      1U
#define OPENSHIM_DEFAULT_PORT     19234U
#define OPENSHIM_DEFAULT_HOST     "127.0.0.1"

#define OPENSHIM_MAX_PAYLOAD      4096U

/* Command IDs */
enum OpenShimIpcCommand {
    IPC_CMD_PING            = 1,
    IPC_CMD_OPEN            = 2,
    IPC_CMD_CLOSE           = 3,
    IPC_CMD_CONNECT         = 4,
    IPC_CMD_DISCONNECT      = 5,
    IPC_CMD_READ            = 6,
    IPC_CMD_WRITE           = 7,
    IPC_CMD_SET_CONFIG      = 8,
    IPC_CMD_CLEAR_RX        = 9,
    IPC_CMD_CLEAR_TX        = 10,
    IPC_CMD_FAST_INIT       = 11,
    IPC_CMD_START_FILTER    = 12,
    IPC_CMD_RX_DATA         = 13,  /* Unsolicited push of received/loopback bytes */
    IPC_CMD_FIVE_BAUD_INIT  = 14
};

/* Status codes */
enum OpenShimIpcStatus {
    IPC_STATUS_OK               = 0,
    IPC_STATUS_ERR_NOT_CONNECTED = 1,
    IPC_STATUS_ERR_BUSY         = 2,
    IPC_STATUS_ERR_INVALID_PARAM= 3,
    IPC_STATUS_ERR_TIMEOUT      = 4,
    IPC_STATUS_ERR_NOT_SUPPORTED= 5,
    IPC_STATUS_ERR_J2534_FAILED = 6,
    IPC_STATUS_ERR_NO_HARDWARE  = 7,
    IPC_STATUS_ERR_GENERAL      = 8
};

#pragma pack(push, 1)

typedef struct {
    uint32_t magic;         /* OPENSHIM_IPC_MAGIC */
    uint16_t version;       /* OPENSHIM_IPC_VERSION */
    uint16_t command_id;    /* enum OpenShimIpcCommand */
    uint32_t seq_id;        /* Sequence ID / correlation token */
    uint32_t status;        /* enum OpenShimIpcStatus */
    uint32_t payload_len;   /* Length of payload following header */
} ipc_header_t;

/* Payloads */

/* IPC_CMD_OPEN payload: empty or device index */
typedef struct {
    uint32_t device_index;
} ipc_req_open_t;

typedef struct {
    uint32_t device_id;
    char description[64];
    char firmware_version[32];
} ipc_resp_open_t;

/* IPC_CMD_CONNECT payload */
typedef struct {
    uint32_t device_id;
    uint32_t protocol_id;
    uint32_t flags;
    uint32_t baud_rate;
} ipc_req_connect_t;

typedef struct {
    uint32_t channel_id;
} ipc_resp_connect_t;

/* IPC_CMD_DISCONNECT payload */
typedef struct {
    uint32_t channel_id;
} ipc_req_disconnect_t;

/* IPC_CMD_SET_CONFIG payload */
typedef struct {
    uint32_t channel_id;
    uint32_t parameter;
    uint32_t value;
} ipc_req_set_config_t;

/* IPC_CMD_CLEAR_RX and IPC_CMD_CLEAR_TX payload */
typedef struct {
    uint32_t channel_id;
} ipc_req_clear_buffer_t;

/* IPC_CMD_WRITE payload header followed by data bytes */
typedef struct {
    uint32_t channel_id;
    uint32_t tx_flags;
    uint32_t timeout_ms;
    uint32_t data_len;
    /* uint8_t data[data_len]; */
} ipc_req_write_t;

typedef struct {
    uint32_t bytes_written;
} ipc_resp_write_t;

/* IPC_CMD_READ payload */
typedef struct {
    uint32_t channel_id;
    uint32_t max_msgs;
    uint32_t timeout_ms;
} ipc_req_read_t;

typedef struct {
    uint32_t num_msgs;
    uint32_t total_bytes;
    /* uint8_t data[total_bytes]; */
} ipc_resp_read_t;

/* IPC_CMD_START_FILTER payload */
typedef struct {
    uint32_t channel_id;
    uint32_t filter_type;
    uint32_t tx_flags;
    uint32_t mask_len;
    uint32_t pattern_len;
    /* mask bytes (mask_len) followed by pattern bytes (pattern_len) */
} ipc_req_start_filter_t;

typedef struct {
    uint32_t filter_id;
} ipc_resp_start_filter_t;

/* IPC_CMD_FAST_INIT payload */
typedef struct {
    uint32_t channel_id;
    uint32_t tx_flags;
    uint32_t timeout_ms;
    uint32_t data_len;
    /* uint8_t tx_data[data_len]; */
} ipc_req_fast_init_t;

typedef struct {
    uint32_t rx_data_len;
    /* uint8_t rx_data[rx_data_len]; */
} ipc_resp_fast_init_t;

/* IPC_CMD_FIVE_BAUD_INIT payload */
typedef struct {
    uint32_t channel_id;
    uint8_t  target_address;  /* 0x33 or 0xD5 */
    uint8_t  pad[3];
} ipc_five_baud_req_t;
typedef ipc_five_baud_req_t ipc_req_five_baud_init_t;

typedef struct {
    uint32_t num_keybytes;
    uint8_t  keybytes[16];
} ipc_five_baud_resp_t;
typedef ipc_five_baud_resp_t ipc_resp_five_baud_init_t;

/* IPC_CMD_RX_DATA: Asynchronous push of received bytes (RX or loopback) */
typedef struct {
    uint32_t channel_id;
    uint32_t rx_status;     /* 0 = normal RX, 1 = loopback (TX_MSG_TYPE) */
    uint32_t timestamp;
    uint32_t data_len;
    /* uint8_t data[data_len]; */
} ipc_push_rx_data_t;

#pragma pack(pop)

#endif /* OPENSHIM_IPC_H */
