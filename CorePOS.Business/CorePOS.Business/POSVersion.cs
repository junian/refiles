using System.Diagnostics;
using System.Reflection;

namespace CorePOS.Business;

public static class POSVersion
{
	public static string AppVersion;

	public static string Build;

	static POSVersion()
	{
		Class2.oOsq41PzvTVMr();
		AppVersion = Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Build;
		Build = Assembly.GetExecutingAssembly().GetName().Version.Revision + "." + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
	}
}
