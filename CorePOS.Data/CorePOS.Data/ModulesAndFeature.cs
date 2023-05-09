using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.ModulesAndFeatures")]
public class ModulesAndFeature : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _ModuleName;

	private string _ControlName;

	private string _Description;

	private bool _AllowCtrlOverride;

	private bool _AllowAdminEdit;

	private EntitySet<SecurityMatrix> _SecurityMatrixes;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler bHyXrnukrv;

	[Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
	public int Id
	{
		get
		{
			return _Id;
		}
		set
		{
			if (_Id != value)
			{
				SendPropertyChanging();
				_Id = value;
				SendPropertyChanged("Id");
			}
		}
	}

	[Column(Storage = "_ModuleName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
	public string ModuleName
	{
		get
		{
			return _ModuleName;
		}
		set
		{
			if (_ModuleName != value)
			{
				SendPropertyChanging();
				_ModuleName = value;
				SendPropertyChanged("ModuleName");
			}
		}
	}

	[Column(Storage = "_ControlName", DbType = "NVarChar(256)")]
	public string ControlName
	{
		get
		{
			return _ControlName;
		}
		set
		{
			if (_ControlName != value)
			{
				SendPropertyChanging();
				_ControlName = value;
				SendPropertyChanged("ControlName");
			}
		}
	}

	[Column(Storage = "_Description", DbType = "NVarChar(512)")]
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

	[Column(Storage = "_AllowCtrlOverride", DbType = "Bit NOT NULL")]
	public bool AllowCtrlOverride
	{
		get
		{
			return _AllowCtrlOverride;
		}
		set
		{
			if (_AllowCtrlOverride != value)
			{
				SendPropertyChanging();
				_AllowCtrlOverride = value;
				SendPropertyChanged("AllowCtrlOverride");
			}
		}
	}

	[Column(Storage = "_AllowAdminEdit", DbType = "Bit NOT NULL")]
	public bool AllowAdminEdit
	{
		get
		{
			return _AllowAdminEdit;
		}
		set
		{
			if (_AllowAdminEdit != value)
			{
				SendPropertyChanging();
				_AllowAdminEdit = value;
				SendPropertyChanged("AllowAdminEdit");
			}
		}
	}

	[Association(Name = "ModulesAndFeature_SecurityMatrix", Storage = "_SecurityMatrixes", ThisKey = "Id", OtherKey = "ModuleID")]
	public EntitySet<SecurityMatrix> SecurityMatrixes
	{
		get
		{
			return _SecurityMatrixes;
		}
		set
		{
			_SecurityMatrixes.Assign(value);
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
			PropertyChangedEventHandler propertyChangedEventHandler = bHyXrnukrv;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref bHyXrnukrv, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = bHyXrnukrv;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref bHyXrnukrv, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public ModulesAndFeature()
	{
		Class5.qrSRKAOzgGGAb();
		// base._002Ector();
		_SecurityMatrixes = new EntitySet<SecurityMatrix>(method_0, method_1);
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
		if (bHyXrnukrv != null)
		{
			bHyXrnukrv(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	private void method_0(SecurityMatrix securityMatrix_0)
	{
		SendPropertyChanging();
		securityMatrix_0.ModulesAndFeature = this;
	}

	private void method_1(SecurityMatrix securityMatrix_0)
	{
		SendPropertyChanging();
		securityMatrix_0.ModulesAndFeature = null;
	}

	static ModulesAndFeature()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
