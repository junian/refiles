using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class AppointmentResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<AppointmentPostModel> list_0;

	public List<AppointmentPostModel> appointmentResponseList
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

	public AppointmentResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
