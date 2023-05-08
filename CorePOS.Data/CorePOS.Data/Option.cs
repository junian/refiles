using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Options")]
public class Option : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _OptionID;

	private int? _ItemID;

	private decimal? _SpecialPrice;

	private bool _AllowAdditional;

	private bool _Synced;

	private EntityRef<Item> _Item;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_OptionID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int OptionID
	{
		get
		{
			return _OptionID;
		}
		set
		{
			if (_OptionID != value)
			{
				SendPropertyChanging();
				_OptionID = value;
				SendPropertyChanged("OptionID");
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

	[Column(Storage = "_SpecialPrice", DbType = "Decimal(18,2)")]
	public decimal? SpecialPrice
	{
		get
		{
			return _SpecialPrice;
		}
		set
		{
			if (!(_SpecialPrice == value))
			{
				SendPropertyChanging();
				_SpecialPrice = value;
				SendPropertyChanged("SpecialPrice");
			}
		}
	}

	[Column(Storage = "_AllowAdditional", DbType = "Bit NOT NULL")]
	public bool AllowAdditional
	{
		get
		{
			return _AllowAdditional;
		}
		set
		{
			if (_AllowAdditional != value)
			{
				SendPropertyChanging();
				_AllowAdditional = value;
				SendPropertyChanged("AllowAdditional");
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

	[Association(Name = "Item_Option", Storage = "_Item", ThisKey = "ItemID", OtherKey = "ItemID", IsForeignKey = true)]
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
					entity.Options.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.Options.Add(this);
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

	public Option()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
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

	static Option()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
