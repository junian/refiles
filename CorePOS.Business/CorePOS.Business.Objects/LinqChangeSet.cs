using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class LinqChangeSet
{
	[CompilerGenerated]
	private IList<object> ilist_0;

	[CompilerGenerated]
	private IList<object> ilist_1;

	[CompilerGenerated]
	private IList<object> ilist_2;

	public IList<object> Inserts
	{
		[CompilerGenerated]
		get
		{
			return ilist_0;
		}
		[CompilerGenerated]
		set
		{
			ilist_0 = value;
		}
	}

	public IList<object> Deletes
	{
		[CompilerGenerated]
		get
		{
			return ilist_1;
		}
		[CompilerGenerated]
		set
		{
			ilist_1 = value;
		}
	}

	public IList<object> Updates
	{
		[CompilerGenerated]
		get
		{
			return ilist_2;
		}
		[CompilerGenerated]
		set
		{
			ilist_2 = value;
		}
	}

	public LinqChangeSet()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
