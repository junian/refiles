using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmEditItemSortOrder : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public short groupID;

		public int itemID;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public KeyValuePair<string, string> temp;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private bool bool_0;

	private bool bool_1;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnOkay;

	private Class19 ddlGroups;

	private Label label8;

	private Label label1;

	private Label label3;

	internal ColumnHeader columnHeader_0;

	internal ListView lstItems;

	internal Button btnDown;

	internal Button btnUp;

	private Button btnAddEmptyRow;

	private Button btnRemoveRow;

	private VScrollBar vScrollBar1;

	private Button btnSortByName;

	private Button btnSortByPrice;

	public frmEditItemSortOrder()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = true;
		bool_1 = true;
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmEditItemSortOrder_Load(object sender, EventArgs e)
	{
		Button button = btnUp;
		btnDown.Enabled = false;
		button.Enabled = false;
		method_3();
	}

	private void method_3()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Product, withShowItems: false, onlyActive: true);
		ddlGroups.DisplayMember = "Value";
		ddlGroups.ValueMember = "Key";
		ddlGroups.DataSource = new BindingSource(groups, null);
		ddlGroups.SelectedIndex = 0;
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		try
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			GClass6 gClass = new GClass6();
			short num = 0;
			CS_0024_003C_003E8__locals0.groupID = Convert.ToInt16(((KeyValuePair<string, string>)ddlGroups.SelectedItem).Key);
			CS_0024_003C_003E8__locals0.itemID = 0;
			foreach (ListViewItem item in lstItems.Items)
			{
				if (!string.IsNullOrEmpty(item.SubItems[1].Text))
				{
					CS_0024_003C_003E8__locals0.itemID = Convert.ToInt32(item.SubItems[1].Text);
					ItemsInGroup itemsInGroup = gClass.ItemsInGroups.Where((ItemsInGroup x) => (int?)x.GroupID == (int?)CS_0024_003C_003E8__locals0.groupID && x.ItemID == (int?)CS_0024_003C_003E8__locals0.itemID).FirstOrDefault();
					if (itemsInGroup != null)
					{
						itemsInGroup.SortOrder = num;
					}
					if (itemsInGroup.Item != null)
					{
						itemsInGroup.Item.Synced = false;
					}
					Helper.SubmitChangesWithCatch(gClass);
				}
				num = (short)(num + 1);
			}
			MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
			new NotificationLabel(this, Resources.Sort_orders_have_been_saved_su, NotificationTypes.Success).Show();
		}
		catch
		{
			new NotificationLabel(this, Resources.An_error_has_occurred_trying_t4, NotificationTypes.Warning).Show();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
	{
		Button button = btnUp;
		btnDown.Enabled = false;
		button.Enabled = false;
		_ = (KeyValuePair<string, string>)ddlGroups.SelectedItem;
		if (ddlGroups.SelectedIndex > 0)
		{
			method_4();
		}
	}

	private void method_4(ItemSortBy itemSortBy_0 = ItemSortBy.SortOrder)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.temp = (KeyValuePair<string, string>)ddlGroups.SelectedItem;
		List<SortListItem> list = (from x in new GClass6().ItemsInGroups
			where x.GroupID.Value == Convert.ToInt16(((KeyValuePair<string, string>)CS_0024_003C_003E8__locals0.temp).Key) && x.Item.Active == true && x.Item.isDeleted == false
			select x into z
			select new SortListItem
			{
				ItemID = z.ItemID.Value,
				ItemName = z.Item.ItemName,
				ItemPrice = z.Item.ItemPrice,
				SortOrder = z.SortOrder
			} into x
			orderby x.SortOrder
			select x).ThenBy((SortListItem y) => y.ItemName).ToList();
		lstItems.Items.Clear();
		if (itemSortBy_0 == ItemSortBy.SortOrder)
		{
			int num = 0;
			if (list.Count() > 0)
			{
				num = list.FirstOrDefault().SortOrder;
			}
			foreach (SortListItem item in list)
			{
				if (num < item.SortOrder && item.SortOrder > 0)
				{
					do
					{
						lstItems.Items.Add(new ListViewItem(new string[2]
						{
							string.Empty,
							string.Empty
						}));
						num++;
					}
					while (num < item.SortOrder);
				}
				lstItems.Items.Add(new ListViewItem(new string[2]
				{
					item.ItemName,
					item.ItemID.ToString()
				}));
				num++;
			}
		}
		else
		{
			List<SortListItem> list2 = list;
			switch (itemSortBy_0)
			{
			case ItemSortBy.ItemName:
				list2 = ((!bool_0) ? list.OrderByDescending((SortListItem a) => a.ItemName).ToList() : list.OrderBy((SortListItem a) => a.ItemName).ToList());
				break;
			case ItemSortBy.ItemPrice:
				list2 = ((!bool_1) ? list.OrderByDescending((SortListItem a) => a.ItemPrice).ToList() : list.OrderBy((SortListItem a) => a.ItemPrice).ToList());
				break;
			}
			foreach (SortListItem item2 in list2)
			{
				lstItems.Items.Add(new ListViewItem(new string[2]
				{
					item2.ItemName,
					item2.ItemID.ToString()
				}));
			}
		}
		if (lstItems.Items.Count * 20 > lstItems.Height)
		{
			vScrollBar1.Visible = true;
			vScrollBar1.Minimum = 0;
			vScrollBar1.Maximum = ((lstItems.Items.Count > 10) ? (lstItems.Items.Count - 5) : 0);
			vScrollBar1.Value = ((lstItems.Items.Count > 0) ? lstItems.TopItem.Index : 0);
		}
		else
		{
			vScrollBar1.Visible = false;
		}
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_move, NotificationTypes.Notification).Show();
			return;
		}
		int index = lstItems.SelectedItems[0].Index;
		ListViewItem item = lstItems.Items[index];
		lstItems.Items.RemoveAt(index);
		lstItems.Items.Insert(index - 1, item);
		lstItems.Items[index - 1].EnsureVisible();
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_move, NotificationTypes.Notification).Show();
			return;
		}
		int index = lstItems.SelectedItems[0].Index;
		ListViewItem item = lstItems.Items[index];
		if (index < lstItems.Items.Count)
		{
			lstItems.Items.RemoveAt(index);
			lstItems.Items.Insert(index + 1, item);
			lstItems.Items[index + 1].EnsureVisible();
		}
	}

	private void btnAddEmptyRow_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_add_t, NotificationTypes.Notification).Show();
			return;
		}
		int index = lstItems.SelectedItems[0].Index;
		ListViewItem item = new ListViewItem(new string[2]
		{
			string.Empty,
			string.Empty
		});
		lstItems.Items.Insert(index + 1, item);
		lstItems.Items[index + 1].Selected = true;
	}

	private void btnRemoveRow_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count != 0 && !(lstItems.SelectedItems[0].SubItems[1].Text != string.Empty))
		{
			int index = lstItems.SelectedItems[0].Index;
			lstItems.Items[index].Remove();
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_empty_spot_to, NotificationTypes.Notification).Show();
		}
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count > 0)
		{
			if (lstItems.SelectedItems[0].Index == 0 && lstItems.Items.Count > 1)
			{
				btnUp.Enabled = false;
				btnDown.Enabled = true;
			}
			if (lstItems.SelectedItems[0].Index > 0)
			{
				Button button = btnDown;
				btnUp.Enabled = true;
				button.Enabled = true;
			}
			if (lstItems.SelectedItems[0].Index == lstItems.Items.Count - 1 && lstItems.SelectedItems[0].Index > 0)
			{
				btnUp.Enabled = true;
				btnDown.Enabled = false;
			}
		}
	}

	private void btnUp_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
		if (lstItems.Items.Count > 0)
		{
			lstItems.TopItem = lstItems.Items[vScrollBar1.Value];
		}
	}

	private void btnSortByName_Click(object sender, EventArgs e)
	{
		method_4(ItemSortBy.ItemName);
		bool_0 = !bool_0;
		if (bool_0)
		{
			btnSortByName.Text = "SORT BY NAME ASC";
		}
		else
		{
			btnSortByName.Text = "SORT BY NAME DESC";
		}
	}

	private void btnSortByPrice_Click(object sender, EventArgs e)
	{
		method_4(ItemSortBy.ItemPrice);
		bool_1 = !bool_1;
		if (bool_1)
		{
			btnSortByPrice.Text = "SORT BY PRICE ASC";
		}
		else
		{
			btnSortByPrice.Text = "SORT BY PRICE DESC";
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditItemSortOrder));
		label3 = new Label();
		label1 = new Label();
		label8 = new Label();
		btnCancel = new Button();
		btnOkay = new Button();
		label9 = new Label();
		columnHeader_0 = new ColumnHeader();
		lstItems = new ListView();
		btnDown = new Button();
		btnUp = new Button();
		btnAddEmptyRow = new Button();
		btnRemoveRow = new Button();
		ddlGroups = new Class19();
		vScrollBar1 = new VScrollBar();
		btnSortByName = new Button();
		btnSortByPrice = new Button();
		SuspendLayout();
		label3.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.Name = "label3";
		label3.UseWaitCursor = true;
		label1.BackColor = SystemColors.GrayText;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.UseWaitCursor = true;
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOkay, "btnOkay");
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.Name = "btnOkay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(columnHeader_0, "ItemName");
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnDown, "btnDown");
		btnDown.ForeColor = Color.White;
		btnDown.Name = "btnDown";
		btnDown.Tag = "";
		btnDown.UseVisualStyleBackColor = false;
		btnDown.EnabledChanged += btnUp_EnabledChanged;
		btnDown.Click += btnDown_Click;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnUp, "btnUp");
		btnUp.ForeColor = Color.White;
		btnUp.Name = "btnUp";
		btnUp.Tag = "";
		btnUp.UseVisualStyleBackColor = false;
		btnUp.EnabledChanged += btnUp_EnabledChanged;
		btnUp.Click += btnUp_Click;
		btnAddEmptyRow.BackColor = Color.FromArgb(50, 119, 155);
		btnAddEmptyRow.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddEmptyRow, "btnAddEmptyRow");
		btnAddEmptyRow.ForeColor = SystemColors.ButtonFace;
		btnAddEmptyRow.Name = "btnAddEmptyRow";
		btnAddEmptyRow.UseVisualStyleBackColor = false;
		btnAddEmptyRow.Click += btnAddEmptyRow_Click;
		btnRemoveRow.BackColor = Color.SandyBrown;
		btnRemoveRow.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnRemoveRow, "btnRemoveRow");
		btnRemoveRow.ForeColor = SystemColors.ButtonFace;
		btnRemoveRow.Name = "btnRemoveRow";
		btnRemoveRow.UseVisualStyleBackColor = false;
		btnRemoveRow.Click += btnRemoveRow_Click;
		ddlGroups.BackColor = Color.White;
		ddlGroups.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroups.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlGroups, "ddlGroups");
		ddlGroups.FormattingEnabled = true;
		ddlGroups.Name = "ddlGroups";
		ddlGroups.SelectedIndexChanged += ddlGroups_SelectedIndexChanged;
		componentResourceManager.ApplyResources(vScrollBar1, "vScrollBar1");
		vScrollBar1.Name = "vScrollBar1";
		vScrollBar1.Scroll += vScrollBar1_Scroll;
		btnSortByName.BackColor = Color.FromArgb(53, 152, 220);
		btnSortByName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSortByName, "btnSortByName");
		btnSortByName.ForeColor = SystemColors.ButtonFace;
		btnSortByName.Name = "btnSortByName";
		btnSortByName.UseVisualStyleBackColor = false;
		btnSortByName.Click += btnSortByName_Click;
		btnSortByPrice.BackColor = Color.FromArgb(53, 152, 220);
		btnSortByPrice.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSortByPrice, "btnSortByPrice");
		btnSortByPrice.ForeColor = SystemColors.ButtonFace;
		btnSortByPrice.Name = "btnSortByPrice";
		btnSortByPrice.UseVisualStyleBackColor = false;
		btnSortByPrice.Click += btnSortByPrice_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(vScrollBar1);
		base.Controls.Add(btnSortByPrice);
		base.Controls.Add(btnSortByName);
		base.Controls.Add(btnRemoveRow);
		base.Controls.Add(btnAddEmptyRow);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lstItems);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(ddlGroups);
		base.Controls.Add(label8);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label9);
		base.Name = "frmEditItemSortOrder";
		base.Opacity = 1.0;
		base.Load += frmEditItemSortOrder_Load;
		ResumeLayout(performLayout: false);
	}
}
