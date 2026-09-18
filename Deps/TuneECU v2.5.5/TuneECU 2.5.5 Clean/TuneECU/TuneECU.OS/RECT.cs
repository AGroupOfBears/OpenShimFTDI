namespace TuneECU.OS
{

public struct RECT
{
	public uint left;

	public uint top;

	public uint right;

	public uint bottom;

	public POINT Location
	{
		get
		{
			return new POINT((int)left, (int)top);
		}
		set
		{
			right -= (uint)((int)left - value.x);
			bottom -= (uint)((int)bottom - value.y);
			left = (uint)value.x;
			top = (uint)value.y;
		}
	}

	public uint Width
	{
		get
		{
			return right - left;
		}
		set
		{
			right = left + value;
		}
	}

	public uint Height
	{
		get
		{
			return bottom - top;
		}
		set
		{
			bottom = top + value;
		}
	}

	public override string ToString()
	{
		return left + ":" + top + ":" + right + ":" + bottom;
	}
}
}
