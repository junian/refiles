using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.PaymentObjects;

public static class MonerisCoreObjects
{
	public static class RequestObjects
	{
		public class Order
		{
			[CompilerGenerated]
			private string xmVwreEfIy;

			[CompilerGenerated]
			private int int_0;

			[CompilerGenerated]
			private int int_1;

			[CompilerGenerated]
			private int int_2;

			[CompilerGenerated]
			private int int_3;

			public string orderId
			{
				[CompilerGenerated]
				get
				{
					return xmVwreEfIy;
				}
				[CompilerGenerated]
				set
				{
					xmVwreEfIy = value;
				}
			}

			public int totalAmount
			{
				[CompilerGenerated]
				get
				{
					return int_0;
				}
				[CompilerGenerated]
				set
				{
					int_0 = value;
				}
			}

			public int preTaxAmount
			{
				[CompilerGenerated]
				get
				{
					return int_1;
				}
				[CompilerGenerated]
				set
				{
					int_1 = value;
				}
			}

			public int gratuity
			{
				[CompilerGenerated]
				get
				{
					return int_2;
				}
				[CompilerGenerated]
				set
				{
					int_2 = value;
				}
			}

			public int remainingAmount
			{
				[CompilerGenerated]
				get
				{
					return int_3;
				}
				[CompilerGenerated]
				set
				{
					int_3 = value;
				}
			}

			public Order()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}

		public class Data
		{
			[CompilerGenerated]
			private Order RhdwzmvtuK;

			public Order order
			{
				[CompilerGenerated]
				get
				{
					return RhdwzmvtuK;
				}
				[CompilerGenerated]
				set
				{
					RhdwzmvtuK = value;
				}
			}

			public Data()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}

		public class Request
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private string xfeQtgeUuj;

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

			[CompilerGenerated]
			private Data data_0;

			public string ecrId
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

			public string merchantId
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

			public string configCode
			{
				[CompilerGenerated]
				get
				{
					return xfeQtgeUuj;
				}
				[CompilerGenerated]
				set
				{
					xfeQtgeUuj = value;
				}
			}

			public string terminalId
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

			public string apiVersion
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

			public string requestId
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

			public string idempotencyKey
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

			public string transactionId
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

			public string requestTimestamp
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

			public string action
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

			public Data data
			{
				[CompilerGenerated]
				get
				{
					return data_0;
				}
				[CompilerGenerated]
				set
				{
					data_0 = value;
				}
			}

			public Request()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}
	}

	public static class ResponseObjects
	{
		public class InitialResponse
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
			private bool bool_0;

			public string requestId
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

			public string transactionId
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

			public string responseTimestamp
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

			public string status
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

			public string statusDesc
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

			public bool completed
			{
				[CompilerGenerated]
				get
				{
					return bool_0;
				}
				[CompilerGenerated]
				set
				{
					bool_0 = value;
				}
			}

			public InitialResponse()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}

		public class ErrorResponse
		{
			public class ErrorDetail
			{
				[CompilerGenerated]
				private int int_0;

				[CompilerGenerated]
				private string string_0;

				[CompilerGenerated]
				private string string_1;

				[CompilerGenerated]
				private string string_2;

				public int errorCode
				{
					[CompilerGenerated]
					get
					{
						return int_0;
					}
					[CompilerGenerated]
					set
					{
						int_0 = value;
					}
				}

				public string parameter
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

				public string value
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

				public string issue
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

				public ErrorDetail()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

			public class Data
			{
				[CompilerGenerated]
				private List<ErrorDetail> list_0;

				public List<ErrorDetail> errorDetails
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

				public Data()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

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
				private bool bool_0;

				[CompilerGenerated]
				private Data data_0;

				public string requestId
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

				public string transactionId
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

				public string responseTimestamp
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

				public string status
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

				public string statusDesc
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

				public bool completed
				{
					[CompilerGenerated]
					get
					{
						return bool_0;
					}
					[CompilerGenerated]
					set
					{
						bool_0 = value;
					}
				}

				public Data data
				{
					[CompilerGenerated]
					get
					{
						return data_0;
					}
					[CompilerGenerated]
					set
					{
						data_0 = value;
					}
				}

				public Response()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

			public ErrorResponse()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}

		public class StatusResponse
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
			private bool bool_0;

			public string requestId
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

			public string idempotencyKey
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

			public string transactionId
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

			public string responseTimestamp
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

			public string status
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

			public string statusDesc
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

			public bool completed
			{
				[CompilerGenerated]
				get
				{
					return bool_0;
				}
				[CompilerGenerated]
				set
				{
					bool_0 = value;
				}
			}

			public StatusResponse()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}

		public class FinalResponse
		{
			public class Card
			{
				[CompilerGenerated]
				private string string_0;

				[CompilerGenerated]
				private string string_1;

				[CompilerGenerated]
				private string string_2;

				[CompilerGenerated]
				private string string_3;

				public string cardType
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

				public string authNumber
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

				public string referenceNumber
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

				public string lastDigits
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

				public Card()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

			public class Payment
			{
				[CompilerGenerated]
				private string string_0;

				[CompilerGenerated]
				private Card card_0;

				[CompilerGenerated]
				private int int_0;

				[CompilerGenerated]
				private int int_1;

				public string tenderType
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

				public Card card
				{
					[CompilerGenerated]
					get
					{
						return card_0;
					}
					[CompilerGenerated]
					set
					{
						card_0 = value;
					}
				}

				public int approvedAmount
				{
					[CompilerGenerated]
					get
					{
						return int_0;
					}
					[CompilerGenerated]
					set
					{
						int_0 = value;
					}
				}

				public int tipAmount
				{
					[CompilerGenerated]
					get
					{
						return int_1;
					}
					[CompilerGenerated]
					set
					{
						int_1 = value;
					}
				}

				public Payment()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

			public class Data
			{
				[CompilerGenerated]
				private Payment payment_0;

				public Payment payment
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

				public Data()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

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
				private bool bool_0;

				[CompilerGenerated]
				private Data data_0;

				public string requestId
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

				public string responseTimestamp
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

				public string transactionId
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

				public string status
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

				public string statusDesc
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

				public bool completed
				{
					[CompilerGenerated]
					get
					{
						return bool_0;
					}
					[CompilerGenerated]
					set
					{
						bool_0 = value;
					}
				}

				public Data data
				{
					[CompilerGenerated]
					get
					{
						return data_0;
					}
					[CompilerGenerated]
					set
					{
						data_0 = value;
					}
				}

				public Response()
				{
					Class2.oOsq41PzvTVMr();
					base._002Ector();
				}
			}

			public FinalResponse()
			{
				Class2.oOsq41PzvTVMr();
				base._002Ector();
			}
		}
	}
}
