using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmOrderEntry : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass135_0
	{
		public string Id;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass135_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass135_1
	{
		public System.Windows.Forms.Timer timer;

		public _003C_003Ec__DisplayClass135_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass135_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CGenerateNewButton_003Eb__0(object sender, MouseEventArgs e)
		{
			timer.Start();
		}

		internal void _003CGenerateNewButton_003Eb__1(object sender, MouseEventArgs e)
		{
			timer.Stop();
		}

		internal void _003CGenerateNewButton_003Eb__2(object sender, EventArgs e)
		{
			timer.Stop();
		}

		internal void _003CGenerateNewButton_003Eb__3(object sender, EventArgs e)
		{
			timer.Stop();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.Id))
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.method_11(Convert.ToInt16(CS_0024_003C_003E8__locals1.Id));
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass136_0
	{
		public short Id;

		public _003C_003Ec__DisplayClass136_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CshowItemInfo_003Eb__0(ItemImage m)
		{
			return m.ItemID == Id;
		}

		internal bool _003CshowItemInfo_003Eb__1(Item m)
		{
			return m.ItemID == Convert.ToInt16(Id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public Order order;

		public _003C_003Ec__DisplayClass141_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnClear_Click_003Eb__3(Item i)
		{
			return i.ItemID == order.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass148_0
	{
		public frmOrderEntry _003C_003E4__this;

		public CorePOS.Data.Group group;

		public Func<ItemsInGroup, bool> _003C_003E9__10;

		public Func<ItemsInGroup, bool> _003C_003E9__11;

		public Func<ItemsInGroup, bool> _003C_003E9__12;

		public Func<ItemsInGroup, bool> _003C_003E9__13;

		public Func<ItemsInGroup, bool> _003C_003E9__14;

		public Func<ItemsInGroup, bool> _003C_003E9__15;

		public _003C_003Ec__DisplayClass148_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CDisplayItems_003Eb__1(CorePOS.Data.Group a)
		{
			if (a.GroupClassification == ItemClassifications.Product && !a.Archived)
			{
				return a.GroupName.ToUpper() == _003C_003E4__this.string_2.ToUpper();
			}
			return false;
		}

		internal bool _003CDisplayItems_003Eb__2(ItemsInGroup a)
		{
			return a.GroupID == group.GroupID;
		}

		internal int _003CDisplayItems_003Eb__3(Item x)
		{
			if (x.ItemsInGroups.Where((ItemsInGroup y) => y.GroupID == group.GroupID).FirstOrDefault() == null)
			{
				return 0;
			}
			return x.ItemsInGroups.Where((ItemsInGroup y) => y.GroupID == group.GroupID).FirstOrDefault().SortOrder;
		}

		internal bool _003CDisplayItems_003Eb__10(ItemsInGroup y)
		{
			return y.GroupID == group.GroupID;
		}

		internal bool _003CDisplayItems_003Eb__11(ItemsInGroup y)
		{
			return y.GroupID == group.GroupID;
		}

		internal bool _003CDisplayItems_003Eb__8(Item a)
		{
			if (a.ItemsInGroups != null && a.ItemsInGroups.Count() > 0)
			{
				return a.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == group.GroupID).FirstOrDefault() != null;
			}
			return false;
		}

		internal bool _003CDisplayItems_003Eb__12(ItemsInGroup x)
		{
			return x.GroupID == group.GroupID;
		}

		internal short _003CDisplayItems_003Eb__9(Item a)
		{
			return a.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == group.GroupID).First().SortOrder;
		}

		internal bool _003CDisplayItems_003Eb__13(ItemsInGroup x)
		{
			return x.GroupID == group.GroupID;
		}

		internal bool _003CDisplayItems_003Eb__14(ItemsInGroup x)
		{
			return x.GroupID == group.GroupID;
		}

		internal bool _003CDisplayItems_003Eb__15(ItemsInGroup x)
		{
			return x.GroupID == group.GroupID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass148_1
	{
		public Item item;

		public _003C_003Ec__DisplayClass148_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CDisplayItems_003Eb__16(ItemImage m)
		{
			return m.ItemID == item.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_0
	{
		public int selectedTag;

		public Item item;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass152_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__0(Item i)
		{
			return i.ItemID == selectedTag;
		}

		internal bool _003CAddItem_003Eb__5(usp_ItemOptionsResult i)
		{
			if (i.ItemID == item.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0))
			{
				if (i.GroupOrderTypes != null)
				{
					return i.GroupOrderTypes.Split(',').Contains(_003C_003E4__this.string_5);
				}
				return true;
			}
			return false;
		}

		internal bool _003CAddItem_003Eb__16(usp_ItemOptionsResult i)
		{
			if (i.ItemID == item.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0))
			{
				if (i.GroupOrderTypes != null)
				{
					return i.GroupOrderTypes.Split(',').Contains(_003C_003E4__this.string_5);
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_1
	{
		public ItemsInItem itemChild;

		public _003C_003Ec__DisplayClass152_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass152_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__8(Item x)
		{
			return x.ItemID == itemChild.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_2
	{
		public Item itemChildDetails;

		public _003C_003Ec__DisplayClass152_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass152_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__9(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemChildDetails.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0))
			{
				if (i.GroupOrderTypes != null)
				{
					return i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.string_5);
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_3
	{
		public frmGroupsInItemSelection frmSel;

		public _003C_003Ec__DisplayClass152_0 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass152_3()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__12(Item a)
		{
			return a.ItemID == frmSel.returnItemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_4
	{
		public Item itemInGroup;

		public _003C_003Ec__DisplayClass152_3 CS_0024_003C_003E8__locals4;

		public _003C_003Ec__DisplayClass152_4()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__13(usp_ItemOptionsResult a)
		{
			if (a.ItemID == itemInGroup.ItemID && !a.ToBeDeleted && ((a.GroupID > 0 && a.OptionsGroupShowOrderEntry == true) || a.GroupID == 0))
			{
				if (a.GroupOrderTypes != null)
				{
					return a.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3._003C_003E4__this.string_5);
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass152_5
	{
		public short groupId;

		public _003C_003Ec__DisplayClass152_5()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItem_003Eb__20(usp_ItemOptionsResult a)
		{
			if (a.MinGroupOptions == 1 && a.MaxGroupOptions == 1 && a.GroupID == groupId)
			{
				return a.Preselect;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_0
	{
		public PossibleCombo combo;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass154_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__2(Item a)
		{
			if (a.ItemID == combo.ParentItemId && !a.isDeleted)
			{
				return a.Active;
			}
			return false;
		}

		internal bool _003CcheckCombo_003Eb__13(Item x)
		{
			return x.ItemID == combo.ParentItemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_1
	{
		public List<GroupsInItem> comboGroups;

		public _003C_003Ec__DisplayClass154_0 CS_0024_003C_003E8__locals1;

		public Func<ItemsInGroup, bool> _003C_003E9__23;

		public _003C_003Ec__DisplayClass154_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__22(int a)
		{
			return (from x in MemoryLoadedObjects.all_itemsInGroups
				where comboGroups.Select((GroupsInItem b) => b.GroupID).ToList().Contains(x.GroupID.Value)
				select x into z
				select z.ItemID).ToList().Contains(a);
		}

		internal bool _003CcheckCombo_003Eb__23(ItemsInGroup x)
		{
			return comboGroups.Select((GroupsInItem b) => b.GroupID).ToList().Contains(x.GroupID.Value);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_2
	{
		public ItemsInItem x;

		public _003C_003Ec__DisplayClass154_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__8(int i)
		{
			return i.ToString() == x.ItemID.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_3
	{
		public GroupsInItem cg;

		public Func<ItemsInGroup, bool> _003C_003E9__11;

		public _003C_003Ec__DisplayClass154_3()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__10(BillItemsWithCount b)
		{
			return (from a in MemoryLoadedObjects.all_itemsInGroups
				where a.GroupID == cg.GroupID
				select a.ItemID).ToList().Contains(b.ItemId);
		}

		internal bool _003CcheckCombo_003Eb__11(ItemsInGroup a)
		{
			return a.GroupID == cg.GroupID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_4
	{
		public Item comboItem;

		public _003C_003Ec__DisplayClass154_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass154_4()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__14(usp_ItemOptionsResult i)
		{
			if (i.ItemID == comboItem.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0))
			{
				if (i.GroupOrderTypes != null)
				{
					return i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.string_5);
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_5
	{
		public ItemsInItem subItem;

		public _003C_003Ec__DisplayClass154_5()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__17(ListViewDataItem x)
		{
			if (x.SubItems[4].ToString() == subItem.ItemID.ToString())
			{
				return Convert.ToBoolean(x.SubItems[12].ToString());
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_6
	{
		public ListViewDataItem mainGroupItem;

		public _003C_003Ec__DisplayClass154_6()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__18(ListViewDataItem x)
		{
			return x.SubItems[5].ToString() == mainGroupItem.SubItems[5].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_7
	{
		public ListViewDataItem lvMain;

		public _003C_003Ec__DisplayClass154_7()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__19(ListViewDataItem x)
		{
			return x.SubItems[5].ToString() == lvMain.SubItems[5].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_8
	{
		public ItemsInItem subItem;

		public _003C_003Ec__DisplayClass154_8()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__20(PossibleCombo x)
		{
			if (x.ItemId == subItem.ItemID)
			{
				return x.ParentItemId == subItem.ParentItemID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_9
	{
		public ItemsInItem itemChild;

		public _003C_003Ec__DisplayClass154_9()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__21(Item x)
		{
			return x.ItemID == itemChild.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_10
	{
		public int itemChild;

		public _003C_003Ec__DisplayClass154_4 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass154_10()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__26(ListViewDataItem x)
		{
			if (x.SubItems[4].ToString() == itemChild.ToString())
			{
				return Convert.ToBoolean(x.SubItems[12].ToString());
			}
			return false;
		}

		internal bool _003CcheckCombo_003Eb__29(Item x)
		{
			return x.ItemID == itemChild;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_11
	{
		public ListViewDataItem mainGroupItem;

		public Item itemInGroup;

		public _003C_003Ec__DisplayClass154_10 CS_0024_003C_003E8__locals4;

		public _003C_003Ec__DisplayClass154_11()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__27(ListViewDataItem x)
		{
			return x.SubItems[5].ToString() == mainGroupItem.SubItems[5].ToString();
		}

		internal bool _003CcheckCombo_003Eb__28(ListViewDataItem x)
		{
			if (x.SubItems[4].ToString() != CS_0024_003C_003E8__locals4.itemChild.ToString())
			{
				return x.SubItems[5].ToString() == mainGroupItem.SubItems[5].ToString();
			}
			return false;
		}

		internal bool _003CcheckCombo_003Eb__30(PossibleCombo x)
		{
			if (x.ItemId == itemInGroup.ItemID)
			{
				return x.ParentItemId == CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.comboItem.ItemID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_12
	{
		public int itemOptionChildId;

		public _003C_003Ec__DisplayClass154_12()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CcheckCombo_003Eb__31(Item x)
		{
			return x.ItemID == itemOptionChildId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass155_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass155_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CremoveFromComboPotential_003Eb__0(PossibleCombo x)
		{
			return x.ItemId == itemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass156_0
	{
		public int childItemID;

		public _003C_003Ec__DisplayClass156_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass156_1
	{
		public ItemsInItem itemChild;

		public _003C_003Ec__DisplayClass156_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CaddPackageItems_003Eb__1(Item x)
		{
			return x.ItemID == itemChild.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass157_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass157_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CAddItemToListView_003Eb__2(ItemsInGroup a)
		{
			return a.ItemID == itemID;
		}

		internal bool _003CAddItemToListView_003Eb__6(Item x)
		{
			return x.ItemID == itemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass157_1
	{
		public List<ItemsInGroup> itemInGroup;

		public _003C_003Ec__DisplayClass157_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass159_0
	{
		public string comboID;

		public _003C_003Ec__DisplayClass159_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnRemove_Click_003Eb__2(ListViewDataItem a)
		{
			if (a.SubItems[5].ToString() == comboID.ToString())
			{
				if (!a[1].ToString().Contains("ADD:"))
				{
					return !a[1].ToString().Contains("OPT: ");
				}
				return false;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass161_0
	{
		public frmGroupsInItemSelection frmSel;

		public _003C_003Ec__DisplayClass161_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CCheckChangeGroupInItem_003Eb__0(Item a)
		{
			return a.ItemID == frmSel.returnItemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass163_0
	{
		public int selectedTag;

		public _003C_003Ec__DisplayClass163_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CRecalculateTaxAndSubtotal_003Eb__0(Item x)
		{
			return x.ItemID == selectedTag;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass163_1
	{
		public Item taxIncludedItems;

		public _003C_003Ec__DisplayClass163_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CRecalculateTaxAndSubtotal_003Eb__2(Item x)
		{
			return x.ItemID == taxIncludedItems.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass175_0
	{
		public string optionComboId;

		public string comboId;

		public int optionItemId;

		public int mainItemId;

		public string optionTab;

		public _003C_003Ec__DisplayClass175_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CShowChangePrice_003Eb__0(ListViewDataItem a)
		{
			if (a.SubItems[11].ToString() == optionComboId && !a.Font.Strikeout && a.SubItems[5].ToString() == comboId)
			{
				if (!a[1].ToString().Contains("ADD:"))
				{
					return !a[1].ToString().Contains("OPT:");
				}
				return false;
			}
			return false;
		}

		internal bool _003CShowChangePrice_003Eb__1(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == optionItemId && x.ItemID == mainItemId)
			{
				return x.Tab.ToUpper() == optionTab.ToUpper();
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass182_0
	{
		public string searchText;

		public _003C_003Ec__DisplayClass182_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass183_0
	{
		public List<Guid> orderListIDs;

		public _003C_003Ec__DisplayClass183_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass183_1
	{
		public Order order;

		public _003C_003Ec__DisplayClass183_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CloadOrder_003Eb__5(Item x)
		{
			return x.ItemID == order.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass186_0
	{
		public string orderNumber;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass186_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CUpdateTableChange_003Eb__0(OrderResult a)
		{
			return a.OrderNumber == orderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass188_0
	{
		public string preCustomer;

		public _003C_003Ec__DisplayClass188_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass189_0
	{
		public Item itemFromDB;

		public Item sold_item;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass189_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CPutOrderToVariables_003Eb__2(ItemsInGroup x)
		{
			return x.ItemID.Value == itemFromDB.ItemID;
		}

		internal void _003CPutOrderToVariables_003Eb__8()
		{
			if (new frmMessageBox(Resources.Do_you_want_to_return_the_item + sold_item.ItemName + Resources._back_to_inventory, Resources.Return_Item_To_Inventory, CustomMessageBoxButtons.YesNo).ShowDialog(_003C_003E4__this) == DialogResult.Yes)
			{
				sold_item.DisableSoldOutItems = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass189_1
	{
		public string[] refundReasons;

		public _003C_003Ec__DisplayClass189_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass189_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CPutOrderToVariables_003Eb__5()
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(refundReasons, _withCustom: true, "Select Void Reason for " + CS_0024_003C_003E8__locals1.sold_item.ItemName, _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: true);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
			{
				CS_0024_003C_003E8__locals1.sold_item.ItemColor = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
				if (MemoryLoadedObjects.ItemSelector.SameForAllValue)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.string_15 = CS_0024_003C_003E8__locals1.sold_item.ItemColor;
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass189_2
	{
		public Order order;

		public _003C_003Ec__DisplayClass189_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CPutOrderToVariables_003Eb__7(Item i)
		{
			return i.ItemID == order.ItemID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass189_3
	{
		public Item batchItem;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass189_3()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CPutOrderToVariables_003Eb__13()
		{
			new NotificationLabel(_003C_003E4__this, batchItem.ItemName + " has qty greater than the qty of it's Expiry Batch", NotificationTypes.Warning).Show();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass193_0
	{
		public int itemid;

		public _003C_003Ec__DisplayClass193_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnChangeTable_Click_003Eb__0(Item a)
		{
			return a.ItemID == itemid;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass193_1
	{
		public string newOrderTable;

		public _003C_003Ec__DisplayClass193_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass204_0
	{
		public int itemId;

		public int selectedComboId;

		public string orderId;

		public Func<ListViewDataItem, bool> _003C_003E9__1;

		public _003C_003Ec__DisplayClass204_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CchangeItemQty_003Eb__0(Item a)
		{
			return a.ItemID == itemId;
		}

		internal bool _003CchangeItemQty_003Eb__1(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == selectedComboId.ToString();
		}

		internal bool _003CchangeItemQty_003Eb__4(int x)
		{
			return x == itemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass204_1
	{
		public ListViewDataItem invetoryItem;

		public _003C_003Ec__DisplayClass204_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CchangeItemQty_003Eb__2(Item a)
		{
			return a.ItemID.ToString() == invetoryItem.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass205_0
	{
		public string orderId;

		public _003C_003Ec__DisplayClass205_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass205_1
	{
		public int itemId;

		public _003C_003Ec__DisplayClass205_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass205_2
	{
		public Order order;

		public _003C_003Ec__DisplayClass205_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass205_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass224_0
	{
		public int itemId;

		public Item item;

		public _003C_003Ec__DisplayClass224_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnFire_Click_003Eb__0(Item a)
		{
			return a.ItemID == itemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass224_1
	{
		public int itemComboId;

		public Func<ListViewDataItem, bool> _003C_003E9__2;

		public _003C_003Ec__DisplayClass224_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnFire_Click_003Eb__2(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == itemComboId.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass231_0
	{
		public string dayOfWeek;

		public _003C_003Ec__DisplayClass231_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass234_0
	{
		public int itemID;

		public int optionComboId;

		public int comboId;

		public _003C_003Ec__DisplayClass234_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnItemOptions_Click_003Eb__0(usp_ItemOptionsResult i)
		{
			if (i.ItemID == itemID && !i.ToBeDeleted)
			{
				if (i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true)
				{
					return true;
				}
				return i.GroupID == 0;
			}
			return false;
		}

		internal bool _003CbtnItemOptions_Click_003Eb__3(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && x.ItemID == itemID)
			{
				if (x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true)
				{
					return true;
				}
				return x.GroupID == 0;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass234_1
	{
		public string itemName;

		public _003C_003Ec__DisplayClass234_0 CS_0024_003C_003E8__locals1;

		public Func<ListViewDataItem, bool> _003C_003E9__5;

		public _003C_003Ec__DisplayClass234_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnItemOptions_Click_003Eb__5(ListViewDataItem a)
		{
			if (a[1].ToString() != itemName && a.SubItems[11].ToString() == CS_0024_003C_003E8__locals1.optionComboId.ToString() && !a.Font.Strikeout && a.SubItems[5].ToString() == CS_0024_003C_003E8__locals1.comboId.ToString())
			{
				if (!a[1].ToString().Contains("ADD:"))
				{
					return a[1].ToString().Contains("OPT: ");
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass234_2
	{
		public SelectedOptionObject selOption;

		public _003C_003Ec__DisplayClass234_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass234_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnItemOptions_Click_003Eb__6(usp_ItemOptionsResult a)
		{
			if (a.ItemWithOptionID == selOption.item_option_id)
			{
				if (a.GroupID > 0 && a.OptionsGroupShowOrderEntry == true)
				{
					return true;
				}
				return a.GroupID == 0;
			}
			return false;
		}

		internal bool _003CbtnItemOptions_Click_003Eb__7(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == selOption.option_itemId && x.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID)
			{
				return x.Tab.ToUpper() == selOption.tag.ToUpper();
			}
			return false;
		}

		internal bool _003CbtnItemOptions_Click_003Eb__8(usp_ItemOptionsResult x)
		{
			if (!x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == selOption.option_itemId)
			{
				return x.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass235_0
	{
		public frmKeyboard keyboard;

		public frmOrderEntry _003C_003E4__this;

		public _003C_003Ec__DisplayClass235_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CbtnSearchItems_Click_1_003Eb__0(Item i)
		{
			if (i.ItemName.ToLower().Contains(keyboard.textEntered.ToLower()) && i.Active && !i.isDeleted)
			{
				return i.ItemClassification == ItemClassifications.Product;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass242_0
	{
		public string bc;

		public _003C_003Ec__DisplayClass242_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CtxtBarcodeSearch_KeyDown_003Eb__1(Item b)
		{
			if (b.UseSmartBarcode)
			{
				return bc == b.Barcode;
			}
			return false;
		}
	}

	private static int int_0;

	private DataManager dataManager_0;

	private Button button_0;

	private Color color_0;

	private Dictionary<int, Item> dictionary_0;

	private decimal decimal_0;

	private decimal decimal_1;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private decimal decimal_2;

	private decimal decimal_3;

	private string string_0;

	private string string_1;

	private decimal decimal_4;

	private List<Tax> list_2;

	private short short_0;

	private short short_1;

	private short short_2;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private string string_13;

	private List<string> list_3;

	private string string_14;

	private int int_1;

	private short short_3;

	private short short_4;

	private bool bool_4;

	public bool isSaved;

	private bool bool_5;

	private short short_5;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private short short_6;

	private short short_7;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private short short_8;

	private short short_9;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private string string_15;

	private FontStyleObject fontStyleObject_0;

	private decimal decimal_5;

	private decimal decimal_6;

	private bool bool_22;

	public int orderOnHoldTime;

	public DateTime? _dateFullfilment;

	public DateTime OrderDateCreated;

	private List<Item> list_4;

	private List<Item> list_5;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private bool bool_26;

	private int int_12;

	private List<OrderResult> list_6;

	[CompilerGenerated]
	private List<string> list_7;

	private List<PossibleCombo> list_8;

	private List<PossibleCombo> list_9;

	private List<int> list_10;

	private List<int> list_11;

	private OrderHelper orderHelper_0;

	private Button btnItemDiscount;

	private Button btnOrdDiscount;

	private Button btnCodeDiscount;

	private Button btnRewardDiscount;

	private int int_13;

	private int int_14;

	private ListViewDataItemGroup listViewDataItemGroup_0;

	private ListViewDataItemGroup listViewDataItemGroup_1;

	private ListViewDataItemGroup listViewDataItemGroup_2;

	private ListViewDataItemGroup listViewDataItemGroup_3;

	private ListViewDataItemGroup listViewDataItemGroup_4;

	private ListViewDataItemGroup listViewDataItemGroup_5;

	private ListViewDataItemGroup listViewDataItemGroup_6;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	private int int_15;

	private IContainer icontainer_1;

	internal Label Label3;

	internal Button btnRemove;

	internal Label label4;

	internal Label label5;

	internal Button btnPay;

	internal Button btnClose;

	internal Button btnClear;

	private FlowLayoutPanel pnlItems;

	private Label lblItemsHeader;

	private FlowLayoutPanel pnlGroups;

	private Label label7;

	private Label label8;

	internal Button btnChangePrice;

	internal Button btnSaveOrder;

	private Label lblTrainingMode;

	private PictureBox pictureBox1;

	private Label lblEmployee;

	internal Button btnSaveClose;

	private FlowLayoutPanel pnlNav;

	private Label label1;

	private Label label2;

	internal Button btnItemOptions;

	internal Button btnInstructions;

	internal Button btnSearchItems;

	private Label lblCustomer;

	private Label lblOrderType;

	public Label lblCategories;

	internal Button btnItemSub;

	internal Button btnSplitMergeBill;

	internal Button btnPrintBill;

	private Label lblSubstitutionMode;

	internal Button btnCustomerInfo;

	internal Label lblTotal;

	internal Label lblTotalTax;

	internal Label lblSubTotal;

	internal Button DpoFeuYkxVM;

	internal Button btnChangeGuests;

	internal Class16 btnOrderDiscount;

	internal Label lblDiscount;

	internal Label label9;

	private Label lblSeat;

	private PictureBox picItemInfo;

	private RadTextBoxControl txtBarcodeSearch;

	private Panel pnlTotals;

	internal CustomListViewTelerik radListItems;

	private VerticalScrollControl verticalScrollControl1;

	internal Button btnChangeQty;

	private PageSetupDialog pageSetupDialog_0;

	private PictureBox picLock;

	private PictureBox picTrash;

	internal Button btnOpenOrders;

	internal System.Windows.Forms.Timer timer_0;

	internal Button btnChangeCourse;

	internal Button ClearBtn;

	internal System.Windows.Forms.Timer timer_1;

	private FlowLayoutPanel pnlQty;

	internal Button btnX2;

	internal Button btn3x;

	internal Button btn4x;

	internal Button btn5x;

	internal Button btn6x;

	internal Button btn7x;

	internal Button btn8x;

	internal Button btn9x;

	internal Button btnFire;

	internal Button GglFeOneCle;

	internal Button btnChangeComboItem;

	private Panel pnlChangeSeat;

	internal Button btnLeft;

	private Label lblTableSeatName;

	internal Button btnRight;

	private Label lblOrderNumber;

	internal Button btnChangeFulfillment;

	internal Button btnOrderNotes;

	public DateTime? dateFullfilment
	{
		get
		{
			return _dateFullfilment;
		}
		set
		{
			_dateFullfilment = value;
			method_17();
		}
	}

	public int moved => int_12;

	public string cus => string_4;

	public string otype => string_5;

	public List<string> OrdersUpdated
	{
		[CompilerGenerated]
		get
		{
			return list_7;
		}
		[CompilerGenerated]
		set
		{
			list_7 = value;
		}
	}

	public frmOrderEntry(string _orderNumber = null, string _customer = null, string _orderType = "Dine In", short _guestCount = 1, string _customerInfoName = "", string _customerInfo = "", int _customerID = 0)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = string.Empty;
		string_1 = string.Empty;
		short_0 = 1;
		short_1 = 1;
		short_2 = 1;
		string_2 = string.Empty;
		string_3 = string.Empty;
		string_10 = string.Empty;
		string_11 = string.Empty;
		string_12 = string.Empty;
		string_13 = "OFF";
		list_3 = new List<string>();
		int_1 = 1;
		short_4 = 1;
		bool_4 = true;
		isSaved = true;
		short_5 = 1;
		bool_6 = true;
		bool_11 = true;
		bool_13 = true;
		bool_16 = true;
		string_15 = "";
		OrderDateCreated = DateTime.Now;
		list_4 = new List<Item>();
		list_5 = new List<Item>();
		bool_26 = true;
		list_6 = new List<OrderResult>();
		list_8 = new List<PossibleCombo>();
		list_9 = new List<PossibleCombo>();
		list_10 = new List<int>();
		list_11 = new List<int>();
		orderHelper_0 = new OrderHelper();
		listViewDataItemGroup_1 = new ListViewDataItemGroup("APPETIZERS");
		listViewDataItemGroup_2 = new ListViewDataItemGroup("BEVERAGES");
		listViewDataItemGroup_3 = new ListViewDataItemGroup("DESSERTS");
		listViewDataItemGroup_4 = new ListViewDataItemGroup("MAINS/ENTREES");
		listViewDataItemGroup_5 = new ListViewDataItemGroup("SIDES");
		listViewDataItemGroup_6 = new ListViewDataItemGroup("UNCATEGORIZED");
		base._002Ector();
		InitializeComponent_1();
		btnFire.Visible = true;
		new FormHelper().ResizeButtonFonts(this);
		fontStyleObject_0 = SettingsHelper.GetSettingFontStyleValues("font_size_item_groups_oe");
		picTrash.Image = btnClear.Image;
		int_13 = _customerID;
		method_9();
		LoadFormData(_orderNumber, _customer, _orderType, _guestCount, int_13, _customerInfoName, _customerInfo, resetComboId: true, 1);
		Rectangle bounds = AppSettings.MainScreen.Bounds;
		base.WindowState = FormWindowState.Maximized;
		base.Size = new Size(bounds.Width, bounds.Height);
		SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
		base.StartPosition = FormStartPosition.Manual;
		btnOpenOrders.Location = btnChangeGuests.Location;
		verticalScrollControl1.ConnectedRadListView = radListItems;
		method_8();
		btnPay.Tag = Color.FromArgb(80, 203, 116);
		btnOrderDiscount.Tag = Color.FromArgb(176, 124, 219);
		btnRemove.Tag = Color.SandyBrown;
		btnInstructions.Tag = Color.FromArgb(53, 152, 220);
		btnItemSub.Tag = Color.FromArgb(61, 142, 185);
		btnItemOptions.Tag = Color.FromArgb(50, 119, 155);
		btnChangeQty.Tag = Color.FromArgb(176, 124, 219);
		btnChangePrice.Tag = Color.FromArgb(147, 101, 184);
		btnClear.Tag = Color.FromArgb(214, 142, 81);
		DpoFeuYkxVM.Tag = Color.FromArgb(50, 119, 155);
		btnSaveClose.Tag = Color.FromArgb(65, 168, 95);
		btnSplitMergeBill.Tag = Color.FromArgb(117, 81, 147);
		btnPrintBill.Tag = Color.FromArgb(214, 142, 81);
		btnCustomerInfo.Tag = Color.FromArgb(65, 168, 95);
		btnChangeGuests.Tag = Color.FromArgb(53, 152, 220);
		method_5();
	}

	public void ReloadOrder(List<string> orderNumbersToReload)
	{
		if (!bool_20 && !string.IsNullOrEmpty(string_3) && orderNumbersToReload.Contains(string_3))
		{
			loadOrderByOrderNumber(string_3);
		}
	}

	public void RefreshGroupsAndItems()
	{
		method_13();
		pnlItems.Controls.Clear();
	}

	public void LoadFormData(string _orderNumber = null, string _customer = null, string _orderType = "Dine In", short _guestCount = 1, int _customerID = 0, string _customerInfoName = "", string _customerInfo = "", bool resetComboId = true, short assignedSeatNum = 1)
	{
		pnlItems.Controls.Clear();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("restaurant_mode");
		if (SettingsHelper.GetSettingValueByKey("course_selection") == "ON" && settingValueByKey == "Dine In" && _orderType == OrderTypes.DineIn)
		{
			ListViewDataItemGroup listViewDataItemGroup = listViewDataItemGroup_1;
			ListViewDataItemGroup listViewDataItemGroup2 = listViewDataItemGroup_2;
			ListViewDataItemGroup listViewDataItemGroup3 = listViewDataItemGroup_3;
			ListViewDataItemGroup listViewDataItemGroup4 = listViewDataItemGroup_4;
			ListViewDataItemGroup listViewDataItemGroup5 = listViewDataItemGroup_5;
			Color color = (listViewDataItemGroup_6.BackColor = Color.WhiteSmoke);
			Color color3 = (listViewDataItemGroup5.BackColor = color);
			Color color5 = (listViewDataItemGroup4.BackColor = color3);
			Color color7 = (listViewDataItemGroup3.BackColor = color5);
			Color backColor = (listViewDataItemGroup2.BackColor = color7);
			listViewDataItemGroup.BackColor = backColor;
			ListViewDataItemGroup listViewDataItemGroup6 = listViewDataItemGroup_1;
			ListViewDataItemGroup listViewDataItemGroup7 = listViewDataItemGroup_2;
			ListViewDataItemGroup listViewDataItemGroup8 = listViewDataItemGroup_3;
			ListViewDataItemGroup listViewDataItemGroup9 = listViewDataItemGroup_4;
			ListViewDataItemGroup listViewDataItemGroup10 = listViewDataItemGroup_5;
			Font font2 = (listViewDataItemGroup_6.Font = new Font(radListItems.Font.FontFamily, 14f, FontStyle.Italic));
			Font font4 = (listViewDataItemGroup10.Font = font2);
			Font font6 = (listViewDataItemGroup9.Font = font4);
			Font font8 = (listViewDataItemGroup8.Font = font6);
			Font font10 = (listViewDataItemGroup7.Font = font8);
			listViewDataItemGroup6.Font = font10;
			ListViewDataItemGroup listViewDataItemGroup11 = listViewDataItemGroup_1;
			ListViewDataItemGroup listViewDataItemGroup12 = listViewDataItemGroup_2;
			ListViewDataItemGroup listViewDataItemGroup13 = listViewDataItemGroup_3;
			ListViewDataItemGroup listViewDataItemGroup14 = listViewDataItemGroup_4;
			ListViewDataItemGroup listViewDataItemGroup15 = listViewDataItemGroup_5;
			listViewDataItemGroup_6.Expanded = true;
			listViewDataItemGroup15.Expanded = true;
			listViewDataItemGroup14.Expanded = true;
			listViewDataItemGroup13.Expanded = true;
			listViewDataItemGroup12.Expanded = true;
			listViewDataItemGroup11.Expanded = true;
			ListViewDataItemGroup listViewDataItemGroup16 = listViewDataItemGroup_1;
			ListViewDataItemGroup listViewDataItemGroup17 = listViewDataItemGroup_2;
			ListViewDataItemGroup listViewDataItemGroup18 = listViewDataItemGroup_3;
			ListViewDataItemGroup listViewDataItemGroup19 = listViewDataItemGroup_4;
			ListViewDataItemGroup listViewDataItemGroup20 = listViewDataItemGroup_5;
			listViewDataItemGroup_6.Visible = false;
			listViewDataItemGroup20.Visible = false;
			listViewDataItemGroup19.Visible = false;
			listViewDataItemGroup18.Visible = false;
			listViewDataItemGroup17.Visible = false;
			listViewDataItemGroup16.Visible = false;
			ListViewDataItemGroup listViewDataItemGroup21 = listViewDataItemGroup_1;
			ListViewDataItemGroup listViewDataItemGroup22 = listViewDataItemGroup_2;
			ListViewDataItemGroup listViewDataItemGroup23 = listViewDataItemGroup_3;
			ListViewDataItemGroup listViewDataItemGroup24 = listViewDataItemGroup_4;
			ListViewDataItemGroup listViewDataItemGroup25 = listViewDataItemGroup_5;
			listViewDataItemGroup_6.Enabled = false;
			listViewDataItemGroup25.Enabled = false;
			listViewDataItemGroup24.Enabled = false;
			listViewDataItemGroup23.Enabled = false;
			listViewDataItemGroup22.Enabled = false;
			listViewDataItemGroup21.Enabled = false;
			radListItems.ShowGroups = true;
			listViewDataItemGroup_1.BackColor = Color.Pink;
			if (!radListItems.Groups.Contains(listViewDataItemGroup_2))
			{
				radListItems.Groups.Add(listViewDataItemGroup_2);
			}
			if (!radListItems.Groups.Contains(listViewDataItemGroup_1))
			{
				radListItems.Groups.Add(listViewDataItemGroup_1);
			}
			if (!radListItems.Groups.Contains(listViewDataItemGroup_4))
			{
				radListItems.Groups.Add(listViewDataItemGroup_4);
			}
			if (!radListItems.Groups.Contains(listViewDataItemGroup_3))
			{
				radListItems.Groups.Add(listViewDataItemGroup_3);
			}
			if (!radListItems.Groups.Contains(listViewDataItemGroup_5))
			{
				radListItems.Groups.Add(listViewDataItemGroup_5);
			}
			if (!radListItems.Groups.Contains(listViewDataItemGroup_6))
			{
				radListItems.Groups.Add(listViewDataItemGroup_6);
			}
			Button button = btnChangeCourse;
			btnFire.Visible = true;
			button.Visible = true;
		}
		else
		{
			radListItems.Groups.Clear();
			Button button2 = btnChangeCourse;
			btnFire.Visible = false;
			button2.Visible = false;
			radListItems.ShowGroups = false;
		}
		if (_orderType == OrderTypes.ToGo)
		{
			lblSeat.Visible = false;
		}
		else
		{
			lblSeat.Visible = true;
		}
		bool_10 = false;
		bool_21 = false;
		OrderDateCreated = DateTime.Now;
		short_0 = 1;
		short_1 = 1;
		short_2 = 1;
		short_3 = 0;
		int_13 = _customerID;
		bool_4 = resetComboId;
		string_13 = SettingsHelper.GetSettingValueByKey("upc_scanning");
		if (string_13 == "OFF")
		{
			txtBarcodeSearch.Visible = false;
			pnlItems.Height = lblCategories.Location.Y - lblItemsHeader.Bottom - 2;
			pnlItems.Location = new Point(pnlItems.Location.X, txtBarcodeSearch.Location.Y);
		}
		else
		{
			txtBarcodeSearch.Visible = true;
			pnlItems.Height = lblCategories.Location.Y - txtBarcodeSearch.Bottom - 2;
			pnlItems.Location = new Point(pnlItems.Location.X, txtBarcodeSearch.Bottom);
			txtBarcodeSearch.Select();
		}
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			lblSubTotal.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblDiscount.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTotalTax.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			lblTotal.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
		}
		lblOrderNumber.Text = "New Order";
		lblSeat.Text = Resources.SEAT_1;
		int_1 = 1;
		dataManager_0 = new DataManager();
		dictionary_0 = new Dictionary<int, Item>();
		list_2 = dataManager_0.GetTax();
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		string_5 = _orderType;
		string_11 = _orderType;
		string_4 = _customer;
		if ((string_5 == OrderTypes.DineIn || string_5 == OrderTypes.ToGo) && settingValueByKey == "Quick Service")
		{
			string_8 = "Walk In";
		}
		else if (string_5 != OrderTypes.DineIn && string_5 != OrderTypes.ToGo)
		{
			string_8 = string_4;
		}
		else
		{
			string_8 = "";
		}
		string_10 = _customer;
		string_6 = _customerInfo;
		radListItems.CellFormatting += radListItems_CellFormatting;
		btnPay.Enabled = true;
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.customer = string_4;
			MemoryLoadedObjects.OrderEntrySecondScreen.orderType = string_5;
		}
		if (!string.IsNullOrEmpty(_orderNumber))
		{
			loadOrderByOrderNumber(_orderNumber);
		}
		else
		{
			method_34();
		}
		if (string_5 == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
		{
			if (string.IsNullOrEmpty(_orderNumber))
			{
				int_1 = assignedSeatNum;
				lblSeat.Text = Resources.SEAT + int_1;
			}
			pnlChangeSeat.Visible = true;
			lblTableSeatName.Text = string_4 + " - " + lblSeat.Text;
			if (lblSeat.Text.Contains(Resources.SEAT_1))
			{
				btnLeft.Enabled = false;
			}
			else
			{
				btnLeft.Enabled = true;
			}
		}
		else
		{
			pnlChangeSeat.Visible = false;
		}
		if (settingValueByKey == "Quick Service")
		{
			btnChangeGuests.Enabled = false;
		}
		else
		{
			btnChangeGuests.Enabled = true;
		}
		if (!string_5.Equals(OrderTypes.PickUp) && !string_5.Equals(OrderTypes.ToGo))
		{
			if (string_5.Equals(OrderTypes.Delivery))
			{
				btnChangeGuests.Enabled = false;
				Button button3 = btnChangeCourse;
				btnFire.Visible = false;
				button3.Visible = false;
				btnChangeGuests.BackColor = Color.Gray;
			}
			else if (string_5.Equals(OrderTypes.MakeToStock))
			{
				btnPay.Enabled = false;
			}
			else if (!string.IsNullOrEmpty(string_4))
			{
				if (_guestCount == 0)
				{
					_guestCount = GuestMethods.GetCurrentTableGuestCapacity(string_4.Replace("Table ", ""));
				}
				short_5 = _guestCount;
				GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), short_5, Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
			}
		}
		else
		{
			btnChangeGuests.Enabled = false;
			Button button4 = btnChangeCourse;
			btnFire.Visible = false;
			button4.Visible = false;
			btnChangeGuests.BackColor = Color.Gray;
			DpoFeuYkxVM.Text = Resources.MOVE_TO_A_TABLE;
		}
		bool_16 = ((SettingsHelper.GetSettingValueByKey("print_chit_change_cancel") == "ON") ? true : false);
		bool_9 = ((SettingsHelper.GetSettingValueByKey("add_solo_option_main") == "ON") ? true : false);
		bool_17 = ((SettingsHelper.GetSettingValueByKey("prompt_void_orders_reason") == "ON") ? true : false);
		bool_18 = ((SettingsHelper.GetSettingValueByKey("item_button_price") == "ON") ? true : false);
		decimal_6 = SettingsHelper.DeliveryFeeSettings.GetDeliveryFeeSettings().FreeDeliveryOver;
		bool_19 = ((SettingsHelper.GetSettingValueByKey("capitalize_item_group_text") == "ON") ? true : false);
		string_7 = _customerInfoName;
		string_12 = _customerInfoName;
		fontStyleObject_0 = SettingsHelper.GetSettingFontStyleValues("font_size_item_groups_oe");
		bool_22 = false;
		if (string_5.Equals(OrderTypes.Delivery) && !string.IsNullOrEmpty(string_6))
		{
			decimal_5 = DeliveryMethods.GetDeliveryFee(string_6.Replace(Resources.DELIVER_TO, ""));
		}
		else
		{
			decimal_5 = default(decimal);
		}
		method_4();
		if (!string_5.Equals(OrderTypes.Delivery) && (!string_5.Equals(OrderTypes.PickUp) || radListItems.Items.Count <= 0))
		{
			if (string_5.Equals(OrderTypes.DineIn) && bool_10)
			{
				Button button5 = btnSaveOrder;
				btnSaveClose.Enabled = true;
				button5.Enabled = true;
			}
			else
			{
				Button button6 = btnSaveOrder;
				btnSaveClose.Enabled = false;
				button6.Enabled = false;
			}
		}
		else
		{
			Button button7 = btnSaveOrder;
			btnSaveClose.Enabled = true;
			button7.Enabled = true;
		}
		ClearBtn.Enabled = false;
		Button button8 = btnItemSub;
		btnItemSub.Visible = false;
		button8.Enabled = false;
		btnItemSub.BackColor = Color.Gray;
		Button button9 = btnItemOptions;
		btnItemSub.Visible = false;
		button9.Enabled = false;
		btnItemOptions.BackColor = Color.Gray;
		btnChangeQty.BackColor = Color.Gray;
		int_14 = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
	}

	private void method_3()
	{
		orderOnHoldTime = 0;
		dateFullfilment = null;
		decimal_4 = default(decimal);
		isSaved = true;
		bool_25 = false;
		list_4 = new List<Item>();
		list_5 = new List<Item>();
		list_11 = new List<int>();
		if (bool_4)
		{
			short_4 = 1;
		}
		bool_2 = false;
		btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
		bool_0 = false;
		string_0 = "";
		string_1 = "";
		decimal_2 = (decimal_3 = 0m);
		decimal_1 = default(decimal);
		OrderDateCreated = DateTime.Now;
	}

	private void method_4()
	{
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			short_6 = 4;
			short_7 = 4;
			short_8 = 4;
			short_9 = 3;
		}
		else
		{
			short_6 = Convert.ToInt16(SettingsHelper.GetSettingValueByKey("items_number_of_columns"));
			short_7 = Convert.ToInt16(SettingsHelper.GetSettingValueByKey("items_number_of_rows"));
			short_8 = Convert.ToInt16(SettingsHelper.GetSettingValueByKey("groups_number_of_columns"));
			short_9 = Convert.ToInt16(SettingsHelper.GetSettingValueByKey("groups_number_of_rows"));
		}
		bool_6 = ((SettingsHelper.GetSettingValueByKey("items_paging") == "ON") ? true : false);
		bool_11 = ((SettingsHelper.GetSettingValueByKey("groups_paging") == "ON") ? true : false);
		bool_7 = ((SettingsHelper.GetSettingValueByKey("item_images") == "ON") ? true : false);
		bool_12 = ((SettingsHelper.GetSettingValueByKey("show_placeholder_buttons") == "ON") ? true : false);
		list_10.Clear();
		list_8.Clear();
		list_11.Clear();
		lblOrderType.Text = string_5;
		method_58();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("restaurant_mode");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (settingValueByKey == "Quick Service")
			{
				DpoFeuYkxVM.Text = Resources.CHANGE_ORDER_TYPE;
				DpoFeuYkxVM.Enabled = true;
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && (string_5 == OrderTypes.DineIn || string_5 == OrderTypes.ToGo))
				{
					btnSaveClose.Enabled = false;
				}
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF")
				{
					if (string_5 != OrderTypes.DineIn && string_5 != OrderTypes.ToGo)
					{
						btnSaveClose.Text = "SAVE && NEW";
						btnSaveClose.Enabled = true;
					}
					else
					{
						btnSaveClose.Text = "SEND && CLOSE";
					}
				}
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.DefaultOrderTypes.Split(',').Count() == 1)
				{
					DpoFeuYkxVM.Enabled = false;
				}
				btnOpenOrders.Location = btnChangeGuests.Location;
			}
		}
		else
		{
			settingValueByKey = "Quick Service";
		}
		if (radListItems.Items.Count > 0 && !string.IsNullOrEmpty(string_3))
		{
			btnClear.Text = Resources.VOID_ORDER;
			btnClear.Image = picTrash.Image;
			btnClear.Enabled = radListItems.Items.Count > 0;
		}
		else if (string_5.Equals(OrderTypes.DineIn) && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
		{
			btnClear.Text = Resources.CLEAR_TABLE;
			btnClear.Image = picTrash.Image;
		}
		else
		{
			method_29();
		}
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("restaurant_capacity");
		if (!string.IsNullOrEmpty(settingValueByKey2) && settingValueByKey2 == "OFF")
		{
			btnChangeGuests.Enabled = false;
			bool_13 = false;
		}
		bool_8 = ((SettingsHelper.GetSettingValueByKey("prompt_option_child_item") == "ON") ? true : false);
		btnRemove.Enabled = false;
		btnInstructions.Enabled = false;
		btnChangeQty.Enabled = false;
		method_53(bool_30: false);
		btnChangePrice.Enabled = false;
		method_57();
		method_7();
	}

	private void method_5()
	{
		if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF")
		{
			btnOpenOrders.Location = btnChangeGuests.Location;
			btnOpenOrders.Visible = true;
			if (MemoryLoadedObjects.DefaultOrderTypes.Split(',').Count() == 1)
			{
				DpoFeuYkxVM.Enabled = false;
			}
		}
		else
		{
			btnOpenOrders.Visible = false;
		}
	}

	private void frmOrderEntry_Load(object sender, EventArgs e)
	{
	}

	public bool ReinitializeOrderEntryByOrderType(string SystemOrderType = "Dine In")
	{
		if (!string.IsNullOrEmpty(MemoryLoadedObjects.DefaultOrderTypes))
		{
			List<string> list = MemoryLoadedObjects.DefaultOrderTypes.Split(',').ToList();
			string text = list[0];
			bool showOpenOrder = false;
			if (text == OrderTypes.PickUp)
			{
				showOpenOrder = true;
			}
			if (list.Count == 1)
			{
				text = list[0];
			}
			else if (list.Count != 2)
			{
				text = ((!list.Contains(SystemOrderType)) ? list[0] : SystemOrderType);
			}
			else
			{
				list.Add(">> VIEW OPEN ORDERS <<");
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
				MemoryLoadedObjects.ItemSelector.LoadForm(list.ToArray(), _withCustom: false, Resources.Select_an_Order_Type, _IsMultipleSelect: false, _autoClose: true);
				switch (MemoryLoadedObjects.ItemSelector.ShowDialog(this))
				{
				case DialogResult.OK:
					break;
				case DialogResult.Yes:
					return false;
				default:
					AuthMethods.LogOutUser();
					return false;
				}
				if (MemoryLoadedObjects.ItemSelector.SingleSelectedItem == ">> VIEW OPEN ORDERS <<")
				{
					if (base.Visible)
					{
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
						MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL", showOEOnClose: false);
						MemoryLoadedObjects.QuickService.Show();
					}
					return true;
				}
				text = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
			}
			if (!(text == OrderTypes.PickUp) && !(text == OrderTypes.Delivery) && !(text == OrderTypes.Catering))
			{
				string_11 = (string_5 = (SystemOrderType = text));
				LoadFormData(null, Resources.Walk_In, SystemOrderType, 1, 0, "", "", resetComboId: true, 1);
				method_6();
				Show();
			}
			else
			{
				new OrderHelper().TakeOutDeliveryFlow(text, bool_0: false, this, showOpenOrder);
				if (MemoryLoadedObjects.CustomersMini != null)
				{
					int_13 = MemoryLoadedObjects.CustomersMini.returnCustomerId;
				}
			}
		}
		else
		{
			string_11 = (string_5 = SystemOrderType);
			LoadFormData(null, Resources.Walk_In, SystemOrderType, 1, 0, "", "", resetComboId: true, 1);
			method_6();
			Show();
		}
		return false;
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
		if (base.Visible)
		{
			method_6();
		}
	}

	private void method_6()
	{
		if (int_11 == 0)
		{
			int_11 = pnlGroups.Height;
		}
		int num = 56;
		if (short_9 == 0)
		{
			short_9 = (short)((int_11 - 9) / num);
			if (short_9 > 9)
			{
				short_9 = 9;
			}
		}
		if (short_9 > 0 && short_8 > 0)
		{
			pnlGroups.Height = num * short_9 + 9;
		}
		int num2 = ((short_9 == 0) ? int_11 : pnlGroups.Height);
		int_8 = ((short_9 > 0) ? short_9 : ((int_11 - 9) / num));
		if (int_8 > 9)
		{
			int_8 = 9;
		}
		if ((short_7 > 0 && short_6 > 0) || (short_9 > 0 && short_8 > 0))
		{
			pnlItems.Height = base.Height - num2 - 80 - 3;
		}
		lblCategories.Location = new Point(lblCategories.Location.X, pnlItems.Location.Y + pnlItems.Height);
		pnlGroups.Location = new Point(pnlGroups.Location.X, lblCategories.Location.Y + lblCategories.Height);
		pnlGroups.Height = base.Bottom - lblCategories.Bottom;
		btnOrderNotes.Location = new Point(btnOrderNotes.Location.X, lblCategories.Location.Y);
		if (bool_26)
		{
			method_13();
		}
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		radListItems.SmallImageList = imageList;
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.SmallImageList = imageList;
		}
		method_36();
		method_46();
		method_5();
		if (bool_26)
		{
			bool_26 = false;
		}
		if (int_10 == 0)
		{
			int_10 = radListItems.Height;
		}
		radListItems.Height = int_10 - (pnlChangeSeat.Visible ? pnlChangeSeat.Height : 0);
		VerticalScrollControl verticalScrollControl = verticalScrollControl1;
		int num4 = (verticalScrollControl1.inputedHeight = int_10 - pnlQty.Height);
		verticalScrollControl.Height = num4;
		verticalScrollControl1.RefreshSize();
	}

	private void radListItems_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
	{
		if ((e.CellElement.Data.HeaderText == "Price" || e.CellElement.Data.HeaderText == "Ext. Price") && e.CellElement is DetailListViewDataCellElement)
		{
			e.CellElement.TextAlignment = ContentAlignment.MiddleRight;
		}
	}

	private void method_7()
	{
		int num = 13;
		if (btnItemSub.Visible)
		{
			num++;
		}
		decimal num2 = Convert.ToDecimal(pnlNav.Height) - 4m;
		int num3 = (int)Math.Round(Convert.ToDecimal((num2 - (decimal)(num - 1)) / (decimal)num), 0);
		foreach (Button control in pnlNav.Controls)
		{
			if (control.Name == "btnClose")
			{
				control.Height = (int)((decimal)num3 + (num2 - (decimal)(num3 * num))) - 5;
			}
			else
			{
				control.Height = num3;
			}
		}
		if (btnItemDiscount != null)
		{
			btnItemDiscount.Font = btnOrderDiscount.Font;
			btnItemDiscount.Size = btnOrderDiscount.Size;
		}
		if (btnOrdDiscount != null)
		{
			btnOrdDiscount.Font = btnOrderDiscount.Font;
			btnOrdDiscount.Size = btnOrderDiscount.Size;
		}
		if (btnCodeDiscount != null)
		{
			btnCodeDiscount.Font = btnOrderDiscount.Font;
			btnCodeDiscount.Size = btnOrderDiscount.Size;
		}
		if (btnRewardDiscount != null)
		{
			btnRewardDiscount.Font = btnOrderDiscount.Font;
			btnRewardDiscount.Size = btnOrderDiscount.Size;
		}
	}

	private void method_8()
	{
		string value = "";
		CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
		if (cardProcessorSettingActiveOnly != null)
		{
			value = cardProcessorSettingActiveOnly.ApiKey;
		}
		if (string.IsNullOrEmpty(value))
		{
			if (btnRewardDiscount != null)
			{
				btnOrderDiscount.method_1(btnRewardDiscount);
				btnRewardDiscount = null;
			}
		}
		else if (btnRewardDiscount == null)
		{
			btnRewardDiscount = new Button();
			btnRewardDiscount.Size = btnOrderDiscount.Size;
			btnRewardDiscount.ForeColor = btnOrderDiscount.ForeColor;
			btnRewardDiscount.Font = btnOrderDiscount.Font;
			btnRewardDiscount.FlatStyle = btnOrderDiscount.FlatStyle;
			btnRewardDiscount.BackColor = Color.FromArgb(147, 101, 184);
			btnRewardDiscount.Name = "btnRewardDiscount";
			btnRewardDiscount.Text = "REWARD REDEMPTION";
			btnRewardDiscount.FlatAppearance.BorderSize = 1;
			btnRewardDiscount.FlatAppearance.BorderColor = Color.Black;
			btnRewardDiscount.Click += btnRewardDiscount_Click;
			btnOrderDiscount.method_0(btnRewardDiscount);
		}
	}

	private void method_9()
	{
		if (btnItemDiscount == null)
		{
			btnItemDiscount = new Button();
			btnItemDiscount.Size = btnOrderDiscount.Size;
			btnItemDiscount.ForeColor = btnOrderDiscount.ForeColor;
			btnItemDiscount.Font = btnOrderDiscount.Font;
			btnItemDiscount.FlatStyle = btnOrderDiscount.FlatStyle;
			btnItemDiscount.BackColor = Color.FromArgb(147, 101, 184);
			btnItemDiscount.Name = "btnItemDiscount";
			btnItemDiscount.Text = "Item Discount";
			btnItemDiscount.FlatAppearance.BorderSize = 1;
			btnItemDiscount.FlatAppearance.BorderColor = Color.Black;
			btnItemDiscount.Click += btnChangePrice_Click;
			btnItemDiscount.EnabledChanged += btnRight_EnabledChanged;
			btnOrderDiscount.method_0(btnItemDiscount);
		}
		if (btnOrdDiscount == null)
		{
			btnOrdDiscount = new Button();
			btnOrdDiscount.Size = btnOrderDiscount.Size;
			btnOrdDiscount.ForeColor = btnOrderDiscount.ForeColor;
			btnOrdDiscount.Font = btnOrderDiscount.Font;
			btnOrdDiscount.FlatStyle = btnOrderDiscount.FlatStyle;
			btnOrdDiscount.BackColor = Color.FromArgb(147, 101, 184);
			btnOrdDiscount.Name = "btnOrdDiscount";
			btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
			btnOrdDiscount.FlatAppearance.BorderSize = 1;
			btnOrdDiscount.FlatAppearance.BorderColor = Color.Black;
			btnOrdDiscount.Click += btnOrdDiscount_Click;
			btnOrderDiscount.method_0(btnOrdDiscount);
		}
		if (btnCodeDiscount == null)
		{
			btnCodeDiscount = new Button();
			btnCodeDiscount.Size = btnOrderDiscount.Size;
			btnCodeDiscount.ForeColor = btnOrderDiscount.ForeColor;
			btnCodeDiscount.Font = btnOrderDiscount.Font;
			btnCodeDiscount.FlatStyle = btnOrderDiscount.FlatStyle;
			btnCodeDiscount.BackColor = Color.FromArgb(147, 101, 184);
			btnCodeDiscount.Name = "btnCodeDiscount";
			btnCodeDiscount.Text = "DISCOUNT CODES";
			btnCodeDiscount.FlatAppearance.BorderSize = 1;
			btnCodeDiscount.FlatAppearance.BorderColor = Color.Black;
			btnCodeDiscount.Click += btnCodeDiscount_Click;
			btnOrderDiscount.method_0(btnCodeDiscount);
		}
	}

	private void btnRewardDiscount_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(radListItems.SelectedItem[2].ToString()) && !(Convert.ToDecimal(radListItems.SelectedItem[2].ToString()) == 0m))
		{
			decimal selectedItemAmount = default(decimal);
			if (radListItems.SelectedItems.Count > 0)
			{
				selectedItemAmount = Convert.ToDecimal(radListItems.SelectedItem[2].ToString());
			}
			if (TapMangoHelper.ProcessTapMangoLoyalty(this, null, decimal_0, "", selectedItemAmount) && TapMangoHelper.DiscountAmount > 0m)
			{
				bool_2 = true;
				btnOrdDiscount.Text = Resources.REMOVE_ORDER_DISCOUNT;
				bool_0 = true;
				string_0 = "Reward Redemption";
				string_1 = DiscountTypes.DollarAmount;
				decimal_2 = TapMangoHelper.DiscountAmount / decimal_0;
				decimal_3 = TapMangoHelper.DiscountAmount;
				isSaved = false;
				RecalculateTaxAndSubtotal();
			}
		}
		else
		{
			new NotificationLabel(this, "Item has no price, please select an item that has price greater than 0", NotificationTypes.Warning).Show();
		}
	}

	private void btnCodeDiscount_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, "btnOrderDiscount") == null)
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Discount Code");
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		DiscountCode discountCode = new GClass6().DiscountCodes.Where((DiscountCode a) => a.Code == MemoryLoadedObjects.Keyboard.textEntered && a.StartDate.Date <= DateTime.Now && a.EndDate.AddDays(1.0).Date >= DateTime.Now && a.AvailableInStore == true).FirstOrDefault();
		if (discountCode != null)
		{
			int num = 0;
			if (discountCode.DiscountCodeCount == -1)
			{
				num = -1;
			}
			else if (discountCode.DiscountCodeCount - discountCode.UsedCount > 0)
			{
				num = discountCode.DiscountCodeCount - discountCode.UsedCount;
			}
			if (num == 0)
			{
				new NotificationLabel(this, "No Discount Code", NotificationTypes.Warning).Show();
				return;
			}
			bool_2 = true;
			btnOrdDiscount.Text = Resources.REMOVE_ORDER_DISCOUNT;
			bool_0 = true;
			string_0 = "Discount Code Used:" + discountCode.Code;
			if (discountCode.String_0 == "percentage")
			{
				decimal_2 = discountCode.DiscountAmount / Convert.ToDecimal(100);
				string_1 = DiscountTypes.Percentage;
			}
			else
			{
				if (discountCode.DiscountAmount > decimal_0)
				{
					new frmMessageBox(Resources.Discount_cannot_be_more_than_t).ShowDialog(this);
					base.DialogResult = DialogResult.None;
					return;
				}
				if (decimal_0 > 0m)
				{
					decimal_2 = discountCode.DiscountAmount / decimal_0;
					decimal_3 = discountCode.DiscountAmount;
					string_1 = DiscountTypes.DollarAmount;
				}
			}
			RecalculateTaxAndSubtotal();
			new NotificationLabel(this, "Discount Code " + discountCode.Code + " applied.", NotificationTypes.Success).Show();
		}
		else
		{
			new NotificationLabel(this, "No Discount Code", NotificationTypes.Warning).Show();
		}
	}

	private Button method_10(string string_16, Color color_1, string string_17, EventHandler eventHandler_0, bool bool_30 = false)
	{
		_003C_003Ec__DisplayClass135_0 _003C_003Ec__DisplayClass135_ = new _003C_003Ec__DisplayClass135_0();
		_003C_003Ec__DisplayClass135_.Id = string_17;
		_003C_003Ec__DisplayClass135_._003C_003E4__this = this;
		Button button = new Button();
		if (bool_19)
		{
			button.Text = string_16.ToUpper().Replace("&", "&&");
		}
		else
		{
			button.Text = string_16.Replace("&", "&&");
		}
		button.Name = button.Text;
		button.Tag = _003C_003Ec__DisplayClass135_.Id;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.BackColor = color_1;
		button.Click += eventHandler_0;
		if (bool_30 && !_003C_003Ec__DisplayClass135_.Id.Equals("0"))
		{
			_003C_003Ec__DisplayClass135_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass135_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass135_;
			CS_0024_003C_003E8__locals0.timer = new System.Windows.Forms.Timer();
			CS_0024_003C_003E8__locals0.timer.Interval = 800;
			button.MouseDown += delegate
			{
				CS_0024_003C_003E8__locals0.timer.Start();
			};
			button.MouseUp += delegate
			{
				CS_0024_003C_003E8__locals0.timer.Stop();
			};
			button.MouseLeave += delegate
			{
				CS_0024_003C_003E8__locals0.timer.Stop();
			};
			CS_0024_003C_003E8__locals0.timer.Tick += delegate
			{
				CS_0024_003C_003E8__locals0.timer.Stop();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Id))
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.method_11(Convert.ToInt16(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Id));
				}
			};
		}
		button.Margin = new Padding(0, 1, 1, 0);
		if (bool_30)
		{
			int num = (int_6 = ((int_6 == 0) ? method_12(bool_30: false) : int_6));
			int num2 = ((short_7 <= 0) ? (int_7 = ((int_7 == 0) ? ((int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlItems.Height - 4) / 4m))) : int_7)) : (int_7 = ((int_7 == 0) ? ((int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlItems.Height - 4) / (decimal)short_7))) : int_7)));
			button.Size = new Size(num, num2);
			button.Font = new Font(FontFamily.GenericSansSerif, fontStyleObject_0.Size, (FontStyle)Convert.ToInt32(fontStyleObject_0.Style));
			button.ForeColor = HelperMethods.GetColor(fontStyleObject_0.Color);
		}
		else
		{
			button.Size = new Size(int_5 = ((int_5 == 0) ? method_12(bool_30: true) : int_5), int_4 = ((int_4 != 0 || int_8 == 0) ? int_4 : ((int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlGroups.Height - 4) / (decimal)int_8)))));
			button.Font = new Font(FontFamily.GenericSansSerif, fontStyleObject_0.Size, (FontStyle)Convert.ToInt32(fontStyleObject_0.Style));
			button.ForeColor = HelperMethods.GetColor(fontStyleObject_0.Color);
		}
		return button;
	}

	private void method_11(short short_10)
	{
		_003C_003Ec__DisplayClass136_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass136_0();
		CS_0024_003C_003E8__locals0.Id = short_10;
		bool_23 = false;
		byte[] array = new byte[0];
		new GClass6();
		ItemImage itemImage = MemoryLoadedObjects.all_itemimages.Where((ItemImage m) => m.ItemID == CS_0024_003C_003E8__locals0.Id).FirstOrDefault();
		array = ((itemImage == null || itemImage.ImageAsText == null || !(itemImage.ImageAsText != "NoImage")) ? Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAMgAAACWCAYAAACb3McZAAAACXBIWXMAAAsTAAALEwEAmpwYAAAKT2lDQ1BQaG90b3Nob3AgSUNDIHByb2ZpbGUAAHjanVNnVFPpFj333vRCS4iAlEtvUhUIIFJCi4AUkSYqIQkQSoghodkVUcERRUUEG8igiAOOjoCMFVEsDIoK2AfkIaKOg6OIisr74Xuja9a89+bN/rXXPues852zzwfACAyWSDNRNYAMqUIeEeCDx8TG4eQuQIEKJHAAEAizZCFz/SMBAPh+PDwrIsAHvgABeNMLCADATZvAMByH/w/qQplcAYCEAcB0kThLCIAUAEB6jkKmAEBGAYCdmCZTAKAEAGDLY2LjAFAtAGAnf+bTAICd+Jl7AQBblCEVAaCRACATZYhEAGg7AKzPVopFAFgwABRmS8Q5ANgtADBJV2ZIALC3AMDOEAuyAAgMADBRiIUpAAR7AGDIIyN4AISZABRG8lc88SuuEOcqAAB4mbI8uSQ5RYFbCC1xB1dXLh4ozkkXKxQ2YQJhmkAuwnmZGTKBNA/g88wAAKCRFRHgg/P9eM4Ors7ONo62Dl8t6r8G/yJiYuP+5c+rcEAAAOF0ftH+LC+zGoA7BoBt/qIl7gRoXgugdfeLZrIPQLUAoOnaV/Nw+H48PEWhkLnZ2eXk5NhKxEJbYcpXff5nwl/AV/1s+X48/Pf14L7iJIEyXYFHBPjgwsz0TKUcz5IJhGLc5o9H/LcL//wd0yLESWK5WCoU41EScY5EmozzMqUiiUKSKcUl0v9k4t8s+wM+3zUAsGo+AXuRLahdYwP2SycQWHTA4vcAAPK7b8HUKAgDgGiD4c93/+8//UegJQCAZkmScQAAXkQkLlTKsz/HCAAARKCBKrBBG/TBGCzABhzBBdzBC/xgNoRCJMTCQhBCCmSAHHJgKayCQiiGzbAdKmAv1EAdNMBRaIaTcA4uwlW4Dj1wD/phCJ7BKLyBCQRByAgTYSHaiAFiilgjjggXmYX4IcFIBBKLJCDJiBRRIkuRNUgxUopUIFVIHfI9cgI5h1xGupE7yAAygvyGvEcxlIGyUT3UDLVDuag3GoRGogvQZHQxmo8WoJvQcrQaPYw2oefQq2gP2o8+Q8cwwOgYBzPEbDAuxsNCsTgsCZNjy7EirAyrxhqwVqwDu4n1Y8+xdwQSgUXACTYEd0IgYR5BSFhMWE7YSKggHCQ0EdoJNwkDhFHCJyKTqEu0JroR+cQYYjIxh1hILCPWEo8TLxB7iEPENyQSiUMyJ7mQAkmxpFTSEtJG0m5SI+ksqZs0SBojk8naZGuyBzmULCAryIXkneTD5DPkG+Qh8lsKnWJAcaT4U+IoUspqShnlEOU05QZlmDJBVaOaUt2ooVQRNY9aQq2htlKvUYeoEzR1mjnNgxZJS6WtopXTGmgXaPdpr+h0uhHdlR5Ol9BX0svpR+iX6AP0dwwNhhWDx4hnKBmbGAcYZxl3GK+YTKYZ04sZx1QwNzHrmOeZD5lvVVgqtip8FZHKCpVKlSaVGyovVKmqpqreqgtV81XLVI+pXlN9rkZVM1PjqQnUlqtVqp1Q61MbU2epO6iHqmeob1Q/pH5Z/YkGWcNMw09DpFGgsV/jvMYgC2MZs3gsIWsNq4Z1gTXEJrHN2Xx2KruY/R27iz2qqaE5QzNKM1ezUvOUZj8H45hx+Jx0TgnnKKeX836K3hTvKeIpG6Y0TLkxZVxrqpaXllirSKtRq0frvTau7aedpr1Fu1n7gQ5Bx0onXCdHZ4/OBZ3nU9lT3acKpxZNPTr1ri6qa6UbobtEd79up+6Ynr5egJ5Mb6feeb3n+hx9L/1U/W36p/VHDFgGswwkBtsMzhg8xTVxbzwdL8fb8VFDXcNAQ6VhlWGX4YSRudE8o9VGjUYPjGnGXOMk423GbcajJgYmISZLTepN7ppSTbmmKaY7TDtMx83MzaLN1pk1mz0x1zLnm+eb15vft2BaeFostqi2uGVJsuRaplnutrxuhVo5WaVYVVpds0atna0l1rutu6cRp7lOk06rntZnw7Dxtsm2qbcZsOXYBtuutm22fWFnYhdnt8Wuw+6TvZN9un2N/T0HDYfZDqsdWh1+c7RyFDpWOt6azpzuP33F9JbpL2dYzxDP2DPjthPLKcRpnVOb00dnF2e5c4PziIuJS4LLLpc+Lpsbxt3IveRKdPVxXeF60vWdm7Obwu2o26/uNu5p7ofcn8w0nymeWTNz0MPIQ+BR5dE/C5+VMGvfrH5PQ0+BZ7XnIy9jL5FXrdewt6V3qvdh7xc+9j5yn+M+4zw33jLeWV/MN8C3yLfLT8Nvnl+F30N/I/9k/3r/0QCngCUBZwOJgUGBWwL7+Hp8Ib+OPzrbZfay2e1BjKC5QRVBj4KtguXBrSFoyOyQrSH355jOkc5pDoVQfujW0Adh5mGLw34MJ4WHhVeGP45wiFga0TGXNXfR3ENz30T6RJZE3ptnMU85ry1KNSo+qi5qPNo3ujS6P8YuZlnM1VidWElsSxw5LiquNm5svt/87fOH4p3iC+N7F5gvyF1weaHOwvSFpxapLhIsOpZATIhOOJTwQRAqqBaMJfITdyWOCnnCHcJnIi/RNtGI2ENcKh5O8kgqTXqS7JG8NXkkxTOlLOW5hCepkLxMDUzdmzqeFpp2IG0yPTq9MYOSkZBxQqohTZO2Z+pn5mZ2y6xlhbL+xW6Lty8elQfJa7OQrAVZLQq2QqboVFoo1yoHsmdlV2a/zYnKOZarnivN7cyzytuQN5zvn//tEsIS4ZK2pYZLVy0dWOa9rGo5sjxxedsK4xUFK4ZWBqw8uIq2Km3VT6vtV5eufr0mek1rgV7ByoLBtQFr6wtVCuWFfevc1+1dT1gvWd+1YfqGnRs+FYmKrhTbF5cVf9go3HjlG4dvyr+Z3JS0qavEuWTPZtJm6ebeLZ5bDpaql+aXDm4N2dq0Dd9WtO319kXbL5fNKNu7g7ZDuaO/PLi8ZafJzs07P1SkVPRU+lQ27tLdtWHX+G7R7ht7vPY07NXbW7z3/T7JvttVAVVN1WbVZftJ+7P3P66Jqun4lvttXa1ObXHtxwPSA/0HIw6217nU1R3SPVRSj9Yr60cOxx++/p3vdy0NNg1VjZzG4iNwRHnk6fcJ3/ceDTradox7rOEH0x92HWcdL2pCmvKaRptTmvtbYlu6T8w+0dbq3nr8R9sfD5w0PFl5SvNUyWna6YLTk2fyz4ydlZ19fi753GDborZ752PO32oPb++6EHTh0kX/i+c7vDvOXPK4dPKy2+UTV7hXmq86X23qdOo8/pPTT8e7nLuarrlca7nuer21e2b36RueN87d9L158Rb/1tWeOT3dvfN6b/fF9/XfFt1+cif9zsu72Xcn7q28T7xf9EDtQdlD3YfVP1v+3Njv3H9qwHeg89HcR/cGhYPP/pH1jw9DBY+Zj8uGDYbrnjg+OTniP3L96fynQ89kzyaeF/6i/suuFxYvfvjV69fO0ZjRoZfyl5O/bXyl/erA6xmv28bCxh6+yXgzMV70VvvtwXfcdx3vo98PT+R8IH8o/2j5sfVT0Kf7kxmTk/8EA5jz/GMzLdsAAAAgY0hSTQAAeiUAAICDAAD5/wAAgOkAAHUwAADqYAAAOpgAABdvkl/FRgAB1XBJREFUeAEA//8AAAH///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPLy8gD5+fkA/Pz8AAQEBAD7+/sYBAQEGAICAgEAAAD+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQP6+vr5AAAA6QQEBOwBAQEABAQEAP///wAREREAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP7+/hv+/v4v+/v7GQEBAQEAAAD/AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAL9/f35AgIC6P39/ckFBQXxAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQACAgIA/Pz8Ov7+/kYAAAAA////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+Ivv7+zMCAgKzBAQE1P///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP7+/gD9/f0t/Pz8RgMDAwAAAAAAAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf19fVUAgIC6AYGBuwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPr6+hn5+flEAgICAAAAAAD///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQEBAAEBAQABAQEA+fn5RwEBAa8AAAD2AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPv7+yn+/v4PAQEBAP///wACAgL0CgoKtAICAvP///8EAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAfz6+voX+Pj4TAEBAQIBAQEA/f39Iv7+/iMAAADTAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP39/QgBAQEAAAAAAAAAAAABAQHhAQEB2AUFBQAAAAAA////AAAAAAAAAAAAAAAAAAEBAQAAAAAAAQEBAAAAAAD///8AAAAAAP///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQADAwPl+/v7Qf39/Q0AAAAAAAAAAwAAAAoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAfz///8AAAAAAAAAAAABAQEA+fn5AP39/QAICAgA////AP///wABAQEA////AP7+/gAAAAAA/Pz8AP7+/gAEBAQAAgICAAEBAQABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD///8EAAAAAAAAAAAAAAAAAAAA/wAAAPwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgICAPv7+wAAAAAABwcHAAAAAAD8/PwA////AP39/QADAwMA+Pj4APz8/AALCwsA/v7+AAAAAAADAwMAAgICAAICAgD///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD6+voAAQEBAAUFBQD+/v4AAQEBAAICAgD+/v4gAQEBFwMDAwP+/v71AgIC3gMDA/P///8A/f39AAAAAAAAAAAAAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAICAgAAAAAA/v7+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8C////AAAAAAACAgIAAgICAP///wADAwMA/Pz8G/j4+Eb+/v4fAQEBAAAAAAD5+fkAAAAA+AYGBsgGBgbAAgICAP///wAAAAAA////AAEBAQABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgIAAAAAAPz8/AD5+fkABQUFAAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH+AQEBAP///wAFBQUAAgICAAEBAQD7+/sh9fX1XgAAAAECAgIAAAAAAAAAAAABAQEA////CPj4+ED+/v4UCwsLrP///wAAAAAAAAAAAP///wD///8AAQEBAAEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAAAAAAD8/PwA+vr6APv7+wD///8ABQUFAP///wD///8AAQEBAAEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/AAAAAAEBAQD///8A/f39AP///wX39/dYAQEBAQEBAQAAAAAAAAAAAAAAAAAAAAAAAQEBAAMDAwD6+vosAgIC5AwMDMj///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wAAAAAAAAAAAAICAgAAAAAA/Pz8APr6+gD7+/sA////AAICAgABAQEAAAAAAAAAAAAAAAAA////AP///wABAQEAAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8D////AAAAAAD+/v4A////APv7+zf+/v4HAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgIA+/v7RPn5+dAAAAD4////AAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEAAMDAwABAQEAAAAAAPz8/AD6+voA+/v7AP///wACAgIAAQEBAAAAAAAAAAAAAQEBAAAAAAAAAAAAAAAAAAAAAAD///8A////AAEBAQABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AAICAgAHBwcA////APr6+icAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+BP39/RsGBgbd/v7+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD8/PwA+vr6APv7+wD///8AAQEBAAICAgAAAAAAAAAAAAAAAAAAAAAA////BQEBAfv///8AAAAAAAAAAAAAAAAAAAAAAP///wD///8AAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH9AgICAAAAAAD+/v4A////BAAAABMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBARYBAQEAAQEBAAEBAQABAQEAAQEBAAEBAQABAQEA////APr6+gD19fUA+vr6AAEBAQACAgIAAQEBAAAAAAAAAAAAAAAAAAEBAQD+/v5C9fX1aP7+/gwCAgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB////AAAAAAACAgIAAgIC/gAAAPYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAfQCAgIAAgICAAICAgACAgIAAgICAAICAgACAgIAAwMDAPv7+wD///8AAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/jb///8+/f39E/T09GH+/v4KAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8CAAAAAP///wD7+/sA/f39/gEBAeIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/uL6+voA+/v7APv7+wD7+/sA+/v7APv7+wD8/PwA+Pj4APz8/AACAgIAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+Nv39/UoAAAAAAwMDAP39/RP09PRh/v7+CQICAgAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH+AQEBAAAAAAD9/f0A/Pz8AAICAskAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD+/v4AAwMD0gEBAfH8/PwA/f39AP39/QD9/f0A/f39AP7+/gD9/f0A+/v7AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD+/v43/f39SgEBAQAAAAAAAAAAAAICAgD8/PwV8/PzZP7+/goCAgIAAAAAAAAAAAAAAAAAAAAAAP///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/AAAAAP///wAEBAQABwcHAAoKCukICAjA/f39AP///wAAAAAAAAAAAAAAAAAAAAAAAAAAAP7+/gACAgLzCQkJugQEBAAFBQUABQUFAAUFBQAFBQUABgYGAAUFBQD8/PwAAAAAAAEBAQAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/jb9/f1JAQEBAAAAAAAAAAAAAAAAAAAAAAADAwMA/v7+E/Pz82P+/v4LAgICAAAAAAAAAAAAAAAAAAAAAAD///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8D////AP///wD8/PwAAgICAAMDAwAHBwfABwcHwQAAAAD+/v4A////AAAAAAD+/v4A/v7+AAMDA+cKCgqeBAQE9AICAgADAwMAAwMDAAMDAwAEBAQAAwMDAPr6+gD///8AAQEBAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+N/39/UoBAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAP7+/hP09PRi/v7+CwICAgAAAAAAAAAAAAAAAAD///8A////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD+/v4A+/v7AAYGBgD+/v4ACAgIvwMDA9j+/v4w/Pz8Fv///wQGBgbzAQEB2gUFBdADAwMA/f39AAICAgAAAAAA////AAICAgD///8A9vb2AP39/QACAgIAAAAAAAAAAAAAAAAAAAAAAAEBAQD+/v42/f39SQEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAICAgD9/f0T8/PzYw0NDZ0CAgL1/v7+AAAAAAD///8AAAAAAAEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH9AQEBAAAAAAABAQEA/Pz8AAUFBQABAQEA/v7+AAMDA+cGBgbn9/f3APz8/AAHBwcAAQEBAP39/QD+/v4AAQEBAP///wAAAAAAAAAAAP///wD39/cA/f39AAICAgAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/jf9/f1JAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgIA/v7+EvPz82INDQ2eAgIC9f7+/gABAQEA////AP///wABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAA/f39APz8/AACAgIAAAAAAP///wD+/v4A////AAAAAAD+/v4A/v7+AAEBAQD8/PwA9vb2APb29gD29vYA9vb2APX19QD9/f0AAgICAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+Nv39/UkBAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAP7+/hPz8/Nj/v7+CwICAgAAAAAA////AP7+/gABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8C////AP///wD///8A////APv7+wD+/v4AAAAAAAAAAAAAAAAAAAAAAP///wD///8AAgICAAICAgD///8A/v7+AP7+/gD+/v4A/v7+AP7+/gABAQEAAAAAAAAAAAAAAAAAAAAAAAEBAQD+/v43/f39SgEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAICAgD+/v4S8/PzYv7+/goCAgIAAAAAAP7+/gD+/v4AAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH+AQEBAAEBAQABAQEAAwMDAP39/QD8/PwAAQEBAAAAAAAAAAAAAAAAAAQEBAACAgIAAAAAAAEBAQABAQEAAQEBAAEBAQABAQEAAQEBAAEBAQAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/jf9/f1JAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgIA/v7+E/T09GP+/v4MAwMDAP///wD///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/AAAAAAAAAAAAAAAAAAAAAAICAgD+/v4AAAAAAAAAAAD///8ABgYGAAkJCQACAgIAAAAAAP///wr8/Pw7AQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA/v7+N/39/UkBAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAP39/RP09PRi/v7+DQQEBAD+/v4A////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8D////AP///wD///8A////AP///wD+/v4A////AAMDAwABAQEAAwMDAP///wAAAAAAAAAAAfb29lv7+/tF////TQEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQD+/v43/f39SQEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAICAgD9/f0S9PT0Zf7+/hQAAAAA/v7+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wACAgIAAQEBAP///wAAAAAA////AAEBAQAAAAAC9vb2X/z8/BsCAgIA/v7+M/7+/koBAQEAAAAAAAAAAAAAAAAAAQEBAP7+/jf9/f1JAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAgIA////DvT09Eb19fUA9/f3AAEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH9AQEBAAAAAAAAAAAAAAAAAAAAAAAEBAQAAQEBAP///wAAAAAAAQEBAAAAAAH29vZf/Pz8HwICAgAAAAAAAQEBAP///zb+/v4AAgICtv///wAAAAAA/v7+OP39/UgBAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQEBAP7+/gP8/PwAAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAA////AAICAgACAgIA////AAAAAAABAQEAAAAAAvb29l/8/PwfAgICAAAAAAAAAAAAAAAAAAAAAAD+/v42AAAA/wICArf+/v4w/v7+SAEBAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAfwCAgIAAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8C////AP///wAAAAAA////AAICAgAAAAAAAAAAAAEBAQAAAAAC9vb2X/z8/B8CAgIAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA////N/7+/hL///8jAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQH+AQEBAAEBAQAAAAAABAQEAAMDAwD///8AAgICAAAAAAL29vZf/Pz8HwICAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///yUAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABgP5/AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8AAAAAAQEBAAAAAAADAwMAAQEBAAEBAQD///8C9vb2X/z8/B8CAgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wP///8A/f39AAICAgADAwMAAAAAAAAAAAL29vZf/Pz8HwICAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQEBAACAgIA////BPb29l/8/PwfAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAf0BAQEAAwMDAAICAgD9/f0C9/f3WPv7+x8CAgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAP39/QABAQEC/v7+HgICAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wL///8A////AAICAgABAQH/AQEB9QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAf4BAQEAAQEBAP///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wP///8AAAAAAP///wAAAAAA/v7+Ef7+/gABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////Df7+/gD+/v4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD///8AAgICAAMDAwAAAAABBgYGzP39/QoBAQH/AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAA5f///wAEBAQA////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAf0CAgIAAAAAAAICAgAEBAT8AgICtP7+/gABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wADAwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQEA/f39APX19QAGBgYAAQEBAP7+/gABAQEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPr6+gAEBAQACgoKAP7+/gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AgAAAAAAAAAAAAAAAAAAAPz///8A/v7+AP7+/gD39/cAAgICAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wD5+fkAAQEBAAgICPsBAQH+AAAAAAAAAAAAAAABAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgIC/f39/QAAAAAAAQEBAP7+/hn7+/sSAQEB9wICAgEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQABAQEA+fn5/v///xj+/v4JAQEBAP///wAAAAD8AAAA9wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABwcH3vf39zX+/v4GAQEBAP7+/hUAAABqAgIC+gAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/vf39wsAAAAAAQEBAP///wACAgLo////4gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAQE3QQEBLr39/dMBAQEAAEBAQAAAAAE////BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEBAQAAAAAA////AAAAAAAICAi/BQUF8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAAoKCswJCQnQ/f39AP7+/gD///8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP///wD///8AAQEBAAQEBLgEBATdAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AAMDAwAKCgqwAAAA3/39/TP///8RAAAAAwAAAP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgICAvv////kAwMDygMDA+D+/v4AAQEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP7+/gABAQEAAwMD1QICAgD8/PwU/v7+BAEBAf8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA////AQMDA/r////jAAAA4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf///wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFZVqaoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAD//z+q3EMK07lfAAAAAElFTkSuQmCC") : Convert.FromBase64String(itemImage.ImageAsText));
		Item item = MemoryLoadedData.all_active_items.Where((Item m) => m.ItemID == Convert.ToInt16(CS_0024_003C_003E8__locals0.Id)).FirstOrDefault();
		string price = item.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		string salePrice = "";
		if (item.OnSale)
		{
			Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(item.ItemID);
			if (promoSaleItemById != null)
			{
				salePrice = promoSaleItemById.GetDiscountAmount.Value.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			}
		}
		new frmItemInfo(item.ItemName, array, item.Description, price, item.Notes, salePrice).ShowDialog(this);
	}

	private int method_12(bool bool_30)
	{
		int num = 0;
		if (!bool_30 && short_6 > 0 && short_7 > 0)
		{
			return (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal((bool_30 ? pnlGroups.Width : pnlItems.Width) - 8) / (decimal)short_6));
		}
		if (bool_30 && short_8 > 0)
		{
			num = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal((bool_30 ? pnlGroups.Width : pnlItems.Width) - 8) / (decimal)short_8));
			if (short_9 > 0)
			{
				int_8 = short_9;
			}
			int_2 = short_9 * short_8;
			return num;
		}
		int num2 = 3;
		while (true)
		{
			if (num2 <= 20)
			{
				num = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal((bool_30 ? pnlGroups.Width : pnlItems.Width) - 8) / (decimal)num2));
				if (num <= 150)
				{
					break;
				}
				num2++;
				continue;
			}
			if (bool_30)
			{
				if (short_8 > 0 && short_9 > 0)
				{
					int_8 = short_9;
					int_2 = short_9 * short_8;
				}
				else
				{
					int_2 = int_8 * 3;
				}
			}
			else
			{
				int_3 = 16;
			}
			return (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlItems.Width - 10) / 4m));
		}
		if (bool_30)
		{
			if (short_8 > 0 && short_9 > 0)
			{
				int_8 = short_9;
				int_2 = short_9 * short_8;
			}
			else
			{
				int_2 = int_8 * num2;
			}
		}
		else
		{
			int_3 = 4 * num2;
		}
		return num;
	}

	private void method_13()
	{
		pnlGroups.Controls.Clear();
		method_12(bool_30: true);
		List<CorePOS.Data.Group> list = (from group_0 in MemoryLoadedObjects.all_active_groups
			where group_0.GroupClassification == ItemClassifications.Product && group_0.ParentGroupID == short_3 && group_0.Active && group_0.OrderEntryShow
			select group_0 into g
			orderby g.HighTraffic descending
			select g).ThenBy((CorePOS.Data.Group w) => w.SortOrder).ThenBy((CorePOS.Data.Group x) => x.GroupName).ToList();
		if (MemoryLoadedObjects.FirstGetGroupIteration)
		{
			short num = 0;
			foreach (CorePOS.Data.Group item in list)
			{
				item.SortOrder -= num;
				if (!item.OrderEntryShow)
				{
					num = (short)(num + 1);
				}
			}
			MemoryLoadedObjects.FirstGetGroupIteration = false;
		}
		list = list.Where((CorePOS.Data.Group a) => a.OrderEntryShow).ToList();
		int num2 = 0;
		int num3 = int_2;
		if (short_8 > 0 && short_9 > 0)
		{
			num3 = short_8 * short_9;
		}
		if (bool_11)
		{
			num3--;
		}
		if (short_3 > 0)
		{
			Button value = method_10("...", HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), short_3.ToString(), method_18);
			pnlGroups.Controls.Add(value);
			num2 = short_2;
			num3--;
			lblItemsHeader.Text = Resources.Items;
		}
		else
		{
			num2 = short_1;
		}
		if (num2 > 1)
		{
			Button value2 = method_10(Resources.PREV_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_14);
			pnlGroups.Controls.Add(value2);
		}
		int num4 = list.Count();
		int num5 = num3 * (num2 - 1);
		bool flag = num4 - num5 > num3;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		if (bool_12 && num4 > 0 && list.Count() > 0)
		{
			num8 = list.Max((CorePOS.Data.Group a) => a.SortOrder) - list.Where((CorePOS.Data.Group a) => a.SortOrder != 0).Count();
			flag = num4 + num8 - num5 > num3;
			if (num8 < 0)
			{
				num8 = 0;
			}
			if (num8 > 0)
			{
				new List<CorePOS.Data.Group>();
				List<CorePOS.Data.Group> list2 = list.ToList();
				int i = 1;
				int num10 = num3;
				if (num4 + num8 > num3 && flag && num2 > 1)
				{
					num10--;
				}
				foreach (CorePOS.Data.Group item2 in list2)
				{
					for (; i < item2.SortOrder; i++)
					{
						if (item2.SortOrder <= 0)
						{
							break;
						}
						if (i > num3 * num2)
						{
							break;
						}
					}
					if (i <= item2.SortOrder && item2.SortOrder > 0)
					{
						i++;
					}
					else if (item2.SortOrder == 0)
					{
						num9++;
					}
					if (num10 * num2 + 1 >= i + num9 && i + num9 > num10 * (num2 - 1) + 1)
					{
						num6++;
						continue;
					}
					if (num10 * num2 + 1 >= i + num9)
					{
						num7++;
						continue;
					}
					break;
				}
			}
		}
		if (num4 + num8 > num3 && flag && num2 > 1)
		{
			num3--;
		}
		if (num2 > 2)
		{
			num5--;
			num7--;
		}
		if (num4 + num8 > num3 && num3 >= 0)
		{
			list = ((!bool_12 || num6 <= 0) ? list.Skip(num5).Take(num3).ToList() : list.Skip(num7).Take(num6).ToList());
		}
		int num11 = ((num4 > 0 && list.Where((CorePOS.Data.Group a) => a.SortOrder != 0).Count() > 0) ? (from a in list
			where a.SortOrder != 0
			select a.SortOrder).Min((short a) => a) : 0);
		int j = num11;
		if (list.Count() > 0)
		{
			foreach (CorePOS.Data.Group item3 in list)
			{
				Color color = HelperMethods.GetColor(item3.GroupColor);
				Button value3 = (((from x in dataManager_0.GetChildGroups(ItemClassifications.Product, item3.GroupID, onlyActive: true)
					where x.OrderEntryShow
					select x).Count() <= 0) ? method_10(item3.GroupName, color, item3.GroupID.ToString(), method_20) : method_10(item3.GroupName, color, item3.GroupID.ToString(), method_19));
				for (; j < item3.SortOrder; j++)
				{
					if (item3.SortOrder <= 0)
					{
						break;
					}
					if (j > num3 * num2)
					{
						break;
					}
					if (!bool_12)
					{
						break;
					}
					Button value4 = method_10(string.Empty, Color.Gray, string.Empty, null);
					pnlGroups.Controls.Add(value4);
				}
				if (j <= item3.SortOrder && item3.SortOrder > 0)
				{
					j++;
				}
				else if (item3.SortOrder == 0 && num8 == 0)
				{
					num9++;
				}
				pnlGroups.Controls.Add(value3);
			}
		}
		bool flag2 = false;
		if ((short_0 > 1 && num4 < num3 * short_0) || short_0 == 1)
		{
			flag2 = true;
		}
		if (bool_12)
		{
			int num12 = (flag2 ? 1 : 0);
			for (int k = (flag ? (j + num9 + 1) : (j + num9)); k < num3 + num11 + num12; k++)
			{
				Button value5 = method_10(string.Empty, Color.Gray, string.Empty, null);
				pnlGroups.Controls.Add(value5);
			}
		}
		if ((num4 + num8 > num3 && flag) & bool_11)
		{
			Button value6 = method_10(Resources.NEXT_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_15);
			pnlGroups.Controls.Add(value6);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = Resources.Items;
		if (short_3 > 0)
		{
			short_2--;
		}
		else
		{
			short_1--;
		}
		method_13();
	}

	private void method_15(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = Resources.Items;
		if (short_3 > 0)
		{
			short_2++;
		}
		else
		{
			short_1++;
		}
		method_13();
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		if (radListItems.Items.Count > 0 && !string.IsNullOrEmpty(string_3))
		{
			if (SettingsHelper.CurrentTerminalMode == "Kiosk")
			{
				HideOrderEntry();
			}
			GClass6 gClass = new GClass6();
			Employee employee = AuthMethods.EmployeeAuthenticateControl(this, "btnClear");
			if (employee == null)
			{
				return;
			}
			if (!(employee.Users.FirstOrDefault().Role.RoleName == Roles.admin) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.manager) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.supervisor) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.employee))
			{
				new NotificationLabel(this, Resources.You_do_not_have_permission, NotificationTypes.Warning).Show();
				return;
			}
			List<Order> list = gClass.Orders.Where((Order o) => o.Void == false && o.OrderNumber == string_3).ToList();
			string voidReason = "";
			if (bool_17)
			{
				string[] itemList = (from r in gClass.Reasons
					where r.ReasonType == "void"
					select r into d
					select d.Value).ToArray();
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
				MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: true, "Select Void Reason");
				if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				voidReason = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
			}
			else if (new frmMessageBox(Resources.Void_Order_Confirmation, Resources.Void_Order_Title, CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
			{
				return;
			}
			bool flag = false;
			using (List<Order>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass141_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass141_0();
					CS_0024_003C_003E8__locals0.order = enumerator.Current;
					if (CS_0024_003C_003E8__locals0.order.PaymentMethods.Contains("=") && CS_0024_003C_003E8__locals0.order.OrderType == OrderTypes.Catering)
					{
						flag = true;
					}
					if (CS_0024_003C_003E8__locals0.order.DateFilled.HasValue && !CS_0024_003C_003E8__locals0.order.ShareItemID.HasValue)
					{
						Item item = MemoryLoadedData.all_active_items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
						if (item != null && item.TrackInventory && new frmMessageBox(Resources.Do_you_want_to_return_the_item + CS_0024_003C_003E8__locals0.order.ItemName + Resources._back_to_inventory, Resources.Return_Item_To_Inventory, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
						{
							new InventoryMethods(gClass).AddItemInventory(CS_0024_003C_003E8__locals0.order, "Item Voided, Return to Inventory.");
							new InventoryMethods(gClass).UpdateExpiryItem(CS_0024_003C_003E8__locals0.order.InventoryBatchId, CS_0024_003C_003E8__locals0.order.Qty, toSubtract: false);
						}
					}
					if (bool_16 && CS_0024_003C_003E8__locals0.order.FlagID != 6)
					{
						CS_0024_003C_003E8__locals0.order.DateFilled = null;
						CS_0024_003C_003E8__locals0.order.Notified = false;
						CS_0024_003C_003E8__locals0.order.PrintedInKitchen = false;
						CS_0024_003C_003E8__locals0.order.IsModified = true;
						CS_0024_003C_003E8__locals0.order.DateVoided = DateTime.Now;
						CS_0024_003C_003E8__locals0.order.FlagID = 4;
					}
					CS_0024_003C_003E8__locals0.order.StationNotified = null;
					CS_0024_003C_003E8__locals0.order.StationPrinted = null;
					CS_0024_003C_003E8__locals0.order.Void = true;
					CS_0024_003C_003E8__locals0.order.Paid = false;
					CS_0024_003C_003E8__locals0.order.VoidBy = employee.FirstName + " " + employee.LastName;
					if (!flag)
					{
						CS_0024_003C_003E8__locals0.order.PaymentMethods = "SAVED ORDER";
					}
					CS_0024_003C_003E8__locals0.order.VoidReason = voidReason;
					CS_0024_003C_003E8__locals0.order.Synced = false;
					if (CS_0024_003C_003E8__locals0.order.FlagID == 6)
					{
						CS_0024_003C_003E8__locals0.order.PrintedInKitchen = true;
						Order order = CS_0024_003C_003E8__locals0.order;
						Order order2 = CS_0024_003C_003E8__locals0.order;
						string text = (CS_0024_003C_003E8__locals0.order.StationPrinted = CS_0024_003C_003E8__locals0.order.StationID);
						string stationNotified = (order2.StationMade = text);
						order.StationNotified = stationNotified;
					}
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
			OrderMethods.LogOrderAudit(string_3, "Order Voided");
			if (flag)
			{
				OrderMethods.CancelPartialPaidCaterOrder(string_3);
			}
			string orderstatus = "SAVED ORDER";
			if (SettingsHelper.CurrentTerminalMode == "Kiosk")
			{
				orderstatus = "KIOSK SAVED ORDER";
			}
			new OrderMethods();
			orderHelper_0.OrderPrintMadeCheck(orderstatus, string_3, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list.Count());
			string_3 = string.Empty;
			radListItems.Items.Clear();
			if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
			{
				MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Clear();
			}
			RecalculateTaxAndSubtotal();
			if (string_5 == OrderTypes.DineIn)
			{
				GuestMethods.AssignEmployeeTable(string_4.Replace("Table", string.Empty).Trim(), 0);
				GuestMethods.UpdateTableGuestCapacity(string_10.Replace("Table ", ""), 0, 0);
			}
			if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
			{
				if (MemoryLoadedObjects.DefaultOrderTypes.Split(',').Count() >= 4 && MemoryLoadedObjects.DefaultOrderTypes.Split(',').Contains(OrderTypes.ToGo))
				{
					ReinitializeOrderEntryByOrderType(OrderTypes.ToGo);
					return;
				}
				ReinitializeOrderEntryByOrderType(MemoryLoadedObjects.DefaultOrderTypes.Split(',')[0]);
			}
			else
			{
				Hide();
			}
		}
		else if (btnClear.Text == "HOLD ORDER")
		{
			method_16();
		}
		else if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF")
			{
				method_34();
			}
			else
			{
				Hide();
			}
		}
		else
		{
			GuestMethods.AssignEmployeeTable(string_4.Replace("Table", string.Empty).Trim(), 0);
			GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), 0, 0);
			HideOrderEntry();
		}
	}

	private void method_16()
	{
		if (!(string_5 == OrderTypes.DineIn))
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Number of minutes to hold order.", 0, 3);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		foreach (ListViewDataItem item in radListItems.Items)
		{
			item.SubItems[14] = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		orderOnHoldTime = Convert.ToInt32(MemoryLoadedObjects.Numpad.numberEntered);
		new NotificationLabel(this, "Order will be held for " + orderOnHoldTime + " minutes.", NotificationTypes.Success).Show();
	}

	private void method_17()
	{
		if (!(string_5 == OrderTypes.PickUp) && !(string_5 == OrderTypes.PickUpOnline) && !(string_5 == OrderTypes.Delivery) && !(string_5 == OrderTypes.DeliveryOnline))
		{
			if (radListItems.Padding != new Padding(0, 0, 0, 0))
			{
				radListItems.Padding = new Padding(0, 0, 0, 0);
			}
			btnChangeFulfillment.Visible = false;
			return;
		}
		btnChangeFulfillment.Location = new Point(radListItems.Location.X + 2, radListItems.Location.Y + radListItems.Height - btnChangeFulfillment.Height - 1);
		radListItems.Padding = new Padding(0, 0, 0, 35);
		btnChangeFulfillment.Visible = true;
		if (dateFullfilment.HasValue)
		{
			string text = ((dateFullfilment.Value.Date == DateTime.Now.Date) ? "TODAY @ " : dateFullfilment.Value.ToString("ddd, MMM dd")) + " " + dateFullfilment.Value.ToShortTimeString();
			btnChangeFulfillment.Text = "FULFILLMENT: " + text + "    * tap here to change *";
		}
		else
		{
			btnChangeFulfillment.Text = "FULFILLMENT: ASAP    * tap here to change *";
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		short_2 = 1;
		pnlItems.Controls.Clear();
		lblItemsHeader.Text = "Items";
		Button button = (Button)sender;
		CorePOS.Data.Group groupFromID = dataManager_0.getGroupFromID(Convert.ToInt16(button.Tag));
		short_3 = groupFromID.ParentGroupID;
		pnlGroups.Controls.Clear();
		if (groupFromID.ParentGroupID > 0)
		{
			CorePOS.Data.Group groupFromID2 = dataManager_0.getGroupFromID(groupFromID.ParentGroupID);
			lblCategories.Text = groupFromID2.GroupName.Replace("&", "&&");
			method_13();
		}
		else
		{
			lblCategories.Text = Resources.Categories;
			method_13();
		}
	}

	private void method_19(object sender, EventArgs e)
	{
		pnlItems.Controls.Clear();
		string_2 = ((Button)sender).Text.Replace("&&", "&");
		Button button = (Button)sender;
		short_3 = Convert.ToInt16(button.Tag);
		lblCategories.Text = button.Text;
		method_13();
		method_21(sender);
	}

	private void method_20(object sender, EventArgs e)
	{
		method_21(sender);
	}

	private void method_21(object object_0)
	{
		string_2 = ((Button)object_0).Text.Replace("&&", "&");
		list_4 = (from itemsInGroup_0 in MemoryLoadedData.ListOfItemsInGroupMemory
			where itemsInGroup_0.Group.GroupName.ToUpper() == string_2.ToUpper()
			select itemsInGroup_0 into a
			select a.Item into i
			orderby i.SortOrder
			select i).ThenBy((Item x) => x.ItemName).ToList();
		short_0 = 1;
		if (button_0 != null)
		{
			button_0.BackColor = color_0;
		}
		lblItemsHeader.Text = Resources.Items_for + string_2;
		button_0 = (Button)object_0;
		color_0 = button_0.BackColor;
		button_0.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gold"]);
		method_22();
	}

	private void method_22()
	{
		_003C_003Ec__DisplayClass148_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass148_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		new GClass6();
		pnlItems.Controls.Clear();
		method_12(bool_30: false);
		CS_0024_003C_003E8__locals0.group = null;
		if (string_2 == string.Empty)
		{
			CS_0024_003C_003E8__locals0.group = null;
		}
		else
		{
			CS_0024_003C_003E8__locals0.group = (from a in MemoryLoadedData.ListOfItemsInGroupMemory.Select((ItemsInGroup a) => a.Group).Distinct()
				where a.GroupClassification == ItemClassifications.Product && !a.Archived && a.GroupName.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_2.ToUpper()
				select a).FirstOrDefault();
		}
		int num = 0;
		if (CS_0024_003C_003E8__locals0.group != null)
		{
			num = MemoryLoadedObjects.all_itemsInGroups.Where((ItemsInGroup a) => a.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).Count();
		}
		List<Item> list = new List<Item>();
		list = list_4.ToList();
		list = ((CS_0024_003C_003E8__locals0.group == null) ? list.OrderBy((Item z) => z.SortOrder).ThenBy((Item zz) => zz.ItemName).ToList() : list.OrderBy((Item x) => (x.ItemsInGroups.Where((ItemsInGroup y) => y.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).FirstOrDefault() != null) ? x.ItemsInGroups.Where((ItemsInGroup y) => y.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).FirstOrDefault().SortOrder : 0).ThenBy((Item z) => z.SortOrder).ThenBy((Item zz) => zz.ItemName)
			.ToList());
		int num2 = list.Count();
		int num3 = int_3;
		if (short_6 > 0 && short_7 > 0)
		{
			num3 = short_7 * short_6;
		}
		int num4 = num3;
		if (short_0 > 1)
		{
			num3--;
		}
		int num5 = ((short_0 > 1) ? (num4 - 1 + (num3 - 1) * (short_0 - 2)) : 0);
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		if (bool_12 && num2 > 0 && CS_0024_003C_003E8__locals0.group != null && num > 0)
		{
			num8 = list.Where((Item a) => a.ItemsInGroups != null && a.ItemsInGroups.Count() > 0 && a.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).FirstOrDefault() != null).ToList().Max((Item a) => a.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).First().SortOrder) - (num2 - 1);
			if (num8 < 0)
			{
				num8 = 0;
			}
			if (num8 > 0)
			{
				new List<Item>();
				List<Item> list2 = list.ToList();
				int i = 0;
				int num9 = num3;
				int num10 = 0;
				int num11 = num9;
				if (short_0 > 1)
				{
					num10 = num4 - 1 + (num9 - 1) * (short_0 - 2);
					num11 = num10 + num9;
				}
				foreach (Item item in list2)
				{
					if (CS_0024_003C_003E8__locals0.group != null)
					{
						ItemsInGroup itemsInGroup = item.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).FirstOrDefault();
						if (itemsInGroup != null && i < itemsInGroup.SortOrder && itemsInGroup.SortOrder > 0 && bool_12)
						{
							for (; i < itemsInGroup.SortOrder && i < num11; i++)
							{
							}
						}
					}
					i++;
					if (num11 > i && i > num10)
					{
						num6++;
						continue;
					}
					if (num11 > i)
					{
						num7++;
						continue;
					}
					break;
				}
			}
		}
		if (num2 + num8 > num3)
		{
			num3--;
			list = ((!bool_12 || num6 <= 0) ? list.Skip(num5).Take(num3).ToList() : list.Skip(num7).Take(num6).ToList());
		}
		if (short_0 > 1)
		{
			Button value = method_10(Resources.PREV_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_23, bool_30: true);
			pnlItems.Controls.Add(value);
		}
		int num12 = 0;
		int num13 = ((short_0 > 1) ? 1 : 0);
		int j = (num12 = num3 * (short_0 - 1) + num13);
		using (List<Item>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass148_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass148_1();
				CS_0024_003C_003E8__locals1.item = enumerator.Current;
				Color color = HelperMethods.GetColor(CS_0024_003C_003E8__locals1.item.ItemColor);
				string text = CS_0024_003C_003E8__locals1.item.ItemName;
				if (text.Contains("&"))
				{
					text = text.Replace("&", "&&");
				}
				if (CS_0024_003C_003E8__locals0.group != null)
				{
					ItemsInGroup itemsInGroup2 = CS_0024_003C_003E8__locals1.item.ItemsInGroups.Where((ItemsInGroup x) => x.GroupID == CS_0024_003C_003E8__locals0.group.GroupID).FirstOrDefault();
					if (itemsInGroup2 != null)
					{
						if (CS_0024_003C_003E8__locals1.item.ItemColor.Replace(" ", string.Empty) == "150,166,166" && itemsInGroup2.Color.Replace(" ", string.Empty) != "150,166,166")
						{
							color = HelperMethods.GetColor(itemsInGroup2.Color);
						}
						if (j < itemsInGroup2.SortOrder && itemsInGroup2.SortOrder > 0 && bool_12)
						{
							for (; j < itemsInGroup2.SortOrder && j < num3 * short_0; j++)
							{
								Button value2 = method_10(string.Empty, Color.Gray, string.Empty, null, bool_30: true);
								pnlItems.Controls.Add(value2);
							}
						}
					}
				}
				Label label = new Label();
				label.Width = 0;
				decimal num14 = CS_0024_003C_003E8__locals1.item.ItemPrice;
				decimal num15 = default(decimal);
				if (CS_0024_003C_003E8__locals1.item.OnSale)
				{
					Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(CS_0024_003C_003E8__locals1.item.ItemID);
					if (promoSaleItemById != null)
					{
						decimal num16 = Convert.ToDecimal(100);
						num15 = ((CS_0024_003C_003E8__locals1.item.ItemPrice > 0m) ? Math.Round(num16 - promoSaleItemById.GetDiscountAmount.Value / CS_0024_003C_003E8__locals1.item.ItemPrice * num16) : Convert.ToDecimal(0));
						if (num15 > 0m)
						{
							num14 = promoSaleItemById.GetDiscountAmount.Value;
						}
					}
				}
				Button button = method_10(text, color, CS_0024_003C_003E8__locals1.item.ItemID.ToString(), method_25, bool_30: true);
				if (bool_7)
				{
					button.Text = "";
					button.TextAlign = ContentAlignment.BottomCenter;
					ItemImage itemImage = MemoryLoadedObjects.all_itemimages.Where((ItemImage m) => m.ItemID == CS_0024_003C_003E8__locals1.item.ItemID).FirstOrDefault();
					if (itemImage != null && itemImage.ImageAsText != null && itemImage.ImageAsText != "NoImage")
					{
						using MemoryStream stream = new MemoryStream(Convert.FromBase64String(itemImage.ImageAsText));
						Bitmap backgroundImage = new Bitmap(Image.FromStream(stream), new Size(button.Width, button.Height));
						button.BackgroundImage = backgroundImage;
					}
					else
					{
						Bitmap backgroundImage2 = new Bitmap(MemoryLoadedObjects.blankImage, new Size(button.Width, button.Height));
						button.BackgroundImage = backgroundImage2;
					}
					pnlItems.Controls.Add(button);
					TransparentLabel transparentLabel = new TransparentLabel();
					transparentLabel.Text = text;
					if (bool_18)
					{
						transparentLabel.Text = transparentLabel.Text + " - " + $"{num14:C}";
					}
					transparentLabel.transparentBackColor = Color.Black;
					transparentLabel.Size = new Size(button.Width, button.Height / 4);
					transparentLabel.Font = new Font(transparentLabel.Font.FontFamily, fontStyleObject_0.Size, (FontStyle)Convert.ToInt32(fontStyleObject_0.Style));
					transparentLabel.ForeColor = HelperMethods.GetColor(fontStyleObject_0.Color);
					transparentLabel.BackColor = HelperMethods.GetColor("209, 72, 65");
					transparentLabel.FlatStyle = FlatStyle.Flat;
					transparentLabel.TextAlign = ContentAlignment.MiddleCenter;
					transparentLabel.Top = button.Height - button.Height / 4;
					button.Controls.Add(transparentLabel);
					transparentLabel.MinimumSize = new Size(transparentLabel.Width, 20);
					transparentLabel.Opacity = 85;
				}
				else
				{
					button.Text = text;
					if (bool_18)
					{
						button.Text = button.Text + " - " + $"{num14:C}";
					}
					button.TextAlign = ContentAlignment.MiddleCenter;
					pnlItems.Controls.Add(button);
				}
				if (num15 > 0m)
				{
					Label label2 = new Label();
					label2.Tag = "currentlySale";
					label2.Text = ((num15 == 100m) ? Resources.FREE : (num15.ToString("0") + Resources._Off));
					label2.Size = new Size(button.Width / 2, button.Height / 4);
					label2.Font = new Font(label2.Font.FontFamily, 8f);
					label2.ForeColor = Color.White;
					label2.BackColor = HelperMethods.GetColor("209, 72, 65");
					label2.FlatStyle = FlatStyle.Flat;
					label2.TextAlign = ContentAlignment.MiddleCenter;
					button.Controls.Add(label2);
					label = label2;
				}
				if (CS_0024_003C_003E8__locals1.item.TrackInventory)
				{
					if (SettingsHelper.CurrentTerminalMode == "Normal")
					{
						Label label3 = new Label();
						if (CS_0024_003C_003E8__locals1.item.InventoryCount > 999m)
						{
							label3.Text = Resources.Stock_999;
						}
						else
						{
							label3.Text = Resources.Stock + (CS_0024_003C_003E8__locals1.item.UOM.isFractional ? CS_0024_003C_003E8__locals1.item.InventoryCount.ToString("0.00", Thread.CurrentThread.CurrentCulture) : CS_0024_003C_003E8__locals1.item.InventoryCount.ToString("0"));
						}
						label3.Size = new Size(button.Width / 2, button.Height / 4);
						label3.Font = new Font(label3.Font.FontFamily, 8f);
						label3.ForeColor = Color.Black;
						label3.BackColor = HelperMethods.GetColor("247, 218, 100");
						label3.FlatStyle = FlatStyle.Flat;
						label3.TextAlign = ContentAlignment.MiddleCenter;
						label3.Left = button.Width - button.Width / 2;
						while (button.Width < label3.PreferredWidth)
						{
							label3.Font = new Font(label3.Font.FontFamily, label3.Font.Size - 0.25f);
						}
						if (label3.Width < label3.PreferredWidth)
						{
							label3.Size = new Size(label3.PreferredWidth, label3.Size.Height);
							label3.Left = button.Width - label3.Width;
							if (label.Width + label3.Width > button.Width)
							{
								label.Size = label.PreferredSize;
								label.Top = label3.Bottom;
								label.Left = button.Width - label.Width;
							}
						}
						button.Controls.Add(label3);
					}
					if (CS_0024_003C_003E8__locals1.item.DisableSoldOutItems && CS_0024_003C_003E8__locals1.item.InventoryCount <= 0m)
					{
						TransparentLabel transparentLabel2 = new TransparentLabel();
						transparentLabel2.Size = new Size(button.Width, button.Height);
						transparentLabel2.Location = new Point(0, 0);
						transparentLabel2.Font = new Font("Arial", 14f, FontStyle.Regular);
						transparentLabel2.FlatStyle = FlatStyle.Flat;
						transparentLabel2.Opacity = 70;
						transparentLabel2.transparentBackColor = CorePOS.Business.Enums.ColorPalette.WellRead;
						transparentLabel2.Text = Resources.SOLD_OUT;
						button.Controls.Add(transparentLabel2);
						transparentLabel2.BringToFront();
					}
				}
				if (!dictionary_0.ContainsKey(CS_0024_003C_003E8__locals1.item.ItemID))
				{
					dictionary_0.Add(CS_0024_003C_003E8__locals1.item.ItemID, CS_0024_003C_003E8__locals1.item);
				}
				j++;
			}
		}
		bool flag = num2 - num5 > num3;
		if (bool_12)
		{
			flag = num2 + num8 - num5 > num3;
		}
		if (short_0 <= 1)
		{
		}
		if (bool_12)
		{
			for (int k = (flag ? (j + 1) : j); k < num3 + num12 + 1; k++)
			{
				Button value3 = method_10(string.Empty, Color.Gray, string.Empty, null, bool_30: true);
				pnlItems.Controls.Add(value3);
			}
		}
		if ((num2 + num8 > num3 && flag) & bool_6)
		{
			Button value4 = method_10(Resources.NEXT_PAGE, HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]), 0.ToString(), method_24, bool_30: true);
			pnlItems.Controls.Add(value4);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		short_0--;
		method_22();
	}

	private void method_24(object sender, EventArgs e)
	{
		short_0++;
		method_22();
	}

	private void method_25(object sender, EventArgs e)
	{
		int int_ = Convert.ToInt32(((Button)sender).Tag.ToString());
		string name = ((Button)sender).Name;
		megFrVxorYX(int_, name);
	}

	private void megFrVxorYX(int int_16, string string_16, decimal? nullable_0 = null)
	{
		_003C_003Ec__DisplayClass152_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass152_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		int num = 0;
		CS_0024_003C_003E8__locals0.selectedTag = int_16;
		if (bool_23)
		{
			if (CS_0024_003C_003E8__locals0.selectedTag != 0)
			{
				method_11(Convert.ToInt16(CS_0024_003C_003E8__locals0.selectedTag));
			}
			return;
		}
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.item = MemoryLoadedData.all_active_items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.selectedTag).FirstOrDefault();
		if (string_16.ToUpper().Contains(Resources._CUSTOM) || string_16.ToUpper().Contains("OPEN CATER") || string_16.ToUpper().Contains("GIFT CARD") || string_16.ToUpper().Contains("GIFT CERTIFICATE"))
		{
			CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.selectedTag).FirstOrDefault();
			if (string_16.ToUpper().Contains("OPEN CATER"))
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Custom_Item_Price, 2, 7);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.item.ItemName = CS_0024_003C_003E8__locals0.item.ItemName;
				CS_0024_003C_003E8__locals0.item.ItemPrice = MemoryLoadedObjects.Numpad.numberEntered;
			}
			else if (!string_16.ToUpper().Contains("GIFT CARD") && !string_16.ToUpper().Contains("GIFT CERTIFICATE"))
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
				MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Name_Of_Custom_Item);
				if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Custom_Item_Price, 2, 7);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.item.ItemName = CS_0024_003C_003E8__locals0.item.ItemName + ": " + MemoryLoadedObjects.Keyboard.textEntered;
				CS_0024_003C_003E8__locals0.item.ItemPrice = MemoryLoadedObjects.Numpad.numberEntered;
			}
			else
			{
				string title = (string_16.ToUpper().Contains("GIFT CERTIFICATE") ? "Enter Gift Cert Price" : "Enter Gift Card Price");
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(title, 2, 7);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.item.ItemPrice = MemoryLoadedObjects.Numpad.numberEntered;
			}
		}
		if (CS_0024_003C_003E8__locals0.item.TaxRule.TaxRuleOperations.Count() > 0)
		{
			TaxRuleOperation taxRuleOperation = CS_0024_003C_003E8__locals0.item.TaxRule.TaxRuleOperations.Where((TaxRuleOperation a) => a.Tax.Inactive).FirstOrDefault();
			if (taxRuleOperation != null)
			{
				if (new frmMessageBox(CS_0024_003C_003E8__locals0.item.ItemName + " has an inactive tax code " + taxRuleOperation.Tax.TaxCode + ", Tax may not apply. Do you want to proceed?", "Inactive Tax Code", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
				{
					return;
				}
			}
			else if (!CS_0024_003C_003E8__locals0.item.TaxRule.Active && new frmMessageBox(CS_0024_003C_003E8__locals0.item.ItemName + " has an inactive tax rule " + CS_0024_003C_003E8__locals0.item.TaxRule.RuleName + ", Tax may not apply. Do you want to proceed?", "Inactive Tax Code", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
			{
				return;
			}
		}
		if (!MiscHelper.CheckItemDisableSOldOut(this, CS_0024_003C_003E8__locals0.item, radListItems))
		{
			return;
		}
		decimal qty = 1m;
		decimal decimal_ = CS_0024_003C_003E8__locals0.item.ItemPrice;
		if (CS_0024_003C_003E8__locals0.item.UOM != null && CS_0024_003C_003E8__locals0.item.UOM.isFractional && string_5 != OrderTypes.MakeToStock)
		{
			if (CS_0024_003C_003E8__locals0.item.UseSmartBarcode && nullable_0.HasValue)
			{
				qty = Math.Round(nullable_0.Value / CS_0024_003C_003E8__locals0.item.ItemPrice, 4, MidpointRounding.AwayFromZero);
			}
			else
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData("Enter Weight In: " + CS_0024_003C_003E8__locals0.item.UOM.Name, 4);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				qty = MemoryLoadedObjects.Numpad.numberEntered;
			}
		}
		else if (CS_0024_003C_003E8__locals0.item.UOM != null && !CS_0024_003C_003E8__locals0.item.UOM.isFractional && CS_0024_003C_003E8__locals0.item.UseSmartBarcode && nullable_0.HasValue)
		{
			decimal_ = nullable_0.Value;
		}
		if (CS_0024_003C_003E8__locals0.item.BatchStockQty > 1m && string_5 == OrderTypes.MakeToStock)
		{
			qty = CS_0024_003C_003E8__locals0.item.BatchStockQty;
		}
		int int_17 = 0;
		string string_17 = "";
		PromotionCheck promotion = PromotionMethods.GetPromotion(radListItems, CS_0024_003C_003E8__locals0.item, string_5, OrderDateCreated);
		if (promotion.IsPromotion)
		{
			decimal_ = promotion.NewItemPrice;
			int_17 = promotion.PromotionId;
			string_17 = promotion.promoCode;
		}
		if (string_5 == OrderTypes.MakeToStock)
		{
			decimal_ = default(decimal);
		}
		if (CS_0024_003C_003E8__locals0.item.TaxesIncluded)
		{
			decimal inventoryCount = CS_0024_003C_003E8__locals0.item.InventoryCount;
			CS_0024_003C_003E8__locals0.item.InventoryCount = 1m;
			decimal_ = TaxMethods.GetPreTaxPrice(new List<Item> { CS_0024_003C_003E8__locals0.item }, CS_0024_003C_003E8__locals0.item);
			CS_0024_003C_003E8__locals0.item.InventoryCount = inventoryCount;
		}
		List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		List<GroupsInItem> list2 = gClass.GroupsInItems.Where((GroupsInItem a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		if (list.Count <= 0 && list2.Count <= 0)
		{
			if (lblSubstitutionMode.Visible)
			{
				DataManager dataManager = new DataManager();
				int num2 = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
				if (dataManager.getItemsInItem(num2).Count() > 0)
				{
					new NotificationLabel(this, Resources.You_cannot_substitute_the_main, NotificationTypes.Notification).Show();
					return;
				}
				if (num2 == CS_0024_003C_003E8__locals0.item.ItemID)
				{
					new NotificationLabel(this, "You cannot substitute the same Item.", NotificationTypes.Notification).Show();
					return;
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Substitution_Price, 2, 4, "0");
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
				{
					string empty = string.Empty;
					if (!radListItems.SelectedItems[0][1].ToString().Contains("SUB: "))
					{
						empty = radListItems.SelectedItems[0][1].ToString();
					}
					else
					{
						empty = radListItems.SelectedItems[0][1].ToString();
						int num3 = empty.IndexOf("SUB: ") + "SUB: ".Length;
						int num4 = empty.LastIndexOf(" FOR");
						empty = empty.Substring(num3, num4 - num3);
					}
					string text = CS_0024_003C_003E8__locals0.item.ItemName;
					if (bool_19)
					{
						text = text.ToUpper();
					}
					radListItems.SelectedItems[0][1] = "SUB: " + empty + " FOR " + text;
					radListItems.SelectedItems[0][2] = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.00", Thread.CurrentThread.CurrentCulture);
					string fraction = (string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString());
					radListItems.SelectedItems[0][3] = (Convert.ToDecimal(MathHelper.FractionToDecimal(fraction)) * MemoryLoadedObjects.Numpad.numberEntered).ToString("0.00");
					radListItems.SelectedItems[0].SubItems[4] = CS_0024_003C_003E8__locals0.item.ItemID.ToString();
					string text2 = radListItems.SelectedItems[0].SubItems[5].ToString();
					foreach (ListViewDataItem item in radListItems.Items)
					{
						if (item.SubItems[5].ToString() == text2)
						{
							item.SubItems[7] = item.SubItems[7].ToString() + "===";
						}
					}
					radListItems.Enabled = true;
					if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
					{
						MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Enabled = true;
					}
					btnItemSub.Text = Resources.ITEM_SUB;
					lblSubstitutionMode.Visible = false;
					btnRemove.Enabled = true;
					bool_3 = true;
					CloneListviewToSecondScreen();
				}
			}
			else
			{
				List<usp_ItemOptionsResult> source = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult i) => i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0) && (i.GroupOrderTypes == null || i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.string_5))).ToList();
				if (source.Count() > 0)
				{
					int int_18 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
					num++;
					bool flag = false;
					using (List<short>.Enumerator enumerator2 = (from a in source
						where a.MinGroupOptions == 1 && a.MaxGroupOptions == 1
						group a by a.GroupID into a
						select a.Key).ToList().GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass152_5 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass152_5();
							CS_0024_003C_003E8__locals3.groupId = enumerator2.Current;
							if (source.Where((usp_ItemOptionsResult a) => a.MinGroupOptions == 1 && a.MaxGroupOptions == 1 && a.GroupID == CS_0024_003C_003E8__locals3.groupId && a.Preselect).Count() == 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!CS_0024_003C_003E8__locals0.item.AutoPromptOptions && !flag)
					{
						method_28(CS_0024_003C_003E8__locals0.item.ItemName, decimal_, CS_0024_003C_003E8__locals0.selectedTag, qty, short_4, bool_30: true, int_18, 0, num, bool_31: true, int_17, string_17);
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
						MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals0.item.ItemName, CS_0024_003C_003E8__locals0.item.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5, null, newItem: true, autoPopulate: true);
						MemoryLoadedObjects.OptionScreen.courseGroup = method_26(CS_0024_003C_003E8__locals0.item.ItemCourse);
						MemoryLoadedObjects.OptionScreen.Done();
						short_4++;
					}
					else
					{
						method_28(CS_0024_003C_003E8__locals0.item.ItemName, decimal_, CS_0024_003C_003E8__locals0.selectedTag, qty, short_4, bool_30: true, int_18, 0, num, bool_31: true, int_17, string_17);
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
						MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals0.item.ItemName, CS_0024_003C_003E8__locals0.item.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5);
						MemoryLoadedObjects.OptionScreen.courseGroup = method_26(CS_0024_003C_003E8__locals0.item.ItemCourse);
						DialogResult dialogResult = MemoryLoadedObjects.OptionScreen.ShowDialog(this);
						if (dialogResult != DialogResult.Cancel)
						{
							short_4++;
						}
						else if (dialogResult == DialogResult.Cancel)
						{
							method_27(1m, CS_0024_003C_003E8__locals0.item.ItemID);
							radListItems.Items.Remove(radListItems.Items.Last());
							if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
							{
								try
								{
									if (MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count > 0)
									{
										MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Remove(MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Last());
									}
								}
								catch
								{
								}
							}
						}
					}
				}
				else
				{
					int int_19 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
					method_28(CS_0024_003C_003E8__locals0.item.ItemName, decimal_, CS_0024_003C_003E8__locals0.selectedTag, qty, 0, bool_30: true, int_19, 0, 0, bool_31: true, int_17, string_17);
				}
			}
		}
		else
		{
			if (lblSubstitutionMode.Visible)
			{
				new NotificationLabel(this, Resources.You_cannot_substitute_for_a_ma, NotificationTypes.Warning).Show();
				return;
			}
			int int_20 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.item);
			num++;
			method_28(CS_0024_003C_003E8__locals0.item.ItemName, decimal_, CS_0024_003C_003E8__locals0.selectedTag, qty, short_4, bool_30: true, int_20, 0, num, bool_31: true, int_17, string_17);
			if (CS_0024_003C_003E8__locals0.item.AutoPromptOptions && (from i in MemoryLoadedObjects.all_item_options
				where i.ItemID == CS_0024_003C_003E8__locals0.item.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0) && (i.GroupOrderTypes == null || i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals0._003C_003E4__this.string_5))
				orderby i.SortOrder, i.ItemName
				select i).ToList().Count() > 0)
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
				MemoryLoadedObjects.OptionScreen.courseGroup = listViewDataItemGroup_0;
				MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals0.item.ItemName, CS_0024_003C_003E8__locals0.item.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5);
				if (MemoryLoadedObjects.OptionScreen.ShowDialog(this) == DialogResult.Cancel)
				{
					method_27(1m, CS_0024_003C_003E8__locals0.item.ItemID);
					radListItems.Items.Remove(radListItems.Items.Last());
					if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
					{
						try
						{
							if (MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count > 0)
							{
								MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Remove(MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Last());
							}
						}
						catch
						{
						}
					}
					RecalculateTaxAndSubtotal();
					method_57();
					return;
				}
			}
			if (list.Count > 0)
			{
				using List<ItemsInItem>.Enumerator enumerator3 = list.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass152_1 _003C_003Ec__DisplayClass152_ = new _003C_003Ec__DisplayClass152_1();
					_003C_003Ec__DisplayClass152_.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
					_003C_003Ec__DisplayClass152_.itemChild = enumerator3.Current;
					_003C_003Ec__DisplayClass152_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass152_2();
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass152_;
					CS_0024_003C_003E8__locals1.itemChildDetails = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.itemChild.ItemID).FirstOrDefault();
					if (CS_0024_003C_003E8__locals1.itemChildDetails == null)
					{
						continue;
					}
					int batchId = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals1.itemChildDetails);
					num++;
					decimal childItemPrice = (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.itemChild.UseChildItemPriceAndTax ? CS_0024_003C_003E8__locals1.itemChildDetails.ItemPrice : 0m);
					addPackageItems("   " + CS_0024_003C_003E8__locals1.itemChildDetails.ItemName, childItemPrice, CS_0024_003C_003E8__locals1.itemChildDetails.ItemID, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.itemChild.Quantity.Value, batchId, num);
					if (bool_8 && CS_0024_003C_003E8__locals1.itemChildDetails.AutoPromptOptions && (from i in MemoryLoadedObjects.all_item_options
						where i.ItemID == CS_0024_003C_003E8__locals1.itemChildDetails.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0) && (i.GroupOrderTypes == null || i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.string_5))
						orderby i.SortOrder, i.ItemName
						select i).ToList().Count() > 0)
					{
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
						MemoryLoadedObjects.OptionScreen.courseGroup = listViewDataItemGroup_0;
						MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals1.itemChildDetails.ItemName, CS_0024_003C_003E8__locals1.itemChildDetails.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5);
						if (MemoryLoadedObjects.OptionScreen.ShowDialog(this) == DialogResult.Cancel)
						{
							method_27(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.itemChild.Quantity.Value, CS_0024_003C_003E8__locals1.itemChildDetails.ItemID);
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (GroupsInItem item2 in list2)
				{
					for (int j = 0; (decimal)j < item2.Quantity; j++)
					{
						_003C_003Ec__DisplayClass152_3 _003C_003Ec__DisplayClass152_2 = new _003C_003Ec__DisplayClass152_3();
						_003C_003Ec__DisplayClass152_2.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
						_003C_003Ec__DisplayClass152_2.frmSel = new frmGroupsInItemSelection(item2.GroupID, ", choice no. " + (j + 1));
						if (_003C_003Ec__DisplayClass152_2.frmSel.ShowDialog() == DialogResult.OK)
						{
							_003C_003Ec__DisplayClass152_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass152_4();
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals4 = _003C_003Ec__DisplayClass152_2;
							CS_0024_003C_003E8__locals2.itemInGroup = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals4.frmSel.returnItemId).FirstOrDefault();
							if (CS_0024_003C_003E8__locals2.itemInGroup != null)
							{
								int int_21 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals2.itemInGroup);
								num++;
								method_28("   " + CS_0024_003C_003E8__locals2.itemInGroup.ItemName, 0m, CS_0024_003C_003E8__locals2.itemInGroup.ItemID, qty, short_4, bool_30: false, int_21, item2.GroupID, num);
								if (bool_8 && CS_0024_003C_003E8__locals2.itemInGroup.AutoPromptOptions && (from a in MemoryLoadedObjects.all_item_options
									where a.ItemID == CS_0024_003C_003E8__locals2.itemInGroup.ItemID && !a.ToBeDeleted && ((a.GroupID > 0 && a.OptionsGroupShowOrderEntry == true) || a.GroupID == 0) && (a.GroupOrderTypes == null || a.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3._003C_003E4__this.string_5))
									orderby a.SortOrder, a.ItemName
									select a).ToList().Count() > 0)
								{
									MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
									MemoryLoadedObjects.OptionScreen.courseGroup = listViewDataItemGroup_0;
									MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals2.itemInGroup.ItemName, CS_0024_003C_003E8__locals2.itemInGroup.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5);
									if (MemoryLoadedObjects.OptionScreen.ShowDialog(this) == DialogResult.Cancel)
									{
										method_27(1m, CS_0024_003C_003E8__locals2.itemInGroup.ItemID);
									}
								}
							}
						}
						_003C_003Ec__DisplayClass152_2.frmSel.Dispose();
					}
				}
			}
			GC.Collect();
			short_4++;
		}
		if (radListItems.Items.Count > 0)
		{
			radListItems.ListViewElement.ViewElement.Scroller.ScrollToItem(radListItems.Items.Last());
		}
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null && MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count > 0)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.ListViewElement.ViewElement.Scroller.ScrollToItem(MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Last());
		}
		checkCombo(CS_0024_003C_003E8__locals0.selectedTag);
		RecalculateTaxAndSubtotal();
		method_57();
		listViewDataItemGroup_0 = null;
		GC.Collect();
	}

	private ListViewDataItemGroup method_26(string string_16)
	{
		if (string_16.ToUpper() == "APPETIZER")
		{
			if (!radListItems.Groups.Contains(listViewDataItemGroup_1))
			{
				radListItems.Groups.Add(listViewDataItemGroup_1);
			}
			listViewDataItemGroup_1.Visible = true;
			return listViewDataItemGroup_1;
		}
		if (string_16.ToUpper() == "BEVERAGE")
		{
			if (!radListItems.Groups.Contains(listViewDataItemGroup_2))
			{
				radListItems.Groups.Add(listViewDataItemGroup_2);
			}
			listViewDataItemGroup_2.Visible = true;
			return listViewDataItemGroup_2;
		}
		if (string_16.ToUpper() == "DESSERT")
		{
			if (!radListItems.Groups.Contains(listViewDataItemGroup_3))
			{
				radListItems.Groups.Add(listViewDataItemGroup_3);
			}
			listViewDataItemGroup_3.Visible = true;
			return listViewDataItemGroup_3;
		}
		if (string_16.ToUpper().Contains("ENTR"))
		{
			if (!radListItems.Groups.Contains(listViewDataItemGroup_4))
			{
				radListItems.Groups.Add(listViewDataItemGroup_4);
			}
			listViewDataItemGroup_4.Visible = true;
			return listViewDataItemGroup_4;
		}
		if (string_16.ToUpper() == "SIDE")
		{
			if (!radListItems.Groups.Contains(listViewDataItemGroup_5))
			{
				radListItems.Groups.Add(listViewDataItemGroup_5);
			}
			listViewDataItemGroup_5.Visible = true;
			return listViewDataItemGroup_5;
		}
		if (!radListItems.Groups.Contains(listViewDataItemGroup_6))
		{
			radListItems.Groups.Add(listViewDataItemGroup_6);
		}
		listViewDataItemGroup_6.Visible = true;
		return listViewDataItemGroup_6;
	}

	public void checkCombo(int selectedTag)
	{
		if (SettingsHelper.GetSettingValueByKey("use_combo_potential") == "OFF")
		{
			return;
		}
		int num = 0;
		GClass6 gClass = new GClass6();
		using List<PossibleCombo>.Enumerator enumerator = (from x in list_8
			group x by x.ParentItemId into x
			select x.First()).ToList().GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass154_0 _003C_003Ec__DisplayClass154_ = new _003C_003Ec__DisplayClass154_0();
			_003C_003Ec__DisplayClass154_._003C_003E4__this = this;
			_003C_003Ec__DisplayClass154_.combo = enumerator.Current;
			_003C_003Ec__DisplayClass154_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass154_1();
			CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass154_;
			if (list_9.Contains(CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1.combo) || MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1.combo.ParentItemId && !a.isDeleted && a.Active).FirstOrDefault() == null)
			{
				continue;
			}
			List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1.combo.ParentItemId).ToList();
			CS_0024_003C_003E8__locals7.comboGroups = gClass.GroupsInItems.Where((GroupsInItem a) => (int?)a.ItemID == CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1.combo.ParentItemId).ToList();
			bool flag = list.Where(delegate(ItemsInItem itemsInItem_0)
			{
				_003C_003Ec__DisplayClass154_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass154_2();
				CS_0024_003C_003E8__locals0.x = itemsInItem_0;
				decimal? quantity = CS_0024_003C_003E8__locals0.x.Quantity;
				decimal num9 = (from i in list_11
					where i.ToString() == CS_0024_003C_003E8__locals0.x.ItemID.ToString()
					select (i)).ToList().Count;
				return (quantity.GetValueOrDefault() <= num9) & quantity.HasValue;
			}).Count() >= list.Count;
			bool flag2 = false;
			int num2 = 0;
			List<BillItemsWithCount> source = (from a in list_11
				group a by a into a
				select new BillItemsWithCount
				{
					ItemId = a.Key,
					qty = a.Count()
				}).ToList();
			using (List<GroupsInItem>.Enumerator enumerator2 = CS_0024_003C_003E8__locals7.comboGroups.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass154_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass154_3();
					CS_0024_003C_003E8__locals0.cg = enumerator2.Current;
					BillItemsWithCount billItemsWithCount = source.Where((BillItemsWithCount b) => (from a in MemoryLoadedObjects.all_itemsInGroups
						where a.GroupID == CS_0024_003C_003E8__locals0.cg.GroupID
						select a.ItemID).ToList().Contains(b.ItemId)).FirstOrDefault();
					if (billItemsWithCount != null && CS_0024_003C_003E8__locals0.cg.Quantity <= (decimal)billItemsWithCount.qty)
					{
						num2++;
					}
				}
			}
			if (num2 >= CS_0024_003C_003E8__locals7.comboGroups.Count)
			{
				flag2 = true;
			}
			if (!flag || !flag2)
			{
				continue;
			}
			_003C_003Ec__DisplayClass154_4 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass154_4();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals7;
			CS_0024_003C_003E8__locals1.comboItem = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.combo.ParentItemId).FirstOrDefault();
			if (new frmMessageBox(Resources.The_combo_items_for + CS_0024_003C_003E8__locals1.comboItem.ItemName + Resources._exist_within_the_order_Would_ + CS_0024_003C_003E8__locals1.comboItem.ItemName + Resources._instead, Resources.Create_Combo, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				decimal decimal_ = (CS_0024_003C_003E8__locals1.comboItem.OnSale ? CS_0024_003C_003E8__locals1.comboItem.ItemSalePrice.Value : CS_0024_003C_003E8__locals1.comboItem.ItemPrice);
				int int_ = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals1.comboItem);
				num++;
				method_28(CS_0024_003C_003E8__locals1.comboItem.ItemName, decimal_, CS_0024_003C_003E8__locals1.comboItem.ItemID, 1m, short_4, bool_30: false, int_, 0, num);
				if (bool_8 && CS_0024_003C_003E8__locals1.comboItem.AutoPromptOptions && (from i in MemoryLoadedObjects.all_item_options
					where i.ItemID == CS_0024_003C_003E8__locals1.comboItem.ItemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0) && (i.GroupOrderTypes == null || i.GroupOrderTypes.Split(',').Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.string_5))
					orderby i.SortOrder, i.ItemName
					select i).ToList().Count() > 0)
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
					MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals1.comboItem.ItemName, CS_0024_003C_003E8__locals1.comboItem.ItemID, 1m, radListItems.Items.Count - 1, num, this, string_5);
					if (MemoryLoadedObjects.OptionScreen.ShowDialog(this) == DialogResult.Cancel)
					{
						method_27(1m, CS_0024_003C_003E8__locals1.comboItem.ItemID);
					}
				}
				new List<ListViewDataItem>();
				if (list.Count > 0)
				{
					using (List<ItemsInItem>.Enumerator enumerator3 = list.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							_003C_003Ec__DisplayClass154_5 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass154_5();
							CS_0024_003C_003E8__locals2.subItem = enumerator3.Current;
							_003C_003Ec__DisplayClass154_6 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass154_6();
							decimal? num3 = CS_0024_003C_003E8__locals2.subItem.Quantity;
							List<ListViewDataItem> list2 = radListItems.Items.Where((ListViewDataItem x) => x.SubItems[4].ToString() == CS_0024_003C_003E8__locals2.subItem.ItemID.ToString() && Convert.ToBoolean(x.SubItems[12].ToString())).ToList();
							CS_0024_003C_003E8__locals3.mainGroupItem = list2.FirstOrDefault();
							if (CS_0024_003C_003E8__locals3.mainGroupItem != null && CS_0024_003C_003E8__locals3.mainGroupItem.SubItems[5].ToString() != "0")
							{
								radListItems.Items.Where((ListViewDataItem x) => x.SubItems[5].ToString() == CS_0024_003C_003E8__locals3.mainGroupItem.SubItems[5].ToString()).ToList();
							}
							using List<ListViewDataItem>.Enumerator enumerator4 = list2.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								_003C_003Ec__DisplayClass154_7 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass154_7();
								CS_0024_003C_003E8__locals4.lvMain = enumerator4.Current;
								List<ListViewDataItem> list3 = new List<ListViewDataItem>();
								list3.Add(CS_0024_003C_003E8__locals4.lvMain);
								if (CS_0024_003C_003E8__locals4.lvMain != null && CS_0024_003C_003E8__locals4.lvMain.SubItems[5].ToString() != "0")
								{
									list3 = radListItems.Items.Where((ListViewDataItem x) => x.SubItems[5].ToString() == CS_0024_003C_003E8__locals4.lvMain.SubItems[5].ToString()).ToList();
								}
								decimal num4 = Convert.ToDecimal(CS_0024_003C_003E8__locals4.lvMain[0].ToString());
								decimal? num5 = num3;
								if (!((num5.GetValueOrDefault() > default(decimal)) & num5.HasValue))
								{
									continue;
								}
								num5 = num3;
								decimal num6 = num4;
								if ((num5.GetValueOrDefault() < num6) & num5.HasValue)
								{
									foreach (ListViewDataItem item4 in list3)
									{
										item4[0] = ((decimal?)num4 - num3).ToString().Replace(".00", string.Empty);
										item4[3] = (Convert.ToDecimal(item4[0].ToString(), Thread.CurrentThread.CurrentCulture) * Convert.ToDecimal(item4[2].ToString(), Thread.CurrentThread.CurrentCulture)).ToString("0.00", Thread.CurrentThread.CurrentCulture);
									}
									num3 = default(decimal);
									continue;
								}
								num3 -= (decimal?)num4;
								foreach (ListViewDataItem item5 in list3)
								{
									if (MemoryLoadedObjects.OrderEntrySecondScreen != null && radListItems.Items.Count > 0)
									{
										MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.RemoveAt(radListItems.Items.IndexOf(item5));
									}
									radListItems.Items.Remove(item5);
								}
							}
						}
					}
					CloneListviewToSecondScreen();
					using List<ItemsInItem>.Enumerator enumerator3 = list.ToList().GetEnumerator();
					while (enumerator3.MoveNext())
					{
						_003C_003Ec__DisplayClass154_8 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass154_8();
						CS_0024_003C_003E8__locals5.subItem = enumerator3.Current;
						int item = Convert.ToInt32(CS_0024_003C_003E8__locals5.subItem.ItemID);
						int num7 = 0;
						while (true)
						{
							decimal num8 = num7;
							decimal? num5 = CS_0024_003C_003E8__locals5.subItem.Quantity;
							if (!((num8 < num5.GetValueOrDefault()) & num5.HasValue))
							{
								break;
							}
							list_11.Remove(item);
							num7++;
						}
						if (!list_11.Contains(item))
						{
							list_8.RemoveAll((PossibleCombo x) => x.ItemId == CS_0024_003C_003E8__locals5.subItem.ItemID && x.ParentItemId == CS_0024_003C_003E8__locals5.subItem.ParentItemID);
							list_10.Remove(item);
						}
					}
				}
				if (list.Count > 0)
				{
					using List<ItemsInItem>.Enumerator enumerator3 = list.ToList().GetEnumerator();
					while (enumerator3.MoveNext())
					{
						_003C_003Ec__DisplayClass154_9 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass154_9();
						CS_0024_003C_003E8__locals6.itemChild = enumerator3.Current;
						Item item2 = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals6.itemChild.ItemID).FirstOrDefault();
						int batchId = orderHelper_0.CheckAndSelectBatchId(item2);
						num++;
						decimal childItemPrice = (CS_0024_003C_003E8__locals6.itemChild.UseChildItemPriceAndTax ? item2.ItemPrice : 0m);
						addPackageItems("   " + item2.ItemName, childItemPrice, item2.ItemID, CS_0024_003C_003E8__locals6.itemChild.Quantity.Value, batchId, num);
					}
				}
				if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.comboGroups.Count > 0)
				{
					using List<int>.Enumerator enumerator6 = list_11.Where((int a) => (from x in MemoryLoadedObjects.all_itemsInGroups
						where CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.comboGroups.Select((GroupsInItem b) => b.GroupID).ToList().Contains(x.GroupID.Value)
						select x into z
						select z.ItemID).ToList().Contains(a)).ToList().GetEnumerator();
					while (enumerator6.MoveNext())
					{
						_003C_003Ec__DisplayClass154_10 _003C_003Ec__DisplayClass154_2 = new _003C_003Ec__DisplayClass154_10();
						_003C_003Ec__DisplayClass154_2.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals1;
						_003C_003Ec__DisplayClass154_2.itemChild = enumerator6.Current;
						_003C_003Ec__DisplayClass154_11 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass154_11();
						CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4 = _003C_003Ec__DisplayClass154_2;
						List<ListViewDataItem> list4 = radListItems.Items.Where((ListViewDataItem x) => x.SubItems[4].ToString() == CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4.itemChild.ToString() && Convert.ToBoolean(x.SubItems[12].ToString())).ToList();
						CS_0024_003C_003E8__locals8.mainGroupItem = list4.FirstOrDefault();
						List<ListViewDataItem> list5 = new List<ListViewDataItem>();
						if (CS_0024_003C_003E8__locals8.mainGroupItem != null && CS_0024_003C_003E8__locals8.mainGroupItem.SubItems[5].ToString() != "0")
						{
							list4 = radListItems.Items.Where((ListViewDataItem x) => x.SubItems[5].ToString() == CS_0024_003C_003E8__locals8.mainGroupItem.SubItems[5].ToString()).ToList();
							list5 = radListItems.Items.Where((ListViewDataItem x) => x.SubItems[4].ToString() != CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4.itemChild.ToString() && x.SubItems[5].ToString() == CS_0024_003C_003E8__locals8.mainGroupItem.SubItems[5].ToString()).ToList();
						}
						foreach (ListViewDataItem item6 in list4)
						{
							if (MemoryLoadedObjects.OrderEntrySecondScreen != null && MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count > 0)
							{
								MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.RemoveAt(radListItems.Items.IndexOf(item6));
							}
							radListItems.Items.Remove(item6);
						}
						CS_0024_003C_003E8__locals8.itemInGroup = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4.itemChild).FirstOrDefault();
						if (CS_0024_003C_003E8__locals8.itemInGroup == null)
						{
							continue;
						}
						int int_2 = orderHelper_0.CheckAndSelectBatchId(CS_0024_003C_003E8__locals8.itemInGroup);
						num++;
						method_28("   " + CS_0024_003C_003E8__locals8.itemInGroup.ItemName, 0m, CS_0024_003C_003E8__locals8.itemInGroup.ItemID, 1m, short_4, bool_30: false, int_2, 0, num);
						foreach (ListViewDataItem item7 in list5)
						{
							_003C_003Ec__DisplayClass154_12 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass154_12();
							CS_0024_003C_003E8__locals9.itemOptionChildId = Convert.ToInt32(item7.SubItems[4].ToString());
							Item item3 = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals9.itemOptionChildId).FirstOrDefault();
							int int_3 = orderHelper_0.CheckAndSelectBatchId(item3);
							method_28("   " + item7[1].ToString().ToUpper(), 0m, CS_0024_003C_003E8__locals9.itemOptionChildId, 1m, short_4, bool_30: false, int_3, 0, num);
						}
						list_11.Remove(CS_0024_003C_003E8__locals8.itemInGroup.ItemID);
						if (!list_11.Contains(CS_0024_003C_003E8__locals8.itemInGroup.ItemID))
						{
							list_8.RemoveAll((PossibleCombo x) => x.ItemId == CS_0024_003C_003E8__locals8.itemInGroup.ItemID && x.ParentItemId == CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals3.comboItem.ItemID);
							list_10.Remove(CS_0024_003C_003E8__locals8.itemInGroup.ItemID);
						}
					}
				}
				short_4++;
			}
			else
			{
				list_9.Add(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.combo);
				method_27(1m, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.combo.ParentItemId.Value);
				list_10.Clear();
			}
			RecalculateTaxAndSubtotal();
			method_57();
		}
	}

	private void method_27(decimal decimal_7, int int_16)
	{
		_003C_003Ec__DisplayClass155_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass155_0();
		CS_0024_003C_003E8__locals0.itemId = int_16;
		if (decimal_7 >= 10000m)
		{
			decimal_7 = 10000m;
		}
		for (int i = 0; (decimal)i < decimal_7; i++)
		{
			list_11.Remove(CS_0024_003C_003E8__locals0.itemId);
		}
		if (!list_11.Contains(CS_0024_003C_003E8__locals0.itemId))
		{
			list_8.RemoveAll((PossibleCombo x) => x.ItemId == CS_0024_003C_003E8__locals0.itemId);
			list_10.Remove(CS_0024_003C_003E8__locals0.itemId);
		}
	}

	public void addPackageItems(string childItemName, decimal childItemPrice, int childItemID, decimal childQuantity, int batchId, int optionComboId = 0, bool useChildItemPriceAndTax = false)
	{
		_003C_003Ec__DisplayClass156_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass156_0();
		CS_0024_003C_003E8__locals0.childItemID = childItemID;
		GClass6 gClass = new GClass6();
		method_28(childItemName, childItemPrice, CS_0024_003C_003E8__locals0.childItemID, childQuantity, short_4, bool_30: false, batchId, 0, optionComboId, useChildItemPriceAndTax);
		List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals0.childItemID).ToList();
		if (list.Count == 0)
		{
			return;
		}
		using List<ItemsInItem>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass156_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass156_1();
			CS_0024_003C_003E8__locals1.itemChild = enumerator.Current;
			Item item = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.itemChild.ItemID).FirstOrDefault();
			if (item != null)
			{
				int batchId2 = orderHelper_0.CheckAndSelectBatchId(item);
				string itemName = item.ItemName;
				decimal childItemPrice2 = (CS_0024_003C_003E8__locals1.itemChild.UseChildItemPriceAndTax ? item.ItemPrice : 0m);
				addPackageItems("   " + itemName, childItemPrice2, item.ItemID, CS_0024_003C_003E8__locals1.itemChild.Quantity.Value, batchId2, optionComboId, CS_0024_003C_003E8__locals1.itemChild.UseChildItemPriceAndTax);
			}
		}
	}

	private void method_28(string string_16, decimal decimal_7, int int_16, decimal qty = 1m, int int_17 = 0, bool bool_30 = true, int int_18 = 0, int int_19 = 0, int int_20 = 0, bool bool_31 = true, int int_21 = 0, string string_17 = "", int int_22 = 0)
	{
		_003C_003Ec__DisplayClass157_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass157_0();
		CS_0024_003C_003E8__locals0.itemID = int_16;
		GClass6 gClass = new GClass6();
		if (bool_30 && CS_0024_003C_003E8__locals0.itemID != -999)
		{
			list_11.Add(CS_0024_003C_003E8__locals0.itemID);
			if (!list_10.Contains(CS_0024_003C_003E8__locals0.itemID))
			{
				_003C_003Ec__DisplayClass157_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass157_1();
				list_10.Add(CS_0024_003C_003E8__locals0.itemID);
				list_8.AddRange((from x in gClass.ItemsInItems
					where x.ItemID == (int?)CS_0024_003C_003E8__locals0.itemID
					select x into j
					select new PossibleCombo
					{
						ParentItemId = j.ParentItemID,
						ItemId = j.ItemID
					}).ToList());
				CS_0024_003C_003E8__locals1.itemInGroup = MemoryLoadedObjects.all_itemsInGroups.Where((ItemsInGroup a) => a.ItemID == CS_0024_003C_003E8__locals0.itemID).ToList();
				list_8.AddRange((from x in gClass.GroupsInItems
					where CS_0024_003C_003E8__locals1.itemInGroup.Select((ItemsInGroup a) => a.GroupID).Contains(x.GroupID)
					select x into j
					select new PossibleCombo
					{
						ParentItemId = j.ItemID,
						GroupId = j.GroupID
					}).ToList());
			}
		}
		string text = ((string_16.Length > 3 && string_16.Substring(0, 3) == "   " && !string_16.Contains("OPT: ")) ? "ChildItem" : (string_16.Contains("OPT: ") ? "OptionItem" : "MainItem"));
		string text2 = "-1";
		if (string_16.ToUpper().Contains(Resources._CUSTOM) || string_16.ToUpper().Contains("OPEN CATER") || string_16.ToUpper().Contains("GIFT CARD") || string_16.ToUpper().Contains("GIFT CERTIFICATE") || !bool_31)
		{
			text2 = decimal_7.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		if (bool_19)
		{
			string_16 = string_16.ToUpper();
		}
		if (dateFullfilment.HasValue)
		{
			orderOnHoldTime = (int)(dateFullfilment.Value - DateTime.Now).TotalMinutes;
		}
		string[] values = new string[23]
		{
			qty.ToString("0.####", Thread.CurrentThread.CurrentCulture),
			string_16,
			decimal_7.ToString("0.00##", Thread.CurrentThread.CurrentCulture),
			(qty * decimal_7).ToString("0.00", Thread.CurrentThread.CurrentCulture),
			CS_0024_003C_003E8__locals0.itemID.ToString(),
			int_17.ToString(),
			string.Empty,
			string.Empty,
			text2,
			int_18.ToString(),
			int_19.ToString(),
			int_20.ToString(),
			bool_30.ToString(),
			string_17,
			orderOnHoldTime.ToString(),
			"",
			text,
			int_22.ToString(),
			int_21.ToString(),
			"",
			"",
			false.ToString(),
			""
		};
		ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
		if (string_16.ToUpper() != "DELIVERY FEE")
		{
			Item item = MemoryLoadedData.all_active_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.itemID).FirstOrDefault();
			listViewDataItem.Group = (listViewDataItemGroup_0 = method_26((item != null) ? item.ItemCourse : ItemCourses.Uncategorized));
		}
		else
		{
			listViewDataItem.Group = (listViewDataItemGroup_0 = method_26(ItemCourses.Uncategorized));
		}
		listViewDataItem.Font = radListItems.Font;
		FormHelper.ChangeOrderEntryLVCellByIdentifier(radListItems, listViewDataItem, radListItems.Font.Size, text);
		radListItems.Items.Add(listViewDataItem);
		CloneListviewToSecondScreen();
	}

	private void method_29()
	{
		if (!string.IsNullOrEmpty(string_3))
		{
			btnClear.Text = Resources.VOID_ORDER;
			btnClear.Image = picTrash.Image;
		}
		else if (string_5 == OrderTypes.DineIn)
		{
			btnClear.Text = "HOLD ORDER";
			btnClear.Image = picLock.Image;
		}
		if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			if ((string_5.Equals(OrderTypes.DineIn) || string_5.Equals(OrderTypes.ToGo)) && btnClear.Text == "HOLD ORDER")
			{
				btnClear.Enabled = false;
				btnClear.Text = Resources.VOID_ORDER;
				btnClear.Image = picTrash.Image;
			}
			else if (string_5.Equals(OrderTypes.PickUp) || string_5.Equals(OrderTypes.PickUpOnline) || string_5.Equals(OrderTypes.Delivery) || string_5.Equals(OrderTypes.DeliveryOnline) || btnClear.Text == Resources.VOID_ORDER)
			{
				btnClear.Enabled = true;
			}
		}
		else if (string_5.Equals(OrderTypes.ToGo) && btnClear.Text == "HOLD ORDER")
		{
			btnClear.Enabled = false;
		}
		else
		{
			btnClear.Enabled = true;
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count != 0)
		{
			if (!string.IsNullOrEmpty(string_3) && AuthMethods.EmployeeAuthenticateControl(this, "btnRemove") == null)
			{
				return;
			}
			decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(radListItems.SelectedItems[0].SubItems[15].ToString(), DiscountTypes.Item);
			if (radListItems.SelectedItems[0].SubItems[1].ToString().ToUpper() == "DELIVERY FEE")
			{
				if (new frmMessageBox("This cannot be reversed.  Are you sure you want to remove the " + radListItems.SelectedItems[0].SubItems[1].ToString() + "?", "Are You Sure?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
				{
					return;
				}
				bool_22 = true;
				isSaved = false;
			}
			ListViewDataItem selectedItem = radListItems.SelectedItem;
			ListViewDataItemGroup group = selectedItem.Group;
			bool flag = false;
			ListViewDataItem listViewDataItem;
			if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
			{
				radListItems.Focus();
				radListItems.MultiSelect = true;
				string text = radListItems.SelectedItems[0].SubItems[5].ToString();
				radListItems.SelectedItems.Clear();
				foreach (ListViewDataItem item in radListItems.Items)
				{
					if (item.SubItems[5].ToString() == text)
					{
						radListItems.Select(new ListViewDataItem[1] { item });
					}
				}
				listViewDataItem = radListItems.SelectedItems[0];
			}
			else
			{
				_003C_003Ec__DisplayClass159_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass159_0();
				radListItems.MultiSelect = false;
				CS_0024_003C_003E8__locals0.comboID = radListItems.SelectedItems[0].SubItems[5].ToString();
				listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.comboID.ToString() && !a[1].ToString().Contains("ADD:") && !a[1].ToString().Contains("OPT: ")).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.comboID.ToString() == "0")
				{
					flag = true;
				}
			}
			int num = 0;
			foreach (ListViewDataItem item2 in radListItems.Items)
			{
				if (item2.Font.Strikeout)
				{
					num++;
				}
			}
			int num2 = radListItems.Items.IndexOf(listViewDataItem);
			int num3 = radListItems.SelectedItems.Count;
			int num4 = radListItems.SelectedItems.Count - 1;
			if (listViewDataItem != null && listViewDataItem.SubItems[4].ToString() == selectedItem.SubItems[4].ToString())
			{
				flag = true;
			}
			int num5 = num4;
			while (true)
			{
				if (num5 >= 0)
				{
					DataManager dataManager = new DataManager();
					int itemID = Convert.ToInt32(radListItems.SelectedItems[num5].SubItems[4].ToString());
					Item oneItem = dataManager.getOneItem(itemID);
					decimal num6 = MathHelper.FractionToDecimal(radListItems.SelectedItems[num5][0].ToString());
					method_27(num6, oneItem.ItemID);
					if (!oneItem.OnSale)
					{
						_ = oneItem.ItemPrice;
					}
					else
					{
						_ = oneItem.ItemSalePrice.Value;
					}
					bool flag2 = false;
					if (!string.IsNullOrEmpty(string_3) && radListItems.SelectedItems[num5].SubItems.Count >= 7)
					{
						if (!string.IsNullOrEmpty(radListItems.SelectedItems[num5].SubItems[6].ToString()))
						{
							if (num6 < 1m && !radListItems.SelectedItems[num5].SubItems[1].ToString().Contains("   "))
							{
								new NotificationLabel(this, "You cannot removed a shared item. ", NotificationTypes.Warning).Show();
								btnRemove.Enabled = true;
								break;
							}
							if (num + num3 == radListItems.Items.Count && !radListItems.SelectedItems[0].Font.Strikeout)
							{
								new NotificationLabel(this, Resources.If_you_are_cancelling_an_entir, NotificationTypes.Warning).Show();
								btnRemove.Enabled = true;
								break;
							}
							foreach (ListViewDataItem selectedItem2 in radListItems.SelectedItems)
							{
								if (!selectedItem2.Font.Strikeout)
								{
									selectedItem2.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Strikeout);
								}
								else if (listViewDataItem == selectedItem2)
								{
									selectedItem2.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Bold);
								}
								else
								{
									selectedItem2.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Regular);
								}
								num5--;
								num3--;
							}
							btnRemove.Text = ((radListItems.SelectedItems[0].Font == null || !radListItems.SelectedItems[0].Font.Strikeout) ? "REMOVE ITEM" : "UNREMOVE ITEM");
							CloneListviewToSecondScreen();
						}
						else
						{
							if (num + num3 == radListItems.Items.Count && num > 0)
							{
								new NotificationLabel(this, Resources.If_you_are_cancelling_an_entir, NotificationTypes.Warning).Show();
								btnRemove.Enabled = true;
								break;
							}
							flag2 = true;
						}
					}
					else
					{
						flag2 = true;
					}
					if (flag2)
					{
						if (flag)
						{
							int selectedIndex = radListItems.SelectedIndex;
							if (MemoryLoadedObjects.OrderEntrySecondScreen != null && MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count > 0)
							{
								MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.RemoveAt(selectedIndex);
							}
							radListItems.Items.RemoveAt(selectedIndex);
							num3--;
						}
						if (num5 > -1)
						{
							ListViewDataItem[] array = new ListViewDataItem[num5];
							for (int i = num2; i < num2 + num5; i++)
							{
								array[i - num2] = radListItems.Items[i];
							}
							radListItems.Select(array);
						}
					}
					num5--;
					continue;
				}
				lblDiscount.Text = (Convert.ToDecimal(lblDiscount.Text) - discountFromDiscountDescription).ToString("0.00");
				RecalculateTaxAndSubtotal();
				method_57();
				if (decimal_1 > decimal_0)
				{
					btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
					bool_0 = false;
					string_0 = "";
					string_1 = "";
					decimal_2 = (decimal_3 = 0m);
					RecalculateTaxAndSubtotal();
					decimal_1 = default(decimal);
					new NotificationLabel(this, "Discount removed. The subtotal is less than the discount.", NotificationTypes.Warning).Show();
				}
				if (radListItems.Items.Count <= 0 && !string_5.Equals(OrderTypes.PickUp) && !string_5.Equals(OrderTypes.Delivery) && !string_5.Equals(OrderTypes.ToGo))
				{
					btnClear.Text = Resources.CLEAR_TABLE;
					btnClear.Image = picTrash.Image;
				}
				else
				{
					if (!string.IsNullOrEmpty(string_3))
					{
						btnClear.Text = Resources.VOID_ORDER;
						btnClear.Image = picTrash.Image;
					}
					else if (string_5 == OrderTypes.DineIn)
					{
						btnClear.Text = "HOLD ORDER";
						btnClear.Image = picLock.Image;
					}
					else
					{
						method_17();
					}
					if (string_5.Equals(OrderTypes.PickUp) || string_5.Equals(OrderTypes.Delivery))
					{
						btnClear.Enabled = radListItems.Items.Count > 0;
					}
				}
				if (group != null && group.Items.Count() == 0)
				{
					group.Visible = false;
				}
				if (radListItems.Items.Where((ListViewDataItem a) => !a.Font.Strikeout).Count() == 1 && radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").Any())
				{
					btnPay.Enabled = false;
				}
				break;
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_you_wish, NotificationTypes.Notification).Show();
		}
	}

	private void method_30()
	{
	}

	private void method_31(short short_10)
	{
		_003C_003Ec__DisplayClass161_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass161_0();
		CS_0024_003C_003E8__locals0.frmSel = new frmGroupsInItemSelection(short_10);
		if (CS_0024_003C_003E8__locals0.frmSel.ShowDialog() == DialogResult.OK)
		{
			new GClass6();
			Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.frmSel.returnItemId).FirstOrDefault();
			if (item != null)
			{
				orderHelper_0.CheckAndSelectBatchId(item);
				string text = item.ItemName;
				if (bool_19)
				{
					text = text.ToUpper();
				}
				radListItems.SelectedItems[0][1] = text;
				radListItems.SelectedItems[0][4] = item.ItemID.ToString();
				CloneListviewToSecondScreen();
			}
		}
		CS_0024_003C_003E8__locals0.frmSel.Dispose();
	}

	public void RecalculateTaxAndSubtotal()
	{
		PromotionMethods.RecalculatePromotion(radListItems, string_5, OrderDateCreated, ref short_4);
		CloneListviewToSecondScreen();
		decimal num = default(decimal);
		decimal_0 = default(decimal);
		DataManager dataManager = new DataManager();
		List<Item> list = new List<Item>();
		foreach (ListViewDataItem item3 in radListItems.Items)
		{
			if (!item3.Font.Strikeout)
			{
				_003C_003Ec__DisplayClass163_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass163_0();
				decimal num2 = MathHelper.FractionToDecimal((string.IsNullOrEmpty(item3[0].ToString()) ? "1" : item3[0].ToString()).Replace(",", "."));
				decimal num3 = Convert.ToDecimal(string.IsNullOrEmpty(item3[2].ToString()) ? "0.00" : item3[2].ToString(), Thread.CurrentThread.CurrentCulture);
				CS_0024_003C_003E8__locals1.selectedTag = Convert.ToInt32(item3.SubItems[4].ToString());
				decimal num4 = ((num2 == 0m) ? 0m : (OrderHelper.GetDiscountFromDiscountDescription(item3.SubItems[15].ToString(), DiscountTypes.Item) / num2));
				Item item2 = ((CS_0024_003C_003E8__locals1.selectedTag == -999) ? dataManager.getDeliveryItem() : MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.selectedTag).FirstOrDefault());
				if (item2 != null)
				{
					list.Add(new Item
					{
						InventoryCount = num2,
						ItemPrice = num3,
						ItemSalePrice = ((num3 >= num4) ? num4 : 0m),
						ItemID = item2.ItemID,
						ItemName = item2.ItemName,
						TaxRule = item2.TaxRule,
						TaxRuleID = item2.TaxRuleID,
						ItemTypeID = item2.ItemTypeID,
						Barcode = item3.SubItems[15].ToString(),
						ItemCost = ((item3.SubItems[8].ToString() == "-1") ? item2.ItemPrice : Convert.ToDecimal(item3.SubItems[8].ToString())),
						Active = true,
						TaxesIncluded = item2.TaxesIncluded
					});
				}
			}
		}
		foreach (Item item4 in list)
		{
			if (OrderHelper.GetDiscountFromDiscountDescription(item4.Barcode, DiscountTypes.Order) > 0m && item4.ItemPrice == 0m && item4.ItemCost > 0m)
			{
				item4.Barcode = OrderHelper.UpdateDiscountFromDiscountDescription(item4.Barcode, DiscountTypes.Order, 0m);
			}
			decimal_0 += Math.Round(item4.InventoryCount * item4.ItemPrice, 2, MidpointRounding.AwayFromZero);
		}
		if (string_1 == DiscountTypes.DollarAmount && decimal_3 > 0m)
		{
			if (decimal_0 > 0m)
			{
				decimal_2 = Math.Round(decimal_3 / decimal_0, 10);
			}
			if (decimal_2 <= 0m || decimal_2 > 1m || list.Count == 0)
			{
				btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
				bool_0 = false;
				string_0 = "";
				string_1 = "";
				decimal_2 = (decimal_3 = 0m);
				decimal_1 = default(decimal);
			}
		}
		decimal_1 = Math.Round(dataManager_0.CalculateOrderDiscount(list, decimal_0, decimal_2), 2, MidpointRounding.AwayFromZero);
		using (List<Item>.Enumerator enumerator2 = list_5.Where((Item a) => a.TaxesIncluded).ToList().GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass163_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass163_1();
				CS_0024_003C_003E8__locals0.taxIncludedItems = enumerator2.Current;
				CS_0024_003C_003E8__locals0.taxIncludedItems.ItemPrice = MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals0.taxIncludedItems.ItemID).First().ItemPrice;
			}
		}
		num = TaxMethods.GetTaxWithRounding(list);
		num = Math.Round(num, 2, MidpointRounding.AwayFromZero);
		lblDiscount.Text = decimal_1.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblTotalTax.Text = num.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblSubTotal.Text = decimal_0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
		lblTotal.Text = (decimal_0 + num - decimal_1).ToString("0.00", Thread.CurrentThread.CurrentCulture);
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.txtDiscount.Text = decimal_1.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtTotalTax.Text = num.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtSubTotal.Text = decimal_0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtTotal.Text = (decimal_0 + num - decimal_1).ToString("0.00", Thread.CurrentThread.CurrentCulture);
		}
		if ((method_35() || !isSaved) && radListItems.Items.Count > 0)
		{
			isSaved = false;
			Button button = btnSaveOrder;
			Button button2 = btnSaveClose;
			ClearBtn.Enabled = true;
			button2.Enabled = true;
			button.Enabled = true;
		}
		else
		{
			isSaved = true;
			Button button3 = btnSaveOrder;
			Button button4 = btnSaveClose;
			ClearBtn.Enabled = false;
			button4.Enabled = false;
			button3.Enabled = false;
		}
		if (string_5 == OrderTypes.Delivery && decimal_5 > 0m && decimal_6 > 0m && !bool_27 && !bool_22)
		{
			bool_27 = true;
			ListViewDataItem listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").FirstOrDefault();
			decimal num5 = list.Where((Item a) => a.ItemID != -999).Sum((Item item) => Math.Round(item.InventoryCount * item.ItemPrice, 2, MidpointRounding.AwayFromZero));
			if (listViewDataItem != null && num5 > decimal_6)
			{
				if (!string.IsNullOrEmpty(listViewDataItem.SubItems[6].ToString()))
				{
					listViewDataItem.Font = new Font(listViewDataItem.Font.FontFamily, listViewDataItem.Font.Size, FontStyle.Strikeout);
				}
				else
				{
					ListViewDataItemGroup group = listViewDataItem.Group;
					radListItems.Items.Remove(listViewDataItem);
					if (group != null && group.Items.Count() == 0)
					{
						group.Visible = false;
					}
				}
				RecalculateTaxAndSubtotal();
			}
			else if (num5 <= decimal_6)
			{
				if (listViewDataItem == null)
				{
					method_46();
				}
				else
				{
					listViewDataItem.Font = new Font(listViewDataItem.Font.FontFamily, listViewDataItem.Font.Size, FontStyle.Regular);
				}
				RecalculateTaxAndSubtotal();
			}
			else
			{
				bool_27 = false;
			}
		}
		else
		{
			bool_27 = false;
		}
		if (SettingsHelper.GetSettingValueByKey("print_chit_cashout") == "ON" && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			if (!(string_5 == OrderTypes.DineIn) && !(string_5 == OrderTypes.ToGo) && radListItems.Items.Count != 0)
			{
				if (string_5 == OrderTypes.Delivery || string_5 == OrderTypes.PickUp || string_5 == OrderTypes.PickUpOnline || string_5 == OrderTypes.DeliveryOnline || string_5 == OrderTypes.PickUpCurbsideOnline || string_5 == OrderTypes.DineInOnline)
				{
					Button button5 = btnSaveClose;
					btnSaveOrder.Enabled = true;
					button5.Enabled = true;
				}
			}
			else
			{
				Button button6 = btnSaveClose;
				btnSaveOrder.Enabled = false;
				button6.Enabled = false;
			}
		}
		method_29();
	}

	private void method_32()
	{
		IOrderedQueryable<Order> source = (from o in new GClass6().Orders
			where o.OrderNumber == string_3 && o.Paid == false && o.Void == false && o.ItemID != -100
			select o into a
			orderby a.ComboID
			select a).ThenBy((Order x) => x.LastDateModified.HasValue ? x.LastDateModified : x.DateCreated);
		list_5 = new List<Item>();
		foreach (Order item2 in source.ToList())
		{
			Item item = new Item();
			Item oneItem = dataManager_0.getOneItem(item2.ItemID);
			item.ItemID = oneItem.ItemID;
			item.TaxesIncluded = oneItem.TaxesIncluded;
			item.InventoryCount = oneItem.InventoryCount;
			item.ItemSalePrice = oneItem.ItemSalePrice;
			item.ItemType = oneItem.ItemType;
			item.ItemTypeID = oneItem.ItemTypeID;
			item.OnSale = oneItem.OnSale;
			item.TaxRule = oneItem.TaxRule;
			item.TaxRuleID = oneItem.TaxRuleID;
			item.ItemName = item2.ItemName;
			if (item2.Qty > 0m)
			{
				decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(item2.DiscountDesc, DiscountTypes.Promo);
				Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(oneItem.ItemID);
				if (promoSaleItemById != null && oneItem.OnSale)
				{
					if (!(Math.Round(promoSaleItemById.GetDiscountAmount.Value, 2) == Math.Round(item2.ItemSellPrice, 2)) && (!(decimal_1 > 0m) || !(Math.Round(item2.Discount / item2.Qty + item2.ItemSellPrice, 2) == Math.Round(oneItem.ItemPrice, 2))))
					{
						item.ItemPrice = item2.ItemSellPrice + item2.Discount / item2.Qty;
					}
					else
					{
						item.ItemPrice = promoSaleItemById.GetDiscountAmount.Value;
					}
				}
				else if (discountFromDiscountDescription > 0m)
				{
					item.ItemPrice = Math.Round(item2.ItemSellPrice + (item2.Discount / item2.Qty - discountFromDiscountDescription), 2);
				}
				else
				{
					item.ItemPrice = item2.ItemSellPrice + item2.Discount / item2.Qty;
				}
			}
			else
			{
				item.ItemPrice = 0m;
			}
			item.InventoryCount = MathHelper.FractionToDecimal(item2.Qty.ToString().Replace(",", "."));
			item.SortOrder = item2.ComboID;
			item.Temp = item2.OrderId.ToString();
			item.Description = (string.IsNullOrEmpty(item2.Instructions) ? string.Empty : item2.Instructions);
			item.Active = !item2.Void;
			item.ItemCost = item2.ItemPrice;
			item.Notes = item2.DiscountReasonItem;
			item.StationID = item2.OrderOnHoldTime.ToString();
			item.Barcode = item2.DiscountDesc;
			item.ItemSalePrice = OrderHelper.GetDiscountFromDiscountDescription(item.Barcode, DiscountTypes.Item) / item.InventoryCount;
			item.ItemClassification = item2.ItemIdentifier;
			item.UOMID = oneItem.UOMID;
			item.UOM = oneItem.UOM;
			item.ItemCourse = oneItem.ItemCourse.ToString().ToUpper();
			item.DisableSoldOutItems = false;
			if (!item.Active && item.Temp != string.Empty && item2 != null && item2.DateFilled.HasValue && oneItem.TrackInventory && new frmMessageBox(Resources.Do_you_want_to_return_the_item + item.ItemName + Resources._back_to_inventory, Resources.Return_Item_To_Inventory, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				item.DisableSoldOutItems = true;
			}
			list_5.Add(item);
		}
	}

	private void btnPay_Click(object sender, EventArgs e)
	{
		try
		{
			CashoutBill();
		}
		catch (Exception ex)
		{
			new NotificationLabel(this, "An error Occurred while processing the order, please try again.", NotificationTypes.Warning).Show();
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			DebugMethods.ShowExceptionTextFile(ex);
		}
	}

	public void CashoutBill(bool isCashoutButton = false)
	{
		if (!method_45())
		{
			return;
		}
		if (btnSaveOrder.Enabled || !isSaved || bool_25)
		{
			if (!method_41(true, 0))
			{
				return;
			}
			Button button = btnSaveClose;
			Button button2 = btnSaveOrder;
			ClearBtn.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
			isSaved = true;
		}
		method_32();
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			if (new frmKioskPay(string_3, decimal_0 + decimal_4).ShowDialog() == DialogResult.OK)
			{
				HideOrderEntry();
			}
			return;
		}
		if (SettingsHelper.GetSettingValueByKey("member_assign") == "ON" && int_13 <= 0 && new frmCustomers(null, string_3, null, save_send: false, show_appointment_members: true, use_skip_button: true).ShowDialog(this) == DialogResult.Cancel)
		{
			if (!string.IsNullOrEmpty(string_3))
			{
				loadOrderByOrderNumber(string_3);
			}
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.PayScreen();
		MemoryLoadedObjects.PayScreen.LoadForm(this, list_5.Where((Item i) => i.Active).ToList(), decimal_0, decimal_4, string_4, string_5, string_3, string_6, string_7, string_8, decimal_1, string_0, decimal_2);
		if (SettingsHelper.GetSettingValueByKey("workflow_prompt_cashout_pin") == "ON")
		{
			if (!MemoryLoadedObjects.PayScreen.EmployeeLogIn("Employee PIN Required"))
			{
				return;
			}
		}
		else if (int_14 == 0 && !MemoryLoadedObjects.PayScreen.EmployeeLogIn(Resources.NOT_LOGGED_IN_Enter_Employee_P))
		{
			return;
		}
		if (MemoryLoadedObjects.PayScreen.ShowDialog(this) == DialogResult.OK)
		{
			dataManager_0 = new DataManager();
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && !isCashoutButton)
			{
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF")
				{
					method_33();
					if (MemoryLoadedObjects.DefaultOrderTypes.Split(',').Count() >= 4 && MemoryLoadedObjects.DefaultOrderTypes.Split(',').Contains(OrderTypes.ToGo))
					{
						ReinitializeOrderEntryByOrderType(OrderTypes.ToGo);
					}
					else
					{
						ReinitializeOrderEntryByOrderType(MemoryLoadedObjects.DefaultOrderTypes.Split(',')[0]);
					}
				}
				else
				{
					HideOrderEntry();
					method_4();
					isSaved = true;
				}
			}
			else
			{
				HideOrderEntry();
				method_4();
				isSaved = true;
			}
			if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
			{
				MemoryLoadedObjects.OrderEntrySecondScreen.ResetValues();
			}
			if (SettingsHelper.GetSettingValueByKey("auto_logout_cashout").ToUpper() == "ON" || SettingsHelper.GetSettingValueByKey("auto_logout_oe").ToUpper() == "ON")
			{
				AuthMethods.LogOutUser();
			}
		}
		else
		{
			dataManager_0 = new DataManager();
			if (dataManager_0.GetOrder(string_3).Count() == 0)
			{
				foreach (ListViewDataItem item in radListItems.Items)
				{
					int itemID = Convert.ToInt32(item[4].ToString());
					Item oneItem = dataManager_0.getOneItem(itemID);
					string value = (string.IsNullOrEmpty(item[2].ToString()) ? "0.00" : item[2].ToString());
					if (oneItem != null && oneItem.ItemPrice != Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture))
					{
						item[8] = Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture).ToString();
					}
				}
				method_41(null, 0);
			}
			if (!string.IsNullOrEmpty(string_3))
			{
				loadOrderByOrderNumber(string_3);
			}
		}
		method_36();
		GC.Collect();
	}

	private void method_33()
	{
		string_5 = (string_11 = MemoryLoadedObjects.DefaultOrderTypes.Split(',')[0]);
		isSaved = true;
		string_10 = (string_4 = Resources.Walk_In);
		string_12 = (string_6 = (string_7 = (string_1 = string.Empty)));
		decimal_3 = (decimal_2 = 0m);
		int_13 = 0;
		method_34();
		method_4();
		method_6();
	}

	private void method_34()
	{
		string_15 = "";
		method_3();
		lblTotalTax.Text = "0.00";
		lblSubTotal.Text = "0.00";
		lblTotal.Text = "0.00";
		list_2 = dataManager_0.GetTax();
		radListItems.Items.Clear();
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.txtDiscount.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtSubTotal.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtTotalTax.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.txtTotal.Text = 0.ToString("0.00", Thread.CurrentThread.CurrentCulture);
			MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Clear();
		}
		decimal_0 = default(decimal);
		decimal_4 = default(decimal);
		RecalculateTaxAndSubtotal();
		string_3 = string.Empty;
		isSaved = true;
		string_9 = "";
		ClearBtn.Enabled = false;
	}

	private bool method_35()
	{
		foreach (ListViewDataItem item in radListItems.Items.Where((ListViewDataItem a) => a[1].ToString() != ConstantItems.Delivery_Fee))
		{
			if (item.Font.Strikeout || string.IsNullOrEmpty(item.SubItems[6].ToString()))
			{
				return true;
			}
		}
		if (string_5 == string_11)
		{
			if (string_10 == string_4)
			{
				string_12 = ((!string.IsNullOrEmpty(string_12)) ? string_12 : "");
				string_7 = ((!string.IsNullOrEmpty(string_7)) ? string_7 : "");
				if (string_12 != string_7)
				{
					return true;
				}
				if (!bool_1 && !bool_2 && !bool_3)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		if (!bool_20 && (method_35() || !isSaved || bool_25) && !bool_21)
		{
			DialogResult dialogResult = new frmMessageBox(Resources.Do_you_want_to_save_the_change0, Resources.Save_Changes, CustomMessageBoxButtons.YesNoCancel).ShowDialog();
			switch (dialogResult)
			{
			case DialogResult.Yes:
				if (method_41(null, 0))
				{
					if (string_5 == OrderTypes.DineIn && string_11 == OrderTypes.DineIn)
					{
						loadOrderByOrderNumber(string_3);
					}
					else
					{
						method_42(string_3);
					}
					HideOrderEntry();
				}
				return;
			case DialogResult.No:
			{
				if (!bool_25)
				{
					break;
				}
				GClass6 gClass = new GClass6();
				string voidBy = "";
				Employee employee = gClass.Employees.Where((Employee a) => a.EmployeeID == Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString())).FirstOrDefault();
				if (employee != null)
				{
					voidBy = employee.FirstName + " " + employee.LastName;
				}
				foreach (Order item in gClass.Orders.Where((Order o) => o.Void == false && o.OrderNumber == string_3).ToList())
				{
					item.DateFilled = null;
					item.Notified = true;
					item.PrintedInKitchen = true;
					item.IsModified = true;
					item.DateVoided = DateTime.Now;
					item.FlagID = 4;
					item.StationNotified = null;
					item.StationPrinted = null;
					item.Void = true;
					item.Paid = false;
					item.VoidBy = voidBy;
					item.PaymentMethods = "SAVED ORDER";
					item.VoidReason = "Cancelled Duplicate Order";
					item.Synced = false;
				}
				Helper.SubmitChangesWithCatch(gClass);
				bool_20 = false;
				base.DialogResult = DialogResult.Cancel;
				HideOrderEntry();
				return;
			}
			}
			if (dialogResult == DialogResult.Cancel)
			{
				return;
			}
		}
		else if (bool_5 && list_3.Count > 0)
		{
			OrderHelper.UpdatePendingSaveOrders(string_4, reprint: true);
			if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF")
			{
				list_3.Add(string_3);
				list_3 = list_3.Distinct().ToList();
				foreach (string item2 in list_3)
				{
					if (SettingsHelper.GetSettingValueByKey("print_chit_cashout") != "ON" || string_5 == OrderTypes.PickUp || string_5 == OrderTypes.PickUpOnline || string_5 == OrderTypes.PickUpCurbsideOnline || string_5 == OrderTypes.DineInOnline || string_5 == OrderTypes.Delivery || string_5 == OrderTypes.DeliveryOnline || string_5 == OrderTypes.Catering)
					{
						orderHelper_0.OrderPrintMadeCheck("SAVED ORDER", item2, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
					}
				}
			}
			else
			{
				orderHelper_0.OrderPrintMadeCheck("SAVED ORDER", string_3, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
			}
			list_3.Clear();
		}
		bool_20 = false;
		bool_5 = false;
		base.DialogResult = DialogResult.Cancel;
		HideOrderEntry();
	}

	private void method_36()
	{
		if (int_14 == 0)
		{
			lblEmployee.Text = Resources.NOT_LOGGED_IN;
			return;
		}
		Employee employeeByID = UserMethods.GetEmployeeByID(int_14);
		if (employeeByID == null)
		{
			return;
		}
		lblEmployee.Text = Resources.EMPLOYEE + employeeByID.FirstName + " " + employeeByID.LastName;
		if (SettingsHelper.CurrentTerminalMode == "Patron" || SettingsHelper.CurrentTerminalMode == "Kiosk" || employeeByID.Users.FirstOrDefault().RoleID == RoleIDs.kiosk || employeeByID.Users.FirstOrDefault().RoleID == RoleIDs.patron)
		{
			lblEmployee.Visible = false;
			if (SettingsHelper.CurrentTerminalMode == "Patron" || employeeByID.Users.FirstOrDefault().RoleID == RoleIDs.patron)
			{
				btnSaveClose.Text = Resources.SEND_TO_KITCHEN0;
			}
			if (SettingsHelper.CurrentTerminalMode == "Kiosk" || employeeByID.Users.FirstOrDefault().RoleID == RoleIDs.kiosk)
			{
				btnClear.Text = Resources.START_OVER;
				btnClear.Enabled = true;
				btnClose.Visible = false;
				btnSaveClose.Visible = false;
			}
		}
	}

	private void method_37(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		if (e.IsSelected)
		{
			ListViewItem listViewItem = ((ListView)sender).SelectedItems[0];
			if (listViewItem.BackColor == Color.LightGray && listViewItem.ForeColor == Color.Gray)
			{
				e.Item.Selected = false;
			}
		}
	}

	private void btnChangePrice_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count != 0)
		{
			if ((sender as Control).Name == btnChangePrice.Name)
			{
				method_38("override");
			}
			else
			{
				method_38("discount");
			}
		}
		else
		{
			new frmMessageBox(Resources.Please_select_the_item_to_chan).ShowDialog(this);
		}
	}

	private void method_38(string string_16)
	{
		string controlName = "btnChangePrice";
		if (string_16 == "discount")
		{
			controlName = "btnOrderDiscount";
		}
		if (AuthMethods.EmployeeAuthenticateControl(this, controlName) != null)
		{
			method_39(string_16);
		}
	}

	private void method_39(string string_16)
	{
		int itemID = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
		Item oneItem = dataManager_0.getOneItem(itemID);
		if (string_16 == "override")
		{
			_ = oneItem.ItemPrice;
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData((string_16 == "override") ? "Change Price" : "Item Discount", 2, 10, "", "", (string_16 == "override") ? true : false);
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK && string_16 == "override")
			{
				radListItems.SelectedItems[0][2] = $"{MemoryLoadedObjects.Numpad.numberEntered:0.00}";
				string text = (string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString());
				string value = (string.IsNullOrEmpty(radListItems.SelectedItems[0][2].ToString()) ? "0.00" : radListItems.SelectedItems[0][2].ToString());
				radListItems.SelectedItems[0][3] = (MathHelper.FractionToDecimal(text.Replace(",", ".")) * Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture)).ToString("0.00", Thread.CurrentThread.CurrentCulture);
				radListItems.SelectedItems[0].SubItems[8] = $"{MemoryLoadedObjects.Numpad.numberEntered:0.00}";
				radListItems.SelectedItems[0].SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(radListItems.SelectedItems[0].SubItems[15].ToString(), DiscountTypes.Item, 0m);
				radListItems.SelectedItems[0].SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(radListItems.SelectedItems[0].SubItems[15].ToString(), DiscountTypes.Promo, 0m);
				radListItems.SelectedItems[0].SubItems[18] = "-1";
				radListItems.SelectedItems[0].SubItems[20] = MemoryLoadedObjects.Numpad.numberEntered.ToString();
				RecalculateTaxAndSubtotal();
				isSaved = false;
			}
			return;
		}
		if (string_16 == "discount" && btnItemDiscount.Text == Resources.ITEM_DISCOUNT)
		{
			if (!(radListItems.SelectedItems[0][2].ToString() == "") && !(Convert.ToDecimal(radListItems.SelectedItems[0][2].ToString()) == 0m))
			{
				decimal num = MathHelper.FractionToDecimal(string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString());
				decimal num2 = Convert.ToDecimal(radListItems.SelectedItems[0][2].ToString());
				string text2 = radListItems.SelectedItems[0][1].ToString();
				if (text2.Contains("OPT:") || (text2.Contains("[") && text2.Contains("]")))
				{
					_003C_003Ec__DisplayClass175_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass175_0();
					if (radListItems.SelectedItems[0][3].ToString() == "")
					{
						new NotificationLabel(this, "Cannot apply item discount to a free option.", NotificationTypes.Notification).Show();
						return;
					}
					CS_0024_003C_003E8__locals0.optionComboId = radListItems.SelectedItems[0].SubItems[11].ToString();
					CS_0024_003C_003E8__locals0.comboId = radListItems.SelectedItems[0].SubItems[5].ToString();
					CS_0024_003C_003E8__locals0.optionTab = ((!radListItems.SelectedItems[0].SubItems[1].ToString().Contains("[") || !radListItems.SelectedItems[0].SubItems[1].ToString().Contains("]")) ? "OPTIONS" : Regex.Match(radListItems.SelectedItems[0].SubItems[1].ToString().ToUpper().Replace("OPT: ", "")
						.Replace("ADD: ", "")
						.Replace("   ", ""), "\\[([^]]*)\\]").Groups[1].Value);
					CS_0024_003C_003E8__locals0.optionItemId = oneItem.ItemID;
					ListViewDataItem listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[11].ToString() == CS_0024_003C_003E8__locals0.optionComboId && !a.Font.Strikeout && a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.comboId && !a[1].ToString().Contains("ADD:") && !a[1].ToString().Contains("OPT:")).FirstOrDefault();
					CS_0024_003C_003E8__locals0.mainItemId = Convert.ToInt32(listViewDataItem.SubItems[4].ToString());
					new GClass6();
					usp_ItemOptionsResult usp_ItemOptionsResult = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult x) => !x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == CS_0024_003C_003E8__locals0.optionItemId && x.ItemID == CS_0024_003C_003E8__locals0.mainItemId && x.Tab.ToUpper() == CS_0024_003C_003E8__locals0.optionTab.ToUpper()).FirstOrDefault();
					if (usp_ItemOptionsResult != null)
					{
						num2 = usp_ItemOptionsResult.SpecialPrice;
					}
				}
				frmDiscount frmDiscount2 = new frmDiscount(num2 * num, DiscountTypes.Item);
				if (frmDiscount2.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				decimal tenderDiscount = frmDiscount2.tenderDiscount;
				string discountDesc = radListItems.SelectedItems[0].SubItems[15].ToString();
				if (tenderDiscount > num2 * num)
				{
					new NotificationLabel(this, "Item discount cannot be more than the original price", NotificationTypes.Warning).Show();
					return;
				}
				if (decimal_2 * num2 * num + tenderDiscount > num2 * num)
				{
					new NotificationLabel(this, "Cannot apply item discount, discount total for this item is greater than the item price.", NotificationTypes.Notification).Show();
					return;
				}
				radListItems.SelectedItems[0].SubItems[13] = frmDiscount2.discountReason;
				radListItems.SelectedItems[0].SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item, tenderDiscount);
				if (frmDiscount2.discountType == DiscountTypes.Percentage && radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
				{
					foreach (ListViewDataItem item in radListItems.Items.Where((ListViewDataItem listViewDataItem_0) => listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString()))
					{
						if (item[2].ToString() != "" && Convert.ToDecimal(item[2].ToString()) > 0m && item != radListItems.SelectedItems[0])
						{
							decimal value2 = Convert.ToDecimal(item[3].ToString()) * frmDiscount2.percentDiscount;
							item.SubItems[13] = frmDiscount2.discountReason;
							item.SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(item.SubItems[15].ToString(), DiscountTypes.Item, value2);
						}
					}
				}
				isSaved = false;
				Button button = btnSaveOrder;
				btnSaveClose.Enabled = true;
				button.Enabled = true;
				RecalculateTaxAndSubtotal();
				method_52();
			}
			else
			{
				new NotificationLabel(this, "Cannot apply item discount to an item with 0 price.", NotificationTypes.Notification).Show();
			}
			return;
		}
		string discountDesc2 = radListItems.SelectedItems[0].SubItems[15].ToString();
		decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(discountDesc2, DiscountTypes.Item);
		lblDiscount.Text = (Convert.ToDecimal(lblDiscount.Text) - discountFromDiscountDescription).ToString("0.00");
		radListItems.SelectedItems[0].SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc2, DiscountTypes.Item, 0m);
		if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
		{
			foreach (ListViewDataItem item2 in radListItems.Items.Where((ListViewDataItem listViewDataItem_0) => listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString()))
			{
				if (item2[2].ToString() != "" && Convert.ToDecimal(item2[2].ToString()) > 0m && item2 != radListItems.SelectedItems[0])
				{
					discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(discountDesc2, DiscountTypes.Item);
					lblDiscount.Text = (Convert.ToDecimal(lblDiscount.Text) - discountFromDiscountDescription).ToString("0.00");
					item2.SubItems[15] = OrderHelper.UpdateDiscountFromDiscountDescription(item2.SubItems[15].ToString(), DiscountTypes.Item, 0m);
				}
			}
		}
		isSaved = false;
		Button button2 = btnSaveOrder;
		btnSaveClose.Enabled = true;
		button2.Enabled = true;
		RecalculateTaxAndSubtotal();
		method_52();
		new NotificationLabel(this, "Item Discount Removed.", NotificationTypes.Success).Show();
	}

	private void btnSaveOrder_Click(object sender, EventArgs e)
	{
		try
		{
			bool_20 = true;
			Button button = btnClose;
			Button button2 = btnSaveOrder;
			Button button3 = btnSaveClose;
			Button button4 = btnPay;
			Button gglFeOneCle = GglFeOneCle;
			btnSplitMergeBill.Enabled = false;
			gglFeOneCle.Enabled = false;
			button4.Enabled = false;
			button3.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
			if (radListItems.Items.Count <= 0)
			{
				return;
			}
			if (SettingsHelper.CurrentTerminalMode == "Patron" || SettingsHelper.CurrentTerminalMode == "Kiosk")
			{
				if (new frmMessageBox(Resources.Are_you_sure_you_want_to_send_, Resources.Send_To_Kitchen, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
				{
					Button button5 = btnSaveOrder;
					Button button6 = btnSaveClose;
					Button button7 = btnPay;
					GglFeOneCle.Enabled = true;
					button7.Enabled = true;
					button6.Enabled = true;
					button5.Enabled = true;
					return;
				}
				if (!string.IsNullOrEmpty(string_3) && new GClass6().Orders.Where((Order x) => x.OrderNumber == string_3 && x.Paid == false && x.Void == false) != null)
				{
					string_3 = OrderMethods.GetNewOrderNumber();
				}
			}
			new NotificationLabel(this, "Order saving...", NotificationTypes.Success);
			new Thread((ThreadStart)delegate
			{
				if (method_41(null, 0))
				{
					bool_28 = true;
				}
			}).Start();
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			new frmMessageBox("An error has occured. Trying to save this order.").ShowDialog(this);
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (bool_28)
			{
				bool_28 = false;
				loadOrderByOrderNumber(string_3);
				method_42(string_3);
				if (SettingsHelper.GetSettingValueByKey("print_chit_cashout") != "ON" && (bool_14 || bool_15))
				{
					if (bool_14)
					{
						new NotificationLabel(this, "Kitchen has been notified.", NotificationTypes.Success).Show();
					}
					if (bool_15)
					{
						new NotificationLabel(this, "Bar has been notified.", NotificationTypes.Success).Show();
					}
				}
				else
				{
					new NotificationLabel(this, "Order saved.", NotificationTypes.Success).Show();
				}
				string_11 = string_5;
				string_10 = string_4;
				string_12 = string_7;
				bool_14 = false;
				bool_15 = false;
				Button button = btnSaveOrder;
				btnSaveClose.Enabled = false;
				button.Enabled = false;
				isSaved = true;
				Button button2 = btnClose;
				Button button3 = btnPay;
				Button gglFeOneCle = GglFeOneCle;
				btnSplitMergeBill.Enabled = true;
				gglFeOneCle.Enabled = true;
				button3.Enabled = true;
				button2.Enabled = true;
				bool_20 = false;
				if (radListItems.Items.Where((ListViewDataItem a) => !a.Font.Strikeout).Count() == 1 && radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").Any())
				{
					btnPay.Enabled = false;
				}
			}
			else if (bool_29)
			{
				bool_29 = false;
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && string_5 != OrderTypes.DineIn && string_5 != OrderTypes.ToGo && string_5 != OrderTypes.MakeToStock)
				{
					new NotificationLabel(this, "Order saved.", NotificationTypes.Success).Show();
					if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
					{
						HideOrderEntry();
					}
					else
					{
						method_33();
						ReinitializeOrderEntryByOrderType(MemoryLoadedObjects.DefaultOrderTypes.Split(',')[0]);
					}
					if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
					{
						MemoryLoadedObjects.OrderEntrySecondScreen.ResetValues();
					}
					GC.Collect();
				}
				else if (SettingsHelper.CurrentTerminalMode != "Patron" && SettingsHelper.CurrentTerminalMode != "Kiosk")
				{
					HideOrderEntry();
					method_42(string_3);
				}
				else
				{
					new NotificationLabel(this, "Order saved.", NotificationTypes.Success).Show();
					loadOrderByOrderNumber(string_3);
					method_42(string_3);
				}
				Button button4 = btnClose;
				Button button5 = btnPay;
				Button gglFeOneCle2 = GglFeOneCle;
				btnSplitMergeBill.Enabled = true;
				gglFeOneCle2.Enabled = true;
				button5.Enabled = true;
				button4.Enabled = true;
				bool_20 = false;
				if (radListItems.Items.Where((ListViewDataItem a) => !a.Font.Strikeout).Count() == 1 && radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").Any())
				{
					btnPay.Enabled = false;
				}
			}
			else if (radListItems.Items.Count == 0)
			{
				btnClose.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			bool_29 = false;
			bool_28 = false;
			bool_20 = false;
		}
	}

	private void btnSplitMergeBill_Click(object sender, EventArgs e)
	{
		string fraction = (string.IsNullOrEmpty(radListItems.Items[0][0].ToString()) ? "1" : radListItems.Items[0][0].ToString());
		if (radListItems.Items.Count <= 1 && (radListItems.Items.Count != 1 || !(MathHelper.FractionToDecimal(fraction) > 0m)))
		{
			new NotificationLabel(this, Resources.Not_enough_items_to_split_bill, NotificationTypes.Notification).Show();
			return;
		}
		int num = GuestMethods.GetCurrentTableGuestCapacity(string_4.Replace("Table ", ""));
		if (num <= 1 && string_5 == OrderTypes.DineIn && bool_13 && SettingsHelper.GetSettingValueByKey("restaurant_mode") != "Quick Service" && short_5 <= 1)
		{
			new frmMessageBox(Resources.Please_change_the_guest_count_, Resources.Invalid_Guest_Count).Show();
			return;
		}
		if (!bool_13 || SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			num = 2;
		}
		bool flag = true;
		if (btnSaveOrder.Enabled || !isSaved || bool_25)
		{
			flag = method_41(null, 0);
		}
		if (!flag)
		{
			return;
		}
		OrderMethods.RecheckGuestCountSplittedBill(string_4);
		loadOrderByOrderNumber(string_3);
		method_42(string_3);
		num = ((num >= 2) ? num : 2);
		frmSplitBill frmSplitBill2 = new frmSplitBill(string_4, string_5, string_3, num, decimal_2);
		if (frmSplitBill2.ShowDialog(this) == DialogResult.OK)
		{
			OrdersUpdated = frmSplitBill2.OrdersUpdated;
			if (!string.IsNullOrEmpty(frmSplitBill2.LastValidOrderNumber))
			{
				string_3 = frmSplitBill2.LastValidOrderNumber;
			}
			if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
			{
				MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Clear();
			}
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
			{
				ReinitializeOrderEntryByOrderType();
				loadOrderByOrderNumber(string_3);
			}
			else
			{
				HideOrderEntry(forceNotLogout: true);
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.MultiBills();
				MemoryLoadedObjects.MultiBills.LoadFormData(MemoryLoadedObjects.Layout, lblCustomer.Text, OrderTypes.DineIn);
				MemoryLoadedObjects.MultiBills.Show();
			}
		}
		else
		{
			frmSplitBill2.Dispose();
		}
		GC.Collect();
	}

	public void loadOrderByOrderNumber(string searchText)
	{
		_003C_003Ec__DisplayClass182_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass182_0();
		CS_0024_003C_003E8__locals0.searchText = searchText;
		try
		{
			list_9 = new List<PossibleCombo>();
			List<Order> list = (from o in new GClass6().Orders
				where o.OrderNumber == CS_0024_003C_003E8__locals0.searchText && o.Paid == false && o.Void == false
				select o into x
				orderby x.LastDateModified.HasValue ? x.LastDateModified : x.DateCreated
				select x).ThenBy((Order a) => a.ComboID).ToList();
			if (list.Count() == 0)
			{
				new NotificationLabel(this, Resources.Order_not_found_or_has_already, NotificationTypes.Notification).Show();
				string_3 = string.Empty;
				HideOrderEntry(forceNotLogout: true);
			}
			else
			{
				string_3 = CS_0024_003C_003E8__locals0.searchText;
				method_40(list);
				radListItems.ListViewElement.ViewElement.VScrollBar.Maximum = radListItems.Items.Count * radListItems.ItemSize.Height;
				verticalScrollControl1.EnableDisableButtonsByScrollListView();
				int_15 = 0;
			}
		}
		catch (Exception ex)
		{
			if (int_15 < 3)
			{
				if (!ex.Message.ToUpper().Contains("DEADLOCKED"))
				{
					new NotificationLabel(this, "Something went wrong loading the order. Please reopen/reload the order.", NotificationTypes.Warning);
					LogHelper.WriteLog(ex.Message, LogTypes.error_log);
					DebugMethods.ShowExceptionTextFile(ex);
					btnClose.Enabled = true;
					bool_21 = true;
					throw;
				}
				Thread.Sleep(1000);
				int_15++;
				loadOrderByOrderNumber(CS_0024_003C_003E8__locals0.searchText);
				return;
			}
			new NotificationLabel(this, "Something went wrong loading the order. Please reopen/reload the order.", NotificationTypes.Warning);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			DebugMethods.ShowExceptionTextFile(ex);
			btnClose.Enabled = true;
			bool_21 = true;
			throw;
		}
	}

	private void method_40(List<Order> list_12)
	{
		_003C_003Ec__DisplayClass183_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass183_0();
		method_34();
		decimal num = default(decimal);
		decimal num2 = default(decimal);
		radListItems.BeginUpdate();
		Order order = list_12.OrderBy((Order a) => a.DateCreated.Value).FirstOrDefault();
		if (order != null)
		{
			OrderDateCreated = order.DateCreated.Value;
			string_8 = order.CustomerInfoPhone;
			string_1 = order.OrderDiscountType;
			dateFullfilment = order.FulfillmentAt;
			if (dateFullfilment.HasValue && string_5 != OrderTypes.DineIn)
			{
				orderOnHoldTime = (int)(dateFullfilment.Value - order.DateCreated.Value).TotalMinutes;
			}
			lblOrderNumber.Text = "ORD#: " + order.OrderNumber;
			if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")
			{
				lblOrderNumber.Text = ("TCKT#: " + order.OrderTicketNumber) ?? "";
			}
		}
		CS_0024_003C_003E8__locals0.orderListIDs = list_12.Select((Order x) => x.OrderId).ToList();
		List<Guid> list = (from a in new GClass6().Orders
			where a.ShareItemID.HasValue && CS_0024_003C_003E8__locals0.orderListIDs.Contains(a.ShareItemID.Value) && a.Void == false
			select a into x
			select x.ShareItemID.Value).ToList();
		using (List<Order>.Enumerator enumerator = list_12.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass183_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass183_1();
				CS_0024_003C_003E8__locals1.order = enumerator.Current;
				bool_0 = CS_0024_003C_003E8__locals1.order.IsDiscount;
				string_3 = CS_0024_003C_003E8__locals1.order.OrderNumber;
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.OrderNotes))
				{
					string_9 = CS_0024_003C_003E8__locals1.order.OrderNotes;
				}
				string text = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Options) ? CS_0024_003C_003E8__locals1.order.ItemName : (CS_0024_003C_003E8__locals1.order.ItemName + " => " + CS_0024_003C_003E8__locals1.order.Options));
				decimal num3 = default(decimal);
				decimal num4 = default(decimal);
				Item item = MemoryLoadedData.all_items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals1.order.ItemID).FirstOrDefault();
				if (item == null)
				{
					if (CS_0024_003C_003E8__locals1.order.ItemID >= 0)
					{
						continue;
					}
					item = new DataManager().getOneItem(CS_0024_003C_003E8__locals1.order.ItemID);
				}
				if (item == null)
				{
					continue;
				}
				Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(item.ItemID);
				bool flag = ((promoSaleItemById != null && item.OnSale) ? true : false);
				num3 = CS_0024_003C_003E8__locals1.order.ItemSellPrice;
				num4 = CS_0024_003C_003E8__locals1.order.ItemSellPrice * CS_0024_003C_003E8__locals1.order.Qty;
				if ((OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.order.DiscountDesc, DiscountTypes.Order) > 0m || OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.order.DiscountDesc, DiscountTypes.Item) > 0m) ? true : false)
				{
					decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.order.DiscountDesc, DiscountTypes.Promo);
					num3 = CS_0024_003C_003E8__locals1.order.ItemSellPrice + ((CS_0024_003C_003E8__locals1.order.Qty > 0m) ? ((CS_0024_003C_003E8__locals1.order.Discount - discountFromDiscountDescription) / CS_0024_003C_003E8__locals1.order.Qty) : 0m);
					num4 = CS_0024_003C_003E8__locals1.order.ItemSellPrice * CS_0024_003C_003E8__locals1.order.Qty + (CS_0024_003C_003E8__locals1.order.Discount - discountFromDiscountDescription);
				}
				if (SettingsHelper.GetSettingValueByKey("show_instruction_oe") == "ON")
				{
					text = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Instructions)) ? (text + " => INSTR: " + CS_0024_003C_003E8__locals1.order.Instructions) : text);
				}
				bool flag2 = false;
				if (CS_0024_003C_003E8__locals1.order.ShareItemID.HasValue || list.Contains(CS_0024_003C_003E8__locals1.order.OrderId))
				{
					flag2 = true;
				}
				if (CS_0024_003C_003E8__locals1.order.FlagID == 5)
				{
					bool_25 = true;
				}
				int num5 = 0;
				PromotionCheck promotion = PromotionMethods.GetPromotion(radListItems, item, string_5, OrderDateCreated);
				if (promotion.IsPromotion && !flag2)
				{
					num5 = promotion.PromotionId;
				}
				string text2 = "-1";
				if (!CS_0024_003C_003E8__locals1.order.OverridePrice.HasValue)
				{
					text2 = "-1";
					if (flag2)
					{
						num5 = -1;
					}
				}
				else
				{
					num5 = -1;
					text2 = ((!item.ItemName.ToUpper().Contains(Resources._CUSTOM)) ? (CS_0024_003C_003E8__locals1.order.ItemSellPrice + ((CS_0024_003C_003E8__locals1.order.Qty > 0m) ? (CS_0024_003C_003E8__locals1.order.Discount / CS_0024_003C_003E8__locals1.order.Qty) : 0m)).ToString("0.00") : CS_0024_003C_003E8__locals1.order.ItemPrice.ToString("0.00"));
				}
				string[] values = new string[24]
				{
					(!(CS_0024_003C_003E8__locals1.order.Qty < 1m)) ? MathHelper.RemoveTrailingZeros(CS_0024_003C_003E8__locals1.order.Qty.ToString()) : ((!item.UOM.isFractional) ? MathHelper.DecimalToFraction(CS_0024_003C_003E8__locals1.order.Qty) : MathHelper.RemoveTrailingZeros(CS_0024_003C_003E8__locals1.order.Qty.ToString())),
					text,
					num3.ToString("0.00##", Thread.CurrentThread.CurrentCulture),
					num4.ToString("0.00", Thread.CurrentThread.CurrentCulture),
					CS_0024_003C_003E8__locals1.order.ItemID.ToString(),
					CS_0024_003C_003E8__locals1.order.ComboID.ToString(),
					CS_0024_003C_003E8__locals1.order.OrderId.ToString(),
					string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Instructions) ? string.Empty : CS_0024_003C_003E8__locals1.order.Instructions,
					text2,
					(CS_0024_003C_003E8__locals1.order.InventoryBatchId.ToString() == "") ? "0" : CS_0024_003C_003E8__locals1.order.InventoryBatchId.ToString(),
					0.ToString(),
					CS_0024_003C_003E8__locals1.order.OptionComboId.ToString(),
					false.ToString(),
					string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.DiscountReason) ? "" : CS_0024_003C_003E8__locals1.order.DiscountReason,
					CS_0024_003C_003E8__locals1.order.OrderOnHoldTime.ToString(),
					string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.DiscountDesc) ? "" : CS_0024_003C_003E8__locals1.order.DiscountDesc,
					CS_0024_003C_003E8__locals1.order.ItemIdentifier,
					CS_0024_003C_003E8__locals1.order.ItemOptionId.HasValue ? CS_0024_003C_003E8__locals1.order.ItemOptionId.Value.ToString() : "0",
					num5.ToString(),
					CS_0024_003C_003E8__locals1.order.DateCreated.ToString(),
					CS_0024_003C_003E8__locals1.order.OverridePrice.HasValue ? CS_0024_003C_003E8__locals1.order.OverridePrice.Value.ToString() : "",
					flag2.ToString(),
					CS_0024_003C_003E8__locals1.order.FlagID.ToString(),
					CS_0024_003C_003E8__locals1.order.DateFilled.HasValue.ToString()
				};
				ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
				listViewDataItem.Group = method_26(CS_0024_003C_003E8__locals1.order.ItemCourse);
				listViewDataItem.Font = radListItems.Font;
				FormHelper.ChangeOrderEntryLVCellByIdentifier(radListItems, listViewDataItem, radListItems.Font.Size, CS_0024_003C_003E8__locals1.order.ItemIdentifier);
				if (CS_0024_003C_003E8__locals1.order.Void)
				{
					listViewDataItem.Font = new Font(radListItems.Items[radListItems.Items.Count - 1].Font, radListItems.Items[radListItems.Items.Count - 1].Font.Style | FontStyle.Strikeout);
				}
				radListItems.Items.Add(listViewDataItem);
				radListItems.AllowArbitraryItemHeight = true;
				if (SettingsHelper.CurrentTerminalMode == "Patron")
				{
					radListItems.Items[radListItems.Items.Count - 1].BackColor = Color.LightGray;
					radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.Gray;
				}
				if (CS_0024_003C_003E8__locals1.order.OrderOnHoldTime > 0 && CS_0024_003C_003E8__locals1.order.DateCreated.Value > DateTime.Now.AddMinutes(-CS_0024_003C_003E8__locals1.order.OrderOnHoldTime))
				{
					radListItems.Items[radListItems.Items.Count - 1].BackColor = Color.FromArgb(50, 119, 155);
					radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.LightGray;
				}
				else
				{
					radListItems.Items[radListItems.Items.Count - 1].BackColor = Color.White;
					if (CS_0024_003C_003E8__locals1.order.ItemIdentifier == "OptionItem")
					{
						radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.DarkRed;
					}
					else
					{
						radListItems.Items[radListItems.Items.Count - 1].ForeColor = Color.Black;
					}
				}
				if (string.IsNullOrEmpty(string_6))
				{
					string_6 = CS_0024_003C_003E8__locals1.order.CustomerInfo;
				}
				if (bool_0 || !string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.DiscountDesc))
				{
					decimal discountFromDiscountDescription2 = OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.order.DiscountDesc, DiscountTypes.Order);
					if (CS_0024_003C_003E8__locals1.order.ComboID != 0 && (CS_0024_003C_003E8__locals1.order.ComboID == 0 || !(CS_0024_003C_003E8__locals1.order.ItemSellPrice != 0m)) && (CS_0024_003C_003E8__locals1.order.ComboID == 0 || dataManager_0.DataContext.ItemsInItems.Where((ItemsInItem x) => x.ParentItemID == (int?)CS_0024_003C_003E8__locals1.order.ItemID).Count() <= 0) && (CS_0024_003C_003E8__locals1.order.ComboID <= 0 || dataManager_0.DataContext.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemID == (int?)CS_0024_003C_003E8__locals1.order.ItemID && x.ToBeDeleted == false).Count() <= 0))
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.Options))
						{
							num += CS_0024_003C_003E8__locals1.order.ItemPrice * CS_0024_003C_003E8__locals1.order.Qty;
							num2 += discountFromDiscountDescription2;
						}
					}
					else if (flag && (promoSaleItemById.GetDiscountAmount.Value == CS_0024_003C_003E8__locals1.order.ItemSellPrice || CS_0024_003C_003E8__locals1.order.Discount / CS_0024_003C_003E8__locals1.order.Qty + CS_0024_003C_003E8__locals1.order.ItemSellPrice == item.ItemPrice))
					{
						num += num4;
						num2 += discountFromDiscountDescription2;
					}
					else
					{
						num += num4;
						num2 += discountFromDiscountDescription2;
					}
				}
				string_0 = CS_0024_003C_003E8__locals1.order.DiscountReason;
				int_13 = (CS_0024_003C_003E8__locals1.order.CustomerID.HasValue ? CS_0024_003C_003E8__locals1.order.CustomerID.Value : 0);
			}
		}
		radListItems.EndUpdate();
		if (bool_0 && OrderHelper.GetDiscountFromDiscountDescription(order.DiscountDesc, DiscountTypes.Order) > 0m)
		{
			btnOrdDiscount.Text = Resources.REMOVE_ORDER_DISCOUNT;
			if (num > 0m)
			{
				decimal_2 = ((num == 0m) ? 0m : Math.Round(num2 / num, 10));
			}
			if (string_1 == DiscountTypes.DollarAmount)
			{
				decimal_3 = num2;
			}
		}
		else
		{
			btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
			decimal_2 = (decimal_3 = 0m);
		}
		short num6 = list_12.Max((Order o) => o.ComboID);
		num6 = (short)(num6 + 1);
		short_4 = num6;
		lblOrderType.Text = (string_11 = (string_5 = order.OrderType));
		if (string_5 == OrderTypes.DineIn)
		{
			lblSeat.Text = Resources.SEAT + order.SeatNum;
		}
		int result = 1;
		if (int.TryParse(order.SeatNum, out result))
		{
			int_1 = result;
		}
		btnClear.Text = Resources.VOID_ORDER;
		btnClear.Image = picTrash.Image;
		RecalculateTaxAndSubtotal();
		method_52();
		method_57();
		method_58();
		if (order != null && order.FlagID == 6)
		{
			bool_10 = true;
		}
	}

	private void btnSaveClose_Click(object sender, EventArgs e)
	{
		try
		{
			bool_20 = true;
			Button button = btnClose;
			Button button2 = btnSaveOrder;
			Button button3 = btnSaveClose;
			Button button4 = btnPay;
			Button gglFeOneCle = GglFeOneCle;
			btnSplitMergeBill.Enabled = false;
			gglFeOneCle.Enabled = false;
			button4.Enabled = false;
			button3.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
			if (radListItems.Items.Count == 0)
			{
				if (string_10 != string_4)
				{
					method_43();
					HideOrderEntry();
				}
				else
				{
					new NotificationLabel(this, Resources.There_is_nothing_to_save, NotificationTypes.Notification);
				}
				return;
			}
			if (SettingsHelper.CurrentTerminalMode == "Patron" || SettingsHelper.CurrentTerminalMode == "Kiosk")
			{
				if (new frmMessageBox(Resources.Are_you_sure_you_want_to_send_, Resources.Send_To_Kitchen, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
				{
					Button button5 = btnSaveOrder;
					Button button6 = btnSaveClose;
					Button button7 = btnPay;
					GglFeOneCle.Enabled = true;
					button7.Enabled = true;
					button6.Enabled = true;
					button5.Enabled = true;
					bool_20 = false;
					return;
				}
				if (!string.IsNullOrEmpty(string_3) && new GClass6().Orders.Where((Order x) => x.OrderNumber == string_3 && x.Paid == false && x.Void == false) != null)
				{
					string_3 = OrderMethods.GetNewOrderNumber();
				}
			}
			new NotificationLabel(this, "Order saving...", NotificationTypes.Success);
			new Thread((ThreadStart)delegate
			{
				if (method_41(null, 0))
				{
					bool_29 = true;
				}
			}).Start();
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			DebugMethods.ShowExceptionTextFile(ex);
			new frmMessageBox("An error has occured. Trying to save this order.").ShowDialog(this);
			if (!string.IsNullOrEmpty(string_3))
			{
				loadOrderByOrderNumber(string_3);
			}
		}
	}

	private bool method_41(bool? nullable_0 = null, byte byte_0 = 0, bool bool_30 = true)
	{
		try
		{
			if (OrderMethods.CheckOrderIsPaid(string_3, string_5))
			{
				Invoke((MethodInvoker)delegate
				{
					new frmMessageBox("Order is already paid.").ShowDialog(this);
				});
				return false;
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = method_45();
			}
			List<Order> list = null;
			if (nullable_0.Value)
			{
				string text = "SAVED ORDER";
				if (SettingsHelper.CurrentTerminalMode == "Kiosk")
				{
					text = "KIOSK SAVED ORDER";
				}
				short seatNum = 1;
				if (string_5 != OrderTypes.DineIn && string_5 != OrderTypes.DineInOnline)
				{
					short_5 = 1;
				}
				else if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
				{
					string[] array = lblSeat.Text.Split(' ');
					if (array.Length > 1)
					{
						seatNum = (short)((!lblCustomer.Text.Contains(Resources.Table)) ? 1 : Convert.ToInt16(array[1]));
					}
				}
				else
				{
					short_5 = 1;
				}
				if (bool_24)
				{
					list = (from o in new GClass6().Orders
						where o.Customer == string_4 && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && o.OrderNumber.ToUpper() != string_3.ToUpper() && o.Void == false && o.Paid == false
						select o into x
						orderby x.SeatNum
						select x).ToList();
					if (list.Count > 0)
					{
						short_5 = Convert.ToInt16(Convert.ToInt32(list.Last().SeatNum) + 1);
					}
				}
				OrderMethods.LogOrderAudit(string_3, "Order Saved");
				string_4 = string_4.Trim();
				new OrderMethods().SaveOrder(list_5, string_3.ToUpper(), string_4, string_5, int_13, text, 0m, 0m, isPaid: false, string_6, string_0, string_7, string_8, short_5, bool_0, string.Empty, seatNum, null, null, 0, dateFullfilment, string_1, GratuityRemoved: false, byte_0, string_9);
				if (!(SettingsHelper.GetSettingValueByKey("print_chit_cashout") != "ON") && !(string_5 == OrderTypes.PickUp) && !(string_5 == OrderTypes.PickUpOnline) && !(string_5 == OrderTypes.PickUpCurbsideOnline) && !(string_5 == OrderTypes.DineInOnline) && !(string_5 == OrderTypes.Delivery) && !(string_5 == OrderTypes.DeliveryOnline) && !(string_5 == OrderTypes.Catering))
				{
					orderHelper_0.OrderMadeCheck(text, string_3, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
				}
				else if (list_3.Count == 0 && byte_0 == 0 && bool_30)
				{
					orderHelper_0.OrderPrintMadeCheck(text, string_3, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
				}
				Employee userByID = UserMethods.GetUserByID((short)int_14);
				if (userByID != null && userByID.Users.FirstOrDefault().Role.RoleName == "Staff")
				{
					GuestMethods.AssignEmployeeTable(string_4.Replace("Table", string.Empty).Trim(), int_14);
					GuestMethods.AssignEmployeeServedOrder(string_3, (short)int_14);
				}
				if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
				{
					DateTime? dateTimeSeatedTable = GuestMethods.GetDateTimeSeatedTable(string_4.Replace("Table", string.Empty).Trim());
					if (dateTimeSeatedTable.HasValue)
					{
						GuestMethods.UpdateDateTimeSeatedOrder(string_3, dateTimeSeatedTable.Value);
					}
				}
				if (list_3.Count > 0 && byte_0 == 0 && bool_30)
				{
					OrderHelper.UpdatePendingSaveOrders(string_4, reprint: true);
					if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "OFF")
					{
						list_3.Add(string_3);
						list_3 = list_3.Distinct().ToList();
						foreach (string item in list_3)
						{
							if (SettingsHelper.GetSettingValueByKey("print_chit_cashout") != "ON" || string_5 == OrderTypes.PickUp || string_5 == OrderTypes.PickUpOnline || string_5 == OrderTypes.PickUpCurbsideOnline || string_5 == OrderTypes.DineInOnline || string_5 == OrderTypes.Delivery || string_5 == OrderTypes.DeliveryOnline || string_5 == OrderTypes.Catering)
							{
								orderHelper_0.OrderPrintMadeCheck(text, item, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
							}
						}
					}
					else
					{
						orderHelper_0.OrderPrintMadeCheck(text, string_3, string_5, string_7, string_4, lblEmployee.Text.Replace("EMPLOYEE: ", ""), list_5.Count());
					}
					short_5 += (short)list_3.Count;
					GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), short_5, int_14);
					list_3.Clear();
				}
				if (string_5 == OrderTypes.DineIn)
				{
					method_42(string_3, list);
				}
				isSaved = true;
				return nullable_0.Value;
			}
			return nullable_0.Value;
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			Invoke((MethodInvoker)delegate
			{
				new frmMessageBox(Resources.An_error_occurred_trying_to_sa).ShowDialog(this);
			});
			return false;
		}
	}

	private void method_42(string string_16, List<Order> list_12 = null)
	{
		_003C_003Ec__DisplayClass186_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass186_0();
		CS_0024_003C_003E8__locals0.orderNumber = string_16;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		OrderMethods orderMethods = new OrderMethods();
		if (CS_0024_003C_003E8__locals0.orderNumber != "")
		{
			if (string_10 != string_4)
			{
				List<OrderResult> list = ((int_12 == 1) ? list_6 : list_6.Where((OrderResult a) => a.OrderNumber == CS_0024_003C_003E8__locals0.orderNumber).ToList());
				if ((from o in new GClass6().Orders
					where o.Customer == string_4 && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && o.Void == false && o.Paid == false
					select o into x
					orderby x.SeatNum
					select x).ToList().Count > 0)
				{
					if (list.Count > 0)
					{
						int num = 1;
						if (list_12 != null && list_12.Count > 0)
						{
							num = Convert.ToInt32(list_12.Last().SeatNum) + 1;
						}
						foreach (OrderResult item in list)
						{
							orderMethods.UpdateOrderTable(item.OrderNumber, string_4, string_5, short_5, num.ToString());
							num++;
						}
					}
					else
					{
						orderMethods.UpdateOrderTable(CS_0024_003C_003E8__locals0.orderNumber, string_4, string_5, short_5);
					}
				}
			}
			else
			{
				orderMethods.UpdateOrderTable(CS_0024_003C_003E8__locals0.orderNumber, string_4, string_5, short_5);
			}
			orderMethods.SubmitChanges();
		}
		if (string_11 == OrderTypes.DineIn)
		{
			if (CS_0024_003C_003E8__locals0.orderNumber != "")
			{
				method_43();
			}
			else if (string_10 != string_4)
			{
				GuestMethods.UpdateTableGuestCapacity(string_10.Replace("Table ", ""), 0, 0);
				GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), short_5, int_14);
			}
			string_10 = string_4;
		}
		else if (string_5 != string_11)
		{
			GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), short_5, int_14);
			string_10 = string_4;
		}
		if (string_14 == null)
		{
			return;
		}
		try
		{
			GClass6 gClass = new GClass6();
			gClass.Layouts.Where((Layout x) => x.TableName == string_14).FirstOrDefault().CurrentGuests = 0;
			Helper.SubmitChangesWithCatch(gClass);
		}
		catch
		{
		}
	}

	private void method_43()
	{
		if (string_5 == string_11)
		{
			if (string_10 != string_4)
			{
				method_44(string_10);
				OrderMethods orderMethods = new OrderMethods();
				if ((from o in orderMethods.GetMultipleBills(string_10, OrderTypes.DineIn)
					where o.DateCreated.AddHours(24.0) > DateTime.Now
					select o).Count() > 0 && (from o in orderMethods.GetMultipleBills(string_4, OrderTypes.DineIn)
					where o.DateCreated.AddHours(24.0) > DateTime.Now
					select o).Count() > 0)
				{
					GuestMethods.UpdateTableGuestCapacityByOrderGuestCount(string_10.Replace("Table ", ""));
					GuestMethods.UpdateTableGuestCapacityByOrderGuestCount(string_4.Replace("Table ", ""));
				}
				else
				{
					GuestMethods.UpdateTableGuestCapacity(string_10.Replace("Table ", ""), 0, int_14);
					GuestMethods.UpdateTableGuestCapacity(string_4.Replace("Table ", ""), short_5, int_14);
				}
			}
		}
		else
		{
			method_44(string_10);
		}
	}

	private void method_44(string string_16)
	{
		_003C_003Ec__DisplayClass188_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass188_0();
		CS_0024_003C_003E8__locals0.preCustomer = string_16;
		GClass6 gClass = new GClass6();
		gClass.Refresh(RefreshMode.OverwriteCurrentValues);
		IQueryable<Order> queryable = gClass.Orders.Where((Order o) => o.Customer == "Table " + CS_0024_003C_003E8__locals0.preCustomer.Replace("Table", string.Empty).Trim() && o.OrderType == OrderTypes.DineIn && o.Paid == true && o.Void == false && o.DateCreated.Value > DateTime.Now.AddDays(-1.0) && o.DateCleared == null);
		gClass.Refresh(RefreshMode.OverwriteCurrentValues, queryable);
		foreach (Order item in queryable)
		{
			item.DateCleared = DateTime.Now;
			item.TipRecorded = true;
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	private bool method_45(bool bool_30 = true)
	{
		if (radListItems.Items.Count == 0)
		{
			if (string_10 != string_4)
			{
				method_43();
			}
			else
			{
				new NotificationLabel(this, Resources.There_are_no_items_to_save_Ple, NotificationTypes.Notification).Show();
			}
			return false;
		}
		if (string.IsNullOrEmpty(string_3))
		{
			string_3 = OrderMethods.GetNewOrderNumber();
		}
		list_5 = new List<Item>();
		DataManager dataManager = new DataManager();
		GClass6 gClass = new GClass6();
		if (dateFullfilment.HasValue)
		{
			orderOnHoldTime = (int)(dateFullfilment.Value - DateTime.Now).TotalMinutes;
		}
		foreach (ListViewDataItem item2 in radListItems.Items.ToList())
		{
			_003C_003Ec__DisplayClass189_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass189_0();
			CS_0024_003C_003E8__locals3._003C_003E4__this = this;
			if (dateFullfilment.HasValue && item2.SubItems[14].ToString() != "-1")
			{
				item2.SubItems[14] = orderOnHoldTime.ToString();
			}
			CS_0024_003C_003E8__locals3.sold_item = new Item();
			CS_0024_003C_003E8__locals3.itemFromDB = dataManager.getOneItem(Convert.ToInt32(item2.SubItems[4].ToString()));
			CS_0024_003C_003E8__locals3.sold_item.ItemID = CS_0024_003C_003E8__locals3.itemFromDB.ItemID;
			if (!CS_0024_003C_003E8__locals3.itemFromDB.ItemsInGroups.Any())
			{
				ItemsInGroup itemsInGroup = MemoryLoadedObjects.all_itemsInGroups.Where((ItemsInGroup x) => x.ItemID.Value == CS_0024_003C_003E8__locals3.itemFromDB.ItemID).FirstOrDefault();
				if (itemsInGroup != null)
				{
					CS_0024_003C_003E8__locals3.sold_item.ItemsInGroups.Add(itemsInGroup);
				}
			}
			else
			{
				CS_0024_003C_003E8__locals3.sold_item.ItemsInGroups = CS_0024_003C_003E8__locals3.itemFromDB.ItemsInGroups;
			}
			CS_0024_003C_003E8__locals3.sold_item.InventoryCount = CS_0024_003C_003E8__locals3.itemFromDB.InventoryCount;
			CS_0024_003C_003E8__locals3.sold_item.ItemType = CS_0024_003C_003E8__locals3.itemFromDB.ItemType;
			CS_0024_003C_003E8__locals3.sold_item.ItemTypeID = CS_0024_003C_003E8__locals3.itemFromDB.ItemTypeID;
			CS_0024_003C_003E8__locals3.sold_item.OnSale = CS_0024_003C_003E8__locals3.itemFromDB.OnSale;
			CS_0024_003C_003E8__locals3.sold_item.TaxRule = CS_0024_003C_003E8__locals3.itemFromDB.TaxRule;
			CS_0024_003C_003E8__locals3.sold_item.TaxRuleID = CS_0024_003C_003E8__locals3.itemFromDB.TaxRuleID;
			CS_0024_003C_003E8__locals3.sold_item.ItemCourse = ((item2.Group == null) ? CS_0024_003C_003E8__locals3.itemFromDB.ItemCourse : ((item2.Group != listViewDataItemGroup_6) ? item2.Group.Text.Substring(0, item2.Group.Text.Length - 1) : item2.Group.Text));
			string text = (item2[1].ToString().Contains(" => INSTR: ") ? item2[1].ToString().Substring(item2[1].ToString().IndexOf(" => INSTR: ")) : "");
			string itemName = ((!string.IsNullOrEmpty(text)) ? item2[1].ToString().Replace(text, "") : item2[1].ToString());
			CS_0024_003C_003E8__locals3.sold_item.ItemName = itemName;
			string value = (string.IsNullOrEmpty(item2[2].ToString()) ? "0.00" : item2[2].ToString());
			CS_0024_003C_003E8__locals3.sold_item.ItemPrice = Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture);
			string text2 = (string.IsNullOrEmpty(item2[0].ToString()) ? "1" : item2[0].ToString());
			CS_0024_003C_003E8__locals3.sold_item.InventoryCount = MathHelper.FractionToDecimal(text2.ToString().Replace(",", "."));
			_ = CS_0024_003C_003E8__locals3.sold_item.InventoryCount;
			if (!(CS_0024_003C_003E8__locals3.sold_item.ItemPrice * CS_0024_003C_003E8__locals3.sold_item.InventoryCount > 100000m))
			{
				CS_0024_003C_003E8__locals3.sold_item.SortOrder = Convert.ToInt16(item2.SubItems[5].ToString());
				CS_0024_003C_003E8__locals3.sold_item.Temp = ((item2.SubItems.Count >= 7) ? item2.SubItems[6].ToString() : string.Empty);
				CS_0024_003C_003E8__locals3.sold_item.Description = ((item2.SubItems.Count >= 8) ? item2.SubItems[7].ToString() : string.Empty);
				if (CS_0024_003C_003E8__locals3.sold_item.Description.Length <= 250)
				{
					CS_0024_003C_003E8__locals3.sold_item.Active = !item2.Font.Strikeout;
					CS_0024_003C_003E8__locals3.sold_item.MaxFreeOptions = ((item2.SubItems.Count >= 7) ? Convert.ToInt32(item2.SubItems[9].ToString()) : 0);
					if (!CS_0024_003C_003E8__locals3.sold_item.ItemName.Contains("SUB:") && !CS_0024_003C_003E8__locals3.sold_item.ItemName.Contains("ADD:") && !CS_0024_003C_003E8__locals3.sold_item.ItemName.Contains("OPT:"))
					{
						CS_0024_003C_003E8__locals3.sold_item.ItemCost = ((item2.SubItems.Count < 9 || !(item2.SubItems[8].ToString() != "-1")) ? (-1m) : Convert.ToDecimal(item2.SubItems[8].ToString(), Thread.CurrentThread.CurrentCulture));
					}
					else
					{
						CS_0024_003C_003E8__locals3.sold_item.ItemCost = Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture);
					}
					CS_0024_003C_003E8__locals3.sold_item.Notes = ((item2.SubItems[13] != null) ? item2.SubItems[13].ToString() : "NO PROMO CODE");
					CS_0024_003C_003E8__locals3.sold_item.StationID = item2.SubItems[14].ToString();
					CS_0024_003C_003E8__locals3.sold_item.Barcode = item2.SubItems[15].ToString();
					CS_0024_003C_003E8__locals3.sold_item.ItemSalePrice = OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals3.sold_item.Barcode, DiscountTypes.Item) / CS_0024_003C_003E8__locals3.sold_item.InventoryCount;
					CS_0024_003C_003E8__locals3.sold_item.MinFreeOptions = Convert.ToInt32(item2.SubItems[11].ToString());
					CS_0024_003C_003E8__locals3.sold_item.ItemClassification = ((item2.SubItems[16] == null) ? "MainItem" : item2.SubItems[16].ToString());
					CS_0024_003C_003E8__locals3.sold_item.ResetQty = Convert.ToDecimal(item2.SubItems[17].ToString());
					CS_0024_003C_003E8__locals3.sold_item.ItemLongName = item2.SubItems[20].ToString();
					CS_0024_003C_003E8__locals3.sold_item.DisableSoldOutItems = false;
					if (!CS_0024_003C_003E8__locals3.sold_item.Active && item2.SubItems.Count > 21 && item2.SubItems[22].ToString() != ((byte)5).ToString())
					{
						if (bool_17 && !item2[1].ToString().Contains("OPT:") && !item2[1].ToString().Contains("DELIVERY") && !item2[1].ToString().Contains("   "))
						{
							_003C_003Ec__DisplayClass189_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass189_1();
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals3;
							CS_0024_003C_003E8__locals0.refundReasons = (from r in gClass.Reasons
								where r.ReasonType == "void"
								select r into d
								select d.Value).ToArray();
							if (!string.IsNullOrEmpty(string_15))
							{
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.sold_item.ItemColor = string_15;
							}
							else
							{
								Invoke((MethodInvoker)delegate
								{
									MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
									MemoryLoadedObjects.ItemSelector.LoadForm(CS_0024_003C_003E8__locals0.refundReasons, _withCustom: true, "Select Void Reason for " + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.sold_item.ItemName, _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: true);
									if (MemoryLoadedObjects.ItemSelector.ShowDialog(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
									{
										CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.sold_item.ItemColor = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
										if (MemoryLoadedObjects.ItemSelector.SameForAllValue)
										{
											CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this.string_15 = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.sold_item.ItemColor;
										}
									}
								});
							}
						}
						if (CS_0024_003C_003E8__locals3.sold_item.Temp != string.Empty)
						{
							_003C_003Ec__DisplayClass189_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass189_2();
							CS_0024_003C_003E8__locals1.order = gClass.Orders.Where((Order a) => ((object)a.OrderId).ToString() == CS_0024_003C_003E8__locals3.sold_item.Temp).FirstOrDefault();
							if (CS_0024_003C_003E8__locals1.order != null && CS_0024_003C_003E8__locals1.order.DateFilled.HasValue && CS_0024_003C_003E8__locals1.order.FlagID != 5)
							{
								Item item = MemoryLoadedData.all_active_items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals1.order.ItemID).FirstOrDefault();
								if (item != null && item.TrackInventory)
								{
									Invoke((MethodInvoker)delegate
									{
										if (new frmMessageBox(Resources.Do_you_want_to_return_the_item + CS_0024_003C_003E8__locals3.sold_item.ItemName + Resources._back_to_inventory, Resources.Return_Item_To_Inventory, CustomMessageBoxButtons.YesNo).ShowDialog(CS_0024_003C_003E8__locals3._003C_003E4__this) == DialogResult.Yes)
										{
											CS_0024_003C_003E8__locals3.sold_item.DisableSoldOutItems = true;
										}
									});
								}
							}
						}
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.itemFromDB.StationID) && (!CS_0024_003C_003E8__locals3.sold_item.Active || string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.sold_item.Temp)))
					{
						if (CS_0024_003C_003E8__locals3.itemFromDB.StationID.Split(',').Contains("1"))
						{
							bool_14 = true;
						}
						else if (CS_0024_003C_003E8__locals3.itemFromDB.StationID.Split(',').Contains("2"))
						{
							bool_15 = true;
						}
					}
					list_5.Add(CS_0024_003C_003E8__locals3.sold_item);
					continue;
				}
				Invoke((MethodInvoker)delegate
				{
					new frmMessageBox("Invalid Order, Instructions is too long", "Invalid order").ShowDialog(this);
				});
				return false;
			}
			Invoke((MethodInvoker)delegate
			{
				new frmMessageBox("Invalid order, total price is too large.", "Invalid order").ShowDialog(this);
			});
			return false;
		}
		using (List<Item>.Enumerator enumerator2 = (from a in list_5
			where a.MaxFreeOptions > 0
			group a by a.MaxFreeOptions into a
			select new Item
			{
				MaxFreeOptions = a.Key,
				ItemName = a.First().ItemName,
				InventoryCount = a.Sum((Item b) => b.InventoryCount)
			}).ToList().GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass189_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass189_3();
				CS_0024_003C_003E8__locals2._003C_003E4__this = this;
				CS_0024_003C_003E8__locals2.batchItem = enumerator2.Current;
				if (!orderHelper_0.CheckBatchQty(CS_0024_003C_003E8__locals2.batchItem.MaxFreeOptions, CS_0024_003C_003E8__locals2.batchItem.InventoryCount))
				{
					Invoke((MethodInvoker)delegate
					{
						new NotificationLabel(CS_0024_003C_003E8__locals2._003C_003E4__this, CS_0024_003C_003E8__locals2.batchItem.ItemName + " has qty greater than the qty of it's Expiry Batch", NotificationTypes.Warning).Show();
					});
					return false;
				}
			}
		}
		if (bool_30)
		{
			dataManager_0.CalculateOrderDiscount(list_5, decimal_0, decimal_2);
		}
		string_15 = "";
		return true;
	}

	private void btnCustomerInfo_Click(object sender, EventArgs e)
	{
		frmCustomerInfo frmCustomerInfo2 = new frmCustomerInfo(string_7, string_8, string_6.Replace(Resources.DELIVER_TO, string.Empty));
		if (frmCustomerInfo2.ShowDialog(this) == DialogResult.OK)
		{
			string_7 = frmCustomerInfo2.getCustomerName();
			if (!string.IsNullOrEmpty(frmCustomerInfo2.getCustomerAddress()) && string_5 != OrderTypes.Delivery)
			{
				if (new frmMessageBox("Would you like to change this to a delivery order?", "Change Order Type?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
				{
					ChangeToDeliveryTakeout(frmCustomerInfo2.getCustomerName(), frmCustomerInfo2.getCustomerPhone(), frmCustomerInfo2.getCustomerAddress(), OrderTypes.Delivery);
					new NotificationLabel(this, "Order Type changed to Delivery.", NotificationTypes.Success).Show();
				}
				else
				{
					string_6 = frmCustomerInfo2.getCustomerAddress();
					string_7 = frmCustomerInfo2.getCustomerName();
					string_8 = frmCustomerInfo2.getCustomerPhone();
				}
			}
			if (string_5 != OrderTypes.DineIn || (string_5 == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service"))
			{
				if (!string.IsNullOrEmpty(frmCustomerInfo2.getCustomerPhone().Trim()))
				{
					string_4 = frmCustomerInfo2.getCustomerPhone().Trim();
				}
				else if (string_4 == "")
				{
					string_4 = "Walk In";
				}
			}
			string_6 = frmCustomerInfo2.getCustomerAddress();
			string_7 = frmCustomerInfo2.getCustomerName();
			string_8 = frmCustomerInfo2.getCustomerPhone();
			method_58();
			isSaved = false;
		}
		frmCustomerInfo2.Dispose();
	}

	public void ChangeToDeliveryTakeout(string name, string phone, string address, string changeOrderType)
	{
		bool_1 = true;
		string_7 = name;
		string_4 = phone;
		if (string_5 != OrderTypes.DineIn)
		{
			string_4 = phone;
		}
		if (changeOrderType == OrderTypes.Delivery)
		{
			string_6 = Resources.DELIVER_TO + address;
			lblOrderType.Text = (string_5 = OrderTypes.Delivery);
			decimal_5 = DeliveryMethods.GetDeliveryFee(string_6.Replace(Resources.DELIVER_TO, ""));
			method_46();
		}
		else
		{
			lblOrderType.Text = (string_5 = changeOrderType);
			string_6 = address;
			ListViewDataItem listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").FirstOrDefault();
			if (listViewDataItem != null)
			{
				if (!string.IsNullOrEmpty(listViewDataItem.SubItems[6].ToString()))
				{
					listViewDataItem.Font = new Font(listViewDataItem.Font.FontFamily, listViewDataItem.Font.Size, FontStyle.Strikeout);
				}
				else
				{
					radListItems.Items.Remove(listViewDataItem);
				}
				RecalculateTaxAndSubtotal();
			}
		}
		method_58();
		Button button = btnSaveClose;
		btnSaveOrder.Enabled = true;
		button.Enabled = true;
	}

	private void method_46()
	{
		if (!(decimal_5 > 0m) || !(string_5 == OrderTypes.Delivery))
		{
			return;
		}
		if (radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").FirstOrDefault() == null)
		{
			if (new GClass6().Orders.Where((Order a) => a.OrderNumber == string_3 && a.ItemID == -999).FirstOrDefault() == null)
			{
				isSaved = false;
				method_28("DELIVERY FEE", decimal_5, -999);
				RecalculateTaxAndSubtotal();
				return;
			}
		}
		else
		{
			ListViewDataItem listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").FirstOrDefault();
			if (listViewDataItem != null && MathHelper.FractionToDecimal(listViewDataItem[0].ToString()) == 1m)
			{
				isSaved = false;
				object value = (listViewDataItem[3] = decimal_5.ToString("0.00"));
				listViewDataItem[2] = value;
				RecalculateTaxAndSubtotal();
			}
		}
		listViewDataItemGroup_0 = null;
	}

	private void DpoFeuYkxVM_Click(object sender, EventArgs e)
	{
		if (((Button)sender).Text == Resources.CHANGE_ORDER_TYPE)
		{
			string[] itemList = MemoryLoadedObjects.DefaultOrderTypes.Split(',');
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
			MemoryLoadedObjects.ItemSelector.LoadForm(itemList, _withCustom: false, Resources.Select_an_Order_Type, _IsMultipleSelect: false, _autoClose: true);
			if (MemoryLoadedObjects.ItemSelector.ShowDialog(this) == DialogResult.OK)
			{
				string singleSelectedItem = MemoryLoadedObjects.ItemSelector.SingleSelectedItem;
				if (singleSelectedItem == lblOrderType.Text)
				{
					return;
				}
				string text = string_5;
				if (!(singleSelectedItem == OrderTypes.Delivery) && !(singleSelectedItem == OrderTypes.PickUp) && !(singleSelectedItem == OrderTypes.Catering))
				{
					if (singleSelectedItem == OrderTypes.ToGo)
					{
						lblOrderType.Text = (string_5 = OrderTypes.ToGo);
					}
					else if (singleSelectedItem == OrderTypes.MakeToStock)
					{
						lblOrderType.Text = (string_5 = singleSelectedItem);
						btnPay.Enabled = false;
					}
					else
					{
						lblOrderType.Text = singleSelectedItem;
						string_5 = singleSelectedItem;
					}
				}
				else
				{
					new OrderHelper().TakeOutDeliveryFlow(singleSelectedItem, bool_0: true, this);
					if (string_4 != string_10)
					{
						int_13 = MemoryLoadedObjects.CustomersMini.returnCustomerId;
						method_58();
						btnClear.Enabled = true;
					}
				}
				if (!btnPay.Enabled && singleSelectedItem != OrderTypes.MakeToStock && radListItems.Items.Count > 0)
				{
					btnPay.Enabled = true;
				}
				foreach (ListViewDataItem item2 in radListItems.Items)
				{
					item2.SubItems[14] = orderOnHoldTime.ToString();
					if (string_5 == OrderTypes.MakeToStock)
					{
						_003C_003Ec__DisplayClass193_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass193_0();
						CS_0024_003C_003E8__locals1.itemid = Convert.ToInt32(item2.SubItems[4].ToString());
						Item item = MemoryLoadedData.all_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.itemid).FirstOrDefault();
						if (item.BatchStockQty > 1m)
						{
							item2[0] = item.BatchStockQty.ToString("0.####", Thread.CurrentThread.CurrentCulture);
						}
						item2[2] = $"{0:0.00}";
						item2[3] = $"{0:0.00}";
					}
				}
				radListItems.Refresh();
				RecalculateTaxAndSubtotal();
				method_47(text, singleSelectedItem);
				if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && string_5 != OrderTypes.DineIn && string_5 != OrderTypes.ToGo)
				{
					btnSaveClose.Text = "SAVE && NEW";
					btnSaveClose.Enabled = true;
					btnSaveOrder.Enabled = false;
				}
				else if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && (string_5 == OrderTypes.DineIn || string_5 == OrderTypes.ToGo))
				{
					Button button = btnSaveClose;
					btnSaveOrder.Enabled = false;
					button.Enabled = false;
				}
				else
				{
					btnSaveClose.Text = "SAVE && CLOSE";
					btnSaveClose.Enabled = true;
					btnSaveOrder.Enabled = true;
				}
				if (!string.IsNullOrEmpty(string_3))
				{
					OrderMethods.LogOrderAudit(string_3, "Order Changed Order Type -> " + text + " to " + string_5);
				}
			}
			else
			{
				base.DialogResult = DialogResult.None;
			}
			if (string_5 == OrderTypes.ToGo)
			{
				lblSeat.Visible = false;
			}
			else
			{
				lblSeat.Visible = true;
			}
			method_17();
			return;
		}
		int num = GuestMethods.GetCurrentTableGuestCapacity(string_4, string_3);
		GClass6 gClass = new GClass6();
		if (num == -1)
		{
			int num2 = (from x in gClass.Layouts
				where x.TableName == string_4.Replace("Table ", "")
				select x.CurrentGuests).FirstOrDefault();
			num = ((num2 > 0) ? num2 : short_5);
		}
		frmTableChange frmTableChange2 = new frmTableChange("Change Table", num, string_4, string_5, string_7);
		if (frmTableChange2.ShowDialog(this) == DialogResult.OK)
		{
			_003C_003Ec__DisplayClass193_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass193_1();
			string orderType = frmTableChange2.OrderType;
			CS_0024_003C_003E8__locals0.newOrderTable = frmTableChange2.OrderTable;
			int num3 = (from x in gClass.Layouts
				where x.TableName == CS_0024_003C_003E8__locals0.newOrderTable
				select x.CurrentGuests).FirstOrDefault();
			string customerInfoName = frmTableChange2.CustomerInfoName;
			int_9 = frmTableChange2.GuestsMoved;
			OrderMethods orderMethods = new OrderMethods();
			list_6 = new List<OrderResult>();
			foreach (OrderResult item3 in (from o in orderMethods.GetMultipleBills(string_4, string_5)
				where o.DateCreated.AddHours(24.0) > DateTime.Now
				select o into a
				group a by a.OrderNumber into a
				select a.FirstOrDefault()).ToList())
			{
				list_6.Add(item3);
			}
			if (string_5 == OrderTypes.DineIn && "Table " + CS_0024_003C_003E8__locals0.newOrderTable != lblCustomer.Text && list_6.Count() > 1)
			{
				if (new frmMessageBox(Resources.There_seems_to_be_more_than_on, Resources.Multiple_Bills, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
				{
					int_12 = 1;
				}
				else
				{
					int_12 = list_6.Count();
				}
			}
			if (orderType == lblOrderType.Text)
			{
				if (lblOrderType.Text == OrderTypes.DineIn)
				{
					if (!("Table " + CS_0024_003C_003E8__locals0.newOrderTable == lblCustomer.Text))
					{
						lblCustomer.Text = "Table " + CS_0024_003C_003E8__locals0.newOrderTable;
						string_4 = lblCustomer.Text;
						short_5 = (short)(num3 + int_9);
						bool_24 = true;
						Button button2 = btnSaveOrder;
						btnSaveClose.Enabled = true;
						button2.Enabled = true;
						lblTableSeatName.Text = string_4 + " - " + lblSeat.Text;
					}
				}
				else
				{
					if (!(CS_0024_003C_003E8__locals0.newOrderTable == lblCustomer.Text))
					{
						string_4 = CS_0024_003C_003E8__locals0.newOrderTable;
						method_58();
						short_5 = (short)(num3 + int_9);
						Button button3 = btnSaveOrder;
						btnSaveClose.Enabled = true;
						button3.Enabled = true;
					}
					string_7 = customerInfoName;
				}
			}
			else
			{
				method_47(lblOrderType.Text, orderType);
				if (orderType == OrderTypes.ToGo)
				{
					lblOrderType.Text = OrderTypes.ToGo;
					lblCustomer.Text = Resources.Walk_In;
					string_14 = frmTableChange2.OriginalTable;
				}
				else
				{
					lblOrderType.Text = OrderTypes.DineIn;
					lblCustomer.Text = "Table " + CS_0024_003C_003E8__locals0.newOrderTable;
					short_5 = (short)(num3 + frmTableChange2.Guest);
					bool_24 = true;
				}
				string_4 = lblCustomer.Text;
				string_5 = lblOrderType.Text;
				string_7 = customerInfoName;
				Button button4 = btnSaveOrder;
				btnSaveClose.Enabled = true;
				button4.Enabled = true;
			}
		}
		frmTableChange2.Dispose();
		if (string_5 == OrderTypes.ToGo)
		{
			lblSeat.Visible = false;
		}
		else
		{
			lblSeat.Visible = true;
		}
		method_29();
		if (string_5.Equals(OrderTypes.MakeToStock))
		{
			btnPay.Enabled = false;
		}
		method_17();
	}

	private void method_47(string string_16, string string_17)
	{
		if (!string_16.Contains(OrderTypes.Delivery) || string_17.Contains(OrderTypes.Delivery))
		{
			return;
		}
		ListViewDataItem listViewDataItem = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[4].ToString() == "-999").FirstOrDefault();
		if (listViewDataItem != null)
		{
			if (listViewDataItem.SubItems[6].ToString() == string.Empty)
			{
				radListItems.Items.Remove(listViewDataItem);
			}
			else
			{
				listViewDataItem.Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Strikeout);
			}
			RecalculateTaxAndSubtotal();
		}
	}

	private void btnRight_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (frmMasterForm.lockedControls != null && frmMasterForm.lockedControls.Select((LockedControl x) => x.Name).Contains(button.Name) && button.Name != "btnRemove" && button.Name != "btnClear" && button.Name != "btnChangePrice" && button.Name != "btnOrderDiscount" && button.Enabled)
		{
			button.Enabled = false;
		}
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Name == "btnSaveOrder" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			button.Enabled = false;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void btnChangeGuests_Click(object sender, EventArgs e)
	{
		string tableName = lblCustomer.Text.Replace("Table ", "");
		short totalTableGuestCapacity = GuestMethods.GetTotalTableGuestCapacity(tableName);
		if (Convert.ToInt16((double)totalTableGuestCapacity * 1.5) <= int_0)
		{
			frmPatronNum frmPatronNum2 = new frmPatronNum(totalTableGuestCapacity);
			if (frmPatronNum2.ShowDialog() == DialogResult.OK)
			{
				short_5 = frmPatronNum2.seat;
				int seat = frmPatronNum2.seat;
				GuestMethods.UpdateTableGuestCapacity(tableName, seat, int_14);
				method_48();
				new NotificationLabel(this, Resources.Guest_count_changed, NotificationTypes.Success).Show();
			}
		}
		else
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Number_of_Guest, 0, 3);
			if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
			{
				int num = Convert.ToInt32(MemoryLoadedObjects.Numpad.numberEntered);
				if (num > 0)
				{
					short_5 = (short)num;
					GuestMethods.UpdateTableGuestCapacity(tableName, num, int_14);
					method_48();
					new NotificationLabel(this, Resources.Guest_count_changed, NotificationTypes.Success).Show();
				}
				else
				{
					new NotificationLabel(this, Resources.The_number_of_guests_must_be_g, NotificationTypes.Notification).Show();
				}
			}
		}
		if (MemoryLoadedObjects.OrderEntrySecondScreen != null)
		{
			MemoryLoadedObjects.OrderEntrySecondScreen.CalculateAutoGratuity();
		}
	}

	private void method_48()
	{
		bool flag = false;
		flag = ((SettingsHelper.GetSettingValueByKey("auto_gratuity") == "ON") ? true : false);
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_gratuity_count");
		int currentTableGuestCapacity = GuestMethods.GetCurrentTableGuestCapacity(string_4.Replace("Table ", ""));
		if (flag && string_5 == OrderTypes.DineIn)
		{
			if (currentTableGuestCapacity >= Convert.ToInt32(settingValueByKey))
			{
				OrderMethods.ComputeAutoGratuity(string_3, "fr-CA");
			}
			else
			{
				OrderMethods.RemoveAutoGratuity(string_3);
			}
		}
	}

	private void method_49(object sender, EventArgs e)
	{
		if (lblOrderType.Text == "Dine In")
		{
			lblOrderType.Font = new Font(lblOrderType.Font.FontFamily, lblOrderType.Font.Size - 0.75f, FontStyle.Bold);
			lblOrderType.Text = Resources.Dine_In;
		}
	}

	private void picItemInfo_Click(object sender, EventArgs e)
	{
		if (!bool_23)
		{
			bool_23 = true;
			new NotificationLabel(this, Resources.Select_Item_to_view, NotificationTypes.Notification).Show();
		}
	}

	private Dictionary<Tax, decimal> method_50(List<Tax> list_12)
	{
		Dictionary<Tax, decimal> dictionary = new Dictionary<Tax, decimal>();
		foreach (Tax item in list_12)
		{
			dictionary.Add(item, 0m);
		}
		return dictionary;
	}

	private void btnPrintBill_Click(object sender, EventArgs e)
	{
		if (radListItems.Items.Count > 0)
		{
			bool flag = true;
			if (btnSaveOrder.Enabled || !isSaved || bool_25)
			{
				flag = method_41(null, 0);
			}
			if (flag)
			{
				loadOrderByOrderNumber(string_3);
				method_42(string_3);
				string settingValueByKey = SettingsHelper.GetSettingValueByKey("print_gratuity_info");
				string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("auto_gratuity");
				if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey.ToUpper().Equals("ON") && settingValueByKey2.ToUpper().Equals("OFF"))
				{
					PrintHelper.GenerateReceipt(string_3, printPaymentTransaction: false, 1, null, tipFlag: true, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				}
				else
				{
					PrintHelper.GenerateReceipt(string_3, printPaymentTransaction: false, 1, null, tipFlag: false, email: false, MemoryLoadedObjects.this_terminal.DefaultPrinter);
				}
				isSaved = false;
				Button button = btnSaveClose;
				btnSaveOrder.Enabled = true;
				button.Enabled = true;
			}
		}
		else
		{
			new NotificationLabel(this, Resources.There_s_nothing_to_print, NotificationTypes.Notification).Show();
		}
	}

	private void btnInstructions_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Instructions();
			MemoryLoadedObjects.Instructions.page_load(this);
			MemoryLoadedObjects.Instructions.ShowDialog(this);
			Button button = btnSaveOrder;
			btnSaveClose.Enabled = true;
			button.Enabled = true;
			isSaved = false;
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_on_the_b, NotificationTypes.Notification).Show();
		}
	}

	private void btnChangeQty_Click(object sender, EventArgs e)
	{
		method_51();
	}

	private void method_51(bool bool_30 = true, decimal qty = 0m)
	{
		if (radListItems.SelectedItems.Count != 0)
		{
			_003C_003Ec__DisplayClass204_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass204_0();
			GClass6 gClass = new GClass6();
			string value = (string.IsNullOrEmpty(radListItems.SelectedItems[0][2].ToString()) ? "0.00" : radListItems.SelectedItems[0][2].ToString());
			decimal decimal_ = Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture);
			decimal previousQty = Convert.ToDecimal(MathHelper.FractionToDecimal(string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString()));
			int selectedTag = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
			CS_0024_003C_003E8__locals0.itemId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
			Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
			CS_0024_003C_003E8__locals0.selectedComboId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[5].ToString());
			int num = ((radListItems.SelectedItems[0].SubItems.Count > 9 && !string.IsNullOrEmpty(radListItems.SelectedItems[0].SubItems[9].ToString())) ? Convert.ToInt32(radListItems.SelectedItems[0].SubItems[9].ToString()) : 0);
			if (bool_30)
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_New_Quantity, 4, 8, string.Empty, string.Empty);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				if (MemoryLoadedObjects.Numpad.numberEntered <= 0m)
				{
					new NotificationLabel(this, "Please enter a value greater than zero.", NotificationTypes.Notification).Show();
					return;
				}
				qty = MemoryLoadedObjects.Numpad.numberEntered;
			}
			if (CS_0024_003C_003E8__locals0.selectedComboId > 0)
			{
				using IEnumerator<ListViewDataItem> enumerator = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.selectedComboId.ToString()).GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass204_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass204_1();
					CS_0024_003C_003E8__locals1.invetoryItem = enumerator.Current;
					Item item2 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals1.invetoryItem.SubItems[4].ToString()).FirstOrDefault();
					if (!MiscHelper.CheckItemDisableSOldOut(this, item2, radListItems, qty, previousQty))
					{
						return;
					}
				}
			}
			else if (!MiscHelper.CheckItemDisableSOldOut(this, item, radListItems, qty, previousQty))
			{
				return;
			}
			CS_0024_003C_003E8__locals0.orderId = radListItems.SelectedItems[0].SubItems[6].ToString();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.orderId))
			{
				Order order = gClass.Orders.Where((Order a) => a.OrderId == new Guid(CS_0024_003C_003E8__locals0.orderId)).FirstOrDefault();
				if (order != null && (!string.IsNullOrEmpty(order.StationMade) || (string.IsNullOrEmpty(order.StationMade) && order.DateFilled.HasValue)))
				{
					short num2 = Convert.ToInt16(radListItems.SelectedItems[0].SubItems[5].ToString());
					previousQty = Convert.ToDecimal(MathHelper.FractionToDecimal(string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString()));
					int num3 = orderHelper_0.CheckAndSelectBatchId(item);
					bool bool_31 = Convert.ToBoolean(radListItems.SelectedItems[0].SubItems[12].ToString());
					if (qty - previousQty == 0m)
					{
						return;
					}
					decimal num4 = qty / previousQty;
					if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0" && !radListItems.SelectedItems[0].SubItems[1].ToString().Contains("ADD: "))
					{
						List<ItemToAddToListModel> list = new List<ItemToAddToListModel>();
						foreach (ListViewDataItem item4 in radListItems.Items)
						{
							if (item4.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString() && !item4.Font.Strikeout)
							{
								string text = item4[1].ToString().ToUpper();
								previousQty = Convert.ToDecimal(MathHelper.FractionToDecimal(item4[0].ToString()));
								decimal_ = Convert.ToDecimal(string.IsNullOrEmpty(item4[2].ToString()) ? "0.00" : item4[2].ToString(), Thread.CurrentThread.CurrentCulture);
								selectedTag = Convert.ToInt32(item4.SubItems[4].ToString());
								bool_31 = Convert.ToBoolean(item4.SubItems[12].ToString());
								int batchId = Convert.ToInt32(item4.SubItems[9].ToString());
								int groupId = Convert.ToInt32(item4.SubItems[10].ToString());
								int optionComboId = Convert.ToInt32(item4.SubItems[11].ToString());
								int itemOptionId = Convert.ToInt32(item4.SubItems[17].ToString());
								decimal d = previousQty * num4;
								d = Math.Round(d, 2);
								if (radListItems.SelectedItems[0].SubItems[1].ToString().ToUpper() != text && radListItems.SelectedItems[0].SubItems[1].ToString().Contains("OPT:"))
								{
									d = previousQty;
								}
								decimal num5 = d - previousQty;
								if (num5 < 0m)
								{
									item4[0] = d.ToString("0.##");
									item4[3] = (d * Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture)).ToString("0.00");
									decimal qty2 = previousQty - d;
									list.Add(new ItemToAddToListModel
									{
										Name = radListItems.SelectedItems[0][1].ToString().ToUpper(),
										Price = decimal_,
										ItemId = CS_0024_003C_003E8__locals0.itemId,
										Qty = qty2,
										ComboId = num2,
										IsComboPotentialSearchable = bool_31,
										batchId = num3,
										GroupId = groupId,
										optionComboId = optionComboId,
										itemOptionId = itemOptionId,
										isDeleted = true
									});
								}
								else
								{
									list.Add(new ItemToAddToListModel
									{
										Name = text,
										Price = decimal_,
										ItemId = selectedTag,
										Qty = num5,
										ComboId = short_4,
										IsComboPotentialSearchable = bool_31,
										batchId = batchId,
										GroupId = groupId,
										optionComboId = optionComboId,
										itemOptionId = itemOptionId,
										isDeleted = false
									});
								}
							}
						}
						foreach (ItemToAddToListModel item5 in list)
						{
							method_28(item5.Name, item5.Price, item5.ItemId, item5.Qty, item5.ComboId, item5.IsComboPotentialSearchable, item5.batchId, item5.GroupId, item5.optionComboId, bool_31: true, 0, "", item5.itemOptionId);
							if (item5.isDeleted)
							{
								radListItems.Items[radListItems.Items.Count - 1].Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Strikeout);
							}
						}
						short_4++;
						if (list.Count > 0)
						{
							Button button = btnSaveOrder;
							btnSaveClose.Enabled = true;
							button.Enabled = true;
						}
					}
					else
					{
						decimal num6 = previousQty * num4;
						decimal num7 = num6 - previousQty;
						if (num7 < 0m)
						{
							num7 = num6;
							ListViewDataItem listViewDataItem = radListItems.SelectedItems[0];
							listViewDataItem[0] = num6.ToString("0.##");
							listViewDataItem[3] = (num7 * Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture)).ToString("0.00");
							decimal qty3 = previousQty - num6;
							method_28(radListItems.SelectedItems[0][1].ToString().ToUpper(), decimal_, CS_0024_003C_003E8__locals0.itemId, qty3, num2, bool_31, 0, 0, 0, bool_31: true, 0, "", Convert.ToInt32(radListItems.SelectedItems[0].SubItems[17]));
							radListItems.Items[radListItems.Items.Count - 1].Font = new Font(radListItems.Font, radListItems.Font.Style | FontStyle.Strikeout);
						}
						else
						{
							method_28(radListItems.SelectedItems[0][1].ToString().ToUpper(), decimal_, CS_0024_003C_003E8__locals0.itemId, num7, num2, bool_31, num3, 0, 0, bool_31: true, 0, "", Convert.ToInt32(radListItems.SelectedItems[0].SubItems[17]));
						}
						Button button2 = btnSaveOrder;
						btnSaveClose.Enabled = true;
						button2.Enabled = true;
					}
					RecalculateTaxAndSubtotal();
					if (radListItems.SelectedItems.Count > 0 && radListItems.SelectedItems[0].Font.Strikeout)
					{
						method_53(bool_30: false);
						btnChangeQty.Enabled = false;
					}
					return;
				}
			}
			if (!item.UOM.isFractional && qty % 1m != 0m)
			{
				new NotificationLabel(this, item.ItemName + Resources._has_a_UOM_of + item.UOM.Name + Resources._Please_add_a_whole_number_for, NotificationTypes.Warning).Show();
			}
			else if (qty > 0m)
			{
				decimal num8 = Convert.ToDecimal(MathHelper.FractionToDecimal(string.IsNullOrEmpty(radListItems.SelectedItems[0][0].ToString()) ? "1" : radListItems.SelectedItems[0][0].ToString()));
				bool flag = false;
				if (num != 0 && qty > 1m && new frmMessageBox("All items have the same expiry date and batch/lot numbers?", "Batch Inventory", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.No)
				{
					flag = true;
					List<int> list2 = new List<int>();
					for (int i = 0; (decimal)i < qty; i++)
					{
						int item3 = orderHelper_0.CheckAndSelectBatchId(item);
						list2.Add(item3);
					}
					List<InventoryBatchWithCount> list3 = (from a in list2
						group a by a into a
						select new InventoryBatchWithCount
						{
							BatchId = a.Key,
							qty = a.Count()
						}).ToList();
					int num9 = 0;
					foreach (InventoryBatchWithCount item6 in list3)
					{
						if (num9 == 0)
						{
							radListItems.SelectedItems[0][0] = item6.qty.ToString("0.####");
							radListItems.SelectedItems[0].SubItems[9] = item6.BatchId;
							if (!string.IsNullOrEmpty(radListItems.SelectedItems[0][2].ToString()))
							{
								radListItems.SelectedItems[0][2].ToString();
							}
							radListItems.SelectedItems[0][3] = (item6.qty * Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture)).ToString("0.00");
							FormHelper.ChangeOrderEntryLVCellByIdentifier(radListItems, radListItems.SelectedItems[0], radListItems.Font.Size, radListItems.SelectedItems[0].SubItems[16].ToString());
						}
						else
						{
							short int_ = Convert.ToInt16(radListItems.SelectedItems[0].SubItems[5].ToString());
							bool bool_32 = Convert.ToBoolean(radListItems.SelectedItems[0].SubItems[12].ToString());
							method_28(radListItems.SelectedItems[0][1].ToString().ToUpper(), decimal_, CS_0024_003C_003E8__locals0.itemId, item6.qty, int_, bool_32, item6.BatchId, 0, 0, bool_31: true, 0, "", Convert.ToInt32(radListItems.SelectedItems[0].SubItems[17]));
						}
						num9++;
					}
				}
				list_11.RemoveAll((int x) => x == CS_0024_003C_003E8__locals0.itemId);
				list_11.AddRange(Enumerable.Repeat(CS_0024_003C_003E8__locals0.itemId, (qty >= 10000m) ? 10000 : ((int)qty)));
				decimal num10 = qty / num8;
				if (!flag)
				{
					radListItems.SelectedItems[0][1] = radListItems.SelectedItems[0][1].ToString();
					radListItems.SelectedItems[0][0] = qty.ToString("0.####");
					string value2 = (string.IsNullOrEmpty(radListItems.SelectedItems[0][2].ToString()) ? "0.00" : radListItems.SelectedItems[0][2].ToString());
					radListItems.SelectedItems[0][3] = (qty * Convert.ToDecimal(value2, Thread.CurrentThread.CurrentCulture)).ToString("0.00");
					FormHelper.ChangeOrderEntryLVCellByIdentifier(radListItems, radListItems.SelectedItems[0], radListItems.Font.Size, radListItems.SelectedItems[0].SubItems[16].ToString());
				}
				if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0" && !radListItems.SelectedItems[0].SubItems[1].ToString().Contains("ADD: "))
				{
					foreach (ListViewDataItem item7 in radListItems.Items)
					{
						if ((!(item7.SubItems[17].ToString() != "0") || !item7.Font.Strikeout) && item7.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString() && item7 != radListItems.SelectedItems[0])
						{
							string fraction = (string.IsNullOrEmpty(item7[0].ToString()) ? "1" : item7[0].ToString());
							string text2 = (string.IsNullOrEmpty(item7[2].ToString()) ? "0.00" : item7[2].ToString());
							decimal d2 = MathHelper.FractionToDecimal(fraction) * num10;
							item7[0] = Math.Round(d2, 2).ToString("0.####");
							item7[3] = (Convert.ToDecimal(item7[0].ToString()) * Convert.ToDecimal(text2.ToString(), Thread.CurrentThread.CurrentCulture)).ToString("0.00");
							FormHelper.ChangeOrderEntryLVCellByIdentifier(radListItems, item7, radListItems.Font.Size, item7.SubItems[16].ToString());
						}
					}
				}
				isSaved = false;
				Button button3 = btnSaveOrder;
				btnSaveClose.Enabled = true;
				button3.Enabled = true;
				RecalculateTaxAndSubtotal();
				checkCombo(selectedTag);
				if (radListItems.SelectedItems.Count > 0 && radListItems.SelectedItems[0].Font.Strikeout)
				{
					method_53(bool_30: false);
					btnChangeQty.Enabled = false;
				}
			}
			else
			{
				new NotificationLabel(this, Resources.The_quantity_should_not_be_zer, NotificationTypes.Notification).Show();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_the_item_to_chan0, NotificationTypes.Notification).Show();
		}
	}

	private void radListItems_SelectedItemChanged(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (radListItems.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass205_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass205_0();
			btnRemove.Enabled = true;
			btnInstructions.Enabled = true;
			btnRemove.Text = ((radListItems.SelectedItems[0].Font == null || !radListItems.SelectedItems[0].Font.Strikeout) ? "REMOVE ITEM" : "UNREMOVE ITEM");
			btnChangeCourse.Enabled = true;
			btnChangeQty.Enabled = true;
			btnRight.Enabled = true;
			method_53(bool_30: true);
			if (radListItems.SelectedItems[0].SubItems[5].ToString() != string.Empty)
			{
				_003C_003Ec__DisplayClass205_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass205_1();
				if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
				{
					if (dataManager_0.getItemsInItem(Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString())).Count() > 0)
					{
						Button button = btnItemSub;
						btnItemSub.Visible = false;
						button.Enabled = false;
					}
					else
					{
						string value = (string.IsNullOrEmpty(radListItems.SelectedItems[0][2].ToString()) ? "0.00" : radListItems.SelectedItems[0][2].ToString());
						if (!radListItems.SelectedItems[0].SubItems[1].ToString().Contains("OPT: ") && (radListItems.SelectedItems[0].SubItems[1].ToString().Contains("   ") || radListItems.SelectedItems[0].SubItems[1].ToString().Contains("SUB: ")))
						{
							if (!(Convert.ToDecimal(value, Thread.CurrentThread.CurrentCulture) == 0m) && !radListItems.SelectedItems[0].SubItems[1].ToString().Contains("ADD: ") && !radListItems.SelectedItems[0].SubItems[1].ToString().Contains("SUB: "))
							{
								bool flag = false;
								if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
								{
									foreach (ListViewDataItem item in radListItems.Items)
									{
										if (item.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString() && (item[1].ToString().Contains("ADD: ") || item[1].ToString().Contains("OPT: ") || item[1].ToString().Contains("SUB: ")))
										{
											flag = true;
											break;
										}
									}
									if (radListItems.Items.Where((ListViewDataItem listViewDataItem_0) => listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString()).Count() == 1)
									{
										flag = true;
									}
								}
								if (flag)
								{
									Button button2 = btnItemSub;
									btnItemSub.Visible = false;
									button2.Enabled = false;
								}
								else
								{
									Button button3 = btnItemSub;
									btnItemSub.Visible = true;
									button3.Enabled = true;
								}
								method_7();
							}
							else
							{
								Button button4 = btnItemSub;
								btnItemSub.Visible = true;
								button4.Enabled = true;
								method_7();
							}
						}
						else
						{
							Button button5 = btnItemSub;
							btnItemSub.Visible = false;
							button5.Enabled = false;
						}
					}
					if (!string.IsNullOrEmpty(radListItems.SelectedItems[0].SubItems[2].ToString()))
					{
						radListItems.SelectedItems[0].SubItems[2].ToString();
					}
					if (radListItems.SelectedItems[0].SubItems[16].ToString() == "MainItem")
					{
						if (radListItems.SelectedItems[0][1].ToString().Contains("SUB:"))
						{
							btnChangeQty.Enabled = false;
						}
						else
						{
							btnChangeQty.Enabled = true;
						}
						btnChangePrice.Enabled = true;
					}
					else
					{
						btnChangeQty.Enabled = false;
						btnChangePrice.Enabled = false;
					}
					method_53(btnChangeQty.Enabled);
				}
				else
				{
					Button button6 = btnItemSub;
					btnItemSub.Visible = false;
					button6.Enabled = false;
					btnChangeQty.Enabled = true;
					btnChangePrice.Enabled = true;
				}
				CS_0024_003C_003E8__locals1.itemId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
				if (gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals1.itemId && i.ToBeDeleted == false).ToList().Count() > 0 && MathHelper.FractionToDecimal(radListItems.SelectedItems[0].SubItems[0].ToString()) >= 1m)
				{
					btnItemOptions.Enabled = true;
				}
				else
				{
					btnItemOptions.Enabled = false;
				}
			}
			else
			{
				Button button7 = btnItemSub;
				btnItemSub.Visible = false;
				button7.Enabled = false;
				btnItemOptions.Enabled = false;
			}
			CS_0024_003C_003E8__locals0.orderId = radListItems.SelectedItems[0].SubItems[6].ToString();
			if (CS_0024_003C_003E8__locals0.orderId != string.Empty)
			{
				_003C_003Ec__DisplayClass205_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass205_2();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals2.order = gClass.Orders.Where((Order a) => a.OrderId == new Guid(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderId) && a.ShareItemID.HasValue == true).FirstOrDefault();
				if (CS_0024_003C_003E8__locals2.order != null && gClass.Orders.Where((Order a) => a.DateCreated > CS_0024_003C_003E8__locals2.order.DateCreated.Value.AddDays(-1.0) && a.ShareItemID.HasValue && a.ShareItemID.Value == new Guid(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderId)).FirstOrDefault() != null)
				{
					btnChangeQty.Enabled = false;
				}
			}
			string value2 = radListItems.SelectedItems[0].SubItems[10].ToString();
			if (CS_0024_003C_003E8__locals0.orderId == string.Empty && Convert.ToInt32(value2) > 0)
			{
				Button button8 = btnChangeComboItem;
				btnChangeComboItem.Enabled = true;
				button8.Visible = true;
			}
			else
			{
				btnChangeComboItem.Visible = false;
			}
			btnRemove.Text = ((radListItems.SelectedItems[0].Font == null || !radListItems.SelectedItems[0].Font.Strikeout) ? "REMOVE ITEM" : "UNREMOVE ITEM");
			method_52();
			btnItemDiscount.Enabled = true;
			if (radListItems.SelectedItems[0].SubItems[16] != null && (radListItems.SelectedItems[0].SubItems[16].ToString() == "ChildItem" || radListItems.SelectedItems[0].SubItems[16].ToString() == "OptionItem" || radListItems.SelectedItems[0][1].ToString().Contains("OPT:") || (radListItems.SelectedItems[0][1].ToString().Contains("[") && radListItems.SelectedItems[0][1].ToString().Contains("]"))) && radListItems.SelectedItems[0][3].ToString() == "")
			{
				btnItemDiscount.Enabled = false;
			}
			if (radListItems.SelectedItems[0][1].ToString().ToUpper().Contains("DELIVERY FEE"))
			{
				btnChangeQty.Enabled = false;
			}
			int num = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[14].ToString());
			Order order = null;
			if (CS_0024_003C_003E8__locals0.orderId != string.Empty)
			{
				order = gClass.Orders.Where((Order a) => a.OrderId == new Guid(CS_0024_003C_003E8__locals0.orderId)).FirstOrDefault();
			}
			if (num != -1 && num != 0 && (order == null || num <= 0 || !(order.DateCreated.Value < DateTime.Now.AddMinutes(-order.OrderOnHoldTime))))
			{
				btnFire.Enabled = true;
			}
			else
			{
				btnFire.Enabled = false;
			}
			if (radListItems.SelectedItems.Count > 0 && radListItems.SelectedItems[0].Font != null && radListItems.SelectedItems[0].Font.Strikeout)
			{
				btnChangeQty.Enabled = false;
			}
		}
		else
		{
			btnFire.Enabled = false;
			btnRemove.Enabled = false;
			btnInstructions.Enabled = false;
			Button button9 = btnItemSub;
			btnItemSub.Visible = false;
			button9.Enabled = false;
			btnItemOptions.Enabled = false;
			btnChangeComboItem.Visible = false;
			btnChangeQty.Enabled = false;
		}
		method_53(btnChangeQty.Enabled);
	}

	private void method_52()
	{
		btnItemDiscount.Text = Resources.ITEM_DISCOUNT;
		if (radListItems.SelectedItems.Count > 0 && radListItems.SelectedItems[0].SubItems[15].ToString().Contains(DiscountTypes.Item))
		{
			btnItemDiscount.Text = Resources.REMOVE_ITEM_DISCOUNT;
		}
	}

	private void btnOpenOrders_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("quick_service_view") == "tile")
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
			MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL");
			MemoryLoadedObjects.QuickService.Show();
			MemoryLoadedObjects.QuickService.Focus();
		}
		else
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickServiceListView();
			MemoryLoadedObjects.QuickServiceListView.LoadFormData();
			MemoryLoadedObjects.QuickServiceListView.Show();
			MemoryLoadedObjects.QuickServiceListView.Focus();
		}
		if (timer_0.Enabled)
		{
			timer_0.Enabled = false;
			btnOpenOrders.BackColor = (Color)btnOpenOrders.Tag;
		}
		base.DialogResult = DialogResult.Cancel;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (btnOpenOrders.BackColor != Color.Red)
		{
			btnOpenOrders.Tag = btnOpenOrders.BackColor;
			btnOpenOrders.BackColor = Color.Red;
		}
		else
		{
			btnOpenOrders.BackColor = (Color)btnOpenOrders.Tag;
		}
	}

	public void ShowOnlineOrderNotification(bool show)
	{
		timer_0.Enabled = show;
	}

	private void btnChangeCourse_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add(ItemCourses.Uncategorized, Resources.Uncategorized);
			dictionary.Add(ItemCourses.Appetizer, Resources.Appetizer);
			dictionary.Add(ItemCourses.Beverage, Resources.Beverage);
			dictionary.Add(ItemCourses.Dessert, Resources.Dessert);
			dictionary.Add(ItemCourses.Entree, Resources.Entree);
			dictionary.Add(ItemCourses.Side, Resources.Side);
			frmButtonSelector frmButtonSelector2 = new frmButtonSelector("Change Item Course", dictionary);
			if (frmButtonSelector2.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			ListViewDataItem listViewDataItem = radListItems.SelectedItems[0];
			ListViewDataItemGroup group = listViewDataItem.Group;
			if (radListItems.SelectedItems[0].SubItems[5].ToString() != "0")
			{
				listViewDataItem = radListItems.Items.Where((ListViewDataItem listViewDataItem_0) => listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString() && listViewDataItem_0.SubItems[16].ToString() == "MainItem").FirstOrDefault();
				listViewDataItem.Group = method_26(frmButtonSelector2.SelectedValue);
				foreach (ListViewDataItem item in radListItems.Items)
				{
					if (item.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString() && (item[1].ToString().Contains("ADD: ") || item[1].ToString().Contains("OPT: ") || item[1].ToString().Contains("SUB: ") || item.SubItems[16].ToString() == "ChildItem"))
					{
						item.Group = method_26(frmButtonSelector2.SelectedValue);
					}
				}
			}
			else
			{
				listViewDataItem.Group = method_26(frmButtonSelector2.SelectedValue);
			}
			if (group.Items.Count() == 0)
			{
				group.Visible = false;
			}
			isSaved = false;
			Button button = btnSaveClose;
			Button button2 = btnSaveOrder;
			ClearBtn.Enabled = true;
			button2.Enabled = true;
			button.Enabled = true;
		}
		else
		{
			new NotificationLabel(this, "Please select an item to change.", NotificationTypes.Notification).Show();
		}
	}

	private void btnOrdDiscount_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeAuthenticateControl(this, "btnOrderDiscount") == null)
		{
			return;
		}
		if (btnOrdDiscount.Text == Resources.ORDER_DISCOUNT)
		{
			frmDiscount frmDiscount2 = new frmDiscount(decimal_0, DiscountTypes.Order);
			if (frmDiscount2.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			foreach (ListViewDataItem item in radListItems.Items)
			{
				decimal num = Convert.ToDecimal(((item[2].ToString() == "") ? "0.00" : item[2].ToString()).RemoveAllNonNumeric());
				if (!(num < 0m))
				{
					decimal num2 = MathHelper.FractionToDecimal((item[0].ToString() == "") ? "1" : item[0].ToString());
					decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(item.SubItems[15].ToString(), DiscountTypes.Item);
					if (Math.Round(frmDiscount2.percentDiscount * num * num2, 4) + Math.Round(discountFromDiscountDescription, 4) > num * num2)
					{
						new NotificationLabel(this, "Cannot apply order discount, discount total for an item is greater than the item price.", NotificationTypes.Notification).Show();
						return;
					}
				}
			}
			bool_2 = true;
			btnOrdDiscount.Text = Resources.REMOVE_ORDER_DISCOUNT;
			bool_0 = true;
			string_0 = frmDiscount2.discountReason;
			string_1 = frmDiscount2.discountType;
			decimal_2 = frmDiscount2.percentDiscount;
			decimal_3 = frmDiscount2.tenderDiscount;
			isSaved = false;
			RecalculateTaxAndSubtotal();
		}
		else
		{
			bool_2 = true;
			btnOrdDiscount.Text = Resources.ORDER_DISCOUNT;
			bool_0 = false;
			string_0 = "";
			string_1 = "";
			decimal_2 = default(decimal);
			decimal_3 = default(decimal);
			isSaved = false;
			RecalculateTaxAndSubtotal();
			decimal_1 = default(decimal);
			new NotificationLabel(this, "Order Discount Removed.", NotificationTypes.Notification).Show();
		}
	}

	private void ClearBtn_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox((!string.IsNullOrEmpty(string_3)) ? "Are you sure you want to start order from Previously saved order?" : "Are you sure you want to start over?", "Start Over Order", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			if (!string.IsNullOrEmpty(string_3))
			{
				loadOrderByOrderNumber(string_3);
				return;
			}
			isSaved = true;
			method_34();
			method_4();
			method_6();
			Button button = btnSaveOrder;
			btnSaveClose.Enabled = false;
			button.Enabled = false;
		}
	}

	private void btnOrderDiscount_Click(object sender, EventArgs e)
	{
	}

	private void method_53(bool bool_30)
	{
		Button button = btnX2;
		Button button2 = btn3x;
		Button button3 = btn4x;
		Button button4 = btn5x;
		Button button5 = btn6x;
		Button button6 = btn7x;
		Button button7 = btn8x;
		bool flag2 = (btn9x.Enabled = bool_30);
		bool flag4 = (button7.Enabled = flag2);
		bool flag6 = (button6.Enabled = flag4);
		bool flag8 = (button5.Enabled = flag6);
		bool flag10 = (button4.Enabled = flag8);
		bool flag12 = (button3.Enabled = flag10);
		bool enabled = (button2.Enabled = flag12);
		button.Enabled = enabled;
	}

	private void btnX2_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void method_54(string string_16)
	{
		method_51(bool_30: false, Convert.ToDecimal(string_16));
	}

	private void btn3x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn4x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn5x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn6x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn7x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn8x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btn9x_Click(object sender, EventArgs e)
	{
		method_54(((Button)sender).Text.Remove(1, 1));
	}

	private void btnFire_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass224_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass224_0();
		GClass6 gClass = new GClass6();
		ListViewDataItem listViewDataItem = radListItems.SelectedItems[0];
		CS_0024_003C_003E8__locals0.itemId = Convert.ToInt32(listViewDataItem.SubItems[4].ToString());
		CS_0024_003C_003E8__locals0.item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.item == null)
		{
			return;
		}
		if (gClass.ItemCourses.Where((ItemCourse a) => a.Name == CS_0024_003C_003E8__locals0.item.ItemCourse).FirstOrDefault() != null)
		{
			_003C_003Ec__DisplayClass224_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass224_1();
			CS_0024_003C_003E8__locals1.itemComboId = Convert.ToInt32(listViewDataItem.SubItems[5].ToString());
			if (CS_0024_003C_003E8__locals1.itemComboId > 0)
			{
				foreach (ListViewDataItem item in radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals1.itemComboId.ToString()))
				{
					item.SubItems[14] = "-1";
				}
			}
			else
			{
				listViewDataItem.SubItems[14] = "-1";
			}
			new NotificationLabel(this, "Item sent to Station.", NotificationTypes.Success).Show();
			btnSaveOrder_Click(null, null);
		}
		else
		{
			new NotificationLabel(this, "Item Course not found.", NotificationTypes.Warning).Show();
		}
	}

	private void btnFire_VisibleChanged(object sender, EventArgs e)
	{
		int num = pnlQty.Height / 9;
		if (!btnFire.Visible)
		{
			num = pnlQty.Height / 8;
		}
		Button button = btnX2;
		Button button2 = btn3x;
		Button button3 = btn4x;
		Button button4 = btn5x;
		Button button5 = btn6x;
		Button button6 = btn7x;
		Button button7 = btn8x;
		Button button8 = btn9x;
		int num3 = (btnFire.Height = num);
		int num5 = (button8.Height = num3);
		int num7 = (button7.Height = num5);
		int num9 = (button6.Height = num7);
		int num11 = (button5.Height = num9);
		int num13 = (button4.Height = num11);
		int num15 = (button3.Height = num13);
		int num17 = (button2.Height = num15);
		button.Height = num17;
	}

	private void GglFeOneCle_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox("Do you want to Print Chit?", "Print Chit", CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes || !method_45())
		{
			return;
		}
		bool flag = true;
		if (btnSaveOrder.Enabled || !isSaved || bool_25)
		{
			flag = method_41(true, 0, bool_30: false);
		}
		if (!flag)
		{
			return;
		}
		method_32();
		loadOrderByOrderNumber(string_3);
		GClass6 gClass = new GClass6();
		OrderHelper orderHelper = new OrderHelper();
		new NotificationLabel(this, "Printing Chit", NotificationTypes.Success).Show();
		foreach (Station station in gClass.Stations)
		{
			orderHelper.PrintToStation(string_3, string_5, string_7 + " - " + string_4, station.StationID, lblEmployee.Text.Replace("EMPLOYEE: ", ""), isOrderMade: false, reprint: true, printOnlyOne: true, string_4);
		}
	}

	private void btnChangeComboItem_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0 && radListItems.SelectedItems[0] != null)
		{
			short num = Convert.ToInt16(radListItems.SelectedItems[0].SubItems[10].ToString());
			if (num > 0)
			{
				method_31(num);
			}
		}
	}

	private void btnLeft_Click(object sender, EventArgs e)
	{
		if ((btnSaveOrder.Enabled || !isSaved) && method_41(null, 6))
		{
			list_3.Add(string_3);
			list_3 = list_3.Distinct().ToList();
			Button button = btnSaveClose;
			Button button2 = btnSaveOrder;
			ClearBtn.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
			isSaved = true;
		}
		if (int_1 == 2 && list_3.Count == 1 && radListItems.Items.Where((ListViewDataItem a) => a.SubItems[6].ToString() == string.Empty).Count() == 0)
		{
			list_3.Clear();
		}
		int_1--;
		method_55(bool_30: false);
	}

	private void btnRight_Click(object sender, EventArgs e)
	{
		if ((btnSaveOrder.Enabled || !isSaved) && method_41(null, 6))
		{
			list_3.Add(string_3);
			list_3 = list_3.Distinct().ToList();
			Button button = btnSaveClose;
			Button button2 = btnSaveOrder;
			ClearBtn.Enabled = false;
			button2.Enabled = false;
			button.Enabled = false;
			isSaved = true;
			bool_5 = true;
		}
		int_1++;
		method_55(bool_30: true);
	}

	private void method_55(bool bool_30)
	{
		List<OrderResult> list = (from orderResult_0 in new OrderMethods().GetMultipleBills(string_4, OrderTypes.DineIn)
			where orderResult_0.DateCreated.AddDays(1.0) > DateTime.Now && orderResult_0.SeatNum == int_1
			select orderResult_0).ToList();
		if (list != null && list.Count > 0)
		{
			if (list.FirstOrDefault().isPaid)
			{
				if (bool_30)
				{
					int_1++;
					method_55(bool_30: true);
				}
				else if (int_1 == 1)
				{
					int_1++;
					method_55(bool_30: true);
				}
				else
				{
					int_1--;
					method_55(bool_30: false);
				}
			}
			else
			{
				string_3 = list.FirstOrDefault().OrderNumber;
				MemoryLoadedObjects.OrderEntry.LoadFormData(string_3, string_4, OrderTypes.DineIn, short_5, 0, string_7, "", resetComboId: false, (short)int_1);
				MemoryLoadedObjects.OrderEntry.Show();
			}
		}
		else
		{
			MemoryLoadedObjects.OrderEntry.LoadFormData(null, string_4, OrderTypes.DineIn, short_5, 0, string_7, "", resetComboId: false, (short)int_1);
			MemoryLoadedObjects.OrderEntry.Show();
		}
	}

	private void btnChangeFulfillment_Click(object sender, EventArgs e)
	{
		frmSelectDateAndTime frmSelectDateAndTime2 = new frmSelectDateAndTime("SELECT FULFILLMENT DATE", DateTime.Now.Date.AddDays(7.0), "", 5, dateFullfilment);
		if (frmSelectDateAndTime2.ShowDialog(this) == DialogResult.Cancel)
		{
			return;
		}
		DateTime dateTime = new DateTime(frmSelectDateAndTime2.returnDate.Year, frmSelectDateAndTime2.returnDate.Month, frmSelectDateAndTime2.returnDate.Day, frmSelectDateAndTime2.returnTime.Hour, frmSelectDateAndTime2.returnTime.Minute, frmSelectDateAndTime2.returnTime.Second);
		if (dateTime < DateTime.Now.AddMinutes(-1.0))
		{
			new NotificationLabel(this, "Date && Time selected is earlier than current time. Order will not be held.", NotificationTypes.Notification).Show();
			return;
		}
		if (dateTime.Date > DateTime.Now.Date.AddDays(7.0))
		{
			new NotificationLabel(this, "Fulfillment date can only be up to 7 Days in advanced.", NotificationTypes.Notification).Show();
			return;
		}
		bool flag = true;
		if (dateTime >= DateTime.Now)
		{
			_003C_003Ec__DisplayClass231_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass231_0();
			GClass6 gClass = new GClass6();
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			CS_0024_003C_003E8__locals0.dayOfWeek = currentCulture.DateTimeFormat.GetDayName(dateTime.DayOfWeek).ToString().ToUpper();
			DateTime date = dateTime.Date;
			DateTime date2 = dateTime.Date;
			bool flag2 = false;
			foreach (BusinessHour item in gClass.BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek.ToUpper() == CS_0024_003C_003E8__locals0.dayOfWeek))
			{
				date = Convert.ToDateTime(dateTime.ToLongDateString() + " " + item.LatestOpeningTime);
				date2 = Convert.ToDateTime(dateTime.ToLongDateString() + " " + item.LatestClosingTime);
				if (date2 < date)
				{
					date2 = date2.AddDays(1.0);
				}
				if (dateTime.TimeOfDay >= date.TimeOfDay && dateTime.TimeOfDay <= date2.TimeOfDay)
				{
					flag2 = true;
				}
			}
			if (!flag2 && new frmMessageBox("Store is closed during the Date && Time selected, proceed anyways?", "STORE CLOSED", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		if (!flag)
		{
			return;
		}
		dateFullfilment = dateTime;
		string text = ((dateTime.Date == DateTime.Now.Date) ? "today at " : dateTime.ToShortDateString()) + " " + dateTime.ToShortTimeString();
		new NotificationLabel(this, "Order fulfillment changed to " + text, NotificationTypes.Notification);
		orderOnHoldTime = (int)(dateTime - DateTime.Now).TotalMinutes;
		method_17();
		foreach (ListViewDataItem item2 in radListItems.Items)
		{
			item2.SubItems[14] = orderOnHoldTime.ToString();
		}
		isSaved = false;
		if (radListItems.Items.Count > 0)
		{
			Button button = btnSaveClose;
			btnSaveOrder.Enabled = true;
			button.Enabled = true;
		}
		else
		{
			Button button2 = btnSaveClose;
			btnSaveOrder.Enabled = false;
			button2.Enabled = false;
		}
	}

	private void btnOrderNotes_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + "Order Notes", 0, 128, string_9, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			string_9 = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void btnItemSub_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (lblSubstitutionMode.Visible)
		{
			radListItems.Enabled = true;
			lblSubstitutionMode.Visible = false;
			button.Text = Resources.ITEM_SUB;
			Button button2 = btnRemove;
			Button button3 = btnSaveOrder;
			Button button4 = btnSaveClose;
			Button button5 = btnPrintBill;
			Button gglFeOneCle = GglFeOneCle;
			Button button6 = btnSplitMergeBill;
			Class16 @class = btnOrderDiscount;
			Button button7 = btnInstructions;
			Button button8 = btnCustomerInfo;
			Button button9 = btnClear;
			Button dpoFeuYkxVM = DpoFeuYkxVM;
			Button button10 = btnPay;
			Button button11 = btnItemOptions;
			ClearBtn.Enabled = true;
			button11.Enabled = true;
			button10.Enabled = true;
			dpoFeuYkxVM.Enabled = true;
			button9.Enabled = true;
			button8.Enabled = true;
			button7.Enabled = true;
			@class.Enabled = true;
			button6.Enabled = true;
			gglFeOneCle.Enabled = true;
			button5.Enabled = true;
			button4.Enabled = true;
			button3.Enabled = true;
			button2.Enabled = true;
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
			{
				btnChangeGuests.Enabled = false;
			}
			else if (string_5 == OrderTypes.DineIn)
			{
				btnChangeGuests.Enabled = true;
			}
			else
			{
				btnChangeGuests.Enabled = false;
			}
			if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.DefaultOrderTypes.Split(',').Count() == 1)
			{
				DpoFeuYkxVM.Enabled = false;
			}
		}
		else if (radListItems.SelectedItems.Count > 0)
		{
			radListItems.Enabled = false;
			button.Text = Resources.CANCEL_ITEM_SUB;
			lblSubstitutionMode.Visible = true;
			Button button12 = btnRemove;
			Button button13 = btnSaveOrder;
			Button button14 = btnSaveClose;
			Button button15 = btnPrintBill;
			Button gglFeOneCle2 = GglFeOneCle;
			Button button16 = btnSplitMergeBill;
			Class16 class2 = btnOrderDiscount;
			Button button17 = btnInstructions;
			Button button18 = btnCustomerInfo;
			Button button19 = btnClear;
			Button dpoFeuYkxVM2 = DpoFeuYkxVM;
			Button button20 = btnPay;
			Button button21 = btnItemOptions;
			ClearBtn.Enabled = false;
			button21.Enabled = false;
			button20.Enabled = false;
			dpoFeuYkxVM2.Enabled = false;
			button19.Enabled = false;
			button18.Enabled = false;
			button17.Enabled = false;
			class2.Enabled = false;
			button16.Enabled = false;
			gglFeOneCle2.Enabled = false;
			button15.Enabled = false;
			button14.Enabled = false;
			button13.Enabled = false;
			button12.Enabled = false;
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_on_the_b0, NotificationTypes.Notification).Show();
		}
	}

	private void btnItemOptions_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count <= 0)
		{
			return;
		}
		if (radListItems.SelectedItems[0] != null)
		{
			_003C_003Ec__DisplayClass234_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass234_0();
			new GClass6();
			CS_0024_003C_003E8__locals0.itemID = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[4].ToString());
			CS_0024_003C_003E8__locals0.comboId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[5].ToString());
			CS_0024_003C_003E8__locals0.optionComboId = Convert.ToInt32(radListItems.SelectedItems[0].SubItems[11].ToString());
			decimal num = radListItems.SelectedItems[0][0].ToString().ToDecimalWithCleanUp();
			ListViewDataItem listViewDataItem = radListItems.SelectedItems[0];
			decimal num2 = Convert.ToDecimal((listViewDataItem[3].ToString() == "") ? "0" : listViewDataItem[3].ToString());
			if (radListItems.SelectedItems.Count <= 0)
			{
				return;
			}
			if ((from i in MemoryLoadedObjects.all_item_options
				where i.ItemID == CS_0024_003C_003E8__locals0.itemID && !i.ToBeDeleted && ((i.GroupID > 0 && i.OptionsGroupShowOrderEntry == true) || i.GroupID == 0)
				orderby i.SortOrder, i.ItemName
				select i).ToList().Count() > 0)
			{
				_003C_003Ec__DisplayClass234_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass234_1();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				decimal itemQty = MathHelper.FractionToDecimal(radListItems.SelectedItems[0][0].ToString());
				CS_0024_003C_003E8__locals2.itemName = radListItems.SelectedItems[0][1].ToString();
				List<SelectedOptionObject> list = new List<SelectedOptionObject>();
				foreach (ListViewDataItem item2 in radListItems.Items.Where((ListViewDataItem a) => a[1].ToString() != CS_0024_003C_003E8__locals2.itemName && a.SubItems[11].ToString() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.optionComboId.ToString() && !a.Font.Strikeout && a.SubItems[5].ToString() == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.comboId.ToString() && (a[1].ToString().Contains("ADD:") || a[1].ToString().Contains("OPT: "))))
				{
					string fraction = ((item2[0].ToString() == "") ? "1" : item2[0].ToString());
					decimal num3 = MathHelper.ToDecimal((item2[2].ToString() == "") ? "0.00" : item2[2].ToString());
					decimal num4 = MathHelper.ToDecimal((item2[3].ToString() == "") ? "0.00" : item2[3].ToString());
					decimal num5 = MathHelper.ToDecimal(item2.SubItems[8].ToString(), -1m);
					SelectedOptionObject item = new SelectedOptionObject
					{
						item_option_id = ((!string.IsNullOrEmpty(item2.SubItems[17].ToString())) ? Convert.ToInt32(item2.SubItems[17].ToString()) : 0),
						tag = ((!item2[1].ToString().Contains("[") || !item2[1].ToString().Contains("]")) ? "OPTIONS" : Regex.Match(item2[1].ToString().ToUpper().Replace("OPT: ", "")
							.Replace("ADD: ", "")
							.Replace("   ", ""), "\\[([^]]*)\\]").Groups[1].Value),
						item_name = Regex.Replace(Regex.Replace(item2[1].ToString().ToUpper().Replace("OPT: ", "")
							.Replace("ADD: ", "")
							.Replace("   ", ""), "(\\[.*\\])", "").Trim(), "(\\(.*\\)) ", ""),
						option_itemId = Convert.ToInt32(item2.SubItems[4].ToString().Trim()),
						price = ((num5 == -1m) ? num3 : num5),
						qty = MathHelper.FractionToDecimal(fraction),
						is_solo_group_option = ((num5 * num != num4) ? true : false)
					};
					list.Add(item);
				}
				List<SelectedOptionObject> list2 = new List<SelectedOptionObject>();
				decimal num6 = default(decimal);
				int num7 = (from x in MemoryLoadedObjects.all_item_options
					where !x.ToBeDeleted && x.ItemID == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0)
					select x into a
					group a by a.Tab).Count();
				using (List<SelectedOptionObject>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass234_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass234_2();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals2;
						CS_0024_003C_003E8__locals1.selOption = enumerator2.Current;
						usp_ItemOptionsResult usp_ItemOptionsResult = MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult a) => a.ItemWithOptionID == CS_0024_003C_003E8__locals1.selOption.item_option_id && ((a.GroupID > 0 && a.OptionsGroupShowOrderEntry == true) || a.GroupID == 0)).FirstOrDefault();
						if (usp_ItemOptionsResult == null && CS_0024_003C_003E8__locals1.selOption.item_option_id != 0)
						{
							usp_ItemOptionsResult = ((num7 <= 1) ? MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult x) => !x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == CS_0024_003C_003E8__locals1.selOption.option_itemId && x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID).FirstOrDefault() : MemoryLoadedObjects.all_item_options.Where((usp_ItemOptionsResult x) => !x.ToBeDeleted && ((x.GroupID > 0 && x.OptionsGroupShowOrderEntry == true) || x.GroupID == 0) && x.Option_ItemID == CS_0024_003C_003E8__locals1.selOption.option_itemId && x.ItemID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID && x.Tab.ToUpper() == CS_0024_003C_003E8__locals1.selOption.tag.ToUpper()).FirstOrDefault());
						}
						if (usp_ItemOptionsResult != null)
						{
							CS_0024_003C_003E8__locals1.selOption.item_option_id = usp_ItemOptionsResult.ItemWithOptionID;
							CS_0024_003C_003E8__locals1.selOption.tag = usp_ItemOptionsResult.Tab;
							CS_0024_003C_003E8__locals1.selOption.qtyPerOneValue = usp_ItemOptionsResult.Qty;
							CS_0024_003C_003E8__locals1.selOption.allow_additional = usp_ItemOptionsResult.AllowAdditional;
							CS_0024_003C_003E8__locals1.selOption.group_id = usp_ItemOptionsResult.GroupID;
							CS_0024_003C_003E8__locals1.selOption.item_option_id = usp_ItemOptionsResult.ItemWithOptionID;
							CS_0024_003C_003E8__locals1.selOption.dependent_group_id = usp_ItemOptionsResult.GroupDependency;
							CS_0024_003C_003E8__locals1.selOption.item_sortOrder = usp_ItemOptionsResult.OptionSortOrder;
							CS_0024_003C_003E8__locals1.selOption.group_sortOrder = (usp_ItemOptionsResult.GroupSortOrder.HasValue ? usp_ItemOptionsResult.GroupSortOrder.Value : 0);
							CS_0024_003C_003E8__locals1.selOption.max_free_group_opt = usp_ItemOptionsResult.MaxFreeOptionPerGroup;
							CS_0024_003C_003E8__locals1.selOption.is_solo_group_option = ((usp_ItemOptionsResult.MaxGroupOptions == 1 && usp_ItemOptionsResult.MinGroupOptions == 1) ? true : false);
							if (!(usp_ItemOptionsResult.Qty == 0m))
							{
								if (CS_0024_003C_003E8__locals1.selOption.qty + num6 < usp_ItemOptionsResult.Qty && CS_0024_003C_003E8__locals1.selOption.price == 0m)
								{
									list2.Add(CS_0024_003C_003E8__locals1.selOption);
								}
								num6 += CS_0024_003C_003E8__locals1.selOption.qty;
								if (num6 == usp_ItemOptionsResult.Qty && usp_ItemOptionsResult.Qty >= 1m)
								{
									CS_0024_003C_003E8__locals1.selOption.qty = num6;
									CS_0024_003C_003E8__locals1.selOption.price = num6 * CS_0024_003C_003E8__locals1.selOption.price;
									num6 = default(decimal);
								}
							}
						}
						else
						{
							list2.Add(CS_0024_003C_003E8__locals1.selOption);
						}
					}
				}
				foreach (SelectedOptionObject item3 in list2)
				{
					list.Remove(item3);
				}
				bool newItem = false;
				if (list.Count == 0)
				{
					newItem = true;
				}
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OptionScreen();
				MemoryLoadedObjects.OptionScreen.courseGroup = listViewDataItem.Group;
				MemoryLoadedObjects.OptionScreen.LoadForm(CS_0024_003C_003E8__locals2.itemName, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID, itemQty, radListItems.SelectedIndex, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.optionComboId, this, string_5, list, newItem);
				MemoryLoadedObjects.OptionScreen.ShowDialog(this);
				string text = listViewDataItem.SubItems[15].ToString();
				if (!string.IsNullOrEmpty(text) && text.Contains(DiscountTypes.Item))
				{
					listViewDataItem.SubItems[13].ToString();
					decimal num8 = Convert.ToDecimal(listViewDataItem[3].ToString());
					if (num8 != num2)
					{
						decimal num9 = OrderHelper.GetDiscountFromDiscountDescription(text, DiscountTypes.Item) / num2;
						text = OrderHelper.UpdateDiscountFromDiscountDescription(text, DiscountTypes.Item, num8 * num9);
						listViewDataItem.SubItems[15] = text;
						RecalculateTaxAndSubtotal();
					}
				}
				Button button = btnSaveOrder;
				Button button2 = btnSaveClose;
				ClearBtn.Enabled = true;
				button2.Enabled = true;
				button.Enabled = true;
				CloneListviewToSecondScreen();
			}
			else
			{
				new NotificationLabel(this, Resources.Please_select_the_main_combo_i, NotificationTypes.Notification).Show();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_item_first, NotificationTypes.Notification).Show();
		}
	}

	private void btnSearchItems_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass235_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass235_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search_Items, 2);
		CS_0024_003C_003E8__locals0.keyboard = MemoryLoadedObjects.Keyboard;
		if (CS_0024_003C_003E8__locals0.keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		new GClass6();
		short_0 = 1;
		list_4 = MemoryLoadedData.all_active_items.Where((Item i) => i.ItemName.ToLower().Contains(CS_0024_003C_003E8__locals0.keyboard.textEntered.ToLower()) && i.Active && !i.isDeleted && i.ItemClassification == ItemClassifications.Product).ToList();
		IQueryable<Item> source = from i in dataManager_0.DataContext.ItemCustomFieldValues
			where (i.CustomField.Value.Contains(CS_0024_003C_003E8__locals0.keyboard.textEntered) || i.Value.Contains(CS_0024_003C_003E8__locals0.keyboard.textEntered)) && i.Item.Active == true && i.Item.isDeleted == false && i.Item.ItemClassification == ItemClassifications.Product
			select i.Item;
		list_4 = (from i in list_4.Union(source.Where((Item x) => !list_4.Select((Item y) => y.ItemID).Contains(x.ItemID)))
			orderby i.ItemName
			select i).ToList();
		lblItemsHeader.Text = Resources.Items_for0 + CS_0024_003C_003E8__locals0.keyboard.textEntered + "'";
		string_2 = string.Empty;
		method_22();
	}

	private void pnlItems_Paint(object sender, PaintEventArgs e)
	{
	}

	private void txtBarcodeSearch_TextChanged(object sender, EventArgs e)
	{
	}

	private void method_56(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search_Items, 3);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		string textEntered = MemoryLoadedObjects.Keyboard.textEntered;
		if (button_0 != null)
		{
			button_0.BackColor = Color.FromArgb(150, 166, 166);
		}
		lblItemsHeader.Text = Resources.Items_Search_Results;
		_ = ((Button)sender).Text;
		pnlItems.Controls.Clear();
		foreach (Item item in (from i in dataManager_0.getAllItems(textEntered)
			orderby i.SortOrder
			select i).ToList())
		{
			Color color = HelperMethods.GetColor(item.ItemColor);
			if (item.ItemName.Contains("&"))
			{
				item.ItemName = item.ItemName.Replace("&", "&&");
			}
			Button value = method_10(item.ItemName, color, item.ItemID.ToString(), method_25, bool_30: true);
			pnlItems.Controls.Add(value);
			if (!dictionary_0.ContainsKey(item.ItemID))
			{
				dictionary_0.Add(item.ItemID, item);
			}
		}
	}

	private void method_57()
	{
		if (radListItems.Items.Where((ListViewDataItem a) => a[1].ToString().ToUpper() != "DELIVERY FEE").ToList().Count > 0)
		{
			btnPay.Enabled = true;
			if (frmMasterForm.lockedControls == null)
			{
				frmMasterForm.lockedControls = new List<LockedControl>();
			}
			btnOrderDiscount.Enabled = true;
			btnPrintBill.Enabled = true;
			btnSplitMergeBill.Enabled = true;
			if (radListItems.Items.Where((ListViewDataItem a) => !string.IsNullOrEmpty(a.SubItems[6].ToString())).Count() > 0)
			{
				GglFeOneCle.Enabled = true;
			}
			else
			{
				GglFeOneCle.Enabled = false;
			}
		}
		else
		{
			btnPay.Enabled = false;
			btnOrderDiscount.Enabled = false;
			btnChangeQty.Enabled = false;
			btnFire.Enabled = false;
			method_53(bool_30: false);
			btnChangePrice.Enabled = false;
			btnSplitMergeBill.Enabled = false;
			Button button = btnPrintBill;
			GglFeOneCle.Enabled = false;
			button.Enabled = false;
		}
	}

	private void txtBarcodeSearch_GotFocus(object sender, EventArgs e)
	{
		if (txtBarcodeSearch.Text == Resources.Click_here_to_start_scanning_p)
		{
			txtBarcodeSearch.ForeColor = HelperMethods.GetColor("Black");
			txtBarcodeSearch.Text = string.Empty;
		}
	}

	private void txtBarcodeSearch_LostFocus(object sender, EventArgs e)
	{
		if (txtBarcodeSearch.Text == string.Empty)
		{
			txtBarcodeSearch.ForeColor = HelperMethods.GetColor("Gray");
			txtBarcodeSearch.Text = Resources.Click_here_to_start_scanning_p;
		}
	}

	private void txtBarcodeSearch_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Return)
		{
			return;
		}
		if (string.IsNullOrEmpty(txtBarcodeSearch.Text))
		{
			new frmMessageBox(Resources.The_barcode_field_is_blank_Ple).ShowDialog(this);
			return;
		}
		new GClass6();
		txtBarcodeSearch.Text = txtBarcodeSearch.Text.Trim();
		Item item = MemoryLoadedData.all_active_items.Where((Item item_0) => item_0.Barcode == txtBarcodeSearch.Text).FirstOrDefault();
		if (item == null)
		{
			_003C_003Ec__DisplayClass242_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass242_0();
			CS_0024_003C_003E8__locals0.bc = txtBarcodeSearch.Text;
			string value = "0";
			if (txtBarcodeSearch.Text.Length == 13)
			{
				CS_0024_003C_003E8__locals0.bc = txtBarcodeSearch.Text.Substring(1, 6);
				value = txtBarcodeSearch.Text.Substring(7, 5);
			}
			else if (txtBarcodeSearch.Text.Length == 12)
			{
				CS_0024_003C_003E8__locals0.bc = txtBarcodeSearch.Text.Substring(0, 6);
				value = txtBarcodeSearch.Text.Substring(6, 5);
			}
			if (CS_0024_003C_003E8__locals0.bc != txtBarcodeSearch.Text)
			{
				item = MemoryLoadedData.all_active_items.Where((Item b) => b.UseSmartBarcode && CS_0024_003C_003E8__locals0.bc == b.Barcode).FirstOrDefault();
			}
			if (item == null)
			{
				new NotificationLabel(this, Resources.Item_not_found0, NotificationTypes.Warning).Show();
				txtBarcodeSearch.Text = string.Empty;
				return;
			}
			megFrVxorYX(item.ItemID, item.ItemName, Convert.ToDecimal(value) / 100m);
		}
		else
		{
			megFrVxorYX(item.ItemID, item.ItemName);
		}
		txtBarcodeSearch.Text = string.Empty;
		e.SuppressKeyPress = true;
		e.Handled = true;
	}

	public void HideOrderEntry(bool forceNotLogout = false)
	{
		bool flag = false;
		if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF")
		{
			Application.OpenForms.OfType<frmQuickServiceListView>().FirstOrDefault();
			frmQuickService frmQuickService2 = Application.OpenForms.OfType<frmQuickService>().FirstOrDefault();
			flag = (frmQuickService2 == null || !frmQuickService2.Visible) && ((frmQuickService2 == null || !frmQuickService2.Visible) ? true : false);
		}
		else if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In" && SettingsHelper.GetSettingValueByKey("auto_logout_oe").ToUpper() == "ON")
		{
			flag = true;
		}
		if (forceNotLogout)
		{
			flag = false;
		}
		if (flag)
		{
			AuthMethods.LogOutUser();
		}
		method_34();
		Close();
	}

	public void CloneListviewToSecondScreen()
	{
		if (MemoryLoadedObjects.OrderEntrySecondScreen == null || radListItems.Items.Count < MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count)
		{
			return;
		}
		int num = 0;
		foreach (ListViewDataItem item in radListItems.Items)
		{
			_ = item;
			if (num < MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Count)
			{
				for (int i = 0; i < 7; i++)
				{
					if (i <= 3)
					{
						MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items[num][i] = radListItems.Items[num][i].ToString();
					}
					else
					{
						MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items[num][i] = radListItems.Items[num].SubItems[i].ToString();
					}
				}
				MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items[num].Font = radListItems.Items[num].Font;
				MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items[num].ForeColor = radListItems.Items[num].ForeColor;
			}
			else
			{
				string[] values = new string[7]
				{
					radListItems.Items[num][0].ToString(),
					radListItems.Items[num][1].ToString(),
					radListItems.Items[num][2].ToString(),
					radListItems.Items[num][3].ToString(),
					radListItems.Items[num].SubItems[4].ToString(),
					radListItems.Items[num].SubItems[5].ToString(),
					radListItems.Items[num].SubItems[6].ToString()
				};
				ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
				listViewDataItem.Font = radListItems.Items[num].Font;
				listViewDataItem.ForeColor = radListItems.Items[num].ForeColor;
				MemoryLoadedObjects.OrderEntrySecondScreen.radListItemsSecond.Items.Add(listViewDataItem);
			}
			num++;
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		base.OnFormClosing(e);
		if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.None)
		{
			e.Cancel = true;
			Hide();
		}
	}

	private void method_58()
	{
		if (!string.IsNullOrEmpty(string_7) && string_5 != OrderTypes.DineIn)
		{
			lblCustomer.Text = string_7;
			lblSeat.Text = string_4;
			lblSeat.Visible = true;
			return;
		}
		lblCustomer.Text = string_4;
		if (!string.IsNullOrEmpty(string_7) && string_5 == OrderTypes.DineIn && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service")
		{
			lblCustomer.Text = string_7;
		}
		else if (string.IsNullOrEmpty(string_7) && string_5 != OrderTypes.DineIn)
		{
			lblSeat.Text = "";
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmOrderEntry));
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "Qty");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Item Name");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 2", "Price");
		ListViewDetailColumn listViewDetailColumn4 = new ListViewDetailColumn("Column 3", "Ext. Price");
		lblTotal = new Label();
		lblTotalTax = new Label();
		lblSubTotal = new Label();
		btnCustomerInfo = new Button();
		lblSubstitutionMode = new Label();
		lblTrainingMode = new Label();
		btnSplitMergeBill = new Button();
		btnPrintBill = new Button();
		lblEmployee = new Label();
		btnChangeGuests = new Button();
		lblCustomer = new Label();
		pictureBox1 = new PictureBox();
		lblOrderType = new Label();
		btnSearchItems = new Button();
		label2 = new Label();
		label1 = new Label();
		pnlNav = new FlowLayoutPanel();
		btnPay = new Button();
		btnOrderDiscount = new Class16();
		btnRemove = new Button();
		ClearBtn = new Button();
		btnInstructions = new Button();
		btnItemSub = new Button();
		btnItemOptions = new Button();
		btnChangeComboItem = new Button();
		btnChangeQty = new Button();
		btnChangePrice = new Button();
		btnClear = new Button();
		DpoFeuYkxVM = new Button();
		btnSaveOrder = new Button();
		btnSaveClose = new Button();
		btnClose = new Button();
		label7 = new Label();
		label8 = new Label();
		lblCategories = new Label();
		lblItemsHeader = new Label();
		pnlGroups = new FlowLayoutPanel();
		pnlItems = new FlowLayoutPanel();
		Label3 = new Label();
		label4 = new Label();
		label5 = new Label();
		lblDiscount = new Label();
		label9 = new Label();
		lblSeat = new Label();
		picItemInfo = new PictureBox();
		txtBarcodeSearch = new RadTextBoxControl();
		pnlTotals = new Panel();
		lblOrderNumber = new Label();
		btnChangeCourse = new Button();
		picLock = new PictureBox();
		picTrash = new PictureBox();
		radListItems = new CustomListViewTelerik();
		verticalScrollControl1 = new VerticalScrollControl();
		pageSetupDialog_0 = new PageSetupDialog();
		btnOpenOrders = new Button();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		timer_1 = new System.Windows.Forms.Timer(icontainer_1);
		pnlQty = new FlowLayoutPanel();
		btnFire = new Button();
		btnX2 = new Button();
		btn3x = new Button();
		btn4x = new Button();
		btn5x = new Button();
		btn6x = new Button();
		btn7x = new Button();
		btn8x = new Button();
		btn9x = new Button();
		GglFeOneCle = new Button();
		pnlChangeSeat = new Panel();
		btnLeft = new Button();
		lblTableSeatName = new Label();
		btnRight = new Button();
		btnChangeFulfillment = new Button();
		btnOrderNotes = new Button();
		((ISupportInitialize)pictureBox1).BeginInit();
		pnlNav.SuspendLayout();
		((ISupportInitialize)picItemInfo).BeginInit();
		((ISupportInitialize)txtBarcodeSearch).BeginInit();
		pnlTotals.SuspendLayout();
		((ISupportInitialize)picLock).BeginInit();
		((ISupportInitialize)picTrash).BeginInit();
		((ISupportInitialize)radListItems).BeginInit();
		pnlQty.SuspendLayout();
		pnlChangeSeat.SuspendLayout();
		SuspendLayout();
		lblTotal.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(lblTotal, "lblTotal");
		lblTotal.ForeColor = Color.Black;
		lblTotal.Name = "lblTotal";
		lblTotalTax.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(lblTotalTax, "lblTotalTax");
		lblTotalTax.ForeColor = Color.Black;
		lblTotalTax.Name = "lblTotalTax";
		lblSubTotal.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(lblSubTotal, "lblSubTotal");
		lblSubTotal.ForeColor = Color.Black;
		lblSubTotal.Name = "lblSubTotal";
		componentResourceManager.ApplyResources(btnCustomerInfo, "btnCustomerInfo");
		btnCustomerInfo.BackColor = Color.FromArgb(65, 168, 95);
		btnCustomerInfo.FlatAppearance.BorderColor = Color.Black;
		btnCustomerInfo.FlatAppearance.BorderSize = 0;
		btnCustomerInfo.FlatAppearance.MouseDownBackColor = Color.White;
		btnCustomerInfo.ForeColor = Color.White;
		btnCustomerInfo.Name = "btnCustomerInfo";
		btnCustomerInfo.UseVisualStyleBackColor = false;
		btnCustomerInfo.EnabledChanged += btnRight_EnabledChanged;
		btnCustomerInfo.Click += btnCustomerInfo_Click;
		componentResourceManager.ApplyResources(lblSubstitutionMode, "lblSubstitutionMode");
		lblSubstitutionMode.BackColor = Color.FromArgb(193, 57, 43);
		lblSubstitutionMode.ForeColor = Color.White;
		lblSubstitutionMode.Name = "lblSubstitutionMode";
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(btnSplitMergeBill, "btnSplitMergeBill");
		btnSplitMergeBill.BackColor = Color.FromArgb(117, 81, 147);
		btnSplitMergeBill.FlatAppearance.BorderColor = Color.Black;
		btnSplitMergeBill.FlatAppearance.BorderSize = 0;
		btnSplitMergeBill.FlatAppearance.MouseDownBackColor = Color.White;
		btnSplitMergeBill.ForeColor = Color.White;
		btnSplitMergeBill.Name = "btnSplitMergeBill";
		btnSplitMergeBill.UseVisualStyleBackColor = false;
		btnSplitMergeBill.EnabledChanged += btnRight_EnabledChanged;
		btnSplitMergeBill.Click += btnSplitMergeBill_Click;
		componentResourceManager.ApplyResources(btnPrintBill, "btnPrintBill");
		btnPrintBill.BackColor = Color.FromArgb(214, 142, 81);
		btnPrintBill.FlatAppearance.BorderColor = Color.Black;
		btnPrintBill.FlatAppearance.BorderSize = 0;
		btnPrintBill.FlatAppearance.MouseDownBackColor = Color.White;
		btnPrintBill.ForeColor = Color.White;
		btnPrintBill.Name = "btnPrintBill";
		btnPrintBill.UseVisualStyleBackColor = false;
		btnPrintBill.EnabledChanged += btnRight_EnabledChanged;
		btnPrintBill.Click += btnPrintBill_Click;
		lblEmployee.BackColor = Color.FromArgb(47, 204, 113);
		componentResourceManager.ApplyResources(lblEmployee, "lblEmployee");
		lblEmployee.ForeColor = Color.White;
		lblEmployee.Name = "lblEmployee";
		componentResourceManager.ApplyResources(btnChangeGuests, "btnChangeGuests");
		btnChangeGuests.BackColor = Color.FromArgb(53, 152, 220);
		btnChangeGuests.FlatAppearance.BorderColor = Color.Black;
		btnChangeGuests.FlatAppearance.BorderSize = 0;
		btnChangeGuests.FlatAppearance.MouseDownBackColor = Color.White;
		btnChangeGuests.ForeColor = Color.White;
		btnChangeGuests.Name = "btnChangeGuests";
		btnChangeGuests.UseVisualStyleBackColor = false;
		btnChangeGuests.EnabledChanged += btnRight_EnabledChanged;
		btnChangeGuests.Click += btnChangeGuests_Click;
		lblCustomer.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblCustomer, "lblCustomer");
		lblCustomer.ForeColor = Color.SandyBrown;
		lblCustomer.Name = "lblCustomer";
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		lblOrderType.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblOrderType, "lblOrderType");
		lblOrderType.ForeColor = Color.SandyBrown;
		lblOrderType.Name = "lblOrderType";
		componentResourceManager.ApplyResources(btnSearchItems, "btnSearchItems");
		btnSearchItems.BackColor = Color.FromArgb(53, 152, 220);
		btnSearchItems.FlatAppearance.BorderColor = Color.Sienna;
		btnSearchItems.FlatAppearance.BorderSize = 0;
		btnSearchItems.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearchItems.ForeColor = Color.White;
		btnSearchItems.Name = "btnSearchItems";
		btnSearchItems.UseVisualStyleBackColor = false;
		btnSearchItems.Click += btnSearchItems_Click;
		label2.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label1.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(pnlNav, "pnlNav");
		pnlNav.BackColor = Color.Transparent;
		pnlNav.Controls.Add(btnPay);
		pnlNav.Controls.Add(btnOrderDiscount);
		pnlNav.Controls.Add(btnRemove);
		pnlNav.Controls.Add(ClearBtn);
		pnlNav.Controls.Add(btnInstructions);
		pnlNav.Controls.Add(btnItemSub);
		pnlNav.Controls.Add(btnItemOptions);
		pnlNav.Controls.Add(btnChangeComboItem);
		pnlNav.Controls.Add(btnChangeQty);
		pnlNav.Controls.Add(btnChangePrice);
		pnlNav.Controls.Add(btnClear);
		pnlNav.Controls.Add(DpoFeuYkxVM);
		pnlNav.Controls.Add(btnSaveOrder);
		pnlNav.Controls.Add(btnSaveClose);
		pnlNav.Controls.Add(btnClose);
		pnlNav.Name = "pnlNav";
		btnPay.BackColor = Color.FromArgb(80, 203, 116);
		btnPay.FlatAppearance.BorderColor = Color.Black;
		btnPay.FlatAppearance.BorderSize = 0;
		btnPay.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnPay, "btnPay");
		btnPay.ForeColor = Color.White;
		btnPay.Name = "btnPay";
		btnPay.Tag = "";
		btnPay.UseVisualStyleBackColor = false;
		btnPay.EnabledChanged += btnRight_EnabledChanged;
		btnPay.Click += btnPay_Click;
		btnOrderDiscount.BackColor = Color.FromArgb(176, 124, 219);
		btnOrderDiscount.FlatAppearance.BorderColor = Color.Sienna;
		btnOrderDiscount.FlatAppearance.BorderSize = 0;
		btnOrderDiscount.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnOrderDiscount, "btnOrderDiscount");
		btnOrderDiscount.ForeColor = Color.White;
		btnOrderDiscount.Name = "btnOrderDiscount";
		btnOrderDiscount.UseVisualStyleBackColor = false;
		btnOrderDiscount.EnabledChanged += btnRight_EnabledChanged;
		btnOrderDiscount.Click += btnOrderDiscount_Click;
		btnRemove.BackColor = Color.SandyBrown;
		btnRemove.FlatAppearance.BorderColor = Color.Black;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnRemove, "btnRemove");
		btnRemove.ForeColor = Color.White;
		btnRemove.Name = "btnRemove";
		btnRemove.UseVisualStyleBackColor = false;
		btnRemove.EnabledChanged += btnRight_EnabledChanged;
		btnRemove.Click += btnRemove_Click;
		ClearBtn.BackColor = Color.FromArgb(213, 84, 1);
		componentResourceManager.ApplyResources(ClearBtn, "ClearBtn");
		ClearBtn.FlatAppearance.BorderColor = Color.Black;
		ClearBtn.FlatAppearance.BorderSize = 0;
		ClearBtn.FlatAppearance.MouseDownBackColor = Color.White;
		ClearBtn.ForeColor = Color.White;
		ClearBtn.Name = "ClearBtn";
		ClearBtn.UseVisualStyleBackColor = false;
		ClearBtn.EnabledChanged += btnRight_EnabledChanged;
		ClearBtn.Click += ClearBtn_Click;
		btnInstructions.BackColor = Color.FromArgb(53, 152, 220);
		btnInstructions.FlatAppearance.BorderColor = Color.Sienna;
		btnInstructions.FlatAppearance.BorderSize = 0;
		btnInstructions.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnInstructions, "btnInstructions");
		btnInstructions.ForeColor = Color.White;
		btnInstructions.Name = "btnInstructions";
		btnInstructions.UseVisualStyleBackColor = false;
		btnInstructions.EnabledChanged += btnRight_EnabledChanged;
		btnInstructions.Click += btnInstructions_Click;
		btnItemSub.BackColor = Color.FromArgb(61, 142, 185);
		componentResourceManager.ApplyResources(btnItemSub, "btnItemSub");
		btnItemSub.FlatAppearance.BorderColor = Color.Black;
		btnItemSub.FlatAppearance.BorderSize = 0;
		btnItemSub.FlatAppearance.MouseDownBackColor = Color.White;
		btnItemSub.ForeColor = Color.White;
		btnItemSub.Name = "btnItemSub";
		btnItemSub.UseVisualStyleBackColor = false;
		btnItemSub.EnabledChanged += btnRight_EnabledChanged;
		btnItemSub.Click += btnItemSub_Click;
		btnItemOptions.BackColor = Color.FromArgb(50, 119, 155);
		btnItemOptions.FlatAppearance.BorderColor = Color.Black;
		btnItemOptions.FlatAppearance.BorderSize = 0;
		btnItemOptions.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnItemOptions, "btnItemOptions");
		btnItemOptions.ForeColor = Color.White;
		btnItemOptions.Name = "btnItemOptions";
		btnItemOptions.UseVisualStyleBackColor = false;
		btnItemOptions.EnabledChanged += btnRight_EnabledChanged;
		btnItemOptions.Click += btnItemOptions_Click;
		btnChangeComboItem.BackColor = Color.FromArgb(53, 152, 220);
		btnChangeComboItem.FlatAppearance.BorderColor = Color.Black;
		btnChangeComboItem.FlatAppearance.BorderSize = 0;
		btnChangeComboItem.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnChangeComboItem, "btnChangeComboItem");
		btnChangeComboItem.ForeColor = Color.White;
		btnChangeComboItem.Name = "btnChangeComboItem";
		btnChangeComboItem.UseVisualStyleBackColor = false;
		btnChangeComboItem.Click += btnChangeComboItem_Click;
		btnChangeQty.BackColor = Color.FromArgb(176, 124, 219);
		btnChangeQty.FlatAppearance.BorderColor = Color.Black;
		btnChangeQty.FlatAppearance.BorderSize = 0;
		btnChangeQty.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnChangeQty, "btnChangeQty");
		btnChangeQty.ForeColor = Color.White;
		btnChangeQty.Name = "btnChangeQty";
		btnChangeQty.UseVisualStyleBackColor = false;
		btnChangeQty.EnabledChanged += btnRight_EnabledChanged;
		btnChangeQty.Click += btnChangeQty_Click;
		btnChangePrice.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(btnChangePrice, "btnChangePrice");
		btnChangePrice.FlatAppearance.BorderColor = Color.Sienna;
		btnChangePrice.FlatAppearance.BorderSize = 0;
		btnChangePrice.FlatAppearance.MouseDownBackColor = Color.White;
		btnChangePrice.ForeColor = Color.White;
		btnChangePrice.Name = "btnChangePrice";
		btnChangePrice.UseVisualStyleBackColor = false;
		btnChangePrice.EnabledChanged += btnRight_EnabledChanged;
		btnChangePrice.Click += btnChangePrice_Click;
		btnClear.BackColor = Color.FromArgb(214, 142, 81);
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.FlatAppearance.BorderColor = Color.Black;
		btnClear.FlatAppearance.BorderSize = 0;
		btnClear.FlatAppearance.MouseDownBackColor = Color.White;
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.EnabledChanged += btnRight_EnabledChanged;
		btnClear.Click += btnClear_Click;
		DpoFeuYkxVM.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(DpoFeuYkxVM, "btnChangeTable");
		DpoFeuYkxVM.FlatAppearance.BorderColor = Color.Black;
		DpoFeuYkxVM.FlatAppearance.BorderSize = 0;
		DpoFeuYkxVM.FlatAppearance.MouseDownBackColor = Color.White;
		DpoFeuYkxVM.ForeColor = Color.White;
		DpoFeuYkxVM.Name = "btnChangeTable";
		DpoFeuYkxVM.UseVisualStyleBackColor = false;
		DpoFeuYkxVM.EnabledChanged += btnRight_EnabledChanged;
		DpoFeuYkxVM.Click += DpoFeuYkxVM_Click;
		btnSaveOrder.BackColor = Color.FromArgb(176, 124, 219);
		componentResourceManager.ApplyResources(btnSaveOrder, "btnSaveOrder");
		btnSaveOrder.FlatAppearance.BorderColor = Color.Black;
		btnSaveOrder.FlatAppearance.BorderSize = 0;
		btnSaveOrder.FlatAppearance.MouseDownBackColor = Color.White;
		btnSaveOrder.ForeColor = Color.White;
		btnSaveOrder.Name = "btnSaveOrder";
		btnSaveOrder.UseVisualStyleBackColor = false;
		btnSaveOrder.EnabledChanged += btnRight_EnabledChanged;
		btnSaveOrder.Click += btnSaveOrder_Click;
		btnSaveClose.BackColor = Color.FromArgb(65, 168, 95);
		componentResourceManager.ApplyResources(btnSaveClose, "btnSaveClose");
		btnSaveClose.FlatAppearance.BorderColor = Color.Black;
		btnSaveClose.FlatAppearance.BorderSize = 0;
		btnSaveClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnSaveClose.ForeColor = Color.White;
		btnSaveClose.Name = "btnSaveClose";
		btnSaveClose.UseVisualStyleBackColor = false;
		btnSaveClose.EnabledChanged += btnRight_EnabledChanged;
		btnSaveClose.Click += btnSaveClose_Click;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.EnabledChanged += btnRight_EnabledChanged;
		btnClose.Click += btnClose_Click;
		label7.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		label8.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(lblCategories, "lblCategories");
		lblCategories.BackColor = Color.FromArgb(65, 168, 95);
		lblCategories.ForeColor = Color.White;
		lblCategories.Name = "lblCategories";
		componentResourceManager.ApplyResources(lblItemsHeader, "lblItemsHeader");
		lblItemsHeader.BackColor = Color.FromArgb(80, 203, 116);
		lblItemsHeader.ForeColor = Color.White;
		lblItemsHeader.Name = "lblItemsHeader";
		componentResourceManager.ApplyResources(pnlGroups, "pnlGroups");
		pnlGroups.BackColor = Color.Transparent;
		pnlGroups.Name = "pnlGroups";
		componentResourceManager.ApplyResources(pnlItems, "pnlItems");
		pnlItems.BackColor = Color.Transparent;
		pnlItems.Name = "pnlItems";
		pnlItems.Paint += pnlItems_Paint;
		Label3.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(Label3, "Label3");
		Label3.ForeColor = Color.White;
		Label3.Name = "Label3";
		label4.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label5.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		lblDiscount.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(lblDiscount, "lblDiscount");
		lblDiscount.ForeColor = Color.Black;
		lblDiscount.Name = "lblDiscount";
		label9.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		lblSeat.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblSeat, "lblSeat");
		lblSeat.ForeColor = Color.SandyBrown;
		lblSeat.Name = "lblSeat";
		picItemInfo.BackColor = Color.FromArgb(80, 203, 116);
		componentResourceManager.ApplyResources(picItemInfo, "picItemInfo");
		picItemInfo.Name = "picItemInfo";
		picItemInfo.TabStop = false;
		picItemInfo.Click += picItemInfo_Click;
		componentResourceManager.ApplyResources(txtBarcodeSearch, "txtBarcodeSearch");
		txtBarcodeSearch.ForeColor = Color.Gray;
		txtBarcodeSearch.Name = "txtBarcodeSearch";
		txtBarcodeSearch.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtBarcodeSearch.TextChanged += txtBarcodeSearch_TextChanged;
		txtBarcodeSearch.GotFocus += txtBarcodeSearch_GotFocus;
		txtBarcodeSearch.KeyDown += txtBarcodeSearch_KeyDown;
		txtBarcodeSearch.LostFocus += txtBarcodeSearch_LostFocus;
		((RadTextBoxControlElement)txtBarcodeSearch.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtBarcodeSearch.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(pnlTotals, "pnlTotals");
		pnlTotals.Controls.Add(lblOrderNumber);
		pnlTotals.Controls.Add(btnChangeCourse);
		pnlTotals.Controls.Add(picLock);
		pnlTotals.Controls.Add(picTrash);
		pnlTotals.Controls.Add(lblTotal);
		pnlTotals.Controls.Add(label5);
		pnlTotals.Controls.Add(lblSeat);
		pnlTotals.Controls.Add(label4);
		pnlTotals.Controls.Add(lblDiscount);
		pnlTotals.Controls.Add(Label3);
		pnlTotals.Controls.Add(label9);
		pnlTotals.Controls.Add(lblOrderType);
		pnlTotals.Controls.Add(pictureBox1);
		pnlTotals.Controls.Add(lblTotalTax);
		pnlTotals.Controls.Add(lblCustomer);
		pnlTotals.Controls.Add(lblSubTotal);
		pnlTotals.Controls.Add(lblEmployee);
		pnlTotals.Name = "pnlTotals";
		lblOrderNumber.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblOrderNumber, "lblOrderNumber");
		lblOrderNumber.ForeColor = Color.SandyBrown;
		lblOrderNumber.Name = "lblOrderNumber";
		componentResourceManager.ApplyResources(btnChangeCourse, "btnChangeCourse");
		btnChangeCourse.BackColor = Color.FromArgb(255, 192, 128);
		btnChangeCourse.FlatAppearance.BorderColor = Color.White;
		btnChangeCourse.FlatAppearance.BorderSize = 0;
		btnChangeCourse.FlatAppearance.MouseDownBackColor = Color.White;
		btnChangeCourse.ForeColor = Color.Black;
		btnChangeCourse.Name = "btnChangeCourse";
		btnChangeCourse.UseVisualStyleBackColor = false;
		btnChangeCourse.Click += btnChangeCourse_Click;
		componentResourceManager.ApplyResources(picLock, "picLock");
		picLock.Name = "picLock";
		picLock.TabStop = false;
		componentResourceManager.ApplyResources(picTrash, "picTrash");
		picTrash.Name = "picTrash";
		picTrash.TabStop = false;
		radListItems.AllowArbitraryItemHeight = true;
		radListItems.AllowEdit = false;
		radListItems.AllowRemove = false;
		componentResourceManager.ApplyResources(radListItems, "radListItems");
		listViewDetailColumn.HeaderText = "Qty";
		listViewDetailColumn.Width = 40f;
		listViewDetailColumn2.HeaderText = "Item Name";
		listViewDetailColumn2.Width = 242f;
		listViewDetailColumn3.HeaderText = "Price";
		listViewDetailColumn3.Width = 57f;
		listViewDetailColumn4.HeaderText = "Ext. Price";
		listViewDetailColumn4.Width = 55f;
		radListItems.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2, listViewDetailColumn3, listViewDetailColumn4);
		radListItems.EnableCustomGrouping = true;
		radListItems.EnableKineticScrolling = true;
		radListItems.GroupIndent = 0;
		radListItems.GroupItemSize = new Size(300, 60);
		radListItems.ItemSize = new Size(200, 40);
		radListItems.ItemSpacing = -1;
		radListItems.Name = "radListItems";
		radListItems.ShowColumnHeaders = false;
		radListItems.ShowGridLines = true;
		radListItems.ShowGroups = true;
		radListItems.ViewType = ListViewType.DetailsView;
		radListItems.SelectedItemChanged += radListItems_SelectedItemChanged;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "twobuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 190;
		verticalScrollControl1.inputedWidth = 0;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.Name = "verticalScrollControl1";
		componentResourceManager.ApplyResources(btnOpenOrders, "btnOpenOrders");
		btnOpenOrders.BackColor = Color.FromArgb(255, 192, 128);
		btnOpenOrders.FlatAppearance.BorderColor = Color.White;
		btnOpenOrders.FlatAppearance.BorderSize = 0;
		btnOpenOrders.FlatAppearance.MouseDownBackColor = Color.White;
		btnOpenOrders.ForeColor = Color.Black;
		btnOpenOrders.Name = "btnOpenOrders";
		btnOpenOrders.UseVisualStyleBackColor = false;
		btnOpenOrders.Click += btnOpenOrders_Click;
		timer_0.Interval = 500;
		timer_0.Tick += timer_0_Tick;
		timer_1.Enabled = true;
		timer_1.Interval = 5000;
		timer_1.Tick += timer_1_Tick;
		pnlQty.Controls.Add(btnFire);
		pnlQty.Controls.Add(btnX2);
		pnlQty.Controls.Add(btn3x);
		pnlQty.Controls.Add(btn4x);
		pnlQty.Controls.Add(btn5x);
		pnlQty.Controls.Add(btn6x);
		pnlQty.Controls.Add(btn7x);
		pnlQty.Controls.Add(btn8x);
		pnlQty.Controls.Add(btn9x);
		componentResourceManager.ApplyResources(pnlQty, "pnlQty");
		pnlQty.Name = "pnlQty";
		btnFire.BackColor = Color.FromArgb(193, 57, 43);
		btnFire.FlatAppearance.BorderColor = Color.Black;
		btnFire.FlatAppearance.BorderSize = 0;
		btnFire.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnFire, "btnFire");
		btnFire.ForeColor = Color.White;
		btnFire.Name = "btnFire";
		btnFire.UseVisualStyleBackColor = false;
		btnFire.EnabledChanged += btnRight_EnabledChanged;
		btnFire.VisibleChanged += btnFire_VisibleChanged;
		btnFire.Click += btnFire_Click;
		btnX2.BackColor = Color.FromArgb(176, 124, 219);
		btnX2.FlatAppearance.BorderColor = Color.Black;
		btnX2.FlatAppearance.BorderSize = 0;
		btnX2.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnX2, "btnX2");
		btnX2.ForeColor = Color.White;
		btnX2.Name = "btnX2";
		btnX2.UseVisualStyleBackColor = false;
		btnX2.Click += btnX2_Click;
		btn3x.BackColor = Color.FromArgb(176, 124, 219);
		btn3x.FlatAppearance.BorderColor = Color.Black;
		btn3x.FlatAppearance.BorderSize = 0;
		btn3x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn3x, "btn3x");
		btn3x.ForeColor = Color.White;
		btn3x.Name = "btn3x";
		btn3x.UseVisualStyleBackColor = false;
		btn3x.Click += btn3x_Click;
		btn4x.BackColor = Color.FromArgb(176, 124, 219);
		btn4x.FlatAppearance.BorderColor = Color.Black;
		btn4x.FlatAppearance.BorderSize = 0;
		btn4x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn4x, "btn4x");
		btn4x.ForeColor = Color.White;
		btn4x.Name = "btn4x";
		btn4x.UseVisualStyleBackColor = false;
		btn4x.Click += btn4x_Click;
		btn5x.BackColor = Color.FromArgb(176, 124, 219);
		btn5x.FlatAppearance.BorderColor = Color.Black;
		btn5x.FlatAppearance.BorderSize = 0;
		btn5x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn5x, "btn5x");
		btn5x.ForeColor = Color.White;
		btn5x.Name = "btn5x";
		btn5x.UseVisualStyleBackColor = false;
		btn5x.Click += btn5x_Click;
		btn6x.BackColor = Color.FromArgb(176, 124, 219);
		btn6x.FlatAppearance.BorderColor = Color.Black;
		btn6x.FlatAppearance.BorderSize = 0;
		btn6x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn6x, "btn6x");
		btn6x.ForeColor = Color.White;
		btn6x.Name = "btn6x";
		btn6x.UseVisualStyleBackColor = false;
		btn6x.Click += btn6x_Click;
		btn7x.BackColor = Color.FromArgb(176, 124, 219);
		btn7x.FlatAppearance.BorderColor = Color.Black;
		btn7x.FlatAppearance.BorderSize = 0;
		btn7x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn7x, "btn7x");
		btn7x.ForeColor = Color.White;
		btn7x.Name = "btn7x";
		btn7x.UseVisualStyleBackColor = false;
		btn7x.Click += btn7x_Click;
		btn8x.BackColor = Color.FromArgb(176, 124, 219);
		btn8x.FlatAppearance.BorderColor = Color.Black;
		btn8x.FlatAppearance.BorderSize = 0;
		btn8x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn8x, "btn8x");
		btn8x.ForeColor = Color.White;
		btn8x.Name = "btn8x";
		btn8x.UseVisualStyleBackColor = false;
		btn8x.Click += btn8x_Click;
		btn9x.BackColor = Color.FromArgb(176, 124, 219);
		btn9x.FlatAppearance.BorderColor = Color.Black;
		btn9x.FlatAppearance.BorderSize = 0;
		btn9x.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btn9x, "btn9x");
		btn9x.ForeColor = Color.White;
		btn9x.Name = "btn9x";
		btn9x.UseVisualStyleBackColor = false;
		btn9x.Click += btn9x_Click;
		componentResourceManager.ApplyResources(GglFeOneCle, "btnPrintChit");
		GglFeOneCle.BackColor = Color.FromArgb(213, 84, 1);
		GglFeOneCle.FlatAppearance.BorderColor = Color.Black;
		GglFeOneCle.FlatAppearance.BorderSize = 0;
		GglFeOneCle.FlatAppearance.MouseDownBackColor = Color.White;
		GglFeOneCle.ForeColor = Color.White;
		GglFeOneCle.Name = "btnPrintChit";
		GglFeOneCle.UseVisualStyleBackColor = false;
		GglFeOneCle.EnabledChanged += btnRight_EnabledChanged;
		GglFeOneCle.Click += GglFeOneCle_Click;
		componentResourceManager.ApplyResources(pnlChangeSeat, "pnlChangeSeat");
		pnlChangeSeat.Controls.Add(btnLeft);
		pnlChangeSeat.Controls.Add(lblTableSeatName);
		pnlChangeSeat.Controls.Add(btnRight);
		pnlChangeSeat.Name = "pnlChangeSeat";
		btnLeft.BackColor = Color.FromArgb(50, 119, 155);
		btnLeft.FlatAppearance.BorderColor = Color.Black;
		btnLeft.FlatAppearance.BorderSize = 0;
		btnLeft.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnLeft, "btnLeft");
		btnLeft.ForeColor = Color.White;
		btnLeft.Name = "btnLeft";
		btnLeft.UseVisualStyleBackColor = false;
		btnLeft.EnabledChanged += btnRight_EnabledChanged;
		btnLeft.Click += btnLeft_Click;
		lblTableSeatName.BackColor = Color.Gray;
		lblTableSeatName.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblTableSeatName, "lblTableSeatName");
		lblTableSeatName.ForeColor = Color.Black;
		lblTableSeatName.Name = "lblTableSeatName";
		btnRight.BackColor = Color.FromArgb(50, 119, 155);
		btnRight.FlatAppearance.BorderColor = Color.Black;
		btnRight.FlatAppearance.BorderSize = 0;
		btnRight.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnRight, "btnRight");
		btnRight.ForeColor = Color.White;
		btnRight.Name = "btnRight";
		btnRight.UseVisualStyleBackColor = false;
		btnRight.EnabledChanged += btnRight_EnabledChanged;
		btnRight.Click += btnRight_Click;
		componentResourceManager.ApplyResources(btnChangeFulfillment, "btnChangeFulfillment");
		btnChangeFulfillment.BackColor = Color.FromArgb(255, 192, 128);
		btnChangeFulfillment.FlatAppearance.BorderColor = Color.White;
		btnChangeFulfillment.FlatAppearance.BorderSize = 0;
		btnChangeFulfillment.FlatAppearance.MouseDownBackColor = Color.White;
		btnChangeFulfillment.ForeColor = Color.Black;
		btnChangeFulfillment.Name = "btnChangeFulfillment";
		btnChangeFulfillment.UseVisualStyleBackColor = false;
		btnChangeFulfillment.Click += btnChangeFulfillment_Click;
		componentResourceManager.ApplyResources(btnOrderNotes, "btnOrderNotes");
		btnOrderNotes.BackColor = Color.FromArgb(198, 129, 71);
		btnOrderNotes.FlatAppearance.BorderColor = Color.Black;
		btnOrderNotes.FlatAppearance.BorderSize = 0;
		btnOrderNotes.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnOrderNotes.ForeColor = Color.White;
		btnOrderNotes.Name = "btnOrderNotes";
		btnOrderNotes.UseVisualStyleBackColor = false;
		btnOrderNotes.Click += btnOrderNotes_Click;
		base.AutoScaleMode = AutoScaleMode.None;
		BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(this, "$this");
		base.ControlBox = false;
		base.Controls.Add(btnOrderNotes);
		base.Controls.Add(btnChangeFulfillment);
		base.Controls.Add(GglFeOneCle);
		base.Controls.Add(pnlQty);
		base.Controls.Add(btnOpenOrders);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(lblSubstitutionMode);
		base.Controls.Add(picItemInfo);
		base.Controls.Add(btnCustomerInfo);
		base.Controls.Add(btnSplitMergeBill);
		base.Controls.Add(btnPrintBill);
		base.Controls.Add(btnChangeGuests);
		base.Controls.Add(btnSearchItems);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(label7);
		base.Controls.Add(label8);
		base.Controls.Add(lblCategories);
		base.Controls.Add(lblItemsHeader);
		base.Controls.Add(pnlGroups);
		base.Controls.Add(pnlItems);
		base.Controls.Add(txtBarcodeSearch);
		base.Controls.Add(pnlTotals);
		base.Controls.Add(pnlNav);
		base.Controls.Add(pnlChangeSeat);
		base.Controls.Add(radListItems);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmOrderEntry";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmOrderEntry_Load;
		base.Controls.SetChildIndex(radListItems, 0);
		base.Controls.SetChildIndex(pnlChangeSeat, 0);
		base.Controls.SetChildIndex(pnlNav, 0);
		base.Controls.SetChildIndex(pnlTotals, 0);
		base.Controls.SetChildIndex(txtBarcodeSearch, 0);
		base.Controls.SetChildIndex(pnlItems, 0);
		base.Controls.SetChildIndex(pnlGroups, 0);
		base.Controls.SetChildIndex(lblItemsHeader, 0);
		base.Controls.SetChildIndex(lblCategories, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex(label7, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(btnSearchItems, 0);
		base.Controls.SetChildIndex(btnChangeGuests, 0);
		base.Controls.SetChildIndex(btnPrintBill, 0);
		base.Controls.SetChildIndex(btnSplitMergeBill, 0);
		base.Controls.SetChildIndex(btnCustomerInfo, 0);
		base.Controls.SetChildIndex(picItemInfo, 0);
		base.Controls.SetChildIndex(lblSubstitutionMode, 0);
		base.Controls.SetChildIndex(lblTrainingMode, 0);
		base.Controls.SetChildIndex(verticalScrollControl1, 0);
		base.Controls.SetChildIndex(btnOpenOrders, 0);
		base.Controls.SetChildIndex(pnlQty, 0);
		base.Controls.SetChildIndex(GglFeOneCle, 0);
		base.Controls.SetChildIndex(btnChangeFulfillment, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(btnOrderNotes, 0);
		((ISupportInitialize)pictureBox1).EndInit();
		pnlNav.ResumeLayout(performLayout: false);
		((ISupportInitialize)picItemInfo).EndInit();
		((ISupportInitialize)txtBarcodeSearch).EndInit();
		pnlTotals.ResumeLayout(performLayout: false);
		((ISupportInitialize)picLock).EndInit();
		((ISupportInitialize)picTrash).EndInit();
		((ISupportInitialize)radListItems).EndInit();
		pnlQty.ResumeLayout(performLayout: false);
		pnlChangeSeat.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	static frmOrderEntry()
	{
		Class26.Ggkj0JxzN9YmC();
		int_0 = 49;
	}

	[CompilerGenerated]
	private bool method_59(CorePOS.Data.Group group_0)
	{
		if (group_0.GroupClassification == ItemClassifications.Product && group_0.ParentGroupID == short_3 && group_0.Active)
		{
			return group_0.OrderEntryShow;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_60(ItemsInGroup itemsInGroup_0)
	{
		return itemsInGroup_0.Group.GroupName.ToUpper() == string_2.ToUpper();
	}

	[CompilerGenerated]
	private bool method_61(ItemsInItem itemsInItem_0)
	{
		_003C_003Ec__DisplayClass154_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass154_2();
		CS_0024_003C_003E8__locals0.x = itemsInItem_0;
		decimal? quantity = CS_0024_003C_003E8__locals0.x.Quantity;
		decimal num = (from i in list_11
			where i.ToString() == CS_0024_003C_003E8__locals0.x.ItemID.ToString()
			select (i)).ToList().Count;
		return (quantity.GetValueOrDefault() <= num) & quantity.HasValue;
	}

	[CompilerGenerated]
	private bool method_62(ListViewDataItem listViewDataItem_0)
	{
		return listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString();
	}

	[CompilerGenerated]
	private bool method_63(ListViewDataItem listViewDataItem_0)
	{
		return listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString();
	}

	[CompilerGenerated]
	private void method_64()
	{
		if (method_41(null, 0))
		{
			bool_28 = true;
		}
	}

	[CompilerGenerated]
	private void method_65()
	{
		if (method_41(null, 0))
		{
			bool_29 = true;
		}
	}

	[CompilerGenerated]
	private void method_66()
	{
		new frmMessageBox("Order is already paid.").ShowDialog(this);
	}

	[CompilerGenerated]
	private void method_67()
	{
		new frmMessageBox(Resources.An_error_occurred_trying_to_sa).ShowDialog(this);
	}

	[CompilerGenerated]
	private void method_68()
	{
		new frmMessageBox("Invalid order, total price is too large.", "Invalid order").ShowDialog(this);
	}

	[CompilerGenerated]
	private void method_69()
	{
		new frmMessageBox("Invalid Order, Instructions is too long", "Invalid order").ShowDialog(this);
	}

	[CompilerGenerated]
	private bool method_70(ListViewDataItem listViewDataItem_0)
	{
		return listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString();
	}

	[CompilerGenerated]
	private bool method_71(ListViewDataItem listViewDataItem_0)
	{
		if (listViewDataItem_0.SubItems[5].ToString() == radListItems.SelectedItems[0].SubItems[5].ToString())
		{
			return listViewDataItem_0.SubItems[16].ToString() == "MainItem";
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_72(OrderResult orderResult_0)
	{
		if (orderResult_0.DateCreated.AddDays(1.0) > DateTime.Now)
		{
			return orderResult_0.SeatNum == int_1;
		}
		return false;
	}

	[CompilerGenerated]
	private bool method_73(Item item_0)
	{
		return item_0.Barcode == txtBarcodeSearch.Text;
	}
}
