using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAdminViewOrders : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public frmAdminViewOrders _003C_003E4__this;

		public string search;

		public GClass6 context;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__18(OrderPostDataModel o)
		{
			if (o.date_created.Date >= _003C_003E4__this.dateFrom.Value.Date)
			{
				return o.date_created.Date <= _003C_003E4__this.dateTo.Value.Date;
			}
			return false;
		}

		internal bool _003CFilterOrders_003Eb__21(OrderPostDataModel a)
		{
			return a.order_number.Contains(search);
		}

		internal OrderTotal _003CFilterOrders_003Eb__58(IGrouping<string, Order> x)
		{
			_003C_003Ec__DisplayClass7_7 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_7
			{
				x = x
			};
			return new OrderTotal
			{
				OrderNumber = _003C_003Ec__DisplayClass7_.x.First().OrderNumber,
				OrderTicket = _003C_003Ec__DisplayClass7_.x.First().OrderTicketNumber,
				Discount = _003C_003Ec__DisplayClass7_.x.Sum((Order c) => c.Discount),
				Sub = _003C_003Ec__DisplayClass7_.x.Sum((Order c) => c.SubTotal),
				Tax = _003C_003Ec__DisplayClass7_.x.Sum((Order c) => c.TaxTotal),
				Total = _003C_003Ec__DisplayClass7_.x.Sum((Order c) => c.Total),
				Refund = _003C_003Ec__DisplayClass7_.x.Where((Order w) => w.DateRefunded.HasValue).Sum((Order c) => c.Total),
				PaymentMethods = _003C_003Ec__DisplayClass7_.x.First().PaymentMethods,
				DatePaid = _003C_003Ec__DisplayClass7_.x.FirstOrDefault().DatePaid.Value,
				DiscountReason = _003C_003Ec__DisplayClass7_.x.FirstOrDefault().DiscountReason,
				CustomerInfo = _003C_003Ec__DisplayClass7_.x.FirstOrDefault().CustomerInfoName + ((_003C_003Ec__DisplayClass7_.x.FirstOrDefault().Customer != "Walk In") ? ("-" + _003C_003Ec__DisplayClass7_.x.FirstOrDefault().Customer) : string.Empty),
				RefundNumber = ((context.Refunds.Where((Refund a) => a.Order.OrderNumber == _003C_003Ec__DisplayClass7_.x.First().OrderNumber).FirstOrDefault() == null) ? "-" : context.Refunds.Where((Refund a) => a.Order.OrderNumber == _003C_003Ec__DisplayClass7_.x.First().OrderNumber).FirstOrDefault().RefundNumber),
				OrderType = _003C_003Ec__DisplayClass7_.x.FirstOrDefault().OrderType,
				TipAmount = _003C_003Ec__DisplayClass7_.x.FirstOrDefault().TipAmount,
				ServedByUserID = (_003C_003Ec__DisplayClass7_.x.First().UserServed.HasValue ? _003C_003Ec__DisplayClass7_.x.First().UserServed.Value : 0),
				UserCreatedID = (_003C_003Ec__DisplayClass7_.x.First().UserCashout.HasValue ? _003C_003Ec__DisplayClass7_.x.First().UserCashout.Value : 0)
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public string pay;

		public _003C_003Ec__DisplayClass7_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__7(Refund o)
		{
			if (o.PaymentMethod.Contains(pay))
			{
				return o.PaymentMethod != "";
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public OrderTotal order;

		public _003C_003Ec__DisplayClass7_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__17(Employee a)
		{
			return a.EmployeeID == order.ServedByUserID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_3
	{
		public int empId;

		public _003C_003Ec__DisplayClass7_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__31(Order a)
		{
			if (a.UserServed != empId)
			{
				return a.UserCashout == empId;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_4
	{
		public OrderTotal order;

		public _003C_003Ec__DisplayClass7_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__44(Employee a)
		{
			return a.EmployeeID == order.ServedByUserID;
		}

		internal bool _003CFilterOrders_003Eb__45(Employee a)
		{
			return a.EmployeeID == order.UserCreatedID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_5
	{
		public int empId;

		public _003C_003Ec__DisplayClass7_5()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__46(Order a)
		{
			if (a.UserServed != empId && a.UserCashout != empId)
			{
				return a.UserCreated == empId;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_6
	{
		public string pay;

		public _003C_003Ec__DisplayClass7_6()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__53(Order a)
		{
			if (a.PaymentMethods.Contains(pay))
			{
				return a.PaymentMethods != "";
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_7
	{
		public IGrouping<string, Order> x;

		public _003C_003Ec__DisplayClass7_7()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_8
	{
		public OrderTotal order;

		public _003C_003Ec__DisplayClass7_8()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CFilterOrders_003Eb__67(Employee a)
		{
			return a.EmployeeID == order.ServedByUserID;
		}

		internal bool _003CFilterOrders_003Eb__68(Employee a)
		{
			return a.EmployeeID == order.UserCreatedID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public string oldOrderNumber;

		public List<Order> orders;

		public Func<usp_ItemOptionsResult, bool> _003C_003E9__7;

		public _003C_003Ec__DisplayClass24_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnDuplicate_Click_003Eb__7(usp_ItemOptionsResult x)
		{
			return orders.Select((Order y) => y.ItemOptionId.Value).Contains(x.ItemWithOptionID);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public List<Guid> orderListIDs;

		public int billCount;

		public List<usp_ItemOptionsResult> iwos;

		public _003C_003Ec__DisplayClass24_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnDuplicate_Click_003Eb__5(Guid a)
		{
			return orderListIDs.FirstOrDefault() == a;
		}

		internal GlobalOrderHistoryObjects.Order _003CbtnDuplicate_Click_003Eb__8(Order x)
		{
			_003C_003Ec__DisplayClass24_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_2
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
	private sealed class _003C_003Ec__DisplayClass24_2
	{
		public Order x;

		public _003C_003Ec__DisplayClass24_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
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

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass33_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public string selectedOrder;

		public _003C_003Ec__DisplayClass34_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public string selectedOrder;

		public _003C_003Ec__DisplayClass35_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public string orderNumber;

		public List<Order> orders;

		public _003C_003Ec__DisplayClass41_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private string string_0;

	private CustomPager customPager_0;

	private string string_1;

	private int int_0;

	private bool bool_0;

	private List<OrderPostDataModel> list_2;

	private bool bool_1;

	private IContainer icontainer_1;

	internal ListView lstOrders;

	internal ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private Label label9;

	internal Button btnPrintReceipt;

	internal Button btnPreview;

	private ColumnHeader columnHeader_4;

	private ColumnHeader columnHeader_5;

	private DateTimePicker dateFrom;

	private DateTimePicker dateTo;

	private Label lblDash;

	private ColumnHeader columnHeader_6;

	private TabControl tabControl1;

	private TabPage tabOrdersPage;

	private TabPage tabRefundsPage;

	internal ListView lstRefunds;

	internal ColumnHeader columnHeader_7;

	private ColumnHeader columnHeader_8;

	private ColumnHeader columnHeader_9;

	private ColumnHeader columnHeader_10;

	private ColumnHeader columnHeader_11;

	internal Button btnClose;

	private Panel pnlMain;

	private ColumnHeader columnHeader_12;

	private ColumnHeader columnHeader_13;

	private ColumnHeader columnHeader_14;

	internal Button btnRefundOrder;

	private ColumnHeader columnHeader_15;

	private Label label1;

	private RadTextBoxControl txtSearchInfo;

	internal Button btnShowKeyboard_SearchInfo;

	private Label label3;

	internal Button btnDuplicate;

	private ColumnHeader columnHeader_16;

	private ColumnHeader columnHeader_17;

	private ColumnHeader columnHeader_18;

	private Label lblTraining;

	private ColumnHeader columnHeader_19;

	private Label label4;

	private CheckBox chkCash;

	private CheckBox chkVisa;

	private CheckBox chkAmex;

	private CheckBox chkMasterCard;

	private CheckBox chkOthers;

	private CheckBox chkInterac;

	internal Button btnChangePaymentType;

	internal Button btnReprintChit;

	private ColumnHeader columnHeader_20;

	internal Button btnVoidOrder;

	private CheckBox chkAll;

	internal Button btnPullOrder;

	private TabPage tabOtherOrdersPage;

	internal ListView lstOrderCatering;

	internal ColumnHeader columnHeader_21;

	private ColumnHeader columnHeader_22;

	private ColumnHeader columnHeader_23;

	private ColumnHeader columnHeader_24;

	private ColumnHeader columnHeader_25;

	private ColumnHeader columnHeader_26;

	private ColumnHeader columnHeader_27;

	private ColumnHeader columnHeader_28;

	private ColumnHeader columnHeader_29;

	private ColumnHeader columnHeader_30;

	private ColumnHeader columnHeader_31;

	private ColumnHeader columnHeader_32;

	private Label label2;

	private Class19 ddlEmployees;

	internal Button btnRefreshOrders;

	private TabPage tabVoidOrdersPage;

	internal ListView lstVoidOrders;

	internal ColumnHeader columnHeader_33;

	private ColumnHeader columnHeader_34;

	private ColumnHeader columnHeader_35;

	private ColumnHeader columnHeader_36;

	private ColumnHeader columnHeader_37;

	private ColumnHeader columnHeader_38;

	private ColumnHeader columnHeader_39;

	private ColumnHeader columnHeader_40;

	private ColumnHeader columnHeader_41;

	internal Button btnChangeEmpCashout;

	private ColumnHeader columnHeader_42;

	public frmAdminViewOrders()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = Class22.string_0;
		string_1 = Roles.employee;
		list_2 = new List<OrderPostDataModel>();
		// base._002Ector();
		InitializeComponent_1();
		customPager_0 = new CustomPager();
		CustomPager customPager = customPager_0;
		customPager.PagerButton_Click = (EventHandler)Delegate.Combine(customPager.PagerButton_Click, new EventHandler(method_4));
		pnlMain.Controls.Add(customPager_0);
		new FormHelper().ResizeButtonFonts(this);
		tabControl1.ItemSize = new Size(300, tabControl1.ItemSize.Height);
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTraining.Visible = true;
		}
		else
		{
			lblTraining.Visible = false;
		}
		if (!MemoryLoadedObjects.DefaultOrderTypes.Contains(OrderTypes.Catering) || !MemoryLoadedObjects.isMultipleLocation)
		{
			tabControl1.TabPages.Remove(tabOtherOrdersPage);
		}
	}

	private void method_3(string string_2, int int_1 = 0)
	{
		_003C_003Ec__DisplayClass7_7 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		Button button = btnPreview;
		Button button2 = btnChangePaymentType;
		Button button3 = btnRefundOrder;
		Button button4 = btnPrintReceipt;
		btnDuplicate.Enabled = true;
		button4.Enabled = true;
		button3.Enabled = true;
		button2.Enabled = true;
		button.Enabled = true;
		Button button5 = btnPullOrder;
		btnRefreshOrders.Visible = false;
		button5.Visible = false;
		string_0 = string_2;
		customPager_0.currentPage = int_1;
		_ = dateFrom.Value;
		_ = dateTo.Value;
		new List<OrderTotal>();
		List<string> list = new List<string>();
		lstOrders.Items.Clear();
		lstRefunds.Items.Clear();
		lstVoidOrders.Items.Clear();
		if (string_2 == Class22.string_0)
		{
			txtSearchInfo.Text = "";
		}
		CS_0024_003C_003E8__locals0.search = txtSearchInfo.Text.Trim();
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.search) && string_2 == Class22.string_1)
		{
			string_2 = Class22.string_0;
		}
		CS_0024_003C_003E8__locals0.context = new GClass6();
		if (tabControl1.SelectedTab.Text.Contains(Resources.Refunds))
		{
			btnRefundOrder.Visible = false;
			btnDuplicate.Visible = false;
			List<Refund> source3;
			if (string_2 == Class22.string_0)
			{
				List<Refund> list2 = new List<Refund>();
				List<Refund> list3 = new List<Refund>();
				if (chkAll.Checked)
				{
					IQueryable<Refund> source = CS_0024_003C_003E8__locals0.context.Refunds.Where((Refund o) => o.DateCreated.Date >= dateFrom.Value.Date && o.DateCreated.Date <= dateTo.Value.Date.AddDays(1.0).AddSeconds(-1.0));
					list2 = ((int_0 != 0) ? source.Where((Refund a) => a.EmployeeID == (int?)int_0 || (int?)a.Order.UserCreated == (int?)int_0 || (int?)a.Order.UserCashout == (int?)int_0 || (int?)a.Order.UserServed == (int?)int_0).ToList() : source.ToList());
				}
				else
				{
					if (chkCash.Checked)
					{
						list.Add("CASH");
					}
					if (chkVisa.Checked)
					{
						list.Add("VISA");
					}
					if (chkMasterCard.Checked)
					{
						list.Add("MASTERCARD");
					}
					if (chkInterac.Checked)
					{
						list.Add("INTERAC");
						list.Add("DEBIT");
					}
					if (chkAmex.Checked)
					{
						list.Add("AMERICAN EXPRESS");
						list.Add("AMEX");
					}
					if (chkOthers.Checked)
					{
						list.Add("GIFT");
						list.Add("LOYALTY");
						list.Add(Resources.Coupon.ToUpper());
						list.Add("COUPON");
						list.Add(Resources.Store_Credit.ToUpper());
						list.Add("STORE CREDIT");
						list.Add("JCB");
						list.Add("DISCOVER");
						list.Add("DINERS CLUB");
						list.Add("UBER EATS");
						list.Add("SKIP THE DISHES");
						list.Add("CREDIT");
						list.Add("OTHER");
						list.Add("CHECK");
					}
					IQueryable<Refund> source2 = CS_0024_003C_003E8__locals0.context.Refunds.Where((Refund o) => o.DateCreated.Date >= dateFrom.Value.Date && o.DateCreated.Date <= dateTo.Value.Date);
					list3 = ((int_0 != 0) ? source2.Where((Refund a) => a.EmployeeID == (int?)int_0).ToList() : source2.ToList());
					using List<string>.Enumerator enumerator = list.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass7_1();
						CS_0024_003C_003E8__locals7.pay = enumerator.Current;
						list2.AddRange(list3.Where((Refund o) => o.PaymentMethod.Contains(CS_0024_003C_003E8__locals7.pay) && o.PaymentMethod != "").ToList());
					}
				}
				source3 = (from a in list2
					orderby a.DateCreated descending, a.RefundNumber descending
					select a).ToList();
			}
			else
			{
				source3 = (from a in CS_0024_003C_003E8__locals0.context.Refunds.Where((Refund o) => (o.Order.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.search.ToLower()) || o.Order.Customer.Contains(CS_0024_003C_003E8__locals0.search) || o.Order.OrderNumber.Contains(CS_0024_003C_003E8__locals0.search) || o.Order.OrderTicketNumber.Contains(CS_0024_003C_003E8__locals0.search)) && o.Order.DateRefunded != null).ToList()
					orderby a.DateCreated descending, a.RefundNumber descending
					select a).ToList();
			}
			int num = (from r in source3
				group r by r.RefundNumber).Count();
			if (num <= 0)
			{
				return;
			}
			int num2 = ((num % customPager_0.rowsPerPage != 0) ? 1 : 0);
			int lastPage = num / customPager_0.rowsPerPage + num2;
			customPager_0.lastPage = lastPage;
			List<OrderTotal> list4 = (from x in (from r in source3
					group r by r.RefundNumber).Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage)
				select new OrderTotal
				{
					OrderNumber = x.First().Order.OrderNumber,
					Discount = x.Sum((Refund c) => c.Order.Discount),
					Sub = x.Sum((Refund c) => c.Order.SubTotal),
					Tax = x.Sum((Refund c) => c.Order.TaxTotal),
					Total = x.Sum((Refund c) => c.Order.Total),
					Refund = x.FirstOrDefault().AmountRefunded,
					PaymentMethods = x.FirstOrDefault().PaymentMethod,
					DatePaid = x.FirstOrDefault().DateCreated,
					RefundNumber = x.FirstOrDefault().RefundNumber,
					DiscountReason = x.FirstOrDefault().RefundReason,
					OrderType = x.FirstOrDefault().Order.OrderType,
					TipAmount = x.FirstOrDefault().Order.TipAmount,
					ServedByUserID = (x.FirstOrDefault().EmployeeID.HasValue ? x.FirstOrDefault().EmployeeID.Value : 0)
				}).ToList();
			customPager_0.AddPagerButtons();
			using List<OrderTotal>.Enumerator enumerator2 = list4.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass7_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_2();
				CS_0024_003C_003E8__locals1.order = enumerator2.Current;
				decimal num3 = default(decimal);
				if (CS_0024_003C_003E8__locals1.order.TipAmount > 0m && CS_0024_003C_003E8__locals1.order.Refund > 0m && !CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains(Resources.CASH0) && !CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains(Resources.Gift_Certificate.ToUpper()) && !CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains(Resources.Store_Credit.ToUpper()) && !CS_0024_003C_003E8__locals1.order.PaymentMethods.Contains(Resources.COUPON0))
				{
					num3 = CS_0024_003C_003E8__locals1.order.TipAmount;
				}
				string text = "";
				if (CS_0024_003C_003E8__locals1.order.ServedByUserID != 0)
				{
					Employee employee = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals1.order.ServedByUserID).FirstOrDefault();
					if (employee != null)
					{
						text = employee.FirstName + " " + employee.LastName;
					}
				}
				ListViewItem value = new ListViewItem(new string[9]
				{
					CS_0024_003C_003E8__locals1.order.RefundNumber,
					"$" + Math.Round(CS_0024_003C_003E8__locals1.order.Tax, 2),
					"$" + Math.Round(CS_0024_003C_003E8__locals1.order.Total + num3, 2),
					CS_0024_003C_003E8__locals1.order.DatePaid.ToString(),
					CS_0024_003C_003E8__locals1.order.PaymentMethods,
					CS_0024_003C_003E8__locals1.order.DiscountReason,
					CS_0024_003C_003E8__locals1.order.OrderNumber,
					CS_0024_003C_003E8__locals1.order.OrderType,
					text
				});
				lstRefunds.Items.Add(value);
			}
			return;
		}
		if (tabControl1.SelectedTab.Text.Contains("Other"))
		{
			Button button6 = btnPullOrder;
			btnRefreshOrders.Visible = true;
			button6.Visible = true;
			Button button7 = btnPreview;
			Button button8 = btnChangePaymentType;
			Button button9 = btnRefundOrder;
			Button button10 = btnPrintReceipt;
			btnDuplicate.Enabled = false;
			button10.Enabled = false;
			button9.Enabled = false;
			button8.Enabled = false;
			button7.Enabled = false;
			if (!bool_0)
			{
				OrderResponseModel orderResponseModel = new OrderResponseModel();
				orderResponseModel = SyncMethods.GetOrdersFromCatering();
				if (orderResponseModel.code != 200)
				{
					new NotificationLabel(this, orderResponseModel.message, NotificationTypes.Warning).Show();
					return;
				}
				list_2 = orderResponseModel.orderList;
				bool_0 = true;
			}
			if (string_2 == Class22.string_0)
			{
				list_2 = list_2.Where((OrderPostDataModel o) => o.date_created.Date >= CS_0024_003C_003E8__locals0._003C_003E4__this.dateFrom.Value.Date && o.date_created.Date <= CS_0024_003C_003E8__locals0._003C_003E4__this.dateTo.Value.Date).ToList();
				list_2 = (from a in list_2
					orderby a.date_created descending, a.order_number descending
					select a).ToList();
			}
			else
			{
				list_2 = (from a in list_2
					where a.order_number.Contains(CS_0024_003C_003E8__locals0.search)
					orderby a.date_paid descending, a.order_number descending
					select a).ToList();
			}
			int num4 = (from o in list_2
				group o by o.order_number).Count();
			if (num4 <= 0)
			{
				return;
			}
			int num5 = ((num4 % customPager_0.rowsPerPage != 0) ? 1 : 0);
			int lastPage2 = num4 / customPager_0.rowsPerPage + num5;
			customPager_0.lastPage = lastPage2;
			List<OrderTotal> list5 = (from x in (from o in list_2
					group o by o.order_number).Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage)
				select new OrderTotal
				{
					OrderNumber = x.First().order_number,
					Discount = x.Sum((OrderPostDataModel c) => c.discount),
					Sub = x.Sum((OrderPostDataModel c) => c.subtotal),
					Tax = x.Sum((OrderPostDataModel c) => c.tax_total),
					Total = x.Sum((OrderPostDataModel c) => c.total),
					PaymentMethods = x.First().payment_methods,
					DateCreated = x.FirstOrDefault().date_created,
					DiscountReason = x.FirstOrDefault().discount_reason,
					CustomerInfo = x.FirstOrDefault().customer_name + ((x.FirstOrDefault().customer_phone != "Walk In") ? ("-" + x.FirstOrDefault().customer_phone) : string.Empty),
					OrderType = x.FirstOrDefault().order_type,
					TipAmount = x.FirstOrDefault().tip_amount
				}).ToList();
			customPager_0.AddPagerButtons();
			lstOrderCatering.Items.Clear();
			{
				foreach (OrderTotal item in list5)
				{
					ListViewItem value2 = new ListViewItem(new string[11]
					{
						item.OrderNumber,
						item.DateCreated.ToString("MM/dd/yyyy hh:mmtt"),
						"$" + Math.Round(item.Sub, 2).ToString("0.00"),
						"$" + Math.Round(item.Discount, 2).ToString("0.00"),
						"$" + Math.Round(item.Tax, 2).ToString("0.00"),
						"$" + Math.Round(item.Total, 2).ToString("0.00"),
						item.PaymentMethods,
						"$" + Math.Round(item.TipAmount, 2).ToString("0.00"),
						item.OrderType,
						item.CustomerInfo,
						item.DiscountReason
					});
					lstOrderCatering.Items.Add(value2);
				}
				return;
			}
		}
		if (tabControl1.SelectedTab.Text.Contains("Void Orders"))
		{
			_003C_003Ec__DisplayClass7_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass7_3();
			btnRefundOrder.Visible = true;
			btnDuplicate.Visible = true;
			btnDuplicate.Enabled = false;
			List<Order> source4 = ((!(string_2 == Class22.string_0)) ? (from o in CS_0024_003C_003E8__locals0.context.Orders
				where o.DateCreated.HasValue && o.DateRefunded.HasValue == false && o.Void == true && (o.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.search.ToLower()) || o.Customer.Contains(CS_0024_003C_003E8__locals0.search) || o.OrderNumber.Contains(CS_0024_003C_003E8__locals0.search) || o.OrderTicketNumber.Contains(CS_0024_003C_003E8__locals0.search))
				select o into a
				orderby a.DatePaid descending, a.OrderNumber descending
				select a).ToList() : (from a in CS_0024_003C_003E8__locals0.context.Orders.Where((Order o) => o.DateCreated.HasValue && o.DateRefunded.HasValue == false && o.Void == true && o.DateCreated.Value.Date >= dateFrom.Value.Date && o.DateCreated.Value.Date <= dateTo.Value.Date).ToList()
				orderby a.DateCreated descending, a.OrderNumber descending
				select a).ToList());
			CS_0024_003C_003E8__locals2.empId = (int)ddlEmployees.SelectedValue;
			if (CS_0024_003C_003E8__locals2.empId != 0)
			{
				source4 = source4.Where((Order a) => a.UserServed == CS_0024_003C_003E8__locals2.empId || a.UserCashout == CS_0024_003C_003E8__locals2.empId).ToList();
			}
			int num6 = (from o in source4
				group o by o.OrderNumber).Count();
			if (num6 <= 0)
			{
				return;
			}
			int num7 = ((num6 % customPager_0.rowsPerPage != 0) ? 1 : 0);
			int lastPage3 = num6 / customPager_0.rowsPerPage + num7;
			customPager_0.lastPage = lastPage3;
			List<OrderTotal> list6 = (from x in (from o in source4
					group o by o.OrderNumber).Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage)
				select new OrderTotal
				{
					OrderNumber = x.First().OrderNumber,
					DateCreated = x.First().DateCreated.Value,
					Sub = x.Sum((Order c) => c.SubTotal),
					Tax = x.Sum((Order c) => c.TaxTotal),
					Total = x.Sum((Order c) => c.Total),
					CustomerInfo = x.FirstOrDefault().CustomerInfoName + ((x.FirstOrDefault().Customer != "Walk In") ? ("-" + x.FirstOrDefault().Customer) : string.Empty),
					OrderType = x.FirstOrDefault().OrderType,
					VoidReason = x.First().VoidReason,
					VoidBy = x.First().VoidBy
				}).ToList();
			customPager_0.AddPagerButtons();
			using List<OrderTotal>.Enumerator enumerator2 = list6.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass7_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass7_4();
				CS_0024_003C_003E8__locals3.order = enumerator2.Current;
				if (CS_0024_003C_003E8__locals3.order.TipAmount > 0m && CS_0024_003C_003E8__locals3.order.Refund > 0m && !CS_0024_003C_003E8__locals3.order.PaymentMethods.Contains(Resources.CASH0) && !CS_0024_003C_003E8__locals3.order.PaymentMethods.Contains(Resources.Gift_Certificate.ToUpper()) && !CS_0024_003C_003E8__locals3.order.PaymentMethods.Contains(Resources.Store_Credit.ToUpper()) && !CS_0024_003C_003E8__locals3.order.PaymentMethods.Contains(Resources.COUPON0))
				{
					_ = CS_0024_003C_003E8__locals3.order.TipAmount;
				}
				if (CS_0024_003C_003E8__locals3.order.ServedByUserID != 0)
				{
					Employee employee2 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals3.order.ServedByUserID).FirstOrDefault();
					if (employee2 != null)
					{
						_ = employee2.FirstName + " " + employee2.LastName;
					}
				}
				if (CS_0024_003C_003E8__locals3.order.UserCreatedID != 0)
				{
					Employee employee3 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals3.order.UserCreatedID).FirstOrDefault();
					if (employee3 != null)
					{
						_ = employee3.FirstName + " " + employee3.LastName;
					}
				}
				ListViewItem value3 = new ListViewItem(new string[9]
				{
					CS_0024_003C_003E8__locals3.order.OrderNumber,
					CS_0024_003C_003E8__locals3.order.DateCreated.ToString("MM/dd/yyyy hh:mmtt"),
					"$" + Math.Round(CS_0024_003C_003E8__locals3.order.Sub, 2).ToString("0.00"),
					"$" + Math.Round(CS_0024_003C_003E8__locals3.order.Tax, 2).ToString("0.00"),
					"$" + Math.Round(CS_0024_003C_003E8__locals3.order.Total, 2).ToString("0.00"),
					CS_0024_003C_003E8__locals3.order.OrderType,
					CS_0024_003C_003E8__locals3.order.CustomerInfo,
					CS_0024_003C_003E8__locals3.order.VoidReason,
					CS_0024_003C_003E8__locals3.order.VoidBy
				});
				lstVoidOrders.Items.Add(value3);
			}
			return;
		}
		_003C_003Ec__DisplayClass7_5 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass7_5();
		btnRefundOrder.Visible = true;
		btnDuplicate.Visible = true;
		btnDuplicate.Enabled = false;
		List<Order> source7;
		if (string_2 == Class22.string_0)
		{
			List<Order> list7 = new List<Order>();
			if (chkAll.Checked)
			{
				IQueryable<Order> source5 = CS_0024_003C_003E8__locals0.context.Orders.Where((Order o) => o.DatePaid.HasValue && o.DatePaid.Value.Date >= dateFrom.Value.Date && o.DatePaid.Value.Date <= dateTo.Value.Date.AddDays(1.0).AddSeconds(-1.0));
				list7 = ((int_0 != 0) ? source5.Where((Order a) => (int?)a.UserCashout == (int?)int_0 || (int?)a.UserServed == (int?)int_0 || (int?)a.UserCreated == (int?)int_0).ToList() : source5.ToList());
			}
			else
			{
				if (chkCash.Checked)
				{
					list.Add("CASH");
				}
				if (chkVisa.Checked)
				{
					list.Add("VISA");
				}
				if (chkMasterCard.Checked)
				{
					list.Add("MASTERCARD");
				}
				if (chkInterac.Checked)
				{
					list.Add("INTERAC");
					list.Add("DEBIT");
				}
				if (chkAmex.Checked)
				{
					list.Add("AMERICAN EXPRESS");
					list.Add("AMEX");
				}
				if (chkOthers.Checked)
				{
					list.Add("GIFT");
					list.Add("LOYALTY");
					list.Add(Resources.Coupon.ToUpper());
					list.Add("COUPON");
					list.Add(Resources.Store_Credit.ToUpper());
					list.Add("STORE CREDIT");
					list.Add("JCB");
					list.Add("DISCOVER");
					list.Add("DINERS CLUB");
					list.Add("UBER EATS");
					list.Add("SKIP THE DISHES");
					list.Add("CREDIT");
					list.Add("OTHER");
					list.Add("CHECK");
				}
				List<Order> source6 = CS_0024_003C_003E8__locals0.context.Orders.Where((Order o) => o.DatePaid.HasValue && o.DatePaid.Value.Date >= dateFrom.Value.Date && o.DatePaid.Value.Date <= dateTo.Value.Date).ToList();
				using List<string>.Enumerator enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_6 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass7_6();
					CS_0024_003C_003E8__locals5.pay = enumerator.Current;
					list7.AddRange(source6.Where((Order a) => a.PaymentMethods.Contains(CS_0024_003C_003E8__locals5.pay) && a.PaymentMethods != "").ToList());
				}
			}
			source7 = (from a in list7
				orderby a.DatePaid descending, a.OrderNumber descending
				select a).ToList();
		}
		else
		{
			source7 = (from a in CS_0024_003C_003E8__locals0.context.Orders.Where((Order o) => o.DatePaid.Value.Date >= dateFrom.Value.Date && o.DatePaid.Value.Date <= dateTo.Value.Date && o.Paid == true && (o.CustomerInfoName.ToLower().Contains(CS_0024_003C_003E8__locals0.search.ToLower()) || o.Customer.Contains(CS_0024_003C_003E8__locals0.search) || o.OrderNumber.Contains(CS_0024_003C_003E8__locals0.search) || o.OrderTicketNumber.Contains(CS_0024_003C_003E8__locals0.search))).ToList()
				orderby a.DatePaid descending, a.OrderNumber descending
				select a).ToList();
		}
		CS_0024_003C_003E8__locals4.empId = (int)ddlEmployees.SelectedValue;
		if (CS_0024_003C_003E8__locals4.empId != 0)
		{
			source7 = source7.Where((Order a) => a.UserServed == CS_0024_003C_003E8__locals4.empId || a.UserCashout == CS_0024_003C_003E8__locals4.empId || a.UserCreated == CS_0024_003C_003E8__locals4.empId).ToList();
		}
		int num8 = (from o in source7
			group o by o.OrderNumber).Count();
		if (num8 <= 0)
		{
			return;
		}
		int num9 = ((num8 % customPager_0.rowsPerPage != 0) ? 1 : 0);
		int lastPage4 = num8 / customPager_0.rowsPerPage + num9;
		customPager_0.lastPage = lastPage4;
		List<OrderTotal> list8 = (from o in source7
			group o by o.OrderNumber).Skip(customPager_0.rowsPerPage * customPager_0.currentPage).Take(customPager_0.rowsPerPage).Select(delegate(IGrouping<string, Order> x)
		{
			CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_7();
			CS_0024_003C_003E8__locals0.x = x;
			return new OrderTotal
			{
				OrderNumber = CS_0024_003C_003E8__locals0.x.First().OrderNumber,
				OrderTicket = CS_0024_003C_003E8__locals0.x.First().OrderTicketNumber,
				Discount = CS_0024_003C_003E8__locals0.x.Sum((Order c) => c.Discount),
				Sub = CS_0024_003C_003E8__locals0.x.Sum((Order c) => c.SubTotal),
				Tax = CS_0024_003C_003E8__locals0.x.Sum((Order c) => c.TaxTotal),
				Total = CS_0024_003C_003E8__locals0.x.Sum((Order c) => c.Total),
				Refund = CS_0024_003C_003E8__locals0.x.Where((Order w) => w.DateRefunded.HasValue).Sum((Order c) => c.Total),
				PaymentMethods = CS_0024_003C_003E8__locals0.x.First().PaymentMethods,
				DatePaid = CS_0024_003C_003E8__locals0.x.FirstOrDefault().DatePaid.Value,
				DiscountReason = CS_0024_003C_003E8__locals0.x.FirstOrDefault().DiscountReason,
				CustomerInfo = CS_0024_003C_003E8__locals0.x.FirstOrDefault().CustomerInfoName + ((CS_0024_003C_003E8__locals0.x.FirstOrDefault().Customer != "Walk In") ? ("-" + CS_0024_003C_003E8__locals0.x.FirstOrDefault().Customer) : string.Empty),
				RefundNumber = ((CS_0024_003C_003E8__locals0.context.Refunds.Where((Refund a) => a.Order.OrderNumber == CS_0024_003C_003E8__locals0.x.First().OrderNumber).FirstOrDefault() == null) ? "-" : CS_0024_003C_003E8__locals0.context.Refunds.Where((Refund a) => a.Order.OrderNumber == CS_0024_003C_003E8__locals0.x.First().OrderNumber).FirstOrDefault().RefundNumber),
				OrderType = CS_0024_003C_003E8__locals0.x.FirstOrDefault().OrderType,
				TipAmount = CS_0024_003C_003E8__locals0.x.FirstOrDefault().TipAmount,
				ServedByUserID = (CS_0024_003C_003E8__locals0.x.First().UserServed.HasValue ? CS_0024_003C_003E8__locals0.x.First().UserServed.Value : 0),
				UserCreatedID = (CS_0024_003C_003E8__locals0.x.First().UserCashout.HasValue ? CS_0024_003C_003E8__locals0.x.First().UserCashout.Value : 0)
			};
		})
			.ToList();
		customPager_0.AddPagerButtons();
		using List<OrderTotal>.Enumerator enumerator2 = list8.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			_003C_003Ec__DisplayClass7_8 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass7_8();
			CS_0024_003C_003E8__locals6.order = enumerator2.Current;
			decimal num10 = default(decimal);
			if (CS_0024_003C_003E8__locals6.order.TipAmount > 0m && CS_0024_003C_003E8__locals6.order.Refund > 0m && !CS_0024_003C_003E8__locals6.order.PaymentMethods.Contains(Resources.CASH0) && !CS_0024_003C_003E8__locals6.order.PaymentMethods.Contains(Resources.Gift_Certificate.ToUpper()) && !CS_0024_003C_003E8__locals6.order.PaymentMethods.Contains(Resources.Store_Credit.ToUpper()) && !CS_0024_003C_003E8__locals6.order.PaymentMethods.Contains(Resources.COUPON0))
			{
				num10 = CS_0024_003C_003E8__locals6.order.TipAmount;
			}
			string text2 = "";
			if (CS_0024_003C_003E8__locals6.order.ServedByUserID != 0)
			{
				Employee employee4 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals6.order.ServedByUserID).FirstOrDefault();
				if (employee4 != null)
				{
					text2 = employee4.FirstName + " " + employee4.LastName;
				}
			}
			string text3 = "";
			if (CS_0024_003C_003E8__locals6.order.UserCreatedID != 0)
			{
				Employee employee5 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals6.order.UserCreatedID).FirstOrDefault();
				if (employee5 != null)
				{
					text3 = employee5.FirstName + " " + employee5.LastName;
				}
			}
			ListViewItem value4 = new ListViewItem(new string[14]
			{
				CS_0024_003C_003E8__locals6.order.OrderNumber,
				CS_0024_003C_003E8__locals6.order.OrderTicket,
				CS_0024_003C_003E8__locals6.order.DatePaid.ToString("MM/dd/yyyy hh:mmtt"),
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.Sub, 2).ToString("0.00"),
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.Discount, 2).ToString("0.00"),
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.Tax, 2).ToString("0.00"),
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.Total, 2).ToString("0.00"),
				CS_0024_003C_003E8__locals6.order.PaymentMethods,
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.TipAmount, 2).ToString("0.00"),
				"$" + Math.Round(CS_0024_003C_003E8__locals6.order.Refund + num10, 2).ToString("0.00"),
				CS_0024_003C_003E8__locals6.order.OrderType,
				CS_0024_003C_003E8__locals6.order.CustomerInfo,
				CS_0024_003C_003E8__locals6.order.DiscountReason,
				text2 + " - " + text3
			});
			lstOrders.Items.Add(value4);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (button.Text == "<<")
		{
			method_3(string_0);
		}
		else if (button.Text == "<")
		{
			method_3(string_0, customPager_0.currentPage - 1);
		}
		else if (button.Text == ">")
		{
			method_3(string_0, customPager_0.currentPage + 1);
		}
		else if (button.Text == ">>")
		{
			method_3(string_0, customPager_0.lastPage - 1);
		}
		else
		{
			method_3(string_0, Convert.ToInt32(button.Text) - 1);
		}
	}

	private void lstOrders_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		new frmReport(lstOrders.SelectedItems[0].Text, ReportTypes.Orders).ShowDialog();
	}

	private void lstVoidOrders_MouseDoubleClick(object sender, MouseEventArgs e)
	{
	}

	private void btnPrintReceipt_Click(object sender, EventArgs e)
	{
		if (tabControl1.SelectedTab.Text.Contains(Resources.Refunds))
		{
			if (lstRefunds.SelectedItems.Count != 0)
			{
				new PrintHelper().GenerateRefundReceipt(lstRefunds.SelectedItems[0].SubItems[0].Text);
			}
			else
			{
				new frmMessageBox(Resources.Select_an_order_to_print).ShowDialog(this);
			}
		}
		else if (lstOrders.SelectedItems.Count != 0)
		{
			PrintHelper.GenerateReceipt(lstOrders.SelectedItems[0].SubItems[0].Text, printPaymentTransaction: true, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
		}
		else
		{
			new frmMessageBox(Resources.Select_an_order_to_print).ShowDialog(this);
		}
	}

	private void btnPreview_Click(object sender, EventArgs e)
	{
		if (tabControl1.SelectedTab.Text.Contains(Resources.Refunds))
		{
			if (lstRefunds.SelectedItems.Count != 0)
			{
				new frmReport(lstRefunds.SelectedItems[0].Text, ReportTypes.Refunds).ShowDialog();
			}
			else
			{
				new frmMessageBox(Resources.Select_an_order_to_view).ShowDialog(this);
			}
		}
		else if (lstOrders.SelectedItems.Count != 0)
		{
			new frmReport(lstOrders.SelectedItems[0].Text, ReportTypes.Orders).ShowDialog(this);
		}
		else
		{
			new frmMessageBox(Resources.Select_an_order_to_view).ShowDialog(this);
		}
	}

	private void dateFrom_ValueChanged(object sender, EventArgs e)
	{
		if (dateFrom.Value > dateTo.Value)
		{
			dateTo.Value = dateFrom.Value;
		}
		else
		{
			method_3(Class22.string_0);
		}
	}

	private void dateTo_ValueChanged(object sender, EventArgs e)
	{
		if (dateFrom.Value > dateTo.Value)
		{
			dateFrom.Value = dateTo.Value;
		}
		else
		{
			method_3(Class22.string_0);
		}
	}

	private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3(Class22.string_0);
		if (tabControl1.SelectedTab.Text.Contains(Resources.Saved_Orders))
		{
			btnPreview.Visible = true;
			btnPreview.Text = Resources.LOAD_ORDER;
			btnPreview.Font = new Font(btnPreview.Font.FontFamily, 8f);
		}
		else if (tabControl1.SelectedTab.Text.Contains("Void Orders"))
		{
			btnPreview.Visible = false;
		}
		else
		{
			btnPreview.Visible = true;
			btnPreview.Text = Resources.PREVIEW;
			btnPreview.Font = new Font(btnPreview.Font.FontFamily, 10f);
			btnReprintChit.Visible = false;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		AuthMethods.LogOutUser();
		if (customPager_0 != null)
		{
			customPager_0.Dispose();
		}
		if (list_2 != null)
		{
			list_2.Clear();
		}
		list_2 = null;
		Close();
	}

	private void frmAdminViewOrders_Load(object sender, EventArgs e)
	{
		string_1 = UserMethods.GetEmployeeRole(Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]));
		int_0 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]);
		MemoryLoadedObjects.all_employees = new GClass6().Employees.ToList();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		if (!(string_1 == Roles.admin) && !(string_1 == Roles.manager))
		{
			Employee employee = MemoryLoadedObjects.all_employees.Where((Employee employee_0) => employee_0.EmployeeID == int_0).FirstOrDefault();
			if (employee != null)
			{
				dictionary.Add(employee.EmployeeID, employee.FirstName + " " + employee.LastName);
			}
		}
		else
		{
			dictionary.Add(0, Resources.All_Employees);
			foreach (KeyValuePair<int, string> item in (from a in MemoryLoadedObjects.all_employees
				where a.isActive && a.FirstName != null && a.FirstName != string.Empty
				select a into x
				orderby x.FirstName
				select x).ThenBy((Employee y) => y.LastName).ToDictionary((Employee a) => a.EmployeeID, (Employee a) => (!string.IsNullOrEmpty(a.FirstName) && !string.IsNullOrEmpty(a.LastName)) ? (a.FirstName + " " + a.LastName) : a.FirstName))
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		ddlEmployees.DisplayMember = "Value";
		ddlEmployees.ValueMember = "Key";
		ddlEmployees.DataSource = new BindingSource(dictionary, null);
		ddlEmployees.SelectedIndex = 0;
		int_0 = Convert.ToInt32(ddlEmployees.SelectedValue);
		pnlMain.Left = (base.Size.Width - pnlMain.Width) / 2;
		if (lstRefunds.Columns.Count > 0)
		{
			lstRefunds.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.0);
			lstRefunds.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 0.75);
			lstRefunds.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 0.75);
			lstRefunds.Columns[3].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.0);
			lstRefunds.Columns[4].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.5);
			lstRefunds.Columns[5].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 2.5);
			lstRefunds.Columns[6].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.0);
			lstRefunds.Columns[7].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.0);
			lstRefunds.Columns[8].Width = ControlHelpers.ControlWidthFixer(lstRefunds, 1.0);
		}
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 22);
		if (lstOrders.Columns.Count > 0)
		{
			lstOrders.SmallImageList = imageList;
			lstOrders.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.8);
			if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")
			{
				lstOrders.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.6);
			}
			else
			{
				lstOrders.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.0);
			}
			lstOrders.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstOrders, 1.5);
			lstOrders.Columns[3].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.8);
			lstOrders.Columns[4].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.6);
			lstOrders.Columns[5].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.6);
			lstOrders.Columns[6].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.7);
			lstOrders.Columns[7].Width = ControlHelpers.ControlWidthFixer(lstOrders, 1.3);
			lstOrders.Columns[8].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.7);
			lstOrders.Columns[9].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.7);
			lstOrders.Columns[10].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.9);
			lstOrders.Columns[11].Width = ControlHelpers.ControlWidthFixer(lstOrders, 1.4);
			if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")
			{
				lstOrders.Columns[12].Width = ControlHelpers.ControlWidthFixer(lstOrders, 0.7);
			}
			else
			{
				lstOrders.Columns[12].Width = ControlHelpers.ControlWidthFixer(lstOrders, 1.25);
			}
			lstOrders.Columns[13].Width = ControlHelpers.ControlWidthFixer(lstOrders, 1.0);
		}
		customPager_0.Location = new Point(tabControl1.Location.X, tabControl1.Bottom);
		customPager_0.Size = new Size(tabControl1.Width, customPager_0.Height);
		method_3(Class22.string_0);
	}

	private void btnRefundOrder_Click(object sender, EventArgs e)
	{
		if (!tabControl1.SelectedTab.Text.Contains(Resources.Orders))
		{
			return;
		}
		if (lstOrders.SelectedItems.Count != 0)
		{
			new frmRefund(lstOrders.SelectedItems[0].Text).ShowDialog(this);
			if (!string.IsNullOrEmpty(txtSearchInfo.Text))
			{
				method_3(Class22.string_1);
			}
			else
			{
				method_3(Class22.string_0);
			}
		}
		else
		{
			new frmMessageBox(Resources.Select_an_order_to_refund).ShowDialog(this);
		}
	}

	private void method_6(string string_2, RadTextBoxControl radTextBoxControl_0)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(string_2, 0, 128, radTextBoxControl_0.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl_0.Text = MemoryLoadedObjects.Keyboard.textEntered;
			method_3(Class22.string_1);
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_SearchInfo_Click(object sender, EventArgs e)
	{
		method_6(Resources.Enter_Search_Criteria, txtSearchInfo);
	}

	private void txtSearchInfo_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void txtSearchInfo_KeyUp(object sender, KeyEventArgs e)
	{
		method_3(Class22.string_1);
	}

	private void btnDuplicate_Click(object sender, EventArgs e)
	{
		if (!tabControl1.SelectedTab.Text.Contains(Resources.Orders))
		{
			return;
		}
		if (lstOrders.SelectedItems.Count != 0)
		{
			_003C_003Ec__DisplayClass24_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
			CS_0024_003C_003E8__locals0.oldOrderNumber = lstOrders.SelectedItems[0].Text;
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.orders = (from o in gClass.Orders
				where o.OrderNumber == CS_0024_003C_003E8__locals0.oldOrderNumber && o.DatePaid.HasValue && o.ItemID > 0
				select o into x
				orderby x.DateCreated
				select x).ToList();
			if (CS_0024_003C_003E8__locals0.orders.Count() <= 0)
			{
				return;
			}
			GlobalOrderHistoryObjects.CustomerInfo customerInfo = new GlobalOrderHistoryObjects.CustomerInfo();
			Order order = CS_0024_003C_003E8__locals0.orders.FirstOrDefault();
			customerInfo.customer_cell = order.Customer;
			customerInfo.customer_address = order.CustomerInfo;
			customerInfo.customer_name = order.CustomerInfoName;
			customerInfo.customer_id = order.CustomerID.Value;
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
					_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass24_1();
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
							CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_2();
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
					OrderHelper.DuplicateOrder(orders, customerInfo, newOrderNumber, order.OrderType, (short)employee.EmployeeID);
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
		else
		{
			new frmMessageBox(Resources.Please_select_a_Take_Out_or_De).ShowDialog(this);
		}
	}

	private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstOrders.SelectedItems.Count != 0)
		{
			string text = lstOrders.SelectedItems[0].SubItems[10].Text;
			if (!text.Equals(OrderTypes.PickUp) && !text.Equals(OrderTypes.Delivery))
			{
				btnDuplicate.Enabled = false;
			}
			else
			{
				btnDuplicate.Enabled = true;
			}
			string text2 = lstOrders.SelectedItems[0].SubItems[6].Text;
			string value = lstOrders.SelectedItems[0].SubItems[9].Text;
			btnRefundOrder.Enabled = !text2.Equals(value);
			if (Convert.ToDateTime(lstOrders.SelectedItems[0].SubItems[2].Text).Date >= DateTime.Now.AddHours(-6.0).Date)
			{
				btnReprintChit.Visible = true;
			}
			else
			{
				btnReprintChit.Visible = false;
			}
			if (!SettingsHelper.isVoidOrderAddOn)
			{
				return;
			}
			string text3 = lstOrders.SelectedItems[0].SubItems[7].Text;
			bool flag = true;
			if (text3.Contains("CASH"))
			{
				foreach (string item in from x in text3.Split('|')
					where !string.IsNullOrEmpty(x)
					select x)
				{
					if (!item.Contains("CASH"))
					{
						flag = false;
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (string_1 == Roles.admin && flag)
			{
				btnVoidOrder.Visible = true;
			}
			else
			{
				btnVoidOrder.Visible = false;
			}
		}
		else
		{
			btnDuplicate.Enabled = false;
		}
	}

	private void btnDuplicate_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.BackColor = Color.Gray;
		}
		else
		{
			button.BackColor = Color.FromArgb(176, 124, 219);
		}
	}

	private void lstRefunds_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		new frmReport(lstRefunds.SelectedItems[0].Text, ReportTypes.Refunds).Show();
	}

	private void btnRefundOrder_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.BackColor = Color.Gray;
		}
		else
		{
			button.BackColor = Color.SandyBrown;
		}
	}

	private DateTime method_7(DateTime dateTime_0)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_0);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void dateFrom_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_7(dateTimePicker.Value);
	}

	private void chkCash_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			bool_1 = true;
			method_3(string_0);
			bool_1 = false;
		}
	}

	private void btnChangePaymentType_Click(object sender, EventArgs e)
	{
		if (!tabControl1.SelectedTab.Text.Contains(Resources.Orders) || lstOrders.SelectedItems.Count == 0 || AuthMethods.EmployeeAuthenticateControl(this, "btnChangePaymentType") == null)
		{
			return;
		}
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.orderNumber = lstOrders.SelectedItems[0].Text;
		List<Order> list = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && a.Void == false).ToList();
		frmSelectPaymentMethodMultiple frmSelectPaymentMethodMultiple2 = new frmSelectPaymentMethodMultiple(list.Sum((Order a) => a.Total));
		if (frmSelectPaymentMethodMultiple2.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		bool flag = false;
		decimal num = default(decimal);
		decimal tipAmount = list.FirstOrDefault().TipAmount;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter TIP", 2, 10, tipAmount.ToString("0.00"));
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			num = MemoryLoadedObjects.Numpad.numberEntered;
			if (num != tipAmount && new frmMessageBox("Do you want to change the existing $" + tipAmount.ToString("0.00") + " tip amount to the new $" + num.ToString("0.00") + " tip amount?", "Change Tip", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
			{
				flag = true;
			}
		}
		string text = "";
		foreach (ProcessorPaymentTypeWithId item in frmSelectPaymentMethodMultiple2.paymentMethod)
		{
			text = text + item.PaymentTypeName + "=" + item.Amount.ToString("0.00") + "|";
		}
		foreach (Order item2 in list)
		{
			item2.PaymentMethods = text;
			item2.TenderAmount = frmSelectPaymentMethodMultiple2.TenderCash;
			item2.TenderChange = frmSelectPaymentMethodMultiple2.TenderChange;
			if (!flag)
			{
				item2.TipAmount = frmSelectPaymentMethodMultiple2.Tip + num;
				item2.TipDesc = OrderHelper.UpdateDiscountFromDiscountDescription(item2.TipDesc, TipTypes.Cash, item2.TipAmount);
			}
			item2.Synced = false;
		}
		Helper.SubmitChangesWithCatch(gClass);
		method_3(string_0);
	}

	private void btnReprintChit_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		if (lstOrders.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Please select an order to re-print chit(s).", NotificationTypes.Notification).Show();
			return;
		}
		OrderHelper orderHelper = new OrderHelper();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.selectedOrder = lstOrders.SelectedItems[0].SubItems[0].Text;
		Order order = gClass.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.selectedOrder).FirstOrDefault();
		Employee employee = (order.UserCreated.HasValue ? UserMethods.GetUserByID(order.UserCreated.Value) : null);
		string orderNumber = order.OrderNumber;
		string orderType = order.OrderType;
		string customer = order.CustomerInfoName + " - " + order.Customer;
		string employee2 = "";
		if (employee != null)
		{
			employee2 = employee.FirstName;
		}
		else if (orderNumber.Contains("WEB"))
		{
			employee2 = OnlineOrderProviders.Hippos + " Online Order";
		}
		if (order != null)
		{
			foreach (Station station in gClass.Stations)
			{
				orderHelper.PrintToStation(orderNumber, orderType, customer, station.StationID, employee2, isOrderMade: false, reprint: true, printOnlyOne: true, order.Customer);
			}
		}
		orderHelper = null;
		gClass = null;
		GC.Collect();
	}

	private void btnVoidOrder_Click(object sender, EventArgs e)
	{
		if (tabControl1.SelectedTab.Text.ToUpper() == Resources.Orders.ToUpper() && lstOrders.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass35_0();
			CS_0024_003C_003E8__locals0.selectedOrder = lstOrders.SelectedItems[0].SubItems[0].Text;
			if (new frmMessageBox("Are you sure you want to delete this order? " + CS_0024_003C_003E8__locals0.selectedOrder + ". This order will be deleted in the database. You cannot undo this action.", "Delete Order", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
			{
				return;
			}
			GClass6 gClass = new GClass6();
			List<Order> list = gClass.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.selectedOrder).ToList();
			if (list.Where((Order a) => a.Refunds.Count > 0).Count() > 0)
			{
				if (new frmMessageBox("Are you sure you want to delete this order? This order has a corresponding refund data. The Refund data will be deleted.", "DELETE ORDER", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
				{
					return;
				}
				foreach (Order item in list)
				{
					List<Refund> entities = item.Refunds.ToList();
					gClass.Refunds.DeleteAllOnSubmit(entities);
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			gClass.Orders.DeleteAllOnSubmit(list);
			Helper.SubmitChangesWithCatch(gClass);
			CloudsyncDataArchiver entity = new CloudsyncDataArchiver
			{
				DataType = "order",
				UniqueIdentifier = CS_0024_003C_003E8__locals0.selectedOrder,
				DateCreated = DateTime.Now,
				Synced = false
			};
			gClass.CloudsyncDataArchivers.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
			string text = "";
			Employee employeeByID = EmployeeMethods.getEmployeeByID(Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]));
			if (employeeByID != null)
			{
				text = employeeByID.FirstName + " " + employeeByID.LastName;
			}
			new NotificationLabel(this, "Order has been deleted.", NotificationTypes.Success).Show();
			LogHelper.WriteLog("Order Deleted " + CS_0024_003C_003E8__locals0.selectedOrder + ", by " + text, LogTypes.call_log);
			method_3(Class22.string_1);
			btnVoidOrder.Visible = false;
		}
		else
		{
			new NotificationLabel(this, "Cannot void refunded/voided orders.", NotificationTypes.Warning).Show();
		}
	}

	private void txtSearchInfo_TextChanged(object sender, EventArgs e)
	{
	}

	private void chkAll_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			bool_1 = true;
			if (chkAll.Checked)
			{
				CheckBox checkBox = chkCash;
				CheckBox checkBox2 = chkInterac;
				CheckBox checkBox3 = chkAmex;
				CheckBox checkBox4 = chkVisa;
				CheckBox checkBox5 = chkMasterCard;
				chkOthers.Checked = true;
				checkBox5.Checked = true;
				checkBox4.Checked = true;
				checkBox3.Checked = true;
				checkBox2.Checked = true;
				checkBox.Checked = true;
			}
			else
			{
				CheckBox checkBox6 = chkCash;
				CheckBox checkBox7 = chkInterac;
				CheckBox checkBox8 = chkAmex;
				CheckBox checkBox9 = chkVisa;
				CheckBox checkBox10 = chkMasterCard;
				chkOthers.Checked = false;
				checkBox10.Checked = false;
				checkBox9.Checked = false;
				checkBox8.Checked = false;
				checkBox7.Checked = false;
				checkBox6.Checked = false;
			}
			method_3(string_0);
			bool_1 = false;
		}
	}

	private void btnPullOrder_Click(object sender, EventArgs e)
	{
		if (lstOrderCatering.SelectedItems.Count > 0)
		{
			string orderNumber = lstOrderCatering.SelectedItems[0].Text;
			string text = SyncMethods.SyncTask(new PullOrderPostResponseModel
			{
				token = SyncMethods.GetToken(),
				OrderNumber = orderNumber
			}, "/api/Orders/PullCateringOrders");
			if (text == string.Empty)
			{
				new NotificationLabel(this, "Order successfully pulled.", NotificationTypes.Notification).Show();
			}
			else
			{
				new NotificationLabel(this, text, NotificationTypes.Warning).Show();
			}
		}
		else
		{
			new NotificationLabel(this, "Please select an order to pull", NotificationTypes.Warning).Show();
		}
	}

	private void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
	{
		int_0 = Convert.ToInt32(ddlEmployees.SelectedValue);
		if (!string.IsNullOrEmpty(txtSearchInfo.Text))
		{
			method_3(Class22.string_1);
		}
		else
		{
			method_3(Class22.string_0);
		}
	}

	private void btnRefreshOrders_Click(object sender, EventArgs e)
	{
		bool_0 = false;
		method_3(Class22.string_0);
	}

	private void btnChangeEmpCashout_Click(object sender, EventArgs e)
	{
		if (!tabControl1.SelectedTab.Text.Contains(Resources.Orders) || lstOrders.SelectedItems.Count == 0)
		{
			return;
		}
		Dictionary<DialogResult, string> dictionary = new Dictionary<DialogResult, string>();
		dictionary.Add(DialogResult.Yes, "SERVED");
		dictionary.Add(DialogResult.No, "CASHOUT");
		DialogResult dialogResult = new frmEitherOrSelector("Change Employee", dictionary).ShowDialog(this);
		string text = "Cash Out";
		if (dialogResult == DialogResult.Yes)
		{
			text = "Served";
		}
		bool flag = false;
		do
		{
			frmSelectEmployee frmSelectEmployee2 = new frmSelectEmployee(showBtnClose: true, showNoEmployeeBtn: false, "Change Employee - " + text + ": Select an Employee");
			if (frmSelectEmployee2.ShowDialog(this) == DialogResult.OK)
			{
				_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.orderNumber = lstOrders.SelectedItems[0].Text;
				CS_0024_003C_003E8__locals0.orders = gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).ToList();
				if (CS_0024_003C_003E8__locals0.orders.FirstOrDefault().UserCashout.HasValue)
				{
					Employee employee = gClass.Employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals0.orders.FirstOrDefault().UserCashout.Value).FirstOrDefault();
					DialogResult dialogResult2 = new frmMessageBox("Do you want to change the Employee " + text + " from " + employee.FirstName + " " + employee.LastName + " to " + frmSelectEmployee2.employeeName + "?", "Change Employee Cashout", CustomMessageBoxButtons.YesNoCancel).ShowDialog(this);
					if (dialogResult2 == DialogResult.Yes)
					{
						foreach (Order order in CS_0024_003C_003E8__locals0.orders)
						{
							if (dialogResult == DialogResult.Yes)
							{
								order.UserServed = (short)frmSelectEmployee2.employeeID;
							}
							else
							{
								order.UserCashout = (short)frmSelectEmployee2.employeeID;
							}
						}
						gClass.SubmitChanges();
						method_3(Class22.string_0);
						new NotificationLabel(this, "Employee " + text + " changed.", NotificationTypes.Success).Show();
						flag = true;
					}
					else
					{
						if (dialogResult2 != DialogResult.No)
						{
							continue;
						}
						flag = true;
					}
				}
			}
			flag = true;
		}
		while (!flag);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminViewOrders));
		pnlMain = new Panel();
		btnChangeEmpCashout = new Button();
		btnRefreshOrders = new Button();
		ddlEmployees = new Class19();
		label2 = new Label();
		btnPullOrder = new Button();
		chkAll = new CheckBox();
		btnVoidOrder = new Button();
		btnReprintChit = new Button();
		btnChangePaymentType = new Button();
		chkOthers = new CheckBox();
		chkInterac = new CheckBox();
		chkAmex = new CheckBox();
		chkMasterCard = new CheckBox();
		chkVisa = new CheckBox();
		chkCash = new CheckBox();
		label4 = new Label();
		lblTraining = new Label();
		btnDuplicate = new Button();
		label3 = new Label();
		txtSearchInfo = new RadTextBoxControl();
		btnShowKeyboard_SearchInfo = new Button();
		label1 = new Label();
		btnRefundOrder = new Button();
		btnClose = new Button();
		btnPreview = new Button();
		dateTo = new DateTimePicker();
		btnPrintReceipt = new Button();
		lblDash = new Label();
		dateFrom = new DateTimePicker();
		tabControl1 = new TabControl();
		tabOrdersPage = new TabPage();
		lstOrders = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_20 = new ColumnHeader();
		columnHeader_6 = new ColumnHeader();
		columnHeader_15 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		columnHeader_5 = new ColumnHeader();
		columnHeader_18 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		columnHeader_16 = new ColumnHeader();
		columnHeader_19 = new ColumnHeader();
		columnHeader_12 = new ColumnHeader();
		columnHeader_32 = new ColumnHeader();
		tabRefundsPage = new TabPage();
		lstRefunds = new ListView();
		columnHeader_7 = new ColumnHeader();
		columnHeader_8 = new ColumnHeader();
		columnHeader_9 = new ColumnHeader();
		columnHeader_10 = new ColumnHeader();
		columnHeader_14 = new ColumnHeader();
		columnHeader_13 = new ColumnHeader();
		columnHeader_11 = new ColumnHeader();
		columnHeader_17 = new ColumnHeader();
		columnHeader_42 = new ColumnHeader();
		tabVoidOrdersPage = new TabPage();
		lstVoidOrders = new ListView();
		columnHeader_33 = new ColumnHeader();
		columnHeader_34 = new ColumnHeader();
		columnHeader_35 = new ColumnHeader();
		columnHeader_36 = new ColumnHeader();
		columnHeader_37 = new ColumnHeader();
		columnHeader_38 = new ColumnHeader();
		columnHeader_39 = new ColumnHeader();
		columnHeader_40 = new ColumnHeader();
		columnHeader_41 = new ColumnHeader();
		tabOtherOrdersPage = new TabPage();
		lstOrderCatering = new ListView();
		columnHeader_21 = new ColumnHeader();
		columnHeader_22 = new ColumnHeader();
		columnHeader_23 = new ColumnHeader();
		columnHeader_24 = new ColumnHeader();
		columnHeader_25 = new ColumnHeader();
		columnHeader_26 = new ColumnHeader();
		columnHeader_27 = new ColumnHeader();
		columnHeader_28 = new ColumnHeader();
		columnHeader_29 = new ColumnHeader();
		columnHeader_30 = new ColumnHeader();
		columnHeader_31 = new ColumnHeader();
		label9 = new Label();
		pnlMain.SuspendLayout();
		((ISupportInitialize)txtSearchInfo).BeginInit();
		tabControl1.SuspendLayout();
		tabOrdersPage.SuspendLayout();
		tabRefundsPage.SuspendLayout();
		tabVoidOrdersPage.SuspendLayout();
		tabOtherOrdersPage.SuspendLayout();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlMain, "pnlMain");
		pnlMain.Controls.Add(btnChangeEmpCashout);
		pnlMain.Controls.Add(btnRefreshOrders);
		pnlMain.Controls.Add(ddlEmployees);
		pnlMain.Controls.Add(label2);
		pnlMain.Controls.Add(btnPullOrder);
		pnlMain.Controls.Add(chkAll);
		pnlMain.Controls.Add(btnVoidOrder);
		pnlMain.Controls.Add(btnReprintChit);
		pnlMain.Controls.Add(btnChangePaymentType);
		pnlMain.Controls.Add(chkOthers);
		pnlMain.Controls.Add(chkInterac);
		pnlMain.Controls.Add(chkAmex);
		pnlMain.Controls.Add(chkMasterCard);
		pnlMain.Controls.Add(chkVisa);
		pnlMain.Controls.Add(chkCash);
		pnlMain.Controls.Add(label4);
		pnlMain.Controls.Add(lblTraining);
		pnlMain.Controls.Add(btnDuplicate);
		pnlMain.Controls.Add(label3);
		pnlMain.Controls.Add(txtSearchInfo);
		pnlMain.Controls.Add(btnShowKeyboard_SearchInfo);
		pnlMain.Controls.Add(label1);
		pnlMain.Controls.Add(btnRefundOrder);
		pnlMain.Controls.Add(btnClose);
		pnlMain.Controls.Add(btnPreview);
		pnlMain.Controls.Add(dateTo);
		pnlMain.Controls.Add(btnPrintReceipt);
		pnlMain.Controls.Add(lblDash);
		pnlMain.Controls.Add(dateFrom);
		pnlMain.Controls.Add(tabControl1);
		pnlMain.Name = "pnlMain";
		componentResourceManager.ApplyResources(btnChangeEmpCashout, "btnChangeEmpCashout");
		btnChangeEmpCashout.BackColor = Color.FromArgb(42, 102, 134);
		btnChangeEmpCashout.DialogResult = DialogResult.OK;
		btnChangeEmpCashout.FlatAppearance.BorderColor = Color.Black;
		btnChangeEmpCashout.FlatAppearance.BorderSize = 0;
		btnChangeEmpCashout.ForeColor = Color.White;
		btnChangeEmpCashout.Name = "btnChangeEmpCashout";
		btnChangeEmpCashout.UseVisualStyleBackColor = false;
		btnChangeEmpCashout.Click += btnChangeEmpCashout_Click;
		componentResourceManager.ApplyResources(btnRefreshOrders, "btnRefreshOrders");
		btnRefreshOrders.BackColor = Color.FromArgb(77, 174, 225);
		btnRefreshOrders.FlatAppearance.BorderColor = Color.White;
		btnRefreshOrders.FlatAppearance.BorderSize = 0;
		btnRefreshOrders.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnRefreshOrders.ForeColor = Color.White;
		btnRefreshOrders.Name = "btnRefreshOrders";
		btnRefreshOrders.UseVisualStyleBackColor = false;
		btnRefreshOrders.Click += btnRefreshOrders_Click;
		ddlEmployees.DrawMode = DrawMode.OwnerDrawVariable;
		ddlEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlEmployees, "ddlEmployees");
		ddlEmployees.Name = "ddlEmployees";
		ddlEmployees.SelectedIndexChanged += ddlEmployees_SelectedIndexChanged;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(btnPullOrder, "btnPullOrder");
		btnPullOrder.BackColor = Color.FromArgb(80, 203, 116);
		btnPullOrder.FlatAppearance.BorderColor = Color.White;
		btnPullOrder.FlatAppearance.BorderSize = 0;
		btnPullOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnPullOrder.ForeColor = Color.White;
		btnPullOrder.Name = "btnPullOrder";
		btnPullOrder.UseVisualStyleBackColor = false;
		btnPullOrder.Click += btnPullOrder_Click;
		chkAll.BackColor = Color.Silver;
		chkAll.Checked = true;
		chkAll.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkAll, "chkAll");
		chkAll.ForeColor = Color.Black;
		chkAll.Name = "chkAll";
		chkAll.UseVisualStyleBackColor = false;
		chkAll.CheckedChanged += chkAll_CheckedChanged;
		componentResourceManager.ApplyResources(btnVoidOrder, "btnVoidOrder");
		btnVoidOrder.BackColor = Color.FromArgb(235, 107, 86);
		btnVoidOrder.FlatAppearance.BorderColor = Color.White;
		btnVoidOrder.FlatAppearance.BorderSize = 0;
		btnVoidOrder.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnVoidOrder.ForeColor = Color.White;
		btnVoidOrder.Name = "btnVoidOrder";
		btnVoidOrder.UseVisualStyleBackColor = false;
		btnVoidOrder.Click += btnVoidOrder_Click;
		componentResourceManager.ApplyResources(btnReprintChit, "btnReprintChit");
		btnReprintChit.BackColor = Color.SandyBrown;
		btnReprintChit.FlatAppearance.BorderColor = Color.White;
		btnReprintChit.FlatAppearance.BorderSize = 0;
		btnReprintChit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnReprintChit.ForeColor = Color.White;
		btnReprintChit.Name = "btnReprintChit";
		btnReprintChit.UseVisualStyleBackColor = false;
		btnReprintChit.Click += btnReprintChit_Click;
		componentResourceManager.ApplyResources(btnChangePaymentType, "btnChangePaymentType");
		btnChangePaymentType.BackColor = Color.FromArgb(71, 132, 165);
		btnChangePaymentType.DialogResult = DialogResult.OK;
		btnChangePaymentType.FlatAppearance.BorderColor = Color.Black;
		btnChangePaymentType.FlatAppearance.BorderSize = 0;
		btnChangePaymentType.ForeColor = Color.White;
		btnChangePaymentType.Name = "btnChangePaymentType";
		btnChangePaymentType.UseVisualStyleBackColor = false;
		btnChangePaymentType.Click += btnChangePaymentType_Click;
		componentResourceManager.ApplyResources(chkOthers, "chkOthers");
		chkOthers.BackColor = Color.LightGray;
		chkOthers.Checked = true;
		chkOthers.CheckState = CheckState.Checked;
		chkOthers.ForeColor = Color.Black;
		chkOthers.Name = "chkOthers";
		chkOthers.UseVisualStyleBackColor = false;
		chkOthers.CheckedChanged += chkCash_CheckedChanged;
		chkInterac.BackColor = Color.LightGray;
		chkInterac.Checked = true;
		chkInterac.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkInterac, "chkInterac");
		chkInterac.ForeColor = Color.Black;
		chkInterac.Name = "chkInterac";
		chkInterac.UseVisualStyleBackColor = false;
		chkInterac.CheckedChanged += chkCash_CheckedChanged;
		chkAmex.BackColor = Color.LightGray;
		chkAmex.Checked = true;
		chkAmex.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkAmex, "chkAmex");
		chkAmex.ForeColor = Color.Black;
		chkAmex.Name = "chkAmex";
		chkAmex.UseVisualStyleBackColor = false;
		chkAmex.CheckedChanged += chkCash_CheckedChanged;
		chkMasterCard.BackColor = Color.LightGray;
		chkMasterCard.Checked = true;
		chkMasterCard.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkMasterCard, "chkMasterCard");
		chkMasterCard.ForeColor = Color.Black;
		chkMasterCard.Name = "chkMasterCard";
		chkMasterCard.UseVisualStyleBackColor = false;
		chkMasterCard.CheckedChanged += chkCash_CheckedChanged;
		chkVisa.BackColor = Color.LightGray;
		chkVisa.Checked = true;
		chkVisa.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkVisa, "chkVisa");
		chkVisa.ForeColor = Color.Black;
		chkVisa.Name = "chkVisa";
		chkVisa.UseVisualStyleBackColor = false;
		chkVisa.CheckedChanged += chkCash_CheckedChanged;
		chkCash.BackColor = Color.LightGray;
		chkCash.Checked = true;
		chkCash.CheckState = CheckState.Checked;
		componentResourceManager.ApplyResources(chkCash, "chkCash");
		chkCash.ForeColor = Color.Black;
		chkCash.Name = "chkCash";
		chkCash.UseVisualStyleBackColor = false;
		chkCash.CheckedChanged += chkCash_CheckedChanged;
		label4.BackColor = Color.DarkGray;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.Black;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(lblTraining, "lblTraining");
		lblTraining.BackColor = Color.FromArgb(193, 57, 43);
		lblTraining.BorderStyle = BorderStyle.FixedSingle;
		lblTraining.ForeColor = Color.White;
		lblTraining.Name = "lblTraining";
		componentResourceManager.ApplyResources(btnDuplicate, "btnDuplicate");
		btnDuplicate.BackColor = Color.FromArgb(176, 124, 219);
		btnDuplicate.DialogResult = DialogResult.OK;
		btnDuplicate.FlatAppearance.BorderColor = Color.Black;
		btnDuplicate.FlatAppearance.BorderSize = 0;
		btnDuplicate.ForeColor = Color.White;
		btnDuplicate.Name = "btnDuplicate";
		btnDuplicate.UseVisualStyleBackColor = false;
		btnDuplicate.EnabledChanged += btnDuplicate_EnabledChanged;
		btnDuplicate.Click += btnDuplicate_Click;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtSearchInfo, "txtSearchInfo");
		txtSearchInfo.ForeColor = Color.FromArgb(40, 40, 40);
		txtSearchInfo.Name = "txtSearchInfo";
		txtSearchInfo.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSearchInfo.TextChanged += txtSearchInfo_TextChanged;
		txtSearchInfo.Click += txtSearchInfo_Click;
		txtSearchInfo.KeyUp += txtSearchInfo_KeyUp;
		((RadTextBoxControlElement)txtSearchInfo.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSearchInfo.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_SearchInfo.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SearchInfo.DialogResult = DialogResult.OK;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SearchInfo.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SearchInfo, "btnShowKeyboard_SearchInfo");
		btnShowKeyboard_SearchInfo.ForeColor = Color.White;
		btnShowKeyboard_SearchInfo.Name = "btnShowKeyboard_SearchInfo";
		btnShowKeyboard_SearchInfo.UseVisualStyleBackColor = false;
		btnShowKeyboard_SearchInfo.Click += btnShowKeyboard_SearchInfo_Click;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(btnRefundOrder, "btnRefundOrder");
		btnRefundOrder.BackColor = Color.SandyBrown;
		btnRefundOrder.DialogResult = DialogResult.OK;
		btnRefundOrder.FlatAppearance.BorderColor = Color.Black;
		btnRefundOrder.FlatAppearance.BorderSize = 0;
		btnRefundOrder.ForeColor = Color.White;
		btnRefundOrder.Name = "btnRefundOrder";
		btnRefundOrder.UseVisualStyleBackColor = false;
		btnRefundOrder.EnabledChanged += btnRefundOrder_EnabledChanged;
		btnRefundOrder.Click += btnRefundOrder_Click;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(btnPreview, "btnPreview");
		btnPreview.BackColor = Color.FromArgb(80, 203, 116);
		btnPreview.DialogResult = DialogResult.OK;
		btnPreview.FlatAppearance.BorderColor = Color.Black;
		btnPreview.FlatAppearance.BorderSize = 0;
		btnPreview.ForeColor = Color.White;
		btnPreview.Name = "btnPreview";
		btnPreview.UseVisualStyleBackColor = false;
		btnPreview.Click += btnPreview_Click;
		componentResourceManager.ApplyResources(dateTo, "dateTo");
		dateTo.Format = DateTimePickerFormat.Short;
		dateTo.Name = "dateTo";
		dateTo.ValueChanged += dateTo_ValueChanged;
		dateTo.MouseDown += dateFrom_MouseDown;
		componentResourceManager.ApplyResources(btnPrintReceipt, "btnPrintReceipt");
		btnPrintReceipt.BackColor = Color.FromArgb(77, 174, 225);
		btnPrintReceipt.DialogResult = DialogResult.OK;
		btnPrintReceipt.FlatAppearance.BorderColor = Color.Black;
		btnPrintReceipt.FlatAppearance.BorderSize = 0;
		btnPrintReceipt.ForeColor = Color.White;
		btnPrintReceipt.Name = "btnPrintReceipt";
		btnPrintReceipt.UseVisualStyleBackColor = false;
		btnPrintReceipt.Click += btnPrintReceipt_Click;
		componentResourceManager.ApplyResources(lblDash, "lblDash");
		lblDash.ForeColor = Color.White;
		lblDash.Name = "lblDash";
		componentResourceManager.ApplyResources(dateFrom, "dateFrom");
		dateFrom.Format = DateTimePickerFormat.Short;
		dateFrom.Name = "dateFrom";
		dateFrom.ValueChanged += dateFrom_ValueChanged;
		dateFrom.MouseDown += dateFrom_MouseDown;
		componentResourceManager.ApplyResources(tabControl1, "tabControl1");
		tabControl1.Controls.Add(tabOrdersPage);
		tabControl1.Controls.Add(tabRefundsPage);
		tabControl1.Controls.Add(tabVoidOrdersPage);
		tabControl1.Controls.Add(tabOtherOrdersPage);
		tabControl1.Multiline = true;
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.SizeMode = TabSizeMode.Fixed;
		tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
		tabOrdersPage.Controls.Add(lstOrders);
		componentResourceManager.ApplyResources(tabOrdersPage, "tabOrdersPage");
		tabOrdersPage.Name = "tabOrdersPage";
		tabOrdersPage.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(lstOrders, "lstOrders");
		lstOrders.BackColor = Color.White;
		lstOrders.BorderStyle = BorderStyle.FixedSingle;
		lstOrders.Columns.AddRange(new ColumnHeader[14]
		{
			columnHeader_0, columnHeader_20, columnHeader_6, columnHeader_15, columnHeader_1, columnHeader_2, columnHeader_3, columnHeader_5, columnHeader_18, columnHeader_4,
			columnHeader_16, columnHeader_19, columnHeader_12, columnHeader_32
		});
		lstOrders.FullRowSelect = true;
		lstOrders.GridLines = true;
		lstOrders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstOrders.HideSelection = false;
		lstOrders.MultiSelect = false;
		lstOrders.Name = "lstOrders";
		lstOrders.TileSize = new Size(50, 200);
		lstOrders.UseCompatibleStateImageBehavior = false;
		lstOrders.View = View.Details;
		lstOrders.SelectedIndexChanged += lstOrders_SelectedIndexChanged;
		lstOrders.MouseDoubleClick += lstOrders_MouseDoubleClick;
		componentResourceManager.ApplyResources(columnHeader_0, "OrderNumber");
		componentResourceManager.ApplyResources(columnHeader_20, "OrderTicket");
		componentResourceManager.ApplyResources(columnHeader_6, "DatePaid");
		componentResourceManager.ApplyResources(columnHeader_15, "Subtotal");
		componentResourceManager.ApplyResources(columnHeader_1, "Discount");
		componentResourceManager.ApplyResources(columnHeader_2, "Tax");
		componentResourceManager.ApplyResources(columnHeader_3, "Total");
		componentResourceManager.ApplyResources(columnHeader_5, "PaymentType");
		componentResourceManager.ApplyResources(columnHeader_18, "TipAmount");
		componentResourceManager.ApplyResources(columnHeader_4, "Refund");
		componentResourceManager.ApplyResources(columnHeader_16, "OrderType");
		componentResourceManager.ApplyResources(columnHeader_19, "CustomerInfo");
		componentResourceManager.ApplyResources(columnHeader_12, "DiscountReason");
		componentResourceManager.ApplyResources(columnHeader_32, "ServedBy");
		tabRefundsPage.Controls.Add(lstRefunds);
		componentResourceManager.ApplyResources(tabRefundsPage, "tabRefundsPage");
		tabRefundsPage.Name = "tabRefundsPage";
		tabRefundsPage.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(lstRefunds, "lstRefunds");
		lstRefunds.BorderStyle = BorderStyle.FixedSingle;
		lstRefunds.Columns.AddRange(new ColumnHeader[9] { columnHeader_7, columnHeader_8, columnHeader_9, columnHeader_10, columnHeader_14, columnHeader_13, columnHeader_11, columnHeader_17, columnHeader_42 });
		lstRefunds.FullRowSelect = true;
		lstRefunds.GridLines = true;
		lstRefunds.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstRefunds.HideSelection = false;
		lstRefunds.MultiSelect = false;
		lstRefunds.Name = "lstRefunds";
		lstRefunds.TileSize = new Size(50, 200);
		lstRefunds.UseCompatibleStateImageBehavior = false;
		lstRefunds.View = View.Details;
		lstRefunds.MouseDoubleClick += lstRefunds_MouseDoubleClick;
		componentResourceManager.ApplyResources(columnHeader_7, "columnHeader1");
		componentResourceManager.ApplyResources(columnHeader_8, "columnHeader4");
		componentResourceManager.ApplyResources(columnHeader_9, "columnHeader5");
		componentResourceManager.ApplyResources(columnHeader_10, "columnHeader8");
		componentResourceManager.ApplyResources(columnHeader_14, "columnHeader3");
		componentResourceManager.ApplyResources(columnHeader_13, "columnHeader2");
		componentResourceManager.ApplyResources(columnHeader_11, "columnHeader9");
		componentResourceManager.ApplyResources(columnHeader_17, "columnHeader6");
		componentResourceManager.ApplyResources(columnHeader_42, "RefundedBy");
		tabVoidOrdersPage.Controls.Add(lstVoidOrders);
		componentResourceManager.ApplyResources(tabVoidOrdersPage, "tabVoidOrdersPage");
		tabVoidOrdersPage.Name = "tabVoidOrdersPage";
		tabVoidOrdersPage.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(lstVoidOrders, "lstVoidOrders");
		lstVoidOrders.BackColor = Color.White;
		lstVoidOrders.BorderStyle = BorderStyle.FixedSingle;
		lstVoidOrders.Columns.AddRange(new ColumnHeader[9] { columnHeader_33, columnHeader_34, columnHeader_35, columnHeader_36, columnHeader_37, columnHeader_38, columnHeader_39, columnHeader_40, columnHeader_41 });
		lstVoidOrders.FullRowSelect = true;
		lstVoidOrders.GridLines = true;
		lstVoidOrders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstVoidOrders.HideSelection = false;
		lstVoidOrders.MultiSelect = false;
		lstVoidOrders.Name = "lstVoidOrders";
		lstVoidOrders.TileSize = new Size(50, 200);
		lstVoidOrders.UseCompatibleStateImageBehavior = false;
		lstVoidOrders.View = View.Details;
		lstVoidOrders.MouseDoubleClick += lstVoidOrders_MouseDoubleClick;
		componentResourceManager.ApplyResources(columnHeader_33, "columnHeader10");
		componentResourceManager.ApplyResources(columnHeader_34, "columnHeader22");
		componentResourceManager.ApplyResources(columnHeader_35, "columnHeader23");
		componentResourceManager.ApplyResources(columnHeader_36, "columnHeader25");
		componentResourceManager.ApplyResources(columnHeader_37, "columnHeader26");
		componentResourceManager.ApplyResources(columnHeader_38, "columnHeader30");
		componentResourceManager.ApplyResources(columnHeader_39, "columnHeader31");
		componentResourceManager.ApplyResources(columnHeader_40, "columnHeader32");
		componentResourceManager.ApplyResources(columnHeader_41, "columnHeader33");
		tabOtherOrdersPage.Controls.Add(lstOrderCatering);
		componentResourceManager.ApplyResources(tabOtherOrdersPage, "tabOtherOrdersPage");
		tabOtherOrdersPage.Name = "tabOtherOrdersPage";
		tabOtherOrdersPage.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(lstOrderCatering, "lstOrderCatering");
		lstOrderCatering.BackColor = Color.White;
		lstOrderCatering.BorderStyle = BorderStyle.FixedSingle;
		lstOrderCatering.Columns.AddRange(new ColumnHeader[11]
		{
			columnHeader_21, columnHeader_22, columnHeader_23, columnHeader_24, columnHeader_25, columnHeader_26, columnHeader_27, columnHeader_28, columnHeader_29, columnHeader_30,
			columnHeader_31
		});
		lstOrderCatering.FullRowSelect = true;
		lstOrderCatering.GridLines = true;
		lstOrderCatering.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstOrderCatering.HideSelection = false;
		lstOrderCatering.MultiSelect = false;
		lstOrderCatering.Name = "lstOrderCatering";
		lstOrderCatering.TileSize = new Size(50, 200);
		lstOrderCatering.UseCompatibleStateImageBehavior = false;
		lstOrderCatering.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_21, "columnHeader7");
		componentResourceManager.ApplyResources(columnHeader_22, "columnHeader11");
		componentResourceManager.ApplyResources(columnHeader_23, "columnHeader12");
		componentResourceManager.ApplyResources(columnHeader_24, "columnHeader13");
		componentResourceManager.ApplyResources(columnHeader_25, "columnHeader14");
		componentResourceManager.ApplyResources(columnHeader_26, "columnHeader15");
		componentResourceManager.ApplyResources(columnHeader_27, "columnHeader16");
		componentResourceManager.ApplyResources(columnHeader_28, "columnHeader17");
		componentResourceManager.ApplyResources(columnHeader_29, "columnHeader19");
		componentResourceManager.ApplyResources(columnHeader_30, "columnHeader20");
		componentResourceManager.ApplyResources(columnHeader_31, "columnHeader21");
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(pnlMain);
		base.Controls.Add(label9);
		base.Name = "frmAdminViewOrders";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmAdminViewOrders_Load;
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(pnlMain, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		pnlMain.ResumeLayout(performLayout: false);
		pnlMain.PerformLayout();
		((ISupportInitialize)txtSearchInfo).EndInit();
		tabControl1.ResumeLayout(performLayout: false);
		tabOrdersPage.ResumeLayout(performLayout: false);
		tabRefundsPage.ResumeLayout(performLayout: false);
		tabVoidOrdersPage.ResumeLayout(performLayout: false);
		tabOtherOrdersPage.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_8(Employee employee_0)
	{
		return employee_0.EmployeeID == int_0;
	}
}
