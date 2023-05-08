using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects;

public class CompanyResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private CompanySetup companySetup_0;

	[CompilerGenerated]
	private List<BusinessHoursPostDataModel> list_0;

	public CompanySetup companyResponse
	{
		[CompilerGenerated]
		get
		{
			return companySetup_0;
		}
		[CompilerGenerated]
		set
		{
			companySetup_0 = value;
		}
	}

	public List<BusinessHoursPostDataModel> ListOfBusinessHours
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

	public CompanyResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
