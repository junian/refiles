using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace CorePOS.Business.Objects.PaymentObjects;

public static class SPInObjects
{
	public static class RequestObj
	{
		[XmlRoot(ElementName = "request")]
		public class Request
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

			[CompilerGenerated]
			private string string_6;

			[CompilerGenerated]
			private string string_7;

			[XmlElement(ElementName = "AuthKey")]
			public string AuthKey
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

			[XmlElement(ElementName = "RegisterId")]
			public string RegisterId
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

			[XmlElement(ElementName = "InvNum")]
			public string InvNum
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

			[XmlElement(ElementName = "TransType")]
			public string TransType
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

			[XmlElement(ElementName = "Amount")]
			public string Amount
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

			[XmlElement(ElementName = "Tip")]
			public string Tip
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

			[XmlElement(ElementName = "RefId")]
			public string RefId
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

			[XmlElement(ElementName = "AcntLast4")]
			public string AcntLast4
			{
				[CompilerGenerated]
				get
				{
					return string_7;
				}
				[CompilerGenerated]
				set
				{
					string_7 = value;
				}
			}

			public Request()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}
	}

	public static class ResponseObj
	{
		[XmlRoot(ElementName = "response")]
		public class Response
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

			[CompilerGenerated]
			private string string_6;

			[CompilerGenerated]
			private string string_7;

			[CompilerGenerated]
			private string string_8;

			[XmlElement(ElementName = "RefId")]
			public string RefId
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

			[XmlElement(ElementName = "RegisterId")]
			public string RegisterId
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

			[XmlElement(ElementName = "InvNum")]
			public string InvNum
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

			[XmlElement(ElementName = "ResultCode")]
			public string ResultCode
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

			[XmlElement(ElementName = "Message")]
			public string Message
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

			[XmlElement(ElementName = "AuthCode")]
			public string AuthCode
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

			[XmlElement(ElementName = "PNRef")]
			public string PNRef
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

			[XmlElement(ElementName = "PaymentType")]
			public string PaymentType
			{
				[CompilerGenerated]
				get
				{
					return string_7;
				}
				[CompilerGenerated]
				set
				{
					string_7 = value;
				}
			}

			[XmlElement(ElementName = "ExtData")]
			public string ExtData
			{
				[CompilerGenerated]
				get
				{
					return string_8;
				}
				[CompilerGenerated]
				set
				{
					string_8 = value;
				}
			}

			public Response()
			{
				Class2.oOsq41PzvTVMr();
				// base._002Ector();
			}
		}
	}
}
