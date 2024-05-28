namespace CorePOS.Business.Methods.PaymentProcessors;

public static class PaymentTerminalTransactionTypes
{
	public static string sale;

	public static string refund;

	public static string void_transaction;

	public static string ping;

	public static string settlement;

	public static string purchase_correction;

	static PaymentTerminalTransactionTypes()
	{
		Class2.oOsq41PzvTVMr();
		sale = "sale";
		refund = "refund";
		void_transaction = "void";
		ping = "ping";
		settlement = "settlement";
		purchase_correction = "purchase_correction";
	}
}
