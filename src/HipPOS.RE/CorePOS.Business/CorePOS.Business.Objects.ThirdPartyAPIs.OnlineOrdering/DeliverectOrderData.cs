using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public class DeliverectOrderData
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

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
	private int int_0;

	[CompilerGenerated]
	private List<DeliverectStatusHistory> list_0;

	[CompilerGenerated]
	private string string_6;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private string string_7;

	[CompilerGenerated]
	private DateTime dateTime_2;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private DeliverectCourier deliverectCourier_0;

	[CompilerGenerated]
	private DeliverectCustomer deliverectCustomer_0;

	[CompilerGenerated]
	private DeliverectDeliveryAddress deliverectDeliveryAddress_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private DeliverectPayment deliverectPayment_0;

	[CompilerGenerated]
	private string string_8;

	[CompilerGenerated]
	private List<DeliverectOrderItem> list_1;

	[CompilerGenerated]
	private List<DeliverectTaxes> MmcNestDdk;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private int int_4;

	[CompilerGenerated]
	private int int_5;

	[CompilerGenerated]
	private int int_6;

	[CompilerGenerated]
	private int int_7;

	[CompilerGenerated]
	private string string_9;

	[CompilerGenerated]
	private string string_10;

	[CompilerGenerated]
	private string string_11;

	[CompilerGenerated]
	private List<string> list_2;

	public string _id
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

	public DateTime _created
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

	public DateTime _updated
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

	public string channelOrderId
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

	public string channelOrderDisplayId
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

	public string posLocationId
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

	public string location
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

	public string channelLink
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

	public int status
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

	public List<DeliverectStatusHistory> statusHistory
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

	public string by
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

	public int orderType
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

	public int channel
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

	public string table
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

	public DateTime pickupTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_2;
		}
		[CompilerGenerated]
		set
		{
			dateTime_2 = value;
		}
	}

	public bool deliveryIsAsap
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

	public DeliverectCourier courier
	{
		[CompilerGenerated]
		get
		{
			return deliverectCourier_0;
		}
		[CompilerGenerated]
		set
		{
			deliverectCourier_0 = value;
		}
	}

	public DeliverectCustomer customer
	{
		[CompilerGenerated]
		get
		{
			return deliverectCustomer_0;
		}
		[CompilerGenerated]
		set
		{
			deliverectCustomer_0 = value;
		}
	}

	public DeliverectDeliveryAddress deliveryAddress
	{
		[CompilerGenerated]
		get
		{
			return deliverectDeliveryAddress_0;
		}
		[CompilerGenerated]
		set
		{
			deliverectDeliveryAddress_0 = value;
		}
	}

	public bool orderIsAlreadyPaid
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public DeliverectPayment payment
	{
		[CompilerGenerated]
		get
		{
			return deliverectPayment_0;
		}
		[CompilerGenerated]
		set
		{
			deliverectPayment_0 = value;
		}
	}

	public string note
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

	public List<DeliverectOrderItem> items
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public List<DeliverectTaxes> taxes
	{
		[CompilerGenerated]
		get
		{
			return MmcNestDdk;
		}
		[CompilerGenerated]
		set
		{
			MmcNestDdk = value;
		}
	}

	public int decimalDigits
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

	public int numberOfCustomers
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public int deliveryCost
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int serviceCharge
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int discountTotal
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public string posCustomerId
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

	public string account
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

	public string posReceiptId
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

	public List<string> tags
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public DeliverectOrderData()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
