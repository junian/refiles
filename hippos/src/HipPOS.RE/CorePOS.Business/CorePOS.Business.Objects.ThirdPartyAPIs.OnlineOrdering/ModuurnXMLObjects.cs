using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public class ModuurnXMLObjects
{
	[XmlRoot(ElementName = "client_address_parts")]
	public class Client_address_parts
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[XmlElement(ElementName = "street")]
		public string Street
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

		[XmlElement(ElementName = "city")]
		public string City
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

		public Client_address_parts()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[XmlRoot(ElementName = "sub-item")]
	public class Subitem
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

		[XmlElement(ElementName = "id")]
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

		[XmlElement(ElementName = "name")]
		public string Name
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

		[XmlElement(ElementName = "price")]
		public string Price
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

		[XmlElement(ElementName = "group_name")]
		public string Group_name
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

		[XmlElement(ElementName = "quantity")]
		public string Quantity
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

		[XmlElement(ElementName = "type_id")]
		public string Type_id
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

		[XmlElement(ElementName = "type")]
		public string Type
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

		[XmlElement(ElementName = "idCompound")]
		public string IdCompound
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

		public Subitem()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[XmlRoot(ElementName = "option")]
	public class Option
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
		private List<Subitem> list_0;

		[XmlElement(ElementName = "id")]
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

		[XmlElement(ElementName = "name")]
		public string Name
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

		[XmlElement(ElementName = "price")]
		public string Price
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

		[XmlElement(ElementName = "group_name")]
		public string Group_name
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

		[XmlElement(ElementName = "quantity")]
		public string Quantity
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

		[XmlElement(ElementName = "type_id")]
		public string Type_id
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

		[XmlElement(ElementName = "type")]
		public string Type
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

		[XmlElement(ElementName = "idCompound")]
		public string IdCompound
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

		[XmlElement(ElementName = "sub-item")]
		public List<Subitem> Subitems
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

		public Option()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[XmlRoot(ElementName = "item")]
	public class Item
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

		[CompilerGenerated]
		private string string_9;

		[CompilerGenerated]
		private string string_10;

		[CompilerGenerated]
		private string string_11;

		[CompilerGenerated]
		private string string_12;

		[CompilerGenerated]
		private string string_13;

		[CompilerGenerated]
		private string string_14;

		[CompilerGenerated]
		private List<Option> list_0;

		[XmlElement(ElementName = "id")]
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

		[XmlElement(ElementName = "name")]
		public string Name
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

		[XmlElement(ElementName = "total_item_price")]
		public string Total_item_price
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

		[XmlElement(ElementName = "price")]
		public string Price
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

		[XmlElement(ElementName = "quantity")]
		public string Quantity
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

		[XmlElement(ElementName = "instructions")]
		public string Instructions
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

		[XmlElement(ElementName = "type_id")]
		public string Type_id
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

		[XmlElement(ElementName = "type")]
		public string Type
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

		[XmlElement(ElementName = "tax_rate")]
		public string Tax_rate
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

		[XmlElement(ElementName = "tax_value")]
		public string Tax_value
		{
			[CompilerGenerated]
			get
			{
				return string_9;
			}
			[CompilerGenerated]
			set
			{
				string_9 = value;
			}
		}

		[XmlElement(ElementName = "parent_id")]
		public string Parent_id
		{
			[CompilerGenerated]
			get
			{
				return string_10;
			}
			[CompilerGenerated]
			set
			{
				string_10 = value;
			}
		}

		[XmlElement(ElementName = "cart_discount_rate")]
		public string Cart_discount_rate
		{
			[CompilerGenerated]
			get
			{
				return string_11;
			}
			[CompilerGenerated]
			set
			{
				string_11 = value;
			}
		}

		[XmlElement(ElementName = "cart_discount")]
		public string Cart_discount
		{
			[CompilerGenerated]
			get
			{
				return string_12;
			}
			[CompilerGenerated]
			set
			{
				string_12 = value;
			}
		}

		[XmlElement(ElementName = "item_discount")]
		public string Item_discount
		{
			[CompilerGenerated]
			get
			{
				return string_13;
			}
			[CompilerGenerated]
			set
			{
				string_13 = value;
			}
		}

		[XmlElement(ElementName = "idCompound")]
		public string IdCompound
		{
			[CompilerGenerated]
			get
			{
				return string_14;
			}
			[CompilerGenerated]
			set
			{
				string_14 = value;
			}
		}

		[XmlElement(ElementName = "option")]
		public List<Option> Options
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

	[XmlRoot(ElementName = "orders")]
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
		private string string_9;

		[CompilerGenerated]
		private string string_10;

		[CompilerGenerated]
		private string string_11;

		[CompilerGenerated]
		private string string_12;

		[CompilerGenerated]
		private string string_13;

		[CompilerGenerated]
		private string string_14;

		[CompilerGenerated]
		private string string_15;

		[CompilerGenerated]
		private string string_16;

		[CompilerGenerated]
		private string string_17;

		[CompilerGenerated]
		private string string_18;

		[CompilerGenerated]
		private string string_19;

		[CompilerGenerated]
		private string string_20;

		[CompilerGenerated]
		private string string_21;

		[CompilerGenerated]
		private string string_22;

		[CompilerGenerated]
		private string string_23;

		[CompilerGenerated]
		private string string_24;

		[CompilerGenerated]
		private string string_25;

		[CompilerGenerated]
		private string string_26;

		[CompilerGenerated]
		private string string_27;

		[CompilerGenerated]
		private string string_28;

		[CompilerGenerated]
		private string string_29;

		[CompilerGenerated]
		private string string_30;

		[CompilerGenerated]
		private string string_31;

		[CompilerGenerated]
		private string string_32;

		[CompilerGenerated]
		private string string_33;

		[CompilerGenerated]
		private string string_34;

		[CompilerGenerated]
		private string string_35;

		[CompilerGenerated]
		private string string_36;

		[CompilerGenerated]
		private string string_37;

		[CompilerGenerated]
		private Client_address_parts client_address_parts_0;

		[CompilerGenerated]
		private List<Item> list_0;

		[XmlElement(ElementName = "id")]
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

		[XmlElement(ElementName = "restaurant_id")]
		public string Restaurant_id
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

		[XmlElement(ElementName = "order_id")]
		public string Order_id
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

		[XmlElement(ElementName = "client_id")]
		public string Client_id
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

		[XmlElement(ElementName = "type")]
		public string Type
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

		[XmlElement(ElementName = "source")]
		public string Source
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

		[XmlElement(ElementName = "sub_total_price")]
		public string Sub_total_price
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

		[XmlElement(ElementName = "tax_value")]
		public string Tax_value
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

		[XmlElement(ElementName = "total_price")]
		public string Total_price
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

		[XmlElement(ElementName = "client_first_name")]
		public string Client_first_name
		{
			[CompilerGenerated]
			get
			{
				return string_9;
			}
			[CompilerGenerated]
			set
			{
				string_9 = value;
			}
		}

		[XmlElement(ElementName = "client_last_name")]
		public string Client_last_name
		{
			[CompilerGenerated]
			get
			{
				return string_10;
			}
			[CompilerGenerated]
			set
			{
				string_10 = value;
			}
		}

		[XmlElement(ElementName = "client_email")]
		public string Client_email
		{
			[CompilerGenerated]
			get
			{
				return string_11;
			}
			[CompilerGenerated]
			set
			{
				string_11 = value;
			}
		}

		[XmlElement(ElementName = "comment")]
		public string Comment
		{
			[CompilerGenerated]
			get
			{
				return string_12;
			}
			[CompilerGenerated]
			set
			{
				string_12 = value;
			}
		}

		[XmlElement(ElementName = "client_phone")]
		public string Client_phone
		{
			[CompilerGenerated]
			get
			{
				return string_13;
			}
			[CompilerGenerated]
			set
			{
				string_13 = value;
			}
		}

		[XmlElement(ElementName = "pin_skipped")]
		public string Pin_skipped
		{
			[CompilerGenerated]
			get
			{
				return string_14;
			}
			[CompilerGenerated]
			set
			{
				string_14 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_name")]
		public string Restaurant_name
		{
			[CompilerGenerated]
			get
			{
				return string_15;
			}
			[CompilerGenerated]
			set
			{
				string_15 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_phone")]
		public string Restaurant_phone
		{
			[CompilerGenerated]
			get
			{
				return string_16;
			}
			[CompilerGenerated]
			set
			{
				string_16 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_country")]
		public string Restaurant_country
		{
			[CompilerGenerated]
			get
			{
				return string_17;
			}
			[CompilerGenerated]
			set
			{
				string_17 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_state")]
		public string Restaurant_state
		{
			[CompilerGenerated]
			get
			{
				return string_18;
			}
			[CompilerGenerated]
			set
			{
				string_18 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_city")]
		public string Restaurant_city
		{
			[CompilerGenerated]
			get
			{
				return string_19;
			}
			[CompilerGenerated]
			set
			{
				string_19 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_street")]
		public string Restaurant_street
		{
			[CompilerGenerated]
			get
			{
				return string_20;
			}
			[CompilerGenerated]
			set
			{
				string_20 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_zipcode")]
		public string Restaurant_zipcode
		{
			[CompilerGenerated]
			get
			{
				return string_21;
			}
			[CompilerGenerated]
			set
			{
				string_21 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_latitude")]
		public string Restaurant_latitude
		{
			[CompilerGenerated]
			get
			{
				return string_22;
			}
			[CompilerGenerated]
			set
			{
				string_22 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_longitude")]
		public string Restaurant_longitude
		{
			[CompilerGenerated]
			get
			{
				return string_23;
			}
			[CompilerGenerated]
			set
			{
				string_23 = value;
			}
		}

		[XmlElement(ElementName = "instructions")]
		public string Instructions
		{
			[CompilerGenerated]
			get
			{
				return string_24;
			}
			[CompilerGenerated]
			set
			{
				string_24 = value;
			}
		}

		[XmlElement(ElementName = "currency")]
		public string Currency
		{
			[CompilerGenerated]
			get
			{
				return string_25;
			}
			[CompilerGenerated]
			set
			{
				string_25 = value;
			}
		}

		[XmlElement(ElementName = "latitude")]
		public string Latitude
		{
			[CompilerGenerated]
			get
			{
				return string_26;
			}
			[CompilerGenerated]
			set
			{
				string_26 = value;
			}
		}

		[XmlElement(ElementName = "longitude")]
		public string Longitude
		{
			[CompilerGenerated]
			get
			{
				return string_27;
			}
			[CompilerGenerated]
			set
			{
				string_27 = value;
			}
		}

		[XmlElement(ElementName = "tax_type")]
		public string Tax_type
		{
			[CompilerGenerated]
			get
			{
				return string_28;
			}
			[CompilerGenerated]
			set
			{
				string_28 = value;
			}
		}

		[XmlElement(ElementName = "fulfill_at")]
		public string Fulfill_at
		{
			[CompilerGenerated]
			get
			{
				return string_29;
			}
			[CompilerGenerated]
			set
			{
				string_29 = value;
			}
		}

		[XmlElement(ElementName = "pos_system_id")]
		public string Pos_system_id
		{
			[CompilerGenerated]
			get
			{
				return string_30;
			}
			[CompilerGenerated]
			set
			{
				string_30 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_key")]
		public string Restaurant_key
		{
			[CompilerGenerated]
			get
			{
				return string_31;
			}
			[CompilerGenerated]
			set
			{
				string_31 = value;
			}
		}

		[XmlElement(ElementName = "restaurant_token")]
		public string Restaurant_token
		{
			[CompilerGenerated]
			get
			{
				return string_32;
			}
			[CompilerGenerated]
			set
			{
				string_32 = value;
			}
		}

		[XmlElement(ElementName = "api_version")]
		public string Api_version
		{
			[CompilerGenerated]
			get
			{
				return string_33;
			}
			[CompilerGenerated]
			set
			{
				string_33 = value;
			}
		}

		[XmlElement(ElementName = "payment")]
		public string Payment
		{
			[CompilerGenerated]
			get
			{
				return string_34;
			}
			[CompilerGenerated]
			set
			{
				string_34 = value;
			}
		}

		[XmlElement(ElementName = "tip")]
		public string Tip
		{
			[CompilerGenerated]
			get
			{
				return string_35;
			}
			[CompilerGenerated]
			set
			{
				string_35 = value;
			}
		}

		[XmlElement(ElementName = "delivery_fee")]
		public string Delivery_fee
		{
			[CompilerGenerated]
			get
			{
				return string_36;
			}
			[CompilerGenerated]
			set
			{
				string_36 = value;
			}
		}

		[XmlElement(ElementName = "client_address")]
		public string Client_address
		{
			[CompilerGenerated]
			get
			{
				return string_37;
			}
			[CompilerGenerated]
			set
			{
				string_37 = value;
			}
		}

		[XmlElement(ElementName = "client_address_parts")]
		public Client_address_parts Client_address_parts
		{
			[CompilerGenerated]
			get
			{
				return client_address_parts_0;
			}
			[CompilerGenerated]
			set
			{
				client_address_parts_0 = value;
			}
		}

		[XmlElement(ElementName = "item")]
		public List<Item> Items
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

		public Order()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[XmlRoot(ElementName = "root")]
	public class Root
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private List<Order> list_0;

		[XmlElement(ElementName = "count")]
		public string Count
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

		[XmlElement(ElementName = "orders")]
		public List<Order> Orders
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

		public Root()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	public ModuurnXMLObjects()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
