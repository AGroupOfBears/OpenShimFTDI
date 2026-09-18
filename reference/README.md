# OpenShimFTDI Reference Material

This directory contains the source references, reverse-engineering material,
protocol documentation, vendor examples, traces, and hardware tests used during
development of OpenShimFTDI.

OpenShimFTDI is intended to allow legacy Windows TuneECU 2.5.x to communicate
with a Tactrix OpenPort 2.0 while preserving TuneECU's existing ECU detection,
diagnostic, protocol, and application logic.

The primary target application is Windows TuneECU 2.5.x running under Wine on
Linux.

---

# Project goal

The desired application-side architecture is:

```text
TuneECU 2.5.x
      |
      v
  FTD2XX.dll
      |
      v
 OpenShimFTDI
      |
      v
 transport backend
      |
      v
 Tactrix OpenPort 2.0
      |
      v
 K-Line / CAN
      |
      v
      ECU
```

TuneECU should remain responsible for:

- ECU probing
- automatic ECU identification
- motorcycle/model determination
- ECU protocol state
- request generation
- reply parsing
- DTC handling
- live sensor handling
- maintenance operations
- security access
- map reading
- map programming

OpenShimFTDI should primarily provide compatibility and transport.

---

# Current development environment

Current development environment:

```text
OS:      CachyOS Linux
Host:    ThinkPad
Target:  TuneECU 2.5.x under Wine
Cable:   Tactrix OpenPort 2.0
USB ID:  0403:cc4d
```

TuneECU itself runs successfully under Wine.

A native Linux path to the OpenPort 2.0 has also been demonstrated:

```text
CachyOS
   |
   v
 libusb
   |
   v
NikolaKozina J2534
   |
   v
OpenPort 2.0
```

The following calls have been successfully tested as a normal Linux user:

```text
PassThruOpen
PassThruClose
```

Example successful result:

```text
PassThruOpen returned: 0
Device ID: <non-zero>
PassThruClose returned: 0
```

This confirms that native Linux/libusb access to the OpenPort 2.0 is viable.

---

# Purpose of this directory

This directory is reference material.

It is not the OpenShimFTDI implementation itself.

It exists to answer questions such as:

- What D2XX behaviour does Windows TuneECU expect?
- How does TuneECU configure an FTDI interface?
- How does TuneECU initialize an ECU connection?
- How does TuneECU automatically identify an ECU?
- Which D2XX calls are timing-sensitive?
- How are reads, writes, echoes, breaks and retries handled?
- What higher-level ECU operation corresponds to a low-level FTDI sequence?
- How does Tactrix expose OpenPort functionality through J2534?
- How can an OpenPort 2.0 be driven directly from Linux?
- Where do D2XX and J2534 abstractions differ?
- Which observations are confirmed and which are inferred?

The goal is to minimize guesswork during implementation.

---

# Evidence hierarchy

When reference sources disagree, use approximately this order of authority.

## 1. Windows TuneECU 2.5.x source

Highest priority.

```text
tuneecu-windows/
```

This is the software OpenShimFTDI must satisfy.

The behaviour of Windows TuneECU therefore takes precedence over equivalent
behaviour found in Android TuneECU or third-party implementations.

---

## 2. Actual Windows TuneECU runtime traces

```text
tuneecu-windows/traces/
```

Runtime traces should be used to establish:

- actual D2XX call order
- timing
- baud changes
- break behaviour
- reads
- writes
- retries
- timeouts
- probe sequences
- connection state changes

Runtime behaviour may reveal details that are difficult to infer from recovered
source alone.

---

## 3. Official Tactrix J2534 material

```text
j2534/tactrix/
```

Use official Tactrix headers, examples and logs for:

- J2534 API usage
- OpenPort-specific extensions
- K-Line examples
- CAN examples
- filters
- IOCTL usage
- message structures
- vendor-specific behaviour

Do not invent constants or structures from memory when an authoritative local
reference exists.

---

## 4. NikolaKozina OpenPort J2534 implementation

```text
j2534/nikolakozina-j2534/
```

This implementation provides a working open-source reference for communicating
with an OpenPort 2.0 through libusb.

It is especially useful for:

- Linux USB access
- OpenPort device discovery
- USB protocol investigation
- J2534 implementation behaviour
- native Linux backend development

It is an implementation reference rather than the behavioural specification for
OpenShimFTDI.

---

## 5. TuneECU Android source

```text
tuneecu-android/
```

The Android implementation is supporting evidence.

It is useful for understanding:

- direct FTDI communication
- serial setup
- USB communication
- ECU initialization
- communication profiles
- ECU request generation
- response framing
- protocol state
- diagnostic behaviour

Windows TuneECU remains the primary target.

---

## 6. Inference

Anything not directly established from source, runtime evidence,
documentation, or hardware testing should be marked as inference.

Do not silently promote an inference to a fact.

---

# Evidence labels

Use the following labels when documenting findings.

## CONFIRMED

Directly established through:

- source code
- Smali
- runtime trace
- API definition
- hardware test

## OBSERVED

Something is visibly present, but its complete role or meaning is not yet
established.

## INFERRED

A likely interpretation supported by surrounding evidence.

## UNKNOWN

Insufficient evidence currently exists.

---

# Directory layout

```text
reference/
├── README.md
│
├── j2534/
│   ├── nikolakozina-j2534/
│   │   ├── extras/
│   │   ├── j2534/
│   │   │   ├── j2534.c
│   │   │   ├── j2534.h
│   │   │   ├── j2534.pc
│   │   │   ├── j2534.vcxproj
│   │   │   └── makefile
│   │   ├── LICENSE
│   │   └── README.md
│   │
│   ├── tactrix/
│   │   ├── driver-reference/
│   │   │   ├── License.txt
│   │   │   └── openport2.inf
│   │   │
│   │   ├── include/
│   │   │   ├── J2534.cpp
│   │   │   ├── J2534.h
│   │   │   └── j2534_tactrix.h
│   │   │
│   │   ├── logging/
│   │   │   └── ...
│   │   │
│   │   └── samples/
│   │       ├── canlogger/
│   │       ├── innomts/
│   │       └── klogger/
│   │
│   └── tests/
│       └── j2534-open-test.c
│
├── tuneecu-android/
│   ├── README.md
│   ├── jadx/
│   ├── smali/
│   ├── resources/
│   └── reports/
│
└── tuneecu-windows/
    ├── 2.5.5/
    ├── 2.5.8/
    ├── reports/
    └── traces/
```

---

# Windows TuneECU reference

Windows TuneECU is the most important reference set.

Two versions are currently retained:

```text
tuneecu-windows/2.5.5/
tuneecu-windows/2.5.8/
```

The selected files focus on transport, protocol, diagnostics and ECU/model
behaviour rather than unrelated Windows UI code.

---

# ISOFT.cs

```text
tuneecu-windows/<version>/TuneECU/ISOFT.cs
```

Primary transport reference.

Responsibilities include:

- serial communication
- native FTDI calls
- FTDI configuration
- receive processing
- receive thread behaviour
- buffering
- echo handling
- timing
- retries
- communication dispatch

This should normally be the first Windows source file inspected when
implementing or debugging OpenShimFTDI.

Observed FTDI setup includes:

```text
8 data bits
no parity
1 stop bit
no flow control
128-byte input transfer size
150 ms timeouts
4 ms latency timer
```

Baud changes, break control and line control are also involved in ECU
initialization.

---

# ISORead.cs

```text
tuneecu-windows/<version>/TuneECU/ISORead.cs
```

Primary ECU protocol reference.

Responsibilities include:

- ECU initialization
- state transitions
- ECU identification
- ISO/KWP request generation
- ECU reply processing
- security access
- DTC operations
- diagnostic reads
- memory reads
- map reading
- download/programming
- ECU reset
- recovery

Use this file to understand what a low-level transport operation represents in
TuneECU's higher-level ECU protocol state machine.

---

# ISOMain.cs

```text
tuneecu-windows/<version>/TuneECU/ISOMain.cs
```

Application orchestration reference.

Relevant areas include:

- connection actions
- operation selection
- test execution
- settings
- timers
- UI scheduling
- communication state interactions

Transport or protocol behaviour that does not appear to originate in
`ISOFT.cs` or `ISORead.cs` may originate here.

---

# ISensor.cs

```text
tuneecu-windows/<version>/TuneECU/ISensor.cs
```

Diagnostic sensor reference.

Contains logic for:

- sensor selection
- sensor IDs
- raw-value decoding
- ECU-family-specific conversion
- display values

Useful after basic ECU communication has been established.

---

# eMode.cs

```text
tuneecu-windows/<version>/TuneECU/eMode.cs
```

Contains protocol/runtime mode definitions.

Useful for interpreting TuneECU state transitions.

---

# eMessage.cs

```text
tuneecu-windows/<version>/TuneECU/eMessage.cs
```

Contains message/state definitions used by communication logic.

---

# QueryForm.cs

```text
tuneecu-windows/<version>/TuneECU/QueryForm.cs
```

Contains operation-specific application choices.

Lower priority than `ISOFT.cs` and `ISORead.cs`, but useful when determining how
particular protocol operations are initiated.

---

# Tune.cs

```text
tuneecu-windows/<version>/TuneLibrary/Tune.cs
```

Contains model and calibration reference information including:

- map identities
- address tables
- flash blocks
- model data
- capability rules
- calibration information

Do not use this data to hard-code a motorcycle into OpenShimFTDI.

TuneECU should remain responsible for determining ECU and model identity.

---

# Automatic ECU detection

TuneECU Windows does not require the user to select a motorcycle before
connecting.

The expected flow is approximately:

```text
connect interface
      |
      v
start TuneECU
      |
      v
power motorcycle / ECU
      |
      v
user selects Connect
      |
      v
TuneECU probes ECU
      |
      v
ECU responds
      |
      v
TuneECU identifies ECU family/type
      |
      v
TuneECU derives ECU/model capabilities
```

OpenShimFTDI must preserve this behaviour.

Do not:

- hard-code a Daytona 675
- hard-code Triumph behaviour
- invent ECU replies
- bypass TuneECU's probe logic
- perform application-level ECU identification inside the shim

TuneECU should remain responsible for automatic detection.

---

# Windows traces

```text
tuneecu-windows/traces/
```

Current material includes:

```text
2.5.5/
├── ftdi-code.il
├── trace.txt
└── TuneECU.il

2.5.8/
└── trace.txt
```

The absence of equivalent 2.5.8 IL files is not currently considered a blocker
because recovered 2.5.8 C# source is available.

Future traces should preferably use descriptive names.

Examples:

```text
2.5.5-connect-no-ecu.log
2.5.5-connect-bike.log
2.5.5-dtc-read.log
2.5.5-live-data.log
```

---

# Windows reports

```text
tuneecu-windows/reports/
```

Current reports:

```text
SOURCE_ANALYSIS.md
FILE_INVENTORY.md
```

`SOURCE_ANALYSIS.md` contains the recovered-source architecture and behavioural
analysis.

`FILE_INVENTORY.md` records the inspected source tree and identifies which
files own transport, protocol, diagnostics, models and application behaviour.

---

# J2534 reference

```text
j2534/
```

There are currently two main J2534 reference sets:

```text
tactrix/
nikolakozina-j2534/
```

They serve different purposes.

---

# Official Tactrix J2534 material

```text
j2534/tactrix/
```

This material was obtained from the Tactrix OpenPort 2.0 driver/developer
package.

---

# Tactrix include files

```text
j2534/tactrix/include/
├── J2534.cpp
├── J2534.h
└── j2534_tactrix.h
```

## J2534.h

The Tactrix `J2534.h` in this reference set is primarily a sample-side C++
wrapper around a J2534 provider.

It includes methods corresponding to:

```text
PassThruOpen
PassThruClose
PassThruConnect
PassThruDisconnect
PassThruReadMsgs
PassThruWriteMsgs
PassThruStartPeriodicMsg
PassThruStopPeriodicMsg
PassThruStartMsgFilter
PassThruStopMsgFilter
PassThruSetProgrammingVoltage
PassThruReadVersion
PassThruGetLastError
PassThruIoctl
```

It also contains:

- DLL loading
- function-pointer resolution
- debugging helpers
- provider validation

---

# J2534.cpp

Implementation of the Tactrix sample-side J2534 wrapper.

Useful for understanding:

- provider discovery/loading
- symbol resolution
- API invocation
- debugging
- error handling

---

# j2534_tactrix.h

Contains Tactrix-specific J2534 definitions and extensions.

Check this file before implementing or assuming a vendor-specific Tactrix
operation.

---

# Tactrix samples

```text
j2534/tactrix/samples/
```

Current examples:

```text
canlogger/
klogger/
innomts/
```

---

## klogger

Particularly valuable for K-Line work.

Use it to understand how Tactrix expects J2534/OpenPort communication to be
configured for K-Line.

Do not assume the example vehicle protocol or ECU messages apply directly to
TuneECU's target ECU.

---

## canlogger

Useful for CAN/J2534 examples.

This is lower priority for the initial K-Line diagnostic target but useful for
future CAN support.

---

## innomts

Additional J2534 usage example.

Useful for comparing API usage patterns.

---

# Tactrix example logs

```text
j2534/tactrix/logging/
```

Current examples include:

```text
mitsubishi can.txt
mitsubishi k-line.txt
obd can mode 01 22 23 UDS.txt
subaru brz uds.txt
subaru can fast.txt
subaru can.txt
subaru k-line adc lc1.txt
subaru k-line aem.txt
subaru k-line.txt
subaru k-line zt2.txt
```

These logs can help establish:

- J2534 call ordering
- protocol configuration
- filter setup
- K-Line patterns
- CAN patterns
- read/write behaviour
- initialization behaviour

The ECU message contents belong to their respective example vehicles.

Do not treat them as TuneECU/Target-ECU commands.

---

# Tactrix driver metadata

```text
j2534/tactrix/driver-reference/
```

Current files:

```text
License.txt
openport2.inf
```

These provide useful information about the OpenPort driver package and device
metadata.

Original vendor binaries are intentionally not part of this reference tree.

Examples include:

```text
op20pt32.dll
openport.sys
WdfCoInstaller01009.dll
DPInst.exe
uninstall.exe
```

Keep such binaries outside the repository unless their redistribution terms
have been explicitly checked.

---

# NikolaKozina J2534 implementation

```text
j2534/nikolakozina-j2534/
```

This is an open-source J2534 implementation for the Tactrix OpenPort 2.0.

It can be built natively on Linux.

The implementation uses libusb to communicate with the device.

Important source:

```text
j2534/j2534.c
j2534/j2534.h
```

The project has successfully built on CachyOS using:

```text
make
```

producing:

```text
j2534.so
```

---

# Nikola J2534 API

The Nikola header directly defines a C-facing J2534 implementation.

Observed error identifiers include:

```text
J2534_NOERROR
J2534_ERR_NOT_SUPPORTED
J2534_ERR_INVALID_CHANNEL_ID
J2534_ERR_INVALID_PROTOCOL_ID
J2534_ERR_NULL_PARAMETER
J2534_ERR_INVALID_IOCTL_VALUE
J2534_ERR_INVALID_FLAGS
J2534_ERR_FAILED
J2534_ERR_DEVICE_NOT_CONNECTED
J2534_ERR_TIMEOUT
J2534_ERR_INVALID_MSG
J2534_ERR_INVALID_TIME_INTERVAL
J2534_ERR_EXCEEDED_LIMIT
J2534_ERR_INVALID_MSG_ID
J2534_ERR_DEVICE_IN_USE
J2534_ERR_INVALID_IOCTL_ID
J2534_ERR_BUFFER_EMPTY
J2534_ERR_BUFFER_FULL
J2534_ERR_BUFFER_OVERFLOW
J2534_ERR_PIN_INVALID
J2534_ERR_CHANNEL_IN_USE
J2534_ERR_MSG_PROTOCOL_ID
J2534_ERR_INVALID_FILTER_ID
J2534_ERR_NO_FLOW_CONTROL
J2534_ERR_NOT_UNIQUE
J2534_ERR_INVALID_BAUDRATE
J2534_ERR_INVALID_DEVICE_ID
```

Observed IOCTL identifiers include:

```text
J2534_GET_CONFIG
J2534_SET_CONFIG
J2534_READ_VBATT
J2534_FIVE_BAUD_INIT
J2534_FAST_INIT
J2534_CLEAR_TX_BUFFER
J2534_CLEAR_RX_BUFFER
J2534_CLEAR_PERIODIC_MSGS
J2534_CLEAR_MSG_FILTERS
J2534_CLEAR_FUNCT_MSG_LOOKUP_TABLE
J2534_ADD_TO_FUNCT_MSG_LOOKUP_TABLE
J2534_DELETE_FROM_FUNCT_MSG_LOOUP_TABLE
J2534_READ_PROG_VOLTAGE
```

---

# Nikola J2534 structures

The public header defines structures including:

```text
SCONFIG
SCONFIG_LIST
PASSTHRU_MSG
```

The implementation's `PASSTHRU_MSG` contains fields for:

```text
ProtocolID
RxStatus
TxFlags
Timestamp
DataSize
ExtraDataIndex
Data
```

Its message data buffer is 4128 bytes.

---

# Nikola exported functions

The implementation exposes functions corresponding to:

```text
PassThruOpen
PassThruClose
PassThruConnect
PassThruDisconnect
PassThruReadMsgs
PassThruWriteMsgs
PassThruStartPeriodicMsg
PassThruStopPeriodicMsg
PassThruStartMsgFilter
PassThruStopMsgFilter
PassThruSetProgrammingVoltage
PassThruReadVersion
PassThruGetLastError
PassThruIoctl
```

---

# Header differences

The Tactrix and Nikola headers should not be assumed to be ABI-identical merely
because they both expose J2534 concepts.

The Tactrix material contains a sample-side C++ loader/wrapper.

Nikola's header describes the exported C implementation itself.

Function prototypes must therefore be checked individually.

For example, observed `PassThruReadVersion` argument ordering differs between
the two reference headers.

Never cast incompatible function pointers merely because function names match.

Verify the exact API contract of the provider being called.

---

# Protocol constants

At the current point in investigation, searching Nikola's public `j2534.h` for:

```text
ISO9141
ISO14230
CAN
ISO15765
```

does not produce named protocol constants.

The same header does expose:

```text
J2534_FIVE_BAUD_INIT
J2534_FAST_INIT
PassThruConnect(...)
```

Before constructing a `PassThruConnect()` hardware test, inspect:

```text
j2534.c
```

and the official Tactrix definitions to determine the exact protocol identifiers
expected by the implementation.

Do not guess protocol IDs.

---

# Native Linux J2534 test

A small hardware smoke test is retained at:

```text
j2534/tests/j2534-open-test.c
```

Its purpose is intentionally narrow.

It currently tests:

```text
PassThruOpen
PassThruClose
```

The OpenPort appears under Linux as:

```text
0403:cc4d Future Technology Devices International, Ltd OpenPort 2.0
```

A successful normal-user test has returned:

```text
PassThruOpen returned: 0
Device ID: <non-zero>
PassThruClose returned: 0
```

Current native J2534 status:

```text
PassThruOpen       CONFIRMED
PassThruClose      CONFIRMED
PassThruConnect    NOT YET VERIFIED
```

---

# Linux USB permissions

The OpenPort is accessed as a raw USB device through libusb.

A dedicated group is used:

```text
openport
```

Example udev rule:

```text
SUBSYSTEM=="usb", ATTR{idVendor}=="0403", ATTR{idProduct}=="cc4d", MODE="0660", GROUP="openport"
```

After applying the rule and adding the development user to the group, the
device node was verified as:

```text
owner=root
group=openport
mode=660
```

The J2534 open/close test then succeeded without root privileges.

---

# Build artefacts

Do not commit generated build artefacts from reference implementations unless
there is a specific reason.

Examples:

```text
*.o
*.so
```

Recommended ignore entries:

```gitignore
reference/j2534/nikolakozina-j2534/j2534/*.o
reference/j2534/nikolakozina-j2534/j2534/*.so
reference/j2534/tests/j2534-open-test
```

Keep:

```text
reference/j2534/tests/j2534-open-test.c
```

because it is a useful reproducible test.

---

# TuneECU Android reference

Detailed Android documentation is contained in:

```text
tuneecu-android/README.md
```

The Android reference set intentionally includes only communication-related
material rather than the entire application.

It contains:

```text
jadx/
smali/
resources/
reports/
```

---

# Android JADX / Smali mapping

Some classes were renamed by JADX.

Confirmed mappings include:

```text
p053b.p054a.p055a.C1143g -> b.a.a.g
p053b.p054a.p055a.C1145i -> b.a.a.i
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

When JADX reconstructs ambiguous or broken control flow, verify the behaviour
against Smali.

---

# D2XX versus J2534

This is the central OpenShimFTDI engineering problem.

TuneECU expects a relatively low-level FTDI/D2XX serial interface.

J2534 exposes a higher-level vehicle communication interface.

Therefore the following assumption is unsafe:

```text
one FT_* call
      =
one PassThru* call
```

For example, TuneECU may express an initialization operation through a sequence
such as:

```text
FT_SetBaudRate
FT_SetBreakOn
delay
FT_SetBreakOff
FT_Write
```

A J2534 provider may represent the same underlying vehicle-bus operation through
concepts such as:

```text
PassThruConnect
PassThruIoctl
SET_CONFIG
FAST_INIT
FIVE_BAUD_INIT
```

OpenShimFTDI may therefore need to identify the semantic meaning of some D2XX
sequences rather than performing naïve one-call-to-one-call translation.

Any semantic translation must be supported by evidence.

---

# OpenShimFTDI responsibility boundary

The guiding design principle is:

**TuneECU remains the brains. OpenShimFTDI remains the transport bridge.**

TuneECU should remain responsible for:

- automatic probing
- ECU identification
- motorcycle/model identification
- protocol state
- ECU request generation
- ECU response interpretation
- diagnostics
- sensor decoding
- security access
- maintenance functions
- map logic

OpenShimFTDI should be responsible for:

- presenting the D2XX API TuneECU expects
- maintaining relevant D2XX state
- translating transport operations
- forwarding requests to the selected backend
- returning ECU data using D2XX semantics
- timeout/error translation
- transport logging

Avoid reproducing TuneECU's ECU protocol engine inside OpenShimFTDI.

---

# Backend architecture

OpenShimFTDI should not unnecessarily lock itself to a single transport
implementation.

A conceptual backend interface may include operations such as:

```text
backend_open
backend_close
backend_connect
backend_disconnect
backend_read
backend_write
backend_ioctl
backend_set_config
```

Possible implementations include:

```text
Windows J2534 provider backend
Linux native helper backend
Direct OpenPort/libusb backend
```

The exact abstraction should follow observed requirements rather than being
over-designed before the TuneECU transport behaviour is understood.

---

# Windows J2534 route

A possible Windows/Wine path is:

```text
TuneECU.exe
    |
    v
OpenShimFTDI.dll
    |
    v
J2534 provider
    |
    v
OpenPort 2.0
```

The original Tactrix Windows provider is:

```text
op20pt32.dll
```

This path remains useful for investigation.

However, Wine compatibility with the complete vendor USB/kernel-driver stack
must not be assumed merely because the DLL can be installed.

---

# Native Linux route

Because native OpenPort access has already been demonstrated, another promising
architecture is:

```text
TuneECU.exe under Wine
        |
        v
OpenShimFTDI.dll
        |
        v
local IPC
        |
        v
native Linux helper
        |
        v
J2534 / libusb
        |
        v
OpenPort 2.0
```

Potential advantages:

- Linux controls USB natively
- no dependency on Windows kernel-driver emulation
- OpenShimFTDI remains small
- the native backend can be tested independently
- J2534/OpenPort behaviour can be debugged without TuneECU running
- Wine only needs to communicate with the local helper

This is currently an architectural option rather than a finalized requirement.

---

# Existing OpenShimFTDI shim

The existing OpenShimFTDI implementation began as an FTDI/D2XX compatibility
and tracing harness.

It should not be mistaken for a completed OpenPort backend.

The original implementation provides functionality such as:

- fake FTDI device discovery
- device open/close
- D2XX configuration
- logging
- read/write buffering
- synthetic local loopback

The existing loopback behaviour copies bytes written through `FT_Write()` into
the local RX queue.

That is useful for API testing but does not represent real ECU communication.

It can also interfere with connection analysis because TuneECU may interpret its
own transmitted request as an ECU response.

A no-loopback/log-only mode is therefore useful when collecting real TuneECU
connection traces.

---

# Initial implementation priorities

The preferred milestone order is:

```text
1. D2XX discovery/open compatibility
2. backend OpenPort open/close
3. PassThruConnect
4. configuration/baud handling
5. K-Line initialization
6. TuneECU automatic ECU identification
7. DTC reading
8. live sensor data
9. DTC clearing
10. TPS/adaptation/maintenance operations
11. map reading
12. map programming
```

Current native hardware status:

```text
OpenPort USB detection    CONFIRMED
libusb access             CONFIRMED
PassThruOpen              CONFIRMED
PassThruClose             CONFIRMED
PassThruConnect           NOT YET VERIFIED
K-Line initialization     NOT YET VERIFIED
ECU identification        NOT YET VERIFIED
```

---

# Diagnostics before programming

The first practical target is reliable diagnostics.

Priority functionality:

```text
connect
identify ECU
read DTCs
read live data
clear DTCs
perform required maintenance/adaptation functions
```

Map flashing is deliberately lower priority.

Do not attempt ECU programming simply because basic transport communication
works.

A transport error during a diagnostic request usually results in a failed
request.

A transport error during ECU erase/programming can leave the ECU in a partially
programmed or unusable state.

Transport reliability should therefore be demonstrated before flashing is
attempted.

---

# Files that should generally not be committed

Generated binaries and vendor binaries should not be committed without a clear
reason.

Examples:

```text
*.o
*.so
*.dll
*.sys
*.exe
```

Original vendor binaries may still be kept separately on the development
machine for local investigation.

Do not redistribute them without checking their license terms.

---

# Licensing and provenance

This reference tree contains material from multiple sources.

Do not assume a single license applies to the entire directory.

Categories include:

- recovered TuneECU source
- TuneECU application data
- Tactrix developer material
- Tactrix driver metadata
- NikolaKozina J2534 source
- locally generated traces
- locally written test programs

Preserve upstream copyright and license notices.

Do not remove provenance comments from copied reference files.

Recovered TuneECU material retains its original authorship.

No new license claim is made over recovered source.

---

# Development questions

Before implementing a behaviour in OpenShimFTDI, ask:

```text
What evidence says TuneECU expects this?
```

Then:

```text
What evidence says the backend can provide this?
```

Then:

```text
What translation is required between those two behaviours?
```

If any answer is uncertain, record that uncertainty.

---

# Rules for implementation

Do not:

- hard-code a motorcycle model
- hard-code Daytona-specific detection
- fabricate ECU replies
- bypass TuneECU's automatic probe logic
- assume Android behaviour equals Windows behaviour
- assume D2XX and J2534 are equivalent abstractions
- invent J2534 constants
- assume similarly named APIs have identical prototypes
- treat synthetic loopback as ECU communication
- begin ECU flashing before transport reliability is demonstrated

Prefer:

- Windows TuneECU source
- real runtime traces
- official vendor definitions
- reproducible hardware tests
- explicit evidence labels
- small independently testable transport components

---

# Guiding principle

**TuneECU handles ECU logic.**

**OpenShimFTDI handles compatibility and transport.**

Preserve TuneECU's existing automatic detection and protocol engine wherever
possible.

Translate only what must be translated between D2XX and the selected OpenPort
backend.
```

The Windows transport/protocol descriptions above follow the supplied source analysis, which identifies `ISOFT.cs` as the transport owner and `ISORead.cs` as the initialization/protocol/diagnostics owner.  The J2534 API notes follow the supplied Tactrix-vs-Nikola header diff, including the Nikola error/IOCTL definitions and direct C API.   
