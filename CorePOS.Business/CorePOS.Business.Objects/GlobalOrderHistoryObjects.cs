using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class GlobalOrderHistoryObjects
{
	public class Request
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		public string token
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

		public string phone_number
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

		public Request()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public class Response
	{
		[CompilerGenerated]
		private CustomerInfo customerInfo_0;

		[CompilerGenerated]
		private List<Order> list_0;

		public CustomerInfo customer_info
		{
			[CompilerGenerated]
			get
			{
				return customerInfo_0;
			}
			[CompilerGenerated]
			set
			{
				customerInfo_0 = value;
			}
		}

		public List<Order> orders
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

		public Response()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public class CustomerInfo
	{
		[CompilerGenerated]
		private int int_0;

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
		private DateTime dateTime_0;

		public int customer_id
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

		public string customer_name
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

		public string customer_cell
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

		public string customer_home
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

		public string customer_email
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

		public string customer_address
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

		public DateTime last_modified
		{
			[CompilerGenerated]
			get
			{
				return dateTime_0;
			}
			[CompilerGenerated]
			set
			{
				dateTime_0 = value;
			}
		}

		public CustomerInfo()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public class Order
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
		private int int_0;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private decimal decimal_0;

		[CompilerGenerated]
		private string string_5;

		[CompilerGenerated]
		private byte byte_0;

		[CompilerGenerated]
		private string string_6;

		[CompilerGenerated]
		private short short_0;

		[CompilerGenerated]
		private string string_7;

		[CompilerGenerated]
		private string string_8;

		[CompilerGenerated]
		private DateTime dateTime_0;

		[CompilerGenerated]
		private DateTime dateTime_1;

		public string location_id
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

		public string order_number
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

		public string customer_phone
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

		public string item_barcode
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

		public int item_id
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

		public string item_name
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

		public decimal item_qty
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

		public string item_instruction
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

		public byte item_identifier
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}

		public string item_identifier_string
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

		public short combo_id
		{
			[CompilerGenerated]
			get
			{
				return short_0;
			}
			[CompilerGenerated]
			set
			{
				short_0 = value;
			}
		}

		public string option_tab
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

		public string option_group_name
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

		public DateTime date_paid
		{
			[CompilerGenerated]
			get
			{
				return dateTime_0;
			}
			[CompilerGenerated]
			set
			{
				dateTime_0 = value;
			}
		}

		public DateTime date_created
		{
			[CompilerGenerated]
			get
			{
				return dateTime_1;
			}
			[CompilerGenerated]
			set
			{
				dateTime_1 = value;
			}
		}

		public Order()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public GlobalOrderHistoryObjects()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
