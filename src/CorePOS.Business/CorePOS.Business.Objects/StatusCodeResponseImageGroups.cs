using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseImageGroups : StatusCodeResponse
{
	[CompilerGenerated]
	private List<ImageGroupsPostModel> list_0;

	public List<ImageGroupsPostModel> GroupImagesResponseList
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

	public StatusCodeResponseImageGroups()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
