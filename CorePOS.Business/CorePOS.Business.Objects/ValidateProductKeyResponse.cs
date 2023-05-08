using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ValidateProductKeyResponse : StatusCodeResponse
{
	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public string install_token
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

	public string install_id
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

	public ValidateProductKeyResponse()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
