using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class SPIn
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

	public static PaymentTransactionObject SendToTerminal(string provider, string model, string ip, int port, string request, bool parseObject, string orderNumber, string paymentMethod)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.ip = ip;
		(from x in new GClass6().PaymentTerminalTransactionLogs
			where x.IP == CS_0024_003C_003E8__locals0.ip
			select x into y
			orderby y.DateCreated descending
			select y).FirstOrDefault();
		PaymentHelper.RecordPaymentTransactionLog(provider, model, CS_0024_003C_003E8__locals0.ip, port, request, "request", orderNumber, paymentMethod);
		PaymentTransactionObject paymentTransactionObject = smethod_0(CS_0024_003C_003E8__locals0.ip, port, request, parseObject);
		if (paymentTransactionObject.responsecode != null)
		{
			PaymentHelper.RecordPaymentTransactionLog(provider, model, CS_0024_003C_003E8__locals0.ip, port, paymentTransactionObject.rawdata, "response", orderNumber, paymentMethod);
		}
		return paymentTransactionObject;
	}

	private static PaymentTransactionObject smethod_0(string string_0, int int_0, string string_1, bool bool_0)
	{
		_ = DateTime.Now;
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("http://" + string_0 + ":" + int_0 + "/cgi.html?TerminalTransaction=" + string_1);
			obj.ContentType = "application/xml";
			obj.Method = "GET";
			obj.GetRequestStream();
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
			string s = streamReader.ReadToEnd();
			_ = (PATT_Posera.Request.POSRequest)new XmlSerializer(typeof(SPInObjects.ResponseObj.Response)).Deserialize(new StringReader(s));
		}
		catch (Exception)
		{
		}
		return new PaymentTransactionObject();
	}
}
