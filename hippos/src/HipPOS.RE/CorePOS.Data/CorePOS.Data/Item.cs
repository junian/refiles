using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Items")]
public class Item : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs onpsgraCdP;

	private int _ItemID;

	private string _ItemName;

	private decimal _ItemPrice;

	private bool _Taxable;

	private string _StationID;

	private short _SortOrder;

	private string _ItemColor;

	private bool _AllowCustomPrice;

	private bool _AllowEditDescription;

	private bool _Synced;

	private bool _TrackInventory;

	private DateTime? _StartDateOnSale;

	private DateTime? _EndDateOnSale;

	private bool _DisableSoldOutItems;

	private decimal _ItemCost;

	private int _ItemTypeID;

	private decimal? _ItemSalePrice;

	private bool _OnSale;

	private int _TaxRuleID;

	private bool _Active;

	private string _Barcode;

	private bool _AllowProRated;

	private decimal _InventoryCount;

	private short _UOMID;

	private string _Temp;

	private string _Description;

	private long _CloudItemID;

	private DateTime? _StartTimeOnSale;

	private DateTime? _EndTimeOnSale;

	private string _ItemClassification;

	private string _DaysSaleList;

	private bool _isDeleted;

	private string _Notes;

	private string _ItemCourse;

	private int _MaxFreeOptions;

	private bool _TrackExpiryDate;

	private int _MinFreeOptions;

	private bool _ApplySaleComboOption;

	private bool _AutoResetQty;

	private decimal _ResetQty;

	private bool _LoyaltyRedemption;

	private string _ItemLongName;

	private bool _UseSmartBarcode;

	private bool _AutoPromptOptions;

	private decimal _BatchStockQty;

	private bool _TaxesIncluded;

	private bool _ShowOnPatronOrdering;

	private DateTime? _LastGoodInventoryReconciledDate;

	private decimal? _ReorderQty;

	private decimal _ReOrderLimit;

	private EntitySet<ItemCustomFieldValue> _ItemCustomFieldValues;

	private EntitySet<ItemsInGroup> _ItemsInGroups;

	private EntitySet<ItemAuditLog> _ItemAuditLogs;

	private EntitySet<Option> _Options;

	private EntitySet<GClass7> _UOMUnitsConversions;

	private EntitySet<GroupsInItem> _GroupsInItems;

	private EntitySet<InventoryBatch> _InventoryBatches;

	private EntitySet<ItemImage> _ItemImages;

	private EntitySet<ItemsSupplier> _ItemsSuppliers;

	private EntityRef<ItemType> _ItemType;

	private EntityRef<TaxRule> _TaxRule;

	private EntityRef<UOM> _UOM;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_ItemID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
				SendPropertyChanging();
				_ItemName = value;
				SendPropertyChanged("ItemName");
			}
		}
	}

	[Column(Storage = "_ItemPrice", DbType = "Decimal(18,4) NOT NULL")]
	public decimal ItemPrice
	{
		get
		{
			return _ItemPrice;
		}
		set
		{
			if (_ItemPrice != value)
			{
				SendPropertyChanging();
				_ItemPrice = value;
				SendPropertyChanged("ItemPrice");
			}
		}
	}

	[Column(Storage = "_Taxable", DbType = "Bit NOT NULL")]
	public bool Taxable
	{
		get
		{
			return _Taxable;
		}
		set
		{
			if (_Taxable != value)
			{
				SendPropertyChanging();
				_Taxable = value;
				SendPropertyChanged("Taxable");
			}
		}
	}

	[Column(Storage = "_StationID", DbType = "NVarChar(256)")]
	public string StationID
	{
		get
		{
			return _StationID;
		}
		set
		{
			if (_StationID != value)
			{
				SendPropertyChanging();
				_StationID = value;
				SendPropertyChanged("StationID");
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

	[Column(Storage = "_ItemColor", DbType = "NVarChar(50)")]
	public string ItemColor
	{
		get
		{
			return _ItemColor;
		}
		set
		{
			if (_ItemColor != value)
			{
				SendPropertyChanging();
				_ItemColor = value;
				SendPropertyChanged("ItemColor");
			}
		}
	}

	[Column(Storage = "_AllowCustomPrice", DbType = "Bit NOT NULL")]
	public bool AllowCustomPrice
	{
		get
		{
			return _AllowCustomPrice;
		}
		set
		{
			if (_AllowCustomPrice != value)
			{
				SendPropertyChanging();
				_AllowCustomPrice = value;
				SendPropertyChanged("AllowCustomPrice");
			}
		}
	}

	[Column(Storage = "_AllowEditDescription", DbType = "Bit NOT NULL")]
	public bool AllowEditDescription
	{
		get
		{
			return _AllowEditDescription;
		}
		set
		{
			if (_AllowEditDescription != value)
			{
				SendPropertyChanging();
				_AllowEditDescription = value;
				SendPropertyChanged("AllowEditDescription");
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

	[Column(Storage = "_TrackInventory", DbType = "Bit NOT NULL")]
	public bool TrackInventory
	{
		get
		{
			return _TrackInventory;
		}
		set
		{
			if (_TrackInventory != value)
			{
				SendPropertyChanging();
				_TrackInventory = value;
				SendPropertyChanged("TrackInventory");
			}
		}
	}

	[Column(Storage = "_StartDateOnSale", DbType = "DateTime")]
	public DateTime? StartDateOnSale
	{
		get
		{
			return _StartDateOnSale;
		}
		set
		{
			if (_StartDateOnSale != value)
			{
				SendPropertyChanging();
				_StartDateOnSale = value;
				SendPropertyChanged("StartDateOnSale");
			}
		}
	}

	[Column(Storage = "_EndDateOnSale", DbType = "DateTime")]
	public DateTime? EndDateOnSale
	{
		get
		{
			return _EndDateOnSale;
		}
		set
		{
			if (_EndDateOnSale != value)
			{
				SendPropertyChanging();
				_EndDateOnSale = value;
				SendPropertyChanged("EndDateOnSale");
			}
		}
	}

	[Column(Storage = "_DisableSoldOutItems", DbType = "Bit NOT NULL")]
	public bool DisableSoldOutItems
	{
		get
		{
			return _DisableSoldOutItems;
		}
		set
		{
			if (_DisableSoldOutItems != value)
			{
				SendPropertyChanging();
				_DisableSoldOutItems = value;
				SendPropertyChanged("DisableSoldOutItems");
			}
		}
	}

	[Column(Storage = "_ItemCost", DbType = "Decimal(18,4) NOT NULL")]
	public decimal ItemCost
	{
		get
		{
			return _ItemCost;
		}
		set
		{
			if (_ItemCost != value)
			{
				SendPropertyChanging();
				_ItemCost = value;
				SendPropertyChanged("ItemCost");
			}
		}
	}

	[Column(Storage = "_ItemTypeID", DbType = "Int NOT NULL")]
	public int ItemTypeID
	{
		get
		{
			return _ItemTypeID;
		}
		set
		{
			if (_ItemTypeID != value)
			{
				if (_ItemType.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ItemTypeID = value;
				SendPropertyChanged("ItemTypeID");
			}
		}
	}

	[Column(Storage = "_ItemSalePrice", DbType = "Decimal(18,4)")]
	public decimal? ItemSalePrice
	{
		get
		{
			return _ItemSalePrice;
		}
		set
		{
			if (!(_ItemSalePrice == value))
			{
				SendPropertyChanging();
				_ItemSalePrice = value;
				SendPropertyChanged("ItemSalePrice");
			}
		}
	}

	[Column(Storage = "_OnSale", DbType = "Bit NOT NULL")]
	public bool OnSale
	{
		get
		{
			return _OnSale;
		}
		set
		{
			if (_OnSale != value)
			{
				SendPropertyChanging();
				_OnSale = value;
				SendPropertyChanged("OnSale");
			}
		}
	}

	[Column(Storage = "_TaxRuleID", DbType = "Int NOT NULL")]
	public int TaxRuleID
	{
		get
		{
			return _TaxRuleID;
		}
		set
		{
			if (_TaxRuleID != value)
			{
				if (_TaxRule.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_TaxRuleID = value;
				SendPropertyChanged("TaxRuleID");
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
				SendPropertyChanging();
				_Barcode = value;
				SendPropertyChanged("Barcode");
			}
		}
	}

	[Column(Storage = "_AllowProRated", DbType = "Bit NOT NULL")]
	public bool AllowProRated
	{
		get
		{
			return _AllowProRated;
		}
		set
		{
			if (_AllowProRated != value)
			{
				SendPropertyChanging();
				_AllowProRated = value;
				SendPropertyChanged("AllowProRated");
			}
		}
	}

	[Column(Storage = "_InventoryCount", DbType = "Decimal(18,4) NOT NULL")]
	public decimal InventoryCount
	{
		get
		{
			return _InventoryCount;
		}
		set
		{
			if (_InventoryCount != value)
			{
				SendPropertyChanging();
				_InventoryCount = value;
				SendPropertyChanged("InventoryCount");
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

	[Column(Storage = "_Temp", DbType = "NVarChar(128)")]
	public string Temp
	{
		get
		{
			return _Temp;
		}
		set
		{
			if (_Temp != value)
			{
				SendPropertyChanging();
				_Temp = value;
				SendPropertyChanged("Temp");
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

	[Column(Storage = "_CloudItemID", DbType = "BigInt NOT NULL")]
	public long CloudItemID
	{
		get
		{
			return _CloudItemID;
		}
		set
		{
			if (_CloudItemID != value)
			{
				SendPropertyChanging();
				_CloudItemID = value;
				SendPropertyChanged("CloudItemID");
			}
		}
	}

	[Column(Storage = "_StartTimeOnSale", DbType = "DateTime")]
	public DateTime? StartTimeOnSale
	{
		get
		{
			return _StartTimeOnSale;
		}
		set
		{
			if (_StartTimeOnSale != value)
			{
				SendPropertyChanging();
				_StartTimeOnSale = value;
				SendPropertyChanged("StartTimeOnSale");
			}
		}
	}

	[Column(Storage = "_EndTimeOnSale", DbType = "DateTime")]
	public DateTime? EndTimeOnSale
	{
		get
		{
			return _EndTimeOnSale;
		}
		set
		{
			if (_EndTimeOnSale != value)
			{
				SendPropertyChanging();
				_EndTimeOnSale = value;
				SendPropertyChanged("EndTimeOnSale");
			}
		}
	}

	[Column(Storage = "_ItemClassification", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string ItemClassification
	{
		get
		{
			return _ItemClassification;
		}
		set
		{
			if (_ItemClassification != value)
			{
				SendPropertyChanging();
				_ItemClassification = value;
				SendPropertyChanged("ItemClassification");
			}
		}
	}

	[Column(Storage = "_DaysSaleList", DbType = "NVarChar(512)")]
	public string DaysSaleList
	{
		get
		{
			return _DaysSaleList;
		}
		set
		{
			if (_DaysSaleList != value)
			{
				SendPropertyChanging();
				_DaysSaleList = value;
				SendPropertyChanged("DaysSaleList");
			}
		}
	}

	[Column(Storage = "_isDeleted", DbType = "Bit NOT NULL")]
	public bool isDeleted
	{
		get
		{
			return _isDeleted;
		}
		set
		{
			if (_isDeleted != value)
			{
				SendPropertyChanging();
				_isDeleted = value;
				SendPropertyChanged("isDeleted");
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

	[Column(Storage = "_ItemCourse", DbType = "NVarChar(48) NOT NULL", CanBeNull = false)]
	public string ItemCourse
	{
		get
		{
			return _ItemCourse;
		}
		set
		{
			if (_ItemCourse != value)
			{
				SendPropertyChanging();
				_ItemCourse = value;
				SendPropertyChanged("ItemCourse");
			}
		}
	}

	[Column(Storage = "_MaxFreeOptions", DbType = "Int NOT NULL")]
	public int MaxFreeOptions
	{
		get
		{
			return _MaxFreeOptions;
		}
		set
		{
			if (_MaxFreeOptions != value)
			{
				SendPropertyChanging();
				_MaxFreeOptions = value;
				SendPropertyChanged("MaxFreeOptions");
			}
		}
	}

	[Column(Storage = "_TrackExpiryDate", DbType = "Bit NOT NULL")]
	public bool TrackExpiryDate
	{
		get
		{
			return _TrackExpiryDate;
		}
		set
		{
			if (_TrackExpiryDate != value)
			{
				SendPropertyChanging();
				_TrackExpiryDate = value;
				SendPropertyChanged("TrackExpiryDate");
			}
		}
	}

	[Column(Storage = "_MinFreeOptions", DbType = "Int NOT NULL")]
	public int MinFreeOptions
	{
		get
		{
			return _MinFreeOptions;
		}
		set
		{
			if (_MinFreeOptions != value)
			{
				SendPropertyChanging();
				_MinFreeOptions = value;
				SendPropertyChanged("MinFreeOptions");
			}
		}
	}

	[Column(Storage = "_ApplySaleComboOption", DbType = "Bit NOT NULL")]
	public bool ApplySaleComboOption
	{
		get
		{
			return _ApplySaleComboOption;
		}
		set
		{
			if (_ApplySaleComboOption != value)
			{
				SendPropertyChanging();
				_ApplySaleComboOption = value;
				SendPropertyChanged("ApplySaleComboOption");
			}
		}
	}

	[Column(Storage = "_AutoResetQty", DbType = "Bit NOT NULL")]
	public bool AutoResetQty
	{
		get
		{
			return _AutoResetQty;
		}
		set
		{
			if (_AutoResetQty != value)
			{
				SendPropertyChanging();
				_AutoResetQty = value;
				SendPropertyChanged("AutoResetQty");
			}
		}
	}

	[Column(Storage = "_ResetQty", DbType = "Decimal(18,4) NOT NULL")]
	public decimal ResetQty
	{
		get
		{
			return _ResetQty;
		}
		set
		{
			if (_ResetQty != value)
			{
				SendPropertyChanging();
				_ResetQty = value;
				SendPropertyChanged("ResetQty");
			}
		}
	}

	[Column(Storage = "_LoyaltyRedemption", DbType = "Bit NOT NULL")]
	public bool LoyaltyRedemption
	{
		get
		{
			return _LoyaltyRedemption;
		}
		set
		{
			if (_LoyaltyRedemption != value)
			{
				SendPropertyChanging();
				_LoyaltyRedemption = value;
				SendPropertyChanged("LoyaltyRedemption");
			}
		}
	}

	[Column(Storage = "_ItemLongName", DbType = "NVarChar(255)")]
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
				SendPropertyChanging();
				_ItemLongName = value;
				SendPropertyChanged("ItemLongName");
			}
		}
	}

	[Column(Storage = "_UseSmartBarcode", DbType = "Bit NOT NULL")]
	public bool UseSmartBarcode
	{
		get
		{
			return _UseSmartBarcode;
		}
		set
		{
			if (_UseSmartBarcode != value)
			{
				SendPropertyChanging();
				_UseSmartBarcode = value;
				SendPropertyChanged("UseSmartBarcode");
			}
		}
	}

	[Column(Storage = "_AutoPromptOptions", DbType = "Bit NOT NULL")]
	public bool AutoPromptOptions
	{
		get
		{
			return _AutoPromptOptions;
		}
		set
		{
			if (_AutoPromptOptions != value)
			{
				SendPropertyChanging();
				_AutoPromptOptions = value;
				SendPropertyChanged("AutoPromptOptions");
			}
		}
	}

	[Column(Storage = "_BatchStockQty", DbType = "Decimal(18,4) NOT NULL")]
	public decimal BatchStockQty
	{
		get
		{
			return _BatchStockQty;
		}
		set
		{
			if (_BatchStockQty != value)
			{
				SendPropertyChanging();
				_BatchStockQty = value;
				SendPropertyChanged("BatchStockQty");
			}
		}
	}

	[Column(Storage = "_TaxesIncluded", DbType = "Bit NOT NULL")]
	public bool TaxesIncluded
	{
		get
		{
			return _TaxesIncluded;
		}
		set
		{
			if (_TaxesIncluded != value)
			{
				SendPropertyChanging();
				_TaxesIncluded = value;
				SendPropertyChanged("TaxesIncluded");
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
				SendPropertyChanging();
				_ShowOnPatronOrdering = value;
				SendPropertyChanged("ShowOnPatronOrdering");
			}
		}
	}

	[Column(Storage = "_LastGoodInventoryReconciledDate", DbType = "DateTime")]
	public DateTime? LastGoodInventoryReconciledDate
	{
		get
		{
			return _LastGoodInventoryReconciledDate;
		}
		set
		{
			if (_LastGoodInventoryReconciledDate != value)
			{
				SendPropertyChanging();
				_LastGoodInventoryReconciledDate = value;
				SendPropertyChanged("LastGoodInventoryReconciledDate");
			}
		}
	}

	[Column(Storage = "_ReorderQty", DbType = "Decimal(18,2)")]
	public decimal? ReorderQty
	{
		get
		{
			return _ReorderQty;
		}
		set
		{
			if (!(_ReorderQty == value))
			{
				SendPropertyChanging();
				_ReorderQty = value;
				SendPropertyChanged("ReorderQty");
			}
		}
	}

	[Column(Storage = "_ReOrderLimit", DbType = "Decimal(18,2) NOT NULL")]
	public decimal ReOrderLimit
	{
		get
		{
			return _ReOrderLimit;
		}
		set
		{
			if (_ReOrderLimit != value)
			{
				SendPropertyChanging();
				_ReOrderLimit = value;
				SendPropertyChanged("ReOrderLimit");
			}
		}
	}

	[Association(Name = "Item_ItemCustomFieldValue", Storage = "_ItemCustomFieldValues", ThisKey = "ItemID", OtherKey = "ItemId")]
	public EntitySet<ItemCustomFieldValue> ItemCustomFieldValues
	{
		get
		{
			return _ItemCustomFieldValues;
		}
		set
		{
			_ItemCustomFieldValues.Assign(value);
		}
	}

	[Association(Name = "Item_ItemsInGroup", Storage = "_ItemsInGroups", ThisKey = "ItemID", OtherKey = "ItemID")]
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

	[Association(Name = "Item_ItemAuditLog", Storage = "_ItemAuditLogs", ThisKey = "ItemID", OtherKey = "ItemID")]
	public EntitySet<ItemAuditLog> ItemAuditLogs
	{
		get
		{
			return _ItemAuditLogs;
		}
		set
		{
			_ItemAuditLogs.Assign(value);
		}
	}

	[Association(Name = "Item_Option", Storage = "_Options", ThisKey = "ItemID", OtherKey = "ItemID")]
	public EntitySet<Option> Options
	{
		get
		{
			return _Options;
		}
		set
		{
			_Options.Assign(value);
		}
	}

	[Association(Name = "Item_UOMUnitsConversion", Storage = "_UOMUnitsConversions", ThisKey = "ItemID", OtherKey = "ItemID")]
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

	[Association(Name = "Item_GroupsInItem", Storage = "_GroupsInItems", ThisKey = "ItemID", OtherKey = "ItemID")]
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

	[Association(Name = "Item_InventoryBatch", Storage = "_InventoryBatches", ThisKey = "ItemID", OtherKey = "ItemID")]
	public EntitySet<InventoryBatch> InventoryBatches
	{
		get
		{
			return _InventoryBatches;
		}
		set
		{
			_InventoryBatches.Assign(value);
		}
	}

	[Association(Name = "Item_ItemImage", Storage = "_ItemImages", ThisKey = "ItemID", OtherKey = "ItemID")]
	public EntitySet<ItemImage> ItemImages
	{
		get
		{
			return _ItemImages;
		}
		set
		{
			_ItemImages.Assign(value);
		}
	}

	[Association(Name = "Item_ItemsSupplier", Storage = "_ItemsSuppliers", ThisKey = "ItemID", OtherKey = "ItemId")]
	public EntitySet<ItemsSupplier> ItemsSuppliers
	{
		get
		{
			return _ItemsSuppliers;
		}
		set
		{
			_ItemsSuppliers.Assign(value);
		}
	}

	[Association(Name = "ItemType_Item", Storage = "_ItemType", ThisKey = "ItemTypeID", OtherKey = "ItemTypeID", IsForeignKey = true)]
	public ItemType ItemType
	{
		get
		{
			return _ItemType.Entity;
		}
		set
		{
			ItemType entity = _ItemType.Entity;
			if (entity != value || !_ItemType.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_ItemType.Entity = null;
					entity.Items.Remove(this);
				}
				_ItemType.Entity = value;
				if (value != null)
				{
					value.Items.Add(this);
					_ItemTypeID = value.ItemTypeID;
				}
				else
				{
					_ItemTypeID = 0;
				}
				SendPropertyChanged("ItemType");
			}
		}
	}

	[Association(Name = "TaxRule_Item", Storage = "_TaxRule", ThisKey = "TaxRuleID", OtherKey = "TaxRuleId", IsForeignKey = true)]
	public TaxRule TaxRule
	{
		get
		{
			return _TaxRule.Entity;
		}
		set
		{
			TaxRule entity = _TaxRule.Entity;
			if (entity != value || !_TaxRule.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_TaxRule.Entity = null;
					entity.Items.Remove(this);
				}
				_TaxRule.Entity = value;
				if (value != null)
				{
					value.Items.Add(this);
					_TaxRuleID = value.TaxRuleId;
				}
				else
				{
					_TaxRuleID = 0;
				}
				SendPropertyChanged("TaxRule");
			}
		}
	}

	[Association(Name = "UOM_Item", Storage = "_UOM", ThisKey = "UOMID", OtherKey = "UOMID", IsForeignKey = true)]
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
					entity.Items.Remove(this);
				}
				_UOM.Entity = value;
				if (value != null)
				{
					value.Items.Add(this);
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

	public Item()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_ItemCustomFieldValues = new EntitySet<ItemCustomFieldValue>(method_0, method_1);
		_ItemsInGroups = new EntitySet<ItemsInGroup>(method_2, method_3);
		_ItemAuditLogs = new EntitySet<ItemAuditLog>(method_4, method_5);
		_Options = new EntitySet<Option>(method_6, method_7);
		_UOMUnitsConversions = new EntitySet<GClass7>(method_8, method_9);
		_GroupsInItems = new EntitySet<GroupsInItem>(method_10, method_11);
		_InventoryBatches = new EntitySet<InventoryBatch>(method_12, method_13);
		_ItemImages = new EntitySet<ItemImage>(method_14, method_15);
		_ItemsSuppliers = new EntitySet<ItemsSupplier>(method_16, method_17);
		_ItemType = default(EntityRef<ItemType>);
		_TaxRule = default(EntityRef<TaxRule>);
		_UOM = default(EntityRef<UOM>);
	}

	protected virtual void SendPropertyChanging()
	{
		if (propertyChangingEventHandler_0 != null)
		{
			propertyChangingEventHandler_0(this, onpsgraCdP);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void method_0(ItemCustomFieldValue itemCustomFieldValue_0)
	{
		SendPropertyChanging();
		itemCustomFieldValue_0.Item = this;
	}

	private void method_1(ItemCustomFieldValue itemCustomFieldValue_0)
	{
		SendPropertyChanging();
		itemCustomFieldValue_0.Item = null;
	}

	private void method_2(ItemsInGroup itemsInGroup_0)
	{
		SendPropertyChanging();
		itemsInGroup_0.Item = this;
	}

	private void method_3(ItemsInGroup itemsInGroup_0)
	{
		SendPropertyChanging();
		itemsInGroup_0.Item = null;
	}

	private void method_4(ItemAuditLog itemAuditLog_0)
	{
		SendPropertyChanging();
		itemAuditLog_0.Item = this;
	}

	private void method_5(ItemAuditLog itemAuditLog_0)
	{
		SendPropertyChanging();
		itemAuditLog_0.Item = null;
	}

	private void method_6(Option option_0)
	{
		SendPropertyChanging();
		option_0.Item = this;
	}

	private void method_7(Option option_0)
	{
		SendPropertyChanging();
		option_0.Item = null;
	}

	private void method_8(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.Item = this;
	}

	private void method_9(GClass7 gclass7_0)
	{
		SendPropertyChanging();
		gclass7_0.Item = null;
	}

	private void method_10(GroupsInItem groupsInItem_0)
	{
		SendPropertyChanging();
		groupsInItem_0.Item = this;
	}

	private void method_11(GroupsInItem groupsInItem_0)
	{
		SendPropertyChanging();
		groupsInItem_0.Item = null;
	}

	private void method_12(InventoryBatch inventoryBatch_0)
	{
		SendPropertyChanging();
		inventoryBatch_0.Item = this;
	}

	private void method_13(InventoryBatch inventoryBatch_0)
	{
		SendPropertyChanging();
		inventoryBatch_0.Item = null;
	}

	private void method_14(ItemImage itemImage_0)
	{
		SendPropertyChanging();
		itemImage_0.Item = this;
	}

	private void method_15(ItemImage itemImage_0)
	{
		SendPropertyChanging();
		itemImage_0.Item = null;
	}

	private void method_16(ItemsSupplier itemsSupplier_0)
	{
		SendPropertyChanging();
		itemsSupplier_0.Item = this;
	}

	private void method_17(ItemsSupplier itemsSupplier_0)
	{
		SendPropertyChanging();
		itemsSupplier_0.Item = null;
	}

	static Item()
	{
		Class5.qrSRKAOzgGGAb();
		onpsgraCdP = new PropertyChangingEventArgs(string.Empty);
	}
}
