# TuneECU Android working inventory

This index covers only `TuneECU v5.5.64.apk`. The Android manifest reports package `com.tuneecu`, version name `5.5`, and version code `5564`.

| Class or resource | Method | Purpose | Important constants | Profile or IDs | Confidence | Source |
| --- | --- | --- | --- | --- | --- | --- |
| `MainActivity` | `m8481e` / Smali `e` | Initialize the embedded D2xx manager and add a VID/PID pair. | `1027`, `48960` | `0403:BF40` | CONFIRMED | `jadx/sources/com/tuneecu/MainActivity.java`; `apktool/smali/com/tuneecu/MainActivity.smali` |
| `MainActivity` | `m8165A5` / Smali `A5` | Scan attached USB devices. | USB VID `1027` | FTDI vendor filter | CONFIRMED | Same files as above |
| `ActivityC2266vc` | `m9068Nb` | Enumerate D2xx devices and identify USB OBDLink SX by product description. | `OBDLinkSX` | USB ELM path | CONFIRMED | `jadx/sources/com/tuneecu/ActivityC2266vc.java` |
| `ActivityC2266vc` | `m9077Ob` | Open direct USB and configure serial operation. | 8 data bits, 1 stop bit, no parity, 10,400 or 115,200 baud | Direct FTDI and OBDLink SX | CONFIRMED | `jadx/sources/com/tuneecu/ActivityC2266vc.java`; `apktool/smali/com/tuneecu/vc.smali` |
| `ActivityC2266vc` | `m9074Xb` | Write direct USB bytes. | 3 ms byte gap or bulk write | Raw and ASCII paths | CONFIRMED | Same files as above |
| `C2252uc` | `run` | Read and frame direct USB replies. | 2,048-byte read buffer, 4,096-byte assembly buffer, 160 ms timeout | Binary and `>`-terminated ASCII | CONFIRMED | `jadx/sources/com/tuneecu/C2252uc.java`; `apktool/smali/com/tuneecu/uc.smali` |
| `C2043g` | class service | Manage classic Bluetooth states and writes. | `0001101-0000-1000-8000-00805F9B34FB` | RFCOMM/SPP | CONFIRMED | `jadx/sources/com/tuneecu/C2043g.java`; `apktool/smali/com/tuneecu/g.smali` |
| `C2029f` | `run` | Read Bluetooth adapter text until prompt. | `>` | ELM/STN reply delimiter | CONFIRMED | `jadx/sources/com/tuneecu/C2029f.java`; `apktool/smali/com/tuneecu/f.smali` |
| `HandlerC2235t9` | `handleMessage` | Route Bluetooth replies to the main reply parser. | message types 1, 2, 4, 5 | Connection states 0 through 3 | CONFIRMED | `jadx/sources/com/tuneecu/HandlerC2235t9.java`; `apktool/smali/com/tuneecu/t9.smali` |
| `MainActivity` | `m8752Z8` / Smali `Z8` | Append carriage return and send an ASCII adapter command. | `\r`, `AT` | Bluetooth or USB OBDLink SX | CONFIRMED | `jadx/sources/com/tuneecu/MainActivity.java`; `apktool/smali/com/tuneecu/MainActivity.smali` |
| `MainActivity` | fields `f7400Q2` to `f7492h3` | Store 18 adapter initialization arrays. | `ATTP3/4/5/6/7`, `ATSPB`, `ATSH`, `ATCRA`, flow-control commands | Active profiles 0 through 21 | CONFIRMED | Same files as above; `reports/communication-inventory.json` |
| `MainActivity` | `m8805y8` / Smali `y8` | Select an initialization array from the active profile. | `ATWS` | Profiles 0 through 21 | CONFIRMED | Same files as above |
| `MainActivity` | `m8402W5` / Smali `W5` | Parse adapter and ECU replies and change state. | `STN11`, `STN22`, `WGSoft`, `DAF1D5`, `C1DA8F`, `7E8`, `781`, `704`, `602`, `600` | Profiles 0 through 21 | CONFIRMED | Same files as above; Smali method starts at line 22804 in current output |
| `ActivityC2307z` | `m9098Ed` | Submit a binary ECU request to the transport layer. | Many byte-array service requests | Multiple ECU families | OBSERVED | `jadx/sources/com/tuneecu/ActivityC2307z.java`; `apktool/smali/com/tuneecu/z.smali` |
| `ActivityC2307z` | `m9133Nc` | Parse a complete binary reply. | Runtime mode and framing flags | Multiple ECU families | OBSERVED | Same files as above |
| `ActivityC2307z` | `m9135Ne` | Change or execute the runtime protocol mode. | `EnumC2294y` | 74 modes | OBSERVED | Same files as above |
| `EnumC2294y` | enum | Name the protocol states. | `MODE_SESSION`, `MODE_SEED`, `MODE_READ_MEM`, `MODE_REQ_DOWNLOAD`, `MODE_DOWNLOAD`, `MODE_ECU_RESET` | Diagnostics, read, write, maintenance | CONFIRMED | `jadx/sources/com/tuneecu/EnumC2294y.java`; `apktool/smali/com/tuneecu/y.smali` |
| `ActivityC2225t` | `m9033gc` / Smali `gc` | Find a calibration record and return its description or character. | `t100`, `t200` through `t316`, `t900` | Map record character | CONFIRMED | `jadx/sources/com/tuneecu/ActivityC2225t.java`; `apktool/smali/com/tuneecu/t.smali` |
| `ActivityC2225t`, `ActivityC2307z`, `MainActivity` | map metadata calls | Convert the record character to an index. | `0123456789ABCDEFGHIJKLMNOPQRSTUV` | Record `7` -> index 7; record `B` -> index 11 | CONFIRMED | Java and Smali files for these classes |
| `MainActivity` | `m8373T9`, `m8427Y6` | Convert an ECU selector suffix to a selector index. | `0123456789ABCDEFGHIJKLMNP` | ECU selector index | CONFIRMED | `jadx/sources/com/tuneecu/MainActivity.java`; `apktool/smali/com/tuneecu/MainActivity.smali` |
| `MainActivity` | `m8656t9` | Set the base profile and ECU-family flags for an ECU selector index. | switch cases 0 through 24 | Base profiles 0, 2, 3, 5, 6, 7, and 10 | CONFIRMED | Same files as above |
| `arrays.xml` | `t201`, `t204` | Store calibration descriptions. | `20108:7`, `20417:7`, `20477:B` | Daytona 675 and Tiger 800 | CONFIRMED | `apktool/res/values/arrays.xml` |
| `arrays.xml` | `ecu` | Store broad ECU selector groups. | `Triumph (Sagem):1`, `Triumph (Keihin):0`, `Triumph 400 (Bosch):P` | Selector suffixes | CONFIRMED | `apktool/res/values/arrays.xml` |
| `p053b.p054a.p055a.C1143g` | `m5104k`, `m5107o` | Filter supported USB identifiers and add one identifier. | FTDI and other VID/PID pairs | D2xx | CONFIRMED | `jadx/sources/p053b/p054a/p055a/C1143g.java`; matching Smali |
| `p053b.p054a.p055a.C1145i` | `m5155z`, `m5140P`, `m5153x` | Set baud, write USB data, and read buffered data. | 300 through 921,600 baud table | D2xx | CONFIRMED | `jadx/sources/p053b/p054a/p055a/C1145i.java`; matching Smali |

All listed paths are below `reverse-engineering/tuneecu-android/` unless the path starts with `docs/`.
