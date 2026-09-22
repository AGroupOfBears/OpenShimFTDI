#ifndef FTDITRACE_H
#define FTDITRACE_H

#include <windows.h>
#include <stdint.h>
#include <stdbool.h>

#ifdef __cplusplus
extern "C" {
#endif

// D2XX types mapped for basic compatibility
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

// Logging Events
typedef enum {
    EV_FT_CreateDeviceInfoList,
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
    EV_META_INFO
} ft_event_type_t;

typedef struct {
    uint64_t seq;
    ft_event_type_t ev_type;
    uint32_t thread_id;
    uint64_t ts_entry;
    uint64_t ts_exit;
    FT_HANDLE handle;
    FT_STATUS status;

    uint32_t arg1;
    uint32_t arg2;
    uint32_t arg3;
    
    uint32_t req_bytes;
    uint32_t act_bytes;
    
    // Up to 128 bytes of data stored inline (sufficient for typical J2534/K-Line diagnostics)
    // If it exceeds, we cap the logging, but real DLL call handles it fine.
    uint32_t data_len;
    uint8_t data[256];
} ft_log_event_t;

// Real Proxy Loader API
bool ftditrace_init_real_dll(void);
void ftditrace_shutdown(void);

// Logging API
void ftditrace_log_init(void);
void ftditrace_log_shutdown(void);
void ftditrace_log_enqueue(ft_log_event_t *ev);
uint64_t ftditrace_qpc(void);
uint32_t ftditrace_qpc_to_ms(uint64_t delta);

#ifdef __cplusplus
}
#endif

#endif // FTDITRACE_H
