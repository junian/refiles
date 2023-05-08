using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.ItemsSupplier")]
public class ItemsSupplier : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _ItemId;

	private int _SupplierId;

	private EntityRef<Supplier> _Supplier;

	private EntityRef<Item> _Item;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_ItemId", DbType = "Int NOT NULL", IsPrimaryKey = true)]
	public int ItemId
	{
		get
		{
			return _ItemId;
		}
		set
		{
			if (_ItemId != value)
			{
				if (_Item.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ItemId = value;
				SendPropertyChanged("ItemId");
			}
		}
	}

	[Column(Storage = "_SupplierId", DbType = "Int NOT NULL", IsPrimaryKey = true)]
	public int SupplierId
	{
		get
		{
			return _SupplierId;
		}
		set
		{
			if (_SupplierId != value)
			{
				if (_Supplier.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_SupplierId = value;
				SendPropertyChanged("SupplierId");
			}
		}
	}

	[Association(Name = "Supplier_ItemsSupplier", Storage = "_Supplier", ThisKey = "SupplierId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
	public Supplier Supplier
	{
		get
		{
			return _Supplier.Entity;
		}
		set
		{
			Supplier entity = _Supplier.Entity;
			if (entity != value || !_Supplier.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Supplier.Entity = null;
					entity.ItemsSuppliers.Remove(this);
				}
				_Supplier.Entity = value;
				if (value != null)
				{
					value.ItemsSuppliers.Add(this);
					_SupplierId = value.Id;
				}
				else
				{
					_SupplierId = 0;
				}
				SendPropertyChanged("Supplier");
			}
		}
	}

	[Association(Name = "Item_ItemsSupplier", Storage = "_Item", ThisKey = "ItemId", OtherKey = "ItemID", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
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
					entity.ItemsSuppliers.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.ItemsSuppliers.Add(this);
					_ItemId = value.ItemID;
				}
				else
				{
					_ItemId = 0;
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

	public ItemsSupplier()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Supplier = default(EntityRef<Supplier>);
		_Item = default(EntityRef<Item>);
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

	static ItemsSupplier()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
