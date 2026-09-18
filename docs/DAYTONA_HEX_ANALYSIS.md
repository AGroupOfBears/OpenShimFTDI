# Daytona 20417Map.hex Analysis

## File Identity
- **File path**: `/home/spoqn/Desktop/Source Codes/OpenECU/Deps/20417Map.hex`
- **Total file size**: 254,961 bytes
- **Format**: TuneECU Proprietary Encrypted Bin (.hex extension is a misnomer; it is not an Intel HEX file)
- **Map Identifier/Header**: `0x04176AA3` (decimal: `68643491`) internally mapped to ID `20417`.
- **ASCII Header Strings**: "Daytona 675 up to VIN 294377", "Arrow complete system", "Fuel up to E10", "Minimum 95 RON (89 RON/MON) fuel"

## Decoding format
The file is encoded with a simple XOR stream cipher where `decoded_byte = raw_byte ^ prev_raw_byte ^ key_byte` (with a rotating 4-byte key based on `0x18041367 | 0x80808080`).

## Address Ranges / Regions
The `.hex` maps exactly 8 distinct memory blocks into the ECU address space:
1. `0x06000` - `0x3ADE0` (Size: `0x34DE0` / 216,544 bytes) - **Main Executable / Firmware Region**
2. `0x4FFF0` - `0x50010` (Size: `0x20` / 32 bytes)
3. `0x50000` - `0x50920` (Size: `0x920` / 2,336 bytes) - **Calibration / Tables**
4. `0x51000` - `0x51160` (Size: `0x160` / 352 bytes) - **Calibration / Tables**
5. `0x52000` - `0x526A0` (Size: `0x6A0` / 1,696 bytes) - **Calibration / Tables**
6. `0x53000` - `0x53600` (Size: `0x600` / 1,536 bytes) - **Calibration / Tables**
7. `0x55000` - `0x5CDE0` (Size: `0x7DE0` / 32,224 bytes) - **Calibration / Tables**
8. `0x5FFF0` - `0x60010` (Size: `0x20` / 32 bytes) - **Map Header/Checksum Region**

## Gaps & Image Completeness
- **Not a Complete ROM**: The address space `0x00000` to `0x05FFF` (24 KB) is completely excluded, confirming the bootloader region is omitted.
- Extensive memory gaps exist between `0x3ADE0` and `0x4FFF0`, as well as sparse population in the `0x5xxxx` region. 
- It contains both calibration data and the main executable ECU firmware.

## Verification Checksums
- Signature/checksum blocks exist in the `0x4FFF0` and `0x5FFF0` mini-blocks (32 bytes each), typical for Keihin checksum blocks delineating major region structures.
