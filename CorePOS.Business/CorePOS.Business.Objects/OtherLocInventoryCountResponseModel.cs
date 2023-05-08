using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class OtherLocInventoryCountResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<OtherLocInventoryCount> list_0;

	public List<OtherLocInventoryCount> ListInventory
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

	public OtherLocInventoryCountResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
