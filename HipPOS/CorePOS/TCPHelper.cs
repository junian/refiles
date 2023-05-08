using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;

namespace CorePOS;

public class TCPHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string ordernumber;

		public string table;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CProcessBillPayment_003Eb__0(Order x)
		{
			if (x.OrderNumber == ordernumber)
			{
				return !x.Paid;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PATT_Posera.Request.POSRequest req;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CGetTables_003Eb__1(Layout x)
		{
			return x.TableName == req.POSDefaultInfo.table;
		}

		internal bool _003CGetTables_003Eb__2(Layout x)
		{
			return x.TableID.ToString() == req.POSDefaultInfo.table;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Employee emp;

		public _003C_003Ec__DisplayClass4_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CGetTables_003Eb__4(OrderTotal x)
		{
			return x.ServedByUserID == emp.EmployeeID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public OrderTotal bill;

		public _003C_003Ec__DisplayClass4_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	public void ProcessClient(TcpClient client, X509Certificate serverCertificate)
	{
		try
		{
			if (serverCertificate != null)
			{
				SslStream sslStream = new SslStream(client.GetStream(), leaveInnerStreamOpen: false);
				try
				{
					sslStream.ReadTimeout = 5000;
					sslStream.WriteTimeout = 5000;
					sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12, checkCertificateRevocation: false);
					string string_ = method_4(sslStream);
					byte[] array = method_0(string_);
					sslStream.Write(array, 0, array.Length);
					sslStream.Close();
				}
				catch (AuthenticationException ex)
				{
					if (ex.InnerException != null)
					{
						Console.WriteLine("Inner exception: {0}", ex.InnerException.Message);
					}
					sslStream.Close();
					return;
				}
			}
			else
			{
				NetworkStream stream = client.GetStream();
				byte[] array2 = new byte[client.ReceiveBufferSize];
				int count = stream.Read(array2, 0, client.ReceiveBufferSize);
				string string_ = Encoding.ASCII.GetString(array2, 0, count);
				byte[] array3 = method_0(string_);
				stream.Write(array3, 0, array3.Length);
				stream.Close();
			}
			client.GetStream().Close();
			client.Close();
		}
		catch (Exception)
		{
			client.GetStream().Close();
			client.Close();
		}
	}

	private byte[] method_0(string string_0)
	{
		string_0 = string_0.Substring(5, string_0.Length - 5);
		LogHelper.WriteLog(string_0, LogTypes.tcp_log);
		PATT_Posera.Request.POSRequest pOSRequest = (PATT_Posera.Request.POSRequest)new XmlSerializer(typeof(PATT_Posera.Request.POSRequest)).Deserialize(new StringReader(string_0));
		if (pOSRequest.Payment == null)
		{
			return method_3(pOSRequest);
		}
		return method_2(pOSRequest);
	}

	private byte[] method_1(PATT_Posera.Request.POSRequest posrequest_0)
	{
		new OrderMethods(new GClass6());
		return null;
	}

	private byte[] method_2(PATT_Posera.Request.POSRequest posrequest_0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		short num = (short)EmployeeMethods.getEmployeeByPIN(posrequest_0.POSDefaultInfo.server).EmployeeID;
		GClass6 gClass = new GClass6();
		OrderMethods orderMethods = new OrderMethods(gClass);
		if (posrequest_0.POSDefaultInfo.check.Length > 7 && posrequest_0.POSDefaultInfo.check.Substring(0, 3) == "999")
		{
			CS_0024_003C_003E8__locals0.ordernumber = "WEB" + posrequest_0.POSDefaultInfo.check.Substring(3, posrequest_0.POSDefaultInfo.check.Length - 3);
		}
		else
		{
			CS_0024_003C_003E8__locals0.ordernumber = OrderMethods.FormatOrderNumber(posrequest_0.POSDefaultInfo.check);
		}
		List<Order> list = (from x in orderMethods.OpenOrders()
			where x.OrderNumber == CS_0024_003C_003E8__locals0.ordernumber && !x.Paid
			select x into y
			orderby y.DateCreated
			select y).ToList();
		if (list.Count() == 0)
		{
			return Encoding.ASCII.GetBytes("0");
		}
		decimal num2 = list.Sum((Order x) => x.Total);
		CS_0024_003C_003E8__locals0.table = null;
		bool flag = false;
		flag = ((SettingsHelper.GetSettingValueByKey("auto_clear_table") == "ON") ? true : false);
		decimal num3 = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("card_transaction_fee"));
		if (num3 > 0m)
		{
			decimal num4 = list.Sum((Order x) => x.Total) * (num3 / 100m);
			if (num4 > 0m && list.Where((Order x) => x.ItemName == "Transaction Fee").FirstOrDefault() == null)
			{
				Order order = list.FirstOrDefault();
				Order order2 = OrderMethods.CreateTransactionFeeOrder(num4, order.OrderNumber, order.OrderType, order.Customer, order.CustomerInfo, order.CustomerInfoName, order.PaymentMethods.Replace(',', '.'), num, order.TerminalID, order.GuestCount);
				gClass.Orders.InsertOnSubmit(order2);
				list.Add(order2);
			}
		}
		string pATT_PaymentMethods = FirstData.getPATT_PaymentMethods(posrequest_0.Payment.CardType);
		decimal num5 = list.Sum((Order a) => a.SubTotal);
		foreach (Order item in list)
		{
			if (posrequest_0.Payment.Pamt / 100m + item.TenderAmount >= num2)
			{
				item.Paid = true;
				item.DatePaid = DateTime.Now;
				if (flag)
				{
					item.DateCleared = DateTime.Now;
				}
			}
			if (item.PaymentMethods == "SAVED ORDER")
			{
				item.PaymentMethods = "";
			}
			item.PaymentMethods = item.PaymentMethods + pATT_PaymentMethods + "=" + ((posrequest_0.Payment.Pamt + posrequest_0.Payment.Tamt) / 100m).ToString("0.00") + "|";
			item.TenderAmount += (posrequest_0.Payment.Pamt + posrequest_0.Payment.Tamt) / 100m;
			item.TipAmount += posrequest_0.Payment.Tamt / 100m;
			item.TipRecorded = ((item.TipAmount > 0m) ? true : false);
			if (item.TipAmount > 0m)
			{
				List<string> list2 = new List<string>();
				foreach (CustomTipSharing item2 in MemoryLoadedObjects.all_tip_sharing.Where((CustomTipSharing a) => a.Percentage > 0m))
				{
					decimal num6 = item.TipAmount * item2.Percentage / 100m;
					if (num6 > 0m && item2.TipShareType == 1 && item.TipAmount > 0m)
					{
						list2.Add(item2.TipName + "=" + num6.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
					else if (item2.TipShareType == 2)
					{
						num6 = num5 * item2.Percentage / 100m;
						list2.Add(item2.TipName + "=" + num6.ToString("0.00") + "=" + item2.Percentage.ToString("0.##"));
					}
				}
				if (list2 != null && list2.Count > 0)
				{
					item.TipShareDesc = string.Join("|", list2);
				}
			}
			item.UserCashout = num;
			item.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.table))
			{
				CS_0024_003C_003E8__locals0.table = item.Customer;
			}
		}
		gClass.Refresh(RefreshMode.OverwriteCurrentValues, list);
		if ((from x in gClass.Orders.Where((Order o) => o.Customer == CS_0024_003C_003E8__locals0.table && o.OrderType == OrderTypes.DineIn && (o.Paid == false || (o.Paid == true && o.DateCleared == null)) && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0)).ToList()
			select x.OrderNumber).Distinct().ToList().Count == 0)
		{
			GuestMethods.UpdateTableGuestCapacity(CS_0024_003C_003E8__locals0.table.Replace("Table", string.Empty).Trim(), 0, 0);
		}
		PATT_Posera.Response.Ident ident = new PATT_Posera.Response.Ident
		{
			Id = posrequest_0.Ident.id,
			Ttype = posrequest_0.Ident.ttype
		};
		PATT_Posera.Response.POSDefaultInfo pOSDefaultInfo = new PATT_Posera.Response.POSDefaultInfo
		{
			Server = posrequest_0.POSDefaultInfo.server,
			Track2 = posrequest_0.POSDefaultInfo.track2,
			Res = "1",
			Rtext = "success",
			Table = posrequest_0.POSDefaultInfo.table,
			Check = posrequest_0.POSDefaultInfo.check
		};
		new StringWriter();
		XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[1] { XmlQualifiedName.Empty });
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(PATT_Posera.Response.POSResponse));
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = false;
		xmlWriterSettings.OmitXmlDeclaration = true;
		PATT_Posera.Response.POSResponse o2 = new PATT_Posera.Response.POSResponse
		{
			Checks = null,
			Ident = ident,
			POSDefaultInfo = pOSDefaultInfo
		};
		string text;
		using (StringWriter stringWriter = new StringWriter())
		{
			using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);
			xmlSerializer.Serialize(xmlWriter, o2, namespaces);
			text = stringWriter.ToString().Replace("'", string.Empty);
			text = text.Replace("\"", "'");
		}
		string text2 = text.Length.ToString();
		if (text2.Length < 5)
		{
			for (int i = text2.Length; i < 5; i++)
			{
				text2 = "0" + text2;
			}
		}
		return Encoding.ASCII.GetBytes(text2 + text);
	}

	private byte[] method_3(PATT_Posera.Request.POSRequest posrequest_0)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.req = posrequest_0;
		try
		{
			_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
			string text = "success";
			string res = "1";
			string text2 = null;
			string text3 = null;
			if (CS_0024_003C_003E8__locals0.req.POSDefaultInfo.table != "0" && CS_0024_003C_003E8__locals0.req.POSDefaultInfo.table != string.Empty)
			{
				if (MemoryLoadedObjects.layout_alltables == null || !MemoryLoadedObjects.layout_alltables.Any())
				{
					MemoryLoadedObjects.layout_alltables = new GClass6().Layouts.Where((Layout x) => x.Active == true && ((int?)x.Rotation == (int?)86 || (int?)x.Rotation == (int?)72)).ToList();
				}
				Layout layout = MemoryLoadedObjects.layout_alltables.Where((Layout x) => x.TableName == CS_0024_003C_003E8__locals0.req.POSDefaultInfo.table).FirstOrDefault();
				if (layout == null)
				{
					layout = MemoryLoadedObjects.layout_alltables.Where((Layout x) => x.TableID.ToString() == CS_0024_003C_003E8__locals0.req.POSDefaultInfo.table).FirstOrDefault();
					if (layout == null)
					{
						text = "Invalid Table";
						res = "846";
					}
					else
					{
						text3 = "Table " + layout.TableName;
					}
				}
				else
				{
					text3 = "Table " + layout.TableName;
				}
			}
			if (CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check != "0")
			{
				text2 = ((CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check.Length <= 7 || !(CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check.Substring(0, 3) == "999")) ? OrderMethods.FormatOrderNumber(CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check) : ("WEB" + CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check.Substring(3, CS_0024_003C_003E8__locals0.req.POSDefaultInfo.check.Length - 3)));
			}
			CS_0024_003C_003E8__locals1.emp = EmployeeMethods.getEmployeeByPIN(CS_0024_003C_003E8__locals0.req.POSDefaultInfo.server);
			List<OrderTotal> list = null;
			if (CS_0024_003C_003E8__locals1.emp == null)
			{
				text = "Invalid Employee Password";
				res = "832";
			}
			else
			{
				list = (from x in new OrderMethods().OpenDineInBills(text3, text2)
					where !string.IsNullOrEmpty(x.OrderNumber)
					select x).ToList();
				string roleName = CS_0024_003C_003E8__locals1.emp.Users.FirstOrDefault().Role.RoleName;
				if (roleName == Roles.employee || roleName == Roles.driver)
				{
					list = list.Where((OrderTotal x) => x.ServedByUserID == CS_0024_003C_003E8__locals1.emp.EmployeeID).ToList();
				}
			}
			PATT_Posera.Response.Checks checks = new PATT_Posera.Response.Checks();
			List<PATT_Posera.Response.Check> list2 = new List<PATT_Posera.Response.Check>();
			if (text3 != null && (list == null || list.Count() == 0))
			{
				text = "Invalid Table For Employee";
				res = "846";
			}
			else if (text2 != null && (list == null || list.Count() == 0))
			{
				text = "Check Does Not Exist";
				res = "850";
			}
			else if (!(text == "Invalid Table") && list != null)
			{
				List<string> list3 = new List<string>();
				int num = 0;
				int num2 = 0;
				decimal num3 = default(decimal);
				GClass6 gClass = new GClass6();
				int num4 = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("auto_gratuity_count"));
				bool flag = SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON";
				decimal num5 = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("card_transaction_fee"));
				using List<OrderTotal>.Enumerator enumerator = list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_2();
					CS_0024_003C_003E8__locals2.bill = enumerator.Current;
					num = (int)(CS_0024_003C_003E8__locals2.bill.TenderedAmount * 100m);
					PATT_Posera.Response.Check check = new PATT_Posera.Response.Check();
					num2 = (int)(CS_0024_003C_003E8__locals2.bill.Tax * 100m);
					check.Tax = num2.ToString();
					check.Amt = ((int)(CS_0024_003C_003E8__locals2.bill.Sub * 100m)).ToString();
					if (flag && GuestMethods.GetCurrentTableGuestCapacity(CS_0024_003C_003E8__locals2.bill.Customer.Replace("Table ", string.Empty)) >= num4)
					{
						num3 = OrderMethods.ComputeAutoGratuity(CS_0024_003C_003E8__locals2.bill.OrderNumber, Thread.CurrentThread.CurrentCulture.Name);
						if (num3 > 0m)
						{
							check.Amt = ((int)(CS_0024_003C_003E8__locals2.bill.Sub * 100m) + (int)(num3 * 100m)).ToString();
						}
					}
					if (num5 > 0m)
					{
						decimal num6 = (CS_0024_003C_003E8__locals2.bill.Sub + CS_0024_003C_003E8__locals2.bill.Tax) * (num5 / 100m);
						List<Order> source = gClass.Orders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals2.bill.OrderNumber).ToList();
						if (num6 > 0m && source.Where((Order x) => x.ItemName == "Transaction Fee").FirstOrDefault() == null)
						{
							check.Amt = (Convert.ToInt32(check.Amt) + Convert.ToInt32(num6 * 100m)).ToString();
						}
					}
					if (num > 0)
					{
						num -= num2;
						if (num < 0)
						{
							check.Tax = (-num).ToString();
						}
						else
						{
							check.Tax = "0";
						}
						num2 = (int)(CS_0024_003C_003E8__locals2.bill.Sub * 100m);
						num -= num2;
						if (num < 0)
						{
							check.Amt = (-num).ToString();
						}
						else
						{
							check.Amt = "0";
						}
					}
					if (CS_0024_003C_003E8__locals2.bill.OrderNumber.Contains("WEB"))
					{
						check.Chkno = CS_0024_003C_003E8__locals2.bill.OrderNumber.Replace("WEB", "999");
					}
					else
					{
						check.Chkno = Convert.ToInt32(new string(CS_0024_003C_003E8__locals2.bill.OrderNumber.Where((char c) => char.IsDigit(c)).ToArray())).ToString();
					}
					check.Chkname = CS_0024_003C_003E8__locals2.bill.OrderNumber;
					check.Tablename = CS_0024_003C_003E8__locals2.bill.Customer.Replace("Table ", string.Empty);
					check.Tableno = CS_0024_003C_003E8__locals2.bill.CustomerInfo;
					if (check.Tax != "0" || check.Amt != "0")
					{
						list2.Add(check);
					}
					if (!list3.Contains(CS_0024_003C_003E8__locals2.bill.Customer))
					{
						list3.Add(CS_0024_003C_003E8__locals2.bill.Customer);
					}
				}
			}
			checks.Check = list2;
			PATT_Posera.Response.Ident ident = new PATT_Posera.Response.Ident
			{
				Id = CS_0024_003C_003E8__locals0.req.Ident.id,
				Ttype = CS_0024_003C_003E8__locals0.req.Ident.ttype
			};
			PATT_Posera.Response.POSDefaultInfo pOSDefaultInfo = new PATT_Posera.Response.POSDefaultInfo
			{
				Server = CS_0024_003C_003E8__locals0.req.POSDefaultInfo.server,
				Track2 = CS_0024_003C_003E8__locals0.req.POSDefaultInfo.track2,
				Res = res,
				Rtext = text,
				Table = CS_0024_003C_003E8__locals0.req.POSDefaultInfo.table,
				Check = ((list == null) ? "0" : list.Count().ToString())
			};
			PATT_Posera.Response.POSResponse o = new PATT_Posera.Response.POSResponse
			{
				Checks = checks,
				Ident = ident,
				POSDefaultInfo = pOSDefaultInfo
			};
			new StringWriter();
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[1] { XmlQualifiedName.Empty });
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PATT_Posera.Response.POSResponse));
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = false;
			xmlWriterSettings.OmitXmlDeclaration = true;
			string text4;
			using (StringWriter stringWriter = new StringWriter())
			{
				using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);
				xmlSerializer.Serialize(xmlWriter, o, namespaces);
				text4 = stringWriter.ToString().Replace("'", string.Empty);
				text4 = text4.Replace("\"", "'");
			}
			string text5 = text4.Length.ToString();
			if (text5.Length < 5)
			{
				for (int i = text5.Length; i < 5; i++)
				{
					text5 = "0" + text5;
				}
			}
			return Encoding.ASCII.GetBytes(text5 + text4);
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			return null;
		}
	}

	private string method_4(SslStream sslStream_0)
	{
		byte[] array = new byte[99999];
		StringBuilder stringBuilder = new StringBuilder();
		int num = -1;
		num = sslStream_0.Read(array, 0, array.Length);
		Decoder decoder = Encoding.UTF8.GetDecoder();
		char[] array2 = new char[decoder.GetCharCount(array, 0, num)];
		decoder.GetChars(array, 0, num, array2, 0);
		stringBuilder.Append(array2);
		return stringBuilder.ToString();
	}

	public TCPHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
	}
}
