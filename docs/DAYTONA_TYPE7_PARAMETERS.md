# Daytona 675 Parameter Analysis (Map 20417)

## Typ vs TypTable (Re-Confirmed)
* **CONFIRMED**: Map 20417's catalogue string (`"20417:7:Daytona 675..."`) does **not** specify `Typ = 7` for the UI map definition. 
* **CONFIRMED**: The catalogue `"7"` is parsed by `IMap.cs` as a wheel circumference index (`wRef`), resolving to `rWheel[7]`.
* **CONFIRMED**: The map definition type is fully established by the file signature `0x04176AA3`, resolving to `TypTable = 40` using `identifyMap`, which routes the application logic through `case 40:`.
* **CONFIRMED**: `I Idle (N)` is a Sagem exclusive parameter defined in Sagem branches (e.g., `case 7:`). Because Map 20417 processes via Keihin branch `case 40:`, node[6] is populated instead as `"L3"`. The earlier Sagem mechanic assumptions are irrelevant entirely to Map 20417.

## Speed Adjust Extraction Workflow

### UI / Display Mechanics
* **CONFIRMED**: The `TypTable=40` logic initializes `Tune.prmIndex` to `16724496` (`0xFF3210`), activating the first three parameter slots (`0`, `1`, `2`).
* **CONFIRMED**: Slot 2 corresponds to `paramIndex[2]` which maps to `LangUI[48]` ("Speed Adjust (%)").
* **CONFIRMED**: The Tree UI dynamically retrieves the bounds for item `2` through specific Keihin checks, providing bounded adjustments from `-60.0%` to `+20.0%` with increment steps of `0.1%`.
* **CONFIRMED**: Speed Adjust is undeniably **VISIBLE and EDITABLE** in both TuneECU v2.5.5 and v2.5.8.

### Formula Resolution (Display and Write)
* **CONFIRMED**: The parsing formula extracts the `wRef` reference character (`7`) and leverages the lookup table `rWheel`, where `rWheel[7] = 3724`.
* **CONFIRMED**: **Display Formula**: `paramIndex[2] = ((rWheel[wRef] * 1000) / RAW_INT) - 1000`. The UI subsequently renders `paramIndex[2] / 10.0` as the percentage string.
* **CONFIRMED**: **Write Formula**: `RAW_INT = (rWheel[wRef] * 1000) / (1000 + paramIndex[2])`.

## Absolute ECU Memory Mapping

* **CONFIRMED**: `MakeMemoryMap` allocates space starting explicitly at offset `0x50000`, built directly from the `mapTable[0]` derivation `(0x60050 & 0xF0) << 12`.
* **CONFIRMED**: Speed Adjust operates on `mapTable[3] = 13218` (`0x33A2`), resulting in absolute address `0x533A2`.

## Verified Parameters Matrix (Map 20417)

| Parameter | Visible? | Editable? | Absolute ECU Address | Width | Endian | Raw Stock Bytes | Stock Value | Display Formula | Write Formula | Min | Max |
|----------|----------|-----------|----------------------|-------|--------|-----------------|-------------|-----------------|---------------|-----|-----|
| Rev Limit | Yes | Yes | `0x5061C` | 16-bit | Big | `34 0D` (`13325`) | 13325 RPM | `RAW` | `RAW` | N/A | 14200 RPM |
| Thermo Fan | Yes | Yes | `0x5226E` | 16-bit | Big | `04 06` (`1030`) | 103.0 °C | `RAW / 10.0` | `RAW * 10` | N/A | N/A |
| Speed Adjust | Yes | Yes | `0x533A2` | 16-bit | Big | `0E 8C` (`3724`) | 0.0 % | `(rWheel[7] * 1000 / RAW) - 1000` | `rWheel[7] * 1000 / (1000 + value)` | -60.0% | +20.0% |

> [!NOTE]
> * `rWheel[7]` evaluates to exactly `3724`.
> * Re-verifying the raw Speed Adjust bytes (`3724`) backwards through the extraction formula cleanly guarantees a `0.0%` reading, perfectly mirroring expected Untouched Stock states.

> [!CAUTION]
> The Map 20417 parameter definition is sufficiently resolved for ECU simulator implementation.
