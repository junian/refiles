using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.EmployeeClockInOutQueues")]
public class EmployeeClockInOutQueue : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _EmployeePin;

	private string _Timestamp;

	private string _Action;

	private bool _Synced;

	private int? _EmployeeId;

	private EntityRef<Employee> _Employee;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int Id
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

	[Column(Storage = "_EmployeePin", DbType = "NVarChar(128)")]
	public string EmployeePin
	{
		get
		{
			return _EmployeePin;
		}
		set
		{
			if (_EmployeePin != value)
			{
				SendPropertyChanging();
				_EmployeePin = value;
				SendPropertyChanged("EmployeePin");
			}
		}
	}

	[Column(Storage = "_Timestamp", DbType = "NVarChar(128)")]
	public string Timestamp
	{
		get
		{
			return _Timestamp;
		}
		set
		{
			if (_Timestamp != value)
			{
				SendPropertyChanging();
				_Timestamp = value;
				SendPropertyChanged("Timestamp");
			}
		}
	}

	[Column(Storage = "_Action", DbType = "NVarChar(128)")]
	public string Action
	{
		get
		{
			return _Action;
		}
		set
		{
			if (_Action != value)
			{
				SendPropertyChanging();
				_Action = value;
				SendPropertyChanged("Action");
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

	[Column(Storage = "_EmployeeId", DbType = "Int")]
	public int? EmployeeId
	{
		get
		{
			return _EmployeeId;
		}
		set
		{
			if (_EmployeeId != value)
			{
				if (_Employee.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_EmployeeId = value;
				SendPropertyChanged("EmployeeId");
			}
		}
	}

	[Association(Name = "Employee_EmployeeClockInOutQueue", Storage = "_Employee", ThisKey = "EmployeeId", OtherKey = "EmployeeID", IsForeignKey = true)]
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
					entity.EmployeeClockInOutQueues.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.EmployeeClockInOutQueues.Add(this);
					_EmployeeId = value.EmployeeID;
				}
				else
				{
					_EmployeeId = null;
				}
				SendPropertyChanged("Employee");
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

	public EmployeeClockInOutQueue()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Employee = default(EntityRef<Employee>);
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

	static EmployeeClockInOutQueue()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
