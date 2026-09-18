    .field  private static  unsigned int8[] rBuffer
    .field  private static  int32 rLength
    .field  private static  int32 rStart
    .field  private static  int32 xStart
    .field  private static  int32 wLength
    .field  private static  unsigned int32 rIndex
    .field  private static  int32 sIndex
    .field  private static  bool eEcho
    .field  private static  unsigned int8[] wBuffer
    .field  private static  unsigned int8[] wByte
    .field  private static  int32 lnBuffer
    .field  private static  int32 pxBuffer
    .field  private static  int32 interval

    // method line 447
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_CreateDeviceInfoList" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_CreateDeviceInfoList (unsigned int32& lpdwNumDevs)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_CreateDeviceInfoList

    // method line 448
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_ListDevices" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_ListDevices (void* pvArg1, void* pvArg2, unsigned int32 dwFlags)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_ListDevices

    // method line 449
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_ListDevices" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_ListDevices (unsigned int32 pvArg1, void* pvArg2, unsigned int32 dwFlags)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_ListDevices

    // method line 450
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_Open" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_Open (unsigned int32 uiPort, unsigned int32& ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_Open

    // method line 451
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_OpenEx" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_OpenEx (void* pvArg1, unsigned int32 dwFlags, unsigned int32& ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_OpenEx

    // method line 452
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_Close" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_Close (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_Close

    // method line 453
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_Read" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_Read (unsigned int32 ftHandle, void* lpBuffer, unsigned int32 dwBytesToRead, unsigned int32& lpdwBytesReturned)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_Read

    // method line 454
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_Write" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_Write (unsigned int32 ftHandle, void* lpBuffer, unsigned int32 dwBytesToRead, unsigned int32& lpdwBytesWritten)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_Write

    // method line 455
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetBaudRate" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetBaudRate (unsigned int32 ftHandle, unsigned int32 dwBaudRate)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetBaudRate

    // method line 456
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetDataCharacteristics" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetDataCharacteristics (unsigned int32 ftHandle, unsigned int8 uWordLength, unsigned int8 uStopBits, unsigned int8 uParity)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetDataCharacteristics

    // method line 457
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetFlowControl" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetFlowControl (unsigned int32 ftHandle, unsigned int16 usFlowControl, unsigned int8 uXon, unsigned int8 uXoff)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetFlowControl

    // method line 458
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetDtr" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetDtr (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetDtr

    // method line 459
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_ClrDtr" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_ClrDtr (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_ClrDtr

    // method line 460
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetRts" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetRts (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetRts

    // method line 461
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_ClrRts" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_ClrRts (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_ClrRts

    // method line 462
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_Purge" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_Purge (unsigned int32 ftHandle, unsigned int32 dwMask)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_Purge

    // method line 463
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetTimeouts" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetTimeouts (unsigned int32 ftHandle, unsigned int32 dwReadTimeout, unsigned int32 dwWriteTimeout)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetTimeouts

    // method line 464
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetBreakOn" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetBreakOn (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetBreakOn

    // method line 465
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetBreakOff" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetBreakOff (unsigned int32 ftHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetBreakOff

    // method line 466
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_GetStatus" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_GetStatus (unsigned int32 ftHandle, unsigned int32& lpdwAmountInRxQueue, unsigned int32& lpdwAmountInTxQueue, unsigned int32& lpdwEventStatus)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_GetStatus

    // method line 467
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetEventNotification" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetEventNotification (unsigned int32 ftHandle, unsigned int32 dwEventMask, void* pvArg)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetEventNotification

    // method line 468
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetLatencyTimer" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetLatencyTimer (unsigned int32 ftHandle, unsigned int8 ucTimer)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetLatencyTimer

    // method line 469
    .method private static hidebysig pinvokeimpl ("FTD2XX.dll" as "FT_SetUSBParameters" winapi )
           default valuetype TuneECU.ISOFT/FT_STATUS FT_SetUSBParameters (unsigned int32 ftHandle, unsigned int32 dwInTransferSize, unsigned int32 dwOutTransferSize)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::FT_SetUSBParameters

    // method line 470
    .method private static hidebysig pinvokeimpl ("kernel32.dll" as "CreateEvent" winapi lasterr )
           default native int CreateEvent (native int lpEventAttributes, bool bManualReset, bool bInitialState, string spName)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::CreateEvent

    // method line 471
    .method private static hidebysig pinvokeimpl ("kernel32.dll" as "WaitForSingleObject" winapi lasterr )
           default int32 WaitForSingleObject (native int hHandle, unsigned int32 dwMilliseconds)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::WaitForSingleObject

    // method line 472
    .method private static hidebysig pinvokeimpl ("kernel32.dll" as "CloseHandle" winapi lasterr )
           default bool CloseHandle (native int hHandle)  cil managed preservesig 
    {
        // Method begins at RVA 0x0
    } // end of method ISOFT::CloseHandle

    // method line 473
    .method public static hidebysig 
           default void SetMessage (valuetype TuneECU.eMessage message)  cil managed 
    {
        // Method begins at RVA 0x383a1
	// Code size 7 (0x7)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  stsfld valuetype TuneECU.eMessage TuneECU.ISOFT::mMessage
	IL_0006:  ret 
    } // end of method ISOFT::SetMessage

    // method line 474
    .method public static hidebysig 
           default void InitializeSerialPort ()  cil managed 
    {
        // Method begins at RVA 0x383ac
	// Code size 303 (0x12f)
	.maxstack 4
	.locals init (
		string	V_0,
		int32	V_1,
		int32	V_2,
		string[]	V_3,
		int32	V_4)
	IL_0000:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_0005:  callvirt instance valuetype [System]System.IO.Ports.Parity class TuneECU.Properties.Settings::get_Parity()
	IL_000a:  box [System]System.IO.Ports.Parity
	IL_000f:  callvirt instance string object::ToString()
	IL_0014:  stsfld string TuneECU.ISOFT::cmbParity
	IL_0019:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_001e:  callvirt instance valuetype [System]System.IO.Ports.StopBits class TuneECU.Properties.Settings::get_StopBits()
	IL_0023:  box [System]System.IO.Ports.StopBits
	IL_0028:  callvirt instance string object::ToString()
	IL_002d:  stsfld string TuneECU.ISOFT::cmbStopBits
	IL_0032:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_0037:  callvirt instance int32 class TuneECU.Properties.Settings::get_DataBits()
	IL_003c:  stloc.1 
	IL_003d:  ldloca.s 1
	IL_003f:  call instance string int32::ToString()
	IL_0044:  stsfld string TuneECU.ISOFT::cmbDataBits
	IL_0049:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_004e:  callvirt instance int32 class TuneECU.Properties.Settings::get_BaudRate()
	IL_0053:  stloc.2 
	IL_0054:  ldloca.s 2
	IL_0056:  call instance string int32::ToString()
	IL_005b:  stsfld string TuneECU.ISOFT::cmbBaudRate
	IL_0060:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0065:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_006a:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_006f:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Clear()
	IL_0074:  call string[] class [System]System.IO.Ports.SerialPort::GetPortNames()
	IL_0079:  stloc.3 
	IL_007a:  ldc.i4.0 
	IL_007b:  stloc.s 4
	IL_007d:  br.s IL_00a5

	IL_007f:  ldloc.3 
	IL_0080:  ldloc.s 4
	IL_0082:  ldelem.ref 
	IL_0083:  stloc.0 
	IL_0084:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0089:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_008e:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_0093:  ldloc.0 
	IL_0094:  call string class TuneECU.ISOFT::cleanCOM(string)
	IL_0099:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Add(object)
	IL_009e:  pop 
	IL_009f:  ldloc.s 4
	IL_00a1:  ldc.i4.1 
	IL_00a2:  add 
	IL_00a3:  stloc.s 4
	IL_00a5:  ldloc.s 4
	IL_00a7:  ldloc.3 
	IL_00a8:  ldlen 
	IL_00a9:  conv.i4 
	IL_00aa:  blt.s IL_007f

	IL_00ac:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_00b1:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_00b6:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_00bb:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_00c0:  callvirt instance string class TuneECU.Properties.Settings::get_PortName()
	IL_00c5:  callvirt instance bool class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Contains(object)
	IL_00ca:  brfalse.s IL_00e7

	IL_00cc:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_00d1:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_00d6:  call class TuneECU.Properties.Settings class TuneECU.Properties.Settings::get_Default()
	IL_00db:  callvirt instance string class TuneECU.Properties.Settings::get_PortName()
	IL_00e0:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
	IL_00e5:  br.s IL_010e

	IL_00e7:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_00ec:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_00f1:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_00f6:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::get_Count()
	IL_00fb:  ldc.i4.0 
	IL_00fc:  ble.s IL_010e

	IL_00fe:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0103:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_0108:  ldc.i4.0 
	IL_0109:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
	IL_010e:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_0113:  ldnull 
	IL_0114:  ldftn void class TuneECU.ISOFT::port_DataReceived(object, class [System]System.IO.Ports.SerialDataReceivedEventArgs)
	IL_011a:  newobj instance void class [System]System.IO.Ports.SerialDataReceivedEventHandler::'.ctor'(object, native int)
	IL_011f:  callvirt instance void class [System]System.IO.Ports.SerialPort::add_DataReceived(class [System]System.IO.Ports.SerialDataReceivedEventHandler)
	IL_0124:  ldsfld bool TuneECU.ISOMain::serialMode
	IL_0129:  call void class TuneECU.ISOMain::addSerialMenuItem(bool)
	IL_012e:  ret 
    } // end of method ISOFT::InitializeSerialPort

    // method line 475
    .method private static hidebysig 
           default string cleanCOM (string s)  cil managed 
    {
        // Method begins at RVA 0x384e8
	// Code size 103 (0x67)
	.maxstack 3
	.locals init (
		class [mscorlib]System.Text.StringBuilder	V_0,
		class [mscorlib]System.Text.StringBuilder	V_1,
		int32	V_2)
	IL_0000:  ldarg.0 
	IL_0001:  ldstr "COM"
	IL_0006:  callvirt instance int32 string::IndexOf(string)
	IL_000b:  ldc.i4.0 
	IL_000c:  bge.s IL_0010

	IL_000e:  ldarg.0 
	IL_000f:  ret 
	IL_0010:  ldarg.0 
	IL_0011:  newobj instance void class [mscorlib]System.Text.StringBuilder::'.ctor'(string)
	IL_0016:  stloc.0 
	IL_0017:  ldstr "COM"
	IL_001c:  newobj instance void class [mscorlib]System.Text.StringBuilder::'.ctor'(string)
	IL_0021:  stloc.1 
	IL_0022:  ldc.i4.3 
	IL_0023:  stloc.2 
	IL_0024:  br.s IL_0057

	IL_0026:  ldloc.0 
	IL_0027:  ldloc.2 
	IL_0028:  callvirt instance char class [mscorlib]System.Text.StringBuilder::get_Chars(int32)
	IL_002d:  ldc.i4.s 0x30
	IL_002f:  clt 
	IL_0031:  ldc.i4.0 
	IL_0032:  ceq 
	IL_0034:  ldloc.0 
	IL_0035:  ldloc.2 
	IL_0036:  callvirt instance char class [mscorlib]System.Text.StringBuilder::get_Chars(int32)
	IL_003b:  ldc.i4.s 0x39
	IL_003d:  cgt 
	IL_003f:  ldc.i4.0 
	IL_0040:  ceq 
	IL_0042:  and 
	IL_0043:  brfalse.s IL_0053

	IL_0045:  ldloc.1 
	IL_0046:  ldloc.0 
	IL_0047:  ldloc.2 
	IL_0048:  callvirt instance char class [mscorlib]System.Text.StringBuilder::get_Chars(int32)
	IL_004d:  callvirt instance class [mscorlib]System.Text.StringBuilder class [mscorlib]System.Text.StringBuilder::Append(char)
	IL_0052:  pop 
	IL_0053:  ldloc.2 
	IL_0054:  ldc.i4.1 
	IL_0055:  add 
	IL_0056:  stloc.2 
	IL_0057:  ldloc.2 
	IL_0058:  ldarg.0 
	IL_0059:  callvirt instance int32 string::get_Length()
	IL_005e:  blt.s IL_0026

	IL_0060:  ldloc.1 
	IL_0061:  callvirt instance string object::ToString()
	IL_0066:  ret 
    } // end of method ISOFT::cleanCOM

    // method line 476
    .method public static hidebysig 
           default void UpdateSerialPort ()  cil managed 
    {
        // Method begins at RVA 0x3855c
	// Code size 197 (0xc5)
	.maxstack 3
	.locals init (
		int32	V_0,
		int32	V_1,
		string	V_2,
		string[]	V_3,
		int32	V_4)
	IL_0000:  ldc.i4.m1 
	IL_0001:  stloc.0 
	IL_0002:  ldc.i4.0 
	IL_0003:  stloc.1 
	IL_0004:  br.s IL_0024

	IL_0006:  ldloc.1 
	IL_0007:  ldsfld class [System.Windows.Forms]System.Windows.Forms.ToolStripMenuItem[] TuneECU.ISOMain::m_serial
	IL_000c:  ldlen 
	IL_000d:  conv.i4 
	IL_000e:  beq.s IL_003b

	IL_0010:  ldsfld class [System.Windows.Forms]System.Windows.Forms.ToolStripMenuItem[] TuneECU.ISOMain::m_serial
	IL_0015:  ldloc.1 
	IL_0016:  ldelem.ref 
	IL_0017:  callvirt instance bool class [System.Windows.Forms]System.Windows.Forms.ToolStripMenuItem::get_Checked()
	IL_001c:  brfalse.s IL_0020

	IL_001e:  ldloc.1 
	IL_001f:  stloc.0 
	IL_0020:  ldloc.1 
	IL_0021:  ldc.i4.1 
	IL_0022:  add 
	IL_0023:  stloc.1 
	IL_0024:  ldloc.1 
	IL_0025:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_002a:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_002f:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_0034:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::get_Count()
	IL_0039:  blt.s IL_0006

	IL_003b:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0040:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_0045:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_004a:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Clear()
	IL_004f:  call string[] class [System]System.IO.Ports.SerialPort::GetPortNames()
	IL_0054:  stloc.3 
	IL_0055:  ldc.i4.0 
	IL_0056:  stloc.s 4
	IL_0058:  br.s IL_0080

	IL_005a:  ldloc.3 
	IL_005b:  ldloc.s 4
	IL_005d:  ldelem.ref 
	IL_005e:  stloc.2 
	IL_005f:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0064:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_0069:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_006e:  ldloc.2 
	IL_006f:  call string class TuneECU.ISOFT::cleanCOM(string)
	IL_0074:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Add(object)
	IL_0079:  pop 
	IL_007a:  ldloc.s 4
	IL_007c:  ldc.i4.1 
	IL_007d:  add 
	IL_007e:  stloc.s 4
	IL_0080:  ldloc.s 4
	IL_0082:  ldloc.3 
	IL_0083:  ldlen 
	IL_0084:  conv.i4 
	IL_0085:  blt.s IL_005a

	IL_0087:  ldloc.0 
	IL_0088:  ldc.i4.m1 
	IL_0089:  ceq 
	IL_008b:  ldc.i4.0 
	IL_008c:  ceq 
	IL_008e:  ldloc.0 
	IL_008f:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0094:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_0099:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	IL_009e:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::get_Count()
	IL_00a3:  clt 
	IL_00a5:  and 
	IL_00a6:  brfalse.s IL_00b8

	IL_00a8:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_00ad:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	IL_00b2:  ldloc.0 
	IL_00b3:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
	IL_00b8:  ldloc.0 
	IL_00b9:  ldc.i4.m1 
	IL_00ba:  ceq 
	IL_00bc:  ldc.i4.0 
	IL_00bd:  ceq 
	IL_00bf:  call void class TuneECU.ISOMain::addSerialMenuItem(bool)
	IL_00c4:  ret 
    } // end of method ISOFT::UpdateSerialPort

    // method line 477
    .method public static hidebysig 
           default bool openSerialPort (int32 rate)  cil managed 
    {
        // Method begins at RVA 0x38630
	// Code size 190 (0xbe)
	.maxstack 3
	.locals init (
		bool	V_0)
	IL_0000:  ldc.i4.0 
	IL_0001:  stsfld bool TuneECU.ISOFT::ackRead
	.try { // 0
	  IL_0006:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_000b:  callvirt instance bool class [System]System.IO.Ports.SerialPort::get_IsOpen()
	  IL_0010:  brfalse.s IL_001c

	  IL_0012:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_0017:  callvirt instance void class [System]System.IO.Ports.SerialPort::Close()
	  IL_001c:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_0021:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	  IL_0026:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::cmbPortName
	  IL_002b:  callvirt instance string class [System.Windows.Forms]System.Windows.Forms.Control::get_Text()
	  IL_0030:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_PortName(string)
	  IL_0035:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_003a:  ldarg.0 
	  IL_003b:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_BaudRate(int32)
	  IL_0040:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_0045:  ldsfld string TuneECU.ISOFT::cmbDataBits
	  IL_004a:  call int32 int32::Parse(string)
	  IL_004f:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_DataBits(int32)
	  IL_0054:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_0059:  ldtoken [System]System.IO.Ports.StopBits
	  IL_005e:  call class [mscorlib]System.Type class [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
	  IL_0063:  ldsfld string TuneECU.ISOFT::cmbStopBits
	  IL_0068:  call object class [mscorlib]System.Enum::Parse(class [mscorlib]System.Type, string)
	  IL_006d:  unbox.any [System]System.IO.Ports.StopBits
	  IL_0072:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_StopBits(valuetype [System]System.IO.Ports.StopBits)
	  IL_0077:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_007c:  ldtoken [System]System.IO.Ports.Parity
	  IL_0081:  call class [mscorlib]System.Type class [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
	  IL_0086:  ldsfld string TuneECU.ISOFT::cmbParity
	  IL_008b:  call object class [mscorlib]System.Enum::Parse(class [mscorlib]System.Type, string)
	  IL_0090:  unbox.any [System]System.IO.Ports.Parity
	  IL_0095:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_Parity(valuetype [System]System.IO.Ports.Parity)
	  IL_009a:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_009f:  ldc.i4 2000
	  IL_00a4:  callvirt instance void class [System]System.IO.Ports.SerialPort::set_WriteTimeout(int32)
	  IL_00a9:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_00ae:  callvirt instance void class [System]System.IO.Ports.SerialPort::Open()
	  IL_00b3:  ldc.i4.1 
	  IL_00b4:  stloc.0 
	  IL_00b5:  leave.s IL_00bc

	} // end .try 0
	catch class [mscorlib]System.Object { // 0
	  IL_00b7:  pop 
	  IL_00b8:  ldc.i4.0 
	  IL_00b9:  stloc.0 
	  IL_00ba:  leave.s IL_00bc

	} // end handler 0
	IL_00bc:  ldloc.0 
	IL_00bd:  ret 
    } // end of method ISOFT::openSerialPort

    // method line 478
    .method public static hidebysig 
           default void closeSerialPort (bool wait)  cil managed 
    {
        // Method begins at RVA 0x3870c
	// Code size 81 (0x51)
	.maxstack 2
	IL_0000:  ldarg.0 
	IL_0001:  brfalse.s IL_0012

	IL_0003:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0008:  call class [System.Windows.Forms]System.Windows.Forms.Cursor class [System.Windows.Forms]System.Windows.Forms.Cursors::get_WaitCursor()
	IL_000d:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.Control::set_Cursor(class [System.Windows.Forms]System.Windows.Forms.Cursor)
	IL_0012:  ldc.i4 2048
	IL_0017:  call void class [mscorlib]System.Threading.Thread::Sleep(int32)
	IL_001c:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_0021:  callvirt instance bool class [System]System.IO.Ports.SerialPort::get_IsOpen()
	IL_0026:  brfalse.s IL_003e

	IL_0028:  ldsfld bool TuneECU.ISOMain::comFailed
	IL_002d:  brtrue.s IL_0034

	IL_002f:  call void class TuneECU.ISORead::SendWalbroInit()
	IL_0034:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_0039:  callvirt instance void class [System]System.IO.Ports.SerialPort::Close()
	IL_003e:  ldarg.0 
	IL_003f:  brfalse.s IL_0050

	IL_0041:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0046:  call class [System.Windows.Forms]System.Windows.Forms.Cursor class [System.Windows.Forms]System.Windows.Forms.Cursors::get_Default()
	IL_004b:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.Control::set_Cursor(class [System.Windows.Forms]System.Windows.Forms.Cursor)
	IL_0050:  ret 
    } // end of method ISOFT::closeSerialPort

    // method line 479
    .method public static hidebysig 
           default void serialWrite (unsigned int8[] data, int32 len, bool csum)  cil managed 
    {
        // Method begins at RVA 0x3876c
	// Code size 233 (0xe9)
	.maxstack 6
	.locals init (
		int32	V_0,
		int32	V_1)
	IL_0000:  ldc.i4.0 
	IL_0001:  stsfld bool TuneECU.ISOFT::ackRead
	IL_0006:  ldarg.1 
	IL_0007:  stsfld int32 TuneECU.ISOFT::rLength
	IL_000c:  ldarg.1 
	IL_000d:  ldc.i4.m1 
	IL_000e:  beq.s IL_0022

	IL_0010:  ldc.i4.0 
	IL_0011:  stsfld int32 TuneECU.ISOFT::rStart
	IL_0016:  ldc.i4.0 
	IL_0017:  stsfld int32 TuneECU.ISOFT::xStart
	IL_001c:  ldc.i4.0 
	IL_001d:  stsfld int32 TuneECU.ISOFT::sIndex
	IL_0022:  ldarg.0 
	IL_0023:  ldnull 
	IL_0024:  ceq 
	IL_0026:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_002b:  callvirt instance bool class [System]System.IO.Ports.SerialPort::get_IsOpen()
	IL_0030:  ldc.i4.0 
	IL_0031:  ceq 
	IL_0033:  or 
	IL_0034:  brfalse.s IL_0037

	IL_0036:  ret 
	IL_0037:  ldarg.2 
	IL_0038:  brfalse.s IL_0061

	IL_003a:  ldc.i4.0 
	IL_003b:  stloc.1 
	IL_003c:  ldc.i4.0 
	IL_003d:  stloc.0 
	IL_003e:  br.s IL_004a

	IL_0040:  ldloc.1 
	IL_0041:  ldarg.0 
	IL_0042:  ldloc.0 
	IL_0043:  ldelem.u1 
	IL_0044:  add 
	IL_0045:  stloc.1 
	IL_0046:  ldloc.0 
	IL_0047:  ldc.i4.1 
	IL_0048:  add 
	IL_0049:  stloc.0 
	IL_004a:  ldloc.0 
	IL_004b:  ldarg.0 
	IL_004c:  ldlen 
	IL_004d:  conv.i4 
	IL_004e:  ldc.i4.1 
	IL_004f:  sub 
	IL_0050:  blt.s IL_0040

	IL_0052:  ldloc.0 
	IL_0053:  ldc.i4.0 
	IL_0054:  ble.s IL_0061

	IL_0056:  ldarg.0 
	IL_0057:  ldloc.0 
	IL_0058:  ldloc.1 
	IL_0059:  ldc.i4 255
	IL_005e:  and 
	IL_005f:  conv.u1 
	IL_0060:  stelem.i1 
	.try { // 0
	  IL_0061:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_0066:  ldarg.0 
	  IL_0067:  ldc.i4.0 
	  IL_0068:  ldarg.0 
	  IL_0069:  ldlen 
	  IL_006a:  conv.i4 
	  IL_006b:  callvirt instance void class [System]System.IO.Ports.SerialPort::Write(unsigned int8[], int32, int32)
	  IL_0070:  ldc.i4.1 
	  IL_0071:  call void class TuneECU.ISOMain::USBLed(int32)
	  IL_0076:  leave.s IL_00ce

	} // end .try 0
	catch class [mscorlib]System.Object { // 0
	  IL_0078:  pop 
	  IL_0079:  ldc.i4.1 
	  IL_007a:  stsfld bool TuneECU.ISOMain::comFailed
	  IL_007f:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	  IL_0084:  callvirt instance void class TuneECU.ISOMain::QueryConnect()
	  IL_0089:  ldstr ""
	  IL_008e:  ldsfld string[0...,0...] TuneECU.ISOMain::LangUI
	  IL_0093:  ldsfld int32 TuneECU.ISOMain::mLang
	  IL_0098:  ldc.i4 356
	  IL_009d:  call instance string string[,]::Get(int32, int32)
	  IL_00a2:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_00a7:  callvirt instance string class [System]System.IO.Ports.SerialPort::get_PortName()
	  IL_00ac:  ldsfld string[0...,0...] TuneECU.ISOMain::LangUI
	  IL_00b1:  ldsfld int32 TuneECU.ISOMain::mLang
	  IL_00b6:  ldc.i4 356
	  IL_00bb:  call instance string string[,]::Get(int32, int32)
	  IL_00c0:  call string string::Concat(string, string, string)
	  IL_00c5:  ldc.i4.2 
	  IL_00c6:  call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult class TuneECU.ISOMain::DisplayBox(string, string, int32)
	  IL_00cb:  pop 
	  IL_00cc:  leave.s IL_00ce

	} // end handler 0
	IL_00ce:  ldsfld int32 TuneECU.ISOMain::mDebug
	IL_00d3:  ldc.i4.s 0x0c
	IL_00d5:  and 
	IL_00d6:  ldc.i4.0 
	IL_00d7:  ble.s IL_00e8

	IL_00d9:  ldarg.0 
	IL_00da:  ldc.i4.0 
	IL_00db:  ldarg.0 
	IL_00dc:  ldlen 
	IL_00dd:  conv.i4 
	IL_00de:  ldstr ">"
	IL_00e3:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	IL_00e8:  ret 
    } // end of method ISOFT::serialWrite

    // method line 480
    .method private static hidebysig 
           default void port_DataReceived (object sender, class [System]System.IO.Ports.SerialDataReceivedEventArgs e)  cil managed 
    {
        // Method begins at RVA 0x38874
	// Code size 417 (0x1a1)
	.maxstack 5
	.locals init (
		int32	V_0,
		int32	V_1,
		int32	V_2,
		bool	V_3)
	IL_0000:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_0005:  callvirt instance bool class [System]System.IO.Ports.SerialPort::get_IsOpen()
	IL_000a:  brtrue.s IL_000d

	IL_000c:  ret 
	IL_000d:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	IL_0012:  callvirt instance int32 class [System]System.IO.Ports.SerialPort::get_BytesToRead()
	IL_0017:  stloc.2 
	IL_0018:  ldsfld valuetype TuneECU.eMode TuneECU.ISORead::mMode
	IL_001d:  ldc.i4.s 0x17
	IL_001f:  ceq 
	IL_0021:  ldloc.2 
	IL_0022:  ldc.i4.8 
	IL_0023:  clt 
	IL_0025:  and 
	IL_0026:  brfalse.s IL_0029

	IL_0028:  ret 
	.try { // 0
	  IL_0029:  ldsfld class [System]System.IO.Ports.SerialPort TuneECU.ISOFT::comport
	  IL_002e:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_0033:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_0038:  ldloc.2 
	  IL_0039:  callvirt instance int32 class [System]System.IO.Ports.SerialPort::Read(unsigned int8[], int32, int32)
	  IL_003e:  pop 
	  IL_003f:  ldsfld int32 TuneECU.ISOMain::mDebug
	  IL_0044:  ldc.i4.s 0x0c
	  IL_0046:  and 
	  IL_0047:  ldc.i4.0 
	  IL_0048:  ble.s IL_005f

	  IL_004a:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_004f:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_0054:  ldloc.2 
	  IL_0055:  ldstr "<"
	  IL_005a:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	  IL_005f:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_0064:  ldc.i4 3584
	  IL_0069:  ble.s IL_00a9

	  IL_006b:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_0070:  ldc.i4 3328
	  IL_0075:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_007a:  ldc.i4 256
	  IL_007f:  ldc.i4 512
	  IL_0084:  call void class [mscorlib]System.Array::Copy(class [mscorlib]System.Array, int32, class [mscorlib]System.Array, int32, int32)
	  IL_0089:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_008e:  ldc.i4 3072
	  IL_0093:  sub 
	  IL_0094:  stsfld int32 TuneECU.ISOFT::sIndex
	  IL_0099:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_009e:  ldc.i4 3072
	  IL_00a3:  sub 
	  IL_00a4:  stsfld int32 TuneECU.ISOFT::rStart
	  IL_00a9:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_00ae:  ldloc.2 
	  IL_00af:  add 
	  IL_00b0:  stloc.1 
	  IL_00b1:  ldc.i4.0 
	  IL_00b2:  stloc.3 
	  IL_00b3:  ldsfld int32 TuneECU.ISOFT::rLength
	  IL_00b8:  ldc.i4.0 
	  IL_00b9:  bge.s IL_010d

	  IL_00bb:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_00c0:  brtrue.s IL_00c8

	  IL_00c2:  ldc.i4.5 
	  IL_00c3:  stsfld int32 TuneECU.ISOFT::rStart
	  IL_00c8:  ldc.i4.0 
	  IL_00c9:  stloc.0 
	  IL_00ca:  br.s IL_00e5

	  IL_00cc:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_00d1:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_00d6:  ldloc.0 
	  IL_00d7:  add 
	  IL_00d8:  ldelem.u1 
	  IL_00d9:  ldc.i4.s 0x3a
	  IL_00db:  bne.un.s IL_00e1

	  IL_00dd:  ldc.i4.1 
	  IL_00de:  stloc.3 
	  IL_00df:  br.s IL_00e9

	  IL_00e1:  ldloc.0 
	  IL_00e2:  ldc.i4.1 
	  IL_00e3:  add 
	  IL_00e4:  stloc.0 
	  IL_00e5:  ldloc.0 
	  IL_00e6:  ldloc.2 
	  IL_00e7:  blt.s IL_00cc

	  IL_00e9:  ldloc.3 
	  IL_00ea:  brfalse IL_0180

	  IL_00ef:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_00f4:  ldloc.0 
	  IL_00f5:  add 
	  IL_00f6:  stsfld int32 TuneECU.ISOFT::xStart
	  IL_00fb:  ldsfld int32 TuneECU.ISOFT::xStart
	  IL_0100:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_0105:  sub 
	  IL_0106:  stsfld int32 TuneECU.ISOFT::wLength
	  IL_010b:  br.s IL_0180

	  IL_010d:  ldsfld valuetype TuneECU.eMode TuneECU.ISORead::mMode
	  IL_0112:  ldc.i4.s 0x23
	  IL_0114:  ceq 
	  IL_0116:  ldsfld int32 TuneECU.ISOFT::rLength
	  IL_011b:  ldc.i4.2 
	  IL_011c:  cgt 
	  IL_011e:  and 
	  IL_011f:  brfalse.s IL_0166

	  IL_0121:  ldsfld int32 TuneECU.ISOFT::sIndex
	  IL_0126:  stloc.0 
	  IL_0127:  br.s IL_013b

	  IL_0129:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	  IL_012e:  ldloc.0 
	  IL_012f:  ldelem.u1 
	  IL_0130:  ldc.i4 240
	  IL_0135:  beq.s IL_013f

	  IL_0137:  ldloc.0 
	  IL_0138:  ldc.i4.1 
	  IL_0139:  add 
	  IL_013a:  stloc.0 
	  IL_013b:  ldloc.0 
	  IL_013c:  ldloc.1 
	  IL_013d:  blt.s IL_0129

	  IL_013f:  ldloc.0 
	  IL_0140:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_0145:  sub 
	  IL_0146:  ldc.i4.2 
	  IL_0147:  cgt 
	  IL_0149:  ldloc.0 
	  IL_014a:  ldloc.1 
	  IL_014b:  clt 
	  IL_014d:  and 
	  IL_014e:  brfalse.s IL_0180

	  IL_0150:  ldloc.0 
	  IL_0151:  ldc.i4.3 
	  IL_0152:  sub 
	  IL_0153:  stsfld int32 TuneECU.ISOFT::rStart
	  IL_0158:  ldsfld int32 TuneECU.ISOFT::rLength
	  IL_015d:  stsfld int32 TuneECU.ISOFT::wLength
	  IL_0162:  ldc.i4.1 
	  IL_0163:  stloc.3 
	  IL_0164:  br.s IL_0180

	  IL_0166:  ldloc.1 
	  IL_0167:  ldsfld int32 TuneECU.ISOFT::rStart
	  IL_016c:  ldsfld int32 TuneECU.ISOFT::rLength
	  IL_0171:  add 
	  IL_0172:  blt.s IL_0180

	  IL_0174:  ldsfld int32 TuneECU.ISOFT::rLength
	  IL_0179:  stsfld int32 TuneECU.ISOFT::wLength
	  IL_017e:  ldc.i4.1 
	  IL_017f:  stloc.3 
	  IL_0180:  ldloc.3 
	  IL_0181:  brfalse.s IL_0195

	  IL_0183:  ldc.i4.1 
	  IL_0184:  stsfld bool TuneECU.ISOFT::ackRead
	  IL_0189:  ldc.i4.0 
	  IL_018a:  stsfld int32 TuneECU.ISOFT::flagOut
	  IL_018f:  ldc.i4.0 
	  IL_0190:  stsfld int32 TuneECU.ISOFT::rFlag
	  IL_0195:  ldloc.1 
	  IL_0196:  stsfld int32 TuneECU.ISOFT::sIndex
	  IL_019b:  leave.s IL_01a0

	} // end .try 0
	catch class [mscorlib]System.Object { // 0
	  IL_019d:  pop 
	  IL_019e:  leave.s IL_01a0

	} // end handler 0
	IL_01a0:  ret 
    } // end of method ISOFT::port_DataReceived

    // method line 481
    .method public static hidebysig 
           default unsigned int32 CreateDeviceInfoList ()  cil managed 
    {
        // Method begins at RVA 0x38a40
	// Code size 31 (0x1f)
	.maxstack 1
	.locals init (
		valuetype TuneECU.ISOFT/FT_STATUS	V_0,
		unsigned int32	V_1,
		unsigned int32	V_2)
	.try { // 0
	  IL_0000:  ldc.i4.s 0x11
	  IL_0002:  stloc.0 
	  IL_0003:  ldc.i4.0 
	  IL_0004:  stloc.1 
	  IL_0005:  ldloca.s 1
	  IL_0007:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_CreateDeviceInfoList([out] unsigned int32&)
	  IL_000c:  stloc.0 
	  IL_000d:  ldloc.0 
	  IL_000e:  brtrue.s IL_0014

	  IL_0010:  ldloc.1 
	  IL_0011:  stloc.2 
	  IL_0012:  leave.s IL_001d

	  IL_0014:  ldc.i4.0 
	  IL_0015:  stloc.2 
	  IL_0016:  leave.s IL_001d

	} // end .try 0
	catch class [mscorlib]System.Object { // 0
	  IL_0018:  pop 
	  IL_0019:  ldc.i4.0 
	  IL_001a:  stloc.2 
	  IL_001b:  leave.s IL_001d

	} // end handler 0
	IL_001d:  ldloc.2 
	IL_001e:  ret 
    } // end of method ISOFT::CreateDeviceInfoList

    // method line 482
    .method public static hidebysig 
           default bool ListUnopenDevices (unsigned int32 Flag)  cil managed 
    {
        // Method begins at RVA 0x38a7c
	// Code size 298 (0x12a)
	.maxstack 4
	.locals init (
		valuetype TuneECU.ISOFT/FT_STATUS	V_0,
		unsigned int32	V_1,
		int32	V_2,
		unsigned int8[]	V_3,
		int32	V_4,
		void*	V_5,
		unsigned int8& pinned	V_6,
		string	V_7,
		class [mscorlib]System.Text.ASCIIEncoding	V_8,
		bool	V_9,
		unsigned int8[]	V_10)
	IL_0000:  ldc.i4.s 0x11
	IL_0002:  stloc.0 
	IL_0003:  ldc.i4.s 0x40
	IL_0005:  newarr [mscorlib]System.Byte
	IL_000a:  stloc.3 
	IL_000b:  ldc.i4.m1 
	IL_000c:  stloc.s 4
	IL_000e:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0013:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::lbDevList
	IL_0018:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
	IL_001d:  stloc.s 4
	IL_001f:  ldarg.0 
	IL_0020:  stsfld unsigned int32 TuneECU.ISOFT::dwListDescFlags
	.try { // 1
	  IL_0025:  ldloca.s 1
	  IL_0027:  conv.u 
	  IL_0028:  stloc.s 5
	  IL_002a:  ldloc.s 5
	  IL_002c:  ldc.i4.0 
	  IL_002d:  conv.u 
	  IL_002e:  ldc.i4 -2147483648
	  IL_0033:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_ListDevices(void*, void*, unsigned int32)
	  IL_0038:  stloc.0 
	  IL_0039:  ldloc.0 
	  IL_003a:  brtrue IL_00f1

	  IL_003f:  ldsfld unsigned int32 TuneECU.ISOFT::dwListDescFlags
	  IL_0044:  ldc.i4 536870912
	  IL_0049:  bne.un.s IL_0076

	  IL_004b:  ldc.i4.0 
	  IL_004c:  stloc.2 
	  IL_004d:  br.s IL_006e

	  IL_004f:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	  IL_0054:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::lbDevList
	  IL_0059:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	  IL_005e:  ldloc.2 
	  IL_005f:  box [mscorlib]System.Int32
	  IL_0064:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Add(object)
	  IL_0069:  pop 
	  IL_006a:  ldloc.2 
	  IL_006b:  ldc.i4.1 
	  IL_006c:  add 
	  IL_006d:  stloc.2 
	  IL_006e:  ldloc.2 
	  IL_006f:  conv.i8 
	  IL_0070:  ldloc.1 
	  IL_0071:  conv.u8 
	  IL_0072:  blt.s IL_004f

	  IL_0074:  br.s IL_00f1

	  IL_0076:  ldc.i4.0 
	  IL_0077:  stloc.2 
	  IL_0078:  br.s IL_00eb

	  .try { // 0
	    IL_007a:  ldloc.3 
	    IL_007b:  dup 
	    IL_007c:  stloc.s 10
	    IL_007e:  brfalse.s IL_0086

	    IL_0080:  ldloc.s 10
	    IL_0082:  ldlen 
	    IL_0083:  conv.i4 
	    IL_0084:  brtrue.s IL_008c

	    IL_0086:  ldc.i4.0 
	    IL_0087:  conv.u 
	    IL_0088:  stloc.s 6
	    IL_008a:  br.s IL_0096

	    IL_008c:  ldloc.s 10
	    IL_008e:  ldc.i4.0 
	    IL_008f:  ldelema [mscorlib]System.Byte
	    IL_0094:  stloc.s 6
	    IL_0096:  ldloc.2 
	    IL_0097:  ldloc.s 6
	    IL_0099:  conv.i 
	    IL_009a:  ldsfld unsigned int32 TuneECU.ISOFT::dwListDescFlags
	    IL_009f:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_ListDevices(unsigned int32, void*, unsigned int32)
	    IL_00a4:  stloc.0 
	    IL_00a5:  ldloc.0 
	    IL_00a6:  brtrue.s IL_00d6

	    IL_00a8:  newobj instance void class [mscorlib]System.Text.ASCIIEncoding::'.ctor'()
	    IL_00ad:  stloc.s 8
	    IL_00af:  ldloc.s 8
	    IL_00b1:  ldloc.3 
	    IL_00b2:  ldc.i4.0 
	    IL_00b3:  ldloc.3 
	    IL_00b4:  ldlen 
	    IL_00b5:  conv.i4 
	    IL_00b6:  callvirt instance string class [mscorlib]System.Text.Encoding::GetString(unsigned int8[], int32, int32)
	    IL_00bb:  stloc.s 7
	    IL_00bd:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	    IL_00c2:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::lbDevList
	    IL_00c7:  callvirt instance class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection class [System.Windows.Forms]System.Windows.Forms.ListBox::get_Items()
	    IL_00cc:  ldloc.s 7
	    IL_00ce:  callvirt instance int32 class [System.Windows.Forms]System.Windows.Forms.ListBox/ObjectCollection::Add(object)
	    IL_00d3:  pop 
	    IL_00d4:  br.s IL_00e0

	    IL_00d6:  call void class TuneECU.ISOMain::addUSBMenuItem()
	    IL_00db:  ldc.i4.0 
	    IL_00dc:  stloc.s 9
	    IL_00de:  leave.s IL_0127

	    IL_00e0:  leave.s IL_00e7

	  } // end .try 0
	  finally  { // 0
	    IL_00e2:  ldc.i4.0 
	    IL_00e3:  conv.u 
	    IL_00e4:  stloc.s 6
	    IL_00e6:  endfinally 
	  } // end handler 0
	  IL_00e7:  ldloc.2 
	  IL_00e8:  ldc.i4.1 
	  IL_00e9:  add 
	  IL_00ea:  stloc.2 
	  IL_00eb:  ldloc.2 
	  IL_00ec:  conv.i8 
	  IL_00ed:  ldloc.1 
	  IL_00ee:  conv.u8 
	  IL_00ef:  blt.s IL_007a

	  IL_00f1:  leave.s IL_00f8

	} // end .try 1
	catch class [mscorlib]System.Object { // 1
	  IL_00f3:  pop 
	  IL_00f4:  ldc.i4.0 
	  IL_00f5:  stloc.1 
	  IL_00f6:  leave.s IL_00f8

	} // end handler 1
	IL_00f8:  ldloc.s 4
	IL_00fa:  ldc.i4.0 
	IL_00fb:  clt 
	IL_00fd:  ldloc.1 
	IL_00fe:  ldc.i4.0 
	IL_00ff:  cgt.un 
	IL_0101:  and 
	IL_0102:  brfalse.s IL_0109

	IL_0104:  ldc.i4.0 
	IL_0105:  stloc.s 4
	IL_0107:  br.s IL_010f

	IL_0109:  ldloc.1 
	IL_010a:  brtrue.s IL_010f

	IL_010c:  ldc.i4.m1 
	IL_010d:  stloc.s 4
	IL_010f:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_0114:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::lbDevList
	IL_0119:  ldloc.s 4
	IL_011b:  callvirt instance void class [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
	IL_0120:  call void class TuneECU.ISOMain::addUSBMenuItem()
	IL_0125:  ldc.i4.1 
	IL_0126:  ret 
	IL_0127:  ldloc.s 9
	IL_0129:  ret 
    } // end of method ISOFT::ListUnopenDevices

    // method line 483
    .method public static hidebysig 
           default bool FTDOpen (unsigned int32 Index, unsigned int32 baud)  cil managed 
    {
        // Method begins at RVA 0x38bd0
	// Code size 358 (0x166)
	.maxstack 4
	.locals init (
		unsigned int32	V_0,
		valuetype TuneECU.ISOFT/FT_STATUS	V_1,
		unsigned int8	V_2,
		void*	V_3,
		class [mscorlib]System.Text.ASCIIEncoding	V_4,
		unsigned int8[]	V_5,
		unsigned int8& pinned	V_6,
		unsigned int8[]	V_7)
	IL_0000:  ldc.i4.s 0x11
	IL_0002:  stloc.1 
	IL_0003:  ldc.i4.4 
	IL_0004:  stloc.2 
	IL_0005:  ldc.i4.0 
	IL_0006:  stsfld int32 TuneECU.ISOFT::flagOut
	IL_000b:  ldc.i4.0 
	IL_000c:  stsfld int32 TuneECU.ISOFT::rFlag
	IL_0011:  ldc.i4.0 
	IL_0012:  call void class TuneECU.ISORead::SwitchMode(valuetype TuneECU.eMode)
	IL_0017:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_001c:  brfalse.s IL_0024

	IL_001e:  ldc.i4.0 
	IL_001f:  call void class TuneECU.ISOFT::FTDClose(bool)
	IL_0024:  ldsfld unsigned int32 TuneECU.ISOFT::dwListDescFlags
	IL_0029:  ldc.i4 -1073741825
	IL_002e:  and 
	IL_002f:  stloc.0 
	IL_0030:  ldsfld unsigned int32 TuneECU.ISOFT::dwListDescFlags
	IL_0035:  ldc.i4 -536870913
	IL_003a:  and 
	IL_003b:  stloc.0 
	IL_003c:  ldloc.0 
	IL_003d:  brtrue.s IL_004d

	IL_003f:  ldarg.0 
	IL_0040:  ldsflda unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0045:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Open(unsigned int32, [out] unsigned int32&)
	IL_004a:  stloc.1 
	IL_004b:  br.s IL_009c

	IL_004d:  newobj instance void class [mscorlib]System.Text.ASCIIEncoding::'.ctor'()
	IL_0052:  stloc.s 4
	IL_0054:  ldloc.s 4
	IL_0056:  ldsfld class TuneECU.ISOMain TuneECU.ISOMain::me
	IL_005b:  ldfld class [System.Windows.Forms]System.Windows.Forms.ListBox TuneECU.ISOMain::lbDevList
	IL_0060:  callvirt instance string class [System.Windows.Forms]System.Windows.Forms.Control::get_Text()
	IL_0065:  callvirt instance unsigned int8[] class [mscorlib]System.Text.Encoding::GetBytes(string)
	IL_006a:  stloc.s 5
	IL_006c:  ldloc.s 5
	IL_006e:  dup 
	IL_006f:  stloc.s 7
	IL_0071:  brfalse.s IL_0079

	IL_0073:  ldloc.s 7
	IL_0075:  ldlen 
	IL_0076:  conv.i4 
	IL_0077:  brtrue.s IL_007f

	IL_0079:  ldc.i4.0 
	IL_007a:  conv.u 
	IL_007b:  stloc.s 6
	IL_007d:  br.s IL_0089

	IL_007f:  ldloc.s 7
	IL_0081:  ldc.i4.0 
	IL_0082:  ldelema [mscorlib]System.Byte
	IL_0087:  stloc.s 6
	IL_0089:  ldloc.s 6
	IL_008b:  conv.i 
	IL_008c:  ldloc.0 
	IL_008d:  ldsflda unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0092:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_OpenEx(void*, unsigned int32, [out] unsigned int32&)
	IL_0097:  stloc.1 
	IL_0098:  ldc.i4.0 
	IL_0099:  conv.u 
	IL_009a:  stloc.s 6
	IL_009c:  ldloc.1 
	IL_009d:  brtrue IL_0164

	IL_00a2:  ldc.i4.0 
	IL_00a3:  stsfld bool TuneECU.ISOFT::Terminate
	IL_00a8:  ldc.i4.0 
	IL_00a9:  stsfld bool TuneECU.ISOMain::serialMode
	IL_00ae:  call void class TuneECU.ISOMain::addUSBMenuItem()
	IL_00b3:  ldsfld native int [mscorlib]System.IntPtr::Zero
	IL_00b8:  ldc.i4.0 
	IL_00b9:  ldc.i4.0 
	IL_00ba:  ldstr ""
	IL_00bf:  call native int class TuneECU.ISOFT::CreateEvent(native int, bool, bool, string)
	IL_00c4:  stsfld native int TuneECU.ISOFT::hEvent
	IL_00c9:  ldc.i4.1 
	IL_00ca:  stsfld unsigned int32 TuneECU.ISOFT::EventMask
	IL_00cf:  ldsfld native int TuneECU.ISOFT::hEvent
	IL_00d4:  call void* native int::op_Explicit(native int)
	IL_00d9:  stloc.3 
	IL_00da:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_00df:  ldsfld unsigned int32 TuneECU.ISOFT::EventMask
	IL_00e4:  ldloc.3 
	IL_00e5:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetEventNotification(unsigned int32, unsigned int32, void*)
	IL_00ea:  stloc.1 
	IL_00eb:  ldnull 
	IL_00ec:  ldftn void class TuneECU.ISOFT::ThreadProc()
	IL_00f2:  newobj instance void class [mscorlib]System.Threading.ThreadStart::'.ctor'(object, native int)
	IL_00f7:  newobj instance void class [mscorlib]System.Threading.Thread::'.ctor'(class [mscorlib]System.Threading.ThreadStart)
	IL_00fc:  stsfld class [mscorlib]System.Threading.Thread TuneECU.ISOFT::pThreadRead
	IL_0101:  ldsfld class [mscorlib]System.Threading.Thread TuneECU.ISOFT::pThreadRead
	IL_0106:  callvirt instance void class [mscorlib]System.Threading.Thread::Start()
	IL_010b:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0110:  ldc.i4.8 
	IL_0111:  ldc.i4.0 
	IL_0112:  ldc.i4.0 
	IL_0113:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetDataCharacteristics(unsigned int32, unsigned int8, unsigned int8, unsigned int8)
	IL_0118:  pop 
	IL_0119:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_011e:  ldc.i4.0 
	IL_011f:  ldc.i4.s 0x11
	IL_0121:  ldc.i4.s 0x13
	IL_0123:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetFlowControl(unsigned int32, unsigned int16, unsigned int8, unsigned int8)
	IL_0128:  pop 
	IL_0129:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_012e:  ldc.i4 128
	IL_0133:  ldc.i4.0 
	IL_0134:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetUSBParameters(unsigned int32, unsigned int32, unsigned int32)
	IL_0139:  pop 
	IL_013a:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_013f:  ldc.i4 150
	IL_0144:  ldc.i4 150
	IL_0149:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetTimeouts(unsigned int32, unsigned int32, unsigned int32)
	IL_014e:  pop 
	IL_014f:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0154:  ldloc.2 
	IL_0155:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetLatencyTimer(unsigned int32, unsigned int8)
	IL_015a:  stloc.1 
	IL_015b:  ldarg.1 
	IL_015c:  ldc.i4.1 
	IL_015d:  call void class TuneECU.ISOFT::FTHiSpeed(unsigned int32, bool)
	IL_0162:  ldc.i4.1 
	IL_0163:  ret 
	IL_0164:  ldc.i4.0 
	IL_0165:  ret 
    } // end of method ISOFT::FTDOpen

    // method line 484
    .method public static hidebysig 
           default void FTHiSpeed (unsigned int32 baud, bool purge)  cil managed 
    {
        // Method begins at RVA 0x38d42
	// Code size 35 (0x23)
	.maxstack 8
	IL_0000:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0005:  brfalse.s IL_0022

	IL_0007:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_000c:  ldarg.0 
	IL_000d:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetBaudRate(unsigned int32, unsigned int32)
	IL_0012:  pop 
	IL_0013:  ldarg.1 
	IL_0014:  brfalse.s IL_0022

	IL_0016:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_001b:  ldc.i4.3 
	IL_001c:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Purge(unsigned int32, unsigned int32)
	IL_0021:  pop 
	IL_0022:  ret 
    } // end of method ISOFT::FTHiSpeed

    // method line 485
    .method private static hidebysig 
           default void ThreadProc ()  cil managed 
    {
        // Method begins at RVA 0x38d68
	// Code size 237 (0xed)
	.maxstack 4
	.locals init (
		unsigned int32	V_0,
		unsigned int32	V_1,
		unsigned int32	V_2,
		unsigned int32	V_3,
		unsigned int8& pinned	V_4,
		unsigned int8[]	V_5)
	IL_0000:  ldc.i4.0 
	IL_0001:  stloc.0 
	IL_0002:  ldc.i4.0 
	IL_0003:  stloc.1 
	IL_0004:  ldc.i4.0 
	IL_0005:  stloc.2 
	IL_0006:  ldc.i4.0 
	IL_0007:  stloc.3 
	IL_0008:  br IL_00e2

	IL_000d:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0012:  brtrue.s IL_0015

	IL_0014:  ret 
	IL_0015:  ldsfld native int TuneECU.ISOFT::hEvent
	IL_001a:  ldc.i4 1024
	IL_001f:  call int32 class TuneECU.ISOFT::WaitForSingleObject(native int, unsigned int32)
	IL_0024:  pop 
	IL_0025:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_002a:  ldc.i4.0 
	IL_002b:  ble IL_00e2

	IL_0030:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_0035:  dup 
	IL_0036:  stloc.s 5
	IL_0038:  brfalse.s IL_0040

	IL_003a:  ldloc.s 5
	IL_003c:  ldlen 
	IL_003d:  conv.i4 
	IL_003e:  brtrue.s IL_0046

	IL_0040:  ldc.i4.0 
	IL_0041:  conv.u 
	IL_0042:  stloc.s 4
	IL_0044:  br.s IL_0050

	IL_0046:  ldloc.s 5
	IL_0048:  ldc.i4.0 
	IL_0049:  ldelema [mscorlib]System.Byte
	IL_004e:  stloc.s 4
	IL_0050:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0055:  ldloca.s 1
	IL_0057:  ldloca.s 2
	IL_0059:  ldloca.s 3
	IL_005b:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_GetStatus(unsigned int32, [out] unsigned int32&, [out] unsigned int32&, [out] unsigned int32&)
	IL_0060:  pop 
	IL_0061:  ldloc.1 
	IL_0062:  ldc.i4.0 
	IL_0063:  ble.un.s IL_00d1

	IL_0065:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_006a:  ldloc.s 4
	IL_006c:  conv.i 
	IL_006d:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0072:  add 
	IL_0073:  ldc.i4.1 
	IL_0074:  ldloca.s 0
	IL_0076:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Read(unsigned int32, void*, unsigned int32, [out] unsigned int32&)
	IL_007b:  pop 
	IL_007c:  ldsfld int32 TuneECU.ISOMain::mDebug
	IL_0081:  ldc.i4.s 0x0c
	IL_0083:  and 
	IL_0084:  ldc.i4.0 
	IL_0085:  ble.s IL_009c

	IL_0087:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_008c:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0091:  ldloc.1 
	IL_0092:  ldstr "<"
	IL_0097:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	IL_009c:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_00a1:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00a6:  conv.u 
	IL_00a7:  ldelem.u1 
	IL_00a8:  ldsfld unsigned int8[] TuneECU.ISOFT::wByte
	IL_00ad:  ldc.i4.0 
	IL_00ae:  ldelem.u1 
	IL_00af:  bne.un.s IL_00cb

	IL_00b1:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_00b6:  ldc.i4.1 
	IL_00b7:  sub 
	IL_00b8:  stsfld int32 TuneECU.ISOFT::pxBuffer
	IL_00bd:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00c2:  ldloc.0 
	IL_00c3:  add 
	IL_00c4:  stsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00c9:  br.s IL_00d1

	IL_00cb:  ldc.i4.0 
	IL_00cc:  stsfld int32 TuneECU.ISOFT::pxBuffer
	IL_00d1:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_00d6:  ldc.i4.0 
	IL_00d7:  ble.s IL_00de

	IL_00d9:  call void class TuneECU.ISOFT::FTDWriteByte()
	IL_00de:  ldc.i4.0 
	IL_00df:  conv.u 
	IL_00e0:  stloc.s 4
	IL_00e2:  ldsfld bool TuneECU.ISOFT::Terminate
	IL_00e7:  brfalse IL_000d

	IL_00ec:  ret 
    } // end of method ISOFT::ThreadProc

    // method line 486
    .method public static hidebysig 
           default void FTDRead ()  cil managed 
    {
        // Method begins at RVA 0x38e64
	// Code size 390 (0x186)
	.maxstack 4
	.locals init (
		unsigned int32	V_0,
		unsigned int32	V_1,
		unsigned int32	V_2,
		unsigned int32	V_3,
		unsigned int8& pinned	V_4,
		unsigned int8[]	V_5)
	IL_0000:  ldc.i4.0 
	IL_0001:  stloc.0 
	IL_0002:  ldc.i4.0 
	IL_0003:  stloc.1 
	IL_0004:  ldc.i4.0 
	IL_0005:  stloc.2 
	IL_0006:  ldc.i4.0 
	IL_0007:  stloc.3 
	IL_0008:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_000d:  brtrue.s IL_0010

	IL_000f:  ret 
	IL_0010:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_0015:  brtrue IL_0185

	IL_001a:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_001f:  dup 
	IL_0020:  stloc.s 5
	IL_0022:  brfalse.s IL_002a

	IL_0024:  ldloc.s 5
	IL_0026:  ldlen 
	IL_0027:  conv.i4 
	IL_0028:  brtrue.s IL_0030

	IL_002a:  ldc.i4.0 
	IL_002b:  conv.u 
	IL_002c:  stloc.s 4
	IL_002e:  br.s IL_003a

	IL_0030:  ldloc.s 5
	IL_0032:  ldc.i4.0 
	IL_0033:  ldelema [mscorlib]System.Byte
	IL_0038:  stloc.s 4
	IL_003a:  ldc.i4.0 
	IL_003b:  stloc.0 
	IL_003c:  ldc.i4.0 
	IL_003d:  stloc.1 
	IL_003e:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0043:  ldloca.s 1
	IL_0045:  ldloca.s 2
	IL_0047:  ldloca.s 3
	IL_0049:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_GetStatus(unsigned int32, [out] unsigned int32&, [out] unsigned int32&, [out] unsigned int32&)
	IL_004e:  pop 
	IL_004f:  ldloc.1 
	IL_0050:  ldc.i4.0 
	IL_0051:  ble.un IL_0105

	IL_0056:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_005b:  ldloc.s 4
	IL_005d:  conv.i 
	IL_005e:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0063:  add 
	IL_0064:  ldloc.1 
	IL_0065:  ldloca.s 0
	IL_0067:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Read(unsigned int32, void*, unsigned int32, [out] unsigned int32&)
	IL_006c:  pop 
	IL_006d:  ldsfld int32 TuneECU.ISOMain::mDebug
	IL_0072:  ldc.i4.s 0x0c
	IL_0074:  and 
	IL_0075:  ldc.i4.0 
	IL_0076:  ble.s IL_008d

	IL_0078:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_007d:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0082:  ldloc.1 
	IL_0083:  ldstr "<"
	IL_0088:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	IL_008d:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0092:  ldloc.0 
	IL_0093:  add 
	IL_0094:  ldc.i4 4096
	IL_0099:  rem.un 
	IL_009a:  stsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_009f:  ldsfld int32 TuneECU.ISOFT::rLength
	IL_00a4:  ldc.i4.0 
	IL_00a5:  clt 
	IL_00a7:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00ac:  conv.u8 
	IL_00ad:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_00b2:  conv.i8 
	IL_00b3:  cgt 
	IL_00b5:  and 
	IL_00b6:  brfalse.s IL_010b

	IL_00b8:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_00bd:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_00c2:  ldelem.u1 
	IL_00c3:  ldc.i4.s 0x7f
	IL_00c5:  and 
	IL_00c6:  brtrue.s IL_00ee

	IL_00c8:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00cd:  conv.u8 
	IL_00ce:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_00d3:  ldc.i4.3 
	IL_00d4:  add 
	IL_00d5:  conv.i8 
	IL_00d6:  ble.s IL_010b

	IL_00d8:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_00dd:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_00e2:  ldc.i4.3 
	IL_00e3:  add 
	IL_00e4:  ldelem.u1 
	IL_00e5:  ldc.i4.5 
	IL_00e6:  add 
	IL_00e7:  stsfld int32 TuneECU.ISOFT::rLength
	IL_00ec:  br.s IL_010b

	IL_00ee:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_00f3:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_00f8:  ldelem.u1 
	IL_00f9:  ldc.i4.s 0x7f
	IL_00fb:  and 
	IL_00fc:  ldc.i4.4 
	IL_00fd:  add 
	IL_00fe:  stsfld int32 TuneECU.ISOFT::rLength
	IL_0103:  br.s IL_010b

	IL_0105:  ldc.i4.0 
	IL_0106:  call void class TuneECU.ISOMain::USBLed(int32)
	IL_010b:  ldsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0110:  conv.u8 
	IL_0111:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_0116:  ldsfld int32 TuneECU.ISOFT::rLength
	IL_011b:  add 
	IL_011c:  conv.i8 
	IL_011d:  clt 
	IL_011f:  ldc.i4.0 
	IL_0120:  ceq 
	IL_0122:  ldsfld int32 TuneECU.ISOFT::rLength
	IL_0127:  ldc.i4.0 
	IL_0128:  cgt 
	IL_012a:  and 
	IL_012b:  brfalse.s IL_0181

	IL_012d:  ldc.i4.1 
	IL_012e:  call void class TuneECU.ISOMain::USBLed(int32)
	IL_0133:  ldsfld unsigned int8[] TuneECU.ISOFT::rBuffer
	IL_0138:  ldsfld int32 TuneECU.ISOFT::rStart
	IL_013d:  ldsfld int32 TuneECU.ISOFT::rLength
	IL_0142:  ldsfld bool TuneECU.ISOFT::eEcho
	IL_0147:  call void class TuneECU.ISORead::ReadData(unsigned int8[], int32, int32, bool)
	IL_014c:  ldsfld bool TuneECU.ISOFT::eEcho
	IL_0151:  brfalse.s IL_016f

	IL_0153:  ldsfld int32 TuneECU.ISOFT::rLength
	IL_0158:  stsfld int32 TuneECU.ISOFT::rStart
	IL_015d:  ldc.i4.0 
	IL_015e:  stsfld bool TuneECU.ISOFT::eEcho
	IL_0163:  ldsfld int32 TuneECU.ISOFT::wLength
	IL_0168:  stsfld int32 TuneECU.ISOFT::rLength
	IL_016d:  br.s IL_0181

	IL_016f:  ldc.i4.0 
	IL_0170:  stsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_0175:  ldc.i4.0 
	IL_0176:  stsfld int32 TuneECU.ISOFT::flagOut
	IL_017b:  ldc.i4.0 
	IL_017c:  stsfld int32 TuneECU.ISOFT::rFlag
	IL_0181:  ldc.i4.0 
	IL_0182:  conv.u 
	IL_0183:  stloc.s 4
	IL_0185:  ret 
    } // end of method ISOFT::FTDRead

    // method line 487
    .method public static hidebysig 
           default void FTDWriteByte ()  cil managed 
    {
        // Method begins at RVA 0x38ff8
	// Code size 109 (0x6d)
	.maxstack 5
	.locals init (
		unsigned int32	V_0,
		unsigned int8& pinned	V_1,
		unsigned int8[]	V_2)
	IL_0000:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_0005:  brtrue.s IL_0008

	IL_0007:  ret 
	IL_0008:  ldc.i4.0 
	IL_0009:  stloc.0 
	IL_000a:  ldsfld unsigned int8[] TuneECU.ISOFT::wByte
	IL_000f:  ldc.i4.0 
	IL_0010:  ldsfld unsigned int8[] TuneECU.ISOFT::wBuffer
	IL_0015:  ldsfld int32 TuneECU.ISOFT::lnBuffer
	IL_001a:  ldsfld int32 TuneECU.ISOFT::pxBuffer
	IL_001f:  sub 
	IL_0020:  ldelem.u1 
	IL_0021:  stelem.i1 
	IL_0022:  ldsfld unsigned int8[] TuneECU.ISOFT::wByte
	IL_0027:  dup 
	IL_0028:  stloc.2 
	IL_0029:  brfalse.s IL_0030

	IL_002b:  ldloc.2 
	IL_002c:  ldlen 
	IL_002d:  conv.i4 
	IL_002e:  brtrue.s IL_0035

	IL_0030:  ldc.i4.0 
	IL_0031:  conv.u 
	IL_0032:  stloc.1 
	IL_0033:  br.s IL_003d

	IL_0035:  ldloc.2 
	IL_0036:  ldc.i4.0 
	IL_0037:  ldelema [mscorlib]System.Byte
	IL_003c:  stloc.1 
	IL_003d:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0042:  ldloc.1 
	IL_0043:  conv.i 
	IL_0044:  ldc.i4.1 
	IL_0045:  ldloca.s 0
	IL_0047:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Write(unsigned int32, void*, unsigned int32, [out] unsigned int32&)
	IL_004c:  pop 
	IL_004d:  ldc.i4.0 
	IL_004e:  conv.u 
	IL_004f:  stloc.1 
	IL_0050:  ldsfld int32 TuneECU.ISOMain::mDebug
	IL_0055:  ldc.i4.s 0x0c
	IL_0057:  and 
	IL_0058:  ldc.i4.0 
	IL_0059:  ble.s IL_006c

	IL_005b:  ldsfld unsigned int8[] TuneECU.ISOFT::wByte
	IL_0060:  ldc.i4.0 
	IL_0061:  ldc.i4.1 
	IL_0062:  ldstr ">"
	IL_0067:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	IL_006c:  ret 
    } // end of method ISOFT::FTDWriteByte

    // method line 488
    .method public static hidebysig 
           default bool FTDWrite (unsigned int8[] msg, int32 lr, bool echo, bool line)  cil managed 
    {
        // Method begins at RVA 0x39074
	// Code size 198 (0xc6)
	.maxstack 4
	.locals init (
		unsigned int32	V_0,
		valuetype TuneECU.ISOFT/FT_STATUS	V_1,
		unsigned int8& pinned	V_2,
		unsigned int8[]	V_3)
	IL_0000:  ldc.i4.0 
	IL_0001:  stloc.0 
	IL_0002:  ldc.i4.0 
	IL_0003:  stsfld int32 TuneECU.ISOFT::flagOut
	IL_0008:  ldarg.2 
	IL_0009:  brfalse.s IL_0015

	IL_000b:  ldarg.0 
	IL_000c:  ldlen 
	IL_000d:  conv.i4 
	IL_000e:  stsfld int32 TuneECU.ISOFT::rLength
	IL_0013:  br.s IL_001b

	IL_0015:  ldarg.1 
	IL_0016:  stsfld int32 TuneECU.ISOFT::rLength
	IL_001b:  ldarg.2 
	IL_001c:  stsfld bool TuneECU.ISOFT::eEcho
	IL_0021:  ldarg.1 
	IL_0022:  stsfld int32 TuneECU.ISOFT::wLength
	IL_0027:  ldarg.0 
	IL_0028:  brfalse.s IL_00a9

	IL_002a:  ldc.i4.s 0x11
	IL_002c:  stloc.1 
	IL_002d:  ldarg.0 
	IL_002e:  stsfld unsigned int8[] TuneECU.ISOFT::wBuffer
	IL_0033:  ldarg.3 
	IL_0034:  brfalse.s IL_008c

	IL_0036:  ldsfld unsigned int8[] TuneECU.ISOFT::wBuffer
	IL_003b:  dup 
	IL_003c:  stloc.3 
	IL_003d:  brfalse.s IL_0044

	IL_003f:  ldloc.3 
	IL_0040:  ldlen 
	IL_0041:  conv.i4 
	IL_0042:  brtrue.s IL_0049

	IL_0044:  ldc.i4.0 
	IL_0045:  conv.u 
	IL_0046:  stloc.2 
	IL_0047:  br.s IL_0051

	IL_0049:  ldloc.3 
	IL_004a:  ldc.i4.0 
	IL_004b:  ldelema [mscorlib]System.Byte
	IL_0050:  stloc.2 
	IL_0051:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0056:  ldloc.2 
	IL_0057:  conv.i 
	IL_0058:  ldsfld unsigned int8[] TuneECU.ISOFT::wBuffer
	IL_005d:  ldlen 
	IL_005e:  conv.i4 
	IL_005f:  ldloca.s 0
	IL_0061:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Write(unsigned int32, void*, unsigned int32, [out] unsigned int32&)
	IL_0066:  stloc.1 
	IL_0067:  ldc.i4.0 
	IL_0068:  conv.u 
	IL_0069:  stloc.2 
	IL_006a:  ldc.i4.0 
	IL_006b:  stsfld int32 TuneECU.ISOFT::pxBuffer
	IL_0070:  ldsfld int32 TuneECU.ISOMain::mDebug
	IL_0075:  ldc.i4.s 0x0c
	IL_0077:  and 
	IL_0078:  ldc.i4.0 
	IL_0079:  ble.s IL_00b5

	IL_007b:  ldarg.0 
	IL_007c:  ldc.i4.0 
	IL_007d:  ldarg.0 
	IL_007e:  ldlen 
	IL_007f:  conv.i4 
	IL_0080:  ldstr ">"
	IL_0085:  call void class TuneECU.ISOMain::WriteTrcFile(unsigned int8[], int32, int32, string)
	IL_008a:  br.s IL_00b5

	IL_008c:  ldsfld unsigned int8[] TuneECU.ISOFT::wBuffer
	IL_0091:  ldlen 
	IL_0092:  conv.i4 
	IL_0093:  stsfld int32 TuneECU.ISOFT::lnBuffer
	IL_0098:  ldsfld int32 TuneECU.ISOFT::lnBuffer
	IL_009d:  stsfld int32 TuneECU.ISOFT::pxBuffer
	IL_00a2:  call void class TuneECU.ISOFT::FTDWriteByte()
	IL_00a7:  br.s IL_00b5

	IL_00a9:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_00ae:  ldc.i4.3 
	IL_00af:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_Purge(unsigned int32, unsigned int32)
	IL_00b4:  stloc.1 
	IL_00b5:  ldc.i4.0 
	IL_00b6:  stsfld unsigned int32 TuneECU.ISOFT::rIndex
	IL_00bb:  ldc.i4.0 
	IL_00bc:  stsfld int32 TuneECU.ISOFT::rStart
	IL_00c1:  ldloc.1 
	IL_00c2:  ldc.i4.0 
	IL_00c3:  ceq 
	IL_00c5:  ret 
    } // end of method ISOFT::FTDWrite

    // method line 489
    .method public static hidebysig 
           default void SetBreak (unsigned int8 v)  cil managed 
    {
        // Method begins at RVA 0x39146
	// Code size 36 (0x24)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  brtrue.s IL_0010

	IL_0003:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0008:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetBreakOn(unsigned int32)
	IL_000d:  pop 
	IL_000e:  br.s IL_001b

	IL_0010:  ldsfld unsigned int32 TuneECU.ISOFT::m_hPort
	IL_0015:  call valuetype TuneECU.ISOFT/FT_STATUS class TuneECU.ISOFT::FT_SetBreakOff(unsigned int32)
