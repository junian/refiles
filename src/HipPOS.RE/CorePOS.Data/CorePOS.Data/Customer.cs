using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Customers")]
public class Customer : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _CustomerID;

	private int _EmployeeID;

	private string _MemberNumber;

	private string _CustomerName;

	private string _CustomerCell;

	private string _CustomerHome;

	private string _CustomerEmail;

	private string _Comments;

	private DateTime _DateCreated;

	private bool _Active;

	private string _Address;

	private string _LoyaltyCardNo;

	private bool _Synced;

	private Guid? _CloudsyncGUID;

	private decimal? _DeliveryTravelDistanceKM;

	private int _DeliveryTravelTimeMinutes;

	private DateTime? _LastModified;

	private EntitySet<Appointment> _Appointments;

	private EntityRef<Employee> _Employee;

	[CompilerGenerated]
	private PropertyChangingEventHandler cGkjYjRyma;

	[CompilerGenerated]
	private PropertyChangedEventHandler GyZjisdqLB;

	[Column(Storage = "_CustomerID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int CustomerID
	{
		get
		{
			return _CustomerID;
		}
		set
		{
			if (_CustomerID != value)
			{
				SendPropertyChanging();
				_CustomerID = value;
				SendPropertyChanged("CustomerID");
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

	[Column(Storage = "_MemberNumber", DbType = "NVarChar(50)")]
	public string MemberNumber
	{
		get
		{
			return _MemberNumber;
		}
		set
		{
			if (_MemberNumber != value)
			{
				SendPropertyChanging();
				_MemberNumber = value;
				SendPropertyChanged("MemberNumber");
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

	[Column(Storage = "_Address", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
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

	[Column(Storage = "_LoyaltyCardNo", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string LoyaltyCardNo
	{
		get
		{
			return _LoyaltyCardNo;
		}
		set
		{
			if (_LoyaltyCardNo != value)
			{
				SendPropertyChanging();
				_LoyaltyCardNo = value;
				SendPropertyChanged("LoyaltyCardNo");
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

	[Column(Storage = "_CloudsyncGUID", DbType = "UniqueIdentifier")]
	public Guid? CloudsyncGUID
	{
		get
		{
			return _CloudsyncGUID;
		}
		set
		{
			if (_CloudsyncGUID != value)
			{
				SendPropertyChanging();
				_CloudsyncGUID = value;
				SendPropertyChanged("CloudsyncGUID");
			}
		}
	}

	[Column(Storage = "_DeliveryTravelDistanceKM", DbType = "Decimal(6,2)")]
	public decimal? DeliveryTravelDistanceKM
	{
		get
		{
			return _DeliveryTravelDistanceKM;
		}
		set
		{
			if (!(_DeliveryTravelDistanceKM == value))
			{
				SendPropertyChanging();
				_DeliveryTravelDistanceKM = value;
				SendPropertyChanged("DeliveryTravelDistanceKM");
			}
		}
	}

	[Column(Storage = "_DeliveryTravelTimeMinutes", DbType = "Int NOT NULL")]
	public int DeliveryTravelTimeMinutes
	{
		get
		{
			return _DeliveryTravelTimeMinutes;
		}
		set
		{
			if (_DeliveryTravelTimeMinutes != value)
			{
				SendPropertyChanging();
				_DeliveryTravelTimeMinutes = value;
				SendPropertyChanged("DeliveryTravelTimeMinutes");
			}
		}
	}

	[Column(Storage = "_LastModified", DbType = "DateTime")]
	public DateTime? LastModified
	{
		get
		{
			return _LastModified;
		}
		set
		{
			if (_LastModified != value)
			{
				SendPropertyChanging();
				_LastModified = value;
				SendPropertyChanged("LastModified");
			}
		}
	}

	[Association(Name = "Customer_Appointment", Storage = "_Appointments", ThisKey = "CustomerID", OtherKey = "CustomerID")]
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

	[Association(Name = "Employee_Customer", Storage = "_Employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
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
					entity.Customers.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.Customers.Add(this);
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
			PropertyChangingEventHandler propertyChangingEventHandler = cGkjYjRyma;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref cGkjYjRyma, value2, propertyChangingEventHandler2);
			}
			while ((object)propertyChangingEventHandler != propertyChangingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangingEventHandler propertyChangingEventHandler = cGkjYjRyma;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref cGkjYjRyma, value2, propertyChangingEventHandler2);
			}
			while ((object)propertyChangingEventHandler != propertyChangingEventHandler2);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = GyZjisdqLB;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref GyZjisdqLB, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = GyZjisdqLB;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref GyZjisdqLB, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public Customer()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Appointments = new EntitySet<Appointment>(method_0, method_1);
		_Employee = default(EntityRef<Employee>);
	}

	protected virtual void SendPropertyChanging()
	{
		if (cGkjYjRyma != null)
		{
			cGkjYjRyma(this, propertyChangingEventArgs_0);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (GyZjisdqLB != null)
		{
			GyZjisdqLB(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void method_0(Appointment appointment_0)
	{
		SendPropertyChanging();
		appointment_0.Customer = this;
	}

	private void method_1(Appointment appointment_0)
	{
		SendPropertyChanging();
		appointment_0.Customer = null;
	}

	static Customer()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
