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

public class frmAddItemInGroup : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public frmAddItemInGroup _003C_003E4__this;

		public Class17 chk;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public Item item;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass6_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int itemId;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public Class17 chk;

		public _003C_003Ec__DisplayClass14_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003ClistViewGroup_MouseClick_003Eb__1(ItemsInGroup x)
		{
			return x.GroupID == short.Parse(chk.Text);
		}
	}

	private List<Item> list_2;

	private string string_0;

	private IContainer icontainer_1;

	private Label label1;

	private Label label2;

	private ListView listViewItem;

	private Panel panel1;

	private RadioButton radioAll;

	private RadioButton radioAssociated;

	private RadioButton radioShowNonAssociated;

	private Label label10;

	private Label label3;

	private BindingSource bindingSource_0;

	private ComboBox selectAssociatedItemsGroup;

	private CheckBox chkMaterialsOnly;

	internal Button btnSetSortOrder;

	private Panel testPanel;

	internal Button btnRefresh;

	private ColumnHeader columnHeader_0;

	public frmAddItemInGroup()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = ItemClassifications.Product;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		listViewItem.ShowGroups = false;
		radioShowNonAssociated.Checked = true;
		method_4();
		selectAssociatedItemsGroup.Enabled = false;
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		method_3();
	}

	private void method_3()
	{
		label1.Width = ControlHelpers.ControlWidthFixer(this, 6.0);
		label2.Width = ControlHelpers.ControlWidthFixer(this, 6.0) - 2;
		label2.Location = new Point(label1.Right + 1, label2.Location.Y);
		listViewItem.Width = ControlHelpers.ControlWidthFixer(this, 6.0);
		listViewItem.Height = listViewItem.Height + base.Bounds.Height - panel1.Bottom - 3;
		testPanel.Width = ControlHelpers.ControlWidthFixer(this, 6.0) - 2;
		testPanel.Height = testPanel.Height + base.Bounds.Height - testPanel.Bottom - 3;
		testPanel.Location = new Point(listViewItem.Right + 1, testPanel.Location.Y);
		btnSetSortOrder.Width = ControlHelpers.ControlWidthFixer(this, 3.0);
		btnSetSortOrder.Location = new Point(btnSetSortOrder.Location.X, listViewItem.Bottom + 1);
		btnRefresh.Width = ControlHelpers.ControlWidthFixer(this, 3.0) - 2;
		btnRefresh.Location = new Point(btnSetSortOrder.Right + 1, listViewItem.Bottom + 1);
		panel1.Width = ControlHelpers.ControlWidthFixer(this, 6.0);
		panel1.Location = new Point(panel1.Location.X, btnSetSortOrder.Bottom + 1);
	}

	private void method_4()
	{
		testPanel.Controls.Clear();
		selectAssociatedItemsGroup.DisplayMember = "Value";
		selectAssociatedItemsGroup.ValueMember = "Key";
		selectAssociatedItemsGroup.DataSource = new BindingSource(AdminMethods.getGroups(string_0), null);
		Dictionary<string, string> groups = AdminMethods.getGroups(string_0);
		groups.Remove("0");
		Point point = new Point(5, -10);
		foreach (KeyValuePair<string, string> item in groups)
		{
			Class17 @class = new Class17(30, 30, 30, item.Key);
			testPanel.Controls.Add(@class);
			@class.Location = new Point(point.X, point.Y + 10);
			@class.Click += method_5;
			@class.Name = item.Value;
			point = new Point(@class.Location.X, @class.Bottom);
			Label label = new Label();
			label.Text = item.Value.Replace("&", "&&");
			label.Font = listViewItem.Font;
			label.AutoSize = true;
			testPanel.Controls.Add(label);
			label.Location = new Point(@class.Left + 35, @class.Location.Y + @class.Height / 4);
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass6_.chk = sender as Class17;
		if (listViewItem.SelectedItems.Count > 0)
		{
			if (_003C_003Ec__DisplayClass6_.chk.Checked)
			{
				AdminMethods.doAssociateItemAndGroup(short.Parse(_003C_003Ec__DisplayClass6_.chk.Text), Convert.ToInt16(listViewItem.SelectedItems[0].SubItems[1].Text), allowNew: true);
				new frmMessageBox(Resources.Please_select_an_item_color_an);
				return;
			}
			_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass6_;
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.item = gClass.Items.Where((Item x) => x.ItemID == Convert.ToInt32(listViewItem.SelectedItems[0].SubItems[1].Text) && x.isDeleted == false).FirstOrDefault();
			ItemsInGroup itemsInGroup = gClass.ItemsInGroups.Where((ItemsInGroup x) => x.ItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID && (int?)x.GroupID == (int?)short.Parse(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.chk.Text)).FirstOrDefault();
			if (itemsInGroup != null && CS_0024_003C_003E8__locals0.item != null)
			{
				gClass.ItemsInGroups.DeleteOnSubmit(itemsInGroup);
				CS_0024_003C_003E8__locals0.item.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		else
		{
			new frmMessageBox(Resources.Please_select_an_item_before_s).ShowDialog(this);
			_003C_003Ec__DisplayClass6_.chk.Checked = false;
		}
	}

	private void radioShowNonAssociated_CheckedChanged(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_6()
	{
		base.UseWaitCursor = true;
		Application.DoEvents();
		if (radioShowNonAssociated.Checked)
		{
			list_2 = AdminMethods.getNonAssociatedItems(string_0);
			selectAssociatedItemsGroup.Enabled = false;
		}
		else if (radioAssociated.Checked)
		{
			list_2 = AdminMethods.getAssociatedItems(string_0);
			selectAssociatedItemsGroup.Enabled = true;
			selectAssociatedItemsGroup.SelectedIndex = 0;
		}
		else if (radioAll.Checked)
		{
			list_2 = AdminMethods.getAllItems(string_0);
			selectAssociatedItemsGroup.Enabled = false;
		}
		method_7();
		base.UseWaitCursor = false;
	}

	private void method_7()
	{
		base.UseWaitCursor = true;
		Application.DoEvents();
		listViewItem.Items.Clear();
		foreach (Item item in list_2)
		{
			try
			{
				ListViewItem value = new ListViewItem(new string[2]
				{
					(item.ItemsInGroups.Count() > 0) ? (item.ItemsInGroups[0].Group.GroupName + ": " + item.ItemName) : item.ItemName,
					item.ItemID.ToString()
				});
				listViewItem.Items.Add(value);
			}
			catch
			{
			}
		}
		base.UseWaitCursor = false;
	}

	private void method_8(object sender, EventArgs e)
	{
		Close();
	}

	private void selectAssociatedItemsGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (radioAssociated.Checked)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)selectAssociatedItemsGroup.SelectedItem;
			if (keyValuePair.Key != "0")
			{
				list_2 = AdminMethods.getItemsFromGroup(short.Parse(keyValuePair.Key));
				method_7();
			}
			else
			{
				list_2 = AdminMethods.getAssociatedItems(string_0);
				method_7();
			}
		}
	}

	private void chkMaterialsOnly_CheckedChanged(object sender, EventArgs e)
	{
		string_0 = ItemClassifications.Product;
		if (chkMaterialsOnly.Checked)
		{
			string_0 = ItemClassifications.Material;
		}
		method_6();
		method_4();
	}

	private void btnSetSortOrder_Click(object sender, EventArgs e)
	{
		new frmEditItemSortOrder().ShowDialog(this);
	}

	private void listViewItem_MouseClick(object sender, MouseEventArgs e)
	{
		if (listViewItem.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.itemId = Convert.ToInt32(listViewItem.SelectedItems[0].SubItems[1].Text);
			List<ItemsInGroup> source = gClass.ItemsInGroups.Where((ItemsInGroup x) => x.ItemID == (int?)CS_0024_003C_003E8__locals0.itemId).ToList();
			using IEnumerator<Class17> enumerator = testPanel.Controls.OfType<Class17>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_1();
				CS_0024_003C_003E8__locals1.chk = enumerator.Current;
				if (source.FirstOrDefault((ItemsInGroup x) => x.GroupID == short.Parse(CS_0024_003C_003E8__locals1.chk.Text)) != null)
				{
					CS_0024_003C_003E8__locals1.chk.Checked = true;
				}
				else
				{
					CS_0024_003C_003E8__locals1.chk.Checked = false;
				}
			}
			return;
		}
		method_9();
	}

	private void btnRefresh_Click(object sender, EventArgs e)
	{
		method_6();
		method_9();
	}

	private void method_9()
	{
		foreach (Class17 item in testPanel.Controls.OfType<Class17>())
		{
			item.Checked = false;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddItemInGroup));
		label1 = new Label();
		label2 = new Label();
		listViewItem = new ListView();
		columnHeader_0 = new ColumnHeader();
		panel1 = new Panel();
		chkMaterialsOnly = new CheckBox();
		selectAssociatedItemsGroup = new ComboBox();
		radioAll = new RadioButton();
		radioAssociated = new RadioButton();
		radioShowNonAssociated = new RadioButton();
		label10 = new Label();
		label3 = new Label();
		bindingSource_0 = new BindingSource(icontainer_1);
		btnSetSortOrder = new Button();
		testPanel = new Panel();
		btnRefresh = new Button();
		panel1.SuspendLayout();
		((ISupportInitialize)bindingSource_0).BeginInit();
		SuspendLayout();
		label1.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.UseWaitCursor = true;
		label2.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label2.UseWaitCursor = true;
		listViewItem.BackColor = Color.White;
		listViewItem.BorderStyle = BorderStyle.None;
		listViewItem.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		listViewItem.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(listViewItem, "listViewItem");
		listViewItem.ForeColor = Color.FromArgb(40, 40, 40);
		listViewItem.FullRowSelect = true;
		listViewItem.Groups.AddRange(new ListViewGroup[1] { (ListViewGroup)componentResourceManager.GetObject("listViewItem.Groups") });
		listViewItem.HeaderStyle = ColumnHeaderStyle.None;
		listViewItem.HideSelection = false;
		listViewItem.Name = "listViewItem";
		listViewItem.UseCompatibleStateImageBehavior = false;
		listViewItem.View = View.Details;
		listViewItem.MouseClick += listViewItem_MouseClick;
		componentResourceManager.ApplyResources(columnHeader_0, "Filler");
		panel1.BackColor = Color.Gray;
		panel1.Controls.Add(chkMaterialsOnly);
		panel1.Controls.Add(selectAssociatedItemsGroup);
		panel1.Controls.Add(radioAll);
		panel1.Controls.Add(radioAssociated);
		panel1.Controls.Add(radioShowNonAssociated);
		panel1.ForeColor = Color.White;
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		panel1.UseWaitCursor = true;
		componentResourceManager.ApplyResources(chkMaterialsOnly, "chkMaterialsOnly");
		chkMaterialsOnly.ForeColor = Color.White;
		chkMaterialsOnly.Name = "chkMaterialsOnly";
		chkMaterialsOnly.UseVisualStyleBackColor = true;
		chkMaterialsOnly.UseWaitCursor = true;
		chkMaterialsOnly.CheckedChanged += chkMaterialsOnly_CheckedChanged;
		selectAssociatedItemsGroup.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(selectAssociatedItemsGroup, "selectAssociatedItemsGroup");
		selectAssociatedItemsGroup.FormattingEnabled = true;
		selectAssociatedItemsGroup.Name = "selectAssociatedItemsGroup";
		selectAssociatedItemsGroup.UseWaitCursor = true;
		selectAssociatedItemsGroup.SelectedIndexChanged += selectAssociatedItemsGroup_SelectedIndexChanged;
		componentResourceManager.ApplyResources(radioAll, "radioAll");
		radioAll.BackColor = Color.Transparent;
		radioAll.ForeColor = Color.White;
		radioAll.Name = "radioAll";
		radioAll.TabStop = true;
		radioAll.UseVisualStyleBackColor = false;
		radioAll.UseWaitCursor = true;
		radioAll.CheckedChanged += radioShowNonAssociated_CheckedChanged;
		componentResourceManager.ApplyResources(radioAssociated, "radioAssociated");
		radioAssociated.BackColor = Color.Transparent;
		radioAssociated.ForeColor = Color.White;
		radioAssociated.Name = "radioAssociated";
		radioAssociated.TabStop = true;
		radioAssociated.UseVisualStyleBackColor = false;
		radioAssociated.UseWaitCursor = true;
		radioAssociated.CheckedChanged += radioShowNonAssociated_CheckedChanged;
		componentResourceManager.ApplyResources(radioShowNonAssociated, "radioShowNonAssociated");
		radioShowNonAssociated.BackColor = Color.Transparent;
		radioShowNonAssociated.ForeColor = Color.White;
		radioShowNonAssociated.Name = "radioShowNonAssociated";
		radioShowNonAssociated.TabStop = true;
		radioShowNonAssociated.UseVisualStyleBackColor = false;
		radioShowNonAssociated.UseWaitCursor = true;
		radioShowNonAssociated.CheckedChanged += radioShowNonAssociated_CheckedChanged;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.LemonChiffon;
		label3.Name = "label3";
		label3.UseWaitCursor = true;
		btnSetSortOrder.BackColor = Color.FromArgb(214, 142, 81);
		btnSetSortOrder.FlatAppearance.BorderColor = Color.Black;
		btnSetSortOrder.FlatAppearance.BorderSize = 0;
		btnSetSortOrder.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSetSortOrder, "btnSetSortOrder");
		btnSetSortOrder.ForeColor = Color.White;
		btnSetSortOrder.Name = "btnSetSortOrder";
		btnSetSortOrder.UseVisualStyleBackColor = false;
		btnSetSortOrder.Click += btnSetSortOrder_Click;
		componentResourceManager.ApplyResources(testPanel, "testPanel");
		testPanel.BackColor = Color.White;
		testPanel.Name = "testPanel";
		btnRefresh.BackColor = Color.FromArgb(80, 203, 116);
		btnRefresh.FlatAppearance.BorderColor = Color.Black;
		btnRefresh.FlatAppearance.BorderSize = 0;
		btnRefresh.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnRefresh, "btnRefresh");
		btnRefresh.ForeColor = Color.White;
		btnRefresh.Name = "btnRefresh";
		btnRefresh.UseVisualStyleBackColor = false;
		btnRefresh.Click += btnRefresh_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(btnRefresh);
		base.Controls.Add(testPanel);
		base.Controls.Add(btnSetSortOrder);
		base.Controls.Add(label3);
		base.Controls.Add(label10);
		base.Controls.Add(panel1);
		base.Controls.Add(listViewItem);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAddItemInGroup";
		base.Opacity = 1.0;
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		((ISupportInitialize)bindingSource_0).EndInit();
		ResumeLayout(performLayout: false);
	}
}
