using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;

namespace CorePOS;

public static class AppSettings
{
	public static string AppVersion;

	public static string Build;

	[CompilerGenerated]
	private static int int_0;

	[CompilerGenerated]
	private static Screen screen_0;

	[CompilerGenerated]
	private static Screen screen_1;

	[CompilerGenerated]
	private static Screen screen_2;

	public static int ScreenCount
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public static Screen MainScreen
	{
		[CompilerGenerated]
		get
		{
			return screen_0;
		}
		[CompilerGenerated]
		set
		{
			screen_0 = value;
		}
	}

	public static Screen SecondaryScreen
	{
		[CompilerGenerated]
		get
		{
			return screen_1;
		}
		[CompilerGenerated]
		set
		{
			screen_1 = value;
		}
	}

	public static Screen ThirdScreen
	{
		[CompilerGenerated]
		get
		{
			return screen_2;
		}
		[CompilerGenerated]
		set
		{
			screen_2 = value;
		}
	}

	static AppSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		AppVersion = POSVersion.AppVersion;
		Build = POSVersion.Build;
		screen_0 = Screen.PrimaryScreen;
	}
}
