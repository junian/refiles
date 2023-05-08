using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Appointments")]
public class Appointment : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _AppointmentID;

	private int _EmployeeID;

	private string _CustomerName;

	private string _CustomerCell;

	private string _CustomerHome;

	private string _CustomerEmail;

	private string _Comments;

	private DateTime _StartDateTime;

	private DateTime _EndDateTime;

	private DateTime _DateCreated;

	private bool _SMSSent;

	private bool _EmailSent;

	private bool _isCancelled;

	private bool _isNoShow;

	private int _NumOfPeople;

	private DateTime _NextNotifyDateTime;

	private bool _ReminderDismissed;

	private bool _Synced;

	private long _CloudsyncReservationID;

	private string _AppointmentType;

	private bool _IsCleared;

	private DateTime? _DateUpdated;

	private int? _CustomerID;

	private EntitySet<Layout> _Layouts;

	private EntityRef<Customer> _Customer;

	private EntityRef<Employee> _Employee;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_AppointmentID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int AppointmentID
	{
		get
		{
			return _AppointmentID;
		}
		set
		{
			if (_AppointmentID != value)
			{
				SendPropertyChanging();
				_AppointmentID = value;
				SendPropertyChanged("AppointmentID");
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

	[Column(Storage = "_CustomerName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string CustomerName
	{
		get
		{
			return _CustomerName;
		}
		set
		{
			if (_CustomerName != value)
			{
				SendPropertyChanging();
				_CustomerName = value;
				SendPropertyChanged("CustomerName");
			}
		}
	}

	[Column(Storage = "_CustomerCell", DbType = "NVarChar(10)")]
	public string CustomerCell
	{
		get
		{
			return _CustomerCell;
		}
		set
		{
			if (_CustomerCell != value)
			{
				SendPropertyChanging();
				_CustomerCell = value;
				SendPropertyChanged("CustomerCell");
			}
		}
	}

	[Column(Storage = "_CustomerHome", DbType = "NVarChar(10)")]
	public string CustomerHome
	{
		get
		{
			return _CustomerHome;
		}
		set
		{
			if (_CustomerHome != value)
			{
				SendPropertyChanging();
				_CustomerHome = value;
				SendPropertyChanged("CustomerHome");
			}
		}
	}

	[Column(Storage = "_CustomerEmail", DbType = "NVarChar(MAX)")]
	public string CustomerEmail
	{
		get
		{
			return _CustomerEmail;
		}
		set
		{
			if (_CustomerEmail != value)
			{
				SendPropertyChanging();
				_CustomerEmail = value;
				SendPropertyChanged("CustomerEmail");
			}
		}
	}

	[Column(Storage = "_Comments", DbType = "NVarChar(MAX)")]
	public string Comments
	{
		get
		{
			return _Comments;
		}
		set
		{
			if (_Comments != value)
			{
				SendPropertyChanging();
				_Comments = value;
				SendPropertyChanged("Comments");
			}
		}
	}

	[Column(Storage = "_StartDateTime", DbType = "DateTime NOT NULL")]
	public DateTime StartDateTime
	{
		get
		{
			return _StartDateTime;
		}
		set
		{
			if (_StartDateTime != value)
			{
				SendPropertyChanging();
				_StartDateTime = value;
				SendPropertyChanged("StartDateTime");
			}
		}
	}

	[Column(Storage = "_EndDateTime", DbType = "DateTime NOT NULL")]
	public DateTime EndDateTime
	{
		get
		{
			return _EndDateTime;
		}
		set
		{
			if (_EndDateTime != value)
			{
				SendPropertyChanging();
				_EndDateTime = value;
				SendPropertyChanged("EndDateTime");
			}
		}
	}

	[Column(Storage = "_DateCreated", DbType = "DateTime NOT NULL")]
	public DateTime DateCreated
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

	[Column(Storage = "_SMSSent", DbType = "Bit NOT NULL")]
	public bool SMSSent
	{
		get
		{
			return _SMSSent;
		}
		set
		{
			if (_SMSSent != value)
			{
				SendPropertyChanging();
				_SMSSent = value;
				SendPropertyChanged("SMSSent");
			}
		}
	}

	[Column(Storage = "_EmailSent", DbType = "Bit NOT NULL")]
	public bool EmailSent
	{
		get
		{
			return _EmailSent;
		}
		set
		{
			if (_EmailSent != value)
			{
				SendPropertyChanging();
				_EmailSent = value;
				SendPropertyChanged("EmailSent");
			}
		}
	}

	[Column(Storage = "_isCancelled", DbType = "Bit NOT NULL")]
	public bool isCancelled
	{
		get
		{
			return _isCancelled;
		}
		set
		{
			if (_isCancelled != value)
			{
				SendPropertyChanging();
				_isCancelled = value;
				SendPropertyChanged("isCancelled");
			}
		}
	}

	[Column(Storage = "_isNoShow", DbType = "Bit NOT NULL")]
	public bool isNoShow
	{
		get
		{
			return _isNoShow;
		}
		set
		{
			if (_isNoShow != value)
			{
				SendPropertyChanging();
				_isNoShow = value;
				SendPropertyChanged("isNoShow");
			}
		}
	}

	[Column(Storage = "_NumOfPeople", DbType = "Int NOT NULL")]
	public int NumOfPeople
	{
		get
		{
			return _NumOfPeople;
		}
		set
		{
			if (_NumOfPeople != value)
			{
				SendPropertyChanging();
				_NumOfPeople = value;
				SendPropertyChanged("NumOfPeople");
			}
		}
	}

	[Column(Storage = "_NextNotifyDateTime", DbType = "DateTime NOT NULL")]
	public DateTime NextNotifyDateTime
	{
		get
		{
			return _NextNotifyDateTime;
		}
		set
		{
			if (_NextNotifyDateTime != value)
			{
				SendPropertyChanging();
				_NextNotifyDateTime = value;
				SendPropertyChanged("NextNotifyDateTime");
			}
		}
	}

	[Column(Storage = "_ReminderDismissed", DbType = "Bit NOT NULL")]
	public bool ReminderDismissed
	{
		get
		{
			return _ReminderDismissed;
		}
		set
		{
			if (_ReminderDismissed != value)
			{
				SendPropertyChanging();
				_ReminderDismissed = value;
				SendPropertyChanged("ReminderDismissed");
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

	[Column(Storage = "_CloudsyncReservationID", DbType = "BigInt NOT NULL")]
	public long CloudsyncReservationID
	{
		get
		{
			return _CloudsyncReservationID;
		}
		set
		{
			if (_CloudsyncReservationID != value)
			{
				SendPropertyChanging();
				_CloudsyncReservationID = value;
				SendPropertyChanged("CloudsyncReservationID");
			}
		}
	}

	[Column(Storage = "_AppointmentType", DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
	public string AppointmentType
	{
		get
		{
			return _AppointmentType;
		}
		set
		{
			if (_AppointmentType != value)
			{
				SendPropertyChanging();
				_AppointmentType = value;
				SendPropertyChanged("AppointmentType");
			}
		}
	}

	[Column(Storage = "_IsCleared", DbType = "Bit NOT NULL")]
	public bool IsCleared
	{
		get
		{
			return _IsCleared;
		}
		set
		{
			if (_IsCleared != value)
			{
				SendPropertyChanging();
				_IsCleared = value;
				SendPropertyChanged("IsCleared");
			}
		}
	}

	[Column(Storage = "_DateUpdated", DbType = "DateTime")]
	public DateTime? DateUpdated
	{
		get
		{
			return _DateUpdated;
		}
		set
		{
			if (_DateUpdated != value)
			{
				SendPropertyChanging();
				_DateUpdated = value;
				SendPropertyChanged("DateUpdated");
			}
		}
	}

	[Column(Storage = "_CustomerID", DbType = "Int")]
	public int? CustomerID
	{
		get
		{
			return _CustomerID;
		}
		set
		{
			if (_CustomerID != value)
			{
				if (_Customer.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_CustomerID = value;
				SendPropertyChanged("CustomerID");
			}
		}
	}

	[Association(Name = "Appointment_Layout", Storage = "_Layouts", ThisKey = "AppointmentID", OtherKey = "AppointmentID")]
	public EntitySet<Layout> Layouts
	{
		get
		{
			return _Layouts;
		}
		set
		{
			_Layouts.Assign(value);
		}
	}

	[Association(Name = "Customer_Appointment", Storage = "_Customer", ThisKey = "CustomerID", OtherKey = "CustomerID", IsForeignKey = true)]
	public Customer Customer
	{
		get
		{
			return _Customer.Entity;
		}
		set
		{
			Customer entity = _Customer.Entity;
			if (entity != value || !_Customer.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Customer.Entity = null;
					entity.Appointments.Remove(this);
				}
				_Customer.Entity = value;
				if (value != null)
				{
					value.Appointments.Add(this);
					_CustomerID = value.CustomerID;
				}
				else
				{
					_CustomerID = null;
				}
				SendPropertyChanged("Customer");
			}
		}
	}

	[Association(Name = "Employee_Appointment", Storage = "_Employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
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
					entity.Appointments.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.Appointments.Add(this);
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

	public Appointment()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Layouts = new EntitySet<Layout>(method_0, method_1);
		_Customer = default(EntityRef<Customer>);
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

	private void method_0(Layout layout_0)
	{
		SendPropertyChanging();
		layout_0.Appointment = this;
	}

	private void method_1(Layout layout_0)
	{
		SendPropertyChanging();
		layout_0.Appointment = null;
	}

	static Appointment()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
