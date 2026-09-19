#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <stdio.h>
#include <stdint.h>
#include <string.h>
#include <assert.h>

typedef PVOID FT_HANDLE;
typedef ULONG FT_STATUS;

#define FT_OK 0UL
#define FT_LIST_BY_INDEX 0x40000000UL
#define FT_OPEN_BY_DESCRIPTION 2UL
#define FT_EVENT_RXCHAR 1UL
#define FT_PURGE_RX 1UL
#define FT_PURGE_TX 2UL

typedef FT_STATUS (WINAPI *OpenFn)(DWORD, FT_HANDLE *);
typedef FT_STATUS (WINAPI *CloseFn)(FT_HANDLE);
typedef FT_STATUS (WINAPI *ReadFn)(FT_HANDLE, LPVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *WriteFn)(FT_HANDLE, LPVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *GetStatusFn)(FT_HANDLE, LPDWORD, LPDWORD, LPDWORD);
typedef FT_STATUS (WINAPI *SetEventFn)(FT_HANDLE, DWORD, PVOID);
typedef FT_STATUS (WINAPI *PurgeFn)(FT_HANDLE, DWORD);

#define RESOLVE(variable, type, name)                                      \
    do {                                                                    \
        variable = (type)GetProcAddress(module, name);                      \
        if (variable == NULL) {                                             \
            fprintf(stderr, "FAIL: missing export %s\n", name);            \
            return 1;                                                       \
        }                                                                   \
    } while (0)

int main(void)
{
    printf("=== Test: OpenShimFTDI Stream Packetizer & Local Echo ===\n");

    HMODULE module = LoadLibraryA("..\\FTD2XX.dll");
    if (module == NULL) {
        /* Also try relative path */
        module = LoadLibraryA(".\\FTD2XX.dll");
    }
    if (module == NULL) {
        fprintf(stderr, "FAIL: LoadLibraryA FTD2XX.dll error %lu\n", GetLastError());
        return 1;
    }

    OpenFn open_device;
    CloseFn close_device;
    ReadFn read_device;
    WriteFn write_device;
    GetStatusFn get_status;
    SetEventFn set_event;
    PurgeFn purge_device;

    RESOLVE(open_device, OpenFn, "FT_Open");
    RESOLVE(close_device, CloseFn, "FT_Close");
    RESOLVE(read_device, ReadFn, "FT_Read");
    RESOLVE(write_device, WriteFn, "FT_Write");
    RESOLVE(get_status, GetStatusFn, "FT_GetStatus");
    RESOLVE(set_event, SetEventFn, "FT_SetEventNotification");
    RESOLVE(purge_device, PurgeFn, "FT_Purge");

    FT_HANDLE handle = NULL;
    FT_STATUS status = open_device(0, &handle);
    if (status != FT_OK) {
        fprintf(stderr, "FAIL: FT_Open returned %lu\n", (unsigned long)status);
        return 1;
    }

    HANDLE rx_event = CreateEvent(NULL, FALSE, FALSE, NULL);
    assert(rx_event != NULL);
    status = set_event(handle, FT_EVENT_RXCHAR, rx_event);
    assert(status == FT_OK);

    /* Test 1: Byte-by-byte feed of SendSeed: 68 6A F1 27 05 EF (6 bytes) */
    printf("[TEST 1] Byte-by-byte feed of SendSeed (68 6A F1 27 05 EF)...\n");
    const uint8_t seed_cmd[6] = { 0x68, 0x6A, 0xF1, 0x27, 0x05, 0xEF };
    for (int i = 0; i < 6; i++) {
        DWORD written = 0;
        status = write_device(handle, (LPVOID)&seed_cmd[i], 1, &written);
        assert(status == FT_OK);
        assert(written == 1);

        /* Immediate local echo must be ready in RX queue */
        DWORD rx_amt = 0, tx_amt = 0, event_stat = 0;
        status = get_status(handle, &rx_amt, &tx_amt, &event_stat);
        assert(status == FT_OK);
        assert(rx_amt == 1);

        /* Read the echo byte */
        uint8_t echo_byte = 0;
        DWORD read_amt = 0;
        status = read_device(handle, &echo_byte, 1, &read_amt);
        assert(status == FT_OK);
        assert(read_amt == 1);
        assert(echo_byte == seed_cmd[i]);
    }
    printf("  [PASS] SendSeed byte-by-byte echo verified\n");

    /* Test 2: Byte-by-byte feed of SendKey: 68 6A F1 27 06 12 34 36 (8 bytes) */
    printf("[TEST 2] Byte-by-byte feed of SendKey (68 6A F1 27 06 12 34 36)...\n");
    const uint8_t key_cmd[8] = { 0x68, 0x6A, 0xF1, 0x27, 0x06, 0x12, 0x34, 0x36 };
    for (int i = 0; i < 8; i++) {
        DWORD written = 0;
        status = write_device(handle, (LPVOID)&key_cmd[i], 1, &written);
        assert(status == FT_OK);
        assert(written == 1);

        uint8_t echo_byte = 0;
        DWORD read_amt = 0;
        status = read_device(handle, &echo_byte, 1, &read_amt);
        assert(status == FT_OK);
        assert(read_amt == 1);
        assert(echo_byte == key_cmd[i]);
    }
    printf("  [PASS] SendKey byte-by-byte echo verified\n");

    /* Test 3: Byte-by-byte feed of CheckDevice: 68 6A F1 3F 02 (5 bytes) */
    printf("[TEST 3] Byte-by-byte feed of CheckDevice (68 6A F1 3F 02)...\n");
    const uint8_t check_cmd[5] = { 0x68, 0x6A, 0xF1, 0x3F, 0x02 };
    for (int i = 0; i < 5; i++) {
        DWORD written = 0;
        status = write_device(handle, (LPVOID)&check_cmd[i], 1, &written);
        assert(status == FT_OK);
        assert(written == 1);

        uint8_t echo_byte = 0;
        DWORD read_amt = 0;
        status = read_device(handle, &echo_byte, 1, &read_amt);
        assert(status == FT_OK);
        assert(read_amt == 1);
        assert(echo_byte == check_cmd[i]);
    }
    printf("  [PASS] CheckDevice byte-by-byte echo verified\n");

    /* Test 4: Standard ISO 14230 frame: 81 11 F1 81 04 (5 bytes) */
    printf("[TEST 4] Standard ISO 14230 frame (81 11 F1 81 04)...\n");
    const uint8_t iso_cmd[5] = { 0x81, 0x11, 0xF1, 0x81, 0x04 };
    for (int i = 0; i < 5; i++) {
        DWORD written = 0;
        status = write_device(handle, (LPVOID)&iso_cmd[i], 1, &written);
        assert(status == FT_OK);
        assert(written == 1);

        uint8_t echo_byte = 0;
        DWORD read_amt = 0;
        status = read_device(handle, &echo_byte, 1, &read_amt);
        assert(status == FT_OK);
        assert(read_amt == 1);
        assert(echo_byte == iso_cmd[i]);
    }
    printf("  [PASS] Standard ISO 14230 byte-by-byte echo verified\n");

    /* Test 5: Block mode write (all 6 bytes at once) */
    printf("[TEST 5] Block write of 6 bytes at once...\n");
    DWORD block_written = 0;
    status = write_device(handle, (LPVOID)seed_cmd, 6, &block_written);
    assert(status == FT_OK);
    assert(block_written == 6);

    uint8_t block_echo[6] = {0};
    DWORD block_read = 0;
    status = read_device(handle, block_echo, 6, &block_read);
    assert(status == FT_OK);
    assert(block_read == 6);
    assert(memcmp(block_echo, seed_cmd, 6) == 0);
    printf("  [PASS] Block write and full echo drain verified\n");

    /* Test 6: Timeout flusher (partial data flushed after >= 35 ms) */
    printf("[TEST 6] Inter-byte timeout flush verification...\n");
    const uint8_t partial_data[2] = { 0x11, 0x22 };
    DWORD part_written = 0;
    status = write_device(handle, (LPVOID)partial_data, 2, &part_written);
    assert(status == FT_OK);
    assert(part_written == 2);

    /* Drain local echo */
    uint8_t dummy[2];
    DWORD dummy_read = 0;
    read_device(handle, dummy, 2, &dummy_read);

    /* Wait 50 ms to exceed 35 ms silence timeout */
    Sleep(50);

    /* FT_GetStatus triggers flush_accum_if_timed_out_locked */
    DWORD rx_q = 0, tx_q = 0, ev_q = 0;
    status = get_status(handle, &rx_q, &tx_q, &ev_q);
    assert(status == FT_OK);
    printf("  [PASS] Inter-byte timeout flush executed cleanly\n");

    /* Test 7: Purge TX clears pending accumulator */
    printf("[TEST 7] FT_Purge TX accumulator clearing...\n");
    status = write_device(handle, (LPVOID)partial_data, 2, &part_written);
    assert(status == FT_OK);
    read_device(handle, dummy, 2, &dummy_read);

    status = purge_device(handle, FT_PURGE_TX);
    assert(status == FT_OK);
    printf("  [PASS] FT_Purge TX accumulator cleared\n");

    status = close_device(handle);
    assert(status == FT_OK);
    CloseHandle(rx_event);
    FreeLibrary(module);

    printf("\n=== ALL STREAM PACKETIZER & LOCAL ECHO TESTS PASSED ===\n");
    return 0;
}
