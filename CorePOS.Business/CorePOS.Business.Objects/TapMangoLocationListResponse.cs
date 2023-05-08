using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TapMangoLocationListResponse : TapMangoErrorResponse
{
	[CompilerGenerated]
	private List<TapMangoLocation> list_0;

	public List<TapMangoLocation> data
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

	public TapMangoLocationListResponse()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
