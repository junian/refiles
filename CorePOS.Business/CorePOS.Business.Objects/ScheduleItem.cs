using System;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class ScheduleItem
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private DateTime? nullable_0;

	public string Time
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

	public string Text
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

	public DateTime? ScheduleDateTime
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public ScheduleItem()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
