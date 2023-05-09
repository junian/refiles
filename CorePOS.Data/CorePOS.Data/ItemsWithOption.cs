using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.ItemsWithOptions")]
public class ItemsWithOption : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _ItemWithOptionID;

	private int? _ItemID;

	private int? _OptionID;

	private decimal _Price;

	private bool _AllowAdditional;

	private bool _Synced;

	private short _SortOrder;

	private short _GroupID;

	private decimal _Qty;

	private bool _ToBeDeleted;

	private string _Tab;

	private short _MaxGroupOptions;

	private short _MinGroupOptions;

	private string _Color;

	private bool _Preselect;

	private string _GroupOrderTypes;

	private short _GroupDependency;

	private string _OptionDependency;

	private bool _ExcludeFromFreeOption;

	private short _MaxFreeOptionPerGroup;

	private string _Notes;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_ItemWithOptionID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int ItemWithOptionID
	{
		get
		{
			return _ItemWithOptionID;
		}
		set
		{
			if (_ItemWithOptionID != value)
			{
				SendPropertyChanging();
				_ItemWithOptionID = value;
				SendPropertyChanged("ItemWithOptionID");
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
				SendPropertyChanging();
				_ItemID = value;
				SendPropertyChanged("ItemID");
			}
		}
	}

	[Column(Storage = "_OptionID", DbType = "Int")]
	public int? OptionID
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

	[Column(Storage = "_Price", DbType = "Decimal(6,2) NOT NULL")]
	public decimal Price
	{
		get
		{
			return _Price;
		}
		set
		{
			if (_Price != value)
			{
				SendPropertyChanging();
				_Price = value;
				SendPropertyChanged("Price");
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
				SendPropertyChanging();
				_GroupID = value;
				SendPropertyChanged("GroupID");
			}
		}
	}

	[Column(Storage = "_Qty", DbType = "Decimal(4,1) NOT NULL")]
	public decimal Qty
	{
		get
		{
			return _Qty;
		}
		set
		{
			if (_Qty != value)
			{
				SendPropertyChanging();
				_Qty = value;
				SendPropertyChanged("Qty");
			}
		}
	}

	[Column(Storage = "_ToBeDeleted", DbType = "Bit NOT NULL")]
	public bool ToBeDeleted
	{
		get
		{
			return _ToBeDeleted;
		}
		set
		{
			if (_ToBeDeleted != value)
			{
				SendPropertyChanging();
				_ToBeDeleted = value;
				SendPropertyChanged("ToBeDeleted");
			}
		}
	}

	[Column(Storage = "_Tab", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string Tab
	{
		get
		{
			return _Tab;
		}
		set
		{
			if (_Tab != value)
			{
				SendPropertyChanging();
				_Tab = value;
				SendPropertyChanged("Tab");
			}
		}
	}

	[Column(Storage = "_MaxGroupOptions", DbType = "SmallInt NOT NULL")]
	public short MaxGroupOptions
	{
		get
		{
			return _MaxGroupOptions;
		}
		set
		{
			if (_MaxGroupOptions != value)
			{
				SendPropertyChanging();
				_MaxGroupOptions = value;
				SendPropertyChanged("MaxGroupOptions");
			}
		}
	}

	[Column(Storage = "_MinGroupOptions", DbType = "SmallInt NOT NULL")]
	public short MinGroupOptions
	{
		get
		{
			return _MinGroupOptions;
		}
		set
		{
			if (_MinGroupOptions != value)
			{
				SendPropertyChanging();
				_MinGroupOptions = value;
				SendPropertyChanged("MinGroupOptions");
			}
		}
	}

	[Column(Storage = "_Color", DbType = "NVarChar(50)")]
	public string Color
	{
		get
		{
			return _Color;
		}
		set
		{
			if (_Color != value)
			{
				SendPropertyChanging();
				_Color = value;
				SendPropertyChanged("Color");
			}
		}
	}

	[Column(Storage = "_Preselect", DbType = "Bit NOT NULL")]
	public bool Preselect
	{
		get
		{
			return _Preselect;
		}
		set
		{
			if (_Preselect != value)
			{
				SendPropertyChanging();
				_Preselect = value;
				SendPropertyChanged("Preselect");
			}
		}
	}

	[Column(Storage = "_GroupOrderTypes", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string GroupOrderTypes
	{
		get
		{
			return _GroupOrderTypes;
		}
		set
		{
			if (_GroupOrderTypes != value)
			{
				SendPropertyChanging();
				_GroupOrderTypes = value;
				SendPropertyChanged("GroupOrderTypes");
			}
		}
	}

	[Column(Storage = "_GroupDependency", DbType = "SmallInt NOT NULL")]
	public short GroupDependency
	{
		get
		{
			return _GroupDependency;
		}
		set
		{
			if (_GroupDependency != value)
			{
				SendPropertyChanging();
				_GroupDependency = value;
				SendPropertyChanged("GroupDependency");
			}
		}
	}

	[Column(Storage = "_OptionDependency", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string OptionDependency
	{
		get
		{
			return _OptionDependency;
		}
		set
		{
			if (_OptionDependency != value)
			{
				SendPropertyChanging();
				_OptionDependency = value;
				SendPropertyChanged("OptionDependency");
			}
		}
	}

	[Column(Storage = "_ExcludeFromFreeOption", DbType = "Bit NOT NULL")]
	public bool ExcludeFromFreeOption
	{
		get
		{
			return _ExcludeFromFreeOption;
		}
		set
		{
			if (_ExcludeFromFreeOption != value)
			{
				SendPropertyChanging();
				_ExcludeFromFreeOption = value;
				SendPropertyChanged("ExcludeFromFreeOption");
			}
		}
	}

	[Column(Storage = "_MaxFreeOptionPerGroup", DbType = "SmallInt NOT NULL")]
	public short MaxFreeOptionPerGroup
	{
		get
		{
			return _MaxFreeOptionPerGroup;
		}
		set
		{
			if (_MaxFreeOptionPerGroup != value)
			{
				SendPropertyChanging();
				_MaxFreeOptionPerGroup = value;
				SendPropertyChanged("MaxFreeOptionPerGroup");
			}
		}
	}

	[Column(Storage = "_Notes", DbType = "NVarChar(256)")]
	public string Notes
	{
		get
		{
			return _Notes;
		}
		set
		{
			if (_Notes != value)
			{
				SendPropertyChanging();
				_Notes = value;
				SendPropertyChanged("Notes");
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

	public ItemsWithOption()
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

	static ItemsWithOption()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
