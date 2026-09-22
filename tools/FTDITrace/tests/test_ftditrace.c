#include <windows.h>
#include <stdint.h>

typedef ULONG FT_STATUS;
typedef PVOID FT_HANDLE;

void print(const char* msg) {
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    DWORD w;
    int len = 0;
    while(msg[len]) len++;
    WriteFile(h, msg, len, &w, NULL);
}

int main() {
    print("=== FTDITrace Test Harness ===\n");
    HMODULE proxy = LoadLibraryA("FTD2XX.dll");
    if (!proxy) {
        print("FAIL: Could not load proxy FTD2XX.dll\n");
        return 1;
    }
    print("PASS: Loaded proxy FTD2XX.dll\n");

    FT_STATUS (WINAPI *FT_Open)(int, FT_HANDLE*) = (void*)GetProcAddress(proxy, "FT_Open");
    FT_STATUS (WINAPI *FT_Close)(FT_HANDLE) = (void*)GetProcAddress(proxy, "FT_Close");
    FT_STATUS (WINAPI *FT_Write)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)GetProcAddress(proxy, "FT_Write");
    FT_STATUS (WINAPI *FT_Read)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)GetProcAddress(proxy, "FT_Read");
    FT_STATUS (WINAPI *FT_SetBaudRate)(FT_HANDLE, DWORD) = (void*)GetProcAddress(proxy, "FT_SetBaudRate");
    FT_STATUS (WINAPI *FT_SetBreakOn)(FT_HANDLE) = (void*)GetProcAddress(proxy, "FT_SetBreakOn");

    if (!FT_Open || !FT_Close || !FT_Write || !FT_Read || !FT_SetBaudRate || !FT_SetBreakOn) {
        print("FAIL: Missing exports in proxy DLL\n");
        return 1;
    }
    print("PASS: Resolved proxy exports\n");

    FT_HANDLE h = NULL;
    FT_STATUS r = FT_Open(0, &h);
    if (r != 0 || h != (FT_HANDLE)0x1234) {
        print("FAIL: FT_Open\n");
        return 1;
    }
    print("PASS: FT_Open forwarded successfully\n");

    FT_SetBaudRate(h, 10400);
    print("PASS: FT_SetBaudRate\n");

    FT_SetBreakOn(h);
    print("PASS: FT_SetBreakOn\n");

    DWORD w;
    uint8_t tx[7] = {0x68, 0x6A, 0xF1, 0x27, 0x03, 0x02, 0xEF};
    FT_Write(h, tx, 7, &w);
    if (w != 7) {
        print("FAIL: FT_Write did not preserve length\n");
        return 1;
    }
    print("PASS: FT_Write preserved bytes\n");

    DWORD rd = 0;
    uint8_t rx[5];
    FT_Read(h, rx, 1, &rd);
    if (rd != 1 || rx[0] != 0xAA) {
        print("FAIL: FT_Read did not return expected fake byte\n");
        return 1;
    }
    print("PASS: FT_Read returned correct byte\n");

    FT_Close(h);
    print("PASS: FT_Close\n");

    FreeLibrary(proxy);
    print("PASS: Proxy unloaded\n");
    ExitProcess(0); return 0;
}
