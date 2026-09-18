# TuneECU Android unresolved questions

This list is ordered by effect on safe interoperability work.

1. **Runtime detection graph:** What exact probe, response signature, active profile, ECU classification, and next command transitions are in `MainActivity.W5`? The Java output has broken control flow, so the answer must come from direct Smali control-flow analysis.
2. **Calibration-to-communications link:** How does the character returned from a record such as `20417:7` affect ECU selection or protocol selection? The current evidence proves the record decoder and the map metadata index, but it does not prove a direct link to the separate ECU selector decoder.
3. **Profile ownership:** Which motorcycle and ECU selector flags use each active profile from 0 through 21 at run time, including probe fallbacks and detected-generation changes?
4. **Direct USB framing:** What named protocol uses the short and extended frame-length rules in `C2252uc.run`, and how do its header and checksum fields work?
5. **K-Line initialization:** Which profiles use 5-baud init, fast init, or a custom wake-up, and what are the exact direct-FTDI timing rules?
6. **UDS confirmation:** Which CAN profiles use ISO-TP and UDS after the first `10 01` or `10 03` request, and which profiles use manufacturer-specific services instead?
7. **Diagnostic operations:** What are the exact requests, expected replies, preconditions, and decoders for VIN, calibration ID, firmware ID, sensors, DTCs, adaptations, service reset, ABS, TPMS, and actuator tests?
8. **Map reading:** What session, address format, block size, retry policy, and checksum process does each ECU family use?
9. **Programming:** What are the complete erase, request-download, transfer, transfer-exit, verification, reset, and recovery state machines for each ECU family?
10. **Security access:** Where are seed-to-key algorithms implemented, what are their inputs and outputs, and which ECU families use each algorithm?
11. **Adapter limits:** What minimum firmware and command subsets are required for STN11, STN22, OBDLink, UCSI-2000, UCSI-2100, and vLinker devices?
12. **Tactrix compatibility:** What USB VID/PID and interfaces does the user's OpenPort 2.0 Rev H expose, and does it match the APK's D2xx filter? The APK has no explicit `Tactrix` or `OpenPort` string.
13. **JADX failures:** What does `MainActivity.m8287L8` do, and do the other methods with restructure warnings hide communication behavior?
14. **OpenECU gap analysis:** Which confirmed Android capabilities are absent or different in the Windows 2.5.8-derived Rust project? This comparison must start only after the Android protocol graph is more complete.
15. **Rust architecture:** What final module and type boundaries best represent the confirmed adapter, link, framing, diagnostic, ECU, and motorcycle layers? No architecture is final until the protocol evidence is mature.
