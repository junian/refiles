using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using com.clover.remotepay.sdk;
using com.clover.sdk.v3.payments;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class FirstData
{
	public static PaymentTransactionObject SendToTerminal(string model, string ip, int port, string request, bool parseObject, string orderNumber, string paymentMethod)
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
		PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, model, CS_0024_003C_003E8__locals0.ip, port, request, "request", orderNumber, paymentMethod);
		PaymentTransactionObject paymentTransactionObject = smethod_0(CS_0024_003C_003E8__locals0.ip, port, request, parseObject);
		if (paymentTransactionObject.responsecode != null)
		{
			PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, model, CS_0024_003C_003E8__locals0.ip, port, paymentTransactionObject.rawdata, "response", orderNumber, paymentMethod);
		}
		return paymentTransactionObject;
	}

	public static void SendToClover(ICloverConnector cloverConnector, string ip, int port, CloverTransactionObject.Request request, string paymentMethod)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.request = request;
		CS_0024_003C_003E8__locals0.ip = ip;
		GClass6 gClass = new GClass6();
		CloverTransactionObject.Request request2 = CS_0024_003C_003E8__locals0.request;
		JsonSerializerSettings val = new JsonSerializerSettings();
		val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
		val.set_MaxDepth((int?)2000);
		string req_res_data = JsonConvert.SerializeObject((object)request2, (Formatting)1, val);
		PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, CS_0024_003C_003E8__locals0.ip, port, req_res_data, "request", CS_0024_003C_003E8__locals0.request.OrderNumber, paymentMethod);
		if (CS_0024_003C_003E8__locals0.request.RequestType.ToLower().Contains("sale"))
		{
			SaleRequest val2 = new SaleRequest();
			((BaseTransactionRequest)val2).set_ExternalId(ExternalIDUtil.GenerateRandomString(13));
			((BaseTransactionRequest)val2).set_Amount((long)CS_0024_003C_003E8__locals0.request.Amount);
			((TransactionRequest)val2).set_AutoAcceptSignature((bool?)true);
			((BaseTransactionRequest)val2).set_AutoAcceptPaymentConfirmations((bool?)false);
			((BaseTransactionRequest)val2).set_DisableDuplicateChecking((bool?)true);
			((BaseTransactionRequest)val2).set_CardEntryMethods((int?)36623);
			cloverConnector.Sale(val2);
			return;
		}
		if (CS_0024_003C_003E8__locals0.request.RequestType.ToLower().Contains("refund"))
		{
			foreach (PaymentTerminalTransactionLog item in from x in gClass.PaymentTerminalTransactionLogs
				where x.OrderNumber == CS_0024_003C_003E8__locals0.request.OrderNumber && x.Type == "response" && x.DeviceModel == PaymentTerminalModels.Clover.Flex && x.IP == CS_0024_003C_003E8__locals0.ip && x.Data != null
				select x into y
				orderby y.DateCreated descending
				select y)
			{
				if (item.Data != null)
				{
					try
					{
						SaleResponse val3 = JsonConvert.DeserializeObject<SaleResponse>(item.Data);
						if (((PaymentResponse)val3).get_Payment() != null)
						{
							RefundPaymentRequest val4 = new RefundPaymentRequest();
							val4.set_Amount((long)CS_0024_003C_003E8__locals0.request.Amount);
							val4.set_PaymentId(((PaymentResponse)val3).get_Payment().get_id());
							val4.set_OrderId(((PaymentResponse)val3).get_Payment().get_order().get_id());
							if (CS_0024_003C_003E8__locals0.request.Amount == ((PaymentResponse)val3).get_Payment().get_amount())
							{
								val4.set_FullRefund(true);
							}
							else
							{
								val4.set_FullRefund(false);
							}
							cloverConnector.RefundPayment(val4);
							break;
						}
					}
					catch
					{
					}
				}
			}
			return;
		}
		if (CS_0024_003C_003E8__locals0.request.RequestType.ToLower().Contains("settlement"))
		{
			CloseoutRequest val5 = new CloseoutRequest();
			val5.set_AllowOpenTabs(false);
			val5.set_BatchId(CS_0024_003C_003E8__locals0.request.BatchID);
			cloverConnector.Closeout(val5);
		}
	}

	public static string FormatTransactionString(string transactiontype, string baseamount, string ordernumber, string clerkid, string merchantid)
	{
		return addStringLength("transactiontype^" + transactiontype + "^baseamount^" + baseamount + "^invoicenumber^" + ordernumber + "^clerkid^" + clerkid + "^merchantid^" + merchantid + "^transactiondate^" + DateTime.Now.ToString("MMddyy") + "^transactiontime^" + DateTime.Now.ToString("HHmmss") + "^");
	}

	public static Dictionary<string, string> MapTransactionString(string log)
	{
		string[] array = log.Split('^');
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < array.Length - 1; i += 2)
		{
			dictionary.Add(array[i], array[i + 1]);
		}
		return dictionary;
	}

	public static string addStringLength(string request)
	{
		string text = request.Length.ToString();
		while (text.Length < 5)
		{
			text = "0" + text;
		}
		request = text + request;
		return request;
	}

	private static PaymentTransactionObject smethod_0(string string_0, int int_0, string string_1, bool bool_0)
	{
		int num = (string_1.Contains("^settlement^") ? 360 : 60);
		DateTime now = DateTime.Now;
		PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
		byte[] bytes = Encoding.ASCII.GetBytes(string_1);
		NetworkStream stream;
		try
		{
			stream = new TcpClient(string_0, int_0).GetStream();
			int num4 = (stream.ReadTimeout = (stream.WriteTimeout = num * 1000));
			stream.Write(bytes, 0, bytes.Length);
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = true;
		}
		catch
		{
			if (string_1.Contains("^void^"))
			{
				paymentTransactionObject.responsecode = "xxx";
			}
			else
			{
				paymentTransactionObject.responsecode = "999";
			}
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = false;
			return paymentTransactionObject;
		}
		int num5 = 0;
		int num6 = 0;
		int num7 = 8;
		string text = string.Empty;
		bool flag = false;
		int num8 = 0;
		byte[] array = new byte[9999];
		while (!flag)
		{
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = true;
			if (!(now.AddSeconds(num) < DateTime.Now))
			{
				try
				{
					num6 = stream.Read(array, num8, num7);
					now = DateTime.Now;
				}
				catch
				{
				}
				if (num6 != 0)
				{
					if (num7 == 8)
					{
						text = Encoding.ASCII.GetString(array, num8, num6);
						if (!text.Contains("00003ACK") && !text.Contains("00003NAK"))
						{
							if (num7 == 8)
							{
								try
								{
									num7 = Convert.ToInt32(text.Substring(0, 5));
									now = DateTime.Now;
								}
								catch
								{
									array = new byte[8];
									num8 = 0;
									flag = true;
									break;
								}
								num8 += num6;
								num5 += num6;
							}
						}
						else
						{
							num8 += num6;
							now = DateTime.Now;
						}
						continue;
					}
					num5 += num6;
					text = Encoding.ASCII.GetString(array, (num8 - 3 >= 0) ? (num8 - 3) : 0, num7);
					stream.WriteByte(PaymentHelper.HexStringToByteArray("06")[0]);
					flag = true;
					break;
				}
				flag = true;
				break;
			}
			flag = true;
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			text = Encoding.ASCII.GetString(array, (num8 - 3 >= 0) ? (num8 - 3) : 0, num7);
		}
		paymentTransactionObject.rawdata = text;
		Dictionary<string, string> source = MapTransactionString(text);
		paymentTransactionObject.responsecode = (from x in source
			where x.Key == "responsecode"
			select x into y
			select y.Value).FirstOrDefault();
		if (!string.IsNullOrEmpty(paymentTransactionObject.responsecode) && bool_0)
		{
			paymentTransactionObject.cardaccount = (from x in source
				where x.Key == "cardaccount"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.cardissuercode = (from x in source
				where x.Key == "cardissuercode"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.totalamount = (from x in source
				where x.Key == "totalamount"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.approvalcode = (from x in source
				where x.Key == "approvalcode"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.invoicenumber = (from x in source
				where x.Key == "invoicenumber"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.customerreceipt = (from x in source
				where x.Key == "customerreceipt"
				select x into y
				select y.Value).FirstOrDefault();
			paymentTransactionObject.merchantreceipt = (from x in source
				where x.Key == "merchantreceipt"
				select x into y
				select y.Value).FirstOrDefault();
		}
		CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = false;
		return paymentTransactionObject;
	}

	public static string getPATT_PaymentMethods(string cardid)
	{
		try
		{
			return Convert.ToInt32(cardid) switch
			{
				0 => "Interac", 
				1 => "Mastercard", 
				2 => "Visa", 
				3 => "Diners Club", 
				4 => "Discovery", 
				5 => "American Express", 
				6 => "JCB", 
				7 => "PL", 
				8 => "CASH", 
				9 => "Gift Card", 
				10 => "Coupon", 
				_ => "CASH", 
			};
		}
		catch
		{
			return "CASH";
		}
	}

	public static string FormatCloverReceipt(string transactiontype, string rawData, string HipposOrderNumber)
	{
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		string empty = string.Empty;
		CardType cardType;
		if (transactiontype == "sale")
		{
			SaleResponse val = JsonConvert.DeserializeObject<SaleResponse>(rawData);
			string text = "<br/>";
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.BusinessName + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.Address1 + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.City + "," + CompanyHelper.CompanyData.StateProv + "," + CompanyHelper.CompanyData.ZIP + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.Phone + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.String_0 + "</span>" + text;
			empty = empty + text + "HIPPOS ORDER #: " + HipposOrderNumber + text;
			empty = empty + "TRANSACTION DATE/TIME: " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + text;
			empty = empty + "ORDER #: " + ((PaymentResponse)val).get_Payment().get_externalPaymentId() + text;
			empty = empty + "TRANSACTION: " + ((PaymentResponse)val).get_Payment().get_cardTransaction().get_transactionNo() + text;
			empty = empty + "<b>TOTAL: <span style='float:right;'>" + $"{(decimal)((float)((PaymentResponse)val).get_Payment().get_amount() / 100f):C}" + "</span></b>" + text;
			string text2 = empty;
			long? tipAmount = ((PaymentResponse)val).get_Payment().get_tipAmount();
			long num = 0L;
			empty = text2 + ((tipAmount > 0L) ? ("<b>TIPS: <span style='float:right;'>" + $"{(decimal)((float?)((PaymentResponse)val).get_Payment().get_tipAmount() / 100f).Value:C}" + "</span></b>" + text) : string.Empty);
			empty = ((!((BaseResponse)val).get_Success()) ? (empty + text + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>DECLINED</span>" + text + text) : (empty + text + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>APPROVED</span>" + text + text));
			empty = empty + ((PaymentResponse)val).get_Payment().get_tender().get_label()
				.ToUpper() + " " + transactiontype.ToUpper() + " <span style='float:right;'>" + $"{(decimal)((float?)(((PaymentResponse)val).get_Payment().get_amount() + ((PaymentResponse)val).get_Payment().get_tipAmount()) / 100f).Value:C}" + "</span>" + text;
			string[] obj = new string[6] { empty, null, null, null, null, null };
			cardType = ((PaymentResponse)val).get_Payment().get_cardTransaction().get_cardType();
			obj[1] = ((object)(CardType)(ref cardType)).ToString();
			obj[2] = " <span style='float:right;'>************";
			obj[3] = ((PaymentResponse)val).get_Payment().get_cardTransaction().get_last4();
			obj[4] = "</span>";
			obj[5] = text;
			empty = string.Concat(obj);
			string text3 = empty;
			CardEntryType entryType = ((PaymentResponse)val).get_Payment().get_cardTransaction().get_entryType();
			object obj2;
			if (!((object)(CardEntryType)(ref entryType)).ToString().Contains("_"))
			{
				entryType = ((PaymentResponse)val).get_Payment().get_cardTransaction().get_entryType();
				obj2 = ((object)(CardEntryType)(ref entryType)).ToString();
			}
			else
			{
				entryType = ((PaymentResponse)val).get_Payment().get_cardTransaction().get_entryType();
				obj2 = ((object)(CardEntryType)(ref entryType)).ToString().Split('_')[1];
			}
			empty = text3 + "METHOD: " + (string)obj2 + text;
			empty = empty + "REF #: " + ((PaymentResponse)val).get_Payment().get_cardTransaction().get_referenceId() + text;
			empty = empty + "AUTH #: " + ((PaymentResponse)val).get_Payment().get_cardTransaction().get_authCode() + text + text;
			empty = empty + "ORDER ID: " + ((PaymentResponse)val).get_Payment().get_order().get_id() + text;
			return empty + "###RECEIPT_RECIPIENT###" + text;
		}
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.refund = JsonConvert.DeserializeObject<RefundPaymentResponse>(rawData);
		foreach (PaymentTerminalTransactionLog item in from x in new GClass6().PaymentTerminalTransactionLogs
			where x.OrderNumber == ((BaseResponse)CS_0024_003C_003E8__locals0.refund).get_Message() && x.Type == "response" && x.DeviceModel == PaymentTerminalModels.Clover.Flex && x.Data != null
			select x into y
			orderby y.DateCreated descending
			select y)
		{
			if (item != null)
			{
				SaleResponse val2 = JsonConvert.DeserializeObject<SaleResponse>(item.Data);
				if (((PaymentResponse)val2).get_Payment() != null)
				{
					string text4 = "<br/>";
					empty = empty + "ORDER #: " + ((PaymentResponse)val2).get_Payment().get_externalPaymentId() + text4;
					empty = empty + "TRANSACTION: " + ((PaymentResponse)val2).get_Payment().get_cardTransaction().get_transactionNo() + text4;
					empty = empty + "<b>TOTAL: <span style='float:right;'>" + $"{(decimal)((float?)CS_0024_003C_003E8__locals0.refund.get_Refund().get_amount() / 100f).Value:C}" + "</span></b>" + text4;
					empty = empty + ((PaymentResponse)val2).get_Payment().get_tender().get_label()
						.ToUpper() + " " + transactiontype.ToUpper() + " <span style='float:right;'>" + $"{(decimal)((float?)CS_0024_003C_003E8__locals0.refund.get_Refund().get_amount() / 100f).Value:C}" + "</span>" + text4;
					string[] obj3 = new string[6] { empty, null, null, null, null, null };
					cardType = ((PaymentResponse)val2).get_Payment().get_cardTransaction().get_cardType();
					obj3[1] = ((object)(CardType)(ref cardType)).ToString();
					obj3[2] = " <span style='float:right;'>**** **** **** ";
					obj3[3] = ((PaymentResponse)val2).get_Payment().get_cardTransaction().get_last4();
					obj3[4] = "</span>";
					obj3[5] = text4;
					empty = string.Concat(obj3);
					empty = empty + "REF #: " + ((PaymentResponse)val2).get_Payment().get_cardTransaction().get_referenceId() + text4;
					empty = empty + "AUTH #: " + ((PaymentResponse)val2).get_Payment().get_cardTransaction().get_authCode() + text4 + text4;
					empty = empty + "REFUND ID: " + CS_0024_003C_003E8__locals0.refund.get_Refund().get_id() + text4;
					empty = ((!((BaseResponse)CS_0024_003C_003E8__locals0.refund).get_Success()) ? (empty + text4 + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>DECLINED</span>" + text4 + text4) : (empty + text4 + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>APPROVED</span>" + text4 + text4));
					return empty + "###RECEIPT_RECIPIENT###" + text4;
				}
			}
		}
		return empty;
	}

	private static string smethod_1(int int_0)
	{
		return int_0 switch
		{
			0 => "VISA", 
			1 => "MC", 
			2 => "AMEX", 
			3 => "DISCOVER", 
			4 => "DINERS_CLUB", 
			5 => "JCB", 
			6 => "MAESTRO", 
			7 => "SOLO", 
			8 => "LASER", 
			9 => "CHINA_UNION_PAY", 
			10 => "CARTE_BLANCHE", 
			11 => "UNKNOWN", 
			12 => "GIFT_CARD", 
			13 => "EBT", 
			14 => "INTERAC", 
			15 => "OTHER", 
			_ => "UNKNOWN", 
		};
	}
}
