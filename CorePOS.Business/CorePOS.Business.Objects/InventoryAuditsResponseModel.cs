using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class InventoryAuditsResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<InventoryAuditsPostDataModel> list_0;

	[CompilerGenerated]
	private int int_1;

	public List<InventoryAuditsPostDataModel> inventoryAuditList
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

	public int itemIdNotSynced
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public InventoryAuditsResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
