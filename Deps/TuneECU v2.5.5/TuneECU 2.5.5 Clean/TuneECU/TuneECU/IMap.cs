using System;
using System.Text;
using System.Windows.Forms;
using TuneLibrary;

namespace TuneECU
{

public class IMap : ISOMain
{
	private static int[] addrTable;

	private static int[] cmpTable;

	public static byte[] umodMap;

	public static byte[] cmpMap;

	public static byte[] flashMemo;

	public static byte[] memoMap;

	public static byte[] defnMap;

	public static byte[] mHeader;

	public static byte[] signMap;

	public static int flashSize;

	public static int flashRow;

	public static int MapID;

	public static int cmpOff;

	public static int TypMap;

	public static int offMap;

	public static int[] flashTable;

	public static string idFile;

	public static int memoSize = 655360;

	private static int umodSize = 131072;

	private static int iAddr = 40;

	public static int[] paramIndex = new int[32];

	public static int[] mapTable = new int[iAddr];

	public static short[] cRPM;

	public static short[] iRPM;

	public static short[] icRPM;

	public static short[] gRPM;

	public static short[] mRPM;

	public static short[] mcRPM;

	public static short[] _Load;

	public static short[] Throttle;

	public static short[] defThrottle = new short[20]
	{
		0, 10, 20, 30, 40, 50, 60, 80, 100, 150,
		200, 250, 300, 350, 400, 500, 600, 700, 800, 1000
	};

	public static short[] sThrottle = new short[208]
	{
		0, 10, 20, 30, 40, 50, 60, 90, 130, 160,
		190, 230, 290, 430, 720, 1000, 0, 10, 30, 50,
		60, 70, 100, 140, 210, 280, 390, 480, 560, 700,
		830, 1000, 0, 10, 20, 40, 50, 70, 90, 120,
		140, 180, 220, 270, 370, 500, 750, 1000, 0, 10,
		20, 40, 50, 70, 90, 120, 140, 180, 220, 270,
		370, 500, 750, 1000, 0, 10, 30, 50, 60, 70,
		100, 130, 190, 250, 360, 440, 520, 640, 770, 1000,
		0, 10, 30, 40, 50, 60, 70, 90, 120, 180,
		230, 340, 410, 600, 700, 1000, 0, 10, 20, 40,
		50, 70, 90, 120, 140, 180, 220, 270, 370, 500,
		750, 1000, 0, 10, 20, 40, 60, 100, 160, 220,
		290, 390, 490, 620, 730, 820, 920, 1000, 0, 10,
		30, 50, 60, 70, 100, 130, 210, 280, 400, 490,
		570, 710, 840, 1000, 0, 10, 30, 50, 60, 70,
		100, 130, 210, 280, 400, 490, 570, 710, 840, 1000,
		0, 10, 30, 50, 60, 70, 100, 130, 210, 280,
		400, 490, 570, 710, 840, 1000, 0, 10, 20, 40,
		60, 100, 160, 220, 290, 390, 490, 620, 730, 820,
		920, 1000, 0, 40, 70, 100, 110, 120, 150, 190,
		240, 310, 390, 470, 530, 630, 770, 1000
	};

	public static short[] sLoad = new short[48]
	{
		0, 9, 12, 15, 18, 22, 27, 32, 41, 49,
		58, 66, 76, 87, 97, 100, 0, 10, 19, 22,
		29, 33, 37, 42, 49, 55, 62, 71, 80, 91,
		98, 100, 0, 18, 20, 22, 24, 27, 30, 33,
		37, 41, 44, 48, 55, 60, 67, 80
	};

	public static short[] sTemp = new short[16]
	{
		-10, -4, 4, 14, 24, 34, 44, 54, 64, 74,
		84, 90, 94, 99, 109, 130
	};

	public static short[] sGear;

	public static short[] defRev = new short[32]
	{
		800, 1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600,
		2800, 3000, 3200, 3400, 3600, 4000, 4500, 5000, 5500, 6000,
		6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000, 10500, 11000,
		11500, 12000
	};

	public static int identifyMap(byte[] data, int start, int set)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		uint num = 0u;
		int num2 = 0;
		int num3 = 0;
		int i;
		for (i = 0; i < 4; i++)
		{
			num = (num << 8) | data[start + i];
		}
		for (i = 0; i < Tune.mType.Length / 8 && Tune.mType[i * 8] != num; i++)
		{
		}
		if (i < Tune.mType.Length / 8)
		{
			int num4 = (int)(Tune.mType[i * 8 + 2] * 32);
			int num5 = num4;
			while ((num3 < 32) & (Tune.eBloc[num4 + 1] != 0))
			{
				num3 += 2;
				num4 += 2;
				num2 += 2;
			}
			switch (set)
			{
			case 1:
			{
				addrTable = new int[num2];
				for (num4 = 0; num4 < num2; num4++)
				{
					addrTable[num4] = (int)Tune.eBloc[num5 + num4];
				}
				int num6 = -32;
				for (num4 = 0; num4 < num2 / 2; num4++)
				{
					if (addrTable[num4 * 2] < num6 + 32)
					{
						i = -3;
					}
					num6 = addrTable[num4 * 2];
				}
				if (i < 0)
				{
					ISOMain.DisplayBox("", "TuneLibrary data error !\rCan't open the file...", 2);
				}
				else if (Tune.mType[i * 8 + 4] < 16)
				{
					Array.Copy(ToArray((int)Tune.mType[i * 8 + 6]), 0, ISORead.csMap, 24, 4);
				}
				break;
			}
			case 0:
				cmpTable = new int[num2];
				for (num4 = 0; num4 < num2; num4++)
				{
					cmpTable[num4] = (int)Tune.eBloc[num5 + num4];
				}
				break;
			case -1:
				return (int)Tune.mType[i * 8 + 4];
			}
			return i;
		}
		return -1;
	}

	public static int getAddr(int type, int off)
	{
		if (type < 0)
		{
			return type;
		}
		return Tune.eAddr[Tune.mType[type * 8 + 1] * iAddr + off];
	}

	public static bool codecMap(byte[] data, bool mode)
	{
		byte b = 0;
		byte b2 = 0;
		int num = 4;
		uint num2 = BitConverter.ToUInt32(data, 0) | 0x80808080u;
		if (data == null)
		{
			return false;
		}
		while (num < data.Length)
		{
			byte b3 = (byte)(b2++ % 4 * 8);
			byte b4 = (byte)(data[num] ^ b ^ ((num2 >> (int)b3) & 0xFF));
			b = ((!mode) ? data[num] : b4);
			data[num++] = b4;
		}
		return true;
	}

	public static byte[] encodeHex(StringBuilder sInfo, byte[] sTrim)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = (mapTable[0] & 0xFF) << 12;
		int num9 = mapTable[0] & 0xF0000;
		num3 = addrTable.Length;
		for (int i = 0; i < num3 / 2; i++)
		{
			num4 += addrTable[i * 2 + 1];
		}
		if (sTrim != null)
		{
			num2 = sTrim.Length;
		}
		byte[] array = new byte[num4 + sInfo.Length + num3 * 4 + num2 + 42];
		num2 = 402920288 + ((ISOMain.TypTable > 2048) ? 8 : ((ISOMain.TypTable < 16) ? 4 : ((ISOMain.TypTable >= 80) ? 1 : 7)));
		if ((ISOMain.TypTable > 5) & (ISOMain.TypTable < 80))
		{
			Array.Copy(ToArray(13684944), 0, mHeader, 8, 3);
			Array.Copy(ToArray(13684944), 0, mHeader, 16, 3);
		}
		Array.Copy(ToArray(num2), 0, mHeader, 0, 4);
		Array.Copy(mHeader, array, 28);
		Array.Copy(ToArray(sInfo.Length), 0, array, 28, 2);
		num2 = 0;
		while (num2 < sInfo.Length)
		{
			array[num2 + 30] = (byte)sInfo[num2++];
		}
		num2 += 30;
		Array.Copy(ToArray(7300718), 0, array, num2, 3);
		num2 += 3;
		array[num2++] = (byte)(num3 / 2);
		if (ISOMain.TypTable >= 16)
		{
			num = MapChecksum(num8, apply: false);
		}
		for (int i = 0; i < num3; i++)
		{
			Array.Copy(ToArray(addrTable[i]), 0, array, num2, 4);
			num2 += 4;
		}
		for (int j = 0; j < num3 / 2; j++)
		{
			int num10 = addrTable[j * 2];
			for (int i = 0; i < addrTable[j * 2 + 1]; i++)
			{
				byte b = memoMap[num10 + i];
				array[num2++] = b;
				if (num10 < num9)
				{
					num5 += b;
					if (num10 >= num8)
					{
						num6 += b;
					}
				}
				else
				{
					num7 += b;
				}
			}
		}
		if (ISOMain.TypTable < 16)
		{
			num = (BitConverter.ToInt16(mHeader, 24) - num6) & 0xFFFF;
		}
		if (ISOMain.TypTable < 80)
		{
			array[14] = (byte)(num >> 8);
			array[15] = (byte)(num & 0xFF);
		}
		Array.Copy(ToArray(num5), 0, array, num2, 4);
		Array.Copy(ToArray(num7), 0, array, num2 + 4, 4);
		if (sTrim != null)
		{
			Array.Copy(sTrim, 0, array, num2 + 8, sTrim.Length);
		}
		codecMap(array, mode: true);
		return array;
	}

	public static int CheckMapID(int id, int ix)
	{
		if (ix == 0)
		{
			if (ISOMain.sagemECU)
			{
				if (((id >> 8) & 3) != ((MapID >> 8) & 3))
				{
					return 4;
				}
				return 0;
			}
			if (id != MapID)
			{
				return 4;
			}
			return 0;
		}
		ISOMain.avTest = 31;
		int i;
		for (i = 0; i < Tune.mType.Length / 8 && Tune.mType[i * 8 + 3] != (uint)id; i++)
		{
		}
		if (i < Tune.mType.Length / 8)
		{
			int num = (int)Tune.mType[i * 8 + 4];
			ISOMain.avTest = (int)(Tune.mType[i * 8 + 5] & 0xFF);
			ISOMain.avTrim = (int)((Tune.mType[i * 8 + 5] >> 8) & 0x3F);
			return i * 65536 + num;
		}
		return -1;
	}

	public static byte[] ToArray(int value)
	{
		byte[] array = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = (byte)(value & 0xFF);
			value >>= 8;
		}
		return array;
	}

	public static void BuildMemoryMap(byte[] dMap)
	{
		if (umodMap == null)
		{
			umodMap = new byte[umodSize];
		}
		mHeader = new byte[28];
		defnMap = new byte[16];
		signMap = new byte[8];
		Array.Copy(dMap, mHeader, 28);
		ISOMain.TypTable = (int)Tune.mType[TypMap * 8 + 4];
		int value = 402920288 + ((ISOMain.TypTable > 2048) ? 8 : ((ISOMain.TypTable < 16) ? 4 : ((ISOMain.TypTable >= 80) ? 1 : 7)));
		Array.Copy(ToArray(value), mHeader, 4);
		if (mHeader[0] != 97)
		{
			Array.Copy(mHeader, 8, defnMap, 0, 16);
			Array.Copy(mHeader, 8, signMap, 0, 8);
		}
		switch (mHeader[0])
		{
		case 100:
			SetSagemTable(TypMap, cMap: true);
			break;
		case 97:
		case 103:
			SetKeihinTable(TypMap, cMap: true);
			break;
		case 104:
			SetWalbroTable(TypMap, cMap: true);
			break;
		}
	}

	public static int MakeMemoryMap(byte[] buffer)
	{
		int num = 0;
		int result = -2;
		if (memoMap == null)
		{
			memoMap = new byte[memoSize];
		}
		if (umodMap == null)
		{
			umodMap = new byte[umodSize];
		}
		for (int i = 0; i < memoSize; i++)
		{
			memoMap[i] = byte.MaxValue;
		}
		if ((BitConverter.ToInt32(buffer, 0) & 0xFFFFFFF0u) == 402920288)
		{
			mHeader = new byte[28];
			defnMap = new byte[16];
			signMap = new byte[8];
			Array.Copy(buffer, 0, mHeader, 0, 28);
			TypMap = identifyMap(mHeader, 20, 1);
			if (TypMap < 0)
			{
				return TypMap - 2;
			}
			if (mHeader[0] != 97)
			{
				Array.Copy(mHeader, 8, defnMap, 0, 16);
				Array.Copy(mHeader, 8, signMap, 0, 8);
			}
			int num2 = addrTable.Length / 2;
			num = num2 * 8 + 30;
			for (int i = 0; i < num2; i++)
			{
				int num3 = addrTable[i * 2];
				int num4 = addrTable[i * 2 + 1];
				for (int j = 0; j < num4; j++)
				{
					memoMap[num3 + j] = buffer[num + j];
				}
				num += num4;
			}
			switch (mHeader[0])
			{
			case 100:
				result = SetSagemTable(TypMap, cMap: true);
				break;
			case 97:
			case 103:
				result = SetKeihinTable(TypMap, cMap: true);
				break;
			case 104:
				result = SetWalbroTable(TypMap, cMap: true);
				break;
			default:
				result = -3;
				break;
			}
		}
		return result;
	}

	public static int MakeCompareMap(byte[] buffer)
	{
		int num = 0;
		if (cmpMap == null)
		{
			cmpMap = new byte[umodSize];
		}
		for (int i = 0; i < umodSize; i++)
		{
			cmpMap[i] = byte.MaxValue;
		}
		int num2 = (mapTable[0] & 0xFF) << 12;
		int num3 = mapTable[0] & 0xFF000;
		if ((BitConverter.ToInt32(buffer, 0) & 0xFFFFFFF0u) == 402920288)
		{
			int num4 = identifyMap(buffer, 20, 0);
			if (num4 < 0)
			{
				return -1;
			}
			if (Tune.mType[num4 * 8 + 7] != Tune.mType[TypMap * 8 + 7])
			{
				return -4;
			}
			int num5 = (int)Tune.mType[num4 * 8 + 4];
			cmpOff = (int)Tune.mType[num4 * 8 + 1] * iAddr;
			int num6 = cmpTable.Length / 2;
			int i = 0;
			num = 0;
			int num7 = num6 * 8 + 30;
			for (; i < num6 && cmpTable[i * 2] < num2; i++)
			{
				num7 += cmpTable[i * 2 + 1];
			}
			for (; i < num6; i++)
			{
				num2 = cmpTable[i * 2];
				num = cmpTable[i * 2 + 1];
				if (cmpTable[i * 2] >= num3)
				{
					break;
				}
				for (int j = 0; j < num; j++)
				{
					cmpMap[(num2 & 0xFFFF) + j] = buffer[num7 + j];
				}
				num7 += num;
			}
			if (num5 < 16)
			{
				num7 = Tune.eAddr[cmpOff + 11] & 0xFFFF;
				mcRPM = new short[ISOMain.fREV];
				for (i = 0; i < ISOMain.fREV; i++)
				{
					mcRPM[i] = (short)(BitConverter.ToUInt16(cmpMap, num7 + i * 2) / ((num5 >= 2) ? 1 : 4));
				}
				FixRpmBug(mcRPM, rnd: true);
				num7 = Tune.eAddr[cmpOff + 21] & 0xFFFF;
				icRPM = new short[ISOMain.iREV];
				for (i = 0; i < ISOMain.iREV; i++)
				{
					icRPM[i] = (short)(BitConverter.ToUInt16(cmpMap, num7 + i * 2) / 4);
				}
				FixRpmBug(icRPM, rnd: true);
				paramIndex[16] = BitConverter.ToInt16(cmpMap, Tune.eAddr[cmpOff + 1]);
				if (num5 < 2)
				{
					paramIndex[17] = (int)Math.Round((double)(cmpMap[Tune.eAddr[cmpOff + 6]] - 55) * 0.7);
				}
				else
				{
					paramIndex[17] = (int)Math.Round((double)(cmpMap[Tune.eAddr[cmpOff + 6]] - 50) * 0.8);
				}
				paramIndex[18] = BitConverter.ToInt16(cmpMap, Tune.eAddr[cmpOff + 3]) * 25 / 96;
				if (Tune.eAddr[cmpOff + 7] != 0)
				{
					paramIndex[20] = BitConverter.ToInt16(cmpMap, Tune.eAddr[cmpOff + 7]) / 2;
				}
				for (i = 8; i < 14; i++)
				{
					if (Tune.eAddr[cmpOff + i + 25] != 0)
					{
						paramIndex[i + 16] = cmpMap[Tune.eAddr[cmpOff + i + 25] & 0xFFFF];
					}
				}
				ISOMain.me.displayParams(-1, -1);
			}
			else if (num5 < 2048)
			{
				num7 = Tune.eAddr[cmpOff + 10] & 0x1FFFF;
				mcRPM = new short[ISOMain.fREV];
				for (i = 0; i < ISOMain.fREV; i++)
				{
					mcRPM[i] = (short)((cmpMap[num7 + i * 2] << 8) | cmpMap[num7 + i * 2 + 1]);
				}
				num7 = Tune.eAddr[cmpOff + 8] & 0x1FFFF;
				icRPM = new short[ISOMain.iREV];
				for (i = 0; i < ISOMain.iREV; i++)
				{
					icRPM[i] = (short)((cmpMap[num7 + i * 2] << 8) | cmpMap[num7 + i * 2 + 1]);
				}
				paramIndex[16] = (cmpMap[Tune.eAddr[cmpOff + 1]] << 8) | cmpMap[Tune.eAddr[cmpOff + 1] + 1];
				if (Tune.eAddr[cmpOff + 6] != 0)
				{
					paramIndex[17] = ((cmpMap[Tune.eAddr[cmpOff + 6]] << 8) | cmpMap[Tune.eAddr[cmpOff + 6] + 1]) / 10;
				}
				paramIndex[18] = 65535;
				if (Tune.eAddr[cmpOff + 4] != 0)
				{
					paramIndex[19] = (cmpMap[Tune.eAddr[cmpOff + 4]] << 8) | cmpMap[Tune.eAddr[cmpOff + 4] + 1];
				}
				if (Tune.eAddr[cmpOff + 7] != 0)
				{
					paramIndex[20] = (cmpMap[Tune.eAddr[cmpOff + 7]] << 8) | cmpMap[Tune.eAddr[cmpOff + 7] + 1];
				}
				if (Tune.eAddr[cmpOff + 32] != 0)
				{
					int j = Tune.eAddr[cmpOff + 32] & 0xFFFF;
					paramIndex[21] = (cmpMap[j] << 10) | (cmpMap[j + 1] << 5) | cmpMap[j + 2];
					j = (Tune.eAddr[cmpOff + 32] >> 16) & 0xFFFF;
					if (j > 0)
					{
						int num8 = (((cmpMap[j] << 8) | cmpMap[j + 1]) / 100 << 16) | (((cmpMap[j + 2] << 8) | cmpMap[j + 3]) / 100 << 24);
						paramIndex[21] += num8;
					}
				}
				for (i = 8; i < 14; i++)
				{
					if (Tune.eAddr[cmpOff + i + 25] != 0)
					{
						paramIndex[i + 16] = cmpMap[Tune.eAddr[cmpOff + i + 25] & 0xFFFF];
					}
				}
				ISOMain.me.displayParams(-1, -1);
			}
			return 0;
		}
		return -2;
	}

	public static void SetFlashTable(int type, int addr, bool full)
	{
		int i = 0;
		int num = 0;
		flashSize = 0;
		flashTable = null;
		if (type < 0)
		{
			return;
		}
		if (full)
		{
			flashTable = addrTable;
			for (i = 0; i < flashTable.Length / 2; i++)
			{
				flashSize += (addrTable[i * 2 + 1] + (ISOMain.sBloc - 1)) / ISOMain.sBloc;
			}
		}
		else if (type < 16)
		{
			for (; i < addrTable.Length / 2 && addrTable[i * 2] < addr; i++)
			{
			}
			flashTable = new int[2];
			flashTable[0] = addr;
			flashTable[1] = addrTable[i * 2 + 1];
			flashSize = (flashTable[1] + (ISOMain.sBloc - 1)) / ISOMain.sBloc;
		}
		else
		{
			for (; i < addrTable.Length / 2; i++)
			{
				if (addrTable[i * 2] == addr)
				{
					num = i;
				}
			}
			flashTable = new int[(i - num) * 2];
			Array.Copy(addrTable, num * 2, flashTable, 0, flashTable.Length);
			for (i = 0; i < flashTable.Length / 2; i++)
			{
				flashSize += (flashTable[i * 2 + 1] + (ISOMain.sBloc - 1)) / ISOMain.sBloc;
			}
		}
		flashSize *= ISOMain.sBloc;
	}

	public static void BuildFlashMap()
	{
		int num = ISOMain.today.Year % 100;
		int month = ISOMain.today.Month;
		int day = ISOMain.today.Day;
		int num3;
		if (ISOMain.TypTable < 16)
		{
			int num2 = MapChecksum(0, apply: true);
			signMap[6] = (byte)(num2 >> 8);
			signMap[7] = (byte)(num2 & 0xFF);
			Array.Copy(signMap, 6, mHeader, 14, 2);
			if ((signMap[0] == 208) & (signMap[1] == 208) & (signMap[2] == 208))
			{
				signMap[0] = (byte)(num / 10 * 16 + num % 10);
				signMap[1] = (byte)(month / 10 * 16 + month % 10);
				signMap[2] = (byte)(day / 10 * 16 + day % 10);
			}
			num3 = (mapTable[0] & 0xFF) << 12;
		}
		else
		{
			num3 = (mapTable[0] & 0xF0) << 12;
			int num2 = MapChecksum(num3, apply: true);
			signMap[6] = (byte)(num2 >> 8);
			signMap[7] = (byte)(num2 & 0xFF);
			if (ISOMain.TypTable < 80)
			{
				Array.Copy(signMap, 6, mHeader, 14, 2);
				signMap[0] = (byte)(num / 10 * 16 + num % 10);
				signMap[1] = (byte)(month / 10 * 16 + month % 10);
				signMap[2] = (byte)(day / 10 * 16 + day % 10);
			}
		}
		SetFlashTable(ISOMain.TypTable, num3, full: false);
		MakeMemoryFlash(flashSize / ISOMain.sBloc);
		flashRow = 0;
	}

	public static void BuildRestoreMap()
	{
		int num = 0;
		int num2 = ISOMain.today.Year % 100;
		int month = ISOMain.today.Month;
		int day = ISOMain.today.Day;
		int num3 = (mapTable[0] & 0xFF) << 12;
		if (ISOMain.TypTable < 16)
		{
			int num4 = 524288;
			for (num = 0; num < 131072; num++)
			{
				memoMap[num4 + num] = memoMap[num];
			}
			ApplyTrims(num4, ISOMain.TypTable);
			int num5 = MapChecksum(num4, apply: false);
			defnMap[6] = (byte)(num5 >> 8);
			defnMap[7] = (byte)(num5 & 0xFF);
			Array.Copy(defnMap, 6, mHeader, 14, 2);
			if ((defnMap[0] == 208) & (defnMap[1] == 208) & (defnMap[2] == 208))
			{
				defnMap[0] = (byte)(num2 / 10 * 16 + num2 % 10);
				defnMap[1] = (byte)(month / 10 * 16 + month % 10);
				defnMap[2] = (byte)(day / 10 * 16 + day % 10);
				defnMap[8] = defnMap[0];
				defnMap[9] = defnMap[1];
				defnMap[10] = defnMap[2];
			}
		}
		else
		{
			int num5 = MapChecksum(num3, apply: true);
			defnMap[6] = (byte)(num5 >> 8);
			defnMap[7] = (byte)(num5 & 0xFF);
			if (ISOMain.TypTable < 80)
			{
				Array.Copy(defnMap, 6, mHeader, 14, 2);
				defnMap[0] = (byte)(num2 / 10 * 16 + num2 % 10);
				defnMap[1] = (byte)(month / 10 * 16 + month % 10);
				defnMap[2] = (byte)(day / 10 * 16 + day % 10);
				defnMap[8] = defnMap[0];
				defnMap[9] = defnMap[1];
				defnMap[10] = defnMap[2];
			}
		}
		SetFlashTable(ISOMain.TypTable, num3, full: true);
		MakeMemRestore(flashSize / ISOMain.sBloc);
		flashRow = 0;
	}

	private static void MakeMemoryFlash(int count)
	{
		int num = 0;
		int num2 = 0;
		int num3 = (ISOMain._KTM ? 136 : 38);
		int num4 = 524288;
		int num5 = 0;
		int num6 = (mapTable[0] & 0xF0) << 12;
		flashMemo = new byte[count * num3];
		for (int i = 0; i < flashTable.Length / 2; i++)
		{
			int num7 = flashTable[i * 2];
			int num8 = flashTable[i * 2 + 1] / ISOMain.sBloc;
			byte b = (byte)(flashTable[i * 2 + 1] - num8 * ISOMain.sBloc);
			int j;
			for (j = 0; j < num8; j++)
			{
				if (ISOMain.TypTable >= 16)
				{
					num5 = (num7 - num6) & 0x10000;
				}
				num2 = num + j * num3;
				byte b2 = (byte)(num7 >> 8);
				byte b3 = (byte)num7;
				flashMemo[num2++] = 54;
				flashMemo[num2++] = (byte)(num7 >> 16);
				flashMemo[num2++] = b2;
				flashMemo[num2++] = b3;
				flashMemo[num2++] = (byte)ISOMain.sBloc;
				if (!ISOMain._KTM)
				{
					flashMemo[num2++] = 0;
				}
				for (int k = 0; k < ISOMain.sBloc; k++)
				{
					flashMemo[num2++] = memoMap[num4 + num5 + (num7 & 0xFFFF) + k];
				}
				num7 += ISOMain.sBloc;
				if (ISOMain._KTM)
				{
					flashMemo[num2++] = (byte)(num7 >> 16);
					flashMemo[num2++] = (byte)(num7 >> 8);
					flashMemo[num2++] = (byte)num7;
					b = 0;
				}
			}
			if (b > 0)
			{
				num2 = num + j * num3;
				byte b2 = (byte)(num7 >> 8);
				byte b3 = (byte)num7;
				flashMemo[num2++] = 54;
				flashMemo[num2++] = (byte)(num7 >> 16);
				flashMemo[num2++] = b2;
				flashMemo[num2++] = b3;
				flashMemo[num2++] = b;
				flashMemo[num2++] = 0;
				for (int k = 0; k < ISOMain.sBloc; k++)
				{
					if (k < b)
					{
						flashMemo[num2] = memoMap[num4 + num5 + (num7 & 0xFFFF) + k];
					}
					num2++;
				}
			}
			num = num2;
		}
		if (ISOMain.TypTable >= 16)
		{
			if (ISOMain._KTM)
			{
				num2 -= 3;
				flashMemo[num2] = 0;
				flashMemo[num2 + 1] = 0;
				flashMemo[num2 + 2] = 0;
			}
			flashMemo[num2 - 2] = signMap[6];
			flashMemo[num2 - 1] = signMap[7];
		}
	}

	private static void MakeMemRestore(int count)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = (mapTable[0] & 0xF0) << 12;
		int num6 = (ISOMain._KTM ? 136 : (ISOMain._Walbro ? 37 : 38));
		int num7 = (ISOMain._Walbro ? 1 : 0);
		flashMemo = new byte[(count + num7) * num6];
		for (int i = 0; i < flashTable.Length / 2; i++)
		{
			int num9;
			int num10;
			int num8;
			if (ISOMain.TypTable < 2048)
			{
				num8 = flashTable[i * 2];
				num9 = ((num8 >= num5) ? 524288 : 0);
				num10 = flashTable[i * 2 + 1] / ISOMain.sBloc;
				byte b = (byte)(flashTable[i * 2 + 1] - num10 * ISOMain.sBloc);
				for (num7 = 0; num7 < num10; num7++)
				{
					if (num9 > 0)
					{
						num4 = (num8 - num5) & 0x10000;
					}
					num2 = num + num7 * num6;
					byte b2 = (byte)(num8 >> 8);
					byte b3 = (byte)num8;
					flashMemo[num2++] = 54;
					flashMemo[num2++] = (byte)(num8 >> 16);
					flashMemo[num2++] = b2;
					flashMemo[num2++] = b3;
					flashMemo[num2++] = (byte)ISOMain.sBloc;
					if (!ISOMain._KTM)
					{
						flashMemo[num2++] = 0;
					}
					for (int j = 0; j < ISOMain.sBloc; j++)
					{
						flashMemo[num2++] = memoMap[num9 + num4 + (num8 & ((num9 == 0) ? 16777215 : 65535)) + j];
					}
					num8 += ISOMain.sBloc;
					if (ISOMain._KTM)
					{
						flashMemo[num2++] = (byte)(num8 >> 16);
						flashMemo[num2++] = (byte)(num8 >> 8);
						flashMemo[num2++] = (byte)num8;
						b = 0;
					}
				}
				if (b > 0)
				{
					num2 = num + num7 * num6;
					byte b2 = (byte)(num8 >> 8);
					byte b3 = (byte)num8;
					flashMemo[num2++] = 54;
					flashMemo[num2++] = (byte)(num8 >> 16);
					flashMemo[num2++] = b2;
					flashMemo[num2++] = b3;
					flashMemo[num2++] = b;
					flashMemo[num2++] = 0;
					for (int j = 0; j < ISOMain.sBloc; j++)
					{
						if (j < b)
						{
							flashMemo[num2] = memoMap[num9 + num4 + (num8 & ((num9 == 0) ? 16777215 : 65535)) + j];
						}
						num2++;
					}
				}
				num = num2;
				continue;
			}
			num8 = flashTable[i * 2];
			num9 = ((num8 >= num5) ? 524288 : 0);
			num10 = flashTable[i * 2 + 1] / ISOMain.sBloc;
			for (num7 = 0; num7 < num10; num7++)
			{
				num = 0;
				if (num9 > 0)
				{
					num4 = (num8 - num5) & 0x10000;
				}
				flashMemo[num2++] = 0;
				byte b = (byte)(num8 >> 16);
				flashMemo[num2++] = b;
				num += b;
				b = (byte)(num8 >> 8);
				flashMemo[num2++] = b;
				num += b;
				b = (byte)num8;
				flashMemo[num2++] = b;
				num += b;
				for (int j = 0; j < ISOMain.sBloc; j++)
				{
					b = memoMap[num9 + num4 + (num8 & ((num9 == 0) ? 16777215 : 65535)) + j];
					flashMemo[num2++] = b;
					num += b;
				}
				flashMemo[num2++] = (byte)(num - 139);
				num8 += ISOMain.sBloc;
				num3++;
			}
			if (num3 == count)
			{
				num = 0;
				num8 = 131040;
				flashMemo[num2++] = 0;
				byte b = (byte)(num8 >> 16);
				flashMemo[num2++] = b;
				num += b;
				b = (byte)(num8 >> 8);
				flashMemo[num2++] = b;
				num += b;
				b = (byte)num8;
				flashMemo[num2++] = b;
				num += b;
				for (int j = 0; j < ISOMain.sBloc - 2; j++)
				{
					b = byte.MaxValue;
					flashMemo[num2++] = b;
					num += b;
				}
				b = defnMap[6];
				flashMemo[num2++] = b;
				num += b;
				b = defnMap[7];
				flashMemo[num2++] = b;
				num += b;
				flashMemo[num2++] = (byte)(num - 139);
			}
		}
		if ((ISOMain.TypTable >= 16) & (ISOMain.TypTable < 2048))
		{
			if (ISOMain._KTM)
			{
				num2 -= 3;
				flashMemo[num2] = 0;
				flashMemo[num2 + 1] = 0;
				flashMemo[num2 + 2] = 0;
			}
			flashMemo[num2 - 2] = defnMap[6];
			flashMemo[num2 - 1] = defnMap[7];
		}
	}

	public static int ReadNextBloc(int addr, int row)
	{
		if (addr + row >= flashTable[flashRow] + flashTable[flashRow + 1])
		{
			flashRow += 2;
			if (flashRow == flashTable.Length)
			{
				return ISORead.readLen;
			}
			ISORead.addrRead = flashTable[flashRow];
			return 0;
		}
		return row;
	}

	public static void WalbroParams(int ms, bool mode)
	{
		int num = (mapTable[0] & 0xF0) << 12;
		string text = (ISOMain.altMap ? " (Map 1)" : " (Map 0)");
		TreeNode val = ISOMain.mTvMap(1);
		TreeNode val2 = ISOMain.mTvMap(2);
		val.Text = (((int)val.Tag == 8) ? (ISOMain.LangUI[ISOMain.mLang, 72] + text) : "");
		val2.Text = (((int)val2.Tag == 8) ? (ISOMain.LangUI[ISOMain.mLang, 138] + text) : "");
		if (ISOMain.showMod & ISOMain.compareF & mode)
		{
			paramIndex[16] = (cmpMap[Tune.eAddr[cmpOff + 1] + ms] << 8) | cmpMap[Tune.eAddr[cmpOff + 1] + ms + 1];
			if (Tune.eAddr[cmpOff + 5] != 0)
			{
				paramIndex[19] = (cmpMap[Tune.eAddr[cmpOff + 5] + ms] << 8) | cmpMap[Tune.eAddr[cmpOff + 5] + ms + 1];
			}
			if (Tune.eAddr[cmpOff + 6] != 0)
			{
				paramIndex[17] = (int)Math.Round((double)(int)cmpMap[Tune.eAddr[cmpOff + 6] + ms] / 1.6 - 30.0);
			}
			for (int i = 8; i < 12; i++)
			{
				if (Tune.eAddr[cmpOff + i + 25] != 0)
				{
					paramIndex[i + 16] = cmpMap[(Tune.eAddr[cmpOff + i + 25] + ms) & 0xFFFF];
				}
			}
			return;
		}
		paramIndex[0] = (memoMap[num + ms + mapTable[1]] << 8) | memoMap[num + ms + mapTable[1] + 1];
		if (mapTable[5] != 0)
		{
			paramIndex[3] = (memoMap[num + ms + mapTable[5]] << 8) | memoMap[num + ms + mapTable[5] + 1];
		}
		if (mapTable[6] != 0)
		{
			paramIndex[1] = (int)Math.Round((double)(int)memoMap[num + ms + mapTable[6]] / 1.6 - 30.0);
		}
		for (int j = 8; j < 12; j++)
		{
			if (mapTable[j + 25] != 0)
			{
				paramIndex[j] = memoMap[num + ms + (mapTable[j + 25] & 0xFFFF)];
			}
		}
		Array.Copy(paramIndex, 0, paramIndex, 16, 16);
	}

	public static int SetWalbroTable(int tm, bool cMap)
	{
		int num = (int)Tune.mType[tm * 8 + 1];
		MapID = (int)Tune.mType[tm * 8 + 3];
		int num2 = (int)Tune.mType[tm * 8 + 4];
		for (int i = 0; i < iAddr; i++)
		{
			mapTable[i] = Tune.eAddr[num * iAddr + i];
		}
		int num3 = (mapTable[0] & 0xF0) << 12;
		idFile = ISORead.BuildString(mHeader, 4, 16, ascii: true, nozero: false);
		ISOMain.fREV = (mapTable[10] >> 16) & 0xFE;
		ISOMain.sREV = ISOMain.fREV;
		ISOMain.iREV = ISOMain.fREV;
		ISOMain.mPOS = 16;
		int num4 = num3 + (mapTable[10] & 0x1FFFF);
		mRPM = new short[ISOMain.fREV];
		for (int i = 0; i < ISOMain.fREV; i++)
		{
			mRPM[i] = (short)((memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1]);
		}
		mcRPM = mRPM;
		iRPM = mRPM;
		icRPM = iRPM;
		ISOMain.gREV = 0;
		Throttle = new short[ISOMain.mPOS];
		num4 = num3 + mapTable[27];
		double num5 = (float)(int)memoMap[num4 + ISOMain.mPOS - 1] / 1000f;
		for (int i = 0; i < ISOMain.mPOS; i++)
		{
			num = memoMap[num4 + i];
			double num6 = Math.Round((double)num / num5);
			num = (int)num6;
			Throttle[i] = (short)num;
		}
		offMap = mapTable[37];
		for (int i = 1; i < 16; i++)
		{
			paramIndex[i] = 65535;
		}
		num = (int)((Tune.mType[tm * 8 + 6] >> 8) & 0xFF);
		if (num == 0)
		{
			paramIndex[7] = mapTable[2];
		}
		else
		{
			paramIndex[7] = Tune.kRevMax[num];
		}
		WalbroParams(0, mode: false);
		int num7 = 524288;
		for (int i = 0; i < 131072; i++)
		{
			memoMap[num7 + i] = memoMap[num3 + i];
		}
		ApplyTrims(num7, num2);
		if (cMap)
		{
			CopyUMap();
		}
		return num2;
	}

	public static int SetKeihinTable(int tm, bool cMap)
	{
		int num = (int)Tune.mType[tm * 8 + 1];
		MapID = (int)Tune.mType[tm * 8 + 3];
		int num2 = (int)Tune.mType[tm * 8 + 4];
		for (int i = 0; i < iAddr; i++)
		{
			mapTable[i] = Tune.eAddr[num * iAddr + i];
		}
		int num3 = (mapTable[0] & 0xF0) << 12;
		if (num2 < 80)
		{
			idFile = ((mHeader[19] << 16) | (mHeader[20] << 8) | mHeader[21]).ToString("X2");
		}
		else
		{
			idFile = ISORead.BuildString(mHeader, 11, 5, ascii: true, nozero: false);
		}
		ISOMain.fREV = (mapTable[10] >> 16) & 0xFE;
		ISOMain.sREV = ISOMain.fREV;
		ISOMain.iREV = ISOMain.fREV;
		ISOMain.mPOS = 20;
		int num4 = num3 + (mapTable[10] & 0x1FFFF);
		mRPM = new short[ISOMain.fREV];
		for (int i = 0; i < ISOMain.fREV; i++)
		{
			mRPM[i] = (short)((memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1]);
		}
		mcRPM = mRPM;
		num4 = num3 + (mapTable[8] & 0x1FFFF);
		iRPM = new short[ISOMain.iREV];
		for (int i = 0; i < ISOMain.iREV; i++)
		{
			iRPM[i] = (short)((memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1]);
		}
		icRPM = iRPM;
		Throttle = new short[ISOMain.mPOS];
		num4 = num3 + mapTable[27];
		double num5 = (float)((memoMap[num4 + ISOMain.mPOS * 2 - 2] << 8) | memoMap[num4 + ISOMain.mPOS * 2 - 1]) / 1000f;
		for (int i = 0; i < ISOMain.mPOS; i++)
		{
			num = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
			double num6 = Math.Round((double)num / num5);
			num = (int)num6;
			Throttle[i] = (short)num;
		}
		if (((num2 & 0xFF78) == 64) & (mapTable[30] != 0))
		{
			ISOMain.gREV = 14;
			gRPM = new short[ISOMain.gREV];
			num4 = num3 + mapTable[30];
			for (int i = 0; i < ISOMain.gREV; i++)
			{
				gRPM[ISOMain.gREV - i - 1] = (short)((memoMap[num4 + i * 4] << 8) | memoMap[num4 + i * 4 + 1]);
			}
		}
		else
		{
			ISOMain.gREV = 0;
		}
		for (int i = 1; i < 16; i++)
		{
			paramIndex[i] = 65535;
		}
		paramIndex[0] = (memoMap[num3 + mapTable[1]] << 8) | memoMap[num3 + mapTable[1] + 1];
		if (mapTable[6] != 0)
		{
			paramIndex[1] = ((memoMap[num3 + mapTable[6]] << 8) | memoMap[num3 + mapTable[6] + 1]) / 10;
		}
		int num7;
		if (mapTable[3] != 0)
		{
			double num6 = (memoMap[num3 + mapTable[3]] << 8) | memoMap[num3 + mapTable[3] + 1];
			ISOMain.wRef = mHeader[27];
			if (ISOMain.wRef == 0)
			{
				GetInfosMap(ISOMain.idMap, num2);
				if (ISOMain.wRef > 0)
				{
					mHeader[27] = (byte)ISOMain.wRef;
				}
			}
			num7 = Tune.rWheel[ISOMain.wRef] * 1000;
			if (num7 > 0)
			{
				paramIndex[2] = (int)Math.Round((double)num7 / num6 - 1000.0);
			}
		}
		if (mapTable[4] != 0)
		{
			paramIndex[3] = (memoMap[num3 + mapTable[4]] << 8) | memoMap[num3 + mapTable[4] + 1];
		}
		if (mapTable[7] != 0)
		{
			paramIndex[4] = (memoMap[num3 + mapTable[7]] << 8) | memoMap[num3 + mapTable[7] + 1];
		}
		if (mapTable[32] != 0)
		{
			num = mapTable[32] & 0xFFFF;
			paramIndex[5] = (memoMap[num3 + num] << 10) | (memoMap[num3 + num + 1] << 5) | memoMap[num3 + num + 2];
			num = (mapTable[32] >> 16) & 0xFFFF;
			if (num > 0)
			{
				num7 = (((memoMap[num3 + num] << 8) | memoMap[num3 + num + 1]) / 100 << 16) | (((memoMap[num3 + num + 2] << 8) | memoMap[num3 + num + 3]) / 100 << 24);
				paramIndex[5] += num7;
			}
		}
		paramIndex[7] = GetRpmMax(num3, num2);
		for (int i = 8; i < 14; i++)
		{
			if (mapTable[i + 25] != 0)
			{
				paramIndex[i] = memoMap[num3 + (mapTable[i + 25] & 0xFFFF)];
			}
		}
		num4 = mapTable[39] & 0xFFFF;
		if (num4 > 0)
		{
			memoMap[num3 + num4] = 0;
		}
		num7 = 524288;
		for (int i = 0; i < 131072; i++)
		{
			memoMap[num7 + i] = memoMap[num3 + i];
		}
		ApplyTrims(num7, num2);
		Array.Copy(paramIndex, 0, paramIndex, 16, 16);
		if (cMap)
		{
			CopyUMap();
		}
		return num2;
	}

	public static int SetSagemTable(int tm, bool cMap)
	{
		string format = "{0:x}";
		int num = (int)Tune.mType[tm * 8 + 1];
		MapID = (int)Tune.mType[tm * 8 + 3];
		int num2 = (int)Tune.mType[tm * 8 + 4];
		int i;
		for (i = 0; i < iAddr; i++)
		{
			mapTable[i] = Tune.eAddr[num * iAddr + i];
		}
		if ((num2 >= 8) & (num2 <= 12))
		{
			format = "{0:x6}";
		}
		idFile = string.Format(format, (mHeader[19] << 16) | (mHeader[20] << 8) | mHeader[21]);
		int num3 = (mapTable[0] & 0xF0) << 12;
		int num4 = num3 + (mapTable[11] & 0xFFFF);
		ISOMain.fREV = mapTable[11] >> 16;
		ISOMain.mPOS = 16;
		ISOMain.iREV = ISOMain.mPOS;
		_Load = new short[ISOMain.mPOS];
		Throttle = new short[ISOMain.mPOS];
		i = ((num == 12) ? 32 : (((num == 2) | (num == 3) | (num == 6)) ? 16 : 0));
		Array.Copy(sLoad, i, _Load, 0, 16);
		Array.Copy(sThrottle, num * 16, Throttle, 0, 16);
		mRPM = new short[ISOMain.fREV];
		for (i = 0; i < ISOMain.fREV; i++)
		{
			mRPM[i] = (short)(BitConverter.ToUInt16(memoMap, num4 + i * 2) / ((num2 >= 2) ? 1 : 4));
		}
		ISOMain.sREV = FixRpmBug(mRPM, rnd: true);
		mcRPM = mRPM;
		num4 = num3 + (mapTable[21] & 0xFFFF);
		iRPM = new short[ISOMain.iREV];
		for (i = 0; i < ISOMain.iREV; i++)
		{
			iRPM[i] = (short)(BitConverter.ToUInt16(memoMap, num4 + i * 2) / 4);
		}
		FixRpmBug(iRPM, rnd: true);
		icRPM = iRPM;
		for (i = 1; i < 16; i++)
		{
			paramIndex[i] = 65535;
		}
		paramIndex[0] = BitConverter.ToInt16(memoMap, num3 + mapTable[1]);
		if (num2 < 2)
		{
			paramIndex[1] = (int)Math.Round((double)(memoMap[num3 + mapTable[6]] - 55) * 0.7);
		}
		else
		{
			paramIndex[1] = (int)Math.Round((double)(memoMap[num3 + mapTable[6]] - 50) * 0.8);
		}
		paramIndex[2] = BitConverter.ToInt16(memoMap, num3 + mapTable[3]) * 25 / 96;
		if (mapTable[7] != 0)
		{
			paramIndex[4] = BitConverter.ToInt16(memoMap, num3 + mapTable[7]) / 2;
		}
		FixRpmLimit();
		for (i = 8; i < 14; i++)
		{
			if (mapTable[i + 25] != 0)
			{
				paramIndex[i] = memoMap[num3 + (mapTable[i + 25] & 0xFFFF)];
			}
		}
		Array.Copy(paramIndex, 0, paramIndex, 16, 16);
		if (cMap)
		{
			CopyUMap();
		}
		return num2;
	}

	private static void FixRpmLimit()
	{
		int num = (int)Math.Round((double)mRPM[ISOMain.fREV - 1] * 1.06 / 200.0) * 200;
		if (mapTable[2] == 0)
		{
			paramIndex[7] = num;
		}
		else if (mapTable[2] < num)
		{
			paramIndex[7] = num;
		}
		else
		{
			paramIndex[7] = mapTable[2];
		}
	}

	private static int FixRpmBug(short[] table, bool rnd)
	{
		int num3;
		if (rnd)
		{
			int num = table.Length - 1;
			int num2 = (((table[num] - 2 == table[num - 1] - 1) & (table[num] - 2 == table[num - 2])) ? 100 : 0);
			for (int i = 0; i < 3; i++)
			{
				num3 = table[num - i] / 5 + (1 - i) * num2;
				table[num - i] = (short)(num3 * 5);
			}
			if (table[num] <= table[num - 1])
			{
				table[num] = (short)(table[num - 1] + 500);
			}
		}
		for (num3 = 0; num3 < table.Length && (num3 <= 15 || table[num3] != table[num3 - 1]); num3++)
		{
		}
		return num3;
	}

	public static void CopyUMap()
	{
		int num = (mapTable[0] & 0xF0) << 12;
		for (int i = 0; i < umodSize; i++)
		{
			umodMap[i] = memoMap[num + i];
		}
	}

	public static bool checkMapModif()
	{
		if (umodMap == null)
		{
			return false;
		}
		int num = (mapTable[0] & 0xF0) << 12;
		int i;
		for (i = 0; i < umodSize && umodMap[i] == memoMap[num + i]; i++)
		{
		}
		return i < umodSize;
	}

	public static void ApplyParams(int Index, int Value)
	{
		int num = 0;
		int num2 = 0;
		int num3 = (mapTable[0] & 0xF0) << 12;
		_ = mapTable[0];
		paramIndex[Index] = Value;
		if (ISOMain.altParams)
		{
			num = offMap;
		}
		switch (Index)
		{
		case 0:
		{
			int num4 = (((ISOMain.TypTable & 0xFFFC) == 92) ? 4 : ((((ISOMain.TypTable & 0xFF50) == 80) | ((ISOMain.TypTable & 0xFFF0) == 1024)) ? 2 : (((mapTable[0] & 0xFF) == 48) ? 8 : ((ISOMain.TypTable > 2048) ? 1 : 10))));
			if (ISOMain.TypTable < 16)
			{
				int num9 = ((ISOMain.TypTable >= 3) ? 1 : 2);
				int num8 = BitConverter.ToInt16(memoMap, num3 + mapTable[1]);
				num2 = paramIndex[0] - num8;
				for (int i = 0; i < 4; i++)
				{
					int num6 = (num9 - 1) * 4 - i * num9 * 2;
					num8 = BitConverter.ToInt16(memoMap, num3 + mapTable[1] + num6);
					memoMap[num3 + mapTable[1] + num6] = (byte)((num8 + num2) & 0xFF);
					memoMap[num3 + mapTable[1] + num6 + 1] = (byte)(num8 + num2 >> 8);
				}
				break;
			}
			for (int i = 0; i < num4; i++)
			{
				int num8 = (memoMap[num3 + num + mapTable[1] + i * 2] << 8) | memoMap[num3 + num + mapTable[1] + i * 2 + 1];
				if (i == 0)
				{
					num2 = paramIndex[0] - num8;
				}
				if (num8 > 4096)
				{
					memoMap[num3 + num + mapTable[1] + i * 2] = (byte)(num8 + num2 >> 8);
					memoMap[num3 + num + mapTable[1] + i * 2 + 1] = (byte)((num8 + num2) & 0xFF);
				}
			}
			break;
		}
		case 1:
			if (ISOMain.TypTable < 2)
			{
				int num8 = (int)((double)(memoMap[num3 + mapTable[6]] - 55) * 0.7);
				num2 = paramIndex[1] - num8;
				memoMap[num3 + mapTable[6]] = (byte)Math.Round((double)(num8 + num2) / 0.7 + 55.0);
				num8 = (int)((double)(memoMap[num3 + mapTable[6] - 1] - 55) * 0.7);
				memoMap[num3 + mapTable[6] - 1] = (byte)Math.Round((double)(num8 + num2) / 0.7 + 55.0);
			}
			else if (ISOMain.TypTable < 16)
			{
				int num8 = (int)((double)(memoMap[num3 + mapTable[6]] - 50) * 0.8);
				num2 = paramIndex[1] - num8;
				memoMap[num3 + mapTable[6]] = (byte)Math.Round((double)(num8 + num2) / 0.8 + 50.0);
				num8 = (int)((double)(memoMap[num3 + mapTable[6] - 1] - 50) * 0.8);
				memoMap[num3 + mapTable[6] - 1] = (byte)Math.Round((double)(num8 + num2) / 0.8 + 50.0);
				if (ISOMain.TypTable >= 8)
				{
					num8 = (int)((double)(memoMap[num3 + mapTable[6] + 1] - 50) * 0.8);
					memoMap[num3 + mapTable[6] + 1] = (byte)Math.Round((double)(num8 + num2) / 0.8 + 50.0);
				}
			}
			else if (ISOMain.TypTable > 2048)
			{
				int num8 = (int)Math.Round((double)(int)memoMap[num3 + num + mapTable[6]] / 1.6 - 30.0);
				num2 = paramIndex[1] - num8;
				memoMap[num3 + num + mapTable[6]] = (byte)Math.Round((double)(num8 + num2 + 30) * 1.6);
				num8 = (int)Math.Round((double)(int)memoMap[num3 + mapTable[6] + 1] / 1.6 - 30.0);
				memoMap[num3 + num + mapTable[6] + 1] = (byte)Math.Round((double)(num8 + num2 + 30) * 1.6);
			}
			else
			{
				int num8 = (memoMap[num3 + mapTable[6]] << 8) | memoMap[num3 + mapTable[6] + 1];
				num2 = paramIndex[1] * 10 - num8;
				memoMap[num3 + mapTable[6]] = (byte)(num8 + num2 >> 8);
				memoMap[num3 + mapTable[6] + 1] = (byte)((num8 + num2) & 0xFF);
				num8 = (memoMap[num3 + mapTable[6] + 2] << 8) | memoMap[num3 + mapTable[6] + 3];
				memoMap[num3 + mapTable[6] + 2] = (byte)(num8 + num2 >> 8);
				memoMap[num3 + mapTable[6] + 3] = (byte)((num8 + num2) & 0xFF);
			}
			break;
		case 2:
			if (ISOMain.TypTable < 16)
			{
				int num7 = (int)Math.Round((double)(paramIndex[2] * 96 / 25));
				memoMap[num3 + mapTable[3]] = (byte)(num7 & 0xFF);
				memoMap[num3 + mapTable[3] + 1] = (byte)(num7 >> 8);
			}
			else
			{
				int num7 = Tune.rWheel[mHeader[27]] * 1000 / (1000 + paramIndex[2]);
				memoMap[num3 + mapTable[3]] = (byte)(num7 >> 8);
				memoMap[num3 + mapTable[3] + 1] = (byte)(num7 & 0xFF);
			}
			break;
		case 3:
		{
			int num7;
			if (ISOMain.TypTable > 2048)
			{
				num7 = paramIndex[3];
				memoMap[num3 + num + mapTable[5]] = (byte)(num7 >> 8);
				memoMap[num3 + num + mapTable[5] + 1] = (byte)(num7 & 0xFF);
				break;
			}
			num7 = paramIndex[3];
			memoMap[num3 + mapTable[4]] = (byte)(num7 >> 8);
			memoMap[num3 + mapTable[4] + 1] = (byte)(num7 & 0xFF);
			if (ISOMain._Flap)
			{
				num7 = (int)((double)num7 * 0.96 / 100.0) * 100;
				memoMap[num3 + mapTable[4] + 2] = (byte)(num7 >> 8);
				memoMap[num3 + mapTable[4] + 3] = (byte)(num7 & 0xFF);
			}
			break;
		}
		case 4:
			if (ISOMain.TypTable < 16)
			{
				int num7 = paramIndex[4] * 2;
				memoMap[num3 + mapTable[7]] = (byte)(num7 & 0xFF);
				memoMap[num3 + mapTable[7] + 1] = (byte)(num7 >> 8);
			}
			else if (mapTable[7] != 0)
			{
				int num8 = (memoMap[num3 + mapTable[7]] << 8) | memoMap[num3 + mapTable[7] + 1];
				num2 = paramIndex[4] - num8;
				memoMap[num3 + mapTable[7]] = (byte)(num8 + num2 >> 8);
				memoMap[num3 + mapTable[7] + 1] = (byte)((num8 + num2) & 0xFF);
				num8 = (memoMap[num3 + mapTable[7] + 2] << 8) | memoMap[num3 + mapTable[7] + 3];
				memoMap[num3 + mapTable[7] + 2] = (byte)(num8 + num2 >> 8);
				memoMap[num3 + mapTable[7] + 3] = (byte)((num8 + num2) & 0xFF);
			}
			break;
		case 5:
		{
			int num7 = paramIndex[5];
			memoMap[num3 + (mapTable[32] & 0xFFFF)] = (byte)((num7 >> 10) & 0x1F);
			memoMap[num3 + ((mapTable[32] + 1) & 0xFFFF)] = (byte)((num7 >> 5) & 0x1F);
			memoMap[num3 + ((mapTable[32] + 2) & 0xFFFF)] = (byte)(num7 & 0x1F);
			memoMap[num3 + ((mapTable[32] + 6) & 0xFFFF)] = (byte)((num7 >> 5) & 0x1F);
			memoMap[num3 + ((mapTable[32] + 7) & 0xFFFF)] = (byte)(num7 & 0x1F);
			break;
		}
		default:
		{
			if (Index <= 7 || (mapTable[Index + 25] & 0xFFFF) == 0)
			{
				break;
			}
			int num4 = 0;
			int num5 = mapTable[Index + 25] >> 24;
			if (num5 > 63)
			{
				num4 = (num5 >> 4) - 3;
			}
			int num6 = (num5 & 0xF) + 1;
			for (int i = 0; i <= num4; i++)
			{
				memoMap[num3 + num + (mapTable[Index + 25] & 0xFFFF) + i * num6] = (byte)paramIndex[Index];
			}
			for (int i = 8; i < 14; i++)
			{
				if (((mapTable[i + 25] & 0xFFFF) == (mapTable[Index + 25] & 0xFFFF)) & (paramIndex[i] != 65535))
				{
					paramIndex[i] = paramIndex[Index];
				}
			}
			break;
		}
		}
		if ((ISOMain.TypTable & 0xFFE0) == 2048)
		{
			WalbroParams(ISOMain.altMap ? offMap : 0, mode: true);
		}
		ISOMain.me.displayParams(-1, -1);
		ISOMain.pSave = false;
	}

	public static void ConvertPcmd(short[] pThrottle, short[] pRev, double[] pTable, int ind)
	{
		int i = 0;
		double num = 0.0;
		byte[] array = new byte[4];
		double[] array2 = new double[64];
		int num2 = (414530 >> (byte)(ind >> 8) * 4) & 0xF;
		for (int j = 0; j < pThrottle.Length; j++)
		{
			int num3 = 0;
			short num4 = 0;
			double num5 = 0.0;
			for (int k = 0; k < ISOMain.fREV; k++)
			{
				if ((mRPM[k] > 0) & (num3 < pRev.Length) & (mRPM[k] <= pRev[^1]))
				{
					while (pRev[num3] < mRPM[k] && num3 < pRev.Length - 1)
					{
						num4 = pRev[num3++];
					}
					if (num3 > 0)
					{
						num5 = pTable[num3 + j * pRev.Length - 1];
					}
					short num6 = pRev[num3];
					double num7 = pTable[num3 + j * pRev.Length];
					double num8 = num6 - num4;
					double num9 = mRPM[k] - num4;
					double a = (num7 - num5) * (num9 / num8) + num5;
					array2[k + 32] = Math.Round(a);
					if (num3 < pRev.Length - 1 && mRPM[k] > pRev[num3 + 1])
					{
						num4 = num6;
						num3++;
					}
				}
			}
			for (; Throttle[i] < pThrottle[j]; i++)
			{
				double num10 = (double)Throttle[i] - num;
				double num11 = pThrottle[j];
				for (int k = 0; k < ISOMain.fREV; k++)
				{
					double num12 = array2[k];
					double a2 = (array2[k + 32] - num12) * (num10 / (num11 - num)) + num12;
					array = BitConverter.GetBytes((int)Math.Round(a2));
					Array.Copy(array, 0, ISOMain.MapTrim, (k + i * 32) * 12 + num2 * 2, 2);
				}
			}
			if (Throttle[i] == pThrottle[j])
			{
				for (int k = 0; k < ISOMain.fREV; k++)
				{
					array = BitConverter.GetBytes((int)Math.Round(array2[k + 32]));
					Array.Copy(array, 0, ISOMain.MapTrim, (k + i * 32) * 12 + num2 * 2, 2);
				}
				i++;
			}
			num = pThrottle[j];
			Array.Copy(array2, 32, array2, 0, 32);
		}
	}

	public static void ApplyTrims(int addr, int typT)
	{
		short[] array = new short[4];
		int num = ((typT >= 16) ? 8 : 0);
		byte[] mapTrim = ISOMain.MapTrim;
		int[] array2 = new int[24]
		{
			mapTable[9],
			mapTable[10],
			0,
			0,
			mapTable[18],
			mapTable[19],
			mapTable[20],
			0,
			mapTable[11],
			mapTable[12],
			mapTable[13],
			mapTable[14],
			mapTable[19],
			mapTable[20],
			mapTable[21],
			mapTable[22],
			mapTable[23],
			mapTable[24],
			mapTable[25],
			mapTable[26],
			mapTable[15],
			mapTable[16],
			mapTable[17],
			mapTable[18]
		};
		for (int i = 0; i < 32; i++)
		{
			for (int j = 0; j < 20; j++)
			{
				short num2;
				for (int k = num; k < num + 4; k++)
				{
					if (array2[k] == 0)
					{
						continue;
					}
					array[0] = (short)((mapTrim[(i + j * 32) * 12 + 4] | (mapTrim[(i + j * 32) * 12 + 5] << 8)) + 100);
					array[1] = (short)((mapTrim[(i + j * 32) * 12 + 8] | (mapTrim[(i + j * 32) * 12 + 9] << 8)) + 100);
					array[2] = (short)((mapTrim[(i + j * 32) * 12 + 6] | (mapTrim[(i + j * 32) * 12 + 7] << 8)) + 100);
					array[3] = (short)((mapTrim[(i + j * 32) * 12 + 10] | (mapTrim[(i + j * 32) * 12 + 11] << 8)) + 100);
					num2 = (ISOMain.oneTrim ? array[0] : array[k % 8]);
					if (!((num2 != 100) & (j < ISOMain.mPOS) & (i < ISOMain.fREV)))
					{
						continue;
					}
					double num3;
					short num4;
					if (num == 0)
					{
						num3 = (BitConverter.ToInt16(memoMap, addr + array2[k] + (j * ISOMain.fREV + i) * 2) - ((typT > 1) ? 20000 : 0)) * num2;
						num4 = (short)(Math.Round(num3 / 100.0) + (double)((typT > 1) ? 20000 : 0));
						memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2] = (byte)(num4 & 0xFF);
						memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2 + 1] = (byte)(num4 >> 8);
						continue;
					}
					if (typT > 2048)
					{
						num3 = ((memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2] << 8) | memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2 + 1]) * num2;
						num4 = (short)Math.Round(num3 / 100.0);
						memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2] = (byte)(num4 >> 8);
						memoMap[addr + array2[k] + (j * ISOMain.fREV + i) * 2 + 1] = (byte)(num4 & 0xFF);
						continue;
					}
					num3 = ((memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2] << 8) | memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2 + 1]) * num2;
					num4 = (short)Math.Round(num3 / 100.0);
					memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2] = (byte)(num4 >> 8);
					memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2 + 1] = (byte)(num4 & 0xFF);
					if (ISOMain._LTrim & ISOMain.me.TrimToLMenuItem.Checked)
					{
						num3 = ((memoMap[addr + array2[k + 12] + (i * ISOMain.mPOS + j) * 2] << 8) | memoMap[addr + array2[k + 12] + (i * ISOMain.mPOS + j) * 2 + 1]) * num2;
						num4 = (short)Math.Round(num3 / 100.0);
						memoMap[addr + array2[k + 12] + (i * ISOMain.mPOS + j) * 2] = (byte)(num4 >> 8);
						memoMap[addr + array2[k + 12] + (i * ISOMain.mPOS + j) * 2 + 1] = (byte)(num4 & 0xFF);
					}
				}
				num2 = (short)(mapTrim[(i + j * 32) * 12 + 12] | (mapTrim[(i + j * 32) * 12 + 13] << 8));
				bool flag = ((typT < 7) & (typT != 3) & (typT != 4)) | (typT == 14);
				if ((num2 != 0) & (j < ISOMain.mPOS) & (i < ISOMain.fREV))
				{
					for (int k = num + 4; k < num + 8; k++)
					{
						if (array2[k] != 0)
						{
							if (num == 0)
							{
								double num3 = (double)(memoMap[addr + array2[k] + j * ISOMain.iREV + i] - (flag ? 32 : 48)) * (flag ? 9.375 : 6.25) + (double)num2;
								short num4 = (short)(Math.Round(num3 * 16.0 / (double)(flag ? 150 : 100)) + (double)(flag ? 32 : 48));
								memoMap[addr + array2[k] + j * ISOMain.iREV + i] = (byte)(num4 & 0xFF);
							}
							else if (typT > 2048)
							{
								short num4 = (short)(memoMap[addr + array2[k] + j * ISOMain.fREV + i] + num2 * 4 / 10);
								memoMap[addr + array2[k] + (j * ISOMain.fREV + i)] = (byte)num4;
							}
							else
							{
								short num4 = (short)(((memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2] << 8) | memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2 + 1]) + num2);
								memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2] = (byte)(num4 >> 8);
								memoMap[addr + array2[k] + (i * ISOMain.mPOS + j) * 2 + 1] = (byte)(num4 & 0xFF);
							}
						}
					}
				}
				if (num != 8)
				{
					continue;
				}
				num2 = (short)(mapTrim[(i + j * 32) * 12 + 14] | (mapTrim[(i + j * 32) * 12 + 15] << 8));
				if (!((num2 != 0) & (j < ISOMain.mPOS) & (i < ISOMain.fREV)))
				{
					continue;
				}
				for (int k = num + 8; k < num + 12; k++)
				{
					if (array2[k] != 0)
					{
						short num4 = (short)(((memoMap[addr + array2[k] + (i * 20 + j) * 2] << 8) | memoMap[addr + array2[k] + (i * 20 + j) * 2 + 1]) + num2);
						memoMap[addr + array2[k] + (i * 20 + j) * 2] = (byte)(num4 >> 8);
						memoMap[addr + array2[k] + (i * 20 + j) * 2 + 1] = (byte)(num4 & 0xFF);
					}
				}
			}
		}
	}

	public static void ValidMod(int addr)
	{
		int num = (mapTable[39] & 0xF0000) >> 16;
		if (num == 0)
		{
			return;
		}
		int i = 0;
		int num2 = 0;
		num = (num - 1) * 16;
		int num3 = Tune.chkMap[num + i++];
		int num4 = Tune.chkMap[num + i++];
		int num5;
		if (num3 != 32768)
		{
			for (; i < 16; i++)
			{
				num5 = 0;
				while (Tune.chkMap[num + i] > 0)
				{
					num5 += (memoMap[addr + Tune.chkMap[num + i]] << 8) + memoMap[addr + Tune.chkMap[num + i++] + 1];
				}
				int num6 = memoMap[addr + num4 + num2];
				int num7 = memoMap[addr + num4 + num2 + 1];
				memoMap[addr + num3 + num6] = (byte)(num5 >> 8);
				memoMap[addr + num3 + num7] = (byte)(num5 & 0xFF);
				num2 += 2;
			}
			return;
		}
		num5 = 0;
		num3 = num4;
		num4 = Tune.chkMap[num + i++];
		while (num3 != 32768)
		{
			for (int num6 = num3; num6 < num4; num6 += 2)
			{
				num5 += (memoMap[addr + num6] << 8) | memoMap[addr + num6 + 1];
			}
			num3 = Tune.chkMap[num + i++];
			num4 = Tune.chkMap[num + i++];
		}
		num3 = Tune.chkMap[num + i++];
		num4 = Tune.chkMap[num + i++];
		memoMap[addr + num3] = (byte)(num5 >> 8);
		memoMap[addr + num4] = (byte)num5;
	}

	public static int MapChecksum(int offset, bool apply)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 524288;
		if (apply)
		{
			for (num = 0; num < 131072; num++)
			{
				memoMap[num5 + num] = memoMap[offset + num];
			}
			ApplyTrims(num5, ISOMain.TypTable);
			offset = num5;
		}
		int num6;
		if (ISOMain.TypTable < 16)
		{
			while ((addrTable[num2] < 65536) & (num2 < addrTable.Length))
			{
				num6 = addrTable[num2++];
				int num7 = addrTable[num2++];
				for (num = 0; num < num7; num++)
				{
					num4 += memoMap[num6 + offset + num];
				}
			}
			return (BitConverter.ToInt16(mHeader, 26) - num4) & 0xFFFF;
		}
		num6 = (mapTable[0] & 0xF0) << 12;
		ValidMod(offset);
		num = 0;
		for (num2 = ((mapTable[0] & 0xFF000) - num6) / 2 - 1; num2 > 0; num2--)
		{
			num4 += (memoMap[offset + num] << 8) | memoMap[offset + num + 1];
			num += 2;
		}
		return num4 & 0xFFFF;
	}

	public static void SetGridTable(string fString, int map, int ptr, int type)
	{
		double[] array = null;
		short[] array2 = new short[32];
		int num = (mapTable[0] & 0xF0) << 12;
		byte[] array3 = ((!((cmpMap != null) & ISOMain.compareF)) ? umodMap : cmpMap);
		switch (ptr)
		{
		case 0:
			ISOMain.SetLabelMap(83, 0, ISOMain.mPOS, Throttle, null);
			break;
		case 1:
		{
			int num3 = num + mapTable[9];
			for (int i = 0; i < 20; i++)
			{
				array2[i] = (short)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
			}
			ISOMain.SetLabelMap(84, 0, 20, array2, null);
			break;
		}
		case 2:
		{
			int num3 = num + mapTable[31];
			for (int i = 0; i < 15; i++)
			{
				array2[i] = (short)((memoMap[num3 + 56 - i * 4] << 8) | memoMap[num3 + 57 - i * 4]);
			}
			ISOMain.SetLabelMap(85, 2, 15, array2, null);
			break;
		}
		case 3:
		{
			int num3 = num + mapTable[29];
			for (int i = 0; i < 8; i++)
			{
				array2[i] = (short)((memoMap[num3 + 28 - i * 4] << 8) | memoMap[num3 + 29 - i * 4]);
			}
			ISOMain.SetLabelMap(85, 2, 8, array2, null);
			break;
		}
		case 4:
			ISOMain.SetLabelMap(83, 0, ISOMain.mPOS, Throttle, null);
			break;
		case 5:
		{
			int num3 = num + mapTable[5];
			for (int i = 0; i < 5; i++)
			{
				short num4 = (short)((memoMap[num3 + 16 - i * 4] << 8) | memoMap[num3 + 17 - i * 4]);
				array2[i] = (short)(num4 / 10);
			}
			ISOMain.SetLabelMap(87, 2, 5, array2, null);
			break;
		}
		case 6:
			ISOMain.SetLabelMap(86, 0, 16, _Load, null);
			break;
		case 7:
			ISOMain.SetLabelMap(85, 2, ISOMain.iREV, iRPM, null);
			break;
		case 8:
			ISOMain.SetLabelMap(87, 2, ISOMain.iREV, sTemp, null);
			break;
		case 9:
		{
			int num2 = ((type < 70) ? 5 : 6);
			sGear = new short[num2];
			for (int i = 0; i < num2; i++)
			{
				sGear[i] = (short)(i + 1);
			}
			ISOMain.SetLabelMap(99, 2, num2, sGear, null);
			break;
		}
		}
		ISOMain.eTrim = -1;
		ISORead.vSens = false;
		switch (map & 0x3F)
		{
		case 4:
		{
			array = new double[32];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 5] : mapTable[5]);
			int num3 = num + mapTable[5];
			for (int i = 0; i < 16; i++)
			{
				array[i] = BitConverter.ToInt16(memoMap, num3 + i * 2);
				array[i + 16] = BitConverter.ToInt16(array3, num5 + i * 2);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 5:
		{
			array = new double[10];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			int num3 = num + mapTable[map];
			for (int i = 0; i < 5; i++)
			{
				array[i] = (short)((memoMap[num3 + 18 - i * 4] << 8) | memoMap[num3 + 19 - i * 4]);
				array[i + 5] = (short)((array3[num5 + 18 - i * 4] << 8) | array3[num5 + 19 - i * 4]);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 6:
		case 7:
		case 8:
		{
			if (map == 6)
			{
				ISOMain.SetLabelMap(-1, 1, ISOMain.iREV, iRPM, icRPM);
			}
			int num9 = ((map != 6) ? 1 : ISOMain.iREV);
			int num10 = ISOMain.iREV;
			array = new double[num10 * num9 * 2];
			int num5 = (num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map + 17] : mapTable[map + 17]));
			int num3 = num + mapTable[map + 17];
			int num2 = 0;
			for (int j = 0; j < num10; j++)
			{
				for (int i = 0; i < num9; i++)
				{
					short num4 = (short)(BitConverter.ToInt16(memoMap, num3 + num2) * 5);
					array[i * num10 + j] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num4 = (short)(BitConverter.ToInt16(array3, num5 + num2) * 5);
					array[i * num10 + j + num10 * num9] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num2 += 2;
					ISOMain.SetGridMap(fString, array);
				}
			}
			break;
		}
		case 9:
		case 10:
		{
			ISORead.vSens = true;
			ISOMain.SetLabelMap(-1, 1, ISOMain.sREV, mRPM, mcRPM);
			array = new double[768];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			int num3 = num + mapTable[map];
			int num2 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					ushort num6 = (ushort)(BitConverter.ToInt16(memoMap, num3 + num2) - ((type > 1) ? 20000 : 0));
					array[i * ISOMain.mPOS + j] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num6 = (ushort)(BitConverter.ToInt16(array3, num5 + num2) - ((type > 1) ? 20000 : 0));
					array[i * ISOMain.mPOS + j + 384] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num2 += 2;
				}
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 11:
		case 12:
		{
			ISORead.vSens = true;
			ISORead.SetMapSensor(map);
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mcRPM);
			ISOMain.rpmMap = mRPM[ISOMain.fREV - 1];
			array = new double[ISOMain.fREV * ISOMain.mPOS * 2];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			int num3 = num + mapTable[map];
			ISOMain.altMap = (map == 12) & ((ISOMain.TypTable & 0xFFE0) == 2048);
			int num2 = 0;
			if (type < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					ushort num6 = (ushort)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
					array[i] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num6 = (ushort)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]);
					array[i + 640] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				}
			}
			else
			{
				for (int j = 0; j < ISOMain.mPOS; j++)
				{
					for (int i = 0; i < ISOMain.fREV; i++)
					{
						ushort num6 = (ushort)((memoMap[num3 + num2] << 8) | memoMap[num3 + num2 + 1]);
						array[i * ISOMain.mPOS + j] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
						num6 = (ushort)((array3[num5 + num2] << 8) | array3[num5 + num2 + 1]);
						array[i * ISOMain.mPOS + j + 512] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
						num2 += 2;
					}
				}
				if (!ISOMain.pSave & ((type & 0xFFE0) == 2048))
				{
					WalbroParams(ISOMain.altMap ? offMap : 0, mode: true);
					ISOMain.me.displayParams(-1, -1);
				}
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 19:
		case 20:
		case 21:
		case 22:
		{
			ISOMain.SetLabelMap(-1, 1, 32, iRPM, icRPM);
			ISOMain.rpmMap = iRPM[ISOMain.iREV - 1];
			array = new double[ISOMain.iREV * ISOMain.mPOS * 2];
			int num2 = (((map & 0x40) == 64) ? 4 : 0);
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + (map & 0x3F) + num2] : mapTable[(map & 0x3F) + num2]);
			int num3 = num + mapTable[(map & 0x3F) + num2];
			ISOMain.altMap = (map == 20) & ((ISOMain.TypTable & 0xFFE0) == 2048);
			if (type < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					short num4 = (short)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
					array[i] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num4 = (short)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]);
					array[i + 640] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				}
			}
			else
			{
				for (int j = 0; j < ISOMain.mPOS; j++)
				{
					for (int i = 0; i < ISOMain.iREV; i++)
					{
						double num7 = (double)(int)memoMap[num3 + num2] * 2.5 - 100.0;
						array[i * ISOMain.mPOS + j] = num7 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
						num7 = (double)(int)array3[num5 + num2] * 2.5 - 100.0;
						array[i * ISOMain.mPOS + j + 512] = num7 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
						num2++;
					}
				}
				if (!ISOMain.pSave & ((type & 0xFFE0) == 2048))
				{
					WalbroParams(ISOMain.altMap ? offMap : 0, mode: true);
					ISOMain.me.displayParams(-1, -1);
				}
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 23:
		{
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mcRPM);
			ISOMain.rpmMap = mRPM[ISOMain.fREV - 1];
			array = new double[1280];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 28] : mapTable[28]);
			int num3 = num + mapTable[28];
			for (int i = 0; i < 640; i++)
			{
				ushort num6 = (ushort)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
				array[i] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				num6 = (ushort)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]);
				array[i + 640] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 24:
		{
			array = new double[16];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 29] : mapTable[29]);
			int num3 = num + mapTable[29];
			for (int i = 0; i < 8; i++)
			{
				array[i] = (short)Math.Round((double)((memoMap[num3 + 30 - i * 4] << 8) | memoMap[num3 + 31 - i * 4]) / 2.55);
				array[i + 8] = (short)Math.Round((double)((array3[num5 + 30 - i * 4] << 8) | array3[num5 + 31 - i * 4]) / 2.55);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 25:
		{
			ISOMain.SetLabelMap(-1, 1, ISOMain.gREV, gRPM, gRPM);
			array = new double[168];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]);
			int num3 = num + mapTable[30];
			int num2 = 0;
			int num8 = sGear.Length;
			for (int j = 0; j < num8; j++)
			{
				num2 += 2;
				for (int i = ISOMain.gREV; i > 0; i--)
				{
					array[(i - 1) * num8 + j] = (short)Math.Round((double)((memoMap[num3 + num2] << 8) | memoMap[num3 + num2 + 1]) / 2.55);
					array[(i - 1) * num8 + j + 84] = (short)Math.Round((double)((array3[num5 + num2] << 8) | array3[num5 + num2 + 1]) / 2.55);
					num2 += 4;
				}
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 26:
		case 27:
		{
			array = new double[32];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map - 10] : mapTable[map - 10]);
			int num3 = num + mapTable[map - 10];
			bool flag3 = ((type < 7) & (type != 3) & (type != 4)) | (type == 14);
			for (int i = 0; i < ISOMain.iREV; i++)
			{
				short num4 = (short)Math.Round((double)(memoMap[num3 + i] - (flag3 ? 32 : 48)) * (flag3 ? 9.375 : 6.25));
				array[i] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				num4 = (short)Math.Round((double)(array3[num5 + i] - (flag3 ? 32 : 48)) * (flag3 ? 9.375 : 6.25));
				array[i + 16] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 28:
		case 29:
		case 30:
		{
			ISOMain.SetLabelMap(-1, 1, ISOMain.iREV, iRPM, icRPM);
			int num2 = 0;
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map - 10] : mapTable[map - 10]);
			int num3 = num + mapTable[map - 10];
			array = new double[512];
			bool flag = ((type < 7) & (type != 3) & (type != 4)) | (type == 14);
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					short num4 = (short)Math.Round((double)(memoMap[num3 + num2] - (flag ? 32 : 48)) * (flag ? 9.375 : 6.25));
					array[i * ISOMain.mPOS + j] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
					num4 = (short)Math.Round((double)(array3[num5 + num2++] - (flag ? 32 : 48)) * (flag ? 9.375 : 6.25));
					array[i * ISOMain.mPOS + j + 256] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				}
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 31:
		{
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mRPM);
			array = new double[1280];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]) & 0x1FFFF;
			int num3 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				array[i] = (short)Math.Round((double)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]) / 2.56);
				array[i + 640] = (short)Math.Round((double)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]) / 2.56);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 32:
		case 36:
		case 37:
		case 38:
		{
			if ((map & 4) == 0)
			{
				ISOMain.SetLabelMap(-1, 1, ISOMain.sREV, mRPM, mRPM);
				ISOMain.eTrim = 0;
				ISOMain.updateTrim();
			}
			else
			{
				ISOMain.SetLabelMap(-1, 1, ISOMain.iREV, iRPM, iRPM);
			}
			ISORead.vSens = (map & 4) == 0;
			if (ISORead.vSens)
			{
				ISORead.SetMapSensor(11);
			}
			array = new double[1280];
			bool flag2 = ISOMain.altMap;
			ISOMain.altMap = false;
			byte[] mapTrim = ISOMain.MapTrim;
			int num2 = (map & 5) * 2 + ((ISOMain.eTrim == 0) ? ISOMain.xTrim : 0);
			if (BitConverter.ToInt32(mapTrim, 0) > 0)
			{
				for (int j = 0; j < 32; j++)
				{
					for (int i = 0; i < 20; i++)
					{
						if ((i < ISOMain.gCol) & (j < ISOMain.gRow))
						{
							short num4 = (short)BitConverter.ToInt32(mapTrim, (j + i * 32) * 12 + num2 + 4);
							array[j * ISOMain.gCol + i] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
						}
					}
				}
			}
			if (ISOMain.cmpTrim.Length == 12292)
			{
				mapTrim = ISOMain.cmpTrim;
				num2 = (map & 5) * 2 + ((ISOMain.eTrim == 0) ? ISOMain.xTrim : 0);
				if (BitConverter.ToInt32(mapTrim, 0) > 0)
				{
					for (int j = 0; j < 32; j++)
					{
						for (int i = 0; i < 20; i++)
						{
							if ((i < ISOMain.gCol) & (j < ISOMain.gRow))
							{
								short num4 = (short)BitConverter.ToInt32(mapTrim, (j + i * 32) * 12 + num2 + 4);
								array[j * ISOMain.gCol + i + 640] = (double)num4 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
							}
						}
					}
				}
			}
			if (((type & 0xFFE0) == 2048) & (flag2 != ISOMain.altMap) & !ISOMain.eSave)
			{
				WalbroParams(ISOMain.altMap ? offMap : 0, mode: true);
				ISOMain.me.displayParams(-1, -1);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 49:
		{
			array = new double[32];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 31] : mapTable[31]);
			int num3 = num + mapTable[31];
			for (int i = 0; i < 15; i++)
			{
				array[i] = (short)Math.Round((double)((memoMap[num3 + 58 - i * 4] << 8) | memoMap[num3 + 59 - i * 4]) / 2.55);
				array[i + 16] = (short)Math.Round((double)((array3[num5 + 58 - i * 4] << 8) | array3[num5 + 59 - i * 4]) / 2.55);
			}
			if (array[0] > 100.0)
			{
				array[0] = 15.0;
			}
			if (array[16] > 100.0)
			{
				array[16] = 15.0;
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 50:
		{
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mRPM);
			array = new double[1280];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]) & 0x1FFFF;
			int num3 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				array[i] = (short)Math.Round((double)(int)memoMap[num3 + i] / 2.55);
				array[i + 640] = (short)Math.Round((double)(int)array3[num5 + i] / 2.55);
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		case 51:
		case 52:
		case 53:
		case 54:
		{
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mcRPM);
			ISOMain.rpmMap = mRPM[ISOMain.fREV - 1];
			array = new double[1280];
			int num5 = mapTable[map - 40];
			int num3 = num + num5;
			for (int i = 0; i < 640; i++)
			{
				ushort num6 = (ushort)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
				array[i] = (double)(int)num6 / 8.55;
				num6 = (ushort)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]);
				array[i + 640] = (double)(int)num6 / 8.55;
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		default:
		{
			ISORead.vSens = true;
			ISORead.SetMapSensor(map);
			ISOMain.SetLabelMap(-1, 1, 32, mRPM, mcRPM);
			ISOMain.rpmMap = mRPM[ISOMain.fREV - 1];
			array = new double[1280];
			int num5 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			int num3 = num + mapTable[map];
			for (int i = 0; i < 640; i++)
			{
				ushort num6 = (ushort)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]);
				array[i] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
				num6 = (ushort)((array3[num5 + i * 2] << 8) | array3[num5 + i * 2 + 1]);
				array[i + 640] = (double)(int)num6 / (double)((fString == "0") ? 1 : ((fString == "0.0") ? 10 : 100));
			}
			ISOMain.SetGridMap(fString, array);
			break;
		}
		}
		ISOMain.pcEdit = (map >= 9) & (map < 19) & ISOMain.pCent;
		ISOMain.pcGraph = (map >= 9) & (map < 19) & ISOMain.sCent;
	}

	public static void SaveModMap(double[] table, int map, int type)
	{
		int num = (mapTable[0] & 0xF0) << 12;
		switch (map)
		{
		case 4:
		{
			int num3 = num + mapTable[5];
			for (int i = 0; i < 16; i++)
			{
				memoMap[num3 + i * 2] = (byte)((int)table[i] & 0xFF);
				memoMap[num3 + i * 2 + 1] = (byte)((int)table[i] >> 8);
			}
			break;
		}
		case 5:
		{
			int num3 = num + mapTable[map];
			for (int i = 0; i < 5; i++)
			{
				memoMap[num3 + 18 - i * 4] = (byte)((int)table[i] >> 8);
				memoMap[num3 + 19 - i * 4] = (byte)((int)table[i] & 0xFF);
			}
			break;
		}
		case 6:
		case 7:
		case 8:
		{
			int num7 = ISOMain.iREV;
			int num8 = table.Length / num7 / 2;
			int num3 = num + mapTable[map + 17];
			int num2 = 0;
			for (int j = 0; j < num7; j++)
			{
				for (int i = 0; i < num8; i++)
				{
					int num4 = (int)(table[i * num7 + j] * 20.0);
					memoMap[num3 + num2] = (byte)(num4 & 0xFF);
					memoMap[num3 + num2 + 1] = (byte)(num4 >> 8);
					num2 += 2;
				}
			}
			break;
		}
		case 9:
		case 10:
		{
			int num3 = num + mapTable[map];
			int num2 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					int num4 = (int)(table[i * ISOMain.mPOS + j] * 10.0 + (double)((ISOMain.TypTable > 1) ? 20000 : 0));
					memoMap[num3 + num2] = (byte)(num4 & 0xFF);
					memoMap[num3 + num2 + 1] = (byte)(num4 >> 8);
					num2 += 2;
				}
			}
			break;
		}
		case 11:
		case 12:
		{
			int num3 = num + mapTable[map];
			int num2 = 0;
			if (type < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					int num4 = (int)Math.Round(table[i]);
					memoMap[num3 + i * 2] = (byte)(num4 >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)(num4 & 0xFF);
				}
				break;
			}
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					int num4 = (int)table[i * ISOMain.mPOS + j];
					memoMap[num3 + num2] = (byte)(num4 >> 8);
					memoMap[num3 + num2 + 1] = (byte)(num4 & 0xFF);
					num2 += 2;
				}
			}
			break;
		}
		case 19:
		case 20:
		{
			int num2 = 0;
			int num3 = num + mapTable[map];
			if (type < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					int num4 = (int)Math.Round(table[i]);
					memoMap[num3 + i * 2] = (byte)(num4 >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)(num4 & 0xFF);
				}
				break;
			}
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					int num4 = (int)((table[i * ISOMain.mPOS + j] + 100.0) * 0.4);
					memoMap[num3 + num2] = (byte)num4;
					num2++;
				}
			}
			break;
		}
		case 23:
		{
			int num3 = num + mapTable[28];
			for (int i = 0; i < 640; i++)
			{
				int num4 = (int)Math.Round(table[i]);
				memoMap[num3 + i * 2] = (byte)(num4 >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)(num4 & 0xFF);
			}
			break;
		}
		case 24:
		{
			int num3 = num + mapTable[29];
			for (int i = 0; i < 8; i++)
			{
				int num4 = (int)Math.Round((double)((memoMap[num3 + 30 - i * 4] << 8) | memoMap[num3 + 31 - i * 4]) / 2.55);
				if (num4 != (int)Math.Round(table[i] / 2.55))
				{
					memoMap[num3 + 30 - i * 4] = (byte)((int)table[i] >> 8);
					memoMap[num3 + 31 - i * 4] = (byte)((int)table[i] & 0xFF);
				}
			}
			break;
		}
		case 25:
		{
			int num3 = num + mapTable[30];
			int num2 = 0;
			int num6 = sGear.Length;
			for (int j = 0; j < num6; j++)
			{
				num2 += 2;
				for (int i = ISOMain.gREV; i > 0; i--)
				{
					int num4 = (int)Math.Round((double)((memoMap[num3 + num2] << 8) | memoMap[num3 + num2 + 1]) / 2.55);
					if (num4 != (int)Math.Round(table[(i - 1) * num6 + j] / 2.55))
					{
						memoMap[num3 + num2] = (byte)((int)table[(i - 1) * num6 + j] >> 8);
						memoMap[num3 + num2 + 1] = (byte)((int)table[(i - 1) * num6 + j] & 0xFF);
					}
					num2 += 4;
				}
			}
			break;
		}
		case 26:
		case 27:
		{
			int num3 = num + mapTable[map - 10];
			bool flag2 = ((type < 7) & (type != 3) & (type != 4)) | (type == 14);
			for (int i = 0; i < ISOMain.iREV; i++)
			{
				int num4 = (int)(Math.Round(table[i] * 16.0 / (double)(flag2 ? 15 : 10)) + (double)(flag2 ? 32 : 48));
				memoMap[num3 + i] = (byte)(num4 & 0xFF);
			}
			break;
		}
		case 28:
		case 29:
		case 30:
		{
			int num3 = num + mapTable[map - 10];
			bool flag = ((type < 7) & (type != 3) & (type != 4)) | (type == 14);
			int num2 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					int num4 = (int)(Math.Round(table[i * ISOMain.mPOS + j] * 16.0 / (double)(flag ? 15 : 10)) + (double)(flag ? 32 : 48));
					memoMap[num3 + num2++] = (byte)(num4 & 0xFF);
				}
			}
			break;
		}
		case 31:
		{
			int num3 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				int num4 = (int)Math.Round((double)((memoMap[num3 + i * 2] << 8) | memoMap[num3 + i * 2 + 1]) / 2.56);
				if (num4 != (int)Math.Round(table[i] / 2.56))
				{
					memoMap[num3 + i * 2] = (byte)((int)table[i] >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)((int)table[i] & 0xFF);
				}
			}
			break;
		}
		case 32:
		case 36:
		case 37:
		case 38:
		{
			byte[] mapTrim = ISOMain.MapTrim;
			int num2 = (map & 5) * 2 + ((ISOMain.eTrim == 0) ? ISOMain.xTrim : 0);
			for (int j = 0; j < 32; j++)
			{
				for (int i = 0; i < 20; i++)
				{
					if ((i < ISOMain.gCol) & (j < ISOMain.gRow))
					{
						byte[] bytes = BitConverter.GetBytes((int)Math.Round(table[j * ISOMain.gCol + i]));
						Array.Copy(bytes, 0, mapTrim, (j + i * 32) * 12 + num2 + 4, 2);
					}
				}
			}
			ISOMain.checkMapTrim(blank: false);
			break;
		}
		case 49:
		{
			int num3 = num + mapTable[31];
			for (int i = 0; i < 15; i++)
			{
				int num4 = (int)Math.Round((double)((memoMap[num3 + 58 - i * 4] << 8) | memoMap[num3 + 59 - i * 4]) / 2.55);
				if (num4 != (int)Math.Round(table[i] / 2.55))
				{
					memoMap[num3 + 58 - i * 4] = (byte)((int)table[i] >> 8);
					memoMap[num3 + 59 - i * 4] = (byte)((int)table[i] & 0xFF);
				}
			}
			break;
		}
		case 50:
		{
			int num3 = num + (mapTable[30] & 0x1FFFF);
			for (int num5 = mapTable[30] >> 20; num5 >= 0; num5--)
			{
				int i;
				for (i = 0; i < 640; i++)
				{
					int num4 = (int)Math.Round((double)(int)memoMap[num3 + i] / 2.55);
					if (num4 != (int)Math.Round(table[i] / 2.55))
					{
						memoMap[num3 + i] = (byte)table[i];
					}
				}
				num3 += i;
			}
			break;
		}
		case 51:
		case 52:
		case 53:
		case 54:
		{
			int num3 = num + mapTable[map - 40];
			for (int i = 0; i < 640; i++)
			{
				int num4 = (int)Math.Round(table[i] * 8.55);
				memoMap[num3 + i * 2] = (byte)(num4 >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)(num4 & 0xFF);
			}
			break;
		}
		default:
		{
			int num2 = (((map & 0x40) == 64) ? 4 : 0);
			int num3 = num + mapTable[(map & 0x3F) + num2];
			for (int i = 0; i < 640; i++)
			{
				int num4 = (int)Math.Round(table[i]);
				memoMap[num3 + i * 2] = (byte)(num4 >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)(num4 & 0xFF);
			}
			break;
		}
		}
	}

	public static void CopyMap(double[] table, int map)
	{
		int num = (mapTable[0] & 0xF0) << 12;
		byte[] array = ((!((cmpMap != null) & ISOMain.compareF)) ? umodMap : cmpMap);
		int num2;
		int num7;
		int num8;
		int num5;
		int num3;
		int num4;
		switch (map)
		{
		case 4:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 5] : mapTable[5]);
			num4 = num + mapTable[5];
			for (int i = 0; i < 16; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = BitConverter.ToInt16(array, num3 + i * 2);
				}
				else
				{
					table[i + 2] = BitConverter.ToInt16(memoMap, num4 + i * 2);
				}
			}
			return;
		}
		case 5:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 5] : mapTable[5]);
			num4 = num + mapTable[5];
			for (int i = 0; i < 15; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = (short)((array[num3 + 18 - i * 4] << 8) | array[num3 + 19 - i * 4]);
				}
				else
				{
					table[i + 2] = (short)((memoMap[num4 + 18 - i * 4] << 8) | memoMap[num4 + 19 - i * 4]);
				}
			}
			return;
		}
		case 7:
		case 8:
			num2 = 1;
			goto IL_0210;
		case 6:
			num2 = ISOMain.iREV;
			goto IL_0210;
		case 9:
		case 10:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			num4 = num + mapTable[map];
			cRPM = (ISOMain.showMod ? mcRPM : mRPM);
			num5 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					if (ISOMain.showMod)
					{
						table[num5 + 2] = BitConverter.ToInt16(array, num3 + num5++ * 2);
					}
					else
					{
						table[num5 + 2] = BitConverter.ToInt16(memoMap, num4 + num5++ * 2);
					}
				}
			}
			return;
		}
		case 11:
		case 12:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			num4 = num + mapTable[map];
			cRPM = (ISOMain.showMod ? mcRPM : mRPM);
			num5 = 0;
			if (ISOMain.TypTable < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					if (ISOMain.showMod)
					{
						table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
					}
					else
					{
						table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
					}
				}
				return;
			}
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					if (ISOMain.showMod)
					{
						table[num5 + 2] = BitConverter.ToInt16(array, num3 + num5++ * 2);
					}
					else
					{
						table[num5 + 2] = BitConverter.ToInt16(memoMap, num4 + num5++ * 2);
					}
				}
			}
			return;
		}
		case 19:
		case 20:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map] : mapTable[map]);
			num4 = num + mapTable[map];
			cRPM = (ISOMain.showMod ? icRPM : iRPM);
			num5 = 0;
			if (ISOMain.TypTable < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					if (ISOMain.showMod)
					{
						table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
					}
					else
					{
						table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
					}
				}
				return;
			}
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					if (ISOMain.showMod)
					{
						table[num5 + 2] = BitConverter.ToInt16(array, num3 + num5++ * 2);
					}
					else
					{
						table[num5 + 2] = BitConverter.ToInt16(memoMap, num4 + num5++ * 2);
					}
				}
			}
			return;
		}
		case 23:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 28] : mapTable[28]);
			num4 = num + mapTable[28];
			for (int i = 0; i < 640; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
				}
				else
				{
					table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
				}
			}
			return;
		}
		case 24:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 29] : mapTable[29]);
			num4 = num + mapTable[29];
			for (int i = 0; i < 8; i++)
			{
				if (ISOMain.showMod)
				{
					table[i * 2 + 2] = (short)((array[num3 + 28 - i * 4] << 8) | array[num3 + 29 - i * 4]);
					table[i * 2 + 3] = (short)((array[num3 + 30 - i * 4] << 8) | array[num3 + 31 - i * 4]);
				}
				else
				{
					table[i * 2 + 2] = (short)((memoMap[num4 + 28 - i * 4] << 8) | memoMap[num4 + 29 - i * 4]);
					table[i * 2 + 3] = (short)((memoMap[num4 + 30 - i * 4] << 8) | memoMap[num4 + 31 - i * 4]);
				}
			}
			return;
		}
		case 25:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]);
			num4 = num + mapTable[30];
			num5 = 0;
			int num6 = sGear.Length;
			for (int j = 0; j < num6; j++)
			{
				num5 += 2;
				for (int i = ISOMain.gREV; i > 0; i--)
				{
					if (ISOMain.showMod)
					{
						table[(i - 1) * num6 + j + 2] = (short)((array[num3 + num5] << 8) | array[num3 + num5 + 1]);
					}
					else
					{
						table[(i - 1) * num6 + j + 2] = (short)((memoMap[num4 + num5] << 8) | memoMap[num4 + num5 + 1]);
					}
					num5 += 4;
				}
			}
			return;
		}
		case 26:
		case 27:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map - 10] : mapTable[map - 10]);
			num4 = num + mapTable[map - 10];
			cRPM = (ISOMain.showMod ? icRPM : iRPM);
			for (int i = 0; i < ISOMain.iREV; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = (int)array[num3 + i];
				}
				else
				{
					table[i + 2] = (int)memoMap[num4 + i];
				}
			}
			return;
		}
		case 28:
		case 29:
		case 30:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map - 10] : mapTable[map - 10]);
			num4 = num + mapTable[map - 10];
			cRPM = (ISOMain.showMod ? icRPM : iRPM);
			num5 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					if (ISOMain.showMod)
					{
						table[num5 + 2] = (int)array[num3 + num5++];
					}
					else
					{
						table[num5 + 2] = (int)memoMap[num4 + num5++];
					}
				}
			}
			return;
		}
		case 31:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]) & 0x1FFFF;
			num4 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
				}
				else
				{
					table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
				}
			}
			return;
		}
		case 32:
		case 36:
		case 37:
		case 38:
		{
			byte[] value = ((ISOMain.showMod & ISOMain.compareF) ? ISOMain.cmpTrim : ISOMain.MapTrim);
			num5 = (map & 4) * 2 + ((ISOMain.eTrim == 0) ? ISOMain.xTrim : 0);
			table[2] = BitConverter.ToInt32(value, 0);
			for (int j = 0; j < 32; j++)
			{
				for (int i = 0; i < 20; i++)
				{
					if ((i < ISOMain.gCol) & (j < ISOMain.gRow))
					{
						table[j * ISOMain.gCol + i + 3] = (short)BitConverter.ToInt32(value, (j + i * 32) * 12 + num5 + 4);
					}
				}
			}
			return;
		}
		case 49:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 31] : mapTable[31]);
			num4 = num + mapTable[31];
			for (int i = 0; i < 15; i++)
			{
				if (ISOMain.showMod)
				{
					table[i * 2 + 2] = (short)((array[num3 + 56 - i * 4] << 8) | array[num3 + 57 - i * 4]);
					table[i * 2 + 3] = (short)((array[num3 + 58 - i * 4] << 8) | array[num3 + 59 - i * 4]);
				}
				else
				{
					table[i * 2 + 2] = (short)((memoMap[num4 + 56 - i * 4] << 8) | memoMap[num4 + 57 - i * 4]);
					table[i * 2 + 3] = (short)((memoMap[num4 + 58 - i * 4] << 8) | memoMap[num4 + 59 - i * 4]);
				}
			}
			return;
		}
		case 50:
		{
			num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + 30] : mapTable[30]) & 0x1FFFF;
			num4 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				if (ISOMain.showMod)
				{
					table[i + 2] = (int)array[num3 + i];
				}
				else
				{
					table[i + 2] = (int)memoMap[num4 + i];
				}
			}
			return;
		}
		case 51:
		case 52:
		case 53:
		case 54:
			{
				num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map - 40] : mapTable[map - 40]) & 0x1FFFF;
				num4 = num + mapTable[map - 40];
				for (int i = 0; i < 640; i++)
				{
					if (ISOMain.showMod)
					{
						table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
					}
					else
					{
						table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
					}
				}
				return;
			}
			IL_0210:
			num7 = num2;
			num8 = ISOMain.iREV;
			num3 = (num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + map + 17] : mapTable[map + 17]));
			num4 = num + mapTable[map + 17];
			num5 = 0;
			for (int j = 0; j < num8; j++)
			{
				for (int i = 0; i < num7; i++)
				{
					if (ISOMain.showMod)
					{
						table[num5 + 2] = BitConverter.ToInt16(array, num3 + num5++ * 2);
					}
					else
					{
						table[num5 + 2] = BitConverter.ToInt16(memoMap, num4 + num5++ * 2);
					}
				}
			}
			return;
		}
		num5 = (((map & 0x40) == 64) ? 4 : 0);
		num3 = (ISOMain.compareF ? Tune.eAddr[cmpOff + (map & 0x3F) + num5] : mapTable[(map & 0x3F) + num5]);
		num4 = num + mapTable[(map & 0x3F) + num5];
		for (int i = 0; i < 640; i++)
		{
			if (ISOMain.showMod)
			{
				table[i + 2] = (array[num3 + i * 2] << 8) | array[num3 + i * 2 + 1];
			}
			else
			{
				table[i + 2] = (memoMap[num4 + i * 2] << 8) | memoMap[num4 + i * 2 + 1];
			}
		}
		if ((map > 12) & (map < 15))
		{
			cRPM = (ISOMain.showMod ? mcRPM : mRPM);
		}
		else if ((map > 18) & (map < 23))
		{
			cRPM = (ISOMain.showMod ? icRPM : iRPM);
		}
	}

	public static void PasteMap(double[] table, int map)
	{
		int num = (mapTable[0] & 0xF0) << 12;
		int num4;
		int num5;
		int num6;
		int num3;
		int num2;
		switch (map)
		{
		case 4:
		{
			num3 = num + mapTable[5];
			for (int i = 0; i < 16; i++)
			{
				memoMap[num3 + i * 2] = (byte)((int)table[i + 2] & 0xFF);
				memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] >> 8);
			}
			break;
		}
		case 5:
		{
			num3 = num + mapTable[map];
			for (int i = 0; i < 5; i++)
			{
				memoMap[num3 + 18 - i * 4] = (byte)((int)table[i + 2] >> 8);
				memoMap[num3 + 19 - i * 4] = (byte)((int)table[i + 2] & 0xFF);
			}
			break;
		}
		case 7:
		case 8:
			num4 = 1;
			goto IL_018c;
		case 6:
			num4 = ISOMain.iREV;
			goto IL_018c;
		case 9:
		case 10:
		{
			num3 = num + mapTable[map];
			num2 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.fREV; i++)
				{
					memoMap[num3 + num2 * 2] = (byte)((int)table[num2 + 2] & 0xFF);
					memoMap[num3 + num2 * 2 + 1] = (byte)((int)table[num2 + 2] >> 8);
					num2++;
				}
			}
			copyRPM(cRPM, ign: false);
			FixRpmLimit();
			break;
		}
		case 11:
		case 12:
			num3 = num + mapTable[map];
			num2 = 0;
			if (ISOMain.TypTable < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
				}
			}
			else
			{
				for (int j = 0; j < ISOMain.mPOS; j++)
				{
					for (int i = 0; i < ISOMain.fREV; i++)
					{
						memoMap[num3 + num2 * 2] = (byte)((int)table[num2 + 2] & 0xFF);
						memoMap[num3 + num2 * 2 + 1] = (byte)((int)table[num2 + 2] >> 8);
						num2++;
					}
				}
			}
			copyRPM(cRPM, ign: false);
			break;
		case 19:
		case 20:
		{
			num3 = num + mapTable[map];
			num2 = 0;
			if (ISOMain.TypTable < 2048)
			{
				for (int i = 0; i < 640; i++)
				{
					memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
				}
				copyRPM(cRPM, ign: true);
				break;
			}
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					memoMap[num3 + num2 * 2] = (byte)((int)table[num2 + 2] & 0xFF);
					memoMap[num3 + num2 * 2 + 1] = (byte)((int)table[num2 + 2] >> 8);
					num2++;
				}
			}
			break;
		}
		case 23:
		{
			num3 = num + mapTable[28];
			for (int i = 0; i < 640; i++)
			{
				memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
			}
			break;
		}
		case 24:
		{
			num3 = num + mapTable[29];
			for (int i = 0; i < 8; i++)
			{
				memoMap[num3 + 28 - i * 4] = (byte)((int)table[i * 2 + 2] >> 8);
				memoMap[num3 + 29 - i * 4] = (byte)((int)table[i * 2 + 2] & 0xFF);
				memoMap[num3 + 30 - i * 4] = (byte)((int)table[i * 2 + 3] >> 8);
				memoMap[num3 + 31 - i * 4] = (byte)((int)table[i * 2 + 3] & 0xFF);
			}
			break;
		}
		case 25:
		{
			num3 = num + mapTable[30];
			num2 = 0;
			int num8 = sGear.Length;
			for (int j = 0; j < num8; j++)
			{
				num2 += 2;
				for (int i = ISOMain.gREV; i > 0; i--)
				{
					memoMap[num3 + num2] = (byte)((int)table[(i - 1) * num8 + j + 2] >> 8);
					memoMap[num3 + num2 + 1] = (byte)((int)table[(i - 1) * num8 + j + 2] & 0xFF);
					num2 += 4;
				}
			}
			break;
		}
		case 26:
		case 27:
		{
			num3 = num + mapTable[map - 10];
			for (int i = 0; i < ISOMain.iREV; i++)
			{
				memoMap[num3 + i] = (byte)table[i + 2];
			}
			copyRPM(cRPM, ign: true);
			break;
		}
		case 28:
		case 29:
		case 30:
		{
			num3 = num + mapTable[map - 10];
			num2 = 0;
			for (int j = 0; j < ISOMain.mPOS; j++)
			{
				for (int i = 0; i < ISOMain.iREV; i++)
				{
					memoMap[num3 + num2] = (byte)table[num2++ + 2];
				}
			}
			copyRPM(cRPM, ign: true);
			break;
		}
		case 31:
		{
			num3 = num + (mapTable[30] & 0x1FFFF);
			for (int i = 0; i < 640; i++)
			{
				memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
			}
			break;
		}
		case 32:
		case 36:
		case 37:
		case 38:
		{
			byte[] mapTrim = ISOMain.MapTrim;
			num2 = (map & 4) * 2 + ((ISOMain.eTrim == 0) ? ISOMain.xTrim : 0);
			byte[] bytes = BitConverter.GetBytes((int)table[2]);
			Array.Copy(bytes, mapTrim, 4);
			for (int j = 0; j < 32; j++)
			{
				for (int i = 0; i < 20; i++)
				{
					if (j < ISOMain.gRow)
					{
						bytes = BitConverter.GetBytes((int)table[j * ISOMain.gCol + i + 3]);
						Array.Copy(bytes, 0, mapTrim, (j + i * 32) * 12 + num2 + 4, 2);
					}
				}
			}
			break;
		}
		case 49:
		{
			num3 = num + mapTable[31];
			for (int i = 0; i < 15; i++)
			{
				memoMap[num3 + 56 - i * 4] = (byte)((int)table[i * 2 + 2] >> 8);
				memoMap[num3 + 57 - i * 4] = (byte)((int)table[i * 2 + 2] & 0xFF);
				memoMap[num3 + 58 - i * 4] = (byte)((int)table[i * 2 + 3] >> 8);
				memoMap[num3 + 59 - i * 4] = (byte)((int)table[i * 2 + 3] & 0xFF);
			}
			break;
		}
		case 50:
		{
			num3 = num + (mapTable[30] & 0x1FFFF);
			for (int num7 = mapTable[30] >> 20; num7 >= 0; num7--)
			{
				int i;
				for (i = 0; i < 640; i++)
				{
					memoMap[num3 + i] = (byte)table[i + 2];
				}
				num3 += i;
			}
			break;
		}
		case 51:
		case 52:
		case 53:
		case 54:
		{
			num3 = num + mapTable[map - 40];
			for (int i = 0; i < 640; i++)
			{
				memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
				memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
			}
			break;
		}
		default:
			{
				num2 = (((map & 0x40) == 64) ? 4 : 0);
				num3 = num + mapTable[(map & 0x3F) + num2];
				for (int i = 0; i < 640; i++)
				{
					memoMap[num3 + i * 2] = (byte)((int)table[i + 2] >> 8);
					memoMap[num3 + i * 2 + 1] = (byte)((int)table[i + 2] & 0xFF);
				}
				if ((map > 10) & (map < 15))
				{
					copyRPM(cRPM, ign: false);
				}
				else if ((map > 20) & (map < 23))
				{
					copyRPM(cRPM, ign: true);
				}
				break;
			}
			IL_018c:
			num5 = num4;
			num6 = ISOMain.iREV;
			num3 = num + mapTable[map + 17];
			num2 = 0;
			for (int j = 0; j < num6; j++)
			{
				for (int i = 0; i < num5; i++)
				{
					memoMap[num3 + num2 * 2] = (byte)((int)table[num2 + 2] & 0xFF);
					memoMap[num3 + num2 * 2 + 1] = (byte)((int)table[num2 + 2] >> 8);
					num2++;
				}
			}
			break;
		}
	}

	private static void copyRPM(short[] rCopy, bool ign)
	{
		int num = ((ISOMain.TypTable >= 16) ? 1 : 0);
		int num2 = (mapTable[0] & 0xF0) << 12;
		int num3 = num2 + ((((mapTable[0] & 0xF0) << 12) + mapTable[ign ? (21 - num * 13) : (11 - num)]) & 0xFFFF);
		if (ign)
		{
			for (int i = 0; i < ISOMain.iREV; i++)
			{
				iRPM[i] = rCopy[i];
				int num4 = rCopy[i] * ((ISOMain.TypTable >= 16) ? 1 : 4);
				memoMap[num3 + i * 2 + (num & 1)] = (byte)(num4 & 0xFF);
				memoMap[num3 + i * 2 + (num ^ 1)] = (byte)(num4 >> 8);
			}
		}
		else
		{
			for (int i = 0; i < ISOMain.fREV; i++)
			{
				mRPM[i] = rCopy[i];
				int num4 = rCopy[i] * ((ISOMain.TypTable >= 2) ? 1 : 4);
				memoMap[num3 + i * 2 + (num & 1)] = (byte)(num4 & 0xFF);
				memoMap[num3 + i * 2 + (num ^ 1)] = (byte)(num4 >> 8);
			}
		}
	}

	public static string GetWbMap(byte[] mdata)
	{
		int num = identifyMap(mdata, 20, -2);
		string text;
		if (num < 0)
		{
			text = "Unknown";
		}
		else
		{
			num = (int)(Tune.mType[num * 8 + 6] & 0xFF);
			text = ((num != 0) ? Tune.walbroID[num] : ((mdata[20] << 8) | mdata[21]).ToString("###00"));
		}
		StringBuilder stringBuilder = new StringBuilder(text);
		for (int i = 0; i < 16 && i != text.Length; i++)
		{
			mdata[i + 4] = (byte)stringBuilder[i];
		}
		return text;
	}

	public static string GetInfosMap(string id, int type)
	{
		ISOMain.wRef = 0;
		string result = "";
		string text = "";
		if (id != null && (type & 0xFFF8) == 8)
		{
			return "";
		}
		if (type < 80)
		{
			for (int i = 0; i < Tune.mTriumphInfos.Length; i++)
			{
				if (Tune.mTriumphInfos[i].StartsWith(id))
				{
					text = Tune.mTriumphInfos[i].Substring(id.Length + 1, 1);
					ISOMain.wRef = "0123456789ABCDEFGHIJKLMNOPQRSTUV".IndexOf(text);
					if (ISOMain.wRef < 0)
					{
						ISOMain.wRef = 0;
					}
					result = Tune.mTriumphInfos[i].Substring(id.Length + 3);
					break;
				}
			}
		}
		else
		{
			for (int j = 0; j < Tune.mKTMinfos.Length; j++)
			{
				if (Tune.mKTMinfos[j].StartsWith(id))
				{
					result = Tune.mKTMinfos[j].Substring(id.Length + 1);
					break;
				}
			}
		}
		return result;
	}

	public static int GetRpmMax(int addr, int type)
	{
		string text = "";
		int result = 0;
		int num = mapTable[2];
		if (type < 80)
		{
			return mapTable[2];
		}
		text = ISORead.BuildString(memoMap, addr + num, 16, ascii: true, nozero: false);
		for (int i = 0; i < Tune.mKTMmodel.Length; i++)
		{
			if (Tune.mKTMmodel[i].StartsWith(text))
			{
				int length = Tune.mKTMmodel[i].Length;
				int.TryParse(Tune.mKTMmodel[i].Substring(length - 1), out result);
				break;
			}
		}
		return Tune.kRevMax[result];
	}
}
}
