using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmOnlineOrders : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadOrders_003Eb__8(Order x)
		{
			return x.OrderNumber == orderNumber;
		}
	}

	private List<Order> list_2;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private int int_0;

	private byte byte_0;

	private DateTime? nullable_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Button btnCancel;

	private Class24 lblNewOrders;

	private Class24 lblConfirmedOrders;

	private VerticalScrollControl verticalScrollControl1;

	internal CustomListViewTelerik lvItems;

	private Label label2;

	private Label label1;

	private Label label8;

	internal CustomListViewTelerik lvOrders;

	private VerticalScrollControl verticalScrollControl2;

	private Timer timer_0;

	private RadLabel lblOrderInfo;

	private FlowLayoutPanel pnlConfirmation;

	private Label label3;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button btnCustomMins;

	internal Button btnReject;

	internal Button btnConfirmFulfillmentTime;

	private Class24 lblRejectedOrder;

	public frmOnlineOrders(string _orderNumber = null)
	{
		Class26.Ggkj0JxzN9YmC();
		string_1 = string.Empty;
		string_2 = string.Empty;
		string_3 = string.Empty;
		int_0 = -1;
		// base._002Ector();
		InitializeComponent_1();
		lvItems.CellFormatting += lvItems_CellFormatting;
		string_0 = _orderNumber;
	}

	private void frmOnlineOrders_Load(object sender, EventArgs e)
	{
		verticalScrollControl1.RefreshSize();
		verticalScrollControl2.RefreshSize();
		method_3();
	}

	private void method_3()
	{
		lvItems.Items.Clear();
		lvOrders.Items.Clear();
		pnlConfirmation.Visible = false;
		lblOrderInfo.Text = string.Empty;
		GClass6 gClass = new GClass6();
		switch (byte_0)
		{
		case 0:
		{
			OrderMethods orderMethods = new OrderMethods(gClass);
			list_2 = (from a in orderMethods.OpenOrders(OrderTypes.AllOnline)
				orderby a.Source, a.FulfillmentAt.HasValue, a.FulfillmentAt.HasValue ? new DateTime?(a.FulfillmentAt.Value) : a.DateCreated
				select a).ToList();
			break;
		}
		case 1:
			list_2 = (from x in gClass.Orders
				where x.DateCreated.Value >= DateTime.Now.AddDays(-1.0) && x.FlagID == 0 && x.Void == false && x.OrderType.Contains("Online")
				select x into a
				orderby a.Source
				select a).ToList();
			break;
		case 2:
			list_2 = (from x in gClass.Orders
				where x.DateCreated.Value >= DateTime.Now.AddDays(-1.0) && x.FlagID == 0 && x.Void == true && x.OrderType.Contains("Online")
				select x into a
				orderby a.Source
				select a).ToList();
			break;
		}
		int num = 0;
		int num2 = 0;
		List<string> list = list_2.Select((Order x) => x.OrderNumber).Distinct().ToList();
		ListViewDataItem[] array = new ListViewDataItem[list.Count];
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
				CS_0024_003C_003E8__locals0.orderNumber = enumerator.Current;
				Order order = (from x in list_2
					where x.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber
					orderby x.DateCreated
					select x).FirstOrDefault();
				if (order != null)
				{
					string[] values = new string[5]
					{
						(CS_0024_003C_003E8__locals0.orderNumber.Length > 15) ? CS_0024_003C_003E8__locals0.orderNumber.Substring(CS_0024_003C_003E8__locals0.orderNumber.Length - 4, 4).ToUpper() : CS_0024_003C_003E8__locals0.orderNumber,
						(!string.IsNullOrEmpty(order.SubSource)) ? order.SubSource : (string.IsNullOrEmpty(order.Source) ? "Unknown" : order.Source),
						string.IsNullOrEmpty(order.Source) ? "Unknown" : order.Source,
						CS_0024_003C_003E8__locals0.orderNumber,
						(!string.IsNullOrEmpty(order.ThirdPartyOrderId)) ? order.ThirdPartyOrderId : ""
					};
					ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
					listViewDataItem.Font = lvOrders.Font;
					array[num] = listViewDataItem;
					if (byte_0 == 0 && !string.IsNullOrEmpty(string_0) && CS_0024_003C_003E8__locals0.orderNumber == string_0)
					{
						num2 = num;
					}
				}
				num++;
			}
		}
		lvOrders.Items.AddRange(array);
		if (byte_0 == 0)
		{
			int_0 = num2;
			lvOrders.SelectedIndex = int_0;
		}
		if (lvOrders.SelectedIndex > -1)
		{
			string_3 = lvOrders.Items[int_0].SubItems[4].ToString();
			string_2 = lvOrders.Items[int_0].SubItems[3].ToString();
			string_1 = lvOrders.Items[int_0].SubItems[2].ToString();
		}
		verticalScrollControl1.EnableDisableButtonsByScrollListView();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void lblNewOrders_Click(object sender, EventArgs e)
	{
		lblNewOrders.BackColor = Color.SandyBrown;
		lblConfirmedOrders.BackColor = Color.FromArgb(176, 124, 219);
		lblRejectedOrder.BackColor = Color.FromArgb(176, 124, 219);
		byte_0 = 0;
		method_3();
	}

	private void BpfuZottDo(object sender, EventArgs e)
	{
		lblNewOrders.BackColor = Color.FromArgb(176, 124, 219);
		lblRejectedOrder.BackColor = Color.FromArgb(176, 124, 219);
		lblConfirmedOrders.BackColor = Color.SandyBrown;
		byte_0 = 1;
		method_3();
	}

	private void lvOrders_SelectedItemChanged(object sender, EventArgs e)
	{
		if (lvOrders.SelectedItems.Count > 0)
		{
			if (lvOrders.SelectedItems[0] == null)
			{
				return;
			}
			int_0 = lvOrders.SelectedIndex;
			pnlConfirmation.Visible = byte_0 == 0;
			lvItems.Items.Clear();
			string_3 = lvOrders.SelectedItems[0].SubItems[4].ToString();
			string_2 = lvOrders.SelectedItems[0].SubItems[3].ToString();
			string_1 = lvOrders.SelectedItems[0].SubItems[2].ToString();
			List<Order> list = (from order_0 in list_2
				where order_0.OrderNumber == string_2
				select order_0 into x
				orderby x.DateCreated
				select x).ToList();
			Order order = list.FirstOrDefault();
			lblOrderInfo.Text = "<html><color=yellow><b>" + order.OrderType.ToUpper() + "</b><br>";
			RadLabel radLabel = lblOrderInfo;
			radLabel.Text = radLabel.Text + "<color=white><b>ORDER DATE:</b> " + order.DateCreated.Value.ToString("MM/dd/yyyy hh:mm tt") + "<br>";
			RadLabel radLabel2 = lblOrderInfo;
			radLabel2.Text = radLabel2.Text + "<b>CUSTOMER INFO:</b> <br>NAME: " + order.CustomerInfoName + "<br>PHONE: " + order.CustomerInfoPhone + "<br>EMAIL: " + order.CustomerInfoEmail + "<br>" + order.CustomerInfo + "<br>";
			nullable_0 = order.FulfillmentAt;
			if (nullable_0.HasValue && nullable_0.Value > DateTime.Now.AddMinutes(30.0))
			{
				string text = ((nullable_0.Value.Date == DateTime.Now.Date) ? ("TODAY @ " + nullable_0.Value.ToShortTimeString()) : nullable_0.Value.ToString("ddd, MMM dd @ hh:mm tt"));
				RadLabel radLabel3 = lblOrderInfo;
				radLabel3.Text = radLabel3.Text + "<color=red><b>FULFILLMENT AT:</b><br>" + text + "<color=white><br><br>";
				btnConfirmFulfillmentTime.Visible = true;
				btnConfirmFulfillmentTime.Text = "CONFIRM FOR " + text;
				button_0.Text = "ADD " + button_0.Text.Replace("ADD ", string.Empty);
				button_1.Text = "ADD " + button_1.Text.Replace("ADD ", string.Empty);
				button_2.Text = "ADD " + button_2.Text.Replace("ADD ", string.Empty);
				button_3.Text = "ADD " + button_3.Text.Replace("ADD ", string.Empty);
				button_4.Text = "ADD " + button_4.Text.Replace("ADD ", string.Empty);
			}
			else
			{
				nullable_0 = null;
				btnConfirmFulfillmentTime.Visible = false;
				button_0.Text = button_0.Text.Replace("ADD ", string.Empty);
				button_1.Text = button_1.Text.Replace("ADD ", string.Empty);
				button_2.Text = button_2.Text.Replace("ADD ", string.Empty);
				button_3.Text = button_3.Text.Replace("ADD ", string.Empty);
				button_4.Text = button_4.Text.Replace("ADD ", string.Empty);
			}
			string text2 = "";
			if (string.IsNullOrEmpty(order.Instructions) && string.IsNullOrEmpty(order.OrderNotes))
			{
				text2 = "<color=white>NO INSTRUCTIONS";
			}
			else
			{
				string text3 = "";
				if (!string.IsNullOrEmpty(order.Instructions))
				{
					text3 = order.Instructions.Split('|')[0].ToString();
				}
				string text4 = "";
				if (!string.IsNullOrEmpty(order.OrderNotes) && string.IsNullOrEmpty(text3))
				{
					text4 = order.OrderNotes;
				}
				text2 = "<color=red><b>" + text3 + " " + text4 + "</b>";
			}
			RadLabel radLabel4 = lblOrderInfo;
			radLabel4.Text = radLabel4.Text + "<b>ORDER INSTRUCTIONS:</b><br>" + text2;
			lblOrderInfo.Text += "<br><br><br><br><br><br><br><br><br><br><br><br></html>";
			lblOrderInfo.TextAlignment = ContentAlignment.TopLeft;
			lblOrderInfo.RootElement.Alignment = ContentAlignment.TopLeft;
			{
				foreach (Order item in list)
				{
					string[] values = new string[3]
					{
						MathHelper.DecimalToFraction(item.Qty),
						item.ItemName + (string.IsNullOrEmpty(item.Instructions) ? string.Empty : (item.Instructions.Contains("|") ? (" => INSTR: " + item.Instructions.Split('|')[1].ToString()) : string.Empty)),
						(item.Qty * item.ItemSellPrice).ToString("0.00")
					};
					ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
					listViewDataItem.Font = lvItems.Font;
					lvItems.Items.Add(listViewDataItem);
				}
				return;
			}
		}
		lvItems.Items.Clear();
		lblOrderInfo.Text = string.Empty;
		pnlConfirmation.Visible = false;
	}

	private void lvItems_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
	{
		if ((e.CellElement.Data.HeaderText == "Price" || e.CellElement.Data.HeaderText == "Ext. Price") && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
		}
	}

	private void method_4(string string_4, int int_1)
	{
		int preptimeMinutes = int_1;
		if (nullable_0.HasValue)
		{
			preptimeMinutes = (int)Math.Abs((nullable_0.Value.AddMinutes(int_1) - DateTime.Now).TotalMinutes);
		}
		if (SyncMethods.UpdateOrderStatusInOrdering(string_2, string_4, string.Empty, string.Empty, string_1, preptimeMinutes, string_3).code == 200)
		{
			GClass6 gClass = new GClass6();
			List<Order> list = gClass.Orders.Where((Order x) => x.OrderNumber == string_2).ToList();
			Order order = list.OrderBy((Order x) => x.DateCreated).FirstOrDefault();
			foreach (Order item in list)
			{
				item.FlagID = 0;
				if (string_4 == "OrderRejected")
				{
					item.Paid = false;
					item.DatePaid = null;
					item.Void = true;
					item.VoidReason = "Order Rejected";
					item.DateVoided = DateTime.Now;
					item.UserCancelled = Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
				}
				else if (nullable_0.HasValue)
				{
					item.FulfillmentAt = nullable_0.Value.AddMinutes(int_1);
				}
				else
				{
					item.FulfillmentAt = DateTime.Now.AddMinutes(int_1);
				}
				item.Synced = false;
			}
			Helper.SubmitChangesWithCatch(gClass);
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_chit_cashout");
			if (string_4 != "OrderRejected" && (settingValueByKey == "OFF" || (settingValueByKey == "ON" && order.Paid)))
			{
				new OrderHelper().OrderPrintMadeCheck("", string_2, order.OrderType, order.CustomerInfoName, order.Customer, "Online Order", list.Count());
			}
			if (string_4 == "OrderRejected")
			{
				new NotificationLabel(this, "Order has been rejected.", NotificationTypes.Notification).Show();
			}
			else if (nullable_0.HasValue)
			{
				DateTime dateTime = nullable_0.Value.AddMinutes(int_1);
				string text = ((dateTime.Date == DateTime.Now.Date) ? dateTime.ToString("HH:mm tt") : dateTime.ToString("MMM dd @ HH:mm tt"));
				new NotificationLabel(this, "Order has been accepted with an order ready time on " + text, NotificationTypes.Success).Show();
			}
			else
			{
				new NotificationLabel(this, "Order has been accepted with an order ready time in " + int_1 + " minutes.", NotificationTypes.Success).Show();
			}
			lvOrders.Items.RemoveAt(int_0);
			if (int_0 > lvOrders.Items.Count - 1)
			{
				int_0 = lvOrders.Items.Count - 1;
			}
			lvOrders.SelectedIndex = int_0;
			if (lvOrders.Items.Count == 0)
			{
				CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: false);
			}
			if (base.ParentForm != null)
			{
				MiscHelper.MakeOrderIsModified(base.ParentForm, order.OrderNumber);
			}
		}
		else
		{
			new NotificationLabel(this, "An error occurred changing order status.  Please check internet connection and try again later.", NotificationTypes.Warning).Show();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 15);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 20);
	}

	private void method_5(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 25);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 30);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 45);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 60);
	}

	private void btnReject_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox("Are you sure you want to REJECT this order (" + string_2 + ")?", "REJECT?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			method_4("OrderRejected", 0);
		}
	}

	private void btnCustomMins_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Custom Preptime Minutes", 0, 3, string.Empty, string.Empty);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			if (MemoryLoadedObjects.Numpad.numberEntered <= 0m)
			{
				new NotificationLabel(this, "Please enter a value greater than zero.", NotificationTypes.Notification).Show();
			}
			else
			{
				method_4("ReceivedByKitchen", (int)MemoryLoadedObjects.Numpad.numberEntered);
			}
		}
	}

	private void btnConfirmFulfillmentTime_Click(object sender, EventArgs e)
	{
		method_4("ReceivedByKitchen", 0);
	}

	private void lblRejectedOrder_Click(object sender, EventArgs e)
	{
		lblNewOrders.BackColor = Color.FromArgb(176, 124, 219);
		lblRejectedOrder.BackColor = Color.SandyBrown;
		lblConfirmedOrders.BackColor = Color.FromArgb(176, 124, 219);
		byte_0 = 2;
		method_3();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmOnlineOrders));
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "OrderNumber");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "OrderDate");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 0", "Qty");
		ListViewDetailColumn listViewDetailColumn4 = new ListViewDetailColumn("Column 1", "Item Name");
		ListViewDetailColumn listViewDetailColumn5 = new ListViewDetailColumn("Column 3", "Ext. Price");
		lblTitle = new Label();
		btnCancel = new Button();
		lblNewOrders = new Class24();
		lblConfirmedOrders = new Class24();
		verticalScrollControl1 = new VerticalScrollControl();
		lvOrders = new CustomListViewTelerik();
		lvItems = new CustomListViewTelerik();
		label2 = new Label();
		label1 = new Label();
		label8 = new Label();
		verticalScrollControl2 = new VerticalScrollControl();
		timer_0 = new Timer(icontainer_1);
		lblOrderInfo = new RadLabel();
		pnlConfirmation = new FlowLayoutPanel();
		label3 = new Label();
		btnConfirmFulfillmentTime = new Button();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		btnCustomMins = new Button();
		btnReject = new Button();
		lblRejectedOrder = new Class24();
		((ISupportInitialize)lvOrders).BeginInit();
		((ISupportInitialize)lvItems).BeginInit();
		((ISupportInitialize)lblOrderInfo).BeginInit();
		pnlConfirmation.SuspendLayout();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		lblNewOrders.BackColor = Color.SandyBrown;
		componentResourceManager.ApplyResources(lblNewOrders, "lblNewOrders");
		lblNewOrders.Name = "lblNewOrders";
		lblNewOrders.UseMnemonic = false;
		lblNewOrders.method_1("NEW ORDERS");
		lblNewOrders.Click += lblNewOrders_Click;
		lblConfirmedOrders.BackColor = Color.FromArgb(176, 124, 219);
		componentResourceManager.ApplyResources(lblConfirmedOrders, "lblConfirmedOrders");
		lblConfirmedOrders.Name = "lblConfirmedOrders";
		lblConfirmedOrders.UseMnemonic = false;
		lblConfirmedOrders.method_1("CONFIRMED ORDERS");
		lblConfirmedOrders.Click += BpfuZottDo;
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "twobuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = lvOrders;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.Name = "verticalScrollControl1";
		lvOrders.AllowArbitraryItemHeight = true;
		lvOrders.AllowEdit = false;
		lvOrders.AllowRemove = false;
		componentResourceManager.ApplyResources(lvOrders, "lvOrders");
		listViewDetailColumn.HeaderText = "OrderNumber";
		listViewDetailColumn.Width = 170f;
		listViewDetailColumn2.HeaderText = "OrderDate";
		listViewDetailColumn2.Width = 115f;
		lvOrders.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2);
		lvOrders.EnableCustomGrouping = true;
		lvOrders.EnableKineticScrolling = true;
		lvOrders.GroupIndent = 0;
		lvOrders.GroupItemSize = new Size(300, 60);
		lvOrders.ItemSize = new Size(200, 40);
		lvOrders.ItemSpacing = -1;
		lvOrders.Name = "lvOrders";
		lvOrders.ShowColumnHeaders = false;
		lvOrders.ShowGridLines = true;
		lvOrders.ShowGroups = true;
		lvOrders.ViewType = ListViewType.DetailsView;
		lvOrders.SelectedItemChanged += lvOrders_SelectedItemChanged;
		lvItems.AllowArbitraryItemHeight = true;
		lvItems.AllowEdit = false;
		lvItems.AllowRemove = false;
		componentResourceManager.ApplyResources(lvItems, "lvItems");
		listViewDetailColumn3.HeaderText = "Qty";
		listViewDetailColumn3.Width = 40f;
		listViewDetailColumn4.HeaderText = "Item Name";
		listViewDetailColumn4.Width = 242f;
		listViewDetailColumn5.HeaderText = "Ext. Price";
		listViewDetailColumn5.Width = 90f;
		lvItems.Columns.AddRange(listViewDetailColumn3, listViewDetailColumn4, listViewDetailColumn5);
		lvItems.EnableCustomGrouping = true;
		lvItems.EnableKineticScrolling = true;
		lvItems.GroupIndent = 0;
		lvItems.GroupItemSize = new Size(300, 60);
		lvItems.ItemSize = new Size(200, 40);
		lvItems.ItemSpacing = -1;
		lvItems.Name = "lvItems";
		lvItems.ShowColumnHeaders = false;
		lvItems.ShowGridLines = true;
		lvItems.ShowGroups = true;
		lvItems.ViewType = ListViewType.DetailsView;
		label2.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label1.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label8.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(verticalScrollControl2, "verticalScrollControl2");
		verticalScrollControl2.BackColor = Color.Transparent;
		verticalScrollControl2.ButtonDownEventOverride = null;
		verticalScrollControl2.ButtonLastEventOverride = null;
		verticalScrollControl2.ButtonStyle = "fourbuttons";
		verticalScrollControl2.ConnectedPanel = null;
		verticalScrollControl2.ConnectedRadListView = lvItems;
		verticalScrollControl2.inputedHeight = 0;
		verticalScrollControl2.inputedWidth = 0;
		verticalScrollControl2.Name = "verticalScrollControl2";
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(lblOrderInfo, "lblOrderInfo");
		lblOrderInfo.BackColor = Color.FromArgb(64, 64, 64);
		lblOrderInfo.ForeColor = Color.White;
		lblOrderInfo.Name = "lblOrderInfo";
		pnlConfirmation.Controls.Add(label3);
		pnlConfirmation.Controls.Add(btnConfirmFulfillmentTime);
		pnlConfirmation.Controls.Add(button_0);
		pnlConfirmation.Controls.Add(button_1);
		pnlConfirmation.Controls.Add(button_2);
		pnlConfirmation.Controls.Add(button_3);
		pnlConfirmation.Controls.Add(button_4);
		pnlConfirmation.Controls.Add(btnCustomMins);
		pnlConfirmation.Controls.Add(btnReject);
		componentResourceManager.ApplyResources(pnlConfirmation, "pnlConfirmation");
		pnlConfirmation.Name = "pnlConfirmation";
		label3.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label3.Tag = "2,0";
		btnConfirmFulfillmentTime.BackColor = Color.FromArgb(55, 141, 80);
		btnConfirmFulfillmentTime.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnConfirmFulfillmentTime.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnConfirmFulfillmentTime, "btnConfirmFulfillmentTime");
		btnConfirmFulfillmentTime.ForeColor = Color.White;
		btnConfirmFulfillmentTime.Name = "btnConfirmFulfillmentTime";
		btnConfirmFulfillmentTime.UseVisualStyleBackColor = false;
		btnConfirmFulfillmentTime.Click += btnConfirmFulfillmentTime_Click;
		button_0.BackColor = Color.FromArgb(70, 203, 116);
		button_0.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button_0.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_0, "btn15Mins");
		button_0.ForeColor = Color.White;
		button_0.Name = "btn15Mins";
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		button_1.BackColor = Color.FromArgb(70, 203, 116);
		button_1.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button_1.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_1, "btn20Mins");
		button_1.ForeColor = Color.White;
		button_1.Name = "btn20Mins";
		button_1.UseVisualStyleBackColor = false;
		button_1.Click += button_1_Click;
		button_2.BackColor = Color.FromArgb(65, 168, 95);
		button_2.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button_2.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_2, "btn30Mins");
		button_2.ForeColor = Color.White;
		button_2.Name = "btn30Mins";
		button_2.UseVisualStyleBackColor = false;
		button_2.Click += button_2_Click;
		button_3.BackColor = Color.FromArgb(65, 168, 95);
		button_3.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button_3.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_3, "btn45Mins");
		button_3.ForeColor = Color.White;
		button_3.Name = "btn45Mins";
		button_3.UseVisualStyleBackColor = false;
		button_3.Click += button_3_Click;
		button_4.BackColor = Color.FromArgb(55, 141, 80);
		button_4.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		button_4.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_4, "btn60Mins");
		button_4.ForeColor = Color.White;
		button_4.Name = "btn60Mins";
		button_4.UseVisualStyleBackColor = false;
		button_4.Click += button_4_Click;
		btnCustomMins.BackColor = Color.FromArgb(77, 174, 225);
		btnCustomMins.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnCustomMins.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCustomMins, "btnCustomMins");
		btnCustomMins.ForeColor = Color.White;
		btnCustomMins.Name = "btnCustomMins";
		btnCustomMins.UseVisualStyleBackColor = false;
		btnCustomMins.Click += btnCustomMins_Click;
		btnReject.BackColor = Color.SandyBrown;
		btnReject.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnReject.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnReject, "btnReject");
		btnReject.ForeColor = Color.White;
		btnReject.Name = "btnReject";
		btnReject.UseVisualStyleBackColor = false;
		btnReject.Click += btnReject_Click;
		lblRejectedOrder.BackColor = Color.FromArgb(176, 124, 219);
		componentResourceManager.ApplyResources(lblRejectedOrder, "lblRejectedOrder");
		lblRejectedOrder.Name = "lblRejectedOrder";
		lblRejectedOrder.UseMnemonic = false;
		lblRejectedOrder.method_1("REJECTED ORDERS");
		lblRejectedOrder.Click += lblRejectedOrder_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lblRejectedOrder);
		base.Controls.Add(pnlConfirmation);
		base.Controls.Add(lblOrderInfo);
		base.Controls.Add(verticalScrollControl2);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(label8);
		base.Controls.Add(lvItems);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(lblConfirmedOrders);
		base.Controls.Add(lblNewOrders);
		base.Controls.Add(btnCancel);
		base.Controls.Add(lblTitle);
		base.Controls.Add(lvOrders);
		base.Name = "frmOnlineOrders";
		base.Opacity = 1.0;
		base.Load += frmOnlineOrders_Load;
		base.Controls.SetChildIndex(lvOrders, 0);
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(lblNewOrders, 0);
		base.Controls.SetChildIndex(lblConfirmedOrders, 0);
		base.Controls.SetChildIndex(verticalScrollControl1, 0);
		base.Controls.SetChildIndex(lvItems, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(verticalScrollControl2, 0);
		base.Controls.SetChildIndex(lblOrderInfo, 0);
		base.Controls.SetChildIndex(pnlConfirmation, 0);
		base.Controls.SetChildIndex(lblRejectedOrder, 0);
		((ISupportInitialize)lvOrders).EndInit();
		((ISupportInitialize)lvItems).EndInit();
		((ISupportInitialize)lblOrderInfo).EndInit();
		pnlConfirmation.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_6(Order order_0)
	{
		return order_0.OrderNumber == string_2;
	}
}
