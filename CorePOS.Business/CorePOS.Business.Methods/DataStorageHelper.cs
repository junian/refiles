using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class DataStorageHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public short ParentGroupID;

		public string itemClassification;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CGetChildGroups_003Eb__0(Group g)
		{
			if (g.ParentGroupID == ParentGroupID && g.GroupClassification == itemClassification)
			{
				return !g.Archived;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public string Classification;

		public string GroupName;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CGetGroup_003Eb__0(Group a)
		{
			if (a.GroupClassification == Classification && !a.Archived)
			{
				return a.GroupName == GroupName;
			}
			return false;
		}
	}

	public static List<Item> ItemList;

	public static List<Group> GroupList;

	public static List<ItemsInGroup> ItemsInGroupsList;

	public static void SetItems()
	{
		ItemList = new GClass6().Items.ToList();
	}

	public static void SetGroups()
	{
		GroupList = new GClass6().Groups.ToList();
	}

	public static void SetItemsInGroups()
	{
		ItemsInGroupsList = new GClass6().ItemsInGroups.ToList();
	}

	public static List<Item> GetItemsInGroup(string GroupName, bool onlyActive = true)
	{
		List<Item> list = new List<Item>();
		list = (from a in ItemsInGroupsList
			where !a.Item.isDeleted
			select a.Item).ToList();
		if (onlyActive)
		{
			list = list.Where((Item a) => a.Active).ToList();
		}
		return list;
	}

	public static List<Group> GetChildGroups(string itemClassification, short ParentGroupID, bool onlyActive = false)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.ParentGroupID = ParentGroupID;
		CS_0024_003C_003E8__locals0.itemClassification = itemClassification;
		List<Group> list = new List<Group>();
		list = GroupList.Where((Group g) => g.ParentGroupID == CS_0024_003C_003E8__locals0.ParentGroupID && g.GroupClassification == CS_0024_003C_003E8__locals0.itemClassification && !g.Archived).ToList();
		if (onlyActive)
		{
			list = list.Where((Group g) => g.Active).ToList();
		}
		return list;
	}

	public static Group GetGroup(string GroupName, string Classification)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.Classification = Classification;
		CS_0024_003C_003E8__locals0.GroupName = GroupName;
		return GroupList.Where((Group a) => a.GroupClassification == CS_0024_003C_003E8__locals0.Classification && !a.Archived && a.GroupName == CS_0024_003C_003E8__locals0.GroupName).FirstOrDefault();
	}

	static DataStorageHelper()
	{
		Class2.oOsq41PzvTVMr();
		ItemList = new List<Item>();
		GroupList = new List<Group>();
		ItemsInGroupsList = new List<ItemsInGroup>();
	}
}
