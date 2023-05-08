namespace CorePOS.Business.Enums;

public class Servers
{
	public static string website;

	public static string sync_server;

	public static string ordering_server;

	public static string downloads;

	public static string updates;

	public static string activation_server;

	public static string etime_card_server;

	public Servers()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}

	static Servers()
	{
		Class2.oOsq41PzvTVMr();
		website = "https://www.hipposhq.com";
		sync_server = DebugSettings.syncServer;
		ordering_server = DebugSettings.orderingServer;
		downloads = "https://www.hipposhq.com/downloads/restaurant/required";
		updates = "https://www.hipposhq.com/downloads/restaurant/updates";
		activation_server = "https://apps.hipposhq.com";
		etime_card_server = DebugSettings.syncServer + "/time";
	}
}
