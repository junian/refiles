using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.ItemCustomFieldValue")]
public class ItemCustomFieldValue : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private int _ItemId;

	private short _CustomFieldId;

	private string _Value;

	private bool _Synced;

	private EntityRef<CustomField> _CustomField;

	private EntityRef<Item> _Item;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler fbAoHvHe1;

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

	[Column(Storage = "_ItemId", DbType = "Int NOT NULL")]
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

	[Column(Storage = "_CustomFieldId", DbType = "SmallInt NOT NULL")]
	public short CustomFieldId
	{
		get
		{
			return _CustomFieldId;
		}
		set
		{
			if (_CustomFieldId != value)
			{
				if (_CustomField.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_CustomFieldId = value;
				SendPropertyChanged("CustomFieldId");
			}
		}
	}

	[Column(Storage = "_Value", DbType = "NVarChar(50)")]
	public string Value
	{
		get
		{
			return _Value;
		}
		set
		{
			if (_Value != value)
			{
				SendPropertyChanging();
				_Value = value;
				SendPropertyChanged("Value");
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

	[Association(Name = "CustomField_ItemCustomFieldValue", Storage = "_CustomField", ThisKey = "CustomFieldId", OtherKey = "CustomFieldId", IsForeignKey = true)]
	public CustomField CustomField
	{
		get
		{
			return _CustomField.Entity;
		}
		set
		{
			CustomField entity = _CustomField.Entity;
			if (entity != value || !_CustomField.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_CustomField.Entity = null;
					entity.ItemCustomFieldValues.Remove(this);
				}
				_CustomField.Entity = value;
				if (value != null)
				{
					value.ItemCustomFieldValues.Add(this);
					_CustomFieldId = value.CustomFieldId;
				}
				else
				{
					_CustomFieldId = 0;
				}
				SendPropertyChanged("CustomField");
			}
		}
	}

	[Association(Name = "Item_ItemCustomFieldValue", Storage = "_Item", ThisKey = "ItemId", OtherKey = "ItemID", IsForeignKey = true)]
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
					entity.ItemCustomFieldValues.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.ItemCustomFieldValues.Add(this);
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
			PropertyChangedEventHandler propertyChangedEventHandler = fbAoHvHe1;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref fbAoHvHe1, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = fbAoHvHe1;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref fbAoHvHe1, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public ItemCustomFieldValue()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_CustomField = default(EntityRef<CustomField>);
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
		if (fbAoHvHe1 != null)
		{
			fbAoHvHe1(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static ItemCustomFieldValue()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
