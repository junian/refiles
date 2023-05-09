using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class GroupsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<Group> list_0;

	public List<Group> groups
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

	public GroupsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
