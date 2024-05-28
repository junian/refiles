using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class OptionObject : usp_ItemOptionsResult
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private short short_0;

	public new string GroupName
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

	public short TabSortOrder
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public OptionObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
