using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.ThirdPartyAPIs.OnlineOrdering;

public class FlytMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public OnlineOrderSyncQueue orderQueue;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_1
	{
		public List<string> itemPLUs;

		public List<int> list_0;

		public _003C_003Ec__DisplayClass0_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public FlytOrderModel.Item dataOrder;

		public Item dataItem;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CAddFlytOrderItem_003Eb__1(Item x)
		{
			return x.Barcode == dataOrder.plu;
		}

		internal bool _003CAddFlytOrderItem_003Eb__2(Item a)
		{
			return a.ItemName.ToUpper() == dataOrder.name.ToUpper();
		}

		internal bool _003CAddFlytOrderItem_003Eb__4(ItemsInGroup x)
		{
			return x.ItemID == dataItem.ItemID;
		}
	}

	public static List<OrderHeader> ProcessFlytOrders()
	{
		List<OrderHeader> list = new List<OrderHeader>();
		GClass6 gClass = new GClass6();
		GClass6 gClass2 = new GClass6();
		List<OnlineOrderSyncQueue> list2 = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => !MemoryLoadedData.LastThirdPartyIds.Contains(a.Id) && a.Provider == OnlineOrderProviders.Flyt && a.DateProcessed.HasValue == false && a.DateCreated > DateTime.Now.AddHours(-12.0)).ToList();
		MemoryLoadedData.LastThirdPartyIds.AddRange(list2.Select((OnlineOrderSyncQueue a) => a.Id).ToList());
		MemoryLoadedData.LastThirdPartyIds = MemoryLoadedData.LastThirdPartyIds.OrderByDescending((int a) => a).Take(10).ToList();
		using List<OnlineOrderSyncQueue>.Enumerator enumerator = list2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals1.orderQueue = enumerator.Current;
			FlytOrderModel.FlytOrder flytOrder = JsonConvert.DeserializeObject<FlytOrderModel.FlytOrder>(CS_0024_003C_003E8__locals1.orderQueue.RawData);
			SyncMethods.WriteToSyncLog("Order START Process Flyt: " + flytOrder.third_party_order_reference, "OnlineOrderSync_");
			string text = (flytOrder.channel.name.ToUpper().Contains("SKIP") ? "SKIP" : "UBER");
			string text2 = text + flytOrder.third_party_order_reference;
			try
			{
				if (gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => a.DateProcessed.HasValue && a.DateProcessed.Value > DateTime.Now.AddMinutes(-10.0) && a.Comment == CS_0024_003C_003E8__locals1.orderQueue.Comment).Any())
				{
					continue;
				}
				_003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_1();
				string third_party_order_reference = flytOrder.third_party_order_reference;
				string customerName = "SKIP#:" + third_party_order_reference.Substring(third_party_order_reference.Length - 4);
				string customerPhone = null;
				string customerInfo = null;
				string customerEmail = null;
				string orderType = ((flytOrder.type == "collection-by-customer" || flytOrder.type == "delivery-by-delivery-partner") ? "Pick-Up-Online" : "Delivery-Online");
				_ = flytOrder.kitchen_notes;
				bool bool_ = false;
				int int_ = 0;
				decimal num = (decimal)flytOrder.payment.final.tax / 100m;
				decimal num2 = (decimal)flytOrder.payment.final.inc_tax / 100m;
				decimal num3 = num2 - num;
				DateTime dateCreated = UnixTimeStampToDateTime(Convert.ToDouble(flytOrder.created_at));
				CS_0024_003C_003E8__locals0.itemPLUs = (from x in flytOrder.items
					where x.plu != string.Empty && x.plu != null
					select x.plu).ToList();
				foreach (FlytOrderModel.Item item in flytOrder.items)
				{
					CS_0024_003C_003E8__locals0.itemPLUs.AddRange((from x in item.children
						where x.plu != string.Empty && x.plu != null
						select x.plu).ToList());
				}
				List<Item> list3 = gClass2.Items.Where((Item x) => CS_0024_003C_003E8__locals0.itemPLUs.Contains(x.Barcode) || x.ItemName == "CUSTOM").ToList();
				CS_0024_003C_003E8__locals0.list_0 = list3.Select((Item y) => y.ItemID).ToList();
				List<ItemsInGroup> list_ = gClass2.ItemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals0.list_0.Contains(x.ItemID.Value)).ToList();
				List<Order> list4 = new List<Order>();
				short num4 = 1;
				decimal num5 = default(decimal);
				foreach (FlytOrderModel.Item item2 in flytOrder.items)
				{
					Guid guid_ = Guid.NewGuid();
					decimal num6 = Math.Round((decimal)item2.price / 100m / num3 * num, 2);
					num5 += num6;
					FlytAddItemOrderData flytAddItemOrderData = new FlytAddItemOrderData
					{
						ChannelName = flytOrder.channel.name,
						PaymentMethod = flytOrder.payment_method,
						OrderNumber = third_party_order_reference,
						OrderType = orderType,
						CustomerEmail = customerEmail,
						CustomerInfo = customerInfo,
						CustomerName = customerName,
						CustomerPhone = customerPhone,
						ItemTaxAmount = num6,
						TotalAmount = num2,
						DateCreated = dateCreated,
						ComboId = num4,
						TenderType = flytOrder.tender_type,
						Instructions = flytOrder.kitchen_notes,
						FulfillmentAt = UnixTimeStampToDateTime(Convert.ToDouble(flytOrder.collect_at))
					};
					Order order = smethod_0(guid_, flytAddItemOrderData, item2, list3, list_, ref bool_, ref int_);
					if (order != null)
					{
						list4.Add(order);
						if (item2.children != null && item2.children.Count > 0)
						{
							foreach (FlytOrderModel.Item child in item2.children)
							{
								Guid guid_2 = Guid.NewGuid();
								child.description = "OPTION ITEM";
								num6 = (flytAddItemOrderData.ItemTaxAmount = Math.Round((decimal)child.price / 100m / num3 * num, 2));
								num5 += num6;
								Order order2 = smethod_0(guid_2, flytAddItemOrderData, child, list3, list_, ref bool_, ref int_);
								if (order2 != null)
								{
									list4.Add(order2);
								}
							}
						}
					}
					num4 = (short)(num4 + 1);
				}
				if (num5 != num)
				{
					decimal num8 = num - num5;
					Order order3 = (from a in list4
						where a.ItemPrice > 0m && a.TaxTotal > 0m
						orderby a.TaxTotal
						select a).FirstOrDefault();
					if (order3 != null)
					{
						order3.TaxDesc = "TAX:" + (order3.TaxTotal += num8).ToString("0.00") + "|";
						order3.Total += num8;
					}
				}
				gClass.Orders.InsertAllOnSubmit(list4);
				CS_0024_003C_003E8__locals1.orderQueue.DateProcessed = DateTime.Now;
				Helper.SubmitChangesWithCatch(gClass);
				SyncMethods.WriteToSyncLog("Order END Process Flyt: " + flytOrder.third_party_order_reference, "OnlineOrderSync_");
				if (list4.Count > 0)
				{
					list.Add(new OrderHeader
					{
						OrderNumber = list4.FirstOrDefault().OrderNumber,
						OrderType = list4.FirstOrDefault().OrderType,
						CustomerInfoName = list4.FirstOrDefault().CustomerInfoName,
						Customer = list4.FirstOrDefault().Customer,
						Source = list4.FirstOrDefault().SubSource,
						ItemCount = (short)list4.Count
					});
				}
			}
			catch (Exception ex)
			{
				MemoryLoadedData.OnlineOrderErrorMessage = "Unable to process: " + text + " | order: " + text2 + ", due to " + ex.Message;
				SyncMethods.WriteToSyncLog("Flyt Error: " + ex.Message + " " + ex.StackTrace, "OnlineOrderSync_");
			}
		}
		return list;
	}

	private static Order smethod_0(Guid guid_0, FlytAddItemOrderData flytAddItemOrderData_0, FlytOrderModel.Item item_0, List<Item> list_0, List<ItemsInGroup> list_1, ref bool bool_0, ref int int_0)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.dataOrder = item_0;
		int currentTerminalID = HelperMethods.GetCurrentTerminalID();
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.dataOrder.plu))
		{
			CS_0024_003C_003E8__locals0.dataItem = list_0.Where((Item a) => a.ItemName.ToUpper() == "CUSTOM").FirstOrDefault();
			CS_0024_003C_003E8__locals0.dataItem.ItemName = CS_0024_003C_003E8__locals0.dataOrder.name;
		}
		else
		{
			CS_0024_003C_003E8__locals0.dataItem = list_0.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals0.dataOrder.plu).FirstOrDefault();
			if (CS_0024_003C_003E8__locals0.dataItem == null)
			{
				CS_0024_003C_003E8__locals0.dataItem = list_0.Where((Item a) => a.ItemName.ToUpper() == CS_0024_003C_003E8__locals0.dataOrder.name.ToUpper()).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.dataItem == null)
				{
					CS_0024_003C_003E8__locals0.dataItem = list_0.Where((Item a) => a.ItemName.ToUpper() == "CUSTOM").FirstOrDefault();
					CS_0024_003C_003E8__locals0.dataItem.ItemName = CS_0024_003C_003E8__locals0.dataOrder.name;
				}
			}
		}
		if (CS_0024_003C_003E8__locals0.dataItem != null)
		{
			string groupName = "";
			ItemsInGroup itemsInGroup = list_1.Where((ItemsInGroup x) => x.ItemID == CS_0024_003C_003E8__locals0.dataItem.ItemID).FirstOrDefault();
			if (itemsInGroup != null)
			{
				Group group = itemsInGroup.Group;
				if (group != null)
				{
					groupName = group.GroupName;
				}
			}
			Order order = new Order();
			order.OrderId = guid_0;
			string text = "";
			if (flytAddItemOrderData_0.ChannelName.ToUpper().Contains("SKIP"))
			{
				text = "SKIP";
				order.Source = OnlineOrderSource.Skip;
			}
			else
			{
				text = "UBER";
				order.Source = OnlineOrderSource.UBER;
			}
			order.OrderNumber = text + flytAddItemOrderData_0.OrderNumber;
			order.OrderType = flytAddItemOrderData_0.OrderType;
			order.DiscountDesc = string.Empty;
			order.Paid = (flytAddItemOrderData_0.PaymentMethod.Equals("CARD") ? true : false);
			order.Void = false;
			order.StationID = CS_0024_003C_003E8__locals0.dataItem.StationID;
			order.ItemID = CS_0024_003C_003E8__locals0.dataItem.ItemID;
			order.GroupName = groupName;
			order.ItemName = ((CS_0024_003C_003E8__locals0.dataOrder.description == "OPTION ITEM") ? ("OPT: " + CS_0024_003C_003E8__locals0.dataItem.ItemName) : CS_0024_003C_003E8__locals0.dataItem.ItemName);
			order.ItemPrice = (decimal)CS_0024_003C_003E8__locals0.dataOrder.price / 100m;
			order.Discount = 0m;
			order.SubTotal = (decimal)CS_0024_003C_003E8__locals0.dataOrder.price / 100m;
			order.TaxTotal = flytAddItemOrderData_0.ItemTaxAmount;
			order.TaxDesc = ((CS_0024_003C_003E8__locals0.dataOrder.price == 0) ? "TAX:0.00|" : ("TAX:" + flytAddItemOrderData_0.ItemTaxAmount.ToString("0.00") + "|"));
			order.Total = (decimal)CS_0024_003C_003E8__locals0.dataOrder.price / 100m + order.TaxTotal;
			order.TipAmount = 0m;
			order.PaymentMethods = (flytAddItemOrderData_0.PaymentMethod.Equals("CARD") ? (text + "=" + flytAddItemOrderData_0.TotalAmount.ToString("0.00") + "|") : "SAVED ORDER");
			order.DateCreated = flytAddItemOrderData_0.DateCreated.AddMilliseconds(int_0 * 100);
			order.DateFilled = null;
			order.DatePaid = (flytAddItemOrderData_0.PaymentMethod.Equals("CARD") ? new DateTime?(flytAddItemOrderData_0.DateCreated.AddMilliseconds(int_0 * 100)) : null);
			order.UserCreated = null;
			order.UserCancelled = null;
			order.UserCashout = null;
			order.UserServed = null;
			order.DateRefunded = null;
			order.ItemSellPrice = (decimal)CS_0024_003C_003E8__locals0.dataOrder.price / 100m;
			order.ComboID = flytAddItemOrderData_0.ComboId;
			order.Qty = 1m;
			order.ItemCost = CS_0024_003C_003E8__locals0.dataItem.ItemCost;
			order.DiscountReason = null;
			order.OrderOnHoldTime = 0;
			order.DateTimeSeated = null;
			order.SeatNum = "1";
			order.ItemCourse = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.dataItem.ItemCourse)) ? CS_0024_003C_003E8__locals0.dataItem.ItemCourse.ToUpper() : ItemCourses.Uncategorized.ToUpper());
			order.Synced = false;
			order.CustomerInfoName = flytAddItemOrderData_0.CustomerName;
			order.CustomerInfo = flytAddItemOrderData_0.CustomerInfo;
			order.CustomerInfoEmail = flytAddItemOrderData_0.CustomerEmail;
			order.CustomerInfoPhone = flytAddItemOrderData_0.CustomerPhone;
			order.ItemBarcode = CS_0024_003C_003E8__locals0.dataItem.Barcode;
			if (order.ItemName.Contains("OPT:") && order.ComboID > 0)
			{
				order.ItemIdentifier = "OptionItem";
			}
			else if ((order.ItemName.Contains("   ") || order.ItemName.Contains("---")) && !order.ItemName.Contains("OPT:") && order.ComboID > 0 && order.ItemSellPrice == 0m)
			{
				order.ItemIdentifier = "ChildItem";
			}
			else
			{
				order.ItemIdentifier = "MainItem";
			}
			order.CreatedByTerminalID = currentTerminalID;
			if (bool_0)
			{
				order.Instructions = null;
			}
			else
			{
				bool_0 = true;
				order.Instructions = flytAddItemOrderData_0.Instructions;
			}
			order.Source = OnlineOrderSource.Flyt;
			order.SubSource = OnlineOrderSource.Skip;
			order.Customer = ((!string.IsNullOrEmpty(order.SubSource)) ? (order.SubSource + "-" + order.OrderNumber.Substring(order.OrderNumber.Length - 4).ToUpper()) : (OnlineOrderProviders.Flyt.ToUpper() + "-" + order.OrderNumber.Substring(order.OrderNumber.Length - 4).ToUpper()));
			order.FulfillmentAt = flytAddItemOrderData_0.FulfillmentAt;
			order.DeliveryTime = null;
			order.FlagID = 1;
			if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
			{
				order.FlagID = 0;
			}
			int_0++;
			return order;
		}
		return null;
	}

	public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
	}

	public FlytMethods()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
