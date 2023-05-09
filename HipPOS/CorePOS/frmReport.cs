using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
using Microsoft.Reporting.WinForms;

namespace CorePOS;

public class frmReport : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int empID;

		public int cashierID;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadReport_003Eb__3(Employee e)
		{
			return e.EmployeeID == empID;
		}

		internal bool _003CLoadReport_003Eb__4(Employee e)
		{
			return e.EmployeeID == cashierID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public Employee emp;

		public _003C_003Ec__DisplayClass12_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CLoadReport_003Eb__28(Order a)
		{
			return a.UserServed == emp.EmployeeID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public string empName;

		public _003C_003Ec__DisplayClass12_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal DeliveryCommissionObject _003CLoadReport_003Eb__30(IGrouping<string, Order> a)
		{
			return new DeliveryCommissionObject
			{
				OrderNumber = a.Key,
				EmployeeName = empName,
				SubTotal = a.Sum((Order x) => x.SubTotal)
			};
		}
	}

	private GClass6 gclass6_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private int int_0;

	private int int_1;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private ChartObject chartObject_0;

	private IContainer icontainer_1;

	private ReportViewer reportViewer1;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	public frmReport(string param, string report_type, ChartObject _chartObject = null, int _EmployeeId = 0, int _TerminalId = -1)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		int_1 = -1;
		// base._002Ector();
		InitializeComponent_1();
		base.TopLevel = true;
		base.TopMost = true;
		string_2 = report_type;
		if (!(string_2 == ReportTypes.Orders) && !(string_2 == ReportTypes.Refunds))
		{
			if (!(string_2 == ReportTypes.DayEndClosing) && !(string_2 == ReportTypes.DeliveryCommission) && !(string_2 == ReportTypes.DeliveryDrivers))
			{
				string_1 = param;
				chartObject_0 = _chartObject;
				return;
			}
			dateTime_1 = Convert.ToDateTime(param.Split('|')[0]);
			dateTime_0 = Convert.ToDateTime(param.Split('|')[1]);
			int_0 = _EmployeeId;
			int_1 = _TerminalId;
		}
		else
		{
			string_0 = param;
		}
	}

	private void frmReport_Load(object sender, EventArgs e)
	{
		LoadReport();
	}

	private void frmReport_FormClosing(object sender, EventArgs e)
	{
		gclass6_0.Dispose();
		chartObject_0 = null;
		reportViewer1.Dispose();
		GC.Collect();
	}

	public void LoadReport()
	{
		reportViewer1.LocalReport.DataSources.Clear();
		if (string_2 == ReportTypes.Orders)
		{
			_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
			Text = "View Orders";
			reportViewer1.LocalReport.ReportEmbeddedResource = "CorePOS.Reports.Receipt.rdlc";
			if (MemoryLoadedObjects.receipt_logo == null)
			{
				MemoryLoadedObjects.receipt_logo = gclass6_0.ImageScreens.Where((ImageScreen a) => a.ImageType == "receipt_logo").FirstOrDefault();
			}
			if (MemoryLoadedObjects.receipt_logo != null)
			{
				byte[] array = Convert.FromBase64String(MemoryLoadedObjects.receipt_logo.ImageAsText);
				reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportLogo", Convert.ToBase64String(array), visible: true));
				reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", visible: true));
				Image image;
				using (MemoryStream stream = new MemoryStream(array))
				{
					image = Image.FromStream(stream);
				}
				float num = (float)image.Width / (float)image.Height * 0.868f;
				int num2 = (int)((3.3f - num) / 2f * 72.28f);
				reportViewer1.LocalReport.SetParameters(new ReportParameter("LogoWidth", num2 + "pt", visible: true));
				image.Dispose();
			}
			else
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportLogo", "R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==", visible: false));
				reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", visible: false));
				reportViewer1.LocalReport.SetParameters(new ReportParameter("LogoWidth", "50", visible: true));
			}
			int num3 = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("receipt_font_size_additional"));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmFontSize", num3.ToString()));
			List<ReceiptOrder> source = ReceiptMethods.GetOrderToPrintReceipt(string_0).ToList();
			decimal num4 = default(decimal);
			ReceiptOrder receiptOrder = source.Where((ReceiptOrder a) => a.ItemName.Contains("Cash Rounding")).FirstOrDefault();
			if (receiptOrder != null)
			{
				num4 = receiptOrder.Total;
			}
			source = source.Where((ReceiptOrder a) => !a.ItemName.Contains("Cash Rounding")).ToList();
			int num5 = 25;
			switch (num3)
			{
			case 1:
				num5 = 22;
				break;
			case 2:
				num5 = 20;
				break;
			}
			foreach (ReceiptOrder item in source)
			{
				string text = "";
				int num6 = num5 - item.ItemName.Length;
				for (int i = 0; i < num6; i++)
				{
					text += " .";
				}
				item.ItemName += text;
			}
			CS_0024_003C_003E8__locals0.empID = (source.FirstOrDefault().UserServed.HasValue ? source.FirstOrDefault().UserServed.Value : (source.FirstOrDefault().UserCreated.HasValue ? source.FirstOrDefault().UserCreated.Value : 0));
			Employee employee = MemoryLoadedObjects.all_employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.empID).FirstOrDefault();
			string text2 = string.Empty;
			if (CS_0024_003C_003E8__locals0.empID != 0 && employee != null)
			{
				text2 += employee.FirstName;
				if (employee.LastName.Length > 1)
				{
					text2 = text2 + " " + employee.LastName[0];
				}
			}
			if (source.FirstOrDefault().OrderType == OrderTypes.DeliveryOnline || source.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline)
			{
				text2 = "Online";
			}
			CS_0024_003C_003E8__locals0.cashierID = (source.FirstOrDefault().UserCashout.HasValue ? source.FirstOrDefault().UserCashout.Value : 0);
			Employee employee2 = MemoryLoadedObjects.all_employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.cashierID).FirstOrDefault();
			string text3 = string.Empty;
			if (CS_0024_003C_003E8__locals0.cashierID != 0 && employee2 != null)
			{
				text3 += employee2.FirstName;
				if (employee2.LastName.Length > 1)
				{
					text3 = text3 + " " + employee2.LastName[0];
				}
			}
			if (source.FirstOrDefault().OrderType == OrderTypes.DeliveryOnline || source.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline)
			{
				text3 = "Online";
			}
			ReportDataSource reportDataSource = new ReportDataSource("ReceiptDS", source);
			string orderType = source.FirstOrDefault().OrderType;
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmOrderType", orderType));
			if (SettingsHelper.GetSettingValueByKey("order_type_receipt").Split(',').Contains(orderType))
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmBigOrderType", orderType.ToUpper()));
			}
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmEmployeeName", text2));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCashierName", text3));
			string empty = string.Empty;
			empty = ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON") ? ((!string.IsNullOrEmpty(source.FirstOrDefault().OrderTicketNumber)) ? OrderHelper.formatTicket(source.FirstOrDefault().OrderTicketNumber) : source.FirstOrDefault().OrderNumber) : ((string.IsNullOrEmpty(source.FirstOrDefault().SubSource) || string.IsNullOrEmpty(source.FirstOrDefault().OrderTicketNumber)) ? source.FirstOrDefault().OrderNumber : source.FirstOrDefault().OrderTicketNumber));
			if (empty.Length > 15)
			{
				empty = empty.Substring(empty.Length - 4, 4).ToUpper();
			}
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmOrderTicketNumber", empty));
			if (string.IsNullOrEmpty(source.FirstOrDefault().CustomerInfoName))
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCustomer", source.FirstOrDefault().Customer));
			}
			else
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCustomer", source.FirstOrDefault().Customer + "-" + source.FirstOrDefault().CustomerInfoName));
			}
			decimal num7 = default(decimal);
			if (source.Where((ReceiptOrder a) => !a.Void).Any() && num4 != 0m)
			{
				num7 = source.Where((ReceiptOrder a) => !a.Void).First().TipAmount;
			}
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmHasRoundedTotal", (num4 != 0m) ? "True" : "False"));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmRoundedTotal", (source.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Total) + num4 + num7).ToString()));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmDiscount", source.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Discount).ToString()));
			reportViewer1.LocalReport.DataSources.Add(reportDataSource);
			reportDataSource.Value = source;
			List<CompanySetup> list = new List<CompanySetup>();
			list.Add(CompanyHelper.CompanyDataSetup);
			ReportDataSource reportDataSource2 = new ReportDataSource("CompanyDS", list);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			reportDataSource2.Value = list;
			List<Tax> taxRate = ReceiptMethods.GetTaxRate();
			ReportDataSource reportDataSource3 = new ReportDataSource("TaxDS", taxRate);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
			reportDataSource3.Value = taxRate;
			List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(source.FirstOrDefault().PaymentMethods);
			ReportDataSource reportDataSource4 = new ReportDataSource("PaymentTypeDS", paymentTypes);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
			reportDataSource4.Value = paymentTypes;
			List<ProcessorPaymentType> taxTypes = PaymentTypeMethods.GetTaxTypes(string.Join("", (from a in source
				where !a.Void
				select a.TaxDesc).ToList()), withPercentage: true);
			ReportDataSource reportDataSource5 = new ReportDataSource("TaxTypeDS", taxTypes);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
			reportDataSource5.Value = taxTypes;
			List<TransactionReceipt> list2 = (from x in gclass6_0.TransactionReceipts
				where x.OrderNumber.Equals(string_0) && x.MerchantReceipt.Contains("APPROVED")
				orderby x.DateCreated descending
				select x).ToList();
			string text4 = string.Empty;
			if (list2 != null && list2.Count > 0)
			{
				foreach (TransactionReceipt item2 in list2)
				{
					text4 += item2.CustomerReceipt;
				}
			}
			text4 = text4.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmPaymentCardTransactionData", text4));
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmAutoGratuity", settingValueByKey));
			string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("receipt_language");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage", settingValueByKey2));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
			string value = Resources.Tax_No + ":";
			if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
			{
				value = "";
			}
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_TaxNo", value));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Order", Resources._Order));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_OrderType", Resources.Order_Type));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Time", Resources.Time));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Customer", Resources.Customer0));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Server", Resources.Server));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Cashier", "Cashier"));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Total", Resources.Total));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_YourShare", Resources.Your_Share_of_the_bill));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_DiscountReason", Resources.Discount_Reason));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_TaxChange", Resources.Tax_Change));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Tendered", Resources.Tendered));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Change", Resources.Change));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_PaymentMethods", Resources.Payment_Methods));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
			Order order = source.FirstOrDefault();
			if (order != null)
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmChange", order.TenderChange.ToString()));
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCash", order.TenderAmount.ToString()));
			}
			IQueryable<Order> source2 = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0 && o.ComboID != 0);
			decimal num8 = default(decimal);
			foreach (Order item3 in source2.Where((Order c) => c.ItemPrice > 0m))
			{
				num8 += DataManager.GetComboDiscount(item3.ItemID);
			}
			num8 += source.Where((ReceiptOrder d) => !d.DateRefunded.HasValue).Sum((ReceiptOrder a) => a.Discount);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmSavedTotal", num8.ToString()));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmDiscountReason", source.FirstOrDefault().DiscountReason));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTaxChangeReason", source.FirstOrDefault().TaxChangeReason));
			if (orderType == OrderTypes.Catering)
			{
				decimal num9 = paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
				decimal num10 = source.Sum((ReceiptOrder a) => a.Total) - num9;
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmBalance", num10.ToString()));
			}
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
			}
			string value2 = ((source.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline) ? "" : source.FirstOrDefault().CustomerInfo);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCustomerInfo", value2));
			string settingValueByKey3 = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey3) ? " " : settingValueByKey3));
			if (!(SettingsHelper.CurrentTerminalMode == "Kiosk") && !SettingsHelper.GetSettingValueByKey("now_serving_screen").Contains("ON") && !SettingsHelper.GetSettingValueByKey("use_order_ticket").Contains("ON"))
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmKiosk_Mode", "false"));
			}
			else
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmKiosk_Mode", "true"));
			}
			reportViewer1.LocalReport.Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (string_2 == ReportTypes.Refunds)
		{
			Text = Resources.View_Refunds;
			reportViewer1.LocalReport.ReportEmbeddedResource = "CorePOS.Reports.RefundReceipt.rdlc";
			List<Order> refundOrderToPrintReceipt = ReceiptMethods.GetRefundOrderToPrintReceipt(string_0);
			ReportDataSource reportDataSource6 = new ReportDataSource("ReceiptDS", refundOrderToPrintReceipt);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmRefundNumber", string_0));
			reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
			reportDataSource6.Value = refundOrderToPrintReceipt;
			List<CompanySetup> list3 = new List<CompanySetup>();
			list3.Add(CompanyHelper.CompanyDataSetup);
			ReportDataSource reportDataSource7 = new ReportDataSource("CompanyDS", list3);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
			reportDataSource7.Value = list3;
			List<Tax> taxRate2 = ReceiptMethods.GetTaxRate();
			ReportDataSource reportDataSource8 = new ReportDataSource("TaxDS", taxRate2);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
			reportDataSource8.Value = taxRate2;
			List<RefundDS> refundDS = ReceiptMethods.GetRefundDS(string_0);
			ReportDataSource reportDataSource9 = new ReportDataSource("RefundsDS", refundDS);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
			reportDataSource9.Value = refundDS;
			string text5 = string.Empty;
			List<TransactionReceipt> list4 = (from x in gclass6_0.TransactionReceipts
				where x.RefundNumber == string_0 && x.MerchantReceipt.Contains("APPROVED")
				select x into y
				orderby y.DateCreated descending
				select y).ToList();
			short num11 = 0;
			bool flag = false;
			foreach (TransactionReceipt item4 in list4)
			{
				num11 = (short)(num11 + 1);
				if (num11 <= 2 && item4.MerchantReceipt.Contains("VOID"))
				{
					flag = true;
				}
				text5 += item4.CustomerReceipt;
			}
			text5 = text5.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmPaymentCardTransactionData", text5));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_RefundReceipt", Resources.REFUND_RECEIPT));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_RefundNumber", Resources.REFUND_NUMBER));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_RefundTotal", flag ? "Void Total" : Resources.Refund_Total));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
			string text6 = refundDS.FirstOrDefault().RefundPaymentMethod.ToUpper();
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmRefundPaymentType", (flag ? "Void" : "Refund Payment") + " Method: " + text6));
			bool flag2 = false;
			List<ReceiptOrder> list5 = ReceiptMethods.GetOrderToPrintReceipt(refundOrderToPrintReceipt.First().OrderNumber).ToList();
			if (list5.All((ReceiptOrder a) => a.Void) && list5.Count == refundOrderToPrintReceipt.Count)
			{
				flag2 = true;
			}
			decimal num12 = ((!(text6 != Resources.CASH0) || !(text6 != "GIFT CERTIFICATE") || !(text6 != "COUPON") || !(text6 != "STORE CREDIT") || !flag2) ? 0m : refundDS.FirstOrDefault().TipAmount);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTipAmount", num12.ToString("0.00")));
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
			}
			string settingValueByKey4 = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey4) ? " " : settingValueByKey4));
			reportViewer1.LocalReport.Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (string_2 == ReportTypes.DayEndClosing)
		{
			Text = Resources.Day_End_Closing;
			reportViewer1.LocalReport.DataSources.Clear();
			reportViewer1.LocalReport.ReportEmbeddedResource = "CorePOS.Reports.Blank.rdlc";
			DayEndTotalsObject dayEndTotalsObject = new PrintHelper().GenerateDayEndTotalsHTML(dateTime_1, dateTime_0, int_0, int_1);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmFontSize", "12"));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTextString", dayEndTotalsObject.DayEndHtml));
			reportViewer1.LocalReport.SetParameters(new ReportParameter("prmFontFamily", "Courier New"));
			reportViewer1.LocalReport.Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (!(string_2 == ReportTypes.DeliveryCommission) && !(string_2 == ReportTypes.DeliveryDrivers))
		{
			reportViewer1.ShowPrintButton = true;
			reportViewer1.ShowToolBar = true;
			reportViewer1.LocalReport.ReportEmbeddedResource = string_1;
			ReportDataSource reportDataSource10 = new ReportDataSource("ChartTotalDS", chartObject_0.totals);
			reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
			reportViewer1.LocalReport.SetParameters(new ReportParameter("ChartTitle", chartObject_0.title));
			reportDataSource10.Value = chartObject_0.totals;
			reportViewer1.LocalReport.Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		Text = "Delivery Commission";
		reportViewer1.LocalReport.ReportEmbeddedResource = "CorePOS.Reports.DeliveryCommissions.rdlc";
		List<CompanySetup> list6 = new List<CompanySetup>();
		list6.Add(CompanyHelper.CompanyDataSetup);
		ReportDataSource reportDataSource11 = new ReportDataSource("CompanyDS", list6);
		reportViewer1.LocalReport.DataSources.Add(reportDataSource11);
		reportDataSource11.Value = list6;
		IQueryable<Order> source3 = gclass6_0.Orders.Where((Order o) => o.DatePaid <= dateTime_0 && o.DatePaid >= dateTime_1 && (o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.DeliveryOnline));
		if (int_0 != 0)
		{
			source3 = source3.Where((Order a) => (int?)a.UserServed == (int?)int_0);
		}
		List<Order> list7 = new List<Order>();
		string text7 = "DELIVERY COMMISSION REPORT";
		if (string_2 == ReportTypes.DeliveryCommission)
		{
			list7 = source3.Where((Order o) => o.ItemName == ConstantItems.Delivery_Fee).ToList();
			text7 = "DELIVERY COMMISSION REPORT";
		}
		else
		{
			list7 = source3.ToList();
			text7 = "DELIVERY DRIVER LIST";
		}
		List<DeliveryCommissionObject> list8 = new List<DeliveryCommissionObject>();
		using (List<Employee>.Enumerator enumerator4 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.Users.First().Role.RoleName == Roles.driver && a.isActive).ToList().GetEnumerator())
		{
			while (enumerator4.MoveNext())
			{
				_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
				CS_0024_003C_003E8__locals1.emp = enumerator4.Current;
				_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass12_2();
				CS_0024_003C_003E8__locals2.empName = CS_0024_003C_003E8__locals1.emp.FirstName + " " + CS_0024_003C_003E8__locals1.emp.LastName;
				List<DeliveryCommissionObject> list9 = (from a in list7
					where a.UserServed == CS_0024_003C_003E8__locals1.emp.EmployeeID
					group a by a.OrderNumber into a
					select new DeliveryCommissionObject
					{
						OrderNumber = a.Key,
						EmployeeName = CS_0024_003C_003E8__locals2.empName,
						SubTotal = a.Sum((Order x) => x.SubTotal)
					}).ToList();
				if (list9.Count > 0)
				{
					list8.AddRange(list9);
					list8.Add(new DeliveryCommissionObject
					{
						OrderNumber = "-",
						EmployeeName = CS_0024_003C_003E8__locals2.empName.ToUpper() + " TOTAL",
						SubTotal = list9.Sum((DeliveryCommissionObject a) => a.SubTotal)
					});
				}
			}
		}
		reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
		string value3 = Resources.Tax_No + ":";
		if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
		{
			value3 = "";
		}
		reportViewer1.LocalReport.SetParameters(new ReportParameter("prmLanguage_TaxNo", value3));
		reportViewer1.LocalReport.SetParameters(new ReportParameter("prmCurrentDate", dateTime_1.ToLongDateString()));
		reportViewer1.LocalReport.SetParameters(new ReportParameter("prmTitle", text7));
		ReportDataSource reportDataSource12 = new ReportDataSource("CommissionTotalDS", list8);
		reportViewer1.LocalReport.DataSources.Add(reportDataSource12);
		reportDataSource12.Value = list8;
		reportViewer1.LocalReport.Refresh();
		reportViewer1.RefreshReport();
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
		ReportDataSource reportDataSource = new ReportDataSource();
		ReportDataSource reportDataSource2 = new ReportDataSource();
		bindingSource_0 = new BindingSource(icontainer_1);
		bindingSource_1 = new BindingSource(icontainer_1);
		reportViewer1 = new ReportViewer();
		((ISupportInitialize)bindingSource_0).BeginInit();
		((ISupportInitialize)bindingSource_1).BeginInit();
		SuspendLayout();
		bindingSource_0.DataSource = typeof(Order);
		bindingSource_1.DataSource = typeof(CompanySetup);
		reportViewer1.BackColor = Color.DarkGray;
		reportViewer1.Dock = DockStyle.Fill;
		reportDataSource.Name = "ReceiptDS";
		reportDataSource.Value = bindingSource_0;
		reportDataSource2.Name = "CompanyDS";
		reportDataSource2.Value = bindingSource_1;
		reportViewer1.LocalReport.DataSources.Add(reportDataSource);
		reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
		reportViewer1.LocalReport.ReportEmbeddedResource = "CorePOS.Reports.Receipt.rdlc";
		reportViewer1.Location = new Point(0, 0);
		reportViewer1.Name = "reportViewer1";
		reportViewer1.Padding = new Padding(40, 40, 0, 40);
		reportViewer1.ShowPrintButton = false;
		reportViewer1.ShowToolBar = false;
		reportViewer1.Size = new Size(390, 600);
		reportViewer1.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gray;
		base.ClientSize = new Size(390, 600);
		base.Controls.Add(reportViewer1);
		ForeColor = Color.FromArgb(40, 40, 40);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmReport";
		base.Opacity = 1.0;
		Text = "View Orders";
		base.FormClosing += frmReport_FormClosing;
		base.Load += frmReport_Load;
		((ISupportInitialize)bindingSource_0).EndInit();
		((ISupportInitialize)bindingSource_1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
