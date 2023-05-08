using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ActiveCustomerListResponse : TapMangoErrorResponse
{
	[CompilerGenerated]
	private List<ActiveCustomer> list_0;

	public List<ActiveCustomer> data
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

	public ActiveCustomerListResponse()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
