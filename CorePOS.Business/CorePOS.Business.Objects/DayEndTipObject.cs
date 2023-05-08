using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class DayEndTipObject
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private decimal decimal_1;

	[CompilerGenerated]
	private decimal decimal_2;

	[CompilerGenerated]
	private List<StationTipObject> list_0;

	[CompilerGenerated]
	private decimal decimal_3;

	[CompilerGenerated]
	private decimal decimal_4;

	public string Name
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

	public int TotalOrders
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

	public decimal TotalSales
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public decimal TotalTip
	{
		[CompilerGenerated]
		get
		{
			return decimal_1;
		}
		[CompilerGenerated]
		set
		{
			decimal_1 = value;
		}
	}

	public decimal TotalStationTips
	{
		[CompilerGenerated]
		get
		{
			return decimal_2;
		}
		[CompilerGenerated]
		set
		{
			decimal_2 = value;
		}
	}

	public List<StationTipObject> StationTips
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

	public decimal NetTip
	{
		[CompilerGenerated]
		get
		{
			return decimal_3;
		}
		[CompilerGenerated]
		set
		{
			decimal_3 = value;
		}
	}

	public decimal RefundedTip
	{
		[CompilerGenerated]
		get
		{
			return decimal_4;
		}
		[CompilerGenerated]
		set
		{
			decimal_4 = value;
		}
	}

	public DayEndTipObject()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
