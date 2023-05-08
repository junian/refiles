using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CorePOS.Data;

[Table(Name = "dbo.ImageScreen")]
public class ImageScreen : INotifyPropertyChanging, INotifyPropertyChanged
{
	private static PropertyChangingEventArgs propertyChangingEventArgs_0;

	private int _Id;

	private string _ImageType;

	private string _ImageName;

	private string _ImageAsText;

	private int _Interval;

	private int _SortOrder;

	private bool _Synced;

	private string _BlobName;

	private string _BlobThumbnailName;

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

	[Column(Storage = "_ImageType", DbType = "NVarChar(128)")]
	public string ImageType
	{
		get
		{
			return _ImageType;
		}
		set
		{
			if (_ImageType != value)
			{
				SendPropertyChanging();
				_ImageType = value;
				SendPropertyChanged("ImageType");
			}
		}
	}

	[Column(Storage = "_ImageName", DbType = "NVarChar(128)")]
	public string ImageName
	{
		get
		{
			return _ImageName;
		}
		set
		{
			if (_ImageName != value)
			{
				SendPropertyChanging();
				_ImageName = value;
				SendPropertyChanged("ImageName");
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

	[Column(Storage = "_Interval", DbType = "Int NOT NULL")]
	public int Interval
	{
		get
		{
			return _Interval;
		}
		set
		{
			if (_Interval != value)
			{
				SendPropertyChanging();
				_Interval = value;
				SendPropertyChanged("Interval");
			}
		}
	}

	[Column(Storage = "_SortOrder", DbType = "Int NOT NULL")]
	public int SortOrder
	{
		get
		{
			return _SortOrder;
		}
		set
		{
			if (_SortOrder != value)
			{
				SendPropertyChanging();
				_SortOrder = value;
				SendPropertyChanged("SortOrder");
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

	[Column(Storage = "_BlobName", DbType = "NVarChar(256)")]
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

	[Column(Storage = "_BlobThumbnailName", DbType = "NVarChar(256)")]
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

	public ImageScreen()
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
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	static ImageScreen()
	{
		Class5.qrSRKAOzgGGAb();
		propertyChangingEventArgs_0 = new PropertyChangingEventArgs(string.Empty);
	}
}
