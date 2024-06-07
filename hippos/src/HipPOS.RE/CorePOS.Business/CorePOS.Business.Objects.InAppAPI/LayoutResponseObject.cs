using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class LayoutResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<TableModel> list_0;

	[CompilerGenerated]
	private List<Layout> list_1;

	[CompilerGenerated]
	private string string_3;

	public List<TableModel> tables
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

	public List<Layout> layout_objects
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public string default_layout
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

	public LayoutResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
