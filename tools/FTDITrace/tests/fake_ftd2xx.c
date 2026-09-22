#include <windows.h>
#define EXPORT __declspec(dllexport) WINAPI

EXPORT ULONG FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs) { if(lpdwNumDevs) *lpdwNumDevs=1; return 0; }
EXPORT ULONG FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD Flags) { (void)pArg1; (void)pArg2; (void)Flags; return 0; }
EXPORT ULONG FT_Open(int iDevice, PVOID *ftHandle) { (void)iDevice; if(ftHandle) *ftHandle=(PVOID)0x1234; return 0; }
EXPORT ULONG FT_OpenEx(PVOID pArg1, DWORD dwFlags, PVOID *ftHandle) { (void)pArg1; (void)dwFlags; if(ftHandle) *ftHandle=(PVOID)0x5678; return 0; }
EXPORT ULONG FT_Close(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_Read(PVOID ftHandle, PVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned) { 
    (void)ftHandle; 
    if(lpBuffer && dwBytesToRead > 0) {
        ((unsigned char*)lpBuffer)[0] = 0xAA;
        if(lpdwBytesReturned) *lpdwBytesReturned = 1;
    }
    return 0; 
}
EXPORT ULONG FT_Write(PVOID ftHandle, PVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten) { 
    (void)ftHandle; (void)lpBuffer; 
    if(lpdwBytesWritten) *lpdwBytesWritten = dwBytesToWrite; 
    return 0; 
}
EXPORT ULONG FT_SetBaudRate(PVOID ftHandle, DWORD dwBaudRate) { (void)ftHandle; (void)dwBaudRate; return 0; }
EXPORT ULONG FT_SetDataCharacteristics(PVOID ftHandle, UCHAR uWordLength, UCHAR uStopBits, UCHAR uParity) { (void)ftHandle; (void)uWordLength; (void)uStopBits; (void)uParity; return 0; }
EXPORT ULONG FT_SetFlowControl(PVOID ftHandle, ULONG usFlowControl, UCHAR uXon, UCHAR uXoff) { (void)ftHandle; (void)usFlowControl; (void)uXon; (void)uXoff; return 0; }
EXPORT ULONG FT_SetDtr(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_ClrDtr(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_SetRts(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_ClrRts(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_Purge(PVOID ftHandle, DWORD dwMask) { (void)ftHandle; (void)dwMask; return 0; }
EXPORT ULONG FT_SetTimeouts(PVOID ftHandle, DWORD dwReadTimeout, DWORD dwWriteTimeout) { (void)ftHandle; (void)dwReadTimeout; (void)dwWriteTimeout; return 0; }
EXPORT ULONG FT_SetBreakOn(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_SetBreakOff(PVOID ftHandle) { (void)ftHandle; return 0; }
EXPORT ULONG FT_GetStatus(PVOID ftHandle, LPDWORD lpdwAmountInRxQueue, LPDWORD lpdwAmountInTxQueue, LPDWORD lpdwEventStatus) { 
    (void)ftHandle; 
    if(lpdwAmountInRxQueue) *lpdwAmountInRxQueue=5; 
    if(lpdwAmountInTxQueue) *lpdwAmountInTxQueue=0; 
    if(lpdwEventStatus) *lpdwEventStatus=1; 
    return 0; 
}
EXPORT ULONG FT_SetEventNotification(PVOID ftHandle, DWORD dwEventMask, PVOID pvArg) { (void)ftHandle; (void)dwEventMask; (void)pvArg; return 0; }
EXPORT ULONG FT_SetLatencyTimer(PVOID ftHandle, UCHAR ucTimer) { (void)ftHandle; (void)ucTimer; return 0; }
EXPORT ULONG FT_SetUSBParameters(PVOID ftHandle, DWORD dwInTransferSize, DWORD dwOutTransferSize) { (void)ftHandle; (void)dwInTransferSize; (void)dwOutTransferSize; return 0; }

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    (void)hinstDLL;
    (void)fdwReason;
    (void)lpvReserved;
    return TRUE;
}
