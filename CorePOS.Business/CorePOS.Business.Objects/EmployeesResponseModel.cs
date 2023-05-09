using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class EmployeesResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<EmployeesPostModel> list_0;

	public List<EmployeesPostModel> employeeList
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

	public EmployeesResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
