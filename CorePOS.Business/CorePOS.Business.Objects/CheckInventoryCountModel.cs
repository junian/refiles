using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class CheckInventoryCountModel
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<CheckInventoryCountItemModel> list_0;

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

	public CheckInventoryCountModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
