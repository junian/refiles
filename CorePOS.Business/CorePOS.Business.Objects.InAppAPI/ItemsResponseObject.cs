using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.InAppAPI;

public class ItemsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<ItemObject> list_0;

	public List<ItemObject> items
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

	public ItemsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
