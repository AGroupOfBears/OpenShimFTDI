#include "../include/ftditrace.h"
#include <windows.h>
#include <stdio.h>

static HMODULE g_real_dll = NULL;

FARPROC g_fn_FT_CreateDeviceInfoList = NULL;
FARPROC g_fn_FT_ListDevices = NULL;
FARPROC g_fn_FT_Open = NULL;
FARPROC g_fn_FT_OpenEx = NULL;
FARPROC g_fn_FT_Close = NULL;
FARPROC g_fn_FT_Read = NULL;
FARPROC g_fn_FT_Write = NULL;
FARPROC g_fn_FT_SetBaudRate = NULL;
FARPROC g_fn_FT_SetDataCharacteristics = NULL;
FARPROC g_fn_FT_SetFlowControl = NULL;
FARPROC g_fn_FT_SetDtr = NULL;
FARPROC g_fn_FT_ClrDtr = NULL;
FARPROC g_fn_FT_SetRts = NULL;
FARPROC g_fn_FT_ClrRts = NULL;
FARPROC g_fn_FT_Purge = NULL;
FARPROC g_fn_FT_SetTimeouts = NULL;
FARPROC g_fn_FT_SetBreakOn = NULL;
FARPROC g_fn_FT_SetBreakOff = NULL;
FARPROC g_fn_FT_GetStatus = NULL;
FARPROC g_fn_FT_SetEventNotification = NULL;
FARPROC g_fn_FT_SetLatencyTimer = NULL;
FARPROC g_fn_FT_SetUSBParameters = NULL;

bool ftditrace_init_real_dll(void) {
    if (g_real_dll) return true;
    
    char real_dll_path[MAX_PATH] = {0};
    
    if (GetEnvironmentVariableA("FTDITRACE_REAL_DLL", real_dll_path, MAX_PATH) == 0) {
        char dll_path[MAX_PATH] = {0};
        HMODULE hm = NULL;
        if (GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | 
            GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT,
            (LPCSTR)&ftditrace_init_real_dll, &hm)) {
            GetModuleFileNameA(hm, dll_path, sizeof(dll_path));
            char* last_slash = strrchr(dll_path, '\\');
            if (last_slash) *last_slash = '\0';
            wsprintfA(real_dll_path, "%s\\FTD2XX_REAL.dll", dll_path);
        } else {
            wsprintfA(real_dll_path, "FTD2XX_REAL.dll");
        }
    }
    
    g_real_dll = LoadLibraryA(real_dll_path);
    if (!g_real_dll) return false;
    
    g_fn_FT_CreateDeviceInfoList = GetProcAddress(g_real_dll, "FT_CreateDeviceInfoList");
    g_fn_FT_ListDevices = GetProcAddress(g_real_dll, "FT_ListDevices");
    g_fn_FT_Open = GetProcAddress(g_real_dll, "FT_Open");
    g_fn_FT_OpenEx = GetProcAddress(g_real_dll, "FT_OpenEx");
    g_fn_FT_Close = GetProcAddress(g_real_dll, "FT_Close");
    g_fn_FT_Read = GetProcAddress(g_real_dll, "FT_Read");
    g_fn_FT_Write = GetProcAddress(g_real_dll, "FT_Write");
    g_fn_FT_SetBaudRate = GetProcAddress(g_real_dll, "FT_SetBaudRate");
    g_fn_FT_SetDataCharacteristics = GetProcAddress(g_real_dll, "FT_SetDataCharacteristics");
    g_fn_FT_SetFlowControl = GetProcAddress(g_real_dll, "FT_SetFlowControl");
    g_fn_FT_SetDtr = GetProcAddress(g_real_dll, "FT_SetDtr");
    g_fn_FT_ClrDtr = GetProcAddress(g_real_dll, "FT_ClrDtr");
    g_fn_FT_SetRts = GetProcAddress(g_real_dll, "FT_SetRts");
    g_fn_FT_ClrRts = GetProcAddress(g_real_dll, "FT_ClrRts");
    g_fn_FT_Purge = GetProcAddress(g_real_dll, "FT_Purge");
    g_fn_FT_SetTimeouts = GetProcAddress(g_real_dll, "FT_SetTimeouts");
    g_fn_FT_SetBreakOn = GetProcAddress(g_real_dll, "FT_SetBreakOn");
    g_fn_FT_SetBreakOff = GetProcAddress(g_real_dll, "FT_SetBreakOff");
    g_fn_FT_GetStatus = GetProcAddress(g_real_dll, "FT_GetStatus");
    g_fn_FT_SetEventNotification = GetProcAddress(g_real_dll, "FT_SetEventNotification");
    g_fn_FT_SetLatencyTimer = GetProcAddress(g_real_dll, "FT_SetLatencyTimer");
    g_fn_FT_SetUSBParameters = GetProcAddress(g_real_dll, "FT_SetUSBParameters");
    
    return true;
}

void ftditrace_shutdown(void) {
    if (g_real_dll) {
        FreeLibrary(g_real_dll);
        g_real_dll = NULL;
    }
}
