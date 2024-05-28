using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class ReasonsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<Reason> list_0;

	public List<Reason> reasons
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

	public ReasonsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
