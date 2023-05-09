using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Business.Methods;

namespace CorePOS.Business.Objects.InAppAPI;

public class SettingsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<SettingsObject> list_0;

	public List<SettingsObject> ListOfSettings
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

	public SettingsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
