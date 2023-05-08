using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Newtonsoft.Json;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmCustomersMini : frmMasterForm
{
	private int int_0;

	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private string string_2;

	public int orderOnHoldTime;

	public DateTime? FulfillmentDate;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private string string_5;

	[CompilerGenerated]
	private string string_6;

	private List<GlobalOrderHistoryObjects.Order> list_2;

	private List<GlobalOrderHistoryObjects.CustomerInfo> list_3;

	private GlobalOrderHistoryObjects.CustomerInfo customerInfo_0;

	private GClass6 gclass6_0;

	private IContainer icontainer_1;

	internal ListView lstCustomers;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Label lblName;

	private Label lblCellPhone;

	internal Button btnClose;

	internal Button btnSave;

	private Label lblEmail;

	private Label lblMemberInfo;

	internal Button btnCancel;

	private Label lblTrainingMode;

	internal Button btnShowKeyboard_Name;

	internal Button btnShowKeyboard_Cell;

	internal Button btnShowKeyboard_Email;

	private Panel pnlMain;

	private Label lblWIndowTitle;

	private RadTextBoxControl txtEmail;

	private RadTextBoxControl txtCell;

	private RadTextBoxControl txtName;

	private RadTextBoxControl txtAddress;

	internal Button btnShowKeyboard_Address;

	private Label label4;

	private ColumnHeader columnHeader_2;

	internal Button btnDuplicate;

	private Label label1;

	internal ListView lstOrderHistory;

	internal ColumnHeader columnHeader_3;

	internal ColumnHeader columnHeader_4;

	private Label label8;

	private Label label7;

	internal ListView lstItems;

	private ColumnHeader columnHeader_5;

	internal ColumnHeader columnHeader_6;

	public string returnCell
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public string returnEmail
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string returnName
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public string returnAddress
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public int returnCustomerId
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public frmCustomersMini()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = true;
		string_2 = string.Empty;
		list_2 = new List<GlobalOrderHistoryObjects.Order>();
		list_3 = new List<GlobalOrderHistoryObjects.CustomerInfo>();
		customerInfo_0 = new GlobalOrderHistoryObjects.CustomerInfo();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		_ = Thread.CurrentThread.CurrentCulture;
	}

	public void LoadFormData(string _searchCriteria = null, string _orderType = null, bool _OEOpened = false)
	{
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		((Control)(object)txtAddress).Text = string.Empty;
		((Control)(object)txtName).Text = string.Empty;
		((Control)(object)txtCell).Text = string.Empty;
		((Control)(object)txtEmail).Text = string.Empty;
		list_2 = new List<GlobalOrderHistoryObjects.Order>();
		list_3 = new List<GlobalOrderHistoryObjects.CustomerInfo>();
		customerInfo_0 = new GlobalOrderHistoryObjects.CustomerInfo();
		bool_1 = _OEOpened;
		lstCustomers.Items.Clear();
		lstItems.Items.Clear();
		lstOrderHistory.Items.Clear();
		string_0 = _searchCriteria;
		string_1 = _orderType;
		orderOnHoldTime = 0;
		FulfillmentDate = null;
	}

	private void frmCustomersMini_Load(object sender, EventArgs e)
	{
		int_0 = 0;
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstCustomers.SmallImageList = imageList;
		method_10();
		if (!string.IsNullOrEmpty(string_0))
		{
			btnDuplicate.Enabled = false;
			((Control)(object)txtCell).Text = string_0;
			method_5();
			if (lstCustomers.Items.Count == 0 && ((Control)(object)txtCell).Text == MemoryLoadedObjects.callerID.Number)
			{
				((Control)(object)txtName).Text = MemoryLoadedObjects.callerID.Name.ToUpper();
			}
		}
	}

	private bool method_3()
	{
		if (string_1 == OrderTypes.Delivery && ((Control)(object)txtAddress).Text == string.Empty)
		{
			btnShowKeyboard_Address_Click(btnShowKeyboard_Address, null);
			if (((Control)(object)txtAddress).Text == string.Empty)
			{
				new NotificationLabel(this, "Address is required for delivery orders.", NotificationTypes.Notification).Show();
				return false;
			}
			return true;
		}
		return true;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		bool_0 = true;
		if (!method_3())
		{
			return;
		}
		if (!bool_1)
		{
			if (bool_0 && method_4())
			{
				returnCell = ((Control)(object)txtCell).Text;
				returnName = ((Control)(object)txtName).Text;
				returnEmail = ((Control)(object)txtEmail).Text;
				returnAddress = ((Control)(object)txtAddress).Text;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.None;
			}
		}
		else
		{
			method_4();
			string address = ((string_1 == OrderTypes.Delivery) ? ((Control)(object)txtAddress).Text : string.Empty);
			MemoryLoadedObjects.OrderEntry.ChangeToDeliveryTakeout(((Control)(object)txtName).Text, ((Control)(object)txtCell).Text, address, string_1);
			base.DialogResult = DialogResult.Yes;
		}
		btnCancel.Enabled = true;
	}

	private bool method_4(DateTime? nullable_0 = null, DateTime? nullable_1 = null)
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (((Control)(object)txtCell).Text == string.Empty)
		{
			new NotificationLabel(this, "Phone number is required.", NotificationTypes.Notification).Show();
			return false;
		}
		if (!string.IsNullOrEmpty(((Control)(object)txtEmail).Text) && !Regex.IsMatch(((Control)(object)txtEmail).Text, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase))
		{
			new frmMessageBox(Resources.E_mail_address_is_not_in_corre).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return false;
		}
		string text = ((Control)(object)txtCell).Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		CS_0024_003C_003E8__locals0.queryCellPhone = ((text == "" || text == null) ? "XXXXXXXXXXX0" : text);
		string text2 = ((Control)(object)txtEmail).Text;
		CS_0024_003C_003E8__locals0.queryCustomerEmail = ((text2 == "" || text2 == null) ? "XXXXXXXXXXXXX" : text2);
		Customer customer;
		if (int_0 == 0)
		{
			customer = gclass6_0.Customers.Where((Customer a) => (a.CustomerCell == CS_0024_003C_003E8__locals0.queryCellPhone || a.CustomerEmail == CS_0024_003C_003E8__locals0.queryCustomerEmail) && a.CustomerID != int_0).FirstOrDefault();
			if (customer != null)
			{
				int_0 = customer.CustomerID;
			}
			else
			{
				customer = new Customer();
				customer.LoyaltyCardNo = string.Empty;
				customer.EmployeeID = (((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] == 0) ? 1 : ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]));
				customer.CustomerHome = string.Empty;
				customer.Comments = string.Empty;
				customer.MemberNumber = string.Empty;
				customer.DateCreated = DateTime.Now;
				gclass6_0.Customers.InsertOnSubmit(customer);
			}
		}
		else
		{
			customer = gclass6_0.Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
		}
		customer.CustomerName = ((Control)(object)txtName).Text.Trim();
		customer.CustomerCell = ((Control)(object)txtCell).Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		customer.CustomerEmail = ((Control)(object)txtEmail).Text;
		customer.LastModified = DateTime.Now;
		customer.Active = true;
		customer.LastModified = DateTime.Now;
		if (!string.IsNullOrEmpty(((Control)(object)txtAddress).Text) && string_1 == OrderTypes.Delivery)
		{
			TravelInfo totalDistanceFromDeliveryAddress = GoogleMethods.GetTotalDistanceFromDeliveryAddress(((Control)(object)txtAddress).Text);
			if (totalDistanceFromDeliveryAddress.Distance > 0m && totalDistanceFromDeliveryAddress.TravelTime > 0)
			{
				customer.DeliveryTravelDistanceKM = totalDistanceFromDeliveryAddress.Distance;
				customer.DeliveryTravelTimeMinutes = totalDistanceFromDeliveryAddress.TravelTime;
			}
		}
		else if (string.IsNullOrEmpty(((Control)(object)txtAddress).Text))
		{
			customer.DeliveryTravelDistanceKM = null;
			customer.DeliveryTravelTimeMinutes = 0;
		}
		customer.Address = ((Control)(object)txtAddress).Text.Trim();
		Helper.SubmitChangesWithCatch(gclass6_0);
		int_0 = customer.CustomerID;
		return true;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Hide();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		lstCustomers.SelectedIndices.Clear();
		method_8();
		((Control)(object)txtCell).Text = string_0;
	}

	private void method_5()
	{
		list_2.Clear();
		GClass6 gClass = new GClass6();
		if (string.IsNullOrEmpty(string_0) || string_0.Length <= 3)
		{
			return;
		}
		List<Customer> source = gClass.Customers.Where((Customer c) => (c.CustomerCell != null && c.CustomerCell.Contains(string_0)) || (c.CustomerHome != null && c.CustomerHome.Contains(string_0))).ToList();
		list_3 = (from x in (from x in source
				orderby (x.CustomerCell + x.CustomerHome).Length
				select x into a
				orderby a.LastModified descending
				select a).Take(10)
			select new GlobalOrderHistoryObjects.CustomerInfo
			{
				customer_address = x.Address,
				customer_cell = x.CustomerCell,
				customer_email = x.CustomerEmail,
				customer_home = x.CustomerHome,
				customer_id = x.CustomerID,
				customer_name = x.CustomerName,
				last_modified = (x.LastModified.HasValue ? x.LastModified.Value : x.DateCreated)
			}).ToList();
		if (SettingsHelper.hasGlobalOrderHistoryAddOn && string_0.Length >= 10)
		{
			_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass39_0();
			if (string.IsNullOrEmpty(string_2))
			{
				string_2 = gClass.Settings.Where((Setting s) => s.Key == "cloudsync_api_key").FirstOrDefault().Value;
			}
			CS_0024_003C_003E8__locals3.response = method_6(string_0);
			if (CS_0024_003C_003E8__locals3.response != null && CS_0024_003C_003E8__locals3.response.orders != null && CS_0024_003C_003E8__locals3.response.customer_info != null)
			{
				_003C_003Ec__DisplayClass39_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass39_1();
				CS_0024_003C_003E8__locals3.response.orders.ForEach(delegate(GlobalOrderHistoryObjects.Order a)
				{
					a.date_created = a.date_paid;
				});
				list_2 = CS_0024_003C_003E8__locals3.response.orders;
				CS_0024_003C_003E8__locals4.customer = (from a in source.Where(delegate(Customer x)
					{
						if (x.CustomerCell != null && x.CustomerCell == CS_0024_003C_003E8__locals3.response.customer_info.customer_cell)
						{
							return true;
						}
						return x.CustomerHome != null && x.CustomerHome == CS_0024_003C_003E8__locals3.response.customer_info.customer_home;
					})
					orderby a.LastModified descending
					select a).FirstOrDefault();
				if (CS_0024_003C_003E8__locals4.customer == null)
				{
					CS_0024_003C_003E8__locals4.customer = new Customer
					{
						Active = true,
						Address = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_address == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_address),
						CustomerCell = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_cell == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_cell),
						CustomerEmail = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_email == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_email),
						CustomerHome = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_home == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_home),
						CustomerName = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_name == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_name),
						DateCreated = DateTime.Now,
						LoyaltyCardNo = string.Empty,
						EmployeeID = (((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] == 0) ? 1 : ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"])),
						Comments = string.Empty,
						MemberNumber = string.Empty,
						LastModified = DateTime.Now,
						Synced = false
					};
					gClass.Customers.InsertOnSubmit(CS_0024_003C_003E8__locals4.customer);
					gClass.SubmitChanges();
					CS_0024_003C_003E8__locals3.response.customer_info.customer_id = CS_0024_003C_003E8__locals4.customer.CustomerID;
					list_3.Add(CS_0024_003C_003E8__locals3.response.customer_info);
				}
				else if (CS_0024_003C_003E8__locals4.customer.LastModified < CS_0024_003C_003E8__locals3.response.customer_info.last_modified)
				{
					CS_0024_003C_003E8__locals4.customer.Address = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_address == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_address);
					CS_0024_003C_003E8__locals4.customer.CustomerCell = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_cell == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_cell);
					CS_0024_003C_003E8__locals4.customer.CustomerEmail = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_email == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_email);
					CS_0024_003C_003E8__locals4.customer.CustomerHome = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_home == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_home);
					CS_0024_003C_003E8__locals4.customer.CustomerName = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_name == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_name);
					CS_0024_003C_003E8__locals4.customer.LastModified = CS_0024_003C_003E8__locals3.response.customer_info.last_modified;
					CS_0024_003C_003E8__locals4.customer.Synced = false;
					gClass.SubmitChanges();
					GlobalOrderHistoryObjects.CustomerInfo customerInfo = list_3.Where((GlobalOrderHistoryObjects.CustomerInfo a) => a.customer_id == CS_0024_003C_003E8__locals4.customer.CustomerID).FirstOrDefault();
					if (customerInfo != null)
					{
						customerInfo.customer_name = CS_0024_003C_003E8__locals4.customer.CustomerName;
						customerInfo.customer_address = CS_0024_003C_003E8__locals4.customer.Address;
						customerInfo.customer_cell = CS_0024_003C_003E8__locals4.customer.CustomerCell;
						customerInfo.customer_home = CS_0024_003C_003E8__locals4.customer.CustomerHome;
						customerInfo.customer_email = CS_0024_003C_003E8__locals4.customer.CustomerEmail;
						customerInfo.last_modified = (CS_0024_003C_003E8__locals4.customer.LastModified.HasValue ? CS_0024_003C_003E8__locals4.customer.LastModified.Value : DateTime.Now);
					}
				}
				foreach (GlobalOrderHistoryObjects.CustomerInfo item2 in list_3)
				{
					string text = string.Empty;
					if (!string.IsNullOrEmpty(item2.customer_cell))
					{
						text = Resources.Cell + item2.customer_cell + " / " + Resources.Home + item2.customer_home;
					}
					ListViewItem value = new ListViewItem(new string[4]
					{
						item2.customer_name,
						text,
						item2.customer_address,
						item2.customer_id.ToString()
					});
					lstCustomers.Items.Add(value);
				}
			}
			if (list_2 == null)
			{
				list_2 = new List<GlobalOrderHistoryObjects.Order>();
			}
			CS_0024_003C_003E8__locals3.custIDs = list_3.Select((GlobalOrderHistoryObjects.CustomerInfo x) => x.customer_id).ToList();
			List<Order> list = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && x.CustomerID != null && CS_0024_003C_003E8__locals3.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && !x.ShareItemID.HasValue).ToList();
			List<Order> source2 = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && x.CustomerID != null && CS_0024_003C_003E8__locals3.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && x.ShareItemID.HasValue).ToList();
			if (list.Count() > 0)
			{
				list.Select((Order a) => a.OrderId).ToList();
				List<Guid> list2 = source2.Select((Order a) => a.ShareItemID.Value).ToList();
				List<GlobalOrderHistoryObjects.Order> list3 = new List<GlobalOrderHistoryObjects.Order>();
				using (List<Order>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass39_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_2();
						CS_0024_003C_003E8__locals0.x = enumerator2.Current;
						if (!list_2.Select((GlobalOrderHistoryObjects.Order a) => a.order_number).Contains(CS_0024_003C_003E8__locals0.x.OrderNumber))
						{
							GlobalOrderHistoryObjects.Order item = new GlobalOrderHistoryObjects.Order
							{
								combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
								customer_phone = CS_0024_003C_003E8__locals0.x.CustomerInfoPhone,
								date_created = (CS_0024_003C_003E8__locals0.x.LastDateModified.HasValue ? CS_0024_003C_003E8__locals0.x.LastDateModified.Value : CS_0024_003C_003E8__locals0.x.DateCreated.Value),
								date_paid = CS_0024_003C_003E8__locals0.x.DatePaid.Value,
								item_barcode = CS_0024_003C_003E8__locals0.x.ItemBarcode,
								item_id = CS_0024_003C_003E8__locals0.x.ItemID,
								item_identifier = (byte)((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "MainItem") ? 1 : ((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "ChildItem") ? 2 : 3)),
								item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
								item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
								item_name = CS_0024_003C_003E8__locals0.x.ItemName,
								item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)((list2.Count <= 0) ? 1 : (list2.Where((Guid a) => a == CS_0024_003C_003E8__locals0.x.OrderId).Count() + 1)),
								option_group_name = CS_0024_003C_003E8__locals0.x.ItemOptionId.ToString(),
								option_tab = "###",
								order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
							};
							list3.Add(item);
						}
					}
				}
				if (list3.Count > 0)
				{
					list_2.AddRange(list3);
					list_2 = (from x in list_2
						orderby x.date_created, x.combo_id
						select x).ToList();
				}
			}
		}
		else if (list_3.Count() > 0)
		{
			_003C_003Ec__DisplayClass39_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass39_3();
			foreach (GlobalOrderHistoryObjects.CustomerInfo item3 in list_3)
			{
				string text2 = string.Empty;
				if (!string.IsNullOrEmpty(item3.customer_cell))
				{
					text2 = Resources.Cell + item3.customer_cell + " / " + Resources.Home + item3.customer_home;
				}
				ListViewItem value2 = new ListViewItem(new string[4]
				{
					item3.customer_name,
					text2,
					item3.customer_address,
					item3.customer_id.ToString()
				});
				lstCustomers.Items.Add(value2);
			}
			CS_0024_003C_003E8__locals1.custIDs = list_3.Select((GlobalOrderHistoryObjects.CustomerInfo x) => x.customer_id).ToList();
			List<Order> source3 = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && CS_0024_003C_003E8__locals1.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && !x.ShareItemID.HasValue).ToList();
			List<Order> source4 = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && CS_0024_003C_003E8__locals1.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && x.ShareItemID.HasValue).ToList();
			if (source3.Count() > 0)
			{
				_003C_003Ec__DisplayClass39_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass39_4();
				source3.Select((Order a) => a.OrderId).ToList();
				CS_0024_003C_003E8__locals2.sharedOrderIDs = source4.Select((Order a) => a.ShareItemID.Value).ToList();
				list_2 = (from x in source3.Select(delegate(Order x)
					{
						_003C_003Ec__DisplayClass39_5 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_5();
						CS_0024_003C_003E8__locals0.x = x;
						return new GlobalOrderHistoryObjects.Order
						{
							combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
							customer_phone = CS_0024_003C_003E8__locals0.x.CustomerInfoPhone,
							date_created = (CS_0024_003C_003E8__locals0.x.LastDateModified.HasValue ? CS_0024_003C_003E8__locals0.x.LastDateModified.Value : CS_0024_003C_003E8__locals0.x.DateCreated.Value),
							date_paid = CS_0024_003C_003E8__locals0.x.DatePaid.Value,
							item_barcode = CS_0024_003C_003E8__locals0.x.ItemBarcode,
							item_id = CS_0024_003C_003E8__locals0.x.ItemID,
							item_identifier = (byte)((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "MainItem") ? 1 : ((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "ChildItem") ? 2 : 3)),
							item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
							item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
							item_name = CS_0024_003C_003E8__locals0.x.ItemName,
							item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)((CS_0024_003C_003E8__locals2.sharedOrderIDs.Count <= 0) ? 1 : (CS_0024_003C_003E8__locals2.sharedOrderIDs.Where((Guid a) => a == CS_0024_003C_003E8__locals0.x.OrderId).Count() + 1)),
							option_group_name = CS_0024_003C_003E8__locals0.x.ItemOptionId.ToString(),
							option_tab = "###",
							order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
						};
					})
					orderby x.date_created
					select x).ThenBy((GlobalOrderHistoryObjects.Order a) => a.combo_id).ToList();
			}
		}
		else
		{
			((Control)(object)txtCell).Text = string_0;
		}
		if (lstCustomers.Items.Count == 1 && string_0.Length >= 10)
		{
			lstCustomers.Items[0].Selected = true;
		}
	}

	private GlobalOrderHistoryObjects.Response method_6(string string_7)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		GlobalOrderHistoryObjects.Response result = new GlobalOrderHistoryObjects.Response();
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DebugSettings.readyOnlyAPIServer + "getorderhistory");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			httpWebRequest.Proxy = null;
			GlobalOrderHistoryObjects.Request request = new GlobalOrderHistoryObjects.Request
			{
				phone_number = string_7,
				token = string_2
			};
			httpWebRequest.Timeout = 10000;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)request, (Formatting)1, val);
				streamWriter.Write(value);
			}
			try
			{
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				result = JsonConvert.DeserializeObject<GlobalOrderHistoryObjects.Response>(streamReader.ReadToEnd());
				return result;
			}
			catch (Exception ex)
			{
				new NotificationLabel(this, ex.Message, NotificationTypes.Warning).Show();
				return result;
			}
		}
		return result;
	}

	private void method_7(Customer customer_0)
	{
		((Control)(object)txtCell).Text = customer_0.CustomerCell;
		((Control)(object)txtEmail).Text = customer_0.CustomerEmail;
		((Control)(object)txtName).Text = customer_0.CustomerName;
		((Control)(object)txtAddress).Text = customer_0.Address;
		btnCancel.Enabled = true;
	}

	private void method_8()
	{
		int_0 = 0;
		bool_0 = true;
		((Control)(object)txtCell).Text = string.Empty;
		((Control)(object)txtEmail).Text = string.Empty;
		((Control)(object)txtName).Text = string.Empty;
		((Control)(object)txtAddress).Text = string.Empty;
		btnDuplicate.Enabled = false;
	}

	private void method_9(object sender, EventArgs e)
	{
		int_0 = 0;
		btnCancel.Enabled = false;
		method_8();
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Name0, 0, 50, ((Control)(object)txtName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtName).Text = MemoryLoadedObjects.Keyboard.textEntered;
			bool_0 = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Cell_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Cellphone_No, 0, 10, ((Control)(object)txtCell).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtCell).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			bool_0 = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Email_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Email, 1, 128, ((Control)(object)txtEmail).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtEmail).Text = MemoryLoadedObjects.Keyboard.textEntered;
			bool_0 = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_10()
	{
		lstCustomers.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 2.0);
		lstCustomers.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 5.0);
		lstCustomers.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 5.0);
	}

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstCustomers.SelectedIndices.Count <= 0)
		{
			return;
		}
		lstOrderHistory.Items.Clear();
		lstItems.Items.Clear();
		if (lstCustomers.SelectedItems[0].SubItems.Count <= 1)
		{
			return;
		}
		bool_0 = false;
		if (lstCustomers.SelectedItems[0].SubItems[3].Text == string.Empty)
		{
			int_0 = 0;
		}
		else
		{
			int_0 = Convert.ToInt32(lstCustomers.SelectedItems[0].SubItems[3].Text);
		}
		if (int_0 > 0)
		{
			_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.cus = gClass.Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
			if (CS_0024_003C_003E8__locals0.cus != null)
			{
				method_7(CS_0024_003C_003E8__locals0.cus);
				btnCancel.Enabled = true;
				var enumerable = (from x in list_2
					where x.customer_phone == CS_0024_003C_003E8__locals0.cus.CustomerHome || x.customer_phone == CS_0024_003C_003E8__locals0.cus.CustomerCell
					group x by x.order_number into a
					select new
					{
						OrderNumber = a.Key,
						DateCreated = a.FirstOrDefault().date_paid
					} into x
					orderby x.DateCreated descending
					select x).Take(10);
				if (enumerable.Count() > 0)
				{
					foreach (var item in enumerable)
					{
						ListViewItem value = new ListViewItem(new string[2]
						{
							item.DateCreated.ToShortDateString(),
							item.OrderNumber
						});
						lstOrderHistory.Items.Add(value);
					}
					lstOrderHistory.Items[0].Selected = true;
					btnDuplicate.Enabled = true;
				}
				else
				{
					btnDuplicate.Enabled = false;
				}
			}
			else
			{
				btnDuplicate.Enabled = false;
			}
		}
		else
		{
			method_8();
			btnDuplicate.Enabled = false;
		}
	}

	private void btnShowKeyboard_Address_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Address, 0, 255, ((Control)(object)txtAddress).Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtAddress).Text = MemoryLoadedObjects.Keyboard.textEntered;
			bool_0 = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnDuplicate_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (!method_3())
		{
			return;
		}
		CS_0024_003C_003E8__locals0.selected_order = lstOrderHistory.SelectedItems[0].SubItems[1].Text;
		List<GlobalOrderHistoryObjects.Order> list = (from o in list_2
			where o.order_number == CS_0024_003C_003E8__locals0.selected_order
			select o into x
			orderby x.date_created
			select x).ThenBy((GlobalOrderHistoryObjects.Order a) => a.combo_id).ToList();
		if (list.Count() <= 0)
		{
			return;
		}
		foreach (GlobalOrderHistoryObjects.Order item in list.Where((GlobalOrderHistoryObjects.Order x) => x.option_tab == "###" && x.option_group_name != string.Empty))
		{
			_003C_003Ec__DisplayClass51_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass51_1();
			CS_0024_003C_003E8__locals1.iwoID = 0;
			int.TryParse(item.option_group_name, out CS_0024_003C_003E8__locals1.iwoID);
			if (CS_0024_003C_003E8__locals1.iwoID > 0)
			{
				usp_ItemOptionsResult usp_ItemOptionsResult = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals1.iwoID).FirstOrDefault();
				if (usp_ItemOptionsResult != null)
				{
					item.option_group_name = usp_ItemOptionsResult.GroupName;
					item.option_tab = usp_ItemOptionsResult.Tab;
				}
				else
				{
					item.option_group_name = null;
					item.option_tab = null;
				}
			}
			else
			{
				item.option_group_name = null;
				item.option_tab = null;
			}
		}
		customerInfo_0 = list_3.Where((GlobalOrderHistoryObjects.CustomerInfo x) => x.customer_id == CS_0024_003C_003E8__locals0._003C_003E4__this.int_0).FirstOrDefault();
		if (customerInfo_0 != null)
		{
			string newOrderNumber = OrderMethods.GetNewOrderNumber();
			OrderHelper.DuplicateOrder(list, customerInfo_0, newOrderNumber, string_1, Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()), (string_1 == OrderTypes.Delivery) ? true : false, orderOnHoldTime, FulfillmentDate);
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
			MemoryLoadedObjects.OrderEntry.LoadFormData(newOrderNumber, ((Control)(object)txtCell).Text, string_1, 0, int_0, ((Control)(object)txtName).Text, (string_1 == OrderTypes.Delivery) ? ((Control)(object)txtAddress).Text : string.Empty, resetComboId: true, 1);
			base.DialogResult = DialogResult.Ignore;
			Close();
		}
		else
		{
			new NotificationLabel(this, "Please select a customer to duplicate the order.", NotificationTypes.Notification).Show();
		}
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void lstOrderHistory_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstOrderHistory.SelectedItems.Count <= 0)
		{
			return;
		}
		lstItems.Items.Clear();
		foreach (GlobalOrderHistoryObjects.Order item in (from order_0 in list_2
			where order_0.order_number == lstOrderHistory.SelectedItems[0].SubItems[1].Text
			select order_0 into x
			orderby x.date_paid, x.combo_id
			select x).ThenBy((GlobalOrderHistoryObjects.Order z) => z.item_identifier).ToList())
		{
			ListViewItem listViewItem = new ListViewItem(new string[2]
			{
				MathHelper.DecimalToFraction(item.item_qty),
				item.item_name
			});
			if (item.item_identifier_string == "MainItem")
			{
				listViewItem.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
			}
			else
			{
				listViewItem.Font = new Font("Microsoft Sans Serif", 8.75f, FontStyle.Regular);
				if (item.item_identifier_string == "OptionItem")
				{
					listViewItem.ForeColor = Color.DarkRed;
				}
			}
			lstItems.Items.Add(listViewItem);
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
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCustomersMini));
		lblWIndowTitle = new Label();
		pnlMain = new Panel();
		lblTrainingMode = new Label();
		label1 = new Label();
		lstOrderHistory = new ListView();
		columnHeader_3 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		btnDuplicate = new Button();
		txtAddress = new RadTextBoxControl();
		btnShowKeyboard_Address = new Button();
		label4 = new Label();
		txtEmail = new RadTextBoxControl();
		txtCell = new RadTextBoxControl();
		txtName = new RadTextBoxControl();
		btnShowKeyboard_Email = new Button();
		lstCustomers = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		btnShowKeyboard_Cell = new Button();
		btnShowKeyboard_Name = new Button();
		lblName = new Label();
		lblCellPhone = new Label();
		btnClose = new Button();
		btnSave = new Button();
		lblEmail = new Label();
		btnCancel = new Button();
		lblMemberInfo = new Label();
		label8 = new Label();
		label7 = new Label();
		lstItems = new ListView();
		columnHeader_5 = new ColumnHeader();
		columnHeader_6 = new ColumnHeader();
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtAddress).BeginInit();
		((ISupportInitialize)txtEmail).BeginInit();
		((ISupportInitialize)txtCell).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(PersistentNotification, "PersistentNotification");
		lblWIndowTitle.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblWIndowTitle, "lblWIndowTitle");
		lblWIndowTitle.ForeColor = Color.White;
		lblWIndowTitle.Name = "lblWIndowTitle";
		pnlMain.BackColor = Color.FromArgb(35, 39, 56);
		pnlMain.Controls.Add(lblTrainingMode);
		pnlMain.Controls.Add(label1);
		pnlMain.Controls.Add(lstOrderHistory);
		pnlMain.Controls.Add(btnDuplicate);
		pnlMain.Controls.Add((Control)(object)txtAddress);
		pnlMain.Controls.Add(btnShowKeyboard_Address);
		pnlMain.Controls.Add(label4);
		pnlMain.Controls.Add((Control)(object)txtEmail);
		pnlMain.Controls.Add((Control)(object)txtCell);
		pnlMain.Controls.Add((Control)(object)txtName);
		pnlMain.Controls.Add(btnShowKeyboard_Email);
		pnlMain.Controls.Add(lstCustomers);
		pnlMain.Controls.Add(btnShowKeyboard_Cell);
		pnlMain.Controls.Add(btnShowKeyboard_Name);
		pnlMain.Controls.Add(lblName);
		pnlMain.Controls.Add(lblCellPhone);
		pnlMain.Controls.Add(btnClose);
		pnlMain.Controls.Add(btnSave);
		pnlMain.Controls.Add(lblEmail);
		pnlMain.Controls.Add(btnCancel);
		pnlMain.Controls.Add(lblMemberInfo);
		componentResourceManager.ApplyResources(pnlMain, "pnlMain");
		pnlMain.Name = "pnlMain";
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		label1.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.Tag = "2,0";
		lstOrderHistory.BackColor = Color.White;
		lstOrderHistory.BorderStyle = BorderStyle.None;
		lstOrderHistory.Columns.AddRange(new ColumnHeader[2] { columnHeader_3, columnHeader_4 });
		componentResourceManager.ApplyResources(lstOrderHistory, "lstOrderHistory");
		lstOrderHistory.FullRowSelect = true;
		lstOrderHistory.GridLines = true;
		lstOrderHistory.HeaderStyle = ColumnHeaderStyle.None;
		lstOrderHistory.HideSelection = false;
		lstOrderHistory.MultiSelect = false;
		lstOrderHistory.Name = "lstOrderHistory";
		lstOrderHistory.Tag = "5,5";
		lstOrderHistory.TileSize = new Size(50, 200);
		lstOrderHistory.UseCompatibleStateImageBehavior = false;
		lstOrderHistory.View = View.Details;
		lstOrderHistory.SelectedIndexChanged += lstOrderHistory_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_3, "columnHeader1");
		componentResourceManager.ApplyResources(columnHeader_4, "columnHeader2");
		componentResourceManager.ApplyResources(btnDuplicate, "btnDuplicate");
		btnDuplicate.BackColor = Color.FromArgb(176, 124, 219);
		btnDuplicate.FlatAppearance.BorderColor = Color.Black;
		btnDuplicate.FlatAppearance.BorderSize = 0;
		btnDuplicate.ForeColor = Color.White;
		btnDuplicate.Name = "btnDuplicate";
		btnDuplicate.UseVisualStyleBackColor = false;
		btnDuplicate.Click += btnDuplicate_Click;
		componentResourceManager.ApplyResources(txtAddress, "txtAddress");
		((Control)(object)txtAddress).ForeColor = Color.FromArgb(40, 40, 40);
		txtAddress.set_Multiline(true);
		((Control)(object)txtAddress).Name = "txtAddress";
		((RadElement)((RadControl)txtAddress).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtAddress).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtAddress).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtAddress).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Address.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Address.DialogResult = DialogResult.OK;
		btnShowKeyboard_Address.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Address.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Address, "btnShowKeyboard_Address");
		btnShowKeyboard_Address.ForeColor = Color.White;
		btnShowKeyboard_Address.Name = "btnShowKeyboard_Address";
		btnShowKeyboard_Address.Tag = "5,5";
		btnShowKeyboard_Address.UseVisualStyleBackColor = false;
		btnShowKeyboard_Address.Click += btnShowKeyboard_Address_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label4.Tag = "5,5";
		componentResourceManager.ApplyResources(txtEmail, "txtEmail");
		((Control)(object)txtEmail).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtEmail).Name = "txtEmail";
		((RadElement)((RadControl)txtEmail).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtEmail).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtEmail).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtEmail).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtCell, "txtCell");
		((Control)(object)txtCell).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCell).Name = "txtCell";
		((RadElement)((RadControl)txtCell).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtCell).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCell).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCell).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtName, "txtName");
		((Control)(object)txtName).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtName).Name = "txtName";
		((RadElement)((RadControl)txtName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtName).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Email.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Email.DialogResult = DialogResult.OK;
		btnShowKeyboard_Email.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Email.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Email, "btnShowKeyboard_Email");
		btnShowKeyboard_Email.ForeColor = Color.White;
		btnShowKeyboard_Email.Name = "btnShowKeyboard_Email";
		btnShowKeyboard_Email.Tag = "5,5";
		btnShowKeyboard_Email.UseVisualStyleBackColor = false;
		btnShowKeyboard_Email.Click += btnShowKeyboard_Email_Click;
		lstCustomers.BackColor = Color.White;
		lstCustomers.BorderStyle = BorderStyle.None;
		lstCustomers.Columns.AddRange(new ColumnHeader[3] { columnHeader_0, columnHeader_1, columnHeader_2 });
		componentResourceManager.ApplyResources(lstCustomers, "lstCustomers");
		lstCustomers.FullRowSelect = true;
		lstCustomers.GridLines = true;
		lstCustomers.HeaderStyle = ColumnHeaderStyle.None;
		lstCustomers.HideSelection = false;
		lstCustomers.MultiSelect = false;
		lstCustomers.Name = "lstCustomers";
		lstCustomers.Tag = "5,5";
		lstCustomers.TileSize = new Size(50, 200);
		lstCustomers.UseCompatibleStateImageBehavior = false;
		lstCustomers.View = View.Details;
		lstCustomers.SelectedIndexChanged += lstCustomers_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "CustomerNameTitle");
		componentResourceManager.ApplyResources(columnHeader_1, "Phone");
		componentResourceManager.ApplyResources(columnHeader_2, "Address");
		btnShowKeyboard_Cell.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Cell.DialogResult = DialogResult.OK;
		btnShowKeyboard_Cell.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Cell.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Cell, "btnShowKeyboard_Cell");
		btnShowKeyboard_Cell.ForeColor = Color.White;
		btnShowKeyboard_Cell.Name = "btnShowKeyboard_Cell";
		btnShowKeyboard_Cell.Tag = "5,5";
		btnShowKeyboard_Cell.UseVisualStyleBackColor = false;
		btnShowKeyboard_Cell.Click += btnShowKeyboard_Cell_Click;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.Tag = "5,5";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		lblName.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblName, "lblName");
		lblName.ForeColor = Color.White;
		lblName.Name = "lblName";
		lblName.Tag = "5,5";
		lblCellPhone.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblCellPhone, "lblCellPhone");
		lblCellPhone.ForeColor = Color.White;
		lblCellPhone.Name = "lblCellPhone";
		lblCellPhone.Tag = "5,5";
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.Tag = "5,5";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.Tag = "5,5";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		lblEmail.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblEmail, "lblEmail");
		lblEmail.ForeColor = Color.White;
		lblEmail.Name = "lblEmail";
		lblEmail.Tag = "5,5";
		btnCancel.BackColor = Color.SandyBrown;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.Tag = "5,5";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		lblMemberInfo.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblMemberInfo, "lblMemberInfo");
		lblMemberInfo.ForeColor = Color.White;
		lblMemberInfo.Name = "lblMemberInfo";
		lblMemberInfo.Tag = "2,0";
		label8.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label7.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[2] { columnHeader_5, columnHeader_6 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_5, "ItemQty");
		componentResourceManager.ApplyResources(columnHeader_6, "ItemName");
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(label8);
		base.Controls.Add(label7);
		base.Controls.Add(lstItems);
		base.Controls.Add(lblWIndowTitle);
		base.Controls.Add(pnlMain);
		base.Name = "frmCustomersMini";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.TopMost = true;
		base.Load += frmCustomersMini_Load;
		base.Controls.SetChildIndex(pnlMain, 0);
		base.Controls.SetChildIndex(lblWIndowTitle, 0);
		base.Controls.SetChildIndex(lstItems, 0);
		base.Controls.SetChildIndex(label7, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlMain.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtAddress).EndInit();
		((ISupportInitialize)txtEmail).EndInit();
		((ISupportInitialize)txtCell).EndInit();
		((ISupportInitialize)txtName).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_11(GlobalOrderHistoryObjects.Order order_0)
	{
		return order_0.order_number == lstOrderHistory.SelectedItems[0].SubItems[1].Text;
	}
}
