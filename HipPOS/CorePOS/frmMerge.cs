using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmMerge : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public List<Guid> sharedOrderIDs;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CLoadFormProcedure_003Eb__4(Order o)
		{
			return !sharedOrderIDs.Contains(o.OrderId);
		}
	}

	private short short_0;

	private short short_1;

	private string[] string_0;

	private FormHelper formHelper_0;

	private OrderMethods PxCfQuDemM;

	private Font font_0;

	private string string_1;

	private string string_2;

	private List<OrderResult> list_2;

	private PrintHelper printHelper_0;

	private ListView listView_0;

	private ListView listView_1;

	private IContainer icontainer_1;

	internal Panel BillsPanel;

	internal Button btnSave;

	internal Panel Panel1;

	internal Button BtnCancel;

	internal Timer timer_0;

	private Label label8;

	private Label lblToolTip;

	private VerticalScrollControl vScrollBillsPanel;

	public frmMerge(string cus, string ot)
	{
		Class26.Ggkj0JxzN9YmC();
		short_0 = 320;
		short_1 = 5;
		string_0 = new string[101];
		formHelper_0 = new FormHelper();
		PxCfQuDemM = new OrderMethods(new GClass6());
		printHelper_0 = new PrintHelper();
		base._002Ector();
		string_1 = ot;
		string_2 = cus;
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		vScrollBillsPanel.ConnectedPanel = BillsPanel;
	}

	private void frmMerge_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		BillsPanel.Controls.Clear();
		short num = 0;
		int num2 = 0;
		int num3 = 0;
		font_0 = new Font("Arial", 10f, FontStyle.Regular);
		_ = Application.StartupPath;
		BillsPanel.SendToBack();
		List<Order> source = (from x in PxCfQuDemM.OpenOrders()
			where x.OrderType != OrderTypes.DineIn && !x.Paid
			select x).ToList();
		List<Order> source2 = source.Where((Order x) => x.ShareItemID.HasValue).ToList();
		CS_0024_003C_003E8__locals0.sharedOrderIDs = source2.Select((Order y) => y.ShareItemID.Value).ToList();
		List<Guid> collection = source2.Select((Order y) => y.OrderId).ToList();
		CS_0024_003C_003E8__locals0.sharedOrderIDs.AddRange(collection);
		List<OrderResult> source3 = (from o in source
			where !CS_0024_003C_003E8__locals0.sharedOrderIDs.Contains(o.OrderId)
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
				SeatNum = Convert.ToInt16(o.SeatNum)
			}).Distinct().ToList();
		list_2 = (from a in source3
			where a.OrderNumber != "" && a.OrderNumber != null
			select a into y
			orderby y.SeatNum
			select y into x
			group x by x.OrderNumber into y
			select y.First()).ToList();
		foreach (OrderResult item in list_2)
		{
			string_0[num] = item.OrderNumber;
			method_4(item.Customer, item.OrderNumber, num2, num3);
			if (num2 == 2)
			{
				num3++;
				num2 = -1;
			}
			num2++;
			num = (short)(num + 1);
		}
		foreach (OrderResult item2 in (IEnumerable<OrderResult>)list_2)
		{
			if (!string.IsNullOrEmpty(item2.OrderNumber))
			{
				formHelper_0.addItemsToList((ListView)BillsPanel.Controls.Find(item2.OrderNumber, searchAllChildren: false).FirstOrDefault(), item2.OrderNumber, null, 8f, isUnpaidOrdersOnly: true);
			}
		}
	}

	private void method_4(string string_3, string string_4, int int_0, int int_1)
	{
		ListView listView = new ListView();
		listView.Name = string_4.ToString();
		listView.Tag = string_3;
		listView.Font = font_0;
		listView.View = View.Details;
		string text = ((string_3.Length > 1) ? (Resources.Items_for_Customer + string_3) : Resources.Items);
		listView.Columns.Add("Qty", 35, HorizontalAlignment.Right);
		listView.Columns.Add(text, 210, HorizontalAlignment.Left);
		listView.Columns.Add(Resources.Price, 60, HorizontalAlignment.Right);
		listView.MultiSelect = false;
		listView.FullRowSelect = true;
		listView.GridLines = true;
		listView.Size = new Size(short_0, short_0 - 150);
		listView.Location = new Point(int_0 * short_0 + (int_0 + 1) * short_1, int_1 * (short_0 - 150) + (int_1 + 1) * short_1);
		listView.MouseUp += method_5;
		BillsPanel.Controls.Add(listView);
		listView.BringToFront();
	}

	private void method_5(object sender, MouseEventArgs e)
	{
		if (listView_0 == null)
		{
			listView_0 = (ListView)sender;
			listView_0.BackColor = Color.LightBlue;
			return;
		}
		if (listView_0 != null && listView_0 == (ListView)sender)
		{
			listView_0.BackColor = Color.White;
			listView_0 = null;
			return;
		}
		listView_1 = (ListView)sender;
		foreach (ListViewItem item in listView_0.Items)
		{
			item.Remove();
			listView_1.Items.Insert(listView_1.Items.Count, item);
		}
		listView_0.BackColor = Color.White;
		listView_0 = (listView_1 = null);
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		foreach (OrderResult item in (IEnumerable<OrderResult>)list_2)
		{
			ListView listView = (ListView)BillsPanel.Controls.Find(item.OrderNumber, searchAllChildren: false).FirstOrDefault();
			if (listView == null || listView.Items.Count <= 0)
			{
				continue;
			}
			string name = listView.Name;
			string customer = listView.Tag.ToString();
			for (short num = 0; num <= listView.Items.Count - 1; num = (short)(num + 1))
			{
				listView.Items[num].Selected = true;
				if (!listView.SelectedItems[0].SubItems[0].Text.Contains("DISCOUNT"))
				{
					string[] array = listView.SelectedItems[0].SubItems[6].Text.Split('|');
					foreach (string g in array)
					{
						Guid id = new Guid(g);
						PxCfQuDemM.GetOrder(id).OrderNumber = name;
						PxCfQuDemM.GetOrder(id).Customer = customer;
						PxCfQuDemM.SubmitChanges();
					}
				}
			}
		}
		base.DialogResult = DialogResult.OK;
		Close();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMerge));
		timer_0 = new Timer(icontainer_1);
		vScrollBillsPanel = new VerticalScrollControl();
		BillsPanel = new Panel();
		Panel1 = new Panel();
		lblToolTip = new Label();
		label8 = new Label();
		btnSave = new Button();
		BtnCancel = new Button();
		Panel1.SuspendLayout();
		SuspendLayout();
		timer_0.Interval = 1000;
		componentResourceManager.ApplyResources(vScrollBillsPanel, "vScrollBillsPanel");
		vScrollBillsPanel.BackColor = Color.FromArgb(95, 95, 95);
		vScrollBillsPanel.ButtonStyle = "fourbuttons";
		vScrollBillsPanel.ConnectedPanel = null;
		vScrollBillsPanel.ConnectedRadListView = null;
		vScrollBillsPanel.inputedHeight = 0;
		vScrollBillsPanel.inputedWidth = 0;
		vScrollBillsPanel.Name = "vScrollBillsPanel";
		componentResourceManager.ApplyResources(BillsPanel, "BillsPanel");
		BillsPanel.Name = "BillsPanel";
		componentResourceManager.ApplyResources(Panel1, "Panel1");
		Panel1.BorderStyle = BorderStyle.FixedSingle;
		Panel1.Controls.Add(lblToolTip);
		Panel1.Controls.Add(label8);
		Panel1.Controls.Add(btnSave);
		Panel1.Controls.Add(BtnCancel);
		Panel1.Name = "Panel1";
		componentResourceManager.ApplyResources(lblToolTip, "lblToolTip");
		lblToolTip.BackColor = Color.LemonChiffon;
		lblToolTip.Name = "lblToolTip";
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.Black;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(vScrollBillsPanel);
		base.Controls.Add(BillsPanel);
		base.Controls.Add(Panel1);
		base.MaximizeBox = false;
		base.Name = "frmMerge";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.Load += frmMerge_Load;
		Panel1.ResumeLayout(performLayout: false);
		Panel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
