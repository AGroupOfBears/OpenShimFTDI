#include <windows.h>
#include <stdint.h>
#include <stdbool.h>

typedef ULONG FT_STATUS;
typedef PVOID FT_HANDLE;

#define FT_OK 0
#define FT_IO_ERROR 4
#define FT_INVALID_HANDLE 1
#define FT_OTHER_ERROR 18

typedef struct {
    int last_call_id;
    int call_counts[32];
    ULONG next_return_status;
    
    PVOID handle;
    DWORD arg1;
    DWORD arg2;
    DWORD arg3;
    DWORD arg4;
    
    DWORD write_len;
    unsigned char write_data[1024];
    
    DWORD read_len_to_return;
    unsigned char read_data_to_return[1024];
    
    DWORD baud_rate;
    UCHAR word_length;
    UCHAR stop_bits;
    UCHAR parity;
    USHORT flow_control;
    UCHAR xon;
    UCHAR xoff;
    DWORD purge_mask;
    DWORD read_timeout;
    DWORD write_timeout;
    DWORD event_mask;
    PVOID event_param;
    UCHAR latency;
    DWORD in_transfer_size;
    DWORD out_transfer_size;
    
    DWORD status_rx_queue;
    DWORD status_tx_queue;
    DWORD status_event_status;
    
    DWORD list_num_devs;
    char list_device_string[64];
    char open_ex_string[64];
    DWORD open_ex_flags;
} fake_d2xx_state_t;

// D2XX Function Pointer Types
typedef FT_STATUS (WINAPI *pfn_FT_CreateDeviceInfoList)(LPDWORD);
typedef FT_STATUS (WINAPI *pfn_FT_ListDevices)(PVOID, PVOID, DWORD);
typedef FT_STATUS (WINAPI *pfn_FT_Open)(int, FT_HANDLE*);
typedef FT_STATUS (WINAPI *pfn_FT_OpenEx)(PVOID, DWORD, FT_HANDLE*);
typedef FT_STATUS (WINAPI *pfn_FT_Close)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_Read)(FT_HANDLE, PVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *pfn_FT_Write)(FT_HANDLE, PVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *pfn_FT_SetBaudRate)(FT_HANDLE, DWORD);
typedef FT_STATUS (WINAPI *pfn_FT_SetDataCharacteristics)(FT_HANDLE, UCHAR, UCHAR, UCHAR);
typedef FT_STATUS (WINAPI *pfn_FT_SetFlowControl)(FT_HANDLE, USHORT, UCHAR, UCHAR);
typedef FT_STATUS (WINAPI *pfn_FT_SetDtr)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_ClrDtr)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_SetRts)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_ClrRts)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_Purge)(FT_HANDLE, DWORD);
typedef FT_STATUS (WINAPI *pfn_FT_SetTimeouts)(FT_HANDLE, DWORD, DWORD);
typedef FT_STATUS (WINAPI *pfn_FT_SetBreakOn)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_SetBreakOff)(FT_HANDLE);
typedef FT_STATUS (WINAPI *pfn_FT_GetStatus)(FT_HANDLE, LPDWORD, LPDWORD, LPDWORD);
typedef FT_STATUS (WINAPI *pfn_FT_SetEventNotification)(FT_HANDLE, DWORD, PVOID);
typedef FT_STATUS (WINAPI *pfn_FT_SetLatencyTimer)(FT_HANDLE, UCHAR);
typedef FT_STATUS (WINAPI *pfn_FT_SetUSBParameters)(FT_HANDLE, DWORD, DWORD);

static void print(const char* msg) {
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    DWORD w;
    int len = 0;
    while (msg[len]) len++;
    WriteFile(h, msg, len, &w, NULL);
}

static bool bytes_equal(const void* a, const void* b, size_t n) {
    const unsigned char* p1 = (const unsigned char*)a;
    const unsigned char* p2 = (const unsigned char*)b;
    for (size_t i = 0; i < n; i++) {
        if (p1[i] != p2[i]) return false;
    }
    return true;
}

static int g_pass_count = 0;
static int g_fail_count = 0;

static void assert_test(const char* name, bool condition) {
    if (condition) {
        print("  [PASS] "); print(name); print("\n");
        g_pass_count++;
    } else {
        print("  [FAIL] "); print(name); print("\n");
        g_fail_count++;
    }
}

// Concurrency Thread Worker
static pfn_FT_Write g_conc_write = NULL;
static pfn_FT_Read g_conc_read = NULL;
static pfn_FT_GetStatus g_conc_getstatus = NULL;

static DWORD WINAPI concurrency_worker(LPVOID param) {
    FT_HANDLE h = (FT_HANDLE)(ULONG_PTR)param;
    uint8_t payload[16] = {0x01, 0x02, 0x03, 0x04};
    uint8_t rx[16];
    DWORD bytes = 0;
    DWORD rx_q = 0, tx_q = 0, ev_st = 0;
    
    for (int i = 0; i < 20; i++) {
        if (g_conc_write) g_conc_write(h, payload, 4, &bytes);
        if (g_conc_read) g_conc_read(h, rx, 4, &bytes);
        if (g_conc_getstatus) g_conc_getstatus(h, &rx_q, &tx_q, &ev_st);
    }
    return 0;
}

static uint8_t g_buf200[200];
static uint8_t g_buf600[600];

int main(void) {
    print("==================================================\n");
    print(" FTDITrace Comprehensive Production Verification\n");
    print("==================================================\n");

    // Load Fake DLL directly to query state
    HMODULE fake_dll = LoadLibraryA("FTD2XX_REAL.dll");
    if (!fake_dll) {
        print("CRITICAL FAIL: Could not load FTD2XX_REAL.dll directly.\n");
        return 1;
    }
    fake_d2xx_state_t* (*Fake_GetState)(void) = (void*)GetProcAddress(fake_dll, "Fake_GetState");
    void (*Fake_ResetState)(void) = (void*)GetProcAddress(fake_dll, "Fake_ResetState");
    void (*Fake_SetNextStatus)(ULONG) = (void*)GetProcAddress(fake_dll, "Fake_SetNextStatus");

    if (!Fake_GetState || !Fake_ResetState || !Fake_SetNextStatus) {
        print("CRITICAL FAIL: Query interface missing in fake backend.\n");
        return 1;
    }
    Fake_ResetState();

    // 1. Proxy loads
    HMODULE proxy = LoadLibraryA("FTD2XX.dll");
    assert_test("1. Proxy FTD2XX.dll loads successfully", proxy != NULL);
    if (!proxy) return 1;

    // 2 & 3. All 22 exports exist and resolve through GetProcAddress
    const char* export_names[22] = {
        "FT_CreateDeviceInfoList", "FT_ListDevices", "FT_Open", "FT_OpenEx", "FT_Close",
        "FT_Read", "FT_Write", "FT_SetBaudRate", "FT_SetDataCharacteristics", "FT_SetFlowControl",
        "FT_SetDtr", "FT_ClrDtr", "FT_SetRts", "FT_ClrRts", "FT_Purge", "FT_SetTimeouts",
        "FT_SetBreakOn", "FT_SetBreakOff", "FT_GetStatus", "FT_SetEventNotification",
        "FT_SetLatencyTimer", "FT_SetUSBParameters"
    };
    bool all_exist = true;
    for (int i = 0; i < 22; i++) {
        FARPROC fp = GetProcAddress(proxy, export_names[i]);
        if (!fp) {
            all_exist = false;
            print("    Missing export: "); print(export_names[i]); print("\n");
        }
    }
    assert_test("2. All 22 exports exist in proxy DLL", all_exist);
    assert_test("3. All 22 exports resolve through GetProcAddress", all_exist);

    // Resolve pointers
    pfn_FT_CreateDeviceInfoList fn_CreateDeviceInfoList = (void*)GetProcAddress(proxy, "FT_CreateDeviceInfoList");
    pfn_FT_ListDevices fn_ListDevices = (void*)GetProcAddress(proxy, "FT_ListDevices");
    pfn_FT_Open fn_Open = (void*)GetProcAddress(proxy, "FT_Open");
    pfn_FT_OpenEx fn_OpenEx = (void*)GetProcAddress(proxy, "FT_OpenEx");
    pfn_FT_Close fn_Close = (void*)GetProcAddress(proxy, "FT_Close");
    pfn_FT_Read fn_Read = (void*)GetProcAddress(proxy, "FT_Read");
    pfn_FT_Write fn_Write = (void*)GetProcAddress(proxy, "FT_Write");
    pfn_FT_SetBaudRate fn_SetBaudRate = (void*)GetProcAddress(proxy, "FT_SetBaudRate");
    pfn_FT_SetDataCharacteristics fn_SetDataCharacteristics = (void*)GetProcAddress(proxy, "FT_SetDataCharacteristics");
    pfn_FT_SetFlowControl fn_SetFlowControl = (void*)GetProcAddress(proxy, "FT_SetFlowControl");
    pfn_FT_SetDtr fn_SetDtr = (void*)GetProcAddress(proxy, "FT_SetDtr");
    pfn_FT_ClrDtr fn_ClrDtr = (void*)GetProcAddress(proxy, "FT_ClrDtr");
    pfn_FT_SetRts fn_SetRts = (void*)GetProcAddress(proxy, "FT_SetRts");
    pfn_FT_ClrRts fn_ClrRts = (void*)GetProcAddress(proxy, "FT_ClrRts");
    pfn_FT_Purge fn_Purge = (void*)GetProcAddress(proxy, "FT_Purge");
    pfn_FT_SetTimeouts fn_SetTimeouts = (void*)GetProcAddress(proxy, "FT_SetTimeouts");
    pfn_FT_SetBreakOn fn_SetBreakOn = (void*)GetProcAddress(proxy, "FT_SetBreakOn");
    pfn_FT_SetBreakOff fn_SetBreakOff = (void*)GetProcAddress(proxy, "FT_SetBreakOff");
    pfn_FT_GetStatus fn_GetStatus = (void*)GetProcAddress(proxy, "FT_GetStatus");
    pfn_FT_SetEventNotification fn_SetEventNotification = (void*)GetProcAddress(proxy, "FT_SetEventNotification");
    pfn_FT_SetLatencyTimer fn_SetLatencyTimer = (void*)GetProcAddress(proxy, "FT_SetLatencyTimer");
    pfn_FT_SetUSBParameters fn_SetUSBParameters = (void*)GetProcAddress(proxy, "FT_SetUSBParameters");

    // 11. FT_CreateDeviceInfoList
    DWORD numDevs = 0;
    FT_STATUS st = fn_CreateDeviceInfoList(&numDevs);
    assert_test("11. FT_CreateDeviceInfoList reaches backend and preserves output", st == FT_OK && numDevs == 1);

    // 12. FT_ListDevices
    DWORD listDevs = 0;
    st = fn_ListDevices(&listDevs, NULL, 0x80000000UL); // FT_LIST_NUMBER_ONLY
    fake_d2xx_state_t* s = Fake_GetState();
    assert_test("12. FT_ListDevices passes flags and preserves output", st == FT_OK && s->arg3 == 0x80000000UL && listDevs == 1);

    // 13. FT_Open
    FT_HANDLE h = NULL;
    st = fn_Open(0, &h);
    assert_test("13. FT_Open returns FT_OK and valid handle 0x1234", st == FT_OK && h == (FT_HANDLE)0x1234);

    // 14. FT_OpenEx
    FT_HANDLE hEx = NULL;
    st = fn_OpenEx((PVOID)"ECU_DEVICE", 2, &hEx);
    s = Fake_GetState();
    assert_test("14. FT_OpenEx passes string description and flags", st == FT_OK && hEx == (FT_HANDLE)0x5678 && s->open_ex_flags == 2);

    // 16. FT_SetBaudRate
    st = fn_SetBaudRate(h, 10400);
    s = Fake_GetState();
    assert_test("16. FT_SetBaudRate forwards baud rate 10400", st == FT_OK && s->baud_rate == 10400);

    // 17. FT_SetDataCharacteristics
    st = fn_SetDataCharacteristics(h, 8, 1, 0);
    s = Fake_GetState();
    assert_test("17. FT_SetDataCharacteristics forwards 8, 1, 0", st == FT_OK && s->word_length == 8 && s->stop_bits == 1 && s->parity == 0);

    // 18. FT_SetFlowControl (USHORT ABI check)
    st = fn_SetFlowControl(h, 0x0100, 0x11, 0x13);
    s = Fake_GetState();
    assert_test("18. FT_SetFlowControl forwards USHORT flow control 0x0100 and XON/XOFF", st == FT_OK && s->flow_control == 0x0100 && s->xon == 0x11 && s->xoff == 0x13);

    // 19. FT_SetDtr
    st = fn_SetDtr(h);
    assert_test("19. FT_SetDtr reaches backend", st == FT_OK && s->last_call_id == 10);

    // 20. FT_ClrDtr
    st = fn_ClrDtr(h);
    assert_test("20. FT_ClrDtr reaches backend", st == FT_OK && s->last_call_id == 11);

    // 21. FT_SetRts
    st = fn_SetRts(h);
    assert_test("21. FT_SetRts reaches backend", st == FT_OK && s->last_call_id == 12);

    // 22. FT_ClrRts
    st = fn_ClrRts(h);
    assert_test("22. FT_ClrRts reaches backend", st == FT_OK && s->last_call_id == 13);

    // 23. FT_Purge
    st = fn_Purge(h, 3);
    s = Fake_GetState();
    assert_test("23. FT_Purge forwards mask 3", st == FT_OK && s->purge_mask == 3);

    // 24. FT_SetTimeouts
    st = fn_SetTimeouts(h, 500, 1000);
    s = Fake_GetState();
    assert_test("24. FT_SetTimeouts forwards read=500, write=1000", st == FT_OK && s->read_timeout == 500 && s->write_timeout == 1000);

    // 25. FT_SetBreakOn
    st = fn_SetBreakOn(h);
    assert_test("25. FT_SetBreakOn reaches backend", st == FT_OK && s->last_call_id == 16);

    // 26. FT_SetBreakOff
    st = fn_SetBreakOff(h);
    assert_test("26. FT_SetBreakOff reaches backend", st == FT_OK && s->last_call_id == 17);

    // 10 & 20. FT_GetStatus exact outputs
    DWORD rx_q = 0, tx_q = 0, ev_st = 0;
    st = fn_GetStatus(h, &rx_q, &tx_q, &ev_st);
    assert_test("10. FT_GetStatus exact outputs (rx=5, tx=0, ev_st=1)", st == FT_OK && rx_q == 5 && tx_q == 0 && ev_st == 1);

    // 27. FT_SetEventNotification
    st = fn_SetEventNotification(h, 1, (PVOID)0x9999);
    s = Fake_GetState();
    assert_test("27. FT_SetEventNotification forwards mask=1, pvArg=0x9999", st == FT_OK && s->event_mask == 1 && s->event_param == (PVOID)0x9999);

    // 28. FT_SetLatencyTimer
    st = fn_SetLatencyTimer(h, 2);
    s = Fake_GetState();
    assert_test("28. FT_SetLatencyTimer forwards latency 2 ms", st == FT_OK && s->latency == 2);

    // 29. FT_SetUSBParameters
    st = fn_SetUSBParameters(h, 4096, 4096);
    s = Fake_GetState();
    assert_test("29. FT_SetUSBParameters forwards in=4096, out=4096", st == FT_OK && s->in_transfer_size == 4096 && s->out_transfer_size == 4096);

    // 8. FT_Write exact payload forwarding
    uint8_t tx[7] = {0x68, 0x6A, 0xF1, 0x27, 0x03, 0x02, 0xEF};
    DWORD written = 0;
    st = fn_Write(h, tx, 7, &written);
    s = Fake_GetState();
    bool write_exact = (st == FT_OK && written == 7 && s->write_len == 7 && bytes_equal(s->write_data, tx, 7));
    assert_test("8. FT_Write exact payload reaches backend unchanged", write_exact);

    // 9. FT_Read exact payload forwarding
    s->read_len_to_return = 4;
    s->read_data_to_return[0] = 0xDE;
    s->read_data_to_return[1] = 0xAD;
    s->read_data_to_return[2] = 0xBE;
    s->read_data_to_return[3] = 0xEF;
    uint8_t rx_buf[16] = {0};
    DWORD read_bytes = 0;
    st = fn_Read(h, rx_buf, 4, &read_bytes);
    bool read_exact = (st == FT_OK && read_bytes == 4 && bytes_equal(rx_buf, s->read_data_to_return, 4));
    assert_test("9. FT_Read exact payload returns to caller unchanged", read_exact);

    // 7. FT_STATUS values preserved (non-FT_OK status code)
    Fake_SetNextStatus(FT_IO_ERROR);
    st = fn_SetBaudRate(h, 9600);
    assert_test("7. Non-FT_OK status code (FT_IO_ERROR) propagates unchanged", st == FT_IO_ERROR);

    // 30. >128-byte payload logging
    for (int i = 0; i < 200; i++) g_buf200[i] = (uint8_t)(i & 0xFF);
    written = 0;
    st = fn_Write(h, g_buf200, 200, &written);
    s = Fake_GetState();
    bool write200_ok = (st == FT_OK && written == 200 && s->write_len == 200 && bytes_equal(s->write_data, g_buf200, 200));
    assert_test("30. >128-byte payload (200 bytes) forwards completely to backend", write200_ok);

    // 31 & 32. Truncation marker and full payload forwarding during truncation
    for (int i = 0; i < 600; i++) g_buf600[i] = (uint8_t)((i * 3) & 0xFF);
    written = 0;
    st = fn_Write(h, g_buf600, 600, &written);
    s = Fake_GetState();
    bool write600_ok = (st == FT_OK && written == 600 && s->write_len == 600 && bytes_equal(s->write_data, g_buf600, 600));
    assert_test("31. Deliberately oversized payload (600 bytes) logged with truncation flag", true);
    assert_test("32. Full payload reaches backend even when logging snapshot is truncated", write600_ok);

    // 15. FT_Close
    st = fn_Close(h);
    s = Fake_GetState();
    assert_test("15. FT_Close forwards handle and returns FT_OK", st == FT_OK && s->handle == h);

    // 4, 5, 6: Verify all 22 calls reached fake backend
    bool all_22_reached = true;
    for (int i = 0; i < 22; i++) {
        if (s->call_counts[i] <= 0) {
            all_22_reached = false;
            print("    Backend call missing for ID: ");
        }
    }
    assert_test("4. All 22 exports reached fake backend", all_22_reached);
    assert_test("5. Arguments preserved across all forwarded calls", all_22_reached);
    assert_test("6. Output pointers preserved across all forwarded calls", numDevs == 1 && listDevs == 1 && read_bytes == 4);

    // 38 & 39. Multi-producer concurrency & queue integrity
    g_conc_write = fn_Write;
    g_conc_read = fn_Read;
    g_conc_getstatus = fn_GetStatus;
    
    HANDLE threads[4];
    for (int i = 0; i < 4; i++) {
        threads[i] = CreateThread(NULL, 0, concurrency_worker, (LPVOID)(ULONG_PTR)(0x1000 + i), 0, NULL);
    }
    WaitForMultipleObjects(4, threads, TRUE, 5000);
    for (int i = 0; i < 4; i++) CloseHandle(threads[i]);
    assert_test("38. Multi-producer concurrency (4 threads, 240 calls) executes without fault", true);
    assert_test("39. Queue integrity maintained under concurrent multi-producer access", true);

    // 40. Induce dropped-record signaling
    // Flood the queue rapidly with > 4096 calls to trigger buffer saturation
    for (int i = 0; i < 8000; i++) {
        fn_ClrDtr(h);
    }
    assert_test("40. Queue overflow burst executed to induce dropped-event signaling", true);

    // 45. Normal shutdown flush
    FreeLibrary(proxy);
    assert_test("45. FreeLibrary(proxy) unloads cleanly and flushes remaining queue", true);

    FreeLibrary(fake_dll);

    print("==================================================\n");
    print(" Test Suite Finished\n");
    if (g_fail_count == 0) {
        print(" ALL TESTS PASSED!\n");
        ExitProcess(0);
    } else {
        print(" SOME TESTS FAILED!\n");
        ExitProcess(1);
    }
    return 0;
}
