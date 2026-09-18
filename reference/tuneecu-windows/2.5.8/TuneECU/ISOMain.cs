using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Microsoft.Win32;
using TuneECU.Controls;
using TuneECU.Properties;
using TuneLibrary;

namespace TuneECU;

public class ISOMain : Form
{
	public class DoubleBufferPanel : Panel
	{
		public DoubleBufferPanel()
		{
			((Control)this).DoubleBuffered = true;
			((Control)this).SetStyle((ControlStyles)139266, true);
			((Control)this).UpdateStyles();
		}
	}

	public const int TASKBAR_SHOW = 64;

	public const int TASKBAR_HIDE = 128;

	public const int TEST_TIME = 20;

	public const int PSTART = 5;

	public const uint FT_BAUD_10400 = 10400u;

	public const uint FT_BAUD_57600 = 57600u;

	public const uint FT_BAUD_62400 = 62400u;

	public const uint FT_BAUD_62500 = 62500u;

	public const uint FT_LIST_NUMBER_ONLY = 2147483648u;

	public const uint FT_LIST_BY_INDEX = 1073741824u;

	public const uint FT_LIST_ALL = 536870912u;

	public const uint FT_OPEN_BY_SERIAL_NUMBER = 1u;

	public const uint FT_OPEN_BY_DESCRIPTION = 2u;

	public const int defLABEL_HEIGHT = 15;

	public const int cLang = 5;

	private const int DEF_HEIGHT = 600;

	private const int DASH_WIDTH = 800;

	private const int DASH_HEIGHT = 453;

	private const int NEEDLE_LARGE = 375;

	private const int NEEDLE_SMALL = 203;

	private const int tSHOW = 12;

	private const int libVersion = 140;

	private const int iTiming = 196;

	public static ISOMain me;

	public static IDataObject clipData;

	public static string prmTitle;

	public static IntPtr logHandle;

	public static IntPtr infoHandle;

	private static int groundTask;

	public static string subVersion;

	private bool HideTask;

	private bool TaskBarVisible;

	private static bool enWide;

	private static bool wState;

	private static bool enTest;

	private static bool edShift;

	private bool autoConnect;

	public static bool dConnect;

	private bool mPaste;

	private bool mStart;

	private bool notry;

	private bool USBIgnore;

	public static bool edState;

	public static bool eSave;

	public static bool pSave;

	public static bool comFailed;

	public static bool compareF;

	public static bool sRecovery;

	public static bool toHide;

	public static bool noMap;

	public static bool lbSelect;

	public static bool oneSelect;

	public static bool graphSelect;

	public static bool editSelect;

	public static bool eSens;

	public static bool mConnect;

	public static bool keyF7;

	public static bool editCurve;

	public static bool egSave;

	public static bool showGraph;

	public static bool showMod;

	public static bool showView;

	public static bool rowTPS;

	public static bool oneCurve;

	public static bool oneTrim;

	public static bool pCent;

	public static bool sCent;

	public static bool dcLabel;

	public static bool pcEdit;

	public static bool pcGraph;

	public static bool pcShow;

	public static bool showInfo;

	public static bool showLog;

	public static bool InfoTop;

	public static bool LogTop;

	public static bool showSplash;

	public static bool altMap;

	public static bool altParams;

	public static bool rDump;

	public static bool KWP;

	public static bool _2nECU;

	public static bool tCode;

	public static bool infoMod;

	public static bool sagemECU;

	public static bool ISCDiff;

	public static bool _Apri;

	public static bool _Bene;

	public static bool _KTM;

	public static bool _2ndT;

	public static bool _Flap;

	public static bool _Twin;

	public static bool _Four;

	public static bool _LC4;

	public static bool _Walbro;

	public static bool noLoop;

	public static bool _sagemF;

	public static bool epMap;

	public static bool _LTrim;

	public static bool onTest;

	public static bool rstTrim;

	public static bool unSave;

	public static bool EXBVReset;

	public static bool ISCVReset;

	public static bool setTPS;

	public static bool notryCnx;

	public static bool serialMode;

	private string strTest;

	private string separator;

	private static string lastFile;

	private static string cmpFile;

	private static string errFile;

	private static string lastPort;

	private static string usbSerial;

	public static string mapName;

	public static string cmpName;

	public static string idMap;

	public static string cpMap;

	public static DateTime today;

	public static StringBuilder sbLog;

	public static string descMap;

	public static string gFormat;

	public static string lhLabel;

	public static string lvLabel;

	private double[] MapClip;

	private byte[] Mapbuffer;

	private static byte[] tmMap;

	public static byte[] MapTrim;

	public static byte[] cmpTrim;

	public static byte[] histMemo;

	public static byte[] egCol;

	public static byte[] egRow;

	private static int tagMap;

	public static int eInfo;

	public static int[] iTable;

	public static double[] eTable;

	public static double dColor;

	public static double eColor;

	public static double gScale;

	public static double mProgress;

	private double egMax;

	private double egMin;

	private decimal eValue;

	private decimal UDInc;

	private decimal EDInc;

	private decimal egInc;

	private static int dClear;

	private int showMapID;

	private int showCells;

	private int UDTop;

	private int USBWait;

	private int flashTempo;

	private int errExit;

	private int eSensor;

	private int exNode;

	private int btnMode;

	private int btnPress;

	private int HideUD;

	private int offWide;

	private int offGr;

	private int yCurve;

	private int edGr;

	private int egClick;

	private int pcType;

	private byte mRun;

	private byte sRun;

	private static int eTag;

	private static TreeNode aNode;

	private static int iConnect;

	public static int iStart;

	public static int QConnect;

	public static int mLed;

	public static int mView;

	public static int TypTable;

	public static int typCopy;

	public static int typInfo;

	public static int wRef;

	public static int mECU;

	public static int offWOT;

	public static int stepEXBV;

	public static int stepISCV;

	public static int btnTest;

	public static int outTest;

	public static int testTick;

	public static int rTrim;

	public static int tRetry;

	public static int iTag;

	public static int sTag;

	public static int rpmMap;

	public static int firstSelect;

	public static int lastSelect;

	public static int kDown;

	public static int lDown;

	public static int mDown;

	public static int xDown;

	public static int flashEnable;

	public static int nop;

	public static int sBloc;

	public static int warn;

	public static int eCurv;

	public static int sCurv;

	public static int eFirst;

	public static int eLast;

	public static int mCells;

	public static int eTrim;

	public static int xTrim;

	public static int cTrim;

	public static int iTrim;

	public static int wbTrim;

	public static int gCol;

	public static int gOff;

	public static int gRow;

	public static int fREV;

	public static int gREV;

	public static int iREV;

	public static int sREV;

	public static int mPOS;

	public static int lbH;

	public static int lbS;

	public static int lbW;

	public static double[] gridArray;

	public static double[,] gTable;

	public static short[] LH_Array;

	public static short[] LV_Array;

	public static Color[] LV_Color;

	public static Color[] LH_Color;

	public static Color[] xColor;

	public static short[] dataRefresh;

	public static int refreshCode;

	public static int mLang;

	public static int swMode;

	public static int swTest;

	public static int avTest;

	public static int avTrim;

	public static int eqDev;

	public static int RevCount;

	public static int pTiming;

	public static ulong pForce;

	public static int mDebug;

	public static int tDebug;

	public static int sProgress;

	public static int refBar;

	public static int oSys;

	public static int tpsMin;

	public static int tpsMax;

	public static float dpi;

	public static ToolStripMenuItem[] m_serial;

	public static ToolStripMenuItem[] m_USB;

	private static Color[] lColor;

	private static Color[] mColor;

	private static Color[] qColor;

	private Warning warningBox;

	private AboutBox aboutForm;

	private Infos infoForm;

	private Logs logForm;

	private static QueryForm queryBox;

	private static MemoryStream grabMemoryStream;

	private static MemoryStream grabbingMemoryStream;

	private Cursor grabCursor;

	private Cursor grabbingCursor;

	private static int[] lbSensors;

	private static int[] tipSensors;

	private ManagementEventWatcher watcher;

	public static int[] ptrMap;

	private StreamWriter writer;

	public static string[,] LangUI;

	private IContainer components;

	public Timer cReadTimer;

	private Label _mapInfos;

	private MenuStrip menuStrip;

	private ToolStripMenuItem fileMenuItem;

	private ToolStripMenuItem openMenuItem;

	private OpenFileDialog openFileDialog;

	private SaveFileDialog saveFileDialog;

	private Label _vehInfos;

	private ToolStripMenuItem ECUMenuItem;

	public ToolStripMenuItem flashMenuItem;

	public ToolStripMenuItem connectMenuItem;

	private ToolStripSeparator sepQMenuItem;

	private ToolStripMenuItem quitMenuItem;

	private Label _lbMap;

	private ImageList tv_Image;

	private GroupBox gbMap;

	private GroupBox gbVehicule;

	private TreeView tvVehicule;

	private ToolStripMenuItem editMenuItem;

	private ToolStripMenuItem copyMenuItem;

	private ToolStripMenuItem pasteMenuItem;

	private ToolStripMenuItem fusionMenuItem;

	private ToolStripSeparator sepRMenuItem;

	private ToolStripMenuItem safeMenuItem;

	private ContextMenuStrip cModifMenu;

	private ToolStripMenuItem modifSubMenu;

	private ContextMenuStrip cActiveMenu;

	private ToolStripMenuItem activeSubMenu;

	private ToolStripMenuItem saveMenuItem;

	private ToolStripMenuItem displayMenuItem;

	private ToolStripMenuItem graphMenuItem;

	private Timer activeAppTimer;

	public NumericUpDown valueUD;

	private Panel vUDpanel;

	private ToolStripSeparator toolStripSepR;

	private ToolStripMenuItem razTPSMenuItem;

	private ToolStripMenuItem optionsMenuItem;

	private ToolStripMenuItem languageMenuItem;

	private ToolStripMenuItem englishMenuItem;

	private ToolStripMenuItem frenchMenuItem;

	private ToolStripMenuItem eraseCodesMenuItem;

	private ToolStripMenuItem autoMenuItem;

	private Label _lbSensors;

	private GroupBox gbSensor;

	private Label _lbDash;

	private Label _lbDesc;

	private Label _lbCodes;

	private GroupBox gbError;

	private ListBox listCodes;

	private Panel panelCodes;

	private TextBox tbDescription;

	private PictureBox sensor_plus;

	private PictureBox sensor_minus;

	public GroupBox gbTable;

	public DoubleBufferPanel panelTable;

	public NumericUpDown editUpDown;

	public GroupBox gbDiag;

	private ToolStripMenuItem aboutMenuItem;

	public ListBox lbDevList;

	private Label _lbTests;

	protected ToolStripStatusLabel ledStatus;

	private StatusStrip statusStrip;

	public ToolStripMenuItem DevMenuItem;

	private ToolStripMenuItem logMenuItem;

	private ToolStripMenuItem infosMapMenuItem;

	public Panel panelDiag;

	private GroupBox gbTests;

	public TreeView tvSensor;

	public TreeView tvTests;

	private ToolStripMenuItem PCIIIMenuItem;

	private ToolStripSeparator sepPMenuItem;

	private ToolStripMenuItem compareMenuItem;

	private NumericUpDown adjustUD;

	private ContextMenuStrip cResetMenu;

	private ToolStripMenuItem resetSubMenu;

	private ToolStripStatusLabel battStatus;

	private ToolStripStatusLabel tpsStatus;

	private ToolStripStatusLabel loopStatus;

	private ToolStripSeparator sepLMenuItem;

	private ToolStripMenuItem historyMenuItem;

	private ToolStripMenuItem readMapMenuItem;

	private Panel Logo_Panel;

	private ToolStripMenuItem germanMenuItem;

	public PictureBox pbDash;

	public Panel EDpanel;

	private ToolStripMenuItem italianMenuItem;

	private ToolStripMenuItem spanishMenuItem;

	private ToolStripStatusLabel blankStatus;

	private ToolStripSeparator sepEMenuItem;

	private ToolStripMenuItem useTrimMenuItem;

	private ToolStripSeparator sepSMenuItem;

	private ToolStripMenuItem fullScreenMenuItem;

	private ContextMenuStrip cCopyMenu;

	private ToolStripMenuItem copySubMenu;

	private ToolStripMenuItem pasteSubMenu;

	private ToolStripMenuItem exportMenuItem;

	private ToolStripSeparator sepTMenuItem;

	public Button BtnRight;

	public Button BtnMid;

	public Button BtnLeft;

	private ContextMenuStrip cTrimMenu;

	private ToolStripMenuItem trimSubMenu;

	private ToolStripMenuItem portugueseMenuItem;

	public ListBox cmbPortName;

	private ToolStripMenuItem serialMenuItem;

	private ToolStripMenuItem uSBMenuItem;

	public ToolStripStatusLabel fileStatus;

	public TreeView tvMap;

	public ToolStripMenuItem TrimToLMenuItem;

	private ToolStripMenuItem saveBinMenuItem;

	[DllImport("user32", EntryPoint = "FindWindowA")]
	public static extern int FindWindows(string lpClassName, string lpWindowsName);

	[DllImport("user32")]
	public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

	[DllImport("user32.dll")]
	private static extern int GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	private static extern short GetKeyState(int keyCode);

	public ISOMain()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		TaskBarVisible = true;
		mStart = true;
		UDInc = 1m;
		EDInc = 1m;
		egInc = 1m;
		edGr = 1;
		egClick = -1;
		grabCursor = new Cursor((Stream)grabMemoryStream);
		grabbingCursor = new Cursor((Stream)grabbingMemoryStream);
		((Form)this)._002Ector();
		InitializeComponent();
		me = this;
	}

	private void ISOMain_Load(object sender, EventArgs e)
	{
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Invalid comparison between Unknown and I4
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		int result = 0;
		int result2 = 0;
		string text = Thread.CurrentThread.CurrentCulture.ToString();
		int num = (text.Contains("pt-") ? 5 : (text.Contains("es-") ? 4 : (text.Contains("it-") ? 3 : (text.Contains("de-") ? 2 : (text.Contains("fr-") ? 1 : 0)))));
		Rectangle bounds = Screen.PrimaryScreen.Bounds;
		errExit = (((bounds.Width < 1024) | (bounds.Height < 576)) ? 1 : 0);
		enWide = bounds.Height >= 720;
		offWide = 600 - ((Control)this).Height;
		lastFile = GetHKCUkey("Software\\TuneECU", "Properties", "LastTune", "");
		lastPort = GetHKCUkey("Software\\TuneECU", "Properties", "serialPort", "");
		usbSerial = GetHKCUkey("Software\\TuneECU", "Properties", "USBPort", "0");
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Language", num.ToString()), out mLang);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Mode", "0"), out var result3);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Sensors", "6143"), out eSensor);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "exNode", "1"), out exNode);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "LastECU", "1"), out mECU);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "PCFile", "0"), out pcType);
		serialMode = usbSerial.IndexOf("COM") == 0;
		sagemECU = mECU == 0;
		_KTM = mECU == 2;
		GetHKCUkey("Software\\TuneECU", "Properties", "Version", "1.8.0");
		autoConnect = GetHKCUkey("Software\\TuneECU", "Properties", "AutoConnect", "1") == "1";
		showGraph = GetHKCUkey("Software\\TuneECU", "Properties", "Graphic", "0") == "0";
		showSplash = GetHKCUkey("Software\\TuneECU", "Properties", "Splash", "1") == "1";
		separator = GetHKCUkey("Software\\TuneECU", "Properties", "Separator", "\t");
		_ = GetHKCUkey("Software\\TuneECU", "Properties", "noWarning", "0") == "0";
		wState = enWide & (GetHKCUkey("Software\\TuneECU", "Properties", "fullScreen", "0") == "1");
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Release", null), out result);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Timing", null), out pTiming);
		int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Debug", null), out mDebug);
		ulong.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "ForceOn", null), out pForce);
		if (pcType != 1)
		{
			pcType = 0;
		}
		if ((exNode + 1) / 2 != 1)
		{
			exNode = 1;
		}
		if ((result3 < 0) | (result3 > 2))
		{
			result3 = 0;
		}
		if (mLang > 5)
		{
			mLang = num;
		}
		if (mDebug == 0)
		{
			DelHKCUkey("Software\\TuneECU\\Properties", "Debug");
		}
		if ((pTiming < 180) | (pTiming > 219))
		{
			pTiming = 196;
		}
		pForce = (pForce << 56) ^ 0xFFFFFFFFFFFFFFFFuL;
		((Control)sensor_minus).Tag = (((eSensor & 0x1000) > 0) ? 1 : 0);
		autoMenuItem.Checked = autoConnect;
		iTable = Tune.tabMapB;
		MapTrim = new byte[1];
		cmpTrim = new byte[1];
		string text2 = Tune.mKTMmodel[0];
		if (text2.StartsWith("Version:"))
		{
			int.TryParse(text2.Substring(8, text2.Length - 8), out result2);
		}
		if ((result2 < 140) | (result2 / 10 != 14))
		{
			MessageBox.Show("    The program can't start because the TuneLibrary.dll version is incompatible !!!        ", "TuneECU", (MessageBoxButtons)0, (MessageBoxIcon)16);
			errExit = 4;
		}
		IDraw.LoadDashBmp();
		Graphics val = ((Control)this).CreateGraphics();
		dpi = val.DpiX;
		IDraw.initFonts();
		if ((errExit == 0) & (result < 140))
		{
			warningBox = new Warning();
			if ((int)((Form)warningBox).ShowDialog() == 1)
			{
				SetHKCUkey("Software\\TuneECU\\Properties", "Release", 140.ToString());
			}
			else
			{
				errExit = 2;
			}
		}
		if (errExit > 0)
		{
			((Form)this).WindowState = (FormWindowState)1;
			if ((errExit & 1) == 1)
			{
				DisplayBox("", LangUI[mLang, 334], 2);
			}
			Application.Exit();
			return;
		}
		componentsFontSize();
		((Control)this).Cursor = Cursors.WaitCursor;
		activeAppTimer.Enabled = true;
		today = DateTime.Today;
		oSys = getOSInfo();
		aboutForm = new AboutBox();
		infoForm = new Infos();
		logForm = new Logs();
		sbLog = new StringBuilder("");
		ISORead.Setkeys(11123772655450801483uL);
		cReadTimer.Enabled = true;
		tvVehicule.Nodes[0].Expand();
		SetDefTable();
		if ((lastFile != "") & File.Exists(lastFile))
		{
			OpenSelectFile(lastFile);
		}
		else
		{
			lastFile = null;
		}
		UpdateUI();
		((Control)_lbSensors).Tag = ((Control)gbSensor).Height;
		((Control)_lbTests).Tag = ((Control)gbTests).Height;
		HideTask = bounds.Height <= 600;
		if (HideTask)
		{
			HideBar();
		}
		((Control)sensor_minus).Visible = (eSensor & 0x1000) > 0;
		eSensor &= 2047;
		switch (result3)
		{
		case 0:
			TabButton_Click(BtnLeft);
			break;
		case 1:
			TabButton_Click(BtnRight);
			break;
		case 2:
			TabButton_Click(BtnMid);
			break;
		}
		graphMenuItem_Click(null, null);
		((Control)this).Text = "TuneECU" + getVersion().Substring(1);
		((Form)this).FormBorderStyle = (FormBorderStyle)(bounds.Height >= 600);
		refBar = ((ToolStripItem)fileStatus).Width;
		if (showSplash)
		{
			AboutBox.mOpacity = 300.0;
			aboutForm.mSplash.Checked = showSplash;
			((Control)aboutForm.mSplash).Visible = false;
			((Control)aboutForm.okButton).Visible = false;
			aboutForm.Opacitytimer.Enabled = true;
			((Control)aboutForm).Show();
			((Control)aboutForm).Refresh();
		}
		else if ((mDebug & 1) == 1)
		{
			WriteTrcFile(null, 0, 0, "");
		}
	}

	private void componentsFontSize()
	{
		Font rFont = IDraw.rFont;
		Font tFont = IDraw.tFont;
		Font tbFont = IDraw.tbFont;
		Font sgFont = IDraw.sgFont;
		((Control)menuStrip).Font = sgFont;
		((Control)cActiveMenu).Font = sgFont;
		((Control)cModifMenu).Font = sgFont;
		((Control)cResetMenu).Font = sgFont;
		((Control)cCopyMenu).Font = sgFont;
		((Control)cTrimMenu).Font = sgFont;
		((Control)tvMap).Font = tFont;
		((Control)tvSensor).Font = tFont;
		((Control)tvTests).Font = tFont;
		((Control)tvVehicule).Font = tFont;
		((Control)statusStrip).Font = tbFont;
		((ToolStripItem)fileStatus).Font = tbFont;
		((ToolStripItem)battStatus).Font = tbFont;
		((ToolStripItem)loopStatus).Font = tbFont;
		((ToolStripItem)tpsStatus).Font = tbFont;
		((Control)tbDescription).Font = IDraw.dFont;
		tvVehicule.Nodes[0].NodeFont = tbFont;
		for (int i = 0; i < 3; i++)
		{
			tvVehicule.Nodes[0].Nodes[i].NodeFont = rFont;
		}
		for (int i = 0; i < 3; i++)
		{
			tvMap.Nodes[i].NodeFont = tbFont;
		}
		for (int i = 0; i < 16; i++)
		{
			tvMap.Nodes[0].Nodes[i].NodeFont = rFont;
		}
		for (int i = 0; i < 6; i++)
		{
			tvMap.Nodes[1].Nodes[i].NodeFont = rFont;
		}
		for (int i = 0; i < 6; i++)
		{
			tvMap.Nodes[2].Nodes[i].NodeFont = rFont;
		}
		for (int i = 0; i < 11; i++)
		{
			tvSensor.Nodes[i].NodeFont = tbFont;
		}
		for (int i = 0; i < 13; i++)
		{
			tvTests.Nodes[i].NodeFont = tFont;
		}
		((Control)adjustUD).Font = rFont;
		((Control)editUpDown).Font = rFont;
		((Control)valueUD).Font = rFont;
	}

	private void ISOMain_Resize(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		if (!enWide)
		{
			return;
		}
		int width = ((Control)this).Width;
		int num = ((Control)this).Height + offWide;
		if (swMode == 0)
		{
			unselectLabel(0);
			SaveGridTable();
			wState = (int)((Form)this).WindowState == 2;
		}
		((Control)Logo_Panel).Left = width / 2;
		((ToolStripItem)loopStatus).Width = ((width >= 1280) ? 50 : 34);
		((ToolStripItem)fileStatus).Width = ((Control)statusStrip).Width - ((ToolStripItem)loopStatus).Width - 198;
		int num2 = ((width >= 1280) ? 188 : 172);
		int num3 = ((num >= 720) ? 86 : 70);
		((Control)_vehInfos).Width = num2;
		((Control)_mapInfos).SetBounds(7, num3 + 44, num2, 15);
		((Control)_lbMap).SetBounds(num2 + 16, 26, width - num2 - 32, 15);
		((Control)gbVehicule).SetBounds(6, 38, num2 + 1, num3);
		((Control)gbMap).SetBounds(6, num3 + 56, num2 + 1, num - num3 - 116);
		((Control)tvVehicule).SetBounds(2, 7, num2 - 3, num3 - 9);
		((Control)tvMap).SetBounds(2, 7, num2 - 3, num - num3 - 125);
		((Control)gbTable).SetBounds(num2 + 15, 38, width - num2 - 31, num - 97);
		((Control)panelTable).SetBounds(1, 7, width - num2 - 30, num - 104);
		if (wState & (aNode == null))
		{
			aNode = new TreeNode("", -2, -2);
			aNode.Tag = -1;
			tvMap.Nodes[0].Nodes.Add(aNode);
		}
		else if (aNode != null)
		{
			aNode.Remove();
			aNode = null;
		}
		if (((Control)tvMap).Enabled & (swMode == 0))
		{
			if (wState)
			{
				tvMap.Nodes[exNode ^ 3].Expand();
			}
			else
			{
				tvMap.Nodes[exNode ^ 3].Collapse();
			}
		}
		UDTop = tvMap.Nodes[1].Bounds.Top + 23;
		((Control)vUDpanel).Left = num2 - 46;
		MapSelected(tagMap);
		AfterOpenMap();
	}

	private int getOSInfo()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		Version version = oSVersion.Version;
		int result = 0;
		if (oSVersion.Platform == PlatformID.Win32NT)
		{
			switch (version.Major)
			{
			case 3:
				result = 1;
				break;
			case 4:
				result = 2;
				break;
			case 5:
				result = ((version.Minor != 0) ? 5 : 4);
				break;
			case 6:
				result = ((version.Minor != 0) ? 12 : 8);
				break;
			}
		}
		return result;
	}

	private void UpdateUI()
	{
		((ToolStripItem)fileMenuItem).Text = LangUI[mLang, 0];
		((ToolStripItem)openMenuItem).Text = LangUI[mLang, 1];
		((ToolStripItem)saveMenuItem).Text = LangUI[mLang, 2];
		((ToolStripItem)quitMenuItem).Text = LangUI[mLang, 3];
		((ToolStripItem)PCIIIMenuItem).Text = LangUI[mLang, 4];
		((ToolStripItem)compareMenuItem).Text = LangUI[mLang, 5];
		((ToolStripItem)editMenuItem).Text = LangUI[mLang, 6];
		((ToolStripItem)copyMenuItem).Text = LangUI[mLang, 7];
		((ToolStripItem)pasteMenuItem).Text = LangUI[mLang, 8];
		((ToolStripItem)fusionMenuItem).Text = LangUI[mLang, 9];
		((ToolStripItem)useTrimMenuItem).Text = LangUI[mLang, 10];
		((ToolStripItem)TrimToLMenuItem).Text = LangUI[mLang, 199];
		((ToolStripItem)exportMenuItem).Text = LangUI[mLang, 11];
		((ToolStripItem)logMenuItem).Text = LangUI[mLang, 12];
		((ToolStripItem)displayMenuItem).Text = LangUI[mLang, 13];
		((ToolStripItem)graphMenuItem).Text = LangUI[mLang, 14];
		((ToolStripItem)infosMapMenuItem).Text = LangUI[mLang, 15];
		((ToolStripItem)fullScreenMenuItem).Text = LangUI[mLang, 16];
		((ToolStripItem)ECUMenuItem).Text = LangUI[mLang, 17];
		((ToolStripItem)connectMenuItem).Text = (mConnect ? LangUI[mLang, 25] : LangUI[mLang, 18]);
		((ToolStripItem)historyMenuItem).Text = LangUI[mLang, 19];
		((ToolStripItem)readMapMenuItem).Text = LangUI[mLang, 20];
		((ToolStripItem)flashMenuItem).Text = LangUI[mLang, 21];
		((ToolStripItem)safeMenuItem).Text = LangUI[mLang, 22];
		((ToolStripItem)eraseCodesMenuItem).Text = LangUI[mLang, 24];
		((ToolStripItem)optionsMenuItem).Text = LangUI[mLang, 26];
		((ToolStripItem)languageMenuItem).Text = LangUI[mLang, 27];
		((ToolStripItem)englishMenuItem).Text = LangUI[mLang, 28];
		((ToolStripItem)frenchMenuItem).Text = LangUI[mLang, 29];
		((ToolStripItem)germanMenuItem).Text = LangUI[mLang, 30];
		((ToolStripItem)italianMenuItem).Text = LangUI[mLang, 31];
		((ToolStripItem)spanishMenuItem).Text = LangUI[mLang, 32];
		((ToolStripItem)portugueseMenuItem).Text = LangUI[mLang, 33];
		((ToolStripItem)autoMenuItem).Text = LangUI[mLang, 315];
		((ToolStripItem)DevMenuItem).Text = LangUI[mLang, 330];
		((ToolStripItem)aboutMenuItem).Text = LangUI[mLang, 331];
		((ToolStripItem)modifSubMenu).Text = LangUI[mLang, 35];
		((ToolStripItem)copySubMenu).Text = LangUI[mLang, 37];
		((ToolStripItem)pasteSubMenu).Text = LangUI[mLang, 38];
		((ToolStripItem)activeSubMenu).Text = LangUI[mLang, 41];
		((ToolStripItem)resetSubMenu).Text = LangUI[mLang, 43];
		((ToolStripItem)serialMenuItem).Text = LangUI[mLang, 119];
		((Control)menuStrip).Refresh();
		((Control)BtnLeft).Invalidate();
		((Control)BtnMid).Invalidate();
		((Control)BtnRight).Invalidate();
		((Control)_mapInfos).Text = LangUI[mLang, 67];
		if (ISORead.dataSensor[63] == null)
		{
			((Control)_vehInfos).Text = LangUI[mLang, 71];
		}
		((Control)_lbSensors).Text = LangUI[mLang, 101];
		((Control)_lbTests).Text = LangUI[mLang, 100];
		((Control)_lbCodes).Text = LangUI[mLang, 93];
		((Control)_lbDesc).Text = LangUI[mLang, 240];
		((Control)_lbDash).Text = LangUI[mLang, 92];
		if ((int)((Control)_lbMap).Tag > 0)
		{
			((Control)_lbMap).Text = LangUI[mLang, (int)((Control)_lbMap).Tag];
		}
		((ToolStripItem)tpsStatus).Text = LangUI[mLang, 116];
		((ToolStripItem)battStatus).ToolTipText = LangUI[mLang, 115];
		if (((ToolStripItem)loopStatus).Enabled)
		{
			((ToolStripItem)loopStatus).ToolTipText = LangUI[mLang, (int)((ToolStripItem)loopStatus).Tag];
		}
		if (((ToolStripItem)tpsStatus).Enabled)
		{
			((ToolStripItem)tpsStatus).ToolTipText = LangUI[mLang, (int)((ToolStripItem)tpsStatus).Tag];
		}
		if ((mLed > 0) & (mLed < 3))
		{
			((ToolStripItem)ledStatus).ToolTipText = LangUI[mLang, mLed + 311];
		}
		if (swMode > 0)
		{
			if (refreshCode == 0)
			{
				refreshCode--;
			}
			((Control)listCodes).Invalidate();
			((ToolStripItem)fileStatus).Text = "";
		}
		UpdateNodes();
		if (noMap)
		{
			((Control)panelTable).Invalidate();
		}
		else
		{
			DisplayMsg(idMap, 128);
		}
		setUISensors();
		if (showInfo)
		{
			infoForm.Infos_Load(null, null);
		}
		if (showLog)
		{
			logForm.Logs_Load(null, null);
		}
		englishMenuItem.Checked = mLang == 0;
		frenchMenuItem.Checked = mLang == 1;
		germanMenuItem.Checked = mLang == 2;
		italianMenuItem.Checked = mLang == 3;
		spanishMenuItem.Checked = mLang == 4;
		portugueseMenuItem.Checked = mLang == 5;
		if (TypTable >= 0)
		{
			MapSelected(tagMap);
		}
	}

	private void UpdateNodes()
	{
		string text = "";
		tvMap.Nodes[0].Nodes[13].Text = "";
		tvMap.Nodes[0].Nodes[14].Text = "";
		tvMap.Nodes[0].Nodes[15].Text = "";
		if ((TypTable < 8) | (TypTable == 14))
		{
			tvMap.Nodes[0].Nodes[7].Name = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[7].Text = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[10].Name = LangUI[mLang, 48];
			tvMap.Nodes[0].Nodes[10].Text = LangUI[mLang, 48];
		}
		else if (TypTable < 16)
		{
			tvMap.Nodes[0].Nodes[5].Name = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[5].Text = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[7].Name = LangUI[mLang, 48];
			tvMap.Nodes[0].Nodes[7].Text = LangUI[mLang, 48];
		}
		else if (TypTable < 72)
		{
			if ((TypTable & 0xF8) == 56)
			{
				tvMap.Nodes[0].Nodes[8].Name = LangUI[mLang, 46] + " Dry";
				tvMap.Nodes[0].Nodes[8].Text = LangUI[mLang, 46] + " Dry";
				tvMap.Nodes[0].Nodes[13].Name = LangUI[mLang, 46] + " Wet";
				tvMap.Nodes[0].Nodes[13].Text = LangUI[mLang, 46] + " Wet";
				tvMap.Nodes[0].Nodes[14].Name = LangUI[mLang, 47];
				tvMap.Nodes[0].Nodes[14].Text = LangUI[mLang, 47];
			}
			else
			{
				if (TypTable < 64)
				{
					tvMap.Nodes[0].Nodes[14].Name = LangUI[mLang, ((TypTable >= 40) & (TypTable != 48)) ? 49 : 51];
					tvMap.Nodes[0].Nodes[14].Text = LangUI[mLang, ((TypTable >= 40) & (TypTable != 48)) ? 49 : 51];
				}
				else if (TypTable != 48)
				{
					tvMap.Nodes[0].Nodes[14].Name = LangUI[mLang, 50];
					tvMap.Nodes[0].Nodes[14].Text = LangUI[mLang, 50];
				}
				tvMap.Nodes[0].Nodes[15].Name = (((TypTable >= 40) & (TypTable != 48)) ? LangUI[mLang, 51] : "");
				tvMap.Nodes[0].Nodes[15].Text = (((TypTable >= 40) & (TypTable != 48)) ? LangUI[mLang, 51] : "");
				if ((Tune.nStyle != "") & (Tune.nStyle != null))
				{
					tvMap.Nodes[0].Nodes[11].Name = LangUI[mLang, 46];
					tvMap.Nodes[0].Nodes[11].Text = LangUI[mLang, 46];
				}
				for (int i = 1; i < 3; i++)
				{
					tvMap.Nodes[0].Nodes[i + 11].Name = LangUI[mLang, i + 46];
					tvMap.Nodes[0].Nodes[i + 11].Text = LangUI[mLang, i + 46];
				}
			}
		}
		else if (TypTable < 80)
		{
			for (int i = 1; i < 3; i++)
			{
				tvMap.Nodes[0].Nodes[i + 8].Name = LangUI[mLang, i + 45];
				tvMap.Nodes[0].Nodes[i + 8].Text = LangUI[mLang, i + 45];
			}
			if (TypTable < 78)
			{
				tvMap.Nodes[0].Nodes[11].Name = LangUI[mLang, 51];
				tvMap.Nodes[0].Nodes[11].Text = LangUI[mLang, 51];
			}
			else
			{
				tvMap.Nodes[0].Nodes[11].Name = LangUI[mLang, 48];
				tvMap.Nodes[0].Nodes[11].Text = LangUI[mLang, 48];
				tvMap.Nodes[0].Nodes[12].Name = LangUI[mLang, 51];
				tvMap.Nodes[0].Nodes[12].Text = LangUI[mLang, 51];
			}
		}
		else if (TypTable < 100)
		{
			tvMap.Nodes[0].Nodes[9].Name = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[10].Name = LangUI[mLang, 48];
			tvMap.Nodes[0].Nodes[11].Name = LangUI[mLang, 50];
			tvMap.Nodes[0].Nodes[12].Name = LangUI[mLang, 51];
			tvMap.Nodes[0].Nodes[9].Text = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[10].Text = LangUI[mLang, 48];
			tvMap.Nodes[0].Nodes[11].Text = LangUI[mLang, 50];
			tvMap.Nodes[0].Nodes[12].Text = LangUI[mLang, 51];
		}
		else if (TypTable < 1024)
		{
			int i = ((TypTable == 112) ? 5 : 11);
			tvMap.Nodes[0].Nodes[i].Name = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[i].Text = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[i + 1].Name = LangUI[mLang, 51];
			tvMap.Nodes[0].Nodes[i + 1].Text = LangUI[mLang, 51];
		}
		else if ((TypTable & 0xFFE0) == 2048)
		{
			tvMap.Nodes[0].Nodes[5].Name = LangUI[mLang, 46];
			tvMap.Nodes[0].Nodes[5].Text = LangUI[mLang, 46];
		}
		updateTrim();
		tvMap.Nodes[0].Name = LangUI[mLang, 91];
		if ((TypTable & 0xFFF0) != 1024)
		{
			tvMap.Nodes[0].Text = tvMap.Nodes[0].Name + "- " + tvMap.Nodes[0].Nodes[iTag].Text;
		}
		else
		{
			tvMap.Nodes[0].Text = LangUI[mLang, 73];
		}
		if ((TypTable & 0xFFE0) == 2048)
		{
			text = (altMap ? " (Map 1)" : " (Map 0)");
		}
		tvMap.Nodes[1].Name = LangUI[mLang, 72];
		tvMap.Nodes[1].Text = (((int)tvMap.Nodes[1].Tag == 8) ? LangUI[mLang, 72] : "") + text;
		tvMap.Nodes[2].Name = LangUI[mLang, 138];
		tvMap.Nodes[2].Text = (((int)tvMap.Nodes[2].Tag == 8) ? LangUI[mLang, 138] : "");
		for (int i = 0; i < 6; i++)
		{
			int num = (Tune.prmLabel >> i * 4) & 0xF;
			tvMap.Nodes[1].Nodes[i].Text = ((num > 0) ? LangUI[mLang, num + 51] : "");
			tvMap.Nodes[1].Nodes[i].ImageIndex = ((num == 0) ? (-2) : 5);
		}
		for (int i = 0; i < 6; i++)
		{
			int num = (Tune.devLabel >> i * 4) & 0xF;
			tvMap.Nodes[2].Nodes[i].Text = ((num > 0) ? LangUI[mLang, num + 138] : "");
			if (num == 0)
			{
				tvMap.Nodes[2].Nodes[i].ImageIndex = -2;
			}
		}
		for (int i = 0; i < 3; i++)
		{
			tvVehicule.Nodes[0].Nodes[i].Name = LangUI[mLang, i + 66];
		}
		tvVehicule.Nodes[0].Nodes[0].Text = LangUI[mLang, 66];
		tvVehicule.Nodes[0].Nodes[1].Text = LangUI[mLang, 67];
		tvVehicule.Nodes[0].Nodes[2].Text = LangUI[mLang, _KTM ? 70 : 68];
		tvSensor.Nodes[10].Text = LangUI[mLang, 114];
	}

	public static void updateTrim()
	{
		int result = 0;
		string value = "";
		string text = me.tvMap.Nodes[0].Nodes[0].Text;
		if ((TypTable & 0xFFE0) == 2048)
		{
			value = ((xTrim == 4) ? "1" : ((!oneTrim) ? "0" : ""));
		}
		else if (text == "F1")
		{
			value = ((xTrim == 4) ? "2" : ((xTrim == 2) ? "3" : ((xTrim == 6) ? "4" : ((!oneTrim) ? "1" : ""))));
		}
		else if (text.Substring(0, Math.Min(text.Length, 2)) == "F3")
		{
			value = ((xTrim == 4) ? "2" : ((xTrim == 2) ? "1" : ((xTrim == 6) ? "4" : ((!oneTrim) ? "3" : ""))));
		}
		string text2 = LangUI[mLang, 45];
		if ((Tune.nStyle != "") & (Tune.nStyle != null))
		{
			int.TryParse(Tune.nStyle.Substring(1, 2), out result);
			int num = text2.IndexOf("F");
			if (num != -1)
			{
				text2 = text2.Insert(num + 1, value);
			}
			if (result > 0)
			{
				me.tvMap.Nodes[0].Nodes[result].Name = text2;
				me.tvMap.Nodes[0].Nodes[result].Text = text2;
			}
			me.tvMap.Nodes[0].Text = me.tvMap.Nodes[0].Name + "- " + text2;
		}
	}

	private void setUISensors()
	{
		int num = 0;
		int num2 = (_Walbro ? 30 : (_KTM ? 20 : ((!sagemECU) ? 10 : 0)));
		int num3 = (_Walbro ? 90 : (_LC4 ? 75 : (_KTM ? 60 : (_Four ? 45 : (_Twin ? 30 : ((!sagemECU) ? 15 : 0))))));
		int num4 = (_Walbro ? 4194378 : (_LC4 ? 293863744 : (_KTM ? 295962197 : (_Twin ? 41985109 : (_Four ? 42279295 : (sagemECU ? (8716362 + (_sagemF ? 5 : (_Apri ? 3 : 0))) : 43327850))))));
		long num5 = (uint)(_Walbro ? (-6785452) : (_LC4 ? 556832612 : (_KTM ? 557619044 : (_Twin ? (-895977900) : (_2ndT ? (-895977900) : (-1164413356))))));
		int num6 = (_Walbro ? 15188 : (_LC4 ? 12825 : (_KTM ? 12824 : (sagemECU ? 30292 : 12816))));
		int num7 = (_Walbro ? 1914 : (sagemECU ? 30586 : 2730));
		string text = (_LC4 ? "131748273346434038312210243652" : (_KTM ? "131748273346434038312110243652" : (sagemECU ? "131748273446434038312110243652" : "131748273446434038315410243652")));
		tipSensors[19] = (_2ndT ? 168 : 147);
		tipSensors[25] = (_Flap ? 155 : 147);
		tvVehicule.Nodes[0].Nodes[2].Text = LangUI[mLang, (_KTM | _Walbro) ? 70 : 68];
		DisplayMsg("", 96);
		if (sagemECU)
		{
			tipSensors[0] = (_sagemF ? 179 : (_Apri ? 167 : 148));
			tipSensors[1] = ((_Apri | _sagemF) ? 178 : 160);
		}
		for (int i = 0; i < dataRefresh.Length; i++)
		{
			dataRefresh[i] = 255;
		}
		for (int i = 0; i < 10; i++)
		{
			tvSensor.Nodes[i].Text = LangUI[mLang, lbSensors[num2 + i]];
			for (int j = 0; j < tvSensor.Nodes[i].GetNodeCount(true); j++)
			{
				string text2 = text.Substring(num * 2, 2);
				tvSensor.Nodes[i].Nodes[j].Name = text2;
				int.TryParse(text2, out var result);
				int num8 = num4 & 3;
				for (int k = 0; k < num8 + 1; k++)
				{
					dataRefresh[result + k] = (short)(i * 16 + j);
				}
				tvSensor.Nodes[i].Nodes[j].Tag = num8 + 64;
				num4 >>= 2;
				text2 = LangUI[mLang, tipSensors[num++ + num3]];
				if (text2.StartsWith("()"))
				{
					text2 = text2.Insert(1, j.ToString());
				}
				tvSensor.Nodes[i].Nodes[j].ToolTipText = text2;
			}
		}
		for (int i = 0; i < 4; i++)
		{
			int num9 = ((i == 3) ? (((_KTM & !_LC4) | _Twin) ? 2 : ((!_Flap) ? 4 : 0)) : 0);
			tvSensor.Nodes[10].Nodes[i].Name = LangUI[mLang, i * 2 + num9 + 102];
			tvSensor.Nodes[10].Nodes[i].Text = LangUI[mLang, i * 2 + 103];
		}
		for (int i = 0; i < 8; i++)
		{
			int j = (int)(num5 >> i * 4) & 0xF;
			tvTests.Nodes[i].Text = ((j == 15) ? "" : LangUI[mLang, j + 249]);
			tvTests.Nodes[i].ImageIndex = ((j == 15) ? (-2) : 8);
		}
		for (int i = 0; i < 4; i++)
		{
			int j = (num6 >> i * 4) & 0xF;
			tvTests.Nodes[i + 9].Text = LangUI[mLang, j + 262];
			j = (num7 >> i * 4) & 0xF;
			tvTests.Nodes[i + 9].ImageIndex = j - 2;
			ISORead.dataSensor[i] = "0";
		}
		((ToolStripItem)razTPSMenuItem).Text = LangUI[mLang, sagemECU ? 23 : 303];
		if (num2 <= 10)
		{
			setDiagInterface();
		}
		_Label_Invalidate();
	}

	public static void setDiagInterface()
	{
		ushort[] array;
		int num;
		int num2;
		if (sagemECU)
		{
			num = (_Apri ? 79 : 1031);
			num2 = (_Apri ? 1031 : 79);
			array = ISORead.sagemT_Sensor;
		}
		else
		{
			num = (_2ndT ? 368 : 35);
			num2 = (_2ndT ? 35 : 368);
			array = ISORead.keihinT_Sensor;
		}
		for (int i = 0; i < array.Length / 2; i++)
		{
			if (array[i * 2] == num2)
			{
				array[i * 2] = (ushort)num;
			}
		}
		if (sagemECU)
		{
			return;
		}
		num = (_2ndT ? 24 : 34);
		num2 = (_2ndT ? 34 : 24);
		for (int i = 0; i < array.Length / 2; i++)
		{
			if (array[i * 2] == num2)
			{
				array[i * 2] = (ushort)num;
			}
		}
	}

	public void USBListen()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		WqlEventQuery val = new WqlEventQuery("__InstanceOperationEvent");
		val.WithinInterval = new TimeSpan(0, 0, 3);
		val.Condition = "TargetInstance ISA 'Win32_USBControllerDevice' ";
		watcher = new ManagementEventWatcher((EventQuery)(object)val);
		watcher.EventArrived += new EventArrivedEventHandler(UsbEventArrived);
		try
		{
			watcher.Start();
		}
		catch
		{
		}
	}

	private void UsbEventArrived(object sender, EventArrivedEventArgs e)
	{
		USBWait = 10;
	}

	private void portList_SelectedIndexChanged(object sender, EventArgs e)
	{
		((ToolStripItem)connectMenuItem).Enabled = (((ListControl)lbDevList).SelectedIndex >= 0) | (((ListControl)cmbPortName).SelectedIndex >= 0);
	}

	public void SetDefTable()
	{
		IMap.idFile = "";
		SetLabelMap(83, 0, 20, IMap.defThrottle, null);
		SetLabelMap(-1, 1, 32, IMap.defRev, IMap.defRev);
		lhLabel = LangUI[mLang, 96];
		DisplayMsg("", 64);
		DisplayMsg("", 96);
		((Control)_mapInfos).Text = LangUI[mLang, 67];
		tvMap.CollapseAll();
		((Control)tvMap).Refresh();
		((Control)panelTable).Refresh();
		if (showInfo)
		{
			((Form)infoForm).Close();
		}
	}

	public static void SetLabelMap(int title, int dir, int count, short[] array, short[] cArray)
	{
		double num = ((!noMap & (ptrMap[iTable[iTag]] == 5)) ? 0.32 : 1.0);
		int num2 = mColor.Length;
		int num3 = array.Length;
		int width = ((Control)me.panelTable).Width;
		Color[] array2 = new Color[count];
		if (title != -1)
		{
			((Control)me._lbMap).Text = LangUI[mLang, title];
			((Control)me._lbMap).Tag = title;
		}
		double num4 = array[count - 1] - array[0];
		if (num4 != 0.0)
		{
			for (int i = 0; i < count; i++)
			{
				short num5 = (short)(array[i] - array[0]);
				double num6 = (double)num5 / num4 * (double)num2 * num;
				if (num6 > (double)(num2 - 1))
				{
					num6 = num2 - 1;
				}
				Color color = mColor[(int)num6];
				array2[i] = color;
			}
		}
		switch (dir)
		{
		case 0:
		case 2:
			dcLabel = title == 83;
			LH_Array = new short[num3];
			Array.Copy(array, LH_Array, num3);
			LH_Color = new Color[array2.Length];
			Array.Copy(array2, LH_Color, array2.Length);
			gCol = count++;
			num4 = ((double)width / (double)count - (double)(width / count)) * (double)count;
			gOff = (int)num4;
			lbW = width / count;
			if (dir == 2)
			{
				gRow = 1;
				lbS = 29;
				lbH = lbS;
			}
			break;
		case 1:
		{
			LV_Array = new short[num3 * 2];
			Array.Copy(array, LV_Array, num3);
			Array.Copy(cArray, 0, LV_Array, num3, num3);
			LV_Color = new Color[array2.Length];
			Array.Copy(array2, LV_Color, array2.Length);
			gRow = count;
			int height = ((Control)me.panelTable).Height;
			int num7 = (int)Math.Round((double)height / (double)(count + 1));
			if (height - num7 * count < 15)
			{
				num7--;
			}
			lbH = num7;
			lbS = height - lbH * count;
			break;
		}
		}
	}

	public static void SetGridMap(string format, double[] array)
	{
		gFormat = format;
		gridArray = array;
		eTable = null;
		if ((ptrMap[iTable[iTag]] & 0x70) != 32)
		{
			xColor = mColor;
		}
		else
		{
			xColor = qColor;
		}
		((Control)me.panelTable).Invalidate();
	}

	public void InvalidateGrid(int axis)
	{
		if (!showGraph)
		{
			Rectangle rectangle = ((axis != 0) ? new Rectangle(0, 0, lbW + gOff, ((Control)panelTable).Height) : new Rectangle(0, 0, ((Control)panelTable).Width, lbS));
			((Control)panelTable).Invalidate(rectangle);
		}
	}

	private void panelGrid_Paint(object sender, PaintEventArgs e)
	{
		IDraw.panelGridPaint(e);
	}

	private void _Label_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintLabel(sender, e, 0);
	}

	private void _Label_Invalidate()
	{
		((Control)Logo_Panel).Invalidate();
		if (swMode == 0)
		{
			((Control)_vehInfos).Invalidate();
			((Control)_mapInfos).Invalidate();
			((Control)_lbMap).Invalidate();
		}
		else
		{
			((Control)_lbSensors).Invalidate();
			((Control)_lbTests).Invalidate();
			((Control)_lbDash).Invalidate();
			((Control)_lbCodes).Invalidate();
			((Control)_lbDesc).Invalidate();
		}
	}

	private void fileStatus_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintfileStatus(sender, e);
	}

	private void Logo_Panel_Paint(object sender, PaintEventArgs e)
	{
		Rectangle part = new Rectangle(0, 0, ((Control)Logo_Panel).Width, ((Control)Logo_Panel).Height);
		IDraw.PaintLogo(part, e);
	}

	private void pbDash_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintMeter(e);
	}

	private void EDpanel_Paint(object sender, PaintEventArgs e)
	{
		IDraw.EDPanelPaint(e);
	}

	public void pbDash_Update(int src, int val)
	{
		int num = IDraw.dGauge[src * 10 + 6];
		int num2 = IDraw.dGauge[src * 10 + 7];
		int num3 = IDraw.dGauge[src * 10 + 8];
		int num4 = IDraw.dGauge[src * 10 + 9];
		if (val < num3)
		{
			val = num3;
		}
		if (val > num4)
		{
			val = num4;
		}
		double num5 = (val - num3) * (num2 - num) / (num4 - num3);
		IDraw.Angle_Meter[src] = (int)num5 + num;
		Rectangle rectangle = IDraw.dashRegion[src];
		((Control)pbDash).Invalidate(rectangle);
		if ((src == 0) & (swMode == 0))
		{
			mRun = (byte)((val != 0) ? 1u : 0u);
			if (sRun != mRun)
			{
				flashItemEnabled();
			}
		}
	}

	public static TreeNode mTvMap(int index)
	{
		return me.tvMap.Nodes[index];
	}

	public void tvSensor_Update(int index)
	{
		int i = 1;
		bool flag = false;
		string[] dataSensor = ISORead.dataSensor;
		int num;
		if (index > dataRefresh.Length - 1)
		{
			num = index;
		}
		else
		{
			for (num = dataRefresh[index]; (dataRefresh[index + i] == (short)num) & (i < 12); i++)
			{
			}
		}
		if (index < 90)
		{
			for (int j = 0; j < i; j++)
			{
				if (dataSensor[index + j] != dataSensor[index + j + 100])
				{
					dataSensor[index + j + 100] = dataSensor[index + j];
					flag = true;
				}
			}
			if ((num == 255) | !flag)
			{
				return;
			}
		}
		int num2 = num >> 4;
		tvSensor.Nodes[num2].Nodes[num & 0xF].SelectedImageIndex = 0;
	}

	public void tvTest_Update(int node, bool refresh)
	{
		int num = node >> 4;
		string[] dataSensor = ISORead.dataSensor;
		if ((dataSensor[num + 64] != dataSensor[num + 164]) | refresh)
		{
			dataSensor[num + 164] = dataSensor[num + 64];
			tvTests.Nodes[num].SelectedImageIndex = 0;
		}
	}

	private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
	{
		if (e.Node.IsVisible & cReadTimer.Enabled)
		{
			IDraw.TreeViewDrawNode(sender, e);
		}
	}

	private void panelTable_MouseClick(object sender, MouseEventArgs e)
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Invalid comparison between Unknown and I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Invalid comparison between Unknown and I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Invalid comparison between Unknown and I4
		if ((iStart > 0) | (e == null) | noMap)
		{
			return;
		}
		int num = (e.X - gOff) / lbW;
		int num2 = (((e.Y > lbS) | (num > 0)) ? ((e.Y - lbS) / lbH) : (-1));
		int width = ((Control)panelTable).Width;
		int height = ((Control)panelTable).Height;
		int num3 = width / gRow;
		int num4 = ((lbH < 20) ? lbH : 20);
		int num5 = width - gRow * num3;
		int num6 = (e.X - num5) / num3;
		if (!showGraph & ((mDown == -1) | (mDown != num * 100 + num2)))
		{
			return;
		}
		if (!showGraph & (gRow > 1) & ((int)e.Button == 1048576))
		{
			mCells = mDown;
			showCells = 10;
		}
		else if (showGraph)
		{
			if (((int)e.Button == 2097152) & (mDown != -1) & !showMod)
			{
				if (mDown < 100)
				{
					if ((lDown > 99) | (mDown != num2))
					{
						return;
					}
					eCurv = Math.Min(mDown % 100, gRow - 1);
				}
				else
				{
					if ((mDown != num * 100) | (gRow <= 1) | (editCurve & (lDown < 100)))
					{
						return;
					}
					eCurv = mDown;
				}
				if (editCurve)
				{
					eSaveCurve();
				}
				else
				{
					lDown = -1;
				}
				editCurve = !editCurve | (lDown != mDown);
				if (editCurve)
				{
					egSave = true;
					egInc = defineInc();
					egMin = Tune.eRange[tagMap * 2];
					egMax = Tune.eRange[tagMap * 2 + 1];
					lDown = mDown;
					sCurv = eCurv;
					gTable = null;
					((ToolStripItem)graphMenuItem).Enabled = false;
					((Control)panelTable).Focus();
				}
				else
				{
					editGraphOut();
				}
			}
			else if (editCurve & ((int)e.Button == 1048576))
			{
				byte[] array = null;
				int num7 = -1;
				if ((lDown < 100) & (mDown != -1) & (e.X - gOff > lbW) & (num == (xDown - gOff) / lbW))
				{
					num7 = num - 1;
					_ = gCol;
					array = egCol;
				}
				else if ((e.Y > height - num4) & (num6 == (xDown - num5) / num3))
				{
					num7 = num6;
					_ = gRow;
					array = egRow;
				}
				if ((array != null) & (((e.X - gOff > lbW) & (lDown < 100) & (yCurve < lbS)) | ((lDown > 99) & (yCurve > height - num4))))
				{
					edState = false;
					if (!edShift)
					{
						egClick = num7;
					}
					int num8 = array[num7] ^ 1;
					array[num7] = (byte)num8;
					gTable[2, num7] = num8;
					if (edShift & (egClick != -1))
					{
						int num9 = Math.Min(num7, egClick);
						int num10 = Math.Max(num7, egClick);
						for (int i = num9; i < num10; i++)
						{
							array[i] = (byte)num8;
							gTable[2, i] = num8;
						}
					}
					for (int i = 0; i < array.Length; i++)
					{
						if (gTable[2, i] > 0.0)
						{
							edState = true;
						}
					}
				}
			}
		}
		((Control)panelTable).Invalidate();
	}

	private void panelTable_MouseDown(object sender, MouseEventArgs e)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Invalid comparison between Unknown and I4
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Invalid comparison between Unknown and I4
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Invalid comparison between Unknown and I4
		if ((TypTable < 0) | (e == null))
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = (e.X - gOff) / lbW;
		int num6 = (e.Y - lbS) / lbH;
		int num7 = num5 * 100 + num6;
		mDown = ((((e.Y > lbS) & (num5 == 0)) | ((e.Y <= lbS) & (num5 > 0))) ? num7 : (-1));
		if (editCurve)
		{
			xDown = e.X;
			if ((int)e.Button == 1048576)
			{
				yCurve = e.Y;
			}
			return;
		}
		bool flag = mDown != -1;
		bool flag2 = false;
		if ((e.Y < lbH * gRow + lbS) & !mStart)
		{
			if (lbSelect)
			{
				num = ((firstSelect / 100 < lastSelect / 100) ? (firstSelect / 100) : (lastSelect / 100));
				num3 = ((firstSelect / 100 < lastSelect / 100) ? (lastSelect / 100) : (firstSelect / 100));
				num2 = ((firstSelect % 100 < lastSelect % 100) ? (firstSelect % 100) : (lastSelect % 100));
				num4 = ((firstSelect % 100 < lastSelect % 100) ? (lastSelect % 100) : (firstSelect % 100));
				flag2 = (num5 >= num) & (num5 <= num3) & (num6 >= num2) & (num6 <= num4);
			}
			if ((int)e.Button == 1048576)
			{
				editSelect = !showGraph & !flag & (num5 > 0);
				graphSelect = showGraph & flag & ((num5 == 0) | rowTPS) & !showView;
				if (editSelect | graphSelect)
				{
					mCells = -1;
					showCells = 0;
					if (((int)Control.ModifierKeys == 65536) & oneSelect)
					{
						if (firstSelect != lastSelect)
						{
							lastSelect = firstSelect;
							oneSelect = true;
						}
						else
						{
							oneSelect = false;
						}
						((Control)editUpDown).Visible = oneSelect;
					}
					else if (lbSelect)
					{
						if (flag2)
						{
							return;
						}
						lbSelect = false;
						oneSelect = true;
					}
					if (oneSelect | !lbSelect)
					{
						firstSelect = num7;
						lastSelect = firstSelect;
					}
					else
					{
						lastSelect = num7;
					}
				}
				else
				{
					unselectLabel(0);
				}
				lbSelect = true;
				((Control)EDpanel).Hide();
				((Control)editUpDown).Visible = false;
				((Control)panelTable).Invalidate();
				if (graphSelect & compareF)
				{
					DisplayMsg(cutString(lastFile + "  && …" + Path.GetFileName(cmpFile), ((ToolStripItem)fileStatus).Width - 8), 64);
				}
			}
			else if (!flag2)
			{
				unselectLabel(1);
			}
		}
		else
		{
			unselectLabel(1);
		}
	}

	private void panelTable_MouseUp(object sender, MouseEventArgs e)
	{
		if ((TypTable < 0) | (e == null))
		{
			return;
		}
		_ = (e.X - gOff) / lbW;
		_ = (e.Y - lbS) / lbH;
		if (editCurve)
		{
			yCurve = e.Y;
		}
		else if (graphSelect)
		{
			if (graphSelect & compareF)
			{
				DisplayMsg(cutString(lastFile, ((ToolStripItem)fileStatus).Width - 8), 64);
			}
			unselectLabel(1);
		}
		else if (!showGraph & !((Control)aboutForm).Visible & !((Control)editUpDown).Visible)
		{
			SetvalueUD();
			int num = (pcEdit ? 17 : 0);
			Point location = new Point((eLast / 100 + 1) * lbW + ((Control)gbTable).Left + gOff - 3, (eLast % 100 + 1) * lbH + lbS + ((Control)gbTable).Top - 15 + num + 3);
			Point location2 = new Point(location.X - 41, location.Y + 2);
			oneSelect = true;
			if (pcEdit)
			{
				((Control)EDpanel).Location = location2;
				pcShow = lbSelect;
			}
			((Control)panelTable).ContextMenuStrip = cCopyMenu;
			if (!showMod)
			{
				((Control)editUpDown).Location = location;
				((Control)EDpanel).Location = location2;
				((Control)editUpDown).Visible = lbSelect;
				((Control)editUpDown).Focus();
			}
		}
	}

	private void panelTable_MouseMove(object sender, MouseEventArgs e)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Invalid comparison between Unknown and I4
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
		if ((TypTable < 0) | (e == null))
		{
			return;
		}
		if (editCurve)
		{
			int height = ((Control)me.panelTable).Height;
			int num = ((lDown > 99) ? ((lbH < 20) ? lbH : 20) : 0);
			int num2 = ((lDown <= 99) ? lbW : 0);
			if ((e.X > num2 + gOff) & (e.Y > lbS) & (e.Y < height - num) & edState)
			{
				if ((int)e.Button != 1048576)
				{
					((Control)this).Cursor = grabCursor;
				}
				else
				{
					int d = (yCurve - e.Y) / 2;
					yCurve = e.Y;
					editGraphValue(d);
					((Control)this).Cursor = grabbingCursor;
				}
				offGr = 1;
			}
			else
			{
				((Control)this).Cursor = Cursors.Default;
				offGr = 0;
			}
			Cursor.Show();
		}
		else if (editSelect & ((int)e.Button == 1048576) & ((e.X - gOff > lbW) & (e.X - gOff < ((Control)panelTable).Width - 1) & (e.Y > lbS) & (e.Y < lbH * gRow + lbS)))
		{
			int num3 = (e.X - gOff) / lbW;
			int d = (e.Y - lbS) / lbH;
			lastSelect = num3 * 100 + d;
			((Control)EDpanel).Hide();
			((Control)editUpDown).Visible = false;
			((Control)panelTable).Invalidate();
		}
		else if (graphSelect & ((int)e.Button == 1048576) & (((e.X > 0) & (e.X - gOff < lbW - 1) & (e.Y > lbS) & (e.Y < lbH * gRow + lbS)) | ((e.X - gOff > lbW - 1) & (e.X < (lbW + 1) * gCol + gOff) & (e.Y > 0) & (e.Y < lbS))))
		{
			int num3 = (e.X - gOff) / lbW;
			int d = (e.Y - lbS) / lbH;
			lastSelect = num3 * 100 + d;
			if (oneCurve)
			{
				firstSelect = lastSelect;
			}
			((Control)panelTable).Invalidate();
		}
	}

	private void panelTable_MouseWheel(object sender, MouseEventArgs e)
	{
		if (!((gTable == null) | (e == null)))
		{
			editGraphValue((e.Delta > 0) ? 1 : (-1));
		}
	}

	private void panelTable_MouseLeave(object sender, EventArgs e)
	{
		offGr = 0;
		((Control)this).Cursor = Cursors.Default;
		Cursor.Show();
	}

	private void editGraphValue(int d)
	{
		if (gTable == null)
		{
			return;
		}
		bool flag = true;
		int num = ((lDown > 99) ? gRow : gCol);
		double num2 = (double)((decimal)edGr * egInc * (decimal)offGr * (decimal)d);
		for (int i = 0; i < num; i++)
		{
			if (gTable[2, i] > 0.0)
			{
				double num3;
				if (!pcGraph)
				{
					num3 = gTable[0, i] + num2;
				}
				else
				{
					double num4 = gTable[0, i] / 100.0;
					num3 = Math.Round(gTable[0, i] + num4 * num2);
				}
				if (((int)(num3 * 100.0) > (int)(egMax * 100.0)) | (num3 < egMin))
				{
					flag = false;
				}
			}
		}
		if (flag)
		{
			for (int j = 0; j < num; j++)
			{
				if (!(gTable[2, j] > 0.0))
				{
					continue;
				}
				double num3;
				if (!pcGraph)
				{
					num3 = gTable[0, j] + num2;
				}
				else
				{
					double num4 = gTable[0, j] / 100.0;
					num3 = Math.Round(gTable[0, j] + num4 * num2);
					if (gTable[1, j] != 0.0 && Math.Round((num3 / gTable[1, j] - 1.0) * 100.0) == 0.0)
					{
						num3 = gTable[1, j];
					}
				}
				gTable[0, j] = num3;
			}
		}
		((Control)panelTable).Invalidate();
	}

	private void editGraphOut()
	{
		if (egSave)
		{
			eSaveCurve();
		}
		egSave = false;
		editCurve = false;
		((ToolStripItem)graphMenuItem).Enabled = true;
		eCurv = -1;
		lDown = -1;
		sCurv = -1;
		((Control)tvMap).Focus();
		((Control)this).Cursor = Cursors.Default;
		Cursor.Show();
		gTable = null;
	}

	private void SetLocUD()
	{
		SetvalueUD();
		int num = (pcEdit ? 17 : 0);
		Point location = new Point((lastSelect / 100 + 1) * lbW + ((Control)gbTable).Left + gOff - 3, (lastSelect % 100 + 1) * lbH + lbS + ((Control)gbTable).Top - 15 + num + 3);
		Point location2 = new Point(location.X - 41, location.Y + 2);
		if (pcEdit)
		{
			((Control)EDpanel).Location = location2;
			pcShow = lbSelect;
		}
		((Control)editUpDown).Location = location;
		((Control)EDpanel).Location = location2;
		((Control)panelTable).Invalidate();
	}

	private static KeyStates GetKeyState(Keys key)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected I4, but got Unknown
		KeyStates keyStates = KeyStates.None;
		short keyState = GetKeyState((int)key);
		if ((keyState & 0x8000) == 32768)
		{
			keyStates |= KeyStates.Down;
		}
		return keyStates;
	}

	public static bool IsKeyDown(Keys key)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
	}

	private void ISOMain_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Invalid comparison between Unknown and I4
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Invalid comparison between Unknown and I4
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Invalid comparison between Unknown and I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Invalid comparison between Unknown and I4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Invalid comparison between Unknown and I4
		if ((swMode != 0) | !((Control)menuStrip).Enabled | noMap)
		{
			return;
		}
		if (((int)e.KeyCode == 118) & showGraph & !graphSelect & rowTPS)
		{
			if (!showGraph)
			{
				unselectLabel(0);
			}
			keyF7 = true;
			showView = (ptrMap[iTable[iTag]] & 0x70) != 32;
			((Control)panelTable).Invalidate();
		}
		else if (editCurve & ((int)e.KeyCode == 16))
		{
			edShift = true;
			edGr = (pcGraph ? 1 : 10);
		}
		else
		{
			if (!((Control)editUpDown).Visible)
			{
				return;
			}
			if ((int)e.KeyCode == 33)
			{
				if (editUpDown.Value + editUpDown.Increment > editUpDown.Maximum)
				{
					editUpDown.Value = editUpDown.Maximum;
					return;
				}
				NumericUpDown obj = editUpDown;
				obj.Value += editUpDown.Increment;
			}
			else if ((int)e.KeyCode == 34)
			{
				if (editUpDown.Value - editUpDown.Increment < editUpDown.Minimum)
				{
					editUpDown.Value = editUpDown.Minimum;
					return;
				}
				NumericUpDown obj2 = editUpDown;
				obj2.Value -= editUpDown.Increment;
			}
			else if (lastSelect == firstSelect)
			{
				if (((int)e.KeyCode == 37) & (firstSelect / 100 > 1))
				{
					firstSelect = (lastSelect / 100 - 1) * 100 + lastSelect % 100;
				}
				else if (((int)e.KeyCode == 39) & (firstSelect / 100 < gCol))
				{
					firstSelect = (lastSelect / 100 + 1) * 100 + lastSelect % 100;
				}
				else if (((int)e.KeyCode == 38) & (firstSelect % 100 > 0))
				{
					firstSelect = lastSelect % 100 - 1 + lastSelect / 100 * 100;
				}
				else if (((int)e.KeyCode == 40) & (firstSelect % 100 < gRow - 1))
				{
					firstSelect = lastSelect % 100 + 1 + lastSelect / 100 * 100;
				}
				if (lastSelect != firstSelect)
				{
					lastSelect = firstSelect;
					SaveValueUD();
					eFirst = firstSelect;
					eLast = lastSelect;
					SetLocUD();
				}
			}
		}
	}

	private void ISOMain_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Invalid comparison between Unknown and I4
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Invalid comparison between Unknown and I4
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Invalid comparison between Unknown and I4
		if ((swMode != 0) | !((Control)menuStrip).Enabled | noMap)
		{
			return;
		}
		if (editCurve)
		{
			if ((e.KeyValue == 27) | (e.KeyValue == 13))
			{
				if (e.KeyValue == 27)
				{
					egSave = false;
				}
				graphSelect = false;
				lbSelect = false;
				editGraphOut();
				((Control)panelTable).Invalidate();
			}
			else if ((int)e.KeyCode == 16)
			{
				edShift = false;
				egClick = -1;
				edGr = 1;
			}
		}
		if ((int)e.KeyCode == 115)
		{
			if (showGraph & !editCurve)
			{
				oneCurve = !oneCurve;
			}
			else if ((ptrMap[tagMap] >= 9) & (ptrMap[tagMap] < 19))
			{
				if (editCurve)
				{
					sCent = !sCent;
					pcGraph = !pcGraph & sCent;
					((Control)panelTable).Invalidate();
				}
				else
				{
					pCent = !pCent;
					if (!((Control)editUpDown).Visible)
					{
						pcEdit = !pcEdit & pCent;
					}
					else if (editUpDown.Value == 0m)
					{
						pcEdit = !pcEdit & pCent;
						SetvalueUD();
						((Control)panelTable).Invalidate();
					}
				}
			}
		}
		if ((int)e.KeyCode == 117)
		{
			if (!showGraph)
			{
				unselectLabel(0);
			}
			if (editCurve)
			{
				eSaveCurve();
				gTable = null;
				editCurve = false;
				((Control)this).Cursor = Cursors.Default;
				lDown = -1;
			}
			if (((ptrMap[iTable[iTag]] & 0x70) != 32) | compareF)
			{
				showMod = !showMod;
				swapMap();
				menuItemEnabled(swMode == 0);
			}
		}
		else if ((int)e.KeyCode == 118)
		{
			keyF7 = false;
			showView = false;
			((Control)panelTable).Invalidate();
		}
	}

	private void swapMap()
	{
		nodeTrimEnabled(compareF | !showMod);
		if ((TypTable & 0xFFE0) == 2048)
		{
			IMap.WalbroParams(altMap ? IMap.offMap : 0, mode: true);
		}
		displayParams(-1, -1);
		if (compareF & showMod)
		{
			DisplayMsg(cutString(cmpFile, ((ToolStripItem)fileStatus).Width - 8), 64);
			DisplayMsg(cpMap, 128);
		}
		else
		{
			DisplayMsg(cutString(lastFile, ((ToolStripItem)fileStatus).Width - 8), 64);
			DisplayMsg(idMap, 128);
		}
		if (!showMod)
		{
			checkMapTrim(blank: false);
		}
		else
		{
			checkCmpTrim();
		}
		((Control)panelTable).Invalidate();
	}

	private void nodeTrimEnabled(bool en)
	{
		int num = Tune.idTrim % 100;
		int num2 = Tune.idTrim / 100;
		if (num2 > 16)
		{
			((Control)cTrimMenu).Enabled = en;
			return;
		}
		tvMap.Nodes[0].Nodes[num].Tag = (en ? 1 : (-1));
		tvMap.Nodes[0].Nodes[num2].Tag = (en ? 1 : (-1));
		if (en & (sTag != -1))
		{
			tvMap.SelectedNode = tvMap.Nodes[0].Nodes[sTag];
		}
		((Control)tvMap).Invalidate();
	}

	private void eSaveCurve()
	{
		if (sCurv < 0)
		{
			return;
		}
		if (sCurv < 100)
		{
			int num = (gRow - sCurv - 1) * gCol;
			for (int i = 0; i < gCol; i++)
			{
				gridArray[num + i] = gTable[0, i];
			}
		}
		else
		{
			int num = sCurv / 100 - 1;
			for (int i = 0; i < gRow; i++)
			{
				gridArray[i * gCol + num] = gTable[0, i];
			}
		}
		eTable = gridArray;
	}

	private decimal defineInc()
	{
		bool flag = ((TypTable < 7) & (TypTable != 3) & (TypTable != 4)) | (TypTable == 14);
		switch (ptrMap[tagMap])
		{
		case 5:
			return 10m;
		case 6:
		case 7:
		case 8:
			return 0.05m;
		case 9:
		case 10:
			return 0.1m;
		case 19:
		case 20:
			return ((TypTable & 0xFFE0) == 2048) ? 0.25m : 0.1m;
		case 21:
		case 22:
			return 0.1m;
		case 23:
			return 0.01m;
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
			return flag ? 0.9375m : 0.625m;
		case 36:
		case 37:
			return (TypTable > 2048) ? 0.25m : 0.1m;
		case 38:
			return flag ? 0.9375m : 0.625m;
		case 51:
		case 52:
		case 53:
		case 54:
		case 83:
		case 84:
		case 85:
		case 86:
			return 0.1m;
		default:
			return 1m;
		}
	}

	private void SetvalueUD()
	{
		int num = 0;
		int num2 = 0;
		int num3 = eFirst / 100;
		int num4 = eFirst % 100;
		int num5 = eLast / 100;
		int num6 = eLast % 100;
		int num7 = (showMod ? (gRow * gCol) : 0);
		EDInc = defineInc();
		double num8 = Tune.eRange[tagMap * 2];
		double num9 = Tune.eRange[tagMap * 2 + 1];
		editUpDown.Minimum = -65535m;
		editUpDown.Maximum = 65535m;
		eTable = new double[(num5 - num3 + 1) * (num6 - num4 + 1)];
		for (int num10 = gRow; num10 > 0; num10--)
		{
			for (int i = 1; i < gCol + 1; i++)
			{
				if ((i >= num3) & (i <= num5) & (num10 - 1 >= num4) & (num10 - 1 <= num6))
				{
					eTable[num++] = gridArray[num7 + num2];
				}
				num2++;
			}
		}
		for (num = 0; num < eTable.Length; num++)
		{
			if (eTable[num] < num9)
			{
				num9 = eTable[num];
			}
			if (eTable[num] > num8)
			{
				num8 = eTable[num];
			}
		}
		editUpDown.Value = 0m;
		if (pcEdit)
		{
			editUpDown.Minimum = -100m;
			if (num8 > 0.0)
			{
				editUpDown.Maximum = (int)((Tune.eRange[tagMap * 2 + 1] - num8) * 100.0 / num8);
			}
			if (editUpDown.Maximum > 250m)
			{
				editUpDown.Maximum = 250m;
			}
			editUpDown.Increment = 1m;
		}
		else
		{
			editUpDown.Minimum = (decimal)(Tune.eRange[tagMap * 2] - num9);
			editUpDown.Maximum = (decimal)(Tune.eRange[tagMap * 2 + 1] - num8);
			editUpDown.Increment = EDInc;
		}
	}

	private void SaveValueUD()
	{
		int num = 0;
		int num2 = 0;
		int num3 = eFirst / 100;
		int num4 = eFirst % 100;
		int num5 = eLast / 100;
		int num6 = eLast % 100;
		int num7 = (showMod ? (gRow * gCol) : 0);
		if (eTable == null)
		{
			return;
		}
		for (int i = 0; i < eTable.Length; i++)
		{
			if (pcEdit)
			{
				double num8 = eTable[i];
				eTable[i] = num8 * (double)(editUpDown.Value + 100m) / 100.0;
			}
			else
			{
				eTable[i] += (double)editUpDown.Value;
			}
		}
		for (int num9 = gRow; num9 > 0; num9--)
		{
			for (int i = 1; i < gCol + 1; i++)
			{
				if (num == eTable.Length)
				{
					break;
				}
				if ((i >= num3) & (i <= num5) & (num9 - 1 >= num4) & (num9 - 1 <= num6))
				{
					gridArray[num7 + num2] = eTable[num++];
				}
				num2++;
			}
		}
	}

	private void SaveGridTable()
	{
		if (!((eTable == null) & (gTable == null)))
		{
			if ((gTable != null) & egSave)
			{
				eSaveCurve();
			}
			double[] array = new double[gridArray.Length];
			Array.Copy(gridArray, array, array.Length);
			double num;
			switch (ptrMap[tagMap])
			{
			case 19:
			case 20:
			case 21:
			case 22:
				num = 1000.0;
				break;
			case 23:
				num = 10000.0;
				break;
			case 24:
			case 25:
				num = 255.0;
				break;
			case 31:
				num = 256.0;
				break;
			case 32:
				num = 100.0;
				infoMod = true;
				break;
			case 36:
			case 37:
			case 38:
				num = ((TypTable > 2048) ? 1001 : 1000);
				infoMod = true;
				break;
			case 49:
			case 50:
				num = 255.0;
				break;
			case 83:
			case 84:
			case 85:
			case 86:
				num = 1000.0;
				break;
			default:
				num = 100.0;
				break;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i] * num / 100.0;
			}
			IMap.SaveModMap(array, ptrMap[tagMap], TypTable);
			eTable = null;
		}
	}

	private void copyValueTable()
	{
		int num = 0;
		int num2 = 0;
		int num3 = eFirst / 100;
		int num4 = eFirst % 100;
		int num5 = eLast / 100;
		int num6 = eLast % 100;
		int num7 = (int)MapClip[2] / 100;
		int num8 = (int)MapClip[2] % 100;
		int num9 = (int)MapClip[3] / 100;
		int num10 = (int)MapClip[3] % 100;
		if (eTable == null)
		{
			return;
		}
		if (eFirst == eLast)
		{
			num5 = num3 + num9 - num7;
			num6 = num4 + num10 - num8;
			if (num5 > gCol)
			{
				num5 = gCol;
			}
			if (num6 >= gRow)
			{
				num6 = gRow - 1;
			}
			eLast = num5 * 100 + num6;
		}
		int num11 = num9 - num7 + 1;
		int num12 = num10 - num8 + 1;
		num9 = num5 - num3 + 1;
		num10 = num6 - num4 + 1;
		eTable = new double[num9 * num10];
		while (num10 - ++num2 >= 0)
		{
			for (int i = 0; i < num9; i++)
			{
				if (i < num9)
				{
					eTable[(num10 - num2) * num9 + i] = MapClip[(num12 - ((num2 - 1) % num12 + 1)) * num11 + i % num11 + 4];
				}
			}
		}
		num = 0;
		num2 = 0;
		for (int num13 = gRow; num13 > 0; num13--)
		{
			for (int i = 1; i < gCol + 1; i++)
			{
				if (num == eTable.Length)
				{
					break;
				}
				if ((i >= num3) & (i <= num5) & (num13 - 1 >= num4) & (num13 - 1 <= num6))
				{
					gridArray[num2] = eTable[num++];
				}
				num2++;
			}
		}
		firstSelect = eFirst;
		lastSelect = eLast;
	}

	private void cCopyMenu_Opening(object sender, CancelEventArgs e)
	{
		if (MapClip != null)
		{
			((ToolStripItem)pasteSubMenu).Enabled = enCopy((int)MapClip[1]) & (MapClip[0] == 65535.0) & !showMod;
		}
	}

	private void copySubMenu_Click(object sender, EventArgs e)
	{
		if (eTable != null)
		{
			eSave = false;
			SaveValueUD();
			mPaste = false;
			((ToolStripItem)pasteMenuItem).Enabled = false;
			MapClip = new double[eTable.Length + 4];
			MapClip[0] = 65535.0;
			MapClip[1] = ptrMap[tagMap];
			MapClip[2] = eFirst;
			MapClip[3] = eLast;
			Array.Copy(eTable, 0, MapClip, 4, eTable.Length);
			unselectLabel(2);
		}
	}

	private void pasteSubMenu_Click(object sender, EventArgs e)
	{
		copyValueTable();
		unselectLabel(2);
	}

	public static void checkMapTrim(bool blank)
	{
		int i = 0;
		int num = 0;
		if (blank & (MapTrim[0] == 2))
		{
			for (; i < MapTrim.Length - 4; i += 12)
			{
				MapTrim[i + 6] = 0;
				MapTrim[i + 7] = 0;
				MapTrim[i + 10] = 0;
				MapTrim[i + 11] = 0;
			}
		}
		for (i = 0; i < MapTrim.Length - 4; i += 2)
		{
			if ((MapTrim[i + 4] | MapTrim[i + 5]) != 0)
			{
				num |= (byte)((105690656278018L >> i / 2 % 3 * 8) & 0xFF);
			}
		}
		if (blank)
		{
			oneTrim = (MapTrim[0] & 4) == 0;
		}
		if (oneTrim)
		{
			num &= 0x62;
		}
		else if ((num & 2) == 2)
		{
			num |= 4;
		}
		MapTrim[0] = (byte)num;
		num = Tune.idTrim % 100;
		i = ((num > 0) ? ((int)me.tvMap.Nodes[0].Nodes[num - 1].Tag) : 0);
		((ToolStripItem)me.fusionMenuItem).Enabled = (MapTrim[0] > 0) & (swMode == 0);
		((ToolStripItem)me.useTrimMenuItem).Enabled = (swMode == 0) & (num * i > 1);
		((ToolStripItem)me.TrimToLMenuItem).Enabled = (swMode == 0) & ((MapTrim[0] & 2) != 0);
		me.useTrimMenuItem.Checked = oneTrim & (swMode == 0) & (num * i > 1);
	}

	private void clearMapTrim()
	{
		int i = 0;
		if (oneTrim)
		{
			for (; i < MapTrim.Length - 4; i += 12)
			{
				MapTrim[i + 6] = 0;
				MapTrim[i + 7] = 0;
				MapTrim[i + 8] = 0;
				MapTrim[i + 9] = 0;
				MapTrim[i + 10] = 0;
				MapTrim[i + 11] = 0;
			}
		}
	}

	public static void checkCmpTrim()
	{
		int i = 0;
		int num = 0;
		for (; i < cmpTrim.Length - 4; i += 2)
		{
			if ((cmpTrim[i + 4] | cmpTrim[i + 5]) != 0)
			{
				num |= (byte)((105690656278018L >> i / 2 % 3 * 8) & 0xFF);
			}
		}
		if (oneTrim)
		{
			num &= 0x62;
		}
		else if ((num & 2) == 2)
		{
			num |= 4;
		}
		cmpTrim[0] = (byte)num;
	}

	private void selectTrim(int n)
	{
		xTrim = ((!oneTrim) ? ((n == 0) ? 4 : (((n == 4) & (((TypTable < 72) & ((TypTable & 0xFFF8) != 8)) | ((TypTable & 0xFFF0) == 112))) ? 2 : 0)) : 0);
	}

	private void unselectLabel(int mode)
	{
		oneSelect = false;
		lbSelect = false;
		graphSelect = false;
		if (mode > 1)
		{
			showCells = mode;
		}
		else
		{
			editSelect = false;
		}
		((Control)EDpanel).Hide();
		((Control)editUpDown).Visible = false;
		valueUD_Close();
		((Control)panelTable).ContextMenuStrip = null;
		if (mode != 0)
		{
			((Control)panelTable).Invalidate();
		}
	}

	private void windowFocus()
	{
		HideBar();
		if ((IntPtr)groundTask == logHandle)
		{
			((Control)logForm).Focus();
		}
		else if ((IntPtr)groundTask == infoHandle)
		{
			((Control)infoForm).Focus();
		}
		else
		{
			((Control)this).Focus();
		}
	}

	private void activeAppTimer_Tick(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Invalid comparison between Unknown and I4
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Invalid comparison between Unknown and I4
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		if (HideTask)
		{
			groundTask = GetForegroundWindow();
			if (!toHide & ((IntPtr)groundTask != ((Control)this).Handle) & ((IntPtr)groundTask != logHandle) & ((IntPtr)groundTask != infoHandle))
			{
				ShowBar();
			}
			else if (TaskBarVisible)
			{
				windowFocus();
			}
		}
		if (iStart >= 0 && iStart-- == 0)
		{
			((ToolStripItem)serialMenuItem).Enabled = ((ListControl)cmbPortName).SelectedIndex != -1;
			if (!ISOFT.ListUnopenDevices(1073741826u) & !serialMode)
			{
				DisplayBox("", LangUI[mLang, 341], 3);
			}
			USBListen();
			ISOFT.InitializeSerialPort();
			((Control)this).Cursor = Cursors.Default;
		}
		if ((mStart & (iStart < 0)) && AboutBox.mOpacity == 0.0)
		{
			mStart = false;
			((Form)this).Opacity = 1.0;
			if (!mConnect & ((ToolStripItem)connectMenuItem).Enabled & autoConnect)
			{
				QConnect = 4;
			}
		}
		if (USBWait > 0 && --USBWait == 0)
		{
			ISOFT.InitializeSerialPort();
			if (((ListControl)lbDevList).SelectedIndex > -1)
			{
				lbDevList.Items[((ListControl)lbDevList).SelectedIndex].ToString();
			}
			lbDevList.Items.Clear();
			uint num = ISOFT.CreateDeviceInfoList();
			if ((num != 0) & mConnect & !serialMode)
			{
				return;
			}
			if (!ISOFT.ListUnopenDevices(1073741826u) & !USBIgnore)
			{
				USBIgnore = true;
				if (!serialMode)
				{
					DisplayBox("", LangUI[mLang, 341], 3);
				}
			}
			else
			{
				USBIgnore = false;
			}
			if (((ListControl)lbDevList).SelectedIndex == -1)
			{
				((Control)lbDevList).Text = "";
				if (mConnect)
				{
					breakConnection(ISORead.mFlash | ISORead.mLoad);
				}
			}
		}
		if (iConnect > 0)
		{
			iConnect--;
			if (iConnect == 0)
			{
				ISORead.SwitchMode(eMode.MODE_NULL);
			}
		}
		if (QConnect > 0)
		{
			QConnect--;
			if (QConnect == 0)
			{
				QueryConnect();
			}
		}
		if (flashTempo > 0 && --flashTempo == 0)
		{
			btnFlashEnabled(mode: true);
		}
		if (graphSelect & ((Control.MouseButtons & 0x100000) != 1048576))
		{
			panelTable_MouseUp(null, null);
		}
		if ((HideUD > 0) & ((Control.MouseButtons & 0x100000) != 1048576))
		{
			HideUD = 0;
			((Control)adjustUD).Hide();
			if (((Control)valueUD).Visible)
			{
				valueUD_Close();
			}
		}
		if (showMapID > 0)
		{
			if (--showMapID == 6)
			{
				int offset = (IMap.mapTable[0] & 0xF0) << 12;
				DisplayMsg(IMap.MapChecksum(offset, apply: true).ToString("X2"), 144);
			}
			else if (showMapID == 0)
			{
				DisplayMsg(idMap, 128);
			}
		}
		if (showCells > 0 && --showCells == 0)
		{
			mCells = -1;
			editSelect = false;
			((Control)me.panelTable).Invalidate();
		}
		if (refreshCode > 0 && --refreshCode == 0)
		{
			listCodesUpdate("", status: true);
		}
		if (refreshCode < 0 && ((++refreshCode == 0) & (((ListControl)listCodes).SelectedIndex == -1)))
		{
			DisplayMsg(LangUI[mLang, 239], 48);
		}
		if (onTest)
		{
			if (((testTick == 0) & !EXBVReset & !ISCVReset) && btnTest != -1)
			{
				tvTests.Nodes[btnTest].ImageIndex = 9;
				if ((swMode != 0) & (ISORead.mTest != 49))
				{
					int num2 = ((!_LC4) ? (ISORead.mTest & 0xF0) : 0);
					string text = (((num2 == 64) | (num2 == 80) | (num2 == 240)) ? ("... (" + (ISORead.mTest & 3) + ")") : "...");
					strTest = ((btnTest < 8) ? LangUI[mLang, 281] : "") + tvTests.Nodes[btnTest].Text;
					DisplayMsg(strTest + text, 64);
					DisplayMsg(strTest + text, 32);
				}
			}
			if (++testTick > 20)
			{
				if (!EXBVReset & !ISCVReset)
				{
					testTick = 20;
					if ((ISORead.mTest == 65) & !_LC4)
					{
						ISORead.StartDiagRoutine(24, 0);
					}
					else if ((ISORead.mTest == 81) & !_LC4)
					{
						ISORead.StartDiagRoutine(25, 0);
					}
					else if ((ISORead.mTest == 241) & !_LC4)
					{
						ISORead.StartDiagRoutine(26, 0);
					}
					else
					{
						if (ISORead.rTest == 2)
						{
							ISORead.SwitchMode(eMode.MODE_DIAGNOSTIC);
						}
						else
						{
							testTick = 0;
						}
						if (ISORead.mTest != 49)
						{
							DisplayMsg(LangUI[mLang, 282] + "\r", 32);
							if (swMode != 0)
							{
								DisplayMsg(strTest + LangUI[mLang, 282], 64);
							}
						}
					}
				}
				else if (EXBVReset)
				{
					switch (stepEXBV)
					{
					case 1:
						DisplayMsg(LangUI[mLang, 307], 64);
						break;
					case 2:
					case 3:
						SettingEXBV();
						break;
					}
					tvTests.Nodes[9].ImageIndex = (((testTick & 1) == 0) ? 9 : 8);
					if (testTick > 21)
					{
						testTick = 20;
					}
					btnTest = -1;
				}
				else
				{
					switch (stepISCV)
					{
					case 3:
						testTick = 18;
						me.tvTests.Nodes[btnTest].ImageIndex = 8;
						ISORead.SwitchMode(eMode.MODE_STOP_DIAG);
						break;
					case 4:
						me.tvTests.Nodes[btnTest].ImageIndex = 8;
						SettingTPS();
						break;
					default:
						tvTests.Nodes[10].ImageIndex = (((testTick & 1) == 0) ? 9 : 8);
						if (testTick > 21)
						{
							testTick = 20;
						}
						break;
					}
				}
				if (testTick == 0)
				{
					endTest(rst: false);
				}
			}
		}
		else if (((btnTest != -1) & !setTPS) && outTest++ > 20)
		{
			tvTests.Nodes[btnTest].ImageIndex = 8;
			string text2 = ((btnTest < 9) ? LangUI[mLang, 281] : "");
			string text3 = tvTests.Nodes[btnTest].Text + LangUI[mLang, 290];
			DisplayMsg(text2 + text3, 64);
			DisplayMsg(text2 + text3, 32);
			btnTest = -1;
		}
		if ((wbTrim & 0xFF) > 0)
		{
			int num3 = wbTrim & 0xFF;
			if (--num3 == 0)
			{
				wbTrimValidate();
			}
			else
			{
				wbTrim = (wbTrim & 0x700) | num3;
			}
		}
		if (rstTrim)
		{
			if (btnTest == -1)
			{
				if ((swMode == 1) & sagemECU)
				{
					DisplayMsg("", 512);
				}
				tvTests.Nodes[rTrim].ImageIndex = (((rTrim > 9) & sagemECU) ? 5 : 8);
				rstTrim = false;
			}
			else if (_KTM & (btnTest == 9))
			{
				tvTests.Nodes[rTrim].ImageIndex = (((testTick & 1) == 0) ? 9 : 8);
				if (testTick == 0)
				{
					testTick += 2;
				}
			}
			else if (testTick-- > 0)
			{
				tvTests.Nodes[rTrim].ImageIndex = (((testTick & 1) == 0) ? 9 : 8);
			}
			else
			{
				btnTest = -1;
			}
		}
		if (dClear > 0 && --dClear == 0)
		{
			DisplayMsg("", 64);
		}
		if (tDebug > 0 && --tDebug == 0)
		{
			mDebug = 0;
			tDebug = -1;
		}
	}

	private void checkTimer_Tick(object sender, EventArgs e)
	{
		ISOFT.readTimer();
		if (pcShow)
		{
			((Control)EDpanel).Visible = ((Control)editUpDown).Visible;
			pcShow = false;
		}
	}

	public void breakConnection(bool msg)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		((Control)menuStrip).Enabled = true;
		((Form)this).MaximizeBox = (swMode == 0) & enWide;
		((Control)me).Cursor = Cursors.Default;
		((Control)tvMap).Enabled = TypTable > -1;
		((Control)panelTable).Enabled = true;
		((Control)me.BtnLeft).Enabled = true;
		((Control)me.BtnMid).Enabled = true;
		((Control)me.BtnRight).Enabled = true;
		ProgressBarInit(0);
		if (msg)
		{
			DisplayBox("", LangUI[mLang, 203], 2);
			if (!ISORead.mLoad)
			{
				DisplayMsg(LangUI[mLang, 200], 32);
			}
		}
		if (ISORead.mMode != eMode.MODE_NULL)
		{
			ISORead.SwitchMode(eMode.MODE_NULL);
		}
		else
		{
			ISORead.iRetry = 0;
		}
		sagemECU = TypTable < 16;
		me.QueryConnect();
		QConnect = 1;
	}

	private void serialMenuItemDropDown(object sender, EventArgs e)
	{
		ISOFT.UpdateSerialPort();
	}

	private static void serialChecked(bool en)
	{
		int num = 0;
		bool flag = ((ArrangedElementCollection)((ToolStripDropDownItem)me.serialMenuItem).DropDownItems).Count > 0;
		bool flag2 = false;
		for (int i = 0; i < ((ArrangedElementCollection)((ToolStripDropDownItem)me.serialMenuItem).DropDownItems).Count; i++)
		{
			flag2 = (((ToolStripItem)m_serial[i]).Text == lastPort) | m_serial[i].Checked;
			m_serial[i].Checked = en & flag2;
			if (m_serial[i].Checked)
			{
				num = i;
			}
		}
		if (!flag2)
		{
			m_serial[num].Checked = en & flag;
		}
		if (!(en & flag & !dConnect))
		{
			return;
		}
		lastPort = ((ToolStripItem)m_serial[num]).Text;
		if (!mConnect)
		{
			serialMode = true;
			((ListControl)me.cmbPortName).SelectedIndex = num;
			((ToolStripItem)me.connectMenuItem).Enabled = ((ListControl)me.cmbPortName).SelectedIndex >= 0;
			if (((ToolStripItem)me.connectMenuItem).Enabled & me.autoConnect & !comFailed)
			{
				me.QueryConnect();
			}
		}
	}

	public static void addSerialMenuItem(bool check)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		string text = "";
		ToolStripMenuItem val = null;
		((ToolStripDropDownItem)me.serialMenuItem).DropDownItems.Clear();
		for (int i = 0; i < me.cmbPortName.Items.Count && i != 8; i++)
		{
			text = me.cmbPortName.Items[i].ToString();
			val = new ToolStripMenuItem(text);
			((ToolStripDropDownItem)me.serialMenuItem).DropDownItems.Add((ToolStripItem)(object)val);
			((ToolStripItem)val).Click += serialMenuItemDropDownItem_Click;
			m_serial[i] = val;
		}
		((ToolStripItem)me.serialMenuItem).Enabled = val != null;
		serialItemsEnable(!mConnect);
		serialChecked((val != null) & check);
	}

	public static void addUSBMenuItem()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		string text = "";
		ToolStripMenuItem val = null;
		((ToolStripDropDownItem)me.uSBMenuItem).DropDownItems.Clear();
		for (int i = 0; i < me.lbDevList.Items.Count && i != 4; i++)
		{
			text = me.lbDevList.Items[i].ToString();
			val = new ToolStripMenuItem(text.Substring(0, text.IndexOf("\0")));
			((ToolStripDropDownItem)me.uSBMenuItem).DropDownItems.Add((ToolStripItem)(object)val);
			((ToolStripItem)val).Click += usbMenuItemDropDownItem_Click;
			m_USB[i] = val;
		}
		((ToolStripItem)me.uSBMenuItem).Enabled = val != null;
		USBItemsEnable(!mConnect);
		m_USB[0].Checked = (val != null) & !mConnect & !serialMode;
		if (!(mConnect & serialMode))
		{
			serialChecked((val == null) | serialMode);
		}
		if (m_USB[0].Checked)
		{
			serialMode = false;
			lastPort = ((ToolStripItem)m_USB[0]).Text;
		}
		else
		{
			serialMode = true;
			lastPort = usbSerial;
		}
	}

	private static void serialMenuItemDropDownItem_Click(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		if (mConnect)
		{
			return;
		}
		int num = 0;
		ToolStripMenuItem val = (ToolStripMenuItem)sender;
		for (int i = 0; i < 4; i++)
		{
			m_USB[i].Checked = false;
		}
		for (int i = 0; i < 8; i++)
		{
			if (((object)m_serial[i]).Equals((object?)val))
			{
				num = i;
				serialMode = true;
				lastPort = ((ToolStripItem)m_serial[i]).Text;
			}
			else
			{
				m_serial[i].Checked = false;
			}
		}
		if (num < me.cmbPortName.Items.Count)
		{
			val.Checked = true;
			((ListControl)me.cmbPortName).SelectedIndex = num;
			((ListControl)me.lbDevList).SelectedIndex = -1;
		}
	}

	private static void usbMenuItemDropDownItem_Click(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		if (mConnect)
		{
			return;
		}
		int num = 0;
		ToolStripMenuItem val = (ToolStripMenuItem)sender;
		for (int i = 0; i < 8; i++)
		{
			m_serial[i].Checked = false;
		}
		for (int i = 0; i < 4; i++)
		{
			if (((object)m_USB[i]).Equals((object?)val))
			{
				num = i;
				serialMode = false;
				lastPort = ((ToolStripItem)m_USB[i]).Text;
			}
			else
			{
				m_USB[i].Checked = false;
			}
		}
		if (num < me.lbDevList.Items.Count)
		{
			val.Checked = true;
			((ListControl)me.lbDevList).SelectedIndex = num;
		}
	}

	private void _mapInfos_Click(object sender, EventArgs e)
	{
		if (!noMap)
		{
			HideUD = 0;
			unselectLabel(1);
			SaveGridTable();
			if (!(compareF & showMod))
			{
				showMapID = 12;
				string text = (IMap.MapID >> 8).ToString("X2") + "-" + (IMap.MapID & 0xFF).ToString("X2");
				DisplayMsg(LangUI[mLang, 94] + text, 160);
			}
		}
	}

	public static void DisplayMsg(string msg, int Bk)
	{
		int num = Bk / 16;
		int num2 = 0;
		switch (num)
		{
		case 1:
			((Control)me.tvVehicule).Refresh();
			break;
		case 2:
			if ((sbLog.ToString() == "") & (msg.IndexOf("\r") == 0))
			{
				msg = msg.Remove(0, 1);
			}
			sbLog.Append(msg);
			if (showLog)
			{
				((TextBoxBase)me.logForm.rtbLog).AppendText(msg);
				((Control)me.logForm.rtbLog).Refresh();
			}
			if ((mDebug & 2) > 0)
			{
				string text5 = "";
				while (msg.IndexOf("\r") > -1)
				{
					int num3 = msg.IndexOf("\r");
					text5 = msg.Substring(0, num3 + 1) + "\n";
					msg = msg.Substring(num3 + 1, msg.Length - num3 - 1);
				}
				text5 += msg;
				if (text5.IndexOf(" ") == 0)
				{
					text5 = text5.Remove(0, 1);
				}
				WriteTrcFile(null, 0, 0, text5);
			}
			break;
		case 3:
			((Control)me.tbDescription).Text = msg;
			break;
		case 4:
		{
			string text6 = new string(' ', (swMode == 0) ? 2 : 10);
			((ToolStripItem)me.fileStatus).Text = text6 + msg;
			break;
		}
		case 6:
		{
			string text3 = "";
			string text4;
			if (ISORead.dataSensor[63] == null)
			{
				text4 = "";
			}
			else if (sagemECU)
			{
				text4 = " -  Sagem";
			}
			else if (_Walbro)
			{
				text4 = " -  Walbro";
			}
			else
			{
				if (_LC4 & _2nECU)
				{
					text3 = " #" + (eInfo + 1);
				}
				text4 = " -  Keihin";
			}
			me.tvVehicule.Nodes[0].Text = LangUI[mLang, 65] + text4 + text3;
			break;
		}
		case 7:
			((Control)me._vehInfos).Text = "VIN : " + msg;
			break;
		case 8:
			((Control)me._mapInfos).Text = LangUI[mLang, 67] + msg;
			break;
		case 9:
			((Control)me._mapInfos).Text = LangUI[mLang, 70] + msg;
			break;
		case 10:
			((Control)me._mapInfos).Text = msg;
			break;
		case 16:
			((ToolStripItem)me.battStatus).Text = " " + msg;
			break;
		case 18:
			switch (msg)
			{
			case "01":
				((ToolStripItem)me.loopStatus).Image = (Image)(object)Resources.OpenLoop;
				((ToolStripItem)me.loopStatus).ToolTipText = LangUI[mLang, 296];
				num2 = 296;
				break;
			case "02":
				((ToolStripItem)me.loopStatus).Image = (Image)(object)Resources.ClosedLoop;
				((ToolStripItem)me.loopStatus).ToolTipText = LangUI[mLang, 297];
				num2 = 297;
				break;
			case "04":
				((ToolStripItem)me.loopStatus).Image = (Image)(object)Resources.OpenLoop;
				((ToolStripItem)me.loopStatus).ToolTipText = LangUI[mLang, 298];
				num2 = 298;
				break;
			default:
				if ((msg == "08") | (msg == "10"))
				{
					((ToolStripItem)me.loopStatus).Image = (Image)(object)Resources.OpenLoop;
					((ToolStripItem)me.loopStatus).ToolTipText = LangUI[mLang, 299];
					num2 = 299;
				}
				break;
			}
			((ToolStripItem)me.loopStatus).Enabled = num2 > 0;
			((ToolStripItem)me.loopStatus).Tag = num2;
			break;
		case 20:
			if (msg == "0")
			{
				((ToolStripItem)me.tpsStatus).Image = (Image)(object)Resources.LedOff;
				((ToolStripItem)me.tpsStatus).ToolTipText = LangUI[mLang, 294];
				num2 = 294;
			}
			else
			{
				((ToolStripItem)me.tpsStatus).Image = (Image)(object)Resources.LedOn;
				((ToolStripItem)me.tpsStatus).ToolTipText = LangUI[mLang, 295];
				num2 = 295;
			}
			((ToolStripItem)me.tpsStatus).Enabled = num2 > 0;
			((ToolStripItem)me.tpsStatus).Tag = num2;
			break;
		case 32:
		{
			dClear = 20;
			string text = LangUI[mLang, 289];
			string text2 = LangUI[mLang, 290 + (((ISORead.mTrim & 0x40) != 0) ? 1 : 0)];
			switch (ISORead.mTrim & 0xF)
			{
			case 6:
				DisplayMsg(text + LangUI[mLang, 268] + text2 + "\r", 32);
				DisplayMsg(text + LangUI[mLang, 268] + text2, 64);
				break;
			case 7:
				DisplayMsg(text + LangUI[mLang, 269] + text2 + "\r", 32);
				DisplayMsg(text + LangUI[mLang, 269] + text2, 64);
				break;
			default:
				DisplayMsg(LangUI[mLang, 266] + text2 + "\r", 32);
				DisplayMsg(LangUI[mLang, 266] + text2, 64);
				break;
			}
			break;
		}
		}
	}

	public static DialogResult DisplayBox(string title, string msg, int type)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int num2 = -1;
		string text = "";
		toHide = true;
		DialogResult val = (DialogResult)2;
		queryBox = new QueryForm();
		QueryForm.boxMode = type;
		((Control)queryBox._lbMap).Text = title;
		while (msg.IndexOf("\r") >= 0)
		{
			num++;
			num2 = msg.IndexOf("\r");
			text = msg.Substring(0, num2);
			switch (num)
			{
			case 1:
				((Control)queryBox.rLabel).Text = text;
				break;
			case 2:
				((Control)queryBox.sLabel).Text = text;
				break;
			default:
				((Control)queryBox.tLabel).Text = text;
				break;
			}
			if (num2 < msg.Length)
			{
				msg = msg.Substring(num2 + 1, msg.Length - num2 - 1);
			}
		}
		switch (num)
		{
		case 0:
			((Control)queryBox.rLabel).Text = msg;
			break;
		case 1:
			((Control)queryBox.sLabel).Text = msg;
			break;
		case 2:
			((Control)queryBox.tLabel).Text = msg;
			break;
		}
		val = ((Form)queryBox).ShowDialog();
		toHide = false;
		return val;
	}

	public static void infosConnect(int state)
	{
		iConnect = ((state == 1) ? 6 : 0);
		mLed = state;
		if ((mLed == 0) | (mLed > 2))
		{
			((ToolStripItem)me.ledStatus).ToolTipText = null;
		}
		else
		{
			((ToolStripItem)me.ledStatus).ToolTipText = LangUI[mLang, mLed + 311];
		}
	}

	public static void USBLed(int On)
	{
		((ToolStripItem)me.ledStatus).Tag = On;
		((Control)me.statusStrip).Invalidate(((ToolStripItem)me.ledStatus).Bounds);
		((Control)me.statusStrip).Update();
	}

	private void ledStatus_Paint(object sender, PaintEventArgs e)
	{
		if ((int)((ToolStripItem)ledStatus).Tag > 0)
		{
			IDraw.LED_Paint(e);
		}
	}

	private void OpenSelectFile(string mName)
	{
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		eTable = null;
		errFile = "";
		DisplayMsg("", 64);
		if (mName != "" && mName != null)
		{
			try
			{
				Mapbuffer = ReadFile(mName, first: true);
				if (Mapbuffer != null)
				{
					TypTable = IMap.MakeMemoryMap(Mapbuffer);
				}
				else
				{
					TypTable = -3;
				}
				mapName = Path.GetFileName(mName);
				switch (TypTable)
				{
				case -3:
					errFile = mapName + " : " + LangUI[mLang, 320];
					break;
				case -2:
					errFile = mapName + " : " + LangUI[mLang, 223];
					break;
				case -1:
					errFile = mapName + " : " + LangUI[mLang, 224];
					break;
				default:
					showMod = false;
					compareF = false;
					compareMenuItem.Checked = false;
					SetHKCUkey("Software\\TuneECU\\Properties", "LastTune", mName);
					lastFile = mName;
					DisplayMsg(cutString(lastFile, ((ToolStripItem)fileStatus).Width - 8), 64);
					break;
				case -4:
					break;
				}
				unSave = TypTable > 0;
				tvMap_Setup();
			}
			catch (Exception ex)
			{
				lastFile = null;
				TypTable = -1;
				errFile = ex.Message.ToString() + "    ";
			}
		}
		if (!mStart & !notry)
		{
			if (errFile != "")
			{
				DisplayBox("", errFile, 3);
			}
			notry = true;
			if ((TypTable < 0) & (lastFile != "") & (lastFile != null) & (swMode == 0))
			{
				OpenSelectFile(lastFile);
			}
		}
		AfterOpenMap();
	}

	private void AfterOpenMap()
	{
		if (TypTable < 0)
		{
			IMap.umodMap = null;
		}
		noMap = TypTable < 0;
		if (((Control)menuStrip).Enabled)
		{
			enableMenuItems(ISORead.mMode, 0);
		}
		if (noMap)
		{
			lastFile = null;
			Mapbuffer = null;
			SetDefTable();
		}
	}

	private bool OpenCompareFile(string mName)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		errFile = "";
		int num = -1;
		try
		{
			Mapbuffer = ReadFile(mName, first: false);
			num = ((Mapbuffer == null) ? (-3) : IMap.MakeCompareMap(Mapbuffer));
			cmpName = Path.GetFileName(mName);
			switch (num)
			{
			case -4:
				errFile = LangUI[mLang, 247];
				break;
			case -3:
				errFile = cmpName + " : " + LangUI[mLang, 320];
				break;
			case -2:
				errFile = cmpName + " : " + LangUI[mLang, 223];
				break;
			case -1:
				errFile = cmpName + " : " + LangUI[mLang, 224];
				break;
			}
		}
		catch (Exception ex)
		{
			errFile = ex.Message.ToString() + "    ";
		}
		if (errFile != "")
		{
			DisplayBox("", errFile, 3);
		}
		cmpFile = mName;
		return (errFile == "") & (num == 0);
	}

	public static FileStream openWriteFile(string filePath)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		FileStream result = null;
		if (File.Exists(filePath))
		{
			try
			{
				File.Delete(filePath);
			}
			catch (Exception ex)
			{
				DisplayBox("", ex.Message.ToString(), 3);
				return null;
			}
		}
		try
		{
			result = new FileStream(filePath, FileMode.Append, FileAccess.Write);
		}
		catch (Exception ex2)
		{
			DisplayBox("", ex2.Message.ToString(), 3);
		}
		return result;
	}

	public static bool WriteStream(FileStream fileStream, byte[] buffer, int start, int length)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			fileStream.Write(buffer, start, length);
		}
		catch (Exception ex)
		{
			DisplayBox("", ex.Message.ToString(), 3);
			return false;
		}
		return true;
	}

	public static void closeStream(FileStream fileStream)
	{
		fileStream?.Close();
	}

	public static string ReadInfo(string filePath)
	{
		bool flag = false;
		string text = "";
		string text2 = "";
		string format = "{0:x}";
		FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 1000;
			byte[] array = new byte[num3];
			while ((num3 > 0) & !flag)
			{
				num = fileStream.Read(array, num2, num3);
				flag = num <= 0;
				num3 -= num;
				num2 += num;
			}
			if (flag)
			{
				return null;
			}
			if ((BitConverter.ToInt32(array, 0) & 0xFFFFFFF0u) == 402920288)
			{
				IMap.codecMap(array, mode: false);
				int num4 = BitConverter.ToInt16(array, 28);
				if (BitConverter.ToInt16(array, num4 + 31) != 28518)
				{
					return "";
				}
				text2 = ISORead.BuildString(array, 30, num4, ascii: true, nozero: false);
				if ((array[0] == 97) | (array[0] == 104))
				{
					text = ISORead.BuildString(array, 4, 16, ascii: true, nozero: false);
				}
				else
				{
					if (array[0] == 100)
					{
						int num5 = IMap.identifyMap(array, 20, -1);
						if ((num5 >= 8) & (num5 <= 12))
						{
							format = "{0:x6}";
							text = string.Format(format, (array[11] << 16) | (array[12] << 8) | array[13]);
						}
						else
						{
							text = string.Format(format, ISORead.IDSagem((array[11] << 16) | (array[12] << 8) | array[13]));
							if (text == "0")
							{
								text = $"{(array[19] << 16) | (array[20] << 8) | array[21]:x}";
							}
						}
					}
					else
					{
						text = string.Format(format, (array[19] << 16) | (array[12] << 8) | array[13]);
					}
					text = text + "|" + string.Format(format, (array[19] << 16) | (array[20] << 8) | array[21]);
				}
			}
			else if (BitConverter.ToInt32(array, 0) == 202)
			{
				int num4 = BitConverter.ToInt16(array, 12);
				text2 = ISORead.BuildString(array, 28, num4, ascii: true, nozero: false);
			}
			else if (BitConverter.ToInt32(array, 0) == 2)
			{
				fileStream.Seek(BitConverter.ToInt16(array, 16), SeekOrigin.Begin);
				int num4 = 0;
				num2 = 0;
				num3 = 256;
				array = new byte[num3];
				while ((num3 > 0) & !flag)
				{
					num = fileStream.Read(array, num2, num3);
					flag = num <= 0;
					num3 -= num;
					num2 += num;
				}
				for (; array[num4] != 0; num4++)
				{
				}
				text2 = ISORead.BuildString(array, 0, num4, ascii: true, nozero: false);
			}
		}
		finally
		{
			fileStream.Close();
			if (flag)
			{
				text2 = "";
			}
		}
		return text + ":" + text2;
	}

	private byte[] ReadFile(string filePath, bool first)
	{
		int i = 0;
		int num = 0;
		bool flag = false;
		string text = "";
		FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		byte[] array2;
		try
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = (int)fileStream.Length;
			int num5 = num4;
			byte[] array = new byte[num5];
			while ((num5 > 0) & !flag)
			{
				num2 = fileStream.Read(array, num3, num5);
				flag = num2 <= 0;
				num5 -= num2;
				num3 += num2;
			}
			if (flag)
			{
				return null;
			}
			if ((BitConverter.ToInt32(array, 0) & 0xFFFFFFF0u) != 402920288)
			{
				return null;
			}
			IMap.codecMap(array, mode: false);
			int num6 = BitConverter.ToInt16(array, 28);
			if (BitConverter.ToInt16(array, num6 + 31) != 28518)
			{
				return null;
			}
			string text2;
			if ((array[0] == 97) | (array[0] == 104))
			{
				text2 = ISORead.BuildString(array, 4, 16, ascii: true, nozero: false);
			}
			else if (array[0] == 100)
			{
				int num7 = IMap.identifyMap(array, 20, -1);
				if ((num7 >= 8) & (num7 <= 12))
				{
					text2 = $"{(array[11] << 16) | (array[12] << 8) | array[13]:x6}";
				}
				else
				{
					text2 = $"{ISORead.IDSagem((array[11] << 16) | (array[12] << 8) | array[13]):x}";
					if (text2 == "0")
					{
						text2 = $"{(array[19] << 16) | (array[20] << 8) | array[21]:x}";
					}
				}
			}
			else
			{
				text2 = $"{(array[19] << 16) | (array[12] << 8) | array[13]:x}";
			}
			text = ISORead.BuildString(array, 30, num6, ascii: true, nozero: false);
			num = array[num6 + 33];
			num2 = num * 8 + 38;
			for (; i < num; i++)
			{
				num2 += BitConverter.ToInt32(array, num6 + i * 8 + 38);
			}
			i = 30;
			num5 = num6 + 4;
			array2 = new byte[num2];
			Array.Copy(array, 0, array2, 0, 28);
			array2[28] = (byte)num;
			num = array2[28] * 8;
			Array.Copy(array, num6 + 34, array2, i, num);
			i += num;
			num += num6 + 34;
			Array.Copy(array, num, array2, i, num2 - i);
			int num8 = 12292;
			if (first)
			{
				idMap = text2;
				DisplayMsg(idMap, 128);
				descMap = text;
				((Control)infoForm.rtbInfos).Text = descMap;
				infoMod = false;
				MapTrim = new byte[num8];
				if (num4 - num2 - num5 >= num8)
				{
					Array.Copy(array, num2 + num5, MapTrim, 0, num8);
				}
				checkMapTrim(blank: true);
				xTrim = 0;
			}
			else
			{
				cpMap = text2;
				cmpTrim = new byte[num8];
				if (num4 - num2 - num5 >= num8)
				{
					Array.Copy(array, num2 + num5, cmpTrim, 0, num8);
				}
				checkCmpTrim();
				if (eTrim == 0)
				{
					updateTrim();
				}
				MapSelected(tagMap);
			}
		}
		finally
		{
			fileStream.Close();
			if (flag)
			{
				array2 = null;
			}
		}
		return array2;
	}

	private void saveMapFile(string mName)
	{
		byte[] sTrim = null;
		StringBuilder sInfo = new StringBuilder(descMap);
		FileStream fileStream = openWriteFile(mName);
		if (fileStream != null)
		{
			clearMapTrim();
			checkMapTrim(blank: false);
			if (MapTrim[0] > 0)
			{
				sTrim = MapTrim;
			}
			byte[] array = IMap.encodeHex(sInfo, sTrim);
			if (WriteStream(fileStream, array, 0, array.Length))
			{
				unSave = true;
				flashItemEnabled();
			}
			closeStream(fileStream);
			IMap.CopyUMap();
			infoMod = false;
			SetHKCUkey("Software\\TuneECU\\Properties", "LastTune", mName);
			lastFile = mName;
			mapName = Path.GetFileName(mName);
			DisplayMsg(cutString(lastFile, ((ToolStripItem)fileStatus).Width - 8), 64);
			MapSelected(tagMap);
		}
	}

	private static void WriteTxtFile(string mName)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		StreamWriter streamWriter = null;
		StringBuilder stringBuilder = new StringBuilder();
		string value = me.separator;
		if (File.Exists(mName))
		{
			try
			{
				File.Delete(mName);
			}
			catch (Exception ex)
			{
				DisplayBox("", ex.Message.ToString(), 3);
				return;
			}
		}
		try
		{
			streamWriter = new StreamWriter(mName);
			stringBuilder.Append(value);
			for (int i = 0; i < gCol; i++)
			{
				stringBuilder.Append(((double)LH_Array[i] / (double)((!dcLabel) ? 1 : 10)).ToString());
				stringBuilder.Append(value);
			}
			streamWriter.WriteLine(stringBuilder.ToString());
			int num = (showMod ? gRow : 0);
			int num2 = (showMod ? (gRow * gCol) : 0);
			for (int num3 = gRow - 1; num3 >= 0; num3--)
			{
				stringBuilder = new StringBuilder();
				stringBuilder.Append(LV_Array[num3 + num].ToString());
				stringBuilder.Append(value);
				for (int i = 0; i < gCol; i++)
				{
					stringBuilder.Append(gridArray[num3 * gCol + i + num2].ToString(gFormat));
					stringBuilder.Append(value);
				}
				streamWriter.WriteLine(stringBuilder.ToString());
			}
		}
		finally
		{
			streamWriter?.Close();
		}
	}

	private int[] gearPCV(byte[] rData, int id, int at, int c, int g)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		int i = 0;
		int num;
		for (num = 58; (BitConverter.ToUInt16(rData, num + i - 2) != id) & (num + i < at); i += 16)
		{
		}
		num += i;
		if (num >= at)
		{
			return null;
		}
		for (i = 0; (BitConverter.ToUInt16(rData, num + i * 16 - 2) == id) & (num + i * 16 < at); i++)
		{
		}
		int[] array = new int[i];
		for (i = 0; i < array.Length; i++)
		{
			array[i] = BitConverter.ToUInt16(rData, num + i * 16 + 10);
		}
		if (((rData[num] & 0xF) == 15) | (g < 3))
		{
			return array;
		}
		int num2 = g + 9;
		if (num2 > 15)
		{
			num2 = 15;
		}
		if (QueryForm.pGear < 0)
		{
			DisplayBox("", LangUI[mLang, 310], num2);
		}
		int[] array2 = new int[i / g];
		i = array.Length / g;
		Array.Copy(array, QueryForm.pGear * i, array2, 0, i);
		return array2;
	}

	private byte[] readPCFile(string filePath)
	{
		bool flag = false;
		byte[] array = new byte[1];
		FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 28;
			byte[] array2 = new byte[num3];
			while ((num3 > 0) & !flag)
			{
				num = fileStream.Read(array2, num2, num3);
				flag = num <= 0;
				num3 -= num;
				num2 += num;
			}
			if (flag)
			{
				return array;
			}
			int num4 = BitConverter.ToInt32(array2, 0);
			if ((num4 != 202) & (num4 != 2))
			{
				return array;
			}
			pcType = ((num4 == 2) ? 1 : 0);
			array[0] = 254;
			int[] array3 = ((num4 == 202) ? Tune.pcMap : Tune.pcV);
			int num5 = ((num4 == 202) ? Tune.idPC : Tune.idPV);
			int num6 = BitConverter.ToInt32(array2, 4);
			int i;
			for (i = 0; i < array3.Length && !((num6 == array3[i]) & (((int)Math.Pow(2.0, i) & num5) != 0)); i++)
			{
			}
			if (i == array3.Length)
			{
				return array;
			}
			if (num4 == 2)
			{
				num = 0;
				num2 = 0;
				array[0] = 1;
				num3 = (int)fileStream.Length;
				array2 = new byte[num3];
				fileStream.Seek(0L, SeekOrigin.Begin);
				while ((num3 > 0) & !flag)
				{
					num = fileStream.Read(array2, num2, num3);
					flag = num <= 0;
					num3 -= num;
					num2 += num;
				}
				if (flag)
				{
					return array;
				}
				int num7 = array2[21];
				int g = array2[22];
				int num8 = BitConverter.ToInt16(array2, 60);
				int num9 = BitConverter.ToInt16(array2, 64);
				int num10 = 0;
				int num11 = 0;
				int num12 = array2[num8];
				int num13 = array2[num9];
				short[] array4 = new short[num12];
				for (i = 0; i < num12; i++)
				{
					array4[i] = BitConverter.ToInt16(array2, num8 + (i + 2) * 2);
				}
				short[] array5 = new short[num13];
				for (i = 0; i < num13; i++)
				{
					array5[i] = BitConverter.ToInt16(array2, num9 + (i + 2) * 2);
				}
				if ((array2[59] & 0xD0) != 208)
				{
					return array;
				}
				QueryForm.pGear = -1;
				int[] array6 = gearPCV(array2, 16577, num8, num7, g);
				if (array6 == null)
				{
					return array;
				}
				for (i = 0; i < array6.Length; i++)
				{
					if (num10 == array6[i])
					{
						continue;
					}
					num10 = array6[i];
					double[] array7 = new double[num12 * num13];
					for (int j = 0; j < num12; j++)
					{
						for (int k = 0; k < num13; k++)
						{
							array7[j * num13 + k] = array2[num10 + k * num12 + j] - 100;
						}
					}
					int ind = (num11 << 8) + 1;
					IMap.ConvertPcmd(array4, array5, array7, ind);
					num11++;
				}
				oneTrim = num11 != num7;
				array6 = gearPCV(array2, 16833, num8, num7, g);
				if (array6 != null)
				{
					num10 = array6[0];
					double[] array7 = new double[num12 * num13];
					for (int j = 0; j < num12; j++)
					{
						for (int k = 0; k < num13; k++)
						{
							i = array2[num10 + k * num12 + j];
							i = (i - ((i > 128) ? 256 : 0)) * 10;
							array7[j * num13 + k] = i;
						}
					}
					int ind = 1026;
					IMap.ConvertPcmd(array4, array5, array7, ind);
				}
			}
			else
			{
				int num12 = BitConverter.ToInt16(array2, 10);
				int num14 = BitConverter.ToInt16(array2, 12);
				array[0] = 1;
				num = 0;
				num2 = 0;
				num3 = num14 + num12 * 4 + 20;
				array2 = new byte[num3];
				while ((num3 > 0) & !flag)
				{
					num = fileStream.Read(array2, num2, num3);
					flag = num <= 0;
					num3 -= num;
					num2 += num;
				}
				if (flag)
				{
					return array;
				}
				short[] array4 = new short[num12];
				for (i = 0; i < num12; i++)
				{
					array4[i] = (short)(BitConverter.ToInt16(array2, num14 + i * 4) * 10);
				}
				i = num14 + num12 * 4;
				ISORead.BuildString(array2, 0, num14, ascii: true, nozero: false);
				int ind = BitConverter.ToInt16(array2, i);
				int num13 = BitConverter.ToInt16(array2, i + 2);
				if (ind != 1)
				{
					return array;
				}
				num = 0;
				num2 = 0;
				num3 = (num13 + num13 * num12) * 4;
				array2 = new byte[num3];
				while ((num3 > 0) & !flag)
				{
					num = fileStream.Read(array2, num2, num3);
					flag = num <= 0;
					num3 -= num;
					num2 += num;
				}
				if (flag)
				{
					return array;
				}
				short[] array5 = new short[num13];
				for (i = 0; i < num13; i++)
				{
					array5[i] = BitConverter.ToInt16(array2, i * 4);
				}
				double[] array7 = new double[num12 * num13];
				for (i = 0; i < array7.Length; i++)
				{
					array7[i] = BitConverter.ToInt32(array2, (num13 + i) * 4);
				}
				IMap.ConvertPcmd(array4, array5, array7, ind);
				oneTrim = true;
				while (true)
				{
					num = 0;
					num2 = 0;
					num3 = 20;
					array2 = new byte[num3];
					while ((num3 > 0) & !flag)
					{
						num = fileStream.Read(array2, num2, num3);
						flag = num <= 0;
						num3 -= num;
						num2 += num;
					}
					if (flag)
					{
						return array;
					}
					ind = BitConverter.ToInt16(array2, 0);
					num13 = BitConverter.ToInt16(array2, 2);
					if ((byte)ind != 1)
					{
						break;
					}
					num = 0;
					num2 = 0;
					oneTrim = false;
					num3 = (num13 + num13 * num12) * 4;
					array2 = new byte[num3];
					while ((num3 > 0) & !flag)
					{
						num = fileStream.Read(array2, num2, num3);
						flag = num <= 0;
						num3 -= num;
						num2 += num;
					}
					if (flag)
					{
						return array;
					}
					array5 = new short[num13];
					for (i = 0; i < num13; i++)
					{
						array5[i] = BitConverter.ToInt16(array2, i * 4);
					}
					array7 = new double[num12 * num13];
					for (i = 0; i < array7.Length; i++)
					{
						array7[i] = BitConverter.ToInt32(array2, (num13 + i) * 4);
					}
					IMap.ConvertPcmd(array4, array5, array7, ind);
				}
			}
			checkMapTrim(blank: false);
			infoMod = true;
			xTrim = 0;
			if (eTrim == 0)
			{
				updateTrim();
			}
			MapSelected(tagMap);
		}
		finally
		{
			fileStream.Close();
			if (flag)
			{
				array[0] = byte.MaxValue;
			}
		}
		return array;
	}

	private void OpenPCIIIFile(string pcName)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			byte[] array = readPCFile(pcName);
			if (array.Length == 1)
			{
				switch ((int)array[0])
				{
				case 254:
					DisplayBox("", LangUI[mLang, 243], 3);
					break;
				case 255:
					DisplayBox("", LangUI[mLang, 244], 3);
					break;
				case 0:
					DisplayBox("", LangUI[mLang, 245], 3);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			DisplayBox("", ex.Message.ToString(), 3);
		}
	}

	private void fileClosing()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		if ((IMap.checkMapModif() | infoMod | !unSave) & !noMap)
		{
			string msg = formatText(LangUI[mLang, 225] + lastFile + LangUI[mLang, 226], LangUI[mLang, 227], 14, 528);
			if ((int)DisplayBox("", msg, 7) == 1)
			{
				saveMenuItem_Click(null, null);
			}
		}
		eSave = false;
	}

	private string formatText(string textF, string textS, int trunc, int width)
	{
		Graphics val = ((Control)this).CreateGraphics();
		StringBuilder stringBuilder = new StringBuilder(textF);
		StringBuilder stringBuilder2 = new StringBuilder(textS);
		SizeF sizeF = val.MeasureString(stringBuilder.ToString(), IDraw.tFont);
		if (width > 0)
		{
			if (sizeF.Width > (float)width)
			{
				stringBuilder.Insert(trunc, "…");
			}
			while (sizeF.Width > (float)width)
			{
				stringBuilder.Remove(trunc + 1, 2);
				sizeF = val.MeasureString(stringBuilder.ToString(), IDraw.tFont);
			}
		}
		return stringBuilder.ToString() + stringBuilder2.ToString();
	}

	private string cutString(string str, int width)
	{
		if (str == null)
		{
			return "";
		}
		Graphics val = ((Control)this).CreateGraphics();
		SizeF sizeF = default(SizeF);
		StringBuilder stringBuilder = new StringBuilder(str);
		sizeF = val.MeasureString(stringBuilder.ToString(), IDraw.tbFont);
		int num = str.IndexOf(' ');
		if (sizeF.Width > (float)width)
		{
			stringBuilder.Insert(num + 1, "…");
		}
		while (sizeF.Width > (float)width)
		{
			stringBuilder.Remove(num + 2, 2);
			sizeF = val.MeasureString(stringBuilder.ToString(), IDraw.tbFont);
		}
		return stringBuilder.ToString();
	}

	private void UpgradeEnabled(mOpenFileDialog sender, bool save)
	{
		try
		{
			if (!save)
			{
				((FileDialog)sender.OpenDialog).AutoUpgradeEnabled = false;
			}
			else
			{
				((FileDialog)sender.SaveDialog).AutoUpgradeEnabled = false;
			}
		}
		catch
		{
			throw;
		}
	}

	public void openMenuItem_Click(object sender, EventArgs e)
	{
		if (e != null)
		{
			SaveGridTable();
			fileClosing();
		}
		toHide = true;
		string text = "";
		typInfo = 0;
		notry = false;
		mOpenFileDialog mOpenFileDialog2 = new mOpenFileDialog();
		try
		{
			((FileDialog)mOpenFileDialog2.OpenDialog).Title = LangUI[mLang, 228];
			((FileDialog)mOpenFileDialog2.OpenDialog).DefaultExt = "hex";
			((FileDialog)mOpenFileDialog2.OpenDialog).Filter = "(*.hex)|*.hex";
			((FileDialog)mOpenFileDialog2.OpenDialog).InitialDirectory = "";
			if (oSys > 5)
			{
				UpgradeEnabled(mOpenFileDialog2, save: false);
			}
			mOpenFileDialog2.StartLocation = AddonWindowLocation.Bottom;
			text = mOpenFileDialog2.ShowOpenDialog((IWin32Window)(object)this);
			if (!((text == "") & (e != null)))
			{
				if (text != "")
				{
					OpenSelectFile(text);
				}
				else if ((lastFile != "") & (lastFile != null) & (swMode == 0))
				{
					OpenSelectFile(lastFile);
				}
			}
		}
		finally
		{
			((Component)(object)mOpenFileDialog2).Dispose();
			toHide = false;
		}
	}

	public void openCompareMenu_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		cmpName = "";
		typInfo = 0;
		toHide = true;
		showMod = false;
		compareF = false;
		IMap.mcRPM = IMap.mRPM;
		IMap.icRPM = IMap.iRPM;
		Array.Copy(IMap.paramIndex, 0, IMap.paramIndex, 16, 16);
		compareMenuItem.Checked = false;
		mOpenFileDialog mOpenFileDialog2 = new mOpenFileDialog();
		((FileDialog)mOpenFileDialog2.OpenDialog).Title = LangUI[mLang, 246];
		((FileDialog)mOpenFileDialog2.OpenDialog).DefaultExt = "hex";
		((FileDialog)mOpenFileDialog2.OpenDialog).Filter = "(*.hex)|*.hex";
		((FileDialog)mOpenFileDialog2.OpenDialog).InitialDirectory = "";
		if (oSys > 5)
		{
			UpgradeEnabled(mOpenFileDialog2, save: false);
		}
		mOpenFileDialog2.StartLocation = AddonWindowLocation.Bottom;
		cmpName = mOpenFileDialog2.ShowOpenDialog((IWin32Window)(object)this);
		if (cmpName != "")
		{
			compareF = OpenCompareFile(cmpName);
		}
		else
		{
			showMod = false;
			swapMap();
		}
		if ((swMode == 0) & (((ptrMap[iTable[iTag]] & 0x70) != 32) | showMod))
		{
			MapSelected(tagMap);
		}
		compareMenuItem.Checked = compareF;
		menuItemEnabled(swMode == 0);
		((Component)(object)mOpenFileDialog2).Dispose();
		toHide = false;
	}

	private void saveMenuItem_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		string text = "";
		toHide = true;
		mOpenFileDialog mOpenFileDialog2 = new mOpenFileDialog();
		((FileDialog)mOpenFileDialog2.SaveDialog).Title = LangUI[mLang, 229];
		((FileDialog)mOpenFileDialog2.SaveDialog).DefaultExt = "hex";
		((FileDialog)mOpenFileDialog2.SaveDialog).InitialDirectory = "";
		((FileDialog)mOpenFileDialog2.SaveDialog).FileName = mapName;
		((FileDialog)mOpenFileDialog2.SaveDialog).Filter = "(*.hex)|*.hex";
		if (oSys > 5)
		{
			UpgradeEnabled(mOpenFileDialog2, save: true);
		}
		mOpenFileDialog2.StartLocation = AddonWindowLocation.None;
		text = mOpenFileDialog2.ShowSaveDialog((IWin32Window)(object)this);
		if (text != "")
		{
			saveMapFile(text);
		}
		((Component)(object)mOpenFileDialog2).Dispose();
		toHide = false;
	}

	private void saveBinMenuItem_Click(object sender, EventArgs e)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		SaveGridTable();
		((FileDialog)saveFileDialog).Title = LangUI[mLang, 229];
		((FileDialog)saveFileDialog).DefaultExt = "bin";
		((FileDialog)saveFileDialog).InitialDirectory = "";
		((FileDialog)saveFileDialog).FileName = idMap;
		((FileDialog)saveFileDialog).Filter = "(*.bin)|*.bin";
		((FileDialog)openFileDialog).FilterIndex = 1;
		if ((int)((CommonDialog)saveFileDialog).ShowDialog((IWin32Window)(object)this) != 1)
		{
			return;
		}
		byte[] memoMap = IMap.memoMap;
		string fileName = ((FileDialog)saveFileDialog).FileName;
		FileStream fileStream = openWriteFile(fileName);
		if (fileStream != null)
		{
			if (TypTable < 16)
			{
				IMap.MapChecksum(0, apply: true);
				int length = 131072;
				WriteStream(fileStream, memoMap, 524288, length);
			}
			else
			{
				int num = (IMap.mapTable[0] & 0xF0) << 12;
				int num2 = IMap.mapTable[0] & 0xF0000;
				int length = num2 - num + 524288;
				int num3 = IMap.MapChecksum(num, apply: true);
				memoMap[length - 2] = (byte)(num3 >> 8);
				memoMap[length - 1] = (byte)(num3 & 0xFF);
				WriteStream(fileStream, memoMap, 0, num);
				WriteStream(fileStream, memoMap, 524288, num2 - num);
			}
			closeStream(fileStream);
		}
	}

	public void openPCIIIMenu_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		string text = "";
		typInfo = 1;
		toHide = true;
		mOpenFileDialog mOpenFileDialog2 = new mOpenFileDialog();
		((FileDialog)mOpenFileDialog2.OpenDialog).Title = LangUI[mLang, 242];
		((FileDialog)mOpenFileDialog2.OpenDialog).DefaultExt = "";
		((FileDialog)mOpenFileDialog2.OpenDialog).Filter = ((pcType == 0) ? "(*.djm)|*.djm|(*.pvm)|*.pvm" : "(*.pvm)|*.pvm|(*.djm)|*.djm");
		((FileDialog)mOpenFileDialog2.OpenDialog).InitialDirectory = "";
		if (oSys > 5)
		{
			UpgradeEnabled(mOpenFileDialog2, save: false);
		}
		mOpenFileDialog2.StartLocation = AddonWindowLocation.Bottom;
		text = mOpenFileDialog2.ShowOpenDialog((IWin32Window)(object)this);
		if (text != "")
		{
			OpenPCIIIFile(text);
		}
		toHide = false;
	}

	private void fusionMenuItem_Paint(object sender, PaintEventArgs e)
	{
		if ((ptrMap[iTable[iTag]] & 0x70) == 32)
		{
			if (((Control)editUpDown).Visible)
			{
				unselectLabel(1);
			}
			SaveGridTable();
			eTable = null;
			if (!compareF & !showMod)
			{
				checkMapTrim(blank: false);
			}
			else
			{
				checkCmpTrim();
			}
		}
	}

	private void copyMenuItem_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		MapClip = new double[644];
		int num = ptrMap[iTable[iTag]];
		MapClip[0] = rpmMap * 10 + Tune.idPC;
		MapClip[1] = num;
		IMap.CopyMap(MapClip, num);
		((ToolStripItem)pasteMenuItem).Enabled = !showMod;
		mPaste = true;
	}

	private void pasteMenuItem_Click(object sender, EventArgs e)
	{
		unselectLabel(0);
		IMap.PasteMap(MapClip, ptrMap[tagMap]);
		MapSelected(tagMap);
	}

	private void exportMenuItem_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		string text = "";
		string text2 = tvMap.Nodes[0].Nodes[iTag].Text;
		int num = text2.IndexOf("/");
		if (num >= 0)
		{
			text2 = text2.Replace("/", "-");
		}
		toHide = true;
		mOpenFileDialog mOpenFileDialog2 = new mOpenFileDialog();
		((FileDialog)mOpenFileDialog2.SaveDialog).Title = LangUI[mLang, 229];
		((FileDialog)mOpenFileDialog2.SaveDialog).DefaultExt = "txt";
		((FileDialog)mOpenFileDialog2.SaveDialog).InitialDirectory = "";
		((FileDialog)mOpenFileDialog2.SaveDialog).FileName = text2;
		((FileDialog)mOpenFileDialog2.SaveDialog).Filter = "(*.txt)|*.txt";
		if (oSys > 5)
		{
			UpgradeEnabled(mOpenFileDialog2, save: true);
		}
		mOpenFileDialog2.StartLocation = AddonWindowLocation.None;
		text = mOpenFileDialog2.ShowSaveDialog((IWin32Window)(object)this);
		if (text != "")
		{
			WriteTxtFile(text);
		}
		toHide = false;
	}

	private void useTrimMenuItem_Click(object sender, EventArgs e)
	{
		oneTrim = !oneTrim;
		xTrim = 0;
		if (ptrMap[tagMap] != 32)
		{
			updateTrim();
		}
		if (eTrim == 0)
		{
			SaveGridTable();
			MapSelected(tagMap);
			if (!oneTrim)
			{
				selectTrim(-1);
			}
		}
		checkMapTrim(blank: false);
	}

	private void TrimToLMenuItem_Click(object sender, EventArgs e)
	{
		TrimToLMenuItem.Checked = !TrimToLMenuItem.Checked;
	}

	private void fusionMenuItem_Click(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)DisplayBox("", LangUI[mLang, 342], 8) == 1)
		{
			int length = 12292;
			int addr = (IMap.mapTable[0] & 0xF0) << 12;
			IMap.ApplyTrims(addr, TypTable);
			Array.Clear(MapTrim, 0, length);
			((ToolStripItem)fusionMenuItem).Enabled = false;
			MapSelected(tagMap);
		}
	}

	private void clearLogItem()
	{
		sbLog = new StringBuilder("");
		((TextBoxBase)logForm.rtbLog).Clear();
	}

	public static void clearLog()
	{
		me.clearLogItem();
	}

	private void graphMenuItem_Click(object sender, EventArgs e)
	{
		if (((Control)menuStrip).Enabled & !editCurve)
		{
			showGraph = !showGraph;
			graphMenuItem.Checked = showGraph;
			if (lbSelect)
			{
				unselectLabel(1);
			}
			if (showGraph)
			{
				((Control)panelTable).ContextMenuStrip = null;
			}
			int num = (showGraph ? 64 : 160);
			((Control)panelTable).BackColor = Color.FromArgb(num, num, num);
		}
	}

	private void viewInfosMap_Click(object sender, EventArgs e)
	{
		if (!((Control)infoForm).Visible)
		{
			infoForm = new Infos();
			((Control)infoForm.rtbInfos).Text = descMap;
			((TextBoxBase)infoForm.rtbInfos).SelectionStart = ((TextBoxBase)infoForm.rtbInfos).TextLength;
			infoForm.mShow.Checked = InfoTop;
			((Control)infoForm).Show();
			showInfo = true;
		}
		else
		{
			((Control)infoForm).Hide();
		}
	}

	private void fullScreenMenuItem_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Form)this).WindowState == 0)
		{
			((Form)this).WindowState = (FormWindowState)2;
		}
		else
		{
			((Form)this).WindowState = (FormWindowState)0;
		}
	}

	private void viewLog_Click(object sender, EventArgs e)
	{
		if (!((Control)logForm).Visible)
		{
			logForm = new Logs();
			((TextBoxBase)logForm.rtbLog).AppendText(sbLog.ToString());
			logForm.mShow.Checked = LogTop;
			((Control)logForm).Show();
			showLog = true;
		}
		else
		{
			((Control)logForm).Hide();
		}
	}

	private void listCodes_DrawItem(object sender, DrawItemEventArgs e)
	{
		if ((e.Index >= 0) & (e.Bounds.Y == 0))
		{
			string text = listCodes.Items[e.Index].ToString();
			IDraw.PaintListCodes(text, e);
			ISORead.GetDescription(text);
		}
	}

	public static void listCodesAddItems(string items)
	{
		if (me.listCodes.Items.IndexOf((object)items) == -1)
		{
			me.listCodes.Items.Add((object)items);
		}
		if (((ListControl)me.listCodes).SelectedIndex == -1)
		{
			((Control)me.listCodes).Enabled = true;
			((ListControl)me.listCodes).SelectedIndex = 0;
			((Control)me.listCodes).Focus();
			((ToolStripItem)me.eraseCodesMenuItem).Enabled = true;
		}
	}

	public static void listCodesClear()
	{
		me.listCodes.Items.Clear();
		((Control)me.listCodes).Enabled = false;
		((TextBoxBase)me.tbDescription).Clear();
		((ToolStripItem)me.eraseCodesMenuItem).Enabled = false;
	}

	public static void listCodesUpdate(string msg, bool status)
	{
		if (ISORead.readCodes + ISORead.clearCodes <= 0)
		{
			listCodesClear();
			DisplayMsg(msg, 48);
			refreshCode = ((!status) ? 10 : 0);
			if (status)
			{
				ISORead.readCodes = ((!(_LC4 & _2nECU)) ? 1 : 2);
			}
		}
	}

	private void connectMenuItem_Click(object sender, EventArgs e)
	{
		notryCnx = false;
		QConnect = 1;
		dConnect = mConnect;
		comFailed = false;
		serialItemsEnable(en: false);
		USBItemsEnable(en: false);
	}

	public void QueryConnect()
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Invalid comparison between Unknown and I4
		infosConnect(0);
		int selectedIndex = ((ListControl)cmbPortName).SelectedIndex;
		int selectedIndex2 = ((ListControl)lbDevList).SelectedIndex;
		((ToolStripItem)connectMenuItem).Enabled = false;
		ISOFT.rSafe = 0;
		ISORead.mFlash = false;
		ISORead.mLoad = false;
		ISORead.reLoad = false;
		testTick = 0;
		ISORead.SwitchMode(eMode.MODE_NULL);
		if (mConnect)
		{
			if (EXBVReset | ISCVReset)
			{
				endTest(rst: true);
			}
			if (swMode != 0)
			{
				((ToolStripItem)fileStatus).Text = "";
			}
			mConnect = false;
			if (serialMode)
			{
				ISOFT.closeSerialPort(wait: true);
			}
			else
			{
				ISOFT.FTDClose(wait: true);
			}
			listCodesClear();
			((ToolStripItem)connectMenuItem).Text = LangUI[mLang, 18];
			USBLed(0);
		}
		else if (serialMode & !comFailed)
		{
			if (ISOFT.openSerialPort(38400))
			{
				mConnect = true;
				((ToolStripItem)connectMenuItem).Text = LangUI[mLang, 25];
				ISORead.dataClear(68);
				ISOFT.SetflagOut(9);
			}
			else
			{
				DisplayBox("", LangUI[mLang, 340] + ((Control)cmbPortName).Text, 2);
				comFailed = true;
			}
		}
		else if (selectedIndex2 != -1)
		{
			if (ISOFT.FTDOpen((uint)selectedIndex2, 10400u))
			{
				mConnect = true;
				((ToolStripItem)connectMenuItem).Text = LangUI[mLang, 25];
				ISORead.dataClear(68);
				if (sRecovery & (swMode == 0) & (TypTable > 0))
				{
					if (ISORead.mSafe)
					{
						safeMenuItem_Click(null, null);
					}
					else if ((int)DisplayBox("", LangUI[mLang, 221], 9) == 1)
					{
						safeMenuItem_Click(null, null);
					}
					else
					{
						sRecovery = false;
					}
				}
				else
				{
					ISOFT.SetflagOut(9);
				}
			}
			else
			{
				string text = ((Control)lbDevList).Text;
				DisplayBox("", LangUI[mLang, 340] + text.Substring(0, text.IndexOf("\0")), 2);
			}
		}
		((ToolStripItem)connectMenuItem).Enabled = (selectedIndex2 != -1) | (selectedIndex != -1);
		serialItemsEnable(!mConnect);
		USBItemsEnable(!mConnect);
	}

	private static void serialItemsEnable(bool en)
	{
		for (int i = 0; i < m_serial.Length; i++)
		{
			((ToolStripItem)m_serial[i]).Enabled = en;
		}
	}

	private static void USBItemsEnable(bool en)
	{
		for (int i = 0; i < m_USB.Length; i++)
		{
			((ToolStripItem)m_USB[i]).Enabled = en;
		}
	}

	public static void UploadDone()
	{
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Invalid comparison between Unknown and I4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		if (ISORead.readBuffer == null)
		{
			byte[] memoMap = IMap.memoMap;
			if (!ISORead.aRead & (me.Mapbuffer != null))
			{
				int num = (IMap.mapTable[0] & 0xFF) << 12;
				int num2 = (IMap.mapTable[0] & 0xFF000) - num;
				for (int i = 0; i < num2; i++)
				{
					memoMap[num + i] = memoMap[(num & 0xFFFF) + i + 524288];
				}
				compareF = true;
				cmpFile = lastFile;
			}
			else
			{
				compareF = false;
				IMap.mcRPM = IMap.mRPM;
				IMap.icRPM = IMap.iRPM;
			}
			showMod = false;
			unSave = false;
			string text = ISORead.dataSensor[ISORead.qDST * 20 + 65];
			lastFile = text + "Map";
			int num3 = 12292;
			MapTrim = new byte[num3];
			me.compareMenuItem.Checked = compareF;
			int num4 = (int)Tune.mType[IMap.TypMap * 8 + 4];
			idMap = text;
			if (num4 < 80)
			{
				descMap = IMap.GetInfosMap(idMap, num4);
			}
			else
			{
				descMap = IMap.GetInfosMap(idMap.Substring(2), num4);
			}
			if (wRef > 0)
			{
				tmMap[27] = (byte)wRef;
			}
			if (ISORead.aRead)
			{
				IMap.BuildMemoryMap(tmMap);
				me.tvMap_Setup();
				me.AfterOpenMap();
			}
			else
			{
				Array.Copy(tmMap, 4, IMap.mHeader, 4, 16);
				if (TypTable < 16)
				{
					IMap.SetSagemTable(IMap.TypMap, cMap: false);
				}
				else if (TypTable > 2048)
				{
					IMap.SetWalbroTable(IMap.TypMap, cMap: false);
				}
				else
				{
					IMap.SetKeihinTable(IMap.TypMap, cMap: false);
				}
				if (compareF)
				{
					IMap.MakeCompareMap(me.Mapbuffer);
				}
				me.displayParams(-1, -1);
				me.MapSelected(tagMap);
			}
			mapName = lastFile;
			DisplayMsg(idMap, 128);
			DisplayMsg(me.cutString(lastFile, ((ToolStripItem)me.fileStatus).Width - 8), 64);
			DisplayBox("", LangUI[mLang, 230], 1);
			return;
		}
		if (rDump)
		{
			ISORead.mLoad = false;
			notryCnx = false;
			QConnect = 1;
			dConnect = mConnect;
			comFailed = false;
			string filePath = "Dump" + ISORead.dataSensor[65] + ".dat";
			FileStream fileStream = openWriteFile(filePath);
			if (fileStream != null)
			{
				WriteStream(fileStream, IMap.memoMap, 0, 131072);
				closeStream(fileStream);
			}
			DisplayBox("", LangUI[mLang, 230], 1);
			return;
		}
		short num5;
		for (num5 = 0; num5 < 128; num5++)
		{
			short num6 = (short)((histMemo[num5 * 32 + 18] << 8) | histMemo[num5 * 32 + 19]);
			if (num6 != -1)
			{
				int id = (histMemo[num5 * 32 + 5] << 16) | (histMemo[num5 * 32 + 6] << 8) | histMemo[num5 * 32 + 7];
				int num7 = (histMemo[num5 * 32 + 8] << 8) | histMemo[num5 * 32 + 9];
				int num8 = (histMemo[num5 * 32 + 13] << 16) | (histMemo[num5 * 32 + 14] << 8) | histMemo[num5 * 32 + 15];
				int num9 = ISORead.IDSagem(id);
				string text2 = ((num9 <= 0) ? "????  " : $"{num9:x}");
				string text3 = $"{num8:x}";
				DisplayMsg(num6 + " - " + LangUI[mLang, 67] + " " + text2 + " (" + text3 + "), " + LangUI[mLang, 70] + num7.ToString("X2") + "\r", 32);
			}
		}
		if (num5 == 0)
		{
			DisplayMsg(num5 + "\r", 32);
		}
		if (!showLog && (int)DisplayBox("", LangUI[mLang, 218], 7) == 1)
		{
			me.viewLog_Click(null, null);
		}
	}

	private void historyMenuItem_Click(object sender, EventArgs e)
	{
		DisplayMsg(LangUI[mLang, 44], 32);
		if (histMemo == null)
		{
			int num = 8192;
			sBloc = 32;
			histMemo = new byte[num];
			btnFlashEnabled(mode: false);
			((Control)menuStrip).Enabled = false;
			((Control)this).Cursor = Cursors.WaitCursor;
			((Control)tvMap).Enabled = false;
			((Control)panelTable).Enabled = false;
			ISORead.aRead = false;
			ISORead.SetReadData(histMemo, 16384, num);
		}
	}

	private void readMapMenuItem_Click(object sender, EventArgs e)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		SaveGridTable();
		fileClosing();
		string text = ISORead.dataSensor[65] + ((_Apri | _Bene | _Walbro) ? "" : (" (" + ISORead.baseMap + ")"));
		toHide = true;
		queryBox = new QueryForm();
		QueryForm.boxMode = 0;
		((Control)queryBox.radioMap1).Text = text;
		if ((int)((Form)queryBox).ShowDialog() != 1)
		{
			toHide = false;
			return;
		}
		int num = 0;
		int id = ((ISORead.qDST == 0) ? ISORead.ECUTyp : ISORead.ECUTyp2);
		tmMap = ((ISORead.qDST == 0) ? ISORead.csMap : ISORead.csMap2);
		toHide = false;
		rDump = false;
		if ((IMap.CheckMapID(id, 1) & 0xFFFF) < 0)
		{
			IMap.TypMap = -1;
			DisplayBox("", LangUI[mLang, 317], 3);
			return;
		}
		WriteTrcFile(tmMap, 20, 4, "Map ID : ");
		IMap.TypMap = IMap.identifyMap(tmMap, 20, 1);
		if (IMap.TypMap < 0)
		{
			DisplayBox("", LangUI[mLang, 224], 3);
			if ((ISORead.ECUTyp & 0xFFFEF9) != 16384)
			{
				return;
			}
			rDump = true;
		}
		eTable = null;
		btnFlashEnabled(mode: false);
		((Control)menuStrip).Enabled = false;
		((Control)this).Cursor = Cursors.WaitCursor;
		((Control)tvMap).Enabled = false;
		((Control)panelTable).Enabled = false;
		if (!noMap & !_Walbro)
		{
			ISORead.aRead = BitConverter.ToInt32(tmMap, 20) != BitConverter.ToInt32(IMap.mHeader, 20);
		}
		else
		{
			ISORead.aRead = true;
		}
		if (!noMap & ISORead.aRead)
		{
			TypTable = -1;
			AfterOpenMap();
		}
		sBloc = (KWP ? 128 : 32);
		int num2;
		if (rDump)
		{
			IMap.flashTable = new int[2];
			num = 0;
			num2 = 131072;
			IMap.flashTable[0] = num;
			IMap.flashTable[1] = num2;
			IMap.flashSize = num2;
			ISORead.aRead = true;
		}
		else
		{
			num = (IMap.getAddr(IMap.TypMap, 0) & 0xFF) << 12;
			IMap.SetFlashTable((int)Tune.mType[IMap.TypMap * 8 + 4], num, ISORead.aRead);
		}
		num2 = IMap.flashSize;
		if (ISORead.aRead)
		{
			if (IMap.memoMap == null)
			{
				IMap.memoMap = new byte[IMap.memoSize];
			}
			IMap.umodMap = null;
			for (int i = 0; i < IMap.memoSize; i++)
			{
				IMap.memoMap[i] = byte.MaxValue;
			}
		}
		((Control)Logo_Panel).Invalidate();
		ISORead.SetReadData(null, 0, num2);
		((Control)panelTable).Invalidate();
	}

	public void readUnkownMap(string sMap)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		SaveGridTable();
		fileClosing();
		toHide = true;
		queryBox = new QueryForm();
		QueryForm.boxMode = 0;
		((Control)queryBox.radioMap1).Text = sMap;
		if ((int)((Form)queryBox).ShowDialog() != 1)
		{
			toHide = false;
			return;
		}
		rDump = true;
		eTable = null;
		btnFlashEnabled(mode: false);
		((Control)menuStrip).Enabled = false;
		((Control)this).Cursor = Cursors.WaitCursor;
		((Control)tvMap).Enabled = false;
		((Control)panelTable).Enabled = false;
		ISORead.aRead = true;
		if (!noMap)
		{
			TypTable = -1;
			AfterOpenMap();
		}
		sBloc = (KWP ? 128 : 32);
		IMap.flashTable = new int[2];
		int num = 0;
		int num2 = 131072;
		IMap.flashTable[0] = num;
		IMap.flashTable[1] = num2;
		IMap.flashSize = num2;
		if (IMap.memoMap == null)
		{
			IMap.memoMap = new byte[IMap.memoSize];
		}
		IMap.umodMap = null;
		for (int i = 0; i < IMap.memoSize; i++)
		{
			IMap.memoMap[i] = byte.MaxValue;
		}
		((Control)Logo_Panel).Invalidate();
		ISORead.SetReadData(null, 0, num2);
		((Control)panelTable).Invalidate();
	}

	private void flashMenuItem_Click(object sender, EventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		if (sender != null)
		{
			SaveGridTable();
		}
		if ((int)DisplayBox(LangUI[mLang, 67] + idMap, LangUI[mLang, 343], 10) == 1)
		{
			int.TryParse(GetHKCUkey("Software\\TuneECU", "Properties", "Debug", null), out mDebug);
			((ToolStripItem)loopStatus).Enabled = false;
			((ToolStripItem)tpsStatus).Enabled = false;
			((ToolStripItem)me.loopStatus).ToolTipText = "";
			((ToolStripItem)me.tpsStatus).ToolTipText = "";
			ISORead.FlashIt(mode: false);
		}
	}

	public void safeMenuItem_Click(object sender, EventArgs e)
	{
		sagemECU = TypTable < 16;
		DisplayMsg("", 96);
		ISORead.FlashIt(mode: true);
	}

	private void razTPSMenuItem_Click(object sender, EventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		if ((int)DisplayBox("", LangUI[mLang, sagemECU ? 276 : 304], 7) != 2)
		{
			DisplayMsg(LangUI[mLang, sagemECU ? 231 : 279], 32);
			DisplayMsg("0", 320);
			btnTest = 11;
			ISORead.mTest = 0;
			ISORead.StartDiagRoutine(btnTest, 0);
		}
	}

	private void eraseCodesMenuItem_Click(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)DisplayBox("", LangUI[mLang, 234], 8) == 1)
		{
			ISORead.clearCodes = ((!(_LC4 & _2nECU)) ? 1 : 2);
		}
	}

	private void flashItemEnabled()
	{
		bool flag = (ISORead.mMode == eMode.MODE_READ_SENSORS) | (ISORead.mMode == eMode.MODE_WALBRO_SENSORS);
		((ToolStripItem)flashMenuItem).Enabled = FlashEnable() & unSave & Tune.avProg & flag;
		((ToolStripItem)me.readMapMenuItem).Enabled = (swMode == 0) & (me.sRun == 0) & flag;
		((ToolStripItem)me.historyMenuItem).Enabled = ((ToolStripItem)me.readMapMenuItem).Enabled & sagemECU;
		if (((ToolStripItem)flashMenuItem).Enabled)
		{
			flashTempo = 2;
		}
		else
		{
			btnFlashEnabled(mode: false);
		}
	}

	public static bool FlashEnable()
	{
		me.sRun = me.mRun;
		bool flag = !(((TypTable < 8) ^ (sagemECU & !_Apri & !_Bene)) | (((TypTable >= 8) & (TypTable <= 12)) ^ _Apri) | (((TypTable & 0xFFFE) == 14) ^ _Bene) | (((TypTable >= 80) & (TypTable < 2048)) ^ _KTM) | ((((TypTable & 0xFFF0) == 112) | ((TypTable & 0xFFF0) == 1024)) ^ (_LC4 | _2nECU)) | (((TypTable & 0xFFE0) == 2048) ^ _Walbro)) & (TypTable > 0) & (swMode == 0);
		return flag & (me.sRun == 0);
	}

	public static void enableMenuItems(eMode mode, int count)
	{
		bool flag = swMode == 0;
		bool flag2 = !(ISORead.mFlash | ISORead.mLoad);
		((Control)me.menuStrip).Enabled = flag2;
		((ToolStripItem)me.fullScreenMenuItem).Enabled = ((Form)me).MaximizeBox;
		me.fullScreenMenuItem.Checked = wState;
		((Control)me).Cursor = ((flag2 & (iStart < 0)) ? Cursors.Default : Cursors.WaitCursor);
		((Control)me.tvMap).Enabled = (TypTable > -1) & flag2;
		((Control)me.panelTable).Enabled = flag2;
		((Control)me.BtnLeft).Enabled = flag2;
		((Control)me.BtnMid).Enabled = flag2;
		((Control)me.BtnRight).Enabled = flag2;
		((ToolStripItem)me.openMenuItem).Enabled = flag;
		((ToolStripItem)me.compareMenuItem).Enabled = flag & !noMap;
		if (!flag)
		{
			((ToolStripItem)me.exportMenuItem).Enabled = false;
		}
		me.flashItemEnabled();
		((ToolStripItem)me.safeMenuItem).Enabled = FlashEnable() & mConnect & (count > 3);
		((ToolStripItem)me.razTPSMenuItem).Enabled = ((ToolStripItem)me.flashMenuItem).Enabled & !sagemECU & !_KTM & !_Walbro;
		if (!mConnect | (mode != eMode.MODE_READ_SENSORS))
		{
			((ToolStripItem)me.loopStatus).Enabled = false;
			((ToolStripItem)me.loopStatus).ToolTipText = "";
			((ToolStripItem)me.tpsStatus).Enabled = false;
			((ToolStripItem)me.tpsStatus).ToolTipText = "";
		}
		((ToolStripItem)me.battStatus).Enabled = !((mode == eMode.MODE_NULL) | (swMode == 1));
		if (TypTable < 0)
		{
			((ToolStripItem)me.exportMenuItem).Enabled = false;
		}
		((ToolStripItem)me.copyMenuItem).Enabled = (TypTable > -1) & flag;
		((ToolStripItem)me.graphMenuItem).Enabled = flag & !noMap;
		((ToolStripItem)me.eraseCodesMenuItem).Enabled = (((ListControl)me.listCodes).SelectedIndex > -1) & (((mode == eMode.MODE_READ_SENSORS) & !flag) | (((mode == eMode.MODE_WALBRO_SENSORS) | (mode == eMode.MODE_WALBRO_TPS)) & (swMode == 1)));
		me.tv_testEnabled((mode == eMode.MODE_READ_SENSORS) | (mode == eMode.MODE_WALBRO_TPS));
		me.menuItemEnabled(flag);
		if (mode != eMode.MODE_WALBRO_TPS)
		{
			eTag = 0;
		}
		eSens = (!(((TypTable < 8) ^ (sagemECU & !_Apri & !_Bene)) | (((TypTable >= 8) & (TypTable <= 12)) ^ _Apri) | (((TypTable & 0xFFFE) == 14) ^ _Bene) | (((TypTable & 0xFFE0) == 2048) ^ _Walbro) | (((TypTable >= 80) & (TypTable < 2048)) ^ _KTM)) & (TypTable > 0) & (ISORead.mMode == eMode.MODE_READ_SENSORS)) | (!(((TypTable & 0xFFE0) == 2048) ^ _Walbro) & (ISORead.mMode == eMode.MODE_WALBRO_SENSORS) & (swMode == 0));
		int num = mView;
		mView = (mView & ((mode == eMode.MODE_NULL) ? 63 : 127)) | (((mode == eMode.MODE_READ_SENSORS) | (mode == eMode.MODE_WALBRO_SENSORS) | (mode == eMode.MODE_WALBRO_TPS)) ? 64 : 0);
		if (mView != num)
		{
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
			((Control)me.pbDash).Invalidate();
		}
		if (((mode == eMode.MODE_READ_SENSORS) & (tDebug != -1)) && tDebug == 0)
		{
			tDebug = 90;
		}
	}

	private void menuItemEnabled(bool mode)
	{
		int num = Tune.idTrim % 100;
		int num2 = ((num > 0) ? ((int)me.tvMap.Nodes[0].Nodes[num - 1].Tag) : 0);
		bool flag = !(showMod & compareF) & mode & !noMap;
		((ToolStripItem)me.useTrimMenuItem).Enabled = flag & mode & (num * num2 > 1);
		me.useTrimMenuItem.Checked = oneTrim & mode & (num * num2 > 1);
		((ToolStripItem)me.fusionMenuItem).Enabled = (MapTrim[0] > 0) & mode & flag;
		((ToolStripItem)saveMenuItem).Enabled = flag;
		((ToolStripItem)PCIIIMenuItem).Enabled = flag & (Tune.idPC != 0);
		((ToolStripItem)pasteMenuItem).Enabled = mPaste & flag;
		((ToolStripItem)TrimToLMenuItem).Enabled = flag;
		((ToolStripItem)infosMapMenuItem).Enabled = flag;
	}

	private void autoMenuItem_Click(object sender, EventArgs e)
	{
		autoConnect = !autoConnect;
		autoMenuItem.Checked = autoConnect;
		mStart = autoConnect;
	}

	private void langMenuItem_Click(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		SaveGridTable();
		int.TryParse(((ToolStripItem)(ToolStripMenuItem)sender).Tag.ToString(), out mLang);
		UpdateUI();
	}

	private void aboutMenuItem_Click(object sender, EventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		toHide = true;
		aboutForm = new AboutBox();
		aboutForm.mSplash.Checked = showSplash;
		((Form)aboutForm).ShowDialog();
		toHide = false;
	}

	private void quitMenuItem_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		fileClosing();
		noMap = true;
		Application.Exit();
	}

	private void btnFlashEnabled(bool mode)
	{
		if ((swMode == 0) & ((ToolStripItem)me.flashMenuItem).Enabled & mode)
		{
			((Control)BtnLeft).Tag = 4;
		}
		else
		{
			((Control)BtnLeft).Tag = 0;
		}
		((Control)BtnLeft).Invalidate();
	}

	private void SetHKCUkey(string BaseKey, string KeyName, string Value)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(BaseKey, writable: true);
			registryKey.SetValue(KeyName, Value);
			registryKey.Close();
		}
		catch
		{
		}
	}

	private void DelHKCUkey(string BaseKey, string KeyName)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(BaseKey, writable: true);
			registryKey.DeleteValue(KeyName);
			registryKey.Close();
		}
		catch
		{
		}
	}

	private static string GetHKCUkey(string BaseKey, string SubKey, string KeyName, string def)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(BaseKey + "\\" + SubKey, writable: true);
			if ((registryKey == null) & (def != null))
			{
				registryKey = Registry.CurrentUser.CreateSubKey(BaseKey + "\\" + SubKey);
			}
			if (registryKey != null)
			{
				try
				{
					string result = registryKey.GetValue(KeyName).ToString();
					registryKey.Close();
					return result;
				}
				catch
				{
					registryKey.SetValue(KeyName, def);
					registryKey.Close();
					return def;
				}
			}
			return def;
		}
		catch
		{
			return def;
		}
	}

	private void tvMap_Setup()
	{
		TreeNode val = tvMap.Nodes[0];
		TreeNode val2 = tvMap.Nodes[1];
		if (iTag < 16)
		{
			val.Nodes[iTag].ImageIndex = -2;
		}
		else
		{
			iTag = 0;
		}
		string pc = ((TypTable > 80) ? idMap.Substring(2, 3) : "");
		if (Tune.tvMap_Define(pc, TypTable))
		{
			for (int i = 0; i < 16; i++)
			{
				val.Nodes[i].Name = Tune.node[i];
				val.Nodes[i].Text = Tune.node[i];
			}
			for (int i = 1; i < 16; i++)
			{
				val.Nodes[i].Tag = Tune.tagNode[i];
			}
		}
		else
		{
			val.Collapse();
			val2.Collapse();
			TypTable = -1;
		}
		iTable = Tune.mTable;
		((Control)tvMap).Enabled = TypTable > -1;
		tvMap.Nodes[1].Tag = ((Tune.prmLabel > 0) ? 8 : (-8));
		tvMap.Nodes[1].Text = (((int)tvMap.Nodes[1].Tag == 8) ? LangUI[mLang, 72] : "");
		tvMap.Nodes[2].Tag = ((Tune.devLabel > 0) ? 8 : (-8));
		tvMap.Nodes[2].Text = (((int)tvMap.Nodes[2].Tag == 8) ? LangUI[mLang, 138] : "");
		for (int i = 0; i < 6; i++)
		{
			ISORead.dataSensor[i + 68] = "";
			int num = (short)IMap.paramIndex[(Tune.prmIndex >> i * 4) & 0xF];
			val2.Nodes[i].Tag = 34 * ((num != -1) ? 1 : (-1));
			val2.Nodes[i].ContextMenuStrip = ((num != -1) ? cModifMenu : null);
		}
		UpdateNodes();
		epMap = (TypTable & 0xFFF0) == 1024;
		TrimToLMenuItem.Checked = false;
		_LTrim = (TypTable > 16) & (TypTable < 1024);
		((ToolStripItem)TrimToLMenuItem).Enabled = _LTrim;
		if (((Control)tvMap).Enabled)
		{
			tvMap.Nodes[0].Expand();
			tvMap.Nodes[exNode].Expand();
			displayParams(-1, -1);
			displayLOF(val);
			tagMap = iTable[0];
			ISOFT.rSafe = 0;
			if (tvMap.SelectedNode != val.Nodes[0])
			{
				tvMap.SelectedNode = val.Nodes[0];
			}
			MapSelected(tagMap);
			if (((int)tvMap.Nodes[2].Tag < 0) & ((int)tvMap.Nodes[1].Tag > 0))
			{
				tvMap.Nodes[1].Expand();
			}
			val.Nodes[iTag].ImageIndex = 2;
			if ((TypTable & 0xFFF0) != 1024)
			{
				tvMap.Nodes[0].Text = tvMap.Nodes[0].Name + "- " + tvMap.Nodes[0].Nodes[0].Text;
			}
			else
			{
				tvMap.Nodes[0].Text = LangUI[mLang, 73];
			}
			((Control)tvMap).Refresh();
		}
		if (!mConnect & (TypTable > 0))
		{
			_sagemF = (TypTable == 3) | (TypTable == 4) | (TypTable == 7);
			_Apri = (TypTable >= 8) & (TypTable <= 12);
			_Bene = (TypTable & 0xFFFE) == 14;
			_LC4 = (TypTable & 0xFFF0) == 112;
			_KTM = ((TypTable & 0xFF50) == 80) | ((TypTable & 0xFFF0) == 1024);
			_Twin = (TypTable & 0xFFF8) == 72;
			_2ndT = (TypTable & 0xFF78) == 64;
			_Four = (TypTable & 0xFF4E) == 70;
			_Flap = (TypTable & 0xFF28) == 40;
			_Walbro = (TypTable & 0xFFE0) == 2048;
			SetUInterface((TypTable >= 16) ? 1 : 0);
			RevCount = ((((TypTable & 0xFF30) == 32) | _Four | _sagemF) ? 1 : ((!(((TypTable & 0xFF50) == 64) | _LC4)) ? 2 : 0));
		}
		_Label_Invalidate();
	}

	private void displayLOF(TreeNode node)
	{
		if ((TypTable & 0xFF50) != 80)
		{
			return;
		}
		int num = (IMap.mapTable[0] & 0xFF) << 12;
		int num2 = (IMap.mapTable[38] & 0xF0000) >> 16;
		int num3 = IMap.memoMap[num + (IMap.mapTable[38] & 0xFFFF)];
		num3 = (num3 >> num2) & 1;
		for (num2 = 4; num2 < 11; num2++)
		{
			if ((int)node.Nodes[num2].Tag == -2)
			{
				node.Nodes[num2].Tag = ((num3 == 1) ? 1 : (-1));
			}
		}
	}

	public void displayParams(int prm, int dev)
	{
		int num = (showMod ? 16 : 0);
		TreeNode val = tvMap.Nodes[1];
		TreeNode val2 = tvMap.Nodes[2];
		int i = 0;
		if (prm >= 0)
		{
			for (; (i < 6) & (((Tune.prmIndex >> i * 4) & 0xF) != prm); i++)
			{
			}
			prm = ((i < 6) ? i : (-1));
		}
		int num2 = ((prm >= 0) ? prm : 0);
		int num3 = ((prm >= 0) ? (prm + 1) : 6);
		if (prm != -2)
		{
			for (i = num2; i < num3; i++)
			{
				int num4 = (Tune.prmIndex >> i * 4) & 0xF;
				if (!(((int)val.Nodes[i].Tag > 0) & (num4 < 8)))
				{
					continue;
				}
				val.Nodes[i].ImageIndex = 5;
				if (IMap.paramIndex[num + num4] != 65535)
				{
					if ((num4 == 2) | (num4 == 4))
					{
						UDInc = (decimal)IMap.paramIndex[num + num4] / 10m;
						ISORead.dataSensor[num4 + 68] = UDInc.ToString("#0.0");
					}
					else if (num4 == 5)
					{
						ISORead.dataSensor[num4 + 68] = (((IMap.paramIndex[num + num4] >> 5) & 0x1F) * 10).ToString();
					}
					else
					{
						ISORead.dataSensor[num4 + 68] = IMap.paramIndex[num + num4].ToString();
					}
				}
				else
				{
					ISORead.dataSensor[num4 + 68] = "";
				}
			}
		}
		i = 0;
		if (dev >= 0)
		{
			for (; (i < 6) & (((Tune.devIndex >> i * 4) & 0xF) != dev); i++)
			{
			}
			dev = ((i < 6) ? i : (-1));
		}
		num2 = ((dev >= 0) ? dev : 0);
		num3 = ((dev >= 0) ? (dev + 1) : 6);
		if (dev == -2)
		{
			return;
		}
		for (i = num2; i < num3; i++)
		{
			int num5 = (Tune.devIndex >> i * 4) & 0xF;
			int num6 = (Tune.devMask >> i) & 1;
			int num7 = (IMap.mapTable[num5 + 32] >> 16) & 0xF;
			int num8 = 1 << num7;
			int num4 = ((num5 == 0) ? (-1) : ((short)IMap.paramIndex[num + num5 + 7]));
			val2.Nodes[i].Tag = 4 * (((num4 != -1) & (num6 != 0)) ? 1 : (-1));
			val2.Nodes[i].ContextMenuStrip = (((num4 != -1) & (num6 != 0)) ? cActiveMenu : null);
			if (num5 > 0)
			{
				val2.Nodes[i].ImageIndex = (((num4 != -1) & ((IMap.paramIndex[num + num5 + 7] & num8) > 0)) ? 1 : 0);
			}
		}
	}

	private void MapSelected(int tag)
	{
		if (!((swMode < 0) | (TypTable < 0)))
		{
			bool enabled = false;
			int ptr = 0;
			typCopy = 0;
			string fString = "0";
			mCells = -1;
			editGraphOut();
			mPaste = false;
			((ToolStripItem)pasteMenuItem).Enabled = false;
			switch (ptrMap[tag] & 0x3F)
			{
			case 4:
				ptr = 8;
				typCopy = 1028;
				lhLabel = "";
				lvLabel = LangUI[mLang, 96];
				rowTPS = false;
				break;
			case 5:
				ptr = 5;
				typCopy = 1285;
				lhLabel = "";
				lvLabel = LangUI[mLang, 96];
				rowTPS = false;
				break;
			case 6:
				ptr = 6;
				typCopy = 1542;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.00";
				enabled = true;
				rowTPS = true;
				break;
			case 7:
				ptr = 7;
				typCopy = 1799;
				lhLabel = "";
				lvLabel = LangUI[mLang, 97];
				fString = "0.00";
				rowTPS = false;
				break;
			case 8:
				ptr = 8;
				typCopy = 2056;
				lhLabel = "";
				lvLabel = LangUI[mLang, 97];
				fString = "0.00";
				rowTPS = false;
				break;
			case 9:
			case 10:
				ptr = 0;
				typCopy = 2314;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = ((TypTable < 16) ? "0.0" : "0");
				enabled = true;
				rowTPS = true;
				break;
			case 11:
			case 12:
			case 13:
			case 14:
				ptr = 0;
				typCopy = 2830;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				enabled = true;
				rowTPS = true;
				break;
			case 15:
			case 16:
			case 17:
			case 18:
				ptr = 1;
				typCopy = 3858;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				enabled = true;
				rowTPS = true;
				break;
			case 19:
			case 20:
			case 21:
				ptr = 0;
				typCopy = (Tune._I4 ? 4886 : 4885);
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				enabled = true;
				rowTPS = true;
				break;
			case 22:
				ptr = ((!Tune._I4) ? 1 : 0);
				typCopy = (Tune._I4 ? 4886 : 5654);
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				enabled = true;
				rowTPS = true;
				break;
			case 23:
				ptr = 0;
				typCopy = 5911;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.00";
				enabled = true;
				rowTPS = true;
				break;
			case 24:
				ptr = 3;
				typCopy = 6168;
				lhLabel = "";
				lvLabel = LangUI[mLang, 95];
				rowTPS = false;
				break;
			case 25:
				ptr = 9;
				typCopy = 6425;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				enabled = true;
				rowTPS = true;
				break;
			case 26:
			case 27:
				ptr = 8;
				typCopy = 6683;
				lhLabel = "";
				lvLabel = LangUI[mLang, 98];
				fString = "0.0";
				rowTPS = false;
				break;
			case 28:
			case 29:
				ptr = 6;
				typCopy = 7197;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				enabled = true;
				rowTPS = true;
				break;
			case 30:
				ptr = 6;
				typCopy = 7710;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				enabled = true;
				rowTPS = true;
				break;
			case 31:
				ptr = 0;
				typCopy = 7967;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				enabled = true;
				rowTPS = true;
				break;
			case 32:
				ptr = 0;
				typCopy = 8224;
				dColor = -40.0;
				eColor = 1.25;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				rowTPS = true;
				break;
			case 36:
			case 37:
				ptr = 4;
				typCopy = 9253;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				rowTPS = true;
				break;
			case 38:
				ptr = 6;
				typCopy = 9766;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				rowTPS = true;
				break;
			case 49:
				ptr = 2;
				typCopy = 12593;
				lhLabel = "";
				lvLabel = LangUI[mLang, 95];
				rowTPS = true;
				break;
			case 50:
				ptr = 0;
				typCopy = 12850;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				enabled = true;
				rowTPS = true;
				break;
			case 51:
			case 52:
			case 53:
			case 54:
				ptr = 0;
				typCopy = 13110;
				lhLabel = LangUI[mLang, 96];
				lvLabel = "";
				fString = "0.0";
				enabled = true;
				rowTPS = true;
				break;
			}
			dColor = Tune.gColor[tag * 3];
			eColor = Tune.gColor[tag * 3 + 1];
			gScale = Tune.gColor[tag * 3 + 2];
			((ToolStripItem)exportMenuItem).Enabled = enabled;
			showView = rowTPS & keyF7;
			IMap.SetGridTable(fString, ptrMap[tag], ptr, TypTable);
			if (egCol.Length != gCol)
			{
				egCol = new byte[gCol];
			}
			if (egRow.Length != gRow)
			{
				egRow = new byte[gRow];
			}
			if (MapClip != null)
			{
				ptr = (int)MapClip[0];
				tag = (int)MapClip[1];
				mPaste = (ptr == rpmMap * 10 + Tune.idPC) & enCopy(tag);
				((ToolStripItem)pasteMenuItem).Enabled = mPaste & !showMod;
				menuItemEnabled(swMode == 0);
			}
		}
	}

	private bool enCopy(int tag)
	{
		return ((typCopy & 0xFF) >= (tag & 0x3F)) & (typCopy >> 8 <= (tag & 0x3F));
	}

	private void tvVehicule_MouseUp(object sender, MouseEventArgs e)
	{
		if (_LC4 & _2nECU & (e.Y > tvVehicule.ItemHeight))
		{
			int num = eInfo ^ 1;
			if (ISORead.dataSensor[85] == null)
			{
				num = 0;
			}
			if (eInfo != num)
			{
				eInfo = num;
				DisplayMsg("", 96);
				((Control)tvVehicule).Invalidate();
			}
		}
	}

	private void tvMap_AfterSelect(object sender, TreeViewEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		SaveGridTable();
		TreeView val = (TreeView)sender;
		if ((int)e.Node.Tag != 1)
		{
			return;
		}
		iTag = e.Node.Index;
		if (sTag != iTag)
		{
			e.Node.ImageIndex = 2;
			if (sTag != -1)
			{
				val.Nodes[0].Nodes[sTag].ImageIndex = -2;
			}
			sTag = iTag;
			tagMap = iTable[iTag];
			if ((TypTable & 0xFFF0) != 1024)
			{
				val.Nodes[0].Text = val.Nodes[0].Name + "- " + e.Node.Name;
			}
			else
			{
				val.Nodes[0].Text = LangUI[mLang, 73];
			}
			if (TypTable >= 0)
			{
				MapSelected(tagMap);
			}
		}
	}

	private void tvMap_BeforeExpand(object sender, TreeViewCancelEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if ((int)e.Node.Tag < 0)
		{
			((CancelEventArgs)(object)e).Cancel = true;
		}
		else
		{
			TreeView val = (TreeView)sender;
			int index = e.Node.Index;
			if (index > 0 && ((val.Nodes[1].Bounds.Y + e.Node.Bounds.Height * 14 > ((Control)val).Height) & val.Nodes[index ^ 3].IsExpanded))
			{
				val.Nodes[index ^ 3].Collapse();
				exNode = index;
			}
		}
		HideUD = 0;
		valueUD_Close();
	}

	private void tvMap_AfterExpand(object sender, TreeViewEventArgs e)
	{
		UDTop = tvMap.Nodes[1].Bounds.Top + 23;
	}

	private void tvMap_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Invalid comparison between Unknown and I4
		if (tvMap.SelectedNode == null || tvMap.SelectedNode.Parent == null)
		{
			return;
		}
		if (tvMap.SelectedNode.Index >= iTable.Length)
		{
			TreeNode val = tvMap.Nodes[0];
			tvMap.SelectedNode = val.Nodes[iTag];
			return;
		}
		int num = Tune.idTrim % 100;
		if (!((num < 2) & (tvMap.SelectedNode.Index != num)) && (((ptrMap[iTable[tvMap.SelectedNode.Index]] & 0x70) == 32) & (eTrim == 0) & !oneTrim) && (int)e.KeyCode == 32)
		{
			SaveGridTable();
			selectTrim(xTrim);
			MapSelected(tagMap);
		}
	}

	private void tvMap_MouseDown(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		TreeView val = (TreeView)sender;
		if ((int)e.Button == 2097152)
		{
			int num = e.Y / val.ItemHeight;
			if ((num > 0) & (num < iTable.Length))
			{
				trimMenu_Activate(num);
			}
			else
			{
				((Control)val).ContextMenuStrip = null;
			}
			return;
		}
		int num2 = Tune.idTrim % 100;
		int num3 = val.ItemHeight * (num2 + 1);
		if (!((e.Y < num3) | (e.Y > num3 + val.ItemHeight)) && (((ptrMap[iTable[iTag]] & 0x70) == 32) & (eTrim == 0) & !oneTrim))
		{
			SaveGridTable();
			selectTrim(xTrim);
			MapSelected(tagMap);
		}
	}

	private void tvMap_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Invalid comparison between Unknown and I4
		TreeView val = (TreeView)sender;
		if (e.Node.Level > 0)
		{
			if (e.Node.Parent.Index == 1)
			{
				if (((Control)valueUD).Visible)
				{
					if (((Control)valueUD).Top == UDTop + e.Node.Index * 16)
					{
						((Control)valueUD).Focus();
						HideUD = -1;
					}
					else
					{
						HideUD = 1;
					}
				}
				else
				{
					HideUD = 0;
				}
			}
			else
			{
				HideUD = 1;
			}
			if (((int)((MouseEventArgs)e).Button == 1048576) | (e.Node.Parent.Index > 0))
			{
				val.SelectedNode = e.Node;
			}
		}
		if (HideUD != -1)
		{
			unselectLabel(1);
		}
	}

	private void tvMap_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		TreeNode node = e.Node;
		if (node.Level <= 0 || !((e.Node.Parent.Index > 0) & !showMod))
		{
			return;
		}
		HideUD = 0;
		if (((Control)valueUD).Visible)
		{
			if (e.Node.Index == (int)((ToolStripItem)modifSubMenu).Tag)
			{
				return;
			}
			valueUD_Close();
		}
		NodeAction(node);
	}

	private void trimMenu_Activate(int k)
	{
		int num = ptrMap[iTable[k - 1]];
		int num2;
		int num3;
		string text;
		switch (num)
		{
		case 11:
			num2 = 0;
			num3 = 32;
			_ = xTrim;
			iTrim = Tune.idTrim % 100;
			text = (oneTrim ? "" : (((TypTable & 0xFFF0) == 112) ? "3" : "1"));
			break;
		case 12:
			num2 = ((!oneTrim) ? 4 : 0);
			num3 = 32;
			_ = xTrim;
			iTrim = Tune.idTrim % 100;
			text = (oneTrim ? "" : "2");
			break;
		case 13:
			num2 = ((!oneTrim) ? 2 : 0);
			num3 = 32;
			_ = xTrim;
			iTrim = Tune.idTrim % 100;
			text = (oneTrim ? "" : (((TypTable & 0xFFF0) == 112) ? "1" : "3"));
			break;
		case 14:
			num2 = ((!oneTrim) ? 6 : 0);
			num3 = 32;
			_ = xTrim;
			iTrim = Tune.idTrim % 100;
			text = (oneTrim ? "" : "4");
			break;
		case 19:
		case 20:
		case 21:
		case 22:
			num2 = 0;
			num3 = 36;
			iTrim = Tune.idTrim / 100 % 100;
			text = (((TypTable & 0xF8) == 56) ? " Dry" : "");
			break;
		case 83:
		case 84:
		case 85:
		case 86:
			num2 = 0;
			num3 = 37;
			iTrim = Tune.idTrim / 10000;
			text = " Wet";
			break;
		default:
			num2 = -1;
			num3 = 0;
			text = "";
			break;
		}
		if ((num2 >= 0) & ((num2 != xTrim) | (ptrMap[iTable[iTag]] != num3)))
		{
			string text2 = LangUI[mLang, (num3 == 32) ? 45 : 46];
			int num4 = text2.IndexOf("F");
			if (num > 18)
			{
				text2 += text;
			}
			else if (num4 != -1)
			{
				text2 = text2.Insert(num4 + 1, text);
			}
			((ToolStripItem)trimSubMenu).Text = text2;
			((Control)tvMap).ContextMenuStrip = cTrimMenu;
			((ToolStripItem)trimSubMenu).Tag = num2;
		}
		else
		{
			((Control)tvMap).ContextMenuStrip = null;
		}
	}

	private void menuStrip_MenuActivate(object sender, EventArgs e)
	{
		if (((Control)editUpDown).Visible)
		{
			unselectLabel(1);
		}
		if (((Control)valueUD).Visible)
		{
			valueUD_Close();
		}
		if (((ToolStripDropDown)cModifMenu).Visible)
		{
			((ToolStripDropDown)cModifMenu).Close();
		}
		if (((ToolStripDropDown)cActiveMenu).Visible)
		{
			((ToolStripDropDown)cActiveMenu).Close();
		}
		infosMapMenuItem.Checked = ((Control)infoForm).Visible;
		logMenuItem.Checked = ((Control)logForm).Visible;
	}

	private void cTrimMenu_Click(object sender, EventArgs e)
	{
		SaveGridTable();
		iTag = iTrim;
		xTrim = (int)((ToolStripItem)trimSubMenu).Tag;
		TreeNode val = tvMap.Nodes[0];
		tvMap.SelectedNode = null;
		if (iTag < 16)
		{
			tvMap.SelectedNode = val.Nodes[iTag];
		}
		else if (iTag < iTable.Length)
		{
			tagMap = iTable[iTag];
			tvMap.Nodes[0].Text = tvMap.Nodes[0].Name + "- " + ((ToolStripItem)trimSubMenu).Text;
			if (TypTable >= 0)
			{
				MapSelected(tagMap);
			}
		}
	}

	private void cModifMenu_Opening(object sender, CancelEventArgs e)
	{
		if ((HideUD == -1) | (onTest & (swMode == 1)) | showMod)
		{
			e.Cancel = true;
		}
	}

	private void cEditMenu_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Control sourceControl = ((ContextMenuStrip)sender).SourceControl;
		TreeNode selectedNode = ((TreeView)((sourceControl is TreeView) ? sourceControl : null)).SelectedNode;
		NodeAction(selectedNode);
	}

	private void cActiveMenu_Opened(object sender, EventArgs e)
	{
		int imageIndex = tvMap.SelectedNode.ImageIndex;
		((ToolStripItem)activeSubMenu).Text = ((imageIndex == 0) ? LangUI[mLang, 41] : LangUI[mLang, 42]);
	}

	private void vUDpanel_Paint(object sender, PaintEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		StringFormat val = new StringFormat();
		val = new StringFormat((StringFormatFlags)1);
		string text = eValue.ToString();
		if (((text != null) & (text != "")) && text.Substring(0, 1) == "-")
		{
			text = text.Substring(1, text.Length - 1) + "-";
		}
		e.Graphics.DrawString(text, IDraw.tbFont, (Brush)(object)IDraw.redBrush, (float)(((Control)vUDpanel).Width - 2), 1f, val);
	}

	private void valueUD_Enter(object sender, EventArgs e)
	{
		((ToolStripItem)modifSubMenu).Tag = tvMap.SelectedNode.Index;
		valueUD.Increment = Math.Abs(UDInc);
	}

	private void valueUD_KeyPress(object sender, KeyPressEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and O
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and O
		if ((e.KeyChar == '\u001b') | (e.KeyChar == '\r'))
		{
			eSave = e.KeyChar != '\u001b';
			if ((object)(NumericUpDown)sender == valueUD)
			{
				valueUD_Close();
			}
			else if ((object)(NumericUpDown)sender == editUpDown)
			{
				unselectLabel(1);
			}
		}
	}

	private void valueUD_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 16)
		{
			if (((Control)valueUD).Visible & (UDInc > 0m))
			{
				((NumericUpDown)sender).Increment = UDInc * 10m;
			}
			else if (((Control)editUpDown).Visible & (EDInc > 0m) & !pcEdit)
			{
				((NumericUpDown)sender).Increment = EDInc * 10m;
			}
		}
	}

	private void valueUD_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 16)
		{
			if (((Control)valueUD).Visible & (UDInc > 0m))
			{
				((NumericUpDown)sender).Increment = UDInc;
			}
			else if (((Control)editUpDown).Visible & (EDInc > 0m) & !pcEdit)
			{
				((NumericUpDown)sender).Increment = EDInc;
			}
		}
	}

	private void valueUD_ValueChanged(object sender, EventArgs e)
	{
		if (((Control)vUDpanel).Visible)
		{
			((Control)vUDpanel).Invalidate();
			eValue = valueUD.Value;
		}
		eSave = true;
		pSave = true;
	}

	private void valueUD_Close()
	{
		if (HideUD != 0)
		{
			return;
		}
		if (eSave)
		{
			int num = (int)((ToolStripItem)modifSubMenu).Tag;
			if (num != -1)
			{
				TreeNode val = tvMap.Nodes[1].Nodes[num];
				int num2 = (Tune.prmIndex >> val.Index * 4) & 0xF;
				if (num2 < 12)
				{
					int value;
					if (UDInc == 0.1m)
					{
						ISORead.dataSensor[num2 + 68] = valueUD.Value.ToString("#0.0");
						value = (int)(valueUD.Value * 10m);
					}
					else
					{
						value = (int)valueUD.Value;
						ISORead.dataSensor[num2 + 68] = value.ToString();
					}
					IMap.ApplyParams(num2, value);
				}
				eSave = false;
				((ToolStripItem)modifSubMenu).Tag = -1;
			}
		}
		((Control)vUDpanel).Hide();
		((Control)valueUD).Hide();
	}

	private void EditUD_Leave(object sender, EventArgs e)
	{
		if (HideUD == 0)
		{
			btnTest = -1;
			HideUD = 1;
		}
	}

	private void editUpDown_ValueChanged(object sender, EventArgs e)
	{
		eSave = true;
		if (pcEdit)
		{
			((Control)EDpanel).Invalidate();
		}
		((Control)panelTable).Invalidate();
	}

	private void editUpDown_Leave(object sender, EventArgs e)
	{
		if (eSave)
		{
			SaveValueUD();
		}
	}

	private void NodeAction(TreeNode node)
	{
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Invalid comparison between Unknown and I4
		if ((int)node.Tag < 0)
		{
			return;
		}
		int num = ptrMap[tagMap];
		altParams = (TypTable > 2048) & ((num == 12) | (num == 20));
		if (node.Index < 8)
		{
			switch ((int)node.Tag & 6)
			{
			case 2:
			{
				int num3 = 0;
				int num4 = 0;
				int num2 = (Tune.prmIndex >> node.Index * 4) & 0xF;
				int num5 = IMap.paramIndex[num2];
				switch (num2)
				{
				case 0:
					UDInc = 10m;
					num4 = IMap.paramIndex[7];
					num3 = (int)((double)num4 * 0.0075) * 100;
					break;
				case 1:
					UDInc = -1m;
					num3 = 94;
					num4 = 106;
					break;
				case 2:
					if (TypTable < 16)
					{
						UDInc = 0.1m;
						num3 = 2000;
						num4 = 4500;
					}
					else
					{
						UDInc = 0.1m;
						num3 = -600;
						num4 = 200;
					}
					break;
				case 3:
					if (TypTable == 16)
					{
						UDInc = 10m;
						num3 = 8000;
						num4 = 24000;
					}
					else if ((TypTable >= 40) & (TypTable < 64))
					{
						UDInc = 10m;
						num3 = 900;
						num4 = 4500;
					}
					else
					{
						UDInc = 10m;
						num3 = 1000;
						num4 = 2400;
					}
					break;
				case 4:
					if ((TypTable == 6) | (TypTable == 14))
					{
						UDInc = 0.1m;
						num3 = 120;
						num4 = 150;
					}
					else
					{
						UDInc = 0.1m;
						num3 = (((TypTable & 0x3C) == 60) ? 300 : 1500);
						num4 = (((TypTable & 0x3C) == 60) ? 4000 : 2990);
					}
					break;
				case 5:
					UDInc = 10m;
					num3 = 30;
					num4 = 150;
					break;
				}
				if (num4 == 65535)
				{
					break;
				}
				if (num5 < num3)
				{
					num5 = num3;
				}
				if (num5 > num4)
				{
					num5 = num4;
				}
				if (num2 == 5)
				{
					toHide = true;
					queryBox = new QueryForm();
					QueryForm.boxMode = 100;
					QueryForm.boxValue = IMap.paramIndex[5];
					if ((int)((Form)queryBox).ShowDialog() == 1)
					{
						IMap.ApplyParams(num2, QueryForm.boxValue);
						displayParams(5, -2);
					}
					toHide = false;
				}
				else
				{
					valueUD.Increment = Math.Abs(UDInc);
					valueUD.Minimum = (decimal)num3 * ((UDInc == 0.1m) ? 0.1m : 1m);
					valueUD.Maximum = (decimal)num4 * ((UDInc == 0.1m) ? 0.1m : 1m);
					valueUD.Value = (decimal)num5 * ((UDInc == 0.1m) ? 0.1m : 1m);
					eValue = valueUD.Value;
					((Control)vUDpanel).Top = UDTop + node.Index * 16;
					((Control)valueUD).Top = ((Control)vUDpanel).Top;
					((Control)vUDpanel).Show();
					((Control)valueUD).Show();
					((Control)valueUD).Focus();
				}
				eSave = false;
				break;
			}
			case 4:
			{
				int num2 = (Tune.devIndex >> node.Index * 4) & 0xF;
				paramsToggle(num2 + 7);
				break;
			}
			case 3:
				break;
			}
		}
		else
		{
			adjustUD_Activate(node);
		}
	}

	private void paramsToggle(int index)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Invalid comparison between Unknown and I4
		int i = 0;
		bool flag = true;
		TreeNode val = tvMap.Nodes[2];
		int num = (IMap.mapTable[index + 25] >> 16) & 0xF;
		int num2 = 1 << num;
		for (; (((Tune.devIndex >> i * 4) & 0xF) != index - 7) & (i < 7); i++)
		{
		}
		if (i == 7)
		{
			return;
		}
		int num3 = (Tune.devAcc >> (index - 7) * 4) & 0xF;
		int num4 = (val.Nodes[i].ImageIndex + 1) % 2;
		if (num4 == 1)
		{
			val.Nodes[i].ImageIndex = num4;
			num4 = num2;
			num2 = IMap.paramIndex[index] | num4;
			IMap.ApplyParams(index, num2);
			return;
		}
		if (num3 > 0)
		{
			flag = (int)DisplayBox("", LangUI[mLang, num3 + 300], 9) == 1;
		}
		if (flag)
		{
			val.Nodes[i].ImageIndex = num4;
			num4 = 0xFFFF ^ num2;
			num2 = IMap.paramIndex[index] & num4;
			IMap.ApplyParams(index, num2);
		}
	}

	public static void ProgressBarInit(int Max)
	{
		if (Max == 0)
		{
			mProgress = 0.0;
		}
		else
		{
			mProgress = (double)refBar / (double)Max;
		}
		sProgress = 0;
		((ToolStripItem)me.fileStatus).Invalidate();
	}

	public static void ProgressBarRefresh(int Pos)
	{
		if (Pos >= 0)
		{
			sProgress = Pos;
		}
		((ToolStripItem)me.fileStatus).Invalidate();
	}

	public void ShowBar()
	{
		int hwnd = FindWindows("Shell_traywnd", string.Empty);
		SetWindowPos(hwnd, 0, 0, 0, 0, 0, 64);
		TaskBarVisible = true;
	}

	public void HideBar()
	{
		int hwnd = FindWindows("Shell_traywnd", string.Empty);
		SetWindowPos(hwnd, 0, 0, 0, 0, 0, 128);
		TaskBarVisible = false;
	}

	public static void SetUInterface(int type)
	{
		sagemECU = type == 0;
		mView = (mView & 0x40) | ((swMode == 2) ? 15 : ((!sagemECU) ? (_Twin ? 3 : (_Walbro ? 4 : (_Four ? 5 : 7))) : 0));
		me.setUISensors();
		if ((swMode > -1) & ((swMode & 3) > 0))
		{
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
		}
		((Control)me.BtnMid).Invalidate();
		((Control)me.BtnRight).Invalidate();
	}

	private void button_MouseDown(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		if ((e.Button & 0x100000) == 1048576)
		{
			Button val = (Button)sender;
			int num = (int)((Control)val).Tag;
			btnMode = num * 8 + 1;
			btnPress = btnMode;
			((Control)val).Invalidate();
		}
	}

	private void button_MouseLeave(object sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		btnMode = 0;
		Button val = (Button)sender;
		((Control)val).Invalidate();
	}

	private void button_MouseUp(object sender, MouseEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		if ((int)e.Button == 1048576)
		{
			Button val = (Button)sender;
			_ = (int)((Control)val).Tag;
			if (btnMode * btnPress > 0)
			{
				TabButton_Click(sender);
			}
			btnMode = 0;
			btnPress = 0;
			((Control)val).Invalidate();
		}
	}

	private void button_MouseMove(object sender, MouseEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		if (btnPress != 0)
		{
			Button val = (Button)sender;
			int num = (int)((Control)val).Tag;
			if ((e.X < 0) | (e.X > ((Control)val).Width) | (e.Y < 0) | (e.Y > ((Control)val).Height) | ((e.Button & 0x100000) != 1048576) | (btnPress != num * 8 + 1))
			{
				btnMode = 0;
				((Control)val).Invalidate();
			}
			else
			{
				btnMode = num * 8 + 1;
				((Control)val).Invalidate();
			}
		}
	}

	private void button_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintBtn(sender, e, btnMode);
	}

	private void TabButton_Click(object sender)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		unselectLabel(1);
		SaveGridTable();
		((Control)Logo_Panel).Invalidate();
		Button val = (Button)sender;
		if ((int)((Control)val).Tag == swMode)
		{
			return;
		}
		int num = (int)((Control)val).Tag;
		if (swMode > 0)
		{
			ISORead.dataClear(0);
		}
		swMode = num & 3;
		offWOT = 100;
		((Form)this).MaximizeBox = ((num & 3) == 0) & enWide;
		enableMenuItems(ISORead.mMode, 0);
		((ToolStripItem)TrimToLMenuItem).Enabled = (swMode == 0) & ((MapTrim[0] & 2) != 0);
		if (num > 0)
		{
			for (int i = 1; i < 4; i++)
			{
				ISORead.dataSensor[i] = "0";
			}
		}
		switch (num)
		{
		case 0:
			if (wState)
			{
				((Form)this).WindowState = (FormWindowState)2;
			}
			((Control)panelDiag).Hide();
			((Control)gbTable).Show();
			if (!noMap)
			{
				DisplayMsg(cutString(lastFile, ((ToolStripItem)fileStatus).Width - 8), 64);
			}
			listCodes.Items.Clear();
			((TextBoxBase)tbDescription).Clear();
			if (EXBVReset | ISCVReset)
			{
				endTest(rst: true);
			}
			ISORead.setSensor(num);
			MapSelected(tagMap);
			break;
		case 1:
		{
			if (wState)
			{
				((Form)this).WindowState = (FormWindowState)0;
			}
			DisplayMsg("", 64);
			mView = (mView & 0x40) | ((!sagemECU) ? (_Twin ? 3 : (_Walbro ? 4 : (_Four ? 5 : 7))) : 0);
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
			((Control)gbTable).Hide();
			((Control)panelDiag).Show();
			ISORead.msWalbro = 0;
			ISORead.dataClear(0);
			ISORead.setSensor(num);
			if (ISORead.mMode == eMode.MODE_READ_SENSORS)
			{
				listCodesUpdate("", status: true);
			}
			for (int j = 1; j < 4; j++)
			{
				ISORead.dataSensor[j] = "0";
			}
			((Control)sensor_plus).Enabled = false;
			((Control)tvSensor).Enabled = false;
			((ToolStripItem)pasteMenuItem).Enabled = false;
			((ToolStripItem)loopStatus).Enabled = false;
			((ToolStripItem)tpsStatus).Enabled = false;
			((ToolStripItem)me.loopStatus).ToolTipText = "";
			((ToolStripItem)me.tpsStatus).ToolTipText = "";
			((Control)gbSensor).Height = (int)((Control)_lbSensors).Tag;
			((Control)tvSensor).Height = ((Control)gbSensor).Height - 9;
			((Control)_lbTests).Visible = true;
			((Control)gbTests).Visible = true;
			((Control)tvTests).Focus();
			((Control)pbDash).Invalidate();
			break;
		}
		case 2:
			if (wState)
			{
				((Form)this).WindowState = (FormWindowState)0;
			}
			DisplayMsg("", 64);
			mView |= 15;
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
			((Control)gbTable).Hide();
			((Control)panelDiag).Show();
			if (EXBVReset | ISCVReset)
			{
				endTest(rst: true);
			}
			ISORead.dataClear(0);
			ISORead.setSensor(num);
			if (ISORead.mMode == eMode.MODE_READ_SENSORS)
			{
				listCodesUpdate("", status: true);
			}
			if ((int)((Control)sensor_minus).Tag == 0)
			{
				pb_minus_Click(sensor_minus, null);
			}
			((Control)sensor_plus).Enabled = true;
			((Control)tvSensor).Enabled = true;
			((ToolStripItem)pasteMenuItem).Enabled = false;
			((Control)gbSensor).Height = ((Control)panelDiag).Height - 14;
			((Control)tvSensor).Height = ((Control)gbSensor).Height - 9;
			((Control)_lbTests).Visible = false;
			((Control)gbTests).Visible = false;
			((Control)tvSensor).Focus();
			((Control)pbDash).Invalidate();
			break;
		case 4:
			flashMenuItem_Click(null, null);
			break;
		case 3:
			break;
		}
	}

	public static void endTest(bool rst)
	{
		if (rst)
		{
			ISORead.SwitchMode(eMode.MODE_NULL);
		}
		else if (ISORead.mMode == eMode.MODE_READ_SENSORS)
		{
			listCodesUpdate("", status: true);
		}
		ISORead.dataSensor[3] = null;
		if (btnTest == -1)
		{
			btnTest = (ISCVReset ? 10 : 9);
		}
		me.tvTests.Nodes[btnTest].ImageIndex = 8;
		btnTest = -1;
		tRetry = 0;
		onTest = false;
		EXBVReset = false;
		ISCVReset = false;
		stepEXBV = 0;
		stepISCV = 0;
		ISORead.rTest = 0;
	}

	public static void sensorEnabled(int mode)
	{
		switch (mode)
		{
		case 1:
			me.pb_minus_Click(null, null);
			break;
		case 2:
			if ((int)((Control)me.sensor_minus).Tag == 1)
			{
				me.pb_plus_Click(null, null);
			}
			else
			{
				me.pb_minus_Click(null, null);
			}
			break;
		}
	}

	private void _lbSensors_DoubleClick(object sender, EventArgs e)
	{
		if (((Control)sensor_plus).Enabled)
		{
			if (((Control)sensor_plus).Visible)
			{
				pb_plus_Click(sensor_plus, null);
			}
			else
			{
				pb_minus_Click(sensor_minus, null);
			}
		}
	}

	private void pb_plus_Click(object sender, MouseEventArgs e)
	{
		int num = eSensor;
		if (sender != null)
		{
			((Control)sensor_minus).Tag = 1;
			if ((eSensor & 0x7FF) == 0)
			{
				eSensor = 2047;
			}
		}
		for (int i = 0; i < tvSensor.Nodes.Count; i++)
		{
			if ((num & (int)Math.Pow(2.0, i)) > 0)
			{
				tvSensor.Nodes[i].Expand();
			}
			else
			{
				SetSensorCount(i, 0, set: true);
			}
			tvSensor.Nodes[i].Tag = 8;
		}
		((Control)sensor_plus).Hide();
		((Control)sensor_minus).Show();
	}

	private void pb_minus_Click(object sender, MouseEventArgs e)
	{
		int num = 0;
		for (int i = 0; i < tvSensor.Nodes.Count; i++)
		{
			if (tvSensor.Nodes[i].IsExpanded)
			{
				num += (int)Math.Pow(2.0, i);
			}
			else
			{
				NodesChange(i);
			}
			tvSensor.Nodes[i].Collapse();
			tvSensor.Nodes[i].Tag = ((swMode == 1) ? (-8) : 8);
		}
		((Control)sensor_plus).Show();
		((Control)sensor_minus).Hide();
		if (num != 0)
		{
			eSensor = num;
		}
		if (sender != null)
		{
			((Control)sensor_minus).Tag = 0;
		}
	}

	private void tvSensor_NodesChange(object sender, TreeViewEventArgs e)
	{
		if (swMode == 2)
		{
			int index = e.Node.Index;
			ushort en = (ushort)(e.Node.IsExpanded ? 3u : 0u);
			SetSensorCount(index, en, set: true);
		}
	}

	private void NodesChange(int index)
	{
		TreeNode val = tvSensor.Nodes[index];
		ushort en = (ushort)(val.IsExpanded ? 3u : 0u);
		SetSensorCount(index, en, set: false);
	}

	private void SetSensorCount(int ix, ushort en, bool set)
	{
		if (_Walbro)
		{
			return;
		}
		ushort[] allSensor = ISORead.AllSensor;
		int num = ((!sagemECU) ? 11 : 0);
		if (set)
		{
			eSensor = (eSensor & (-1 ^ (int)Math.Pow(2.0, ix))) | ((int)Math.Pow(2.0, ix) * en);
		}
		for (int i = 0; i < 12; i++)
		{
			ushort num2 = ISensor.sensorNode[(ix + num) * 12 + i];
			if (num2 == ushort.MaxValue)
			{
				continue;
			}
			for (int j = 0; j < allSensor.Length / 2; j++)
			{
				if (allSensor[j * 2] == num2)
				{
					allSensor[j * 2 + 1] = en;
				}
			}
		}
	}

	private void tvTests_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (eTag > 0)
		{
			return;
		}
		int num = (int)e.Node.Tag;
		int num2 = (int)((Control)adjustUD).Tag;
		if ((num == 34) & (btnTest == -1) & (e.Node.Index > 9))
		{
			if (((Control)adjustUD).Visible)
			{
				if (e.Node.Index - 10 == num2)
				{
					((Control)adjustUD).Focus();
					HideUD = -1;
				}
				else
				{
					HideUD = 1;
				}
			}
			else
			{
				HideUD = 0;
			}
			e.Node.ContextMenuStrip = cModifMenu;
			tvTests.SelectedNode = e.Node;
			((Control)adjustUD).Tag = e.Node.Index - 10;
		}
		else
		{
			HideUD = 1;
		}
	}

	private void tvTests_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Invalid comparison between Unknown and I4
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Invalid comparison between Unknown and I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Invalid comparison between Unknown and I4
		if (eTag > 0)
		{
			return;
		}
		if (((int)e.Node.Tag == 4) & (btnTest == -1))
		{
			if (_Walbro)
			{
				tpsMin = 100;
				tpsMax = 100;
				setTPS = true;
				btnTest = e.Node.Index;
				tvTests.Nodes[btnTest].ImageIndex = 9;
				if ((int)DisplayBox("", LangUI[mLang, 360], 9) == 1)
				{
					setWalbroTps();
				}
				tvTests.Nodes[9].ImageIndex = 8;
				btnTest = -1;
			}
			else if (_KTM & (e.Node.Index == 9))
			{
				rstTrim = true;
				btnTest = e.Node.Index;
				rTrim = btnTest;
				ISORead.StartDiagRoutine(27, 0);
				DisplayMsg(LangUI[mLang, 300], 64);
				tvTests.Nodes[btnTest].ImageIndex = 9;
				testTick = 5;
			}
			else if (_KTM & (e.Node.Index == 11))
			{
				if ((int)DisplayBox("", LangUI[mLang, 304], 7) == 2)
				{
					return;
				}
				btnTest = e.Node.Index;
				rTrim = btnTest;
				ISORead.StartDiagRoutine(28, 0);
				DisplayMsg(LangUI[mLang, 279], 64);
				tvTests.Nodes[btnTest].ImageIndex = 9;
			}
			else if (sagemECU & (e.Node.Index == 9))
			{
				if ((int)DisplayBox("", LangUI[mLang, 276], 7) == 2)
				{
					return;
				}
				rstTrim = true;
				btnTest = e.Node.Index;
				rTrim = btnTest;
				ISORead.StartSagemCmd(8);
				DisplayMsg(LangUI[mLang, 266] + "...", 64);
				tvTests.Nodes[btnTest].ImageIndex = 9;
				testTick = 5;
			}
			else if (EXBVReset & (e.Node.Index == 9))
			{
				btnTest = e.Node.Index;
				ISORead.StartDiagRoutine(btnTest, (ISORead.rTest == 9) ? 2 : 0);
			}
			else if (ISCVReset & (e.Node.Index == 10))
			{
				btnTest = e.Node.Index;
				ISORead.StartDiagRoutine(btnTest, (ISORead.rTest == 7) ? 2 : 0);
			}
			else if (!EXBVReset & !ISCVReset)
			{
				if (e.Node.Index > 8 && (int)DisplayBox("", LangUI[mLang, 277] + LangUI[mLang, e.Node.Index + 253] + LangUI[mLang, 278], 7) == 2)
				{
					return;
				}
				btnTest = e.Node.Index;
				ISORead.StartDiagRoutine(btnTest + (KWP ? 16 : 0), 0);
				DisplayMsg("", 64);
			}
			outTest = 0;
		}
		if (((int)e.Node.Tag == 34) & (btnTest == -1))
		{
			HideUD = 0;
			if (((Control)adjustUD).Visible)
			{
				((Control)adjustUD).Hide();
			}
			((Control)adjustUD).Tag = e.Node.Index - 10;
			if ((ISORead.dataSagemTrim[(int)((Control)adjustUD).Tag * 8] != byte.MaxValue) | _Walbro)
			{
				adjustUD_Activate(e.Node);
			}
		}
	}

	private void setWalbroTps()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (tpsMin > 64)
		{
			setTPS = false;
			DisplayBox("", LangUI[mLang, 358], 4);
		}
		else if (tpsMax < 192)
		{
			setTPS = false;
			DisplayBox("", LangUI[mLang, 359], 4);
		}
		else
		{
			ISORead.walbroSetTPS(0);
			ISORead.setWBTrim = 1;
		}
	}

	private void adjustUD_Activate(TreeNode node)
	{
		((Control)adjustUD).Top = node.Bounds.Top + 10;
		adjustUD.Value = 0m;
		if (_Walbro)
		{
			adjustUD.Minimum = 0m;
			adjustUD.Maximum = 255m;
			adjustUD.Value = ISORead.dataNum[(int)((Control)adjustUD).Tag + ISORead.msWalbro + 18];
			((Control)adjustUD).ContextMenuStrip = null;
		}
		else
		{
			adjustUD.Maximum = 1m;
			adjustUD.Minimum = -1m;
			if ((int)((Control)adjustUD).Tag == 0)
			{
				((Control)adjustUD).ContextMenuStrip = null;
			}
			else
			{
				((Control)adjustUD).ContextMenuStrip = cResetMenu;
			}
		}
		((Control)adjustUD).Show();
		((Control)adjustUD).Focus();
	}

	private void adjustUD_ValueChanged(object sender, EventArgs e)
	{
		int num = (int)adjustUD.Value;
		int num2 = (int)((Control)adjustUD).Tag;
		if (_Walbro)
		{
			int num3 = wbTrim & 0x700;
			int value = ISORead.byte2String((byte)num);
			ISORead.dataNum[num2 + ISORead.msWalbro + 18] = (short)num;
			ISORead.walbroSetValue(num2 * 4, value);
			ISORead.dataSensor[num2 + 74] = ((double)ISORead.dataNum[num2 + ISORead.msWalbro + 18] / 128.0).ToString("0.000");
			tvTest_Update(num2 * 16 + 160, refresh: true);
			eTag = num2 + 1;
			wbTrim = (eTag << 8) | (num3 + 5);
			return;
		}
		if (num != 0)
		{
			num = (num + 1) / 2 + num2 * 2;
			if (ISORead.dataSagemTrim[num] != byte.MaxValue)
			{
				ISORead.StartSagemCmd((byte)num);
			}
		}
		adjustUD.Value = 0m;
	}

	private void wbTrimValidate()
	{
		((Control)adjustUD).Hide();
		ISORead.setWBTrim = 1;
		tvTest_Update(eTag * 16 + 144, refresh: true);
		eTag = 0;
		wbTrim = 0;
	}

	private void cResetMenu_Click(object sender, EventArgs e)
	{
		((Control)adjustUD).Hide();
		rstTrim = true;
		btnTest = tvTests.SelectedNode.Index;
		rTrim = btnTest;
		DisplayMsg(LangUI[mLang, 289] + LangUI[mLang, rTrim + 257] + "...", 64);
		ISORead.StartSagemCmd((byte)((int)((Control)adjustUD).Tag + 5));
		testTick = 5;
	}

	private void tv_testEnabled(bool mode)
	{
		if (mode == enTest)
		{
			return;
		}
		bool flag = false;
		if (((int)tvTests.Nodes[0].Tag == 4 != mode) | !mode)
		{
			for (int i = 0; i < 8; i++)
			{
				flag = (avTest & (int)Math.Pow(2.0, i)) > 0;
				tvTests.Nodes[i].Tag = ((mode & flag) ? 4 : (-4));
			}
			for (int j = 0; j < 4; j++)
			{
				flag = (avTrim & (int)Math.Pow(2.0, j)) > 0;
				tvTests.Nodes[j + 9].Tag = ((mode & flag) ? 4 : (-4));
				tvTests.Nodes[j + 9].ContextMenuStrip = null;
				ISORead.dataSensor[j + 174] = "";
			}
			for (int k = 0; k < 6; k++)
			{
				ISORead.dataSagemTrim[k * 4] = byte.MaxValue;
			}
			((Control)tvTests).Invalidate();
			if (!mode)
			{
				HideUD = 1;
			}
		}
		if (onTest & !mode)
		{
			endTest(rst: false);
			if (swMode > 0)
			{
				DisplayMsg("", 64);
			}
		}
		enTest = mode;
	}

	public static void SettingEXBV()
	{
		switch (++stepEXBV)
		{
		case 1:
			EXBVReset = true;
			testTick = 0;
			me.tvTests.Nodes[9].ImageIndex = 9;
			ISORead.setDiagSensor(4);
			mView &= 68;
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(4);
			DisplayMsg(LangUI[mLang, 308], 32);
			DisplayMsg(LangUI[mLang, 306], 64);
			break;
		case 2:
			testTick = 0;
			me.tvTests.Nodes[9].ImageIndex = 9;
			DisplayMsg(LangUI[mLang, 306], 64);
			break;
		case 3:
			ISORead.StartDiagRoutine(9, 2);
			testTick = 19;
			break;
		case 4:
			EXBVReset = false;
			ISORead.setDiagSensor(1);
			mView |= 7;
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
			DisplayMsg(LangUI[mLang, 309] + "\r", 32);
			DisplayMsg(LangUI[mLang, 309], 64);
			endTest(rst: false);
			break;
		}
	}

	public static void SettingTPS()
	{
		switch (++stepISCV)
		{
		case 1:
			ISCVReset = true;
			testTick = 18;
			me.tvTests.Nodes[10].ImageIndex = 9;
			ISORead.setDiagSensor(2);
			mView &= 68;
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(2);
			DisplayMsg(LangUI[mLang, 288], 32);
			DisplayMsg(LangUI[mLang, 283], 64);
			break;
		case 2:
			testTick = 18;
			DisplayMsg(LangUI[mLang, 284 + (ISCDiff ? 2 : 0)], 64);
			break;
		case 3:
			btnTest = 10;
			me.tvTests.Nodes[10].ImageIndex = 9;
			testTick = -10;
			DisplayMsg(LangUI[mLang, 285], 64);
			break;
		case 4:
			ISORead.setDiagSensor(1);
			mView |= 7;
			((Control)me.pbDash).BackgroundImage = (Image)(object)IDraw.PaintDash(swMode / 2);
			DisplayMsg(LangUI[mLang, 287] + "\r", 32);
			DisplayMsg(LangUI[mLang, 287], 64);
			endTest(rst: false);
			break;
		}
	}

	private void ISOMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (errExit != 0)
		{
			return;
		}
		if (!ISORead.mFlash & !ISORead.mLoad)
		{
			((Control)EDpanel).Hide();
			((Control)editUpDown).Hide();
			valueUD_Close();
			SaveGridTable();
			fileClosing();
			ISOFT.Terminate = true;
			if (writer != null)
			{
				try
				{
					writer.Close();
				}
				catch
				{
				}
			}
		}
		else
		{
			if (ISORead.mLoad)
			{
				ISOFT.SetMessage(eMessage.ERR_ABORT);
				Thread.Sleep(200);
			}
			((CancelEventArgs)(object)e).Cancel = true;
		}
	}

	private void ISOMain_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (errExit != 0)
		{
			return;
		}
		if (cReadTimer.Enabled)
		{
			cReadTimer.Enabled = false;
			ISOFT.FTDClose(wait: true);
			ISOFT.closeSerialPort(wait: true);
			if (!TaskBarVisible)
			{
				ShowBar();
			}
			try
			{
				watcher.Stop();
			}
			catch
			{
			}
		}
		eSensor += (((int)((Control)sensor_minus).Tag > 0) ? 4096 : 0);
		if (me.lbDevList.Items.Count > 0)
		{
			usbSerial = lastPort;
		}
		SetHKCUkey("Software\\TuneECU\\Properties", "Version", getVersion().Substring(2));
		SetHKCUkey("Software\\TuneECU\\Properties", "Language", mLang.ToString());
		SetHKCUkey("Software\\TuneECU\\Properties", "Mode", swMode.ToString());
		SetHKCUkey("Software\\TuneECU\\Properties", "Sensors", eSensor.ToString());
		SetHKCUkey("Software\\TuneECU\\Properties", "exNode", exNode.ToString());
		SetHKCUkey("Software\\TuneECU\\Properties", "PCFile", pcType.ToString());
		SetHKCUkey("Software\\TuneECU\\Properties", "LastECU", sagemECU ? "0" : (_KTM ? "2" : "1"));
		SetHKCUkey("Software\\TuneECU\\Properties", "serialPort", lastPort);
		SetHKCUkey("Software\\TuneECU\\Properties", "USBPort", usbSerial);
		SetHKCUkey("Software\\TuneECU\\Properties", "AutoConnect", autoConnect ? "1" : "0");
		SetHKCUkey("Software\\TuneECU\\Properties", "Graphic", showGraph ? "1" : "0");
		SetHKCUkey("Software\\TuneECU\\Properties", "Splash", showSplash ? "1" : "0");
		SetHKCUkey("Software\\TuneECU\\Properties", "Separator", separator);
		SetHKCUkey("Software\\TuneECU\\Properties", "fullScreen", wState ? "1" : "0");
		if (pTiming == 196)
		{
			DelHKCUkey("Software\\TuneECU\\Properties", "Timing");
		}
		if (pForce == ulong.MaxValue)
		{
			DelHKCUkey("Software\\TuneECU\\Properties", "ForceOn");
		}
	}

	public static string getVersion()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string text = $"{executingAssembly.GetName().Version.Build}";
		text = ((text != "0") ? ("." + text) : "");
		return "v " + $"{executingAssembly.GetName().Version.Major}.{executingAssembly.GetName().Version.Minor + text}";
	}

	public static void WriteTrcFile(byte[] mTrace, int start, int len, string s)
	{
		string text = "";
		try
		{
			if (me.writer == null)
			{
				me.writer = new StreamWriter("trace.txt");
				me.writer.WriteLine(((Control)me).Text + subVersion + Tune.getVersion() + "\r\n");
				me.writer.WriteLine("R=" + ((Control)me).Width + "x" + ((Control)me).Height + ":" + ((Form)me).Opacity + (showSplash ? "*" : ""));
				me.writer.WriteLine("L:" + mLang + " M:" + swMode + " E:" + mECU + " S:" + oSys + "\r\n");
			}
			string text2 = DateTime.Now.Second.ToString("00") + ":" + DateTime.Now.Millisecond.ToString("000") + " " + s;
			text = ((mTrace != null) ? (text2 + " " + BitConverter.ToString(mTrace, start, len) + "\r") : ((len <= 0) ? (s + "\r") : (s + len + "\r")));
			if (me.writer.BaseStream != null && me.writer.BaseStream.Length < 4194304)
			{
				me.writer.WriteLine(text);
			}
		}
		catch
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected O, but got Unknown
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Expected O, but got Unknown
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected O, but got Unknown
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected O, but got Unknown
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected O, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected O, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected O, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected O, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected O, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected O, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected O, but got Unknown
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Expected O, but got Unknown
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Expected O, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected O, but got Unknown
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected O, but got Unknown
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected O, but got Unknown
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Expected O, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Expected O, but got Unknown
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Expected O, but got Unknown
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected O, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Expected O, but got Unknown
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Expected O, but got Unknown
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Expected O, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected O, but got Unknown
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected O, but got Unknown
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected O, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected O, but got Unknown
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Expected O, but got Unknown
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Expected O, but got Unknown
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Expected O, but got Unknown
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Expected O, but got Unknown
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_086e: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Expected O, but got Unknown
		//IL_0890: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Expected O, but got Unknown
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Expected O, but got Unknown
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b0: Expected O, but got Unknown
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Expected O, but got Unknown
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cc: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d7: Expected O, but got Unknown
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Expected O, but got Unknown
		//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Expected O, but got Unknown
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Expected O, but got Unknown
		//IL_0904: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Expected O, but got Unknown
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Expected O, but got Unknown
		//IL_091a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Expected O, but got Unknown
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Expected O, but got Unknown
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Expected O, but got Unknown
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Expected O, but got Unknown
		//IL_0951: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Expected O, but got Unknown
		//IL_095c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Expected O, but got Unknown
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_0971: Expected O, but got Unknown
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_097c: Expected O, but got Unknown
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0998: Expected O, but got Unknown
		//IL_0999: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Expected O, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Expected O, but got Unknown
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Expected O, but got Unknown
		//IL_09d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected O, but got Unknown
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Expected O, but got Unknown
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Expected O, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Expected O, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Expected O, but got Unknown
		//IL_0a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Expected O, but got Unknown
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Expected O, but got Unknown
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Expected O, but got Unknown
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected O, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Expected O, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected O, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6f: Expected O, but got Unknown
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Expected O, but got Unknown
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a90: Expected O, but got Unknown
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9b: Expected O, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Expected O, but got Unknown
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected O, but got Unknown
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Expected O, but got Unknown
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Expected O, but got Unknown
		//IL_0ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ade: Expected O, but got Unknown
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Expected O, but got Unknown
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Expected O, but got Unknown
		//IL_0af5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aff: Expected O, but got Unknown
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Expected O, but got Unknown
		//IL_0b0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b15: Expected O, but got Unknown
		//IL_0b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Expected O, but got Unknown
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Expected O, but got Unknown
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_0d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d40: Expected O, but got Unknown
		//IL_0def: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Expected O, but got Unknown
		//IL_0f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b7: Expected O, but got Unknown
		//IL_200f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2019: Expected O, but got Unknown
		//IL_2129: Unknown result type (might be due to invalid IL or missing references)
		//IL_2133: Expected O, but got Unknown
		//IL_21cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d5: Expected O, but got Unknown
		//IL_21f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2202: Expected O, but got Unknown
		//IL_229e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a8: Expected O, but got Unknown
		//IL_238e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2398: Expected O, but got Unknown
		//IL_23a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23af: Expected O, but got Unknown
		//IL_23bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c6: Expected O, but got Unknown
		//IL_23ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f4: Expected O, but got Unknown
		//IL_2401: Unknown result type (might be due to invalid IL or missing references)
		//IL_240b: Expected O, but got Unknown
		//IL_2418: Unknown result type (might be due to invalid IL or missing references)
		//IL_2422: Expected O, but got Unknown
		//IL_2477: Unknown result type (might be due to invalid IL or missing references)
		//IL_2481: Expected O, but got Unknown
		//IL_24f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2500: Expected O, but got Unknown
		//IL_2613: Unknown result type (might be due to invalid IL or missing references)
		//IL_261d: Expected O, but got Unknown
		//IL_262a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2634: Expected O, but got Unknown
		//IL_2641: Unknown result type (might be due to invalid IL or missing references)
		//IL_264b: Expected O, but got Unknown
		//IL_26df: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e9: Expected O, but got Unknown
		//IL_2730: Unknown result type (might be due to invalid IL or missing references)
		//IL_273a: Expected O, but got Unknown
		//IL_2e9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea7: Expected O, but got Unknown
		//IL_2eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ebe: Expected O, but got Unknown
		//IL_2ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed5: Expected O, but got Unknown
		//IL_2ee2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eec: Expected O, but got Unknown
		//IL_2ef9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f03: Expected O, but got Unknown
		//IL_2f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f1a: Expected O, but got Unknown
		//IL_2f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f31: Expected O, but got Unknown
		//IL_2f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f48: Expected O, but got Unknown
		//IL_2f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f5f: Expected O, but got Unknown
		//IL_3003: Unknown result type (might be due to invalid IL or missing references)
		//IL_300d: Expected O, but got Unknown
		//IL_31d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_31e1: Expected O, but got Unknown
		//IL_31ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_31f8: Expected O, but got Unknown
		//IL_320b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3215: Expected O, but got Unknown
		//IL_32e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ea: Expected O, but got Unknown
		//IL_3339: Unknown result type (might be due to invalid IL or missing references)
		//IL_3343: Expected O, but got Unknown
		//IL_3364: Unknown result type (might be due to invalid IL or missing references)
		//IL_336e: Expected O, but got Unknown
		//IL_3391: Unknown result type (might be due to invalid IL or missing references)
		//IL_340d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3417: Expected O, but got Unknown
		//IL_344a: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c4: Expected O, but got Unknown
		//IL_3507: Unknown result type (might be due to invalid IL or missing references)
		//IL_3589: Unknown result type (might be due to invalid IL or missing references)
		//IL_3593: Expected O, but got Unknown
		//IL_35e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ee: Expected O, but got Unknown
		//IL_3619: Unknown result type (might be due to invalid IL or missing references)
		//IL_3623: Expected O, but got Unknown
		//IL_3671: Unknown result type (might be due to invalid IL or missing references)
		//IL_367b: Expected O, but got Unknown
		//IL_3790: Unknown result type (might be due to invalid IL or missing references)
		//IL_37fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3805: Expected O, but got Unknown
		//IL_3812: Unknown result type (might be due to invalid IL or missing references)
		//IL_381c: Expected O, but got Unknown
		//IL_3829: Unknown result type (might be due to invalid IL or missing references)
		//IL_3833: Expected O, but got Unknown
		//IL_39b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_39bf: Expected O, but got Unknown
		//IL_39f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a73: Expected O, but got Unknown
		//IL_3a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aa0: Expected O, but got Unknown
		//IL_3b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b32: Expected O, but got Unknown
		//IL_3c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c75: Expected O, but got Unknown
		//IL_3cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ce7: Expected O, but got Unknown
		//IL_3d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d2d: Expected O, but got Unknown
		//IL_3de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3df0: Expected O, but got Unknown
		//IL_3e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e95: Expected O, but got Unknown
		//IL_3f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f43: Expected O, but got Unknown
		//IL_4033: Unknown result type (might be due to invalid IL or missing references)
		//IL_403d: Expected O, but got Unknown
		//IL_437e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4388: Expected O, but got Unknown
		//IL_4395: Unknown result type (might be due to invalid IL or missing references)
		//IL_439f: Expected O, but got Unknown
		//IL_43ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b6: Expected O, but got Unknown
		//IL_43d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_43e3: Expected O, but got Unknown
		//IL_4467: Unknown result type (might be due to invalid IL or missing references)
		//IL_4471: Expected O, but got Unknown
		//IL_4505: Unknown result type (might be due to invalid IL or missing references)
		//IL_450f: Expected O, but got Unknown
		//IL_4597: Unknown result type (might be due to invalid IL or missing references)
		//IL_45a1: Expected O, but got Unknown
		//IL_468e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4698: Expected O, but got Unknown
		//IL_46bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_46c5: Expected O, but got Unknown
		//IL_475c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4766: Expected O, but got Unknown
		//IL_4824: Unknown result type (might be due to invalid IL or missing references)
		//IL_482e: Expected O, but got Unknown
		//IL_4f49: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f53: Expected O, but got Unknown
		//IL_4f60: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f6a: Expected O, but got Unknown
		//IL_4f77: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f81: Expected O, but got Unknown
		//IL_50f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_50fd: Expected O, but got Unknown
		//IL_51ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_51b7: Expected O, but got Unknown
		//IL_5339: Unknown result type (might be due to invalid IL or missing references)
		//IL_5343: Expected O, but got Unknown
		//IL_5373: Unknown result type (might be due to invalid IL or missing references)
		//IL_53e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_53ee: Expected O, but got Unknown
		//IL_53fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5405: Expected O, but got Unknown
		//IL_5429: Unknown result type (might be due to invalid IL or missing references)
		//IL_5433: Expected O, but got Unknown
		//IL_5440: Unknown result type (might be due to invalid IL or missing references)
		//IL_544a: Expected O, but got Unknown
		//IL_54c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_54cb: Expected O, but got Unknown
		//IL_54fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_556c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5576: Expected O, but got Unknown
		//IL_5583: Unknown result type (might be due to invalid IL or missing references)
		//IL_558d: Expected O, but got Unknown
		//IL_55b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_55bb: Expected O, but got Unknown
		//IL_55c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_55d2: Expected O, but got Unknown
		//IL_5649: Unknown result type (might be due to invalid IL or missing references)
		//IL_5653: Expected O, but got Unknown
		//IL_5683: Unknown result type (might be due to invalid IL or missing references)
		//IL_56f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_56fe: Expected O, but got Unknown
		//IL_570b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5715: Expected O, but got Unknown
		//IL_5739: Unknown result type (might be due to invalid IL or missing references)
		//IL_5743: Expected O, but got Unknown
		//IL_5750: Unknown result type (might be due to invalid IL or missing references)
		//IL_575a: Expected O, but got Unknown
		//IL_59c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_59d3: Expected O, but got Unknown
		//IL_59e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_59f0: Expected O, but got Unknown
		//IL_5a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a79: Expected O, but got Unknown
		//IL_5a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a8b: Expected O, but got Unknown
		//IL_5aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5aaf: Expected O, but got Unknown
		//IL_5ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ac1: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ISOMain));
		TreeNode val = new TreeNode("F1", 2, -2);
		TreeNode val2 = new TreeNode("F2", -2, -2);
		TreeNode val3 = new TreeNode("F3", -2, -2);
		TreeNode val4 = new TreeNode("Fuel Trim", -2, -2);
		TreeNode val5 = new TreeNode("L1", -2, -2);
		TreeNode val6 = new TreeNode("L2", -2, -2);
		TreeNode val7 = new TreeNode("L3", -2, -2);
		TreeNode val8 = new TreeNode("I1", -2, -2);
		TreeNode val9 = new TreeNode("I2", -2, -2);
		TreeNode val10 = new TreeNode("I3", -2, -2);
		TreeNode val11 = new TreeNode("I4", -2, -2);
		TreeNode val12 = new TreeNode("Ignition Trim", -2, -2);
		TreeNode val13 = new TreeNode("Air/Fuel", -2, -2);
		TreeNode val14 = new TreeNode("Idle", -2, -2);
		TreeNode val15 = new TreeNode("Exhaust Valve", -2, -2);
		TreeNode val16 = new TreeNode("2nd Throttle", -2, -2);
		TreeNode val17 = new TreeNode("Table ", -2, -2, (TreeNode[])(object)new TreeNode[16]
		{
			val, val2, val3, val4, val5, val6, val7, val8, val9, val10,
			val11, val12, val13, val14, val15, val16
		});
		TreeNode val18 = new TreeNode("revLimit");
		TreeNode val19 = new TreeNode("Fan");
		TreeNode val20 = new TreeNode("Speed");
		TreeNode val21 = new TreeNode("Pulse");
		TreeNode val22 = new TreeNode("IFO");
		TreeNode val23 = new TreeNode("Target A/F");
		TreeNode val24 = new TreeNode("Parameters", -2, -2, (TreeNode[])(object)new TreeNode[6] { val18, val19, val20, val21, val22, val23 });
		TreeNode val25 = new TreeNode("SAI");
		TreeNode val26 = new TreeNode("EXBV");
		TreeNode val27 = new TreeNode("O2");
		TreeNode val28 = new TreeNode("Dashboard");
		TreeNode val29 = new TreeNode("2nd Throttle");
		TreeNode val30 = new TreeNode("2nd TPS");
		TreeNode val31 = new TreeNode("Devices", -2, -2, (TreeNode[])(object)new TreeNode[6] { val25, val26, val27, val28, val29, val30 });
		TreeNode val32 = new TreeNode("Serial # : ", -2, -2);
		TreeNode val33 = new TreeNode("Map : ", -2, -2);
		TreeNode val34 = new TreeNode("Checksum : ", -2, -2);
		TreeNode val35 = new TreeNode("ECU Infos", -2, -2, (TreeNode[])(object)new TreeNode[3] { val32, val33, val34 });
		TreeNode val36 = new TreeNode("Tacho");
		TreeNode val37 = new TreeNode("Cooling Fan");
		TreeNode val38 = new TreeNode("Fuel Pump");
		TreeNode val39 = new TreeNode("Idle Stepper");
		TreeNode val40 = new TreeNode("Purge Valve");
		TreeNode val41 = new TreeNode("SAI");
		TreeNode val42 = new TreeNode("Air Flap");
		TreeNode val43 = new TreeNode("Exhaust Valve");
		TreeNode val44 = new TreeNode("", -2, -2);
		TreeNode val45 = new TreeNode("Adjust EXBV");
		TreeNode val46 = new TreeNode("Reset ISCV");
		TreeNode val47 = new TreeNode("Reset Adapt");
		TreeNode val48 = new TreeNode("", -2, -2);
		TreeNode val49 = new TreeNode("                                    ", -2, -2);
		TreeNode val50 = new TreeNode("Injection Pulse", -2, -2, (TreeNode[])(object)new TreeNode[1] { val49 });
		TreeNode val51 = new TreeNode("                                    ", -2, -2);
		TreeNode val52 = new TreeNode("                                    ", -2, -2);
		TreeNode val53 = new TreeNode("Ignition Timing", -2, -2, (TreeNode[])(object)new TreeNode[2] { val51, val52 });
		TreeNode val54 = new TreeNode("                                    ", -2, -2);
		TreeNode val55 = new TreeNode("                                    ", -2, -2);
		TreeNode val56 = new TreeNode("Throttle", -2, -2, (TreeNode[])(object)new TreeNode[2] { val54, val55 });
		TreeNode val57 = new TreeNode("                                    ", -2, -2);
		TreeNode val58 = new TreeNode("                                    ", -2, -2);
		TreeNode val59 = new TreeNode("                                    ", -2, -2);
		TreeNode val60 = new TreeNode("O2 Sensor", -2, -2, (TreeNode[])(object)new TreeNode[3] { val57, val58, val59 });
		TreeNode val61 = new TreeNode("                                    ", -2, -2);
		TreeNode val62 = new TreeNode("                                    ", -2, -2);
		TreeNode val63 = new TreeNode("Idle", -2, -2, (TreeNode[])(object)new TreeNode[2] { val61, val62 });
		TreeNode val64 = new TreeNode("                                    ", -2, -2);
		TreeNode val65 = new TreeNode("EXBV", -2, -2, (TreeNode[])(object)new TreeNode[1] { val64 });
		TreeNode val66 = new TreeNode("                                    ", -2, -2);
		TreeNode val67 = new TreeNode("Temperature", -2, -2, (TreeNode[])(object)new TreeNode[1] { val66 });
		TreeNode val68 = new TreeNode("                                    ", -2, -2);
		TreeNode val69 = new TreeNode("Barometric", -2, -2, (TreeNode[])(object)new TreeNode[1] { val68 });
		TreeNode val70 = new TreeNode("                                    ", -2, -2);
		TreeNode val71 = new TreeNode("Engine Load", -2, -2, (TreeNode[])(object)new TreeNode[1] { val70 });
		TreeNode val72 = new TreeNode("                                    ", -2, -2);
		TreeNode val73 = new TreeNode("Fuel Level", -2, -2, (TreeNode[])(object)new TreeNode[1] { val72 });
		TreeNode val74 = new TreeNode("Clutch");
		TreeNode val75 = new TreeNode("Fuel Pump");
		TreeNode val76 = new TreeNode("Start Relay");
		TreeNode val77 = new TreeNode("Air Flap");
		TreeNode val78 = new TreeNode("Other", -2, -2, (TreeNode[])(object)new TreeNode[4] { val74, val75, val76, val77 });
		cModifMenu = new ContextMenuStrip(components);
		modifSubMenu = new ToolStripMenuItem();
		cReadTimer = new Timer(components);
		_mapInfos = new Label();
		menuStrip = new MenuStrip();
		fileMenuItem = new ToolStripMenuItem();
		openMenuItem = new ToolStripMenuItem();
		compareMenuItem = new ToolStripMenuItem();
		saveMenuItem = new ToolStripMenuItem();
		saveBinMenuItem = new ToolStripMenuItem();
		sepPMenuItem = new ToolStripSeparator();
		PCIIIMenuItem = new ToolStripMenuItem();
		sepQMenuItem = new ToolStripSeparator();
		aboutMenuItem = new ToolStripMenuItem();
		quitMenuItem = new ToolStripMenuItem();
		editMenuItem = new ToolStripMenuItem();
		copyMenuItem = new ToolStripMenuItem();
		pasteMenuItem = new ToolStripMenuItem();
		sepTMenuItem = new ToolStripSeparator();
		exportMenuItem = new ToolStripMenuItem();
		sepEMenuItem = new ToolStripSeparator();
		useTrimMenuItem = new ToolStripMenuItem();
		TrimToLMenuItem = new ToolStripMenuItem();
		fusionMenuItem = new ToolStripMenuItem();
		displayMenuItem = new ToolStripMenuItem();
		graphMenuItem = new ToolStripMenuItem();
		infosMapMenuItem = new ToolStripMenuItem();
		logMenuItem = new ToolStripMenuItem();
		sepSMenuItem = new ToolStripSeparator();
		fullScreenMenuItem = new ToolStripMenuItem();
		ECUMenuItem = new ToolStripMenuItem();
		connectMenuItem = new ToolStripMenuItem();
		sepLMenuItem = new ToolStripSeparator();
		historyMenuItem = new ToolStripMenuItem();
		readMapMenuItem = new ToolStripMenuItem();
		sepRMenuItem = new ToolStripSeparator();
		flashMenuItem = new ToolStripMenuItem();
		safeMenuItem = new ToolStripMenuItem();
		toolStripSepR = new ToolStripSeparator();
		razTPSMenuItem = new ToolStripMenuItem();
		eraseCodesMenuItem = new ToolStripMenuItem();
		optionsMenuItem = new ToolStripMenuItem();
		autoMenuItem = new ToolStripMenuItem();
		DevMenuItem = new ToolStripMenuItem();
		serialMenuItem = new ToolStripMenuItem();
		uSBMenuItem = new ToolStripMenuItem();
		languageMenuItem = new ToolStripMenuItem();
		englishMenuItem = new ToolStripMenuItem();
		frenchMenuItem = new ToolStripMenuItem();
		germanMenuItem = new ToolStripMenuItem();
		italianMenuItem = new ToolStripMenuItem();
		spanishMenuItem = new ToolStripMenuItem();
		portugueseMenuItem = new ToolStripMenuItem();
		openFileDialog = new OpenFileDialog();
		saveFileDialog = new SaveFileDialog();
		tv_Image = new ImageList(components);
		_vehInfos = new Label();
		_lbMap = new Label();
		gbTable = new GroupBox();
		panelTable = new DoubleBufferPanel();
		gbMap = new GroupBox();
		valueUD = new NumericUpDown();
		vUDpanel = new Panel();
		tvMap = new TreeView();
		gbVehicule = new GroupBox();
		tvVehicule = new TreeView();
		statusStrip = new StatusStrip();
		blankStatus = new ToolStripStatusLabel();
		battStatus = new ToolStripStatusLabel();
		loopStatus = new ToolStripStatusLabel();
		tpsStatus = new ToolStripStatusLabel();
		fileStatus = new ToolStripStatusLabel();
		ledStatus = new ToolStripStatusLabel();
		cActiveMenu = new ContextMenuStrip(components);
		activeSubMenu = new ToolStripMenuItem();
		activeAppTimer = new Timer(components);
		editUpDown = new NumericUpDown();
		panelDiag = new Panel();
		_lbCodes = new Label();
		_lbDesc = new Label();
		gbError = new GroupBox();
		panelCodes = new Panel();
		listCodes = new ListBox();
		tbDescription = new TextBox();
		_lbTests = new Label();
		gbTests = new GroupBox();
		adjustUD = new NumericUpDown();
		tvTests = new TreeView();
		_lbDash = new Label();
		sensor_minus = new PictureBox();
		sensor_plus = new PictureBox();
		gbDiag = new GroupBox();
		pbDash = new PictureBox();
		_lbSensors = new Label();
		gbSensor = new GroupBox();
		tvSensor = new TreeView();
		lbDevList = new ListBox();
		cResetMenu = new ContextMenuStrip(components);
		resetSubMenu = new ToolStripMenuItem();
		Logo_Panel = new Panel();
		EDpanel = new Panel();
		cCopyMenu = new ContextMenuStrip(components);
		copySubMenu = new ToolStripMenuItem();
		pasteSubMenu = new ToolStripMenuItem();
		BtnRight = new Button();
		BtnMid = new Button();
		BtnLeft = new Button();
		cTrimMenu = new ContextMenuStrip(components);
		trimSubMenu = new ToolStripMenuItem();
		cmbPortName = new ListBox();
		((Control)cModifMenu).SuspendLayout();
		((Control)menuStrip).SuspendLayout();
		((Control)gbTable).SuspendLayout();
		((Control)gbMap).SuspendLayout();
		((ISupportInitialize)valueUD).BeginInit();
		((Control)gbVehicule).SuspendLayout();
		((Control)statusStrip).SuspendLayout();
		((Control)cActiveMenu).SuspendLayout();
		((ISupportInitialize)editUpDown).BeginInit();
		((Control)panelDiag).SuspendLayout();
		((Control)gbError).SuspendLayout();
		((Control)panelCodes).SuspendLayout();
		((Control)gbTests).SuspendLayout();
		((ISupportInitialize)adjustUD).BeginInit();
		((ISupportInitialize)sensor_minus).BeginInit();
		((ISupportInitialize)sensor_plus).BeginInit();
		((Control)gbDiag).SuspendLayout();
		((ISupportInitialize)pbDash).BeginInit();
		((Control)gbSensor).SuspendLayout();
		((Control)cResetMenu).SuspendLayout();
		((Control)cCopyMenu).SuspendLayout();
		((Control)cTrimMenu).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)cModifMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)modifSubMenu });
		((Control)cModifMenu).Name = "cEditMenu";
		((Control)cModifMenu).Size = new Size(120, 26);
		((ToolStripDropDown)cModifMenu).Opening += cModifMenu_Opening;
		((Control)cModifMenu).Click += cEditMenu_Click;
		((ToolStripItem)modifSubMenu).Name = "modifSubMenu";
		((ToolStripItem)modifSubMenu).Size = new Size(119, 22);
		((ToolStripItem)modifSubMenu).Tag = -1;
		((ToolStripItem)modifSubMenu).Text = "Modifier";
		cReadTimer.Interval = 10;
		cReadTimer.Tick += checkTimer_Tick;
		((Control)_mapInfos).BackColor = Color.DarkGray;
		((Control)_mapInfos).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_mapInfos).ForeColor = SystemColors.Menu;
		((Control)_mapInfos).Location = new Point(7, 114);
		((Control)_mapInfos).MinimumSize = new Size(172, 15);
		((Control)_mapInfos).Name = "_mapInfos";
		((Control)_mapInfos).Size = new Size(172, 15);
		((Control)_mapInfos).TabIndex = 12;
		((Control)_mapInfos).Text = "Map";
		_mapInfos.TextAlign = (ContentAlignment)16;
		((Control)_mapInfos).Click += _mapInfos_Click;
		((Control)_mapInfos).Paint += new PaintEventHandler(_Label_Paint);
		((ToolStrip)menuStrip).BackColor = SystemColors.Control;
		((Control)menuStrip).BackgroundImageLayout = (ImageLayout)0;
		((Control)menuStrip).Dock = (DockStyle)0;
		((ToolStrip)menuStrip).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
		{
			(ToolStripItem)fileMenuItem,
			(ToolStripItem)editMenuItem,
			(ToolStripItem)displayMenuItem,
			(ToolStripItem)ECUMenuItem,
			(ToolStripItem)optionsMenuItem
		});
		((Control)menuStrip).Location = new Point(0, 0);
		((Control)menuStrip).Name = "menuStrip";
		((ToolStrip)menuStrip).RenderMode = (ToolStripRenderMode)2;
		menuStrip.ShowItemToolTips = true;
		((Control)menuStrip).Size = new Size(327, 24);
		menuStrip.Stretch = false;
		((Control)menuStrip).TabIndex = 20;
		menuStrip.MenuActivate += menuStrip_MenuActivate;
		((ToolStripItem)fileMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripDropDownItem)fileMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[9]
		{
			(ToolStripItem)openMenuItem,
			(ToolStripItem)compareMenuItem,
			(ToolStripItem)saveMenuItem,
			(ToolStripItem)saveBinMenuItem,
			(ToolStripItem)sepPMenuItem,
			(ToolStripItem)PCIIIMenuItem,
			(ToolStripItem)sepQMenuItem,
			(ToolStripItem)aboutMenuItem,
			(ToolStripItem)quitMenuItem
		});
		((ToolStripItem)fileMenuItem).Name = "fileMenuItem";
		((ToolStripItem)fileMenuItem).Padding = new Padding(0);
		((ToolStripItem)fileMenuItem).Size = new Size(29, 20);
		((ToolStripItem)fileMenuItem).Text = "&File";
		((ToolStripItem)openMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)openMenuItem).Name = "openMenuItem";
		((ToolStripItem)openMenuItem).Size = new Size(164, 22);
		((ToolStripItem)openMenuItem).Text = "&Open Map File";
		((ToolStripItem)openMenuItem).TextDirection = (ToolStripTextDirection)1;
		((ToolStripItem)openMenuItem).Click += openMenuItem_Click;
		((ToolStripItem)compareMenuItem).Enabled = false;
		((ToolStripItem)compareMenuItem).Name = "compareMenuItem";
		((ToolStripItem)compareMenuItem).Size = new Size(164, 22);
		((ToolStripItem)compareMenuItem).Text = "Co&mpare with";
		((ToolStripItem)compareMenuItem).Click += openCompareMenu_Click;
		((ToolStripItem)saveMenuItem).Enabled = false;
		((ToolStripItem)saveMenuItem).Name = "saveMenuItem";
		((ToolStripItem)saveMenuItem).Size = new Size(164, 22);
		((ToolStripItem)saveMenuItem).Text = "&Save Map File";
		((ToolStripItem)saveMenuItem).Click += saveMenuItem_Click;
		((ToolStripItem)saveBinMenuItem).Name = "saveBinMenuItem";
		((ToolStripItem)saveBinMenuItem).Size = new Size(164, 22);
		((ToolStripItem)saveBinMenuItem).Text = "Save bin";
		((ToolStripItem)saveBinMenuItem).Visible = false;
		((ToolStripItem)saveBinMenuItem).Click += saveBinMenuItem_Click;
		((ToolStripItem)sepPMenuItem).Name = "sepPMenuItem";
		((ToolStripItem)sepPMenuItem).Size = new Size(161, 6);
		((ToolStripItem)PCIIIMenuItem).Enabled = false;
		((ToolStripItem)PCIIIMenuItem).Name = "PCIIIMenuItem";
		((ToolStripItem)PCIIIMenuItem).Size = new Size(164, 22);
		((ToolStripItem)PCIIIMenuItem).Text = "&Import PCIII Map";
		((ToolStripItem)PCIIIMenuItem).Click += openPCIIIMenu_Click;
		((ToolStripItem)sepQMenuItem).Name = "sepQMenuItem";
		((ToolStripItem)sepQMenuItem).Size = new Size(161, 6);
		((ToolStripItem)aboutMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)aboutMenuItem).Name = "aboutMenuItem";
		((ToolStripItem)aboutMenuItem).Size = new Size(164, 22);
		((ToolStripItem)aboutMenuItem).Text = "&About";
		((ToolStripItem)aboutMenuItem).Click += aboutMenuItem_Click;
		((ToolStripItem)quitMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)quitMenuItem).Name = "quitMenuItem";
		((ToolStripItem)quitMenuItem).Size = new Size(164, 22);
		((ToolStripItem)quitMenuItem).Text = "&Exit";
		((ToolStripItem)quitMenuItem).Click += quitMenuItem_Click;
		((ToolStripItem)editMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripDropDownItem)editMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[8]
		{
			(ToolStripItem)copyMenuItem,
			(ToolStripItem)pasteMenuItem,
			(ToolStripItem)sepTMenuItem,
			(ToolStripItem)exportMenuItem,
			(ToolStripItem)sepEMenuItem,
			(ToolStripItem)useTrimMenuItem,
			(ToolStripItem)TrimToLMenuItem,
			(ToolStripItem)fusionMenuItem
		});
		((ToolStripItem)editMenuItem).Name = "editMenuItem";
		((ToolStripItem)editMenuItem).Size = new Size(39, 20);
		((ToolStripItem)editMenuItem).Text = "&Edit";
		((ToolStripItem)copyMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)copyMenuItem).Name = "copyMenuItem";
		((ToolStripItem)copyMenuItem).Size = new Size(209, 22);
		((ToolStripItem)copyMenuItem).Text = "&Copy Table";
		((ToolStripItem)copyMenuItem).Click += copyMenuItem_Click;
		((ToolStripItem)pasteMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)pasteMenuItem).Enabled = false;
		((ToolStripItem)pasteMenuItem).Name = "pasteMenuItem";
		((ToolStripItem)pasteMenuItem).Size = new Size(209, 22);
		((ToolStripItem)pasteMenuItem).Text = "&Paste Table";
		((ToolStripItem)pasteMenuItem).Click += pasteMenuItem_Click;
		((ToolStripItem)sepTMenuItem).Name = "sepTMenuItem";
		((ToolStripItem)sepTMenuItem).Size = new Size(206, 6);
		((ToolStripItem)exportMenuItem).Enabled = false;
		((ToolStripItem)exportMenuItem).Name = "exportMenuItem";
		((ToolStripItem)exportMenuItem).Size = new Size(209, 22);
		((ToolStripItem)exportMenuItem).Text = "E&xport Table";
		((ToolStripItem)exportMenuItem).Click += exportMenuItem_Click;
		((ToolStripItem)sepEMenuItem).Name = "sepEMenuItem";
		((ToolStripItem)sepEMenuItem).Size = new Size(206, 6);
		((ToolStripItem)useTrimMenuItem).Name = "useTrimMenuItem";
		((ToolStripItem)useTrimMenuItem).Size = new Size(209, 22);
		((ToolStripItem)useTrimMenuItem).Text = "Use Trim F for all F Tables";
		((ToolStripItem)useTrimMenuItem).Click += useTrimMenuItem_Click;
		((ToolStripItem)TrimToLMenuItem).Enabled = false;
		((ToolStripItem)TrimToLMenuItem).Name = "TrimToLMenuItem";
		((ToolStripItem)TrimToLMenuItem).Size = new Size(209, 22);
		((ToolStripItem)TrimToLMenuItem).Text = "Apply Trim to L Tables";
		((ToolStripItem)TrimToLMenuItem).Click += TrimToLMenuItem_Click;
		((ToolStripItem)fusionMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)fusionMenuItem).Enabled = false;
		((ToolStripItem)fusionMenuItem).Name = "fusionMenuItem";
		((ToolStripItem)fusionMenuItem).Size = new Size(209, 22);
		((ToolStripItem)fusionMenuItem).Text = "Commit &Trims";
		((ToolStripItem)fusionMenuItem).Click += fusionMenuItem_Click;
		((ToolStripItem)fusionMenuItem).Paint += new PaintEventHandler(fusionMenuItem_Paint);
		((ToolStripDropDownItem)displayMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
		{
			(ToolStripItem)graphMenuItem,
			(ToolStripItem)infosMapMenuItem,
			(ToolStripItem)logMenuItem,
			(ToolStripItem)sepSMenuItem,
			(ToolStripItem)fullScreenMenuItem
		});
		((ToolStripItem)displayMenuItem).Name = "displayMenuItem";
		((ToolStripItem)displayMenuItem).Size = new Size(57, 20);
		((ToolStripItem)displayMenuItem).Text = "&Display";
		((ToolStripItem)graphMenuItem).Name = "graphMenuItem";
		graphMenuItem.ShortcutKeys = (Keys)116;
		((ToolStripItem)graphMenuItem).Size = new Size(156, 22);
		((ToolStripItem)graphMenuItem).Text = "&Graphic";
		((ToolStripItem)graphMenuItem).Click += graphMenuItem_Click;
		((ToolStripItem)infosMapMenuItem).Enabled = false;
		((ToolStripItem)infosMapMenuItem).Name = "infosMapMenuItem";
		((ToolStripItem)infosMapMenuItem).Size = new Size(156, 22);
		((ToolStripItem)infosMapMenuItem).Text = "&Map Infos";
		((ToolStripItem)infosMapMenuItem).Click += viewInfosMap_Click;
		((ToolStripItem)logMenuItem).Name = "logMenuItem";
		((ToolStripItem)logMenuItem).Size = new Size(156, 22);
		((ToolStripItem)logMenuItem).Text = "&Logs";
		((ToolStripItem)logMenuItem).Click += viewLog_Click;
		((ToolStripItem)sepSMenuItem).Name = "sepSMenuItem";
		((ToolStripItem)sepSMenuItem).Size = new Size(153, 6);
		((ToolStripItem)fullScreenMenuItem).Name = "fullScreenMenuItem";
		fullScreenMenuItem.ShortcutKeys = (Keys)121;
		((ToolStripItem)fullScreenMenuItem).Size = new Size(156, 22);
		((ToolStripItem)fullScreenMenuItem).Text = "Full Screen";
		((ToolStripItem)fullScreenMenuItem).Click += fullScreenMenuItem_Click;
		((ToolStripItem)ECUMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripDropDownItem)ECUMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[10]
		{
			(ToolStripItem)connectMenuItem,
			(ToolStripItem)sepLMenuItem,
			(ToolStripItem)historyMenuItem,
			(ToolStripItem)readMapMenuItem,
			(ToolStripItem)sepRMenuItem,
			(ToolStripItem)flashMenuItem,
			(ToolStripItem)safeMenuItem,
			(ToolStripItem)toolStripSepR,
			(ToolStripItem)razTPSMenuItem,
			(ToolStripItem)eraseCodesMenuItem
		});
		((ToolStripItem)ECUMenuItem).Name = "ECUMenuItem";
		((ToolStripItem)ECUMenuItem).Size = new Size(41, 20);
		((ToolStripItem)ECUMenuItem).Text = "E&CU";
		((ToolStripItem)connectMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)connectMenuItem).Enabled = false;
		((ToolStripItem)connectMenuItem).Name = "connectMenuItem";
		((ToolStripItem)connectMenuItem).Size = new Size(165, 22);
		((ToolStripItem)connectMenuItem).Text = "&Connect";
		((ToolStripItem)connectMenuItem).Click += connectMenuItem_Click;
		((ToolStripItem)sepLMenuItem).Name = "sepLMenuItem";
		((ToolStripItem)sepLMenuItem).Size = new Size(162, 6);
		((ToolStripItem)historyMenuItem).Enabled = false;
		((ToolStripItem)historyMenuItem).Name = "historyMenuItem";
		((ToolStripItem)historyMenuItem).Size = new Size(165, 22);
		((ToolStripItem)historyMenuItem).Text = "&History";
		((ToolStripItem)historyMenuItem).Click += historyMenuItem_Click;
		((ToolStripItem)readMapMenuItem).Enabled = false;
		((ToolStripItem)readMapMenuItem).Name = "readMapMenuItem";
		((ToolStripItem)readMapMenuItem).Size = new Size(165, 22);
		((ToolStripItem)readMapMenuItem).Text = "Read &Map";
		((ToolStripItem)readMapMenuItem).Click += readMapMenuItem_Click;
		((ToolStripItem)sepRMenuItem).Name = "sepRMenuItem";
		((ToolStripItem)sepRMenuItem).Size = new Size(162, 6);
		((ToolStripItem)flashMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)flashMenuItem).Enabled = false;
		((ToolStripItem)flashMenuItem).Name = "flashMenuItem";
		((ToolStripItem)flashMenuItem).Size = new Size(165, 22);
		((ToolStripItem)flashMenuItem).Text = "&Write ECU";
		((ToolStripItem)flashMenuItem).Click += flashMenuItem_Click;
		((ToolStripItem)safeMenuItem).Enabled = false;
		((ToolStripItem)safeMenuItem).Name = "safeMenuItem";
		((ToolStripItem)safeMenuItem).Size = new Size(165, 22);
		((ToolStripItem)safeMenuItem).Text = "ECU &Recovery";
		((ToolStripItem)safeMenuItem).Click += safeMenuItem_Click;
		((ToolStripItem)toolStripSepR).Name = "toolStripSepR";
		((ToolStripItem)toolStripSepR).Size = new Size(162, 6);
		((ToolStripItem)razTPSMenuItem).Enabled = false;
		((ToolStripItem)razTPSMenuItem).Name = "razTPSMenuItem";
		((ToolStripItem)razTPSMenuItem).Size = new Size(165, 22);
		((ToolStripItem)razTPSMenuItem).Text = "Raz &TPS";
		((ToolStripItem)razTPSMenuItem).Click += razTPSMenuItem_Click;
		((ToolStripItem)eraseCodesMenuItem).Enabled = false;
		((ToolStripItem)eraseCodesMenuItem).Name = "eraseCodesMenuItem";
		((ToolStripItem)eraseCodesMenuItem).Size = new Size(165, 22);
		((ToolStripItem)eraseCodesMenuItem).Text = "E&rase Error Codes";
		((ToolStripItem)eraseCodesMenuItem).Click += eraseCodesMenuItem_Click;
		((ToolStripDropDownItem)optionsMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)autoMenuItem,
			(ToolStripItem)DevMenuItem,
			(ToolStripItem)languageMenuItem
		});
		((ToolStripItem)optionsMenuItem).Name = "optionsMenuItem";
		((ToolStripItem)optionsMenuItem).Size = new Size(61, 20);
		((ToolStripItem)optionsMenuItem).Text = "&Options";
		((ToolStripItem)autoMenuItem).Name = "autoMenuItem";
		((ToolStripItem)autoMenuItem).Size = new Size(148, 22);
		((ToolStripItem)autoMenuItem).Text = "Auto-connect";
		((ToolStripItem)autoMenuItem).Click += autoMenuItem_Click;
		((ToolStripItem)DevMenuItem).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripDropDownItem)DevMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)serialMenuItem,
			(ToolStripItem)uSBMenuItem
		});
		((ToolStripItem)DevMenuItem).Name = "DevMenuItem";
		((ToolStripItem)DevMenuItem).Size = new Size(148, 22);
		((ToolStripItem)DevMenuItem).Text = "&Interface";
		((ToolStripDropDownItem)DevMenuItem).DropDownOpening += serialMenuItemDropDown;
		((ToolStripItem)serialMenuItem).Enabled = false;
		((ToolStripItem)serialMenuItem).Name = "serialMenuItem";
		((ToolStripItem)serialMenuItem).Size = new Size(102, 22);
		((ToolStripItem)serialMenuItem).Text = "Serial";
		((ToolStripItem)uSBMenuItem).Enabled = false;
		((ToolStripItem)uSBMenuItem).Name = "uSBMenuItem";
		((ToolStripItem)uSBMenuItem).Size = new Size(102, 22);
		((ToolStripItem)uSBMenuItem).Text = "USB";
		((ToolStripDropDownItem)languageMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[6]
		{
			(ToolStripItem)englishMenuItem,
			(ToolStripItem)frenchMenuItem,
			(ToolStripItem)germanMenuItem,
			(ToolStripItem)italianMenuItem,
			(ToolStripItem)spanishMenuItem,
			(ToolStripItem)portugueseMenuItem
		});
		((ToolStripItem)languageMenuItem).Name = "languageMenuItem";
		((ToolStripItem)languageMenuItem).Size = new Size(148, 22);
		((ToolStripItem)languageMenuItem).Text = "&Language";
		((ToolStripItem)englishMenuItem).Name = "englishMenuItem";
		((ToolStripItem)englishMenuItem).Size = new Size(134, 22);
		((ToolStripItem)englishMenuItem).Tag = "0";
		((ToolStripItem)englishMenuItem).Text = "&English";
		((ToolStripItem)englishMenuItem).Click += langMenuItem_Click;
		((ToolStripItem)frenchMenuItem).Name = "frenchMenuItem";
		((ToolStripItem)frenchMenuItem).Size = new Size(134, 22);
		((ToolStripItem)frenchMenuItem).Tag = "1";
		((ToolStripItem)frenchMenuItem).Text = "&French";
		((ToolStripItem)frenchMenuItem).Click += langMenuItem_Click;
		((ToolStripItem)germanMenuItem).Name = "germanMenuItem";
		((ToolStripItem)germanMenuItem).Size = new Size(134, 22);
		((ToolStripItem)germanMenuItem).Tag = "2";
		((ToolStripItem)germanMenuItem).Text = "German";
		((ToolStripItem)germanMenuItem).Click += langMenuItem_Click;
		((ToolStripItem)italianMenuItem).Name = "italianMenuItem";
		((ToolStripItem)italianMenuItem).Size = new Size(134, 22);
		((ToolStripItem)italianMenuItem).Tag = "3";
		((ToolStripItem)italianMenuItem).Text = "Italian";
		((ToolStripItem)italianMenuItem).Click += langMenuItem_Click;
		((ToolStripItem)spanishMenuItem).Name = "spanishMenuItem";
		((ToolStripItem)spanishMenuItem).Size = new Size(134, 22);
		((ToolStripItem)spanishMenuItem).Tag = "4";
		((ToolStripItem)spanishMenuItem).Text = "Spanish";
		((ToolStripItem)spanishMenuItem).Click += langMenuItem_Click;
		((ToolStripItem)portugueseMenuItem).Name = "portugueseMenuItem";
		((ToolStripItem)portugueseMenuItem).Size = new Size(134, 22);
		((ToolStripItem)portugueseMenuItem).Tag = "5";
		((ToolStripItem)portugueseMenuItem).Text = "Portuguese";
		((ToolStripItem)portugueseMenuItem).Click += langMenuItem_Click;
		tv_Image.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("tv_Image.ImageStream");
		tv_Image.TransparentColor = Color.Transparent;
		tv_Image.Images.SetKeyName(0, "CheckOff.PNG");
		tv_Image.Images.SetKeyName(1, "CheckOn.PNG");
		tv_Image.Images.SetKeyName(2, "Grid.PNG");
		tv_Image.Images.SetKeyName(3, "DevOff.png");
		tv_Image.Images.SetKeyName(4, "DevOn.png");
		tv_Image.Images.SetKeyName(5, "Edit.png");
		tv_Image.Images.SetKeyName(6, "Roll.png");
		tv_Image.Images.SetKeyName(7, "Arrow.png");
		tv_Image.Images.SetKeyName(8, "PuceOff.png");
		tv_Image.Images.SetKeyName(9, "PuceOn.png");
		((Control)_vehInfos).BackColor = Color.DarkGray;
		((Control)_vehInfos).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_vehInfos).ForeColor = SystemColors.Menu;
		((Control)_vehInfos).Location = new Point(7, 26);
		((Control)_vehInfos).MinimumSize = new Size(172, 15);
		((Control)_vehInfos).Name = "_vehInfos";
		((Control)_vehInfos).Size = new Size(172, 15);
		((Control)_vehInfos).TabIndex = 24;
		((Control)_vehInfos).Text = "Vehicule";
		_vehInfos.TextAlign = (ContentAlignment)16;
		((Control)_vehInfos).Paint += new PaintEventHandler(_Label_Paint);
		((Control)_lbMap).BackColor = Color.DarkGray;
		((Control)_lbMap).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbMap).ForeColor = SystemColors.Menu;
		((Control)_lbMap).Location = new Point(188, 26);
		((Control)_lbMap).MinimumSize = new Size(820, 15);
		((Control)_lbMap).Name = "_lbMap";
		((Control)_lbMap).Size = new Size(820, 15);
		((Control)_lbMap).TabIndex = 27;
		((Control)_lbMap).Text = "Throttle Position";
		_lbMap.TextAlign = (ContentAlignment)32;
		((Control)_lbMap).Paint += new PaintEventHandler(_Label_Paint);
		((Control)gbTable).Controls.Add((Control)(object)panelTable);
		((Control)gbTable).Location = new Point(187, 38);
		((Control)gbTable).Name = "gbTable";
		((Control)gbTable).Size = new Size(821, 503);
		((Control)gbTable).TabIndex = 30;
		gbTable.TabStop = false;
		((Control)panelTable).BackColor = Color.DarkGray;
		((Control)panelTable).ForeColor = SystemColors.ControlText;
		((Control)panelTable).Location = new Point(1, 7);
		((Control)panelTable).Name = "panelTable";
		((Control)panelTable).Size = new Size(819, 495);
		((Control)panelTable).TabIndex = 29;
		((Control)panelTable).Paint += new PaintEventHandler(panelGrid_Paint);
		((Control)panelTable).MouseClick += new MouseEventHandler(panelTable_MouseClick);
		((Control)panelTable).MouseDown += new MouseEventHandler(panelTable_MouseDown);
		((Control)panelTable).MouseLeave += panelTable_MouseLeave;
		((Control)panelTable).MouseMove += new MouseEventHandler(panelTable_MouseMove);
		((Control)panelTable).MouseUp += new MouseEventHandler(panelTable_MouseUp);
		((Control)panelTable).MouseWheel += new MouseEventHandler(panelTable_MouseWheel);
		((Control)gbMap).Controls.Add((Control)(object)valueUD);
		((Control)gbMap).Controls.Add((Control)(object)vUDpanel);
		((Control)gbMap).Controls.Add((Control)(object)tvMap);
		((Control)gbMap).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)gbMap).Location = new Point(6, 126);
		((Control)gbMap).Name = "gbMap";
		((Control)gbMap).Size = new Size(173, 414);
		((Control)gbMap).TabIndex = 31;
		gbMap.TabStop = false;
		((UpDownBase)valueUD).BorderStyle = (BorderStyle)0;
		((Control)valueUD).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)valueUD).Location = new Point(8, 279);
		valueUD.Maximum = new decimal(new int[4] { 9990, 0, 0, 0 });
		valueUD.Minimum = new decimal(new int[4] { 8000, 0, 0, 0 });
		((Control)valueUD).Name = "valueUD";
		((Control)valueUD).Size = new Size(15, 16);
		((Control)valueUD).TabIndex = 63;
		((Control)valueUD).TabStop = false;
		((Control)valueUD).Tag = "";
		((UpDownBase)valueUD).TextAlign = (HorizontalAlignment)1;
		valueUD.Value = new decimal(new int[4] { 9990, 0, 0, 0 });
		valueUD.ValueChanged += valueUD_ValueChanged;
		((Control)valueUD).Enter += valueUD_Enter;
		((Control)valueUD).KeyDown += new KeyEventHandler(valueUD_KeyDown);
		((Control)valueUD).KeyPress += new KeyPressEventHandler(valueUD_KeyPress);
		((Control)valueUD).KeyUp += new KeyEventHandler(valueUD_KeyUp);
		((Control)valueUD).Leave += EditUD_Leave;
		((Control)vUDpanel).BackColor = SystemColors.Window;
		((Control)vUDpanel).BackgroundImageLayout = (ImageLayout)0;
		((Control)vUDpanel).Location = new Point(126, 280);
		((Control)vUDpanel).Name = "vUDpanel";
		((Control)vUDpanel).Size = new Size(41, 16);
		((Control)vUDpanel).TabIndex = 64;
		((Control)vUDpanel).Visible = false;
		((Control)vUDpanel).Paint += new PaintEventHandler(vUDpanel_Paint);
		((Control)tvMap).BackColor = Color.White;
		tvMap.BorderStyle = (BorderStyle)0;
		tvMap.DrawMode = (TreeViewDrawMode)2;
		((Control)tvMap).Enabled = false;
		((Control)tvMap).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvMap.FullRowSelect = true;
		tvMap.ImageIndex = 0;
		tvMap.ImageList = tv_Image;
		((Control)tvMap).ImeMode = (ImeMode)2;
		tvMap.Indent = 16;
		((Control)tvMap).Location = new Point(2, 7);
		((Control)tvMap).Name = "tvMap";
		val.ImageIndex = 2;
		val.Name = "F1";
		val.SelectedImageIndex = -2;
		val.StateImageKey = "(none)";
		val.Tag = 1;
		val.Text = "F1";
		val2.ImageIndex = -2;
		val2.Name = "F2";
		val2.SelectedImageIndex = -2;
		val2.StateImageKey = "Grid.PNG";
		val2.Tag = 1;
		val2.Text = "F2";
		val3.ImageIndex = -2;
		val3.Name = "F3";
		val3.SelectedImageIndex = -2;
		val3.Tag = 1;
		val3.Text = "F3";
		val4.ImageIndex = -2;
		val4.Name = "Fuel Trim";
		val4.SelectedImageIndex = -2;
		val4.Tag = 1;
		val4.Text = "Fuel Trim";
		val5.ImageIndex = -2;
		val5.Name = "L1";
		val5.SelectedImageIndex = -2;
		val5.Tag = 1;
		val5.Text = "L1";
		val6.ImageIndex = -2;
		val6.Name = "L2";
		val6.SelectedImageIndex = -2;
		val6.Tag = 1;
		val6.Text = "L2";
		val7.ImageIndex = -2;
		val7.Name = "L3";
		val7.SelectedImageIndex = -2;
		val7.Tag = 1;
		val7.Text = "L3";
		val8.ImageIndex = -2;
		val8.Name = "I1";
		val8.SelectedImageIndex = -2;
		val8.Tag = 1;
		val8.Text = "I1";
		val9.ImageIndex = -2;
		val9.Name = "I2";
		val9.SelectedImageIndex = -2;
		val9.Tag = 1;
		val9.Text = "I2";
		val10.ImageIndex = -2;
		val10.Name = "I3";
		val10.SelectedImageIndex = -2;
		val10.Tag = 1;
		val10.Text = "I3";
		val11.ForeColor = Color.DarkGray;
		val11.ImageIndex = -2;
		val11.Name = "I4";
		val11.SelectedImageIndex = -2;
		val11.Tag = -1;
		val11.Text = "I4";
		val12.ImageIndex = -2;
		val12.Name = "Ignition Trim  ";
		val12.SelectedImageIndex = -2;
		val12.Tag = 1;
		val12.Text = "Ignition Trim";
		val13.ImageIndex = -2;
		val13.Name = "Air/Fuel";
		val13.SelectedImageIndex = -2;
		val13.Tag = 1;
		val13.Text = "Air/Fuel";
		val14.ForeColor = Color.DarkGray;
		val14.ImageIndex = -2;
		val14.Name = "Idle";
		val14.SelectedImageIndex = -2;
		val14.Tag = 1;
		val14.Text = "Idle";
		val15.ForeColor = Color.DarkGray;
		val15.ImageIndex = -2;
		val15.Name = "Exhaust Valve";
		val15.SelectedImageIndex = -2;
		val15.Tag = -1;
		val15.Text = "Exhaust Valve";
		val16.ForeColor = Color.DarkGray;
		val16.ImageIndex = -2;
		val16.Name = "2nd Throttle";
		val16.SelectedImageIndex = -2;
		val16.Tag = -1;
		val16.Text = "2nd Throttle";
		val17.ImageIndex = -2;
		val17.Name = "Table ";
		val17.SelectedImageIndex = -2;
		val17.Tag = 8;
		val17.Text = "Table ";
		val18.ContextMenuStrip = cModifMenu;
		val18.ImageIndex = 5;
		val18.Name = "Tree_revLimit";
		val18.Tag = 34;
		val18.Text = "revLimit";
		val19.ContextMenuStrip = cModifMenu;
		val19.ImageIndex = 5;
		val19.Name = "Tree_Fan";
		val19.Tag = 34;
		val19.Text = "Fan";
		val20.ContextMenuStrip = cModifMenu;
		val20.ImageIndex = 5;
		val20.Name = "Tree_Speed";
		val20.Tag = 34;
		val20.Text = "Speed";
		val21.ImageIndex = 5;
		val21.Name = "Tree_Pulse";
		val21.Tag = -34;
		val21.Text = "Pulse";
		val22.ImageIndex = 5;
		val22.Name = "Tree_IFO";
		val22.Tag = -34;
		val22.Text = "IFO";
		val23.ImageIndex = 5;
		val23.Name = "Tree_Target";
		val23.Tag = -34;
		val23.Text = "Target A/F";
		val24.ImageIndex = -2;
		val24.Name = "mData";
		val24.SelectedImageIndex = -2;
		val24.Tag = 8;
		val24.Text = "Parameters";
		val25.Name = "Tree_SAI";
		val25.Tag = -4;
		val25.Text = "SAI";
		val26.Name = "Tree_EXBV";
		val26.Tag = -4;
		val26.Text = "EXBV";
		val27.Name = "Tree_O2";
		val27.Tag = -4;
		val27.Text = "O2";
		val28.Name = "Tree_Dash";
		val28.Tag = -4;
		val28.Text = "Dashboard";
		val29.Name = "Tree_Throttle";
		val29.Tag = -4;
		val29.Text = "2nd Throttle";
		val30.Name = "Tree_TPS";
		val30.Tag = -4;
		val30.Text = "2nd TPS";
		val31.ImageIndex = -2;
		val31.Name = "Devices";
		val31.SelectedImageIndex = -2;
		val31.Tag = 8;
		val31.Text = "Devices";
		tvMap.Nodes.AddRange((TreeNode[])(object)new TreeNode[3] { val17, val24, val31 });
		tvMap.Scrollable = false;
		tvMap.SelectedImageIndex = 0;
		tvMap.ShowNodeToolTips = true;
		((Control)tvMap).Size = new Size(169, 405);
		((Control)tvMap).TabIndex = 24;
		((Control)tvMap).Tag = 1;
		tvMap.AfterCollapse += new TreeViewEventHandler(tvMap_AfterExpand);
		tvMap.BeforeExpand += new TreeViewCancelEventHandler(tvMap_BeforeExpand);
		tvMap.AfterExpand += new TreeViewEventHandler(tvMap_AfterExpand);
		tvMap.DrawNode += new DrawTreeNodeEventHandler(TreeView_DrawNode);
		tvMap.AfterSelect += new TreeViewEventHandler(tvMap_AfterSelect);
		tvMap.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvMap_NodeMouseClick);
		tvMap.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvMap_NodeMouseDoubleClick);
		((Control)tvMap).KeyDown += new KeyEventHandler(tvMap_KeyDown);
		((Control)tvMap).MouseDown += new MouseEventHandler(tvMap_MouseDown);
		((Control)gbVehicule).Controls.Add((Control)(object)tvVehicule);
		((Control)gbVehicule).Location = new Point(6, 38);
		((Control)gbVehicule).Name = "gbVehicule";
		((Control)gbVehicule).Size = new Size(173, 70);
		((Control)gbVehicule).TabIndex = 32;
		gbVehicule.TabStop = false;
		((Control)tvVehicule).BackColor = Color.White;
		tvVehicule.BorderStyle = (BorderStyle)0;
		tvVehicule.DrawMode = (TreeViewDrawMode)2;
		((Control)tvVehicule).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvVehicule.FullRowSelect = true;
		tvVehicule.ImageIndex = 0;
		tvVehicule.ImageList = tv_Image;
		((Control)tvVehicule).ImeMode = (ImeMode)2;
		tvVehicule.Indent = 16;
		tvVehicule.ItemHeight = 15;
		((Control)tvVehicule).Location = new Point(2, 7);
		((Control)tvVehicule).Name = "tvVehicule";
		val32.ImageIndex = -2;
		val32.Name = "Serial # : ";
		val32.SelectedImageIndex = -2;
		val32.Tag = 32;
		val32.Text = "Serial # : ";
		val33.ImageIndex = -2;
		val33.Name = "Map : ";
		val33.SelectedImageIndex = -2;
		val33.Tag = 32;
		val33.Text = "Map : ";
		val34.ImageIndex = -2;
		val34.Name = "Checksum : ";
		val34.SelectedImageIndex = -2;
		val34.Tag = 32;
		val34.Text = "Checksum : ";
		val35.ImageIndex = -2;
		val35.Name = "ECU";
		val35.SelectedImageIndex = -2;
		val35.Tag = 8;
		val35.Text = "ECU Infos";
		tvVehicule.Nodes.AddRange((TreeNode[])(object)new TreeNode[1] { val35 });
		tvVehicule.Scrollable = false;
		tvVehicule.SelectedImageIndex = 0;
		((Control)tvVehicule).Size = new Size(169, 61);
		((Control)tvVehicule).TabIndex = 26;
		((Control)tvVehicule).Tag = 0;
		tvVehicule.DrawNode += new DrawTreeNodeEventHandler(TreeView_DrawNode);
		((Control)tvVehicule).MouseUp += new MouseEventHandler(tvVehicule_MouseUp);
		((Control)statusStrip).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ToolStrip)statusStrip).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[6]
		{
			(ToolStripItem)blankStatus,
			(ToolStripItem)battStatus,
			(ToolStripItem)loopStatus,
			(ToolStripItem)tpsStatus,
			(ToolStripItem)fileStatus,
			(ToolStripItem)ledStatus
		});
		((Control)statusStrip).Location = new Point(0, 546);
		((Control)statusStrip).Name = "statusStrip";
		statusStrip.ShowItemToolTips = true;
		((Control)statusStrip).Size = new Size(1018, 22);
		((Control)statusStrip).TabIndex = 57;
		((ToolStripItem)blankStatus).AutoSize = false;
		((ToolStripItem)blankStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)blankStatus).Name = "blankStatus";
		((ToolStripItem)blankStatus).Size = new Size(14, 17);
		((ToolStripItem)battStatus).AutoSize = false;
		((ToolStripItem)battStatus).Enabled = false;
		((ToolStripItem)battStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)battStatus).ForeColor = SystemColors.ControlDarkDark;
		((ToolStripItem)battStatus).Image = (Image)componentResourceManager.GetObject("battStatus.Image");
		((ToolStripItem)battStatus).ImageAlign = (ContentAlignment)16;
		((ToolStripItem)battStatus).ImageScaling = (ToolStripItemImageScaling)0;
		((ToolStripItem)battStatus).Margin = new Padding(5, 0, 0, 0);
		((ToolStripItem)battStatus).Name = "battStatus";
		((ToolStripItem)battStatus).Overflow = (ToolStripItemOverflow)0;
		((ToolStripItem)battStatus).Size = new Size(64, 22);
		((ToolStripItem)battStatus).TextAlign = (ContentAlignment)64;
		((ToolStripItem)loopStatus).AutoSize = false;
		((ToolStripItem)loopStatus).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)loopStatus).Enabled = false;
		((ToolStripItem)loopStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)1);
		((ToolStripItem)loopStatus).Image = (Image)(object)Resources.OpenLoop;
		((ToolStripItem)loopStatus).ImageAlign = (ContentAlignment)16;
		((ToolStripItem)loopStatus).ImageScaling = (ToolStripItemImageScaling)0;
		((ToolStripItem)loopStatus).Margin = new Padding(5, 0, 0, 0);
		((ToolStripItem)loopStatus).Name = "loopStatus";
		((ToolStripItem)loopStatus).Overflow = (ToolStripItemOverflow)0;
		((ToolStripItem)loopStatus).Size = new Size(34, 22);
		((ToolStripItem)loopStatus).TextAlign = (ContentAlignment)16;
		((ToolStripItem)tpsStatus).AutoSize = false;
		((ToolStripItem)tpsStatus).Enabled = false;
		((ToolStripItem)tpsStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)1);
		((ToolStripItem)tpsStatus).ForeColor = SystemColors.ControlDarkDark;
		((ToolStripItem)tpsStatus).Image = (Image)(object)Resources.LedOff;
		((ToolStripItem)tpsStatus).ImageAlign = (ContentAlignment)16;
		((ToolStripItem)tpsStatus).ImageScaling = (ToolStripItemImageScaling)0;
		((ToolStripItem)tpsStatus).Margin = new Padding(5, 2, 0, 0);
		((ToolStripItem)tpsStatus).Name = "tpsStatus";
		((ToolStripItem)tpsStatus).Overflow = (ToolStripItemOverflow)0;
		((ToolStripItem)tpsStatus).Size = new Size(58, 20);
		((ToolStripItem)tpsStatus).Text = " TPS ";
		((ToolStripItem)tpsStatus).TextAlign = (ContentAlignment)16;
		((ToolStripItem)tpsStatus).TextImageRelation = (TextImageRelation)8;
		((ToolStripItem)fileStatus).AutoSize = false;
		((ToolStripItem)fileStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)fileStatus).ForeColor = SystemColors.ControlDarkDark;
		((ToolStripItem)fileStatus).Name = "fileStatus";
		((ToolStripItem)fileStatus).Size = new Size(786, 17);
		((ToolStripItem)fileStatus).TextAlign = (ContentAlignment)16;
		((ToolStripItem)fileStatus).Paint += new PaintEventHandler(fileStatus_Paint);
		((ToolStripItem)ledStatus).AutoSize = false;
		((ToolStripItem)ledStatus).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripItem)ledStatus).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)ledStatus).ImageScaling = (ToolStripItemImageScaling)0;
		((ToolStripItem)ledStatus).Name = "ledStatus";
		((ToolStripItem)ledStatus).Size = new Size(24, 17);
		((ToolStripItem)ledStatus).Tag = 0;
		((ToolStripItem)ledStatus).Paint += new PaintEventHandler(ledStatus_Paint);
		((ToolStrip)cActiveMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)activeSubMenu });
		((Control)cActiveMenu).Name = "cEditMenu";
		((Control)cActiveMenu).Size = new Size(112, 26);
		((ToolStripDropDown)cActiveMenu).Opening += cModifMenu_Opening;
		((ToolStripDropDown)cActiveMenu).Opened += cActiveMenu_Opened;
		((Control)cActiveMenu).Click += cEditMenu_Click;
		((ToolStripItem)activeSubMenu).Name = "activeSubMenu";
		((ToolStripItem)activeSubMenu).Size = new Size(111, 22);
		((ToolStripItem)activeSubMenu).Text = "Activer";
		activeAppTimer.Interval = 500;
		activeAppTimer.Tick += activeAppTimer_Tick;
		((UpDownBase)editUpDown).InterceptArrowKeys = false;
		((Control)editUpDown).Location = new Point(998, 522);
		((Control)editUpDown).Margin = new Padding(0);
		((Control)editUpDown).Name = "editUpDown";
		((Control)editUpDown).Size = new Size(17, 20);
		((Control)editUpDown).TabIndex = 60;
		((Control)editUpDown).Visible = false;
		editUpDown.ValueChanged += editUpDown_ValueChanged;
		((Control)editUpDown).KeyDown += new KeyEventHandler(valueUD_KeyDown);
		((Control)editUpDown).KeyPress += new KeyPressEventHandler(valueUD_KeyPress);
		((Control)editUpDown).KeyUp += new KeyEventHandler(valueUD_KeyUp);
		((Control)editUpDown).Leave += editUpDown_Leave;
		((Control)panelDiag).Controls.Add((Control)(object)_lbCodes);
		((Control)panelDiag).Controls.Add((Control)(object)_lbDesc);
		((Control)panelDiag).Controls.Add((Control)(object)gbError);
		((Control)panelDiag).Controls.Add((Control)(object)_lbTests);
		((Control)panelDiag).Controls.Add((Control)(object)gbTests);
		((Control)panelDiag).Controls.Add((Control)(object)_lbDash);
		((Control)panelDiag).Controls.Add((Control)(object)sensor_minus);
		((Control)panelDiag).Controls.Add((Control)(object)sensor_plus);
		((Control)panelDiag).Controls.Add((Control)(object)gbDiag);
		((Control)panelDiag).Controls.Add((Control)(object)_lbSensors);
		((Control)panelDiag).Controls.Add((Control)(object)gbSensor);
		((Control)panelDiag).Location = new Point(4, 26);
		((Control)panelDiag).Name = "panelDiag";
		((Control)panelDiag).Size = new Size(1008, 516);
		((Control)panelDiag).TabIndex = 65;
		((Control)panelDiag).Visible = false;
		((Control)_lbCodes).BackColor = Color.DarkGray;
		((Control)_lbCodes).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbCodes).ForeColor = SystemColors.Menu;
		((Control)_lbCodes).Location = new Point(206, 472);
		((Control)_lbCodes).Margin = new Padding(0);
		((Control)_lbCodes).MinimumSize = new Size(101, 15);
		((Control)_lbCodes).Name = "_lbCodes";
		((Control)_lbCodes).Size = new Size(101, 15);
		((Control)_lbCodes).TabIndex = 34;
		((Control)_lbCodes).Text = "Error Codes";
		_lbCodes.TextAlign = (ContentAlignment)16;
		((Control)_lbCodes).Paint += new PaintEventHandler(_Label_Paint);
		((Control)_lbDesc).BackColor = Color.DarkGray;
		((Control)_lbDesc).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbDesc).ForeColor = SystemColors.Menu;
		((Control)_lbDesc).Location = new Point(309, 472);
		((Control)_lbDesc).Name = "_lbDesc";
		((Control)_lbDesc).Size = new Size(695, 15);
		((Control)_lbDesc).TabIndex = 57;
		((Control)_lbDesc).Text = "Description";
		_lbDesc.TextAlign = (ContentAlignment)16;
		((Control)_lbDesc).Paint += new PaintEventHandler(_Label_Paint);
		((Control)gbError).BackColor = SystemColors.Control;
		((Control)gbError).Controls.Add((Control)(object)panelCodes);
		((Control)gbError).Location = new Point(205, 484);
		((Control)gbError).Name = "gbError";
		((Control)gbError).Size = new Size(799, 30);
		((Control)gbError).TabIndex = 30;
		gbError.TabStop = false;
		((Control)panelCodes).BackColor = SystemColors.Window;
		((Control)panelCodes).Controls.Add((Control)(object)listCodes);
		((Control)panelCodes).Controls.Add((Control)(object)tbDescription);
		((Control)panelCodes).Location = new Point(2, 8);
		((Control)panelCodes).Name = "panelCodes";
		((Control)panelCodes).Size = new Size(795, 20);
		((Control)panelCodes).TabIndex = 36;
		listCodes.BorderStyle = (BorderStyle)0;
		listCodes.DrawMode = (DrawMode)1;
		((Control)listCodes).Enabled = false;
		((Control)listCodes).Font = new Font("Tahoma", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		listCodes.IntegralHeight = false;
		listCodes.ItemHeight = 17;
		((Control)listCodes).Location = new Point(4, -1);
		((Control)listCodes).Name = "listCodes";
		((Control)listCodes).Size = new Size(94, 20);
		((Control)listCodes).TabIndex = 0;
		listCodes.DrawItem += new DrawItemEventHandler(listCodes_DrawItem);
		((Control)tbDescription).BackColor = SystemColors.Window;
		((TextBoxBase)tbDescription).BorderStyle = (BorderStyle)0;
		((Control)tbDescription).Cursor = Cursors.Default;
		((Control)tbDescription).Font = new Font("Tahoma", 9.75f);
		((Control)tbDescription).ForeColor = SystemColors.WindowText;
		((Control)tbDescription).Location = new Point(104, 1);
		((TextBoxBase)tbDescription).MaxLength = 200;
		((TextBoxBase)tbDescription).Multiline = true;
		((Control)tbDescription).Name = "tbDescription";
		((TextBoxBase)tbDescription).ReadOnly = true;
		((TextBoxBase)tbDescription).ShortcutsEnabled = false;
		((Control)tbDescription).Size = new Size(690, 17);
		((Control)tbDescription).TabIndex = 0;
		((Control)tbDescription).TabStop = false;
		((Control)_lbTests).BackColor = Color.DarkGray;
		((Control)_lbTests).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbTests).ForeColor = SystemColors.Menu;
		((Control)_lbTests).Location = new Point(3, 252);
		((Control)_lbTests).MinimumSize = new Size(195, 15);
		((Control)_lbTests).Name = "_lbTests";
		((Control)_lbTests).Size = new Size(195, 15);
		((Control)_lbTests).TabIndex = 70;
		((Control)_lbTests).Text = "Tests & Adjust.";
		_lbTests.TextAlign = (ContentAlignment)16;
		((Control)_lbTests).Paint += new PaintEventHandler(_Label_Paint);
		((Control)gbTests).Controls.Add((Control)(object)adjustUD);
		((Control)gbTests).Controls.Add((Control)(object)tvTests);
		((Control)gbTests).Location = new Point(2, 264);
		((Control)gbTests).Name = "gbTests";
		((Control)gbTests).Size = new Size(196, 250);
		((Control)gbTests).TabIndex = 70;
		gbTests.TabStop = false;
		((UpDownBase)adjustUD).BorderStyle = (BorderStyle)0;
		((Control)adjustUD).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)adjustUD).Location = new Point(6, 189);
		adjustUD.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		((Control)adjustUD).Name = "adjustUD";
		((Control)adjustUD).Size = new Size(15, 16);
		((Control)adjustUD).TabIndex = 28;
		((Control)adjustUD).Tag = 0;
		((Control)adjustUD).Visible = false;
		((Control)adjustUD).Click += adjustUD_ValueChanged;
		((Control)adjustUD).Leave += EditUD_Leave;
		((Control)tvTests).BackColor = Color.White;
		tvTests.BorderStyle = (BorderStyle)0;
		tvTests.DrawMode = (TreeViewDrawMode)2;
		((Control)tvTests).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvTests.FullRowSelect = true;
		tvTests.ImageIndex = 0;
		tvTests.ImageList = tv_Image;
		((Control)tvTests).ImeMode = (ImeMode)2;
		tvTests.Indent = 16;
		tvTests.ItemHeight = 18;
		((Control)tvTests).Location = new Point(2, 8);
		((Control)tvTests).Name = "tvTests";
		val36.Name = "Tacho";
		val36.Tag = 0;
		val36.Text = "Tacho";
		val37.Name = "Fan";
		val37.Tag = 0;
		val37.Text = "Cooling Fan";
		val38.Name = "Pump";
		val38.Tag = 0;
		val38.Text = "Fuel Pump";
		val39.Name = "Idle";
		val39.Tag = 0;
		val39.Text = "Idle Stepper";
		val40.Name = "Purge";
		val40.Tag = 0;
		val40.Text = "Purge Valve";
		val41.Name = "SAI";
		val41.Tag = 0;
		val41.Text = "SAI";
		val42.Name = "Flap";
		val42.Tag = 0;
		val42.Text = "Air Flap";
		val43.Name = "EXBV";
		val43.Tag = 0;
		val43.Text = "Exhaust Valve";
		val44.ImageIndex = -2;
		val44.Name = "Blank";
		val44.SelectedImageIndex = -2;
		val44.Tag = 0;
		val44.Text = "";
		val45.Name = "EXBV";
		val45.Tag = -4;
		val45.Text = "Adjust EXBV";
		val46.Name = "ISCV";
		val46.Tag = 0;
		val46.Text = "Reset ISCV";
		val47.Name = "Adapt";
		val47.Tag = 0;
		val47.Text = "Reset Adapt";
		val48.ImageIndex = -2;
		val48.Name = "Reset Throttle";
		val48.SelectedImageIndex = -2;
		val48.Tag = 0;
		val48.Text = "";
		tvTests.Nodes.AddRange((TreeNode[])(object)new TreeNode[13]
		{
			val36, val37, val38, val39, val40, val41, val42, val43, val44, val45,
			val46, val47, val48
		});
		tvTests.Scrollable = false;
		tvTests.SelectedImageIndex = 0;
		((Control)tvTests).Size = new Size(192, 240);
		((Control)tvTests).TabIndex = 27;
		((Control)tvTests).Tag = 2;
		tvTests.DrawNode += new DrawTreeNodeEventHandler(TreeView_DrawNode);
		tvTests.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvTests_NodeMouseClick);
		tvTests.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvTests_NodeMouseDoubleClick);
		((Control)_lbDash).BackColor = Color.DarkGray;
		((Control)_lbDash).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbDash).ForeColor = SystemColors.Menu;
		((Control)_lbDash).Location = new Point(206, 0);
		((Control)_lbDash).Name = "_lbDash";
		((Control)_lbDash).Size = new Size(798, 15);
		((Control)_lbDash).TabIndex = 34;
		((Control)_lbDash).Text = "Dashboard";
		_lbDash.TextAlign = (ContentAlignment)32;
		((Control)_lbDash).Paint += new PaintEventHandler(_Label_Paint);
		((Control)sensor_minus).BackColor = Color.DarkGray;
		sensor_minus.Image = (Image)(object)Resources.Minus;
		((Control)sensor_minus).Location = new Point(8, 4);
		((Control)sensor_minus).Name = "sensor_minus";
		((Control)sensor_minus).Size = new Size(9, 9);
		sensor_minus.SizeMode = (PictureBoxSizeMode)3;
		sensor_minus.TabIndex = 67;
		sensor_minus.TabStop = false;
		((Control)sensor_minus).Visible = false;
		((Control)sensor_minus).MouseClick += new MouseEventHandler(pb_minus_Click);
		((Control)sensor_plus).BackColor = Color.DarkGray;
		sensor_plus.Image = (Image)(object)Resources.Plus;
		((Control)sensor_plus).Location = new Point(8, 4);
		((Control)sensor_plus).Name = "sensor_plus";
		((Control)sensor_plus).Size = new Size(9, 9);
		sensor_plus.SizeMode = (PictureBoxSizeMode)3;
		sensor_plus.TabIndex = 66;
		sensor_plus.TabStop = false;
		((Control)sensor_plus).MouseClick += new MouseEventHandler(pb_plus_Click);
		((Control)gbDiag).Controls.Add((Control)(object)pbDash);
		((Control)gbDiag).Location = new Point(205, 12);
		((Control)gbDiag).Name = "gbDiag";
		((Control)gbDiag).Size = new Size(799, 454);
		((Control)gbDiag).TabIndex = 35;
		gbDiag.TabStop = false;
		((Control)pbDash).BackColor = SystemColors.ControlDarkDark;
		((Control)pbDash).BackgroundImageLayout = (ImageLayout)0;
		((Control)pbDash).Location = new Point(1, 7);
		((Control)pbDash).Name = "pbDash";
		((Control)pbDash).Size = new Size(800, 446);
		pbDash.TabIndex = 0;
		pbDash.TabStop = false;
		((Control)pbDash).Paint += new PaintEventHandler(pbDash_Paint);
		((Control)_lbSensors).BackColor = Color.DarkGray;
		((Control)_lbSensors).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbSensors).ForeColor = SystemColors.Menu;
		((Control)_lbSensors).Location = new Point(3, 0);
		((Control)_lbSensors).MinimumSize = new Size(195, 15);
		((Control)_lbSensors).Name = "_lbSensors";
		((Control)_lbSensors).Size = new Size(195, 15);
		((Control)_lbSensors).TabIndex = 25;
		((Control)_lbSensors).Text = "     Sensors";
		_lbSensors.TextAlign = (ContentAlignment)16;
		((Control)_lbSensors).Paint += new PaintEventHandler(_Label_Paint);
		((Control)_lbSensors).DoubleClick += _lbSensors_DoubleClick;
		((Control)gbSensor).Controls.Add((Control)(object)tvSensor);
		((Control)gbSensor).Location = new Point(2, 12);
		((Control)gbSensor).Name = "gbSensor";
		((Control)gbSensor).Size = new Size(196, 234);
		((Control)gbSensor).TabIndex = 33;
		gbSensor.TabStop = false;
		((Control)tvSensor).BackColor = Color.White;
		tvSensor.BorderStyle = (BorderStyle)0;
		tvSensor.DrawMode = (TreeViewDrawMode)2;
		((Control)tvSensor).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		tvSensor.ImageIndex = 0;
		tvSensor.ImageList = tv_Image;
		tvSensor.Indent = 16;
		tvSensor.ItemHeight = 16;
		((Control)tvSensor).Location = new Point(2, 7);
		((Control)tvSensor).Name = "tvSensor";
		val49.ImageIndex = -2;
		val49.Name = "13-Inj Pulse";
		val49.SelectedImageIndex = -2;
		val49.Tag = "";
		val49.Text = "                                    ";
		val50.ImageIndex = -2;
		val50.Name = "Injection Pulse";
		val50.SelectedImageIndex = -2;
		val50.Tag = 8;
		val50.Text = "Injection Pulse";
		val51.ImageIndex = -2;
		val51.Name = "17-Ign Timing";
		val51.SelectedImageIndex = -2;
		val51.Tag = "";
		val51.Text = "                                    ";
		val52.ImageIndex = -2;
		val52.Name = "48-Ign Dwell";
		val52.SelectedImageIndex = -2;
		val52.Text = "                                    ";
		val53.ImageIndex = -2;
		val53.Name = "Ignition Timing";
		val53.SelectedImageIndex = -2;
		val53.Tag = 8;
		val53.Text = "Ignition Timing";
		val54.ImageIndex = -2;
		val54.Name = "27-Reference";
		val54.SelectedImageIndex = -2;
		val54.Tag = "";
		val54.Text = "                                    ";
		val55.ImageIndex = -2;
		val55.Name = "33-Position";
		val55.SelectedImageIndex = -2;
		val55.Text = "                                    ";
		val56.ImageIndex = -2;
		val56.Name = "Throttle";
		val56.SelectedImageIndex = -2;
		val56.Tag = 8;
		val56.Text = "Throttle";
		val57.ImageIndex = -2;
		val57.Name = "46-Status";
		val57.SelectedImageIndex = -2;
		val57.Tag = "";
		val57.Text = "                                    ";
		val58.ImageIndex = -2;
		val58.Name = "43-Range #1";
		val58.SelectedImageIndex = -2;
		val58.Tag = "";
		val58.Text = "                                    ";
		val59.ImageIndex = -2;
		val59.Name = "40-Range #2";
		val59.SelectedImageIndex = -2;
		val59.Text = "                                    ";
		val60.ImageIndex = -2;
		val60.Name = "O2 Sensor";
		val60.SelectedImageIndex = -2;
		val60.Tag = 8;
		val60.Text = "O2 Sensor";
		val61.ImageIndex = -2;
		val61.Name = "38-Reference";
		val61.SelectedImageIndex = -2;
		val61.Tag = "";
		val61.Text = "                                    ";
		val62.ImageIndex = -2;
		val62.Name = "31-ISC Step";
		val62.SelectedImageIndex = -2;
		val62.Tag = "";
		val62.Text = "                                    ";
		val63.ImageIndex = -2;
		val63.Name = "Idle";
		val63.SelectedImageIndex = -2;
		val63.Tag = 8;
		val63.Text = "Idle";
		val64.ImageIndex = -2;
		val64.Name = "54-EXBV Sensor";
		val64.SelectedImageIndex = -2;
		val64.Tag = "";
		val64.Text = "                                    ";
		val65.ImageIndex = -2;
		val65.Name = "EXBV";
		val65.SelectedImageIndex = -2;
		val65.Tag = 8;
		val65.Text = "EXBV";
		val66.ImageIndex = -2;
		val66.Name = "10-Temp";
		val66.SelectedImageIndex = -2;
		val66.Tag = "";
		val66.Text = "                                    ";
		val67.ImageIndex = -2;
		val67.Name = "Temperature";
		val67.SelectedImageIndex = -2;
		val67.Tag = 8;
		val67.Text = "Temperature";
		val68.ImageIndex = -2;
		val68.Name = "24-Baro";
		val68.SelectedImageIndex = -2;
		val68.Tag = "";
		val68.Text = "                                    ";
		val69.ImageIndex = -2;
		val69.Name = "Barometric";
		val69.SelectedImageIndex = -2;
		val69.Tag = 8;
		val69.Text = "Barometric";
		val70.ImageIndex = -2;
		val70.Name = "36-Load";
		val70.SelectedImageIndex = -2;
		val70.Tag = "";
		val70.Text = "                                    ";
		val71.ImageIndex = -2;
		val71.Name = "Engine Load";
		val71.SelectedImageIndex = -2;
		val71.Tag = 8;
		val71.Text = "Engine Load";
		val72.ImageIndex = -2;
		val72.Name = "52-Fuel Level";
		val72.SelectedImageIndex = -2;
		val72.Tag = "";
		val72.Text = "                                    ";
		val73.ImageIndex = -2;
		val73.Name = "Fuel";
		val73.SelectedImageIndex = -2;
		val73.Tag = 8;
		val73.Text = "Fuel Level";
		val74.Name = "SAI";
		val74.Tag = 16;
		val74.Text = "Clutch";
		val75.Name = "Main Relay";
		val75.Tag = 16;
		val75.Text = "Fuel Pump";
		val76.Name = "Start Switch";
		val76.Tag = 16;
		val76.Text = "Start Relay";
		val77.Name = "O2 Heater";
		val77.Tag = 16;
		val77.Text = "Air Flap";
		val78.ImageIndex = -2;
		val78.Name = "Other";
		val78.SelectedImageIndex = -2;
		val78.Tag = 8;
		val78.Text = "Other";
		tvSensor.Nodes.AddRange((TreeNode[])(object)new TreeNode[11]
		{
			val50, val53, val56, val60, val63, val65, val67, val69, val71, val73,
			val78
		});
		tvSensor.Scrollable = false;
		tvSensor.SelectedImageIndex = 0;
		tvSensor.ShowNodeToolTips = true;
		((Control)tvSensor).Size = new Size(192, 225);
		((Control)tvSensor).TabIndex = 1;
		((Control)tvSensor).Tag = 3;
		tvSensor.AfterCollapse += new TreeViewEventHandler(tvSensor_NodesChange);
		tvSensor.AfterExpand += new TreeViewEventHandler(tvSensor_NodesChange);
		tvSensor.DrawNode += new DrawTreeNodeEventHandler(TreeView_DrawNode);
		((ListControl)lbDevList).FormattingEnabled = true;
		((Control)lbDevList).Location = new Point(328, 0);
		((Control)lbDevList).Name = "lbDevList";
		((Control)lbDevList).Size = new Size(172, 4);
		((Control)lbDevList).TabIndex = 66;
		((Control)lbDevList).Visible = false;
		lbDevList.SelectedIndexChanged += portList_SelectedIndexChanged;
		((ToolStrip)cResetMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)resetSubMenu });
		((Control)cResetMenu).Name = "cResetMenu";
		((Control)cResetMenu).Size = new Size(103, 26);
		((Control)cResetMenu).Click += cResetMenu_Click;
		((ToolStripItem)resetSubMenu).Name = "resetSubMenu";
		((ToolStripItem)resetSubMenu).Size = new Size(102, 22);
		((ToolStripItem)resetSubMenu).Text = "Reset";
		((Control)Logo_Panel).BackColor = SystemColors.Control;
		((Control)Logo_Panel).Location = new Point(512, 1);
		((Control)Logo_Panel).Name = "Logo_Panel";
		((Control)Logo_Panel).Size = new Size(144, 24);
		((Control)Logo_Panel).TabIndex = 67;
		((Control)Logo_Panel).Paint += new PaintEventHandler(Logo_Panel_Paint);
		((Control)EDpanel).BackColor = Color.FromArgb(224, 224, 224);
		((Control)EDpanel).BackgroundImageLayout = (ImageLayout)0;
		((Control)EDpanel).ForeColor = SystemColors.WindowText;
		((Control)EDpanel).Location = new Point(957, 524);
		((Control)EDpanel).Name = "EDpanel";
		((Control)EDpanel).Size = new Size(41, 16);
		((Control)EDpanel).TabIndex = 71;
		((Control)EDpanel).Tag = 0;
		((Control)EDpanel).Visible = false;
		((Control)EDpanel).Paint += new PaintEventHandler(EDpanel_Paint);
		((ToolStrip)cCopyMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)copySubMenu,
			(ToolStripItem)pasteSubMenu
		});
		((Control)cCopyMenu).Name = "cCopyMenu";
		((Control)cCopyMenu).Size = new Size(103, 48);
		((ToolStripDropDown)cCopyMenu).Opening += cCopyMenu_Opening;
		((ToolStripItem)copySubMenu).Name = "copySubMenu";
		((ToolStripItem)copySubMenu).Size = new Size(102, 22);
		((ToolStripItem)copySubMenu).Text = "Copy";
		((ToolStripItem)copySubMenu).Click += copySubMenu_Click;
		((ToolStripItem)pasteSubMenu).Enabled = false;
		((ToolStripItem)pasteSubMenu).Name = "pasteSubMenu";
		((ToolStripItem)pasteSubMenu).Size = new Size(102, 22);
		((ToolStripItem)pasteSubMenu).Text = "Paste";
		((ToolStripItem)pasteSubMenu).Click += pasteSubMenu_Click;
		((Control)BtnRight).Anchor = (AnchorStyles)9;
		((Control)BtnRight).BackColor = Color.Transparent;
		((ButtonBase)BtnRight).FlatAppearance.BorderSize = 0;
		((ButtonBase)BtnRight).FlatAppearance.MouseDownBackColor = Color.Transparent;
		((ButtonBase)BtnRight).FlatAppearance.MouseOverBackColor = Color.Transparent;
		((ButtonBase)BtnRight).FlatStyle = (FlatStyle)0;
		((Control)BtnRight).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)BtnRight).ForeColor = Color.White;
		((Control)BtnRight).Location = new Point(910, 4);
		((Control)BtnRight).Margin = new Padding(3, 0, 3, 3);
		((Control)BtnRight).Name = "BtnRight";
		((Control)BtnRight).Size = new Size(98, 20);
		((Control)BtnRight).TabIndex = 74;
		((Control)BtnRight).Tag = 1;
		((ButtonBase)BtnRight).TextAlign = (ContentAlignment)2;
		((ButtonBase)BtnRight).UseVisualStyleBackColor = false;
		((Control)BtnRight).Paint += new PaintEventHandler(button_Paint);
		((Control)BtnRight).MouseDown += new MouseEventHandler(button_MouseDown);
		((Control)BtnRight).MouseLeave += button_MouseLeave;
		((Control)BtnRight).MouseMove += new MouseEventHandler(button_MouseMove);
		((Control)BtnRight).MouseUp += new MouseEventHandler(button_MouseUp);
		((Control)BtnMid).Anchor = (AnchorStyles)9;
		((Control)BtnMid).BackColor = Color.Transparent;
		((ButtonBase)BtnMid).FlatAppearance.BorderSize = 0;
		((ButtonBase)BtnMid).FlatAppearance.MouseDownBackColor = Color.Transparent;
		((ButtonBase)BtnMid).FlatAppearance.MouseOverBackColor = Color.Transparent;
		((ButtonBase)BtnMid).FlatStyle = (FlatStyle)0;
		((Control)BtnMid).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)BtnMid).ForeColor = Color.White;
		((Control)BtnMid).Location = new Point(812, 4);
		((Control)BtnMid).Margin = new Padding(3, 0, 3, 3);
		((Control)BtnMid).Name = "BtnMid";
		((Control)BtnMid).Size = new Size(98, 20);
		((Control)BtnMid).TabIndex = 75;
		((Control)BtnMid).Tag = 2;
		((ButtonBase)BtnMid).TextAlign = (ContentAlignment)2;
		((ButtonBase)BtnMid).UseVisualStyleBackColor = false;
		((Control)BtnMid).Paint += new PaintEventHandler(button_Paint);
		((Control)BtnMid).MouseDown += new MouseEventHandler(button_MouseDown);
		((Control)BtnMid).MouseLeave += button_MouseLeave;
		((Control)BtnMid).MouseMove += new MouseEventHandler(button_MouseMove);
		((Control)BtnMid).MouseUp += new MouseEventHandler(button_MouseUp);
		((Control)BtnLeft).Anchor = (AnchorStyles)9;
		((Control)BtnLeft).BackColor = Color.Transparent;
		((ButtonBase)BtnLeft).FlatAppearance.BorderSize = 0;
		((ButtonBase)BtnLeft).FlatAppearance.MouseDownBackColor = Color.Transparent;
		((ButtonBase)BtnLeft).FlatAppearance.MouseOverBackColor = Color.Transparent;
		((ButtonBase)BtnLeft).FlatStyle = (FlatStyle)0;
		((Control)BtnLeft).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)BtnLeft).ForeColor = Color.White;
		((Control)BtnLeft).Location = new Point(704, 4);
		((Control)BtnLeft).Margin = new Padding(3, 0, 3, 3);
		((Control)BtnLeft).Name = "BtnLeft";
		((Control)BtnLeft).Size = new Size(108, 20);
		((Control)BtnLeft).TabIndex = 76;
		((Control)BtnLeft).Tag = 0;
		((ButtonBase)BtnLeft).TextAlign = (ContentAlignment)2;
		((ButtonBase)BtnLeft).UseVisualStyleBackColor = false;
		((Control)BtnLeft).Paint += new PaintEventHandler(button_Paint);
		((Control)BtnLeft).MouseDown += new MouseEventHandler(button_MouseDown);
		((Control)BtnLeft).MouseLeave += button_MouseLeave;
		((Control)BtnLeft).MouseMove += new MouseEventHandler(button_MouseMove);
		((Control)BtnLeft).MouseUp += new MouseEventHandler(button_MouseUp);
		((ToolStrip)cTrimMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)trimSubMenu });
		((Control)cTrimMenu).Name = "cEditMenu";
		((Control)cTrimMenu).Size = new Size(100, 26);
		((Control)cTrimMenu).Click += cTrimMenu_Click;
		((ToolStripItem)trimSubMenu).Name = "trimSubMenu";
		((ToolStripItem)trimSubMenu).Size = new Size(99, 22);
		((ToolStripItem)trimSubMenu).Tag = -1;
		((ToolStripItem)trimSubMenu).Text = "Trim";
		((ListControl)cmbPortName).FormattingEnabled = true;
		((Control)cmbPortName).Location = new Point(328, 12);
		((Control)cmbPortName).Name = "cmbPortName";
		((Control)cmbPortName).Size = new Size(172, 4);
		((Control)cmbPortName).TabIndex = 77;
		((Control)cmbPortName).Visible = false;
		cmbPortName.SelectedIndexChanged += portList_SelectedIndexChanged;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1018, 568);
		((Control)this).Controls.Add((Control)(object)cmbPortName);
		((Control)this).Controls.Add((Control)(object)BtnLeft);
		((Control)this).Controls.Add((Control)(object)BtnMid);
		((Control)this).Controls.Add((Control)(object)BtnRight);
		((Control)this).Controls.Add((Control)(object)panelDiag);
		((Control)this).Controls.Add((Control)(object)EDpanel);
		((Control)this).Controls.Add((Control)(object)editUpDown);
		((Control)this).Controls.Add((Control)(object)Logo_Panel);
		((Control)this).Controls.Add((Control)(object)statusStrip);
		((Control)this).Controls.Add((Control)(object)lbDevList);
		((Control)this).Controls.Add((Control)(object)_lbMap);
		((Control)this).Controls.Add((Control)(object)_vehInfos);
		((Control)this).Controls.Add((Control)(object)_mapInfos);
		((Control)this).Controls.Add((Control)(object)gbTable);
		((Control)this).Controls.Add((Control)(object)menuStrip);
		((Control)this).Controls.Add((Control)(object)gbVehicule);
		((Control)this).Controls.Add((Control)(object)gbMap);
		((Control)this).DoubleBuffered = true;
		((Control)this).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).KeyPreview = true;
		((Form)this).MainMenuStrip = menuStrip;
		((Form)this).MaximizeBox = false;
		((Control)this).MaximumSize = new Size(2560, 1920);
		((Control)this).MinimumSize = new Size(1024, 576);
		((Control)this).Name = "ISOMain";
		((Form)this).Opacity = 0.0;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "TuneECU";
		((Form)this).FormClosing += new FormClosingEventHandler(ISOMain_FormClosing);
		((Form)this).FormClosed += new FormClosedEventHandler(ISOMain_FormClosed);
		((Form)this).Load += ISOMain_Load;
		((Control)this).KeyDown += new KeyEventHandler(ISOMain_KeyDown);
		((Control)this).KeyUp += new KeyEventHandler(ISOMain_KeyUp);
		((Control)this).Resize += ISOMain_Resize;
		((Control)cModifMenu).ResumeLayout(false);
		((Control)menuStrip).ResumeLayout(false);
		((Control)menuStrip).PerformLayout();
		((Control)gbTable).ResumeLayout(false);
		((Control)gbMap).ResumeLayout(false);
		((ISupportInitialize)valueUD).EndInit();
		((Control)gbVehicule).ResumeLayout(false);
		((Control)statusStrip).ResumeLayout(false);
		((Control)statusStrip).PerformLayout();
		((Control)cActiveMenu).ResumeLayout(false);
		((ISupportInitialize)editUpDown).EndInit();
		((Control)panelDiag).ResumeLayout(false);
		((Control)gbError).ResumeLayout(false);
		((Control)panelCodes).ResumeLayout(false);
		((Control)panelCodes).PerformLayout();
		((Control)gbTests).ResumeLayout(false);
		((ISupportInitialize)adjustUD).EndInit();
		((ISupportInitialize)sensor_minus).EndInit();
		((ISupportInitialize)sensor_plus).EndInit();
		((Control)gbDiag).ResumeLayout(false);
		((ISupportInitialize)pbDash).EndInit();
		((Control)gbSensor).ResumeLayout(false);
		((Control)cResetMenu).ResumeLayout(false);
		((Control)cCopyMenu).ResumeLayout(false);
		((Control)cTrimMenu).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static ISOMain()
	{
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		clipData = Clipboard.GetDataObject();
		subVersion = "";
		enWide = false;
		wState = false;
		enTest = true;
		edShift = false;
		dConnect = false;
		edState = false;
		eSave = false;
		pSave = false;
		comFailed = false;
		compareF = false;
		sRecovery = false;
		toHide = false;
		noMap = true;
		lbSelect = false;
		oneSelect = false;
		graphSelect = false;
		editSelect = false;
		mConnect = false;
		keyF7 = false;
		editCurve = false;
		egSave = false;
		showGraph = false;
		showMod = false;
		showView = false;
		rowTPS = true;
		oneCurve = true;
		oneTrim = true;
		pCent = true;
		sCent = true;
		dcLabel = false;
		pcEdit = false;
		pcGraph = true;
		pcShow = false;
		showInfo = false;
		showLog = false;
		rDump = false;
		egCol = new byte[1];
		egRow = new byte[1];
		tagMap = 0;
		eInfo = 0;
		dColor = 0.0;
		eColor = 1.0;
		mProgress = 0.0;
		dClear = 0;
		eTag = 0;
		aNode = null;
		iStart = 5;
		QConnect = 0;
		mLed = 0;
		TypTable = -1;
		offWOT = 100;
		btnTest = -1;
		iTag = 0;
		sTag = -1;
		rpmMap = 0;
		warn = 25;
		eCurv = -1;
		sCurv = -1;
		eFirst = 0;
		eLast = 0;
		mCells = -1;
		eTrim = -1;
		xTrim = 0;
		cTrim = 0;
		wbTrim = 0;
		dataRefresh = new short[80];
		refreshCode = 0;
		mLang = 0;
		swMode = -1;
		swTest = 0;
		RevCount = 0;
		mDebug = 0;
		tDebug = 0;
		sProgress = 0;
		m_serial = (ToolStripMenuItem[])(object)new ToolStripMenuItem[8]
		{
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem()
		};
		m_USB = (ToolStripMenuItem[])(object)new ToolStripMenuItem[4]
		{
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem(),
			new ToolStripMenuItem()
		};
		lColor = new Color[3]
		{
			Color.Red,
			Color.DarkOrange,
			Color.Green
		};
		mColor = new Color[32]
		{
			Color.FromArgb(0, 112, 228),
			Color.FromArgb(0, 88, 228),
			Color.FromArgb(0, 72, 228),
			Color.FromArgb(0, 48, 228),
			Color.FromArgb(45, 0, 228),
			Color.FromArgb(90, 0, 228),
			Color.FromArgb(120, 0, 228),
			Color.FromArgb(145, 0, 228),
			Color.FromArgb(172, 0, 228),
			Color.FromArgb(204, 0, 228),
			Color.FromArgb(228, 0, 145),
			Color.FromArgb(228, 0, 80),
			Color.FromArgb(228, 0, 0),
			Color.FromArgb(228, 80, 0),
			Color.FromArgb(228, 96, 0),
			Color.FromArgb(228, 112, 0),
			Color.FromArgb(228, 140, 0),
			Color.FromArgb(228, 166, 0),
			Color.FromArgb(228, 192, 0),
			Color.FromArgb(228, 216, 0),
			Color.FromArgb(220, 228, 0),
			Color.FromArgb(204, 228, 0),
			Color.FromArgb(182, 228, 0),
			Color.FromArgb(144, 228, 0),
			Color.FromArgb(91, 228, 0),
			Color.FromArgb(0, 228, 0),
			Color.FromArgb(0, 228, 112),
			Color.FromArgb(11, 208, 127),
			Color.FromArgb(27, 194, 125),
			Color.FromArgb(25, 181, 117),
			Color.FromArgb(25, 162, 106),
			Color.FromArgb(24, 148, 98)
		};
		qColor = new Color[64]
		{
			Color.FromArgb(38, 38, 255),
			Color.FromArgb(44, 44, 255),
			Color.FromArgb(50, 50, 255),
			Color.FromArgb(56, 56, 255),
			Color.FromArgb(62, 62, 255),
			Color.FromArgb(68, 68, 255),
			Color.FromArgb(74, 74, 255),
			Color.FromArgb(80, 80, 255),
			Color.FromArgb(86, 86, 255),
			Color.FromArgb(92, 92, 255),
			Color.FromArgb(98, 98, 255),
			Color.FromArgb(104, 104, 255),
			Color.FromArgb(110, 110, 255),
			Color.FromArgb(116, 116, 255),
			Color.FromArgb(122, 122, 255),
			Color.FromArgb(128, 128, 255),
			Color.FromArgb(134, 134, 255),
			Color.FromArgb(140, 140, 255),
			Color.FromArgb(146, 146, 255),
			Color.FromArgb(152, 152, 255),
			Color.FromArgb(158, 158, 255),
			Color.FromArgb(164, 164, 255),
			Color.FromArgb(170, 170, 255),
			Color.FromArgb(176, 176, 255),
			Color.FromArgb(182, 182, 254),
			Color.FromArgb(188, 188, 252),
			Color.FromArgb(194, 194, 248),
			Color.FromArgb(200, 200, 244),
			Color.FromArgb(206, 206, 240),
			Color.FromArgb(212, 212, 236),
			Color.FromArgb(218, 218, 232),
			Color.FromArgb(224, 224, 228),
			Color.FromArgb(224, 224, 224),
			Color.FromArgb(216, 228, 216),
			Color.FromArgb(208, 232, 208),
			Color.FromArgb(200, 236, 200),
			Color.FromArgb(192, 240, 192),
			Color.FromArgb(184, 244, 184),
			Color.FromArgb(176, 248, 176),
			Color.FromArgb(168, 252, 168),
			Color.FromArgb(160, 254, 160),
			Color.FromArgb(152, 255, 152),
			Color.FromArgb(144, 255, 144),
			Color.FromArgb(136, 255, 136),
			Color.FromArgb(128, 255, 128),
			Color.FromArgb(120, 255, 120),
			Color.FromArgb(112, 255, 112),
			Color.FromArgb(104, 255, 104),
			Color.FromArgb(96, 255, 96),
			Color.FromArgb(88, 255, 88),
			Color.FromArgb(80, 255, 80),
			Color.FromArgb(72, 255, 72),
			Color.FromArgb(64, 255, 64),
			Color.FromArgb(56, 255, 56),
			Color.FromArgb(48, 255, 48),
			Color.FromArgb(40, 255, 40),
			Color.FromArgb(32, 255, 32),
			Color.FromArgb(24, 244, 24),
			Color.FromArgb(16, 236, 16),
			Color.FromArgb(8, 228, 8),
			Color.FromArgb(0, 220, 16),
			Color.FromArgb(0, 212, 24),
			Color.FromArgb(0, 204, 32),
			Color.FromArgb(0, 196, 40)
		};
		grabMemoryStream = new MemoryStream(Resources.grab);
		grabbingMemoryStream = new MemoryStream(Resources.grabbing);
		lbSensors = new int[40]
		{
			120, 130, 122, 123, 124, 131, 126, 127, 128, 129,
			120, 133, 122, 123, 124, 125, 126, 127, 128, 129,
			120, 133, 122, 123, 124, 132, 126, 127, 128, 134,
			120, 133, 122, 123, 124, 273, 126, 127, 128, 129
		};
		tipSensors = new int[105]
		{
			148, 160, 147, 150, 147, 151, 147, 147, 162, 163,
			164, 156, 165, 158, 147, 148, 149, 160, 150, 168,
			151, 152, 147, 153, 154, 155, 156, 157, 158, 159,
			167, 170, 171, 150, 147, 169, 166, 166, 174, 147,
			147, 156, 157, 158, 159, 179, 173, 178, 150, 168,
			151, 152, 147, 153, 154, 147, 156, 157, 158, 159,
			167, 170, 171, 150, 172, 169, 147, 147, 174, 154,
			175, 156, 176, 158, 177, 180, 181, 182, 184, 185,
			151, 147, 147, 174, 154, 183, 156, 176, 158, 177,
			148, 149, 147, 190, 191, 189, 192, 147, 174, 187,
			147, 188, 165, 147, 147
		};
		ptrMap = new int[43]
		{
			9, 10, 32, 28, 29, 30, 26, 27, 38, 6,
			7, 4, 8, 11, 12, 13, 14, 15, 16, 17,
			18, 19, 20, 21, 22, 32, 36, 37, 23, 5,
			49, 24, 25, 31, 83, 84, 85, 86, 50, 51,
			52, 53, 54
		};
		LangUI = new string[6, 361]
		{
			{
				"&File", "&Open Map File", "&Save Map File", "&Exit", "&Import PC Table", "&Compare File", "&Edit", "&Copy Table", "&Paste Table", "Commit &Trims",
				"Use \"F Trim\" for all F Tables", "E&xport Table", "&Logs", "&Display", "&Graphic", "&Map Infos", "Full Screen", "EC&U", "&Connect", "&History",
				"Read &Map", "&Download", "&Recovery", "Reset &TPS", "&Erase Error Codes", "&Disconnect", "&Options", "&Language", "English", "French",
				"German", "Italian", "Spanish", "Portuguese", "", "Edit", "Cut", "Copy", "Paste", "Delete",
				"Undo", "Enable", "Disable", "Reset", "\rHistory :\r", "F Trim ", "I Trim ", "Air/Fuel", "Idle   ", "Exhaust Valve",
				"2nd Throttle", "F-L Switch", "Injector Flow : ", "Target Idle A/F : ", "Speed Limit : ", "Rev. Limit (rpm) : ", "Thermo Fan (°C) : ", "Speed Adjust (%) : ", "Prime pulse : ", "Intake Flap (rpm) : ",
				"Quickshifter (ms)", "Idle (rpm) : ", "", "Software Checksum : ", "ECU Type : ", "ECU Infos", "Serial : ", "Map : ", "Checksum / P : ", "Type : ",
				"Checksum : ", "Vehicle", "Parameters", "Throttle Table", "&Cancel", "&Ok", "Cl&ear", "&Close", "Interface", "Download",
				"Map Edit", "Tests", "Diagnostics", "Throttle Position (%)", "Air Pressure (hPa)", "Engine (rpm)", "Engine Load (%)", "Temperature (°C)", "Map Infos", "Logs",
				"Table Infos", "Table ", "Dashboard", "Error Codes", "Type : ", "Pos", "Rpm", "A/F", "Degree", "Gear",
				"Tests & Adjust.", "     Sensors", "SAI", "Clutch", "Main Relay", "Fuel Pump", "Start Switch", "Start Relay", "Air Flap", "O2 Sensor",
				"O2 Sensor (2)", "", "", "", "Other", "Battery Volt", " TPS ", "", "", "Serial",
				"Injection Pulse", "Ignition Timing", "Throttle", "O2 Sensor", "Idle", "Exhaust Valve", "Temperature", "Barometric", "Engine Load", "Fuel Level",
				"Ignition Coil", "Long Term Fuel Trim", "Manifold Pressure", "Ignition", "Security", "O2 Sensor #1", "O2 Sensor #2", "", "Devices", "SAI    ",
				"Exhaust Valve", "O2 Sensor", "2nd Throttle", "Air Flap", "EPC", "O2 Sensor (2)", "Idle Speed Control", "", "Cylinder 1 - 2 - 3 (ms)", "Timing cylinder 1 - 2 - 3 (degrees BTDC)",
				"Reference - Sensor position volt", "Output volt", "Adaption range off idle - Adaption range idle - Adaption status idle", "Reference speed (rpm) - Speed control adaption status", "Speed control target step - Speed control step", "Position - Sensor position volt", "Intake air - Intake air sensor volt - Motor sensor volt", "Pressure - Pressure sensor volt - MAP sensor volt", "Calculed", "Sensor voltage",
				"Dwell time cylinder 1 - 2 - 3 (ms)", "Related fuel trim", "Reference speed (rpm) - Adaptive stepper position", "Idle fuel trim (CO) - Speed control step", " % ", "Pressure", "() Adaption range off idle - Adaption range idle - Adaption status idle", "Cylinder 1 - 2 (ms)", "Position (2) - Sensor position volt (2)", "Output volt 1 - 2",
				"Timing cylinder 1 - 2 (degrees BTDC)", "Dwell time cylinder 1 - 2 (ms)", "Target position (2) - Sensor position (2) - Sensor volt (2)", "Timing cylinder 1 - 2 - 3 - 4 (degrees BTDC)", "Reference speed (rpm)", "Cylinder 1 pressure - MAP sensor volt 1 - 2", "Pressure - Pressure sensor volt", "Sidestand sensor volt - Rollover switch volt", "Dwell time 1 - 2 - 3 - 4 (ms)", "Cylinder 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Timing (degrees BTDC)", "Dwell time (ms)", "Map sensor volt", "Reference - Throttle grip sensor position volt", "Throttle motor position - Throttle motor sensor position volt", "Reference", "Speed control step", "Intake air", "Output value",
				"Minimum - Maximum", "Delta", "Fuel Correction", "", "", "", "", "", "", "Apply \"F Trim\" to L Tables",
				"Transfer failed.\r", "Operation cancelled !", "ECU is connected but not responding.\rRun the ECU Recovery ?", "Connection break, download failed.", " ECU connected.\rAuthentification... ", "Unlocking the ECU... ", "Access allowed.\r", "Access not allowed.", "Access denied.", "Invalid key.\r",
				"ECU identification.\r", "Serial ", "Connection break.", "Download in progress...\r", "Download done.\r", "ECU recovery in progress...\r", "ECU recovery done.\r", "Reading in progress... ", "History reading done.\rOpen the Logs window ?", "ECU restarting...\r\r",
				"Timeout, transfer failed.\r", "Run the ECU Recovery ?", "ECU is not responding :\rCheck cable connection.\rTurn ignition off and on.", "Unknown Map file.", "Unknown Map type.", "File ", " has changed.\r\r", "Save the change ?", "Select a Map", "Save",
				"Map reading done.", "Reset TPS...", "Reset TPS done.\r", "\rInitialization...", "Erase all troubles code ?", "Troubles codes erased.\r", "Unknown Error Code", "Wrong key or file not found , connection to vehicule not allowed\r", "Download failed.", "No error code",
				"Description", "Please wait...", "Select a PCIII or PCV file", "This PCIII file is not compatible with this Map", "Error while reading the file", "This file is not a PCIII or PCV table", "Compare with...", "Map type must be identical", "", "Throttle Motor Drive",
				"Injector", "O2 Sensor", "Ignition Coil", "Tachometer", "Cooling Fan", "Fuel Pump", "Idle Speed Control", "Purge Control Valve", "SAI", "Air Flap",
				"Exhaust Valve", "2nd Throttle", "Adjust EXBV", "Adjust ISCV", "Reset  Adaption", "", "Reset TPS", "Idle Fuel Trim (CO)", "Adjust IACV", "Long Term Fuel Trim",
				"Adjust Throttle Cable", "Adjust Throttle position", "Adjust TPS", "Global Inj. correction", "", "", "Reset TPS ?", "", " ?    ", "Reset Adaption...",
				"Unsupported Test/Adjust", "Test ", " done", "Adjust the TPS until you read 0.60 volts and double-click on \"Adjust ISCV\" again", "Adjust the ISCV nut until you read 0.72 volt and double-click on \"Adjust ISCV\" again", "Idle Stepper adaptation in progress, don't touch anything for 15 seconds", "Adjust the ISCV nut until you read 0.75 volt and double-click on \"Adjust ISCV\" again", "ISCV adjustement complete", "Adjust ISCV...\r", "Reset ",
				" failed", " done", "Always show", "Show when start", "Closed throttle position reference status not adapted", "Closed throttle position reference status adapted", "Open loop fuel system operation (Insufficient engine temperature)", "Closed loop fuel system operation (Normal condition)", "Open loop fuel system operation (Normal condition)", "Open loop fuel system operation (System failure)",
				"Switch ignition off and adjust throttle cable...", "Disable only if the 2nd Throttle valves\ror 2nd Throttle device (stepping motor & 2nd TPS) are removed", "", "Reset &Adaption", "Reset Adaption ?", "Reset Adaption done.\r", "Please wait... positioning the butterfly valve", "The exhaust butterfly cables can now be adjust, double-click on \"Adjust EXBV\" when done", "Adjust EXBV...\r", "Adjust EXBV done",
				"The import can't use the \"Gear advanced\" feature.\rSelect the table to use :\r ", "Trying to connect...", "Authentification...", "Connected", "", "Auto-connect", "Map", "Unsupported ECU type.", "&Read", "No Map...",
				"Unsupported Map or file is corrupt.", "This Map is not compatible with this ECU.", "Incompatible Map.\r", "", "Quickshifter cut times", "Low Rpm:Mid Rpm:High Rpm", "Information", "Error", "Confirm", "Warning",
				"&Interface", "&About", "Reprogramming & diagnostic tool for\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (all models EFI except Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "This program is freeware\r\nand may only be distributed free of charge.", "This software need a screen resolution of 1024x576 or upper.\r", "Cannot open the port ", "USB Device not found\rReconnect the USB/OBD interface.", "&No", "&Yes", "",
				"Cannot open the port ", "USB Device not found\rReconnect the USB/OBD interface.", "Commit the fuel & ignition trims to the main tables\rand clear the trims tables ?", "Incorrect values can damage the engine.\rConfirm to write the ECU ?", "Turn ignition off\rPlug the programming connector\rTurn ignition on\r", "Sending the Erase/Program routine...", "Erasing blocks...\r", "Block n° ", " erased.\r", "",
				"Turn ignition off\rUnplug the programming connector\rTurn ignition on", "", "Download done... ", "", "ECU recovery done... ", "", "Unable to communicate with Port ", "", "TPS 0% voltage too high", "TPS 100% voltage too low",
				"Move throttle from closed to fully open then click \"Ok\" to validate"
			},
			{
				"&Fichier", "&Ouvrir une cartographie", "&Enregistrer la cartographie", "&Quitter", "&Importer une table PC", "&Comparer cartographie", "&Edition", "Co&pier la table", "C&oller la table", "&Appliquer les corrections",
				"Utiliser \"Correction F\" pour toutes les tables F", "E&xporter la table", "&Logs", "Affic&hage", "&Graphique", "&Infos cartographie", "Plein écran", "EC&U", "&Connecter", "&Historique",
				"&Lire cartographie", "&Programmer", "&Récupération", "Réinitialiser &TPS", "E&ffacer codes d'erreur", "&Déconnecter", "&Options", "&Langue", "Anglais", "Français",
				"Allemand", "Italien", "Espagnol", "Portugais", "", "Modifier", "Couper", "Copier", "Coller", "Supprimer",
				"Annuler", "Activer", "Désactiver", "Réinitialiser", "\rHistorique :\r", "Correction F", "Correction I", "Air/Essence", "Ralenti", "Valve Echap.",
				"Papillons Aux.", "Transition F-L", "Débit injecteur : ", "A/F cible (ralenti) : ", "Limit. vitesse : ", "Rupteur (tr/min) : ", "Ventilateur (°C) : ", "Correc. vitesse (%) : ", "Prime pulse : ", "Volet d'air (tr/min) : ",
				"Quickshifter (ms)", "Ralenti (tr/min) : ", "", "Checksum logiciel : ", "Type ECU : ", "Infos ECU", "N° série : ", "Map : ", "Checksum / P : ", "Type : ",
				"Checksum : ", "Véhicule", "Paramètres", "Table Papillon", "&Annuler", "&Ok", "&Effacer", "&Fermer", "", "Programmer",
				"Cartographie", "Tests", "Diagnostics", "Position Papillon (%)", "Pression Air Adm. (hPa)", "Régime moteur (tr/min)", "Charge Moteur (%)", "Température (°C)", "Infos cartographie", "Logs",
				"Infos table", "Table ", "Tableau de bord", "Codes d'erreur", "Type : ", "Pos", "Tr/min", "A/F", "Degré", "Rapport",
				"Tests & Réglages", "     Capteurs", "Injection air", "Embrayage", "Relais ECU", "Pompe ess.", "Coupe-circuit", "Relais dém.", "Volet d'air", "Sonde O2",
				"Sonde O2 (2)", "", "", "", "Autres", "Tension batterie", " TPS ", "", "", "Série",
				"Temps d'injection", "Point d'allumage", "Papillons", "Sonde O2", "Ralenti", "Valve échappement", "Température", "Barométrique", "Charge moteur", "Niveau essence",
				"Bobine d'allumage", "Correct. inj. long terme", "Pression admission", "Allumage", "Sécurités", "Sonde O2 #1", "Sonde O2 #2", "", "Dispositifs", "Injection Air",
				"Valve Echap.", "Sonde O2", "Papillons Aux.", "Volet d'air", "EPC", "Sonde O2 (2)", "Controleur ralenti", "", "Cylindre 1 - 2 - 3 (ms)", "Avance cylindre 1 - 2 - 3 (degrés avant PMH)",
				"Référence - Tension capteur position", "Tension sortie", "Plage d'adaptation hors ralenti - Plage d'adaptation au ralenti - Etat d'adaptation au ralenti", "Régime de référence (tr/min) - Etat d'adaptation control régime", "Position cible commande régime - Position commande régime", "Position - Tension capteur position", "Air admission - Tension capteur air admission - Tension capteur moteur", "Pression - Tension capteur pression - Tension capteur pression admission", "Calculée", "Tension capteur",
				"Temps de conduction cylindre 1 - 2 - 3 (ms)", "Correction injection", "Régime de référence (tr/min) - Position valve d'air", "Correction richesse (CO) - Position commande régime", " % ", "Pression", "() Plage d'adaptation hors ralenti - Plage d'adaptation au ralenti - Etat d'adaptation au ralenti", "Cylindre 1 - 2 (ms)", "Position (2) - Tension capteur position (2)", "Tension sortie 1 - 2",
				"Avance cylindre 1 - 2 (degrés avant PMH)", "Temps de conduction cylindre 1 - 2 (ms)", "Position cible (2) - Position (2) - Tension capteur position (2)", "Avance cylindre 1 - 2 - 3 - 4 (degrés avant PMH)", "Régime de référence (tr/min)", "Pression cylindre 1 - Tension capteur pression 1 - 2", "Pression - Tension capteur pression", "Tension capteur béquille latérale - Tension capteur d'inclinaison", "Temps de conduction 1 - 2 - 3 - 4 (ms)", "Cylindre 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Avance (degrés avant PMH)", "Temps de conduction (ms)", "Tension capteur pression", "Référence - Tension capteur poignée de gaz", "Position moteur de control - Tension capteur du moteur de control", "Référence", "Position commande régime", "Air admission", "Valeur de sortie",
				"Minimum - Maximum", "Delta", "Correction carburant", "", "", "", "", "", "", "Appliquer \"Correction F\" aux tables L",
				"Echec du transfert.\r", "Opération annulée !", "L'ECU est connecté mais ne répond pas.\rLancer la récupération de L'ECU ?", "Connexion interrompue, le téléchargement a échoué.", " ECU connecté.\rAuthentification... ", "Déverrouillage de l'ECU... ", "Accès autorisé.\r", "Accès non autorisé.", "Accès refusé.", "Clé invalide.\r",
				"Identification de l'ECU.\r", "N° série ", "Connexion interrompue.", "\rTéléchargement en cours...\r", "Téléchargement terminé.\r", "Récupération de l'ECU en cours...\r", "Récupération de l'ECU terminé.\r", "\rLecture en cours...\r", "Lecture historique terminée.\rVoir la fenêtre Logs ?", "Redémarrage de l'ECU...\r\r",
				"Délai dépassé, le transfert a échoué.\r", "Lancer la récupération de L'ECU ?", "Pas de réponse de l'ECU :\rVérifier que le cable est connecté.\rCouper et remettre le contact.", "Fichier non conforme.", "Type de cartographie inconnu.", "Le fichier ", " a été modifié.\r\r", "Enregistrer les modifications ?", "Sélectionner une cartographie", "Enregistrer",
				"Lecture cartographie terminée.", "Réinitialisation du TPS...", "Le TPS a été réinitialisé.\r", "\rInitialisation...", "Effacer tous les codes d'erreur ?", "Codes d'erreur effacés.\r", "Code d'erreur inconnu", "Fichier key manquant ou incorrect, la connexion avec le véhicule est impossible\r", "Echec du téléchargement.", "Pas de code d'erreur",
				"Description", "Veuillez patienter...", "Sélectionner une table PCIII ou PCV", "Fichier PCIII incompatible avec la cartographie", "Erreur de lecture du fichier", "Ce fichier n'est pas une table PCIII ou PCV", "Comparer avec...", "Les cartographies doivent être du même type", "", "Actionneur papillon",
				"Injecteur", "Sonde O2", "Bobine d'allumage", "Bloc compteur", "Ventilateur Radiateur", "Pompe à essence", "Controleur ralenti", "Electrovanne de purge", "Injection d'air", "Volet d'air",
				"Valve échappement", "Papillons secondaires", "Réglage valve échap.", "Réglage ISCV", "Réinit. adaptation", "", "Réinitialisation TPS", "Réglage CO", "Réglage IACV", "Correct. inj. long terme",
				"Réglage cable d'accélérateur", "Réglage position papillon", "Réglage TPS", "Correct. inj. globale", "", "", "Réinitialiser TPS ?", "", " ?    ", "Réinitialisation adaptation...",
				"Test/réglage non implémenté", "Test ", " terminé", "Ajuster le positionnement du TPS pour avoir une tension de 0,60 volts et double-cliquer sur \"Réglage ISCV\" à nouveau", "Régler l'écrou du controleur de ralenti pour avoir 0,72 volts et double-cliquer sur \"Réglage ISCV\" à nouveau", "Calibrage controleur ralenti en cours, ne touchez à rien pendant 15 secondes", "Régler l'écrou du controleur de ralenti pour avoir 0,75 volts et double-cliquer sur \"Réglage ISCV\" à nouveau", "Réglage ISCV terminé", "Réglage ISCV...\r", "Réinitialisation ",
				" en échec", " effectué", "Toujours visible", "Voir au démarrage", "Etat de référence position papillons fermés non adapté", "Etat de référence position papillons fermés adapté", "Fonctionnement système d'injection en boucle ouverte (Température moteur insuffisante)", "Fonctionnement système d'injection en boucle fermée (Condition normale)", "Fonctionnement système d'injection en boucle ouverte (Condition normale)", "Fonctionnement système d'injection en boucle ouverte (Défaut système)",
				"Couper le contact et régler le cable d'accélérateur...", "Ne désactiver les papillons secondaires que si les papillons\rou le système secondaire (moteur PAP et 2e TPS) sont enlevés", "", "Réinitialiser &adaptation", "Réinitialiser adaptation ?", "Réinitialisation adaptation terminé.\r", "Veuillez patienter... positionnement de la valve d'échappement", "Régler les cables de la valve d'échappement, et ensuite double-cliquer sur \"Réglage valve échap.\"", "Réglage valve échappement...\r", "Réglage valve échappement terminé",
				"L'importation ne peut pas utiliser la fonctionnalité \"Gear advanced\".\rSélectionner la table à utiliser :\r ", "Connexion en cours...", "Authentification...", "Connecté", "", "Connexion auto.", "Map", "Type d'ECU non supporté.", "&Lire", "Aucune cartographie...",
				"Cartographie non supportée ou fichier corrompu.", "Cartographie incompatible avec cet ECU.", "Cartographie incompatible.\r", "", "Temps de coupure Quickshifter", "Bas régime:Mi-régime:Haut régime", "Information", "Erreur", "Confirmer", "Attention",
				"&Interface", "&A propos", "Outil de reprogrammation & diagnostic pour\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (tous modèles EFI sauf Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "Ce logiciel est distribué gratuitement,\r\nil ne peut être concédé qu'à titre gratuit.", "Ce logiciel fonctionne avec une résolution d'écran de 1024x576 minimun.\r", "Impossible d'ouvrir le port", "Périphérique USB non trouvé\rReconnecter l'interface USB/OBD.", "&Non", "&Oui", "",
				"Impossible d'ouvrir le port ", "Périphérique USB non trouvé\rReconnecter l'interface USB/OBD.", "Fusionner les corrections d'essence et d'allumage aux tables principales\ret remettre à zéro les tables Correction F & I ?", "Des valeurs incorrectes peuvent endommager le moteur.\rConfirmer la reprogrammation de l'ECU ?", "Couper le contact\rBrancher le connecteur de programmation\rRemettre le contact", "Transfert de la routine Effacement/Programmation...", "Effacement des blocs...\r", "Bloc n° ", " effacé.\r", "",
				"Couper le contact\rDébrancher le connecteur de programmation\rRemettre le contact", "", "Téléchargement terminé... ", "", "Récupération de l'ECU terminé... ", "", "Impossible de communiquer avec le Port ", "", "Tension TPS 0% trop élevée", "Tension TPS 100% trop faible",
				"Tourner la poignée de gaz de la position fermée à complétement ouvert puis cliquer sur \"Ok\" pour valider"
			},
			{
				"&Datei", "&Map Datei Öffnen", "Map Datei &Speichern", "&Beenden", "PC Tabelle &Importieren", "&Vergleiche Datei", "&Bearbeiten", "Tabelle &Kopieren", "Tabelle &Einfügen", "Trimms Ü&bernehmen",
				"\"F-Trimm\" auf alle F-Tabellen anwenden", "Tabelle &Exportieren", "&Log Datei", "&Anzeige", "&Diagram", "&Map Info", "Vollbildanzeige", "EC&U", "&Verbinden", "&Historie",
				"Map aus ECU &lesen", "Map auf ECU &speichern", "&Wiederherstellung", "&TPS Zurücksetzen", "&Fehlercode löschen", "&Trennen", "&Optionen", "&Sprache", "Englisch", "Französisch",
				"Deutsch", "Italienisch", "Spanisch", "Portugiesisch", "", "Bearbeiten", "Ausschneiden", "Kopieren", "Einügen", "Löschen",
				"Rückgängig", "Aktivieren", "Deaktivieren", "Zurücksetzen", "\rHistorie :\r", "F Trimm", "I Trimm", "Luft/Kraftstoff", "Leerlauf", "Abgasklappe",
				"2. Drosselklappe", "Umschalten F-L", "Injektordurchfluss : ", "Soll Leerl. A/F : ", "Vmax Begrenzung : ", "Drehz.max (1/min) : ", "Lüfter (°C) : ", "Tacho Abgleich (%) : ", "Pumpimpuls : ", "Luftklappe (1/min) : ",
				"Quickshifter (ms)", "Leerlauf (1/min) : ", "", "Software-Prüfsumme : ", "ECU Typ : ", "ECU Info", "Serien Nr : ", "Map : ", "Prüfsumme / P : ", "Typ : ",
				"Prüfsumme : ", "Fahrzeug", "Parameter", "Drosselkl. Tabelle", "&Abbrechen", "&Ok", "&Leeren", "&Schliessen", "Schnittstelle", "Herunterladen",
				"Map Bearbeiten", "Test", "Diagnose", "Drosselkl. Position (%)", "Luftdruck (hPa)", "Motor (1/min)", "Motor Last (%)", "Temperatur (°C)", "Map Info", "Log Datei",
				"Tabelle Info", "Tabelle ", "Instrumententafel", "Fehler Code", "Typ : ", "Pos", "1/min", "A/F", "Grad", "Gang",
				"Test & Einstellung.", "     Sensoren", "SLS", "Kupplung", "Haupt Relais", "Benzinpumpe", "Start Knopf", "Start Relais", "Luft Klappe", "Lambdasonde",
				"Lambda S.(2)", "", "", "", "Weitere", "Batterie Spannung", " TPS ", "", "", "Seriell",
				"Einspritz Impuls", "Zündzeitpunkt", "Drosselklappe", "Lambdasonde", "Leerlauf", "Abgasklappe", "Temperatur", "Umgebungsluftdruck", "Motor Last", "Kraftstoffstand",
				"Zündspule", "Langzeit Kraftstoff Abgleich", "Ansaugluftdruck", "Zündung", "Sicherheit", "Lambdasonde #1", "Lambdasonde #2", "", "Vorrichtung", "SLS    ",
				"Abgasklappe", "Lambdasonde", "2. Drosselklappe", "Luft Klappe", "EPC", "Lambdasonde (2)", "Leerlaufdrehzahlregelung", "", "Zylinder 1 - 2 - 3 (ms)", "Zündverstellung Zylinder 1 - 2 - 3 (Grad vor OT)",
				"Referenz - Sensor Position Volt", "Ausgabe Volt", "Anpassungsbereich Teil/Voll Last - Anpassungsbereich Leerlauf - Anpassung Status Leerlauf", "Referenz Geschwindigkeit (1/min) - Geschwindigkeitsüberwachung Anpassungsstatus", "Geschwindigkeitsüberwachung Soll Step - Geschwindigkeitsüberwachung Step", "Positions - Sensor Position volt", "Ansaugluft - Ansaugluftsensor Volt - Motor Sensor Volt", "Druck - Drucksensor Volt - Ansaugluftdrucksensor (MAP) Volt", "Berechnet", "Sensor Spannung",
				"Einschaltzeit Zündspule 1 - 2 - 3 (ms)", "zugeordneter Kraftstoffabgleich", "Referenz Geschwindigkeit (1/min) - Angepasste Stepper Position", "Leerlauf Kraftstoff Abgleich (CO) - Geschwindigkeitsüberwachung Step", " % ", "Druck", "() Anpassungsbereich Teil/Voll Last - Anpassungsbereich Leerlauf - Anpassung Status Leerlauf", "Zylinder 1 - 2 (ms)", "Positions (2)- Sensor Position volt (2)", "Ausgabe Volt 1 - 2",
				"Zündverstellung Zylinder 1 - 2 (Grad vor OT)", "Einschaltzeit Zündspule 1 - 2 (ms)", "Soll Position (2) - Sensor Position (2) - Sensor Volt (2)", "Zündverstellung Zylinder 1 - 2 - 3 - 4 (Grad vor OT)", "Referenz Geschwindigkeit (1/min)", "Zylinder 1 Druck - Ansaugluftdrucksensor (MAP) Volt 1 - 2", "Druck - Druck Sensor volt", "Seitenständer Sensor Volt - Sturzerkennungschalter Volt", "Einschaltzeit Zündspule 1 - 2 - 3 - 4 (ms)", "Zylinder 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Zündverstellung (Grad vor OT)", "Einschaltzeit Zündspule (ms)", "Ansaugluftdrucksensor (MAP) Volt", "Referenz - Gasgriff Positionssensor Volt", "Position Drosselklappenmotor - Positionssensor Drosselklappenmotor Volt", "Referenz", "Geschwindigkeitsüberwachung Step", "Ansaugluft", "Ausgabewert",
				"Minimum - Maximum", "Delta", "Kraftstoffkorrektur", "", "", "", "", "", "", "\"F-Trimm\" auf L-Tabellen anwenden",
				"Transfer fehlgeschlagen.\r", "Operation abgebrochen !", "ECU ist verbunden antwortet aber nicht.\rECU Wiederherstellung durchführen ?", "Verbindung unterbrochen, Herunterladen fehlgeschlagen.", " ECU verbunden.\rAuthentifikation... ", "Entsperren der ECU... ", "Zugriff erlaubt.\r", "Zugriff nicht erlaubt.", "Zugriff verweigert.\r", "Ungültiger Key.\r",
				"ECU Identifizierung.\r", "Serien Nr ", "Verbindung unterbrochen.", "Herunterladen läuft...\r", "Herunterladen fertig.\r", "ECU Wiederherstellung läuft...\r", "ECU Wiederherstellung fertig.\r", "Lesen läuft... ", "Historie Lesen läuft.\rÖffne das Logdatei Fenster ?", "ECU neustarten...\r\r",
				"Timeout, Transfer fehlgeschlagen.\r", "ECU Wiederherstellung starten ?", "ECU antwortet nicht :\rPrüfe die Kabel Verbindung.\rSchalte Zündung AUS und AN.", "Unbekannte Map Datei.", "Unbekannter Map Typ.", "Datei ", " wurde geändert.\r\r", "Änderung speichern ?", "Map Auswählen", "Speichern",
				"Map Lesen fertig.", "Zurücksetzten TPS...", "Zurücksetzen TPS fertig.\r", "\rInitialisierung...", "Lösche alle Fehler Codes ?", "Fehler Codes gelöscht.\r", "Unbekannter Fehler Code", "Falscher Key oder Datei nicht gefunden, Verbindung zum Fahrzeug nicht erlaubt\r", "Herunterladen fehlgeschlagen.", "Kein Fehler Code",
				"Beschreibung", "Bitte warten...", "Wählen eine PCIII oder PCV Tabelle", "Diese PCIII oder PCV Datei ist nicht kompatibel mit diesem Map", "Fehler während der Datei lesen", "Diese Datei ist kein PCIII oder PCV Tabelle", "Vergleiche mit...", "Map Typ muss identisch sein", "", "Drosselklappenstellmotor",
				"Injector", "Lambdasonde", "Zündspule", "Drehzahlmesser", "Kühler Lüfter", "Benzinepumpe", "Leerlaufdrehzahlregelung", "Spülregelventil", "SLS", "Luft Klappe",
				"Abgasklappe", "2. Drosselklappe", "Einstellen EXBV", "Einstellen ISCV", "Anpassung zurücksetzen", "", "Zurücksetzen TPS", "Leerl. A/F Abgleich (CO)", "Einstellen IACV", "Langzeit Gemisch Abgleich",
				"Einstellung Gaszug", "Drosselklappenstellung", "Einstellen TPS", "Allgem. Einspr. Abgleich", "", "", "Zurücksetzen TPS ?", "", " ?    ", "Anpassung zurücksetzen...",
				"Nicht unterstützer Test/Einstellen", "Test ", " Fertig", "Stelle den TPS auf 0,60 Volt dann Doppel-Click auf \"Einstellung  ISCV\"", "Stelle die Mutter des Leerlaufregler (ISCV) auf 0,72 Volt dann Doppel-Click auf \"Einstellung ISCV\"", "Leerlauf Stellmotor Anpassung aktiv, für die nächsten 15 sek. nichts betätigen", "Stelle die Mutter des Leerlaufregler (ISCV) auf 0,75 Volt dann Doppel-Click auf \"Einstellung ISCV\"", "Einstellung ISCV Fertig", "Einstellung ISCV...\r", "Zurücksetzen ",
				" Fehlgeschlagen", " Fertig", "Zeige immer", "Zeige bei Start", "Referenz Position der geschlossenen Drosselklappe ist nicht angepasst", "Referenz Position der geschlossenen Drosselklappe ist angepasst", "Kraftstoffregelung im Open-Loop Betrieb (Motor Temperatur nicht ausreichend)", "Kraftstoffregelung im Close-Loop Betrieb (Normal Bedingung)", "Kraftstoffregelung im Open-Loop Betrieb (Normal Bedingung)", "Kraftstoffregelung im Open-Loop Betrieb (System Fehler)",
				"Schalte die Zündung aus & stelle den Gaszug ein...", "Nur deaktivieren, wenn die 2.Drosselklappen\roder die 2.Drosseleinrichtung (Schrittmotor & TPS) ausgebaut wurden    ", "", "&Anpassung Zurücksetzen", "Anpassung Zurücksetzen ?", "Anpassung Zurücksetzen fertig.\r", "Bitte warten... Abgasklappe wird positioniert", "Die Auspuffklappen Züge können nun eingestellt werden, Doppel-click auf \"Einstellen Abgasklappe (EXBV)\" nach dem Einstellen", "Einstellen Abgasklappe (EXBV)...\r", "Einstellung Abgasklappe (EXBV) fertig",
				"Der Import kann nicht die \"Gear advanced\" Funktion benutzen.\rWähle die zu verwendende Tabelle aus :\r ", "Versuche zu verbinden...", "Authentifizierung...", "Verbunden", "", "Autom. verbinden", "Map", "Nicht unterstützes ECU Typ.", "&Lesen", "Keine Map...",
				"Nicht unterstützes Map oder Datei ist beschädigt.", "Dieses Map ist nicht compatibel mit dieser ECU.", "Nicht compatibles Map.\r", "", "Quickshifter Unterbrechungszeiten", "Niedr. Drehz:Mittl. Drehz:Hohe Drehz", "Information", "Fehler", "Bestätigen", "Warnung",
				"S&chnittstelle", "&Über", "Reprogramierung & Diagnose Werkzeug für\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (alle EFI Modelle außer Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "Dieses Programm ist Freeware\r\nund darf nur kostenlos verteilt werden", "Diese Software benötigt eine Auflösung von 1024x576 oder höher.\r", "Kann Port nicht öffnen", "USB Gerät nicht gefunden\r USB/OBD erneut verbinden.", "&Nein", "&Ja", "",
				"Kann Port ", "USB Gerät nicht gefunden\r USB/OBD erneut verbinden.", "Kraftstoff & Zündungs Trimms in Haupttabellen übernehmen\rund anschließend löschen ?", "Falsche Werte können den Motor beschädigen.\rBestätige das Beschreiben der ECU ?", "Schalte Zündung AUS\rStecken Sie den Programmierungstecker\rSchalten Zündung AN", "Sendien der routine Löschen/Programmierung...", "Löschen der Blöcke...\r", "Block nr. ", " gelöscht.\r", "",
				"Schalte Zündung AUS\rEntfernen Sie den Programmierungsstecker\rSchalten Zündung AN", "", "Herunterladen fertig... ", "", "ECU Wiederherstellung fertig... ", "", "Kann nicht kommunizieren mit Port ", "", "TPS 0% Spannung zu hoch", "TPS 100% Spannung zu gering",
				"Bewege den Gasgriff von der geschlossenen Pos. in die voll geöffnete Pos. und klicken Sie auf \"Ok\" um zu bestätigen"
			},
			{
				"&File", "Apri &Mappa", "&Salva Mappa", "&Uscita", "&Importa tabella PC", "&Confronta File", "&Modifica", "&Copia Tabella", "&Incolla Tabella", "&Applica le regolazioni",
				"Usa \"Regolazione F\" per tutte le tavole F", "&Exporta Tabella", "&Registri", "&Display", "&Grafico", "&Informazioni Mappa", "A schermo intero", "EC&U", "Co&nnetti", "Cr&onologia",
				"Leggi &Mappa", "Carica su &ECU", "&Ripristina", "Reset &TPS", "&Cancella Codici Errore", "&Disconnetti", "&Opzioni", "&Linguaggio", "Inglese", "Francese",
				"Tedesco", "Italiano", "Spagnolo", "Portoghese", "", "Modifica", "Taglia", "Copia", "Incolla", "Cancella",
				"Annulla ultima modifica", "Abilita", "Disabilita", "Reset", "\rCronologia :\r", "Regolazione F", "Regolazione I", "Aria/Carburante", "Minino ", "Valvola di Scarico",
				"2° Acceleratore", "Commuta F-L", "Flusso Iniett. : ", "Minimo A/C : ", "Limit. Velocità : ", "Limitatore (rpm) : ", "Ventola (°C) : ", "Corr.Velocità (%) : ", "Avv. a freddo ", "Deflettore aria (rpm) : ",
				"Cambio rapido (ms)", "Minino (rpm) : ", "", "Software checksum : ", "Tipo di ECU : ", "Informazioni", "Seriale : ", "Mappa : ", "Checksum / P : ", "Tipo : ",
				"Checksum : ", "Veicolo", "Parametri", "Tabella Acceleratore", "&Annulla", "&Ok", "&Ripulisci", "&Chiudi", "Interfaccia", "Scarica",
				"Edita Mappa", "Test", "Diagnostica", "Posizione Acceleratore (%)", "Pressione Aria (hPa)", "Motore (giri/min)", "Carico Motore (%)", "Temperatura (°C)", "Informazioni Mappa", "Registri",
				"Informazioni Tabella", "Tabella ", "Cruscotto", "Codici Errore", "Tipo : ", "Pos", "Rpm", "A/C", "Grado", "Marcia",
				"Prove & Regolazioni", "     Sensori", "SAI", "Frizione", "Relè princ.", "Pompa Benz.", "Interr. Avv.", "Relè Avv.", "Deflettore aria", "Sensore O2",
				"Sensore O2-2", "", "", "", "Altro", "Tensione Batteria", " TPS ", "", "", "Seriale",
				"Impulso di iniezione", "Anticipo d'accensione", "Acceleratore", "Sensore O2", "Minimo", "Valvola di Scarico", "Temperatura", "Barometrica", "Carico Motore", "Livello Carburante",
				"Bobine d'accensione", "Regol. Carb. (regime)", "Pressione del collettore", "Accensione", "Sicurezza", "Sensore O2 #1", "Sensore O2 #2", "", "Dispositivo", "SAI    ",
				"Valv. di scarico", "Sensore O2", "2° Acceleratore", "Deflettore aria", "EPC", "Sensore O2 (2)", "Regolazione minimo", "", "Cilindro 1 - 2 - 3 (ms)", "Temporizzazioni cilindro 1 - 2 - 3 (gradi prima del PMS)",
				"Riferimento - Tensione sensore posizione", "Tensione Uscita", "Adattamento fuori limite minimo - Adattamento limite minimo - Adattamento regime di minimo", "Velocità di riferimento (rpm) - Controllo adeguamento velocità", "Passo desiderato per controllo di velocità - passo controllo velocità", "Posizione - Tensione sensore di posizione", "Aria Aspirata - Tensione Sensore Aria Aspirata - Tensione Sensore Motore", "Pressione - Tensione sensore di pressione - Tensione sensore MAP", "Calcolato", "Tensione sensore",
				"Tempo di induzione bobine cilindro 1 - 2 - 3 (ms)", "Regolazione rapportata del carburante", "Velocità di riferimento (rpm) - Posizione motorino passo passo", "regolazione carburante al minimo (CO) - Passo controllo velocità", " % ", "Pressione", "() Adattamento fuori limite minimo - Adattamento limite minimo - Adattamento regime di minimo", "Cilindro 1 - 2 (ms)", "Posizione (2) - Tensione sensore di posizione (2)", "Tensione uscita 1 - 2",
				"Temporizzazioni cilindro 1 - 2 (gradi prima del PMS)", "Tempo di induzione bobine cilindro 1 - 2 (ms)", "Posizione di riferimento (2) - Posizione Sensore (2) - Tensione sensore (2)", "Temporizzazioni cilindro 1 - 2 - 3 - 4 (gradi prima del PMS)", "Velocità di riferimento (rpm)", "Pressione cilindro 1 - sensore MAP volt 1 - 2", "Pressione - Sensore pressione volt", "Tensione Interruttore caduta - Tensione Sensore cavalletto laterale", "Tempo di induzione 1 - 2 - 3 - 4 (ms)", "Cilindro 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Temporizzazioni (gradi prima del PMS)", "Tempo di induzione bobine (ms)", "sensore MAP volt", "Riferimento - Tensione sensore di posizione manopola acceleratore", "Posizione motorino corpo farfallato - Tenzione sensore di posizione corpo farfallato", "Riferimento", "Passo controllo velocità", "Aria aspirata", "Valore di uscita",
				"Minimo -  Massimo", "Delta", "Correzione carburante", "", "", "", "", "", "", "Applicare \"Regolazione F\" alle tavole L",
				"Trasferimento fallito.\r", "Operazione annullata !", "L'ECU è connessa ma non risponde.\rEseguire il Ripristino ECU ?", "Connessione interrotta, scaricamento fallito.", " ECU connessa.\rAutenticazione... ", "Sblocco dell'ECU... ", "Accesso consentito.\r", "Accesso non consentito.", "Accesso negato.", "Chiave non valida.\r",
				"Identificazione ECU.\r", "Seriale ", "Connessione interrotta.", "Scaricamento in atto...\r", "Scaricamento eseguito.\r", "Ripristino ECU in corso...\r", "Ripristino ECU eseguito.\r", "Lettura in corso... ", "Lettura cronologia eseguita.\rApro la finestra dei registri ?", "Riavvio ECU...\r\r",
				"Timeout, trasferimento fallito.\r", "Eseguire il rispristino dell'ECU ?", "L'ECU non risponde :\rControlla il cavo.\rSpegni e riaccendi il quadro.", "File di Mappa sconosciuto.", "Tipo di Mappa sconosciuto.", "Il file ", " è stato modificato.\r\r", "Salvare i cambiamenti ?", "Selezionare una Mappa", "Salva",
				"Lettura Mappa eseguita.", "Reset TPS...", "Reset TPS eseguito.\r", "\rInizializzazione...", "Cancellare tutti i codici di errore ?", "Codici di errore cancellati.\r", "Codice errore sconosciuto", "Chiave errata o file non trovato , connessione al veicolo non permessa\r", "Download fallito.", "Nessun codice di errore",
				"Descrizione", "Prego attendere...", "Seleziona un file PCIII o PCV", "Questo file PCIII o PCV non è compatibile con questa mappa", "Errore in lettura file", "Questo file non è un file PCIII o PCV", "Confronta con...", "I tipi di mappe devono essere identici", "", "Attuatore della valvola a farfalla",
				"Iniettore", "Sensore O2", "Bobine d'accensione", "Tachimetro", "Ventola raffreddamento", "Pompa carburante", "Regolazione minimo", "Elettrovalvola allo scarico", "SAI", "deflettore aria",
				"Valvola di scarico", "2° accelleratore", "Regolazione EXBV", "Regolazione ISCV", "Reset di adattamento", "", "Reset TPS", "Regol. carb. minimo (CO)", "Regolazione IACV", "Regol. Rapp. Carb.(regime)",
				"Regolazione il cavo dell'acceleratore", "Regolazione della valvola a farfalla", "Regolazione TPS", "Regol. globale Carb.", "", "", "Reset TPS ?", "", " ?    ", "Reset di adattamento...",
				"Test/regolazione non supportato", "Test ", " eseguito", "Regola il TPS finchè leggi 0.60 volts e fai doppio clic su \"Regolazione ISCV\" di nuovo", "Regola il dado dell' ISCV finchè leggi 0.72 volts e fai doppio clic su \"Regolazione ISCV\" di nuovo", "Adattamento motorino passo-passo del minimo in corso, non toccare nulla per 15 secondi", "Regola il dado dell' ISCV finchè leggi 0.75 volts e fai doppio clic su \"Regolazione ISCV\" di nuovo", "Regolazione ISCV completata", "Regolazione ISCV...\r", "Reset ",
				" fallito", " eseguito", "Mostra sempre", "Mostra all'avvio", "Posizione di riferimento acceleratore chiuso non regolata", "Posizione di riferimento acceleratore chiuso regolata", "Carburazione di riferimento \"open loop\" (temperatura motore insufficiente)", "Carburazione adattiva \"closed loop\" (condizione normale)", "Carburazione di riferimento \"open loop\" (condizione normale)", "Carburazione di riferimento \"open loop\" (errore di sistema)",
				"Portare la chiave d'accensione su off e regolare il cavo dell'acceleratore...", "Disabilitare solo se le valvole secondarie dei corpi farfallati      \r  o il sistema secondario (motore stepper e 2° TPS) sono stati rimossi", "", "Reset di &adattamento", "Reset di adattamento ?", "Reset di adattamento eseguito.\r", "Prego attendere... Sto posizionando la valvola a farfalla", "I cavi della valvola di scarico possono ora essere regolati, doppio clic su \"regolazione EXBV\" quando finito.", "Regolazione EXBV...\r", "Regolazione EXBV eseguita",
				"Nell'importazione non può essere utilizzata la funzione \"Gear Advanced\".\rSelezionare la tabella da utilizzare:\r ", "Provo a connettermi...", "Autenticazione...", "Connesso", "", "Connetti Automaticamente", "Mappa", "Tipo di ECU non sopportato.", "&Leggi", "Nessuna mappa...",
				"La Mappa non è supportata o il file è corrotto.", "Questa Mappa non è compatibile con questa ECU.", "Mappa Incompatibile.\r", "", "Tempo di intervento cambio rapido", "Bassi regimi:Medi regimi:Alti regimi", "informazioni", "Errore", "Confermare", "Attenzione",
				"&Interfaccia", "C&rediti", "Strumento di riprogrammazione & diagnostica per\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (tutti i modelli con EFI eccetto Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "Questo programma è gratuito e può solo essere distribuito senza costi.", "Questo software necessità di uno schermo con una risoluzione di 1024x576 o superiore.\r", "Non posso aprire la porta ", "Dispositivo USB non trovato\rRiconnettere l'interfaccia USB/OBD.", "&No", "&Si", "",
				"Non posso aprire la porta ", "Dispositivo USB non trovato\rRiconnettere l'interfaccia USB/OBD.", "Applicare le regolazioni carburante & iniezione sulle tabelle principali\red eliminare le tabelle di regolazione ?", "Valori incorretti possono danneggiare il motore.\rConfermi la scrittura sull'ECU ?", "Spegni il quadro\rCollega il connettore di programmazione\rAccendi il quadro", "Sto eseguendo il programma di Cancellazione/Programmazione...", "Eliminando blocchi...\r", "Blocco n° ", " cancellato.\r", "",
				"Spegni il quadro\rScollega il connettore di programmazione\rAccendi il quadro", "", "Scaricamento eseguito... ", "", "Ripristino ECU eseguito... ", "", "Impossibile comunicare con Port ", "", "Voltaggio TPS 0% troppo alto", "Voltaggio TPS 100% troppo basso",
				"Muovi l'acceleratore da chiuso a tutto aperto e clicca \"Ok\" per confermare"
			},
			{
				"&Archivo", "Abrir &Mapa", "&Guardar Mapa", "&Salir", "&Importar Tabla de PC", "&Comparar Mapa", "&Editar", "&Copiar Tabla", "&Pegar Tabla", "&Aplicar correcciones",
				"Utiliza \"Corrección F\" para todas las tablas F", "&Exportar Tabla", "&Registros", "&Pantalla", "&Grafica", "Información del &Mapa", "Pantalla completa", "EC&U", "&Conectar", "&Historial",
				"Leer &Mapa", "&Descargar", "&Recuperación", "Resetear &TPS", "&Borrar Códigos de Error", "&Desconectar", "&Opciones", "&Lenguaje", "Inglés", "Francés",
				"Alemán", "Italiano", "Español", "Portugués", "", "Editar", "Cortar", "Copiar", "Pegar", "Borrar",
				"Deshacer", "Habilitar", "Deshabilitar", "Reanudar", "\rHistorial :\r", "Corrección F", "Corrección I", "Aire/Combustible", "Ralentí", "Válvula de Escape",
				"2° Acelerador", "Interruptor F-L", "Flujo Inyector : ", "Ralentí Objetivo A/F : ", "Limite Velocidad : ", "Límite Rev. (rpm) : ", "Ventilador (°C) : ", "Ajuste Velocidad (%) : ", "Pulso de cebado : ", "Lengüeta aire (rpm) : ",
				"Quickshifter (ms)", "Ralentí (rpm) : ", "", "Suma Chequeo de Software : ", "Tipo de ECU : ", "Información", "No Serie : ", "Mapa : ", "Suma Chequeo /P : ", "Tipo : ",
				"Suma Chequeo : ", "Vehículo", "Parámetros", "Tabla Acelerador", "&Cancelar", "&Ok", "&Borrar", "&Cerrar", "Interfaz", "Descarga",
				"Edición Mapa", "Tests", "Diagnosis", "Posición Acelerador (%)", "Presión del Aire (hPa)", "Motor (rpm)", "Carga del Motor (%)", "Temperatura (°C)", "Información del Mapa", "Registros",
				"Información de la Tabla", "Tabla ", "Panel de Instrumentos", "Códigos de Error", "Tipo : ", "Pos", "Rpm", "A/F", "Grado", "Marcha",
				"Tests y Ajustes", "     Sensores", "SAI", "Embrague", "Relé principal", "Bomba comb.", "Inter. arranque", "Relé arranque", "Lengüeta Aire", "Sensor O2",
				"Sensor O2 (2)", "", "", "", "Otros", "Voltaje de Batería", " TPS ", "", "", "Serie",
				"Pulso de inyección", "Momento de encendido", "Acelerador", "Sensor O2", "Ralentí", "Válvula de escape", "Temperatura", "Barométrico", "Carga del motor", "Nivel de combustible",
				"Bobina de encendido", "Regul. mezcla a largo plazo", "Presión del colector", "Encendido", "Seguridad", "Sensor O2 (1)", "Sensor O2 (2)", "", "Disposotivos", "SAI    ",
				"Válvula de escape", "Sensor O2", "2° Acelerador", "Lengüeta de aire", "EPC", "Sensor O2 (2)", "control de ralentí", "", "Cilindro 1 - 2 - 3 (ms)", "Momento encendido cilindro 1 - 2 - 3 (grados BTDC)",
				"Referencia - Voltaje sensor posición ", "Voltaje salida", "Rango adaptación fuera ralentí - Rango adaptación ralentí - Estado adaptación ralentí", "Velocidad referencia (rpm) - Estado adaptación control velocidad", "Paso objetivo control velocidad - Paso control velocidad", "Posición - Voltaje sensor posición", "Admisión aire - Voltaje sensor admisión aire - Voltaje sensor motor", "Presión - Voltaje sensor presión - Voltaje sensor MAP", "Calculado", "Voltaje del sensor",
				"Tiempo de permanencia cilindro 1 - 2 - 3 (ms)", "Corrección de combustible", "Velocidad referencia (rpm) - Posición válvula motor paso a paso", "Corrección combustible ralentí (CO) - Paso control velocidad", " % ", "Presión", "() Rango adaptación fuera ralentí - Rango adaptación ralentí - Estado adaptación ralentí", "Cilindro 1 -2 (ms)", "Posición (2)- Voltaje sensor posición (2)", "Voltaje salida 1 - 2",
				"Momento encendido cilindro 1 - 2 (grados BTDC)", "Tiempo de permanencia bobina encendido cilindro 1 - 2 (ms)", "Posición objetivo (2) - Sensor posición (2) - Voltaje sensor (2)", "Momento encendido cilindro 1 - 2 - 3 - 4 (grados BTDC)", "Velocidad referencia(rpm)", "Presión cilindro 1 - Voltaje sensor MAP 1 - 2", "Presión - Voltaje sensor presión", "Voltaje sensor pata lateral - Voltaje sensor inclinación", "Tiempo de permanencia 1 - 2 - 3 - 4 (ms)", "Cilindro 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Momento encendido (grados BTDC)", "Tiempo de permanencia bobina encendido (ms)", "Voltaje sensor MAP", "Referencia - Voltaje del sensor de posición del puño de acelerador", "Posición del motor del acelerador - Voltaje del sensor de posición del motor de acelerador", "Referencia", "Paso control velocidad", "Admisión aire", "Valore de salida",
				"Mínimo - Máximo", "Delta", "Corrección de combustible", "", "", "", "", "", "", "Aplicar \"Corrección F\" a las tablas L",
				"Transferencia fallida.\r", "Operación cancelada!", "La ECU está conectada pero no responde.\r¿Iniciar la recuperación de la ECU?", "Conexión interrumpida, descarga fallida.", " ECU conectada.\rAutentificación... ", "Desbloqueando la ECU... ", "Acceso permitido.\r", "Acceso no permitido.", "Acceso denegado.", "Llave no valida.\r",
				"Identificación de la ECU.\r", "Nº Serie ", "Conexión interrumpida.", "Descarga en progreso...\r", "Descarga terminada.\r", "Recuperación de la ECU en progreso...\r", "Recuperación de la ECU terminada.\r", "Lectura en progreso... ", "Lectura del historial terminada.\r¿Abrir la ventana de registros?", "Reiniciando la ECU...\r\r",
				"Tiempo excedido, transferencia fallida.\r", "¿Iniciar la recuperación de la ECU?", "La ECU no responde :\rComprueba la conexión del cable.\rApague y enciende el contacto.", "Archivo de Mapa desconocido.", "Tipo de Mapa desconocido.", "El archivo ", " ha cambiado.\r\r", "¿Guardar el cambio?", "Seleccionar un Mapa", "Guardar",
				"Lectura de Mapa terminada.", "Resetear TPS...", "Reseteo de TPS terminado.\r", "\rIniciando...", "¿Borrar todos los códigos de error?", "Códigos de error borrados.\r", "Código de error desconocido", "Llave incorrecta o archivo no encontrado, conexión con el vehículo no permitida\r", "Descarga fallida.", "No hay código de error",
				"Descripción", "Por favor espere...", "Seleccione un archivo PCIII o PCV", "Este archivo PCIII o PCV no es compatible con este Mapa", "Error mientras se leía el archivo", "Este archivo no es una tabla PCIII o PCV", "Comparar con...", "El tipo de Mapa debe ser idéntico", "", "Actuador del acelerador",
				"Inyectore", "Sensore O2", "Bobina de encendido", "tacómetro", "Ventilador de refrigeración", "Bomba de combustible", "Motor paso a paso ralentí", "Valvula control purga", "SAI", "Lengüeta del aire",
				"Valvula de escape", "2° Acelerador", "Ajuste EXBV", "Ajuste ISCV", "Resetear adaptación", "", "Resetear TPS", "Corr. mezcla ralentí (CO)", "Ajuste IACV", "Regul. mezcla largo plazo",
				"Ajuste el cable de acelerador", "Ajuste de posición del acelerador", "Ajuste TPS", "Regul. global mezcla", "", "", "¿Resetear TPS?", "¿", "?      ", "Resetear adaptación...",
				"Test/ajuste no disponible", "Test ", " Terminado", "Ajuste el TPS hasta que lea 0,60 voltios y haga doble click en \"Ajuste ISCV\" de nuevo", "Ajuste el ISCV hasta que lea 0,72 voltios y haga doble click en \"Ajuste ISCV\" de nuevo", "Adaptación del motor paso a paso del ralentí en progreso, no toque nada durante 15 segundos", "Ajuste el ISCV hasta que lea 0,75 voltios y haga doble click en \"Ajuste ISCV\" de nuevo", "Ajuste ISCV terminado", "Ajuste ISCV...\r", "Resetear ",
				" fallido", " terminado", "Mostrar siempre", "Mostrar al comienzo", "Estado de referencia de posición acelerador cerrado no adaptado", "Estado de referencia de posición acelerador cerrado adaptado", "Funcionamiento del sistema de injección en bucle abierto (Insuficiente temperatura del motor)", "Funcionamiento del sistema de injección en bucle cerrado (Estado normal)", "Funcionamiento del sistema de injección en bucle abierto (Estado normal)", "Funcionamiento del sistema de injección en bucle abierto (Fallo de sistema)",
				"Apague el interruptor de encendido y ajuste el cable de acelerador...", "Desactivar solo si las mariposas de acelerador secundarias\ro el dispositivo de acelerador secundario (motor paso a paso y 2º TPS ) son quitados    ", "", "Resetear &adaptación", "¿Resetear adaptación?", "Reseteo adaptación terminado.\r", "Por favor espere... posicionando la valvula de mariposa", "El cable de la mariposa de escape pueden ser ajustados ahora, doble click en \"Adjuste EXBV\" cuando termine", "Ajuste EXBV...\r", "Ajuste EXBV terminado",
				"La importación no puede usar la funcionalidad \"Gear advanced\".\rSeleccione la tabla a utilizar:\r ", "Intentando conectar...", "Autentificación...", "Conectado", "", "Auto-conectar", "Mapa", "Tipo ECU no soportada.", "&Leer", "No Mapa...",
				"Mapa no soportado o archivo corrupto.", "Este mapa no es compatible con esta ECU.", "Mapa incompatible.\r", "", "Quickshifter Tiempos de Corte", "Bajas Rpm:Medias Rpm:Altas Rpm", "Información", "Error", "Confirmar", "Advertencia",
				"&Interfaz", "&Acerca de", "Herramienta de reprogramación y diagnóstico para\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (todos modelos EFI excepto Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "Este programa es gratuito\r\ny solo puede distribuir de forma gratuita.", "Este programa necesita una resolución de pantalla de 1024x576 o superior.\r", "No se puede abrir el puerto", "Dispositivo USB no encontrado\rReconecte el interfaz USB/OBD", "&No", "&Sí", "",
				"No se puede abrir el puerto", "Dispositivo USB no encontrado\rReconecte el interfaz USB/OBD", "¿Aplicar las correcciones de combustible y encendido a las tablas principales\ry borrar las tablas de correcciones?", "Valores incorrectos pueden dañar el motor.\r¿Confirma la reprogramación de la ECU?", "Apague el contacto\rConecte el conector de programación\rEnciende el contacto", "Enviando la rutina de Borrado/Programación...", "Borrando bloques...\r", "Bloques n° ", " borrado.\r", "",
				"Apague el contacto\rDesconecte el conector de programación\rEnciende el contacto", "", "Descarga terminada... ", "", "Recuperación de la ECU terminada... ", "", "No se puede comunicar con el puerto ", "", "Voltaje del TPS 0% demasiado alto", "Voltaje del TPS 100% demasiado bajo",
				"Rotar acelerador desde plenamente cerrado hasta totalmente abierto y clic en \"Ok\" para validar"
			},
			{
				"&Arquivo", "Abrir Arquivo de &Mapa", "Sal&var Arquivo de Mapa", "&Sair", "&Importar Tabela PC", "&Comparar Arquivos", "&Editar", "&Copiar Tabela", "Co&lar Tabela", "&Aplicar Ajustes",
				"Usar \"Ajustes F\" para todas Tabelas F", "E&xportar Tabela", "&Logs", "&Vizualizar", "&Gráfico", "&Infos do Mapa", "Tela Cheia", "EC&U", "&Conectar", "&Histórico",
				"Ler &Mapa", "&Gravar Mapa", "&Recuperação", "Reset &TPS", "&Limpar Códigos de Erros", "&Desconectar", "&Opções", "&Idioma", "Inglês", "Francês",
				"Alemão", "Italiano", "Espanhol", "Português", "", "Editar", "Recortar", "Copiar", "Colar", "Excluir",
				"Desfazer", "Ativar", "Desativar", "Reset", "\rHistórico :\r", "F Ajuste ", "I Ajuste ", "Ar/Combustível", "Marcha Lenta", "Válvula Exaustão",
				"2o Acelerador", "Transição F/L", "Fluxo Injetor : ", "Mistura A/C Lenta : ", "Limite Velocidade : ", "Limite RPM (rpm) : ", "Ventoinha (°C) : ", "Ajuste Vel. (%) : ", "Pulso inicial : ", "Flap Admissão (rpm) : ",
				"Quickshifter (ms)", "Marcha Lenta (rpm) : ", "", "Software Checksum : ", "Tipo de ECU : ", "Infos ECU", "Num. Série : ", "Mapa : ", "Checksum / P : ", "Tipo : ",
				"Checksum : ", "Veículo", "Parâmetros", "Acelerador Tabela", "&Cancelar", "&Ok", "&Limpar", "&Fechar", "Interface", "Baixar",
				"Editar Mapa", "Testes", "Diagnósticos", "Posição Acel. (%)", "Pressão AR (hPa)", "Motor (rpm)", "Carga Motor (%)", "Temperatura (°C)", "Infos Mapa", "Logs",
				"Infos Tabela", "Tabela ", "Painel", "Códigos de Erro", "Tipo : ", "Pos", "Rpm", "A/C", "Graus", "Marcha",
				"Testes & Ajustes", "     Sensores", "SAI", "Embreagem", "Relê Princ", "Bomba Comb.", "Botão Start", "Relê Start", "Flap Ar", "Sensor O2",
				"Sensor O2 (2)", "", "", "", "Outros", "Volt. Bateria", " TPS ", "", "", "Serial",
				"Pulso de Injeção", "Tempo de Ignição", "Acelerador", "Sensor O2", "Marcha Lenta", "Válvula Exaustão", "Temperatura", "Barométrica", "Carga do Motor", "Nível de Combustível",
				"Bobina de Ignição", "Ajuste Comb Longo Prazo", "Pressão de admissão", "Ignição", "Segurança", "Sensor O2 #1", "Sensor O2 #2", "", "Dispositivos", "SAI    ",
				"Válvula Exaustão", "Sensor O2", "2o Acelerador", "Flap Ar", "EPC", "Sensor O2 (2)", "Controle Marcha Lenta", "", "Cilindro 1 - 2 - 3 (ms)", "Tempos do cylindro 1 - 2 - 3 ((graus BTDC)",
				"Referência - Voltagem do sensor de posição", "Voltagem Saída", "Gama de adequação fora da lenta - Gama de adequação na lenta - Status adequação marcha lenta", "Velocidade de referência (rpm) - Status do controle de adequação da velocidade", "Alvo do Passo do Controle de Velocidade - Passo do controle de velocidade", "Posição - Voltagem do sensor de posição", "Admissão de Ar - Volts sensor Admissão de Ar  - Voltagem do sensor motor", "Pressão - Voltagem do sensor de pressão - Voltagem do sensor MAP", "Calculado", "Voltagem do Sensor",
				"Tempo de permanência do cilindro 1 - 2 - 3 (ms)", "Ajuste de combustível relativo", "Velocidade de referência (rpm) - Posição adaptiva do stepper", "Ajuste de combustível na lenta (CO) - Passo do controle de velocidade", " % ", "Pressão", "() Gama de adequação fora da lenta - Gama de adequação na lenta - Status adequação marcha lenta", "Cilindro 1 - 2 (ms)", "Posição (2) - Voltagem do sensor de posição (2)", "Voltagem Saída 1 - 2",
				"Tempos do cylindro 1 - 2 ((graus BTDC)", "Tempo de permanência do cilindro 1 - 2 (ms)", "Posição alvo (2) - Posição do sensor (2) - Voltagem do sensor (2)", "Tempos do cylindro 1 - 2 - 3 - 4 (graus BTDC)", "Velocidade de referência (rpm)", "Pressão do cylindro 1 - Voltagem do sensor MAP 1 - 2", "Pressão - Voltagem do sensor de pressão", "Voltagem do sensor do cavalete lateral - Voltagem do sensor de queda", "Tempo de permanência 1 - 2 - 3 - 4 (ms)", "Cylindro 1 - 2 - 3 - 4 (ms)",
				"(ms)", "Tempos (graus BTDC)", "Tempo de permanência (ms)", "Voltagem do sensor MAP", "Referência - Voltagem do sensor de posição do punho do acelerador", "Posição do motor do acelerador - Voltagem do sensor de posição do motor do acelerador", "Referência", "Passo do controle de velocidade", "Admissão de Ar", "Valor de saída",
				"Mínimo - Máximo", "Delta", "Correção de Combustível", "", "", "", "", "", "", "Aplicar \"Ajustes F\" para Tabelas L",
				"Falha na transferência.\r", "Operação Cancelada!", "ECU conectada mas sem resposta.\rAcionar o modo de recuperação da ECU?", "Quebra de conexão, falha na gravação.", " ECU conectada.\rAutenticando... ", "Desbloqueando a ECU... ", "Acesso permitido.\r", "Acesso não permitido.", "Acesso Negado.", "Chave Inválida.\r",
				"Identificação da ECU.\r", "Número de Série ", "Quebra na conexão.", "Gravação em progresso...\r", "Gravação concluída.\r", "Recuperação da ECU em progresso...\r", "Recuperação da ECU concluída.\r", "Leitura em progresso... ", "Leitura do Histórico concluída.\rAbrir a janela de logs?", "Reiniciando ECU...\r\r",
				"Timeout, Falha na transferência.\r", "Carregar Recuperação da ECU?", "ECU não responde :\rVerifique a conexão do cabo.\rDesligue e religue a ignição.", "Arquivo de mapa desconhecido.", "Tipo de mapa desconhecido.", "Arquivo ", " modificado.\r\r", "Salvar as modificações?", "Selecione um mapa", "Salvar",
				"Leitura do mapa concluída.", "Reset TPS...", "Reset do TPS concluído.\r", "\rInicializando...", "Apagar todos códigos de problemas?", "Códigos de problemas apagados.\r", "Código de erro desconhecido", "Chave Inválida ou arquivo desconhecido, conexão com veículo não permitida\r", "Falha na gravação.", "Sem código de erro",
				"Descrição", "Por favor, aguarde...", "Selecione um arquivo PCIII ou PCV", "Este arquivo PCIII ou PCV não é compatível com este Mapa", "Erro de leitura no arquivo", "Este arquivo não contém uma tabela PCIII ou PCV", "Comparar com...", "O tipo do mapa deve ser idêntico", "", "Comando motor acelerador",
				"Injetor", "Sensor O2", "Bobina de Ignição", "Tacometro", "Ventoinha", "Bomba de Combustível", "Stepper marcha-lenta", "Válvula controle purgador", "SAI", "Flap de ar",
				"Válvula de Exaustão", "2o Acelerador", "Ajuste EXBV", "Ajuste ISCV", "Reset Adequação", "", "Reset TPS", "Ajuste Comb Lenta (CO)", "Ajuste IACV", "Ajuste Comb Longo Prazo",
				"Ajuste Cabo do Acelerador", "Ajuste Posição Acelerador", "Ajuste TPS", "Ajuste Comb global", "", "", "Reset TPS?", "", " ?    ", "Reset Adequação...",
				"Teste/Ajuste não suportado", "Teste ", " concluído", "Ajuste o TPS até ler 0,60 volts e dê um duplo-clique em \"Ajuste ISCV\" novamente", "Ajuste a porca do ICSV até ler 0,72 volts e dê um duplo-clique em \"Ajuste ISCV\" novamente", "Adequação do Stepper da marcha-lenta em progresso, não toque nada por 15 segundos", "Ajuste a porca do ICSV até ler 0,75 volts e dê um duplo-clique em  \"Ajuste ISCV\" novamente", "Ajuste ISCV completo", "Ajuste ISCV...\r", "Reset ",
				" falhou", " concluído", "Sempre mostrar", "Mostrar quando iniciar", "Status da posição de referência do acelerador fechado não adequado", "Status da posição de referência do acelerador fechado adequado", "Operação do sistema de injeção de combustível em loop aberto (temperatura do motor insuficiente)", "Operação do sistema de injeção de combustível em loop fechado (condição normal)", "Operação do sistema de injeção de combustível em loop aberto (condição normal)", "Operação do sistema de injeção de combustível em loop aberto (falha de sistema)",
				"Desligue a ignição e ajuste o cabo do acelerador...", "Desabilite somente se as válvulas do 2o acelerador\rou o dispositivo do 2o acelerador (motor de passo & 2o TPS) foram removidos", "", "Reset &Adequação", "Reset Adequação?", "Reset Adequação concluído.\r", "Por favor, aguarde... Posicionando a válvula de borboleta", "Os cabos da borboleta de exaustão aora podem ser ajustados. Duplo clique em \"Adjust EXBV\" após concluir", "Ajuste EXBV...\r", "Ajuste EXBV concluído",
				"A importação não pode usar a função \"Gear Advanced\".\rSelecione a tabela a ser utilizada:\r ", "Tentando conectar...", "Autenticação...", "Conectado", "", "Conexão Automática", "Mapa", "Tipo de ECU não suportada.", "&Ler", "Sem Mapa...",
				"Mapa não suportado ou arquivo corrompido.", "Este mapa não é compatível com a ECU.", "Mapa Incompatível.\r", "", "Tempos de corte Quickshifter", "Rpm baixo:Rpm médio:Rpm alto", "Informação", "Erro", "Confirmar", "Atenção",
				"&Interface", "S&obre", "Ferramenta de reprogramação & Diagnóstico para\r\nAprilia Caponord  &  RST Futura\r\nBenelli Tornado, TNT & TREK\r\nTriumph (todos modelos EFI exceto Tiger Explorer)\r\nKTM 690, 990 & 1190\r\n\r\n\r\n", "Este programa é um freeware\r\ne deve somente ser distribuido gratuitamente.", "Este software necessita de uma resolução superior a 1024x600.\r", "Impossivel abrir a porta ", "Dispositivo USB não reconhecido\rReconecte a interface USB/OBD.", "&Não", "&Sim", "",
				"Impossivel abrir a porta ", "Dispositivo USB não reconhecido\rReconecte a interface USB/OBD.", "Executar os ajustes de combustivel & ignição nas tabelas principais\re limpar as tabelas de ajustes?", "Valores incorretos podem danificar a ECU.\rConfirma a gravação para a ECU?", "Desligue a ignição\rConecte o plug de programação\rLigue a ignição", "Enviando rotina de Exclusão/Programação...", "Excluindo blocos...\r", "Bloco n° ", " excluído.\r", "",
				"Desligue a ignição\rRemova o plug de programação\rLigue a ignição", "", "Gravação concluída... ", "", "Recuperação da ECU concluída... ", "", "Não é possivel se comunicar o Porto ", "", "Voltagem do TPS 0% muito elevada", "Voltagem do TPS 100% muito baixo",
				"Movimento do acelerador de fechado para completamente aberta, em seguida, clique em \"OK\" para validar"
			}
		};
	}
}
