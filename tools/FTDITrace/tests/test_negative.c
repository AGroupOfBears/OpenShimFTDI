#include <windows.h>
#include <stdbool.h>

typedef ULONG FT_STATUS;
typedef PVOID FT_HANDLE;

#define FT_OK 0
#define FT_OTHER_ERROR 18

static void print(const char* msg) {
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    DWORD w;
    int len = 0;
    while (msg[len]) len++;
    WriteFile(h, msg, len, &w, NULL);
}

int main(void) {
    print("==================================================\n");
    print(" FTDITrace Negative Test Suite\n");
    print("==================================================\n");

    // TEST 41: Missing FTD2XX_REAL.dll
    SetEnvironmentVariableA("FTDITRACE_REAL_DLL", "C:\\nonexistent_d2xx_path_12345.dll");
    HMODULE hProxy1 = LoadLibraryA("FTD2XX.dll");
    if (!hProxy1) {
        print("  [FAIL] Test 41: Could not load FTD2XX.dll proxy\n");
        ExitProcess(1);
    }
    typedef FT_STATUS (WINAPI *pfn_Open)(int, FT_HANDLE*);
    pfn_Open fn_Open1 = (pfn_Open)GetProcAddress(hProxy1, "FT_Open");
    if (!fn_Open1) {
        print("  [FAIL] Test 41: Could not resolve FT_Open\n");
        FreeLibrary(hProxy1);
        ExitProcess(1);
    }
    FT_HANDLE handle1 = NULL;
    FT_STATUS st1 = fn_Open1(0, &handle1);
    FreeLibrary(hProxy1);

    if (st1 == FT_OTHER_ERROR) {
        print("  [PASS] 41. Missing FTD2XX_REAL.dll returns FT_OTHER_ERROR cleanly\n");
    } else {
        print("  [FAIL] 41. Missing FTD2XX_REAL.dll did not return FT_OTHER_ERROR\n");
        ExitProcess(1);
    }

    // TEST 42: Missing backend export
    SetEnvironmentVariableA("FTDITRACE_REAL_DLL", "./FTD2XX_MISSING_EXP.dll");
    HMODULE hProxy2 = LoadLibraryA("FTD2XX.dll");
    if (!hProxy2) {
        print("  [FAIL] Test 42: Could not load FTD2XX.dll proxy\n");
        ExitProcess(1);
    }
    typedef FT_STATUS (WINAPI *pfn_SetUSBParameters)(FT_HANDLE, DWORD, DWORD);
    pfn_SetUSBParameters fn_SetUSB = (pfn_SetUSBParameters)GetProcAddress(hProxy2, "FT_SetUSBParameters");
    if (!fn_SetUSB) {
        print("  [FAIL] Test 42: Could not resolve FT_SetUSBParameters\n");
        FreeLibrary(hProxy2);
        ExitProcess(1);
    }
    FT_STATUS st2 = fn_SetUSB((FT_HANDLE)0x1234, 4096, 4096);
    FreeLibrary(hProxy2);

    if (st2 == FT_OTHER_ERROR) {
        print("  [PASS] 42. Missing backend export returns FT_OTHER_ERROR cleanly\n");
    } else {
        print("  [FAIL] 42. Missing backend export did not return FT_OTHER_ERROR\n");
        ExitProcess(1);
    }

    print("==================================================\n");
    print(" Negative Tests Finished: ALL PASSED!\n");
    ExitProcess(0);
    return 0;
}
