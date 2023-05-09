using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Tax")]
public class Tax : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _TaxID;

	private string _TaxCode;

	private decimal _Percentage;

	private bool _Inactive;

	private string _Description;

	private bool _Synced;

	private EntitySet<TaxRuleOperation> _TaxRuleOperations;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TaxID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TaxID
	{
		get
		{
			return _TaxID;
		}
		set
		{
			if (_TaxID != value)
			{
				SendPropertyChanging();
				_TaxID = value;
				SendPropertyChanged("TaxID");
			}
		}
	}

	[Column(Storage = "_TaxCode", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string TaxCode
	{
		get
		{
			return _TaxCode;
		}
		set
		{
			if (_TaxCode != value)
			{
				SendPropertyChanging();
				_TaxCode = value;
				SendPropertyChanged("TaxCode");
			}
		}
	}

	[Column(Storage = "_Percentage", DbType = "Decimal(5,5) NOT NULL")]
	public decimal Percentage
	{
		get
		{
			return _Percentage;
		}
		set
		{
			if (_Percentage != value)
			{
				SendPropertyChanging();
				_Percentage = value;
				SendPropertyChanged("Percentage");
			}
		}
	}

	[Column(Storage = "_Inactive", DbType = "Bit NOT NULL")]
	public bool Inactive
	{
		get
		{
			return _Inactive;
		}
		set
		{
			if (_Inactive != value)
			{
				SendPropertyChanging();
				_Inactive = value;
				SendPropertyChanged("Inactive");
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

	[Association(Name = "Tax_TaxRuleOperation", Storage = "_TaxRuleOperations", ThisKey = "TaxID", OtherKey = "TaxID")]
	public EntitySet<TaxRuleOperation> TaxRuleOperations
	{
		get
		{
			return _TaxRuleOperations;
		}
		set
		{
			_TaxRuleOperations.Assign(value);
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

	public Tax()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_TaxRuleOperations = new EntitySet<TaxRuleOperation>(method_0, method_1);
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

	private void method_0(TaxRuleOperation taxRuleOperation_0)
	{
		SendPropertyChanging();
		taxRuleOperation_0.Tax = this;
	}

	private void method_1(TaxRuleOperation taxRuleOperation_0)
	{
		SendPropertyChanging();
		taxRuleOperation_0.Tax = null;
	}

	static Tax()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
