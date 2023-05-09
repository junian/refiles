using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class OrderSums : OrderResult
{
	[CompilerGenerated]
	private string string_11;

	[CompilerGenerated]
	private decimal decimal_1;

	[CompilerGenerated]
	private decimal decimal_2;

	[CompilerGenerated]
	private decimal decimal_3;

	public string firstOrderID
	{
		[CompilerGenerated]
		get
		{
			return string_11;
		}
		[CompilerGenerated]
		set
		{
			string_11 = value;
		}
	}

	public decimal Discounts
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

	public decimal Taxes
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

	public decimal Total
	{
		[CompilerGenerated]
		get
		{
			return decimal_3;
		}
		[CompilerGenerated]
		set
		{
			decimal_3 = value;
		}
	}

	public OrderSums()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
