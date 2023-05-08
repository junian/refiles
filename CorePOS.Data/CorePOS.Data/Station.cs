using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Stations")]
public class Station : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _StationID;

	private string _StationName;

	private string _PrinterName;

	private bool _HasCashDrawer;

	private string _IPAddress;

	private string _ComputerName;

	private bool _EnablePrint;

	private int _PrintCopies;

	private bool _AutoPrint;

	private bool _SendToStation;

	private bool _Synced;

	private short _ChitFormat;

	private bool _IsDefault;

	private string _DefaultButtonName;

	private int? _SystemDefinedID;

	private string _PaperSize;

	private int? _ChitFontSize;

	private int? _DisplayFontSize;

	private string _OrderTypes;

	private bool _PrintEachQty;

	private short _PrintItemQtyGreater;

	private bool _IsDeleted;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler ReIjVmxafW;

	[Column(Storage = "_StationID", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public short StationID
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

	[Column(Storage = "_StationName", DbType = "NVarChar(50)")]
	public string StationName
	{
		get
		{
			return _StationName;
		}
		set
		{
			if (_StationName != value)
			{
				SendPropertyChanging();
				_StationName = value;
				SendPropertyChanged("StationName");
			}
		}
	}

	[Column(Storage = "_PrinterName", DbType = "NVarChar(50)")]
	public string PrinterName
	{
		get
		{
			return _PrinterName;
		}
		set
		{
			if (_PrinterName != value)
			{
				SendPropertyChanging();
				_PrinterName = value;
				SendPropertyChanged("PrinterName");
			}
		}
	}

	[Column(Storage = "_HasCashDrawer", DbType = "Bit NOT NULL")]
	public bool HasCashDrawer
	{
		get
		{
			return _HasCashDrawer;
		}
		set
		{
			if (_HasCashDrawer != value)
			{
				SendPropertyChanging();
				_HasCashDrawer = value;
				SendPropertyChanged("HasCashDrawer");
			}
		}
	}

	[Column(Storage = "_IPAddress", DbType = "NVarChar(15)")]
	public string String_0
	{
		get
		{
			return _IPAddress;
		}
		set
		{
			if (_IPAddress != value)
			{
				SendPropertyChanging();
				_IPAddress = value;
				SendPropertyChanged("IPAddress");
			}
		}
	}

	[Column(Storage = "_ComputerName", DbType = "NVarChar(50)")]
	public string ComputerName
	{
		get
		{
			return _ComputerName;
		}
		set
		{
			if (_ComputerName != value)
			{
				SendPropertyChanging();
				_ComputerName = value;
				SendPropertyChanged("ComputerName");
			}
		}
	}

	[Column(Storage = "_EnablePrint", DbType = "Bit NOT NULL")]
	public bool EnablePrint
	{
		get
		{
			return _EnablePrint;
		}
		set
		{
			if (_EnablePrint != value)
			{
				SendPropertyChanging();
				_EnablePrint = value;
				SendPropertyChanged("EnablePrint");
			}
		}
	}

	[Column(Storage = "_PrintCopies", DbType = "Int NOT NULL")]
	public int PrintCopies
	{
		get
		{
			return _PrintCopies;
		}
		set
		{
			if (_PrintCopies != value)
			{
				SendPropertyChanging();
				_PrintCopies = value;
				SendPropertyChanged("PrintCopies");
			}
		}
	}

	[Column(Storage = "_AutoPrint", DbType = "Bit NOT NULL")]
	public bool AutoPrint
	{
		get
		{
			return _AutoPrint;
		}
		set
		{
			if (_AutoPrint != value)
			{
				SendPropertyChanging();
				_AutoPrint = value;
				SendPropertyChanged("AutoPrint");
			}
		}
	}

	[Column(Storage = "_SendToStation", DbType = "Bit NOT NULL")]
	public bool SendToStation
	{
		get
		{
			return _SendToStation;
		}
		set
		{
			if (_SendToStation != value)
			{
				SendPropertyChanging();
				_SendToStation = value;
				SendPropertyChanged("SendToStation");
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

	[Column(Storage = "_ChitFormat", DbType = "SmallInt NOT NULL")]
	public short ChitFormat
	{
		get
		{
			return _ChitFormat;
		}
		set
		{
			if (_ChitFormat != value)
			{
				SendPropertyChanging();
				_ChitFormat = value;
				SendPropertyChanged("ChitFormat");
			}
		}
	}

	[Column(Storage = "_IsDefault", DbType = "Bit NOT NULL")]
	public bool IsDefault
	{
		get
		{
			return _IsDefault;
		}
		set
		{
			if (_IsDefault != value)
			{
				SendPropertyChanging();
				_IsDefault = value;
				SendPropertyChanged("IsDefault");
			}
		}
	}

	[Column(Storage = "_DefaultButtonName", DbType = "NVarChar(50)")]
	public string DefaultButtonName
	{
		get
		{
			return _DefaultButtonName;
		}
		set
		{
			if (_DefaultButtonName != value)
			{
				SendPropertyChanging();
				_DefaultButtonName = value;
				SendPropertyChanged("DefaultButtonName");
			}
		}
	}

	[Column(Storage = "_SystemDefinedID", DbType = "Int")]
	public int? SystemDefinedID
	{
		get
		{
			return _SystemDefinedID;
		}
		set
		{
			if (_SystemDefinedID != value)
			{
				SendPropertyChanging();
				_SystemDefinedID = value;
				SendPropertyChanged("SystemDefinedID");
			}
		}
	}

	[Column(Storage = "_PaperSize", DbType = "NVarChar(5)")]
	public string PaperSize
	{
		get
		{
			return _PaperSize;
		}
		set
		{
			if (_PaperSize != value)
			{
				SendPropertyChanging();
				_PaperSize = value;
				SendPropertyChanged("PaperSize");
			}
		}
	}

	[Column(Storage = "_ChitFontSize", DbType = "Int")]
	public int? ChitFontSize
	{
		get
		{
			return _ChitFontSize;
		}
		set
		{
			if (_ChitFontSize != value)
			{
				SendPropertyChanging();
				_ChitFontSize = value;
				SendPropertyChanged("ChitFontSize");
			}
		}
	}

	[Column(Storage = "_DisplayFontSize", DbType = "Int")]
	public int? DisplayFontSize
	{
		get
		{
			return _DisplayFontSize;
		}
		set
		{
			if (_DisplayFontSize != value)
			{
				SendPropertyChanging();
				_DisplayFontSize = value;
				SendPropertyChanged("DisplayFontSize");
			}
		}
	}

	[Column(Storage = "_OrderTypes", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
	public string OrderTypes
	{
		get
		{
			return _OrderTypes;
		}
		set
		{
			if (_OrderTypes != value)
			{
				SendPropertyChanging();
				_OrderTypes = value;
				SendPropertyChanged("OrderTypes");
			}
		}
	}

	[Column(Storage = "_PrintEachQty", DbType = "Bit NOT NULL")]
	public bool PrintEachQty
	{
		get
		{
			return _PrintEachQty;
		}
		set
		{
			if (_PrintEachQty != value)
			{
				SendPropertyChanging();
				_PrintEachQty = value;
				SendPropertyChanged("PrintEachQty");
			}
		}
	}

	[Column(Storage = "_PrintItemQtyGreater", DbType = "SmallInt NOT NULL")]
	public short PrintItemQtyGreater
	{
		get
		{
			return _PrintItemQtyGreater;
		}
		set
		{
			if (_PrintItemQtyGreater != value)
			{
				SendPropertyChanging();
				_PrintItemQtyGreater = value;
				SendPropertyChanged("PrintItemQtyGreater");
			}
		}
	}

	[Column(Storage = "_IsDeleted", DbType = "Bit NOT NULL")]
	public bool IsDeleted
	{
		get
		{
			return _IsDeleted;
		}
		set
		{
			if (_IsDeleted != value)
			{
				SendPropertyChanging();
				_IsDeleted = value;
				SendPropertyChanged("IsDeleted");
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
			PropertyChangedEventHandler propertyChangedEventHandler = ReIjVmxafW;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref ReIjVmxafW, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = ReIjVmxafW;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref ReIjVmxafW, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public Station()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
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
		if (ReIjVmxafW != null)
		{
			ReIjVmxafW(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static Station()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
