namespace CorePOS.Business.Enums;

public enum HipposOnlineOrderStatusID
{
	ReceivedByStore = 1,
	ReceivedByKitchen = 2,
	OrderRejected = 30,
	Preparing = 40,
	OrderMade = 50,
	ReadyForPickup = 60,
	ReadyForDelivery = 70,
	InDelivery = 80,
	Paid = 100,
	Completed = 110,
	Refunded = 200
}
