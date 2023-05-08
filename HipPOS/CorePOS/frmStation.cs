using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmStation : frmMasterForm
{
	private FormHelper formHelper_0;

	private short short_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private int int_1;

	private float float_0;

	private string string_1;

	private string string_2;

	private bool bool_2;

	private Button button_0;

	private string string_3;

	private IContainer icontainer_1;

	internal Button btnItemMade;

	internal Button btnPrintOrder;

	internal Button BtnCancel;

	internal Button btnClearCancelled;

	private System.Windows.Forms.Timer timer_0;

	internal Button btnShowDetails;

	private Label lblQty;

	private Label lblDescription;

	private Label lblTime;

	private Label lblOrderType;

	private Panel pnlMain;

	private Label lblTitle;

	internal Button btnShowItems;

	internal Button btnEnterOrder;

	internal Button btnScreenRefresh;

	private Label lblTraining;

	private Label lblCourse;

	private Label lblCounter;

	private Label lblCustomer;

	private Windows8Theme windows8Theme_0;

	private CustomListViewTelerik radListItems;

	private VerticalScrollControl verticalScrollControl1;

	internal Button btnChangeView;

	private Label lblOrderNum;

	internal Button btnPutOrderOnHold;

	internal Button btnChangeStation;

	internal Button btnOTFilter_All;

	private Label label1;

	internal Button btnOTFilter_Catering;

	internal Button btnOTFilter_Delivery;

	internal Button btnOTFilter_PickUp;

	internal Button btnOTFilter_ToGo;

	internal Button btnOTFilter_DineIn;

	internal Button btnClearSearch;

	private Label label3;

	private RadTextBoxControl txtSearchInfo;

	internal Button btnShowKeyboard_SearchInfo;

	private System.Windows.Forms.Timer timer_1;

	private System.Windows.Forms.Timer timer_2;

	public frmStation(object sender, short _stationID)
	{
		Class26.Ggkj0JxzN9YmC();
		formHelper_0 = new FormHelper();
		int_0 = 30;
		float_0 = 13f;
		string_3 = "ALL";
		base._002Ector();
		GClass6 gClass = new GClass6();
		if (SettingsHelper.CurrentTerminalMode == "KitchenDisplay")
		{
			CultureInfo cultureInfo = new CultureInfo(SettingsHelper.GetSettingValueByKey("primary_language"));
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		button_0 = (Button)sender;
		short_0 = _stationID;
		btnShowItems.Text = Resources.SHOW_RECENTLY_MADE_ITEMS;
		btnShowItems.Tag = "MADE ITEMS";
		btnPrintOrder.Enabled = false;
		btnItemMade.Enabled = false;
		btnShowDetails.Enabled = false;
		btnClearCancelled.Enabled = false;
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Visible = true;
		}
		else
		{
			lblTraining.Visible = false;
		}
		bool_2 = ((SettingsHelper.GetSettingValueByKey("print_chit_cashout") == "ON") ? true : false);
		btnClearCancelled.Tag = Color.FromArgb(214, 142, 81);
		string_1 = gClass.CompanySetups.FirstOrDefault().Name;
		verticalScrollControl1.ConnectedRadListView = radListItems;
	}

	private void frmStation_Load(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode == "KitchenDisplay" || SettingsHelper.CurrentTerminalMode == "BarDisplay")
		{
			timer_1.Enabled = true;
		}
		Station station = MemoryLoadedObjects.all_stations.Where((Station station_0) => station_0.StationID == short_0).FirstOrDefault();
		if (station == null)
		{
			btnChangeStation_Click(null, null);
			return;
		}
		float_0 = station.DisplayFontSize.Value;
		int num3 = (lblTitle.Width = (pnlMain.Width = base.Size.Width));
		pnlMain.Height = base.Size.Height - 40;
		int_1 = int_0;
		lblCounter.Text = int_1.ToString();
		btnScreenRefresh.Location = new Point(base.Size.Width - btnScreenRefresh.Width, 0);
		num3 = (btnScreenRefresh.Height = (btnChangeStation.Height = lblTitle.Height + lblDescription.Height + 2));
		btnChangeStation.Location = new Point(btnScreenRefresh.Left - btnChangeStation.Width, 0);
		lblCounter.Location = new Point(btnScreenRefresh.Left + 5, btnScreenRefresh.Top + 15);
		method_5();
		string_2 = station.StationName.ToUpper();
		lblTitle.Text = string_2 + " PENDING ITEMS";
		method_4();
		timer_0.Enabled = true;
		if (SettingsHelper.GetSettingValueByKey("now_serving_screen") == "ON")
		{
			ControlHelpers.ShowNowServingScreen();
		}
		if (SettingsHelper.CurrentTerminalMode == "KitchenDisplay")
		{
			btnEnterOrder.Visible = false;
		}
		else
		{
			btnEnterOrder.Visible = true;
		}
		btnPutOrderOnHold.Enabled = false;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (SettingsHelper.CurrentTerminalMode != "KitchenDisplay")
		{
			formHelper_0.Dispose();
			GC.Collect();
			Dispose();
			return;
		}
		ModulesAndFeature modulesAndFeature = gClass.ModulesAndFeatures.Where((ModulesAndFeature x) => x.ModuleName == "frmSplash" && x.ControlName == "btnClose").FirstOrDefault();
		if (modulesAndFeature != null)
		{
			List<SecurityMatrix> list = modulesAndFeature.SecurityMatrixes.Where((SecurityMatrix x) => x.IsAllow).ToList();
			List<string> list2 = new List<string>();
			using (List<SecurityMatrix>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					switch (enumerator.Current.RoleID)
					{
					case 1:
						list2.Add(Roles.admin);
						break;
					case 2:
						list2.Add(Roles.manager);
						break;
					case 3:
						list2.Add(Roles.employee);
						break;
					case 6:
						list2.Add(Roles.supervisor);
						break;
					}
				}
			}
			if (list2.Count() != 0 && AuthMethods.ValidatePin(this, list2))
			{
				FormHelper.CleanupObjects();
				Application.Exit();
			}
		}
		else
		{
			FormHelper.CleanupObjects();
			Application.Exit();
		}
	}

	private void btnItemMade_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		OrderMethods orderMethods = new OrderMethods();
		InventoryMethods inventoryMethods = new InventoryMethods();
		if (radListItems.SelectedItems.Count <= 0)
		{
			return;
		}
		string text = string.Empty;
		string text2 = radListItems.SelectedItems[0].SubItems[2].ToString().Replace(" *PAID*", string.Empty);
		switch (text2)
		{
		case "D/I":
			text2 = OrderTypes.DineIn;
			break;
		case "T/O":
			text2 = OrderTypes.PickUp;
			break;
		case "DLRY":
			text2 = OrderTypes.Delivery;
			break;
		case "TOGO":
			text2 = OrderTypes.ToGo;
			break;
		case "T/O-W":
			text2 = OrderTypes.TakeOutOnline;
			break;
		case "DLRY-W":
			text2 = OrderTypes.DeliveryOnline;
			break;
		}
		Guid id = new Guid(radListItems.SelectedItems[0].SubItems[7].ToString());
		CS_0024_003C_003E8__locals0.order = orderMethods.GetOrder(id);
		bool flag = true;
		if (!bool_1)
		{
			if (CS_0024_003C_003E8__locals0.order.ComboID != 0)
			{
				List<Order> list = (from o in orderMethods.UnfilledOrders(-1)
					where o.ComboID == CS_0024_003C_003E8__locals0.order.ComboID && o.OrderNumber == CS_0024_003C_003E8__locals0.order.OrderNumber && (o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime)))
					select o).ToList();
				flag = true;
				foreach (Order item in list)
				{
					if (!item.Void)
					{
						item.StationMade = StationMethods.AddStationIdFromStationIds(item.StationMade, short_0.ToString());
						if (!string.IsNullOrEmpty(item.StationID) && !string.IsNullOrEmpty(item.StationMade) && item.StationMade.Split(',').Count() == item.StationID.Split(',').Count())
						{
							item.DateFilled = DateTime.Now;
						}
						item.ItemMadeNotified = false;
						text = text + (flag ? string.Empty : "-- ") + item.ItemName + ((!flag) ? string.Empty : (string.IsNullOrEmpty(item.Options) ? string.Empty : (" (" + item.Options + ")"))) + (string.IsNullOrEmpty(item.Instructions) ? string.Empty : (" (" + item.Instructions + ")")) + "<br/>";
						flag = false;
					}
					inventoryMethods.SubtractMaterialInventory(item);
					if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(CS_0024_003C_003E8__locals0.order.OrderType != OrderTypes.MakeToStock))
					{
						inventoryMethods.AddItemInventory(item, "MAKE TO STOCK");
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: false);
						item.Paid = true;
						item.DatePaid = DateTime.Now;
						item.DateCleared = DateTime.Now;
						item.PaymentMethods = "MAKE TO STOCK=0.00|";
					}
					else
					{
						inventoryMethods.SubtractItemInventory(item);
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: true);
					}
					orderMethods.SubmitChanges();
				}
			}
			else if (!CS_0024_003C_003E8__locals0.order.Void)
			{
				CS_0024_003C_003E8__locals0.order.StationMade = StationMethods.AddStationIdFromStationIds(CS_0024_003C_003E8__locals0.order.StationMade, short_0.ToString());
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.StationID) && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.StationMade) && CS_0024_003C_003E8__locals0.order.StationMade.Split(',').Count() == CS_0024_003C_003E8__locals0.order.StationID.Split(',').Count())
				{
					CS_0024_003C_003E8__locals0.order.DateFilled = DateTime.Now;
				}
				CS_0024_003C_003E8__locals0.order.ItemMadeNotified = false;
				text = CS_0024_003C_003E8__locals0.order.ItemName + ((!flag) ? string.Empty : (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Options) ? string.Empty : (" ( " + CS_0024_003C_003E8__locals0.order.Options + ")"))) + (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Instructions) ? string.Empty : (" (" + CS_0024_003C_003E8__locals0.order.Instructions + ")")) + "<br/>";
				inventoryMethods.SubtractMaterialInventory(CS_0024_003C_003E8__locals0.order);
				if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(CS_0024_003C_003E8__locals0.order.OrderType != OrderTypes.MakeToStock))
				{
					inventoryMethods.AddItemInventory(CS_0024_003C_003E8__locals0.order, "MAKE TO STOCK");
					inventoryMethods.UpdateExpiryItem(CS_0024_003C_003E8__locals0.order.InventoryBatchId, CS_0024_003C_003E8__locals0.order.Qty, toSubtract: false);
					CS_0024_003C_003E8__locals0.order.Paid = true;
					CS_0024_003C_003E8__locals0.order.DatePaid = DateTime.Now;
					CS_0024_003C_003E8__locals0.order.DateCleared = DateTime.Now;
					CS_0024_003C_003E8__locals0.order.PaymentMethods = "MAKE TO STOCK=0.00|";
				}
				else
				{
					inventoryMethods.SubtractItemInventory(CS_0024_003C_003E8__locals0.order);
					inventoryMethods.UpdateExpiryItem(CS_0024_003C_003E8__locals0.order.InventoryBatchId, CS_0024_003C_003E8__locals0.order.Qty, toSubtract: true);
				}
				orderMethods.SubmitChanges();
			}
			orderMethods.SubmitChanges();
			if (text2 == OrderTypes.DeliveryOnline || text2 == OrderTypes.TakeOutOnline || text2 == OrderTypes.PickUpOnline)
			{
				new OrderHelper().UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals0.order, isSingleOrder: true);
			}
			Station singleStation = new StationMethods().GetSingleStation(short_0);
			if (singleStation.AutoPrint)
			{
				if (text2.Contains(OrderTypes.DineIn))
				{
					new PrintHelper().PrintString("<p style=\"font-size:16pt;font-weight:bold;\">" + CS_0024_003C_003E8__locals0.order.Customer.ToUpper() + ":</p>" + text, 12, singleStation);
				}
				if ((text2.Contains(OrderTypes.PickUp) || text2.Contains(OrderTypes.Delivery) || text2.Contains(OrderTypes.DeliveryOnline) || text2.Contains(OrderTypes.TakeOutOnline) || text2.Contains(OrderTypes.ToGo)) && !CS_0024_003C_003E8__locals0.order.Void)
				{
					orderMethods = new OrderMethods();
					if ((from o in orderMethods.Orders(CS_0024_003C_003E8__locals0.order.OrderNumber)
						where !o.DateFilled.HasValue && o.StationID.Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.short_0.ToString()) && o.ItemID > 0
						select o).Count() == 0)
					{
						PrintHelper.GenerateReceipt(CS_0024_003C_003E8__locals0.order.OrderNumber, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
					}
					if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
					{
						MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals0.order.OrderNumber, CS_0024_003C_003E8__locals0.order.Customer, CS_0024_003C_003E8__locals0.order.OrderType);
					}
				}
			}
		}
		else if (CS_0024_003C_003E8__locals0.order.ComboID != 0)
		{
			GClass6 gClass = new GClass6();
			IQueryable<Order> queryable = gClass.Orders.Where((Order a) => a.DateFilled.HasValue && a.StationID.Contains(short_0.ToString()) && a.ComboID == CS_0024_003C_003E8__locals0.order.ComboID && a.OrderNumber == CS_0024_003C_003E8__locals0.order.OrderNumber);
			flag = true;
			foreach (Order item2 in queryable)
			{
				if (!item2.Void)
				{
					item2.DateFilled = null;
					item2.ItemMadeNotified = true;
					flag = false;
				}
				inventoryMethods.AddtMaterialInventory(item2);
				inventoryMethods.AddItemInventory(item2);
				inventoryMethods.UpdateExpiryItem(CS_0024_003C_003E8__locals0.order.InventoryBatchId, CS_0024_003C_003E8__locals0.order.Qty, toSubtract: false);
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
		else
		{
			if (!CS_0024_003C_003E8__locals0.order.Void)
			{
				CS_0024_003C_003E8__locals0.order.DateFilled = null;
				CS_0024_003C_003E8__locals0.order.ItemMadeNotified = true;
				inventoryMethods.AddtMaterialInventory(CS_0024_003C_003E8__locals0.order);
				inventoryMethods.AddItemInventory(CS_0024_003C_003E8__locals0.order);
			}
			orderMethods.SubmitChanges();
			inventoryMethods.UpdateExpiryItem(CS_0024_003C_003E8__locals0.order.InventoryBatchId, CS_0024_003C_003E8__locals0.order.Qty, toSubtract: false);
		}
		method_4();
	}

	private void btnPrintOrder_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
			OrderMethods orderMethods = new OrderMethods();
			InventoryMethods inventoryMethods = new InventoryMethods();
			CS_0024_003C_003E8__locals0.orderNumber = radListItems.SelectedItems[0].SubItems[1].ToString();
			string text = radListItems.SelectedItems[0].SubItems[2].ToString();
			switch (text)
			{
			case "D/I":
				text = OrderTypes.DineIn;
				break;
			case "T/O":
				text = OrderTypes.PickUp;
				break;
			case "P/U":
				text = OrderTypes.PickUp;
				break;
			case "DLRY":
				text = OrderTypes.Delivery;
				break;
			case "TOGO":
				text = OrderTypes.ToGo;
				break;
			case "T/O-W":
				text = OrderTypes.TakeOutOnline;
				break;
			case "DLRY-W":
				text = OrderTypes.DeliveryOnline;
				break;
			}
			List<Order> source = (from o in orderMethods.Orders(CS_0024_003C_003E8__locals0.orderNumber)
				where o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value <= DateTime.Now.AddMinutes(-o.OrderOnHoldTime)) || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.PickUp
				select o).ToList();
			source = (bool_1 ? source.Where((Order order_0) => order_0.StationID != null && order_0.StationID.Contains(short_0.ToString()) && order_0.DateFilled.HasValue && order_0.ItemID != -100).ToList() : source.Where((Order order_0) => order_0.StationID != null && order_0.StationID.Contains(short_0.ToString()) && !order_0.DateFilled.HasValue).ToList());
			if (source.Where((Order x) => x.FulfillmentAt.HasValue).Count() > 0 && source.Where((Order o) => o.FulfillmentAt.HasValue && o.FulfillmentAt <= DateTime.Now.AddMinutes(30.0)).Count() == 0)
			{
				new NotificationLabel(this, "You cannot complete this order at this time.", NotificationTypes.Notification).Show();
				return;
			}
			bool flag = true;
			string text2 = string.Empty;
			foreach (Order item in source.ToList())
			{
				text2 = item.Customer;
				if (!bool_1)
				{
					item.StationMade = StationMethods.AddStationIdFromStationIds(item.StationMade, short_0.ToString());
					if (!string.IsNullOrEmpty(item.StationID) && !string.IsNullOrEmpty(item.StationMade) && item.StationMade.Split(',').Count() == item.StationID.Split(',').Count())
					{
						item.DateFilled = DateTime.Now;
					}
				}
				else
				{
					item.DateFilled = null;
					item.StationMade = StationMethods.ChangeSingleStationFromStationIds(item.StationMade, short_0.ToString());
				}
				item.ItemMadeNotified = (bool_1 ? true : false);
				flag = item.Void;
				if (!bool_1)
				{
					inventoryMethods.SubtractMaterialInventory(item);
					if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
					{
						inventoryMethods.AddItemInventory(item, "MAKE TO STOCK");
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: false);
						item.Paid = true;
						item.DatePaid = DateTime.Now;
						item.DateCleared = DateTime.Now;
						item.PaymentMethods = "MAKE TO STOCK=0.00|";
					}
					else
					{
						inventoryMethods.SubtractItemInventory(item);
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: true);
					}
				}
				else
				{
					inventoryMethods.AddtMaterialInventory(item);
					if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
					{
						inventoryMethods.SubtractItemInventory(item);
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: true);
						item.Paid = false;
						item.DatePaid = null;
						item.DateCleared = null;
						item.PaymentMethods = "SAVED ORDER";
					}
					else
					{
						inventoryMethods.AddItemInventory(item);
						inventoryMethods.UpdateExpiryItem(item.InventoryBatchId, item.Qty, toSubtract: false);
					}
				}
				foreach (Order item2 in orderMethods.SharedOrders(item.OrderId).ToList())
				{
					if (!item2.DateFilled.HasValue)
					{
						item2.DateFilled = item.DateFilled;
					}
					item2.ItemMadeNotified = item.ItemMadeNotified;
					item2.Void = item.Void;
					if (!bool_1)
					{
						inventoryMethods.SubtractMaterialInventory(item2);
						if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
						{
							inventoryMethods.AddItemInventory(item2, "MAKE TO STOCK");
							inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: false);
							item.Paid = true;
							item.DateCleared = DateTime.Now;
							item.DatePaid = DateTime.Now;
							item.PaymentMethods = "MAKE TO STOCK=0.00|";
						}
						else
						{
							inventoryMethods.SubtractItemInventory(item2);
							inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: true);
						}
					}
					else
					{
						inventoryMethods.AddtMaterialInventory(item2);
						if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
						{
							inventoryMethods.SubtractItemInventory(item2);
							inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: true);
							item.Paid = false;
							item.DatePaid = null;
							item.DateCleared = null;
							item.PaymentMethods = "SAVED ORDER";
						}
						else
						{
							inventoryMethods.AddItemInventory(item2);
							inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: false);
						}
					}
					orderMethods.SubmitChanges();
				}
				orderMethods.SubmitChanges();
			}
			if ((text.Contains(OrderTypes.PickUp) || text.Contains(OrderTypes.Delivery) || text.Contains(OrderTypes.DeliveryOnline) || text.Contains(OrderTypes.PickUpOnline) || text.Contains(OrderTypes.TakeOutOnline) || text.Contains(OrderTypes.ToGo)) && !flag && !bool_1)
			{
				Station singleStation = new StationMethods().GetSingleStation(short_0);
				if (MemoryLoadedObjects.all_stations.Where((Station a) => a.SendToStation && a.AutoPrint).Any() && !new GClass6().Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && a.Void == false && a.StationID != null && a.DateFilled == null).Any())
				{
					PrintHelper.GenerateReceipt(CS_0024_003C_003E8__locals0.orderNumber, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, singleStation.PrinterName);
				}
				if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled" && !string.IsNullOrEmpty(text2) && !new GClass6().Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && a.Void == false && a.StationID != null && a.DateFilled == null).Any())
				{
					MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals0.orderNumber, text2, text);
				}
			}
			if (!bool_1 && (text == OrderTypes.DeliveryOnline || text == OrderTypes.TakeOutOnline || text == OrderTypes.PickUpOnline || text == OrderTypes.PickUpCurbsideOnline || text == OrderTypes.DineInOnline))
			{
				new OrderHelper().UpdateOrderStatusInOrdering(orderMethods.Orders(CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault(), isSingleOrder: false);
			}
			method_4();
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item, NotificationTypes.Notification).Show();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (int_1 > 0)
		{
			int_1--;
			lblCounter.Text = int_1.ToString();
		}
		if (int_1 <= 0)
		{
			method_4();
		}
	}

	private void method_3(string string_4, RadListView radListView_0, ref bool bool_3, ref bool bool_4, ref bool bool_5)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.query = string_4;
		bool_3 = false;
		bool_4 = false;
		try
		{
			if (bool_0)
			{
				return;
			}
			OrderMethods orderMethods = new OrderMethods();
			GClass6 gClass = new GClass6();
			int_1 = int_0;
			bool_0 = true;
			List<Order> list = (from o in orderMethods.UnfilledRefundedAndVoidOrders(short_0)
				where o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime)) || (o.OrderOnHoldTime != 0 && (o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.TakeOutOnline))
				select o).ToList();
			if (string_3 != "ALL")
			{
				list = list.Where((Order x) => x.OrderType.ToUpper().Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.string_3)).ToList();
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.query))
			{
				list = list.Where((Order x) => (x.Customer != null && x.Customer.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfo != null && x.CustomerInfo.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfoName != null && x.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || x.OrderNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query) || (x.OrderTicketNumber != null && x.OrderTicketNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query))).ToList();
			}
			if (bool_2)
			{
				list = list.Where((Order a) => a.Paid).ToList();
			}
			if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON")
			{
				list = list.Where((Order a) => a.FlagID != 1 || a.FlagID == 0).ToList();
			}
			list = ((!(SettingsHelper.GetSettingValueByKey("course_selection") == "ON")) ? list.OrderBy((Order a) => a.DateCreated).ToList() : list.OrderByItemCourse().ThenBy((Order a) => a.DateCreated).ToList());
			if (list.Any())
			{
				if (btnClearCancelled.InvokeRequired && btnShowItems.Tag.ToString().Contains("MADE ITEMS"))
				{
					btnClearCancelled.Invoke((MethodInvoker)delegate
					{
						CS_0024_003C_003E8__locals0._003C_003E4__this.btnClearCancelled.Enabled = true;
					});
				}
				else if (btnClearCancelled.InvokeRequired)
				{
					btnClearCancelled.Invoke((MethodInvoker)delegate
					{
						CS_0024_003C_003E8__locals0._003C_003E4__this.btnClearCancelled.Enabled = false;
					});
				}
			}
			else if (btnClearCancelled.InvokeRequired)
			{
				btnClearCancelled.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0._003C_003E4__this.btnClearCancelled.Enabled = false;
				});
			}
			radListView_0.Items.Clear();
			List<Order> list2 = ((!bool_1) ? (from x in gClass.Orders
				where x.DateFilled.HasValue == false && x.StationID.Contains(short_0.ToString()) && x.ShareItemID == null && x.ItemID != -100 && x.DateCreated.Value.Date >= DateTime.Now.AddDays(-1.0).Date && x.ItemName != ConstantItems.Delivery_Fee && !x.PaymentMethods.Contains("KIOSK") && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)))
				select x into a
				orderby a.DateCreated
				select a).ToList() : (from x in gClass.Orders
				where x.DateFilled.HasValue == true && x.DateFilled.Value >= DateTime.Now.AddHours(-12.0).Date && x.ItemID != -100 && x.ItemID != -999 && x.ItemName != ConstantItems.Delivery_Fee
				select x into a
				orderby a.DateFilled.Value descending
				select a).Take(40).ToList());
			if (string_3 != "ALL")
			{
				list2 = list2.Where((Order x) => x.OrderType.ToUpper().Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.string_3)).ToList();
			}
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.query))
			{
				list2 = list2.Where((Order x) => (x.Customer != null && x.Customer.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfo != null && x.CustomerInfo.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || (x.CustomerInfoName != null && x.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.query)) || x.OrderNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query) || (x.OrderTicketNumber != null && x.OrderTicketNumber.ToLower().Contains(CS_0024_003C_003E8__locals0.query))).ToList();
			}
			if (bool_2 && !bool_1)
			{
				list2 = list2.Where((Order a) => a.Paid || (a.OrderType != OrderTypes.DineIn && a.OrderType != OrderTypes.ToGo)).ToList();
			}
			if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON" && !bool_1)
			{
				list2 = list2.Where((Order a) => a.FlagID != 1 || a.FlagID == 0).ToList();
			}
			list2 = ((!(SettingsHelper.GetSettingValueByKey("course_selection") == "ON")) ? list2.OrderBy((Order a) => a.DateCreated).ToList() : list2.OrderByItemCourse().ThenBy((Order a) => a.DateCreated).ToList());
			SoundPlayer soundPlayer = new SoundPlayer();
			soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\tada.wav";
			string text = string.Empty;
			bool flag = false;
			using (List<Order>.Enumerator enumerator = list2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
					CS_0024_003C_003E8__locals1.order = enumerator.Current;
					if (!bool_1 && ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.StationMade) && CS_0024_003C_003E8__locals1.order.StationMade.Split(',').Contains(short_0.ToString())) || string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.StationID)))
					{
						continue;
					}
					if (CS_0024_003C_003E8__locals1.order.ItemName == null)
					{
						break;
					}
					if (CS_0024_003C_003E8__locals1.order.ComboID > 0 && CS_0024_003C_003E8__locals1.order.ItemSellPrice == 0m && string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Instructions) && !CS_0024_003C_003E8__locals1.order.ItemName.Contains("SUB:") && !CS_0024_003C_003E8__locals1.order.ItemName.Contains("ADD:") && !CS_0024_003C_003E8__locals1.order.ItemName.Contains("OPT:") && CS_0024_003C_003E8__locals1.order.ItemIdentifier != "MainItem" && gClass.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals1.order.ItemID).ToList().Count == 0)
					{
						continue;
					}
					string text2 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Instructions)) ? CS_0024_003C_003E8__locals1.order.Instructions : string.Empty);
					string text3 = "N/A";
					if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.DineIn)
					{
						text3 = "D/I";
					}
					else if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.PickUp)
					{
						text3 = "P/U";
					}
					else if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.Delivery)
					{
						text3 = "DLRY";
					}
					else if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.ToGo)
					{
						text3 = "TOGO";
					}
					else if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.TakeOutOnline)
					{
						text3 = "P/U-W";
					}
					else if (CS_0024_003C_003E8__locals1.order.OrderType == OrderTypes.DeliveryOnline)
					{
						text3 = "DLRY-W";
					}
					Color white = Color.White;
					white = ((CS_0024_003C_003E8__locals1.order.OrderType.Equals(OrderTypes.PickUp) || CS_0024_003C_003E8__locals1.order.OrderType.Contains(OrderTypes.Delivery)) ? ((radListView_0.Items.Count <= 0) ? Color.LightGreen : ((text == CS_0024_003C_003E8__locals1.order.OrderNumber) ? radListView_0.Items[radListView_0.Items.Count - 1].BackColor : ((!(radListView_0.Items[radListView_0.Items.Count - 1].BackColor == Color.LightPink)) ? Color.LightPink : Color.LightGreen))) : ((radListView_0.Items.Count <= 0) ? Color.White : ((text == CS_0024_003C_003E8__locals1.order.OrderNumber) ? radListView_0.Items[radListView_0.Items.Count - 1].BackColor : ((!(radListView_0.Items[radListView_0.Items.Count - 1].BackColor == Color.LightSkyBlue)) ? Color.LightSkyBlue : Color.White))));
					DateTime now = DateTime.Now;
					DateTime value = CS_0024_003C_003E8__locals1.order.DateCreated.Value;
					TimeSpan timeSpan = now - value;
					List<Order> subSharedOrders = new OrderMethods().GetSubSharedOrders(CS_0024_003C_003E8__locals1.order.OrderId);
					decimal num = default(decimal);
					if (subSharedOrders.Count > 0)
					{
						num = subSharedOrders.Sum((Order a) => a.Qty);
					}
					string time = Math.Floor(timeSpan.TotalMinutes).ToString("0");
					string orderNumber = CS_0024_003C_003E8__locals1.order.OrderNumber;
					string orderType = text3 + (CS_0024_003C_003E8__locals1.order.Paid ? " *PAID*" : string.Empty);
					string customer = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Customer.Trim())) ? CS_0024_003C_003E8__locals1.order.Customer : (CS_0024_003C_003E8__locals1.order.OrderNumber.Contains("OR") ? CS_0024_003C_003E8__locals1.order.OrderNumber : ("ORD:" + CS_0024_003C_003E8__locals1.order.OrderNumber)));
					string text4 = MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals1.order.Qty + num);
					if (text4 == "1/1")
					{
						text4 = "1";
					}
					string text5 = CS_0024_003C_003E8__locals1.order.ItemCourse;
					if (text5.ToUpper() == "UNCATEGORIZED")
					{
						text5 = string.Empty;
					}
					string item = (CS_0024_003C_003E8__locals1.order.ItemName + ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Options)) ? (" => " + CS_0024_003C_003E8__locals1.order.Options) : string.Empty) + ((!string.IsNullOrEmpty(text2)) ? (" => INSTR: " + text2) : string.Empty)).ToUpper();
					string orderid = CS_0024_003C_003E8__locals1.order.OrderId.ToString();
					Color fontColor = Color.Black;
					if (bool_1 && CS_0024_003C_003E8__locals1.order.ItemMadeNotified)
					{
						fontColor = Color.DarkBlue;
					}
					formHelper_0.subAddItemsToStationListTelerik(radListView_0, time, orderNumber, orderType, customer, text4, text5, CS_0024_003C_003E8__locals1.order.Void, item, orderid, white, fontColor, float_0);
					if (!CS_0024_003C_003E8__locals1.order.Notified)
					{
						if (CS_0024_003C_003E8__locals1.order.Void && CS_0024_003C_003E8__locals1.order.IsModified)
						{
							CS_0024_003C_003E8__locals1.order.IsModified = false;
							bool_4 = true;
						}
						else if (!CS_0024_003C_003E8__locals1.order.Void && CS_0024_003C_003E8__locals1.order.IsModified)
						{
							CS_0024_003C_003E8__locals1.order.IsModified = false;
							bool_5 = true;
						}
						CS_0024_003C_003E8__locals1.order.Notified = true;
						Helper.SubmitChangesWithCatch(gClass);
						bool_3 = true;
						if (!flag)
						{
							soundPlayer.Play();
							bool_3 = true;
							flag = true;
						}
					}
					text = CS_0024_003C_003E8__locals1.order.OrderNumber;
				}
			}
			list2 = null;
			bool_0 = false;
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			bool_0 = false;
		}
	}

	private async void method_4()
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		Button btnCancel = BtnCancel;
		btnChangeView.Enabled = false;
		btnCancel.Enabled = false;
		if (radListItems.SelectedItems.Count > 0)
		{
			string_0 = radListItems.SelectedItems[0].SubItems[6].ToString();
		}
		else
		{
			string_0 = null;
		}
		CS_0024_003C_003E8__locals0.rv = new RadListView();
		CS_0024_003C_003E8__locals0.rv.Items.AddRange((from ListViewDataItem item in radListItems.Items
			select (item)).ToArray());
		Cursor = Cursors.WaitCursor;
		CS_0024_003C_003E8__locals0.isNotify = false;
		CS_0024_003C_003E8__locals0.isItemsCancelled = false;
		CS_0024_003C_003E8__locals0.isItemModified = false;
		try
		{
			int_1 = int_0;
			lblCounter.Text = int_1.ToString();
			await Task.Run(delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_3(CS_0024_003C_003E8__locals0._003C_003E4__this.txtSearchInfo.Text.Trim(), CS_0024_003C_003E8__locals0.rv, ref CS_0024_003C_003E8__locals0.isNotify, ref CS_0024_003C_003E8__locals0.isItemsCancelled, ref CS_0024_003C_003E8__locals0.isItemModified);
			});
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, error);
			return;
		}
		if (CS_0024_003C_003E8__locals0.isNotify)
		{
			new NotificationLabel(this, Resources.NEW_ORDER_S_HAVE_BEEN_RECEIVED, NotificationTypes.Notification).Show();
		}
		if (CS_0024_003C_003E8__locals0.isItemsCancelled)
		{
			new NotificationLabel(this, "Item(s) have been cancelled.", NotificationTypes.Notification).Show();
		}
		if (CS_0024_003C_003E8__locals0.isItemModified)
		{
			new NotificationLabel(this, "Item(s) have been modified.", NotificationTypes.Notification).Show();
		}
		Cursor = Cursors.Default;
		radListItems.Items.Clear();
		radListItems.Items.AddRange((from ListViewDataItem item in CS_0024_003C_003E8__locals0.rv.Items
			select (item)).ToArray());
		bool flag = false;
		if (string_0 != null)
		{
			foreach (ListViewDataItem item in radListItems.Items)
			{
				if (item.SubItems[6].ToString() == string_0)
				{
					radListItems.SelectedItem = item;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			btnPrintOrder.Enabled = false;
			btnItemMade.Enabled = false;
			btnShowDetails.Enabled = false;
			radListItems.SelectedItems.Clear();
		}
		verticalScrollControl1.EnableDisableButtonsByScrollListView();
		Button btnCancel2 = BtnCancel;
		btnChangeView.Enabled = true;
		btnCancel2.Enabled = true;
	}

	private void frmStation_VisibleChanged(object sender, EventArgs e)
	{
	}

	private void btnClearCancelled_Click(object sender, EventArgs e)
	{
		OrderMethods orderMethods = new OrderMethods();
		foreach (Order item in (from o in orderMethods.UnfilledRefundedAndVoidOrders(short_0)
			where o.OrderOnHoldTime == 0 || o.OrderOnHoldTime == -1 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime))
			select o).ToList())
		{
			item.DateFilled = DateTime.Now;
		}
		orderMethods.SubmitChanges();
		method_4();
	}

	private void btnShowDetails_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			new frmMessageBox(radListItems.SelectedItems[0].SubItems[6].ToString()).ShowDialog(this);
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_view, NotificationTypes.Notification).Show();
		}
	}

	private void btnShowItems_Click(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			bool_1 = true;
			btnShowItems.Text = Resources.SHOW_PENDING_ITEMS;
			btnShowItems.Tag = "PENDING ITEMS";
			lblTitle.Text = string_2 + " RECENTLY MADE ITEMS";
			lblTitle.BackColor = Color.FromArgb(214, 142, 81);
			BackColor = Color.FromArgb(42, 102, 134);
			btnPrintOrder.Text = Resources.UNDO_ORDER_MADE;
			btnItemMade.Text = Resources.UNDO_ITEM_MADE;
			method_4();
		}
		else
		{
			bool_1 = false;
			btnShowItems.Text = Resources.SHOW_RECENTLY_MADE_ITEMS;
			btnShowItems.Tag = "MADE ITEMS";
			lblTitle.Text = string_2 + " PENDING ITEMS";
			lblTitle.BackColor = Color.FromArgb(147, 101, 184);
			BackColor = Color.FromArgb(35, 39, 56);
			radListItems.BackColor = Color.LightGray;
			btnPrintOrder.Text = Resources.ORDER_MADE;
			btnItemMade.Text = Resources.ITEM_MADE;
			method_4();
		}
	}

	private void method_5()
	{
		lblDescription.Left = lblCourse.Left + lblCourse.Width + 1;
		radListItems.Columns[0].Width = lblTime.Width + 1;
		radListItems.Columns[1].Width = lblOrderNum.Width + 1;
		radListItems.Columns[2].Width = lblOrderType.Width + 1;
		radListItems.Columns[3].Width = lblCustomer.Width + 1;
		radListItems.Columns[4].Width = lblQty.Width + 1;
		radListItems.Columns[5].Width = lblCourse.Width + 1;
		radListItems.Columns[6].Width = lblDescription.Width - 10;
		radListItems.CellFormatting += radListItems_CellFormatting;
	}

	private void radListItems_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
	{
		if (e.CellElement.Data.HeaderText == "Column 4" && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
		}
	}

	private void btnEnterOrder_Click(object sender, EventArgs e)
	{
		if (!new GClass6().CompanySetups.FirstOrDefault().isOpen)
		{
			new NotificationLabel(this, "Store is closed, please open the store.", NotificationTypes.Warning).Show();
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN, 0);
		bool flag = false;
		do
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
			{
				flag = true;
				continue;
			}
			Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
			if (employee != null)
			{
				flag = true;
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
				switch (SettingsHelper.GetSettingValueByKey("restaurant_mode"))
				{
				case "Quick Service":
					method_6();
					break;
				case "Dine In":
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Layout();
					MemoryLoadedObjects.Layout.LoadFormData();
					MemoryLoadedObjects.Layout.Show(this);
					break;
				case null:
					method_6();
					break;
				}
			}
			else
			{
				new NotificationLabel(this, Resources.Invalid_PIN_entered, NotificationTypes.Warning).Show();
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
			}
		}
		while (!flag);
	}

	private void method_6()
	{
		if (MemoryLoadedObjects.QuickService != null && !MemoryLoadedObjects.QuickService.IsDisposed)
		{
			if (MemoryLoadedObjects.QuickService != null && MemoryLoadedObjects.QuickService.Visible)
			{
				MemoryLoadedObjects.QuickService.Hide();
			}
		}
		else
		{
			MemoryLoadedObjects.QuickService = new frmQuickService();
		}
		MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL");
		Rectangle bounds = AppSettings.MainScreen.Bounds;
		MemoryLoadedObjects.QuickService.WindowState = FormWindowState.Normal;
		MemoryLoadedObjects.QuickService.Size = new Size(bounds.Width, bounds.Height);
		MemoryLoadedObjects.QuickService.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
		MemoryLoadedObjects.QuickService.StartPosition = FormStartPosition.Manual;
		MemoryLoadedObjects.QuickService.ShowDialog();
	}

	private void btnShowDetails_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void btnScreenRefresh_Click(object sender, EventArgs e)
	{
		OrderHelper.OnlineOrderRefresh();
		method_4();
	}

	private void radListItems_SelectedItemChanged(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			btnPrintOrder.Enabled = true;
			btnItemMade.Enabled = true;
			btnShowDetails.Enabled = true;
			btnPutOrderOnHold.Enabled = true;
		}
		else
		{
			btnPrintOrder.Enabled = false;
			btnItemMade.Enabled = false;
			btnShowDetails.Enabled = false;
			btnPutOrderOnHold.Enabled = false;
		}
	}

	private void btnChangeView_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Setting setting = (from s in gClass.Settings.ToList()
			where s.Key == "kitchen_station_view"
			select s).FirstOrDefault();
		if (setting != null)
		{
			setting.Value = "tile";
			Helper.SubmitChangesWithCatch(gClass);
			SettingsHelper.SetSettingValueByKey("kitchen_station_view", setting.Value);
			SettingsHelper.SetAllSettings();
			new frmStationTiles(sender, short_0).Show();
			Close();
			Dispose();
		}
	}

	private void btnPutOrderOnHold_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Number of minutes to hold order.", 0, 3);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		if (MemoryLoadedObjects.Numpad.numberEntered <= 0m)
		{
			new NotificationLabel(this, "Please enter a value greater than 0.", NotificationTypes.Warning).Show();
			return;
		}
		string orderNumber = radListItems.SelectedItems[0].SubItems[1].ToString();
		OrderMethods orderMethods = new OrderMethods();
		List<Order> list = orderMethods.Orders(orderNumber);
		if (!bool_1)
		{
			list = list.Where((Order order_0) => order_0.StationID.Contains(short_0.ToString()) && !order_0.DateFilled.HasValue).ToList();
		}
		foreach (Order item in list)
		{
			item.OrderOnHoldTime = (int)(DateTime.Now - item.DateCreated.Value).TotalMinutes + (int)MemoryLoadedObjects.Numpad.numberEntered;
		}
		orderMethods.SubmitChanges();
		method_4();
	}

	private void btnChangeStation_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary = MemoryLoadedObjects.all_stations.Where((Station station_0) => station_0.StationID != short_0 && (station_0.SystemDefinedID != 2 || !station_0.SystemDefinedID.HasValue) && station_0.SendToStation).ToList().ToDictionary((Station a) => a.StationID.ToString(), (Station a) => a.StationName);
		frmButtonSelector frmButtonSelector2 = new frmButtonSelector("Change Station", dictionary);
		if (frmButtonSelector2.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		if (button_0 != null)
		{
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (button_0.Name == "btnStation1")
			{
				terminal.DefaultStation1 = Convert.ToInt32(frmButtonSelector2.SelectedValue);
			}
			else
			{
				terminal.DefaultStation2 = Convert.ToInt32(frmButtonSelector2.SelectedValue);
			}
			button_0.Text = frmButtonSelector2.SelectedDisplay.ToUpper() + " DISPLAY";
			Helper.SubmitChangesWithCatch(gClass);
		}
		else if (SettingsHelper.CurrentTerminalMode == "KitchenDisplay" || SettingsHelper.CurrentTerminalMode == "BarDisplay")
		{
			Terminal terminal2 = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (terminal2 != null)
			{
				terminal2.DefaultStation1 = Convert.ToInt32(frmButtonSelector2.SelectedValue);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		new frmStationTiles(sender, Convert.ToInt16(frmButtonSelector2.SelectedValue)).Show();
		Close();
		Dispose();
	}

	private void btnClearSearch_Click(object sender, EventArgs e)
	{
		txtSearchInfo.Text = "";
		method_4();
	}

	private void btnShowKeyboard_SearchInfo_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Search Orders", 0, 49, txtSearchInfo.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtSearchInfo.Text = MemoryLoadedObjects.Keyboard.textEntered;
			base.DialogResult = DialogResult.None;
		}
	}

	private void txtSearchInfo_TextChanged(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_7(Button button_1)
	{
		string_3 = button_1.Text;
		Button button = btnOTFilter_All;
		Button button2 = btnOTFilter_DineIn;
		Button button3 = btnOTFilter_ToGo;
		Button button4 = btnOTFilter_PickUp;
		Button button5 = btnOTFilter_Delivery;
		Color color2 = (btnOTFilter_Catering.BackColor = Color.FromArgb(176, 124, 219));
		Color color4 = (button5.BackColor = color2);
		Color color6 = (button4.BackColor = color4);
		Color color8 = (button3.BackColor = color6);
		Color color11 = (button.BackColor = (button2.BackColor = color8));
		button_1.BackColor = Color.FromArgb(214, 142, 81);
		method_4();
	}

	private void btnOTFilter_All_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void btnOTFilter_DineIn_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void btnOTFilter_ToGo_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void btnOTFilter_PickUp_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void btnOTFilter_Delivery_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void btnOTFilter_Catering_Click(object sender, EventArgs e)
	{
		method_7((Button)sender);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		PrintHelper.PrintReceiptCheck();
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(MemoryLoadedData.OnlineOrderErrorMessage))
		{
			timer_2.Enabled = false;
			new frmMessageBox(MemoryLoadedData.OnlineOrderErrorMessage, "Online Order Error").ShowDialog();
			MemoryLoadedData.OnlineOrderErrorMessage = string.Empty;
			timer_2.Enabled = true;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmStation));
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "Column 0");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Column 1");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 2", "Column 2");
		ListViewDetailColumn listViewDetailColumn4 = new ListViewDetailColumn("Column 3", "Column 3");
		ListViewDetailColumn listViewDetailColumn5 = new ListViewDetailColumn("Column 4", "Column 4");
		ListViewDetailColumn listViewDetailColumn6 = new ListViewDetailColumn("Column 5", "Column 5");
		ListViewDetailColumn listViewDetailColumn7 = new ListViewDetailColumn("Column 6", "Column 6");
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		windows8Theme_0 = new Windows8Theme();
		lblCounter = new Label();
		btnScreenRefresh = new Button();
		lblTitle = new Label();
		pnlMain = new Panel();
		btnOTFilter_All = new Button();
		label1 = new Label();
		btnOTFilter_Catering = new Button();
		btnOTFilter_Delivery = new Button();
		btnOTFilter_PickUp = new Button();
		btnOTFilter_ToGo = new Button();
		btnOTFilter_DineIn = new Button();
		btnClearSearch = new Button();
		label3 = new Label();
		txtSearchInfo = new RadTextBoxControl();
		btnShowKeyboard_SearchInfo = new Button();
		btnPutOrderOnHold = new Button();
		lblOrderNum = new Label();
		btnChangeView = new Button();
		verticalScrollControl1 = new VerticalScrollControl();
		lblCustomer = new Label();
		lblCourse = new Label();
		lblTraining = new Label();
		btnEnterOrder = new Button();
		btnShowItems = new Button();
		lblOrderType = new Label();
		lblTime = new Label();
		BtnCancel = new Button();
		lblQty = new Label();
		btnPrintOrder = new Button();
		lblDescription = new Label();
		btnClearCancelled = new Button();
		btnItemMade = new Button();
		btnShowDetails = new Button();
		radListItems = new CustomListViewTelerik();
		btnChangeStation = new Button();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		timer_2 = new System.Windows.Forms.Timer(icontainer_1);
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		((ISupportInitialize)radListItems).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		lblCounter.BackColor = Color.FromArgb(65, 168, 95);
		componentResourceManager.ApplyResources(lblCounter, "lblCounter");
		lblCounter.ForeColor = Color.White;
		lblCounter.Name = "lblCounter";
		lblCounter.Click += btnScreenRefresh_Click;
		componentResourceManager.ApplyResources(btnScreenRefresh, "btnScreenRefresh");
		btnScreenRefresh.BackColor = Color.FromArgb(65, 168, 95);
		btnScreenRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnScreenRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnScreenRefresh.ForeColor = Color.White;
		btnScreenRefresh.Name = "btnScreenRefresh";
		btnScreenRefresh.UseVisualStyleBackColor = true;
		btnScreenRefresh.Click += btnScreenRefresh_Click;
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.FlatStyle = FlatStyle.Flat;
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(pnlMain, "pnlMain");
		pnlMain.Controls.Add(btnOTFilter_All);
		pnlMain.Controls.Add(label1);
		pnlMain.Controls.Add(btnOTFilter_Catering);
		pnlMain.Controls.Add(btnOTFilter_Delivery);
		pnlMain.Controls.Add(btnOTFilter_PickUp);
		pnlMain.Controls.Add(btnOTFilter_ToGo);
		pnlMain.Controls.Add(btnOTFilter_DineIn);
		pnlMain.Controls.Add(btnClearSearch);
		pnlMain.Controls.Add(label3);
		pnlMain.Controls.Add(txtSearchInfo);
		pnlMain.Controls.Add(btnShowKeyboard_SearchInfo);
		pnlMain.Controls.Add(btnPutOrderOnHold);
		pnlMain.Controls.Add(lblOrderNum);
		pnlMain.Controls.Add(btnChangeView);
		pnlMain.Controls.Add(verticalScrollControl1);
		pnlMain.Controls.Add(lblCustomer);
		pnlMain.Controls.Add(lblCourse);
		pnlMain.Controls.Add(lblTraining);
		pnlMain.Controls.Add(btnEnterOrder);
		pnlMain.Controls.Add(btnShowItems);
		pnlMain.Controls.Add(lblOrderType);
		pnlMain.Controls.Add(lblTime);
		pnlMain.Controls.Add(BtnCancel);
		pnlMain.Controls.Add(lblQty);
		pnlMain.Controls.Add(btnPrintOrder);
		pnlMain.Controls.Add(lblDescription);
		pnlMain.Controls.Add(btnClearCancelled);
		pnlMain.Controls.Add(btnItemMade);
		pnlMain.Controls.Add(btnShowDetails);
		pnlMain.Controls.Add(radListItems);
		pnlMain.Name = "pnlMain";
		componentResourceManager.ApplyResources(btnOTFilter_All, "btnOTFilter_All");
		btnOTFilter_All.BackColor = Color.FromArgb(214, 142, 81);
		btnOTFilter_All.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_All.FlatAppearance.BorderSize = 0;
		btnOTFilter_All.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_All.ForeColor = Color.White;
		btnOTFilter_All.Name = "btnOTFilter_All";
		btnOTFilter_All.UseVisualStyleBackColor = false;
		btnOTFilter_All.Click += btnOTFilter_All_Click;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.Gray;
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(btnOTFilter_Catering, "btnOTFilter_Catering");
		btnOTFilter_Catering.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_Catering.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_Catering.FlatAppearance.BorderSize = 0;
		btnOTFilter_Catering.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_Catering.ForeColor = Color.White;
		btnOTFilter_Catering.Name = "btnOTFilter_Catering";
		btnOTFilter_Catering.UseVisualStyleBackColor = false;
		btnOTFilter_Catering.Click += btnOTFilter_Catering_Click;
		componentResourceManager.ApplyResources(btnOTFilter_Delivery, "btnOTFilter_Delivery");
		btnOTFilter_Delivery.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_Delivery.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_Delivery.FlatAppearance.BorderSize = 0;
		btnOTFilter_Delivery.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_Delivery.ForeColor = Color.White;
		btnOTFilter_Delivery.Name = "btnOTFilter_Delivery";
		btnOTFilter_Delivery.UseVisualStyleBackColor = false;
		btnOTFilter_Delivery.Click += btnOTFilter_Delivery_Click;
		componentResourceManager.ApplyResources(btnOTFilter_PickUp, "btnOTFilter_PickUp");
		btnOTFilter_PickUp.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_PickUp.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_PickUp.FlatAppearance.BorderSize = 0;
		btnOTFilter_PickUp.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_PickUp.ForeColor = Color.White;
		btnOTFilter_PickUp.Name = "btnOTFilter_PickUp";
		btnOTFilter_PickUp.UseVisualStyleBackColor = false;
		btnOTFilter_PickUp.Click += btnOTFilter_PickUp_Click;
		componentResourceManager.ApplyResources(btnOTFilter_ToGo, "btnOTFilter_ToGo");
		btnOTFilter_ToGo.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_ToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_ToGo.FlatAppearance.BorderSize = 0;
		btnOTFilter_ToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_ToGo.ForeColor = Color.White;
		btnOTFilter_ToGo.Name = "btnOTFilter_ToGo";
		btnOTFilter_ToGo.UseVisualStyleBackColor = false;
		btnOTFilter_ToGo.Click += btnOTFilter_ToGo_Click;
		componentResourceManager.ApplyResources(btnOTFilter_DineIn, "btnOTFilter_DineIn");
		btnOTFilter_DineIn.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_DineIn.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_DineIn.FlatAppearance.BorderSize = 0;
		btnOTFilter_DineIn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_DineIn.ForeColor = Color.White;
		btnOTFilter_DineIn.Name = "btnOTFilter_DineIn";
		btnOTFilter_DineIn.UseVisualStyleBackColor = false;
		btnOTFilter_DineIn.Click += btnOTFilter_DineIn_Click;
		componentResourceManager.ApplyResources(btnClearSearch, "btnClearSearch");
		btnClearSearch.BackColor = Color.FromArgb(1, 110, 211);
		btnClearSearch.DialogResult = DialogResult.OK;
		btnClearSearch.FlatAppearance.BorderColor = Color.Black;
		btnClearSearch.FlatAppearance.BorderSize = 0;
		btnClearSearch.ForeColor = Color.White;
		btnClearSearch.Name = "btnClearSearch";
		btnClearSearch.UseVisualStyleBackColor = false;
		btnClearSearch.Click += btnClearSearch_Click;
		label3.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtSearchInfo, "txtSearchInfo");
		txtSearchInfo.ForeColor = Color.FromArgb(40, 40, 40);
		txtSearchInfo.Name = "txtSearchInfo";
		txtSearchInfo.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSearchInfo.TextChanged += txtSearchInfo_TextChanged;
		txtSearchInfo.Click += btnShowKeyboard_SearchInfo_Click;
		((RadTextBoxControlElement)txtSearchInfo.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSearchInfo.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(btnShowKeyboard_SearchInfo, "btnShowKeyboard_SearchInfo");
		btnShowKeyboard_SearchInfo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchInfo.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_SearchInfo.ForeColor = Color.White;
		btnShowKeyboard_SearchInfo.Name = "btnShowKeyboard_SearchInfo";
		btnShowKeyboard_SearchInfo.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchInfo.Click += btnShowKeyboard_SearchInfo_Click;
		componentResourceManager.ApplyResources(btnPutOrderOnHold, "btnPutOrderOnHold");
		btnPutOrderOnHold.BackColor = Color.FromArgb(61, 142, 185);
		btnPutOrderOnHold.FlatAppearance.BorderColor = Color.Black;
		btnPutOrderOnHold.FlatAppearance.BorderSize = 0;
		btnPutOrderOnHold.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPutOrderOnHold.ForeColor = Color.White;
		btnPutOrderOnHold.Name = "btnPutOrderOnHold";
		btnPutOrderOnHold.UseVisualStyleBackColor = false;
		btnPutOrderOnHold.EnabledChanged += btnShowDetails_EnabledChanged;
		btnPutOrderOnHold.Click += btnPutOrderOnHold_Click;
		lblOrderNum.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblOrderNum, "lblOrderNum");
		lblOrderNum.ForeColor = Color.White;
		lblOrderNum.Name = "lblOrderNum";
		componentResourceManager.ApplyResources(btnChangeView, "btnChangeView");
		btnChangeView.BackColor = Color.FromArgb(42, 102, 134);
		btnChangeView.FlatAppearance.BorderColor = Color.Black;
		btnChangeView.FlatAppearance.BorderSize = 0;
		btnChangeView.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChangeView.ForeColor = Color.White;
		btnChangeView.Name = "btnChangeView";
		btnChangeView.UseVisualStyleBackColor = false;
		btnChangeView.Click += btnChangeView_Click;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Name = "verticalScrollControl1";
		lblCustomer.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblCustomer, "lblCustomer");
		lblCustomer.ForeColor = Color.White;
		lblCustomer.Name = "lblCustomer";
		lblCourse.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblCourse, "lblCourse");
		lblCourse.ForeColor = Color.White;
		lblCourse.Name = "lblCourse";
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(btnEnterOrder, "btnEnterOrder");
		btnEnterOrder.BackColor = Color.FromArgb(255, 192, 128);
		btnEnterOrder.FlatAppearance.BorderColor = Color.Black;
		btnEnterOrder.FlatAppearance.BorderSize = 0;
		btnEnterOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnEnterOrder.ForeColor = Color.White;
		btnEnterOrder.Name = "btnEnterOrder";
		btnEnterOrder.UseVisualStyleBackColor = false;
		btnEnterOrder.Click += btnEnterOrder_Click;
		componentResourceManager.ApplyResources(btnShowItems, "btnShowItems");
		btnShowItems.BackColor = Color.FromArgb(147, 101, 184);
		btnShowItems.FlatAppearance.BorderColor = Color.Black;
		btnShowItems.FlatAppearance.BorderSize = 0;
		btnShowItems.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnShowItems.ForeColor = Color.White;
		btnShowItems.Name = "btnShowItems";
		btnShowItems.UseVisualStyleBackColor = false;
		btnShowItems.Click += btnShowItems_Click;
		lblOrderType.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblOrderType, "lblOrderType");
		lblOrderType.ForeColor = Color.White;
		lblOrderType.Name = "lblOrderType";
		lblTime.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblTime, "lblTime");
		lblTime.ForeColor = Color.White;
		lblTime.Name = "lblTime";
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.Black;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		lblQty.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(lblQty, "lblQty");
		lblQty.ForeColor = Color.White;
		lblQty.Name = "lblQty";
		componentResourceManager.ApplyResources(btnPrintOrder, "btnPrintOrder");
		btnPrintOrder.BackColor = Color.FromArgb(77, 174, 225);
		btnPrintOrder.FlatAppearance.BorderColor = Color.Black;
		btnPrintOrder.FlatAppearance.BorderSize = 0;
		btnPrintOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrintOrder.ForeColor = Color.White;
		btnPrintOrder.Name = "btnPrintOrder";
		btnPrintOrder.UseVisualStyleBackColor = false;
		btnPrintOrder.EnabledChanged += btnShowDetails_EnabledChanged;
		btnPrintOrder.Click += btnPrintOrder_Click;
		componentResourceManager.ApplyResources(lblDescription, "lblDescription");
		lblDescription.BackColor = Color.FromArgb(61, 142, 185);
		lblDescription.ForeColor = Color.White;
		lblDescription.Name = "lblDescription";
		componentResourceManager.ApplyResources(btnClearCancelled, "btnClearCancelled");
		btnClearCancelled.BackColor = Color.FromArgb(214, 142, 81);
		btnClearCancelled.FlatAppearance.BorderColor = Color.Black;
		btnClearCancelled.FlatAppearance.BorderSize = 0;
		btnClearCancelled.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClearCancelled.ForeColor = Color.White;
		btnClearCancelled.Name = "btnClearCancelled";
		btnClearCancelled.UseVisualStyleBackColor = false;
		btnClearCancelled.EnabledChanged += btnShowDetails_EnabledChanged;
		btnClearCancelled.Click += btnClearCancelled_Click;
		componentResourceManager.ApplyResources(btnItemMade, "btnItemMade");
		btnItemMade.BackColor = Color.FromArgb(80, 203, 116);
		btnItemMade.FlatAppearance.BorderColor = Color.Black;
		btnItemMade.FlatAppearance.BorderSize = 0;
		btnItemMade.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnItemMade.ForeColor = Color.White;
		btnItemMade.Name = "btnItemMade";
		btnItemMade.UseVisualStyleBackColor = false;
		btnItemMade.EnabledChanged += btnShowDetails_EnabledChanged;
		btnItemMade.Click += btnItemMade_Click;
		componentResourceManager.ApplyResources(btnShowDetails, "btnShowDetails");
		btnShowDetails.BackColor = Color.FromArgb(176, 124, 219);
		btnShowDetails.FlatAppearance.BorderColor = Color.Black;
		btnShowDetails.FlatAppearance.BorderSize = 0;
		btnShowDetails.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnShowDetails.ForeColor = Color.White;
		btnShowDetails.Name = "btnShowDetails";
		btnShowDetails.UseVisualStyleBackColor = false;
		btnShowDetails.EnabledChanged += btnShowDetails_EnabledChanged;
		btnShowDetails.Click += btnShowDetails_Click;
		radListItems.AllowArbitraryItemHeight = true;
		radListItems.AllowEdit = false;
		radListItems.AllowRemove = false;
		componentResourceManager.ApplyResources(radListItems, "radListItems");
		listViewDetailColumn.HeaderText = "Column 0";
		listViewDetailColumn2.HeaderText = "Column 1";
		listViewDetailColumn3.HeaderText = "Column 2";
		listViewDetailColumn4.HeaderText = "Column 3";
		listViewDetailColumn5.HeaderText = "Column 4";
		listViewDetailColumn6.HeaderText = "Column 5";
		listViewDetailColumn7.HeaderText = "Column 6";
		radListItems.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2, listViewDetailColumn3, listViewDetailColumn4, listViewDetailColumn5, listViewDetailColumn6, listViewDetailColumn7);
		radListItems.EnableKineticScrolling = true;
		radListItems.ItemSpacing = -1;
		radListItems.Name = "radListItems";
		radListItems.ShowColumnHeaders = false;
		radListItems.ShowGridLines = true;
		radListItems.ViewType = ListViewType.DetailsView;
		radListItems.SelectedItemChanged += radListItems_SelectedItemChanged;
		componentResourceManager.ApplyResources(btnChangeStation, "btnChangeStation");
		btnChangeStation.BackColor = Color.FromArgb(214, 142, 81);
		btnChangeStation.FlatAppearance.BorderColor = Color.Black;
		btnChangeStation.FlatAppearance.BorderSize = 0;
		btnChangeStation.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChangeStation.ForeColor = Color.White;
		btnChangeStation.Name = "btnChangeStation";
		btnChangeStation.UseVisualStyleBackColor = false;
		btnChangeStation.Click += btnChangeStation_Click;
		timer_1.Interval = 1500;
		timer_1.Tick += timer_1_Tick;
		timer_2.Enabled = true;
		timer_2.Interval = 5000;
		timer_2.Tick += timer_2_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnChangeStation);
		base.Controls.Add(lblCounter);
		base.Controls.Add(btnScreenRefresh);
		base.Controls.Add(lblTitle);
		base.Controls.Add(pnlMain);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmStation";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmStation_Load;
		base.VisibleChanged += frmStation_VisibleChanged;
		base.Controls.SetChildIndex(pnlMain, 0);
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(btnScreenRefresh, 0);
		base.Controls.SetChildIndex(lblCounter, 0);
		base.Controls.SetChildIndex(btnChangeStation, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlMain.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtSearchInfo).EndInit();
		((ISupportInitialize)radListItems).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_8(Station station_0)
	{
		return station_0.StationID == short_0;
	}

	[CompilerGenerated]
	private bool method_9(Order order_0)
	{
		if (order_0.StationID != null && order_0.StationID.Contains(short_0.ToString()))
		{
			return !order_0.DateFilled.HasValue;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_10(Order order_0)
	{
		if (order_0.StationID != null && order_0.StationID.Contains(short_0.ToString()) && order_0.DateFilled.HasValue)
		{
			return order_0.ItemID != -100;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_11(Order order_0)
	{
		if (order_0.StationID.Contains(short_0.ToString()))
		{
			return !order_0.DateFilled.HasValue;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_12(Station station_0)
	{
		if (station_0.StationID != short_0 && (station_0.SystemDefinedID != 2 || !station_0.SystemDefinedID.HasValue))
		{
			return station_0.SendToStation;
		}
		return false;
	}
}
