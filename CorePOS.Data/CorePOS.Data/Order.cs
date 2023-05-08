using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Orders")]
public class Order : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private Guid _OrderId;

	private string _OrderNumber;

	private int _SortOrder;

	private string _OrderType;

	private string _Customer;

	private string _RulesDesc;

	private string _DiscountDesc;

	private bool _Paid;

	private bool _Void;

	private string _StationID;

	private int _ItemID;

	private string _ItemName;

	private string _Instructions;

	private decimal _ItemPrice;

	private decimal _Discount;

	private decimal _SubTotal;

	private decimal _TaxTotal;

	private decimal _Total;

	private string _PaymentMethods;

	private DateTime? _DateCreated;

	private DateTime? _DateFilled;

	private DateTime? _DatePaid;

	private short? _UserCreated;

	private short? _UserCancelled;

	private bool _Notified;

	private bool _VoidNotified;

	private short _ComboID;

	private bool _Synced;

	private int? _CustomerID;

	private string _TaxDesc;

	private string _GroupName;

	private decimal _Qty;

	private decimal _ItemCost;

	private decimal _ItemSellPrice;

	private DateTime? _DateRefunded;

	private DateTime? _LastSynced;

	private string _VoidBy;

	private string _Options;

	private string _CustomerInfo;

	private string _DiscountReason;

	private decimal _TenderAmount;

	private decimal _TenderChange;

	private decimal _TipAmount;

	private DateTime? _DateCleared;

	private bool _TipRecorded;

	private string _CustomerInfoName;

	private int _GuestCount;

	private bool _ItemMadeNotified;

	private bool _IsDiscount;

	private string _SeatNum;

	private Guid? _ShareItemID;

	private string _TaxChangeReason;

	private string _TransactionApprovalCode;

	private bool _PrintedInKitchen;

	private int? _TerminalID;

	private int? _InventoryBatchId;

	private string _DiscountReasonItem;

	private decimal _DiscountOnSaleItem;

	private int _OrderOnHoldTime;

	private bool _IsModified;

	private DateTime? _LastDateModified;

	private DateTime? _DateVoided;

	private short _OptionComboId;

	private string _Flag;

	private string _TipShareDesc;

	private string _VoidReason;

	private short? _UserCashout;

	private string _ItemIdentifier;

	private string _OrderTicketNumber;

	private string _ItemCourse;

	private short? _UserServed;

	private DateTime? _FulfillmentAt;

	private string _Source;

	private string _StationMade;

	private int? _ItemOptionId;

	private DateTime? _DateTimeSeated;

	private decimal? _DeliveryTravelDistanceKM;

	private int _DeliveryTravelTimeMinutes;

	private DateTime? _DepartureTime;

	private DateTime? _DeliveryTime;

	private string _OrderNotes;

	private string _StationNotified;

	private string _StationPrinted;

	private bool _CustomerNotified;

	private int? _CreatedByTerminalID;

	private string _CustomerInfoPhone;

	private string _OrderDiscountType;

	private decimal? _OverridePrice;

	private string _TipDesc;

	private string _CustomerInfoEmail;

	private string _SubSource;

	private string _ItemBarcode;

	private byte _FlagID;

	private string _ThirdPartyOrderId;

	private EntitySet<Refund> _Refunds;

	private EntityRef<Terminal> _Terminal;

	private EntityRef<Terminal> _Terminal1;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_OrderId", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
	public Guid OrderId
	{
		get
		{
			return _OrderId;
		}
		set
		{
			if (_OrderId != value)
			{
				SendPropertyChanging();
				_OrderId = value;
				SendPropertyChanged("OrderId");
			}
		}
	}

	[Column(Storage = "_OrderNumber", DbType = "NVarChar(40)")]
	public string OrderNumber
	{
		get
		{
			return _OrderNumber;
		}
		set
		{
			if (_OrderNumber != value)
			{
				SendPropertyChanging();
				_OrderNumber = value;
				SendPropertyChanged("OrderNumber");
			}
		}
	}

	[Column(Storage = "_SortOrder", DbType = "Int NOT NULL")]
	public int SortOrder
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

	[Column(Storage = "_OrderType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string OrderType
	{
		get
		{
			return _OrderType;
		}
		set
		{
			if (_OrderType != value)
			{
				SendPropertyChanging();
				_OrderType = value;
				SendPropertyChanged("OrderType");
			}
		}
	}

	[Column(Storage = "_Customer", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string Customer
	{
		get
		{
			return _Customer;
		}
		set
		{
			if (_Customer != value)
			{
				SendPropertyChanging();
				_Customer = value;
				SendPropertyChanged("Customer");
			}
		}
	}

	[Column(Storage = "_RulesDesc", DbType = "NVarChar(50)")]
	public string RulesDesc
	{
		get
		{
			return _RulesDesc;
		}
		set
		{
			if (_RulesDesc != value)
			{
				SendPropertyChanging();
				_RulesDesc = value;
				SendPropertyChanged("RulesDesc");
			}
		}
	}

	[Column(Storage = "_DiscountDesc", DbType = "NVarChar(512)")]
	public string DiscountDesc
	{
		get
		{
			return _DiscountDesc;
		}
		set
		{
			if (_DiscountDesc != value)
			{
				SendPropertyChanging();
				_DiscountDesc = value;
				SendPropertyChanged("DiscountDesc");
			}
		}
	}

	[Column(Storage = "_Paid", DbType = "Bit NOT NULL")]
	public bool Paid
	{
		get
		{
			return _Paid;
		}
		set
		{
			if (_Paid != value)
			{
				SendPropertyChanging();
				_Paid = value;
				SendPropertyChanged("Paid");
			}
		}
	}

	[Column(Storage = "_Void", DbType = "Bit NOT NULL")]
	public bool Void
	{
		get
		{
			return _Void;
		}
		set
		{
			if (_Void != value)
			{
				SendPropertyChanging();
				_Void = value;
				SendPropertyChanged("Void");
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

	[Column(Storage = "_ItemName", DbType = "NVarChar(256)")]
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

	[Column(Storage = "_Instructions", DbType = "NVarChar(MAX)")]
	public string Instructions
	{
		get
		{
			return _Instructions;
		}
		set
		{
			if (_Instructions != value)
			{
				SendPropertyChanging();
				_Instructions = value;
				SendPropertyChanged("Instructions");
			}
		}
	}

	[Column(Storage = "_ItemPrice", DbType = "Decimal(10,4) NOT NULL")]
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

	[Column(Storage = "_Discount", DbType = "Decimal(10,4) NOT NULL")]
	public decimal Discount
	{
		get
		{
			return _Discount;
		}
		set
		{
			if (_Discount != value)
			{
				SendPropertyChanging();
				_Discount = value;
				SendPropertyChanged("Discount");
			}
		}
	}

	[Column(Storage = "_SubTotal", DbType = "Decimal(10,4) NOT NULL")]
	public decimal SubTotal
	{
		get
		{
			return _SubTotal;
		}
		set
		{
			if (_SubTotal != value)
			{
				SendPropertyChanging();
				_SubTotal = value;
				SendPropertyChanged("SubTotal");
			}
		}
	}

	[Column(Storage = "_TaxTotal", DbType = "Decimal(10,4) NOT NULL")]
	public decimal TaxTotal
	{
		get
		{
			return _TaxTotal;
		}
		set
		{
			if (_TaxTotal != value)
			{
				SendPropertyChanging();
				_TaxTotal = value;
				SendPropertyChanged("TaxTotal");
			}
		}
	}

	[Column(Storage = "_Total", DbType = "Decimal(10,4) NOT NULL")]
	public decimal Total
	{
		get
		{
			return _Total;
		}
		set
		{
			if (_Total != value)
			{
				SendPropertyChanging();
				_Total = value;
				SendPropertyChanged("Total");
			}
		}
	}

	[Column(Storage = "_PaymentMethods", DbType = "NVarChar(2056)")]
	public string PaymentMethods
	{
		get
		{
			return _PaymentMethods;
		}
		set
		{
			if (_PaymentMethods != value)
			{
				SendPropertyChanging();
				_PaymentMethods = value;
				SendPropertyChanged("PaymentMethods");
			}
		}
	}

	[Column(Storage = "_DateCreated", DbType = "DateTime")]
	public DateTime? DateCreated
	{
		get
		{
			return _DateCreated;
		}
		set
		{
			if (_DateCreated != value)
			{
				SendPropertyChanging();
				_DateCreated = value;
				SendPropertyChanged("DateCreated");
			}
		}
	}

	[Column(Storage = "_DateFilled", DbType = "DateTime")]
	public DateTime? DateFilled
	{
		get
		{
			return _DateFilled;
		}
		set
		{
			if (_DateFilled != value)
			{
				SendPropertyChanging();
				_DateFilled = value;
				SendPropertyChanged("DateFilled");
			}
		}
	}

	[Column(Storage = "_DatePaid", DbType = "DateTime")]
	public DateTime? DatePaid
	{
		get
		{
			return _DatePaid;
		}
		set
		{
			if (_DatePaid != value)
			{
				SendPropertyChanging();
				_DatePaid = value;
				SendPropertyChanged("DatePaid");
			}
		}
	}

	[Column(Storage = "_UserCreated", DbType = "SmallInt")]
	public short? UserCreated
	{
		get
		{
			return _UserCreated;
		}
		set
		{
			if (_UserCreated != value)
			{
				SendPropertyChanging();
				_UserCreated = value;
				SendPropertyChanged("UserCreated");
			}
		}
	}

	[Column(Storage = "_UserCancelled", DbType = "SmallInt")]
	public short? UserCancelled
	{
		get
		{
			return _UserCancelled;
		}
		set
		{
			if (_UserCancelled != value)
			{
				SendPropertyChanging();
				_UserCancelled = value;
				SendPropertyChanged("UserCancelled");
			}
		}
	}

	[Column(Storage = "_Notified", DbType = "Bit NOT NULL")]
	public bool Notified
	{
		get
		{
			return _Notified;
		}
		set
		{
			if (_Notified != value)
			{
				SendPropertyChanging();
				_Notified = value;
				SendPropertyChanged("Notified");
			}
		}
	}

	[Column(Storage = "_VoidNotified", DbType = "Bit NOT NULL")]
	public bool VoidNotified
	{
		get
		{
			return _VoidNotified;
		}
		set
		{
			if (_VoidNotified != value)
			{
				SendPropertyChanging();
				_VoidNotified = value;
				SendPropertyChanged("VoidNotified");
			}
		}
	}

	[Column(Storage = "_ComboID", DbType = "SmallInt NOT NULL")]
	public short ComboID
	{
		get
		{
			return _ComboID;
		}
		set
		{
			if (_ComboID != value)
			{
				SendPropertyChanging();
				_ComboID = value;
				SendPropertyChanged("ComboID");
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

	[Column(Storage = "_CustomerID", DbType = "Int")]
	public int? CustomerID
	{
		get
		{
			return _CustomerID;
		}
		set
		{
			if (_CustomerID != value)
			{
				SendPropertyChanging();
				_CustomerID = value;
				SendPropertyChanged("CustomerID");
			}
		}
	}

	[Column(Storage = "_TaxDesc", DbType = "NVarChar(50)")]
	public string TaxDesc
	{
		get
		{
			return _TaxDesc;
		}
		set
		{
			if (_TaxDesc != value)
			{
				SendPropertyChanging();
				_TaxDesc = value;
				SendPropertyChanged("TaxDesc");
			}
		}
	}

	[Column(Storage = "_GroupName", DbType = "NVarChar(100)")]
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

	[Column(Storage = "_Qty", DbType = "Decimal(16,4) NOT NULL")]
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

	[Column(Storage = "_ItemCost", DbType = "Decimal(10,4) NOT NULL")]
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

	[Column(Storage = "_ItemSellPrice", DbType = "Decimal(10,4) NOT NULL")]
	public decimal ItemSellPrice
	{
		get
		{
			return _ItemSellPrice;
		}
		set
		{
			if (_ItemSellPrice != value)
			{
				SendPropertyChanging();
				_ItemSellPrice = value;
				SendPropertyChanged("ItemSellPrice");
			}
		}
	}

	[Column(Storage = "_DateRefunded", DbType = "DateTime")]
	public DateTime? DateRefunded
	{
		get
		{
			return _DateRefunded;
		}
		set
		{
			if (_DateRefunded != value)
			{
				SendPropertyChanging();
				_DateRefunded = value;
				SendPropertyChanged("DateRefunded");
			}
		}
	}

	[Column(Storage = "_LastSynced", DbType = "DateTime")]
	public DateTime? LastSynced
	{
		get
		{
			return _LastSynced;
		}
		set
		{
			if (_LastSynced != value)
			{
				SendPropertyChanging();
				_LastSynced = value;
				SendPropertyChanged("LastSynced");
			}
		}
	}

	[Column(Storage = "_VoidBy", DbType = "NVarChar(100)")]
	public string VoidBy
	{
		get
		{
			return _VoidBy;
		}
		set
		{
			if (_VoidBy != value)
			{
				SendPropertyChanging();
				_VoidBy = value;
				SendPropertyChanged("VoidBy");
			}
		}
	}

	[Column(Storage = "_Options", DbType = "NVarChar(255)")]
	public string Options
	{
		get
		{
			return _Options;
		}
		set
		{
			if (_Options != value)
			{
				SendPropertyChanging();
				_Options = value;
				SendPropertyChanged("Options");
			}
		}
	}

	[Column(Storage = "_CustomerInfo", DbType = "NVarChar(1024)")]
	public string CustomerInfo
	{
		get
		{
			return _CustomerInfo;
		}
		set
		{
			if (_CustomerInfo != value)
			{
				SendPropertyChanging();
				_CustomerInfo = value;
				SendPropertyChanged("CustomerInfo");
			}
		}
	}

	[Column(Storage = "_DiscountReason", DbType = "NVarChar(100)")]
	public string DiscountReason
	{
		get
		{
			return _DiscountReason;
		}
		set
		{
			if (_DiscountReason != value)
			{
				SendPropertyChanging();
				_DiscountReason = value;
				SendPropertyChanged("DiscountReason");
			}
		}
	}

	[Column(Storage = "_TenderAmount", DbType = "Decimal(10,2) NOT NULL")]
	public decimal TenderAmount
	{
		get
		{
			return _TenderAmount;
		}
		set
		{
			if (_TenderAmount != value)
			{
				SendPropertyChanging();
				_TenderAmount = value;
				SendPropertyChanged("TenderAmount");
			}
		}
	}

	[Column(Storage = "_TenderChange", DbType = "Decimal(10,2) NOT NULL")]
	public decimal TenderChange
	{
		get
		{
			return _TenderChange;
		}
		set
		{
			if (_TenderChange != value)
			{
				SendPropertyChanging();
				_TenderChange = value;
				SendPropertyChanged("TenderChange");
			}
		}
	}

	[Column(Storage = "_TipAmount", DbType = "Decimal(10,2) NOT NULL")]
	public decimal TipAmount
	{
		get
		{
			return _TipAmount;
		}
		set
		{
			if (_TipAmount != value)
			{
				SendPropertyChanging();
				_TipAmount = value;
				SendPropertyChanged("TipAmount");
			}
		}
	}

	[Column(Storage = "_DateCleared", DbType = "DateTime")]
	public DateTime? DateCleared
	{
		get
		{
			return _DateCleared;
		}
		set
		{
			if (_DateCleared != value)
			{
				SendPropertyChanging();
				_DateCleared = value;
				SendPropertyChanged("DateCleared");
			}
		}
	}

	[Column(Storage = "_TipRecorded", DbType = "Bit NOT NULL")]
	public bool TipRecorded
	{
		get
		{
			return _TipRecorded;
		}
		set
		{
			if (_TipRecorded != value)
			{
				SendPropertyChanging();
				_TipRecorded = value;
				SendPropertyChanged("TipRecorded");
			}
		}
	}

	[Column(Storage = "_CustomerInfoName", DbType = "NVarChar(64) NOT NULL", CanBeNull = false)]
	public string CustomerInfoName
	{
		get
		{
			return _CustomerInfoName;
		}
		set
		{
			if (_CustomerInfoName != value)
			{
				SendPropertyChanging();
				_CustomerInfoName = value;
				SendPropertyChanged("CustomerInfoName");
			}
		}
	}

	[Column(Storage = "_GuestCount", DbType = "Int NOT NULL")]
	public int GuestCount
	{
		get
		{
			return _GuestCount;
		}
		set
		{
			if (_GuestCount != value)
			{
				SendPropertyChanging();
				_GuestCount = value;
				SendPropertyChanged("GuestCount");
			}
		}
	}

	[Column(Storage = "_ItemMadeNotified", DbType = "Bit NOT NULL")]
	public bool ItemMadeNotified
	{
		get
		{
			return _ItemMadeNotified;
		}
		set
		{
			if (_ItemMadeNotified != value)
			{
				SendPropertyChanging();
				_ItemMadeNotified = value;
				SendPropertyChanged("ItemMadeNotified");
			}
		}
	}

	[Column(Storage = "_IsDiscount", DbType = "Bit NOT NULL")]
	public bool IsDiscount
	{
		get
		{
			return _IsDiscount;
		}
		set
		{
			if (_IsDiscount != value)
			{
				SendPropertyChanging();
				_IsDiscount = value;
				SendPropertyChanged("IsDiscount");
			}
		}
	}

	[Column(Storage = "_SeatNum", DbType = "NVarChar(3) NOT NULL", CanBeNull = false)]
	public string SeatNum
	{
		get
		{
			return _SeatNum;
		}
		set
		{
			if (_SeatNum != value)
			{
				SendPropertyChanging();
				_SeatNum = value;
				SendPropertyChanged("SeatNum");
			}
		}
	}

	[Column(Storage = "_ShareItemID", DbType = "UniqueIdentifier")]
	public Guid? ShareItemID
	{
		get
		{
			return _ShareItemID;
		}
		set
		{
			if (_ShareItemID != value)
			{
				SendPropertyChanging();
				_ShareItemID = value;
				SendPropertyChanged("ShareItemID");
			}
		}
	}

	[Column(Storage = "_TaxChangeReason", DbType = "NVarChar(128)")]
	public string TaxChangeReason
	{
		get
		{
			return _TaxChangeReason;
		}
		set
		{
			if (_TaxChangeReason != value)
			{
				SendPropertyChanging();
				_TaxChangeReason = value;
				SendPropertyChanged("TaxChangeReason");
			}
		}
	}

	[Column(Storage = "_TransactionApprovalCode", DbType = "NVarChar(128)")]
	public string TransactionApprovalCode
	{
		get
		{
			return _TransactionApprovalCode;
		}
		set
		{
			if (_TransactionApprovalCode != value)
			{
				SendPropertyChanging();
				_TransactionApprovalCode = value;
				SendPropertyChanged("TransactionApprovalCode");
			}
		}
	}

	[Column(Storage = "_PrintedInKitchen", DbType = "Bit NOT NULL")]
	public bool PrintedInKitchen
	{
		get
		{
			return _PrintedInKitchen;
		}
		set
		{
			if (_PrintedInKitchen != value)
			{
				SendPropertyChanging();
				_PrintedInKitchen = value;
				SendPropertyChanged("PrintedInKitchen");
			}
		}
	}

	[Column(Storage = "_TerminalID", DbType = "Int")]
	public int? TerminalID
	{
		get
		{
			return _TerminalID;
		}
		set
		{
			if (_TerminalID != value)
			{
				if (_Terminal.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_TerminalID = value;
				SendPropertyChanged("TerminalID");
			}
		}
	}

	[Column(Storage = "_InventoryBatchId", DbType = "Int")]
	public int? InventoryBatchId
	{
		get
		{
			return _InventoryBatchId;
		}
		set
		{
			if (_InventoryBatchId != value)
			{
				SendPropertyChanging();
				_InventoryBatchId = value;
				SendPropertyChanged("InventoryBatchId");
			}
		}
	}

	[Column(Storage = "_DiscountReasonItem", DbType = "NVarChar(100)")]
	public string DiscountReasonItem
	{
		get
		{
			return _DiscountReasonItem;
		}
		set
		{
			if (_DiscountReasonItem != value)
			{
				SendPropertyChanging();
				_DiscountReasonItem = value;
				SendPropertyChanged("DiscountReasonItem");
			}
		}
	}

	[Column(Storage = "_DiscountOnSaleItem", DbType = "Decimal(10,4) NOT NULL")]
	public decimal DiscountOnSaleItem
	{
		get
		{
			return _DiscountOnSaleItem;
		}
		set
		{
			if (_DiscountOnSaleItem != value)
			{
				SendPropertyChanging();
				_DiscountOnSaleItem = value;
				SendPropertyChanged("DiscountOnSaleItem");
			}
		}
	}

	[Column(Storage = "_OrderOnHoldTime", DbType = "Int NOT NULL")]
	public int OrderOnHoldTime
	{
		get
		{
			return _OrderOnHoldTime;
		}
		set
		{
			if (_OrderOnHoldTime != value)
			{
				SendPropertyChanging();
				_OrderOnHoldTime = value;
				SendPropertyChanged("OrderOnHoldTime");
			}
		}
	}

	[Column(Storage = "_IsModified", DbType = "Bit NOT NULL")]
	public bool IsModified
	{
		get
		{
			return _IsModified;
		}
		set
		{
			if (_IsModified != value)
			{
				SendPropertyChanging();
				_IsModified = value;
				SendPropertyChanged("IsModified");
			}
		}
	}

	[Column(Storage = "_LastDateModified", DbType = "DateTime")]
	public DateTime? LastDateModified
	{
		get
		{
			return _LastDateModified;
		}
		set
		{
			if (_LastDateModified != value)
			{
				SendPropertyChanging();
				_LastDateModified = value;
				SendPropertyChanged("LastDateModified");
			}
		}
	}

	[Column(Storage = "_DateVoided", DbType = "DateTime")]
	public DateTime? DateVoided
	{
		get
		{
			return _DateVoided;
		}
		set
		{
			if (_DateVoided != value)
			{
				SendPropertyChanging();
				_DateVoided = value;
				SendPropertyChanged("DateVoided");
			}
		}
	}

	[Column(Storage = "_OptionComboId", DbType = "SmallInt NOT NULL")]
	public short OptionComboId
	{
		get
		{
			return _OptionComboId;
		}
		set
		{
			if (_OptionComboId != value)
			{
				SendPropertyChanging();
				_OptionComboId = value;
				SendPropertyChanged("OptionComboId");
			}
		}
	}

	[Column(Storage = "_Flag", DbType = "NVarChar(128)")]
	public string Flag
	{
		get
		{
			return _Flag;
		}
		set
		{
			if (_Flag != value)
			{
				SendPropertyChanging();
				_Flag = value;
				SendPropertyChanged("Flag");
			}
		}
	}

	[Column(Storage = "_TipShareDesc", DbType = "NVarChar(256)")]
	public string TipShareDesc
	{
		get
		{
			return _TipShareDesc;
		}
		set
		{
			if (_TipShareDesc != value)
			{
				SendPropertyChanging();
				_TipShareDesc = value;
				SendPropertyChanged("TipShareDesc");
			}
		}
	}

	[Column(Storage = "_VoidReason", DbType = "NVarChar(128)")]
	public string VoidReason
	{
		get
		{
			return _VoidReason;
		}
		set
		{
			if (_VoidReason != value)
			{
				SendPropertyChanging();
				_VoidReason = value;
				SendPropertyChanged("VoidReason");
			}
		}
	}

	[Column(Storage = "_UserCashout", DbType = "SmallInt")]
	public short? UserCashout
	{
		get
		{
			return _UserCashout;
		}
		set
		{
			if (_UserCashout != value)
			{
				SendPropertyChanging();
				_UserCashout = value;
				SendPropertyChanged("UserCashout");
			}
		}
	}

	[Column(Storage = "_ItemIdentifier", DbType = "NVarChar(256)")]
	public string ItemIdentifier
	{
		get
		{
			return _ItemIdentifier;
		}
		set
		{
			if (_ItemIdentifier != value)
			{
				SendPropertyChanging();
				_ItemIdentifier = value;
				SendPropertyChanged("ItemIdentifier");
			}
		}
	}

	[Column(Storage = "_OrderTicketNumber", DbType = "NVarChar(50)")]
	public string OrderTicketNumber
	{
		get
		{
			return _OrderTicketNumber;
		}
		set
		{
			if (_OrderTicketNumber != value)
			{
				SendPropertyChanging();
				_OrderTicketNumber = value;
				SendPropertyChanged("OrderTicketNumber");
			}
		}
	}

	[Column(Storage = "_ItemCourse", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
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

	[Column(Storage = "_UserServed", DbType = "SmallInt")]
	public short? UserServed
	{
		get
		{
			return _UserServed;
		}
		set
		{
			if (_UserServed != value)
			{
				SendPropertyChanging();
				_UserServed = value;
				SendPropertyChanged("UserServed");
			}
		}
	}

	[Column(Storage = "_FulfillmentAt", DbType = "DateTime")]
	public DateTime? FulfillmentAt
	{
		get
		{
			return _FulfillmentAt;
		}
		set
		{
			if (_FulfillmentAt != value)
			{
				SendPropertyChanging();
				_FulfillmentAt = value;
				SendPropertyChanged("FulfillmentAt");
			}
		}
	}

	[Column(Storage = "_Source", DbType = "NVarChar(50)")]
	public string Source
	{
		get
		{
			return _Source;
		}
		set
		{
			if (_Source != value)
			{
				SendPropertyChanging();
				_Source = value;
				SendPropertyChanged("Source");
			}
		}
	}

	[Column(Storage = "_StationMade", DbType = "NVarChar(256)")]
	public string StationMade
	{
		get
		{
			return _StationMade;
		}
		set
		{
			if (_StationMade != value)
			{
				SendPropertyChanging();
				_StationMade = value;
				SendPropertyChanged("StationMade");
			}
		}
	}

	[Column(Storage = "_ItemOptionId", DbType = "Int")]
	public int? ItemOptionId
	{
		get
		{
			return _ItemOptionId;
		}
		set
		{
			if (_ItemOptionId != value)
			{
				SendPropertyChanging();
				_ItemOptionId = value;
				SendPropertyChanged("ItemOptionId");
			}
		}
	}

	[Column(Storage = "_DateTimeSeated", DbType = "DateTime")]
	public DateTime? DateTimeSeated
	{
		get
		{
			return _DateTimeSeated;
		}
		set
		{
			if (_DateTimeSeated != value)
			{
				SendPropertyChanging();
				_DateTimeSeated = value;
				SendPropertyChanged("DateTimeSeated");
			}
		}
	}

	[Column(Storage = "_DeliveryTravelDistanceKM", DbType = "Decimal(6,2)")]
	public decimal? DeliveryTravelDistanceKM
	{
		get
		{
			return _DeliveryTravelDistanceKM;
		}
		set
		{
			if (!(_DeliveryTravelDistanceKM == value))
			{
				SendPropertyChanging();
				_DeliveryTravelDistanceKM = value;
				SendPropertyChanged("DeliveryTravelDistanceKM");
			}
		}
	}

	[Column(Storage = "_DeliveryTravelTimeMinutes", DbType = "Int NOT NULL")]
	public int DeliveryTravelTimeMinutes
	{
		get
		{
			return _DeliveryTravelTimeMinutes;
		}
		set
		{
			if (_DeliveryTravelTimeMinutes != value)
			{
				SendPropertyChanging();
				_DeliveryTravelTimeMinutes = value;
				SendPropertyChanged("DeliveryTravelTimeMinutes");
			}
		}
	}

	[Column(Storage = "_DepartureTime", DbType = "DateTime")]
	public DateTime? DepartureTime
	{
		get
		{
			return _DepartureTime;
		}
		set
		{
			if (_DepartureTime != value)
			{
				SendPropertyChanging();
				_DepartureTime = value;
				SendPropertyChanged("DepartureTime");
			}
		}
	}

	[Column(Storage = "_DeliveryTime", DbType = "DateTime")]
	public DateTime? DeliveryTime
	{
		get
		{
			return _DeliveryTime;
		}
		set
		{
			if (_DeliveryTime != value)
			{
				SendPropertyChanging();
				_DeliveryTime = value;
				SendPropertyChanged("DeliveryTime");
			}
		}
	}

	[Column(Storage = "_OrderNotes", DbType = "NVarChar(MAX)")]
	public string OrderNotes
	{
		get
		{
			return _OrderNotes;
		}
		set
		{
			if (_OrderNotes != value)
			{
				SendPropertyChanging();
				_OrderNotes = value;
				SendPropertyChanged("OrderNotes");
			}
		}
	}

	[Column(Storage = "_StationNotified", DbType = "NVarChar(128)")]
	public string StationNotified
	{
		get
		{
			return _StationNotified;
		}
		set
		{
			if (_StationNotified != value)
			{
				SendPropertyChanging();
				_StationNotified = value;
				SendPropertyChanged("StationNotified");
			}
		}
	}

	[Column(Storage = "_StationPrinted", DbType = "NVarChar(128)")]
	public string StationPrinted
	{
		get
		{
			return _StationPrinted;
		}
		set
		{
			if (_StationPrinted != value)
			{
				SendPropertyChanging();
				_StationPrinted = value;
				SendPropertyChanged("StationPrinted");
			}
		}
	}

	[Column(Storage = "_CustomerNotified", DbType = "Bit NOT NULL")]
	public bool CustomerNotified
	{
		get
		{
			return _CustomerNotified;
		}
		set
		{
			if (_CustomerNotified != value)
			{
				SendPropertyChanging();
				_CustomerNotified = value;
				SendPropertyChanged("CustomerNotified");
			}
		}
	}

	[Column(Storage = "_CreatedByTerminalID", DbType = "Int")]
	public int? CreatedByTerminalID
	{
		get
		{
			return _CreatedByTerminalID;
		}
		set
		{
			if (_CreatedByTerminalID != value)
			{
				if (_Terminal1.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_CreatedByTerminalID = value;
				SendPropertyChanged("CreatedByTerminalID");
			}
		}
	}

	[Column(Storage = "_CustomerInfoPhone", DbType = "NVarChar(128)")]
	public string CustomerInfoPhone
	{
		get
		{
			return _CustomerInfoPhone;
		}
		set
		{
			if (_CustomerInfoPhone != value)
			{
				SendPropertyChanging();
				_CustomerInfoPhone = value;
				SendPropertyChanged("CustomerInfoPhone");
			}
		}
	}

	[Column(Storage = "_OrderDiscountType", DbType = "NVarChar(10)")]
	public string OrderDiscountType
	{
		get
		{
			return _OrderDiscountType;
		}
		set
		{
			if (_OrderDiscountType != value)
			{
				SendPropertyChanging();
				_OrderDiscountType = value;
				SendPropertyChanged("OrderDiscountType");
			}
		}
	}

	[Column(Storage = "_OverridePrice", DbType = "Decimal(18,2)")]
	public decimal? OverridePrice
	{
		get
		{
			return _OverridePrice;
		}
		set
		{
			if (!(_OverridePrice == value))
			{
				SendPropertyChanging();
				_OverridePrice = value;
				SendPropertyChanged("OverridePrice");
			}
		}
	}

	[Column(Storage = "_TipDesc", DbType = "NVarChar(128)")]
	public string TipDesc
	{
		get
		{
			return _TipDesc;
		}
		set
		{
			if (_TipDesc != value)
			{
				SendPropertyChanging();
				_TipDesc = value;
				SendPropertyChanged("TipDesc");
			}
		}
	}

	[Column(Storage = "_CustomerInfoEmail", DbType = "NVarChar(128)")]
	public string CustomerInfoEmail
	{
		get
		{
			return _CustomerInfoEmail;
		}
		set
		{
			if (_CustomerInfoEmail != value)
			{
				SendPropertyChanging();
				_CustomerInfoEmail = value;
				SendPropertyChanged("CustomerInfoEmail");
			}
		}
	}

	[Column(Storage = "_SubSource", DbType = "NVarChar(50)")]
	public string SubSource
	{
		get
		{
			return _SubSource;
		}
		set
		{
			if (_SubSource != value)
			{
				SendPropertyChanging();
				_SubSource = value;
				SendPropertyChanged("SubSource");
			}
		}
	}

	[Column(Storage = "_ItemBarcode", DbType = "NVarChar(50)")]
	public string ItemBarcode
	{
		get
		{
			return _ItemBarcode;
		}
		set
		{
			if (_ItemBarcode != value)
			{
				SendPropertyChanging();
				_ItemBarcode = value;
				SendPropertyChanged("ItemBarcode");
			}
		}
	}

	[Column(Storage = "_FlagID", DbType = "TinyInt NOT NULL")]
	public byte FlagID
	{
		get
		{
			return _FlagID;
		}
		set
		{
			if (_FlagID != value)
			{
				SendPropertyChanging();
				_FlagID = value;
				SendPropertyChanged("FlagID");
			}
		}
	}

	[Column(Storage = "_ThirdPartyOrderId", DbType = "NVarChar(128)")]
	public string ThirdPartyOrderId
	{
		get
		{
			return _ThirdPartyOrderId;
		}
		set
		{
			if (_ThirdPartyOrderId != value)
			{
				SendPropertyChanging();
				_ThirdPartyOrderId = value;
				SendPropertyChanged("ThirdPartyOrderId");
			}
		}
	}

	[Association(Name = "Order_Refund", Storage = "_Refunds", ThisKey = "OrderId", OtherKey = "OrderId")]
	public EntitySet<Refund> Refunds
	{
		get
		{
			return _Refunds;
		}
		set
		{
			_Refunds.Assign(value);
		}
	}

	[Association(Name = "Terminal_Order", Storage = "_Terminal", ThisKey = "TerminalID", OtherKey = "TerminalID", IsForeignKey = true)]
	public Terminal Terminal
	{
		get
		{
			return _Terminal.Entity;
		}
		set
		{
			Terminal entity = _Terminal.Entity;
			if (entity != value || !_Terminal.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Terminal.Entity = null;
					entity.Orders.Remove(this);
				}
				_Terminal.Entity = value;
				if (value != null)
				{
					value.Orders.Add(this);
					_TerminalID = value.TerminalID;
				}
				else
				{
					_TerminalID = null;
				}
				SendPropertyChanged("Terminal");
			}
		}
	}

	[Association(Name = "Terminal_Order1", Storage = "_Terminal1", ThisKey = "CreatedByTerminalID", OtherKey = "TerminalID", IsForeignKey = true)]
	public Terminal Terminal1
	{
		get
		{
			return _Terminal1.Entity;
		}
		set
		{
			Terminal entity = _Terminal1.Entity;
			if (entity != value || !_Terminal1.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Terminal1.Entity = null;
					entity.Orders1.Remove(this);
				}
				_Terminal1.Entity = value;
				if (value != null)
				{
					value.Orders1.Add(this);
					_CreatedByTerminalID = value.TerminalID;
				}
				else
				{
					_CreatedByTerminalID = null;
				}
				SendPropertyChanged("Terminal1");
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

	public Order()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Refunds = new EntitySet<Refund>(method_0, method_1);
		_Terminal = default(EntityRef<Terminal>);
		_Terminal1 = default(EntityRef<Terminal>);
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

	private void method_0(Refund refund_0)
	{
		SendPropertyChanging();
		refund_0.Order = this;
	}

	private void method_1(Refund refund_0)
	{
		SendPropertyChanging();
		refund_0.Order = null;
	}

	static Order()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
