using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TuneECU
{

internal static class Program
{
	[DllImport("user32.dll")]
	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[STAThread]
	private static void Main()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		bool createdNew = true;
		Mutex obj = new Mutex(initiallyOwned: true, "TuneECU", out createdNew);
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string path = Path.Combine(baseDirectory, "TuneLibrary.dll");
		if (File.Exists(path))
		{
			if (createdNew)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run((Form)(object)new ISOMain());
				GC.KeepAlive(obj);
			}
			else
			{
				IntPtr intPtr = FindWindow(null, "TuneECU");
				ShowWindow(intPtr, 1);
				SetForegroundWindow(intPtr);
			}
		}
		else
		{
			MessageBox.Show("    The program can't start because TuneLibrary.dll is missing !!!        ", "TuneECU", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
	}
}
}
