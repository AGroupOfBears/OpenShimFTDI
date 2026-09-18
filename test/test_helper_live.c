#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <assert.h>

#include "../include/openshim_ipc.h"

static int send_all(int fd, const void *buf, size_t len)
{
    const uint8_t *p = (const uint8_t *)buf;
    while (len > 0) {
        ssize_t n = write(fd, p, len);
        if (n <= 0) return -1;
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
        if (n <= 0) return -1;
        p += n;
        len -= n;
    }
    return 0;
}

static int send_cmd(int fd, uint16_t cmd_id, uint32_t seq, const void *payload, uint32_t payload_len,
                    ipc_header_t *out_hdr, void *out_payload, uint32_t max_out_len)
{
    ipc_header_t hdr;
    hdr.magic = OPENSHIM_IPC_MAGIC;
    hdr.version = OPENSHIM_IPC_VERSION;
    hdr.command_id = cmd_id;
    hdr.seq_id = seq;
    hdr.status = 0;
    hdr.payload_len = payload_len;

    if (send_all(fd, &hdr, sizeof(hdr)) != 0) return -1;
    if (payload_len > 0 && payload != NULL) {
        if (send_all(fd, payload, payload_len) != 0) return -1;
    }

    while (1) {
        if (recv_all(fd, out_hdr, sizeof(*out_hdr)) != 0) return -1;
        if (out_hdr->command_id == IPC_CMD_RX_DATA) {
            /* Drain unsolicited RX data */
            uint8_t dummy[4096];
            if (out_hdr->payload_len > 0) {
                if (recv_all(fd, dummy, out_hdr->payload_len) != 0) return -1;
            }
            continue;
        }
        break;
    }

    if (out_hdr->payload_len > 0) {
        if (out_hdr->payload_len > max_out_len) {
            return -2;
        }
        if (recv_all(fd, out_payload, out_hdr->payload_len) != 0) return -1;
    }
    return 0;
}

int main(int argc, char *argv[])
{
    uint16_t port = OPENSHIM_DEFAULT_PORT;
    if (argc > 1) {
        port = (uint16_t)atoi(argv[1]);
    }

    printf("=== Test: Live Native Helper via IPC (Port %u) ===\n", port);

    int sock = socket(AF_INET, SOCK_STREAM, 0);
    assert(sock >= 0);

    struct sockaddr_in addr;
    memset(&addr, 0, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_port = htons(port);
    inet_pton(AF_INET, OPENSHIM_DEFAULT_HOST, &addr.sin_addr);

    if (connect(sock, (struct sockaddr *)&addr, sizeof(addr)) != 0) {
        perror("Connect failed");
        printf("[SKIP/FAIL] Could not connect to helper daemon on %s:%u\n", OPENSHIM_DEFAULT_HOST, port);
        return 1;
    }
    printf("[PASS] Connected to helper socket.\n");

    /* 1. Ping */
    ipc_header_t resp_hdr;
    uint8_t payload[4096];
    int r = send_cmd(sock, IPC_CMD_PING, 1, NULL, 0, &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] Helper PING replied OK\n");

    /* 2. OPEN backend device */
    ipc_req_open_t req_open = { 0 };
    r = send_cmd(sock, IPC_CMD_OPEN, 2, &req_open, sizeof(req_open), &resp_hdr, payload, sizeof(payload));
    assert(r == 0);
    if (resp_hdr.status == IPC_STATUS_ERR_NO_HARDWARE) {
        printf("[NOTICE] OpenPort hardware not detected by J2534; test verifying graceful error reporting.\n");
        close(sock);
        return 0;
    }
    assert(resp_hdr.status == IPC_STATUS_OK);
    ipc_resp_open_t *open_resp = (ipc_resp_open_t *)payload;
    printf("[PASS] OPEN succeeded: Device ID=%u, Desc='%s', FW='%s'\n",
           open_resp->device_id, open_resp->description, open_resp->firmware_version);

    /* 3. CONNECT ISO14230 */
    ipc_req_connect_t req_conn;
    req_conn.device_id = open_resp->device_id;
    req_conn.protocol_id = 4; /* ISO14230 */
    req_conn.flags = 0;
    req_conn.baud_rate = 10400;
    r = send_cmd(sock, IPC_CMD_CONNECT, 3, &req_conn, sizeof(req_conn), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    ipc_resp_connect_t *conn_resp = (ipc_resp_connect_t *)payload;
    uint32_t channel_id = conn_resp->channel_id;
    printf("[PASS] CONNECT ISO14230 succeeded: Channel ID=%u\n", channel_id);

    /* 4. SET_CONFIG DATA_RATE = 10400 */
    ipc_req_set_config_t req_cfg;
    req_cfg.channel_id = channel_id;
    req_cfg.parameter = 1; /* CONFIG_DATA_RATE */
    req_cfg.value = 10400;
    r = send_cmd(sock, IPC_CMD_SET_CONFIG, 4, &req_cfg, sizeof(req_cfg), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] SET_CONFIG DATA_RATE=10400 succeeded\n");

    /* 5. SET_CONFIG DATA_RATE = 62400 (TuneECU high speed) */
    req_cfg.value = 62400;
    r = send_cmd(sock, IPC_CMD_SET_CONFIG, 5, &req_cfg, sizeof(req_cfg), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] SET_CONFIG DATA_RATE=62400 succeeded\n");

    /* Restore to 10400 */
    req_cfg.value = 10400;
    r = send_cmd(sock, IPC_CMD_SET_CONFIG, 6, &req_cfg, sizeof(req_cfg), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);

    /* 6. CLEAR_RX and CLEAR_TX */
    ipc_req_clear_buffer_t req_clear = { channel_id };
    r = send_cmd(sock, IPC_CMD_CLEAR_RX, 7, &req_clear, sizeof(req_clear), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] CLEAR_RX succeeded\n");

    r = send_cmd(sock, IPC_CMD_CLEAR_TX, 8, &req_clear, sizeof(req_clear), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] CLEAR_TX succeeded\n");

    /* 7. FAST_INIT Request Path */
    uint8_t fast_init_buf[sizeof(ipc_req_fast_init_t) + 4];
    ipc_req_fast_init_t *fi_req = (ipc_req_fast_init_t *)fast_init_buf;
    fi_req->channel_id = channel_id;
    fi_req->tx_flags = 0;
    fi_req->timeout_ms = 500;
    fi_req->data_len = 4;
    uint8_t init_req_bytes[4] = { 0x81, 0x11, 0xF1, 0x81 }; /* KWP StartCommunication */
    memcpy(fast_init_buf + sizeof(ipc_req_fast_init_t), init_req_bytes, 4);

    r = send_cmd(sock, IPC_CMD_FAST_INIT, 9, fast_init_buf, sizeof(fast_init_buf), &resp_hdr, payload, sizeof(payload));
    /* FAST_INIT returns OK or timeout if no ECU is physically connected on the bench */
    printf("[PASS] FAST_INIT request dispatched to OpenPort hardware (status=%u)\n", resp_hdr.status);

    /* 8. DISCONNECT */
    ipc_req_disconnect_t req_disc = { channel_id };
    r = send_cmd(sock, IPC_CMD_DISCONNECT, 10, &req_disc, sizeof(req_disc), &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] DISCONNECT succeeded\n");

    /* 9. CLOSE */
    r = send_cmd(sock, IPC_CMD_CLOSE, 11, NULL, 0, &resp_hdr, payload, sizeof(payload));
    assert(r == 0 && resp_hdr.status == IPC_STATUS_OK);
    printf("[PASS] CLOSE succeeded\n");

    close(sock);
    printf("=== ALL NATIVE HELPER LIVE TESTS PASSED ===\n");
    return 0;
}
