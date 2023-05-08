using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.GroupsInItems")]
public class GroupsInItem : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private int _ItemID;

	private short _GroupID;

	private decimal _Quantity;

	private short _SortOrder;

	private bool _Synced;

	private bool _PromptItemOptions;

	private EntityRef<Group> _Group;

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

	[Column(Storage = "_GroupID", DbType = "SmallInt NOT NULL")]
	public short GroupID
	{
		get
		{
			return _GroupID;
		}
		set
		{
			if (_GroupID != value)
			{
				if (_Group.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_GroupID = value;
				SendPropertyChanged("GroupID");
			}
		}
	}

	[Column(Storage = "_Quantity", DbType = "Decimal(18,2) NOT NULL")]
	public decimal Quantity
	{
		get
		{
			return _Quantity;
		}
		set
		{
			if (_Quantity != value)
			{
				SendPropertyChanging();
				_Quantity = value;
				SendPropertyChanged("Quantity");
			}
		}
	}

	[Column(Storage = "_SortOrder", DbType = "SmallInt NOT NULL")]
	public short SortOrder
	{
		get
		{
			return _SortOrder;
		}
		set
		{
			if (_SortOrder != value)
			{
				SendPropertyChanging();
				_SortOrder = value;
				SendPropertyChanged("SortOrder");
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

	[Column(Storage = "_PromptItemOptions", DbType = "Bit NOT NULL")]
	public bool PromptItemOptions
	{
		get
		{
			return _PromptItemOptions;
		}
		set
		{
			if (_PromptItemOptions != value)
			{
				SendPropertyChanging();
				_PromptItemOptions = value;
				SendPropertyChanged("PromptItemOptions");
			}
		}
	}

	[Association(Name = "Group_GroupsInItem", Storage = "_Group", ThisKey = "GroupID", OtherKey = "GroupID", IsForeignKey = true)]
	public Group Group
	{
		get
		{
			return _Group.Entity;
		}
		set
		{
			Group entity = _Group.Entity;
			if (entity != value || !_Group.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Group.Entity = null;
					entity.GroupsInItems.Remove(this);
				}
				_Group.Entity = value;
				if (value != null)
				{
					value.GroupsInItems.Add(this);
					_GroupID = value.GroupID;
				}
				else
				{
					_GroupID = 0;
				}
				SendPropertyChanged("Group");
			}
		}
	}

	[Association(Name = "Item_GroupsInItem", Storage = "_Item", ThisKey = "ItemID", OtherKey = "ItemID", IsForeignKey = true)]
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
					entity.GroupsInItems.Remove(this);
				}
				_Item.Entity = value;
				if (value != null)
				{
					value.GroupsInItems.Add(this);
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

	public GroupsInItem()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Group = default(EntityRef<Group>);
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

	static GroupsInItem()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
