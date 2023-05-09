using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseOnlineOrderQueues : StatusCodeResponse
{
	[CompilerGenerated]
	private List<OnlineOrderQueuePostDataModel> list_0;

	public List<OnlineOrderQueuePostDataModel> queueList
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

	public StatusCodeResponseOnlineOrderQueues()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
