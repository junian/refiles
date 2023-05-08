using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Properties;
using CorePOS.Data;
using UnitsNet;
using UnitsNet.Units;

namespace CorePOS.Business.Methods;

public class UOMMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public List<string> removedUnits;

		public List<string> existingBaseUnits;

		public Func<string, bool> _003C_003E9__4;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CGetAllUOMs_003Eb__2(string a)
		{
			return !removedUnits.Contains(a);
		}

		internal bool _003CGetAllUOMs_003Eb__4(string a)
		{
			return !existingBaseUnits.Contains(a);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int itemID;

		public int int_0;

		public int toUOMID;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public List<UOM> GetUOMs(int itemId = 0)
	{
		return new DataManager().method_1(itemId);
	}

	public Dictionary<int, string> GetAllUOMsList()
	{
		GClass6 gClass = new GClass6();
		new Dictionary<int, string>();
		return ((IEnumerable<UOM>)gClass.UOMs.OrderBy((UOM x) => x.Name)).ToDictionary((Func<UOM, int>)((UOM k) => k.UOMID), (Func<UOM, string>)((UOM v) => v.Name));
	}

	public List<UOM> method_0(int itemID)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		GClass6 gClass = new GClass6();
		List<UOM> list = (from a in gClass.UOMUnitsConversions
			where a.ItemID == (int?)CS_0024_003C_003E8__locals0.itemID
			select a into y
			select y.UOM1).ToList();
		list.Add(gClass.Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.itemID).FirstOrDefault().UOM);
		return list.OrderBy((UOM x) => x.Name).ToList();
	}

	public Dictionary<int, string> method_1()
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		GClass6 gClass = new GClass6();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		dictionary = ((IEnumerable<UOM>)gClass.UOMs).ToDictionary((Func<UOM, int>)((UOM k) => k.UOMID), (Func<UOM, string>)((UOM v) => v.Name));
		CS_0024_003C_003E8__locals0.removedUnits = new List<string>
		{
			"Undefined", "Centigram", "Decagram", "Decigram", "Hectogram", "Kilopound", "Kilotonne", "LongHundredweight", "LongTon", "Megapound",
			"Megatonne", "Microgram", "Nanogram", "ShortHundredweight", "ShortTon", "Tonne"
		};
		List<string> source = (from a in Enum.GetNames(typeof(MassUnit))
			where !CS_0024_003C_003E8__locals0.removedUnits.Contains(a)
			select a).ToList();
		CS_0024_003C_003E8__locals0.existingBaseUnits = dictionary.Select((KeyValuePair<int, string> a) => a.Value).ToList();
		int num = -1;
		foreach (string item in source.Where((string a) => !CS_0024_003C_003E8__locals0.existingBaseUnits.Contains(a)))
		{
			dictionary.Add(num, item);
			num--;
		}
		dictionary.Add(0, Resources._Add_New);
		return dictionary;
	}

	public static decimal ConvertByUOMID(int itemID, decimal Qty, int int_0, int toUOMID)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		CS_0024_003C_003E8__locals0.int_0 = int_0;
		CS_0024_003C_003E8__locals0.toUOMID = toUOMID;
		GClass6 gClass = new GClass6();
		GClass7 gClass2 = gClass.UOMUnitsConversions.Where((GClass7 x) => x.ItemID == (int?)CS_0024_003C_003E8__locals0.itemID && x.BaseUnitId == CS_0024_003C_003E8__locals0.int_0 && x.ToUnitId == CS_0024_003C_003E8__locals0.toUOMID).FirstOrDefault();
		if (gClass2 != null)
		{
			return MathHelper.FractionToDecimal(Qty + ((gClass2.Operator == "*") ? "/" : "*") + gClass2.Factor, 8);
		}
		if (gClass2 == null && (CS_0024_003C_003E8__locals0.int_0 == 1 || CS_0024_003C_003E8__locals0.toUOMID == 1))
		{
			return Qty;
		}
		string name = gClass.UOMs.Where((UOM x) => x.UOMID == CS_0024_003C_003E8__locals0.int_0).FirstOrDefault().Name;
		string name2 = gClass.UOMs.Where((UOM x) => x.UOMID == CS_0024_003C_003E8__locals0.toUOMID).FirstOrDefault().Name;
		return (decimal)UnitConverter.ConvertByName((byte)1, "Mass", name, name2) * Qty;
	}

	public UOMMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}
}
