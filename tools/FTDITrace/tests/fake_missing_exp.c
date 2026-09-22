#include <windows.h>

#define EXPORT __declspec(dllexport) WINAPI

EXPORT ULONG FT_Open(int iDevice, PVOID *ftHandle) {
    (void)iDevice;
    if (ftHandle) *ftHandle = (PVOID)0x1234;
    return 0; // FT_OK
}

EXPORT ULONG FT_Close(PVOID ftHandle) {
    (void)ftHandle;
    return 0; // FT_OK
}

// Deliberately omits FT_SetUSBParameters, FT_SetLatencyTimer, etc.

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    (void)hinstDLL;
    (void)fdwReason;
    (void)lpvReserved;
    return TRUE;
}
