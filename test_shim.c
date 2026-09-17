#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <stdio.h>
#include <string.h>

typedef PVOID FT_HANDLE;
typedef ULONG FT_STATUS;

#define FT_OK 0UL
#define FT_LIST_NUMBER_ONLY 0x80000000UL
#define FT_LIST_BY_INDEX 0x40000000UL
#define FT_OPEN_BY_DESCRIPTION 2UL
#define FT_EVENT_RXCHAR 1UL
#define FT_PURGE_RX 1UL

typedef FT_STATUS (WINAPI *CreateListFn)(LPDWORD);
typedef FT_STATUS (WINAPI *ListFn)(PVOID, PVOID, DWORD);
typedef FT_STATUS (WINAPI *OpenFn)(DWORD, FT_HANDLE *);
typedef FT_STATUS (WINAPI *OpenExFn)(PVOID, DWORD, FT_HANDLE *);
typedef FT_STATUS (WINAPI *CloseFn)(FT_HANDLE);
typedef FT_STATUS (WINAPI *ReadFn)(FT_HANDLE, LPVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *WriteFn)(FT_HANDLE, LPVOID, DWORD, LPDWORD);
typedef FT_STATUS (WINAPI *GetStatusFn)(FT_HANDLE, LPDWORD, LPDWORD, LPDWORD);
typedef FT_STATUS (WINAPI *SetEventFn)(FT_HANDLE, DWORD, PVOID);
typedef FT_STATUS (WINAPI *PurgeFn)(FT_HANDLE, DWORD);
typedef FT_STATUS (WINAPI *SimpleFn)(FT_HANDLE);
typedef FT_STATUS (WINAPI *BaudFn)(FT_HANDLE, DWORD);
typedef FT_STATUS (WINAPI *DataFn)(FT_HANDLE, UCHAR, UCHAR, UCHAR);
typedef FT_STATUS (WINAPI *FlowFn)(FT_HANDLE, USHORT, UCHAR, UCHAR);
typedef FT_STATUS (WINAPI *TimeoutsFn)(FT_HANDLE, DWORD, DWORD);
typedef FT_STATUS (WINAPI *LatencyFn)(FT_HANDLE, UCHAR);
typedef FT_STATUS (WINAPI *UsbFn)(FT_HANDLE, DWORD, DWORD);

#define RESOLVE(variable, type, name)                                      \
    do {                                                                    \
        variable = (type)GetProcAddress(module, name);                      \
        if (variable == NULL) {                                             \
            fprintf(stderr, "FAIL: missing export %s\n", name);            \
            FreeLibrary(module);                                           \
            return 1;                                                       \
        }                                                                   \
    } while (0)

static int expect_ok(const char *operation, FT_STATUS status)
{
    if (status != FT_OK) {
        fprintf(stderr, "FAIL: %s returned %lu\n", operation,
                (unsigned long)status);
        return 0;
    }
    return 1;
}

int main(void)
{
    HMODULE module = LoadLibraryA("FTD2XX.dll");
    CreateListFn create_list;
    ListFn list;
    OpenFn open_device;
    OpenExFn open_ex;
    CloseFn close_device;
    ReadFn read_device;
    WriteFn write_device;
    GetStatusFn get_status;
    SetEventFn set_event;
    PurgeFn purge;
    SimpleFn set_dtr;
    SimpleFn clr_dtr;
    SimpleFn set_rts;
    SimpleFn clr_rts;
    SimpleFn set_break_on;
    SimpleFn set_break_off;
    BaudFn set_baud;
    DataFn set_data;
    FlowFn set_flow;
    TimeoutsFn set_timeouts;
    LatencyFn set_latency;
    UsbFn set_usb;
    FT_HANDLE handle = NULL;
    HANDLE event_handle;
    DWORD count = 0;
    DWORD written = 0;
    DWORD read = 0;
    DWORD rx = 0;
    DWORD tx = 0;
    DWORD events = 0;
    char description[64] = {0};
    BYTE outbound[] = {0x81, 0x12, 0xF1, 0x81, 0x05};
    BYTE inbound[sizeof(outbound)] = {0};
    int result = 1;

    if (module == NULL) {
        fprintf(stderr, "FAIL: LoadLibraryA: error %lu\n",
                (unsigned long)GetLastError());
        return 1;
    }

    RESOLVE(create_list, CreateListFn, "FT_CreateDeviceInfoList");
    RESOLVE(list, ListFn, "FT_ListDevices");
    RESOLVE(open_device, OpenFn, "FT_Open");
    RESOLVE(open_ex, OpenExFn, "FT_OpenEx");
    RESOLVE(close_device, CloseFn, "FT_Close");
    RESOLVE(read_device, ReadFn, "FT_Read");
    RESOLVE(write_device, WriteFn, "FT_Write");
    RESOLVE(get_status, GetStatusFn, "FT_GetStatus");
    RESOLVE(set_event, SetEventFn, "FT_SetEventNotification");
    RESOLVE(purge, PurgeFn, "FT_Purge");
    RESOLVE(set_dtr, SimpleFn, "FT_SetDtr");
    RESOLVE(clr_dtr, SimpleFn, "FT_ClrDtr");
    RESOLVE(set_rts, SimpleFn, "FT_SetRts");
    RESOLVE(clr_rts, SimpleFn, "FT_ClrRts");
    RESOLVE(set_break_on, SimpleFn, "FT_SetBreakOn");
    RESOLVE(set_break_off, SimpleFn, "FT_SetBreakOff");
    RESOLVE(set_baud, BaudFn, "FT_SetBaudRate");
    RESOLVE(set_data, DataFn, "FT_SetDataCharacteristics");
    RESOLVE(set_flow, FlowFn, "FT_SetFlowControl");
    RESOLVE(set_timeouts, TimeoutsFn, "FT_SetTimeouts");
    RESOLVE(set_latency, LatencyFn, "FT_SetLatencyTimer");
    RESOLVE(set_usb, UsbFn, "FT_SetUSBParameters");

    if (!expect_ok("FT_CreateDeviceInfoList", create_list(&count)) || count != 1) {
        fprintf(stderr, "FAIL: expected one device, got %lu\n", (unsigned long)count);
        goto cleanup;
    }

    count = 0;
    if (!expect_ok("FT_ListDevices(number)",
                   list(&count, NULL, FT_LIST_NUMBER_ONLY)) || count != 1) {
        fprintf(stderr, "FAIL: list count mismatch\n");
        goto cleanup;
    }

    if (!expect_ok("FT_ListDevices(description)",
                   list((PVOID)0, description,
                        FT_LIST_BY_INDEX | FT_OPEN_BY_DESCRIPTION)) ||
        strcmp(description, "OpenPort 2.0 FTDI Bridge") != 0) {
        fprintf(stderr, "FAIL: description mismatch: '%s'\n", description);
        goto cleanup;
    }

    if (!expect_ok("FT_Open", open_device(0, &handle)) || handle == NULL) {
        fprintf(stderr, "FAIL: invalid fake handle\n");
        goto cleanup;
    }

    if (!expect_ok("FT_SetBaudRate", set_baud(handle, 360)) ||
        !expect_ok("FT_SetDataCharacteristics", set_data(handle, 8, 0, 0)) ||
        !expect_ok("FT_SetFlowControl", set_flow(handle, 0, 0x11, 0x13)) ||
        !expect_ok("FT_SetDtr", set_dtr(handle)) ||
        !expect_ok("FT_ClrDtr", clr_dtr(handle)) ||
        !expect_ok("FT_SetRts", set_rts(handle)) ||
        !expect_ok("FT_ClrRts", clr_rts(handle)) ||
        !expect_ok("FT_SetTimeouts", set_timeouts(handle, 150, 150)) ||
        !expect_ok("FT_SetBreakOn", set_break_on(handle)) ||
        !expect_ok("FT_SetBreakOff", set_break_off(handle)) ||
        !expect_ok("FT_SetLatencyTimer", set_latency(handle, 4)) ||
        !expect_ok("FT_SetUSBParameters", set_usb(handle, 128, 0))) {
        goto cleanup;
    }

    event_handle = CreateEventA(NULL, FALSE, FALSE, NULL);
    if (event_handle == NULL) {
        fprintf(stderr, "FAIL: CreateEventA: error %lu\n",
                (unsigned long)GetLastError());
        goto cleanup;
    }

    if (!expect_ok("FT_SetEventNotification",
                   set_event(handle, FT_EVENT_RXCHAR, event_handle)) ||
        !expect_ok("FT_Write",
                   write_device(handle, outbound, sizeof(outbound), &written)) ||
        written != sizeof(outbound)) {
        CloseHandle(event_handle);
        goto cleanup;
    }

    if (WaitForSingleObject(event_handle, 250) != WAIT_OBJECT_0) {
        fprintf(stderr, "FAIL: RX event was not signaled\n");
        CloseHandle(event_handle);
        goto cleanup;
    }

    if (!expect_ok("FT_GetStatus", get_status(handle, &rx, &tx, &events)) ||
        rx != sizeof(outbound) || tx != 0 || (events & FT_EVENT_RXCHAR) == 0) {
        fprintf(stderr, "FAIL: unexpected queue status rx=%lu tx=%lu events=0x%lX\n",
                (unsigned long)rx, (unsigned long)tx, (unsigned long)events);
        CloseHandle(event_handle);
        goto cleanup;
    }

    if (!expect_ok("FT_Read", read_device(handle, inbound, sizeof(inbound), &read)) ||
        read != sizeof(outbound) || memcmp(outbound, inbound, sizeof(outbound)) != 0) {
        fprintf(stderr, "FAIL: echo data mismatch\n");
        CloseHandle(event_handle);
        goto cleanup;
    }

    if (!expect_ok("FT_Write(purge setup)",
                   write_device(handle, outbound, sizeof(outbound), &written)) ||
        !expect_ok("FT_Purge(RX/TX)", purge(handle, FT_PURGE_RX | 2UL)) ||
        !expect_ok("FT_GetStatus(after purge)",
                   get_status(handle, &rx, &tx, &events)) || rx != 0) {
        fprintf(stderr, "FAIL: RX purge did not empty the FIFO\n");
        CloseHandle(event_handle);
        goto cleanup;
    }

    CloseHandle(event_handle);
    if (!expect_ok("FT_Close", close_device(handle))) {
        goto cleanup_without_close;
    }
    handle = NULL;

    if (!expect_ok("FT_OpenEx(description)",
                   open_ex("OpenPort 2.0 FTDI Bridge", FT_OPEN_BY_DESCRIPTION,
                           &handle)) || handle == NULL ||
        !expect_ok("FT_Close(after OpenEx)", close_device(handle))) {
        goto cleanup;
    }
    handle = NULL;
    puts("PASS: all 22 exports resolved; enumeration, configuration, open/openEx, event signal, TX echo, RX drain, purge, and close passed");
    result = 0;

cleanup:
    if (handle != NULL) {
        close_device(handle);
    }
cleanup_without_close:
    FreeLibrary(module);
    return result;
}
