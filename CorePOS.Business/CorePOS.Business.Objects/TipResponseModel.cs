using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class TipResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private string string_1;

	public string Tip
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

	public TipResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
