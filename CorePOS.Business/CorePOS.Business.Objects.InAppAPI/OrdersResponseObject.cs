using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class OrdersResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<Order> list_0;

	public List<Order> orders
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

	public OrdersResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
