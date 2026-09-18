using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TuneECU.Properties;

namespace TuneECU;

public class ISOFT : ISOMain
{
	public enum FT_STATUS
	{
		FT_OK,
		FT_INVALID_HANDLE,
		FT_DEVICE_NOT_FOUND,
		FT_DEVICE_NOT_OPENED,
		FT_IO_ERROR,
		FT_INSUFFICIENT_RESOURCES,
		FT_INVALID_PARAMETER,
		FT_INVALID_BAUD_RATE,
		FT_DEVICE_NOT_OPENED_FOR_ERASE,
		FT_DEVICE_NOT_OPENED_FOR_WRITE,
		FT_FAILED_TO_WRITE_DEVICE,
		FT_EEPROM_READ_FAILED,
		FT_EEPROM_WRITE_FAILED,
		FT_EEPROM_ERASE_FAILED,
		FT_EEPROM_NOT_PRESENT,
		FT_EEPROM_NOT_PROGRAMMED,
		FT_INVALID_ARGS,
		FT_OTHER_ERROR
	}

	public const byte FT_BITS_8 = 8;

	public const byte FT_BITS_7 = 7;

	public const byte FT_BITS_6 = 6;

	public const byte FT_BITS_5 = 5;

	public const byte FT_STOP_BITS_1 = 0;

	public const byte FT_STOP_BITS_1_5 = 1;

	public const byte FT_STOP_BITS_2 = 2;

	public const byte FT_PARITY_NONE = 0;

	public const byte FT_PARITY_ODD = 1;

	public const byte FT_PARITY_EVEN = 2;

	public const byte FT_PARITY_MARK = 3;

	public const byte FT_PARITY_SPACE = 4;

	public const ushort FT_FLOW_NONE = 0;

	public const ushort FT_FLOW_RTS_CTS = 256;

	public const ushort FT_FLOW_DTR_DSR = 512;

	public const ushort FT_FLOW_XON_XOFF = 1024;

	public const uint FT_EVENT_RXCHAR = 1u;

	public const uint FT_EVENT_MODEM_STATUS = 2u;

	public const uint FT_EVENT_LINE_STATUS = 4u;

	public const byte FT_PURGE_RX = 1;

	public const byte FT_PURGE_TX = 2;

	public const int RECOUNT = 80;

	public const int TIMEOUT = 150;

	public const int RTIMEOUT = 200;

	public static int LONG_TIMEOUT;

	public static int SYNC_TIMEOUT;

	public static int IntV;

	private static IntPtr hEvent;

	private static uint EventMask;

	protected static Thread pThreadRead;

	protected static Thread pThreadWrite;

	protected static uint dwListDescFlags;

	protected static uint m_hPort;

	public static eMessage mMessage;

	public static int flagOut;

	public static int rFlag;

	public static int rLoad;

	public static int rSafe;

	public static int sECU;

	public static bool imFlag;

	public static bool Terminate;

	public static bool checkSagem;

	public static bool ackRead;

	public static SerialPort comport;

	public static string cmbStopBits;

	public static string cmbDataBits;

	public static string cmbBaudRate;

	public static string cmbParity;

	private static byte[] rBuffer;

	private static int rLength;

	private static int rStart;

	private static int xStart;

	private static int wLength;

	private static uint rIndex;

	private static int sIndex;

	private static bool eEcho;

	private static byte[] wBuffer;

	private static byte[] wByte;

	private static int lnBuffer;

	private static int pxBuffer;

	private static int interval;

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_CreateDeviceInfoList(ref uint lpdwNumDevs);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_ListDevices(void* pvArg1, void* pvArg2, uint dwFlags);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_ListDevices(uint pvArg1, void* pvArg2, uint dwFlags);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_Open(uint uiPort, ref uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_OpenEx(void* pvArg1, uint dwFlags, ref uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_Close(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_Read(uint ftHandle, void* lpBuffer, uint dwBytesToRead, ref uint lpdwBytesReturned);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_Write(uint ftHandle, void* lpBuffer, uint dwBytesToRead, ref uint lpdwBytesWritten);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetBaudRate(uint ftHandle, uint dwBaudRate);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetDataCharacteristics(uint ftHandle, byte uWordLength, byte uStopBits, byte uParity);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetFlowControl(uint ftHandle, ushort usFlowControl, byte uXon, byte uXoff);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetDtr(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_ClrDtr(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetRts(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_ClrRts(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_Purge(uint ftHandle, uint dwMask);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetTimeouts(uint ftHandle, uint dwReadTimeout, uint dwWriteTimeout);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetBreakOn(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetBreakOff(uint ftHandle);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_GetStatus(uint ftHandle, ref uint lpdwAmountInRxQueue, ref uint lpdwAmountInTxQueue, ref uint lpdwEventStatus);

	[DllImport("FTD2XX.dll")]
	private unsafe static extern FT_STATUS FT_SetEventNotification(uint ftHandle, uint dwEventMask, void* pvArg);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetLatencyTimer(uint ftHandle, byte ucTimer);

	[DllImport("FTD2XX.dll")]
	private static extern FT_STATUS FT_SetUSBParameters(uint ftHandle, uint dwInTransferSize, uint dwOutTransferSize);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string spName);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(IntPtr hHandle);

	public static void SetMessage(eMessage message)
	{
		mMessage = message;
	}

	public static void InitializeSerialPort()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		cmbParity = ((object)Settings.Default.Parity).ToString();
		cmbStopBits = ((object)Settings.Default.StopBits).ToString();
		cmbDataBits = Settings.Default.DataBits.ToString();
		cmbBaudRate = Settings.Default.BaudRate.ToString();
		ISOMain.me.cmbPortName.Items.Clear();
		string[] portNames = SerialPort.GetPortNames();
		foreach (string s in portNames)
		{
			ISOMain.me.cmbPortName.Items.Add((object)cleanCOM(s));
		}
		if (ISOMain.me.cmbPortName.Items.Contains((object)Settings.Default.PortName))
		{
			((Control)ISOMain.me.cmbPortName).Text = Settings.Default.PortName;
		}
		else if (ISOMain.me.cmbPortName.Items.Count > 0)
		{
			((ListControl)ISOMain.me.cmbPortName).SelectedIndex = 0;
		}
		comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
		ISOMain.addSerialMenuItem(ISOMain.serialMode);
	}

	private static string cleanCOM(string s)
	{
		if (s.IndexOf("COM") < 0)
		{
			return s;
		}
		StringBuilder stringBuilder = new StringBuilder(s);
		StringBuilder stringBuilder2 = new StringBuilder("COM");
		for (int i = 3; i < s.Length; i++)
		{
			if ((stringBuilder[i] >= '0') & (stringBuilder[i] <= '9'))
			{
				stringBuilder2.Append(stringBuilder[i]);
			}
		}
		return stringBuilder2.ToString();
	}

	public static void UpdateSerialPort()
	{
		int num = -1;
		for (int i = 0; i < ISOMain.me.cmbPortName.Items.Count && i != ISOMain.m_serial.Length; i++)
		{
			if (ISOMain.m_serial[i].Checked)
			{
				num = i;
			}
		}
		ISOMain.me.cmbPortName.Items.Clear();
		string[] portNames = SerialPort.GetPortNames();
		foreach (string s in portNames)
		{
			ISOMain.me.cmbPortName.Items.Add((object)cleanCOM(s));
		}
		if ((num != -1) & (num < ISOMain.me.cmbPortName.Items.Count))
		{
			((ListControl)ISOMain.me.cmbPortName).SelectedIndex = num;
		}
		ISOMain.addSerialMenuItem(num != -1);
	}

	public static bool openSerialPort(int rate)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		ackRead = false;
		try
		{
			if (comport.IsOpen)
			{
				comport.Close();
			}
			comport.PortName = ((Control)ISOMain.me.cmbPortName).Text;
			comport.BaudRate = rate;
			comport.DataBits = int.Parse(cmbDataBits);
			comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits);
			comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity);
			comport.WriteTimeout = 2000;
			comport.Open();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void closeSerialPort(bool wait)
	{
		if (wait)
		{
			((Control)ISOMain.me).Cursor = Cursors.WaitCursor;
		}
		Thread.Sleep(2048);
		if (comport.IsOpen)
		{
			if (!ISOMain.comFailed)
			{
				ISORead.SendWalbroInit();
			}
			comport.Close();
		}
		if (wait)
		{
			((Control)ISOMain.me).Cursor = Cursors.Default;
		}
	}

	public static void serialWrite(byte[] data, int len, bool csum)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		ackRead = false;
		rLength = len;
		if (len != -1)
		{
			rStart = 0;
			xStart = 0;
			sIndex = 0;
		}
		if ((data == null) | !comport.IsOpen)
		{
			return;
		}
		if (csum)
		{
			int num = 0;
			int i;
			for (i = 0; i < data.Length - 1; i++)
			{
				num += data[i];
			}
			if (i > 0)
			{
				data[i] = (byte)(num & 0xFF);
			}
		}
		try
		{
			comport.Write(data, 0, data.Length);
			ISOMain.USBLed(1);
		}
		catch
		{
			ISOMain.comFailed = true;
			ISOMain.me.QueryConnect();
			ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 356] + comport.PortName, 2);
		}
		if ((ISOMain.mDebug & 0xC) > 0)
		{
			ISOMain.WriteTrcFile(data, 0, data.Length, ">");
		}
	}

	private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		if (!comport.IsOpen)
		{
			return;
		}
		int bytesToRead = comport.BytesToRead;
		if ((ISORead.mMode == eMode.MODE_WALBRO_SENSORS) & (bytesToRead < 8))
		{
			return;
		}
		try
		{
			comport.Read(rBuffer, sIndex, bytesToRead);
			if ((ISOMain.mDebug & 0xC) > 0)
			{
				ISOMain.WriteTrcFile(rBuffer, sIndex, bytesToRead, "<");
			}
			if (rStart > 3584)
			{
				Array.Copy(rBuffer, 3328, rBuffer, 256, 512);
				sIndex -= 3072;
				rStart -= 3072;
			}
			int num = sIndex + bytesToRead;
			bool flag = false;
			if (rLength < 0)
			{
				if (rStart == 0)
				{
					rStart = 5;
				}
				int i;
				for (i = 0; i < bytesToRead; i++)
				{
					if (rBuffer[sIndex + i] == 58)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					xStart = sIndex + i;
					wLength = xStart - rStart;
				}
			}
			else if ((ISORead.mMode == eMode.MODE_WALBRO_DOWNLOAD) & (rLength > 2))
			{
				int i;
				for (i = sIndex; i < num && rBuffer[i] != 240; i++)
				{
				}
				if ((i - rStart > 2) & (i < num))
				{
					rStart = i - 3;
					wLength = rLength;
					flag = true;
				}
			}
			else if (num >= rStart + rLength)
			{
				wLength = rLength;
				flag = true;
			}
			if (flag)
			{
				ackRead = true;
				flagOut = 0;
				rFlag = 0;
			}
			sIndex = num;
		}
		catch
		{
		}
	}

	public static uint CreateDeviceInfoList()
	{
		try
		{
			FT_STATUS fT_STATUS = FT_STATUS.FT_OTHER_ERROR;
			uint lpdwNumDevs = 0u;
			if (FT_CreateDeviceInfoList(ref lpdwNumDevs) == FT_STATUS.FT_OK)
			{
				return lpdwNumDevs;
			}
			return 0u;
		}
		catch
		{
			return 0u;
		}
	}

	public unsafe static bool ListUnopenDevices(uint Flag)
	{
		FT_STATUS fT_STATUS = FT_STATUS.FT_OTHER_ERROR;
		byte[] array = new byte[64];
		int num = -1;
		num = ((ListControl)ISOMain.me.lbDevList).SelectedIndex;
		dwListDescFlags = Flag;
		uint num2 = default(uint);
		try
		{
			void* pvArg = &num2;
			if (FT_ListDevices(pvArg, null, 2147483648u) == FT_STATUS.FT_OK)
			{
				if (dwListDescFlags == 536870912)
				{
					for (int i = 0; i < num2; i++)
					{
						ISOMain.me.lbDevList.Items.Add((object)i);
					}
				}
				else
				{
					for (int i = 0; i < num2; i++)
					{
						fixed (byte* pvArg2 = array)
						{
							if (FT_ListDevices((uint)i, pvArg2, dwListDescFlags) == FT_STATUS.FT_OK)
							{
								ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
								string text = aSCIIEncoding.GetString(array, 0, array.Length);
								ISOMain.me.lbDevList.Items.Add((object)text);
								continue;
							}
							ISOMain.addUSBMenuItem();
							return false;
						}
					}
				}
			}
		}
		catch
		{
			num2 = 0u;
		}
		if ((num < 0) & (num2 != 0))
		{
			num = 0;
		}
		else if (num2 == 0)
		{
			num = -1;
		}
		((ListControl)ISOMain.me.lbDevList).SelectedIndex = num;
		ISOMain.addUSBMenuItem();
		return true;
	}

	public unsafe static bool FTDOpen(uint Index, uint baud)
	{
		FT_STATUS fT_STATUS = FT_STATUS.FT_OTHER_ERROR;
		byte ucTimer = 4;
		flagOut = 0;
		rFlag = 0;
		ISORead.SwitchMode(eMode.MODE_NULL);
		if (m_hPort != 0)
		{
			FTDClose(wait: false);
		}
		uint num = dwListDescFlags & 0xBFFFFFFFu;
		num = dwListDescFlags & 0xDFFFFFFFu;
		if (num == 0)
		{
			fT_STATUS = FT_Open(Index, ref m_hPort);
		}
		else
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			fixed (byte* bytes = aSCIIEncoding.GetBytes(((Control)ISOMain.me.lbDevList).Text))
			{
				fT_STATUS = FT_OpenEx(bytes, num, ref m_hPort);
			}
		}
		if (fT_STATUS == FT_STATUS.FT_OK)
		{
			Terminate = false;
			ISOMain.serialMode = false;
			ISOMain.addUSBMenuItem();
			hEvent = CreateEvent(IntPtr.Zero, bManualReset: false, bInitialState: false, "");
			EventMask = 1u;
			void* pvArg = (void*)hEvent;
			fT_STATUS = FT_SetEventNotification(m_hPort, EventMask, pvArg);
			pThreadRead = new Thread(ThreadProc);
			pThreadRead.Start();
			FT_SetDataCharacteristics(m_hPort, 8, 0, 0);
			FT_SetFlowControl(m_hPort, 0, 17, 19);
			FT_SetUSBParameters(m_hPort, 128u, 0u);
			FT_SetTimeouts(m_hPort, 150u, 150u);
			fT_STATUS = FT_SetLatencyTimer(m_hPort, ucTimer);
			FTHiSpeed(baud, purge: true);
			return true;
		}
		return false;
	}

	public static void FTHiSpeed(uint baud, bool purge)
	{
		if (m_hPort != 0)
		{
			FT_SetBaudRate(m_hPort, baud);
			if (purge)
			{
				FT_Purge(m_hPort, 3u);
			}
		}
	}

	private unsafe static void ThreadProc()
	{
		uint lpdwBytesReturned = 0u;
		uint lpdwAmountInRxQueue = 0u;
		uint lpdwAmountInTxQueue = 0u;
		uint lpdwEventStatus = 0u;
		while (!Terminate && m_hPort != 0)
		{
			WaitForSingleObject(hEvent, 1024u);
			if (pxBuffer <= 0)
			{
				continue;
			}
			fixed (byte* ptr = rBuffer)
			{
				FT_GetStatus(m_hPort, ref lpdwAmountInRxQueue, ref lpdwAmountInTxQueue, ref lpdwEventStatus);
				if (lpdwAmountInRxQueue != 0)
				{
					FT_Read(m_hPort, ptr + (int)rIndex, 1u, ref lpdwBytesReturned);
					if ((ISOMain.mDebug & 0xC) > 0)
					{
						ISOMain.WriteTrcFile(rBuffer, (int)rIndex, (int)lpdwAmountInRxQueue, "<");
					}
					if (rBuffer[rIndex] == wByte[0])
					{
						pxBuffer--;
						rIndex += lpdwBytesReturned;
					}
					else
					{
						pxBuffer = 0;
					}
				}
				if (pxBuffer > 0)
				{
					FTDWriteByte();
				}
			}
		}
	}

	public unsafe static void FTDRead()
	{
		uint num = 0u;
		uint num2 = 0u;
		uint lpdwAmountInTxQueue = 0u;
		uint lpdwEventStatus = 0u;
		if (m_hPort == 0 || pxBuffer != 0)
		{
			return;
		}
		fixed (byte* ptr = rBuffer)
		{
			num = 0u;
			num2 = 0u;
			FT_GetStatus(m_hPort, ref num2, ref lpdwAmountInTxQueue, ref lpdwEventStatus);
			if (num2 != 0)
			{
				FT_Read(m_hPort, ptr + (int)rIndex, num2, ref num);
				if ((ISOMain.mDebug & 0xC) > 0)
				{
					ISOMain.WriteTrcFile(rBuffer, (int)rIndex, (int)num2, "<");
				}
				rIndex = (rIndex + num) % 4096;
				if ((rLength < 0) & (rIndex > rStart))
				{
					if ((rBuffer[rStart] & 0x7F) == 0)
					{
						if (rIndex > rStart + 3)
						{
							rLength = rBuffer[rStart + 3] + 5;
						}
					}
					else
					{
						rLength = (rBuffer[rStart] & 0x7F) + 4;
					}
				}
			}
			else
			{
				ISOMain.USBLed(0);
			}
			if ((rIndex >= rStart + rLength) & (rLength > 0))
			{
				ISOMain.USBLed(1);
				ISORead.ReadData(rBuffer, rStart, rLength, eEcho);
				if (eEcho)
				{
					rStart = rLength;
					eEcho = false;
					rLength = wLength;
				}
				else
				{
					rIndex = 0u;
					flagOut = 0;
					rFlag = 0;
				}
			}
		}
	}

	public unsafe static void FTDWriteByte()
	{
		if (pxBuffer != 0)
		{
			uint lpdwBytesWritten = 0u;
			wByte[0] = wBuffer[lnBuffer - pxBuffer];
			fixed (byte* lpBuffer = wByte)
			{
				FT_Write(m_hPort, lpBuffer, 1u, ref lpdwBytesWritten);
			}
			if ((ISOMain.mDebug & 0xC) > 0)
			{
				ISOMain.WriteTrcFile(wByte, 0, 1, ">");
			}
		}
	}

	public unsafe static bool FTDWrite(byte[] msg, int lr, bool echo, bool line)
	{
		uint lpdwBytesWritten = 0u;
		flagOut = 0;
		if (echo)
		{
			rLength = msg.Length;
		}
		else
		{
			rLength = lr;
		}
		eEcho = echo;
		wLength = lr;
		FT_STATUS fT_STATUS;
		if (msg != null)
		{
			fT_STATUS = FT_STATUS.FT_OTHER_ERROR;
			wBuffer = msg;
			if (line)
			{
				fixed (byte* lpBuffer = wBuffer)
				{
					fT_STATUS = FT_Write(m_hPort, lpBuffer, (uint)wBuffer.Length, ref lpdwBytesWritten);
				}
				pxBuffer = 0;
				if ((ISOMain.mDebug & 0xC) > 0)
				{
					ISOMain.WriteTrcFile(msg, 0, msg.Length, ">");
				}
			}
			else
			{
				lnBuffer = wBuffer.Length;
				pxBuffer = lnBuffer;
				FTDWriteByte();
			}
		}
		else
		{
			fT_STATUS = FT_Purge(m_hPort, 3u);
		}
		rIndex = 0u;
		rStart = 0;
		return fT_STATUS == FT_STATUS.FT_OK;
	}

	public static void SetBreak(byte v)
	{
		if (v == 0)
		{
			FT_SetBreakOn(m_hPort);
		}
		else
		{
			FT_SetBreakOff(m_hPort);
		}
		ISOMain.USBLed(v ^ 1);
	}

	public static void SetflagOut(int p)
	{
		if (p < 0)
		{
			imFlag = true;
		}
		else
		{
			flagOut = LONG_TIMEOUT / IntV * p / 10;
		}
	}

	public static void sensorDisplay()
	{
		try
		{
			interval = (interval + 1) % 128;
			if (ISOMain.swMode != 0 && interval % 64 == 36)
			{
				((Control)ISOMain.me.pbDash).Invalidate();
			}
			if (ISOMain.swMode != 1)
			{
				if ((interval % 8 == 3) & (ISORead.vSens & ISOMain.eSens))
				{
					ISOMain.me.InvalidateGrid(1);
				}
				else if ((interval % 8 == 7) & (ISORead.vSens & ISOMain.eSens))
				{
					ISOMain.me.InvalidateGrid(0);
				}
				else if (interval % 64 == 62)
				{
					ISOMain.DisplayMsg(ISORead.dataSensor[5], 256);
				}
			}
			else if (interval % 8 == 3)
			{
				double num = double.Parse(ISORead.dataSensor[3]) * 10.0;
				ISOMain.me.pbDash_Update(3, (int)num);
				ISOMain.me.tvTest_Update(160, refresh: false);
				ISOMain.me.tvTest_Update(176, refresh: false);
			}
			if (ISOMain.swMode == 2)
			{
				if (interval % 8 == 3)
				{
					ISOMain.me.pbDash_Update(0, int.Parse(ISORead.dataSensor[0]));
					ISOMain.me.tvSensor_Update(13);
				}
				else if (interval % 8 == 7)
				{
					ISOMain.me.pbDash_Update(1, int.Parse(ISORead.dataSensor[1]));
					ISOMain.me.tvSensor_Update(17);
				}
				else if (interval % 16 == 12)
				{
					double num = double.Parse(ISORead.dataSensor[2]) * 10.0;
					ISOMain.me.pbDash_Update(2, (int)num);
					ISOMain.me.tvSensor_Update(31);
					ISOMain.me.tvSensor_Update(43);
					ISOMain.me.tvSensor_Update(46);
				}
				else if (interval % 64 == 29)
				{
					ISOMain.me.pbDash_Update(3, int.Parse(ISORead.dataSensor[3]));
					ISOMain.me.tvSensor_Update(10);
					ISOMain.me.tvSensor_Update(24);
					ISOMain.me.tvSensor_Update(27);
					ISOMain.me.tvSensor_Update(34);
					ISOMain.me.tvSensor_Update(38);
					ISOMain.me.tvSensor_Update(54);
				}
			}
		}
		catch
		{
			ISOMain.DisplayMsg(":CATCH > " + interval + "\r", 32);
		}
	}

	public static void readTimer()
	{
		//IL_0bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10af: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a73: Invalid comparison between Unknown and I4
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Invalid comparison between Unknown and I4
		//IL_0e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		eMode mMode = ISORead.mMode;
		if (comport.IsOpen)
		{
			ISOMain.USBLed(0);
			if (ackRead)
			{
				flag = ISORead.readSerial(rBuffer, rStart, wLength);
				if ((rLength < 0) & (xStart > rStart))
				{
					if (ISOMain.swMode == 1)
					{
						ISORead.breakSensor();
					}
					else if (flag)
					{
						ISensor.DataSensorUpdate(rBuffer, rStart, rLength);
					}
					rStart = xStart;
				}
			}
			switch (mMode)
			{
			case eMode.MODE_NULL:
			{
				int num2 = (ISORead.mFlash ? SYNC_TIMEOUT : (LONG_TIMEOUT / 8));
				if (!((flagOut++ > num2 * ((!ISOMain.notryCnx) ? 1 : 10) / IntV) | imFlag))
				{
					break;
				}
				if ((ISORead.iRetry == 0) | (ISOMain.sbLog.Length == 0))
				{
					if (rSafe > 0)
					{
						ISOMain.clearLog();
					}
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 233], 32);
				}
				else
				{
					ISOMain.DisplayMsg(".", 32);
				}
				ISORead.WalbroInitialization();
				interval = 0;
				imFlag = false;
				flagOut = 0;
				rFlag = 0;
				break;
			}
			case eMode.MODE_WALBRO_VERSION:
				if (flagOut++ <= 200 / IntV)
				{
					break;
				}
				if (ISORead.ECUTyp < 0)
				{
					eMessage eMessage3 = mMessage;
					if (eMessage3 != eMessage.ERR_NULL && eMessage3 == eMessage.ERR_ABORT)
					{
						mMessage = eMessage.ERR_NULL;
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 317], 3);
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 317], 32);
						ISORead.mFlash = false;
						ISOMain.infosConnect(2);
						ISOMain.me.readUnkownMap(ISORead.dataSensor[65]);
						flagOut = 0;
					}
				}
				else if (rFlag++ > 3)
				{
					rFlag = 0;
					ISORead.SwitchMode(eMode.MODE_NULL);
				}
				else
				{
					ISORead.SwitchMode(mMode);
				}
				break;
			case eMode.MODE_WALBRO_INFO:
			case eMode.MODE_WALBRO_DTC:
				if (flagOut++ > 150 / IntV)
				{
					if (rFlag++ > 3)
					{
						rFlag = 0;
						ISORead.SwitchMode(eMode.MODE_NULL);
					}
					else
					{
						ISORead.SwitchMode(mMode);
					}
				}
				break;
			case eMode.MODE_WALBRO_SET_VALUE:
			case eMode.MODE_WALBRO_CLEAR_DTC:
				if (flagOut++ > 600 / IntV)
				{
					if (rFlag++ > 3)
					{
						rFlag = 0;
						ISORead.SwitchMode(eMode.MODE_NULL);
					}
					else if (mMode != eMode.MODE_WALBRO_SET_VALUE)
					{
						ISORead.SwitchMode(mMode);
					}
				}
				break;
			case eMode.MODE_WALBRO_SENSORS:
			case eMode.MODE_WALBRO_TPS:
				if (flagOut++ > 150 / IntV)
				{
					rFlag = 0;
					ISORead.SwitchMode(eMode.MODE_NULL);
				}
				else
				{
					sensorDisplay();
				}
				break;
			case eMode.MODE_WALBRO_READ_MEM:
				if (flagOut++ <= 200 / IntV)
				{
					break;
				}
				if (rFlag++ > 200)
				{
					switch (mMessage)
					{
					case eMessage.ERR_TIMEOUT:
						mMessage = eMessage.ERR_NULL;
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 220], 2);
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
						ISORead.mFlash = false;
						ISORead.mLoad = false;
						ISOMain.me.breakConnection(msg: false);
						flagOut = 0;
						break;
					case eMessage.ERR_NULL:
						break;
					}
				}
				else
				{
					ISORead.SwitchMode(mMode);
				}
				break;
			case eMode.MODE_WALBRO_END_READ:
			case eMode.MODE_WALBRO_END_PROG:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				switch (mMessage)
				{
				case eMessage.END_DOWNLOAD:
				{
					mMessage = eMessage.ERR_NULL;
					int num = ((ISOMain.sRecovery | ISORead.safe) ? 2 : 0);
					if (ISORead.mLoad)
					{
						ISOMain.UploadDone();
					}
					else
					{
						ISORead.dataClear(68);
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, num + 352] + ISOMain.LangUI[ISOMain.mLang, 350], 1);
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, num + 214], 32);
						ISOMain.sRecovery = false;
					}
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISORead.safe = false;
					ISORead.SwitchMode(eMode.MODE_NULL);
					flagOut = 200;
					break;
				}
				case eMessage.ERR_TIMEOUT:
					mMessage = eMessage.ERR_NULL;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 220], 2);
					if (!ISORead.mLoad)
					{
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
					}
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISOMain.me.breakConnection(msg: false);
					flagOut = 0;
					break;
				}
				break;
			case eMode.MODE_WALBRO_SYNC:
			case eMode.MODE_WALBRO_UPROG:
			case eMode.MODE_WALBRO_ERASING:
			case eMode.MODE_WALBRO_ERASED:
			case eMode.MODE_WALBRO_DOWNLOAD:
				if ((flagOut++ > SYNC_TIMEOUT / IntV) | imFlag)
				{
					switch (mMessage)
					{
					case eMessage.ERR_TIMEOUT:
						mMessage = eMessage.ERR_NULL;
						ISOMain.DisplayMsg(ISORead.mFileText, 64);
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 220], 2);
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 290] + "\r", 32);
						ISORead.mFlash = false;
						ISORead.mLoad = false;
						ISOMain.me.breakConnection(msg: false);
						flagOut = 0;
						break;
					case eMessage.ERR_NULL:
						break;
					}
				}
				break;
			case eMode.MODE_WALBRO_ABORT:
			{
				eMessage eMessage2 = mMessage;
				if (eMessage2 != eMessage.ERR_NULL && eMessage2 == eMessage.ERR_ABORT)
				{
					mMessage = eMessage.ERR_NULL;
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 201], 3);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 201] + "\r", 32);
					ISOMain.me.breakConnection(msg: false);
					flagOut = 0;
				}
				break;
			}
			}
		}
		else
		{
			if (m_hPort == 0)
			{
				return;
			}
			if (pxBuffer == 0)
			{
				FTDRead();
			}
			switch (mMode)
			{
			case eMode.MODE_NULL:
				if (!((flagOut++ > LONG_TIMEOUT * ((!ISOMain.notryCnx) ? 1 : 5) / IntV) | imFlag))
				{
					break;
				}
				pxBuffer = 0;
				rIndex = 0u;
				if ((ISORead.iRetry == 0) | (ISOMain.sbLog.Length == 0))
				{
					if (rSafe > 0)
					{
						ISOMain.clearLog();
					}
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 233], 32);
				}
				else
				{
					ISOMain.DisplayMsg(".", 32);
				}
				if (ISOMain.mECU >> 1 != (ISORead.iRetry & 1))
				{
					sECU = 0;
					ISORead.KWPInit();
					ISORead.dataClear(68);
				}
				else
				{
					ISORead.Initialization(51);
				}
				imFlag = false;
				flagOut = 0;
				rFlag = 0;
				break;
			case eMode.MODE_INIT:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				if (++rFlag > 3)
				{
					if ((ISOMain.mDebug & 2) > 0)
					{
						ISOMain.WriteTrcFile(null, 0, 0, "Init : " + rFlag + ";" + sECU);
					}
					ISORead.mMode = eMode.MODE_NULL;
					Thread.Sleep(300);
					if (ISORead.mId & (ISORead.iDST == 1) & ISOMain._KTM)
					{
						if (ISORead.mLoad)
						{
							if (sECU++ > (ISORead.reLoad ? 7 : 2))
							{
								ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 200], 2);
								ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
								ISORead.mFlash = false;
								ISORead.mLoad = false;
								ISOMain.me.breakConnection(msg: false);
							}
							else
							{
								ISORead.KWPInit();
							}
						}
						else if (!ISORead.reLoad)
						{
							ISOMain._2nECU = sECU++ < 2;
							ISORead.iDST = (ISOMain._2nECU ? 1 : 0);
							ISORead.KWPInit();
						}
					}
					else
					{
						ISORead.Initialization(51);
					}
					flagOut = 0;
					rFlag = 0;
				}
				else if (ISORead.reLoad)
				{
					Thread.Sleep(100);
					ISORead.KWPInit();
				}
				else
				{
					ISORead.SwitchMode(eMode.MODE_INIT);
				}
				flagOut = 0;
				break;
			case eMode.MODE_SEED:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				if (++rFlag > 3)
				{
					rSafe += ((ISOMain.swMode == 0) ? 1 : 0);
					ISOMain.sagemECU = ISOMain.TypTable < 8;
					if (((rSafe == 4) & ISOMain.FlashEnable()) && (int)ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 202], 9) == 1)
					{
						ISOMain.me.safeMenuItem_Click(null, null);
						flagOut = 0;
						rFlag = 0;
						break;
					}
					ISORead.SwitchMode(eMode.MODE_NULL);
				}
				else
				{
					checkSagem = false;
					ISORead.SendCheckDevice();
				}
				ISOMain.USBLed(0);
				flagOut = 0;
				break;
			case eMode.MODE_READ_PIDS:
			case eMode.MODE_READ_ACTIVE:
			case eMode.MODE_READ_SENSORS:
			case eMode.MODE_SAGEM_CMD:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				if (rFlag++ > 3)
				{
					rFlag = 0;
					ISORead.SwitchMode(eMode.MODE_NULL);
				}
				else if (ISOMain._LC4 & ISOMain._2nECU & ISOMain.tCode)
				{
					if (ISORead.iDST == 1)
					{
						ISORead.newSession(0);
					}
					else if (ISORead.readCodes > 0)
					{
						ISORead.newSession(1);
					}
				}
				else
				{
					ISORead.SendCheckDevice();
				}
				ISOMain.USBLed(0);
				flagOut = 0;
				break;
			case eMode.MODE_READ_DATA_BLOCK:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				switch (mMessage)
				{
				case eMessage.ERR_NO_SEED:
					if (ISOMain.swMode == 0)
					{
						mMessage = eMessage.ERR_NULL;
						if ((int)ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 202], 9) == 1)
						{
							ISOMain.sRecovery = true;
						}
						ISORead.mSafe = true;
					}
					ISOMain.me.breakConnection(msg: false);
					break;
				default:
					if (rFlag++ > 3)
					{
						rFlag = 0;
						ISORead.SwitchMode(eMode.MODE_NULL);
					}
					else
					{
						ISORead.SendCheckDevice();
					}
					ISOMain.USBLed(0);
					flagOut = 0;
					break;
				case eMessage.ERR_NULL:
					break;
				}
				break;
			case eMode.MODE_DIAGNOSTIC:
			case eMode.MODE_STOP_DIAG:
				if (flagOut++ <= 150 / IntV)
				{
					break;
				}
				switch (mMessage)
				{
				case eMessage.END_DIAG:
					mMessage = eMessage.ERR_NULL;
					if ((ISOMain.swMode == 0) & (ISORead.mTest == 0))
					{
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, ISOMain.sagemECU ? 232 : 305], 1);
					}
					ISORead.SwitchMode(eMode.MODE_NULL);
					ISOMain.testTick = 20;
					flagOut = 400;
					break;
				default:
					if (rFlag++ > 3)
					{
						ISORead.SwitchMode(eMode.MODE_NULL);
					}
					else
					{
						ISORead.SendCheckDevice();
					}
					ISOMain.USBLed(0);
					flagOut = 0;
					break;
				case eMessage.ERR_NULL:
					break;
				}
				break;
			case eMode.MODE_READ_IDENT:
			case eMode.MODE_ACCESS:
				if (flagOut++ <= 750 / IntV)
				{
					break;
				}
				switch (mMessage)
				{
				case eMessage.ERR_VERSION_MAP:
					ISOMain.sRecovery = false;
					mMessage = eMessage.ERR_NULL;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 321], 2);
					ISORead.SwitchMode(eMode.MODE_NULL);
					flagOut = 400;
					break;
				case eMessage.ERR_AUTHENTIFY:
					mMessage = eMessage.ERR_NULL;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 207], 3);
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISORead.SwitchMode(eMode.MODE_NULL);
					flagOut = 0;
					break;
				default:
					if (rFlag++ > 4)
					{
						mMessage = eMessage.ERR_NULL;
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 212], 3);
						ISORead.SwitchMode(eMode.MODE_NULL);
					}
					else
					{
						ISORead.SwitchMode(mMode);
					}
					ISORead.SwitchMode(eMode.MODE_NULL);
					flagOut = 0;
					break;
				case eMessage.ERR_NULL:
					break;
				}
				break;
			case eMode.MODE_START_PROG:
			case eMode.MODE_SPEED_COM:
			case eMode.MODE_START_DOWNLOAD:
			case eMode.MODE_DOWNLOAD_EXIT:
			case eMode.MODE_END_PROG:
			case eMode.MODE_ECU_RESET:
				if (flagOut++ <= 750 / IntV)
				{
					break;
				}
				switch (mMessage)
				{
				case eMessage.END_DOWNLOAD:
				{
					mMessage = eMessage.ERR_NULL;
					FTHiSpeed(10400u, purge: true);
					int num3 = ((ISOMain.sRecovery | ISORead.safe) ? 2 : 0);
					if (ISORead.mLoad)
					{
						ISOMain.UploadDone();
					}
					else
					{
						ISORead.dataClear(68);
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, num3 + 214], 1);
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, num3 + 214], 32);
						ISOMain.pForce = ulong.MaxValue;
						ISOMain.sRecovery = false;
					}
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISORead.safe = false;
					ISORead.SwitchMode(eMode.MODE_NULL);
					flagOut = 200;
					break;
				}
				case eMessage.ERR_FAILED:
					mMessage = eMessage.ERR_NULL;
					FTHiSpeed(10400u, purge: true);
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 238], 1);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISOMain.me.breakConnection(msg: false);
					break;
				default:
					if (rFlag++ > 4)
					{
						mMessage = eMessage.ERR_NULL;
						FTHiSpeed(10400u, purge: true);
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 220], 2);
						if (!ISORead.mLoad)
						{
							ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
						}
						ISORead.mFlash = false;
						ISORead.mLoad = false;
						ISOMain.me.breakConnection(msg: false);
					}
					else
					{
						ISORead.SwitchMode(mMode);
					}
					flagOut = 0;
					break;
				case eMessage.ERR_NULL:
					break;
				}
				break;
			case eMode.MODE_DOWNLOAD:
			case eMode.MODE_READ_MEM:
				if (flagOut++ <= 200 / IntV)
				{
					break;
				}
				if (rFlag++ > 80)
				{
					switch (mMessage)
					{
					case eMessage.ERR_TIMEOUT:
						mMessage = eMessage.ERR_NULL;
						FTHiSpeed(10400u, purge: true);
						ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 220], 2);
						if (!ISORead.mLoad)
						{
							ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 200], 32);
						}
						ISORead.mFlash = false;
						ISORead.mLoad = false;
						ISOMain.me.breakConnection(msg: false);
						flagOut = 0;
						break;
					case eMessage.ERR_NULL:
						break;
					}
				}
				else if (ISOMain._KTM & ISORead.mLoad & (ISORead.rstLoad < 10) & (rLoad++ > 8))
				{
					ISORead.reLoad = true;
					ISORead.rstLoad++;
					ISOMain.KWP = false;
					ISORead.KWPInit();
					rFlag = -12;
					flagOut = 0;
					rLoad = 0;
				}
				else
				{
					ISORead.SwitchMode(mMode);
				}
				break;
			case eMode.MODE_ABORT:
				switch (mMessage)
				{
				case eMessage.ERR_AUTHENTIFY:
					mMessage = eMessage.ERR_NULL;
					FTHiSpeed(10400u, purge: true);
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 208], 3);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 208] + "\r", 32);
					ISOMain.me.breakConnection(msg: false);
					flagOut = 0;
					break;
				case eMessage.ERR_ABORT:
					mMessage = eMessage.ERR_NULL;
					FTHiSpeed(10400u, purge: true);
					ISORead.mFlash = false;
					ISORead.mLoad = false;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 201], 3);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 201] + "\r", 32);
					ISOMain.me.breakConnection(msg: false);
					flagOut = 0;
					break;
				default:
					mMessage = eMessage.ERR_NULL;
					ISORead.mLoad = false;
					ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 212], 3);
					ISOMain.me.breakConnection(msg: false);
					flagOut = 0;
					break;
				case eMessage.ERR_NULL:
					break;
				}
				break;
			}
		}
	}

	public static void FTDClose(bool wait)
	{
		if (m_hPort != 0)
		{
			Terminate = true;
			if (wait)
			{
				((Control)ISOMain.me).Cursor = Cursors.WaitCursor;
			}
			Thread.Sleep(2048);
			FT_Close(m_hPort);
			m_hPort = 0u;
			if (wait)
			{
				((Control)ISOMain.me).Cursor = Cursors.Default;
			}
		}
	}

	static ISOFT()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		LONG_TIMEOUT = 6000;
		SYNC_TIMEOUT = 2500;
		IntV = ISOMain.me.cReadTimer.Interval;
		imFlag = false;
		Terminate = false;
		comport = new SerialPort();
		rBuffer = new byte[8192];
		rIndex = 0u;
		sIndex = 0;
		eEcho = false;
		wByte = new byte[1];
		pxBuffer = 0;
	}
}
