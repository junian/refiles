using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.InventoryBatches")]
public class InventoryBatch : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _BatchNumber;

	private DateTime _ReceivedDate;

	private DateTime _ExpiryDate;

	private decimal _QTYReceived;

	private decimal _QTYRemaining;

	private int _ItemID;

	private bool _Synced;

	private EntityRef<Item> _Item;

	[CompilerGenerated]
	private PropertyChangingEventHandler elmXvbpnaU;

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

	[Column(Storage = "_BatchNumber", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string BatchNumber
	{
		get
		{
			return _BatchNumber;
		}
		set
		{
			if (_BatchNumber != value)
			{
				SendPropertyChanging();
				_BatchNumber = value;
				SendPropertyChanged("BatchNumber");
			}
		}
	}

	[Column(Storage = "_ReceivedDate", DbType = "DateTime NOT NULL")]
	public DateTime ReceivedDate
	{
		get
		{
			return _ReceivedDate;
		}
		set
		{
			if (_ReceivedDate != value)
			{
				SendPropertyChanging();
				_ReceivedDate = value;
				SendPropertyChanged("ReceivedDate");
			}
		}
	}

	[Column(Storage = "_ExpiryDate", DbType = "DateTime NOT NULL")]
	public DateTime ExpiryDate
	{
		get
		{
			return _ExpiryDate;
		}
		set
		{
			if (_ExpiryDate != value)
			{
				SendPropertyChanging();
				_ExpiryDate = value;
				SendPropertyChanged("ExpiryDate");
			}
		}
	}

	[Column(Storage = "_QTYReceived", DbType = "Decimal(18,2) NOT NULL")]
	public decimal Decimal_0
	{
		get
		{
			return _QTYReceived;
		}
		set
		{
			if (_QTYReceived != value)
			{
				SendPropertyChanging();
				_QTYReceived = value;
				SendPropertyChanged("QTYReceived");
			}
		}
	}

	[Column(Storage = "_QTYRemaining", DbType = "Decimal(18,2) NOT NULL")]
	public decimal QTYRemaining
	{
		get
		{
			return _QTYRemaining;
		}
		set
		{
			if (_QTYRemaining != value)
			{
				SendPropertyChanging();
				_QTYRemaining = value;
				SendPropertyChanged("QTYRemaining");
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
				if (_Item.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ItemID = value;
				SendPropertyChanged("ItemID");
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

	[Association(Name = "Item_InventoryBatch", Storage = "_Item", ThisKey = "ItemID", OtherKey = "ItemID", IsForeignKey = true)]
	public Item Item
	{
		get
		{
			return _Item.Entity;
		}
		set
		{
			Item entity = _Item.Entity;
			if (entity != value || !_Item.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Item.Entity = null;
					entity.InventoryBatches.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.InventoryBatches.Add(this);
					_ItemID = value.ItemID;
				}
				else
				{
					_ItemID = 0;
				}
				SendPropertyChanged("Item");
			}
		}
	}

	public event PropertyChangingEventHandler PropertyChanging
	{
		[CompilerGenerated]
		add
		{
			PropertyChangingEventHandler propertyChangingEventHandler = elmXvbpnaU;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref elmXvbpnaU, value2, propertyChangingEventHandler2);
			}
			while ((object)propertyChangingEventHandler != propertyChangingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangingEventHandler propertyChangingEventHandler = elmXvbpnaU;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			do
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
				PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler2, value);
				propertyChangingEventHandler = Interlocked.CompareExchange(ref elmXvbpnaU, value2, propertyChangingEventHandler2);
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

	public InventoryBatch()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Item = default(EntityRef<Item>);
	}

	protected virtual void SendPropertyChanging()
	{
		if (elmXvbpnaU != null)
		{
			elmXvbpnaU(this, propertyChangingEventArgs_0);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static InventoryBatch()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
