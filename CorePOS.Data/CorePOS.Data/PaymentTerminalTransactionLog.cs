using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.PaymentTerminalTransactionLogs")]
public class PaymentTerminalTransactionLog : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private long _PaymentTerminalTransactionLogID;

	private string _Type;

	private string _ProcessorName;

	private string _DeviceModel;

	private string _IP;

	private string _Data;

	private DateTime _DateCreated;

	private string _OrderNumber;

	private string _PaymentMethod;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_PaymentTerminalTransactionLogID", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public long PaymentTerminalTransactionLogID
	{
		get
		{
			return _PaymentTerminalTransactionLogID;
		}
		set
		{
			if (_PaymentTerminalTransactionLogID != value)
			{
				SendPropertyChanging();
				_PaymentTerminalTransactionLogID = value;
				SendPropertyChanged("PaymentTerminalTransactionLogID");
			}
		}
	}

	[Column(Storage = "_Type", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string Type
	{
		get
		{
			return _Type;
		}
		set
		{
			if (_Type != value)
			{
				SendPropertyChanging();
				_Type = value;
				SendPropertyChanged("Type");
			}
		}
	}

	[Column(Storage = "_ProcessorName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string ProcessorName
	{
		get
		{
			return _ProcessorName;
		}
		set
		{
			if (_ProcessorName != value)
			{
				SendPropertyChanging();
				_ProcessorName = value;
				SendPropertyChanged("ProcessorName");
			}
		}
	}

	[Column(Storage = "_DeviceModel", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string DeviceModel
	{
		get
		{
			return _DeviceModel;
		}
		set
		{
			if (_DeviceModel != value)
			{
				SendPropertyChanging();
				_DeviceModel = value;
				SendPropertyChanged("DeviceModel");
			}
		}
	}

	[Column(Storage = "_IP", DbType = "NVarChar(15) NOT NULL", CanBeNull = false)]
	public string IP
	{
		get
		{
			return _IP;
		}
		set
		{
			if (_IP != value)
			{
				SendPropertyChanging();
				_IP = value;
				SendPropertyChanged("IP");
			}
		}
	}

	[Column(Storage = "_Data", DbType = "NVarChar(MAX)")]
	public string Data
	{
		get
		{
			return _Data;
		}
		set
		{
			if (_Data != value)
			{
				SendPropertyChanging();
				_Data = value;
				SendPropertyChanged("Data");
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

	[Column(Storage = "_OrderNumber", DbType = "NVarChar(20)")]
	public string OrderNumber
	{
		get
		{
			return _OrderNumber;
		}
		set
		{
			if (_OrderNumber != value)
			{
				SendPropertyChanging();
				_OrderNumber = value;
				SendPropertyChanged("OrderNumber");
			}
		}
	}

	[Column(Storage = "_PaymentMethod", DbType = "NVarChar(256)")]
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

	public PaymentTerminalTransactionLog()
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

	static PaymentTerminalTransactionLog()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
