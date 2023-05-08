using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmQuickService : frmMasterForm
{
	private GClass6 gclass6_0;

	private short AnEbVexupf;

	private short short_0;

	private short short_1;

	private string[] string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private int int_1;

	private string string_3;

	public List<OrderResult> multipleBillsToCompare;

	private List<OrderResult> list_2;

	private int int_2;

	private int int_3;

	private int int_4;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private int int_5;

	private int int_6;

	private Label label_0;

	private IContainer icontainer_1;

	internal Panel eewbfssqe0;

	internal Button BtnCancel;

	internal Button btnNewTakeOutOrder;

	internal Button btnNewDeliveryOrder;

	internal Button btnNewOrder;

	private Label lblTrainingMode;

	internal Button btnOpenRegister;

	internal Button btnToGo;

	private System.Windows.Forms.Timer timer_0;

	private VerticalScrollControl verticalScrollControl1;

	private FlowLayoutPanel flowLayoutPanel1;

	internal Button btnPrintChit;

	private Label lblTitle;

	internal Button btnChange;

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

	internal Button btnScreenRefresh;

	private Label lblCounter;

	internal Button btnNewCatering;

	internal Button btnNotifyCustomer;

	internal Button btnConfirmOnlineOrders;

	internal System.Windows.Forms.Timer timer_1;

	private System.Windows.Forms.Timer timer_2;

	private Class19 ddlDateRangeFilter;

	private System.Windows.Forms.Timer timer_3;

	public frmQuickService()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		AnEbVexupf = 320;
		short_0 = 8;
		short_1 = 2;
		string_0 = new string[1001];
		int_1 = 30;
		string_3 = "ALL";
		multipleBillsToCompare = new List<OrderResult>();
		int_4 = 1;
		bool_2 = true;
		bool_5 = true;
		bool_6 = true;
		int_5 = 12;
		label_0 = new Label();
		base._002Ector();
		InitializeComponent_1();
		btnConfirmOnlineOrders.Tag = btnConfirmOnlineOrders.BackColor;
		VerticalScrollControl verticalScrollControl = verticalScrollControl1;
		verticalScrollControl.ButtonDownEventOverride = (EventHandler)Delegate.Combine(verticalScrollControl.ButtonDownEventOverride, new EventHandler(method_3));
		VerticalScrollControl verticalScrollControl2 = verticalScrollControl1;
		verticalScrollControl2.ButtonLastEventOverride = (EventHandler)Delegate.Combine(verticalScrollControl2.ButtonLastEventOverride, new EventHandler(method_3));
		new FormHelper().ResizeButtonFonts(this);
		Dictionary<int, string> dataSource = MiscHelper.GenDateRangeFilters();
		ddlDateRangeFilter.DisplayMember = "Value";
		ddlDateRangeFilter.ValueMember = "Key";
		ddlDateRangeFilter.DataSource = new BindingSource(dataSource, null);
		ddlDateRangeFilter.SelectedIndex = 0;
	}

	public void LoadFormData(string cus, string ot, bool showOEOnClose = true)
	{
		if (MemoryLoadedObjects.OrderEntry != null && MemoryLoadedObjects.OrderEntry.OrdersUpdated != null && MemoryLoadedObjects.OrderEntry.OrdersUpdated.Count > 0)
		{
			using (List<string>.Enumerator enumerator = MemoryLoadedObjects.OrderEntry.OrdersUpdated.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
					CS_0024_003C_003E8__locals0.OrderNumUpdated = enumerator.Current;
					OrderResult orderResult = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.OrderNumUpdated).FirstOrDefault();
					if (orderResult != null)
					{
						orderResult.IsModified = true;
					}
				}
			}
			MemoryLoadedObjects.OrderEntry.OrdersUpdated = new List<string>();
		}
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
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
			lblTrainingMode.Location = new Point(eewbfssqe0.Width - lblTrainingMode.Width, eewbfssqe0.Height - lblTrainingMode.Height);
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		string_1 = ot;
		string_2 = cus;
		timer_0.Enabled = true;
		bool_6 = showOEOnClose;
	}

	private void frmQuickService_Activated(object sender, EventArgs e)
	{
		bool_1 = true;
		if (!bool_2)
		{
			LoadFormProcedure();
		}
	}

	private void frmQuickService_Load(object sender, EventArgs e)
	{
		label_0 = new Label();
		label_0.Size = new Size(eewbfssqe0.Width - 20, eewbfssqe0.Height / 10);
		label_0.Text = "LOAD MORE...";
		label_0.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		label_0.ForeColor = Color.White;
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		label_0.BackColor = eewbfssqe0.BackColor;
		label_0.Click += label_0_Click;
		label_0.Visible = false;
		eewbfssqe0.Controls.Add(label_0);
		if (eewbfssqe0.Width < 1280)
		{
			short_0 = 8;
		}
		method_5();
		int_4 = eewbfssqe0.Width / AnEbVexupf - 1;
		LoadFormProcedure();
		bool_2 = false;
	}

	private void method_3(object sender, EventArgs e)
	{
		int value = eewbfssqe0.VerticalScroll.Value;
		int maximum = eewbfssqe0.VerticalScroll.Maximum;
		if (value == maximum - eewbfssqe0.VerticalScroll.LargeChange + 1)
		{
			method_4();
		}
	}

	private void label_0_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		if (int_6 > int_5)
		{
			int_5 += 8;
			LoadFormProcedure();
		}
	}

	private void method_5()
	{
		for (int i = 2; i < 10; i++)
		{
			AnEbVexupf = (short)((eewbfssqe0.Width - (i + 1) * short_0) / i - 5);
			if (AnEbVexupf > 315)
			{
				if (AnEbVexupf >= 315 && AnEbVexupf <= 470)
				{
					break;
				}
				continue;
			}
			AnEbVexupf = 315;
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
			bool_0 = true;
			OrderMethods orderMethods = new OrderMethods();
			timer_1.Enabled = (bool_7 = CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder((from x in orderMethods.OpenOrders(OrderTypes.AllOnline, 1)
				where x.FlagID == 1
				select x).Count() > 0));
			if (!bool_7)
			{
				btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
			}
			lblCounter.Text = int_1.ToString();
			int_0 = int_1;
			short num = 0;
			int_2 = AnEbVexupf / 10;
			int_3 = (int)((double)(AnEbVexupf / 10) * 1.5);
			int num2 = 0;
			int num3 = 0;
			eewbfssqe0.SendToBack();
			list_2 = (from a in new OrderMethods().SearchOpenOrders(((Control)(object)txtSearchInfo).Text.Trim(), string_3, Convert.ToInt32(ddlDateRangeFilter.SelectedValue))
				orderby a.FulFillmentAt.HasValue, a.FulFillmentAt.HasValue ? a.FulFillmentAt.Value : a.DateCreated
				select a into x
				group x by x.OrderNumber into y
				select y.First()).ToList();
			List<OrderResult> list = list_2;
			string_0 = new string[1001];
			int_6 = 0;
			if (list != null)
			{
				using (List<OrderResult>.Enumerator enumerator = multipleBillsToCompare.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass34_0();
						CS_0024_003C_003E8__locals1.existingBill = enumerator.Current;
						OrderResult orderResult = list.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals1.existingBill.OrderNumber).FirstOrDefault();
						if (orderResult == null)
						{
							method_8(CS_0024_003C_003E8__locals1.existingBill.OrderNumber);
						}
						else if (CS_0024_003C_003E8__locals1.existingBill.IsModified || orderResult.isPaid != CS_0024_003C_003E8__locals1.existingBill.isPaid || CS_0024_003C_003E8__locals1.existingBill.FlagID != orderResult.FlagID || CS_0024_003C_003E8__locals1.existingBill.FulFillmentAt != orderResult.FulFillmentAt)
						{
							method_6(orderResult.Customer, orderResult.OrderNumber, orderResult.isPaid, orderResult.tipRecorded, orderResult.tipAmount, orderResult.CustomerInfoPhone, orderResult.CustomerInfoName, orderResult.OrderType, orderResult.FlagID);
						}
					}
				}
				using (IEnumerator<OrderResult> enumerator2 = list.Take(int_5).GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_1();
						CS_0024_003C_003E8__locals0.orderResult = enumerator2.Current;
						OrderResult orderResult2 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderResult.OrderNumber).FirstOrDefault();
						CS_0024_003C_003E8__locals0.orderResult.row = num3;
						CS_0024_003C_003E8__locals0.orderResult.col = num2;
						string_0[num] = CS_0024_003C_003E8__locals0.orderResult.OrderNumber;
						if (orderResult2 == null)
						{
							method_10(CS_0024_003C_003E8__locals0.orderResult.Customer, CS_0024_003C_003E8__locals0.orderResult.OrderNumber, CS_0024_003C_003E8__locals0.orderResult.isPaid, CS_0024_003C_003E8__locals0.orderResult.tipRecorded, CS_0024_003C_003E8__locals0.orderResult.tipAmount, CS_0024_003C_003E8__locals0.orderResult.CustomerInfoName, CS_0024_003C_003E8__locals0.orderResult.CustomerInfoPhone, CS_0024_003C_003E8__locals0.orderResult.CustomerInfo, CS_0024_003C_003E8__locals0.orderResult.OrderType, CS_0024_003C_003E8__locals0.orderResult.FlagID, CS_0024_003C_003E8__locals0.orderResult.col, CS_0024_003C_003E8__locals0.orderResult.row);
						}
						else if (orderResult2.row != num3 || orderResult2.col != num2)
						{
							method_7(CS_0024_003C_003E8__locals0.orderResult.OrderNumber, num3, num2);
						}
						if (num2 == int_4)
						{
							num3++;
							num2 = -1;
						}
						num2++;
						num = (short)(num + 1);
					}
				}
				int_6 = list.Count();
				if (int_6 > int_5)
				{
					int num4 = num3 * (AnEbVexupf - 200) + (num3 + 1) * short_0 * short_1 + num3 * 80 + eewbfssqe0.AutoScrollPosition.Y;
					label_0.Location = new Point(0, num4);
					label_0.Visible = true;
				}
				else
				{
					label_0.Location = new Point(0, 0);
					label_0.Visible = false;
				}
				multipleBillsToCompare.Clear();
				foreach (OrderResult item in list.Take(int_5))
				{
					multipleBillsToCompare.Add(item);
				}
			}
			else
			{
				timer_1.Enabled = (bool_7 = CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: false));
				if (!bool_7)
				{
					btnConfirmOnlineOrders.BackColor = (Color)btnConfirmOnlineOrders.Tag;
				}
			}
			list.Clear();
			list = null;
			bool_0 = false;
			verticalScrollControl1.EnableDisableButtonsByScrollPanel();
		}
		catch (Exception error)
		{
			bool_0 = false;
			if (this != null && !base.IsDisposed)
			{
				new NotificationLabel(this, "Something went wrong loading the orders. Please REFERSH the page.", NotificationTypes.Warning).Show();
			}
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void method_6(string string_4, string string_5, bool bool_8, bool bool_9, decimal decimal_0, string string_6, string string_7, string string_8, byte byte_0)
	{
		OrderChit orderChit = (OrderChit)eewbfssqe0.Controls.Find("chit" + string_5, searchAllChildren: false).FirstOrDefault();
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
			orderChit.UpdateClickLabelTag(byte_0 + "|" + string_8 + "|" + string_4 + "|" + string_6 + "|" + string_7);
			TransparentLabel transparentLabel = (TransparentLabel)eewbfssqe0.Controls.Find("lbl" + string_5, searchAllChildren: false).FirstOrDefault();
			if (transparentLabel != null)
			{
				transparentLabel.Location = new Point(orderChit.Location.X, orderChit.Location.Y + 115);
			}
			else
			{
				method_11(orderChit, string_5, bool_8, string_8, byte_0.ToString());
			}
			TransparentLabel transparentLabel2 = (TransparentLabel)eewbfssqe0.Controls.Find("lblTip" + string_5, searchAllChildren: false).FirstOrDefault();
			if (transparentLabel2 != null)
			{
				transparentLabel2.Location = new Point(orderChit.Location.X, orderChit.Location.Y + orderChit.Size.Height - transparentLabel2.Size.Height);
				transparentLabel2.BringToFront();
			}
			else
			{
				method_12(orderChit, string_5, bool_8, bool_9, decimal_0);
			}
		}
	}

	private void method_7(string string_4, int int_7, int int_8)
	{
		OrderChit orderChit = (OrderChit)eewbfssqe0.Controls.Find("chit" + string_4, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			orderChit.Location = new Point(int_8 * AnEbVexupf + (int_8 + 1) * short_0, int_7 * (AnEbVexupf - 200) + (int_7 + 1) * short_0 * short_1 + int_7 * 110 + eewbfssqe0.AutoScrollPosition.Y);
			TransparentLabel transparentLabel = (TransparentLabel)eewbfssqe0.Controls.Find("lblTip" + string_4, searchAllChildren: false).FirstOrDefault();
			if (transparentLabel != null)
			{
				transparentLabel.Location = new Point(orderChit.Location.X, orderChit.Location.Y + orderChit.Size.Height - transparentLabel.Size.Height);
			}
			TransparentLabel transparentLabel2 = (TransparentLabel)eewbfssqe0.Controls.Find("lbl" + string_4, searchAllChildren: false).FirstOrDefault();
			if (transparentLabel2 != null)
			{
				transparentLabel2.Location = new Point(orderChit.Location.X, orderChit.Location.Y + 115);
			}
		}
	}

	private void method_8(string string_4)
	{
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass37_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.orderNumber = string_4;
		OrderChit orderChit = (OrderChit)eewbfssqe0.Controls.Find("chit" + CS_0024_003C_003E8__locals0.orderNumber, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			eewbfssqe0.Controls.Remove(orderChit);
			orderChit.Dispose();
		}
		method_9(CS_0024_003C_003E8__locals0.orderNumber);
		new Thread((ThreadStart)delegate
		{
			try
			{
				Thread.Sleep(2000);
				CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0._003C_003E4__this.method_9(CS_0024_003C_003E8__locals0.orderNumber);
				});
			}
			catch
			{
			}
		}).Start();
	}

	private void method_9(string string_4)
	{
		TransparentLabel transparentLabel = (TransparentLabel)eewbfssqe0.Controls.Find("lblTip" + string_4, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			eewbfssqe0.Controls.Remove(transparentLabel);
			transparentLabel.Dispose();
		}
		TransparentLabel transparentLabel2 = (TransparentLabel)eewbfssqe0.Controls.Find("lbl" + string_4, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel2 != null)
		{
			eewbfssqe0.Controls.Remove(transparentLabel2);
			transparentLabel2.Dispose();
		}
	}

	private void method_10(string string_4, string string_5, bool bool_8, bool bool_9, decimal decimal_0, string string_6, string string_7, string string_8, string string_9, byte byte_0, int int_7, int int_8)
	{
		TransparentLabel transparentLabel = new TransparentLabel();
		transparentLabel.Name = string_5;
		transparentLabel.Tag = byte_0 + "|" + string_9 + "|" + string_4 + "|" + string_7 + "|" + string_6 + "|" + string_8;
		transparentLabel.MouseUp += method_13;
		OrderChit orderChit = new OrderChit(isKitchen: false, AnEbVexupf - 200, EnableBlinkingTimer: false, transparentLabel, ScreenType.take_out, ShowAllItems: false);
		orderChit.Name = "chit" + string_5;
		orderChit.OrderNumber.Add(string_5);
		orderChit.StationID = 1;
		orderChit.Width = AnEbVexupf;
		orderChit.Height = (int)((double)orderChit.Width * 0.5);
		orderChit.FontSize = 10f;
		orderChit.Tag = byte_0 + "|" + string_9 + "|" + string_4 + "|" + string_7 + "|" + string_6 + "|" + string_8;
		orderChit.Location = new Point(int_7 * AnEbVexupf + (int_7 + 1) * short_0, int_8 * (AnEbVexupf - 200) + (int_8 + 1) * short_0 * short_1 + int_8 * 110 + eewbfssqe0.AutoScrollPosition.Y);
		orderChit.BringToFront();
		eewbfssqe0.Controls.Add(orderChit);
		transparentLabel.BringToFront();
		method_11(orderChit, string_5, bool_8, string_9, byte_0.ToString());
		method_12(orderChit, string_5, bool_8, bool_9, decimal_0);
	}

	private void method_11(OrderChit orderChit_0, string string_4, bool bool_8, string string_5, string string_6)
	{
		_003C_003Ec__DisplayClass40_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0.isPaid = bool_8;
		CS_0024_003C_003E8__locals0.selectedOrderType = string_5;
		CS_0024_003C_003E8__locals0.orderFlag = string_6;
		CS_0024_003C_003E8__locals0.chit = orderChit_0;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.orderNumber = string_4;
		TransparentLabel transparentLabel = (TransparentLabel)eewbfssqe0.Controls.Find("lbl" + CS_0024_003C_003E8__locals0.orderNumber, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.BringToFront();
			return;
		}
		new Thread((ThreadStart)delegate
		{
			Thread.Sleep(500);
			if ((CS_0024_003C_003E8__locals0.isPaid && CS_0024_003C_003E8__locals0.selectedOrderType != OrderTypes.DeliveryOnline && CS_0024_003C_003E8__locals0.selectedOrderType != OrderTypes.TakeOutOnline && CS_0024_003C_003E8__locals0.selectedOrderType != OrderTypes.PickUpOnline && CS_0024_003C_003E8__locals0.selectedOrderType != OrderTypes.PickUpCurbsideOnline && CS_0024_003C_003E8__locals0.selectedOrderType != OrderTypes.DineInOnline) || (CS_0024_003C_003E8__locals0.isPaid && (CS_0024_003C_003E8__locals0.selectedOrderType == OrderTypes.DeliveryOnline || CS_0024_003C_003E8__locals0.selectedOrderType == OrderTypes.TakeOutOnline || CS_0024_003C_003E8__locals0.selectedOrderType == OrderTypes.PickUpOnline || CS_0024_003C_003E8__locals0.selectedOrderType == OrderTypes.PickUpCurbsideOnline || CS_0024_003C_003E8__locals0.selectedOrderType == OrderTypes.DineInOnline) && CS_0024_003C_003E8__locals0.orderFlag != ((byte)1).ToString()))
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_1();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals0.lbl = new TransparentLabel();
				CS_0024_003C_003E8__locals0.lbl.Size = CS_0024_003C_003E8__locals0.chit.Size;
				CS_0024_003C_003E8__locals0.lbl.Height = 72;
				CS_0024_003C_003E8__locals0.lbl.Location = new Point(CS_0024_003C_003E8__locals0.chit.Location.X, CS_0024_003C_003E8__locals0.chit.Location.Y + 35 + 80);
				CS_0024_003C_003E8__locals0.lbl.Text = Resources._PAID;
				CS_0024_003C_003E8__locals0.lbl.TextAlign = ContentAlignment.BottomCenter;
				CS_0024_003C_003E8__locals0.lbl.ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
				CS_0024_003C_003E8__locals0.lbl.Opacity = 70;
				CS_0024_003C_003E8__locals0.lbl.BackColor = Color.White;
				CS_0024_003C_003E8__locals0.lbl.Font = new Font("Arial", 30f, FontStyle.Bold);
				CS_0024_003C_003E8__locals0.lbl.MouseUp += CS_0024_003C_003E8__locals0._003C_003E4__this.method_13;
				CS_0024_003C_003E8__locals0.lbl.Name = "lbl" + CS_0024_003C_003E8__locals0.orderNumber;
				CS_0024_003C_003E8__locals0.lbl.Tag = CS_0024_003C_003E8__locals0.chit.Tag;
				CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Add(CS_0024_003C_003E8__locals0.lbl);
					CS_0024_003C_003E8__locals0.lbl.BringToFront();
					if ((OrderChit)CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Find("chit" + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber, searchAllChildren: false).FirstOrDefault() == null)
					{
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Remove(CS_0024_003C_003E8__locals0.lbl);
						CS_0024_003C_003E8__locals0.lbl.Dispose();
					}
				});
			}
		}).Start();
	}

	private void method_12(OrderChit orderChit_0, string string_4, bool bool_8, bool bool_9, decimal decimal_0)
	{
		_003C_003Ec__DisplayClass41_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals0.TipRecorded = bool_9;
		CS_0024_003C_003E8__locals0.isPaid = bool_8;
		CS_0024_003C_003E8__locals0.chit = orderChit_0;
		CS_0024_003C_003E8__locals0.TipAmount = decimal_0;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.orderNumber = string_4;
		TransparentLabel transparentLabel = (TransparentLabel)eewbfssqe0.Controls.Find("lblTip" + CS_0024_003C_003E8__locals0.orderNumber, searchAllChildren: false).FirstOrDefault();
		if (transparentLabel != null)
		{
			transparentLabel.BringToFront();
			return;
		}
		new Thread((ThreadStart)delegate
		{
			Thread.Sleep(700);
			if (CS_0024_003C_003E8__locals0.TipRecorded && CS_0024_003C_003E8__locals0.isPaid)
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_1();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals0.lblTip = new TransparentLabel();
				CS_0024_003C_003E8__locals0.lblTip.Size = new Size(CS_0024_003C_003E8__locals0.chit.Size.Width / 2, 35);
				CS_0024_003C_003E8__locals0.lblTip.Location = new Point(CS_0024_003C_003E8__locals0.chit.Location.X, CS_0024_003C_003E8__locals0.chit.Location.Y + CS_0024_003C_003E8__locals0.chit.Height - CS_0024_003C_003E8__locals0.lblTip.Size.Height);
				CS_0024_003C_003E8__locals0.lblTip.Text = Resources.Tip_Amount0 + CS_0024_003C_003E8__locals0.TipAmount.ToString("$0.00");
				CS_0024_003C_003E8__locals0.lblTip.TextAlign = ContentAlignment.BottomLeft;
				CS_0024_003C_003E8__locals0.lblTip.ForeColor = Color.Black;
				CS_0024_003C_003E8__locals0.lblTip.BackColor = Color.Transparent;
				CS_0024_003C_003E8__locals0.lblTip.Font = new Font("Arial", 12f, FontStyle.Regular);
				CS_0024_003C_003E8__locals0.lblTip.MouseUp += CS_0024_003C_003E8__locals0._003C_003E4__this.method_13;
				CS_0024_003C_003E8__locals0.lblTip.Name = "lblTip" + CS_0024_003C_003E8__locals0.orderNumber;
				CS_0024_003C_003E8__locals0.lblTip.Opacity = 80;
				CS_0024_003C_003E8__locals0.lblTip.Tag = CS_0024_003C_003E8__locals0.chit.Tag;
				CS_0024_003C_003E8__locals0._003C_003E4__this.Invoke((MethodInvoker)delegate
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Add(CS_0024_003C_003E8__locals0.lblTip);
					CS_0024_003C_003E8__locals0.lblTip.BringToFront();
					if ((OrderChit)CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Find("chit" + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber, searchAllChildren: false).FirstOrDefault() == null)
					{
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.eewbfssqe0.Controls.Remove(CS_0024_003C_003E8__locals0.lblTip);
						CS_0024_003C_003E8__locals0.lblTip.Dispose();
					}
				});
			}
		}).Start();
	}

	private void method_13(object sender, MouseEventArgs e)
	{
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass42_0();
		CS_0024_003C_003E8__locals0.lv = (Control)sender;
		string empty = string.Empty;
		CS_0024_003C_003E8__locals0.orderNum = CS_0024_003C_003E8__locals0.lv.Name.Replace("lblTip", string.Empty).Replace("lbl", string.Empty);
		OrderChit orderChit = (OrderChit)eewbfssqe0.Controls.Find("chit" + CS_0024_003C_003E8__locals0.orderNum, searchAllChildren: false).FirstOrDefault();
		if (orderChit != null)
		{
			if (orderChit.onlineOrder_confirmed_click || orderChit.OnlineOrderStatus == 1)
			{
				orderChit.onlineOrder_confirmed_click = false;
				return;
			}
			if (bool_3)
			{
				OrderHelper orderHelper = new OrderHelper();
				bool_3 = false;
				btnPrintChit.Text = "REPRINT CHIT";
				new NotificationLabel(this, "Printing Chit", NotificationTypes.Success).Show();
				{
					foreach (Station all_station in MemoryLoadedObjects.all_stations)
					{
						orderHelper.PrintToStation(orderChit.OrderNumber.First(), orderChit.OrderType, orderChit.CustomerInfoName + " - " + orderChit.Customer, all_station.StationID, orderChit.EmployeeName, isOrderMade: false, reprint: true, printOnlyOne: true);
					}
					return;
				}
			}
		}
		string empty2 = string.Empty;
		string text = string.Empty;
		string customerInfo = string.Empty;
		string[] array = CS_0024_003C_003E8__locals0.lv.Tag.ToString().Split('|');
		empty2 = array[0];
		empty = array[1];
		if (!(empty == OrderTypes.Delivery) && !(empty == OrderTypes.DeliveryOnline) && !(empty == OrderTypes.PickUp) && !(empty == OrderTypes.PickUpOnline))
		{
			string_2 = array[2];
		}
		else
		{
			string_2 = array[3];
		}
		if (array != null && array.Length > 4 && array.Length >= 5)
		{
			text = array[4];
			if (array.Length >= 6)
			{
				customerInfo = array[5];
			}
		}
		if (bool_4)
		{
			if (new frmMessageBox("Do you want to notify \"" + text + "-" + string_2 + "\" customer?", "Notify Customer", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals0.orderNum, string_2, empty);
				btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
				bool_4 = false;
			}
			return;
		}
		if ((TransparentLabel)eewbfssqe0.Controls.Find("lbl" + CS_0024_003C_003E8__locals0.orderNum, searchAllChildren: false).FirstOrDefault() != null)
		{
			string text2 = CS_0024_003C_003E8__locals0.orderNum.ToUpper();
			if ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON" && orderChit != null && !string.IsNullOrEmpty(orderChit.OrderTicket)) || !string.IsNullOrEmpty(orderChit.SubSource))
			{
				text2 = orderChit.OrderTicket;
			}
			if (new frmMessageBox("Do you want to clear this order (" + text2 + ")?", "Clear Order", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				OrderHelper orderHelper2 = new OrderHelper();
				orderHelper2.ClearOrder(CS_0024_003C_003E8__locals0.orderNum, empty, this);
				orderHelper2.RecordBatchId(CS_0024_003C_003E8__locals0.orderNum, empty, this);
				MiscHelper.NotifyCustomer(this, CS_0024_003C_003E8__locals0.orderNum, string_2, empty, suppressAlreadySentNotification: true);
			}
			return;
		}
		if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON" && (empty == OrderTypes.DeliveryOnline || empty == OrderTypes.TakeOutOnline || empty == OrderTypes.PickUpOnline || empty == OrderTypes.PickUpCurbsideOnline || empty == OrderTypes.DineInOnline) && empty2 == ((byte)1).ToString())
		{
			OrderResult orderResult = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNum).FirstOrDefault();
			if (orderResult != null)
			{
				orderResult.IsModified = true;
			}
			return;
		}
		if (MemoryLoadedObjects.OrderEntry.Visible)
		{
			MemoryLoadedObjects.OrderEntry.Close();
		}
		if (!OrderMethods.CheckIfOpenOrderExists(CS_0024_003C_003E8__locals0.lv.Name, Convert.ToInt32(ddlDateRangeFilter.SelectedValue)))
		{
			LoadFormProcedure();
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(CS_0024_003C_003E8__locals0.lv.Name, string_2, empty, 0, 0, text, customerInfo, resetComboId: true, 1);
		if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "ON")
		{
			DialogResult dialogResult = MemoryLoadedObjects.OrderEntry.ShowDialog();
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Cancel)
			{
				OrderResult orderResult2 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
				if (orderResult2 != null)
				{
					orderResult2.IsModified = true;
				}
			}
			LoadFormProcedure();
		}
		else
		{
			MemoryLoadedObjects.OrderEntry.Show();
			MemoryLoadedObjects.QuickService.Hide();
			OrderResult orderResult3 = multipleBillsToCompare.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.lv.Name).FirstOrDefault();
			if (orderResult3 != null)
			{
				orderResult3.IsModified = true;
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && bool_6)
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

	private void method_14(object sender, EventArgs e)
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
				PrintHelper.GenerateReceipt(text, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				continue;
			}
			break;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass45_0();
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
			CS_0024_003C_003E8__locals0.btn.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
		}
		else
		{
			CS_0024_003C_003E8__locals0.btn.BackColor = HelperMethods.GetColor("53, 152, 220");
		}
	}

	private void btnNewTakeOutOrder_Click(object sender, EventArgs e)
	{
		bool_1 = false;
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.PickUp, bool_0: false, this);
	}

	private void btnNewDeliveryOrder_Click(object sender, EventArgs e)
	{
		bool_1 = false;
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Delivery, bool_0: false, this);
	}

	private void btnNewOrder_Click(object sender, EventArgs e)
	{
		method_16();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(null, Resources.Walk_In, OrderTypes.DineIn, 1, 0, "", "", resetComboId: true, 1);
		MemoryLoadedObjects.OrderEntry.Show();
	}

	private void method_16()
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("second_screen");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (AppSettings.ScreenCount >= 2 && settingValueByKey == "ON")
			{
				if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
				{
					MemoryLoadedObjects.OrderEntrySecondScreen.ResetValues();
				}
				else
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntrySecondScreen();
					Rectangle bounds = AppSettings.SecondaryScreen.Bounds;
					MemoryLoadedObjects.OrderEntrySecondScreen.WindowState = FormWindowState.Normal;
					MemoryLoadedObjects.OrderEntrySecondScreen.TopMost = true;
					MemoryLoadedObjects.OrderEntrySecondScreen.Size = new Size(bounds.Width, bounds.Height);
					MemoryLoadedObjects.OrderEntrySecondScreen.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
					MemoryLoadedObjects.OrderEntrySecondScreen.StartPosition = FormStartPosition.Manual;
					MemoryLoadedObjects.OrderEntrySecondScreen.Show();
				}
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
		bool_1 = false;
	}

	private void btnToGo_Click(object sender, EventArgs e)
	{
		method_16();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
		MemoryLoadedObjects.OrderEntry.LoadFormData(null, Resources.Walk_In, OrderTypes.ToGo, 1, 0, "", "", resetComboId: true, 1);
		MemoryLoadedObjects.OrderEntry.Show();
	}

	private void eewbfssqe0_SizeChanged(object sender, EventArgs e)
	{
	}

	private void btnOpenRegister_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, "btnOpenRegister") != null)
		{
			GClass8.OpenCashDrawer();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int_0--;
		if (int_0 <= 0)
		{
			int_0 = int_1;
			if (bool_1 && !bool_2)
			{
				LoadFormProcedure();
			}
		}
		lblCounter.Text = int_0.ToString();
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

	private void btnChange_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Setting setting = gClass.Settings.Where((Setting s) => s.Key == "quick_service_view").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = "list";
			Helper.SubmitChangesWithCatch(gClass);
			SettingsHelper.SetSettingValueByKey("quick_service_view", setting.Value);
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickServiceListView();
			MemoryLoadedObjects.QuickServiceListView.LoadFormData(bool_6);
			MemoryLoadedObjects.QuickServiceListView.Show();
			timer_0.Enabled = false;
			bool_1 = false;
			Hide();
		}
	}

	private void btnScreenRefresh_Click(object sender, EventArgs e)
	{
		OrderHelper.OnlineOrderRefresh();
		LoadFormProcedure();
	}

	private void lblCounter_Click(object sender, EventArgs e)
	{
		OrderHelper.OnlineOrderRefresh();
		LoadFormProcedure();
	}

	private void method_17(Button button_0)
	{
		string_3 = button_0.Text;
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
		LoadFormProcedure();
	}

	private void btnOTFilter_All_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
	}

	private void btnOTFilter_DineIn_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
	}

	private void btnOTFilter_ToGo_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
	}

	private void btnOTFilter_PickUp_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
	}

	private void btnOTFilter_Delivery_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
	}

	private void btnOTFilter_Catering_Click(object sender, EventArgs e)
	{
		method_17((Button)sender);
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

	private void txtSearchInfo_TextChanged(object sender, EventArgs e)
	{
		LoadFormProcedure();
	}

	private void btnClearSearch_Click(object sender, EventArgs e)
	{
		((Control)(object)txtSearchInfo).Text = "";
		LoadFormProcedure();
	}

	private void btnNewCatering_Click(object sender, EventArgs e)
	{
		new OrderHelper().TakeOutDeliveryFlow(OrderTypes.Catering, bool_0: false, this);
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
		LoadFormProcedure();
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
		if (bool_4)
		{
			bool_4 = false;
			btnNotifyCustomer.Text = "NOTIFY CUSTOMER";
			timer_2.Enabled = false;
			new NotificationLabel(this, "Customer Notification Cancelled", NotificationTypes.Success, 3);
		}
	}

	private void ddlDateRangeFilter_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_2)
		{
			eewbfssqe0.Controls.Clear();
			multipleBillsToCompare.Clear();
			LoadFormProcedure();
		}
	}

	private void timer_3_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(MemoryLoadedData.OnlineOrderErrorMessage))
		{
			timer_3.Enabled = false;
			new frmMessageBox(MemoryLoadedData.OnlineOrderErrorMessage, "Online Order Error").ShowDialog();
			MemoryLoadedData.OnlineOrderErrorMessage = string.Empty;
			timer_3.Enabled = true;
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
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_118f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b0: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmQuickService));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		verticalScrollControl1 = new VerticalScrollControl();
		eewbfssqe0 = new Panel();
		lblTrainingMode = new Label();
		btnToGo = new Button();
		btnOpenRegister = new Button();
		btnNewOrder = new Button();
		btnNewDeliveryOrder = new Button();
		btnNewTakeOutOrder = new Button();
		BtnCancel = new Button();
		flowLayoutPanel1 = new FlowLayoutPanel();
		btnNotifyCustomer = new Button();
		btnPrintChit = new Button();
		btnNewCatering = new Button();
		btnConfirmOnlineOrders = new Button();
		lblTitle = new Label();
		btnChange = new Button();
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
		btnScreenRefresh = new Button();
		lblCounter = new Label();
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		timer_2 = new System.Windows.Forms.Timer(icontainer_1);
		ddlDateRangeFilter = new Class19();
		timer_3 = new System.Windows.Forms.Timer(icontainer_1);
		flowLayoutPanel1.SuspendLayout();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = eewbfssqe0;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Name = "verticalScrollControl1";
		componentResourceManager.ApplyResources(eewbfssqe0, "BillsPanel");
		eewbfssqe0.BorderStyle = BorderStyle.FixedSingle;
		eewbfssqe0.Name = "BillsPanel";
		eewbfssqe0.SizeChanged += eewbfssqe0_SizeChanged;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		btnToGo.BackColor = Color.FromArgb(61, 142, 185);
		btnToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnToGo.FlatAppearance.BorderSize = 0;
		btnToGo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnToGo, "btnToGo");
		btnToGo.ForeColor = Color.White;
		btnToGo.Name = "btnToGo";
		btnToGo.UseVisualStyleBackColor = false;
		btnToGo.Click += btnToGo_Click;
		btnOpenRegister.BackColor = Color.FromArgb(50, 119, 155);
		btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnOpenRegister.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenRegister, "btnOpenRegister");
		btnOpenRegister.ForeColor = Color.White;
		btnOpenRegister.Name = "btnOpenRegister";
		btnOpenRegister.UseVisualStyleBackColor = false;
		btnOpenRegister.Click += btnOpenRegister_Click;
		btnNewOrder.BackColor = Color.FromArgb(1, 110, 211);
		btnNewOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewOrder.FlatAppearance.BorderSize = 0;
		btnNewOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewOrder, "btnNewOrder");
		btnNewOrder.ForeColor = Color.White;
		btnNewOrder.Name = "btnNewOrder";
		btnNewOrder.UseVisualStyleBackColor = false;
		btnNewOrder.Click += btnNewOrder_Click;
		btnNewDeliveryOrder.BackColor = Color.FromArgb(80, 203, 116);
		btnNewDeliveryOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewDeliveryOrder.FlatAppearance.BorderSize = 0;
		btnNewDeliveryOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewDeliveryOrder, "btnNewDeliveryOrder");
		btnNewDeliveryOrder.ForeColor = Color.White;
		btnNewDeliveryOrder.Name = "btnNewDeliveryOrder";
		btnNewDeliveryOrder.UseVisualStyleBackColor = false;
		btnNewDeliveryOrder.Click += btnNewDeliveryOrder_Click;
		btnNewTakeOutOrder.BackColor = Color.FromArgb(176, 124, 219);
		btnNewTakeOutOrder.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewTakeOutOrder.FlatAppearance.BorderSize = 0;
		btnNewTakeOutOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewTakeOutOrder, "btnNewTakeOutOrder");
		btnNewTakeOutOrder.ForeColor = Color.White;
		btnNewTakeOutOrder.Name = "btnNewTakeOutOrder";
		btnNewTakeOutOrder.UseVisualStyleBackColor = false;
		btnNewTakeOutOrder.Click += btnNewTakeOutOrder_Click;
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.White;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
		flowLayoutPanel1.Controls.Add(BtnCancel);
		flowLayoutPanel1.Controls.Add(btnOpenRegister);
		flowLayoutPanel1.Controls.Add(btnNotifyCustomer);
		flowLayoutPanel1.Controls.Add(btnPrintChit);
		flowLayoutPanel1.Controls.Add(btnNewCatering);
		flowLayoutPanel1.Controls.Add(btnNewDeliveryOrder);
		flowLayoutPanel1.Controls.Add(btnNewTakeOutOrder);
		flowLayoutPanel1.Controls.Add(btnToGo);
		flowLayoutPanel1.Controls.Add(btnNewOrder);
		flowLayoutPanel1.Controls.Add(btnConfirmOnlineOrders);
		flowLayoutPanel1.Name = "flowLayoutPanel1";
		componentResourceManager.ApplyResources(btnNotifyCustomer, "btnNotifyCustomer");
		btnNotifyCustomer.BackColor = Color.FromArgb(53, 152, 220);
		btnNotifyCustomer.FlatAppearance.BorderColor = Color.White;
		btnNotifyCustomer.FlatAppearance.BorderSize = 0;
		btnNotifyCustomer.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnNotifyCustomer.ForeColor = Color.White;
		btnNotifyCustomer.Name = "btnNotifyCustomer";
		btnNotifyCustomer.UseVisualStyleBackColor = false;
		btnNotifyCustomer.Click += btnNotifyCustomer_Click;
		componentResourceManager.ApplyResources(btnPrintChit, "btnPrintChit");
		btnPrintChit.BackColor = Color.SandyBrown;
		btnPrintChit.FlatAppearance.BorderColor = Color.White;
		btnPrintChit.FlatAppearance.BorderSize = 0;
		btnPrintChit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPrintChit.ForeColor = Color.White;
		btnPrintChit.Name = "btnPrintChit";
		btnPrintChit.UseVisualStyleBackColor = false;
		btnPrintChit.Click += btnPrintChit_Click;
		btnNewCatering.BackColor = Color.FromArgb(53, 143, 79);
		btnNewCatering.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnNewCatering.FlatAppearance.BorderSize = 0;
		btnNewCatering.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewCatering, "btnNewCatering");
		btnNewCatering.ForeColor = Color.White;
		btnNewCatering.Name = "btnNewCatering";
		btnNewCatering.UseVisualStyleBackColor = false;
		btnNewCatering.Click += btnNewCatering_Click;
		componentResourceManager.ApplyResources(btnConfirmOnlineOrders, "btnConfirmOnlineOrders");
		btnConfirmOnlineOrders.BackColor = Color.FromArgb(255, 192, 128);
		btnConfirmOnlineOrders.FlatAppearance.BorderColor = Color.White;
		btnConfirmOnlineOrders.FlatAppearance.BorderSize = 0;
		btnConfirmOnlineOrders.FlatAppearance.MouseDownBackColor = Color.White;
		btnConfirmOnlineOrders.ForeColor = Color.Black;
		btnConfirmOnlineOrders.Name = "btnConfirmOnlineOrders";
		btnConfirmOnlineOrders.UseVisualStyleBackColor = false;
		btnConfirmOnlineOrders.Click += btnConfirmOnlineOrders_Click;
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.FlatStyle = FlatStyle.Flat;
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(btnChange, "btnChange");
		btnChange.BackColor = Color.FromArgb(214, 142, 81);
		btnChange.FlatAppearance.BorderColor = Color.Black;
		btnChange.FlatAppearance.BorderSize = 0;
		btnChange.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnChange.ForeColor = Color.White;
		btnChange.Name = "btnChange";
		btnChange.UseVisualStyleBackColor = false;
		btnChange.Click += btnChange_Click;
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
		((Control)(object)txtSearchInfo).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtSearchInfo).Name = "txtSearchInfo";
		((RadElement)((RadControl)txtSearchInfo).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSearchInfo).TextChanged += txtSearchInfo_TextChanged;
		((Control)(object)txtSearchInfo).Click += btnShowKeyboard_SearchInfo_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSearchInfo).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSearchInfo).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(btnShowKeyboard_SearchInfo, "btnShowKeyboard_SearchInfo");
		btnShowKeyboard_SearchInfo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchInfo.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_SearchInfo.ForeColor = Color.White;
		btnShowKeyboard_SearchInfo.Name = "btnShowKeyboard_SearchInfo";
		btnShowKeyboard_SearchInfo.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchInfo.Click += btnShowKeyboard_SearchInfo_Click;
		componentResourceManager.ApplyResources(btnScreenRefresh, "btnScreenRefresh");
		btnScreenRefresh.BackColor = Color.FromArgb(65, 168, 95);
		btnScreenRefresh.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnScreenRefresh.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnScreenRefresh.ForeColor = Color.White;
		btnScreenRefresh.Name = "btnScreenRefresh";
		btnScreenRefresh.UseVisualStyleBackColor = true;
		btnScreenRefresh.Click += btnScreenRefresh_Click;
		componentResourceManager.ApplyResources(lblCounter, "lblCounter");
		lblCounter.BackColor = Color.FromArgb(65, 168, 95);
		lblCounter.ForeColor = Color.White;
		lblCounter.Name = "lblCounter";
		lblCounter.Click += lblCounter_Click;
		timer_1.Interval = 500;
		timer_1.Tick += timer_1_Tick;
		timer_2.Interval = 30000;
		timer_2.Tick += timer_2_Tick;
		ddlDateRangeFilter.DrawMode = DrawMode.OwnerDrawVariable;
		ddlDateRangeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlDateRangeFilter, "ddlDateRangeFilter");
		ddlDateRangeFilter.Name = "ddlDateRangeFilter";
		ddlDateRangeFilter.SelectedIndexChanged += ddlDateRangeFilter_SelectedIndexChanged;
		timer_3.Enabled = true;
		timer_3.Interval = 5000;
		timer_3.Tick += timer_3_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(ddlDateRangeFilter);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(lblCounter);
		base.Controls.Add(btnScreenRefresh);
		base.Controls.Add(btnOTFilter_All);
		base.Controls.Add(label1);
		base.Controls.Add(btnOTFilter_Catering);
		base.Controls.Add(btnOTFilter_Delivery);
		base.Controls.Add(btnOTFilter_PickUp);
		base.Controls.Add(btnOTFilter_ToGo);
		base.Controls.Add(btnOTFilter_DineIn);
		base.Controls.Add(btnClearSearch);
		base.Controls.Add(label3);
		base.Controls.Add((Control)(object)txtSearchInfo);
		base.Controls.Add(btnShowKeyboard_SearchInfo);
		base.Controls.Add(btnChange);
		base.Controls.Add(lblTitle);
		base.Controls.Add(flowLayoutPanel1);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(eewbfssqe0);
		base.Name = "frmQuickService";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.WindowState = FormWindowState.Maximized;
		base.Activated += frmQuickService_Activated;
		base.Load += frmQuickService_Load;
		base.Controls.SetChildIndex(eewbfssqe0, 0);
		base.Controls.SetChildIndex(verticalScrollControl1, 0);
		base.Controls.SetChildIndex(flowLayoutPanel1, 0);
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(btnChange, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_SearchInfo, 0);
		base.Controls.SetChildIndex((Control)(object)txtSearchInfo, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(btnClearSearch, 0);
		base.Controls.SetChildIndex(btnOTFilter_DineIn, 0);
		base.Controls.SetChildIndex(btnOTFilter_ToGo, 0);
		base.Controls.SetChildIndex(btnOTFilter_PickUp, 0);
		base.Controls.SetChildIndex(btnOTFilter_Delivery, 0);
		base.Controls.SetChildIndex(btnOTFilter_Catering, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(btnOTFilter_All, 0);
		base.Controls.SetChildIndex(btnScreenRefresh, 0);
		base.Controls.SetChildIndex(lblCounter, 0);
		base.Controls.SetChildIndex(lblTrainingMode, 0);
		base.Controls.SetChildIndex(ddlDateRangeFilter, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		flowLayoutPanel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtSearchInfo).EndInit();
		ResumeLayout(performLayout: false);
	}
}
