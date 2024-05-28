using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class CardTransactionFeeObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private char char_0;

	[CompilerGenerated]
	private decimal decimal_0;

	public string CardType
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

	public char TenderType
	{
		[CompilerGenerated]
		get
		{
			return char_0;
		}
		[CompilerGenerated]
		set
		{
			char_0 = value;
		}
	}

	public decimal Amount
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

	public CardTransactionFeeObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
