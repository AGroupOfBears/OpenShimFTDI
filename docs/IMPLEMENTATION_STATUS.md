# OpenShimFTDI Implementation Status

## 1. Overview and Architecture

OpenShimFTDI is an x86 Windows `FTD2XX.dll` compatibility shim designed to enable TuneECU (running under Wine) to communicate with automotive ECUs via a Tactrix OpenPort 2.0 interface.

The target architecture is implemented and verified end-to-end:

```
+-------------------------------------------------------------+
| TuneECU 2.5.x (or Wine 32-bit test runner)                   |
| - Issues standard FTDI D2XX calls                           |
+-------------------------------------------------------------+
                              |
                              v
+-------------------------------------------------------------+
| 32-bit Windows FTD2XX.dll (OpenShimFTDI)                    |
| - Local circular RX FIFO (64 KB) with zero-latency FT_GetStatus|
| - Win32 event notification (FT_SetEventNotification/FT_EVENT_RXCHAR)|
| - KWP Fast Init sequence state machine                      |
| - 5-baud bit-bang sequence detection and logging            |
| - Deferred PassThruConnect at first communication           |
| - Dual backend modes: OPENSHIM_BACKEND=loopback | ipc       |
+-------------------------------------------------------------+
                              |
                              | Localhost TCP (127.0.0.1:19234)
                              | Binary protocol (openshim_ipc.h)
                              v
+-------------------------------------------------------------+
| Native Linux Helper (openshim-helper)                       |
| - Listens strictly on 127.0.0.1:19234                       |
| - Thread-safe J2534 serialization mutex                     |
| - Asynchronous background RX polling and TCP streaming      |
| - Pass-All filter management and LOOPBACK=1 echo            |
| - Dynamic loader for native libj2534.so                     |
+-------------------------------------------------------------+
                              |
                              | J2534 API (C dynamic link)
                              v
+-------------------------------------------------------------+
| NikolaKozina J2534 Driver (libj2534.so) / libusb-1.0        |
+-------------------------------------------------------------+
                              |
                              | USB (VID: 0403, PID: CC4D)
                              v
+-------------------------------------------------------------+
| Physical Hardware: Tactrix OpenPort 2.0                     |
+-------------------------------------------------------------+
```

---

## 2. Implemented Functionality

### 2.1 32-bit Windows FTD2XX.dll Shim
- **Export Table**: All 22 D2XX API functions implemented and exported with stdcall calling convention and clean undecorated aliases via `--kill-at`.
- **Backend Selection**:
  - `OPENSHIM_BACKEND=loopback`: In-process synthetic loopback FIFO for isolated unit testing without external processes.
  - `OPENSHIM_BACKEND=ipc` (default): Winsock client connecting to `127.0.0.1:19234` (configurable via `OPENSHIM_IPC_PORT`).
- **Deferred J2534 Protocol Connection**:
  - `FT_Open` / `FT_OpenEx` issues `IPC_CMD_OPEN` (`PassThruOpen`) only.
  - Protocol connection (`PassThruConnect`) is deferred until first transmit or initialization to ensure correct protocol configuration (e.g., ISO14230 vs ISO9141).
- **Local RX FIFO Buffering**:
  - In-memory circular FIFO (64 KB capacity) maintained inside the DLL.
  - Background Winsock reader thread receives pushed RX frames from helper daemon and inserts them immediately.
  - `FT_GetStatus` queries local count without socket latency or round-trips.
  - `FT_Read` drains the local circular FIFO.
  - `FT_SetEventNotification` triggers Win32 event upon receiving `FT_EVENT_RXCHAR`.
- **KWP Fast Init State Recognition**:
  - Tracks sequence: `FT_SetBaudRate(360)` -> `FT_SetBreakOn` -> `FT_SetBreakOff` -> `FT_Write({0x00}, 1)` -> `FT_SetBaudRate(10400)` -> `FT_Write({0x81, ...}, len)`.
  - Suppresses transmitting 360 baud directly to J2534 (which would fail on OpenPort).
  - Automatically translates `FT_Write` with `0x81` into `IPC_CMD_FAST_INIT` (`PassThruIoctl(FAST_INIT)`).
  - Injects transmitted frame echo into local RX FIFO to satisfy TuneECU's strict echo verification.
- **5-Baud Bit-Bang Detection**:
  - Tracks break toggling at non-360 bauds.
  - Detects 5-baud sequence and emits structured log notice: `[FIVE_BAUD_INIT] Detected 5-baud bit-bang initialization sequence; unsupported by J2534 backend. Logging explicit unsupported condition.`
- **Buffer Purging**:
  - `FT_Purge(FT_PURGE_RX | FT_PURGE_TX)` drains local circular FIFO and issues `CLEAR_RX_BUFFER` and `CLEAR_TX_BUFFER` ioctls to hardware.
- **Logging**:
  - Thread-safe structured logging with timestamps, thread IDs, and hex payload dumps in `ftd2xx-shim.log`.

### 2.2 Native Linux Helper (`openshim-helper`)
- **Transport**: Native C Linux daemon listening strictly on `127.0.0.1:19234`.
- **IPC Protocol (`openshim_ipc.h`)**:
  - Strict 20-byte packed binary header: `magic (0x4F505348)`, `version (1)`, `command_id`, `seq_id`, `status`, `payload_len`.
  - Commands implemented: `PING`, `OPEN`, `CLOSE`, `CONNECT`, `DISCONNECT`, `READ`, `WRITE`, `SET_CONFIG`, `CLEAR_RX`, `CLEAR_TX`, `FAST_INIT`, `START_FILTER`, and asynchronous `RX_DATA` push.
- **J2534 Concurrency Protection**:
  - NikolaKozina `j2534.c` uses shared USB endpoints without internal locking.
  - Helper enforces `pthread_mutex_t g_j2534_lock` across all J2534 calls (`PassThruOpen`, `PassThruConnect`, `PassThruIoctl`, `PassThruReadMsgs`, `PassThruWriteMsgs`).
- **Loopback & Filtering**:
  - Configures `LOOPBACK = 1` on channel connect.
  - Installs Pass-All filter (`PassThruStartMsgFilter` with mask 0x00 and pattern 0x00).
- **Asynchronous RX Streaming**:
  - Dedicated background thread polls `PassThruReadMsgs` and pushes received/echoed frames immediately to the connected client as `IPC_CMD_RX_DATA`.

---

## 3. Test Suite Results

The test suite consists of 4 automated test suites run via `make test`:

| Test Suite | Target Binary | Environment | Scope | Result |
| :--- | :--- | :--- | :--- | :--- |
| **IPC Framing Unit Test** | `test_ipc_framing` | Native Linux (gcc) | Header packing, 20-byte alignment, serialization, status codes | **PASS** |
| **Synthetic Loopback Test** | `test_shim.exe` | Wine 32-bit (`OPENSHIM_BACKEND=loopback`) | 22 D2XX exports, open/close, baud/data/flow settings, event signaling, write-read FIFO loopback, purge | **PASS** |
| **Live Native Helper Test** | `test_helper_live` | Native Linux against Tactrix OpenPort 2.0 | `PassThruOpen`, `PassThruConnect(ISO14230, 10400)`, `SET_CONFIG(DATA_RATE=10400)`, `SET_CONFIG(DATA_RATE=62400)`, `CLEAR_RX`, `CLEAR_TX`, `FAST_INIT` dispatch, `PassThruDisconnect`, `PassThruClose` | **PASS** |
| **End-to-End Wine IPC Test** | `test_shim_ipc.exe` | Wine 32-bit DLL communicating with Linux Helper | Full transport bridge: Wine Winsock IPC -> Helper -> Tactrix OpenPort 2.0, deferred connect, Fast Init recognition, Win32 event signaling, RX queue count verification, local FIFO drain, purge, 5-baud detection logging | **PASS** |

### Live Physical Hardware Verification
> [!IMPORTANT]
> The Tactrix OpenPort 2.0 hardware (USB VID: 0403, PID: CC4D, Rev: 0200) was physically connected and verified during testing.
> - `PassThruOpen` returned Device ID 5 (`Tactrix OpenPort 2.0`, FW `OpenPort 2.0 J2534`).
> - `PassThruConnect(ISO14230, baud=10400)` returned Channel ID 4.
> - `PassThruIoctl(SET_CONFIG, DATA_RATE=62400)` succeeded (validating high-speed TuneECU data transfer rate support).
> - `PassThruIoctl(FAST_INIT)` successfully dispatched the KWP StartCommunication request packet to physical K-line pins.

---

## 4. Known Failures & Limitations

- **No ECU on Bench**: During FAST_INIT dispatch on physical OpenPort hardware without an ECU connected on the bench, hardware returned status 6 (`ERR_TIMEOUT` / `ERR_FAILED`), which was properly handled and propagated without crashing.
- **Root Required for Direct USB**: When running tests without udev permissions, OpenPort USB access requires suitable permissions or root group access.

---

## 5. Unsupported Functionality

- **FIVE_BAUD_INIT**:
  - Bit-banged 5-baud initialization is detected and logged as unsupported.
  - J2534 does not natively implement `FIVE_BAUD_INIT` for K-line on OpenPort.
- **Map Flashing**:
  - Per design constraints, write/reflash routines for ECU ROM maps are not implemented.
- **ECU Emulation / Faking**:
  - OpenShimFTDI does not fake ECU responses. TuneECU remains responsible for probing and communication.

---

## 6. Next Milestone

1. **Bench Testing with Physical ECU**: Connect physical Triumph / KTM Sagem or Keihin ECU to OpenPort K-line and verify complete TuneECU connection handshake and sensor reading.
2. **ISO9141 Mode Switch Evaluation**: Add automated detection if TuneECU probes with ISO9141 framing instead of ISO14230.
3. **Five-Baud Pin 7 Bit-Bang Driver Exploration**: Research hardware feasibility of driving Pin 7 low/high via J2534 `PassThruSetProgrammingVoltage` or raw FTDI bitbang for legacy ECUs.
