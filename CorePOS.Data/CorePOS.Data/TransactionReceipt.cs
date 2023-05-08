using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.TransactionReceipts")]
public class TransactionReceipt : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _TransactionReceiptID;

	private string _OrderNumber;

	private string _RefundNumber;

	private string _CustomerReceipt;

	private string _MerchantReceipt;

	private DateTime _DateCreated;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TransactionReceiptID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TransactionReceiptID
	{
		get
		{
			return _TransactionReceiptID;
		}
		set
		{
			if (_TransactionReceiptID != value)
			{
				SendPropertyChanging();
				_TransactionReceiptID = value;
				SendPropertyChanged("TransactionReceiptID");
			}
		}
	}

	[Column(Storage = "_OrderNumber", DbType = "NVarChar(50)")]
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

	[Column(Storage = "_RefundNumber", DbType = "NVarChar(10)")]
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

	[Column(Storage = "_CustomerReceipt", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
	public string CustomerReceipt
	{
		get
		{
			return _CustomerReceipt;
		}
		set
		{
			if (_CustomerReceipt != value)
			{
				SendPropertyChanging();
				_CustomerReceipt = value;
				SendPropertyChanged("CustomerReceipt");
			}
		}
	}

	[Column(Storage = "_MerchantReceipt", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
	public string MerchantReceipt
	{
		get
		{
			return _MerchantReceipt;
		}
		set
		{
			if (_MerchantReceipt != value)
			{
				SendPropertyChanging();
				_MerchantReceipt = value;
				SendPropertyChanged("MerchantReceipt");
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

	public TransactionReceipt()
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

	static TransactionReceipt()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
