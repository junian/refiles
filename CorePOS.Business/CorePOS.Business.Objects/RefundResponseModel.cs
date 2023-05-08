using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class RefundResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<RefundPostDataModel> list_0;

	public List<RefundPostDataModel> refundList
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

	public RefundResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
