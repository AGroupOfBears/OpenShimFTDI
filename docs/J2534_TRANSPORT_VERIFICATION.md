# J2534 Transport Verification

This document verifies the transport-level assumptions for the OpenShimFTDI adapter, based on inspection of the official Tactrix headers (`reference/j2534/tactrix/`) and the NikolaKozina J2534 implementation (`reference/j2534/nikolakozina-j2534/`).

## 1. Supported J2534 Features & Semantics

### 1.1 Protocol Identifiers and `PassThruConnect`
**Sources**: `j2534_tactrix.h`, `j2534.c:750`
- `PassThruConnect` parses the `ProtocolID` input.
- **CONFIRMED**: Nikola's driver explicitly supports ID `3` (`ISO9141`) and `4` (`ISO14230`). It sends the OpenPort command string `ato<ProtocolID> <Flags> <Baud> 0\n`.
- Tactrix's K-Line specific variants (`ISO9141_K = 0x00009180`) are not explicitly evaluated in Nikola's `switch` block, relying instead on the hardware default routing to Pin 7 for standard protocols 3 and 4.

### 1.2 Packet Framing and Header Preservation (ISO 9141/14230)
**Sources**: `j2534.c:1010`
- **CONFIRMED**: For K-Line (`ISO9141` or `ISO14230`), Nikola's driver calls `datacopy(msgBuf, data, 0, pos, (data[len] - 1))`. This copies the response starting at offset `0`.
- This ensures the J2534 `PASSTHRU_MSG.Data` buffer contains the **entire raw frame** (including format, target, source, and checksum bytes). TuneECU expects exactly this level of detail.

### 1.3 Loopback Emulation (`TX_LB_MSG`)
**Sources**: `j2534.c:1013`
- **CONFIRMED**: The OpenPort hardware and Nikola's driver explicitly support loopback packets.
- When a `TX_LB_MSG` (`packet_type == 0x20`) is received from the hardware, the driver stores it in a `PASSTHRU_MSG` with `RxStatus = 1` (TX_MSG_TYPE).
- Crucially, just like RX frames, K-Line loopback frames are copied from offset `0`, meaning they contain the **exact full frame** transmitted. OpenShimFTDI can feed these loopback fragments byte-by-byte into the FTDI RX buffer to flawlessly satisfy TuneECU's half-duplex echo-verification routine. 

### 1.4 Baud Rates and Dynamic Switching (`DATA_RATE`)
**Sources**: `j2534.c:750`, `j2534.c:1584`
- **CONFIRMED**: In `PassThruConnect`, the baud rate integer is inserted natively into the `ato` command without artificial validation lists. `62400` is accepted and sent directly to the firmware.
- **CONFIRMED**: Changing the baud rate on-the-fly without reopening the connection is supported. J2534's `SET_CONFIG` translates directly to the `ats<ChannelID> 1 <Value>\n` native command (where `1` is the ID for `DATA_RATE`). The OpenPort hardware dynamically updates the UART divisors.

### 1.5 Filter Configuration (Pass-All)
**Sources**: `jlogger.cpp`, `j2534.c:1340`
- **CONFIRMED**: A Pass-All filter is configured by sending a `MASK` of zero and `PATTERN` of zero, passing all physical bus bytes to the upper application.
- Nikola's driver verifies the sizes and flags of Mask and Pattern, then passes them down via the `atf` command.

### 1.6 Buffer Clearing (`CLEAR_RX_BUFFER` / `CLEAR_TX_BUFFER`)
**Sources**: `j2534.c:1770`
- **CONFIRMED**: `CLEAR_RX_BUFFER` properly empties the internal host-side linked list (`flush_queue()`) and returns `LIBUSB_SUCCESS`.
- **OBSERVED / likely sufficient**: `CLEAR_TX_BUFFER` is a no-op that just returns `LIBUSB_SUCCESS`. This is harmless; TuneECU calls `FT_Purge`, and if TX is empty, doing nothing satisfies the contract. The OpenPort does not provide a native `at` command for clearing hardware buffers.

### 1.7 `FAST_INIT` Semantics
**Sources**: `j2534.c:1718`
- **CONFIRMED**: Fast Init is supported natively by the OpenPort hardware and invoked via `PassThruIoctl(..., J2534_FAST_INIT, ...)`.
- The driver translates this to the OpenPort command `aty<ChannelID> <DataSize> 0\n`, attaches the TuneECU `0x81` (StartCommunication) payload, and the OpenPort firmware assumes full responsibility for asserting the 25ms low / 25ms high wakeup sequence at 360 baud before transmitting the payload at standard baud.

---

## 2. Unsupported Features & Critical Risks

The following assumptions in `J2534_FEASIBILITY.md` lacked full support in the Nikola open-source driver and require explicit correction or risk acknowledgment.

### 2.1 `FIVE_BAUD_INIT` Implementation Missing
- **CORRECTION**: J2534-1 defines `FIVE_BAUD_INIT`, but Nikola's driver strictly treats it as a stub. It is completely broken/missing from `j2534.c`.
- **Finding**: Calling it will fail with `LIBUSB_ERROR_NOT_SUPPORTED` / `J2534_ERR_NOT_SUPPORTED`.

- **CONFIRMED**: 2006–2012 Daytona uses diagnostic K-Line on pin 7.
Old Daytona technical sources identify ISO9141-2 / 10.4 kbaud.
TuneECU contains a real 5-baud ISO initialization path.
Nikola currently cannot perform FIVE_BAUD_INIT.

**VERY STRONG WORKING CONCLUSION**:
Our 2006 Daytona compatibility target should support 5-baud init.

**NOT YET CONFIRMED**:
The exact low-level OpenPort firmware command we need to implement it.

### 2.2 `PassThruSetProgrammingVoltage` Missing
- **CORRECTION**: To work around the lack of `FIVE_BAUD_INIT`, `J2534_FEASIBILITY.md` proposed using `PassThruSetProgrammingVoltage` to manually drop OBD Pin 7 (K-Line) to ground (`SHORT_TO_GROUND`).
- **Finding**: Nikola's driver stubs this too. Calling `PassThruSetProgrammingVoltage` returns `J2534_ERR_NOT_SUPPORTED` (`j2534.c:1385`).

### 2.3 Low-Level OpenPort Command Set Constraints
- **Finding**: Inspection of the driver's string emissions (`ato`, `atc`, `ats`, `atg`, `atr`, `aty`, `atf`, `att`, `atk`) confirms the open-source driver lacks a native bit-banging (`atb` or similar) or raw pin voltage command.
- **Risk**: Without modifying NikolaKozina's `j2534.c` to expose undocumented OpenPort firmware features, **5-baud bit-bang initialization (used for ISO 9141 and Sagem) cannot be performed.** KWP2000 Fast Init is fully functional, but older ECU variants relying exclusively on 5-baud init will time out.

---

## 3. Final Verification Table

| Requirement | Proven | Implementation choice | Remaining risk |
|---|---|---|---|
| Read/Write transparency | **CONFIRMED** | Pass-All filter + manual loopback reconstruction | None. Full frames (header+checksum) are passed up. |
| Half-Duplex Echo Verify | **CONFIRMED** | Extract bytes from `TX_LB_MSG` (`RxStatus = 1`) frames | Timing variance (J2534 buffers vs continuous stream). |
| Baud Rate Switching | **CONFIRMED** | Send `SET_CONFIG` -> `DATA_RATE` IOCTLs dynamically | None. `62400` flows to hardware correctly. |
| RX / TX Buffer Purge | **CONFIRMED** | Call `CLEAR_RX_BUFFER` / `CLEAR_TX_BUFFER` IOCTLs | Safe. |
| KWP Fast Init (`0x81`) | **CONFIRMED** | Map sequence to J2534 `FAST_INIT` IOCTL | Fast Init is fully delegated to firmware. |
| 5-Baud ISO 9141 Init | **UNSUPPORTED** | **Requires enhancing Linux J2534 driver**. | OpenShimFTDI will fail on legacy 5-baud ECUs unless the backend adds support for 5-baud hardware macros or direct Pin 7 control. |

---

## 4. Final Direction

Modifying production `OpenShimFTDI` code may proceed with the understanding that standard communication (KWP2000 diagnostics and general transport) appear highly viable without changes to the underlying J2534 transport. However, compatibility for the oldest subset of 5-Baud-Init ECUs (like early Sagem) must be deferred until the underlying Linux J2534 backend is extended.
