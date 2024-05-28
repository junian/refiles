using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class StatusCodeResponseLocation : StatusCodeResponse
{
	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public string LocationID
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

	public string AccountID
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

	public StatusCodeResponseLocation()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
