using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class InventoryBatchResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<InventoryBatchPostDataModel> list_0;

	public List<InventoryBatchPostDataModel> BatchList
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

	public InventoryBatchResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
