using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class MemberIdResponse
{
	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private int int_0;

	public Guid CloudsyncGuid
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

	public long CloudsyncId
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

	public int AppId
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

	public MemberIdResponse()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
