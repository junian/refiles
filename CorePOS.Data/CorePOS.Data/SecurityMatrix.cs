using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.SecurityMatrix")]
public class SecurityMatrix : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private int _ModuleID;

	private short _RoleID;

	private bool _IsAllow;

	private EntityRef<ModulesAndFeature> _ModulesAndFeature;

	private EntityRef<Role> _Role;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

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

	[Column(Storage = "_ModuleID", DbType = "Int NOT NULL")]
	public int ModuleID
	{
		get
		{
			return _ModuleID;
		}
		set
		{
			if (_ModuleID != value)
			{
				if (_ModulesAndFeature.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_ModuleID = value;
				SendPropertyChanged("ModuleID");
			}
		}
	}

	[Column(Storage = "_RoleID", DbType = "SmallInt NOT NULL")]
	public short RoleID
	{
		get
		{
			return _RoleID;
		}
		set
		{
			if (_RoleID != value)
			{
				if (_Role.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_RoleID = value;
				SendPropertyChanged("RoleID");
			}
		}
	}

	[Column(Storage = "_IsAllow", DbType = "Bit NOT NULL")]
	public bool IsAllow
	{
		get
		{
			return _IsAllow;
		}
		set
		{
			if (_IsAllow != value)
			{
				SendPropertyChanging();
				_IsAllow = value;
				SendPropertyChanged("IsAllow");
			}
		}
	}

	[Association(Name = "ModulesAndFeature_SecurityMatrix", Storage = "_ModulesAndFeature", ThisKey = "ModuleID", OtherKey = "Id", IsForeignKey = true)]
	public ModulesAndFeature ModulesAndFeature
	{
		get
		{
			return _ModulesAndFeature.Entity;
		}
		set
		{
			ModulesAndFeature entity = _ModulesAndFeature.Entity;
			if (entity != value || !_ModulesAndFeature.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_ModulesAndFeature.Entity = null;
					entity.SecurityMatrixes.Remove(this);
				}
				_ModulesAndFeature.Entity = value;
				if (value != null)
				{
					value.SecurityMatrixes.Add(this);
					_ModuleID = value.Id;
				}
				else
				{
					_ModuleID = 0;
				}
				SendPropertyChanged("ModulesAndFeature");
			}
		}
	}

	[Association(Name = "Role_SecurityMatrix", Storage = "_Role", ThisKey = "RoleID", OtherKey = "RoleID", IsForeignKey = true)]
	public Role Role
	{
		get
		{
			return _Role.Entity;
		}
		set
		{
			Role entity = _Role.Entity;
			if (entity != value || !_Role.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Role.Entity = null;
					entity.SecurityMatrixes.Remove(this);
				}
				_Role.Entity = value;
				if (value != null)
				{
					value.SecurityMatrixes.Add(this);
					_RoleID = value.RoleID;
				}
				else
				{
					_RoleID = 0;
				}
				SendPropertyChanged("Role");
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

	public SecurityMatrix()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_ModulesAndFeature = default(EntityRef<ModulesAndFeature>);
		_Role = default(EntityRef<Role>);
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

	static SecurityMatrix()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
