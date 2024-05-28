using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.PaymentTypes")]
public class PaymentType : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _Name;

	private int _SortOrder;

	private bool _OpenCashDrawer;

	private bool _UsePaymentTerminal;

	private bool _SystemDefault;

	private bool _PrintReceipt;

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

	[Column(Storage = "_Name", DbType = "NVarChar(20)")]
	public string Name
	{
		get
		{
			return _Name;
		}
		set
		{
			if (_Name != value)
			{
				SendPropertyChanging();
				_Name = value;
				SendPropertyChanged("Name");
			}
		}
	}

	[Column(Storage = "_SortOrder", DbType = "Int NOT NULL")]
	public int SortOrder
	{
		get
		{
			return _SortOrder;
		}
		set
		{
			if (_SortOrder != value)
			{
				SendPropertyChanging();
				_SortOrder = value;
				SendPropertyChanged("SortOrder");
			}
		}
	}

	[Column(Storage = "_OpenCashDrawer", DbType = "Bit NOT NULL")]
	public bool OpenCashDrawer
	{
		get
		{
			return _OpenCashDrawer;
		}
		set
		{
			if (_OpenCashDrawer != value)
			{
				SendPropertyChanging();
				_OpenCashDrawer = value;
				SendPropertyChanged("OpenCashDrawer");
			}
		}
	}

	[Column(Storage = "_UsePaymentTerminal", DbType = "Bit NOT NULL")]
	public bool UsePaymentTerminal
	{
		get
		{
			return _UsePaymentTerminal;
		}
		set
		{
			if (_UsePaymentTerminal != value)
			{
				SendPropertyChanging();
				_UsePaymentTerminal = value;
				SendPropertyChanged("UsePaymentTerminal");
			}
		}
	}

	[Column(Storage = "_SystemDefault", DbType = "Bit NOT NULL")]
	public bool SystemDefault
	{
		get
		{
			return _SystemDefault;
		}
		set
		{
			if (_SystemDefault != value)
			{
				SendPropertyChanging();
				_SystemDefault = value;
				SendPropertyChanged("SystemDefault");
			}
		}
	}

	[Column(Storage = "_PrintReceipt", DbType = "Bit NOT NULL")]
	public bool PrintReceipt
	{
		get
		{
			return _PrintReceipt;
		}
		set
		{
			if (_PrintReceipt != value)
			{
				SendPropertyChanging();
				_PrintReceipt = value;
				SendPropertyChanged("PrintReceipt");
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

	public PaymentType()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
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

	static PaymentType()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
