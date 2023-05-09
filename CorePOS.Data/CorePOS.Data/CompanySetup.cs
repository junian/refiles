using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.CompanySetup")]
public class CompanySetup : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _CompanyID;

	private string _Name;

	private string _Address1;

	private string _City;

	private string _StateProv;

	private string _Country;

	private string _ZIP;

	private string _Phone;

	private string _Fax;

	private string _TAXAccount;

	private string _BusinessName;

	private string _LatestClosingTime;

	private string _LatestOpeningTime;

	private int _Capacity;

	private bool _isSynced;

	private DateTime? _LastDateSettlement;

	private bool _isOpen;

	private decimal _OpeningBalance;

	private decimal _ClosingBalance;

	private string _Long;

	private string _Lat;

	private bool _hasUnconfirmedOnlineOrder;

	private string _TimeZoneName;

	private int _TimeZoneOffset;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_CompanyID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int CompanyID
	{
		get
		{
			return _CompanyID;
		}
		set
		{
			if (_CompanyID != value)
			{
				SendPropertyChanging();
				_CompanyID = value;
				SendPropertyChanged("CompanyID");
			}
		}
	}

	[Column(Storage = "_Name", DbType = "NVarChar(50)")]
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
				SendPropertyChanging();
				_Name = value;
				SendPropertyChanged("Name");
			}
		}
	}

	[Column(Storage = "_Address1", DbType = "NVarChar(255)")]
	public string Address1
	{
		get
		{
			return _Address1;
		}
		set
		{
			if (_Address1 != value)
			{
				SendPropertyChanging();
				_Address1 = value;
				SendPropertyChanged("Address1");
			}
		}
	}

	[Column(Storage = "_City", DbType = "NVarChar(50)")]
	public string City
	{
		get
		{
			return _City;
		}
		set
		{
			if (_City != value)
			{
				SendPropertyChanging();
				_City = value;
				SendPropertyChanged("City");
			}
		}
	}

	[Column(Storage = "_StateProv", DbType = "NVarChar(50)")]
	public string StateProv
	{
		get
		{
			return _StateProv;
		}
		set
		{
			if (_StateProv != value)
			{
				SendPropertyChanging();
				_StateProv = value;
				SendPropertyChanged("StateProv");
			}
		}
	}

	[Column(Storage = "_Country", DbType = "NVarChar(50)")]
	public string Country
	{
		get
		{
			return _Country;
		}
		set
		{
			if (_Country != value)
			{
				SendPropertyChanging();
				_Country = value;
				SendPropertyChanged("Country");
			}
		}
	}

	[Column(Storage = "_ZIP", DbType = "NVarChar(20)")]
	public string ZIP
	{
		get
		{
			return _ZIP;
		}
		set
		{
			if (_ZIP != value)
			{
				SendPropertyChanging();
				_ZIP = value;
				SendPropertyChanged("ZIP");
			}
		}
	}

	[Column(Storage = "_Phone", DbType = "NVarChar(15)")]
	public string Phone
	{
		get
		{
			return _Phone;
		}
		set
		{
			if (_Phone != value)
			{
				SendPropertyChanging();
				_Phone = value;
				SendPropertyChanged("Phone");
			}
		}
	}

	[Column(Storage = "_Fax", DbType = "NVarChar(15)")]
	public string Fax
	{
		get
		{
			return _Fax;
		}
		set
		{
			if (_Fax != value)
			{
				SendPropertyChanging();
				_Fax = value;
				SendPropertyChanged("Fax");
			}
		}
	}

	[Column(Storage = "_TAXAccount", DbType = "NVarChar(20)")]
	public string String_0
	{
		get
		{
			return _TAXAccount;
		}
		set
		{
			if (_TAXAccount != value)
			{
				SendPropertyChanging();
				_TAXAccount = value;
				SendPropertyChanged("TAXAccount");
			}
		}
	}

	[Column(Storage = "_BusinessName", DbType = "NVarChar(255)")]
	public string BusinessName
	{
		get
		{
			return _BusinessName;
		}
		set
		{
			if (_BusinessName != value)
			{
				SendPropertyChanging();
				_BusinessName = value;
				SendPropertyChanged("BusinessName");
			}
		}
	}

	[Column(Storage = "_LatestClosingTime", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string LatestClosingTime
	{
		get
		{
			return _LatestClosingTime;
		}
		set
		{
			if (_LatestClosingTime != value)
			{
				SendPropertyChanging();
				_LatestClosingTime = value;
				SendPropertyChanged("LatestClosingTime");
			}
		}
	}

	[Column(Storage = "_LatestOpeningTime", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string LatestOpeningTime
	{
		get
		{
			return _LatestOpeningTime;
		}
		set
		{
			if (_LatestOpeningTime != value)
			{
				SendPropertyChanging();
				_LatestOpeningTime = value;
				SendPropertyChanged("LatestOpeningTime");
			}
		}
	}

	[Column(Storage = "_Capacity", DbType = "Int NOT NULL")]
	public int Capacity
	{
		get
		{
			return _Capacity;
		}
		set
		{
			if (_Capacity != value)
			{
				SendPropertyChanging();
				_Capacity = value;
				SendPropertyChanged("Capacity");
			}
		}
	}

	[Column(Storage = "_isSynced", DbType = "Bit NOT NULL")]
	public bool isSynced
	{
		get
		{
			return _isSynced;
		}
		set
		{
			if (_isSynced != value)
			{
				SendPropertyChanging();
				_isSynced = value;
				SendPropertyChanged("isSynced");
			}
		}
	}

	[Column(Storage = "_LastDateSettlement", DbType = "DateTime")]
	public DateTime? LastDateSettlement
	{
		get
		{
			return _LastDateSettlement;
		}
		set
		{
			if (_LastDateSettlement != value)
			{
				SendPropertyChanging();
				_LastDateSettlement = value;
				SendPropertyChanged("LastDateSettlement");
			}
		}
	}

	[Column(Storage = "_isOpen", DbType = "Bit NOT NULL")]
	public bool isOpen
	{
		get
		{
			return _isOpen;
		}
		set
		{
			if (_isOpen != value)
			{
				SendPropertyChanging();
				_isOpen = value;
				SendPropertyChanged("isOpen");
			}
		}
	}

	[Column(Storage = "_OpeningBalance", DbType = "Decimal(16,2) NOT NULL")]
	public decimal OpeningBalance
	{
		get
		{
			return _OpeningBalance;
		}
		set
		{
			if (_OpeningBalance != value)
			{
				SendPropertyChanging();
				_OpeningBalance = value;
				SendPropertyChanged("OpeningBalance");
			}
		}
	}

	[Column(Storage = "_ClosingBalance", DbType = "Decimal(16,2) NOT NULL")]
	public decimal ClosingBalance
	{
		get
		{
			return _ClosingBalance;
		}
		set
		{
			if (_ClosingBalance != value)
			{
				SendPropertyChanging();
				_ClosingBalance = value;
				SendPropertyChanged("ClosingBalance");
			}
		}
	}

	[Column(Storage = "_Long", DbType = "NVarChar(30)")]
	public string Long
	{
		get
		{
			return _Long;
		}
		set
		{
			if (_Long != value)
			{
				SendPropertyChanging();
				_Long = value;
				SendPropertyChanged("Long");
			}
		}
	}

	[Column(Storage = "_Lat", DbType = "NVarChar(30)")]
	public string Lat
	{
		get
		{
			return _Lat;
		}
		set
		{
			if (_Lat != value)
			{
				SendPropertyChanging();
				_Lat = value;
				SendPropertyChanged("Lat");
			}
		}
	}

	[Column(Storage = "_hasUnconfirmedOnlineOrder", DbType = "Bit NOT NULL")]
	public bool hasUnconfirmedOnlineOrder
	{
		get
		{
			return _hasUnconfirmedOnlineOrder;
		}
		set
		{
			if (_hasUnconfirmedOnlineOrder != value)
			{
				SendPropertyChanging();
				_hasUnconfirmedOnlineOrder = value;
				SendPropertyChanged("hasUnconfirmedOnlineOrder");
			}
		}
	}

	[Column(Storage = "_TimeZoneName", DbType = "NVarChar(100)")]
	public string TimeZoneName
	{
		get
		{
			return _TimeZoneName;
		}
		set
		{
			if (_TimeZoneName != value)
			{
				SendPropertyChanging();
				_TimeZoneName = value;
				SendPropertyChanged("TimeZoneName");
			}
		}
	}

	[Column(Storage = "_TimeZoneOffset", DbType = "Int NOT NULL")]
	public int TimeZoneOffset
	{
		get
		{
			return _TimeZoneOffset;
		}
		set
		{
			if (_TimeZoneOffset != value)
			{
				SendPropertyChanging();
				_TimeZoneOffset = value;
				SendPropertyChanged("TimeZoneOffset");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging
	{
		[CompilerGenerated]
		add
		{
			PropertyChangingEventHandler propertyChangingEventHandler = propertyChangingEventHandler_0;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref propertyChangingEventHandler_0, value2, propertyChangingEventHandler2);
			}
			while ((object)propertyChangingEventHandler != propertyChangingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangingEventHandler propertyChangingEventHandler = propertyChangingEventHandler_0;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref propertyChangingEventHandler_0, value2, propertyChangingEventHandler2);
			}
			while ((object)propertyChangingEventHandler != propertyChangingEventHandler2);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CompanySetup()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
	}

	protected virtual void SendPropertyChanging()
	{
		if (propertyChangingEventHandler_0 != null)
		{
			propertyChangingEventHandler_0(this, propertyChangingEventArgs_0);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static CompanySetup()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
