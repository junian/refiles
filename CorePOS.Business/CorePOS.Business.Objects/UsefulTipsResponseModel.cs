using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class UsefulTipsResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<UsefulTipsResponseDataModel> RcyAeFbjaI;

	public List<UsefulTipsResponseDataModel> UsefulTips
	{
		[CompilerGenerated]
		get
		{
			return RcyAeFbjaI;
		}
		[CompilerGenerated]
		set
		{
			RcyAeFbjaI = value;
		}
	}

	public UsefulTipsResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
