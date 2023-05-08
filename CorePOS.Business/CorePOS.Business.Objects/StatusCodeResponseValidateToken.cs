using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseValidateToken : StatusCodeResponse
{
	[CompilerGenerated]
	private List<SubscriptionPostData> list_0;

	public List<SubscriptionPostData> ListOfSubscriptions
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

	public StatusCodeResponseValidateToken()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
