using System.Data.Linq.Mapping;

namespace CorePOS.Data;

public class usp_ClosingTotalsResult
{
	private string _Name;

	private int? _Qty;

	private decimal? _Total;

	[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string Name
	{
		get
		{
			return _Name;
		}
		set
		{
			if (_Name != value)
			{
				_Name = value;
			}
		}
	}

	[Column(Storage = "_Qty", DbType = "Int")]
	public int? Qty
	{
		get
		{
			return _Qty;
		}
		set
		{
			if (_Qty != value)
			{
				_Qty = value;
			}
		}
	}

	[Column(Storage = "_Total", DbType = "Decimal(38,2)")]
	public decimal? Total
	{
		get
		{
			return _Total;
		}
		set
		{
			if (!(_Total == value))
			{
				_Total = value;
			}
		}
	}

	public usp_ClosingTotalsResult()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
	}
}
