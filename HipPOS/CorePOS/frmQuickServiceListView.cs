using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmQuickServiceListView : frmMasterForm
{
	private bool bool_0;

	private List<OrderResult> list_2;

	private OrderMethods orderMethods_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0;

	private int int_1;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private CustomPager customPager_0;

	private string string_0;

	private List<OrderResult> list_3;

	private IContainer icontainer_1;

	private Label lblTitle;

	private FlowLayoutPanel flowLayoutPanel1;

	internal Button BtnCancel;

	internal Button btnOpenRegister;

	internal Button btnPrintChit;

	internal Button btnNewDeliveryOrder;

	internal Button btnNewTakeOutOrder;

	internal Button btnNewOrder;

	internal Button btnToGo;

	private CustomListViewTelerik radListOrders;

	private Label lblFulfillment;

	private Label lblCustomerInfo;

	private Label lblOrderType;

	private Label lblOrderNumber;

	internal Button btnChange;

	private Label label3;

	private RadTextBoxControl txtSearchInfo;

	internal Button btnShowKeyboard_SearchInfo;

	internal Button btnScreenRefresh;

	private Label lblCounter;

	private Timer timer_0;

	internal Button btnClearSearch;

	private Label lblReceivedTime;

	private Label lblTicketNumber;

	internal Button btnOTFilter_DineIn;

	internal Button btnOTFilter_ToGo;

	internal Button btnOTFilter_PickUp;

	internal Button btnOTFilter_Delivery;

	internal Button btnOTFilter_Catering;

	private Label label1;

	internal Button btnOTFilter_All;

	internal Button btnNewCatering;

	internal Button btnNotifyCustomer;

	private VerticalScrollControl verticalScrollControl1;

	internal Button btnConfirmOnlineOrders;

	internal Timer timer_1;

	private Timer timer_2;

	private Class19 ddlDateRangeFilter;

	public frmQuickServiceListView()
	{
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<OrderResult>();
		orderMethods_0 = new OrderMethods();
		bool_1 = true;
		bool_2 = true;
		int_1 = 30;
		bool_5 = SettingsHelper.GetSettingValueByKey("sms") == "Enabled";
		string_0 = "ALL";
		base._002Ector();
		InitializeComponent_1();
		btnConfirmOnlineOrders.Tag = btnConfirmOnlineOrders.BackColor;
		customPager_0 = new CustomPager();
		CustomPager customPager = customPager_0;
		customPager.PagerButton_Click = (EventHandler)Delegate.Combine(customPager.PagerButton_Click, new EventHandler(method_6));
		customPager_0.rowsPerPage = ((Control)(object)radListOrders).Height / 37;
		customPager_0.Height = 50;
		base.Controls.Add(customPager_0);
		base.Activated += frmQuickServiceListView_Activated;
		lblCounter.Text = int_1.ToString();
		int_0 = int_1;
		Dictionary<int, string> dataSource = MiscHelper.GenDateRangeFilters();
		ddlDateRangeFilter.DisplayMember = "Value";
		ddlDateRangeFilter.ValueMember = "Key";
		ddlDateRangeFilter.DataSource = new BindingSource(dataSource, null);
		ddlDateRangeFilter.SelectedIndex = 0;
	}

	public void LoadFormData(bool showOEOnClose = true)
	{
		List<string> list = MemoryLoadedObjects.DefaultOrderTypes.Split(',').ToList();
		if (!list.Contains(OrderTypes.Delivery))
		{
			btnNewDeliveryOrder.Visible = false;
		}
		if (!list.Contains(OrderTypes.PickUp))
		{
			btnNewTakeOutOrder.Visible = false;
		}
		if (!list.Contains(OrderTypes.ToGo))
		{
			btnToGo.Visible = false;
		}
		if (!list.Contains(OrderTypes.DineIn))
		{
			btnNewOrder.Visible = false;
		}
		if (!list.Contains(OrderTypes.Catering))
		{
			btnNewCatering.Visible = false;
		}
		bool_1 = showOEOnClose;
		lblCounter.Text = int_1.ToString();
		int_0 = int_1;
		timer_0.Enabled = true;
		verticalScrollControl1.ConnectedRadListView = radListOrders;
	}

	private void method_3()
	{
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[0].set_Width((float)(lblOrderType.Width + 1));
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[1].set_Width((float)(lblReceivedTime.Width + 1));
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[2].set_Width((float)(lblFulfillment.Width + 1));
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[3].set_Width((float)(lblOrderNumber.Width + 1));
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[4].set_Width((float)(lblTicketNumber.Width + 1));
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[5].set_Width((float)(lblCustomerInfo.Width - 50));
	}

	private void frmQuickServiceListView_Load(object sender, EventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((RadListView)radListOrders).add_ItemMouseClick(new ListViewItemEventHandler(fUwXewmPr4));
		method_3();
		customPager_0.Location = new Point(((Control)(object)radListOrders).Location.X, ((Control)(object)radListOrders).Bottom);
		customPager_0.Size = new Size(((Control)(object)radListOrders).Width, customPager_0.Height);
		((RadListView)radListOrders).get_Items().Clear();
		method_4();
		bool_2 = false;
	}

	private void frmQuickServiceListView_Activated(object sender, EventArgs e)
	{
		if (!bool_2 && !bool_7)
		{
			method_4(customPager_0.currentPage);
		}
		else
		{
			bool_7 = false;
		}
	}

	private void fUwXewmPr4(object sender, ListViewItemEventArgs e)
	{
		if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems()).Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.orderNumber = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_Item(3).ToString();
		string text = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_Item(5).ToString();
		int selectedIndex = ((RadListView)radListOrders).get_SelectedIndex();
		Order order = gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && o.Void == false).FirstOrDefault();
		if (order == null)
		{
			new NotificationLabel(this, "Order does not exist or is modified. Please refresh the page.", NotificationTypes.Success).Show();
			return;
		}
		if (bool_3)
		{
			OrderHelper orderHelper = new OrderHelper();
			btnPrintChit.Text = "REPRINT CHIT";
			new NotificationLabel(this, "Printing Chit", NotificationTypes.Success).Show();
			string employee = "";
			if (string.IsNullOrEmpty(order.Source))
			{
				if (order.UserCreated.HasValue)
				{
					Employee userByID = UserMethods.GetUserByID(order.UserCreated.Value);
					if (userByID != null)
					{
						employee = userByID.FirstName;
					}
				}
			}
			else
			{
				employee = order.Source;
			}
			foreach (Station all_station in MemoryLoadedObjects.all_stations)
			{
				orderHelper.PrintToStation(CS_0024_003C_003E8__locals0.orderNumber, order.OrderType, order.CustomerInfoName + " - " + order.Customer, all_station.StationID, employee, isOrderMade: false, reprint: true, printOnlyOne: true);
			}
			bool_3 = false;
			return;
		}
		if (bool_4)
		{
			if (new frmMessageBox("Do you want to notify \"" + order.CustomerInfoName + "-" + order.Customer + "\" customer?", "Notify Customer", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				MiscHelper.NotifyCustomer(this, order.OrderNumber, order.Customer, order.OrderType);
				btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
				bool_4 = false;
				OrderResult orderResult = list_2.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
				if (orderResult != null)
				{
					orderResult.IsModified = true;
				}
				method_10(CS_0024_003C_003E8__locals0.orderNumber);
			}
			return;
		}
		if (order.FlagID == 1)
		{
			if (timer_1.Enabled)
			{
				timer_1.Enabled = false;
				btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
			}
			new frmOnlineOrders(order.OrderNumber).ShowDialog();
			method_4();
			return;
		}
		if (text.Contains(Resources.PAID))
		{
			bool_7 = true;
			string text2 = order.OrderNumber.ToUpper();
			if ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON" && order != null && !string.IsNullOrEmpty(order.OrderTicketNumber)) || !string.IsNullOrEmpty(order.SubSource))
			{
				text2 = order.OrderTicketNumber;
			}
			if (new frmMessageBox("Do you want to clear this order (" + text2 + ")?", "Clear Order", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				((RadListView)radListOrders).get_Items().RemoveAt(selectedIndex);
				OrderHelper orderHelper2 = new OrderHelper();
				orderHelper2.ClearOrder(CS_0024_003C_003E8__locals0.orderNumber, order.OrderType);
				MiscHelper.NotifyCustomer(this, order.OrderNumber, order.Customer, order.OrderType, suppressAlreadySentNotification: true);
				orderHelper2.RecordBatchId(CS_0024_003C_003E8__locals0.orderNumber, order.OrderType);
			}
			return;
		}
		string text3 = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(5).ToString();
		if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON" && (order.OrderType == OrderTypes.DeliveryOnline || order.OrderType == OrderTypes.TakeOutOnline) && text3 == ((byte)1).ToString())
		{
			method_10(CS_0024_003C_003E8__locals0.orderNumber);
			OrderResult orderResult2 = list_2.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
			if (orderResult2 != null)
			{
				orderResult2.IsModified = true;
				return;
			}
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(CS_0024_003C_003E8__locals0.orderNumber, order.Customer, order.OrderType, 0, 0, order.CustomerInfoName, order.CustomerInfo, resetComboId: true, 1);
		if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "ON")
		{
			DialogResult dialogResult = MemoryLoadedObjects.OrderEntry.ShowDialog();
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Cancel)
			{
				method_10(CS_0024_003C_003E8__locals0.orderNumber);
				OrderResult orderResult3 = list_2.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
				if (orderResult3 != null)
				{
					orderResult3.IsModified = true;
				}
			}
			method_4();
		}
		else
		{
			MemoryLoadedObjects.OrderEntry.Show();
			MemoryLoadedObjects.QuickServiceListView.Hide();
		}
	}

	private void method_4(int int_2 = 0, bool bool_8 = false)
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			lblCounter.Text = int_1.ToString();
			int_0 = int_1;
			bool_0 = true;
			orderMethods_0 = new OrderMethods();
			bool_6 = orderMethods_0.OpenOrders(OrderTypes.AllOnline).Count() > 0;
			if (bool_6)
			{
				timer_1.Enabled = true;
			}
			else
			{
				btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
			}
			if (!bool_8 || (((IEnumerable<ListViewDataItem>)((RadListView)radListOrders).get_Items()).Count() < customPager_0.rowsPerPage && customPager_0.currentPage != customPager_0.lastPage))
			{
				list_3 = (from a in orderMethods_0.SearchOpenOrders(((Control)(object)txtSearchInfo).Text.Trim(), string_0, Convert.ToInt32(ddlDateRangeFilter.SelectedValue))
					orderby a.FulFillmentAt.HasValue, a.FulFillmentAt.HasValue ? a.FulFillmentAt.Value : a.DateCreated
					select a into x
					group x by x.OrderNumber into y
					select y.First()).ToList();
			}
			if (list_3 != null)
			{
				int num = ((list_3 != null) ? list_3.Count() : 0);
				int num2 = ((num % customPager_0.rowsPerPage != 0) ? 1 : 0);
				int num3 = num / customPager_0.rowsPerPage + num2;
				if (int_2 > num3 - 1)
				{
					int_2 = num3 - 1;
				}
				customPager_0.currentPage = int_2;
				customPager_0.lastPage = num3;
				List<OrderResult> list = list_3.Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage).ToList();
				customPager_0.AddPagerButtons();
				((RadListView)radListOrders).get_Items().Clear();
				foreach (OrderResult item in list)
				{
					string string_ = item.Customer + " " + item.CustomerInfo + " " + item.CustomerInfoName;
					if (item.OrderType == OrderTypes.PickUpOnline || item.OrderType == OrderTypes.DeliveryOnline)
					{
						string_ = item.Customer + " " + item.CustomerInfoPhone + " " + item.CustomerInfo + " " + item.CustomerInfoName;
					}
					method_5(item.OrderNumber, item.OrderTicket, item.OrderType, item.DateCreated, item.FulFillmentAt, string_, item.isPaid, item.FlagID, item.isCustomerNotified, item.OrderNotes);
				}
				list_2.Clear();
				foreach (OrderResult item2 in list)
				{
					list_2.Add(item2);
				}
				list.Clear();
				list = null;
			}
			bool_0 = false;
		}
		catch (Exception error)
		{
			bool_0 = false;
			new NotificationLabel(this, "Something went wrong loading the orders. Please REFERSH the page.", NotificationTypes.Warning).Show();
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void method_5(string string_1, string string_2, string string_3, DateTime dateTime_0, DateTime? nullable_0, string string_4, bool bool_8, byte byte_0, bool bool_9, string string_5)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		string obj = (bool_8 ? "**PAID** " : "") + (bool_9 ? "** NOTIFIED ** " : string.Empty);
		string text = "";
		text = ((!nullable_0.HasValue) ? "ASAP" : ((nullable_0.Value <= DateTime.Now) ? "ASAP" : ((!(nullable_0.Value.Date > DateTime.Now.Date)) ? nullable_0.Value.ToShortTimeString() : nullable_0.Value.ToString("MM/dd HH:mm"))));
		string text2 = "";
		if (!string.IsNullOrEmpty(string_5))
		{
			text2 = " NOTES: " + string_5;
		}
		string text3 = obj + string_4 + text2;
		string[] array = new string[7]
		{
			string_3,
			(dateTime_0.AddHours(24.0) < DateTime.Now) ? dateTime_0.ToShortDateString() : dateTime_0.ToShortTimeString(),
			text,
			string_1,
			string_2,
			text3,
			byte_0.ToString()
		};
		ListViewDataItem val = new ListViewDataItem("", array);
		if (bool_8)
		{
			val.set_BackColor(Color.LightGreen);
		}
		else
		{
			val.set_BackColor(Color.White);
		}
		((RadListView)radListOrders).get_Items().Add(val);
	}

	private void method_6(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (button.Text == "<<")
		{
			method_4(0, bool_8: true);
		}
		else if (button.Text == "<")
		{
			method_4(customPager_0.currentPage - 1, bool_8: true);
		}
		else if (button.Text == ">")
		{
			method_4(customPager_0.currentPage + 1, bool_8: true);
		}
		else if (button.Text == ">>")
		{
			method_4(customPager_0.lastPage - 1, bool_8: true);
		}
		else
		{
			method_4(Convert.ToInt32(button.Text) - 1, bool_8: true);
		}
	}

	private void method_7()
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("second_screen");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (AppSettings.ScreenCount >= 2 && settingValueByKey == "ON")
			{
				if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
				{
					MemoryLoadedObjects.OrderEntrySecondScreen.ResetValues();
					return;
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntrySecondScreen();
				Rectangle bounds = AppSettings.SecondaryScreen.Bounds;
				MemoryLoadedObjects.OrderEntrySecondScreen.WindowState = FormWindowState.Normal;
				MemoryLoadedObjects.OrderEntrySecondScreen.TopMost = true;
				MemoryLoadedObjects.OrderEntrySecondScreen.Size = new Size(bounds.Width, bounds.Height);
				MemoryLoadedObjects.OrderEntrySecondScreen.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
				MemoryLoadedObjects.OrderEntrySecondScreen.StartPosition = FormStartPosition.Manual;
				MemoryLoadedObjects.OrderEntrySecondScreen.Show();
			}
			else
			{
				MemoryLoadedObjects.OrderEntrySecondScreen = null;
			}
		}
		else
		{
			MemoryLoadedObjects.OrderEntrySecondScreen = null;
		}
	}

	private void btnToGo_Click(object sender, EventArgs e)
	{
		method_7();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(null, Resources.Walk_In, OrderTypes.ToGo, 1, 0, "", "", resetComboId: true, 1);
		MemoryLoadedObjects.OrderEntry.Show();
	}

	private void method_8(object sender, EventArgs e)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_print, Resources.Print_All_Bills, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
		{
			return;
		}
		foreach (ListViewDataItem item in ((RadListView)radListOrders).get_Items())
		{
			if (item.get_Item(2) != null)
			{
				string text = item.get_Item(2).ToString();
				try
				{
					PrintHelper.GenerateReceipt(text, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				}
				catch
				{
					new NotificationLabel(this, "Unable to print order number '" + text + "', please try again later.", NotificationTypes.Warning).Show();
				}
				continue;
			}
			break;
		}
	}

	private void btnNewOrder_Click(object sender, EventArgs e)
	{
		method_7();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(null, Resources.Walk_In, OrderTypes.DineIn, 1, 0, "", "", resetComboId: true, 1);
		MemoryLoadedObjects.OrderEntry.Show();
	}

	private void btnNewTakeOutOrder_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.PickUp, bool_0: false, this);
	}

	private void btnNewDeliveryOrder_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Delivery, bool_0: false, this);
	}

	private void btnPrintChit_Click(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			bool_3 = true;
			btnPrintChit.Text = "CANCEL REPRINT CHIT";
			new NotificationLabel(this, "Select an Order to print chit", NotificationTypes.Success).Show();
		}
		else
		{
			bool_3 = false;
			btnPrintChit.Text = "REPRINT CHIT";
			new NotificationLabel(this, "Chit printing cancelled", NotificationTypes.Success, 4);
		}
	}

	private void btnOpenRegister_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, "btnOpenRegister") != null)
		{
			GClass8.OpenCashDrawer();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && bool_1)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
			MemoryLoadedObjects.OrderEntry.Show();
			Hide();
			return;
		}
		timer_0.Enabled = false;
		Hide();
		if (!MemoryLoadedObjects.OrderEntry.Visible)
		{
			AuthMethods.LogOutUser();
		}
		else
		{
			MemoryLoadedObjects.OrderEntry.ReinitializeOrderEntryByOrderType(OrderTypes.ToGo);
		}
	}

	private void btnChange_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Setting setting = gClass.Settings.Where((Setting s) => s.Key == "quick_service_view").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = "tile";
			Helper.SubmitChangesWithCatch(gClass);
			SettingsHelper.SetSettingValueByKey("quick_service_view", setting.Value);
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
			MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL", bool_1);
			MemoryLoadedObjects.QuickService.Show();
			timer_0.Enabled = false;
			Hide();
		}
	}

	private void txtSearchInfo_TextChanged(object sender, EventArgs e)
	{
		method_4();
	}

	private void btnShowKeyboard_SearchInfo_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Search Orders", 0, 49, ((Control)(object)txtSearchInfo).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSearchInfo).Text = MemoryLoadedObjects.Keyboard.textEntered;
			base.DialogResult = DialogResult.None;
		}
	}

	private void lblCounter_Click(object sender, EventArgs e)
	{
		OrderHelper.OnlineOrderRefresh();
		method_4(customPager_0.currentPage);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int_0--;
		lblCounter.Text = int_0.ToString();
		if (int_0 <= 0)
		{
			method_4(customPager_0.currentPage);
		}
	}

	private void btnClearSearch_Click(object sender, EventArgs e)
	{
		((Control)(object)txtSearchInfo).Text = "";
		method_4();
	}

	private void btnOTFilter_DineIn_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void btnOTFilter_All_Click(object sender, EventArgs e)
	{
		method_9((Button)sender);
	}

	private void method_9(Button button_0)
	{
		string_0 = button_0.Text;
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
		button_0.BackColor = Color.FromArgb(214, 142, 81);
		method_4();
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

	private void btnNewCatering_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Catering, bool_0: false, this);
	}

	private void radListOrders_SelectedItemChanged(object sender, EventArgs e)
	{
	}

	private void btnNotifyCustomer_Click(object sender, EventArgs e)
	{
		if (bool_5)
		{
			if (!bool_4)
			{
				bool_4 = true;
				btnNotifyCustomer.Text = "CANCEL NOTIFY";
				timer_2.Enabled = true;
				timer_2.Start();
				new NotificationLabel(this, "Select an Order", NotificationTypes.Success, 10);
			}
			else
			{
				bool_4 = false;
				btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
				timer_2.Enabled = false;
				timer_2.Stop();
				new NotificationLabel(this, "Customer Notification Cancelled", NotificationTypes.Success, 3);
			}
		}
		else
		{
			new NotificationLabel(this, "SMS Add-On Subscription Is Not Enabled, Please Contact Hippos To Enable.", NotificationTypes.Notification).Show();
		}
	}

	private void btnConfirmOnlineOrders_Click(object sender, EventArgs e)
	{
		if (timer_1.Enabled)
		{
			timer_1.Enabled = false;
			btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
		}
		new frmOnlineOrders().ShowDialog();
		method_4();
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (btnConfirmOnlineOrders.BackColor != Color.Red)
		{
			btnConfirmOnlineOrders.BackColor = Color.Red;
		}
		else
		{
			btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		bool_4 = false;
		btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
		timer_2.Enabled = false;
		timer_2.Stop();
	}

	private void ddlDateRangeFilter_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_10(string string_1)
	{
		_003C_003Ec__DisplayClass53_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass53_0();
		CS_0024_003C_003E8__locals0.orderNumber = string_1;
		if (MemoryLoadedObjects.QuickService != null)
		{
			OrderResult orderResult = MemoryLoadedObjects.QuickService.multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).FirstOrDefault();
			if (orderResult != null)
			{
				orderResult.IsModified = true;
			}
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
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_19b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19da: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmQuickServiceListView));
		ListViewDetailColumn val = new ListViewDetailColumn("Column 0", "Column 0");
		ListViewDetailColumn val2 = new ListViewDetailColumn("Column 1", "Column 1");
		ListViewDetailColumn val3 = new ListViewDetailColumn("Column 2", "Column 2");
		ListViewDetailColumn val4 = new ListViewDetailColumn("Column 3", "Column 3");
		ListViewDetailColumn val5 = new ListViewDetailColumn("Column 4", "Column 4");
		ListViewDetailColumn val6 = new ListViewDetailColumn("Column 5", "Column 5");
		ListViewDataItem val7 = new ListViewDataItem("ListViewItem 1");
		lblFulfillment = new Label();
		lblCustomerInfo = new Label();
		lblOrderType = new Label();
		lblOrderNumber = new Label();
		flowLayoutPanel1 = new FlowLayoutPanel();
		BtnCancel = new Button();
		btnOpenRegister = new Button();
		btnNotifyCustomer = new Button();
		btnPrintChit = new Button();
		btnNewDeliveryOrder = new Button();
		btnNewTakeOutOrder = new Button();
		btnNewOrder = new Button();
		btnToGo = new Button();
		btnNewCatering = new Button();
		btnConfirmOnlineOrders = new Button();
		lblTitle = new Label();
		radListOrders = new CustomListViewTelerik();
		btnChange = new Button();
		label3 = new Label();
		txtSearchInfo = new RadTextBoxControl();
		btnShowKeyboard_SearchInfo = new Button();
		btnScreenRefresh = new Button();
		lblCounter = new Label();
		timer_0 = new Timer(icontainer_1);
		btnClearSearch = new Button();
		lblReceivedTime = new Label();
		lblTicketNumber = new Label();
		btnOTFilter_DineIn = new Button();
		btnOTFilter_ToGo = new Button();
		btnOTFilter_PickUp = new Button();
		btnOTFilter_Delivery = new Button();
		btnOTFilter_Catering = new Button();
		label1 = new Label();
		btnOTFilter_All = new Button();
		verticalScrollControl1 = new VerticalScrollControl();
		timer_1 = new Timer(icontainer_1);
		timer_2 = new Timer(icontainer_1);
		ddlDateRangeFilter = new Class19();
		flowLayoutPanel1.SuspendLayout();
		((ISupportInitialize)radListOrders).BeginInit();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		SuspendLayout();
		lblFulfillment.BackColor = Color.FromArgb(61, 142, 185);
		lblFulfillment.Font = new Font("Microsoft Sans Serif", 10f);
		lblFulfillment.ForeColor = Color.White;
		lblFulfillment.ImeMode = ImeMode.NoControl;
		lblFulfillment.Location = new Point(278, 73);
		lblFulfillment.Margin = new Padding(0, 0, 0, 1);
		lblFulfillment.MinimumSize = new Size(0, 35);
		lblFulfillment.Name = "lblFulfillment";
		lblFulfillment.Size = new Size(140, 35);
		lblFulfillment.TabIndex = 142;
		lblFulfillment.Text = "Fulfillment";
		lblFulfillment.TextAlign = ContentAlignment.MiddleCenter;
		lblCustomerInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblCustomerInfo.BackColor = Color.FromArgb(61, 142, 185);
		lblCustomerInfo.Font = new Font("Microsoft Sans Serif", 10f);
		lblCustomerInfo.ForeColor = Color.White;
		lblCustomerInfo.ImeMode = ImeMode.NoControl;
		lblCustomerInfo.Location = new Point(612, 73);
		lblCustomerInfo.Margin = new Padding(0, 0, 0, 1);
		lblCustomerInfo.MinimumSize = new Size(0, 35);
		lblCustomerInfo.Name = "lblCustomerInfo";
		lblCustomerInfo.Padding = new Padding(10, 0, 0, 0);
		lblCustomerInfo.Size = new Size(413, 35);
		lblCustomerInfo.TabIndex = 141;
		lblCustomerInfo.Text = "Customer Info";
		lblCustomerInfo.TextAlign = ContentAlignment.MiddleLeft;
		lblOrderType.BackColor = Color.FromArgb(61, 142, 185);
		lblOrderType.Font = new Font("Microsoft Sans Serif", 10f);
		lblOrderType.ForeColor = Color.White;
		lblOrderType.ImeMode = ImeMode.NoControl;
		lblOrderType.Location = new Point(0, 73);
		lblOrderType.Margin = new Padding(0, 0, 0, 1);
		lblOrderType.MinimumSize = new Size(0, 35);
		lblOrderType.Name = "lblOrderType";
		lblOrderType.Size = new Size(150, 35);
		lblOrderType.TabIndex = 140;
		lblOrderType.Text = "Order Type";
		lblOrderType.TextAlign = ContentAlignment.MiddleCenter;
		lblOrderNumber.BackColor = Color.FromArgb(61, 142, 185);
		lblOrderNumber.Font = new Font("Microsoft Sans Serif", 10f);
		lblOrderNumber.ForeColor = Color.White;
		lblOrderNumber.ImeMode = ImeMode.NoControl;
		lblOrderNumber.Location = new Point(419, 73);
		lblOrderNumber.Margin = new Padding(0, 0, 0, 1);
		lblOrderNumber.MinimumSize = new Size(0, 35);
		lblOrderNumber.Name = "lblOrderNumber";
		lblOrderNumber.Size = new Size(124, 35);
		lblOrderNumber.TabIndex = 139;
		lblOrderNumber.Text = "Order #";
		lblOrderNumber.TextAlign = ContentAlignment.MiddleCenter;
		flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		flowLayoutPanel1.Controls.Add(BtnCancel);
		flowLayoutPanel1.Controls.Add(btnOpenRegister);
		flowLayoutPanel1.Controls.Add(btnNotifyCustomer);
		flowLayoutPanel1.Controls.Add(btnPrintChit);
		flowLayoutPanel1.Controls.Add(btnNewDeliveryOrder);
		flowLayoutPanel1.Controls.Add(btnNewTakeOutOrder);
		flowLayoutPanel1.Controls.Add(btnNewOrder);
		flowLayoutPanel1.Controls.Add(btnToGo);
		flowLayoutPanel1.Controls.Add(btnNewCatering);
		flowLayoutPanel1.Controls.Add(btnConfirmOnlineOrders);
		flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
		flowLayoutPanel1.Location = new Point(4, 694);
		flowLayoutPanel1.Margin = new Padding(0);
		flowLayoutPanel1.Name = "flowLayoutPanel1";
		flowLayoutPanel1.Size = new Size(1020, 74);
		flowLayoutPanel1.TabIndex = 109;
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.White;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.FlatStyle = FlatStyle.Flat;
		BtnCancel.Font = new Font("Microsoft Sans Serif", 8.25f);
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Image = (Image)componentResourceManager.GetObject("BtnCancel.Image");
		BtnCancel.ImeMode = ImeMode.NoControl;
		BtnCancel.Location = new Point(910, 0);
		BtnCancel.Margin = new Padding(1, 0, 0, 0);
		BtnCancel.Name = "BtnCancel";
		BtnCancel.Padding = new Padding(10, 5, 0, 5);
		BtnCancel.Size = new Size(110, 72);
		BtnCancel.TabIndex = 20;
		BtnCancel.Text = "CLOSE";
		BtnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		btnOpenRegister.BackColor = Color.FromArgb(50, 119, 155);
		btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnOpenRegister.FlatAppearance.BorderSize = 0;
		btnOpenRegister.FlatStyle = FlatStyle.Flat;
		btnOpenRegister.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnOpenRegister.ForeColor = Color.White;
		btnOpenRegister.Image = (Image)componentResourceManager.GetObject("btnOpenRegister.Image");
		btnOpenRegister.ImeMode = ImeMode.NoControl;
		btnOpenRegister.Location = new Point(799, 0);
		btnOpenRegister.Margin = new Padding(1, 0, 0, 0);
		btnOpenRegister.Name = "btnOpenRegister";
		btnOpenRegister.Padding = new Padding(5, 0, 0, 0);
		btnOpenRegister.Size = new Size(110, 72);
		btnOpenRegister.TabIndex = 86;
		btnOpenRegister.Text = "OPEN TIL";
		btnOpenRegister.TextAlign = ContentAlignment.MiddleLeft;
		btnOpenRegister.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnOpenRegister.UseVisualStyleBackColor = false;
		btnOpenRegister.Click += btnOpenRegister_Click;
		btnNotifyCustomer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnNotifyCustomer.BackColor = Color.FromArgb(53, 152, 220);
		btnNotifyCustomer.FlatAppearance.BorderColor = Color.White;
		btnNotifyCustomer.FlatAppearance.BorderSize = 0;
		btnNotifyCustomer.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNotifyCustomer.FlatStyle = FlatStyle.Flat;
		btnNotifyCustomer.Font = new Font("Microsoft Sans Serif", 9f);
		btnNotifyCustomer.ForeColor = Color.White;
		btnNotifyCustomer.ImageAlign = ContentAlignment.MiddleLeft;
		btnNotifyCustomer.ImeMode = ImeMode.NoControl;
		btnNotifyCustomer.Location = new Point(698, 0);
		btnNotifyCustomer.Margin = new Padding(1, 0, 0, 0);
		btnNotifyCustomer.Name = "btnNotifyCustomer";
		btnNotifyCustomer.Size = new Size(100, 72);
		btnNotifyCustomer.TabIndex = 145;
		btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
		btnNotifyCustomer.TextImageRelation = TextImageRelation.ImageAboveText;
		btnNotifyCustomer.UseVisualStyleBackColor = false;
		btnNotifyCustomer.Click += btnNotifyCustomer_Click;
		btnPrintChit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnPrintChit.BackColor = Color.SandyBrown;
		btnPrintChit.FlatAppearance.BorderColor = Color.White;
		btnPrintChit.FlatAppearance.BorderSize = 0;
		btnPrintChit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrintChit.FlatStyle = FlatStyle.Flat;
		btnPrintChit.Font = new Font("Microsoft Sans Serif", 7.5f);
		btnPrintChit.ForeColor = Color.White;
		btnPrintChit.Image = (Image)componentResourceManager.GetObject("btnPrintChit.Image");
		btnPrintChit.ImageAlign = ContentAlignment.MiddleLeft;
		btnPrintChit.ImeMode = ImeMode.NoControl;
		btnPrintChit.Location = new Point(587, 0);
		btnPrintChit.Margin = new Padding(1, 0, 0, 0);
		btnPrintChit.Name = "btnPrintChit";
		btnPrintChit.Size = new Size(110, 72);
		btnPrintChit.TabIndex = 141;
		btnPrintChit.Text = "REPRINT CHIT";
		btnPrintChit.TextAlign = ContentAlignment.MiddleLeft;
		btnPrintChit.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnPrintChit.UseVisualStyleBackColor = false;
		btnPrintChit.Click += btnPrintChit_Click;
		btnNewDeliveryOrder.BackColor = Color.FromArgb(80, 203, 116);
		btnNewDeliveryOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewDeliveryOrder.FlatAppearance.BorderSize = 0;
		btnNewDeliveryOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNewDeliveryOrder.FlatStyle = FlatStyle.Flat;
		btnNewDeliveryOrder.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnNewDeliveryOrder.ForeColor = Color.White;
		btnNewDeliveryOrder.ImeMode = ImeMode.NoControl;
		btnNewDeliveryOrder.Location = new Point(493, 0);
		btnNewDeliveryOrder.Margin = new Padding(1, 0, 0, 0);
		btnNewDeliveryOrder.Name = "btnNewDeliveryOrder";
		btnNewDeliveryOrder.Padding = new Padding(10, 0, 10, 0);
		btnNewDeliveryOrder.Size = new Size(93, 72);
		btnNewDeliveryOrder.TabIndex = 32;
		btnNewDeliveryOrder.Text = "NEW DELIVERY ORDER";
		btnNewDeliveryOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnNewDeliveryOrder.UseVisualStyleBackColor = false;
		btnNewDeliveryOrder.Click += btnNewDeliveryOrder_Click;
		btnNewTakeOutOrder.BackColor = Color.FromArgb(176, 124, 219);
		btnNewTakeOutOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewTakeOutOrder.FlatAppearance.BorderSize = 0;
		btnNewTakeOutOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNewTakeOutOrder.FlatStyle = FlatStyle.Flat;
		btnNewTakeOutOrder.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnNewTakeOutOrder.ForeColor = Color.White;
		btnNewTakeOutOrder.ImeMode = ImeMode.NoControl;
		btnNewTakeOutOrder.Location = new Point(399, 0);
		btnNewTakeOutOrder.Margin = new Padding(1, 0, 0, 0);
		btnNewTakeOutOrder.Name = "btnNewTakeOutOrder";
		btnNewTakeOutOrder.Padding = new Padding(10, 0, 10, 0);
		btnNewTakeOutOrder.Size = new Size(93, 72);
		btnNewTakeOutOrder.TabIndex = 31;
		btnNewTakeOutOrder.Text = "NEW PICK-UP ORDER";
		btnNewTakeOutOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnNewTakeOutOrder.UseVisualStyleBackColor = false;
		btnNewTakeOutOrder.Click += btnNewTakeOutOrder_Click;
		btnNewOrder.BackColor = Color.FromArgb(1, 110, 211);
		btnNewOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewOrder.FlatAppearance.BorderSize = 0;
		btnNewOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNewOrder.FlatStyle = FlatStyle.Flat;
		btnNewOrder.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnNewOrder.ForeColor = Color.White;
		btnNewOrder.ImeMode = ImeMode.NoControl;
		btnNewOrder.Location = new Point(305, 0);
		btnNewOrder.Margin = new Padding(1, 0, 0, 0);
		btnNewOrder.Name = "btnNewOrder";
		btnNewOrder.Padding = new Padding(10, 0, 10, 0);
		btnNewOrder.Size = new Size(93, 72);
		btnNewOrder.TabIndex = 33;
		btnNewOrder.Text = "NEW DINE-IN ORDER";
		btnNewOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnNewOrder.UseVisualStyleBackColor = false;
		btnNewOrder.Click += btnNewOrder_Click;
		btnToGo.BackColor = Color.FromArgb(61, 142, 185);
		btnToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnToGo.FlatAppearance.BorderSize = 0;
		btnToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnToGo.FlatStyle = FlatStyle.Flat;
		btnToGo.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnToGo.ForeColor = Color.White;
		btnToGo.ImeMode = ImeMode.NoControl;
		btnToGo.Location = new Point(211, 0);
		btnToGo.Margin = new Padding(1, 0, 0, 0);
		btnToGo.Name = "btnToGo";
		btnToGo.Padding = new Padding(10, 0, 10, 0);
		btnToGo.Size = new Size(93, 72);
		btnToGo.TabIndex = 87;
		btnToGo.Text = "NEW TO-GO ORDER";
		btnToGo.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnToGo.UseVisualStyleBackColor = false;
		btnToGo.Click += btnToGo_Click;
		btnNewCatering.BackColor = Color.FromArgb(53, 143, 79);
		btnNewCatering.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewCatering.FlatAppearance.BorderSize = 0;
		btnNewCatering.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNewCatering.FlatStyle = FlatStyle.Flat;
		btnNewCatering.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnNewCatering.ForeColor = Color.White;
		btnNewCatering.ImeMode = ImeMode.NoControl;
		btnNewCatering.Location = new Point(117, 0);
		btnNewCatering.Margin = new Padding(1, 0, 0, 0);
		btnNewCatering.Name = "btnNewCatering";
		btnNewCatering.Padding = new Padding(10, 0, 10, 0);
		btnNewCatering.Size = new Size(93, 72);
		btnNewCatering.TabIndex = 142;
		btnNewCatering.Text = "NEW CATERING ORDER";
		btnNewCatering.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnNewCatering.UseVisualStyleBackColor = false;
		btnNewCatering.Click += btnNewCatering_Click;
		btnConfirmOnlineOrders.Anchor = AnchorStyles.Top;
		btnConfirmOnlineOrders.BackColor = Color.FromArgb(255, 192, 128);
		btnConfirmOnlineOrders.FlatAppearance.BorderColor = Color.White;
		btnConfirmOnlineOrders.FlatAppearance.BorderSize = 0;
		btnConfirmOnlineOrders.FlatAppearance.MouseDownBackColor = Color.White;
		btnConfirmOnlineOrders.FlatStyle = FlatStyle.Flat;
		btnConfirmOnlineOrders.Font = new Font("Microsoft Sans Serif", 9f);
		btnConfirmOnlineOrders.ForeColor = Color.Black;
		btnConfirmOnlineOrders.ImeMode = ImeMode.NoControl;
		btnConfirmOnlineOrders.Location = new Point(5, 0);
		btnConfirmOnlineOrders.Margin = new Padding(0);
		btnConfirmOnlineOrders.Name = "btnConfirmOnlineOrders";
		btnConfirmOnlineOrders.Size = new Size(111, 72);
		btnConfirmOnlineOrders.TabIndex = 146;
		btnConfirmOnlineOrders.Text = "ONLINE ORDERS";
		btnConfirmOnlineOrders.UseVisualStyleBackColor = false;
		btnConfirmOnlineOrders.Click += btnConfirmOnlineOrders_Click;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.FlatStyle = FlatStyle.Flat;
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-1, 1);
		lblTitle.MinimumSize = new Size(720, 35);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(1026, 35);
		lblTitle.TabIndex = 108;
		lblTitle.Text = "ORDERS";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		((RadListView)radListOrders).set_AllowArbitraryItemHeight(true);
		((RadListView)radListOrders).set_AllowEdit(false);
		((RadListView)radListOrders).set_AllowRemove(false);
		((Control)(object)radListOrders).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		val.set_HeaderText("Column 0");
		val2.set_HeaderText("Column 1");
		val3.set_HeaderText("Column 2");
		val4.set_HeaderText("Column 3");
		val5.set_HeaderText("Column 4");
		val6.set_HeaderText("Column 5");
		((RadListView)radListOrders).get_Columns().AddRange((ListViewDetailColumn[])(object)new ListViewDetailColumn[6] { val, val2, val3, val4, val5, val6 });
		((RadListView)radListOrders).set_EnableKineticScrolling(true);
		((Control)(object)radListOrders).Font = new Font("Microsoft Sans Serif", 13.5f, FontStyle.Bold);
		val7.set_Text("ListViewItem 1");
		((RadListView)radListOrders).get_Items().AddRange((ListViewDataItem[])(object)new ListViewDataItem[1] { val7 });
		((RadListView)radListOrders).set_ItemSpacing(-1);
		((Control)(object)radListOrders).Location = new Point(1, 109);
		((Control)(object)radListOrders).Name = "radListOrders";
		((RadListView)radListOrders).set_ShowColumnHeaders(false);
		((RadListView)radListOrders).set_ShowGridLines(true);
		((Control)(object)radListOrders).Size = new Size(989, 535);
		((Control)(object)radListOrders).TabIndex = 138;
		((Control)(object)radListOrders).Text = "radListView1";
		((RadListView)radListOrders).set_ViewType((ListViewType)2);
		((RadListView)radListOrders).add_SelectedItemChanged((EventHandler)radListOrders_SelectedItemChanged);
		btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnChange.BackColor = Color.FromArgb(214, 142, 81);
		btnChange.FlatAppearance.BorderColor = Color.Black;
		btnChange.FlatAppearance.BorderSize = 0;
		btnChange.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChange.FlatStyle = FlatStyle.Flat;
		btnChange.Font = new Font("Microsoft Sans Serif", 9.75f);
		btnChange.ForeColor = Color.White;
		btnChange.ImeMode = ImeMode.NoControl;
		btnChange.Location = new Point(814, 1);
		btnChange.Name = "btnChange";
		btnChange.Size = new Size(79, 71);
		btnChange.TabIndex = 147;
		btnChange.Text = "TILE VIEW";
		btnChange.UseVisualStyleBackColor = false;
		btnChange.Click += btnChange_Click;
		label3.BackColor = Color.Gray;
		label3.Font = new Font("Microsoft Sans Serif", 10f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(1, 37);
		label3.Name = "label3";
		label3.Size = new Size(65, 35);
		label3.TabIndex = 222;
		label3.Text = "Search:";
		label3.TextAlign = ContentAlignment.MiddleCenter;
		((Control)(object)txtSearchInfo).Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		((Control)(object)txtSearchInfo).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtSearchInfo).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtSearchInfo).Location = new Point(67, 37);
		((Control)(object)txtSearchInfo).Name = "txtSearchInfo";
		((RadElement)((RadControl)txtSearchInfo).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSearchInfo).Size = new Size(147, 35);
		((Control)(object)txtSearchInfo).TabIndex = 220;
		((Control)(object)txtSearchInfo).TextChanged += txtSearchInfo_TextChanged;
		((Control)(object)txtSearchInfo).Click += btnShowKeyboard_SearchInfo_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSearchInfo).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSearchInfo).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_SearchInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnShowKeyboard_SearchInfo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchInfo.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_SearchInfo.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_SearchInfo.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_SearchInfo.ForeColor = Color.White;
		btnShowKeyboard_SearchInfo.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_SearchInfo.Image");
		btnShowKeyboard_SearchInfo.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_SearchInfo.Location = new Point(215, 37);
		btnShowKeyboard_SearchInfo.Name = "btnShowKeyboard_SearchInfo";
		btnShowKeyboard_SearchInfo.Size = new Size(40, 35);
		btnShowKeyboard_SearchInfo.TabIndex = 221;
		btnShowKeyboard_SearchInfo.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchInfo.Click += btnShowKeyboard_SearchInfo_Click;
		btnScreenRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnScreenRefresh.BackColor = Color.FromArgb(65, 168, 95);
		btnScreenRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnScreenRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnScreenRefresh.FlatStyle = FlatStyle.Flat;
		btnScreenRefresh.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnScreenRefresh.ForeColor = Color.White;
		btnScreenRefresh.ImeMode = ImeMode.NoControl;
		btnScreenRefresh.Location = new Point(893, 1);
		btnScreenRefresh.Name = "btnScreenRefresh";
		btnScreenRefresh.Padding = new Padding(55, 4, 8, 0);
		btnScreenRefresh.Size = new Size(131, 72);
		btnScreenRefresh.TabIndex = 223;
		btnScreenRefresh.Text = "REFRESH NOW";
		btnScreenRefresh.TextAlign = ContentAlignment.MiddleLeft;
		btnScreenRefresh.UseVisualStyleBackColor = true;
		btnScreenRefresh.Click += lblCounter_Click;
		lblCounter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		lblCounter.BackColor = Color.FromArgb(65, 168, 95);
		lblCounter.Font = new Font("Microsoft Sans Serif", 26f, FontStyle.Bold);
		lblCounter.ForeColor = Color.White;
		lblCounter.ImeMode = ImeMode.NoControl;
		lblCounter.Location = new Point(898, 15);
		lblCounter.Margin = new Padding(2, 0, 2, 0);
		lblCounter.Name = "lblCounter";
		lblCounter.Size = new Size(57, 43);
		lblCounter.TabIndex = 224;
		lblCounter.Text = "20";
		lblCounter.TextAlign = ContentAlignment.MiddleCenter;
		lblCounter.Click += lblCounter_Click;
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		btnClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClearSearch.BackColor = Color.FromArgb(1, 110, 211);
		btnClearSearch.DialogResult = DialogResult.OK;
		btnClearSearch.FlatAppearance.BorderColor = Color.Black;
		btnClearSearch.FlatAppearance.BorderSize = 0;
		btnClearSearch.FlatStyle = FlatStyle.Flat;
		btnClearSearch.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnClearSearch.ForeColor = Color.White;
		btnClearSearch.ImeMode = ImeMode.NoControl;
		btnClearSearch.Location = new Point(256, 36);
		btnClearSearch.Name = "btnClearSearch";
		btnClearSearch.Size = new Size(60, 37);
		btnClearSearch.TabIndex = 225;
		btnClearSearch.Text = "CLEAR SEARCH";
		btnClearSearch.UseVisualStyleBackColor = false;
		btnClearSearch.Click += btnClearSearch_Click;
		lblReceivedTime.BackColor = Color.FromArgb(61, 142, 185);
		lblReceivedTime.Font = new Font("Microsoft Sans Serif", 10f);
		lblReceivedTime.ForeColor = Color.White;
		lblReceivedTime.ImeMode = ImeMode.NoControl;
		lblReceivedTime.Location = new Point(151, 73);
		lblReceivedTime.Margin = new Padding(0, 0, 0, 1);
		lblReceivedTime.MinimumSize = new Size(0, 35);
		lblReceivedTime.Name = "lblReceivedTime";
		lblReceivedTime.Size = new Size(126, 35);
		lblReceivedTime.TabIndex = 226;
		lblReceivedTime.Text = "Received Time";
		lblReceivedTime.TextAlign = ContentAlignment.MiddleCenter;
		lblTicketNumber.BackColor = Color.FromArgb(61, 142, 185);
		lblTicketNumber.Font = new Font("Microsoft Sans Serif", 10f);
		lblTicketNumber.ForeColor = Color.White;
		lblTicketNumber.ImeMode = ImeMode.NoControl;
		lblTicketNumber.Location = new Point(544, 73);
		lblTicketNumber.Margin = new Padding(0, 0, 0, 1);
		lblTicketNumber.MinimumSize = new Size(0, 35);
		lblTicketNumber.Name = "lblTicketNumber";
		lblTicketNumber.Size = new Size(67, 35);
		lblTicketNumber.TabIndex = 227;
		lblTicketNumber.Text = "Ticket #";
		lblTicketNumber.TextAlign = ContentAlignment.MiddleCenter;
		btnOTFilter_DineIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_DineIn.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_DineIn.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_DineIn.FlatAppearance.BorderSize = 0;
		btnOTFilter_DineIn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_DineIn.FlatStyle = FlatStyle.Flat;
		btnOTFilter_DineIn.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_DineIn.ForeColor = Color.White;
		btnOTFilter_DineIn.ImeMode = ImeMode.NoControl;
		btnOTFilter_DineIn.Location = new Point(444, 37);
		btnOTFilter_DineIn.Margin = new Padding(0);
		btnOTFilter_DineIn.Name = "btnOTFilter_DineIn";
		btnOTFilter_DineIn.Size = new Size(73, 35);
		btnOTFilter_DineIn.TabIndex = 228;
		btnOTFilter_DineIn.Text = "DINE IN";
		btnOTFilter_DineIn.UseVisualStyleBackColor = false;
		btnOTFilter_DineIn.Click += btnOTFilter_DineIn_Click;
		btnOTFilter_ToGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_ToGo.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_ToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_ToGo.FlatAppearance.BorderSize = 0;
		btnOTFilter_ToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_ToGo.FlatStyle = FlatStyle.Flat;
		btnOTFilter_ToGo.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_ToGo.ForeColor = Color.White;
		btnOTFilter_ToGo.ImeMode = ImeMode.NoControl;
		btnOTFilter_ToGo.Location = new Point(518, 37);
		btnOTFilter_ToGo.Margin = new Padding(0);
		btnOTFilter_ToGo.Name = "btnOTFilter_ToGo";
		btnOTFilter_ToGo.Size = new Size(73, 35);
		btnOTFilter_ToGo.TabIndex = 229;
		btnOTFilter_ToGo.Text = "TO-GO";
		btnOTFilter_ToGo.UseVisualStyleBackColor = false;
		btnOTFilter_ToGo.Click += btnOTFilter_ToGo_Click;
		btnOTFilter_PickUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_PickUp.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_PickUp.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_PickUp.FlatAppearance.BorderSize = 0;
		btnOTFilter_PickUp.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_PickUp.FlatStyle = FlatStyle.Flat;
		btnOTFilter_PickUp.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_PickUp.ForeColor = Color.White;
		btnOTFilter_PickUp.ImeMode = ImeMode.NoControl;
		btnOTFilter_PickUp.Location = new Point(592, 37);
		btnOTFilter_PickUp.Margin = new Padding(0);
		btnOTFilter_PickUp.Name = "btnOTFilter_PickUp";
		btnOTFilter_PickUp.Size = new Size(73, 35);
		btnOTFilter_PickUp.TabIndex = 230;
		btnOTFilter_PickUp.Text = "PICK-UP";
		btnOTFilter_PickUp.UseVisualStyleBackColor = false;
		btnOTFilter_PickUp.Click += btnOTFilter_PickUp_Click;
		btnOTFilter_Delivery.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_Delivery.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_Delivery.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_Delivery.FlatAppearance.BorderSize = 0;
		btnOTFilter_Delivery.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_Delivery.FlatStyle = FlatStyle.Flat;
		btnOTFilter_Delivery.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_Delivery.ForeColor = Color.White;
		btnOTFilter_Delivery.ImeMode = ImeMode.NoControl;
		btnOTFilter_Delivery.Location = new Point(666, 37);
		btnOTFilter_Delivery.Margin = new Padding(0);
		btnOTFilter_Delivery.Name = "btnOTFilter_Delivery";
		btnOTFilter_Delivery.Size = new Size(73, 35);
		btnOTFilter_Delivery.TabIndex = 231;
		btnOTFilter_Delivery.Text = "DELIVERY";
		btnOTFilter_Delivery.UseVisualStyleBackColor = false;
		btnOTFilter_Delivery.Click += btnOTFilter_Delivery_Click;
		btnOTFilter_Catering.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_Catering.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_Catering.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_Catering.FlatAppearance.BorderSize = 0;
		btnOTFilter_Catering.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_Catering.FlatStyle = FlatStyle.Flat;
		btnOTFilter_Catering.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_Catering.ForeColor = Color.White;
		btnOTFilter_Catering.ImeMode = ImeMode.NoControl;
		btnOTFilter_Catering.Location = new Point(740, 37);
		btnOTFilter_Catering.Margin = new Padding(0);
		btnOTFilter_Catering.Name = "btnOTFilter_Catering";
		btnOTFilter_Catering.Size = new Size(73, 35);
		btnOTFilter_Catering.TabIndex = 232;
		btnOTFilter_Catering.Text = "CATERING";
		btnOTFilter_Catering.UseVisualStyleBackColor = false;
		btnOTFilter_Catering.Click += btnOTFilter_Catering_Click;
		label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		label1.BackColor = Color.Gray;
		label1.Font = new Font("Microsoft Sans Serif", 10f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(317, 37);
		label1.Name = "label1";
		label1.Size = new Size(52, 35);
		label1.TabIndex = 233;
		label1.Text = "Filters:";
		label1.TextAlign = ContentAlignment.MiddleRight;
		btnOTFilter_All.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnOTFilter_All.BackColor = Color.FromArgb(214, 142, 81);
		btnOTFilter_All.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_All.FlatAppearance.BorderSize = 0;
		btnOTFilter_All.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_All.FlatStyle = FlatStyle.Flat;
		btnOTFilter_All.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnOTFilter_All.ForeColor = Color.White;
		btnOTFilter_All.ImeMode = ImeMode.NoControl;
		btnOTFilter_All.Location = new Point(370, 37);
		btnOTFilter_All.Margin = new Padding(0);
		btnOTFilter_All.Name = "btnOTFilter_All";
		btnOTFilter_All.Size = new Size(73, 35);
		btnOTFilter_All.TabIndex = 234;
		btnOTFilter_All.Text = "ALL";
		btnOTFilter_All.UseVisualStyleBackColor = false;
		btnOTFilter_All.Click += btnOTFilter_All_Click;
		verticalScrollControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(974, 109);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 100);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 584);
		verticalScrollControl1.TabIndex = 235;
		timer_1.Interval = 500;
		timer_1.Tick += timer_1_Tick;
		timer_2.Interval = 30000;
		timer_2.Tick += timer_2_Tick;
		ddlDateRangeFilter.DrawMode = DrawMode.OwnerDrawVariable;
		ddlDateRangeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlDateRangeFilter.FlatStyle = FlatStyle.Flat;
		ddlDateRangeFilter.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlDateRangeFilter.ItemHeight = 28;
		ddlDateRangeFilter.Location = new Point(1, 1);
		ddlDateRangeFilter.Margin = new Padding(4, 5, 4, 5);
		ddlDateRangeFilter.Name = "ddlDateRangeFilter";
		ddlDateRangeFilter.Size = new Size(206, 34);
		ddlDateRangeFilter.TabIndex = 249;
		ddlDateRangeFilter.SelectedIndexChanged += ddlDateRangeFilter_SelectedIndexChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1024, 768);
		base.Controls.Add(ddlDateRangeFilter);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnOTFilter_All);
		base.Controls.Add(label1);
		base.Controls.Add(btnOTFilter_Catering);
		base.Controls.Add(btnOTFilter_Delivery);
		base.Controls.Add(btnOTFilter_PickUp);
		base.Controls.Add(btnOTFilter_ToGo);
		base.Controls.Add(btnOTFilter_DineIn);
		base.Controls.Add(lblTicketNumber);
		base.Controls.Add(lblReceivedTime);
		base.Controls.Add(btnClearSearch);
		base.Controls.Add(lblCounter);
		base.Controls.Add(btnScreenRefresh);
		base.Controls.Add(label3);
		base.Controls.Add((Control)(object)txtSearchInfo);
		base.Controls.Add(btnShowKeyboard_SearchInfo);
		base.Controls.Add(btnChange);
		base.Controls.Add(lblFulfillment);
		base.Controls.Add(lblCustomerInfo);
		base.Controls.Add(lblOrderType);
		base.Controls.Add(lblOrderNumber);
		base.Controls.Add((Control)(object)radListOrders);
		base.Controls.Add(flowLayoutPanel1);
		base.Controls.Add(lblTitle);
		base.Name = "frmQuickServiceListView";
		base.Opacity = 1.0;
		Text = "frmQuickServiceListView";
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmQuickServiceListView_Load;
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(flowLayoutPanel1, 0);
		base.Controls.SetChildIndex((Control)(object)radListOrders, 0);
		base.Controls.SetChildIndex(lblOrderNumber, 0);
		base.Controls.SetChildIndex(lblOrderType, 0);
		base.Controls.SetChildIndex(lblCustomerInfo, 0);
		base.Controls.SetChildIndex(lblFulfillment, 0);
		base.Controls.SetChildIndex(btnChange, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_SearchInfo, 0);
		base.Controls.SetChildIndex((Control)(object)txtSearchInfo, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(btnScreenRefresh, 0);
		base.Controls.SetChildIndex(lblCounter, 0);
		base.Controls.SetChildIndex(btnClearSearch, 0);
		base.Controls.SetChildIndex(lblReceivedTime, 0);
		base.Controls.SetChildIndex(lblTicketNumber, 0);
		base.Controls.SetChildIndex(btnOTFilter_DineIn, 0);
		base.Controls.SetChildIndex(btnOTFilter_ToGo, 0);
		base.Controls.SetChildIndex(btnOTFilter_PickUp, 0);
		base.Controls.SetChildIndex(btnOTFilter_Delivery, 0);
		base.Controls.SetChildIndex(btnOTFilter_Catering, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(btnOTFilter_All, 0);
		base.Controls.SetChildIndex(verticalScrollControl1, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(ddlDateRangeFilter, 0);
		flowLayoutPanel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)radListOrders).EndInit();
		((ISupportInitialize)txtSearchInfo).EndInit();
		ResumeLayout(performLayout: false);
	}
}
