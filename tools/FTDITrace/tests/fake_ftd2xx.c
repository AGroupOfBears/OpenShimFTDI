#include <windows.h>

#define EXPORT __declspec(dllexport) WINAPI

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

static fake_d2xx_state_t g_state;

static void fake_memset(void* dst, int v, size_t n) {
    unsigned char* p = (unsigned char*)dst;
    for (size_t i = 0; i < n; i++) p[i] = (unsigned char)v;
}

static void fake_memcpy(void* dst, const void* src, size_t n) {
    unsigned char* d = (unsigned char*)dst;
    const unsigned char* s = (const unsigned char*)src;
    for (size_t i = 0; i < n; i++) d[i] = s[i];
}

EXPORT fake_d2xx_state_t* Fake_GetState(void) {
    return &g_state;
}

EXPORT void Fake_ResetState(void) {
    fake_memset(&g_state, 0, sizeof(g_state));
    g_state.read_len_to_return = 1;
    g_state.read_data_to_return[0] = 0xAA;
    g_state.status_rx_queue = 5;
    g_state.status_tx_queue = 0;
    g_state.status_event_status = 1;
    g_state.list_num_devs = 1;
}

EXPORT void Fake_SetNextStatus(ULONG status) {
    g_state.next_return_status = status;
}

static ULONG check_status(int func_id) {
    g_state.last_call_id = func_id;
    if (func_id >= 0 && func_id < 32) {
        g_state.call_counts[func_id]++;
    }
    if (g_state.next_return_status != 0) {
        ULONG st = g_state.next_return_status;
        g_state.next_return_status = 0;
        return st;
    }
    return 0; // FT_OK
}

EXPORT ULONG FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs) {
    ULONG st = check_status(0);
    if (st != 0) return st;
    if (lpdwNumDevs) *lpdwNumDevs = g_state.list_num_devs ? g_state.list_num_devs : 1;
    return 0;
}

EXPORT ULONG FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD Flags) {
    g_state.arg1 = (DWORD)(ULONG_PTR)pArg1;
    g_state.arg2 = (DWORD)(ULONG_PTR)pArg2;
    g_state.arg3 = Flags;
    ULONG st = check_status(1);
    if (st != 0) return st;
    if (Flags & 0x80000000UL) { // FT_LIST_NUMBER_ONLY
        if (pArg1) *(LPDWORD)pArg1 = g_state.list_num_devs ? g_state.list_num_devs : 1;
    } else if (Flags & 0x40000000UL) { // FT_LIST_BY_INDEX
        if (pArg2) {
            const char* dev_desc = g_state.list_device_string[0] ? g_state.list_device_string : "FTDI_TEST_DEVICE";
            int i = 0;
            while (dev_desc[i] && i < 63) {
                ((char*)pArg2)[i] = dev_desc[i];
                i++;
            }
            ((char*)pArg2)[i] = 0;
        }
    }
    return 0;
}

EXPORT ULONG FT_Open(int iDevice, PVOID *ftHandle) {
    g_state.arg1 = (DWORD)iDevice;
    ULONG st = check_status(2);
    if (st != 0) return st;
    if (ftHandle) *ftHandle = (PVOID)0x1234;
    return 0;
}

EXPORT ULONG FT_OpenEx(PVOID pArg1, DWORD dwFlags, PVOID *ftHandle) {
    g_state.arg1 = (DWORD)(ULONG_PTR)pArg1;
    g_state.open_ex_flags = dwFlags;
    if (pArg1) {
        int i = 0;
        const char* s = (const char*)pArg1;
        while (s[i] && i < 63) {
            g_state.open_ex_string[i] = s[i];
            i++;
        }
        g_state.open_ex_string[i] = 0;
    }
    ULONG st = check_status(3);
    if (st != 0) return st;
    if (ftHandle) *ftHandle = (PVOID)0x5678;
    return 0;
}

EXPORT ULONG FT_Close(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(4);
}

EXPORT ULONG FT_Read(PVOID ftHandle, PVOID lpBuffer, DWORD dwBytesToRead, LPDWORD lpdwBytesReturned) {
    g_state.handle = ftHandle;
    g_state.arg1 = dwBytesToRead;
    ULONG st = check_status(5);
    if (st != 0) {
        if (lpdwBytesReturned) *lpdwBytesReturned = 0;
        return st;
    }
    DWORD to_copy = dwBytesToRead < g_state.read_len_to_return ? dwBytesToRead : g_state.read_len_to_return;
    if (lpBuffer && to_copy > 0) {
        fake_memcpy(lpBuffer, g_state.read_data_to_return, to_copy);
    }
    if (lpdwBytesReturned) *lpdwBytesReturned = to_copy;
    return 0;
}

EXPORT ULONG FT_Write(PVOID ftHandle, PVOID lpBuffer, DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten) {
    g_state.handle = ftHandle;
    g_state.write_len = dwBytesToWrite;
    DWORD to_save = dwBytesToWrite < 1024 ? dwBytesToWrite : 1024;
    if (lpBuffer && to_save > 0) {
        fake_memcpy(g_state.write_data, lpBuffer, to_save);
    }
    ULONG st = check_status(6);
    if (st != 0) {
        if (lpdwBytesWritten) *lpdwBytesWritten = 0;
        return st;
    }
    if (lpdwBytesWritten) *lpdwBytesWritten = dwBytesToWrite;
    return 0;
}

EXPORT ULONG FT_SetBaudRate(PVOID ftHandle, DWORD dwBaudRate) {
    g_state.handle = ftHandle;
    g_state.baud_rate = dwBaudRate;
    return check_status(7);
}

EXPORT ULONG FT_SetDataCharacteristics(PVOID ftHandle, UCHAR uWordLength, UCHAR uStopBits, UCHAR uParity) {
    g_state.handle = ftHandle;
    g_state.word_length = uWordLength;
    g_state.stop_bits = uStopBits;
    g_state.parity = uParity;
    return check_status(8);
}

EXPORT ULONG FT_SetFlowControl(PVOID ftHandle, USHORT usFlowControl, UCHAR uXon, UCHAR uXoff) {
    g_state.handle = ftHandle;
    g_state.flow_control = usFlowControl;
    g_state.xon = uXon;
    g_state.xoff = uXoff;
    return check_status(9);
}

EXPORT ULONG FT_SetDtr(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(10);
}

EXPORT ULONG FT_ClrDtr(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(11);
}

EXPORT ULONG FT_SetRts(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(12);
}

EXPORT ULONG FT_ClrRts(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(13);
}

EXPORT ULONG FT_Purge(PVOID ftHandle, DWORD dwMask) {
    g_state.handle = ftHandle;
    g_state.purge_mask = dwMask;
    return check_status(14);
}

EXPORT ULONG FT_SetTimeouts(PVOID ftHandle, DWORD dwReadTimeout, DWORD dwWriteTimeout) {
    g_state.handle = ftHandle;
    g_state.read_timeout = dwReadTimeout;
    g_state.write_timeout = dwWriteTimeout;
    return check_status(15);
}

EXPORT ULONG FT_SetBreakOn(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(16);
}

EXPORT ULONG FT_SetBreakOff(PVOID ftHandle) {
    g_state.handle = ftHandle;
    return check_status(17);
}

EXPORT ULONG FT_GetStatus(PVOID ftHandle, LPDWORD lpdwAmountInRxQueue, LPDWORD lpdwAmountInTxQueue, LPDWORD lpdwEventStatus) {
    g_state.handle = ftHandle;
    ULONG st = check_status(18);
    if (st != 0) return st;
    if (lpdwAmountInRxQueue) *lpdwAmountInRxQueue = g_state.status_rx_queue;
    if (lpdwAmountInTxQueue) *lpdwAmountInTxQueue = g_state.status_tx_queue;
    if (lpdwEventStatus) *lpdwEventStatus = g_state.status_event_status;
    return 0;
}

EXPORT ULONG FT_SetEventNotification(PVOID ftHandle, DWORD dwEventMask, PVOID pvArg) {
    g_state.handle = ftHandle;
    g_state.event_mask = dwEventMask;
    g_state.event_param = pvArg;
    return check_status(19);
}

EXPORT ULONG FT_SetLatencyTimer(PVOID ftHandle, UCHAR ucTimer) {
    g_state.handle = ftHandle;
    g_state.latency = ucTimer;
    return check_status(20);
}

EXPORT ULONG FT_SetUSBParameters(PVOID ftHandle, DWORD dwInTransferSize, DWORD dwOutTransferSize) {
    g_state.handle = ftHandle;
    g_state.in_transfer_size = dwInTransferSize;
    g_state.out_transfer_size = dwOutTransferSize;
    return check_status(21);
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    (void)hinstDLL;
    (void)fdwReason;
    (void)lpvReserved;
    return TRUE;
}
