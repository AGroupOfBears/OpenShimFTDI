# FTDITrace

**FTDITrace** is a standalone diagnostic tool designed to proxy and capture the exact behavioural contract between genuine Windows TuneECU (2.5.5 / 2.5.8) and a genuine FTDI K-Line cable.

It dynamically captures every call to `FTD2XX.dll`, records the arguments, bytes transferred, exact timing, and sequence, and forwards it instantly to the underlying genuine drivers (`FTD2XX_REAL.dll`).

## Goal
The captured logs serve as a **Ground Truth Oracle** for OpenShimFTDI development, allowing us to perfectly replicate native Windows USB latency, packet fragmentation, and serial parameters.

## Building (CachyOS)
```bash
make clean all
```
This uses clang cross-compilation identically to the main OpenShimFTDI project (32-bit `i686-pc-windows-gnu`).

## Deployment (Windows 11)
To capture a real session, copy `FTD2XX.dll` and the `scripts/` folder to the native Windows host running TuneECU with the real FTDI cable plugged in.

1. Open a PowerShell prompt as Administrator.
2. Run `.\install-ftditrace.ps1`
   - This renames the original `FTD2XX.dll` to `FTD2XX_REAL.dll` and places the proxy in its place.
3. Launch TuneECU and perform operations (e.g., Read Map, Test J2534, etc.).
4. Close TuneECU.
5. Retrieve the logs from `TuneECUv2.5.5\FTDITrace-Logs\`.
6. Run `.\uninstall-ftditrace.ps1` to restore the genuine DLL.

## Logging Architecture
FTDITrace is designed to be invisible. It collects timing metrics and arguments inline with near-zero latency, avoiding global lock contention across genuine D2XX calls. The logging serialization runs entirely on a background thread that flushes to disk (both human-readable `.log` and machine-readable `.jsonl`).
