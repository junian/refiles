using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class CustomFieldResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<CustomFieldPostDataModel> jZskffGdya;

	public List<CustomFieldPostDataModel> CustomFieldList
	{
		[CompilerGenerated]
		get
		{
			return jZskffGdya;
		}
		[CompilerGenerated]
		set
		{
			jZskffGdya = value;
		}
	}

	public CustomFieldResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
