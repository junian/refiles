using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class HipposClockInOutListPostObject : ClocksInOutReponseObject
{
	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private List<HipposClockInOutRequestObject> list_0;

	public string cs_apikey
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

	public List<HipposClockInOutRequestObject> ListOfClockInOut
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

	public HipposClockInOutListPostObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
