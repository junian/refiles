using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CorePOS.Business.Objects;

public class InstructionsResponseModel : StatusCodeResponse
{
	[CompilerGenerated]
	private List<InstructionsDataModel> list_0;

	public List<InstructionsDataModel> instructionsList
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

	public InstructionsResponseModel()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
