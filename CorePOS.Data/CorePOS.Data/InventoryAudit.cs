using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.InventoryAudits")]
public class InventoryAudit : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _InventoryAuditId;

	private int _ItemID;

	private decimal _QtyStart;

	private decimal _QtyChange;

	private decimal _QtyNew;

	private string _Owner;

	private string _Comment;

	private DateTime _DateCreated;

	private bool _Synced;

	private long _CloudInventoryAuditID;

	private string _InventoryType;

	private int? _SupplierId;

	private bool _isReconciled;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_InventoryAuditId", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int InventoryAuditId
	{
		get
		{
			return _InventoryAuditId;
		}
		set
		{
			if (_InventoryAuditId != value)
			{
				SendPropertyChanging();
				_InventoryAuditId = value;
				SendPropertyChanged("InventoryAuditId");
			}
		}
	}

	[Column(Storage = "_ItemID", DbType = "Int NOT NULL")]
	public int ItemID
	{
		get
		{
			return _ItemID;
		}
		set
		{
			if (_ItemID != value)
			{
				SendPropertyChanging();
				_ItemID = value;
				SendPropertyChanged("ItemID");
			}
		}
	}

	[Column(Storage = "_QtyStart", DbType = "Decimal(18,4) NOT NULL")]
	public decimal QtyStart
	{
		get
		{
			return _QtyStart;
		}
		set
		{
			if (_QtyStart != value)
			{
				SendPropertyChanging();
				_QtyStart = value;
				SendPropertyChanged("QtyStart");
			}
		}
	}

	[Column(Storage = "_QtyChange", DbType = "Decimal(18,4) NOT NULL")]
	public decimal QtyChange
	{
		get
		{
			return _QtyChange;
		}
		set
		{
			if (_QtyChange != value)
			{
				SendPropertyChanging();
				_QtyChange = value;
				SendPropertyChanged("QtyChange");
			}
		}
	}

	[Column(Storage = "_QtyNew", DbType = "Decimal(18,4) NOT NULL")]
	public decimal QtyNew
	{
		get
		{
			return _QtyNew;
		}
		set
		{
			if (_QtyNew != value)
			{
				SendPropertyChanging();
				_QtyNew = value;
				SendPropertyChanged("QtyNew");
			}
		}
	}

	[Column(Storage = "_Owner", DbType = "NVarChar(50)")]
	public string Owner
	{
		get
		{
			return _Owner;
		}
		set
		{
			if (_Owner != value)
			{
				SendPropertyChanging();
				_Owner = value;
				SendPropertyChanged("Owner");
			}
		}
	}

	[Column(Storage = "_Comment", DbType = "NVarChar(MAX)")]
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

	[Column(Storage = "_CloudInventoryAuditID", DbType = "BigInt NOT NULL")]
	public long CloudInventoryAuditID
	{
		get
		{
			return _CloudInventoryAuditID;
		}
		set
		{
			if (_CloudInventoryAuditID != value)
			{
				SendPropertyChanging();
				_CloudInventoryAuditID = value;
				SendPropertyChanged("CloudInventoryAuditID");
			}
		}
	}

	[Column(Storage = "_InventoryType", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string InventoryType
	{
		get
		{
			return _InventoryType;
		}
		set
		{
			if (_InventoryType != value)
			{
				SendPropertyChanging();
				_InventoryType = value;
				SendPropertyChanged("InventoryType");
			}
		}
	}

	[Column(Storage = "_SupplierId", DbType = "Int")]
	public int? SupplierId
	{
		get
		{
			return _SupplierId;
		}
		set
		{
			if (_SupplierId != value)
			{
				SendPropertyChanging();
				_SupplierId = value;
				SendPropertyChanged("SupplierId");
			}
		}
	}

	[Column(Storage = "_isReconciled", DbType = "Bit NOT NULL")]
	public bool isReconciled
	{
		get
		{
			return _isReconciled;
		}
		set
		{
			if (_isReconciled != value)
			{
				SendPropertyChanging();
				_isReconciled = value;
				SendPropertyChanged("isReconciled");
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

	public InventoryAudit()
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

	static InventoryAudit()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
