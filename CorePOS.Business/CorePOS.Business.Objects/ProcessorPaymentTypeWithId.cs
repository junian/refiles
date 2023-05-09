using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ProcessorPaymentTypeWithId
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private DateTime? nullable_0;

	[CompilerGenerated]
	private decimal decimal_1;

	public string PaymentTypeName
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

	public string Id
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

	public string CardNumber
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public bool PaymentReceived
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public DateTime? DatePaid
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public decimal TipAmount
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

	public ProcessorPaymentTypeWithId()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
