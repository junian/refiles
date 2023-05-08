using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.DiscountCodes")]
public class DiscountCode : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private long _Id;

	private long _CloudsyncId;

	private string _Code;

	private string _Description;

	private decimal _DiscountAmount;

	private string _DiscountUOM;

	private DateTime _StartDate;

	private DateTime _EndDate;

	private bool _AvailableOnline;

	private bool _AvailableInStore;

	private bool _OneTimeUse;

	private int _DiscountCodeCount;

	private int _UsedCount;

	private bool _Synced;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public long Id
	{
		get
		{
			return _Id;
		}
		set
		{
			if (_Id != value)
			{
				SendPropertyChanging();
				_Id = value;
				SendPropertyChanged("Id");
			}
		}
	}

	[Column(Storage = "_CloudsyncId", DbType = "BigInt NOT NULL")]
	public long CloudsyncId
	{
		get
		{
			return _CloudsyncId;
		}
		set
		{
			if (_CloudsyncId != value)
			{
				SendPropertyChanging();
				_CloudsyncId = value;
				SendPropertyChanged("CloudsyncId");
			}
		}
	}

	[Column(Storage = "_Code", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string Code
	{
		get
		{
			return _Code;
		}
		set
		{
			if (_Code != value)
			{
				SendPropertyChanging();
				_Code = value;
				SendPropertyChanged("Code");
			}
		}
	}

	[Column(Storage = "_Description", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
	public string Description
	{
		get
		{
			return _Description;
		}
		set
		{
			if (_Description != value)
			{
				SendPropertyChanging();
				_Description = value;
				SendPropertyChanged("Description");
			}
		}
	}

	[Column(Storage = "_DiscountAmount", DbType = "Decimal(12,4) NOT NULL")]
	public decimal DiscountAmount
	{
		get
		{
			return _DiscountAmount;
		}
		set
		{
			if (_DiscountAmount != value)
			{
				SendPropertyChanging();
				_DiscountAmount = value;
				SendPropertyChanged("DiscountAmount");
			}
		}
	}

	[Column(Storage = "_DiscountUOM", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string String_0
	{
		get
		{
			return _DiscountUOM;
		}
		set
		{
			if (_DiscountUOM != value)
			{
				SendPropertyChanging();
				_DiscountUOM = value;
				SendPropertyChanged("DiscountUOM");
			}
		}
	}

	[Column(Storage = "_StartDate", DbType = "DateTime NOT NULL")]
	public DateTime StartDate
	{
		get
		{
			return _StartDate;
		}
		set
		{
			if (_StartDate != value)
			{
				SendPropertyChanging();
				_StartDate = value;
				SendPropertyChanged("StartDate");
			}
		}
	}

	[Column(Storage = "_EndDate", DbType = "DateTime NOT NULL")]
	public DateTime EndDate
	{
		get
		{
			return _EndDate;
		}
		set
		{
			if (_EndDate != value)
			{
				SendPropertyChanging();
				_EndDate = value;
				SendPropertyChanged("EndDate");
			}
		}
	}

	[Column(Storage = "_AvailableOnline", DbType = "Bit NOT NULL")]
	public bool AvailableOnline
	{
		get
		{
			return _AvailableOnline;
		}
		set
		{
			if (_AvailableOnline != value)
			{
				SendPropertyChanging();
				_AvailableOnline = value;
				SendPropertyChanged("AvailableOnline");
			}
		}
	}

	[Column(Storage = "_AvailableInStore", DbType = "Bit NOT NULL")]
	public bool AvailableInStore
	{
		get
		{
			return _AvailableInStore;
		}
		set
		{
			if (_AvailableInStore != value)
			{
				SendPropertyChanging();
				_AvailableInStore = value;
				SendPropertyChanged("AvailableInStore");
			}
		}
	}

	[Column(Storage = "_OneTimeUse", DbType = "Bit NOT NULL")]
	public bool OneTimeUse
	{
		get
		{
			return _OneTimeUse;
		}
		set
		{
			if (_OneTimeUse != value)
			{
				SendPropertyChanging();
				_OneTimeUse = value;
				SendPropertyChanged("OneTimeUse");
			}
		}
	}

	[Column(Storage = "_DiscountCodeCount", DbType = "Int NOT NULL")]
	public int DiscountCodeCount
	{
		get
		{
			return _DiscountCodeCount;
		}
		set
		{
			if (_DiscountCodeCount != value)
			{
				SendPropertyChanging();
				_DiscountCodeCount = value;
				SendPropertyChanged("DiscountCodeCount");
			}
		}
	}

	[Column(Storage = "_UsedCount", DbType = "Int NOT NULL")]
	public int UsedCount
	{
		get
		{
			return _UsedCount;
		}
		set
		{
			if (_UsedCount != value)
			{
				SendPropertyChanging();
				_UsedCount = value;
				SendPropertyChanged("UsedCount");
			}
		}
	}

	[Column(Storage = "_Synced", DbType = "Bit NOT NULL")]
	public bool Synced
	{
		get
		{
			return _Synced;
		}
		set
		{
			if (_Synced != value)
			{
				SendPropertyChanging();
				_Synced = value;
				SendPropertyChanged("Synced");
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

	public DiscountCode()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
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

	static DiscountCode()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
