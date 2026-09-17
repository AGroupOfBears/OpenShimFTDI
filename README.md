# TuneECU FTD2XX fake-device shim v0.1

This is a 32-bit Windows `FTD2XX.dll` diagnostic shim for TuneECU 2.5.5 under
Wine. It exposes exactly the D2XX entry points found in TuneECU's P/Invoke
declarations and reports one device named:

```text
OpenPort 2.0 FTDI Bridge
```

Version 0.1 has **no Tactrix/OpenPort backend and no ECU write functionality**.
It only supports device discovery/opening, accepts configuration calls, logs
calls, and loops bytes written with `FT_Write` back into a local RX FIFO. The
looped-back bytes signal a caller-supplied `FT_EVENT_RXCHAR` Win32 event. This
is sufficient for observing TuneECU's D2XX call sequence; it is not an ECU or
K-line protocol emulator and will not establish a real ECU session.

## Implemented exports

- `FT_CreateDeviceInfoList`, `FT_ListDevices`
- `FT_Open`, `FT_OpenEx`, `FT_Close`
- `FT_Read`, `FT_Write`, `FT_GetStatus`, `FT_Purge`
- `FT_SetBaudRate`, `FT_SetDataCharacteristics`, `FT_SetFlowControl`
- `FT_SetDtr`, `FT_ClrDtr`, `FT_SetRts`, `FT_ClrRts`
- `FT_SetTimeouts`, `FT_SetBreakOn`, `FT_SetBreakOff`
- `FT_SetEventNotification`, `FT_SetLatencyTimer`, `FT_SetUSBParameters`

`FT_ListDevices` supports D2XX number-only, by-index description/serial, and
list-all forms. The fake serial is `OP20SHIM01`.

## Build on CachyOS / Arch Linux

Install the 32-bit MinGW-w64 cross compiler:

```bash
sudo pacman -S --needed mingw-w64-gcc mingw-w64-binutils make
```

Build and inspect the DLL:

```bash
make
make verify
```

The expected file type is `PE32 executable (DLL) (console) Intel 80386` (the
word "console" in `file` output is harmless for a DLL). The `.def` file and
`--kill-at` ensure that the exports have the undecorated names requested by
TuneECU while the x86 functions still use the WinAPI/stdcall ABI.

To build and run the included smoke test under Wine:

```bash
make test
```

The test dynamically resolves the DLL exports and checks discovery, indexed
description lookup, opening, RX event signaling, TX-to-RX echo, status, read,
purge, and close.

## Use with TuneECU under Wine

1. Keep a backup of any real/official `FTD2XX.dll` already beside TuneECU.
2. Copy this `FTD2XX.dll` into the same directory as `TuneECU.exe`.
3. Start TuneECU with the native DLL override:

   ```bash
   WINEDLLOVERRIDES="ftd2xx=n" wine ./TuneECU.exe
   ```

The shim first tries to append `ftd2xx-shim.log` beside the loaded DLL. If
that directory is not writable, it falls back to the process working
directory. Every exported call is logged with wall-clock milliseconds,
`GetTickCount`, thread ID, arguments, status, and transfer bytes for reads and
writes.

For a clean trace, remove or rename an old log before starting TuneECU. Do not
connect this v0.1 shim to a motorcycle expecting communication: the device is
entirely synthetic and all traffic stays in process memory.

## Design notes

- Target: Windows x86/PE32, not Linux ELF and not Windows x64.
- ABI: `WINAPI` (`__stdcall` on x86), matching TuneECU's `pinvokeimpl ... winapi`.
- Handle: one nonzero synthetic 32-bit handle.
- RX: thread-safe 64 KiB ring FIFO; `FT_GetStatus` reports its byte count and
  `FT_Read` drains it.
- TX: considered immediately transmitted. Each accepted byte is copied to RX.
- Events: the caller owns the event handle. The shim stores but never closes it.
- Purge: mask bit 1 clears RX; bit 2 clears the transient TX state; mask 3 does
  both.
- Close: resets all device, FIFO, configuration, and event state.

This code intentionally contains no J2534, USB, Tactrix, K-line, or ECU-flash
implementation.
