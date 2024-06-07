using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmAdminViewItemsAndGroups : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string key;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass9_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public short gId;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int itemId;

		public Item item;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public string groupId;

		public Group group;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass12_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int itemId;

		public Item item;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public Option opt;

		public _003C_003Ec__DisplayClass14_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public ItemsInGroup ig;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass14_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private IContainer icontainer_1;

	private Label lblItems;

	private ListView listViewGroup;

	private Label lblGroup;

	private ListView listViewItem;

	private Label label10;

	private Label label3;

	private Button btnGroupOnSale;

	private Button btnViewItem;

	private Button btnDeleteGroup;

	private Button btnUnassociateItem;

	private Button btnRemoveGroupOnSale;

	private Button btnDeleteItem;

	private Label lblPromoNote;

	public frmAdminViewItemsAndGroups()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		method_3();
	}

	private void method_3()
	{
		lblGroup.Width = ControlHelpers.ControlWidthFixer(this, 6.0);
		lblItems.Width = ControlHelpers.ControlWidthFixer(this, 6.0) - 2;
		lblItems.Location = new Point(lblGroup.Right + 1, lblItems.Location.Y);
		listViewGroup.Width = ControlHelpers.ControlWidthFixer(this, 6.0);
		listViewGroup.Height = listViewGroup.Height + base.Bounds.Height - btnGroupOnSale.Bottom - 3;
		listViewItem.Width = ControlHelpers.ControlWidthFixer(this, 6.0) - 2;
		listViewItem.Height = listViewItem.Height + base.Bounds.Height - btnGroupOnSale.Bottom - 3;
		listViewItem.Location = new Point(listViewGroup.Right + 1, listViewItem.Location.Y);
		lblPromoNote.Width = ControlHelpers.ControlWidthFixer(this, 4.0);
		lblPromoNote.Location = new Point(btnGroupOnSale.Location.X, listViewGroup.Bottom + 1);
		btnDeleteGroup.Width = ControlHelpers.ControlWidthFixer(this, 2.0) - 2;
		btnDeleteGroup.Location = new Point(lblPromoNote.Right + 1, listViewGroup.Bottom + 1);
		btnViewItem.Width = ControlHelpers.ControlWidthFixer(this, 2.0) - 3;
		btnViewItem.Location = new Point(btnDeleteGroup.Right + 1, listViewGroup.Bottom + 1);
		btnUnassociateItem.Width = ControlHelpers.ControlWidthFixer(this, 2.0) - 4;
		btnUnassociateItem.Location = new Point(btnViewItem.Right + 1, listViewGroup.Bottom + 1);
		btnDeleteItem.Width = ControlHelpers.ControlWidthFixer(this, 2.0);
		btnDeleteItem.Location = new Point(btnUnassociateItem.Right + 1, listViewGroup.Bottom + 1);
	}

	private void OdUhrLtfOC()
	{
		DataManager dataManager = new DataManager();
		Dictionary<string, string> groups = AdminMethods.getGroups();
		listViewGroup.Items.Clear();
		listViewGroup.Items.Add(Resources._Unassociated_Items);
		listViewGroup.Items[0].Tag = "0";
		GClass6 gClass = new GClass6();
		int num = 1;
		using Dictionary<string, string>.KeyCollection.Enumerator enumerator = groups.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals0.key = enumerator.Current;
			if (groups[CS_0024_003C_003E8__locals0.key].Contains("**"))
			{
				continue;
			}
			ListViewItem value = new ListViewItem(new string[2]
			{
				groups[CS_0024_003C_003E8__locals0.key],
				CS_0024_003C_003E8__locals0.key
			});
			listViewGroup.Items.Add(value);
			listViewGroup.Items[listViewGroup.Items.Count - 1].Tag = CS_0024_003C_003E8__locals0.key;
			List<Item> list = (from a in dataManager.GetItemsInGroup(Convert.ToInt16(CS_0024_003C_003E8__locals0.key))
				where a.OnSale && (!a.EndDateOnSale.HasValue || (a.EndDateOnSale.HasValue && a.EndDateOnSale >= DateTime.Today))
				select a).ToList();
			List<ItemsInGroup> source = gClass.ItemsInGroups.Where((ItemsInGroup g) => (int?)g.GroupID == (int?)Convert.ToInt16(CS_0024_003C_003E8__locals0.key)).ToList();
			if (list.Count() == source.Count() && list.Count() != 0)
			{
				listViewGroup.Items[num].BackColor = HelperMethods.GetColor("47, 204, 113");
				Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(list.FirstOrDefault().ItemID);
				if (promoSaleItemById != null)
				{
					decimal num2 = Convert.ToDecimal(100);
					decimal num3 = ((list.FirstOrDefault().ItemPrice == 0m) ? 0m : Math.Round(num2 - promoSaleItemById.GetDiscountAmount.Value / list.FirstOrDefault().ItemPrice * num2));
					int num4 = 0;
					foreach (Item item in list)
					{
						if (!(((item.ItemPrice == 0m) ? 0m : Math.Round(num2 - promoSaleItemById.GetDiscountAmount.Value / item.ItemPrice * num2)) != num3))
						{
							num4++;
							continue;
						}
						break;
					}
					if (list.Count() == num4)
					{
						listViewGroup.Items[num].Text = listViewGroup.Items[num].Text + "; " + num3.ToString("0") + "% Off";
					}
				}
				else
				{
					listViewGroup.Items[num].Text = listViewGroup.Items[num].Text + "; " + 0.ToString("0") + "% Off";
				}
			}
			num++;
		}
	}

	private void method_4()
	{
		if (listViewGroup.SelectedItems.Count <= 0)
		{
			return;
		}
		listViewItem.Items.Clear();
		List<Item> list = new List<Item>();
		if (listViewGroup.SelectedIndices[0] != 0)
		{
			list = (from i in new DataManager().GetItemsInGroup(Convert.ToInt16(listViewGroup.SelectedItems[0].SubItems[1].Text))
				where !i.isDeleted
				select i).ToList();
			btnUnassociateItem.Enabled = true;
			btnDeleteGroup.Enabled = true;
			btnRemoveGroupOnSale.Enabled = true;
			btnGroupOnSale.Enabled = true;
		}
		else
		{
			list = AdminMethods.getNonAssociatedItems(ItemClassifications.Product).ToList();
			btnUnassociateItem.Enabled = false;
			btnDeleteGroup.Enabled = false;
			btnRemoveGroupOnSale.Enabled = false;
			btnGroupOnSale.Enabled = false;
		}
		int num = 0;
		foreach (Item item in list)
		{
			listViewItem.Items.Add(item.ItemName);
			listViewItem.Items[listViewItem.Items.Count - 1].Tag = item.ItemID;
			Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(item.ItemID);
			if (item.OnSale && promoSaleItemById != null)
			{
				listViewItem.Items[num].BackColor = HelperMethods.GetColor("47, 204, 113");
			}
			num++;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		Close();
	}

	private void frmAdminViewItemsAndGroups_Load(object sender, EventArgs e)
	{
		OdUhrLtfOC();
	}

	private void listViewGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_4();
		if (listViewGroup.SelectedItems.Count > 0)
		{
			if (listViewGroup.SelectedItems[0].BackColor != HelperMethods.GetColor("47, 204, 113"))
			{
				btnRemoveGroupOnSale.Enabled = false;
				btnRemoveGroupOnSale.BackColor = HelperMethods.GetColor("210, 210, 210");
			}
			else
			{
				btnRemoveGroupOnSale.Enabled = true;
				btnRemoveGroupOnSale.BackColor = HelperMethods.GetColor("244, 164, 96");
			}
		}
	}

	private void listViewItem_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void btnViewItem_Click(object sender, EventArgs e)
	{
		if (listViewItem.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
			CS_0024_003C_003E8__locals0.itemId = (int)listViewItem.SelectedItems[0].Tag;
			if (new frmAddEditItems(new GClass6().Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault().ItemID).ShowDialog(this) == DialogResult.OK)
			{
				new NotificationLabel(this, Resources.Item_Successfully_Edited, NotificationTypes.Success).Show();
			}
			method_4();
		}
	}

	private void btnGroupOnSale_Click(object sender, EventArgs e)
	{
	}

	private void btnDeleteGroup_Click(object sender, EventArgs e)
	{
		if (listViewGroup.SelectedItems.Count <= 0)
		{
			return;
		}
		frmMessageBox frmMessageBox2 = new frmMessageBox(Resources.Are_you_sure_you_want_to_delet3 + listViewGroup.SelectedItems[0].SubItems[0].Text + Resources._The_item_s_inside_this_group_, Resources.Delete, CustomMessageBoxButtons.YesNo);
		frmMessageBox2.ShowDialog(this);
		if (frmMessageBox2.DialogResult != DialogResult.OK && frmMessageBox2.DialogResult != DialogResult.Yes)
		{
			return;
		}
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.gId = Convert.ToInt16(Convert.ToInt16(listViewGroup.SelectedItems[0].SubItems[1].Text));
		Group group = gClass.Groups.Where((Group x) => x.GroupID == CS_0024_003C_003E8__locals0.gId).FirstOrDefault();
		group.Archived = true;
		group.Active = false;
		group.Synced = false;
		Helper.SubmitChangesWithCatch(gClass);
		List<Group> list = gClass.Groups.Where((Group a) => a.ParentGroupID == CS_0024_003C_003E8__locals0.gId).ToList();
		if (list.Count > 0)
		{
			foreach (Group item in list)
			{
				item.ParentGroupID = 0;
			}
			Helper.SubmitChangesWithCatch(gClass);
		}
		AdminMethods.UnassociateItemsInGroup(CS_0024_003C_003E8__locals0.gId);
		AdminMethods.UnassociateItemsInGroupRecursion(CS_0024_003C_003E8__locals0.gId);
		if (gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.GroupID == CS_0024_003C_003E8__locals0.gId).Count() > 0)
		{
			gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.GroupID == CS_0024_003C_003E8__locals0.gId).ToList().ForEach(delegate(ItemsWithOption b)
			{
				b.GroupID = 0;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		OdUhrLtfOC();
		listViewItem.Items.Clear();
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
		new NotificationLabel(this, Resources.The_Group_is_successfully_dele, NotificationTypes.Success).Show();
	}

	private void btnUnassociateItem_Click(object sender, EventArgs e)
	{
		if (listViewItem.SelectedItems.Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		if (listViewGroup.SelectedItems.Count <= 0)
		{
			new frmMessageBox(Resources.Please_Select_a_group, Resources.Error_select_a_group).ShowDialog(this);
			return;
		}
		CS_0024_003C_003E8__locals0.itemId = (int)listViewItem.SelectedItems[0].Tag;
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.itemId && i.isDeleted == false).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.item != null)
		{
			frmMessageBox frmMessageBox2 = new frmMessageBox(Resources.Are_you_sure_you_want_to_Unass + CS_0024_003C_003E8__locals0.item.ItemName + Resources._from_it_s_group, Resources.Unassociate, CustomMessageBoxButtons.YesNo);
			frmMessageBox2.ShowDialog(this);
			if (frmMessageBox2.DialogResult == DialogResult.OK || frmMessageBox2.DialogResult == DialogResult.Yes)
			{
				_003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass12_1();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals1.groupId = (string)listViewGroup.SelectedItems[0].Tag;
				CS_0024_003C_003E8__locals1.group = gClass.Groups.Where((Group g) => g.GroupID == Convert.ToInt16(CS_0024_003C_003E8__locals1.groupId)).FirstOrDefault();
				ItemsInGroup entity = gClass.ItemsInGroups.Where((ItemsInGroup d) => d.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.item.ItemID && (int?)d.GroupID == (int?)CS_0024_003C_003E8__locals1.group.GroupID).FirstOrDefault();
				gClass.ItemsInGroups.DeleteOnSubmit(entity);
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.item.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
				method_4();
				int index = listViewGroup.SelectedItems[0].Index;
				OdUhrLtfOC();
				listViewGroup.Items[index].Selected = true;
				new NotificationLabel(this, Resources.Item_Successfully_Unassociated, NotificationTypes.Success).Show();
				MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Item_does_not_exists, NotificationTypes.Warning).Show();
		}
	}

	private void btnRemoveGroupOnSale_Click(object sender, EventArgs e)
	{
	}

	private void btnDeleteItem_Click(object sender, EventArgs e)
	{
		if (listViewItem.SelectedItems.Count <= 0)
		{
			return;
		}
		frmMessageBox frmMessageBox2 = new frmMessageBox(Resources.Are_you_sure_you_want_to_delet4 + listViewItem.SelectedItems[0].SubItems[0].Text + "\"?", Resources.Delete, CustomMessageBoxButtons.YesNo);
		frmMessageBox2.ShowDialog(this);
		if (frmMessageBox2.DialogResult != DialogResult.OK && frmMessageBox2.DialogResult != DialogResult.Yes)
		{
			return;
		}
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.itemId = (int)listViewItem.SelectedItems[0].Tag;
		CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.itemId && i.isDeleted == false).FirstOrDefault();
		if (CS_0024_003C_003E8__locals0.item != null)
		{
			CS_0024_003C_003E8__locals0.item.isDeleted = true;
			CS_0024_003C_003E8__locals0.item.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
		}
		method_4();
		if (listViewGroup.Items.Count > 0)
		{
			int index = listViewGroup.SelectedItems[0].Index;
			OdUhrLtfOC();
			listViewGroup.Items[index].Selected = true;
		}
		if (gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).Count() > 0)
		{
			gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList().ForEach(delegate(ItemsWithOption a)
			{
				a.ToBeDeleted = true;
				a.Synced = false;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		List<Option> list = gClass.Options.Where((Option a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList();
		if (list.Count > 0)
		{
			using List<Option>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_1();
				CS_0024_003C_003E8__locals1.opt = enumerator.Current;
				gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.OptionID == (int?)CS_0024_003C_003E8__locals1.opt.OptionID).ToList().ForEach(delegate(ItemsWithOption a)
				{
					a.ToBeDeleted = true;
					a.Synced = false;
				});
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		using (List<ItemsInGroup>.Enumerator enumerator2 = gClass.ItemsInGroups.Where((ItemsInGroup a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.itemId).ToList().GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass14_2();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals2.ig = enumerator2.Current;
				List<ItemsInGroup> list2 = (from a in gClass.ItemsInGroups
					where (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals2.ig.GroupID && a.ItemID != (int?)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemId
					orderby a.SortOrder
					select a).ToList();
				short num = 0;
				foreach (ItemsInGroup item in list2)
				{
					if (item != null)
					{
						item.SortOrder = num;
					}
					if (item.Item != null)
					{
						item.Item.Synced = false;
					}
					Helper.SubmitChangesWithCatch(gClass);
					num = (short)(num + 1);
				}
			}
		}
		MemoryLoadedObjects.RefreshItemOptions = true;
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
		new NotificationLabel(this, Resources.Item_Successfully_Deleted, NotificationTypes.Success).Show();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminViewItemsAndGroups));
		lblItems = new Label();
		listViewGroup = new ListView();
		lblGroup = new Label();
		listViewItem = new ListView();
		label10 = new Label();
		label3 = new Label();
		btnGroupOnSale = new Button();
		btnViewItem = new Button();
		btnDeleteGroup = new Button();
		btnUnassociateItem = new Button();
		btnRemoveGroupOnSale = new Button();
		btnDeleteItem = new Button();
		lblPromoNote = new Label();
		SuspendLayout();
		lblItems.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblItems, "lblItems");
		lblItems.ForeColor = Color.White;
		lblItems.Name = "lblItems";
		listViewGroup.BackColor = Color.White;
		listViewGroup.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(listViewGroup, "listViewGroup");
		listViewGroup.ForeColor = Color.Black;
		listViewGroup.Groups.AddRange(new ListViewGroup[1] { (ListViewGroup)componentResourceManager.GetObject("listViewGroup.Groups") });
		listViewGroup.HideSelection = false;
		listViewGroup.MultiSelect = false;
		listViewGroup.Name = "listViewGroup";
		listViewGroup.UseCompatibleStateImageBehavior = false;
		listViewGroup.View = View.List;
		listViewGroup.SelectedIndexChanged += listViewGroup_SelectedIndexChanged;
		lblGroup.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblGroup, "lblGroup");
		lblGroup.ForeColor = Color.White;
		lblGroup.Name = "lblGroup";
		listViewItem.BackColor = Color.White;
		listViewItem.BorderStyle = BorderStyle.None;
		listViewItem.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(listViewItem, "listViewItem");
		listViewItem.ForeColor = Color.Black;
		listViewItem.FullRowSelect = true;
		listViewItem.Groups.AddRange(new ListViewGroup[2]
		{
			(ListViewGroup)componentResourceManager.GetObject("listViewItem.Groups"),
			(ListViewGroup)componentResourceManager.GetObject("listViewItem.Groups1")
		});
		listViewItem.HideSelection = false;
		listViewItem.Name = "listViewItem";
		listViewItem.UseCompatibleStateImageBehavior = false;
		listViewItem.View = View.List;
		listViewItem.SelectedIndexChanged += listViewItem_SelectedIndexChanged;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.LemonChiffon;
		label3.Name = "label3";
		btnGroupOnSale.BackColor = Color.FromArgb(61, 142, 185);
		btnGroupOnSale.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnGroupOnSale, "btnGroupOnSale");
		btnGroupOnSale.ForeColor = SystemColors.ButtonFace;
		btnGroupOnSale.Name = "btnGroupOnSale";
		btnGroupOnSale.UseVisualStyleBackColor = false;
		btnGroupOnSale.Click += btnGroupOnSale_Click;
		btnViewItem.BackColor = Color.FromArgb(61, 142, 185);
		btnViewItem.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnViewItem, "btnViewItem");
		btnViewItem.ForeColor = SystemColors.ButtonFace;
		btnViewItem.Name = "btnViewItem";
		btnViewItem.UseVisualStyleBackColor = false;
		btnViewItem.Click += btnViewItem_Click;
		btnDeleteGroup.BackColor = Color.FromArgb(235, 107, 86);
		btnDeleteGroup.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDeleteGroup, "btnDeleteGroup");
		btnDeleteGroup.ForeColor = SystemColors.ButtonFace;
		btnDeleteGroup.Name = "btnDeleteGroup";
		btnDeleteGroup.UseVisualStyleBackColor = false;
		btnDeleteGroup.Click += btnDeleteGroup_Click;
		btnUnassociateItem.BackColor = Color.SandyBrown;
		btnUnassociateItem.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnUnassociateItem, "btnUnassociateItem");
		btnUnassociateItem.ForeColor = SystemColors.ButtonFace;
		btnUnassociateItem.Name = "btnUnassociateItem";
		btnUnassociateItem.UseVisualStyleBackColor = false;
		btnUnassociateItem.Click += btnUnassociateItem_Click;
		btnRemoveGroupOnSale.BackColor = Color.SandyBrown;
		btnRemoveGroupOnSale.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnRemoveGroupOnSale, "btnRemoveGroupOnSale");
		btnRemoveGroupOnSale.ForeColor = SystemColors.ButtonFace;
		btnRemoveGroupOnSale.Name = "btnRemoveGroupOnSale";
		btnRemoveGroupOnSale.UseVisualStyleBackColor = false;
		btnRemoveGroupOnSale.Click += btnRemoveGroupOnSale_Click;
		btnDeleteItem.BackColor = Color.FromArgb(235, 107, 86);
		btnDeleteItem.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDeleteItem, "btnDeleteItem");
		btnDeleteItem.ForeColor = SystemColors.ButtonFace;
		btnDeleteItem.Name = "btnDeleteItem";
		btnDeleteItem.UseVisualStyleBackColor = false;
		btnDeleteItem.Click += btnDeleteItem_Click;
		lblPromoNote.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(lblPromoNote, "lblPromoNote");
		lblPromoNote.Name = "lblPromoNote";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lblPromoNote);
		base.Controls.Add(btnDeleteItem);
		base.Controls.Add(btnRemoveGroupOnSale);
		base.Controls.Add(btnUnassociateItem);
		base.Controls.Add(btnDeleteGroup);
		base.Controls.Add(btnViewItem);
		base.Controls.Add(btnGroupOnSale);
		base.Controls.Add(label3);
		base.Controls.Add(label10);
		base.Controls.Add(listViewItem);
		base.Controls.Add(lblGroup);
		base.Controls.Add(listViewGroup);
		base.Controls.Add(lblItems);
		ForeColor = Color.FromArgb(40, 40, 40);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminViewItemsAndGroups";
		base.Opacity = 1.0;
		base.Load += frmAdminViewItemsAndGroups_Load;
		base.Controls.SetChildIndex(lblItems, 0);
		base.Controls.SetChildIndex(listViewGroup, 0);
		base.Controls.SetChildIndex(lblGroup, 0);
		base.Controls.SetChildIndex(listViewItem, 0);
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(btnGroupOnSale, 0);
		base.Controls.SetChildIndex(btnViewItem, 0);
		base.Controls.SetChildIndex(btnDeleteGroup, 0);
		base.Controls.SetChildIndex(btnUnassociateItem, 0);
		base.Controls.SetChildIndex(btnRemoveGroupOnSale, 0);
		base.Controls.SetChildIndex(btnDeleteItem, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(lblPromoNote, 0);
		ResumeLayout(performLayout: false);
	}
}
