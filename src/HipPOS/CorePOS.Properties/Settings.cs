using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CorePOS.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance;

	public static Settings Default => defaultInstance;

	[UserScopedSetting]
	[DefaultSettingValue("True")]
	[DebuggerNonUserCode]
	public bool KeyboardConnected
	{
		get
		{
			return (bool)this["KeyboardConnected"];
		}
		set
		{
			this["KeyboardConnected"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("True")]
	[DebuggerNonUserCode]
	public bool isTabletDevice
	{
		get
		{
			return (bool)this["isTabletDevice"];
		}
		set
		{
			this["isTabletDevice"] = value;
		}
	}

	public Settings()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}

	private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
	{
	}

	private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
	{
	}

	static Settings()
	{
		Class26.Ggkj0JxzN9YmC();
		defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
