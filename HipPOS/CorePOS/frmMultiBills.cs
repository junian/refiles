using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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

public class frmMultiBills : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public OrderResult existingBill;

		public _003C_003Ec__DisplayClass23_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CLoadFormProcedure_003Eb__8(OrderResult a)
		{
			return a.OrderNumber == existingBill.OrderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_1
	{
		public OrderResult orderResult;

		public _003C_003Ec__DisplayClass23_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CLoadFormProcedure_003Eb__9(OrderResult a)
		{
			return a.OrderNumber == orderResult.OrderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public frmMultiBills _003C_003E4__this;

		public string orderNumber;

		public _003C_003Ec__DisplayClass26_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CRemoveBill_003Eb__0()
		{
			try
			{
				Thread.Sleep(2000);
				_003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					_003C_003E4__this.method_7(orderNumber);
				});
			}
			catch
			{
			}
		}

		internal void _003CRemoveBill_003Eb__1()
		{
			_003C_003E4__this.method_7(orderNumber);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public bool TipRecorded;

		public string orderNumber;

		public decimal TipAmount;

		public bool isPaid;

		public OrderChit chit;

		public frmMultiBills _003C_003E4__this;

		public _003C_003Ec__DisplayClass29_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CAddTipLabel_003Eb__0()
		{
			Thread.Sleep(500);
			try
			{
				if ((!TipRecorded && (!orderNumber.Contains("WEB") || !(TipAmount > 0m))) || !isPaid || chit == null)
				{
					return;
				}
				_003C_003Ec__DisplayClass29_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_1();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = this;
				CS_0024_003C_003E8__locals0.lblTip = new TransparentLabel();
				CS_0024_003C_003E8__locals0.lblTip.Size = new Size(chit.Size.Width / 2, 35);
				int num = chit.Location.Y + chit.Size.Height - CS_0024_003C_003E8__locals0.lblTip.Size.Height - 10;
				int y = ((chit.Size.Width / 2 > chit.Size.Height) ? (num + 130) : num);
				CS_0024_003C_003E8__locals0.lblTip.Location = new Point(chit.Location.X, y);
				CS_0024_003C_003E8__locals0.lblTip.Text = Resources.Tip_Amount0 + TipAmount.ToString("$0.00");
				CS_0024_003C_003E8__locals0.lblTip.TextAlign = ContentAlignment.BottomLeft;
				CS_0024_003C_003E8__locals0.lblTip.ForeColor = Color.Black;
				CS_0024_003C_003E8__locals0.lblTip.BackColor = Color.Transparent;
				CS_0024_003C_003E8__locals0.lblTip.Font = new Font("Arial", 11f, FontStyle.Regular);
				CS_0024_003C_003E8__locals0.lblTip.Name = "lblTip" + orderNumber;
				CS_0024_003C_003E8__locals0.lblTip.Opacity = 80;
				_003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					if (CS_0024_003C_003E8__locals0.lblTip != null && !CS_0024_003C_003E8__locals0.lblTip.IsDisposed)
					{
						SizeF sizeF = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.CreateGraphics().MeasureString(Resources.Tip_Amount0 + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.TipAmount.ToString("$0.00"), CS_0024_003C_003E8__locals0.lblTip.Font);
						if (sizeF.Width > (float)CS_0024_003C_003E8__locals0.lblTip.Size.Width)
						{
							CS_0024_003C_003E8__locals0.lblTip.Size = new Size(Convert.ToInt16(sizeF.Width), 35);
						}
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Add(CS_0024_003C_003E8__locals0.lblTip);
						CS_0024_003C_003E8__locals0.lblTip.BringToFront();
						if ((OrderChit)CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Find("chit" + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber, searchAllChildren: false).FirstOrDefault() == null && CS_0024_003C_003E8__locals0.lblTip != null && !CS_0024_003C_003E8__locals0.lblTip.IsDisposed)
						{
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Remove(CS_0024_003C_003E8__locals0.lblTip);
							CS_0024_003C_003E8__locals0.lblTip.Dispose();
						}
					}
				});
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog("Add Tip Label ERROR: " + ex.Message + "\n" + ex.StackTrace, LogTypes.error_log);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_1
	{
		public TransparentLabel lblTip;

		public _003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass29_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CAddTipLabel_003Eb__1()
		{
			if (lblTip != null && !lblTip.IsDisposed)
			{
				SizeF sizeF = CS_0024_003C_003E8__locals1._003C_003E4__this.CreateGraphics().MeasureString(Resources.Tip_Amount0 + CS_0024_003C_003E8__locals1.TipAmount.ToString("$0.00"), lblTip.Font);
				if (sizeF.Width > (float)lblTip.Size.Width)
				{
					lblTip.Size = new Size(Convert.ToInt16(sizeF.Width), 35);
				}
				CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Add(lblTip);
				lblTip.BringToFront();
				if ((OrderChit)CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Find("chit" + CS_0024_003C_003E8__locals1.orderNumber, searchAllChildren: false).FirstOrDefault() == null && lblTip != null && !lblTip.IsDisposed)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Remove(lblTip);
					lblTip.Dispose();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public Control lv;

		public _003C_003Ec__DisplayClass30_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CsubBillsClick_003Eb__0(OrderResult a)
		{
			return a.OrderNumber == lv.Name;
		}

		internal bool _003CsubBillsClick_003Eb__1(OrderResult a)
		{
			return a.OrderNumber == lv.Name;
		}

		internal bool _003CsubBillsClick_003Eb__4(OrderResult a)
		{
			return a.OrderNumber == lv.Name;
		}

		internal bool _003CsubBillsClick_003Eb__5(OrderResult a)
		{
			return a.OrderNumber == lv.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_1
	{
		public string oNum;

		public _003C_003Ec__DisplayClass30_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CsubBillsClick_003Eb__2(OrderResult a)
		{
			return a.OrderNumber == oNum;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_2
	{
		public string OrdNum;

		public _003C_003Ec__DisplayClass30_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CsubBillsClick_003Eb__3(OrderResult a)
		{
			return a.OrderNumber == OrdNum;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_3
	{
		public string oNum;

		public _003C_003Ec__DisplayClass30_3()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CsubBillsClick_003Eb__6(OrderResult a)
		{
			return a.OrderNumber == oNum;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public OrderResult orderResult;

		public _003C_003Ec__DisplayClass34_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public Button btn;

		public _003C_003Ec__DisplayClass36_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003Cbutton_EnabledChanged_003Eb__0(LockedControl x)
		{
			return x.Name.Contains(btn.Name);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass38_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_1
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass38_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public OrderChit orderchit;

		public _003C_003Ec__DisplayClass39_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003Ctimer1_Tick_003Eb__3(Order o)
		{
			return o.OrderNumber == orderchit.OrderNumber.First();
		}
	}

	private short short_0;

	private short short_1;

	private string[] string_0;

	private FormHelper formHelper_0;

	private OrderMethods orderMethods_0;

	private Font font_0;

	public string screenOrderType;

	private string string_1;

	private short short_2;

	public List<OrderResult> multipleBillsToCompare;

	private List<OrderResult> list_2;

	private frmLayout frmLayout_0;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private string string_2;

	private IContainer icontainer_1;

	internal Panel BillsPanel;

	internal Button CgDyNrYqmq;

	internal Panel Panel1;

	internal Button BtnCancel;

	internal Button btnSelectionMerge;

	internal Button btnClearTable;

	private System.Windows.Forms.Timer timer_0;

	private Label lblTraining;

	internal Button btnNewTakeOut;

	internal Button btnToGo;

	private VerticalScrollControl vScrollBillsPanel;

	internal Button btnCashoutBill;

	private Label WxBypksAks;

	internal Button btnNewDeliveryOrder;

	internal Button btnPrintChit;

	internal Button btnNewCatering;

	private Panel panel2;

	internal Button btnOTFilter_All;

	private Label label1;

	internal Button btnOTFilter_Catering;

	internal Button btnOTFilter_Delivery;

	internal Button btnOTFilter_PickUp;

	internal Button btnOTFilter_ToGo;

	internal Button btnClearSearch;

	private Label label3;

	private RadTextBoxControl txtSearchInfo;

	internal Button btnShowKeyboard_SearchInfo;

	private Label lblTitle;

	internal Button btnNotifyCustomer;

	private Label lblSelectNotify;

	internal Button btnConfirmOnlineOrders;

	internal System.Windows.Forms.Timer timer_1;

	private System.Windows.Forms.Timer timer_2;

	private Class19 ddlDateRangeFilter;

	private Label lblSplitTitle;

	public frmMultiBills()
	{
		Class26.Ggkj0JxzN9YmC();
		short_0 = 308;
		short_1 = 10;
		string_0 = new string[1001];
		formHelper_0 = new FormHelper();
		orderMethods_0 = new OrderMethods();
		int_0 = 1;
		bool_1 = true;
		string_2 = "ALL";
		base._002Ector();
		InitializeComponent_1();
		btnConfirmOnlineOrders.Tag = btnConfirmOnlineOrders.BackColor;
		new FormHelper().ResizeButtonFonts(this);
		vScrollBillsPanel.ConnectedPanel = BillsPanel;
		Dictionary<int, string> dataSource = MiscHelper.GenDateRangeFilters();
		ddlDateRangeFilter.DisplayMember = "Value";
		ddlDateRangeFilter.ValueMember = "Key";
		ddlDateRangeFilter.DataSource = new BindingSource(dataSource, null);
		ddlDateRangeFilter.SelectedIndex = 0;
	}

	public void LoadFormData(frmLayout frm, string cus, string ot)
	{
		screenOrderType = ot;
		string_1 = cus;
		frmLayout_0 = frm;
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Visible = true;
		}
		else
		{
			lblTraining.Visible = false;
		}
		if (screenOrderType == OrderTypes.DineIn)
		{
			panel2.Visible = false;
			lblSplitTitle.Visible = true;
			lblSplitTitle.Text = cus;
			BillsPanel.Location = new Point(0, lblSplitTitle.Bottom + 1);
			BillsPanel.Size = new Size(BillsPanel.Width, base.Height - Panel1.Height - 2);
			vScrollBillsPanel.Location = new Point(vScrollBillsPanel.Location.X, BillsPanel.Location.Y - lblSplitTitle.Size.Height);
			ddlDateRangeFilter.Visible = false;
		}
		else
		{
			panel2.Visible = true;
			lblSplitTitle.Visible = false;
			BillsPanel.Location = new Point(0, panel2.Bottom + 1);
			BillsPanel.Size = new Size(BillsPanel.Width, base.Height - Panel1.Height - panel2.Height - 2);
			vScrollBillsPanel.Location = new Point(vScrollBillsPanel.Location.X, BillsPanel.Location.Y);
			ddlDateRangeFilter.Visible = true;
			ddlDateRangeFilter.SelectedIndex = 0;
		}
		if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled" && screenOrderType != OrderTypes.DineIn)
		{
			btnNotifyCustomer.Visible = true;
		}
		else
		{
			btnNotifyCustomer.Visible = false;
		}
		multipleBillsToCompare = new List<OrderResult>();
		list_2 = orderMethods_0.GetMultipleBills(string_1, screenOrderType);
		timer_0.Start();
		method_3();
		int_0 = BillsPanel.Width / short_0 - 1;
		short_2 = Convert.ToInt16(list_2.Count());
		btnSelectionMerge.Visible = true;
		if (screenOrderType.ToUpper().Contains("PAID"))
		{
			btnSelectionMerge.Enabled = false;
		}
		if (list_2.Where((OrderResult o) => !o.isPaid).Count() <= 1)
		{
			btnSelectionMerge.Enabled = false;
		}
		if (screenOrderType == OrderTypes.PickUp)
		{
			btnSelectionMerge.Location = btnCashoutBill.Location;
			btnCashoutBill.Visible = false;
			Button button = btnClearTable;
			Button button2 = btnToGo;
			Button button3 = btnNewDeliveryOrder;
			btnNewTakeOut.Visible = true;
			button3.Visible = true;
			button2.Visible = true;
			button.Visible = true;
			btnClearTable.Text = Resources.CLEAR_ALL_PAID_ORDERS;
			if (MemoryLoadedObjects.DefaultOrderTypes.Contains(OrderTypes.Catering))
			{
				btnNewCatering.Visible = true;
			}
			else
			{
				btnNewCatering.Visible = false;
			}
		}
		else
		{
			Button button4 = btnCashoutBill;
			btnClearTable.Visible = true;
			button4.Visible = true;
			btnSelectionMerge.Location = new Point(btnCashoutBill.Left - btnSelectionMerge.Width, btnSelectionMerge.Location.Y);
			btnNewCatering.Visible = false;
			btnClearTable.Enabled = false;
			Button button5 = btnToGo;
			Button button6 = btnNewDeliveryOrder;
			Button button7 = btnNewTakeOut;
			btnNewCatering.Visible = false;
			button7.Visible = false;
			button6.Visible = false;
			button5.Visible = false;
		}
		if (list_2.Where((OrderResult o) => !o.isPaid).Count() == 0 && screenOrderType != OrderTypes.PickUp)
		{
			btnClearTable.Enabled = true;
		}
		bool_1 = false;
		IoRywDjqfQ(null, null);
	}

	private void frmMultiBills_Activated(object sender, EventArgs e)
	{
		int_0 = BillsPanel.Width / short_0 - 1;
		if (!bool_1)
		{
			LoadFormProcedure();
		}
		if (MemoryLoadedObjects.OrderEntry != null && MemoryLoadedObjects.OrderEntry.Visible)
		{
			MemoryLoadedObjects.OrderEntry.HideOrderEntry();
		}
	}

	private void frmMultiBills_Load(object sender, EventArgs e)
	{
	}

	private void method_3()
	{
		for (int i = 2; i < 10; i++)
		{
			short_0 = (short)((BillsPanel.Width - (i + 1) * short_1) / i - 5);
			if (short_0 > 308)
			{
				if (short_0 >= 308 && short_0 <= 400)
				{
					break;
				}
				continue;
			}
			short_0 = 308;
			break;
		}
	}

	public void LoadFormProcedure()
	{
		if (bool_0)
		{
			return;
		}
		try
		{
			if (CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] == null || CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() == "0")
			{
				Close();
			}
			bool_0 = true;
			short num = 0;
			int num2 = 0;
			int num3 = 0;
			font_0 = new Font("Arial", 12 + (int_0 - 3), FontStyle.Regular);
			BillsPanel.SendToBack();
			orderMethods_0 = new OrderMethods();
			if (screenOrderType == OrderTypes.DineIn)
			{
				list_2 = orderMethods_0.GetMultipleBills(string_1, screenOrderType);
				list_2 = list_2.Where((OrderResult a) => a.DateCreated.AddDays(1.0) > DateTime.Now).ToList();
				method_16();
				btnConfirmOnlineOrders.Visible = false;
			}
			else
			{
				btnConfirmOnlineOrders.Visible = true;
				list_2 = (from x in orderMethods_0.SearchOpenOrders(txtSearchInfo.Text.Trim(), string_2, Convert.ToInt32(ddlDateRangeFilter.SelectedValue))
					where x.OrderType != OrderTypes.DineIn || (x.OrderType == OrderTypes.DineIn && x.Customer.Contains("KIOSK"))
					select x).ToList();
				timer_1.Enabled = (bool_3 = CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(orderMethods_0.OpenOrders(OrderTypes.AllOnline).Count() > 0));
				if (!bool_3)
				{
					btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
				}
			}
			List<OrderResult> list = (from y in list_2
				orderby y.SeatNum
				select y into x
				group x by x.OrderNumber into y
				select y.First()).ToList();
			string_0 = new string[1001];
			using (List<OrderResult>.Enumerator enumerator = multipleBillsToCompare.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass23_0();
					CS_0024_003C_003E8__locals1.existingBill = enumerator.Current;
					OrderResult orderResult = list.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals1.existingBill.OrderNumber).FirstOrDefault();
					if (orderResult == null)
					{
						method_6(CS_0024_003C_003E8__locals1.existingBill.OrderNumber);
					}
					else if (CS_0024_003C_003E8__locals1.existingBill.IsModified || orderResult.isPaid != CS_0024_003C_003E8__locals1.existingBill.isPaid || CS_0024_003C_003E8__locals1.existingBill.FlagID != orderResult.FlagID || CS_0024_003C_003E8__locals1.existingBill.FulFillmentAt != orderResult.FulFillmentAt)
					{
						method_4(orderResult.Customer, orderResult.OrderNumber, orderResult.isPaid, orderResult.tipRecorded, orderResult.tipAmount, orderResult.CustomerInfoPhone, orderResult.CustomerInfoName, orderResult.OrderType, orderResult.FlagID);
					}
				}
			}
			using (List<OrderResult>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_1();
					CS_0024_003C_003E8__locals0.orderResult = enumerator.Current;
					OrderResult orderResult2 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderResult.OrderNumber).FirstOrDefault();
					CS_0024_003C_003E8__locals0.orderResult.row = num3;
					CS_0024_003C_003E8__locals0.orderResult.col = num2;
					string_0[num] = CS_0024_003C_003E8__locals0.orderResult.OrderNumber;
					if (orderResult2 == null)
					{
						method_8(CS_0024_003C_003E8__locals0.orderResult.Customer, CS_0024_003C_003E8__locals0.orderResult.OrderNumber, CS_0024_003C_003E8__locals0.orderResult.isPaid, CS_0024_003C_003E8__locals0.orderResult.tipRecorded, CS_0024_003C_003E8__locals0.orderResult.tipAmount, CS_0024_003C_003E8__locals0.orderResult.CustomerInfoPhone, CS_0024_003C_003E8__locals0.orderResult.CustomerInfoName, CS_0024_003C_003E8__locals0.orderResult.SeatNum, CS_0024_003C_003E8__locals0.orderResult.col, CS_0024_003C_003E8__locals0.orderResult.row, CS_0024_003C_003E8__locals0.orderResult.OrderType, CS_0024_003C_003E8__locals0.orderResult.OrderStatus, CS_0024_003C_003E8__locals0.orderResult.FlagID);
					}
					else if (orderResult2.row != num3 || orderResult2.col != num2)
					{
						method_5(CS_0024_003C_003E8__locals0.orderResult.OrderNumber, num3, num2);
					}
					if (num2 == int_0)
					{
						num3++;
						num2 = -1;
					}
					num2++;
					num = (short)(num + 1);
				}
			}
			multipleBillsToCompare.Clear();
			foreach (OrderResult item in list)
			{
				multipleBillsToCompare.Add(item);
			}
			if (num2 <= 1 && num3 <= 0)
			{
				btnSelectionMerge.Enabled = false;
			}
			else
			{
				btnSelectionMerge.Enabled = true;
			}
			if (list.Where((OrderResult o) => !o.isPaid).Count() <= 1)
			{
				btnSelectionMerge.Enabled = false;
			}
			if (list.Where((OrderResult o) => !o.isPaid).Count() > 0 && screenOrderType != OrderTypes.PickUp)
			{
				btnClearTable.Enabled = false;
			}
			else
			{
				btnClearTable.Enabled = true;
			}
			if (list_2.Count() == 0)
			{
				CgDyNrYqmq.Enabled = false;
			}
			else
			{
				CgDyNrYqmq.Enabled = true;
			}
			if (!list_2.Any() || list_2.Where((OrderResult o) => o.isPaid).Count() == 0)
			{
				btnClearTable.Enabled = false;
			}
			list.Clear();
			list = null;
			bool_0 = false;
			vScrollBillsPanel.EnableDisableButtonsByScrollPanel();
		}
		catch (Exception ex)
		{
			bool_0 = false;
			if (this != null && !base.IsDisposed)
			{
				new NotificationLabel(this, "Something went wrong loading the orders. Please REFERSH the page.", NotificationTypes.Warning).Show();
			}
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
		}
	}

	private void method_4(string string_3, string string_4, bool bool_4, bool bool_5, decimal decimal_0, string string_5, string string_6, string string_7, byte byte_0)
	{
		OrderChit orderChit = (OrderChit)BillsPanel.Controls.Find("chit" + string_4, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			if (byte_0 == 1)
			{
				orderChit.OnlineOrderStatus = byte_0;
			}
			else
			{
				orderChit.onlineOrder_confirmed = true;
				orderChit.OnlineOrderStatus = 0;
			}
			orderChit.Refresh();
			orderChit.UpdateClickLabelTag(byte_0 + "|" + string_7 + "|" + string_3 + "|" + string_5 + "|" + string_6);
			if (bool_4)
			{
				orderChit.ClickLabel.Visible = true;
				orderChit.ClickLabel.Text = "** " + Resources.PAID + " **";
				orderChit.ClickLabel.ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
				orderChit.ClickLabel.Opacity = 60;
				orderChit.ClickLabel.BackColor = Color.Black;
				orderChit.ClickLabel.TransparentBackColor = Color.White;
			}
			TransparentLabel transparentLabel = (TransparentLabel)BillsPanel.Controls.Find("lblTip" + string_4, searchAllChildren: false).FirstOrDefault();
			if (transparentLabel != null)
			{
				transparentLabel.Location = new Point(orderChit.Location.X, orderChit.Location.Y + orderChit.Size.Height - transparentLabel.Size.Height);
				transparentLabel.Text = Resources.Tip_Amount0 + decimal_0.ToString("$0.00");
			}
			else
			{
				method_9(orderChit, string_4, bool_4, bool_5, decimal_0);
			}
		}
	}

	private void method_5(string string_3, int int_1, int int_2)
	{
		OrderChit orderChit = (OrderChit)BillsPanel.Controls.Find("chit" + string_3, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			orderChit.Location = new Point(int_2 * short_0 + (int_2 + 1) * short_1, int_1 * (short_0 - 150) + (int_1 + 1) * short_1 + int_1 * 110 + BillsPanel.AutoScrollPosition.Y);
		}
		TransparentLabel transparentLabel = (TransparentLabel)BillsPanel.Controls.Find("lblTip" + string_3, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.Location = new Point(orderChit.Location.X, orderChit.Location.Y + orderChit.Size.Height - transparentLabel.Size.Height);
		}
	}

	private void method_6(string string_3)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.orderNumber = string_3;
		OrderChit orderChit = (OrderChit)BillsPanel.Controls.Find("chit" + CS_0024_003C_003E8__locals0.orderNumber, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			ControlHelpers.ClearControlsInControl(orderChit);
			BillsPanel.Controls.Remove(orderChit);
			orderChit.Dispose();
		}
		method_7(CS_0024_003C_003E8__locals0.orderNumber);
		new Thread((ThreadStart)delegate
		{
			try
			{
				Thread.Sleep(2000);
				CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0._003C_003E4__this.method_7(CS_0024_003C_003E8__locals0.orderNumber);
				});
			}
			catch
			{
			}
		}).Start();
	}

	private void method_7(string string_3)
	{
		TransparentLabel transparentLabel = (TransparentLabel)BillsPanel.Controls.Find("lblTip" + string_3, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			BillsPanel.Controls.Remove(transparentLabel);
			transparentLabel.Dispose();
		}
	}

	private void method_8(string string_3, string string_4, bool bool_4, bool bool_5, decimal decimal_0, string string_5, string string_6, short short_3, int int_1, int int_2, string string_7, string string_8, byte byte_0)
	{
		if ((OrderChit)BillsPanel.Controls.Find("chit" + string_4, searchAllChildren: false).FirstOrDefault() == null)
		{
			TransparentLabel transparentLabel = new TransparentLabel();
			transparentLabel.Name = string_4;
			transparentLabel.Tag = byte_0 + "|" + string_7 + "|" + string_3 + "|" + string_5 + "|" + string_6;
			transparentLabel.MouseUp += method_10;
			string currentScreenType = ((screenOrderType == OrderTypes.DineIn) ? ScreenType.dine_in : ScreenType.take_out);
			OrderChit orderChit = new OrderChit(isKitchen: false, short_0 - 150, EnableBlinkingTimer: false, transparentLabel, currentScreenType);
			orderChit.Name = "chit" + string_4;
			orderChit.OrderNumber.Add(string_4);
			orderChit.StationID = 1;
			orderChit.Width = short_0;
			orderChit.FontSize = 10f;
			orderChit.Tag = byte_0 + "|" + string_7 + "|" + string_3 + "|" + string_5 + "|" + string_6;
			orderChit.Location = new Point(int_1 * short_0 + (int_1 + 1) * short_1, int_2 * (short_0 - 150) + (int_2 + 1) * short_1 + int_2 * 110 + BillsPanel.AutoScrollPosition.Y);
			BillsPanel.Controls.Add(orderChit);
			orderChit.BringToFront();
			if (bool_4)
			{
				transparentLabel.Text = "** " + Resources.PAID + " **";
				transparentLabel.ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
				transparentLabel.Opacity = 60;
				transparentLabel.BackColor = Color.Black;
			}
			TransparentLabel transparentLabel2 = new TransparentLabel(TransparentLabelType.Food);
			transparentLabel2.Name = "Label Food " + string_4;
			transparentLabel2.Size = new Size(42, 40);
			transparentLabel2.Location = new Point(0, orderChit.Size.Height - 46);
			transparentLabel2.BackColor = Color.Transparent;
			transparentLabel2.Click += method_13;
			orderChit.Controls.Add(transparentLabel2);
			transparentLabel2.Visible = false;
			TransparentLabel transparentLabel3 = new TransparentLabel(TransparentLabelType.Drink);
			transparentLabel3.Name = "Label Drink " + string_4;
			transparentLabel3.Size = new Size(42, 40);
			transparentLabel3.Location = new Point(0, orderChit.Size.Height - 46);
			transparentLabel3.BackColor = Color.Transparent;
			transparentLabel3.Click += method_13;
			orderChit.Controls.Add(transparentLabel3);
			transparentLabel3.Visible = false;
			method_9(orderChit, string_4, bool_4, bool_5, decimal_0);
		}
	}

	private void method_9(OrderChit orderChit_0, string string_3, bool bool_4, bool bool_5, decimal decimal_0)
	{
		_003C_003Ec__DisplayClass29_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals0.TipRecorded = bool_5;
		CS_0024_003C_003E8__locals0.orderNumber = string_3;
		CS_0024_003C_003E8__locals0.TipAmount = decimal_0;
		CS_0024_003C_003E8__locals0.isPaid = bool_4;
		CS_0024_003C_003E8__locals0.chit = orderChit_0;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		TransparentLabel transparentLabel = (TransparentLabel)BillsPanel.Controls.Find("lblTip" + CS_0024_003C_003E8__locals0.orderNumber, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.BringToFront();
			return;
		}
		new Thread((ThreadStart)delegate
		{
			Thread.Sleep(500);
			try
			{
				if ((CS_0024_003C_003E8__locals0.TipRecorded || (CS_0024_003C_003E8__locals0.orderNumber.Contains("WEB") && CS_0024_003C_003E8__locals0.TipAmount > 0m)) && CS_0024_003C_003E8__locals0.isPaid && CS_0024_003C_003E8__locals0.chit != null)
				{
					CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_1();
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
					CS_0024_003C_003E8__locals0.lblTip = new TransparentLabel();
					CS_0024_003C_003E8__locals0.lblTip.Size = new Size(CS_0024_003C_003E8__locals0.chit.Size.Width / 2, 35);
					int num = CS_0024_003C_003E8__locals0.chit.Location.Y + CS_0024_003C_003E8__locals0.chit.Size.Height - CS_0024_003C_003E8__locals0.lblTip.Size.Height - 10;
					int num2 = ((CS_0024_003C_003E8__locals0.chit.Size.Width / 2 > CS_0024_003C_003E8__locals0.chit.Size.Height) ? (num + 130) : num);
					CS_0024_003C_003E8__locals0.lblTip.Location = new Point(CS_0024_003C_003E8__locals0.chit.Location.X, num2);
					CS_0024_003C_003E8__locals0.lblTip.Text = Resources.Tip_Amount0 + CS_0024_003C_003E8__locals0.TipAmount.ToString("$0.00");
					CS_0024_003C_003E8__locals0.lblTip.TextAlign = ContentAlignment.BottomLeft;
					CS_0024_003C_003E8__locals0.lblTip.ForeColor = Color.Black;
					CS_0024_003C_003E8__locals0.lblTip.BackColor = Color.Transparent;
					CS_0024_003C_003E8__locals0.lblTip.Font = new Font("Arial", 11f, FontStyle.Regular);
					CS_0024_003C_003E8__locals0.lblTip.Name = "lblTip" + CS_0024_003C_003E8__locals0.orderNumber;
					CS_0024_003C_003E8__locals0.lblTip.Opacity = 80;
					CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
					{
						if (CS_0024_003C_003E8__locals0.lblTip != null && !CS_0024_003C_003E8__locals0.lblTip.IsDisposed)
						{
							SizeF sizeF = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.CreateGraphics().MeasureString(Resources.Tip_Amount0 + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.TipAmount.ToString("$0.00"), CS_0024_003C_003E8__locals0.lblTip.Font);
							if (sizeF.Width > (float)CS_0024_003C_003E8__locals0.lblTip.Size.Width)
							{
								CS_0024_003C_003E8__locals0.lblTip.Size = new Size(Convert.ToInt16(sizeF.Width), 35);
							}
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Add(CS_0024_003C_003E8__locals0.lblTip);
							CS_0024_003C_003E8__locals0.lblTip.BringToFront();
							if ((OrderChit)CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Find("chit" + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber, searchAllChildren: false).FirstOrDefault() == null && CS_0024_003C_003E8__locals0.lblTip != null && !CS_0024_003C_003E8__locals0.lblTip.IsDisposed)
							{
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.BillsPanel.Controls.Remove(CS_0024_003C_003E8__locals0.lblTip);
								CS_0024_003C_003E8__locals0.lblTip.Dispose();
							}
						}
					});
				}
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog("Add Tip Label ERROR: " + ex.Message + "\n" + ex.StackTrace, LogTypes.error_log);
			}
		}).Start();
	}

	private void method_10(object sender, MouseEventArgs e)
	{
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
		if (sender == null)
		{
			return;
		}
		CS_0024_003C_003E8__locals0.lv = (Control)sender;
		if (CS_0024_003C_003E8__locals0.lv == null)
		{
			return;
		}
		string name = CS_0024_003C_003E8__locals0.lv.Name;
		OrderChit orderChit = (OrderChit)BillsPanel.Controls.Find("chit" + name, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			if (orderChit.onlineOrder_confirmed_click || orderChit.OnlineOrderStatus == 1)
			{
				orderChit.onlineOrder_confirmed_click = false;
				return;
			}
			if (bool_2)
			{
				OrderHelper orderHelper = new OrderHelper();
				bool_2 = false;
				btnPrintChit.Text = "REPRINT CHIT";
				new NotificationLabel(this, "Printing chits.", NotificationTypes.Success).Show();
				{
					foreach (Station station in new GClass6().Stations)
					{
						orderHelper.PrintToStation(orderChit.OrderNumber.First(), orderChit.OrderType, orderChit.CustomerInfoName + " - " + orderChit.Customer, station.StationID, orderChit.EmployeeName, isOrderMade: false, reprint: true, printOnlyOne: true, orderChit.TableName);
					}
					return;
				}
			}
		}
		if (CS_0024_003C_003E8__locals0.lv.Text.Contains(Resources.PENDING))
		{
			new frmMessageBox(Resources.Order_cannot_be_cleared_Order_).ShowDialog();
			return;
		}
		if (CS_0024_003C_003E8__locals0.lv.Text.Contains(Resources.PAID))
		{
			string text = OrderTypes.DineIn;
			if (CS_0024_003C_003E8__locals0.lv.Tag != null)
			{
				text = CS_0024_003C_003E8__locals0.lv.Tag.ToString();
			}
			if (text == OrderTypes.DeliveryOnline || text == OrderTypes.PickUpOnline || text == OrderTypes.PickUpCurbsideOnline || text == OrderTypes.DineInOnline)
			{
				new OrderHelper().RecordBatchId(CS_0024_003C_003E8__locals0.lv.Name, text);
			}
			if (frmLayout_0.RecordTip(null, CS_0024_003C_003E8__locals0.lv.Name, text))
			{
				OrderResult orderResult = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
				if (orderResult != null)
				{
					orderResult.IsModified = true;
				}
				LoadFormProcedure();
			}
			return;
		}
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string[] array = CS_0024_003C_003E8__locals0.lv.Tag.ToString().Split('|');
		if (array != null && array.Length > 1)
		{
			text3 = array[0];
			text2 = array[1];
			if (!(text2 == OrderTypes.Delivery) && !(text2 == OrderTypes.DeliveryOnline) && !(text2 == OrderTypes.PickUp) && !(text2 == OrderTypes.PickUpOnline))
			{
				string_1 = array[2];
			}
			else
			{
				string_1 = array[3];
			}
			if (array.Length >= 5)
			{
				text4 = array[4];
				if (array.Length >= 6)
				{
				}
			}
		}
		if (SettingsHelper.CurrentTerminalMode == "Patron")
		{
			frmPatron obj = new frmPatron();
			obj.LoadFormData(CS_0024_003C_003E8__locals0.lv.Name, string_1, text2, 0, text4);
			obj.ShowDialog();
			obj.Dispose();
			return;
		}
		if (WxBypksAks.Visible)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
			MemoryLoadedObjects.OrderEntry.LoadFormData(CS_0024_003C_003E8__locals0.lv.Name, string_1, text2, 0, 0, text4, "", resetComboId: true, 1);
			MemoryLoadedObjects.OrderEntry.CashoutBill(isCashoutButton: true);
			OrderResult orderResult2 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
			if (orderResult2 != null)
			{
				orderResult2.IsModified = true;
			}
			if (MemoryLoadedObjects.OrderEntry.OrdersUpdated != null && MemoryLoadedObjects.OrderEntry.OrdersUpdated.Count > 0)
			{
				using List<string>.Enumerator enumerator2 = MemoryLoadedObjects.OrderEntry.OrdersUpdated.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass30_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass30_1();
					CS_0024_003C_003E8__locals1.oNum = enumerator2.Current;
					OrderResult orderResult3 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals1.oNum).FirstOrDefault();
					if (orderResult3 != null)
					{
						orderResult3.IsModified = true;
					}
				}
			}
			LoadFormProcedure();
			if (MemoryLoadedObjects.OrderEntry.moved == 1)
			{
				screenOrderType = MemoryLoadedObjects.OrderEntry.otype;
				string_1 = MemoryLoadedObjects.OrderEntry.cus;
			}
		}
		else if (lblSelectNotify.Visible && SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
		{
			if (!string.IsNullOrEmpty(string_1) && string_1 != "Walk In")
			{
				if (new frmMessageBox("Do you want to notify \"" + text4 + "-" + string_1 + "\" customer?", "Notify Customer", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
				{
					return;
				}
				MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals0.lv.Name, string_1, text2);
				btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
				lblSelectNotify.Visible = false;
				btnNotifyCustomer.Enabled = true;
			}
			else
			{
				new NotificationLabel(this, "Please Select a pickup or delivery order type.", NotificationTypes.Success).Show();
			}
		}
		else
		{
			if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON" && (text2 == OrderTypes.DeliveryOnline || text2 == OrderTypes.PickUpOnline || text2 == OrderTypes.PickUpCurbsideOnline || text2 == OrderTypes.DineInOnline) && text3 == ((byte)1).ToString())
			{
				_003C_003Ec__DisplayClass30_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass30_2();
				CS_0024_003C_003E8__locals2.OrdNum = CS_0024_003C_003E8__locals0.lv.Name;
				OrderResult orderResult4 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals2.OrdNum).FirstOrDefault();
				if (orderResult4 != null)
				{
					orderResult4.IsModified = true;
				}
				return;
			}
			if (!OrderMethods.CheckIfOpenOrderExists(CS_0024_003C_003E8__locals0.lv.Name, Convert.ToInt32(ddlDateRangeFilter.SelectedValue)))
			{
				OrderResult orderResult5 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
				if (orderResult5 != null)
				{
					orderResult5.IsModified = true;
				}
				LoadFormProcedure();
				return;
			}
			frmLayout_0.ShowEmptyOrderEntry();
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
			MemoryLoadedObjects.OrderEntry.LoadFormData(CS_0024_003C_003E8__locals0.lv.Name, string_1, text2, 0, 0, text4, "", resetComboId: true, 1);
			DialogResult dialogResult = MemoryLoadedObjects.OrderEntry.ShowDialog();
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Cancel)
			{
				OrderResult orderResult6 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
				if (orderResult6 != null)
				{
					orderResult6.IsModified = true;
				}
				if (MemoryLoadedObjects.OrderEntry.OrdersUpdated != null && MemoryLoadedObjects.OrderEntry.OrdersUpdated.Count > 0)
				{
					using List<string>.Enumerator enumerator2 = MemoryLoadedObjects.OrderEntry.OrdersUpdated.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass30_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass30_3();
						CS_0024_003C_003E8__locals3.oNum = enumerator2.Current;
						OrderResult orderResult7 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals3.oNum).FirstOrDefault();
						if (orderResult7 != null)
						{
							orderResult7.IsModified = true;
						}
					}
				}
				LoadFormProcedure();
				if (MemoryLoadedObjects.OrderEntry.moved == 1)
				{
					screenOrderType = MemoryLoadedObjects.OrderEntry.otype;
					string_1 = MemoryLoadedObjects.OrderEntry.cus;
				}
			}
		}
		GC.Collect();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		timer_0.Stop();
		ControlHelpers.ClearControlsInPanel(BillsPanel);
		multipleBillsToCompare = null;
		string_0 = null;
		WxBypksAks.Visible = false;
		btnCashoutBill.Text = "CASHOUT BILLS";
		base.DialogResult = DialogResult.OK;
		GC.Collect();
		Close();
	}

	private void CgDyNrYqmq_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_print, Resources.Print_All_Bills, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
		{
			return;
		}
		string[] array = string_0;
		foreach (string text in array)
		{
			if (text != null)
			{
				PrintHelper.GenerateReceipt(text, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				continue;
			}
			break;
		}
	}

	private void method_11(object sender, EventArgs e)
	{
	}

	private void method_12(string string_3, IQueryable<OrderResult> iqueryable_0, GClass6 gclass6_0)
	{
		using IEnumerator<OrderResult> enumerator = iqueryable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
			CS_0024_003C_003E8__locals0.orderResult = enumerator.Current;
			foreach (Order item in gclass6_0.Orders.Where((Order o) => o.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderResult.OrderNumber)).ToList())
			{
				item.OrderNumber = string_3;
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
		}
	}

	private void btnSelectionMerge_Click(object sender, EventArgs e)
	{
		if (screenOrderType != OrderTypes.DineIn)
		{
			if (new frmMerge(string_1, screenOrderType).ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			foreach (OrderResult item in multipleBillsToCompare.ToList())
			{
				item.IsModified = true;
			}
			LoadFormProcedure();
			return;
		}
		new frmSplitBill(string_1, screenOrderType, string_0[0]).ShowDialog(this);
		foreach (OrderResult item2 in multipleBillsToCompare.ToList())
		{
			item2.IsModified = true;
		}
		LoadFormProcedure();
	}

	private void CgDyNrYqmq_EnabledChanged(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass36_0();
		CS_0024_003C_003E8__locals0.btn = (Button)sender;
		if (frmMasterForm.lockedControls != null)
		{
			LockedControl lockedControl = frmMasterForm.lockedControls.Where((LockedControl x) => x.Name.Contains(CS_0024_003C_003E8__locals0.btn.Name)).FirstOrDefault();
			if (lockedControl != null && !lockedControl.AllowCtrlOverride && CS_0024_003C_003E8__locals0.btn.Enabled)
			{
				CS_0024_003C_003E8__locals0.btn.Enabled = false;
			}
		}
		if (!CS_0024_003C_003E8__locals0.btn.Enabled)
		{
			CS_0024_003C_003E8__locals0.btn.Tag = CS_0024_003C_003E8__locals0.btn.BackColor;
			CS_0024_003C_003E8__locals0.btn.BackColor = Color.Gray;
		}
		else if (CS_0024_003C_003E8__locals0.btn.Tag != null)
		{
			CS_0024_003C_003E8__locals0.btn.BackColor = (Color)CS_0024_003C_003E8__locals0.btn.Tag;
		}
	}

	private void btnClearTable_Click(object sender, EventArgs e)
	{
		if (OrderTypes.PickUp == screenOrderType)
		{
			if (new frmMessageBox(Resources.Are_you_sure_you_want_to_clear1, Resources.Clear_Paid_Orders, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			GClass6 gClass = new GClass6();
			foreach (Order item in gClass.Orders.Where((Order o) => (o.OrderType == OrderTypes.PickUp || o.OrderType == OrderTypes.PickUpOnline || o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.DeliveryOnline || o.OrderType == OrderTypes.PickUpCurbsideOnline || o.OrderType == OrderTypes.DineInOnline || o.OrderType == OrderTypes.ToGo || o.OrderType == OrderTypes.Catering) && o.Paid == true && o.Void == false && o.DateCleared == null && o.FlagID == 0 && o.DatePaid != null).ToList())
			{
				item.DateCleared = DateTime.Now;
			}
			Helper.SubmitChangesWithCatch(gClass);
			LoadFormProcedure();
		}
		else
		{
			frmLayout_0.ClearOccupiedTable(string_1);
			if (orderMethods_0.GetMultipleBills(string_1, screenOrderType).Count() == 0)
			{
				frmLayout_0.Show();
				Close();
			}
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		TransparentLabel transparentLabel = (TransparentLabel)sender;
		if (transparentLabel.Name.Contains("Label Food"))
		{
			_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass38_0();
			CS_0024_003C_003E8__locals0.orderNumber = transparentLabel.Name.Replace("Label Food ", "");
			gClass = new GClass6();
			(from o in gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && o.StationID != null && o.StationID != string.Empty && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
				where o.StationID.Split(',').Contains("1")
				select o).ToList().ForEach(delegate(Order x)
			{
				x.ItemMadeNotified = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		else if (transparentLabel.Name.Contains("Label Drink"))
		{
			_003C_003Ec__DisplayClass38_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass38_1();
			CS_0024_003C_003E8__locals1.orderNumber = transparentLabel.Name.Replace("Label Drink ", "");
			gClass = new GClass6();
			(from o in gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals1.orderNumber && o.StationID != null && o.StationID != string.Empty && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
				where o.StationID.Split(',').Contains("2")
				select o).ToList().ForEach(delegate(Order x)
			{
				x.ItemMadeNotified = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		transparentLabel.Visible = false;
		IoRywDjqfQ(null, null);
	}

	private void IoRywDjqfQ(object sender, EventArgs e)
	{
		if (MemoryLoadedObjects.OrderEntry.Visible || Application.OpenForms["frmPay"] != null || Application.OpenForms["frmPayFinish"] != null)
		{
			return;
		}
		if (!bool_0)
		{
			GClass6 gClass = new GClass6();
			LoadFormProcedure();
			bool_0 = true;
			List<OrderResult> list = (from x in list_2
				group x by x.OrderNumber into y
				select y.First()).ToList();
			List<Order> source = new List<Order>();
			if (SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON" || SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON")
			{
				source = gClass.Orders.Where((Order o) => o.ItemMadeNotified == false && o.DateFilled.HasValue && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList();
			}
			foreach (OrderResult item in list)
			{
				_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
				CS_0024_003C_003E8__locals0.orderchit = (OrderChit)BillsPanel.Controls.Find("chit" + item.OrderNumber, searchAllChildren: false).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.orderchit == null || (!(SettingsHelper.GetSettingValueByKey("layout_show_food_icon") == "ON") && !(SettingsHelper.GetSettingValueByKey("layout_show_drink_icon") == "ON")))
				{
					continue;
				}
				var list2 = (from o in source
					where o.OrderNumber == CS_0024_003C_003E8__locals0.orderchit.OrderNumber.First()
					select o into x
					group x by x.Customer into x
					select new
					{
						TableName = x.FirstOrDefault().Customer,
						StationId = x.FirstOrDefault().StationID
					}).ToList();
				if (list2.Count > 0)
				{
					TransparentLabel transparentLabel = (TransparentLabel)CS_0024_003C_003E8__locals0.orderchit.Controls.Find("Label Food " + CS_0024_003C_003E8__locals0.orderchit.OrderNumber, searchAllChildren: false).FirstOrDefault();
					TransparentLabel transparentLabel2 = (TransparentLabel)CS_0024_003C_003E8__locals0.orderchit.Controls.Find("Label Drink " + CS_0024_003C_003E8__locals0.orderchit.OrderNumber, searchAllChildren: false).FirstOrDefault();
					var anon = list2.FirstOrDefault();
					if (anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("1") && transparentLabel != null)
					{
						transparentLabel.Visible = true;
						transparentLabel.BringToFront();
					}
					else if (anon.StationId != null && anon.StationId != string.Empty && anon.StationId.Split(',').Contains("2") && transparentLabel2 != null)
					{
						transparentLabel2.Visible = true;
						transparentLabel2.BringToFront();
					}
				}
			}
		}
		bool_0 = false;
	}

	private void btnNewTakeOut_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.PickUp, bool_0: false, this);
	}

	private void btnToGo_Click(object sender, EventArgs e)
	{
		frmLayout_0.ShowEmptyOrderEntry();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(null, Resources.Walk_In, OrderTypes.ToGo, 1, 0, "", "", resetComboId: true, 1);
		MemoryLoadedObjects.OrderEntry.Show();
	}

	private void btnCashoutBill_Click(object sender, EventArgs e)
	{
		WxBypksAks.Visible = !WxBypksAks.Visible;
		WxBypksAks.BringToFront();
		if (WxBypksAks.Visible)
		{
			btnCashoutBill.Text = "NORMAL BILL MODE";
		}
		else
		{
			btnCashoutBill.Text = "CASHOUT BILLS";
		}
	}

	private void method_14(object sender, EventArgs e)
	{
	}

	private void btnNewDeliveryOrder_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Delivery, bool_0: false, this);
	}

	private void btnPrintChit_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" && screenOrderType == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
		{
			if (new frmMessageBox("Do you want to print chit for this table?", "Print Chit", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
			{
				return;
			}
			string employee = "SYSTEM";
			Employee employee2 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString())).FirstOrDefault();
			if (employee2 != null)
			{
				employee = employee2.FirstName + " " + employee2.LastName;
			}
			OrderHelper orderHelper = new OrderHelper();
			OrderResult orderResult = list_2.FirstOrDefault();
			new NotificationLabel(this, "Printing chits.", NotificationTypes.Success).Show();
			if (orderResult == null)
			{
				return;
			}
			string[] array = orderResult.StationID.Split(',');
			foreach (string value in array)
			{
				orderHelper.PrintToStation(orderResult.OrderNumber, orderResult.OrderType, orderResult.CustomerInfoName + " - " + orderResult.Customer, Convert.ToInt16(value), employee, isOrderMade: false, reprint: true, printOnlyOne: false, orderResult.Customer);
			}
			{
				foreach (OrderResult item in list_2.ToList())
				{
					orderHelper.ChangePrintedInKitchenAndOrderStationMade(item.OrderNumber, item.OrderType);
				}
				return;
			}
		}
		if (!bool_2)
		{
			bool_2 = true;
			btnPrintChit.Text = "CANCEL REPRINT CHIT";
			new NotificationLabel(this, "Select an order to print chit.", NotificationTypes.Success).Show();
		}
		else
		{
			bool_2 = false;
			btnPrintChit.Text = "REPRINT CHIT";
			new NotificationLabel(this, "Print chit cancelled.", NotificationTypes.Success, 4);
		}
	}

	private void btnNewCatering_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Catering, bool_0: false, this);
	}

	private void method_15(Button button_0)
	{
		string_2 = button_0.Text;
		Button button = btnOTFilter_All;
		Button button2 = btnOTFilter_ToGo;
		Button button3 = btnOTFilter_PickUp;
		Button button4 = btnOTFilter_Delivery;
		Color color2 = (btnOTFilter_Catering.BackColor = Color.FromArgb(176, 124, 219));
		Color color4 = (button4.BackColor = color2);
		Color color6 = (button3.BackColor = color4);
		Color backColor = (button2.BackColor = color6);
		button.BackColor = backColor;
		button_0.BackColor = Color.FromArgb(214, 142, 81);
		LoadFormProcedure();
	}

	private void btnOTFilter_ToGo_Click(object sender, EventArgs e)
	{
		method_15((Button)sender);
	}

	private void txtSearchInfo_TextChanged(object sender, EventArgs e)
	{
		LoadFormProcedure();
	}

	private void btnClearSearch_Click(object sender, EventArgs e)
	{
		txtSearchInfo.Text = "";
		LoadFormProcedure();
		base.DialogResult = DialogResult.None;
	}

	private void btnNotifyCustomer_Click(object sender, EventArgs e)
	{
		if (screenOrderType == OrderTypes.DineIn)
		{
			OrderHelper orderHelper = new OrderHelper();
			OrderResult orderResult = list_2.FirstOrDefault();
			if (orderResult == null)
			{
				return;
			}
			string[] array = orderResult.StationID.Split(',');
			foreach (string value in array)
			{
				orderHelper.PrintToStation(orderResult.OrderNumber, orderResult.OrderType, orderResult.CustomerInfoName + " - " + orderResult.Customer, Convert.ToInt16(value), "SYSTEM", isOrderMade: false, reprint: false, printOnlyOne: false, orderResult.Customer);
			}
			{
				foreach (OrderResult item in list_2.ToList())
				{
					orderHelper.ChangePrintedInKitchenAndOrderStationMade(item.OrderNumber, item.OrderType);
				}
				return;
			}
		}
		lblSelectNotify.Visible = !lblSelectNotify.Visible;
		if (lblSelectNotify.Visible)
		{
			btnNotifyCustomer.Text = "STOP NOTIFY CUSTOMER";
			timer_2.Enabled = true;
			timer_2.Start();
		}
		else
		{
			btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
			timer_2.Enabled = false;
			timer_2.Stop();
			new NotificationLabel(this, "Customer Notification Cancelled", NotificationTypes.Success, 3);
		}
	}

	private void btnShowKeyboard_SearchInfo_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Search", 0, 256, txtSearchInfo.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtSearchInfo.Text = MemoryLoadedObjects.Keyboard.textEntered;
			LoadFormProcedure();
		}
		base.DialogResult = DialogResult.None;
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

	private void UlEyKndNwe(object sender, EventArgs e)
	{
		lblSelectNotify.Visible = false;
		btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
		timer_2.Enabled = false;
		timer_2.Stop();
	}

	private void ddlDateRangeFilter_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			BillsPanel.Controls.Clear();
			multipleBillsToCompare = new List<OrderResult>();
			multipleBillsToCompare.Clear();
			LoadFormProcedure();
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
		BillsPanel.Controls.Clear();
		multipleBillsToCompare = new List<OrderResult>();
		multipleBillsToCompare.Clear();
		LoadFormProcedure();
	}

	private void method_16()
	{
		if (screenOrderType == OrderTypes.DineIn && list_2.Any((OrderResult a) => a.FlagID == 6))
		{
			OrderHelper.UpdatePendingSaveOrders(string_1);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMultiBills));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		WxBypksAks = new Label();
		panel2 = new Panel();
		ddlDateRangeFilter = new Class19();
		btnConfirmOnlineOrders = new Button();
		btnOTFilter_All = new Button();
		label1 = new Label();
		btnOTFilter_Catering = new Button();
		btnOTFilter_Delivery = new Button();
		btnOTFilter_PickUp = new Button();
		btnOTFilter_ToGo = new Button();
		btnClearSearch = new Button();
		label3 = new Label();
		txtSearchInfo = new RadTextBoxControl();
		btnShowKeyboard_SearchInfo = new Button();
		lblTitle = new Label();
		lblTraining = new Label();
		BillsPanel = new Panel();
		Panel1 = new Panel();
		btnNotifyCustomer = new Button();
		btnNewCatering = new Button();
		btnPrintChit = new Button();
		btnNewDeliveryOrder = new Button();
		btnSelectionMerge = new Button();
		btnCashoutBill = new Button();
		btnToGo = new Button();
		btnNewTakeOut = new Button();
		btnClearTable = new Button();
		CgDyNrYqmq = new Button();
		BtnCancel = new Button();
		vScrollBillsPanel = new VerticalScrollControl();
		lblSelectNotify = new Label();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		timer_2 = new System.Windows.Forms.Timer(icontainer_1);
		lblSplitTitle = new Label();
		panel2.SuspendLayout();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		Panel1.SuspendLayout();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 20000;
		timer_0.Tick += IoRywDjqfQ;
		componentResourceManager.ApplyResources(WxBypksAks, "lblSelectCashoutBill");
		WxBypksAks.BackColor = Color.FromArgb(193, 57, 43);
		WxBypksAks.BorderStyle = BorderStyle.FixedSingle;
		WxBypksAks.ForeColor = Color.White;
		WxBypksAks.Name = "lblSelectCashoutBill";
		componentResourceManager.ApplyResources(panel2, "panel2");
		panel2.Controls.Add(ddlDateRangeFilter);
		panel2.Controls.Add(btnConfirmOnlineOrders);
		panel2.Controls.Add(btnOTFilter_All);
		panel2.Controls.Add(label1);
		panel2.Controls.Add(btnOTFilter_Catering);
		panel2.Controls.Add(btnOTFilter_Delivery);
		panel2.Controls.Add(btnOTFilter_PickUp);
		panel2.Controls.Add(btnOTFilter_ToGo);
		panel2.Controls.Add(btnClearSearch);
		panel2.Controls.Add(label3);
		panel2.Controls.Add(txtSearchInfo);
		panel2.Controls.Add(btnShowKeyboard_SearchInfo);
		panel2.Controls.Add(lblTitle);
		panel2.Name = "panel2";
		ddlDateRangeFilter.DrawMode = DrawMode.OwnerDrawVariable;
		ddlDateRangeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlDateRangeFilter, "ddlDateRangeFilter");
		ddlDateRangeFilter.Name = "ddlDateRangeFilter";
		ddlDateRangeFilter.SelectedIndexChanged += ddlDateRangeFilter_SelectedIndexChanged;
		componentResourceManager.ApplyResources(btnConfirmOnlineOrders, "btnConfirmOnlineOrders");
		btnConfirmOnlineOrders.BackColor = Color.FromArgb(255, 192, 128);
		btnConfirmOnlineOrders.FlatAppearance.BorderColor = Color.White;
		btnConfirmOnlineOrders.FlatAppearance.BorderSize = 0;
		btnConfirmOnlineOrders.FlatAppearance.MouseDownBackColor = Color.White;
		btnConfirmOnlineOrders.ForeColor = Color.Black;
		btnConfirmOnlineOrders.Name = "btnConfirmOnlineOrders";
		btnConfirmOnlineOrders.UseVisualStyleBackColor = false;
		btnConfirmOnlineOrders.Click += btnConfirmOnlineOrders_Click;
		componentResourceManager.ApplyResources(btnOTFilter_All, "btnOTFilter_All");
		btnOTFilter_All.BackColor = Color.FromArgb(214, 142, 81);
		btnOTFilter_All.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_All.FlatAppearance.BorderSize = 0;
		btnOTFilter_All.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_All.ForeColor = Color.White;
		btnOTFilter_All.Name = "btnOTFilter_All";
		btnOTFilter_All.UseVisualStyleBackColor = false;
		btnOTFilter_All.Click += btnOTFilter_ToGo_Click;
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
		btnOTFilter_Catering.Click += btnOTFilter_ToGo_Click;
		componentResourceManager.ApplyResources(btnOTFilter_Delivery, "btnOTFilter_Delivery");
		btnOTFilter_Delivery.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_Delivery.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_Delivery.FlatAppearance.BorderSize = 0;
		btnOTFilter_Delivery.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_Delivery.ForeColor = Color.White;
		btnOTFilter_Delivery.Name = "btnOTFilter_Delivery";
		btnOTFilter_Delivery.UseVisualStyleBackColor = false;
		btnOTFilter_Delivery.Click += btnOTFilter_ToGo_Click;
		componentResourceManager.ApplyResources(btnOTFilter_PickUp, "btnOTFilter_PickUp");
		btnOTFilter_PickUp.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_PickUp.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_PickUp.FlatAppearance.BorderSize = 0;
		btnOTFilter_PickUp.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_PickUp.ForeColor = Color.White;
		btnOTFilter_PickUp.Name = "btnOTFilter_PickUp";
		btnOTFilter_PickUp.UseVisualStyleBackColor = false;
		btnOTFilter_PickUp.Click += btnOTFilter_ToGo_Click;
		componentResourceManager.ApplyResources(btnOTFilter_ToGo, "btnOTFilter_ToGo");
		btnOTFilter_ToGo.BackColor = Color.FromArgb(176, 124, 219);
		btnOTFilter_ToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnOTFilter_ToGo.FlatAppearance.BorderSize = 0;
		btnOTFilter_ToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOTFilter_ToGo.ForeColor = Color.White;
		btnOTFilter_ToGo.Name = "btnOTFilter_ToGo";
		btnOTFilter_ToGo.UseVisualStyleBackColor = false;
		btnOTFilter_ToGo.Click += btnOTFilter_ToGo_Click;
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
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.FlatStyle = FlatStyle.Flat;
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(BillsPanel, "BillsPanel");
		BillsPanel.BorderStyle = BorderStyle.FixedSingle;
		BillsPanel.Name = "BillsPanel";
		componentResourceManager.ApplyResources(Panel1, "Panel1");
		Panel1.BorderStyle = BorderStyle.FixedSingle;
		Panel1.Controls.Add(btnNotifyCustomer);
		Panel1.Controls.Add(btnNewCatering);
		Panel1.Controls.Add(btnPrintChit);
		Panel1.Controls.Add(btnNewDeliveryOrder);
		Panel1.Controls.Add(btnSelectionMerge);
		Panel1.Controls.Add(btnCashoutBill);
		Panel1.Controls.Add(btnToGo);
		Panel1.Controls.Add(btnNewTakeOut);
		Panel1.Controls.Add(btnClearTable);
		Panel1.Controls.Add(CgDyNrYqmq);
		Panel1.Controls.Add(BtnCancel);
		Panel1.Name = "Panel1";
		btnNotifyCustomer.BackColor = Color.FromArgb(61, 142, 185);
		btnNotifyCustomer.FlatAppearance.BorderColor = Color.White;
		btnNotifyCustomer.FlatAppearance.BorderSize = 0;
		btnNotifyCustomer.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNotifyCustomer, "btnNotifyCustomer");
		btnNotifyCustomer.ForeColor = Color.White;
		btnNotifyCustomer.Name = "btnNotifyCustomer";
		btnNotifyCustomer.UseVisualStyleBackColor = false;
		btnNotifyCustomer.EnabledChanged += CgDyNrYqmq_EnabledChanged;
		btnNotifyCustomer.Click += btnNotifyCustomer_Click;
		btnNewCatering.BackColor = Color.FromArgb(53, 143, 79);
		btnNewCatering.FlatAppearance.BorderColor = Color.Black;
		btnNewCatering.FlatAppearance.BorderSize = 0;
		btnNewCatering.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnNewCatering, "btnNewCatering");
		btnNewCatering.ForeColor = Color.White;
		btnNewCatering.Name = "btnNewCatering";
		btnNewCatering.Tag = "";
		btnNewCatering.UseVisualStyleBackColor = false;
		btnNewCatering.Click += btnNewCatering_Click;
		btnPrintChit.BackColor = Color.SandyBrown;
		btnPrintChit.FlatAppearance.BorderColor = Color.White;
		btnPrintChit.FlatAppearance.BorderSize = 0;
		btnPrintChit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnPrintChit, "btnPrintChit");
		btnPrintChit.ForeColor = Color.White;
		btnPrintChit.Name = "btnPrintChit";
		btnPrintChit.UseVisualStyleBackColor = false;
		btnPrintChit.Click += btnPrintChit_Click;
		btnNewDeliveryOrder.BackColor = Color.FromArgb(80, 203, 116);
		btnNewDeliveryOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewDeliveryOrder.FlatAppearance.BorderSize = 0;
		btnNewDeliveryOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewDeliveryOrder, "btnNewDeliveryOrder");
		btnNewDeliveryOrder.ForeColor = Color.White;
		btnNewDeliveryOrder.Name = "btnNewDeliveryOrder";
		btnNewDeliveryOrder.UseVisualStyleBackColor = false;
		btnNewDeliveryOrder.Click += btnNewDeliveryOrder_Click;
		btnSelectionMerge.BackColor = Color.FromArgb(53, 152, 220);
		btnSelectionMerge.FlatAppearance.BorderColor = Color.White;
		btnSelectionMerge.FlatAppearance.BorderSize = 0;
		btnSelectionMerge.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSelectionMerge, "btnSelectionMerge");
		btnSelectionMerge.ForeColor = Color.White;
		btnSelectionMerge.Name = "btnSelectionMerge";
		btnSelectionMerge.UseVisualStyleBackColor = false;
		btnSelectionMerge.EnabledChanged += CgDyNrYqmq_EnabledChanged;
		btnSelectionMerge.Click += btnSelectionMerge_Click;
		btnCashoutBill.BackColor = Color.FromArgb(53, 143, 79);
		btnCashoutBill.FlatAppearance.BorderColor = Color.Black;
		btnCashoutBill.FlatAppearance.BorderSize = 0;
		btnCashoutBill.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnCashoutBill, "btnCashoutBill");
		btnCashoutBill.ForeColor = Color.White;
		btnCashoutBill.Name = "btnCashoutBill";
		btnCashoutBill.Tag = "";
		btnCashoutBill.UseVisualStyleBackColor = false;
		btnCashoutBill.Click += btnCashoutBill_Click;
		btnToGo.BackColor = Color.FromArgb(61, 142, 185);
		btnToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnToGo.FlatAppearance.BorderSize = 0;
		btnToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnToGo, "btnToGo");
		btnToGo.ForeColor = Color.White;
		btnToGo.Name = "btnToGo";
		btnToGo.UseVisualStyleBackColor = false;
		btnToGo.Click += btnToGo_Click;
		btnNewTakeOut.BackColor = Color.FromArgb(176, 124, 219);
		btnNewTakeOut.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewTakeOut.FlatAppearance.BorderSize = 0;
		btnNewTakeOut.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewTakeOut, "btnNewTakeOut");
		btnNewTakeOut.ForeColor = Color.White;
		btnNewTakeOut.Name = "btnNewTakeOut";
		btnNewTakeOut.UseVisualStyleBackColor = false;
		btnNewTakeOut.Click += btnNewTakeOut_Click;
		btnClearTable.BackColor = Color.FromArgb(214, 142, 81);
		btnClearTable.FlatAppearance.BorderColor = Color.White;
		btnClearTable.FlatAppearance.BorderSize = 0;
		btnClearTable.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnClearTable, "btnClearTable");
		btnClearTable.ForeColor = Color.White;
		btnClearTable.Name = "btnClearTable";
		btnClearTable.UseVisualStyleBackColor = false;
		btnClearTable.EnabledChanged += CgDyNrYqmq_EnabledChanged;
		btnClearTable.Click += btnClearTable_Click;
		CgDyNrYqmq.BackColor = Color.SandyBrown;
		CgDyNrYqmq.FlatAppearance.BorderColor = Color.White;
		CgDyNrYqmq.FlatAppearance.BorderSize = 0;
		CgDyNrYqmq.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(CgDyNrYqmq, "btnPrint");
		CgDyNrYqmq.ForeColor = Color.White;
		CgDyNrYqmq.Name = "btnPrint";
		CgDyNrYqmq.UseVisualStyleBackColor = false;
		CgDyNrYqmq.EnabledChanged += CgDyNrYqmq_EnabledChanged;
		CgDyNrYqmq.Click += CgDyNrYqmq_Click;
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.White;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(vScrollBillsPanel, "vScrollBillsPanel");
		vScrollBillsPanel.BackColor = Color.FromArgb(95, 95, 95);
		vScrollBillsPanel.ButtonDownEventOverride = null;
		vScrollBillsPanel.ButtonLastEventOverride = null;
		vScrollBillsPanel.ButtonStyle = "fourbuttons";
		vScrollBillsPanel.ConnectedPanel = null;
		vScrollBillsPanel.ConnectedRadListView = null;
		vScrollBillsPanel.inputedHeight = 0;
		vScrollBillsPanel.inputedWidth = 0;
		vScrollBillsPanel.Name = "vScrollBillsPanel";
		componentResourceManager.ApplyResources(lblSelectNotify, "lblSelectNotify");
		lblSelectNotify.BackColor = Color.FromArgb(193, 57, 43);
		lblSelectNotify.BorderStyle = BorderStyle.FixedSingle;
		lblSelectNotify.ForeColor = Color.White;
		lblSelectNotify.Name = "lblSelectNotify";
		timer_1.Interval = 500;
		timer_1.Tick += timer_1_Tick;
		timer_2.Interval = 10000;
		timer_2.Tick += UlEyKndNwe;
		componentResourceManager.ApplyResources(lblSplitTitle, "lblSplitTitle");
		lblSplitTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblSplitTitle.FlatStyle = FlatStyle.Flat;
		lblSplitTitle.ForeColor = Color.White;
		lblSplitTitle.Name = "lblSplitTitle";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(panel2);
		base.Controls.Add(lblSplitTitle);
		base.Controls.Add(lblSelectNotify);
		base.Controls.Add(WxBypksAks);
		base.Controls.Add(lblTraining);
		base.Controls.Add(vScrollBillsPanel);
		base.Controls.Add(BillsPanel);
		base.Controls.Add(Panel1);
		base.Name = "frmMultiBills";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.WindowState = FormWindowState.Maximized;
		base.Activated += frmMultiBills_Activated;
		base.Load += frmMultiBills_Load;
		base.Controls.SetChildIndex(Panel1, 0);
		base.Controls.SetChildIndex(BillsPanel, 0);
		base.Controls.SetChildIndex(vScrollBillsPanel, 0);
		base.Controls.SetChildIndex(lblTraining, 0);
		base.Controls.SetChildIndex(WxBypksAks, 0);
		base.Controls.SetChildIndex(lblSelectNotify, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(lblSplitTitle, 0);
		base.Controls.SetChildIndex(panel2, 0);
		panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtSearchInfo).EndInit();
		Panel1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
