#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <stdio.h>
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
typedef FT_STATUS (WINAPI *SimpleFn)(FT_HANDLE);

#define RESOLVE(variable, type, name)                                      \
    do {                                                                    \
        variable = (type)GetProcAddress(module, name);                      \
        if (variable == NULL) {                                             \
            fprintf(stderr, "FAIL: missing export %s\n", name);            \
            return 1;                                                       \
        }                                                                   \
    } while (0)

static void send_tuneecu_break_train(SimpleFn set_break_on, SimpleFn set_break_off, FT_HANDLE handle, int address)
{
    int c = address * 4 + 1025;
    for (int j = 0; j < 11; j++) {
        BYTE b2 = (BYTE)(c & 1);
        c >>= 1;
        if (b2 == 0) {
            set_break_on(handle);
        } else {
            set_break_off(handle);
        }
    }
}

int main(void)
{
    printf("=== Running OpenShimFTDI 5-Baud Break Decode & Handshake Virtualization Tests ===\n");

    HMODULE module = LoadLibraryA("FTD2XX.dll");
    if (module == NULL) {
        fprintf(stderr, "FAIL: LoadLibraryA: error %lu\n", (unsigned long)GetLastError());
        return 1;
    }

    OpenFn open_device;
    CloseFn close_device;
    ReadFn read_device;
    WriteFn write_device;
    GetStatusFn get_status;
    SetEventFn set_event;
    PurgeFn purge;
    SimpleFn set_break_on;
    SimpleFn set_break_off;

    RESOLVE(open_device, OpenFn, "FT_Open");
    RESOLVE(close_device, CloseFn, "FT_Close");
    RESOLVE(read_device, ReadFn, "FT_Read");
    RESOLVE(write_device, WriteFn, "FT_Write");
    RESOLVE(get_status, GetStatusFn, "FT_GetStatus");
    RESOLVE(set_event, SetEventFn, "FT_SetEventNotification");
    RESOLVE(purge, PurgeFn, "FT_Purge");
    RESOLVE(set_break_on, SimpleFn, "FT_SetBreakOn");
    RESOLVE(set_break_off, SimpleFn, "FT_SetBreakOff");

    FT_HANDLE handle = NULL;
    FT_STATUS st = open_device(0, &handle);
    if (st != FT_OK || handle == NULL) {
        fprintf(stderr, "FAIL: FT_Open failed: %lu\n", (unsigned long)st);
        return 1;
    }

    HANDLE rx_event = CreateEventA(NULL, FALSE, FALSE, NULL);
    assert(rx_event != NULL);
    st = set_event(handle, FT_EVENT_RXCHAR, rx_event);
    assert(st == FT_OK);

    DWORD rx = 0, tx = 0, ev = 0, read_bytes = 0, written = 0;
    BYTE buf[16];

    /* =========================================================================
     * TEST 1: Mock 0x33 5-Baud Handshake
     * ========================================================================= */
    printf("\n[TEST 1] Testing 5-baud pattern decode for address 0x33 (Keihin)...\n");
    send_tuneecu_break_train(set_break_on, set_break_off, handle, 0x33);

    /* Event should have fired */
    DWORD wait_res = WaitForSingleObject(rx_event, 500);
    assert(wait_res == WAIT_OBJECT_0);

    /* Check RX queue length */
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK);
    assert(rx == 3);

    /* TuneECU calls post-break purge - must PRESERVE the 3 bytes */
    st = purge(handle, FT_PURGE_RX | FT_PURGE_TX);
    assert(st == FT_OK);
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK);
    assert(rx == 3);

    /* Read the 3 key bytes */
    memset(buf, 0, sizeof(buf));
    st = read_device(handle, buf, 3, &read_bytes);
    assert(st == FT_OK);
    assert(read_bytes == 3);
    assert(buf[0] == 0x55);
    assert(buf[1] == 0x08);
    assert(buf[2] == 0x08);
    printf("  Read keybytes: 0x%02X 0x%02X 0x%02X\n", buf[0], buf[1], buf[2]);

    /* TuneECU computes Init = KB2 ^ 0xFF = 0x08 ^ 0xFF = 0xF7 and writes it */
    BYTE init_byte = (BYTE)(0x08 ^ 0xFF);
    st = write_device(handle, &init_byte, 1, &written);
    assert(st == FT_OK);
    assert(written == 1);

    /* Virtualization must have pushed 2 bytes: local echo (0xF7) and ACK (~0x33 = 0xCC) */
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK);
    assert(rx == 2);

    /* TuneECU reads 1-byte echo */
    BYTE echo_byte = 0;
    st = read_device(handle, &echo_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && echo_byte == 0xF7);

    /* TuneECU reads 1-byte ack */
    BYTE ack_byte = 0;
    st = read_device(handle, &ack_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && ack_byte == 0xCC);

    printf("[PASS] Mock 0x33 handshake passed (received keybytes [0x55,0x08,0x08], echo 0xF7, ack 0xCC)\n");

    /* =========================================================================
     * TEST 2: Mock 0xD5 5-Baud Handshake
     * ========================================================================= */
    printf("\n[TEST 2] Testing 5-baud pattern decode for address 0xD5 (Sagem)...\n");
    send_tuneecu_break_train(set_break_on, set_break_off, handle, 0xD5);

    wait_res = WaitForSingleObject(rx_event, 500);
    assert(wait_res == WAIT_OBJECT_0);

    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 3);

    st = purge(handle, FT_PURGE_RX | FT_PURGE_TX);
    assert(st == FT_OK);
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 3);

    memset(buf, 0, sizeof(buf));
    st = read_device(handle, buf, 3, &read_bytes);
    assert(st == FT_OK && read_bytes == 3);
    assert(buf[0] == 0x55 && buf[1] == 0xD9 && buf[2] == 0x8F);
    printf("  Read keybytes: 0x%02X 0x%02X 0x%02X\n", buf[0], buf[1], buf[2]);

    /* TuneECU computes Init = KB2 ^ 0xFF = 0x8F ^ 0xFF = 0x70 */
    init_byte = (BYTE)(0x8F ^ 0xFF);
    st = write_device(handle, &init_byte, 1, &written);
    assert(st == FT_OK && written == 1);

    /* Virtualization must have pushed echo (0x70) and ACK (~0xD5 = 0x2A) */
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 2);

    st = read_device(handle, &echo_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && echo_byte == 0x70);

    st = read_device(handle, &ack_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && ack_byte == 0x2A);

    printf("[PASS] Mock 0xD5 handshake passed (received keybytes [0x55,0xD9,0x8F], echo 0x70, ack 0x2A)\n");

    /* =========================================================================
     * TEST 3: Wrong ~KB2 byte is NOT suppressed and resets handshake state
     * ========================================================================= */
    printf("\n[TEST 3] Testing non-matching write during awaiting_init state...\n");
    send_tuneecu_break_train(set_break_on, set_break_off, handle, 0x33);
    st = read_device(handle, buf, 3, &read_bytes);
    assert(st == FT_OK && read_bytes == 3);

    /* Handshake expects 0xF7. Write a totally wrong byte 0xAA */
    BYTE wrong_byte = 0xAA;
    st = write_device(handle, &wrong_byte, 1, &written);
    assert(st == FT_OK && written == 1);

    /* In loopback mode, 0xAA is treated as normal write -> echoed once, NO ACK injected! */
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 1);

    st = read_device(handle, &echo_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && echo_byte == 0xAA);

    /* Verify state was reset to IDLE: now writing 0xF7 will NOT produce ACK */
    st = write_device(handle, &init_byte, 1, &written);
    assert(st == FT_OK && written == 1);
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 1); /* Only echo, no ACK */
    st = read_device(handle, &echo_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && echo_byte == init_byte);

    printf("[PASS] Non-matching write was not suppressed and correctly reset handshake state\n");

    /* =========================================================================
     * TEST 4: Stale state timeout (>5000 ms) reset
     * ========================================================================= */
    printf("\n[TEST 4] Testing handshake state timeout reset (>5000ms)...\n");
    send_tuneecu_break_train(set_break_on, set_break_off, handle, 0x33);
    st = read_device(handle, buf, 3, &read_bytes);
    assert(st == FT_OK && read_bytes == 3);

    printf("  Sleeping 5.2 seconds to allow handshake state to expire...\n");
    Sleep(5200);

    /* Now write 0xF7. Because >5000ms elapsed, handshake state must be IDLE */
    init_byte = 0xF7;
    st = write_device(handle, &init_byte, 1, &written);
    assert(st == FT_OK && written == 1);

    /* In loopback mode, normal write echoes 1 byte, no ACK */
    st = get_status(handle, &rx, &tx, &ev);
    assert(st == FT_OK && rx == 1);
    st = read_device(handle, &echo_byte, 1, &read_bytes);
    assert(st == FT_OK && read_bytes == 1 && echo_byte == 0xF7);

    printf("[PASS] Stale-state timeout successfully reset handshake state to IDLE\n");

    close_device(handle);
    CloseHandle(rx_event);
    FreeLibrary(module);

    printf("\n=== ALL 5-BAUD BREAK DECODE & VIRTUALIZATION TESTS PASSED ===\n");
    return 0;
}
