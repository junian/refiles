using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class UOMResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<UOMPostDataModel> list_0;

	public List<UOMPostDataModel> PromotionList
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

	public UOMResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
