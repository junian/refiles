using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ItemsWithOptionResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<ItemsWithOptionDataModel> list_0;

	public List<ItemsWithOptionDataModel> itemsWithOptionList
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

	public ItemsWithOptionResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
