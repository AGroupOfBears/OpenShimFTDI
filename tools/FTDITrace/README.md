# FTDITrace

**FTDITrace** is a standalone diagnostic/reference tool designed to proxy and transparently capture the exact behavioural contract between genuine Windows TuneECU (2.5.5 / 2.5.8) and a genuine FTDI K-Line cable on native Windows 11.

It intercepts calls to `FTD2XX.dll`, records high-resolution timing, input/output arguments, and payloads, and forwards all requests unmodified to genuine `FTD2XX_REAL.dll`.

FTDITrace is **not** part of OpenShimFTDI production runtime. Its purpose is to serve as an empirical reference oracle against which OpenShimFTDI behaviour can be verified.

---

## Concurrency Model & Performance Design

- **Low-Perturbation Design**: Intercepted D2XX functions record entry timestamps and parameters inline, forward immediately to the genuine FTDI driver, record exit timestamps, and enqueue an event record.
- **Critical-Section Protected Queue**: The ring buffer (4096 entries) is protected by a fast Win32 critical section (`CRITICAL_SECTION`). Neither the caller threads nor the real D2XX calls contend on file I/O locks.
- **Asynchronous Logging Worker**: Disk writes (both text log and JSONL) are offloaded to a dedicated background worker thread (`log_worker_thread`) awakened via a Win32 auto-reset event (`SetEvent`).
- **Graceful Shutdown**: When `DllMain` receives `DLL_PROCESS_DETACH`, pending queue events are flushed to disk before closing file handles.

---

## High-Resolution Timing & Sequence Semantics

### Sequence Identifier (`seq`)
- `seq` is assigned atomically (`InterlockedIncrement`) on **call entry** to each D2XX function.
- The log output order reflects **call completion order** (when the background worker drains completed events). Under multi-threaded concurrency, completion order may naturally differ from call entry order. The monotonic `seq` field preserves the strict global invocation order.

### Raw 64-Bit Performance Counter (QPC) Values
To avoid 32-bit truncation or rounding errors, timestamps and clock frequency are recorded in both machine-readable JSONL and text logs as 16-character hexadecimal strings representing full 64-bit unsigned integers:
- `qpc_entry`: 64-bit raw QPC ticks at function entry
- `qpc_exit`: 64-bit raw QPC ticks at function exit
- `qpf`: 64-bit raw QueryPerformanceFrequency ticks per second
- `session_start_qpc`: 64-bit raw QPC ticks recorded at session initialization

### Conversion Formulas
To calculate timing intervals:
- **Call Duration (seconds)**:
  $$\text{duration\_sec} = \frac{\text{qpc\_exit} - \text{qpc\_entry}}{\text{qpf}}$$
- **Call Duration (milliseconds)**:
  $$\text{dur\_ms} = \frac{(\text{qpc\_exit} - \text{qpc\_entry}) \times 1000}{\text{qpf}}$$
- **Offset from Session Start (seconds)**:
  $$\text{offset\_sec} = \frac{\text{qpc\_entry} - \text{session\_start\_qpc}}{\text{qpf}}$$

Derived convenience integers `dur_ms` and `rel_ms` are also provided in each JSONL record.

---

## Payload Logging & Truncation Semantics

- **Bounded Capture**: To maintain predictable memory usage, log event structures allocate a bounded buffer `FTDITRACE_MAX_CAPTURE_BYTES` (512 bytes) for payload inspection.
- **100% Data Forwarding**: Full caller payloads are **always forwarded to the genuine DLL unchanged**, regardless of size. Truncation applies strictly to the logged snapshot.
- **Payload Fields**:
  - `original_data_len`: Actual payload byte count requested/transferred by the caller.
  - `data_len`: Number of bytes captured in the log (up to 512).
  - `truncated`: Boolean flag (`true` if `original_data_len > 512`, `false` otherwise).
  - `data`: JSON array of integers (`[0..255]`) containing the captured bytes.

---

## Safety & Installation Matrix

The installation scripts `scripts/install-ftditrace.ps1` and `scripts/uninstall-ftditrace.ps1` strictly prevent overwriting or destroying genuine FTDI drivers:

| Case | State of TuneECU Directory | Installer Action |
|---|---|---|
| **Scenario B** (Real Baseline) | Clean Windows 11 installation: No local `FTD2XX.dll` or `FTD2XX_REAL.dll` (relies on `SysWOW64\ftd2xx.dll`) | **Safe Install**: Copies genuine 32-bit DLL from `SysWOW64\ftd2xx.dll` to `FTD2XX_REAL.dll` (SysWOW64 is NEVER modified), installs proxy `FTD2XX.dll`, writes `FTDITrace.install.json`. Uninstall removes both local DLLs and manifest, restoring clean SysWOW64 resolution. |
| **Scenario A** (Local DLL) | Local genuine `FTD2XX.dll` exists, `FTD2XX_REAL.dll` does NOT exist | **Safe Install**: Preserves local genuine DLL as `FTD2XX_REAL.dll`, logs SHA-256 hashes, installs proxy `FTD2XX.dll`, writes `FTDITrace.install.json`. Uninstall restores original local DLL exactly. |
| **Repeat Install** | FTDITrace already installed: `FTD2XX_REAL.dll` or `FTDITrace.install.json` exists | **Refused**: Aborts immediately with error to protect the immutable genuine backup. Zero files modified or deleted. |
| **Incomplete / Corrupt** | Files exist but manifest is missing or damaged | **Refused**: Aborts safely without modifying files; requires manual recovery. |

### Parameters & Features
- `-TuneEcuDir <path>`: Target application directory (defaults to `C:\Users\xer0\Desktop\TuneECUv2.5.5`).
- `-ProxyDll <path>`: Source proxy DLL path (defaults to package proxy).
- `-RealD2xxPath <path>`: Source genuine 32-bit D2XX DLL (defaults to `$env:WINDIR\SysWOW64\ftd2xx.dll`).
- `-WhatIf`: Supports PowerShell `-WhatIf` / `ShouldProcess` dry-run simulation without touching files.
- **Architecture Validation**: Enforces 32-bit PE32 (i386 0x014c) binaries and rejects 64-bit binaries (e.g. `System32\ftd2xx.dll`).
- **Driver Safety**: Does **NOT** modify `C:\Windows\System32`, `SysWOW64`, or FTDI INF drivers.

---

## Building (CachyOS)

Requirements: `clang`, `lld`, `wine`, `python3`.

```bash
cd tools/FTDITrace
make clean all test
```

Build outputs:
- `FTD2XX.dll`: 32-bit PE32 proxy DLL exporting all 22 D2XX APIs.
- `FTD2XX_REAL.dll`: Fake backend used for automated testing under Wine.
- `FTD2XX_MISSING_EXP.dll`: Test backend with omitted exports for negative testing.
- `test_ftditrace.exe`: Comprehensive 46-item production test harness.
- `test_negative.exe`: Negative testing verifying missing DLL and missing export handling.

---

## Verifying Binary Characteristics

Run on Linux host:
```bash
file FTD2XX.dll
llvm-readobj --coff-exports FTD2XX.dll
```
Expected output:
- PE32 executable for MS Windows 6.00 (DLL), Intel i386.
- Exactly 22 exported functions with standard undecorated symbols (`FT_Open`, `FT_Close`, `FT_Read`, `FT_Write`, etc.).
