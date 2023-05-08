using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Printing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

public class PrintHelper
{
	public List<CompanySetup> companies;

	private ReportDataSource reportDataSource_0;

	private List<Tax> list_0;

	private ReportDataSource reportDataSource_1;

	private string string_0;

	private int int_0;

	private static bool bool_0;

	private static string string_1;

	private int int_1;

	private IList<Stream> ilist_0;

	public static bool currentlyPrinting;

	[DllImport("winspool.Drv", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultPrinter(string name);

	public PrintHelper(string printerName = null)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		companies = new List<CompanySetup>();
		list_0 = ReceiptMethods.GetTaxRate().ToList();
		base._002Ector();
		reportDataSource_0 = new ReportDataSource("CompanyDS", (IEnumerable)companies);
		reportDataSource_1 = new ReportDataSource("TaxDS", (IEnumerable)list_0);
		companies.Add(CompanyHelper.CompanyDataSetup);
		if (printerName != null)
		{
			string_0 = printerName;
			return;
		}
		PrinterSettings printerSettings = new PrinterSettings();
		if (printerSettings != null)
		{
			string_0 = printerSettings.PrinterName;
		}
		else
		{
			string_0 = null;
		}
	}

	private Stream method_0(string string_2, string string_3, Encoding encoding_0, string string_4, bool bool_1)
	{
		Stream stream = new MemoryStream();
		ilist_0.Add(stream);
		return stream;
	}

	public static void GenerateReceipt(string orderNumber, bool printPaymentTransaction = false, int splitBillEvenly = 1, string savePath = null, bool tipFlag = false, bool email = false, string printerName = null, decimal gcValue = -1m, decimal lcValue = -1m)
	{
		if (MemoryLoadedObjects.ListOfReceiptsToPrint == null)
		{
			MemoryLoadedObjects.ListOfReceiptsToPrint = new List<ReceiptPrintInfo>();
		}
		MemoryLoadedObjects.ListOfReceiptsToPrint.Add(new ReceiptPrintInfo
		{
			orderNumber = orderNumber,
			printPaymentTransaction = printPaymentTransaction,
			splitBillEvenly = splitBillEvenly,
			savePath = savePath,
			tipFlag = tipFlag,
			email = email,
			printerName = printerName,
			GCValue = gcValue,
			LoyaltyValue = lcValue
		});
	}

	public void PrintReceipt(string rlang, string orderNumber, bool printPaymentTransaction = false, int splitBillEvenly = 1, string savePath = null, bool tipFlag = false, bool email = false, string printerName = null, decimal gcValue = 0m, decimal lcValue = 0m)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected O, but got Unknown
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Expected O, but got Unknown
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Expected O, but got Unknown
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Expected O, but got Unknown
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Expected O, but got Unknown
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected O, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected O, but got Unknown
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Expected O, but got Unknown
		//IL_093a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Expected O, but got Unknown
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0964: Expected O, but got Unknown
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Expected O, but got Unknown
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a25: Expected O, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected O, but got Unknown
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Expected O, but got Unknown
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Expected O, but got Unknown
		//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9a: Expected O, but got Unknown
		//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Expected O, but got Unknown
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7c: Expected O, but got Unknown
		//IL_0c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c98: Expected O, but got Unknown
		//IL_0d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d14: Expected O, but got Unknown
		//IL_0d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Expected O, but got Unknown
		//IL_0e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1f: Expected O, but got Unknown
		//IL_0e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Expected O, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Expected O, but got Unknown
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_104f: Expected O, but got Unknown
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_106d: Expected O, but got Unknown
		//IL_1074: Unknown result type (might be due to invalid IL or missing references)
		//IL_107e: Expected O, but got Unknown
		//IL_1089: Unknown result type (might be due to invalid IL or missing references)
		//IL_1093: Expected O, but got Unknown
		//IL_10c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ce: Expected O, but got Unknown
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e3: Expected O, but got Unknown
		//IL_10ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Expected O, but got Unknown
		//IL_1103: Unknown result type (might be due to invalid IL or missing references)
		//IL_110d: Expected O, but got Unknown
		//IL_1118: Unknown result type (might be due to invalid IL or missing references)
		//IL_1122: Expected O, but got Unknown
		//IL_112d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1137: Expected O, but got Unknown
		//IL_1142: Unknown result type (might be due to invalid IL or missing references)
		//IL_114c: Expected O, but got Unknown
		//IL_1157: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Expected O, but got Unknown
		//IL_116c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1176: Expected O, but got Unknown
		//IL_1181: Unknown result type (might be due to invalid IL or missing references)
		//IL_118b: Expected O, but got Unknown
		//IL_1196: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a0: Expected O, but got Unknown
		//IL_11ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b5: Expected O, but got Unknown
		//IL_11c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ca: Expected O, but got Unknown
		//IL_11d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11df: Expected O, but got Unknown
		//IL_11ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f4: Expected O, but got Unknown
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1209: Expected O, but got Unknown
		//IL_1214: Unknown result type (might be due to invalid IL or missing references)
		//IL_121e: Expected O, but got Unknown
		//IL_1229: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Expected O, but got Unknown
		//IL_123e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1248: Expected O, but got Unknown
		//IL_1253: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Expected O, but got Unknown
		//IL_1268: Unknown result type (might be due to invalid IL or missing references)
		//IL_1272: Expected O, but got Unknown
		//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c4: Expected O, but got Unknown
		//IL_12d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12db: Expected O, but got Unknown
		//IL_133a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1344: Expected O, but got Unknown
		//IL_1404: Unknown result type (might be due to invalid IL or missing references)
		//IL_140e: Expected O, but got Unknown
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.orderNumber = orderNumber;
		if (!string.IsNullOrEmpty(printerName))
		{
			string_0 = printerName;
		}
		CultureInfo cultureInfo = new CultureInfo(rlang);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		LocalReport val = new LocalReport();
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
		val.set_ReportEmbeddedResource("CorePOS.Reports.Receipt.rdlc");
		GClass6 gClass = new GClass6();
		if (MemoryLoadedObjects.receipt_logo == null)
		{
			MemoryLoadedObjects.receipt_logo = gClass.ImageScreens.Where((ImageScreen a) => a.ImageType == "receipt_logo").FirstOrDefault();
		}
		if (MemoryLoadedObjects.receipt_logo != null)
		{
			if (!string.IsNullOrEmpty(MemoryLoadedObjects.receipt_logo.ImageAsText))
			{
				byte[] array = Convert.FromBase64String(MemoryLoadedObjects.receipt_logo.ImageAsText);
				((Report)val).SetParameters(new ReportParameter("ReportLogo", Convert.ToBase64String(array), true));
				((Report)val).SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", true));
				Image image;
				using (MemoryStream stream = new MemoryStream(array))
				{
					image = Image.FromStream(stream);
				}
				float num = (float)image.Width / (float)image.Height * 0.868f;
				((Report)val).SetParameters(new ReportParameter("LogoWidth", (int)((3.3f - num) / 2f * 72.28f) + "pt", true));
				image.Dispose();
			}
			else
			{
				((Report)val).SetParameters(new ReportParameter("ReportLogo", "R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==", false));
				((Report)val).SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", false));
				((Report)val).SetParameters(new ReportParameter("LogoWidth", "50", true));
			}
		}
		else
		{
			((Report)val).SetParameters(new ReportParameter("ReportLogo", "R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==", false));
			((Report)val).SetParameters(new ReportParameter("ReportLogoMimeType", "image/png", false));
			((Report)val).SetParameters(new ReportParameter("LogoWidth", "50", true));
		}
		int num2 = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("receipt_font_size_additional"));
		((Report)val).SetParameters(new ReportParameter("prmFontSize", num2.ToString()));
		List<ReceiptOrder> orderToPrintReceipt = ReceiptMethods.GetOrderToPrintReceipt(CS_0024_003C_003E8__locals0.orderNumber);
		decimal num3 = default(decimal);
		ReceiptOrder receiptOrder = orderToPrintReceipt.Where((ReceiptOrder a) => a.ItemName.Contains("Cash Rounding")).FirstOrDefault();
		if (receiptOrder != null)
		{
			num3 = receiptOrder.Total;
		}
		orderToPrintReceipt = orderToPrintReceipt.Where((ReceiptOrder a) => !a.ItemName.Contains("Cash Rounding")).ToList();
		int num4 = 25;
		switch (num2)
		{
		case 1:
			num4 = 22;
			break;
		case 2:
			num4 = 20;
			break;
		}
		foreach (ReceiptOrder item in orderToPrintReceipt)
		{
			string text = "";
			int num5 = num4 - item.ItemName.Length;
			for (int i = 0; i < num5; i++)
			{
				text += " .";
			}
			item.ItemName += text;
		}
		if (orderToPrintReceipt.FirstOrDefault() == null)
		{
			return;
		}
		CS_0024_003C_003E8__locals0.empID = (orderToPrintReceipt.FirstOrDefault().UserServed.HasValue ? orderToPrintReceipt.FirstOrDefault().UserServed.Value : (orderToPrintReceipt.FirstOrDefault().UserCreated.HasValue ? orderToPrintReceipt.FirstOrDefault().UserCreated.Value : 0));
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
		if (orderToPrintReceipt.FirstOrDefault().OrderType == OrderTypes.DeliveryOnline || orderToPrintReceipt.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline)
		{
			text2 = "Online";
		}
		CS_0024_003C_003E8__locals0.cashierID = (orderToPrintReceipt.FirstOrDefault().UserCashout.HasValue ? orderToPrintReceipt.FirstOrDefault().UserCashout.Value : 0);
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
		if (orderToPrintReceipt.FirstOrDefault().OrderType == OrderTypes.DeliveryOnline || orderToPrintReceipt.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline)
		{
			text3 = "Online";
		}
		ReportDataSource val2 = new ReportDataSource("ReceiptDS", (IEnumerable)orderToPrintReceipt);
		string orderType = orderToPrintReceipt.FirstOrDefault().OrderType;
		((Report)val).SetParameters(new ReportParameter("prmOrderType", orderType));
		if (SettingsHelper.GetSettingValueByKey("order_type_receipt").Split(',').Contains(orderType))
		{
			((Report)val).SetParameters(new ReportParameter("prmBigOrderType", orderType.ToUpper()));
		}
		((Report)val).SetParameters(new ReportParameter("prmEmployeeName", text2));
		((Report)val).SetParameters(new ReportParameter("prmCashierName", text3));
		if (string.IsNullOrEmpty(orderToPrintReceipt.FirstOrDefault().CustomerInfoName))
		{
			((Report)val).SetParameters(new ReportParameter("prmCustomer", orderToPrintReceipt.FirstOrDefault().Customer));
		}
		else
		{
			((Report)val).SetParameters(new ReportParameter("prmCustomer", orderToPrintReceipt.FirstOrDefault().Customer + "-" + orderToPrintReceipt.FirstOrDefault().CustomerInfoName));
		}
		decimal num6 = default(decimal);
		if (orderToPrintReceipt.Where((ReceiptOrder a) => !a.Void).Any())
		{
			num6 = orderToPrintReceipt.Where((ReceiptOrder a) => !a.Void).First().TipAmount;
		}
		((Report)val).SetParameters(new ReportParameter("prmHasRoundedTotal", (num3 != 0m) ? "True" : "False"));
		((Report)val).SetParameters(new ReportParameter("prmRoundedTotal", (orderToPrintReceipt.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Total) + num3 + num6).ToString()));
		((Report)val).SetParameters(new ReportParameter("prmDiscount", orderToPrintReceipt.Where((ReceiptOrder a) => !a.Void).Sum((ReceiptOrder a) => a.Discount).ToString()));
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val2);
		val2.set_Value((object)orderToPrintReceipt);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(reportDataSource_0);
		reportDataSource_0.set_Value((object)companies);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(reportDataSource_1);
		reportDataSource_1.set_Value((object)list_0);
		List<ProcessorPaymentType> paymentTypes = PaymentTypeMethods.GetPaymentTypes(orderToPrintReceipt.FirstOrDefault().PaymentMethods);
		ReportDataSource val3 = new ReportDataSource("PaymentTypeDS", (IEnumerable)paymentTypes);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val3);
		val3.set_Value((object)paymentTypes);
		List<ProcessorPaymentType> taxTypes = PaymentTypeMethods.GetTaxTypes(string.Join("", (from a in orderToPrintReceipt
			where !a.Void
			select a.TaxDesc).ToList()), withPercentage: true);
		ReportDataSource val4 = new ReportDataSource("TaxTypeDS", (IEnumerable)taxTypes);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val4);
		val4.set_Value((object)taxTypes);
		if (splitBillEvenly > 1)
		{
			((Report)val).SetParameters(new ReportParameter("prmSplitBillTotal", (orderToPrintReceipt.Sum((ReceiptOrder a) => a.Total) / (decimal)splitBillEvenly).ToString()));
		}
		Order order = orderToPrintReceipt.FirstOrDefault();
		if (order != null)
		{
			((Report)val).SetParameters(new ReportParameter("prmChange", order.TenderChange.ToString()));
			((Report)val).SetParameters(new ReportParameter("prmCash", order.TenderAmount.ToString()));
		}
		if (tipFlag)
		{
			double num7 = 0.0;
			foreach (ReceiptOrder item2 in orderToPrintReceipt)
			{
				num7 += decimal.ToDouble(item2.Total);
			}
			num7 /= (double)splitBillEvenly;
			((Report)val).SetParameters(new ReportParameter("prmTip15", "15% -  $" + (0.15 * num7).ToString("F")));
			((Report)val).SetParameters(new ReportParameter("prmTip18", "18% -  $" + (0.18 * num7).ToString("F")));
			((Report)val).SetParameters(new ReportParameter("prmTip20", "20% -  $" + (0.2 * num7).ToString("F")));
		}
		else
		{
			((Report)val).SetParameters(new ReportParameter("prmTip15", ""));
			((Report)val).SetParameters(new ReportParameter("prmTip18", ""));
			((Report)val).SetParameters(new ReportParameter("prmTip20", ""));
		}
		IQueryable<Order> source = gClass.Orders.Where((Order o) => o.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber && o.ComboID != 0);
		decimal num8 = default(decimal);
		foreach (Order item3 in source.Where((Order c) => c.ItemPrice > 0m))
		{
			num8 += DataManager.GetComboDiscount(item3.ItemID);
		}
		((Report)val).SetParameters(new ReportParameter("prmSavedTotal", (num8 + orderToPrintReceipt.Where((ReceiptOrder d) => !d.DateRefunded.HasValue).Sum((ReceiptOrder a) => a.Discount)).ToString()));
		((Report)val).SetParameters(new ReportParameter("prmDiscountReason", orderToPrintReceipt.FirstOrDefault().DiscountReason));
		((Report)val).SetParameters(new ReportParameter("prmTaxChangeReason", orderToPrintReceipt.FirstOrDefault().TaxChangeReason));
		if (orderType == OrderTypes.Catering)
		{
			decimal num9 = paymentTypes.Sum((ProcessorPaymentType a) => a.Amount);
			((Report)val).SetParameters(new ReportParameter("prmBalance", (orderToPrintReceipt.Sum((ReceiptOrder a) => a.Total) - num9).ToString()));
		}
		string text4 = ((orderToPrintReceipt.FirstOrDefault().OrderType == OrderTypes.TakeOutOnline) ? "" : orderToPrintReceipt.FirstOrDefault().CustomerInfo);
		((Report)val).SetParameters(new ReportParameter("prmCustomerInfo", text4));
		string empty = string.Empty;
		empty = ((SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON") ? ((!string.IsNullOrEmpty(orderToPrintReceipt.FirstOrDefault().OrderTicketNumber)) ? OrderHelper.formatTicket(orderToPrintReceipt.FirstOrDefault().OrderTicketNumber) : orderToPrintReceipt.FirstOrDefault().OrderNumber) : ((string.IsNullOrEmpty(orderToPrintReceipt.FirstOrDefault().SubSource) || string.IsNullOrEmpty(orderToPrintReceipt.FirstOrDefault().OrderTicketNumber)) ? orderToPrintReceipt.FirstOrDefault().OrderNumber : orderToPrintReceipt.FirstOrDefault().OrderTicketNumber));
		if (empty.Length > 15)
		{
			empty = empty.Substring(empty.Length - 4, 4).ToUpper();
		}
		((Report)val).SetParameters(new ReportParameter("prmOrderTicketNumber", empty));
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			((Report)val).SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
		}
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
		((Report)val).SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey) ? " " : settingValueByKey));
		List<TransactionReceipt> list = (from x in gClass.TransactionReceipts
			where x.OrderNumber.Equals(CS_0024_003C_003E8__locals0.orderNumber) && x.MerchantReceipt.Contains("APPROVED")
			select x into y
			orderby y.DateCreated descending
			select y).ToList();
		string text5 = string.Empty;
		if (printPaymentTransaction && list != null && list.Count > 0)
		{
			foreach (TransactionReceipt item4 in list)
			{
				text5 += ((item4 != null) ? item4.CustomerReceipt : string.Empty);
			}
			text5 = text5.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
		}
		((Report)val).SetParameters(new ReportParameter("prmPaymentCardTransactionData", text5));
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("auto_gratuity");
		((Report)val).SetParameters(new ReportParameter("prmAutoGratuity", settingValueByKey2));
		((Report)val).SetParameters(new ReportParameter("prmLanguage", rlang));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
		string text6 = Resources.Tax_No + ":";
		if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
		{
			text6 = "";
		}
		((Report)val).SetParameters(new ReportParameter("prmLanguage_TaxNo", text6));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Order", Resources._Order));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_OrderType", Resources.Order_Type));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Time", Resources.Time));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Customer", Resources.Customer0));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Server", Resources.Server));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Cashier", "Cashier"));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Total", Resources.Total));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_YourShare", Resources.Your_Share_of_the_bill));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_DiscountReason", Resources.Discount_Reason));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_TaxChange", Resources.Tax_Change));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Tendered", Resources.Tendered));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Change", Resources.Change0));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_PaymentMethods", Resources.Payment_Methods));
		((Report)val).SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
		if (!(SettingsHelper.CurrentTerminalMode == "Kiosk") && !SettingsHelper.GetSettingValueByKey("now_serving_screen").Contains("ON") && !SettingsHelper.GetSettingValueByKey("use_order_ticket").Contains("ON"))
		{
			((Report)val).SetParameters(new ReportParameter("prmKiosk_Mode", "false"));
		}
		else
		{
			((Report)val).SetParameters(new ReportParameter("prmKiosk_Mode", "true"));
		}
		string text7 = "";
		if (gcValue >= 0m)
		{
			text7 = text7 + "GIFT CARD BAL: " + gcValue + "\n";
		}
		if (lcValue >= 0m)
		{
			text7 = text7 + "LOYALTY CARD BAL: " + lcValue + "\n";
		}
		((Report)val).SetParameters(new ReportParameter("prmGiftCardValue", text7));
		((Report)val).Refresh();
		for (int j = 0; j < splitBillEvenly; j++)
		{
			if (splitBillEvenly != 1 && j == splitBillEvenly - 1)
			{
				decimal num10 = orderToPrintReceipt.Sum((ReceiptOrder a) => a.Total);
				decimal num11 = num10 / (decimal)splitBillEvenly;
				decimal num12 = Math.Round(num11, 2) * (decimal)splitBillEvenly;
				if (num10 != num12)
				{
					((Report)val).SetParameters(new ReportParameter("prmSplitBillTotal", ((num10 > num12) ? (num11 + Convert.ToDecimal(0.01)) : (num11 - Convert.ToDecimal(0.01))).ToString()));
				}
			}
			if (savePath == null)
			{
				method_2(val);
				method_5(SettingsHelper.GetSettingValueByKey("receipt_size"), -1, bool_1: true);
			}
			else
			{
				method_2(val, "png");
				method_6(savePath);
			}
		}
		val.Dispose();
		GC.Collect();
	}

	public static void PrintReceiptCheck()
	{
		try
		{
			if (currentlyPrinting || MemoryLoadedObjects.ListOfReceiptsToPrint == null || !MemoryLoadedObjects.ListOfReceiptsToPrint.Any())
			{
				return;
			}
			_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
			currentlyPrinting = true;
			PrintHelper printHelper = new PrintHelper();
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_language");
			CS_0024_003C_003E8__locals0.tempVar = MemoryLoadedObjects.ListOfReceiptsToPrint.ToList();
			foreach (ReceiptPrintInfo item in CS_0024_003C_003E8__locals0.tempVar)
			{
				printHelper.PrintReceipt(settingValueByKey, item.orderNumber, item.printPaymentTransaction, item.splitBillEvenly, item.savePath, item.tipFlag, item.email, item.printerName, item.GCValue, item.LoyaltyValue);
			}
			MemoryLoadedObjects.ListOfReceiptsToPrint.RemoveAll((ReceiptPrintInfo a) => CS_0024_003C_003E8__locals0.tempVar.Contains(a));
			currentlyPrinting = false;
		}
		catch (Exception error)
		{
			currentlyPrinting = false;
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	public void GenerateRefundReceipt(string refundNumber)
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.refundNumber = refundNumber;
		_003C_003Ec__DisplayClass17_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass17_.rlang = SettingsHelper.GetSettingValueByKey("receipt_language");
		new Thread((ThreadStart)delegate
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Expected O, but got Unknown
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Expected O, but got Unknown
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_042d: Expected O, but got Unknown
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Expected O, but got Unknown
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Expected O, but got Unknown
			//IL_0462: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Expected O, but got Unknown
			//IL_0477: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Expected O, but got Unknown
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0496: Expected O, but got Unknown
			//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ab: Expected O, but got Unknown
			//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Expected O, but got Unknown
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d5: Expected O, but got Unknown
			//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f5: Expected O, but got Unknown
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_050a: Expected O, but got Unknown
			CultureInfo cultureInfo = new CultureInfo(_003C_003Ec__DisplayClass17_.rlang);
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
			LocalReport val = new LocalReport();
			GClass6 gClass = new GClass6();
			((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
			val.set_ReportEmbeddedResource("CorePOS.Reports.RefundReceipt.rdlc");
			List<Order> refundOrderToPrintReceipt = ReceiptMethods.GetRefundOrderToPrintReceipt(_003C_003Ec__DisplayClass17_.refundNumber);
			ReportDataSource val2 = new ReportDataSource("ReceiptDS", (IEnumerable)refundOrderToPrintReceipt);
			((Report)val).SetParameters(new ReportParameter("prmRefundNumber", _003C_003Ec__DisplayClass17_.refundNumber));
			((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val2);
			val2.set_Value((object)refundOrderToPrintReceipt);
			((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(_003C_003Ec__DisplayClass17_._003C_003E4__this.reportDataSource_0);
			_003C_003Ec__DisplayClass17_._003C_003E4__this.reportDataSource_0.set_Value((object)_003C_003Ec__DisplayClass17_._003C_003E4__this.companies);
			((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(_003C_003Ec__DisplayClass17_._003C_003E4__this.reportDataSource_1);
			_003C_003Ec__DisplayClass17_._003C_003E4__this.reportDataSource_1.set_Value((object)_003C_003Ec__DisplayClass17_._003C_003E4__this.list_0);
			List<RefundDS> refundDS = ReceiptMethods.GetRefundDS(_003C_003Ec__DisplayClass17_.refundNumber);
			ReportDataSource val3 = new ReportDataSource("RefundsDS", (IEnumerable)refundDS);
			((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val3);
			val3.set_Value((object)refundDS);
			bool flag = false;
			List<ReceiptOrder> list = ReceiptMethods.GetOrderToPrintReceipt(refundOrderToPrintReceipt.First().OrderNumber).ToList();
			if (list.All((ReceiptOrder a) => a.Void) && list.Count == refundOrderToPrintReceipt.Count)
			{
				flag = true;
			}
			string text = refundDS.FirstOrDefault().RefundPaymentMethod.ToUpper();
			((Report)val).SetParameters(new ReportParameter("prmTipAmount", ((!(text != Resources.CASH0) || !(text != "GIFT CERTIFICATE") || !(text != "COUPON") || !(text != "STORE CREDIT") || !flag) ? 0m : refundDS.FirstOrDefault().TipAmount).ToString("0.00;(0.00)")));
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				((Report)val).SetParameters(new ReportParameter("prmTrainingMode", Resources._TRAINING_MODE));
			}
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_footer_message");
			((Report)val).SetParameters(new ReportParameter("prmFooterMessage", string.IsNullOrEmpty(settingValueByKey) ? " " : settingValueByKey));
			string text2 = string.Empty;
			List<TransactionReceipt> list2 = (from x in gClass.TransactionReceipts
				where x.RefundNumber == _003C_003Ec__DisplayClass17_.refundNumber && x.MerchantReceipt.Contains("APPROVED")
				select x into y
				orderby y.DateCreated descending
				select y).ToList();
			short num = 0;
			bool flag2 = false;
			foreach (TransactionReceipt item in list2)
			{
				num = (short)(num + 1);
				if (num <= 2 && item.CustomerReceipt.Contains("VOID"))
				{
					flag2 = true;
				}
				text2 += item.CustomerReceipt;
			}
			text2 = text2.Replace("\u001a", " ").Replace("\u001b\u0017", "  ").Replace("\u001b\u0017\u001b\u001a", "    ")
				.Replace("\u001b", "  ");
			((Report)val).SetParameters(new ReportParameter("prmPaymentCardTransactionData", text2));
			((Report)val).SetParameters(new ReportParameter("prmRefundPaymentType", (flag2 ? "Void" : "Refund Payment") + " Method: " + text));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_RefundReceipt", Resources.REFUND_RECEIPT));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_RefundNumber", Resources.REFUND_NUMBER));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_Date", Resources._Date));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_QTY", Resources.QTY));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_ITEMS", Resources.ITEMS0));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_PRICE", Resources.PRICE0));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_Subtotal", Resources.Subtotal));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_Tax", Resources.Tax));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_RefundTotal", flag2 ? "Void Total" : Resources.Refund_Total));
			((Report)val).SetParameters(new ReportParameter("prmLanguage_PoweredBy", Resources.Powered_by_Hippos_Software));
			_003C_003Ec__DisplayClass17_._003C_003E4__this.method_2(val);
			_003C_003Ec__DisplayClass17_._003C_003E4__this.method_5(SettingsHelper.GetSettingValueByKey("receipt_size"), -1, bool_1: true);
			val.Dispose();
			GC.Collect();
		}).Start();
	}

	public void PrintAppointments(List<Appointment> appointments)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		LocalReport val = new LocalReport();
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
		val.set_ReportEmbeddedResource("CorePOS.Reports.AppointmentList.rdlc");
		ReportDataSource val2 = new ReportDataSource("AppointmentDS", (IEnumerable)appointments);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val2);
		val2.set_Value((object)appointments);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(reportDataSource_0);
		reportDataSource_0.set_Value((object)companies);
		method_2(val);
		method_5(SettingsHelper.GetSettingValueByKey("receipt_size"));
	}

	public DayEndTotalsObject GenerateDayEndTotalsHTML(DateTime startDate, DateTime endDate, int EmployeeId, int TerminalId)
	{
		_003C_003Ec__DisplayClass19_5 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.endDate = endDate;
		CS_0024_003C_003E8__locals0.startDate = startDate;
		CS_0024_003C_003E8__locals0.EmployeeId = EmployeeId;
		CS_0024_003C_003E8__locals0.TerminalId = TerminalId;
		DayEndTotalsObject dayEndTotalsObject = new DayEndTotalsObject();
		int num = 0;
		GClass6 gClass = new GClass6();
		string text = "<html><body><div style=\"text-align:center;padding-left:5pt;padding-right:5pt;\">%CompanyInfoDisplay%<div style=\"text-align:center;font-size:9pt;padding-bottom:5pt;\">%ReportInfo_For%</div><div style=\"text-align:left;font-size:9pt;\">Printed By:%ReportInfo_PrintedBy%</div><div style=\"text-align:left;font-size:9pt;\">%ReportInfo_PrintedDate%</div><div style=\"text-align:center;font-size:9pt;\">------------------------------</div><div style=\"text-align:left;\"><span style=\"float:left;font-size:9pt;\">Report For:</span><span style=\"float:right;font-weight:bold;font-size:10pt;\">%ReportInfo_Date%</span></div><div style=\"text-align:center;font-weight:bold;font-size:10pt;padding-bottom:5pt;\">%ReportInfo_TimeRange%</div><div style=\"text-align:left;font-size:8pt;\">%ReportInfo_Notice%</div><div style=\"text-align:center;font-size:9pt;\">------------------------------</div>%TenderSummaryDisplay%        %SalesSummaryDisplay%        %VoidSummaryDisplay%        %RefundSummaryDisplay%        %PayoutSummaryDisplay%        %OtherSummaryDisplay%        %EmployeeSummaryDisplay%        %TipShareSummaryDisplay%</div> <div style=\"text-align:center;\">** END OF REPORT **</div></body></html>";
		TextInfo textInfo = new CultureInfo("en-US", useUserOverride: false).TextInfo;
		string empty = string.Empty;
		string empty2 = string.Empty;
		int num2 = 0;
		decimal num3 = default(decimal);
		List<Order> source = ((CS_0024_003C_003E8__locals0.EmployeeId <= 0) ? gClass.Orders.Where((Order o) => o.DatePaid <= CS_0024_003C_003E8__locals0.endDate && o.DatePaid >= CS_0024_003C_003E8__locals0.startDate && ((o.Void == false && o.DateRefunded.HasValue == false) || (o.Void == true && o.DateRefunded.HasValue == true))).ToList() : gClass.Orders.Where((Order o) => o.DatePaid <= CS_0024_003C_003E8__locals0.endDate && o.DatePaid >= CS_0024_003C_003E8__locals0.startDate && o.UserCashout.Value == CS_0024_003C_003E8__locals0.EmployeeId && ((o.Void == false && o.DateRefunded.HasValue == false) || (o.Void == true && o.DateRefunded.HasValue == true))).ToList());
		OrderMethods orderMethods = new OrderMethods();
		List<OrderTipObject> list = (from a in source
			group a by a.OrderNumber into a
			select new OrderTipObject
			{
				OrderNumber = a.Key,
				Totals = a.Sum((Order b) => b.Total),
				PaymentMethod = a.First().PaymentMethods,
				OrderType = a.First().OrderType,
				UserCashout = (a.FirstOrDefault().UserServed.HasValue ? a.FirstOrDefault().UserServed : (a.FirstOrDefault().UserCashout.HasValue ? a.FirstOrDefault().UserCashout : a.FirstOrDefault().UserCreated)),
				StationTips = OrderMethods.GetListStationsTips(a.FirstOrDefault().TipShareDesc, a.Sum((Order b) => b.SubTotal), a.First().TipAmount),
				NetTip = a.FirstOrDefault().TipAmount - OrderMethods.GetStationsTipAmount(a.FirstOrDefault().TipShareDesc),
				TipAmount = a.OrderByDescending((Order b) => b.TipAmount).FirstOrDefault().TipAmount,
				IsEntireOrderRefunded = ((a.Count() == a.Where((Order b) => b.DateRefunded.HasValue).Count()) ? true : false)
			}).ToList();
		List<OrderTipObject> list2 = new List<OrderTipObject>();
		using (List<OrderTipObject>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
				CS_0024_003C_003E8__locals1.tipOrder = enumerator.Current;
				List<usp_ClosingTotalsResult> totalPaymentsByMethod = orderMethods.getTotalPaymentsByMethod(source.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals1.tipOrder.OrderNumber).ToList());
				decimal num4 = default(decimal);
				if (Math.Round(CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount, 2) > totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value))
				{
					if (Math.Round(CS_0024_003C_003E8__locals1.tipOrder.Totals, 2) < totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value))
					{
						num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount);
						if (Math.Abs(num4) < 0.03m)
						{
							CS_0024_003C_003E8__locals1.tipOrder.TipAmount += num4;
							continue;
						}
						num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - CS_0024_003C_003E8__locals1.tipOrder.Totals;
						if (Math.Abs(num4) < 0.03m)
						{
							CS_0024_003C_003E8__locals1.tipOrder.TipAmount += num4;
							continue;
						}
						decimal num5 = Math.Abs(Math.Round(totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount), 2));
						list2.Add(new OrderTipObject
						{
							NetTip = CS_0024_003C_003E8__locals1.tipOrder.NetTip - num5,
							IsEntireOrderRefunded = CS_0024_003C_003E8__locals1.tipOrder.IsEntireOrderRefunded,
							OrderType = CS_0024_003C_003E8__locals1.tipOrder.OrderType,
							StationTips = CS_0024_003C_003E8__locals1.tipOrder.StationTips,
							Totals = CS_0024_003C_003E8__locals1.tipOrder.Totals,
							OrderNumber = CS_0024_003C_003E8__locals1.tipOrder.OrderNumber,
							UserCashout = CS_0024_003C_003E8__locals1.tipOrder.UserCashout,
							PaymentMethod = "CASH",
							TipAmount = num5
						});
						if (CS_0024_003C_003E8__locals1.tipOrder.TipAmount > num5)
						{
							CS_0024_003C_003E8__locals1.tipOrder.TipAmount -= num5;
							CS_0024_003C_003E8__locals1.tipOrder.NetTip -= num5;
						}
					}
					else
					{
						if (!(Math.Round(CS_0024_003C_003E8__locals1.tipOrder.Totals, 2) != totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value)))
						{
							continue;
						}
						num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount);
						if (Math.Abs(num4) < 0.03m)
						{
							CS_0024_003C_003E8__locals1.tipOrder.TipAmount += num4;
							continue;
						}
						num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - CS_0024_003C_003E8__locals1.tipOrder.Totals;
						if (Math.Abs(num4) < 0.03m)
						{
							CS_0024_003C_003E8__locals1.tipOrder.TipAmount += num4;
						}
					}
				}
				else if (totalPaymentsByMethod.Count > 0 && Math.Round(CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount, 2) < totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value))
				{
					num4 = totalPaymentsByMethod.Sum((usp_ClosingTotalsResult a) => a.Total.Value) - (CS_0024_003C_003E8__locals1.tipOrder.Totals + CS_0024_003C_003E8__locals1.tipOrder.TipAmount);
					CS_0024_003C_003E8__locals1.tipOrder.TipAmount += num4;
				}
			}
		}
		list.AddRange(list2);
		empty2 = string.Empty;
		if (SettingsHelper.GetSettingValueByKey("eodreport_company_info") == "ON")
		{
			empty2 = "<div style=\"text-align:center;font-size:12pt;font-weight:bold;\">%CompanyName%</div><div style=\"text-align:center;font-size:9pt;font-weight:bold;\">%CompanyAddress1%</div><div style=\"text-align:center;font-size:9pt;font-weight:bold;\">%CompanyAddress2%</div><div style=\"text-align:center;font-size:9pt;font-weight:bold;\">%CompanyTax%</div><div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			empty2 = empty2.Replace("%CompanyName%", CompanyHelper.CompanyDataSetup.Name);
			string address = CompanyHelper.CompanyDataSetup.Address1;
			string newValue = CompanyHelper.CompanyDataSetup.City + ", " + CompanyHelper.CompanyDataSetup.StateProv + ", " + CompanyHelper.CompanyDataSetup.ZIP;
			empty2 = empty2.Replace("%CompanyAddress1%", address);
			empty2 = empty2.Replace("%CompanyAddress2%", newValue);
			string newValue2 = (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0) ? string.Empty : (Resources.Tax_No + ":" + CompanyHelper.CompanyDataSetup.String_0));
			empty2 = empty2.Replace("%CompanyTax%", newValue2);
		}
		text = text.Replace("%CompanyInfoDisplay%", empty2);
		num += 1000;
		string text2 = "All Terminals";
		if (CS_0024_003C_003E8__locals0.TerminalId != -1)
		{
			if (CS_0024_003C_003E8__locals0.TerminalId == 0)
			{
				text2 = "No Terminals";
			}
			else
			{
				Terminal terminal = MemoryLoadedObjects.all_terminals.Where((Terminal a) => a.TerminalID == CS_0024_003C_003E8__locals0.TerminalId).FirstOrDefault();
				if (terminal != null)
				{
					text2 = terminal.SystemName;
				}
			}
		}
		text2 += " Sales";
		if (CS_0024_003C_003E8__locals0.EmployeeId != 0)
		{
			Employee employee = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals0.EmployeeId).FirstOrDefault();
			if (employee != null)
			{
				text2 = text2 + " For " + employee.FirstName + " " + employee.LastName;
			}
		}
		string newValue3 = string.Empty;
		if (CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0")
		{
			Employee employee2 = MemoryLoadedObjects.all_employees.Where((Employee a) => a.EmployeeID.ToString() == CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()).FirstOrDefault();
			newValue3 = employee2.FirstName + " " + employee2.LastName;
		}
		text = text.Replace("%ReportInfo_For%", text2);
		text = text.Replace("%ReportInfo_PrintedBy%", newValue3);
		text = text.Replace("%ReportInfo_PrintedDate%", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
		string newValue4 = CS_0024_003C_003E8__locals0.startDate.ToString("MM/dd/yyyy");
		if (CS_0024_003C_003E8__locals0.startDate.Date != CS_0024_003C_003E8__locals0.endDate.Date)
		{
			newValue4 = "<br><div style=\"text-align:center;font-weight:bold;font-size:10pt;\">" + CS_0024_003C_003E8__locals0.startDate.ToString("MM/dd/yyyy") + " - " + CS_0024_003C_003E8__locals0.endDate.ToString("MM/dd/yyyy") + "</div>";
		}
		text = text.Replace("%ReportInfo_Date%", newValue4);
		text = text.Replace("%ReportInfo_TimeRange%", CS_0024_003C_003E8__locals0.startDate.ToShortTimeString() + " - " + CS_0024_003C_003E8__locals0.endDate.ToShortTimeString());
		text = text.Replace("%ReportInfo_Notice%", Resources.Notice_Orders_paid_before);
		num += 500;
		IQueryable<Refund> source2 = gClass.Refunds.Where((Refund a) => a.DateCreated <= CS_0024_003C_003E8__locals0.endDate && a.DateCreated >= CS_0024_003C_003E8__locals0.startDate);
		empty2 = (empty = string.Empty);
		if (SettingsHelper.GetSettingValueByKey("eodreport_tender_summary") == "ON")
		{
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">TENDER SUMMARY</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;\">Sales</div><div style=\"text-align:left;\">%SalesTenderSummary%</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;\">Refund</div><div style=\"text-align:left;\">%RefundTenderSummary%</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;\">Net</div><div style=\"text-align:left;\">%NetTenderSummary%</div>";
			List<usp_ClosingTotalsResult> list3 = DayEndClosingMethods.getDayEndTotals().ToList();
			foreach (usp_ClosingTotalsResult item4 in list3.OrderBy((usp_ClosingTotalsResult x) => (!x.Name.ToUpper().Contains("TIPS")) ? x.Name : "Z"))
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				string text3 = textInfo.ToTitleCase(item4.Name.ToLower());
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item4.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item4.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				if (!item4.Name.ToUpper().Contains("TIPS:"))
				{
					num2 += item4.Qty.Value;
					num3 += item4.Total.Value;
				}
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Sales:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num3.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty2 = empty2.Replace("%SalesTenderSummary%", empty);
			num += 100;
			List<usp_ClosingTotalsResult> list4;
			if (CS_0024_003C_003E8__locals0.EmployeeId != 0)
			{
				source2 = source2.Where((Refund a) => a.EmployeeID == (int?)CS_0024_003C_003E8__locals0.EmployeeId || (int?)a.Order.UserCashout == (int?)CS_0024_003C_003E8__locals0.EmployeeId || (int?)a.Order.UserServed == (int?)CS_0024_003C_003E8__locals0.EmployeeId || (int?)a.Order.UserCreated == (int?)CS_0024_003C_003E8__locals0.EmployeeId);
				list4 = (from a in source2
					group a by a.PaymentMethod into g
					select new usp_ClosingTotalsResult
					{
						Name = g.FirstOrDefault().PaymentMethod,
						Qty = (from a in g
							group a by a.RefundNumber).Count(),
						Total = g.Sum((Refund a) => a.Order.Total)
					} into x
					orderby x.Name
					select x).ToList();
			}
			else
			{
				list4 = (from a in source2
					group a by a.PaymentMethod into g
					select new usp_ClosingTotalsResult
					{
						Name = g.FirstOrDefault().PaymentMethod,
						Qty = (from a in g
							group a by a.RefundNumber).Count(),
						Total = g.Sum((Refund a) => a.Order.Total)
					} into x
					orderby x.Name
					select x).ToList();
			}
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			foreach (usp_ClosingTotalsResult item5 in list4)
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				string text3 = textInfo.ToTitleCase(item5.Name.ToLower());
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item5.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item5.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				num2 += item5.Qty.Value;
				num3 += item5.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Refunds:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num3.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty2 = empty2.Replace("%RefundTenderSummary%", empty);
			num += 100;
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			List<usp_ClosingTotalsResult> first = (from l2 in list4
				join l1 in list3 on l2.Name.ToUpper() equals l1.Name.ToUpper() into temp
				from l1 in temp.DefaultIfEmpty()
				select new usp_ClosingTotalsResult
				{
					Name = l2.Name,
					Qty = ((l1 != null) ? l1.Qty : new int?(0)) + ((l2 != null) ? l2.Qty : new int?(0)),
					Total = ((l1 != null) ? l1.Total : new decimal?(default(decimal))) - l2.Total
				}).ToList();
			List<usp_ClosingTotalsResult> second = (from l1 in list3
				join l2 in list4 on l1.Name.ToUpper() equals l2.Name.ToUpper() into temp
				from l2 in temp.DefaultIfEmpty()
				select new usp_ClosingTotalsResult
				{
					Name = l1.Name,
					Qty = l1.Qty + ((l2 != null) ? l2.Qty : new int?(0)),
					Total = l1.Total - ((l2 != null) ? l2.Total : new decimal?(default(decimal)))
				}).ToList();
			List<usp_ClosingTotalsResult> source3 = (from a in first.Union(second)
				group a by a.Name.ToUpper() into a
				select a.FirstOrDefault()).ToList();
			usp_ClosingTotalsResult usp_ClosingTotalsResult = source3.Where((usp_ClosingTotalsResult x) => x.Name.ToUpper().Trim().Equals("TIPS: OTHER")).FirstOrDefault();
			if (usp_ClosingTotalsResult != null)
			{
				usp_ClosingTotalsResult.Name = "CASH LESS TIPS";
			}
			foreach (usp_ClosingTotalsResult item6 in from x in source3
				where !x.Name.ToUpper().Contains("TIPS:")
				orderby x.Name
				select x)
			{
				if (item6.Name.ToUpper() == "CASH LESS TIPS")
				{
					usp_ClosingTotalsResult usp_ClosingTotalsResult2 = source3.Where((usp_ClosingTotalsResult a) => a.Name.ToUpper() == "CASH").FirstOrDefault();
					if (usp_ClosingTotalsResult2 != null)
					{
						item6.Total = usp_ClosingTotalsResult2.Total.Value - item6.Total.Value;
					}
					else
					{
						if (!(item6.Total.Value > 0m))
						{
							continue;
						}
						item6.Total = 0m - item6.Total.Value;
					}
				}
				empty += "<span style=\"float:left;font-size:9pt;padding-bottom:5pt;\">";
				string text3 = textInfo.ToTitleCase(item6.Name.ToLower());
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item6.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item6.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				if (item6.Name.ToUpper() != "CASH LESS TIPS")
				{
					num2 += item6.Qty.Value;
					num3 += item6.Total.Value;
				}
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;\">";
			empty += method_1("Net Tenders:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num3.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty2 = empty2.Replace("%NetTenderSummary%", empty);
			num += 100;
		}
		text = text.Replace("%TenderSummaryDisplay%", empty2);
		empty2 = (empty = string.Empty);
		if (SettingsHelper.GetSettingValueByKey("eodreport_sales_summary") == "ON")
		{
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">SALES SUMMARY</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;\">Sales</div><div style=\"text-align:left;\">%SalesSummary%</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;padding-top:5pt;\">Discounts</div><div style=\"text-align:left;\">%DiscountsSummary%</div><div style=\"text-align:left;font-size:11pt;font-weight:bold;padding-top:5pt;\">Taxes</div><div style=\"text-align:left;padding-bottom:5pt\">%TaxesSummary%</div>";
			List<usp_ClosingTotalsResult> source4 = (from a in source
				where !a.Void || (a.Void && a.DateRefunded.HasValue)
				select a into x
				group x by x.GroupName into x
				select new usp_ClosingTotalsResult
				{
					Name = (string.IsNullOrEmpty(x.FirstOrDefault().GroupName) ? x.FirstOrDefault().ItemName : x.FirstOrDefault().GroupName),
					Qty = x.Sum((Order a) => (int)a.Qty),
					Total = x.Sum((Order z) => z.SubTotal + z.Discount)
				}).ToList();
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			decimal num6 = default(decimal);
			decimal num7 = default(decimal);
			decimal num8 = default(decimal);
			string text3;
			foreach (usp_ClosingTotalsResult item7 in from x in source4.Where(delegate(usp_ClosingTotalsResult x)
				{
					decimal? total2 = x.Total;
					return ((total2.GetValueOrDefault() >= default(decimal)) & total2.HasValue) || x.Name.Contains("Cash Rounding");
				})
				orderby x.Total descending
				select x)
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				text3 = textInfo.ToTitleCase(item7.Name.ToLower());
				if (text3.Contains("-"))
				{
					empty += " ";
				}
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item7.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item7.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				if (!item7.Name.Contains("Cash Rounding"))
				{
					num2 += item7.Qty.Value;
				}
				num6 += item7.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Sales:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num6.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty2 = empty2.Replace("%SalesSummary%", empty);
			num += 100;
			List<usp_ClosingTotalsResult> source5 = (from x in source
				where x.DiscountDesc != null && x.DiscountDesc != string.Empty && !x.Void
				group x by x.DiscountReason into x
				select new usp_ClosingTotalsResult
				{
					Name = ((x.FirstOrDefault().DiscountReason == null) ? "NO REASON GIVEN" : x.FirstOrDefault().DiscountReason.ToLower()),
					Qty = (from z in x
						group z by z.DiscountReason).Count(),
					Total = x.Sum((Order z) => z.Discount)
				}).ToList();
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			foreach (usp_ClosingTotalsResult item8 in from x in source5.Where(delegate(usp_ClosingTotalsResult x)
				{
					decimal? total = x.Total;
					return ((total.GetValueOrDefault() >= default(decimal)) & total.HasValue) || x.Name.Contains("Cash Rounding");
				})
				orderby x.Total descending
				select x)
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				text3 = textInfo.ToTitleCase((item8.Name == null) ? "NO REASON GIVEN" : item8.Name.ToLower());
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item8.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item8.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				if (!item8.Name.Contains("Cash Rounding"))
				{
					num2 += item8.Qty.Value;
				}
				num7 += item8.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Discounts:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num7.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty2 = empty2.Replace("%DiscountsSummary%", empty);
			num += 100;
			ReceiptMethods.ParseDayEndTaxTotals(CS_0024_003C_003E8__locals0.startDate, CS_0024_003C_003E8__locals0.endDate, CS_0024_003C_003E8__locals0.EmployeeId, CS_0024_003C_003E8__locals0.TerminalId);
			List<usp_ClosingTotalsResult> source6 = DayEndClosingMethods.getDayEndTotals().ToList();
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			foreach (usp_ClosingTotalsResult item9 in source6.OrderByDescending((usp_ClosingTotalsResult x) => x.Total))
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				text3 = item9.Name.ToUpper();
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(" ", 4, bool_1: false);
				empty += method_1("$ " + item9.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				num2 += item9.Qty.Value;
				num8 += item9.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Sales Tax:", 13);
			empty += method_1(" ", 4, bool_1: false);
			empty += method_1("$ " + num8.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			decimal num9 = source2.Select((Refund a) => new OrderTotal
			{
				Tax = a.Order.TaxTotal,
				Sub = a.Order.SubTotal
			}).ToList().Sum((OrderTotal a) => a.Tax);
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Refunded Tax:", 13);
			empty += method_1(" ", 4, bool_1: false);
			empty += method_1("$ " + (-num9).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Net Tax:", 13);
			empty += method_1(" ", 4, bool_1: false);
			empty += method_1("$ " + (num8 - num9).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-size:9pt;\">";
			text3 = textInfo.ToTitleCase("NET SALES");
			decimal num10 = num6 - num7;
			empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
			empty += method_1("", 4, bool_1: false);
			empty += method_1("$ " + num10.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;\">";
			empty += method_1("NET SALES INC. TAX", 18);
			empty += method_1("$ " + (num10 + num8).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			decimal num11 = default(decimal);
			if (gClass.Refunds.Where((Refund o) => o.DateCreated <= CS_0024_003C_003E8__locals0.endDate && o.DateCreated >= CS_0024_003C_003E8__locals0.startDate).Count() > 0)
			{
				num11 = (from o in gClass.Refunds
					where o.DateCreated <= CS_0024_003C_003E8__locals0.endDate && o.DateCreated >= CS_0024_003C_003E8__locals0.startDate
					select o into a
					select a.AmountRefunded).Sum();
			}
			empty += "</span>";
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;\">";
			empty += method_1("GROSS SALES - REFUNDS", 18);
			empty += method_1("$ " + (num10 + num8 - num11).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty2 = empty2.Replace("%TaxesSummary%", empty);
			num += 100;
		}
		text = text.Replace("%SalesSummaryDisplay%", empty2);
		empty2 = string.Empty;
		if (SettingsHelper.GetSettingValueByKey("eodreport_void_summary") == "ON")
		{
			_003C_003Ec__DisplayClass19_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass19_2();
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">VOID SUMMARY</div><div style=\"text-align:left;\">%VoidSummary%</div>";
			List<Order> source7 = gClass.Orders.Where((Order o) => o.DateCreated <= CS_0024_003C_003E8__locals0.endDate && o.DateCreated >= CS_0024_003C_003E8__locals0.startDate && o.Void == true && o.DateRefunded.HasValue == false).ToList();
			CS_0024_003C_003E8__locals2.voidedOrdersByOrderNum = (from x in source7
				group x by x.OrderNumber into x
				select new Order
				{
					VoidReason = x.FirstOrDefault().VoidReason,
					OrderNumber = x.Key
				}).ToList();
			List<usp_ClosingTotalsResult> source8 = (from x in source7
				group x by x.VoidReason).Select(delegate(IGrouping<string, Order> x)
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_3();
				CS_0024_003C_003E8__locals0.x = x;
				return new usp_ClosingTotalsResult
				{
					Name = CS_0024_003C_003E8__locals0.x.FirstOrDefault().VoidReason,
					Qty = CS_0024_003C_003E8__locals2.voidedOrdersByOrderNum.Where((Order a) => a.VoidReason == CS_0024_003C_003E8__locals0.x.Key).Count(),
					Total = CS_0024_003C_003E8__locals0.x.Sum((Order z) => z.SubTotal)
				};
			}).ToList();
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			foreach (usp_ClosingTotalsResult item10 in source8.OrderByDescending((usp_ClosingTotalsResult x) => x.Total))
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				string text3 = (string.IsNullOrEmpty(item10.Name) ? "No Reason Given" : textInfo.ToTitleCase(item10.Name.ToLower()));
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item10.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item10.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				num2 += item10.Qty.Value;
				num3 += item10.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Voids:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num3.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty2 = empty2.Replace("%VoidSummary%", empty);
		}
		text = text.Replace("%VoidSummaryDisplay%", empty2);
		if (SettingsHelper.GetSettingValueByKey("eodreport_refund_summary") == "ON")
		{
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">REFUND SUMMARY</div><div style=\"text-align:left;\">%RefundSummary%</div>";
			List<usp_ClosingTotalsResult> source9 = (from x in source2
				group x by x.RefundReason into x
				select new usp_ClosingTotalsResult
				{
					Name = x.FirstOrDefault().RefundReason,
					Qty = (from z in x
						group z by z.RefundReason).Count(),
					Total = x.Sum((Refund z) => z.AmountRefunded)
				}).ToList();
			List<OrderTotal> source10 = source2.Select((Refund a) => new OrderTotal
			{
				Tax = a.Order.TaxTotal,
				Sub = a.Order.SubTotal
			}).ToList();
			empty = string.Empty;
			num2 = 0;
			num3 = default(decimal);
			foreach (usp_ClosingTotalsResult item11 in source9.OrderByDescending((usp_ClosingTotalsResult x) => x.Total))
			{
				empty += "<span style=\"float:left;font-size:9pt;\">";
				string text3 = textInfo.ToTitleCase(item11.Name.ToLower());
				empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
				empty += method_1(item11.Qty.ToString(), 4, bool_1: false);
				empty += method_1("$ " + item11.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				num2 += item11.Qty.Value;
				num3 += item11.Total.Value;
				num += 100;
			}
			empty += "<div style=\"text-align:center;font-size:9pt;\">------------------------------</div>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Net Refunds:", 13);
			empty += method_1("", 4, bool_1: false);
			empty += method_1("$ " + source10.Sum((OrderTotal a) => a.Sub).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Refund Taxes:", 13);
			empty += method_1("", 4, bool_1: false);
			empty += method_1("$ " + source10.Sum((OrderTotal a) => a.Tax).ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty += "<span style=\"float:left;font-weight:bold;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1("Total Refunds:", 13);
			empty += method_1(num2.ToString(), 4, bool_1: false);
			empty += method_1("$ " + num3.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
			empty2 = empty2.Replace("%RefundSummary%", empty);
		}
		text = text.Replace("%RefundSummaryDisplay%", empty2);
		empty2 = string.Empty;
		if (SettingsHelper.GetSettingValueByKey("eodreport_payout_summary") == "ON")
		{
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">PAYOUT SUMMARY</div><div style=\"text-align:left;\">%PayoutInformationSummary%</div>";
			List<usp_ClosingTotalsResult> list5 = (from o in gClass.Payouts
				where o.DateCreated <= CS_0024_003C_003E8__locals0.endDate && o.DateCreated >= CS_0024_003C_003E8__locals0.startDate && o.Reason != PayoutTypes.OpeningBalance && o.Reason != PayoutTypes.ClosingBalance
				select o into a
				group a by a.Reason into a
				select new usp_ClosingTotalsResult
				{
					Name = a.Key,
					Total = a.Sum((Payout b) => b.Amount)
				}).ToList();
			List<Payout> list6 = gClass.Payouts.Where((Payout a) => (a.Reason == PayoutTypes.OpeningBalance || a.Reason == PayoutTypes.ClosingBalance) && a.DateCreated >= CS_0024_003C_003E8__locals0.startDate.AddHours(-2.0) && a.DateCreated <= CS_0024_003C_003E8__locals0.endDate.Date.AddDays(1.0)).ToList();
			if (list6 != null && list6.Count > 0)
			{
				usp_ClosingTotalsResult usp_ClosingTotalsResult3 = (from a in list6
					where a.Reason == PayoutTypes.OpeningBalance
					orderby a.DateCreated descending
					select new usp_ClosingTotalsResult
					{
						Name = a.Reason,
						Total = a.Amount
					}).FirstOrDefault();
				if (usp_ClosingTotalsResult3 != null)
				{
					list5.Add(usp_ClosingTotalsResult3);
				}
				usp_ClosingTotalsResult usp_ClosingTotalsResult4 = (from a in list6
					where a.Reason == PayoutTypes.ClosingBalance
					orderby a.DateCreated descending
					select new usp_ClosingTotalsResult
					{
						Name = a.Reason,
						Total = a.Amount
					}).FirstOrDefault();
				if (usp_ClosingTotalsResult4 != null)
				{
					list5.Add(usp_ClosingTotalsResult4);
				}
			}
			empty = string.Empty;
			foreach (usp_ClosingTotalsResult item12 in list5)
			{
				empty += "<span style=\"float:left;font-size:9pt;padding-bottom:5pt;\">";
				empty += method_1(item12.Name, 18);
				empty += method_1("$ " + item12.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
				empty += "</span>";
				num += 100;
			}
			empty2 = empty2.Replace("%PayoutInformationSummary%", empty);
		}
		text = text.Replace("%PayoutSummaryDisplay%", empty2);
		empty2 = string.Empty;
		List<usp_ClosingTotalsResult> list7;
		usp_ClosingTotalsResult obj;
		decimal value;
		if (SettingsHelper.GetSettingValueByKey("eodreport_other_info") == "ON")
		{
			empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">OTHER INFORMATION</div><div style=\"text-align:left;\">%OtherInformationSummary%</div>";
			empty = string.Empty;
			num2 = 0;
			num3 = ((source.Count() > 0) ? source.Sum((Order x) => x.Total) : 0m);
			list7 = new List<usp_ClosingTotalsResult>();
			usp_ClosingTotalsResult usp_ClosingTotalsResult5 = new usp_ClosingTotalsResult
			{
				Name = "Customer Count",
				Qty = ((source.Count() > 0) ? (from x in source
					group x by new { x.OrderNumber, x.GuestCount }).Sum(y => y.Key.GuestCount) : 0),
				Total = default(decimal)
			};
			list7.Add(usp_ClosingTotalsResult5);
			obj = new usp_ClosingTotalsResult
			{
				Name = "Avg. Sale/Customer",
				Qty = 0
			};
			if (!(num3 == 0m))
			{
				int? qty = usp_ClosingTotalsResult5.Qty;
				int num12 = 0;
				if (!((qty.GetValueOrDefault() == 0) & qty.HasValue))
				{
					value = Math.Round(num3 / (decimal)usp_ClosingTotalsResult5.Qty.Value, 2);
					goto IL_3d92;
				}
			}
			value = 0m;
			goto IL_3d92;
		}
		goto IL_442f;
		IL_3d92:
		obj.Total = value;
		usp_ClosingTotalsResult item = obj;
		list7.Add(item);
		usp_ClosingTotalsResult usp_ClosingTotalsResult6 = new usp_ClosingTotalsResult
		{
			Name = "Trans Count",
			Qty = (from x in source
				group x by x.OrderNumber).Count(),
			Total = default(decimal)
		};
		list7.Add(usp_ClosingTotalsResult6);
		usp_ClosingTotalsResult obj2 = new usp_ClosingTotalsResult
		{
			Name = "Avg. Sale/Trans",
			Qty = 0
		};
		decimal value2;
		if (!(num3 == 0m))
		{
			int? qty = usp_ClosingTotalsResult6.Qty;
			int num12 = 0;
			if (!((qty.GetValueOrDefault() == 0) & qty.HasValue))
			{
				value2 = Math.Round(num3 / (decimal)usp_ClosingTotalsResult6.Qty.Value, 2);
				goto IL_3e7f;
			}
		}
		value2 = 0m;
		goto IL_3e7f;
		IL_442f:
		text = text.Replace("%OtherSummaryDisplay%", empty2);
		empty2 = string.Empty;
		if (SettingsHelper.GetSettingValueByKey("eodreport_employee_summary") == "ON" || SettingsHelper.GetSettingValueByKey("eodreport_tipshare_summary") == "ON")
		{
			_003C_003Ec__DisplayClass19_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass19_4();
			if (CS_0024_003C_003E8__locals0.EmployeeId != 0)
			{
				source.Where((Order a) => a.UserCashout.HasValue && a.UserCashout.Value == CS_0024_003C_003E8__locals0.EmployeeId).ToList();
			}
			List<DayEndTipObject> list8 = new List<DayEndTipObject>();
			CS_0024_003C_003E8__locals3.employees = MemoryLoadedObjects.all_employees;
			list8 = (from a in (from a in list
					group a by a.UserCashout).Select(delegate(IGrouping<short?, OrderTipObject> a)
				{
					CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_5();
					CS_0024_003C_003E8__locals0.a = a;
					return new DayEndTipObject
					{
						Name = ((CS_0024_003C_003E8__locals0.a.Key.HasValue && CS_0024_003C_003E8__locals0.a.Key.Value > 0 && CS_0024_003C_003E8__locals3.employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.a.Key.Value).FirstOrDefault() != null) ? (CS_0024_003C_003E8__locals3.employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.a.Key.Value).First().FirstName + " " + CS_0024_003C_003E8__locals3.employees.Where((Employee e) => e.EmployeeID == CS_0024_003C_003E8__locals0.a.Key.Value).First().LastName) : (CS_0024_003C_003E8__locals0.a.FirstOrDefault().OrderType.ToUpper().Contains("ONLINE") ? "Online Sales" : "Patron")),
						TotalOrders = (from z in CS_0024_003C_003E8__locals0.a
							group z by z.OrderNumber).Count(),
						TotalSales = CS_0024_003C_003E8__locals0.a.Sum((OrderTipObject b) => b.Totals),
						TotalTip = CS_0024_003C_003E8__locals0.a.Sum((OrderTipObject b) => b.TipAmount),
						RefundedTip = CS_0024_003C_003E8__locals0.a.Where((OrderTipObject b) => b.IsEntireOrderRefunded).Sum((OrderTipObject b) => b.TipAmount),
						TotalStationTips = CS_0024_003C_003E8__locals0.a.Sum((OrderTipObject b) => b.StationTips.Sum((StationTipObject c) => c.TipAmount))
					};
				})
				orderby a.Name
				select a).ToList();
			if (SettingsHelper.GetSettingValueByKey("eodreport_employee_summary") == "ON")
			{
				empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">EMPLOYEE SUMMARY</div><div style=\"text-align:left;\">%EmployeeSummary%</div>";
				empty = string.Empty;
				int int_ = 18;
				foreach (DayEndTipObject item13 in list8)
				{
					item13.NetTip = item13.TotalTip - item13.RefundedTip - item13.TotalStationTips;
					empty = empty + "<div style=\"float:left;font-size:10pt;font-weight:bold;\">" + textInfo.ToTitleCase(item13.Name.ToLower()) + "</div>";
					empty += "<span style=\"float:left;font-size:9pt;padding-bottom:5pt;\">";
					empty += method_1("Total Orders", 13);
					empty += method_1(item13.TotalOrders.ToString(), 4, bool_1: false);
					empty += "</span>";
					empty += "<span style=\"float:left;font-size:9pt;\">";
					empty += method_1("Total Sales", int_);
					empty += method_1("$ " + item13.TotalSales.ToString("0.00;(0.00)"), 10, bool_1: false);
					empty += "</span>";
					empty += "<span style=\"float:left;font-size:9pt;\">";
					empty += method_1("Total Tips", int_);
					empty += method_1("$ " + item13.TotalTip.ToString("0.00;(0.00)"), 10, bool_1: false);
					empty += "</span>";
					empty += "<span style=\"float:left;font-size:9pt;\">";
					empty += method_1("Refunded Tips", 17);
					empty += method_1("$ " + (-item13.RefundedTip).ToString("0.00;(0.00)"), 10, bool_1: false);
					empty += "</span>";
					empty += "<span style=\"float:left;font-size:9pt;\">";
					empty += method_1("Shared Tips", 17);
					empty += method_1("$ " + item13.TotalStationTips.ToString("0.00;(0.00)"), 10, bool_1: false);
					empty += "</span>";
					empty += "<span style=\"float:left;font-size:9pt;\">";
					empty += method_1("Net Tips", int_);
					empty += method_1("$ " + item13.NetTip.ToString("0.00;(0.00)"), 10, bool_1: false);
					empty += "</span>";
					num += 600;
				}
				empty2 = empty2.Replace("%EmployeeSummary%", empty);
			}
			text = text.Replace("%EmployeeSummaryDisplay%", empty2);
			empty2 = string.Empty;
			if (SettingsHelper.GetSettingValueByKey("eodreport_tipshare_summary") == "ON")
			{
				empty2 = "<div style=\"text-align:left;font-size:12pt;font-weight:bold;padding-top:5pt;\">TIP SHARE SUMMARY</div><div style=\"text-align:left;\">%TipShareSummary%</div>";
				List<StationTipObject> list9 = new List<StationTipObject>();
				if (list != null && list.Count() > 0)
				{
					list9 = (from a in list.Where((OrderTipObject a) => !a.IsEntireOrderRefunded).SelectMany((OrderTipObject a) => a.StationTips).ToList()
						group a by new { a.StatioName, a.TipPercentage } into a
						select new StationTipObject
						{
							StatioName = a.Key.StatioName,
							TipAmount = a.Sum((StationTipObject b) => b.TipAmount),
							TipPercentage = a.Key.TipPercentage
						}).ToList();
				}
				empty = string.Empty;
				if (list9.Count() > 0)
				{
					foreach (StationTipObject item14 in list9)
					{
						empty += "<span style=\"float:left;font-size:9pt;padding-bottom:5pt;\">";
						empty += method_1(textInfo.ToTitleCase(item14.StatioName.ToLower()), 13);
						empty += method_1(item14.TipPercentage.ToString(), 4, bool_1: false);
						empty += method_1("$ " + item14.TipAmount.ToString("0.00;(0.00)"), 10, bool_1: false);
						empty += "</span>";
						num += 100;
					}
				}
				else
				{
					empty = "No Tip Share Info";
				}
				empty2 = empty2.Replace("%TipShareSummary%", empty);
			}
			text = text.Replace("%TipShareSummaryDisplay%", empty2);
		}
		dayEndTotalsObject.DayEndHtml = text;
		dayEndTotalsObject.PaperHeight = num;
		return dayEndTotalsObject;
		IL_3e7f:
		obj2.Total = value2;
		usp_ClosingTotalsResult item2 = obj2;
		list7.Add(item2);
		usp_ClosingTotalsResult usp_ClosingTotalsResult7 = new usp_ClosingTotalsResult
		{
			Name = "Total Tips",
			Qty = 0,
			Total = list.Sum((OrderTipObject a) => a.TipAmount)
		};
		list7.Add(usp_ClosingTotalsResult7);
		usp_ClosingTotalsResult usp_ClosingTotalsResult8 = new usp_ClosingTotalsResult
		{
			Name = "Refunded Tips",
			Qty = 0,
			Total = -list.Where((OrderTipObject a) => a.IsEntireOrderRefunded).Sum((OrderTipObject a) => a.TipAmount)
		};
		list7.Add(usp_ClosingTotalsResult8);
		usp_ClosingTotalsResult item3 = new usp_ClosingTotalsResult
		{
			Name = "Net Tips",
			Qty = 0,
			Total = usp_ClosingTotalsResult7.Total - usp_ClosingTotalsResult8.Total
		};
		list7.Add(item3);
		foreach (usp_ClosingTotalsResult item15 in list7)
		{
			empty += "<span style=\"float:left;font-size:9pt;\">";
			string text3 = textInfo.ToTitleCase(item15.Name.ToLower());
			empty += method_1((text3.Length > 13) ? text3.Substring(0, 13) : text3, 13);
			string text4 = empty;
			int? qty = item15.Qty;
			int num12 = 0;
			empty = text4 + method_1((qty > 0) ? item15.Qty.ToString() : " ", 4, bool_1: false);
			string text5 = empty;
			qty = item15.Qty;
			num12 = 0;
			empty = text5 + method_1((qty > 0) ? " " : ("$ " + item15.Total.Value.ToString("0.00;(0.00)")), 10, bool_1: false);
			empty += "</span>";
			num += 100;
		}
		foreach (usp_ClosingTotalsResult item16 in (from o in gClass.Payouts
			where o.DateCreated <= CS_0024_003C_003E8__locals0.endDate && o.DateCreated >= CS_0024_003C_003E8__locals0.startDate
			select o into a
			group a by a.Reason into a
			select new usp_ClosingTotalsResult
			{
				Name = a.Key,
				Total = a.Sum((Payout b) => b.Amount)
			}).ToList())
		{
			if (!item16.Name.ToUpper().Contains(" BALANCE") && !item16.Name.ToUpper().Contains(" SAFE"))
			{
				item16.Name = "PAYOUT " + item16.Name;
			}
			empty += "<span style=\"float:left;font-size:9pt;padding-bottom:5pt;\">";
			empty += method_1(item16.Name, 17);
			empty += method_1("$ " + item16.Total.Value.ToString("0.00;(0.00)"), 10, bool_1: false);
			empty += "</span>";
			num += 100;
		}
		empty2 = empty2.Replace("%OtherInformationSummary%", empty);
		goto IL_442f;
	}

	public void PrintDeliveryCommission(DateTime startDate, DateTime endDate, int EmployeeId, string reportType)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.endDate = endDate;
		CS_0024_003C_003E8__locals0.startDate = startDate;
		CS_0024_003C_003E8__locals0.EmployeeId = EmployeeId;
		GClass6 gClass = new GClass6();
		LocalReport val = new LocalReport();
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
		val.set_ReportEmbeddedResource("CorePOS.Reports.DeliveryCommissions.rdlc");
		List<CompanySetup> list = new List<CompanySetup> { CompanyHelper.CompanyDataSetup };
		ReportDataSource val2 = new ReportDataSource("CompanyDS", (IEnumerable)list);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val2);
		val2.set_Value((object)list);
		IQueryable<Order> source = gClass.Orders.Where((Order o) => ((o.DeliveryTime <= CS_0024_003C_003E8__locals0.endDate && o.DeliveryTime >= CS_0024_003C_003E8__locals0.startDate) || (o.DatePaid <= CS_0024_003C_003E8__locals0.endDate && o.DatePaid >= CS_0024_003C_003E8__locals0.startDate)) && (o.OrderType == OrderTypes.Delivery || o.OrderType == OrderTypes.DeliveryOnline));
		if (CS_0024_003C_003E8__locals0.EmployeeId != 0)
		{
			source = source.Where((Order a) => (int?)a.UserServed == (int?)CS_0024_003C_003E8__locals0.EmployeeId);
		}
		List<Order> list2 = new List<Order>();
		string text = "DELIVERY COMMISSION REPORT";
		if (reportType == ReportTypes.DeliveryCommission)
		{
			list2 = source.Where((Order o) => o.ItemName == ConstantItems.Delivery_Fee).ToList();
			text = "DELIVERY COMMISSION REPORT";
		}
		else
		{
			list2 = source.ToList();
			text = "DELIVERY DRIVER LIST";
		}
		List<DeliveryCommissionObject> list3 = new List<DeliveryCommissionObject>();
		using (List<Employee>.Enumerator enumerator = MemoryLoadedObjects.all_employees.Where((Employee a) => a.Users.First().Role.RoleName == Roles.driver && a.isActive).ToList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass20_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass20_1();
				CS_0024_003C_003E8__locals1.emp = enumerator.Current;
				List<DeliveryCommissionObject> list4 = (from a in list2
					group a by a.OrderNumber into a
					select new DeliveryCommissionObject
					{
						OrderNumber = a.Key,
						EmployeeName = CS_0024_003C_003E8__locals1.emp.FirstName + " " + CS_0024_003C_003E8__locals1.emp.LastName,
						SubTotal = a.Sum((Order x) => x.SubTotal)
					}).ToList();
				if (list4.Count > 0)
				{
					list3.AddRange(list4);
					list3.Add(new DeliveryCommissionObject
					{
						OrderNumber = "-",
						EmployeeName = "TOTAL " + CS_0024_003C_003E8__locals1.emp.FirstName,
						SubTotal = list4.Sum((DeliveryCommissionObject a) => a.SubTotal)
					});
				}
			}
		}
		((Report)val).SetParameters(new ReportParameter("prmLanguage_Phone", Resources.Phone));
		string text2 = Resources.Tax_No + ":";
		if (string.IsNullOrEmpty(CompanyHelper.CompanyDataSetup.String_0))
		{
			text2 = "";
		}
		((Report)val).SetParameters(new ReportParameter("prmLanguage_TaxNo", text2));
		((Report)val).SetParameters(new ReportParameter("prmCurrentDate", CS_0024_003C_003E8__locals0.startDate.ToLongDateString()));
		((Report)val).SetParameters(new ReportParameter("prmTitle", text));
		ReportDataSource val3 = new ReportDataSource("CommissionTotalDS", (IEnumerable)list3);
		((Collection<ReportDataSource>)(object)val.get_DataSources()).Add(val3);
		val3.set_Value((object)list3);
		method_2(val);
		method_5(SettingsHelper.GetSettingValueByKey("receipt_size"));
	}

	private string method_1(string string_2, int int_2, bool bool_1 = true)
	{
		string_2 = string_2.Replace("&nbsp;", " ");
		if (bool_1)
		{
			for (int i = string_2.Length - 1; i < int_2; i++)
			{
				string_2 += "&nbsp;";
			}
		}
		else
		{
			for (int j = string_2.Length - 1; j < int_2; j++)
			{
				string_2 = "&nbsp;" + string_2;
			}
		}
		return string_2.Replace(" ", "&nbsp;");
	}

	public void GenerateDayEndTotals(DateTime startDate, DateTime endDate, int EmployeeId, int TerminalId)
	{
		_003C_003Ec__DisplayClass22_0 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_0();
		_003C_003Ec__DisplayClass22_.startDate = startDate;
		_003C_003Ec__DisplayClass22_.endDate = endDate;
		_003C_003Ec__DisplayClass22_.EmployeeId = EmployeeId;
		_003C_003Ec__DisplayClass22_.TerminalId = TerminalId;
		_003C_003Ec__DisplayClass22_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals0;
		new Thread((ThreadStart)delegate
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			try
			{
				LocalReport val = new LocalReport();
				((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
				((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
				val.set_ReportEmbeddedResource("CorePOS.Reports.Blank.rdlc");
				DayEndTotalsObject dayEndTotalsObject = new PrintHelper().GenerateDayEndTotalsHTML(_003C_003Ec__DisplayClass22_.startDate, _003C_003Ec__DisplayClass22_.endDate, _003C_003Ec__DisplayClass22_.EmployeeId, _003C_003Ec__DisplayClass22_.TerminalId);
				((Report)val).SetParameters(new ReportParameter("prmFontSize", "12"));
				((Report)val).SetParameters(new ReportParameter("prmTextString", dayEndTotalsObject.DayEndHtml));
				((Report)val).SetParameters(new ReportParameter("prmFontFamily", "Courier New"));
				_003C_003Ec__DisplayClass22_._003C_003E4__this.method_2(val);
				_003C_003Ec__DisplayClass22_._003C_003E4__this.method_5(SettingsHelper.GetSettingValueByKey("receipt_size"), -1, bool_1: true);
				val.Dispose();
				GC.Collect();
			}
			catch (Exception)
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_1();
				CS_0024_003C_003E8__locals0.splashForm = Application.OpenForms.OfType<frmSplash>().FirstOrDefault();
				CS_0024_003C_003E8__locals0.splashForm.Invoke((Action)delegate
				{
					new NotificationLabel(CS_0024_003C_003E8__locals0.splashForm, "Error printing chit. Please check printer settings.", NotificationTypes.Warning).Show();
				});
			}
		}).Start();
	}

	private void method_2(LocalReport localReport_0, string string_2 = "EMF", int int_2 = 297, string string_3 = "80mm")
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		string text = "<DeviceInfo>\r\n                <OutputFormat>%OUTPUT_FORMAT%</OutputFormat>\r\n                <PageWidth>%WIDTH%</PageWidth>\r\n                <PageHeight>%HEIGHT%mm</PageHeight>\r\n                <MarginTop>0mm</MarginTop>\r\n                <MarginLeft>0mm</MarginLeft>\r\n                <MarginRight>0mm</MarginRight>\r\n                <MarginBottom>0mm</MarginBottom>\r\n            </DeviceInfo>";
		text = text.Replace("%OUTPUT_FORMAT%", string_2);
		text = text.Replace("%HEIGHT%", Convert.ToString(int_2));
		text = text.Replace("%WIDTH%", string_3);
		ilist_0 = new List<Stream>();
		Warning[] array = default(Warning[]);
		localReport_0.Render("Image", text, new CreateStreamCallback(method_0), ref array);
		foreach (Stream item in ilist_0)
		{
			item.Position = 0L;
		}
		array = null;
	}

	private void method_3(object object_0, PrintPageEventArgs printPageEventArgs_0, bool bool_1)
	{
		Metafile image = new Metafile(ilist_0[int_1]);
		int width = printPageEventArgs_0.PageSettings.PaperSize.Width;
		Rectangle rect = new Rectangle(printPageEventArgs_0.PageBounds.Left, printPageEventArgs_0.PageBounds.Top, width, printPageEventArgs_0.PageSettings.PaperSize.Height);
		printPageEventArgs_0.Graphics.FillRectangle(Brushes.White, rect);
		printPageEventArgs_0.Graphics.DrawImage(image, rect);
		int_1++;
		printPageEventArgs_0.HasMorePages = bool_1 && int_1 < ilist_0.Count;
	}

	private PaperSize method_4(int int_2 = 297, string string_2 = "80mm")
	{
		string_2 = string_2.Replace("mm", string.Empty);
		float num = 73f;
		switch (string_2)
		{
		case "102":
			num = 100f;
			break;
		case "80":
			num = 73f;
			break;
		case "72":
			num = 63f;
			break;
		case "58":
			num = 50f;
			break;
		}
		int width = (int)((double)num / 25.399970155035071 * 100.0);
		int_2 = (int)((double)int_2 / 25.399970155035071 * 100.0);
		return new PaperSize("Custom", width, int_2);
	}

	private void method_5(string string_2, int int_2 = -1, bool bool_1 = false)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.calculateHasMorePages = bool_1;
		new Thread((ThreadStart)delegate
		{
			Thread.CurrentThread.IsBackground = true;
			CheckPCPrintQueueStatus(CS_0024_003C_003E8__locals0._003C_003E4__this.string_0);
		}).Start();
		if (!string_2.Contains("mm"))
		{
			string_2 += "mm";
		}
		if (ilist_0 != null && ilist_0.Count != 0)
		{
			PrintDocument printDocument = new PrintDocument();
			printDocument.PrinterSettings.PrinterName = string_0;
			printDocument.PrintController = new StandardPrintController();
			if (!printDocument.PrinterSettings.IsValid)
			{
				new frmMessageBox(Resources.Cannot_find_the_default_printe1, Resources.Printer_Error).ShowDialog();
				return;
			}
			PaperSize paperSize;
			if (int_2 > 0)
			{
				paperSize = method_4(int_2, string_2);
				printDocument.DefaultPageSettings.Margins.Bottom = 0;
			}
			else
			{
				paperSize = method_4(297, string_2);
				printDocument.DefaultPageSettings.Margins.Bottom = 50;
			}
			printDocument.PrintPage += delegate(object sender, PrintPageEventArgs e)
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_3(sender, e, CS_0024_003C_003E8__locals0.calculateHasMorePages);
			};
			printDocument.DefaultPageSettings.Margins.Top = 0;
			printDocument.DefaultPageSettings.Margins.Left = 0;
			printDocument.DefaultPageSettings.Margins.Right = 0;
			PaperSize paperSize4 = (printDocument.PrinterSettings.DefaultPageSettings.PaperSize = (printDocument.DefaultPageSettings.PaperSize = paperSize));
			printDocument.PrinterSettings.DefaultPageSettings.Margins = printDocument.DefaultPageSettings.Margins;
			printDocument.DefaultPageSettings.PrinterResolution = new PrinterResolution
			{
				X = 100,
				Y = 100
			};
			printDocument.PrinterSettings.DefaultPageSettings.PrinterResolution = printDocument.DefaultPageSettings.PrinterResolution;
			if (!string.IsNullOrEmpty(string_0))
			{
				printDocument.PrinterSettings.PrinterName = string_0;
			}
			else
			{
				string text = ((!string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.DefaultPrinter)) ? MemoryLoadedObjects.this_terminal.DefaultPrinter : SettingsHelper.GetSettingValueByKey("printer_default"));
				if (string.IsNullOrEmpty(text))
				{
					new frmMessageBox(Resources.Cannot_find_the_default_printe0, Resources.Printer_Error).ShowDialog();
					return;
				}
				printDocument.PrinterSettings.PrinterName = text;
			}
			try
			{
				int_1 = 0;
				printDocument.Print();
			}
			catch
			{
				string text2 = ((!string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.DefaultPrinter)) ? MemoryLoadedObjects.this_terminal.DefaultPrinter : SettingsHelper.GetSettingValueByKey("printer_default"));
				if (string_0 == text2)
				{
					if (method_7())
					{
						method_5(string_2, int_2, CS_0024_003C_003E8__locals0.calculateHasMorePages);
					}
				}
				else
				{
					int_0++;
					if (int_0 <= 3)
					{
						string_0 = text2;
						method_5(string_2, int_2, CS_0024_003C_003E8__locals0.calculateHasMorePages);
					}
				}
			}
			paperSize = null;
			printDocument.Dispose();
			GC.Collect();
		}
		else
		{
			new frmMessageBox("An error occurred trying to print. Please try again.", "Print Error").ShowDialog();
		}
	}

	public static bool CheckPCPrintQueueStatus(string printerName)
	{
		try
		{
			Thread.Sleep(3000);
			if (bool_0 && !(string_1 != printerName))
			{
				return false;
			}
			string_1 = printerName;
			PrintQueue printQueue;
			if (printerName.Contains("\\\\"))
			{
				int num = printerName.IndexOf("\\") + 1;
				int length = printerName.LastIndexOf("\\") - num;
				string text = printerName.Substring(num, length);
				printQueue = new PrintServer("\\\\" + Dns.GetHostEntry(text.TrimStart('\\')).HostName).GetPrintQueue(printerName);
			}
			else
			{
				printQueue = new LocalPrintServer().GetPrintQueue(printerName);
			}
			while (true)
			{
				string text2 = string.Empty;
				if (!printQueue.IsDoorOpened)
				{
					if (!printQueue.IsNotAvailable && !printQueue.IsOffline && !printQueue.IsNotAvailable)
					{
						if (printQueue.IsOutOfPaper)
						{
							text2 = "The '" + printerName + "' printer is out of paper.";
						}
						else if (printQueue.IsInError || printQueue.IsOutOfMemory)
						{
							text2 = "The '" + printerName + "' printer is in an ERROR state.  Please check the printer connections, and reset the printer. To reset the printer:\r\n\r\n1. Turn off the printer \r\n2. Press and hold the FEED button. \r\n3. While holding the FEED button, turn on the printer. Keep holding the feed button for 3 seconds and let go.";
						}
					}
					else
					{
						text2 = "The '" + printerName + "' printer is offline or not available.  Please check the printer connections, and reset the printer.";
					}
				}
				else
				{
					text2 = "The '" + printerName + "' printer door is open.  Please close before to continue printing.";
				}
				if (string.IsNullOrEmpty(text2))
				{
					if (printQueue.NumberOfJobs <= 0)
					{
						break;
					}
					Thread.Sleep(3000);
					printQueue.Refresh();
					if (printQueue.NumberOfJobs <= 0)
					{
						return true;
					}
					continue;
				}
				if (MemoryLoadedObjects.showPrintError)
				{
					bool_0 = true;
					frmMessageBox obj = new frmMessageBox(text2, printerName.ToUpper() + " PRINT ERROR");
					obj.TopMost = true;
					obj.ShowDialog();
					bool_0 = false;
					string_1 = string.Empty;
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog("CheckPCPrintQueueStatus ERROR: " + ex.Message + "\n" + ex.StackTrace, LogTypes.print_log);
			return false;
		}
	}

	private void method_6(string string_2)
	{
		if (ilist_0 != null && ilist_0.Count != 0)
		{
			if (!File.Exists(string_2))
			{
				using (FileStream fileStream = new FileStream(string_2, FileMode.Create))
				{
					MemoryStream memoryStream = new MemoryStream();
					int_1 = 0;
					ilist_0[int_1].CopyTo(memoryStream);
					fileStream.Write(memoryStream.ToArray(), 0, Convert.ToInt32(ilist_0[int_1].Length));
					return;
				}
			}
			return;
		}
		throw new Exception(Resources.Error_no_stream_to_print);
	}

	public void PrintSavedOrder(string orderNumber)
	{
		string message = Resources.Saved_Order + orderNumber;
		PrintString(message);
	}

	public void PrintString(string message, int FontSize = 14, Station station = null, string fontFamily = "Arial", bool isBold = false, bool isHTML = true)
	{
		_003C_003Ec__DisplayClass30_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
		CS_0024_003C_003E8__locals0.station = station;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.isHTML = isHTML;
		CS_0024_003C_003E8__locals0.message = message;
		CS_0024_003C_003E8__locals0.FontSize = FontSize;
		CS_0024_003C_003E8__locals0.fontFamily = fontFamily;
		CS_0024_003C_003E8__locals0.isBold = isBold;
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.message))
		{
			return;
		}
		new Thread((ThreadStart)delegate
		{
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Expected O, but got Unknown
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Expected O, but got Unknown
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Expected O, but got Unknown
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Expected O, but got Unknown
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Expected O, but got Unknown
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Expected O, but got Unknown
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Expected O, but got Unknown
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Expected O, but got Unknown
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Expected O, but got Unknown
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Expected O, but got Unknown
			_003C_003Ec__DisplayClass30_1 _003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_1();
			_003C_003Ec__DisplayClass30_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			_003C_003Ec__DisplayClass30_.p = new PrintDocument();
			new StationMethods();
			_003C_003Ec__DisplayClass30_.p.PrintController = new StandardPrintController();
			string text = SettingsHelper.GetSettingValueByKey("receipt_size");
			if (CS_0024_003C_003E8__locals0.station != null)
			{
				if (CS_0024_003C_003E8__locals0.station.EnablePrint)
				{
					_003C_003Ec__DisplayClass30_.p.PrinterSettings.PrinterName = CS_0024_003C_003E8__locals0.station.PrinterName;
					text = CS_0024_003C_003E8__locals0.station.PaperSize.Trim();
				}
				else
				{
					_003C_003Ec__DisplayClass30_.p.PrinterSettings.PrinterName = CS_0024_003C_003E8__locals0._003C_003E4__this.string_0;
				}
			}
			else
			{
				_003C_003Ec__DisplayClass30_.p.PrinterSettings.PrinterName = CS_0024_003C_003E8__locals0._003C_003E4__this.string_0;
			}
			if (!text.Contains("mm"))
			{
				text += "mm";
			}
			if (CS_0024_003C_003E8__locals0.isHTML)
			{
				LocalReport val = new LocalReport();
				((Collection<ReportDataSource>)(object)val.get_DataSources()).Clear();
				int int_ = 297;
				if (CS_0024_003C_003E8__locals0.station != null && CS_0024_003C_003E8__locals0.station.ChitFormat != 1 && CS_0024_003C_003E8__locals0.station.ChitFormat != 3 && CS_0024_003C_003E8__locals0.station.ChitFormat != 5)
				{
					if (CS_0024_003C_003E8__locals0.station != null && CS_0024_003C_003E8__locals0.station.ChitFormat == 6)
					{
						string[] array = CS_0024_003C_003E8__locals0.message.Split(new string[1] { "%DATA_BREAK%" }, StringSplitOptions.None);
						string text2 = array[0];
						string text3 = array[1];
						CS_0024_003C_003E8__locals0.message = array[2];
						val.set_ReportEmbeddedResource("CorePOS.Reports.BlankChit6.rdlc");
						((Report)val).SetParameters(new ReportParameter("prmOrderNumber", text2));
						((Report)val).SetParameters(new ReportParameter("prmTableNumber", text3));
						int_ = 3276;
					}
					else if (CS_0024_003C_003E8__locals0.station != null && CS_0024_003C_003E8__locals0.station.ChitFormat == 2)
					{
						val.set_ReportEmbeddedResource("CorePOS.Reports.BlankLabel.rdlc");
						int_ = 32;
					}
					else if (CS_0024_003C_003E8__locals0.station != null && CS_0024_003C_003E8__locals0.station.ChitFormat == 4)
					{
						string[] array2 = CS_0024_003C_003E8__locals0.message.Split(new string[1] { "%DATA_BREAK%" }, StringSplitOptions.None);
						string text4 = array2[0];
						string text5 = array2[1];
						string text6 = array2[2];
						string text7 = array2[3];
						string text8 = array2[4];
						string text9 = array2[5];
						string text10 = array2[6];
						CS_0024_003C_003E8__locals0.message = array2[7];
						val.set_ReportEmbeddedResource("CorePOS.Reports.LargeLabelChit.rdlc");
						((Report)val).SetParameters(new ReportParameter("prmCustomerInfo", text10));
						((Report)val).SetParameters(new ReportParameter("prmOrderType", text4));
						((Report)val).SetParameters(new ReportParameter("prmChitNumber", text5));
						((Report)val).SetParameters(new ReportParameter("prmOrderTicket", text6));
						((Report)val).SetParameters(new ReportParameter("prmOrderDates", text7));
						((Report)val).SetParameters(new ReportParameter("prmOrderTotals", text8));
						((Report)val).SetParameters(new ReportParameter("prmOrderStatus", text9));
						((Report)val).SetParameters(new ReportParameter("prmCustomerInfo", text10));
						int_ = 40;
					}
				}
				else
				{
					val.set_ReportEmbeddedResource("CorePOS.Reports.Blank.rdlc");
					int_ = 3276;
				}
				((Report)val).SetParameters(new ReportParameter("prmFontSize", CS_0024_003C_003E8__locals0.FontSize.ToString()));
				((Report)val).SetParameters(new ReportParameter("prmTextString", CS_0024_003C_003E8__locals0.message));
				((Report)val).SetParameters(new ReportParameter("prmFontFamily", CS_0024_003C_003E8__locals0.fontFamily));
				CS_0024_003C_003E8__locals0._003C_003E4__this.method_2(val, "EMF", int_, text);
				try
				{
					CS_0024_003C_003E8__locals0._003C_003E4__this.method_5(text, int_);
				}
				catch
				{
					string text11 = ((!string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.DefaultPrinter)) ? MemoryLoadedObjects.this_terminal.DefaultPrinter : SettingsHelper.GetSettingValueByKey("printer_default"));
					if (CS_0024_003C_003E8__locals0._003C_003E4__this.string_0 == text11)
					{
						if (CS_0024_003C_003E8__locals0._003C_003E4__this.method_7())
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.PrintString(CS_0024_003C_003E8__locals0.message, CS_0024_003C_003E8__locals0.FontSize, CS_0024_003C_003E8__locals0.station);
						}
					}
					else
					{
						CS_0024_003C_003E8__locals0._003C_003E4__this.string_0 = text11;
						CS_0024_003C_003E8__locals0._003C_003E4__this.method_5(text, int_);
					}
				}
				_003C_003Ec__DisplayClass30_.p.PrintController = null;
				_003C_003Ec__DisplayClass30_.p.Dispose();
				GC.Collect();
			}
			else
			{
				CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_2();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass30_;
				CS_0024_003C_003E8__locals0.style = (CS_0024_003C_003E8__locals0.isBold ? FontStyle.Bold : FontStyle.Regular);
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.PrintPage += delegate(object sender, PrintPageEventArgs e)
				{
					e.Graphics.DrawString(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.message, new Font(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.fontFamily, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.FontSize, CS_0024_003C_003E8__locals0.style), new SolidBrush(Color.Black), new RectangleF(0f, 0f, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.DefaultPageSettings.PrintableArea.Width, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.DefaultPageSettings.PrintableArea.Height));
				};
				try
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.Print();
				}
				catch
				{
					string text12 = ((!string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.DefaultPrinter)) ? MemoryLoadedObjects.this_terminal.DefaultPrinter : SettingsHelper.GetSettingValueByKey("printer_default"));
					if (CS_0024_003C_003E8__locals0._003C_003E4__this.string_0 == text12)
					{
						if (CS_0024_003C_003E8__locals0._003C_003E4__this.method_7())
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.PrintString(CS_0024_003C_003E8__locals0.message, CS_0024_003C_003E8__locals0.FontSize, CS_0024_003C_003E8__locals0.station);
						}
					}
					else
					{
						CS_0024_003C_003E8__locals0._003C_003E4__this.PrintString(CS_0024_003C_003E8__locals0.message, CS_0024_003C_003E8__locals0.FontSize);
					}
				}
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.PrintController = null;
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.p.Dispose();
				GC.Collect();
			}
		}).Start();
	}

	private bool method_7()
	{
		if (new frmMessageBox(Resources.Cannot_find_the_default_pri_W, Resources.Printer_Error, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			PrintDialog printDialog = new PrintDialog();
			GClass6 gClass = new GClass6();
			if (printDialog.ShowDialog() != DialogResult.Cancel)
			{
				SetDefaultPrinter(printDialog.PrinterSettings.PrinterName);
				Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
				if (terminal != null)
				{
					terminal.DefaultPrinter = printDialog.PrinterSettings.PrinterName;
					Helper.SubmitChangesWithCatch(gClass);
					MemoryLoadedObjects.RefreshTerminalData();
				}
			}
			gClass.Dispose();
			printDialog.Dispose();
			GC.Collect();
			return true;
		}
		return false;
	}

	public void QueueChit(string message, int fontSize, Station station, DateTime Datecreated, string OrderNumber, int numberOfCopies = 1, List<Guid> OrderIds = null, List<string> RelatedOrderNumbers = null)
	{
		if (string.IsNullOrEmpty(message))
		{
			return;
		}
		if (SettingsHelper.GetSettingValueByKey("chit_print_server").ToUpper() == "NONE")
		{
			string text = "";
			if (!string.IsNullOrEmpty(station.PrinterName))
			{
				text = station.PrinterName;
			}
			for (int i = 0; i < numberOfCopies; i++)
			{
				MemoryLoadedObjects.ListChitsToPrint.Add(new ChitPrintInfo
				{
					OrderNumber = OrderNumber,
					Message = message,
					FontSize = fontSize,
					station = station,
					PrinterName = text,
					RelatedOrderNumbers = RelatedOrderNumbers,
					orderIds = OrderIds
				});
				LogHelper.WriteLog("QueueChit: Queued chit print in memory for: order=" + OrderNumber + ", printer=" + text + ".", LogTypes.print_log);
			}
		}
		else
		{
			string text2 = string.Join(",", RelatedOrderNumbers);
			GClass6 gClass = new GClass6();
			for (int j = 0; j < numberOfCopies; j++)
			{
				ChitPrintQueue chitPrintQueue = new ChitPrintQueue();
				chitPrintQueue.TextString = message;
				chitPrintQueue.FontSize = fontSize;
				chitPrintQueue.StationID = station.StationID;
				chitPrintQueue.DateCreated = Datecreated;
				chitPrintQueue.Printed = false;
				chitPrintQueue.OrderNumber = ((RelatedOrderNumbers == null || RelatedOrderNumbers.Count <= 1) ? OrderNumber : text2);
				gClass.ChitPrintQueues.InsertOnSubmit(chitPrintQueue);
				LogHelper.WriteLog("QueueChit: Queued chit print in database for: order=" + OrderNumber + ", printer=PrintServer.", LogTypes.print_log);
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	static PrintHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = false;
		string_1 = string.Empty;
		currentlyPrinting = false;
	}
}
