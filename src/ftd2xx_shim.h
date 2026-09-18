#ifndef FTD2XX_SHIM_H
#define FTD2XX_SHIM_H

#include <windows.h>

#ifdef __cplusplus
extern "C" {
#endif

typedef PVOID FT_HANDLE;
typedef ULONG FT_STATUS;

enum {
    FT_OK = 0,
    FT_INVALID_HANDLE = 1,
    FT_DEVICE_NOT_FOUND = 2,
    FT_DEVICE_NOT_OPENED = 3,
    FT_IO_ERROR = 4,
    FT_INSUFFICIENT_RESOURCES = 5,
    FT_INVALID_PARAMETER = 6
};

#define FT_OPEN_BY_SERIAL_NUMBER  1UL
#define FT_OPEN_BY_DESCRIPTION    2UL
#define FT_OPEN_BY_LOCATION       4UL

#define FT_LIST_NUMBER_ONLY       0x80000000UL
#define FT_LIST_BY_INDEX          0x40000000UL
#define FT_LIST_ALL               0x20000000UL

#define FT_PURGE_RX               1UL
#define FT_PURGE_TX               2UL

#define FT_EVENT_RXCHAR           1UL
#define FT_EVENT_MODEM_STATUS     2UL

#define FTD2XX_API __declspec(dllexport)

FTD2XX_API FT_STATUS WINAPI FT_CreateDeviceInfoList(LPDWORD lpdwNumDevs);
FTD2XX_API FT_STATUS WINAPI FT_ListDevices(PVOID pArg1, PVOID pArg2, DWORD dwFlags);
FTD2XX_API FT_STATUS WINAPI FT_Open(DWORD deviceNumber, FT_HANDLE *pHandle);
FTD2XX_API FT_STATUS WINAPI FT_OpenEx(PVOID pvArg1, DWORD dwFlags, FT_HANDLE *pHandle);
FTD2XX_API FT_STATUS WINAPI FT_Close(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_Read(FT_HANDLE ftHandle, LPVOID lpBuffer,
                                     DWORD dwBytesToRead, LPDWORD lpdwBytesReturned);
FTD2XX_API FT_STATUS WINAPI FT_Write(FT_HANDLE ftHandle, LPVOID lpBuffer,
                                      DWORD dwBytesToWrite, LPDWORD lpdwBytesWritten);
FTD2XX_API FT_STATUS WINAPI FT_SetBaudRate(FT_HANDLE ftHandle, DWORD dwBaudRate);
FTD2XX_API FT_STATUS WINAPI FT_SetDataCharacteristics(FT_HANDLE ftHandle,
                                                       UCHAR uWordLength,
                                                       UCHAR uStopBits,
                                                       UCHAR uParity);
FTD2XX_API FT_STATUS WINAPI FT_SetFlowControl(FT_HANDLE ftHandle,
                                              USHORT usFlowControl,
                                              UCHAR uXon,
                                              UCHAR uXoff);
FTD2XX_API FT_STATUS WINAPI FT_SetDtr(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_ClrDtr(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_SetRts(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_ClrRts(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_Purge(FT_HANDLE ftHandle, DWORD dwMask);
FTD2XX_API FT_STATUS WINAPI FT_SetTimeouts(FT_HANDLE ftHandle,
                                            DWORD dwReadTimeout,
                                            DWORD dwWriteTimeout);
FTD2XX_API FT_STATUS WINAPI FT_SetBreakOn(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_SetBreakOff(FT_HANDLE ftHandle);
FTD2XX_API FT_STATUS WINAPI FT_GetStatus(FT_HANDLE ftHandle,
                                          LPDWORD lpdwAmountInRxQueue,
                                          LPDWORD lpdwAmountInTxQueue,
                                          LPDWORD lpdwEventStatus);
FTD2XX_API FT_STATUS WINAPI FT_SetEventNotification(FT_HANDLE ftHandle,
                                                     DWORD dwEventMask,
                                                     PVOID pvArg);
FTD2XX_API FT_STATUS WINAPI FT_SetLatencyTimer(FT_HANDLE ftHandle, UCHAR ucLatency);
FTD2XX_API FT_STATUS WINAPI FT_SetUSBParameters(FT_HANDLE ftHandle,
                                                DWORD dwInTransferSize,
                                                DWORD dwOutTransferSize);

#ifdef __cplusplus
}
#endif

#endif
