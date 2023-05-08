using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class SupplierResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<SupplierPostDataModel> list_0;

	public List<SupplierPostDataModel> SupplierList
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

	public SupplierResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
