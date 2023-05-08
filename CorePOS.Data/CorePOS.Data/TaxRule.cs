using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.TaxRules")]
public class TaxRule : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _TaxRuleId;

	private string _RuleName;

	private bool _Active;

	private bool _Synced;

	private EntitySet<TaxRuleOperation> _TaxRuleOperations;

	private EntitySet<Item> _Items;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TaxRuleId", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TaxRuleId
	{
		get
		{
			return _TaxRuleId;
		}
		set
		{
			if (_TaxRuleId != value)
			{
				SendPropertyChanging();
				_TaxRuleId = value;
				SendPropertyChanged("TaxRuleId");
			}
		}
	}

	[Column(Storage = "_RuleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string RuleName
	{
		get
		{
			return _RuleName;
		}
		set
		{
			if (_RuleName != value)
			{
				SendPropertyChanging();
				_RuleName = value;
				SendPropertyChanged("RuleName");
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

	[Association(Name = "TaxRule_TaxRuleOperation", Storage = "_TaxRuleOperations", ThisKey = "TaxRuleId", OtherKey = "TaxRuleId")]
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

	[Association(Name = "TaxRule_Item", Storage = "_Items", ThisKey = "TaxRuleId", OtherKey = "TaxRuleID")]
	public EntitySet<Item> Items
	{
		get
		{
			return _Items;
		}
		set
		{
			_Items.Assign(value);
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

	public TaxRule()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_TaxRuleOperations = new EntitySet<TaxRuleOperation>(method_0, method_1);
		_Items = new EntitySet<Item>(method_2, method_3);
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
		taxRuleOperation_0.TaxRule = this;
	}

	private void method_1(TaxRuleOperation taxRuleOperation_0)
	{
		SendPropertyChanging();
		taxRuleOperation_0.TaxRule = null;
	}

	private void method_2(Item item_0)
	{
		SendPropertyChanging();
		item_0.TaxRule = this;
	}

	private void method_3(Item item_0)
	{
		SendPropertyChanging();
		item_0.TaxRule = null;
	}

	static TaxRule()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
