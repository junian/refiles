using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class MonerisCore
{
	public static PaymentTransactionObject SendToTerminal(string provider, string model, string ip, int port, string request, bool parseObject, string orderNumber, string paymentMethod)
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
		PaymentTransactionObject paymentTransactionObject = ((!(model == PaymentTerminalModels.Ingenico.Desk5000)) ? new PaymentTransactionObject() : smethod_0(provider, CS_0024_003C_003E8__locals0.ip, port, request, parseObject));
		if (paymentTransactionObject.responsecode != null)
		{
			PaymentHelper.RecordPaymentTransactionLog(provider, model, CS_0024_003C_003E8__locals0.ip, port, paymentTransactionObject.rawdata, "response", orderNumber, paymentMethod);
		}
		return paymentTransactionObject;
	}

	public static string FormatTransactionString(string transactiontype, int totalamount, int taxamount, string ordernumber, string clerkid, string merchantid)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
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
		Convert.ToChar(28);
		if (transactiontype == IngenicoTransactionTypes.settlement)
		{
			return "";
		}
		MonerisCoreObjects.RequestObjects.Request obj = new MonerisCoreObjects.RequestObjects.Request
		{
			action = transactiontype,
			apiVersion = "1.0",
			configCode = "C000040SI",
			ecrId = "Hippos Restaurant",
			merchantId = merchantid,
			idempotencyKey = StringCipher.RandomString(50),
			requestId = StringCipher.RandomString(50),
			requestTimestamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
			transactionId = string.Empty,
			data = new MonerisCoreObjects.RequestObjects.Data
			{
				order = new MonerisCoreObjects.RequestObjects.Order
				{
					orderId = ordernumber,
					totalAmount = totalamount,
					preTaxAmount = totalamount - taxamount
				}
			}
		};
		JsonSerializerSettings val = new JsonSerializerSettings();
		val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
		val.set_MaxDepth((int?)2000);
		return FirstData.addStringLength(JsonConvert.SerializeObject((object)obj, (Formatting)1, val));
	}

	private static PaymentTransactionObject smethod_0(string string_0, string string_1, int int_0, string string_2, bool bool_0)
	{
		int num = ((string_2.Substring(0, 2) == "20") ? 360 : 60);
		PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
		byte[] bytes = Encoding.ASCII.GetBytes(string_2);
		NetworkStream stream;
		try
		{
			stream = new TcpClient(string_1, int_0).GetStream();
			int num4 = (stream.ReadTimeout = (stream.WriteTimeout = num * 1000));
			stream.Write(bytes, 0, bytes.Length);
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
			return paymentTransactionObject;
		}
		int num5 = 0;
		int num6 = 0;
		int count = 8;
		string value = string.Empty;
		string empty = string.Empty;
		bool flag = false;
		int num7 = 0;
		byte[] array = new byte[1024];
		int num8 = 0;
		if (string_2 == "20\u001c0071")
		{
			num8 = 1;
		}
		while (!flag)
		{
			num6 = stream.Read(array, num7, 1024);
			if (num6 != 0)
			{
				num5 += num6;
				empty = Encoding.ASCII.GetString(array).Replace("\u0011", string.Empty);
				empty = empty.Replace("\0", string.Empty).Replace("\u001c", "^");
				if (!string.IsNullOrEmpty(empty))
				{
					if (empty.Substring(0, 3) == "990")
					{
						value = empty;
					}
					switch (num8)
					{
					default:
						stream.WriteByte(PaymentHelper.HexStringToByteArray("06")[0]);
						break;
					case 1:
						stream.WriteByte(PaymentHelper.HexStringToByteArray("06")[0]);
						flag = true;
						break;
					case 0:
					{
						Thread.Sleep(1000);
						byte[] bytes2 = Encoding.ASCII.GetBytes("990");
						stream.Write(bytes2, 0, 3);
						break;
					}
					}
					num8++;
				}
				continue;
			}
			flag = true;
			break;
		}
		if (string.IsNullOrEmpty(value))
		{
			value = Encoding.ASCII.GetString(array, (num7 - 3 >= 0) ? (num7 - 3) : 0, count);
		}
		return paymentTransactionObject;
	}
}
