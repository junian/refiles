namespace CorePOS.Business.Enums;

public static class ReportTypes
{
	public static string Orders;

	public static string Refunds;

	public static string SalesChart;

	public static string DayEndClosing;

	public static string DeliveryCommission;

	public static string DeliveryDrivers;

	static ReportTypes()
	{
		Class2.oOsq41PzvTVMr();
		Orders = "orders";
		Refunds = "refunds";
		SalesChart = "sales_charts";
		DayEndClosing = "day_end";
		DeliveryCommission = "delivery_commission";
		DeliveryDrivers = "delivery_driver";
	}
}
