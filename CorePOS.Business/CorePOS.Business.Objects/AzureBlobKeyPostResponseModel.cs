using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class AzureBlobKeyPostResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public string Key
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

	public string LocationId
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

	public AzureBlobKeyPostResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
