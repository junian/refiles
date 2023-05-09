using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Layout")]
public class Layout : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _TableID;

	private string _TableName;

	private int? _Y;

	private int? _X;

	private char? _Rotation;

	private int? _NumOfSeats;

	private bool _Active;

	private string _Section;

	private bool _Round;

	private int _CurrentGuests;

	private bool _isReserved;

	private string _ReservationName;

	private int? _AppointmentID;

	private int _AngleOfRotation;

	private int? _EmployeeID;

	private DateTime? _DateTimeSeated;

	private EntityRef<Appointment> _Appointment;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TableID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TableID
	{
		get
		{
			return _TableID;
		}
		set
		{
			if (_TableID != value)
			{
				SendPropertyChanging();
				_TableID = value;
				SendPropertyChanged("TableID");
			}
		}
	}

	[Column(Storage = "_TableName", DbType = "NVarChar(40) NOT NULL", CanBeNull = false)]
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
				SendPropertyChanging();
				_TableName = value;
				SendPropertyChanged("TableName");
			}
		}
	}

	[Column(Storage = "_Y", DbType = "Int")]
	public int? Y
	{
		get
		{
			return _Y;
		}
		set
		{
			if (_Y != value)
			{
				SendPropertyChanging();
				_Y = value;
				SendPropertyChanged("Y");
			}
		}
	}

	[Column(Storage = "_X", DbType = "Int")]
	public int? X
	{
		get
		{
			return _X;
		}
		set
		{
			if (_X != value)
			{
				SendPropertyChanging();
				_X = value;
				SendPropertyChanged("X");
			}
		}
	}

	[Column(Storage = "_Rotation", DbType = "Char(1)")]
	public char? Rotation
	{
		get
		{
			return _Rotation;
		}
		set
		{
			if (_Rotation != value)
			{
				SendPropertyChanging();
				_Rotation = value;
				SendPropertyChanged("Rotation");
			}
		}
	}

	[Column(Storage = "_NumOfSeats", DbType = "Int")]
	public int? NumOfSeats
	{
		get
		{
			return _NumOfSeats;
		}
		set
		{
			if (_NumOfSeats != value)
			{
				SendPropertyChanging();
				_NumOfSeats = value;
				SendPropertyChanged("NumOfSeats");
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

	[Column(Storage = "_Section", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
	public string Section
	{
		get
		{
			return _Section;
		}
		set
		{
			if (_Section != value)
			{
				SendPropertyChanging();
				_Section = value;
				SendPropertyChanged("Section");
			}
		}
	}

	[Column(Storage = "_Round", DbType = "Bit NOT NULL")]
	public bool Round
	{
		get
		{
			return _Round;
		}
		set
		{
			if (_Round != value)
			{
				SendPropertyChanging();
				_Round = value;
				SendPropertyChanged("Round");
			}
		}
	}

	[Column(Storage = "_CurrentGuests", DbType = "Int NOT NULL")]
	public int CurrentGuests
	{
		get
		{
			return _CurrentGuests;
		}
		set
		{
			if (_CurrentGuests != value)
			{
				SendPropertyChanging();
				_CurrentGuests = value;
				SendPropertyChanged("CurrentGuests");
			}
		}
	}

	[Column(Storage = "_isReserved", DbType = "Bit NOT NULL")]
	public bool isReserved
	{
		get
		{
			return _isReserved;
		}
		set
		{
			if (_isReserved != value)
			{
				SendPropertyChanging();
				_isReserved = value;
				SendPropertyChanged("isReserved");
			}
		}
	}

	[Column(Storage = "_ReservationName", DbType = "NVarChar(512)")]
	public string ReservationName
	{
		get
		{
			return _ReservationName;
		}
		set
		{
			if (_ReservationName != value)
			{
				SendPropertyChanging();
				_ReservationName = value;
				SendPropertyChanged("ReservationName");
			}
		}
	}

	[Column(Storage = "_AppointmentID", DbType = "Int")]
	public int? AppointmentID
	{
		get
		{
			return _AppointmentID;
		}
		set
		{
			if (_AppointmentID != value)
			{
				if (_Appointment.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_AppointmentID = value;
				SendPropertyChanged("AppointmentID");
			}
		}
	}

	[Column(Storage = "_AngleOfRotation", DbType = "Int NOT NULL")]
	public int AngleOfRotation
	{
		get
		{
			return _AngleOfRotation;
		}
		set
		{
			if (_AngleOfRotation != value)
			{
				SendPropertyChanging();
				_AngleOfRotation = value;
				SendPropertyChanged("AngleOfRotation");
			}
		}
	}

	[Column(Storage = "_EmployeeID", DbType = "Int")]
	public int? EmployeeID
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

	[Column(Storage = "_DateTimeSeated", DbType = "DateTime")]
	public DateTime? DateTimeSeated
	{
		get
		{
			return _DateTimeSeated;
		}
		set
		{
			if (_DateTimeSeated != value)
			{
				SendPropertyChanging();
				_DateTimeSeated = value;
				SendPropertyChanged("DateTimeSeated");
			}
		}
	}

	[Association(Name = "Appointment_Layout", Storage = "_Appointment", ThisKey = "AppointmentID", OtherKey = "AppointmentID", IsForeignKey = true)]
	public Appointment Appointment
	{
		get
		{
			return _Appointment.Entity;
		}
		set
		{
			Appointment entity = _Appointment.Entity;
			if (entity != value || !_Appointment.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Appointment.Entity = null;
					entity.Layouts.Remove(this);
				}
				_Appointment.Entity = value;
				if (value != null)
				{
					value.Layouts.Add(this);
					_AppointmentID = value.AppointmentID;
				}
				else
				{
					_AppointmentID = null;
				}
				SendPropertyChanged("Appointment");
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

	public Layout()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Appointment = default(EntityRef<Appointment>);
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

	static Layout()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
