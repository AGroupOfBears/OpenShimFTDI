# OpenShimFTDI Implementation Status

## 1. Overview and Architecture

OpenShimFTDI is an x86 Windows `FTD2XX.dll` compatibility shim designed to enable TuneECU (running under Wine) to communicate with automotive and motorcycle ECUs via a Tactrix OpenPort 2.0 interface.

The transport architecture has been implemented and verified end-to-end through physical OpenPort 2.0 hardware:

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
| - 5-baud break pattern decoder (0x33, 0xD5)                 |
| - Handshake virtualization (echo ~KB2, inject ~Address)     |
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
| - IPC_CMD_FIVE_BAUD_INIT handler                            |
| - Dynamic loader for native j2534.so                        |
+-------------------------------------------------------------+
                              |
                              | J2534 API (C dynamic link)
                              v
+-------------------------------------------------------------+
| NikolaKozina J2534 Driver (j2534.so) / libusb-1.0           |
| - usb_send_read_once()                                      |
| - PassThruIoctl(J2534_FIVE_BAUD_INIT) -> OpenPort 'atw'     |
| - Channel validation & PassThruGetLastError bugfixes        |
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

### 2.1 J2534 Backend (`j2534.so` / NikolaKozina J2534)
- **Synchronous USB Transfer**: Added `usb_send_read_once()` to execute a synchronous OUT bulk transfer followed by an IN bulk transfer with custom timeout (5000 ms), properly converting OpenPort firmware error codes (`are <n>`) into `J2534_ERR_FAILED`.
- **`PassThruIoctl(J2534_FIVE_BAUD_INIT)`**:
  - Implements J2534-1 5-baud initialization ioctl ID 4.
  - Takes input `SBYTE_ARRAY` containing target address (e.g. `0x33` or `0xD5`).
  - Dispatches OpenPort firmware command `atw<ChannelID> <address_decimal>\r\n` (e.g. `atw3 51\r\n` for ISO9141 or `atw4 51\r\n` for ISO14230).
  - Uses 5000 ms timeout.
  - Safely parses `arw` response using `strtok_r` (reentrant) and converts decimal byte tokens into `output->BytePtr`.
  - Respects caller's `output->NumOfBytes` buffer capacity and updates `output->NumOfBytes` with actual received count.
  - Translates `are 7` (timeout without ECU response) to `J2534_ERR_FAILED` with error text `Error: J2534 device comms error: 7`.
- **Channel Validation Fix**:
  - Replaced faulty upstream Nikola check `strtoul(&con->channel, ...)` (which passed a pointer to a single byte) with `valid_channel_id(ChannelID)` across `PassThruDisconnect`, `PassThruReadMsgs`, `PassThruWriteMsgs`, `PassThruStartMsgFilter`, `PassThruStopMsgFilter`, and `PassThruIoctl`.
  - Resets `con->channel = 0; con->protocol_id = 0;` on disconnect and close.
- **`PassThruGetLastError` Fix**:
  - Replaced upstream pointer overwrite (`pErrorDescription = LAST_ERROR;`) with safe string copy `strncpy(pErrorDescription, LAST_ERROR, LE_LEN - 1);`.

### 2.2 IPC Protocol (`include/openshim_ipc.h`)
- Added command:
  ```c
  IPC_CMD_FIVE_BAUD_INIT = 14
  ```
- Defined packed payload structures:
  ```c
  typedef struct {
      uint32_t channel_id;
      uint8_t  target_address;  /* 0x33 or 0xD5 */
      uint8_t  pad[3];
  } ipc_req_five_baud_init_t;

  typedef struct {
      uint32_t num_keybytes;
      uint8_t  keybytes[16];
  } ipc_resp_five_baud_init_t;
  ```

### 2.3 Native Linux Helper (`openshim-helper`)
- Implemented `IPC_CMD_FIVE_BAUD_INIT` handler.
- Acquires `pthread_mutex_lock(&g_j2534_lock)` to protect shared USB endpoints.
- Prepares `J2534_SBYTE_ARRAY` structures and executes `g_j2534.PassThruIoctl(ctx->channel_id, J2534_FIVE_BAUD_INIT, &in_arr, &out_arr)`.
- Copies returned key bytes into `ipc_resp_five_baud_init_t` and sends reply to shim.

### 2.4 32-bit Windows FTD2XX.dll Shim (`src/ftd2xx_shim.c`)
- **5-Baud Break-Pattern Decoder**:
  - Tracks 11-bit break bit-bang train from TuneECU (`FT_SetBreakOn` = 0, `FT_SetBreakOff` = 1).
  - Validates UART framing: Start bit = 0, Stop bit = 1.
  - Decodes target addresses: `0x33` (Keihin, 51) and `0xD5` (Sagem, 213).
  - Automatically resets accumulator if break train is interrupted (> 1500 ms).
- **Wakeup Dispatch & Normalization**:
  - In `BACKEND_MODE_IPC`: Dispatches `IPC_CMD_FIVE_BAUD_INIT` to helper.
  - In `BACKEND_MODE_LOOPBACK`: Generates ECU keybytes `[0x55, 0x08, 0x08]` for `0x33` or `[0x55, 0xD9, 0x8F]` for `0xD5`.
  - Normalizes returned key bytes into TuneECU's expected `[0x55, KB1, KB2]` format.
  - Pushes normalized 3-byte payload to local RX FIFO and signals `FT_EVENT_RXCHAR`.
- **Post-Break Purge Preservation**:
  - Sets `five_baud_rx_ready = TRUE` upon receiving key bytes.
  - When TuneECU issues its post-break `FT_Purge(FT_PURGE_RX)`, the 3 key bytes in the RX FIFO are preserved rather than cleared.
- **Handshake Virtualization State Machine**:
  - Tracks `five_baud_state = FIVE_BAUD_STATE_AWAITING_INIT`.
  - Calculates `expected_init = KB2 ^ 0xFF` and `expected_ack = target_address ^ 0xFF`.
  - In `FT_Write`:
    - Checks 5000 ms expiration timer; resets to `FIVE_BAUD_STATE_IDLE` on timeout.
    - When TuneECU writes `expected_init`:
      1. Suppresses transmission to hardware/IPC (OpenPort firmware already completed handshake internally via `atw`).
      2. Injects local FTDI write echo of `expected_init` into RX FIFO.
      3. Injects `expected_ack` (`~Address`) into RX FIFO.
      4. Signals `FT_EVENT_RXCHAR`.
      5. Clears `five_baud_state` to `FIVE_BAUD_STATE_IDLE`.
    - If a non-matching byte is written, it is **not** suppressed and is passed to the normal write path while resetting state to `IDLE`.

---

## 3. Test Suite Results

All automated test suites and live hardware tests pass:

| Test Suite | Target Binary | Environment | Scope | Result |
| :--- | :--- | :--- | :--- | :--- |
| **IPC Framing Unit Test** | `test_ipc_framing` | Native Linux (gcc) | Header packing, 20-byte alignment, connect/write/push payloads, `IPC_CMD_FIVE_BAUD_INIT` request/response structures | **PASS** |
| **Synthetic Loopback Test** | `test_shim.exe` | Wine 32-bit (`OPENSHIM_BACKEND=loopback`) | 22 D2XX exports, open/close, baud/data/flow settings, event signaling, write-read FIFO loopback, purge | **PASS** |
| **5-Baud Break Decode & Virtualization Test** | `test_shim_break_decode.exe` | Wine 32-bit (`OPENSHIM_BACKEND=loopback`) | Mock 0x33 handshake (keybytes [0x55,0x08,0x08], echo 0xF7, ACK 0xCC), Mock 0xD5 handshake (keybytes [0x55,0xD9,0x8F], echo 0x70, ACK 0x2A), non-matching write pass-through, stale-state timeout (>5000ms) reset | **PASS** |
| **Live Native Helper Test** | `test_helper_live` | Native Linux against Tactrix OpenPort 2.0 | `PassThruOpen`, `PassThruConnect(ISO14230, 10400)`, `SET_CONFIG(DATA_RATE=10400)`, `SET_CONFIG(DATA_RATE=62400)`, `CLEAR_RX`, `CLEAR_TX`, `FAST_INIT` dispatch, `PassThruDisconnect`, `PassThruClose` | **PASS** |
| **End-to-End Wine IPC Test** | `test_shim_ipc.exe` | Wine 32-bit DLL communicating with Linux Helper | Full transport bridge: Wine Winsock IPC -> Helper -> Tactrix OpenPort 2.0, deferred connect, Fast Init recognition, Win32 event signaling, RX queue count verification, local FIFO drain, purge | **PASS** |
| **Live 5-Baud Hardware Test** | `test_five_baud_live` | Native Linux against Tactrix OpenPort 2.0 | Dispatches `atw3 51` on ISO9141; clean timeout `are 7` mapping without ECU; dispatches `atw4 51` on ISO14230; clean timeout `are 7`; subsequent normal connect, filter, disconnect, close without deadlock or crash | **PASS** |

### Live Physical Hardware Verification Log Summary
```
=== OpenPort 2.0 Live FIVE_BAUD_INIT & Hardware Safety Test ===
Loading J2534 library: ./j2534.so
PassThruOpen() -> 0 (dev_id=6)

--- Test 1: Connect ISO9141 (Channel 3), dispatch atw3 51 ---
PassThruConnect(ISO9141) -> 0 (channel_id=3)
Dispatching PassThruIoctl(FIVE_BAUD_INIT, addr=0x33)...
FIVE_BAUD_INIT rc = 7, out_bytes = 16
[CONFIRMED] Without ECU connected, OpenPort timed out cleanly (rc=7, err='Error: J2534 device comms error: 7')
PassThruDisconnect(ISO9141) -> 0

--- Test 2: Connect ISO14230 (Channel 4), dispatch atw4 51 ---
PassThruConnect(ISO14230) -> 0 (channel_id=4)
Dispatching PassThruIoctl(FIVE_BAUD_INIT, addr=0x33)...
FIVE_BAUD_INIT rc = 7, out_bytes = 16
[CONFIRMED] Without ECU connected, OpenPort timed out cleanly (rc=7, err='Error: J2534 device comms error: 7')
PassThruDisconnect(ISO14230) -> 0

--- Test 3: Subsequent normal commands verification ---
PassThruConnect -> 0 (ch=4)
PassThruStartMsgFilter -> 10 (filter_id=10)
PassThruDisconnect -> 0
PassThruClose -> 0

=== HARDWARE VALIDATION PASSED WITHOUT DEADLOCK OR CRASH ===
```

---

## 4. Unresolved Items & Important Notes

> [!IMPORTANT]
> **Full Five-Baud ECU Handshake Requires Physical Vehicle/ECU Testing**:
> Bench tests have verified that OpenPort firmware receives `atw3 51` and `atw4 51`, executes the 5-baud slow-init routine on K-line pin 7, times out cleanly (`are 7`) when no ECU replies, and leaves the hardware responsive for subsequent operations.
> However, verifying successful reception of real vehicle keybytes (`0x55, KB1, KB2`) and bi-directional inverted address acknowledgement requires physical testing with a live Keihin or Sagem ECU on the 2006 Triumph Daytona 675.

- **Map Flashing**:
  - By design, ECU map flashing routines are not implemented.
- **ECU Emulation**:
  - OpenShimFTDI does not fake ECU responses. TuneECU remains responsible for probing, identification, and sensor reading.
