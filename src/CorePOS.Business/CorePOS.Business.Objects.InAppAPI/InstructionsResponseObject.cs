using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Objects.InAppAPI;

public class InstructionsResponseObject : APIResponseObj
{
	[CompilerGenerated]
	private List<SpecialInstruction> list_0;

	public List<SpecialInstruction> instructions
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

	public InstructionsResponseObject()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
