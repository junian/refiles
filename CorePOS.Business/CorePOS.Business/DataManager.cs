using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;
using CorePOS.Data.Properties;

namespace CorePOS.Business;

public class DataManager
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string groupClassification;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public string itemClassification;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public short ParentGroupID;

		public string itemClassification;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string GroupName;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public short GroupID;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int ItemID;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public string itemClassification;

		public string query;

		public _003C_003Ec__DisplayClass15_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CgetAllItems_003Eb__2(Item i)
		{
			if (i.ItemName.Contains(query) && i.ItemClassification == itemClassification)
			{
				return !i.isDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public DataManager _003C_003E4__this;

		public string itemClassification;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public string itemClassification;

		public _003C_003Ec__DisplayClass17_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public string orderNumber;

		public List<Guid> orderIDs;

		public List<int> itemIDs;

		public _003C_003Ec__DisplayClass18_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public string address;

		public _003C_003Ec__DisplayClass18_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_2
	{
		public Item orig_item;

		public _003C_003Ec__DisplayClass18_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CSaveOneOrder_003Eb__10(ItemsInGroup a)
		{
			return a.ItemID == orig_item.ItemID;
		}

		internal bool _003CSaveOneOrder_003Eb__11(ItemsInGroup a)
		{
			return a.ItemID == orig_item.ItemID;
		}

		internal bool _003CSaveOneOrder_003Eb__13(ItemCourse a)
		{
			return a.Name == orig_item.ItemCourse;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_3
	{
		public string orderID;

		public _003C_003Ec__DisplayClass18_3()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CSaveOneOrder_003Eb__12(Order o)
		{
			return o.OrderId == new Guid(orderID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public string customer;

		public _003C_003Ec__DisplayClass19_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public string oNum;

		public _003C_003Ec__DisplayClass19_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CRecheckGuestCountSplittedBill_003Eb__2(Order o)
		{
			return o.OrderNumber == oNum;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_2
	{
		public int splittedGuestCount;

		public _003C_003Ec__DisplayClass19_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal void _003CRecheckGuestCountSplittedBill_003Eb__3(Order a)
		{
			a.GuestCount = splittedGuestCount;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int ComboItemId;

		public _003C_003Ec__DisplayClass20_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_1
	{
		public ItemsInItem childItem;

		public _003C_003Ec__DisplayClass20_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int itemTypeID;

		public int taxruleID;

		public short uom_id;

		public _003C_003Ec__DisplayClass22_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public int itemTypeID;

		public int taxruleID;

		public short uom_id;

		public _003C_003Ec__DisplayClass25_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public short groupID;

		public _003C_003Ec__DisplayClass26_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass29_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public short itemID;

		public short groupID;

		public _003C_003Ec__DisplayClass32_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public string KeyName;

		public _003C_003Ec__DisplayClass37_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass38_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public Guid OrderID;

		public _003C_003Ec__DisplayClass39_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public long appointmentID;

		public _003C_003Ec__DisplayClass41_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public DateTime? date;

		public _003C_003Ec__DisplayClass43_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public long id;

		public _003C_003Ec__DisplayClass45_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public string question;

		public _003C_003Ec__DisplayClass54_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public string question;

		public _003C_003Ec__DisplayClass56_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass59_0
	{
		public DateTime OrderDateCreated;

		public _003C_003Ec__DisplayClass59_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CIsPromotionTime_003Eb__0(string a)
		{
			return a.Contains(OrderDateCreated.DayOfWeek.ToString().ToUpper());
		}
	}

	private GClass6 gclass6_0;

	public GClass6 DataContext
	{
		get
		{
			return gclass6_0;
		}
		set
		{
			gclass6_0 = value;
		}
	}

	public DataManager()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
		gclass6_0 = new GClass6();
	}

	public DataManager(GClass6 appDataContext)
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
		gclass6_0 = appDataContext;
	}

	public List<CompanySetup> GetCompanySetup()
	{
		return gclass6_0.CompanySetups.OrderBy((CompanySetup r) => r.Name).ToList();
	}

	public List<Group> GetGroups(string groupClassification, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.groupClassification = groupClassification;
		List<Group> list = (from g in gclass6_0.Groups
			where g.GroupClassification == CS_0024_003C_003E8__locals0.groupClassification && g.Archived == false
			orderby g.GroupName
			select g).ToList();
		if (onlyActive)
		{
			list = list.Where((Group g) => g.Active).ToList();
		}
		return list;
	}

	public List<Group> GetParentGroups(string itemClassification, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		List<Group> list = gclass6_0.Groups.Where((Group g) => g.ParentGroupID == 0 && g.GroupClassification == CS_0024_003C_003E8__locals0.itemClassification && g.Archived == false).ToList();
		if (onlyActive)
		{
			list = list.Where((Group g) => g.Active).ToList();
		}
		return list;
	}

	public List<Group> GetChildGroups(string itemClassification, short ParentGroupID, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.ParentGroupID = ParentGroupID;
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		List<Group> list = gclass6_0.Groups.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals0.ParentGroupID && g.GroupClassification == CS_0024_003C_003E8__locals0.itemClassification && g.Archived == false).ToList();
		if (onlyActive)
		{
			list = list.Where((Group g) => g.Active).ToList();
		}
		return list;
	}

	public List<Item> GetItemsInGroup(string GroupName, bool onlyActive = true)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.GroupName = GroupName;
		if (onlyActive)
		{
			return (from i in method_0(bool_0: true)
				where i.Group.GroupName.ToUpper() == CS_0024_003C_003E8__locals0.GroupName.ToUpper()
				select i into grp
				select grp.Item).ToList();
		}
		return (from i in method_0()
			where i.Group.GroupName.ToUpper() == CS_0024_003C_003E8__locals0.GroupName.ToUpper()
			select i into grp
			select grp.Item).ToList();
	}

	public List<Item> GetItemsInGroup(short GroupID, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.GroupID = GroupID;
		return (from i in method_0(onlyActive)
			where (int?)i.GroupID == (int?)CS_0024_003C_003E8__locals0.GroupID
			select i into grp
			select grp.Item).ToList();
	}

	public List<Item> GetItemsInGroup(int ItemID)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.ItemID = ItemID;
		return (from i in method_0()
			where i.Item.ItemID == CS_0024_003C_003E8__locals0.ItemID
			select i into grp
			select grp.Item).ToList();
	}

	private IQueryable<ItemsInGroup> method_0(bool bool_0 = false)
	{
		if (bool_0)
		{
			return from grp in gclass6_0.ItemsInGroups
				where grp.Item.Active == true && grp.Item.isDeleted == false
				select grp into a
				orderby a.SortOrder
				select a;
		}
		return from grp in gclass6_0.ItemsInGroups
			where grp.Item.isDeleted == false
			select grp into a
			orderby a.SortOrder
			select a;
	}

	public List<Item> getItemsInItem(int itemID)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		return (from ini in gclass6_0.ItemsInItems
			join i in gclass6_0.Items on ini.ItemID equals i.ItemID
			where ini.ParentItemID == (int?)CS_0024_003C_003E8__locals0.itemID && !i.isDeleted
			select i).ToList();
	}

	public List<Item> getAllItems(string itemClassification = "product", string query = null, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		CS_0024_003C_003E8__locals0.query = query;
		List<Item> list = ((!onlyActive) ? gclass6_0.Items.Where((Item i) => i.ItemClassification == CS_0024_003C_003E8__locals0.itemClassification && i.isDeleted == false).ToList() : gclass6_0.Items.Where((Item i) => i.Active == true && i.isDeleted == false && i.ItemClassification == CS_0024_003C_003E8__locals0.itemClassification).ToList());
		if (CS_0024_003C_003E8__locals0.query != null)
		{
			list = list.Where((Item i) => i.ItemName.Contains(CS_0024_003C_003E8__locals0.query) && i.ItemClassification == CS_0024_003C_003E8__locals0.itemClassification && !i.isDeleted).ToList();
		}
		return list;
	}

	public List<Item> getNonAssociatedItems(string itemClassification)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		return (from i in gclass6_0.Items
			where !gclass6_0.ItemsInGroups.Select((ItemsInGroup grp) => grp.ItemID).Distinct().Contains(i.ItemID) && i.ItemClassification == CS_0024_003C_003E8__locals0.itemClassification && i.isDeleted == false
			orderby i.ItemName
			select i).ToList();
	}

	public List<Item> getAssociatedItems(string itemClassification)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		return (from grp in gclass6_0.ItemsInGroups
			where grp.Item.ItemClassification == CS_0024_003C_003E8__locals0.itemClassification
			select grp.Item into i
			where i.isDeleted == false
			select i).ToList();
	}

	public void SaveOneOrder(List<Item> itemList, string orderNumber, string customer, string orderType, int customerID, string paymentMethod, decimal TenderCash, decimal TenderChange, DataManager manager, bool isPaid = true, string customerInfo = "", string discountReason = "", string customerInfoName = "", string CustomerInfoPhone = "", int GuestCount = 1, bool isDiscount = false, string taxChangeReason = "", short seatNum = 0, int? terminalId = null, List<decimal> transactionFees = null, short EmployeeCreated = 0, DateTime? FulfillmentDate = null, string OrderDiscountType = "", bool GratuityRemoved = false, byte overrideFlagID = 0, string orderNotes = "")
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		decimal rounding = default(decimal);
		decimal num = default(decimal);
		int num2 = 0;
		bool customerNotified = false;
		if (isPaid && MemoryLoadedData.isChitPrinting)
		{
			int num3 = 3;
			for (int i = 0; i < num3; i++)
			{
				Thread.Sleep(1000);
				if (!MemoryLoadedData.isChitPrinting)
				{
					break;
				}
			}
		}
		GClass6 gClass = new GClass6();
		if (paymentMethod.Contains("SAVED ORDER") && OrderMethods.CheckOrderIsPaid(CS_0024_003C_003E8__locals0.orderNumber, orderType) && gClass.TransactionReceipts.Where((TransactionReceipt a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).Count() > 0)
		{
			return;
		}
		terminalId = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["CurrentTerminalID"].ToString());
		if (terminalId.HasValue)
		{
			int? num4 = terminalId;
			if (!((num4.GetValueOrDefault() == 0) & num4.HasValue))
			{
				goto IL_01c8;
			}
		}
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			terminalId = terminal.TerminalID;
		}
		goto IL_01c8;
		IL_01c8:
		bool flag = ((SettingsHelper.GetSettingValueByKey("print_chit_change_cancel") == "ON") ? true : false);
		bool flag2 = ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON") ? true : false);
		bool flag3 = false;
		string text = string.Empty;
		CS_0024_003C_003E8__locals0.orderIDs = (from x in itemList
			where !string.IsNullOrEmpty(x.Temp) && !x.Temp.Contains("11111111-1111-1111-1111-111111111111")
			select x into y
			select new Guid(y.Temp.Split('|')[0])).ToList();
		CS_0024_003C_003E8__locals0.itemIDs = itemList.Select((Item x) => x.ItemID).ToList();
		manager.DataContext = new GClass6();
		List<Order> source = manager.DataContext.Orders.Where((Order x) => CS_0024_003C_003E8__locals0.orderIDs.Contains(x.OrderId)).ToList();
		List<ItemsInGroup> source2 = gClass.ItemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals0.itemIDs.Contains(x.ItemID.Value)).ToList();
		List<ItemCourse> source3 = gClass.ItemCourses.ToList();
		decimal? deliveryTravelDistanceKM = null;
		int deliveryTravelTimeMinutes = 0;
		if (orderType == OrderTypes.Delivery || orderType == OrderTypes.PickUp)
		{
			_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_1();
			CS_0024_003C_003E8__locals1.address = customerInfo.Replace(Resources.DELIVER_TO, "").Trim();
			Customer customer2 = gClass.Customers.Where((Customer a) => a.Address == CS_0024_003C_003E8__locals1.address).FirstOrDefault();
			if (customer2 != null)
			{
				deliveryTravelDistanceKM = customer2.DeliveryTravelDistanceKM;
				deliveryTravelTimeMinutes = customer2.DeliveryTravelTimeMinutes;
			}
		}
		string text2 = null;
		bool flag4 = false;
		List<Order> list = new List<Order>();
		decimal num5 = default(decimal);
		int orderOnHoldTime = 0;
		int guestCount = GuestCount;
		foreach (Item item in itemList)
		{
			_003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass18_2();
			DataManager dataManager = new DataManager();
			CS_0024_003C_003E8__locals2.orig_item = dataManager.getOneItem(item.ItemID);
			Order order = null;
			if (!string.IsNullOrEmpty(item.Temp) && !item.Temp.Contains("11111111-1111-1111-1111-111111111111"))
			{
				_003C_003Ec__DisplayClass18_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass18_3();
				Guid empty = Guid.Empty;
				CS_0024_003C_003E8__locals3.orderID = empty.ToString();
				if (item.Temp.Contains("|"))
				{
					string[] array = item.Temp.Split('|');
					CS_0024_003C_003E8__locals3.orderID = array[0];
				}
				else
				{
					CS_0024_003C_003E8__locals3.orderID = item.Temp;
				}
				order = source.Where((Order o) => o.OrderId == new Guid(CS_0024_003C_003E8__locals3.orderID)).FirstOrDefault();
				if (order != null)
				{
					customerNotified = order.CustomerNotified;
					if (!flag4)
					{
						flag4 = order.FlagID == 5;
					}
					if (item.InventoryCount >= 1m && item.InventoryCount != order.Qty && !isPaid)
					{
						order.Notified = false;
						order.PrintedInKitchen = false;
						order.StationNotified = null;
						order.IsModified = true;
						if (!flag4)
						{
							order.FlagID = 3;
						}
					}
				}
			}
			if (order == null)
			{
				order = new Order();
				order.OrderId = Guid.NewGuid();
				order.OrderNumber = CS_0024_003C_003E8__locals0.orderNumber;
				order.OrderType = orderType;
				order.CustomerInfoName = customerInfoName;
				order.ItemBarcode = CS_0024_003C_003E8__locals2.orig_item.Barcode;
				if (!CS_0024_003C_003E8__locals2.orig_item.TaxesIncluded)
				{
					order.ItemPrice = ((item.ItemName == ConstantItems.Delivery_Fee) ? (item.ItemPrice + OrderMethods.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Item) + OrderMethods.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Order)) : CS_0024_003C_003E8__locals2.orig_item.ItemPrice);
				}
				else
				{
					decimal inventoryCount = CS_0024_003C_003E8__locals2.orig_item.InventoryCount;
					CS_0024_003C_003E8__locals2.orig_item.InventoryCount = 1m;
					List<Item> list2 = new List<Item>();
					list2.Add(CS_0024_003C_003E8__locals2.orig_item);
					order.ItemPrice = TaxMethods.GetPreTaxPrice(list2, CS_0024_003C_003E8__locals2.orig_item);
					CS_0024_003C_003E8__locals2.orig_item.InventoryCount = inventoryCount;
				}
				order.DateCreated = DateTime.Now.AddMilliseconds(num2 * 100);
				order.CreatedByTerminalID = terminalId;
				order.Instructions = "";
				if (paymentMethod.Equals("SPLIT SAVED ORDER"))
				{
					Order order2 = order;
					order.Notified = true;
					order2.PrintedInKitchen = true;
					order.DateFilled = DateTime.Now;
					Order order3 = order;
					string stationMade = (order.StationPrinted = CS_0024_003C_003E8__locals2.orig_item.StationID);
					order3.StationMade = stationMade;
				}
				else
				{
					Order order4 = order;
					order.Notified = false;
					order4.PrintedInKitchen = false;
				}
				Order order5 = order;
				short? userCreated = (order.UserServed = ((EmployeeCreated == 0) ? Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()) : EmployeeCreated));
				order5.UserCreated = userCreated;
				if (SettingsHelper.GetSettingValueByKey("delivery_management") == "ON" && order.OrderType == OrderTypes.Delivery && MemoryLoadedData.IsDeliveryManagement)
				{
					order.UserServed = null;
				}
				if (item.Temp.Contains("11111111-1111-1111-1111-111111111111"))
				{
					order.DateFilled = DateTime.Now;
					string[] array2 = item.Temp.Split('|');
					order.ShareItemID = new Guid(array2[1]);
					order.ItemMadeNotified = true;
				}
				order.GroupName = ((source2.Where((ItemsInGroup a) => a.ItemID == CS_0024_003C_003E8__locals2.orig_item.ItemID).Count() > 0) ? source2.Where((ItemsInGroup a) => a.ItemID == CS_0024_003C_003E8__locals2.orig_item.ItemID).First().Group.GroupName : "Uncategorized");
				list.Add(order);
			}
			if (flag4)
			{
				Order order6 = order;
				DateTime? dateCreated = (order.LastDateModified = DateTime.Now.AddMilliseconds(num2 * 100));
				order6.DateCreated = dateCreated;
			}
			if (!string.IsNullOrEmpty(order.OrderTicketNumber))
			{
				text = order.OrderTicketNumber;
			}
			else if (string.IsNullOrEmpty(text))
			{
				text = OrderMethods.GetNewOrderTicketNumber(orderType);
			}
			if (flag2)
			{
				order.OrderTicketNumber = text;
			}
			if (customer.ToUpper() == "WALK IN")
			{
				customer = customer + " " + text;
			}
			order.ComboID = item.SortOrder;
			order.Synced = false;
			if (order.OptionComboId == 0 && item.MinFreeOptions > 0)
			{
				order.OptionComboId = (short)item.MinFreeOptions;
			}
			order.CustomerID = customerID;
			order.Customer = customer;
			order.DeliveryTravelDistanceKM = deliveryTravelDistanceKM;
			order.DeliveryTravelTimeMinutes = deliveryTravelTimeMinutes;
			order.OrderNumber = CS_0024_003C_003E8__locals0.orderNumber;
			order.TerminalID = terminalId;
			order.DiscountReason = discountReason;
			order.OrderDiscountType = OrderDiscountType;
			if (!string.IsNullOrEmpty(orderNotes))
			{
				order.OrderNotes = orderNotes;
			}
			if (!order.ItemOptionId.HasValue)
			{
				order.ItemOptionId = (int)item.ResetQty;
			}
			if (item.MaxFreeOptions != 0)
			{
				order.InventoryBatchId = item.MaxFreeOptions;
			}
			if (paymentMethod.Contains("SAVED ORDER") && order.Paid && order.DatePaid.HasValue)
			{
				continue;
			}
			if (order.OrderType == OrderTypes.DineIn)
			{
				order.GuestCount = ((item.CloudItemID > 0L) ? Convert.ToInt32(item.CloudItemID) : ((GuestCount > 1) ? GuestCount : GuestMethods.GetCurrentTableGuestCapacity(customer.Replace("Table ", ""))));
			}
			else
			{
				order.GuestCount = GuestCount;
			}
			guestCount = order.GuestCount;
			order.ItemID = item.ItemID;
			order.ItemSellPrice = item.ItemPrice;
			order.TenderAmount = TenderCash;
			order.TenderChange = TenderChange;
			int num7 = Convert.ToInt32(item.StationID);
			int num8 = 0;
			if (SettingsHelper.GetSettingValueByKey("fulfillment_threshold") == "ON" && (orderType == OrderTypes.Delivery || orderType == OrderTypes.PickUp))
			{
				num8 = (int)(Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("fulfillment_threshold_time")) * 60m);
			}
			if (num7 == 0 && orderType == OrderTypes.DineIn)
			{
				if (order.ItemOptionId.HasValue && order.ItemOptionId.Value != 0)
				{
					order.OrderOnHoldTime = orderOnHoldTime;
				}
				else
				{
					ItemCourse itemCourse = source3.Where((ItemCourse a) => a.Name == CS_0024_003C_003E8__locals2.orig_item.ItemCourse).FirstOrDefault();
					if (itemCourse != null)
					{
						order.OrderOnHoldTime = itemCourse.OnHoldMinutes;
					}
					else
					{
						order.OrderOnHoldTime = num7;
					}
					orderOnHoldTime = order.OrderOnHoldTime;
				}
			}
			else
			{
				order.OrderOnHoldTime = num7;
			}
			if (order.OrderOnHoldTime != 0 && order.OrderOnHoldTime != -1)
			{
				if (FulfillmentDate.HasValue)
				{
					if (order.FulfillmentAt != FulfillmentDate)
					{
						flag3 = true;
					}
					order.FulfillmentAt = FulfillmentDate;
				}
				else
				{
					order.FulfillmentAt = (order.LastDateModified.HasValue ? order.LastDateModified.Value : order.DateCreated.Value).AddMinutes(order.OrderOnHoldTime);
				}
				if (!(order.OrderType == OrderTypes.Delivery) && !(order.OrderType == OrderTypes.PickUp))
				{
					if (order.OrderType != OrderTypes.DineIn)
					{
						order.OrderOnHoldTime = 0;
					}
				}
				else
				{
					int num9 = order.OrderOnHoldTime - num8;
					order.OrderOnHoldTime = ((num8 != 0 && num9 >= 0) ? num9 : 0);
				}
			}
			order.ItemIdentifier = item.ItemClassification;
			order.ItemCourse = (string.IsNullOrEmpty(item.ItemCourse) ? ItemCourses.Uncategorized : item.ItemCourse);
			if (item.ItemCost != -1m)
			{
				order.ItemPrice = item.ItemCost;
			}
			order.ItemCost = CS_0024_003C_003E8__locals2.orig_item.ItemCost;
			if (!string.IsNullOrEmpty(item.ItemLongName))
			{
				order.OverridePrice = Convert.ToDecimal(item.ItemLongName);
			}
			if ((!string.IsNullOrEmpty(item.Temp) && !item.Temp.Contains("11111111-1111-1111-1111-111111111111")) || item.Description.Contains("==="))
			{
				order.LastDateModified = DateTime.Now.AddMilliseconds(num2 * 100);
				if (flag)
				{
					if (string.IsNullOrEmpty(order.Instructions))
					{
						order.Instructions = "";
					}
					if (flag3)
					{
						order.DateFilled = null;
						order.Notified = false;
						order.StationNotified = null;
						order.PrintedInKitchen = false;
						order.IsModified = true;
						order.StationPrinted = null;
						if (!flag4)
						{
							order.FlagID = 7;
						}
					}
					if (string.IsNullOrEmpty(item.Temp) && item.Description.Contains("==="))
					{
						order.DateFilled = null;
						order.Notified = false;
						order.StationNotified = null;
						order.PrintedInKitchen = false;
						order.IsModified = true;
						order.StationPrinted = null;
						if (!flag4)
						{
							order.FlagID = 2;
						}
					}
					else if (order.Void != !item.Active)
					{
						order.DateFilled = null;
						order.Notified = false;
						order.StationNotified = null;
						order.PrintedInKitchen = false;
						order.IsModified = true;
						order.DateVoided = DateTime.Now;
						order.StationPrinted = null;
						if (!flag4)
						{
							order.FlagID = 4;
						}
					}
					else if ((order.Instructions != item.Description || (order.ItemName != null && !order.ItemName.Contains(item.ItemName)) || item.Description.Contains("===") || item.InventoryCount != order.Qty) && !paymentMethod.Equals("SPLIT SAVED ORDER"))
					{
						order.DateFilled = null;
						order.Notified = false;
						order.StationNotified = null;
						order.PrintedInKitchen = false;
						order.IsModified = true;
						order.StationPrinted = null;
						if (!flag4)
						{
							order.FlagID = 3;
						}
					}
				}
				else
				{
					string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_chit_cashout");
					if (!flag4)
					{
						if (string.IsNullOrEmpty(item.Temp) && item.Description.Contains("==="))
						{
							if (settingValueByKey == "OFF")
							{
								order.Notified = true;
								order.PrintedInKitchen = true;
								order.IsModified = true;
							}
							order.FlagID = 2;
						}
						else if (order.Void != !item.Active)
						{
							if (settingValueByKey == "OFF")
							{
								order.Notified = true;
								order.PrintedInKitchen = true;
								order.IsModified = true;
								order.DateVoided = DateTime.Now;
								order.StationNotified = null;
							}
							order.FlagID = 4;
						}
						else if (order.Instructions != item.Description || order.ItemName != item.ItemName || item.Description.Contains("===") || item.InventoryCount != order.Qty || flag3)
						{
							if (settingValueByKey == "OFF")
							{
								order.Notified = true;
								order.PrintedInKitchen = true;
								order.IsModified = true;
								order.StationNotified = null;
							}
							order.FlagID = 3;
						}
					}
				}
			}
			if (overrideFlagID == 6)
			{
				order.FlagID = overrideFlagID;
			}
			else if (order.FlagID == 6 && overrideFlagID == 0)
			{
				order.FlagID = 0;
			}
			order.Qty = item.InventoryCount;
			order.DiscountDesc = item.Barcode;
			order.IsDiscount = isDiscount;
			if (order.ItemPrice > 0m && order.ItemPrice > order.ItemSellPrice && order.Qty > 0m && !string.IsNullOrEmpty(order.DiscountDesc))
			{
				order.Discount = Math.Round((order.ItemPrice - order.ItemSellPrice) * order.Qty, 4, MidpointRounding.AwayFromZero);
			}
			else
			{
				order.Discount = 0m;
			}
			string discountReasonItem = item.Notes;
			decimal discountOnSaleItem = default(decimal);
			if (CS_0024_003C_003E8__locals2.orig_item.OnSale && order.Discount > 0m)
			{
				Promotion promotion = gClass.Promotions.Where((Promotion a) => a.GetDiscountUOM == "@" && a.String_0 == CS_0024_003C_003E8__locals2.orig_item.ItemID.ToString() && a.GetQtyString == "IT" && a.IsDeleted == false).FirstOrDefault();
				if (promotion != null && method_3(promotion, DateTime.Now))
				{
					decimal num10 = Convert.ToDecimal(100);
					decimal num11 = ((CS_0024_003C_003E8__locals2.orig_item.ItemPrice > 0m) ? Math.Round(num10 - promotion.GetDiscountAmount.Value / CS_0024_003C_003E8__locals2.orig_item.ItemPrice * num10) : Convert.ToDecimal(0));
					discountReasonItem = "Sale: " + num11 + "% Off";
					discountOnSaleItem = promotion.GetDiscountAmount.Value;
				}
			}
			order.DiscountOnSaleItem = discountOnSaleItem;
			order.DiscountReasonItem = discountReasonItem;
			if (order.Discount < 0m)
			{
				order.Discount = 0m;
			}
			order.SubTotal = Math.Round(order.ItemSellPrice * item.InventoryCount, 2, MidpointRounding.AwayFromZero);
			ItemTaxDetails itemTaxDetailsWithRounding = TaxMethods.GetItemTaxDetailsWithRounding(itemList, item, rounding);
			order.TaxTotal = itemTaxDetailsWithRounding.TaxValue;
			order.TaxDesc = itemTaxDetailsWithRounding.TaxDesc;
			rounding = itemTaxDetailsWithRounding.Rounding;
			order.Total = order.SubTotal + order.TaxTotal;
			num += order.Total;
			order.PaymentMethods = paymentMethod.Replace(',', '.').Replace("SPLIT SAVED ORDER", "SAVED ORDER");
			order.Void = !item.Active;
			if (order.Void)
			{
				order.VoidReason = item.ItemColor;
			}
			order.Paid = isPaid;
			order.OrderType = orderType;
			order.SeatNum = seatNum.ToString();
			if (order.FlagID == 5 || flag4)
			{
				order.FlagID = 0;
				if (order.Void)
				{
					order.PrintedInKitchen = true;
					order.Notified = true;
				}
			}
			order.ItemName = item.ItemName;
			if (!order.ItemName.Contains("GIFT CARD"))
			{
				order.Instructions = item.Description.Replace("===", "");
			}
			if (text2 != null && item.ItemClassification == "OptionItem" && (CS_0024_003C_003E8__locals2.orig_item.ItemName.ToUpper() == "SMALL" || CS_0024_003C_003E8__locals2.orig_item.ItemName.ToUpper() == "MEDIUM" || CS_0024_003C_003E8__locals2.orig_item.ItemName.ToUpper() == "LARGE"))
			{
				order.StationID = text2;
				text2 = null;
			}
			else
			{
				order.StationID = CS_0024_003C_003E8__locals2.orig_item.StationID;
				text2 = ((!(item.ItemClassification == "MainItem")) ? null : CS_0024_003C_003E8__locals2.orig_item.StationID);
			}
			if (isPaid)
			{
				order.Synced = false;
				order.DatePaid = DateTime.Now.AddMilliseconds(num2 * 100);
			}
			else if (!isPaid && paymentMethod.Contains("[") && paymentMethod.Split('|').Length == 2)
			{
				order.Synced = false;
				order.DatePaid = DateTime.Now.AddMilliseconds(num2 * 100);
			}
			order.CustomerInfo = customerInfo;
			order.CustomerInfoPhone = CustomerInfoPhone;
			if (customerID > 0)
			{
				order.CustomerID = customerID;
			}
			if (item.DisableSoldOutItems && !string.IsNullOrEmpty(order.StationMade) && order.ItemID > 0)
			{
				InventoryMethods inventoryMethods = new InventoryMethods();
				inventoryMethods.AddItemInventory(order, "Inventory count revert back.");
				inventoryMethods.UpdateExpiryItem(order.InventoryBatchId, order.Qty, toSubtract: false);
			}
			order.CustomerInfoName = customerInfoName;
			order.TaxChangeReason = taxChangeReason;
			num5 = order.TipAmount;
			num2++;
		}
		if (list.Count > 0)
		{
			manager.DataContext.Orders.InsertAllOnSubmit(list);
		}
		SQLLogMethods.SubmitChangesWithCatch(manager.DataContext);
		if (transactionFees != null && manager.DataContext.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.ItemName == "Transaction Fee").FirstOrDefault() == null)
		{
			foreach (decimal transactionFee in transactionFees)
			{
				if (!(transactionFee == 0m))
				{
					Order entity = new Order
					{
						OrderId = Guid.NewGuid(),
						OrderType = orderType,
						ItemID = -100,
						ItemName = "Transaction Fee",
						GroupName = "Transaction Fee",
						DatePaid = DateTime.Now,
						DateFilled = DateTime.Now,
						DateCleared = DateTime.Now,
						DateCreated = DateTime.Now,
						Customer = customer,
						CustomerInfo = customerInfo,
						CustomerInfoName = customerInfoName,
						CustomerInfoPhone = CustomerInfoPhone,
						PaymentMethods = paymentMethod.Replace(',', '.'),
						ItemCost = transactionFee,
						Notified = true,
						Qty = 1m,
						UserCreated = ((EmployeeCreated == 0) ? Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()) : EmployeeCreated),
						UserCashout = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()),
						StationID = "",
						TerminalID = terminalId,
						OrderNumber = CS_0024_003C_003E8__locals0.orderNumber,
						ItemPrice = transactionFee,
						ItemSellPrice = transactionFee,
						TaxTotal = 0m,
						SubTotal = transactionFee,
						Total = transactionFee,
						OrderTicketNumber = text,
						SeatNum = "1",
						ComboID = 0,
						Paid = true,
						GuestCount = guestCount,
						Synced = false,
						ItemCourse = ItemCourses.Uncategorized,
						CustomerNotified = customerNotified,
						ItemIdentifier = "MainItem",
						ItemOptionId = 0,
						DiscountDesc = ""
					};
					manager.DataContext.Orders.InsertOnSubmit(entity);
					method_2(manager.DataContext);
				}
			}
		}
		if (SettingsHelper.GetSettingValueByKey("coin_system") == "ON" && manager.DataContext.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.ItemName == "Cash Rounding Difference").FirstOrDefault() == null && paymentMethod.Contains("CASH="))
		{
			List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(paymentMethod);
			decimal num12 = paymentTypes.Where((ProcessorPaymentType a) => a.PaymentTypeName == "CASH").Sum((ProcessorPaymentType a) => a.Amount);
			if (num12 >= num - 0.05m)
			{
				decimal num13 = OrderMethods.GetCoinSystemRoundedValue(num12) - num12;
				bool flag5 = false;
				if (TenderChange > 0m && num12 != num && num13 == 0m)
				{
					num12 = num + num5;
					num13 = OrderMethods.GetCoinSystemRoundedValue(num12) - num12;
					flag5 = true;
				}
				if (num13 != 0m)
				{
					if (!flag5)
					{
						paymentTypes.Where((ProcessorPaymentType a) => a.PaymentTypeName == "CASH").Last().Amount += num13;
						paymentMethod = "";
						foreach (ProcessorPaymentType item2 in paymentTypes)
						{
							paymentMethod = paymentMethod + item2.PaymentTypeName + "=" + item2.Amount.ToString("0.00") + "|";
						}
					}
					num2++;
					DateTime value = DateTime.Now.AddMilliseconds(num2 * 100);
					Order entity2 = new Order
					{
						OrderId = Guid.NewGuid(),
						OrderType = orderType,
						ItemID = -100,
						ItemName = "Cash Rounding Difference",
						GroupName = "Cash Rounding Difference",
						DatePaid = value,
						OrderTicketNumber = text,
						DateFilled = value,
						DateCleared = value,
						DateCreated = value,
						CustomerID = customerID,
						Customer = customer,
						CustomerInfo = customerInfo,
						CustomerInfoName = customerInfoName,
						CustomerInfoPhone = CustomerInfoPhone,
						PaymentMethods = paymentMethod.Replace(',', '.'),
						ItemCost = num13,
						Notified = true,
						Qty = 1m,
						UserCreated = ((EmployeeCreated == 0) ? Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()) : EmployeeCreated),
						UserCashout = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()),
						StationID = "",
						TerminalID = terminalId,
						OrderNumber = CS_0024_003C_003E8__locals0.orderNumber,
						ItemPrice = num13,
						ItemSellPrice = num13,
						TaxTotal = 0m,
						SubTotal = num13,
						Total = num13,
						SeatNum = "1",
						ComboID = 0,
						Paid = true,
						GuestCount = guestCount,
						Synced = false,
						ItemCourse = ItemCourses.Uncategorized,
						ItemIdentifier = "MainItem",
						CustomerNotified = customerNotified,
						ItemOptionId = 0,
						DiscountDesc = ""
					};
					manager.DataContext.Orders.InsertOnSubmit(entity2);
					method_2(manager.DataContext);
					foreach (Order item3 in manager.DataContext.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.Void == false).ToList())
					{
						item3.PaymentMethods = paymentMethod;
					}
					method_2(manager.DataContext);
				}
			}
		}
		if (!GratuityRemoved)
		{
			bool flag6 = false;
			flag6 = ((SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON") ? true : false);
			string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(customer.Replace("Table ", ""));
			if (flag6 && currentTableGuestCapacity >= Convert.ToInt32(settingValueByKey2) && orderType == OrderTypes.DineIn && (paymentMethod == "SAVED ORDER" || paymentMethod == "SPLIT SAVED ORDER"))
			{
				OrderMethods.ComputeAutoGratuity(CS_0024_003C_003E8__locals0.orderNumber, "fr-CA");
			}
		}
	}

	public void RecheckGuestCountSplittedBill(string customer)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.customer = customer;
		GClass6 gClass = new GClass6();
		List<Order> source = gClass.Orders.Where((Order o) => o.Customer == CS_0024_003C_003E8__locals0.customer && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
		List<string> list = source.Select((Order x) => x.OrderNumber).Distinct().ToList();
		if (list.Count <= 1)
		{
			return;
		}
		short currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(CS_0024_003C_003E8__locals0.customer.Replace("Table ", ""));
		int num = 0;
		int num2 = currentTableGuestCapacity / list.Count;
		int num3 = currentTableGuestCapacity % list.Count;
		using List<string>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
			CS_0024_003C_003E8__locals1.oNum = enumerator.Current;
			_003C_003Ec__DisplayClass19_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass19_2();
			CS_0024_003C_003E8__locals2.splittedGuestCount = ((num < list.Count - num3) ? num2 : (num2 + 1));
			source.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals1.oNum).ToList().ForEach(delegate(Order a)
			{
				a.GuestCount = CS_0024_003C_003E8__locals2.splittedGuestCount;
			});
			Helper.SubmitChangesWithCatch(gClass);
			num++;
		}
	}

	public static decimal GetComboDiscount(int ComboItemId)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.ComboItemId = ComboItemId;
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		GClass6 gClass = new GClass6();
		IQueryable<ItemsInItem> queryable = gClass.ItemsInItems.Where((ItemsInItem c) => c.ParentItemID == (int?)CS_0024_003C_003E8__locals0.ComboItemId);
		if (queryable.FirstOrDefault() != null)
		{
			Item item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.ComboItemId).FirstOrDefault();
			using (IEnumerator<ItemsInItem> enumerator = queryable.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass20_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass20_1();
					CS_0024_003C_003E8__locals1.childItem = enumerator.Current;
					Item item2 = gClass.Items.Where((Item i) => (int?)i.ItemID == CS_0024_003C_003E8__locals1.childItem.ItemID).FirstOrDefault();
					num2 += item2.ItemPrice * CS_0024_003C_003E8__locals1.childItem.Quantity.Value;
				}
			}
			return num + (num2 - item.ItemPrice);
		}
		return num;
	}

	public void insertItem(string barcode, string name, decimal itemCost, decimal itemPrice, decimal itemSalePrice, bool onsale, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList, int itemTypeID, int taxruleID, string string_0, short? sortOrder, string color, bool active, decimal inventoryQTY, bool disableIfSoldOut, short uom_id, bool trackInventory, string itemClassificationToAdd, string itemDescription, string itemNotes, string itemCourse, int maxFreeOptions, int minFreeOptions, bool TrackExpiry, bool ApplySaleComboOption, bool AutoResetQty, decimal ResetQty, bool RedemptionLoyalty, bool UseSmartBarcode, bool AutoPromptOption, decimal BatchStockQty, bool TaxesIncluded, decimal ReOrderLimit, decimal ReOrderQty)
	{
		Item item = new Item();
		item.Barcode = barcode;
		item.ItemName = name;
		item.ItemCost = itemCost;
		item.ItemPrice = itemPrice;
		item.ItemSalePrice = itemSalePrice;
		item.OnSale = onsale;
		item.StartDateOnSale = startDateSale;
		item.EndDateOnSale = endDateSale;
		item.StartTimeOnSale = StartTimeRangeSale;
		item.EndTimeOnSale = EndTimeRangeSale;
		item.DaysSaleList = daySaleList;
		item.ItemTypeID = itemTypeID;
		item.TaxRuleID = taxruleID;
		item.StationID = string_0;
		if (sortOrder.HasValue)
		{
			item.SortOrder = sortOrder.Value;
		}
		item.ItemColor = color;
		item.Active = active;
		item.UOMID = uom_id;
		item.TrackInventory = trackInventory;
		item.DisableSoldOutItems = disableIfSoldOut;
		item.ItemClassification = itemClassificationToAdd;
		item.Synced = false;
		item.Description = itemDescription;
		item.Notes = itemNotes;
		item.ItemCourse = (string.IsNullOrEmpty(itemCourse) ? ItemCourses.Uncategorized : itemCourse);
		item.MaxFreeOptions = maxFreeOptions;
		item.MinFreeOptions = minFreeOptions;
		item.TrackExpiryDate = TrackExpiry;
		item.ApplySaleComboOption = ApplySaleComboOption;
		item.AutoResetQty = AutoResetQty;
		item.ResetQty = ResetQty;
		item.LoyaltyRedemption = RedemptionLoyalty;
		item.UseSmartBarcode = UseSmartBarcode;
		item.AutoPromptOptions = AutoPromptOption;
		item.BatchStockQty = BatchStockQty;
		item.TaxesIncluded = TaxesIncluded;
		item.ReOrderLimit = ReOrderLimit;
		item.ReorderQty = ReOrderQty;
		if (trackInventory)
		{
			item.InventoryCount = inventoryQTY;
			gclass6_0.Items.InsertOnSubmit(item);
			Helper.SubmitChangesWithCatch(gclass6_0);
			new InventoryMethods(gclass6_0).LogInventoryChange(item.ItemID, 0m, inventoryQTY, inventoryQTY, string.Empty, "New Item", 0, itemClassificationToAdd);
		}
		else
		{
			item.InventoryCount = 0m;
			gclass6_0.Items.InsertOnSubmit(item);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public void updateItem(int itemID, string barcode, string name, decimal itemCost, decimal itemPrice, decimal itemSalePrice, bool onsale, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList, int itemTypeID, int taxruleID, string string_0, short? sortOrder, string color, bool active, decimal inventoryQTY, bool disableIfSoldOut, short uom_id, bool trackInventory, string itemClassification, string itemDescription, string itemNote, string itemCourse, int maxFreeOptions, int minFreeOptions, bool TrackExpiry, bool ApplySaleComboOption, int supplierId, bool AutoResetQty, decimal ResetQty, bool RedemptionLoyalty, bool UseSmartBarcode, bool AutoPromptOption, decimal BatchStockQty, bool TaxesIncluded, decimal ReOrderLimit, decimal ReOrderQty, string inventoryUpdateReason = "Update Item")
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.itemTypeID = itemTypeID;
		CS_0024_003C_003E8__locals0.taxruleID = taxruleID;
		CS_0024_003C_003E8__locals0.uom_id = uom_id;
		Item oneItem = getOneItem(itemID);
		if (oneItem != null)
		{
			AddItemChangelog(oneItem, barcode, name, itemCost, itemPrice, itemSalePrice, onsale, startDateSale, endDateSale, StartTimeRangeSale, EndTimeRangeSale, daySaleList, CS_0024_003C_003E8__locals0.itemTypeID, CS_0024_003C_003E8__locals0.taxruleID, string_0, sortOrder, color, active, inventoryQTY, disableIfSoldOut, CS_0024_003C_003E8__locals0.uom_id, trackInventory, itemClassification, minFreeOptions, maxFreeOptions, AutoResetQty, itemNote);
			decimal inventoryCount = oneItem.InventoryCount;
			decimal qtyChange = inventoryQTY - oneItem.InventoryCount;
			oneItem.Barcode = barcode;
			oneItem.ItemName = name;
			oneItem.ItemCost = itemCost;
			oneItem.ItemPrice = itemPrice;
			oneItem.ItemSalePrice = itemSalePrice;
			oneItem.OnSale = onsale;
			oneItem.StartDateOnSale = startDateSale;
			oneItem.EndDateOnSale = endDateSale;
			oneItem.StartTimeOnSale = StartTimeRangeSale;
			oneItem.EndTimeOnSale = EndTimeRangeSale;
			oneItem.DaysSaleList = daySaleList;
			oneItem.ItemType = gclass6_0.ItemTypes.Where((ItemType x) => x.ItemTypeID == CS_0024_003C_003E8__locals0.itemTypeID).FirstOrDefault();
			oneItem.TaxRule = gclass6_0.TaxRules.Where((TaxRule x) => x.TaxRuleId == CS_0024_003C_003E8__locals0.taxruleID).FirstOrDefault();
			oneItem.StationID = string_0;
			if (sortOrder.HasValue)
			{
				oneItem.SortOrder = sortOrder.Value;
			}
			oneItem.ItemColor = color;
			oneItem.Active = active;
			oneItem.Synced = false;
			oneItem.UOM = gclass6_0.UOMs.Where((UOM x) => x.UOMID == CS_0024_003C_003E8__locals0.uom_id).FirstOrDefault();
			oneItem.TrackInventory = trackInventory;
			oneItem.ItemClassification = itemClassification;
			oneItem.DisableSoldOutItems = disableIfSoldOut;
			oneItem.Description = itemDescription;
			oneItem.Notes = itemNote;
			oneItem.ItemCourse = itemCourse;
			oneItem.MaxFreeOptions = maxFreeOptions;
			oneItem.MinFreeOptions = minFreeOptions;
			oneItem.TrackExpiryDate = TrackExpiry;
			oneItem.ApplySaleComboOption = ApplySaleComboOption;
			oneItem.AutoResetQty = AutoResetQty;
			oneItem.ResetQty = ResetQty;
			oneItem.LoyaltyRedemption = RedemptionLoyalty;
			oneItem.UseSmartBarcode = UseSmartBarcode;
			oneItem.AutoPromptOptions = AutoPromptOption;
			oneItem.BatchStockQty = BatchStockQty;
			oneItem.TaxesIncluded = TaxesIncluded;
			oneItem.ReOrderLimit = ReOrderLimit;
			oneItem.ReorderQty = ReOrderQty;
			oneItem.isDeleted = false;
			if (trackInventory)
			{
				new InventoryMethods(gclass6_0).LogInventoryChange(oneItem.ItemID, inventoryCount, qtyChange, inventoryQTY, string.Empty, inventoryUpdateReason, supplierId, itemClassification);
				oneItem.InventoryCount = inventoryQTY;
			}
			else
			{
				oneItem.InventoryCount = 0m;
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
			return;
		}
		throw new Exception("Item does not exist.");
	}

	public void updateSetupSaleItem(int itemID, decimal itemSalePrice, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList)
	{
		Item oneItem = getOneItem(itemID);
		if (oneItem != null)
		{
			AddSetupSaleItemChangelog(oneItem, itemSalePrice, startDateSale, endDateSale, StartTimeRangeSale, EndTimeRangeSale, daySaleList);
			oneItem.ItemSalePrice = itemSalePrice;
			oneItem.StartDateOnSale = startDateSale;
			oneItem.EndDateOnSale = endDateSale;
			oneItem.StartTimeOnSale = StartTimeRangeSale;
			oneItem.EndTimeOnSale = EndTimeRangeSale;
			oneItem.DaysSaleList = daySaleList;
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public void AddSetupSaleItemChangelog(Item item, decimal itemSalePrice, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList)
	{
		string text = "";
		decimal? itemSalePrice2 = item.ItemSalePrice;
		if (!((itemSalePrice2.GetValueOrDefault() == itemSalePrice) & itemSalePrice2.HasValue))
		{
			text = ((!(item.ItemPrice > 0m)) ? (text + " | Sale Price " + item.ItemPrice + " => " + itemSalePrice) : (text + " | Sale " + (int)((item.ItemPrice - itemSalePrice) / item.ItemPrice * 100m) + "% - Sale Price " + item.ItemPrice + " => " + itemSalePrice));
		}
		if ((startDateSale.HasValue && endDateSale.HasValue) || (!item.StartDateOnSale.HasValue && !item.EndDateOnSale.HasValue))
		{
			if (item.StartDateOnSale != startDateSale)
			{
				text = string.Concat(text, " | Start date sale ", item.StartDateOnSale, " => ", startDateSale);
			}
			if (item.EndDateOnSale != endDateSale)
			{
				text = string.Concat(text, " | End date sale ", item.EndDateOnSale, " => ", endDateSale);
			}
		}
		else
		{
			text = string.Concat(text, " | End date sale => ", item.EndDateOnSale, " | On Sale True => False");
		}
		if ((StartTimeRangeSale.HasValue && EndTimeRangeSale.HasValue) || (!item.StartTimeOnSale.HasValue && !item.EndTimeOnSale.HasValue))
		{
			if (item.StartTimeOnSale != StartTimeRangeSale)
			{
				text = string.Concat(text, " | Start time sale ", item.StartTimeOnSale, " => ", StartTimeRangeSale);
			}
			if (item.EndTimeOnSale != EndTimeRangeSale)
			{
				text = string.Concat(text, " | End time sale ", item.EndTimeOnSale, " => ", EndTimeRangeSale);
			}
		}
		else
		{
			text = string.Concat(text, " | End time sale => ", item.EndTimeOnSale, " | On Sale True => False");
		}
		if (!string.IsNullOrEmpty(text))
		{
			ItemAuditLog entity = new ItemAuditLog
			{
				ItemID = item.ItemID,
				Changelog = text,
				DateCreated = DateTime.Now,
				Synced = false
			};
			gclass6_0.ItemAuditLogs.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public void AddItemChangelog(Item item, string barcode, string name, decimal itemCost, decimal itemPrice, decimal itemSalePrice, bool onsale, DateTime? startDateSale, DateTime? endDateSale, DateTime? StartTimeRangeSale, DateTime? EndTimeRangeSale, string daySaleList, int itemTypeID, int taxruleID, string string_0, short? sortOrder, string color, bool active, decimal inventoryQTY, bool disableIfSoldOut, short uom_id, bool trackInventory, string itemClassification, int minFreeOption, int maxFreeOption, bool AutoResetQty, string ItemNote)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0.itemTypeID = itemTypeID;
		CS_0024_003C_003E8__locals0.taxruleID = taxruleID;
		CS_0024_003C_003E8__locals0.uom_id = uom_id;
		string text = "";
		if (item.Barcode != barcode)
		{
			text = text + " | Barcode " + item.Barcode + " => " + barcode;
		}
		if (item.ItemName != name)
		{
			text = text + " | Name " + item.ItemName + " => " + name;
		}
		if (item.ItemCost != itemCost)
		{
			text = text + " | Cost " + item.ItemCost + " => " + itemCost;
		}
		if (item.ItemPrice != itemPrice)
		{
			text = text + " | Price " + item.ItemPrice + " => " + itemPrice;
		}
		decimal? itemSalePrice2 = item.ItemSalePrice;
		if (!((itemSalePrice2.GetValueOrDefault() == itemSalePrice) & itemSalePrice2.HasValue))
		{
			text = text + " | Sale Price " + item.ItemSalePrice + " => " + itemSalePrice;
		}
		if (item.OnSale != onsale)
		{
			text = text + " | On Sale " + item.OnSale + " => " + onsale;
		}
		if (item.StartDateOnSale != startDateSale)
		{
			text = string.Concat(text, " | Start date sale ", item.StartDateOnSale, " => ", startDateSale);
		}
		if (item.EndDateOnSale != endDateSale)
		{
			text = string.Concat(text, " | End date sale ", item.EndDateOnSale, " => ", endDateSale);
		}
		if (item.StartTimeOnSale != StartTimeRangeSale)
		{
			text = string.Concat(text, " | Start time sale ", item.StartTimeOnSale, " => ", StartTimeRangeSale);
		}
		if (item.EndTimeOnSale != EndTimeRangeSale)
		{
			text = string.Concat(text, " | End time sale ", item.EndTimeOnSale, " => ", EndTimeRangeSale);
		}
		if (item.ItemTypeID != CS_0024_003C_003E8__locals0.itemTypeID)
		{
			text = text + " | Item Type " + item.ItemType.ItemTypeName + " => " + gclass6_0.ItemTypes.Where((ItemType i) => i.ItemTypeID == CS_0024_003C_003E8__locals0.itemTypeID).FirstOrDefault().ItemTypeName;
		}
		if (item.TaxRuleID != CS_0024_003C_003E8__locals0.taxruleID)
		{
			text = text + " | Tax Rule " + item.TaxRule.RuleName + " => " + gclass6_0.TaxRules.Where((TaxRule t) => t.TaxRuleId == CS_0024_003C_003E8__locals0.taxruleID).FirstOrDefault().RuleName;
		}
		if (item.StationID != string_0)
		{
			string text2 = ((!string.IsNullOrEmpty(item.StationID)) ? StationMethods.GetStationNamesFromStationIds(item.StationID) : "No Station");
			string text3 = ((!string.IsNullOrEmpty(string_0)) ? StationMethods.GetStationNamesFromStationIds(string_0) : "No Station");
			text = text + " | Station Changed " + text2 + " => " + text3;
		}
		if (item.ItemColor != color)
		{
			text = text + " | Color " + item.ItemColor + " => " + color;
		}
		if (item.Active != active)
		{
			text = text + " | Active " + item.Active + " => " + active;
		}
		if (item.DisableSoldOutItems != disableIfSoldOut)
		{
			text = text + " | Disable if sold out " + item.DisableSoldOutItems + " => " + disableIfSoldOut;
		}
		if (item.UOMID != CS_0024_003C_003E8__locals0.uom_id)
		{
			text = text + " | UOM " + item.UOM.Name + " => " + gclass6_0.UOMs.Where((UOM i) => i.UOMID == CS_0024_003C_003E8__locals0.uom_id).FirstOrDefault().Name;
		}
		if (item.TrackInventory != trackInventory)
		{
			text = text + " | Track Inventory " + item.TrackInventory + " => " + trackInventory;
		}
		if (item.MaxFreeOptions != maxFreeOption)
		{
			text = text + " | Max Free Option " + item.MaxFreeOptions + " => " + maxFreeOption;
		}
		if (item.MinFreeOptions != minFreeOption)
		{
			text = text + " | Min Free Option " + item.MinFreeOptions + " => " + minFreeOption;
		}
		if (item.AutoResetQty != AutoResetQty)
		{
			text = text + " | Auto Reset Qty " + item.AutoResetQty + " => " + AutoResetQty;
		}
		if (item.Notes != ItemNote)
		{
			text = text + " | Notes " + item.Notes + " => " + ItemNote;
		}
		if (!string.IsNullOrEmpty(text))
		{
			ItemAuditLog entity = new ItemAuditLog
			{
				ItemID = item.ItemID,
				Changelog = text,
				DateCreated = DateTime.Now,
				Synced = false
			};
			gclass6_0.ItemAuditLogs.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public Group getGroupFromID(short groupID)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.groupID = groupID;
		return gclass6_0.Groups.Where((Group g) => g.GroupID == CS_0024_003C_003E8__locals0.groupID).First();
	}

	public void updateGroup(short groupID, string groupName, string groupColor, bool highTraffic, bool isActive, short ParentGroupID, string groupClassification, short SortOrder, bool OEShow, bool PatronShow)
	{
		Group groupFromID = getGroupFromID(groupID);
		groupFromID.GroupName = groupName;
		groupFromID.GroupColor = groupColor;
		groupFromID.HighTraffic = highTraffic;
		groupFromID.Active = isActive;
		groupFromID.ParentGroupID = ParentGroupID;
		groupFromID.Synced = false;
		groupFromID.GroupClassification = groupClassification;
		groupFromID.SortOrder = SortOrder;
		groupFromID.OrderEntryShow = OEShow;
		groupFromID.ShowInPatronKiosk = PatronShow;
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public void insertGroup(string groupName, string groupColor, bool highTraffic, bool isActive, short ParentGroupID, string groupClassification, short SortOrder, bool OEShow, bool PatronShow)
	{
		Group group = new Group();
		group.GroupName = groupName;
		group.GroupColor = groupColor;
		group.HighTraffic = highTraffic;
		group.Active = isActive;
		group.ParentGroupID = ParentGroupID;
		group.Synced = false;
		group.GroupClassification = groupClassification;
		group.SortOrder = SortOrder;
		group.OrderEntryShow = OEShow;
		group.ShowInPatronKiosk = PatronShow;
		gclass6_0.Groups.InsertOnSubmit(group);
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public Item getOneItem(int itemID)
	{
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		if (CS_0024_003C_003E8__locals0.itemID == -999)
		{
			return getDeliveryItem();
		}
		return gclass6_0.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.itemID).FirstOrDefault();
	}

	public Item getDeliveryItem()
	{
		Item item = gclass6_0.Items.Where((Item a) => a.ItemName == ConstantItems.Delivery_Fee && a.Active == true && a.isDeleted == false).FirstOrDefault();
		if (item == null)
		{
			item = gclass6_0.Items.Where((Item a) => a.ItemName == ConstantItems.Delivery_Fee).FirstOrDefault();
		}
		item.ItemID = -999;
		item.ItemPrice = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("delivery_charge"));
		return item;
	}

	public Item getCustomItem()
	{
		return gclass6_0.Items.Where((Item a) => a.ItemName == ConstantItems.Custom).FirstOrDefault();
	}

	public void doAssociate(short groupID, short itemID, bool allowNew = false)
	{
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		CS_0024_003C_003E8__locals0.groupID = groupID;
		IQueryable<ItemsInGroup> source = gclass6_0.ItemsInGroups.Where((ItemsInGroup grp) => grp.ItemID == (int?)CS_0024_003C_003E8__locals0.itemID);
		if (source.Count() != 0 && !allowNew)
		{
			ItemsInGroup itemsInGroup = source.First();
			itemsInGroup.Group = gclass6_0.Groups.Where((Group x) => x.GroupID == CS_0024_003C_003E8__locals0.groupID).FirstOrDefault();
			itemsInGroup.Synced = false;
			itemsInGroup.Item.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			return;
		}
		ItemsInGroup itemsInGroup2 = new ItemsInGroup();
		itemsInGroup2.GroupID = CS_0024_003C_003E8__locals0.groupID;
		itemsInGroup2.ItemID = CS_0024_003C_003E8__locals0.itemID;
		itemsInGroup2.Color = "150,166,166";
		itemsInGroup2.Synced = false;
		Item item = gclass6_0.Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.itemID).FirstOrDefault();
		if (item != null)
		{
			item.Synced = false;
		}
		gclass6_0.ItemsInGroups.InsertOnSubmit(itemsInGroup2);
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public void insertItemInGroup(short groupID, int itemID)
	{
		ItemsInGroup itemsInGroup = new ItemsInGroup();
		itemsInGroup.ItemID = itemID;
		itemsInGroup.GroupID = groupID;
		itemsInGroup.Synced = false;
		itemsInGroup.Color = "150,166,166";
		gclass6_0.ItemsInGroups.InsertOnSubmit(itemsInGroup);
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public List<Order> getAllOrders(bool onlyPaid = false)
	{
		IQueryable<Order> source = ((!onlyPaid) ? gclass6_0.Orders.OrderByDescending((Order o) => o.OrderNumber) : (from o in gclass6_0.Orders
			where o.DatePaid.HasValue
			orderby o.OrderNumber descending
			select o));
		return source.ToList();
	}

	public List<Tax> GetTax()
	{
		IQueryable<Tax> queryable = gclass6_0.Taxes.Where((Tax t) => t.Inactive == false);
		List<Tax> list = new List<Tax>();
		foreach (Tax item in queryable)
		{
			if (!item.Inactive)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public IQueryable<GenKey> GetGenKeys()
	{
		return gclass6_0.GenKeys.Select((GenKey g) => g);
	}

	public void changeKeyGens(string KeyName, long target)
	{
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals0.KeyName = KeyName;
		gclass6_0.GenKeys.Single((GenKey x) => x.KeyName == CS_0024_003C_003E8__locals0.KeyName).LastKey = target;
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public IQueryable<Order> GetOrder(string orderNumber)
	{
		_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass38_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		return from o in gclass6_0.Orders
			where o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber
			orderby o.DateCreated
			select o;
	}

	public IQueryable<Order> GetOrder(Guid OrderID)
	{
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0.OrderID = OrderID;
		return from o in gclass6_0.Orders
			where o.OrderId == CS_0024_003C_003E8__locals0.OrderID
			orderby o.DateCreated
			select o;
	}

	public List<CompanySetup> GetFirstCompany()
	{
		IQueryable<CompanySetup> source = gclass6_0.CompanySetups.Select((CompanySetup c) => c).Take(1);
		return new List<CompanySetup> { source.First() };
	}

	public void AppointmentCancel(long appointmentID)
	{
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals0.appointmentID = appointmentID;
		List<Layout> list = gclass6_0.Layouts.Where((Layout a) => (long?)a.AppointmentID == (long?)CS_0024_003C_003E8__locals0.appointmentID).ToList();
		if (list != null)
		{
			foreach (Layout item in list)
			{
				item.AppointmentID = null;
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
		Appointment appointment = gclass6_0.Appointments.Where((Appointment a) => (long)a.AppointmentID == CS_0024_003C_003E8__locals0.appointmentID).FirstOrDefault();
		if (appointment != null)
		{
			appointment.Synced = false;
			appointment.isCancelled = true;
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public List<Station> GetAllStations()
	{
		return (from s in gclass6_0.Stations
			select (s) into a
			where a.IsDeleted == false
			orderby a.SystemDefinedID.HasValue ? a.SystemDefinedID.Value : 999, a.StationName
			select a).ToList();
	}

	public List<Appointment> getUpcomingReservations(DateTime? date = null)
	{
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals0.date = date;
		List<Appointment> list = null;
		if (CS_0024_003C_003E8__locals0.date.HasValue)
		{
			return (from r in gclass6_0.Appointments
				where r.StartDateTime.Date == ((DateTime?)CS_0024_003C_003E8__locals0.date).Value.Date && r.isCancelled == false && r.AppointmentType == AppointmentTypes.reservation
				orderby r.StartDateTime
				select r).ToList();
		}
		return (from r in gclass6_0.Appointments
			where r.StartDateTime.Date >= DateTime.Now.Date && r.isCancelled == false && r.AppointmentType == AppointmentTypes.reservation
			orderby r.StartDateTime
			select r).ToList();
	}

	public List<Appointment> getUpcomingWaitingList()
	{
		return (from r in gclass6_0.Appointments
			where r.DateCreated.Date >= DateTime.Now.Date && r.IsCleared == false && r.AppointmentType == AppointmentTypes.waiting_list
			orderby r.DateCreated
			select r).ToList();
	}

	public Appointment getReservation(long id)
	{
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass45_0();
		CS_0024_003C_003E8__locals0.id = id;
		return gclass6_0.Appointments.Where((Appointment r) => (long)r.AppointmentID == CS_0024_003C_003E8__locals0.id).FirstOrDefault();
	}

	public void reservationSave(DateTime date, int employeeID, string name, string phone, short numOfPeople, string comments, string email, string appointmentType, int? customerID, long resID = 0L)
	{
		Appointment appointment = null;
		if (resID == 0L)
		{
			appointment = new Appointment();
			gclass6_0.Appointments.InsertOnSubmit(appointment);
			appointment.DateCreated = DateTime.Now;
		}
		else
		{
			appointment = getReservation(resID);
		}
		if (appointment == null)
		{
			return;
		}
		appointment.EmployeeID = employeeID;
		Appointment appointment2 = appointment;
		DateTime startDateTime = (appointment.EndDateTime = date);
		appointment2.StartDateTime = startDateTime;
		appointment.CustomerName = name;
		appointment.CustomerCell = phone;
		appointment.NumOfPeople = numOfPeople;
		appointment.NextNotifyDateTime = date.AddHours(-2.0);
		appointment.isCancelled = false;
		appointment.Comments = comments;
		appointment.CustomerEmail = email;
		appointment.Synced = false;
		appointment.AppointmentType = appointmentType;
		appointment.IsCleared = false;
		appointment.DateUpdated = DateTime.Now;
		appointment.CustomerID = customerID;
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public void reservationSnooze(long resID)
	{
		Appointment reservation = getReservation(resID);
		if (reservation == null)
		{
			return;
		}
		reservation.NextNotifyDateTime = DateTime.Now.AddMinutes(10.0);
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public void reservationDismiss(long resID)
	{
		Appointment reservation = getReservation(resID);
		if (reservation == null)
		{
			return;
		}
		reservation.ReminderDismissed = true;
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public void reservationCancel(long resID)
	{
		Appointment reservation = getReservation(resID);
		if (reservation == null)
		{
			return;
		}
		reservation.isCancelled = true;
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	public IQueryable<Appointment> reservationReminder()
	{
		return gclass6_0.Appointments.Where((Appointment r) => r.StartDateTime <= DateTime.Now.AddHours(2.0) && r.isCancelled == false);
	}

	public List<UOM> method_1(int itemID)
	{
		return gclass6_0.UOMs.ToList();
	}

	public void SubmitChangesToDatabase()
	{
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	public void MaintenanceSave(string question, int answerType, bool update = false)
	{
		Maintenance maintenance = null;
		if (!update)
		{
			maintenance = new Maintenance();
			gclass6_0.Maintenances.InsertOnSubmit(maintenance);
		}
		else
		{
			maintenance = getMaintenance(question);
		}
		if (maintenance != null)
		{
			maintenance.Question = question;
			maintenance.AnswerType = answerType;
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public Maintenance getMaintenance(string question)
	{
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass54_0();
		CS_0024_003C_003E8__locals0.question = question;
		return gclass6_0.Maintenances.Where((Maintenance r) => r.Question.ToUpper() == CS_0024_003C_003E8__locals0.question.ToUpper()).FirstOrDefault();
	}

	public IQueryable<Maintenance> GetAllMaintenances()
	{
		return gclass6_0.Maintenances.Select((Maintenance s) => s);
	}

	public void MaintenanceRemove(string question)
	{
		_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass56_0();
		CS_0024_003C_003E8__locals0.question = question;
		Maintenance maintenance = gclass6_0.Maintenances.Where((Maintenance a) => a.Question.ToUpper() == CS_0024_003C_003E8__locals0.question.ToUpper()).FirstOrDefault();
		if (maintenance != null)
		{
			gclass6_0.Maintenances.DeleteOnSubmit(maintenance);
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	public decimal CalculateOrderDiscount(List<Item> itemList, decimal total, decimal discountPercent)
	{
		decimal num = default(decimal);
		discountPercent = ((discountPercent > 1m) ? 1m : discountPercent);
		decimal num2 = (num = itemList.Sum((Item a) => a.ItemSalePrice.Value * a.InventoryCount));
		decimal num3 = Math.Round(discountPercent * total, 2, MidpointRounding.AwayFromZero) + num2;
		short num4 = 1;
		itemList = itemList.Where((Item i) => i.ItemPrice > 0m && i.Active).ToList();
		short num5 = (short)itemList.Count();
		foreach (Item item in itemList.OrderByDescending((Item x) => x.InventoryCount))
		{
			decimal num6 = default(decimal);
			if (item.InventoryCount <= 0m)
			{
				item.InventoryCount = 1m;
			}
			if (num4 < num5)
			{
				num6 = Math.Round(item.InventoryCount * item.ItemPrice * discountPercent, 2, MidpointRounding.AwayFromZero);
				decimal itemPrice = item.ItemPrice;
				item.ItemPrice -= Math.Round(num6 / item.InventoryCount, 4, MidpointRounding.AwayFromZero);
				item.ItemPrice = ((item.ItemPrice < 0m) ? 0m : item.ItemPrice);
				num6 = (itemPrice - item.ItemPrice) * item.InventoryCount;
				num6 = Math.Round(num6, 2, MidpointRounding.AwayFromZero);
				num += num6;
				num4 = (short)(num4 + 1);
			}
			else
			{
				item.ItemPrice -= Math.Round((num3 - num) / item.InventoryCount, 4, MidpointRounding.AwayFromZero);
				item.ItemPrice = ((item.ItemPrice < 0m) ? 0m : item.ItemPrice);
				num6 = num3 - num;
				num += num6;
			}
			item.Barcode = OrderMethods.UpdateDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Order, num6);
			decimal? itemSalePrice = item.ItemSalePrice;
			if ((itemSalePrice.GetValueOrDefault() > default(decimal)) & itemSalePrice.HasValue)
			{
				if (item.ItemPrice - item.ItemSalePrice.Value >= 0m)
				{
					item.ItemPrice -= Math.Round(item.ItemSalePrice.Value, 2, MidpointRounding.AwayFromZero);
				}
				else
				{
					decimal num7 = item.ItemPrice - item.ItemSalePrice.Value;
					num += num7;
					item.ItemSalePrice = item.ItemPrice;
					item.ItemPrice = 0m;
				}
				item.Barcode = OrderMethods.UpdateDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Item, item.ItemSalePrice.Value * item.InventoryCount);
			}
		}
		return num;
	}

	private void method_2(GClass6 gclass6_1)
	{
		try
		{
			gclass6_1.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_1.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	private bool method_3(Promotion promotion_0, DateTime dateTime_0)
	{
		_003C_003Ec__DisplayClass59_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass59_0();
		CS_0024_003C_003E8__locals0.OrderDateCreated = dateTime_0;
		bool result = false;
		if (promotion_0.StartDate.HasValue)
		{
			result = ((promotion_0.StartDate.Value <= CS_0024_003C_003E8__locals0.OrderDateCreated && promotion_0.EndDate.Value.AddHours(23.0).AddMinutes(59.0) >= CS_0024_003C_003E8__locals0.OrderDateCreated) ? true : false);
		}
		if (!string.IsNullOrEmpty(promotion_0.DayTimeOfWeek))
		{
			if (promotion_0.DayTimeOfWeek.Contains(CS_0024_003C_003E8__locals0.OrderDateCreated.DayOfWeek.ToString().ToUpper()))
			{
				string[] array = (from a in promotion_0.DayTimeOfWeek.Split('|').ToList()
					where a.Contains(CS_0024_003C_003E8__locals0.OrderDateCreated.DayOfWeek.ToString().ToUpper())
					select a).FirstOrDefault().Split('-');
				_ = array[0];
				string s = array[1];
				string s2 = array[2];
				DateTime dateTime = DateTime.ParseExact(s, "H:mm", null, DateTimeStyles.None);
				DateTime dateTime2 = DateTime.ParseExact(s2, "H:mm", null, DateTimeStyles.None);
				result = ((dateTime.TimeOfDay <= CS_0024_003C_003E8__locals0.OrderDateCreated.TimeOfDay && dateTime2.TimeOfDay >= CS_0024_003C_003E8__locals0.OrderDateCreated.TimeOfDay) ? true : false);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}
}
