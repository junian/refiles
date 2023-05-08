using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class InstructionsMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public string stations;

		public _003C_003Ec__DisplayClass7_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CSpecialInstructionsListItemAtStation_003Eb__2(SpecialInstruction i)
		{
			if (!stations.Contains(i.StationID.ToString()))
			{
				return i.StationID == 0;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int instrID;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CSpecialInstructionsList_003Eb__0(SpecialInstruction i)
		{
			return i.SpecialInstructionID == instrID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public string instr;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CSpecialInstructionsList_003Eb__0(SpecialInstruction i)
		{
			return i.Instruction.ToUpper().Equals(instr.ToUpper().Trim());
		}
	}

	private GClass6 gclass6_0;

	public GClass6 DataContext
	{
		get
		{
			return gclass6_0;
		}
		set
		{
			gclass6_0 = value;
		}
	}

	public InstructionsMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
		gclass6_0 = new GClass6();
	}

	public InstructionsMethods(GClass6 appDataContext)
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
		gclass6_0 = appDataContext;
	}

	public List<SpecialInstruction> SpecialInstructionsList()
	{
		return DataContext.SpecialInstructions.OrderBy((SpecialInstruction x) => x.Instruction).ToList();
	}

	public List<SpecialInstruction> SpecialInstructionsListItemAtStation(int itemId)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		Item item = gclass6_0.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		if (item != null)
		{
			_003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_1();
			CS_0024_003C_003E8__locals1.stations = item.StationID;
			return (from i in SpecialInstructionsList()
				where CS_0024_003C_003E8__locals1.stations.Contains(i.StationID.ToString()) || i.StationID == 0
				select i).ToList();
		}
		return (from i in SpecialInstructionsList()
			where i.StationID == 0
			select i).ToList();
	}

	public SpecialInstruction SpecialInstructionsList(int instrID)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.instrID = instrID;
		return (from i in SpecialInstructionsList()
			where i.SpecialInstructionID == CS_0024_003C_003E8__locals0.instrID
			select i).FirstOrDefault();
	}

	public SpecialInstruction SpecialInstructionsList(string instr)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.instr = instr;
		SpecialInstruction specialInstruction = (from i in SpecialInstructionsList()
			where i.Instruction.ToUpper().Equals(CS_0024_003C_003E8__locals0.instr.ToUpper().Trim())
			select i).FirstOrDefault();
		if (specialInstruction != null)
		{
			return specialInstruction;
		}
		return null;
	}
}
