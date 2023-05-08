using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmEditGroupSortOrder : frmMasterForm
{
	private IContainer icontainer_1;

	internal ListView lstGroups;

	internal ColumnHeader columnHeader_0;

	private Label label3;

	private Button btnCancel;

	private Button btnOkay;

	private Label label9;

	private Button btnRemoveRow;

	private Button btnAddEmptyRow;

	internal Button btnDown;

	internal Button btnUp;

	private Label label2;

	private Label label4;

	internal ListView listView_0;

	internal ColumnHeader columnHeader_1;

	private Class19 ddlGroups;

	private Label label8;

	private Label label1;

	private Class19 ddlClassification;

	public frmEditGroupSortOrder()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		method_4();
		method_3(ItemClassifications.Product.ToString());
	}

	private void method_3(string string_0)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.classification = string_0;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("0", "All Parent Groups");
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.parentGroupIds = (from a in gClass.Groups
			where a.ParentGroupID != 0
			select a.ParentGroupID).Distinct().ToList();
		foreach (KeyValuePair<string, string> item in gClass.Groups.Where((Group a) => CS_0024_003C_003E8__locals0.parentGroupIds.Contains(a.GroupID) && a.Archived == false && a.Active == true && a.GroupClassification == CS_0024_003C_003E8__locals0.classification).ToDictionary((Group a) => a.GroupID.ToString(), (Group a) => a.GroupName))
		{
			dictionary.Add(item.Key, item.Value);
		}
		ddlGroups.DisplayMember = "Value";
		ddlGroups.ValueMember = "Key";
		ddlGroups.DataSource = new BindingSource(dictionary, null);
		ddlGroups.SelectedIndex = 0;
	}

	private void method_4()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(ItemClassifications.Product.ToString(), ItemClassifications.Product.ToString());
		dictionary.Add(ItemClassifications.Material.ToString(), ItemClassifications.Material.ToString());
		dictionary.Add(ItemClassifications.Option.ToString(), ItemClassifications.Option.ToString());
		ddlClassification.DisplayMember = "Value";
		ddlClassification.ValueMember = "Key";
		ddlClassification.DataSource = new BindingSource(dictionary, null);
		ddlClassification.SelectedIndex = 0;
	}

	private void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_5(Convert.ToInt32(((KeyValuePair<string, string>)ddlGroups.SelectedItem).Key), ddlClassification.Text);
	}

	private void ddlClassification_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3(((KeyValuePair<string, string>)ddlClassification.SelectedItem).Value);
	}

	private void method_5(int int_0, string string_0 = "product")
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.parentGroupId = int_0;
		CS_0024_003C_003E8__locals0.groupClassification = string_0;
		listView_0.Items.Clear();
		lstGroups.Items.Clear();
		GClass6 gClass = new GClass6();
		List<Group> list = (from a in gClass.Groups
			where a.Archived == false && a.Active == true && a.HighTraffic == true && a.ParentGroupID == CS_0024_003C_003E8__locals0.parentGroupId && a.GroupClassification == CS_0024_003C_003E8__locals0.groupClassification
			orderby a.SortOrder
			select a).ToList();
		List<Group> list2 = (from a in gClass.Groups
			where a.Archived == false && a.Active == true && a.HighTraffic == false && a.ParentGroupID == CS_0024_003C_003E8__locals0.parentGroupId && a.GroupClassification == CS_0024_003C_003E8__locals0.groupClassification
			orderby a.SortOrder
			select a).ToList();
		int num = 1;
		foreach (Group item in list)
		{
			if (num < item.SortOrder && item.SortOrder > 0)
			{
				do
				{
					listView_0.Items.Add(new ListViewItem(new string[2]
					{
						string.Empty,
						string.Empty
					}));
					num++;
				}
				while (num < item.SortOrder);
			}
			listView_0.Items.Add(new ListViewItem(new string[2]
			{
				item.GroupName,
				item.GroupID.ToString()
			}));
			if (item.SortOrder > 0)
			{
				num++;
			}
		}
		foreach (Group item2 in list2)
		{
			if (num < item2.SortOrder && item2.SortOrder > 0)
			{
				do
				{
					lstGroups.Items.Add(new ListViewItem(new string[2]
					{
						string.Empty,
						string.Empty
					}));
					num++;
				}
				while (num < item2.SortOrder);
			}
			lstGroups.Items.Add(new ListViewItem(new string[2]
			{
				item2.GroupName,
				item2.GroupID.ToString()
			}));
			if (item2.SortOrder > 0)
			{
				num++;
			}
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstGroups.SelectedItems.Count == 0 && listView_0.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_move, NotificationTypes.Notification).Show();
			return;
		}
		if (lstGroups.SelectedItems.Count > 0)
		{
			int index = lstGroups.SelectedItems[0].Index;
			if (index > 0)
			{
				ListViewItem item = lstGroups.Items[index];
				lstGroups.Items.RemoveAt(index);
				lstGroups.Items.Insert(index - 1, item);
				lstGroups.Items[index - 1].EnsureVisible();
			}
		}
		if (listView_0.SelectedItems.Count > 0)
		{
			int index2 = listView_0.SelectedItems[0].Index;
			if (index2 > 0)
			{
				ListViewItem item2 = listView_0.Items[index2];
				listView_0.Items.RemoveAt(index2);
				listView_0.Items.Insert(index2 - 1, item2);
				listView_0.Items[index2 - 1].EnsureVisible();
			}
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstGroups.SelectedItems.Count == 0 && listView_0.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_move, NotificationTypes.Notification).Show();
			return;
		}
		if (lstGroups.SelectedItems.Count > 0)
		{
			int num = lstGroups.SelectedItems[0].Index;
			ListViewItem item = lstGroups.Items[num];
			if (num < lstGroups.Items.Count)
			{
				lstGroups.Items.RemoveAt(num);
				if (num < lstGroups.Items.Count)
				{
					num++;
				}
				lstGroups.Items.Insert(num, item);
				lstGroups.Items[num].EnsureVisible();
			}
		}
		if (listView_0.SelectedItems.Count <= 0)
		{
			return;
		}
		int num2 = listView_0.SelectedItems[0].Index;
		ListViewItem item2 = listView_0.Items[num2];
		if (num2 < listView_0.Items.Count)
		{
			listView_0.Items.RemoveAt(num2);
			if (num2 < listView_0.Items.Count)
			{
				num2++;
			}
			listView_0.Items.Insert(num2, item2);
			listView_0.Items[num2].EnsureVisible();
		}
	}

	private void btnAddEmptyRow_Click(object sender, EventArgs e)
	{
		if (lstGroups.SelectedItems.Count == 0 && listView_0.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_add_t, NotificationTypes.Notification).Show();
			return;
		}
		if (lstGroups.SelectedItems.Count > 0)
		{
			int index = lstGroups.SelectedItems[0].Index;
			ListViewItem item = new ListViewItem(new string[2]
			{
				string.Empty,
				string.Empty
			});
			lstGroups.Items.Insert(index + 1, item);
			lstGroups.Items[index + 1].Selected = true;
		}
		if (listView_0.SelectedItems.Count > 0)
		{
			int index2 = listView_0.SelectedItems[0].Index;
			ListViewItem item2 = new ListViewItem(new string[2]
			{
				string.Empty,
				string.Empty
			});
			listView_0.Items.Insert(index2 + 1, item2);
			listView_0.Items[index2 + 1].Selected = true;
		}
	}

	private void btnRemoveRow_Click(object sender, EventArgs e)
	{
		if ((lstGroups.SelectedItems.Count != 0 && !(lstGroups.SelectedItems[0].SubItems[1].Text != string.Empty)) || (listView_0.SelectedItems.Count != 0 && !(listView_0.SelectedItems[0].SubItems[1].Text != string.Empty)))
		{
			if (lstGroups.SelectedItems.Count > 0 && lstGroups.SelectedItems[0].SubItems[1].Text == string.Empty)
			{
				int index = lstGroups.SelectedItems[0].Index;
				lstGroups.Items[index].Remove();
			}
			if (listView_0.SelectedItems.Count > 0 && listView_0.SelectedItems[0].SubItems[1].Text == string.Empty)
			{
				int index2 = listView_0.SelectedItems[0].Index;
				listView_0.Items[index2].Remove();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_empty_spot_to, NotificationTypes.Notification).Show();
		}
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		try
		{
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
			GClass6 gClass = new GClass6();
			short num = 1;
			CS_0024_003C_003E8__locals0.groupId = 0;
			foreach (ListViewItem item in listView_0.Items)
			{
				if (!string.IsNullOrEmpty(item.SubItems[1].Text))
				{
					CS_0024_003C_003E8__locals0.groupId = Convert.ToInt16(item.SubItems[1].Text);
					Group group = gClass.Groups.Where((Group a) => a.GroupID == CS_0024_003C_003E8__locals0.groupId).FirstOrDefault();
					if (group != null)
					{
						group.SortOrder = num;
						group.Synced = false;
					}
					Helper.SubmitChangesWithCatch(gClass);
				}
				num = (short)(num + 1);
			}
			foreach (ListViewItem item2 in lstGroups.Items)
			{
				if (!string.IsNullOrEmpty(item2.SubItems[1].Text))
				{
					CS_0024_003C_003E8__locals0.groupId = Convert.ToInt16(item2.SubItems[1].Text);
					Group group2 = gClass.Groups.Where((Group a) => a.GroupID == CS_0024_003C_003E8__locals0.groupId).FirstOrDefault();
					if (group2 != null)
					{
						group2.SortOrder = num;
						group2.Synced = false;
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

	private void lstGroups_Click(object sender, EventArgs e)
	{
		if (listView_0.SelectedItems.Count > 0)
		{
			for (int i = 0; i < listView_0.SelectedIndices.Count; i++)
			{
				listView_0.Items[listView_0.SelectedIndices[i]].Selected = false;
			}
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (lstGroups.SelectedItems.Count > 0)
		{
			for (int i = 0; i < listView_0.SelectedIndices.Count; i++)
			{
				listView_0.Items[listView_0.SelectedIndices[i]].Selected = false;
			}
		}
	}

	private void listView_0_Click(object sender, EventArgs e)
	{
		if (lstGroups.SelectedItems.Count > 0)
		{
			for (int i = 0; i < lstGroups.SelectedIndices.Count; i++)
			{
				lstGroups.Items[lstGroups.SelectedIndices[i]].Selected = false;
			}
		}
	}

	private void label1_Click(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditGroupSortOrder));
		lstGroups = new ListView();
		columnHeader_0 = new ColumnHeader();
		label3 = new Label();
		btnCancel = new Button();
		btnOkay = new Button();
		label9 = new Label();
		btnRemoveRow = new Button();
		btnAddEmptyRow = new Button();
		btnDown = new Button();
		btnUp = new Button();
		label2 = new Label();
		label4 = new Label();
		listView_0 = new ListView();
		columnHeader_1 = new ColumnHeader();
		ddlGroups = new Class19();
		label8 = new Label();
		label1 = new Label();
		ddlClassification = new Class19();
		SuspendLayout();
		lstGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		lstGroups.BorderStyle = BorderStyle.None;
		lstGroups.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstGroups.Font = new Font("Microsoft Sans Serif", 14f);
		lstGroups.FullRowSelect = true;
		lstGroups.GridLines = true;
		lstGroups.HeaderStyle = ColumnHeaderStyle.None;
		lstGroups.HideSelection = false;
		lstGroups.Location = new Point(360, 190);
		lstGroups.Margin = new Padding(4);
		lstGroups.MultiSelect = false;
		lstGroups.Name = "lstGroups";
		lstGroups.Size = new Size(336, 491);
		lstGroups.TabIndex = 236;
		lstGroups.TileSize = new Size(50, 200);
		lstGroups.UseCompatibleStateImageBehavior = false;
		lstGroups.View = View.Details;
		lstGroups.Click += lstGroups_Click;
		columnHeader_0.Text = "Group Name";
		columnHeader_0.Width = 520;
		label3.BackColor = Color.LemonChiffon;
		label3.Font = new Font("Microsoft Sans Serif", 8.25f);
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(1, 686);
		label3.Margin = new Padding(4, 0, 4, 0);
		label3.Name = "label3";
		label3.Padding = new Padding(7, 6, 7, 6);
		label3.Size = new Size(252, 95);
		label3.TabIndex = 235;
		label3.Text = "INSTRUCTIONS:  Select a row, and click up/down arrows to move the Groups into a new row.";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label3.UseWaitCursor = true;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(639, 686);
		btnCancel.Margin = new Padding(4);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(127, 95);
		btnCancel.TabIndex = 231;
		btnCancel.Text = "CLOSE";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		btnOkay.FlatStyle = FlatStyle.Flat;
		btnOkay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.ImeMode = ImeMode.NoControl;
		btnOkay.Location = new Point(511, 686);
		btnOkay.Margin = new Padding(4);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(127, 95);
		btnOkay.TabIndex = 230;
		btnOkay.Text = "SAVE";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(1, 1);
		label9.Margin = new Padding(4, 0, 4, 0);
		label9.Name = "label9";
		label9.Size = new Size(765, 57);
		label9.TabIndex = 229;
		label9.Text = "GROUP SORT ORDER";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		btnRemoveRow.BackColor = Color.SandyBrown;
		btnRemoveRow.FlatAppearance.BorderSize = 0;
		btnRemoveRow.FlatStyle = FlatStyle.Flat;
		btnRemoveRow.Font = new Font("Microsoft Sans Serif", 10f);
		btnRemoveRow.ForeColor = SystemColors.ButtonFace;
		btnRemoveRow.ImeMode = ImeMode.NoControl;
		btnRemoveRow.Location = new Point(383, 686);
		btnRemoveRow.Margin = new Padding(4);
		btnRemoveRow.Name = "btnRemoveRow";
		btnRemoveRow.Size = new Size(127, 95);
		btnRemoveRow.TabIndex = 240;
		btnRemoveRow.Text = "REMOVE EMPTY SPOT";
		btnRemoveRow.UseVisualStyleBackColor = false;
		btnRemoveRow.Click += btnRemoveRow_Click;
		btnAddEmptyRow.BackColor = Color.FromArgb(50, 119, 155);
		btnAddEmptyRow.FlatAppearance.BorderSize = 0;
		btnAddEmptyRow.FlatStyle = FlatStyle.Flat;
		btnAddEmptyRow.Font = new Font("Microsoft Sans Serif", 10f);
		btnAddEmptyRow.ForeColor = SystemColors.ButtonFace;
		btnAddEmptyRow.ImeMode = ImeMode.NoControl;
		btnAddEmptyRow.Location = new Point(255, 686);
		btnAddEmptyRow.Margin = new Padding(4);
		btnAddEmptyRow.Name = "btnAddEmptyRow";
		btnAddEmptyRow.Size = new Size(127, 95);
		btnAddEmptyRow.TabIndex = 239;
		btnAddEmptyRow.Text = "ADD EMPTY SPOT";
		btnAddEmptyRow.UseVisualStyleBackColor = false;
		btnAddEmptyRow.Click += btnAddEmptyRow_Click;
		btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnDown.FlatStyle = FlatStyle.Flat;
		btnDown.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnDown.ForeColor = Color.White;
		btnDown.Image = (Image)componentResourceManager.GetObject("btnDown.Image");
		btnDown.ImeMode = ImeMode.NoControl;
		btnDown.Location = new Point(699, 417);
		btnDown.Margin = new Padding(0, 0, 0, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new Size(67, 263);
		btnDown.TabIndex = 238;
		btnDown.Tag = "";
		btnDown.TextAlign = ContentAlignment.BottomCenter;
		btnDown.UseVisualStyleBackColor = false;
		btnDown.Click += btnDown_Click;
		btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnUp.FlatStyle = FlatStyle.Flat;
		btnUp.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnUp.ForeColor = Color.White;
		btnUp.Image = (Image)componentResourceManager.GetObject("btnUp.Image");
		btnUp.ImeMode = ImeMode.NoControl;
		btnUp.Location = new Point(699, 147);
		btnUp.Margin = new Padding(0, 0, 0, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(67, 263);
		btnUp.TabIndex = 237;
		btnUp.Tag = "";
		btnUp.TextAlign = ContentAlignment.BottomCenter;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		label2.BackColor = SystemColors.GrayText;
		label2.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(360, 148);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.Name = "label2";
		label2.Padding = new Padding(7, 0, 0, 0);
		label2.Size = new Size(336, 39);
		label2.TabIndex = 241;
		label2.Text = "NON HIGH TRAFFIC";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		label4.BackColor = SystemColors.GrayText;
		label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(1, 148);
		label4.Margin = new Padding(4, 0, 4, 0);
		label4.Name = "label4";
		label4.Padding = new Padding(7, 0, 0, 0);
		label4.Size = new Size(357, 39);
		label4.TabIndex = 242;
		label4.Text = "HIGH TRAFFIC";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		listView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		listView_0.BorderStyle = BorderStyle.None;
		listView_0.Columns.AddRange(new ColumnHeader[1] { columnHeader_1 });
		listView_0.Font = new Font("Microsoft Sans Serif", 14f);
		listView_0.FullRowSelect = true;
		listView_0.GridLines = true;
		listView_0.HeaderStyle = ColumnHeaderStyle.None;
		listView_0.HideSelection = false;
		listView_0.Location = new Point(3, 190);
		listView_0.Margin = new Padding(4);
		listView_0.MultiSelect = false;
		listView_0.Name = "lstHTGroups";
		listView_0.Size = new Size(356, 491);
		listView_0.TabIndex = 243;
		listView_0.TileSize = new Size(50, 200);
		listView_0.UseCompatibleStateImageBehavior = false;
		listView_0.View = View.Details;
		listView_0.Click += listView_0_Click;
		columnHeader_1.Text = "Group Name";
		columnHeader_1.Width = 520;
		ddlGroups.BackColor = Color.White;
		ddlGroups.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroups.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlGroups.FlatStyle = FlatStyle.Flat;
		ddlGroups.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlGroups.FormattingEnabled = true;
		ddlGroups.ItemHeight = 28;
		ddlGroups.Location = new Point(166, 106);
		ddlGroups.Margin = new Padding(5, 6, 5, 6);
		ddlGroups.Name = "ddlGroups";
		ddlGroups.Size = new Size(600, 34);
		ddlGroups.TabIndex = 245;
		ddlGroups.SelectedIndexChanged += ddlGroups_SelectedIndexChanged;
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = Color.White;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(3, 105);
		label8.Margin = new Padding(5, 0, 5, 0);
		label8.MinimumSize = new Size(160, 42);
		label8.Name = "label8";
		label8.Size = new Size(160, 42);
		label8.TabIndex = 244;
		label8.Text = "Select Group";
		label8.TextAlign = ContentAlignment.MiddleLeft;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(3, 60);
		label1.Margin = new Padding(5, 0, 5, 0);
		label1.MinimumSize = new Size(160, 42);
		label1.Name = "label1";
		label1.Size = new Size(160, 42);
		label1.TabIndex = 246;
		label1.Text = "Classification";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label1.Click += label1_Click;
		ddlClassification.BackColor = Color.White;
		ddlClassification.DrawMode = DrawMode.OwnerDrawVariable;
		ddlClassification.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlClassification.FlatStyle = FlatStyle.Flat;
		ddlClassification.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlClassification.FormattingEnabled = true;
		ddlClassification.ItemHeight = 28;
		ddlClassification.Location = new Point(165, 60);
		ddlClassification.Margin = new Padding(5, 6, 5, 6);
		ddlClassification.Name = "ddlClassification";
		ddlClassification.Size = new Size(600, 34);
		ddlClassification.TabIndex = 247;
		ddlClassification.SelectedIndexChanged += ddlClassification_SelectedIndexChanged;
		base.AutoScaleDimensions = new SizeF(8f, 16f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(772, 790);
		base.Controls.Add(ddlClassification);
		base.Controls.Add(label1);
		base.Controls.Add(ddlGroups);
		base.Controls.Add(label8);
		base.Controls.Add(listView_0);
		base.Controls.Add(label4);
		base.Controls.Add(label2);
		base.Controls.Add(lstGroups);
		base.Controls.Add(label3);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label9);
		base.Controls.Add(btnRemoveRow);
		base.Controls.Add(btnAddEmptyRow);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Margin = new Padding(5);
		base.Name = "frmEditGroupSortOrder";
		base.Opacity = 1.0;
		Text = "frmEditGroupSortOrder";
		ResumeLayout(performLayout: false);
	}
}
