using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.MaterialsInItem")]
public class MaterialsInItem : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _ID;

	private int _ItemID;

	private int _ItemMaterialID;

	private decimal? _Quantity;

	private short _UOMID;

	private string _Comments;

	private EntityRef<UOM> _UOM;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int ID
	{
		get
		{
			return _ID;
		}
		set
		{
			if (_ID != value)
			{
				SendPropertyChanging();
				_ID = value;
				SendPropertyChanged("ID");
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

	[Column(Storage = "_ItemMaterialID", DbType = "Int NOT NULL")]
	public int ItemMaterialID
	{
		get
		{
			return _ItemMaterialID;
		}
		set
		{
			if (_ItemMaterialID != value)
			{
				SendPropertyChanging();
				_ItemMaterialID = value;
				SendPropertyChanged("ItemMaterialID");
			}
		}
	}

	[Column(Storage = "_Quantity", DbType = "Decimal(18,4)")]
	public decimal? Quantity
	{
		get
		{
			return _Quantity;
		}
		set
		{
			if (!(_Quantity == value))
			{
				SendPropertyChanging();
				_Quantity = value;
				SendPropertyChanged("Quantity");
			}
		}
	}

	[Column(Storage = "_UOMID", DbType = "SmallInt NOT NULL")]
	public short UOMID
	{
		get
		{
			return _UOMID;
		}
		set
		{
			if (_UOMID != value)
			{
				if (_UOM.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_UOMID = value;
				SendPropertyChanged("UOMID");
			}
		}
	}

	[Column(Storage = "_Comments", DbType = "NVarChar(256)")]
	public string Comments
	{
		get
		{
			return _Comments;
		}
		set
		{
			if (_Comments != value)
			{
				SendPropertyChanging();
				_Comments = value;
				SendPropertyChanged("Comments");
			}
		}
	}

	[Association(Name = "UOM_MaterialsInItem", Storage = "_UOM", ThisKey = "UOMID", OtherKey = "UOMID", IsForeignKey = true)]
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
					entity.MaterialsInItems.Remove(this);
				}
				_UOM.Entity = value;
				if (value != null)
				{
					value.MaterialsInItems.Add(this);
					_UOMID = value.UOMID;
				}
				else
				{
					_UOMID = 0;
				}
				SendPropertyChanged("UOM");
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

	public MaterialsInItem()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_UOM = default(EntityRef<UOM>);
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

	static MaterialsInItem()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
