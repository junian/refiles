namespace CorePOS.Business.Enums;

public static class OrderTypes
{
	public static readonly string DineIn;

	public static readonly string DineInOnline;

	public static readonly string PickUp;

	public static readonly string Delivery;

	public static readonly string ToGo;

	public static readonly string PreOrder;

	public static readonly string DeliveryOnline;

	public static readonly string TakeOutOnline;

	public static readonly string PickUpOnline;

	public static readonly string PickUpCurbsideOnline;

	public static readonly string MakeToStock;

	public static readonly string Catering;

	public static readonly string AllOnline;

	static OrderTypes()
	{
		Class2.oOsq41PzvTVMr();
		DineIn = "Dine In";
		DineInOnline = "Dine-In-Online";
		PickUp = "Pick-Up";
		Delivery = "Delivery";
		ToGo = "To-Go";
		PreOrder = "PreOrder";
		DeliveryOnline = "Delivery-Online";
		TakeOutOnline = "Take-Out-Online";
		PickUpOnline = "Pick-Up-Online";
		PickUpCurbsideOnline = "Pick-Up-Curbside-Online";
		MakeToStock = "Make To Stock";
		Catering = "Catering";
		AllOnline = "AllOnline";
	}
}
