using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmManageOptions : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public List<int> itemIdsThatHaveOption;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public global::_003C_003Ef__AnonymousType3<ItemsWithOption, Item, Option> itemWithOption;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int itemWithOptionID;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private int int_0;

	private bool bool_0;

	private IContainer icontainer_1;

	private Label label3;

	private ListView lstItemOption;

	private Label label1;

	private ListView lstItems;

	private Label label10;

	private Label label4;

	internal Button btnMoveUp;

	internal Button btnMoveDown;

	internal Button btnSave;

	internal Button btnClose;

	public frmManageOptions()
	{
		Class26.Ggkj0JxzN9YmC();
		bool_0 = true;
		base._002Ector();
		InitializeComponent_1();
		method_3();
	}

	private void method_3()
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.itemIdsThatHaveOption = gClass.ItemsWithOptions.Select((ItemsWithOption a) => a.ItemID.Value).ToList();
		foreach (Item item in (from tblItems in gClass.Items
			where CS_0024_003C_003E8__locals0.itemIdsThatHaveOption.Contains(tblItems.ItemID) && tblItems.Active == true && tblItems.isDeleted == false
			orderby tblItems.ItemName
			select tblItems).ToList())
		{
			lstItems.Items.Add(new ListViewItem(new string[2]
			{
				item.ItemName,
				item.ItemID.ToString()
			}));
		}
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_4();
			return;
		}
		switch (new frmMessageBox(Resources.Do_you_want_to_save_the_change1, Resources.Save_Changes0, CustomMessageBoxButtons.YesNoCancel).ShowDialog())
		{
		case DialogResult.Yes:
			method_5();
			break;
		case DialogResult.Cancel:
			return;
		}
		bool_0 = true;
		method_4();
	}

	private void method_4()
	{
		if (lstItems.SelectedItems.Count <= 0)
		{
			return;
		}
		lstItemOption.Clear();
		GClass6 gClass = new GClass6();
		string value = lstItems.SelectedItems[0].SubItems[1].Text;
		int_0 = Convert.ToInt32(value);
		using var enumerator = (from tblItemWithOptions in gClass.ItemsWithOptions
			join tblItems in gClass.Items on tblItemWithOptions.ItemID equals tblItems.ItemID
			join tblOptions in gClass.Options on tblItemWithOptions.OptionID equals tblOptions.OptionID
			where tblItems.ItemID == int_0 && tblItems.Active == true && tblItems.isDeleted == false
			select new { tblItemWithOptions, tblItems, tblOptions } into a
			orderby a.tblItemWithOptions.SortOrder
			select a).GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals0.itemWithOption = enumerator.Current;
			Item item = gClass.Items.Where((Item i) => (int?)i.ItemID == CS_0024_003C_003E8__locals0.itemWithOption.tblOptions.ItemID).FirstOrDefault();
			lstItemOption.Items.Add(new ListViewItem(new string[2]
			{
				item.ItemName,
				CS_0024_003C_003E8__locals0.itemWithOption.tblItemWithOptions.ItemWithOptionID.ToString()
			}));
		}
	}

	private void btnMoveUp_Click(object sender, EventArgs e)
	{
		ControlHelpers.MoveListViewItems(lstItemOption, ControlHelpers.MoveDirection.Up);
		bool_0 = false;
	}

	private void btnMoveDown_Click(object sender, EventArgs e)
	{
		ControlHelpers.MoveListViewItems(lstItemOption, ControlHelpers.MoveDirection.Down);
		bool_0 = false;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			Close();
			return;
		}
		switch (new frmMessageBox(Resources.Do_you_want_to_save_the_change1, Resources.Save_Changes0, CustomMessageBoxButtons.YesNoCancel).ShowDialog())
		{
		case DialogResult.Yes:
			method_5();
			break;
		case DialogResult.Cancel:
			return;
		}
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		GClass6 gClass = new GClass6();
		foreach (ListViewItem item in lstItemOption.Items)
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
			string value = item.SubItems[1].Text;
			CS_0024_003C_003E8__locals0.itemWithOptionID = Convert.ToInt32(value);
			gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ItemWithOptionID == CS_0024_003C_003E8__locals0.itemWithOptionID).FirstOrDefault().SortOrder = (short)item.Index;
		}
		Helper.SubmitChangesWithCatch(gClass);
		bool_0 = true;
		new NotificationLabel(this, Resources.Changes_successfully_saved, NotificationTypes.Success).Show();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageOptions));
		label3 = new Label();
		lstItemOption = new ListView();
		label1 = new Label();
		lstItems = new ListView();
		label10 = new Label();
		label4 = new Label();
		btnMoveUp = new Button();
		btnMoveDown = new Button();
		btnSave = new Button();
		btnClose = new Button();
		SuspendLayout();
		label3.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.FromArgb(64, 64, 64);
		label3.Name = "label3";
		lstItemOption.BackColor = Color.White;
		lstItemOption.BorderStyle = BorderStyle.None;
		lstItemOption.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstItemOption, "lstItemOption");
		lstItemOption.ForeColor = Color.Black;
		lstItemOption.FullRowSelect = true;
		lstItemOption.Groups.AddRange(new ListViewGroup[1] { (ListViewGroup)componentResourceManager.GetObject("lstItemOption.Groups") });
		lstItemOption.HideSelection = false;
		lstItemOption.Name = "lstItemOption";
		lstItemOption.UseCompatibleStateImageBehavior = false;
		lstItemOption.View = View.List;
		label1.BackColor = Color.LightGray;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.FromArgb(64, 64, 64);
		label1.Name = "label1";
		lstItems.BackColor = Color.White;
		lstItems.BorderStyle = BorderStyle.None;
		lstItems.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.ForeColor = Color.Black;
		lstItems.FullRowSelect = true;
		lstItems.Groups.AddRange(new ListViewGroup[1] { (ListViewGroup)componentResourceManager.GetObject("lstItems.Groups") });
		lstItems.HideSelection = false;
		lstItems.Name = "lstItems";
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.List;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(147, 101, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label4.BackColor = Color.LemonChiffon;
		label4.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.Name = "label4";
		btnMoveUp.BackColor = Color.FromArgb(77, 174, 225);
		btnMoveUp.Cursor = Cursors.Default;
		btnMoveUp.FlatAppearance.BorderColor = Color.Black;
		btnMoveUp.FlatAppearance.BorderSize = 0;
		btnMoveUp.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnMoveUp, "btnMoveUp");
		btnMoveUp.ForeColor = Color.White;
		btnMoveUp.Name = "btnMoveUp";
		btnMoveUp.UseVisualStyleBackColor = false;
		btnMoveUp.Click += btnMoveUp_Click;
		btnMoveDown.BackColor = Color.FromArgb(50, 119, 155);
		btnMoveDown.Cursor = Cursors.Default;
		btnMoveDown.FlatAppearance.BorderColor = Color.Black;
		btnMoveDown.FlatAppearance.BorderSize = 0;
		btnMoveDown.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnMoveDown, "btnMoveDown");
		btnMoveDown.ForeColor = Color.White;
		btnMoveDown.Name = "btnMoveDown";
		btnMoveDown.UseVisualStyleBackColor = false;
		btnMoveDown.Click += btnMoveDown_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.Cursor = Cursors.Default;
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.Cursor = Cursors.Default;
		btnClose.FlatAppearance.BorderColor = Color.Black;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnClose);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnMoveDown);
		base.Controls.Add(btnMoveUp);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(lstItemOption);
		base.Controls.Add(label1);
		base.Controls.Add(lstItems);
		base.Controls.Add(label10);
		base.Name = "frmManageOptions";
		base.Opacity = 1.0;
		ResumeLayout(performLayout: false);
	}
}
