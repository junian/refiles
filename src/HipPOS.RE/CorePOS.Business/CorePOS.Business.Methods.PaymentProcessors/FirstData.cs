using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using com.clover.remotepay.sdk;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class FirstData
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

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public CloverTransactionObject.Request request;

		public string ip;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public RefundPaymentResponse refund;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

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
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.request = request;
		CS_0024_003C_003E8__locals0.ip = ip;
		GClass6 gClass = new GClass6();
		string req_res_data = JsonConvert.SerializeObject(CS_0024_003C_003E8__locals0.request, Formatting.Indented, new JsonSerializerSettings
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			MaxDepth = 2000
		});
		PaymentHelper.RecordPaymentTransactionLog(PaymentProviderNames.FirstData, PaymentTerminalModels.Clover.Flex, CS_0024_003C_003E8__locals0.ip, port, req_res_data, "request", CS_0024_003C_003E8__locals0.request.OrderNumber, paymentMethod);
		if (CS_0024_003C_003E8__locals0.request.RequestType.ToLower().Contains("sale"))
		{
			SaleRequest saleRequest = new SaleRequest();
			saleRequest.ExternalId = ExternalIDUtil.GenerateRandomString(13);
			saleRequest.Amount = CS_0024_003C_003E8__locals0.request.Amount;
			saleRequest.AutoAcceptSignature = true;
			saleRequest.AutoAcceptPaymentConfirmations = false;
			saleRequest.DisableDuplicateChecking = true;
			saleRequest.CardEntryMethods = 36623;
			cloverConnector.Sale(saleRequest);
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
						SaleResponse saleResponse = JsonConvert.DeserializeObject<SaleResponse>(item.Data);
						if (saleResponse.Payment != null)
						{
							RefundPaymentRequest refundPaymentRequest = new RefundPaymentRequest();
							refundPaymentRequest.Amount = CS_0024_003C_003E8__locals0.request.Amount;
							refundPaymentRequest.PaymentId = saleResponse.Payment.id;
							refundPaymentRequest.OrderId = saleResponse.Payment.order.id;
							if (CS_0024_003C_003E8__locals0.request.Amount == saleResponse.Payment.amount)
							{
								refundPaymentRequest.FullRefund = true;
							}
							else
							{
								refundPaymentRequest.FullRefund = false;
							}
							cloverConnector.RefundPayment(refundPaymentRequest);
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
			CloseoutRequest closeoutRequest = new CloseoutRequest();
			closeoutRequest.AllowOpenTabs = false;
			closeoutRequest.BatchId = CS_0024_003C_003E8__locals0.request.BatchID;
			cloverConnector.Closeout(closeoutRequest);
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
			int readTimeout = (stream.WriteTimeout = num * 1000);
			stream.ReadTimeout = readTimeout;
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
		int num3 = 0;
		int num4 = 0;
		int num5 = 8;
		string text = string.Empty;
		bool flag = false;
		int num6 = 0;
		byte[] array = new byte[9999];
		while (!flag)
		{
			CorePOS.Data.Properties.Settings.Default["isPaymentTerminalConnected"] = true;
			if (!(now.AddSeconds(num) < DateTime.Now))
			{
				try
				{
					num4 = stream.Read(array, num6, num5);
					now = DateTime.Now;
				}
				catch
				{
				}
				if (num4 != 0)
				{
					if (num5 == 8)
					{
						text = Encoding.ASCII.GetString(array, num6, num4);
						if (!text.Contains("00003ACK") && !text.Contains("00003NAK"))
						{
							if (num5 == 8)
							{
								try
								{
									num5 = Convert.ToInt32(text.Substring(0, 5));
									now = DateTime.Now;
								}
								catch
								{
									array = new byte[8];
									num6 = 0;
									flag = true;
									break;
								}
								num6 += num4;
								num3 += num4;
							}
						}
						else
						{
							num6 += num4;
							now = DateTime.Now;
						}
						continue;
					}
					num3 += num4;
					text = Encoding.ASCII.GetString(array, (num6 - 3 >= 0) ? (num6 - 3) : 0, num5);
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
			text = Encoding.ASCII.GetString(array, (num6 - 3 >= 0) ? (num6 - 3) : 0, num5);
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
		string empty = string.Empty;
		if (transactiontype == "sale")
		{
			SaleResponse saleResponse = JsonConvert.DeserializeObject<SaleResponse>(rawData);
			string text = "<br/>";
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.BusinessName + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.Address1 + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.City + "," + CompanyHelper.CompanyData.StateProv + "," + CompanyHelper.CompanyData.ZIP + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.Phone + "</span>" + text;
			empty = empty + "<span style='text-align:center;'>" + CompanyHelper.CompanyData.String_0 + "</span>" + text;
			empty = empty + text + "HIPPOS ORDER #: " + HipposOrderNumber + text;
			empty = empty + "TRANSACTION DATE/TIME: " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + text;
			empty = empty + "ORDER #: " + saleResponse.Payment.externalPaymentId + text;
			empty = empty + "TRANSACTION: " + saleResponse.Payment.cardTransaction.transactionNo + text;
			empty = empty + "<b>TOTAL: <span style='float:right;'>" + $"{(decimal)((float)saleResponse.Payment.amount / 100f):C}" + "</span></b>" + text;
			string text2 = empty;
			long? tipAmount = saleResponse.Payment.tipAmount;
			long num = 0L;
			empty = text2 + ((tipAmount > 0L) ? ("<b>TIPS: <span style='float:right;'>" + $"{(decimal)((float?)saleResponse.Payment.tipAmount / 100f).Value:C}" + "</span></b>" + text) : string.Empty);
			empty = ((!saleResponse.Success) ? (empty + text + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>DECLINED</span>" + text + text) : (empty + text + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>APPROVED</span>" + text + text));
			empty = empty + saleResponse.Payment.tender.label.ToUpper() + " " + transactiontype.ToUpper() + " <span style='float:right;'>" + $"{(decimal)((float?)(saleResponse.Payment.amount + saleResponse.Payment.tipAmount) / 100f).Value:C}" + "</span>" + text;
			empty = empty + saleResponse.Payment.cardTransaction.cardType.ToString() + " <span style='float:right;'>************" + saleResponse.Payment.cardTransaction.last4 + "</span>" + text;
			empty = empty + "METHOD: " + (saleResponse.Payment.cardTransaction.entryType.ToString().Contains("_") ? saleResponse.Payment.cardTransaction.entryType.ToString().Split('_')[1] : saleResponse.Payment.cardTransaction.entryType.ToString()) + text;
			empty = empty + "REF #: " + saleResponse.Payment.cardTransaction.referenceId + text;
			empty = empty + "AUTH #: " + saleResponse.Payment.cardTransaction.authCode + text + text;
			empty = empty + "ORDER ID: " + saleResponse.Payment.order.id + text;
			return empty + "###RECEIPT_RECIPIENT###" + text;
		}
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.refund = JsonConvert.DeserializeObject<RefundPaymentResponse>(rawData);
		foreach (PaymentTerminalTransactionLog item in from x in new GClass6().PaymentTerminalTransactionLogs
			where x.OrderNumber == CS_0024_003C_003E8__locals0.refund.Message && x.Type == "response" && x.DeviceModel == PaymentTerminalModels.Clover.Flex && x.Data != null
			select x into y
			orderby y.DateCreated descending
			select y)
		{
			if (item != null)
			{
				SaleResponse saleResponse2 = JsonConvert.DeserializeObject<SaleResponse>(item.Data);
				if (saleResponse2.Payment != null)
				{
					string text3 = "<br/>";
					empty = empty + "ORDER #: " + saleResponse2.Payment.externalPaymentId + text3;
					empty = empty + "TRANSACTION: " + saleResponse2.Payment.cardTransaction.transactionNo + text3;
					empty = empty + "<b>TOTAL: <span style='float:right;'>" + $"{(decimal)((float?)CS_0024_003C_003E8__locals0.refund.Refund.amount / 100f).Value:C}" + "</span></b>" + text3;
					empty = empty + saleResponse2.Payment.tender.label.ToUpper() + " " + transactiontype.ToUpper() + " <span style='float:right;'>" + $"{(decimal)((float?)CS_0024_003C_003E8__locals0.refund.Refund.amount / 100f).Value:C}" + "</span>" + text3;
					empty = empty + saleResponse2.Payment.cardTransaction.cardType.ToString() + " <span style='float:right;'>**** **** **** " + saleResponse2.Payment.cardTransaction.last4 + "</span>" + text3;
					empty = empty + "REF #: " + saleResponse2.Payment.cardTransaction.referenceId + text3;
					empty = empty + "AUTH #: " + saleResponse2.Payment.cardTransaction.authCode + text3 + text3;
					empty = empty + "REFUND ID: " + CS_0024_003C_003E8__locals0.refund.Refund.id + text3;
					empty = ((!CS_0024_003C_003E8__locals0.refund.Success) ? (empty + text3 + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>DECLINED</span>" + text3 + text3) : (empty + text3 + "<span style='text-align:center; font-size: 16pt; font-weight:bold;'>APPROVED</span>" + text3 + text3));
					return empty + "###RECEIPT_RECIPIENT###" + text3;
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
