using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.InAppAPI;

public class APIProductKeyReponseObj : APIResponseObj
{
	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private string string_5;

	public string product_key
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

	public string install_token
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string install_id
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public APIProductKeyReponseObj()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
