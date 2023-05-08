using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;

public class DeliverectPushItems
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private List<DeliverectProducts> list_0;

	[CompilerGenerated]
	private List<DeliverectCategories> list_1;

	public string accountId
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string locationId
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public List<DeliverectProducts> products
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public List<DeliverectCategories> categories
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public DeliverectPushItems()
	{
		Class2.oOsq41PzvTVMr();
		list_0 = new List<DeliverectProducts>();
		list_1 = new List<DeliverectCategories>();
		base._002Ector();
	}
}
