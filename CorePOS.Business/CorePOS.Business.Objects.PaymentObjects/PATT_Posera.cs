using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace CorePOS.Business.Objects.PaymentObjects;

public class PATT_Posera
{
	public class Request
	{
		[XmlRoot(ElementName = "POSRequest")]
		public class POSRequest
		{
			[CompilerGenerated]
			private Ident ident_0;

			[CompilerGenerated]
			private POSDefaultInfo posdefaultInfo_0;

			[CompilerGenerated]
			private Payment payment_0;

			[XmlElement(ElementName = "Ident")]
			public Ident Ident
			{
				[CompilerGenerated]
				get
				{
					return ident_0;
				}
				[CompilerGenerated]
				set
				{
					ident_0 = value;
				}
			}

			[XmlElement(ElementName = "POSDefaultInfo")]
			public POSDefaultInfo POSDefaultInfo
			{
				[CompilerGenerated]
				get
				{
					return posdefaultInfo_0;
				}
				[CompilerGenerated]
				set
				{
					posdefaultInfo_0 = value;
				}
			}

			[XmlElement(ElementName = "Payment")]
			public Payment Payment
			{
				[CompilerGenerated]
				get
				{
					return payment_0;
				}
				[CompilerGenerated]
				set
				{
					payment_0 = value;
				}
			}

			public POSRequest()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		public class Ident
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string string_2;

			[XmlAttribute]
			public string id
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute]
			public string termserialno
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			[XmlAttribute]
			public string ttype
			{
				[CompilerGenerated]
				get
				{
					return string_2;
				}
				[CompilerGenerated]
				set
				{
					string_2 = value;
				}
			}

			public Ident()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		public class POSDefaultInfo
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string zQiQuadFu3;

			[CompilerGenerated]
			private string string_2;

			[XmlAttribute]
			public string server
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute]
			public string table
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			[XmlAttribute]
			public string check
			{
				[CompilerGenerated]
				get
				{
					return zQiQuadFu3;
				}
				[CompilerGenerated]
				set
				{
					zQiQuadFu3 = value;
				}
			}

			[XmlAttribute]
			public string track2
			{
				[CompilerGenerated]
				get
				{
					return string_2;
				}
				[CompilerGenerated]
				set
				{
					string_2 = value;
				}
			}

			public POSDefaultInfo()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		[XmlRoot(ElementName = "Payment")]
		public class Payment
		{
			[CompilerGenerated]
			private decimal decimal_0;

			[CompilerGenerated]
			private decimal decimal_1;

			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string string_2;

			[CompilerGenerated]
			private string string_3;

			[CompilerGenerated]
			private string string_4;

			[CompilerGenerated]
			private string string_5;

			[CompilerGenerated]
			private string string_6;

			[XmlAttribute(AttributeName = "pamt")]
			public decimal Pamt
			{
				[CompilerGenerated]
				get
				{
					return decimal_0;
				}
				[CompilerGenerated]
				set
				{
					decimal_0 = value;
				}
			}

			[XmlAttribute(AttributeName = "tamt")]
			public decimal Tamt
			{
				[CompilerGenerated]
				get
				{
					return decimal_1;
				}
				[CompilerGenerated]
				set
				{
					decimal_1 = value;
				}
			}

			[XmlAttribute(AttributeName = "cback")]
			public string Cback
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute(AttributeName = "schrg")]
			public string Schrg
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			[XmlAttribute(AttributeName = "cardType")]
			public string CardType
			{
				[CompilerGenerated]
				get
				{
					return string_2;
				}
				[CompilerGenerated]
				set
				{
					string_2 = value;
				}
			}

			[XmlAttribute(AttributeName = "acct")]
			public string Acct
			{
				[CompilerGenerated]
				get
				{
					return string_3;
				}
				[CompilerGenerated]
				set
				{
					string_3 = value;
				}
			}

			[XmlAttribute(AttributeName = "exp")]
			public string Exp
			{
				[CompilerGenerated]
				get
				{
					return string_4;
				}
				[CompilerGenerated]
				set
				{
					string_4 = value;
				}
			}

			[XmlAttribute(AttributeName = "track2")]
			public string Track2
			{
				[CompilerGenerated]
				get
				{
					return string_5;
				}
				[CompilerGenerated]
				set
				{
					string_5 = value;
				}
			}

			[XmlAttribute(AttributeName = "edc")]
			public string Edc
			{
				[CompilerGenerated]
				get
				{
					return string_6;
				}
				[CompilerGenerated]
				set
				{
					string_6 = value;
				}
			}

			public Payment()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		public Request()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Response
	{
		[XmlRoot(ElementName = "POSResponse")]
		public class POSResponse
		{
			[CompilerGenerated]
			private Ident ident_0;

			[CompilerGenerated]
			private POSDefaultInfo posdefaultInfo_0;

			[CompilerGenerated]
			private Checks checks_0;

			[XmlElement(ElementName = "Ident")]
			public Ident Ident
			{
				[CompilerGenerated]
				get
				{
					return ident_0;
				}
				[CompilerGenerated]
				set
				{
					ident_0 = value;
				}
			}

			[XmlElement(ElementName = "POSDefaultInfo")]
			public POSDefaultInfo POSDefaultInfo
			{
				[CompilerGenerated]
				get
				{
					return posdefaultInfo_0;
				}
				[CompilerGenerated]
				set
				{
					posdefaultInfo_0 = value;
				}
			}

			[XmlElement(ElementName = "Checks")]
			public Checks Checks
			{
				[CompilerGenerated]
				get
				{
					return checks_0;
				}
				[CompilerGenerated]
				set
				{
					checks_0 = value;
				}
			}

			public POSResponse()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		[XmlRoot(ElementName = "Ident")]
		public class Ident
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[XmlAttribute(AttributeName = "id")]
			public string Id
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute(AttributeName = "ttype")]
			public string Ttype
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			public Ident()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		[XmlRoot(ElementName = "POSDefaultInfo")]
		public class POSDefaultInfo
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string string_2;

			[CompilerGenerated]
			private string string_3;

			[CompilerGenerated]
			private string string_4;

			[CompilerGenerated]
			private string string_5;

			[XmlAttribute(AttributeName = "server")]
			public string Server
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute(AttributeName = "table")]
			public string Table
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			[XmlAttribute(AttributeName = "check")]
			public string Check
			{
				[CompilerGenerated]
				get
				{
					return string_2;
				}
				[CompilerGenerated]
				set
				{
					string_2 = value;
				}
			}

			[XmlAttribute(AttributeName = "track2")]
			public string Track2
			{
				[CompilerGenerated]
				get
				{
					return string_3;
				}
				[CompilerGenerated]
				set
				{
					string_3 = value;
				}
			}

			[XmlAttribute(AttributeName = "res")]
			public string Res
			{
				[CompilerGenerated]
				get
				{
					return string_4;
				}
				[CompilerGenerated]
				set
				{
					string_4 = value;
				}
			}

			[XmlAttribute(AttributeName = "rtext")]
			public string Rtext
			{
				[CompilerGenerated]
				get
				{
					return string_5;
				}
				[CompilerGenerated]
				set
				{
					string_5 = value;
				}
			}

			public POSDefaultInfo()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		[XmlRoot(ElementName = "Check")]
		public class Check
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string string_2;

			[CompilerGenerated]
			private string string_3;

			[CompilerGenerated]
			private string string_4;

			[CompilerGenerated]
			private string string_5;

			[XmlAttribute(AttributeName = "tableno")]
			public string Tableno
			{
				[CompilerGenerated]
				get
				{
					return string_0;
				}
				[CompilerGenerated]
				set
				{
					string_0 = value;
				}
			}

			[XmlAttribute(AttributeName = "tablename")]
			public string Tablename
			{
				[CompilerGenerated]
				get
				{
					return string_1;
				}
				[CompilerGenerated]
				set
				{
					string_1 = value;
				}
			}

			[XmlAttribute(AttributeName = "chkname")]
			public string Chkname
			{
				[CompilerGenerated]
				get
				{
					return string_2;
				}
				[CompilerGenerated]
				set
				{
					string_2 = value;
				}
			}

			[XmlAttribute(AttributeName = "chkno")]
			public string Chkno
			{
				[CompilerGenerated]
				get
				{
					return string_3;
				}
				[CompilerGenerated]
				set
				{
					string_3 = value;
				}
			}

			[XmlAttribute(AttributeName = "amt")]
			public string Amt
			{
				[CompilerGenerated]
				get
				{
					return string_4;
				}
				[CompilerGenerated]
				set
				{
					string_4 = value;
				}
			}

			[XmlAttribute(AttributeName = "tax")]
			public string Tax
			{
				[CompilerGenerated]
				get
				{
					return string_5;
				}
				[CompilerGenerated]
				set
				{
					string_5 = value;
				}
			}

			public Check()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		[XmlRoot(ElementName = "Checks")]
		public class Checks
		{
			[CompilerGenerated]
			private List<Check> list_0;

			[XmlElement(ElementName = "Check")]
			public List<Check> Check
			{
				[CompilerGenerated]
				get
				{
					return list_0;
				}
				[CompilerGenerated]
				set
				{
					list_0 = value;
				}
			}

			public Checks()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}

		public Response()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public PATT_Posera()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
