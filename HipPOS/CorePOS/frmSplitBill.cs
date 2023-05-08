using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmSplitBill : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public string listid;

		public _003C_003Ec__DisplayClass48_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public Item itemFromDB;

		public _003C_003Ec__DisplayClass63_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass72_0
	{
		public decimal qty;

		public string itemName;

		public _003C_003Ec__DisplayClass72_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private short short_0;

	private short short_1;

	private short short_2;

	private int int_0;

	private int int_1;

	private bool bool_0;

	private GClass6 gclass6_0;

	private OrderHelper orderHelper_0;

	private DataManager dataManager_0;

	private OrderMethods orderMethods_0;

	private Font font_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private int int_2;

	private string string_5;

	private short short_3;

	private short short_4;

	private decimal decimal_0;

	private string string_6;

	private string string_7;

	private int int_3;

	private FormHelper formHelper_0;

	private ListView listView_0;

	private ListView listView_1;

	private List<ListView> list_2;

	private List<string> list_3;

	private IQueryable<Order> iqueryable_0;

	private string string_8;

	private bool bool_1;

	private Image image_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	[CompilerGenerated]
	private List<string> list_4;

	[CompilerGenerated]
	private string string_9;

	private int int_4;

	private int int_5;

	private int int_6;

	private List<Item> list_5;

	private bool bool_5;

	private IContainer icontainer_1;

	internal Panel BillsPanel;

	internal Button BtnCancel;

	internal Button btnSaveClose;

	private Label lblOrderType;

	private Label lblCustomer;

	private Label wjeFkDmlMy6;

	internal Button btnAddBill;

	internal Button btnShareItem;

	internal Button btnStartOver;

	internal Button btnSave;

	internal Button btnPrint;

	internal Button btnSplitEvenly;

	private VerticalScrollControl verticalScrollControl1;

	internal Button btnSaveEdit;

	public List<string> OrdersUpdated
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		set
		{
			list_4 = value;
		}
	}

	public string LastValidOrderNumber
	{
		[CompilerGenerated]
		get
		{
			return string_9;
		}
		[CompilerGenerated]
		set
		{
			string_9 = value;
		}
	}

	public frmSplitBill(string cus, string ot, string oid, int guestCount = 2, decimal percentageDiscount = 0m)
	{
		Class26.Ggkj0JxzN9YmC();
		short_0 = 260;
		short_1 = 200;
		short_2 = 10;
		gclass6_0 = new GClass6();
		orderHelper_0 = new OrderHelper();
		dataManager_0 = new DataManager();
		string_6 = "";
		string_7 = "";
		int_3 = 2;
		formHelper_0 = new FormHelper();
		list_2 = new List<ListView>();
		list_3 = new List<string>();
		list_5 = new List<Item>();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		string_1 = cus;
		string_0 = ot;
		string_5 = oid;
		int_3 = guestCount;
		OrdersUpdated = new List<string>();
		verticalScrollControl1.ConnectedPanel = BillsPanel;
		decimal_0 = percentageDiscount;
	}

	private void frmSplitBill_FormClosing(object sender, EventArgs e)
	{
		gclass6_0 = null;
		orderHelper_0 = null;
		orderMethods_0 = null;
		formHelper_0 = null;
		if (image_0 != null)
		{
			image_0.Dispose();
		}
		font_0.Dispose();
		GC.Collect();
	}

	private void method_3()
	{
		ControlHelpers.ClearControlsInPanel(BillsPanel);
		int_0 = 0;
		int_1 = 0;
		iqueryable_0 = gclass6_0.Orders.Where((Order o) => o.Customer == string_1 && o.OrderType == string_0 && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && o.Void == false && o.Paid == false);
		Order order = iqueryable_0.FirstOrDefault();
		if (order == null)
		{
			new NotificationLabel(this, "Order is either paid or voided.", NotificationTypes.Warning).Show();
			return;
		}
		int_2 = (order.CustomerID.HasValue ? order.CustomerID.Value : 0);
		string_2 = order.CustomerInfo;
		string_3 = order.CustomerInfoName;
		string_4 = order.CustomerInfoPhone;
		foreach (Order item in iqueryable_0.ToList())
		{
			if (!(OrderHelper.GetDiscountFromDiscountDescription(item.DiscountDesc, DiscountTypes.Order) > 0m) && !(OrderHelper.GetDiscountFromDiscountDescription(item.DiscountDesc, DiscountTypes.Item) > 0m))
			{
				if (OrderHelper.GetDiscountFromDiscountDescription(item.DiscountDesc, DiscountTypes.Promo) > 0m)
				{
					bool_4 = true;
					break;
				}
				continue;
			}
			bool_3 = true;
			break;
		}
		if (decimal_0 > 0m)
		{
			string_6 = order.DiscountReason;
			string_7 = order.DiscountDesc;
		}
		list_3.Clear();
		if (string_0 == OrderTypes.DineIn)
		{
			if (short_4 == 0)
			{
				short_4 = iqueryable_0.Max((Order o) => Convert.ToInt16(o.SeatNum));
				if (short_4 == 1)
				{
					short_4 = 2;
				}
			}
			short_3 = short_4;
			for (int i = 1; i <= short_3; i++)
			{
				IliFtzwapVs(i.ToString());
			}
		}
		else
		{
			List<string> list = (from a in iqueryable_0
				group a by a.OrderNumber into a
				select a.Key).ToList();
			short_3 = (short)(from a in iqueryable_0
				group a by a.OrderNumber).Count();
			short_4 = short_3;
			string_8 = list.First();
			foreach (string item2 in list)
			{
				IliFtzwapVs(item2);
			}
			if (short_3 == 1)
			{
				method_11();
			}
		}
		method_12();
		BillsPanel.VerticalScroll.Value = 0;
	}

	private void frmSplitBill_Load(object sender, EventArgs e)
	{
		orderMethods_0 = new OrderMethods(gclass6_0);
		short_0 = (short)((BillsPanel.Width - short_2) / 3 - 2 * short_2);
		short_1 = (short)((BillsPanel.Height - short_2) / 2 - 3 * short_2);
		int_0 = 0;
		int_1 = 0;
		font_0 = new Font("Arial", 10f, FontStyle.Regular);
		method_3();
		new FormHelper().ResizeButtonFonts(this);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			btnShareItem.Font = new Font(btnShareItem.Font.FontFamily, btnShareItem.Font.Size - 0.75f);
			btnAddBill.Font = new Font(btnAddBill.Font.FontFamily, btnAddBill.Font.Size - 1.5f);
			btnAddBill.Padding = new Padding(0, 1, 0, 0);
			btnSaveClose.Font = new Font(btnSaveClose.Font.FontFamily, btnSaveClose.Font.Size - 1.5f);
			btnSaveClose.Padding = new Padding(0, 1, 0, 0);
			btnSaveEdit.Font = new Font(btnSaveEdit.Font.FontFamily, btnSaveEdit.Font.Size - 1.5f);
			btnSaveEdit.Padding = new Padding(0, 1, 0, 0);
		}
		lblOrderType.Text = string_0 + " : ";
		lblCustomer.Text = string_1;
		Button button = btnSave;
		Button button2 = btnSaveClose;
		Button button3 = btnSaveEdit;
		btnStartOver.Enabled = false;
		button3.Enabled = false;
		button2.Enabled = false;
		button.Enabled = false;
	}

	private void IliFtzwapVs(string string_10)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.listid = string_10;
		BillsPanel.VerticalScroll.Value = 0;
		Label label = new Label();
		label.Size = new Size(short_0, 30);
		label.ForeColor = Color.White;
		label.Location = new Point(int_0 * short_0 + (int_0 + 1) * short_2, int_1 * short_1 + (int_1 + 1) * short_2 + int_1 * label.Size.Height);
		label.TextAlign = ContentAlignment.MiddleLeft;
		if (string_0 == OrderTypes.DineIn)
		{
			label.BackColor = ColorHelper.smethod_0(Convert.ToInt16(CS_0024_003C_003E8__locals0.listid));
		}
		label.Font = new Font("Arial", 14f, FontStyle.Regular);
		if (string_0 == OrderTypes.DineIn)
		{
			label.Text = Resources.SEAT + CS_0024_003C_003E8__locals0.listid;
		}
		else
		{
			label.Text = Resources.Order + " " + CS_0024_003C_003E8__locals0.listid;
		}
		ListView listView = new ListView();
		listView.Name = CS_0024_003C_003E8__locals0.listid;
		listView.Font = font_0;
		listView.View = View.Details;
		listView.Columns.Add("Qty", 40, HorizontalAlignment.Left);
		listView.Columns.Add(Resources.Items, short_0 - 170, HorizontalAlignment.Left);
		listView.Columns.Add(Resources.Price, 50, HorizontalAlignment.Right);
		listView.Columns.Add(Resources.Ext_Price, 60, HorizontalAlignment.Right);
		listView.MultiSelect = false;
		listView.FullRowSelect = true;
		listView.GridLines = true;
		listView.Size = new Size(short_0, short_1);
		listView.Location = new Point(label.Location.X, label.Location.Y + label.Height);
		listView.Tag = string_0 + "|" + string_1 + "|" + string_3;
		listView.ColumnWidthChanged += method_4;
		listView.MouseUp += method_5;
		BillsPanel.Controls.Add(label);
		BillsPanel.Controls.Add(listView);
		listView.BringToFront();
		listView.Focus();
		string text = "";
		text = ((!(string_0 == OrderTypes.DineIn)) ? (from o in iqueryable_0
			where o.OrderNumber == CS_0024_003C_003E8__locals0.listid
			select o.OrderNumber).FirstOrDefault() : (from o in iqueryable_0
			where o.SeatNum == CS_0024_003C_003E8__locals0.listid
			select o.OrderNumber).FirstOrDefault());
		if (!string.IsNullOrEmpty(text))
		{
			list_3.Add(text);
			formHelper_0.addItemsToList(listView, text, null, listView.Font.Size, isUnpaidOrdersOnly: true);
		}
		if (int_0 == 2)
		{
			int_1++;
			int_0 = -1;
		}
		int_0++;
	}

	private void method_4(object sender, ColumnWidthChangedEventArgs e)
	{
		ListView listView = sender as ListView;
		if (listView.Columns[e.ColumnIndex].Width < 50)
		{
			listView.Columns[e.ColumnIndex].Width = 50;
		}
	}

	private void method_5(object sender, MouseEventArgs e)
	{
		if (listView_0 == null)
		{
			if (((ListView)sender).SelectedIndices.Count > 0)
			{
				if (!((ListView)sender).SelectedItems[0].Font.Strikeout)
				{
					listView_0 = (ListView)sender;
					btnStartOver.Enabled = true;
				}
				else
				{
					new NotificationLabel(this, Resources.Please_select_an_item_that_has, NotificationTypes.Warning).Show();
					((ListView)sender).Items[((ListView)sender).SelectedIndices[0]].Selected = false;
				}
			}
		}
		else if (listView_0 != null && bool_0)
		{
			if (listView_0 != (ListView)sender && !list_2.Contains((ListView)sender))
			{
				list_2.Add((ListView)sender);
				TransparentLabel transparentLabel = new TransparentLabel();
				transparentLabel.TransparentBackColor = ColorPalette.Energy;
				transparentLabel.Opacity = 70;
				transparentLabel.Size = ((ListView)sender).Size;
				transparentLabel.Location = ((ListView)sender).Location;
				transparentLabel.Name = "selected_tlbl" + ((ListView)sender).Name;
				BillsPanel.Controls.Add(transparentLabel);
				transparentLabel.BringToFront();
				btnStartOver.Enabled = true;
			}
		}
		else if (listView_0 != (ListView)sender && !bool_0)
		{
			listView_1 = (ListView)sender;
			method_6(sender, listView_0, listView_0.Font.Size);
			btnStartOver.Enabled = true;
		}
		else
		{
			listView_0 = null;
			listView_1 = null;
			btnStartOver.Enabled = false;
		}
	}

	private void method_6(object object_0, ListView listView_2, float float_0 = 8f)
	{
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		int int_4 = 0;
		int int_5 = 0;
		int int_6 = 0;
		method_8(listView_2, out var string_, out var string_2, out var string_3, out var string_4, out int_, out int_2, out int_3, out var string_5, out var bool_, out var string_6, out int_4, out int_5, out var string_7, out var string_8, out var string_9, out int_6, listView_2.SelectedItems[0].Index);
		int index = listView_2.SelectedItems[0].Index;
		if (!listView_2.Items[index].SubItems[1].Text.Contains("SUB:") && !listView_2.Items[index].SubItems[1].Text.Contains("ADD:") && !listView_2.Items[index].SubItems[1].Text.Contains("DISCOUNT") && !listView_2.Items[index].SubItems[1].Text.Contains("OPT:"))
		{
			ListView listView = (ListView)object_0;
			decimal num = default(decimal);
			List<ListViewItem> list = new List<ListViewItem>();
			bool flag = false;
			foreach (ListViewItem item2 in listView.Items)
			{
				string[] array = item2.SubItems[6].Text.Split('|');
				if (array.Length > 1 && array[1] == string_5)
				{
					flag = true;
				}
				list.Add(item2);
			}
			List<ListViewItem> list2 = new List<ListViewItem>();
			if (int_2 != 0)
			{
				foreach (ListViewItem item3 in listView_2.Items)
				{
					list2.Add(item3);
				}
			}
			else
			{
				list2.Add(listView_2.SelectedItems[0]);
			}
			int num2 = 0;
			decimal num3 = 1m;
			foreach (ListViewItem item4 in list2)
			{
				if (Convert.ToInt32(item4.SubItems[5].Text) != int_2 || item4.Font.Strikeout || item4.Index < 0)
				{
					continue;
				}
				method_8(listView_2, out string_, out string_2, out string_3, out string_4, out int_, out int_2, out int_3, out string_5, out bool_, out string_6, out int_4, out int_5, out string_7, out string_8, out string_9, out int_6, item4.Index);
				if (MathHelper.FractionToDecimal(string_) > 1m)
				{
					if (num2 == 0)
					{
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
						MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Qty_To_Move, 4, string_.Length + 4, string_.ToString());
						if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
						{
							return;
						}
						num = MemoryLoadedObjects.Numpad.numberEntered;
						if (num > MathHelper.FractionToDecimal(string_) || num <= 0m)
						{
							new NotificationLabel(this, Resources.Action_not_allowed_Invalid_Qua, NotificationTypes.Warning).Show();
							method_7();
							return;
						}
						if (num < MathHelper.FractionToDecimal(string_))
						{
							string_5 = Guid.NewGuid().ToString();
						}
						num3 = num / MathHelper.FractionToDecimal(string_);
					}
					else
					{
						num = num3 * MathHelper.FractionToDecimal(string_);
						if (num < MathHelper.FractionToDecimal(string_))
						{
							string_5 = Guid.NewGuid().ToString();
						}
					}
				}
				else
				{
					num = MathHelper.FractionToDecimal(string_);
				}
				int num4 = int_2;
				if (int_2 != 0)
				{
					foreach (ListViewItem item5 in list)
					{
						if (int_2 == Convert.ToInt32(item5.SubItems[5].Text ?? "0"))
						{
							num4++;
						}
					}
				}
				decimal num5 = MathHelper.FractionToDecimal(string_) - num;
				bool flag2 = false;
				int count = listView.Items.Count;
				if (num5 <= 0m)
				{
					if (!string.IsNullOrEmpty(string_5))
					{
						if (!string_5.Contains("|") && !flag)
						{
							formHelper_0.subAddItemsToList(listView, MathHelper.DecimalToFraction(num).ToString(), string_2, string_3, int_, num4, int_3, string_5, bool_, string_6, int_4, int_5, null, float_0, string_8, -1, 0m, string_7, int_6, string_9, item4);
							item4.Remove();
							flag2 = true;
						}
						else
						{
							item4.Font = new Font(item4.Font, FontStyle.Strikeout);
							foreach (ListViewItem item6 in listView.Items)
							{
								if (item6.SubItems[6].Text == string_5)
								{
									formHelper_0.subAddItemsToList(listView, MathHelper.DecimalToFraction(num).ToString(), string_2, string_3, int_, num4, int_3, string_5, bool_, string_6, int_4, int_5, null, float_0, string_8, -1, 0m, string_7, int_6, string_9, item4);
									item4.Remove();
									flag2 = true;
								}
							}
						}
					}
					else
					{
						item4.Font = new Font(item4.Font, FontStyle.Strikeout);
					}
				}
				else
				{
					item4.SubItems[0].Text = MathHelper.RemoveTrailingZeros(num5.ToString("0.##"));
					item4.SubItems[3].Text = (MathHelper.ToDecimal(item4.SubItems[3].Text) - num * MathHelper.ToDecimal(item4.SubItems[2].Text)).ToString("0.00");
					FormHelper.ChangeOrderEntryLVWinformsCellByIdentifier(listView_2, item4, listView_2.Font.Size, item4.SubItems[16].Text);
					formHelper_0.subAddItemsToList(listView, MathHelper.DecimalToFraction(num).ToString(), string_2, string_3, int_, num4, int_3, string_5, bool_, string_6, int_4, int_5, null, float_0, string_8, -1, 0m, item4.SubItems[15].Text, int_6, string_9, item4);
					flag2 = true;
				}
				if (!flag2)
				{
					formHelper_0.subAddItemsToList(listView, MathHelper.DecimalToFraction(num).ToString(), string_2, string_3, int_, num4, int_3, string_5, bool_, string_6, int_4, int_5, null, float_0, string_8, -1, 0m, item4.SubItems[15].Text, int_6, string_9, item4);
					if (count < listView.Items.Count)
					{
						item4.Remove();
					}
				}
				num2++;
			}
			for (int i = 1; i <= 2 && index + i < listView_2.Items.Count; i++)
			{
				if (index >= listView_2.Items.Count - 1)
				{
					break;
				}
				if (!listView_2.Items[index + i].SubItems[0].Text.Contains("SUB:") && !listView_2.Items[index + i].SubItems[0].Text.Contains("ADD:") && !listView_2.Items[index + i].SubItems[0].Text.Contains("DISCOUNT"))
				{
					break;
				}
				method_8(listView_2, out string_, out string_2, out string_3, out string_4, out int_, out int_2, out int_3, out string_5, out bool_, out string_6, out int_4, out int_5, out string_7, out string_8, out string_9, out int_6, index + i);
				if (Convert.ToDecimal(string_) > 1m)
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
					MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Qty_To_Move, 0, string_.Length, string_.ToString());
					if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
					{
						num = Convert.ToDecimal(MemoryLoadedObjects.Numpad);
						if (num > MathHelper.FractionToDecimal(string_))
						{
							new NotificationLabel(this, Resources.Action_not_allowed_Invalid_Qua, NotificationTypes.Warning).Show();
							method_7();
							return;
						}
						if (num < MathHelper.FractionToDecimal(string_))
						{
							string_5 = string.Empty;
						}
					}
					else
					{
						MemoryLoadedObjects.Numpad.Hide();
					}
				}
				else
				{
					num = 1m;
				}
				formHelper_0.subAddItemsToList(listView, MathHelper.DecimalToFraction(num).ToString(), string_2, string_3, int_, int_2, int_3, string_5, bool_, string_6, int_4, int_5, null, float_0, string_8, -1, 0m, string_7, int_6, string_9, listView_2.Items[index + i]);
			}
			new List<int>();
			foreach (ListViewItem item7 in listView_2.Items)
			{
				if (item7.Font.Strikeout && item7.SubItems[6].Text.Contains("11111111-1111-1111-1111-111111111111|"))
				{
					item7.Remove();
				}
			}
			method_12();
			method_7();
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_main_item_and_su, NotificationTypes.Warning).Show();
			method_7();
		}
	}

	private void method_7()
	{
		listView_0 = null;
		listView_1 = null;
		foreach (ListView item in list_2)
		{
			((TransparentLabel)BillsPanel.Controls.Find("selected_tlbl" + item.Name, searchAllChildren: false).FirstOrDefault())?.Dispose();
		}
		Button button = btnSave;
		Button button2 = btnSaveClose;
		btnSaveEdit.Enabled = true;
		button2.Enabled = true;
		button.Enabled = true;
		list_2.Clear();
		list_2 = new List<ListView>();
	}

	private void method_8(ListView listView_2, out string string_10, out string string_11, out string string_12, out string string_13, out int int_7, out int int_8, out int int_9, out string string_14, out bool bool_6, out string string_15, out int int_10, out int int_11, out string string_16, out string string_17, out string string_18, out int int_12, int int_13)
	{
		string_10 = listView_2.Items[int_13].SubItems[0].Text;
		string_11 = listView_2.Items[int_13].SubItems[1].Text;
		string_12 = listView_2.Items[int_13].SubItems[2].Text;
		string_13 = listView_2.Items[int_13].SubItems[3].Text;
		bool_6 = listView_2.Items[int_13].Font.Style.ToString().Contains("Strikeout");
		string_16 = listView_2.Items[int_13].SubItems[15].Text;
		string_17 = listView_2.Items[int_13].SubItems[16].Text;
		int_12 = Convert.ToInt32(listView_2.Items[int_13].SubItems[17].Text);
		string_18 = listView_2.Items[int_13].SubItems[19].Text;
		if (listView_2.Items[int_13].SubItems.Count > 4)
		{
			int_7 = Convert.ToInt32((!string.IsNullOrEmpty(listView_2.Items[int_13].SubItems[4].Text)) ? listView_2.Items[int_13].SubItems[4].Text : "0");
			int_8 = Convert.ToInt32(listView_2.Items[int_13].SubItems[5].Text ?? "0");
			string_14 = listView_2.Items[int_13].SubItems[6].Text;
			string_15 = listView_2.Items[int_13].SubItems[7].Text;
			int_10 = Convert.ToInt32(listView_2.Items[int_13].SubItems[9].Text);
			int_9 = Convert.ToInt32(listView_2.Items[int_13].SubItems[11].Text);
			int_11 = Convert.ToInt32(listView_2.Items[int_13].SubItems[14].Text);
		}
		else
		{
			int_7 = 0;
			int_8 = 0;
			string_14 = string.Empty;
			string_15 = string.Empty;
			int_10 = 0;
			int_9 = 0;
			int_11 = 0;
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		if (bool_1)
		{
			base.DialogResult = DialogResult.OK;
		}
		Close();
	}

	private void btnSaveClose_Click(object sender, EventArgs e)
	{
		method_9();
		Close();
	}

	private void method_9()
	{
		try
		{
			if (bool_3)
			{
				if (new frmMessageBox("Do you want to retain your discount?", "Retain Discount", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
				{
					bool_2 = true;
				}
				else
				{
					bool_2 = false;
				}
			}
			else
			{
				bool_2 = false;
			}
			int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(string_1.Replace("Table ", ""));
			int_4 = 0;
			int_5 = currentTableGuestCapacity / short_3;
			int_6 = currentTableGuestCapacity % short_3;
			if (string_0 != OrderTypes.DineIn)
			{
				OrdersUpdated = new List<string>();
				foreach (string item in list_3)
				{
					ListView listView = (ListView)BillsPanel.Controls.Find(item, searchAllChildren: false).FirstOrDefault();
					if (listView != null && listView.Items.Count > 0)
					{
						list_5.Clear();
						method_10(listView);
						new OrderMethods().SaveOrder(list_5, item.ToUpper(), string_1, string_0, int_2, "SPLIT SAVED ORDER", 0m, 0m, isPaid: false, string_2, string_6, string_3, string_4, int_5, bool_5, string.Empty, 1, null, null, 0, null, "", GratuityRemoved: false, 0);
						OrderMethods.RecheckGuestCountSplittedBill(string_1);
						int_4++;
						OrdersUpdated.Add(item);
						if (list_5.Where((Item a) => a.Active).Count() > 0)
						{
							LastValidOrderNumber = item.ToUpper();
						}
					}
				}
			}
			for (short num = 1; num <= short_3; num = (short)(num + 1))
			{
				ListView listView2 = (ListView)BillsPanel.Controls.Find(num.ToString(), searchAllChildren: false).FirstOrDefault();
				if (listView2 != null && listView2.Items.Count > 0)
				{
					string text = "";
					if (list_3.Count >= num)
					{
						text = list_3[num - 1];
					}
					else
					{
						text = OrderMethods.GetNewOrderNumber();
						list_3.Add(text);
					}
					list_5.Clear();
					method_10(listView2);
					new OrderMethods().SaveOrder(list_5, text.ToUpper(), string_1, string_0, int_2, "SPLIT SAVED ORDER", 0m, 0m, isPaid: false, string_2, string_6, string_3, string_4, int_5, bool_5, string.Empty, Convert.ToInt16(listView2.Name), null, null, 0, null, "", GratuityRemoved: false, 0);
					OrderMethods.RecheckGuestCountSplittedBill(string_1);
					int_4++;
				}
			}
			GuestMethods.UpdateTableGuestCapacity(string_1.Replace("Table ", ""), int_4, Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
			OrderMethods.LogOrderAudit(string_5, "Order Splitted -> " + string.Join(",", list_3.Distinct()));
			new NotificationLabel(this, Resources.Your_orders_have_been_saved_su, NotificationTypes.Success).Show();
		}
		catch (Exception)
		{
			new NotificationLabel(this, Resources.An_error_has_occurred_trying_t3, NotificationTypes.Warning).Show();
		}
	}

	private void method_10(ListView listView_2)
	{
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		decimal num3 = default(decimal);
		foreach (ListViewItem item2 in listView_2.Items)
		{
			_003C_003Ec__DisplayClass63_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass63_0();
			DataManager dataManager = new DataManager();
			Item item = new Item();
			CS_0024_003C_003E8__locals0.itemFromDB = dataManager.getOneItem(Convert.ToInt32(item2.SubItems[4].Text));
			item.ItemID = CS_0024_003C_003E8__locals0.itemFromDB.ItemID;
			if (!CS_0024_003C_003E8__locals0.itemFromDB.ItemsInGroups.Any())
			{
				ItemsInGroup itemsInGroup = dataManager.DataContext.ItemsInGroups.Where((ItemsInGroup x) => x.ItemID.Value == CS_0024_003C_003E8__locals0.itemFromDB.ItemID).FirstOrDefault();
				if (itemsInGroup != null)
				{
					item.ItemsInGroups.Add(itemsInGroup);
				}
			}
			else
			{
				item.ItemsInGroups = CS_0024_003C_003E8__locals0.itemFromDB.ItemsInGroups;
			}
			item.ItemType = CS_0024_003C_003E8__locals0.itemFromDB.ItemType;
			item.ItemTypeID = CS_0024_003C_003E8__locals0.itemFromDB.ItemTypeID;
			item.OnSale = CS_0024_003C_003E8__locals0.itemFromDB.OnSale;
			item.TaxRule = CS_0024_003C_003E8__locals0.itemFromDB.TaxRule;
			item.TaxRuleID = CS_0024_003C_003E8__locals0.itemFromDB.TaxRuleID;
			string value = ((item2.SubItems[2].Text == "") ? "0.00" : item2.SubItems[2].Text);
			string fraction = ((item2.SubItems[0].Text == "") ? "1" : item2.SubItems[0].Text);
			item.ItemName = item2.SubItems[1].Text;
			item.ItemPrice = Convert.ToDecimal(value);
			if (!item.ItemName.Contains("SUB:") && !item.ItemName.Contains("ADD:") && !item.ItemName.Contains("OPT:"))
			{
				item.ItemCost = ((item2.SubItems.Count < 9 || !(item2.SubItems[8].Text != "-1")) ? (-1m) : Convert.ToDecimal(item2.SubItems[8].Text));
			}
			else
			{
				item.ItemCost = Convert.ToDecimal(value);
			}
			item.InventoryCount = Convert.ToDecimal(MathHelper.FractionToDecimal(fraction));
			item.SortOrder = Convert.ToInt16(item2.SubItems[5].Text);
			item.Temp = ((item2.SubItems.Count >= 7) ? item2.SubItems[6].Text : string.Empty);
			item.Description = ((item2.SubItems.Count >= 8) ? item2.SubItems[7].Text : string.Empty);
			item.Active = !item2.Font.Strikeout;
			item.ItemCourse = ((item2.SubItems.Count >= 7) ? item2.SubItems[19].Text : "0");
			item.Notes = item2.SubItems[13].Text;
			item.StationID = item2.SubItems[14].Text;
			item.ItemSalePrice = default(decimal);
			item.Barcode = ((bool_2 || bool_4) ? item2.SubItems[15].Text : "");
			decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Item);
			if (discountFromDiscountDescription > 0m)
			{
				item.ItemSalePrice = discountFromDiscountDescription;
				item.Barcode = OrderHelper.UpdateDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Item, item.ItemSalePrice.Value);
			}
			item.ItemClassification = item2.SubItems[16].Text;
			item.ResetQty = Convert.ToInt32(item2.SubItems[17].Text);
			if (bool_4 && !bool_2)
			{
				decimal discountFromDiscountDescription2 = OrderHelper.GetDiscountFromDiscountDescription(item2.SubItems[15].Text, DiscountTypes.Promo);
				string discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(item2.SubItems[15].Text, DiscountTypes.Promo, discountFromDiscountDescription2);
				discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item, 0m);
				discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Order, 0m);
				item.Barcode = discountDesc;
			}
			if (!item2.Font.Strikeout)
			{
				num += item.ItemPrice * item.InventoryCount;
			}
			item.CloudItemID = ((int_4 < short_3 - int_6) ? int_5 : (int_5 + 1));
			list_5.Add(item);
			if (bool_2 || bool_4)
			{
				num2 += OrderHelper.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Order);
				num3 += OrderHelper.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Promo);
			}
		}
		if (bool_2 || bool_4)
		{
			decimal_0 = ((num - num3 != 0m) ? Math.Round(num2 / (num - num3), 10) : 0m);
			dataManager_0.CalculateOrderDiscount(list_5, num, decimal_0);
			bool_5 = true;
		}
	}

	private void btnAddBill_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void method_11()
	{
		if (short_3 <= 30)
		{
			short_4++;
			short_3 = short_4;
			IliFtzwapVs(short_4.ToString());
			method_12();
		}
		else
		{
			new NotificationLabel(this, "Bill count already reached the limit.", NotificationTypes.Notification).Show();
		}
	}

	private void btnShareItem_Click(object sender, EventArgs e)
	{
		if (listView_0 == null)
		{
			new NotificationLabel(this, Resources.Please_select_the_item_to_shar, NotificationTypes.Notification).Show();
		}
		else if (!listView_0.SelectedItems[0].SubItems[6].Text.Contains("|") && !(MathHelper.FractionToDecimal(listView_0.SelectedItems[0].SubItems[0].Text) < 1m))
		{
			btnStartOver.Enabled = true;
			Button button = (Button)sender;
			if (button.Image != null)
			{
				image_0 = button.Image;
			}
			if (!bool_0)
			{
				bool_0 = true;
				button.Text = Resources.DONE_SHARING;
				button.TextAlign = ContentAlignment.MiddleCenter;
				button.Image = null;
				button.BackColor = Color.FromArgb(214, 142, 81);
				new NotificationLabel(this, Resources.Please_select_the_seats_bills_, NotificationTypes.Notification).Show();
				Button button2 = btnSave;
				Button button3 = btnSaveClose;
				Button button4 = btnSaveEdit;
				listView_0.Enabled = false;
				button4.Enabled = false;
				button3.Enabled = false;
				button2.Enabled = false;
			}
			else
			{
				bool_0 = false;
				button.Text = Resources.SHARE_ITEM;
				button.TextAlign = ContentAlignment.BottomCenter;
				button.Image = image_0;
				button.BackColor = Color.FromArgb(176, 124, 219);
				Button button5 = btnSave;
				Button button6 = btnSaveClose;
				Button button7 = btnSaveEdit;
				listView_0.Enabled = true;
				button7.Enabled = true;
				button6.Enabled = true;
				button5.Enabled = true;
				ListViewItem listViewItem = listView_0.SelectedItems[0];
				method_8(listView_0, out var string_, out var string_2, out var string_3, out var string_4, out var int_, out var int_2, out var int_3, out var string_5, out var bool_, out var string_6, out var int_4, out var int_5, out var string_7, out var string_8, out var string_9, out var int_6, listView_0.SelectedItems[0].Index);
				int index = listView_0.SelectedItems[0].Index;
				if (listView_0.Items[index].SubItems[1].Text.Contains("SUB:") || listView_0.Items[index].SubItems[1].Text.Contains("ADD:") || listView_0.Items[index].SubItems[1].Text.Contains("DISCOUNT"))
				{
					new NotificationLabel(this, Resources.Please_select_main_item_and_su0, NotificationTypes.Warning).Show();
					method_7();
					return;
				}
				int num = list_2.Count + 1;
				decimal num2 = default(decimal);
				if (int_2 != 0)
				{
					foreach (ListViewItem item in listView_0.Items)
					{
						if (Convert.ToInt32(item.SubItems[5].Text) != int_2 || item.Font.Strikeout)
						{
							continue;
						}
						num2 = Math.Round(Convert.ToDecimal(MathHelper.FractionToDecimal(item.SubItems[0].Text)) / (decimal)num, 4);
						method_8(listView_0, out string_, out string_2, out string_3, out string_4, out int_, out int_2, out int_3, out string_5, out bool_, out string_6, out int_4, out int_5, out string_7, out string_8, out string_9, out int_6, item.Index);
						string_5 = "11111111-1111-1111-1111-111111111111|" + string_5;
						foreach (ListView item2 in list_2)
						{
							formHelper_0.subAddItemsToList(item2, num2.ToString(), string_2, string_3, int_, int_2, int_3, string_5, bool_, string_6, int_4, int_5, null, item2.Font.Size, string_8);
						}
						if (num2 < 1m)
						{
							item.SubItems[0].Text = MathHelper.DecimalToFraction(num2);
						}
						else
						{
							item.SubItems[0].Text = num2.ToString();
						}
						string value = ((item.SubItems[2].Text == "") ? "0.00" : item.SubItems[2].Text);
						item.SubItems[3].Text = (num2 * Convert.ToDecimal(value)).ToString("0.00");
						FormHelper.ChangeOrderEntryLVWinformsCellByIdentifier(listView_0, item, listView_0.Font.Size, item.SubItems[16].Text);
					}
				}
				else
				{
					num2 = Math.Round(Convert.ToDecimal(MathHelper.FractionToDecimal(listViewItem.SubItems[0].Text)) / (decimal)num, 4);
					string_5 = "11111111-1111-1111-1111-111111111111|" + listViewItem.SubItems[6].Text;
					foreach (ListView item3 in list_2)
					{
						formHelper_0.subAddItemsToList(item3, num2.ToString(), listViewItem.SubItems[1].Text, listViewItem.SubItems[2].Text, int_, int_2, int_3, string_5, Void: false, string_6, int_4, int_5, null, item3.Font.Size, string_8, -1, 0m, listViewItem.SubItems[15].Text, int_6, string_9);
					}
					if (num2 < 1m)
					{
						listViewItem.SubItems[0].Text = MathHelper.DecimalToFraction(num2);
					}
					else
					{
						listViewItem.SubItems[0].Text = num2.ToString();
					}
					listViewItem.SubItems[3].Text = (num2 * Convert.ToDecimal(listViewItem.SubItems[2].Text)).ToString("0.00");
					FormHelper.ChangeOrderEntryLVWinformsCellByIdentifier(listView_0, listViewItem, listView_0.Font.Size, listViewItem.SubItems[16].Text);
				}
				method_7();
			}
			method_12();
		}
		else
		{
			new NotificationLabel(this, Resources.You_cannot_share_an_already_sh, NotificationTypes.Notification).Show();
			listView_0 = null;
		}
	}

	private void btnStartOver_Click(object sender, EventArgs e)
	{
		ControlHelpers.ClearControlsInPanel(BillsPanel);
		int_0 = 0;
		int_1 = 0;
		list_3.Clear();
		if (string_0 == OrderTypes.DineIn)
		{
			short_4 = Convert.ToInt16(iqueryable_0.OrderByDescending((Order o) => o.SeatNum).FirstOrDefault().SeatNum);
			short_3 = short_4;
			for (int i = 1; i <= short_3; i++)
			{
				IliFtzwapVs(i.ToString());
			}
		}
		else
		{
			List<string> list = (from a in iqueryable_0
				group a by a.OrderNumber into a
				select a.Key).ToList();
			short_4 = (short_3 = (short)(from a in iqueryable_0
				group a by a.OrderNumber).Count());
			foreach (string item in list)
			{
				IliFtzwapVs(item);
			}
		}
		btnStartOver.Enabled = false;
		method_12();
		method_7();
		bool_0 = false;
		btnShareItem.Text = Resources.SHARE_ITEM;
		btnShareItem.BackColor = Color.FromArgb(176, 124, 219);
		GC.Collect();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		method_9();
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, iqueryable_0);
		method_3();
		GC.Collect();
		bool_1 = true;
		Button button = btnSave;
		Button button2 = btnSaveClose;
		Button button3 = btnSaveEdit;
		btnStartOver.Enabled = false;
		button3.Enabled = false;
		button2.Enabled = false;
		button.Enabled = false;
	}

	private void btnPrint_Click(object sender, EventArgs e)
	{
		if (!btnSave.Enabled)
		{
			if (new frmMessageBox(Resources.Are_you_sure_you_want_to_print, Resources.Print_All_Bills, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
		}
		else
		{
			if (new frmMessageBox("Are you sure you want to save and print all the bills?", Resources.Print_All_Bills, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			method_9();
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, iqueryable_0);
			method_3();
			GC.Collect();
			bool_1 = true;
			Button button = btnSave;
			Button button2 = btnSaveClose;
			Button button3 = btnSaveEdit;
			btnStartOver.Enabled = false;
			button3.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
		}
		foreach (string item in list_3)
		{
			if (item != null)
			{
				PrintHelper.GenerateReceipt(item, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				continue;
			}
			break;
		}
	}

	private void btnSaveEdit_Click(object sender, EventArgs e)
	{
		method_9();
		base.DialogResult = DialogResult.OK;
		Dispose();
	}

	private void btnSplitEvenly_Click(object sender, EventArgs e)
	{
		if (short_3 <= 1)
		{
			new NotificationLabel(this, "There should be at least 2 or more bills.", NotificationTypes.Warning).Show();
			return;
		}
		if (string.IsNullOrEmpty(this.string_8))
		{
			listView_0 = BillsPanel.Controls.Find("1", searchAllChildren: true).FirstOrDefault() as ListView;
		}
		else
		{
			listView_0 = BillsPanel.Controls.Find(this.string_8, searchAllChildren: true).FirstOrDefault() as ListView;
		}
		if (listView_0.Items.Count > 0)
		{
			int num = short_3;
			decimal num2 = default(decimal);
			foreach (ListViewItem item in listView_0.Items)
			{
				method_8(listView_0, out var _, out var _, out var _, out var _, out var int_, out var int_2, out var int_3, out var string_5, out var _, out var string_6, out var int_4, out var int_5, out var string_7, out var string_8, out var _, out var int_6, item.Index);
				num2 = Math.Round(Convert.ToDecimal(MathHelper.FractionToDecimal(item.SubItems[0].Text)) / (decimal)num, 4);
				string_5 = "11111111-1111-1111-1111-111111111111|" + item.SubItems[6].Text;
				foreach (Control control in BillsPanel.Controls)
				{
					if (control is ListView && listView_0 != null && control != listView_0)
					{
						ListView listView = control as ListView;
						formHelper_0.subAddItemsToList(listView, num2.ToString(), item.SubItems[1].Text, item.SubItems[2].Text, int_, int_2, int_3, string_5, Void: false, string_6, int_4, int_5, null, listView.Font.Size, string_8, -1, 0m, string_7, int_6);
					}
				}
				if (num2 < 1m)
				{
					item.SubItems[0].Text = MathHelper.DecimalToFraction(num2);
				}
				else
				{
					item.SubItems[0].Text = num2.ToString();
				}
				string value = item.SubItems[2].Text;
				if (item.SubItems[2].Text == "")
				{
					value = "0.00";
				}
				item.SubItems[3].Text = (num2 * Convert.ToDecimal(value)).ToString("0.00");
				item.SubItems[15].Text = string_7;
				FormHelper.ChangeOrderEntryLVWinformsCellByIdentifier(listView_0, item, listView_0.Font.Size, item.SubItems[16].Text);
			}
		}
		else
		{
			new NotificationLabel(this, "Bill 1 doesn't have items. you only use evenly split feature if Bill 1 has the only bill that has items.", NotificationTypes.Notification).Show();
		}
		method_12();
		method_7();
		btnStartOver.Enabled = true;
	}

	private void method_12()
	{
		_003C_003Ec__DisplayClass72_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass72_0();
		ListView listView = BillsPanel.Controls.Find("1", searchAllChildren: true).FirstOrDefault() as ListView;
		List<ListView> list = new List<ListView>();
		foreach (Control control in BillsPanel.Controls)
		{
			if (control is ListView && control.Name != "1")
			{
				list.Add(control as ListView);
			}
		}
		CS_0024_003C_003E8__locals0.qty = default(decimal);
		CS_0024_003C_003E8__locals0.itemName = "";
		if (string_0 == OrderTypes.DineIn)
		{
			foreach (ListView item in list)
			{
				int num = 0;
				foreach (ListViewItem item2 in item.Items)
				{
					if (!item2.Font.Strikeout)
					{
						num++;
					}
				}
				if (num > 0)
				{
					btnSplitEvenly.Enabled = false;
					return;
				}
			}
		}
		else if (BillsPanel.Controls.Find(string_8, searchAllChildren: true).FirstOrDefault() is ListView listView2 && listView2.Items.Count > 0)
		{
			CS_0024_003C_003E8__locals0.qty = Convert.ToDecimal(MathHelper.FractionToDecimal(listView2.Items[0].SubItems[0].Text));
			CS_0024_003C_003E8__locals0.itemName = listView2.Items[0].SubItems[1].Text;
			if (list_3.Count > 1 || iqueryable_0.Where((Order a) => a.SeatNum == "1" && a.Qty == CS_0024_003C_003E8__locals0.qty && CS_0024_003C_003E8__locals0.itemName == a.ItemName).FirstOrDefault() == null)
			{
				btnSplitEvenly.Enabled = false;
				return;
			}
		}
		btnSplitEvenly.Enabled = true;
	}

	private void btnSaveEdit_EnabledChanged(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSplitBill));
		verticalScrollControl1 = new VerticalScrollControl();
		btnSplitEvenly = new Button();
		btnPrint = new Button();
		btnSave = new Button();
		btnStartOver = new Button();
		btnShareItem = new Button();
		btnAddBill = new Button();
		wjeFkDmlMy6 = new Label();
		lblCustomer = new Label();
		lblOrderType = new Label();
		BtnCancel = new Button();
		btnSaveClose = new Button();
		BillsPanel = new Panel();
		btnSaveEdit = new Button();
		SuspendLayout();
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
		componentResourceManager.ApplyResources(btnSplitEvenly, "btnSplitEvenly");
		btnSplitEvenly.BackColor = Color.FromArgb(53, 152, 220);
		btnSplitEvenly.FlatAppearance.BorderColor = Color.Black;
		btnSplitEvenly.FlatAppearance.BorderSize = 0;
		btnSplitEvenly.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSplitEvenly.ForeColor = Color.White;
		btnSplitEvenly.Name = "btnSplitEvenly";
		btnSplitEvenly.UseVisualStyleBackColor = false;
		btnSplitEvenly.EnabledChanged += btnSaveEdit_EnabledChanged;
		btnSplitEvenly.Click += btnSplitEvenly_Click;
		componentResourceManager.ApplyResources(btnPrint, "btnPrint");
		btnPrint.BackColor = Color.SandyBrown;
		btnPrint.FlatAppearance.BorderColor = Color.White;
		btnPrint.FlatAppearance.BorderSize = 0;
		btnPrint.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrint.ForeColor = Color.White;
		btnPrint.Name = "btnPrint";
		btnPrint.UseVisualStyleBackColor = false;
		btnPrint.Click += btnPrint_Click;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.EnabledChanged += btnSaveEdit_EnabledChanged;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(btnStartOver, "btnStartOver");
		btnStartOver.BackColor = Color.SandyBrown;
		btnStartOver.FlatAppearance.BorderColor = Color.Black;
		btnStartOver.FlatAppearance.BorderSize = 0;
		btnStartOver.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnStartOver.ForeColor = Color.White;
		btnStartOver.Name = "btnStartOver";
		btnStartOver.UseVisualStyleBackColor = false;
		btnStartOver.EnabledChanged += btnSaveEdit_EnabledChanged;
		btnStartOver.Click += btnStartOver_Click;
		componentResourceManager.ApplyResources(btnShareItem, "btnShareItem");
		btnShareItem.BackColor = Color.FromArgb(176, 124, 219);
		btnShareItem.FlatAppearance.BorderColor = Color.Black;
		btnShareItem.FlatAppearance.BorderSize = 0;
		btnShareItem.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnShareItem.ForeColor = Color.White;
		btnShareItem.Name = "btnShareItem";
		btnShareItem.UseVisualStyleBackColor = false;
		btnShareItem.Click += btnShareItem_Click;
		componentResourceManager.ApplyResources(btnAddBill, "btnAddBill");
		btnAddBill.BackColor = Color.FromArgb(50, 119, 155);
		btnAddBill.FlatAppearance.BorderColor = Color.Black;
		btnAddBill.FlatAppearance.BorderSize = 0;
		btnAddBill.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddBill.ForeColor = Color.White;
		btnAddBill.Name = "btnAddBill";
		btnAddBill.UseVisualStyleBackColor = false;
		btnAddBill.Click += btnAddBill_Click;
		componentResourceManager.ApplyResources(wjeFkDmlMy6, "label10");
		wjeFkDmlMy6.BackColor = Color.FromArgb(156, 89, 184);
		wjeFkDmlMy6.ForeColor = Color.White;
		wjeFkDmlMy6.Name = "label10";
		componentResourceManager.ApplyResources(lblCustomer, "lblCustomer");
		lblCustomer.ForeColor = Color.White;
		lblCustomer.Name = "lblCustomer";
		componentResourceManager.ApplyResources(lblOrderType, "lblOrderType");
		lblOrderType.ForeColor = Color.White;
		lblOrderType.Name = "lblOrderType";
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.DialogResult = DialogResult.Cancel;
		BtnCancel.FlatAppearance.BorderColor = Color.Black;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(btnSaveClose, "btnSaveClose");
		btnSaveClose.BackColor = Color.FromArgb(65, 168, 95);
		btnSaveClose.DialogResult = DialogResult.OK;
		btnSaveClose.FlatAppearance.BorderColor = Color.Black;
		btnSaveClose.FlatAppearance.BorderSize = 0;
		btnSaveClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSaveClose.ForeColor = Color.White;
		btnSaveClose.Name = "btnSaveClose";
		btnSaveClose.UseVisualStyleBackColor = false;
		btnSaveClose.EnabledChanged += btnSaveEdit_EnabledChanged;
		btnSaveClose.Click += btnSaveClose_Click;
		componentResourceManager.ApplyResources(BillsPanel, "BillsPanel");
		BillsPanel.BorderStyle = BorderStyle.FixedSingle;
		BillsPanel.Name = "BillsPanel";
		componentResourceManager.ApplyResources(btnSaveEdit, "btnSaveEdit");
		btnSaveEdit.BackColor = Color.FromArgb(65, 168, 95);
		btnSaveEdit.DialogResult = DialogResult.OK;
		btnSaveEdit.FlatAppearance.BorderColor = Color.Black;
		btnSaveEdit.FlatAppearance.BorderSize = 0;
		btnSaveEdit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSaveEdit.ForeColor = Color.White;
		btnSaveEdit.Name = "btnSaveEdit";
		btnSaveEdit.UseVisualStyleBackColor = false;
		btnSaveEdit.EnabledChanged += btnSaveEdit_EnabledChanged;
		btnSaveEdit.Click += btnSaveEdit_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(40, 50, 78);
		base.Controls.Add(btnSaveEdit);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnSplitEvenly);
		base.Controls.Add(btnPrint);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnStartOver);
		base.Controls.Add(btnShareItem);
		base.Controls.Add(btnAddBill);
		base.Controls.Add(wjeFkDmlMy6);
		base.Controls.Add(lblCustomer);
		base.Controls.Add(lblOrderType);
		base.Controls.Add(BtnCancel);
		base.Controls.Add(btnSaveClose);
		base.Controls.Add(BillsPanel);
		base.Name = "frmSplitBill";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.WindowState = FormWindowState.Maximized;
		base.FormClosing += frmSplitBill_FormClosing;
		base.Load += frmSplitBill_Load;
		base.Controls.SetChildIndex(BillsPanel, 0);
		base.Controls.SetChildIndex(btnSaveClose, 0);
		base.Controls.SetChildIndex(BtnCancel, 0);
		base.Controls.SetChildIndex(lblOrderType, 0);
		base.Controls.SetChildIndex(lblCustomer, 0);
		base.Controls.SetChildIndex(wjeFkDmlMy6, 0);
		base.Controls.SetChildIndex(btnAddBill, 0);
		base.Controls.SetChildIndex(btnShareItem, 0);
		base.Controls.SetChildIndex(btnStartOver, 0);
		base.Controls.SetChildIndex(btnSave, 0);
		base.Controls.SetChildIndex(btnPrint, 0);
		base.Controls.SetChildIndex(btnSplitEvenly, 0);
		base.Controls.SetChildIndex(verticalScrollControl1, 0);
		base.Controls.SetChildIndex(btnSaveEdit, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		ResumeLayout(performLayout: false);
	}
}
