using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.UOMUnitsConversion")]
public class GClass7 : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private short _BaseUnitId;

	private short _ToUnitId;

	private string _Operator;

	private decimal _Factor;

	private int? _ItemID;

	private EntityRef<UOM> _UOM;

	private EntityRef<UOM> _UOM1;

	private EntityRef<Item> _Item;

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

	[Column(Storage = "_BaseUnitId", DbType = "SmallInt NOT NULL")]
	public short BaseUnitId
	{
		get
		{
			return _BaseUnitId;
		}
		set
		{
			if (_BaseUnitId != value)
			{
				if (_UOM.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_BaseUnitId = value;
				SendPropertyChanged("BaseUnitId");
			}
		}
	}

	[Column(Storage = "_ToUnitId", DbType = "SmallInt NOT NULL")]
	public short ToUnitId
	{
		get
		{
			return _ToUnitId;
		}
		set
		{
			if (_ToUnitId != value)
			{
				if (_UOM1.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ToUnitId = value;
				SendPropertyChanged("ToUnitId");
			}
		}
	}

	[Column(Storage = "_Operator", DbType = "NVarChar(3) NOT NULL", CanBeNull = false)]
	public string Operator
	{
		get
		{
			return _Operator;
		}
		set
		{
			if (_Operator != value)
			{
				SendPropertyChanging();
				_Operator = value;
				SendPropertyChanged("Operator");
			}
		}
	}

	[Column(Storage = "_Factor", DbType = "Decimal(16,4) NOT NULL")]
	public decimal Factor
	{
		get
		{
			return _Factor;
		}
		set
		{
			if (_Factor != value)
			{
				SendPropertyChanging();
				_Factor = value;
				SendPropertyChanged("Factor");
			}
		}
	}

	[Column(Storage = "_ItemID", DbType = "Int")]
	public int? ItemID
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

	[Association(Name = "UOM_UOMUnitsConversion", Storage = "_UOM", ThisKey = "BaseUnitId", OtherKey = "UOMID", IsForeignKey = true)]
	public UOM UOM
	{
		get
		{
			return _UOM.Entity;
		}
		set
		{
			UOM entity = _UOM.Entity;
			if (entity != value || !_UOM.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_UOM.Entity = null;
					entity.UOMUnitsConversions.Remove(this);
				}
				_UOM.Entity = value;
				if (value != null)
				{
					value.UOMUnitsConversions.Add(this);
					_BaseUnitId = value.UOMID;
				}
				else
				{
					_BaseUnitId = 0;
				}
				SendPropertyChanged("UOM");
			}
		}
	}

	[Association(Name = "UOM_UOMUnitsConversion1", Storage = "_UOM1", ThisKey = "ToUnitId", OtherKey = "UOMID", IsForeignKey = true)]
	public UOM UOM1
	{
		get
		{
			return _UOM1.Entity;
		}
		set
		{
			UOM entity = _UOM1.Entity;
			if (entity != value || !_UOM1.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_UOM1.Entity = null;
					entity.UOMUnitsConversions1.Remove(this);
				}
				_UOM1.Entity = value;
				if (value != null)
				{
					value.UOMUnitsConversions1.Add(this);
					_ToUnitId = value.UOMID;
				}
				else
				{
					_ToUnitId = 0;
				}
				SendPropertyChanged("UOM1");
			}
		}
	}

	[Association(Name = "Item_UOMUnitsConversion", Storage = "_Item", ThisKey = "ItemID", OtherKey = "ItemID", IsForeignKey = true)]
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
					entity.UOMUnitsConversions.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.UOMUnitsConversions.Add(this);
					_ItemID = value.ItemID;
				}
				else
				{
					_ItemID = null;
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

	public GClass7()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_UOM = default(EntityRef<UOM>);
		_UOM1 = default(EntityRef<UOM>);
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

	static GClass7()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
