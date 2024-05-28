using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StationTipObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal decimal_1;

	public string StatioName
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

	public decimal TipAmount
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

	public decimal TipPercentage
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

	public StationTipObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
