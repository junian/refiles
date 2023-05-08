using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.InAppAPI;

public class OptionsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<OptionObject> list_0;

	public List<OptionObject> options
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

	public OptionsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
