using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class DeliveryFeeFromToPerKM
{
	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal decimal_1;

	[CompilerGenerated]
	private decimal decimal_2;

	public decimal FromDistance
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public decimal ToDistance
	{
		[CompilerGenerated]
		get
		{
			return decimal_1;
		}
		[CompilerGenerated]
		set
		{
			decimal_1 = value;
		}
	}

	public decimal ChargePerKM
	{
		[CompilerGenerated]
		get
		{
			return decimal_2;
		}
		[CompilerGenerated]
		set
		{
			decimal_2 = value;
		}
	}

	public DeliveryFeeFromToPerKM()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
