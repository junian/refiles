using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Users")]
public class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _UserID;

	private int _EmployeeID;

	private short _RoleID;

	private string _PIN;

	private bool _Active;

	private Guid? _HipposTimeEmployeeID;

	private EntityRef<Role> _Role;

	private EntityRef<Employee> _Employee;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_UserID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int UserID
	{
		get
		{
			return _UserID;
		}
		set
		{
			if (_UserID != value)
			{
				SendPropertyChanging();
				_UserID = value;
				SendPropertyChanged("UserID");
			}
		}
	}

	[Column(Storage = "_EmployeeID", DbType = "Int NOT NULL")]
	public int EmployeeID
	{
		get
		{
			return _EmployeeID;
		}
		set
		{
			if (_EmployeeID != value)
			{
				if (_Employee.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_EmployeeID = value;
				SendPropertyChanged("EmployeeID");
			}
		}
	}

	[Column(Storage = "_RoleID", DbType = "SmallInt NOT NULL")]
	public short RoleID
	{
		get
		{
			return _RoleID;
		}
		set
		{
			if (_RoleID != value)
			{
				if (_Role.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_RoleID = value;
				SendPropertyChanged("RoleID");
			}
		}
	}

	[Column(Storage = "_PIN", DbType = "NVarChar(16) NOT NULL", CanBeNull = false)]
	public string PIN
	{
		get
		{
			return _PIN;
		}
		set
		{
			if (_PIN != value)
			{
				SendPropertyChanging();
				_PIN = value;
				SendPropertyChanged("PIN");
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

	[Column(Storage = "_HipposTimeEmployeeID", DbType = "UniqueIdentifier")]
	public Guid? HipposTimeEmployeeID
	{
		get
		{
			return _HipposTimeEmployeeID;
		}
		set
		{
			if (_HipposTimeEmployeeID != value)
			{
				SendPropertyChanging();
				_HipposTimeEmployeeID = value;
				SendPropertyChanged("HipposTimeEmployeeID");
			}
		}
	}

	[Association(Name = "Role_User", Storage = "_Role", ThisKey = "RoleID", OtherKey = "RoleID", IsForeignKey = true)]
	public Role Role
	{
		get
		{
			return _Role.Entity;
		}
		set
		{
			Role entity = _Role.Entity;
			if (entity != value || !_Role.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Role.Entity = null;
					entity.Users.Remove(this);
				}
				_Role.Entity = value;
				if (value != null)
				{
					value.Users.Add(this);
					_RoleID = value.RoleID;
				}
				else
				{
					_RoleID = 0;
				}
				SendPropertyChanged("Role");
			}
		}
	}

	[Association(Name = "Employee_User", Storage = "_Employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
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
					entity.Users.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.Users.Add(this);
					_EmployeeID = value.EmployeeID;
				}
				else
				{
					_EmployeeID = 0;
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

	public User()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Role = default(EntityRef<Role>);
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

	static User()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
