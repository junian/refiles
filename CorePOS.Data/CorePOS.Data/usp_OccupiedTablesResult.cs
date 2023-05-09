using System.Data.Linq.Mapping;

namespace CorePOS.Data;

public class usp_OccupiedTablesResult
{
	private string _TableName;

	private string _Customer;

	[Column(Storage = "_TableName", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
	public string TableName
	{
		get
		{
			return _TableName;
		}
		set
		{
			if (_TableName != value)
			{
				_TableName = value;
			}
		}
	}

	[Column(Storage = "_Customer", DbType = "NVarChar(50)")]
	public string Customer
	{
		get
		{
			return _Customer;
		}
		set
		{
			if (_Customer != value)
			{
				_Customer = value;
			}
		}
	}

	public usp_OccupiedTablesResult()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
	}
}
