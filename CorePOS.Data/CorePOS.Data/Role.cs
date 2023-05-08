using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.Roles")]
public class Role : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private short _RoleID;

	private string _RoleName;

	private short? _RoleLevel;

	private EntitySet<User> _Users;

	private EntitySet<SecurityMatrix> _SecurityMatrixes;

	[CompilerGenerated]
	private PropertyChangingEventHandler propertyChangingEventHandler_0;

	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	[Column(Storage = "_RoleID", AutoSync = AutoSync.OnInsert, DbType = "SmallInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
				SendPropertyChanging();
				_RoleID = value;
				SendPropertyChanged("RoleID");
			}
		}
	}

	[Column(Storage = "_RoleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
	public string RoleName
	{
		get
		{
			return _RoleName;
		}
		set
		{
			if (_RoleName != value)
			{
				SendPropertyChanging();
				_RoleName = value;
				SendPropertyChanged("RoleName");
			}
		}
	}

	[Column(Storage = "_RoleLevel", DbType = "SmallInt")]
	public short? RoleLevel
	{
		get
		{
			return _RoleLevel;
		}
		set
		{
			if (_RoleLevel != value)
			{
				SendPropertyChanging();
				_RoleLevel = value;
				SendPropertyChanged("RoleLevel");
			}
		}
	}

	[Association(Name = "Role_User", Storage = "_Users", ThisKey = "RoleID", OtherKey = "RoleID")]
	public EntitySet<User> Users
	{
		get
		{
			return _Users;
		}
		set
		{
			_Users.Assign(value);
		}
	}

	[Association(Name = "Role_SecurityMatrix", Storage = "_SecurityMatrixes", ThisKey = "RoleID", OtherKey = "RoleID")]
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

	public Role()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Users = new EntitySet<User>(method_0, method_1);
		_SecurityMatrixes = new EntitySet<SecurityMatrix>(method_2, method_3);
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

	private void method_0(User user_0)
	{
		SendPropertyChanging();
		user_0.Role = this;
	}

	private void method_1(User user_0)
	{
		SendPropertyChanging();
		user_0.Role = null;
	}

	private void method_2(SecurityMatrix securityMatrix_0)
	{
		SendPropertyChanging();
		securityMatrix_0.Role = this;
	}

	private void method_3(SecurityMatrix securityMatrix_0)
	{
		SendPropertyChanging();
		securityMatrix_0.Role = null;
	}

	static Role()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
