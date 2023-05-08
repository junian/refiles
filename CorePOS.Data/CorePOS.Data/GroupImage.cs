using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.GroupImages")]
public class GroupImage : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private short _GroupID;

	private string _BlobName;

	private string _BlobThumbnailName;

	private string _ImageAsText;

	private bool _isNewImage;

	private string _ImageAsTextHighRes;

	private EntityRef<Group> _Group;

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

	[Column(Storage = "_GroupID", DbType = "SmallInt NOT NULL")]
	public short GroupID
	{
		get
		{
			return _GroupID;
		}
		set
		{
			if (_GroupID != value)
			{
				if (_Group.HasLoadedOrAssignedValue)
				{
					throw new ForeignKeyReferenceAlreadyHasValueException();
				}
				SendPropertyChanging();
				_GroupID = value;
				SendPropertyChanged("GroupID");
			}
		}
	}

	[Column(Storage = "_BlobName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
	public string BlobName
	{
		get
		{
			return _BlobName;
		}
		set
		{
			if (_BlobName != value)
			{
				SendPropertyChanging();
				_BlobName = value;
				SendPropertyChanged("BlobName");
			}
		}
	}

	[Column(Storage = "_BlobThumbnailName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
	public string BlobThumbnailName
	{
		get
		{
			return _BlobThumbnailName;
		}
		set
		{
			if (_BlobThumbnailName != value)
			{
				SendPropertyChanging();
				_BlobThumbnailName = value;
				SendPropertyChanged("BlobThumbnailName");
			}
		}
	}

	[Column(Storage = "_ImageAsText", DbType = "NVarChar(MAX)")]
	public string ImageAsText
	{
		get
		{
			return _ImageAsText;
		}
		set
		{
			if (_ImageAsText != value)
			{
				SendPropertyChanging();
				_ImageAsText = value;
				SendPropertyChanged("ImageAsText");
			}
		}
	}

	[Column(Storage = "_isNewImage", DbType = "Bit NOT NULL")]
	public bool isNewImage
	{
		get
		{
			return _isNewImage;
		}
		set
		{
			if (_isNewImage != value)
			{
				SendPropertyChanging();
				_isNewImage = value;
				SendPropertyChanged("isNewImage");
			}
		}
	}

	[Column(Storage = "_ImageAsTextHighRes", DbType = "NVarChar(MAX)")]
	public string ImageAsTextHighRes
	{
		get
		{
			return _ImageAsTextHighRes;
		}
		set
		{
			if (_ImageAsTextHighRes != value)
			{
				SendPropertyChanging();
				_ImageAsTextHighRes = value;
				SendPropertyChanged("ImageAsTextHighRes");
			}
		}
	}

	[Association(Name = "Group_GroupImage", Storage = "_Group", ThisKey = "GroupID", OtherKey = "GroupID", IsForeignKey = true)]
	public Group Group
	{
		get
		{
			return _Group.Entity;
		}
		set
		{
			Group entity = _Group.Entity;
			if (entity != value || !_Group.HasLoadedOrAssignedValue)
			{
				SendPropertyChanging();
				if (entity != null)
				{
					_Group.Entity = null;
					entity.GroupImages.Remove(this);
				}
				_Group.Entity = value;
				if (value != null)
				{
					value.GroupImages.Add(this);
					_GroupID = value.GroupID;
				}
				else
				{
					_GroupID = 0;
				}
				SendPropertyChanged("Group");
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

	public GroupImage()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
		_Group = default(EntityRef<Group>);
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

	static GroupImage()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
