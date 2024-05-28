using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.TaxRuleOperations")]
public class TaxRuleOperation : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _TaxRuleOperatorId;

	private int _TaxRuleId;

	private Guid _TaxRuleRequirementID;

	private string _Operator;

	private decimal _Condition;

	private int _TaxID;

	private bool _Synced;

	private EntityRef<Tax> _Tax;

	private EntityRef<TaxRule> _TaxRule;

	private EntityRef<TaxRuleRequirement> _TaxRuleRequirement;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TaxRuleOperatorId", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int TaxRuleOperatorId
	{
		get
		{
			return _TaxRuleOperatorId;
		}
		set
		{
			if (_TaxRuleOperatorId != value)
			{
				SendPropertyChanging();
				_TaxRuleOperatorId = value;
				SendPropertyChanged("TaxRuleOperatorId");
			}
		}
	}

	[Column(Storage = "_TaxRuleId", DbType = "Int NOT NULL")]
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
				if (_TaxRule.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_TaxRuleId = value;
				SendPropertyChanged("TaxRuleId");
			}
		}
	}

	[Column(Storage = "_TaxRuleRequirementID", DbType = "UniqueIdentifier NOT NULL")]
	public Guid TaxRuleRequirementID
	{
		get
		{
			return _TaxRuleRequirementID;
		}
		set
		{
			if (_TaxRuleRequirementID != value)
			{
				if (_TaxRuleRequirement.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_TaxRuleRequirementID = value;
				SendPropertyChanged("TaxRuleRequirementID");
			}
		}
	}

	[Column(Storage = "_Operator", DbType = "NVarChar(2) NOT NULL", CanBeNull = false)]
	public string Operator
	{
		get
		{
			return _Operator;
		}
		set
		{
			if (_Operator != value)
			{
				SendPropertyChanging();
				_Operator = value;
				SendPropertyChanged("Operator");
			}
		}
	}

	[Column(Storage = "_Condition", DbType = "Decimal(18,2) NOT NULL")]
	public decimal Condition
	{
		get
		{
			return _Condition;
		}
		set
		{
			if (_Condition != value)
			{
				SendPropertyChanging();
				_Condition = value;
				SendPropertyChanged("Condition");
			}
		}
	}

	[Column(Storage = "_TaxID", DbType = "Int NOT NULL")]
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
				if (_Tax.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_TaxID = value;
				SendPropertyChanged("TaxID");
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

	[Association(Name = "Tax_TaxRuleOperation", Storage = "_Tax", ThisKey = "TaxID", OtherKey = "TaxID", IsForeignKey = true)]
	public Tax Tax
	{
		get
		{
			return _Tax.Entity;
		}
		set
		{
			Tax entity = _Tax.Entity;
			if (entity != value || !_Tax.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Tax.Entity = null;
					entity.TaxRuleOperations.Remove(this);
				}
				_Tax.Entity = value;
				if (value != null)
				{
					value.TaxRuleOperations.Add(this);
					_TaxID = value.TaxID;
				}
				else
				{
					_TaxID = 0;
				}
				SendPropertyChanged("Tax");
			}
		}
	}

	[Association(Name = "TaxRule_TaxRuleOperation", Storage = "_TaxRule", ThisKey = "TaxRuleId", OtherKey = "TaxRuleId", IsForeignKey = true)]
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
					entity.TaxRuleOperations.Remove(this);
				}
				_TaxRule.Entity = value;
				if (value != null)
				{
					value.TaxRuleOperations.Add(this);
					_TaxRuleId = value.TaxRuleId;
				}
				else
				{
					_TaxRuleId = 0;
				}
				SendPropertyChanged("TaxRule");
			}
		}
	}

	[Association(Name = "TaxRuleRequirement_TaxRuleOperation", Storage = "_TaxRuleRequirement", ThisKey = "TaxRuleRequirementID", OtherKey = "TaxRuleRequirementId", IsForeignKey = true)]
	public TaxRuleRequirement TaxRuleRequirement
	{
		get
		{
			return _TaxRuleRequirement.Entity;
		}
		set
		{
			TaxRuleRequirement entity = _TaxRuleRequirement.Entity;
			if (entity != value || !_TaxRuleRequirement.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_TaxRuleRequirement.Entity = null;
					entity.TaxRuleOperations.Remove(this);
				}
				_TaxRuleRequirement.Entity = value;
				if (value != null)
				{
					value.TaxRuleOperations.Add(this);
					_TaxRuleRequirementID = value.TaxRuleRequirementId;
				}
				else
				{
					_TaxRuleRequirementID = default(Guid);
				}
				SendPropertyChanged("TaxRuleRequirement");
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

	public TaxRuleOperation()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_Tax = default(EntityRef<Tax>);
		_TaxRule = default(EntityRef<TaxRule>);
		_TaxRuleRequirement = default(EntityRef<TaxRuleRequirement>);
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

	static TaxRuleOperation()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
