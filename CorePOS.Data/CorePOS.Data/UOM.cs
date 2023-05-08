using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.UOMs")]
public class UOM : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _UOMID;

	private string _Name;

	private bool _isFractional;

	private bool _Synced;

	private EntitySet<GClass7> _UOMUnitsConversions;

	private EntitySet<GClass7> _UOMUnitsConversions1;

	private EntitySet<MaterialsInItem> _MaterialsInItems;

	private EntitySet<Item> _Items;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_UOMID", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
				SendPropertyChanging();
				_UOMID = value;
				SendPropertyChanged("UOMID");
			}
		}
	}

	[Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

	[Column(Storage = "_isFractional", DbType = "Bit NOT NULL")]
	public bool isFractional
	{
		get
		{
			return _isFractional;
		}
		set
		{
			if (_isFractional != value)
			{
				SendPropertyChanging();
				_isFractional = value;
				SendPropertyChanged("isFractional");
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

	[Association(Name = "UOM_UOMUnitsConversion", Storage = "_UOMUnitsConversions", ThisKey = "UOMID", OtherKey = "BaseUnitId")]
	public EntitySet<GClass7> UOMUnitsConversions
	{
		get
		{
			return _UOMUnitsConversions;
		}
		set
		{
			_UOMUnitsConversions.Assign(value);
		}
	}

	[Association(Name = "UOM_UOMUnitsConversion1", Storage = "_UOMUnitsConversions1", ThisKey = "UOMID", OtherKey = "ToUnitId")]
	public EntitySet<GClass7> UOMUnitsConversions1
	{
		get
		{
			return _UOMUnitsConversions1;
		}
		set
		{
			_UOMUnitsConversions1.Assign(value);
		}
	}

	[Association(Name = "UOM_MaterialsInItem", Storage = "_MaterialsInItems", ThisKey = "UOMID", OtherKey = "UOMID")]
	public EntitySet<MaterialsInItem> MaterialsInItems
	{
		get
		{
			return _MaterialsInItems;
		}
		set
		{
			_MaterialsInItems.Assign(value);
		}
	}

	[Association(Name = "UOM_Item", Storage = "_Items", ThisKey = "UOMID", OtherKey = "UOMID")]
	public EntitySet<Item> Items
	{
		get
		{
			return _Items;
		}
		set
		{
			_Items.Assign(value);
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

	public UOM()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_UOMUnitsConversions = new EntitySet<GClass7>(method_0, method_1);
		_UOMUnitsConversions1 = new EntitySet<GClass7>(method_2, rhajkLhHpk);
		_MaterialsInItems = new EntitySet<MaterialsInItem>(method_3, method_4);
		_Items = new EntitySet<Item>(method_5, method_6);
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

	private void method_0(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.UOM = this;
	}

	private void method_1(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.UOM = null;
	}

	private void method_2(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.UOM1 = this;
	}

	private void rhajkLhHpk(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.UOM1 = null;
	}

	private void method_3(MaterialsInItem materialsInItem_0)
	{
		SendPropertyChanging();
		materialsInItem_0.UOM = this;
	}

	private void method_4(MaterialsInItem materialsInItem_0)
	{
		SendPropertyChanging();
		materialsInItem_0.UOM = null;
	}

	private void method_5(Item item_0)
	{
		SendPropertyChanging();
		item_0.UOM = this;
	}

	private void method_6(Item item_0)
	{
		SendPropertyChanging();
		item_0.UOM = null;
	}

	static UOM()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
