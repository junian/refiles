using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.TaxRuleRequirements")]
public class TaxRuleRequirement : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private Guid _TaxRuleRequirementId;

	private string _RequirementDesc;

	private EntitySet<TaxRuleOperation> _TaxRuleOperations;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_TaxRuleRequirementId", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
	public Guid TaxRuleRequirementId
	{
		get
		{
			return _TaxRuleRequirementId;
		}
		set
		{
			if (_TaxRuleRequirementId != value)
			{
				SendPropertyChanging();
				_TaxRuleRequirementId = value;
				SendPropertyChanged("TaxRuleRequirementId");
			}
		}
	}

	[Column(Storage = "_RequirementDesc", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
	public string RequirementDesc
	{
		get
		{
			return _RequirementDesc;
		}
		set
		{
			if (_RequirementDesc != value)
			{
				SendPropertyChanging();
				_RequirementDesc = value;
				SendPropertyChanged("RequirementDesc");
			}
		}
	}

	[Association(Name = "TaxRuleRequirement_TaxRuleOperation", Storage = "_TaxRuleOperations", ThisKey = "TaxRuleRequirementId", OtherKey = "TaxRuleRequirementID")]
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

	public TaxRuleRequirement()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_TaxRuleOperations = new EntitySet<TaxRuleOperation>(GpyMeKrfa, method_0);
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

	private void GpyMeKrfa(TaxRuleOperation taxRuleOperation_0)
	{
		SendPropertyChanging();
		taxRuleOperation_0.TaxRuleRequirement = this;
	}

	private void method_0(TaxRuleOperation taxRuleOperation_0)
	{
		SendPropertyChanging();
		taxRuleOperation_0.TaxRuleRequirement = null;
	}

	static TaxRuleRequirement()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
