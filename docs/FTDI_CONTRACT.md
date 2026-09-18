# FTDI D2XX Contract for TuneECU 2.5.x

## 1. Scope and Authority

This document defines the exact contract between TuneECU (versions 2.5.5 and 2.5.8) and the FTDI D2XX library (`FTD2XX.dll`). The contract is derived directly from decompiled source code, Intermediate Language (IL) disassembly, and runtime traces of Windows TuneECU.

### Evidence Hierarchy and Labels
- **CONFIRMED**: Directly established through decompiled C# source (`reference/tuneecu-windows/2.5.5/`, `reference/tuneecu-windows/2.5.8/`), IL disassembly (`TuneECU.il`, `ftdi-code.il`), and official API definitions.
- **OBSERVED**: Found in binary or traces, but role or necessity is conditional or context-dependent.
- **INFERRED**: Logical deduction based on hardware/protocol standards corroborated by surrounding code.
- **UNKNOWN**: Insufficient evidence in local reference material.

---

## 2. Inventory of Exported D2XX Functions

TuneECU defines P/Invoke declarations for 22 D2XX functions in `TuneECU.ISOFT`. However, inspection of the compiled bytecode (`ftdi-code.il` and `TuneECU.il`) confirms that only a specific subset is ever invoked during execution.

| D2XX Function | Declared in `ISOFT.cs` | Called in IL / Runtime | Status | Purpose in TuneECU |
|---|---|---|---|---|
| `FT_CreateDeviceInfoList` | Yes | No (0 call sites) | **CONFIRMED** | Declared in interop table, but enumeration uses `FT_ListDevices`. |
| `FT_ListDevices` | Yes | **Yes** | **CONFIRMED** | Device count query (`FT_LIST_NUMBER_ONLY`) and description retrieval (`FT_LIST_BY_INDEX \| FT_OPEN_BY_DESCRIPTION`). |
| `FT_Open` | Yes | **Yes** | **CONFIRMED** | Device open by numeric index (fallback if description flag zero). |
| `FT_OpenEx` | Yes | **Yes** | **CONFIRMED** | Primary device open by ASCII description string. |
| `FT_Close` | Yes | **Yes** | **CONFIRMED** | Closes device handle on disconnect or application exit. |
| `FT_Read` | Yes | **Yes** | **CONFIRMED** | Single-byte read in worker thread (`ThreadProc`) and multi-byte read in timer polling loop (`FTDRead`). |
| `FT_Write` | Yes | **Yes** | **CONFIRMED** | Single-byte write in byte mode (`FTDWriteByte`) and multi-byte write in block mode (`FTDWrite`). |
| `FT_SetBaudRate` | Yes | **Yes** | **CONFIRMED** | Sets UART baud rate (360, 10400, 57600, 62400, 62500 baud). |
| `FT_SetDataCharacteristics` | Yes | **Yes** | **CONFIRMED** | Configures 8 data bits, 1 stop bit, no parity (`FT_BITS_8`, `FT_STOP_BITS_1`, `FT_PARITY_NONE`). |
| `FT_SetFlowControl` | Yes | **Yes** | **CONFIRMED** | Configures no flow control (`FT_FLOW_NONE`), XON=0x11, XOFF=0x13. |
| `FT_SetDtr` | Yes | **No (0 calls)** | **CONFIRMED** | Not used in any code path. |
| `FT_ClrDtr` | Yes | **No (0 calls)** | **CONFIRMED** | Not used in any code path. |
| `FT_SetRts` | Yes | **No (0 calls)** | **CONFIRMED** | Not used in any code path. |
| `FT_ClrRts` | Yes | **No (0 calls)** | **CONFIRMED** | Not used in any code path. |
| `FT_Purge` | Yes | **Yes** | **CONFIRMED** | Flushes RX and TX buffers (`FT_PURGE_RX \| FT_PURGE_TX = 3`). |
| `FT_SetTimeouts` | Yes | **Yes** | **CONFIRMED** | Sets read timeout = 150 ms, write timeout = 150 ms. |
| `FT_SetBreakOn` | Yes | **Yes** | **CONFIRMED** | Forces K-Line LOW (space) for Fast Init wakeup and 5-baud bit-banging. |
| `FT_SetBreakOff` | Yes | **Yes** | **CONFIRMED** | Releases K-Line HIGH (mark) for Fast Init and 5-baud bit-banging. |
| `FT_GetStatus` | Yes | **Yes** | **CONFIRMED** | Queries RX queue byte count (`lpdwAmountInRxQueue`) in worker thread and timer polling. |
| `FT_SetEventNotification` | Yes | **Yes** | **CONFIRMED** | Registers Win32 event for `FT_EVENT_RXCHAR` (1). |
| `FT_SetLatencyTimer` | Yes | **Yes** | **CONFIRMED** | Sets latency timer to 4 ms. |
| `FT_SetUSBParameters` | Yes | **Yes** | **CONFIRMED** | Sets USB IN transfer size to 128 bytes, OUT to 0 (default). |

---

## 3. Call Sequences and Operational Lifecycle

### 3.1 Device Enumeration and Discovery
**Source**: `ISOFT.cs:497-550` (`ListUnopenDevices`), `ISOMain.cs:2985, 3015`, `ftdi-code.il:946-1128`.

1. TuneECU invokes `ISOFT.ListUnopenDevices(Flag)` with parameter `Flag = 1073741826u` (`0x40000002` = `FT_LIST_BY_INDEX | FT_OPEN_BY_DESCRIPTION`).
2. Calls `FT_ListDevices(&num2, NULL, 0x80000000u)` (`FT_LIST_NUMBER_ONLY`).
   - Retrieves the number of connected FTDI devices into `num2`.
3. For each index `i = 0` to `num2 - 1`:
   - Allocates a 64-byte buffer `byte[] array = new byte[64]`.
   - Calls `FT_ListDevices((uint)i, &array[0], 0x40000002u)` (`FT_LIST_BY_INDEX | FT_OPEN_BY_DESCRIPTION`).
   - Decodes ASCII string from `array` and populates the UI device list dropdown (`ISOMain.me.lbDevList.Items.Add(text)`).
4. `FT_CreateDeviceInfoList` is never called (**CONFIRMED**).

### 3.2 Channel Connection (`FTDOpen`)
**Source**: `ISOFT.cs:554-600` (`FTDOpen`), `ISOMain.cs:5067`, `ftdi-code.il:1132-1278`.

When the user connects (or automatic reconnection triggers) at default baud `10400u`:
1. If port already open (`m_hPort != 0`), calls `FTDClose(wait: false)`.
2. Computes flags: `num = dwListDescFlags & 0xDFFFFFFFu` (`0x40000002`).
3. If `num == 0`: calls `FT_Open(Index, &m_hPort)`.
4. If `num != 0`: decodes selected dropdown text into ASCII bytes and calls `FT_OpenEx(bytes, num, &m_hPort)`.
5. On `FT_OK`:
   - Sets `Terminate = false`.
   - Creates Win32 event: `hEvent = CreateEvent(IntPtr.Zero, bManualReset: false, bInitialState: false, "")`.
   - Sets event mask: `EventMask = 1u` (`FT_EVENT_RXCHAR`).
   - Calls `FT_SetEventNotification(m_hPort, EventMask, (void*)hEvent)`.
   - Starts reader background thread: `pThreadRead = new Thread(ThreadProc); pThreadRead.Start();`.
   - Calls `FT_SetDataCharacteristics(m_hPort, 8, 0, 0)`:
     - `uWordLength = 8` (`FT_BITS_8`)
     - `uStopBits = 0` (`FT_STOP_BITS_1`)
     - `uParity = 0` (`FT_PARITY_NONE`)
   - Calls `FT_SetFlowControl(m_hPort, 0, 17, 19)`:
     - `uFlowControl = 0` (`FT_FLOW_NONE`)
     - `uXon = 17` (`0x11`)
     - `uXoff = 19` (`0x13`)
   - Calls `FT_SetUSBParameters(m_hPort, 128u, 0u)`:
     - `dwInTransferSize = 128` bytes
     - `dwOutTransferSize = 0` (driver default)
   - Calls `FT_SetTimeouts(m_hPort, 150u, 150u)`:
     - `dwReadTimeout = 150` ms
     - `dwWriteTimeout = 150` ms
   - Calls `FT_SetLatencyTimer(m_hPort, 4)`:
     - `ucTimer = 4` ms
   - Calls `FTHiSpeed(baud, purge: true)`:
     - Calls `FT_SetBaudRate(m_hPort, baud)` (10400)
     - Calls `FT_Purge(m_hPort, 3u)` (`FT_PURGE_RX | FT_PURGE_TX`)

### 3.3 Channel Teardown (`FTDClose`)
**Source**: `ISOFT.cs:644-672` (`FTDClose`), `ftdi-code.il:1422-1490`.

1. Sets `Terminate = true`.
2. Signals event: `SetEvent(hEvent)`.
3. If `wait == true` and worker thread alive: `pThreadRead.Join(100)`.
4. Calls `FT_Close(m_hPort)`.
5. Closes Win32 event handle: `CloseHandle(hEvent)`.
6. Resets `m_hPort = 0`.

---

## 4. Read/Write Semantics and Echo Handling

TuneECU communicates over ISO 9141-2 / ISO 14230-4 K-Line interfaces where the physical bus is half-duplex (TX and RX tied together). Every byte transmitted onto K-Line is looped back into the FTDI receiver. TuneECU implements two distinct write modes to manage this bus reality:

### 4.1 Byte-by-Byte Transmission with Echo Verification (`line = false`)
**Source**: `ISOFT.cs:612-642` (`FTDWrite`), `ISOFT.cs:674-688` (`FTDWriteByte`), `ISOFT.cs:721-756` (`ThreadProc`).

Used for single-byte commands (e.g. `SendZero`, `SendInitA`), Walbro commands, and delicate handshakes:
1. `FTDWrite(msg, lr, echo, line=false)` initializes:
   - `wBuffer = msg; lnBuffer = msg.Length; pxBuffer = lnBuffer;`
   - Calls `FTDWriteByte()`.
2. `FTDWriteByte()`:
   - Takes current byte: `wByte[0] = wBuffer[lnBuffer - pxBuffer]`.
   - Calls `FT_Write(m_hPort, &wByte[0], 1u, &lpdwBytesWritten)`.
3. `ThreadProc` worker loop:
   - Calls `WaitForSingleObject(hEvent, 1024u)`.
   - When signaled by `FT_EVENT_RXCHAR`:
     - Calls `FT_GetStatus(m_hPort, &lpdwAmountInRxQueue, &lpdwAmountInTxQueue, &lpdwEventStatus)`.
     - If `lpdwAmountInRxQueue != 0`:
       - Calls `FT_Read(m_hPort, &rBuffer[rIndex], 1u, &lpdwBytesReturned)`.
       - **Echo Check**: Compares `rBuffer[rIndex] == wByte[0]`.
       - If matching: decrements `pxBuffer--`, advances `rIndex += lpdwBytesReturned`.
       - If not matching (bus contention, collision, or held low): aborts transmission by forcing `pxBuffer = 0`.
     - If `pxBuffer > 0`: calls `FTDWriteByte()` to send the next byte.

### 4.2 Block Transmission (`line = true`)
**Source**: `ISOFT.cs:621-628` (`FTDWrite`), `ISOFT.cs:689-720` (`FTDRead`).

Used for full ISO/KWP frames where fast transmission is desired (`SendInitK`, `SendIso` when `all=true`):
1. Calls `FT_Write(m_hPort, &wBuffer[0], (uint)wBuffer.Length, &lpdwBytesWritten)` in a single bulk operation.
2. Sets `pxBuffer = 0`.
3. `rLength` is initialized to `msg.Length` if `echo == true`, or expected response length if `echo == false`.

### 4.3 Periodic Polling and Frame Assembly (`FTDRead`)
**Source**: `ISOFT.cs:689-720` (`FTDRead`), `ISOFT.cs:873-1000` (`readTimer`), `ISOMain.cs:8463` (`cReadTimer.Interval = 10`).

TuneECU runs a Windows Forms Timer `cReadTimer` ticking every **10 ms**:
1. Checks `if (m_hPort == 0 || pxBuffer != 0) return;`.
2. Calls `FT_GetStatus(m_hPort, &num2, &lpdwAmountInTxQueue, &lpdwEventStatus)`.
3. If `num2 != 0`: calls `FT_Read(m_hPort, &rBuffer[rIndex], num2, &num)`.
4. Increments `rIndex += num`.
5. **Frame Length Auto-Detection** (when `rLength < 0`):
   - KWP format (`(rBuffer[rStart] & 0x7F) == 0`): length is at index 3 -> `rLength = rBuffer[rStart + 3] + 5` (Format + Target + Source + LenByte + Data[N] + Checksum).
   - ISO 9141 format (`(rBuffer[rStart] & 0x7F) != 0`): length embedded in format byte -> `rLength = (rBuffer[rStart] & 0x7F) + 4` (Format + Target + Source + Data[N] + Checksum).
6. **Echo Discarding**:
   - When `rIndex >= rStart + rLength`: calls `ISORead.ReadData(rBuffer, rStart, rLength, eEcho)`.
   - If `eEcho == true`: `ReadData` discards the frame immediately (`if (echo) return;`).
   - `FTDRead` advances `rStart = rLength`, clears `eEcho = false`, and sets `rLength = wLength` (awaits the real ECU reply).
   - When the actual reply arrives: `ReadData` processes the payload, and `FTDRead` resets `rIndex = 0; flagOut = 0; rFlag = 0;`.

---

## 5. ECU Initialization and Probing Mechanisms

TuneECU does not use hard-coded vehicle models. In `MODE_NULL`, it alternates between two initialization strategies until an ECU responds:

### 5.1 KWP2000 Fast Initialization (`ISORead.KWPInit`)
**Source**: `ISORead.cs:3523-3539` (`KWPInit`), `ISORead.cs:1020-1022` (`SendZero`), `ISORead.cs:1028-1031` (`SendInitK`).

Participating D2XX calls and sequence:
1. `FTHiSpeed(360u, purge: false)` -> `FT_SetBaudRate(m_hPort, 360)`.
2. `SetBreak(0)` -> `FT_SetBreakOn(m_hPort)` (asserts K-Line LOW).
3. `Thread.Sleep(200)` (200 ms break).
4. `SetBreak(1)` -> `FT_SetBreakOff(m_hPort)` (releases K-Line HIGH).
5. `SendZero()` -> `FTDWrite(new byte[1] { 0 }, 1, echo: true, line: false)`:
   - Transmits `0x00` at 360 baud.
   - At 360 baud: 1 bit = 2.778 ms. Start bit (0) + 8 data bits (0) = 9 zero bits = **25.0 ms LOW pulse** (`TiniL`).
   - Stop bit (1) = 2.78 ms HIGH.
6. `Thread.Sleep(50)` (50 ms idle HIGH pause, `TiniH`).
7. `FTHiSpeed(10400u, purge: true)` -> `FT_SetBaudRate(m_hPort, 10400)`, `FT_Purge(m_hPort, 3u)`.
8. Switches to `MODE_INIT`.
9. In `MODE_INIT`, calls `SendInitK()`:
   - Transmits KWP `StartCommunication` request: `0x81` (Target `0xD5`, Source `0xF5`).
   - Sent via `SendIso(new byte[1] { 129 }, -1, Echo: true, all: true)`.
10. Awaits ECU positive response `0xC1 0xEA 0x8F ...`.

### 5.2 ISO 9141-2 / ISO 14230-4 5-Baud Initialization (`ISORead.Initialization`)
**Source**: `ISORead.cs:3600-3685` (`Initialization`), `ISORead.cs:1023-1027` (`SendInitA`), `ISOMain.cs:849, 872` (`pTiming`).

Participating D2XX calls and sequence:
1. Target address byte `c = 51` (`0x33`, OBD-II standard address) or `c = 213` (`0xD5`, Sagem / proprietary).
2. TuneECU **bit-bangs** the 5-baud UART word using `FT_SetBreakOn` and `FT_SetBreakOff`:
   ```csharp
   c = c * 4 + 1025; // Prepares 11 bits: stop(1), start(0), 8 data bits (LSB first), stop(1)
   for (int i = 0; i < 11; i++) {
       Thread.Sleep(ISOMain.pTiming); // Default 196 ms (~200 ms = 1 / 5 baud)
       byte b2 = (byte)(c & 1);
       if (b2 != b) {
           ISOFT.SetBreak(b2); // 0 -> FT_SetBreakOn, 1 -> FT_SetBreakOff
       }
       b = b2;
       c /= 2;
   }
   ```
3. Calls `ISOFT.FTDWrite(null, 3, echo: false, line: false)`:
   - Calls `FT_Purge(m_hPort, 3u)`.
   - Sets expected read length `rLength = 3`.
4. ECU responds with 3 synchronization bytes at 10400 baud:
   - `0x55` (Sync byte)
   - `KB1` (Key byte 1, e.g. `0x08` or `0xD9`)
   - `KB2` (Key byte 2, e.g. `0x08` or `0x8F`)
5. In `ReadData(MODE_NULL)`:
   - Computes inverted Key Byte 2: `Init = KB2 ^ 0xFF`.
   - Switches to `MODE_INIT`.
6. In `MODE_INIT`:
   - Calls `SendInitA()`: sends `Init` byte (`~KB2`) via `FTDWrite`.
7. ECU confirms handshake by returning inverted address byte `~0x33 = 0xCC` (204).
8. Switches to `MODE_SEED` to begin seed/key security handshake.

---

## 6. Baud Rate Transitions

TuneECU switches baud rates dynamically during operation using `ISOFT.FTHiSpeed`:

| Baud Rate | Purge Buffer | Caller / State | Purpose | Evidence |
|---|---|---|---|---|
| **10400** | Yes (`3u`) | `FTDOpen`, `readTimer`, disconnect recovery | Standard K-Line diagnostic speed | **CONFIRMED** |
| **360** | No (`false`) | `ISORead.KWPInit` | Wakeup pulse generation (`TiniL = 25 ms`) | **CONFIRMED** |
| **57600** | Yes (`3u`) | `ISORead.cs:3187` (`OBDReply`, code 129) | High-speed map download / programming | **CONFIRMED** |
| **62400** | Yes (`3u`) | `ISORead.cs:3209` (`OBDReply`, code 130) | High-speed map download / programming | **CONFIRMED** |
| **62500** | Yes (`3u`) | `ISORead.cs:3182` (`OBDReply`, code 74) | High-speed map download / programming | **CONFIRMED** |

---

## 7. Timing, Timeouts, and Latency Requirements

| Parameter | Value | Location / Usage | Contract Implication |
|---|---|---|---|
| **Read Timeout** | 150 ms | `FT_SetTimeouts` | Maximum wait inside `FT_Read` if insufficient bytes present. |
| **Write Timeout** | 150 ms | `FT_SetTimeouts` | Maximum wait inside `FT_Write`. |
| **Latency Timer** | 4 ms | `FT_SetLatencyTimer` | FTDI USB buffering latency. Must be low (<= 4 ms) to avoid delaying echo detection. |
| **USB InTransferSize** | 128 bytes | `FT_SetUSBParameters` | FTDI USB packet chunk size. |
| **UI Polling Interval** | 10 ms | `cReadTimer.Interval` | Frequency at which `FTDRead` polls `FT_GetStatus` and drains incoming data. |
| **LONG_TIMEOUT** | 6000 ms | `ISOFT.cs:875` | Maximum duration in `MODE_NULL` before retrying ECU connection. |
| **SYNC_TIMEOUT** | 2500 ms | `ISOFT.cs:875` | Protocol synchronization timeout. |
| **Bit-Bang Timing** | 196 ms (range 180-219 ms) | `ISOMain.pTiming` | One bit period at 5 baud (1000 ms / 5 = 200 ms). Corresponds to `Thread.Sleep(196)`. |
| **Retry Counter** | 3 to 4 attempts | `ISORead.iRetry` | Number of init attempts before reporting connection error to user. |

---

## 8. Summary Checklist for OpenShimFTDI

To successfully host TuneECU without modifying application bytecode:
1. `FT_ListDevices` must return valid device counts and formatted description strings matching what TuneECU expects.
2. `FT_Open` and `FT_OpenEx` must succeed and yield a non-null handle.
3. `FT_SetEventNotification` must accept Win32 event handles and trigger them when data is available.
4. `FT_SetBreakOn` and `FT_SetBreakOff` must be supported or translated, as they are mandatory for both 5-baud init and KWP fast init.
5. `FT_SetBaudRate` must support 360, 10400, 57600, 62400, and 62500 baud.
6. `FT_Purge(3)` must clear RX and TX queues cleanly.
7. `FT_GetStatus` must accurately report `lpdwAmountInRxQueue`.
8. Echo handling is strictly mandatory: the application actively checks that written bytes appear in the receive stream.
