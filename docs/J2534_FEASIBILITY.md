# J2534 Feasibility Analysis for OpenShimFTDI

## 1. Executive Summary

This document evaluates the feasibility of driving a **Tactrix OpenPort 2.0** hardware adapter through SAE J2534 (and native OpenPort USB protocols) to satisfy the D2XX contract required by legacy Windows **TuneECU 2.5.x** running under Wine.

The evaluation is based strictly on local primary reference material:
1. Official Tactrix headers, sample source code, and configurations (`reference/j2534/tactrix/`).
2. NikolaKozina open-source OpenPort 2.0 J2534 implementation (`reference/j2534/nikolakozina-j2534/`).
3. TuneECU 2.5.x decompiled source and execution traces (`reference/tuneecu-windows/`).

---

## 2. J2534 and OpenPort Reference Baseline

### 2.1 Protocol Identifiers
**Sources**: `j2534_tactrix.h:58-69`, `nikolakozina-j2534/j2534/j2534.c:75-78`.

Standard SAE J2534-1 protocol numbers relevant to TuneECU:
- `ISO9141` = `0x03` (Standard ISO 9141-2 K-Line)
- `ISO14230` = `0x04` (Keyword Protocol 2000 / KWP2000 over K-Line)
- `CAN` = `0x05` (Raw CAN)
- `ISO15765` = `0x06` (Diagnostic CAN)

Tactrix OpenPort 2.0 specific protocol/channel variants (`j2534_tactrix.h:46-54`):
- `ISO9141_K` = `0x00009180` (ISO 9141 over OBD Pin 7 / K-Line)
- `ISO9141_L` = `0x00009190` (ISO 9141 over OBD Pin 15 / L-Line)
- `ISO14230_K` = `0x00009280` (ISO 14230 over OBD Pin 7 / K-Line)
- `ISO14230_L` = `0x00009290` (ISO 14230 over OBD Pin 15 / L-Line)

**Feasibility**: **Directly representable**. OpenPort 2.0 natively supports K-Line on Pin 7 for both ISO 9141 and ISO 14230.

---

## 3. Detailed Operational Mapping

### 3.1 Device Enumeration and Discovery
- **TuneECU Requirement**: `FT_ListDevices` with `FT_LIST_NUMBER_ONLY` and `FT_LIST_BY_INDEX | FT_OPEN_BY_DESCRIPTION`. Expects a device count and a human-readable ASCII string (e.g. `"Tactrix OpenPort 2.0"`).
- **J2534 / OpenPort Capability**: In standard J2534, enumeration is typically handled via Windows registry (`PassThruOpen(NULL, &devId)` opens the default device). In libusb / Linux backend (`nikolakozina-j2534/j2534/j2534.c:662`), devices are scanned by USB VID `0x0403` / PID `0xCC4D`.
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**: OpenShimFTDI can enumerate connected OpenPort 2.0 devices via `libusb` or J2534 registry entries, synthesizing FTDI device description records into `FT_ListDevices`.

---

### 3.2 Channel Connection and Teardown
- **TuneECU Requirement**: `FT_Open` / `FT_OpenEx` -> sets line parameters, timeouts, latency, baud -> `FT_Close`.
- **J2534 Capability**:
  - `PassThruOpen(pName, &DeviceID)` opens the hardware interface (`nikolakozina-j2534/j2534/j2534.c:655`).
  - `PassThruConnect(DeviceID, ProtocolID, Flags, Baudrate, &ChannelID)` connects to the protocol bus (`j2534.c:750`).
  - `PassThruDisconnect(ChannelID)` and `PassThruClose(DeviceID)` close the channel and hardware.
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**: `FT_OpenEx` maps to `PassThruOpen` followed by `PassThruConnect` (or deferred connect upon baud selection). `FT_Close` maps to `PassThruDisconnect` and `PassThruClose`.

---

### 3.3 Baud Rate Configuration
- **TuneECU Requirement**:
  - `10400` baud (diagnostic default)
  - `360` baud (used in `KWPInit` for wakeup generation)
  - `57600`, `62400`, `62500` baud (high-speed programming/reading)
- **J2534 / OpenPort Capability**:
  - `10400`: Standard diagnostic baud rate. Directly supported in J2534 `PassThruConnect` and OpenPort firmware (`ato4 0 10400 0\r\n`).
  - `57600`, `62500`: Standard / common high-speed serial baud rates. OpenPort hardware UART baud generator supports arbitrary baud divisors.
  - `62400`: 62400 baud is within 0.16% of 62500 baud, well within UART sample tolerances (±2-3%).
  - `360` baud: Not a standard diagnostic baud rate. Standard J2534 drivers may reject 360 as an invalid baud rate (`ERR_INVALID_BAUDRATE`). However, TuneECU only sets 360 baud to transmit a single 25 ms break/low pulse (see Section 3.7).
- **Classification**:
  - `10400`, `57600`, `62400`, `62500`: **Directly Representable**.
  - `360`: **Requires Semantic Translation** (translated as part of the Fast Init state sequence).

---

### 3.4 Message Framing and Byte-Stream Emulation (Read/Write)
- **TuneECU Requirement**:
  - Stream-oriented byte access.
  - Calls `FT_Write` with 1 byte or N bytes.
  - Calls `FT_GetStatus` to check available RX queue bytes.
  - Calls `FT_Read` to read 1 byte or N bytes from internal FIFO buffer.
- **J2534 / OpenPort Capability**:
  - Packet-oriented message access.
  - `PassThruWriteMsgs(ChannelID, pMsg, &NumMsgs, Timeout)` writes complete `PASSTHRU_MSG` packets (`j2534.c:1232`).
  - `PassThruReadMsgs(ChannelID, pMsg, &NumMsgs, Timeout)` reads complete `PASSTHRU_MSG` packets (`j2534.c:831`).
  - OpenPort firmware buffers incoming messages according to protocol framing rules.
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**: OpenShimFTDI must implement an internal FIFO buffer architecture:
  - **TX Translation**: When TuneECU performs byte writes (`line = false`), OpenShimFTDI packages data into `PASSTHRU_MSG` packets (or writes single-byte packets) or aggregates stream writes when appropriate.
  - **RX Translation**: A background thread continuously drains `PassThruReadMsgs` into a local ring buffer. `FT_GetStatus` returns the number of buffered bytes in the ring buffer. `FT_Read` reads requested byte counts directly from this ring buffer.

---

### 3.5 Message Filtering
- **TuneECU Requirement**: Expects to see all raw bytes on the wire (no software filtering at FTDI level).
- **J2534 Capability**:
  - In J2534, incoming messages are blocked by default unless a message filter is explicitly configured via `PassThruStartMsgFilter` (`j2534.c:1320`).
  - Tactrix documentation and samples (`reference/j2534/tactrix/samples/klogger/klogger.cpp:237-248`) demonstrate establishing a **Pass-All Filter**:
    ```c
    PASSTHRU_MSG msgMask = { .ProtocolID = protocol, .DataSize = 1, .Data = {0x00} };
    PASSTHRU_MSG msgPattern = { .ProtocolID = protocol, .DataSize = 1, .Data = {0x00} };
    PassThruStartMsgFilter(ChannelID, PASS_FILTER, &msgMask, &msgPattern, NULL, &msgId);
    ```
- **Classification**: **Directly Representable**.
- **Implementation Mechanism**: OpenShimFTDI must automatically execute `PassThruStartMsgFilter` with a pass-all mask/pattern immediately after establishing the protocol channel in `PassThruConnect`.

---

### 3.6 Loopback and Echo Handling
- **TuneECU Requirement**:
  - In byte write mode (`line = false`), TuneECU explicitly waits for the half-duplex bus echo of every transmitted byte and compares `rBuffer[rIndex] == wByte[0]` (`ISOFT.cs:741`).
  - In block mode (`line = true`), TuneECU waits for `rLength = msg.Length` echo bytes and discards them (`ISORead.cs:2100`) before reading the ECU response.
- **J2534 Capability**:
  - J2534 defines the configuration parameter `LOOPBACK` (ID `0x03`, `j2534_tactrix.h:151`).
  - When `LOOPBACK = 1` (`SET_CONFIG`), the J2534 interface returns transmitted messages in the receive queue with `RxStatus` bit 0 set (`TX_MSG_TYPE` / loopback flag).
  - Nikola's OpenPort driver (`j2534.c:1000-1045`) parses loopback packets from OpenPort (`TX_LB_MSG = 0x20`, `packet_type == TX_LB_MSG -> RxStatus = 1`).
- **Classification**: **Directly Representable**.
- **Implementation Mechanism**: OpenShimFTDI enables `LOOPBACK = 1` via `PassThruIoctl(ChannelID, SET_CONFIG, ...)` so that OpenPort echoes transmitted bytes back into the receive ring buffer, satisfying TuneECU's echo verification logic.

---

### 3.7 KWP2000 Fast Initialization
- **TuneECU Requirement**:
  - Sets baud to 360.
  - Asserts break for 200 ms (`FT_SetBreakOn`).
  - Releases break (`FT_SetBreakOff`).
  - Transmits byte `0x00` at 360 baud (9 bit times = 25 ms low pulse, 1 stop bit = high).
  - Sleeps 50 ms.
  - Sets baud to 10400.
  - Transmits `StartCommunication` (`0x81`).
- **J2534 Capability**:
  - J2534-1 defines IOCTL `FAST_INIT` (`0x05`, `j2534_tactrix.h:88`).
  - Supported directly by OpenPort 2.0 hardware and implemented in Nikola's driver (`j2534.c:1718-1768`):
    - Sends command `aty<ChannelID> <DataSize> 0\r\n` along with message payload `0x81`.
    - OpenPort firmware autonomously executes the 25 ms low / 25 ms high wakeup pattern, transmits the message, and returns the response bytes.
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**: OpenShimFTDI can recognize the distinct Fast Init state sequence (baud 360 -> break on/off -> send zero -> baud 10400 -> send 0x81) and map it to a standard J2534 `FAST_INIT` IOCTL call, or emulate break assertion directly if low-level pin control is chosen.

---

### 3.8 ISO 9141-2 / ISO 14230-4 5-Baud Initialization
- **TuneECU Requirement**:
  - Bit-bangs target address byte (`0x33` or `0xD5`) by calling `FT_SetBreakOn` and `FT_SetBreakOff` with `ISOMain.pTiming` (~196 ms) sleep intervals (`ISORead.cs:3635-3658`).
  - Expects 3 synchronization bytes (`0x55, KB1, KB2`) at 10400 baud.
  - Transmits `~KB2` and receives `0xCC`.
- **J2534 Capability**:
  - SAE J2534-1 defines IOCTL `FIVE_BAUD_INIT` (`0x04`, `j2534_tactrix.h:87`).
  - Input: `SBYTE_ARRAY` containing target address byte (e.g. `0x33`).
  - Output: `SBYTE_ARRAY` containing `0x55, KB1, KB2`.
  - **Driver Support Status**: In Nikola's implementation (`nikolakozina-j2534/j2534/j2534.c:1700`), `FIVE_BAUD_INIT` is **not implemented** (`J2534_ERR_NOT_SUPPORTED`). In official Tactrix OpenPort 2.0 Windows driver, `FIVE_BAUD_INIT` is exposed as an IOCTL, but requires firmware-level execution.
  - **Direct Pin Control Alternative**: Tactrix OpenPort 2.0 supports direct pin voltage / ground switching on OBD Pin 7 (K-Line) via `PassThruSetProgrammingVoltage` (`j2534_tactrix.h:124-142`):
    - `#define J1962_PIN_7 7` ("K: Supports GND")
    - `#define SHORT_TO_GROUND 0xFFFFFFFE`
    - `#define VOLTAGE_OFF 0xFFFFFFFF`
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**:
  1. *Approach A (State Recognition)*: Detect the bit-banging loop (11 successive break transitions with ~200 ms sleep). Aggregate into the target address byte (e.g. `0x33`), execute J2534 `FIVE_BAUD_INIT`, and inject `0x55, KB1, KB2` into the RX ring buffer.
  2. *Approach B (Direct Break / Pin Control)*: Map `FT_SetBreakOn` / `FT_SetBreakOff` to OpenPort pin ground assertion (`SHORT_TO_GROUND` / `VOLTAGE_OFF` on Pin 7).

---

### 3.9 Buffer Purge and Queues
- **TuneECU Requirement**: `FT_Purge(m_hPort, 3u)` (`FT_PURGE_RX | FT_PURGE_TX`).
- **J2534 Capability**:
  - IOCTL `CLEAR_RX_BUFFER` (`0x08`) and `CLEAR_TX_BUFFER` (`0x07`) (`j2534_tactrix.h:89-90`).
  - Nikola's driver implements `CLEAR_RX_BUFFER` via `flush_queue()` and `CLEAR_TX_BUFFER` as a no-op (`j2534.c:1770-1782`).
- **Classification**: **Directly Representable**.
- **Implementation Mechanism**: `FT_Purge` calls `PassThruIoctl(ChannelID, CLEAR_RX_BUFFER, NULL, NULL)` and flushes the local RX/TX ring buffers in OpenShimFTDI.

---

### 3.10 Event Notification
- **TuneECU Requirement**: `FT_SetEventNotification(m_hPort, FT_EVENT_RXCHAR, hEvent)` registers a Win32 event signaled whenever bytes enter the RX queue (`ISOFT.cs:574`).
- **J2534 Capability**: Standard J2534 does not use Win32 event handles; it uses blocking calls with timeouts in `PassThruReadMsgs`.
- **Classification**: **Requires Semantic Translation**.
- **Implementation Mechanism**: OpenShimFTDI stores the Win32 `hEvent` handle. Whenever the background reader thread receives messages via `PassThruReadMsgs` and pushes bytes into the local ring buffer, it calls Win32 `SetEvent(hEvent)`, seamlessly unblocking TuneECU's `ThreadProc`.

---

## 4. Comprehensive Feasibility Mapping Matrix

| TuneECU D2XX Feature | Required Parameters / Values | J2534 / OpenPort Equivalent | Feasibility Category | Citation & Notes |
|---|---|---|---|---|
| `FT_ListDevices` | `0x80000000`, `0x40000002` | libusb VID `0x0403` / PID `0xCC4D` scan | **Requires Semantic Translation** | `ISOFT.cs:505`, `j2534.c:662` |
| `FT_Open` / `FT_OpenEx` | Description string / flags | `PassThruOpen` + `PassThruConnect` | **Requires Semantic Translation** | `ISOFT.cs:566`, `j2534.c:655, 750` |
| `FT_Close` | Handle | `PassThruDisconnect` + `PassThruClose` | **Requires Semantic Translation** | `ISOFT.cs:659`, `j2534.c:795, 735` |
| `FT_SetBaudRate` (10400) | 10400 baud | `PassThruConnect(..., 10400, ...)` | **Directly Representable** | `ISOFT.cs:605`, `j2534.c:750` |
| `FT_SetBaudRate` (57600, 62400, 62500) | High baud rates | `PassThruConnect` or `SET_CONFIG` (`DATA_RATE`) | **Directly Representable** | `ISORead.cs:3182`, `j2534_tactrix.h:150` |
| `FT_SetBaudRate` (360) | 360 baud | Intercepted in Fast Init state machine | **Requires Semantic Translation** | `ISORead.cs:3523` |
| `FT_SetDataCharacteristics` | 8 bits, 1 stop bit, no parity | Standard ISO9141/ISO14230 framing | **Directly Representable** | `ISOFT.cs:580`, 8N1 standard |
| `FT_SetFlowControl` | `FT_FLOW_NONE`, XON=17, XOFF=19 | Standard J2534 UART mode | **Directly Representable** | `ISOFT.cs:581` |
| `FT_SetTimeouts` | Read=150ms, Write=150ms | Internal FIFO read timeout & J2534 timeouts | **Requires Semantic Translation** | `ISOFT.cs:585` |
| `FT_SetLatencyTimer` | 4 ms | USB polling frequency in shim worker | **Requires Semantic Translation** | `ISOFT.cs:586` |
| `FT_SetUSBParameters` | In=128, Out=0 | Internal ring buffer sizing | **Requires Semantic Translation** | `ISOFT.cs:584` |
| `FT_Purge` | `3u` (`PURGE_RX \| PURGE_TX`) | `CLEAR_RX_BUFFER` / `CLEAR_TX_BUFFER` | **Directly Representable** | `ISOFT.cs:607`, `j2534.c:1770` |
| `FT_SetEventNotification` | `FT_EVENT_RXCHAR`, `hEvent` | Worker thread signals `SetEvent(hEvent)` | **Requires Semantic Translation** | `ISOFT.cs:574` |
| `FT_GetStatus` | `&AmountInRxQueue` | Query local RX ring buffer count | **Requires Semantic Translation** | `ISOFT.cs:703, 735` |
| `FT_Write` (single byte, `line=0`) | 1 byte + echo verify | `PassThruWriteMsgs` (`DataSize=1`) | **Requires Semantic Translation** | `ISOFT.cs:680`, `j2534.c:1255` |
| `FT_Write` (block write, `line=1`) | N bytes full frame | `PassThruWriteMsgs` (`DataSize=N`) | **Directly Representable** | `ISOFT.cs:623`, `j2534.c:1232` |
| `FT_Read` (single or block) | Buffer pointer, count | Drain local RX ring buffer | **Requires Semantic Translation** | `ISOFT.cs:705, 737` |
| Bus Echo (`eEcho=true`) | Transmit loopback | `LOOPBACK = 1` (`SET_CONFIG`) | **Directly Representable** | `ISOFT.cs:710`, `j2534.c:1000` |
| Fast Init Wakeup | 200ms break + 25ms pulse | `PassThruIoctl(FAST_INIT, ...)` | **Requires Semantic Translation** | `ISORead.cs:3523`, `j2534.c:1718` |
| 5-Baud Init Address | Bit-banged break transitions | `PassThruIoctl(FIVE_BAUD_INIT)` or Pin 7 GND | **Requires Semantic Translation** | `ISORead.cs:3635`, `j2534_tactrix.h:87` |
| `FT_SetBreakOn` / `Off` | K-Line break assert/release | Pin 7 GND / Voltage Off or Init IOCTLs | **Requires Semantic Translation** | `ISOFT.cs:1563, 1569` |
| `FT_SetDtr` / `ClrDtr` | Modem control | Unused by TuneECU (0 calls) | **Unsupported (Not Required)** | `ISOFT.cs:141` |
| `FT_SetRts` / `ClrRts` | Modem control | Unused by TuneECU (0 calls) | **Unsupported (Not Required)** | `ISOFT.cs:149` |

---

## 5. Feasibility Conclusion and Architectural Guidance

### Feasibility Determination: **FEASIBLE WITH SEMANTIC TRANSLATION**

There are no fundamental architectural blockers preventing an OpenPort 2.0 adapter from driving Windows TuneECU 2.5.x. All communications are physically conducted over standard K-Line (Pin 7), which OpenPort 2.0 natively supports.

However, a naive 1:1 API pass-through is impossible because D2XX exposes an **asynchronous byte stream** with manual line break toggling, whereas J2534 exposes a **packet-oriented diagnostic messaging system**.

### Architectural Recommendations for OpenShimFTDI:
1. **Asynchronous Ring Buffer Core**:
   OpenShimFTDI must maintain thread-safe local RX and TX ring buffers. A background transport worker continuously drains OpenPort via `PassThruReadMsgs` (with `LOOPBACK = 1` and a Pass-All filter enabled) and populates the RX ring buffer, firing `SetEvent(hEvent)` whenever new bytes arrive.
2. **Break and Init State Machine**:
   TuneECU's ECU probing logic relies on `FT_SetBreakOn` / `FT_SetBreakOff` for both Fast Init and 5-Baud Init. OpenShimFTDI can either:
   - Provide a state tracker that detects the 5-baud bit-bang and Fast Init sequences and translates them to standard J2534 `FIVE_BAUD_INIT` and `FAST_INIT` IOCTLs; OR
   - Translate break on/off to OpenPort 2.0 Pin 7 ground assert / release commands.
3. **Strict Preservation of TuneECU Logic**:
   The shim must not attempt to spoof ECU identification, detect motorcycle models, or alter request/response payloads. TuneECU's automatic probing and multi-mode identification logic in `ISORead.cs` must run completely unmodified.
