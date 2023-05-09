using System.Collections.Generic;
using System.Runtime.CompilerServices;
using com.clover.remotepay.sdk;
using CorePOS.Business.Objects.PaymentObjects;

namespace CorePOS.Business.Objects.InAppAPI;

public class APIRequestObj
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string kOtnlVcuyk;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private APIRequestSetTableObj apirequestSetTableObj_0;

	[CompilerGenerated]
	private List<OrderedItem> list_0;

	[CompilerGenerated]
	private APIAuthPin apiauthPin_0;

	[CompilerGenerated]
	private APIProductKey apiproductKey_0;

	[CompilerGenerated]
	private ControlAccess controlAccess_0;

	[CompilerGenerated]
	private PaymentResponse paymentResponse_0;

	[CompilerGenerated]
	private PoyntTransactionObject poyntTransactionObject_0;

	public string call_type
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

	public string call_param
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

	public string call_param2
	{
		[CompilerGenerated]
		get
		{
			return kOtnlVcuyk;
		}
		[CompilerGenerated]
		set
		{
			kOtnlVcuyk = value;
		}
	}

	public string api_token
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

	public APIRequestSetTableObj orderHeader
	{
		[CompilerGenerated]
		get
		{
			return apirequestSetTableObj_0;
		}
		[CompilerGenerated]
		set
		{
			apirequestSetTableObj_0 = value;
		}
	}

	public List<OrderedItem> order_items
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

	public APIAuthPin AuthPin
	{
		[CompilerGenerated]
		get
		{
			return apiauthPin_0;
		}
		[CompilerGenerated]
		set
		{
			apiauthPin_0 = value;
		}
	}

	public APIProductKey pk_object
	{
		[CompilerGenerated]
		get
		{
			return apiproductKey_0;
		}
		[CompilerGenerated]
		set
		{
			apiproductKey_0 = value;
		}
	}

	public ControlAccess control_access
	{
		[CompilerGenerated]
		get
		{
			return controlAccess_0;
		}
		[CompilerGenerated]
		set
		{
			controlAccess_0 = value;
		}
	}

	public PaymentResponse clover_response
	{
		[CompilerGenerated]
		get
		{
			return paymentResponse_0;
		}
		[CompilerGenerated]
		set
		{
			paymentResponse_0 = value;
		}
	}

	public PoyntTransactionObject poynt_response
	{
		[CompilerGenerated]
		get
		{
			return poyntTransactionObject_0;
		}
		[CompilerGenerated]
		set
		{
			poyntTransactionObject_0 = value;
		}
	}

	public APIRequestObj()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
