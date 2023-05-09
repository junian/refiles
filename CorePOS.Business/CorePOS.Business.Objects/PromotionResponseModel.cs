using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class PromotionResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<PromotionPostDataModel> list_0;

	public List<PromotionPostDataModel> PromotionList
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

	public PromotionResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
