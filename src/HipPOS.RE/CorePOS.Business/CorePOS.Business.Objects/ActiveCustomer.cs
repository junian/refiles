using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ActiveCustomer
{
	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private long long_1;

	public long deviceId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public string deviceName
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

	public long customerId
	{
		[CompilerGenerated]
		get
		{
			return long_1;
		}
		[CompilerGenerated]
		set
		{
			long_1 = value;
		}
	}

	public ActiveCustomer()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
