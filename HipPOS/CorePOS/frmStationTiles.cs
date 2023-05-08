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
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmStationTiles : frmMasterForm
{
	private short short_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private int int_1;

	private float float_0;

	private string string_0;

	private int int_2;

	private bool bool_2;

	private bool bool_3;

	private List<OrderChit> list_2;

	private Button button_0;

	private string string_1;

	private IContainer icontainer_1;

	internal Button btnOrderMade;

	internal Button BtnCancel;

	internal Button uIvVfnvwe1;

	private System.Windows.Forms.Timer timer_0;

	private Panel pnlMain;

	private Label lblTitle;

	internal Button btnEnterOrder;

	internal Button btnScreenRefresh;

	private Label lblTraining;

	private Label lblCounter;

	private VerticalScrollControl verticalScrollControl1;

	private FlowLayoutPanel cqvEnKpyg0;

	internal Button btnPrint;

	internal Button btnPrintClear;

	internal Button btnChangeView;

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

	public frmStationTiles(object sender, short _stationID)
	{
		Class26.Ggkj0JxzN9YmC();
		int_0 = 20;
		int_1 = 20;
		float_0 = 13f;
		int_2 = 3;
		list_2 = new List<OrderChit>();
		string_1 = "ALL";
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
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Visible = true;
		}
		else
		{
			lblTraining.Visible = false;
		}
		bool_2 = ((SettingsHelper.GetSettingValueByKey("print_chit_cashout") == "ON") ? true : false);
		bool_3 = ((SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON") ? true : false);
		uIvVfnvwe1.Tag = Color.FromArgb(214, 142, 81);
		string_0 = gClass.CompanySetups.FirstOrDefault().Name;
		verticalScrollControl1.ConnectedPanel = cqvEnKpyg0;
	}

	private void frmStationTiles_Load(object sender, EventArgs e)
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
		lblCounter.Location = new Point(btnScreenRefresh.Left + 5, btnScreenRefresh.Top + 15);
		lblTitle.Text = station.StationName.ToUpper() + " PENDING ITEMS";
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
		method_5();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode != "KitchenDisplay")
		{
			foreach (OrderChit item in list_2)
			{
				if (item.RefreshThread != null)
				{
					item.RefreshThread.Abort();
				}
			}
			string_0 = null;
			list_2 = null;
			GC.Collect();
			Dispose();
			return;
		}
		ModulesAndFeature modulesAndFeature = new GClass6().ModulesAndFeatures.Where((ModulesAndFeature x) => x.ModuleName == "frmSplash" && x.ControlName == "btnClose").FirstOrDefault();
		if (modulesAndFeature != null)
		{
			List<SecurityMatrix> list = modulesAndFeature.SecurityMatrixes.Where((SecurityMatrix x) => x.IsAllow).ToList();
			List<string> list2 = new List<string>();
			using (List<SecurityMatrix>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					switch (enumerator2.Current.RoleID)
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

	private void btnOrderMade_Click(object sender, EventArgs e)
	{
		foreach (OrderChit item in list_2.Where((OrderChit x) => x.Selected).ToList())
		{
			method_3(item);
		}
	}

	private void method_3(OrderChit orderChit_0)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.selectedList = orderChit_0;
		OrderMethods orderMethods = new OrderMethods();
		if (CS_0024_003C_003E8__locals0.selectedList != null)
		{
			_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass17_1();
			CS_0024_003C_003E8__locals1.orderNumber = CS_0024_003C_003E8__locals0.selectedList.Name;
			string tableName = CS_0024_003C_003E8__locals0.selectedList.TableName;
			string text = CS_0024_003C_003E8__locals0.selectedList.OrderType;
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
			case "MTS":
				text = OrderTypes.MakeToStock;
				break;
			}
			List<Order> source = ((!(SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON") || !(text == OrderTypes.DineIn)) ? (from o in orderMethods.Orders(CS_0024_003C_003E8__locals1.orderNumber)
				where o.OrderOnHoldTime == 0 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime))
				select o).ToList() : (from o in orderMethods.UnfilledOrderTable(tableName)
				where o.OrderOnHoldTime == 0 || (o.OrderOnHoldTime != 0 && o.DateCreated.Value < DateTime.Now.AddMinutes(-o.OrderOnHoldTime))
				select o).ToList());
			source = (bool_1 ? source.Where((Order o) => o.StationID != null && o.StationID.Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.short_0.ToString()) && o.DateFilled.HasValue).ToList() : source.Where((Order o) => o.StationID != null && o.StationID.Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.short_0.ToString()) && !o.DateFilled.HasValue).ToList());
			if (source.Where((Order x) => x.FulfillmentAt.HasValue).Count() > 0 && source.Where((Order o) => o.FulfillmentAt.HasValue && o.FulfillmentAt <= DateTime.Now.AddMinutes(30.0)).Count() == 0)
			{
				new NotificationLabel(this, "You cannot complete this order at this time.", NotificationTypes.Notification).Show();
				return;
			}
			bool flag = source.Where((Order a) => !a.Void).Count() <= 0;
			if (source.Count() > 0)
			{
				string customer = source.FirstOrDefault().Customer;
				InventoryMethods inventoryMethods = new InventoryMethods();
				foreach (Order item in source.ToList())
				{
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
					}
					item.ItemMadeNotified = (bool_1 ? true : false);
					if (!bool_1)
					{
						if (!item.Void)
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
							if (!item2.Void)
							{
								inventoryMethods.SubtractMaterialInventory(item2);
								if (!(SettingsHelper.GetSettingValueByKey("production_mode") == "Disabled") && !(item.OrderType != OrderTypes.MakeToStock))
								{
									inventoryMethods.AddItemInventory(item2, "MAKE TO STOCK");
									inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: false);
									item.Paid = true;
									item.DatePaid = DateTime.Now;
									item.DateCleared = DateTime.Now;
									item.PaymentMethods = "MAKE TO STOCK=0.00|";
								}
								else
								{
									inventoryMethods.SubtractItemInventory(item2);
									inventoryMethods.UpdateExpiryItem(item2.InventoryBatchId, item2.Qty, toSubtract: true);
								}
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
					}
				}
				orderMethods.SubmitChanges();
				if ((text.Contains(OrderTypes.PickUp) || text.Contains(OrderTypes.Delivery) || text.Contains(OrderTypes.DeliveryOnline) || text.Contains(OrderTypes.PickUpOnline) || text.Contains(OrderTypes.TakeOutOnline) || text.Contains(OrderTypes.ToGo)) && !flag && !bool_1)
				{
					Station singleStation = new StationMethods().GetSingleStation(short_0);
					if (MemoryLoadedObjects.all_stations.Where((Station a) => a.SendToStation && a.AutoPrint).Any() && !new GClass6().Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.orderNumber && a.ItemID > 0 && a.Void == false && a.StationID != null && a.DateFilled == null).Any())
					{
						PrintHelper.GenerateReceipt(CS_0024_003C_003E8__locals1.orderNumber, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, singleStation.PrinterName);
					}
					if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled" && !string.IsNullOrEmpty(customer) && !new GClass6().Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.orderNumber && a.ItemID > 0 && a.Void == false && a.StationID != null && a.DateFilled == null).Any())
					{
						MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals1.orderNumber, customer, text);
					}
				}
				if (!bool_1 && (text == OrderTypes.DeliveryOnline || text == OrderTypes.TakeOutOnline || text == OrderTypes.PickUpOnline || text == OrderTypes.PickUpCurbsideOnline || text == OrderTypes.DineInOnline))
				{
					new OrderHelper().UpdateOrderStatusInOrdering(orderMethods.Orders(CS_0024_003C_003E8__locals1.orderNumber).FirstOrDefault(), isSingleOrder: false);
				}
			}
			list_2.Remove(list_2.Where((OrderChit x) => x.Name == CS_0024_003C_003E8__locals0.selectedList.Name).FirstOrDefault());
			CS_0024_003C_003E8__locals0.selectedList.Refresh();
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
			method_5();
		}
	}

	private void frmStationTiles_VisibleChanged(object sender, EventArgs e)
	{
	}

	private void uIvVfnvwe1_Click(object sender, EventArgs e)
	{
		OrderMethods orderMethods = new OrderMethods();
		List<OrderChit> list = list_2.ToList();
		bool flag = false;
		if (list.Count > 0)
		{
			using (List<OrderChit>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
					CS_0024_003C_003E8__locals0.chit = enumerator.Current;
					if (CS_0024_003C_003E8__locals0.chit == null)
					{
						continue;
					}
					foreach (Order item in (from x in orderMethods.UnfilledRefundedAndVoidOrders(short_0)
						where CS_0024_003C_003E8__locals0.chit.OrderNumber.Contains(x.OrderNumber)
						select x).ToList())
					{
						item.DateFilled = DateTime.Now;
						if (!string.IsNullOrEmpty(item.StationID))
						{
							item.StationMade = StationMethods.AddStationIdFromStationIds(item.StationMade, short_0.ToString());
						}
						flag = true;
					}
					if (flag)
					{
						orderMethods.SubmitChanges();
						CS_0024_003C_003E8__locals0.chit.Selected = false;
						CS_0024_003C_003E8__locals0.chit.Refresh();
					}
				}
			}
			if (!flag)
			{
				new NotificationLabel(this, "There were no cancelled orders to clear.", NotificationTypes.Notification).Show();
			}
		}
		else
		{
			new NotificationLabel(this, "Please select a chit to clear.", NotificationTypes.Notification).Show();
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
					method_4();
					break;
				case "Dine In":
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Layout();
					MemoryLoadedObjects.Layout.LoadFormData();
					MemoryLoadedObjects.Layout.Show(this);
					break;
				case null:
					method_4();
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

	private void method_4()
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

	private void uIvVfnvwe1_EnabledChanged(object sender, EventArgs e)
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
		method_5();
	}

	private async void method_5()
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.isNotify = false;
		CS_0024_003C_003E8__locals0.isItemsCancelled = false;
		CS_0024_003C_003E8__locals0.isItemModified = false;
		try
		{
			Button btnCancel = BtnCancel;
			Button button = btnScreenRefresh;
			btnChangeView.Enabled = false;
			button.Enabled = false;
			btnCancel.Enabled = false;
			int_1 = int_0;
			lblCounter.Text = int_1.ToString();
			await Task.Run(delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_6(CS_0024_003C_003E8__locals0._003C_003E4__this.txtSearchInfo.Text, CS_0024_003C_003E8__locals0._003C_003E4__this.cqvEnKpyg0, ref CS_0024_003C_003E8__locals0.isNotify, ref CS_0024_003C_003E8__locals0.isItemsCancelled, ref CS_0024_003C_003E8__locals0.isItemModified);
			});
			CS_0024_003C_003E8__locals0.isNotify = list_2.Where((OrderChit x) => x.isUpdated).Count() > 0;
		}
		catch
		{
			Button btnCancel2 = BtnCancel;
			Button button2 = btnScreenRefresh;
			btnChangeView.Enabled = true;
			button2.Enabled = true;
			btnCancel2.Enabled = true;
			return;
		}
		new Thread((ThreadStart)delegate
		{
			try
			{
				Thread.Sleep(2000);
				CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0._003C_003E4__this.verticalScrollControl1.EnableDisableButtonsByScrollPanel();
				});
			}
			catch (Exception)
			{
			}
		}).Start();
	}

	private void method_6(string string_2, FlowLayoutPanel flowLayoutPanel_0, ref bool bool_4, ref bool bool_5, ref bool bool_6)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.query = string_2;
		CS_0024_003C_003E8__locals0.pnl = flowLayoutPanel_0;
		try
		{
			bool_4 = false;
			if (!bool_0)
			{
				_003C_003Ec__DisplayClass26_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass26_1();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				OrderMethods orderMethods = new OrderMethods();
				new GClass6();
				new ItemMethods();
				bool_0 = true;
				CS_0024_003C_003E8__locals1.existingOrderNumbers = new List<string>();
				list_2.RemoveAll((OrderChit x) => x.IsDisposed);
				List<Order> source = orderMethods.UnfilledOrders(short_0).ToList();
				using (List<OrderChit>.Enumerator enumerator = list_2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass26_2 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass26_2();
						CS_0024_003C_003E8__locals3.ochit = enumerator.Current;
						if (CS_0024_003C_003E8__locals3.ochit.IsDisposed)
						{
							continue;
						}
						CS_0024_003C_003E8__locals1.existingOrderNumbers.AddRange(CS_0024_003C_003E8__locals3.ochit.OrderNumber);
						List<Order> source2 = source.Where((Order x) => CS_0024_003C_003E8__locals3.ochit.OrderNumber.Contains(x.OrderNumber) && (x.OrderOnHoldTime == 0 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value < DateTime.Now.AddMinutes(-x.OrderOnHoldTime)))).ToList();
						if (string_1 != "ALL")
						{
							source2 = source2.Where((Order x) => x.OrderType.ToUpper().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.string_1)).ToList();
						}
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query))
						{
							source2 = source2.Where((Order x) => (x.Customer != null && x.Customer.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query)) || (x.CustomerInfo != null && x.CustomerInfo.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query)) || (x.CustomerInfoName != null && x.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query)) || x.OrderNumber.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query) || (x.OrderTicketNumber != null && x.OrderTicketNumber.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query))).ToList();
						}
						if (bool_2)
						{
							source2 = source2.Where((Order a) => a.Paid).ToList();
						}
						if (bool_3)
						{
							source2 = source2.Where((Order a) => a.FlagID != 1 || a.FlagID == 0).ToList();
						}
						if (source2.Where((Order x) => x.Void).Count() == CS_0024_003C_003E8__locals3.ochit.VoidCount && source2.Count() == CS_0024_003C_003E8__locals3.ochit.OrderCount && !(source2.Sum((Order a) => a.Total) != CS_0024_003C_003E8__locals3.ochit.TotalTotal) && !(source2.Sum((Order a) => a.Qty) != CS_0024_003C_003E8__locals3.ochit.OrderQty))
						{
							CS_0024_003C_003E8__locals3.ochit.isUpdated = false;
						}
						else
						{
							Invoke((MethodInvoker)delegate
							{
								CS_0024_003C_003E8__locals3.ochit.Refresh();
							});
						}
						source2.All(delegate(Order x)
						{
							x.Notified = true;
							return true;
						});
						orderMethods.SubmitChanges();
					}
				}
				List<OrderTableNameAndNumber> source3 = orderMethods.UnfilledOrderNumbers(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.query, string_1, short_0, bool_2, bool_3).ToList();
				if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF")
				{
					source3 = (from a in source3
						group a by a.OrderNumber into a
						select new OrderTableNameAndNumber
						{
							OrderNumber = a.Key,
							OrderType = a.FirstOrDefault().OrderType,
							TableName = ""
						}).ToList();
				}
				int num = cqvEnKpyg0.Width / int_2 - 20;
				List<OrderChit> list = new List<OrderChit>();
				using (List<OrderTableNameAndNumber>.Enumerator enumerator2 = source3.Where((OrderTableNameAndNumber a) => !CS_0024_003C_003E8__locals1.existingOrderNumbers.Contains(a.OrderNumber)).ToList().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass26_3 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_3();
						_003C_003Ec__DisplayClass26_.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals1;
						_003C_003Ec__DisplayClass26_.orderSelected = enumerator2.Current;
						_003C_003Ec__DisplayClass26_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass26_4();
						CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass26_;
						CS_0024_003C_003E8__locals2.chit = null;
						if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF" || CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderType != OrderTypes.DineIn)
						{
							CS_0024_003C_003E8__locals2.chit = list_2.Where((OrderChit x) => x.OrderNumber.Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderNumber)).FirstOrDefault();
						}
						if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" && CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderType == OrderTypes.DineIn)
						{
							CS_0024_003C_003E8__locals2.chit = list_2.Where((OrderChit x) => x.TableName == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.TableName).FirstOrDefault();
							if (CS_0024_003C_003E8__locals2.chit == null)
							{
								CS_0024_003C_003E8__locals2.chit = list.Where((OrderChit x) => x.TableName == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.TableName).FirstOrDefault();
							}
							if (CS_0024_003C_003E8__locals2.chit != null)
							{
								CS_0024_003C_003E8__locals2.chit.OrderNumber.Add(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderNumber);
							}
						}
						if (CS_0024_003C_003E8__locals2.chit == null)
						{
							CS_0024_003C_003E8__locals2.chit = new OrderChit();
							CS_0024_003C_003E8__locals2.chit.Name = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderNumber;
							CS_0024_003C_003E8__locals2.chit.OrderNumber.Add(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.OrderNumber);
							CS_0024_003C_003E8__locals2.chit.StationID = short_0;
							CS_0024_003C_003E8__locals2.chit.Width = num;
							CS_0024_003C_003E8__locals2.chit.FontSize = float_0;
							CS_0024_003C_003E8__locals2.chit.TableName = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.orderSelected.TableName;
							bool_4 = true;
							list.Add(CS_0024_003C_003E8__locals2.chit);
							Invoke((MethodInvoker)delegate
							{
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.pnl.Controls.Add(CS_0024_003C_003E8__locals2.chit);
							});
						}
					}
				}
				list_2 = list_2.Union(list).ToList();
				Thread.Sleep(3000);
				list_2.RemoveAll((OrderChit x) => x.IsDisposed);
				bool_4 = list_2.Where((OrderChit x) => x.isUpdated).Count() > 0;
				bool_5 = list_2.Where((OrderChit x) => x.isItemCancelled).Count() > 0;
				bool_6 = list_2.Where((OrderChit x) => x.isItemChanged).Count() > 0;
				if (bool_4 | bool_6 | bool_5)
				{
					SoundPlayer soundPlayer = new SoundPlayer();
					soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\tada.wav";
					soundPlayer.Play();
				}
				if (bool_4)
				{
					Invoke((MethodInvoker)delegate
					{
						new NotificationLabel(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this, Resources.NEW_ORDER_S_HAVE_BEEN_RECEIVED, NotificationTypes.Notification).Show();
					});
				}
				if (bool_5)
				{
					Invoke((MethodInvoker)delegate
					{
						new NotificationLabel(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this, "Item(s) have been cancelled.", NotificationTypes.Notification).Show();
					});
				}
				if (bool_6)
				{
					Invoke((MethodInvoker)delegate
					{
						new NotificationLabel(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this, "Item(s) have been modified.", NotificationTypes.Notification).Show();
					});
				}
				bool_0 = false;
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			bool_0 = false;
		}
		try
		{
			Invoke((MethodInvoker)delegate
			{
				Button btnCancel = CS_0024_003C_003E8__locals0._003C_003E4__this.BtnCancel;
				Button button = CS_0024_003C_003E8__locals0._003C_003E4__this.btnScreenRefresh;
				CS_0024_003C_003E8__locals0._003C_003E4__this.btnChangeView.Enabled = true;
				button.Enabled = true;
				btnCancel.Enabled = true;
			});
		}
		catch
		{
		}
	}

	private void btnPrint_Click(object sender, EventArgs e)
	{
		method_7(bool_4: false);
	}

	private void btnPrintClear_Click(object sender, EventArgs e)
	{
		method_7(bool_4: true);
	}

	private void method_7(bool bool_4)
	{
		OrderHelper orderHelper = new OrderHelper();
		foreach (OrderChit item in list_2.Where((OrderChit x) => x.Selected).ToList())
		{
			if (item != null)
			{
				orderHelper.PrintToStation(item.OrderNumber.First(), item.OrderType, item.CustomerInfoName + " - " + item.Customer, short_0, item.EmployeeName, isOrderMade: false, reprint: true, printOnlyOne: true, item.TableName);
				if (bool_4)
				{
					method_3(item);
				}
				else
				{
					item.Selected = false;
				}
			}
		}
		orderHelper = null;
		GC.Collect();
	}

	private void btnChangeView_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Setting setting = (from s in gClass.Settings.ToList()
			where s.Key == "kitchen_station_view"
			select s).FirstOrDefault();
		if (setting != null)
		{
			setting.Value = "list";
			Helper.SubmitChangesWithCatch(gClass);
			SettingsHelper.SetSettingValueByKey("kitchen_station_view", setting.Value);
			SettingsHelper.SetAllSettings();
			new frmStation(sender, short_0).Show();
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
		List<OrderChit> list = list_2.Where((OrderChit x) => x.Selected).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (OrderChit item in list)
		{
			method_8(item, Convert.ToInt32(MemoryLoadedObjects.Numpad.valueEntered));
			list_2.Remove(item);
		}
		method_5();
	}

	private void method_8(OrderChit orderChit_0, int int_3)
	{
		if (orderChit_0 == null)
		{
			return;
		}
		OrderMethods orderMethods = new OrderMethods();
		new InventoryMethods();
		string name = orderChit_0.Name;
		List<Order> list = orderMethods.Orders(name).ToList();
		if (!bool_1)
		{
			list = list.Where((Order order_0) => order_0.StationID.Contains(short_0.ToString()) && !order_0.DateFilled.HasValue).ToList();
		}
		foreach (Order item in list)
		{
			item.OrderOnHoldTime = (int)(DateTime.Now - item.DateCreated.Value).TotalMinutes + int_3;
		}
		orderMethods.SubmitChanges();
		orderChit_0.Refresh();
	}

	private void btnChangeStation_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		List<Station> source = MemoryLoadedObjects.all_stations.Where((Station a) => a.StationID != CS_0024_003C_003E8__locals0._003C_003E4__this.short_0 && (a.SystemDefinedID != 2 || !a.SystemDefinedID.HasValue) && a.SendToStation).ToList();
		dictionary = source.ToDictionary((Station a) => a.StationID.ToString(), (Station a) => a.StationName);
		CS_0024_003C_003E8__locals0.stationsList = new frmButtonSelector("Change Station", dictionary);
		if (CS_0024_003C_003E8__locals0.stationsList.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		if (button_0 != null)
		{
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (button_0.Name == "btnStation1")
			{
				terminal.DefaultStation1 = Convert.ToInt32(CS_0024_003C_003E8__locals0.stationsList.SelectedValue);
			}
			else
			{
				terminal.DefaultStation2 = Convert.ToInt32(CS_0024_003C_003E8__locals0.stationsList.SelectedValue);
			}
			Helper.SubmitChangesWithCatch(gClass);
			button_0.Text = source.Where((Station x) => x.StationID == Convert.ToInt32(CS_0024_003C_003E8__locals0.stationsList.SelectedValue)).FirstOrDefault().StationName.ToUpper() + " DISPLAY";
		}
		else if (SettingsHelper.CurrentTerminalMode == "KitchenDisplay" || SettingsHelper.CurrentTerminalMode == "BarDisplay")
		{
			Terminal terminal2 = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (terminal2 != null)
			{
				terminal2.DefaultStation1 = Convert.ToInt32(CS_0024_003C_003E8__locals0.stationsList.SelectedValue);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		new frmStationTiles(sender, Convert.ToInt16(CS_0024_003C_003E8__locals0.stationsList.SelectedValue)).Show();
		Close();
		Dispose();
	}

	private void method_9(Button button_1)
	{
		cqvEnKpyg0.Controls.Clear();
		list_2.Clear();
		GC.Collect();
		string_1 = button_1.Text;
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
		method_5();
	}

	private void btnOTFilter_All_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_DineIn_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_ToGo_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_PickUp_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_Delivery_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_Catering_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnClearSearch_Click(object sender, EventArgs e)
	{
		txtSearchInfo.Text = "";
		method_5();
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
		cqvEnKpyg0.Controls.Clear();
		list_2.Clear();
		GC.Collect();
		method_5();
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		PrintHelper.PrintReceiptCheck();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmStationTiles));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
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
		lblTraining = new Label();
		btnPutOrderOnHold = new Button();
		btnChangeView = new Button();
		btnPrintClear = new Button();
		btnPrint = new Button();
		lblCounter = new Label();
		verticalScrollControl1 = new VerticalScrollControl();
		btnScreenRefresh = new Button();
		btnEnterOrder = new Button();
		BtnCancel = new Button();
		btnOrderMade = new Button();
		uIvVfnvwe1 = new Button();
		cqvEnKpyg0 = new FlowLayoutPanel();
		btnChangeStation = new Button();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
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
		pnlMain.Controls.Add(lblTraining);
		pnlMain.Controls.Add(btnPutOrderOnHold);
		pnlMain.Controls.Add(btnChangeView);
		pnlMain.Controls.Add(btnPrintClear);
		pnlMain.Controls.Add(btnPrint);
		pnlMain.Controls.Add(lblCounter);
		pnlMain.Controls.Add(verticalScrollControl1);
		pnlMain.Controls.Add(btnScreenRefresh);
		pnlMain.Controls.Add(btnEnterOrder);
		pnlMain.Controls.Add(BtnCancel);
		pnlMain.Controls.Add(btnOrderMade);
		pnlMain.Controls.Add(uIvVfnvwe1);
		pnlMain.Controls.Add(cqvEnKpyg0);
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
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(btnPutOrderOnHold, "btnPutOrderOnHold");
		btnPutOrderOnHold.BackColor = Color.FromArgb(61, 142, 185);
		btnPutOrderOnHold.FlatAppearance.BorderColor = Color.Black;
		btnPutOrderOnHold.FlatAppearance.BorderSize = 0;
		btnPutOrderOnHold.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPutOrderOnHold.ForeColor = Color.White;
		btnPutOrderOnHold.Name = "btnPutOrderOnHold";
		btnPutOrderOnHold.UseVisualStyleBackColor = false;
		btnPutOrderOnHold.Click += btnPutOrderOnHold_Click;
		componentResourceManager.ApplyResources(btnChangeView, "btnChangeView");
		btnChangeView.BackColor = Color.FromArgb(42, 102, 134);
		btnChangeView.FlatAppearance.BorderColor = Color.Black;
		btnChangeView.FlatAppearance.BorderSize = 0;
		btnChangeView.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChangeView.ForeColor = Color.White;
		btnChangeView.Name = "btnChangeView";
		btnChangeView.UseVisualStyleBackColor = false;
		btnChangeView.Click += btnChangeView_Click;
		componentResourceManager.ApplyResources(btnPrintClear, "btnPrintClear");
		btnPrintClear.BackColor = Color.FromArgb(214, 142, 81);
		btnPrintClear.FlatAppearance.BorderColor = Color.White;
		btnPrintClear.FlatAppearance.BorderSize = 0;
		btnPrintClear.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrintClear.ForeColor = Color.White;
		btnPrintClear.Name = "btnPrintClear";
		btnPrintClear.UseVisualStyleBackColor = false;
		btnPrintClear.Click += btnPrintClear_Click;
		componentResourceManager.ApplyResources(btnPrint, "btnPrint");
		btnPrint.BackColor = Color.SandyBrown;
		btnPrint.FlatAppearance.BorderColor = Color.White;
		btnPrint.FlatAppearance.BorderSize = 0;
		btnPrint.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrint.ForeColor = Color.White;
		btnPrint.Name = "btnPrint";
		btnPrint.UseVisualStyleBackColor = false;
		btnPrint.Click += btnPrint_Click;
		componentResourceManager.ApplyResources(lblCounter, "lblCounter");
		lblCounter.BackColor = Color.FromArgb(65, 168, 95);
		lblCounter.ForeColor = Color.White;
		lblCounter.Name = "lblCounter";
		lblCounter.Click += btnScreenRefresh_Click;
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
		componentResourceManager.ApplyResources(btnScreenRefresh, "btnScreenRefresh");
		btnScreenRefresh.BackColor = Color.FromArgb(65, 168, 95);
		btnScreenRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnScreenRefresh.FlatAppearance.BorderSize = 0;
		btnScreenRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnScreenRefresh.ForeColor = Color.White;
		btnScreenRefresh.Name = "btnScreenRefresh";
		btnScreenRefresh.UseVisualStyleBackColor = true;
		btnScreenRefresh.Click += btnScreenRefresh_Click;
		componentResourceManager.ApplyResources(btnEnterOrder, "btnEnterOrder");
		btnEnterOrder.BackColor = Color.FromArgb(255, 192, 128);
		btnEnterOrder.FlatAppearance.BorderColor = Color.Black;
		btnEnterOrder.FlatAppearance.BorderSize = 0;
		btnEnterOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnEnterOrder.ForeColor = Color.White;
		btnEnterOrder.Name = "btnEnterOrder";
		btnEnterOrder.UseVisualStyleBackColor = false;
		btnEnterOrder.Click += btnEnterOrder_Click;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.Black;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(btnOrderMade, "btnOrderMade");
		btnOrderMade.BackColor = Color.FromArgb(77, 174, 225);
		btnOrderMade.FlatAppearance.BorderColor = Color.Black;
		btnOrderMade.FlatAppearance.BorderSize = 0;
		btnOrderMade.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOrderMade.ForeColor = Color.White;
		btnOrderMade.Name = "btnOrderMade";
		btnOrderMade.UseVisualStyleBackColor = false;
		btnOrderMade.EnabledChanged += uIvVfnvwe1_EnabledChanged;
		btnOrderMade.Click += btnOrderMade_Click;
		componentResourceManager.ApplyResources(uIvVfnvwe1, "btnClearCancelled");
		uIvVfnvwe1.BackColor = Color.FromArgb(198, 129, 71);
		uIvVfnvwe1.FlatAppearance.BorderColor = Color.Black;
		uIvVfnvwe1.FlatAppearance.BorderSize = 0;
		uIvVfnvwe1.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		uIvVfnvwe1.ForeColor = Color.White;
		uIvVfnvwe1.Name = "btnClearCancelled";
		uIvVfnvwe1.UseVisualStyleBackColor = false;
		uIvVfnvwe1.EnabledChanged += uIvVfnvwe1_EnabledChanged;
		uIvVfnvwe1.Click += uIvVfnvwe1_Click;
		componentResourceManager.ApplyResources(cqvEnKpyg0, "pnlOrders");
		cqvEnKpyg0.Name = "pnlOrders";
		componentResourceManager.ApplyResources(btnChangeStation, "btnChangeStation");
		btnChangeStation.BackColor = Color.FromArgb(214, 142, 81);
		btnChangeStation.FlatAppearance.BorderColor = Color.Black;
		btnChangeStation.FlatAppearance.BorderSize = 0;
		btnChangeStation.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChangeStation.ForeColor = Color.White;
		btnChangeStation.Name = "btnChangeStation";
		btnChangeStation.UseVisualStyleBackColor = false;
		btnChangeStation.Click += btnChangeStation_Click;
		timer_1.Interval = 1000;
		timer_1.Tick += timer_1_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnChangeStation);
		base.Controls.Add(lblTitle);
		base.Controls.Add(pnlMain);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmStationTiles";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmStationTiles_Load;
		base.VisibleChanged += frmStationTiles_VisibleChanged;
		base.Controls.SetChildIndex(pnlMain, 0);
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(btnChangeStation, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlMain.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtSearchInfo).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_10(Station station_0)
	{
		return station_0.StationID == short_0;
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
}
