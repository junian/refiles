using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDeliveryManagement : frmMasterForm
{
	private bool jhpjWnjvei;

	private int int_0;

	private int kTdjvuOmiJ;

	private CustomPager customPager_0;

	private List<OrderResult> list_2;

	private Dictionary<string, string> dictionary_0;

	private Employee employee_0;

	private List<Employee> list_3;

	private DateTime dateTime_0;

	private List<ListViewDataItem> list_4;

	private IContainer icontainer_1;

	private Label label9;

	private CustomListViewTelerik radListOrders;

	private Label lblCounter;

	internal Button btnScreenRefresh;

	private Label col4;

	private Label col1;

	private Label col6;

	private Label col3;

	private Label col2;

	private CheckBox chkNotAssigned;

	private CheckBox chkAssigned;

	private Label label3;

	private FlowLayoutPanel flowLayoutPanel1;

	internal Button BtnCancel;

	internal Button btnAssignDriver;

	internal Button btnCashout;

	private Timer timer_0;

	internal Button btnPickUpOrder;

	internal Button btnRecordDelivery;

	private Label col5;

	private Label lblEmployeeName;

	internal Button btnSignInOut;

	internal Button btnRecordDelAndCashout;

	private CheckBox chkPickedUp;

	private CheckBox chkNotPickedUp;

	public frmDeliveryManagement()
	{
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		int_0 = 20;
		list_2 = new List<OrderResult>();
		dictionary_0 = new Dictionary<string, string>();
		dateTime_0 = DateTime.Now;
		list_4 = new List<ListViewDataItem>();
		base._002Ector();
		InitializeComponent_1();
		customPager_0 = new CustomPager();
		CustomPager customPager = customPager_0;
		customPager.PagerButton_Click = (EventHandler)Delegate.Combine(customPager.PagerButton_Click, new EventHandler(method_4));
		customPager_0.rowsPerPage = 5;
		base.Controls.Add(customPager_0);
		GClass6 gClass = new GClass6();
		list_3 = gClass.Employees.Where((Employee x) => x.isActive == true).ToList();
		dictionary_0 = list_3.Where((Employee a) => a.Users.First().Role.RoleName == "Driver").ToDictionary((Employee a) => a.EmployeeID.ToString(), (Employee b) => b.FirstName + " " + b.LastName);
		if (CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] != null && CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0")
		{
			Employee employee = list_3.Where((Employee a) => a.EmployeeID == Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString())).FirstOrDefault();
			if (employee != null)
			{
				lblEmployeeName.Text = employee.FirstName + " " + employee.LastName;
			}
		}
		else
		{
			lblEmployeeName.Text = string.Empty;
		}
		((RadListView)radListOrders).add_ItemMouseClick(new ListViewItemEventHandler(radListOrders_ItemMouseClick));
	}

	private void method_3()
	{
		((Collection<ListViewDetailColumn>)(object)((RadListView)radListOrders).get_Columns())[5].set_Width((float)(col6.Width - 23));
		customPager_0.Location = new Point(((Control)(object)radListOrders).Location.X, ((Control)(object)radListOrders).Bottom);
		customPager_0.Size = new Size(((Control)(object)radListOrders).Width, customPager_0.Height);
	}

	private void radListOrders_ItemMouseClick(object sender, ListViewItemEventArgs e)
	{
		if (list_4.Contains(e.get_Item()))
		{
			list_4.Remove(e.get_Item());
		}
		else
		{
			list_4.Add(e.get_Item());
		}
		((RadListView)radListOrders).get_SelectedItems().Clear();
		((RadListView)radListOrders).Select(list_4.ToArray());
	}

	private void method_4(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (button.Text == "<<")
		{
			method_5();
		}
		else if (button.Text == "<")
		{
			method_5(customPager_0.currentPage - 1);
		}
		else if (button.Text == ">")
		{
			method_5(customPager_0.currentPage + 1);
		}
		else if (button.Text == ">>")
		{
			method_5(customPager_0.lastPage - 1);
		}
		else
		{
			method_5(Convert.ToInt32(button.Text) - 1);
		}
	}

	private void method_5(int int_1 = 0)
	{
		if (jhpjWnjvei)
		{
			return;
		}
		try
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
			new GClass6();
			if (dateTime_0 < DateTime.Now.AddMinutes(-2.0) && btnSignInOut.Text == "SIGN-OUT")
			{
				lblEmployeeName.Text = string.Empty;
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
				employee_0 = null;
				btnSignInOut.Text = "SIGN-IN";
				dateTime_0 = DateTime.Now;
			}
			customPager_0.currentPage = int_1;
			lblCounter.Text = int_0.ToString();
			kTdjvuOmiJ = int_0;
			jhpjWnjvei = true;
			List<OrderResult> source = (from a in new OrderMethods().GetMultipleBills(string.Empty, "ALL")
				where a.OrderType == OrderTypes.Delivery || a.OrderType == OrderTypes.DeliveryOnline
				where !a.FulFillmentAt.HasValue || a.FulFillmentAt <= DateTime.Now.AddHours(2.0)
				select a).ToList();
			if (employee_0 != null && employee_0.Users.FirstOrDefault().Role.RoleName == Roles.driver)
			{
				source = source.Where((OrderResult orderResult_0) => !orderResult_0.UserServed.HasValue || orderResult_0.UserServed == employee_0.EmployeeID).ToList();
			}
			if (!chkAssigned.Checked)
			{
				source = source.Where((OrderResult a) => !a.UserServed.HasValue).ToList();
			}
			if (!chkNotAssigned.Checked)
			{
				source = source.Where((OrderResult a) => a.UserServed.HasValue).ToList();
			}
			if (!chkPickedUp.Checked)
			{
				source = source.Where((OrderResult a) => !a.DatePickup.HasValue).ToList();
			}
			if (!chkNotPickedUp.Checked)
			{
				source = source.Where((OrderResult a) => a.DatePickup.HasValue).ToList();
			}
			source = (from a in source
				orderby a.FulFillmentAt.HasValue, a.FulFillmentAt.HasValue ? a.FulFillmentAt.Value : a.DateCreated
				select a into x
				group x by x.OrderNumber into y
				select y.First()).ToList();
			List<OrderResult> list = source.ToList();
			CS_0024_003C_003E8__locals0.ordernumberSelected = "";
			if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems()).Count > 0)
			{
				CS_0024_003C_003E8__locals0.ordernumberSelected = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_Item(3).ToString();
			}
			if (list != null)
			{
				int num = list?.Count() ?? 0;
				int num2 = ((num % customPager_0.rowsPerPage != 0) ? 1 : 0);
				int lastPage = num / customPager_0.rowsPerPage + num2;
				customPager_0.lastPage = lastPage;
				list = list.Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage).ToList();
				customPager_0.AddPagerButtons();
				((RadListView)radListOrders).get_Items().Clear();
				using (List<OrderResult>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_1();
						CS_0024_003C_003E8__locals1.orderResult = enumerator.Current;
						string string_ = "";
						if (CS_0024_003C_003E8__locals1.orderResult.UserServed.HasValue)
						{
							Employee employee = list_3.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals1.orderResult.UserServed).FirstOrDefault();
							if (employee != null)
							{
								string_ = employee.FirstName;
							}
						}
						string settingValueByKey = SettingsHelper.GetSettingValueByKey("delivery_distance_uom");
						string obj = (CS_0024_003C_003E8__locals1.orderResult.TravelDistance.HasValue ? (CS_0024_003C_003E8__locals1.orderResult.TravelDistance.Value.ConvertDistance().ToString("0.00") + " " + settingValueByKey) : "");
						string text = CS_0024_003C_003E8__locals1.orderResult.TravelTime + " mins";
						string text2 = obj + " " + text + " (one way) \n";
						string obj2 = (CS_0024_003C_003E8__locals1.orderResult.TravelDistance.HasValue ? ((CS_0024_003C_003E8__locals1.orderResult.TravelDistance.Value.ConvertDistance() * 2m).ToString("0.00") + " " + settingValueByKey) : "");
						string text3 = CS_0024_003C_003E8__locals1.orderResult.TravelTime * 2 + " mins";
						string text4 = obj2 + " " + text3 + " (round)";
						method_6(CS_0024_003C_003E8__locals1.orderResult.OrderNumber, string_, CS_0024_003C_003E8__locals1.orderResult.DateCreated, text2 + text4, CS_0024_003C_003E8__locals1.orderResult.Customer, CS_0024_003C_003E8__locals1.orderResult.CustomerInfo, CS_0024_003C_003E8__locals1.orderResult.CustomerInfoName, CS_0024_003C_003E8__locals1.orderResult.isPaid, CS_0024_003C_003E8__locals1.orderResult.FlagID, CS_0024_003C_003E8__locals1.orderResult.UserServed, CS_0024_003C_003E8__locals1.orderResult.DatePickup, CS_0024_003C_003E8__locals1.orderResult.DateDelivered, CS_0024_003C_003E8__locals1.orderResult.FulFillmentAt);
					}
				}
				list_2.Clear();
				foreach (OrderResult item in list)
				{
					list_2.Add(item);
				}
				list.Clear();
			}
			if (CS_0024_003C_003E8__locals0.ordernumberSelected != "")
			{
				ListViewDataItem val = ((IEnumerable<ListViewDataItem>)((RadListView)radListOrders).get_Items()).Where((ListViewDataItem a) => a.get_Item(3).ToString() == CS_0024_003C_003E8__locals0.ordernumberSelected).FirstOrDefault();
				if (val != null)
				{
					((RadListView)radListOrders).set_SelectedIndex(((RadListView)radListOrders).get_Items().IndexOf(val));
				}
			}
			list = null;
			jhpjWnjvei = false;
		}
		catch (Exception)
		{
			jhpjWnjvei = false;
			new NotificationLabel(this, "Something went wrong loading the orders. Please REFRESH the page.", NotificationTypes.Warning).Show();
		}
	}

	private void method_6(string string_0, string string_1, DateTime dateTime_1, string string_2, string string_3, string string_4, string string_5, bool bool_0, byte byte_0, short? nullable_0, DateTime? nullable_1, DateTime? nullable_2, DateTime? nullable_3)
	{
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		string orderFlagString = MiscHelper.GetOrderFlagString(byte_0);
		string text = (bool_0 ? "**PAID**\r\n" : "");
		string text2 = ((!nullable_3.HasValue) ? "ASAP" : ((nullable_3.Value <= DateTime.Now) ? "ASAP" : nullable_3.ToString()));
		string[] array = new string[14]
		{
			string_1,
			" CREATED: " + dateTime_1.ToElapsedTime().Replace("second", "sec").Replace("minute", "min")
				.Replace("hour", "hr") + "\r\n  PICKED: " + (nullable_1.HasValue ? nullable_1.Value.ToString("hh:mm tt") : "") + "\r\n   DLVRD: " + ((!nullable_2.HasValue || !nullable_1.HasValue) ? "" : nullable_2.Value.ToString("hh:mm tt")) + "\r\nDLVRD IN: " + ((!nullable_2.HasValue || !nullable_1.HasValue) ? "" : ((int)(nullable_2.Value - nullable_1.Value).TotalMinutes + " mins")) + "\r\n",
			string_2,
			string_0,
			nullable_2.HasValue ? "YES" : "NO",
			text + "DLVR BY: " + text2 + "\r\n   NAME: " + string_5 + "\r\n  PHONE: " + string_3 + "\r\nADDRESS: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string_4.ToLower()),
			orderFlagString,
			string_3,
			string_4,
			string_5,
			nullable_0.HasValue ? nullable_0.Value.ToString() : "",
			nullable_1.HasValue ? nullable_1.Value.ToString() : "",
			nullable_2.HasValue ? nullable_2.Value.ToString() : "",
			bool_0.ToString()
		};
		ListViewDataItem val = new ListViewDataItem("", array);
		if (bool_0)
		{
			val.set_BackColor(Color.LightGreen);
		}
		else
		{
			val.set_BackColor(Color.White);
		}
		val.set_TextAlignment(ContentAlignment.TopLeft);
		((RadListView)radListOrders).get_Items().Add(val);
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		AuthMethods.LogOutUser();
		Close();
	}

	private void btnAssignDriver_Click(object sender, EventArgs e)
	{
		dateTime_0 = DateTime.Now;
		if (btnAssignDriver.Text == "ASSIGN DRIVER")
		{
			if (employee_0 == null)
			{
				return;
			}
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
			CS_0024_003C_003E8__locals0.employeeId = employee_0.EmployeeID;
			if (employee_0.Users.FirstOrDefault().Role.RoleName != Roles.driver)
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
				MemoryLoadedObjects.ItemSelector.LoadForm(null, _withCustom: false, "Select a Driver", _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: false, dictionary_0);
				if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.employeeId = Convert.ToInt32(MemoryLoadedObjects.ItemSelector.SingleSelectedKey);
			}
			GClass6 gClass = new GClass6();
			foreach (ListViewDataItem item in ((IEnumerable<ListViewDataItem>)((RadListView)radListOrders).get_SelectedItems()).Where((ListViewDataItem a) => string.IsNullOrEmpty(a.get_Item(0).ToString())))
			{
				_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass17_1();
				CS_0024_003C_003E8__locals2.ordnum = item.get_Item(3).ToString();
				List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals2.ordnum).ToList();
				if (list.Count > 0)
				{
					list.ForEach(delegate(Order a)
					{
						a.UserServed = (short)CS_0024_003C_003E8__locals0.employeeId;
					});
					Helper.SubmitChangesWithCatch(gClass);
				}
			}
			new NotificationLabel(this, "Order Assigned", NotificationTypes.Success).Show();
			method_5();
			return;
		}
		GClass6 gClass2 = new GClass6();
		foreach (ListViewDataItem item2 in ((IEnumerable<ListViewDataItem>)((RadListView)radListOrders).get_SelectedItems()).Where((ListViewDataItem a) => !string.IsNullOrEmpty(a.get_Item(0).ToString())))
		{
			_003C_003Ec__DisplayClass17_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass17_2();
			CS_0024_003C_003E8__locals1.ordnum = item2.get_Item(3).ToString();
			List<Order> list2 = gClass2.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.ordnum).ToList();
			if (list2.Count > 0)
			{
				list2.ForEach(delegate(Order a)
				{
					a.UserServed = null;
				});
				Helper.SubmitChangesWithCatch(gClass2);
			}
		}
		new NotificationLabel(this, "Driver Removed", NotificationTypes.Success).Show();
		method_5();
	}

	private void btnCashout_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_7()
	{
		dateTime_0 = DateTime.Now;
		if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems()).Count <= 0 || ((RadListView)radListOrders).get_Items().get_Count() <= ((RadListView)radListOrders).get_SelectedIndex())
		{
			return;
		}
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.ordnum = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_Item(3).ToString();
		string customer = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(7).ToString();
		string customerInfo = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(8).ToString();
		string customerInfoName = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(9).ToString();
		if (!Convert.ToBoolean(((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(13).ToString()))
		{
			frmOrderEntry obj = new frmOrderEntry(CS_0024_003C_003E8__locals0.ordnum, customer, OrderTypes.Delivery, 0, customerInfoName, customerInfo);
			obj.CashoutBill(isCashoutButton: true);
			method_5();
			obj.Dispose();
			return;
		}
		foreach (ListViewDataItem item in (ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())
		{
			bool num = Convert.ToBoolean(item.get_SubItems().get_Item(13).ToString());
			CS_0024_003C_003E8__locals0.ordnum = item.get_Item(3).ToString();
			if (!num)
			{
				continue;
			}
			GClass6 gClass = new GClass6();
			List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.ordnum).ToList();
			if (list.Count <= 0)
			{
				continue;
			}
			foreach (Order item2 in list)
			{
				item2.Synced = false;
				item2.DateCleared = DateTime.Now;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
		method_5();
		new NotificationLabel(this, "Order Cleared", NotificationTypes.Success).Show();
	}

	private void btnScreenRefresh_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		kTdjvuOmiJ--;
		lblCounter.Text = kTdjvuOmiJ.ToString();
		if (kTdjvuOmiJ <= 0)
		{
			method_5();
		}
	}

	private void frmDeliveryManagement_Load(object sender, EventArgs e)
	{
		method_3();
		Button button = btnAssignDriver;
		Button button2 = btnCashout;
		Button button3 = btnPickUpOrder;
		Button button4 = btnRecordDelivery;
		btnRecordDelAndCashout.Enabled = false;
		button4.Enabled = false;
		button3.Enabled = false;
		button2.Enabled = false;
		button.Enabled = false;
	}

	private void chkAssigned_CheckedChanged(object sender, EventArgs e)
	{
		if (!chkAssigned.Checked)
		{
			chkPickedUp.Checked = false;
		}
		method_5();
	}

	private void chkNotAssigned_CheckedChanged(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_8()
	{
		if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems()).Count > 0 && CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] != null && CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0")
		{
			string text = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(10).ToString();
			string text2 = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(11).ToString();
			string text3 = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(12).ToString();
			if (Convert.ToBoolean(((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_SubItems().get_Item(13).ToString()))
			{
				btnCashout.Text = "CLEAR";
			}
			else
			{
				btnCashout.Text = "CASHOUT";
			}
			btnAssignDriver.Enabled = false;
			if (employee_0 != null && (employee_0.Users.FirstOrDefault().Role.RoleName == Roles.admin || employee_0.Users.FirstOrDefault().Role.RoleName == Roles.manager))
			{
				btnAssignDriver.Enabled = true;
				if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0].get_Item(0).ToString() != "")
				{
					btnAssignDriver.Text = "REMOVE DRIVER";
					btnAssignDriver.BackColor = Color.FromArgb(147, 101, 184);
				}
				else
				{
					btnAssignDriver.Text = "ASSIGN DRIVER";
					btnAssignDriver.BackColor = Color.FromArgb(1, 110, 211);
				}
			}
			btnPickUpOrder.Enabled = true;
			if (text == CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() && text2 == "")
			{
				btnPickUpOrder.Enabled = true;
			}
			else if (text2 != "")
			{
				Button button = btnAssignDriver;
				btnPickUpOrder.Enabled = false;
				button.Enabled = false;
			}
			if (text2 != "" && text3 == "" && text == CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString())
			{
				Button button2 = btnRecordDelivery;
				btnRecordDelAndCashout.Enabled = true;
				button2.Enabled = true;
			}
			else
			{
				Button button3 = btnRecordDelivery;
				btnRecordDelAndCashout.Enabled = false;
				button3.Enabled = false;
			}
			if (text3 != "" && text == CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString())
			{
				btnCashout.Enabled = true;
			}
			else
			{
				btnCashout.Enabled = false;
			}
		}
		else
		{
			Button button4 = btnPickUpOrder;
			Button button5 = btnRecordDelivery;
			Button button6 = btnRecordDelAndCashout;
			Button button7 = btnAssignDriver;
			btnCashout.Enabled = false;
			button7.Enabled = false;
			button6.Enabled = false;
			button5.Enabled = false;
			button4.Enabled = false;
		}
	}

	private void radListOrders_SelectedItemChanged(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_9(object sender, MouseEventArgs e)
	{
		method_8();
	}

	private void btnPickUpOrder_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_10()
	{
		if (employee_0 == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals0.employeeId = employee_0.EmployeeID;
		if (employee_0.Users.FirstOrDefault().Role.RoleName != Roles.driver)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(null, _withCustom: false, "Select a Driver", _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: false, dictionary_0);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			CS_0024_003C_003E8__locals0.employeeId = Convert.ToInt32(MemoryLoadedObjects.ItemSelector.SingleSelectedKey);
		}
		dateTime_0 = DateTime.Now;
		GClass6 gClass = new GClass6();
		foreach (ListViewDataItem item in (ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())
		{
			_003C_003Ec__DisplayClass29_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass29_1();
			CS_0024_003C_003E8__locals1.ordnum = item.get_Item(3).ToString();
			List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.ordnum).ToList();
			if (list.Count > 0)
			{
				list.ForEach(delegate(Order a)
				{
					a.DepartureTime = DateTime.Now;
					a.UserServed = (short)CS_0024_003C_003E8__locals0.employeeId;
				});
				PrintHelper.GenerateReceipt(CS_0024_003C_003E8__locals1.ordnum, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		new NotificationLabel(this, "Order Picked Up", NotificationTypes.Success).Show();
		method_5();
	}

	private void btnRecordDelivery_Click(object sender, EventArgs e)
	{
		method_11(bool_0: false);
	}

	private void method_11(bool bool_0)
	{
		dateTime_0 = DateTime.Now;
		if (((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems()).Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass31_0();
		ListViewDataItem val = ((ReadOnlyCollection<ListViewDataItem>)(object)((RadListView)radListOrders).get_SelectedItems())[0];
		CS_0024_003C_003E8__locals0.timeSelected = new frmTimePicker(DateTime.Now.AddMinutes(-5.0), 5);
		if (CS_0024_003C_003E8__locals0.timeSelected.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		_003C_003Ec__DisplayClass31_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass31_1();
		if (DateTime.Now < CS_0024_003C_003E8__locals0.timeSelected.Time)
		{
			new NotificationLabel(this, "Time cannot be later than current time.", NotificationTypes.Warning).Show();
			return;
		}
		if (CS_0024_003C_003E8__locals0.timeSelected.Time < Convert.ToDateTime(val.get_SubItems().get_Item(11).ToString()))
		{
			new NotificationLabel(this, "Time cannot be earlier than pick up time.", NotificationTypes.Warning).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals1.ordnum = val.get_Item(3).ToString();
		List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.ordnum).ToList();
		if (list.Count > 0)
		{
			list.ForEach(delegate(Order a)
			{
				a.DeliveryTime = CS_0024_003C_003E8__locals0.timeSelected.Time;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		new NotificationLabel(this, "Order Delivery Time Added.", NotificationTypes.Success).Show();
		if (bool_0)
		{
			method_7();
		}
		else
		{
			method_5();
		}
	}

	private void btnRecordDelAndCashout_EnabledChanged(object sender, EventArgs e)
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

	private void btnSignInOut_Click(object sender, EventArgs e)
	{
		if (btnSignInOut.Text == "SIGN-IN")
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Employee_PIN, 0, 8);
			bool flag = false;
			do
			{
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					flag = true;
				}
				else if (MemoryLoadedObjects.Numpad.numberEntered.ToString().Length <= 8)
				{
					employee_0 = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
					if (employee_0 != null)
					{
						CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee_0.EmployeeID;
						lblEmployeeName.Text = employee_0.FirstName + " " + employee_0.LastName;
						btnSignInOut.Text = "SIGN-OUT";
						flag = true;
					}
					else
					{
						lblEmployeeName.Text = string.Empty;
						new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
						MemoryLoadedObjects.Numpad.TextInput = string.Empty;
					}
				}
				else
				{
					lblEmployeeName.Text = string.Empty;
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag);
		}
		else
		{
			lblEmployeeName.Text = string.Empty;
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
			btnSignInOut.Text = "SIGN-IN";
			employee_0 = null;
		}
		dateTime_0 = DateTime.Now;
		method_5();
	}

	private void btnRecordDelAndCashout_Click(object sender, EventArgs e)
	{
		method_11(bool_0: true);
	}

	private void chkPickedUp_CheckedChanged(object sender, EventArgs e)
	{
		if (chkPickedUp.Checked)
		{
			chkAssigned.Checked = true;
		}
		method_5();
	}

	private void chkNotPickedUp_CheckedChanged(object sender, EventArgs e)
	{
		method_5();
	}

	private void lblCounter_Click(object sender, EventArgs e)
	{
		method_5();
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDeliveryManagement));
		ListViewDetailColumn val = new ListViewDetailColumn("Column 0", "Column 0");
		ListViewDetailColumn val2 = new ListViewDetailColumn("Column 1", "Column 1");
		ListViewDetailColumn val3 = new ListViewDetailColumn("Column 2", "Column 2");
		ListViewDetailColumn val4 = new ListViewDetailColumn("Column 3", "Column 3");
		ListViewDetailColumn val5 = new ListViewDetailColumn("Column 4", "Column 4");
		ListViewDetailColumn val6 = new ListViewDetailColumn("Column 5", "Column 5");
		ListViewDataItem val7 = new ListViewDataItem("ListViewItem 1");
		timer_0 = new Timer(icontainer_1);
		col5 = new Label();
		flowLayoutPanel1 = new FlowLayoutPanel();
		BtnCancel = new Button();
		btnAssignDriver = new Button();
		btnCashout = new Button();
		btnPickUpOrder = new Button();
		btnRecordDelivery = new Button();
		btnRecordDelAndCashout = new Button();
		btnSignInOut = new Button();
		lblEmployeeName = new Label();
		chkNotAssigned = new CheckBox();
		chkAssigned = new CheckBox();
		label3 = new Label();
		lblCounter = new Label();
		btnScreenRefresh = new Button();
		col2 = new Label();
		col3 = new Label();
		col6 = new Label();
		col1 = new Label();
		col4 = new Label();
		label9 = new Label();
		radListOrders = new CustomListViewTelerik();
		chkPickedUp = new CheckBox();
		chkNotPickedUp = new CheckBox();
		flowLayoutPanel1.SuspendLayout();
		((ISupportInitialize)radListOrders).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		col5.BackColor = Color.FromArgb(61, 142, 185);
		col5.Font = new Font("Microsoft Sans Serif", 10f);
		col5.ForeColor = Color.White;
		col5.ImeMode = ImeMode.NoControl;
		col5.Location = new Point(624, 76);
		col5.Margin = new Padding(0, 0, 0, 1);
		col5.MinimumSize = new Size(0, 35);
		col5.Name = "col5";
		col5.Size = new Size(73, 35);
		col5.TabIndex = 241;
		col5.Text = "Delivered";
		col5.TextAlign = ContentAlignment.MiddleCenter;
		flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		flowLayoutPanel1.Controls.Add(BtnCancel);
		flowLayoutPanel1.Controls.Add(btnAssignDriver);
		flowLayoutPanel1.Controls.Add(btnCashout);
		flowLayoutPanel1.Controls.Add(btnPickUpOrder);
		flowLayoutPanel1.Controls.Add(btnRecordDelivery);
		flowLayoutPanel1.Controls.Add(btnRecordDelAndCashout);
		flowLayoutPanel1.Controls.Add(btnSignInOut);
		flowLayoutPanel1.Controls.Add(lblEmployeeName);
		flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
		flowLayoutPanel1.Location = new Point(1, 454);
		flowLayoutPanel1.Name = "flowLayoutPanel1";
		flowLayoutPanel1.Size = new Size(1009, 61);
		flowLayoutPanel1.TabIndex = 239;
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.White;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.FlatStyle = FlatStyle.Flat;
		BtnCancel.Font = new Font("Microsoft Sans Serif", 8.25f);
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Image = (Image)componentResourceManager.GetObject("BtnCancel.Image");
		BtnCancel.ImeMode = ImeMode.NoControl;
		BtnCancel.Location = new Point(898, 0);
		BtnCancel.Margin = new Padding(1, 0, 0, 0);
		BtnCancel.Name = "BtnCancel";
		BtnCancel.Padding = new Padding(10, 5, 0, 5);
		BtnCancel.Size = new Size(111, 60);
		BtnCancel.TabIndex = 20;
		BtnCancel.Text = "CLOSE";
		BtnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		btnAssignDriver.BackColor = Color.FromArgb(1, 110, 211);
		btnAssignDriver.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnAssignDriver.FlatAppearance.BorderSize = 0;
		btnAssignDriver.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAssignDriver.FlatStyle = FlatStyle.Flat;
		btnAssignDriver.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnAssignDriver.ForeColor = Color.White;
		btnAssignDriver.Image = (Image)componentResourceManager.GetObject("btnAssignDriver.Image");
		btnAssignDriver.ImageAlign = ContentAlignment.MiddleLeft;
		btnAssignDriver.ImeMode = ImeMode.NoControl;
		btnAssignDriver.Location = new Point(775, 0);
		btnAssignDriver.Margin = new Padding(1, 0, 0, 0);
		btnAssignDriver.Name = "btnAssignDriver";
		btnAssignDriver.Padding = new Padding(10, 5, 0, 5);
		btnAssignDriver.Size = new Size(122, 60);
		btnAssignDriver.TabIndex = 32;
		btnAssignDriver.Text = "ASSIGN DRIVER";
		btnAssignDriver.TextAlign = ContentAlignment.MiddleLeft;
		btnAssignDriver.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnAssignDriver.UseVisualStyleBackColor = false;
		btnAssignDriver.EnabledChanged += btnRecordDelAndCashout_EnabledChanged;
		btnAssignDriver.Click += btnAssignDriver_Click;
		btnCashout.BackColor = Color.FromArgb(80, 203, 116);
		btnCashout.FlatAppearance.BorderColor = Color.Black;
		btnCashout.FlatAppearance.BorderSize = 0;
		btnCashout.FlatAppearance.MouseDownBackColor = Color.White;
		btnCashout.FlatStyle = FlatStyle.Flat;
		btnCashout.Font = new Font("Microsoft Sans Serif", 7.5f);
		btnCashout.ForeColor = Color.White;
		btnCashout.Image = (Image)componentResourceManager.GetObject("btnCashout.Image");
		btnCashout.ImageAlign = ContentAlignment.MiddleLeft;
		btnCashout.ImeMode = ImeMode.NoControl;
		btnCashout.Location = new Point(661, 0);
		btnCashout.Margin = new Padding(1, 0, 0, 1);
		btnCashout.Name = "btnCashout";
		btnCashout.Size = new Size(113, 60);
		btnCashout.TabIndex = 88;
		btnCashout.Tag = "";
		btnCashout.Text = "CASHOUT";
		btnCashout.TextAlign = ContentAlignment.MiddleLeft;
		btnCashout.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCashout.UseVisualStyleBackColor = false;
		btnCashout.EnabledChanged += btnRecordDelAndCashout_EnabledChanged;
		btnCashout.Click += btnCashout_Click;
		btnPickUpOrder.BackColor = Color.FromArgb(122, 79, 148);
		btnPickUpOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnPickUpOrder.FlatAppearance.BorderSize = 0;
		btnPickUpOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPickUpOrder.FlatStyle = FlatStyle.Flat;
		btnPickUpOrder.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnPickUpOrder.ForeColor = Color.White;
		btnPickUpOrder.Image = (Image)componentResourceManager.GetObject("btnPickUpOrder.Image");
		btnPickUpOrder.ImageAlign = ContentAlignment.MiddleLeft;
		btnPickUpOrder.ImeMode = ImeMode.NoControl;
		btnPickUpOrder.Location = new Point(545, 0);
		btnPickUpOrder.Margin = new Padding(1, 0, 0, 0);
		btnPickUpOrder.Name = "btnPickUpOrder";
		btnPickUpOrder.Padding = new Padding(10, 5, 0, 5);
		btnPickUpOrder.Size = new Size(115, 60);
		btnPickUpOrder.TabIndex = 89;
		btnPickUpOrder.Text = "PICK UP ORDER";
		btnPickUpOrder.TextAlign = ContentAlignment.MiddleLeft;
		btnPickUpOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnPickUpOrder.UseVisualStyleBackColor = false;
		btnPickUpOrder.EnabledChanged += btnRecordDelAndCashout_EnabledChanged;
		btnPickUpOrder.Click += btnPickUpOrder_Click;
		btnRecordDelivery.BackColor = Color.FromArgb(147, 101, 184);
		btnRecordDelivery.FlatAppearance.BorderColor = Color.Sienna;
		btnRecordDelivery.FlatAppearance.BorderSize = 0;
		btnRecordDelivery.FlatAppearance.MouseDownBackColor = Color.White;
		btnRecordDelivery.FlatStyle = FlatStyle.Flat;
		btnRecordDelivery.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnRecordDelivery.ForeColor = Color.White;
		btnRecordDelivery.Image = (Image)componentResourceManager.GetObject("btnRecordDelivery.Image");
		btnRecordDelivery.ImageAlign = ContentAlignment.MiddleLeft;
		btnRecordDelivery.ImeMode = ImeMode.NoControl;
		btnRecordDelivery.Location = new Point(423, 0);
		btnRecordDelivery.Margin = new Padding(1, 0, 0, 1);
		btnRecordDelivery.MinimumSize = new Size(121, 58);
		btnRecordDelivery.Name = "btnRecordDelivery";
		btnRecordDelivery.Size = new Size(121, 60);
		btnRecordDelivery.TabIndex = 90;
		btnRecordDelivery.Text = "RECORD DELIVERY TIME";
		btnRecordDelivery.TextAlign = ContentAlignment.MiddleLeft;
		btnRecordDelivery.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnRecordDelivery.UseVisualStyleBackColor = false;
		btnRecordDelivery.EnabledChanged += btnRecordDelAndCashout_EnabledChanged;
		btnRecordDelivery.Click += btnRecordDelivery_Click;
		btnRecordDelAndCashout.BackColor = Color.FromArgb(53, 143, 79);
		btnRecordDelAndCashout.FlatAppearance.BorderColor = Color.Sienna;
		btnRecordDelAndCashout.FlatAppearance.BorderSize = 0;
		btnRecordDelAndCashout.FlatAppearance.MouseDownBackColor = Color.White;
		btnRecordDelAndCashout.FlatStyle = FlatStyle.Flat;
		btnRecordDelAndCashout.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnRecordDelAndCashout.ForeColor = Color.White;
		btnRecordDelAndCashout.Image = (Image)componentResourceManager.GetObject("btnRecordDelAndCashout.Image");
		btnRecordDelAndCashout.ImageAlign = ContentAlignment.MiddleLeft;
		btnRecordDelAndCashout.ImeMode = ImeMode.NoControl;
		btnRecordDelAndCashout.Location = new Point(293, 0);
		btnRecordDelAndCashout.Margin = new Padding(1, 0, 0, 1);
		btnRecordDelAndCashout.MinimumSize = new Size(121, 58);
		btnRecordDelAndCashout.Name = "btnRecordDelAndCashout";
		btnRecordDelAndCashout.Size = new Size(129, 60);
		btnRecordDelAndCashout.TabIndex = 245;
		btnRecordDelAndCashout.Text = "RECORD DELIVERY && CASHOUT";
		btnRecordDelAndCashout.TextAlign = ContentAlignment.MiddleLeft;
		btnRecordDelAndCashout.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnRecordDelAndCashout.UseVisualStyleBackColor = false;
		btnRecordDelAndCashout.EnabledChanged += btnRecordDelAndCashout_EnabledChanged;
		btnRecordDelAndCashout.Click += btnRecordDelAndCashout_Click;
		btnSignInOut.BackColor = Color.FromArgb(255, 192, 128);
		btnSignInOut.FlatAppearance.BorderColor = Color.White;
		btnSignInOut.FlatAppearance.BorderSize = 0;
		btnSignInOut.FlatAppearance.MouseDownBackColor = Color.White;
		btnSignInOut.FlatStyle = FlatStyle.Flat;
		btnSignInOut.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnSignInOut.ForeColor = Color.White;
		btnSignInOut.Image = (Image)componentResourceManager.GetObject("btnSignInOut.Image");
		btnSignInOut.ImageAlign = ContentAlignment.TopCenter;
		btnSignInOut.ImeMode = ImeMode.NoControl;
		btnSignInOut.Location = new Point(167, 0);
		btnSignInOut.Margin = new Padding(1, 0, 0, 1);
		btnSignInOut.MaximumSize = new Size(140, 87);
		btnSignInOut.Name = "btnSignInOut";
		btnSignInOut.Padding = new Padding(0, 3, 0, 3);
		btnSignInOut.Size = new Size(125, 60);
		btnSignInOut.TabIndex = 244;
		btnSignInOut.Text = "SIGN-IN";
		btnSignInOut.TextAlign = ContentAlignment.MiddleLeft;
		btnSignInOut.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSignInOut.UseVisualStyleBackColor = false;
		btnSignInOut.Click += btnSignInOut_Click;
		lblEmployeeName.BackColor = Color.DarkGray;
		lblEmployeeName.Font = new Font("Microsoft Sans Serif", 11.5f);
		lblEmployeeName.ForeColor = Color.Black;
		lblEmployeeName.ImeMode = ImeMode.NoControl;
		lblEmployeeName.Location = new Point(4, 0);
		lblEmployeeName.Margin = new Padding(0);
		lblEmployeeName.Name = "lblEmployeeName";
		lblEmployeeName.Size = new Size(162, 61);
		lblEmployeeName.TabIndex = 243;
		lblEmployeeName.Text = "EMPLOYEE NAME";
		lblEmployeeName.TextAlign = ContentAlignment.MiddleCenter;
		chkNotAssigned.BackColor = Color.LightGray;
		chkNotAssigned.Checked = true;
		chkNotAssigned.CheckState = CheckState.Checked;
		chkNotAssigned.Font = new Font("Microsoft Sans Serif", 11.25f);
		chkNotAssigned.ForeColor = Color.Black;
		chkNotAssigned.ImeMode = ImeMode.NoControl;
		chkNotAssigned.Location = new Point(296, 39);
		chkNotAssigned.Name = "chkNotAssigned";
		chkNotAssigned.Padding = new Padding(5, 2, 5, 2);
		chkNotAssigned.Size = new Size(203, 36);
		chkNotAssigned.TabIndex = 237;
		chkNotAssigned.Text = "NOT ASSIGNED";
		chkNotAssigned.UseVisualStyleBackColor = false;
		chkNotAssigned.CheckedChanged += chkNotAssigned_CheckedChanged;
		chkAssigned.BackColor = Color.LightGray;
		chkAssigned.Checked = true;
		chkAssigned.CheckState = CheckState.Checked;
		chkAssigned.Font = new Font("Microsoft Sans Serif", 11.25f);
		chkAssigned.ForeColor = Color.Black;
		chkAssigned.ImeMode = ImeMode.NoControl;
		chkAssigned.Location = new Point(123, 39);
		chkAssigned.Name = "chkAssigned";
		chkAssigned.Padding = new Padding(5, 2, 5, 2);
		chkAssigned.Size = new Size(172, 36);
		chkAssigned.TabIndex = 236;
		chkAssigned.Text = "ASSIGNED";
		chkAssigned.UseVisualStyleBackColor = false;
		chkAssigned.CheckedChanged += chkAssigned_CheckedChanged;
		label3.BackColor = Color.DarkGray;
		label3.Font = new Font("Microsoft Sans Serif", 11.5f);
		label3.ForeColor = Color.Black;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(-1, 39);
		label3.Name = "label3";
		label3.Size = new Size(123, 36);
		label3.TabIndex = 235;
		label3.Text = "FILTERS:";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		lblCounter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		lblCounter.BackColor = Color.FromArgb(65, 168, 95);
		lblCounter.Font = new Font("Microsoft Sans Serif", 26f, FontStyle.Bold);
		lblCounter.ForeColor = Color.White;
		lblCounter.ImeMode = ImeMode.NoControl;
		lblCounter.Location = new Point(884, 17);
		lblCounter.Margin = new Padding(2, 0, 2, 0);
		lblCounter.Name = "lblCounter";
		lblCounter.Size = new Size(57, 43);
		lblCounter.TabIndex = 234;
		lblCounter.Text = "20";
		lblCounter.TextAlign = ContentAlignment.MiddleCenter;
		lblCounter.Click += lblCounter_Click;
		btnScreenRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnScreenRefresh.BackColor = Color.FromArgb(65, 168, 95);
		btnScreenRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnScreenRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnScreenRefresh.FlatStyle = FlatStyle.Flat;
		btnScreenRefresh.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnScreenRefresh.ForeColor = Color.White;
		btnScreenRefresh.ImeMode = ImeMode.NoControl;
		btnScreenRefresh.Location = new Point(879, 3);
		btnScreenRefresh.Name = "btnScreenRefresh";
		btnScreenRefresh.Padding = new Padding(55, 4, 8, 0);
		btnScreenRefresh.Size = new Size(131, 72);
		btnScreenRefresh.TabIndex = 233;
		btnScreenRefresh.Text = "REFRESH NOW";
		btnScreenRefresh.TextAlign = ContentAlignment.MiddleLeft;
		btnScreenRefresh.UseVisualStyleBackColor = true;
		btnScreenRefresh.Click += btnScreenRefresh_Click;
		col2.BackColor = Color.FromArgb(61, 142, 185);
		col2.Font = new Font("Microsoft Sans Serif", 10f);
		col2.ForeColor = Color.White;
		col2.ImeMode = ImeMode.NoControl;
		col2.Location = new Point(123, 76);
		col2.Margin = new Padding(0, 0, 0, 1);
		col2.MinimumSize = new Size(0, 35);
		col2.Name = "col2";
		col2.Size = new Size(245, 35);
		col2.TabIndex = 232;
		col2.Text = "Order Timer";
		col2.TextAlign = ContentAlignment.MiddleCenter;
		col3.BackColor = Color.FromArgb(61, 142, 185);
		col3.Font = new Font("Microsoft Sans Serif", 10f);
		col3.ForeColor = Color.White;
		col3.ImeMode = ImeMode.NoControl;
		col3.Location = new Point(369, 76);
		col3.Margin = new Padding(0, 0, 0, 1);
		col3.MinimumSize = new Size(0, 35);
		col3.Name = "col3";
		col3.Size = new Size(129, 35);
		col3.TabIndex = 231;
		col3.Text = "Est. Travel Time";
		col3.TextAlign = ContentAlignment.MiddleCenter;
		col6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		col6.BackColor = Color.FromArgb(61, 142, 185);
		col6.Font = new Font("Microsoft Sans Serif", 10f);
		col6.ForeColor = Color.White;
		col6.ImeMode = ImeMode.NoControl;
		col6.Location = new Point(698, 76);
		col6.Margin = new Padding(0, 0, 0, 1);
		col6.MinimumSize = new Size(0, 35);
		col6.Name = "col6";
		col6.Padding = new Padding(10, 0, 0, 0);
		col6.Size = new Size(312, 35);
		col6.TabIndex = 230;
		col6.Text = "Order && Customer Info";
		col6.TextAlign = ContentAlignment.MiddleLeft;
		col1.BackColor = Color.FromArgb(61, 142, 185);
		col1.Font = new Font("Microsoft Sans Serif", 10f);
		col1.ForeColor = Color.White;
		col1.ImeMode = ImeMode.NoControl;
		col1.Location = new Point(0, 76);
		col1.Margin = new Padding(0, 0, 0, 1);
		col1.MinimumSize = new Size(0, 35);
		col1.Name = "col1";
		col1.Size = new Size(122, 35);
		col1.TabIndex = 229;
		col1.Text = "Driver";
		col1.TextAlign = ContentAlignment.MiddleCenter;
		col4.BackColor = Color.FromArgb(61, 142, 185);
		col4.Font = new Font("Microsoft Sans Serif", 10f);
		col4.ForeColor = Color.White;
		col4.ImeMode = ImeMode.NoControl;
		col4.Location = new Point(499, 76);
		col4.Margin = new Padding(0, 0, 0, 1);
		col4.MinimumSize = new Size(0, 35);
		col4.Name = "col4";
		col4.Size = new Size(124, 35);
		col4.TabIndex = 228;
		col4.Text = "Order #";
		col4.TextAlign = ContentAlignment.MiddleCenter;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(-78, 3);
		label9.MinimumSize = new Size(720, 35);
		label9.Name = "label9";
		label9.Size = new Size(1159, 35);
		label9.TabIndex = 101;
		label9.Text = "DELIVERY MANAGEMENT SYSTEM";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		((RadListView)radListOrders).set_AllowArbitraryItemHeight(true);
		((RadListView)radListOrders).set_AllowEdit(false);
		((RadListView)radListOrders).set_AllowRemove(false);
		((Control)(object)radListOrders).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		val.set_HeaderText("Column 0");
		val.set_Width(122f);
		val2.set_HeaderText("Column 1");
		val2.set_Width(246f);
		val3.set_HeaderText("Column 2");
		val3.set_Width(131f);
		val4.set_HeaderText("Column 3");
		val4.set_Width(126f);
		val5.set_HeaderText("Column 4");
		val5.set_Width(75f);
		val6.set_HeaderText("Column 5");
		val6.set_Width(275f);
		((RadListView)radListOrders).get_Columns().AddRange((ListViewDetailColumn[])(object)new ListViewDetailColumn[6] { val, val2, val3, val4, val5, val6 });
		((RadListView)radListOrders).set_EnableKineticScrolling(true);
		((Control)(object)radListOrders).Font = new Font("Courier New", 13.5f);
		val7.set_Text("ListViewItem 1");
		((RadListView)radListOrders).get_Items().AddRange((ListViewDataItem[])(object)new ListViewDataItem[1] { val7 });
		((RadListView)radListOrders).set_ItemSpacing(-1);
		((Control)(object)radListOrders).Location = new Point(1, 112);
		((RadListView)radListOrders).set_MultiSelect(true);
		((Control)(object)radListOrders).Name = "radListOrders";
		((RadListView)radListOrders).set_SelectLastAddedItem(false);
		((RadListView)radListOrders).set_ShowColumnHeaders(false);
		((RadListView)radListOrders).set_ShowGridLines(true);
		((Control)(object)radListOrders).Size = new Size(1009, 298);
		((Control)(object)radListOrders).TabIndex = 227;
		((Control)(object)radListOrders).Text = "radListView1";
		((RadListView)radListOrders).set_ViewType((ListViewType)2);
		((RadListView)radListOrders).add_SelectedItemChanged((EventHandler)radListOrders_SelectedItemChanged);
		chkPickedUp.BackColor = Color.LightGray;
		chkPickedUp.Checked = true;
		chkPickedUp.CheckState = CheckState.Checked;
		chkPickedUp.Font = new Font("Microsoft Sans Serif", 11.25f);
		chkPickedUp.ForeColor = Color.Black;
		chkPickedUp.ImeMode = ImeMode.NoControl;
		chkPickedUp.Location = new Point(500, 39);
		chkPickedUp.Name = "chkPickedUp";
		chkPickedUp.Padding = new Padding(5, 2, 5, 2);
		chkPickedUp.Size = new Size(172, 36);
		chkPickedUp.TabIndex = 242;
		chkPickedUp.Text = "PICKED UP";
		chkPickedUp.UseVisualStyleBackColor = false;
		chkPickedUp.CheckedChanged += chkPickedUp_CheckedChanged;
		chkNotPickedUp.BackColor = Color.LightGray;
		chkNotPickedUp.Checked = true;
		chkNotPickedUp.CheckState = CheckState.Checked;
		chkNotPickedUp.Font = new Font("Microsoft Sans Serif", 11.25f);
		chkNotPickedUp.ForeColor = Color.Black;
		chkNotPickedUp.ImeMode = ImeMode.NoControl;
		chkNotPickedUp.Location = new Point(673, 39);
		chkNotPickedUp.Name = "chkNotPickedUp";
		chkNotPickedUp.Padding = new Padding(5, 2, 5, 2);
		chkNotPickedUp.Size = new Size(206, 36);
		chkNotPickedUp.TabIndex = 243;
		chkNotPickedUp.Text = "NOT PICKED UP";
		chkNotPickedUp.UseVisualStyleBackColor = false;
		chkNotPickedUp.CheckedChanged += chkNotPickedUp_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1010, 518);
		base.Controls.Add(chkNotPickedUp);
		base.Controls.Add(chkPickedUp);
		base.Controls.Add(col5);
		base.Controls.Add(flowLayoutPanel1);
		base.Controls.Add(chkNotAssigned);
		base.Controls.Add(chkAssigned);
		base.Controls.Add(label3);
		base.Controls.Add(lblCounter);
		base.Controls.Add(btnScreenRefresh);
		base.Controls.Add(col2);
		base.Controls.Add(col3);
		base.Controls.Add(col6);
		base.Controls.Add(col1);
		base.Controls.Add(col4);
		base.Controls.Add((Control)(object)radListOrders);
		base.Controls.Add(label9);
		base.Name = "frmDeliveryManagement";
		base.Opacity = 1.0;
		Text = "Delivery Management System";
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmDeliveryManagement_Load;
		flowLayoutPanel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)radListOrders).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool VdPjkvuZla(OrderResult orderResult_0)
	{
		if (orderResult_0.UserServed.HasValue)
		{
			return orderResult_0.UserServed == employee_0.EmployeeID;
		}
		return true;
	}
}
