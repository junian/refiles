using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StationResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<StationPostDataModel> list_0;

	public List<StationPostDataModel> StationList
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

	public StationResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
