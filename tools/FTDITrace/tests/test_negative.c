#include <windows.h>
#include <stdbool.h>

int main(void) {
    SetEnvironmentVariableA("FTDITRACE_REAL_DLL", "C:\\nonexistent_d2xx_path_12345.dll");
    HMODULE h = LoadLibraryA("FTD2XX.dll");
    if (!h) {
        ExitProcess(0);
    }
    typedef ULONG (WINAPI *pfn_Open)(int, PVOID*);
    pfn_Open fn = (pfn_Open)GetProcAddress(h, "FT_Open");
    if (fn) {
        PVOID handle = NULL;
        ULONG st = fn(0, &handle);
        // Should return FT_OTHER_ERROR (18) and not crash
        if (st == 18) {
            FreeLibrary(h);
            ExitProcess(0);
        }
    }
    FreeLibrary(h);
    ExitProcess(1);
    return 0;
}
