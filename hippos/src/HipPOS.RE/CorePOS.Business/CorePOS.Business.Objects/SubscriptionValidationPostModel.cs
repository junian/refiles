using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class SubscriptionValidationPostModel
{
	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private Guid guid_1;

	public Guid productkey
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

	public Guid subscription_id
	{
		[CompilerGenerated]
		get
		{
			return guid_1;
		}
		[CompilerGenerated]
		set
		{
			guid_1 = value;
		}
	}

	public SubscriptionValidationPostModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
