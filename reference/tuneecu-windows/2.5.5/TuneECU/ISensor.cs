using System;
using TuneLibrary;

namespace TuneECU
{

public class ISensor : ISORead
{
	public static ushort[] sensorNode = new ushort[264]
	{
		1029, 1030, 1031, 1032, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 76, 77, 78, 79, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 9013, 24, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 20756, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 9030, 9015,
		5, 300, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		9010, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 4, 2, 1, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 7, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 26, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 272, 273, 274, 275, 65535, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 288, 289, 290, 291, 304, 305,
		306, 307, 65535, 65535, 65535, 65535, 320, 0, 368, 369,
		24, 118, 119, 65535, 65535, 65535, 65535, 65535, 18, 19,
		20, 21, 324, 325, 342, 328, 329, 344, 65535, 65535,
		264, 355, 353, 352, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 34, 35, 3, 2, 22, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 17, 16, 8, 65535, 65535, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 5, 4, 2, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 263, 65535,
		65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		38, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535, 65535,
		65535, 65535, 65, 102, 96, 105, 99, 70, 100, 101,
		112, 65535, 65535, 65535
	};

	public static string[] GetDataTree(int treeTag, int index)
	{
		string[] array = new string[1];
		switch (treeTag)
		{
		case 1:
			index = (Tune.prmIndex >> index * 4) & 0xF;
			goto case 0;
		case 2:
			index -= 8;
			goto case 0;
		case 0:
		{
			string text = ISORead.dataSensor[treeTag * 4 + index + ISOMain.eInfo * 20 + 64];
			if ((text != null) & (text != ""))
			{
				if (text.Substring(0, 1) == "-")
				{
					array[0] = text.Substring(1, text.Length - 1) + "-";
				}
				else
				{
					array[0] = text;
				}
			}
			break;
		}
		case 4:
		case 5:
		case 6:
		case 7:
		{
			array = new string[treeTag - 3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ISORead.dataSensor[index + i];
			}
			break;
		}
		}
		return array;
	}

	private static int parseData(byte[] data, int index, int len)
	{
		byte b = 0;
		short num = 0;
		for (int i = 0; i < len; i++)
		{
			b = data[index + i];
			b = (byte)((!((b >= 48) & (b < 58))) ? (((b >= 65) & (b < 71)) ? ((byte)(b - 55)) : 0) : ((byte)(b - 48)));
			num = (short)((num << 4) + b);
		}
		return num;
	}

	public static void DataSensorUpdate(byte[] msg, int start, int length)
	{
		if (msg[start++] == 58)
		{
			if (ISOMain.swMode != 1)
			{
				double num = (double)parseData(msg, start + 50, 2) * 0.07078;
				ISORead.dataSensor[5] = num.ToString("#0.0");
				num = parseData(msg, start + 4, 4);
				ISORead.dataSensor[0] = ((int)num).ToString();
				ISORead.dataValue[1] = ISORead.dataSensor[0];
				num = (double)parseData(msg, start + 44, 2) / 2.0;
				ISORead.dataSensor[1] = Math.Round(num).ToString();
				ISORead.dataValue[0] = ISORead.dataSensor[1];
			}
			else if (length == 9)
			{
				double num = parseData(msg, start + 3, 2);
				ISORead.dataNum[16] = (short)num;
				num /= 51.0;
				ISORead.dataSensor[3] = num.ToString("0.00");
			}
			if ((ISOMain.swMode == 2) & (ISORead.mMode == eMode.MODE_WALBRO_SENSORS) & (length < 0))
			{
				double num = parseData(msg, start + 8, 4);
				ISORead.dataSensor[2] = ((int)num).ToString();
				ISORead.dataSensor[24] = ((int)num).ToString();
				num = parseData(msg, start + 12, 4);
				ISORead.dataSensor[43] = (num / 656.0).ToString("0.00");
				num = (double)parseData(msg, start + 16, 4) / 1000.0;
				ISORead.dataSensor[13] = num.ToString("##0.000");
				num = (double)parseData(msg, start + 20, 4) / 1000.0;
				ISORead.dataSensor[14] = num.ToString("##0.000");
				num = (double)parseData(msg, start + 24, 4) / 1000.0;
				ISORead.dataSensor[15] = num.ToString("##0.000");
				num = (short)parseData(msg, start + 28, 4);
				ISORead.dataSensor[17] = (num / 10.0).ToString("##0.0");
				num = (short)parseData(msg, start + 32, 4);
				ISORead.dataSensor[18] = (num / 10.0).ToString("##0.0");
				num = (short)parseData(msg, start + 36, 4);
				ISORead.dataSensor[19] = (num / 10.0).ToString("##0.0");
				num = (double)parseData(msg, start + 46, 2) * 0.625 - 30.0;
				ISORead.dataSensor[10] = ((int)num).ToString();
				num = (double)parseData(msg, start + 48, 2) * 0.625 - 30.0;
				ISORead.dataSensor[3] = ((int)num).ToString();
				num = parseData(msg, start + 52, 2);
				ISORead.dataSensor[46] = (num / 100.0).ToString("0.00");
				num = (double)parseData(msg, start + 56, 2) / 2.55;
				ISORead.dataSensor[31] = ((int)num).ToString();
				num = parseData(msg, start + 58, 2);
				ISORead.dataSensor[34] = ((int)(num - (double)((num > 128.0) ? 256 : 0))).ToString();
				num = 1 ^ parseData(msg, start + 60, 2);
				ISORead.dataNum[5] = (short)num;
				num = parseData(msg, start + 62, 2);
				ISORead.dataNum[4] = (short)num;
				num = parseData(msg, start + 64, 2);
				short num2 = (short)num;
				ISORead.dataNum[2] = num2;
				ISORead.dataSensor[54] = ((double)ISORead.dataNum[(num2 == 0) ? 19 : 21] / 128.0).ToString("0.000");
			}
		}
	}

	public static void DataSensorReceive(byte[] msg, int start)
	{
		int num = 0;
		int num2 = (msg[start] << 8) | (msg[start + 1] + (ISOMain.sagemECU ? 65536 : 0));
		double num3 = (msg[start + 2] << 8) | msg[start + 3];
		switch (num2)
		{
		case 0:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 5.0) / 1000.0;
			if (ISOMain.swMode == 1)
			{
				ISORead.dataSensor[3] = num3.ToString("0.00");
				if ((ISOMain.ISCVReset | ISOMain._KTM | ISOMain._Four) & !ISOMain._LC4)
				{
					ISOMain.me.pbDash_Update(3, (int)(num3 * 10000.0 / 12.0));
				}
			}
			else
			{
				ISORead.dataSensor[28] = num3.ToString("0.00 V");
				ISOMain.me.tvSensor_Update(28);
			}
			break;
		case 1:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[1] = ((int)num3).ToString();
			if ((ISOMain.swMode == 2) | ((ISOMain._Four | ISOMain._LC4) & (ISOMain.swMode == 1)))
			{
				ISOMain.me.pbDash_Update(1, (int)num3);
			}
			else if (ISORead.vSens & ISOMain.eSens & !ISOMain._LC4)
			{
				ISORead.dataValue[0] = ISORead.dataSensor[1];
				ISOMain.me.InvalidateGrid(0);
			}
			break;
		case 2:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 5.0) / 1000.0;
			ISORead.dataSensor[ISOMain._KTM ? 22 : 26] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(ISOMain._KTM ? 22 : 26);
			break;
		case 3:
			num3 *= (double)(ISOMain._KTM ? 1 : 10);
			if (ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[0] = num3.ToString();
				ISOMain.me.InvalidateGrid(0);
			}
			ISORead.dataSensor[1] = ((int)num3).ToString();
			if (ISOMain._LC4 | ISOMain._Four)
			{
				ISOMain.me.pbDash_Update(2, (int)num3);
				ISORead.dataSensor[2] = ((int)num3).ToString();
			}
			else if (ISOMain.swMode == 1)
			{
				ISOMain.me.pbDash_Update(1, (int)num3);
			}
			if (ISOMain._KTM & !ISOMain._LC4)
			{
				ISORead.dataSensor[21] = ISORead.dataSensor[1] + " hPa";
				ISOMain.me.tvSensor_Update(21);
			}
			break;
		case 4:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 20.0) / 1000.0;
			ISORead.dataSensor[25] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(25);
			break;
		case 5:
			num3 /= 50.0;
			ISORead.dataSensor[24] = num3.ToString("#000 hPa");
			ISOMain.me.tvSensor_Update(24);
			break;
		case 7:
			ISOMain.DisplayMsg((num3 / 10.0).ToString("#0.0 V"), 256);
			break;
		case 8:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 19.608) / 1000.0;
			ISORead.dataSensor[12] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(12);
			break;
		case 9:
			num3 -= 40.0;
			ISORead.dataSensor[3] = num3.ToString();
			if (ISOMain.swMode == 2)
			{
				ISOMain.me.pbDash_Update(3, (int)num3);
			}
			break;
		case 16:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 19.608) / 1000.0;
			ISORead.dataSensor[11] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(11);
			break;
		case 17:
			num3 -= 40.0;
			ISORead.dataSensor[10] = num3.ToString("##0 °C");
			ISOMain.me.tvSensor_Update(10);
			break;
		case 18:
			num3 = num3 * 4.887 / 1000.0;
			ISORead.dataSensor[46] = num3.ToString("0.000 V");
			ISOMain.me.tvSensor_Update(46);
			break;
		case 19:
			num3 /= 200.0;
			ISORead.dataSensor[46] = num3.ToString("0.000 V");
			ISOMain.me.tvSensor_Update(46);
			break;
		case 20:
			num3 = num3 * 4.887 / 1000.0;
			ISORead.dataSensor[47] = num3.ToString("0.000 V");
			ISOMain.me.tvSensor_Update(47);
			break;
		case 21:
			num3 /= 200.0;
			ISORead.dataSensor[47] = num3.ToString("0.000 V");
			ISOMain.me.tvSensor_Update(47);
			break;
		case 22:
			num3 = num3 * 4.887 / 1000.0;
			ISORead.dataSensor[23] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(23);
			break;
		case 23:
			num3 *= (double)(ISOMain._KTM ? 1 : 10);
			if (ISOMain._KTM & ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[0] = num3.ToString();
				ISOMain.me.InvalidateGrid(0);
			}
			ISORead.dataSensor[2] = ((int)num3).ToString();
			ISOMain.me.pbDash_Update(2, (int)num3);
			break;
		case 24:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 5.0) / 1000.0;
			ISORead.dataSensor[35] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(35);
			break;
		case 33:
		{
			if (ISOMain._KTM)
			{
				num3 = num3 * 4.887 / 1000.0;
				ISORead.dataSensor[52] = num3.ToString("0.00 V");
				ISOMain.me.tvSensor_Update(52);
				break;
			}
			int num5 = (int)num3;
			while (num5 > 0)
			{
				num5 >>= 1;
				num++;
			}
			ISORead.dataSensor[8] = num.ToString();
			ISORead.sGear = true;
			break;
		}
		case 34:
			num3 /= 100.0;
			ISORead.dataSensor[55] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(55);
			break;
		case 35:
			num3 = num3 * 100.0 / 255.0;
			if (ISOMain.swMode == 1)
			{
				ISORead.dataSensor[3] = ((int)num3).ToString();
				if (ISOMain.EXBVReset)
				{
					ISOMain.me.pbDash_Update(3, (int)num3 * 10);
				}
			}
			else
			{
				ISORead.dataSensor[54] = ((int)num3).ToString("##0") + " %";
				ISOMain.me.tvSensor_Update(54);
			}
			break;
		case 38:
			num3 /= 51.0;
			ISORead.dataSensor[52] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(52);
			break;
		case 40:
			num3 = num3 * 4.887 / 1000.0;
			ISORead.dataSensor[53] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(53);
			break;
		case 41:
			ISORead.dataNum[0] = (short)num3;
			break;
		case 49:
			num3 *= 10.0;
			ISORead.dataSensor[3] = ((int)num3).ToString();
			if (ISOMain.swMode == 1)
			{
				ISOMain.me.pbDash_Update(3, (int)num3);
			}
			break;
		case 64:
			ISORead.dataNum[4] = (short)((int)num3 ^ 0xFF);
			break;
		case 65:
			ISORead.dataNum[7] = (short)((int)num3 ^ 0xFF);
			ISOMain.eqDev |= 1;
			if (ISORead.dataNum[7] != ISORead.dataNum[37])
			{
				ISORead.dataNum[37] = ISORead.dataNum[7];
				ISOMain.me.tvSensor_Update(160);
			}
			break;
		case 66:
			ISORead.dataNum[5] = (short)num3;
			break;
		case 67:
		{
			int num4 = ISORead.dataNum[15] & 2;
			num = (((int)num3 ^ 0xFF) & 1) | num4;
			ISORead.dataNum[15] = (short)num;
			ISORead.dataSensor[8] = num switch
			{
				1 => "2", 
				2 => "3", 
				_ => "", 
			};
			ISORead.sGear = true;
			break;
		}
		case 68:
			ISORead.dataNum[2] = (short)num3;
			break;
		case 69:
		{
			int num4 = ISORead.dataNum[15] & 1;
			num = (((int)num3 ^ 0xFF) & 2) | num4;
			ISORead.dataNum[15] = (short)num;
			ISORead.dataSensor[8] = num switch
			{
				1 => "2", 
				2 => "3", 
				_ => "", 
			};
			ISORead.sGear = true;
			break;
		}
		case 70:
			ISORead.dataNum[12] = (short)num3;
			ISOMain.eqDev |= 32;
			if (ISORead.dataNum[12] != ISORead.dataNum[42])
			{
				ISORead.dataNum[42] = ISORead.dataNum[12];
				ISOMain.me.tvSensor_Update(162);
			}
			break;
		case 96:
			ISORead.dataNum[9] = (short)num3;
			ISOMain.eqDev |= 4;
			if (ISORead.dataNum[9] != ISORead.dataNum[39])
			{
				ISORead.dataNum[39] = ISORead.dataNum[9];
				ISOMain.me.tvSensor_Update(161);
			}
			break;
		case 97:
			ISORead.dataNum[0] = (short)num3;
			break;
		case 98:
			ISORead.dataNum[1] = (short)num3;
			break;
		case 99:
			ISORead.dataNum[11] = (short)num3;
			ISOMain.eqDev |= 16;
			if (ISORead.dataNum[11] != ISORead.dataNum[41])
			{
				ISORead.dataNum[41] = ISORead.dataNum[11];
				ISOMain.me.tvSensor_Update(162);
			}
			break;
		case 100:
			ISORead.dataNum[13] = (short)num3;
			ISOMain.eqDev |= 64;
			if (ISORead.dataNum[13] != ISORead.dataNum[43])
			{
				ISORead.dataNum[43] = ISORead.dataNum[13];
				ISOMain.me.tvSensor_Update(163);
			}
			break;
		case 101:
			ISORead.dataNum[14] = (short)num3;
			ISOMain.eqDev |= 128;
			if (ISORead.dataNum[14] != ISORead.dataNum[44])
			{
				ISORead.dataNum[44] = ISORead.dataNum[14];
				ISOMain.me.tvSensor_Update(163);
			}
			break;
		case 102:
			ISORead.dataNum[8] = (short)((int)num3 ^ 0xFF);
			ISOMain.eqDev |= 2;
			if (ISORead.dataNum[8] != ISORead.dataNum[38])
			{
				ISORead.dataNum[38] = ISORead.dataNum[8];
				ISOMain.me.tvSensor_Update(160);
			}
			break;
		case 104:
			ISORead.dataNum[3] = (short)num3;
			break;
		case 105:
			ISORead.dataNum[10] = (short)num3;
			ISOMain.eqDev |= 8;
			if (ISORead.dataNum[10] != ISORead.dataNum[40])
			{
				ISORead.dataNum[40] = ISORead.dataNum[10];
				ISOMain.me.tvSensor_Update(161);
			}
			break;
		case 112:
			ISORead.dataNum[14] = (short)num3;
			ISOMain.eqDev |= 128;
			if (ISORead.dataNum[14] != ISORead.dataNum[44])
			{
				ISORead.dataNum[44] = ISORead.dataNum[14];
				ISOMain.me.tvSensor_Update(163);
			}
			break;
		case 118:
			num3 = num3 * (ISOMain._KTM ? 4.887 : 5.0) / 1000.0;
			if ((ISOMain.swMode == 1) & ISOMain._LC4)
			{
				ISORead.dataSensor[3] = num3.ToString("0.00");
				ISOMain.me.pbDash_Update(3, (int)(num3 * 10000.0 / 12.0));
			}
			else
			{
				ISORead.dataSensor[34] = num3.ToString("0.00 V");
				ISOMain.me.tvSensor_Update(34);
			}
			break;
		case 119:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[33] = ((int)num3).ToString();
			ISOMain.me.tvSensor_Update(33);
			if (ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[0] = ISORead.dataSensor[33];
				ISOMain.me.InvalidateGrid(0);
			}
			break;
		case 256:
			num3 = (int)(num3 / 40.0) * 10;
			ISORead.dataSensor[0] = num3.ToString();
			ISOMain.me.pbDash_Update(0, (int)num3);
			if (ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[1] = ISORead.dataSensor[0];
				ISOMain.me.InvalidateGrid(1);
			}
			break;
		case 257:
			ISORead.dataSensor[7] = num3.ToString();
			break;
		case 263:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[36] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(36);
			break;
		case 264:
			num3 = num3 * 10.0 / 40.0;
			ISORead.dataSensor[38] = num3.ToString("#000");
			ISOMain.me.tvSensor_Update(38);
			break;
		case 272:
			num3 /= 1000.0;
			ISORead.dataSensor[13] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(13);
			break;
		case 273:
			num3 /= 1000.0;
			ISORead.dataSensor[14] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(14);
			break;
		case 274:
			num3 /= 1000.0;
			ISORead.dataSensor[15] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(15);
			break;
		case 275:
			num3 /= 1000.0;
			ISORead.dataSensor[16] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(16);
			break;
		case 288:
			num3 = num3 / 2.0 - 64.0;
			ISORead.dataSensor[17] = num3.ToString("#0.0");
			ISOMain.me.tvSensor_Update(17);
			break;
		case 289:
			num3 = num3 / 2.0 - 64.0;
			ISORead.dataSensor[18] = num3.ToString("#0.0");
			ISOMain.me.tvSensor_Update(18);
			break;
		case 290:
			num3 = num3 / 2.0 - 64.0;
			ISORead.dataSensor[19] = num3.ToString("#0.0");
			ISOMain.me.tvSensor_Update(19);
			break;
		case 291:
			num3 = num3 / 2.0 - 64.0;
			ISORead.dataSensor[20] = num3.ToString("#0.0");
			ISOMain.me.tvSensor_Update(20);
			break;
		case 304:
			num3 /= 1000.0;
			ISORead.dataSensor[48] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(48);
			break;
		case 305:
			num3 /= 1000.0;
			ISORead.dataSensor[49] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(49);
			break;
		case 306:
			num3 /= 1000.0;
			ISORead.dataSensor[50] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(50);
			break;
		case 307:
			num3 /= 1000.0;
			ISORead.dataSensor[51] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(51);
			break;
		case 313:
			ISOMain.DisplayMsg(num3.ToString("##0"), 320);
			break;
		case 320:
			num3 = (int)num3 & 0xFF;
			ISORead.dataSensor[27] = (num3 / 10.0).ToString("#0.0");
			ISOMain.me.tvSensor_Update(27);
			break;
		case 324:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[43] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(43);
			break;
		case 325:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[44] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(44);
			break;
		case 328:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[40] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(40);
			break;
		case 329:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[41] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(41);
			break;
		case 342:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[45] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(45);
			break;
		case 344:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[42] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(42);
			break;
		case 352:
			ISORead.dataSensor[32] = num3.ToString();
			ISOMain.me.tvSensor_Update(32);
			break;
		case 353:
			ISORead.dataSensor[31] = num3.ToString();
			ISOMain.me.tvSensor_Update(31);
			break;
		case 355:
			num3 = (num3 - 128.0) * 100.0 / 128.0;
			ISORead.dataSensor[39] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(39);
			break;
		case 368:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[34] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(34);
			break;
		case 369:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[33] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(33);
			break;
		case 16643:
			num3 = (int)(num3 / 256.0);
			ISOMain.DisplayMsg(((int)num3).ToString("X2"), 288);
			break;
		case 65537:
			num3 /= 51.0;
			ISORead.dataSensor[12] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(12);
			break;
		case 65538:
			num3 /= 51.0;
			ISORead.dataSensor[11] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(11);
			break;
		case 65539:
			num3 -= 40.0;
			ISORead.dataSensor[3] = num3.ToString();
			ISOMain.me.pbDash_Update(3, (int)num3);
			break;
		case 65540:
			num3 -= 40.0;
			ISORead.dataSensor[10] = num3.ToString("##0 °C");
			ISOMain.me.tvSensor_Update(10);
			break;
		case 65541:
			ISORead.setSagemTrim(0, (int)num3 & 0xFF);
			num3 = num3 / 1.28 - 100.0;
			ISORead.dataSensor[31] = num3.ToString("##0.0") + " %";
			ISORead.dataSensor[74] = num3.ToString("##0.0");
			if (ISOMain.swMode == 2)
			{
				ISOMain.me.tvSensor_Update(31);
			}
			else
			{
				ISOMain.me.tvTest_Update(160, refresh: false);
			}
			break;
		case 65543:
			num3 /= 50.0;
			ISORead.dataSensor[24] = num3.ToString("#000 hPa");
			ISOMain.me.tvSensor_Update(24);
			break;
		case 65544:
			num3 = num3 / 2.0 - 64.0;
			ISORead.dataSensor[2] = num3.ToString("#0.0");
			ISOMain.me.pbDash_Update(2, (int)num3);
			break;
		case 65545:
			ISORead.dataNum[1] = (short)num3;
			break;
		case 65546:
			ISORead.dataNum[5] = (short)num3;
			break;
		case 65551:
			ISORead.dataNum[4] = (short)((int)num3 ^ 0xFF);
			break;
		case 65557:
			ISOMain.DisplayMsg((num3 / 10.0).ToString("#0.0 V"), 256);
			break;
		case 65559:
			num3 = (int)(num3 * (double)((ISOMain.swMode == 0) ? 58 : 39) / (double)ISOMain.offWOT);
			if (num3 > 100.0)
			{
				ISOMain.offWOT = (int)num3;
				num3 = 100.0;
			}
			ISORead.dataSensor[1] = ((int)num3).ToString();
			ISOMain.me.pbDash_Update(1, (int)num3);
			if (ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[0] = ISORead.dataSensor[1];
				ISOMain.me.InvalidateGrid(0);
			}
			break;
		case 65560:
			num3 /= 51.0;
			ISORead.dataSensor[28] = num3.ToString("0.00 V");
			ISOMain.me.tvSensor_Update(28);
			break;
		case 65562:
			num3 = num3 * 100.0 / 255.0;
			ISORead.dataSensor[36] = ((int)num3).ToString("##0") + " %";
			ISOMain.me.tvSensor_Update(36);
			break;
		case 65595:
			num3 = (int)(num3 / 40.0) * 10;
			ISORead.dataSensor[0] = num3.ToString();
			ISOMain.me.pbDash_Update(0, (int)num3);
			if (ISORead.vSens & ISOMain.eSens)
			{
				ISORead.dataValue[1] = ISORead.dataSensor[0];
				ISOMain.me.InvalidateGrid(1);
			}
			break;
		case 65612:
			num3 /= 312.0;
			ISORead.dataSensor[17] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(17);
			break;
		case 65613:
			num3 /= 312.0;
			ISORead.dataSensor[18] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(18);
			break;
		case 65614:
			num3 /= 312.0;
			ISORead.dataSensor[19] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(19);
			break;
		case 65615:
			num3 /= 312.0;
			ISORead.dataSensor[20] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(20);
			break;
		case 65836:
			ISORead.dataSensor[32] = num3.ToString();
			ISOMain.me.tvSensor_Update(32);
			break;
		case 66565:
			num3 /= 312.0;
			ISORead.dataSensor[13] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(13);
			break;
		case 66566:
			num3 /= 312.0;
			ISORead.dataSensor[14] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(14);
			break;
		case 66567:
			num3 /= 312.0;
			ISORead.dataSensor[15] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(15);
			break;
		case 66568:
			num3 /= 312.0;
			ISORead.dataSensor[16] = num3.ToString("#0.000");
			ISOMain.me.tvSensor_Update(16);
			break;
		case 74546:
			ISORead.setSagemTrim(2, (int)num3);
			num3 = (double)((int)num3 >> 8) / 1.28 - 100.0 + (double)((int)num3 & 0xFF) / 327.68;
			ISORead.dataSensor[21] = num3.ToString("##0.0") + " %";
			ISORead.dataSensor[76] = num3.ToString("##0.0");
			if (ISOMain.swMode == 2)
			{
				ISOMain.me.tvSensor_Update(21);
			}
			else
			{
				ISOMain.me.tvTest_Update(192, refresh: false);
			}
			break;
		case 74549:
			num3 = 147.0 - num3;
			ISORead.dataSensor[27] = (num3 * ((num3 > 0.0) ? 0.1 : 0.0)).ToString("#0.0");
			ISOMain.me.tvSensor_Update(27);
			break;
		case 74551:
			ISORead.setSagemTrim(1, (int)num3 & 0xFF);
			num3 = (int)(num3 / 1.28) - 100;
			ISORead.dataSensor[39] = num3.ToString();
			ISORead.dataSensor[75] = num3.ToString();
			if (ISOMain.swMode == 2)
			{
				ISOMain.me.tvSensor_Update(39);
			}
			else
			{
				ISOMain.me.tvTest_Update(176, refresh: false);
			}
			break;
		case 74566:
			num3 *= 10.0;
			ISORead.dataSensor[38] = num3.ToString("#000");
			ISOMain.me.tvSensor_Update(38);
			break;
		case 82177:
			num3 = (int)num3 >> 15;
			ISORead.dataNum[0] = (short)num3;
			break;
		case 82179:
			num3 = (int)num3 >> 8;
			ISOMain.DisplayMsg(((int)num3).ToString("X2"), 288);
			break;
		case 82189:
			num3 = (int)num3 >> 8;
			ISORead.dataSensor[7] = num3.ToString();
			break;
		case 82196:
			if (msg[start + 3] != byte.MaxValue)
			{
				ISORead.dataSensor[43] = ((double)(int)msg[start + 3] / 1.275 - 100.0).ToString("##0.0");
				ISOMain.me.tvSensor_Update(43);
			}
			num3 = (double)(int)msg[start + 2] / 200.0;
			ISORead.dataSensor[46] = num3.ToString("0.000 V");
			ISOMain.me.tvSensor_Update(46);
			break;
		}
	}
}
}
