using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;

namespace CorePOS;

public class frmCopyMoveOptions : frmMasterForm
{
	private IContainer dZjntFigOj;

	private Label label9;

	internal ListView lstItemsLeft;

	internal ColumnHeader columnHeader_0;

	internal ListView lstItemsRight;

	internal ColumnHeader columnHeader_1;

	private Class19 ddlGroupLeft;

	private Label label8;

	private Label label1;

	private Class19 ddlGroupsRight;

	internal Button btnMove;

	internal Button btnCopy;

	private Label label2;

	private Button btnCancel;

	private Label label3;

	private Label label4;

	private Button btnRemoveRow;

	private Panel pnlOptionGroups;

	private Label label5;

	private Label label6;

	private Class17 chkRemoveAllOption;

	private Class17 chkRemoveAllOptGroup;

	private Label lblRemoveAllOpt;

	private Label lblRemoveAllOptGroup;

	private Label label7;

	internal Button btnCopyToAll;

	public frmCopyMoveOptions()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void VxaSbEbxCh(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ItemClassifications.Product, withShowItems: false, onlyActive: true);
		ddlGroupLeft.DisplayMember = "Value";
		ddlGroupLeft.ValueMember = "Key";
		ddlGroupLeft.DataSource = new BindingSource(groups, null);
		ddlGroupLeft.SelectedIndex = 0;
		ddlGroupsRight.DisplayMember = "Value";
		ddlGroupsRight.ValueMember = "Key";
		ddlGroupsRight.DataSource = new BindingSource(groups, null);
		ddlGroupsRight.SelectedIndex = 0;
	}

	private void ddlGroupLeft_SelectedIndexChanged(object sender, EventArgs e)
	{
		pnlOptionGroups.Controls.Clear();
		KeyValuePair<string, string> keyValuePair_ = (KeyValuePair<string, string>)ddlGroupLeft.SelectedItem;
		if (ddlGroupLeft.SelectedIndex > 0)
		{
			method_4(Class15.string_0, keyValuePair_);
		}
	}

	private void ddlGroupsRight_SelectedIndexChanged(object sender, EventArgs e)
	{
		KeyValuePair<string, string> keyValuePair_ = (KeyValuePair<string, string>)ddlGroupsRight.SelectedItem;
		if (ddlGroupsRight.SelectedIndex > 0)
		{
			method_4(Class15.string_1, keyValuePair_);
		}
	}

	private void method_4(string string_0, KeyValuePair<string, string> keyValuePair_0)
	{
		List<Item> list = (from a in AdminMethods.getItemsFromGroup(Convert.ToInt16(keyValuePair_0.Key))
			where a.Active
			select a).ToList();
		ListView listView = ((!(string_0 == Class15.string_0)) ? lstItemsRight : lstItemsLeft);
		listView.Items.Clear();
		foreach (Item item in list)
		{
			listView.Items.Add(new ListViewItem(new string[2]
			{
				item.ItemName,
				item.ItemID.ToString()
			}));
		}
	}

	private void btnCopy_Click(object sender, EventArgs e)
	{
		if (method_8())
		{
			method_5("copy");
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnMove_Click(object sender, EventArgs e)
	{
		if (method_8())
		{
			method_5("move");
			base.DialogResult = DialogResult.None;
		}
	}

	private void method_5(string string_0)
	{
		if (lstItemsLeft.SelectedItems.Count > 0 && lstItemsRight.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
			CS_0024_003C_003E8__locals0.leftItemID = Convert.ToInt32(lstItemsLeft.SelectedItems[0].SubItems[1].Text);
			CS_0024_003C_003E8__locals0.rightItemID = Convert.ToInt32(lstItemsRight.SelectedItems[0].SubItems[1].Text);
			GClass6 gClass = new GClass6();
			int num = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.leftItemID && a.ToBeDeleted == false).Count();
			gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.rightItemID && a.ToBeDeleted == false).Count();
			if (num == 0)
			{
				new NotificationLabel(this, "Item " + lstItemsLeft.SelectedItems[0].SubItems[0].Text + " has no item options.", NotificationTypes.Warning).Show();
				return;
			}
			CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList = new List<string>();
			foreach (object control in pnlOptionGroups.Controls)
			{
				if (control is Class17)
				{
					Class17 @class = control as Class17;
					if (@class.Checked)
					{
						CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList.Add(@class.Tag.ToString());
					}
				}
			}
			bool @checked = chkRemoveAllOption.Checked;
			bool checked2 = chkRemoveAllOptGroup.Checked;
			if (@checked || checked2)
			{
				List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.rightItemID).ToList();
				if (checked2)
				{
					list = list.Where((ItemsWithOption a) => CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList.Contains(a.GroupID + "-" + a.Tab)).ToList();
				}
				foreach (ItemsWithOption item in list)
				{
					item.ToBeDeleted = true;
					item.Synced = false;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			if (string_0 == "copy")
			{
				MavSyfAsXJ(CS_0024_003C_003E8__locals0.leftItemID, CS_0024_003C_003E8__locals0.rightItemID, bool_0: false, CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList);
			}
			else
			{
				MavSyfAsXJ(CS_0024_003C_003E8__locals0.leftItemID, CS_0024_003C_003E8__locals0.rightItemID, bool_0: true, CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList);
			}
			if (string_0 == "copy")
			{
				new NotificationLabel(this, "Options successfully copied.", NotificationTypes.Success).Show();
			}
			else
			{
				new NotificationLabel(this, "Options successfully moved.", NotificationTypes.Success).Show();
			}
			MemoryLoadedObjects.RefreshItemOptions = true;
			MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
		}
		else
		{
			new frmMessageBox("Please select an item.").ShowDialog(this);
		}
	}

	private void MavSyfAsXJ(int int_0, int int_1, bool bool_0, List<string> list_2)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.leftItemID = int_0;
		CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList = list_2;
		CS_0024_003C_003E8__locals0.rightItemID = int_1;
		GClass6 gClass = new GClass6();
		List<ItemsWithOption> list = (from a in gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.leftItemID && a.ToBeDeleted == false).ToList()
			where CS_0024_003C_003E8__locals0.selectedGroupsAndTabsByList.Contains(a.GroupID + "-" + a.Tab)
			select a).ToList();
		using (List<ItemsWithOption>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_1();
				CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals1.iol = enumerator.Current;
				ItemsWithOption itemsWithOption = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.rightItemID && a.OptionID == CS_0024_003C_003E8__locals1.iol.OptionID && a.GroupID == CS_0024_003C_003E8__locals1.iol.GroupID && a.Tab.ToUpper() == CS_0024_003C_003E8__locals1.iol.Tab.ToUpper()).FirstOrDefault();
				if (itemsWithOption != null)
				{
					itemsWithOption.GroupID = CS_0024_003C_003E8__locals1.iol.GroupID;
					itemsWithOption.Price = CS_0024_003C_003E8__locals1.iol.Price;
					itemsWithOption.Qty = CS_0024_003C_003E8__locals1.iol.Qty;
					itemsWithOption.SortOrder = CS_0024_003C_003E8__locals1.iol.SortOrder;
					itemsWithOption.AllowAdditional = CS_0024_003C_003E8__locals1.iol.AllowAdditional;
					itemsWithOption.MaxGroupOptions = CS_0024_003C_003E8__locals1.iol.MaxGroupOptions;
					itemsWithOption.MinGroupOptions = CS_0024_003C_003E8__locals1.iol.MinGroupOptions;
					itemsWithOption.Color = CS_0024_003C_003E8__locals1.iol.Color;
					itemsWithOption.SortOrder = CS_0024_003C_003E8__locals1.iol.SortOrder;
					itemsWithOption.Preselect = CS_0024_003C_003E8__locals1.iol.Preselect;
					itemsWithOption.Synced = false;
					itemsWithOption.ToBeDeleted = CS_0024_003C_003E8__locals1.iol.ToBeDeleted;
					itemsWithOption.GroupDependency = CS_0024_003C_003E8__locals1.iol.GroupDependency;
					itemsWithOption.GroupOrderTypes = CS_0024_003C_003E8__locals1.iol.GroupOrderTypes;
					itemsWithOption.OptionDependency = method_6(CS_0024_003C_003E8__locals1.iol.OptionDependency, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.rightItemID);
					itemsWithOption.ExcludeFromFreeOption = CS_0024_003C_003E8__locals1.iol.ExcludeFromFreeOption;
					continue;
				}
				Option option = gClass.Options.Where((Option a) => (int?)a.OptionID == CS_0024_003C_003E8__locals1.iol.OptionID).FirstOrDefault();
				if (option == null || option.ItemID != CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.rightItemID)
				{
					ItemsWithOption entity = new ItemsWithOption
					{
						ItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.rightItemID,
						OptionID = CS_0024_003C_003E8__locals1.iol.OptionID,
						Price = CS_0024_003C_003E8__locals1.iol.Price,
						Qty = CS_0024_003C_003E8__locals1.iol.Qty,
						Preselect = CS_0024_003C_003E8__locals1.iol.Preselect,
						GroupID = CS_0024_003C_003E8__locals1.iol.GroupID,
						SortOrder = CS_0024_003C_003E8__locals1.iol.SortOrder,
						Tab = CS_0024_003C_003E8__locals1.iol.Tab,
						AllowAdditional = CS_0024_003C_003E8__locals1.iol.AllowAdditional,
						MaxGroupOptions = CS_0024_003C_003E8__locals1.iol.MaxGroupOptions,
						MinGroupOptions = CS_0024_003C_003E8__locals1.iol.MinGroupOptions,
						Color = CS_0024_003C_003E8__locals1.iol.Color,
						Synced = false,
						ToBeDeleted = CS_0024_003C_003E8__locals1.iol.ToBeDeleted,
						GroupDependency = CS_0024_003C_003E8__locals1.iol.GroupDependency,
						GroupOrderTypes = CS_0024_003C_003E8__locals1.iol.GroupOrderTypes,
						OptionDependency = method_6(CS_0024_003C_003E8__locals1.iol.OptionDependency, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.rightItemID),
						ExcludeFromFreeOption = CS_0024_003C_003E8__locals1.iol.ExcludeFromFreeOption
					};
					gClass.ItemsWithOptions.InsertOnSubmit(entity);
				}
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
		if (!bool_0)
		{
			return;
		}
		foreach (ItemsWithOption item in list)
		{
			item.ToBeDeleted = true;
			item.Synced = false;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	private string method_6(string string_0, int int_0)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_.itemID = int_0;
		if (!string.IsNullOrEmpty(string_0) && string_0 != "0")
		{
			GClass6 gClass = new GClass6();
			string text = string.Empty;
			string[] array = string_0.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_2 = new _003C_003Ec__DisplayClass10_1();
				_003C_003Ec__DisplayClass10_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
				_003C_003Ec__DisplayClass10_2.itemOptionID = array[i];
				_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_2();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass10_2;
				CS_0024_003C_003E8__locals0.iwo = gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.ItemWithOptionID.ToString() == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.itemOptionID).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.iwo != null)
				{
					ItemsWithOption itemsWithOption = gClass.ItemsWithOptions.Where((ItemsWithOption x) => x.OptionID == CS_0024_003C_003E8__locals0.iwo.OptionID && x.ItemID == (int?)CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID).FirstOrDefault();
					if (itemsWithOption != null)
					{
						text += ((!string.IsNullOrEmpty(text)) ? ("," + itemsWithOption.ItemWithOptionID) : itemsWithOption.ItemWithOptionID.ToString());
						continue;
					}
					itemsWithOption = new ItemsWithOption
					{
						AllowAdditional = CS_0024_003C_003E8__locals0.iwo.AllowAdditional,
						Color = CS_0024_003C_003E8__locals0.iwo.Color,
						GroupDependency = CS_0024_003C_003E8__locals0.iwo.GroupDependency,
						GroupID = CS_0024_003C_003E8__locals0.iwo.GroupID,
						GroupOrderTypes = CS_0024_003C_003E8__locals0.iwo.GroupOrderTypes,
						ItemID = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID,
						MaxGroupOptions = CS_0024_003C_003E8__locals0.iwo.MaxGroupOptions,
						MinGroupOptions = CS_0024_003C_003E8__locals0.iwo.MinGroupOptions,
						OptionDependency = method_6(CS_0024_003C_003E8__locals0.iwo.OptionDependency, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemID),
						OptionID = CS_0024_003C_003E8__locals0.iwo.OptionID,
						Preselect = CS_0024_003C_003E8__locals0.iwo.Preselect,
						Price = CS_0024_003C_003E8__locals0.iwo.Price,
						Qty = CS_0024_003C_003E8__locals0.iwo.Qty,
						SortOrder = CS_0024_003C_003E8__locals0.iwo.SortOrder,
						Synced = false,
						Tab = CS_0024_003C_003E8__locals0.iwo.Tab,
						ToBeDeleted = false,
						ExcludeFromFreeOption = CS_0024_003C_003E8__locals0.iwo.ExcludeFromFreeOption
					};
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				return "0";
			}
			return text;
		}
		return string_0;
	}

	private void zonSpjouff(object sender, EventArgs e)
	{
		if (lstItemsLeft.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
			CS_0024_003C_003E8__locals0.leftItemID = Convert.ToInt32(lstItemsLeft.SelectedItems[0].SubItems[1].Text);
			GClass6 gClass = new GClass6();
			if (gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.leftItemID && a.ToBeDeleted == false).Count() == 0)
			{
				new NotificationLabel(this, "Item " + lstItemsLeft.SelectedItems[0].SubItems[0].Text + " has no item options.", NotificationTypes.Warning).Show();
			}
			if (new frmMessageBox("Are you sure you want to remove all Item Option of " + lstItemsLeft.SelectedItems[0].SubItems[0].Text + "?", "Remove Options", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No)
			{
				return;
			}
			List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.leftItemID && a.ToBeDeleted == false).ToList();
			if (list.Count > 0)
			{
				foreach (ItemsWithOption item in list)
				{
					item.ToBeDeleted = true;
					item.Synced = false;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			pnlOptionGroups.Controls.Clear();
			new NotificationLabel(this, "Options successfully removed.", NotificationTypes.Success).Show();
		}
		else
		{
			new frmMessageBox("Please select an item.").ShowDialog(this);
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void lstItemsLeft_SelectedIndexChanged(object sender, EventArgs e)
	{
		pnlOptionGroups.Controls.Clear();
		if (lstItemsLeft.SelectedItems.Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.leftItemID = Convert.ToInt32(lstItemsLeft.SelectedItems[0].SubItems[1].Text);
		GClass6 gClass = new GClass6();
		var source = from a in gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemID == (int?)CS_0024_003C_003E8__locals0.leftItemID && a.ToBeDeleted == false).ToList()
			group a by new { a.GroupID, a.Tab };
		int num = 0;
		using var enumerator = (from a in source
			orderby a.Key.Tab, a.Key.GroupID
			select a).GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass13_1();
			CS_0024_003C_003E8__locals1.a = enumerator.Current;
			string text = "No Option Group";
			if (CS_0024_003C_003E8__locals1.a.Key.GroupID != 0)
			{
				Group group = gClass.Groups.Where((Group b) => b.GroupID == CS_0024_003C_003E8__locals1.a.Key.GroupID).FirstOrDefault();
				if (group != null)
				{
					text = group.GroupName;
				}
			}
			method_7(new KeyValuePair<string, string>(CS_0024_003C_003E8__locals1.a.Key.GroupID + "-" + CS_0024_003C_003E8__locals1.a.Key.Tab, CS_0024_003C_003E8__locals1.a.Key.Tab.ToUpper() + "-" + text), num);
			num++;
		}
	}

	private void method_7(KeyValuePair<string, string> keyValuePair_0, int int_0)
	{
		Class17 @class = new Class17();
		@class.Name = keyValuePair_0.Value;
		@class.Tag = keyValuePair_0.Key;
		@class.Location = new Point(10, 40 * int_0 + 10);
		@class.Checked = true;
		pnlOptionGroups.Controls.Add(@class);
		Label label = new Label();
		label.Name = "lbl" + keyValuePair_0.Value;
		label.Text = keyValuePair_0.Value;
		label.Location = new Point(50, 40 * int_0 + 10);
		label.Size = new Size(300, 30);
		label.Font = new Font(label9.Font.FontFamily, 13f, FontStyle.Regular);
		label.ForeColor = Color.Black;
		label.BackColor = Color.White;
		label.TextAlign = ContentAlignment.MiddleLeft;
		pnlOptionGroups.Controls.Add(label);
		int_0++;
	}

	private void chkRemoveAllOption_CheckedChanged(object sender, EventArgs e)
	{
		if (chkRemoveAllOption.Checked)
		{
			chkRemoveAllOptGroup.Checked = false;
		}
	}

	private void bbrnSoptb3(object sender, EventArgs e)
	{
		if (chkRemoveAllOptGroup.Checked)
		{
			chkRemoveAllOption.Checked = false;
		}
	}

	private void btnCopyToAll_Click(object sender, EventArgs e)
	{
		if (!method_8() || DialogResult.Yes != new frmMessageBox("Are you sure you want to copy to all the items in the group?", "Copy All?", CustomMessageBoxButtons.YesNo).ShowDialog())
		{
			return;
		}
		foreach (ListViewItem item in lstItemsRight.Items)
		{
			if (lstItemsLeft.SelectedItems[0].SubItems[1].Text != item.SubItems[1].Text)
			{
				item.Selected = true;
				method_5("copy");
				base.DialogResult = DialogResult.None;
			}
		}
	}

	private bool method_8()
	{
		if (lstItemsLeft.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Please select From Main Item.", NotificationTypes.Warning).Show();
			return false;
		}
		return true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && dZjntFigOj != null)
		{
			dZjntFigOj.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCopyMoveOptions));
		label9 = new Label();
		lstItemsLeft = new ListView();
		columnHeader_0 = new ColumnHeader();
		lstItemsRight = new ListView();
		columnHeader_1 = new ColumnHeader();
		ddlGroupLeft = new Class19();
		label8 = new Label();
		label1 = new Label();
		ddlGroupsRight = new Class19();
		btnMove = new Button();
		btnCopy = new Button();
		label2 = new Label();
		btnCancel = new Button();
		label3 = new Label();
		label4 = new Label();
		btnRemoveRow = new Button();
		pnlOptionGroups = new Panel();
		label5 = new Label();
		label6 = new Label();
		chkRemoveAllOption = new Class17();
		chkRemoveAllOptGroup = new Class17();
		lblRemoveAllOpt = new Label();
		lblRemoveAllOptGroup = new Label();
		label7 = new Label();
		btnCopyToAll = new Button();
		SuspendLayout();
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(7, 9);
		label9.Name = "label9";
		label9.Size = new Size(1010, 38);
		label9.TabIndex = 230;
		label9.Text = "COPY/MOVE OPTIONS";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		lstItemsLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		lstItemsLeft.BorderStyle = BorderStyle.None;
		lstItemsLeft.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstItemsLeft.Font = new Font("Microsoft Sans Serif", 14f);
		lstItemsLeft.FullRowSelect = true;
		lstItemsLeft.GridLines = true;
		lstItemsLeft.HeaderStyle = ColumnHeaderStyle.None;
		lstItemsLeft.HideSelection = false;
		lstItemsLeft.Location = new Point(6, 153);
		lstItemsLeft.MultiSelect = false;
		lstItemsLeft.Name = "lstItemsLeft";
		lstItemsLeft.Size = new Size(301, 522);
		lstItemsLeft.TabIndex = 245;
		lstItemsLeft.TileSize = new Size(50, 200);
		lstItemsLeft.UseCompatibleStateImageBehavior = false;
		lstItemsLeft.View = View.Details;
		lstItemsLeft.SelectedIndexChanged += lstItemsLeft_SelectedIndexChanged;
		columnHeader_0.Text = "Group Name";
		columnHeader_0.Width = 520;
		lstItemsRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		lstItemsRight.BorderStyle = BorderStyle.None;
		lstItemsRight.Columns.AddRange(new ColumnHeader[1] { columnHeader_1 });
		lstItemsRight.Font = new Font("Microsoft Sans Serif", 14f);
		lstItemsRight.FullRowSelect = true;
		lstItemsRight.GridLines = true;
		lstItemsRight.HeaderStyle = ColumnHeaderStyle.None;
		lstItemsRight.HideSelection = false;
		lstItemsRight.Location = new Point(704, 154);
		lstItemsRight.MultiSelect = false;
		lstItemsRight.Name = "lstItemsRight";
		lstItemsRight.Size = new Size(313, 521);
		lstItemsRight.TabIndex = 244;
		lstItemsRight.TileSize = new Size(50, 200);
		lstItemsRight.UseCompatibleStateImageBehavior = false;
		lstItemsRight.View = View.Details;
		columnHeader_1.Text = "Group Name";
		columnHeader_1.Width = 520;
		ddlGroupLeft.BackColor = Color.White;
		ddlGroupLeft.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroupLeft.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlGroupLeft.FlatStyle = FlatStyle.Flat;
		ddlGroupLeft.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlGroupLeft.FormattingEnabled = true;
		ddlGroupLeft.ItemHeight = 28;
		ddlGroupLeft.Location = new Point(6, 82);
		ddlGroupLeft.Margin = new Padding(4, 5, 4, 5);
		ddlGroupLeft.Name = "ddlGroupLeft";
		ddlGroupLeft.Size = new Size(301, 34);
		ddlGroupLeft.TabIndex = 247;
		ddlGroupLeft.SelectedIndexChanged += ddlGroupLeft_SelectedIndexChanged;
		label8.BackColor = Color.FromArgb(132, 146, 146);
		label8.Font = new Font("Microsoft Sans Serif", 12f);
		label8.ForeColor = Color.White;
		label8.ImeMode = ImeMode.NoControl;
		label8.Location = new Point(6, 47);
		label8.Margin = new Padding(4, 0, 4, 0);
		label8.MinimumSize = new Size(120, 34);
		label8.Name = "label8";
		label8.Size = new Size(301, 34);
		label8.TabIndex = 246;
		label8.Text = "Select Group";
		label8.TextAlign = ContentAlignment.MiddleLeft;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(704, 47);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 34);
		label1.Name = "label1";
		label1.Size = new Size(313, 34);
		label1.TabIndex = 248;
		label1.Text = "Select Group";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		ddlGroupsRight.BackColor = Color.White;
		ddlGroupsRight.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGroupsRight.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlGroupsRight.FlatStyle = FlatStyle.Flat;
		ddlGroupsRight.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlGroupsRight.FormattingEnabled = true;
		ddlGroupsRight.ItemHeight = 28;
		ddlGroupsRight.Location = new Point(704, 82);
		ddlGroupsRight.Margin = new Padding(4, 5, 4, 5);
		ddlGroupsRight.Name = "ddlGroupsRight";
		ddlGroupsRight.Size = new Size(313, 34);
		ddlGroupsRight.TabIndex = 249;
		ddlGroupsRight.SelectedIndexChanged += ddlGroupsRight_SelectedIndexChanged;
		btnMove.BackColor = Color.Salmon;
		btnMove.FlatAppearance.BorderColor = Color.Black;
		btnMove.FlatAppearance.BorderSize = 0;
		btnMove.FlatAppearance.MouseDownBackColor = Color.White;
		btnMove.FlatStyle = FlatStyle.Flat;
		btnMove.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
		btnMove.ForeColor = Color.White;
		btnMove.Image = (Image)componentResourceManager.GetObject("btnMove.Image");
		btnMove.ImageAlign = ContentAlignment.TopCenter;
		btnMove.ImeMode = ImeMode.NoControl;
		btnMove.Location = new Point(623, 555);
		btnMove.Name = "btnMove";
		btnMove.Padding = new Padding(0, 20, 0, 20);
		btnMove.Size = new Size(80, 120);
		btnMove.TabIndex = 250;
		btnMove.Text = "MOVE";
		btnMove.TextAlign = ContentAlignment.BottomCenter;
		btnMove.UseVisualStyleBackColor = false;
		btnMove.Click += btnMove_Click;
		btnCopy.BackColor = Color.SandyBrown;
		btnCopy.FlatAppearance.BorderColor = Color.Black;
		btnCopy.FlatAppearance.BorderSize = 0;
		btnCopy.FlatAppearance.MouseDownBackColor = Color.White;
		btnCopy.FlatStyle = FlatStyle.Flat;
		btnCopy.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
		btnCopy.ForeColor = Color.White;
		btnCopy.Image = (Image)componentResourceManager.GetObject("btnCopy.Image");
		btnCopy.ImageAlign = ContentAlignment.TopCenter;
		btnCopy.ImeMode = ImeMode.NoControl;
		btnCopy.Location = new Point(623, 154);
		btnCopy.Name = "btnCopy";
		btnCopy.Padding = new Padding(0, 20, 0, 20);
		btnCopy.Size = new Size(80, 120);
		btnCopy.TabIndex = 251;
		btnCopy.Text = "COPY";
		btnCopy.TextAlign = ContentAlignment.BottomCenter;
		btnCopy.UseVisualStyleBackColor = false;
		btnCopy.Click += btnCopy_Click;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(308, 47);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.Name = "label2";
		label2.Size = new Size(395, 34);
		label2.TabIndex = 252;
		label2.TextAlign = ContentAlignment.MiddleLeft;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(840, 681);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(177, 80);
		btnCancel.TabIndex = 253;
		btnCancel.Text = "CLOSE";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		label3.BackColor = SystemColors.GrayText;
		label3.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(5, 117);
		label3.Name = "label3";
		label3.Padding = new Padding(5, 0, 0, 0);
		label3.Size = new Size(302, 35);
		label3.TabIndex = 254;
		label3.Text = "Items";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label4.BackColor = SystemColors.GrayText;
		label4.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(704, 117);
		label4.Name = "label4";
		label4.Padding = new Padding(5, 0, 0, 0);
		label4.Size = new Size(313, 35);
		label4.TabIndex = 255;
		label4.Text = "Items";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		btnRemoveRow.BackColor = Color.SandyBrown;
		btnRemoveRow.FlatAppearance.BorderSize = 0;
		btnRemoveRow.FlatStyle = FlatStyle.Flat;
		btnRemoveRow.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnRemoveRow.ForeColor = SystemColors.ButtonFace;
		btnRemoveRow.ImeMode = ImeMode.NoControl;
		btnRemoveRow.Location = new Point(6, 681);
		btnRemoveRow.Name = "btnRemoveRow";
		btnRemoveRow.Size = new Size(166, 80);
		btnRemoveRow.TabIndex = 256;
		btnRemoveRow.Text = "REMOVE ALL OPTIONS";
		btnRemoveRow.UseVisualStyleBackColor = false;
		btnRemoveRow.Click += zonSpjouff;
		pnlOptionGroups.AutoScroll = true;
		pnlOptionGroups.BackColor = Color.White;
		pnlOptionGroups.Location = new Point(308, 153);
		pnlOptionGroups.Margin = new Padding(10);
		pnlOptionGroups.Name = "pnlOptionGroups";
		pnlOptionGroups.Padding = new Padding(10);
		pnlOptionGroups.Size = new Size(314, 522);
		pnlOptionGroups.TabIndex = 257;
		label5.BackColor = SystemColors.GrayText;
		label5.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(308, 117);
		label5.Name = "label5";
		label5.Padding = new Padding(5, 0, 0, 0);
		label5.Size = new Size(395, 35);
		label5.TabIndex = 258;
		label5.Text = "Option Groups";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		label6.BackColor = Color.FromArgb(132, 146, 146);
		label6.Font = new Font("Microsoft Sans Serif", 12f);
		label6.ForeColor = Color.White;
		label6.ImeMode = ImeMode.NoControl;
		label6.Location = new Point(308, 82);
		label6.Margin = new Padding(4, 0, 4, 0);
		label6.Name = "label6";
		label6.Size = new Size(395, 34);
		label6.TabIndex = 259;
		label6.TextAlign = ContentAlignment.MiddleLeft;
		chkRemoveAllOption.Location = new Point(226, 684);
		chkRemoveAllOption.Name = "chkRemoveAllOption";
		chkRemoveAllOption.Size = new Size(30, 30);
		chkRemoveAllOption.TabIndex = 260;
		chkRemoveAllOption.Text = "customCheckbox1";
		chkRemoveAllOption.TextAlign = ContentAlignment.MiddleRight;
		chkRemoveAllOption.UseVisualStyleBackColor = true;
		chkRemoveAllOption.CheckedChanged += chkRemoveAllOption_CheckedChanged;
		chkRemoveAllOptGroup.Location = new Point(226, 727);
		chkRemoveAllOptGroup.Name = "chkRemoveAllOptGroup";
		chkRemoveAllOptGroup.Size = new Size(30, 30);
		chkRemoveAllOptGroup.TabIndex = 261;
		chkRemoveAllOptGroup.Text = "customCheckbox2";
		chkRemoveAllOptGroup.TextAlign = ContentAlignment.MiddleRight;
		chkRemoveAllOptGroup.UseVisualStyleBackColor = true;
		chkRemoveAllOptGroup.CheckedChanged += bbrnSoptb3;
		lblRemoveAllOpt.BackColor = Color.FromArgb(35, 39, 56);
		lblRemoveAllOpt.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblRemoveAllOpt.ForeColor = Color.White;
		lblRemoveAllOpt.ImeMode = ImeMode.NoControl;
		lblRemoveAllOpt.Location = new Point(259, 679);
		lblRemoveAllOpt.Name = "lblRemoveAllOpt";
		lblRemoveAllOpt.Padding = new Padding(5, 0, 0, 0);
		lblRemoveAllOpt.Size = new Size(556, 44);
		lblRemoveAllOpt.TabIndex = 262;
		lblRemoveAllOpt.Text = "Remove all existing options from destination item before copy/move.";
		lblRemoveAllOpt.TextAlign = ContentAlignment.MiddleLeft;
		lblRemoveAllOptGroup.BackColor = Color.FromArgb(35, 39, 56);
		lblRemoveAllOptGroup.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblRemoveAllOptGroup.ForeColor = Color.White;
		lblRemoveAllOptGroup.ImeMode = ImeMode.NoControl;
		lblRemoveAllOptGroup.Location = new Point(259, 720);
		lblRemoveAllOptGroup.Name = "lblRemoveAllOptGroup";
		lblRemoveAllOptGroup.Padding = new Padding(5, 0, 0, 0);
		lblRemoveAllOptGroup.Size = new Size(575, 44);
		lblRemoveAllOptGroup.TabIndex = 263;
		lblRemoveAllOptGroup.Text = "Remove all existing options from destination item that are in the same Option Group.";
		lblRemoveAllOptGroup.TextAlign = ContentAlignment.MiddleLeft;
		label7.BackColor = SystemColors.GrayText;
		label7.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label7.ForeColor = Color.White;
		label7.ImeMode = ImeMode.NoControl;
		label7.Location = new Point(622, 153);
		label7.Name = "label7";
		label7.Padding = new Padding(5, 0, 0, 0);
		label7.Size = new Size(81, 522);
		label7.TabIndex = 264;
		label7.TextAlign = ContentAlignment.MiddleLeft;
		btnCopyToAll.BackColor = Color.Chocolate;
		btnCopyToAll.FlatAppearance.BorderColor = Color.Black;
		btnCopyToAll.FlatAppearance.BorderSize = 0;
		btnCopyToAll.FlatAppearance.MouseDownBackColor = Color.White;
		btnCopyToAll.FlatStyle = FlatStyle.Flat;
		btnCopyToAll.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
		btnCopyToAll.ForeColor = Color.White;
		btnCopyToAll.Image = (Image)componentResourceManager.GetObject("btnCopyToAll.Image");
		btnCopyToAll.ImageAlign = ContentAlignment.TopCenter;
		btnCopyToAll.ImeMode = ImeMode.NoControl;
		btnCopyToAll.Location = new Point(623, 405);
		btnCopyToAll.Name = "btnCopyToAll";
		btnCopyToAll.Padding = new Padding(0, 20, 0, 20);
		btnCopyToAll.Size = new Size(80, 149);
		btnCopyToAll.TabIndex = 265;
		btnCopyToAll.Text = "COPY TO ALL";
		btnCopyToAll.TextAlign = ContentAlignment.BottomCenter;
		btnCopyToAll.UseVisualStyleBackColor = false;
		btnCopyToAll.Click += btnCopyToAll_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1024, 768);
		base.Controls.Add(btnCopyToAll);
		base.Controls.Add(lblRemoveAllOptGroup);
		base.Controls.Add(lblRemoveAllOpt);
		base.Controls.Add(chkRemoveAllOptGroup);
		base.Controls.Add(chkRemoveAllOption);
		base.Controls.Add(label6);
		base.Controls.Add(label5);
		base.Controls.Add(pnlOptionGroups);
		base.Controls.Add(btnRemoveRow);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(btnCancel);
		base.Controls.Add(label2);
		base.Controls.Add(btnCopy);
		base.Controls.Add(btnMove);
		base.Controls.Add(ddlGroupsRight);
		base.Controls.Add(label1);
		base.Controls.Add(ddlGroupLeft);
		base.Controls.Add(label8);
		base.Controls.Add(lstItemsLeft);
		base.Controls.Add(lstItemsRight);
		base.Controls.Add(label9);
		base.Controls.Add(label7);
		base.Name = "frmCopyMoveOptions";
		base.Opacity = 1.0;
		Text = "frmCopyMoveOptions";
		base.Load += VxaSbEbxCh;
		ResumeLayout(performLayout: false);
	}
}
