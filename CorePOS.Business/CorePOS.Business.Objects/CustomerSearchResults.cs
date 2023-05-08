using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects;

public class CustomerSearchResults : Customer
{
	[CompilerGenerated]
	private int int_0;

	public int total_matches
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public CustomerSearchResults()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
