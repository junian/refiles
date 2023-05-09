using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Groups")]
public class Group : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _GroupID;

	private string _GroupName;

	private string _GroupColor;

	private bool _HighTraffic;

	private bool _AllowHalfOrder;

	private bool _Synced;

	private bool _Active;

	private short _ParentGroupID;

	private string _GroupClassification;

	private bool _Archived;

	private int _CloudSyncId;

	private bool _isEcommerce;

	private short _SortOrder;

	private bool _OrderEntryShow;

	private bool _ShowInPatronKiosk;

	private string _Description;

	private EntitySet<ItemsInGroup> _ItemsInGroups;

	private EntitySet<GroupsInItem> _GroupsInItems;

	private EntitySet<GroupImage> _GroupImages;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_GroupID", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
				SendPropertyChanging();
				_GroupID = value;
				SendPropertyChanged("GroupID");
			}
		}
	}

	[Column(Storage = "_GroupName", DbType = "NVarChar(50)")]
	public string GroupName
	{
		get
		{
			return _GroupName;
		}
		set
		{
			if (_GroupName != value)
			{
				SendPropertyChanging();
				_GroupName = value;
				SendPropertyChanged("GroupName");
			}
		}
	}

	[Column(Storage = "_GroupColor", DbType = "NVarChar(50)")]
	public string GroupColor
	{
		get
		{
			return _GroupColor;
		}
		set
		{
			if (_GroupColor != value)
			{
				SendPropertyChanging();
				_GroupColor = value;
				SendPropertyChanged("GroupColor");
			}
		}
	}

	[Column(Storage = "_HighTraffic", DbType = "Bit NOT NULL")]
	public bool HighTraffic
	{
		get
		{
			return _HighTraffic;
		}
		set
		{
			if (_HighTraffic != value)
			{
				SendPropertyChanging();
				_HighTraffic = value;
				SendPropertyChanged("HighTraffic");
			}
		}
	}

	[Column(Storage = "_AllowHalfOrder", DbType = "Bit NOT NULL")]
	public bool AllowHalfOrder
	{
		get
		{
			return _AllowHalfOrder;
		}
		set
		{
			if (_AllowHalfOrder != value)
			{
				SendPropertyChanging();
				_AllowHalfOrder = value;
				SendPropertyChanged("AllowHalfOrder");
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

	[Column(Storage = "_Active", DbType = "Bit NOT NULL")]
	public bool Active
	{
		get
		{
			return _Active;
		}
		set
		{
			if (_Active != value)
			{
				SendPropertyChanging();
				_Active = value;
				SendPropertyChanged("Active");
			}
		}
	}

	[Column(Storage = "_ParentGroupID", DbType = "SmallInt NOT NULL")]
	public short ParentGroupID
	{
		get
		{
			return _ParentGroupID;
		}
		set
		{
			if (_ParentGroupID != value)
			{
				SendPropertyChanging();
				_ParentGroupID = value;
				SendPropertyChanged("ParentGroupID");
			}
		}
	}

	[Column(Storage = "_GroupClassification", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string GroupClassification
	{
		get
		{
			return _GroupClassification;
		}
		set
		{
			if (_GroupClassification != value)
			{
				SendPropertyChanging();
				_GroupClassification = value;
				SendPropertyChanged("GroupClassification");
			}
		}
	}

	[Column(Storage = "_Archived", DbType = "Bit NOT NULL")]
	public bool Archived
	{
		get
		{
			return _Archived;
		}
		set
		{
			if (_Archived != value)
			{
				SendPropertyChanging();
				_Archived = value;
				SendPropertyChanged("Archived");
			}
		}
	}

	[Column(Storage = "_CloudSyncId", DbType = "Int NOT NULL")]
	public int CloudSyncId
	{
		get
		{
			return _CloudSyncId;
		}
		set
		{
			if (_CloudSyncId != value)
			{
				SendPropertyChanging();
				_CloudSyncId = value;
				SendPropertyChanged("CloudSyncId");
			}
		}
	}

	[Column(Storage = "_isEcommerce", DbType = "Bit NOT NULL")]
	public bool isEcommerce
	{
		get
		{
			return _isEcommerce;
		}
		set
		{
			if (_isEcommerce != value)
			{
				SendPropertyChanging();
				_isEcommerce = value;
				SendPropertyChanged("isEcommerce");
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

	[Column(Storage = "_OrderEntryShow", DbType = "Bit NOT NULL")]
	public bool OrderEntryShow
	{
		get
		{
			return _OrderEntryShow;
		}
		set
		{
			if (_OrderEntryShow != value)
			{
				SendPropertyChanging();
				_OrderEntryShow = value;
				SendPropertyChanged("OrderEntryShow");
			}
		}
	}

	[Column(Storage = "_ShowInPatronKiosk", DbType = "Bit NOT NULL")]
	public bool ShowInPatronKiosk
	{
		get
		{
			return _ShowInPatronKiosk;
		}
		set
		{
			if (_ShowInPatronKiosk != value)
			{
				SendPropertyChanging();
				_ShowInPatronKiosk = value;
				SendPropertyChanged("ShowInPatronKiosk");
			}
		}
	}

	[Column(Storage = "_Description", DbType = "NVarChar(MAX)")]
	public string Description
	{
		get
		{
			return _Description;
		}
		set
		{
			if (_Description != value)
			{
				SendPropertyChanging();
				_Description = value;
				SendPropertyChanged("Description");
			}
		}
	}

	[Association(Name = "Group_ItemsInGroup", Storage = "_ItemsInGroups", ThisKey = "GroupID", OtherKey = "GroupID")]
	public EntitySet<ItemsInGroup> ItemsInGroups
	{
		get
		{
			return _ItemsInGroups;
		}
		set
		{
			_ItemsInGroups.Assign(value);
		}
	}

	[Association(Name = "Group_GroupsInItem", Storage = "_GroupsInItems", ThisKey = "GroupID", OtherKey = "GroupID")]
	public EntitySet<GroupsInItem> GroupsInItems
	{
		get
		{
			return _GroupsInItems;
		}
		set
		{
			_GroupsInItems.Assign(value);
		}
	}

	[Association(Name = "Group_GroupImage", Storage = "_GroupImages", ThisKey = "GroupID", OtherKey = "GroupID")]
	public EntitySet<GroupImage> GroupImages
	{
		get
		{
			return _GroupImages;
		}
		set
		{
			_GroupImages.Assign(value);
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

	public Group()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_ItemsInGroups = new EntitySet<ItemsInGroup>(method_0, method_1);
		_GroupsInItems = new EntitySet<GroupsInItem>(method_2, method_3);
		_GroupImages = new EntitySet<GroupImage>(method_4, method_5);
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

	private void method_0(ItemsInGroup itemsInGroup_0)
	{
		SendPropertyChanging();
		itemsInGroup_0.Group = this;
	}

	private void method_1(ItemsInGroup itemsInGroup_0)
	{
		SendPropertyChanging();
		itemsInGroup_0.Group = null;
	}

	private void method_2(GroupsInItem groupsInItem_0)
	{
		SendPropertyChanging();
		groupsInItem_0.Group = this;
	}

	private void method_3(GroupsInItem groupsInItem_0)
	{
		SendPropertyChanging();
		groupsInItem_0.Group = null;
	}

	private void method_4(GroupImage groupImage_0)
	{
		SendPropertyChanging();
		groupImage_0.Group = this;
	}

	private void method_5(GroupImage groupImage_0)
	{
		SendPropertyChanging();
		groupImage_0.Group = null;
	}

	static Group()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
