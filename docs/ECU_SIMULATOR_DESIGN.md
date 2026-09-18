# ECU Simulator Architecture for OpenShimFTDI

To facilitate regression testing, Fast Init configuration logic, and TuneECU connection integration without having a physical motorcycle or Tactrix device tied up on a bench, we introduce exhaustive simulation modes to OpenShimFTDI.

## 1. Supported Backend Modes (Task 7)

OpenShimFTDI's `openshim-helper` Linux daemon will support the following three mutually exclusive topology modes via the `OPENSHIM_BACKEND` configuration variable:

### A. Simulator (`OPENSHIM_BACKEND=simulator`)
* **Topology:** TuneECU -> OpenShimFTDI.dll -> helper -> (Internal Software ECU).
* **Requirements:** Absolutely no Tactrix OpenPort 2.0 or motorcycle. The `openshim-helper` operates entirely in RAM natively satisfying J2534 requests without passing them to `j2534.so`.
* **Behavior:** Intercepts `IPC_CMD_FAST_INIT` internally, reporting success. Mocks all byte RX/TX queues directly using the C-based Simulator State Machine block.

### B. Hardware (`OPENSHIM_BACKEND=hardware`)
* **Topology:** TuneECU -> OpenShimFTDI.dll -> helper -> `j2534.so` -> OpenPort 2.0 -> Physical ECU.
* **Requirements:** Requires the Tactrix hardware plugged in and connected to a functioning 2006+ Triumph Keihin OBD port.
* **Behavior:** Complete production passthrough. No spoofed data or state machines are engaged.

### C. Hardware-Sim (`OPENSHIM_BACKEND=hardware-sim`)
* **Topology:** TuneECU -> OpenShimFTDI.dll -> helper -> `j2534.so` -> OpenPort 2.0 -> (Nothing / Terminated).
* **Requirements:** A physical Tactrix OpenPort 2.0 is required via USB to prove underlying J2534 library compatibility (e.g. `PassThruOpen`, `PassThruConnect`, FTDI driver loading). No motorcycle required.
* **Behavior:** The `j2534.so` layer is fully exercised for configurations, baud-changes, filters, and line clears. Commands like `FIVE_BAUD_INIT` and `FAST_INIT` will be dispatched electrically allowing full software-driver coverage. **Crucially:** The internal Software ECU intercepts TX'd bytes going into `PassThruWriteMsgs` and pushes responsive ECU diagnostic payloads artificially back into the `openshim-helper` RX return path via a thread. No physical ECU K-line collision will occur as the line is effectively isolated.

---

## 2. Real-Time State Machine Construction (Mock ECU)

The software Keihin ECU Simulator will maintain a connection state machine executing within the `openshim-helper` polling loop.

### Phase 1: Boot & Authentication
- **On `IPC_CMD_FAST_INIT` (Target 0xD5):** Mark state as `ECU_AWAKE`. Queue `0xC1 0xDA 0x8F <CS>` into the return buffer for TuneECU.
- **On `0x27 0x03` (Read Mode Seed):** Expect Keihin/KWP format. Output `0x67 0x03 0xAA 0xBB`. State switches to `AWAITING_KWP_KEY_3`.
- **On `0x27 0x04`:** Test if transmitted key equals `0xAABB * 28846 & 0xFFFF`. If true, return `0x67 0x04` and transition to `ECU_UNLOCKED`.
- **On `0x27 0x05` (Flash Mode Seed):** Output `0x67 0x05 0xCC 0xDD`. Wait for key. Test vs `0xCCDD * 6777 & 0xFFFF`. Return `0x67 0x06`.

### Phase 2: Metadata Provision (`0x1A` routines)
- **`0x1A 0x01` (VIN/Serial):** Reply `0x5A 0x01` followed by "xxxxxxxxxxx294377".
- **`0x1A 0x02` (Hardware Typ):** Return `0x5A 0x02` formatted precisely to yield `ISOMain._LC4 == true`? No, just match Keihin IDs.
- **`0x1A 0x05` (Map Version):** Return `0x5A 0x05` with "xxxxxxx20417Map". Ensures TuneECU `mId` validates it as target format mapping.

---

## 3. Hex Image Address Matrix / Phase C (Map Reading)

The target binary file `20417Map.hex` is securely loaded on launch of `openshim-helper` (running locally). TuneECU generates KWP `0x23` `ReadMemoryByAddress` using specific boundaries determined dynamically inside `IMap.CheckMapID()`.

The Simulator utilizes the fully XOR-decoded `.hex` region indices sequentially. Since TuneECU asks for memory in strictly mapped 128-byte sectors, the Simulator returns it from these precise internal limits derived in Task 5:

| ECU Physical Address | Chunk Length | Content Representation / Offset Mapping in `decoded.bin` | Simulator Rule |
|---|---|---|---|
| `0x00000 -> 0x05FFF` | N/A | Ignored / Bootloader. | Send Negative Response (0x7F) or N/A. |
| `0x06000 -> 0x3ADE0` | 216,544 bytes | Embedded firmware logic. Decoded File offsets `0x5E -> 0x34E3E`. | Slices perfectly onto the payload stream on `0x23` reads. |
| `0x3ADE0 -> 0x4FFF0` | N/A | Unused Keihin address block. Gap intentionally skipped by TuneECU `ReadNextBloc`. | Do not process. |
| `0x4FFF0 -> 0x50010` | 32 bytes | Configuration / Signatures block. Found consecutively in file stream. | Direct Memory map extraction. |
| `0x50000 -> 0x50920` | 2,336 bytes | Fuel/Ignition calibration vectors. | Direct Memory map extraction. |
| `0x51000 -> 0x51160` | 352 bytes | Configuration table subsets. | Direct Memory map extraction. |
| `0x52000 -> 0x526A0` | 1,696 bytes | Sensor scaling / Map thresholds. | Direct Memory map extraction. |
| `0x53000 -> 0x53600` | 1,536 bytes | Extended calibrations. | Direct Memory map extraction. |
| `0x55000 -> 0x5CDE0` | 32,224 bytes | Large array maps/tuning breakpoints. | Direct Memory map extraction. |
| `0x5FFF0 -> 0x60010` | 32 bytes | File Hash Checksum region. Matches end of File stream. | Matches TuneECU checksum polling bounds. |

When `0x23 <Add_Hi> <Add_Md> <Add_Lo> 0x80` is intercepted:
1. Reconstruct absolute `int address_seek = Add_Hi << 16 | Add_Md << 8 | Add_Lo`.
2. Find corresponding file block mapping and boundaries.
3. Slice `128` bytes.
4. Reply `0x63 <128 bytes of data>` exactly as requested by TuneECU.
