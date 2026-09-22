# FTDITrace Windows Deployment Guide (Release Candidate 2)

## Overview & Architecture

**FTDITrace** is an observation-only reference proxy for FTDI D2XX USB communications on Windows 11. It is designed to capture the exact runtime interaction between 32-bit TuneECU (2.5.5) and genuine FTDI USB hardware without modifying or perturbing ECU payloads or timing.

```
TuneECU.exe (32-bit PE32)
   │
   ▼
FTD2XX.dll (FTDITrace Proxy - PE32 x86)
   ├── Records entry QPC, sequence, thread ID, and input parameters
   │
   ▼
FTD2XX_REAL.dll (Genuine FTDI Driver DLL - PE32 x86)
   │
   ▼
Windows USB FTDI Driver & FT232R USB Cable
```

FTDITrace strictly forwards all calls, buffers, and statuses unmodified. It performs **no** emulation, packet rewriting, checksum calculation, or synthetic response generation.

---

## IMPORTANT: Genuine FTDI DLL is NOT Included

In accordance with licensing and driver safety requirements, the proprietary genuine FTDI D2XX DLL is **NOT distributed in this package**.

On native Windows 11 64-bit, the genuine FTDI driver is already installed on the Lenovo T14 Gen 3 development system:
- **Genuine 32-bit DLL**: `C:\Windows\SysWOW64\ftd2xx.dll`
  - Reference SHA-256: `ccd078db89fdf03a2b5647c799976cd0b05023f1ffbab48444a2b3fcf22ebb0b`
  - Size: 283,136 bytes
  - Architecture: PE32 (i386 0x014c)
  - Exports: 93 functions
- **Genuine 64-bit DLL**: `C:\Windows\System32\ftd2xx.dll`
  - Reference SHA-256: `d7d5ac47dd0b5d20dc389fba2608ccd17f37cc08a075555a52ab1fa338a56827`
  - Architecture: PE32+ (x86_64)

> [!WARNING]
> **DO NOT USE `C:\Windows\System32\ftd2xx.dll`**:
> On 64-bit Windows, `System32` contains 64-bit binaries. TuneECU is a 32-bit application and runs under WOW64. It cannot load 64-bit DLLs. The installer automatically enforces PE32 architecture and will reject `System32\ftd2xx.dll`.

---

## Windows Baseline Context (Scenario B vs Scenario A)

### Baseline State on Windows 11 (Scenario B)
By default, the TuneECU application folder:
`C:\Users\xer0\Desktop\TuneECUv2.5.5`
contains **no local `FTD2XX.dll`**. TuneECU relies on standard Windows DLL resolution to load `C:\Windows\SysWOW64\ftd2xx.dll`.

### What Installation Does (Scenario B)
1. Copies `C:\Windows\SysWOW64\ftd2xx.dll` into the TuneECU directory as `FTD2XX_REAL.dll`. (SysWOW64 is NEVER modified or moved).
2. Copies FTDITrace proxy `FTD2XX.dll` into the TuneECU directory.
3. Generates `FTDITrace.install.json` recording original state and file hashes.

### What Uninstall Does (Scenario B)
1. Deletes `FTD2XX.dll` (proxy).
2. Deletes `FTD2XX_REAL.dll` (temporary genuine copy).
3. Deletes `FTDITrace.install.json`.
4. Leaves **no local D2XX DLL** in the TuneECU folder, cleanly returning the system to baseline where Windows DLL search resumes loading `SysWOW64\ftd2xx.dll`.

### Scenario A (If a local genuine `FTD2XX.dll` was already present)
If TuneECU already had a local genuine `FTD2XX.dll`:
- Installation preserves/backs up the local DLL to `FTD2XX_REAL.dll` and installs proxy as `FTD2XX.dll`.
- Uninstallation deletes the proxy, restores `FTD2XX_REAL.dll` -> `FTD2XX.dll`, and verifies the SHA-256 matches the original pre-install hash.

---

## Installation Walkthrough

Open PowerShell (Run as Administrator if TuneECU directory permissions require it) and navigate to the extracted package folder:

```powershell
cd FTDITrace-win32-rc2
```

### Standard Install (Scenario B Default)
```powershell
.\install-ftditrace.ps1 -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5"
```
The installer automatically:
- Resolves genuine 32-bit DLL from `C:\Windows\SysWOW64\ftd2xx.dll`.
- Verifies both proxy and genuine DLL are 32-bit PE32 binaries.
- Installs proxy `FTD2XX.dll` and genuine copy `FTD2XX_REAL.dll`.
- Writes `FTDITrace.install.json`.

### Optional: Install with Explicit Genuine DLL Path
If using a custom backup of genuine `ftd2xx.dll`:
```powershell
.\install-ftditrace.ps1 `
  -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5" `
  -RealD2xxPath "C:\path\to\known-good\ftd2xx.dll"
```

---

## Repeat-Install Safety & Driver Protection

- **Immutable Driver Protection**: If `FTD2XX_REAL.dll` or `FTDITrace.install.json` already exists in the TuneECU directory, the installer **aborts immediately** with an error. It will never overwrite `FTD2XX_REAL.dll` or replace files.
- **Dry Run**: You can pass `-WhatIf` to inspect actions without making changes:
  ```powershell
  .\install-ftditrace.ps1 -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5" -WhatIf
  ```

---

## Uninstallation Walkthrough

To restore TuneECU to its exact pre-installation baseline:

```powershell
.\uninstall-ftditrace.ps1 -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5"
```

The uninstaller reads `FTDITrace.install.json` and performs exact-state restoration:
- For **Scenario B**: Removes `FTD2XX.dll`, `FTD2XX_REAL.dll`, and `FTDITrace.install.json`.
- For **Scenario A**: Restores original `FTD2XX.dll` from `FTD2XX_REAL.dll` and verifies the restored hash.

---

## Trace Log Outputs & Analysis

When TuneECU executes with FTDITrace installed, logs are written to:
`TuneECUDir\FTDITrace-Logs\` (or `FTDITRACE_LOG_DIR` if set).

Each run produces two simultaneous log files:
1. `YYYYMMDD_HHMMSS_pid<PID>_ftditrace.log`: Human-readable text log with timestamps and hex dumps.
2. `YYYYMMDD_HHMMSS_pid<PID>_ftditrace.jsonl`: Complete, machine-readable JSON Lines records.

### High-Resolution Timing Interpretation
- `qpc_entry` and `qpc_exit`: Raw 64-bit performance counter ticks formatted as 16-hex-digit strings.
- In start metadata record: `qpf` (QueryPerformanceFrequency) and `session_start_qpc`.
- Conversion formula:
  $$\text{duration (sec)} = \frac{\text{qpc\_exit} - \text{qpc\_entry}}{\text{qpf}}$$
  $$\text{duration (ms)} = \frac{(\text{qpc\_exit} - \text{qpc\_entry}) \times 1000}{\text{qpf}}$$

---

## Native Bench Testing Advisory

> [!CAUTION]
> **Bench Testing First**: Always validate FTDITrace on Windows in a safe bench setting first:
> 1. Plug in the genuine FT232R USB cable (VID:PID 0403:6001, Serial A50285BI) into the Lenovo T14 Gen 3 without connecting the OBD-II connector to any motorcycle or vehicle ECU.
> 2. Launch TuneECU 2.5.5.
> 3. Verify that TuneECU recognizes the FTDI cable (green/amber status icon) and that trace logs are generated in `FTDITrace-Logs/`.
> 4. Verify log files parse and contain initialization calls (`FT_CreateDeviceInfoList`, `FT_Open`, `FT_SetBaudRate`, etc.).
> 5. Only proceed to vehicle/motorcycle connection after successful native USB bench validation.
