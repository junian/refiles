using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;

namespace CorePOS.AdminPanel;

public class frmEditTabSortOrder : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string tabValue;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	private IContainer icontainer_1;

	private Label label9;

	private Label label1;

	internal Button btnDown;

	internal Button btnUp;

	internal ListView lstTabs;

	internal ColumnHeader columnHeader_0;

	private Button btnCancel;

	private Button btnOkay;

	private Label label3;

	public frmEditTabSortOrder()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmEditTabSortOrder_Load(object sender, EventArgs e)
	{
		foreach (Reason item in (from a in gclass6_0.Reasons
			where a.ReasonType == ReasonTypes.option_tab
			orderby a.SortOrder
			select a).ToList())
		{
			lstTabs.Items.Add(new ListViewItem(new string[2]
			{
				item.Value,
				item.Id.ToString()
			}));
		}
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		short num = 1;
		foreach (ListViewItem item in lstTabs.Items)
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals0.tabValue = item.SubItems[0].Text;
			Reason reason = gClass.Reasons.Where((Reason a) => a.Value == CS_0024_003C_003E8__locals0.tabValue).FirstOrDefault();
			if (reason != null)
			{
				reason.SortOrder = num;
			}
			Helper.SubmitChangesWithCatch(gClass);
			num = (short)(num + 1);
		}
		MemoryLoadedObjects.RefreshGeneralOEData();
		new NotificationLabel(this, "Tab Sort Orders have been successfully saved.", NotificationTypes.Success).Show();
		base.DialogResult = DialogResult.None;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstTabs.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an option to move.", NotificationTypes.Notification).Show();
			return;
		}
		int index = lstTabs.SelectedItems[0].Index;
		if (index > 0)
		{
			ListViewItem item = lstTabs.Items[index];
			lstTabs.Items.RemoveAt(index);
			lstTabs.Items.Insert(index - 1, item);
			lstTabs.Items[index - 1].EnsureVisible();
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstTabs.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an option to move.", NotificationTypes.Notification).Show();
			return;
		}
		int index = lstTabs.SelectedItems[0].Index;
		ListViewItem item = lstTabs.Items[index];
		if (index < lstTabs.Items.Count - 1)
		{
			lstTabs.Items.RemoveAt(index);
			lstTabs.Items.Insert(index + 1, item);
			lstTabs.Items[index + 1].EnsureVisible();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditTabSortOrder));
		label3 = new Label();
		btnCancel = new Button();
		btnOkay = new Button();
		label1 = new Label();
		btnDown = new Button();
		btnUp = new Button();
		lstTabs = new ListView();
		columnHeader_0 = new ColumnHeader();
		label9 = new Label();
		SuspendLayout();
		label3.BackColor = Color.LemonChiffon;
		label3.Font = new Font("Microsoft Sans Serif", 8.25f);
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(1, 454);
		label3.Name = "label3";
		label3.Padding = new Padding(5);
		label3.Size = new Size(188, 80);
		label3.TabIndex = 245;
		label3.Text = "INSTRUCTIONS: Click up/down arrows to move the tabs into a new row.";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label3.UseWaitCursor = true;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(397, 454);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(175, 80);
		btnCancel.TabIndex = 244;
		btnCancel.Text = "CLOSE";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		btnOkay.FlatStyle = FlatStyle.Flat;
		btnOkay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.ImeMode = ImeMode.NoControl;
		btnOkay.Location = new Point(190, 454);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(206, 80);
		btnOkay.TabIndex = 243;
		btnOkay.Text = "SAVE";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		label1.BackColor = SystemColors.GrayText;
		label1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(0, 47);
		label1.Name = "label1";
		label1.Padding = new Padding(5, 0, 0, 0);
		label1.Size = new Size(573, 37);
		label1.TabIndex = 239;
		label1.Text = "Tabs";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label1.UseWaitCursor = true;
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnDown.FlatStyle = FlatStyle.Flat;
		btnDown.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnDown.ForeColor = Color.White;
		btnDown.Image = (Image)componentResourceManager.GetObject("btnDown.Image");
		btnDown.ImeMode = ImeMode.NoControl;
		btnDown.Location = new Point(522, 279);
		btnDown.Margin = new Padding(0, 0, 0, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new Size(50, 173);
		btnDown.TabIndex = 242;
		btnDown.Tag = "";
		btnDown.TextAlign = ContentAlignment.BottomCenter;
		btnDown.UseVisualStyleBackColor = false;
		btnDown.Click += btnDown_Click;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnUp.FlatStyle = FlatStyle.Flat;
		btnUp.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnUp.ForeColor = Color.White;
		btnUp.Image = (Image)componentResourceManager.GetObject("btnUp.Image");
		btnUp.ImeMode = ImeMode.NoControl;
		btnUp.Location = new Point(522, 85);
		btnUp.Margin = new Padding(0, 0, 0, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(50, 193);
		btnUp.TabIndex = 241;
		btnUp.Tag = "";
		btnUp.TextAlign = ContentAlignment.BottomCenter;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		lstTabs.BorderStyle = BorderStyle.None;
		lstTabs.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstTabs.Font = new Font("Microsoft Sans Serif", 14f);
		lstTabs.FullRowSelect = true;
		lstTabs.GridLines = true;
		lstTabs.HeaderStyle = ColumnHeaderStyle.None;
		lstTabs.HideSelection = false;
		lstTabs.Location = new Point(1, 85);
		lstTabs.MinimumSize = new Size(410, 350);
		lstTabs.MultiSelect = false;
		lstTabs.Name = "lstTabs";
		lstTabs.Size = new Size(520, 367);
		lstTabs.TabIndex = 240;
		lstTabs.TileSize = new Size(50, 200);
		lstTabs.UseCompatibleStateImageBehavior = false;
		lstTabs.View = View.Details;
		columnHeader_0.Text = "Item Name";
		columnHeader_0.Width = 480;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(1, 0);
		label9.Name = "label9";
		label9.Size = new Size(573, 46);
		label9.TabIndex = 230;
		label9.Text = "TAB SORT ORDER";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(573, 538);
		base.Controls.Add(label3);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label1);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lstTabs);
		base.Controls.Add(label9);
		base.Name = "frmEditTabSortOrder";
		base.Opacity = 1.0;
		Text = "frmEditTabSortOrder";
		base.Load += frmEditTabSortOrder_Load;
		ResumeLayout(performLayout: false);
	}
}
