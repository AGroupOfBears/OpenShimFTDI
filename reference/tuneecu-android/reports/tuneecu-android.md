# TuneECU Android ECU communication analysis

## Scope and status

This report covers only `Deps/TuneECU v5.5.64.apk`. This initial pass preserves and extracts the APK, separates first-party code from library code, identifies the communication components, records the adapter command profiles, and identifies the main state machines. It does not analyze licensing, payment, user authentication, or the Android user interface. It does not change the OpenECU Rust implementation.

The analysis uses these evidence labels:

- **CONFIRMED**: Constants, instructions, calls, or control flow directly show the result.
- **OBSERVED**: The binary contains the item, but its full purpose is not yet established.
- **INFERRED**: The result is a probable interpretation of related evidence.
- **UNKNOWN**: The current evidence is not sufficient.

Deep flashing, recovery, and security access analysis is outside this initial pass. The relevant states are present and are indexed here for the next pass.

## 1. APK metadata

| Item | Value | Evidence |
| --- | --- | --- |
| Input file | `Deps/TuneECU v5.5.64.apk` | CONFIRMED |
| Preserved copy | `reverse-engineering/tuneecu-android/raw/TuneECU v5.5.64.apk` | CONFIRMED |
| Size | 6,757,673 bytes | CONFIRMED |
| SHA-256 | `b3d95cfdcee5e8175009606e5c5c4e1cc264d42c5bb5750882afd6b68f6d62e3` | CONFIRMED |
| Android package | `com.tuneecu` | CONFIRMED |
| Version name | `5.5` | CONFIRMED |
| Version code | `5564` | CONFIRMED |
| Minimum SDK | 19 | CONFIRMED |
| Target SDK | 30 | CONFIRMED |
| Compile SDK | 32 | CONFIRMED |
| Signer | `CN=Alain Fontaine, C=FR` | CONFIRMED |
| Certificate SHA-256 | `7C:3E:FA:7F:BE:51:93:8E:66:39:C2:0E:D8:99:0B:62:2F:76:CC:9C:F6:46:1F:39:4B:0A:25:97:AB:2D:A5:6F` | CONFIRMED |

Sources: `reverse-engineering/tuneecu-android/apktool/apktool.yml`, `reverse-engineering/tuneecu-android/apktool/AndroidManifest.xml`, `reverse-engineering/tuneecu-android/reports/checksums.txt`, and `reverse-engineering/tuneecu-android/reports/signing-certificate.txt`.

The archive contains one `classes.dex` file. It contains no native `.so` library for ARM, ARM64, x86, or x86-64. The ECU implementation therefore resides in Dalvik bytecode in this APK. **CONFIRMED.** Source: `reverse-engineering/tuneecu-android/reports/initial-inventory.json`.

Apktool 3.0.3 completed the resource and Smali decode. JADX 1.5.6 produced 2,519 Java files and reported two errors. At least one full method, `MainActivity.m8287L8`, is not reconstructed. Several other large methods have control-flow warnings. The Smali output remains the authority for these methods. **CONFIRMED.** Sources: `reverse-engineering/tuneecu-android/jadx/sources/com/tuneecu/MainActivity.java` and `reverse-engineering/tuneecu-android/apktool/smali/com/tuneecu/MainActivity.smali`.

## 2. Relevant package and class inventory

The first-party package contains 375 JADX Java files and 377 Apktool Smali files. Most class names are obfuscated. The communication work is concentrated in a small group of classes. **CONFIRMED.**

| Class | Method or role | Initial finding | Evidence |
| --- | --- | --- | --- |
| `MainActivity` | `m8481e` (`e` in Smali) | Creates the embedded D2xx manager and adds USB VID `0x0403`, PID `0xBF40`. | CONFIRMED |
| `MainActivity` | `m8165A5` (`A5` in Smali) | Scans USB devices and accepts USB vendor ID `0x0403` before the D2xx device filter runs. | CONFIRMED |
| `MainActivity` | `m8805y8` (`y8` in Smali) | Selects one of 18 ELM/STN initialization arrays from active profile values 0 through 21. | CONFIRMED |
| `MainActivity` | `m8752Z8` (`Z8` in Smali) | Appends carriage return to an ASCII adapter command and sends it through Bluetooth or USB OBDLink SX. | CONFIRMED |
| `MainActivity` | `m8402W5` (`W5` in Smali) | Parses adapter replies, identifies adapter variants, recognizes ECU response signatures, changes the active profile, and starts later protocol states. | CONFIRMED |
| `ActivityC2266vc` | `m9068Nb`, `m9077Ob`, `m9078Rb`, `m9074Xb` | Enumerates FTDI devices, opens the direct USB channel, configures serial parameters, changes baud rate, and writes bytes. | CONFIRMED |
| `C2252uc` | `run` | Reads the FTDI channel, assembles replies, applies framing rules, and dispatches complete replies. | CONFIRMED |
| `HandlerC2210rc` | `handleMessage` | Sends complete direct-USB replies to `ActivityC2307z.m9133Nc` or to a Walbro parser. | CONFIRMED |
| `C2043g` | Bluetooth service | Manages classic Bluetooth connection states and data writes. | CONFIRMED |
| `C2015e` | `run` | Opens an RFCOMM client socket. | CONFIRMED |
| `C2029f` | `run` | Reads one Bluetooth byte at a time and dispatches an ASCII reply when it receives `>`. | CONFIRMED |
| `HandlerC2235t9` | `handleMessage` | Sends Bluetooth replies to `MainActivity.m8402W5` and updates connection state. | CONFIRMED |
| `ActivityC2307z` | Protocol engine | Builds binary ECU requests, parses replies, and controls diagnostics, reading, programming, ABS, instrument, TPMS, and Walbro states. | CONFIRMED |
| `EnumC2294y` | Runtime mode enum | Defines 74 named protocol states from `MODE_NULL` through `MODE_WALBRO_SET_INFOS`. | CONFIRMED |
| `ActivityC2225t` | `m9033gc` | Looks up a calibration record and returns its description or calibration family character. | CONFIRMED |
| `p053b.p054a.p055a.C1143g` | Embedded D2xx manager | Filters supported USB VID/PID pairs and opens FTDI devices. | CONFIRMED |
| `p053b.p054a.p055a.C1145i` | Embedded D2xx device | Implements USB control transfers, serial setup, baud selection, bulk writes, and buffered reads. | CONFIRMED |

Third-party code includes Android support and AndroidX code, Google Play Services, Material components, and an obfuscated embedded FTDI D2xx implementation. These packages are excluded from ECU protocol conclusions except where the first-party code calls the D2xx implementation. **CONFIRMED.**

## 3. Adapter architecture

TuneECU has two primary application-level transport paths in this APK. **CONFIRMED.**

1. The direct USB path uses Android USB host APIs and the embedded D2xx implementation. `ActivityC2266vc.m9077Ob` configures 8 data bits, 1 stop bit, no parity, starts a reader thread, and selects 10,400 baud for the normal direct path. `m9078Rb` changes the baud rate. `m9074Xb` supports byte-at-a-time writes with a 3 ms gap and bulk writes.
2. The Bluetooth path uses classic Bluetooth RFCOMM. `C2043g` contains the literal UUID `0001101-0000-1000-8000-00805F9B34FB`. Android parses the shortened first UUID group as the Bluetooth Serial Port Profile value `0x1101`. `C2029f.run` collects ASCII data until the ELM prompt character `>` and then sends it to `MainActivity.m8402W5`.

The first-party package has no `BluetoothGatt` reference. The extracted communication path uses classic Bluetooth sockets, not Bluetooth Low Energy GATT. **CONFIRMED for this APK.**

USB OBDLink SX is a special case. `ActivityC2266vc.m9068Nb` removes spaces from the USB product description and compares it with `OBDLinkSX`. If it matches, later code uses the ASCII ELM/STN command path over the FTDI USB channel at 115,200 baud. **CONFIRMED.**

The embedded D2xx filter contains these built-in USB identifiers: FTDI `0x0403` with PIDs `0x6015`, `0x6014`, `0x6011`, `0x6010`, `0x6001`, `0x6006`, `0x601C`, `0xFAC1` through `0xFAC6`, `0x6012`, and `0x6017`; VID `0x08AC` with PID `0x1025`; and VID `0x15D6` with PID `0x0001`. TuneECU also adds FTDI `0x0403:0xBF40` at run time. **CONFIRMED.** Source: `p053b.p054a.p055a.C1143g` and `MainActivity.m8481e`.

The APK does not contain the strings `Tactrix` or `OpenPort`. This pass has not established whether an OpenPort 2.0 Rev H USB descriptor matches one of the accepted pairs. Tactrix compatibility is **UNKNOWN**.

### Adapter command flow

```text
Bluetooth RFCOMM adapter -> byte stream -> collect through '>' -> MainActivity.m8402W5
USB OBDLink SX          -> D2xx byte stream -> collect through '>' -> MainActivity.m8402W5
Direct FTDI cable       -> D2xx byte stream -> binary framing -> ActivityC2307z.m9133Nc
```

`MainActivity.m8402W5` checks `STI` replies for `STN11` or `STN22`. It checks `AT#1` replies for `WGSoft`. It checks `AT@1` replies and labels replies that start with `1` as UCSI-2000 and replies that start with `2` as UCSI-2100. **CONFIRMED.** Source: `MainActivity.m8402W5` and `MainActivity.smali` method `W5`.

## 4. ECU family decoder

There are two character systems. They must not be combined.

### Calibration record character

The resource record `20417:7:Daytona 675` is present and states: VIN up to 294377, Arrow complete system, fuel up to E10, and minimum 95 RON. The records `20477:B:Tiger 800/800 XC` and later Tiger 800 records are also present. **CONFIRMED.** Source: `reverse-engineering/tuneecu-android/apktool/res/values/arrays.xml`.

`ActivityC2225t.m9033gc` selects the correct `tNNN` resource array from the calibration number, finds the record that starts with that number, and returns the character between the first and second colon when its third argument is 2. Other methods index that returned character with `0123456789ABCDEFGHIJKLMNOPQRSTUV`. **CONFIRMED.** Sources: `ActivityC2225t.m9033gc`, `ActivityC2225t` near its map initialization logic, `ActivityC2307z.m9221nc`, and the corresponding Smali in `t.smali` and `z.smali`.

| Calibration | Character | Character index | Model evidence | Evidence |
| --- | ---: | ---: | --- | --- |
| 20108 and 20417 | `7` | 7 | Daytona 675, VIN up to 294377 | CONFIRMED |
| 20197 and related records | `7` | 7 | Street Triple | CONFIRMED |
| 20477 and related records | `B` | 11 | Tiger 800 and Tiger 800 XC | CONFIRMED |

The calibration character is stored in map metadata and is used by map processing. This pass has not found a direct call that converts the calibration character to the active communication profile. That part of the requested pipeline is **UNKNOWN**.

### ECU selector character

The `R.array.ecu` list uses suffix characters for user-visible ECU groups. `MainActivity.m8373T9` and `m8427Y6` convert the suffix with `0123456789ABCDEFGHIJKLMNP`. They then call `MainActivity.m8656t9`, which sets the base communication profile and ECU flags. **CONFIRMED.**

For example, `Triumph (Keihin):0` gives selector index 0, and `Triumph (Sagem):1` gives selector index 1. `MainActivity.m8656t9` selects base profile 0 for both selectors, subject to its existing-profile condition for selector 0. **CONFIRMED.**

The shorter decoder `0123456789ABCDEFGHIJKLMNP` therefore applies to ECU selector entries. It is not proven to decode the character in records such as `20417:7`. **CONFIRMED distinction.**

## 5. Internal protocol profile table

`MainActivity.f6939Ja` is the active profile value, and `MainActivity.f6930Ia` is the base profile value. `MainActivity.m8805y8` selects the initialization array. The field names are JADX names and can change between versions. **CONFIRMED.**

The meanings in the Interpretation column are preliminary. The command sequences are direct evidence. ELM protocol names are marked as inferences until the ECU reply parser is fully reconstructed.

| Profile | Initialization sequence after `ATWS` | Initial interpretation | Evidence |
| ---: | --- | --- | --- |
| 0 | `ATE0 ATL0 ATAL ATS0 ATH1 ATTP3 ATSH686AF1` | ISO 9141 style K-Line probe with header `68 6A F1`. | Commands CONFIRMED; protocol INFERRED |
| 1 | Variant A: `ATE0 ATL0 ATS0 STI AT#1 AT@1 ATH1 ATTP7 ATV0 ATCAF0 ATCFC1 ATCP18 ATSHDB33F1 020100`; variant B uses `STPTO 160 STCSEGT1 ATSHDAD5F1`; variant C uses custom protocol B, 29-bit filters, and `020100`. | Adapter-qualified 29-bit CAN or custom CAN probe. | CONFIRMED |
| 2 | `ATE0 ATL0 ATAL ATS0 ATH1 ATTP5 ATSH81D5F5 81` | ISO 14230/KWP fast-init style probe. | Commands CONFIRMED; protocol INFERRED |
| 3 | `ATE0 ATL0 ATS0 STI AT#1 AT@1 ATH1 ATTP6 ATCAF0 ATCFC1 ATCRA7E8 ATSH7E0 021003` | 11-bit CAN, request ID `7E0`, reply ID `7E8`, UDS extended session probe. | Commands CONFIRMED; UDS meaning INFERRED |
| 4 | `ATE0 ATL0 ATAL ATS0 ATH1 ATTP5 ATSH8111F1 81 ATSH8011F1 20` | KWP fast-init style two-header probe. | Commands CONFIRMED; protocol INFERRED |
| 5 | `ATE0 ATL0 ATAL ATS0 ATH1 ATTP5 ATSH8010F1 81` | KWP fast-init style probe to target `0x10`. | Commands CONFIRMED; protocol INFERRED |
| 6 | `ATE0 ATL0 ATAL ATS0 ATH1 ATTP5 ATSH8101F1 81` | KWP fast-init style probe to target `0x01`. | Commands CONFIRMED; protocol INFERRED |
| 7 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 8 | `ATE0 ATL0 ATAL ATS0 ATST32 ATH1 ATTP3 ATIIA43 ATSH686AF1` | ISO 9141 style K-Line probe with init address `0x43`. | Commands CONFIRMED; protocol INFERRED |
| 9 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 10 | `ATE0 ATL0 ATS0 STI AT#1 AT@1 ATCAF0 ATCFC0 ATPBE101 ATSPB ATCRA7E8 ATSH7E0 ATH1 021001` | Custom CAN protocol B, IDs `7E0` and `7E8`, default diagnostic session probe. | Commands CONFIRMED; UDS meaning INFERRED |
| 11 | `ATE0 ATL0 ATS0 ATH1 ATTP6 ATCAF0 ATCFC0 ATCRA704 ATSH701 5E01` | 11-bit CAN with request ID `701` and reply ID `704`; first service is not yet classified. | CONFIRMED |
| 12 | `ATE0 ATL0 ATS0 ATH1 ATTP7 ATV0 ATCAF0 ATCFC1 ATCP18 STCSEGT1 ATSHDAC1F1 021003` | 29-bit CAN UDS extended session probe. | Commands CONFIRMED; UDS meaning INFERRED |
| 13 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 14 | `ATE0 ATL0 ATS0 ATH1 ATAT0 ATSTFF ATTP6 ATCAF0 ATCFC0 ATCRA602 ATSH604 0B00` | 11-bit CAN with request ID `604` and reply ID `602`; first service is not yet classified. | CONFIRMED |
| 15 | `ATE0 ATL0 ATS0 ATH1 ATTP7 ATV0 ATCAF0 ATCFC1 ATCP18 ATSHDAC8F1 021003` | 29-bit CAN UDS extended session probe. | Commands CONFIRMED; UDS meaning INFERRED |
| 16 | `ATE0 ATL0 ATS0 ATH1 ATAT0 ATST50 ATTP6 ATCAF0 ATCFC0 ATCRA600 0D` | 11-bit CAN with reply ID `600`; request addressing is not yet established. | CONFIRMED |
| 17 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 18 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 19 | Reuses profile 0 array. | Fallback or probe alias. | CONFIRMED array selection; purpose UNKNOWN |
| 20 | `ATE0 ATL0 ATAL ATS0 ATH1 ATIIAD5 ATTP4 ATSH82D5F5` | KWP 5-baud-init style probe with init address `0xD5`. | Commands CONFIRMED; protocol INFERRED |
| 21 | `ATE0 ATL0 ATS0 STI AT#1 AT@1 ATCAF0 ATCFC0 ATPBE101 ATSPB ATCRA781 ATSH780 ATH1 021003` | Custom CAN protocol B, request ID `780`, reply ID `781`, UDS extended session probe. | Commands CONFIRMED; UDS meaning INFERRED |

Source: `MainActivity` fields `f7400Q2` through `f7492h3` and method `m8805y8`; Smali method `y8` is the cross-check.

## 6. K-Line and KWP profiles

Profiles 0, 2, 4, 5, 6, 8, and 20 use ELM protocol selections 3, 4, or 5 and three-byte headers. The literal commands confirm that TuneECU supports multiple K-Line initialization and address combinations. **CONFIRMED.**

The direct FTDI path starts at 10,400 baud and can send one byte at a time with a 3 ms gap. This behavior is consistent with timing-sensitive K-Line work. **CONFIRMED behavior; K-Line use INFERRED at this stage.**

The exact slow-init, fast-init, wake-up, checksum, and KWP service state transitions are not complete in this pass. They are **UNKNOWN** pending the state-by-state analysis of `ActivityC2307z` and `ActivityC2266vc.m9067Lb`.

## 7. CAN, ISO-TP, and UDS profiles

Profiles 3, 10, 11, 12, 14, 15, 16, and 21 configure CAN reply filters or transmit headers. Profiles 3 and 10 use `7E0`/`7E8`. Profile 21 uses `780`/`781`. Profile 11 uses `701`/`704`. Profile 14 uses `604`/`602`. Profile 16 filters `600`. **CONFIRMED.**

The `021003` payload has the structure of an ISO-TP single frame with length 2 and UDS service `0x10`, subfunction `0x03`. The expected positive response pattern `...0650...` appears in `MainActivity.m8402W5`. This supports the extended diagnostic session interpretation. **INFERRED with strong local evidence.**

`C2252uc.run` also has a binary frame-length rule. It uses either the low seven bits of the first byte plus four bytes or an extended length from byte 3 plus five bytes. The full framing protocol is not yet named. **OBSERVED.**

## 8. Runtime ECU detection

`MainActivity.m8402W5(String)` is the high-priority reply parser. It removes ELM prompt and formatting text, advances through the selected adapter initialization array, identifies STN and UCSI adapters, handles adapter errors, parses CAN and K-Line response text, and changes `EnumC2294y` states. **CONFIRMED.**

The method contains the response signatures `C1DA8F`, `C1EF8F`, `C16B8F`, `C1E98F`, `DAF1D50641`, `DAF1D606`, `DAF1D610`, `DAF1D5101349`, `7E8`, `704`, `602`, `600`, and `781`. **CONFIRMED.** Source: `MainActivity.smali`, method `W5`, especially the constants near Smali lines 23820 through 23974.

JADX reports broken control flow for this method. One reliable transition is visible: under active profile 2, a reply that contains `C1DA8F` sets an ECU flag, enters `MODE_INIT`, sends `ATSH80D5F5`, and continues. Under active profile 1, the `DAF1D5...` variants cause different follow-up commands or save response bytes for later classification. **CONFIRMED for these visible branches.**

The complete table from probe to signature to ECU class to next profile is not complete. It requires direct Smali control-flow reconstruction. That work is **UNKNOWN** and is the first task for the next analysis pass.

## 9. Diagnostics

`EnumC2294y` contains states for ECU information, active data, sensors, DTC read, DTC clear, identification, ABS identification and DTC work, ABS bleeding, exhaust valve adjustment, TPMS, service interval, instrument data, and crank adaptation. **CONFIRMED.**

The exact request bytes, sessions, and reply interpretations for each diagnostic operation are not complete in this initial pass. They are **UNKNOWN**.

## 10. Map reading

`EnumC2294y` contains `MODE_REQ_UPLOAD`, `MODE_IAW_READ`, `MODE_7SM_READ`, `MODE_READ_BLOCK`, and `MODE_READ_MEM`. `ActivityC2307z` contains generators and parsers for these states. **CONFIRMED.**

The address formats, block sizes, retry rules, and map integrity checks are not complete in this initial pass. They are **UNKNOWN**.

## 11. Programming and flashing

`EnumC2294y` contains session, seed, access, erase, programming request, download request, start download, transfer, transfer exit, end programming, ECU reset, IAW programming, and Walbro programming states. **CONFIRMED.**

This pass does not claim a flashing sequence. The state names prove that implementations exist, but they do not prove the bytes or transitions. The bytes, timing, retry rules, and ECU-family conditions are **UNKNOWN** until each state is traced in `ActivityC2307z` and cross-checked with Smali.

## 12. Security access

`MODE_SEED`, `MODE_ACCESS`, `ERR_AUTHENTIFY`, `SECURITY_ACCESS`, and `SECURITY_UNLOCK` are present. **CONFIRMED.**

No seed-to-key algorithm is documented in this initial pass. No algorithm will be assigned to an ECU family without direct call and data-flow evidence. The algorithms and family associations are **UNKNOWN**.

## 13. Model, ECU, and protocol mapping

The APK provides a broad ECU selector list for Aprilia, Benelli, BMW, CCM, Ducati, Gilera, Husqvarna, KTM, Moto Guzzi, Moto Morini, and Triumph. The Triumph entries explicitly distinguish Sagem, Keihin, and the Triumph 400 Bosch ECU. **CONFIRMED.** Source: `R.array.ecu` in `arrays.xml`.

For the user's calibration, the APK directly confirms `20417:7:Daytona 675`, VIN up to 294377, Arrow complete system, fuel up to E10, and minimum 95 RON. **CONFIRMED.**

The Android calibration record does not itself name the ECU type. The broad ECU selector list names Triumph Keihin as selector suffix `0`, but the current pass has not demonstrated the full link from record `20417` to that selector. The model-to-ECU relationship is therefore **OBSERVED from separate data sources** and the executable link remains **UNKNOWN**.

## 14. Comparison with OpenECU and Windows 2.5.8

This comparison is deferred. The user required the Android behavior to be identified independently before the existing implementation is used as a comparison target. No Rust file was changed in this pass.

The Android evidence already shows areas that a later comparison must test: classic Bluetooth ELM/STN transport, direct D2xx USB transport, USB OBDLink SX, STN and UCSI identification, K-Line profiles, 11-bit and 29-bit CAN profiles, custom CAN protocol B, reply-signature-driven profile changes, and a large runtime state enum. **CONFIRMED Android scope.**

## 15. Unresolved questions

The prioritized question list is in `docs/reverse-engineering/tuneecu-android-unknowns.md`.

## 16. Proposed Rust architecture

Architecture work is deferred until the Android state machines are sufficiently mature. The current evidence supports these boundaries: adapter, physical/data-link transport, ISO-TP or other framing, diagnostic protocol, ECU implementation, and motorcycle definition. **INFERRED design boundary.**

No Rust architecture is final, and no Rust code was changed.
