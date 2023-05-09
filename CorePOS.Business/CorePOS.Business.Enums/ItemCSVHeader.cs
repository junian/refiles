namespace CorePOS.Business.Enums;

public class ItemCSVHeader
{
	public static string[] RestaurantHeader;

	public ItemCSVHeader()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}

	static ItemCSVHeader()
	{
		Class2.oOsq41PzvTVMr();
		RestaurantHeader = new string[31]
		{
			"ItemID", "Barcode", "Use Smart Barcode", "Name", "Long Name", "Description", "Item Cost", "Item Price", "Item Sale Price", "Inventory Qty",
			"Track Inventory", "UOM", "Item Type", "Tax Rule", "Button Color", "Group", "Parent Group", "Min Free Options", "Max Free Options", "Station",
			"Item Classification", "Is Active", "Taxes Included", "Re-Order Limit", "Re-Order Qty", "Supplier", "Received Date", "Expiry Date", "Batch Number", "Loyalty Redemption",
			"Is Deleted"
		};
	}
}
