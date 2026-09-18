using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace TuneECU.Properties
{

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => defaultInstance;

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("COM1")]
	public string PortName
	{
		get
		{
			return (string)((SettingsBase)this)["PortName"];
		}
		set
		{
			((SettingsBase)this)["PortName"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("9600")]
	public int BaudRate
	{
		get
		{
			return (int)((SettingsBase)this)["BaudRate"];
		}
		set
		{
			((SettingsBase)this)["BaudRate"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("8")]
	public int DataBits
	{
		get
		{
			return (int)((SettingsBase)this)["DataBits"];
		}
		set
		{
			((SettingsBase)this)["DataBits"] = value;
		}
	}

	[DefaultSettingValue("None")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public Parity Parity
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Parity)((SettingsBase)this)["Parity"];
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((SettingsBase)this)["Parity"] = value;
		}
	}

	[DefaultSettingValue("One")]
	[UserScopedSetting]
	[DebuggerNonUserCode]
	public StopBits StopBits
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (StopBits)((SettingsBase)this)["StopBits"];
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((SettingsBase)this)["StopBits"] = value;
		}
	}
}
}
