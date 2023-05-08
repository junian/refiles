using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class CheckInventoryCountResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<CheckInventoryCountItemModel> list_0;

	public List<CheckInventoryCountItemModel> Items
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

	public CheckInventoryCountResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
