using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ItemResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<ItemsPostDataModel> list_0;

	public List<ItemsPostDataModel> itemResponseList
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

	public ItemResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
