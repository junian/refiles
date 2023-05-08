using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmEditOptionSortOrder : frmMasterForm
{
	private int int_0;

	private string string_0;

	private string string_1;

	private IContainer icontainer_1;

	private Label label3;

	private Label label1;

	private Button btnCancel;

	private Button btnOkay;

	private Label label9;

	internal ColumnHeader columnHeader_0;

	private VScrollBar vScrollBar1;

	internal Button btnDown;

	internal Button btnUp;

	internal ListView lstOptions;

	private Label lblTab;

	private Label label2;

	private Label lblItemName;

	private Label label5;

	private Button btnRemoveRow;

	private Button btnAddEmptyRow;

	private Class19 xqdgdpoubr;

	private Label label8;

	public frmEditOptionSortOrder(int ItemId, string ItemName, string tab)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		string_0 = ItemName;
		int_0 = ItemId;
		string_1 = tab;
		lblItemName.Text = string_0;
		lblTab.Text = string_1;
	}

	private void frmEditOptionSortOrder_Load(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Option, withShowItems: false, onlyActive: true);
		groups.Remove(0.ToString());
		groups.Add(0.ToString(), "** " + Resources.No_Option_Groups + " **");
		CS_0024_003C_003E8__locals0.listOfRelatedGroups = (from a in gClass.usp_ItemOptions()
			where a.ItemID == CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 && a.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_1.ToUpper() && !a.ToBeDeleted
			select a.GroupID.ToString()).ToList();
		groups = groups.Where((KeyValuePair<string, string> a) => CS_0024_003C_003E8__locals0.listOfRelatedGroups.Contains(a.Key)).ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> a) => a.Value);
		xqdgdpoubr.DisplayMember = "Value";
		xqdgdpoubr.ValueMember = "Key";
		xqdgdpoubr.DataSource = new BindingSource(groups, null);
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstOptions.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an option to move.", NotificationTypes.Notification).Show();
			return;
		}
		int index = lstOptions.SelectedItems[0].Index;
		if (index > 0)
		{
			ListViewItem item = lstOptions.Items[index];
			lstOptions.Items.RemoveAt(index);
			lstOptions.Items.Insert(index - 1, item);
			lstOptions.Items[index - 1].EnsureVisible();
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstOptions.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an option to move.", NotificationTypes.Notification).Show();
			return;
		}
		int index = lstOptions.SelectedItems[0].Index;
		ListViewItem item = lstOptions.Items[index];
		if (index < lstOptions.Items.Count - 1)
		{
			lstOptions.Items.RemoveAt(index);
			lstOptions.Items.Insert(index + 1, item);
			lstOptions.Items[index + 1].EnsureVisible();
		}
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		short num = 0;
		foreach (ListViewItem item in lstOptions.Items)
		{
			if (!string.IsNullOrEmpty(item.SubItems[1].Text))
			{
				_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
				CS_0024_003C_003E8__locals0.itemsWithOptionID = Convert.ToInt32(item.SubItems[1].Text);
				ItemsWithOption itemsWithOption = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemWithOptionID == CS_0024_003C_003E8__locals0.itemsWithOptionID).FirstOrDefault();
				if (itemsWithOption != null)
				{
					itemsWithOption.SortOrder = num;
					itemsWithOption.Synced = false;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			num = (short)(num + 1);
		}
		new NotificationLabel(this, "Sort Orders have been successfully saved.", NotificationTypes.Success).Show();
		base.DialogResult = DialogResult.None;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnAddEmptyRow_Click(object sender, EventArgs e)
	{
		if (lstOptions.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, Resources.Please_select_an_item_to_add_t, NotificationTypes.Notification).Show();
			return;
		}
		int index = lstOptions.SelectedItems[0].Index;
		ListViewItem item = new ListViewItem(new string[2]
		{
			string.Empty,
			string.Empty
		});
		lstOptions.Items.Insert(index + 1, item);
		lstOptions.Items[index + 1].Selected = true;
	}

	private void btnRemoveRow_Click(object sender, EventArgs e)
	{
		if (lstOptions.SelectedItems.Count != 0 && !(lstOptions.SelectedItems[0].SubItems[1].Text != string.Empty))
		{
			int index = lstOptions.SelectedItems[0].Index;
			lstOptions.Items[index].Remove();
			if (index < lstOptions.Items.Count)
			{
				lstOptions.Items[index].Selected = true;
			}
			else
			{
				lstOptions.Items[lstOptions.Items.Count - 1].Selected = true;
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_an_empty_spot_to, NotificationTypes.Notification).Show();
		}
	}

	private void xqdgdpoubr_SelectedIndexChanged(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		lstOptions.Items.Clear();
		CS_0024_003C_003E8__locals0.temp = (KeyValuePair<string, string>)xqdgdpoubr.SelectedItem;
		GClass6 gClass = new GClass6();
		List<usp_ItemOptionsResult> list = (from a in gClass.usp_ItemOptions()
			where a.ItemID == CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 && !a.ToBeDeleted && a.Tab.ToUpper() == CS_0024_003C_003E8__locals0._003C_003E4__this.string_1.ToUpper() && a.GroupID == Convert.ToInt16(CS_0024_003C_003E8__locals0.temp.Key)
			orderby a.OptionSortOrder
			select a).ToList();
		int num = 0;
		using (List<usp_ItemOptionsResult>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass11_1();
				CS_0024_003C_003E8__locals1.iwo = enumerator.Current;
				if (num < CS_0024_003C_003E8__locals1.iwo.OptionSortOrder && CS_0024_003C_003E8__locals1.iwo.OptionSortOrder > 0)
				{
					do
					{
						lstOptions.Items.Add(new ListViewItem(new string[2]
						{
							string.Empty,
							string.Empty
						}));
						num++;
					}
					while (num < CS_0024_003C_003E8__locals1.iwo.OptionSortOrder);
				}
				Item item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.iwo.Option_ItemID).FirstOrDefault();
				lstOptions.Items.Add(new ListViewItem(new string[2]
				{
					item.ItemName,
					CS_0024_003C_003E8__locals1.iwo.ItemWithOptionID.ToString()
				}));
				num++;
			}
		}
		if (lstOptions.Items.Count * 20 > lstOptions.Height)
		{
			vScrollBar1.Visible = true;
			vScrollBar1.Minimum = 0;
			vScrollBar1.Maximum = ((lstOptions.Items.Count > 10) ? (lstOptions.Items.Count - 5) : 0);
			vScrollBar1.Value = ((lstOptions.Items.Count > 0) ? lstOptions.TopItem.Index : 0);
		}
		else
		{
			vScrollBar1.Visible = false;
		}
	}

	private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
		if (lstOptions.Items.Count > 0)
		{
			lstOptions.TopItem = lstOptions.Items[vScrollBar1.Value];
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditOptionSortOrder));
		lblItemName = new Label();
		label5 = new Label();
		lblTab = new Label();
		label2 = new Label();
		label3 = new Label();
		label1 = new Label();
		btnCancel = new Button();
		btnOkay = new Button();
		label9 = new Label();
		vScrollBar1 = new VScrollBar();
		btnDown = new Button();
		btnUp = new Button();
		lstOptions = new ListView();
		columnHeader_0 = new ColumnHeader();
		btnRemoveRow = new Button();
		btnAddEmptyRow = new Button();
		xqdgdpoubr = new Class19();
		label8 = new Label();
		SuspendLayout();
		lblItemName.BackColor = SystemColors.AppWorkspace;
		lblItemName.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblItemName.ImeMode = ImeMode.NoControl;
		lblItemName.Location = new Point(124, 86);
		lblItemName.Name = "lblItemName";
		lblItemName.Size = new Size(452, 35);
		lblItemName.TabIndex = 245;
		lblItemName.Text = "Item Name";
		lblItemName.TextAlign = ContentAlignment.MiddleLeft;
		label5.BackColor = Color.Gray;
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(3, 86);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(0, 35);
		label5.Name = "label5";
		label5.Padding = new Padding(0, 0, 5, 0);
		label5.Size = new Size(120, 35);
		label5.TabIndex = 244;
		label5.Text = "Item Name";
		label5.TextAlign = ContentAlignment.MiddleRight;
		lblTab.BackColor = SystemColors.AppWorkspace;
		lblTab.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblTab.ImeMode = ImeMode.NoControl;
		lblTab.Location = new Point(124, 50);
		lblTab.Name = "lblTab";
		lblTab.Size = new Size(452, 35);
		lblTab.TabIndex = 243;
		lblTab.Text = "Tab";
		lblTab.TextAlign = ContentAlignment.MiddleLeft;
		label2.BackColor = Color.Gray;
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(3, 50);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(0, 35);
		label2.Name = "label2";
		label2.Padding = new Padding(0, 0, 5, 0);
		label2.Size = new Size(120, 35);
		label2.TabIndex = 242;
		label2.Text = "Tab";
		label2.TextAlign = ContentAlignment.MiddleRight;
		label3.BackColor = Color.LemonChiffon;
		label3.Font = new Font("Microsoft Sans Serif", 8.25f);
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(3, 561);
		label3.Name = "label3";
		label3.Padding = new Padding(5);
		label3.Size = new Size(189, 80);
		label3.TabIndex = 235;
		label3.Text = "INSTRUCTIONS: Select a Main Item to load the options into the list.  Select a row, and click up/down arrows to move the options into a new row.";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label3.UseWaitCursor = true;
		label1.BackColor = SystemColors.GrayText;
		label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(3, 158);
		label1.Name = "label1";
		label1.Padding = new Padding(5, 0, 0, 0);
		label1.Size = new Size(573, 37);
		label1.TabIndex = 234;
		label1.Text = "Options";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(481, 561);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(95, 80);
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
		btnOkay.Location = new Point(385, 561);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(95, 80);
		btnOkay.TabIndex = 230;
		btnOkay.Text = "SAVE";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(3, 3);
		label9.Name = "label9";
		label9.Size = new Size(573, 46);
		label9.TabIndex = 229;
		label9.Text = "OPTION SORT ORDER";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		vScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		vScrollBar1.ImeMode = ImeMode.NoControl;
		vScrollBar1.Location = new Point(486, 196);
		vScrollBar1.Name = "vScrollBar1";
		vScrollBar1.Size = new Size(38, 362);
		vScrollBar1.TabIndex = 241;
		vScrollBar1.Scroll += vScrollBar1_Scroll;
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
		btnDown.Location = new Point(525, 390);
		btnDown.Margin = new Padding(0, 0, 0, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new Size(50, 173);
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
		btnUp.Location = new Point(525, 196);
		btnUp.Margin = new Padding(0, 0, 0, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(50, 193);
		btnUp.TabIndex = 237;
		btnUp.Tag = "";
		btnUp.TextAlign = ContentAlignment.BottomCenter;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		lstOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		lstOptions.BorderStyle = BorderStyle.None;
		lstOptions.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstOptions.Font = new Font("Microsoft Sans Serif", 14f);
		lstOptions.FullRowSelect = true;
		lstOptions.GridLines = true;
		lstOptions.HeaderStyle = ColumnHeaderStyle.None;
		lstOptions.HideSelection = false;
		lstOptions.Location = new Point(4, 196);
		lstOptions.MinimumSize = new Size(410, 350);
		lstOptions.MultiSelect = false;
		lstOptions.Name = "lstOptions";
		lstOptions.Size = new Size(520, 364);
		lstOptions.TabIndex = 236;
		lstOptions.TileSize = new Size(50, 200);
		lstOptions.UseCompatibleStateImageBehavior = false;
		lstOptions.View = View.Details;
		columnHeader_0.Text = "Item Name";
		columnHeader_0.Width = 480;
		btnRemoveRow.BackColor = Color.SandyBrown;
		btnRemoveRow.FlatAppearance.BorderSize = 0;
		btnRemoveRow.FlatStyle = FlatStyle.Flat;
		btnRemoveRow.Font = new Font("Microsoft Sans Serif", 10f);
		btnRemoveRow.ForeColor = SystemColors.ButtonFace;
		btnRemoveRow.ImeMode = ImeMode.NoControl;
		btnRemoveRow.Location = new Point(289, 561);
		btnRemoveRow.Name = "btnRemoveRow";
		btnRemoveRow.Size = new Size(95, 79);
		btnRemoveRow.TabIndex = 247;
		btnRemoveRow.Text = "REMOVE EMPTY SPOT";
		btnRemoveRow.UseVisualStyleBackColor = false;
		btnRemoveRow.Click += btnRemoveRow_Click;
		btnAddEmptyRow.BackColor = Color.FromArgb(50, 119, 155);
		btnAddEmptyRow.FlatAppearance.BorderSize = 0;
		btnAddEmptyRow.FlatStyle = FlatStyle.Flat;
		btnAddEmptyRow.Font = new Font("Microsoft Sans Serif", 10f);
		btnAddEmptyRow.ForeColor = SystemColors.ButtonFace;
		btnAddEmptyRow.ImeMode = ImeMode.NoControl;
		btnAddEmptyRow.Location = new Point(193, 561);
		btnAddEmptyRow.Name = "btnAddEmptyRow";
		btnAddEmptyRow.Size = new Size(95, 79);
		btnAddEmptyRow.TabIndex = 246;
		btnAddEmptyRow.Text = "ADD EMPTY SPOT";
		btnAddEmptyRow.UseVisualStyleBackColor = false;
		btnAddEmptyRow.Click += btnAddEmptyRow_Click;
		xqdgdpoubr.BackColor = Color.White;
		xqdgdpoubr.DrawMode = DrawMode.OwnerDrawVariable;
		xqdgdpoubr.DropDownStyle = ComboBoxStyle.DropDownList;
		xqdgdpoubr.FlatStyle = FlatStyle.Flat;
		xqdgdpoubr.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		xqdgdpoubr.FormattingEnabled = true;
		xqdgdpoubr.ItemHeight = 28;
		xqdgdpoubr.Location = new Point(124, 123);
		xqdgdpoubr.Margin = new Padding(4, 5, 4, 5);
		xqdgdpoubr.Name = "ddlOptionGroups";
		xqdgdpoubr.Size = new Size(451, 34);
		xqdgdpoubr.TabIndex = 249;
		xqdgdpoubr.SelectedIndexChanged += xqdgdpoubr_SelectedIndexChanged;
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = Color.White;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(3, 122);
		label8.Margin = new Padding(4, 0, 4, 0);
		label8.MinimumSize = new Size(120, 34);
		label8.Name = "label8";
		label8.Size = new Size(120, 35);
		label8.TabIndex = 248;
		label8.Text = "Option Groups";
		label8.TextAlign = ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(579, 642);
		base.Controls.Add(xqdgdpoubr);
		base.Controls.Add(label8);
		base.Controls.Add(btnRemoveRow);
		base.Controls.Add(btnAddEmptyRow);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label5);
		base.Controls.Add(lblTab);
		base.Controls.Add(label2);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label9);
		base.Controls.Add(vScrollBar1);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lstOptions);
		base.Name = "frmEditOptionSortOrder";
		base.Opacity = 1.0;
		Text = "frmEditOptionSortOrder";
		base.Load += frmEditOptionSortOrder_Load;
		base.Controls.SetChildIndex(lstOptions, 0);
		base.Controls.SetChildIndex(btnUp, 0);
		base.Controls.SetChildIndex(btnDown, 0);
		base.Controls.SetChildIndex(vScrollBar1, 0);
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(btnOkay, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(lblTab, 0);
		base.Controls.SetChildIndex(label5, 0);
		base.Controls.SetChildIndex(lblItemName, 0);
		base.Controls.SetChildIndex(btnAddEmptyRow, 0);
		base.Controls.SetChildIndex(btnRemoveRow, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex(xqdgdpoubr, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		ResumeLayout(performLayout: false);
	}
}
