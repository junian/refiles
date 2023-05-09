using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class OptionResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<OptionsDataModel> list_0;

	public List<OptionsDataModel> optionsList
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

	public OptionResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
