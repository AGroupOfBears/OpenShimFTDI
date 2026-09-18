Absolutely — here’s a complete updated `README.md` for:

```text
/home/spoqn/Desktop/Source Codes/OpenShimFTDI/reference/tuneecu-android/README.md
```

Paste this in as-is:

```markdown
# TuneECU Android Reference

This directory contains a deliberately limited subset of reverse-engineered
TuneECU Android files supplied as supporting reference material for development
of OpenShimFTDI.

These files are **reference material only**.

OpenShimFTDI is not intended to recreate TuneECU Android.

The primary implementation target is the behaviour expected by the Windows
versions of TuneECU 2.5.x when communicating through `FTD2XX.dll`.

The Android implementation is included because it provides useful supporting
evidence about:

- FTDI / D2XX behaviour
- direct USB communication
- serial configuration
- K-Line communication
- ECU initialization
- ECU probing
- ECU response framing
- communication profile selection
- ECU identification
- diagnostic request generation
- diagnostic response parsing
- ECU protocol state transitions

The Android reference set currently comes from the reverse-engineered
TuneECU Android 5.5.64 build.

---

# OpenShimFTDI architecture

The intended architecture is:

```text
TuneECU Windows 2.5.x
        |
        v
   FTD2XX.dll API
        |
        v
    OpenShimFTDI
        |
        v
      J2534
        |
        v
 Tactrix OpenPort 2.0
        |
        v
 K-Line / CAN vehicle bus
        |
        v
        ECU
```

OpenShimFTDI should act as a compatibility and transport layer.

It should not attempt to replace TuneECU's ECU protocol engine unless a specific
D2XX behaviour must be translated into an equivalent J2534 operation.

---

# TuneECU connection behaviour

TuneECU does not require the user to select a motorcycle before connection.

The normal flow is approximately:

```text
Connect diagnostic interface
        |
        v
Start TuneECU
        |
        v
Power motorcycle / ECU
        |
        v
User selects Connect
        |
        v
TuneECU probes the ECU
        |
        v
ECU responds
        |
        v
TuneECU identifies ECU family/type
        |
        v
TuneECU derives motorcycle/ECU information
        |
        v
Diagnostic functionality becomes available
```

Therefore OpenShimFTDI should not hard-code a motorcycle model such as a
Daytona 675.

TuneECU itself should remain responsible for:

- connection attempts
- ECU probing
- ECU classification
- ECU identification
- motorcycle identification
- diagnostic request generation
- diagnostic response interpretation
- DTC operations
- live sensor operations
- adaptation and maintenance operations
- map read/write logic

OpenShimFTDI should preserve enough of the expected FTDI/D2XX behaviour that
TuneECU's existing state machine can operate normally.

---

# Reference hierarchy

When investigating behaviour, prefer evidence in approximately this order:

1. Windows TuneECU 2.5.x reverse-engineered code
2. Actual D2XX traces captured from Windows TuneECU
3. Android Smali
4. Android JADX output
5. Reverse-engineering reports
6. Protocol interpretation / inference

The Windows application is the client OpenShimFTDI must satisfy.

The Android application is supporting evidence.

Smali should be treated as authoritative when JADX produces broken, incomplete,
or ambiguous control flow.

Do not blindly translate Android application code into OpenShimFTDI.

---

# Directory layout

```text
tuneecu-android/
├── README.md
│
├── jadx/
│   ├── com/
│   │   └── tuneecu/
│   │       ├── MainActivity.java
│   │       ├── ActivityC2266vc.java
│   │       ├── C2252uc.java
│   │       ├── ActivityC2307z.java
│   │       ├── EnumC2294y.java
│   │       ├── HandlerC2210rc.java
│   │       └── HandlerC2235t9.java
│   │
│   └── p053b/
│       └── p054a/
│           └── p055a/
│               ├── C1143g.java
│               └── C1145i.java
│
├── smali/
│   ├── com/
│   │   └── tuneecu/
│   │       ├── MainActivity.smali
│   │       ├── vc.smali
│   │       ├── uc.smali
│   │       ├── z.smali
│   │       ├── y.smali
│   │       ├── rc.smali
│   │       └── t9.smali
│   │
│   └── p053b/
│       └── p054a/
│           └── p055a/
│               ├── g.smali
│               └── i.smali
│
├── resources/
│   └── arrays.xml
│
└── reports/
    ├── tuneecu-android.md
    ├── tuneecu-android-inventory.md
    ├── tuneecu-android-unknowns.md
    └── communication-inventory.json
```

---

# Primary reference files

## `jadx/com/tuneecu/MainActivity.java`

High-value communication reference.

Relevant behaviour includes:

- D2XX manager initialization
- USB device scanning
- communication profile selection
- adapter initialization arrays
- ELM/STN initialization
- adapter response parsing
- ECU response parsing
- runtime protocol changes
- connection state transitions
- ECU selector decoding
- base communication-profile selection

Important methods identified during reverse engineering include:

```text
m8481e
m8165A5
m8752Z8
m8805y8
m8402W5
m8373T9
m8427Y6
m8656t9
```

The most important parser is:

```text
m8402W5
```

which corresponds to:

```text
W5
```

in Smali.

This method parses adapter and ECU responses and changes communication
state/profile based on observed replies.

Because JADX has difficulty reconstructing portions of this routine, conclusions
derived from it should be verified against:

```text
smali/com/tuneecu/MainActivity.smali
```

---

# `smali/com/tuneecu/MainActivity.smali`

Authoritative bytecode-level counterpart to `MainActivity.java`.

This file is especially important for:

- `W5`
- adapter response handling
- ECU response signature matching
- active-profile transitions
- base-profile transitions
- protocol initialization arrays
- state changes where JADX output is incomplete

When JADX and Smali disagree, prefer the Smali.

---

# `jadx/com/tuneecu/ActivityC2266vc.java`

Direct USB / D2XX transport reference.

Relevant behaviour includes:

- USB device enumeration
- D2XX device opening
- direct FTDI configuration
- baud-rate selection
- serial setup
- direct USB writes
- byte-at-a-time writes
- bulk writes
- USB OBDLink SX detection

Observed baud rates include:

```text
10400
115200
```

Observed serial framing includes:

```text
8 data bits
1 stop bit
no parity
```

The exact context and meaning of each configuration should be derived from the
code and runtime traces rather than assumed.

Smali counterpart:

```text
smali/com/tuneecu/vc.smali
```

---

# `jadx/com/tuneecu/C2252uc.java`

Direct USB receive path.

Relevant behaviour includes:

- FTDI reads
- receive buffering
- response assembly
- framing
- timeout handling
- binary response handling
- ASCII response handling
- dispatching completed responses

Observed implementation details include:

```text
2048-byte read buffer
4096-byte assembly buffer
160 ms timeout
```

This file is particularly useful when determining what Windows TuneECU may
expect from equivalents of:

```text
FT_Read
FT_GetStatus
FT_SetEventNotification
```

Smali counterpart:

```text
smali/com/tuneecu/uc.smali
```

---

# `jadx/com/tuneecu/ActivityC2307z.java`

Main binary ECU protocol engine.

This class contains much of TuneECU's higher-level ECU communication logic.

Relevant behaviour includes:

- binary ECU request generation
- binary response parsing
- runtime protocol modes
- ECU identification
- diagnostic sessions
- DTC operations
- sensor operations
- adaptation operations
- memory reads
- map reads
- programming
- security access
- ECU reset
- ABS operations
- instrument operations
- TPMS operations
- Walbro-related operations

Important methods identified during reverse engineering include:

```text
m9098Ed
m9133Nc
m9135Ne
```

OpenShimFTDI should not reimplement this protocol engine.

The purpose of including this file is to let developers determine what a
particular low-level FTDI operation represents in TuneECU's higher-level state
machine.

Smali counterpart:

```text
smali/com/tuneecu/z.smali
```

---

# `jadx/com/tuneecu/EnumC2294y.java`

Runtime communication-state enumeration.

This class provides semantic names for otherwise-obfuscated protocol states.

Observed states include concepts such as:

```text
MODE_SESSION
MODE_SEED
MODE_READ_MEM
MODE_REQ_DOWNLOAD
MODE_DOWNLOAD
MODE_ECU_RESET
```

The enum contains approximately 74 runtime protocol states covering diagnostics,
reading, programming and maintenance functionality.

This file is useful when tracing `ActivityC2307z`.

Smali counterpart:

```text
smali/com/tuneecu/y.smali
```

---

# `jadx/com/tuneecu/HandlerC2210rc.java`

Routes completed responses from the direct USB / FTDI receive path into the
higher-level ECU communication engine.

Useful for understanding the boundary:

```text
FTDI transport
        |
        v
receive framing
        |
        v
message routing
        |
        v
ECU protocol engine
```

Smali counterpart:

```text
smali/com/tuneecu/rc.smali
```

---

# `jadx/com/tuneecu/HandlerC2235t9.java`

Routes responses received through the smart-adapter / Bluetooth path.

This is not part of the primary direct-FTDI shim path, but it is useful when
comparing:

```text
raw FTDI communication
```

with:

```text
ELM/STN smart-adapter communication
```

Smali counterpart:

```text
smali/com/tuneecu/t9.smali
```

---

# Embedded Android D2XX implementation

TuneECU Android contains an embedded FTDI/D2XX-style implementation.

These classes are useful supporting references for understanding how TuneECU
expects FTDI-like devices to behave.

---

## `jadx/p053b/p054a/p055a/C1143g.java`

JADX-renamed class.

Original class name:

```text
b.a.a.g
```

JADX reports:

```text
/* JADX INFO: renamed from: b.a.a.g */
```

Relevant behaviour includes:

- FTDI USB VID/PID filtering
- supported USB device identification
- D2XX manager behaviour
- device enumeration
- adding supported VID/PID pairs

Known reverse-engineered methods include:

```text
m5104k
m5107o
```

Corresponding original Smali:

```text
smali/p053b/p054a/p055a/g.smali
```

Note that the destination directory preserves the JADX package grouping for
convenience, while the Smali filename preserves the original obfuscated class
name.

---

## `jadx/p053b/p054a/p055a/C1145i.java`

JADX-renamed class.

Original class name:

```text
b.a.a.i
```

JADX reports:

```text
/* JADX INFO: renamed from: b.a.a.i */
```

Relevant behaviour includes:

- baud-rate configuration
- USB device communication
- control transfers
- data writes
- buffered reads
- FTDI-style device setup

Known reverse-engineered methods include:

```text
m5155z
m5140P
m5153x
```

Corresponding original Smali:

```text
smali/p053b/p054a/p055a/i.smali
```

---

# JADX / Smali name mappings

Some classes were renamed by JADX during decompilation.

Known mappings relevant to this reference set are:

```text
JADX                                        Original / Smali

p053b.p054a.p055a.C1143g                   b.a.a.g
p053b.p054a.p055a.C1145i                   b.a.a.i
```

Therefore:

```text
jadx/p053b/p054a/p055a/C1143g.java
```

corresponds to:

```text
smali/p053b/p054a/p055a/g.smali
```

and:

```text
jadx/p053b/p054a/p055a/C1145i.java
```

corresponds to:

```text
smali/p053b/p054a/p055a/i.smali
```

Do not assume JADX class names map directly to Smali filenames.

---

# `resources/arrays.xml`

Contains ECU selector and calibration metadata.

Useful entries include:

- calibration descriptions
- ECU selector groups
- Triumph ECU group information
- map-family characters
- selector suffixes

Known examples include records such as:

```text
20108:7
20417:7
20477:B
```

and ECU selectors such as:

```text
Triumph (Sagem):1
Triumph (Keihin):0
Triumph 400 (Bosch):P
```

Important:

TuneECU uses at least two different character/index systems.

The calibration/map-record alphabet is:

```text
0123456789ABCDEFGHIJKLMNOPQRSTUV
```

The ECU-selector alphabet is:

```text
0123456789ABCDEFGHIJKLMNP
```

Do not assume a calibration family character directly maps to a communication
profile number.

---

# Known communication profile evidence

The Android implementation contains multiple adapter initialization profiles.

Observed commands include:

```text
ATE0
ATL0
ATH1
ATS0
ATV0
ATTP3
ATTP4
ATTP5
ATTP6
ATTP7
ATSPB
ATSH7E0
ATCRA7E8
ATSH7DF
ATSH18DAD5F1
ATCF18DAF1D5
ATCM1FFFFF00
ATFCSH18DAD5F1
ATFCSD300008
ATFCSM1
ATCP18
ATIIA43
ATIIAD5
ATPB0101
ATPBE101
ATST32
ATST50
ATSTFF
```

Observed protocol mappings include:

```text
ATTP3
ISO 9141-2

ATTP4
ISO 14230-4 / KWP2000 5-baud initialization

ATTP5
ISO 14230-4 / KWP2000 fast initialization

ATTP6
ISO 15765-4 CAN, 11-bit, 500 kbit/s

ATTP7
ISO 15765-4 CAN, 29-bit, 500 kbit/s
```

These profiles are primarily relevant as protocol evidence.

OpenShimFTDI should not copy ELM/STN command sequences directly unless they help
identify the equivalent low-level FTDI or J2534 operation.

---

# Known response signatures

The Android reply parser contains response signatures including:

```text
C1DA8F
C1EF8F
C16B8F
C1E98F

DAF1D50641
DAF1D606
DAF1D610
DAF1D5101349

7E8
704
602
600
781
```

These signatures are useful when tracing automatic ECU detection and profile
transitions.

They must not be interpreted without checking the surrounding state/profile
conditions.

---

# Reports

## `reports/tuneecu-android.md`

Human-readable reverse-engineering report.

Use this as the primary overview of what has already been established.

Read this before performing new analysis so work is not duplicated.

---

## `reports/tuneecu-android-inventory.md`

Compact index of important classes, methods, constants, profiles and confidence
levels.

This is useful for quickly locating:

- D2XX setup
- USB transport
- profile selection
- reply parsing
- protocol-engine methods
- ECU selector logic

---

## `reports/tuneecu-android-unknowns.md`

Lists unresolved reverse-engineering questions.

Items in this file must not be treated as established facts.

Use the classifications:

```text
CONFIRMED
OBSERVED
INFERRED
UNKNOWN
```

when documenting conclusions.

---

## `reports/communication-inventory.json`

Machine-oriented communication inventory.

Useful for:

- automated searches
- constant lookup
- protocol cross-referencing
- class/method discovery

---

# Important distinction: raw D2XX versus J2534

Windows TuneECU expects a relatively low-level FTDI/D2XX serial interface.

The Tactrix OpenPort 2.0 is normally controlled through J2534, which presents a
higher-level automotive communication API.

These are not equivalent abstractions.

Therefore a one-to-one mapping such as:

```text
one FT_* call
        =
one PassThru* call
```

cannot be assumed.

For example, TuneECU may express an ECU initialization sequence through:

```text
FT_SetBaudRate
FT_SetBreakOn
timing delay
FT_SetBreakOff
FT_Write
```

while J2534 may represent the same underlying operation through:

```text
PassThruConnect
PassThruIoctl
FAST_INIT
FIVE_BAUD_INIT
protocol configuration
```

OpenShimFTDI may therefore need to recognize sequences of D2XX operations and
translate the overall semantic operation into J2534 behaviour.

Such translations must be based on evidence.

Do not guess.

Use:

1. Windows TuneECU call sites
2. real D2XX traces
3. Android implementation
4. J2534 documentation
5. OpenPort-specific documentation

---

# OpenShimFTDI design principle

Whenever possible:

**TuneECU should remain the brains. OpenShimFTDI should remain the transport
bridge.**

The desired flow is:

```text
TuneECU decides what ECU operation to perform
        |
        v
TuneECU expresses transport activity through D2XX
        |
        v
OpenShimFTDI observes / translates that behaviour
        |
        v
J2534 communicates through OpenPort 2.0
        |
        v
ECU receives request
        |
        v
ECU returns response
        |
        v
OpenShimFTDI presents response using D2XX semantics
        |
        v
TuneECU continues its existing state machine
```

Avoid duplicating ECU protocol logic inside OpenShimFTDI unless it is necessary
to translate between raw serial operations and J2534 semantic operations.

---

# Initial implementation scope

The first target is usable diagnostics.

Priority order:

```text
1. FTD2XX device discovery
2. FTD2XX device open
3. OpenPort / J2534 backend open
4. ECU connection
5. TuneECU automatic ECU identification
6. DTC reading
7. live sensor data
8. DTC clearing
9. TPS / adaptation / service operations
10. map reading if required
```

Full ECU map or firmware writing is not required for the first milestone.

Do not implement or test ECU flashing until:

- connection is reliable
- reads are reliable
- timeouts are understood
- initialization is understood
- ECU identification is reliable
- diagnostic operations work reliably

---

# What this reference set does not contain

This directory intentionally does not contain the entire Android application.

Excluded material includes:

- Android UI libraries
- AndroidX
- Material components
- image resources
- layout resources
- payment libraries
- Google libraries
- unrelated Bluetooth implementation details
- unrelated application logic

The goal is to provide Gemini and developers with enough communication-related
context without flooding the project with thousands of irrelevant files.

---

# Files intentionally omitted for now

The following Android communication classes exist but are not required for the
initial direct-FTDI shim implementation:

```text
C2043g
C2029f
```

These primarily relate to Bluetooth Classic / RFCOMM / ELM-STN communication.

They may be added later if comparison between the smart-adapter and direct-FTDI
paths becomes useful.

---

# Evidence discipline

All reverse-engineering conclusions should use one of the following labels.

## CONFIRMED

Directly demonstrated by:

- constants
- bytecode
- control flow
- API calls
- runtime traces

## OBSERVED

Present in the application, but full meaning or ownership has not been
established.

## INFERRED

Likely interpretation supported by surrounding evidence.

## UNKNOWN

Insufficient evidence.

Do not silently promote an inference into a confirmed fact.

---

# Safety boundary

The immediate goal is diagnostic interoperability.

Read-only and low-risk diagnostic functionality should be established before
write/programming functionality.

Do not perform ECU erase, download, flash or map-write operations simply because
the transport layer appears functional.

A transport translation bug during diagnostics usually causes a timeout.

A transport translation bug during ECU programming can leave the ECU in an
unrecoverable or partially programmed state.

---

# Summary

This reference directory exists to answer questions such as:

```text
How does TuneECU configure an FTDI device?

How does TuneECU send raw ECU requests?

How does TuneECU receive and frame replies?

How does TuneECU perform ECU initialization?

How does TuneECU decide which communication profile is active?

What ECU reply signatures cause state transitions?

What does a particular low-level write mean in the higher-level protocol engine?

Which behaviours should OpenShimFTDI preserve?

Which raw FTDI behaviours may need to be translated into J2534 semantics?
```

It should not be used as an excuse to recreate TuneECU Android inside the shim.

The guiding rule remains:

**TuneECU handles ECU logic. OpenShimFTDI handles compatibility and transport.**
```
