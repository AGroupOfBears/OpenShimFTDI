using System;

namespace TuneECU.OS
{

public struct WINDOWPOS
{
	public IntPtr hwnd;

	public IntPtr hwndAfter;

	public int x;

	public int y;

	public int cx;

	public int cy;

	public uint flags;

	public override string ToString()
	{
		return x + ":" + y + ":" + cx + ":" + cy + ":" + ((SWP_Flags)flags).ToString();
	}
}
}
