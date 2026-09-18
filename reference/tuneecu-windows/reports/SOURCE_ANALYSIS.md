# TuneECU source analysis

Analysis date: 17 September 2026.

## Inspection scope

The inspection read every file in these folders:

- `TuneECU v2.5.5/TuneECU 2.5.5 Clean`
- `TuneECU v2.5.8/TuneECU 2.5.8 Clean`

The tool read all file bytes. It parsed project XML and resource XML. It recorded C# declarations, resource names, binary signatures, file sizes, and SHA-256 hashes. It extracted the initialized library arrays and all language strings. It compared the two source versions.

The manual review followed the main file, map, transport, protocol, sensor, and UI paths. Binary assets received a signature and hash inspection. The inspection did not execute the original program or verify every branch on an ECU. A generated member index is not a substitute for those checks.

| Item | 2.5.5 | 2.5.8 |
| --- | ---: | ---: |
| All files | 73 | 75 |
| Total bytes | 3,619,595 | 2,177,251 |
| C# files | 47 | 48 |
| RESX files | 6 | 6 |
| Resources in RESX files | 47 | 47 |
| Initialized arrays in Tune.cs | 31 | 32 |
| Language tables | 6 × 361 strings | 6 × 361 strings |
| mType records | 696 | 716 |
| eAddr rows, with 40 fields per row | 58 | 62 |
| eBloc groups, with 32 fields per group | 60 | 67 |

The 2.5.5 folder also contains build outputs. These account for much of the file size difference. The smaller 2.5.8 folder does not indicate fewer functions.

The first inventory contained 131 files. Seventeen generated `obj` files appeared in the 2.5.8 clean folder during this work. The final inventory includes all 148 files. Those additions are build records. The recovered C# source did not change.

See [FILE_INVENTORY.md](FILE_INVENTORY.md) for every file. `reference/source-inventory.json` contains the full hashes and declaration evidence. `reference/version-diff.txt` records source differences after blank lines, namespace lines, and decompiler IL comments are removed. The diff still includes formatting and compiler reconstruction differences.

## Program purpose

TuneECU is a motorcycle calibration and diagnostic application. It edits supported map files without an ECU connection. It also connects to an ECU to read identity, sensors, faults, history, and maps. It can run actuator tests, change supported adjustments, download a map, and recover an ECU.

The source contains Keihin, Sagem, and Walbro paths. It also contains Triumph, KTM, Aprilia, and Benelli model logic. Exact support depends on the model and calibration tables. Do not describe it as a Triumph-only application. Do not infer support for every motorcycle from a manufacturer name.

## Source responsibilities

| Source | Observed responsibility | Rebuild destination |
| --- | --- | --- |
| `Program.cs` | Startup, single-instance mutex, window focus, and TuneLibrary check | App and platform services |
| `ISOMain.cs` | Menus, file I/O, edit commands, screen state, tests, settings, and UI scheduling | Core and Slint app |
| `IMap.cs` | File codec, model lookup, memory images, table conversion, trims, checksums, flash blocks, and recovery blocks | Maps |
| `ISORead.cs` | Initialization, security access, state transitions, replies, DTC data, reads, download, and recovery | Protocol and diagnostics |
| `ISOFT.cs` | Serial ports, FTDI calls, receive thread, echo handling, timing, retries, and dispatch | Transport and protocol worker |
| `ISensor.cs` | Sensor ID selection, raw decoding, family conversion, and display values | Diagnostics |
| `IDraw.cs` | Map grids, graphs, gauges, icons, colors, and axis labels | Slint views |
| `Tune.cs` | Map identities, address tables, blocks, checksum definitions, model notes, and capability rules | Models |
| `Infos.cs`, `Logs.cs`, `QueryForm.cs` | Map descriptions, operation messages, and operation-specific choices | Slint dialogs and core |
| `AboutBox.cs`, `Warning.cs` | Application information and operation warnings | Slint dialogs |
| `mOpenFileDialog.cs`, `TuneECU.Controls/*` | File previews and Windows dialog extensions | Portable file services |
| `TuneECU.OS/*`, `KeyStates.cs` | Windows structures, flags, messages, and key state | Portable UI and platform services |
| `TuneECU.Properties/*` | Resource access and serial defaults | Assets and settings |
| `.resx`, `.ico`, `.cur` | Embedded images, form resources, icon, and cursor | Asset migration |
| `.csproj`, `.sln`, `AssemblyInfo.cs` | Legacy build and version metadata | Cargo and application version data |
| `bin/*`, `obj/*` | Generated assemblies, symbols, resources, and build records | Reference evidence only |

## How file and map operations work

The `.hex` extension does not identify Intel HEX text in this program. `ISOMain.ReadFile` expects a binary container. The first little-endian word, with its low four bits cleared, must equal `402920288`.

`IMap.codecMap` leaves the first four bytes unchanged. It combines each later byte with a rotating prefix byte and the previous ciphertext byte. The key sets the high bit in each prefix byte. This is a reversible file transform.

The decoded container has a 28-byte header. A two-byte description length follows it. Description bytes, an `nfo` marker, a block count, and address/length records follow. Memory block data, two stored sums, and optional trim data follow the directory. The original read path allocates 12,292 bytes for stored trims.

`identifyMap` uses a four-byte map signature to find an eight-field `mType` record. It uses that record to select memory blocks and table addresses. `MakeMemoryMap` builds the working memory image. `MakeCompareMap` builds separate comparison data.

The map editor supports fuel, load, ignition, fuel trim, ignition trim, air/fuel, idle, warmup, valve, throttle, and model-specific tables. Model rules add gear, wet/dry, low-octane, idle ignition, limit, minimum, and multiple map-bank variants. Table labels in the initial WinForms tree do not describe the full table set. `Tune.tvMap_Define` changes the labels and available functions.

`SetKeihinTable`, `SetSagemTable`, and `SetWalbroTable` interpret different layouts. `SetGridTable` converts raw cells for display. `SaveModMap` writes edited values back to the memory image. Copy and paste include compatibility rules and axis handling.

PCIII and PCV import use `.djm` and `.pvm` files. The parser recognizes leading values `202` and `2`. Import includes model, cylinder, and gear choices. `ConvertPcmd` interpolates on RPM and throttle axes and uses C# rounding. A Rust port must match midpoint rounding explicitly.

Trim handling includes shared F trims, conversion to L tables, commit, reset, and stored comparison trims. `ValidMod` and `MapChecksum` have family-specific logic. `BuildFlashMap` and `BuildRestoreMap` construct different programming images.

## How an ECU session works

`ISOFT` provides serial and native FTDI access. FTDI initialization selects 8 data bits, no parity, one stop bit, no flow control, a 128-byte input transfer size, 150 ms timeouts, and a 4 ms latency timer. Baud changes, break control, and line control are part of initialization.

Receive processing handles buffered data, expected echo, timing, and retries. `readTimer` also performs protocol work. The original design spreads session logic across `ISOFT`, `ISORead`, and `ISOMain`. The Rust port must preserve these interactions when it separates the modules.

The source enum contains 37 modes. They cover initialization, seed and key access, identification, sensor reads, diagnostics, memory reads, download, exit, abort, and reset. Walbro has additional information, TPS, value, fault, sync, erase, and programming modes.

`SendIso` builds ordinary ISO, KWP, and Sagem request headers. It appends an additive byte checksum. `ReadData` dispatches replies to the ISO or KWP handlers. `readSerial` handles Walbro traffic separately. Walbro data also uses ASCII hexadecimal conversion.

`Setkeys` derives read and write key values from the library constant. `CalculateKey` selects a mode-specific calculation. `SendSeed`, `SendKey`, and `SendKeySagem` form the access workflow. A correct port needs request and reply evidence for each path.

Map programming includes access, programming mode, communication speed, transfer start, data blocks, transfer exit, checksum validation, and reset. Walbro uses its own sync and erase sequence. Recovery uses different map construction and session rules.

The ECU History command reads 8,192 bytes from address 16,384 in 32-byte blocks. It is an ECU memory operation. It is separate from the application log.

The inspected transport source contains serial and FTDI implementations. It does not contain a J2534 provider. The confirmed OpenPort 2.0 Rev H target is an additional OpenECU transport requirement. It must reproduce the same ECU session behavior through the J2534 interface.

## Diagnostics, tests, and desktop functions

`ISensor` converts sensor channels according to ECU family and model flags. Values include RPM, throttle, injection time, ignition angle, temperatures, pressure, voltage, oxygen data, trims, and switch state. Some values require signed interpretation. Sensor availability is model-specific.

Fault handling includes active codes, pending codes, MIL state, descriptions, and erase commands. Walbro has a separate decoder.

Actuator tests include the tachometer, cooling fan, fuel pump, idle stepper, purge valve, secondary air, air flap, exhaust valve, and secondary throttle paths. Adjustments include EXBV cables, ISCV, adaptation, TPS, Sagem trims, and Walbro values.

Desktop behavior includes a map description editor, log window, file previews, keyboard controls, context menus, graph controls, fullscreen, remembered settings, and startup focus. Settings include interface selection, last map, language, sensor mask, mode, graph state, and export separator.

The source contains English, French, German, Italian, Spanish, and Portuguese tables. Both sets are retained as reference data. Translation extraction does not mean that the Slint UI is translated.

## Verified differences between the clean versions

| Area | Observed 2.5.8 change |
| --- | --- |
| Map catalog | Twenty new map IDs. No old map ID disappears. Thirty-two existing records change. |
| Address data | Four additional 40-field address rows and seven additional 32-field block groups |
| Capability rules | New `tabMapH` data and additional model branches, including type 140 |
| Model descriptions | KTM model list grows from 16 to 17 entries. Triumph information grows from 680 to 694 strings. |
| Walbro identity | Adds `A1BEN_07`; changes map names, including `TNT01AS` and `TREK404` |
| Walbro TPS | Collects minimum and maximum values during a throttle sweep. Checks minimum at most 64 and maximum at least 192. Writes both values. |
| TPS lifecycle | Changes test timeout behavior, clears TPS state on session reset, and reports completion after a reply |
| Walbro sensors | Uses a signed ignition value divided by 10. The dashboard path accepts decimal values. |
| Walbro timeout | Avoids the previous general mode retry for `MODE_WALBRO_SET_VALUE` |
| Binary save | Adds `saveBinMenuItem_Click`. The source menu item is hidden by default. |
| Messages | Changes port error text, TPS instructions, and translations |

`IMap.cs` is unchanged after the namespace wrapper is removed. Many other changes are namespace syntax, interpolation syntax, layout sizes, or decompiler comments. Do not treat each textual difference as a new feature.

## Limits and corrections to earlier reports

The source is recovered code. It contains decompiler warnings and Windows interop casts. Static evidence supports the architecture and feature scope. It does not prove every runtime result.

The clean 2.5.8 project targets `.NET Framework 2.0`, Windows Forms, and `x86`. These are legacy build choices. They do not constrain the Rust process to 32 bits.

The previous handoff describes C# and Qt implementation files that are absent. Its build and test claims are historical. The Rust workspace and its current verification record are the active baseline.

This work uses recovered source as a reference. It is not an independent clean-room implementation. The supplied source retains its original authorship. No new license claim is made for that source or its extracted data.

Full parity needs reference map tests, protocol captures, ECU or emulator tests, and desktop acceptance checks. See [FEATURE_PARITY.md](FEATURE_PARITY.md) for the tracked requirements.
