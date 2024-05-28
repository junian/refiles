using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class AccessTokenRequestObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private Guid guid_1;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	public string pin
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

	public Guid companyId
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

	public Guid locationId
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

	public string device_uid
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

	public string device_mac
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

	public AccessTokenRequestObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
