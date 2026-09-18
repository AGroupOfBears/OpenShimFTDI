using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TuneLibrary;

namespace TuneECU;

public class ISORead : ISOMain
{
	private const int DTCTYPEACTIVE = 0;

	private const int DTCTYPEPENDING = 1;

	private const int DTCTYPEMAX = 2;

	private static ushort[,] mDtcCode;

	private static int[] mDtcCount;

	private static int mDTCMax;

	private static int msgDTC;

	public static short MIL = 0;

	public static eMode mMode;

	public static byte mTest;

	public static byte rTest;

	public static byte mTrim;

	public static int addrRead;

	public static int addrDump;

	public static int dataRow;

	public static int readRow;

	public static int readLen;

	public static byte[] csMap = new byte[28];

	public static byte[] csMap2 = new byte[28];

	public static byte[] readBuffer;

	private static byte[] uBuffer;

	private static byte bData;

	private static byte AM;

	private static int altDtc;

	private static int bSensor;

	private static ushort dSensor;

	private static int Init;

	private static int KEYR;

	private static int KEYW;

	public static int rIdle;

	public static int rMS;

	private static int rVersion;

	public static int iRetry;

	public static int rstLoad;

	public static int clearCodes;

	public static int readCodes;

	public static int setWBTrim;

	public static int msWalbro;

	public static int ECUTyp;

	public static int ECUTyp2;

	public static int iDST;

	public static int qDST;

	public static int pCount;

	public static string baseMap;

	public static string baseMap2;

	public static string mFileText;

	public static short[] dataNum = new short[60];

	public static string[] dataSensor = new string[200];

	public static string[] dataValue = new string[2];

	private static bool noSum;

	public static bool sGear = false;

	public static bool aRead;

	public static bool aWrite;

	public static bool mFlash;

	public static bool mLoad;

	public static bool mSafe;

	public static bool reLoad;

	public static bool safe = false;

	public static bool vSens;

	public static bool mId;

	private static short[] dataBlock = new short[16]
	{
		15363, 15364, 15365, 15368, 15370, 0, 0, 0, 6657, 6658,
		6661, 6674, 6688, 0, 6705, 6706
	};

	private static byte[] diagData = new byte[29]
	{
		1, 6, 4, 2, 3, 10, 12, 13, 11, 9,
		7, 0, 8, 0, 0, 0, 17, 112, 48, 160,
		144, 65, 81, 241, 66, 82, 242, 49, 0
	};

	public static byte[] dataSagemTrim = new byte[36]
	{
		255, 5, 0, 0, 255, 5, 0, 0, 255, 55,
		0, 0, 255, 55, 0, 0, 255, 50, 0, 0,
		255, 50, 0, 0, 35, 55, 0, 127, 35, 50,
		133, 112, 35, 53, 0, 145
	};

	private static ushort[] readSensor;

	public static ushort[] AllSensor;

	private static ushort[] EditSensorK = new ushort[30]
	{
		256, 1, 1, 1, 256, 1, 1, 1, 20739, 1,
		256, 1, 1, 1, 256, 1, 1, 1, 313, 1,
		256, 1, 1, 1, 256, 1, 1, 1, 7, 1
	};

	private static ushort[] EditSensorM = new ushort[30]
	{
		256, 1, 1, 1, 256, 1, 1, 1, 256, 1,
		256, 1, 1, 1, 256, 1, 1, 1, 256, 1,
		256, 1, 1, 1, 256, 1, 1, 1, 7, 1
	};

	private static ushort[] EditSensorL = new ushort[30]
	{
		256, 1, 119, 1, 256, 1, 119, 1, 256, 1,
		256, 1, 119, 1, 256, 1, 119, 1, 256, 1,
		256, 1, 119, 1, 256, 1, 119, 1, 7, 1
	};

	private static ushort[] EditSensorS = new ushort[20]
	{
		59, 1, 23, 1, 59, 1, 23, 1, 20739, 1,
		59, 1, 23, 1, 59, 1, 23, 1, 21, 1
	};

	private static ushort[] TestSensorK = new ushort[48]
	{
		3, 1, 23, 1, 49, 1, 0, 0, 35, 0,
		3, 1, 23, 1, 49, 1, 0, 0, 35, 0,
		3, 1, 23, 1, 49, 1, 0, 0, 35, 0,
		3, 1, 23, 1, 49, 1, 0, 0, 35, 0,
		3, 1, 23, 1, 49, 1, 313, 1
	};

	private static ushort[] TestSensorF = new ushort[10] { 1, 1, 65535, 0, 0, 1, 65535, 0, 65535, 0 };

	private static ushort[] TestSensorM = new ushort[10] { 3, 1, 23, 1, 0, 1, 65535, 0, 65535, 0 };

	private static ushort[] TestSensorL = new ushort[10] { 1, 1, 3, 1, 118, 1, 65535, 0, 65535, 0 };

	private static ushort[] TestSensorS = new ushort[6] { 5, 1, 9010, 1, 9015, 1 };

	public static ushort[] keihinT_Sensor = new ushort[318]
	{
		256, 4, 272, 0, 273, 0, 1, 4, 274, 0,
		288, 0, 9, 3, 256, 4, 289, 0, 290, 0,
		1, 4, 304, 3, 305, 3, 8, 0, 256, 4,
		306, 3, 3, 0, 1, 4, 23, 3, 49, 0,
		17, 0, 256, 4, 2, 3, 263, 0, 1, 4,
		353, 3, 352, 0, 320, 0, 256, 4, 19, 0,
		0, 0, 1, 4, 324, 0, 342, 0, 20739, 0,
		256, 4, 325, 0, 257, 0, 1, 4, 33, 0,
		35, 3, 5, 0, 256, 4, 34, 3, 355, 0,
		1, 4, 98, 0, 65, 0, 4, 0, 256, 4,
		99, 3, 64, 0, 1, 4, 272, 3, 273, 3,
		264, 0, 256, 4, 274, 0, 288, 0, 1, 4,
		289, 0, 290, 0, 97, 3, 256, 4, 304, 0,
		305, 0, 1, 4, 306, 3, 3, 3, 313, 3,
		256, 4, 23, 3, 49, 0, 1, 4, 2, 3,
		263, 0, 38, 0, 256, 4, 353, 0, 352, 0,
		1, 4, 19, 0, 0, 0, 105, 0, 256, 4,
		324, 0, 342, 0, 1, 4, 325, 0, 257, 3,
		7, 0, 256, 4, 33, 3, 35, 0, 1, 4,
		34, 0, 355, 0, 16, 3, 256, 4, 98, 3,
		65, 0, 1, 4, 99, 3, 64, 3, 112, 0,
		256, 4, 272, 0, 273, 0, 1, 4, 274, 0,
		288, 0, 104, 3, 256, 4, 289, 0, 290, 0,
		1, 4, 304, 3, 305, 3, 96, 0, 256, 4,
		306, 3, 3, 0, 1, 4, 23, 3, 49, 0,
		20739, 0, 256, 4, 2, 3, 263, 0, 1, 4,
		353, 3, 352, 0, 70, 0, 256, 4, 19, 0,
		0, 0, 1, 4, 324, 0, 342, 0, 68, 3,
		256, 4, 325, 0, 257, 0, 1, 4, 33, 0,
		35, 3, 102, 0, 256, 4, 34, 3, 64, 0,
		1, 4, 98, 0, 65, 0, 100, 0, 256, 4,
		99, 3, 355, 0, 1, 4, 66, 0
	};

	public static ushort[] keihinD_Sensor = new ushort[350]
	{
		256, 4, 272, 0, 273, 0, 1, 4, 288, 0,
		289, 0, 9, 3, 256, 4, 304, 0, 305, 0,
		1, 4, 2, 3, 324, 3, 8, 0, 256, 4,
		3, 0, 23, 0, 1, 4, 342, 3, 325, 3,
		313, 0, 256, 4, 263, 3, 328, 0, 1, 4,
		344, 3, 329, 0, 17, 0, 256, 4, 0, 0,
		19, 0, 1, 4, 21, 0, 257, 0, 16, 0,
		256, 4, 33, 0, 98, 0, 1, 4, 65, 0,
		66, 3, 5, 0, 256, 4, 64, 3, 272, 0,
		1, 4, 273, 0, 288, 0, 264, 0, 256, 4,
		289, 0, 304, 0, 1, 4, 305, 0, 2, 0,
		100, 3, 256, 4, 324, 0, 3, 0, 1, 4,
		23, 3, 342, 3, 101, 0, 256, 4, 325, 3,
		263, 0, 1, 4, 328, 3, 344, 0, 97, 0,
		256, 4, 329, 0, 0, 0, 1, 4, 19, 0,
		21, 0, 20739, 0, 256, 4, 257, 0, 33, 0,
		1, 4, 98, 0, 65, 3, 105, 0, 256, 4,
		66, 3, 64, 0, 1, 4, 272, 0, 273, 0,
		7, 0, 256, 4, 288, 0, 289, 0, 1, 4,
		304, 0, 305, 0, 4, 3, 256, 4, 2, 0,
		324, 0, 1, 4, 3, 3, 23, 3, 38, 0,
		256, 4, 342, 3, 325, 0, 1, 4, 20739, 3,
		263, 0, 99, 0, 256, 4, 328, 0, 344, 0,
		1, 4, 329, 0, 0, 0, 96, 0, 256, 4,
		19, 0, 21, 0, 1, 4, 257, 0, 33, 3,
		70, 0, 256, 4, 98, 3, 65, 0, 1, 4,
		66, 0, 64, 0, 264, 0, 256, 4, 272, 0,
		273, 0, 1, 4, 288, 0, 289, 0, 102, 3,
		256, 4, 304, 0, 305, 0, 1, 4, 2, 3,
		324, 3, 68, 0, 256, 4, 3, 0, 23, 0,
		1, 4, 342, 3, 325, 3, 97, 0, 256, 4,
		263, 3, 328, 0, 1, 4, 344, 3, 329, 0,
		20739, 0, 256, 4, 0, 0, 19, 0, 1, 4,
		21, 0, 257, 0, 104, 0, 256, 4, 33, 0,
		98, 0, 1, 4, 65, 0, 66, 3, 64, 0
	};

	public static ushort[] keihinF_Sensor = new ushort[224]
	{
		256, 4, 272, 0, 273, 0, 1, 4, 274, 0,
		275, 0, 9, 3, 256, 4, 288, 0, 289, 0,
		1, 4, 290, 3, 291, 3, 8, 0, 256, 4,
		304, 3, 305, 0, 1, 4, 306, 3, 307, 0,
		17, 0, 256, 4, 19, 0, 324, 0, 1, 4,
		342, 0, 325, 0, 16, 0, 256, 4, 353, 0,
		352, 0, 1, 4, 0, 0, 368, 3, 5, 0,
		256, 4, 24, 3, 3, 0, 1, 4, 2, 0,
		257, 0, 4, 0, 256, 4, 20739, 0, 355, 0,
		1, 4, 98, 0, 65, 0, 264, 3, 256, 4,
		66, 0, 263, 0, 1, 4, 96, 0, 68, 0,
		102, 3, 256, 4, 272, 0, 273, 0, 1, 4,
		274, 0, 275, 0, 97, 3, 256, 4, 288, 0,
		289, 0, 1, 4, 290, 3, 291, 3, 320, 0,
		256, 4, 304, 3, 305, 0, 1, 4, 306, 3,
		307, 0, 100, 0, 256, 4, 19, 0, 324, 0,
		1, 4, 342, 0, 325, 0, 99, 0, 256, 4,
		353, 0, 352, 0, 1, 4, 0, 0, 368, 3,
		7, 0, 256, 4, 24, 3, 3, 0, 1, 4,
		2, 0, 257, 0, 96, 0, 256, 4, 20739, 0,
		355, 0, 1, 4, 98, 0, 65, 0, 313, 3,
		256, 4, 66, 0, 263, 0, 1, 4, 96, 0,
		68, 0, 102, 3
	};

	public static ushort[] keihinK_Sensor = new ushort[196]
	{
		256, 4, 272, 0, 273, 0, 1, 4, 288, 0,
		289, 0, 9, 3, 256, 4, 304, 0, 305, 0,
		1, 4, 3, 0, 23, 0, 8, 3, 256, 4,
		2, 0, 22, 0, 1, 4, 0, 0, 320, 0,
		17, 3, 256, 4, 24, 0, 264, 0, 1, 4,
		353, 0, 352, 0, 16, 3, 256, 4, 368, 0,
		369, 0, 1, 4, 263, 0, 18, 0, 7, 3,
		256, 4, 20, 0, 65, 0, 1, 4, 66, 0,
		64, 0, 96, 3, 256, 4, 40, 0, 33, 0,
		1, 4, 41, 0, 0, 0, 102, 3, 256, 4,
		272, 0, 273, 0, 1, 4, 288, 0, 289, 0,
		100, 3, 256, 4, 304, 0, 305, 0, 1, 4,
		3, 0, 23, 0, 101, 3, 256, 4, 2, 0,
		22, 0, 1, 4, 0, 0, 320, 0, 67, 3,
		256, 4, 24, 0, 264, 0, 1, 4, 353, 0,
		352, 0, 69, 3, 256, 4, 368, 0, 369, 0,
		1, 4, 263, 0, 18, 0, 5, 3, 256, 4,
		20, 0, 65, 0, 1, 4, 66, 0, 64, 0,
		4, 3, 256, 4, 40, 0, 33, 0, 1, 4,
		41, 0, 0, 0, 68, 3
	};

	public static ushort[] keihinL_Sensor = new ushort[134]
	{
		256, 4, 272, 0, 288, 0, 1, 4, 304, 0,
		3, 0, 9, 3, 256, 4, 0, 0, 2, 0,
		1, 4, 264, 0, 119, 0, 8, 3, 256, 4,
		118, 0, 320, 0, 1, 4, 263, 0, 18, 0,
		17, 3, 256, 4, 65, 0, 66, 0, 1, 4,
		64, 0, 40, 0, 16, 3, 256, 4, 33, 0,
		100, 0, 1, 4, 102, 0, 272, 0, 96, 3,
		256, 4, 288, 0, 304, 0, 1, 4, 3, 0,
		0, 0, 68, 3, 256, 4, 2, 0, 264, 0,
		1, 4, 119, 0, 118, 0, 7, 3, 256, 4,
		320, 0, 263, 0, 1, 4, 18, 0, 65, 0,
		5, 3, 256, 4, 66, 0, 64, 0, 1, 4,
		40, 0, 33, 0, 4, 3, 256, 4, 100, 0,
		102, 0, 1, 4
	};

	public static ushort[] sagemT_Sensor = new ushort[144]
	{
		59, 4, 1029, 0, 1030, 0, 23, 4, 76, 0,
		77, 0, 3, 0, 59, 4, 8, 0, 1031, 0,
		23, 4, 78, 0, 7, 0, 59, 4, 28929, 0,
		26, 0, 23, 4, 9015, 0, 300, 0, 4, 0,
		59, 4, 20756, 0, 16653, 0, 23, 4, 9, 0,
		9013, 0, 59, 4, 20739, 0, 24, 0, 23, 4,
		10, 0, 1, 0, 5, 0, 59, 4, 15, 0,
		2, 0, 23, 4, 1029, 0, 1030, 0, 59, 4,
		76, 0, 8, 0, 23, 4, 77, 0, 1031, 0,
		9010, 0, 59, 4, 78, 0, 7, 0, 23, 4,
		28929, 0, 26, 0, 59, 4, 9015, 0, 16653, 0,
		23, 4, 20756, 0, 300, 0, 21, 0, 59, 4,
		20739, 0, 9013, 0, 23, 4, 24, 0, 9, 0,
		59, 4, 10, 0, 1, 0, 23, 4, 15, 0,
		2, 0, 9030, 0
	};

	public static ushort[] sagemF_Sensor = new ushort[130]
	{
		59, 4, 1029, 0, 1030, 0, 23, 4, 1031, 0,
		1032, 0, 3, 0, 59, 4, 76, 0, 77, 0,
		23, 4, 78, 0, 79, 0, 59, 4, 28929, 0,
		26, 0, 23, 4, 9015, 0, 300, 0, 4, 0,
		59, 4, 8, 0, 16653, 0, 23, 4, 9, 0,
		9013, 0, 59, 4, 24, 0, 10, 0, 23, 4,
		1, 0, 15, 0, 5, 0, 59, 4, 1029, 0,
		1030, 0, 23, 4, 1031, 0, 1032, 0, 59, 4,
		76, 0, 77, 0, 23, 4, 78, 0, 79, 0,
		2, 0, 59, 4, 7, 0, 28929, 0, 23, 4,
		26, 0, 16653, 0, 59, 4, 300, 0, 9013, 0,
		23, 4, 24, 0, 9, 0, 21, 0, 59, 4,
		10, 0, 1, 0, 23, 4, 15, 0, 9030, 0
	};

	public static ulong[] IdVersion = new ulong[9] { 0uL, 360287970206417152uL, 504403158282273024uL, 216172782164116224uL, 432345564261122304uL, 0uL, 0uL, 0uL, 216172782164115968uL };

	private static byte[] usrProg = new byte[1474]
	{
		122, 7, 0, 255, 251, 254, 94, 255, 244, 10,
		1, 32, 109, 244, 122, 3, 255, 255, 254, 189,
		104, 58, 202, 212, 104, 186, 122, 3, 255, 255,
		255, 109, 104, 58, 202, 84, 104, 186, 106, 56,
		255, 255, 254, 213, 114, 80, 24, 238, 122, 0,
		0, 255, 250, 196, 24, 187, 12, 234, 23, 82,
		23, 114, 10, 130, 104, 171, 142, 1, 174, 1,
		67, 240, 24, 238, 122, 0, 0, 255, 250, 208,
		24, 187, 12, 234, 23, 82, 23, 114, 10, 130,
		104, 171, 142, 1, 174, 63, 67, 240, 250, 48,
		106, 170, 0, 255, 250, 176, 251, 49, 122, 2,
		0, 255, 250, 177, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 178, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 179, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 180, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 181, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 182, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 183, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 184, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 185, 104, 171, 251, 65, 122, 2,
		0, 255, 250, 186, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 187, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 188, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 189, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 190, 104, 171, 139, 1, 122, 2,
		0, 255, 250, 191, 104, 171, 24, 170, 106, 170,
		255, 255, 255, 128, 122, 3, 255, 255, 255, 130,
		104, 58, 202, 48, 104, 186, 250, 12, 106, 170,
		255, 255, 255, 129, 248, 1, 94, 255, 249, 166,
		24, 170, 106, 170, 0, 255, 250, 164, 122, 0,
		0, 255, 250, 164, 94, 255, 249, 108, 106, 42,
		0, 255, 250, 164, 170, 2, 70, 222, 250, 8,
		58, 66, 121, 2, 90, 127, 107, 162, 255, 255,
		255, 190, 24, 204, 26, 162, 11, 2, 122, 34,
		0, 1, 36, 247, 67, 246, 248, 4, 94, 255,
		249, 166, 12, 200, 94, 255, 249, 166, 24, 170,
		106, 170, 0, 255, 250, 164, 122, 0, 0, 255,
		250, 164, 94, 255, 249, 108, 106, 42, 0, 255,
		250, 164, 170, 8, 70, 204, 140, 1, 172, 15,
		67, 198, 248, 4, 94, 255, 249, 166, 24, 170,
		106, 170, 0, 255, 250, 164, 122, 0, 0, 255,
		250, 164, 94, 255, 249, 108, 106, 42, 0, 255,
		250, 164, 170, 6, 70, 222, 24, 238, 12, 234,
		23, 82, 13, 36, 23, 116, 15, 192, 122, 16,
		0, 255, 250, 208, 94, 255, 249, 108, 12, 136,
		71, 240, 142, 1, 174, 1, 67, 226, 122, 3,
		0, 255, 250, 208, 104, 58, 170, 69, 88, 112,
		3, 102, 170, 80, 71, 8, 250, 66, 104, 186,
		88, 0, 3, 90, 122, 2, 0, 255, 250, 209,
		104, 42, 106, 170, 0, 255, 250, 200, 248, 75,
		94, 255, 249, 166, 24, 238, 64, 26, 12, 234,
		23, 82, 13, 36, 23, 116, 15, 192, 122, 16,
		0, 255, 250, 210, 94, 255, 249, 108, 12, 136,
		71, 240, 142, 1, 106, 42, 0, 255, 250, 200,
		28, 174, 69, 220, 24, 170, 106, 170, 0, 255,
		250, 199, 24, 238, 106, 42, 0, 255, 250, 200,
		23, 82, 11, 2, 25, 0, 29, 32, 76, 38,
		122, 1, 0, 255, 250, 208, 13, 32, 24, 187,
		12, 234, 23, 82, 23, 114, 10, 146, 104, 42,
		8, 171, 142, 1, 12, 234, 23, 82, 29, 2,
		77, 234, 106, 171, 0, 255, 250, 199, 12, 234,
		23, 82, 23, 114, 122, 0, 0, 255, 250, 208,
		106, 43, 0, 255, 250, 199, 120, 32, 106, 42,
		0, 255, 250, 208, 28, 171, 71, 8, 250, 67,
		104, 138, 88, 0, 2, 184, 122, 2, 0, 255,
		250, 210, 104, 40, 23, 80, 12, 128, 24, 136,
		13, 8, 25, 0, 122, 2, 0, 255, 250, 211,
		104, 42, 23, 82, 13, 42, 25, 34, 10, 160,
		122, 2, 0, 255, 250, 212, 104, 43, 16, 115,
		16, 115, 16, 115, 16, 115, 235, 0, 25, 187,
		122, 2, 0, 255, 250, 213, 104, 42, 23, 82,
		10, 176, 20, 168, 1, 0, 107, 160, 0, 255,
		250, 192, 24, 238, 106, 42, 0, 255, 250, 200,
		23, 82, 13, 32, 121, 18, 255, 251, 25, 51,
		29, 35, 76, 54, 12, 234, 23, 82, 13, 35,
		23, 115, 121, 18, 0, 6, 23, 242, 120, 32,
		106, 42, 0, 255, 250, 208, 120, 48, 106, 170,
		0, 255, 251, 32, 120, 48, 106, 170, 0, 255,
		250, 128, 142, 1, 12, 235, 23, 83, 13, 2,
		121, 18, 255, 251, 29, 35, 77, 202, 1, 0,
		107, 34, 0, 255, 250, 192, 122, 34, 0, 1,
		255, 255, 88, 32, 1, 202, 24, 170, 106, 170,
		0, 255, 251, 16, 127, 200, 112, 96, 106, 42,
		0, 255, 251, 16, 138, 1, 106, 170, 0, 255,
		251, 16, 24, 170, 106, 170, 0, 255, 250, 198,
		121, 0, 0, 10, 94, 255, 249, 90, 24, 238,
		106, 42, 0, 255, 250, 200, 23, 82, 121, 18,
		255, 251, 25, 0, 29, 32, 76, 50, 122, 0,
		0, 255, 250, 128, 12, 234, 23, 82, 23, 114,
		1, 0, 107, 35, 0, 255, 250, 192, 10, 163,
		10, 130, 104, 42, 104, 186, 142, 1, 12, 235,
		23, 83, 106, 42, 0, 255, 250, 200, 23, 82,
		121, 18, 255, 251, 29, 35, 77, 212, 121, 2,
		90, 0, 107, 162, 255, 255, 255, 188, 121, 2,
		165, 58, 107, 162, 255, 255, 255, 188, 122, 4,
		0, 255, 255, 201, 125, 64, 112, 0, 121, 0,
		0, 50, 94, 255, 249, 90, 127, 200, 112, 0,
		121, 0, 0, 170, 94, 255, 249, 90, 127, 200,
		114, 0, 121, 0, 0, 10, 94, 255, 249, 90,
		125, 64, 114, 0, 121, 0, 0, 10, 94, 255,
		249, 90, 121, 2, 165, 28, 107, 162, 255, 255,
		255, 188, 127, 200, 112, 32, 121, 0, 0, 4,
		94, 255, 249, 90, 24, 238, 106, 42, 0, 255,
		250, 200, 23, 82, 121, 18, 255, 251, 25, 17,
		29, 33, 88, 192, 0, 140, 12, 237, 23, 85,
		13, 84, 23, 116, 1, 0, 107, 35, 0, 255,
		250, 192, 10, 195, 250, 255, 104, 186, 121, 0,
		0, 2, 94, 255, 249, 90, 1, 0, 107, 35,
		0, 255, 250, 192, 10, 195, 15, 192, 122, 16,
		0, 255, 250, 128, 105, 49, 122, 20, 0, 255,
		251, 32, 104, 74, 23, 10, 104, 59, 22, 186,
		23, 10, 104, 138, 11, 5, 23, 245, 15, 211,
		122, 19, 0, 255, 250, 128, 122, 21, 0, 255,
		251, 32, 104, 90, 23, 10, 22, 154, 12, 169,
		23, 9, 104, 185, 104, 10, 170, 255, 70, 4,
		169, 255, 71, 8, 250, 1, 106, 170, 0, 255,
		250, 198, 142, 2, 12, 235, 23, 83, 106, 42,
		0, 255, 250, 200, 23, 82, 121, 18, 255, 251,
		29, 35, 88, 208, 255, 116, 127, 200, 114, 32,
		121, 0, 0, 5, 94, 255, 249, 90, 248, 78,
		94, 255, 249, 166, 248, 84, 94, 255, 249, 166,
		106, 40, 0, 255, 251, 16, 94, 255, 249, 166,
		106, 42, 0, 255, 250, 198, 71, 12, 106, 42,
		0, 255, 251, 16, 170, 239, 88, 48, 254, 100,
		127, 200, 114, 96, 106, 42, 0, 255, 251, 16,
		170, 240, 70, 10, 248, 241, 94, 255, 249, 166,
		88, 0, 252, 186, 248, 240, 94, 255, 249, 166,
		88, 0, 252, 176, 1, 0, 107, 36, 0, 255,
		250, 192, 248, 242, 94, 255, 249, 166, 15, 194,
		13, 162, 12, 42, 23, 82, 23, 114, 12, 168,
		94, 255, 249, 166, 15, 194, 13, 162, 25, 170,
		12, 168, 94, 255, 249, 166, 15, 194, 17, 114,
		17, 114, 17, 114, 17, 114, 12, 168, 94, 255,
		249, 166, 12, 200, 94, 255, 249, 166, 88, 0,
		252, 108, 106, 40, 0, 255, 250, 208, 106, 168,
		0, 255, 250, 196, 94, 255, 249, 166, 24, 170,
		58, 202, 58, 203, 127, 200, 114, 96, 64, 254,
		16, 80, 16, 80, 25, 34, 29, 2, 68, 6,
		11, 2, 29, 2, 69, 250, 84, 112, 122, 3,
		255, 255, 255, 132, 104, 58, 234, 135, 104, 186,
		121, 2, 234, 96, 124, 48, 115, 96, 70, 6,
		27, 2, 13, 34, 70, 244, 13, 34, 70, 4,
		25, 0, 64, 20, 106, 42, 255, 255, 255, 133,
		104, 138, 106, 56, 255, 255, 255, 132, 114, 96,
		121, 0, 0, 1, 84, 112, 122, 3, 255, 255,
		255, 132, 104, 58, 234, 128, 71, 250, 106, 168,
		255, 255, 255, 131, 106, 56, 255, 255, 255, 132,
		114, 112, 84, 112
	};

	private static byte[] Walbro_Init = new byte[3] { 58, 63, 0 };

	private static byte[] Walbro_Info = new byte[13]
	{
		58, 82, 48, 48, 48, 50, 48, 56, 48, 48,
		51, 67, 0
	};

	private static byte[] Walbro_Version = new byte[13]
	{
		58, 86, 48, 48, 48, 48, 48, 48, 48, 48,
		48, 56, 0
	};

	private static byte[] Walbro_Trim = new byte[13]
	{
		58, 82, 48, 48, 48, 50, 48, 56, 48, 48,
		48, 56, 0
	};

	private static byte[] Walbro_Sensors = new byte[13]
	{
		58, 84, 48, 48, 48, 48, 48, 48, 48, 48,
		48, 56, 0
	};

	private static byte[] Walbro_TPS = new byte[13]
	{
		58, 82, 48, 48, 70, 70, 69, 67, 48, 56,
		48, 50, 0
	};

	private static byte[] Walbro_Set_Value = new byte[29]
	{
		58, 87, 48, 48, 48, 50, 48, 56, 48, 48,
		48, 56, 50, 54, 68, 48, 56, 67, 56, 67,
		56, 67, 56, 67, 56, 49, 48, 48, 0
	};

	private static byte[] Walbro_ReadMem = new byte[13]
	{
		58, 82, 48, 48, 48, 48, 48, 48, 48, 48,
		50, 48, 0
	};

	private static byte[] Walbro_DTC = new byte[13]
	{
		58, 82, 48, 48, 48, 50, 48, 48, 48, 48,
		49, 56, 0
	};

	private static byte[] walbro_Clear_DTC = new byte[15]
	{
		58, 87, 48, 48, 48, 50, 48, 48, 48, 48,
		48, 49, 48, 48, 0
	};

	private static int[] walbroDTC = new int[64]
	{
		122, 123, 0, 0, 105, 0, 118, 119, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		562, 563, 1203, 0, 0, 0, 0, 0, 1201, 1202,
		1352, 1353, 0, 0, 1231, 1232, 0, 1351, 1502, 1552,
		1553, 1601, 0, 0, 0, 1501, 0, 0, 0, 0,
		1602, 0, 0, 0
	};

	private static string[] AltDesc = new string[3] { "P0201P0202P0351P0352P1201P1202P1205P1206P1351P1352P1355P1356P1501P1502", "P0227P0228", "P0118P0119P0122P0123P1501P1502" };

	private static string[,] DtcDescription = new string[6, 195]
	{
		{
			"P0031\tOxygen sensor heater short circuit to ground or open circuit", "P0032\tOxygen sensor heater short circuit to battery", "P0051\tOxygen sensor 2, heater short circuit to ground or open circuit", "P0052\tOxygen sensor 2, heater short circuit to battery", "P0078\tExhaust control valve actuator circuit malfunction", "P0105\tBarometric pressure sensor circuit malfunction", "P0107\tMAP sensor short circuit to ground", "P0108\tMAP sensor short circuit to battery or open circuit", "P0110\tInlet air temperature sensor circuit malfunction", "P0112\tInlet air temperature sensor short circuit to ground",
			"P0113\tInlet air temperature sensor open circuit or short circuit to battery", "P0115\tCoolant temperature sensor circuit malfunction", "P0116\tCoolant temperature sensor circuit (1st Cylinder) malfunction", "P0117\tCoolant temperature sensor high voltage or short circuit to battery", "P0118\tCoolant temperature sensor low voltage (short to ground or open circuit)", "3P0118\tEngine temperature sensor, short circuit", "P0119\tEngine coolant sensor, hight voltage", "3P0119\tEngine temperature sensor, open circuit", "P0120\tThrottle position sensor circuit malfunction", "P0122\tThrottle position sensor low voltage (short to ground or open circuit)",
			"3P0122\tThrottle position sensor, short circuit", "P0123\tThrottle position sensor high voltage or short circuit to battery", "3P0123\tThrottle position sensor, open circuit", "P0130\tLambda sensor, circuit malfunction", "P0131\tLambda sensor, short circuit to ground", "P0132\tLambda sensor signal too high", "P0133\tLambda sensor, short circuit to battery", "P0135\tOxygen sensor heater circuit malfunction", "P0150\tLambda sensor 2, circuit malfunction", "P0170\tLambda feedback fuel trim malfunction",
			"P0201\tInjector 1 circuit malfunction", "1P0201\tInjector 2 circuit malfunction", "P0202\tInjector 2 circuit malfunction", "1P0202\tInjector 1 circuit malfunction", "P0203\tInjector 3 circuit malfunction", "P0204\tInjector 4 circuit malfunction", "P0222\t2nd Throttle position sensor, low voltage (short to ground or open circuit)", "P0223\t2nd Throttle position sensor, high voltage or short circuit to battery", "P0227\t2nd Throttle position sensor, low voltage (short to ground or open circuit)", "2P0227\tGrip throttle position sensor, low voltage (short to ground or open circuit)",
			"P0228\t2nd Throttle position sensor, high voltage or short circuit to battery", "2P0228\tGrip throttle position sensor, high voltage or short circuit to battery", "P0230\tFuel pump relay default", "P0335\tCrankshaft sensor circuit malfunction", "P0340\tCamshaft sensor malfunction", "P0341\tCamshaft sensor circuit malfunction", "P0351\tIgnition coil 1 circuit malfunction", "1P0351\tIgnition coil 2 circuit malfunction", "P0352\tIgnition coil 2 circuit malfunction", "1P0352\tIgnition coil 1 circuit malfunction",
			"P0353\tIgnition coil 3 circuit malfunction", "P0354\tIgnition coil 4 circuit malfunction", "P0413\tSecondary air injection system short circuit to ground or open circuit", "P0414\tSecondary air injection system short circuit to battery", "P0443\tPurge valve system circuit malfunction", "P0444\tPurge Valve system open circuit or short circuit to ground", "P0445\tPurge valve system short circuit to battery", "P0460\tFuel level sensor circuit malfunction", "P0462\tFuel level sensor circuit low input", "P0463\tFuel level sensor circuit high input",
			"P0500\tVehicle speed sensor malfunction", "P0505\tIdle speed control system malfunction", "P0510\tTwist grip cruise cancel switch malfunction", "P0560\tECM power supply, circuit malfunction", "P0562\tSystem voltage low", "P0563\tSystem voltage high", "P0571\tBrake 1 switch malfunction", "P0603\tEEPROM fault", "P0616\tStarter relay short circuit to ground or open circuit", "P0617\tStarter relay short circuit to battery",
			"P0630\tEEPROM-Error", "P0638\t2nd Throttle control system malfunction", "P0654\tTachometer circuit malfunction", "P0656\tFuel gauge, circuit malfunction", "P0705\tGear position sensor circuit malfunction", "P1030\tOxygen sensor circuit malfunction", "P1078\tExhaust control valve actuator position sensor circuit low voltage or short to ground", "P1079\tExhaust control valve actuator position sensor circuit high voltage or short to battery", "P1080\tExhaust control valve actuator circuit malfunction", "P1105\tMAP sensor pipe fault",
			"P1106\tMAP sensor 2, pipe fault", "P1107\tAmbient pressure sensor circuit low voltage or short to ground", "P1108\tAmbient pressure sensor circuit high voltage or open circuit", "P1111\tManifold absolute pressure sensor pipes reversed", "P1115\tCoolant temperature gauge circuit malfunction", "P1116\tCoolant temperature gauge, short circuit to ground or open circuit", "P1117\tCoolant temperature gauge, short circuit to battery or over temperature", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tTraction Control prevented due to ABS malfunction", "P1171\tLambda feedback maximum enrichment", "P1172\tLambda feedback maximum enleanment", "P1178\tLambda feedback reached maximum air leakage adaption", "P1179\tLambda feedback reached minimum air leakage adaption", "P1201\tInjector 1, open circuit or short to ground", "1P1201\tInjector 2, open circuit or short to ground", "P1202\tInjector 2, open circuit or short to ground", "1P1202\tInjector 1, open circuit or short to ground", "P1203\tInjector 3, open circuit or short to ground",
			"P1204\tInjector 4, open circuit or short to ground", "P1205\tInjector 1, short circuit to battery or over temperature", "1P1205\tInjector 2, short circuit to battery or over temperature", "P1206\tInjector 2, short circuit to battery or over temperature", "1P1206\tInjector 1, short circuit to battery or over temperature", "P1207\tInjector 3, short circuit to battery or over temperature", "P1208\tInjector 4, short circuit to battery or over temperature", "P1231\tFuel pump relay open circuit or short to ground", "P1232\tFuel pump relay short circuit to battery", "P1335\tCrankshaft sensor incorrect sequence pattern",
			"P1340\tElectrical Noise signal", "P1341\tCamshaft sensor incorrect sequence pattern", "P1351\tIgnition coil 1, open circuit or short circuit to ground", "1P1351\tIgnition coil 2, open circuit or short circuit to ground", "P1352\tIgnition coil 2, open circuit or short circuit to ground", "1P1352\tIgnition coil 1, open circuit or short circuit to ground", "P1353\tIgnition coil 3, open circuit or short circuit to ground", "P1354\tIgnition coil 4, open circuit or short circuit to ground", "P1355\tIgnition coil 1, short circuit to battery or over temperature", "1P1355\tIgnition coil 2, short circuit to battery or over temperature",
			"P1356\tIgnition coil 2, short circuit to battery or over temperature", "1P1356\tIgnition coil 1, short circuit to battery or over temperature", "P1357\tIgnition coil 3, short circuit to battery or over temperature", "P1358\tIgnition coil 4, short circuit to battery or over temperature", "P1385\tTachometer system malfunction", "P1386\tTachometer, open circuit or short to ground", "P1387\tTachometer, short circuit to battery or over temperature", "P1500\tVehicle speed sensor, circuit malfunction", "P1501\tSpeedometer driver, open circuit or short to ground", "1P1501\tInlet air temperature sensor, short circuit to ground",
			"3P1501\tInlet air temperature sensor, short circuit", "P1502\tSpeedometer driver, short circuit to battery or over temperature", "1P1502\tInlet air temperature sensor, open circuit or short circuit to battery", "3P1502\tInlet air temperature sensor, open circuit", "P1508\tUnmatched Immobiliser ECM", "P1520\tUnmatched ABS", "P1521\tLost communication with ABS", "P1530\tThrottle hall effect sensor circuit malfunction", "P1534\tEngine oil level sensor circuit malfunction", "P1551\tCooling fan system malfunction",
			"P1552\tCooling fan open circuit or short circuit to ground", "P1553\tCooling fan short circuit to battery", "P1560\tSensor supply voltage circuit fault", "P1571\tBrake 2 switch malfunction", "P1574\tCruise Control prevented due to other malfunction condition", "P1575\tCruise Control disabled until button press sequence completed", "P1576\tBrake 1 switch correlation error with brake switch 2", "P1577\tBrake 2 switch correlation error with brake switch 1", "P1590\tSide stand switch, low voltage or short to ground", "P1600\tMIL, system fault",
			"P1601\tMIL, open circuit or short circuit to ground", "P1602\tMIL, short circuit to battery", "P1604\tECM tamper detected - return to Triumph", "P1605\tECU locked by the tunelock function", "P1606\tECM internal error", "P1607\tECM ride by wire internal error", "P1608\tECM ride by wire internal error", "P1610\tLow fuel output circuit malfunction", "P1611\tLow fuel indicator lamp, short circuit to ground or open circuit", "P1612\tLow fuel indicator lamp, short circuit to battery",
			"P1614\tInstrument ID incompatible", "P1616\tAccessory control relay short circuit to ground or open circuit", "P1617\tAccessory control relay short circuit to battery", "P1619\tHeadlamp relay short circuit to ground or open circuit", "P1620\tHeadlamp relay short circuit to battery", "P1621\tFuel gauge, short circuit to ground or open circuit", "P1622\tFuel gauge, short circuit to battery", "P1628\tFuel pump short circuit to ground or open circuit", "P1629\tFuel pump short to battery", "P1631\tFall detection sensor circuit low voltage or short to ground",
			"P1632\tFall detection sensor circuit high voltage or open circuit", "P1633\tWindscreen system malfunction", "P1650\tLost communication with RCU (or immobiliser malfunction)", "P1659\tEMS ignition voltage input malfunction", "P1670\tIntake flap solenoid short circuit to ground or open circuit", "P1671\tIntake flap solenoid short circuit to battery", "P1685\tEMS main relay circuit malfunction", "P1687\tMAP sensor 2, short circuit to ground", "P1688\tMAP sensor 2, short circuit to battery or open circuit", "P1690\tMalfunction of CAN-Bus communication",
			"P1695\tLost communication with instrument panel", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tSensor supply battery circuit malfunction", "P2118\tThrottle motor drive circuit malfunction", "P2119\tThrottle position fault", "P2183\tCoolant temperature sensor circuit (2nd Cylinder) malfunction", "L0001\tFront wheel unit sensor battery alert", "L0002\tRear wheel unit sensor battery alert", "L0003\tFront wheel unit sensor fault alert",
			"L0004\tRear wheel unit sensor fault alert", "L0005\tFront wheel unit sensor loss of communication", "L0006\tRear wheel unit sensor loss of communication", "L0007\tRCU fault", "L0008\tInvalid key: Key authentication unsuccessful"
		},
		{
			"P0031\tSonde Lambda, circuit de chauffe ouvert ou court-circuit à la masse", "P0032\tSonde Lambda, circuit de chauffe court-circuit à la batterie", "P0051\tSonde Lambda 2, circuit de chauffe ouvert ou court-circuit à la masse", "P0052\tSonde Lambda 2, circuit de chauffe court-circuit à la batterie", "P0078\tValve d'échappement, dysfonctionnement du circuit de commande", "P0105\tDysfonctionnement du circuit du capteur de pression barométrique", "P0107\tCapteur de pression d'admission, court-circuit à la masse", "P0108\tCapteur de pression d'admission, circuit ouvert ou court-circuit à la batterie", "P0110\tDysfonctionnement du circuit du capteur de température d'air d'admission", "P0112\tCapteur de température d'air, court-circuit à la masse",
			"P0113\tCapteur de température d'air, circuit ouvert ou court-circuit à la batterie", "P0115\tDysfonctionnement du circuit du capteur de température du liquide de refroidissement", "P0116\tDysfonctionnement du circuit du capteur de température du liquide de refroidissement (cylindre 1)", "P0117\tCapteur de température du liquide de refroidissement, signal trop fort ou court-circuit à la batterie", "P0118\tCapteur de température du liquide de refroidissement, signal trop faible (circuit ouvert ou court-circuit à la masse)", "3P0118\tCapteur de température du liquide de refroidissement, court-circuit", "P0119\tTension élevée du capteur de liquide de refroidissement moteur", "3P0119\tCapteur de température du liquide de refroidissement, circuit ouvert", "P0120\tDysfonctionnement du circuit du capteur de position des papillons", "P0122\tCapteur de position de papillon, signal trop faible (circuit ouvert ou court-circuit à la masse)",
			"3P0122\tCapteur de position de papillon, court-circuit", "P0123\tCapteur de position de papillon, signal trop fort ou court-circuit à la batterie", "3P0123\tCapteur de position de papillon, circuit ouvert", "P0130\tSonde lambda, dysfonctionnement du circuit", "P0131\tSonde lambda, court-circuit à la masse", "P0132\tSonde lambda, signal trop fort", "P0133\tSonde lambda, court-circuit à la batterie", "P0135\tSonde Lambda, dysfonctionnement du circuit de chauffe", "P0150\tSonde lambda 2, dysfonctionnement du circuit", "P0170\tDysfonctionnement de la correction en carburant (rétroaction sonde lambda)",
			"P0201\tInjecteur 1, dysfonctionnement du circuit", "1P0201\tInjecteur 2, dysfonctionnement du circuit", "P0202\tInjecteur 2, dysfonctionnement du circuit", "1P0202\tInjecteur 1, dysfonctionnement du circuit", "P0203\tInjecteur 3, dysfonctionnement du circuit", "P0204\tInjecteur 4, dysfonctionnement du circuit", "P0222\tCapteur de position du papillon 2, signal trop faible (circuit ouvert ou court-circuit à la masse)", "P0223\tCapteur de position du papillon 2, signal trop fort ou court-circuit à la batterie", "P0227\tCapteur de position du papillon 2, signal trop faible (circuit ouvert ou court-circuit à la masse)", "2P0227\tCapteur de position de la poignée d'accélérateur, signal trop faible (circuit ouvert ou court-circuit à la masse)",
			"P0228\tCapteur de position du papillon 2, signal trop fort ou court-circuit à la batterie", "2P0228\tCapteur de position de la poignée d'accélérateur, signal trop fort ou court-circuit à la batterie", "P0230\tDéfaut du relais de la pompe à carburant", "P0335\tCapteur de position du vilebrequin, dysfonctionnement du circuit", "P0340\tDysfonctionnement du capteur de l'arbre à cames", "P0341\tDéfaut du circuit du capteur de l'arbre à cames", "P0351\tBobine d'allumage 1, dysfonctionnement du circuit", "1P0351\tBobine d'allumage 2, dysfonctionnement du circuit", "P0352\tBobine d'allumage 2, dysfonctionnement du circuit", "1P0352\tBobine d'allumage 1, dysfonctionnement du circuit",
			"P0353\tBobine d'allumage 3, dysfonctionnement du circuit", "P0354\tBobine d'allumage 4, dysfonctionnement du circuit", "P0413\tElectrovanne d'injection d'air secondaire, circuit ouvert ou court-circuit à la masse", "P0414\tElectrovanne d'injection d'air secondaire, court-circuit à la batterie", "P0443\tDysfonctionnement du circuit de l'électrovanne de purge", "P0444\tElectrovanne de purge, circuit ouvert ou court-circuit à la masse", "P0445\tElectrovanne de purge, court-circuit à la batterie", "P0460\tDysfonctionnement du capteur de niveau du réservoir de carburant", "P0462\tCapteur de niveau de carburant, impédance d'entrée faible", "P0463\tCapteur de niveau de carburant, impédance d'entrée élevée",
			"P0500\tDysfonctionnement du capteur de vitesse du véhicule", "P0505\tDysfonctionnement du système de régulation du ralenti", "P0510\tDysfonctionnement du commutateur d'annulation du régulateur de vitesse sur la poignée d’accélérateur", "P0560\tAlimentation de l'ECM, dysfonctionnement du circuit", "P0562\tTension de circuit basse", "P0563\tTension de circuit élevée", "P0571\tDysfonctionnement de commutateur de frein 1", "P0603\tDéfaut EEPROM", "P0616\tRelais du démarreur, circuit ouvert ou court-circuit à la masse", "P0617\tRelais du démarreur, court-circuit à la batterie",
			"P0630\tErreur EEPROM", "P0638\tServomoteur du papillon 2, dysfonctionnement du circuit", "P0654\tRégime moteur, dysfonctionnement du circuit", "P0656\tGauge de carburant, dysfonctionnement du circuit", "P1030\tSonde Lambda, dysfonctionnement du circuit", "P0705\tCapteur de position de rapport de boite, dysfonctionnement du circuit", "P1078\tCapteur de position de valve d'échappement, signal trop faible ou court-circuit à la masse", "P1079\tCapteur de position de valve d'échappement, signal trop fort ou court-circuit à la batterie", "P1080\tCapteur de position de valve d'échappement, dysfonctionnement du circuit", "P1105\tCapteur de pression atmosphérique, problème durite",
			"P1106\tCapteur de pression atmosphérique 2, problème durite", "P1107\tCapteur de pression atmosphérique, signal trop faible ou court-circuit à la masse", "P1108\tCapteur de pression atmosphérique, circuit ouvert ou signal trop fort", "P1111\tTuyaux de capteur de pression absolue au collecteur intervertis", "P1115\tGauge de température de liquide de refroidissement, dysfonctionnement du circuit", "P1116\tIndicateur de température du liquide de refroidissement, circuit ouvert ou court-circuit à la masse", "P1117\tIndicateur de température du liquide de refroidissement, court-circuit à la batterie ou température excessive", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tAntipatinage désactivé à cause d'un dysfonctionnement de l'ABS", "P1171\tEnrichissement maximum (rétroaction sonde lambda)", "P1172\tAppauvrissement maximum (rétroaction sonde lambda)", "P1178\tAdaptation maximum du volet d'air (rétroaction sonde lambda)", "P1179\tAdaptation minimum du volet d'air (rétroaction sonde lambda)", "P1201\tInjecteur 1, circuit ouvert ou court-circuit à la masse", "1P1201\tInjecteur 2, circuit ouvert ou court-circuit à la masse", "P1202\tInjecteur 2, circuit ouvert ou court-circuit à la masse", "1P1202\tInjecteur 1, circuit ouvert ou court-circuit à la masse", "P1203\tInjecteur 3, circuit ouvert ou court-circuit à la masse",
			"P1204\tInjecteur 4, circuit ouvert ou court-circuit à la masse", "P1205\tInjecteur 1, court-circuit à la batterie ou température excessive", "1P1205\tInjecteur 2, court-circuit à la batterie ou température excessive", "P1206\tInjecteur 2, court-circuit à la batterie ou température excessive", "1P1206\tInjecteur 1, court-circuit à la batterie ou température excessive", "P1207\tInjecteur 3, court-circuit à la batterie ou température excessive", "P1208\tInjecteur 4, court-circuit à la batterie ou température excessive", "P1231\tRelais pompe à essence, circuit ouvert ou court-circuit à la masse", "P1232\tRelais pompe à essence, court-circuit à la batterie", "P1335\tModèle de séquence incorrect du capteur de vilebrequin",
			"P1340\tInterférence électrique", "P1341\tModèle de séquence incorrect du capteur de l'arbre à cames", "P1351\tBobine d'allumage 1, circuit ouvert ou court-circuit à la masse", "1P1351\tBobine d'allumage 2, circuit ouvert ou court-circuit à la masse", "P1352\tBobine d'allumage 2, circuit ouvert ou court-circuit à la masse", "1P1352\tBobine d'allumage 1, circuit ouvert ou court-circuit à la masse", "P1353\tBobine d'allumage 3, circuit ouvert ou court-circuit à la masse", "P1354\tBobine d'allumage 4, circuit ouvert ou court-circuit à la masse", "P1355\tBobine d'allumage 1, température excessive ou court-circuit à la batterie", "1P1355\tBobine d'allumage 2, température excessive ou court-circuit à la batterie",
			"P1356\tBobine d'allumage 2, température excessive ou court-circuit à la batterie", "1P1356\tBobine d'allumage 1, température excessive ou court-circuit à la batterie", "P1357\tBobine d'allumage 3, température excessive ou court-circuit à la batterie", "P1358\tBobine d'allumage 4, température excessive ou court-circuit à la batterie", "P1385\tCompte-tours, dysfonctionnement du circuit", "P1386\tCompte-tours, circuit ouvert ou court-circuit à la masse", "P1387\tCompte-tours, température excessive ou court-circuit à la batterie", "P1500\tCapteur de vitesse, dysfonctionnement du circuit", "P1501\tCircuit de commande du compteur de vitesse, circuit ouvert ou court-circuit à la masse", "1P1501\tCapteur de température d'air, court-circuit à la masse",
			"3P1501\tCapteur de température d'air, court-circuit", "P1502\tCircuit de commande du compteur de vitesse, température excessive ou court-circuit à la batterie", "1P1502\tCapteur de température d'air, circuit ouvert ou court-circuit à la batterie", "3P1502\tCapteur de température d'air, circuit ouvert", "P1508\tNon correspondance d'ECM antidémarrage", "P1520\tL'ABS ne correspond pas", "P1521\tPerte de communication avec l'ABS", "P1530\tCapteur à effet hall du papillon, dysfonctionnement du circuit", "P1534\tDysfonctionnement du circuit de capteur de niveau d'huile moteur", "P1551\tVentilateur de radiateur d'eau, dysfonctionnement du circuit",
			"P1552\tVentilateur de radiateur d'eau, circuit ouvert ou court-circuit à la masse", "P1553\tVentilateur de radiateur d'eau, court-circuit à la batterie", "P1560\tDéfaut du circuit d'alimentation des capteurs", "P1571\tDysfonctionnement de commutateur de frein 2", "P1574\tRégulateur de vitesse désactivé à cause d'un autre dysfonctionnement", "P1575\tRégulateur de vitesse désactivé jusqu'à ce que la séquence de pression de bouton est terminée", "P1576\tErreur de corrélation de commutateur 1 de frein avec commutateur 2 de frein", "P1577\tErreur de corrélation de commutateur 2 de frein avec commutateur 1 de frein", "P1590\tContacteur béquille latérale, signal trop faible ou court-circuit à la masse", "P1600\tDéfaillance du système MIL",
			"P1601\tMIL, circuit ouvert ou court-circuit à la masse", "P1602\tMIL, court-circuit à la batterie", "P1604\tEffraction ECM détectée - renvoi à Triumph", "P1605\tECU bloqué par la fonction blocage de mise au point", "P1606\tErreur interne de l'ECM", "P1607\tErreur interne ECM de l'accélérateur électronique", "P1608\tErreur interne ECM de l'accélérateur électronique", "P1610\tCapteur niveau bas de carburant, dysfonctionnement du circuit", "P1611\tTémoin de niveau de carburant, circuit ouvert ou court-circuit à la masse", "P1612\tTémoin de niveau de carburant, court-circuit à la batterie",
			"P1614\tID instruments incompatible", "P1616\tRelais de commande d'accessoire, court-circuit à la masse ou circuit ouvert", "P1617\tRelais de commande d'accessoire, court-circuit à la batterie", "P1619\tRelais de phare, court-circuit à la masse ou circuit ouvert", "P1620\tRelais de phare – court-circuit à la batterie", "P1621\tGauge de carburant, circuit ouvert ou court-circuit à la masse", "P1622\tGauge de carburant, court-circuit à la batterie", "P1628\tPompe à essence, circuit ouvert ou court-circuit à la masse", "P1629\tPompe à essence, court-circuit à la batterie", "P1631\tCapteur détection de chute, signal trop faible ou court-circuit à la masse",
			"P1632\tCapteur détection de chute, signal trop fort ou circuit ouvert", "P1633\tDysfonctionnement du système du pare-brise", "P1650\tPerte de communication avec le RCU (ou dysfonctionnement de l'antidémarrage)", "P1659\tCapteur d'allumage, dysfonctionnement du circuit", "P1670\tVolet d'admission d'air, circuit ouvert ou court-circuit à la masse", "P1671\tVolet d'admission d'air, court-circuit à la batterie", "P1685\tRelais principal du boitier de gestion moteur, dysfonctionnement du circuit", "P1687\tCapteur de pression d'admission 2, court-circuit à la masse", "P1688\tCapteur de pression d'admission 2, circuit ouvert ou court-circuit à la batterie", "P1690\tDéfaut de communication du Bus CAN",
			"P1695\tPerte de communication avec le tableau de bord", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tCapteur de tension batterie, dysfonctionnement du circuit", "P2118\tActionneur du papillon, dysfonctionnement du circuit", "P2119\tDéfaut de positionnement du papillon", "P2183\tDysfonctionnement du circuit du capteur de température du liquide de refroidissement (cylindre 2)", "L0001\tAlerte pile de capteur de roue avant", "L0002\tAlerte pile de capteur de roue arrière", "L0003\tAlerte défaut de capteur de roue avant",
			"L0004\tAlerte défaut de capteur de roue arrière", "L0005\tPerte de communication avec le capteur de roue avant", "L0006\tPerte de communication avec le capteur de roue arrière", "L0007\tDéfaut de RCU", "L0008\tClé non valide : Echec d'authentification de clé"
		},
		{
			"P0031\tHeizelement Lambda-Sonde, Leiterunterbrechung/Erdschluss", "P0032\tHeizelement Lambda-Sonde: Kurzschluss zu Batterie", "P0051\tHeizelement Lambda-Sonde 2, Leiterunterbrechung/Erdschluss", "P0052\tHeizelement Lambda-Sonde: Kurzschluss gegen Batterie", "P0078\tFehlfunktion Stromkreis Abgassteuerventil-Stellglied", "P0105\tFehlfunktion Stromkreis Umgebungsluftdrucksensor", "P0107\tSaugrohr-Absolutdruck-Sensor, niedrige Eingangsspannung", "P0108\tSaugrohr-Absolutdruck-Sensor, hohe Eingangsspannung", "P0110\tSystemfehler Ansauglufttemperatursensor", "P0112\tAnsaugluft-Temperatur zu hoch",
			"P0113\tAnsaugluft-Temperatur zu niedrig", "P0115\tSystemfehler Kühlmitteltemperatursensor", "P0116\tSystemfehler Kühlmitteltemperatursensor (zylinder 1)", "P0117\tMotorkühlmitteltemperatur, hohe Eingangsspannung", "P0118\tMotorkühlmitteltemperatur, niedrige Eingangsspannung", "3P0118\tMotorkühlmitteltemperatur, Kurzschluss", "P0119\tMotor Kühlmittel Temperatursensor, Spannungssignal zu hoch", "3P0119\tMotorkühlmitteltemperatur, Leiterunterbrechung", "P0120\tSystemfehler Dosselklappensensor", "P0122\tDrosselklappensensor, niedrige Eingangsspannung",
			"3P0122\tDrosselklappensensor, Kurzschluss", "P0123\tDrosselklappensensor, hohe Eingangsspannung", "3P0123\tDrosselklappensensor, Leiterunterbrechung", "P0130\tFehlfunktion Stromkreis Lambda Sonde", "P0131\tLambda-Sonde, Kurzschluss gegen Masse", "P0132\tLambda-Sonde Signal zu hoch", "P0133\tLambda-Sonde, Kurzschluss gegen Batterie", "P0135\tHeizelement Lambda-Sonde, Fehlfunktion Stromkreis", "P0150\tFehlfunktion Stromkreis Lambda Sonde 2", "P0170\tFehlfunktion Lambda Rückmeldung Kraftstoff Trimm",
			"P0201\tFehlfunktion Stromkreis Einspritzventil 1", "1P0201\tFehlfunktion Stromkreis Einspritzventil 2", "P0202\tFehlfunktion Stromkreis Einspritzventil 2", "1P0202\tFehlfunktion Stromkreis Einspritzventil 1", "P0203\tFehlfunktion Stromkreis Einspritzventil 3", "P0204\tFehlfunktion Stromkreis Einspritzventil 4", "P0222\tSekundäres Drosselklappensystem, niedrige Spannung", "P0223\tSekundäres Drosselklappensystem, hohe Spannung", "P0227\tSekundäres Drosselklappensystem, niedrige Spannung", "2P0227\tDrosselklappen Positionssensor, Spannungssignal zu niedrig (offener Stromkreis oder Kurzschluss an Masse)",
			"P0228\tSekundäres Drosselklappensystem, hohe Spannung", "2P0228\tDrosselklappen Positionssensor, Spannungssignal zu hoch (Kurzschluss der Batterie)", "P0230\tSystemfehler Kraftstoffpumpenrelais", "P0335\tFehlfunktion Stromkreis Kurbelwellensensor", "P0340\tSystemfehler Nockenwellen-Sensor", "P0341\tNockenwellen-Sensor Kabelfehler", "P0351\tFehlfunktion Stromkreis Zündspule 1", "1P0351\tFehlfunktion Stromkreis Zündspule 2", "P0352\tFehlfunktion Stromkreis Zündspule 2", "1P0352\tFehlfunktion Stromkreis Zündspule 1",
			"P0353\tFehlfunktion Stromkreis Zündspule 3", "P0354\tFehlfunktion Stromkreis Zündspule 4", "P0413\tSekundärluftsystem: Kurzschluss gegen Masse oder Leiterunterbrechung", "P0414\tSekundärluftsystem: Kurzschluss zu Batterie", "P0443\tSystemfehler Spülventil", "P0444\tSpülventilsystem: Kurzschluss gegen Masse oder Leiterunterbrechung", "P0445\tSpülventilsystem: Kurzschluss zu Batterie", "P0460\tFehlfunktion Stromkreis Kraftstoffstand-Sensor", "P0462\tKraftstoffstand-Sensor Stromkreis niedrige Spannung", "P0463\tKraftstoffstand-Sensor Stromkreis hohe Spannung",
			"P0500\tFehlfunktion Fahrzeuggeschwindigkeitssensor", "P0505\tFehlfunktion Leerlaufdrehzahlanzeige", "P0510\tDrehgriff, Tempomatausschalter, Fehlfunktion", "P0560\tSystemspannung, Fehlfunktion Batteriestromkreis", "P0562\tSystemspannung zu niedrig, Kabel-Batterei-Lichtmaschinen defekt", "P0563\tSystemspannung zu hoch, Lichtmaschinendefekt", "P0571\tBremsschalter 1, Fehlfunktion", "P0603\tEEPROM-Fehler", "P0616\tStarterrelais: Kurzschluss gegen Masse oder Leiterunterbrechung", "P0617\tStarterrelais: Kurzschluss zu Batterie",
			"P0630\tEEPROM-Fehler", "P0638\tFehlfunktion Sek. Drosselklappenstromkreis", "P0654\tFehlfunktion Stromkreis Drehzahlmesser", "P0656\tFehlfunktion Stromkreis Tankuhr", "P0705\tFehlfunktion Stromkreis Gangstellungssensor", "P1030\tLambda-Sonde, Fehlfunktion Stromkreis", "P1078\tSellungsssensor Abgassteuerventil-Stellgied, niedrige Eingangsspannung (Kurzschluss zu Masse)", "P1079\tSellungsssensor Abgassteuerventil-Stellgied, hohe Eingangsspannung (Kurzschluss der Batterie)", "P1080\tFehlfunktion Machnismus Abgassteuerventil-Stellglied", "P1105\tSaugrohr-Absolutdruck-Sensor, Fehlfunktion Rohr",
			"P1106\tSaugrohr-Absolutdruck-Sensor 2, Fehlfunktion Rohr", "P1107\tStromkreis Umgebungs-Luftdrucksensor, niedrige Eingangsspannung", "P1108\tStromkreis Umgebungs-Luftdrucksensor, hohe Eingangsspannung", "P1111\tSaugrohr-Absolutdruck-Sensoren, Rohre umgedreht", "P1115\tFehlfunktion Stromkreis Kühlmitteltemperaturanzeige", "P1116\tKühlmittel Temperaturanzeige, Stromkreis unterbrochen Kurzschluss zu Masse", "P1117\tKühlmittel Temperaturanzeige, Kurzschluss zu Batterie", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tAntischlupfregelung wegen ABS-Fehlfunktion nicht verfügbar", "P1171\tLambda Rückmeldung max Anreicherung", "P1172\tLambda Rückmeldung min Abmagerung", "P1178\tLambda Rückmeldung erreichte maximum Luftleckanpassung", "P1179\tLambda Rückmeldung erreichte minimum Luftleckanpassung", "P1201\tLeitungsunterbrechung/Erdschluss Einspritzventil 1", "1P1201\tLeitungsunterbrechung/Erdschluss Einspritzventil 2", "P1202\tLeitungsunterbrechung/Erdschluss Einspritzventil 2", "1P1202\tLeitungsunterbrechung/Erdschluss Einspritzventil 1", "P1203\tLeitungsunterbrechung/Erdschluss Einspritzventil 3",
			"P1204\tLeitungsunterbrechung/Erdschluss Einspritzventil 4", "P1205\tKurzschluss gegen Batterie+  Einspritzventil 1", "1P1205\tKurzschluss gegen Batterie+  Einspritzventil 2", "P1206\tKurzschluss gegen Batterie + Einspritzventil 2", "1P1206\tKurzschluss gegen Batterie + Einspritzventil 1", "P1207\tKurzschluss gegen Batterie + Einspritzventil 3", "P1208\tKurzschluss gegen Batterie + Einspritzventil 4", "P1231\tKraftstoffpumpe: Kurzschluss gegen Masse oder Leiterunterbrechung", "P1232\tRelais Kraftstoffpumpe: Kurzschluss zu Batterie", "P1335\tKurbelwellensensor Zahnrad/Kabelfehler",
			"P1340\tElektrisches Störsignal", "P1341\tNockenwellen-Sensor defktes Nockenwellenzahnrad", "P1351\tUnterbrechung oder Kurzschluss Zündspule 1", "1P1351\tUnterbrechung oder Kurzschluss Zündspule 2", "P1352\tUnterbrechung oder Kurzschluss Zündspule 2", "1P1352\tUnterbrechung oder Kurzschluss Zündspule 1", "P1353\tUnterbrechung oder Kurzschluss Zündspule 3", "P1354\tUnterbrechung oder Kurzschluss Zündspule 4", "P1355\tKurzschluss gegen Batterie Zündspule 1", "1P1355\tKurzschluss gegen Batterie Zündspule 2",
			"P1356\tKurzschluss gegen Batterie Zündspule 2", "1P1356\tKurzschluss gegen Batterie Zündspule 1", "P1357\tKurzschluss gegen Batterie Zündspule 3", "P1358\tKurzschluss gegen Batterie Zündspule 4", "P1385\tSystemfehler Drehzahlmesser", "P1386\tDrehzahlmesser, Leiterunterbrechung oder Kurzschluss gegen Masse", "P1387\tDrehzahlmesser, Kurzschluss zu Batterie oder Temperatur zu hoch", "P1500\tFahrzeuggeschwindigkeit, Fehlfunktion im Ausgangsstromkreis", "P1501\tTachometerantrieb, Leiterunterbrechung oder Erdschluss", "1P1501\tAnsauglufttemperatur sensor, kurzschluss zu Masse",
			"3P1501\tAnsauglufttemperatur sensor, kurzschluss", "P1502\tTachometerantrieb, Kurzschluss gegen Vbatt oder Überhitzung", "1P1502\tAnsauglufttemperatur sensor, offener Stromkreis oder kurzschluss der Batterie", "3P1502\tAnsauglufttemperatur sensor, Leiterunterbrechung", "P1508\tECM der Wegfahrsperre ohne Bindung", "P1520\tABS ohne Bindung", "P1521\tVerbindung zum ABS unterbrochen", "P1530\tHall-Effekt-Sensor der Drosselklappe, Störung im Schaltkreis", "P1534\tStromkreis Motorölstandsensor, Fehlfunktion", "P1551\tSystemfehler Kühlerventilator",
			"P1552\tKurzschluss/Leiterunterbrchung Kühlerventilator", "P1553\tKühlerventilator: Kurzschluss zu Batterie/Überhitzung", "P1560\tKabelfehler Motorsteuergerät", "P1571\tBremsschalter 2, Fehlfunktion", "P1574\tTempomat wegen sonstiger Fehlfunktion nicht verfügbar", "P1575\tTempomat bis zum Abschluss der Tastensequenz deaktiviert", "P1576\tBremsschalter 1, Korrelationsfehler mit Bremsschalter 2", "P1577\tBremsschalter 2, Korrelationsfehler mit Bremsschalter 1", "P1590\tSeitenständerschalter, niedrige Spannung oder Kurzschluss gegen Masse", "P1600\tMIL, Systemfehler",
			"P1601\tMIL, Stromkreis unterbrochen oder Kurzschluss gegen Masse", "P1602\tMIL, Kurzschluss gegen Batterie", "P1604\tECM-Manipulation festgestellt - an Triumph zurücksenden", "P1605\tECU durch Funktion Abstimmung sperren gesperrt", "P1606\tECM interner Fehler", "P1607\tECM, E-Gas, interner Fehler", "P1608\tECM, E-Gas, interner Fehler", "P1610\tFehlfunktion Ausgangsstromkreis Kraftstoffwarnung", "P1611\tKraftstoff Reservelampe, Kurzschluss gegen Masse oder Leiterunterbrechung", "P1612\tKraftstoff Reservelampe, Kurzschluss zu Batterie",
			"P1614\tInstrumenten-ID nicht kompatibel", "P1616\tZubehör-Steuerrelais, Kurzschluss gegen Masse oder Leiterunterbrechung", "P1617\tZubehör-Steuerrelais, Kurzschluss zu Batterie", "P1619\tScheinwerferrelais, Kurzschluss gegen Masse oder Leiterunterbrechung ", "P1620\tScheinwerferrelais, Kurzschluss zu Batterie", "P1621\tKraftstoffanzeige: Kurzschluss gegen Masse oder Leiterunterbrechung", "P1622\tKraftstoffanzeige: Kurzschluss gegen Batterie", "P1628\tKraftstoffpumpe: Kurzschluss gegen Masse oder Leiterunterbrechung", "P1629\tRelais Kraftstoffpumpe: Kurzschluss zu Batterie", "P1631\tStromkreis Sturzerkennungssensor, niedrige Spannung",
			"P1632\tStromkreis Sturzerkennungssensor, hohe Spannung", "P1633\tWindschutzscheibensystem, Fehlfunktion", "P1650\tVerbindung zum RCU unterbrochen (oder fehlfunktion der Wegfahrsperre)", "P1659\tFehlfunktion EMS-Zündspannung", "P1670\tStromkreis Einlassklappen-Magnetventil Erdschluss oder Leiterunterbrechung", "P1671\tStromkreis Einlassklappen-Magnetventil Kurzschluss gegen Vbatt", "P1685\tFehlfunktion Stromkreis EMS-Hauptrelais", "P1687\tSaugrohr-Absolutdruck-Sensor 2, niedrige Eingangsspannung", "P1688\tSaugrohr-Absolutdruck-Sensor 2, hohe Eingangsspannung", "P1690\tCAN-Komunikationsfehler",
			"P1695\tVerbindung zur Instrumententafel unterbrochen", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tFehlfunktion Sensorspeisestromkreis (5V Sensorversorgungsspannung)", "P2118\tDrosselklappenmotor, Fehlfunktion", "P2119\tFehlerhafte Positionierung der Drosselklappe", "P2183\tSystemfehler Kühlmitteltemperatursensor (zylinder 2)", "L0001\tBatteriewarnung Sensor Vorderradeinheit", "L0002\tBatteriewarnung Sensor Hinterradeinheit", "L0003\tFehlerwarnung Sensor Vorderradeinheit",
			"L0004\tFehlerwarnung Sensor Hinterradeinheit", "L0005\tSensor Vorderradeinheit, Verbindungsverlust", "L0006\tSensor Hinterradeinheit, Verbindungsverlust", "L0007\tRCU-Fehler", "L0008\tUngültiger Schlüssel: Schlüsselauthentifizierung nicht erfolgreich"
		},
		{
			"P0031\tCircuito aperto o cortocircuito a massa circuito riscaldatore sensore ossigeno", "P0032\tCortocircuito su batteria del riscaldatore sensore ossigeno", "P0051\tCircuito aperto o cortocircuito a massa nel circuito riscaldatore sensore ossigeno 2", "P0052\tCortocircuito su batteria del riscaldatore sensore ossigeno 2", "P0078\tCircuito motorino a passo farfalla scarico, circuito aperto o in cortocircuito a massa", "P0105\tMalfunzionamento circuito sensore pressione barometrica", "P0107\tBassa tensione sensore pressione assoluta collettore", "P0108\tAlta tensione sensore pressione assoluta collettore", "P0110\tMalfunzionamento circuito temperatura aria aspirata", "P0112\tTemperatura aria aspirata troppo alta",
			"P0113\tTemperatura aria aspirata troppo bassa", "P0115\tMalfunzionamento circuito temperatura liquido refrigerante motore", "P0116\tMalfunzionamento circuito temperatura liquido refrigerante motore (cilindro 1)", "P0117\tTemperatura liquido refrigerante motore troppo bassa", "P0118\tTemperatura liquido refrigerante motore troppo alta", "3P0118\tTemperatura liquido refrigerante motore, cortocircuito", "P0119\tIngresso alto circuito sensore liquido refrigerante motore", "3P0119\tTemperatura liquido refrigerante motore, circuito aperto", "P0120\tMalfunzionamento circuito sensore posizione farfalla", "P0122\tSensore posizione farfalla basso",
			"3P0122\tSensore posizione farfalla, cortocircuito", "P0123\tSensore posizione farfalla alto", "3P0123\tSensore posizione farfalla, circuito aperto", "P0130\tMalfunzionamento circuito riscaldatore sensore ossigeno", "P0131\tMassa sensore ossigeno troppo alta", "P0132\tSegnale sensore ossigeno troppo alto", "P0133\tCortocircuito su batteria del riscaldatore sensore ossigeno", "P0135\tMalfunzionamento riscaldatore sensore ossigeno", "P0150\tMalfunzionamento circuito riscaldatore sensore ossigeno 2", "P0170\tTerugkoppeling lambdasonde brandstofafregeling defect",
			"P0201\tInjector 1, circuit defect", "1P0201\tInjector 2, circuit defect", "P0202\tInjector 2, circuit defect", "1P0202\tInjector 1, circuit defect", "P0203\tInjector 3, circuit defect", "P0204\tInjector 4, circuit defect", "P0222\tBassa tensione sistema sensore posizione seconda farfalla", "P0223\tAlta tensione sensore posizione seconda farfalla", "P0227\tBassa tensione sistema sensore posizione seconda farfalla", "2P0227\tSensore posizione manopola acceleratore, segnale troppo debole (circuito aperto o in corto-circuito)",
			"P0228\tAlta tensione sensore posizione seconda farfalla", "2P0228\tSensore posizione manopola acceleratore, segnale troppo forte o batteria in corto circuito", "P0230\tRelè pompa di alimentazione guasto", "P0335\tMalfunzionamento circuito sensore albero motore", "P0340\tMalfunzionamento sensore albero a camme", "P0341\tCircuito sensore albero a camme guasto", "P0351\tMalfunzionamento bobina di accensione 1", "1P0351\tMalfunzionamento bobina di accensione 2", "P0352\tMalfunzionamento bobina di accensione 2", "1P0352\tMalfunzionamento bobina di accensione 1",
			"P0353\tMalfunzionamento bobina di accensione 3", "P0354\tMalfunzionamento bobina di accensione 4", "P0413\tCircuito aperto iniezione aria secondaria", "P0414\tCortocircuito iniezione aria secondaria", "P0443\tMalfunzionamento circuito valvola di spurgo", "P0444\tCircuito aperto o cortocircuito a massa valvola di spurgo", "P0445\tCortocircuito valvola di spurgo su batteria veicolo o sovratemperatura", "P0460\tMalfunzionamento circuito sensore livello carburante", "P0462\tIngresso basso circuito sensore carburante", "P0463\tIngresso alto circuito sensore carburante",
			"P0500\tMalfunzionamento sensore velocit‡ di avanzamento", "P0505\tMalfunzionamento impianto valvola regolazione aria al minimo", "P0510\tMalfunzionamento interruttore disattivazione controllo velocità di crociera su manopola comando acceleratore", "P0560\tTensione sistema - malfunzionamento circuito batteria", "P0562\tTensione sistema bassa", "P0563\tTensione sistema alta", "P0571\tMalfunzionamento interruttore 1 freno", "P0603\tErrore EEPROM", "P0616\tCortocircuito a massa o circuito aperto relè di avviamento", "P0617\tCortocircuito relË di avviamento su batteria",
			"P0630\tEEPROM-Error", "P0638\tMalfunzionamento circuito seconda farfalla", "P0654\tMalfunzionamento circuito tachimetro", "P0656\tMalfunzionamento circuito indicatore livello carburante", "P0705\tMalfunzionamento circuito sensore posizione marcia", "P1030\tMalfunzionamento circuito sensore ossigeno", "P1078\tSensore posizione scarico - circuito aperto o cortocircuito a massa ", "P1079\tSensore posizione scarico - cortocircuito su batteria veicolo", "P1080\tMeccanismo controllo attuatore scarico guasto", "P1105\tMalfunzionamento tubazione sensore pressione assoluta collettore",
			"P1106\tMalfunzionamento tubazione sensore pressione assoluta collettore 2", "P1107\tBassa tensione circuito sensore pressione aria ambiente", "P1108\tAlta tensione circuito sensore pressione aria ambiente", "P1111\tTubazioni sensore pressione assoluta collettore invertite", "P1115\tMalfunzionamento circuito indicatore temperatura liquido refrigerante ", "P1116\tCortocircuito o circuito aperto indicatore temperatura liquido refrigerante", "P1117\tIndicatore temperatura liquido refrigerante in cortocircuito su batteria veicolo / sovratemperatura", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tControllo velocità di crociera non attivabile a causa del malfunzionamento dell'ABS", "P1171\tArricchimento massimo in base a feedback Lambda", "P1172\tImpoverimento massimo in base a feedback Lambda", "P1178\tIl feedback del sensore Lambda ha raggiunto l''adattamento massimo dovuto al trafilamento di aria", "P1179\tIl feedback del sensore Lambda ha raggiunto l''adattamento minimo dovuto al trafilamento di aria", "P1201\tCircuito aperto o cortocircuito a massa iniettore 1", "1P1201\tCircuito aperto o cortocircuito a massa iniettore 2", "P1202\tCircuito aperto o cortocircuito a massa iniettore 2", "1P1202\tCircuito aperto o cortocircuito a massa iniettore 1", "P1203\tCircuito aperto o cortocircuito a massa iniettore 3",
			"P1204\tCircuito aperto o cortocircuito a massa iniettore 4", "P1205\tCortocircuito iniettore 1 su batteria veicolo o sovratemperatura", "1P1205\tCortocircuito iniettore 2 su batteria veicolo o sovratemperatura", "P1206\tCortocircuito iniettore 2 su batteria veicolo o sovratemperatura", "1P1206\tCortocircuito iniettore 1 su batteria veicolo o sovratemperatura", "P1207\tCortocircuito iniettore 3 su batteria veicolo o sovratemperatura", "P1208\tCortocircuito iniettore 4 su batteria veicolo o sovratemperatura", "P1231\tCircuito aperto relè pompa di alimentazione", "P1232\tCortocircuito relè pompa di alimentazione", "P1335\tSchema sequenza errata sensore albero motore",
			"P1340\tDisturbi elettrici eccessivi su sensore albero a camme", "P1341\tSchema sequenza errata sensore albero a camme", "P1351\tCircuito aperto o cortocircuito a massa bobina di accensione 1", "1P1351\tCircuito aperto o cortocircuito a massa bobina di accensione 2", "P1352\tCircuito aperto o cortocircuito a massa bobina di accensione 2", "1P1352\tCircuito aperto o cortocircuito a massa bobina di accensione 1", "P1353\tCircuito aperto o cortocircuito a massa bobina di accensione 3", "P1354\tCircuito aperto o cortocircuito a massa bobina di accensione 4", "P1355\tCortocircuito bobina di accensione 1 su batteria veicolo o sovratemperatura", "1P1355\tCortocircuito bobina di accensione 2 su batteria veicolo o sovratemperatura",
			"P1356\tCortocircuito bobina di accensione 2 su batteria veicolo o sovratemperatura", "1P1356\tCortocircuito bobina di accensione 1 su batteria veicolo o sovratemperatura", "P1357\tCortocircuito bobina di accensione 3 su batteria veicolo o sovratemperatura", "P1358\tCortocircuito bobina di accensione 4 su batteria veicolo o sovratemperatura", "P1385\tMalfunzionamento circuito cronometro", "P1386\tCronometro in cortocircuito o circuito aperto", "P1387\tCronometro in cortocircuito su batteria veicolo o sovratemperatura", "P1500\tMalfunzionamento circuito uscita velocità di avanzamento", "P1501\tCircuito aperto o cortocircuito a massa comando tachimetro", "1P1501\tTemperatura aria aspirata sensore, cortocircuito a massa",
			"3P1501\tTemperatura aria aspirata sensore, cortocircuito", "P1502\tCortocircuito su batteria veicolo o sovratemperatura comando tachimetro", "1P1502\tTemperatura aria aspirata sensore, circuito aperto o cortocircuito su batteria", "3P1502\tTemperatura aria aspirata sensore, circuito aperto", "P1508\tECM immobilizzatore non accoppiata", "P1520\tABS non accoppiato", "P1521\tComunicazione con ABS persa", "P1530\tSensore ad effetto Hall, malfunzionamento del circuito", "P1534\tMalfunzionamento circuito sensore livello olio motore", "P1551\tMalfunzionamento circuito del elettroventola",
			"P1552\tCircuito aperto o cortocircuito del elettroventola", "P1553\tCortocircuito su batteria veicolo o sovratemperatura elettroventola", "P1560\tCircuito tensione di alimentazione sensore guasto", "P1571\tMalfunzionamento interruttore 2 freno", "P1574\tControllo velocità di crociera non attivabile a causa di altro malfunzionamento", "P1575\tControllo velocità di crociera disattivato fino al completamento della sequenza di pressione dei pulsanti", "P1576\tErrore di correlazione tra interruttore 1 e interruttore 2 freno", "P1577\tErrore di correlazione tra interruttore 2 e interruttore 1 freno", "P1590\tBassa tensione circuito di sensore cavalletto laterale", "P1600\tMalfunzionamento circuito spia MIL",
			"P1601\tCircuito aperto o cortocircuito a massa spia MIL", "P1602\tCortocircuito su batteria veicolo spia MIL", "P1604\tÈ stata rilevata la manomissione dell'ECM - rispedire a Triumph", "P1605\tECU bloccata da funzione di blocco messa a punto", "P1606\tErrore interno ECM", "P1607\tErrore interno dell'ECM dell'acceleratore elettronico", "P1608\tErrore interno dell'ECM dell'acceleratore elettronico", "P1610\tMalfunzionamento circuito uscita basso livello carburante", "P1611\tCortocircuito a massa o circuito aperto spia indicatore basso livello carburante", "P1612\tCortocircuito su batteria veicolo spia indicatore basso livello carburante",
			"P1614\tID strumentazione incompatibile", "P1616\tRelè comando accessori in cortocircuito a massa o circuito aperto", "P1617\tRelè comando accessori in cortocircuito su tensione batteria", "P1619\tRelè proiettore in cortocircuito a massa o circuito aperto", "P1620\tRelè proiettore in cortocircuito su tensione batteria", "P1621\tCortocircuito a massa o circuito aperto indicatore di livello carburante", "P1622\tCortocircuito su batteria veicolo indicatore di livello carburante", "P1628\tPompa di alimentazione - circuito aperto o cortocircuito a massa ", "P1629\tPompa di alimentazione - cortocircuito su batteria veicolo", "P1631\tBassa tensione circuito di rilevamento caduta",
			"P1632\tAlta tensione circuito di rilevamento caduta", "P1633\tMalfunzionamento del sistema del parabrezza", "P1650\tComunicazione con RCU persa (o malfunzionamento del immobilizzatore", "P1659\tProblemi di alimentazione all''accensione", "P1670\tSolenoide deflettore aria - circuito aperto o cortocircuito a massa ", "P1671\tSolenoide deflettore aria - in corto su batteria veicolo", "P1685\tMalfunzionamento circuito relè principale", "P1687\tBassa tensione sensore pressione assoluta collettore 2", "P1688\tTensione alta sensore pressione assoluta collettore 2", "P1690\tMalfunzionamento Bus CAN",
			"P1695\tComunicazione con quadro strumenti persa", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tProblemi di alimentazione sensore 5 V", "P2118\tAttuatore della valvola a farfalla, malfunzionamento del circuito", "P2119\tDifetto nel posizionamento della valvola a farfalla", "P2183\tMalfunzionamento circuito temperatura liquido refrigerante motore (cilindro 2)", "L0001\tAvviso batteria sensore gruppo ruota anteriore", "L0002\tAvviso batteria sensore gruppo ruota posteriore", "L0003\tAvviso guasto sensore gruppo ruota anteriore",
			"L0004\tAvviso guasto sensore gruppo ruota posteriore", "L0005\tPerdita di comunicazione con sensore gruppo ruota anteriore", "L0006\tPerdita di comunicazione con sensore gruppo ruota posteriore", "L0007\tRCU guasta", "L0008\tChiave non valida: Autenticazione chiave non riuscita"
		},
		{
			"P0031\tCircuito abierto o cortocircuito a tierra en el calentador del sensor de oxígeno 1", "P0032\tCortocircuito a batería en el calentador del sensor de oxígeno 1", "P0051\tCircuito abierto o cortocircuito a tierra en el calentador del sensor de oxígeno 2", "P0052\tCortocircuito a batería en el calentador del sensor de oxígeno 2", "P0078\tCircuito del motor de escape, circuito abierto o cortocircuito a tierra", "P0105\tAvería del circuito del sensor de presión atmosférico", "P0107\tVoltaje bajo en el sensor de presión absoluta del colector", "P0108\tVoltaje alto en el sensor de presión absoluta del colector", "P0110\tAvería del circuito del aire de admisión", "P0112\tTemperatura del aire de admisión demasiado alta",
			"P0113\tTemperatura del aire de admisión demasiado baja", "P0115\tAvería del circuito del refrigerante del motor", "P0116\tAvería del circuito del refrigerante del motor (cilindro 1)", "P0117\tTemperatura del refrigerante del motor demasiado baja", "P0118\tTemperatura del refrigerante del motor demasiado alta", "3P0118\tSensor de temperatura del refrigerante del motor, cortocircuito", "P0119\tVoltaje del refrigerante del motor demasiado alta", "3P0119\tSensor de temperatura del refrigerante del motor, circuito abierto", "P0120\tAvería del circuito del Sensor de posición del acelerador", "P0122\tSensor de posición del acelerador bajo",
			"3P0122\tSensor de posición del acelerador, cortocircuito", "P0123\tSensor de posición del acelerador alto", "3P0123\tSensor de posición del acelerador, circuito abierto", "P0130\tAnomalía en el circuito del calentador del sensor de oxígeno 1", "P0131\tMasa del sensor de oxígeno demasiado alta", "P0132\tSeñal del sensor de oxígeno demasiado alta", "P0133\tCortocircuito a batería en el sensor de oxígeno", "P0135\tAnomalía en el calentador del sensor de oxígeno", "P0150\tAnomalía en el circuito del calentador del sensor de oxígeno 2", "P0170\tAnomalía de la regulación de la mezcla de combustible",
			"P0201\tAnomalía en el circuito del inyector 1", "1P0201\tAnomalía en el circuito del inyector 2", "P0202\tAnomalía en el circuito del inyector 2", "1P0202\tAnomalía en el circuito del inyector 1", "P0203\tAnomalía en el circuito del inyector 3", "P0204\tAnomalía en el circuito del inyector 4", "P0222\tVoltaje bajo en el sensor de posición del acelerador secundario", "P0223\tVoltaje alto en el sensor de posición del acelerador secundario", "P0227\tVoltaje bajo en el sensor de posición del acelerador secundario", "2P0227\tSensor de posición de la empuñadura del acelerador, circuito abierto o cortocircuito a tierra",
			"P0228\tVoltaje alto en el sensor de posición del acelerador secundario", "2P0228\tSensor de posición de la empuñadura del acelerador, voltaje alto o cortocircuito a Vbatt", "P0230\tAvería en el relé de la bomba de combustible", "P0335\tAnomalía en el circuito del sensor del Cigüeñal", "P0340\tAnomalía en el sensor del árbol de levas", "P0341\tFallo del circuito del sensor del árbol de levas", "P0351\tAnomalía de la bobina de encendido 1", "1P0351\tAnomalía de la bobina de encendido 2", "P0352\tAnomalía de la bobina de encendido 2", "1P0352\tAnomalía de la bobina de encendido 1",
			"P0353\tAnomalía de la bobina de encendido 3", "P0354\tAnomalía de la bobina de encendido 4", "P0413\tCircuito de inyección de aire secundario abierto", "P0414\tCortocircuito en el circuito de inyección de aire secundario", "P0443\tAnomalía de la válvula de purga", "P0444\tCircuito abierto o cortocircuito a tierra en la válvula de purga", "P0445\tCortocircuito a Vbatt o temperatura excesiva en la válvula de purga", "P0460\tAnomalía en el circuito del sensor del nivel de combustible", "P0462\tEntrada baja en el circuito del sensor de combustible", "P0463\tEntrada alta en el circuito del sensor de combustible",
			"P0500\tAnomalía en el sensor de velocidad del vehículo", "P0505\tAnomalía en el sistema de la válvula de control de aire de ralentí", "P0510\tAnomalía en el interruptor de cancelación del control de crucero del puño giratorio", "P0560\tVoltaje del sistema, anomalía en el circuito de la batería", "P0562\tVoltaje del sistema bajo", "P0563\tVoltaje del sistema bajo", "P0571\tAnomalía en el interruptor del freno 1", "P0603\tError de EEPROM", "P0616\tCircuito abierto o cortocircuito a tierra en el relé de arranque", "P0617\tCortocircuito a batería en el relé de arranque",
			"P0630\tError de EEPROM", "P0638\tAnomalía en el circuito del acelerador secundario", "P0654\tAnomalía en el circuito del tacómetro", "P0656\tAnomalía en el circuito del indicador del nivel de combustible", "P0705\tAnomalía en el circuito del sensor de posición del cambio de marchas", "P1030\tFallo del sensor de oxígeno", "P1078\tSensor de posición de escape, circuito abierto o cortocircuito a tierra", "P1079\tSensor de posición de escape, cortocircuito a Vbatt", "P1080\tFallo del mecanismo de control del actuador de escape", "P1105\tAnomalía en el conducto del sensor de presión absoluta del colector",
			"P1106\tAnomalía en el conducto del sensor de presión absoluta del colector", "P1107\tVoltaje bajo en el circuito del sensor de presión ambiental", "P1108\tVoltaje alto en el circuito del sensor de presión ambiental", "P1111\tConductos del sensor de presión absoluta del colector invertidos", "P1115\tAnomalía en el circuito del indicador de temperatura del refrigerante ", "P1116\tCortocircuito o circuito abierto en el indicador de temperatura del refrigerante", "P1117\tCortocircuito a Vbatt/temperatura excesiva en el indicador de temperatura del refrigerante", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tControl de tracción inhabilitado debido a anomalía en el ABS", "P1171\tEnriquecimiento máximo de realimentatión lambda", "P1172\tEmpobrecimiento máximo de realimentatión lambda", "P1178\tRealimentatión lambda alcanzada, adaptación de fuga de aire máximo", "P1179\tRealimentatión lambda alcanzada, adaptación de fuga de aire máximo", "P1201\tCircuito abierto o cortocircuito a tierra en el inyector 1", "1P1201\tCircuito abierto o cortocircuito a tierra en el inyector 2", "P1202\tCircuito abierto o cortocircuito a tierra en el inyector 2", "1P1202\tCircuito abierto o cortocircuito a tierra en el inyector 1", "P1203\tCircuito abierto o cortocircuito a tierra en el inyector 3",
			"P1204\tCircuito abierto o cortocircuito a tierra en el inyector 4", "P1205\tCortocircuito a Vbatt o temperatura excesiva en el inyector 1", "1P1205\tCortocircuito a Vbatt o temperatura excesiva en el inyector 2", "P1206\tCortocircuito a Vbatt o temperatura excesiva en el inyector 2", "1P1206\tCortocircuito a Vbatt o temperatura excesiva en el inyector 1", "P1207\tCortocircuito a Vbatt o temperatura excesiva en el inyector 3", "P1208\tCortocircuito a Vbatt o temperatura excesiva en el inyector 4", "P1231\tCircuito abierto en el relé de la bomba de combustible", "P1232\tCortocircuito en el relé de la bomba de combustible", "P1335\tPatrón de secuencia incorrecta en el sensor del Cigüeñal",
			"P1340\tInterferencia eléctrica excesiva en el sensor del árbol de levas", "P1341\tPatrón de secuencia incorrecta en el sensor del árbol de levas", "P1351\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 1", "1P1351\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 2", "P1352\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 2", "1P1352\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 1", "P1353\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 3", "P1354\tCircuito abierto o cortocircuito a tierra en la bobina de encendido 4", "P1355\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 1", "1P1355\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 2",
			"P1356\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 2", "1P1356\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 1", "P1357\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 3", "P1358\tCortocircuito a Vbatt o temperatura excesiva en la bobina de encendido 4", "P1385\tAnomalía en el contador de revoluciones", "P1386\tCircuito abierto o cortocircuito en el contador de revoluciones", "P1387\tCortocircuito a Vbatt o temperatura excesiva en el contador de revoluciones", "P1500\tAnomalía en el circuito de salida de la velocidad del Vehículo", "P1501\tCircuito abierto o cortocircuito a tierra en el mecanismo del velocímetro", "1P1501\tSensor de temperatura del aire de admisión, cortocircuito a tierra",
			"3P1501\tMecanismo del velocímetro, cortocircuito", "P1502\tCortocircuito a Vbatt o temperatura excesiva en el mecanismo del velocímetro", "1P1502\tSensor de temperatura del aire de admisión, circuito abierto o cortocircuito a Vbatt", "3P1502\tMecanismo del velocímetro, circuito abierto", "P1508\tECM del inmobilizador no emparejado", "P1520\tABS no emparejado", "P1521\tSe ha perdido la comunicación con el ABS", "P1530\tAvería del circuito del sensor de efecto hall de posición del acelerador", "P1534\tAnomalía en el circuito del sensor del nivel de aceite de motor", "P1551\tAvería de la ventilador de refrigeración",
			"P1552\tCircuito abierto o cortocircuito a tierra del ventilador de refrigeración", "P1553\tCortocircuito a Vbatt o temperatura excesiva del ventilador de refrigeración", "P1560\tFallo en el circuito de voltaje de alimentación del sensor", "P1571\tAnomalía en el interruptor del freno 2", "P1574\tControl de crucero inhabilitado debido a otra anomalía", "P1575\tControl de crucero desactivado hasta que se complete la secuencia de pulsado de botones", "P1576\tError de correlación con el interruptor de freno 2 del interruptor de freno 1", "P1577\tError de correlación con el interruptor de freno 1 del interruptor de freno 2", "P1590\tSide stand switch, low voltage or short to ground", "P1600\tAvería en el MIL",
			"P1601\tCircuito abierto o cortocircuito a tierra en el MIL", "P1602\tCortocircuito a Vbatt en el MIL", "P1604\tDetectada manipulación del ECM: devolver a Triumph", "P1605\tECU bloqueada por la función de bloqueo de regulación", "P1606\tError interno del ECM", "P1607\tError interno del acelerador electrónico registrado en el ECM", "P1608\tError interno del acelerador electrónico registrado en el ECM", "P1610\tAnomalía en el circuito de salida de bajo nivel de combustible", "P1611\tCircuito abierto o cortocircuito a tierra en la lámpara del indicador de bajo nivel de combustible", "P1612\tCortocircuito a Vbatt en la lámpara del indicador de bajo nivel de combustible",
			"P1614\tIdentificación de los instrumentos incompatible", "P1616\tCircuito abierto o cortocircuito a tierra en el relé de control de accesorios", "P1617\tCortocircuito a Vbatt en el relé de control de accesorios", "P1619\tCircuito abierto o cortocircuito a tierra en el relé del faro ", "P1620\tCortocircuito a Vbatt en el relé del faro", "P1621\tCircuito abierto o cortocircuito a tierra en el indicador de nivel de combustible", "P1622\tCortocircuito a Vbatt en el indicador de nivel de combustible", "P1628\tCircuito abierto o cortocircuito a tierra en la bomba de combustible ", "P1629\tCortocircuito a Vbatt en la bomba de combustible", "P1631\tVoltaje bajo en el circuito de detección de caída",
			"P1632\tVoltaje alto en el circuito de detección de caída", "P1633\tAnomalía en el sistema del parabrisas", "P1650\tSe ha perdido la comunicación con la RCU (o anomalía del inmovilizador)", "P1659\tProblema en la fuente de alimentación del encendido", "P1670\tCircuito abierto o cortocircuito a tierra en el solenoide de la toma de aire ", "P1671\tCortocircuito a Vbatt en el solenoide de la toma de aire", "P1685\tAnomalía del circuito del relé principal", "P1687\tVoltaje bajo en el sensor de presión absoluta del colector 1", "P1688\tVoltaje bajo en el sensor de presión absoluta del colector 2", "P1690\tFallo de Bus CAN",
			"P1695\tSe ha perdido la comunicación con el panel de instrumentos", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tProblema en la alimentación del sensor de 5V", "P2118\tAnomalía en el circuito de actuador del acelerador", "P2119\tAnomalía en el posición del acelerador", "P2183\tAvería del circuito del refrigerante del motor (cilindro 2)", "L0001\tAlerta de pila del sensor de la unidad de la rueda delantera", "L0002\tAlerta de pila del sensor de la unidad de la rueda trasera", "L0003\tAlerta de fallo del sensor de la unidad de la rueda delantera",
			"L0004\tAlerta de fallo del sensor de la unidad de la rueda trasera", "L0005\tPérdida de comunicación del sensor de la unidad de la rueda delantera", "L0006\tPérdida de comunicación del sensor de la unidad de la rueda trasera", "L0007\tFallo de la RCU", "L0008\tLlave no válida: Fallo en autenticación de la llave"
		},
		{
			"P0031\tOxygen sensor heater short circuit to ground or open circuit", "P0032\tOxygen sensor heater short circuit to battery", "P0051\tOxygen sensor 2, heater short circuit to ground or open circuit", "P0052\tOxygen sensor 2, heater short circuit to battery", "P0078\tExhaust control valve actuator circuit malfunction", "P0105\tBarometric pressure sensor circuit malfunction", "P0107\tMAP sensor short circuit to ground", "P0108\tMAP sensor short circuit to battery or open circuit", "P0110\tInlet air temperature sensor circuit malfunction", "P0112\tInlet air temperature sensor short circuit to ground",
			"P0113\tInlet air temperature sensor open circuit or short circuit to battery", "P0115\tCoolant temperature sensor circuit malfunction", "P0116\tCoolant temperature sensor circuit (1st Cylinder) malfunction", "P0117\tCoolant temperature sensor high voltage or short circuit to battery", "P0118\tCoolant temperature sensor low voltage (short to ground or open circuit)", "3P0118\tEngine temperature sensor, short circuit", "P0119\tEngine coolant sensor, hight voltage", "3P0119\tEngine temperature sensor, open circuit", "P0120\tThrottle position sensor circuit malfunction", "P0122\tThrottle position sensor low voltage (short to ground or open circuit)",
			"3P0122\tThrottle position sensor, short circuit", "P0123\tThrottle position sensor high voltage or short circuit to battery", "3P0123\tThrottle position sensor, open circuit", "P0130\tLambda sensor, circuit malfunction", "P0131\tLambda sensor, short circuit to ground", "P0132\tLambda sensor signal too high", "P0133\tLambda sensor, short circuit to battery", "P0135\tOxygen sensor heater circuit malfunction", "P0150\tLambda sensor 2, circuit malfunction", "P0170\tLambda feedback fuel trim malfunction",
			"P0201\tInjector 1 circuit malfunction", "1P0201\tInjector 2 circuit malfunction", "P0202\tInjector 2 circuit malfunction", "1P0202\tInjector 1 circuit malfunction", "P0203\tInjector 3 circuit malfunction", "P0204\tInjector 4 circuit malfunction", "P0222\t2nd Throttle position sensor, low voltage (short to ground or open circuit)", "P0223\t2nd Throttle position sensor, high voltage or short circuit to battery", "P0227\t2nd Throttle position sensor, low voltage (short to ground or open circuit)", "2P0227\tGrip throttle position sensor, low voltage (short to ground or open circuit)",
			"P0228\t2nd Throttle position sensor, high voltage or short circuit to battery", "2P0228\tGrip throttle position sensor, high voltage or short circuit to battery", "P0230\tFuel pump relay default", "P0335\tCrankshaft sensor circuit malfunction", "P0340\tCamshaft sensor malfunction", "P0341\tCamshaft sensor circuit malfunction", "P0351\tIgnition coil 1 circuit malfunction", "1P0351\tIgnition coil 2 circuit malfunction", "P0352\tIgnition coil 2 circuit malfunction", "1P0352\tIgnition coil 1 circuit malfunction",
			"P0353\tIgnition coil 3 circuit malfunction", "P0354\tIgnition coil 4 circuit malfunction", "P0413\tSecondary air injection system short circuit to ground or open circuit", "P0414\tSecondary air injection system short circuit to battery", "P0443\tPurge valve system circuit malfunction", "P0444\tPurge Valve system open circuit or short circuit to ground", "P0445\tPurge valve system short circuit to battery", "P0460\tFuel level sensor circuit malfunction", "P0462\tFuel level sensor circuit low input", "P0463\tFuel level sensor circuit high input",
			"P0500\tVehicle speed sensor malfunction", "P0505\tIdle speed control system malfunction", "P0510\tTwist grip cruise cancel switch malfunction", "P0560\tECM power supply, circuit malfunction", "P0562\tSystem voltage low", "P0563\tSystem voltage high", "P0571\tBrake 1 switch malfunction", "P0603\tEEPROM fault", "P0616\tStarter relay short circuit to ground or open circuit", "P0617\tStarter relay short circuit to battery",
			"P0630\tEEPROM-Error", "P0638\t2nd Throttle control system malfunction", "P0654\tTachometer circuit malfunction", "P0656\tFuel gauge, circuit malfunction", "P0705\tGear position sensor circuit malfunction", "P1030\tOxygen sensor circuit malfunction", "P1078\tExhaust control valve actuator position sensor circuit low voltage or short to ground", "P1079\tExhaust control valve actuator position sensor circuit high voltage or short to battery", "P1080\tExhaust control valve actuator circuit malfunction", "P1105\tMAP sensor pipe fault",
			"P1106\tMAP sensor 2, pipe fault", "P1107\tAmbient pressure sensor circuit low voltage or short to ground", "P1108\tAmbient pressure sensor circuit high voltage or open circuit", "P1111\tManifold absolute pressure sensor pipes reversed", "P1115\tCoolant temperature gauge circuit malfunction", "P1116\tCoolant temperature gauge, short circuit to ground or open circuit", "P1117\tCoolant temperature gauge, short circuit to battery or over temperature", "P1119\tEngine coolant sensor voltage high", "P1131\tOxygen sensor circuits reversed", "P1133\tOxygen sensor over voltage",
			"P1135\tTraction Control prevented due to ABS malfunction", "P1171\tLambda feedback maximum enrichment", "P1172\tLambda feedback maximum enleanment", "P1178\tLambda feedback reached maximum air leakage adaption", "P1179\tLambda feedback reached minimum air leakage adaption", "P1201\tInjector 1, open circuit or short to ground", "1P1201\tInjector 2, open circuit or short to ground", "P1202\tInjector 2, open circuit or short to ground", "1P1202\tInjector 1, open circuit or short to ground", "P1203\tInjector 3, open circuit or short to ground",
			"P1204\tInjector 4, open circuit or short to ground", "P1205\tInjector 1, short circuit to battery or over temperature", "1P1205\tInjector 2, short circuit to battery or over temperature", "P1206\tInjector 2, short circuit to battery or over temperature", "1P1206\tInjector 1, short circuit to battery or over temperature", "P1207\tInjector 3, short circuit to battery or over temperature", "P1208\tInjector 4, short circuit to battery or over temperature", "P1231\tFuel pump relay open circuit or short to ground", "P1232\tFuel pump relay short circuit to battery", "P1335\tCrankshaft sensor incorrect sequence pattern",
			"P1340\tElectrical Noise signal", "P1341\tCamshaft sensor incorrect sequence pattern", "P1351\tIgnition coil 1, open circuit or short circuit to ground", "1P1351\tIgnition coil 2, open circuit or short circuit to ground", "P1352\tIgnition coil 2, open circuit or short circuit to ground", "1P1352\tIgnition coil 1, open circuit or short circuit to ground", "P1353\tIgnition coil 3, open circuit or short circuit to ground", "P1354\tIgnition coil 4, open circuit or short circuit to ground", "P1355\tIgnition coil 1, short circuit to battery or over temperature", "1P1355\tIgnition coil 2, short circuit to battery or over temperature",
			"P1356\tIgnition coil 2, short circuit to battery or over temperature", "1P1356\tIgnition coil 1, short circuit to battery or over temperature", "P1357\tIgnition coil 3, short circuit to battery or over temperature", "P1358\tIgnition coil 4, short circuit to battery or over temperature", "P1385\tTachometer system malfunction", "P1386\tTachometer, open circuit or short to ground", "P1387\tTachometer, short circuit to battery or over temperature", "P1500\tVehicule speed output circuit malfunction", "P1501\tSpeedometer, open circuit or short to ground", "1P1501\tInlet air temperature sensor, short circuit to ground",
			"3P1501\tInlet air temperature sensor, short circuit", "P1502\tSpeedometer, short circuit to battery or over temperature", "1P1502\tInlet air temperature sensor, open circuit or short circuit to battery", "3P1502\tInlet air temperature sensor, open circuit", "P1508\tUnmatched Immobiliser ECM", "P1520\tUnmatched ABS", "P1521\tLost communication with ABS", "P1530\tThrottle hall effect sensor circuit malfunction", "P1534\tEngine oil level sensor circuit malfunction", "P1551\tCooling fan system malfunction",
			"P1552\tCooling fan open circuit or short circuit to ground", "P1553\tCooling fan short circuit to battery", "P1560\tSensor supply voltage circuit fault", "P1571\tBrake 2 switch malfunction", "P1574\tCruise Control prevented due to other malfunction condition", "P1575\tCruise Control disabled until button press sequence completed", "P1576\tBrake 1 switch correlation error with brake switch 2", "P1577\tBrake 2 switch correlation error with brake switch 1", "P1590\tSide stand switch, low voltage or short to ground", "P1600\tMIL, system fault",
			"P1601\tMIL, open circuit or short circuit to ground", "P1602\tMIL, short circuit to battery", "P1604\tECM tamper detected - return to Triumph", "P1605\tECU locked by the tunelock function", "P1606\tECM internal error", "P1607\tECM ride by wire internal error", "P1608\tECM ride by wire internal error", "P1610\tLow fuel output circuit malfunction", "P1611\tLow fuel indicator lamp, short circuit to ground or open circuit", "P1612\tLow fuel indicator lamp, short circuit to battery",
			"P1614\tInstrument ID incompatible", "P1616\tAccessory control relay short circuit to ground or open circuit", "P1617\tAccessory control relay short circuit to battery", "P1619\tHeadlamp relay short circuit to ground or open circuit", "P1620\tHeadlamp relay short circuit to battery", "P1621\tFuel gauge, short circuit to ground or open circuit", "P1622\tFuel gauge, short circuit to battery", "P1628\tFuel pump short circuit to ground or open circuit", "P1629\tFuel pump short to battery", "P1631\tFall detection sensor circuit low voltage or short to ground",
			"P1632\tFall detection sensor circuit high voltage or open circuit", "P1633\tWindscreen system malfunction", "P1650\tLost communication with RCU (or immobiliser malfunction)", "P1659\tEMS ignition voltage input malfunction", "P1670\tIntake flap solenoid short circuit to ground or open circuit", "P1671\tIntake flap solenoid short circuit to battery", "P1685\tEMS main relay circuit malfunction", "P1687\tMAP sensor 2, short circuit to ground", "P1688\tMAP sensor 2, short circuit to battery or open circuit", "P1690\tMalfunction of CAN-Bus communication",
			"P1695\tLost communication with instrument panel", "P1696\t5V sensor supply short circuit to ground", "P1697\t5V sensor supply short circuit to battery", "P1698\tSensor supply battery circuit malfunction", "P2118\tThrottle motor drive circuit malfunction", "P2119\tThrottle position fault", "P2183\tCoolant temperature sensor circuit (2nd Cylinder) malfunction", "L0001\tFront wheel unit sensor battery alert", "L0002\tRear wheel unit sensor battery alert", "L0003\tFront wheel unit sensor fault alert",
			"L0004\tRear wheel unit sensor fault alert", "L0005\tFront wheel unit sensor loss of communication", "L0006\tRear wheel unit sensor loss of communication", "L0007\tRCU fault", "L0008\tInvalid key: Key authentication unsuccessful"
		}
	};

	public static void walbroSetTPS(int offset)
	{
		int num = byte2String((byte)ISOMain.tpsMin);
		Walbro_Set_Value[offset + 12] = (byte)(num >> 8);
		Walbro_Set_Value[offset + 13] = (byte)(num & 0xFF);
		num = byte2String((byte)ISOMain.tpsMax);
		Walbro_Set_Value[offset + 14] = (byte)(num >> 8);
		Walbro_Set_Value[offset + 15] = (byte)(num & 0xFF);
	}

	public static void walbroSetValue(int offset, int value)
	{
		Walbro_Set_Value[offset + msWalbro + 16] = (byte)(value >> 8);
		Walbro_Set_Value[offset + msWalbro + 17] = (byte)(value & 0xFF);
	}

	public static int IDSagem(int id)
	{
		for (int i = 0; i < Tune.sagemID.Length / 2; i++)
		{
			if (Tune.sagemID[i * 2] == id)
			{
				return Tune.sagemID[i * 2 + 1];
			}
		}
		return 0;
	}

	public static void GetDescription(string dtc)
	{
		bool flag = false;
		if (altDtc > 0 && AltDesc[altDtc - 1].IndexOf(dtc) > -1)
		{
			dtc = altDtc + dtc;
		}
		for (int i = 0; i < DtcDescription.Length / 6; i++)
		{
			if (DtcDescription[ISOMain.mLang, i].StartsWith(dtc))
			{
				ISOMain.DisplayMsg(DtcDescription[ISOMain.mLang, i].Substring(dtc.Length + 1), 48);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 236], 48);
		}
	}

	public static void SetDtcBuffer(int count)
	{
		mDTCMax = count;
		msgDTC = (mDTCMax + 2) / 3;
		mDtcCode = new ushort[2, mDTCMax];
		mDtcCount = new int[2];
	}

	public static void CodesReceive(byte[] message, int start, int length)
	{
		char[] array = new char[4] { 'P', 'C', 'B', 'U' };
		char[] array2 = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};
		int num;
		if (message[start] == 67)
		{
			num = 0;
		}
		else
		{
			if (message[start] != 71)
			{
				return;
			}
			num = 1;
		}
		for (int i = 0; i < 3; i++)
		{
			if (mDtcCount[num] < mDTCMax)
			{
				ushort num2 = (ushort)((message[i * 2 + start + 1] << 8) | message[i * 2 + start + 2]);
				if (num2 != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					mDtcCode[num, mDtcCount[num]] = num2;
					stringBuilder.Append(array[(num2 >> 14) & 3]);
					stringBuilder.Append(array2[(num2 >> 12) & 3]);
					stringBuilder.Append(array2[(num2 >> 8) & 0xF]);
					stringBuilder.Append(array2[(num2 >> 4) & 0xF]);
					stringBuilder.Append(array2[num2 & 0xF]);
					ISOMain.listCodesAddItems(stringBuilder.ToString());
					mDtcCount[num]++;
				}
			}
		}
	}

	private static void codesWalbroReceive(byte[] msg, int start)
	{
		bool flag = false;
		for (int i = 0; i < 16; i++)
		{
			byte b = 0;
			byte b2 = (byte)(msg[start + i] - 48);
			if (b2 > 16)
			{
				b2 -= 7;
			}
			while (b < 4)
			{
				byte b3 = (byte)(b2 >> (int)b);
				if ((b3 & 1) != 0)
				{
					int num = walbroDTC[i * 4 + b];
					string text = ((num != 0) ? ("P" + num.ToString("0000")) : "P????");
					ISOMain.listCodesAddItems(text.ToString());
					flag = true;
					dataNum[0] = (short)(flag ? 1 : 0);
				}
				b++;
			}
		}
		if (!flag)
		{
			ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 239], 48);
		}
	}

	public static void dataClear(int len)
	{
		for (int i = dataNum.Length / 2; i < dataNum.Length; i++)
		{
			dataNum[i] = 128;
		}
		Array.Clear(dataNum, 0, 16);
		if (len > 0)
		{
			Array.Clear(dataSensor, 0, len);
			Array.Clear(dataSensor, 100, len);
			Array.Clear(dataSensor, len + 16, 6);
			Array.Clear(dataSensor, len + 116, 6);
		}
		ISOMain.eqDev = 0;
		((Control)ISOMain.me.tvSensor).Invalidate();
	}

	public static void setSensor(int list)
	{
		altDtc = (ISOMain._Walbro ? 3 : (ISOMain._LC4 ? 2 : (ISOMain._Bene ? 1 : 0)));
		bSensor = 0;
		list += (ISOMain._KTM ? 6 : (ISOMain.sagemECU ? 3 : 0));
		switch (list)
		{
		case 0:
			readSensor = EditSensorK;
			break;
		case 1:
			setDiagSensor(1);
			AllSensor = (ISOMain._Twin ? keihinD_Sensor : (ISOMain._Four ? keihinF_Sensor : keihinT_Sensor));
			readSensor = (ISOMain._Four ? TestSensorF : TestSensorK);
			break;
		case 2:
			AllSensor = (ISOMain._Twin ? keihinD_Sensor : (ISOMain._Four ? keihinF_Sensor : keihinT_Sensor));
			readSensor = AllSensor;
			break;
		case 3:
			EditSensorS[9] = ((!ISOMain.noLoop) ? ((ushort)1) : ((ushort)0));
			readSensor = EditSensorS;
			break;
		case 4:
			TestSensorS[3] = ((!ISOMain.noLoop) ? ((ushort)1) : ((ushort)0));
			AllSensor = sagemT_Sensor;
			readSensor = TestSensorS;
			break;
		case 5:
			AllSensor = (ISOMain._sagemF ? sagemF_Sensor : sagemT_Sensor);
			readSensor = AllSensor;
			break;
		case 6:
			readSensor = (ISOMain._LC4 ? EditSensorL : EditSensorM);
			break;
		case 7:
			AllSensor = (ISOMain._LC4 ? keihinL_Sensor : keihinK_Sensor);
			readSensor = (ISOMain._LC4 ? TestSensorL : TestSensorM);
			break;
		case 8:
			AllSensor = (ISOMain._LC4 ? keihinL_Sensor : keihinK_Sensor);
			readSensor = AllSensor;
			break;
		}
		if (AllSensor != null)
		{
			for (int i = 0; i < AllSensor.Length / 2; i++)
			{
				if (AllSensor[i * 2 + 1] < 4)
				{
					AllSensor[i * 2 + 1] = 3;
				}
			}
		}
		ISOMain.sensorEnabled(list % 3);
	}

	public static void SetMapSensor(int map)
	{
		if ((readSensor != EditSensorK) & (readSensor != EditSensorM) & (readSensor != EditSensorL))
		{
			return;
		}
		int num = 2;
		int num2 = 0;
		int num3 = (((map == 15) | (map == 16) | (map == 17) | (map == 18)) ? 3 : ((!ISOMain._LC4) ? 1 : 119));
		if ((map == 16) & ISOMain._KTM & !ISOMain._LC4)
		{
			num3 = 23;
		}
		while (num < readSensor.Length - 2)
		{
			if (num2 > 1)
			{
				num += 2;
				num2 = 0;
			}
			readSensor[num] = (ushort)num3;
			num += 4;
			num2++;
		}
	}

	public static void setDiagSensor(int mode)
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				TestSensorK[(j + i * 5) * 2 + 1] = (ushort)(mode & 1);
			}
		}
		TestSensorK[7] = (ushort)((mode & 2) / 2);
		TestSensorK[9] = (ushort)((mode & 4) / 4);
		TestSensorK[TestSensorK.Length - 1] = (ushort)(mode & 1);
	}

	public static void setWalbroTrim(byte[] value, int start)
	{
		for (int i = 0; i < 2; i++)
		{
			if ((int)ISOMain.me.tvTests.Nodes[i + 10].Tag == -4)
			{
				ISOMain.me.tvTests.Nodes[i + 10].Tag = 34;
			}
		}
		Array.Copy(value, start, Walbro_Set_Value, 12, 12);
	}

	public static void setSagemTrim(int idx, int iVal)
	{
		int num = ((idx == 2) ? 65535 : 255);
		int num2 = ((idx != 2) ? 1 : 31);
		if ((int)ISOMain.me.tvTests.Nodes[idx + 10].Tag == -4)
		{
			ISOMain.me.tvTests.Nodes[idx + 10].Tag = 34;
		}
		byte b = (byte)((idx != 0) ? 35 : 0);
		int num3 = iVal - ((iVal >= num2) ? num2 : 0);
		int num4 = iVal + ((iVal <= num - num2) ? num2 : 0);
		dataSagemTrim[idx * 8 + 2] = (byte)(num3 >> 8);
		dataSagemTrim[idx * 8 + 3] = (byte)(num3 & 0xFF);
		dataSagemTrim[idx * 8 + 6] = (byte)(num4 >> 8);
		dataSagemTrim[idx * 8 + 7] = (byte)(num4 & 0xFF);
		dataSagemTrim[idx * 8] = b;
		dataSagemTrim[idx * 8 + 4] = b;
	}

	private static void SendZero()
	{
		ISOFT.FTDWrite(new byte[1] { 0 }, 1, echo: true, line: false);
	}

	private static void SendInitA()
	{
		ISOFT.FTDWrite(new byte[1] { (byte)Init }, 1, echo: true, line: false);
	}

	private static void SendInitK()
	{
		SendIso(new byte[1] { 129 }, -1, Echo: true, all: true);
	}

	private static void SendSeed()
	{
		int num = ((ISOMain.KWP | (AM != 3)) ? AM : 5);
		if (ISOFT.checkSagem)
		{
			SendIso(new byte[3] { 39, 3, 2 }, 9, Echo: true, all: false);
		}
		else
		{
			SendIso(new byte[2]
			{
				39,
				(byte)num
			}, 8, Echo: true, all: false);
		}
	}

	private static void SendKey(int key)
	{
		int nr = ((Init == 247) ? 6 : (-1));
		int num = AM + 1;
		SendIso(new byte[4]
		{
			39,
			(byte)num,
			(byte)(key / 256),
			(byte)(key & 0xFF)
		}, nr, Echo: true, all: false);
	}

	private static void SendKeySagem(int key)
	{
		SendIso(new byte[5]
		{
			39,
			3,
			2,
			(byte)(key / 256),
			(byte)(key & 0xFF)
		}, 7, Echo: true, all: false);
	}

	private static void SendPidQuery()
	{
		SendIso(new byte[2] { 1, 0 }, 10, Echo: true, all: false);
	}

	private static void SendDtcStatus()
	{
		SendIso(new byte[2] { 1, 1 }, 10, Echo: true, all: false);
	}

	private static void SendActiveCodeQuery()
	{
		SendIso(new byte[1] { 3 }, 11, Echo: true, all: false);
	}

	private void SendPendingCodeQuery()
	{
		SendIso(new byte[1] { 7 }, 11, Echo: true, all: false);
	}

	private static void SendClearCodesQuery()
	{
		SendIso(new byte[1] { 4 }, 5, Echo: true, all: false);
	}

	private static void SendIDQuery()
	{
		SendIso(new byte[2] { 33, 128 }, -1, Echo: true, all: false);
	}

	private static void SendPrompt()
	{
		int num = 0;
		byte[] array = new byte[ISOMain.KWP ? 3 : 2];
		array[num++] = (byte)(ISOMain.KWP ? 165u : 162u);
		if (ISOMain.KWP)
		{
			array[num++] = 74;
		}
		array[num] = (byte)(ISOMain.sagemECU ? 129u : 130u);
		SendIso(array, -1, Echo: true, !ISOMain.KWP);
	}

	private static void SendStartDiag()
	{
		SendIso(new byte[3]
		{
			49,
			144,
			(byte)((!aWrite) ? ((!ISOMain.sagemECU) ? 1u : 17u) : 0u)
		}, -1, Echo: true, all: true);
	}

	private static void SendReadBlock(byte data)
	{
		byte[] array = new byte[2]
		{
			(byte)(dataBlock[data] >> 8),
			(byte)(dataBlock[data] & 0xFF)
		};
		int nr = (((array[1] == 4) & ISOMain.sagemECU) ? 8 : 11);
		SendIso(array, nr, Echo: true, all: false);
	}

	private static void SendSensorQuery()
	{
		int num = 0;
		int num2 = 0;
		int num3 = bSensor;
		ushort num4;
		if ((readCodes + clearCodes > 0) & (iDST > 0))
		{
			num4 = 1;
		}
		else
		{
			while (readSensor[num3 + 1] < 1)
			{
				num3 = (num3 + 2) % readSensor.Length;
			}
			num4 = readSensor[num3];
			bSensor = (num3 + 2) % readSensor.Length;
		}
		int num5 = num4 >> 12;
		if ((num5 & 4) != 0)
		{
			num2 = num5 - 3;
		}
		num5 = ((num2 == 0) ? 3 : 0);
		byte[] array = new byte[(num5 == 0) ? 2 : 3];
		if (num5 == 3)
		{
			array[num++] = 34;
			array[num++] = (byte)((num4 / 256) & 0x7F);
		}
		else
		{
			array[num++] = (byte)((num4 / 256) & 0xF);
		}
		array[num++] = (byte)(num4 & 0xFF);
		SendIso(array, num5 + num2 + 6, Echo: true, all: false);
		dSensor = num4;
	}

	private static void SendRequestTransfert()
	{
		SendIso(new byte[1] { 52 }, -1, Echo: true, !ISOMain.KWP);
	}

	private static void SendTransfertData()
	{
		int flashRow = IMap.flashRow;
		short num = ((!ISOMain._KTM) ? ((short)(BitConverter.ToInt16(IMap.flashMemo, flashRow + 4) + 6)) : ((short)(IMap.flashMemo[flashRow + 4] + 8)));
		byte[] array = new byte[num];
		Array.Copy(IMap.flashMemo, flashRow, array, 0, num);
		SendIso(array, -1, Echo: true, all: true);
		ISOMain.ProgressBarRefresh(IMap.flashRow / (ISOMain._KTM ? 136 : 38));
	}

	private static void SendTransfertExit()
	{
		SendIso(new byte[1] { 55 }, -1, Echo: true, all: true);
	}

	private static void SendReadData()
	{
		int num = addrRead + readRow;
		SendIso(new byte[6]
		{
			35,
			(byte)(num >> 16),
			(byte)(num >> 8),
			(byte)num,
			(byte)ISOMain.sBloc,
			0
		}, -1, Echo: true, mLoad);
		if (readRow >= 0)
		{
			ISOMain.ProgressBarRefresh(dataRow / (byte)ISOMain.sBloc);
		}
	}

	private static void SendWaitBusy(byte cmd, int wait)
	{
		if (wait > 0)
		{
			Thread.Sleep(wait);
		}
		if (ISOMain.nop++ > ISOMain.warn)
		{
			ISOMain.ProgressBarRefresh(-1);
		}
		SendIso(new byte[1] { cmd }, -1, Echo: true, all: true);
	}

	private static void SendValidFlash()
	{
		bool flag = aWrite;
		byte[] array = new byte[(flag ? 8 : 0) + 10];
		array[0] = 49;
		array[1] = 145;
		if (flag)
		{
			Array.Copy(IMap.defnMap, 0, array, 2, 16);
		}
		else
		{
			Array.Copy(IMap.signMap, 0, array, 2, 8);
		}
		SendIso(array, -1, Echo: true, all: true);
	}

	private static void SendResetCmd()
	{
		SendIso(new byte[2] { 17, 1 }, 5, Echo: true, all: true);
	}

	private static void SendDiagnosticMsg()
	{
		byte[] array = new byte[ISOMain.KWP ? 3 : 2];
		if (rTest == 0)
		{
			array[0] = 49;
			if (ISOMain.KWP)
			{
				array[1] = (byte)(((mTest & 0xF0) >> 4) | 0xA0);
				array[2] = (byte)(mTest & 0xF);
			}
			else
			{
				array[1] = mTest;
			}
		}
		else
		{
			array[0] = 50;
			if (ISOMain.KWP)
			{
				array[1] = (byte)(((rTest & 0xF0) >> 4) | 0xA0);
				array[2] = (byte)(rTest & 0xF);
			}
			else
			{
				array[1] = rTest;
			}
		}
		int nr = (((mTest == 0) | (rTest != 0)) ? 7 : 6);
		SendIso(array, nr, Echo: true, all: false);
	}

	public static void SendCheckDevice()
	{
		SendIso(new byte[1] { (byte)(ISOMain.KWP ? 62u : 63u) }, 6, Echo: true, all: false);
	}

	public static void SendSagemCmd()
	{
		byte[] array = new byte[5] { 163, 0, 0, 0, 0 };
		for (int i = 0; i < 4; i++)
		{
			array[i + 1] = dataSagemTrim[i + mTrim * 4];
		}
		SendIso(array, 9, Echo: true, all: false);
	}

	private static void SendIso(byte[] msg, int nr, bool Echo, bool all)
	{
		int num = msg.Length + (ISOMain.KWP ? 5 : 4);
		byte[] array = new byte[num];
		array[0] = (byte)((Init == 247) ? 104u : ((uint)(((!ISOMain.KWP) ? msg.Length : 0) + 128)));
		array[1] = (byte)((Init == 247) ? 106u : ((uint)(213 + (ISOMain._KTM ? iDST : 0))));
		array[2] = (byte)((Init == 247) ? 241u : 245u);
		if (ISOMain.KWP)
		{
			nr = -1;
			array[3] = (byte)msg.Length;
		}
		for (int i = 0; i < msg.Length; i++)
		{
			array[i + (ISOMain.KWP ? 4 : 3)] = msg[i];
		}
		array[num - 1] = CalcChecksum(array, 0, num - 1);
		ISOMain.USBLed(1);
		ISOFT.FTDWrite(array, nr, Echo, all);
	}

	private static byte CalcChecksum(byte[] msg, int start, int length)
	{
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			num += msg[start + i];
		}
		return (byte)num;
	}

	private static int CalculateKey(int key)
	{
		int num = 0;
		if (Init == 247)
		{
			key = (key * (KEYR ^ (ISOFT.checkSagem ? 51087 : 0))) & 0xFFFF;
		}
		else
		{
			if (ISOMain.KWP)
			{
				num = (mFlash ? 48689 : ((AM == 1) ? 39508 : 40014));
			}
			else if (ISOMain.sagemECU)
			{
				num = 11090 - (mLoad ? 1 : 0);
			}
			key = (key * (KEYW ^ num)) & 0xFFFF;
		}
		return key;
	}

	public static void Setkeys(ulong key)
	{
		KEYR = (int)key;
		KEYW = (int)(key >> 32) ^ KEYR;
		KEYR = (KEYW >> 16) & 0xFFFF;
		KEYW &= 65535;
	}

	public static void StartDiagRoutine(int test, int step)
	{
		ISOMain.tRetry = 0;
		switch (test)
		{
		case 10:
			ISOMain.btnTest = -1;
			test -= step;
			break;
		case 9:
			test -= step;
			break;
		case 7:
			test += (ISOMain._2ndT ? 5 : 0);
			break;
		}
		mTest = diagData[test];
		SwitchMode(eMode.MODE_DIAGNOSTIC);
	}

	public static void StartSagemCmd(byte trim)
	{
		mTrim = trim;
		SwitchMode(eMode.MODE_SAGEM_CMD);
	}

	public static void SwitchLoad(bool start)
	{
		if ((readBuffer == null) & start)
		{
			for (int i = 0; i < 131072; i++)
			{
				IMap.memoMap[i + 524288] = byte.MaxValue;
			}
		}
		ISOMain.mDebug = 0;
		ISOMain.tDebug = -1;
		if (ISOMain.KWP)
		{
			if (start)
			{
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 217], 32);
				ISOMain.ProgressBarInit(readLen / ISOMain.sBloc);
				((Control)ISOMain.me.BtnLeft).Enabled = false;
				((Control)ISOMain.me.BtnMid).Enabled = false;
				((Control)ISOMain.me.BtnRight).Enabled = false;
				rstLoad = 0;
			}
			SwitchMode(eMode.MODE_READ_MEM);
		}
		else
		{
			SwitchMode(eMode.MODE_ACCESS);
		}
	}

	public static void setupFlash()
	{
		ISOMain.sBloc = (ISOMain._KTM ? 128 : 32);
		if (aWrite)
		{
			IMap.BuildRestoreMap();
		}
		else
		{
			IMap.BuildFlashMap();
		}
	}

	public static void SetReadMemory(int addr, int size, int off)
	{
		addrRead = addr;
		ISOMain.sBloc = size;
		readRow = off;
		SwitchMode(eMode.MODE_READ_MEM);
	}

	public static void SwitchMode(eMode mode)
	{
		mMode = mode;
		switch (mMode)
		{
		case eMode.MODE_NULL:
		{
			mId = false;
			iRetry = 0;
			Init = 0;
			if (!mFlash & !ISOMain.sRecovery)
			{
				iDST = 0;
			}
			ISOMain.KWP = false;
			noSum = false;
			ISOMain.setTPS = false;
			readCodes = 0;
			clearCodes = 0;
			int rSafe = ISOFT.rSafe;
			ISOMain.histMemo = null;
			ISOFT.checkSagem = !(mSafe | mLoad | mFlash);
			ISOFT.SetMessage(eMessage.ERR_NULL);
			ISOMain.enableMenuItems(mMode, rSafe);
			ISOMain.infosConnect(0);
			if (ISOMain.swMode == 0)
			{
				((Control)ISOMain.me.panelTable).Invalidate();
			}
			Thread.Sleep(500);
			break;
		}
		case eMode.MODE_INIT:
			Thread.Sleep(25);
			if (Init != 0)
			{
				SendInitA();
			}
			else
			{
				SendInitK();
			}
			break;
		case eMode.MODE_SEED:
			if (!mId & !reLoad)
			{
				ISOMain.infosConnect(1);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 204], 32);
			}
			Thread.Sleep(50);
			SendSeed();
			break;
		case eMode.MODE_READ_DATA_BLOCK:
			SendReadBlock(bData);
			break;
		case eMode.MODE_READ_PIDS:
			SendPidQuery();
			break;
		case eMode.MODE_READ_ACTIVE:
			SetDtcBuffer(MIL & 0x7F);
			SendActiveCodeQuery();
			break;
		case eMode.MODE_READ_SENSORS:
			ISOMain.enableMenuItems(mMode, 0);
			SendSensorQuery();
			break;
		case eMode.MODE_DIAGNOSTIC:
		case eMode.MODE_STOP_DIAG:
			Thread.Sleep(100);
			break;
		case eMode.MODE_SAGEM_CMD:
			Thread.Sleep(50);
			break;
		case eMode.MODE_READ_IDENT:
			ISOFT.rSafe = 0;
			if (ISOMain.mLed == 0)
			{
				ISOMain.DisplayMsg(".\r", 32);
			}
			if (!mId)
			{
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 210], 32);
			}
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendIDQuery();
			break;
		case eMode.MODE_ACCESS:
			if (mFlash & !safe & !mLoad)
			{
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 205], 32);
			}
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendSeed();
			break;
		case eMode.MODE_SPEED_COM:
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendPrompt();
			break;
		case eMode.MODE_START_PROG:
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendStartDiag();
			break;
		case eMode.MODE_START_DOWNLOAD:
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendRequestTransfert();
			break;
		case eMode.MODE_DOWNLOAD:
			Thread.Sleep(160);
			if (ISOMain.nop++ > ISOMain.warn)
			{
				ISOMain.ProgressBarRefresh(-1);
			}
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendTransfertData();
			break;
		case eMode.MODE_READ_MEM:
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendReadData();
			break;
		case eMode.MODE_DOWNLOAD_EXIT:
			Thread.Sleep(100);
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendTransfertExit();
			break;
		case eMode.MODE_END_PROG:
			Thread.Sleep(500);
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendValidFlash();
			break;
		case eMode.MODE_ECU_RESET:
			Thread.Sleep(500);
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			SendResetCmd();
			break;
		case eMode.MODE_WALBRO_INFO:
			Thread.Sleep(20);
			ISOMain.infosConnect(2);
			ISOFT.serialWrite(Walbro_Info, 125, csum: true);
			break;
		case eMode.MODE_WALBRO_VERSION:
			ISOFT.serialWrite(Walbro_Version, 13, csum: true);
			break;
		case eMode.MODE_WALBRO_SENSORS:
			ISOMain.enableMenuItems(mMode, 0);
			ISOFT.serialWrite(Walbro_Sensors, 5, csum: true);
			break;
		case eMode.MODE_WALBRO_TPS:
			ISOMain.enableMenuItems(mMode, 0);
			ISOFT.serialWrite(Walbro_Trim, 21, csum: true);
			break;
		case eMode.MODE_WALBRO_SET_VALUE:
			ISOFT.serialWrite(Walbro_Set_Value, 5, csum: true);
			break;
		case eMode.MODE_WALBRO_READ_MEM:
			setWalbroRead(addrRead + readRow, readBuffer.Length);
			ISOFT.serialWrite(Walbro_ReadMem, readBuffer.Length * 2 + 5, csum: true);
			break;
		case eMode.MODE_WALBRO_DTC:
			ISOMain.listCodesUpdate("", status: true);
			ISOFT.serialWrite(Walbro_DTC, 53, csum: true);
			break;
		case eMode.MODE_WALBRO_CLEAR_DTC:
			ISOFT.serialWrite(walbro_Clear_DTC, 5, csum: true);
			break;
		case eMode.MODE_WALBRO_SYNC:
			ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			uBuffer[0] = 85;
			ISOFT.serialWrite(uBuffer, 1, csum: false);
			break;
		case eMode.MODE_WALBRO_UPROG:
		{
			if (readRow == -2)
			{
				uBuffer = new byte[2];
				uBuffer[0] = (byte)((usrProg.Length >> 8) & 0xFF);
				uBuffer[1] = (byte)(usrProg.Length & 0xFF);
				ISOFT.serialWrite(uBuffer, 2, csum: false);
				break;
			}
			int num = ((readRow + 4 >= usrProg.Length) ? (usrProg.Length - readRow) : 4);
			uBuffer = new byte[num];
			for (int i = 0; i < num; i++)
			{
				uBuffer[i] = usrProg[readRow + i];
			}
			ISOFT.serialWrite(uBuffer, num, csum: false);
			break;
		}
		case eMode.MODE_WALBRO_ERASING:
			ISOMain.infosConnect(1);
			iRetry = 7;
			ISOFT.serialWrite(null, 4, csum: false);
			ISOFT.openSerialPort(38400);
			Thread.Sleep(100);
			break;
		case eMode.MODE_WALBRO_ERASED:
			ISOMain.ProgressBarInit(IMap.flashMemo.Length / 37);
			ISOFT.serialWrite(uBuffer, 1, csum: false);
			break;
		case eMode.MODE_WALBRO_DOWNLOAD:
			uBuffer = new byte[2];
			uBuffer[0] = 80;
			uBuffer[1] = 37;
			ISOFT.serialWrite(uBuffer, 1, csum: false);
			break;
		case eMode.MODE_WALBRO_END_PROG:
			uBuffer = new byte[2];
			uBuffer[0] = 69;
			uBuffer[1] = byte.MaxValue;
			ISOFT.serialWrite(uBuffer, 1, csum: false);
			break;
		case eMode.MODE_ABORT:
		case eMode.MODE_WALBRO_END_READ:
		case eMode.MODE_WALBRO_ABORT:
			break;
		}
	}

	public static void newSession(int dest)
	{
		ISOMain.KWP = false;
		iDST = dest;
		if (dest == 0)
		{
			ISOMain.tCode = false;
		}
		KWPInit();
	}

	public static bool readSerial(byte[] data, int start, int length)
	{
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		ISOFT.ackRead = false;
		if ((start < 0) | (length == 0) | (length > 254))
		{
			return false;
		}
		if ((!noSum & (length > 1)) && data[start + length - 1] != CalcChecksum(data, start, length - 1))
		{
			return false;
		}
		ISOMain.USBLed(1);
		if ((ISOMain.mDebug & 0xC) > 0)
		{
			ISOMain.WriteTrcFile(data, start, length, ":");
		}
		string text = null;
		if (data[start] == 58)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append((char)data[i]);
			}
			text = stringBuilder.ToString();
		}
		switch (mMode)
		{
		case eMode.MODE_NULL:
			if (mFlash)
			{
				if (data[start] == 0)
				{
					SwitchMode(eMode.MODE_WALBRO_SYNC);
				}
			}
			else if (text.StartsWith(":OK!"))
			{
				ISOMain.mECU = 3;
				ISOMain.KWP = false;
				ISOMain._KTM = false;
				ISOMain._LC4 = false;
				ISOMain.sagemECU = false;
				ISOMain._Apri = false;
				ISOMain._Bene = false;
				ISOMain._Walbro = true;
				ISOMain.notryCnx = false;
				if (!mLoad)
				{
					SwitchMode(eMode.MODE_WALBRO_VERSION);
				}
				else
				{
					int num = (mLoad ? readLen : IMap.flashSize);
					ISOMain.enableMenuItems(mMode, 0);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, mLoad ? 217 : 213], 32);
					ISOMain.ProgressBarInit(num / ISOMain.sBloc);
					SwitchMode(eMode.MODE_WALBRO_READ_MEM);
				}
				ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
			}
			break;
		case eMode.MODE_WALBRO_VERSION:
			if (text.StartsWith(":OK!"))
			{
				string text2 = BuildString(data, 4, 8, ascii: true, nozero: true);
				ISOMain.DisplayMsg("\r" + ISOMain.LangUI[ISOMain.mLang, 69] + text2 + "\r", 32);
				ECUTyp = text2 switch
				{
					"A1BEN_07" => 16647, 
					"A1BEN_04" => 16644, 
					"A1BEN_02" => 16642, 
					"WBE400AU" => 16390, 
					"WBE400AR" => 16388, 
					"WBE400AN" => 16386, 
					"WBE400AL" => 16386, 
					_ => -1, 
				};
				int num4 = IMap.CheckMapID(ECUTyp, 1) >> 16;
				if (num4 > 0)
				{
					rIdle = IMap.getAddr(num4, 5) | 0x10000;
					rMS = IMap.getAddr(num4, 36) | 0xFF0000;
					num4 = (((ECUTyp & 0x4100) == 16640) ? 10 : 8);
					Walbro_TPS[9] = (byte)byte2String((byte)num4);
					addrRead = 2;
					readRow = 0;
					ISOMain.RevCount = 2;
					ISOMain.SetUInterface(1);
					readBuffer = new byte[2];
					SwitchMode(eMode.MODE_WALBRO_READ_MEM);
				}
				else
				{
					dataSensor[65] = text2;
					ISOFT.SetMessage(eMessage.ERR_ABORT);
					Thread.Sleep(1000);
				}
			}
			break;
		case eMode.MODE_WALBRO_READ_MEM:
		{
			if (!text.StartsWith(":OK!"))
			{
				break;
			}
			if (!mLoad)
			{
				if (addrRead < 512)
				{
					csMap[22] = String2Byte(data, 4);
					csMap[23] = String2Byte(data, 6);
					addrRead = rIdle;
					SwitchMode(eMode.MODE_WALBRO_READ_MEM);
					break;
				}
				int num2;
				if (addrRead == rIdle)
				{
					num2 = (String2Byte(data, 4) << 8) | String2Byte(data, 6);
					dataSensor[38] = num2.ToString();
					addrRead = 131070;
					SwitchMode(eMode.MODE_WALBRO_READ_MEM);
					break;
				}
				num2 = (String2Byte(data, 4) << 8) | String2Byte(data, 6);
				if (num2 != 65535)
				{
					dataSensor[66] = num2.ToString("X2");
				}
				SwitchMode(eMode.MODE_WALBRO_INFO);
				break;
			}
			for (int j = 0; j < ISOMain.sBloc; j++)
			{
				IMap.memoMap[addrRead + readRow + j] = String2Byte(data, j * 2 + 4);
			}
			dataRow += ISOMain.sBloc;
			readRow += ISOMain.sBloc;
			readRow = IMap.ReadNextBloc(addrRead, readRow);
			if (readRow >= 0)
			{
				ISOMain.ProgressBarRefresh(dataRow / (byte)ISOMain.sBloc);
			}
			if (ISOFT.mMessage != eMessage.ERR_ABORT)
			{
				ISOFT.rFlag = 0;
				if (dataRow < readLen)
				{
					SwitchMode(eMode.MODE_WALBRO_READ_MEM);
					break;
				}
				mMode = eMode.MODE_WALBRO_END_READ;
				if (!ISOMain.rDump)
				{
					readBuffer = null;
				}
				ISOFT.SetMessage(eMessage.END_DOWNLOAD);
				ISOMain.ProgressBarInit(0);
				Thread.Sleep(300);
			}
			else
			{
				mMode = eMode.MODE_WALBRO_ABORT;
			}
			break;
		}
		case eMode.MODE_WALBRO_INFO:
			if (text.StartsWith(":OK!"))
			{
				csMap[20] = String2Byte(data, 108);
				csMap[21] = String2Byte(data, 110);
				string wbMap = IMap.GetWbMap(csMap);
				dataSensor[27] = ((double)(int)String2Byte(data, 4) / 51.0).ToString("0.00");
				dataSensor[28] = ((double)(int)String2Byte(data, 6) / 51.0).ToString("0.00");
				dataNum[19] = String2Byte(data, 12);
				dataNum[21] = String2Byte(data, 14);
				dataSensor[63] = String2Char(data, 20, 34, ascii: true);
				dataSensor[64] = String2Char(data, 60, 20, ascii: true);
				dataSensor[65] = wbMap;
				ISOMain.DisplayMsg("", 16);
				ISOMain.DisplayMsg("", 96);
				ISOMain.DisplayMsg(dataSensor[63], 112);
				ISOMain.DisplayMsg("\r\r" + ISOMain.LangUI[ISOMain.mLang, 210], 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 211] + dataSensor[64] + "\r", 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 63] + ((csMap[22] << 8) + csMap[23]).ToString("X2") + "\r", 32);
				SwitchMode(eMode.MODE_WALBRO_DTC);
			}
			break;
		case eMode.MODE_WALBRO_DTC:
			if (text.StartsWith(":OK!"))
			{
				codesWalbroReceive(data, 20);
				if (ISOMain.swMode == 1)
				{
					SwitchMode(eMode.MODE_WALBRO_TPS);
				}
				else
				{
					SwitchMode(eMode.MODE_WALBRO_SENSORS);
				}
			}
			break;
		case eMode.MODE_WALBRO_CLEAR_DTC:
			if (text.StartsWith(":OK!"))
			{
				ISOMain.listCodesUpdate("", status: true);
				SwitchMode(eMode.MODE_WALBRO_TPS);
			}
			break;
		case eMode.MODE_WALBRO_SENSORS:
			if (text.StartsWith(":OK!"))
			{
				ISOFT.serialWrite(null, -1, csum: true);
			}
			break;
		case eMode.MODE_WALBRO_TPS:
			if (!text.StartsWith(":OK!"))
			{
				break;
			}
			if (ISOMain.swMode != 1)
			{
				mMode = eMode.MODE_NULL;
			}
			else if (length == 21)
			{
				dataNum[18] = String2Byte(data, 8);
				dataNum[19] = String2Byte(data, 12);
				dataNum[20] = String2Byte(data, 10);
				dataNum[21] = String2Byte(data, 14);
				dataSensor[74] = ((double)dataNum[msWalbro + 18] / 128.0).ToString("0.000");
				dataSensor[75] = ((double)dataNum[msWalbro + 19] / 128.0).ToString("0.000");
				setWalbroTrim(data, start + 4);
			}
			if (clearCodes > 0)
			{
				clearCodes = 0;
				SwitchMode(eMode.MODE_WALBRO_CLEAR_DTC);
				break;
			}
			if (readCodes > 0)
			{
				readCodes = 0;
				mMode = eMode.MODE_WALBRO_DTC;
				ISOFT.serialWrite(Walbro_DTC, 53, csum: true);
				break;
			}
			if (setWBTrim > 0)
			{
				setWBTrim = 0;
				SwitchMode(eMode.MODE_WALBRO_SET_VALUE);
				break;
			}
			switch (length)
			{
			case 9:
				ISensor.DataSensorUpdate(data, 0, length);
				setWalbroRead(rMS, 1);
				ISOFT.serialWrite(Walbro_ReadMem, 7, csum: true);
				break;
			case 7:
				dataNum[2] = String2Byte(data, 4);
				if (dataNum[2] != dataNum[32])
				{
					dataNum[32] = dataNum[2];
					msWalbro = ((dataNum[2] != 0) ? 2 : 0);
					SwitchMode(eMode.MODE_WALBRO_TPS);
				}
				else
				{
					ISOFT.serialWrite(Walbro_TPS, 9, csum: true);
				}
				break;
			default:
				ISOFT.serialWrite(Walbro_TPS, 9, csum: true);
				break;
			}
			break;
		case eMode.MODE_WALBRO_SET_VALUE:
			if (text.StartsWith(":OK!"))
			{
				mTrim = 64;
			}
			SwitchMode(eMode.MODE_WALBRO_TPS);
			if (ISOMain.setTPS)
			{
				ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 232], 1);
				ISOMain.setTPS = false;
			}
			break;
		case eMode.MODE_WALBRO_SYNC:
			readRow = -2;
			noSum = true;
			if (data[start] == 170)
			{
				ISOMain.infosConnect(3);
				mFileText = ((ToolStripItem)ISOMain.me.fileStatus).Text;
				ISOMain.DisplayMsg("\r\r" + ISOMain.LangUI[ISOMain.mLang, 345], 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 345], 64);
				SwitchMode(eMode.MODE_WALBRO_UPROG);
			}
			else
			{
				Thread.Sleep(500);
			}
			break;
		case eMode.MODE_WALBRO_UPROG:
		{
			bool flag = length != uBuffer.Length;
			if (!flag)
			{
				for (int k = 0; k < length; k++)
				{
					if (uBuffer[k] != data[k])
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				Thread.Sleep(500);
				break;
			}
			readRow += length;
			if (readRow == usrProg.Length)
			{
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 291] + "\r", 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 346], 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 346], 64);
				SwitchMode(eMode.MODE_WALBRO_ERASING);
			}
			else
			{
				SwitchMode(eMode.MODE_WALBRO_UPROG);
			}
			break;
		}
		case eMode.MODE_WALBRO_ERASING:
			if (length == 4)
			{
				if (((data[start + 2] << 8) | data[start + 3]) == 257)
				{
					uBuffer = new byte[1];
					uBuffer[0] = 2;
					ISOFT.serialWrite(uBuffer, 2, csum: false);
				}
				else if (iRetry-- > 0)
				{
					ISOFT.serialWrite(null, 4, csum: false);
				}
				else
				{
					ISOFT.SetflagOut(-1);
				}
			}
			else if ((length == 2) & (data[start] == 4))
			{
				uBuffer[0] = 8;
				int num3 = data[1];
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 347] + num3 + ISOMain.LangUI[ISOMain.mLang, 348], 32);
				if (num3 == 15)
				{
					SwitchMode(eMode.MODE_WALBRO_ERASED);
				}
				else
				{
					ISOFT.serialWrite(uBuffer, 2, csum: false);
				}
			}
			else
			{
				ISOFT.SetflagOut(-1);
			}
			break;
		case eMode.MODE_WALBRO_ERASED:
			if (data[start] == 4)
			{
				ISOMain.infosConnect(2);
				uBuffer[0] = 6;
				ISOFT.serialWrite(uBuffer, 1, csum: false);
				Thread.Sleep(200);
				ISOMain.DisplayMsg(mFileText, 64);
				SwitchMode(eMode.MODE_WALBRO_DOWNLOAD);
			}
			else
			{
				ISOFT.SetflagOut(-1);
			}
			break;
		case eMode.MODE_WALBRO_DOWNLOAD:
			if (length == 1)
			{
				if (data[start] == 75)
				{
					uBuffer = new byte[37];
					Array.Copy(IMap.flashMemo, IMap.flashRow, uBuffer, 0, 37);
					ISOFT.serialWrite(uBuffer, 4, csum: false);
				}
				else
				{
					ISOFT.SetflagOut(-1);
				}
			}
			else
			{
				IMap.flashRow += 37;
				ISOMain.ProgressBarRefresh(IMap.flashRow / 37);
				if (IMap.flashRow < IMap.flashMemo.Length)
				{
					SwitchMode(eMode.MODE_WALBRO_DOWNLOAD);
				}
				else
				{
					SwitchMode(eMode.MODE_WALBRO_END_PROG);
				}
			}
			break;
		case eMode.MODE_WALBRO_END_PROG:
			if ((data[start] == 69) & (ISOFT.mMessage == eMessage.ERR_TIMEOUT))
			{
				ISOFT.SetMessage(eMessage.END_DOWNLOAD);
				ISOMain.ProgressBarInit(0);
			}
			Thread.Sleep(300);
			break;
		}
		return true;
	}

	public static void ReadData(byte[] data, int start, int length, bool echo)
	{
		if (echo)
		{
			return;
		}
		if ((ISOMain.mDebug & 0xC) > 0)
		{
			ISOMain.WriteTrcFile(data, start, length, ":");
		}
		switch (mMode)
		{
		case eMode.MODE_NULL:
			if (((data[start] == 85) & (data[start + 1] == 8) & (data[start + 2] == 8)) | ((data[start] == 85) & (data[start + 1] == 217) & (data[start + 2] == 143)))
			{
				ISOMain.mECU = 0;
				ISOMain.KWP = false;
				ISOMain._KTM = false;
				ISOMain._LC4 = false;
				ISOMain._Walbro = false;
				ISOMain.notryCnx = false;
				Init = data[start + 2] ^ 0xFF;
				SwitchMode(eMode.MODE_INIT);
			}
			break;
		case eMode.MODE_INIT:
			iRetry = 0;
			ISOMain._Walbro = false;
			if (data[start] == 204)
			{
				AM = (byte)(ISOFT.checkSagem ? 3u : 5u);
				SwitchMode(eMode.MODE_SEED);
			}
			else if (data[start] == 42)
			{
				SwitchMode(eMode.MODE_READ_IDENT);
			}
			else if ((data[start + 4] == 193) & (data[start + 5] == 218) & (data[start + 6] == 143))
			{
				ISOMain.mECU = 0;
				ISOMain._Apri = false;
				ISOMain._Bene = false;
				ISOMain.KWP = true;
				if (!mId & !mFlash)
				{
					ISOMain._KTM = false;
					ISOMain._LC4 = false;
				}
				ISOFT.sECU = 0;
				ISOMain.notryCnx = false;
				ISOFT.checkSagem = false;
				Init = data[start + 2] ^ 0xFF;
				AM = (byte)(mFlash ? 5u : 3u);
				SwitchMode(eMode.MODE_SEED);
			}
			break;
		default:
			if ((data[start] == 72) & (data[start + 1] == 107) & (data[start + 2] == 209))
			{
				ISOReply(data, start, length);
			}
			else if ((data[start] >= 128) & (data[start + 1] == 245) & ((data[start + 2] & 0xDC) == 212))
			{
				KWPReply(data, start, length);
			}
			break;
		}
	}

	private static void ISOReply(byte[] message, int start, int length)
	{
		if (message[start + length - 1] != CalcChecksum(message, start, length - 1))
		{
			return;
		}
		switch (message[start + 3])
		{
		case 65:
			switch (message[start + 4])
			{
			case 0:
				if (ISOMain.swMode == 0)
				{
					SwitchMode(eMode.MODE_READ_SENSORS);
					break;
				}
				ISOMain.listCodesUpdate("", status: true);
				SendDtcStatus();
				break;
			case 1:
				if (readCodes > 0)
				{
					readCodes = 0;
					MIL = message[start + 5];
					if (MIL == 0)
					{
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 239], 48);
						SwitchMode(eMode.MODE_READ_SENSORS);
					}
					else
					{
						SwitchMode(eMode.MODE_READ_ACTIVE);
					}
					break;
				}
				if (readSensor == AllSensor)
				{
					for (int k = 0; k < readSensor.Length / 2; k++)
					{
						if ((readSensor[k * 2] == dSensor) & (readSensor[k * 2 + 1] < 4))
						{
							readSensor[k * 2 + 1] = 3;
						}
					}
				}
				SendSensorQuery();
				ISensor.DataSensorReceive(message, start + 3);
				break;
			default:
				switch (mMode)
				{
				case eMode.MODE_READ_SENSORS:
					if (readSensor == AllSensor)
					{
						for (int j = 0; j < readSensor.Length / 2; j++)
						{
							if ((readSensor[j * 2] == dSensor) & (readSensor[j * 2 + 1] < 4))
							{
								readSensor[j * 2 + 1] = 3;
							}
						}
					}
					SendSensorQuery();
					ISensor.DataSensorReceive(message, start + 3);
					break;
				case eMode.MODE_DIAGNOSTIC:
					SendDiagnosticMsg();
					break;
				case eMode.MODE_SAGEM_CMD:
					SendSagemCmd();
					break;
				}
				break;
			}
			break;
		case 67:
		case 71:
			CodesReceive(message, start + 3, length);
			if (--msgDTC == 0)
			{
				SwitchMode(eMode.MODE_READ_SENSORS);
			}
			else
			{
				ISOFT.FTDWrite(null, 11, echo: false, line: false);
			}
			break;
		case 68:
			clearCodes = 0;
			ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 235], 32);
			ISOMain.listCodesUpdate(ISOMain.LangUI[ISOMain.mLang, 241], status: false);
			SwitchMode(eMode.MODE_READ_SENSORS);
			break;
		case 98:
			switch (mMode)
			{
			case eMode.MODE_READ_SENSORS:
				if (readSensor == AllSensor)
				{
					for (int i = 0; i < readSensor.Length / 2; i++)
					{
						if ((readSensor[i * 2] == dSensor) & (readSensor[i * 2 + 1] < 4))
						{
							readSensor[i * 2 + 1] = 3;
						}
					}
				}
				if (readCodes > 0)
				{
					SendDtcStatus();
				}
				else if (clearCodes > 0)
				{
					SendClearCodesQuery();
				}
				else
				{
					SendSensorQuery();
				}
				ISensor.DataSensorReceive(message, start + 4);
				break;
			case eMode.MODE_DIAGNOSTIC:
				SendDiagnosticMsg();
				break;
			case eMode.MODE_SAGEM_CMD:
				SendSagemCmd();
				break;
			}
			break;
		case 103:
			AM = message[start + 4];
			switch (AM)
			{
			case 3:
				if (message[start + 5] == 2)
				{
					if (length > 7)
					{
						SendKeySagem(CalculateKey((message[start + 6] << 8) | message[start + 7]));
						ISOFT.checkSagem = false;
						ISOMain.sagemECU = true;
					}
					else if (mId)
					{
						bData = 0;
						ISOMain.offWOT = 100;
						ISOMain.enableMenuItems(mMode, 0);
						ISOMain.infosConnect(2);
						ISOMain.SetUInterface(0);
						setSensor(ISOMain.swMode);
						SwitchMode(eMode.MODE_READ_DATA_BLOCK);
					}
					else
					{
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 206], 32);
						mMode = eMode.MODE_NULL;
						Initialization(213);
					}
				}
				break;
			case 5:
				ISOMain.sagemECU = false;
				ISOFT.checkSagem = false;
				SendKey(CalculateKey((message[start + 5] << 8) | message[start + 6]));
				break;
			case 6:
				ISOMain.DisplayMsg("", 96);
				if (mId)
				{
					bData = 0;
					ISOMain.enableMenuItems(mMode, 0);
					ISOMain.infosConnect(2);
					ISOMain.SetUInterface(1);
					setSensor(ISOMain.swMode);
					SwitchMode(eMode.MODE_READ_DATA_BLOCK);
				}
				else
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 206], 32);
					mMode = eMode.MODE_NULL;
					Initialization(213);
				}
				break;
			case 4:
				break;
			}
			break;
		case 113:
		case 115:
			switch (message[start + 4])
			{
			case 2:
				rTest = (byte)((!ISOMain.sagemECU) ? mTest : 0);
				ISOMain.testTick = 0;
				break;
			case 7:
			case 11:
				rTest = mTest;
				ISOMain.SettingTPS();
				break;
			case 9:
				rTest = mTest;
				ISOMain.SettingEXBV();
				break;
			case 13:
				if (ISOMain.EXBVReset)
				{
					rTest = mTest;
					ISOMain.SettingEXBV();
				}
				else
				{
					rTest = 0;
					ISOMain.testTick = 0;
				}
				break;
			default:
				rTest = 0;
				ISOMain.testTick = 0;
				break;
			}
			ISOMain.onTest = true;
			if (ISOMain.swMode == 0)
			{
				Thread.Sleep(200);
				ISOFT.SetMessage(eMessage.END_DIAG);
			}
			else
			{
				SwitchMode(eMode.MODE_READ_SENSORS);
			}
			break;
		case 114:
			rTest = 0;
			switch (mMode)
			{
			case eMode.MODE_DIAGNOSTIC:
				if (ISOMain.EXBVReset)
				{
					if (ISOMain.stepEXBV < 3)
					{
						mTest = (byte)(message[start + 4] ^ 4);
						StartDiagRoutine(9, (mTest != 9) ? 2 : 0);
					}
					else
					{
						SwitchMode(eMode.MODE_READ_SENSORS);
					}
				}
				if (ISOMain.ISCVReset)
				{
					mTest = (byte)(message[start + 4] ^ 0xC);
					StartDiagRoutine(10, (mTest != 7) ? 2 : 0);
				}
				if (mTest == 2)
				{
					SwitchMode(eMode.MODE_READ_SENSORS);
				}
				break;
			case eMode.MODE_STOP_DIAG:
				if (ISOMain.ISCVReset)
				{
					StartDiagRoutine(11, 0);
					ISOMain.SettingTPS();
				}
				break;
			}
			break;
		case 124:
			switch (message[start + 4])
			{
			case 3:
				dataSensor[63] = BuildString(message, start + 6, 4, ascii: true, nozero: false);
				bData = 1;
				SendReadBlock(bData);
				break;
			case 4:
				dataSensor[63] = dataSensor[63] + BuildString(message, start + 5, 2, ascii: true, nozero: false);
				ISOMain.DisplayMsg(dataSensor[63], 112);
				bData = 3;
				SendReadBlock(bData);
				break;
			case 8:
				dataSensor[64] = BuildString(message, start + 5, 5, ascii: false, nozero: false);
				dataSensor[66] = pCount + " / " + ((csMap[14] << 8) | csMap[15]).ToString("X2");
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 63] + ((csMap[22] << 8) + csMap[23]).ToString("X2") + "\r", 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 211] + dataSensor[64] + "\r", 32);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 67] + dataSensor[65] + " (" + baseMap + ")\r", 32);
				ISOMain.DisplayMsg("", 16);
				ISOMain.DisplayMsg("", 96);
				SwitchMode(eMode.MODE_READ_PIDS);
				break;
			}
			break;
		case 127:
			switch (message[start + 4])
			{
			case 0:
				ISOFT.rFlag = 0;
				OBDReply();
				break;
			case 51:
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 208], 32);
				ISOMain.DisplayMsg(".\r", 32);
				SwitchMode(eMode.MODE_NULL);
				break;
			case 129:
				unsupportedTest();
				break;
			}
			break;
		case 227:
			if ((message[start + 4] == 35) & (mTrim > 5))
			{
				mTrim += 64;
			}
			mMode = eMode.MODE_READ_SENSORS;
			SendSensorQuery();
			break;
		}
	}

	private static void KWPReply(byte[] message, int start, int length)
	{
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Invalid comparison between Unknown and I4
		if (message[start + length - 1] != CalcChecksum(message, start, length - 1))
		{
			return;
		}
		if (ISOMain.KWP)
		{
			start++;
			length--;
			if (!mFlash & !mLoad)
			{
				Thread.Sleep(50);
			}
		}
		switch (message[start + 3])
		{
		case 67:
		case 71:
			SetDtcBuffer(20);
			CodesReceive(message, start + 3, length);
			if (--msgDTC == 0)
			{
				SwitchMode(eMode.MODE_READ_SENSORS);
			}
			else
			{
				ISOFT.FTDWrite(null, 11, echo: false, line: false);
			}
			break;
		case 68:
			clearCodes--;
			if (clearCodes == 0)
			{
				if (iDST == 1)
				{
					newSession(0);
				}
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 235], 32);
				ISOMain.listCodesUpdate(ISOMain.LangUI[ISOMain.mLang, 241], status: false);
			}
			else if (clearCodes > 0)
			{
				newSession(1);
			}
			break;
		case 81:
			ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 219], 32);
			Thread.Sleep(200);
			ISOFT.SetMessage(eMessage.END_DOWNLOAD);
			break;
		case 90:
			switch (message[start + 4])
			{
			case 1:
				if (mLoad)
				{
					if (dataSensor[63] != BuildString(message, start + 5, 17, ascii: true, nozero: false))
					{
						mMode = eMode.MODE_ABORT;
						ISOFT.SetMessage(eMessage.ERR_FAILED);
						Thread.Sleep(300);
					}
					else
					{
						SwitchLoad(!reLoad);
					}
					break;
				}
				if (iDST == 0)
				{
					dataSensor[63] = BuildString(message, start + 5, 17, ascii: true, nozero: false);
				}
				dataSensor[iDST * 20 + 64] = BuildString(message, start + 16, 6, ascii: true, nozero: false);
				ISOMain.DisplayMsg(dataSensor[63], 112);
				bData++;
				SendReadBlock(bData);
				break;
			case 2:
				if (iDST == 0)
				{
					ECUTyp = ((message[start + 5] & 0xF) << 20) | ((message[start + 6] & 0xF) << 16) | ((message[start + 7] & 0xF) << 12) | ((message[start + 16] & 0xF) << 8) | ((message[start + 17] & 0xF) << 4) | ((message[start + 14] - 1) & 0xF);
					ISOMain._LC4 = ECUTyp == 7667712;
					IMap.CheckMapID(ECUTyp, 1);
					ISOMain._2nECU = ISOMain._LC4;
				}
				else
				{
					ECUTyp2 = ((message[start + 5] & 0xF) << 20) | ((message[start + 6] & 0xF) << 16) | ((message[start + 7] & 0xF) << 12) | ((message[start + 16] & 0xF) << 8) | ((message[start + 17] & 0xF) << 4) | ((message[start + 14] - 1) & 0xF);
				}
				if (ISOMain._LC4 | (iDST == 1))
				{
					ISOMain.DisplayMsg("\r#" + (char)message[start + 14] + " ", 32);
				}
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 64] + BuildString(message, start + 5, 14, ascii: true, nozero: false) + "\r", 32);
				bData++;
				SendReadBlock(bData);
				break;
			case 5:
				if (iDST == 0)
				{
					baseMap = BuildString(message, start + 12, 5, ascii: true, nozero: false);
					Array.Copy(message, start + 5, csMap, 4, 16);
					csMap[20] = (byte)(((message[start + 12] & 0xF) << 4) | (message[start + 13] & 0xF));
					csMap[21] = message[start + 16];
					ISOMain.eInfo = 0;
					ISOMain.SetUInterface(1);
					setSensor(ISOMain.swMode);
					ISOMain.RevCount = ((!ISOMain._LC4) ? 2 : 0);
				}
				else
				{
					baseMap2 = BuildString(message, start + 12, 5, ascii: true, nozero: false);
					Array.Copy(message, start + 5, csMap2, 4, 16);
					csMap2[20] = (byte)(((message[start + 12] & 0xF) << 4) | (message[start + 13] & 0xF));
					csMap2[21] = message[start + 16];
				}
				dataSensor[iDST * 20 + 65] = BuildString(message, start + 5, 16, ascii: true, nozero: false);
				bData++;
				SendReadBlock(bData);
				break;
			case 18:
				Array.Copy(message, start + 5, (iDST == 0) ? csMap : csMap2, 22, 2);
				bData = 14;
				SendReadBlock(bData);
				break;
			case 32:
				dataSensor[iDST * 20 + 66] = ((message[start + 8] << 8) | message[start + 9]).ToString("X2");
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 211] + dataSensor[iDST * 20 + 64] + "\r", 32);
				if (iDST == 0)
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 63] + ((csMap[22] << 8) + csMap[23]).ToString("X2") + "\r", 32);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 67] + dataSensor[iDST * 20 + 65] + " (" + baseMap + ")\r", 32);
				}
				else
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 63] + ((csMap2[22] << 8) + csMap2[23]).ToString("X2") + "\r", 32);
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 67] + dataSensor[iDST * 20 + 65] + " (" + baseMap2 + ")\r", 32);
				}
				ISOMain.DisplayMsg("", 16);
				ISOMain.DisplayMsg("", 96);
				if (!mId & ISOMain._2nECU & ISOMain._LC4)
				{
					mId = true;
					newSession(1);
				}
				else if (mId & (iDST == 1))
				{
					newSession(0);
				}
				else
				{
					SwitchMode(eMode.MODE_READ_SENSORS);
				}
				if (((mId & (iDST == 0)) | !ISOMain._2nECU) && ((ISOMain.swMode != 0) & (readCodes == 0)))
				{
					ISOMain.listCodesUpdate("", status: true);
				}
				break;
			case 49:
				if (mFlash)
				{
					if ((BitConverter.ToUInt64(message, start + 5) & ISOMain.pForce) == (IdVersion[Tune.idBoot] & ISOMain.pForce))
					{
						aWrite = safe | (BitConverter.ToInt32((iDST == 0) ? csMap : csMap2, 20) != BitConverter.ToInt32(IMap.mHeader, 20));
						setupFlash();
						SwitchMode(eMode.MODE_SPEED_COM);
					}
					else
					{
						mFlash = false;
						mMode = eMode.MODE_ACCESS;
						ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 322], 32);
						Thread.Sleep(200);
						ISOFT.SetMessage(eMessage.ERR_VERSION_MAP);
					}
				}
				else
				{
					bData = 12;
					SendReadBlock(bData);
				}
				break;
			}
			break;
		case 97:
		{
			byte b3 = message[start + 4];
			if (b3 != 128)
			{
				break;
			}
			string text = "{0:x}";
			ECUTyp = (message[start + 17] << 16) | (message[start + 18] << 8) | message[start + 19];
			int num6 = (message[start + 31] << 16) | (message[start + 32] << 8) | message[start + 33];
			if (mFlash)
			{
				int num7 = IMap.identifyMap(csMap, 20, -1);
				if ((num7 >= 8) & (num7 <= 12))
				{
					text = "{0:x6}";
				}
				baseMap = string.Format(text, num6);
				aWrite = safe | (BitConverter.ToInt32(csMap, 20) != BitConverter.ToInt32(IMap.mHeader, 20));
				if (IMap.CheckMapID(ECUTyp, 0) < 4)
				{
					setupFlash();
					ISOFT.checkSagem = false;
					AM = (byte)(ISOMain.sagemECU ? 133u : 5u);
					SwitchMode(eMode.MODE_ACCESS);
				}
				else
				{
					mFlash = false;
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 322], 32);
					Thread.Sleep(200);
					ISOFT.SetMessage(eMessage.ERR_VERSION_MAP);
				}
			}
			else if (mSafe & (mMode != eMode.MODE_NULL))
			{
				mMode = eMode.MODE_NULL;
				if (message[start + 5] != byte.MaxValue)
				{
					if ((int)ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 202], 9) == 1)
					{
						ISOMain.sRecovery = true;
					}
					ISOMain.me.breakConnection(msg: false);
				}
			}
			else if (mLoad)
			{
				AM = (byte)(ISOMain.sagemECU ? 131u : 5u);
				SwitchLoad(start: true);
			}
			else
			{
				if (mMode == eMode.MODE_NULL)
				{
					break;
				}
				string text2 = "";
				mId = true;
				Array.Copy(message, start + 20, csMap, 8, 16);
				int num8 = IMap.CheckMapID(ECUTyp, 1) & 0xFFFF;
				int num7 = IMap.identifyMap(csMap, 20, -2);
				if (num7 >= 0)
				{
					num8 = (int)Tune.mType[num7 * 8 + 4];
					ISOMain.avTest = (int)(Tune.mType[num7 * 8 + 5] & 0xFF);
					if ((num8 >= 8) & (num8 <= 12))
					{
						text = "{0:x6}";
					}
				}
				baseMap = string.Format(text, num6);
				if (ISOMain.sagemECU)
				{
					num7 = (message[start + 23] << 16) | (message[start + 24] << 8) | message[start + 25];
					num6 = ((num8 <= 12) ? IDSagem(num7) : 0);
					text2 = ((text == "{0:x6}") ? string.Format(text, num7) : ((num6 != 0) ? string.Format(text, num6) : baseMap));
					ISOMain._2ndT = false;
					ISOMain._Flap = false;
					ISOMain._Apri = text == "{0:x6}";
					ISOMain._Bene = (num8 & 0xFFFE) == 14;
					ISOMain._Twin = false;
					ISOMain._Four = false;
					ISOMain.noLoop = (num8 < 5) | (num8 == 7);
					ISOMain._sagemF = (num8 == 3) | (num8 == 4) | (num8 == 7);
					ISOFT.checkSagem = true;
				}
				else
				{
					num7 = (message[start + 31] << 16) | (message[start + 24] << 8) | message[start + 25];
					text2 = string.Format(text, num7);
					ISOMain.ISCDiff = (ECUTyp >> 8 == 8194) | (ECUTyp >> 8 == 8200);
					ISOMain._Four = ECUTyp >> 8 == 8192;
					ISOMain._Apri = false;
					ISOMain._Bene = false;
					ISOMain._Twin = (num8 & 0xFFF8) == 72;
					ISOMain._2ndT = (num8 & 0xFF78) == 64;
					ISOMain._Flap = (num8 & 0xFF28) == 40;
				}
				ISOMain.RevCount = ((((num8 & 0xFF20) == 32) | ISOMain._Four | ISOMain._sagemF) ? 1 : (((num8 & 0xFF50) != 64) ? 2 : 0));
				string text3 = (ECUTyp >> 8).ToString("X2") + "-" + (ECUTyp & 0xFF).ToString("X2");
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 64] + text3 + "\r", 32);
				dataSensor[65] = text2;
				pCount = (message[start + 36] << 8) | message[start + 37];
				if ((csMap[14] & csMap[15] & csMap[22] & csMap[23]) < 255)
				{
					mMode = eMode.MODE_NULL;
					Initialization(51);
				}
				else
				{
					AM = 5;
					SwitchMode(eMode.MODE_ACCESS);
				}
			}
			break;
		}
		case 98:
			switch (mMode)
			{
			case eMode.MODE_READ_SENSORS:
				if (readSensor == AllSensor)
				{
					for (int i = 0; i < readSensor.Length / 2; i++)
					{
						if ((readSensor[i * 2] == dSensor) & (readSensor[i * 2 + 1] < 4))
						{
							readSensor[i * 2 + 1] = 3;
						}
					}
				}
				if (readCodes > 0)
				{
					if (readCodes == 2)
					{
						ISOMain.tCode = true;
					}
					ISOMain.refreshCode = -2;
					readCodes--;
					SendActiveCodeQuery();
				}
				else if (clearCodes > 0)
				{
					SendClearCodesQuery();
				}
				else
				{
					SendSensorQuery();
				}
				ISensor.DataSensorReceive(message, start + 4);
				break;
			case eMode.MODE_DIAGNOSTIC:
				SendDiagnosticMsg();
				break;
			}
			break;
		case 99:
			if (readRow >= 0)
			{
				if (readBuffer == null)
				{
					Array.Copy(message, start + 4, IMap.memoMap, readRow + (aRead ? addrRead : ((addrRead & 0xFFFF) | 0x80000)), ISOMain.sBloc);
				}
				else
				{
					Array.Copy(message, start + 4, readBuffer, readRow, ISOMain.sBloc);
				}
				dataRow += ISOMain.sBloc;
				readRow += ISOMain.sBloc;
				rstLoad = 0;
				ISOFT.rLoad = 0;
				if (readBuffer == null)
				{
					readRow = IMap.ReadNextBloc(addrRead, readRow);
				}
				if (ISOFT.mMessage != eMessage.ERR_ABORT)
				{
					ISOFT.rFlag = 0;
					if (dataRow < readLen)
					{
						SendReadData();
						break;
					}
					mMode = eMode.MODE_DOWNLOAD_EXIT;
					ISOFT.SetMessage(eMessage.END_DOWNLOAD);
					ISOMain.ProgressBarInit(0);
					Thread.Sleep(300);
				}
				else
				{
					mMode = eMode.MODE_ABORT;
				}
			}
			else if (ISOMain._KTM)
			{
				if ((rVersion == 0) & (BitConverter.ToUInt16(message, start + 10) != 4357))
				{
					rVersion = 1;
					SetReadMemory(16384, 32, -32);
				}
				else if ((rVersion == 1) & (BitConverter.ToUInt16(message, start + 10) != 4357))
				{
					rVersion = 2;
					SetReadMemory(23552, 32, -32);
				}
				else if ((rVersion == 2) & (BitConverter.ToUInt16(message, start + 10) != 4357))
				{
					rVersion = 255;
					SetReadMemory(24320, 32, -32);
				}
				else if (safe)
				{
					if ((BitConverter.ToUInt64(message, start + 17) & ISOMain.pForce) == (IdVersion[Tune.idBoot] & ISOMain.pForce))
					{
						aWrite = true;
						setupFlash();
						SwitchMode(eMode.MODE_SPEED_COM);
						break;
					}
					mFlash = false;
					mSafe = false;
					mMode = eMode.MODE_ACCESS;
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 322], 32);
					Thread.Sleep(200);
					ISOFT.SetMessage(eMessage.ERR_VERSION_MAP);
				}
				else
				{
					SwitchMode(eMode.MODE_READ_DATA_BLOCK);
				}
			}
			else
			{
				int num3 = ((message[start + 29] == 2) ? 8 : 0);
				int num4 = ((message[start + 34] << 8) | message[start + 35]) & ((csMap[num3 + 14] << 8) | csMap[num3 + 15]);
				csMap[num3 + 14] = (byte)(num4 >> 8);
				csMap[num3 + 15] = (byte)num4;
				if (num3 == 8)
				{
					SetReadMemory(393216, 32, -32);
					break;
				}
				mMode = eMode.MODE_NULL;
				Initialization(51);
			}
			break;
		case 103:
			AM = message[start + 4];
			switch (AM)
			{
			case 3:
			case 5:
				SendKey(CalculateKey((message[start + 5] << 8) | message[start + 6]));
				break;
			case 4:
				ISOMain._KTM = true;
				ISOMain.mECU = 2;
				ISOMain.tRetry = 0;
				bData = 8;
				ISOMain.infosConnect(2);
				if (mLoad)
				{
					SwitchMode(eMode.MODE_READ_DATA_BLOCK);
				}
				else if (!mId)
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 206], 32);
					ISOMain.DisplayMsg("", 96);
					ISOMain.enableMenuItems(mMode, 0);
					rVersion = 0;
					SetReadMemory(24576, 32, -32);
					mMode = eMode.MODE_READ_DATA_BLOCK;
				}
				else if ((iDST == 1) & (readCodes + clearCodes == 0))
				{
					rVersion = 0;
					SetReadMemory(24576, 32, -32);
					mMode = eMode.MODE_READ_DATA_BLOCK;
				}
				else
				{
					SwitchMode(eMode.MODE_READ_SENSORS);
				}
				if ((mId & ISOMain._LC4 & !ISOMain._2nECU) && ((ISOMain.swMode != 0) & (readCodes == 0)))
				{
					ISOMain.listCodesUpdate("", status: true);
				}
				break;
			case 6:
				if (mFlash & !safe)
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 206], 32);
				}
				ISOMain.infosConnect(2);
				if (ISOMain.KWP)
				{
					rVersion = 0;
					ISOMain._KTM = true;
					if (safe)
					{
						SetReadMemory(24576, 32, -32);
					}
					else if (mFlash)
					{
						bData = 14;
						SwitchMode(eMode.MODE_READ_DATA_BLOCK);
					}
				}
				else if (mLoad)
				{
					ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 217], 32);
					ISOMain.ProgressBarInit(readLen / ISOMain.sBloc);
					SwitchMode(eMode.MODE_READ_MEM);
				}
				else if (mFlash)
				{
					SwitchMode(eMode.MODE_START_PROG);
				}
				else
				{
					SetReadMemory(327680, 32, -32);
				}
				break;
			case 131:
			case 133:
				SendKey(CalculateKey((message[start + 5] << 8) | message[start + 6]));
				break;
			case 132:
			case 134:
				ISOMain.infosConnect(2);
				SwitchMode(eMode.MODE_SPEED_COM);
				break;
			}
			break;
		case 113:
			switch (message[start + 4])
			{
			case 144:
				if (ISOMain.sagemECU)
				{
					SwitchMode(eMode.MODE_START_DOWNLOAD);
				}
				else if (ISOMain._KTM)
				{
					SwitchMode(eMode.MODE_DOWNLOAD);
				}
				else
				{
					SwitchMode(eMode.MODE_SPEED_COM);
				}
				break;
			case 145:
			{
				int num2 = ((ISOMain.sRecovery | safe) ? 2 : 0);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, num2 + 214], 32);
				ISOMain.ProgressBarInit(0);
				SwitchMode(eMode.MODE_ECU_RESET);
				break;
			}
			default:
				if ((message[start + 4] & 0xA0) == 160)
				{
					rTest = 0;
					ISOMain.testTick = ((mTest == 49) ? (-20) : 0);
					ISOMain.onTest = true;
				}
				SwitchMode(eMode.MODE_READ_SENSORS);
				break;
			}
			break;
		case 114:
			if ((message[start + 4] & 0xA0) == 160)
			{
				rTest = 0;
			}
			SwitchMode(eMode.MODE_READ_SENSORS);
			break;
		case 116:
		{
			byte b = message[start + 4];
			if (b == 68)
			{
				ISOMain.nop = -1;
				if (ISOMain._KTM)
				{
					Thread.Sleep(500);
					SwitchMode(eMode.MODE_START_PROG);
				}
				else
				{
					Thread.Sleep(340);
					SwitchMode(eMode.MODE_DOWNLOAD);
				}
			}
			break;
		}
		case 118:
			ISOMain.nop = -1;
			IMap.flashRow += (ISOMain._KTM ? 136 : 38);
			if (IMap.flashRow < IMap.flashMemo.Length)
			{
				SendTransfertData();
			}
			else
			{
				SwitchMode(eMode.MODE_DOWNLOAD_EXIT);
			}
			break;
		case 119:
			if (ISOMain._KTM)
			{
				int num5 = ((ISOMain.sRecovery | safe) ? 2 : 0);
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, num5 + 214], 32);
				ISOMain.ProgressBarInit(0);
				SwitchMode(eMode.MODE_ECU_RESET);
			}
			else
			{
				SwitchMode(eMode.MODE_END_PROG);
			}
			break;
		case 126:
			ISOFT.rFlag = 0;
			OBDReply();
			break;
		case 127:
			switch (message[start + 4])
			{
			case 26:
				if (ISOMain.tRetry++ > 3)
				{
					ISOFT.SetMessage(eMessage.ERR_NO_SEED);
				}
				break;
			case 35:
			{
				byte b2 = message[start + 5];
				if (b2 == 51 && mLoad)
				{
					ISOFT.SetMessage(eMessage.ERR_TIMEOUT);
				}
				break;
			}
			case 39:
				ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 209], 32);
				Thread.Sleep(200);
				ISOFT.SetMessage(eMessage.ERR_AUTHENTIFY);
				break;
			case 49:
			{
				int wait = 0;
				if (message[start + 5] == 130)
				{
					ISOFT.rFlag = 4;
					Thread.Sleep(200);
					ISOFT.SetMessage(eMessage.ERR_FAILED);
					break;
				}
				if (message[start + 5] == 145)
				{
					wait = 500;
				}
				if (ISOMain.sagemECU)
				{
					SendWaitBusy(message[start + 4], wait);
				}
				break;
			}
			case 54:
				if (ISOMain.sagemECU)
				{
					SendWaitBusy(message[start + 4], 0);
				}
				else
				{
					SwitchMode(eMode.MODE_DOWNLOAD);
				}
				break;
			case 55:
				if (ISOMain.sagemECU)
				{
					SendWaitBusy(message[start + 4], 250);
				}
				break;
			default:
				readCodes = 0;
				clearCodes = 0;
				break;
			case 0:
				break;
			}
			break;
		case 226:
		case 229:
		{
			int num = (mLoad ? readLen : IMap.flashSize);
			ISOMain.enableMenuItems(mMode, 0);
			ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, mLoad ? 217 : 213], 32);
			ISOMain.ProgressBarInit(num / ISOMain.sBloc);
			bData = 0;
			ISOMain.tDebug = -1;
			switch (message[start + 4])
			{
			case 74:
				ISOFT.FTHiSpeed(62500u, purge: true);
				Thread.Sleep(60);
				SwitchMode(eMode.MODE_START_DOWNLOAD);
				break;
			case 129:
				ISOFT.FTHiSpeed(57600u, purge: true);
				Thread.Sleep(100);
				if (mLoad)
				{
					SwitchMode(eMode.MODE_READ_MEM);
				}
				else
				{
					SwitchMode(eMode.MODE_START_PROG);
				}
				break;
			case 128:
				if (mLoad)
				{
					SwitchMode(eMode.MODE_READ_MEM);
				}
				else
				{
					SwitchMode(eMode.MODE_START_DOWNLOAD);
				}
				break;
			case 130:
				ISOFT.FTHiSpeed(62400u, purge: true);
				Thread.Sleep(600);
				if (mLoad)
				{
					SwitchMode(eMode.MODE_READ_MEM);
				}
				else
				{
					SwitchMode(eMode.MODE_START_DOWNLOAD);
				}
				break;
			}
			break;
		}
		}
	}

	private static void OBDReply()
	{
		switch (mMode)
		{
		case eMode.MODE_SEED:
			SendSeed();
			break;
		case eMode.MODE_READ_DATA_BLOCK:
			SendReadBlock(bData);
			break;
		case eMode.MODE_READ_PIDS:
			SendPidQuery();
			break;
		case eMode.MODE_READ_ACTIVE:
			SwitchMode(eMode.MODE_READ_SENSORS);
			break;
		case eMode.MODE_READ_SENSORS:
			if (readSensor == AllSensor)
			{
				for (int i = 0; i < readSensor.Length / 2; i++)
				{
					if ((readSensor[i * 2] == dSensor) & (readSensor[i * 2 + 1] < 4))
					{
						readSensor[i * 2 + 1]--;
					}
				}
			}
			SendSensorQuery();
			break;
		case eMode.MODE_DIAGNOSTIC:
		case eMode.MODE_STOP_DIAG:
			if (ISOMain.tRetry++ > 3)
			{
				unsupportedTest();
			}
			else
			{
				SendDiagnosticMsg();
			}
			break;
		case eMode.MODE_SAGEM_CMD:
			if (ISOFT.rFlag > 3)
			{
				SwitchMode(eMode.MODE_READ_SENSORS);
			}
			else
			{
				SendSagemCmd();
			}
			break;
		}
	}

	private static void unsupportedTest()
	{
		ISOMain.tRetry = 0;
		ISOMain.btnTest = -1;
		ISOMain.onTest = false;
		ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 280] + "\r", 32);
		ISOMain.DisplayMsg(ISOMain.LangUI[ISOMain.mLang, 280], 64);
		SwitchMode(eMode.MODE_READ_SENSORS);
	}

	public static string BuildString(byte[] sByte, int start, int length, bool ascii, bool nozero)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = start; i < start + length; i++)
		{
			if (ascii)
			{
				if (sByte[i] == 0)
				{
					break;
				}
				stringBuilder.Append((char)sByte[i]);
			}
			else
			{
				stringBuilder.Append(sByte[i].ToString("X2"));
			}
		}
		if (nozero)
		{
			while ((stringBuilder.Length > 0) & (stringBuilder[0] == '0'))
			{
				stringBuilder.Remove(0, 1);
			}
		}
		return stringBuilder.ToString();
	}

	public static byte String2Byte(byte[] hByte, int start)
	{
		int num = hByte[start];
		if ((num >= 48) & (num < 58))
		{
			num -= 48;
		}
		else if ((num >= 65) & (num < 91))
		{
			num -= 55;
		}
		int num2 = hByte[start + 1];
		if ((num2 >= 48) & (num2 < 58))
		{
			num2 -= 48;
		}
		else if ((num2 >= 65) & (num2 < 91))
		{
			num2 -= 55;
		}
		return (byte)((num << 4) | num2);
	}

	public static string String2Char(byte[] hByte, int start, int length, bool ascii)
	{
		bool flag = false;
		byte[] array = new byte[length / 2];
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			flag = false;
			int num = hByte[start + i * 2];
			if ((num >= 48) & (num < 58))
			{
				num -= 48;
			}
			else if ((num >= 65) & (num < 91))
			{
				num -= 55;
			}
			else
			{
				flag = true;
			}
			int num2 = hByte[start + i * 2 + 1];
			if ((num2 >= 48) & (num2 < 58))
			{
				num2 -= 48;
			}
			else if ((num2 >= 65) & (num2 < 91))
			{
				num2 -= 55;
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				array[i] = (byte)((num << 4) | num2);
			}
			else
			{
				array[i] = (byte)(ascii ? 63u : 0u);
			}
			if (ascii & (array[i] == 0))
			{
				break;
			}
			stringBuilder.Append((char)array[i]);
		}
		if (flag & !ascii)
		{
			return null;
		}
		return stringBuilder.ToString();
	}

	public static int byte2String(byte b)
	{
		byte b2 = (byte)(b & 0xF);
		byte b3 = (byte)((b >> 4) & 0xF);
		if (b3 < 10)
		{
			b3 += 48;
		}
		else if (b3 >= 10)
		{
			b3 += 55;
		}
		if (b2 < 10)
		{
			b2 += 48;
		}
		else if (b2 >= 10)
		{
			b2 += 55;
		}
		return (b3 << 8) | b2;
	}

	private static void setWalbroRead(int addr, int len)
	{
		int num;
		for (int i = 0; i < 3; i++)
		{
			num = byte2String((byte)((addr >> i * 8) & 0xFF));
			Walbro_ReadMem[9 - i * 2] = (byte)num;
			Walbro_ReadMem[8 - i * 2] = (byte)(num >> 8);
		}
		num = byte2String((byte)len);
		Walbro_ReadMem[11] = (byte)num;
		Walbro_ReadMem[10] = (byte)(num >> 8);
	}

	public static void breakSensor()
	{
		SendWalbroInit();
		SendWalbroInit();
		Thread.Sleep(200);
		mMode = eMode.MODE_NULL;
	}

	public static void SetReadData(byte[] buffer, int addr, int length)
	{
		if (buffer == null)
		{
			addrRead = IMap.flashTable[0];
		}
		else
		{
			addrRead = addr;
		}
		readBuffer = (ISOMain._Walbro ? new byte[ISOMain.sBloc] : buffer);
		readLen = length;
		IMap.flashRow = 0;
		dataRow = 0;
		readRow = 0;
		mLoad = true;
		reLoad = false;
		iRetry = 0;
		if (ISOMain.KWP)
		{
			newSession(qDST);
		}
		else if (ISOMain._Walbro)
		{
			ISOMain.mDebug = 0;
			ISOMain.tDebug = -1;
			breakSensor();
		}
		else
		{
			mMode = eMode.MODE_NULL;
			Initialization(213);
		}
	}

	public static void FlashIt(bool mode)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		safe = mode;
		mFlash = true;
		mLoad = false;
		iRetry = 0;
		ISOMain.notryCnx = false;
		if (ISOMain._Walbro)
		{
			ISOMain.mDebug = 0;
			ISOMain.tDebug = -1;
			ISOMain.infosConnect(0);
			SendWalbroInit();
			Thread.Sleep(2500);
			ISOMain.me.cReadTimer.Stop();
			ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 344], 3);
			ISOMain.me.cReadTimer.Start();
			aWrite = true;
			setupFlash();
			ISOFT.openSerialPort(9600);
			SwitchMode(eMode.MODE_NULL);
		}
		else if (!ISOMain._KTM)
		{
			mMode = eMode.MODE_NULL;
			((Control)ISOMain.me.panelTable).Invalidate();
			Initialization(213);
		}
		else
		{
			if (!ISOMain.sRecovery)
			{
				iDST = (((ISOMain.TypTable & 0xFFF0) == 1024) ? 1 : 0);
			}
			if ((ISOMain.mDebug & 2) > 0)
			{
				ISOMain.WriteTrcFile(null, 0, 0, "\r\n" + ISOMain.mapName);
			}
			ISOFT.SetflagOut(-1);
			SwitchMode(eMode.MODE_NULL);
		}
	}

	public static void KWPInit()
	{
		Init = 0;
		mSafe = false;
		ISOFT.FTHiSpeed(360u, purge: false);
		ISOFT.SetBreak(0);
		Thread.Sleep(200);
		ISOFT.SetBreak(1);
		Stopwatch stopwatch = new Stopwatch();
		if ((ISOMain.mDebug & 1) == 1)
		{
			stopwatch.Start();
		}
		SendZero();
		Thread.Sleep(50);
		ISOFT.FTHiSpeed(10400u, purge: true);
		if (stopwatch.IsRunning)
		{
			stopwatch.Stop();
			int len = (int)stopwatch.ElapsedMilliseconds;
			ISOMain.WriteTrcFile(null, 0, len, ":");
		}
		SwitchMode(eMode.MODE_INIT);
	}

	public static void SendWalbroInit()
	{
		ISOFT.serialWrite(Walbro_Init, 5, csum: true);
		Thread.Sleep(100);
	}

	public static void WalbroInitialization()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		if (iRetry == -2)
		{
			return;
		}
		if (iRetry > 15)
		{
			ISOMain.me.cReadTimer.Stop();
			iRetry = -1;
			if (!ISOMain.notryCnx)
			{
				ISOMain.notryCnx = (int)ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 222], 9) == 2;
				ISOMain.enableMenuItems(mMode, ISOMain.notryCnx ? 4 : 0);
			}
			if (ISOMain.notryCnx & mFlash)
			{
				ISOMain.me.breakConnection(msg: false);
			}
			ISOMain.me.cReadTimer.Start();
		}
		else
		{
			if (iRetry == -1)
			{
				iRetry++;
			}
			iRetry++;
			if (mFlash)
			{
				uBuffer = new byte[1];
				uBuffer[0] = 0;
				ISOFT.serialWrite(uBuffer, 1, csum: false);
				Thread.Sleep(50);
			}
			else
			{
				SendWalbroInit();
			}
		}
	}

	public static void Initialization(int c)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		if (iRetry == -2)
		{
			return;
		}
		mSafe = false;
		ISOMain.me.cReadTimer.Stop();
		if (iRetry == 3 && (ISOFT.checkSagem & (ISOMain.TypTable < 16) & (ISOMain.swMode == 0)))
		{
			c = 213;
			mSafe = true;
		}
		if (iRetry > 3)
		{
			iRetry = -1;
			ISOFT.rSafe = 0;
			if (!ISOMain.notryCnx)
			{
				ISOMain.notryCnx = (int)ISOMain.DisplayBox("", ISOMain.LangUI[ISOMain.mLang, 222], 9) == 2;
			}
			if (mFlash | mLoad)
			{
				mFlash = false;
				mLoad = false;
			}
			ISOMain.me.breakConnection(msg: false);
			ISOMain.me.cReadTimer.Start();
			return;
		}
		if (ISOMain.mLed > 1)
		{
			ISOMain.infosConnect(1);
		}
		((Control)ISOMain.me.BtnLeft).Enabled = false;
		((Control)ISOMain.me.BtnMid).Enabled = false;
		((Control)ISOMain.me.BtnRight).Enabled = false;
		if (mFlash | mLoad)
		{
			c = 213;
		}
		if (iRetry == -1)
		{
			iRetry++;
		}
		iRetry++;
		byte b = 0;
		Stopwatch stopwatch = new Stopwatch();
		c = c * 4 + 1025;
		for (int i = 0; i < 11; i++)
		{
			Thread.Sleep(ISOMain.pTiming);
			if ((ISOMain.mDebug & 1) == 1)
			{
				if (!stopwatch.IsRunning)
				{
					stopwatch.Start();
				}
				else
				{
					stopwatch.Stop();
					int len = (int)stopwatch.ElapsedMilliseconds;
					stopwatch.Reset();
					ISOMain.WriteTrcFile(null, 0, len, ":");
					stopwatch.Start();
				}
			}
			byte b2 = (byte)(c & 1);
			if (b2 != b)
			{
				ISOFT.SetBreak(b2);
			}
			b = b2;
			c /= 2;
		}
		if (stopwatch.IsRunning)
		{
			stopwatch.Stop();
		}
		ISOFT.FTDWrite(null, 3, echo: false, line: false);
		ISOMain.me.cReadTimer.Start();
		if (!mFlash & !mLoad)
		{
			((Control)ISOMain.me.BtnLeft).Enabled = true;
			((Control)ISOMain.me.BtnMid).Enabled = true;
			((Control)ISOMain.me.BtnRight).Enabled = true;
		}
	}
}
