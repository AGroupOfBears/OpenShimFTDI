# Daytona 675 Parameter Analysis (Map 20417)

## Typ vs TypTable
* **CONFIRMED**: Map 20417's catalogue string (`"20417:7:Daytona 675..."`) does **not** specify `Typ = 7` for the UI map definition. 
* **CONFIRMED**: The catalogue field `"7"` is parsed by `IMap.cs` as a wheel circumference index (`wRef`).
* **CONFIRMED**: The map definition type is fully established by the file signature `0x04176AA3`, resolving to `TypTable = 40` using `identifyMap`.
* **CONFIRMED**: `tvMap_Define` receives `TypTable = 40` and routes application logic through `case 40:`.

## I Idle (N)
* **CONFIRMED**: Map 20417 uses `TypTable = 40`.
* **CONFIRMED**: `tvMap_Define` therefore executes `case 40:`.
* **CONFIRMED**: For `case 40:`, `node[6]` is `"L3"`.
* **CONFIRMED**: `tagNode[6] = 1`.
* **CONFIRMED**: The previous `case 7` `I Idle (N)` analysis does not apply to Map 20417.

## Speed Adjust Extraction Workflow

### UI / Display Mechanics
* **CONFIRMED**: The `TypTable=40` logic initializes `Tune.prmIndex` to `16724496` (`0xFF3210`), activating parameter slots (`0`, `1`, `2`).
* **CONFIRMED**: Slot 2 corresponds to `paramIndex[2]` which maps to `LangUI[48]` ("Speed Adjust (%)").
* **CONFIRMED**: The `paramIndex[2]` slot does not contain `-1` (65535), so it is successfully processed and rendered visible.
* **CONFIRMED**: The UI dynamically retrieves bounds for item `2` through specific Keihin bounding logic (`case 2:` for `TypTable >= 16`), providing adjustment brackets from `-600` to `200` internally, exposing editable `-60.0%` to `+20.0%` with increment steps of `0.1%`.
* **CONFIRMED**: IS SPEED ADJUST VISIBLE AND EDITABLE FOR MAP 20417? **YES.**

### Formula Resolution & Verification
* **CONFIRMED**: The catalogue string `20417:7:` initializes `wRef` to `7`. 
* **CONFIRMED**: `Tune.rWheel[7]` dynamically evaluates to the pre-compiled constant `3724`.
* **CONFIRMED**: `mapTable[3]` is `13218` (`0x33A2`). Evaluated against ECU base `0x50000`, the absolute ECU address is `0x533A2`.
* **CONFIRMED**: Storage width is 16-bit, unsigned, Big-Endian.
* **CONFIRMED**: The raw stock byte sequence at `0x533A2` is `0x0E 0x8C`, representing the integer `3724`.
* **CONFIRMED**: **Exact Display Formula**: `(((rWheel[7] * 1000) / RAW) - 1000) / 10.0`. Applying `RAW = 3724` computes `paramIndex[2] = 0`, generating the clean stock string `"0.0"`.
* **CONFIRMED**: **Exact Write Formula**: `(rWheel[7] * 1000) / (1000 + (UI_Value * 10))`.

## Verified Parameters Matrix (Map 20417)

| Parameter | Visible | Editable | Address | Width | Endian | Raw Stock | Stock Value | Display Formula | Write Formula | Min | Max |
|-----------|---------|----------|---------|-------|--------|-----------|-------------|-----------------|---------------|-----|-----|
| Rev Limit | Yes | Yes | `0x5061C` | 16-bit | Big | `34 0D` (`13325`) | 13325 RPM | `RAW` | `RAW` | N/A | 14200 RPM |
| Thermo Fan | Yes | Yes | `0x5226E` | 16-bit | Big | `04 06` (`1030`) | 103.0 °C | `RAW / 10.0` | `RAW * 10` | N/A | N/A |
| Speed Adjust | Yes | Yes | `0x533A2` | 16-bit | Big | `0E 8C` (`3724`) | 0.0 % | `(((rWheel[7] * 1000) / RAW) - 1000) / 10.0` | `(rWheel[7] * 1000) / (1000 + (UI_Val * 10))` | -60.0% | +20.0% |

Map 20417 parameter definition is sufficiently resolved for ECU simulator implementation.
