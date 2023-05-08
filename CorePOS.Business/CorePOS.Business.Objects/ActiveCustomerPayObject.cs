using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ActiveCustomerPayObject : ActiveCustomer
{
	[CompilerGenerated]
	private string string_1;

	public string CustomerName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public ActiveCustomerPayObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
