using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TuneLibrary;

namespace TuneECU
{

public class IDraw : ISOMain
{
	private const int DASH_WIDTH = 800;

	private const int DASH_SIZE = 440;

	private const int DASH_HEIGHT = 448;

	private const int NEEDLE_LARGE = 375;

	private const int NEEDLE_SMALL = 203;

	public static SolidBrush blackBrush;

	public static SolidBrush shadowBrush;

	public static SolidBrush whiteBrush;

	public static SolidBrush darkBrush;

	public static SolidBrush dimBrush;

	public static SolidBrush blueBrush;

	public static SolidBrush limeBrush;

	public static SolidBrush redBrush;

	public static SolidBrush grayBrush;

	private static Pen cPen;

	private static Pen gPen;

	private static Pen sPen;

	private static Pen rPen;

	private static SolidBrush gBrush;

	public static Color editColor;

	public static Font rFont;

	public static Font edFont;

	public static Font lbFont;

	public static Font pFont;

	public static Font tFont;

	public static Font iFont;

	public static Font tbFont;

	public static Font dFont;

	public static Font sgFont;

	private static Rectangle LEDRect;

	public static int[] dGauge;

	public static Rectangle[] dashRegion;

	public static int[] LCD_data;

	public static int[] Indicator;

	public static int[] Angle_Meter;

	private static int[] Matrix;

	private static byte[] rpmData;

	private static int Spin;

	private static Rectangle nPart;

	private static Rectangle aPart;

	public static int wAngle;

	private static Bitmap Axis_bmp;

	private static Bitmap Dash_bmp;

	private static Bitmap Counter_bmp;

	private static Bitmap Dark_bmp;

	private static Bitmap Indic_bmp;

	private static Bitmap mLogo_bmp;

	private static Bitmap Picto_bmp;

	private static Bitmap LCDB_bmp;

	private static Bitmap LCD70_bmp;

	private static Bitmap LCD28_bmp;

	private static Bitmap LCD20_bmp;

	private static Bitmap LED_bmp;

	private static Bitmap Logos_bmp;

	private static Bitmap Label_bmp;

	private static Bitmap cMask_bmp;

	private static Bitmap mMask_bmp;

	private static Bitmap NeedleL_bmp;

	private static Bitmap NeedleS_bmp;

	private static Bitmap BtnMode_bmp;

	private static ImageAttributes imgAttr;

	private static ImageAttributes bckAttr;

	private static ImageAttributes hiAttr;

	private static ImageAttributes loAttr;

	private static ColorMatrix cMatrix;

	private static ColorMatrix fMatrix;

	private static ColorMatrix gMatrix;

	private static ColorMatrix mMatrix;

	public static void initFonts()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		float num = 792f / ISOMain.dpi;
		float num2 = 864f / ISOMain.dpi;
		float num3 = 936f / ISOMain.dpi;
		rFont = new Font("Microsoft Sans Serif", num, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		edFont = new Font("Microsoft Sans Serif", num, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		lbFont = new Font("Microsoft Sans Serif", num, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		pFont = new Font("Tahoma", num2, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		tFont = new Font("Tahoma", num, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		iFont = new Font("Tahoma", num, (FontStyle)2, (GraphicsUnit)3, (byte)0);
		tbFont = new Font("Tahoma", num, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		dFont = new Font("Tahoma", num3, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		sgFont = new Font("Segoe U", num2, (FontStyle)0, (GraphicsUnit)3, (byte)0);
	}

	public static void LoadDashBmp()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		ResourceManager resourceManager = new ResourceManager("TuneECU.Properties.Resources", Assembly.GetExecutingAssembly());
		string name = "Dashboard";
		Image val = (Image)resourceManager.GetObject(name);
		Dash_bmp = new Bitmap(val);
		name = "Counter";
		val = (Image)resourceManager.GetObject(name);
		Counter_bmp = new Bitmap(val);
		name = "Dark";
		val = (Image)resourceManager.GetObject(name);
		Dark_bmp = new Bitmap(val);
		name = "mLogo";
		val = (Image)resourceManager.GetObject(name);
		mLogo_bmp = new Bitmap(val);
		name = "Mask_C";
		val = (Image)resourceManager.GetObject(name);
		cMask_bmp = new Bitmap(val);
		name = "Mask_M";
		val = (Image)resourceManager.GetObject(name);
		mMask_bmp = new Bitmap(val);
		name = "Picto";
		val = (Image)resourceManager.GetObject(name);
		Picto_bmp = new Bitmap(val);
		name = "Indicator";
		val = (Image)resourceManager.GetObject(name);
		Indic_bmp = new Bitmap(val);
		name = "Logos";
		val = (Image)resourceManager.GetObject(name);
		Logos_bmp = new Bitmap(val);
		name = "Label";
		val = (Image)resourceManager.GetObject(name);
		Label_bmp = new Bitmap(val);
		name = "Needle_L";
		val = (Image)resourceManager.GetObject(name);
		NeedleL_bmp = new Bitmap(val);
		name = "Needle_S";
		val = (Image)resourceManager.GetObject(name);
		NeedleS_bmp = new Bitmap(val);
		name = "BtnMode";
		val = (Image)resourceManager.GetObject(name);
		BtnMode_bmp = new Bitmap(val);
		name = "Axes";
		val = (Image)resourceManager.GetObject(name);
		Axis_bmp = new Bitmap(val);
		name = "LCD_B";
		val = (Image)resourceManager.GetObject(name);
		LCDB_bmp = new Bitmap(val);
		name = "LCD_70";
		val = (Image)resourceManager.GetObject(name);
		LCD70_bmp = new Bitmap(val);
		name = "LCD_28";
		val = (Image)resourceManager.GetObject(name);
		LCD28_bmp = new Bitmap(val);
		name = "LCD_20";
		val = (Image)resourceManager.GetObject(name);
		LCD20_bmp = new Bitmap(val);
		name = "LED";
		val = (Image)resourceManager.GetObject(name);
		LED_bmp = new Bitmap(val);
		Spin = dGauge[42];
		nPart = new Rectangle(dGauge[2] - 187, dGauge[3] - 187, 375, 375);
		aPart = new Rectangle(dGauge[2] - Spin / 2, dGauge[3] - Spin / 2, Spin, Spin);
		int num = 440;
		int num2 = 440;
		int num3 = num * num2 * 4;
		rpmData = new byte[num3];
		Rectangle rectangle = new Rectangle(0, 0, num, num2);
		BitmapData val2 = Counter_bmp.LockBits(rectangle, (ImageLockMode)3, (PixelFormat)2498570);
		IntPtr scan = val2.Scan0;
		Marshal.Copy(scan, rpmData, 0, num3);
		Counter_bmp.UnlockBits(val2);
		sPen.DashStyle = (DashStyle)2;
		sPen.Width = 1f;
		cMatrix.Matrix33 = 0.4f;
		fMatrix.Matrix33 = 1f;
		gMatrix.Matrix33 = 0.11f;
		mMatrix.Matrix33 = 0.7f;
		imgAttr.SetColorMatrix(cMatrix);
		bckAttr.SetColorMatrix(gMatrix);
		hiAttr.SetColorMatrix(fMatrix);
		loAttr.SetColorMatrix(mMatrix);
	}

	private static Bitmap DrawCarbonPaper(int skin)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		int[] array = new int[5] { 0, 4, 3, 2, 1 };
		int num = 800;
		int num2 = 448;
		int num3 = 480;
		double num4 = 0.16;
		Bitmap val = new Bitmap(num, num2);
		Rectangle rectangle = new Rectangle(0, 0, num, num2);
		BitmapData val2 = val.LockBits(rectangle, (ImageLockMode)3, (PixelFormat)137224);
		IntPtr scan = val2.Scan0;
		int stride = val2.Stride;
		int num5 = num * num2 * 3;
		byte[] array2 = new byte[num5];
		for (int i = 0; i < num2; i++)
		{
			int num6 = array[i % 5];
			for (int j = 0; j < num; j++)
			{
				double num7 = ((double)(num3 - j) * num4 * 2.0 / 1000.0 + 1.0) / ((double)i * num4 / 1000.0 + 1.0);
				int num8 = Matrix[skin * 2 + (j + num6) % 5];
				int num9 = i * stride + j * 3;
				array2[num9] = (byte)Math.Round((double)(num8 & 0xFF) * num7);
				array2[num9 + 1] = (byte)Math.Round((double)((num8 >> 8) & 0xFF) * num7);
				array2[num9 + 2] = (byte)Math.Round((double)((num8 >> 16) & 0xFF) * num7);
			}
		}
		Marshal.Copy(array2, 0, scan, num5);
		val.UnlockBits(val2);
		return val;
	}

	private static Bitmap PaintMeterMark()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		int num = 440;
		int num2 = 440;
		Bitmap val = new Bitmap(num, num2);
		Rectangle rectangle = new Rectangle(0, 0, num, num2);
		BitmapData val2 = val.LockBits(rectangle, (ImageLockMode)3, (PixelFormat)2498570);
		BitmapData val3 = cMask_bmp.LockBits(rectangle, (ImageLockMode)3, (PixelFormat)2498570);
		IntPtr scan = val2.Scan0;
		IntPtr scan2 = val3.Scan0;
		int stride = val2.Stride;
		int num3 = num * num2 * 4;
		byte[] array = new byte[num3];
		byte[] array2 = new byte[num3];
		Marshal.Copy(scan2, array2, 0, num3);
		byte b = (byte)ISOMain.RevCount;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				int num4 = i * stride + j * 4;
				byte b2 = rpmData[num4 + b];
				bool flag = ISOMain._KTM & (array2[num4 + 1] < 240);
				if (b2 > 64)
				{
					array[num4] = (byte)((double)(int)b2 * (flag ? 0.15 : 1.0));
					array[num4 + 1] = (byte)((double)(int)b2 * (flag ? 0.45 : 1.0));
					array[num4 + 2] = b2;
					array[num4 + 3] = rpmData[num4 + 3];
				}
			}
		}
		Marshal.Copy(array, 0, scan, num3);
		val.UnlockBits(val2);
		cMask_bmp.UnlockBits(val3);
		return val;
	}

	private static Bitmap PaintPicto(int src)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		int num = dGauge[14];
		int num2 = dGauge[15];
		int num3 = num * num2 * 4;
		byte[] array = new byte[num3];
		byte[] array2 = new byte[num3];
		byte[] array3 = new byte[num3];
		Bitmap val = new Bitmap(num, num2);
		Bitmap val2 = new Bitmap(num, num2);
		Graphics val3 = Graphics.FromImage((Image)(object)val);
		Rectangle rectangle = new Rectangle(0, 0, num, num2);
		val3.DrawImage((Image)(object)Picto_bmp, rectangle, src, 0, num, num2, (GraphicsUnit)2);
		Rectangle rectangle2 = new Rectangle(0, 0, num, num2);
		BitmapData val4 = val.LockBits(rectangle2, (ImageLockMode)3, (PixelFormat)2498570);
		IntPtr scan = val4.Scan0;
		Marshal.Copy(scan, array, 0, num3);
		val.UnlockBits(val4);
		BitmapData val5 = val2.LockBits(rectangle2, (ImageLockMode)3, (PixelFormat)2498570);
		BitmapData val6 = mMask_bmp.LockBits(rectangle2, (ImageLockMode)3, (PixelFormat)2498570);
		IntPtr scan2 = val5.Scan0;
		IntPtr scan3 = val6.Scan0;
		Marshal.Copy(scan3, array3, 0, num3);
		int stride = val5.Stride;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				int num4 = i * stride + j * 4;
				byte b = array[num4];
				bool flag = ISOMain._KTM & (array3[num4 + 1] < 240);
				if (b > 64)
				{
					array2[num4] = (byte)((double)(int)b * (flag ? 0.15 : 1.0));
					array2[num4 + 1] = (byte)((double)(int)b * (flag ? 0.45 : 1.0));
					array2[num4 + 2] = b;
					array2[num4 + 3] = array[num4 + 3];
				}
			}
		}
		Marshal.Copy(array2, 0, scan2, num3);
		val2.UnlockBits(val5);
		mMask_bmp.UnlockBits(val6);
		return val2;
	}

	private static Bitmap PaintBack(Bitmap img)
	{
		if (img == null)
		{
			img = DrawCarbonPaper((!ISOMain._KTM) ? (ISOMain._Apri ? 1 : ((ISOMain._Bene | ISOMain._Walbro) ? 4 : 2)) : 0);
		}
		Graphics val = Graphics.FromImage((Image)(object)img);
		int width = ((Image)Dark_bmp).Width;
		int height = ((Image)Dark_bmp).Height;
		int x = dashRegion[1].X - 8;
		int y;
		Rectangle rectangle;
		for (int i = 1; i < 4; i++)
		{
			y = dashRegion[i].Y - 9;
			rectangle = new Rectangle(x, y, width, width * 9 / 16);
			val.DrawImage((Image)(object)Dark_bmp, rectangle, 0, 0, width, width * 9 / 16, (GraphicsUnit)2, bckAttr);
		}
		x = dashRegion[0].X - 32;
		y = dashRegion[0].Y - 32;
		rectangle = new Rectangle(x, y, width * 2, height * 2);
		val.DrawImage((Image)(object)Dark_bmp, rectangle, 0, 0, width, height, (GraphicsUnit)2, bckAttr);
		width = ((Image)mLogo_bmp).Width;
		height = ((Image)mLogo_bmp).Height;
		rectangle = new Rectangle(800 - width, 448 - height, width, height);
		val.DrawImage((Image)(object)mLogo_bmp, rectangle, 0, 0, width, height, (GraphicsUnit)2);
		return img;
	}

	public static void LED_Paint(PaintEventArgs e)
	{
		e.Graphics.DrawImage((Image)(object)LED_bmp, LEDRect, 0, ISOMain.mLed * 9, 24, 9, (GraphicsUnit)2);
	}

	public static Bitmap PaintDash(int mode)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		bool flag = (mode == 0) & ISOMain._Walbro;
		bool flag2 = ISOMain.sagemECU | ISOMain._Walbro;
		ImageAttributes[] array = (ImageAttributes[])(object)new ImageAttributes[5]
		{
			new ImageAttributes(),
			new ImageAttributes(),
			new ImageAttributes(),
			new ImageAttributes(),
			new ImageAttributes()
		};
		array[0] = (((ISOMain.mView & 0x48) == 72) ? hiAttr : loAttr);
		array[1] = (((ISOMain.mView & 0x41) == 65) ? hiAttr : loAttr);
		array[2] = (((ISOMain.mView & 0x42) == 66) ? hiAttr : loAttr);
		array[3] = (((ISOMain.mView & 0x44) == 68) ? hiAttr : loAttr);
		array[4] = (((ISOMain.mView & 0x40) == 64) ? hiAttr : loAttr);
		Bitmap val = new Bitmap(800, 448);
		Bitmap val2 = PaintBack(null);
		Bitmap val3 = PaintMeterMark();
		Graphics val4 = Graphics.FromImage((Image)(object)val);
		Rectangle rectangle = new Rectangle(Indicator[16], Indicator[17], ((Image)Dash_bmp).Width, ((Image)Dash_bmp).Height);
		Rectangle rectangle2 = new Rectangle(0, 0, 800, 448);
		val4.DrawImage((Image)(object)val2, rectangle2, 0, 0, 800, 448, (GraphicsUnit)2);
		rectangle2 = new Rectangle(dGauge[2] - 220, 0, 440, 440);
		val4.DrawImage((Image)(object)Dash_bmp, rectangle, 0, 0, ((Image)Dash_bmp).Width, ((Image)Dash_bmp).Height, (GraphicsUnit)2, array[0]);
		val4.DrawImage((Image)(object)val3, rectangle2, 0, 0, 440, 440, (GraphicsUnit)2, array[0]);
		rectangle2 = new Rectangle(dGauge[2] - 104, dGauge[3] - 80, ((Image)Logos_bmp).Width, 48);
		val4.DrawImage((Image)(object)Logos_bmp, rectangle2, 0, (ISOMain._Bene | ISOMain._Walbro) ? 144 : (ISOMain._Apri ? 96 : (ISOMain._KTM ? 48 : 0)), rectangle2.Width, rectangle2.Height, (GraphicsUnit)2, array[0]);
		ISORead.sGear = false;
		if (flag2)
		{
			mode = 1;
		}
		int num = (((ISOMain._KTM | ISOMain._Four) & (mode == 0)) ? 2 : ((ISOMain._Twin & (mode == 0)) ? 1 : mode));
		rectangle2 = new Rectangle(dGauge[10] - 1, dGauge[11] - 7, dGauge[14], dGauge[15]);
		val4.DrawImage((Image)(object)PaintPicto(0), rectangle2, 0, 0, dGauge[14], dGauge[15], (GraphicsUnit)2, array[1]);
		rectangle2 = new Rectangle(dGauge[10] - 1, dGauge[21] - 7, dGauge[14], dGauge[15]);
		val4.DrawImage((Image)(object)PaintPicto(dGauge[14] * (flag2 ? 3 : 0)), rectangle2, 0, 0, dGauge[14], dGauge[15], (GraphicsUnit)2, array[2]);
		rectangle2 = new Rectangle(dGauge[10] - 1, dGauge[31] - 7, dGauge[14], dGauge[15]);
		val4.DrawImage((Image)(object)PaintPicto(dGauge[14] * (num % 4 + (flag ? 3 : 0))), rectangle2, 0, 0, dGauge[14], dGauge[15], (GraphicsUnit)2, array[3]);
		for (int i = 1; i < 4; i++)
		{
			int num2 = (((ISOMain.EXBVReset & (i == 3)) | (flag2 & (i == 2))) ? 2 : (((flag & (i == 3)) | (mode * i == 6) | ((ISOMain._KTM | ISOMain._Four) & (mode == 0) & (i == 3))) ? 1 : 0));
			rectangle2 = new Rectangle(dGauge[10] + 77, dGauge[i * 10 + 1] + 33, dGauge[40], dGauge[41]);
			Rectangle rectangle3 = new Rectangle(LCD_data[i * 6 + 1] - 51, LCD_data[i * 6 + 2] - 10, 78, 36);
			num = mode + ((((i == 3) & ((ISOMain._Twin & (mode == 0)) | flag)) | ((i != 3) & ISOMain._Four & (mode != 1)) | ((mode == 0) & (i != 3) & ISOMain._LC4)) ? 1 : 0);
			val4.DrawImage((Image)(object)Picto_bmp, rectangle2, dGauge[40] * (i + num2 - 1), ((Image)Picto_bmp).Height - dGauge[41] * (num % 2 + 1), dGauge[40], dGauge[41], (GraphicsUnit)2, array[i]);
			val4.DrawImage((Image)(object)LCDB_bmp, rectangle3, 0, 0, 78, 36, (GraphicsUnit)2, array[i]);
		}
		num = (((mode & 1) != 0) ? 2 : 0);
		for (int i = 1; i < 4; i++)
		{
			int num2 = (((i == 1) & (mode == 0) & ISOMain._Four) ? 2 : 0);
			dGauge[i * 10 + 8] = dGauge[45 + num * (i - 2)];
			dGauge[i * 10 + 9] = dGauge[46 + (num + num2) * (i - 2)];
		}
		rectangle = new Rectangle(Indicator[8], Indicator[9], 38, 38);
		val4.DrawImage((Image)(object)Indic_bmp, rectangle, 266, 38, 38, 38, (GraphicsUnit)2, array[0]);
		rectangle = new Rectangle(Indicator[12], Indicator[13], 266, 92);
		val4.DrawImage((Image)(object)Indic_bmp, rectangle, 0, 112, 266, 92, (GraphicsUnit)2, array[0]);
		rectangle = new Rectangle(Indicator[14], Indicator[15], 144, 16);
		val4.DrawImage((Image)(object)Indic_bmp, rectangle, 112, 76, 144, 16, (GraphicsUnit)2, array[0]);
		rectangle = new Rectangle(Indicator[0] - 40, Indicator[1], 70, 38);
		val4.DrawImage((Image)(object)Indic_bmp, rectangle, 152, 38, 70, 38, (GraphicsUnit)2, array[0]);
		if (flag2)
		{
			dGauge[28] = dGauge[49];
			dGauge[29] = dGauge[50];
		}
		if (!ISOMain.sagemECU)
		{
			if (flag)
			{
				dGauge[38] = dGauge[51];
				dGauge[39] = dGauge[52];
			}
			num = ((ISOMain._KTM | ISOMain._Walbro) ? 2 : 0);
			rectangle = new Rectangle(Indicator[4 - num], Indicator[5 - num], 76, 38);
			val4.DrawImage((Image)(object)Indic_bmp, rectangle, ISOMain._Walbro ? 191 : 0, 38, 76, 38, (GraphicsUnit)2, ISOMain._Walbro ? array[4] : array[0]);
		}
		if (!ISOMain._KTM & !ISOMain._Walbro)
		{
			rectangle = new Rectangle(Indicator[2], Indicator[3], 76, 38);
			val4.DrawImage((Image)(object)Indic_bmp, rectangle, 76, 38, 76, 38, (GraphicsUnit)2, array[0]);
		}
		dGauge[9] = ((ISOMain.RevCount == 0) ? 10150 : ((ISOMain.RevCount == 2) ? 12200 : 14250));
		for (int i = 0; i < 4; i++)
		{
			ISOMain.me.pbDash_Update(i, 0);
		}
		val4.Dispose();
		return val;
	}

	public static void PaintLabel(object sender, PaintEventArgs e, int bcolor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		Label val = (Label)sender;
		SizeF sizeF = default(SizeF);
		string text = ((Control)val).Text;
		int num = (((int)val.TextAlign == 32) ? 1 : 0);
		sizeF = e.Graphics.MeasureString(text, lbFont);
		int num2 = (((Control)val).Width - (int)sizeF.Width) * num / 2;
		Rectangle rectangle = new Rectangle(0, 0, ((Control)val).Width, ((Control)val).Height);
		e.Graphics.DrawImage((Image)(object)Label_bmp, rectangle, bcolor * 10, 0, 9, 15, (GraphicsUnit)2);
		e.Graphics.DrawString(text, lbFont, (Brush)(object)whiteBrush, (float)(num2 + 1), 1f);
	}

	public static void EDPanelPaint(PaintEventArgs e)
	{
		SizeF sizeF = default(SizeF);
		string text = ISOMain.me.editUpDown.Value + " %";
		sizeF = e.Graphics.MeasureString(text, edFont);
		e.Graphics.DrawString(text, edFont, (Brush)(object)dimBrush, (float)(((Control)ISOMain.me.EDpanel).Width - (int)sizeF.Width - 4), 1f);
	}

	public static void PaintLogo(Rectangle part, PaintEventArgs e)
	{
		if (ISOMain.swMode == 0)
		{
			int num = ((ISOMain.TypTable >= 0) ? ((((ISOMain.TypTable & 0xFFFE) == 14) | ((ISOMain.TypTable & 0xFFE0) == 2048)) ? 3 : (((ISOMain.TypTable & 0xFFF8) == 8) ? 2 : ((ISOMain.TypTable >= 80) ? 1 : 0))) : ((ISOMain._Bene | ISOMain._Walbro) ? 3 : (ISOMain._Apri ? 2 : (ISOMain._KTM ? 1 : 0))));
			e.Graphics.DrawImage((Image)(object)Logos_bmp, part, 0, num * 24 + 192, part.Width, part.Height, (GraphicsUnit)2);
		}
	}

	public static void PaintBtn(object sender, PaintEventArgs e, int mode)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Button val = (Button)sender;
		int num = (int)((Control)val).Tag;
		string text = ISOMain.LangUI[ISOMain.mLang, num + ((num == 4) ? 75 : 80)];
		SizeF sizeF = default(SizeF);
		int num2 = num switch
		{
			1 => 22, 
			2 => 10, 
			_ => 0, 
		};
		int num3 = ((ISOMain.swMode == num) ? 40 : ((num == 4) ? 20 : 0));
		int num4 = ((((mode == num * 8 + 1) & (num3 != 40)) | ((num3 == 40) & ISOMain._KTM)) ? 120 : 0);
		Rectangle rectangle = new Rectangle(num2 + num4, num3, ((num & 3) == 0) ? 108 : 98, 20);
		sizeF = e.Graphics.MeasureString(text, tbFont);
		e.Graphics.DrawImage((Image)(object)BtnMode_bmp, 0, 0, rectangle, (GraphicsUnit)2);
		e.Graphics.DrawString(text, tbFont, (Brush)(object)whiteBrush, ((float)((Control)val).Width - sizeF.Width) / 2f, ((float)((Control)val).Height - sizeF.Height - 1f) / 2f);
		if ((num & 3) > 0)
		{
			rectangle = new Rectangle(0, 2, 1, 15);
			e.Graphics.DrawImage((Image)(object)Label_bmp, rectangle, 0, 0, 1, 15, (GraphicsUnit)2);
		}
	}

	public static void PaintfileStatus(object sender, PaintEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		SizeF sizeF = default(SizeF);
		ToolStripStatusLabel val = (ToolStripStatusLabel)sender;
		if (ISOMain.mProgress > 0.0)
		{
			int num = ((ISOMain.nop > ISOMain.warn) ? 30 : 10);
			int num2 = (int)((double)ISOMain.sProgress * ISOMain.mProgress * (double)((ToolStripItem)val).Width / (double)ISOMain.refBar);
			string text = num2 * 100 / ((ToolStripItem)val).Width + " %";
			sizeF = e.Graphics.MeasureString(text, pFont);
			Rectangle rectangle = new Rectangle(6, 2, num2, ((ToolStripItem)val).Height - 4);
			e.Graphics.FillRectangle((Brush)(object)darkBrush, 6, 2, ((ToolStripItem)val).Width, ((ToolStripItem)val).Height - 4);
			e.Graphics.DrawImage((Image)(object)Label_bmp, rectangle, num, 0, 4, 15, (GraphicsUnit)2);
			if (ISOMain.iStart < 0)
			{
				e.Graphics.DrawString(text, pFont, (Brush)(object)whiteBrush, ((float)((ToolStripItem)val).Width - sizeF.Width + 24f) / 2f, 1f);
			}
		}
	}

	public static void PaintListCodes(string code, DrawItemEventArgs e)
	{
		e.Graphics.Clear(Color.FromKnownColor(KnownColor.Window));
		e.Graphics.DrawString(code, pFont, (Brush)(object)blackBrush, 15f, 3f);
	}

	public static void PaintMeter(PaintEventArgs e)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		int top = e.ClipRectangle.Top;
		int i;
		for (i = 0; i < 4 && dashRegion[i].Top != top; i++)
		{
		}
		int num = ((i > 3) ? 1 : i);
		int num2 = i;
		if (i % 4 == 0)
		{
			Bitmap val = new Bitmap(375, 267);
			Graphics val2 = Graphics.FromImage((Image)(object)val);
			int x = RotateCoord(Angle_Meter[0], 375, 1);
			int y = RotateCoord(Angle_Meter[0], 375, -1);
			val2.RotateTransform((float)Angle_Meter[0]);
			Point point = new Point(x, y);
			val2.DrawImageUnscaled((Image)(object)NeedleL_bmp, point);
			e.Graphics.DrawImage((Image)(object)val, nPart, 0, 0, 375, 375, (GraphicsUnit)2);
			e.Graphics.DrawImage((Image)(object)Axis_bmp, aPart, 0, 0, Spin, Spin, (GraphicsUnit)2);
			Paint_LCD(ISORead.dataSensor[0], 0, e);
			Paint_LCD(ISORead.dataSensor[7], 4, e);
			if (ISORead.sGear)
			{
				Paint_LCD(ISORead.dataSensor[8], 5, e);
			}
			if ((ISOMain.mView & 0x40) == 64)
			{
				if (ISOMain._Walbro & (ISORead.dataNum[2] == 0))
				{
					DrawIndicator(2, 1, e);
				}
				if (ISOMain.swMode == 2)
				{
					for (int j = 0; j < 6; j++)
					{
						if ((ISORead.dataNum[j] > 0) & !(ISOMain._Walbro & (j == 2)))
						{
							int off = j - (((j == 2) & ISOMain._KTM) ? 1 : 0);
							DrawIndicator(j, off, e);
						}
					}
				}
			}
			val2.Dispose();
		}
		else
		{
			num2++;
		}
		for (int k = num; k < num2; k++)
		{
			Bitmap val = new Bitmap(203, 129);
			Graphics val2 = Graphics.FromImage((Image)(object)val);
			int x = RotateCoord(Angle_Meter[k], 203, 1);
			int y = RotateCoord(Angle_Meter[k], 203, -1);
			val2.RotateTransform((float)Angle_Meter[k]);
			Point point = new Point(x, y);
			val2.DrawImageUnscaled((Image)(object)NeedleS_bmp, point);
			Rectangle rectangle = new Rectangle(dGauge[k * 10 + 2] - 101, dGauge[k * 10 + 3] - 101, 203, 203);
			Rectangle rectangle2 = new Rectangle(dGauge[k * 10 + 2] - Spin / 2, dGauge[k * 10 + 3] - Spin / 2, Spin, Spin);
			Rectangle rectangle3 = new Rectangle(LCD_data[k * 6 + 1] - 51, LCD_data[k * 6 + 2] - 10, 78, 36);
			e.Graphics.DrawImage((Image)(object)val, rectangle, 0, 0, 203, 203, (GraphicsUnit)2);
			e.Graphics.DrawImage((Image)(object)Axis_bmp, rectangle2, Spin, 0, Spin, Spin, (GraphicsUnit)2);
			e.Graphics.DrawImage((Image)(object)LCDB_bmp, rectangle3, 0, 0, 78, 36, (GraphicsUnit)2, imgAttr);
			Paint_LCD(((ISOMain.mView & 0x40) == 64) ? ISORead.dataSensor[k] : "0", k, e);
			val2.Dispose();
		}
	}

	private static int RotateCoord(int angle, int size, int axe)
	{
		double num = Math.PI * (double)angle / 180.0;
		return (int)Math.Round((double)axe * Math.Sqrt(2.0) * (double)size * Math.Sin(num / 2.0) * Math.Cos(Math.PI / 4.0 + (double)axe * num / 2.0));
	}

	private static void DrawIndicator(int ind, int off, PaintEventArgs e)
	{
		Rectangle rectangle = new Rectangle(Indicator[off * 2], Indicator[off * 2 + 1], 38, 38);
		e.Graphics.DrawImage((Image)(object)Indic_bmp, rectangle, ind * 38, 0, 38, 38, (GraphicsUnit)2);
	}

	private static void Paint_LCD(string Num, int loc, PaintEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		int num = 0;
		int num2 = 0;
		int num3 = loc * 6;
		Bitmap val = new Bitmap((Image)(object)LCD28_bmp);
		switch (loc)
		{
		case 1:
		case 2:
		case 3:
			val = new Bitmap((Image)(object)LCD20_bmp);
			break;
		case 4:
			val = new Bitmap((Image)(object)LCD70_bmp);
			break;
		}
		if (Num == null)
		{
			Num = "0";
		}
		int length = Num.Length;
		int num4 = LCD_data[num3 + 4];
		for (int i = 0; i < length; i++)
		{
			char value = Num[length - i - 1];
			num = "0123456789,.-".IndexOf(value);
			if (num > 10)
			{
				num--;
			}
			if (num == 10)
			{
				num2 = num2 - num4 + num4 / 4;
			}
			Rectangle rectangle = new Rectangle(LCD_data[num3 + 1] - num2, LCD_data[num3 + 2], num4, LCD_data[num3 + 3]);
			e.Graphics.DrawImage((Image)(object)val, rectangle, num * num4, 0, num4, LCD_data[num3 + 3], (GraphicsUnit)2);
			num2 += num4;
		}
	}

	public static void labelGrid_ValueH(PaintEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if (ISOMain.showGraph)
		{
			return;
		}
		int i = 0;
		int num = ((!ISOMain.dcLabel) ? 1 : 10);
		SolidBrush val = new SolidBrush(Color.Black);
		string text = ISORead.dataValue[0];
		short.TryParse(text, out var result);
		for (; (i < ISOMain.gCol - 1) & (result * num > ISOMain.LH_Array[i]); i++)
		{
		}
		if (i > 0)
		{
			int num2 = (ISOMain.LH_Array[i] - ISOMain.LH_Array[i - 1]) / 2;
			if (result * num <= ISOMain.LH_Array[i - 1] + num2)
			{
				i--;
			}
		}
		int num3 = ISOMain.lbW * i;
		Rectangle rectangle = new Rectangle(num3 + ISOMain.lbW + ISOMain.gOff + 1, 1, ISOMain.lbW - 2, ISOMain.lbS - 2);
		SizeF sizeF = e.Graphics.MeasureString(text, rFont);
		e.Graphics.FillRectangle((Brush)(object)grayBrush, rectangle);
		e.Graphics.DrawString(text, rFont, (Brush)(object)val, (float)(num3 + ISOMain.lbW + ISOMain.gOff) + ((float)ISOMain.lbW - sizeF.Width - 1f) / 2f, ((float)ISOMain.lbS - sizeF.Height) / 2f);
	}

	public static void labelGrid_ValueV(PaintEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		if (ISOMain.showGraph)
		{
			return;
		}
		int i = 0;
		SolidBrush val = new SolidBrush(Color.Black);
		string text = ISORead.dataValue[1];
		short.TryParse(text, out var result);
		for (; (i < ISOMain.gRow - 1) & (result > ISOMain.LV_Array[i]); i++)
		{
		}
		if (i > 0)
		{
			int num = (ISOMain.LV_Array[i] - ISOMain.LV_Array[i - 1]) / 2;
			if (result <= ISOMain.LV_Array[i - 1] + num)
			{
				i--;
			}
		}
		int num2 = ((Control)ISOMain.me.panelTable).Height - ISOMain.lbH * (i + 1);
		Rectangle rectangle = new Rectangle(1, num2 + 1, ISOMain.lbW + ISOMain.gOff - 2, ISOMain.lbH - 2);
		SizeF sizeF = e.Graphics.MeasureString(text, rFont);
		e.Graphics.FillRectangle((Brush)(object)grayBrush, rectangle);
		e.Graphics.DrawString(text, rFont, (Brush)(object)val, ((float)(ISOMain.lbW + ISOMain.gOff) - sizeF.Width - 1f) / 2f, (float)num2 + ((float)ISOMain.lbH - sizeF.Height) / 2f);
	}

	public static void labelGrid_Paint(int x, int y, int size, int off, string str, SolidBrush pen, SolidBrush ground, PaintEventArgs e)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		int num = ((x == 0) ? off : 0);
		int num2 = ((y == 0) ? ISOMain.lbS : ISOMain.lbH);
		int num3 = ((size % 256 == 0) ? ISOMain.lbW : (size % 256));
		int num4 = ((size / 256 == 0) ? num2 : (size / 256));
		SizeF sizeF = default(SizeF);
		Point[] array = new Point[3];
		Point[] array2 = new Point[3];
		ref Point reference = ref array[0];
		reference = new Point(x + off - num, y + num4 - 1);
		ref Point reference2 = ref array[1];
		reference2 = new Point(x + off - num, y);
		ref Point reference3 = ref array[2];
		reference3 = new Point(x + off + num3 - 1, y);
		ref Point reference4 = ref array2[0];
		reference4 = new Point(x + off + num3 - 1, y);
		ref Point reference5 = ref array2[1];
		reference5 = new Point(x + off + num3 - 1, y + num4 - 1);
		ref Point reference6 = ref array2[2];
		reference6 = new Point(x + off - num, y + num4 - 1);
		e.Graphics.FillRectangle((Brush)(object)ground, x + off - num, y, num3 + num, num4);
		Pen val = new Pen((Brush)(object)shadowBrush);
		e.Graphics.DrawLines(val, array);
		val = new Pen((Brush)(object)whiteBrush);
		e.Graphics.DrawLines(val, array2);
		sizeF = e.Graphics.MeasureString(str, rFont);
		if (pen.Color == Color.Black)
		{
			y++;
		}
		e.Graphics.DrawString(str, rFont, (Brush)(object)pen, (float)(x + off) + ((float)num3 - sizeF.Width - (float)num - 1f) / 2f, (float)y + ((float)num4 - sizeF.Height) / 2f - 1f);
	}

	public static void panelGridPaint(PaintEventArgs e)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1179: Unknown result type (might be due to invalid IL or missing references)
		//IL_1183: Expected O, but got Unknown
		//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ae: Expected O, but got Unknown
		bool flag = false;
		bool flag2 = false;
		bool flag3 = true;
		int num = 0;
		int width = ((Control)ISOMain.me.panelTable).Width;
		int height = ((Control)ISOMain.me.panelTable).Height;
		int num2 = width / ISOMain.gRow;
		int num3 = ((ISOMain.lbH < 20) ? ISOMain.lbH : 20);
		int num4 = (ISOMain.pcEdit ? 17 : 0);
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double[] array = null;
		Pen val = new Pen(Color.FromKnownColor(KnownColor.ActiveBorder));
		Pen val2 = new Pen(Color.FromKnownColor(KnownColor.ActiveBorder));
		val2.DashStyle = (DashStyle)2;
		gPen.DashStyle = (DashStyle)2;
		cPen.Width = 2f;
		gPen.Width = 2f;
		rPen.Width = 2f;
		SizeF sizeF = default(SizeF);
		int num8 = ((ISOMain.xColor != null) ? (ISOMain.xColor.Length - 1) : 0);
		if (ISOMain.gridArray != null)
		{
			num = ISOMain.gridArray.Length / 2;
		}
		int num9 = ISOMain.gOff;
		int num10 = ((ISOMain.firstSelect / 100 < ISOMain.lastSelect / 100) ? (ISOMain.firstSelect / 100) : (ISOMain.lastSelect / 100));
		int num11 = ((ISOMain.firstSelect / 100 < ISOMain.lastSelect / 100) ? (ISOMain.lastSelect / 100) : (ISOMain.firstSelect / 100));
		int num12 = ((ISOMain.firstSelect % 100 < ISOMain.lastSelect % 100) ? (ISOMain.firstSelect % 100) : (ISOMain.lastSelect % 100));
		int num13 = ((ISOMain.firstSelect % 100 < ISOMain.lastSelect % 100) ? (ISOMain.lastSelect % 100) : (ISOMain.firstSelect % 100));
		ISOMain.eFirst = num10 * 100 + num12;
		ISOMain.eLast = num11 * 100 + num13;
		Point point = new Point((ISOMain.eLast / 100 + 1) * ISOMain.lbW + ((Control)ISOMain.me.gbTable).Left + ISOMain.gOff - 3, (ISOMain.eLast % 100 + 1) * ISOMain.lbH + ISOMain.lbS + ((Control)ISOMain.me.gbTable).Top - 15 + num4 + 3);
		int num14 = (ISOMain.showMod ? ISOMain.gRow : 0);
		for (int i = 0; i < ISOMain.gCol; i++)
		{
			if (!ISOMain.graphSelect & !ISOMain.keyF7 & ISOMain.showGraph)
			{
				gBrush = darkBrush;
			}
			else if (ISOMain.keyF7 | !ISOMain.showGraph | ((ISOMain.eFirst > 99) & ((i + 1 >= ISOMain.eFirst / 100) & (i < ISOMain.eLast / 100))))
			{
				gBrush = new SolidBrush(ISOMain.LH_Color[i]);
			}
			else
			{
				gBrush = darkBrush;
			}
			num5 = (double)ISOMain.LH_Array[i] / (double)((!ISOMain.dcLabel) ? 1 : 10);
			labelGrid_Paint(ISOMain.lbW * (i + 1), 0, 0, ISOMain.gOff, num5.ToString(), blackBrush, gBrush, e);
		}
		if (ISOMain.gRow > 1)
		{
			for (int i = ISOMain.gRow; i > 0; i--)
			{
				if ((!ISOMain.graphSelect & !ISOMain.editCurve) | ((ISOMain.eFirst < 100) & (i > ISOMain.eFirst % 100) & (i - 1 <= ISOMain.eLast % 100) & ISOMain.graphSelect & !ISOMain.editCurve) | (i == ISOMain.eCurv + 1))
				{
					gBrush = new SolidBrush(ISOMain.LV_Color[ISOMain.gRow - i]);
				}
				else
				{
					gBrush = darkBrush;
					int num15 = (ISOMain.editCurve ? ISOMain.eCurv : ISOMain.eFirst);
					flag = num15 > 99;
				}
				if (!flag & !ISOMain.showView)
				{
					labelGrid_Paint(0, ISOMain.lbH * (i - 1) + ISOMain.lbS, 0, ISOMain.gOff, ISOMain.LV_Array[ISOMain.gRow + num14 - i].ToString(), blackBrush, gBrush, e);
				}
			}
		}
		else if (!ISOMain.showGraph)
		{
			e.Graphics.DrawLine(val, 0, ISOMain.lbH + ISOMain.lbS - 1, width, ISOMain.lbH + ISOMain.lbS - 1);
			labelGrid_Paint(0, ISOMain.lbH, 0, ISOMain.gOff, ISOMain.lvLabel, whiteBrush, darkBrush, e);
		}
		else
		{
			e.Graphics.DrawLine(val2, ISOMain.lbW + ISOMain.gOff - 1, 0, ISOMain.lbW + ISOMain.gOff - 1, width);
		}
		labelGrid_Paint(0, 0, 0, ISOMain.gOff, (!flag & !ISOMain.showView) ? ISOMain.lhLabel : "", whiteBrush, darkBrush, e);
		if (e.ClipRectangle.Width == ISOMain.lbW + ISOMain.gOff)
		{
			labelGrid_ValueV(e);
			return;
		}
		if (e.ClipRectangle.Height == ISOMain.lbS)
		{
			labelGrid_ValueH(e);
			return;
		}
		if (ISOMain.noMap)
		{
			string text = ISOMain.LangUI[ISOMain.mLang, ISORead.mLoad ? 241 : 319];
			sizeF = e.Graphics.MeasureString(text, pFont);
			int num16 = (ISOMain.gCol * ISOMain.lbW - (int)sizeF.Width) / 2;
			int num17 = (ISOMain.gRow * ISOMain.lbH - (int)sizeF.Height) / 2;
			e.Graphics.DrawString(text, pFont, (Brush)(object)whiteBrush, (float)(ISOMain.lbW + num16), (float)num17);
			return;
		}
		flag2 = ((ISOMain.ptrMap[ISOMain.iTable[ISOMain.iTag]] & 0x70) != 32) | ISOMain.compareF;
		int num18 = (((ISOMain.showMod | ISOMain.graphSelect | ISOMain.editCurve) & flag2) ? num : 0);
		if (!ISOMain.showGraph)
		{
			if (!ISOMain.editSelect)
			{
				ISOMain.oneSelect = false;
				ISOMain.lbSelect = false;
				((Control)ISOMain.me.EDpanel).Hide();
				((Control)ISOMain.me.editUpDown).Visible = false;
			}
			for (int num16 = ISOMain.gRow - 1; num16 >= 0; num16--)
			{
				for (int i = 1; i < ISOMain.gCol + 1; i++)
				{
					if (ISOMain.gridArray == null)
					{
						continue;
					}
					gBrush = new SolidBrush(ISOMain.LH_Color[i - 1]);
					num5 = (double)ISOMain.LH_Array[i - 1] / (double)((!ISOMain.dcLabel) ? 1 : 10);
					labelGrid_Paint(ISOMain.lbW * i, 0, 0, ISOMain.gOff, num5.ToString(), blackBrush, gBrush, e);
					num7 = ISOMain.gridArray[num18++];
					num5 = (num7 - ISOMain.dColor) / Math.Abs(ISOMain.eColor);
					if (num5 < 0.0)
					{
						num5 = 0.0;
					}
					if (num5 > (double)num8)
					{
						num5 = num8;
					}
					if (ISOMain.eColor < 0.0)
					{
						num5 = (double)num8 - num5;
					}
					if (ISOMain.editSelect & (i >= num10) & (i <= num11) & (num16 >= num12) & (num16 <= num13))
					{
						gBrush = new SolidBrush(editColor);
						if (((Control)ISOMain.me.editUpDown).Visible)
						{
							if (((Control)ISOMain.me.editUpDown).Location != point)
							{
								((Control)ISOMain.me.editUpDown).Location = point;
							}
							if (ISOMain.pcEdit)
							{
								num7 = num7 * (double)(ISOMain.me.editUpDown.Value + 100m) / 100.0;
								Point location = new Point(((Control)ISOMain.me.editUpDown).Left - 41, ((Control)ISOMain.me.editUpDown).Top + 2);
								((Control)ISOMain.me.EDpanel).Location = location;
								ISOMain.pcShow = !((Control)ISOMain.me.EDpanel).Visible;
							}
							else
							{
								num7 += (double)ISOMain.me.editUpDown.Value;
								((Control)ISOMain.me.EDpanel).Hide();
							}
						}
					}
					else
					{
						Color color = ISOMain.xColor[(int)num5];
						gBrush = (SolidBrush)((!flag3) ? ((object)grayBrush) : ((object)new SolidBrush(Color.FromArgb((ISOMain.showMod & flag2) ? 144 : 255, color.R, color.G, color.B))));
					}
					e.Graphics.FillRectangle((Brush)(object)gBrush, i * ISOMain.lbW + num9, num16 * ISOMain.lbH + ISOMain.lbS, ISOMain.lbW - 1, ISOMain.lbH - 1);
					string text = num7.ToString(ISOMain.gFormat);
					sizeF = e.Graphics.MeasureString(text, rFont);
					int num19 = ((num18 <= num) ? num : 0);
					bool flag4 = text != ISOMain.gridArray[num18 + num19 - 1].ToString(ISOMain.gFormat);
					if (flag2 & flag4 & !ISOMain.compareF & (gBrush.Color != editColor))
					{
						e.Graphics.DrawString(text, rFont, (Brush)(object)whiteBrush, (float)(i * ISOMain.lbW + num9) + ((float)ISOMain.lbW - sizeF.Width - 1f) / 2f, (float)(num16 * ISOMain.lbH + ISOMain.lbS) + ((float)ISOMain.lbH - sizeF.Height) / 2f);
					}
					else
					{
						e.Graphics.DrawString(text, rFont, (Brush)(object)blackBrush, (float)(i * ISOMain.lbW + num9) + ((float)ISOMain.lbW - sizeF.Width - 1f) / 2f, (float)(num16 * ISOMain.lbH + ISOMain.lbS) + ((float)ISOMain.lbH - sizeF.Height) / 2f);
					}
					if (flag2 & flag4 & ISOMain.compareF & (gBrush.Color != editColor))
					{
						e.Graphics.FillRectangle((Brush)(object)whiteBrush, i * ISOMain.lbW + num9, num16 * ISOMain.lbH + ISOMain.lbS, ISOMain.lbH / 6, ISOMain.lbH / 6);
					}
				}
			}
			if (ISOMain.mCells != -1)
			{
				int i = ISOMain.mCells / 100;
				int num16 = ISOMain.mCells % 100;
				if (i > 0)
				{
					e.Graphics.DrawRectangle(rPen, i * ISOMain.lbW + num9, 0, ISOMain.lbW - 2, height - 1);
				}
				else
				{
					e.Graphics.DrawRectangle(rPen, 0, num16 * ISOMain.lbH + ISOMain.lbS, width - 2, ISOMain.lbH - 1);
				}
			}
		}
		else
		{
			if (ISOMain.gScale == 0.0)
			{
				return;
			}
			int num20 = (((ISOMain.iTable[ISOMain.iTag] > 27) & (ISOMain.iTable[ISOMain.iTag] < 32)) ? 36 : (((ISOMain.ptrMap[ISOMain.iTable[ISOMain.iTag]] & 0x70) != 32) ? 40 : 68));
			double num21 = ISOMain.gScale;
			double num22 = (double)(int)(ISOMain.dColor / num21) * num21;
			string text2 = "";
			string[] array2 = null;
			double num23 = Math.Abs(ISOMain.eColor * (double)num20);
			double num24 = height - ISOMain.lbS;
			Point[] array3 = new Point[ISOMain.gCol];
			Point[] array4 = null;
			for (; num22 - ISOMain.dColor < Math.Abs(ISOMain.eColor) * (double)num20; num22 += num21)
			{
				if (num22 >= (double)(int)ISOMain.dColor)
				{
					text2 = (((ISOMain.ptrMap[ISOMain.iTable[ISOMain.iTag]] & 0x70) != 32) ? "" : "+#;-#;0");
					string text = num22.ToString(text2);
					sizeF = e.Graphics.MeasureString(text, rFont);
					int num17 = (int)((double)(height - ISOMain.lbS) - (num22 - ISOMain.dColor) / num23 * num24 - (double)(sizeF.Height / 2f));
					if (num17 > ISOMain.lbS + 1)
					{
						e.Graphics.DrawString(text, rFont, (Brush)(object)blueBrush, (float)width - sizeF.Width - 4f, (float)num17);
					}
				}
			}
			e.Graphics.SmoothingMode = (SmoothingMode)4;
			if (ISOMain.gridArray == null)
			{
				return;
			}
			int num25 = width - ISOMain.gRow * num2;
			array = new double[Math.Max(ISOMain.gRow, ISOMain.gCol)];
			int num26 = 0;
			Point point2 = new Point(0, 0);
			Point point3 = new Point(0, 0);
			string text3 = "";
			if (ISOMain.editCurve)
			{
				array4 = new Point[flag ? ISOMain.gRow : ISOMain.gCol];
				array2 = new string[flag ? ISOMain.gRow : ISOMain.gCol];
			}
			if (num18 > 0)
			{
				for (int num16 = ISOMain.gRow; num16 > 0; num16--)
				{
					if (flag | ISOMain.showView)
					{
						for (int i = 1; i < ISOMain.gCol + 1; i++)
						{
							if ((!ISOMain.graphSelect & ISOMain.showView & ISOMain.showMod) | ((i >= ISOMain.eFirst / 100) & (i <= ISOMain.eLast / 100) & !ISOMain.editCurve) | (i == ISOMain.eCurv / 100))
							{
								num7 = ISOMain.gridArray[(ISOMain.gRow - num16) * ISOMain.gCol + i + num18 - 1];
								if (ISOMain.editCurve)
								{
									array[num26++] = num7;
								}
								gPen.Color = ISOMain.LH_Color[i - 1];
								point3 = new Point((ISOMain.gRow - num16) * num2 + num2 / 2 + num25, (int)((double)(height - ISOMain.lbS) - (num7 - ISOMain.dColor) / num23 * num24));
								if (array3[i - 1].X == 0)
								{
									array3[i - 1] = point3;
								}
								e.Graphics.DrawLine(gPen, array3[i - 1], point3);
								array3[i - 1] = point3;
							}
						}
					}
					else
					{
						bool flag5 = (!ISOMain.graphSelect & ISOMain.showMod) | ((num16 > ISOMain.eFirst % 100) & (num16 - 1 <= ISOMain.eLast % 100) & !ISOMain.editCurve) | (num16 == ISOMain.eCurv + 1);
						gPen.Color = ISOMain.LV_Color[ISOMain.gRow - num16];
						if (flag5)
						{
							num7 = ISOMain.gridArray[num18] - ISOMain.dColor;
							point2 = new Point(ISOMain.lbW + ISOMain.lbW / 3 + ISOMain.gOff, (int)((double)(height - ISOMain.lbS) - num7 / num23 * num24));
							if (ISOMain.editCurve)
							{
								array[num26++] = num7 + ISOMain.dColor;
							}
						}
						num18++;
						for (int i = 2; i < ISOMain.gCol + 1; i++)
						{
							if (flag5)
							{
								num7 = ISOMain.gridArray[num18] - ISOMain.dColor;
								point3 = new Point(i * ISOMain.lbW + ISOMain.lbW / 3 + ISOMain.gOff, (int)((double)(height - ISOMain.lbS) - num7 / num23 * num24));
								e.Graphics.DrawLine(gPen, point2, point3);
								if (ISOMain.editCurve)
								{
									array[num26++] = num7 + ISOMain.dColor;
								}
							}
							point2 = point3;
							num18++;
						}
					}
				}
			}
			num18 = 0;
			array3 = new Point[ISOMain.gCol];
			for (int num16 = ISOMain.gRow; num16 > 0; num16--)
			{
				if (flag | ISOMain.showView)
				{
					for (int i = 1; i < ISOMain.gCol + 1; i++)
					{
						bool flag5 = (!ISOMain.graphSelect & !ISOMain.showMod & !ISOMain.editCurve) | ((i >= ISOMain.eFirst / 100) & (i <= ISOMain.eLast / 100) & ISOMain.graphSelect & !ISOMain.editCurve) | (i == ISOMain.eCurv / 100);
						cPen.Color = ISOMain.LH_Color[i - 1];
						if (ISOMain.editCurve & flag5)
						{
							if (ISOMain.gTable == null)
							{
								ISOMain.gTable = new double[3, ISOMain.gRow];
								ISOMain.edState = false;
								for (int num17 = 0; num17 < ISOMain.gRow; num17++)
								{
									ISOMain.gTable[0, num17] = ISOMain.gridArray[num17 * ISOMain.gCol + i - 1];
									ISOMain.gTable[1, num17] = ISOMain.gridArray[num17 * ISOMain.gCol + i - 1];
									ISOMain.gTable[2, num17] = (int)ISOMain.egRow[num17];
									if (ISOMain.egRow[num17] > 0)
									{
										ISOMain.edState = true;
									}
								}
							}
							num7 = ISOMain.gTable[0, num18];
							num5 = array[num18];
						}
						else
						{
							num7 = ISOMain.gridArray[(ISOMain.gRow - num16) * ISOMain.gCol + i - 1];
						}
						if (!ISOMain.graphSelect & !ISOMain.keyF7 & ISOMain.showGraph & !ISOMain.editCurve)
						{
							gBrush = darkBrush;
						}
						else if (((ISOMain.keyF7 | !ISOMain.showGraph | ((ISOMain.eFirst > 99) & (i >= ISOMain.eFirst / 100) & (i - 1 < ISOMain.eLast / 100))) & !ISOMain.editCurve) | ((i == ISOMain.eCurv / 100) & ISOMain.editCurve))
						{
							gBrush = new SolidBrush(ISOMain.LH_Color[i - 1]);
						}
						else
						{
							gBrush = darkBrush;
						}
						num6 = (double)ISOMain.LH_Array[i - 1] / (double)((!ISOMain.dcLabel) ? 1 : 10);
						labelGrid_Paint(ISOMain.lbW * i, 0, 0, ISOMain.gOff, num6.ToString(), blackBrush, gBrush, e);
						if (!flag5)
						{
							continue;
						}
						point3 = new Point((ISOMain.gRow - num16) * num2 + num2 / 2 + num25, (int)((double)(height - ISOMain.lbS) - (num7 - ISOMain.dColor) / num23 * num24));
						if (array3[i - 1].X == 0)
						{
							array3[i - 1] = point3;
						}
						e.Graphics.DrawLine(cPen, array3[i - 1], point3);
						if (ISOMain.editCurve)
						{
							string text;
							if (ISOMain.pcGraph)
							{
								text = ((num5 == 0.0) ? "" : (num7 / num5 - 1.0).ToString("#0 %"));
							}
							else
							{
								text3 = ((num7 - num5 == 0.0) ? "" : (" (" + ((num7 - num5 > 0.0) ? "+" : "") + (num7 - num5).ToString(ISOMain.gFormat) + ")"));
								text = num7.ToString(ISOMain.gFormat) + text3;
							}
							array4[num18].X = point3.X - ((num16 == 1) ? 20 : 16);
							array4[num18].Y = point3.Y - (((num16 & 1) == 1) ? 24 : (-10));
							array2[num18++] = text;
							e.Graphics.DrawEllipse(cPen, point3.X - 2, point3.Y - 2, 4, 4);
							if (ISOMain.gTable[2, ISOMain.gRow - num16] > 0.0)
							{
								e.Graphics.DrawEllipse(rPen, point3.X - 4, point3.Y - 4, 8, 8);
							}
						}
						array3[i - 1] = point3;
					}
					num7 = (double)ISOMain.LV_Array[num16 - 1] / 1000.0;
					if (ISOMain.gTable != null)
					{
						gBrush = ((ISOMain.gTable[2, num16 - 1] > 0.0) ? limeBrush : darkBrush);
					}
					else
					{
						gBrush = darkBrush;
					}
					if (num16 == 1)
					{
						labelGrid_Paint(0, height - num3, num3 * 256 + num2 + num25, 0, num7.ToString("#.0#") + "k", blackBrush, gBrush, e);
					}
					else
					{
						labelGrid_Paint((num16 - 1) * num2 + num25, height - num3, num3 * 256 + num2, 0, num7.ToString("#.0#"), blackBrush, gBrush, e);
					}
				}
				else
				{
					bool flag5 = (!ISOMain.graphSelect & !ISOMain.showMod & !ISOMain.editCurve) | ((num16 > ISOMain.eFirst % 100) & (num16 - 1 <= ISOMain.eLast % 100) & ISOMain.graphSelect & !ISOMain.editCurve) | (num16 == ISOMain.eCurv + 1);
					cPen.Color = ISOMain.LV_Color[ISOMain.gRow - num16];
					int i;
					if (ISOMain.editCurve & flag5)
					{
						if (ISOMain.gTable == null)
						{
							ISOMain.gTable = new double[3, ISOMain.gCol];
							ISOMain.edState = false;
							for (i = 0; i < ISOMain.gCol; i++)
							{
								ISOMain.gTable[0, i] = ISOMain.gridArray[num18 + i];
								ISOMain.gTable[1, i] = ISOMain.gridArray[num18 + i];
								ISOMain.gTable[2, i] = (int)ISOMain.egCol[i];
								if (ISOMain.egCol[i] > 0)
								{
									ISOMain.edState = true;
								}
							}
						}
						num7 = ISOMain.gTable[0, 0];
						num5 = array[0];
						num18++;
					}
					else
					{
						num7 = ISOMain.gridArray[num18++];
					}
					for (i = 0; i < ISOMain.gCol; i++)
					{
						if (!ISOMain.graphSelect & !ISOMain.keyF7 & ISOMain.showGraph & !ISOMain.editCurve)
						{
							gBrush = darkBrush;
						}
						else if (ISOMain.editCurve & (ISOMain.gTable != null) & (ISOMain.eCurv < 100))
						{
							gBrush = ((ISOMain.gTable[2, i] > 0.0) ? limeBrush : darkBrush);
						}
						else if (((ISOMain.keyF7 | !ISOMain.showGraph | ((ISOMain.eFirst > 99) & (i + 1 >= ISOMain.eFirst / 100) & (i < ISOMain.eLast / 100))) & !ISOMain.editCurve) | ((i == ISOMain.eCurv / 100 - 1) & ISOMain.editCurve))
						{
							gBrush = new SolidBrush(ISOMain.LH_Color[i]);
						}
						else
						{
							gBrush = darkBrush;
						}
						num6 = (double)ISOMain.LH_Array[i] / (double)((!ISOMain.dcLabel) ? 1 : 10);
						labelGrid_Paint(ISOMain.lbW * (i + 1), 0, 0, ISOMain.gOff, num6.ToString(), blackBrush, gBrush, e);
					}
					i = 1;
					point2 = new Point(ISOMain.lbW + ISOMain.lbW / 3 + ISOMain.gOff, (int)((double)(height - ISOMain.lbS) - (num7 - ISOMain.dColor) / num23 * num24));
					if (ISOMain.editCurve & flag5)
					{
						string text;
						if (ISOMain.pcGraph)
						{
							text = ((num5 == 0.0) ? "" : (num7 / num5 - 1.0).ToString("#0 %"));
						}
						else
						{
							text3 = ((num7 - num5 == 0.0) ? "" : (" (" + ((num7 - num5 > 0.0) ? "+" : "") + (num7 - num5).ToString(ISOMain.gFormat) + ")"));
							text = num7.ToString(ISOMain.gFormat) + text3;
						}
						array4[0].X = point2.X - 8;
						array4[0].Y = point2.Y - (((i & 1) == 1) ? 24 : (-16));
						array2[0] = text;
						e.Graphics.DrawEllipse(cPen, point2.X - 2, point2.Y - 2, 4, 4);
						if (ISOMain.gTable[2, 0] > 0.0)
						{
							e.Graphics.DrawEllipse(rPen, point2.X - 4, point2.Y - 4, 8, 8);
						}
					}
					for (i = 2; i < ISOMain.gCol + 1; i++)
					{
						if (ISOMain.editCurve & flag5)
						{
							num7 = ISOMain.gTable[0, i - 1];
							num5 = array[i - 1];
						}
						else
						{
							num7 = ISOMain.gridArray[num18];
						}
						num18++;
						point3 = new Point(i * ISOMain.lbW + ISOMain.lbW / 3 + ISOMain.gOff, (int)((double)(height - ISOMain.lbS) - (num7 - ISOMain.dColor) / num23 * num24));
						if (flag5)
						{
							e.Graphics.DrawLine(cPen, point2, point3);
							if (ISOMain.editCurve)
							{
								string text;
								if (ISOMain.pcGraph)
								{
									text = ((num5 == 0.0) ? "" : (num7 / num5 - 1.0).ToString("#0 %"));
								}
								else
								{
									text3 = ((num7 - num5 == 0.0) ? "" : (" (" + ((num7 - num5 > 0.0) ? "+" : "") + (num7 - num5).ToString(ISOMain.gFormat) + ")"));
									text = num7.ToString(ISOMain.gFormat) + text3;
								}
								array4[i - 1].X = point3.X - 16;
								array4[i - 1].Y = point3.Y - (((i & 1) == 1) ? 24 : (-10));
								array2[i - 1] = text;
								e.Graphics.DrawEllipse(cPen, point3.X - 2, point3.Y - 2, 4, 4);
								if (ISOMain.gTable[2, i - 1] > 0.0)
								{
									e.Graphics.DrawEllipse(rPen, point3.X - 4, point3.Y - 4, 8, 8);
								}
							}
						}
						point2 = point3;
					}
				}
			}
			if (ISOMain.editCurve)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					e.Graphics.DrawString(array2[i], rFont, (Brush)(object)grayBrush, (float)array4[i].X, (float)array4[i].Y);
				}
			}
		}
	}

	public static void TreeViewDrawNode(object sender, DrawTreeNodeEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		Graphics graphics = e.Graphics;
		TreeView val = (TreeView)sender;
		Image val2 = null;
		int num = (int)((Control)val).Tag;
		if (((int)((Control)val).Tag == 2) & (ISOMain.swMode == 2))
		{
			return;
		}
		Pen val3 = Pens.Black;
		Brush val4 = Brushes.White;
		Brush val5 = Brushes.Black;
		StringFormat val6 = new StringFormat();
		string[] array = new string[0];
		int num2 = (int)e.Node.Tag;
		int num3 = val.Indent;
		int num4 = 0;
		int num5 = (((e.Node.Level > 0) | (num == 2)) ? (num3 - 1) : 0);
		int num6 = e.Node.Level + ((num == 2) ? 1 : 0) + 1;
		int num7 = 17;
		int num8 = num7;
		int num9 = (((num == 2) & (Math.Abs(num2) != 8)) ? 2 : 0);
		if ((num == 0) & (e.Node.Level > 0))
		{
			num3 = 10;
		}
		Brush val7 = (((num == 2) & ISOMain._Walbro & (((ISOMain.wbTrim >> 8) & (e.Node.Index - 9)) > 0)) ? Brushes.Red : (ISOMain.showMod ? Brushes.LightGray : Brushes.DimGray));
		switch (num2 & 0x160)
		{
		case 32:
			val6 = new StringFormat((StringFormatFlags)1);
			array = ISensor.GetDataTree(num, e.Node.Index);
			num8 = ((Control)val).Width;
			break;
		case 64:
			val6 = new StringFormat();
			array = ISensor.GetDataTree((num2 & 3) + 4, int.Parse(e.Node.Name.Substring(0, 2)));
			break;
		}
		int num10 = (((num2 & 0x110) == 16) ? (num3 * 5 + 12) : 0);
		Font val8 = ((Control)val).Font;
		if (e.Node.NodeFont != null)
		{
			val8 = e.Node.NodeFont;
		}
		if (e.Node.IsExpanded & (num2 == 8))
		{
			Color lightGray = Color.LightGray;
			val4 = (Brush)new SolidBrush(lightGray);
		}
		else if (num2 < 0)
		{
			val3 = Pens.DarkGray;
			val5 = Brushes.DarkGray;
		}
		if (num == 1)
		{
			if ((e.Node.Level == 0) & !((Control)val).Enabled)
			{
				val3 = Pens.DarkGray;
				val5 = Brushes.DarkGray;
			}
			if (e.Node.Level > 0)
			{
				if (e.Node.Parent.Index > 0)
				{
					num3 = 10;
				}
				else if (Tune.nStyle.IndexOf(e.Node.Index.ToString("00")) > 0)
				{
					val8 = iFont;
					num5 = -2;
				}
			}
		}
		graphics.FillRectangle(val4, e.Bounds);
		if ((val.ImageList != null) & ((e.Node.ImageIndex != -2) | (Math.Abs(num2) == 1)))
		{
			num4 = val.ImageList.ImageSize.Width;
		}
		Brush val9;
		if (num10 > 0)
		{
			num9 = 2;
			val9 = (((ISOMain.eqDev & (1 << e.Node.Index * 2 + 1)) > 0) ? Brushes.Black : Brushes.DarkGray);
			graphics.DrawString(e.Node.Name, val8, val9, (float)(e.Bounds.Left + num10 + (int)((double)num4 * 1.25) + 2), (float)(e.Bounds.Top + num9 + 1));
			num7 = num5 + 2;
		}
		else if ((Math.Abs(num2) != 1) & (num != 2))
		{
			num7 = num3 * num6;
		}
		val9 = (((num10 == 0) | ((ISOMain.eqDev & (1 << e.Node.Index * 2)) > 0)) ? val5 : Brushes.DarkGray);
		graphics.DrawString(e.Node.Text, val8, val9, (float)(e.Bounds.Left + num7 - num5 + (int)((double)num4 * ((num2 == 8) ? 0.0 : 1.25))), (float)(e.Bounds.Top + num9 + 1));
		if (array.Length > 0)
		{
			int num11 = array.Length;
			for (int i = 0; i < num11; i++)
			{
				graphics.DrawString(array[i], tbFont, val7, (float)(num8 + i * (((Control)val).Width + (((num11 & 1) == 1) ? 14 : (-10))) / num11 - 6), (float)(e.Bounds.Top + ((ISOMain.swMode != 1) ? 1 : 3)), val6);
			}
		}
		int num12 = 9;
		Rectangle rectangle = new Rectangle(e.Bounds.Left + num7 - num3 / 2 - num12 / 2, e.Bounds.Top + val.ItemHeight / 2 - num12 / 2, num12, num12);
		if ((e.Node.Nodes.Count > 0) & (e.Node.Text != ""))
		{
			Rectangle rectangle2 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
			if (e.Node.IsExpanded)
			{
				graphics.FillRectangle(Brushes.White, rectangle);
				graphics.DrawRectangle(val3, rectangle2);
				graphics.FillRectangle(val5, rectangle.Left + 2, rectangle.Top + num12 / 2, num12 - 4, 1);
			}
			else
			{
				graphics.FillRectangle(Brushes.White, rectangle);
				graphics.DrawRectangle(val3, rectangle2);
				graphics.FillRectangle(val5, rectangle.Left + 2, rectangle.Top + num12 / 2, num12 - 4, 1);
				graphics.FillRectangle(val5, rectangle.Left + num12 / 2, rectangle.Top + 2, 1, num12 - 4);
			}
		}
		if (val.ImageList == null)
		{
			return;
		}
		int imageIndex = val.ImageIndex;
		if (e.Node.ImageIndex != -1)
		{
			imageIndex = e.Node.ImageIndex;
		}
		if (imageIndex > -1)
		{
			if (num10 > 0)
			{
				int num13 = ((ISORead.dataNum[e.Node.Index * 2 + 8] > 0) ? 4 : 3);
				val2 = val.ImageList.Images[num13];
				if (e.Node.Name != "")
				{
					graphics.DrawImageUnscaled(val2, e.Bounds.Left + num7 + num10 - num4, e.Bounds.Top + e.Bounds.Height / 2 - val2.Height / 2 + num9 - 1);
				}
				num13 = ((ISORead.dataNum[e.Node.Index * 2 + 7] > 0) ? 4 : 3);
				val2 = val.ImageList.Images[num13];
			}
			else
			{
				val2 = val.ImageList.Images[imageIndex];
			}
			graphics.DrawImageUnscaled(val2, e.Bounds.Left + num7 - num4, e.Bounds.Top + e.Bounds.Height / 2 - val2.Height / 2 + num9 - 1);
			if ((num2 == 1) & (ISOMain.eTrim != -1) & !ISOMain.oneTrim)
			{
				val2 = val.ImageList.Images[6];
				graphics.DrawImageUnscaled(val2, e.Bounds.Width - 16, e.Bounds.Top + e.Bounds.Height / 2 - val2.Height / 2 + num9 - 1);
			}
		}
		if (val8 == iFont)
		{
			val2 = val.ImageList.Images[7];
			graphics.DrawImageUnscaled(val2, e.Bounds.Left + num7 + 4, e.Bounds.Top + e.Bounds.Height / 2 - val2.Height / 2 + num9 - 1);
		}
	}

	static IDraw()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		blackBrush = new SolidBrush(Color.Black);
		shadowBrush = new SolidBrush(Color.FromKnownColor(KnownColor.ButtonShadow));
		whiteBrush = new SolidBrush(Color.White);
		darkBrush = new SolidBrush(Color.DarkGray);
		dimBrush = new SolidBrush(Color.DimGray);
		blueBrush = new SolidBrush(Color.SkyBlue);
		limeBrush = new SolidBrush(Color.Lime);
		redBrush = new SolidBrush(Color.Red);
		grayBrush = new SolidBrush(Color.FromArgb(225, 225, 225));
		cPen = new Pen((Brush)(object)shadowBrush);
		gPen = new Pen((Brush)(object)shadowBrush);
		sPen = new Pen((Brush)(object)shadowBrush);
		rPen = new Pen(Color.Cyan);
		editColor = Color.FromArgb(244, 244, 160);
		LEDRect = new Rectangle(4, 4, 24, 9);
		dGauge = new int[53]
		{
			0, 0, 534, 225, 800, 456, -112, 116, 0, 14250,
			48, 16, 156, 121, 220, 120, 0, 180, 0, 100,
			48, 162, 156, 267, 220, 120, 0, 180, 0, 1000,
			48, 308, 156, 413, 220, 120, 0, 180, 40, 120,
			120, 60, 48, 0, 100, 0, 1000, 40, 120, -20,
			60, 0, 50
		};
		dashRegion = new Rectangle[4]
		{
			new Rectangle(344, 36, 380, 380),
			new Rectangle(54, 18, 208, 132),
			new Rectangle(54, 164, 208, 132),
			new Rectangle(54, 310, 208, 132)
		};
		LCD_data = new int[36]
		{
			2, 577, 387, 28, 19, 0, 2, 168, 73, 20,
			14, 0, 2, 168, 219, 20, 14, 0, 2, 168,
			365, 20, 14, 0, 0, 556, 306, 70, 47, 0,
			2, 456, 387, 28, 19, 0
		};
		Indicator = new int[18]
		{
			604, 105, 425, 105, 377, 210, 655, 208, 366, 327,
			664, 327, 436, 327, 464, 274, 424, 294
		};
		Angle_Meter = new int[4] { -112, 0, 0, 0 };
		Matrix = new int[15]
		{
			4605510, 5263440, 5263440, 4605510, 2763306, 2114155, 2640756, 2640756, 2114155, 1058891,
			613971, 812121, 812121, 613971, 410679
		};
		wAngle = 0;
		imgAttr = new ImageAttributes();
		bckAttr = new ImageAttributes();
		hiAttr = new ImageAttributes();
		loAttr = new ImageAttributes();
		cMatrix = new ColorMatrix();
		fMatrix = new ColorMatrix();
		gMatrix = new ColorMatrix();
		mMatrix = new ColorMatrix();
	}
}
}
