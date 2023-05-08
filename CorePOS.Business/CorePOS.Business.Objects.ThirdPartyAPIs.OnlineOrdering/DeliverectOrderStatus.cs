using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public class DeliverectOrderStatus
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string bhendeesbk;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_1;

	public string orderId
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

	public int status
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

	public string reason
	{
		[CompilerGenerated]
		get
		{
			return bhendeesbk;
		}
		[CompilerGenerated]
		set
		{
			bhendeesbk = value;
		}
	}

	public DateTime timeStamp
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

	public string receiptId
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

	public DeliverectOrderStatus()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
