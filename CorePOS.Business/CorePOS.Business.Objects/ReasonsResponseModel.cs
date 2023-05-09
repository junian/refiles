using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ReasonsResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<ReasonsDataModel> list_0;

	public List<ReasonsDataModel> reasonsList
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

	public ReasonsResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
