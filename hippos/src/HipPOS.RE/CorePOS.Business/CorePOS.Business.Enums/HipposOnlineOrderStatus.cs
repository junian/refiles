namespace CorePOS.Business.Enums;

public static class HipposOnlineOrderStatus
{
	public const string Paid = "Paid";

	public const string ReceivedByKitchen = "ReceivedByKitchen";

	public const string ReceivedByStore = "ReceivedByStore";

	public const string Preparing = "Preparing";

	public const string OrderRejected = "OrderRejected";

	public const string OrderMade = "OrderMade";

	public const string ReadyForPickup = "ReadyForPickup";

	public const string ReadyForDelivery = "ReadyForDelivery";

	public const string InDelivery = "InDelivery";

	public const string Completed = "Completed";

	public const string Refunded = "Refunded";
}
