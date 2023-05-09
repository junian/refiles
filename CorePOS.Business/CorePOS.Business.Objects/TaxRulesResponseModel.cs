using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TaxRulesResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<TaxRulePostDataModel> list_0;

	public List<TaxRulePostDataModel> taxRulesResponseList
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

	public TaxRulesResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
