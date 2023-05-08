using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class OrderMethods
{
	protected GClass6 _dataContext;

	public OrderMethods(GClass6 dataContext = null)
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
		if (dataContext == null)
		{
			_dataContext = new GClass6();
		}
		else
		{
			_dataContext = dataContext;
		}
	}

	public static string GetNewOrderNumber()
	{
		GClass6 gClass = new GClass6();
		GenKey genKey = gClass.GenKeys.Where((GenKey a) => a.KeyName == "OrderNumber").FirstOrDefault();
		if (genKey == null)
		{
			genKey = new GenKey();
			genKey.KeyName = "OrderNumber";
			genKey.LastKey = 0L;
			genKey.Prefix = "OR";
			genKey.CleanUp_Bookmark = 0L;
			gClass.GenKeys.InsertOnSubmit(genKey);
			Helper.SubmitChangesWithCatch(gClass);
		}
		genKey.LastKey++;
		Helper.SubmitChangesWithCatch(gClass);
		return ((!string.IsNullOrEmpty(genKey.Prefix)) ? genKey.Prefix.Trim() : "") + $"{genKey.LastKey:000000}";
	}

	public static string GetNewOrderTicketNumber(string orderType)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.orderType = orderType;
		GClass6 gClass = new GClass6();
		OrderTypeGenKey orderTypeGenKey = gClass.OrderTypeGenKeys.Where((OrderTypeGenKey a) => a.OrderType == CS_0024_003C_003E8__locals0.orderType).FirstOrDefault();
		GenKey genKey;
		if (orderTypeGenKey == null)
		{
			genKey = gClass.GenKeys.Where((GenKey a) => a.KeyName == "OrderTicket").FirstOrDefault();
			if (genKey == null)
			{
				genKey = new GenKey();
				genKey.KeyName = "OrderTicket";
				genKey.LastKey = 0L;
				genKey.Prefix = "";
				genKey.CleanUp_Bookmark = 0L;
				genKey.StartKey = 0;
				genKey.EndKey = 999;
				gClass.GenKeys.InsertOnSubmit(genKey);
				Helper.SubmitChangesWithCatch(gClass);
			}
			orderTypeGenKey = new OrderTypeGenKey();
			orderTypeGenKey.GenKeysId = genKey.GenKeyID;
			orderTypeGenKey.OrderType = CS_0024_003C_003E8__locals0.orderType;
			gClass.OrderTypeGenKeys.InsertOnSubmit(orderTypeGenKey);
			Helper.SubmitChangesWithCatch(gClass);
		}
		else
		{
			genKey = orderTypeGenKey.GenKey;
		}
		if (!genKey.EndKey.HasValue)
		{
			genKey.LastKey++;
		}
		else if (genKey.EndKey.Value <= genKey.LastKey)
		{
			genKey.LastKey = genKey.StartKey.Value;
		}
		else
		{
			genKey.LastKey++;
		}
		Helper.SubmitChangesWithCatch(gClass);
		return ((!string.IsNullOrEmpty(genKey.Prefix)) ? genKey.Prefix.Trim() : "") + genKey.LastKey;
	}

	public static void ResetOrderTicketNumbers()
	{
		GClass6 gClass = new GClass6();
		foreach (GenKey item in gClass.GenKeys.Where((GenKey a) => a.GenKeyID > 2).ToList())
		{
			item.LastKey = (item.StartKey.HasValue ? item.StartKey.Value : 0);
			item.LastDateUpdated = DateTime.Now.Date;
		}
		gClass.SubmitChanges();
	}

	public static string FormatOrderNumber(string checkno)
	{
		GenKey genKey = new GClass6().GenKeys.Where((GenKey a) => a.KeyName == "OrderNumber").FirstOrDefault();
		return ((genKey.Prefix == null) ? string.Empty : genKey.Prefix.Trim()) + $"{Convert.ToInt32(checkno):000000}";
	}

	public static string GetNewRefundNumber()
	{
		DataManager dataManager = new DataManager();
		GenKey genKey = (from k in dataManager.GetGenKeys()
			where k.KeyName == "RefundNumber"
			select k).FirstOrDefault();
		if (genKey == null)
		{
			genKey = new GenKey();
			genKey.KeyName = "RefundNumber";
			genKey.LastKey = 0L;
			genKey.Prefix = "RF";
			genKey.CleanUp_Bookmark = 0L;
			dataManager.DataContext.GenKeys.InsertOnSubmit(genKey);
			Helper.SubmitChangesWithCatch(dataManager.DataContext);
		}
		genKey.LastKey++;
		string result = genKey.Prefix.Trim() + $"{genKey.LastKey:000000}";
		GenKeyMethods.updateGenKey(genKey.KeyName, genKey.LastKey);
		return result;
	}

	public void SaveOrder(List<Item> itemList, string orderNumber, string customer, string orderType, int customerID, string paymentMethod, decimal TenderCash, decimal TenderChange, bool isPaid = true, string customerInfo = "", string discountReason = "", string customerInfoName = "", string customerInfoPhone = "", int GuestCount = 1, bool isDiscount = false, string taxChangeReason = "", short seatNum = 0, int? terminalId = null, List<decimal> transactionFees = null, short EmployeeCreated = 0, DateTime? FullfilmentDate = null, string OrderDiscountType = "", bool GratuityRemoved = false, byte overrideFlagID = 0, string orderNotes = "")
	{
		DataManager dataManager = new DataManager(_dataContext);
		dataManager.SaveOneOrder(itemList, orderNumber, customer, orderType, customerID, paymentMethod, TenderCash, TenderChange, dataManager, isPaid, customerInfo, discountReason, customerInfoName, customerInfoPhone, GuestCount, isDiscount, taxChangeReason, seatNum, terminalId, transactionFees, EmployeeCreated, FullfilmentDate, OrderDiscountType, GratuityRemoved, overrideFlagID, orderNotes);
	}

	public static void RecheckGuestCountSplittedBill(string customer)
	{
		new DataManager().RecheckGuestCountSplittedBill(customer);
	}

	public static void DeleteOrders(string orderNumber)
	{
		DataManager dataManager = new DataManager();
		IQueryable<Order> order = dataManager.GetOrder(orderNumber);
		dataManager.DataContext.Orders.DeleteAllOnSubmit(order);
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
	}

	public static void UnpaidAnOrder(string orderNumber, decimal extraTip = 0m)
	{
		DataManager dataManager = new DataManager();
		foreach (Order item in dataManager.GetOrder(orderNumber))
		{
			item.DatePaid = null;
			item.Paid = false;
			item.PaymentMethods = "SAVED ORDER";
			if (item.TipAmount - extraTip >= 0m)
			{
				item.TipAmount -= extraTip;
			}
			item.Synced = false;
			if (item.ItemID == -100)
			{
				dataManager.DataContext.Orders.DeleteOnSubmit(item);
			}
		}
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
	}

	public static void DeleteOneOrderItem(string orderNumber, Guid orderID)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.orderID = orderID;
		DataManager dataManager = new DataManager();
		Order entity = (from o in dataManager.GetOrder(orderNumber)
			where o.OrderId == CS_0024_003C_003E8__locals0.orderID
			select o).FirstOrDefault();
		dataManager.DataContext.Orders.DeleteOnSubmit(entity);
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
	}

	public static void VoidOneOrderItem(string orderNumber, Guid orderID)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.orderID = orderID;
		DataManager dataManager = new DataManager();
		Order order = (from o in dataManager.GetOrder(orderNumber)
			where o.OrderId == CS_0024_003C_003E8__locals0.orderID
			select o).FirstOrDefault();
		if (order != null)
		{
			order.Void = true;
			Helper.SubmitChangesWithCatch(dataManager.DataContext);
		}
	}

	public static void CancelPartialPaidCaterOrder(string orderNumber)
	{
		DataManager dataManager = new DataManager();
		List<Order> list = dataManager.GetOrder(orderNumber).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		Order order = list.FirstOrDefault();
		decimal num = list.Sum((Order a) => a.Total);
		decimal num2 = PaymentTypeMethods.GetPaymentTypes(order.PaymentMethods).Sum((ProcessorPaymentType a) => a.Amount) - num;
		foreach (Order item in list)
		{
			item.Paid = true;
			item.DatePaid = DateTime.Now;
		}
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
		Order order2 = new Order();
		order2.OrderId = Guid.NewGuid();
		order2.OrderNumber = orderNumber;
		order2.OrderTicketNumber = order.OrderTicketNumber;
		order2.SortOrder = order.SortOrder;
		order2.OrderType = order.OrderType;
		order2.Customer = order.Customer;
		order2.RulesDesc = order.RulesDesc;
		order2.DiscountDesc = order.DiscountDesc;
		order2.Paid = true;
		order2.Void = true;
		order2.StationID = "";
		order2.ItemID = -888;
		order2.ItemName = ConstantItems.Cancelled_Cater;
		order2.Instructions = "";
		order2.ItemPrice = num2;
		order2.Discount = 0m;
		order2.SubTotal = num2;
		order2.TaxTotal = 0m;
		order2.Total = num2;
		order2.PaymentMethods = order.PaymentMethods;
		order2.DateCreated = DateTime.Now;
		order2.DateFilled = null;
		order2.DatePaid = DateTime.Now;
		order2.DateRefunded = null;
		order2.UserCreated = order.UserCreated;
		order2.Notified = false;
		order2.VoidNotified = false;
		order2.ComboID = 0;
		order2.Synced = false;
		order2.CustomerID = order.CustomerID;
		order2.TaxDesc = order.TaxDesc;
		order2.GroupName = "";
		order2.Qty = 1m;
		order2.ItemCost = 0m;
		order2.ItemSellPrice = num2;
		order2.LastSynced = null;
		order2.VoidBy = order.VoidBy;
		order2.Options = order.Options;
		order2.CustomerInfo = order.CustomerInfo;
		order2.DiscountReason = order.DiscountReason;
		order2.TenderAmount = 0m;
		order2.TenderChange = 0m;
		order2.TipAmount = 0m;
		order2.DateCleared = null;
		order2.TipRecorded = false;
		order2.CustomerInfoName = order.CustomerInfoName;
		order2.GuestCount = 1;
		order2.ItemMadeNotified = false;
		order2.IsDiscount = order.IsDiscount;
		order2.SeatNum = order.SeatNum;
		order2.ItemIdentifier = order.ItemIdentifier;
		order2.ItemCourse = order.ItemCourse;
		order2.FlagID = order.FlagID;
		order2.UserCashout = order.UserCashout;
		order2.UserServed = order.UserServed;
		order2.VoidReason = order.VoidReason;
		dataManager.DataContext.Orders.InsertOnSubmit(order2);
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
	}

	public IEnumerable<OccupiedTable> OccupiedTables()
	{
		DataManager dataManager = new DataManager();
		List<OpenOrder> list = (from o in dataManager.DataContext.Orders
			where (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && !o.OrderType.Equals(OrderTypes.ToGo) && !o.OrderType.Contains(OrderTypes.PickUp) && !o.OrderType.Contains(OrderTypes.Delivery) && !o.OrderType.Contains(OrderTypes.DeliveryOnline) && !o.OrderType.Contains(OrderTypes.TakeOutOnline) && o.DateCreated.Value >= DateTime.Now.AddDays(-1.0)
			select new OpenOrder
			{
				Customer = o.Customer.Replace("Table ", string.Empty).Trim(),
				OrderType = o.OrderType,
				Paid = o.Paid,
				GuestCount = o.GuestCount,
				TipRecorded = o.TipRecorded,
				Cleared = ((o.DateCleared == null) ? false : true),
				OrderNumber = o.OrderNumber,
				SeatNum = o.SeatNum,
				EmployeeID = (o.UserServed.HasValue ? o.UserServed.Value : 0)
			}).Distinct().ToList();
		List<OccupiedTable> list2 = new List<OccupiedTable>();
		using List<OpenOrder>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals0.o = enumerator.Current;
			Layout layout = dataManager.DataContext.Layouts.Where((Layout x) => CS_0024_003C_003E8__locals0.o.Customer == x.TableName && CS_0024_003C_003E8__locals0.o.Customer != string.Empty).FirstOrDefault();
			if (layout != null)
			{
				OccupiedTable item = new OccupiedTable
				{
					Customer = CS_0024_003C_003E8__locals0.o.Customer,
					TableName = layout.TableName,
					Paid = CS_0024_003C_003E8__locals0.o.Paid,
					GuestCount = layout.CurrentGuests,
					TipRecorded = CS_0024_003C_003E8__locals0.o.TipRecorded,
					Cleared = CS_0024_003C_003E8__locals0.o.Cleared,
					OrderNumber = CS_0024_003C_003E8__locals0.o.OrderNumber,
					SeatNum = CS_0024_003C_003E8__locals0.o.SeatNum,
					EmployeeID = CS_0024_003C_003E8__locals0.o.EmployeeID
				};
				list2.Add(item);
			}
		}
		return list2;
	}

	public List<Order> OpenOrders(int daterangefilter = 60)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.daterangefilter = daterangefilter;
		try
		{
			List<Order> first = new List<Order>();
			List<Order> list = new List<Order>();
			if (CS_0024_003C_003E8__locals0.daterangefilter > 0 && CS_0024_003C_003E8__locals0.daterangefilter != 2 && CS_0024_003C_003E8__locals0.daterangefilter != 9999)
			{
				first = _dataContext.Orders.Where((Order o) => o.DateCreated >= DateTime.Now.AddDays(-CS_0024_003C_003E8__locals0.daterangefilter) && o.DateCreated < DateTime.Now.AddDays(1.0).Date && !o.FulfillmentAt.HasValue && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
				list = _dataContext.Orders.Where((Order o) => o.FulfillmentAt >= DateTime.Now.AddDays(-CS_0024_003C_003E8__locals0.daterangefilter) && o.FulfillmentAt < DateTime.Now.AddDays(1.0).Date && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
			}
			else if (CS_0024_003C_003E8__locals0.daterangefilter == 2)
			{
				first = _dataContext.Orders.Where((Order o) => o.DateCreated >= DateTime.Now.AddDays(-1.0).Date && o.DateCreated < DateTime.Now.Date && !o.FulfillmentAt.HasValue && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
				list = _dataContext.Orders.Where((Order o) => o.FulfillmentAt >= DateTime.Now.AddDays(-1.0).Date && o.FulfillmentAt < DateTime.Now.Date && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
			}
			else if (CS_0024_003C_003E8__locals0.daterangefilter == 9999)
			{
				first = _dataContext.Orders.Where((Order o) => o.DateCreated >= DateTime.Now.AddYears(-2) && !o.FulfillmentAt.HasValue && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
				list = _dataContext.Orders.Where((Order o) => o.FulfillmentAt >= DateTime.Now.AddYears(-2) && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
			}
			else
			{
				list = _dataContext.Orders.Where((Order o) => o.FulfillmentAt.Value > DateTime.Now.AddDays(1.0).Date && o.FulfillmentAt < DateTime.Now.AddDays(-(CS_0024_003C_003E8__locals0.daterangefilter - 1)).Date && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false).ToList();
			}
			return first.Union(list).ToList();
		}
		catch
		{
			Thread.Sleep(2000);
			return OpenOrders(CS_0024_003C_003E8__locals0.daterangefilter);
		}
	}

	public List<Order> OpenOrders(string orderType, int daterangefilter = 60)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.orderType = orderType;
		if (CS_0024_003C_003E8__locals0.orderType != OrderTypes.AllOnline)
		{
			return (from x in OpenOrders(daterangefilter)
				where x.OrderType == CS_0024_003C_003E8__locals0.orderType
				orderby x.OrderNumber
				select x).ToList();
		}
		return _dataContext.Orders.Where((Order o) => o.DateCreated >= DateTime.Now.AddDays(-1.0) && o.FlagID == 1).ToList();
	}

	public List<Order> UnPaidOpenOrders(string orderType, string customer, string orderNumber = null)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.orderType = orderType;
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		CS_0024_003C_003E8__locals0.customer = customer;
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.orderNumber))
		{
			return (from o in _dataContext.Orders
				where o.Paid == false && o.Void == false && o.OrderType == CS_0024_003C_003E8__locals0.orderType && o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber
				orderby o.DateCreated
				select o).ToList();
		}
		return (from o in _dataContext.Orders
			where o.Paid == false && o.Void == false && o.OrderType == CS_0024_003C_003E8__locals0.orderType && o.Customer == CS_0024_003C_003E8__locals0.customer && o.DateCreated >= DateTime.Now.AddDays(-15.0)
			orderby o.OrderNumber, o.DateCreated
			select o).ToList();
	}

	public List<OrderTotal> OpenDineInBills(string tableName = null, string ordernumber = null)
	{
		_003C_003Ec__DisplayClass18_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.tableName = tableName;
		CS_0024_003C_003E8__locals0.ordernumber = ordernumber;
		List<Order> source;
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.tableName) && !(CS_0024_003C_003E8__locals0.tableName == "0"))
		{
			if (!CS_0024_003C_003E8__locals0.tableName.Contains("Table"))
			{
				CS_0024_003C_003E8__locals0.tableName = "Table " + CS_0024_003C_003E8__locals0.tableName;
			}
			source = OpenOrders(OrderTypes.DineIn).Where(delegate(Order x)
			{
				DateTime? dateCreated = x.DateCreated;
				DateTime dateTime = DateTime.Now.AddDays(-1.0);
				return dateCreated.HasValue && dateCreated.GetValueOrDefault() >= dateTime && x.Customer.Contains("Table") && !x.Paid && x.Customer == CS_0024_003C_003E8__locals0.tableName;
			}).ToList();
		}
		else
		{
			source = (from x in OpenOrders(OrderTypes.DineIn, 1)
				where x.Customer.Contains("Table") && !x.Paid
				select x).ToList();
			List<Order> second = (from x in OpenOrders(15)
				where x.OrderType != OrderTypes.DineIn && !x.Paid
				select x).ToList();
			source = source.Union(second).ToList();
		}
		if (CS_0024_003C_003E8__locals0.ordernumber != null)
		{
			source = source.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.ordernumber).ToList();
		}
		List<string> list = source.Select((Order a) => a.OrderNumber).Distinct().ToList();
		List<OrderTotal> list2 = new List<OrderTotal>();
		using List<string>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_1();
			CS_0024_003C_003E8__locals1.tmp_orderNumber = enumerator.Current;
			_003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass18_2();
			CS_0024_003C_003E8__locals2.tmp_Orders = source.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals1.tmp_orderNumber).ToList();
			list2.Add(CS_0024_003C_003E8__locals2.tmp_Orders.Select(delegate(Order o)
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_3();
				CS_0024_003C_003E8__locals0.o = o;
				return new OrderTotal
				{
					OrderNumber = CS_0024_003C_003E8__locals0.o.OrderNumber,
					Tax = CS_0024_003C_003E8__locals2.tmp_Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.o.OrderNumber).Sum((Order y) => y.TaxTotal),
					Sub = CS_0024_003C_003E8__locals2.tmp_Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.o.OrderNumber).Sum((Order y) => y.SubTotal),
					TenderedAmount = CS_0024_003C_003E8__locals0.o.TenderAmount,
					UserCreatedID = (CS_0024_003C_003E8__locals0.o.UserCreated.HasValue ? CS_0024_003C_003E8__locals0.o.UserCreated.Value : 0),
					ServedByUserID = (CS_0024_003C_003E8__locals0.o.UserServed.HasValue ? CS_0024_003C_003E8__locals0.o.UserServed.Value : 0),
					Customer = ((CS_0024_003C_003E8__locals0.o.OrderType == OrderTypes.DineIn) ? CS_0024_003C_003E8__locals0.o.Customer : "TAKE-OUTS"),
					CustomerInfo = ((CS_0024_003C_003E8__locals0.o.OrderType == OrderTypes.DineIn) ? CS_0024_003C_003E8__locals0.o.Customer.Replace("Table ", string.Empty) : "0")
				};
			}).FirstOrDefault());
		}
		return list2;
	}

	public List<Order> FilledOrders(short stationID = 1, int take = 40)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.stationID = stationID;
		if (CS_0024_003C_003E8__locals0.stationID == -1)
		{
			return (from o in _dataContext.Orders
				where o.DateFilled.HasValue && o.DateFilled.Value >= DateTime.Now.AddHours(-12.0).Date && o.ItemID != -999
				select o into a
				orderby a.DatePaid descending
				select a).Take(take).ToList();
		}
		return (from o in _dataContext.Orders
			where o.DateFilled.HasValue && o.StationID.Contains(CS_0024_003C_003E8__locals0.stationID.ToString()) && o.DateFilled.Value >= DateTime.Now.AddHours(-12.0).Date && o.ItemID != -999
			select o into a
			orderby a.DateCreated descending
			select a).Take(take).ToList();
	}

	public List<Order> FilledCompleteOrders(int numberOfMinuteForMadeOrderClear)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.numberOfMinuteForMadeOrderClear = numberOfMinuteForMadeOrderClear;
		List<Order> source = (from o in _dataContext.Orders
			where o.DateFilled.HasValue && o.DateFilled.Value >= DateTime.Now.AddMinutes(-CS_0024_003C_003E8__locals0.numberOfMinuteForMadeOrderClear) && o.ItemID != -999
			select o into a
			orderby a.DatePaid descending
			select a).ToList();
		List<string> list = source.Select((Order x) => x.OrderNumber).Distinct().ToList();
		CS_0024_003C_003E8__locals0.made_orders = new List<string>();
		int num = 0;
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass20_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass20_1();
				CS_0024_003C_003E8__locals1.ordernumber = enumerator.Current;
				num = source.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals1.ordernumber && !x.Void).Count();
				if (source.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals1.ordernumber && !x.Void && x.DateFilled.HasValue).Count() == num)
				{
					CS_0024_003C_003E8__locals0.made_orders.Add(CS_0024_003C_003E8__locals1.ordernumber);
				}
			}
		}
		return source.Where((Order x) => CS_0024_003C_003E8__locals0.made_orders.Contains(x.OrderNumber)).ToList();
	}

	public List<Order> UnfilledOrders(short stationID = 1)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.stationID = stationID;
		if (CS_0024_003C_003E8__locals0.stationID == -1)
		{
			return (from o in _dataContext.Orders
				where !o.DateFilled.HasValue && o.ShareItemID == null && o.DateCreated.Value.Date >= DateTime.Now.AddDays(-1.0).Date && o.ItemID != -999 && !o.PaymentMethods.Contains("KIOSK")
				orderby o.DateCreated, o.OrderNumber
				select o).ToList();
		}
		return (from o in _dataContext.Orders
			where !o.DateFilled.HasValue && o.StationID.Contains(CS_0024_003C_003E8__locals0.stationID.ToString()) && (o.StationMade == null || !o.StationMade.Contains(CS_0024_003C_003E8__locals0.stationID.ToString())) && o.ShareItemID == null && o.DateCreated.Value.Date >= DateTime.Now.AddDays(-1.0).Date && o.ItemID != -999 && !o.PaymentMethods.Contains("KIOSK")
			orderby o.DateCreated, o.OrderNumber
			select o).ToList();
	}

	public List<OrderTableNameAndNumber> UnfilledOrderNumbers(string query, string orderType, short stationID = 1, bool showOnlyOnPaid = false, bool showOnConfirmOnline = false)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.query = query;
		CS_0024_003C_003E8__locals0.orderType = orderType;
		CS_0024_003C_003E8__locals0.stationID = stationID;
		List<Order> source = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.query) ? (from o in _dataContext.Orders
			where !o.DateFilled.HasValue && o.ShareItemID == null && o.DateCreated.Value.Date >= DateTime.Now.AddDays(-1.0).Date && o.ItemID != -999 && !o.PaymentMethods.Contains("KIOSK") && (o.OrderOnHoldTime == 0 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime)))
			orderby o.DateCreated.Value, o.OrderNumber
			select o).ToList() : (from o in _dataContext.Orders
			where ((o.Customer != null && o.Customer.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (o.CustomerInfo != null && o.CustomerInfo.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (o.CustomerInfoName != null && o.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || o.OrderNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query) || (o.OrderTicketNumber != null && o.OrderTicketNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query))) && !o.DateFilled.HasValue && o.ShareItemID == null && o.DateCreated.Value >= DateTime.Now.AddDays(-1.0).Date.Date && o.ItemID != -999 && !o.PaymentMethods.Contains("KIOSK") && (o.OrderOnHoldTime == 0 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime)))
			orderby o.DateCreated.Value, o.OrderNumber
			select o).ToList());
		if (CS_0024_003C_003E8__locals0.orderType != "ALL")
		{
			source = source.Where((Order x) => x.OrderType.ToUpper().Contains(CS_0024_003C_003E8__locals0.orderType)).ToList();
		}
		if (showOnlyOnPaid)
		{
			source = source.Where((Order a) => a.Paid || (a.OrderType != OrderTypes.DineIn && a.OrderType != OrderTypes.ToGo)).ToList();
		}
		if (showOnConfirmOnline)
		{
			source = source.Where((Order a) => a.FlagID != 1 || a.FlagID == 0).ToList();
		}
		if (CS_0024_003C_003E8__locals0.stationID != -1)
		{
			source = source.Where((Order a) => a.StationID != null && a.StationID.Contains(CS_0024_003C_003E8__locals0.stationID.ToString()) && (a.StationMade == null || !a.StationMade.Contains(CS_0024_003C_003E8__locals0.stationID.ToString()))).ToList();
		}
		return (from a in source
			group a by new { a.OrderNumber, a.Customer, a.OrderType } into a
			select new OrderTableNameAndNumber
			{
				OrderNumber = a.Key.OrderNumber,
				TableName = a.Key.Customer,
				OrderType = a.Key.OrderType
			}).ToList();
	}

	public List<Order> UnfilledRefundedAndVoidOrders(short stationID)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0.stationID = stationID;
		return _dataContext.Orders.Where((Order o) => o.DateCreated > DateTime.Now.AddMonths(-1) && o.DateFilled == null && o.StationID.Contains(CS_0024_003C_003E8__locals0.stationID.ToString()) && (o.StationMade == null || !o.StationMade.Contains(CS_0024_003C_003E8__locals0.stationID.ToString())) && o.Void == true && o.ShareItemID == null && o.ItemID != -999).ToList();
	}

	public List<Order> Orders(string orderNumber)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		try
		{
			return (from o in _dataContext.Orders
				where o.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderNumber)
				orderby o.DateCreated
				select o).ToList();
		}
		catch
		{
			Thread.Sleep(2000);
			return (from o in _dataContext.Orders
				where o.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderNumber)
				orderby o.DateCreated
				select o).ToList();
		}
	}

	public static bool CheckIfOpenOrderExists(string ordernumber, int daysDDL)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0.daysDDL = daysDDL;
		CS_0024_003C_003E8__locals0.ordernumber = ordernumber;
		CS_0024_003C_003E8__locals0.daysDDL = Math.Abs(CS_0024_003C_003E8__locals0.daysDDL);
		return new GClass6().Orders.Where((Order o) => (o.DateCreated > DateTime.Now.AddDays(-CS_0024_003C_003E8__locals0.daysDDL) || o.FulfillmentAt > DateTime.Now.AddDays(-CS_0024_003C_003E8__locals0.daysDDL)) && o.OrderNumber == CS_0024_003C_003E8__locals0.ordernumber && o.Paid == false && o.Void == false).Count() > 0;
	}

	public List<Order> UnfilledOrderTable(string TableName)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.TableName = TableName;
		return _dataContext.Orders.Where((Order o) => (o.Customer == CS_0024_003C_003E8__locals0.TableName || o.Customer == CS_0024_003C_003E8__locals0.TableName.ToUpper()) && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateFilled == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
	}

	public List<Order> SharedOrders(Guid SharedOrderId)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.SharedOrderId = SharedOrderId;
		return _dataContext.Orders.Where((Order x) => x.ShareItemID.Value == CS_0024_003C_003E8__locals0.SharedOrderId).ToList();
	}

	public List<OrderResult> AllPaidOrdersToday()
	{
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass28_0();
		DataManager dataManager = new DataManager();
		CS_0024_003C_003E8__locals0.workingDay = getWorkingDay();
		return (from o in dataManager.DataContext.Orders
			where o.Paid == true && o.Void == false && ((DateTime)o.DatePaid).Date >= CS_0024_003C_003E8__locals0.workingDay.Date
			orderby o.OrderNumber descending
			select new OrderResult
			{
				OrderNumber = o.OrderNumber,
				PaymentMethods = o.PaymentMethods,
				Customer = o.Customer,
				DateCreated = o.DateCreated.Value,
				FulFillmentAt = o.FulfillmentAt,
				StationID = o.StationID
			}).Distinct().ToList();
	}

	public static DateTime getWorkingDay()
	{
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CultureInfo cultureInfo = new CultureInfo("en-US");
		CS_0024_003C_003E8__locals0.day = cultureInfo.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
		BusinessHour businessHour = new GClass6().BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek.ToUpper() == CS_0024_003C_003E8__locals0.day).FirstOrDefault();
		string latestClosingTime = businessHour.LatestClosingTime;
		string latestOpeningTime = businessHour.LatestOpeningTime;
		DateTime dateTime = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestOpeningTime);
		DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestClosingTime);
		if (dateTime2 < dateTime)
		{
			dateTime2 = dateTime2.AddDays(1.0);
		}
		return dateTime2;
	}

	public static DateTime getEarliestDate()
	{
		return new DataManager().DataContext.Orders.OrderBy((Order o) => o.DateCreated).FirstOrDefault().DateCreated.Value;
	}

	public static DateTime getLastestDate()
	{
		return new DataManager().DataContext.Orders.OrderByDescending((Order o) => o.DateCreated).FirstOrDefault().DateCreated.Value;
	}

	public Order GetOrder(string orderNumber, Guid Id)
	{
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass32_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		CS_0024_003C_003E8__locals0.Id = Id;
		return _dataContext.Orders.Where((Order o) => o.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderNumber) && o.OrderId == CS_0024_003C_003E8__locals0.Id).FirstOrDefault();
	}

	public Order GetOrder(Guid Id)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0.Id = Id;
		return _dataContext.Orders.Where((Order o) => o.OrderId == CS_0024_003C_003E8__locals0.Id).FirstOrDefault();
	}

	public List<Order> GetSubSharedOrders(Guid Id)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.Id = Id;
		return _dataContext.Orders.Where((Order o) => o.ShareItemID == CS_0024_003C_003E8__locals0.Id && o.Void == false).ToList();
	}

	public static void deleteCashTypeOrders()
	{
		DataManager dataManager = new DataManager();
		IQueryable<Order> entities = dataManager.DataContext.Orders.Where((Order o) => o.PaymentMethods == "Cash|");
		dataManager.DataContext.Orders.DeleteAllOnSubmit(entities);
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
	}

	public List<Order> todaysOrders(DateTime start)
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0.start = start;
		return new DataManager().DataContext.Orders.Where((Order o) => o.DatePaid >= CS_0024_003C_003E8__locals0.start && o.DatePaid <= DateTime.Now && o.Void == false && o.Paid == true && o.DateRefunded.HasValue == false).ToList();
	}

	public static long getBatchOrders(string prefix, long indexInt, int batch, out int numberOrderProcessed)
	{
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_0();
		DataManager dataManager = new DataManager();
		CS_0024_003C_003E8__locals0.startIndex = prefix + $"{indexInt:000000}";
		_ = prefix + $"{indexInt + batch:000000}";
		IQueryable<Order> queryable = (from o in dataManager.DataContext.Orders
			where string.Compare(o.OrderNumber, CS_0024_003C_003E8__locals0.startIndex) >= 0
			orderby o.OrderNumber
			select o).Take(batch * 10);
		numberOrderProcessed = 0;
		string text = string.Empty;
		bool flag = false;
		foreach (Order item in queryable)
		{
			string text2 = item.PaymentMethods;
			if (item.PaymentMethods.EndsWith("|"))
			{
				text2 = item.PaymentMethods.Remove(item.PaymentMethods.Length - 1);
			}
			flag = false;
			string[] array = text2.Split('|');
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "Cash")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				dataManager.DataContext.Orders.DeleteOnSubmit(item);
				continue;
			}
			if (!(text != item.OrderNumber) || numberOrderProcessed + 1 <= batch)
			{
				if (text != item.OrderNumber)
				{
					text = item.OrderNumber;
					numberOrderProcessed++;
					CS_0024_003C_003E8__locals0.startIndex = prefix + $"{indexInt++:000000}";
				}
				item.OrderNumber = CS_0024_003C_003E8__locals0.startIndex;
				continue;
			}
			break;
		}
		dataManager.DataContext.GenKeys.SingleOrDefault().CleanUp_Bookmark = indexInt;
		Helper.SubmitChangesWithCatch(dataManager.DataContext);
		return indexInt;
	}

	public List<OrderResult> GetMultipleBills(string customer, string orderType)
	{
		_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass38_0();
		CS_0024_003C_003E8__locals0.orderType = orderType;
		CS_0024_003C_003E8__locals0.customer = customer;
		if (CS_0024_003C_003E8__locals0.orderType == OrderTypes.PickUp)
		{
			return (from x in (from o in OpenOrders().ToList()
					where o.OrderType.Equals(CS_0024_003C_003E8__locals0.orderType) || o.OrderType.Equals(OrderTypes.ToGo) || o.OrderType.Equals(OrderTypes.Delivery) || o.OrderType.Equals(OrderTypes.DeliveryOnline) || o.OrderType.Equals(OrderTypes.PickUpOnline) || o.OrderType.Equals(OrderTypes.PickUp) || o.OrderType.Equals(OrderTypes.Catering)
					select new OrderResult
					{
						OrderNumber = o.OrderNumber,
						Customer = o.Customer,
						tipRecorded = o.TipRecorded,
						tipAmount = o.TipAmount,
						isPaid = o.Paid,
						CustomerInfoName = o.CustomerInfoName,
						GuestCount = o.GuestCount,
						CustomerInfo = o.CustomerInfo,
						OrderType = o.OrderType,
						OrderStatus = ((!o.DateFilled.HasValue) ? "ReceivedByKitchen" : "OrderMade"),
						SeatNum = Convert.ToInt16(o.SeatNum),
						FlagID = o.FlagID,
						DateCreated = o.DateCreated.Value,
						FulFillmentAt = o.FulfillmentAt,
						UserServed = o.UserServed,
						OrderTicket = o.OrderTicketNumber,
						TravelDistance = o.DeliveryTravelDistanceKM,
						TravelTime = o.DeliveryTravelTimeMinutes,
						DatePickup = o.DepartureTime,
						DateDelivered = o.DeliveryTime,
						StationID = o.StationID,
						OrderNotes = o.OrderNotes
					}).Distinct()
				orderby x.OrderType
				select x).ThenBy((OrderResult y) => y.CustomerInfoName).ThenBy((OrderResult z) => z.Customer).ToList();
		}
		if (CS_0024_003C_003E8__locals0.orderType.ToUpper().Equals("PAID"))
		{
			return AllPaidOrdersToday().ToList();
		}
		if (CS_0024_003C_003E8__locals0.orderType.ToUpper().Equals("ALL"))
		{
			return (from x in (from o in OpenOrders()
					where o.DateCreated.Value > DateTime.Now.AddDays(-14.0)
					select new OrderResult
					{
						OrderNumber = o.OrderNumber,
						OrderType = o.OrderType,
						Customer = o.Customer,
						tipRecorded = o.TipRecorded,
						tipAmount = o.TipAmount,
						isPaid = o.Paid,
						CustomerInfoName = o.CustomerInfoName,
						GuestCount = o.GuestCount,
						CustomerInfo = o.CustomerInfo,
						SeatNum = Convert.ToInt16(o.SeatNum),
						FlagID = o.FlagID,
						DateCreated = o.DateCreated.Value,
						FulFillmentAt = o.FulfillmentAt,
						UserServed = o.UserServed,
						OrderTicket = o.OrderTicketNumber,
						TravelDistance = o.DeliveryTravelDistanceKM,
						TravelTime = o.DeliveryTravelTimeMinutes,
						DatePickup = o.DepartureTime,
						DateDelivered = o.DeliveryTime,
						StationID = o.StationID,
						OrderNotes = o.OrderNotes
					}).Distinct()
				orderby x.OrderType
				select x).ThenBy((OrderResult y) => y.CustomerInfoName).ThenBy((OrderResult z) => z.Customer).ToList();
		}
		return (from x in (from o in OpenOrders()
				where (o.Customer == CS_0024_003C_003E8__locals0.customer || (CS_0024_003C_003E8__locals0.customer != null && o.Customer == CS_0024_003C_003E8__locals0.customer.ToUpper())) && o.OrderType == CS_0024_003C_003E8__locals0.orderType && o.DateCreated.Value > DateTime.Now.AddDays(-14.0)
				select new OrderResult
				{
					OrderNumber = o.OrderNumber,
					OrderType = o.OrderType,
					Customer = o.Customer,
					tipRecorded = o.TipRecorded,
					tipAmount = o.TipAmount,
					isPaid = o.Paid,
					CustomerInfoName = o.CustomerInfoName,
					GuestCount = o.GuestCount,
					CustomerInfo = o.CustomerInfo,
					SeatNum = Convert.ToInt16(o.SeatNum),
					FlagID = o.FlagID,
					DateCreated = o.DateCreated.Value,
					FulFillmentAt = o.FulfillmentAt,
					UserServed = o.UserServed,
					OrderTicket = o.OrderTicketNumber,
					TravelDistance = o.DeliveryTravelDistanceKM,
					TravelTime = o.DeliveryTravelTimeMinutes,
					DatePickup = o.DepartureTime,
					DateDelivered = o.DeliveryTime,
					StationID = o.StationID,
					OrderNotes = o.OrderNotes
				}).Distinct()
			orderby x.OrderType
			select x).ThenBy((OrderResult y) => y.CustomerInfoName).ThenBy((OrderResult z) => z.Customer).ToList();
	}

	public List<OrderResult> SearchOpenOrders(string query, string orderType, int daterange_filter)
	{
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0.query = query;
		CS_0024_003C_003E8__locals0.orderType = orderType;
		List<Order> source = OpenOrders(daterange_filter);
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.query))
		{
			source = source.Where((Order x) => (x.Customer != null && x.Customer.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfo != null && x.CustomerInfo.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfoName != null && x.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || x.OrderNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query) || (x.OrderTicketNumber != null && x.OrderTicketNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query))).ToList();
		}
		if (CS_0024_003C_003E8__locals0.orderType.ToUpper().Equals("ALL"))
		{
			return (from x in source.Select((Order o) => new OrderResult
				{
					OrderNumber = o.OrderNumber,
					OrderType = o.OrderType,
					Customer = o.Customer,
					tipRecorded = o.TipRecorded,
					tipAmount = o.TipAmount,
					isPaid = o.Paid,
					isCustomerNotified = o.CustomerNotified,
					CustomerInfoName = o.CustomerInfoName,
					GuestCount = o.GuestCount,
					CustomerInfo = o.CustomerInfo,
					SeatNum = Convert.ToInt16(o.SeatNum),
					FlagID = o.FlagID,
					DateCreated = o.DateCreated.Value,
					FulFillmentAt = o.FulfillmentAt,
					UserServed = o.UserServed,
					OrderTicket = o.OrderTicketNumber,
					TravelDistance = o.DeliveryTravelDistanceKM,
					TravelTime = o.DeliveryTravelTimeMinutes,
					DatePickup = o.DepartureTime,
					DateDelivered = o.DeliveryTime,
					CustomerInfoPhone = o.CustomerInfoPhone,
					OrderNotes = o.OrderNotes
				}).Distinct()
				orderby x.OrderType
				select x).ThenBy((OrderResult y) => y.CustomerInfoName).ThenBy((OrderResult z) => z.Customer).ToList();
		}
		return (from x in (from o in source
				where o.OrderType.ToUpper().Contains(CS_0024_003C_003E8__locals0.orderType)
				select new OrderResult
				{
					OrderNumber = o.OrderNumber,
					Customer = o.Customer,
					tipRecorded = o.TipRecorded,
					tipAmount = o.TipAmount,
					isPaid = o.Paid,
					isCustomerNotified = o.CustomerNotified,
					CustomerInfoName = o.CustomerInfoName,
					GuestCount = o.GuestCount,
					CustomerInfo = o.CustomerInfo,
					OrderType = o.OrderType,
					OrderStatus = ((!o.DateFilled.HasValue) ? "ReceivedByKitchen" : "OrderMade"),
					SeatNum = Convert.ToInt16(o.SeatNum),
					FlagID = o.FlagID,
					DateCreated = o.DateCreated.Value,
					FulFillmentAt = o.FulfillmentAt,
					UserServed = o.UserServed,
					OrderTicket = o.OrderTicketNumber,
					TravelDistance = o.DeliveryTravelDistanceKM,
					TravelTime = o.DeliveryTravelTimeMinutes,
					DatePickup = o.DepartureTime,
					DateDelivered = o.DeliveryTime,
					CustomerInfoPhone = o.CustomerInfoPhone,
					OrderNotes = o.OrderNotes
				}).Distinct()
			orderby x.DateCreated
			select x).ThenBy((OrderResult y) => y.CustomerInfoName).ThenBy((OrderResult z) => z.Customer).ToList();
	}

	public void SaveTotals(string orderNumber)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		List<Order> list = (from o in OpenOrders()
			where o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber
			select o).ToList();
		List<Item> list2 = new List<Item>();
		Order order = list.FirstOrDefault();
		using (List<Order>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass40_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass40_1();
				CS_0024_003C_003E8__locals1.order = enumerator.Current;
				Item item = _dataContext.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals1.order.ItemID).FirstOrDefault();
				item.ItemPrice = CS_0024_003C_003E8__locals1.order.ItemSellPrice;
				item.InventoryCount = Convert.ToDecimal(CS_0024_003C_003E8__locals1.order.Qty);
				item.SortOrder = (short)CS_0024_003C_003E8__locals1.order.SortOrder;
				item.Active = !CS_0024_003C_003E8__locals1.order.Void;
				item.Temp = CS_0024_003C_003E8__locals1.order.OrderId.ToString();
				list2.Add(item);
			}
		}
		SaveOrder(list2, CS_0024_003C_003E8__locals0.orderNumber, order.Customer, order.OrderType, 0, "SAVED ORDER", order.TenderAmount, order.TenderChange, isPaid: false, "", "", "", "", 1, isDiscount: false, "", 0, null, null, 0, null, "", GratuityRemoved: false, 0);
	}

	public void UpdateOrderTable(string orderNumber, string tableName, string orderType, int guestCount, string seatNum = null)
	{
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		foreach (Order item in _dataContext.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).ToList())
		{
			item.Customer = tableName;
			item.OrderType = orderType;
			item.GuestCount = guestCount;
			if (seatNum != null)
			{
				item.SeatNum = seatNum;
			}
		}
		_dataContext.SubmitChanges();
	}

	public void SubmitChanges()
	{
		Helper.SubmitChangesWithCatch(_dataContext);
	}

	public static List<StationTipObject> GetListStationsTips(string tipDesc, decimal subtotal, decimal TotalTip)
	{
		GClass6 gClass = new GClass6();
		List<StationTipObject> list = new List<StationTipObject>();
		if (!string.IsNullOrEmpty(tipDesc))
		{
			string[] array = tipDesc.Split('|');
			foreach (string text in array)
			{
				_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_0();
				CS_0024_003C_003E8__locals0.TipName = text.Split('=')[0];
				decimal num = Convert.ToDecimal(text.Split('=')[1]);
				decimal num2 = default(decimal);
				if (text.Split('=').Length == 3)
				{
					num2 = Convert.ToDecimal(text.Split('=')[2]);
				}
				CustomTipSharing customTipSharing = gClass.CustomTipSharings.Where((CustomTipSharing a) => a.TipName == CS_0024_003C_003E8__locals0.TipName).FirstOrDefault();
				if (customTipSharing == null)
				{
					continue;
				}
				if (text.Split('=').Length != 3)
				{
					if (customTipSharing.TipShareType == 1)
					{
						num2 = num / TotalTip;
					}
					else if (customTipSharing.TipShareType == 2)
					{
						num2 = num / subtotal;
					}
					num2 = Math.Round(Math.Round(num2 * 100m, 2) * 20m, MidpointRounding.AwayFromZero) / 20m;
				}
				list.Add(new StationTipObject
				{
					StatioName = CS_0024_003C_003E8__locals0.TipName,
					TipAmount = num,
					TipPercentage = Math.Round(num2, 2)
				});
			}
		}
		return list;
	}

	public static decimal GetStationsTipAmount(string tipDesc)
	{
		new GClass6();
		decimal result = default(decimal);
		if (!string.IsNullOrEmpty(tipDesc))
		{
			string[] array = tipDesc.Split('|');
			for (int i = 0; i < array.Length; i++)
			{
				decimal num = Convert.ToDecimal(array[i].Split('=')[1]);
				result += num;
			}
		}
		return result;
	}

	public static decimal GetTotalAmountInTil()
	{
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass45_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.lastSafeDropClearingDate = (from a in gClass.Payouts
			where a.Reason == PayoutTypes.SafeDropClearing
			orderby a.DateCreated descending
			select a).FirstOrDefault()?.DateCreated ?? DateTime.Now.Date;
		List<string> list = (from a in gClass.Orders
			where a.Paid == true && a.DateRefunded.HasValue == false && a.Void == false && a.DatePaid >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate
			group a by a.OrderNumber into a
			select a.FirstOrDefault().PaymentMethods).ToList();
		decimal result = default(decimal);
		foreach (string item in list)
		{
			result += (from a in PaymentTypeMethods.GetPaymentTypes(item)
				where a.PaymentTypeName.ToUpper() == "CASH"
				select a).Sum((ProcessorPaymentType a) => a.Amount);
		}
		decimal num = gClass.Payouts.Where((Payout a) => a.Reason == PayoutTypes.SafeDrop && a.DateCreated >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate).ToList().Sum((Payout a) => a.Amount);
		result -= num;
		decimal num2 = gClass.Payouts.Where((Payout a) => a.Reason == PayoutTypes.ReverseSafeDrop && a.DateCreated >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate).ToList().Sum((Payout a) => a.Amount);
		result += num2;
		foreach (Refund item2 in gClass.Refunds.Where((Refund a) => a.DateCreated >= CS_0024_003C_003E8__locals0.lastSafeDropClearingDate).ToList())
		{
			result -= item2.AmountRefunded;
		}
		return result;
	}

	public static bool GetIsOrderPaid(string orderNumber)
	{
		_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		return new GClass6().Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault()?.Paid ?? false;
	}

	public List<usp_ClosingTotalsResult> getTotalPaymentsByMethod(List<Order> orders)
	{
		List<usp_ClosingTotalsResult> list = new List<usp_ClosingTotalsResult>();
		string[] array = new string[20];
		string[] array2 = new string[2];
		foreach (var item in (from a in orders
			where a.PaymentMethods != null
			group a by a.OrderNumber into a
			select new
			{
				PaymentMethods = a.First().PaymentMethods,
				Total = a.Sum((Order b) => b.Total)
			}).ToList())
		{
			if (!string.IsNullOrEmpty(item.PaymentMethods))
			{
				array = item.PaymentMethods.Split(Convert.ToChar("|"));
				if (array.Count() <= 0)
				{
					continue;
				}
				string[] array3 = array;
				foreach (string text in array3)
				{
					if (!string.IsNullOrEmpty(text) && text.Contains("="))
					{
						array2 = text.Split(Convert.ToChar("="));
						if (array2[0] == "VISA")
						{
							array2[0] = "Visa";
						}
						if (array2[0].ToUpper() == "MASTERCARD")
						{
							array2[0] = "Mastercard";
						}
						if (array2[0].ToUpper() == "INTERAC")
						{
							array2[0] = "Debit";
						}
						if (decimal.TryParse(array2[1], out var result))
						{
							list.Add(new usp_ClosingTotalsResult
							{
								Name = array2[0],
								Total = result
							});
						}
					}
				}
			}
			else if (string.IsNullOrEmpty(item.PaymentMethods) && item.Total < 0m)
			{
				list.Add(new usp_ClosingTotalsResult
				{
					Name = "CASH",
					Total = item.Total
				});
			}
		}
		return (from a in list
			group a by a.Name into p
			select new usp_ClosingTotalsResult
			{
				Name = p.Key,
				Total = p.Sum((usp_ClosingTotalsResult w) => w.Total),
				Qty = p.Count()
			}).ToList();
	}

	public static bool CheckOrderIsPaid(string orderNumber, string orderType)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.orderNumber) && !(orderType == OrderTypes.Catering))
		{
			if (new GClass6().Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && a.Paid == true && a.Void == false).Count() > 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static decimal ComputeAutoGratuity(string orderNumber, string cultureName)
	{
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		GClass6 gClass = new GClass6();
		IQueryable<Order> source = gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber);
		decimal num = default(decimal);
		try
		{
			num = source.Where((Order a) => a.Void == false).Sum((Order a) => a.SubTotal);
		}
		catch
		{
		}
		if (source.FirstOrDefault() != null)
		{
			string orderType = source.FirstOrDefault().OrderType;
			if (orderType == OrderTypes.DeliveryOnline || orderType == OrderTypes.PickUpOnline || orderType == OrderTypes.TakeOutOnline || orderType == OrderTypes.PickUpCurbsideOnline || orderType == OrderTypes.DineInOnline)
			{
				return 0m;
			}
		}
		string text = SettingsHelper.GetSettingValueByKey("auto_gratuity_percentage");
		if (cultureName.Equals("fr-CA"))
		{
			text = text.Replace(".", ",");
		}
		decimal num2 = Math.Round(num * (Convert.ToDecimal(text, Thread.CurrentThread.CurrentCulture) / 100m), 2);
		foreach (Order item in source.ToList())
		{
			item.TipRecorded = true;
			item.TipAmount = ((num2 > 0m) ? num2 : 0m);
			item.Synced = false;
		}
		Helper.SubmitChangesWithCatch(gClass);
		return num2;
	}

	public static void RemoveAutoGratuity(string orderNumber)
	{
		_003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		GClass6 gClass = new GClass6();
		foreach (Order item in gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).ToList())
		{
			item.TipRecorded = false;
			item.TipAmount = 0m;
			item.Synced = false;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static Order CreateTransactionFeeOrder(decimal transactionFee, string orderNumber, string orderType, string customer, string customerInfo, string customerInfoName, string paymentMethods, short employeeID, int? terminalID, int guestCount)
	{
		return new Order
		{
			OrderId = Guid.NewGuid(),
			OrderType = orderType,
			ItemID = -100,
			ItemName = "Transaction Fee",
			DatePaid = DateTime.Now,
			DateFilled = DateTime.Now,
			DateCleared = DateTime.Now,
			DateCreated = DateTime.Now,
			Customer = customer,
			CustomerInfo = customerInfo,
			CustomerInfoName = customerInfoName,
			PaymentMethods = paymentMethods,
			ItemCost = transactionFee,
			Notified = true,
			Qty = 1m,
			UserCreated = employeeID,
			StationID = null,
			TerminalID = terminalID,
			OrderNumber = orderNumber,
			ItemPrice = transactionFee,
			ItemSellPrice = transactionFee,
			TaxTotal = 0m,
			SubTotal = transactionFee,
			Total = transactionFee,
			SeatNum = "1",
			ComboID = 0,
			Paid = true,
			GuestCount = guestCount,
			Synced = false,
			ItemCourse = ItemCourses.Uncategorized
		};
	}

	public static decimal GetCoinSystemRoundedValue(decimal val)
	{
		if (SettingsHelper.GetSettingValueByKey("coin_system") == "OFF")
		{
			return val;
		}
		int num = (int)(val * 100m);
		int num2 = num % 10;
		switch (Math.Abs(num2))
		{
		default:
			return val;
		case 8:
		case 9:
		{
			int num4 = 10;
			if (num2 < 0)
			{
				num4 = -10;
			}
			return (decimal)(num - num2 + num4) / 100m;
		}
		case 3:
		case 4:
		case 6:
		case 7:
		{
			int num3 = 5;
			if (num2 < 0)
			{
				num3 = -5;
			}
			return (decimal)(num - num2 + num3) / 100m;
		}
		case 1:
		case 2:
			return (decimal)(num - num2) / 100m;
		}
	}

	public static void ConfirmOnlineOrderFlag(string OrderNumber)
	{
		_003C_003Ec__DisplayClass53_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass53_0();
		CS_0024_003C_003E8__locals0.OrderNumber = OrderNumber;
		GClass6 gClass = new GClass6();
		foreach (Order item in gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.OrderNumber).ToList())
		{
			item.FlagID = 0;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void LogOrderAudit(string OrderNumber, string Action)
	{
		GClass6 gClass = new GClass6();
		OrderAuditsLog entity = new OrderAuditsLog
		{
			OrderNumber = OrderNumber,
			Comment = Action,
			DateCreated = DateTime.Now,
			Synced = false
		};
		gClass.OrderAuditsLogs.InsertOnSubmit(entity);
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static string UpdateDiscountFromDiscountDescription(string DiscountDesc, string DiscountType, decimal value)
	{
		string text = "";
		if (DiscountDesc == null || !DiscountDesc.Contains(DiscountType))
		{
			text = ((!(value > 0m)) ? DiscountDesc : (DiscountDesc + DiscountType + "=" + value.ToString("0.00#", Thread.CurrentThread.CurrentCulture) + "|"));
		}
		else if (!string.IsNullOrEmpty(DiscountDesc))
		{
			string[] array = DiscountDesc.Split('|');
			foreach (string text2 in array)
			{
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				if (text2.Contains(DiscountType))
				{
					if (value > 0m)
					{
						text = text + text2.Split('=')[0] + "=" + value.ToString("0.00#", Thread.CurrentThread.CurrentCulture) + "|";
					}
				}
				else
				{
					text = text + text2 + "|";
				}
			}
		}
		return text;
	}

	public static decimal GetDiscountFromDiscountDescription(string DiscountDesc, string DiscountType)
	{
		if (!string.IsNullOrEmpty(DiscountDesc))
		{
			string[] array = DiscountDesc.Split('|');
			foreach (string text in array)
			{
				if (text.Contains(DiscountType))
				{
					return Convert.ToDecimal(text.Split('=')[1]);
				}
			}
		}
		return 0m;
	}
}
