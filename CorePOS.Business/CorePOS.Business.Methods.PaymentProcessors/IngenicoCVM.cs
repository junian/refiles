namespace CorePOS.Business.Methods.PaymentProcessors;

public static class IngenicoCVM
{
	public static string no_cvm;

	public static string verified_by_pin;

	public static string signature_required;

	public static string pin_signature;

	static IngenicoCVM()
	{
		Class2.oOsq41PzvTVMr();
		no_cvm = "0";
		verified_by_pin = "1";
		signature_required = "2";
		pin_signature = "3";
	}
}
