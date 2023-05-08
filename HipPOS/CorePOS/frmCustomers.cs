using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.CommonForms;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmCustomers : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public frmCustomers _003C_003E4__this;

		public string queryHomePhone;

		public string queryCellPhone;

		public string queryCustomerEmail;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public string keyword;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass35_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public string oldOrderNumber;

		public List<Order> orders;

		public Func<usp_ItemOptionsResult, bool> _003C_003E9__7;

		public _003C_003Ec__DisplayClass46_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnDuplicate_Click_003Eb__7(usp_ItemOptionsResult x)
		{
			return orders.Select((Order y) => y.ItemOptionId.Value).Contains(x.ItemWithOptionID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_1
	{
		public List<Guid> orderListIDs;

		public int billCount;

		public List<usp_ItemOptionsResult> iwos;

		public _003C_003Ec__DisplayClass46_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnDuplicate_Click_003Eb__5(Guid a)
		{
			return orderListIDs.FirstOrDefault() == a;
		}

		internal GlobalOrderHistoryObjects.Order _003CbtnDuplicate_Click_003Eb__8(Order x)
		{
			_003C_003Ec__DisplayClass46_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_2
			{
				x = x
			};
			return new GlobalOrderHistoryObjects.Order
			{
				combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
				customer_phone = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.x.CustomerInfoPhone) ? CS_0024_003C_003E8__locals0.x.Customer : CS_0024_003C_003E8__locals0.x.CustomerInfoPhone),
				date_paid = CS_0024_003C_003E8__locals0.x.LastDateModified.Value,
				item_barcode = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.x.ItemBarcode) ? MemoryLoadedData.all_items.Where((Item y) => y.ItemID == CS_0024_003C_003E8__locals0.x.ItemID).FirstOrDefault().Barcode : CS_0024_003C_003E8__locals0.x.ItemBarcode),
				item_id = CS_0024_003C_003E8__locals0.x.ItemID,
				item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
				item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
				item_name = CS_0024_003C_003E8__locals0.x.ItemName,
				item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)billCount,
				option_group_name = ((!CS_0024_003C_003E8__locals0.x.ItemOptionId.HasValue || CS_0024_003C_003E8__locals0.x.ItemOptionId.Value <= 0) ? null : ((iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault() != null) ? iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault().GroupName : null)),
				option_tab = ((!CS_0024_003C_003E8__locals0.x.ItemOptionId.HasValue || CS_0024_003C_003E8__locals0.x.ItemOptionId.Value <= 0) ? null : ((iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault() != null) ? iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault().Tab : null)),
				order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_2
	{
		public Order x;

		public _003C_003Ec__DisplayClass46_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnDuplicate_Click_003Eb__11(Item y)
		{
			return y.ItemID == x.ItemID;
		}

		internal bool _003CbtnDuplicate_Click_003Eb__12(usp_ItemOptionsResult y)
		{
			return y.ItemWithOptionID == x.ItemOptionId.Value;
		}

		internal bool _003CbtnDuplicate_Click_003Eb__13(usp_ItemOptionsResult y)
		{
			return y.ItemWithOptionID == x.ItemOptionId.Value;
		}

		internal bool _003CbtnDuplicate_Click_003Eb__14(usp_ItemOptionsResult y)
		{
			return y.ItemWithOptionID == x.ItemOptionId.Value;
		}

		internal bool _003CbtnDuplicate_Click_003Eb__15(usp_ItemOptionsResult y)
		{
			return y.ItemWithOptionID == x.ItemOptionId.Value;
		}
	}

	private int int_0;

	private string string_0;

	private string string_1;

	private GClass6 gclass6_0;

	private bool bool_0;

	private bool bool_1;

	private Form form_0;

	private bool bool_2;

	private bool bool_3;

	private IContainer icontainer_1;

	internal ListView lstItems;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Label lblSearchForMembers;

	private Label lblSearchResults;

	private Label lblName;

	private Label lblCellPhone;

	private Label lblMemberNo;

	internal Button btnClose;

	internal Button btnSave;

	private Label lblHomeNo;

	private Label lblEmail;

	private Label lblMemberInfo;

	internal Button btnCancel;

	internal Button btnSearch;

	private Label lblMembersNotes;

	private TextBox txtComments;

	internal Button btnNew;

	private ColumnHeader columnHeader_2;

	private Label lblTrainingMode;

	private Label lblIsActive;

	internal Button btnShowKeyboard_MemberNumber;

	internal Button btnShowKeyboard_Name;

	internal Button btnShowKeyboard_Cell;

	internal Button btnShowKeyboard_HomePhone;

	internal Button btnShowKeyboard_Email;

	private Panel pnlMain;

	private Label lblWIndowTitle;

	private RadToggleSwitch chkIsActive;

	private RadTextBoxControl txtEmail;

	private RadTextBoxControl txtHomePhone;

	private RadTextBoxControl txtCell;

	private RadTextBoxControl txtName;

	private RadTextBoxControl txtMemberNumber;

	internal Button btnShowKeyboard_SearchBox;

	private RadTextBoxControl txtSearchBox;

	private Label label1;

	private Label label2;

	internal Button btnPreview;

	private Label label3;

	internal ListView lstOrder;

	private ColumnHeader columnHeader_3;

	internal ColumnHeader columnHeader_4;

	internal ColumnHeader columnHeader_5;

	private RadTextBoxControl txtLoyaltyCardNo;

	internal Button btnShowKeyboard_LoyaltyCardNo;

	private Label label5;

	private RadTextBoxControl txtAddress;

	internal Button btnShowKeyboard_Address;

	private Label label4;

	internal Button btnCheckBalance;

	internal Button btnOrderEntry;

	internal Button btnSkip;

	private Class19 ddlYear;

	internal Button btnDuplicate;

	private ColumnHeader columnHeader_6;

	internal Button btnShowKeyboard_txtComments;

	public frmCustomers(Form _parentForm = null, string _orderNumber = null, string _searchCriteria = null, bool save_send = false, bool show_appointment_members = false, bool use_skip_button = false)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = ((SettingsHelper.GetSettingValueByKey("gift_card_payment") == "ON") ? true : false);
		bool_1 = ((SettingsHelper.GetSettingValueByKey("loyalty_card_payment") == "ON") ? true : false);
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		form_0 = _parentForm;
		string_1 = _searchCriteria;
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			chkIsActive.OffText = "NON";
			chkIsActive.OnText = "OUI";
		}
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		bool_3 = show_appointment_members;
		bool_2 = use_skip_button;
		string_0 = _orderNumber;
		if (!string.IsNullOrEmpty(string_0))
		{
			if (!save_send)
			{
				btnSave.Text = Resources.SAVE_ASSIGN;
			}
			else
			{
				btnSave.Text = Resources.SAVE_SEND;
			}
			label2.Location = new Point(598, 183);
		}
		if (!bool_0 && !bool_1)
		{
			btnCheckBalance.Enabled = false;
		}
		else if (bool_1 && bool_0)
		{
			btnCheckBalance.Text = "CHECK LOYALTY CARD BALANCE";
		}
		else if (!bool_1 && bool_0)
		{
			btnCheckBalance.Text = "CHECK GIFT CARD BALANCE";
		}
		else
		{
			btnCheckBalance.Text = "CHECK GIFT && LOYALTY CARD BALANCE";
		}
		for (int i = 2015; i <= DateTime.Now.Year; i++)
		{
			ddlYear.Items.Add(i.ToString());
		}
		ddlYear.SelectedIndex = ddlYear.Items.Count - 1;
	}

	private void frmCustomers_Load(object sender, EventArgs e)
	{
		int_0 = 0;
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstItems.SmallImageList = imageList;
		btnSearch.Enabled = false;
		method_8();
		if (!string.IsNullOrEmpty(string_0))
		{
			Order order = new GClass6().Orders.Where((Order o) => o.OrderNumber == string_0).FirstOrDefault();
			if (order != null && order.OrderType != OrderTypes.DineIn)
			{
				txtSearchBox.Text = order.Customer + " " + order.CustomerInfoName;
				method_4();
			}
		}
		else if (!string.IsNullOrEmpty(string_1))
		{
			txtSearchBox.Text = string_1;
			method_4();
		}
		if (int_0 <= 0)
		{
			btnOrderEntry.Enabled = false;
		}
		if (bool_2)
		{
			btnSkip.Visible = true;
			btnSkip.Location = btnOrderEntry.Location;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (method_3())
		{
			method_4();
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			base.DialogResult = DialogResult.None;
		}
		btnCancel.Enabled = true;
	}

	private bool method_3(DateTime? nullable_0 = null, DateTime? nullable_1 = null)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		List<string> list = new List<string>();
		if (!btnSave.Text.Contains(Resources.SEND))
		{
			if (txtName.Text == string.Empty)
			{
				list.Add("Name");
			}
			if (txtCell.Text == string.Empty)
			{
				list.Add("Cellphone");
			}
		}
		if (list.Count > 0)
		{
			new frmMessageBox(string.Join(Resources._and, list) + ((list.Count == 1) ? Resources._is_mandatory : Resources._are_mandatory)).ShowDialog(this);
			return false;
		}
		Regex regex = new Regex("^\\d{10}$");
		if (!string.IsNullOrEmpty(txtCell.Text) && !regex.Match(txtCell.Text).Success)
		{
			new frmMessageBox(Resources.Cell_phone_number_is_not_in_co).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return false;
		}
		if (!string.IsNullOrEmpty(txtHomePhone.Text) && !regex.Match(txtHomePhone.Text).Success)
		{
			new frmMessageBox(Resources.Home_phone_number_is_not_in_co).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return false;
		}
		if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase))
		{
			new frmMessageBox(Resources.E_mail_address_is_not_in_corre).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return false;
		}
		if (btnSave.Text.Contains(Resources.SEND) && !string.IsNullOrEmpty(string_0) && string.IsNullOrEmpty(txtEmail.Text.Trim()))
		{
			new frmMessageBox(Resources.E_mail_address_is_required).ShowDialog(this);
			base.DialogResult = DialogResult.None;
			return false;
		}
		GClass6 gClass = new GClass6();
		Customer customer = gClass.Customers.Where((Customer b) => b.MemberNumber == txtMemberNumber.Text.Trim() && b.CustomerID != int_0).FirstOrDefault();
		if (customer != null && txtMemberNumber.Text.Trim() != "")
		{
			new frmMessageBox(Resources.Customer + customer.CustomerName + Resources._already_has_the_same_Member_N, Resources.Customer_Duplicate, CustomMessageBoxButtons.Ok).Show();
			base.DialogResult = DialogResult.None;
			return false;
		}
		string text = txtHomePhone.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		CS_0024_003C_003E8__locals0.queryHomePhone = ((text == "" || text == null) ? "XXXXXXXXXXX" : text);
		string text2 = txtCell.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		CS_0024_003C_003E8__locals0.queryCellPhone = ((text2 == "" || text2 == null) ? "XXXXXXXXXXX0" : text2);
		string text3 = txtEmail.Text;
		CS_0024_003C_003E8__locals0.queryCustomerEmail = ((text3 == "" || text3 == null) ? "XXXXXXXXXXXXX" : text3);
		Customer customer2 = gClass.Customers.Where((Customer a) => ((a.CustomerHome == CS_0024_003C_003E8__locals0.queryHomePhone || a.CustomerCell == CS_0024_003C_003E8__locals0.queryCellPhone || a.CustomerEmail == CS_0024_003C_003E8__locals0.queryCustomerEmail) && a.CustomerID != int_0) || (a.LoyaltyCardNo != null && a.LoyaltyCardNo != string.Empty && a.LoyaltyCardNo == txtLoyaltyCardNo.Text.Trim() && a.CustomerID != int_0)).FirstOrDefault();
		if (customer2 != null)
		{
			new NotificationLabel(this, "Another customer (" + customer2.CustomerName + ")" + Resources._already_has_the_same_home_pho, NotificationTypes.Notification).Show();
			return false;
		}
		string text4 = txtHomePhone.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		string text5 = txtCell.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
			.Trim();
		string text6 = txtMemberNumber.Text.Trim();
		Customer customer3;
		if (int_0 == 0)
		{
			customer3 = new Customer();
			customer3.DateCreated = DateTime.Now;
			gClass.Customers.InsertOnSubmit(customer3);
		}
		else
		{
			customer3 = gClass.Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
			if (customer3.CustomerName != txtName.Text.Trim() && (customer3.CustomerHome != text4 || customer3.CustomerCell != text5))
			{
				if (!string.IsNullOrEmpty(customer3.MemberNumber) && customer3.MemberNumber == text6)
				{
					customer3.MemberNumber = "";
					Helper.SubmitChangesWithCatch(gClass);
				}
				customer3 = new Customer();
				customer3.DateCreated = DateTime.Now;
				gClass.Customers.InsertOnSubmit(customer3);
			}
		}
		customer3.MemberNumber = text6;
		customer3.CustomerName = txtName.Text.Trim();
		customer3.CustomerCell = text5;
		customer3.CustomerHome = text4;
		customer3.CustomerEmail = txtEmail.Text;
		customer3.Comments = txtComments.Text;
		customer3.Active = chkIsActive.Value;
		customer3.LastModified = DateTime.Now;
		customer3.LoyaltyCardNo = txtLoyaltyCardNo.Text.Trim();
		customer3.EmployeeID = (((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] == 0) ? 1 : ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]));
		if (!string.IsNullOrEmpty(txtAddress.Text) && customer3.Address != txtAddress.Text)
		{
			TravelInfo totalDistanceFromDeliveryAddress = GoogleMethods.GetTotalDistanceFromDeliveryAddress(txtAddress.Text);
			if (totalDistanceFromDeliveryAddress.Distance > 0m && totalDistanceFromDeliveryAddress.TravelTime > 0)
			{
				customer3.DeliveryTravelDistanceKM = totalDistanceFromDeliveryAddress.Distance;
				customer3.DeliveryTravelTimeMinutes = totalDistanceFromDeliveryAddress.TravelTime;
			}
		}
		else if (string.IsNullOrEmpty(txtAddress.Text))
		{
			customer3.DeliveryTravelDistanceKM = null;
			customer3.DeliveryTravelTimeMinutes = 0;
		}
		customer3.Address = txtAddress.Text.Trim();
		if (string.IsNullOrEmpty(string_0))
		{
			customer3.Synced = false;
		}
		Helper.SubmitChangesWithCatch(gClass);
		int_0 = customer3.CustomerID;
		if ((btnSave.Text.Contains(Resources.SAVE_SEND) || btnSave.Text.Contains(Resources.SAVE_ASSIGN)) && !string.IsNullOrEmpty(string_0))
		{
			gClass = new GClass6();
			IQueryable<Order> queryable = gClass.Orders.Where((Order o) => o.OrderNumber == string_0);
			if (queryable.Count() > 0)
			{
				CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
				string item = Resources.Hi + txtName.Text + Resources._br_br_Thank_you_for_shopping_ + companySetup.Name + Resources._As_you_have_requested_attache;
				foreach (Order item2 in queryable)
				{
					item2.CustomerID = int_0;
				}
				try
				{
					Helper.SubmitChangesWithCatch(gClass);
				}
				catch (Exception ex)
				{
					if (ex.Message.Contains("Row not found"))
					{
						new NotificationLabel(this, "Order is currently syncing to cloudsync please try to send the email again.", NotificationTypes.Notification).Show();
						return false;
					}
				}
				if (!string.IsNullOrEmpty(txtEmail.Text) && btnSave.Text.Contains(Resources.SAVE_SEND))
				{
					List<string> list2 = new List<string>();
					list2.Add(string_0);
					list2.Add(txtEmail.Text);
					list2.Add(item);
					frmLoading frmLoading = new frmLoading("SENDING EMAIL...", "sendEmail", list2);
					frmLoading.ShowDialog(this);
					if (frmLoading.DialogResult == DialogResult.OK)
					{
						new frmMessageBox(Resources.Customer_info_saved_receipt_se).ShowDialog(this);
						Close();
					}
					else
					{
						new frmMessageBox(Resources.An_error_occued_while_sending_the_email_please).ShowDialog(this);
					}
				}
				else
				{
					new NotificationLabel(this, Resources.Customer_info_saved, NotificationTypes.Success).Show();
					Close();
				}
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Customer_info_saved, NotificationTypes.Success).Show();
		}
		txtSearchBox.Text = customer3.CustomerName;
		if (int_0 <= 0)
		{
			btnOrderEntry.Enabled = false;
		}
		else
		{
			btnOrderEntry.Enabled = true;
		}
		return true;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Dispose(disposing: true);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_reset, Resources.Warning_Reset_Info, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes && int_0 > 0)
		{
			Customer customer = new GClass6().Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
			if (customer != null)
			{
				method_6(customer);
			}
		}
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		lstItems.Items.Clear();
		string[] array = txtSearchBox.Text.Trim().Split(' ');
		List<Customer> list = new List<Customer>();
		if (txtSearchBox.Text == Resources.Enter_Search_Criteria_Here || txtSearchBox.Text == "")
		{
			return;
		}
		GClass6 gClass = new GClass6();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
			CS_0024_003C_003E8__locals0.keyword = array2[i];
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.keyword))
			{
				continue;
			}
			foreach (Customer item in gClass.Customers.Where((Customer c) => c.Comments.Contains(CS_0024_003C_003E8__locals0.keyword) || c.CustomerCell.Contains(CS_0024_003C_003E8__locals0.keyword) || c.CustomerEmail.Contains(CS_0024_003C_003E8__locals0.keyword) || c.CustomerHome.Contains(CS_0024_003C_003E8__locals0.keyword) || c.CustomerName.Contains(CS_0024_003C_003E8__locals0.keyword) || c.MemberNumber.Contains(CS_0024_003C_003E8__locals0.keyword)).ToList())
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		if (list.Count() > 0)
		{
			List<CustomerSearchResults> list2 = new List<CustomerSearchResults>();
			int num = 0;
			foreach (Customer item2 in list)
			{
				num = 0;
				array2 = array;
				foreach (string value in array2)
				{
					if (!string.IsNullOrEmpty(value) && (item2.Comments + item2.CustomerCell + item2.CustomerEmail + item2.CustomerHome + item2.CustomerName + item2.MemberNumber).Contains(value))
					{
						num++;
					}
				}
				list2.Add(new CustomerSearchResults
				{
					CustomerCell = item2.CustomerCell,
					CustomerEmail = item2.CustomerEmail,
					CustomerHome = item2.CustomerHome,
					CustomerID = item2.CustomerID,
					CustomerName = item2.CustomerName,
					MemberNumber = item2.MemberNumber,
					total_matches = num
				});
			}
			foreach (CustomerSearchResults item3 in list2.OrderByDescending((CustomerSearchResults a) => a.total_matches).ThenBy((CustomerSearchResults c) => c.CustomerName))
			{
				string text = string.Empty;
				if (!string.IsNullOrEmpty(item3.CustomerCell))
				{
					text = Resources.Cell + item3.CustomerCell;
				}
				if (!string.IsNullOrEmpty(item3.CustomerEmail))
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += " / ";
					}
					text = text + Resources.E_mail + item3.CustomerEmail;
				}
				if (!string.IsNullOrEmpty(item3.CustomerHome))
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += " / ";
					}
					text = text + Resources.Home + item3.CustomerHome;
				}
				ListViewItem value2 = new ListViewItem(new string[4]
				{
					item3.MemberNumber,
					item3.CustomerName,
					text,
					item3.CustomerID.ToString()
				});
				lstItems.Items.Add(value2);
			}
			lstItems.Items[0].Selected = true;
			return;
		}
		ListViewItem value3 = new ListViewItem(new string[1] { Resources.No_results_found });
		lstItems.Items.Add(value3);
		GClass6 gClass2 = new GClass6();
		if (!string.IsNullOrEmpty(string_0))
		{
			Order order = gClass2.Orders.Where((Order o) => o.OrderNumber == string_0).FirstOrDefault();
			if (order != null && order.OrderType != OrderTypes.DineIn)
			{
				txtName.Text = order.CustomerInfoName;
				txtCell.Text = order.Customer;
			}
		}
	}

	private void method_5(IQueryable<Customer> iqueryable_0)
	{
		if (iqueryable_0.Count() > 0)
		{
			foreach (Customer item in iqueryable_0)
			{
				string text = string.Empty;
				if (!string.IsNullOrEmpty(item.CustomerCell))
				{
					text = Resources.Cell + item.CustomerCell;
				}
				if (!string.IsNullOrEmpty(item.CustomerEmail))
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += " / ";
					}
					text = text + Resources.E_mail + item.CustomerEmail;
				}
				if (!string.IsNullOrEmpty(item.CustomerHome))
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += " / ";
					}
					text = text + Resources.Home + item.CustomerHome;
				}
				ListViewItem value = new ListViewItem(new string[4]
				{
					item.MemberNumber,
					item.CustomerName,
					text,
					item.CustomerID.ToString()
				});
				lstItems.Items.Add(value);
			}
			return;
		}
		Button button = btnPreview;
		btnDuplicate.Enabled = false;
		button.Enabled = false;
		ListViewItem value2 = new ListViewItem(new string[1] { Resources.No_results_found });
		lstItems.Items.Add(value2);
	}

	private void method_6(Customer customer_0)
	{
		txtMemberNumber.Text = customer_0.MemberNumber;
		txtCell.Text = customer_0.CustomerCell;
		txtEmail.Text = customer_0.CustomerEmail;
		txtHomePhone.Text = customer_0.CustomerHome;
		txtName.Text = customer_0.CustomerName;
		txtComments.Text = customer_0.Comments;
		chkIsActive.Value = customer_0.Active;
		txtAddress.Text = customer_0.Address;
		txtLoyaltyCardNo.Text = customer_0.LoyaltyCardNo;
		btnCancel.Enabled = true;
	}

	private void method_7()
	{
		txtMemberNumber.Text = string.Empty;
		txtCell.Text = string.Empty;
		txtEmail.Text = string.Empty;
		txtHomePhone.Text = string.Empty;
		txtName.Text = string.Empty;
		txtComments.Text = string.Empty;
		txtAddress.Text = string.Empty;
		txtLoyaltyCardNo.Text = string.Empty;
	}

	private void txtSearchBox_Enter(object sender, EventArgs e)
	{
		if (txtSearchBox.Text == Resources.Enter_Search_Criteria_Here)
		{
			txtSearchBox.ForeColor = HelperMethods.GetColor("Black");
			txtSearchBox.Text = string.Empty;
		}
	}

	private void txtSearchBox_Leave(object sender, EventArgs e)
	{
		if (txtSearchBox.Text == string.Empty)
		{
			txtSearchBox.ForeColor = HelperMethods.GetColor("Gray");
			txtSearchBox.Text = Resources.Enter_Search_Criteria_Here;
		}
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		int_0 = 0;
		Button button = btnCancel;
		btnOrderEntry.Enabled = false;
		button.Enabled = false;
		method_7();
	}

	private void txtSearchBox_TextChanged(object sender, EventArgs e)
	{
		if (txtSearchBox.Text == "")
		{
			btnSearch.Enabled = false;
		}
		else
		{
			btnSearch.Enabled = true;
		}
	}

	private void btnShowKeyboard_MemberNumber_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Member_No, 0, 128, txtMemberNumber.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtMemberNumber.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Name0, 0, 50, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Cell_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Cellphone_No, 0, 10, txtCell.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtCell.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_HomePhone_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Home_Phone_No, 0, 10, txtHomePhone.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtHomePhone.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Email_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Email, 1, 128, txtEmail.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtEmail.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_SearchBox_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search0, 0, 50, txtSearchBox.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtSearchBox.Text = MemoryLoadedObjects.Keyboard.textEntered;
			method_4();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_8()
	{
		if (lstItems.Columns.Count > 0)
		{
			lstItems.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstItems, 2.0);
			lstItems.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstItems, 5.0);
			lstItems.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstItems, 5.0);
		}
	}

	private void txtComments_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedIndices.Count <= 0 || lstItems.SelectedItems[0].SubItems.Count <= 1)
		{
			return;
		}
		if (lstItems.SelectedItems[0].SubItems[3].Text == string.Empty)
		{
			int_0 = 0;
		}
		else
		{
			int_0 = Convert.ToInt32(lstItems.SelectedItems[0].SubItems[3].Text);
		}
		if (int_0 > 0)
		{
			Customer customer = new GClass6().Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
			if (customer != null)
			{
				method_6(customer);
				method_9();
				btnCancel.Enabled = true;
			}
			btnOrderEntry.Enabled = true;
		}
		else
		{
			method_7();
			btnOrderEntry.Enabled = false;
		}
	}

	private void method_9()
	{
		lstOrder.Items.Clear();
		if (int_0 <= 0)
		{
			return;
		}
		var source = (from a in gclass6_0.Orders
			where a.CustomerID == (int?)int_0 && a.DateCreated.Value.Year.ToString() == ddlYear.Text
			group a by a.OrderNumber into a
			select new
			{
				OrderNumber = a.Key,
				DateCreated = a.FirstOrDefault().DateCreated,
				Paid = ((a.Count((Order b) => b.Paid == true && b.Void == false) > 0) ? true : false),
				Void = ((a.Count((Order b) => (b.Paid == true && b.Void == false) || (b.Paid == false && b.Void == false)) > 0) ? false : true),
				Total = ((a.Count((Order b) => (b.Paid == true && b.Void == false) || (b.Paid == false && b.Void == false)) > 0) ? a.Where((Order b) => (b.Paid == true && b.Void == false) || (b.Paid == false && b.Void == false)).Sum((Order b) => b.Total) : a.Sum((Order b) => b.Total))
			} into a
			orderby a.DateCreated descending
			select a).Take(30);
		if (source.Count() == 0)
		{
			Button button = btnPreview;
			btnDuplicate.Enabled = false;
			button.Enabled = false;
			return;
		}
		foreach (var item in source.ToList())
		{
			string text = OrderStatus.Open;
			if (item.Paid)
			{
				text = OrderStatus.Paid;
			}
			if (item.Void)
			{
				text = OrderStatus.Void;
			}
			ListViewItem value = new ListViewItem(new string[4]
			{
				item.DateCreated.Value.ToShortDateString(),
				item.OrderNumber,
				item.Total.ToString("0.00"),
				text
			});
			lstOrder.Items.Add(value);
		}
	}

	private void lstOrder_SelectedIndexChanged(object sender, EventArgs e)
	{
		btnPreview.Enabled = true;
		if (lstOrder.SelectedItems.Count > 0)
		{
			string text = lstOrder.SelectedItems[0].SubItems[3].Text;
			if (!(text == OrderStatus.Open) && !(text == OrderStatus.Void) && !bool_3)
			{
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

	private void btnPreview_Click(object sender, EventArgs e)
	{
		if (lstOrder.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_0();
			CS_0024_003C_003E8__locals0.orderNumber = lstOrder.SelectedItems[0].SubItems[1].Text;
			if (new GClass6().Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && x.Void == false).Count() == 0)
			{
				new NotificationLabel(this, "Unable to load order, order was already voided.", NotificationTypes.Notification).Show();
			}
			else
			{
				new frmReport(CS_0024_003C_003E8__locals0.orderNumber, ReportTypes.Orders).Show();
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_LoyaltyCardNo_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Loyalty Card #", 0, 30, txtLoyaltyCardNo.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtLoyaltyCardNo.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnCheckBalance_Click(object sender, EventArgs e)
	{
		CardProcessorObject cardProcessorObject = null;
		CardProcessorObject cardProcessorObject2 = null;
		string text = string.Empty;
		if (bool_1)
		{
			cardProcessorObject = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
		}
		if (bool_0)
		{
			cardProcessorObject2 = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
		}
		string text2 = string.Empty;
		if (bool_1 && cardProcessorObject != null)
		{
			string title = "PLEASE SWIPE/SCAN LOYALTY CARD NUMBER";
			if (bool_0 && bool_1 && cardProcessorObject2 != null && cardProcessorObject.Processor == cardProcessorObject2.Processor)
			{
				title = "PLEASE SWIPE/SCAN CARD NUMBER";
			}
			frmGiftCardPrompt frmGiftCardPrompt2 = new frmGiftCardPrompt(title);
			if (frmGiftCardPrompt2.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			if (string.IsNullOrEmpty(frmGiftCardPrompt2.CardNumber))
			{
				new NotificationLabel(this, "Card number was blank.", NotificationTypes.Notification).Show();
				return;
			}
			text = frmGiftCardPrompt2.CardNumber;
			if (cardProcessorObject != null && cardProcessorObject.Processor == "Ackroo")
			{
				AckrooCardResponse ackrooCardResponse = AckrooMethods.CheckCardBalance(frmGiftCardPrompt2.CardNumber);
				if (string.IsNullOrEmpty(ackrooCardResponse.error))
				{
					text2 = text2 + "Loyalty: " + $"{ackrooCardResponse.loyalty:C}";
					text2 = text2 + "\nGift Card: " + $"{ackrooCardResponse.gift:C}";
					if (!string.IsNullOrEmpty(text2))
					{
						new frmMessageBox(text2, "CARD BALANCE", CustomMessageBoxButtons.Ok).ShowDialog();
					}
					else
					{
						new frmMessageBox("An error occurred trying to retrieve the card info.  Please check internet connection.", "CARD BALANCE", CustomMessageBoxButtons.Ok).ShowDialog();
					}
					return;
				}
			}
		}
		if (!bool_0 || cardProcessorObject2 == null)
		{
			return;
		}
		if (bool_1 && (cardProcessorObject == null || !(cardProcessorObject.Processor != cardProcessorObject2.Processor)))
		{
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (cardProcessorObject2.Processor == "Ackroo")
			{
				AckrooCardResponse ackrooCardResponse2 = AckrooMethods.CheckCardBalance(text);
				if (string.IsNullOrEmpty(ackrooCardResponse2.error))
				{
					text2 = text2 + "\nGift Card: " + $"{ackrooCardResponse2.gift:C}";
				}
			}
		}
		else
		{
			frmGiftCardPrompt frmGiftCardPrompt3 = new frmGiftCardPrompt("PLEASE SWIPE/SCAN GIFT CARD NUMBER");
			if (frmGiftCardPrompt3.ShowDialog(this) == DialogResult.OK)
			{
				if (string.IsNullOrEmpty(frmGiftCardPrompt3.CardNumber))
				{
					new NotificationLabel(this, "Card number was blank.", NotificationTypes.Notification).Show();
					return;
				}
				if (cardProcessorObject2.Processor == "Ackroo")
				{
					AckrooCardResponse ackrooCardResponse3 = AckrooMethods.CheckCardBalance(frmGiftCardPrompt3.CardNumber);
					if (string.IsNullOrEmpty(ackrooCardResponse3.error))
					{
						text2 = text2 + "\n\nGift Card: " + $"{ackrooCardResponse3.gift:C}";
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			new frmMessageBox(text2, "CARD BALANCE", CustomMessageBoxButtons.Ok).ShowDialog();
		}
		else
		{
			new frmMessageBox("An error occurred trying to retrieve the card info.  Please check internet connection.", "CARD BALANCE", CustomMessageBoxButtons.Ok).ShowDialog();
		}
	}

	private void label4_Click(object sender, EventArgs e)
	{
	}

	private void txtAddress_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnShowKeyboard_Address_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Address, 0, 255, txtAddress.Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtAddress.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtLoyaltyCardNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void label5_Click(object sender, EventArgs e)
	{
	}

	private void btnOrderEntry_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			new frmKioskOrderTypeSelection().ShowDialog();
			return;
		}
		gclass6_0 = new GClass6();
		if (!gclass6_0.CompanySetups.FirstOrDefault().isOpen)
		{
			new NotificationLabel(this, "Store is closed, please open the store.", NotificationTypes.Warning).Show();
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
		string text = txtCell.Text;
		if (text == string.Empty)
		{
			text = txtHomePhone.Text;
		}
		string pickUp = OrderTypes.PickUp;
		string[] itemList = new string[4]
		{
			OrderTypes.Delivery,
			OrderTypes.DineIn,
			OrderTypes.PickUp,
			OrderTypes.ToGo
		};
		MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: false, Resources.Select_an_Order_Type);
		if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
		{
			pickUp = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
			if (pickUp == OrderTypes.PickUp || pickUp == OrderTypes.Delivery)
			{
				if (string.IsNullOrEmpty(txtName.Text.Trim()))
				{
					new NotificationLabel(this, "Please add a name.", NotificationTypes.Warning);
					base.DialogResult = DialogResult.None;
					return;
				}
				if (string.IsNullOrEmpty(text.Trim()))
				{
					new NotificationLabel(this, "Please add any cell/home phone number.", NotificationTypes.Warning);
					base.DialogResult = DialogResult.None;
					return;
				}
			}
			if (pickUp == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
			{
				frmTableChange frmTableChange2 = new frmTableChange("Select Table", 1, text, pickUp, txtName.Text, showBtnToGo: false);
				if (frmTableChange2.ShowDialog(this) == DialogResult.OK)
				{
					text = "Table " + frmTableChange2.OrderTable;
				}
			}
			MemoryLoadedObjects.OrderEntry.LoadFormData(null, text, pickUp, 1, int_0, txtName.Text, txtAddress.Text, resetComboId: true, 1);
			MemoryLoadedObjects.OrderEntry.Show();
		}
		else
		{
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnSkip_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Ignore;
		Close();
	}

	private void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_9();
	}

	private void btnDuplicate_Click(object sender, EventArgs e)
	{
		if (lstOrder.SelectedItems.Count == 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass46_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_0();
		CS_0024_003C_003E8__locals0.oldOrderNumber = lstOrder.SelectedItems[0].SubItems[1].Text;
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.orders = (from o in gClass.Orders
			where o.OrderNumber == CS_0024_003C_003E8__locals0.oldOrderNumber && o.ItemID > 0 && o.Void == false
			select o into x
			orderby x.DateCreated
			select x).ToList();
		if (CS_0024_003C_003E8__locals0.orders.Count() <= 0)
		{
			return;
		}
		GlobalOrderHistoryObjects.CustomerInfo customerInfo = new GlobalOrderHistoryObjects.CustomerInfo();
		using (List<Order>.Enumerator enumerator = CS_0024_003C_003E8__locals0.orders.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				Order current = enumerator.Current;
				customerInfo.customer_cell = current.Customer;
				customerInfo.customer_address = current.CustomerInfo;
				customerInfo.customer_name = current.CustomerInfoName;
				customerInfo.customer_id = current.CustomerID.Value;
			}
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
				_003C_003Ec__DisplayClass46_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass46_1();
				flag = true;
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
				CS_0024_003C_003E8__locals1.orderListIDs = CS_0024_003C_003E8__locals0.orders.Select((Order a) => a.OrderId).ToList();
				List<Guid> list = (from a in gClass.Orders
					where a.ShareItemID.HasValue && CS_0024_003C_003E8__locals1.orderListIDs.Contains(a.ShareItemID.Value) && a.Void == false
					select a into x
					select x.ShareItemID.Value).ToList();
				CS_0024_003C_003E8__locals1.billCount = 1;
				if (list.Count > 0)
				{
					CS_0024_003C_003E8__locals1.billCount = list.Where((Guid a) => CS_0024_003C_003E8__locals1.orderListIDs.FirstOrDefault() == a).Count() + 1;
				}
				else if (CS_0024_003C_003E8__locals0.orders.FirstOrDefault().ShareItemID.HasValue)
				{
					CS_0024_003C_003E8__locals1.billCount = gClass.Orders.Where((Order a) => a.ShareItemID.HasValue && a.ShareItemID.Value == CS_0024_003C_003E8__locals0.orders.FirstOrDefault().ShareItemID).Count() + 1;
				}
				CS_0024_003C_003E8__locals1.iwos = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult x) => CS_0024_003C_003E8__locals0.orders.Select((Order y) => y.ItemOptionId.Value).Contains(x.ItemWithOptionID)).ToList();
				List<GlobalOrderHistoryObjects.Order> orders = (from x in CS_0024_003C_003E8__locals0.orders.Select(delegate(Order x)
					{
						CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_2();
						CS_0024_003C_003E8__locals0.x = x;
						return new GlobalOrderHistoryObjects.Order
						{
							combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
							customer_phone = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.x.CustomerInfoPhone) ? CS_0024_003C_003E8__locals0.x.Customer : CS_0024_003C_003E8__locals0.x.CustomerInfoPhone),
							date_paid = CS_0024_003C_003E8__locals0.x.LastDateModified.Value,
							item_barcode = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.x.ItemBarcode) ? MemoryLoadedData.all_items.Where((Item y) => y.ItemID == CS_0024_003C_003E8__locals0.x.ItemID).FirstOrDefault().Barcode : CS_0024_003C_003E8__locals0.x.ItemBarcode),
							item_id = CS_0024_003C_003E8__locals0.x.ItemID,
							item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
							item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
							item_name = CS_0024_003C_003E8__locals0.x.ItemName,
							item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)CS_0024_003C_003E8__locals1.billCount,
							option_group_name = ((!CS_0024_003C_003E8__locals0.x.ItemOptionId.HasValue || CS_0024_003C_003E8__locals0.x.ItemOptionId.Value <= 0) ? null : ((CS_0024_003C_003E8__locals1.iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault() != null) ? CS_0024_003C_003E8__locals1.iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault().GroupName : null)),
							option_tab = ((!CS_0024_003C_003E8__locals0.x.ItemOptionId.HasValue || CS_0024_003C_003E8__locals0.x.ItemOptionId.Value <= 0) ? null : ((CS_0024_003C_003E8__locals1.iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault() != null) ? CS_0024_003C_003E8__locals1.iwos.Where((usp_ItemOptionsResult y) => y.ItemWithOptionID == CS_0024_003C_003E8__locals0.x.ItemOptionId.Value).FirstOrDefault().Tab : null)),
							order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
						};
					})
					orderby x.date_paid
					select x).ToList();
				string newOrderNumber = OrderMethods.GetNewOrderNumber();
				OrderHelper.DuplicateOrder(orders, customerInfo, newOrderNumber, CS_0024_003C_003E8__locals0.orders.FirstOrDefault().OrderType, (short)employee.EmployeeID);
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
				MemoryLoadedObjects.OrderEntry.LoadFormData(newOrderNumber, customerInfo.customer_cell, OrderTypes.PickUp, 0, customerInfo.customer_id, customerInfo.customer_name, customerInfo.customer_address, resetComboId: true, 1);
				MemoryLoadedObjects.OrderEntry.ShowDialog();
			}
			else
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
			}
		}
		while (!flag);
	}

	private void btnPreview_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!string.IsNullOrEmpty(button.Text))
		{
			if (!button.Enabled)
			{
				button.Tag = button.BackColor;
				button.BackColor = Color.Gray;
			}
			else if (!string.IsNullOrEmpty(button.Tag.ToString()))
			{
				button.BackColor = (Color)button.Tag;
			}
		}
	}

	private void btnShowKeyboard_txtComments_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Notes", 1, 256, txtComments.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtComments.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCustomers));
		lblWIndowTitle = new Label();
		pnlMain = new Panel();
		btnShowKeyboard_txtComments = new Button();
		btnDuplicate = new Button();
		ddlYear = new Class19();
		btnSkip = new Button();
		btnOrderEntry = new Button();
		btnCheckBalance = new Button();
		lblTrainingMode = new Label();
		txtLoyaltyCardNo = new RadTextBoxControl();
		btnShowKeyboard_LoyaltyCardNo = new Button();
		label5 = new Label();
		txtAddress = new RadTextBoxControl();
		btnShowKeyboard_Address = new Button();
		label4 = new Label();
		btnPreview = new Button();
		label3 = new Label();
		lstOrder = new ListView();
		columnHeader_3 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		columnHeader_5 = new ColumnHeader();
		columnHeader_6 = new ColumnHeader();
		label2 = new Label();
		label1 = new Label();
		txtSearchBox = new RadTextBoxControl();
		btnShowKeyboard_SearchBox = new Button();
		txtEmail = new RadTextBoxControl();
		txtHomePhone = new RadTextBoxControl();
		txtCell = new RadTextBoxControl();
		txtName = new RadTextBoxControl();
		txtMemberNumber = new RadTextBoxControl();
		chkIsActive = new RadToggleSwitch();
		lblSearchForMembers = new Label();
		btnSearch = new Button();
		btnShowKeyboard_Email = new Button();
		lstItems = new ListView();
		columnHeader_2 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		btnShowKeyboard_HomePhone = new Button();
		lblSearchResults = new Label();
		btnShowKeyboard_Cell = new Button();
		btnShowKeyboard_Name = new Button();
		lblName = new Label();
		btnShowKeyboard_MemberNumber = new Button();
		lblCellPhone = new Label();
		lblIsActive = new Label();
		lblMemberNo = new Label();
		btnNew = new Button();
		btnClose = new Button();
		btnSave = new Button();
		txtComments = new TextBox();
		lblHomeNo = new Label();
		lblMembersNotes = new Label();
		lblEmail = new Label();
		btnCancel = new Button();
		lblMemberInfo = new Label();
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtLoyaltyCardNo).BeginInit();
		((ISupportInitialize)txtAddress).BeginInit();
		((ISupportInitialize)txtSearchBox).BeginInit();
		((ISupportInitialize)txtEmail).BeginInit();
		((ISupportInitialize)txtHomePhone).BeginInit();
		((ISupportInitialize)txtCell).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)txtMemberNumber).BeginInit();
		((ISupportInitialize)chkIsActive).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblWIndowTitle, "lblWIndowTitle");
		lblWIndowTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblWIndowTitle.ForeColor = Color.White;
		lblWIndowTitle.Name = "lblWIndowTitle";
		componentResourceManager.ApplyResources(pnlMain, "pnlMain");
		pnlMain.BackColor = Color.FromArgb(35, 39, 56);
		pnlMain.Controls.Add(btnShowKeyboard_txtComments);
		pnlMain.Controls.Add(btnDuplicate);
		pnlMain.Controls.Add(ddlYear);
		pnlMain.Controls.Add(btnSkip);
		pnlMain.Controls.Add(btnOrderEntry);
		pnlMain.Controls.Add(btnCheckBalance);
		pnlMain.Controls.Add(lblTrainingMode);
		pnlMain.Controls.Add(txtLoyaltyCardNo);
		pnlMain.Controls.Add(btnShowKeyboard_LoyaltyCardNo);
		pnlMain.Controls.Add(label5);
		pnlMain.Controls.Add(txtAddress);
		pnlMain.Controls.Add(btnShowKeyboard_Address);
		pnlMain.Controls.Add(label4);
		pnlMain.Controls.Add(btnPreview);
		pnlMain.Controls.Add(label3);
		pnlMain.Controls.Add(lstOrder);
		pnlMain.Controls.Add(label2);
		pnlMain.Controls.Add(label1);
		pnlMain.Controls.Add(txtSearchBox);
		pnlMain.Controls.Add(btnShowKeyboard_SearchBox);
		pnlMain.Controls.Add(txtEmail);
		pnlMain.Controls.Add(txtHomePhone);
		pnlMain.Controls.Add(txtCell);
		pnlMain.Controls.Add(txtName);
		pnlMain.Controls.Add(txtMemberNumber);
		pnlMain.Controls.Add(chkIsActive);
		pnlMain.Controls.Add(lblSearchForMembers);
		pnlMain.Controls.Add(btnSearch);
		pnlMain.Controls.Add(btnShowKeyboard_Email);
		pnlMain.Controls.Add(lstItems);
		pnlMain.Controls.Add(btnShowKeyboard_HomePhone);
		pnlMain.Controls.Add(lblSearchResults);
		pnlMain.Controls.Add(btnShowKeyboard_Cell);
		pnlMain.Controls.Add(btnShowKeyboard_Name);
		pnlMain.Controls.Add(lblName);
		pnlMain.Controls.Add(btnShowKeyboard_MemberNumber);
		pnlMain.Controls.Add(lblCellPhone);
		pnlMain.Controls.Add(lblIsActive);
		pnlMain.Controls.Add(lblMemberNo);
		pnlMain.Controls.Add(btnNew);
		pnlMain.Controls.Add(btnClose);
		pnlMain.Controls.Add(btnSave);
		pnlMain.Controls.Add(txtComments);
		pnlMain.Controls.Add(lblHomeNo);
		pnlMain.Controls.Add(lblMembersNotes);
		pnlMain.Controls.Add(lblEmail);
		pnlMain.Controls.Add(btnCancel);
		pnlMain.Controls.Add(lblMemberInfo);
		pnlMain.Name = "pnlMain";
		componentResourceManager.ApplyResources(btnShowKeyboard_txtComments, "btnShowKeyboard_txtComments");
		btnShowKeyboard_txtComments.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_txtComments.DialogResult = DialogResult.OK;
		btnShowKeyboard_txtComments.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_txtComments.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_txtComments.ForeColor = Color.White;
		btnShowKeyboard_txtComments.Name = "btnShowKeyboard_txtComments";
		btnShowKeyboard_txtComments.Tag = "5,5";
		btnShowKeyboard_txtComments.UseVisualStyleBackColor = false;
		btnShowKeyboard_txtComments.Click += btnShowKeyboard_txtComments_Click;
		btnDuplicate.BackColor = Color.FromArgb(80, 203, 116);
		btnDuplicate.FlatAppearance.BorderColor = Color.Black;
		btnDuplicate.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDuplicate, "btnDuplicate");
		btnDuplicate.ForeColor = Color.White;
		btnDuplicate.Name = "btnDuplicate";
		btnDuplicate.UseVisualStyleBackColor = false;
		btnDuplicate.EnabledChanged += btnPreview_EnabledChanged;
		btnDuplicate.Click += btnDuplicate_Click;
		ddlYear.BackColor = Color.White;
		ddlYear.DrawMode = DrawMode.OwnerDrawVariable;
		ddlYear.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlYear, "ddlYear");
		ddlYear.ForeColor = Color.FromArgb(40, 40, 40);
		ddlYear.FormattingEnabled = true;
		ddlYear.Name = "ddlYear";
		ddlYear.Tag = "";
		ddlYear.SelectedIndexChanged += ddlYear_SelectedIndexChanged;
		btnSkip.BackColor = Color.FromArgb(42, 102, 134);
		btnSkip.FlatAppearance.BorderColor = Color.White;
		btnSkip.FlatAppearance.BorderSize = 0;
		btnSkip.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSkip, "btnSkip");
		btnSkip.ForeColor = Color.White;
		btnSkip.Name = "btnSkip";
		btnSkip.UseVisualStyleBackColor = false;
		btnSkip.Click += btnSkip_Click;
		componentResourceManager.ApplyResources(btnOrderEntry, "btnOrderEntry");
		btnOrderEntry.BackColor = Color.FromArgb(255, 192, 128);
		btnOrderEntry.FlatAppearance.BorderColor = Color.White;
		btnOrderEntry.FlatAppearance.BorderSize = 0;
		btnOrderEntry.FlatAppearance.MouseDownBackColor = Color.White;
		btnOrderEntry.ForeColor = Color.White;
		btnOrderEntry.Name = "btnOrderEntry";
		btnOrderEntry.UseVisualStyleBackColor = false;
		btnOrderEntry.EnabledChanged += btnPreview_EnabledChanged;
		btnOrderEntry.Click += btnOrderEntry_Click;
		componentResourceManager.ApplyResources(btnCheckBalance, "btnCheckBalance");
		btnCheckBalance.BackColor = Color.FromArgb(53, 152, 220);
		btnCheckBalance.FlatAppearance.BorderColor = Color.Black;
		btnCheckBalance.FlatAppearance.BorderSize = 0;
		btnCheckBalance.ForeColor = Color.White;
		btnCheckBalance.Name = "btnCheckBalance";
		btnCheckBalance.UseVisualStyleBackColor = false;
		btnCheckBalance.Click += btnCheckBalance_Click;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(txtLoyaltyCardNo, "txtLoyaltyCardNo");
		txtLoyaltyCardNo.ForeColor = Color.FromArgb(40, 40, 40);
		txtLoyaltyCardNo.Name = "txtLoyaltyCardNo";
		txtLoyaltyCardNo.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtLoyaltyCardNo.TextChanged += txtLoyaltyCardNo_TextChanged;
		txtLoyaltyCardNo.Click += txtComments_Click;
		((RadTextBoxControlElement)txtLoyaltyCardNo.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtLoyaltyCardNo.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(btnShowKeyboard_LoyaltyCardNo, "btnShowKeyboard_LoyaltyCardNo");
		btnShowKeyboard_LoyaltyCardNo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_LoyaltyCardNo.DialogResult = DialogResult.OK;
		btnShowKeyboard_LoyaltyCardNo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_LoyaltyCardNo.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_LoyaltyCardNo.ForeColor = Color.White;
		btnShowKeyboard_LoyaltyCardNo.Name = "btnShowKeyboard_LoyaltyCardNo";
		btnShowKeyboard_LoyaltyCardNo.Tag = "5,5";
		btnShowKeyboard_LoyaltyCardNo.UseVisualStyleBackColor = false;
		btnShowKeyboard_LoyaltyCardNo.Click += btnShowKeyboard_LoyaltyCardNo_Click;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label5.Tag = "5,5";
		label5.Click += label5_Click;
		componentResourceManager.ApplyResources(txtAddress, "txtAddress");
		txtAddress.ForeColor = Color.FromArgb(40, 40, 40);
		txtAddress.Multiline = true;
		txtAddress.Name = "txtAddress";
		txtAddress.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtAddress.TextChanged += txtAddress_TextChanged;
		txtAddress.Click += txtComments_Click;
		((RadTextBoxControlElement)txtAddress.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtAddress.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(btnShowKeyboard_Address, "btnShowKeyboard_Address");
		btnShowKeyboard_Address.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Address.DialogResult = DialogResult.OK;
		btnShowKeyboard_Address.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Address.FlatAppearance.BorderSize = 0;
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
		label4.Click += label4_Click;
		btnPreview.BackColor = Color.FromArgb(53, 152, 220);
		btnPreview.FlatAppearance.BorderColor = Color.Black;
		btnPreview.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnPreview, "btnPreview");
		btnPreview.ForeColor = Color.White;
		btnPreview.Name = "btnPreview";
		btnPreview.UseVisualStyleBackColor = false;
		btnPreview.EnabledChanged += btnPreview_EnabledChanged;
		btnPreview.Click += btnPreview_Click;
		label3.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label3.Tag = "0,2";
		componentResourceManager.ApplyResources(lstOrder, "lstOrder");
		lstOrder.BackColor = Color.White;
		lstOrder.BorderStyle = BorderStyle.None;
		lstOrder.Columns.AddRange(new ColumnHeader[4] { columnHeader_3, columnHeader_4, columnHeader_5, columnHeader_6 });
		lstOrder.FullRowSelect = true;
		lstOrder.GridLines = true;
		lstOrder.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstOrder.HideSelection = false;
		lstOrder.MultiSelect = false;
		lstOrder.Name = "lstOrder";
		lstOrder.Tag = "5,5";
		lstOrder.TileSize = new Size(50, 200);
		lstOrder.UseCompatibleStateImageBehavior = false;
		lstOrder.View = View.Details;
		lstOrder.SelectedIndexChanged += lstOrder_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_3, "columnHeader1");
		componentResourceManager.ApplyResources(columnHeader_4, "columnHeader2");
		componentResourceManager.ApplyResources(columnHeader_5, "columnHeader3");
		componentResourceManager.ApplyResources(columnHeader_6, "Status");
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label2.Tag = "5,5";
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.Tag = "5,5";
		txtSearchBox.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtSearchBox, "txtSearchBox");
		txtSearchBox.ForeColor = Color.Black;
		txtSearchBox.Name = "txtSearchBox";
		txtSearchBox.TextChanged += txtSearchBox_TextChanged;
		txtSearchBox.Click += txtComments_Click;
		txtSearchBox.Enter += txtSearchBox_Enter;
		txtSearchBox.Leave += txtSearchBox_Leave;
		btnShowKeyboard_SearchBox.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchBox.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchBox.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchBox.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SearchBox, "btnShowKeyboard_SearchBox");
		btnShowKeyboard_SearchBox.ForeColor = Color.White;
		btnShowKeyboard_SearchBox.Name = "btnShowKeyboard_SearchBox";
		btnShowKeyboard_SearchBox.Tag = "5,5";
		btnShowKeyboard_SearchBox.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchBox.Click += btnShowKeyboard_SearchBox_Click;
		componentResourceManager.ApplyResources(txtEmail, "txtEmail");
		txtEmail.ForeColor = Color.FromArgb(40, 40, 40);
		txtEmail.Name = "txtEmail";
		txtEmail.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtEmail.Click += txtComments_Click;
		((RadTextBoxControlElement)txtEmail.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtEmail.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtHomePhone, "txtHomePhone");
		txtHomePhone.ForeColor = Color.FromArgb(40, 40, 40);
		txtHomePhone.Name = "txtHomePhone";
		txtHomePhone.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtHomePhone.Click += txtComments_Click;
		((RadTextBoxControlElement)txtHomePhone.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtHomePhone.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtCell, "txtCell");
		txtCell.ForeColor = Color.FromArgb(40, 40, 40);
		txtCell.Name = "txtCell";
		txtCell.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtCell.Click += txtComments_Click;
		((RadTextBoxControlElement)txtCell.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtCell.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.Click += txtComments_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtMemberNumber, "txtMemberNumber");
		txtMemberNumber.ForeColor = Color.FromArgb(40, 40, 40);
		txtMemberNumber.Name = "txtMemberNumber";
		txtMemberNumber.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtMemberNumber.Click += txtComments_Click;
		((RadTextBoxControlElement)txtMemberNumber.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtMemberNumber.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(chkIsActive, "chkIsActive");
		chkIsActive.Name = "chkIsActive";
		chkIsActive.OffText = "NO";
		chkIsActive.OnText = "YES";
		chkIsActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkIsActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkIsActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkIsActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkIsActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkIsActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkIsActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkIsActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		lblSearchForMembers.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSearchForMembers, "lblSearchForMembers");
		lblSearchForMembers.ForeColor = Color.White;
		lblSearchForMembers.Name = "lblSearchForMembers";
		lblSearchForMembers.Tag = "0,0";
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.BackColor = Color.FromArgb(53, 152, 220);
		btnSearch.FlatAppearance.BorderColor = Color.Black;
		btnSearch.FlatAppearance.BorderSize = 0;
		btnSearch.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearch.ForeColor = Color.White;
		btnSearch.Name = "btnSearch";
		btnSearch.Tag = "1,0";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += btnSearch_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Email, "btnShowKeyboard_Email");
		btnShowKeyboard_Email.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Email.DialogResult = DialogResult.OK;
		btnShowKeyboard_Email.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Email.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Email.ForeColor = Color.White;
		btnShowKeyboard_Email.Name = "btnShowKeyboard_Email";
		btnShowKeyboard_Email.Tag = "5,5";
		btnShowKeyboard_Email.UseVisualStyleBackColor = false;
		btnShowKeyboard_Email.Click += btnShowKeyboard_Email_Click;
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BackColor = Color.White;
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[3] { columnHeader_2, columnHeader_0, columnHeader_1 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.Tag = "5,5";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_2, "MemberNo");
		componentResourceManager.ApplyResources(columnHeader_0, "CustomerNameTitle");
		componentResourceManager.ApplyResources(columnHeader_1, "Info");
		componentResourceManager.ApplyResources(btnShowKeyboard_HomePhone, "btnShowKeyboard_HomePhone");
		btnShowKeyboard_HomePhone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_HomePhone.DialogResult = DialogResult.OK;
		btnShowKeyboard_HomePhone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_HomePhone.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_HomePhone.ForeColor = Color.White;
		btnShowKeyboard_HomePhone.Name = "btnShowKeyboard_HomePhone";
		btnShowKeyboard_HomePhone.Tag = "5,5";
		btnShowKeyboard_HomePhone.UseVisualStyleBackColor = false;
		btnShowKeyboard_HomePhone.Click += btnShowKeyboard_HomePhone_Click;
		lblSearchResults.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSearchResults, "lblSearchResults");
		lblSearchResults.ForeColor = Color.White;
		lblSearchResults.Name = "lblSearchResults";
		lblSearchResults.Tag = "0,2";
		componentResourceManager.ApplyResources(btnShowKeyboard_Cell, "btnShowKeyboard_Cell");
		btnShowKeyboard_Cell.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Cell.DialogResult = DialogResult.OK;
		btnShowKeyboard_Cell.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Cell.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Cell.ForeColor = Color.White;
		btnShowKeyboard_Cell.Name = "btnShowKeyboard_Cell";
		btnShowKeyboard_Cell.Tag = "5,5";
		btnShowKeyboard_Cell.UseVisualStyleBackColor = false;
		btnShowKeyboard_Cell.Click += btnShowKeyboard_Cell_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
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
		componentResourceManager.ApplyResources(btnShowKeyboard_MemberNumber, "btnShowKeyboard_MemberNumber");
		btnShowKeyboard_MemberNumber.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_MemberNumber.DialogResult = DialogResult.OK;
		btnShowKeyboard_MemberNumber.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_MemberNumber.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_MemberNumber.ForeColor = Color.White;
		btnShowKeyboard_MemberNumber.Name = "btnShowKeyboard_MemberNumber";
		btnShowKeyboard_MemberNumber.Tag = "5,5";
		btnShowKeyboard_MemberNumber.UseVisualStyleBackColor = false;
		btnShowKeyboard_MemberNumber.Click += btnShowKeyboard_MemberNumber_Click;
		lblCellPhone.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblCellPhone, "lblCellPhone");
		lblCellPhone.ForeColor = Color.White;
		lblCellPhone.Name = "lblCellPhone";
		lblCellPhone.Tag = "5,5";
		componentResourceManager.ApplyResources(lblIsActive, "lblIsActive");
		lblIsActive.BackColor = Color.FromArgb(132, 146, 146);
		lblIsActive.ForeColor = Color.White;
		lblIsActive.Name = "lblIsActive";
		lblIsActive.Tag = "5,5";
		lblMemberNo.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblMemberNo, "lblMemberNo");
		lblMemberNo.ForeColor = Color.White;
		lblMemberNo.Name = "lblMemberNo";
		lblMemberNo.Tag = "2,1";
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.Black;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.White;
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.Tag = "5,5";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.Tag = "5,5";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.Tag = "5,5";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(txtComments, "txtComments");
		txtComments.BackColor = Color.White;
		txtComments.BorderStyle = BorderStyle.None;
		txtComments.Name = "txtComments";
		txtComments.Tag = "5,5";
		txtComments.Click += txtComments_Click;
		lblHomeNo.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblHomeNo, "lblHomeNo");
		lblHomeNo.ForeColor = Color.White;
		lblHomeNo.Name = "lblHomeNo";
		lblHomeNo.Tag = "5,5";
		componentResourceManager.ApplyResources(lblMembersNotes, "lblMembersNotes");
		lblMembersNotes.BackColor = Color.FromArgb(147, 101, 184);
		lblMembersNotes.ForeColor = Color.White;
		lblMembersNotes.Name = "lblMembersNotes";
		lblMembersNotes.Tag = "5,5";
		lblEmail.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblEmail, "lblEmail");
		lblEmail.ForeColor = Color.White;
		lblEmail.Name = "lblEmail";
		lblEmail.Tag = "5,5";
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.Tag = "5,5";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(lblMemberInfo, "lblMemberInfo");
		lblMemberInfo.BackColor = Color.FromArgb(147, 101, 184);
		lblMemberInfo.ForeColor = Color.White;
		lblMemberInfo.Name = "lblMemberInfo";
		lblMemberInfo.Tag = "2,0";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lblWIndowTitle);
		base.Controls.Add(pnlMain);
		base.Name = "frmCustomers";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmCustomers_Load;
		base.Controls.SetChildIndex(pnlMain, 0);
		base.Controls.SetChildIndex(lblWIndowTitle, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlMain.ResumeLayout(performLayout: false);
		pnlMain.PerformLayout();
		((ISupportInitialize)txtLoyaltyCardNo).EndInit();
		((ISupportInitialize)txtAddress).EndInit();
		((ISupportInitialize)txtSearchBox).EndInit();
		((ISupportInitialize)txtEmail).EndInit();
		((ISupportInitialize)txtHomePhone).EndInit();
		((ISupportInitialize)txtCell).EndInit();
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)txtMemberNumber).EndInit();
		((ISupportInitialize)chkIsActive).EndInit();
		ResumeLayout(performLayout: false);
	}
}
