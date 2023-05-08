using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class SearchMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public string keyword;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}

		internal bool _003CFindItems_003Eb__10(Item t)
		{
			if (t.TrackInventory && (t.ItemName.ToLower().Contains(keyword) || (t.Barcode != null && t.Barcode.Contains(keyword))))
			{
				return !t.isDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_1
	{
		public string trimmedKeyword;

		public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass0_1()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_2
	{
		public string upcBarcode;

		public _003C_003Ec__DisplayClass0_2()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_3
	{
		public List<int> itemIDs;

		public _003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass0_3()
		{
			Class2.oOsq41PzvTVMr();
			base._002Ector();
		}
	}

	public static List<Item> FindItems(string[] keywords, bool isTrackInventory = true)
	{
		List<Item> list = new List<Item>();
		GClass6 gClass = new GClass6();
		bool flag = true;
		for (int j = 0; j < keywords.Length; j++)
		{
			_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
			_003C_003Ec__DisplayClass0_.keyword = keywords[j];
			if (string.IsNullOrEmpty(_003C_003Ec__DisplayClass0_.keyword) || string.IsNullOrEmpty(_003C_003Ec__DisplayClass0_.keyword.Trim()) || _003C_003Ec__DisplayClass0_.keyword.Trim().Length < 3)
			{
				continue;
			}
			_003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass0_1();
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass0_;
			CS_0024_003C_003E8__locals2.trimmedKeyword = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword.Trim();
			if (flag)
			{
				List<Item> list2 = gClass.Items.Where((Item t) => (t.ItemName.ToLower().Contains(CS_0024_003C_003E8__locals2.trimmedKeyword.ToLower()) || (t.Barcode != null && t.Barcode.Contains(CS_0024_003C_003E8__locals2.trimmedKeyword))) && t.isDeleted == false).Take(100).ToList();
				if (isTrackInventory)
				{
					list2 = list2.Where(delegate(Item a)
					{
						a.TrackInventory = true;
						return true;
					}).ToList();
				}
				List<Item> collection = (from i in gClass.ItemCustomFieldValues
					where i.CustomField.Value.ToLower().Contains(CS_0024_003C_003E8__locals2.trimmedKeyword) || i.Value.ToLower().Contains(CS_0024_003C_003E8__locals2.trimmedKeyword)
					select i.Item).ToList();
				list.AddRange(list2);
				list.AddRange(collection);
				if (CS_0024_003C_003E8__locals2.trimmedKeyword.Length == 12)
				{
					_003C_003Ec__DisplayClass0_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_2();
					CS_0024_003C_003E8__locals0.upcBarcode = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword.Trim().Remove(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword.Length - 1);
					List<Item> collection2 = gClass.Items.Where((Item i) => i.Barcode != null && i.Barcode.Contains(CS_0024_003C_003E8__locals0.upcBarcode) && i.isDeleted == false).Take(100).ToList();
					list.AddRange(collection2);
				}
				flag = false;
			}
			else if (!flag && list.Count() > 0)
			{
				_003C_003Ec__DisplayClass0_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass0_3();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals2;
				CS_0024_003C_003E8__locals1.itemIDs = list.Select((Item x) => x.ItemID).ToList();
				List<Item> collection3 = (from i in gClass.ItemCustomFieldValues
					where (i.CustomField.Value.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword) || i.Value.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword)) && CS_0024_003C_003E8__locals1.itemIDs.Contains(i.ItemId)
					select i.Item).Take(100).ToList();
				list = list.Where((Item t) => t.TrackInventory && (t.ItemName.ToLower().Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword) || (t.Barcode != null && t.Barcode.Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.keyword))) && !t.isDeleted).ToList();
				list.AddRange(collection3);
			}
		}
		return (from i in list.Distinct()
			orderby (i.ItemsInGroups.FirstOrDefault() != null && i.ItemsInGroups.FirstOrDefault().Group != null) ? i.ItemsInGroups.FirstOrDefault().Group.GroupName : string.Empty
			select i).ThenBy((Item x) => x.ItemName).ToList();
	}
}
