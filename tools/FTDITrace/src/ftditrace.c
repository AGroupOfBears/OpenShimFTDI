#include "../include/ftditrace.h"
#include <windows.h>
#include <stdio.h>
#include <string.h>

extern FARPROC g_fn_FT_CreateDeviceInfoList;
extern FARPROC g_fn_FT_ListDevices;
extern FARPROC g_fn_FT_Open;
extern FARPROC g_fn_FT_OpenEx;
extern FARPROC g_fn_FT_Close;
extern FARPROC g_fn_FT_Read;
extern FARPROC g_fn_FT_Write;
extern FARPROC g_fn_FT_SetBaudRate;
extern FARPROC g_fn_FT_SetDataCharacteristics;
extern FARPROC g_fn_FT_SetFlowControl;
extern FARPROC g_fn_FT_SetDtr;
extern FARPROC g_fn_FT_ClrDtr;
extern FARPROC g_fn_FT_SetRts;
extern FARPROC g_fn_FT_ClrRts;
extern FARPROC g_fn_FT_Purge;
extern FARPROC g_fn_FT_SetTimeouts;
extern FARPROC g_fn_FT_SetBreakOn;
extern FARPROC g_fn_FT_SetBreakOff;
extern FARPROC g_fn_FT_GetStatus;
extern FARPROC g_fn_FT_SetEventNotification;
extern FARPROC g_fn_FT_SetLatencyTimer;
extern FARPROC g_fn_FT_SetUSBParameters;

static volatile LONG g_seq = 0;
static volatile LONG g_init_state = 0;

static void ensure_initialized(void) {
    if (InterlockedCompareExchange(&g_init_state, 1, 0) == 0) {
        ftditrace_log_init();
        if (!ftditrace_init_real_dll()) {
            ft_log_event_t ev;
            memset(&ev, 0, sizeof(ev));
            ev.seq = InterlockedIncrement(&g_seq);
            ev.thread_id = GetCurrentThreadId();
            ev.ev_type = EV_META_INFO;
            ev.status = (ULONG)-1; 
            ev.ts_entry = ftditrace_qpc();
            ev.ts_exit = ev.ts_entry;
            const char* msg = "ERROR: Failed to load FTD2XX_REAL.dll";
            ev.data_len = strlen(msg) > 128 ? 128 : strlen(msg);
            memcpy(ev.data, msg, ev.data_len);
            ftditrace_log_enqueue(&ev);
        }
        InterlockedExchange(&g_init_state, 2);
    } else {
        while (g_init_state != 2) { Sleep(1); }
    }
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    (void)hinstDLL;
    (void)lpvReserved;
    switch (fdwReason) {
        case DLL_PROCESS_ATTACH:
            DisableThreadLibraryCalls(hinstDLL);
            break;
        case DLL_PROCESS_DETACH:
            if (g_init_state == 2) {
                ftditrace_log_shutdown();
                ftditrace_shutdown();
            }
            break;
    }
    return TRUE;
}

#define LOG_ENTRY(ev_val, hnd) \
    ensure_initialized(); \
    ft_log_event_t ev; \
    memset(&ev, 0, sizeof(ev)); \
    ev.seq = InterlockedIncrement(&g_seq); \
    ev.thread_id = GetCurrentThreadId(); \
    ev.ev_type = (ev_val); \
    ev.handle = (hnd); \
    ev.ts_entry = ftditrace_qpc()

#define LOG_EXIT(ret_status) \
    ev.ts_exit = ftditrace_qpc(); \
    ev.status = (ret_status); \
    ftditrace_log_enqueue(&ev)

// Macro to fail safely if mapping missing
#define CHECK_FUNC(func_ptr) \
    if (!(func_ptr)) return FT_INITIALIZE_ERR

static const FT_STATUS FT_INITIALIZE_ERR = 1; // Generic fail conceptually

FT_STATUS WINAPI FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs) {
    LOG_ENTRY(EV_FT_CreateDeviceInfoList, NULL);
    CHECK_FUNC(g_fn_FT_CreateDeviceInfoList);
    FT_STATUS (*func)(LPDWORD) = (void*)g_fn_FT_CreateDeviceInfoList;
    FT_STATUS r = func(lpdwNumDevs);
    ev.arg1 = (uint32_t)(lpdwNumDevs ? *lpdwNumDevs : 0);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD Flags) {
    LOG_ENTRY(EV_FT_ListDevices, NULL);
    CHECK_FUNC(g_fn_FT_ListDevices);
    FT_STATUS (*func)(PVOID, PVOID, DWORD) = (void*)g_fn_FT_ListDevices;
    FT_STATUS r = func(pArg1, pArg2, Flags);
    ev.arg1 = Flags;
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_Open(int iDevice, FT_HANDLE *ftHandle) {
    LOG_ENTRY(EV_FT_Open, NULL);
    CHECK_FUNC(g_fn_FT_Open);
    FT_STATUS (*func)(int, FT_HANDLE*) = (void*)g_fn_FT_Open;
    FT_STATUS r = func(iDevice, ftHandle);
    ev.arg1 = (uint32_t)iDevice;
    ev.handle = (ftHandle && r == FT_OK) ? *ftHandle : NULL;
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_OpenEx(PVOID pArg1, DWORD dwFlags, FT_HANDLE *ftHandle) {
    LOG_ENTRY(EV_FT_OpenEx, NULL);
    CHECK_FUNC(g_fn_FT_OpenEx);
    FT_STATUS (*func)(PVOID, DWORD, FT_HANDLE*) = (void*)g_fn_FT_OpenEx;
    FT_STATUS r = func(pArg1, dwFlags, ftHandle);
    ev.arg1 = dwFlags;
    ev.handle = (ftHandle && r == FT_OK) ? *ftHandle : NULL;
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_Close(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_Close, ftHandle);
    CHECK_FUNC(g_fn_FT_Close);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_Close;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_Read(FT_HANDLE ftHandle, PVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned) {
    LOG_ENTRY(EV_FT_Read, ftHandle);
    CHECK_FUNC(g_fn_FT_Read);
    FT_STATUS (*func)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)g_fn_FT_Read;
    
    ev.req_bytes = dwBytesToRead;
    FT_STATUS r = func(ftHandle, lpBuffer, dwBytesToRead, lpdwBytesReturned);
    ev.act_bytes = lpdwBytesReturned ? *lpdwBytesReturned : 0;
    
    // Copy payload
    if (r == FT_OK && lpBuffer && ev.act_bytes > 0) {
        ev.data_len = (ev.act_bytes > 128) ? 128 : ev.act_bytes;
        memcpy(ev.data, lpBuffer, ev.data_len);
    }
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_Write(FT_HANDLE ftHandle, PVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten) {
    LOG_ENTRY(EV_FT_Write, ftHandle);
    CHECK_FUNC(g_fn_FT_Write);
    FT_STATUS (*func)(FT_HANDLE, PVOID, DWORD, LPDWORD) = (void*)g_fn_FT_Write;
    
    ev.req_bytes = dwBytesToWrite;
    if (lpBuffer && dwBytesToWrite > 0) {
        ev.data_len = (dwBytesToWrite > 128) ? 128 : dwBytesToWrite;
        memcpy(ev.data, lpBuffer, ev.data_len);
    }
    
    FT_STATUS r = func(ftHandle, lpBuffer, dwBytesToWrite, lpdwBytesWritten);
    ev.act_bytes = lpdwBytesWritten ? *lpdwBytesWritten : 0;
    
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetBaudRate(FT_HANDLE ftHandle, DWORD dwBaudRate) {
    LOG_ENTRY(EV_FT_SetBaudRate, ftHandle);
    CHECK_FUNC(g_fn_FT_SetBaudRate);
    FT_STATUS (*func)(FT_HANDLE, DWORD) = (void*)g_fn_FT_SetBaudRate;
    ev.arg1 = dwBaudRate;
    FT_STATUS r = func(ftHandle, dwBaudRate);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetDataCharacteristics(FT_HANDLE ftHandle, UCHAR uWordLength, UCHAR uStopBits, UCHAR uParity) {
    LOG_ENTRY(EV_FT_SetDataCharacteristics, ftHandle);
    CHECK_FUNC(g_fn_FT_SetDataCharacteristics);
    FT_STATUS (*func)(FT_HANDLE, UCHAR, UCHAR, UCHAR) = (void*)g_fn_FT_SetDataCharacteristics;
    ev.arg1 = uWordLength; ev.arg2 = uStopBits; ev.arg3 = uParity;
    FT_STATUS r = func(ftHandle, uWordLength, uStopBits, uParity);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetFlowControl(FT_HANDLE ftHandle, ULONG usFlowControl, UCHAR uXon, UCHAR uXoff) {
    LOG_ENTRY(EV_FT_SetFlowControl, ftHandle);
    CHECK_FUNC(g_fn_FT_SetFlowControl);
    FT_STATUS (*func)(FT_HANDLE, ULONG, UCHAR, UCHAR) = (void*)g_fn_FT_SetFlowControl;
    ev.arg1 = usFlowControl; ev.arg2 = uXon; ev.arg3 = uXoff;
    FT_STATUS r = func(ftHandle, usFlowControl, uXon, uXoff);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetDtr(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetDtr, ftHandle);
    CHECK_FUNC(g_fn_FT_SetDtr);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_SetDtr;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_ClrDtr(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_ClrDtr, ftHandle);
    CHECK_FUNC(g_fn_FT_ClrDtr);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_ClrDtr;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetRts(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetRts, ftHandle);
    CHECK_FUNC(g_fn_FT_SetRts);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_SetRts;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_ClrRts(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_ClrRts, ftHandle);
    CHECK_FUNC(g_fn_FT_ClrRts);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_ClrRts;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_Purge(FT_HANDLE ftHandle, DWORD dwMask) {
    LOG_ENTRY(EV_FT_Purge, ftHandle);
    CHECK_FUNC(g_fn_FT_Purge);
    FT_STATUS (*func)(FT_HANDLE, DWORD) = (void*)g_fn_FT_Purge;
    ev.arg1 = dwMask;
    FT_STATUS r = func(ftHandle, dwMask);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetTimeouts(FT_HANDLE ftHandle, DWORD dwReadTimeout, DWORD dwWriteTimeout) {
    LOG_ENTRY(EV_FT_SetTimeouts, ftHandle);
    CHECK_FUNC(g_fn_FT_SetTimeouts);
    FT_STATUS (*func)(FT_HANDLE, DWORD, DWORD) = (void*)g_fn_FT_SetTimeouts;
    ev.arg1 = dwReadTimeout; ev.arg2 = dwWriteTimeout;
    FT_STATUS r = func(ftHandle, dwReadTimeout, dwWriteTimeout);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetBreakOn(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetBreakOn, ftHandle);
    CHECK_FUNC(g_fn_FT_SetBreakOn);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_SetBreakOn;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetBreakOff(FT_HANDLE ftHandle) {
    LOG_ENTRY(EV_FT_SetBreakOff, ftHandle);
    CHECK_FUNC(g_fn_FT_SetBreakOff);
    FT_STATUS (*func)(FT_HANDLE) = (void*)g_fn_FT_SetBreakOff;
    FT_STATUS r = func(ftHandle);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_GetStatus(FT_HANDLE ftHandle, LPDWORD lpdwAmountInRxQueue, LPDWORD lpdwAmountInTxQueue, LPDWORD lpdwEventStatus) {
    LOG_ENTRY(EV_FT_GetStatus, ftHandle);
    CHECK_FUNC(g_fn_FT_GetStatus);
    FT_STATUS (*func)(FT_HANDLE, LPDWORD, LPDWORD, LPDWORD) = (void*)g_fn_FT_GetStatus;
    FT_STATUS r = func(ftHandle, lpdwAmountInRxQueue, lpdwAmountInTxQueue, lpdwEventStatus);
    ev.arg1 = lpdwAmountInRxQueue ? *lpdwAmountInRxQueue : 0;
    ev.arg2 = lpdwAmountInTxQueue ? *lpdwAmountInTxQueue : 0;
    ev.arg3 = lpdwEventStatus ? *lpdwEventStatus : 0;
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetEventNotification(FT_HANDLE ftHandle, DWORD dwEventMask, PVOID pvArg) {
    LOG_ENTRY(EV_FT_SetEventNotification, ftHandle);
    CHECK_FUNC(g_fn_FT_SetEventNotification);
    FT_STATUS (*func)(FT_HANDLE, DWORD, PVOID) = (void*)g_fn_FT_SetEventNotification;
    ev.arg1 = dwEventMask;
    FT_STATUS r = func(ftHandle, dwEventMask, pvArg);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetLatencyTimer(FT_HANDLE ftHandle, UCHAR ucTimer) {
    LOG_ENTRY(EV_FT_SetLatencyTimer, ftHandle);
    CHECK_FUNC(g_fn_FT_SetLatencyTimer);
    FT_STATUS (*func)(FT_HANDLE, UCHAR) = (void*)g_fn_FT_SetLatencyTimer;
    ev.arg1 = ucTimer;
    FT_STATUS r = func(ftHandle, ucTimer);
    LOG_EXIT(r);
    return r;
}

FT_STATUS WINAPI FT_SetUSBParameters(FT_HANDLE ftHandle, DWORD dwInTransferSize, DWORD dwOutTransferSize) {
    LOG_ENTRY(EV_FT_SetUSBParameters, ftHandle);
    CHECK_FUNC(g_fn_FT_SetUSBParameters);
    FT_STATUS (*func)(FT_HANDLE, DWORD, DWORD) = (void*)g_fn_FT_SetUSBParameters;
    ev.arg1 = dwInTransferSize; ev.arg2 = dwOutTransferSize;
    FT_STATUS r = func(ftHandle, dwInTransferSize, dwOutTransferSize);
    LOG_EXIT(r);
    return r;
}
