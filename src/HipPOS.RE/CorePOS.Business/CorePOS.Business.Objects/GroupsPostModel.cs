using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class GroupsPostModel
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<GroupsPostDataModel> list_0;

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

	public List<GroupsPostDataModel> ListOfGroups
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

	public GroupsPostModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
