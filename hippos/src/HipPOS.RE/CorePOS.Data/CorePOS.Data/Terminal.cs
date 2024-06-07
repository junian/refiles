using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Terminals")]
public class Terminal : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs OunjFyYvQE;

	private int _TerminalID;

	private string _SystemName;

	private DateTime _LastCheckedIn;

	private string _DefaultLayoutSectionName;

	private string _PaymentProviderName;

	private string _PaymentMerchantID;

	private string _PaymentTerminalModel;

	private string _PaymentTerminalAddress;

	private short _PaymentTerminalPort;

	private string _OperatingMode;

	private bool _AppRestartRequired;

	private string _Status;

	private bool _ItemsInGroupsRefreshRequired;

	private int? _LayoutZoomValue;

	private bool _SettingsRefreshedRequired;

	private string _PaymentTerminalSerial;

	private int _DefaultStation1;

	private int _DefaultStation2;

	private string _DefaultOrderTypes;

	private DateTime? _LastDateSettlement;

	private string _ProductKey;

	private string _DefaultPrinter;

	private string _PhoneModemDeviceName;

	private bool _ShowPrintError;

	private string _CloverAuthCode;

	private string _Scale_ComPort;

	private string _InstallationToken;

	private string _InstallationID;

	private string _SystemUID;

	private bool _ProcessOnlineOrderQueueFlag;

	private EntitySet<Order> _Orders;

	private EntitySet<Order> _Orders1;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TerminalID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TerminalID
	{
		get
		{
			return _TerminalID;
		}
		set
		{
			if (_TerminalID != value)
			{
				SendPropertyChanging();
				_TerminalID = value;
				SendPropertyChanged("TerminalID");
			}
		}
	}

	[Column(Storage = "_SystemName", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string SystemName
	{
		get
		{
			return _SystemName;
		}
		set
		{
			if (_SystemName != value)
			{
				SendPropertyChanging();
				_SystemName = value;
				SendPropertyChanged("SystemName");
			}
		}
	}

	[Column(Storage = "_LastCheckedIn", DbType = "DateTime NOT NULL")]
	public DateTime LastCheckedIn
	{
		get
		{
			return _LastCheckedIn;
		}
		set
		{
			if (_LastCheckedIn != value)
			{
				SendPropertyChanging();
				_LastCheckedIn = value;
				SendPropertyChanged("LastCheckedIn");
			}
		}
	}

	[Column(Storage = "_DefaultLayoutSectionName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string DefaultLayoutSectionName
	{
		get
		{
			return _DefaultLayoutSectionName;
		}
		set
		{
			if (_DefaultLayoutSectionName != value)
			{
				SendPropertyChanging();
				_DefaultLayoutSectionName = value;
				SendPropertyChanged("DefaultLayoutSectionName");
			}
		}
	}

	[Column(Storage = "_PaymentProviderName", DbType = "NVarChar(128)")]
	public string PaymentProviderName
	{
		get
		{
			return _PaymentProviderName;
		}
		set
		{
			if (_PaymentProviderName != value)
			{
				SendPropertyChanging();
				_PaymentProviderName = value;
				SendPropertyChanged("PaymentProviderName");
			}
		}
	}

	[Column(Storage = "_PaymentMerchantID", DbType = "NVarChar(128)")]
	public string PaymentMerchantID
	{
		get
		{
			return _PaymentMerchantID;
		}
		set
		{
			if (_PaymentMerchantID != value)
			{
				SendPropertyChanging();
				_PaymentMerchantID = value;
				SendPropertyChanged("PaymentMerchantID");
			}
		}
	}

	[Column(Storage = "_PaymentTerminalModel", DbType = "NVarChar(50)")]
	public string PaymentTerminalModel
	{
		get
		{
			return _PaymentTerminalModel;
		}
		set
		{
			if (_PaymentTerminalModel != value)
			{
				SendPropertyChanging();
				_PaymentTerminalModel = value;
				SendPropertyChanged("PaymentTerminalModel");
			}
		}
	}

	[Column(Storage = "_PaymentTerminalAddress", DbType = "NVarChar(50)")]
	public string PaymentTerminalAddress
	{
		get
		{
			return _PaymentTerminalAddress;
		}
		set
		{
			if (_PaymentTerminalAddress != value)
			{
				SendPropertyChanging();
				_PaymentTerminalAddress = value;
				SendPropertyChanged("PaymentTerminalAddress");
			}
		}
	}

	[Column(Storage = "_PaymentTerminalPort", DbType = "SmallInt NOT NULL")]
	public short PaymentTerminalPort
	{
		get
		{
			return _PaymentTerminalPort;
		}
		set
		{
			if (_PaymentTerminalPort != value)
			{
				SendPropertyChanging();
				_PaymentTerminalPort = value;
				SendPropertyChanged("PaymentTerminalPort");
			}
		}
	}

	[Column(Storage = "_OperatingMode", DbType = "NVarChar(20) NOT NULL", CanBeNull = false)]
	public string OperatingMode
	{
		get
		{
			return _OperatingMode;
		}
		set
		{
			if (_OperatingMode != value)
			{
				SendPropertyChanging();
				_OperatingMode = value;
				SendPropertyChanged("OperatingMode");
			}
		}
	}

	[Column(Storage = "_AppRestartRequired", DbType = "Bit NOT NULL")]
	public bool AppRestartRequired
	{
		get
		{
			return _AppRestartRequired;
		}
		set
		{
			if (_AppRestartRequired != value)
			{
				SendPropertyChanging();
				_AppRestartRequired = value;
				SendPropertyChanged("AppRestartRequired");
			}
		}
	}

	[Column(Storage = "_Status", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string Status
	{
		get
		{
			return _Status;
		}
		set
		{
			if (_Status != value)
			{
				SendPropertyChanging();
				_Status = value;
				SendPropertyChanged("Status");
			}
		}
	}

	[Column(Storage = "_ItemsInGroupsRefreshRequired", DbType = "Bit NOT NULL")]
	public bool ItemsInGroupsRefreshRequired
	{
		get
		{
			return _ItemsInGroupsRefreshRequired;
		}
		set
		{
			if (_ItemsInGroupsRefreshRequired != value)
			{
				SendPropertyChanging();
				_ItemsInGroupsRefreshRequired = value;
				SendPropertyChanged("ItemsInGroupsRefreshRequired");
			}
		}
	}

	[Column(Storage = "_LayoutZoomValue", DbType = "Int")]
	public int? LayoutZoomValue
	{
		get
		{
			return _LayoutZoomValue;
		}
		set
		{
			if (_LayoutZoomValue != value)
			{
				SendPropertyChanging();
				_LayoutZoomValue = value;
				SendPropertyChanged("LayoutZoomValue");
			}
		}
	}

	[Column(Storage = "_SettingsRefreshedRequired", DbType = "Bit NOT NULL")]
	public bool SettingsRefreshedRequired
	{
		get
		{
			return _SettingsRefreshedRequired;
		}
		set
		{
			if (_SettingsRefreshedRequired != value)
			{
				SendPropertyChanging();
				_SettingsRefreshedRequired = value;
				SendPropertyChanged("SettingsRefreshedRequired");
			}
		}
	}

	[Column(Storage = "_PaymentTerminalSerial", DbType = "NVarChar(50)")]
	public string PaymentTerminalSerial
	{
		get
		{
			return _PaymentTerminalSerial;
		}
		set
		{
			if (_PaymentTerminalSerial != value)
			{
				SendPropertyChanging();
				_PaymentTerminalSerial = value;
				SendPropertyChanged("PaymentTerminalSerial");
			}
		}
	}

	[Column(Storage = "_DefaultStation1", DbType = "Int NOT NULL")]
	public int DefaultStation1
	{
		get
		{
			return _DefaultStation1;
		}
		set
		{
			if (_DefaultStation1 != value)
			{
				SendPropertyChanging();
				_DefaultStation1 = value;
				SendPropertyChanged("DefaultStation1");
			}
		}
	}

	[Column(Storage = "_DefaultStation2", DbType = "Int NOT NULL")]
	public int DefaultStation2
	{
		get
		{
			return _DefaultStation2;
		}
		set
		{
			if (_DefaultStation2 != value)
			{
				SendPropertyChanging();
				_DefaultStation2 = value;
				SendPropertyChanged("DefaultStation2");
			}
		}
	}

	[Column(Storage = "_DefaultOrderTypes", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
	public string DefaultOrderTypes
	{
		get
		{
			return _DefaultOrderTypes;
		}
		set
		{
			if (_DefaultOrderTypes != value)
			{
				SendPropertyChanging();
				_DefaultOrderTypes = value;
				SendPropertyChanged("DefaultOrderTypes");
			}
		}
	}

	[Column(Storage = "_LastDateSettlement", DbType = "DateTime")]
	public DateTime? LastDateSettlement
	{
		get
		{
			return _LastDateSettlement;
		}
		set
		{
			if (_LastDateSettlement != value)
			{
				SendPropertyChanging();
				_LastDateSettlement = value;
				SendPropertyChanged("LastDateSettlement");
			}
		}
	}

	[Column(Storage = "_ProductKey", DbType = "NVarChar(38)")]
	public string ProductKey
	{
		get
		{
			return _ProductKey;
		}
		set
		{
			if (_ProductKey != value)
			{
				SendPropertyChanging();
				_ProductKey = value;
				SendPropertyChanged("ProductKey");
			}
		}
	}

	[Column(Storage = "_DefaultPrinter", DbType = "NVarChar(50)")]
	public string DefaultPrinter
	{
		get
		{
			return _DefaultPrinter;
		}
		set
		{
			if (_DefaultPrinter != value)
			{
				SendPropertyChanging();
				_DefaultPrinter = value;
				SendPropertyChanged("DefaultPrinter");
			}
		}
	}

	[Column(Storage = "_PhoneModemDeviceName", DbType = "NVarChar(128)")]
	public string PhoneModemDeviceName
	{
		get
		{
			return _PhoneModemDeviceName;
		}
		set
		{
			if (_PhoneModemDeviceName != value)
			{
				SendPropertyChanging();
				_PhoneModemDeviceName = value;
				SendPropertyChanged("PhoneModemDeviceName");
			}
		}
	}

	[Column(Storage = "_ShowPrintError", DbType = "Bit NOT NULL")]
	public bool ShowPrintError
	{
		get
		{
			return _ShowPrintError;
		}
		set
		{
			if (_ShowPrintError != value)
			{
				SendPropertyChanging();
				_ShowPrintError = value;
				SendPropertyChanged("ShowPrintError");
			}
		}
	}

	[Column(Storage = "_CloverAuthCode", DbType = "NVarChar(512)")]
	public string CloverAuthCode
	{
		get
		{
			return _CloverAuthCode;
		}
		set
		{
			if (_CloverAuthCode != value)
			{
				SendPropertyChanging();
				_CloverAuthCode = value;
				SendPropertyChanged("CloverAuthCode");
			}
		}
	}

	[Column(Storage = "_Scale_ComPort", DbType = "NVarChar(5)")]
	public string Scale_ComPort
	{
		get
		{
			return _Scale_ComPort;
		}
		set
		{
			if (_Scale_ComPort != value)
			{
				SendPropertyChanging();
				_Scale_ComPort = value;
				SendPropertyChanged("Scale_ComPort");
			}
		}
	}

	[Column(Storage = "_InstallationToken", DbType = "NVarChar(256)")]
	public string InstallationToken
	{
		get
		{
			return _InstallationToken;
		}
		set
		{
			if (_InstallationToken != value)
			{
				SendPropertyChanging();
				_InstallationToken = value;
				SendPropertyChanged("InstallationToken");
			}
		}
	}

	[Column(Storage = "_InstallationID", DbType = "NVarChar(128)")]
	public string InstallationID
	{
		get
		{
			return _InstallationID;
		}
		set
		{
			if (_InstallationID != value)
			{
				SendPropertyChanging();
				_InstallationID = value;
				SendPropertyChanged("InstallationID");
			}
		}
	}

	[Column(Storage = "_SystemUID", DbType = "NVarChar(128)")]
	public string String_0
	{
		get
		{
			return _SystemUID;
		}
		set
		{
			if (_SystemUID != value)
			{
				SendPropertyChanging();
				_SystemUID = value;
				SendPropertyChanged("SystemUID");
			}
		}
	}

	[Column(Storage = "_ProcessOnlineOrderQueueFlag", DbType = "Bit NOT NULL")]
	public bool ProcessOnlineOrderQueueFlag
	{
		get
		{
			return _ProcessOnlineOrderQueueFlag;
		}
		set
		{
			if (_ProcessOnlineOrderQueueFlag != value)
			{
				SendPropertyChanging();
				_ProcessOnlineOrderQueueFlag = value;
				SendPropertyChanged("ProcessOnlineOrderQueueFlag");
			}
		}
	}

	[Association(Name = "Terminal_Order", Storage = "_Orders", ThisKey = "TerminalID", OtherKey = "TerminalID")]
	public EntitySet<Order> Orders
	{
		get
		{
			return _Orders;
		}
		set
		{
			_Orders.Assign(value);
		}
	}

	[Association(Name = "Terminal_Order1", Storage = "_Orders1", ThisKey = "TerminalID", OtherKey = "CreatedByTerminalID")]
	public EntitySet<Order> Orders1
	{
		get
		{
			return _Orders1;
		}
		set
		{
			_Orders1.Assign(value);
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

	public Terminal()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Orders = new EntitySet<Order>(method_0, method_1);
		_Orders1 = new EntitySet<Order>(method_2, method_3);
	}

	protected virtual void SendPropertyChanging()
	{
		if (propertyChangingEventHandler_0 != null)
		{
			propertyChangingEventHandler_0(this, OunjFyYvQE);
		}
	}

	protected virtual void SendPropertyChanged(string propertyName)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void method_0(Order order_0)
	{
		SendPropertyChanging();
		order_0.Terminal = this;
	}

	private void method_1(Order order_0)
	{
		SendPropertyChanging();
		order_0.Terminal = null;
	}

	private void method_2(Order order_0)
	{
		SendPropertyChanging();
		order_0.Terminal1 = this;
	}

	private void method_3(Order order_0)
	{
		SendPropertyChanging();
		order_0.Terminal1 = null;
	}

	static Terminal()
	{
		Class5.qrSRKAOzgGGAb();
		OunjFyYvQE = new PropertyChangingEventArgs(string.Empty);
	}
}
