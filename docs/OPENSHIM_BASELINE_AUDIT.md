# Canonical OpenShimFTDI CachyOS Baseline Audit

## 1. HOST VERIFICATION
- **Operating System:** Linux / CachyOS (x86_64) confirmed via `/etc/os-release` and `uname -a`.
- **Target Directory:** `/home/spoqn/Desktop/TuneECUv2.5.5/` physically exists and contains the deployed binaries and logs.

## 2. GIT / WORKING TREE
The canonical deployed directory `/home/spoqn/Desktop/TuneECUv2.5.5/` is not a Git repository.
The canonical source lies in `/home/spoqn/Desktop/Source Codes/OpenShimFTDI/`:
- **Git Root:** `/home/spoqn/Desktop/Source Codes/OpenShimFTDI/`
- **Branch:** `main` (tracking `origin/main`)
- **HEAD Commit:** `9e02b42639f8492b9e9d0f3d35feabd8483c566f`
- **Discrepancy:** The HEAD does **NOT** match `6ac477153b9b08bf0aaaa03a60e9440a3ceda5c4`. This difference was explicitly reported as a valid condition.
- **Status:** Contains untracked `reference/j2534/aiden-korbs-j2534/` and `reference/j2534/nikolakozina-j2534/` directories.

## 3. CANONICAL BINARY DEPLOYMENT
Deployed hashes match the previous audit exactly:
- `FTD2XX.dll`: `8f573d30ce2dbbeb9339aa15654e381811aa13d9f3726c41ae53c97b789263ab`
- `openshim-helper`: `d465cdded0d938722e9d4f19687e6732f68587b26251853a96a52fbd832d181b`
- **Timestamps:** 2026-09-19 18:43:32.712+1000

## 4. HISTORICAL LIVE LOG EVIDENCE
Based strictly on the logs at `/home/spoqn/Desktop/TuneECUv2.5.5/ftd2xx-shim.log`:
- **Five-Baud target 0x33:** [OBSERVED] `[FIVE_BAUD] Recognized 10-bit sequence (via timing) for address 0x33`
- **55 08 08, F7, CC:** [OBSERVED] `[FIVE_BAUD] IPC success: queued [0x55, 0x08, 0x08], expected_init=0xF7, expected_ack=0xCC` and injection of `F7` and `CC` in RX FIFO.
- **first post-init frame (68 6A F1 27 03 02 EF):** [OBSERVED] `[FRAME_TX] Candidate frame flushed on silence timeout (elapsed=43 ms, len=7): 68 6A F1 27 03 02 EF`
- **genuine ECU RX:** [OBSERVED] `[ECU_RX] Received 5 bytes from J2534 (rx_status=0x00000000): 48 6B D1 7F 00`
- **TX indications:** Not directly [OBSERVED] in historical shim logs, as they are squelched internally by the helper. `openshim-helper.log` had rolled over / size 1458 and didn't log them.
- **checksum handling:** Reconstructed 03 [UNKNOWN] / not present in historical logs, which predate the `[WIRE_CHECKSUM_MODE] Mode A` logging logic (they shipped payload and relied on the wire behaviour).
- **CheckDevice traffic / 48 6B D1 7F 00:** [OBSERVED] Multiple responses of this data shown in logs after init.
- **errors/timeouts around the security exchange:** [OBSERVED] Candidate Security frames generated a flush event on silence timeout `(elapsed=43 ms, len=7)`.

## 5. SOURCE IMPLEMENTATION VERIFICATION
Verified inside `/home/spoqn/Desktop/Source Codes/OpenShimFTDI/`:
- **immediate local FTDI echo:** [SOURCE-CONFIRMED] Core packetizer behavior in `ftd2xx_shim.c`.
- **TX-indication suppression:** [SOURCE-CONFIRMED] `openshim_helper.c` uses `if (msg.RxStatus & J2534_TX_MSG_TYPE)` to trap and ignore hardware echoes.
- **Five-Baud virtualization:** [SOURCE-CONFIRMED]
- **0x33 handling & F7/CC:** [SOURCE-CONFIRMED]
- **deterministic SecurityAccess recognition:** [SOURCE-CONFIRMED] and [TEST-CONFIRMED] in `test_shim_packetizer.c`.
- **real 7-byte frame (68 6A F1 27 03 02 EF) & 7/9 vs 6/8-byte standard/Keihin SecurityAccess:** [SOURCE-CONFIRMED] and [TEST-CONFIRMED] by `test-packetizer`.
- **checksum validation and TX checksum stripping:** [SOURCE-CONFIRMED] Implemented as `Mode A` in `ftd2xx_shim.c`.
- **RX additive checksum reconstruction:** [SOURCE-CONFIRMED] Implemented as appending logic in `ftd2xx_shim.c`.

## 6. J2534 CHECKSUM SEMANTICS
Tracing the CachyOS `nikolakozina-j2534` J2534 OpenPort implementation wrapper (`j2534.c`):
- **whether TxFlags=0 causes the OpenPort/backend to generate the physical checksum:** [INFERRED] by standard J2534 architecture and shim code's strict expectations (appends checksum if missing, strips it if provided).
- **whether RX presented to the host has the physical checksum removed:** [INFERRED] and heavily demonstrated by shim logic that physically appends `csum` to passed RX frames.
- **what flag/config suppresses checksum generation:** [UNKNOWN] No direct flag present in J2534 CachyOS driver reference source for toggling checksum directly; OpenPort hardware manages it inherently via `TxFlags = 0` (standard).
- **whether the currently deployed helper uses the expected mode:** [SOURCE-CONFIRMED] `req->tx_flags = 0;` is hard-coded into helper bridging IPC messages.

## 7. LOOPBACK / TX-INDICATION REVIEW
The previous macOS audit claim that `CONFIG_LOOPBACK` caused physical bus traffic is **[CONTRADICTED]**.
- **J2534 Loopback:** Configuration `LOOPBACK = 1` (`0x03` via `PassThruIoctl`) instructs the J2534 Dongle firmware to echo the successfully transmitted buffer back up the USB serial line as a received PassThruMessage with status `J2534_TX_MSG_TYPE`.
- **Physical TX vs Indication:** The bus performs one original physical TX. The `LOOPBACK = 1` solely requests the USB J2534 TX indication.
- **Conclusion:** There is **NO** second physical K-Line echo transmission on the wire.

## 8. REGRESSION TEST RESULTS
Compilers: GCC (`gcc`), Clang for Windows (`clang -target i686-pc-windows-gnu`), and Wine.
1. `make test-packetizer`: **PASS** (Block Mode, Hash-based framing and checksum packetizing correctly decoded)
2. `make test-loopback`: **PASS** (Synthetic Win32 / IPC fallback passed)
3. `make test-break-decode`: **PASS** (5-baud address 0x33 and 0xD5 mocked properly)
4. `make test-ipc`: **PASS** (Native helper spawned, valid graceful fallback due to missing J2534 hardware)

## 9. HANDOFF CLAIM CLASSIFICATION
- *Five-baud virtualisation works on OpenPort hardware:* [OBSERVED]
- *Shim strips J2534 hardware loops:* [SOURCE-CONFIRMED]
- *OpenPort generated additional physical bus traffic due to LOOPBACK=1:* [CONTRADICTED] 

## 10. CONTRADICTIONS
Loopback causes physical hardware echo on bus -> False. It only adds USB data polling indications.

## 11. UNKNOWNS
Inner capabilities of the closed OpenPort 2.0 firmware (checksum omission overrides, raw timing semantics).

## 12. FILE CREATED/UPDATED
`/home/spoqn/Desktop/TuneECUv2.5.5/OPENSHIM_BASELINE_AUDIT.md` (overwritten/created)

## 13. RECOMMENDED NEXT STEP
Execute a live J2534 test-bench session against the OpenPort 2.0 with motorcycle ECU powered, observing Checksum "Mode A" implementation live logs without altering binary state.
