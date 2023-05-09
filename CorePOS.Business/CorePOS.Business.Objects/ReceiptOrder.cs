using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects;

public class ReceiptOrder : Order
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private decimal decimal_0;

	public string QtyString
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

	public decimal OrderDiscountWithoutOnSale
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

	public ReceiptOrder()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
