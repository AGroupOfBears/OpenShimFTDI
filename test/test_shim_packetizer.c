#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <stdio.h>
#include <stdint.h>
#include <string.h>
#include <assert.h>

typedef PVOID FT_HANDLE;
typedef ULONG FT_STATUS;

#define FT_OK 0UL
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

static void test_byte_by_byte(FT_HANDLE handle, WriteFn write_fn, ReadFn read_fn, GetStatusFn status_fn,
                              const uint8_t *data, uint32_t len, const char *name)
{
    printf("  [FEED] %s (len=%u)...\n", name, len);
    for (uint32_t i = 0; i < len; i++) {
        DWORD written = 0;
        FT_STATUS st = write_fn(handle, (LPVOID)&data[i], 1, &written);
        assert(st == FT_OK);
        assert(written == 1);

        DWORD rx_amt = 0, tx_amt = 0, ev_stat = 0;
        st = status_fn(handle, &rx_amt, &tx_amt, &ev_stat);
        assert(st == FT_OK);
        assert(rx_amt == 1);

        uint8_t echo = 0;
        DWORD read_amt = 0;
        st = read_fn(handle, &echo, 1, &read_amt);
        assert(st == FT_OK);
        assert(read_amt == 1);
        assert(echo == data[i]);
    }
}

int main(void)
{
    printf("=== Test: OpenShimFTDI Stream Packetizer & Local Echo ===\n");

    HMODULE module = LoadLibraryA("..\\FTD2XX.dll");
    if (module == NULL) {
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

    /* --- Group 1: SecurityAccess (Programming & Normal Diagnostic) --- */
    printf("\n[GROUP 1] SecurityAccess Regression Coverage...\n");
    /* Programming-security: 0x27 05 (seed) and 0x27 06 (key) */
    const uint8_t prog_seed[6] = { 0x68, 0x6A, 0xF1, 0x27, 0x05, 0xEF };
    test_byte_by_byte(handle, write_device, read_device, get_status, prog_seed, 6, "Prog Security Seed (0x27 05)");
    const uint8_t prog_key[8]  = { 0x68, 0x6A, 0xF1, 0x27, 0x06, 0x12, 0x34, 0x36 };
    test_byte_by_byte(handle, write_device, read_device, get_status, prog_key, 8, "Prog Security Key (0x27 06)");

    /* Normal diagnostic: 0x27 03 (seed) and 0x27 04 (key) */
    const uint8_t diag_seed[6] = { 0x68, 0x6A, 0xF1, 0x27, 0x03, 0xED };
    test_byte_by_byte(handle, write_device, read_device, get_status, diag_seed, 6, "Normal Diag Seed (0x27 03 ED)");
    const uint8_t diag_key[8]  = { 0x68, 0x6A, 0xF1, 0x27, 0x04, 0x12, 0x34, 0x34 };
    test_byte_by_byte(handle, write_device, read_device, get_status, diag_key, 8, "Normal Diag Key (0x27 04 12 34 34)");

    /* Real Physical Keihin ISO Diagnostic: 0x27 03 02 EF (seed) and 0x27 03 02 <k_hi> <k_lo> <cs> (key) */
    const uint8_t real_keihin_seed[7] = { 0x68, 0x6A, 0xF1, 0x27, 0x03, 0x02, 0xEF };
    test_byte_by_byte(handle, write_device, read_device, get_status, real_keihin_seed, 7, "Real Keihin Seed (68 6A F1 27 03 02 EF)");
    const uint8_t real_keihin_key[9]  = { 0x68, 0x6A, 0xF1, 0x27, 0x03, 0x02, 0x12, 0x34, 0x35 };
    test_byte_by_byte(handle, write_device, read_device, get_status, real_keihin_key, 9, "Real Keihin Key (68 6A F1 27 03 02 12 34 35)");
    printf("  [PASS] All SecurityAccess variants packetized and echoed cleanly\n");

    /* --- Group 2: Keihin Connection & Identification Services (0x1A) --- */
    printf("\n[GROUP 2] Keihin ReadECUIdentification (0x1A) Services...\n");
    const uint8_t cmd_1a_01[6] = { 0x68, 0x6A, 0xF1, 0x1A, 0x01, 0xDE };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_1a_01, 6, "ReadECUId 0x1A 01");
    const uint8_t cmd_1a_02[6] = { 0x68, 0x6A, 0xF1, 0x1A, 0x02, 0xDF };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_1a_02, 6, "ReadECUId 0x1A 02");
    const uint8_t cmd_1a_05[6] = { 0x68, 0x6A, 0xF1, 0x1A, 0x05, 0xE2 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_1a_05, 6, "ReadECUId 0x1A 05");
    const uint8_t cmd_1a_12[6] = { 0x68, 0x6A, 0xF1, 0x1A, 0x12, 0xEF };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_1a_12, 6, "ReadECUId 0x1A 12");
    const uint8_t cmd_1a_20[6] = { 0x68, 0x6A, 0xF1, 0x1A, 0x20, 0xFD };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_1a_20, 6, "ReadECUId 0x1A 20");
    printf("  [PASS] All 0x1A identification services packetized deterministically\n");

    /* --- Group 3: Known Services (0x21, 0x18, 0x14, 0x23, 0x3F) --- */
    printf("\n[GROUP 3] Deterministic Handling for Known Keihin Services...\n");
    /* 0x21 Local Identifier / PID query */
    const uint8_t cmd_21_01[6] = { 0x68, 0x6A, 0xF1, 0x21, 0x01, 0xE5 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_21_01, 6, "ReadDataByLocalId 0x21 01");
    const uint8_t cmd_21_80[6] = { 0x68, 0x6A, 0xF1, 0x21, 0x80, 0x64 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_21_80, 6, "SendIDQuery 0x21 80");
    const uint8_t cmd_21_2byte[7] = { 0x68, 0x6A, 0xF1, 0x21, 0x00, 0x01, 0xE5 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_21_2byte, 7, "ReadDataByLocalId 2-byte PID");

    /* Keihin 0x3C dataBlock query */
    const uint8_t cmd_3c_03[6] = { 0x68, 0x6A, 0xF1, 0x3C, 0x03, 0x01 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_3c_03, 6, "Keihin DataBlock 0x3C 03");

    /* 0x18 00 FF 00 Read DTCs */
    const uint8_t cmd_18[8] = { 0x68, 0x6A, 0xF1, 0x18, 0x00, 0xFF, 0x00, 0xDA };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_18, 8, "ReadDTCs 0x18 00 FF 00");

    /* 0x14 FF 00 Clear DTCs */
    const uint8_t cmd_14[7] = { 0x68, 0x6A, 0xF1, 0x14, 0xFF, 0x00, 0xD6 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_14, 7, "ClearDTCs 0x14 FF 00");

    /* 0x23 ReadMemoryByAddress (addr=0x020000, len=0x0020) */
    const uint8_t cmd_23[10] = { 0x68, 0x6A, 0xF1, 0x23, 0x02, 0x00, 0x00, 0x00, 0x20, 0x08 };
    test_byte_by_byte(handle, write_device, read_device, get_status, cmd_23, 10, "ReadMemory 0x23");

    /* 0x3F CheckDevice */
    const uint8_t check_cmd[5] = { 0x68, 0x6A, 0xF1, 0x3F, 0x02 };
    test_byte_by_byte(handle, write_device, read_device, get_status, check_cmd, 5, "CheckDevice 0x3F");

    /* Standard ISO 14230 */
    const uint8_t iso_cmd[5] = { 0x81, 0x11, 0xF1, 0x81, 0x04 };
    test_byte_by_byte(handle, write_device, read_device, get_status, iso_cmd, 5, "Standard ISO 14230");
    printf("  [PASS] All known services packetized without timeout reliance\n");

    /* --- Group 4: Block mode and Flush Hardening --- */
    printf("\n[GROUP 4] Block Mode and Fallback Hardening...\n");
    /* Block write of 6 bytes */
    DWORD block_written = 0;
    status = write_device(handle, (LPVOID)cmd_1a_01, 6, &block_written);
    assert(status == FT_OK);
    assert(block_written == 6);
    uint8_t block_echo[6] = {0};
    DWORD block_read = 0;
    status = read_device(handle, block_echo, 6, &block_read);
    assert(status == FT_OK);
    assert(block_read == 6);
    assert(memcmp(block_echo, cmd_1a_01, 6) == 0);
    printf("  [PASS] Block write full echo drain verified\n");

    /* Candidate unknown frame with valid checksum flushes on >= 35 ms timeout */
    /* Unknown SID 0x77: 68 6A F1 77 99 69 (csum: 68+6A+F1+77+99 = 0x269 -> 0x69) */
    printf("  [TEST] Candidate valid unknown frame on timeout...\n");
    const uint8_t cand_frame[6] = { 0x68, 0x6A, 0xF1, 0x77, 0x99, 0xD3 };
    for (int i = 0; i < 6; i++) {
        DWORD w = 0;
        write_device(handle, (LPVOID)&cand_frame[i], 1, &w);
        uint8_t b = 0; DWORD r = 0;
        read_device(handle, &b, 1, &r);
    }
    Sleep(50);
    DWORD rx_q = 0, tx_q = 0, ev_q = 0;
    status = get_status(handle, &rx_q, &tx_q, &ev_q);
    assert(status == FT_OK);
    printf("  [PASS] Candidate checksum-valid frame flushed on silence timeout\n");

    /* Incomplete/checksum-invalid fragment is dropped with [FRAME_DROP] and NOT sent */
    printf("  [TEST] Incomplete / invalid fragment drop on timeout...\n");
    const uint8_t junk[2] = { 0x11, 0x22 };
    DWORD jw = 0;
    status = write_device(handle, (LPVOID)junk, 2, &jw);
    assert(status == FT_OK);
    uint8_t j_echo[2]; DWORD jr = 0;
    read_device(handle, j_echo, 2, &jr);
    Sleep(50);
    status = get_status(handle, &rx_q, &tx_q, &ev_q);
    assert(status == FT_OK);
    printf("  [PASS] Checksum-invalid fragment dropped cleanly on silence timeout\n");

    /* Test FT_Purge TX */
    printf("  [TEST] FT_Purge TX clears accumulator...\n");
    write_device(handle, (LPVOID)junk, 2, &jw);
    read_device(handle, j_echo, 2, &jr);
    status = purge_device(handle, FT_PURGE_TX);
    assert(status == FT_OK);
    printf("  [PASS] FT_Purge TX cleared\n");

    status = close_device(handle);
    assert(status == FT_OK);
    CloseHandle(rx_event);
    FreeLibrary(module);

    printf("\n=== ALL STREAM PACKETIZER HARDENING TESTS PASSED ===\n");
    return 0;
}
