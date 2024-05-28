using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS;

public class ChitPrintInfo
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Station station_0;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private List<string> list_0;

	[CompilerGenerated]
	private List<Guid> AbjLpadRpD;

	public string OrderNumber
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

	public string Message
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

	public int FontSize
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

	public Station station
	{
		[CompilerGenerated]
		get
		{
			return station_0;
		}
		[CompilerGenerated]
		set
		{
			station_0 = value;
		}
	}

	public string PrinterName
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

	public List<string> RelatedOrderNumbers
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

	public List<Guid> orderIds
	{
		[CompilerGenerated]
		get
		{
			return AbjLpadRpD;
		}
		[CompilerGenerated]
		set
		{
			AbjLpadRpD = value;
		}
	}

	public ChitPrintInfo()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
