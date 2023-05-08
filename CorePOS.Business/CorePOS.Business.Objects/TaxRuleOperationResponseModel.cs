using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TaxRuleOperationResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<TaxRuleOperationPostDataModel> list_0;

	public List<TaxRuleOperationPostDataModel> taxRuleOperationResponseList
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

	public TaxRuleOperationResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
