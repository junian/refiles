using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TapMangoCustomerResponse : TapMangoErrorResponse
{
	[CompilerGenerated]
	private TapMangoCustomerObject tapMangoCustomerObject_0;

	public TapMangoCustomerObject data
	{
		[CompilerGenerated]
		get
		{
			return tapMangoCustomerObject_0;
		}
		[CompilerGenerated]
		set
		{
			tapMangoCustomerObject_0 = value;
		}
	}

	public TapMangoCustomerResponse()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
