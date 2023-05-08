using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.OnlineOrderSyncQueues")]
public class OnlineOrderSyncQueue : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _Provider;

	private string _RawData;

	private DateTime _DateCreated;

	private DateTime? _DateProcessed;

	private string _Comment;

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

	[Column(Storage = "_Provider", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string Provider
	{
		get
		{
			return _Provider;
		}
		set
		{
			if (_Provider != value)
			{
				SendPropertyChanging();
				_Provider = value;
				SendPropertyChanged("Provider");
			}
		}
	}

	[Column(Storage = "_RawData", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false)]
	public string RawData
	{
		get
		{
			return _RawData;
		}
		set
		{
			if (_RawData != value)
			{
				SendPropertyChanging();
				_RawData = value;
				SendPropertyChanged("RawData");
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

	[Column(Storage = "_DateProcessed", DbType = "DateTime")]
	public DateTime? DateProcessed
	{
		get
		{
			return _DateProcessed;
		}
		set
		{
			if (_DateProcessed != value)
			{
				SendPropertyChanging();
				_DateProcessed = value;
				SendPropertyChanged("DateProcessed");
			}
		}
	}

	[Column(Storage = "_Comment", DbType = "NVarChar(128)")]
	public string Comment
	{
		get
		{
			return _Comment;
		}
		set
		{
			if (_Comment != value)
			{
				SendPropertyChanging();
				_Comment = value;
				SendPropertyChanged("Comment");
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

	public OnlineOrderSyncQueue()
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

	static OnlineOrderSyncQueue()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
