using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ImageItemsResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<ImageItemsPostModel> list_0;

	public List<ImageItemsPostModel> itemImagesResponseList
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

	public ImageItemsResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
