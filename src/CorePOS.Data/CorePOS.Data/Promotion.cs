using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Promotions")]
public class Promotion : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _PromoId;

	private string _PromoName;

	private string _PromoCode;

	private bool _Active;

	private DateTime? _StartDate;

	private DateTime? _EndDate;

	private string _DayTimeOfWeek;

	private string _OrderTypes;

	private decimal? _BuyQty;

	private string _BuyItemIDs;

	private string _GetQtyString;

	private string _GetItemIDs;

	private decimal? _GetDiscountAmount;

	private string _GetDiscountUOM;

	private bool _Synced;

	private DateTime? _DateCreated;

	private DateTime? _DateModified;

	private int? _UserCreated;

	private int? _UserModified;

	private bool _IsDeleted;

	private EntityRef<Employee> _Employee;

	private EntityRef<Employee> _Employee1;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_PromoId", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int PromoId
	{
		get
		{
			return _PromoId;
		}
		set
		{
			if (_PromoId != value)
			{
				SendPropertyChanging();
				_PromoId = value;
				SendPropertyChanged("PromoId");
			}
		}
	}

	[Column(Storage = "_PromoName", DbType = "NVarChar(128)")]
	public string PromoName
	{
		get
		{
			return _PromoName;
		}
		set
		{
			if (_PromoName != value)
			{
				SendPropertyChanging();
				_PromoName = value;
				SendPropertyChanged("PromoName");
			}
		}
	}

	[Column(Storage = "_PromoCode", DbType = "NVarChar(128)")]
	public string PromoCode
	{
		get
		{
			return _PromoCode;
		}
		set
		{
			if (_PromoCode != value)
			{
				SendPropertyChanging();
				_PromoCode = value;
				SendPropertyChanged("PromoCode");
			}
		}
	}

	[Column(Storage = "_Active", DbType = "Bit NOT NULL")]
	public bool Active
	{
		get
		{
			return _Active;
		}
		set
		{
			if (_Active != value)
			{
				SendPropertyChanging();
				_Active = value;
				SendPropertyChanged("Active");
			}
		}
	}

	[Column(Storage = "_StartDate", DbType = "DateTime")]
	public DateTime? StartDate
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

	[Column(Storage = "_EndDate", DbType = "DateTime")]
	public DateTime? EndDate
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

	[Column(Storage = "_DayTimeOfWeek", DbType = "NVarChar(1024)")]
	public string DayTimeOfWeek
	{
		get
		{
			return _DayTimeOfWeek;
		}
		set
		{
			if (_DayTimeOfWeek != value)
			{
				SendPropertyChanging();
				_DayTimeOfWeek = value;
				SendPropertyChanged("DayTimeOfWeek");
			}
		}
	}

	[Column(Storage = "_OrderTypes", DbType = "NVarChar(512)")]
	public string OrderTypes
	{
		get
		{
			return _OrderTypes;
		}
		set
		{
			if (_OrderTypes != value)
			{
				SendPropertyChanging();
				_OrderTypes = value;
				SendPropertyChanged("OrderTypes");
			}
		}
	}

	[Column(Storage = "_BuyQty", DbType = "Decimal(12,2)")]
	public decimal? BuyQty
	{
		get
		{
			return _BuyQty;
		}
		set
		{
			if (!(_BuyQty == value))
			{
				SendPropertyChanging();
				_BuyQty = value;
				SendPropertyChanged("BuyQty");
			}
		}
	}

	[Column(Storage = "_BuyItemIDs", DbType = "NVarChar(1024)")]
	public string String_0
	{
		get
		{
			return _BuyItemIDs;
		}
		set
		{
			if (_BuyItemIDs != value)
			{
				SendPropertyChanging();
				_BuyItemIDs = value;
				SendPropertyChanged("BuyItemIDs");
			}
		}
	}

	[Column(Storage = "_GetQtyString", DbType = "NVarChar(5)")]
	public string GetQtyString
	{
		get
		{
			return _GetQtyString;
		}
		set
		{
			if (_GetQtyString != value)
			{
				SendPropertyChanging();
				_GetQtyString = value;
				SendPropertyChanged("GetQtyString");
			}
		}
	}

	[Column(Storage = "_GetItemIDs", DbType = "NVarChar(1024)")]
	public string String_1
	{
		get
		{
			return _GetItemIDs;
		}
		set
		{
			if (_GetItemIDs != value)
			{
				SendPropertyChanging();
				_GetItemIDs = value;
				SendPropertyChanged("GetItemIDs");
			}
		}
	}

	[Column(Storage = "_GetDiscountAmount", DbType = "Decimal(12,4)")]
	public decimal? GetDiscountAmount
	{
		get
		{
			return _GetDiscountAmount;
		}
		set
		{
			if (!(_GetDiscountAmount == value))
			{
				SendPropertyChanging();
				_GetDiscountAmount = value;
				SendPropertyChanged("GetDiscountAmount");
			}
		}
	}

	[Column(Storage = "_GetDiscountUOM", DbType = "NVarChar(1)")]
	public string GetDiscountUOM
	{
		get
		{
			return _GetDiscountUOM;
		}
		set
		{
			if (_GetDiscountUOM != value)
			{
				SendPropertyChanging();
				_GetDiscountUOM = value;
				SendPropertyChanged("GetDiscountUOM");
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

	[Column(Storage = "_DateCreated", DbType = "DateTime")]
	public DateTime? DateCreated
	{
		get
		{
			return _DateCreated;
		}
		set
		{
			if (_DateCreated != value)
			{
				SendPropertyChanging();
				_DateCreated = value;
				SendPropertyChanged("DateCreated");
			}
		}
	}

	[Column(Storage = "_DateModified", DbType = "DateTime")]
	public DateTime? DateModified
	{
		get
		{
			return _DateModified;
		}
		set
		{
			if (_DateModified != value)
			{
				SendPropertyChanging();
				_DateModified = value;
				SendPropertyChanged("DateModified");
			}
		}
	}

	[Column(Storage = "_UserCreated", DbType = "Int")]
	public int? UserCreated
	{
		get
		{
			return _UserCreated;
		}
		set
		{
			if (_UserCreated != value)
			{
				if (_Employee.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_UserCreated = value;
				SendPropertyChanged("UserCreated");
			}
		}
	}

	[Column(Storage = "_UserModified", DbType = "Int")]
	public int? UserModified
	{
		get
		{
			return _UserModified;
		}
		set
		{
			if (_UserModified != value)
			{
				if (_Employee1.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_UserModified = value;
				SendPropertyChanged("UserModified");
			}
		}
	}

	[Column(Storage = "_IsDeleted", DbType = "Bit NOT NULL")]
	public bool IsDeleted
	{
		get
		{
			return _IsDeleted;
		}
		set
		{
			if (_IsDeleted != value)
			{
				SendPropertyChanging();
				_IsDeleted = value;
				SendPropertyChanged("IsDeleted");
			}
		}
	}

	[Association(Name = "Employee_Promotion", Storage = "_Employee", ThisKey = "UserCreated", OtherKey = "EmployeeID", IsForeignKey = true)]
	public Employee Employee
	{
		get
		{
			return _Employee.Entity;
		}
		set
		{
			Employee entity = _Employee.Entity;
			if (entity != value || !_Employee.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Employee.Entity = null;
					entity.Promotions.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.Promotions.Add(this);
					_UserCreated = value.EmployeeID;
				}
				else
				{
					_UserCreated = null;
				}
				SendPropertyChanged("Employee");
			}
		}
	}

	[Association(Name = "Employee_Promotion1", Storage = "_Employee1", ThisKey = "UserModified", OtherKey = "EmployeeID", IsForeignKey = true)]
	public Employee Employee1
	{
		get
		{
			return _Employee1.Entity;
		}
		set
		{
			Employee entity = _Employee1.Entity;
			if (entity != value || !_Employee1.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Employee1.Entity = null;
					entity.Promotions1.Remove(this);
				}
				_Employee1.Entity = value;
				if (value != null)
				{
					value.Promotions1.Add(this);
					_UserModified = value.EmployeeID;
				}
				else
				{
					_UserModified = null;
				}
				SendPropertyChanged("Employee1");
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

	public Promotion()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Employee = default(EntityRef<Employee>);
		_Employee1 = default(EntityRef<Employee>);
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

	static Promotion()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
