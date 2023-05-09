using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class RefundPostDataModel
{
	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private Guid guid_1;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal sedjsnLwdW;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private string string_3;

	public Guid RefundAppId
	{
		[CompilerGenerated]
		get
		{
			return guid_0;
		}
		[CompilerGenerated]
		set
		{
			guid_0 = value;
		}
	}

	public string RefundNumber
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

	public DateTime DateCreated
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public Guid OrderId
	{
		[CompilerGenerated]
		get
		{
			return guid_1;
		}
		[CompilerGenerated]
		set
		{
			guid_1 = value;
		}
	}

	public string UserCreated
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

	public decimal Qty
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

	public decimal AmountRefunded
	{
		[CompilerGenerated]
		get
		{
			return sedjsnLwdW;
		}
		[CompilerGenerated]
		set
		{
			sedjsnLwdW = value;
		}
	}

	public string PaymentMethod
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

	public string RefundReason
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public RefundPostDataModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
