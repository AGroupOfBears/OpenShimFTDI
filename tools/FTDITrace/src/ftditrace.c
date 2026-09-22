#include "../include/ftditrace.h"
#include <windows.h>
#include <string.h>

#define EXPORT __declspec(dllexport) WINAPI

static volatile LONG g_seq = 0;

static void ensure_initialized(void) {
    static volatile LONG init_done = 0;
    if (InterlockedCompareExchange(&init_done, 1, 0) == 0) {
        ftditrace_init_real_dll();
        ftditrace_log_init();
    }
}

#define LOG_ENTRY(ev_val, hnd) \
    ensure_initialized(); \
    ft_log_event_t ev; \
    memset(&ev, 0, sizeof(ev)); \
    ev.seq = (uint64_t)InterlockedIncrement(&g_seq); \
    ev.thread_id = GetCurrentThreadId(); \
    ev.ev_type = (ev_val); \
    ev.handle = (hnd); \
    ev.ts_entry = ftditrace_qpc()

#define LOG_EXIT(ret_status) \
    ev.ts_exit = ftditrace_qpc(); \
    ev.status = (ret_status); \
    ftditrace_log_enqueue(&ev)

#define CHECK_FUNC(fn_ptr) \
    if (!(fn_ptr)) { \
        LOG_EXIT(FT_OTHER_ERROR); \
        return FT_OTHER_ERROR; \
    }

EXPORT FT_STATUS FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs) {
    LOG_ENTRY(EV_FT_CreateDeviceInfoList, NULL);
    CHECK_FUNC(g_fn_FT_CreateDeviceInfoList);
    FT_STATUS (WINAPI *func)(LPDWORD) = (void*)g_fn_FT_CreateDeviceInfoList;
    FT_STATUS r = func(lpdwNumDevs);
    ev.arg1 = lpdwNumDevs ? *lpdwNumDevs : 0;
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD Flags) {
    LOG_ENTRY(EV_FT_ListDevices, NULL);
    ev.arg1 = (DWORD)(ULONG_PTR)pArg1;
    ev.arg2 = (DWORD)(ULONG_PTR)pArg2;
    ev.arg3 = Flags;
    CHECK_FUNC(g_fn_FT_ListDevices);
    FT_STATUS (WINAPI *func)(PVOID, PVOID, DWORD) = (void*)g_fn_FT_ListDevices;
    FT_STATUS r = func(pArg1, pArg2, Flags);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_Open(int iDevice, FT_HANDLE *ftHandle) {
    LOG_ENTRY(EV_FT_Open, NULL);
    ev.arg1 = (DWORD)iDevice;
    CHECK_FUNC(g_fn_FT_Open);
    FT_STATUS (WINAPI *func)(int, FT_HANDLE*) = (void*)g_fn_FT_Open;
    FT_STATUS r = func(iDevice, ftHandle);
    if (r == FT_OK && ftHandle) ev.handle = *ftHandle;
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_OpenEx(PVOID pArg1, DWORD dwFlags, FT_HANDLE *ftHandle) {
    LOG_ENTRY(EV_FT_OpenEx, NULL);
    ev.arg1 = (DWORD)(ULONG_PTR)pArg1;
    ev.arg2 = dwFlags;
    CHECK_FUNC(g_fn_FT_OpenEx);
    FT_STATUS (WINAPI *func)(PVOID, DWORD, FT_HANDLE*) = (void*)g_fn_FT_OpenEx;
    FT_STATUS r = func(pArg1, dwFlags, ftHandle);
    if (r == FT_OK && ftHandle) ev.handle = *ftHandle;
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_Close(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_Close, ftHandle);
    CHECK_FUNC(g_fn_FT_Close);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_Close;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_Read(FT_HANDLE ftHandle, PVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned) {
    LOG_ENTRY(EV_FT_Read, ftHandle);
    CHECK_FUNC(g_fn_FT_Read);
    FT_STATUS (WINAPI *func)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)g_fn_FT_Read;
    ev.req_bytes = dwBytesToRead;
    
    // Genuine DLL receives full original buffer and parameters unchanged
    FT_STATUS r = func(ftHandle, lpBuffer, dwBytesToRead, lpdwBytesReturned);
    
    DWORD actual = lpdwBytesReturned ? *lpdwBytesReturned : 0;
    ev.act_bytes = actual;
    ev.original_data_len = actual;
    if (r == FT_OK && lpBuffer && actual > 0) {
        ev.data_len = (actual > FTDITRACE_MAX_CAPTURE_BYTES) ? FTDITRACE_MAX_CAPTURE_BYTES : actual;
        ev.truncated = (ev.original_data_len > FTDITRACE_MAX_CAPTURE_BYTES);
        memcpy(ev.data, lpBuffer, ev.data_len);
    }
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_Write(FT_HANDLE ftHandle, PVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten) {
    LOG_ENTRY(EV_FT_Write, ftHandle);
    CHECK_FUNC(g_fn_FT_Write);
    FT_STATUS (WINAPI *func)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)g_fn_FT_Write;
    
    ev.req_bytes = dwBytesToWrite;
    ev.original_data_len = dwBytesToWrite;
    if (lpBuffer && dwBytesToWrite > 0) {
        ev.data_len = (dwBytesToWrite > FTDITRACE_MAX_CAPTURE_BYTES) ? FTDITRACE_MAX_CAPTURE_BYTES : dwBytesToWrite;
        ev.truncated = (ev.original_data_len > FTDITRACE_MAX_CAPTURE_BYTES);
        memcpy(ev.data, lpBuffer, ev.data_len);
    }
    
    // Genuine DLL receives original buffer and full dwBytesToWrite
    FT_STATUS r = func(ftHandle, lpBuffer, dwBytesToWrite, lpdwBytesWritten);
    ev.act_bytes = lpdwBytesWritten ? *lpdwBytesWritten : 0;
    
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetBaudRate(FT_HANDLE ftHandle, DWORD dwBaudRate) {
    LOG_ENTRY(EV_FT_SetBaudRate, ftHandle);
    ev.arg1 = dwBaudRate;
    CHECK_FUNC(g_fn_FT_SetBaudRate);
    FT_STATUS (WINAPI *func)(FT_HANDLE, DWORD) = (void*)g_fn_FT_SetBaudRate;
    FT_STATUS r = func(ftHandle, dwBaudRate);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetDataCharacteristics(FT_HANDLE ftHandle, UCHAR uWordLength, UCHAR uStopBits, UCHAR uParity) {
    LOG_ENTRY(EV_FT_SetDataCharacteristics, ftHandle);
    ev.arg1 = uWordLength;
    ev.arg2 = uStopBits;
    ev.arg3 = uParity;
    CHECK_FUNC(g_fn_FT_SetDataCharacteristics);
    FT_STATUS (WINAPI *func)(FT_HANDLE, UCHAR, UCHAR, UCHAR) = (void*)g_fn_FT_SetDataCharacteristics;
    FT_STATUS r = func(ftHandle, uWordLength, uStopBits, uParity);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetFlowControl(FT_HANDLE ftHandle, USHORT usFlowControl, UCHAR uXon, UCHAR uXoff) {
    LOG_ENTRY(EV_FT_SetFlowControl, ftHandle);
    ev.arg1 = usFlowControl;
    ev.arg2 = uXon;
    ev.arg3 = uXoff;
    CHECK_FUNC(g_fn_FT_SetFlowControl);
    FT_STATUS (WINAPI *func)(FT_HANDLE, USHORT, UCHAR, UCHAR) = (void*)g_fn_FT_SetFlowControl;
    FT_STATUS r = func(ftHandle, usFlowControl, uXon, uXoff);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetDtr(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetDtr, ftHandle);
    CHECK_FUNC(g_fn_FT_SetDtr);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_SetDtr;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_ClrDtr(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_ClrDtr, ftHandle);
    CHECK_FUNC(g_fn_FT_ClrDtr);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_ClrDtr;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetRts(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetRts, ftHandle);
    CHECK_FUNC(g_fn_FT_SetRts);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_SetRts;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_ClrRts(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_ClrRts, ftHandle);
    CHECK_FUNC(g_fn_FT_ClrRts);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_ClrRts;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_Purge(FT_HANDLE ftHandle, DWORD dwMask) {
    LOG_ENTRY(EV_FT_Purge, ftHandle);
    ev.arg1 = dwMask;
    CHECK_FUNC(g_fn_FT_Purge);
    FT_STATUS (WINAPI *func)(FT_HANDLE, DWORD) = (void*)g_fn_FT_Purge;
    FT_STATUS r = func(ftHandle, dwMask);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetTimeouts(FT_HANDLE ftHandle, DWORD dwReadTimeout, DWORD dwWriteTimeout) {
    LOG_ENTRY(EV_FT_SetTimeouts, ftHandle);
    ev.arg1 = dwReadTimeout;
    ev.arg2 = dwWriteTimeout;
    CHECK_FUNC(g_fn_FT_SetTimeouts);
    FT_STATUS (WINAPI *func)(FT_HANDLE, DWORD, DWORD) = (void*)g_fn_FT_SetTimeouts;
    FT_STATUS r = func(ftHandle, dwReadTimeout, dwWriteTimeout);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetBreakOn(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetBreakOn, ftHandle);
    CHECK_FUNC(g_fn_FT_SetBreakOn);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_SetBreakOn;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetBreakOff(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetBreakOff, ftHandle);
    CHECK_FUNC(g_fn_FT_SetBreakOff);
    FT_STATUS (WINAPI *func)(FT_HANDLE) = (void*)g_fn_FT_SetBreakOff;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_GetStatus(FT_HANDLE ftHandle, LPDWORD lpdwAmountInRxQueue, LPDWORD lpdwAmountInTxQueue, LPDWORD lpdwEventStatus) {
    LOG_ENTRY(EV_FT_GetStatus, ftHandle);
    CHECK_FUNC(g_fn_FT_GetStatus);
    FT_STATUS (WINAPI *func)(FT_HANDLE, LPDWORD, LPDWORD, LPDWORD) = (void*)g_fn_FT_GetStatus;
    FT_STATUS r = func(ftHandle, lpdwAmountInRxQueue, lpdwAmountInTxQueue, lpdwEventStatus);
    ev.arg1 = lpdwAmountInRxQueue ? *lpdwAmountInRxQueue : 0;
    ev.arg2 = lpdwAmountInTxQueue ? *lpdwAmountInTxQueue : 0;
    ev.arg3 = lpdwEventStatus ? *lpdwEventStatus : 0;
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetEventNotification(FT_HANDLE ftHandle, DWORD dwEventMask, PVOID pvArg) {
    LOG_ENTRY(EV_FT_SetEventNotification, ftHandle);
    ev.arg1 = dwEventMask;
    ev.arg2 = (DWORD)(ULONG_PTR)pvArg;
    CHECK_FUNC(g_fn_FT_SetEventNotification);
    FT_STATUS (WINAPI *func)(FT_HANDLE, DWORD, PVOID) = (void*)g_fn_FT_SetEventNotification;
    FT_STATUS r = func(ftHandle, dwEventMask, pvArg);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetLatencyTimer(FT_HANDLE ftHandle, UCHAR ucTimer) {
    LOG_ENTRY(EV_FT_SetLatencyTimer, ftHandle);
    ev.arg1 = ucTimer;
    CHECK_FUNC(g_fn_FT_SetLatencyTimer);
    FT_STATUS (WINAPI *func)(FT_HANDLE, UCHAR) = (void*)g_fn_FT_SetLatencyTimer;
    FT_STATUS r = func(ftHandle, ucTimer);
    LOG_EXIT(r);
    return r;
}

EXPORT FT_STATUS FT_SetUSBParameters(FT_HANDLE ftHandle, DWORD dwInTransferSize, DWORD dwOutTransferSize) {
    LOG_ENTRY(EV_FT_SetUSBParameters, ftHandle);
    ev.arg1 = dwInTransferSize;
    ev.arg2 = dwOutTransferSize;
    CHECK_FUNC(g_fn_FT_SetUSBParameters);
    FT_STATUS (WINAPI *func)(FT_HANDLE, DWORD, DWORD) = (void*)g_fn_FT_SetUSBParameters;
    FT_STATUS r = func(ftHandle, dwInTransferSize, dwOutTransferSize);
    LOG_EXIT(r);
    return r;
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    (void)hinstDLL;
    switch (fdwReason) {
        case DLL_PROCESS_ATTACH:
            DisableThreadLibraryCalls(hinstDLL);
            break;
        case DLL_PROCESS_DETACH:
            ftditrace_log_shutdown(lpvReserved != NULL);
            break;
    }
    return TRUE;
}
