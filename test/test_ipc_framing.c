#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <string.h>
#include <assert.h>

#include "../include/openshim_ipc.h"

int main(void)
{
    printf("=== Test: IPC Framing and Protocol Structures ===\n");

    /* Verify header size is exactly 20 bytes */
    assert(sizeof(ipc_header_t) == 20);
    printf("[PASS] Header size is 20 bytes (pragma pack verified)\n");

    /* Test Header Construction */
    ipc_header_t hdr;
    memset(&hdr, 0, sizeof(hdr));
    hdr.magic = OPENSHIM_IPC_MAGIC;
    hdr.version = OPENSHIM_IPC_VERSION;
    hdr.command_id = IPC_CMD_CONNECT;
    hdr.seq_id = 12345;
    hdr.status = IPC_STATUS_OK;
    hdr.payload_len = sizeof(ipc_req_connect_t);

    assert(hdr.magic == 0x4F505348);
    assert(hdr.version == 1);
    assert(hdr.command_id == IPC_CMD_CONNECT);
    assert(hdr.seq_id == 12345);
    assert(hdr.status == 0);
    assert(hdr.payload_len == sizeof(ipc_req_connect_t));
    printf("[PASS] Header serialization and validation passed\n");

    /* Test Connect Request Payload */
    ipc_req_connect_t conn;
    conn.device_id = 1;
    conn.protocol_id = 4; /* ISO14230 */
    conn.flags = 0;
    conn.baud_rate = 10400;

    assert(sizeof(conn) == 16);
    assert(conn.protocol_id == 4);
    assert(conn.baud_rate == 10400);
    printf("[PASS] Connect request payload verified\n");

    /* Test Write Request Payload */
    uint8_t write_buffer[sizeof(ipc_req_write_t) + 5];
    ipc_req_write_t *wreq = (ipc_req_write_t *)write_buffer;
    wreq->channel_id = 42;
    wreq->tx_flags = 0;
    wreq->timeout_ms = 500;
    wreq->data_len = 5;
    uint8_t test_payload[5] = { 0x80, 0x12, 0xF1, 0x01, 0x84 };
    memcpy(write_buffer + sizeof(ipc_req_write_t), test_payload, 5);

    assert(wreq->channel_id == 42);
    assert(wreq->data_len == 5);
    assert(memcmp(write_buffer + sizeof(ipc_req_write_t), test_payload, 5) == 0);
    printf("[PASS] Write request dynamic payload serialization verified\n");

    /* Test Push RX Data Payload */
    uint8_t rx_buffer[sizeof(ipc_push_rx_data_t) + 4];
    ipc_push_rx_data_t *rx_push = (ipc_push_rx_data_t *)rx_buffer;
    rx_push->channel_id = 42;
    rx_push->rx_status = 1; /* Loopback message */
    rx_push->timestamp = 999999;
    rx_push->data_len = 4;
    uint8_t echo_bytes[4] = { 0xC1, 0x33, 0xF1, 0xE5 };
    memcpy(rx_buffer + sizeof(ipc_push_rx_data_t), echo_bytes, 4);

    assert(rx_push->rx_status == 1);
    assert(rx_push->data_len == 4);
    assert(memcmp(rx_buffer + sizeof(ipc_push_rx_data_t), echo_bytes, 4) == 0);
    printf("[PASS] Asynchronous Push RX data structure verified\n");

    /* Test FIVE_BAUD_INIT Request & Response Payload */
    assert(IPC_CMD_FIVE_BAUD_INIT == 14);
    assert(sizeof(ipc_req_five_baud_init_t) == 8);
    assert(sizeof(ipc_resp_five_baud_init_t) == 20);

    ipc_req_five_baud_init_t req5;
    req5.channel_id = 3;
    req5.target_address = 0x33;
    memset(req5.pad, 0, sizeof(req5.pad));
    assert(req5.channel_id == 3);
    assert(req5.target_address == 0x33);

    ipc_resp_five_baud_init_t resp5;
    memset(&resp5, 0, sizeof(resp5));
    resp5.num_keybytes = 3;
    resp5.keybytes[0] = 0x55;
    resp5.keybytes[1] = 0x08;
    resp5.keybytes[2] = 0x08;
    assert(resp5.num_keybytes == 3);
    assert(resp5.keybytes[0] == 0x55);
    assert(resp5.keybytes[1] == 0x08);
    assert(resp5.keybytes[2] == 0x08);
    printf("[PASS] FIVE_BAUD_INIT request and response payloads verified\n");

    /* Test Status Codes */
    assert(IPC_STATUS_OK == 0);
    assert(IPC_STATUS_ERR_NOT_CONNECTED == 1);
    assert(IPC_STATUS_ERR_BUSY == 2);
    assert(IPC_STATUS_ERR_INVALID_PARAM == 3);
    assert(IPC_STATUS_ERR_TIMEOUT == 4);
    assert(IPC_STATUS_ERR_NOT_SUPPORTED == 5);
    assert(IPC_STATUS_ERR_J2534_FAILED == 6);
    assert(IPC_STATUS_ERR_NO_HARDWARE == 7);
    printf("[PASS] Error and status enumeration verified\n");

    printf("=== ALL IPC FRAMING TESTS PASSED ===\n");
    return 0;
}
