using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Employees")]
public class Employee : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _EmployeeID;

	private string _EmployeeName;

	private string _Address;

	private string _Phone1;

	private string _Phone2;

	private string _SIN;

	private string _FirstName;

	private string _LastName;

	private bool _isActive;

	private bool _Synced;

	private EntitySet<Refund> _Refunds;

	private EntitySet<User> _Users;

	private EntitySet<Appointment> _Appointments;

	private EntitySet<EmployeeClockInOutQueue> _EmployeeClockInOutQueues;

	private EntitySet<Promotion> _Promotions;

	private EntitySet<Promotion> _Promotions1;

	private EntitySet<Customer> _Customers;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_EmployeeID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
				SendPropertyChanging();
				_EmployeeID = value;
				SendPropertyChanged("EmployeeID");
			}
		}
	}

	[Column(Storage = "_EmployeeName", DbType = "NVarChar(100)")]
	public string EmployeeName
	{
		get
		{
			return _EmployeeName;
		}
		set
		{
			if (_EmployeeName != value)
			{
				SendPropertyChanging();
				_EmployeeName = value;
				SendPropertyChanged("EmployeeName");
			}
		}
	}

	[Column(Storage = "_Address", DbType = "NVarChar(255)")]
	public string Address
	{
		get
		{
			return _Address;
		}
		set
		{
			if (_Address != value)
			{
				SendPropertyChanging();
				_Address = value;
				SendPropertyChanged("Address");
			}
		}
	}

	[Column(Storage = "_Phone1", DbType = "NVarChar(20)")]
	public string Phone1
	{
		get
		{
			return _Phone1;
		}
		set
		{
			if (_Phone1 != value)
			{
				SendPropertyChanging();
				_Phone1 = value;
				SendPropertyChanged("Phone1");
			}
		}
	}

	[Column(Storage = "_Phone2", DbType = "NVarChar(20)")]
	public string Phone2
	{
		get
		{
			return _Phone2;
		}
		set
		{
			if (_Phone2 != value)
			{
				SendPropertyChanging();
				_Phone2 = value;
				SendPropertyChanged("Phone2");
			}
		}
	}

	[Column(Storage = "_SIN", DbType = "NVarChar(20)")]
	public string SIN
	{
		get
		{
			return _SIN;
		}
		set
		{
			if (_SIN != value)
			{
				SendPropertyChanging();
				_SIN = value;
				SendPropertyChanged("SIN");
			}
		}
	}

	[Column(Storage = "_FirstName", DbType = "NVarChar(100)")]
	public string FirstName
	{
		get
		{
			return _FirstName;
		}
		set
		{
			if (_FirstName != value)
			{
				SendPropertyChanging();
				_FirstName = value;
				SendPropertyChanged("FirstName");
			}
		}
	}

	[Column(Storage = "_LastName", DbType = "NVarChar(100)")]
	public string LastName
	{
		get
		{
			return _LastName;
		}
		set
		{
			if (_LastName != value)
			{
				SendPropertyChanging();
				_LastName = value;
				SendPropertyChanged("LastName");
			}
		}
	}

	[Column(Storage = "_isActive", DbType = "Bit NOT NULL")]
	public bool isActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			if (_isActive != value)
			{
				SendPropertyChanging();
				_isActive = value;
				SendPropertyChanged("isActive");
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

	[Association(Name = "Employee_Refund", Storage = "_Refunds", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
	public EntitySet<Refund> Refunds
	{
		get
		{
			return _Refunds;
		}
		set
		{
			_Refunds.Assign(value);
		}
	}

	[Association(Name = "Employee_User", Storage = "_Users", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
	public EntitySet<User> Users
	{
		get
		{
			return _Users;
		}
		set
		{
			_Users.Assign(value);
		}
	}

	[Association(Name = "Employee_Appointment", Storage = "_Appointments", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
	public EntitySet<Appointment> Appointments
	{
		get
		{
			return _Appointments;
		}
		set
		{
			_Appointments.Assign(value);
		}
	}

	[Association(Name = "Employee_EmployeeClockInOutQueue", Storage = "_EmployeeClockInOutQueues", ThisKey = "EmployeeID", OtherKey = "EmployeeId")]
	public EntitySet<EmployeeClockInOutQueue> EmployeeClockInOutQueues
	{
		get
		{
			return _EmployeeClockInOutQueues;
		}
		set
		{
			_EmployeeClockInOutQueues.Assign(value);
		}
	}

	[Association(Name = "Employee_Promotion", Storage = "_Promotions", ThisKey = "EmployeeID", OtherKey = "UserCreated")]
	public EntitySet<Promotion> Promotions
	{
		get
		{
			return _Promotions;
		}
		set
		{
			_Promotions.Assign(value);
		}
	}

	[Association(Name = "Employee_Promotion1", Storage = "_Promotions1", ThisKey = "EmployeeID", OtherKey = "UserModified")]
	public EntitySet<Promotion> Promotions1
	{
		get
		{
			return _Promotions1;
		}
		set
		{
			_Promotions1.Assign(value);
		}
	}

	[Association(Name = "Employee_Customer", Storage = "_Customers", ThisKey = "EmployeeID", OtherKey = "EmployeeID")]
	public EntitySet<Customer> Customers
	{
		get
		{
			return _Customers;
		}
		set
		{
			_Customers.Assign(value);
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

	public Employee()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Refunds = new EntitySet<Refund>(method_0, method_1);
		_Users = new EntitySet<User>(method_2, method_3);
		_Appointments = new EntitySet<Appointment>(method_4, method_5);
		_EmployeeClockInOutQueues = new EntitySet<EmployeeClockInOutQueue>(method_6, method_7);
		_Promotions = new EntitySet<Promotion>(method_8, method_9);
		_Promotions1 = new EntitySet<Promotion>(method_10, method_11);
		_Customers = new EntitySet<Customer>(method_12, method_13);
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

	private void method_0(Refund refund_0)
	{
		SendPropertyChanging();
		refund_0.Employee = this;
	}

	private void method_1(Refund refund_0)
	{
		SendPropertyChanging();
		refund_0.Employee = null;
	}

	private void method_2(User user_0)
	{
		SendPropertyChanging();
		user_0.Employee = this;
	}

	private void method_3(User user_0)
	{
		SendPropertyChanging();
		user_0.Employee = null;
	}

	private void method_4(Appointment appointment_0)
	{
		SendPropertyChanging();
		appointment_0.Employee = this;
	}

	private void method_5(Appointment appointment_0)
	{
		SendPropertyChanging();
		appointment_0.Employee = null;
	}

	private void method_6(EmployeeClockInOutQueue employeeClockInOutQueue_0)
	{
		SendPropertyChanging();
		employeeClockInOutQueue_0.Employee = this;
	}

	private void method_7(EmployeeClockInOutQueue employeeClockInOutQueue_0)
	{
		SendPropertyChanging();
		employeeClockInOutQueue_0.Employee = null;
	}

	private void method_8(Promotion promotion_0)
	{
		SendPropertyChanging();
		promotion_0.Employee = this;
	}

	private void method_9(Promotion promotion_0)
	{
		SendPropertyChanging();
		promotion_0.Employee = null;
	}

	private void method_10(Promotion promotion_0)
	{
		SendPropertyChanging();
		promotion_0.Employee1 = this;
	}

	private void method_11(Promotion promotion_0)
	{
		SendPropertyChanging();
		promotion_0.Employee1 = null;
	}

	private void method_12(Customer customer_0)
	{
		SendPropertyChanging();
		customer_0.Employee = this;
	}

	private void method_13(Customer customer_0)
	{
		SendPropertyChanging();
		customer_0.Employee = null;
	}

	static Employee()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
