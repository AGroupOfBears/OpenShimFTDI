# Daytona 675 Parameter Analysis (Map 20417)

## TASK 1 — paramIndex RUNTIME STATE
* **CONFIRMED**: `ISOMain.cs` processes `prmIndex` in 4-bit nibbles starting from the LSB. For Map 20417, `TypTable = 40` (from `mType` signature `0x04176AA3`), providing `prmIndex = 0xFF3210`.
* **CONFIRMED**: The nibble-to-UI array is:
  - Nibble 0 (`0`): `paramIndex[0]` -> Rev Limit (Label 46)
  - Nibble 1 (`1`): `paramIndex[1]` -> Thermo Fan
  - Nibble 2 (`2`): `paramIndex[2]` -> Speed Adjust
* **CONFIRMED**: In `IMap.cs:SetKeihinTable(tm, cMap)` (line 1143), `paramIndex[1..15]` are initialized to `65535` (`0xFFFF`).
* **CONFIRMED**: `paramIndex[0]` is assigned via: `(memoMap[num3 + mapTable[1]] << 8) | memoMap[num3 + mapTable[1] + 1]`.
* **CONFIRMED**: `paramIndex[1]` is assigned via: `((memoMap[num3 + mapTable[6]] << 8) | memoMap[num3 + mapTable[6] + 1]) / 10`.
* **OBSERVED**: `paramIndex[2]` (Speed Adjust) evaluates `mapTable[3]`. Since `mapTable[3] == 0` for this definition, `paramIndex[2]` is bypassed and retains `65535` (`0xFFFF`).
* **CONFIRMED**: When `displayParams` renders `65535`, it casts it to `(short)-1`. The UI tags this as `-34`, effectively hiding unused nodes (like Speed Adjust and all unused upper nibbles `F`).

## TASK 2 — EXACT ADDRESS DETERMINATION
* **OBSERVED**: `MakeMemoryMap` copies `.hex` regions into `memoMap` via `addrTable` mapped from `Tune.eBloc`. For Map 20417, regions include `0x50000` to `0x5CDE0`.
* **OBSERVED**: `SetKeihinTable` calculates the offset base `num3 = (mapTable[0] & 0xF0) << 12`. With `mapTable[0] = 0x5590`, dotPeek outputs `num3 = 0x90000`.
* **INFERRED**: Given the Hex loads into `0x50000`, calculating `num3 = 0x90000` addresses uninitialized `memoMap` zones. This indicates either a decompilation flaw (where `0x5590` intended to map to `0x50000`, e.g., `(mapTable[0] & 0xF000) << 4`), or an undocumented region shifting logic later in the pipeline.
* **INFERRED**: Assuming the intended absolute ECU Base is `0x50000`:
  - **Rev Limit offset**: `mapTable[1] = 0x5A90`. Absolute address: `0x55A90`.
  - **Thermo Fan offset**: `mapTable[6] = 0x91D0`. Absolute address: `0x591D0`.
* **OBSERVED**: Raw bytes in decrypted stock `20417Map.hex` at these exact addresses:
  - `0x55A90`: `B6 05`
  - `0x591D0`: `E6 01` (followed by `E4 01`, `DD 01`, etc. suggesting a 1D curve, not a scalar limit).
* **UNKNOWN**: Extracting `(B6 << 8) | 05` yields `46597`, which differs greatly from a tangible Rev Limit (e.g. `14500`). The Keihin parameter rendering might leverage UI translation tables NOT used for Sagem.

## TASK 3 — VERIFY REV LIMIT BOUNDS
* **CONFIRMED**: For Keihin (`SetKeihinTable`), the UI utilizes the explicit value in `paramIndex[0]`.
* **OBSERVED**: `paramIndex[7] = GetRpmMax(num3, num2)` is populated, returning `mapTable[2]` (`0x5FA0`) for `TypTable < 80`. However, the Tree UI bounds the parameter display independently; trace confirms Tree node 0 explicitly links to `paramIndex[0]`. Max limits are hardcoded by the editor increment boundaries in `ISORead.csMap`.

## TASK 4 — THERMO FAN SCALING
* **CONFIRMED**: Formula for `TypTable=40` (Keihin) is `((raw_high << 8) | raw_low) / 10`.
* **OBSERVED**: This radically diverges from the `(raw - 50) * 0.8` formula utilized in `SetSagemTable`.
* **CONFIRMED**: Decoding `0x01E6` using the Keihin formula yields `48.6°C`. Decoding `0xE601` (Big-Endian raw evaluation per TuneECU) yields `5888.1°C`.
* **UNKNOWN**: Neither output corresponds to expected Fan trigger boundaries (`~103°C`). We conclude the `0x91D0` offset likely points to a multi-point table base, requiring interpolation contrary to TuneECU's simple division logic.

## TASK 5 — SPEED ADJUST VISIBILITY
* **CONFIRMED**: Speed Adjust is categorically absent because `mapTable[3] = 0`, forcing `paramIndex[2]` to remain `0xFFFF`, flagging it hidden in the UI dynamically.

## TASK 6 — I IDLE (N)
* **CONFIRMED**: `Tune.tvMap_Define` explicitly sets `tagNode[6] = ((Typ != 7) ? 1 : -1)`. For instances routing through `case 40:` (the correct internal Keihin logic), it utilizes `tagNode[6] = 1` for `L3` load mapping. 
* **INFERRED**: Neutral idle ignition timing (`I Idle (N)`) is deactivated based exclusively on `Typ` enumeration flags, indicating no associated calibration region mapping exists in the definitions layout. Mechanical reasoning acts independently of the logic boundary: Reason for disabling this node is UNKNOWN.
