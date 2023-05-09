using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.CustomFields")]
public class CustomField : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _CustomFieldId;

	private string _Value;

	private bool _Sycned;

	private EntitySet<ItemCustomFieldValue> _ItemCustomFieldValues;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_CustomFieldId", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public short CustomFieldId
	{
		get
		{
			return _CustomFieldId;
		}
		set
		{
			if (_CustomFieldId != value)
			{
				SendPropertyChanging();
				_CustomFieldId = value;
				SendPropertyChanged("CustomFieldId");
			}
		}
	}

	[Column(Storage = "_Value", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string Value
	{
		get
		{
			return _Value;
		}
		set
		{
			if (_Value != value)
			{
				SendPropertyChanging();
				_Value = value;
				SendPropertyChanged("Value");
			}
		}
	}

	[Column(Storage = "_Sycned", DbType = "Bit NOT NULL")]
	public bool Sycned
	{
		get
		{
			return _Sycned;
		}
		set
		{
			if (_Sycned != value)
			{
				SendPropertyChanging();
				_Sycned = value;
				SendPropertyChanged("Sycned");
			}
		}
	}

	[Association(Name = "CustomField_ItemCustomFieldValue", Storage = "_ItemCustomFieldValues", ThisKey = "CustomFieldId", OtherKey = "CustomFieldId")]
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

	public CustomField()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_ItemCustomFieldValues = new EntitySet<ItemCustomFieldValue>(method_0, method_1);
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

	private void method_0(ItemCustomFieldValue itemCustomFieldValue_0)
	{
		SendPropertyChanging();
		itemCustomFieldValue_0.CustomField = this;
	}

	private void method_1(ItemCustomFieldValue itemCustomFieldValue_0)
	{
		SendPropertyChanging();
		itemCustomFieldValue_0.CustomField = null;
	}

	static CustomField()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
