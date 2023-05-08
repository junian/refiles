using System.Data.Linq.Mapping;

namespace CorePOS.Data;

public class usp_ItemOptionsResult
{
	private int _ItemWithOptionID;

	private int? _ItemID;

	private int _Option_ItemID;

	private string _Barcode;

	private string _ItemName;

	private string _ItemLongName;

	private bool _ShowOnPatronOrdering;

	private bool _ItemOptionShowOnPatronOrdering;

	private bool? _OptionsGroupShowOrderEntry;

	private short _SortOrder;

	private short _PatronOrderingOptionSortOrder;

	private decimal _SpecialPrice;

	private short _OptionSortOrder;

	private bool _AllowAdditional;

	private string _Tab;

	private short _GroupID;

	private decimal _Qty;

	private short _MaxGroupOptions;

	private short _MinGroupOptions;

	private string _Color;

	private bool _Preselect;

	private string _GroupOrderTypes;

	private short _GroupDependency;

	private string _OptionDependency;

	private bool _ToBeDeleted;

	private short? _GroupSortOrder;

	private bool _ExcludeFromFreeOption;

	private short _MaxFreeOptionPerGroup;

	private string _Notes;

	private string _GroupName;

	[Column(Storage = "_ItemWithOptionID", DbType = "Int NOT NULL")]
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
				_ItemWithOptionID = value;
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
				_ItemID = value;
			}
		}
	}

	[Column(Storage = "_Option_ItemID", DbType = "Int NOT NULL")]
	public int Option_ItemID
	{
		get
		{
			return _Option_ItemID;
		}
		set
		{
			if (_Option_ItemID != value)
			{
				_Option_ItemID = value;
			}
		}
	}

	[Column(Storage = "_Barcode", DbType = "NVarChar(50)")]
	public string Barcode
	{
		get
		{
			return _Barcode;
		}
		set
		{
			if (_Barcode != value)
			{
				_Barcode = value;
			}
		}
	}

	[Column(Storage = "_ItemName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
	public string ItemName
	{
		get
		{
			return _ItemName;
		}
		set
		{
			if (_ItemName != value)
			{
				_ItemName = value;
			}
		}
	}

	[Column(Storage = "_ItemLongName", DbType = "NVarChar(MAX)")]
	public string ItemLongName
	{
		get
		{
			return _ItemLongName;
		}
		set
		{
			if (_ItemLongName != value)
			{
				_ItemLongName = value;
			}
		}
	}

	[Column(Storage = "_ShowOnPatronOrdering", DbType = "Bit NOT NULL")]
	public bool ShowOnPatronOrdering
	{
		get
		{
			return _ShowOnPatronOrdering;
		}
		set
		{
			if (_ShowOnPatronOrdering != value)
			{
				_ShowOnPatronOrdering = value;
			}
		}
	}

	[Column(Storage = "_ItemOptionShowOnPatronOrdering", DbType = "Bit NOT NULL")]
	public bool ItemOptionShowOnPatronOrdering
	{
		get
		{
			return _ItemOptionShowOnPatronOrdering;
		}
		set
		{
			if (_ItemOptionShowOnPatronOrdering != value)
			{
				_ItemOptionShowOnPatronOrdering = value;
			}
		}
	}

	[Column(Storage = "_OptionsGroupShowOrderEntry", DbType = "Bit")]
	public bool? OptionsGroupShowOrderEntry
	{
		get
		{
			return _OptionsGroupShowOrderEntry;
		}
		set
		{
			if (_OptionsGroupShowOrderEntry != value)
			{
				_OptionsGroupShowOrderEntry = value;
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
				_SortOrder = value;
			}
		}
	}

	[Column(Storage = "_PatronOrderingOptionSortOrder", DbType = "SmallInt NOT NULL")]
	public short PatronOrderingOptionSortOrder
	{
		get
		{
			return _PatronOrderingOptionSortOrder;
		}
		set
		{
			if (_PatronOrderingOptionSortOrder != value)
			{
				_PatronOrderingOptionSortOrder = value;
			}
		}
	}

	[Column(Storage = "_SpecialPrice", DbType = "Decimal(6,2) NOT NULL")]
	public decimal SpecialPrice
	{
		get
		{
			return _SpecialPrice;
		}
		set
		{
			if (_SpecialPrice != value)
			{
				_SpecialPrice = value;
			}
		}
	}

	[Column(Storage = "_OptionSortOrder", DbType = "SmallInt NOT NULL")]
	public short OptionSortOrder
	{
		get
		{
			return _OptionSortOrder;
		}
		set
		{
			if (_OptionSortOrder != value)
			{
				_OptionSortOrder = value;
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
				_AllowAdditional = value;
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
				_Tab = value;
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
				_GroupID = value;
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
				_Qty = value;
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
				_MaxGroupOptions = value;
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
				_MinGroupOptions = value;
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
				_Color = value;
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
				_Preselect = value;
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
				_GroupOrderTypes = value;
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
				_GroupDependency = value;
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
				_OptionDependency = value;
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
				_ToBeDeleted = value;
			}
		}
	}

	[Column(Storage = "_GroupSortOrder", DbType = "SmallInt")]
	public short? GroupSortOrder
	{
		get
		{
			return _GroupSortOrder;
		}
		set
		{
			if (_GroupSortOrder != value)
			{
				_GroupSortOrder = value;
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
				_ExcludeFromFreeOption = value;
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
				_MaxFreeOptionPerGroup = value;
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
				_Notes = value;
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
				_GroupName = value;
			}
		}
	}

	public usp_ItemOptionsResult()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
	}
}
