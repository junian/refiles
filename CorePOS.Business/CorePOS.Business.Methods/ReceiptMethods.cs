using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class ReceiptMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_1
	{
		public string displayInstructionSetting;

		public string displayOptionSetting;

		public _003C_003Ec__DisplayClass0_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal ReceiptOrder _003CGetOrderToPrintReceipt_003Eb__9(Order ro)
		{
			return new ReceiptOrder
			{
				ComboID = ro.ComboID,
				Customer = ro.Customer,
				CustomerID = ro.CustomerID,
				CustomerInfo = ro.CustomerInfo,
				CustomerInfoName = ro.CustomerInfoName,
				DateCreated = ro.DateCreated,
				DatePaid = ro.DatePaid,
				DateRefunded = ro.DateRefunded,
				Discount = ro.Discount,
				DiscountDesc = ro.DiscountDesc,
				DiscountReason = ro.DiscountReason,
				GroupName = ro.GroupName,
				Instructions = ((displayInstructionSetting == "ON") ? ro.Instructions : ""),
				IsDiscount = ro.IsDiscount,
				ItemID = ro.ItemID,
				ItemCost = ro.ItemCost,
				ItemName = ro.ItemName,
				ItemPrice = ro.ItemPrice,
				ItemSellPrice = ro.ItemSellPrice,
				Options = ((displayOptionSetting == "ON") ? ro.Options : ""),
				OrderId = ro.OrderId,
				OrderNumber = ro.OrderNumber,
				OrderTicketNumber = ro.OrderTicketNumber,
				OrderType = ro.OrderType,
				Paid = ro.Paid,
				PaymentMethods = ro.PaymentMethods,
				Qty = ro.Qty,
				Refunds = ro.Refunds,
				SubTotal = ro.SubTotal,
				TaxChangeReason = ro.TaxChangeReason,
				TaxDesc = ro.TaxDesc,
				TaxTotal = ro.TaxTotal,
				TenderAmount = ro.TenderAmount,
				TenderChange = ro.TenderChange,
				TipAmount = ro.TipAmount,
				TipRecorded = ro.TipRecorded,
				Total = ro.Total,
				UserCreated = ro.UserCreated,
				UserServed = ro.UserServed,
				UserCashout = ro.UserCashout,
				Void = ro.Void,
				DiscountReasonItem = ro.DiscountReasonItem,
				OrderDiscountWithoutOnSale = ((!(ro.Discount > 0m) || !(ro.DiscountReason != "") || !(ro.DiscountReasonItem != "")) ? 0m : (ro.Discount - ro.DiscountOnSaleItem))
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_2
	{
		public List<int> allItemIds;

		public _003C_003Ec__DisplayClass0_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_3
	{
		public ReceiptOrder order;

		public _003C_003Ec__DisplayClass0_3()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CGetOrderToPrintReceipt_003Eb__14(ItemsInItem x)
		{
			return x.ParentItemID == order.ItemID;
		}

		internal bool _003CGetOrderToPrintReceipt_003Eb__15(Item x)
		{
			return x.ItemID == order.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string refundNumber;

		public List<Guid> refunds;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string refundNumber;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public DateTime end;

		public DateTime start;

		public int EmployeeId;

		public int TerminalId;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CParseDayEndTotals_003Eb__3(Order a)
		{
			return a.TerminalID == TerminalId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public _003C_003Ef__AnonymousType11<string, decimal, DateTime?, DateTime?, string, decimal, string, string> order;

		public _003C_003Ec__DisplayClass5_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CParseDayEndTotals_003Eb__10(Order a)
		{
			return a.OrderNumber == order.OrderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public DateTime end;

		public DateTime start;

		public int EmployeeId;

		public int TerminalId;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CParseDayEndTaxTotals_003Eb__1(Order a)
		{
			if (a.UserCashout.HasValue)
			{
				return a.UserCashout.Value == EmployeeId;
			}
			return false;
		}

		internal bool _003CParseDayEndTaxTotals_003Eb__3(Order a)
		{
			return a.TerminalID == TerminalId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string orderNumber;

		public string refundNumber;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public static List<ReceiptOrder> GetOrderToPrintReceipt(string orderNumber)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		int num = 3;
		bool flag = false;
		while (num > 0 && !flag)
		{
			try
			{
				_003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass0_1();
				CS_0024_003C_003E8__locals2.displayOptionSetting = SettingsHelper.GetSettingValueByKey("display_option");
				CS_0024_003C_003E8__locals2.displayInstructionSetting = SettingsHelper.GetSettingValueByKey("display_instruction");
				string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_display_child_items");
				using GClass6 gClass = new GClass6();
				_003C_003Ec__DisplayClass0_2 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass0_2();
				gClass.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
				List<Order> list = (from o in gClass.Orders
					where o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && (o.Void == false || (o.Void == true && o.DateRefunded.HasValue) || (o.Void == true && o.DatePaid.HasValue))
					select o into a
					orderby a.DateCreated
					select a).ToList();
				if (list.Count == 0)
				{
					list = (from o in gClass.Orders
						where o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber
						select o into a
						orderby a.DateCreated
						select a).ToList();
				}
				CS_0024_003C_003E8__locals3.allItemIds = list.Select((Order a) => a.ItemID).ToList();
				if (CS_0024_003C_003E8__locals2.displayOptionSetting == "OFF")
				{
					list = list.Where((Order o) => o.ItemIdentifier == "MainItem" || o.ItemIdentifier == "ChildItem" || (o.ItemIdentifier == "OptionItem" && o.ItemSellPrice > 0m)).ToList();
				}
				if (settingValueByKey == "OFF")
				{
					list = list.Where((Order o) => o.ItemIdentifier == "MainItem" || o.ItemIdentifier == "OptionItem" || (o.ItemIdentifier == "ChildItem" && o.ItemSellPrice > 0m)).ToList();
				}
				if (list.Count == 0 && (CS_0024_003C_003E8__locals2.displayOptionSetting == "OFF" || settingValueByKey == "OFF"))
				{
					list = (from o in gClass.Orders
						where o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && (o.Void == false || (o.Void == true && o.DateRefunded.HasValue))
						select o into a
						orderby a.DateCreated
						select a).ToList();
				}
				List<ReceiptOrder> list2 = (from ro in list
					select new ReceiptOrder
					{
						ComboID = ro.ComboID,
						Customer = ro.Customer,
						CustomerID = ro.CustomerID,
						CustomerInfo = ro.CustomerInfo,
						CustomerInfoName = ro.CustomerInfoName,
						DateCreated = ro.DateCreated,
						DatePaid = ro.DatePaid,
						DateRefunded = ro.DateRefunded,
						Discount = ro.Discount,
						DiscountDesc = ro.DiscountDesc,
						DiscountReason = ro.DiscountReason,
						GroupName = ro.GroupName,
						Instructions = ((CS_0024_003C_003E8__locals2.displayInstructionSetting == "ON") ? ro.Instructions : ""),
						IsDiscount = ro.IsDiscount,
						ItemID = ro.ItemID,
						ItemCost = ro.ItemCost,
						ItemName = ro.ItemName,
						ItemPrice = ro.ItemPrice,
						ItemSellPrice = ro.ItemSellPrice,
						Options = ((CS_0024_003C_003E8__locals2.displayOptionSetting == "ON") ? ro.Options : ""),
						OrderId = ro.OrderId,
						OrderNumber = ro.OrderNumber,
						OrderTicketNumber = ro.OrderTicketNumber,
						OrderType = ro.OrderType,
						Paid = ro.Paid,
						PaymentMethods = ro.PaymentMethods,
						Qty = ro.Qty,
						Refunds = ro.Refunds,
						SubTotal = ro.SubTotal,
						TaxChangeReason = ro.TaxChangeReason,
						TaxDesc = ro.TaxDesc,
						TaxTotal = ro.TaxTotal,
						TenderAmount = ro.TenderAmount,
						TenderChange = ro.TenderChange,
						TipAmount = ro.TipAmount,
						TipRecorded = ro.TipRecorded,
						Total = ro.Total,
						UserCreated = ro.UserCreated,
						UserServed = ro.UserServed,
						UserCashout = ro.UserCashout,
						Void = ro.Void,
						DiscountReasonItem = ro.DiscountReasonItem,
						OrderDiscountWithoutOnSale = ((!(ro.Discount > 0m) || !(ro.DiscountReason != "") || !(ro.DiscountReasonItem != "")) ? 0m : (ro.Discount - ro.DiscountOnSaleItem))
					} into a
					orderby a.ComboID
					select a).ThenBy((ReceiptOrder x) => (!x.LastDateModified.HasValue) ? x.DateCreated : x.LastDateModified).ToList();
				List<ItemsInItem> source = gClass.ItemsInItems.Where((ItemsInItem x) => CS_0024_003C_003E8__locals3.allItemIds.Contains(x.ParentItemID.Value)).ToList();
				List<Item> source2 = gClass.Items.Where((Item x) => CS_0024_003C_003E8__locals3.allItemIds.Contains(x.ItemID)).ToList();
				using (List<ReceiptOrder>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass0_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass0_3();
						CS_0024_003C_003E8__locals1.order = enumerator.Current;
						if (CS_0024_003C_003E8__locals1.order.ComboID > 0)
						{
							if (source.Where((ItemsInItem x) => x.ParentItemID == CS_0024_003C_003E8__locals1.order.ItemID).ToList().Count == 0)
							{
								CS_0024_003C_003E8__locals1.order.ItemName = CS_0024_003C_003E8__locals1.order.ItemName;
							}
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Options))
							{
								ReceiptOrder order = CS_0024_003C_003E8__locals1.order;
								order.ItemName = order.ItemName + " => " + CS_0024_003C_003E8__locals1.order.Options;
							}
						}
						if (CS_0024_003C_003E8__locals1.order.Qty < 1m)
						{
							Item item = source2.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.order.ItemID).FirstOrDefault();
							if (item != null && item.UOM.isFractional)
							{
								CS_0024_003C_003E8__locals1.order.QtyString = CS_0024_003C_003E8__locals1.order.Qty.ToString();
								CS_0024_003C_003E8__locals1.order.QtyString = MathHelper.RemoveTrailingZeros(CS_0024_003C_003E8__locals1.order.QtyString);
							}
							else
							{
								CS_0024_003C_003E8__locals1.order.QtyString = MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals1.order.Qty);
							}
						}
						else
						{
							CS_0024_003C_003E8__locals1.order.QtyString = CS_0024_003C_003E8__locals1.order.Qty.ToString();
							CS_0024_003C_003E8__locals1.order.QtyString = MathHelper.RemoveTrailingZeros(CS_0024_003C_003E8__locals1.order.QtyString);
						}
					}
				}
				return list2.ToList();
			}
			catch (SqlException ex)
			{
				if (ex.Number != 1205)
				{
					throw;
				}
				Thread.Sleep(1000);
				num--;
				if (num == 0)
				{
					throw;
				}
			}
		}
		return new List<ReceiptOrder>();
	}

	public static List<Order> GetRefundOrderToPrintReceipt(string refundNumber)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.refundNumber = refundNumber;
		DataManager dataManager = new DataManager();
		CS_0024_003C_003E8__locals0.refunds = (from r in dataManager.DataContext.Refunds
			where r.RefundNumber == CS_0024_003C_003E8__locals0.refundNumber
			select r into o
			select o.OrderId).ToList();
		return (from o in dataManager.DataContext.Orders
			where CS_0024_003C_003E8__locals0.refunds.Contains(o.OrderId)
			select o into x
			orderby x.DateCreated
			select x).ToList();
	}

	public static List<RefundDS> GetRefundDS(string refundNumber)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.refundNumber = refundNumber;
		GClass6 gClass = new GClass6();
		var queryable = from tblRefunds in gClass.Refunds
			join tblOrders in gClass.Orders on tblRefunds.OrderId equals tblOrders.OrderId
			where tblRefunds.RefundNumber == CS_0024_003C_003E8__locals0.refundNumber
			orderby tblOrders.DateCreated
			select new { tblRefunds, tblOrders };
		List<RefundDS> list = new List<RefundDS>();
		foreach (var item2 in queryable)
		{
			RefundDS item = new RefundDS
			{
				Qty = item2.tblRefunds.Qty,
				ItemName = item2.tblOrders.ItemName,
				ItemSellPrice = item2.tblRefunds.AmountRefunded - item2.tblOrders.TaxTotal,
				RefundPaymentMethod = item2.tblRefunds.PaymentMethod,
				TipAmount = item2.tblRefunds.Order.TipAmount
			};
			list.Add(item);
		}
		return list;
	}

	public static List<CompanySetup> GetCompany()
	{
		return new DataManager().GetFirstCompany();
	}

	public static List<Tax> GetTaxRate()
	{
		return new DataManager().GetTax();
	}

	public static void ParseDayEndTotals(DateTime start, DateTime end, int EmployeeId, int TerminalId)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.end = end;
		CS_0024_003C_003E8__locals0.start = start;
		CS_0024_003C_003E8__locals0.EmployeeId = EmployeeId;
		CS_0024_003C_003E8__locals0.TerminalId = TerminalId;
		GClass6 gClass = new GClass6();
		gClass.usp_TruncateTemp();
		if (CS_0024_003C_003E8__locals0.start > CS_0024_003C_003E8__locals0.end)
		{
			CS_0024_003C_003E8__locals0.end = CS_0024_003C_003E8__locals0.end.AddDays(1.0);
		}
		OrderMethods orderMethods = new OrderMethods();
		List<Order> source = ((CS_0024_003C_003E8__locals0.EmployeeId == 0) ? gClass.Orders.Where((Order o) => ((o.DatePaid <= CS_0024_003C_003E8__locals0.end && o.DatePaid >= CS_0024_003C_003E8__locals0.start && o.Paid == true) || (o.DateCreated <= CS_0024_003C_003E8__locals0.end && o.DateCreated >= CS_0024_003C_003E8__locals0.start && o.PaymentMethods.Contains("=") && o.Paid == false)) && ((o.Void == false && o.DateRefunded.HasValue == false) || (o.Void == true && o.DateRefunded.HasValue == true))).ToList() : gClass.Orders.Where((Order o) => ((o.DatePaid <= CS_0024_003C_003E8__locals0.end && o.DatePaid >= CS_0024_003C_003E8__locals0.start && o.Paid == true) || (o.DateCreated <= CS_0024_003C_003E8__locals0.end && o.DateCreated >= CS_0024_003C_003E8__locals0.start && o.PaymentMethods.Contains("=") && o.Paid == false)) && o.UserCashout.HasValue && o.UserCashout.Value == CS_0024_003C_003E8__locals0.EmployeeId && ((o.Void == false && o.DateRefunded.HasValue == false) || (o.Void == true && o.DateRefunded.HasValue == true))).ToList());
		if (CS_0024_003C_003E8__locals0.TerminalId != -1)
		{
			source = ((CS_0024_003C_003E8__locals0.TerminalId != 0) ? source.Where((Order a) => a.TerminalID == CS_0024_003C_003E8__locals0.TerminalId).ToList() : source.Where((Order a) => !a.TerminalID.HasValue).ToList());
		}
		var list = (from a in source
			group a by a.OrderNumber into a
			select new
			{
				OrderNumber = a.Key,
				Totals = a.Sum((Order b) => b.Total),
				DateCreated = a.FirstOrDefault().DateCreated,
				DatePaid = a.FirstOrDefault().DatePaid,
				PaymentMethods = a.First().PaymentMethods,
				TipAmount = a.OrderByDescending((Order b) => b.TipAmount).FirstOrDefault().TipAmount,
				OrderType = a.First().OrderType,
				TipDesc = a.First().TipDesc
			} into a
			orderby a.DatePaid descending, a.OrderNumber descending
			select a).ToList();
		string[] array = new string[20];
		string[] array2 = new string[2];
		char c = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
		using var enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
			CS_0024_003C_003E8__locals1.order = enumerator.Current;
			if (CS_0024_003C_003E8__locals1.order == null)
			{
				continue;
			}
			if (CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains("CASH") && CS_0024_003C_003E8__locals1.order.TipAmount > 0m)
			{
				Console.Write("TEST");
			}
			array = CS_0024_003C_003E8__locals1.order.PaymentMethods.Split(Convert.ToChar("|"));
			List<Temp> list2 = new List<Temp>();
			bool flag = false;
			if (CS_0024_003C_003E8__locals1.order.OrderNumber.Contains("WEB") && (CS_0024_003C_003E8__locals1.order.DatePaid.Value - CS_0024_003C_003E8__locals1.order.DateCreated.Value).Seconds < 5)
			{
				flag = true;
			}
			decimal num = default(decimal);
			if (array.Length != 0)
			{
				string[] array3 = array;
				foreach (string text in array3)
				{
					if (string.IsNullOrEmpty(text.Trim()))
					{
						break;
					}
					array2 = text.Split(Convert.ToChar("="));
					if (array2.Length != 2)
					{
						continue;
					}
					Temp temp = new Temp();
					temp.Name = (flag ? ("ONLINE " + array2[0].ToUpper()) : array2[0].ToUpper());
					if (array2[0].Contains("[") && array2[0].Contains("]"))
					{
						DateTime dateTime = DateTime.Parse(Regex.Match(array2[0], "\\[([^)]*)\\]").Groups[1].Value);
						if (!(dateTime <= CS_0024_003C_003E8__locals0.end.Date) || !(dateTime >= CS_0024_003C_003E8__locals0.start.Date))
						{
							continue;
						}
						temp.Name = Regex.Replace(array2[0], "\\[.*\\]", "").Trim();
					}
					if (c == ',')
					{
						temp.Value = Convert.ToDecimal(array2[1].Replace('.', c), Thread.CurrentThread.CurrentCulture);
					}
					else
					{
						temp.Value = Convert.ToDecimal(array2[1].Replace(',', c), Thread.CurrentThread.CurrentCulture);
					}
					num += temp.Value;
					list2.Add(temp);
				}
			}
			List<usp_ClosingTotalsResult> totalPaymentsByMethod = orderMethods.getTotalPaymentsByMethod(source.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.order.OrderNumber).ToList());
			if (CS_0024_003C_003E8__locals1.order.TipAmount > 0m || Math.Round(CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount, 2) < totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value))
			{
				decimal num2 = default(decimal);
				bool flag2 = false;
				decimal num3 = CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount;
				decimal? num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total);
				if ((num3 > num4.GetValueOrDefault()) & num4.HasValue)
				{
					decimal totals = CS_0024_003C_003E8__locals1.order.Totals;
					num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total);
					if ((totals < num4.GetValueOrDefault()) & num4.HasValue)
					{
						num2 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount);
						if (Math.Abs(num2) >= 0.03m)
						{
							num2 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - CS_0024_003C_003E8__locals1.order.Totals;
						}
					}
					else if (CS_0024_003C_003E8__locals1.order.Totals != totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value))
					{
						num2 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount);
						if (Math.Abs(num2) >= 0.03m)
						{
							num2 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - CS_0024_003C_003E8__locals1.order.Totals;
						}
					}
				}
				else if (totalPaymentsByMethod.Count > 0)
				{
					decimal num5 = CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount;
					num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total);
					if ((num5 < num4.GetValueOrDefault()) & num4.HasValue)
					{
						num2 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount);
						flag2 = true;
					}
				}
				Temp temp2 = new Temp();
				if ((CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount > num && CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains("CASH")) || (CS_0024_003C_003E8__locals1.order.Totals == num && CS_0024_003C_003E8__locals1.order.TipAmount > 0m) || (CS_0024_003C_003E8__locals1.order.Totals + CS_0024_003C_003E8__locals1.order.TipAmount == num && CS_0024_003C_003E8__locals1.order.TipAmount > 0m && CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains("CASH")))
				{
					temp2.Name = "Tips: Cash";
					if (Math.Abs(num2) < 0.03m || flag2)
					{
						temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount + num2;
					}
					else
					{
						temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount;
					}
				}
				else
				{
					temp2.Name = "Tips: Other";
					if (Math.Abs(num2) < 0.03m || flag2)
					{
						temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount + num2;
					}
					else if (Math.Abs(num2) > 0.03m)
					{
						decimal discountFromDiscountDescription = OrderMethods.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.order.TipDesc, TipTypes.Cash);
						if (discountFromDiscountDescription > 0m)
						{
							temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount - discountFromDiscountDescription;
							Temp temp3 = new Temp();
							temp3.Name = "Tips: Cash";
							temp3.Value = discountFromDiscountDescription;
							list2.Add(temp3);
						}
						else
						{
							temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount;
						}
					}
					else
					{
						temp2.Value = CS_0024_003C_003E8__locals1.order.TipAmount;
					}
				}
				list2.Add(temp2);
			}
			gClass.Temps.InsertAllOnSubmit(list2);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static void ParseDayEndTaxTotals(DateTime start, DateTime end, int EmployeeId, int TerminalId)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.end = end;
		CS_0024_003C_003E8__locals0.start = start;
		CS_0024_003C_003E8__locals0.EmployeeId = EmployeeId;
		CS_0024_003C_003E8__locals0.TerminalId = TerminalId;
		GClass6 gClass = new GClass6();
		gClass.usp_TruncateTemp();
		if (CS_0024_003C_003E8__locals0.start > CS_0024_003C_003E8__locals0.end)
		{
			CS_0024_003C_003E8__locals0.end = CS_0024_003C_003E8__locals0.end.AddDays(1.0);
		}
		new OrderMethods();
		List<Order> source = gClass.Orders.Where((Order o) => o.TaxTotal > 0m && o.DatePaid.HasValue && o.DatePaid <= CS_0024_003C_003E8__locals0.end && o.DatePaid >= CS_0024_003C_003E8__locals0.start && o.Paid == true && ((o.Void == false && o.DateRefunded.HasValue == false) || (o.Void == true && o.DateRefunded.HasValue == true))).ToList();
		if (CS_0024_003C_003E8__locals0.EmployeeId != 0)
		{
			source = source.Where((Order a) => a.UserCashout.HasValue && a.UserCashout.Value == CS_0024_003C_003E8__locals0.EmployeeId).ToList();
		}
		if (CS_0024_003C_003E8__locals0.TerminalId != -1)
		{
			source = ((CS_0024_003C_003E8__locals0.TerminalId != 0) ? source.Where((Order a) => a.TerminalID == CS_0024_003C_003E8__locals0.TerminalId).ToList() : source.Where((Order a) => !a.TerminalID.HasValue).ToList());
		}
		string[] array = new string[2];
		char c = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
		foreach (Order item in source.OrderBy((Order x) => x.DatePaid))
		{
			string[] array2 = item.TaxDesc.Split(Convert.ToChar("|"));
			List<Temp> list = new List<Temp>();
			string[] array3 = array2;
			foreach (string text in array3)
			{
				if (!string.IsNullOrEmpty(text.Trim()))
				{
					array = text.Split(Convert.ToChar(":"));
					Temp temp = new Temp();
					temp.Name = array[0].ToUpper();
					if (c == ',')
					{
						temp.Value = Convert.ToDecimal(array[1].Replace('.', c), Thread.CurrentThread.CurrentCulture);
					}
					else
					{
						temp.Value = Convert.ToDecimal(array[1].Replace(',', c), Thread.CurrentThread.CurrentCulture);
					}
					list.Add(temp);
				}
			}
			gClass.Temps.InsertAllOnSubmit(list);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static List<TransactionReceipt> GetTransactionReceipts(string orderNumber, string refundNumber)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		CS_0024_003C_003E8__locals0.refundNumber = refundNumber;
		return (from x in new DataManager().DataContext.TransactionReceipts
			where x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.RefundNumber == CS_0024_003C_003E8__locals0.refundNumber
			select x into y
			orderby y.DateCreated descending
			select y).ToList();
	}

	public ReceiptMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
