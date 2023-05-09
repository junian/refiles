using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.InAppAPI;

public class GetTablesResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<OrderTotal> list_0;

	public List<OrderTotal> ordertotals
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

	public GetTablesResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
