namespace CorePOS.Business.Enums;

public static class PayoutTypes
{
	public static string SafeDrop;

	public static string Payout;

	public static string ReverseSafeDrop;

	public static string SafeDropClearing;

	public static string OpeningBalance;

	public static string ClosingBalance;

	static PayoutTypes()
	{
		Class2.oOsq41PzvTVMr();
		SafeDrop = "Safe Drop";
		Payout = "Payout";
		ReverseSafeDrop = "Reverse Safe Drop";
		SafeDropClearing = "Safe Drop Clearing";
		OpeningBalance = "Opening Til Balance";
		ClosingBalance = "Closing Til Balance";
	}
}
