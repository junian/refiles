using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseIdMembers : StatusCodeResponse
{
	[CompilerGenerated]
	private List<MemberIdResponse> list_0;

	public List<MemberIdResponse> CustomerIdList
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

	public StatusCodeResponseIdMembers()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
