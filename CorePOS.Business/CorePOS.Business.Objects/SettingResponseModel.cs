using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class SettingResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<SettingPostDataModel> list_0;

	public List<SettingPostDataModel> SettingList
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

	public SettingResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
