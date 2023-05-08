using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects;

public class PrintToStationOrderObject : Order
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<Guid> list_0;

	public new string ItemCourse
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

	public List<Guid> OrderIdSharedList
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public PrintToStationOrderObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
