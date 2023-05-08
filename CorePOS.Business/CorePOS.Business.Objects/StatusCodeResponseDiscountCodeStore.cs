using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseDiscountCodeStore : StatusCodeResponse
{
	[CompilerGenerated]
	private List<DiscountCodeDataModelStore> list_0;

	public List<DiscountCodeDataModelStore> DicountCodeList
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

	public StatusCodeResponseDiscountCodeStore()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
