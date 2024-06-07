using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class OrderResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<OrderPostDataModel> list_0;

	public List<OrderPostDataModel> orderList
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

	public OrderResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
