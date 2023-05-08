namespace CorePOS.Business.Methods.PaymentProcessors;

public static class IngenicoTransactionStatus
{
	public static string approved;

	public static string partial_approved;

	public static string declined;

	public static string comm_error;

	public static string cancelled_byuser;

	public static string timedout_onuser;

	public static string not_completed;

	public static string batch_empty;

	public static string declined_by_merchant;

	public static string record_not_found;

	public static string already_voided;

	static IngenicoTransactionStatus()
	{
		Class2.oOsq41PzvTVMr();
		approved = "00";
		partial_approved = "01";
		declined = "10";
		comm_error = "11";
		cancelled_byuser = "12";
		timedout_onuser = "13";
		not_completed = "14";
		batch_empty = "15";
		declined_by_merchant = "16";
		record_not_found = "17";
		already_voided = "18";
	}
}
