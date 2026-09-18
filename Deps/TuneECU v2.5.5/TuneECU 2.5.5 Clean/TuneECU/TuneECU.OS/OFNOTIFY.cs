using System;

namespace TuneECU.OS
{

public struct OFNOTIFY
{
	public NMHDR hdr;

	public IntPtr OPENFILENAME;

	public IntPtr fileNameShareViolation;
}
}
