using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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
		base._002Ector();
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
		((Component)(object)reportViewer1).Dispose();
		GC.Collect();
	}

	public void LoadReport()
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Expected O, but got Unknown
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Expected O, but got Unknown
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Expected O, but got Unknown
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected O, but got Unknown
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Expected O, but got Unknown
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_0bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd8: Expected O, but got Unknown
		//IL_0bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Expected O, but got Unknown
		//IL_0c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c28: Expected O, but got Unknown
		//IL_0c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c47: Expected O, but got Unknown
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8c: Expected O, but got Unknown
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cab: Expected O, but got Unknown
		//IL_0cc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cca: Expected O, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected O, but got Unknown
		//IL_0cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Expected O, but got Unknown
		//IL_0d1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d27: Expected O, but got Unknown
		//IL_0d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d46: Expected O, but got Unknown
		//IL_0d5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d65: Expected O, but got Unknown
		//IL_0d7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d84: Expected O, but got Unknown
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da3: Expected O, but got Unknown
		//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc2: Expected O, but got Unknown
		//IL_0dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de1: Expected O, but got Unknown
		//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1f: Expected O, but got Unknown
		//IL_0e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Expected O, but got Unknown
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5d: Expected O, but got Unknown
		//IL_0e72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7c: Expected O, but got Unknown
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9b: Expected O, but got Unknown
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eba: Expected O, but got Unknown
		//IL_0ecf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed9: Expected O, but got Unknown
		//IL_0eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef8: Expected O, but got Unknown
		//IL_0f24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2e: Expected O, but got Unknown
		//IL_0f4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Expected O, but got Unknown
		//IL_1122: Unknown result type (might be due to invalid IL or missing references)
		//IL_112c: Expected O, but got Unknown
		//IL_1147: Unknown result type (might be due to invalid IL or missing references)
		//IL_1151: Expected O, but got Unknown
		//IL_116c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1176: Expected O, but got Unknown
		//IL_11f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fb: Expected O, but got Unknown
		//IL_1226: Unknown result type (might be due to invalid IL or missing references)
		//IL_1230: Expected O, but got Unknown
		//IL_126d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1277: Expected O, but got Unknown
		//IL_12a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12af: Expected O, but got Unknown
		//IL_1301: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Expected O, but got Unknown
		//IL_1322: Unknown result type (might be due to invalid IL or missing references)
		//IL_132c: Expected O, but got Unknown
		//IL_1391: Unknown result type (might be due to invalid IL or missing references)
		//IL_1398: Expected O, but got Unknown
		//IL_13ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b8: Expected O, but got Unknown
		//IL_13f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f9: Expected O, but got Unknown
		//IL_1427: Unknown result type (might be due to invalid IL or missing references)
		//IL_142e: Expected O, but got Unknown
		//IL_1462: Unknown result type (might be due to invalid IL or missing references)
		//IL_1469: Expected O, but got Unknown
		//IL_164c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1656: Expected O, but got Unknown
		//IL_166b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1675: Expected O, but got Unknown
		//IL_168a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1694: Expected O, but got Unknown
		//IL_16a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b3: Expected O, but got Unknown
		//IL_16c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d2: Expected O, but got Unknown
		//IL_16e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Expected O, but got Unknown
		//IL_1706: Unknown result type (might be due to invalid IL or missing references)
		//IL_1710: Expected O, but got Unknown
		//IL_1725: Unknown result type (might be due to invalid IL or missing references)
		//IL_172f: Expected O, but got Unknown
		//IL_1744: Unknown result type (might be due to invalid IL or missing references)
		//IL_174e: Expected O, but got Unknown
		//IL_176e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1778: Expected O, but got Unknown
		//IL_178d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1797: Expected O, but got Unknown
		//IL_17d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e0: Expected O, but got Unknown
		//IL_18a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ad: Expected O, but got Unknown
		//IL_18d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e2: Expected O, but got Unknown
		//IL_1910: Unknown result type (might be due to invalid IL or missing references)
		//IL_191a: Expected O, but got Unknown
		//IL_19ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c4: Expected O, but got Unknown
		//IL_19db: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e5: Expected O, but got Unknown
		//IL_19fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a04: Expected O, but got Unknown
		//IL_1a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8f: Expected O, but got Unknown
		//IL_1ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acb: Expected O, but got Unknown
		//IL_1b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3a: Expected O, but got Unknown
		//IL_1f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5e: Expected O, but got Unknown
		//IL_1f99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa3: Expected O, but got Unknown
		//IL_1fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc8: Expected O, but got Unknown
		//IL_1fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe4: Expected O, but got Unknown
		//IL_1feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff2: Expected O, but got Unknown
		((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Clear();
		if (string_2 == ReportTypes.Orders)
		{
			_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
			Text = "View Orders";
			reportViewer1.get_LocalReport().set_ReportEmbeddedResource("CorePOS.Reports.Receipt.rdlc");
			if (MemoryLoadedObjects.receipt_logo == null)
			{
				MemoryLoadedObjects.receipt_logo = gclass6_0.ImageScreens.Where((ImageScreen a) => a.ImageType == "receipt_logo").FirstOrDefault();
			}
			if (MemoryLoadedObjects.receipt_logo != null)
			{
				byte[] array = Convert.FromBase64String(MemoryLoadedObjects.receipt_logo.ImageAsText);
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("ReportLogo", Convert.ToBase64String(array), true));
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", true));
				Image image;
				using (MemoryStream stream = new MemoryStream(array))
				{
					image = Image.FromStream(stream);
				}
				float num = (float)image.Width / (float)image.Height * 0.868f;
				int num2 = (int)((3.3f - num) / 2f * 72.28f);
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("LogoWidth", num2 + "pt", true));
				image.Dispose();
			}
			else
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("ReportLogo", "R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==", false));
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", false));
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("LogoWidth", "50", true));
			}
			int num3 = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("receipt_font_size_additional"));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmFontSize", num3.ToString()));
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
			ReportDataSource val = new ReportDataSource("ReceiptDS", (IEnumerable)source);
			string orderType = source.FirstOrDefault().OrderType;
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmOrderType", orderType));
			if (SettingsHelper.GetSettingValueByKey("order_type_receipt").Split(',').Contains(orderType))
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmBigOrderType", orderType.ToUpper()));
			}
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmEmployeeName", text2));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCashierName", text3));
			string empty = string.Empty;
			empty = ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON") ? ((!string.IsNullOrEmpty(source.FirstOrDefault().OrderTicketNumber)) ? OrderHelper.formatTicket(source.FirstOrDefault().OrderTicketNumber) : source.FirstOrDefault().OrderNumber) : ((string.IsNullOrEmpty(source.FirstOrDefault().SubSource) || string.IsNullOrEmpty(source.FirstOrDefault().OrderTicketNumber)) ? source.FirstOrDefault().OrderNumber : source.FirstOrDefault().OrderTicketNumber));
			if (empty.Length > 15)
			{
				empty = empty.Substring(empty.Length - 4, 4).ToUpper();
			}
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmOrderTicketNumber", empty));
			if (string.IsNullOrEmpty(source.FirstOrDefault().CustomerInfoName))
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCustomer", source.FirstOrDefault().Customer));
			}
			else
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCustomer", source.FirstOrDefault().Customer + "-" + source.FirstOrDefault().CustomerInfoName));
			}
			decimal num7 = default(decimal);
			if (source.Where((ReceiptOrder a) => !a.Void).Any() && num4 != 0m)
			{
				num7 = source.Where((ReceiptOrder a) => !a.Void).First().TipAmount;
			}
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmHasRoundedTotal", (num4 != 0m) ? "True" : "False"));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmRoundedTotal", (source.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Total) + num4 + num7).ToString()));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmDiscount", source.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Discount).ToString()));
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val);
			val.set_Value((object)source);
			List<CompanySetup> list = new List<CompanySetup>();
			list.Add(CompanyHelper.CompanyDataSetup);
			ReportDataSource val2 = new ReportDataSource("CompanyDS", (IEnumerable)list);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val2);
			val2.set_Value((object)list);
			List<Tax> taxRate = ReceiptMethods.GetTaxRate();
			ReportDataSource val3 = new ReportDataSource("TaxDS", (IEnumerable)taxRate);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val3);
			val3.set_Value((object)taxRate);
			List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(source.FirstOrDefault().PaymentMethods);
			ReportDataSource val4 = new ReportDataSource("PaymentTypeDS", (IEnumerable)paymentTypes);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val4);
			val4.set_Value((object)paymentTypes);
			List<ProcessorPaymentType> taxTypes = PaymentTypeMethods.GetTaxTypes(string.Join("", (from a in source
				where !a.Void
				select a.TaxDesc).ToList()), withPercentage: true);
			ReportDataSource val5 = new ReportDataSource("TaxTypeDS", (IEnumerable)taxTypes);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val5);
			val5.set_Value((object)taxTypes);
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
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmPaymentCardTransactionData", text4));
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity");
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmAutoGratuity", settingValueByKey));
			string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("receipt_language");
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage", settingValueByKey2));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
			string text5 = Resources.Tax_No + ":";
			if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
			{
				text5 = "";
			}
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_TaxNo", text5));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Order", Resources._Order));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_OrderType", Resources.Order_Type));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Time", Resources.Time));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Customer", Resources.Customer0));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Server", Resources.Server));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Cashier", "Cashier"));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Total", Resources.Total));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_YourShare", Resources.Your_Share_of_the_bill));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_DiscountReason", Resources.Discount_Reason));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_TaxChange", Resources.Tax_Change));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Tendered", Resources.Tendered));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Change", Resources.Change));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_PaymentMethods", Resources.Payment_Methods));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
			Order order = source.FirstOrDefault();
			if (order != null)
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmChange", order.TenderChange.ToString()));
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCash", order.TenderAmount.ToString()));
			}
			IQueryable<Order> source2 = gclass6_0.Orders.Where((Order o) => o.OrderNumber == string_0 && o.ComboID != 0);
			decimal num8 = default(decimal);
			foreach (Order item3 in source2.Where((Order c) => c.ItemPrice > 0m))
			{
				num8 += DataManager.GetComboDiscount(item3.ItemID);
			}
			num8 += source.Where((ReceiptOrder d) => !d.DateRefunded.HasValue).Sum((ReceiptOrder a) => a.Discount);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmSavedTotal", num8.ToString()));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmDiscountReason", source.FirstOrDefault().DiscountReason));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTaxChangeReason", source.FirstOrDefault().TaxChangeReason));
			if (orderType == OrderTypes.Catering)
			{
				decimal num9 = paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
				decimal num10 = source.Sum((ReceiptOrder a) => a.Total) - num9;
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmBalance", num10.ToString()));
			}
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
			}
			string text6 = ((source.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline) ? "" : source.FirstOrDefault().CustomerInfo);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCustomerInfo", text6));
			string settingValueByKey3 = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey3) ? " " : settingValueByKey3));
			if (!(SettingsHelper.CurrentTerminalMode == "Kiosk") && !SettingsHelper.GetSettingValueByKey("now_serving_screen").Contains("ON") && !SettingsHelper.GetSettingValueByKey("use_order_ticket").Contains("ON"))
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmKiosk_Mode", "false"));
			}
			else
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmKiosk_Mode", "true"));
			}
			((Report)reportViewer1.get_LocalReport()).Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (string_2 == ReportTypes.Refunds)
		{
			Text = Resources.View_Refunds;
			reportViewer1.get_LocalReport().set_ReportEmbeddedResource("CorePOS.Reports.RefundReceipt.rdlc");
			List<Order> refundOrderToPrintReceipt = ReceiptMethods.GetRefundOrderToPrintReceipt(string_0);
			ReportDataSource val6 = new ReportDataSource("ReceiptDS", (IEnumerable)refundOrderToPrintReceipt);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmRefundNumber", string_0));
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val6);
			val6.set_Value((object)refundOrderToPrintReceipt);
			List<CompanySetup> list3 = new List<CompanySetup>();
			list3.Add(CompanyHelper.CompanyDataSetup);
			ReportDataSource val7 = new ReportDataSource("CompanyDS", (IEnumerable)list3);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val7);
			val7.set_Value((object)list3);
			List<Tax> taxRate2 = ReceiptMethods.GetTaxRate();
			ReportDataSource val8 = new ReportDataSource("TaxDS", (IEnumerable)taxRate2);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val8);
			val8.set_Value((object)taxRate2);
			List<RefundDS> refundDS = ReceiptMethods.GetRefundDS(string_0);
			ReportDataSource val9 = new ReportDataSource("RefundsDS", (IEnumerable)refundDS);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val9);
			val9.set_Value((object)refundDS);
			string text7 = string.Empty;
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
				text7 += item4.CustomerReceipt;
			}
			text7 = text7.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmPaymentCardTransactionData", text7));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_RefundReceipt", Resources.REFUND_RECEIPT));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_RefundNumber", Resources.REFUND_NUMBER));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_RefundTotal", flag ? "Void Total" : Resources.Refund_Total));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
			string text8 = refundDS.FirstOrDefault().RefundPaymentMethod.ToUpper();
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmRefundPaymentType", (flag ? "Void" : "Refund Payment") + " Method: " + text8));
			bool flag2 = false;
			List<ReceiptOrder> list5 = ReceiptMethods.GetOrderToPrintReceipt(refundOrderToPrintReceipt.First().OrderNumber).ToList();
			if (list5.All((ReceiptOrder a) => a.Void) && list5.Count == refundOrderToPrintReceipt.Count)
			{
				flag2 = true;
			}
			decimal num12 = ((!(text8 != Resources.CASH0) || !(text8 != "GIFT CERTIFICATE") || !(text8 != "COUPON") || !(text8 != "STORE CREDIT") || !flag2) ? 0m : refundDS.FirstOrDefault().TipAmount);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTipAmount", num12.ToString("0.00")));
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
			}
			string settingValueByKey4 = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey4) ? " " : settingValueByKey4));
			((Report)reportViewer1.get_LocalReport()).Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (string_2 == ReportTypes.DayEndClosing)
		{
			Text = Resources.Day_End_Closing;
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Clear();
			reportViewer1.get_LocalReport().set_ReportEmbeddedResource("CorePOS.Reports.Blank.rdlc");
			DayEndTotalsObject dayEndTotalsObject = new PrintHelper().GenerateDayEndTotalsHTML(dateTime_1, dateTime_0, int_0, int_1);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmFontSize", "12"));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTextString", dayEndTotalsObject.DayEndHtml));
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmFontFamily", "Courier New"));
			((Report)reportViewer1.get_LocalReport()).Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		if (!(string_2 == ReportTypes.DeliveryCommission) && !(string_2 == ReportTypes.DeliveryDrivers))
		{
			reportViewer1.set_ShowPrintButton(true);
			reportViewer1.set_ShowToolBar(true);
			reportViewer1.get_LocalReport().set_ReportEmbeddedResource(string_1);
			ReportDataSource val10 = new ReportDataSource("ChartTotalDS", (IEnumerable)chartObject_0.totals);
			((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val10);
			((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("ChartTitle", chartObject_0.title));
			val10.set_Value((object)chartObject_0.totals);
			((Report)reportViewer1.get_LocalReport()).Refresh();
			reportViewer1.RefreshReport();
			return;
		}
		Text = "Delivery Commission";
		reportViewer1.get_LocalReport().set_ReportEmbeddedResource("CorePOS.Reports.DeliveryCommissions.rdlc");
		List<CompanySetup> list6 = new List<CompanySetup>();
		list6.Add(CompanyHelper.CompanyDataSetup);
		ReportDataSource val11 = new ReportDataSource("CompanyDS", (IEnumerable)list6);
		((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val11);
		val11.set_Value((object)list6);
		IQueryable<Order> source3 = gclass6_0.Orders.Where((Order o) => o.DatePaid <= dateTime_0 && o.DatePaid >= dateTime_1 && (o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.DeliveryOnline));
		if (int_0 != 0)
		{
			source3 = source3.Where((Order a) => (int?)a.UserServed == (int?)int_0);
		}
		List<Order> list7 = new List<Order>();
		string text9 = "DELIVERY COMMISSION REPORT";
		if (string_2 == ReportTypes.DeliveryCommission)
		{
			list7 = source3.Where((Order o) => o.ItemName == ConstantItems.Delivery_Fee).ToList();
			text9 = "DELIVERY COMMISSION REPORT";
		}
		else
		{
			list7 = source3.ToList();
			text9 = "DELIVERY DRIVER LIST";
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
		((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
		string text10 = Resources.Tax_No + ":";
		if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
		{
			text10 = "";
		}
		((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmLanguage_TaxNo", text10));
		((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmCurrentDate", dateTime_1.ToLongDateString()));
		((Report)reportViewer1.get_LocalReport()).SetParameters(new ReportParameter("prmTitle", text9));
		ReportDataSource val12 = new ReportDataSource("CommissionTotalDS", (IEnumerable)list8);
		((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val12);
		val12.set_Value((object)list8);
		((Report)reportViewer1.get_LocalReport()).Refresh();
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
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		icontainer_1 = new Container();
		ReportDataSource val = new ReportDataSource();
		ReportDataSource val2 = new ReportDataSource();
		bindingSource_0 = new BindingSource(icontainer_1);
		bindingSource_1 = new BindingSource(icontainer_1);
		reportViewer1 = new ReportViewer();
		((ISupportInitialize)bindingSource_0).BeginInit();
		((ISupportInitialize)bindingSource_1).BeginInit();
		SuspendLayout();
		bindingSource_0.DataSource = typeof(Order);
		bindingSource_1.DataSource = typeof(CompanySetup);
		((Control)(object)reportViewer1).BackColor = Color.DarkGray;
		((Control)(object)reportViewer1).Dock = DockStyle.Fill;
		val.set_Name("ReceiptDS");
		val.set_Value((object)bindingSource_0);
		val2.set_Name("CompanyDS");
		val2.set_Value((object)bindingSource_1);
		((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val);
		((Collection<ReportDataSource>)(object)reportViewer1.get_LocalReport().get_DataSources()).Add(val2);
		reportViewer1.get_LocalReport().set_ReportEmbeddedResource("CorePOS.Reports.Receipt.rdlc");
		((Control)(object)reportViewer1).Location = new Point(0, 0);
		((Control)(object)reportViewer1).Name = "reportViewer1";
		((Control)(object)reportViewer1).Padding = new Padding(40, 40, 0, 40);
		reportViewer1.set_ShowPrintButton(false);
		reportViewer1.set_ShowToolBar(false);
		((Control)(object)reportViewer1).Size = new Size(390, 600);
		((Control)(object)reportViewer1).TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Gray;
		base.ClientSize = new Size(390, 600);
		base.Controls.Add((Control)(object)reportViewer1);
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
