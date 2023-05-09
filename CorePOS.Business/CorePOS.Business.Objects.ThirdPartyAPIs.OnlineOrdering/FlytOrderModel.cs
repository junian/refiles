using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public class FlytOrderModel
{
	public class Driver
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		public string first_name
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

		public string last_name
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

		public string phone_number
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

		public Driver()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Item
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private List<Item> list_0;

		public string name
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

		public string description
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

		public string plu
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

		public int price
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

		public List<Item> children
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

		public Item()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Channel
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private int int_0;

		public string name
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

		public int id
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

		public Channel()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class ItemsInCart
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		public int inc_tax
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

		public int tax
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

		public ItemsInCart()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Final
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		public int inc_tax
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

		public int tax
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

		public Final()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Price
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		public int inc_tax
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

		public int tax
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

		public Price()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Adjustment
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private Price price_0;

		public string name
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

		public Price price
		{
			[CompilerGenerated]
			get
			{
				return price_0;
			}
			[CompilerGenerated]
			set
			{
				price_0 = value;
			}
		}

		public Adjustment()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Payment
	{
		[CompilerGenerated]
		private ItemsInCart itemsInCart_0;

		[CompilerGenerated]
		private Final final_0;

		[CompilerGenerated]
		private List<Adjustment> list_0;

		public ItemsInCart items_in_cart
		{
			[CompilerGenerated]
			get
			{
				return itemsInCart_0;
			}
			[CompilerGenerated]
			set
			{
				itemsInCart_0 = value;
			}
		}

		public Final final
		{
			[CompilerGenerated]
			get
			{
				return final_0;
			}
			[CompilerGenerated]
			set
			{
				final_0 = value;
			}
		}

		public List<Adjustment> adjustments
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

		public Payment()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Coordinates
	{
		[CompilerGenerated]
		private double double_0;

		[CompilerGenerated]
		private double double_1;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		public double latitude
		{
			[CompilerGenerated]
			get
			{
				return double_0;
			}
			[CompilerGenerated]
			set
			{
				double_0 = value;
			}
		}

		public double longitude
		{
			[CompilerGenerated]
			get
			{
				return double_1;
			}
			[CompilerGenerated]
			set
			{
				double_1 = value;
			}
		}

		public string latitude_as_string
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

		public string longitude_as_string
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

		public Coordinates()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class Delivery
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
		private Coordinates coordinates_0;

		public string first_name
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

		public string last_name
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

		public string phone_number
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

		public string line_one
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

		public string line_two
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

		public string city
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

		public string postcode
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

		public string email
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

		public Coordinates coordinates
		{
			[CompilerGenerated]
			get
			{
				return coordinates_0;
			}
			[CompilerGenerated]
			set
			{
				coordinates_0 = value;
			}
		}

		public Delivery()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public class FlytOrder
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private Driver driver_0;

		[CompilerGenerated]
		private List<Item> list_0;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private Channel channel_0;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private string string_5;

		[CompilerGenerated]
		private string string_6;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_7;

		[CompilerGenerated]
		private string string_8;

		[CompilerGenerated]
		private Payment payment_0;

		[CompilerGenerated]
		private Delivery delivery_0;

		public string type
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

		public string posLocationId
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

		public Driver driver
		{
			[CompilerGenerated]
			get
			{
				return driver_0;
			}
			[CompilerGenerated]
			set
			{
				driver_0 = value;
			}
		}

		public List<Item> items
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

		public string created_at
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

		public Channel channel
		{
			[CompilerGenerated]
			get
			{
				return channel_0;
			}
			[CompilerGenerated]
			set
			{
				channel_0 = value;
			}
		}

		public string collect_at
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

		public string collection_notes
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

		public string kitchen_notes
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

		public string third_party_order_reference
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

		public int total
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

		public string payment_method
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

		public string tender_type
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

		public Delivery delivery
		{
			[CompilerGenerated]
			get
			{
				return delivery_0;
			}
			[CompilerGenerated]
			set
			{
				delivery_0 = value;
			}
		}

		public FlytOrder()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public FlytOrderModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
