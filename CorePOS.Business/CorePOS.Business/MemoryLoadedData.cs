using System.Collections.Generic;
using System.Linq;
using CorePOS.Data;

namespace CorePOS.Business;

public static class MemoryLoadedData
{
	public static string OnlineOrderErrorMessage;

	public static List<int> LastThirdPartyIds;

	public static List<int> LastChitPrintQueueIds;

	public static bool isChitPrinting;

	public static bool IsDeliveryManagement;

	public static List<ItemsInGroup> ListOfItemsInGroupMemory;

	public static List<Item> all_active_items;

	public static List<Item> all_items;

	public static List<Layout> all_layouts;

	public static void UpdateMemoryItemInventory(int itemId, decimal inventoryCount)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		Item item = (from a in ListOfItemsInGroupMemory
			where a.ItemID == CS_0024_003C_003E8__locals0.itemId
			select a.Item).FirstOrDefault();
		if (item != null)
		{
			item.InventoryCount = inventoryCount;
		}
		Item item2 = all_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		if (item2 != null)
		{
			item2.InventoryCount = inventoryCount;
		}
		Item item3 = all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		if (item3 != null)
		{
			item3.InventoryCount = inventoryCount;
		}
	}

	static MemoryLoadedData()
	{
		Class2.oOsq41PzvTVMr();
		OnlineOrderErrorMessage = "";
		LastThirdPartyIds = new List<int>();
		LastChitPrintQueueIds = new List<int>();
		isChitPrinting = false;
		IsDeliveryManagement = false;
		ListOfItemsInGroupMemory = new List<ItemsInGroup>();
		all_layouts = new List<Layout>();
	}
}
