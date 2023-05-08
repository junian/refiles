namespace CorePOS.Business.Enums;

public static class ReasonTypes
{
	public static string discount;

	public static string refund;

	public static string voidreason;

	public static string tax_change;

	public static string option_tab;

	public static string payout;

	static ReasonTypes()
	{
		Class2.oOsq41PzvTVMr();
		discount = "discount";
		refund = "refund";
		voidreason = "void";
		tax_change = "tax change";
		option_tab = "option tab";
		payout = "payout";
	}
}
