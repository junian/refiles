using System;
using System.Collections.Generic;
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

namespace CorePOS;

public class frmAdminReports : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public DateTime start;

		public DateTime end;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public DateTime openingTime;

		public DateTime closingTime;

		public _003C_003Ec__DisplayClass7_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public KeyValuePair<string, string> item;

		public _003C_003Ec__DisplayClass13_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public string groupname;

		public Group parentGroup;

		public List<string> groupNames;

		public _003C_003Ec__DisplayClass13_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadOrders_003Eb__1(Group a)
		{
			return a.GroupName.ToUpper() == groupname.ToUpper();
		}

		internal bool _003CLoadOrders_003Eb__3(Group a)
		{
			return a.ParentGroupID == parentGroup.GroupID;
		}
	}

	private GClass6 TokFvWgrMaE;

	private frmReport frmReport_0;

	private ChartObject chartObject_0;

	private IContainer icontainer_1;

	private Class19 ddlFilters;

	private Label label2;

	private Panel panel1;

	private Label lblTrainingMode;

	private Label label1;

	private Class19 listItems;

	internal Button btnClose;

	private Class19 listGroup;

	private Label label3;

	private Label label4;

	private Label label10;

	public frmAdminReports()
	{
		Class26.Ggkj0JxzN9YmC();
		TokFvWgrMaE = new GClass6();
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		if (Screen.PrimaryScreen.Bounds.Height <= 600)
		{
			base.WindowState = FormWindowState.Maximized;
		}
		else
		{
			base.WindowState = FormWindowState.Normal;
		}
		Dictionary<int, string> dictionary = new Dictionary<int, string>
		{
			{
				1,
				Resources.Today
			},
			{
				2,
				Resources.This_Week
			},
			{
				3,
				Resources.Last_Week
			},
			{
				4,
				Resources.This_Month
			}
		};
		for (int i = 0; i < 12; i++)
		{
			dictionary.Add(i + 5, new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-1 - i).Month).ToString() + " " + DateTime.Now.AddMonths(-1 - i).Year);
		}
		ddlFilters.DisplayMember = "Value";
		ddlFilters.ValueMember = "Key";
		ddlFilters.DataSource = new BindingSource(dictionary, null);
		ddlFilters.SelectedIndex = 0;
		Dictionary<string, string> groups = AdminMethods.getGroups();
		listGroup.DisplayMember = "Value";
		listGroup.ValueMember = "Key";
		listGroup.DataSource = new BindingSource(groups, null);
		listGroup.SelectedIndex = 0;
		List<Item> allItems = AdminMethods.getAllItems(ItemClassifications.Product);
		Dictionary<string, string> dictionary2 = new Dictionary<string, string> { { "0", "*All Items*" } };
		foreach (Item item in allItems)
		{
			dictionary2.Add(item.ItemID.ToString(), item.ItemName);
		}
		listItems.DisplayMember = "Value";
		listItems.ValueMember = "Key";
		listItems.DataSource = new BindingSource(dictionary2, null);
	}

	private void frmAdminReports_Load(object sender, EventArgs e)
	{
	}

	private void wByFwqdFigJ(object sender, EventArgs e)
	{
		if (ddlFilters.SelectedIndex > -1 && listGroup.SelectedIndex > -1)
		{
			method_7();
		}
	}

	private void method_3()
	{
		if (ddlFilters.SelectedIndex != -1)
		{
			int num = Convert.ToInt32(ddlFilters.SelectedValue.ToString().Split(',')[0].ToString().Replace("[", string.Empty));
			List<ChartTotal> list_ = method_5(method_4(num));
			switch (num)
			{
			case 1:
				method_6(list_, Resources.Sales_Report_For_Today);
				break;
			case 2:
				method_6(list_, Resources.Sales_Report_For_This_Week);
				break;
			case 3:
				method_6(list_, Resources.Sales_Report_For_Last_Week);
				break;
			case 4:
				method_6(list_, Resources.Sales_Report_For_This_Month);
				break;
			case 5:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-1).Month).ToString());
				break;
			case 6:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-2).Month).ToString());
				break;
			case 7:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-3).Month).ToString());
				break;
			case 8:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-4).Month).ToString());
				break;
			case 9:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-5).Month).ToString());
				break;
			case 10:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-6).Month).ToString());
				break;
			case 11:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-7).Month).ToString());
				break;
			case 12:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-8).Month).ToString());
				break;
			case 13:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-9).Month).ToString());
				break;
			case 14:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-10).Month).ToString());
				break;
			case 15:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-11).Month).ToString());
				break;
			case 16:
				method_6(list_, Resources.Sales_Report_For + new DateTimeFormatInfo().GetMonthName(DateTime.Now.AddMonths(-12).Month).ToString());
				break;
			}
		}
	}

	private List<Order> method_4(int int_0, IQueryable<Order> iqueryable_0 = null)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		TokFvWgrMaE = new GClass6();
		_003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_1();
		switch (int_0)
		{
		default:
			return TokFvWgrMaE.Orders.ToList();
		case 1:
			CS_0024_003C_003E8__locals1.openingTime = DateTime.Now.Date;
			CS_0024_003C_003E8__locals1.closingTime = DateTime.Now;
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value >= CS_0024_003C_003E8__locals1.openingTime && o.DatePaid.Value <= CS_0024_003C_003E8__locals1.closingTime && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value >= CS_0024_003C_003E8__locals1.openingTime && o.DatePaid.Value <= CS_0024_003C_003E8__locals1.closingTime && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 2:
			CS_0024_003C_003E8__locals0.start = DateTime.Now.AddDays((DateTime.Now.DayOfWeek == DayOfWeek.Sunday) ? (-7) : (0 - DateTime.Now.DayOfWeek)).Date;
			CS_0024_003C_003E8__locals0.end = DateTime.Now;
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Date >= CS_0024_003C_003E8__locals0.start && o.DatePaid <= CS_0024_003C_003E8__locals0.end && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Date >= CS_0024_003C_003E8__locals0.start && o.DatePaid <= CS_0024_003C_003E8__locals0.end && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 3:
			CS_0024_003C_003E8__locals0.start = DateTime.Now.AddDays((DateTime.Now.DayOfWeek == DayOfWeek.Sunday) ? (-7) : (0 - DateTime.Now.DayOfWeek)).AddDays(-7.0).Date;
			CS_0024_003C_003E8__locals0.end = CS_0024_003C_003E8__locals0.start.AddDays(6.0);
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Date >= ((DateTime)CS_0024_003C_003E8__locals0.start).Date && o.DatePaid.Value.Date <= ((DateTime)CS_0024_003C_003E8__locals0.end).Date && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Date >= ((DateTime)CS_0024_003C_003E8__locals0.start).Date && o.DatePaid.Value.Date <= ((DateTime)CS_0024_003C_003E8__locals0.end).Date && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 4:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.Month && o.DatePaid.Value.Year == DateTime.Now.Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.Month && o.DatePaid.Value.Year == DateTime.Now.Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 5:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-1).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-1).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-1).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-1).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 6:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-2).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-2).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-2).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-2).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 7:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-3).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-3).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-3).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-3).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 8:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-4).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-4).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-4).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-4).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 9:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-5).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-5).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-5).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-5).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 10:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-6).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-6).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-6).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-6).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 11:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-7).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-7).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-7).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-7).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 12:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-8).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-8).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-8).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-8).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 13:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-9).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-9).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-9).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-9).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 14:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-10).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-10).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-10).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-10).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 15:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-11).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-11).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-11).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-11).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		case 16:
			if (iqueryable_0 == null)
			{
				return (from o in TokFvWgrMaE.Orders
					where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-12).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-12).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
					orderby o.DatePaid
					select o).ToList();
			}
			return (from o in iqueryable_0
				where o.DatePaid.Value.Month == DateTime.Now.AddMonths(-12).Month && o.DatePaid.Value.Year == DateTime.Now.AddMonths(-12).Year && o.Paid == true && o.Void == false && o.DateRefunded == null
				orderby o.DatePaid
				select o).ToList();
		}
	}

	private List<ChartTotal> method_5(List<Order> list_2, bool bool_0 = true)
	{
		if (bool_0)
		{
			return (from a in list_2
				where !a.Void && a.DatePaid.HasValue
				select a into g
				group g by g.DatePaid.Value.Date into o
				select new ChartTotal
				{
					Label = o.First().DatePaid.Value.ToShortDateString(),
					dt = o.First().DatePaid.Value.Date,
					SubTotal = o.Sum((Order s) => s.SubTotal),
					TaxTotal = o.Sum((Order tx) => tx.TaxTotal),
					Total = o.Sum((Order t) => t.Total)
				}).ToList();
		}
		return (from a in list_2
			where !a.Void && a.DatePaid.HasValue
			select a into g
			group g by g.DatePaid.Value.Hour into o
			select new ChartTotal
			{
				Label = o.First().DatePaid.Value.ToString("hh:00 tt"),
				dt = o.First().DatePaid.Value,
				hour = o.First().DatePaid.Value.Hour,
				SubTotal = o.Sum((Order s) => s.SubTotal),
				TaxTotal = o.Sum((Order tx) => tx.TaxTotal),
				Total = o.Sum((Order t) => t.Total)
			} into o
			orderby o.hour
			select o).ToList();
	}

	private void method_6(List<ChartTotal> list_2, string string_0)
	{
		if (chartObject_0 != null)
		{
			chartObject_0 = null;
		}
		if (frmReport_0 != null)
		{
			frmReport_0 = null;
		}
		GC.Collect();
		chartObject_0 = new ChartObject();
		chartObject_0.title = string_0;
		chartObject_0.totals = list_2;
		panel1.Controls.Clear();
		frmReport_0 = new frmReport("CorePOS.Reports.SalesReport.rdlc", ReportTypes.SalesChart, chartObject_0);
		frmReport_0.TopLevel = false;
		panel1.Controls.Add(frmReport_0);
		frmReport_0.FormBorderStyle = FormBorderStyle.None;
		frmReport_0.Dock = DockStyle.Fill;
		frmReport_0.Show();
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		AuthMethods.LogOutUser();
		chartObject_0 = null;
		frmReport_0.Dispose();
		TokFvWgrMaE.Dispose();
		Close();
		Dispose();
	}

	private void listItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listItems.SelectedIndex != 0 || listGroup.SelectedIndex == 0)
		{
			method_7("item");
		}
	}

	private void method_7(string string_0 = "none")
	{
		if ((listItems.SelectedIndex != 0 || listGroup.SelectedIndex != 0) && listItems.Items.Count != 0 && listGroup.Items.Count != 0)
		{
			if (!(string_0 == "item") && (listItems.SelectedIndex == 0 || listGroup.SelectedIndex != 0))
			{
				if (!(string_0 == "group") && (listItems.SelectedIndex != 0 || listGroup.SelectedIndex == 0))
				{
					method_3();
					return;
				}
				_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass13_1();
				KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)listGroup.SelectedItem;
				listItems.SelectedIndex = 0;
				CS_0024_003C_003E8__locals1.groupname = keyValuePair.Value.Replace("  - ", string.Empty).Replace(" - ", string.Empty);
				CS_0024_003C_003E8__locals1.groupname = CS_0024_003C_003E8__locals1.groupname.Replace("  -- ", string.Empty).Replace(" -- ", string.Empty);
				CS_0024_003C_003E8__locals1.groupname = CS_0024_003C_003E8__locals1.groupname.Replace("  --- ", string.Empty).Replace(" --- ", string.Empty);
				CS_0024_003C_003E8__locals1.groupname = CS_0024_003C_003E8__locals1.groupname.Replace("  ---- ", string.Empty).Replace(" ---- ", string.Empty);
				CS_0024_003C_003E8__locals1.groupNames = new List<string>();
				CS_0024_003C_003E8__locals1.groupNames.Add(CS_0024_003C_003E8__locals1.groupname);
				CS_0024_003C_003E8__locals1.parentGroup = MemoryLoadedObjects.all_groups.Where((Group a) => a.GroupName.ToUpper() == CS_0024_003C_003E8__locals1.groupname.ToUpper()).FirstOrDefault();
				if (CS_0024_003C_003E8__locals1.parentGroup != null)
				{
					foreach (Group item in MemoryLoadedObjects.all_groups.Where((Group a) => a.ParentGroupID == CS_0024_003C_003E8__locals1.parentGroup.GroupID).ToList())
					{
						CS_0024_003C_003E8__locals1.groupNames.Add(item.GroupName);
					}
				}
				IQueryable<Order> iqueryable_ = TokFvWgrMaE.Orders.Where((Order g) => CS_0024_003C_003E8__locals1.groupNames.Contains(g.GroupName));
				int int_ = Convert.ToInt32(ddlFilters.SelectedValue.ToString().Split(',')[0].ToString().Replace("[", string.Empty));
				List<ChartTotal> list_ = method_5(method_4(int_, iqueryable_));
				method_6(list_, "Report for Group " + keyValuePair.Value);
			}
			else
			{
				_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
				CS_0024_003C_003E8__locals0.item = (KeyValuePair<string, string>)listItems.SelectedItem;
				listGroup.SelectedIndex = 0;
				IQueryable<Order> iqueryable_2 = TokFvWgrMaE.Orders.Where((Order i) => i.ItemID == Convert.ToInt32(((KeyValuePair<string, string>)CS_0024_003C_003E8__locals0.item).Key) && i.SubTotal > 0m);
				int int_2 = Convert.ToInt32(ddlFilters.SelectedValue.ToString().Split(',')[0].ToString().Replace("[", string.Empty));
				List<ChartTotal> list_2 = method_5(method_4(int_2, iqueryable_2));
				method_6(list_2, Resources.Report_of_item + CS_0024_003C_003E8__locals0.item.Value);
			}
		}
		else
		{
			method_3();
		}
	}

	private void listGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listGroup.SelectedIndex != 0 || listItems.SelectedIndex == 0)
		{
			method_7("group");
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminReports));
		label10 = new Label();
		label4 = new Label();
		label3 = new Label();
		btnClose = new Button();
		label1 = new Label();
		label2 = new Label();
		lblTrainingMode = new Label();
		panel1 = new Panel();
		listGroup = new Class19();
		listItems = new Class19();
		ddlFilters = new Class19();
		SuspendLayout();
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		panel1.Paint += panel1_Paint;
		componentResourceManager.ApplyResources(listGroup, "listGroup");
		listGroup.DrawMode = DrawMode.OwnerDrawVariable;
		listGroup.DropDownHeight = 300;
		listGroup.DropDownStyle = ComboBoxStyle.DropDownList;
		listGroup.FormattingEnabled = true;
		listGroup.Name = "listGroup";
		listGroup.SelectedIndexChanged += listGroup_SelectedIndexChanged;
		componentResourceManager.ApplyResources(listItems, "listItems");
		listItems.DrawMode = DrawMode.OwnerDrawVariable;
		listItems.DropDownHeight = 300;
		listItems.DropDownStyle = ComboBoxStyle.DropDownList;
		listItems.FormattingEnabled = true;
		listItems.Name = "listItems";
		listItems.SelectedIndexChanged += listItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(ddlFilters, "ddlFilters");
		ddlFilters.DrawMode = DrawMode.OwnerDrawVariable;
		ddlFilters.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlFilters.FormattingEnabled = true;
		ddlFilters.Name = "ddlFilters";
		ddlFilters.SelectedIndexChanged += wByFwqdFigJ;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(label10);
		base.Controls.Add(label4);
		base.Controls.Add(listGroup);
		base.Controls.Add(label3);
		base.Controls.Add(btnClose);
		base.Controls.Add(listItems);
		base.Controls.Add(label1);
		base.Controls.Add(label2);
		base.Controls.Add(ddlFilters);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(panel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminReports";
		base.Opacity = 1.0;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.Load += frmAdminReports_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
