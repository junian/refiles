using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class OrderHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public PrintToStationOrderObject order;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public int numOfItems;

		public OrderHelper _003C_003E4__this;

		public string orderNumber;

		public string orderType;

		public string customerInfoName;

		public string customer;

		public string employeeName;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003COrderPrintMadeCheck_003Eb__0()
		{
			try
			{
				_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_1();
				MemoryLoadedData.isChitPrinting = true;
				MemoryLoadedObjects.chitPrintSelfCheck_running = true;
				if (numOfItems < 3)
				{
					numOfItems = 3;
				}
				if (numOfItems * 100 < 5000)
				{
					Thread.Sleep(numOfItems * 100);
				}
				else
				{
					Thread.Sleep(5000);
				}
				GClass6 gClass = new GClass6();
				bool flag = false;
				CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint = new List<string>();
				foreach (Station all_station in MemoryLoadedObjects.all_stations)
				{
					if (!all_station.SendToStation && all_station.AutoPrint)
					{
						flag = true;
						_ = all_station.PrinterName;
						CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint.Add(all_station.StationID.ToString());
					}
					if (all_station.EnablePrint)
					{
						bool isOrderMade = ((!all_station.SendToStation) ? true : false);
						_003C_003E4__this.PrintToStation(orderNumber, orderType, (string.IsNullOrEmpty(customerInfoName) ? string.Empty : (customerInfoName + " - ")) + customer, all_station.StationID, employeeName, isOrderMade, reprint: false, printOnlyOne: false, customer);
					}
					else if (!all_station.EnablePrint && !all_station.SendToStation)
					{
						_003C_003E4__this.OrderMade(orderNumber, all_station.StationID);
					}
				}
				if (flag)
				{
					List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == orderNumber).ToList();
					if (list.Where((Order a) => a.DateFilled.HasValue || a.OrderType == OrderTypes.DineIn).Count() == 0 && list.Where((Order a) => !a.Void && a.StationID != null && a.StationID.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any() && (a.StationPrinted == null || !a.StationPrinted.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any())).Count() > 0)
					{
						_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass1_2();
						List<string> list2 = (from a in list
							where !a.Void && a.StationID != null && a.StationID.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any()
							select a.StationID).ToList();
						List<string> list3 = new List<string>();
						foreach (string item2 in list2)
						{
							string[] array = item2.Split(',');
							foreach (string item in array)
							{
								if (!list3.Contains(item))
								{
									list3.Add(item);
								}
							}
						}
						CS_0024_003C_003E8__locals1.stationOrdersWithAutoPrint = CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint.Intersect(list3).ToList();
						foreach (Station item3 in MemoryLoadedObjects.all_stations.Where((Station x) => CS_0024_003C_003E8__locals1.stationOrdersWithAutoPrint.Contains(x.StationID.ToString())).ToList())
						{
							if (!item3.OrderTypes.Split(',').Contains(orderType))
							{
								continue;
							}
							PrintHelper.GenerateReceipt(orderNumber, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, item3.PrinterName);
							foreach (Order item4 in list)
							{
								item4.StationPrinted += ((item4.StationPrinted == null) ? item3.StationID.ToString() : ("," + item3.StationID));
							}
						}
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
				_003C_003E4__this.ChangePrintedInKitchenAndOrderStationMade(orderNumber, orderType);
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				MemoryLoadedData.isChitPrinting = false;
			}
			catch (Exception ex)
			{
				MemoryLoadedData.isChitPrinting = false;
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				SyncMethods.WriteToSyncLog("OrderPrintMadeCheck Error: Error printing chit " + orderNumber + ", Chit Print self check will catch this print. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_1
	{
		public List<string> listOfStationIdWithAutoPrint;

		public _003C_003Ec__DisplayClass1_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003COrderPrintMadeCheck_003Eb__3(Order a)
		{
			if (!a.Void && a.StationID != null && a.StationID.Split(',').Intersect(listOfStationIdWithAutoPrint).Any())
			{
				if (a.StationPrinted != null)
				{
					return !a.StationPrinted.Split(',').Intersect(listOfStationIdWithAutoPrint).Any();
				}
				return true;
			}
			return false;
		}

		internal bool _003COrderPrintMadeCheck_003Eb__4(Order a)
		{
			if (!a.Void && a.StationID != null)
			{
				return a.StationID.Split(',').Intersect(listOfStationIdWithAutoPrint).Any();
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_2
	{
		public List<string> stationOrdersWithAutoPrint;

		public Func<Station, bool> _003C_003E9__6;

		public _003C_003Ec__DisplayClass1_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003COrderPrintMadeCheck_003Eb__6(Station x)
		{
			return stationOrdersWithAutoPrint.Contains(x.StationID.ToString());
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int numOfItems;

		public OrderHelper _003C_003E4__this;

		public string orderNumber;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003COrderMadeCheck_003Eb__0()
		{
			if (numOfItems < 3)
			{
				numOfItems = 3;
			}
			if (numOfItems * 100 < 5000)
			{
				Thread.Sleep(numOfItems * 100);
			}
			else
			{
				Thread.Sleep(5000);
			}
			new GClass6();
			foreach (Station item in MemoryLoadedObjects.all_stations.Where((Station a) => a.SystemDefinedID != 1).ToList())
			{
				if (!item.EnablePrint && !item.SendToStation)
				{
					_003C_003E4__this.OrderMade(orderNumber, item.StationID);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int station;

		public string orderType;

		public string TableName;

		public string orderNumber;

		public bool reprint;

		public OrderHelper _003C_003E4__this;

		public Func<Order, bool> _003C_003E9__56;

		public Func<Order, PrintToStationOrderObject> _003C_003E9__60;

		public Func<PrintToStationOrderObject, bool> _003C_003E9__62;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__0(Station a)
		{
			if (a.StationID == station && a.EnablePrint)
			{
				return a.OrderTypes.Split(',').Contains(orderType);
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__2(Order a)
		{
			if (a.StationPrinted != null)
			{
				if (a.StationPrinted != null)
				{
					return !a.StationPrinted.Split(',').Contains(station.ToString());
				}
				return false;
			}
			return true;
		}

		internal bool _003CPrintToStation_003Eb__8(Order o)
		{
			return o.StationID.Split(',').Contains(station.ToString());
		}

		internal PrintToStationOrderObject _003CPrintToStation_003Eb__9(Order a)
		{
			return _003C_003E4__this.PutOrderToPrintToStationObject(a);
		}

		internal bool _003CPrintToStation_003Eb__56(Order a)
		{
			if (a.StationPrinted != null)
			{
				if (a.StationPrinted != null)
				{
					return !a.StationPrinted.Split(',').Contains(station.ToString());
				}
				return false;
			}
			return true;
		}

		internal PrintToStationOrderObject _003CPrintToStation_003Eb__60(Order a)
		{
			return _003C_003E4__this.PutOrderToPrintToStationObject(a);
		}

		internal bool _003CPrintToStation_003Eb__62(PrintToStationOrderObject o)
		{
			return o.StationID.Split(',').Contains(station.ToString());
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int thresholdTimeInMinutes;

		public string printCancelledItems;

		public List<Guid> orderIDs;

		public _003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals1;

		public Func<PrintToStationOrderObject, bool> _003C_003E9__65;

		public _003C_003Ec__DisplayClass3_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__7(Order o)
		{
			if (o.StationID != null && o.StationID != string.Empty && o.ItemID != -999 && (thresholdTimeInMinutes == 0 || !o.FulfillmentAt.HasValue || o.FulfillmentAt <= DateTime.Now.AddMinutes(thresholdTimeInMinutes)))
			{
				if (!CS_0024_003C_003E8__locals1.reprint && o.OrderOnHoldTime != 0 && o.OrderOnHoldTime != -1 && (o.OrderOnHoldTime == 0 || !(o.DateCreated.Value <= DateTime.Now.AddMinutes(-o.OrderOnHoldTime))))
				{
					if (!(o.OrderType == OrderTypes.DeliveryOnline) && !(o.OrderType == OrderTypes.PickUpOnline) && !(o.OrderType == OrderTypes.Delivery) && !(o.OrderType == OrderTypes.PickUp))
					{
						return o.OrderType == OrderTypes.Catering;
					}
					return true;
				}
				return true;
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__65(PrintToStationOrderObject a)
		{
			if (a.StationPrinted != null && a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals1.station.ToString()))
			{
				return true;
			}
			if (printCancelledItems == "ON" && a.Void && a.PrintedInKitchen)
			{
				if (a.StationPrinted != null)
				{
					if (a.StationPrinted != null)
					{
						return !a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals1.station.ToString());
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public Order order;

		public _003C_003Ec__DisplayClass3_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_3
	{
		public PrintToStationOrderObject tempOrder;

		public _003C_003Ec__DisplayClass3_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__33(PrintToStationOrderObject a)
		{
			if (a.ItemID == tempOrder.ItemID && a.ComboID == tempOrder.ComboID && a.ShareItemID == tempOrder.OrderId)
			{
				return a.StationPrinted == tempOrder.StationPrinted;
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__36(PrintToStationOrderObject a)
		{
			if (a != tempOrder && a.ItemID == tempOrder.ItemID && a.ComboID == tempOrder.ComboID && a.OrderNumber == tempOrder.OrderNumber && a.StationPrinted == tempOrder.StationPrinted)
			{
				return !a.ShareItemID.HasValue;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_4
	{
		public string itemCourse;

		public _003C_003Ec__DisplayClass3_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__45(PrintToStationOrderObject a)
		{
			if (a.ItemCourse == itemCourse)
			{
				return a.ItemIdentifier == "MainItem";
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__47(PrintToStationOrderObject a)
		{
			if (a.ItemCourse == itemCourse)
			{
				return a.ItemIdentifier == "MainItem";
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_5
	{
		public short comboId;

		public _003C_003Ec__DisplayClass3_4 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass3_5()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__50(PrintToStationOrderObject a)
		{
			if (a.ComboID == comboId)
			{
				return a.ItemCourse == CS_0024_003C_003E8__locals2.itemCourse;
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__52(PrintToStationOrderObject a)
		{
			return a.ComboID == comboId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_6
	{
		public PrintToStationOrderObject orderItem;

		public _003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals3;

		public Func<PrintToStationOrderObject, bool> _003C_003E9__77;

		public _003C_003Ec__DisplayClass3_6()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__59(Order o)
		{
			if (o.ComboID == orderItem.ComboID && o.StationID != null && o.StationID != string.Empty && o.ItemID > 0 && (CS_0024_003C_003E8__locals3.thresholdTimeInMinutes == 0 || !o.FulfillmentAt.HasValue || o.FulfillmentAt.Value <= DateTime.Now.AddMinutes(CS_0024_003C_003E8__locals3.thresholdTimeInMinutes)))
			{
				if (!CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint && o.OrderOnHoldTime != 0 && o.OrderOnHoldTime != -1 && (o.OrderOnHoldTime == 0 || !(o.DateCreated.Value.AddMinutes(o.OrderOnHoldTime) <= DateTime.Now)))
				{
					if (!(o.OrderType == OrderTypes.DeliveryOnline) && !(o.OrderType == OrderTypes.PickUpOnline) && !(o.OrderType == OrderTypes.PickUpCurbsideOnline) && !(o.OrderType == OrderTypes.DineInOnline) && !(o.OrderType == OrderTypes.Delivery))
					{
						return o.OrderType == OrderTypes.PickUp;
					}
					return true;
				}
				return true;
			}
			return false;
		}

		internal bool _003CPrintToStation_003Eb__71(PrintToStationOrderObject a)
		{
			return a.OrderNumber == orderItem.OrderNumber;
		}

		internal bool _003CPrintToStation_003Eb__77(PrintToStationOrderObject x)
		{
			return x.ItemID != orderItem.ItemID;
		}

		internal bool _003CPrintToStation_003Eb__83(Guid a)
		{
			return a != orderItem.OrderId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_7
	{
		public PrintToStationOrderObject tempOrder;

		public _003C_003Ec__DisplayClass3_7()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__72(PrintToStationOrderObject a)
		{
			if (a.ItemID == tempOrder.ItemID && a.ComboID == tempOrder.ComboID && a.StationPrinted == tempOrder.StationPrinted)
			{
				Guid? shareItemID = a.ShareItemID;
				Guid orderId = tempOrder.OrderId;
				if (!shareItemID.HasValue)
				{
					return false;
				}
				if (!shareItemID.HasValue)
				{
					return true;
				}
				return shareItemID.GetValueOrDefault() == orderId;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_8
	{
		public PrintToStationOrderObject ord;

		public _003C_003Ec__DisplayClass3_8()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__76(Order a)
		{
			return a.OrderId == ord.OrderId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_9
	{
		public Order orderToChange;

		public _003C_003Ec__DisplayClass3_9()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPrintToStation_003Eb__82(Station a)
		{
			if (orderToChange.StationID.Split(',').Contains(a.StationID.ToString()))
			{
				return a.SendToStation;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_10
	{
		public string stationToMade;

		public _003C_003Ec__DisplayClass3_10()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CPrintToStation_003Eb__85(Order a)
		{
			a.StationMade = stationToMade;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_11
	{
		public List<Guid> orderToChangeListUnder;

		public _003C_003Ec__DisplayClass3_11()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int station;

		public Func<Order, bool> _003C_003E9__0;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003COrderMade_003Eb__0(Order o)
		{
			if (o.StationID.Contains(station.ToString()))
			{
				return !o.DateFilled.HasValue;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Order orderItem;

		public Func<Order, bool> _003C_003E9__2;

		public _003C_003Ec__DisplayClass8_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003COrderMade_003Eb__2(Order o)
		{
			if (o.ComboID == orderItem.ComboID && o.OrderNumber == orderItem.OrderNumber)
			{
				return !o.DateFilled.HasValue;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public string _OrderNumber;

		public OrderHelper _003C_003E4__this;

		public Form frm;

		public int tries;

		public string orderType;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRecordBatchId_003Eb__0()
		{
			try
			{
				GClass6 gClass = new GClass6();
				List<Order> list = null;
				if (_OrderNumber != null)
				{
					list = gClass.Orders.Where((Order o) => o.OrderNumber == _OrderNumber && o.Paid == true && o.Void == false && o.DateCleared == null && (o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline)).ToList();
				}
				if (list.Count() <= 0)
				{
					return;
				}
				int num = 0;
				using (List<Order>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1
						{
							order = enumerator.Current
						};
						Item item = gClass.Items.Where((Item a) => a.ItemID == _003C_003Ec__DisplayClass9_.order.ItemID).FirstOrDefault();
						if (item != null && item.TrackExpiryDate && (!_003C_003Ec__DisplayClass9_.order.InventoryBatchId.HasValue || (_003C_003Ec__DisplayClass9_.order.InventoryBatchId.HasValue && _003C_003Ec__DisplayClass9_.order.InventoryBatchId.Value == 0)))
						{
							int value = _003C_003E4__this.CheckAndSelectBatchId(item.ItemID);
							_003C_003Ec__DisplayClass9_.order.InventoryBatchId = value;
							num++;
						}
					}
				}
				if (num > 0)
				{
					Helper.SubmitChangesWithCatch(gClass);
				}
				if (frm != null)
				{
					frm.Invoke((Action)delegate
					{
						MiscHelper.MakeOrderIsModified(frm, _OrderNumber);
					});
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				tries++;
				if (tries <= 3)
				{
					_003C_003E4__this.RecordBatchId(_OrderNumber, orderType, frm, tries);
				}
			}
		}

		internal void _003CRecordBatchId_003Eb__2()
		{
			MiscHelper.MakeOrderIsModified(frm, _OrderNumber);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public Order order;

		public _003C_003Ec__DisplayClass9_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string _OrderNumber;

		public string orderType;

		public Form frm;

		public int tries;

		public OrderHelper _003C_003E4__this;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CClearOrder_003Eb__0()
		{
			try
			{
				GClass6 gClass = new GClass6();
				if (_OrderNumber == null)
				{
					return;
				}
				List<Order> list = gClass.Orders.Where((Order o) => o.OrderNumber == _OrderNumber && o.Paid == true && o.Void == false && o.DateCleared == null).ToList();
				string text = null;
				foreach (Order item in list)
				{
					item.Synced = false;
					item.DateCleared = DateTime.Now;
					if (text == null)
					{
						text = item.Source;
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
				if (orderType == OrderTypes.DeliveryOnline || orderType == OrderTypes.PickUpOnline || orderType == OrderTypes.PickUpCurbsideOnline || orderType == OrderTypes.DineInOnline)
				{
					_ = SyncMethods.UpdateOrderStatusInOrdering(_OrderNumber, "Completed", string.Empty, string.Empty, text).code;
				}
				if (frm != null)
				{
					frm.Invoke((Action)delegate
					{
						MiscHelper.MakeOrderIsModified(frm, _OrderNumber);
					});
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				tries++;
				if (tries <= 3)
				{
					_003C_003E4__this.ClearOrder(_OrderNumber, orderType, frm, tries);
				}
			}
		}

		internal void _003CClearOrder_003Eb__2()
		{
			MiscHelper.MakeOrderIsModified(frm, _OrderNumber);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int itemId;

		public Item item;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public Item item;

		public _003C_003Ec__DisplayClass13_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int batchId;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public string dayOfWeek;

		public _003C_003Ec__DisplayClass17_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public List<GlobalOrderHistoryObjects.Order> orderToIterate;

		public List<Item> items;

		public int mainItemId;

		public int childMainItemId;

		public _003C_003Ec__DisplayClass18_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__7(Item x)
		{
			if (!orderToIterate.Select((GlobalOrderHistoryObjects.Order y) => y.item_barcode).Contains(x.Barcode))
			{
				return orderToIterate.Select((GlobalOrderHistoryObjects.Order y) => y.item_id).Contains(x.ItemID);
			}
			return true;
		}

		internal bool _003CDuplicateOrder_003Eb__8(ItemsInGroup x)
		{
			return items.Select((Item y) => y.ItemID).Contains(x.ItemID.Value);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public short toCorrectComboId;

		public Func<GlobalOrderHistoryObjects.Order, bool> _003C_003E9__11;

		public _003C_003Ec__DisplayClass18_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__11(GlobalOrderHistoryObjects.Order a)
		{
			return a.combo_id == toCorrectComboId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_2
	{
		public GlobalOrderHistoryObjects.Order order;

		public _003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass18_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__18(Item x)
		{
			return x.Barcode == order.item_barcode;
		}

		internal bool _003CDuplicateOrder_003Eb__19(Item x)
		{
			if (x.Barcode == order.item_barcode)
			{
				return x.ItemID == order.item_id;
			}
			return false;
		}

		internal bool _003CDuplicateOrder_003Eb__20(Item x)
		{
			return x.Barcode == order.item_barcode;
		}

		internal bool _003CDuplicateOrder_003Eb__16(Item x)
		{
			return x.ItemID == order.item_id;
		}

		internal bool _003CDuplicateOrder_003Eb__23(usp_ItemOptionsResult a)
		{
			if (a.GroupName == order.option_group_name)
			{
				return a.Tab.ToUpper() == order.option_tab.ToUpper().Trim();
			}
			return false;
		}

		internal bool _003CDuplicateOrder_003Eb__24(usp_ItemOptionsResult a)
		{
			return a.Tab.ToUpper() == order.option_tab.ToUpper().Trim();
		}

		internal bool _003CDuplicateOrder_003Eb__25(usp_ItemOptionsResult a)
		{
			return a.Tab.ToUpper() == order.option_tab.ToUpper().Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_3
	{
		public Item item;

		public _003C_003Ec__DisplayClass18_2 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass18_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__17(ItemsInGroup x)
		{
			return x.ItemID == item.ItemID;
		}

		internal bool _003CDuplicateOrder_003Eb__21(usp_ItemOptionsResult a)
		{
			if (a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId && a.Option_ItemID == item.ItemID)
			{
				return !a.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CDuplicateOrder_003Eb__22(usp_ItemOptionsResult a)
		{
			if (a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId && a.Option_ItemID == item.ItemID)
			{
				return !a.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_4
	{
		public usp_ItemOptionsResult optionData;

		public _003C_003Ec__DisplayClass18_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__26(Reason a)
		{
			return a.Value.ToUpper() == optionData.Tab.ToUpper();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_5
	{
		public global::_003C_003Ef__AnonymousType10<global::_003C_003Ef__AnonymousType9<string, string>, int?> dataGroup;

		public _003C_003Ec__DisplayClass18_5()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__29(usp_ItemOptionsResult a)
		{
			if (a.ItemWithOptionID == dataGroup.ItemOptionId)
			{
				return !a.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_6
	{
		public usp_ItemOptionsResult optionData;

		public _003C_003Ec__DisplayClass18_6()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__30(usp_ItemOptionsResult x)
		{
			if (x.Tab.ToUpper() == optionData.Tab.ToUpper() && x.GroupID == optionData.GroupID)
			{
				return x.ItemID == optionData.ItemID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_7
	{
		public List<int> itemWithOptionIDs;

		public Func<Order, bool> _003C_003E9__32;

		public _003C_003Ec__DisplayClass18_7()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__32(Order a)
		{
			if (a.ItemSellPrice > 0m)
			{
				return itemWithOptionIDs.Contains(a.ItemOptionId.Value);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_8
	{
		public Order o;

		public _003C_003Ec__DisplayClass18_8()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__34(Order a)
		{
			return a.OrderId == o.OrderId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_9
	{
		public GroupsInItem groupInItem;

		public _003C_003Ec__DisplayClass18_9()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_10
	{
		public global::_003C_003Ef__AnonymousType10<global::_003C_003Ef__AnonymousType9<string, string>, int?> dataGroup;

		public _003C_003Ec__DisplayClass18_10()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__41(usp_ItemOptionsResult a)
		{
			if (a.ItemWithOptionID == dataGroup.ItemOptionId)
			{
				return !a.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_11
	{
		public usp_ItemOptionsResult optionData;

		public _003C_003Ec__DisplayClass18_11()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__42(usp_ItemOptionsResult x)
		{
			if (x.Tab.ToUpper() == optionData.Tab.ToUpper() && x.GroupID == optionData.GroupID)
			{
				return x.ItemID == optionData.ItemID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_12
	{
		public List<int> itemWithOptionIDs;

		public _003C_003Ec__DisplayClass18_12()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__44(Order a)
		{
			if (a.ItemSellPrice > 0m)
			{
				return itemWithOptionIDs.Contains(a.ItemOptionId.Value);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_13
	{
		public Order o;

		public _003C_003Ec__DisplayClass18_13()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CDuplicateOrder_003Eb__46(Order a)
		{
			return a.OrderId == o.OrderId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public string customer;

		public _003C_003Ec__DisplayClass20_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public string sync_station;

		public _003C_003Ec__DisplayClass21_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	public List<string> PrintAllHoldItemsPastTimeIndex()
	{
		GClass6 gClass = new GClass6();
		List<string> list = new List<string>();
		if (MemoryLoadedObjects.all_stations.Where((Station a) => a.EnablePrint && !a.SystemDefinedID.HasValue).FirstOrDefault() != null)
		{
			using (List<PrintToStationOrderObject>.Enumerator enumerator = (from a in (from o in gClass.Orders.Where((Order o) => o.OrderOnHoldTime != 0 && o.ItemID != -999 && o.PrintedInKitchen == false && o.DateCreated.Value.Date >= DateTime.Now.AddDays(-1.0).Date && o.ItemIdentifier == "MainItem").ToList()
					where !o.DateFilled.HasValue && !o.ShareItemID.HasValue && !o.PaymentMethods.Contains("KIOSK") && (!o.FulfillmentAt.HasValue || o.FulfillmentAt <= DateTime.Now) && o.DateCreated.Value <= DateTime.Now.AddMinutes(-o.OrderOnHoldTime)
					select o).ToList()
				group a by a.OrderNumber into a
				select new PrintToStationOrderObject
				{
					UserCreated = a.FirstOrDefault().UserCreated,
					OrderNumber = a.Key,
					OrderType = a.FirstOrDefault().OrderType,
					Customer = a.FirstOrDefault().Customer,
					CustomerInfo = a.FirstOrDefault().CustomerInfo,
					CustomerInfoName = a.FirstOrDefault().CustomerInfoName
				}).ToList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
					CS_0024_003C_003E8__locals0.order = enumerator.Current;
					string orderstatus = "SAVED ORDER";
					if (SettingsHelper.CurrentTerminalMode == "Kiosk")
					{
						orderstatus = "KIOSK SAVED ORDER";
					}
					string employeeName = (CS_0024_003C_003E8__locals0.order.UserCreated.HasValue ? (from a in gClass.Users
						where (int?)a.EmployeeID == (int?)CS_0024_003C_003E8__locals0.order.UserCreated
						select string.Concat(a.Employee.FirstName + " ", a.Employee.LastName)).FirstOrDefault() : "ORDER");
					OrderPrintMadeCheck(orderstatus, CS_0024_003C_003E8__locals0.order.OrderNumber, CS_0024_003C_003E8__locals0.order.OrderType, CS_0024_003C_003E8__locals0.order.CustomerInfoName, CS_0024_003C_003E8__locals0.order.Customer, employeeName);
					list.Add(CS_0024_003C_003E8__locals0.order.OrderNumber);
				}
				return list;
			}
		}
		return list;
	}

	public void OrderPrintMadeCheck(string orderstatus, string orderNumber, string orderType, string customerInfoName, string customer, string employeeName, int numOfItems = 1)
	{
		_003C_003Ec__DisplayClass1_0 _003C_003Ec__DisplayClass1_ = new _003C_003Ec__DisplayClass1_0();
		_003C_003Ec__DisplayClass1_.numOfItems = numOfItems;
		_003C_003Ec__DisplayClass1_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass1_.orderNumber = orderNumber;
		_003C_003Ec__DisplayClass1_.orderType = orderType;
		_003C_003Ec__DisplayClass1_.customerInfoName = customerInfoName;
		_003C_003Ec__DisplayClass1_.customer = customer;
		_003C_003Ec__DisplayClass1_.employeeName = employeeName;
		new Thread((ThreadStart)delegate
		{
			try
			{
				_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_1();
				MemoryLoadedData.isChitPrinting = true;
				MemoryLoadedObjects.chitPrintSelfCheck_running = true;
				if (_003C_003Ec__DisplayClass1_.numOfItems < 3)
				{
					_003C_003Ec__DisplayClass1_.numOfItems = 3;
				}
				if (_003C_003Ec__DisplayClass1_.numOfItems * 100 < 5000)
				{
					Thread.Sleep(_003C_003Ec__DisplayClass1_.numOfItems * 100);
				}
				else
				{
					Thread.Sleep(5000);
				}
				GClass6 gClass = new GClass6();
				bool flag = false;
				CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint = new List<string>();
				foreach (Station all_station in MemoryLoadedObjects.all_stations)
				{
					if (!all_station.SendToStation && all_station.AutoPrint)
					{
						flag = true;
						_ = all_station.PrinterName;
						CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint.Add(all_station.StationID.ToString());
					}
					if (all_station.EnablePrint)
					{
						bool isOrderMade = ((!all_station.SendToStation) ? true : false);
						_003C_003Ec__DisplayClass1_._003C_003E4__this.PrintToStation(_003C_003Ec__DisplayClass1_.orderNumber, _003C_003Ec__DisplayClass1_.orderType, (string.IsNullOrEmpty(_003C_003Ec__DisplayClass1_.customerInfoName) ? string.Empty : (_003C_003Ec__DisplayClass1_.customerInfoName + " - ")) + _003C_003Ec__DisplayClass1_.customer, all_station.StationID, _003C_003Ec__DisplayClass1_.employeeName, isOrderMade, reprint: false, printOnlyOne: false, _003C_003Ec__DisplayClass1_.customer);
					}
					else if (!all_station.EnablePrint && !all_station.SendToStation)
					{
						_003C_003Ec__DisplayClass1_._003C_003E4__this.OrderMade(_003C_003Ec__DisplayClass1_.orderNumber, all_station.StationID);
					}
				}
				if (flag)
				{
					List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == _003C_003Ec__DisplayClass1_.orderNumber).ToList();
					if (list.Where((Order a) => a.DateFilled.HasValue || a.OrderType == OrderTypes.DineIn).Count() == 0 && list.Where((Order a) => !a.Void && a.StationID != null && a.StationID.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any() && (a.StationPrinted == null || !a.StationPrinted.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any())).Count() > 0)
					{
						_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass1_2();
						List<string> list2 = (from a in list
							where !a.Void && a.StationID != null && a.StationID.Split(',').Intersect(CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint).Any()
							select a.StationID).ToList();
						List<string> list3 = new List<string>();
						foreach (string item2 in list2)
						{
							string[] array = item2.Split(',');
							foreach (string item in array)
							{
								if (!list3.Contains(item))
								{
									list3.Add(item);
								}
							}
						}
						CS_0024_003C_003E8__locals1.stationOrdersWithAutoPrint = CS_0024_003C_003E8__locals0.listOfStationIdWithAutoPrint.Intersect(list3).ToList();
						foreach (Station item3 in MemoryLoadedObjects.all_stations.Where((Station x) => CS_0024_003C_003E8__locals1.stationOrdersWithAutoPrint.Contains(x.StationID.ToString())).ToList())
						{
							if (item3.OrderTypes.Split(',').Contains(_003C_003Ec__DisplayClass1_.orderType))
							{
								PrintHelper.GenerateReceipt(_003C_003Ec__DisplayClass1_.orderNumber, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, item3.PrinterName);
								foreach (Order item4 in list)
								{
									item4.StationPrinted += ((item4.StationPrinted == null) ? item3.StationID.ToString() : ("," + item3.StationID));
								}
							}
						}
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
				_003C_003Ec__DisplayClass1_._003C_003E4__this.ChangePrintedInKitchenAndOrderStationMade(_003C_003Ec__DisplayClass1_.orderNumber, _003C_003Ec__DisplayClass1_.orderType);
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				MemoryLoadedData.isChitPrinting = false;
			}
			catch (Exception ex)
			{
				MemoryLoadedData.isChitPrinting = false;
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				SyncMethods.WriteToSyncLog("OrderPrintMadeCheck Error: Error printing chit " + _003C_003Ec__DisplayClass1_.orderNumber + ", Chit Print self check will catch this print. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
			}
		}).Start();
	}

	public void OrderMadeCheck(string orderstatus, string orderNumber, string orderType, string customerInfoName, string customer, string employeeName, int numOfItems = 1)
	{
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
		_003C_003Ec__DisplayClass2_.numOfItems = numOfItems;
		_003C_003Ec__DisplayClass2_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass2_.orderNumber = orderNumber;
		new Thread((ThreadStart)delegate
		{
			if (_003C_003Ec__DisplayClass2_.numOfItems < 3)
			{
				_003C_003Ec__DisplayClass2_.numOfItems = 3;
			}
			if (_003C_003Ec__DisplayClass2_.numOfItems * 100 < 5000)
			{
				Thread.Sleep(_003C_003Ec__DisplayClass2_.numOfItems * 100);
			}
			else
			{
				Thread.Sleep(5000);
			}
			new GClass6();
			foreach (Station item in MemoryLoadedObjects.all_stations.Where((Station a) => a.SystemDefinedID != 1).ToList())
			{
				if (!item.EnablePrint && !item.SendToStation)
				{
					_003C_003Ec__DisplayClass2_._003C_003E4__this.OrderMade(_003C_003Ec__DisplayClass2_.orderNumber, item.StationID);
				}
			}
		}).Start();
	}

	public void PrintToStation(string orderNumber, string orderType, string customer, int station, string employee, bool isOrderMade = true, bool reprint = false, bool printOnlyOne = false, string TableName = "")
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.station = station;
		_003C_003Ec__DisplayClass3_.orderType = orderType;
		_003C_003Ec__DisplayClass3_.TableName = TableName;
		_003C_003Ec__DisplayClass3_.orderNumber = orderNumber;
		_003C_003Ec__DisplayClass3_.reprint = reprint;
		_003C_003Ec__DisplayClass3_._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		try
		{
			_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass3_1();
			CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass3_;
			Station station2 = MemoryLoadedObjects.all_stations.Where((Station a) => a.StationID == CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.station && a.EnablePrint && a.OrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType)).FirstOrDefault();
			if (station2 == null)
			{
				return;
			}
			new InventoryMethods();
			CS_0024_003C_003E8__locals4.printCancelledItems = SettingsHelper.GetSettingValueByKey("print_chit_change_cancel");
			bool flag = false;
			if (SettingsHelper.GetSettingValueByKey("course_selection") == "ON")
			{
				flag = true;
			}
			CS_0024_003C_003E8__locals4.thresholdTimeInMinutes = 0;
			if (SettingsHelper.GetSettingValueByKey("fulfillment_threshold") == "ON" && !CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint)
			{
				CS_0024_003C_003E8__locals4.thresholdTimeInMinutes = Math.Abs((int)(Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("fulfillment_threshold_time")) * 60m));
			}
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_chit_cashout");
			List<string> list = new List<string>();
			List<Order> source;
			if ((SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" || station2.ChitFormat == 6) && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
			{
				CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.station.ToString();
				source = gClass.Orders.Where((Order o) => (o.Customer == CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.TableName || o.Customer == CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.TableName.ToUpper()) && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.StationID != null && o.StationID != string.Empty && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
			}
			else
			{
				source = gClass.Orders.Where((Order x) => x.OrderNumber.Equals(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber.ToUpper()) && x.DateCreated.Value.Date >= DateTime.Now.AddDays(-15.0).Date).ToList();
			}
			if (!CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint)
			{
				source = source.Where((Order a) => a.StationPrinted == null || (a.StationPrinted != null && !a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.station.ToString()))).ToList();
			}
			if (settingValueByKey == "ON" && (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.ToGo))
			{
				source = source.Where((Order a) => a.Paid).ToList();
			}
			if (CS_0024_003C_003E8__locals4.printCancelledItems == "OFF" || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint)
			{
				source = source.Where((Order a) => !a.Void || (a.FlagID != 4 && a.FlagID != 3)).ToList();
			}
			if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON" && (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DeliveryOnline || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.PickUpOnline || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.TakeOutOnline || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.PickUpCurbsideOnline || CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineInOnline))
			{
				source = source.Where((Order a) => a.FlagID != 1 || a.FlagID == 0).ToList();
			}
			if (station2.ChitFormat != 5)
			{
				source = source.Where((Order o) => o.ItemIdentifier == "MainItem").ToList();
			}
			List<PrintToStationOrderObject> list2 = (from o in source.Where((Order o) => o.StationID != null && o.StationID != string.Empty && o.ItemID != -999 && (CS_0024_003C_003E8__locals4.thresholdTimeInMinutes == 0 || !o.FulfillmentAt.HasValue || o.FulfillmentAt <= DateTime.Now.AddMinutes(CS_0024_003C_003E8__locals4.thresholdTimeInMinutes)) && (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint || o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value <= DateTime.Now.AddMinutes(-o.OrderOnHoldTime)) || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.PickUp || o.OrderType == OrderTypes.Catering)).ToList()
				where o.StationID.Split(',').Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.station.ToString())
				select o into a
				select CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1._003C_003E4__this.PutOrderToPrintToStationObject(a) into a
				orderby a.ItemCourse
				select a).ThenBy((PrintToStationOrderObject y) => y.DateCreated).ToList();
			list = source.Select((Order a) => a.OrderNumber).Distinct().ToList();
			if (list2.Count == 0 || (list2.Count > 0 && list2.Any((PrintToStationOrderObject a) => a.FlagID == 6)))
			{
				return;
			}
			if (list2.Sum((PrintToStationOrderObject a) => a.Qty) < (decimal)station2.PrintItemQtyGreater)
			{
				decimal d = default(decimal);
				using (IEnumerator<PrintToStationOrderObject> enumerator = list2.Where((PrintToStationOrderObject x) => !x.ShareItemID.HasValue).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass3_2 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_2();
						CS_0024_003C_003E8__locals5.order = enumerator.Current;
						d += CS_0024_003C_003E8__locals5.order.Qty;
						List<Order> list3 = gClass.Orders.Where((Order o) => o.ShareItemID == CS_0024_003C_003E8__locals5.order.OrderId).ToList();
						if (list3 != null && list3.Count > 0)
						{
							d += list3.Sum((Order x) => x.Qty);
						}
						if (Math.Round(d) >= (decimal)station2.PrintItemQtyGreater)
						{
							break;
						}
					}
				}
				if (Math.Round(d) < (decimal)station2.PrintItemQtyGreater)
				{
					return;
				}
			}
			bool flag2 = false;
			if ((SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" || station2.ChitFormat == 6) && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In" && list2.Select((PrintToStationOrderObject a) => a.OrderNumber).Distinct().ToList()
				.Count > 1)
			{
				List<PrintToStationOrderObject> list4 = (from a in list2
					group a by new { a.ItemID, a.ComboID, a.OrderNumber, a.StationPrinted } into a
					select a.FirstOrDefault()).ToList();
				using (List<PrintToStationOrderObject>.Enumerator enumerator2 = list4.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass3_3 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass3_3();
						CS_0024_003C_003E8__locals6.tempOrder = enumerator2.Current;
						if (CS_0024_003C_003E8__locals6.tempOrder.ShareItemID.HasValue)
						{
							continue;
						}
						List<PrintToStationOrderObject> source2 = list2.Where((PrintToStationOrderObject a) => a.ItemID == CS_0024_003C_003E8__locals6.tempOrder.ItemID && a.ComboID == CS_0024_003C_003E8__locals6.tempOrder.ComboID && a.ShareItemID == CS_0024_003C_003E8__locals6.tempOrder.OrderId && a.StationPrinted == CS_0024_003C_003E8__locals6.tempOrder.StationPrinted).ToList();
						if (CS_0024_003C_003E8__locals6.tempOrder.OrderIdSharedList == null)
						{
							CS_0024_003C_003E8__locals6.tempOrder.OrderIdSharedList = new List<Guid>();
						}
						CS_0024_003C_003E8__locals6.tempOrder.OrderIdSharedList.AddRange(source2.Select((PrintToStationOrderObject a) => a.OrderId).ToList());
						CS_0024_003C_003E8__locals6.tempOrder.Qty += Math.Round(source2.Select((PrintToStationOrderObject a) => a.Qty).Sum(), 2);
						if (CS_0024_003C_003E8__locals6.tempOrder.ComboID == 0)
						{
							List<PrintToStationOrderObject> source3 = list2.Where((PrintToStationOrderObject a) => a != CS_0024_003C_003E8__locals6.tempOrder && a.ItemID == CS_0024_003C_003E8__locals6.tempOrder.ItemID && a.ComboID == CS_0024_003C_003E8__locals6.tempOrder.ComboID && a.OrderNumber == CS_0024_003C_003E8__locals6.tempOrder.OrderNumber && a.StationPrinted == CS_0024_003C_003E8__locals6.tempOrder.StationPrinted && !a.ShareItemID.HasValue).ToList();
							CS_0024_003C_003E8__locals6.tempOrder.Qty += Math.Round(source3.Select((PrintToStationOrderObject a) => a.Qty).Sum(), 2);
							CS_0024_003C_003E8__locals6.tempOrder.OrderIdSharedList.AddRange(source3.Select((PrintToStationOrderObject a) => a.OrderId).ToList());
						}
					}
				}
				list2 = list4.Where((PrintToStationOrderObject a) => !a.ShareItemID.HasValue).ToList();
				flag2 = true;
			}
			int value = station2.ChitFontSize.Value;
			string empty = string.Empty;
			string empty2 = string.Empty;
			int num = ((value > 13) ? 27 : (39 - (value - 9) * 3));
			empty += "<br/>";
			empty2 = empty2 ?? "";
			string text = string.Empty;
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = false;
			bool flag6 = false;
			int num2 = 0;
			string text2 = "";
			string seatNum = list2.First().SeatNum;
			string text3 = "";
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string text4 = string.Empty;
			string text5 = "style=\"font-weight:bold;font-size:20pt;\"";
			string text6 = "style=\"font-weight:bold;font-size:12pt;\"";
			string text7 = "";
			List<string> list5 = new List<string>();
			string text8 = string.Empty;
			bool flag7 = false;
			if (PrintEachChitOnlyOne(station2, list2))
			{
				flag7 = true;
			}
			string customerInfo = list2.First().CustomerInfo;
			string customerInfoName = list2.First().CustomerInfoName;
			string text9 = list2.First().CustomerInfoPhone;
			string text10 = (list2.First().FulfillmentAt.HasValue ? list2.First().FulfillmentAt.Value.ToString("hh:mm tt") : list2.First().DateCreated.Value.ToString("hh:mm tt"));
			string source4 = list2.First().Source;
			string subSource = list2.First().SubSource;
			List<Order> source5 = source.Where((Order x) => !x.Void).ToList();
			decimal num3 = source5.Sum((Order x) => x.SubTotal);
			decimal num4 = source5.Sum((Order x) => x.TaxTotal);
			decimal num5 = source5.Sum((Order x) => x.Total);
			string orderNotes = "";
			if (list2.Count > 0)
			{
				text4 = list2.OrderByDescending((PrintToStationOrderObject a) => a.DateCreated).First().DateCreated.Value.ToShortDateString() + " " + list2.OrderByDescending((PrintToStationOrderObject a) => a.DateCreated).First().DateCreated.Value.ToShortTimeString();
				if (station2.ChitFormat == 6 && CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn)
				{
					list2 = (from a in list2
						orderby a.SeatNum, a.ItemCourse
						select a).ThenBy((PrintToStationOrderObject y) => y.DateCreated).ToList();
				}
			}
			string text11 = "";
			List<Guid> list6 = new List<Guid>();
			if (station2.ChitFormat == 5)
			{
				if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint)
				{
					text = "<span style=\"font-size:" + value + "pt; font-weight:bold;\">*COPY*</span><br/>";
				}
				num -= 6;
				list6.AddRange(list2.Select((PrintToStationOrderObject a) => a.OrderId).ToList());
				list2 = list2.Where((PrintToStationOrderObject a) => a.ItemCourse != null && a.ItemCourse.ToUpper() != ItemCourses.Uncategorized.ToUpper()).ToList();
				if (CS_0024_003C_003E8__locals4.printCancelledItems == "OFF")
				{
					list2 = list2.Where((PrintToStationOrderObject a) => !a.Void).ToList();
				}
				using List<string>.Enumerator enumerator3 = (from a in (from a in list2
						group a by a.ItemCourse into a
						select a.Key.ToUpper()).Distinct().ToList()
					orderby (a == ItemCourses.Entree.ToUpper()) ? 1 : ((!(a != ItemCourses.Beverage.ToUpper())) ? 3 : 2)
					select a).ToList().GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass3_4 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass3_4();
					CS_0024_003C_003E8__locals7.itemCourse = enumerator3.Current;
					int num6 = (int)list2.Where((PrintToStationOrderObject a) => a.ItemCourse == CS_0024_003C_003E8__locals7.itemCourse && a.ItemIdentifier == "MainItem").Sum((PrintToStationOrderObject a) => a.Qty);
					if (num6 == 0)
					{
						continue;
					}
					string text12 = CS_0024_003C_003E8__locals7.itemCourse;
					int length = text12.Length;
					if (length < num)
					{
						int num7 = (num - length) / 2;
						string text13 = "x";
						for (int i = 0; i < num7 - 3; i++)
						{
							text13 = "=" + text13 + "=";
						}
						text12 = text13.Replace("x", " " + text12 + " ");
					}
					text = text + "<span style=\"font-weight: bold; color:red;\">" + text12 + "</span><br/>";
					List<short> list7 = (from a in list2
						where a.ItemCourse == CS_0024_003C_003E8__locals7.itemCourse && a.ItemIdentifier == "MainItem"
						group a by a.ComboID into a
						select a.Key).ToList();
					int num8 = 1;
					using (List<short>.Enumerator enumerator4 = list7.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							_003C_003Ec__DisplayClass3_5 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass3_5();
							CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals7;
							CS_0024_003C_003E8__locals8.comboId = enumerator4.Current;
							List<PrintToStationOrderObject> list8;
							if (CS_0024_003C_003E8__locals8.comboId == 0)
							{
								list8 = (from a in list2
									where a.ComboID == CS_0024_003C_003E8__locals8.comboId && a.ItemCourse == CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals2.itemCourse
									orderby a.DateCreated
									select a).ToList();
								foreach (PrintToStationOrderObject item in list8)
								{
									for (int j = 0; (decimal)j < item.Qty; j++)
									{
										if (!(item.ItemIdentifier != "MainItem") || !(text12.ToUpper() == ItemCourses.Entree.ToUpper()))
										{
											bool flag8 = false;
											if (CS_0024_003C_003E8__locals4.printCancelledItems == "ON" && item.Void)
											{
												flag8 = true;
											}
											string text14 = "";
											string text15 = "";
											string text16 = ((!string.IsNullOrEmpty(item.ItemName)) ? item.ItemName.Replace("OPT:", string.Empty).Trim() : "");
											if (flag8)
											{
												text14 = "<S>";
												text15 = "</S>";
											}
											text = text + text14 + num8 + "/" + num6 + " " + text16 + text15 + "<br/>";
											num8++;
										}
									}
								}
								continue;
							}
							list8 = (from a in list2
								where a.ComboID == CS_0024_003C_003E8__locals8.comboId
								orderby a.DateCreated
								select a).ToList();
							int num9 = (int)list8.Where((PrintToStationOrderObject a) => a.ItemIdentifier == "MainItem").FirstOrDefault().Qty;
							for (int k = 0; k < num9; k++)
							{
								bool flag9 = true;
								foreach (PrintToStationOrderObject item2 in list8)
								{
									if (!(item2.ItemIdentifier != "MainItem") || !(text12.ToUpper() == ItemCourses.Entree.ToUpper()))
									{
										bool flag10 = false;
										if (CS_0024_003C_003E8__locals4.printCancelledItems == "ON" && item2.Void)
										{
											flag10 = true;
										}
										string text17 = "";
										string text18 = "";
										string text19 = ((!string.IsNullOrEmpty(item2.ItemName)) ? item2.ItemName.Replace("OPT:", string.Empty).Trim() : "");
										if (flag10)
										{
											text17 = "<S>";
											text18 = "</S>";
										}
										if (flag9)
										{
											text = text + text17 + num8 + "/" + num6 + " " + text19 + text18 + "<br/>";
											flag9 = false;
											num8++;
										}
										else
										{
											text = text + text17 + "<div style=\"text-indent:30pt\">-> " + text19 + text18 + "</div>";
										}
									}
								}
							}
						}
					}
					text += "<br/>";
				}
			}
			else
			{
				using List<PrintToStationOrderObject>.Enumerator enumerator2 = list2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass3_6 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass3_6();
					CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals4;
					CS_0024_003C_003E8__locals9.orderItem = enumerator2.Current;
					orderNotes = CS_0024_003C_003E8__locals9.orderItem.OrderNotes;
					text8 = formatTicket(CS_0024_003C_003E8__locals9.orderItem.OrderTicketNumber);
					if (string.IsNullOrEmpty(text7) && (CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.DeliveryOnline || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.PickUpCurbsideOnline || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.DineInOnline || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.PickUpOnline || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.PickUp || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.Delivery || CS_0024_003C_003E8__locals9.orderItem.OrderType == OrderTypes.Catering) && (CS_0024_003C_003E8__locals9.orderItem.OrderOnHoldTime > 0 || CS_0024_003C_003E8__locals9.orderItem.FulfillmentAt > DateTime.Now))
					{
						DateTime dateTime = (CS_0024_003C_003E8__locals9.orderItem.FulfillmentAt.HasValue ? CS_0024_003C_003E8__locals9.orderItem.FulfillmentAt.Value : CS_0024_003C_003E8__locals9.orderItem.DateCreated.Value.AddMinutes(CS_0024_003C_003E8__locals9.orderItem.OrderOnHoldTime));
						if (dateTime > DateTime.Now)
						{
							text7 = "<span style=\"font-weight:bold;color:#fe0303;font-size:" + ((station2.ChitFormat == 4) ? "6" : "18") + "pt;\" >" + ((CS_0024_003C_003E8__locals9.orderItem.FlagID == 7) ? "** TIME CHANGED **<br>" : string.Empty) + (CS_0024_003C_003E8__locals9.orderItem.OrderType.Contains(OrderTypes.Delivery) ? "DELIVER " : "PICKUP ") + ((dateTime.Date == DateTime.Now.Date) ? ("TODAY @ " + dateTime.ToString("hh:mm tt")) : ("ON " + dateTime.ToString("ddd, MMM dd @ hh:mm tt"))) + "</span>";
						}
					}
					flag4 = true;
					empty3 = string.Empty;
					flag5 = CS_0024_003C_003E8__locals9.orderItem.Paid;
					if (CS_0024_003C_003E8__locals9.orderItem.ComboID != 0 && (num2 != CS_0024_003C_003E8__locals9.orderItem.ComboID || text2 != CS_0024_003C_003E8__locals9.orderItem.OrderNumber))
					{
						list6.Add(CS_0024_003C_003E8__locals9.orderItem.OrderId);
						List<Order> source6;
						if (flag2)
						{
							source6 = gClass.Orders.Where((Order o) => (o.Customer == CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.TableName || o.Customer == CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.TableName.ToUpper()) && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.StationID != null && o.StationID != string.Empty && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
							if (!CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
							{
								source6 = source6.Where((Order a) => a.StationPrinted == null || (a.StationPrinted != null && !a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.station.ToString()))).ToList();
							}
						}
						else
						{
							source6 = gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals9.orderItem.OrderNumber).ToList();
							if (station2.ChitFormat == 3)
							{
								source6 = source6.Where((Order o) => !o.ShareItemID.HasValue).ToList();
							}
						}
						List<Order> source7 = source6.Where((Order o) => o.ComboID == CS_0024_003C_003E8__locals9.orderItem.ComboID && o.StationID != null && o.StationID != string.Empty && o.ItemID > 0 && (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.thresholdTimeInMinutes == 0 || !o.FulfillmentAt.HasValue || o.FulfillmentAt.Value <= DateTime.Now.AddMinutes(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.thresholdTimeInMinutes)) && (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint || o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value.AddMinutes(o.OrderOnHoldTime) <= DateTime.Now) || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.PickUp)).ToList();
						List<PrintToStationOrderObject> source8 = source7.Select((Order a) => CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1._003C_003E4__this.PutOrderToPrintToStationObject(a)).ToList();
						list6.AddRange(source8.Select((PrintToStationOrderObject a) => a.OrderId).ToList());
						if (flag2)
						{
							List<PrintToStationOrderObject> list9 = (from a in source8
								group a by new { a.ItemID, a.ComboID, a.OrderNumber, a.StationPrinted } into a
								select a.FirstOrDefault()).ToList();
							using (List<PrintToStationOrderObject>.Enumerator enumerator5 = list9.GetEnumerator())
							{
								while (enumerator5.MoveNext())
								{
									_003C_003Ec__DisplayClass3_7 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass3_7();
									CS_0024_003C_003E8__locals10.tempOrder = enumerator5.Current;
									if (CS_0024_003C_003E8__locals10.tempOrder.ShareItemID.HasValue)
									{
										continue;
									}
									CS_0024_003C_003E8__locals10.tempOrder.Qty += Math.Round((from a in source8.Where(delegate(PrintToStationOrderObject a)
										{
											if (a.ItemID == CS_0024_003C_003E8__locals10.tempOrder.ItemID && a.ComboID == CS_0024_003C_003E8__locals10.tempOrder.ComboID && a.StationPrinted == CS_0024_003C_003E8__locals10.tempOrder.StationPrinted)
											{
												Guid? shareItemID = a.ShareItemID;
												Guid orderId = CS_0024_003C_003E8__locals10.tempOrder.OrderId;
												if (!shareItemID.HasValue)
												{
													return false;
												}
												if (!shareItemID.HasValue)
												{
													return true;
												}
												return shareItemID.GetValueOrDefault() == orderId;
											}
											return false;
										})
										select a.Qty).Sum(), 2);
								}
							}
							source8 = list9.Where((PrintToStationOrderObject a) => !a.ShareItemID.HasValue).ToList();
							source8 = source8.Where((PrintToStationOrderObject a) => a.OrderNumber == CS_0024_003C_003E8__locals9.orderItem.OrderNumber).ToList();
						}
						source8 = (from o in source8
							where o.StationID.Split(',').Contains(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.station.ToString())
							select o into x
							orderby x.DateCreated
							select x).ToList();
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.printCancelledItems == "OFF" || CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
						{
							source8 = source8.Where((PrintToStationOrderObject a) => !a.Void).ToList();
						}
						bool flag11 = false;
						string text20 = string.Empty;
						string text21 = "";
						List<PrintToStationOrderObject> source9 = source8.Where(delegate(PrintToStationOrderObject a)
						{
							if (a.StationPrinted != null && a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.station.ToString()))
							{
								return true;
							}
							return CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.printCancelledItems == "ON" && a.Void && a.PrintedInKitchen && (a.StationPrinted == null || (a.StationPrinted != null && !a.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.station.ToString())));
						}).ToList();
						int num10 = source9.Count();
						int num11 = source9.Where((PrintToStationOrderObject a) => a.PrintedInKitchen).Count();
						if ((source8.Count() == source8.Where((PrintToStationOrderObject a) => !a.PrintedInKitchen).Count() + num11 && num10 != source8.Count()) || CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
						{
							using List<PrintToStationOrderObject>.Enumerator enumerator5 = source8.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								_003C_003Ec__DisplayClass3_8 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_8();
								CS_0024_003C_003E8__locals0.ord = enumerator5.Current;
								empty4 = string.Empty;
								if (source8.Where((PrintToStationOrderObject a) => !a.Void).Count() <= 0 && source8.Where((PrintToStationOrderObject a) => a.IsModified).Count() <= 0)
								{
									continue;
								}
								if (isOrderMade)
								{
									Order order = source7.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals0.ord.OrderId).FirstOrDefault();
									if (order != null)
									{
										order.StationMade = StationMethods.AddStationIdFromStationIds(CS_0024_003C_003E8__locals0.ord.StationMade, station2.StationID.ToString());
									}
								}
								if (!CS_0024_003C_003E8__locals0.ord.PrintedInKitchen || CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
								{
									if ((CS_0024_003C_003E8__locals0.ord.ItemName.Contains("---") || CS_0024_003C_003E8__locals0.ord.ItemIdentifier != "MainItem") && !CS_0024_003C_003E8__locals0.ord.ItemName.Contains("OPT:"))
									{
										flag6 = true;
									}
									if (flag && station2.ChitFormat != 2 && station2.ChitFormat != 4 && station2.ChitFormat != 6 && (text3 != CS_0024_003C_003E8__locals9.orderItem.ItemCourse || (station2.ChitFormat == 3 && flag3 && !flag7)))
									{
										flag3 = false;
										text3 = CS_0024_003C_003E8__locals9.orderItem.ItemCourse;
										string text22 = ((CS_0024_003C_003E8__locals9.orderItem.ItemCourse.ToUpper() == ItemCourses.Uncategorized.ToUpper()) ? "====================" : (" " + CS_0024_003C_003E8__locals9.orderItem.ItemCourse.ToUpper() + " "));
										int length2 = text22.Length;
										if (length2 < num)
										{
											int num12 = (num - length2) / 2;
											for (int l = 0; l < num12 - 3; l++)
											{
												text22 = "=" + text22 + "=";
											}
										}
										text22 = "<span style=\"font-weight:bold;font-size:" + (float)value + "pt;color:red;text-align:center;\">" + text22 + "</span>";
										text += text22;
										text += "<br />";
									}
									string text23 = "";
									string text24 = "";
									string text25 = "";
									string text26 = "text-indent:" + ((CS_0024_003C_003E8__locals0.ord.ItemName.Contains(" OPT:") && flag6) ? "35" : "23") + "pt;";
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.printCancelledItems == "ON" && CS_0024_003C_003E8__locals0.ord.FlagID == 4)
									{
										text23 = "<S>";
										text24 = "</S>";
										if (text21 == "")
										{
											text26 = string.Empty;
											text25 = "<span style='font-size: 9pt;'>-----»  </span>";
											if (!CS_0024_003C_003E8__locals0.ord.ItemName.Contains("[") && !CS_0024_003C_003E8__locals0.ord.ItemName.Contains("]") && !CS_0024_003C_003E8__locals0.ord.ItemName.Contains(" OPT:"))
											{
												string text27 = text5;
												if (station2.ChitFormat == 2)
												{
													text27 = text6;
												}
												text21 = "<span " + text27 + ">*** Item Cancelled *** </span><br />";
												text += text21;
											}
										}
									}
									if (CS_0024_003C_003E8__locals0.ord.FlagID == 3)
									{
										if (!CS_0024_003C_003E8__locals0.ord.ItemName.Contains("[") && !CS_0024_003C_003E8__locals0.ord.ItemName.Contains("]") && !CS_0024_003C_003E8__locals0.ord.ItemName.Contains(" OPT:"))
										{
											string text28 = text5;
											if (station2.ChitFormat == 2)
											{
												text28 = text6;
											}
											text = text + "<span " + text28 + ">*** Item Changed *** </span><br />";
										}
									}
									else if (CS_0024_003C_003E8__locals0.ord.FlagID == 2 && CS_0024_003C_003E8__locals0.ord.ItemName.Contains("[") && CS_0024_003C_003E8__locals0.ord.ItemName.Contains("]"))
									{
										text26 = "font-weight:bold;";
										text25 = "<span style='display: block;width:20pt;font-size: 7pt;'>*NEW*  </span>";
									}
									string empty5 = string.Empty;
									decimal qty = CS_0024_003C_003E8__locals0.ord.Qty;
									if ((station2.PrintEachQty && station2.ChitFormat == 3 && !flag7) || station2.ChitFormat == 2 || station2.ChitFormat == 4)
									{
										qty /= CS_0024_003C_003E8__locals9.orderItem.Qty;
									}
									empty5 = ((!(qty == 1m)) ? MathHelper.DecimalToFraction(qty) : "");
									if (((CS_0024_003C_003E8__locals0.ord.ItemName.Contains("[") && CS_0024_003C_003E8__locals0.ord.ItemName.Contains("]")) || CS_0024_003C_003E8__locals0.ord.ItemName.Contains("OPT: ")) && station2.ChitFormat != 5)
									{
										if (CS_0024_003C_003E8__locals0.ord.ItemName.Contains("[") && CS_0024_003C_003E8__locals0.ord.ItemName.Contains("]"))
										{
											empty4 = CS_0024_003C_003E8__locals0.ord.ItemName.Substring(0, CS_0024_003C_003E8__locals0.ord.ItemName.IndexOf("]") + 1);
										}
										string text29 = CS_0024_003C_003E8__locals0.ord.ItemName;
										if (!string.IsNullOrEmpty(empty4))
										{
											text29 = text29.Replace(empty4, string.Empty);
										}
										if (station2.ChitFormat != 1 && station2.ChitFormat != 3 && station2.ChitFormat != 4)
										{
											if (station2.ChitFormat != 6)
											{
												text20 = ((!(qty != 1m) || string.IsNullOrEmpty(empty5)) ? (text20 + text23 + "<div style=\"font-size:" + ((float)value - 1f) + "pt; \">" + text29 + "</div>" + text24) : (text20 + text23 + "<div style=\"font-size:" + ((float)value - 1f) + "pt; \">" + text29 + "<span style=\"font-weight:bold;font-size:" + ((float)value + 1f) + "pt;\">  x" + empty5 + "</span></div>" + text24));
											}
											else
											{
												text29 = text29.Trim();
												text20 = ((!(qty != 1m) || string.IsNullOrEmpty(empty5)) ? (text20 + "<div style=\"font-size:" + ((float)value - 1f) + "pt;text-indent:10pt; \">(" + text23 + text29.ToTitleCase() + text24 + ")</div>") : (text20 + "<div style=\"font-size:" + ((float)value - 1f) + "pt;text-indent:10pt; \">(" + text23 + empty5 + " " + text29.ToTitleCase() + text24 + ")</div>"));
												if (CS_0024_003C_003E8__locals0.ord.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Instructions.Replace("|", string.Empty).Trim()))
												{
													text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals0.ord.Instructions.Trim().ToUpper() + " **</I></div>";
												}
											}
										}
										else
										{
											if (empty3 != empty4)
											{
												text20 = text20 + "<div style=\"padding-top:3pt;padding-bottom:0pt;text-indent:23pt;font-weight:bold;font-size:" + (float)value + "pt;\">" + empty4 + "</div>";
												empty3 = empty4;
											}
											string text30 = "300";
											text20 = text20 + (flag4 ? string.Empty : ("<div style=\"padding-top:0pt;padding-bottom:0pt;" + text26 + "font-size:" + ((float)value - 1f) + "pt;color:#fe0303;\">")) + text25 + text23 + "<span style=\"font-weight:" + text30 + ";\">" + empty5 + ((empty5 != string.Empty) ? "x " : " ") + text29.Replace("ADD: ", "+") + ((!flag4) ? string.Empty : (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Options) ? string.Empty : (" (" + CS_0024_003C_003E8__locals0.ord.Options + ")"))) + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Instructions) ? string.Empty : (" (" + CS_0024_003C_003E8__locals0.ord.Instructions + ")")) + text24 + "</span>" + (flag4 ? string.Empty : "</div>");
										}
									}
									else if (station2.ChitFormat != 1 && station2.ChitFormat != 3 && station2.ChitFormat != 4)
									{
										if (station2.ChitFormat == 6)
										{
											text = "<div style=\"font-size:" + ((float)value + 1f) + "pt;font-weight:bold;\">" + text23 + empty5 + " " + CS_0024_003C_003E8__locals0.ord.ItemName.ToTitleCase() + text24 + "</div>";
											if (CS_0024_003C_003E8__locals0.ord.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Instructions.Replace("|", string.Empty).Trim()))
											{
												text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals0.ord.Instructions.Trim().ToUpper() + " **</I></div>";
											}
										}
										else
										{
											text = text23 + "<div style=\"font-size:" + ((float)value + 1f) + "pt;font-weight:bold;\">" + CS_0024_003C_003E8__locals0.ord.ItemName + "</div>" + text24;
										}
									}
									else
									{
										text += (string.IsNullOrEmpty(text20) ? string.Empty : (text20 + "<br />"));
										text20 = (empty3 = string.Empty);
										text = text + "<div style=\"padding-top:0pt;padding-bottom:0pt;" + (flag4 ? "font-weight:bold;" : ((CS_0024_003C_003E8__locals0.ord.ItemName.Contains(" OPT:") && flag6) ? "color:#fe0303;text-indent:35pt;" : "text-indent:23pt;")) + "font-size:" + (float)value + "pt;\">" + text23 + empty5 + ((empty5 != string.Empty) ? "x " : " ") + ((!string.IsNullOrEmpty(empty4)) ? CS_0024_003C_003E8__locals0.ord.ItemName.Replace(empty4, string.Empty) : CS_0024_003C_003E8__locals0.ord.ItemName).Replace("ADD: ", "+") + ((!flag4) ? string.Empty : (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Options) ? string.Empty : (" (" + CS_0024_003C_003E8__locals0.ord.Options + ")"))) + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.ord.Instructions) ? string.Empty : (" (" + CS_0024_003C_003E8__locals0.ord.Instructions + ")")) + text24 + "</div>";
										if (flag4 && source8.Where((PrintToStationOrderObject x) => x.ItemID != CS_0024_003C_003E8__locals9.orderItem.ItemID).Count() > 0)
										{
											text += empty2;
										}
									}
									flag11 = true;
								}
								flag4 = false;
							}
						}
						num2 = CS_0024_003C_003E8__locals9.orderItem.ComboID;
						text2 = CS_0024_003C_003E8__locals9.orderItem.OrderNumber;
						text20 = ((station2.ChitFormat != 6) ? text20.Replace("OPT: ", "+ ") : text20.Replace("Opt: ", ""));
						if ((station2.ChitFormat == 1 || flag7) && station2.ChitFormat != 6)
						{
							if (flag11)
							{
								text = text + (string.IsNullOrEmpty(text20) ? string.Empty : (text20 + "<br />")) + empty;
							}
							continue;
						}
						if (station2.ChitFormat == 2)
						{
							if (!string.IsNullOrEmpty(text))
							{
								text += text20;
								text = (((CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.Delivery || CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.PickUp) && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName)) ? ("<div style=\"font-size:12pt;font-weight:bold;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + " <b>" + CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName + "</b> %ITEM_NUM_PLACEHOLDER%</div>" + text) : ((string.IsNullOrEmpty(text8) || !(SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")) ? ("<div style=\"font-size:12pt;font-weight:normal;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + " <b>" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderNumber + "</b> %ITEM_NUM_PLACEHOLDER%</div>" + text) : ("<div style=\"font-size:12pt;font-weight:bold;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + " **" + text8 + "** %ITEM_NUM_PLACEHOLDER%</div>" + text)));
								if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
								{
									text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
								}
								for (int m = 1; m <= (int)CS_0024_003C_003E8__locals9.orderItem.Qty; m++)
								{
									list5.Add(text);
								}
								text = string.Empty;
								text20 = string.Empty;
							}
							continue;
						}
						if (station2.ChitFormat == 4)
						{
							if (!CS_0024_003C_003E8__locals9.orderItem.Void && !string.IsNullOrEmpty(text))
							{
								string text31 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + "%DATA_BREAK%";
								text31 += "%ITEM_NUM_PLACEHOLDER%%DATA_BREAK%";
								text31 = ((string.IsNullOrEmpty(text8) || !(SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")) ? (text31 + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderNumber) : (text31 + text8));
								text31 += "%DATA_BREAK%";
								text31 = string.Concat(text31, "<span style=\"font-size:7pt;\">DATE: ", CS_0024_003C_003E8__locals9.orderItem.DateCreated, "</span><br>", text7, "%DATA_BREAK%");
								string text32 = $"{num3:C}";
								string text33 = $"{num4:C}";
								string text34 = $"{num5:C}";
								text31 += "SUBTOTAL:";
								for (int n = 0; n < 9 - text32.Length; n++)
								{
									text31 += "&nbsp;";
								}
								text31 += text32;
								text31 += "<br>TAX:";
								for (int num13 = 0; num13 < 14 - text33.Length; num13++)
								{
									text31 += "&nbsp;";
								}
								text31 += text33;
								text31 += "<br><b>TOTAL:";
								for (int num14 = 0; num14 < 12 - text34.Length; num14++)
								{
									text31 += "&nbsp;";
								}
								text31 = text31 + text34 + "</b>%DATA_BREAK%";
								text31 = text31 + (flag5 ? "** PAID **" : "** NOT PAID **") + "%DATA_BREAK%";
								string text35 = CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName + " - " + CS_0024_003C_003E8__locals9.orderItem.Customer + "<br>" + CS_0024_003C_003E8__locals9.orderItem.CustomerInfo + "%DATA_BREAK%";
								if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
								{
									text = text + "%COPY_PLACEHOLDER%<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
								}
								for (int num15 = 1; num15 <= (int)CS_0024_003C_003E8__locals9.orderItem.Qty; num15++)
								{
									list5.Add(text31 + text35 + text + text20);
								}
							}
							text = string.Empty;
							text20 = string.Empty;
							continue;
						}
						if (station2.ChitFormat == 6)
						{
							text = string.Empty;
							if (station2.ChitFormat == 6 && CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn && text11 != CS_0024_003C_003E8__locals9.orderItem.SeatNum.ToString())
							{
								text11 = CS_0024_003C_003E8__locals9.orderItem.SeatNum.ToString();
								text = text + "<div style=\"font-size:" + value + "pt;text-indent:20pt;\">----- Seat " + text11 + "-----</div>";
							}
							string text36 = "";
							string text37 = "";
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.printCancelledItems == "ON" && CS_0024_003C_003E8__locals9.orderItem.Void)
							{
								text36 = "<S>";
								text37 = "</S>";
							}
							text = text + "<div style=\"font-size:" + ((float)value + 1f).ToString() + "pt;font-weight:bold; text-indent:-10pt;\">" + text36 + (int)CS_0024_003C_003E8__locals9.orderItem.Qty + " " + CS_0024_003C_003E8__locals9.orderItem.ItemName.ToTitleCase() + text37 + "</div>";
							if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
							{
								text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
							}
							list5.Add(text + text20);
							text = string.Empty;
							text20 = string.Empty;
							continue;
						}
						if (flag11)
						{
							text += (string.IsNullOrEmpty(text20) ? string.Empty : (text20 + "<br />"));
						}
						if (station2.PrintEachQty)
						{
							decimal d2 = default(decimal);
							List<Order> list10 = gClass.Orders.Where((Order o) => o.ShareItemID == CS_0024_003C_003E8__locals9.orderItem.OrderId).ToList();
							if (list10 != null && list10.Count > 0)
							{
								d2 += CS_0024_003C_003E8__locals9.orderItem.Qty;
								d2 += list10.Sum((Order x) => x.Qty);
							}
							else
							{
								d2 = CS_0024_003C_003E8__locals9.orderItem.Qty;
							}
							for (int num16 = 1; num16 <= (int)Math.Round(d2); num16++)
							{
								list5.Add(text);
							}
						}
						else
						{
							list5.Add(text);
						}
						flag3 = true;
						text = string.Empty;
						text20 = string.Empty;
					}
					else
					{
						if (CS_0024_003C_003E8__locals9.orderItem.ComboID != 0 || (CS_0024_003C_003E8__locals9.orderItem.Void && !CS_0024_003C_003E8__locals9.orderItem.IsModified))
						{
							continue;
						}
						_003C_003Ec__DisplayClass3_9 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass3_9();
						list6.Add(CS_0024_003C_003E8__locals9.orderItem.OrderId);
						CS_0024_003C_003E8__locals1.orderToChange = (from o in gClass.Orders
							where o.OrderId == CS_0024_003C_003E8__locals9.orderItem.OrderId
							select o into x
							orderby x.DateCreated
							select x).FirstOrDefault();
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderToChange.StationPrinted) && CS_0024_003C_003E8__locals1.orderToChange.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.station.ToString()) && !CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
						{
							continue;
						}
						if (isOrderMade && MemoryLoadedObjects.all_stations.Where((Station a) => CS_0024_003C_003E8__locals1.orderToChange.StationID.Split(',').Contains(a.StationID.ToString()) && a.SendToStation).Count() == 0)
						{
							_003C_003Ec__DisplayClass3_10 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass3_10();
							CS_0024_003C_003E8__locals2.stationToMade = StationMethods.AddStationIdFromStationIds(CS_0024_003C_003E8__locals1.orderToChange.StationMade, station2.StationID.ToString());
							CS_0024_003C_003E8__locals1.orderToChange.StationMade = CS_0024_003C_003E8__locals2.stationToMade;
							if (flag2)
							{
								_003C_003Ec__DisplayClass3_11 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass3_11();
								CS_0024_003C_003E8__locals3.orderToChangeListUnder = CS_0024_003C_003E8__locals9.orderItem.OrderIdSharedList.Where((Guid a) => a != CS_0024_003C_003E8__locals9.orderItem.OrderId).ToList();
								gClass.Orders.Where((Order o) => CS_0024_003C_003E8__locals3.orderToChangeListUnder.Contains(o.OrderId)).ToList().ForEach(delegate(Order a)
								{
									a.StationMade = CS_0024_003C_003E8__locals2.stationToMade;
								});
							}
						}
						if (CS_0024_003C_003E8__locals9.orderItem.PrintedInKitchen && !CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.reprint)
						{
							continue;
						}
						if (flag && station2.ChitFormat != 2 && station2.ChitFormat != 4 && (text3 != CS_0024_003C_003E8__locals9.orderItem.ItemCourse || (station2.ChitFormat == 3 && flag3 && !flag7)))
						{
							flag3 = false;
							text3 = CS_0024_003C_003E8__locals9.orderItem.ItemCourse;
							string text38 = ((CS_0024_003C_003E8__locals9.orderItem.ItemCourse.ToUpper() == ItemCourses.Uncategorized.ToUpper()) ? "====================" : (" " + CS_0024_003C_003E8__locals9.orderItem.ItemCourse.ToUpper() + " "));
							int length3 = text38.Length;
							if (length3 < num)
							{
								int num17 = (num - length3) / 2;
								for (int num18 = 0; num18 < num17 - 3; num18++)
								{
									text38 = "=" + text38 + "=";
								}
							}
							text38 = "<span style=\"font-weight:bold;font-size:" + (float)value + "pt;color:red;text-align:center;\">" + text38 + "</span>";
							text += text38;
							text += "<br />";
						}
						string text39 = "";
						string text40 = "";
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.printCancelledItems == "ON")
						{
							if (CS_0024_003C_003E8__locals9.orderItem.Void)
							{
								text39 = "<S>";
								text40 = "</S>";
								text = text + "<span " + text5 + ">*** Item Cancelled *** </span><br />";
							}
							else if (CS_0024_003C_003E8__locals9.orderItem.IsModified)
							{
								text = text + "<span " + text5 + ">*** Item Changed *** </span><br />";
							}
						}
						else if (CS_0024_003C_003E8__locals9.orderItem.IsModified)
						{
							text = text + "<span " + text5 + ">*** Item Changed *** </span><br />";
						}
						if ((station2.ChitFormat == 1 || flag7) && station2.ChitFormat != 6)
						{
							text = text + text39 + ((!flag4) ? string.Empty : (string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Options) ? string.Empty : (" ( " + CS_0024_003C_003E8__locals9.orderItem.Options + ")"))) + ((CS_0024_003C_003E8__locals9.orderItem.Qty == 1m) ? string.Empty : (MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals9.orderItem.Qty) + "x  ")) + CS_0024_003C_003E8__locals9.orderItem.ItemName + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions) ? string.Empty : (" (" + CS_0024_003C_003E8__locals9.orderItem.Instructions + ")")) + text40 + "<br />";
							text = "<span style=\"font-weight: bold;\">" + text + "</span>" + empty;
							continue;
						}
						if (station2.ChitFormat == 2)
						{
							text = (((CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.Delivery || CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.PickUp) && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName)) ? ("<div style=\"font-size:12pt;font-weight:bold;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + " <b>" + CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName + "</b> %ITEM_NUM_PLACEHOLDER%</div>" + CS_0024_003C_003E8__locals9.orderItem.ItemName) : ((string.IsNullOrEmpty(text8) || !(SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")) ? ("<div style=\"font-size:12pt;font-weight:normal;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + " <b>" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderNumber + "</b> %ITEM_NUM_PLACEHOLDER%</div>" + CS_0024_003C_003E8__locals9.orderItem.ItemName) : ("<div style=\"font-size:12pt;font-weight:bold;padding-bottom:3pt;\">" + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + "**" + text8 + "** %ITEM_NUM_PLACEHOLDER%</div>" + CS_0024_003C_003E8__locals9.orderItem.ItemName)));
							if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
							{
								text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
							}
							for (int num19 = 1; num19 <= (int)CS_0024_003C_003E8__locals9.orderItem.Qty; num19++)
							{
								list5.Add(text);
							}
							text = string.Empty;
							continue;
						}
						if (station2.ChitFormat == 4)
						{
							string text41 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType.ToUpper() + "%DATA_BREAK%";
							text41 += "%ITEM_NUM_PLACEHOLDER%%DATA_BREAK%";
							text41 = ((string.IsNullOrEmpty(text8) || !(SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")) ? (text41 + CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderNumber) : (text41 + text8));
							text41 += "%DATA_BREAK%";
							text41 = string.Concat(text41, "<span style=\"font-size:5pt;\">DATE: ", CS_0024_003C_003E8__locals9.orderItem.DateCreated, "</span><br>", text7, "%DATA_BREAK%");
							string text42 = $"{num3:C}";
							string text43 = $"{num4:C}";
							string text44 = $"{num5:C}";
							text41 += "SUBTOTAL:";
							for (int num20 = 0; num20 < 9 - text42.Length; num20++)
							{
								text41 += "&nbsp;";
							}
							text41 += text42;
							text41 += "<br>TAX:";
							for (int num21 = 0; num21 < 14 - text43.Length; num21++)
							{
								text41 += "&nbsp;";
							}
							text41 += text43;
							text41 += "<br><b>TOTAL:";
							for (int num22 = 0; num22 < 12 - text44.Length; num22++)
							{
								text41 += "&nbsp;";
							}
							text41 = text41 + text44 + "</b>%DATA_BREAK%";
							text41 = text41 + (flag5 ? "** PAID **" : "** NOT PAID **") + "%DATA_BREAK%";
							string text45 = CS_0024_003C_003E8__locals9.orderItem.CustomerInfoName + " - " + CS_0024_003C_003E8__locals9.orderItem.Customer + "<br>" + CS_0024_003C_003E8__locals9.orderItem.CustomerInfo + "%DATA_BREAK%";
							if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
							{
								text = text + "%COPY_PLACEHOLDER%<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
							}
							if (!CS_0024_003C_003E8__locals9.orderItem.Void)
							{
								for (int num23 = 1; num23 <= (int)CS_0024_003C_003E8__locals9.orderItem.Qty; num23++)
								{
									list5.Add(text41 + text45 + text + "<b>" + CS_0024_003C_003E8__locals9.orderItem.ItemName + "</b>");
								}
							}
							text = string.Empty;
							continue;
						}
						if (station2.ChitFormat == 6)
						{
							text = string.Empty;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn && text11 != CS_0024_003C_003E8__locals9.orderItem.SeatNum.ToString())
							{
								text11 = CS_0024_003C_003E8__locals9.orderItem.SeatNum.ToString();
								text = text + "<div style=\"font-size:" + value + "pt;text-indent:20pt\">----- Seat " + text11 + "-----</div>";
							}
							text = text + "<div style=\"font-size:" + ((float)value + 1f).ToString() + "pt;font-weight:bold;text-indent:-10pt;\">" + text39 + (int)CS_0024_003C_003E8__locals9.orderItem.Qty + " " + CS_0024_003C_003E8__locals9.orderItem.ItemName.ToTitleCase() + text40 + "</div>";
							if (CS_0024_003C_003E8__locals9.orderItem.Instructions != null && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions.Replace("|", string.Empty).Trim()))
							{
								text = text + "<div style=\"font-size:" + (float)value + "pt;font-weight:normal;padding-top:2pt;\"><I>** " + CS_0024_003C_003E8__locals9.orderItem.Instructions.Trim().ToUpper() + " **</I></div>";
							}
							list5.Add(text);
							text = string.Empty;
							continue;
						}
						text = text + text39 + ((!flag4) ? string.Empty : (string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Options) ? string.Empty : (" ( " + CS_0024_003C_003E8__locals9.orderItem.Options + ")"))) + ((!(CS_0024_003C_003E8__locals9.orderItem.Qty > 1m) || station2.PrintEachQty) ? string.Empty : (MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals9.orderItem.Qty) + "x  ")) + CS_0024_003C_003E8__locals9.orderItem.ItemName + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals9.orderItem.Instructions) ? string.Empty : (" (" + CS_0024_003C_003E8__locals9.orderItem.Instructions + ")")) + text40 + "<br />";
						text = "<span style=\"font-weight: bold;\">" + text + "</span>";
						if (station2.PrintEachQty)
						{
							for (int num24 = 1; num24 <= (int)CS_0024_003C_003E8__locals9.orderItem.Qty; num24++)
							{
								list5.Add(text);
							}
						}
						else
						{
							flag3 = true;
						}
						text = string.Empty;
					}
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
			if (!string.IsNullOrEmpty(text) || list5.Count > 0)
			{
				list5 = list5.Where((string a) => !string.IsNullOrEmpty(a)).ToList();
				int numberOfCopies = 1;
				if (station2 != null)
				{
					numberOfCopies = station2.PrintCopies;
				}
				if (printOnlyOne)
				{
					numberOfCopies = 1;
				}
				string text46 = string.Empty;
				if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint && printOnlyOne)
				{
					int num25 = 20;
					string text47 = "<br />";
					if (station2.ChitFormat == 2)
					{
						text47 = "";
						num25 = 8;
					}
					text46 = "<span style=\"font-size:" + num25 + "pt; font-weight:bold;\">*COPY*</span>" + text47;
				}
				string text48 = string.Empty;
				if (!string.IsNullOrEmpty(text8) && SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")
				{
					text48 = "<span style=\"font-size:26pt; font-weight:bold;\">** " + text8 + " **</span>";
				}
				if ((station2.ChitFormat == 1 || flag7) && station2.ChitFormat != 6)
				{
					text = "<span style=\"font-size:" + value + "pt;\" >" + text + "</span>";
					string message = BuildStringDefaultChit(station2.ChitFormat, text7, flag5, value, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType, text5, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, text48, string.Empty, employee, text4, customer, text, text46, customerInfo, seatNum, orderNotes);
					new PrintHelper().QueueChit(message, value, station2, DateTime.Now, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, numberOfCopies, list6, list);
				}
				else if (station2.ChitFormat != 2 && station2.ChitFormat != 4)
				{
					if (station2.ChitFormat == 5)
					{
						string text49 = "<div style=\"font-size:16pt;text-align:center;\">ORDER SUMMARY</div><br/>";
						text49 = text49 + "<div style=\"font-size:16pt;text-align:center;color:red;\">" + customer + "</div><br/><br/><br/>";
						string text50 = ((!string.IsNullOrEmpty(customerInfoName)) ? customerInfoName : customerInfo);
						text49 = text49 + "<div style=\"font-size:16pt;text-align:center;\">" + text50 + "</div><br/>";
						text49 += text;
						new PrintHelper().QueueChit(text49, value, station2, DateTime.Now, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, numberOfCopies, list6, list);
					}
					else if (station2.ChitFormat == 6)
					{
						int num26 = value;
						int num27 = value + 3;
						int num28 = value + 3;
						string text51 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber;
						if ((CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType.Contains("Online") || SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON") && !string.IsNullOrEmpty(text8))
						{
							text51 = text8;
						}
						string text52 = employee;
						if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType.Contains("Online"))
						{
							text52 = employee.ToTitleCase();
						}
						string text53 = "";
						if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.reprint)
						{
							text53 = text53 + "<span style=\"font-size:" + value + "pt; font-weight:bold;\">*COPY*</span><br/>";
						}
						text53 = text53 + "<div style=\"font-size:" + num27 + "pt;\">Order # " + text51 + "</div>";
						text53 = text53 + "<div style=\"font-size:" + num27 + "pt;\">Customer: " + customerInfoName + "</div>";
						int result = 0;
						if (text9.Length == 10 && int.TryParse(text9, out result))
						{
							text9 = result.ToString("(###) ###-####");
						}
						text53 = text53 + "<div style=\"font-size:" + num27 + "pt;\">Phone # " + text9 + "</div>";
						if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType != OrderTypes.DineIn)
						{
							text53 += "<div style=\"font-size:10pt;\">==============================</div>";
							text53 = ((!flag5) ? (text53 + "<div style=\"font-size:" + num27 + "pt;font-weight: 800;\">**UN PAID**</div>") : (text53 + "<div style=\"font-size:" + num27 + "pt;font-weight: 800;\">**PAID**</div>"));
							text53 += "<div style=\"font-size:10pt;\">==============================</div>";
						}
						text53 += "%DATA_BREAK%";
						if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.DineIn)
						{
							text53 = text53 + "<div style=\"font-size:" + num28 + "pt; font-weight: 800;padding-bottom:20pt;\">Table # " + CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.TableName.Replace("Table", string.Empty) + "</div>";
						}
						else
						{
							string text54 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType;
							if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType.Contains("Online"))
							{
								text54 = text52;
								if (!string.IsNullOrEmpty(source4) && source4.ToUpper() == OnlineOrderSource.Deliverect.ToUpper() && (subSource.ToUpper() == OnlineOrderSource.Deliverect.ToUpper() || string.IsNullOrEmpty(subSource)))
								{
									text54 = "Online Order";
								}
							}
							text53 = text53 + "<div style=\"font-size:" + num28 + "pt;font-weight: 800;\">" + text54 + " " + text8 + "</div>";
							text53 = ((!(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType == OrderTypes.ToGo)) ? (text53 + "<div style=\"font-size:" + num28 + "pt;font-weight: 800;\">Pickup Time " + text10 + "</div>") : (text53 + "<br/>"));
						}
						text53 += "%DATA_BREAK%";
						text53 += "<br/>";
						foreach (string item3 in list5)
						{
							text53 += item3;
						}
						text53 += "<div style=\"font-size:10pt;\">==============================</div>";
						if (CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType.Contains("Online"))
						{
							if (!string.IsNullOrEmpty(source4) && source4.ToUpper() == OnlineOrderSource.Deliverect.ToUpper() && (subSource.ToUpper() == OnlineOrderSource.Deliverect.ToUpper() || string.IsNullOrEmpty(subSource)))
							{
								employee = "Online Order";
							}
							text53 = text53 + "<div style=\"font-size:" + num26 + "pt;\">" + employee + " " + text4 + "</div>";
						}
						else
						{
							text53 = text53 + "<div style=\"font-size:" + num26 + "pt;\">SVR: " + employee + " " + text4 + "</div>";
						}
						new PrintHelper().QueueChit(text53, value, station2, DateTime.Now, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, numberOfCopies, list6, list);
					}
					else
					{
						int num29 = 1;
						string empty6 = string.Empty;
						foreach (string item4 in list5)
						{
							if (!string.IsNullOrEmpty(item4))
							{
								string itemString = "<span style=\"font-size:" + value + "pt;\" >" + item4 + "</span>";
								string orderNumber2 = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber;
								string orderTicketString = text48;
								empty6 = "<span style=\"font-size:14pt; font-weight:bold; color:red;\">" + num29 + " OF " + list5.Count + "</span><br/>";
								string message2 = BuildStringDefaultChit(station2.ChitFormat, text7, flag5, value, CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderType, text5, orderNumber2, orderTicketString, empty6, employee, text4, customer, itemString, text46, customerInfo, seatNum, orderNotes);
								new PrintHelper().QueueChit(message2, value, station2, DateTime.Now.AddMilliseconds(num29 * 300), CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, numberOfCopies, list6, list);
							}
							num29++;
						}
					}
				}
				else
				{
					int num30 = 1;
					foreach (string item5 in list5)
					{
						string newValue = ((station2.ChitFormat != 2) ? (num30 + " of " + list5.Count) : (" <span style=\"font-size:" + value.ToString() + "pt; font-weight:bold; color:red;\"> " + num30 + " / " + list5.Count + "</span>" + text46));
						newValue = item5.Replace("%ITEM_NUM_PLACEHOLDER%", newValue).Replace("%COPY_PLACEHOLDER%", text46);
						new PrintHelper().QueueChit(newValue, value, station2, DateTime.Now.AddMilliseconds(num30 * 300), CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1.orderNumber, numberOfCopies, list6, list);
						num30++;
					}
				}
			}
			gClass.Refresh(RefreshMode.OverwriteCurrentValues);
			CS_0024_003C_003E8__locals4.orderIDs = list2.Select((PrintToStationOrderObject x) => x.OrderId).ToList();
			foreach (Order item6 in gClass.Orders.Where((Order x) => CS_0024_003C_003E8__locals4.orderIDs.Contains(x.OrderId)).ToList())
			{
				if (!item6.Void && !item6.IsModified)
				{
					continue;
				}
				string[] array = item6.StationID.Replace(" ", string.Empty).Split(',');
				bool flag12 = true;
				if (string.IsNullOrEmpty(item6.StationPrinted))
				{
					continue;
				}
				string[] array2 = array;
				foreach (string text55 in array2)
				{
					string[] array3 = item6.StationPrinted.Replace(" ", string.Empty).Split(',');
					for (int num32 = 0; num32 < array3.Length; num32++)
					{
						array3[num32] = " " + array3[num32] + " ";
					}
					if (!array3.Contains(" " + text55 + " "))
					{
						flag12 = false;
					}
				}
				if (flag12)
				{
					item6.IsModified = false;
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
			GC.Collect();
			list2 = null;
			gClass = null;
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gClass.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
		}
	}

	public PrintToStationOrderObject PutOrderToPrintToStationObject(Order a)
	{
		return new PrintToStationOrderObject
		{
			OrderId = a.OrderId,
			OrderNumber = a.OrderNumber,
			ComboID = a.ComboID,
			PrintedInKitchen = a.PrintedInKitchen,
			Void = a.Void,
			DateFilled = a.DateFilled,
			FulfillmentAt = a.FulfillmentAt,
			DateCleared = a.DateCleared,
			DateCreated = a.DateCreated,
			DatePaid = a.DatePaid,
			StationID = a.StationID,
			DateRefunded = a.DateRefunded,
			TaxChangeReason = a.TaxChangeReason,
			Customer = a.Customer,
			CustomerInfoName = a.CustomerInfoName,
			CustomerInfoPhone = a.CustomerInfoPhone,
			CustomerID = a.CustomerID,
			Discount = a.Discount,
			DiscountDesc = a.DiscountDesc,
			ItemName = a.ItemName,
			ItemID = a.ItemID,
			Qty = a.Qty,
			SubTotal = a.SubTotal,
			TaxTotal = a.TaxTotal,
			Total = a.Total,
			Instructions = a.Instructions,
			Options = a.Options,
			ItemCourse = a.ItemCourse,
			IsModified = a.IsModified,
			Paid = a.Paid,
			OrderOnHoldTime = a.OrderOnHoldTime,
			OrderType = a.OrderType,
			FlagID = a.FlagID,
			ShareItemID = a.ShareItemID,
			OrderTicketNumber = a.OrderTicketNumber,
			CustomerInfo = a.CustomerInfo,
			SeatNum = a.SeatNum,
			StationPrinted = a.StationPrinted,
			StationMade = a.StationMade,
			StationNotified = a.StationNotified,
			OrderNotes = a.OrderNotes,
			ItemIdentifier = a.ItemIdentifier
		};
	}

	public string BuildStringDefaultChit(int chitFormat, string PickUpTime, bool isPaid, int fontSize, string orderType, string BigFontStyle, string orderNumber, string orderTicketString, string pageNumber, string employee, string orderDate, string customer, string itemString, string copyString, string deliveryAddress, string seatNum, string orderNotes)
	{
		string text = string.Empty;
		string text2 = "";
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			text2 = "<br/><span style=\"font-size:15pt;\">*** TRAINING MODE ***</span><br/>";
		}
		if (string.IsNullOrEmpty(orderType))
		{
			orderType = "To-Go";
		}
		if (!string.IsNullOrEmpty(customer))
		{
			customer = customer.ToUpper();
			if ((chitFormat == 1 || chitFormat == 3) && (customer.Contains("UBER") || customer.Contains("SKIP") || customer.Contains("DELIVEREC")))
			{
				text = "<br/><span style=\"font-size:16pt;font-weight:bold;\">" + customer + "</span><br/>";
			}
			if (chitFormat == 3)
			{
				customer = "<span style=\"font-size:13pt;\">" + customer + "</span>";
			}
			if (orderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In" && SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF")
			{
				customer = customer + "<br/><span style=\"font-size:13pt;\">SEAT " + seatNum + "</span>";
			}
		}
		if (!string.IsNullOrEmpty(employee))
		{
			employee = employee.Trim();
		}
		if (!string.IsNullOrEmpty(orderTicketString))
		{
			orderTicketString += "<br />";
		}
		if (string.IsNullOrEmpty(pageNumber))
		{
			pageNumber = "<br/>";
		}
		string text3 = "";
		if (!orderType.ToUpper().Contains("DINE IN"))
		{
			text3 = "color: red;";
		}
		string text4 = "";
		text4 = ((chitFormat != 1) ? "" : "<br /><br /><br /><br /><br />");
		deliveryAddress = ((!(orderType == OrderTypes.Delivery)) ? string.Empty : ("<br/><span style=\"font-weight:bold;font-size:10pt;padding-bottom:4pt;\">" + deliveryAddress + "</span>"));
		string text5 = "";
		if (!string.IsNullOrEmpty(orderNotes))
		{
			text5 = "<br/><span style=\"font-weight:bold;font-size:11pt;padding-bottom:4pt;color: red;\">NOTES: " + orderNotes + "</span>";
		}
		string text6 = "";
		text6 = ((!(orderType == OrderTypes.DineIn) || !(SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")) ? ("<span " + (string.IsNullOrEmpty(orderTicketString) ? " style =\"font-weight:bold;font-size:13pt;\"" : string.Empty) + ">" + Resources.Order.ToUpper() + " #: " + orderNumber + "</span><br />") : "");
		return text4 + text2 + copyString + PickUpTime + (isPaid ? "<p style=\"text-indent:40pt;font-weight:bold;color:#fe0303;font-size:16pt;padding-bottom:4pt;\" >** PAID **</p>" : string.Empty) + "<span style=\"font-weight:bold;font-size:14pt;" + text3 + "\" >** " + orderType.Replace("Take-Out", "Pick-Up").ToUpper() + " **</span>" + text + deliveryAddress + "<br/>" + pageNumber + orderTicketString + text6 + "<span style=\"font-size:12pt;\">SVR: " + employee + ", " + orderDate + "</span><br /><span style=\"font-weight:bold;font-size:14pt;padding:0;margin:0;word-wrap:break-word;\" >" + Resources.Customer.ToUpper().Substring(0, 4) + ": " + customer + "</span>" + text5 + "<br/>" + itemString + "<br /><br />";
	}

	public bool PrintEachChitOnlyOne(Station station, List<PrintToStationOrderObject> ord)
	{
		bool result = false;
		if (ord.Where((PrintToStationOrderObject a) => a.Qty >= 10m).Count() > 0 && station.PrintEachQty && station.ChitFormat == 3)
		{
			result = new frmMessageBox("Do you want to print just 1 " + station.StationName + " chit?", "Large Order Qty", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes;
		}
		return result;
	}

	public void ChangePrintedInKitchenAndOrderStationMade(string orderNumber, string orderType)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		GClass6 gClass = new GClass6();
		InventoryMethods inventoryMethods = new InventoryMethods();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_chit_cashout");
		IQueryable<Order> source = gClass.Orders.Where((Order x) => x.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderNumber.ToUpper()) && x.DateCreated.Value.Date >= DateTime.Now.AddDays(-15.0).Date);
		if (settingValueByKey == "ON" && (orderType == OrderTypes.DineIn || orderType == OrderTypes.ToGo))
		{
			source = source.Where((Order a) => a.Paid == true);
		}
		if (SettingsHelper.GetSettingValueByKey("print_chit_change_cancel") == "OFF")
		{
			source = source.Where((Order a) => a.Void == false || (a.FlagID != 4 && a.FlagID != 3));
		}
		source = source.Where((Order o) => o.OrderOnHoldTime == 0 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value <= DateTime.Now.AddMinutes(-o.OrderOnHoldTime)) || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline || o.OrderType == OrderTypes.PickUp);
		foreach (Order item in source.ToList())
		{
			item.PrintedInKitchen = true;
			if ((!string.IsNullOrEmpty(item.StationID) && !string.IsNullOrEmpty(item.StationMade) && item.StationMade.Split(',').Count() == item.StationID.Split(',').Count()) || (string.IsNullOrEmpty(item.StationID) && string.IsNullOrEmpty(item.StationMade)))
			{
				if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
				{
					item.DateFilled = DateTime.Now;
					inventoryMethods.AddItemInventory(item, "MAKE TO STOCK");
					inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: false);
					item.Paid = true;
					item.DatePaid = DateTime.Now;
					item.DateCleared = DateTime.Now;
					item.PaymentMethods = "MAKE TO STOCK=0.00|";
				}
				else if (!item.Void && !item.DateFilled.HasValue)
				{
					item.DateFilled = DateTime.Now;
					inventoryMethods.SubtractMaterialInventory(item);
					inventoryMethods.SubtractItemInventory(item);
					inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: true);
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public void OrderMade(string orderNumber, int station)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.station = station;
		try
		{
			OrderMethods orderMethods = new OrderMethods();
			new InventoryMethods();
			new GClass6();
			using (List<Order>.Enumerator enumerator = (from o in orderMethods.Orders(orderNumber.ToUpper())
				where o.StationID.Contains(CS_0024_003C_003E8__locals0.station.ToString()) && !o.DateFilled.HasValue
				select o into x
				orderby x.DateCreated
				select x).ToList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_1();
					CS_0024_003C_003E8__locals1.orderItem = enumerator.Current;
					if (CS_0024_003C_003E8__locals1.orderItem.ComboID != 0)
					{
						foreach (Order item in (from o in orderMethods.UnfilledOrders((short)CS_0024_003C_003E8__locals0.station)
							where o.ComboID == CS_0024_003C_003E8__locals1.orderItem.ComboID && o.OrderNumber == CS_0024_003C_003E8__locals1.orderItem.OrderNumber && !o.DateFilled.HasValue
							select o into x
							orderby x.DateCreated
							select x).ToList())
						{
							if (!item.Void)
							{
								item.StationMade = StationMethods.AddStationIdFromStationIds(item.StationMade, CS_0024_003C_003E8__locals0.station.ToString());
							}
							orderMethods.SubmitChanges();
						}
					}
					else if (!CS_0024_003C_003E8__locals1.orderItem.Void)
					{
						CS_0024_003C_003E8__locals1.orderItem.StationMade = StationMethods.AddStationIdFromStationIds(CS_0024_003C_003E8__locals1.orderItem.StationMade, CS_0024_003C_003E8__locals0.station.ToString());
					}
				}
			}
			orderMethods.SubmitChanges();
		}
		catch (Exception ex)
		{
			if (ex.Message.ToLower().Contains("row not found"))
			{
				OrderMade(orderNumber, CS_0024_003C_003E8__locals0.station);
			}
		}
	}

	public void RecordBatchId(string _OrderNumber = null, string orderType = "Dine In", Form frm = null, int tries = 1)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_._OrderNumber = _OrderNumber;
		_003C_003Ec__DisplayClass9_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass9_.frm = frm;
		_003C_003Ec__DisplayClass9_.tries = tries;
		_003C_003Ec__DisplayClass9_.orderType = orderType;
		new Thread((ThreadStart)delegate
		{
			try
			{
				GClass6 gClass = new GClass6();
				List<Order> list = null;
				if (_003C_003Ec__DisplayClass9_._OrderNumber != null)
				{
					list = gClass.Orders.Where((Order o) => o.OrderNumber == _003C_003Ec__DisplayClass9_._OrderNumber && o.Paid == true && o.Void == false && o.DateCleared == null && (o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline)).ToList();
				}
				if (list.Count() > 0)
				{
					int num = 0;
					using (List<Order>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_1();
							CS_0024_003C_003E8__locals0.order = enumerator.Current;
							Item item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
							if (item != null && item.TrackExpiryDate && (!CS_0024_003C_003E8__locals0.order.InventoryBatchId.HasValue || (CS_0024_003C_003E8__locals0.order.InventoryBatchId.HasValue && CS_0024_003C_003E8__locals0.order.InventoryBatchId.Value == 0)))
							{
								int value = _003C_003Ec__DisplayClass9_._003C_003E4__this.CheckAndSelectBatchId(item.ItemID);
								CS_0024_003C_003E8__locals0.order.InventoryBatchId = value;
								num++;
							}
						}
					}
					if (num > 0)
					{
						Helper.SubmitChangesWithCatch(gClass);
					}
					if (_003C_003Ec__DisplayClass9_.frm != null)
					{
						_003C_003Ec__DisplayClass9_.frm.Invoke((Action)delegate
						{
							MiscHelper.MakeOrderIsModified(_003C_003Ec__DisplayClass9_.frm, _003C_003Ec__DisplayClass9_._OrderNumber);
						});
					}
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				_003C_003Ec__DisplayClass9_.tries++;
				if (_003C_003Ec__DisplayClass9_.tries <= 3)
				{
					_003C_003Ec__DisplayClass9_._003C_003E4__this.RecordBatchId(_003C_003Ec__DisplayClass9_._OrderNumber, _003C_003Ec__DisplayClass9_.orderType, _003C_003Ec__DisplayClass9_.frm, _003C_003Ec__DisplayClass9_.tries);
				}
			}
		}).Start();
	}

	public void ClearOrder(string _OrderNumber = null, string orderType = "Dine In", Form frm = null, int tries = 1)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_._OrderNumber = _OrderNumber;
		_003C_003Ec__DisplayClass10_.orderType = orderType;
		_003C_003Ec__DisplayClass10_.frm = frm;
		_003C_003Ec__DisplayClass10_.tries = tries;
		_003C_003Ec__DisplayClass10_._003C_003E4__this = this;
		new Thread((ThreadStart)delegate
		{
			try
			{
				GClass6 gClass = new GClass6();
				if (_003C_003Ec__DisplayClass10_._OrderNumber != null)
				{
					List<Order> list = gClass.Orders.Where((Order o) => o.OrderNumber == _003C_003Ec__DisplayClass10_._OrderNumber && o.Paid == true && o.Void == false && o.DateCleared == null).ToList();
					string text = null;
					foreach (Order item in list)
					{
						item.Synced = false;
						item.DateCleared = DateTime.Now;
						if (text == null)
						{
							text = item.Source;
						}
					}
					Helper.SubmitChangesWithCatch(gClass);
					if (_003C_003Ec__DisplayClass10_.orderType == OrderTypes.DeliveryOnline || _003C_003Ec__DisplayClass10_.orderType == OrderTypes.PickUpOnline || _003C_003Ec__DisplayClass10_.orderType == OrderTypes.PickUpCurbsideOnline || _003C_003Ec__DisplayClass10_.orderType == OrderTypes.DineInOnline)
					{
						_ = SyncMethods.UpdateOrderStatusInOrdering(_003C_003Ec__DisplayClass10_._OrderNumber, "Completed", string.Empty, string.Empty, text).code;
					}
					if (_003C_003Ec__DisplayClass10_.frm != null)
					{
						_003C_003Ec__DisplayClass10_.frm.Invoke((Action)delegate
						{
							MiscHelper.MakeOrderIsModified(_003C_003Ec__DisplayClass10_.frm, _003C_003Ec__DisplayClass10_._OrderNumber);
						});
					}
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog(ex.Message + " " + ex.StackTrace, LogTypes.error_log);
				_003C_003Ec__DisplayClass10_.tries++;
				if (_003C_003Ec__DisplayClass10_.tries <= 3)
				{
					_003C_003Ec__DisplayClass10_._003C_003E4__this.ClearOrder(_003C_003Ec__DisplayClass10_._OrderNumber, _003C_003Ec__DisplayClass10_.orderType, _003C_003Ec__DisplayClass10_.frm, _003C_003Ec__DisplayClass10_.tries);
				}
			}
		}).Start();
	}

	public void UpdateOrderStatusInOrdering(Order order, bool isSingleOrder)
	{
		if (order == null || order.DateRefunded.HasValue || (!(order.OrderType == OrderTypes.DeliveryOnline) && !(order.OrderType == OrderTypes.PickUpOnline) && !(order.OrderType == OrderTypes.PickUpCurbsideOnline) && !(order.OrderType == OrderTypes.DineInOnline)))
		{
			return;
		}
		SyncMethods.UpdateOrderStatusInOrdering(order.OrderNumber, "OrderMade", isSingleOrder ? order.OrderId.ToString() : string.Empty, string.Empty, order.Source);
		if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" || SettingsHelper.CurrentTerminalMode == "KitchenDisplay" || SettingsHelper.CurrentTerminalMode == "BarDisplay")
		{
			string status = "ReadyForPickup";
			if (order.OrderType == OrderTypes.DeliveryOnline)
			{
				status = "ReadyForDelivery";
			}
			SyncMethods.UpdateOrderStatusInOrdering(order.OrderNumber, status, isSingleOrder ? order.OrderId.ToString() : string.Empty, string.Empty, order.Source);
		}
	}

	public int CheckAndSelectBatchId(int itemId)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		GClass6 gClass = new GClass6();
		int result = 0;
		CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.item != null && CS_0024_003C_003E8__locals0.item.TrackExpiryDate && CS_0024_003C_003E8__locals0.item.TrackInventory && gClass.InventoryBatches.Where((InventoryBatch a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && a.ExpiryDate >= DateTime.Now && a.QTYRemaining > 0m).Count() > 0)
		{
			frmSelectInventoryBatch frmSelectInventoryBatch2 = new frmSelectInventoryBatch(CS_0024_003C_003E8__locals0.item.ItemID);
			if (frmSelectInventoryBatch2.ShowDialog() == DialogResult.OK)
			{
				result = frmSelectInventoryBatch2.BatchId;
			}
		}
		return result;
	}

	public int CheckAndSelectBatchId(Item item)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.item = item;
		GClass6 gClass = new GClass6();
		int result = 0;
		if (CS_0024_003C_003E8__locals0.item.TrackExpiryDate && CS_0024_003C_003E8__locals0.item.TrackInventory && gClass.InventoryBatches.Where((InventoryBatch a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && a.ExpiryDate >= DateTime.Now && a.QTYRemaining > 0m).Count() > 0)
		{
			frmSelectInventoryBatch frmSelectInventoryBatch2 = new frmSelectInventoryBatch(CS_0024_003C_003E8__locals0.item.ItemID);
			if (frmSelectInventoryBatch2.ShowDialog() == DialogResult.OK)
			{
				result = frmSelectInventoryBatch2.BatchId;
			}
		}
		return result;
	}

	public bool CheckBatchQty(int batchId, decimal qty)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.batchId = batchId;
		if (new GClass6().InventoryBatches.Where((InventoryBatch a) => a.Id == CS_0024_003C_003E8__locals0.batchId).FirstOrDefault().QTYRemaining < qty)
		{
			return false;
		}
		return true;
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

	public static string UpdateDiscountFromDiscountDescription(string DiscountDesc, string DiscountType, decimal value)
	{
		string text = "";
		if (DiscountDesc == null || !DiscountDesc.Contains(DiscountType))
		{
			text = ((!(value > 0m)) ? DiscountDesc : (DiscountDesc + DiscountType + "=" + value.ToString("0.000", Thread.CurrentThread.CurrentCulture) + "|"));
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
						text = text + text2.Split('=')[0] + "=" + value.ToString("0.000", Thread.CurrentThread.CurrentCulture) + "|";
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

	public void TakeOutDeliveryFlow(string orderType, bool bool_0, Form parentForm, bool showOpenOrder = false)
	{
		Dictionary<DialogResult, string> dictionary = new Dictionary<DialogResult, string>();
		dictionary.Add(DialogResult.Yes, "NOW");
		dictionary.Add(DialogResult.No, "LATER");
		int orderOnHoldTime = 0;
		bool flag = true;
		bool flag2 = false;
		string text = string.Empty;
		DateTime? dateTime = null;
		DateTime dateTime2 = DateTime.Now;
		switch (new frmEitherOrSelector("Fulfillment", dictionary, showOpenOrder).ShowDialog(parentForm))
		{
		case DialogResult.No:
		{
			DateTime value = DateTime.Now.Date.AddDays(7.0);
			if (orderType == OrderTypes.Catering)
			{
				value = DateTime.Now.AddMonths(6);
			}
			frmSelectDateAndTime frmSelectDateAndTime2 = new frmSelectDateAndTime("SELECT FULFILLMENT DATE", value, orderType);
			if (frmSelectDateAndTime2.ShowDialog(parentForm) == DialogResult.Cancel)
			{
				TakeOutDeliveryFlow(orderType, bool_0, parentForm, showOpenOrder);
				return;
			}
			dateTime2 = new DateTime(frmSelectDateAndTime2.returnDate.Year, frmSelectDateAndTime2.returnDate.Month, frmSelectDateAndTime2.returnDate.Day, frmSelectDateAndTime2.returnTime.Hour, frmSelectDateAndTime2.returnTime.Minute, frmSelectDateAndTime2.returnTime.Second);
			if (dateTime2 < DateTime.Now.AddMinutes(-1.0))
			{
				text = "Date && Time selected is earlier than current time. Order will not be held.";
				flag = false;
				flag2 = true;
			}
			else if (orderType != OrderTypes.Catering && dateTime2.Date > DateTime.Now.Date.AddDays(7.0))
			{
				text = "Fulfillment date can only be up to 7 Days in advanced.";
				flag = false;
				flag2 = true;
			}
			else if (dateTime2 >= DateTime.Now)
			{
				_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
				GClass6 gClass = new GClass6();
				CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
				CS_0024_003C_003E8__locals0.dayOfWeek = currentCulture.DateTimeFormat.GetDayName(dateTime2.DayOfWeek).ToString().ToUpper();
				DateTime date = dateTime2.Date;
				DateTime date2 = dateTime2.Date;
				bool flag3 = false;
				foreach (BusinessHour item in gClass.BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek.ToUpper() == CS_0024_003C_003E8__locals0.dayOfWeek))
				{
					date = Convert.ToDateTime(dateTime2.ToLongDateString() + " " + item.LatestOpeningTime);
					date2 = Convert.ToDateTime(dateTime2.ToLongDateString() + " " + item.LatestClosingTime);
					if (date2 < date)
					{
						date2 = date2.AddDays(1.0);
					}
					if (dateTime2 >= date && dateTime2 <= date2)
					{
						flag3 = true;
					}
				}
				if (!flag3 && new frmMessageBox("Store is closed during the Date && Time selected, proceed anyways?", "STORE CLOSED", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
				{
					return;
				}
			}
			else
			{
				flag = false;
			}
			break;
		}
		case DialogResult.Abort:
			if (SettingsHelper.GetSettingValueByKey("quick_service_view") == "tile")
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
				MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL", showOEOnClose: false);
				MemoryLoadedObjects.QuickService.Show();
				MemoryLoadedObjects.QuickService.Focus();
			}
			else
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickServiceListView();
				MemoryLoadedObjects.QuickServiceListView.LoadFormData(showOEOnClose: false);
				MemoryLoadedObjects.QuickServiceListView.Show();
				MemoryLoadedObjects.QuickServiceListView.Focus();
			}
			return;
		case DialogResult.Cancel:
		{
			frmOrderEntry frmOrderEntry2 = (frmOrderEntry)Application.OpenForms["frmOrderEntry"];
			frmOrderEntry2?.HideOrderEntry();
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
			{
				frmQuickService frmQuickService2 = (frmQuickService)Application.OpenForms["frmQuickService"];
				frmQuickServiceListView frmQuickServiceListView2 = (frmQuickServiceListView)Application.OpenForms["frmQuickServiceListView"];
				if (((frmQuickService2 != null && !frmQuickService2.Visible) || frmQuickService2 == null) && ((frmQuickServiceListView2 != null && !frmQuickServiceListView2.Visible) || frmQuickServiceListView2 == null) && ((frmOrderEntry2 != null && !frmOrderEntry2.Visible) || frmOrderEntry2 == null))
				{
					AuthMethods.LogOutUser();
				}
			}
			return;
		}
		default:
			flag = false;
			break;
		}
		if (!flag2)
		{
			if (flag)
			{
				DateTime now = DateTime.Now;
				DateTime dateTime3 = now.AddSeconds(-now.Second);
				dateTime = dateTime2;
				orderOnHoldTime = (int)(dateTime2 - dateTime3).TotalMinutes;
				text = ((dateTime2.Date == DateTime.Now.Date) ? "today at " : dateTime2.ToShortDateString()) + " " + dateTime2.ToShortTimeString();
				text = "Order will be held until " + text;
			}
			string number = string.Empty;
			if (MemoryLoadedObjects.callerID.DateCreated.AddMinutes(1.0) > DateTime.Now)
			{
				number = MemoryLoadedObjects.callerID.Number;
			}
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Customer_Phone_Number, 0, 10, number, string.Empty, allowNegative: false, useNotifLabel: false, isPhoneShowInOE: true);
			if (MemoryLoadedObjects.Numpad.ShowDialog(parentForm) == DialogResult.OK)
			{
				string text2 = MemoryLoadedObjects.Numpad.numberEntered.ToString("0");
				if (text2.Length == 0)
				{
					text2 = DateTime.Now.ToString("yyMMDDhhmm");
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.CustomersMini();
				MemoryLoadedObjects.CustomersMini.LoadFormData(text2, orderType, bool_0);
				MemoryLoadedObjects.CustomersMini.orderOnHoldTime = orderOnHoldTime;
				MemoryLoadedObjects.CustomersMini.FulfillmentDate = dateTime;
				switch (MemoryLoadedObjects.CustomersMini.ShowDialog(parentForm))
				{
				case DialogResult.Ignore:
					MemoryLoadedObjects.OrderEntry.isSaved = false;
					MemoryLoadedObjects.OrderEntry.orderOnHoldTime = orderOnHoldTime;
					MemoryLoadedObjects.OrderEntry.dateFullfilment = dateTime;
					MemoryLoadedObjects.OrderEntry.Show();
					break;
				case DialogResult.OK:
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
					MemoryLoadedObjects.OrderEntry.LoadFormData(null, MemoryLoadedObjects.CustomersMini.returnCell, orderType, 1, MemoryLoadedObjects.CustomersMini.returnCustomerId, MemoryLoadedObjects.CustomersMini.returnName, (orderType == OrderTypes.Delivery) ? MemoryLoadedObjects.CustomersMini.returnAddress : string.Empty, resetComboId: true, 1);
					MemoryLoadedObjects.OrderEntry.orderOnHoldTime = orderOnHoldTime;
					MemoryLoadedObjects.OrderEntry.dateFullfilment = dateTime;
					MemoryLoadedObjects.OrderEntry.isSaved = false;
					MemoryLoadedObjects.OrderEntry.Show();
					break;
				case DialogResult.Yes:
					MemoryLoadedObjects.OrderEntry.isSaved = false;
					MemoryLoadedObjects.OrderEntry.orderOnHoldTime = orderOnHoldTime;
					MemoryLoadedObjects.OrderEntry.dateFullfilment = dateTime;
					break;
				default:
					text = string.Empty;
					TakeOutDeliveryFlow(orderType, bool_0, parentForm, showOpenOrder);
					break;
				}
			}
			else
			{
				text = string.Empty;
				TakeOutDeliveryFlow(orderType, bool_0, parentForm, showOpenOrder);
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			new NotificationLabel(parentForm, text, NotificationTypes.Notification).Show();
		}
	}

	public static void DuplicateOrder(List<GlobalOrderHistoryObjects.Order> orders, GlobalOrderHistoryObjects.CustomerInfo customerInfo, string orderNumber, string newOrderType, short empID, bool copyCustomerAddress = true, int orderOnHoldTime = 0, DateTime? FulfillmentDate = null)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		GClass6 gClass = new GClass6();
		List<Reason> source = gClass.Reasons.Where((Reason a) => a.ReasonType == ReasonTypes.option_tab).ToList();
		int num = 0;
		int num2 = 0;
		CS_0024_003C_003E8__locals0.mainItemId = 0;
		CS_0024_003C_003E8__locals0.childMainItemId = 0;
		decimal num3 = default(decimal);
		int num4 = 0;
		int num5 = 0;
		decimal num6 = default(decimal);
		decimal num7 = default(decimal);
		List<Order> list = new List<Order>();
		List<Order> list2 = new List<Order>();
		Order order = null;
		bool flag = false;
		int num8 = 0;
		var source2 = from a in orders
			where a.item_identifier_string == "MainItem"
			group a by new { a.item_identifier_string, a.combo_id };
		if (source2.Where(a => a.Count() > 1).Any())
		{
			_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass18_1();
			CS_0024_003C_003E8__locals1.toCorrectComboId = (from a in source2
				where a.Count() > 1
				select a.Key.combo_id).First();
			short num9 = 100;
			foreach (GlobalOrderHistoryObjects.Order item in from a in orders
				where a.combo_id == CS_0024_003C_003E8__locals1.toCorrectComboId
				orderby a.date_created
				select a)
			{
				if (item.item_identifier_string == "MainItem")
				{
					num9 = (short)(num9 + 1);
				}
				item.combo_id += num9;
			}
		}
		CS_0024_003C_003E8__locals0.orderToIterate = orders.OrderBy((GlobalOrderHistoryObjects.Order x) => x.date_created).ThenBy((GlobalOrderHistoryObjects.Order a) => a.combo_id).ThenBy((GlobalOrderHistoryObjects.Order a) => (a.item_identifier_string == "MainItem") ? 1 : 2)
			.ToList();
		CS_0024_003C_003E8__locals0.items = MemoryLoadedData.all_items.Where((Item x) => CS_0024_003C_003E8__locals0.orderToIterate.Select((GlobalOrderHistoryObjects.Order y) => y.item_barcode).Contains(x.Barcode) || CS_0024_003C_003E8__locals0.orderToIterate.Select((GlobalOrderHistoryObjects.Order y) => y.item_id).Contains(x.ItemID)).ToList();
		List<ItemsInGroup> source3 = MemoryLoadedObjects.all_itemsInGroups.Where((ItemsInGroup x) => CS_0024_003C_003E8__locals0.items.Select((Item y) => y.ItemID).Contains(x.ItemID.Value)).ToList();
		using (List<GlobalOrderHistoryObjects.Order>.Enumerator enumerator2 = CS_0024_003C_003E8__locals0.orderToIterate.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass18_2 _003C_003Ec__DisplayClass18_ = new _003C_003Ec__DisplayClass18_2();
				_003C_003Ec__DisplayClass18_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				_003C_003Ec__DisplayClass18_.order = enumerator2.Current;
				_003C_003Ec__DisplayClass18_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass18_3();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass18_;
				Order order2 = new Order();
				CS_0024_003C_003E8__locals2.item = null;
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_barcode))
				{
					if (MemoryLoadedData.all_items.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_barcode).Count() > 1)
					{
						CS_0024_003C_003E8__locals2.item = MemoryLoadedData.all_items.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_barcode && x.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_id).FirstOrDefault();
					}
					if (CS_0024_003C_003E8__locals2.item == null)
					{
						CS_0024_003C_003E8__locals2.item = MemoryLoadedData.all_items.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_barcode).FirstOrDefault();
					}
				}
				else if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_id > 0)
				{
					CS_0024_003C_003E8__locals2.item = MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_id).FirstOrDefault();
				}
				else if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_id == -999)
				{
					CS_0024_003C_003E8__locals2.item = new DataManager().getDeliveryItem();
				}
				else
				{
					CS_0024_003C_003E8__locals2.item = new DataManager().getCustomItem();
					CS_0024_003C_003E8__locals2.item.ItemName = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_name;
					CS_0024_003C_003E8__locals2.item.ItemPrice = 0m;
				}
				if (CS_0024_003C_003E8__locals2.item == null)
				{
					continue;
				}
				string groupName = "UNCATEGORIZED";
				ItemsInGroup itemsInGroup = source3.Where((ItemsInGroup x) => x.ItemID == CS_0024_003C_003E8__locals2.item.ItemID).FirstOrDefault();
				if (itemsInGroup != null && itemsInGroup.Group != null)
				{
					groupName = itemsInGroup.Group.GroupName;
				}
				decimal num10 = CS_0024_003C_003E8__locals2.item.ItemPrice;
				decimal num11 = CS_0024_003C_003E8__locals2.item.ItemPrice;
				int num12 = 0;
				int num13 = num;
				if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.combo_id > 0)
				{
					if (!CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_name.Contains("OPT: ") && !(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_identifier_string == "OptionItem"))
					{
						if (list2.Count > 0 && num6 > 0m)
						{
							using var enumerator3 = (from a in list2
								group a by new { a.GroupName, a.SubSource } into a
								select new
								{
									a.Key,
									a.FirstOrDefault().ItemOptionId
								}).ToList().GetEnumerator();
							while (enumerator3.MoveNext())
							{
								_003C_003Ec__DisplayClass18_5 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass18_5();
								CS_0024_003C_003E8__locals4.dataGroup = enumerator3.Current;
								_003C_003Ec__DisplayClass18_6 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass18_6();
								CS_0024_003C_003E8__locals5.optionData = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult a) => a.ItemWithOptionID == CS_0024_003C_003E8__locals4.dataGroup.ItemOptionId && !a.ToBeDeleted).FirstOrDefault();
								if (CS_0024_003C_003E8__locals5.optionData == null)
								{
									continue;
								}
								_003C_003Ec__DisplayClass18_7 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass18_7();
								decimal num14 = ((CS_0024_003C_003E8__locals5.optionData.MaxFreeOptionPerGroup == -1) ? 9999m : ((decimal)CS_0024_003C_003E8__locals5.optionData.MaxFreeOptionPerGroup * num7));
								CS_0024_003C_003E8__locals6.itemWithOptionIDs = (from x in MemoryLoadedObjects.all_item_options
									where x.Tab.ToUpper() == CS_0024_003C_003E8__locals5.optionData.Tab.ToUpper() && x.GroupID == CS_0024_003C_003E8__locals5.optionData.GroupID && x.ItemID == CS_0024_003C_003E8__locals5.optionData.ItemID
									select x.ItemWithOptionID).ToList();
								using IEnumerator<Order> enumerator4 = (from a in list2
									where a.ItemSellPrice > 0m && CS_0024_003C_003E8__locals6.itemWithOptionIDs.Contains(a.ItemOptionId.Value)
									orderby a.ItemSellPrice
									select a).GetEnumerator();
								while (enumerator4.MoveNext())
								{
									_003C_003Ec__DisplayClass18_8 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass18_8();
									CS_0024_003C_003E8__locals7.o = enumerator4.Current;
									if (num14 > 0m && num6 > 0m && CS_0024_003C_003E8__locals7.o.ItemOptionId > 0)
									{
										Order order3 = list.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals7.o.OrderId).FirstOrDefault();
										order3.ItemSellPrice = 0m;
										order3.ItemPrice = 0m;
										order3.SubTotal = 0m;
										order3.Total = order3.SubTotal;
										num6 -= order3.Qty;
										num14 -= order3.Qty;
									}
								}
							}
						}
						if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.combo_id > 0 && num8 == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.combo_id)
						{
							ItemsInItem itemsInItem = gClass.ItemsInItems.Where((ItemsInItem a) => a.ParentItemID == (int?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId && a.ItemID == (int?)CS_0024_003C_003E8__locals2.item.ItemID).FirstOrDefault();
							List<GroupsInItem> list3 = gClass.GroupsInItems.Where((GroupsInItem a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId).ToList();
							bool flag2 = false;
							if (list3.Count > 0)
							{
								using List<GroupsInItem>.Enumerator enumerator5 = list3.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									_003C_003Ec__DisplayClass18_9 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass18_9();
									CS_0024_003C_003E8__locals8.groupInItem = enumerator5.Current;
									if ((from a in gClass.ItemsInGroups
										where (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals8.groupInItem.GroupID
										select a.ItemID.Value).ToList().Contains(CS_0024_003C_003E8__locals2.item.ItemID))
									{
										flag2 = true;
										break;
									}
								}
							}
							if ((itemsInItem != null && !itemsInItem.UseChildItemPriceAndTax) || flag2)
							{
								num11 = default(decimal);
								num10 = num11;
								num3 = num10;
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId = CS_0024_003C_003E8__locals2.item.ItemID;
							}
							else
							{
								num3 = CS_0024_003C_003E8__locals2.item.ItemPrice;
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId = CS_0024_003C_003E8__locals2.item.ItemID;
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId = 0;
							}
						}
						else
						{
							num3 = CS_0024_003C_003E8__locals2.item.ItemPrice;
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId = CS_0024_003C_003E8__locals2.item.ItemID;
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId = 0;
						}
						num += num5;
						num4 = num;
						num6 = (decimal)CS_0024_003C_003E8__locals2.item.MaxFreeOptions * CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_qty;
						num7 = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_qty;
						num8 = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.combo_id;
						list2 = new List<Order>();
					}
					else
					{
						_003C_003Ec__DisplayClass18_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass18_4();
						List<usp_ItemOptionsResult> list4 = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.mainItemId && a.Option_ItemID == CS_0024_003C_003E8__locals2.item.ItemID && !a.ToBeDeleted).ToList();
						if (list4.Count == 0 && CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId != 0)
						{
							list4 = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.childMainItemId && a.Option_ItemID == CS_0024_003C_003E8__locals2.item.ItemID && !a.ToBeDeleted).ToList();
						}
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_group_name) && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_tab))
						{
							CS_0024_003C_003E8__locals3.optionData = list4.Where((usp_ItemOptionsResult a) => a.GroupName == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_group_name && a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_tab.ToUpper().Trim()).FirstOrDefault();
							if (list4.Where((usp_ItemOptionsResult a) => a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_tab.ToUpper().Trim()).Count() == 1 && CS_0024_003C_003E8__locals3.optionData == null)
							{
								CS_0024_003C_003E8__locals3.optionData = list4.Where((usp_ItemOptionsResult a) => a.Tab.ToUpper() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.option_tab.ToUpper().Trim()).FirstOrDefault();
							}
						}
						else
						{
							CS_0024_003C_003E8__locals3.optionData = list4.FirstOrDefault();
						}
						if (CS_0024_003C_003E8__locals3.optionData != null)
						{
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.optionData.GroupName))
							{
								groupName = CS_0024_003C_003E8__locals3.optionData.GroupName;
							}
							num12 = CS_0024_003C_003E8__locals3.optionData.ItemWithOptionID;
							decimal num15 = CS_0024_003C_003E8__locals3.optionData.SpecialPrice;
							decimal num16 = ((CS_0024_003C_003E8__locals3.optionData.Qty == 0m) ? 1m : CS_0024_003C_003E8__locals3.optionData.Qty);
							if (order != null && order.ItemIdentifier == "MainItem" && CS_0024_003C_003E8__locals3.optionData.SpecialPrice > 0m && CS_0024_003C_003E8__locals3.optionData.MaxGroupOptions == 1 && CS_0024_003C_003E8__locals3.optionData.MinGroupOptions == 1 && SettingsHelper.GetSettingValueByKey("add_solo_option_main") == "ON")
							{
								num3 = (order.ItemSellPrice = num3 + CS_0024_003C_003E8__locals3.optionData.SpecialPrice / num16);
								order.ItemPrice = order.ItemSellPrice;
								order.DiscountDesc = string.Empty;
								order.Discount = 0m;
								order.DiscountReason = string.Empty;
								order.IsDiscount = false;
								order.SubTotal = CS_0024_003C_003E8__locals3.optionData.SpecialPrice * CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_qty;
								order.TaxTotal = 0m;
								order.Total = order.SubTotal;
								flag = true;
								num15 = default(decimal);
							}
							int num18 = 0;
							Reason reason = source.Where((Reason a) => a.Value.ToUpper() == CS_0024_003C_003E8__locals3.optionData.Tab.ToUpper()).FirstOrDefault();
							if (reason != null)
							{
								num18 = reason.SortOrder;
							}
							if (flag)
							{
								num13 = num4;
							}
							else
							{
								num13 = num4 + CS_0024_003C_003E8__locals3.optionData.SortOrder;
								if (CS_0024_003C_003E8__locals3.optionData.GroupSortOrder.HasValue && CS_0024_003C_003E8__locals3.optionData.GroupSortOrder.Value > 0)
								{
									num13 = num4 + num18 * 100 + CS_0024_003C_003E8__locals3.optionData.GroupSortOrder.Value * 10 + CS_0024_003C_003E8__locals3.optionData.SortOrder;
								}
							}
							num5 = num13;
							num10 = (num11 = num15 / num16);
							order2.SubSource = CS_0024_003C_003E8__locals3.optionData.Tab.ToUpper();
							list2.Add(order2);
						}
					}
				}
				else
				{
					num += num5;
					num4 = num;
				}
				order2.OrderId = Guid.NewGuid();
				order2.OrderNumber = orderNumber;
				order2.SortOrder = ((num12 > 0) ? num13 : num);
				order2.OrderType = newOrderType;
				order2.Customer = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.customer_phone;
				order2.RulesDesc = string.Empty;
				order2.DiscountDesc = string.Empty;
				order2.Paid = false;
				order2.Void = false;
				order2.StationID = CS_0024_003C_003E8__locals2.item.StationID;
				order2.ItemBarcode = CS_0024_003C_003E8__locals2.item.Barcode;
				order2.ItemID = CS_0024_003C_003E8__locals2.item.ItemID;
				order2.ItemName = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_name;
				order2.Instructions = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_instruction;
				order2.ItemPrice = num10;
				order2.Discount = 0m;
				order2.SubTotal = num11 * CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_qty;
				order2.TaxTotal = 0m;
				order2.Total = order2.SubTotal;
				order2.PaymentMethods = "SAVED ORDER";
				order2.DateCreated = DateTime.Now.AddMilliseconds(num2 * 100);
				order2.CreatedByTerminalID = HelperMethods.GetCurrentTerminalID();
				order2.TerminalID = null;
				order2.DateFilled = null;
				order2.DatePaid = null;
				order2.DateRefunded = null;
				order2.UserCreated = empID;
				order2.Notified = false;
				order2.VoidNotified = false;
				order2.ComboID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.combo_id;
				order2.OptionComboId = 0;
				order2.ItemOptionId = num12;
				order2.Synced = false;
				order2.CustomerID = customerInfo.customer_id;
				order2.TaxDesc = string.Empty;
				order2.GroupName = groupName;
				order2.Qty = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_qty;
				order2.ItemCost = ((CS_0024_003C_003E8__locals2.item != null) ? CS_0024_003C_003E8__locals2.item.ItemCost : 0m);
				order2.ItemSellPrice = num11;
				order2.LastSynced = null;
				order2.VoidBy = null;
				order2.Options = string.Empty;
				order2.CustomerInfo = (copyCustomerAddress ? customerInfo.customer_address : string.Empty);
				order2.DiscountReason = string.Empty;
				order2.TenderAmount = 0m;
				order2.TenderChange = 0m;
				order2.TipAmount = 0m;
				order2.DateCleared = null;
				order2.TipRecorded = false;
				order2.CustomerInfoName = customerInfo.customer_name;
				order2.CustomerInfoPhone = ((!string.IsNullOrEmpty(customerInfo.customer_cell)) ? customerInfo.customer_cell : customerInfo.customer_home);
				order2.GuestCount = 1;
				order2.ItemMadeNotified = false;
				order2.IsDiscount = false;
				order2.SeatNum = "1";
				order2.ItemIdentifier = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_identifier_string)) ? CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_identifier_string : ((CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_identifier == 1) ? "MainItem" : ((CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.order.item_identifier == 2) ? "ChildItem" : "OptionItem")));
				order2.ItemCourse = ((CS_0024_003C_003E8__locals2.item != null) ? CS_0024_003C_003E8__locals2.item.ItemCourse : "UNCATEGORIZED");
				order2.FlagID = 5;
				order2.PrintedInKitchen = false;
				order2.OrderOnHoldTime = orderOnHoldTime;
				order2.FulfillmentAt = FulfillmentDate;
				num2++;
				num++;
				list.Add(order2);
				if (order2.ItemIdentifier == "MainItem" || flag)
				{
					order = order2;
					flag = false;
				}
			}
		}
		if (list2.Count > 0 && num6 > 0m)
		{
			using var enumerator3 = (from a in list2
				group a by new { a.GroupName, a.SubSource } into a
				select new
				{
					a.Key,
					a.FirstOrDefault().ItemOptionId
				}).ToList().GetEnumerator();
			while (enumerator3.MoveNext())
			{
				_003C_003Ec__DisplayClass18_10 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass18_10();
				CS_0024_003C_003E8__locals9.dataGroup = enumerator3.Current;
				_003C_003Ec__DisplayClass18_11 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass18_11();
				CS_0024_003C_003E8__locals10.optionData = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult a) => a.ItemWithOptionID == CS_0024_003C_003E8__locals9.dataGroup.ItemOptionId && !a.ToBeDeleted).FirstOrDefault();
				if (CS_0024_003C_003E8__locals10.optionData == null)
				{
					continue;
				}
				_003C_003Ec__DisplayClass18_12 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass18_12();
				decimal num19 = ((CS_0024_003C_003E8__locals10.optionData.MaxFreeOptionPerGroup == -1) ? 9999m : ((decimal)CS_0024_003C_003E8__locals10.optionData.MaxFreeOptionPerGroup * num7));
				CS_0024_003C_003E8__locals11.itemWithOptionIDs = (from x in MemoryLoadedObjects.all_item_options
					where x.Tab.ToUpper() == CS_0024_003C_003E8__locals10.optionData.Tab.ToUpper() && x.GroupID == CS_0024_003C_003E8__locals10.optionData.GroupID && x.ItemID == CS_0024_003C_003E8__locals10.optionData.ItemID
					select x.ItemWithOptionID).ToList();
				using List<Order>.Enumerator enumerator6 = (from a in list2
					where a.ItemSellPrice > 0m && CS_0024_003C_003E8__locals11.itemWithOptionIDs.Contains(a.ItemOptionId.Value)
					orderby a.ItemSellPrice
					select a).ToList().GetEnumerator();
				while (enumerator6.MoveNext())
				{
					_003C_003Ec__DisplayClass18_13 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass18_13();
					CS_0024_003C_003E8__locals12.o = enumerator6.Current;
					if (num19 > 0m && num6 > 0m && CS_0024_003C_003E8__locals12.o.ItemOptionId > 0)
					{
						Order order4 = list.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals12.o.OrderId).FirstOrDefault();
						order4.ItemSellPrice = 0m;
						order4.ItemPrice = 0m;
						order4.SubTotal = 0m * order4.Qty;
						order4.Total = order4.SubTotal;
						num6 -= order4.Qty;
						num19 -= order4.Qty;
					}
				}
			}
		}
		num2 = 0;
		foreach (Order item2 in list.OrderBy((Order a) => a.SortOrder))
		{
			item2.SubSource = null;
			item2.DateCreated = DateTime.Now.AddMilliseconds(num2 * 100);
			num2++;
		}
		gClass.Orders.InsertAllOnSubmit(list);
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static string formatTicket(string ticket)
	{
		if (string.IsNullOrEmpty(ticket))
		{
			return string.Empty;
		}
		ticket = ticket.Trim();
		if (!string.IsNullOrEmpty(ticket))
		{
			if (ticket.Length == 1)
			{
				ticket = "00" + ticket;
			}
			else if (ticket.Length == 2)
			{
				ticket = "0" + ticket;
			}
			return ticket;
		}
		return string.Empty;
	}

	public static void UpdatePendingSaveOrders(string customer, bool reprint = false)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.customer = customer;
		GClass6 gClass = new GClass6();
		List<Order> list = gClass.Orders.Where((Order o) => o.FlagID == 6 && (o.Customer == CS_0024_003C_003E8__locals0.customer || (CS_0024_003C_003E8__locals0.customer != null && o.Customer == CS_0024_003C_003E8__locals0.customer.ToUpper())) && o.OrderType == OrderTypes.DineIn && o.DateCreated.Value.AddDays(1.0) > DateTime.Now).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Order item in list)
		{
			item.FlagID = 0;
			if (reprint)
			{
				item.PrintedInKitchen = false;
			}
		}
		gClass.SubmitChanges();
	}

	public static void OnlineOrderRefresh()
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.sync_station = SyncMethods.GetStation();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(CS_0024_003C_003E8__locals0.sync_station)).FirstOrDefault();
		if (terminal != null)
		{
			terminal.ProcessOnlineOrderQueueFlag = true;
			gClass.SubmitChanges();
		}
	}

	public OrderHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
