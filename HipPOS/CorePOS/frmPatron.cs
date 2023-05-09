using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmPatron : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public frmPatron _003C_003E4__this;

		public object sender;

		public _003C_003Ec__DisplayClass51_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__0()
		{
			_003C_003E4__this.bool_5 = true;
			_003C_003Ec__DisplayClass51_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_2
			{
				CS_0024_003C_003E8__locals2 = this,
				y = ((_003C_003E4__this.pnlItems.AutoScrollPosition.Y >= 0) ? _003C_003E4__this.pnlItems.AutoScrollPosition.Y : 0)
			};
			while (CS_0024_003C_003E8__locals0.y < 48)
			{
				if (CS_0024_003C_003E8__locals0.y > 48)
				{
					CS_0024_003C_003E8__locals0.y = 48;
				}
				_003C_003E4__this.Invoke((Action)delegate
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition = new Point(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition.X, CS_0024_003C_003E8__locals0.y);
				});
				Thread.Sleep(1);
				CS_0024_003C_003E8__locals0.y += 4;
			}
			_003C_003E4__this.bool_5 = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_1
	{
		public Point currAutoS;

		public int scroll_counter;

		public _003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals1;

		public Action _003C_003E9__2;

		public Action _003C_003E9__3;

		public Action _003C_003E9__4;

		public _003C_003Ec__DisplayClass51_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__1()
		{
			for (int i = 0; i < scroll_counter; i++)
			{
				if (currAutoS.Y != 0)
				{
					currAutoS.Y = Math.Abs(currAutoS.Y) + CS_0024_003C_003E8__locals1._003C_003E4__this.int_8;
				}
				if (CS_0024_003C_003E8__locals1.sender is RadListView)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.radListItems.AutoScrollPosition = currAutoS;
					});
				}
				else
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = currAutoS;
					});
				}
				if (Math.Abs(currAutoS.Y) <= 0 || (CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "up" && Math.Abs(currAutoS.Y) >= CS_0024_003C_003E8__locals1._003C_003E4__this.int_7))
				{
					i = scroll_counter;
				}
				if (i >= (int)((double)(float)scroll_counter * 0.65) || (CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "down" && currAutoS.Y < 100))
				{
					if (CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 < 1 && CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 > -1)
					{
						i = scroll_counter;
					}
					else
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 = (int)((float)CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 * 0.8f);
					}
				}
				Thread.Sleep(1);
			}
			if (!(CS_0024_003C_003E8__locals1.sender is RadListView) && CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "down" && Math.Abs(currAutoS.Y) < 48)
			{
				for (int j = ((Math.Abs(currAutoS.Y) >= 0) ? Math.Abs(currAutoS.Y) : 0); j < 48; j += 4)
				{
					if (j > 48)
					{
						j = 48;
					}
					currAutoS.Y = j;
					CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = currAutoS;
					});
					Thread.Sleep(1);
				}
			}
			CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5 = false;
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__2()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.radListItems.AutoScrollPosition = currAutoS;
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__3()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = currAutoS;
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__4()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = currAutoS;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_2
	{
		public int y;

		public _003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass51_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CpnlItemScroll_MouseUp_003Eb__5()
		{
			CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition = new Point(CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition.X, y);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public string searchText;

		public _003C_003Ec__DisplayClass54_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public Order order;

		public _003C_003Ec__DisplayClass55_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_0
	{
		public int selectedTag;

		public _003C_003Ec__DisplayClass57_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public Item item;

		public _003C_003Ec__DisplayClass67_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPatronItemAddItem_Click_003Eb__4(usp_ItemOptionsResult i)
		{
			if (i.ItemID == item.ItemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CPatronItemAddItem_Click_003Eb__13(usp_ItemOptionsResult i)
		{
			if (i.ItemID == item.ItemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_1
	{
		public MaterialsInItem matInItem;

		public _003C_003Ec__DisplayClass67_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_2
	{
		public ItemsInItem itemChild;

		public _003C_003Ec__DisplayClass67_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_3
	{
		public Item itemChildDetails;

		public _003C_003Ec__DisplayClass67_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPatronItemAddItem_Click_003Eb__8(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemChildDetails.ItemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_4
	{
		public frmGroupsInItemSelection frmSel;

		public _003C_003Ec__DisplayClass67_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass69_0
	{
		public int childItemID;

		public _003C_003Ec__DisplayClass69_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass69_1
	{
		public ItemsInItem itemChild;

		public _003C_003Ec__DisplayClass69_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_0
	{
		public ListViewDataItem parentListItem;

		public frmPatron _003C_003E4__this;

		public _003C_003Ec__DisplayClass71_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_1
	{
		public string comboID;

		public _003C_003Ec__DisplayClass71_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRemoveItemInListView_003Eb__0(ListViewDataItem a)
		{
			if (a.SubItems[5].ToString() == comboID.ToString())
			{
				if (!a[1].ToString().Contains("ADD:"))
				{
					return !a[1].ToString().Contains("OPT: ");
				}
				return false;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_2
	{
		public int z;

		public _003C_003Ec__DisplayClass71_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass71_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass71_3
	{
		public string Tag;

		public _003C_003Ec__DisplayClass71_2 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass71_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRemoveItemInListView_003Eb__1(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && x.ItemID.Value.ToString() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.parentListItem.SubItems[4].ToString() && x.Option_ItemID == Convert.ToInt32(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.radListItems.SelectedItems[CS_0024_003C_003E8__locals2.z].SubItems[4].ToString().Trim()))
			{
				return x.Tab.ToUpper() == Tag.ToUpper();
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass74_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass74_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public int itemID;

		public int optionComboId;

		public int comboId;

		public _003C_003Ec__DisplayClass76_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnItemOptions_Click_003Eb__0(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemID)
			{
				return !i.ToBeDeleted;
			}
			return false;
		}

		internal bool _003CbtnItemOptions_Click_003Eb__3(ListViewDataItem a)
		{
			if (a.SubItems[11].ToString() == optionComboId.ToString() && !a.Font.Strikeout && a.SubItems[5].ToString() == comboId.ToString())
			{
				if (!a[1].ToString().Contains("ADD:"))
				{
					return a[1].ToString().Contains("OPT: ");
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_1
	{
		public SelectedOptionObject selOption;

		public _003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass76_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnItemOptions_Click_003Eb__5(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && x.Option_ItemID == selOption.option_itemId && x.ItemID == CS_0024_003C_003E8__locals1.itemID)
			{
				return x.Tab.ToUpper() == selOption.tag.ToUpper();
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass80_0
	{
		public Item itemFromDB;

		public _003C_003Ec__DisplayClass80_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public string itemToDisplay;

		public _003C_003Ec__DisplayClass83_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadItemsTimer_Tick_003Eb__1(PatronItemControl a)
		{
			return a.Name == itemToDisplay;
		}
	}

	private string string_0;

	private string string_1;

	private int int_0;

	private string string_2;

	private string string_3;

	private string string_4;

	private GClass6 gclass6_0;

	private OrderHelper orderHelper_0;

	private DataManager dataManager_0;

	private short short_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private short short_1;

	private bool bool_0;

	private string string_5;

	private List<Item> list_2;

	private List<Tax> list_3;

	private string string_6;

	private decimal decimal_0;

	private decimal decimal_1;

	private decimal decimal_2;

	private bool bool_1;

	private bool bool_2;

	private List<Item> list_4;

	private List<int> list_5;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private DateTime dateTime_0;

	private Point point_0;

	private Point point_1;

	private Point point_2;

	private string string_7;

	private string string_8;

	private int int_7;

	private int int_8;

	private bool bool_7;

	private IContainer icontainer_1;

	private Label label2;

	private Label label8;

	internal CustomListViewTelerik radListItems;

	internal Button btnSaveOrder;

	internal Button btnRemove;

	internal Button btnInstructions;

	internal Button btnClose;

	internal Button btnSearchItems;

	private Label lblItemsHeader;

	private FlowLayoutPanel pnlGroups;

	private Label label3;

	private FlowLayoutPanel pnlItems;

	internal Button btnItemOptions;

	private Label label1;

	private Label label4;

	private Label label5;

	private Label lblTableName;

	private PictureBox pictureBox1;

	private Label label6;

	private Label label7;

	private System.Windows.Forms.Timer timer_0;

	private System.Windows.Forms.Timer timer_1;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 33554432;
			return obj;
		}
	}

	public frmPatron()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		orderHelper_0 = new OrderHelper();
		int_3 = 10;
		int_4 = 1;
		int_5 = 1;
		int_6 = 1;
		short_1 = 1;
		string_5 = string.Empty;
		list_2 = new List<Item>();
		string_6 = "";
		list_4 = new List<Item>();
		list_5 = new List<int>();
		bool_6 = true;
		string_7 = "none";
		string_8 = "none";
		// base._002Ector();
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		InitializeComponent_1();
		dataManager_0 = new DataManager();
		bool_0 = ((SettingsHelper.GetSettingValueByKey("prompt_option_child_item") == "ON") ? true : false);
		radListItems.AutoScroll = false;
		radListItems.ListViewElement.VerticalScrollState = ScrollState.AlwaysHide;
		radListItems.AutoScroll = true;
		radListItems.MouseDown += pnlItems_MouseDown;
		radListItems.MouseMove += pnlItems_MouseMove;
		radListItems.MouseUp += pnlItems_MouseUp;
		radListItems.DisableGesture(GestureType.All);
		radListItems.CellFormatting += radListItems_CellFormatting;
		pnlItems.VerticalScroll.Maximum = 0;
		pnlItems.AutoScroll = false;
		pnlItems.VerticalScroll.Visible = false;
		pnlItems.HorizontalScroll.Visible = false;
		pnlItems.AutoScroll = true;
		pnlItems.MouseDown += pnlItems_MouseDown;
		pnlItems.MouseMove += pnlItems_MouseMove;
		pnlItems.MouseUp += pnlItems_MouseUp;
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			btnSaveOrder.Text = "CHECK OUT";
			btnSaveOrder.Image = null;
			btnClose.Text = "START OVER";
		}
	}

	public void LoadFormData(string _orderNumber = null, string _customer = null, string _orderType = "Dine In", int _guestCount = 1, string _customerInfoName = "", string _employeeName = "")
	{
		base.WindowState = FormWindowState.Maximized;
		string_0 = _customer;
		string_1 = _orderType;
		int_0 = _guestCount;
		string_2 = _customerInfoName;
		string_4 = _employeeName;
		if (!string.IsNullOrEmpty(_orderNumber))
		{
			loadOrderByOrderNumber(_orderNumber);
		}
		else
		{
			method_6();
		}
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			lblTableName.Text = string_1;
		}
		else
		{
			lblTableName.Text = string_0;
		}
		if (_guestCount == 0)
		{
			_guestCount = GuestMethods.GetCurrentTableGuestCapacity(string_0.Replace("Table ", ""));
		}
		int_0 = _guestCount;
		GuestMethods.UpdateTableGuestCapacity(string_0.Replace("Table ", ""), int_0, Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
	}

	public void HideForm()
	{
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			method_6();
			base.DialogResult = DialogResult.Cancel;
			Hide();
		}
		else if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmLayout") != null)
		{
			method_6();
			base.DialogResult = DialogResult.Cancel;
			Hide();
		}
	}

	private void frmPatron_Load(object sender, EventArgs e)
	{
		method_17();
		method_7();
		method_18();
	}

	public void RefreshGroupsAndItems()
	{
		method_17();
		method_7();
		method_18();
		pnlItems.Controls.Clear();
	}

	private void pnlItems_MouseDown(object sender, MouseEventArgs e)
	{
		if (sender is RadListView)
		{
			bool_3 = true;
			point_1 = (point_0 = e.Location);
		}
		else if (!bool_5)
		{
			bool_4 = true;
			point_2 = (point_0 = e.Location);
			dateTime_0 = DateTime.Now;
		}
	}

	private void pnlItems_MouseMove(object sender, MouseEventArgs e)
	{
		bool flag = false;
		flag = ((!(sender is RadListView)) ? bool_4 : bool_3);
		if (!flag || bool_5)
		{
			return;
		}
		Point point;
		string text;
		if (sender is RadListView)
		{
			point = point_1;
			text = string_7;
		}
		else
		{
			point = point_2;
			text = string_8;
		}
		if (point.X == e.Location.X && point.Y == e.Location.Y)
		{
			return;
		}
		Point autoScrollPosition = ((!(sender is RadListView)) ? pnlItems.AutoScrollPosition : radListItems.AutoScrollPosition);
		if (point.Y > e.Location.Y)
		{
			autoScrollPosition.Y = Math.Abs(autoScrollPosition.Y) + 14;
			text = "up";
		}
		else if (point.Y < e.Location.Y)
		{
			if (autoScrollPosition.Y != 0)
			{
				autoScrollPosition.Y = Math.Abs(autoScrollPosition.Y) - 14;
			}
			text = "down";
		}
		else
		{
			autoScrollPosition.Y = Math.Abs(autoScrollPosition.Y);
			text = "none";
		}
		if (sender is RadListView)
		{
			radListItems.AutoScrollPosition = autoScrollPosition;
		}
		else
		{
			pnlItems.AutoScrollPosition = autoScrollPosition;
		}
		int num = e.Location.Y;
		if (text == "up")
		{
			num += 14;
		}
		else if (text == "down")
		{
			num -= 14;
		}
		point = new Point(e.Location.X, num);
		if (sender is RadListView)
		{
			point_1 = point;
			string_7 = text;
		}
		else
		{
			point_2 = point;
			string_8 = text;
		}
	}

	private void pnlItems_MouseUp(object sender, MouseEventArgs e)
	{
		_003C_003Ec__DisplayClass51_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.sender = sender;
		bool_4 = false;
		bool_3 = false;
		if (CS_0024_003C_003E8__locals0.sender is RadListView)
		{
			return;
		}
		TimeSpan timeSpan = DateTime.Now - dateTime_0;
		if ((e.Location.Y - point_0.Y >= 60 || point_0.Y - e.Location.Y >= 60) && timeSpan.TotalMilliseconds > 120.0 && timeSpan.TotalMilliseconds < 400.0 && !bool_5)
		{
			int_8 = 30;
			if (string_8 == "none")
			{
				int_8 = 0;
			}
			else if (string_8 == "down")
			{
				int_8 = -int_8;
			}
			if (int_8 == 0)
			{
				return;
			}
			_003C_003Ec__DisplayClass51_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass51_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.sender is RadListView)
			{
				CS_0024_003C_003E8__locals1.currAutoS = radListItems.AutoScrollPosition;
			}
			else
			{
				CS_0024_003C_003E8__locals1.currAutoS = pnlItems.AutoScrollPosition;
			}
			bool_5 = true;
			CS_0024_003C_003E8__locals1.scroll_counter = 30;
			Thread thread = new Thread((ThreadStart)delegate
			{
				for (int i = 0; i < CS_0024_003C_003E8__locals1.scroll_counter; i++)
				{
					if (CS_0024_003C_003E8__locals1.currAutoS.Y != 0)
					{
						CS_0024_003C_003E8__locals1.currAutoS.Y = Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) + CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_8;
					}
					if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.sender is RadListView)
					{
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
						{
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.radListItems.AutoScrollPosition = CS_0024_003C_003E8__locals1.currAutoS;
						});
					}
					else
					{
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
						{
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = CS_0024_003C_003E8__locals1.currAutoS;
						});
					}
					if (Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) <= 0 || (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "up" && Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) >= CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_7))
					{
						i = CS_0024_003C_003E8__locals1.scroll_counter;
					}
					if (i >= (int)((double)(float)CS_0024_003C_003E8__locals1.scroll_counter * 0.65) || (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "down" && CS_0024_003C_003E8__locals1.currAutoS.Y < 100))
					{
						if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 < 1 && CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 > -1)
						{
							i = CS_0024_003C_003E8__locals1.scroll_counter;
						}
						else
						{
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 = (int)((float)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.int_8 * 0.8f);
						}
					}
					Thread.Sleep(1);
				}
				if (!(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.sender is RadListView) && CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.string_8 == "down" && Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) < 48)
				{
					for (int j = ((Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) >= 0) ? Math.Abs(CS_0024_003C_003E8__locals1.currAutoS.Y) : 0); j < 48; j += 4)
					{
						if (j > 48)
						{
							j = 48;
						}
						CS_0024_003C_003E8__locals1.currAutoS.Y = j;
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.Invoke((Action)delegate
						{
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.pnlItems.AutoScrollPosition = CS_0024_003C_003E8__locals1.currAutoS;
						});
						Thread.Sleep(1);
					}
				}
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1._003C_003E4__this.bool_5 = false;
			});
			thread.IsBackground = true;
			thread.Start();
		}
		else
		{
			if (CS_0024_003C_003E8__locals0.sender is RadListView || !(string_8 == "down") || Math.Abs(pnlItems.AutoScrollPosition.Y) >= 48 || bool_5)
			{
				return;
			}
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.bool_5 = true;
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_2();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals0.y = ((CS_0024_003C_003E8__locals0._003C_003E4__this.pnlItems.AutoScrollPosition.Y >= 0) ? CS_0024_003C_003E8__locals0._003C_003E4__this.pnlItems.AutoScrollPosition.Y : 0);
				while (CS_0024_003C_003E8__locals0.y < 48)
				{
					if (CS_0024_003C_003E8__locals0.y > 48)
					{
						CS_0024_003C_003E8__locals0.y = 48;
					}
					CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((Action)delegate
					{
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition = new Point(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2._003C_003E4__this.pnlItems.AutoScrollPosition.X, CS_0024_003C_003E8__locals0.y);
					});
					Thread.Sleep(1);
					CS_0024_003C_003E8__locals0.y += 4;
				}
				CS_0024_003C_003E8__locals0._003C_003E4__this.bool_5 = false;
			}).Start();
		}
	}

	private void method_3(bool bool_8)
	{
		if (bool_8)
		{
			int_1 = pnlGroups.Width;
			int_2 = pnlGroups.Height / int_3;
		}
	}

	private Button method_4(string string_9, Color color_0, string string_10, EventHandler eventHandler_0, bool bool_8 = false)
	{
		Button button = new Button();
		button.Text = string_9.Replace(" & ", " && ");
		button.Name = button.Text;
		button.Tag = string_10;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.BackColor = color_0;
		button.Click += eventHandler_0;
		button.Margin = new Padding(0, 1, 1, 0);
		if (!bool_8)
		{
			button.Size = new Size(int_1, int_2);
			button.Font = new Font(FontFamily.GenericSansSerif, 12.5f, FontStyle.Regular);
		}
		return button;
	}

	public void loadOrderByOrderNumber(string searchText)
	{
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass54_0();
		CS_0024_003C_003E8__locals0.searchText = searchText;
		bool_6 = true;
		IQueryable<Order> queryable = from o in new GClass6().Orders
			where o.OrderNumber == CS_0024_003C_003E8__locals0.searchText && ((o.Paid == false) & (o.DatePaid == null)) && o.Void == false
			select o into x
			orderby x.DateCreated
			select x;
		if (queryable.Count() == 0)
		{
			new frmMessageBox(Resources.Order_not_found_or_has_already).ShowDialog(this);
			string_5 = string.Empty;
		}
		else
		{
			string_5 = CS_0024_003C_003E8__locals0.searchText;
			method_5(queryable);
			bool_6 = false;
		}
	}

	private void method_5(IQueryable<Order> iqueryable_0)
	{
		iqueryable_0 = iqueryable_0.OrderBy((Order a) => a.ComboID).ThenBy((Order x) => x.DateCreated);
		method_6();
		GClass6 gClass = new GClass6();
		int num = 0;
		radListItems.BeginUpdate();
		using (IEnumerator<Order> enumerator = iqueryable_0.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass55_0();
				CS_0024_003C_003E8__locals0.order = enumerator.Current;
				string_5 = CS_0024_003C_003E8__locals0.order.OrderNumber;
				string text = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Options) ? CS_0024_003C_003E8__locals0.order.ItemName : (CS_0024_003C_003E8__locals0.order.ItemName + " => " + CS_0024_003C_003E8__locals0.order.Options));
				decimal num2 = default(decimal);
				decimal num3 = default(decimal);
				num2 = CS_0024_003C_003E8__locals0.order.ItemSellPrice;
				num3 = CS_0024_003C_003E8__locals0.order.ItemSellPrice * CS_0024_003C_003E8__locals0.order.Qty;
				if (gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.order.ItemID && i.ToBeDeleted == false).ToList().Count() > 0)
				{
					num++;
				}
				string[] values = new string[15]
				{
					(CS_0024_003C_003E8__locals0.order.Qty < 1m) ? MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals0.order.Qty) : MathHelper.RemoveTrailingZeros(CS_0024_003C_003E8__locals0.order.Qty.ToString()),
					text,
					num2.ToString("0.00", Thread.CurrentThread.CurrentCulture),
					num3.ToString("0.00", Thread.CurrentThread.CurrentCulture),
					CS_0024_003C_003E8__locals0.order.ItemID.ToString(),
					CS_0024_003C_003E8__locals0.order.ComboID.ToString(),
					CS_0024_003C_003E8__locals0.order.OrderId.ToString(),
					CS_0024_003C_003E8__locals0.order.Instructions,
					"-1",
					CS_0024_003C_003E8__locals0.order.InventoryBatchId.ToString(),
					0.ToString(),
					num.ToString(),
					false.ToString(),
					CS_0024_003C_003E8__locals0.order.DiscountReason,
					CS_0024_003C_003E8__locals0.order.OrderOnHoldTime.ToString()
				};
				ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
				listViewDataItem.Font = radListItems.Font;
				if (CS_0024_003C_003E8__locals0.order.Void)
				{
					listViewDataItem.Font = new Font(radListItems.Items[radListItems.Items.Count - 1].Font, radListItems.Items[radListItems.Items.Count - 1].Font.Style | FontStyle.Strikeout);
				}
				radListItems.Items.Add(listViewDataItem);
				radListItems.AllowArbitraryItemHeight = true;
				if (Convert.ToInt32(radListItems.Items[radListItems.Items.Count - 1].SubItems[14].ToString()) != 0)
				{
					radListItems.Items[radListItems.Items.Count - 1].BackColor = Color.FromArgb(50, 119, 155);
					radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.LightGray;
				}
				else
				{
					radListItems.Items[radListItems.Items.Count - 1].BackColor = Color.LightGray;
					radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.Gray;
				}
			}
		}
		radListItems.EndUpdate();
		short num4 = iqueryable_0.Max((Order o) => o.ComboID);
		num4 = (short)(num4 + 1);
		short_1 = num4;
		iqueryable_0.FirstOrDefault();
		RecalculateTaxAndSubtotal();
	}

	private void method_6()
	{
		bool_6 = false;
		decimal_1 = default(decimal);
		decimal_0 = default(decimal);
		decimal_2 = default(decimal);
		list_3 = dataManager_0.GetTax();
		decimal_0 = default(decimal);
		radListItems.Items.Clear();
		RecalculateTaxAndSubtotal();
		string_5 = string.Empty;
	}

	public void RecalculateTaxAndSubtotal()
	{
		decimal num = default(decimal);
		decimal_0 = default(decimal);
		GClass6 gClass = new GClass6();
		List<Item> list = new List<Item>();
		foreach (ListViewDataItem item2 in radListItems.Items)
		{
			if (item2.Font == null || !item2.Font.Strikeout)
			{
				_003C_003Ec__DisplayClass57_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass57_0();
				decimal inventoryCount = MathHelper.FractionToDecimal(item2[0].ToString().Replace(",", "."));
				decimal itemPrice = Convert.ToDecimal(item2[2].ToString(), Thread.CurrentThread.CurrentCulture);
				CS_0024_003C_003E8__locals0.selectedTag = Convert.ToInt32(item2.SubItems[4].ToString());
				Item item = gClass.Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.selectedTag).FirstOrDefault();
				list.Add(new Item
				{
					InventoryCount = inventoryCount,
					ItemPrice = itemPrice,
					ItemID = item.ItemID,
					ItemName = item.ItemName,
					TaxRule = item.TaxRule,
					TaxRuleID = item.TaxRuleID,
					ItemTypeID = item.ItemTypeID,
					Active = true
				});
			}
		}
		foreach (Item item3 in list)
		{
			decimal_0 += item3.InventoryCount * item3.ItemPrice;
		}
		num = (decimal_1 = TaxMethods.GetTaxWithRounding(list));
		decimal_2 = decimal_0 + num;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		HideForm();
	}

	private void method_7()
	{
		pnlGroups.Controls.Clear();
		method_3(bool_8: true);
		List<CorePOS.Data.Group> source = (from a in dataManager_0.GetChildGroups(ItemClassifications.Product, short_0, onlyActive: true)
			where a.OrderEntryShow && a.ShowInPatronKiosk
			select a into g
			orderby g.HighTraffic descending
			select g).ThenBy((CorePOS.Data.Group w) => w.SortOrder).ThenBy((CorePOS.Data.Group x) => x.GroupName).ToList();
		int num = 1;
		int num2 = int_3 - 1;
		int num3 = source.Count();
		if (short_0 > 0)
		{
			Button value = method_4("...", HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), short_0.ToString(), method_10);
			pnlGroups.Controls.Add(value);
			num = int_4;
			num2--;
		}
		else
		{
			num = int_5;
		}
		if (num3 <= int_3 + 1)
		{
			num2++;
		}
		else if (num3 > int_3 + 1 && num > 1)
		{
			num2--;
		}
		int num4 = num2 * (num - 1);
		bool flag = num3 - num4 > num2;
		source = source.Skip(num4).Take(num2).ToList();
		if (source.Count() > 0)
		{
			foreach (CorePOS.Data.Group item in source)
			{
				HelperMethods.GetColor(item.GroupColor);
				Button value2 = ((dataManager_0.GetChildGroups(ItemClassifications.Product, item.GroupID, onlyActive: true).Count() <= 0) ? method_4(item.GroupName, HelperMethods.GetColor(HelperMethods.ButtonColors()["Asphalt"]), item.GroupID.ToString(), method_12) : method_4(item.GroupName, HelperMethods.GetColor(HelperMethods.ButtonColors()["Asphalt"]), item.GroupID.ToString(), method_11));
				pnlGroups.Controls.Add(value2);
			}
		}
		if (num > 1)
		{
			Button value3 = method_4(Resources.PREV_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_8);
			pnlGroups.Controls.Add(value3);
		}
		if (num3 > num2 && flag)
		{
			Button value4 = method_4(Resources.NEXT_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_9);
			pnlGroups.Controls.Add(value4);
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = "Item Selection";
		if (short_0 > 0)
		{
			int_4--;
		}
		else
		{
			int_5--;
		}
		method_7();
	}

	private void method_9(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = "Item Selection";
		if (short_0 > 0)
		{
			int_4++;
		}
		else
		{
			int_5++;
		}
		method_7();
	}

	private void method_10(object sender, EventArgs e)
	{
		int_4 = 1;
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = "Item Selection";
		Button button = (Button)sender;
		CorePOS.Data.Group groupFromID = dataManager_0.getGroupFromID(Convert.ToInt16(button.Tag));
		short_0 = groupFromID.ParentGroupID;
		pnlGroups.Controls.Clear();
		if (groupFromID.ParentGroupID > 0)
		{
			dataManager_0.getGroupFromID(groupFromID.ParentGroupID);
			method_7();
		}
		else
		{
			method_7();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		method_13();
		((Control)sender).BackColor = Color.FromArgb(35, 39, 56);
		string_6 = ((Button)sender).Text.Replace(" && ", " & ");
		Button button = (Button)sender;
		short_0 = Convert.ToInt16(button.Tag);
		method_7();
		list_2 = (from a in (from itemsInGroup_0 in MemoryLoadedData.ListOfItemsInGroupMemory
				where itemsInGroup_0.Group.GroupName == string_6 && itemsInGroup_0.Item.Active && !itemsInGroup_0.Item.isDeleted
				select itemsInGroup_0 into i
				orderby i.SortOrder
				select i).ThenBy((ItemsInGroup x) => x.Item.ItemName)
			select a.Item).ToList();
		int_6 = 1;
		lblItemsHeader.Text = Resources.Items_for + string_6.Replace("&", "&&");
		method_14();
	}

	private void method_12(object sender, EventArgs e)
	{
		method_13();
		Control obj = (Control)sender;
		obj.BackColor = Color.FromArgb(35, 39, 56);
		obj.ForeColor = Color.Gold;
		string_6 = ((Button)sender).Text.Replace(" && ", " & ");
		list_2 = (from a in (from itemsInGroup_0 in MemoryLoadedData.ListOfItemsInGroupMemory
				where itemsInGroup_0.Group.GroupName == string_6 && itemsInGroup_0.Item.Active && !itemsInGroup_0.Item.isDeleted
				select itemsInGroup_0 into i
				orderby i.SortOrder
				select i).ThenBy((ItemsInGroup x) => x.Item.ItemName)
			select a.Item).ToList();
		int_6 = 1;
		lblItemsHeader.Text = Resources.Items_for + string_6.Replace("&", "&&");
		method_14();
	}

	private void method_13()
	{
		foreach (Control control in pnlGroups.Controls)
		{
			if (control.BackColor == Color.FromArgb(35, 39, 56))
			{
				control.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Asphalt"]);
				control.ForeColor = Color.White;
			}
		}
	}

	private void method_14()
	{
		timer_0.Enabled = true;
	}

	public void PatronItemAddItem_Click(object sender, MouseEventArgs e)
	{
		_003C_003Ec__DisplayClass67_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass67_0();
		PatronItemControl patronItemControl = (PatronItemControl)((Control)sender).Parent;
		CS_0024_003C_003E8__locals0.item = patronItemControl.itemReturn;
		int num = 0;
		string itemName = CS_0024_003C_003E8__locals0.item.ItemName;
		int itemID = CS_0024_003C_003E8__locals0.item.ItemID;
		if (CS_0024_003C_003E8__locals0.item.DisableSoldOutItems)
		{
			if (CS_0024_003C_003E8__locals0.item.InventoryCount <= 0m)
			{
				new NotificationLabel(this, CS_0024_003C_003E8__locals0.item.ItemName.Replace(" & ", " && ").ToUpper() + Resources._is_sold_out_Please_update_you, NotificationTypes.Warning).Show();
				return;
			}
			using List<MaterialsInItem>.Enumerator enumerator = gclass6_0.MaterialsInItems.Where((MaterialsInItem m) => m.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).ToList().GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass67_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass67_1();
				CS_0024_003C_003E8__locals1.matInItem = enumerator.Current;
				Item item = gclass6_0.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.matInItem.ItemMaterialID).FirstOrDefault();
				if (item != null && item.InventoryCount <= 0m)
				{
					new NotificationLabel(this, item.ItemName.Replace(" & ", " && ").ToUpper() + Resources._is_out_of_stock_Please_update, NotificationTypes.Warning).Show();
					return;
				}
			}
		}
		Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(CS_0024_003C_003E8__locals0.item.ItemID);
		decimal num2 = ((promoSaleItemById == null || !CS_0024_003C_003E8__locals0.item.OnSale) ? CS_0024_003C_003E8__locals0.item.ItemPrice : promoSaleItemById.GetDiscountAmount.Value);
		List<ItemsInItem> list = gclass6_0.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		List<GroupsInItem> list2 = gclass6_0.GroupsInItems.Where((GroupsInItem a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		if (list.Count <= 0 && list2.Count <= 0)
		{
			if (itemName.Contains("1/2"))
			{
				ConfigDetail configDetail = gclass6_0.ConfigDetails.Where((ConfigDetail c) => c.ConfigName.ToUpper().Equals("HALF ORDER CALCULATION")).FirstOrDefault();
				if (configDetail != null)
				{
					DataTable dataTable = new DataTable();
					string expression = configDetail.ConfigValue.Replace("PRICE", num2.ToString());
					decimal.TryParse(dataTable.Compute(expression, string.Empty).ToString(), out var result);
					if (result > 0m)
					{
						num2 = Math.Round(result, 2, MidpointRounding.AwayFromZero);
					}
					else
					{
						num2 = Math.Round(num2 * Convert.ToDecimal(0.5), 2, MidpointRounding.AwayFromZero);
					}
				}
				CS_0024_003C_003E8__locals0.item.ItemName = CS_0024_003C_003E8__locals0.item.ItemName.ToUpper();
			}
			else if ((from i in gclass6_0.usp_ItemOptions()
				where i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && !i.ToBeDeleted
				select i).ToList().Count() > 0)
			{
				int int_ = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
				num++;
				method_15(CS_0024_003C_003E8__locals0.item.ItemName.ToUpper(), num2, itemID, 1m, short_1, int_, 0, num);
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
				MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals0.item.ItemName.ToUpper(), CS_0024_003C_003E8__locals0.item.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_1);
				DialogResult dialogResult = MemoryLoadedObjects.OptionScreen.ShowDialog(this);
				if (dialogResult != DialogResult.Cancel)
				{
					short_1++;
				}
				else if (dialogResult == DialogResult.Cancel)
				{
					radListItems.Items.Remove(radListItems.Items.Last());
				}
			}
			else
			{
				int int_2 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
				method_15(CS_0024_003C_003E8__locals0.item.ItemName.ToUpper(), num2, itemID, 1m, 0, int_2);
			}
		}
		else
		{
			int int_3 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
			num++;
			method_15(CS_0024_003C_003E8__locals0.item.ItemName.ToUpper(), num2, itemID, 1m, short_1, int_3, 0, num);
			if ((from i in gclass6_0.usp_ItemOptions()
				where i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && !i.ToBeDeleted
				orderby i.SortOrder, i.ItemName
				select i).ToList().Count() > 0)
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
				MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals0.item.ItemName.ToUpper(), CS_0024_003C_003E8__locals0.item.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_1);
				if (MemoryLoadedObjects.OptionScreen.ShowDialog(this) == DialogResult.Cancel)
				{
					radListItems.Items.Remove(radListItems.Items.Last());
					method_18();
					return;
				}
			}
			if (list.Count > 0)
			{
				using List<ItemsInItem>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass67_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass67_2();
					CS_0024_003C_003E8__locals2.itemChild = enumerator2.Current;
					_003C_003Ec__DisplayClass67_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass67_3();
					CS_0024_003C_003E8__locals3.itemChildDetails = gclass6_0.Items.Where((Item x) => (int?)x.ItemID == CS_0024_003C_003E8__locals2.itemChild.ItemID).FirstOrDefault();
					int batchId = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals3.itemChildDetails);
					num++;
					addPackageItems("---" + CS_0024_003C_003E8__locals3.itemChildDetails.ItemName.ToUpper(), CS_0024_003C_003E8__locals3.itemChildDetails.ItemID, CS_0024_003C_003E8__locals2.itemChild.Quantity.Value, batchId, num);
					if (bool_0 && (from i in gclass6_0.usp_ItemOptions()
						where i.ItemID == CS_0024_003C_003E8__locals3.itemChildDetails.ItemID && !i.ToBeDeleted
						orderby i.SortOrder, i.ItemName
						select i).ToList().Count() > 0)
					{
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
						MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals3.itemChildDetails.ItemName.ToUpper(), CS_0024_003C_003E8__locals3.itemChildDetails.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_1);
						MemoryLoadedObjects.OptionScreen.ShowDialog(this);
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (GroupsInItem item3 in list2)
				{
					for (int j = 0; (decimal)j < item3.Quantity; j++)
					{
						_003C_003Ec__DisplayClass67_4 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass67_4();
						CS_0024_003C_003E8__locals4.frmSel = new frmGroupsInItemSelection(item3.GroupID, ", choice no. " + (j + 1));
						if (CS_0024_003C_003E8__locals4.frmSel.ShowDialog() == DialogResult.OK)
						{
							Item item2 = gclass6_0.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals4.frmSel.returnItemId).FirstOrDefault();
							if (item2 != null)
							{
								int int_4 = orderHelper_0.CheckAndSelectBatchId(item2);
								method_15("---" + item2.ItemName.ToUpper(), 0m, item2.ItemID, 1m, short_1, int_4, item3.GroupID);
							}
						}
						CS_0024_003C_003E8__locals4.frmSel.Dispose();
					}
				}
			}
			GC.Collect();
			short_1++;
		}
		if (radListItems.Items.Count > 0)
		{
			radListItems.ListViewElement.ViewElement.Scroller.ScrollToItem(radListItems.Items.Last());
		}
		method_18();
	}

	private void method_15(string string_9, decimal decimal_3, int int_9, decimal qty = 1m, int int_10 = 0, int int_11 = 0, int int_12 = 0, int int_13 = 0)
	{
		string[] values = new string[15]
		{
			qty.ToString().Replace(".00", string.Empty),
			string_9,
			decimal_3.ToString(MathHelper.FormatPriceDecimals(decimal_3), Thread.CurrentThread.CurrentCulture),
			(qty * decimal_3).ToString("0.00", Thread.CurrentThread.CurrentCulture),
			int_9.ToString(),
			int_10.ToString(),
			string.Empty,
			string.Empty,
			"-1",
			int_11.ToString(),
			int_12.ToString(),
			int_13.ToString(),
			false.ToString(),
			"",
			"0"
		};
		ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
		listViewDataItem.Font = radListItems.Font;
		radListItems.Items.Add(listViewDataItem);
	}

	public void addPackageItems(string childItemName, int childItemID, decimal childQuantity, int batchId, int optionComboId = 0)
	{
		_003C_003Ec__DisplayClass69_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass69_0();
		CS_0024_003C_003E8__locals0.childItemID = childItemID;
		GClass6 gClass = new GClass6();
		method_15(childItemName, 0m, CS_0024_003C_003E8__locals0.childItemID, childQuantity, short_1, batchId, 0, optionComboId);
		List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals0.childItemID).ToList();
		if (list.Count == 0)
		{
			return;
		}
		using List<ItemsInItem>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass69_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass69_1();
			CS_0024_003C_003E8__locals1.itemChild = enumerator.Current;
			Item item = gClass.Items.Where((Item x) => (int?)x.ItemID == CS_0024_003C_003E8__locals1.itemChild.ItemID).FirstOrDefault();
			if (item != null)
			{
				int batchId2 = orderHelper_0.CheckAndSelectBatchId(item);
				addPackageItems("---" + item.ItemName, item.ItemID, CS_0024_003C_003E8__locals1.itemChild.Quantity.Value, batchId2, optionComboId);
			}
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		method_16();
		if (radListItems.SelectedItems.Count > 1)
		{
			method_16();
		}
	}

	private void method_16()
	{
		_003C_003Ec__DisplayClass71_0 _003C_003Ec__DisplayClass71_ = new _003C_003Ec__DisplayClass71_0();
		_003C_003Ec__DisplayClass71_._003C_003E4__this = this;
		if (radListItems.SelectedItems.Count != 0)
		{
			ListViewDataItem selectedItem = radListItems.SelectedItem;
			bool flag = false;
			if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0" && !radListItems.SelectedItems[0][1].ToString().Contains("ADD: ") && !radListItems.SelectedItems[0][1].ToString().Contains("OPT: "))
			{
				radListItems.Focus();
				radListItems.MultiSelect = true;
				string text = radListItems.SelectedItems[0].SubItems[5].ToString();
				radListItems.SelectedItems.Clear();
				foreach (ListViewDataItem item in radListItems.Items)
				{
					if (item.SubItems[5].ToString() == text)
					{
						radListItems.Select(new ListViewDataItem[1] { item });
					}
				}
				_003C_003Ec__DisplayClass71_.parentListItem = radListItems.SelectedItems[0];
			}
			else
			{
				_003C_003Ec__DisplayClass71_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass71_1();
				radListItems.MultiSelect = false;
				CS_0024_003C_003E8__locals0.comboID = radListItems.SelectedItems[0].SubItems[5].ToString();
				_003C_003Ec__DisplayClass71_.parentListItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.comboID.ToString() && !a[1].ToString().Contains("ADD:") && !a[1].ToString().Contains("OPT: ")).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.comboID.ToString() == "0")
				{
					flag = true;
				}
			}
			int num = 0;
			foreach (ListViewDataItem item2 in radListItems.Items)
			{
				if (item2.Font.Strikeout)
				{
					num++;
				}
			}
			int num2 = radListItems.Items.IndexOf(_003C_003Ec__DisplayClass71_.parentListItem);
			int num3 = radListItems.SelectedItems.Count;
			int num4 = radListItems.SelectedItems.Count - 1;
			if (_003C_003Ec__DisplayClass71_.parentListItem != null && _003C_003Ec__DisplayClass71_.parentListItem.SubItems[4].ToString() == selectedItem.SubItems[4].ToString())
			{
				flag = true;
			}
			_003C_003Ec__DisplayClass71_2 _003C_003Ec__DisplayClass71_2 = new _003C_003Ec__DisplayClass71_2();
			_003C_003Ec__DisplayClass71_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass71_;
			_003C_003Ec__DisplayClass71_2.z = num4;
			while (true)
			{
				if (_003C_003Ec__DisplayClass71_2.z >= 0)
				{
					Item oneItem = new DataManager().getOneItem(Convert.ToInt32(radListItems.SelectedItems[_003C_003Ec__DisplayClass71_2.z].SubItems[4].ToString()));
					decimal num5 = MathHelper.FractionToDecimal(radListItems.SelectedItems[_003C_003Ec__DisplayClass71_2.z][0].ToString());
					for (int i = 0; (decimal)i < num5; i++)
					{
						list_5.Remove(oneItem.ItemID);
					}
					decimal num6 = (oneItem.OnSale ? oneItem.ItemSalePrice.Value : oneItem.ItemPrice);
					bool flag2 = false;
					if (!string.IsNullOrEmpty(string_5) && radListItems.SelectedItems[_003C_003Ec__DisplayClass71_2.z].SubItems.Count >= 7)
					{
						if (!string.IsNullOrEmpty(radListItems.SelectedItems[_003C_003Ec__DisplayClass71_2.z].SubItems[6].ToString()))
						{
							if (num5 < 1m && !radListItems.SelectedItems[_003C_003Ec__DisplayClass71_2.z].SubItems[1].ToString().Contains("---"))
							{
								new NotificationLabel(this, "You cannot removed a shared item. ", NotificationTypes.Warning).Show();
								btnRemove.Enabled = true;
								return;
							}
							if (num + num3 == radListItems.Items.Count && !radListItems.SelectedItems[0].Font.Strikeout)
							{
								new NotificationLabel(this, Resources.If_you_are_cancelling_an_entir, NotificationTypes.Warning).Show();
								btnRemove.Enabled = true;
								return;
							}
							foreach (ListViewDataItem selectedItem2 in radListItems.SelectedItems)
							{
								if (!selectedItem2.Font.Strikeout)
								{
									selectedItem2.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Strikeout);
								}
								else
								{
									selectedItem2.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Regular);
								}
								_003C_003Ec__DisplayClass71_2.z--;
								num3--;
							}
							btnRemove.Text = ((radListItems.SelectedItems[0].Font == null || !radListItems.SelectedItems[0].Font.Strikeout) ? "REMOVE ITEM" : "UNREMOVE ITEM");
						}
						else
						{
							if (num + num3 == radListItems.Items.Count && num > 0)
							{
								break;
							}
							flag2 = true;
						}
					}
					else
					{
						flag2 = true;
					}
					if (flag2)
					{
						if (flag)
						{
							int selectedIndex = radListItems.SelectedIndex;
							radListItems.Items.RemoveAt(selectedIndex);
							num3--;
						}
						else if (num4 == 0)
						{
							_003C_003Ec__DisplayClass71_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass71_3();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass71_2;
							string text2 = radListItems.SelectedItems[CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z].SubItems[1].ToString();
							CS_0024_003C_003E8__locals1.Tag = ((!text2.Contains("[") || !text2.Contains("]")) ? "OPTIONS" : Regex.Match(text2.ToUpper().Replace("OPT: ", "").Replace("ADD: ", "")
								.Replace("---", ""), "\\[([^]]*)\\]").Groups[1].Value);
							decimal num7 = MathHelper.FractionToDecimal(radListItems.SelectedItems[CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z][0].ToString());
							num6 = MathHelper.FractionToDecimal(radListItems.SelectedItems[CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z][2].ToString());
							usp_ItemOptionsResult usp_ItemOptionsResult = (from x in new GClass6().usp_ItemOptions()
								where !x.ToBeDeleted && x.ItemID.Value.ToString() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.parentListItem.SubItems[4].ToString() && x.Option_ItemID == Convert.ToInt32(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.radListItems.SelectedItems[CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z].SubItems[4].ToString().Trim()) && x.Tab.ToUpper() == CS_0024_003C_003E8__locals1.Tag.ToUpper()
								select x).FirstOrDefault();
							if (usp_ItemOptionsResult != null)
							{
								int selectedIndex2 = radListItems.SelectedIndex;
								if (num7 < usp_ItemOptionsResult.Qty)
								{
									radListItems.Items.RemoveAt(selectedIndex2);
									if (num6 > 0m)
									{
										radListItems.Items.RemoveAt(selectedIndex2 - 1);
									}
									else
									{
										radListItems.Items.RemoveAt(selectedIndex2);
									}
									int z = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z;
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.z = z - 1;
									num3--;
								}
								else
								{
									if (Convert.ToDecimal(radListItems.Items[selectedIndex2].SubItems[8].ToString()) != Convert.ToDecimal(radListItems.Items[selectedIndex2].SubItems[3].ToString()))
									{
										decimal num8 = radListItems.Items[num2][3].ToString().ToDecimalWithCleanUp() - Convert.ToDecimal(radListItems.Items[selectedIndex2].SubItems[8].ToString());
										radListItems.Items[num2][2] = $"{num8:0.00}";
										radListItems.Items[num2][3] = (MathHelper.FractionToDecimal(radListItems.Items[num2][0].ToString().Replace(",", ".")) * Convert.ToDecimal(radListItems.Items[num2][2].ToString(), Thread.CurrentThread.CurrentCulture)).ToString("0.00", Thread.CurrentThread.CurrentCulture);
										radListItems.Items[num2].SubItems[8] = $"{num8:0.00}";
									}
									radListItems.Items.RemoveAt(selectedIndex2);
									num3--;
								}
							}
						}
						if (_003C_003Ec__DisplayClass71_2.z > -1)
						{
							ListViewDataItem[] array = new ListViewDataItem[_003C_003Ec__DisplayClass71_2.z];
							for (int j = num2; j < num2 + _003C_003Ec__DisplayClass71_2.z; j++)
							{
								array[j - num2] = radListItems.Items[j];
							}
							radListItems.Select(array);
						}
					}
					_003C_003Ec__DisplayClass71_2.z--;
					continue;
				}
				RecalculateTaxAndSubtotal();
				method_18();
				return;
			}
			new NotificationLabel(this, Resources.If_you_are_cancelling_an_entir, NotificationTypes.Warning).Show();
			btnRemove.Enabled = true;
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_you_wish, NotificationTypes.Notification).Show();
		}
	}

	private void method_17()
	{
		btnSaveOrder.Enabled = false;
		btnRemove.Enabled = false;
		btnInstructions.Enabled = false;
		btnItemOptions.Enabled = false;
	}

	private void radListItems_SelectedItemChanged(object sender, EventArgs e)
	{
		method_18();
	}

	private void method_18()
	{
		if (radListItems.Items.Count > 0)
		{
			if (radListItems.SelectedItems.Count > 0)
			{
				if (radListItems.SelectedItems[0].SubItems[5].ToString() != string.Empty && radListItems.SelectedItems[0].SubItems[4].ToString() != string.Empty)
				{
					_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass74_0();
					CS_0024_003C_003E8__locals0.itemId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
					if (gclass6_0.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.itemId && i.ToBeDeleted == false).ToList().Count() > 0)
					{
						btnItemOptions.Enabled = true;
					}
					else
					{
						btnItemOptions.Enabled = false;
					}
				}
				else
				{
					btnItemOptions.Enabled = false;
				}
				if (!string.IsNullOrEmpty(radListItems.SelectedItems[0].SubItems[6].ToString()))
				{
					Button button = btnRemove;
					Button button2 = btnInstructions;
					btnItemOptions.Enabled = false;
					button2.Enabled = false;
					button.Enabled = false;
				}
				else
				{
					Button button3 = btnRemove;
					btnInstructions.Enabled = true;
					button3.Enabled = true;
				}
			}
			else
			{
				Button button4 = btnRemove;
				Button button5 = btnInstructions;
				btnItemOptions.Enabled = false;
				button5.Enabled = false;
				button4.Enabled = false;
			}
			{
				foreach (ListViewDataItem item in radListItems.Items)
				{
					if (!string.IsNullOrEmpty(item.SubItems[6].ToString()))
					{
						btnSaveOrder.Enabled = false;
						continue;
					}
					btnSaveOrder.Enabled = true;
					break;
				}
				return;
			}
		}
		method_17();
	}

	private void btnInstructions_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Instructions();
			MemoryLoadedObjects.Instructions.page_load(this);
			MemoryLoadedObjects.Instructions.ShowDialog(this);
			btnSaveOrder.Enabled = true;
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_on_the_b, NotificationTypes.Notification).Show();
		}
	}

	private void btnItemOptions_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count <= 0)
		{
			return;
		}
		if (radListItems.SelectedItems[0] != null)
		{
			_003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass76_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.itemID = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
			CS_0024_003C_003E8__locals0.comboId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[5].ToString());
			CS_0024_003C_003E8__locals0.optionComboId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[11].ToString());
			if (radListItems.SelectedItems.Count <= 0)
			{
				return;
			}
			if ((from i in gClass.usp_ItemOptions()
				where i.ItemID == CS_0024_003C_003E8__locals0.itemID && !i.ToBeDeleted
				orderby i.SortOrder, i.ItemName
				select i).ToList().Count() > 0)
			{
				decimal itemQty = Convert.ToDecimal(radListItems.SelectedItems[0][0].ToString());
				string itemName = radListItems.SelectedItems[0][1].ToString();
				List<SelectedOptionObject> list = (from a in radListItems.Items
					where a.SubItems[11].ToString() == CS_0024_003C_003E8__locals0.optionComboId.ToString() && !a.Font.Strikeout && a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.comboId.ToString() && (a[1].ToString().Contains("ADD:") || a[1].ToString().Contains("OPT: "))
					select new SelectedOptionObject
					{
						tag = ((!a[1].ToString().Contains("[") || !a[1].ToString().Contains("]")) ? "OPTIONS" : Regex.Match(a[1].ToString().ToUpper().Replace("OPT: ", "")
							.Replace("ADD: ", "")
							.Replace("---", ""), "\\[([^]]*)\\]").Groups[1].Value),
						item_name = Regex.Replace(a[1].ToString().ToUpper().Replace("OPT: ", "")
							.Replace("ADD: ", "")
							.Replace("---", ""), "(\\[.*\\])", "").Trim(),
						option_itemId = Convert.ToInt32(a.SubItems[4].ToString().Trim()),
						price = Convert.ToDecimal(a.SubItems[8].ToString()),
						qty = MathHelper.FractionToDecimal(a[0].ToString()),
						is_solo_group_option = ((Convert.ToDecimal(a.SubItems[8].ToString()) != Convert.ToDecimal(a.SubItems[3].ToString())) ? true : false)
					}).ToList();
				List<SelectedOptionObject> list2 = new List<SelectedOptionObject>();
				decimal num = default(decimal);
				using (List<SelectedOptionObject>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass76_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass76_1();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
						CS_0024_003C_003E8__locals1.selOption = enumerator.Current;
						usp_ItemOptionsResult usp_ItemOptionsResult = (from x in gClass.usp_ItemOptions()
							where !x.ToBeDeleted && x.Option_ItemID == CS_0024_003C_003E8__locals1.selOption.option_itemId && x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemID && x.Tab.ToUpper() == CS_0024_003C_003E8__locals1.selOption.tag.ToUpper()
							select x).FirstOrDefault();
						if (usp_ItemOptionsResult != null)
						{
							CS_0024_003C_003E8__locals1.selOption.allow_additional = usp_ItemOptionsResult.AllowAdditional;
							if (usp_ItemOptionsResult.Qty == 0m)
							{
								CS_0024_003C_003E8__locals1.selOption.qty = 0m;
								continue;
							}
							if (CS_0024_003C_003E8__locals1.selOption.qty + num < usp_ItemOptionsResult.Qty && CS_0024_003C_003E8__locals1.selOption.price == 0m)
							{
								list2.Add(CS_0024_003C_003E8__locals1.selOption);
							}
							num += CS_0024_003C_003E8__locals1.selOption.qty;
							if (num == usp_ItemOptionsResult.Qty)
							{
								CS_0024_003C_003E8__locals1.selOption.qty = num;
								CS_0024_003C_003E8__locals1.selOption.price = num * CS_0024_003C_003E8__locals1.selOption.price;
								num = default(decimal);
							}
						}
						else
						{
							list2.Add(CS_0024_003C_003E8__locals1.selOption);
						}
					}
				}
				foreach (SelectedOptionObject item in list2)
				{
					list.Remove(item);
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
				MemoryLoadedObjects.OptionScreen.LoadForm(itemName, CS_0024_003C_003E8__locals0.itemID, itemQty, radListItems.SelectedIndex, CS_0024_003C_003E8__locals0.optionComboId, this, string_1, list);
				MemoryLoadedObjects.OptionScreen.ShowDialog(this);
				btnSaveOrder.Enabled = true;
			}
			else
			{
				new NotificationLabel(this, Resources.Please_select_the_main_combo_i, NotificationTypes.Notification).Show();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_first, NotificationTypes.Notification).Show();
		}
	}

	private void btnSearchItems_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search_Items, 2);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			new GClass6();
			int_6 = 1;
			List<Item> source = (from i in MemoryLoadedData.ListOfItemsInGroupMemory
				where i.Group.ShowInPatronKiosk && i.Item.ItemName.ToLower().Contains(MemoryLoadedObjects.Keyboard.textEntered.ToLower()) && i.Item.Active && !i.Item.isDeleted && i.Item.ItemClassification == ItemClassifications.Product
				select i into a
				select a.Item).Distinct().ToList();
			list_2 = source.ToList();
			lblItemsHeader.Text = Resources.Items_for0 + MemoryLoadedObjects.Keyboard.textEntered + "'";
			string_6 = string.Empty;
			method_14();
		}
	}

	private void btnSaveOrder_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			if (method_19())
			{
				List<Order> source = new OrderMethods(new GClass6()).Orders(string_5);
				if (new frmKioskPay(string_5, source.Sum((Order x) => x.Total)).ShowDialog() == DialogResult.OK)
				{
					bool_1 = false;
					bool_2 = false;
					btnSaveOrder.Enabled = false;
					base.DialogResult = DialogResult.Cancel;
					method_6();
					HideForm();
				}
			}
		}
		else if (radListItems.Items.Count > 0 && ((!(SettingsHelper.CurrentTerminalMode == "Patron") && !(SettingsHelper.CurrentTerminalMode == "Kiosk")) || new frmMessageBox(Resources.Are_you_sure_you_want_to_send_, Resources.Send_To_Kitchen, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.No) && method_19())
		{
			loadOrderByOrderNumber(string_5);
			if (bool_1)
			{
				new NotificationLabel(this, "Kitchen has been notified.", NotificationTypes.Success).Show();
			}
			if (bool_2)
			{
				new NotificationLabel(this, "Bar has been notified.", NotificationTypes.Success).Show();
			}
			bool_1 = false;
			bool_2 = false;
			btnSaveOrder.Enabled = false;
		}
	}

	private bool method_19(bool? nullable_0 = null)
	{
		try
		{
			if (!nullable_0.HasValue)
			{
				nullable_0 = method_20();
			}
			if (nullable_0.Value)
			{
				string text = "SAVED ORDER";
				if (SettingsHelper.CurrentTerminalMode == "Kiosk")
				{
					text = "KIOSK SAVED ORDER";
				}
				if (GuestMethods.GetCurrentTableGuestCapacity(string_0.Replace("Table", string.Empty).Trim()) == 0)
				{
					GuestMethods.UpdateTableGuestCapacity(string_0.Replace("Table", string.Empty).Trim(), int_0, Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
				}
				new OrderMethods().SaveOrder(list_4, string_5.ToUpper(), string_0, string_1, 0, text, 0m, 0m, isPaid: false, "", "", string_2, string_3, int_0, isDiscount: false, string.Empty, 1, null, null, 0, null, "", GratuityRemoved: false, 0);
				orderHelper_0.OrderPrintMadeCheck(text, string_5, string_1, string_2, string_0, string_4, list_4.Count());
				int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
				Employee userByID = UserMethods.GetUserByID((short)num);
				if (userByID != null && userByID.Users.FirstOrDefault().Role.RoleName == "Staff")
				{
					GuestMethods.AssignEmployeeTable(string_0.Replace("Table", string.Empty).Trim(), num);
				}
				return nullable_0.Value;
			}
			return nullable_0.Value;
		}
		catch (Exception ex)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
			new frmMessageBox(Resources.An_error_occurred_trying_to_sa).ShowDialog(this);
			return false;
		}
	}

	private bool method_20(bool bool_8 = true)
	{
		new GClass6();
		if (radListItems.Items.Count == 0)
		{
			new NotificationLabel(this, Resources.There_are_no_items_to_save_Ple, NotificationTypes.Notification).Show();
			return false;
		}
		if (string.IsNullOrEmpty(string_5))
		{
			string_5 = OrderMethods.GetNewOrderNumber();
		}
		list_4 = new List<Item>();
		foreach (ListViewDataItem item2 in radListItems.Items)
		{
			_003C_003Ec__DisplayClass80_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass80_0();
			DataManager dataManager = new DataManager();
			Item item = new Item();
			CS_0024_003C_003E8__locals0.itemFromDB = dataManager.getOneItem(Convert.ToInt32(item2.SubItems[4].ToString()));
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
			item.InventoryCount = CS_0024_003C_003E8__locals0.itemFromDB.InventoryCount;
			item.ItemSalePrice = CS_0024_003C_003E8__locals0.itemFromDB.ItemSalePrice;
			item.ItemType = CS_0024_003C_003E8__locals0.itemFromDB.ItemType;
			item.ItemTypeID = CS_0024_003C_003E8__locals0.itemFromDB.ItemTypeID;
			item.OnSale = CS_0024_003C_003E8__locals0.itemFromDB.OnSale;
			item.TaxRule = CS_0024_003C_003E8__locals0.itemFromDB.TaxRule;
			item.TaxRuleID = CS_0024_003C_003E8__locals0.itemFromDB.TaxRuleID;
			item.ItemName = item2[1].ToString();
			item.ItemPrice = Convert.ToDecimal(item2[2].ToString(), Thread.CurrentThread.CurrentCulture);
			item.InventoryCount = MathHelper.FractionToDecimal(item2[0].ToString().Replace(",", "."));
			if (!(item.ItemPrice * item.InventoryCount > 100000m))
			{
				item.SortOrder = Convert.ToInt16(item2.SubItems[5].ToString());
				item.Temp = ((item2.SubItems.Count >= 7) ? item2.SubItems[6].ToString() : string.Empty);
				item.Description = ((item2.SubItems.Count >= 8) ? item2.SubItems[7].ToString() : string.Empty);
				if (item.Description.Length <= 250)
				{
					item.Active = !item2.Font.Strikeout;
					item.ItemCourse = ((item2.SubItems.Count >= 7) ? item2.SubItems[9].ToString() : "0");
					if (!item.ItemName.Contains("SUB:") && !item.ItemName.Contains("ADD:") && !item.ItemName.Contains("OPT:"))
					{
						item.ItemCost = ((item2.SubItems.Count < 9 || !(item2.SubItems[8].ToString() != "-1")) ? (-1m) : Convert.ToDecimal(item2[2].ToString(), Thread.CurrentThread.CurrentCulture));
					}
					else
					{
						item.ItemCost = Convert.ToDecimal(item2[2].ToString(), Thread.CurrentThread.CurrentCulture);
					}
					item.Notes = item2.SubItems[13].ToString();
					item.StationID = item2.SubItems[14].ToString();
					item.DisableSoldOutItems = false;
					_ = item.Active;
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.itemFromDB.StationID) && (!item.Active || string.IsNullOrEmpty(item.Temp)))
					{
						if (CS_0024_003C_003E8__locals0.itemFromDB.StationID.Split(',').Contains("1"))
						{
							bool_1 = true;
						}
						else if (CS_0024_003C_003E8__locals0.itemFromDB.StationID.Split(',').Contains("2"))
						{
							bool_2 = true;
						}
					}
					list_4.Add(item);
					continue;
				}
				new frmMessageBox("Invalid Order, Instructions is too long", "Invalid order").ShowDialog(this);
				return false;
			}
			new frmMessageBox("Invalid order, total price is too large.", "Invalid order").ShowDialog(this);
			return false;
		}
		return true;
	}

	private void btnSaveOrder_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (frmMasterForm.lockedControls != null && frmMasterForm.lockedControls.Select((LockedControl x) => x.Name).Contains(button.Name) && button.Enabled)
		{
			button.Enabled = false;
		}
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

	private void timer_0_Tick(object sender, EventArgs e)
	{
		try
		{
			if (bool_7)
			{
				return;
			}
			bool_7 = true;
			timer_0.Enabled = false;
			pnlItems.Controls.Clear();
			int count = list_2.Count;
			if (count > 4)
			{
				Label label = new Label();
				label.BackColor = Color.Transparent;
				label.Width = 1;
				label.Height = 50;
				pnlItems.Controls.Add(label);
			}
			int num = 0;
			int num2 = pnlItems.Width - 12;
			int_7 = 0;
			using (IEnumerator<string> enumerator = list_2.Select((Item x) => x.ItemID.ToString()).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass83_0();
					CS_0024_003C_003E8__locals0.itemToDisplay = enumerator.Current;
					PatronItemControl patronItemControl = MemoryLoadedObjects.ListOfPatronItemControlObject.Where((PatronItemControl a) => a.Name == CS_0024_003C_003E8__locals0.itemToDisplay).FirstOrDefault();
					patronItemControl.Width = num2;
					patronItemControl.Location = new Point(0, num * 130);
					patronItemControl.AddItem_Click = PatronItemAddItem_Click;
					patronItemControl.ScrollMouseDown = pnlItems_MouseDown;
					patronItemControl.ScrollMouseUp = pnlItems_MouseUp;
					patronItemControl.ScrollMouseMove = pnlItems_MouseMove;
					pnlItems.Controls.Add(patronItemControl);
					num++;
					int_7 += patronItemControl.Height + 5;
				}
			}
			if (count > 4)
			{
				Label label2 = new Label();
				label2.BackColor = Color.Transparent;
				label2.Width = 1;
				label2.Height = 48;
				pnlItems.Controls.Add(label2);
			}
			bool_7 = false;
			pnlItems.AutoScrollPosition = new Point(pnlItems.HorizontalScroll.Value, 50);
			int_7 = int_7 - pnlItems.Height + 48;
		}
		catch (Exception ex)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
		}
	}

	private void radListItems_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
	{
		if (e.CellElement.Data.HeaderText == "Price" && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
			e.CellElement.Padding = new Padding(0, 0, 10, 0);
		}
		else if (e.CellElement.Data.HeaderText == "Qty" && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
		}
		else if (e.CellElement.Data.HeaderText == "Item Name" && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.Padding = new Padding(5, 0, 5, 0);
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (bool_6 || !(SettingsHelper.CurrentTerminalMode != "Kiosk"))
			{
				return;
			}
			IQueryable<Order> source = new GClass6().Orders.Where((Order o) => o.Customer == string_0 && o.OrderType == OrderTypes.DineIn && o.DateCleared == null && o.Void == false && o.Paid == false && o.DatePaid == null && o.DateCreated.Value.AddDays(1.0) >= DateTime.Now);
			if (source.Count() <= 0 || source.Count() == radListItems.Items.Where((ListViewDataItem a) => a.SubItems[6].ToString() != string.Empty).Count())
			{
				return;
			}
			List<ListViewDataItem> list = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[6].ToString() == string.Empty).ToList();
			new NotificationLabel(this, "Items have been added from another device.  Your order has been updated.", NotificationTypes.Notification).Show();
			loadOrderByOrderNumber(source.First().OrderNumber);
			foreach (ListViewDataItem item in list)
			{
				radListItems.Items.Add(item);
			}
		}
		catch (Exception ex)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, ex);
			DebugMethods.ShowExceptionTextFile(ex);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPatron));
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "Qty");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Item Name");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 2", "Price");
		ListViewDetailColumn listViewDetailColumn4 = new ListViewDetailColumn("Column 3", "Ext. Price");
		ListViewDataItem listViewDataItem = new ListViewDataItem("ListViewItem 1");
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		label7 = new Label();
		label6 = new Label();
		pictureBox1 = new PictureBox();
		lblTableName = new Label();
		label5 = new Label();
		label4 = new Label();
		label1 = new Label();
		btnItemOptions = new Button();
		pnlItems = new FlowLayoutPanel();
		label3 = new Label();
		pnlGroups = new FlowLayoutPanel();
		btnSearchItems = new Button();
		lblItemsHeader = new Label();
		btnClose = new Button();
		btnInstructions = new Button();
		btnRemove = new Button();
		btnSaveOrder = new Button();
		label2 = new Label();
		label8 = new Label();
		radListItems = new CustomListViewTelerik();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)radListItems).BeginInit();
		SuspendLayout();
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.BackColor = Color.FromArgb(43, 46, 51);
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(label6, "label6");
		label6.BackColor = Color.FromArgb(43, 46, 51);
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.BackColor = Color.LightGray;
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(lblTableName, "lblTableName");
		lblTableName.BackColor = Color.FromArgb(43, 46, 51);
		lblTableName.ForeColor = Color.SandyBrown;
		lblTableName.Name = "lblTableName";
		componentResourceManager.ApplyResources(label5, "label5");
		label5.BackColor = Color.Black;
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(label4, "label4");
		label4.BackColor = Color.Black;
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.LightGray;
		label1.ForeColor = Color.Black;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(btnItemOptions, "btnItemOptions");
		btnItemOptions.BackColor = Color.FromArgb(147, 101, 184);
		btnItemOptions.FlatAppearance.BorderColor = Color.Sienna;
		btnItemOptions.FlatAppearance.BorderSize = 0;
		btnItemOptions.FlatAppearance.MouseDownBackColor = Color.White;
		btnItemOptions.ForeColor = Color.White;
		btnItemOptions.Name = "btnItemOptions";
		btnItemOptions.UseVisualStyleBackColor = false;
		btnItemOptions.EnabledChanged += btnSaveOrder_EnabledChanged;
		btnItemOptions.Click += btnItemOptions_Click;
		componentResourceManager.ApplyResources(pnlItems, "pnlItems");
		pnlItems.BackColor = Color.FromArgb(35, 39, 56);
		pnlItems.Name = "pnlItems";
		label3.BackColor = Color.FromArgb(43, 46, 51);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(pnlGroups, "pnlGroups");
		pnlGroups.BackColor = Color.FromArgb(35, 39, 56);
		pnlGroups.Name = "pnlGroups";
		componentResourceManager.ApplyResources(btnSearchItems, "btnSearchItems");
		btnSearchItems.BackColor = Color.FromArgb(53, 152, 220);
		btnSearchItems.FlatAppearance.BorderColor = Color.Sienna;
		btnSearchItems.FlatAppearance.BorderSize = 0;
		btnSearchItems.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearchItems.ForeColor = Color.White;
		btnSearchItems.Name = "btnSearchItems";
		btnSearchItems.UseVisualStyleBackColor = false;
		btnSearchItems.Click += btnSearchItems_Click;
		componentResourceManager.ApplyResources(lblItemsHeader, "lblItemsHeader");
		lblItemsHeader.BackColor = Color.FromArgb(43, 46, 51);
		lblItemsHeader.ForeColor = Color.White;
		lblItemsHeader.Name = "lblItemsHeader";
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.EnabledChanged += btnSaveOrder_EnabledChanged;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(btnInstructions, "btnInstructions");
		btnInstructions.BackColor = Color.FromArgb(53, 152, 220);
		btnInstructions.FlatAppearance.BorderColor = Color.Sienna;
		btnInstructions.FlatAppearance.BorderSize = 0;
		btnInstructions.FlatAppearance.MouseDownBackColor = Color.White;
		btnInstructions.ForeColor = Color.White;
		btnInstructions.Name = "btnInstructions";
		btnInstructions.UseVisualStyleBackColor = false;
		btnInstructions.EnabledChanged += btnSaveOrder_EnabledChanged;
		btnInstructions.Click += btnInstructions_Click;
		componentResourceManager.ApplyResources(btnRemove, "btnRemove");
		btnRemove.BackColor = Color.SandyBrown;
		btnRemove.FlatAppearance.BorderColor = Color.Black;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.White;
		btnRemove.ForeColor = Color.White;
		btnRemove.Name = "btnRemove";
		btnRemove.UseVisualStyleBackColor = false;
		btnRemove.EnabledChanged += btnSaveOrder_EnabledChanged;
		btnRemove.Click += btnRemove_Click;
		componentResourceManager.ApplyResources(btnSaveOrder, "btnSaveOrder");
		btnSaveOrder.BackColor = Color.FromArgb(65, 168, 95);
		btnSaveOrder.FlatAppearance.BorderColor = Color.Black;
		btnSaveOrder.FlatAppearance.BorderSize = 0;
		btnSaveOrder.FlatAppearance.MouseDownBackColor = Color.White;
		btnSaveOrder.ForeColor = Color.White;
		btnSaveOrder.Name = "btnSaveOrder";
		btnSaveOrder.UseVisualStyleBackColor = false;
		btnSaveOrder.EnabledChanged += btnSaveOrder_EnabledChanged;
		btnSaveOrder.Click += btnSaveOrder_Click;
		label2.BackColor = Color.FromArgb(43, 46, 51);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label8.BackColor = Color.FromArgb(43, 46, 51);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		radListItems.AllowArbitraryItemHeight = true;
		radListItems.AllowColumnReorder = false;
		radListItems.AllowColumnResize = false;
		radListItems.AllowEdit = false;
		radListItems.AllowRemove = false;
		componentResourceManager.ApplyResources(radListItems, "radListItems");
		listViewDetailColumn.HeaderText = "Qty";
		listViewDetailColumn.Width = 50f;
		listViewDetailColumn2.HeaderText = "Item Name";
		listViewDetailColumn2.Width = 302f;
		listViewDetailColumn3.HeaderText = "Price";
		listViewDetailColumn3.MinWidth = 80f;
		listViewDetailColumn3.Width = 87f;
		listViewDetailColumn4.HeaderText = "Ext. Price";
		listViewDetailColumn4.Visible = false;
		listViewDetailColumn4.Width = 20f;
		radListItems.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2, listViewDetailColumn3, listViewDetailColumn4);
		radListItems.EnableGestures = false;
		radListItems.EnableKineticScrolling = true;
		radListItems.GroupItemSize = new Size(200, 40);
		listViewDataItem.Text = "ListViewItem 1";
		radListItems.Items.AddRange(listViewDataItem);
		radListItems.ItemSize = new Size(200, 50);
		radListItems.ItemSpacing = -1;
		radListItems.Name = "radListItems";
		radListItems.ShowColumnHeaders = false;
		radListItems.ShowGridLines = true;
		radListItems.ViewType = ListViewType.DetailsView;
		radListItems.SelectedItemChanged += radListItems_SelectedItemChanged;
		timer_1.Enabled = true;
		timer_1.Interval = 10000;
		timer_1.Tick += timer_1_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Black;
		base.Controls.Add(pnlItems);
		base.Controls.Add(label7);
		base.Controls.Add(label6);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(lblTableName);
		base.Controls.Add(label5);
		base.Controls.Add(label4);
		base.Controls.Add(label1);
		base.Controls.Add(btnItemOptions);
		base.Controls.Add(label3);
		base.Controls.Add(pnlGroups);
		base.Controls.Add(btnSearchItems);
		base.Controls.Add(lblItemsHeader);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnInstructions);
		base.Controls.Add(btnRemove);
		base.Controls.Add(btnSaveOrder);
		base.Controls.Add(label2);
		base.Controls.Add(label8);
		base.Controls.Add(radListItems);
		DoubleBuffered = true;
		base.Name = "frmPatron";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmPatron_Load;
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)radListItems).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[CompilerGenerated]
	private bool method_21(ItemsInGroup itemsInGroup_0)
	{
		if (itemsInGroup_0.Group.GroupName == string_6 && itemsInGroup_0.Item.Active)
		{
			return !itemsInGroup_0.Item.isDeleted;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_22(ItemsInGroup itemsInGroup_0)
	{
		if (itemsInGroup_0.Group.GroupName == string_6 && itemsInGroup_0.Item.Active)
		{
			return !itemsInGroup_0.Item.isDeleted;
		}
		return false;
	}
}
