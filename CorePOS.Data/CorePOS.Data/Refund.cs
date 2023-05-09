using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Refunds")]
public class Refund : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private Guid _RefundID;

	private string _RefundNumber;

	private DateTime _DateCreated;

	private Guid _OrderId;

	private decimal _Qty;

	private decimal _AmountRefunded;

	private int? _EmployeeID;

	private string _PaymentMethod;

	private string _RefundReason;

	private bool _Synced;

	private EntityRef<Employee> _Employee;

	private EntityRef<Order> _Order;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_RefundID", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
	public Guid RefundID
	{
		get
		{
			return _RefundID;
		}
		set
		{
			if (_RefundID != value)
			{
				SendPropertyChanging();
				_RefundID = value;
				SendPropertyChanged("RefundID");
			}
		}
	}

	[Column(Storage = "_RefundNumber", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
	public string RefundNumber
	{
		get
		{
			return _RefundNumber;
		}
		set
		{
			if (_RefundNumber != value)
			{
				SendPropertyChanging();
				_RefundNumber = value;
				SendPropertyChanged("RefundNumber");
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

	[Column(Storage = "_OrderId", DbType = "UniqueIdentifier NOT NULL")]
	public Guid OrderId
	{
		get
		{
			return _OrderId;
		}
		set
		{
			if (_OrderId != value)
			{
				if (_Order.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_OrderId = value;
				SendPropertyChanged("OrderId");
			}
		}
	}

	[Column(Storage = "_Qty", DbType = "Decimal(10,2) NOT NULL")]
	public decimal Qty
	{
		get
		{
			return _Qty;
		}
		set
		{
			if (_Qty != value)
			{
				SendPropertyChanging();
				_Qty = value;
				SendPropertyChanged("Qty");
			}
		}
	}

	[Column(Storage = "_AmountRefunded", DbType = "Decimal(10,2) NOT NULL")]
	public decimal AmountRefunded
	{
		get
		{
			return _AmountRefunded;
		}
		set
		{
			if (_AmountRefunded != value)
			{
				SendPropertyChanging();
				_AmountRefunded = value;
				SendPropertyChanged("AmountRefunded");
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

	[Column(Storage = "_PaymentMethod", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string PaymentMethod
	{
		get
		{
			return _PaymentMethod;
		}
		set
		{
			if (_PaymentMethod != value)
			{
				SendPropertyChanging();
				_PaymentMethod = value;
				SendPropertyChanged("PaymentMethod");
			}
		}
	}

	[Column(Storage = "_RefundReason", DbType = "NVarChar(100)")]
	public string RefundReason
	{
		get
		{
			return _RefundReason;
		}
		set
		{
			if (_RefundReason != value)
			{
				SendPropertyChanging();
				_RefundReason = value;
				SendPropertyChanged("RefundReason");
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

	[Association(Name = "Employee_Refund", Storage = "_Employee", ThisKey = "EmployeeID", OtherKey = "EmployeeID", IsForeignKey = true)]
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
					entity.Refunds.Remove(this);
				}
				_Employee.Entity = value;
				if (value != null)
				{
					value.Refunds.Add(this);
					_EmployeeID = value.EmployeeID;
				}
				else
				{
					_EmployeeID = null;
				}
				SendPropertyChanged("Employee");
			}
		}
	}

	[Association(Name = "Order_Refund", Storage = "_Order", ThisKey = "OrderId", OtherKey = "OrderId", IsForeignKey = true)]
	public Order Order
	{
		get
		{
			return _Order.Entity;
		}
		set
		{
			Order entity = _Order.Entity;
			if (entity != value || !_Order.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Order.Entity = null;
					entity.Refunds.Remove(this);
				}
				_Order.Entity = value;
				if (value != null)
				{
					value.Refunds.Add(this);
					_OrderId = value.OrderId;
				}
				else
				{
					_OrderId = default(Guid);
				}
				SendPropertyChanged("Order");
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

	public Refund()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Employee = default(EntityRef<Employee>);
		_Order = default(EntityRef<Order>);
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

	static Refund()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
