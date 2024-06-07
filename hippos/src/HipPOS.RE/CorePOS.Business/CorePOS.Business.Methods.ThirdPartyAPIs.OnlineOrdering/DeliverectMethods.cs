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

public class DeliverectMethods
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
		public DeliverectOrderData data;

		public string orderNumber;

		public _003C_003Ec__DisplayClass0_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_2
	{
		public List<string> itemPLUs;

		public List<int> list_0;

		public _003C_003Ec__DisplayClass0_2()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public DeliverectOrderItem dataOrder;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal void _003CGetDeliverectSubTotal_003Eb__0(DeliverectOrderItem a)
		{
			a.quantity = dataOrder.quantity;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public DeliverectOrderItem dataFromDeliverect;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CAddDeliverectOrderItem_003Eb__0(Item x)
		{
			return x.Barcode == dataFromDeliverect.plu;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public Item dataItem;

		public _003C_003Ec__DisplayClass3_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CAddDeliverectOrderItem_003Eb__1(ItemsInGroup x)
		{
			return x.ItemID == dataItem.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public DeliverectOrderItem dataItem;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal void _003CAddItems_003Eb__0(DeliverectOrderItem a)
		{
			a.quantity = dataItem.quantity;
		}
	}

	public static List<OrderHeader> ProcessDeliverect()
	{
		GClass6 gClass = new GClass6();
		List<OrderHeader> list = new List<OrderHeader>();
		GClass6 gClass2 = new GClass6();
		List<OnlineOrderSyncQueue> list2 = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => !MemoryLoadedData.LastThirdPartyIds.Contains(a.Id) && a.Provider == OnlineOrderProviders.Deliverect && a.DateProcessed.HasValue == false && a.DateCreated > DateTime.Now.AddHours(-12.0)).ToList();
		MemoryLoadedData.LastThirdPartyIds.AddRange(list2.Select((OnlineOrderSyncQueue a) => a.Id).ToList());
		MemoryLoadedData.LastThirdPartyIds = MemoryLoadedData.LastThirdPartyIds.OrderByDescending((int a) => a).Take(10).ToList();
		using List<OnlineOrderSyncQueue>.Enumerator enumerator = list2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals0.orderQueue = enumerator.Current;
			_003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass0_1();
			CS_0024_003C_003E8__locals1.data = JsonConvert.DeserializeObject<DeliverectOrderData>(CS_0024_003C_003E8__locals0.orderQueue.RawData);
			SyncMethods.WriteToSyncLog("Order START Process Deliverect: " + CS_0024_003C_003E8__locals1.data.channelOrderId, "OnlineOrderSync_");
			CS_0024_003C_003E8__locals1.orderNumber = CS_0024_003C_003E8__locals1.data.channelOrderDisplayId;
			try
			{
				_003C_003Ec__DisplayClass0_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass0_2();
				short short_ = 1;
				if (!gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => a.DateProcessed.HasValue && a.DateProcessed.Value > DateTime.Now.AddMinutes(-10.0) && a.Comment == CS_0024_003C_003E8__locals0.orderQueue.Comment).Any())
				{
					goto IL_0776;
				}
				if (CS_0024_003C_003E8__locals1.data.status == 100)
				{
					foreach (Order item in gClass.Orders.Where((Order o) => o.DateCreated > DateTime.Now.AddDays(-2.0) && o.OrderNumber == CS_0024_003C_003E8__locals1.data.channelOrderId).ToList())
					{
						item.Void = true;
						item.Paid = false;
						item.Synced = false;
					}
					Helper.SubmitChangesWithCatch(gClass);
					SyncMethods.WriteToSyncLog("Order Cancelled: " + CS_0024_003C_003E8__locals1.data.channelOrderId, "OnlineOrderSync_");
					CS_0024_003C_003E8__locals0.orderQueue.DateProcessed = DateTime.Now;
					Helper.SubmitChangesWithCatch(gClass);
					continue;
				}
				if (gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => a.DateProcessed.HasValue && a.RawData == CS_0024_003C_003E8__locals0.orderQueue.RawData && a.Comment == CS_0024_003C_003E8__locals0.orderQueue.Comment).Any())
				{
					CS_0024_003C_003E8__locals0.orderQueue.DateProcessed = DateTime.Now;
					Helper.SubmitChangesWithCatch(gClass);
					continue;
				}
				short_ = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.orderNumber).Max((Order a) => a.ComboID);
				short_ = (short)(short_ + 1);
				goto IL_0776;
				IL_0776:
				string orderType = OrderTypes.PickUpOnline;
				if (CS_0024_003C_003E8__locals1.data.orderType == 1)
				{
					orderType = OrderTypes.PickUpOnline;
				}
				else if (CS_0024_003C_003E8__locals1.data.orderType == 2)
				{
					orderType = OrderTypes.DeliveryOnline;
				}
				else if (CS_0024_003C_003E8__locals1.data.orderType == 3)
				{
					orderType = OrderTypes.DineInOnline;
				}
				else if (CS_0024_003C_003E8__locals1.data.orderType == 4)
				{
					orderType = OrderTypes.PickUpCurbsideOnline;
				}
				string customerName = ((CS_0024_003C_003E8__locals1.data.customer.name != null) ? CS_0024_003C_003E8__locals1.data.customer.name : "");
				string text = ((CS_0024_003C_003E8__locals1.data.customer.phoneNumber != null) ? CS_0024_003C_003E8__locals1.data.customer.phoneNumber.Replace("+", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty) : "");
				if (!string.IsNullOrEmpty(text) && text[0] == '1')
				{
					text = text.Remove(0, 1);
				}
				string text2 = ((CS_0024_003C_003E8__locals1.data.deliveryAddress.streetNumber != null) ? CS_0024_003C_003E8__locals1.data.deliveryAddress.streetNumber : "");
				string text3 = ((CS_0024_003C_003E8__locals1.data.deliveryAddress.street != null) ? CS_0024_003C_003E8__locals1.data.deliveryAddress.street : "");
				string text4 = ((CS_0024_003C_003E8__locals1.data.deliveryAddress.city != null) ? CS_0024_003C_003E8__locals1.data.deliveryAddress.city : "");
				string text5 = ((CS_0024_003C_003E8__locals1.data.deliveryAddress.postalCode != null) ? CS_0024_003C_003E8__locals1.data.deliveryAddress.postalCode : "");
				string text6 = text2 + " " + text3 + " " + text4 + " " + text5;
				text6 = text6.Trim();
				string customerEmail = ((CS_0024_003C_003E8__locals1.data.customer.email != null) ? CS_0024_003C_003E8__locals1.data.customer.email : "");
				DeliverectPaymentMethods type = (DeliverectPaymentMethods)CS_0024_003C_003E8__locals1.data.payment.type;
				decimal num = (decimal)CS_0024_003C_003E8__locals1.data.payment.amount / 100m;
				decimal num2 = (decimal)CS_0024_003C_003E8__locals1.data.discountTotal / 100m;
				decimal num3 = (decimal)CS_0024_003C_003E8__locals1.data.serviceCharge / 100m;
				decimal num4 = (decimal)CS_0024_003C_003E8__locals1.data.deliveryCost / 100m;
				TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
				DateTime dateCreated = CS_0024_003C_003E8__locals1.data._created.AddHours(utcOffset.Hours);
				DateTime pickupTime = CS_0024_003C_003E8__locals1.data.pickupTime.AddHours(utcOffset.Hours);
				bool orderIsAlreadyPaid = CS_0024_003C_003E8__locals1.data.orderIsAlreadyPaid;
				string subSource = ((DeliverectChannels)CS_0024_003C_003E8__locals1.data.channel).ToString();
				CS_0024_003C_003E8__locals2.itemPLUs = odaohfnpes(CS_0024_003C_003E8__locals1.data.items);
				List<Item> list3 = gClass2.Items.Where((Item x) => CS_0024_003C_003E8__locals2.itemPLUs.Contains(x.Barcode)).ToList();
				CS_0024_003C_003E8__locals2.list_0 = list3.Select((Item y) => y.ItemID).ToList();
				List<ItemsInGroup> list_ = gClass2.ItemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals2.list_0.Contains(x.ItemID.Value)).ToList();
				decimal num5 = smethod_0(CS_0024_003C_003E8__locals1.data.items);
				num5 += num2;
				decimal num6 = num - num5 - num3;
				decimal decimal_ = num6;
				decimal decimal_2 = Math.Abs(num2);
				List<Order> list4 = new List<Order>();
				int int_ = 0;
				DeliverectDataItem deliverectDataItem_ = new DeliverectDataItem
				{
					DeliverectOrderId = CS_0024_003C_003E8__locals1.data._id,
					OrderNumber = CS_0024_003C_003E8__locals1.data.channelOrderId,
					OrderTicket = CS_0024_003C_003E8__locals1.data.channelOrderDisplayId,
					OrderType = orderType,
					DateCreated = dateCreated,
					PaymentMethod = type,
					TotalAmount = num,
					CustomerName = customerName,
					CustomerPhone = text,
					CustomerInfo = text6,
					CustomerEmail = customerEmail,
					ComboId = short_,
					PickupTime = pickupTime,
					Instructions = CS_0024_003C_003E8__locals1.data.note,
					isPaid = orderIsAlreadyPaid,
					SubSource = subSource,
					ItemIdentifier = "MainItem"
				};
				List<Order> list5 = smethod_2(gClass, CS_0024_003C_003E8__locals0.orderQueue, list3, list_, CS_0024_003C_003E8__locals1.data, CS_0024_003C_003E8__locals1.data.items, deliverectDataItem_, num5, num6, bool_0: true, ref int_, ref short_, ref decimal_, ref decimal_2);
				if (list5 == null)
				{
					SyncMethods.WriteToSyncLog("Deliverect Order: Invalid PLU for order " + CS_0024_003C_003E8__locals1.data.channelOrderId, "OnlineOrderSync_");
					return null;
				}
				list4.AddRange(list5);
				DeliverectDataItem deliverectDataItem_2 = new DeliverectDataItem
				{
					DeliverectOrderId = CS_0024_003C_003E8__locals1.data._id,
					OrderNumber = CS_0024_003C_003E8__locals1.data.channelOrderId,
					OrderTicket = CS_0024_003C_003E8__locals1.data.channelOrderDisplayId,
					OrderType = orderType,
					DateCreated = dateCreated,
					PaymentMethod = type,
					TotalAmount = num,
					ItemTax = 0m,
					CustomerName = customerName,
					CustomerPhone = text,
					CustomerInfo = text6,
					CustomerEmail = customerEmail,
					TotalDiscount = 0m,
					ComboId = 0,
					PickupTime = pickupTime,
					Instructions = CS_0024_003C_003E8__locals1.data.note,
					isPaid = orderIsAlreadyPaid,
					SubSource = subSource,
					ItemIdentifier = "MainItem"
				};
				if (num3 > 0m)
				{
					DeliverectOrderItem deliverectOrderItem_ = new DeliverectOrderItem
					{
						price = CS_0024_003C_003E8__locals1.data.serviceCharge,
						plu = "SERVICECHARGE",
						name = "SERVICE CHARGE",
						quantity = 1
					};
					list4.Add(smethod_1(deliverectOrderItem_, deliverectDataItem_2, list3, list_, ref int_));
				}
				if (num4 > 0m)
				{
					DeliverectOrderItem deliverectOrderItem_2 = new DeliverectOrderItem
					{
						price = CS_0024_003C_003E8__locals1.data.deliveryCost,
						plu = "DELIVERYFEE",
						name = "DELIVERY FEE",
						quantity = 1
					};
					list4.Add(smethod_1(deliverectOrderItem_2, deliverectDataItem_2, list3, list_, ref int_));
				}
				if (decimal_ != 0m)
				{
					decimal num7 = decimal_;
					Order order = (from a in list4
						where a.ItemPrice > 0m && a.TaxTotal > 0m
						orderby a.TaxTotal
						select a).FirstOrDefault();
					if (order != null)
					{
						order.TaxDesc = "TAX:" + (order.TaxTotal += num7).ToString("0.00") + "|";
						order.Total += num7;
					}
				}
				gClass.Orders.InsertAllOnSubmit(list4);
				CS_0024_003C_003E8__locals0.orderQueue.DateProcessed = DateTime.Now;
				Helper.SubmitChangesWithCatch(gClass);
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
				string text7 = ((DeliverectChannels)CS_0024_003C_003E8__locals1.data.channel).ToString();
				MemoryLoadedData.OnlineOrderErrorMessage = "Unable to process: " + CS_0024_003C_003E8__locals0.orderQueue.Provider + "-" + text7 + " | order: " + CS_0024_003C_003E8__locals1.orderNumber + ", due to " + ex.Message;
				SyncMethods.WriteToSyncLog("Deliverect Error: " + ex.Message + " " + ex.StackTrace, "OnlineOrderSync_");
			}
		}
		return list;
	}

	private static List<string> odaohfnpes(List<DeliverectOrderItem> list_0)
	{
		List<string> list = new List<string>();
		foreach (DeliverectOrderItem item in list_0)
		{
			if (item.plu.Contains("OPT"))
			{
				list.Add(item.plu.Split('-')[2]);
			}
			else
			{
				list.Add(item.plu);
			}
			if (item.subItems != null && item.subItems.Count > 0)
			{
				list.AddRange(odaohfnpes(item.subItems));
			}
		}
		return list;
	}

	private static decimal smethod_0(List<DeliverectOrderItem> list_0)
	{
		decimal result = default(decimal);
		using List<DeliverectOrderItem>.Enumerator enumerator = list_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals0.dataOrder = enumerator.Current;
			decimal num = (decimal)CS_0024_003C_003E8__locals0.dataOrder.price / 100m;
			result += num * (decimal)CS_0024_003C_003E8__locals0.dataOrder.quantity;
			if (CS_0024_003C_003E8__locals0.dataOrder.subItems != null && CS_0024_003C_003E8__locals0.dataOrder.subItems.Count > 0)
			{
				CS_0024_003C_003E8__locals0.dataOrder.subItems.ForEach(delegate(DeliverectOrderItem a)
				{
					a.quantity = CS_0024_003C_003E8__locals0.dataOrder.quantity;
				});
				result += smethod_0(CS_0024_003C_003E8__locals0.dataOrder.subItems);
			}
		}
		return result;
	}

	private static Order smethod_1(DeliverectOrderItem deliverectOrderItem_0, DeliverectDataItem deliverectDataItem_0, List<Item> list_0, List<ItemsInGroup> list_1, ref int int_0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.dataFromDeliverect = deliverectOrderItem_0;
		int currentTerminalID = HelperMethods.GetCurrentTerminalID();
		decimal num = (decimal)CS_0024_003C_003E8__locals0.dataFromDeliverect.price / 100m;
		string groupName = "";
		Guid orderId = Guid.NewGuid();
		Order order = new Order();
		if (CS_0024_003C_003E8__locals0.dataFromDeliverect.plu != "SERVICECHARGE" && CS_0024_003C_003E8__locals0.dataFromDeliverect.plu != "DELIVERYFEE")
		{
			_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass3_1();
			CS_0024_003C_003E8__locals1.dataItem = list_0.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals0.dataFromDeliverect.plu).FirstOrDefault();
			if (CS_0024_003C_003E8__locals1.dataItem == null || string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.dataFromDeliverect.plu))
			{
				SyncMethods.WriteToSyncLog("INVALID PLU on item -> " + CS_0024_003C_003E8__locals0.dataFromDeliverect.name + " " + CS_0024_003C_003E8__locals0.dataFromDeliverect.plu, "OnlineOrderSync_");
				return null;
			}
			ItemsInGroup itemsInGroup = list_1.Where((ItemsInGroup x) => x.ItemID == CS_0024_003C_003E8__locals1.dataItem.ItemID).FirstOrDefault();
			if (itemsInGroup != null)
			{
				Group group = itemsInGroup.Group;
				if (group != null)
				{
					groupName = group.GroupName;
				}
			}
			order.StationID = CS_0024_003C_003E8__locals1.dataItem.StationID;
			order.ItemID = CS_0024_003C_003E8__locals1.dataItem.ItemID;
			if (deliverectDataItem_0.ItemIdentifier == "OptionItem")
			{
				order.ItemName = "   OPT: " + CS_0024_003C_003E8__locals1.dataItem.ItemName;
			}
			else if (deliverectDataItem_0.ItemIdentifier == "ChildItem")
			{
				order.ItemName = "   " + CS_0024_003C_003E8__locals1.dataItem.ItemName;
			}
			else
			{
				order.ItemName = CS_0024_003C_003E8__locals1.dataItem.ItemName;
			}
			order.ItemPrice = CS_0024_003C_003E8__locals1.dataItem.ItemPrice;
			order.ItemCost = CS_0024_003C_003E8__locals1.dataItem.ItemCost;
			order.ItemBarcode = CS_0024_003C_003E8__locals1.dataItem.Barcode;
			order.ItemCourse = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.dataItem.ItemCourse)) ? CS_0024_003C_003E8__locals1.dataItem.ItemCourse.ToUpper() : ItemCourses.Uncategorized.ToUpper());
		}
		else
		{
			order.StationID = "1";
			order.ItemID = -999;
			order.ItemName = CS_0024_003C_003E8__locals0.dataFromDeliverect.name;
			order.ItemPrice = num;
			order.ItemCost = 0m;
			order.ItemBarcode = "";
			order.ItemCourse = ItemCourses.Uncategorized;
		}
		order.ItemIdentifier = deliverectDataItem_0.ItemIdentifier;
		order.ThirdPartyOrderId = deliverectDataItem_0.DeliverectOrderId;
		order.OrderId = orderId;
		order.Source = OnlineOrderProviders.Deliverect;
		if (deliverectDataItem_0.isPaid)
		{
			order.Paid = true;
			order.DatePaid = deliverectDataItem_0.DateCreated.AddMilliseconds(int_0 * 100);
		}
		else
		{
			order.Paid = false;
			order.DatePaid = null;
		}
		order.OrderNumber = deliverectDataItem_0.OrderNumber;
		order.OrderTicketNumber = deliverectDataItem_0.OrderTicket;
		order.OrderType = deliverectDataItem_0.OrderType;
		order.DiscountDesc = ((deliverectDataItem_0.TotalDiscount > 0m) ? ("item=" + deliverectDataItem_0.TotalDiscount.ToString("0.000")) : string.Empty);
		order.Void = false;
		order.GroupName = groupName;
		order.DateCreated = deliverectDataItem_0.DateCreated.AddMilliseconds(int_0 * 100);
		order.Discount = deliverectDataItem_0.TotalDiscount;
		order.TipAmount = 0m;
		order.SubTotal = num * (decimal)CS_0024_003C_003E8__locals0.dataFromDeliverect.quantity - deliverectDataItem_0.TotalDiscount;
		order.TaxTotal = deliverectDataItem_0.ItemTax;
		order.TaxDesc = ((num == 0m) ? "TAX:0.00|" : ("TAX:" + deliverectDataItem_0.ItemTax.ToString("0.00") + "|"));
		order.Total = order.SubTotal + deliverectDataItem_0.ItemTax;
		order.PaymentMethods = (order.Paid ? (deliverectDataItem_0.SubSource.ToString().ToUpper().Replace("_", " ") + "=" + deliverectDataItem_0.TotalAmount.ToString("0.00") + "|") : "SAVED ORDER");
		order.UserCancelled = null;
		order.UserCashout = null;
		order.UserServed = null;
		order.DateRefunded = null;
		order.ItemSellPrice = num;
		order.ComboID = deliverectDataItem_0.ComboId;
		order.Qty = CS_0024_003C_003E8__locals0.dataFromDeliverect.quantity;
		order.DiscountReason = null;
		order.OrderOnHoldTime = 0;
		order.DateTimeSeated = null;
		order.SeatNum = "0";
		order.CreatedByTerminalID = currentTerminalID;
		order.Synced = false;
		order.Customer = ((!string.IsNullOrEmpty(deliverectDataItem_0.SubSource)) ? (deliverectDataItem_0.SubSource + "-" + deliverectDataItem_0.OrderTicket.Substring(deliverectDataItem_0.OrderTicket.Length - 4).ToUpper()) : (OnlineOrderProviders.Deliverect.ToUpper() + "-" + deliverectDataItem_0.OrderTicket.Substring(deliverectDataItem_0.OrderTicket.Length - 4).ToUpper()));
		order.CustomerInfoName = deliverectDataItem_0.CustomerName;
		order.CustomerInfo = deliverectDataItem_0.CustomerInfo;
		order.CustomerInfoEmail = deliverectDataItem_0.CustomerEmail;
		order.CustomerInfoPhone = deliverectDataItem_0.CustomerPhone;
		if (int_0 == 0)
		{
			order.Instructions = deliverectDataItem_0.Instructions;
		}
		order.Instructions = CS_0024_003C_003E8__locals0.dataFromDeliverect.remark;
		order.SubSource = deliverectDataItem_0.SubSource;
		if (deliverectDataItem_0.PickupTime.Year > 2000)
		{
			order.DeliveryTime = deliverectDataItem_0.PickupTime;
		}
		order.FlagID = 1;
		if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
		{
			order.FlagID = 0;
		}
		int_0++;
		return order;
	}

	private static List<Order> smethod_2(GClass6 gclass6_0, OnlineOrderSyncQueue onlineOrderSyncQueue_0, List<Item> list_0, List<ItemsInGroup> list_1, DeliverectOrderData deliverectOrderData_0, List<DeliverectOrderItem> list_2, DeliverectDataItem deliverectDataItem_0, decimal decimal_0, decimal decimal_1, bool bool_0, ref int int_0, ref short short_0, ref decimal decimal_2, ref decimal decimal_3)
	{
		List<Order> list = new List<Order>();
		using List<DeliverectOrderItem>.Enumerator enumerator = list_2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals0.dataItem = enumerator.Current;
			decimal num = (decimal)CS_0024_003C_003E8__locals0.dataItem.price / 100m;
			decimal totalDiscount = default(decimal);
			if (decimal_3 > 0m)
			{
				if (num * (decimal)CS_0024_003C_003E8__locals0.dataItem.quantity > decimal_3)
				{
					totalDiscount = decimal_3;
					num -= ((CS_0024_003C_003E8__locals0.dataItem.quantity > 0) ? (decimal_3 / (decimal)CS_0024_003C_003E8__locals0.dataItem.quantity) : decimal_3);
					decimal_3 = default(decimal);
				}
				else
				{
					totalDiscount = num;
					if (CS_0024_003C_003E8__locals0.dataItem.quantity > 0)
					{
						decimal_3 = decimal_3 / (decimal)CS_0024_003C_003E8__locals0.dataItem.quantity - num;
					}
					else
					{
						decimal_3 -= num;
					}
					num = default(decimal);
				}
			}
			decimal num2 = ((decimal_0 > 0m) ? Math.Round(num * (decimal)CS_0024_003C_003E8__locals0.dataItem.quantity / decimal_0 * decimal_1, 2) : 0m);
			decimal_2 -= num2;
			deliverectDataItem_0.DeliverectOrderId = deliverectOrderData_0._id;
			deliverectDataItem_0.OrderNumber = deliverectOrderData_0.channelOrderId;
			deliverectDataItem_0.OrderTicket = deliverectOrderData_0.channelOrderDisplayId;
			deliverectDataItem_0.ItemTax = num2;
			deliverectDataItem_0.TotalDiscount = totalDiscount;
			deliverectDataItem_0.ComboId = short_0;
			if (CS_0024_003C_003E8__locals0.dataItem.plu.Contains("OPT"))
			{
				string plu = CS_0024_003C_003E8__locals0.dataItem.plu.Split('-')[2];
				CS_0024_003C_003E8__locals0.dataItem.plu = plu;
				deliverectDataItem_0.ItemIdentifier = "OptionItem";
			}
			else if (!bool_0)
			{
				deliverectDataItem_0.ItemIdentifier = "ChildItem";
			}
			else
			{
				deliverectDataItem_0.ItemIdentifier = "MainItem";
			}
			Order order = smethod_1(CS_0024_003C_003E8__locals0.dataItem, deliverectDataItem_0, list_0, list_1, ref int_0);
			if (order != null)
			{
				list.Add(order);
				if (CS_0024_003C_003E8__locals0.dataItem.subItems != null && CS_0024_003C_003E8__locals0.dataItem.subItems.Count > 0)
				{
					CS_0024_003C_003E8__locals0.dataItem.subItems.ForEach(delegate(DeliverectOrderItem a)
					{
						a.quantity = CS_0024_003C_003E8__locals0.dataItem.quantity;
					});
					List<Order> list2 = smethod_2(gclass6_0, onlineOrderSyncQueue_0, list_0, list_1, deliverectOrderData_0, CS_0024_003C_003E8__locals0.dataItem.subItems, deliverectDataItem_0, decimal_0, decimal_1, bool_0: false, ref int_0, ref short_0, ref decimal_2, ref decimal_3);
					if (list2 == null)
					{
						return null;
					}
					list.AddRange(list2);
				}
				if (bool_0 && !CS_0024_003C_003E8__locals0.dataItem.plu.Contains("OPT"))
				{
					short_0++;
				}
				continue;
			}
			SyncMethods.WriteToSyncLog("Deliverect Order: Invalid PLU for order " + deliverectOrderData_0.channelOrderId, "OnlineOrderSync_");
			return null;
		}
		return list;
	}

	public DeliverectMethods()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
