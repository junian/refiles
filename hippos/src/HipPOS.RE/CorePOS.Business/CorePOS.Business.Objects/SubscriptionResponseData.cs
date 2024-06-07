using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class SubscriptionResponseData : StatusCodeResponse
{
	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private List<Guid> list_0;

	public Guid prodkey_subscription_id
	{
		[CompilerGenerated]
		get
		{
			return guid_0;
		}
		[CompilerGenerated]
		set
		{
			guid_0 = value;
		}
	}

	public List<Guid> subscription_ids
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

	public SubscriptionResponseData()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
