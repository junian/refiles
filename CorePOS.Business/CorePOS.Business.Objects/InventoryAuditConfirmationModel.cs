using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class InventoryAuditConfirmationModel
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<long> list_0;

	public string token
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public List<long> CloudSyncIdList
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

	public InventoryAuditConfirmationModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
