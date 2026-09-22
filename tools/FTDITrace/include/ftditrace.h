#ifndef FTDITRACE_H
#define FTDITRACE_H

#include <windows.h>
#include <stdint.h>
#include <stdbool.h>

#ifdef __cplusplus
extern "C" {
#endif

#define FTDITRACE_VERSION "1.1.0"
#define FTDITRACE_MAX_CAPTURE_BYTES 512

typedef PVOID FT_HANDLE;
typedef ULONG FT_STATUS;

#define FT_OK 0
#define FT_INVALID_HANDLE 1
#define FT_DEVICE_NOT_FOUND 2
#define FT_DEVICE_NOT_OPENED 3
#define FT_IO_ERROR 4
#define FT_INSUFFICIENT_RESOURCES 5
#define FT_INVALID_PARAMETER 6
#define FT_INVALID_BAUD_RATE 7
#define FT_DEVICE_NOT_OPENED_FOR_ERASE 8
#define FT_DEVICE_NOT_OPENED_FOR_WRITE 9
#define FT_FAILED_TO_WRITE_DEVICE 10
#define FT_EEPROM_READ_FAILED 11
#define FT_EEPROM_WRITE_FAILED 12
#define FT_EEPROM_ERASE_FAILED 13
#define FT_EEPROM_NOT_PRESENT 14
#define FT_EEPROM_NOT_PROGRAMMED 15
#define FT_INVALID_ARGS 16
#define FT_NOT_SUPPORTED 17
#define FT_OTHER_ERROR 18
#define FT_DEVICE_LIST_NOT_READY 19

typedef enum {
    EV_FT_CreateDeviceInfoList = 0,
    EV_FT_ListDevices,
    EV_FT_Open,
    EV_FT_OpenEx,
    EV_FT_Close,
    EV_FT_Read,
    EV_FT_Write,
    EV_FT_SetBaudRate,
    EV_FT_SetDataCharacteristics,
    EV_FT_SetFlowControl,
    EV_FT_SetDtr,
    EV_FT_ClrDtr,
    EV_FT_SetRts,
    EV_FT_ClrRts,
    EV_FT_Purge,
    EV_FT_SetTimeouts,
    EV_FT_SetBreakOn,
    EV_FT_SetBreakOff,
    EV_FT_GetStatus,
    EV_FT_SetEventNotification,
    EV_FT_SetLatencyTimer,
    EV_FT_SetUSBParameters,
    EV_META_INFO,
    EV_DROPPED_EVENTS,
    EV_MAX
} ft_event_type_t;

typedef struct {
    uint64_t seq;                 // Monotonic call entry sequence
    DWORD thread_id;
    ft_event_type_t ev_type;
    uint64_t ts_entry;            // Raw QPC at call entry
    uint64_t ts_exit;             // Raw QPC at call exit
    FT_HANDLE handle;
    FT_STATUS status;
    DWORD arg1;
    DWORD arg2;
    DWORD arg3;
    DWORD req_bytes;
    DWORD act_bytes;
    uint32_t original_data_len;   // Total payload length before capture bounds
    uint32_t data_len;            // Captured payload length in data[]
    bool truncated;               // True if original_data_len > FTDITRACE_MAX_CAPTURE_BYTES
    uint8_t data[FTDITRACE_MAX_CAPTURE_BYTES];
} ft_log_event_t;

// Real DLL Function Pointers
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

// Real Proxy Loader API
bool ftditrace_init_real_dll(void);
void ftditrace_shutdown(void);
const char* ftditrace_get_real_dll_path(void);
const char* ftditrace_get_proxy_dll_path(void);

// Logging API
void ftditrace_log_init(void);
void ftditrace_log_shutdown(bool is_process_exit);
void ftditrace_log_enqueue(const ft_log_event_t *ev);
uint64_t ftditrace_qpc(void);
uint64_t ftditrace_qpf(void);
uint32_t ftditrace_qpc_to_ms(uint64_t delta);

#ifdef __cplusplus
}
#endif

#endif // FTDITRACE_H
