using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class AdminMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string classification;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string groupClassification;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_1
	{
		public Group group;

		public _003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass1_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CgetGroups_003Eb__1(Group g)
		{
			if (g.ParentGroupID == group.GroupID)
			{
				return g.GroupClassification == CS_0024_003C_003E8__locals1.groupClassification;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_2
	{
		public Group childGroup;

		public _003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass1_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CgetGroups_003Eb__2(Group g)
		{
			if (g.ParentGroupID == childGroup.GroupID)
			{
				return g.GroupClassification == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_3
	{
		public Group gChildGroup;

		public _003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass1_3()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CgetGroups_003Eb__3(Group g)
		{
			if (g.ParentGroupID == gChildGroup.GroupID)
			{
				return g.GroupClassification == CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_4
	{
		public Group ggChildGroup;

		public _003C_003Ec__DisplayClass1_3 CS_0024_003C_003E8__locals4;

		public _003C_003Ec__DisplayClass1_4()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CgetGroups_003Eb__4(Group g)
		{
			if (g.ParentGroupID == ggChildGroup.GroupID)
			{
				return g.GroupClassification == CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Item item;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public Option opt;

		public _003C_003Ec__DisplayClass12_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public ItemsInGroup ig;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass12_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int ParentItemId;

		public _003C_003Ec__DisplayClass13_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public GroupsInItemsField groupAdded;

		public _003C_003Ec__DisplayClass13_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int ParentItemId;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public ItemsInItemsField itemAdded;

		public _003C_003Ec__DisplayClass14_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass15_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int ItemID;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public CustomFieldValueDisplay cfvd;

		public _003C_003Ec__DisplayClass16_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int ItemId;

		public _003C_003Ec__DisplayClass17_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public int ItemId;

		public _003C_003Ec__DisplayClass18_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int ItemID;

		public _003C_003Ec__DisplayClass19_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public string itemName;

		public int? itemID;

		public _003C_003Ec__DisplayClass22_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public int? itemID;

		public string upc;

		public string itemName;

		public _003C_003Ec__DisplayClass23_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public string groupName;

		public short? groupID;

		public string groupClassification;

		public _003C_003Ec__DisplayClass24_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public int ItemID;

		public _003C_003Ec__DisplayClass25_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public short GroupId;

		public _003C_003Ec__DisplayClass26_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public short UOMID;

		public _003C_003Ec__DisplayClass33_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public Guid guidOrderId;

		public Order order;

		public _003C_003Ec__DisplayClass34_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass35_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public int ParentGroupID;

		public _003C_003Ec__DisplayClass36_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public int groupId;

		public _003C_003Ec__DisplayClass37_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public static List<Group> GetAllGroup(string classification)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.classification = classification;
		return new GClass6().Groups.Where((Group a) => a.Archived == false && a.GroupClassification == CS_0024_003C_003E8__locals0.classification).ToList();
	}

	public static Dictionary<string, string> getGroups(string groupClassification = "product", bool withShowItems = true, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass1_0 _003C_003Ec__DisplayClass1_ = new _003C_003Ec__DisplayClass1_0();
		_003C_003Ec__DisplayClass1_.groupClassification = groupClassification;
		DataManager dataManager = new DataManager();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (withShowItems)
		{
			if (_003C_003Ec__DisplayClass1_.groupClassification == ItemClassifications.Product)
			{
				dictionary.Add("0", Resources._Show_All_Items);
			}
			else
			{
				dictionary.Add("0", Resources._Show_All_Ingredients);
			}
		}
		else
		{
			dictionary.Add("0", Resources._Select_A_Group_To_Edit);
		}
		List<Group> source = dataManager.GetGroups(_003C_003Ec__DisplayClass1_.groupClassification, onlyActive).ToList();
		using IEnumerator<Group> enumerator = source.Where((Group g) => g.ParentGroupID == 0).GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass1_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass1_;
			CS_0024_003C_003E8__locals1.group = enumerator.Current;
			dictionary.Add(CS_0024_003C_003E8__locals1.group.GroupID.ToString(), CS_0024_003C_003E8__locals1.group.GroupName + ((!CS_0024_003C_003E8__locals1.group.Active) ? " *inactive*" : string.Empty));
			using List<Group>.Enumerator enumerator2 = source.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals1.group.GroupID && g.GroupClassification == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.groupClassification).ToList().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1_2();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals1;
				CS_0024_003C_003E8__locals2.childGroup = enumerator2.Current;
				dictionary.Add(CS_0024_003C_003E8__locals2.childGroup.GroupID.ToString(), "  - " + CS_0024_003C_003E8__locals2.childGroup.GroupName + ((!CS_0024_003C_003E8__locals2.childGroup.Active) ? " *inactive*" : string.Empty));
				using List<Group>.Enumerator enumerator3 = source.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals2.childGroup.GroupID && g.GroupClassification == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification).ToList().GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass1_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass1_3();
					CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals2;
					CS_0024_003C_003E8__locals3.gChildGroup = enumerator3.Current;
					dictionary.Add(CS_0024_003C_003E8__locals3.gChildGroup.GroupID.ToString(), "  -- " + CS_0024_003C_003E8__locals3.gChildGroup.GroupName + ((!CS_0024_003C_003E8__locals3.gChildGroup.Active) ? " *inactive*" : string.Empty));
					using List<Group>.Enumerator enumerator4 = source.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals3.gChildGroup.GroupID && g.GroupClassification == CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification).ToList().GetEnumerator();
					while (enumerator4.MoveNext())
					{
						_003C_003Ec__DisplayClass1_4 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_4();
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals4 = CS_0024_003C_003E8__locals3;
						CS_0024_003C_003E8__locals0.ggChildGroup = enumerator4.Current;
						dictionary.Add(CS_0024_003C_003E8__locals0.ggChildGroup.GroupID.ToString(), "  --- " + CS_0024_003C_003E8__locals0.ggChildGroup.GroupName + ((!CS_0024_003C_003E8__locals0.ggChildGroup.Active) ? " *inactive*" : string.Empty));
						foreach (Group item in source.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals0.ggChildGroup.GroupID && g.GroupClassification == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.groupClassification).ToList())
						{
							dictionary.Add(item.GroupID.ToString(), "  ---- " + item.GroupName + ((!item.Active) ? " *inactive*" : string.Empty));
						}
					}
				}
			}
		}
		return dictionary;
	}

	public static List<Item> getItemsFromGroup(string groupName)
	{
		return new DataManager().GetItemsInGroup(groupName);
	}

	public static List<Item> getItemsFromGroup(short groupID)
	{
		return (from i in new DataManager().GetItemsInGroup(groupID)
			orderby i.ItemName
			select i).ToList();
	}

	public static Group getGroupFromID(short groupID)
	{
		return new DataManager().getGroupFromID(groupID);
	}

	public static Item getOneItem(int id)
	{
		return new DataManager().getOneItem(id);
	}

	public static void addNewItem(string barcode, string name, decimal itemCost, decimal itemPrice, decimal itemSalePrice, bool onsale, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList, int itemTypeID, int taxruleID, string string_0, short? sortOrder, string color, bool active, decimal inventoryQTY, bool disableIfSoldOut, short uom_id, bool trackInventory, string itemClassificationToAdd, string itemDescription, string itemNotes, string itemCourse, int maxFreeOptions, int minFreeOptions, bool TrackExpiry, bool ApplySaleComboOption, bool AutoResetQty, decimal ResetQty, bool RedemptionLoyalty, bool UseSmartBarcode, bool AutoPromptOption, decimal BatchStockQty, bool TaxesIncluded, decimal ReOrderLimit, decimal ReOrderQty)
	{
		new DataManager().insertItem(barcode, name, itemCost, itemPrice, itemSalePrice, onsale, startDateSale, endDateSale, StartTimeRangeSale, EndTimeRangeSale, daySaleList, itemTypeID, taxruleID, string_0, sortOrder, color, active, inventoryQTY, disableIfSoldOut, uom_id, trackInventory, itemClassificationToAdd, itemDescription, itemNotes, itemCourse, maxFreeOptions, minFreeOptions, TrackExpiry, ApplySaleComboOption, AutoResetQty, ResetQty, RedemptionLoyalty, UseSmartBarcode, AutoPromptOption, BatchStockQty, TaxesIncluded, ReOrderLimit, ReOrderQty);
	}

	public static void updateItem(int itemID, string barcode, string name, decimal itemCost, decimal itemPrice, decimal itemSalePrice, bool onsale, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList, int itemTypeID, int taxruleID, string string_0, short? sortOrder, string color, bool active, decimal inventoryQTY, bool disableIfSoldOut, short uom_id, bool trackInventory, string itemClassification, string itemDescription, string itemNote, string itemCourse, int maxFreeOptions, int minFreeOptions, bool TrackExpiry, bool ApplySaleComboOption, int supplierId, bool AutoResetQty, decimal ResetQty, bool RedemptionLoyalty, bool UseSmartBarcode, bool AutoPromptOption, decimal BatchStockQty, bool TaxesIncluded, decimal ReOrderLimit, decimal ReOrderQty, string inventoryUpdateReason = "Update Item")
	{
		new DataManager().updateItem(itemID, barcode, name, itemCost, itemPrice, itemSalePrice, onsale, startDateSale, endDateSale, StartTimeRangeSale, EndTimeRangeSale, daySaleList, itemTypeID, taxruleID, string_0, sortOrder, color, active, inventoryQTY, disableIfSoldOut, uom_id, trackInventory, itemClassification, itemDescription, itemNote, itemCourse, maxFreeOptions, minFreeOptions, TrackExpiry, ApplySaleComboOption, supplierId, AutoResetQty, ResetQty, RedemptionLoyalty, UseSmartBarcode, AutoPromptOption, BatchStockQty, TaxesIncluded, ReOrderLimit, ReOrderQty, inventoryUpdateReason);
	}

	public static void updateSetupSaleItem(int itemID, decimal itemSalePrice, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList)
	{
		new DataManager().updateSetupSaleItem(itemID, itemSalePrice, startDateSale, endDateSale, StartTimeRangeSale, EndTimeRangeSale, daySaleList);
	}

	public static void updateGroup(short groupID, string groupName, string groupColor, bool highTraffic, bool isActive, short ParentGroupID, string groupClassification, short SortOrder, bool OEShow, bool PatronShow)
	{
		new DataManager().updateGroup(groupID, groupName, groupColor, highTraffic, isActive, ParentGroupID, groupClassification, SortOrder, OEShow, PatronShow);
	}

	public static void addNewGroup(string groupName, string groupColor, bool highTraffic, bool isActive, short ParentGroupID, string groupClassification, short SortOrder, bool OEShow, bool PatronShow)
	{
		new DataManager().insertGroup(groupName, groupColor, highTraffic, isActive, ParentGroupID, groupClassification, SortOrder, OEShow, PatronShow);
	}

	public static void addItemInGroup(short groupID, int itemID)
	{
		new DataManager().insertItemInGroup(groupID, itemID);
	}

	public static void DeleteItem(GClass6 context, Item item)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.item = item;
		if (CS_0024_003C_003E8__locals0.item != null)
		{
			CS_0024_003C_003E8__locals0.item.isDeleted = true;
			CS_0024_003C_003E8__locals0.item.Synced = false;
			Helper.SubmitChangesWithCatch(context);
		}
		if (context.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).Count() > 0)
		{
			context.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList().ForEach(delegate(ItemsWithOption a)
			{
				a.ToBeDeleted = true;
				a.Synced = false;
			});
			Helper.SubmitChangesWithCatch(context);
		}
		List<Option> list = context.Options.Where((Option a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		if (list.Count > 0)
		{
			using List<Option>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
				CS_0024_003C_003E8__locals1.opt = enumerator.Current;
				context.ItemsWithOptions.Where((ItemsWithOption a) => a.OptionID == (int?)CS_0024_003C_003E8__locals1.opt.OptionID).ToList().ForEach(delegate(ItemsWithOption a)
				{
					a.ToBeDeleted = true;
					a.Synced = false;
				});
				Helper.SubmitChangesWithCatch(context);
			}
		}
		using List<ItemsInGroup>.Enumerator enumerator2 = context.ItemsInGroups.Where((ItemsInGroup a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList().GetEnumerator();
		while (enumerator2.MoveNext())
		{
			_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass12_2();
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals2.ig = enumerator2.Current;
			List<ItemsInGroup> list2 = (from a in context.ItemsInGroups
				where (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals2.ig.GroupID && a.ItemID != (int?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.item.ItemID
				orderby a.SortOrder
				select a).ToList();
			short num = 0;
			foreach (ItemsInGroup item2 in list2)
			{
				if (item2 != null)
				{
					item2.SortOrder = num;
				}
				if (item2.Item != null)
				{
					item2.Item.Synced = false;
				}
				Helper.SubmitChangesWithCatch(context);
				num = (short)(num + 1);
			}
		}
	}

	public static void UpdateGroupsInItems(List<GroupsInItemsField> groupsAddToPackage, int ParentItemId)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.ParentItemId = ParentItemId;
		GClass6 gClass = new GClass6();
		IQueryable<GroupsInItem> queryable = gClass.GroupsInItems.Where((GroupsInItem a) => a.ItemID == CS_0024_003C_003E8__locals0.ParentItemId);
		if (queryable.FirstOrDefault() != null)
		{
			gClass.GroupsInItems.DeleteAllOnSubmit(queryable);
		}
		if (groupsAddToPackage != null)
		{
			using List<GroupsInItemsField>.Enumerator enumerator = groupsAddToPackage.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass13_1();
				CS_0024_003C_003E8__locals1.groupAdded = enumerator.Current;
				Group group = gClass.Groups.Where((Group a) => a.GroupName == CS_0024_003C_003E8__locals1.groupAdded.GroupName && a.Archived == false).FirstOrDefault();
				if (group != null)
				{
					GroupsInItem entity = new GroupsInItem
					{
						GroupID = group.GroupID,
						ItemID = CS_0024_003C_003E8__locals0.ParentItemId,
						Quantity = CS_0024_003C_003E8__locals1.groupAdded.qty,
						SortOrder = 0,
						Synced = false
					};
					gClass.GroupsInItems.InsertOnSubmit(entity);
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void UpdateItemsInItems(List<ItemsInItemsField> itemsAddToPackage, int ParentItemId)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.ParentItemId = ParentItemId;
		GClass6 gClass = new GClass6();
		IQueryable<ItemsInItem> queryable = gClass.ItemsInItems.Where((ItemsInItem a) => a.ParentItemID == (int?)CS_0024_003C_003E8__locals0.ParentItemId);
		if (queryable.FirstOrDefault() != null)
		{
			gClass.ItemsInItems.DeleteAllOnSubmit(queryable);
		}
		if (itemsAddToPackage != null)
		{
			using List<ItemsInItemsField>.Enumerator enumerator = itemsAddToPackage.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_1();
				CS_0024_003C_003E8__locals1.itemAdded = enumerator.Current;
				Item item = gClass.Items.Where((Item tblItems) => tblItems.ItemName == CS_0024_003C_003E8__locals1.itemAdded.ItemName && tblItems.isDeleted == false).FirstOrDefault();
				if (item != null)
				{
					ItemsInItem entity = new ItemsInItem
					{
						ParentItemID = CS_0024_003C_003E8__locals0.ParentItemId,
						ItemID = item.ItemID,
						Quantity = CS_0024_003C_003E8__locals1.itemAdded.qty,
						Synced = false,
						UseChildItemPriceAndTax = CS_0024_003C_003E8__locals1.itemAdded.useItemSettings
					};
					gClass.ItemsInItems.InsertOnSubmit(entity);
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void UpdateMaterialsInItems(List<MaterialsInItem> materialsAddToPackage, int itemId)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		GClass6 gClass = new GClass6();
		IQueryable<MaterialsInItem> queryable = gClass.MaterialsInItems.Where((MaterialsInItem m) => m.ItemID == CS_0024_003C_003E8__locals0.itemId);
		if (queryable.FirstOrDefault() != null)
		{
			gClass.MaterialsInItems.DeleteAllOnSubmit(queryable);
		}
		if (materialsAddToPackage != null)
		{
			foreach (MaterialsInItem item in materialsAddToPackage)
			{
				MaterialsInItem entity = new MaterialsInItem
				{
					ItemID = CS_0024_003C_003E8__locals0.itemId,
					ItemMaterialID = item.ItemMaterialID,
					Quantity = item.Quantity,
					UOMID = item.UOMID,
					Comments = item.Comments
				};
				gClass.MaterialsInItems.InsertOnSubmit(entity);
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void UpdateItemCustomField(int ItemID, List<CustomFieldValueDisplay> listOfCfvd)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.ItemID = ItemID;
		GClass6 gClass = new GClass6();
		IQueryable<ItemCustomFieldValue> entities = gClass.ItemCustomFieldValues.Where((ItemCustomFieldValue c) => c.ItemId == CS_0024_003C_003E8__locals0.ItemID);
		gClass.ItemCustomFieldValues.DeleteAllOnSubmit(entities);
		using (List<CustomFieldValueDisplay>.Enumerator enumerator = listOfCfvd.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_1();
				CS_0024_003C_003E8__locals1.cfvd = enumerator.Current;
				CustomField customField = gClass.CustomFields.Where((CustomField f) => f.Value == CS_0024_003C_003E8__locals1.cfvd.FieldName).FirstOrDefault();
				if (customField != null)
				{
					ItemCustomFieldValue entity = new ItemCustomFieldValue
					{
						ItemId = CS_0024_003C_003E8__locals0.ItemID,
						CustomFieldId = customField.CustomFieldId,
						Value = CS_0024_003C_003E8__locals1.cfvd.FieldValue
					};
					gClass.ItemCustomFieldValues.InsertOnSubmit(entity);
				}
			}
		}
		try
		{
			Helper.SubmitChangesWithCatch(gClass);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public static void UpdateItemsSupplier(int ItemId, List<int> supplierIds)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.ItemId = ItemId;
		GClass6 gClass = new GClass6();
		IQueryable<ItemsSupplier> queryable = gClass.ItemsSuppliers.Where((ItemsSupplier a) => a.ItemId == CS_0024_003C_003E8__locals0.ItemId);
		if (queryable.Count() > 0)
		{
			gClass.ItemsSuppliers.DeleteAllOnSubmit(queryable);
			Helper.SubmitChangesWithCatch(gClass);
		}
		foreach (int supplierId in supplierIds)
		{
			gClass.ItemsSuppliers.InsertOnSubmit(new ItemsSupplier
			{
				ItemId = CS_0024_003C_003E8__locals0.ItemId,
				SupplierId = supplierId
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static List<Supplier> GetItemsSuppliers(int ItemId)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.ItemId = ItemId;
		return (from a in new GClass6().ItemsSuppliers
			where a.ItemId == CS_0024_003C_003E8__locals0.ItemId
			select a.Supplier).ToList();
	}

	public static List<CustomFieldValueDisplay> getItemCustomField(int ItemID)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.ItemID = ItemID;
		GClass6 gClass = new GClass6();
		var queryable = from tblItemCustomFieldValue in gClass.ItemCustomFieldValues
			join tblCustomField in gClass.CustomFields on tblItemCustomFieldValue.CustomFieldId equals tblCustomField.CustomFieldId
			where tblItemCustomFieldValue.ItemId == CS_0024_003C_003E8__locals0.ItemID
			select new { tblItemCustomFieldValue, tblCustomField };
		List<CustomFieldValueDisplay> list = new List<CustomFieldValueDisplay>();
		foreach (var item2 in queryable)
		{
			CustomFieldValueDisplay item = new CustomFieldValueDisplay
			{
				FieldName = item2.tblCustomField.Value,
				FieldValue = item2.tblItemCustomFieldValue.Value
			};
			list.Add(item);
		}
		return list;
	}

	public static List<Item> getAllItems(string itemClassification, bool onlyActive = false)
	{
		DataManager dataManager = new DataManager();
		if (!onlyActive)
		{
			return (from i in dataManager.getAllItems(itemClassification)
				orderby i.ItemName
				select i).ToList();
		}
		return (from i in dataManager.getAllItems(itemClassification)
			where i.Active
			orderby i.ItemName
			select i).ToList();
	}

	public static Dictionary<string, string> getAllItemsDictionary(string itemClassification = "product")
	{
		DataManager dataManager = new DataManager();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Item item in from x in dataManager.getAllItems(itemClassification)
			orderby x.ItemName
			select x)
		{
			dictionary.Add(item.ItemID.ToString(), item.ItemName);
		}
		return dictionary;
	}

	public static bool itemNameExistCheck(string itemName, int? itemID = null)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.itemName = itemName;
		CS_0024_003C_003E8__locals0.itemID = itemID;
		DataManager dataManager = new DataManager();
		if (CS_0024_003C_003E8__locals0.itemID.HasValue)
		{
			return dataManager.DataContext.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.itemName && (int?)i.ItemID != CS_0024_003C_003E8__locals0.itemID && i.isDeleted == false).FirstOrDefault() != null;
		}
		return dataManager.DataContext.Items.Where((Item i) => i.ItemName == CS_0024_003C_003E8__locals0.itemName && i.isDeleted == false).FirstOrDefault() != null;
	}

	public static bool itemUPCExistCheck(string itemName, string upc = null, int? itemID = null)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		CS_0024_003C_003E8__locals0.upc = upc;
		CS_0024_003C_003E8__locals0.itemName = itemName;
		DataManager dataManager = new DataManager();
		if (CS_0024_003C_003E8__locals0.itemID.HasValue)
		{
			return dataManager.DataContext.Items.Where((Item i) => (int?)i.ItemID != CS_0024_003C_003E8__locals0.itemID && i.Barcode == CS_0024_003C_003E8__locals0.upc && i.isDeleted == false).FirstOrDefault() != null;
		}
		return dataManager.DataContext.Items.Where((Item i) => i.ItemName != CS_0024_003C_003E8__locals0.itemName && i.Barcode == CS_0024_003C_003E8__locals0.upc && i.isDeleted == false).FirstOrDefault() != null;
	}

	public static bool groupExistCheck(bool isNewGroup, string groupName, string groupClassification, short? groupID = null)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0.groupName = groupName;
		CS_0024_003C_003E8__locals0.groupID = groupID;
		CS_0024_003C_003E8__locals0.groupClassification = groupClassification;
		DataManager dataManager = new DataManager();
		int num = ((!isNewGroup) ? 1 : 0);
		if (CS_0024_003C_003E8__locals0.groupID.HasValue)
		{
			return dataManager.DataContext.Groups.Where((Group i) => i.GroupName == CS_0024_003C_003E8__locals0.groupName && (int?)i.GroupID != (int?)CS_0024_003C_003E8__locals0.groupID && i.Archived == false && i.GroupClassification == CS_0024_003C_003E8__locals0.groupClassification).Count() > num;
		}
		return dataManager.DataContext.Groups.Where((Group i) => i.GroupName == CS_0024_003C_003E8__locals0.groupName && i.Archived == false && i.GroupClassification == CS_0024_003C_003E8__locals0.groupClassification).Count() > num;
	}

	public static bool uomBatchExistCheck(int ItemID)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0.ItemID = ItemID;
		if (new DataManager().DataContext.InventoryBatches.Where((InventoryBatch a) => a.ItemID == CS_0024_003C_003E8__locals0.ItemID && a.QTYRemaining > 0m).Count() <= 0)
		{
			return false;
		}
		return true;
	}

	public static bool groupDataAssignedCheck(short GroupId, string newGroupClassification)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.GroupId = GroupId;
		GClass6 gClass = new GClass6();
		Group group = gClass.Groups.Where((Group a) => a.GroupID == CS_0024_003C_003E8__locals0.GroupId).FirstOrDefault();
		if (newGroupClassification == group.GroupClassification)
		{
			return false;
		}
		if (group != null)
		{
			if (group.GroupClassification == ItemClassifications.Option)
			{
				if (gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.GroupID == CS_0024_003C_003E8__locals0.GroupId && a.ToBeDeleted == false).Count() > 0)
				{
					return true;
				}
				return false;
			}
			if (gClass.ItemsInGroups.Where((ItemsInGroup a) => (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals0.GroupId).Count() > 0)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static List<Item> getNonAssociatedItems(string itemClassification)
	{
		return new DataManager().getNonAssociatedItems(itemClassification);
	}

	public static List<Item> getAssociatedItems(string itemClassification)
	{
		return new DataManager().getAssociatedItems(itemClassification);
	}

	public static void doAssociateItemAndGroup(short groupID, short itemID, bool allowNew = false)
	{
		new DataManager().doAssociate(groupID, itemID, allowNew);
	}

	public static List<Order> getAllOrders(bool onlyPaid = false)
	{
		return new DataManager().getAllOrders(onlyPaid);
	}

	public static Dictionary<string, string> getItemTypes(string lang = "en-US")
	{
		DataManager dataManager = new DataManager();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (ItemType itemType in dataManager.DataContext.ItemTypes)
		{
			dictionary.Add(itemType.ItemTypeID.ToString(), smethod_0(itemType.ItemTypeName, lang));
		}
		return dictionary;
	}

	private static string smethod_0(string string_0, string string_1)
	{
		switch (string_0)
		{
		case "Other Goods & Services":
			if (string_1 == "es-US")
			{
				return "Otros bienes y servicios";
			}
			if (string_1 == "fr-CA")
			{
				return "Autres biens et services";
			}
			break;
		case "Prepared Food & Beverages":
			if (string_1 == "es-US")
			{
				return "Alimentos y bebidas preparados";
			}
			if (string_1 == "fr-CA")
			{
				return "Aliments et Boissons Préparés";
			}
			break;
		case "Snack & Beverages":
			if (string_1 == "es-US")
			{
				return "Snack & Bebidas";
			}
			if (string_1 == "fr-CA")
			{
				return "Snack & Boissons";
			}
			break;
		case "Ticket, Fare, or Admission":
			if (string_1 == "es-US")
			{
				return "Boleto, tarifa o admisión";
			}
			if (string_1 == "fr-CA")
			{
				return "Billet, tarif ou entrée";
			}
			break;
		}
		return string_0;
	}

	public static bool isUOMFractional(short UOMID)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0.UOMID = UOMID;
		if (new GClass6().UOMs.Where((UOM u) => u.UOMID == CS_0024_003C_003E8__locals0.UOMID).FirstOrDefault().isFractional)
		{
			return true;
		}
		return false;
	}

	public static Guid? CheckIfOrderItemIsShared(string OrderID)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.guidOrderId = new Guid(OrderID);
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.order = gClass.Orders.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals0.guidOrderId).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.order != null)
		{
			if (CS_0024_003C_003E8__locals0.order.ShareItemID.HasValue)
			{
				return CS_0024_003C_003E8__locals0.order.ShareItemID.Value;
			}
			Order order = gClass.Orders.Where((Order a) => a.ShareItemID == CS_0024_003C_003E8__locals0.order.OrderId).FirstOrDefault();
			if (order != null)
			{
				return order.OrderId;
			}
		}
		return null;
	}

	public static bool CheckIfItemIsMainPackage(int itemId)
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		GClass6 gClass = new GClass6();
		if (gClass.ItemsInItems.Where((ItemsInItem a) => a.ParentItemID.Value == CS_0024_003C_003E8__locals0.itemId).Count() > 0)
		{
			return true;
		}
		if (gClass.GroupsInItems.Where((GroupsInItem a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).Count() > 0)
		{
			return true;
		}
		if (gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.itemId && a.ToBeDeleted == false).Count() > 0)
		{
			return true;
		}
		return false;
	}

	public static void UnassociateItemsInGroupRecursion(int ParentGroupID)
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0.ParentGroupID = ParentGroupID;
		List<Group> list = new GClass6().Groups.Where((Group a) => a.ParentGroupID == CS_0024_003C_003E8__locals0.ParentGroupID).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Group item in list)
		{
			UnassociateItemsInGroupRecursion(item.GroupID);
			UnassociateItemsInGroup(item.GroupID);
		}
	}

	public static void UnassociateItemsInGroup(int groupId)
	{
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals0.groupId = groupId;
		GClass6 gClass = new GClass6();
		IQueryable<ItemsInGroup> queryable = gClass.ItemsInGroups.Where((ItemsInGroup g) => (int?)g.GroupID == (int?)CS_0024_003C_003E8__locals0.groupId);
		if (queryable.Count() > 0)
		{
			foreach (ItemsInGroup item in queryable)
			{
				item.Item.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
			gClass.ItemsInGroups.DeleteAllOnSubmit(queryable);
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public AdminMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
