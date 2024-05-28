using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TaxResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<TaxPostDataModel> list_0;

	public List<TaxPostDataModel> taxResponseList
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

	public TaxResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
