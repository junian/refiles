using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class SecondScreenImagesResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<LocationSecondScreenImagesPostDataModel> list_0;

	public List<LocationSecondScreenImagesPostDataModel> LocationImagesResponseList
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

	public SecondScreenImagesResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
