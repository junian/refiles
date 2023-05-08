namespace CorePOS.Business.Methods.PaymentProcessors;

public static class IngenicoTransactionTypes
{
	public static string purchase;

	public static string preauth;

	public static string preauth_completion;

	public static string refund;

	public static string purchase_correction;

	public static string refund_correction;

	public static string settlement;

	public static string settlement_auto;

	static IngenicoTransactionTypes()
	{
		Class2.oOsq41PzvTVMr();
		purchase = "00";
		preauth = "01";
		preauth_completion = "02";
		refund = "03";
		purchase_correction = "05";
		refund_correction = "06";
		settlement = "20";
		settlement_auto = "21";
	}
}
