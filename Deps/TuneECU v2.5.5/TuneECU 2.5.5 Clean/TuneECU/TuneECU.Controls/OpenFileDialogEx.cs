using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TuneECU.OS;

namespace TuneECU.Controls
{

public class OpenFileDialogEx : UserControl
{
	public delegate void FileNameChangedHandler(OpenFileDialogEx sender, string filePath);

	private class OpenDialogNative : NativeWindow, IDisposable
	{
		private SetWindowPosFlags UFLAGSSIZE = (SetWindowPosFlags)530;

		private SetWindowPosFlags UFLAGSHIDE = (SetWindowPosFlags)659;

		private SetWindowPosFlags UFLAGSZORDER = (SetWindowPosFlags)19;

		private Size mOriginalSize;

		private IntPtr mOpenDialogHandle;

		private IntPtr mListViewPtr;

		private WINDOWINFO mListViewInfo;

		private BaseDialogNative mBaseDialogNative;

		private IntPtr mComboFolders;

		private WINDOWINFO mComboFoldersInfo;

		private IntPtr mGroupButtons;

		private WINDOWINFO mGroupButtonsInfo;

		private IntPtr mComboFileName;

		private WINDOWINFO mComboFileNameInfo;

		private IntPtr mComboExtensions;

		private WINDOWINFO mComboExtensionsInfo;

		private IntPtr mOpenButton;

		private WINDOWINFO mOpenButtonInfo;

		private IntPtr mCancelButton;

		private WINDOWINFO mCancelButtonInfo;

		private IntPtr mHelpButton;

		private WINDOWINFO mHelpButtonInfo;

		private OpenFileDialogEx mSourceControl;

		private IntPtr mToolBarFolders;

		private WINDOWINFO mToolBarFoldersInfo;

		private IntPtr mLabelFileName;

		private WINDOWINFO mLabelFileNameInfo;

		private IntPtr mLabelFileType;

		private WINDOWINFO mLabelFileTypeInfo;

		private IntPtr mChkReadOnly;

		private WINDOWINFO mChkReadOnlyInfo;

		private bool mIsClosing;

		private bool mInitializated;

		private RECT mOpenDialogWindowRect = default(RECT);

		private RECT mOpenDialogClientRect = default(RECT);

		public bool IsClosing
		{
			get
			{
				return mIsClosing;
			}
			set
			{
				mIsClosing = value;
			}
		}

		public OpenDialogNative(IntPtr handle, OpenFileDialogEx sourceControl)
		{
			mOpenDialogHandle = handle;
			mSourceControl = sourceControl;
			((NativeWindow)this).AssignHandle(mOpenDialogHandle);
		}

		private void BaseDialogNative_FileNameChanged(BaseDialogNative sender, string filePath)
		{
			if (mSourceControl != null)
			{
				mSourceControl.OnFileNameChanged(filePath);
			}
		}

		private void BaseDialogNative_FolderNameChanged(BaseDialogNative sender, string folderName)
		{
			if (mSourceControl != null)
			{
				mSourceControl.OnFolderNameChanged(folderName);
			}
		}

		private void BaseDialogNative_ClosingDialog(BaseDialogNative sender)
		{
			if (mSourceControl != null)
			{
				mSourceControl.OnClosingDialog();
			}
		}

		public void Dispose()
		{
			((NativeWindow)this).ReleaseHandle();
			if (mBaseDialogNative != null)
			{
				mBaseDialogNative.FileNameChanged -= BaseDialogNative_FileNameChanged;
				mBaseDialogNative.FolderNameChanged -= BaseDialogNative_FolderNameChanged;
				mBaseDialogNative.ClosingDialog -= BaseDialogNative_ClosingDialog;
				mBaseDialogNative.Dispose();
			}
		}

		private void PopulateWindowsHandlers()
		{
			Win32.EnumChildWindows(mOpenDialogHandle, OpenFileDialogEnumWindowCallBack, 0);
		}

		private bool OpenFileDialogEnumWindowCallBack(IntPtr hwnd, int lParam)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			Win32.GetClassName(hwnd, stringBuilder, stringBuilder.Capacity);
			int dlgCtrlID = Win32.GetDlgCtrlID(hwnd);
			Win32.GetWindowInfo(hwnd, out var pwi);
			if (stringBuilder.ToString().StartsWith("#32770"))
			{
				mBaseDialogNative = new BaseDialogNative(hwnd);
				mBaseDialogNative.FileNameChanged += BaseDialogNative_FileNameChanged;
				mBaseDialogNative.FolderNameChanged += BaseDialogNative_FolderNameChanged;
				mBaseDialogNative.ClosingDialog += BaseDialogNative_ClosingDialog;
				return true;
			}
			switch ((ControlsID)dlgCtrlID)
			{
			case ControlsID.DefaultView:
				mListViewPtr = hwnd;
				Win32.GetWindowInfo(hwnd, out mListViewInfo);
				if (mSourceControl.DefaultViewMode != FolderViewMode.Default)
				{
					Win32.SendMessage(mListViewPtr, 273, (int)mSourceControl.DefaultViewMode, 0);
				}
				break;
			case ControlsID.ComboFolder:
				mComboFolders = hwnd;
				mComboFoldersInfo = pwi;
				break;
			case ControlsID.ComboFileType:
				mComboExtensions = hwnd;
				mComboExtensionsInfo = pwi;
				break;
			case ControlsID.ComboFileName:
				if (stringBuilder.ToString().ToLower() == "comboboxex32")
				{
					mComboFileName = hwnd;
					mComboFileNameInfo = pwi;
				}
				break;
			case ControlsID.GroupFolder:
				mGroupButtons = hwnd;
				mGroupButtonsInfo = pwi;
				break;
			case ControlsID.LeftToolBar:
				mToolBarFolders = hwnd;
				mToolBarFoldersInfo = pwi;
				break;
			case ControlsID.ButtonOpen:
				mOpenButton = hwnd;
				mOpenButtonInfo = pwi;
				break;
			case ControlsID.ButtonCancel:
				mCancelButton = hwnd;
				mCancelButtonInfo = pwi;
				break;
			case ControlsID.ButtonHelp:
				mHelpButton = hwnd;
				mHelpButtonInfo = pwi;
				break;
			case ControlsID.CheckBoxReadOnly:
				mChkReadOnly = hwnd;
				mChkReadOnlyInfo = pwi;
				break;
			case ControlsID.LabelFileName:
				mLabelFileName = hwnd;
				mLabelFileNameInfo = pwi;
				break;
			case ControlsID.LabelFileType:
				mLabelFileType = hwnd;
				mLabelFileTypeInfo = pwi;
				break;
			}
			return true;
		}

		private void InitControls()
		{
			mInitializated = true;
			Win32.GetClientRect(mOpenDialogHandle, ref mOpenDialogClientRect);
			Win32.GetWindowRect(mOpenDialogHandle, ref mOpenDialogWindowRect);
			PopulateWindowsHandlers();
			switch (mSourceControl.StartLocation)
			{
			case AddonWindowLocation.Right:
				((Control)mSourceControl).Location = new Point((int)(mOpenDialogClientRect.Width - ((Control)mSourceControl).Width), 0);
				Win32.SetParent(((Control)mSourceControl).Handle, mOpenDialogHandle);
				Win32.SetWindowPos(((Control)mSourceControl).Handle, (IntPtr)1L, 0, 0, 0, 0, UFLAGSZORDER);
				break;
			case AddonWindowLocation.Bottom:
				((Control)mSourceControl).Location = new Point(0, (int)(mOpenDialogClientRect.Height - ((Control)mSourceControl).Height));
				Win32.SetParent(((Control)mSourceControl).Handle, mOpenDialogHandle);
				Win32.SetWindowPos(((Control)mSourceControl).Handle, (IntPtr)1L, 0, 0, 0, 0, UFLAGSZORDER);
				break;
			case AddonWindowLocation.None:
				Win32.SetParent(((Control)mSourceControl).Handle, mOpenDialogHandle);
				Win32.SetWindowPos(((Control)mSourceControl).Handle, (IntPtr)1L, 0, 0, 0, 0, UFLAGSZORDER);
				break;
			}
		}

		protected override void WndProc(ref Message m)
		{
			switch (((Message)(ref m)).Msg)
			{
			case 24:
				mInitializated = true;
				InitControls();
				if (mSourceControl.StartLocation == AddonWindowLocation.None)
				{
					Win32.GetWindowRect(mOpenDialogHandle, ref mOpenDialogWindowRect);
					Win32.SetWindowPos(mOpenDialogHandle, IntPtr.Zero, (int)mOpenDialogWindowRect.left, (int)mOpenDialogWindowRect.top, (int)mOpenDialogWindowRect.Width, mSize, UFLAGSSIZE);
				}
				break;
			case 70:
				if (mIsClosing)
				{
					break;
				}
				if (!mInitializated)
				{
					WINDOWPOS wINDOWPOS = (WINDOWPOS)Marshal.PtrToStructure(((Message)(ref m)).LParam, typeof(WINDOWPOS));
					if (mSourceControl.StartLocation == AddonWindowLocation.Bottom && wINDOWPOS.flags != 0 && (wINDOWPOS.flags & 1) != 1 && (wINDOWPOS.flags & 2) == 2)
					{
						mOriginalSize = new Size(wINDOWPOS.cx, wINDOWPOS.cy);
						if (mSize == 0)
						{
							mSize = wINDOWPOS.cy;
						}
						wINDOWPOS.cy = mSize + ((Control)mSourceControl).Height;
						((Control)mSourceControl).Visible = true;
						Marshal.StructureToPtr((object)wINDOWPOS, ((Message)(ref m)).LParam, true);
					}
					if (mSourceControl.StartLocation == AddonWindowLocation.None && wINDOWPOS.flags != 0 && (wINDOWPOS.flags & 1) != 1 && (wINDOWPOS.flags & 2) == 2)
					{
						mOriginalSize = new Size(wINDOWPOS.cx, wINDOWPOS.cy);
						if (mSize == 0)
						{
							mSize = wINDOWPOS.cy;
						}
						wINDOWPOS.cy = mSize;
						((Control)mSourceControl).Visible = false;
						Marshal.StructureToPtr((object)wINDOWPOS, ((Message)(ref m)).LParam, true);
					}
				}
				switch (mSourceControl.StartLocation)
				{
				case AddonWindowLocation.Right:
				{
					RECT rect = default(RECT);
					Win32.GetClientRect(mOpenDialogHandle, ref rect);
					((Control)mSourceControl).Height = (int)rect.Height;
					break;
				}
				case AddonWindowLocation.Bottom:
				{
					RECT rect = default(RECT);
					Win32.GetClientRect(mOpenDialogHandle, ref rect);
					((Control)mSourceControl).Width = (int)rect.Width;
					break;
				}
				case AddonWindowLocation.None:
				{
					RECT rect = default(RECT);
					Win32.GetClientRect(mOpenDialogHandle, ref rect);
					((Control)mSourceControl).Width = (int)rect.Width;
					((Control)mSourceControl).Height = (int)rect.Height;
					break;
				}
				}
				break;
			case 642:
				if (((Message)(ref m)).WParam == (IntPtr)1L)
				{
					mIsClosing = true;
					mSourceControl.OnClosingDialog();
					Win32.SetWindowPos(mOpenDialogHandle, IntPtr.Zero, 0, 0, 0, 0, UFLAGSHIDE);
					Win32.GetWindowRect(mOpenDialogHandle, ref mOpenDialogWindowRect);
					Win32.SetWindowPos(mOpenDialogHandle, IntPtr.Zero, (int)mOpenDialogWindowRect.left, (int)mOpenDialogWindowRect.top, mOriginalSize.Width, mOriginalSize.Height, UFLAGSSIZE);
				}
				break;
			}
			((NativeWindow)this).WndProc(ref m);
		}
	}

	private class BaseDialogNative : NativeWindow, IDisposable
	{
		public delegate void FileNameChangedHandler(BaseDialogNative sender, string filePath);

		public delegate void EventHandler(BaseDialogNative sender);

		private IntPtr mhandle;

		public event FileNameChangedHandler FileNameChanged;

		public event FileNameChangedHandler FolderNameChanged;

		public event EventHandler ClosingDialog;

		public BaseDialogNative(IntPtr handle)
		{
			mhandle = handle;
			((NativeWindow)this).AssignHandle(handle);
		}

		public void Dispose()
		{
			((NativeWindow)this).ReleaseHandle();
		}

		protected override void WndProc(ref Message m)
		{
			int msg = ((Message)(ref m)).Msg;
			if (msg == 78)
			{
				OFNOTIFY oFNOTIFY = (OFNOTIFY)Marshal.PtrToStructure(((Message)(ref m)).LParam, typeof(OFNOTIFY));
				if (oFNOTIFY.hdr.code == 4294966694u)
				{
					StringBuilder stringBuilder = new StringBuilder(256);
					Win32.SendMessage(Win32.GetParent(mhandle), 1125, 256, stringBuilder);
					if (FileNameChanged != null)
					{
						FileNameChanged(this, stringBuilder.ToString());
					}
				}
				else if (oFNOTIFY.hdr.code == 4294966693u)
				{
					StringBuilder stringBuilder2 = new StringBuilder(256);
					Win32.SendMessage(Win32.GetParent(mhandle), 1126, 256, stringBuilder2);
					if (FolderNameChanged != null)
					{
						FolderNameChanged(this, stringBuilder2.ToString());
					}
				}
			}
			((NativeWindow)this).WndProc(ref m);
		}
	}

	private class DummyForm : Form
	{
		private OpenDialogNative mNativeDialog;

		private OpenFileDialogEx mFileDialogEx;

		private bool mWatchForActivate;

		private IntPtr mOpenDialogHandle = IntPtr.Zero;

		public bool WatchForActivate
		{
			get
			{
				return mWatchForActivate;
			}
			set
			{
				mWatchForActivate = value;
			}
		}

		public DummyForm(OpenFileDialogEx fileDialogEx)
		{
			mFileDialogEx = fileDialogEx;
			((Control)this).Text = "";
			((Form)this).StartPosition = (FormStartPosition)0;
			((Form)this).Location = new Point(-32000, -32000);
			((Form)this).ShowInTaskbar = false;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (mNativeDialog != null)
			{
				mNativeDialog.Dispose();
			}
			((Form)this).OnClosing(e);
		}

		protected override void WndProc(ref Message m)
		{
			if (mWatchForActivate && ((Message)(ref m)).Msg == 6)
			{
				mWatchForActivate = false;
				mOpenDialogHandle = ((Message)(ref m)).LParam;
				mNativeDialog = new OpenDialogNative(((Message)(ref m)).LParam, mFileDialogEx);
			}
			((Form)this).WndProc(ref m);
		}
	}

	private IContainer components;

	protected OpenFileDialog dlgOpen;

	protected SaveFileDialog dlgSave;

	private SetWindowPosFlags UFLAGSHIDE = (SetWindowPosFlags)659;

	private AddonWindowLocation mStartLocation = AddonWindowLocation.Right;

	private FolderViewMode mDefaultViewMode = FolderViewMode.Default;

	private static int mSize;

	public OpenFileDialog OpenDialog => dlgOpen;

	public SaveFileDialog SaveDialog => dlgSave;

	[DefaultValue(AddonWindowLocation.Bottom)]
	public AddonWindowLocation StartLocation
	{
		get
		{
			return mStartLocation;
		}
		set
		{
			mStartLocation = value;
		}
	}

	[DefaultValue(FolderViewMode.Default)]
	public FolderViewMode DefaultViewMode
	{
		get
		{
			return mDefaultViewMode;
		}
		set
		{
			mDefaultViewMode = value;
		}
	}

	public event FileNameChangedHandler FileNameChanged;

	public event FileNameChangedHandler FolderNameChanged;

	public event EventHandler ClosingDialog;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		dlgOpen = new OpenFileDialog();
		((Control)this).SuspendLayout();
		((Control)this).Name = "OpenFileDialogEx";
		((Control)this).Size = new Size(255, 246);
		dlgSave = new SaveFileDialog();
		((Control)this).Name = "SaveFileDialogEx";
		((Control)this).Size = new Size(255, 246);
		((Control)this).ResumeLayout();
	}

	public OpenFileDialogEx()
	{
		InitializeComponent();
	}

	public virtual void OnFileNameChanged(string fileName)
	{
		if (FileNameChanged != null)
		{
			FileNameChanged(this, fileName);
		}
	}

	public virtual void OnFolderNameChanged(string folderName)
	{
		if (FolderNameChanged != null)
		{
			FolderNameChanged(this, folderName);
		}
	}

	public virtual void OnClosingDialog()
	{
		if (ClosingDialog != null)
		{
			ClosingDialog(this, new EventArgs());
		}
	}

	public string ShowOpenDialog(IWin32Window owner)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		DummyForm dummyForm = new DummyForm(this);
		((Form)dummyForm).Show(owner);
		Win32.SetWindowPos(((Control)dummyForm).Handle, IntPtr.Zero, 0, 0, 0, 0, UFLAGSHIDE);
		dummyForm.WatchForActivate = true;
		try
		{
			((CommonDialog)dlgOpen).ShowDialog((IWin32Window)(object)dummyForm);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		((Component)(object)dummyForm).Dispose();
		((Form)dummyForm).Close();
		return ((FileDialog)dlgOpen).FileName;
	}

	public string ShowSaveDialog(IWin32Window owner)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		DummyForm dummyForm = new DummyForm(this);
		((Form)dummyForm).Show(owner);
		Win32.SetWindowPos(((Control)dummyForm).Handle, IntPtr.Zero, 0, 0, 0, 0, UFLAGSHIDE);
		dummyForm.WatchForActivate = true;
		try
		{
			DialogResult val = ((CommonDialog)dlgSave).ShowDialog((IWin32Window)(object)dummyForm);
			if ((int)val != 1)
			{
				((FileDialog)dlgSave).FileName = "";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		((Component)(object)dummyForm).Dispose();
		((Form)dummyForm).Close();
		return ((FileDialog)dlgSave).FileName;
	}
}
}
