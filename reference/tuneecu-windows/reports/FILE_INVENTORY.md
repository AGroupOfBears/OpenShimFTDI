# File inspection inventory

Every file below was read. Text files were parsed or indexed. Binary files were checked by signature and hash. Full hashes and member records are in `reference/source-inventory.json`.

Generated files are retained as evidence. They are not Rust build inputs.

## TuneECU 2.5.5 Clean

| File | Bytes | Inspection | Owner |
| --- | ---: | --- | --- |
| `TuneECU/TuneECU/AboutBox.cs` | 9524 | text | openecu-app |
| `TuneECU/TuneECU/IDraw.cs` | 67758 | text | openecu-app |
| `TuneECU/TuneECU/IMap.cs` | 90398 | text | openecu-maps |
| `TuneECU/TuneECU/ISOFT.cs` | 37542 | text | openecu-transport |
| `TuneECU/TuneECU/ISOMain.cs` | 357482 | text | openecu-core + openecu-app |
| `TuneECU/TuneECU/ISORead.cs` | 158301 | text | openecu-protocol |
| `TuneECU/TuneECU/ISensor.cs` | 24032 | text | openecu-diagnostics |
| `TuneECU/TuneECU/Infos.cs` | 12795 | text | openecu-app |
| `TuneECU/TuneECU/KeyStates.cs` | 72 | text | openecu-app |
| `TuneECU/TuneECU/Logs.cs` | 7026 | text | openecu-app |
| `TuneECU/TuneECU/Program.cs` | 1355 | text | openecu-app |
| `TuneECU/TuneECU/QueryForm.cs` | 38301 | text | openecu-core + openecu-app |
| `TuneECU/TuneECU/Warning.cs` | 17109 | text | openecu-app |
| `TuneECU/TuneECU/eMessage.cs` | 189 | text | openecu-protocol |
| `TuneECU/TuneECU/eMode.cs` | 740 | text | openecu-protocol |
| `TuneECU/TuneECU/mOpenFileDialog.cs` | 4407 | text | openecu-app |
| `TuneECU/TuneECU.AboutBox.resx` | 44923 | text | openecu-app |
| `TuneECU/TuneECU.Controls/AddonWindowLocation.cs` | 91 | text | openecu-app |
| `TuneECU/TuneECU.Controls/ControlsID.cs` | 337 | text | openecu-app |
| `TuneECU/TuneECU.Controls/OpenFileDialogEx.cs` | 15872 | text | openecu-app |
| `TuneECU/TuneECU.ISOMain.resx` | 142577 | text | openecu-app |
| `TuneECU/TuneECU.Infos.resx` | 135853 | text | openecu-app |
| `TuneECU/TuneECU.Logs.resx` | 189275 | text | openecu-app |
| `TuneECU/TuneECU.OS/ButtonStyle.cs` | 642 | text | openecu-app |
| `TuneECU/TuneECU.OS/ChildFromPointFlags.cs` | 148 | text | openecu-app |
| `TuneECU/TuneECU.OS/ComboBoxStyles.cs` | 382 | text | openecu-app |
| `TuneECU/TuneECU.OS/DefaultViewType.cs` | 143 | text | openecu-app |
| `TuneECU/TuneECU.OS/DialogChangeProperties.cs` | 266 | text | openecu-app |
| `TuneECU/TuneECU.OS/DialogChangeStatus.cs` | 301 | text | openecu-app |
| `TuneECU/TuneECU.OS/FolderViewMode.cs` | 144 | text | openecu-app |
| `TuneECU/TuneECU.OS/HitTest.cs` | 561 | text | openecu-app |
| `TuneECU/TuneECU.OS/ImeNotify.cs` | 360 | text | openecu-app |
| `TuneECU/TuneECU.OS/Msg.cs` | 4638 | text | openecu-app |
| `TuneECU/TuneECU.OS/NCCALCSIZE_PARAMS.cs` | 162 | text | openecu-app |
| `TuneECU/TuneECU.OS/NMHDR.cs` | 132 | text | openecu-app |
| `TuneECU/TuneECU.OS/OFNOTIFY.cs` | 157 | text | openecu-app |
| `TuneECU/TuneECU.OS/POINT.cs` | 231 | text | openecu-app |
| `TuneECU/TuneECU.OS/RECT.cs` | 669 | text | openecu-app |
| `TuneECU/TuneECU.OS/SWP_Flags.cs` | 327 | text | openecu-app |
| `TuneECU/TuneECU.OS/SetWindowPosFlags.cs` | 426 | text | openecu-app |
| `TuneECU/TuneECU.OS/StaticControlStyles.cs` | 767 | text | openecu-app |
| `TuneECU/TuneECU.OS/WINDOWINFO.cs` | 329 | text | openecu-app |
| `TuneECU/TuneECU.OS/WINDOWPOS.cs` | 328 | text | openecu-app |
| `TuneECU/TuneECU.OS/Win32.cs` | 3568 | text | openecu-app |
| `TuneECU/TuneECU.OS/WindowExStyles.cs` | 634 | text | openecu-app |
| `TuneECU/TuneECU.OS/WindowStyles.cs` | 783 | text | openecu-app |
| `TuneECU/TuneECU.OS/ZOrderPos.cs` | 126 | text | openecu-app |
| `TuneECU/TuneECU.Properties/Resources.cs` | 11575 | text | openecu-app |
| `TuneECU/TuneECU.Properties/Settings.cs` | 2026 | text | openecu-app |
| `TuneECU/TuneECU.Properties.Resources.resx` | 461746 | text | openecu-app |
| `TuneECU/TuneECU.Resources.grab.cur` | 326 | binary-signature-and-hash | openecu-app |
| `TuneECU/TuneECU.Warning.resx` | 4866 | text | openecu-app |
| `TuneECU/TuneECU.csproj` | 2322 | text | openecu-app |
| `TuneECU/app.ico` | 97566 | binary-signature-and-hash | openecu-app |
| `TuneECU/bin/Debug/TuneLibrary.dll` | 275456 | binary-signature-and-hash | reference-build-output |
| `TuneECU/bin/Debug/TuneLibrary.pdb` | 9484 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.AboutBox.resources` | 22293 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.ISOMain.resources` | 111370 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.Infos.resources` | 98132 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.Logs.resources` | 137172 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.Properties.Resources.resources` | 221661 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.Resources.grab.cur` | 326 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.TuneECU.Warning.resources` | 3142 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/TuneECU.csproj.FilesWrittenAbsolute.txt` | 1504 | text | reference-build-output |
| `TuneECU.sln` | 1368 | text | openecu-app |
| `TuneLibrary/Properties/AssemblyInfo.cs` | 579 | text | openecu-app |
| `TuneLibrary/Tune.cs` | 212384 | text | openecu-models |
| `TuneLibrary/TuneLibrary.csproj` | 1610 | text | openecu-app |
| `TuneLibrary/bin/Debug/TuneLibrary.dll` | 275456 | binary-signature-and-hash | reference-build-output |
| `TuneLibrary/bin/Debug/TuneLibrary.pdb` | 9484 | binary-signature-and-hash | reference-build-output |
| `TuneLibrary/obj/Debug/TuneLibrary.csproj.FilesWrittenAbsolute.txt` | 624 | text | reference-build-output |
| `TuneLibrary/obj/Debug/TuneLibrary.dll` | 275456 | binary-signature-and-hash | reference-build-output |
| `TuneLibrary/obj/Debug/TuneLibrary.pdb` | 9484 | binary-signature-and-hash | reference-build-output |

## TuneECU 2.5.8 Clean

| File | Bytes | Inspection | Owner |
| --- | ---: | --- | --- |
| `TuneECU/Properties/AssemblyInfo.cs` | 698 | text | openecu-app |
| `TuneECU/TuneECU/AboutBox.cs` | 9521 | text | openecu-app |
| `TuneECU/TuneECU/IDraw.cs` | 67757 | text | openecu-app |
| `TuneECU/TuneECU/IMap.cs` | 90395 | text | openecu-maps |
| `TuneECU/TuneECU/ISOFT.cs` | 37582 | text | openecu-transport |
| `TuneECU/TuneECU/ISOMain.cs` | 360310 | text | openecu-core + openecu-app |
| `TuneECU/TuneECU/ISORead.cs` | 158725 | text | openecu-protocol |
| `TuneECU/TuneECU/ISensor.cs` | 24192 | text | openecu-diagnostics |
| `TuneECU/TuneECU/Infos.cs` | 12792 | text | openecu-app |
| `TuneECU/TuneECU/KeyStates.cs` | 69 | text | openecu-app |
| `TuneECU/TuneECU/Logs.cs` | 7023 | text | openecu-app |
| `TuneECU/TuneECU/Program.cs` | 1352 | text | openecu-app |
| `TuneECU/TuneECU/QueryForm.cs` | 38298 | text | openecu-core + openecu-app |
| `TuneECU/TuneECU/Warning.cs` | 17106 | text | openecu-app |
| `TuneECU/TuneECU/eMessage.cs` | 186 | text | openecu-protocol |
| `TuneECU/TuneECU/eMode.cs` | 737 | text | openecu-protocol |
| `TuneECU/TuneECU/mOpenFileDialog.cs` | 4404 | text | openecu-app |
| `TuneECU/TuneECU.AboutBox.resx` | 42251 | text | openecu-app |
| `TuneECU/TuneECU.Controls/AddonWindowLocation.cs` | 88 | text | openecu-app |
| `TuneECU/TuneECU.Controls/ControlsID.cs` | 334 | text | openecu-app |
| `TuneECU/TuneECU.Controls/OpenFileDialogEx.cs` | 15869 | text | openecu-app |
| `TuneECU/TuneECU.ISOMain.resx` | 142577 | text | openecu-app |
| `TuneECU/TuneECU.Infos.resx` | 135853 | text | openecu-app |
| `TuneECU/TuneECU.Logs.resx` | 189275 | text | openecu-app |
| `TuneECU/TuneECU.OS/ButtonStyle.cs` | 639 | text | openecu-app |
| `TuneECU/TuneECU.OS/ChildFromPointFlags.cs` | 145 | text | openecu-app |
| `TuneECU/TuneECU.OS/ComboBoxStyles.cs` | 379 | text | openecu-app |
| `TuneECU/TuneECU.OS/DefaultViewType.cs` | 140 | text | openecu-app |
| `TuneECU/TuneECU.OS/DialogChangeProperties.cs` | 263 | text | openecu-app |
| `TuneECU/TuneECU.OS/DialogChangeStatus.cs` | 298 | text | openecu-app |
| `TuneECU/TuneECU.OS/FolderViewMode.cs` | 141 | text | openecu-app |
| `TuneECU/TuneECU.OS/HitTest.cs` | 558 | text | openecu-app |
| `TuneECU/TuneECU.OS/ImeNotify.cs` | 357 | text | openecu-app |
| `TuneECU/TuneECU.OS/Msg.cs` | 4635 | text | openecu-app |
| `TuneECU/TuneECU.OS/NCCALCSIZE_PARAMS.cs` | 159 | text | openecu-app |
| `TuneECU/TuneECU.OS/NMHDR.cs` | 129 | text | openecu-app |
| `TuneECU/TuneECU.OS/OFNOTIFY.cs` | 154 | text | openecu-app |
| `TuneECU/TuneECU.OS/POINT.cs` | 228 | text | openecu-app |
| `TuneECU/TuneECU.OS/RECT.cs` | 666 | text | openecu-app |
| `TuneECU/TuneECU.OS/SWP_Flags.cs` | 324 | text | openecu-app |
| `TuneECU/TuneECU.OS/SetWindowPosFlags.cs` | 423 | text | openecu-app |
| `TuneECU/TuneECU.OS/StaticControlStyles.cs` | 764 | text | openecu-app |
| `TuneECU/TuneECU.OS/WINDOWINFO.cs` | 326 | text | openecu-app |
| `TuneECU/TuneECU.OS/WINDOWPOS.cs` | 325 | text | openecu-app |
| `TuneECU/TuneECU.OS/Win32.cs` | 3565 | text | openecu-app |
| `TuneECU/TuneECU.OS/WindowExStyles.cs` | 631 | text | openecu-app |
| `TuneECU/TuneECU.OS/WindowStyles.cs` | 780 | text | openecu-app |
| `TuneECU/TuneECU.OS/ZOrderPos.cs` | 123 | text | openecu-app |
| `TuneECU/TuneECU.Properties/Resources.cs` | 11572 | text | openecu-app |
| `TuneECU/TuneECU.Properties/Settings.cs` | 2023 | text | openecu-app |
| `TuneECU/TuneECU.Properties.Resources.resx` | 438062 | text | openecu-app |
| `TuneECU/TuneECU.Resources.grab.cur` | 326 | binary-signature-and-hash | openecu-app |
| `TuneECU/TuneECU.Warning.resx` | 4866 | text | openecu-app |
| `TuneECU/TuneECU.csproj` | 1010 | text | openecu-app |
| `TuneECU/app.ico` | 97566 | binary-signature-and-hash | openecu-app |
| `TuneECU/obj/Debug/net20/TuneECU.GeneratedMSBuildEditorConfig.editorconfig` | 660 | text | reference-build-output |
| `TuneECU/obj/Debug/net20/TuneECU.assets.cache` | 536 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/net20/TuneECU.csproj.AssemblyReference.cache` | 2730 | binary-signature-and-hash | reference-build-output |
| `TuneECU/obj/Debug/net20/TuneECU.exe.withSupportedRuntime.config` | 142 | text | reference-build-output |
| `TuneECU/obj/TuneECU.csproj.nuget.dgspec.json` | 2003 | text | reference-build-output |
| `TuneECU/obj/TuneECU.csproj.nuget.g.props` | 1127 | text | reference-build-output |
| `TuneECU/obj/TuneECU.csproj.nuget.g.targets` | 570 | text | reference-build-output |
| `TuneECU/obj/project.assets.json` | 6611 | text | reference-build-output |
| `TuneECU/obj/project.nuget.cache` | 557 | text | reference-build-output |
| `TuneLibrary/Properties/AssemblyInfo.cs` | 579 | text | openecu-app |
| `TuneLibrary/TuneLibrary/Tune.cs` | 218437 | text | openecu-models |
| `TuneLibrary/TuneLibrary.csproj` | 464 | text | openecu-app |
| `TuneLibrary/obj/Debug/net20/TuneLibrary.GeneratedMSBuildEditorConfig.editorconfig` | 425 | text | reference-build-output |
| `TuneLibrary/obj/Debug/net20/TuneLibrary.assets.cache` | 536 | binary-signature-and-hash | reference-build-output |
| `TuneLibrary/obj/Debug/net20/TuneLibrary.csproj.AssemblyReference.cache` | 1963 | binary-signature-and-hash | reference-build-output |
| `TuneLibrary/obj/TuneLibrary.csproj.nuget.dgspec.json` | 2043 | text | reference-build-output |
| `TuneLibrary/obj/TuneLibrary.csproj.nuget.g.props` | 1127 | text | reference-build-output |
| `TuneLibrary/obj/TuneLibrary.csproj.nuget.g.targets` | 570 | text | reference-build-output |
| `TuneLibrary/obj/project.assets.json` | 6635 | text | reference-build-output |
| `TuneLibrary/obj/project.nuget.cache` | 565 | text | reference-build-output |

