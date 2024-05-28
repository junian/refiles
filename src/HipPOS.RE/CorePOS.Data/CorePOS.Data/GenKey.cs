using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.GenKeys")]
public class GenKey : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _GenKeyID;

	private string _KeyName;

	private string _Prefix;

	private long _LastKey;

	private long _CleanUp_Bookmark;

	private DateTime? _LastDateUpdated;

	private int? _StartKey;

	private int? _EndKey;

	private EntitySet<OrderTypeGenKey> _OrderTypeGenKeys;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_GenKeyID", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public short GenKeyID
	{
		get
		{
			return _GenKeyID;
		}
		set
		{
			if (_GenKeyID != value)
			{
				SendPropertyChanging();
				_GenKeyID = value;
				SendPropertyChanged("GenKeyID");
			}
		}
	}

	[Column(Storage = "_KeyName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string KeyName
	{
		get
		{
			return _KeyName;
		}
		set
		{
			if (_KeyName != value)
			{
				SendPropertyChanging();
				_KeyName = value;
				SendPropertyChanged("KeyName");
			}
		}
	}

	[Column(Storage = "_Prefix", DbType = "NChar(2)")]
	public string Prefix
	{
		get
		{
			return _Prefix;
		}
		set
		{
			if (_Prefix != value)
			{
				SendPropertyChanging();
				_Prefix = value;
				SendPropertyChanged("Prefix");
			}
		}
	}

	[Column(Storage = "_LastKey", DbType = "BigInt NOT NULL")]
	public long LastKey
	{
		get
		{
			return _LastKey;
		}
		set
		{
			if (_LastKey != value)
			{
				SendPropertyChanging();
				_LastKey = value;
				SendPropertyChanged("LastKey");
			}
		}
	}

	[Column(Storage = "_CleanUp_Bookmark", DbType = "BigInt NOT NULL")]
	public long CleanUp_Bookmark
	{
		get
		{
			return _CleanUp_Bookmark;
		}
		set
		{
			if (_CleanUp_Bookmark != value)
			{
				SendPropertyChanging();
				_CleanUp_Bookmark = value;
				SendPropertyChanged("CleanUp_Bookmark");
			}
		}
	}

	[Column(Storage = "_LastDateUpdated", DbType = "DateTime")]
	public DateTime? LastDateUpdated
	{
		get
		{
			return _LastDateUpdated;
		}
		set
		{
			if (_LastDateUpdated != value)
			{
				SendPropertyChanging();
				_LastDateUpdated = value;
				SendPropertyChanged("LastDateUpdated");
			}
		}
	}

	[Column(Storage = "_StartKey", DbType = "Int")]
	public int? StartKey
	{
		get
		{
			return _StartKey;
		}
		set
		{
			if (_StartKey != value)
			{
				SendPropertyChanging();
				_StartKey = value;
				SendPropertyChanged("StartKey");
			}
		}
	}

	[Column(Storage = "_EndKey", DbType = "Int")]
	public int? EndKey
	{
		get
		{
			return _EndKey;
		}
		set
		{
			if (_EndKey != value)
			{
				SendPropertyChanging();
				_EndKey = value;
				SendPropertyChanged("EndKey");
			}
		}
	}

	[Association(Name = "GenKey_OrderTypeGenKey", Storage = "_OrderTypeGenKeys", ThisKey = "GenKeyID", OtherKey = "GenKeysId")]
	public EntitySet<OrderTypeGenKey> OrderTypeGenKeys
	{
		get
		{
			return _OrderTypeGenKeys;
		}
		set
		{
			_OrderTypeGenKeys.Assign(value);
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

	public GenKey()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_OrderTypeGenKeys = new EntitySet<OrderTypeGenKey>(method_0, method_1);
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

	private void method_0(OrderTypeGenKey orderTypeGenKey_0)
	{
		SendPropertyChanging();
		orderTypeGenKey_0.GenKey = this;
	}

	private void method_1(OrderTypeGenKey orderTypeGenKey_0)
	{
		SendPropertyChanging();
		orderTypeGenKey_0.GenKey = null;
	}

	static GenKey()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
