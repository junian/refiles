using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseMembers : StatusCodeResponse
{
	[CompilerGenerated]
	private List<CustomersPostDataModel> list_0;

	public List<CustomersPostDataModel> CustomerList
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

	public StatusCodeResponseMembers()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
