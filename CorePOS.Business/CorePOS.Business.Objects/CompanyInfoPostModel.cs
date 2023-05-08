using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects;

public class CompanyInfoPostModel
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private CompanySetup companySetup_0;

	[CompilerGenerated]
	private List<BusinessHoursPostDataModel> list_0;

	public string token
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public CompanySetup Company
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

	public CompanyInfoPostModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
