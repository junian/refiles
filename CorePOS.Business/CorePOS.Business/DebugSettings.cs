namespace CorePOS.Business;

public class DebugSettings
{
	public static bool EnableHipchatNotificationError;

	public static string syncServer;

	public static string orderingServer;

	public static string readyOnlyAPIServer;

	public DebugSettings()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}

	static DebugSettings()
	{
		Class2.oOsq41PzvTVMr();
		EnableHipchatNotificationError = false;
		syncServer = "https://apps.hipposhq.com";
		orderingServer = "https://order.hipposhq.com";
		readyOnlyAPIServer = "https://fetch1.hipposhq.com/";
	}
}
