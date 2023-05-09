using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class Ingenico
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string ip;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public static List<PaymentTransactionObject> SendToTerminal(string provider, string model, string ip, int port, string request, bool parseObject, string orderNumber, string paymentMethod)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.ip = ip;
		PaymentTerminalTransactionLog paymentTerminalTransactionLog = (from x in new GClass6().PaymentTerminalTransactionLogs
			where x.IP == CS_0024_003C_003E8__locals0.ip
			select x into y
			orderby y.DateCreated descending
			select y).FirstOrDefault();
		if (paymentTerminalTransactionLog != null && paymentTerminalTransactionLog.DateCreated.AddSeconds(3.0) > DateTime.Now)
		{
			Thread.Sleep(3000);
		}
		PaymentHelper.RecordPaymentTransactionLog(provider, model, CS_0024_003C_003E8__locals0.ip, port, request, "request", orderNumber, paymentMethod);
		List<PaymentTransactionObject> list = ((model == PaymentTerminalModels.Ingenico.iCT250 || model == PaymentTerminalModels.Ingenico.Desk5000 || model == PaymentTerminalModels.Ingenico.Move5000) ? smethod_0(provider, CS_0024_003C_003E8__locals0.ip, port, request, parseObject) : new List<PaymentTransactionObject>());
		foreach (PaymentTransactionObject item in list)
		{
			if (item.responsecode != null)
			{
				PaymentHelper.RecordPaymentTransactionLog(provider, model, CS_0024_003C_003E8__locals0.ip, port, item.rawdata, "response", orderNumber, paymentMethod);
			}
		}
		return list;
	}

	public static string FormatTransactionString(string transactiontype, string baseamount, string ordernumber, string clerkid)
	{
		if (transactiontype == PaymentTerminalTransactionTypes.sale)
		{
			transactiontype = IngenicoTransactionTypes.purchase;
		}
		else if (transactiontype == PaymentTerminalTransactionTypes.refund)
		{
			transactiontype = IngenicoTransactionTypes.refund;
		}
		else if (transactiontype == PaymentTerminalTransactionTypes.settlement)
		{
			transactiontype = IngenicoTransactionTypes.settlement;
		}
		else if (transactiontype == PaymentTerminalTransactionTypes.purchase_correction)
		{
			transactiontype = IngenicoTransactionTypes.purchase_correction;
		}
		char c2 = Convert.ToChar(28);
		string text;
		if (transactiontype == IngenicoTransactionTypes.settlement)
		{
			text = transactiontype + c2 + "0071";
		}
		else
		{
			text = transactiontype + c2 + GClass4.transaction_amount + baseamount + c2 + "0020";
			if (!string.IsNullOrEmpty(ordernumber))
			{
				text = text + c2 + GClass4.invoice_number + new string(ordernumber.Where((char c) => char.IsNumber(c)).ToArray()) + c2 + GClass4.clerk_id + clerkid;
			}
		}
		return text;
	}

	public static Dictionary<string, string> MapTransactionString(string log)
	{
		string[] array = log.Split('^');
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				if (array[i].Length > 2)
				{
					dictionary.Add(array[i].Substring(0, 3), array[i].Substring(3, array[i].Length - 3));
				}
				else
				{
					dictionary.Add(array[i].Substring(0, array[i].Length), string.Empty);
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("same key has already been added"))
				{
					dictionary[array[i].Substring(0, 3)] = array[i].Substring(3, array[i].Length - 3);
					continue;
				}
				DebugMethods.ShowExceptionTextFile(ex);
				DebugMethods.ShowErrorTextFile(array[i]);
			}
		}
		return dictionary;
	}

	public static string BuildSettlementReport(string res)
	{
		Dictionary<string, string> source = MapTransactionString(res);
		string text = "<br/>";
		string text2 = text + smethod_2(string.Empty, "------------------------------") + text;
		text2 = text2 + smethod_2("CURRENT BATCH TOTAL", string.Empty) + text;
		text2 = text2 + smethod_2("TERMINAL", (from x in source
			where x.Key == IngencioBatchResponseIDs.terminal_id
			select x into y
			select y.Value).FirstOrDefault()) + text;
		text2 = text2 + smethod_2("BATCH #", (from x in source
			where x.Key == IngencioBatchResponseIDs.batch_number
			select x into y
			select y.Value).FirstOrDefault()) + text;
		text2 = text2 + smethod_2(string.Empty, "------------------------------") + text;
		new List<BatchPaymentObject>();
		char oldChar = Convert.ToChar(29);
		short num = 0;
		int num2 = 0;
		short num3 = 0;
		int num4 = 0;
		short num5 = 0;
		int num6 = 0;
		short num7 = 0;
		int num8 = 0;
		foreach (string item in from x in source
			where x.Key == "900"
			select x into y
			select y.Value)
		{
			Dictionary<string, string> source2 = MapTransactionString(item.Replace(oldChar, '^'));
			BatchPaymentObject batchPaymentObject = new BatchPaymentObject();
			batchPaymentObject.ID = Convert.ToInt32((from x in source2
				where x.Key == "200"
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.card_name = (from x in source2
				where x.Key == IngencioBatchResponseIDs.payment_type
				select x into y
				select y.Value).FirstOrDefault();
			batchPaymentObject.purchase_count = Convert.ToInt16((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_purchase_type_count
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.purchase_amount = Convert.ToInt32((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_purchase_type_amount
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.refund_count = Convert.ToInt16((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_refund_type_count
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.refund_amount = Convert.ToInt32((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_refund_type_amount
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.correction_count = Convert.ToInt16((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_correction_type_count
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.correction_amount = Convert.ToInt32((from x in source2
				where x.Key == IngencioBatchResponseIDs.batch_correction_type_amount
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.net_count = Convert.ToInt16((from x in source2
				where x.Key == IngencioBatchResponseIDs.payment_type_count
				select x into y
				select y.Value).FirstOrDefault());
			batchPaymentObject.net_amount = Convert.ToInt32((from x in source2
				where x.Key == IngencioBatchResponseIDs.payment_type_net_total
				select x into y
				select y.Value).FirstOrDefault());
			text2 = text2 + batchPaymentObject.card_name + text;
			if (batchPaymentObject.purchase_count > 0)
			{
				num = (short)(num + batchPaymentObject.purchase_count);
				num2 += batchPaymentObject.purchase_amount;
				text2 = text2 + smethod_2("PURCHASE " + batchPaymentObject.purchase_count, $"{(decimal)batchPaymentObject.purchase_amount / 100m:C}") + text;
			}
			if (batchPaymentObject.refund_count > 0)
			{
				num3 = (short)(num3 + batchPaymentObject.refund_count);
				num4 += batchPaymentObject.refund_amount;
				text2 = text2 + smethod_2("REFUND " + batchPaymentObject.refund_count, $"{(decimal)batchPaymentObject.refund_amount / 100m:C}") + text;
			}
			if (batchPaymentObject.correction_count > 0)
			{
				num5 = (short)(num5 + batchPaymentObject.correction_count);
				num6 += batchPaymentObject.correction_amount;
				text2 = text2 + smethod_2("CORRECTION " + batchPaymentObject.correction_count, $"{(decimal)batchPaymentObject.correction_amount / 100m:C}") + text;
			}
			text2 = text2 + smethod_2("NET " + batchPaymentObject.net_count, $"{(decimal)batchPaymentObject.net_amount / 100m:C}") + text + text;
			num7 = (short)(num7 + batchPaymentObject.net_count);
			num8 += batchPaymentObject.net_amount;
		}
		text2 = text2 + "GRAND TOTAL" + text;
		text2 = text2 + smethod_2("PURCHASE " + num, $"{(decimal)num2 / 100m:C}") + text;
		text2 = text2 + smethod_2("REFUND " + num3, $"{(decimal)num4 / 100m:C}") + text;
		text2 = text2 + smethod_2("CORRECTION " + num3, $"{(decimal)num6 / 100m:C}") + text + text;
		text2 = text2 + smethod_3("BATCH # " + (from x in source
			where x.Key == IngencioBatchResponseIDs.batch_number
			select x into y
			select y.Value).FirstOrDefault()) + "CLOSED";
		text2 += smethod_3("END OF REPORT");
		string text3 = DateTime.Now.Minute.ToString();
		if (text3.Length == 1)
		{
			text3 = "0" + text3;
		}
		text2 += smethod_3(DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + text3);
		return text2 + smethod_2(string.Empty, "------------------------------") + text + text + text;
	}

	private static List<PaymentTransactionObject> smethod_0(string string_0, string string_1, int int_0, string string_2, bool bool_0)
	{
		int num = ((string_2.Substring(0, 2) == "20") ? 360 : 60);
		List<PaymentTransactionObject> list = new List<PaymentTransactionObject>();
		PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
		byte[] bytes = Encoding.ASCII.GetBytes(string_2);
		NetworkStream stream;
		try
		{
			stream = new TcpClient(string_1, int_0).GetStream();
			int readTimeout = (stream.WriteTimeout = num * 1000);
			stream.ReadTimeout = readTimeout;
			stream.Write(bytes, 0, bytes.Length);
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = true;
		}
		catch
		{
			if (string_2.Contains("^void^"))
			{
				paymentTransactionObject.responsecode = "xxx";
			}
			else
			{
				paymentTransactionObject.responsecode = "999";
			}
			list.Add(paymentTransactionObject);
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = false;
			return list;
		}
		int num3 = 0;
		int num4 = 0;
		int count = 8;
		string empty = string.Empty;
		string empty2 = string.Empty;
		bool flag = false;
		int num5 = 0;
		byte[] array = new byte[1024];
		int num6 = 0;
		if (string_2 == "20\u001c0071")
		{
			num6 = 1;
		}
		while (!flag)
		{
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = true;
			try
			{
				num4 = stream.Read(array, num5, 1024);
			}
			catch
			{
				num4 = 0;
			}
			if (num4 != 0)
			{
				num3 += num4;
				empty2 = Encoding.ASCII.GetString(array).Replace("\u0011", string.Empty);
				empty2 = empty2.Replace("\0", string.Empty).Replace("\u001c", "^");
				if (string.IsNullOrEmpty(empty2))
				{
					continue;
				}
				if (empty2.Substring(0, 3) == "990" && num6 == 0)
				{
					empty = empty2;
					if (string.IsNullOrEmpty(empty))
					{
						empty = Encoding.ASCII.GetString(array, (num5 - 3 >= 0) ? (num5 - 3) : 0, count);
					}
					paymentTransactionObject = mapObject(string_0, empty, bool_0);
					list.Add(paymentTransactionObject);
					Thread.Sleep(1000);
					byte[] bytes2 = Encoding.ASCII.GetBytes("990");
					stream.Write(bytes2, 0, 3);
				}
				else
				{
					if (empty2.Substring(0, 3) == "300")
					{
						empty = empty2;
						paymentTransactionObject = mapObject(string_0, empty, bool_0);
						list.Add(paymentTransactionObject);
					}
					stream.WriteByte(PaymentHelper.HexStringToByteArray("06")[0]);
					if (empty2.Length >= 3 && empty2.Substring(2, 1) == "0")
					{
						flag = true;
					}
				}
				continue;
			}
			flag = true;
			break;
		}
		CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = false;
		return list;
	}

	public static PaymentTransactionObject mapObject(string provider, string msg_received, bool parseObject)
	{
		Dictionary<string, string> dictionary = MapTransactionString(msg_received);
		PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
		paymentTransactionObject.responsecode = (from x in dictionary
			where x.Key == GClass3.CommonCodes.transaction_status
			select x into y
			select y.Value).FirstOrDefault();
		if (paymentTransactionObject.responsecode == null && dictionary.Count() == 1 && !string.IsNullOrEmpty(msg_received) && msg_received.Length >= 2)
		{
			paymentTransactionObject.responsecode = msg_received.Substring(0, 2);
		}
		else
		{
			paymentTransactionObject.transaction_type = (from x in dictionary
				where x.Key == GClass3.CommonCodes.transaction_type
				select x into y
				select y.Value).FirstOrDefault();
			if (!string.IsNullOrEmpty(paymentTransactionObject.responsecode) && parseObject)
			{
				paymentTransactionObject.cardaccount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.account_number
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.cardissuercode = (from x in dictionary
					where x.Key == GClass3.CommonCodes.card_name
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.amount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.transaction_amount
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.cashback_amount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.cashback_amount
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.surcharge_amount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.surcharge_amount
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.tip_amount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.tip_amount
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.totalamount = (from x in dictionary
					where x.Key == GClass3.CommonCodes.total_amount
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.approvalcode = (from x in dictionary
					where x.Key == GClass3.CommonCodes.authorization_number
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.invoicenumber = (from x in dictionary
					where x.Key == GClass3.CommonCodes.invoice_number
					select x into y
					select y.Value).FirstOrDefault();
				paymentTransactionObject.customerreceipt = smethod_1(provider, dictionary, bool_0: true);
				paymentTransactionObject.merchantreceipt = smethod_1(provider, dictionary, bool_0: false);
			}
		}
		paymentTransactionObject.rawdata = msg_received;
		return paymentTransactionObject;
	}

	private static string smethod_1(string string_0, Dictionary<string, string> dictionary_0, bool bool_0, bool bool_1 = true)
	{
		char.TryParse((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.customer_language
			select x into y
			select y.Value).FirstOrDefault(), out var result);
		if (!char.IsNumber(result))
		{
			result = '0';
		}
		string text = (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.transaction_status
			select x into y
			select y.Value).FirstOrDefault();
		if (text == IngenicoTransactionStatus.approved)
		{
			text = ((result == '1' && bool_0) ? "APPROUVÉ" : "APPROVED");
		}
		else if (text == IngenicoTransactionStatus.partial_approved)
		{
			text = ((result == '1' && bool_0) ? "PARTIELLEMENT APPROUVÉ" : "PARTIAL APPROVED");
		}
		else if (text == IngenicoTransactionStatus.declined)
		{
			text = ((result == '1' && bool_0) ? "DIMINUÉ" : "DECLINED");
		}
		else if (text == IngenicoTransactionStatus.comm_error)
		{
			text = ((result == '1' && bool_0) ? "ERREUR DE COMMUNICATION" : "COMMUNICATION ERROR");
		}
		else if (text == IngenicoTransactionStatus.cancelled_byuser)
		{
			text = ((result == '1' && bool_0) ? "ANNULÉ PAR L'UTILISATEUR" : "CANCELLED BY USER");
		}
		else if (text == IngenicoTransactionStatus.timedout_onuser)
		{
			text = ((result == '1' && bool_0) ? "TEMPORISÉ À L'ENTRÉE DE L'UTILISATEUR" : "TIMED OUT ON USER INPUT");
		}
		else if (text == IngenicoTransactionStatus.not_completed)
		{
			text = ((result == '1' && bool_0) ? "INCOMPLET" : "NOT COMPLETED");
		}
		else if (text == IngenicoTransactionStatus.batch_empty)
		{
			text = ((result == '1' && bool_0) ? "LOT VIDE" : "BATCH EMPTY");
		}
		else if (text == IngenicoTransactionStatus.declined_by_merchant)
		{
			text = ((result == '1' && bool_0) ? "REFUSÉ PAR LE MARCHAND" : "DECLINED BY MERCHANT");
		}
		else if (text == IngenicoTransactionStatus.record_not_found)
		{
			text = ((result == '1' && bool_0) ? "ENREGISTREMENT NON TROUVÉ" : "RECORD NOT FOUND");
		}
		else if (text == IngenicoTransactionStatus.already_voided)
		{
			text = ((result == '1' && bool_0) ? "TRANSACTION DÉJÀ ANNULÉE" : "TRANSACTION ALREADY VOIDED");
		}
		string text2 = ((!(string_0 == PaymentProviderNames.Moneris)) ? (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.card_account_type
			select x into y
			select y.Value).FirstOrDefault() : (from x in dictionary_0
			where x.Key == GClass3.Moneris.account_type
			select x into y
			select y.Value).FirstOrDefault());
		if (text2 == "1")
		{
			text2 = "SAVINGS";
		}
		else if (text2 == "2")
		{
			if (string_0 == PaymentProviderNames.Moneris)
			{
				(from x in dictionary_0
					where x.Key == GClass3.Moneris.merchant_address2
					select x into y
					select y.Value).FirstOrDefault();
			}
			else
			{
				(from x in dictionary_0
					where x.Key == GClass3.Other.receipt_merchant_address2
					select x into y
					select y.Value).FirstOrDefault();
			}
			text2 = ((!bool_1) ? "CHECKING" : "CHEQUING");
		}
		else
		{
			text2 = string.Empty;
		}
		string text3 = (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.transaction_type
			select x into y
			select y.Value).FirstOrDefault();
		if (text3 == IngenicoTransactionTypes.purchase)
		{
			text3 = "PURCHASE";
		}
		else if (text3 == IngenicoTransactionTypes.preauth)
		{
			text3 = "PRE-AUTHORIZATION";
		}
		else if (text3 == IngenicoTransactionTypes.preauth_completion)
		{
			text3 = "PRE-AUTHORIZATION COMPLETION";
		}
		else if (text3 == IngenicoTransactionTypes.purchase_correction)
		{
			text3 = ((!(string_0 == PaymentProviderNames.Moneris)) ? "VOID" : "PURCHASE CORRECTION");
		}
		else if (text3 == IngenicoTransactionTypes.refund)
		{
			text3 = "REFUND";
		}
		else if (text3 == IngenicoTransactionTypes.refund_correction)
		{
			text3 = "REFUND CORRECTION";
		}
		string text4 = (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.settlement_date
			select x into y
			select y.Value).FirstOrDefault();
		string text5 = "20" + text4.Substring(0, 2);
		string text6 = text4.Substring(2, 2);
		string text7 = text4.Substring(4, 2);
		text4 = text5 + "/" + text6 + "/" + text7;
		string text8 = (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.settlement_time
			select x into y
			select y.Value).FirstOrDefault();
		string text9 = text8.Substring(0, 2);
		string text10 = text8.Substring(2, 2);
		string text11 = text8.Substring(4, 2);
		text8 = text9 + ":" + text10 + ":" + text11;
		string text12 = "<br/>";
		string empty = string.Empty;
		if (string_0 == PaymentProviderNames.Moneris)
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Moneris.merchant_name
				select x into y
				select y.Value).FirstOrDefault());
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Moneris.merchant_address1
				select x into y
				select y.Value).FirstOrDefault());
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Moneris.merchant_address2
				select x into y
				select y.Value).FirstOrDefault());
		}
		else
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Other.receipt_merchant_name
				select x into y
				select y.Value).FirstOrDefault());
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Other.receipt_merchant_address1
				select x into y
				select y.Value).FirstOrDefault());
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.Other.receipt_merchant_address2
				select x into y
				select y.Value).FirstOrDefault());
		}
		empty = empty + text12 + smethod_2("CARD", (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.account_number
			select x into y
			select y.Value).FirstOrDefault()) + text12;
		if ((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.card_name
			select x into y
			select y.Value).FirstOrDefault() != null)
		{
			empty = empty + smethod_2("CARD TYPE", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.card_name
				select x into y
				select y.Value).FirstOrDefault().ToUpper()) + text12;
		}
		if (!string.IsNullOrEmpty(text2))
		{
			empty = empty + smethod_2("ACCOUNT TYPE", text2) + text12;
		}
		empty = empty + smethod_2("DATE", text4) + text12;
		empty = empty + smethod_2("TIME", text8) + text12;
		empty += smethod_3("-------------------------");
		if (string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.tip_amount
			select x into y
			select y.Value).FirstOrDefault()) && string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.cashback_amount
			select x into y
			select y.Value).FirstOrDefault()) && string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.surcharge_amount
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(text3 + " " + ((result == '1' && bool_0) ? "MONTANT" : "AMOUNT") + ":", $"{Convert.ToDecimal((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.total_amount
				select x into y
				select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
		}
		else
		{
			empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(text3 + " " + ((result == '1' && bool_0) ? "MONTANT" : "AMOUNT") + ":", $"{Convert.ToDecimal((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.transaction_amount
				select x into y
				select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.cashback_amount
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(((result == '1' && bool_0) ? "REMBOURSEMENT" : "CASHBACK") + ":", $"{Convert.ToDecimal((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.cashback_amount
					select x into y
					select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.tip_amount
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(((result == '1' && bool_0) ? "NIP" : "TIP") + ":", $"{Convert.ToDecimal((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.tip_amount
					select x into y
					select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.surcharge_amount
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(((result == '1' && bool_0) ? "SURTAXE" : "TERMINAL FEE") + ":", $"{Convert.ToDecimal((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.surcharge_amount
					select x into y
					select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
			}
			empty = empty + "<div style=\"font-size:10pt;font-weight:bold;\">" + smethod_2(((result == '1' && bool_0) ? "TOTALE" : "TOTAL") + ":", $"{Convert.ToDecimal((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.total_amount
				select x into y
				select y.Value).FirstOrDefault()) / 100m:C}", 26) + "</div>";
		}
		empty += smethod_3("-------------------------");
		if (string_0 == PaymentProviderNames.Moneris)
		{
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.emv_label
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + (from x in dictionary_0
					where x.Key == GClass3.CommonCodes.emv_label
					select x into y
					select y.Value).FirstOrDefault() + "-" + (from x in dictionary_0
					where x.Key == GClass3.Moneris.emv_tsi_first
					select x into y
					select y.Value).FirstOrDefault() + text12;
			}
			else if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.Moneris.emv_tvr_first
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + (from x in dictionary_0
					where x.Key == GClass3.Moneris.emv_tvr_first
					select x into y
					select y.Value).FirstOrDefault() + "-" + (from x in dictionary_0
					where x.Key == GClass3.Moneris.emv_tsi_first
					select x into y
					select y.Value).FirstOrDefault() + text12;
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.Moneris.emv_aid
				select x into y
				select y.Value).FirstOrDefault()))
			{
				string text13 = (from x in dictionary_0
					where x.Key == GClass3.Moneris.emv_aid
					select x into y
					select y.Value).FirstOrDefault();
				empty = empty + text13 + text12;
			}
		}
		else
		{
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.host_response_iso_code
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.host_response_iso_code
					select x into y
					select y.Value).FirstOrDefault() + "-" + text + "-" + (from x in dictionary_0
					where x.Key == GClass3.CommonCodes.host_response_code
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.card_mode
				select x into y
				select y.Value).FirstOrDefault()))
			{
				string text14 = (from x in dictionary_0
					where x.Key == GClass3.CommonCodes.card_mode
					select x into y
					select y.Value).FirstOrDefault();
				switch (text14)
				{
				case "6":
					text14 = "CARD NOT PRESENT MANUAL";
					break;
				case "4":
					text14 = "FALLBACK SWIPE";
					break;
				case "5":
					text14 = "FALLBACK MANUAL";
					break;
				case "0":
					text14 = "SWIPE";
					break;
				case "1":
					text14 = "CHIP";
					break;
				case "2":
					text14 = "TAP";
					break;
				case "3":
					text14 = "MANUAL";
					break;
				}
				empty = empty + smethod_2((result == '1' && bool_0) ? "MODE D'ENTREE" : "ENTRY MODE", text14) + text12;
			}
			if (!bool_0)
			{
				if (!string.IsNullOrEmpty((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.emv_tvr
					select x into y
					select y.Value).FirstOrDefault()))
				{
					empty = empty + smethod_2("TVR", (from x in dictionary_0
						where x.Key == GClass3.CommonCodes.emv_tvr
						select x into y
						select y.Value).FirstOrDefault()) + text12;
				}
				if (!string.IsNullOrEmpty((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.emv_tsi
					select x into y
					select y.Value).FirstOrDefault()))
				{
					empty = empty + smethod_2("TSI", (from x in dictionary_0
						where x.Key == GClass3.CommonCodes.emv_tsi
						select x into y
						select y.Value).FirstOrDefault()) + text12;
				}
				if (!string.IsNullOrEmpty((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.cvm_ttq
					select x into y
					select y.Value).FirstOrDefault()))
				{
					empty = empty + smethod_2("TTQ", (from x in dictionary_0
						where x.Key == GClass3.CommonCodes.cvm_ttq
						select x into y
						select y.Value).FirstOrDefault()) + text12;
				}
				if (!string.IsNullOrEmpty((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.cvm_tc
					select x into y
					select y.Value).FirstOrDefault()))
				{
					empty = empty + smethod_2("TC", (from x in dictionary_0
						where x.Key == GClass3.CommonCodes.cvm_tc
						select x into y
						select y.Value).FirstOrDefault()) + text12;
				}
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.emv_aid
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty = empty + smethod_2("AID", (from x in dictionary_0
					where x.Key == GClass3.CommonCodes.emv_aid
					select x into y
					select y.Value).FirstOrDefault()) + text12;
			}
			empty = empty + smethod_2("APP NAME", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.emv_label
				select x into y
				select y.Value).FirstOrDefault()) + text12;
			empty = empty + smethod_2("RRN", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.rrn
				select x into y
				select y.Value).FirstOrDefault()) + text12;
			empty = empty + smethod_2("TRACE #", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.trace
				select x into y
				select y.Value).FirstOrDefault()) + text12;
			empty = empty + smethod_2("TID", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.terminal_id
				select x into y
				select y.Value).FirstOrDefault()) + text12;
			if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				if (!string.IsNullOrEmpty((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.seq_num
					select x into y
					select y.Value).FirstOrDefault()))
				{
					empty = empty + smethod_2("SEQ", (from x in dictionary_0
						where x.Key == GClass3.CommonCodes.seq_num
						select x into y
						select y.Value).FirstOrDefault()) + text12;
				}
			}
			else if (!bool_0)
			{
				empty += "<div style=\"font-size:14pt;font-weight:bold;text-align:center\">*** TRAINING MODE ***</div>";
			}
			if (!bool_0)
			{
				empty = empty + smethod_2("MID", (from x in dictionary_0
					where x.Key == GClass3.Other.merchant_id
					select x into y
					select y.Value).FirstOrDefault()) + text12;
			}
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.emv_arqc
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty = empty + smethod_2("ARQC", (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.emv_arqc
				select x into y
				select y.Value).FirstOrDefault()) + text12;
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.emv_final_crypto
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty = empty + (from x in dictionary_0
				where x.Key == GClass3.CommonCodes.emv_final_crypto
				select x into y
				select y.Value).FirstOrDefault() + text12;
		}
		empty = empty + smethod_2("AUTH #", (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.authorization_number
			select x into y
			select y.Value).FirstOrDefault()) + text12;
		empty = empty + text12 + "<div style=\"font-size:14pt;font-weight:bold;text-align:center\">" + text + "</div>";
		string empty2 = string.Empty;
		empty2 = ((!(string_0 == PaymentProviderNames.Moneris)) ? (from x in dictionary_0
			where x.Key == GClass3.CommonCodes.cvm_result
			select x into y
			select y.Value).FirstOrDefault() : (from x in dictionary_0
			where x.Key == GClass3.Moneris.cvm_indicator
			select x into y
			select y.Value).FirstOrDefault());
		bool flag = false;
		if (empty2 == IngenicoCVM.no_cvm)
		{
			empty2 = ((result == '1' && bool_0) ? "AUCUNE SIGNATURE REQUISE" : "NO SIGNATURE REQUIRED");
		}
		else if (empty2 == IngenicoCVM.verified_by_pin)
		{
			empty2 = ((result == '1' && bool_0) ? "VÉRIFIÉ PAR PIN" : "VERIFIED BY PIN");
		}
		else if (empty2 == IngenicoCVM.signature_required)
		{
			empty2 = ((result == '1' && bool_0) ? "SIGNATURE REQUISE" : "SIGNATURE REQUIRED");
			flag = true;
		}
		else if (empty2 == IngenicoCVM.pin_signature)
		{
			empty2 = ((result == '1' && bool_0) ? "NIP ET SIGNATURE REQUIS" : "PIN & SIGNATURE REQUIRED");
			flag = true;
		}
		empty += smethod_3(empty2);
		if (!bool_0 && flag)
		{
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement1
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement1
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement2
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement2
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement3
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement3
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement4
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement4
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement5
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement5
					select x into y
					select y.Value).FirstOrDefault());
			}
			if (!string.IsNullOrEmpty((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_endorsement6
				select x into y
				select y.Value).FirstOrDefault()))
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.receipt_endorsement6
					select x into y
					select y.Value).FirstOrDefault());
			}
			empty = empty + text12 + text12 + smethod_3("-------------------------");
			if (string_0 != PaymentProviderNames.Moneris)
			{
				empty += smethod_3((from x in dictionary_0
					where x.Key == GClass3.CommonCodes.cardholder_name
					select x into y
					select y.Value).FirstOrDefault());
			}
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer1
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer1
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer2
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer2
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer3
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer3
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer4
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer4
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer5
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer5
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer6
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer6
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.receipt_footer7
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.receipt_footer7
				select x into y
				select y.Value).FirstOrDefault());
		}
		if (!string.IsNullOrEmpty((from x in dictionary_0
			where x.Key == GClass3.CommonCodes.host_response_text
			select x into y
			select y.Value).FirstOrDefault()))
		{
			empty += smethod_3((from x in dictionary_0
				where x.Key == GClass3.CommonCodes.host_response_text
				select x into y
				select y.Value).FirstOrDefault());
		}
		return text12 + empty + smethod_3((!bool_0) ? "MERCHANT COPY" : ((result == '1') ? "COPIE CLIENT" : "CUSTOMER COPY"));
	}

	private static string smethod_2(string string_0, string string_1 = "", int int_0 = 30)
	{
		if (string_0 == null)
		{
			string_0 = string.Empty;
		}
		if (string_1 == null)
		{
			string_1 = string.Empty;
		}
		int num = int_0 - string_0.Length - string_1.Length;
		for (int i = 0; i <= num; i++)
		{
			string_0 += "&nbsp;";
		}
		return string_0 + string_1;
	}

	private static string smethod_3(string string_0, int int_0 = 30)
	{
		if (string_0 != null && !string.IsNullOrEmpty(string_0.Trim()))
		{
			return "<div style=\"text-align:center;\">" + string_0 + " </div>";
		}
		return string.Empty;
	}
}
