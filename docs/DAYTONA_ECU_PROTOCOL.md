# Daytona 675 Keihin ECU Protocol (Recovered from TuneECU 2.5.5)

## 1. Physical Layer & Initial Connection Discovery
TuneECU alternates between attempting a 5-baud Keihin initialization (`Initialization(51)`) and a KWP2000 Fast Initialization (`KWPInit()`). For the Keihin-equipped Triumph Daytona 675, TuneECU actually connects via **KWP Fast Initialisation**, masquerading as a KTM/KWP target in the internal `KWPReply` logic.

### KWP Fast Initialisation (The Primary Triumph Keihin Mode)
- **TuneECU State (eMode):** `MODE_NULL` moving to `MODE_INIT` via `KWPInit()` caller.
- **Request (Physical):** `360` baud, `FT_SetBreakOn` for 200ms `FT_SetBreakOff`, sends `0x00`.
- **Baud Rate Transition:** Switches to `10400` baud.
- **Request (Logical):** `0x81 0xD5 0xF5 0x81 <CS>` (Target `0xD5`, Source `0xF5`, payload `0x81` StartComm).
- **Target Address:** `0xD5` (213 decimal).
- **Expected ECU Response:** `0xC1 0xDA 0x8F <CS>`.
- **Response Parser Branch:** `KWPReply()` case `MODE_NULL` parses `193, 218, 143` (`0xC1, 0xDA, 0x8F`).
- **Success Next-State:** Sets `ISOMain.KWP = true`, `ISOFT.checkSagem = false`, `AM = 3` (if not flash mode), switches to `MODE_SEED`.
- **Timeout/Retry:** Timeout is ~150ms per `cReadTimer` ticks. Fails to `Initialization(51)` on mismatch.

## 2. Security Access / Seed-Key Auth
Upon receiving `0xC1 0xDA 0x8F`, TuneECU immediately queries for a Seed.

### Seed Request
- **State:** `MODE_SEED`
- **Request Construction:** `SendSeed()` inside `ISORead.cs`.
- **Payload:** `0x27 0x03` (because `AM = 3` was set due to normal read mode).
- **Expected Echo:** Yes (handled implicitly by FTDI).
- **Header:** `0x82 0xD5 0xF5 0x27 0x03 <CS>` (length 2 prefix `128+2=130/0x82`).
- **Expected ECU Response:** `0x67 0x03 <seed_hi> <seed_lo> <CS>`.
- **Parser Branch:** `KWPReply` case `103` (`0x67`).

### Key Calculation
- **Algorithm (CONFIRMED from `CalculateKey(seed)`):**
  - **Seed Width:** 16-bit unsigned (endianness: High byte first).
  - **Static Base Key (`KEY`):** `11123772655450801483` (`0x9A55C8F27A03754B`).
  - **Host extracts `KEYW`:** `(0x9A55C8F2 ^ 0x7A03754B) & 0xFFFF` = `53504` (`0xD100`).
  - **Diagnostic Mode Multiplier (`num`):** `40014` (`0x9C4E`).
  - **Flash/Write Mode Multiplier (`num`):** `48689` (`0xBE31`).
  - **Multiplier applied:** `KEYW ^ num` -> `0xD100 ^ 0x9C4E` = `28846` (`0x70AE`).
  - **Result Key:** `Key = (Seed * 28846) & 0xFFFF`.

### Key Send
- **Payload:** `0x27 0x04 <key_hi> <key_lo>`.
- **Expected ECU Response:** `0x67 0x04 <CS>` (Access Granted).
- **Next-State (Success):** Enters `KWPReply` case `103`, sub-branch `AM == 4`. It flags `ISOMain._KTM = true` (which enables extended memory reads), sets `bData = 8`, and transitions to `MODE_READ_DATA_BLOCK` via `SetReadMemory(24576, 32, -32)`.

---

## 3. ECU Identification (Map & Serial Poll)
After unlocking (where `mId` is initialised implicitly or still false), TuneECU triggers a hardcoded sequence of `ReadDataByLocalIdentifier` (`0x1A`) requests driven by the `bData` array index.

- **State:** `MODE_READ_DATA_BLOCK` -> `SendReadBlock(bData)`.
- **Query 1 (`bData=8`):** `0x1A 0x01`
  - **Response:** `0x5A 0x01 <17 bytes ASCII>`. This is the Vehicle Identification Number (VIN).
  - **Parser:** `KWPReply` case `90` (`0x5A`), subcase `1`. Stores full VIN and extracts the last 6 characters as ECU Serial. Transitions `bData=9`.
- **Query 2 (`bData=9`):** `0x1A 0x02`
  - **Response:** `0x5A 0x02 <14 hex bytes>`.
  - **Parser:** Subcase `2`. Calculates `ECUTyp` algorithmically from bit-shifting specific nibbles at offsets 0, 1, 2, 11, 12, 9 of the payload. Transitions `bData=10`.
- **Query 3 (`bData=10`):** `0x1A 0x05`
  - **Response:** `0x5A 0x05 <16 bytes ASCII>`. This contains the Map ID (e.g., "20417Map...").
  - **Parser:** Subcase `5`. Extracts purely the first 5 characters starting from payload offset 7 (byte 12 absolute) to populate `baseMap` (e.g., "20417"). Then prepares check-sum tracking vectors (`csMap`).
- **Subsequent Queries:** Queries `0x1A12` and `0x1A20` to acquire programming counts and hardware statuses. Once sequence terminates (`bData=13`), TuneECU flags `mId = true`, resets connection `newSession()`, runs KWPInit again, and cleanly drops into `MODE_READ_SENSORS` (since `mId` is now true).

---

## 4. Live Sensor Feeds (Keepalive)
- **TuneECU State:** `MODE_READ_SENSORS`
- **Request/Poll:** Dictated by the `cReadTimer` `Tick` event checking FTDI read buffers. TuneECU dispatches standard ReadDataByLocalIdentifer commands (like `0x21 <PID>`).
- **Retrieval:** If the queue is clear and it's time, `SendSensorQuery()` asks for `0x21` combined with the requested `dSensor`.
- **Expected ECU Response:** `0x61 <PID> <Data>`. Handled by `KWPReply` -> `case 97` (`0x61`).

---

## 5. Active and Stored DTC Diagnostics
- **Active Faults:** 
   TuneECU polls `0x18 0x00 0xFF 0x00` via `SendActiveCodeQuery()`.
   Response triggers `case 67` or `71` (`0x43` / `0x47` ReadDTCByStatus response). Handled in `CodesReceive`.
- **Clear DTCs:**
   TuneECU sends `0x14 0xFF 0x00` (ClearDiagnosticInformation) via `SendClearCodesQuery()`.
   Response triggers `case 68` (`0x44` Positive Response). Restores to `MODE_READ_SENSORS`.

---

## 6. Map Reading (ROM Download to Host)
- **Trigger:** User clicks Read Map, switching flow to `MODE_READ_MEM`.
- **Address Setup:** `SetReadMemory(addr, size, off)`. For Keihin KWP (`ISOMain._KTM == true`), standard chunk size (`ISOMain.sBloc`) is strictly `128` bytes per query (`0x80`).
- **Request Command:** `SendReadData()`
- **Payload Bytes:** `0x23 <HighAddr> <MidAddr> <LowAddr> 0x80 0x00`. (`0x23` = ReadMemoryByAddress).
- **Expected Response:** `0x63 <128 bytes of data>`.
- **Parser Branch:** `KWPReply` case `99` (`0x63`). Array-copies the 128 bytes into `IMap.memoMap` block-by-block. 
- **Address Progression:** Controlled by `IMap.ReadNextBloc()`, jumping over blank regions (`0x00000-0x05FFF` and the padding regions between `0x3ADE0-0x4FFF0`). See Hex Image Mapping.
- **End:** Transits to `MODE_DOWNLOAD_EXIT` sending `0x82` / `SendTransfertExit()`.

---

## 7. Map Writing (Host to ROM Flash)
Map writing is definitively separated from standard reads via the `mFlash = true` state marker.
- **Session Entry & Unlock:** Requires security level `AM = 5`. The Seed multiplier becomes `28846`? No! Since `mFlash = true`, `num = 48689`. Resulting Multiplier: `6777` (`0x1A79`). Request: `0x27 0x05`. Key Response: `0x27 0x06`. 
- **Start Routine / Erase:**
  TuneECU sends `0x31 0x90 0x00` via `SendStartDiag()`. (Starts erase routine).
- **Request Download:**
  TuneECU sends `0x34` via `SendRequestTransfert()`. Wait time ~300ms.
- **Transfer Data:**
  Chunk transmission sizes scale based on Keihin (`_KTM`) limits. Sends `0x36 <BlockNum> <Data...>`.
  Expected Response is `0x76` (TransferData Positive Response).
- **End Session:**
  `SendValidFlash()` completes session (`ISOFT.SetMessage(END_PROG)`).
