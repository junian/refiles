using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.CommonForms;
using CorePOS.Data;

namespace CorePOS;

public class frmManageTerminals : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblHeaderTitle;

	private ListView lstUsed;

	private Label lblGroup;

	private ListView lstUnused;

	private Label lblItems;

	private Button btnMoveUsed;

	private Button btnRemoveUsed;

	private PictureBox pictureBox1;

	internal Button btnDefaultOrderTypes;

	private Label label3;

	public frmManageTerminals()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageTerminals_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		List<Terminal> list = gClass.Terminals.Where((Terminal a) => a.Status == TerminalStatus.active).ToList();
		List<Terminal> list2 = gClass.Terminals.Where((Terminal a) => a.Status == TerminalStatus.inactive).ToList();
		lstUsed.Items.Clear();
		foreach (Terminal item in list)
		{
			lstUsed.Items.Add(item.SystemName);
			lstUsed.Items[lstUsed.Items.Count - 1].Tag = item.TerminalID;
		}
		lstUnused.Items.Clear();
		foreach (Terminal item2 in list2)
		{
			lstUnused.Items.Add(item2.SystemName);
			lstUnused.Items[lstUnused.Items.Count - 1].Tag = item2.TerminalID;
		}
	}

	private void btnMoveUsed_Click(object sender, EventArgs e)
	{
		if (lstUnused.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals0.terminalId = Convert.ToInt32(lstUnused.SelectedItems[0].Tag);
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal a) => a.TerminalID == CS_0024_003C_003E8__locals0.terminalId).FirstOrDefault();
			if (terminal != null)
			{
				terminal.Status = TerminalStatus.active;
				Helper.SubmitChangesWithCatch(gClass);
			}
			method_3();
		}
	}

	private void btnRemoveUsed_Click(object sender, EventArgs e)
	{
		if (lstUsed.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
			CS_0024_003C_003E8__locals0.terminalId = Convert.ToInt32(lstUsed.SelectedItems[0].Tag);
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal a) => a.TerminalID == CS_0024_003C_003E8__locals0.terminalId).FirstOrDefault();
			if (terminal != null)
			{
				terminal.Status = TerminalStatus.inactive;
				Helper.SubmitChangesWithCatch(gClass);
			}
			method_3();
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Close();
		Dispose();
	}

	private void btnDefaultOrderTypes_Click(object sender, EventArgs e)
	{
		if (lstUsed.SelectedItems.Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.terminalId = Convert.ToInt32(lstUsed.SelectedItems[0].Tag);
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal a) => a.TerminalID == CS_0024_003C_003E8__locals0.terminalId).FirstOrDefault();
		if (terminal == null)
		{
			return;
		}
		string defaultOrderTypes = terminal.DefaultOrderTypes;
		Dictionary<string, string> dictionary = OrderTypesDictionary.OrderTypes.ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> a) => a.Value);
		dictionary.Remove("Delivery-Online");
		dictionary.Remove("Pick-Up-Online");
		frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SET DEFAULT ORDER TYPES", dictionary, defaultOrderTypes, 1);
		if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
		{
			defaultOrderTypes = (terminal.DefaultOrderTypes = frmChecklistSelector.returnValue);
			Helper.SubmitChangesWithCatch(gClass);
			if (terminal.SystemName == Environment.MachineName)
			{
				MemoryLoadedObjects.DefaultOrderTypes = terminal.DefaultOrderTypes;
			}
			new NotificationLabel(this, "Default Order Types Successfully Saved.", NotificationTypes.Success).Show();
		}
	}

	private void lstUsed_SelectedIndexChanged(object sender, EventArgs e)
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
		ListViewGroup listViewGroup = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
		ListViewGroup listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
		ListViewGroup listViewGroup3 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageTerminals));
		lblHeaderTitle = new Label();
		lstUsed = new ListView();
		lblGroup = new Label();
		lstUnused = new ListView();
		lblItems = new Label();
		btnMoveUsed = new Button();
		btnRemoveUsed = new Button();
		pictureBox1 = new PictureBox();
		btnDefaultOrderTypes = new Button();
		label3 = new Label();
		((ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(-4, 4);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(734, 38);
		lblHeaderTitle.TabIndex = 122;
		lblHeaderTitle.Text = "MANAGE TERMINALS";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		lstUsed.BackColor = Color.White;
		lstUsed.BorderStyle = BorderStyle.None;
		lstUsed.Cursor = Cursors.Default;
		lstUsed.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold);
		lstUsed.ForeColor = Color.Black;
		lstUsed.FullRowSelect = true;
		listViewGroup.Header = "ListViewGroup";
		listViewGroup.Name = "Name";
		listViewGroup2.Header = "ListViewGroup";
		listViewGroup2.Name = "Price";
		lstUsed.Groups.AddRange(new ListViewGroup[2] { listViewGroup, listViewGroup2 });
		lstUsed.HideSelection = false;
		lstUsed.Location = new Point(366, 73);
		lstUsed.Name = "lstUsed";
		lstUsed.Size = new Size(364, 453);
		lstUsed.TabIndex = 126;
		lstUsed.UseCompatibleStateImageBehavior = false;
		lstUsed.View = View.List;
		lstUsed.SelectedIndexChanged += lstUsed_SelectedIndexChanged;
		lblGroup.BackColor = Color.FromArgb(132, 146, 146);
		lblGroup.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		lblGroup.ForeColor = Color.White;
		lblGroup.ImeMode = ImeMode.NoControl;
		lblGroup.Location = new Point(0, 42);
		lblGroup.Name = "lblGroup";
		lblGroup.Size = new Size(365, 30);
		lblGroup.TabIndex = 125;
		lblGroup.Text = "Inactive Terminals";
		lstUnused.BackColor = Color.White;
		lstUnused.BorderStyle = BorderStyle.None;
		lstUnused.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold);
		lstUnused.ForeColor = Color.Black;
		listViewGroup3.Header = "ListViewGroup";
		listViewGroup3.Name = "Name";
		lstUnused.Groups.AddRange(new ListViewGroup[1] { listViewGroup3 });
		lstUnused.HideSelection = false;
		lstUnused.Location = new Point(0, 73);
		lstUnused.MultiSelect = false;
		lstUnused.Name = "lstUnused";
		lstUnused.Size = new Size(365, 534);
		lstUnused.TabIndex = 124;
		lstUnused.UseCompatibleStateImageBehavior = false;
		lstUnused.View = View.List;
		lblItems.BackColor = Color.FromArgb(132, 146, 146);
		lblItems.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold);
		lblItems.ForeColor = Color.White;
		lblItems.ImeMode = ImeMode.NoControl;
		lblItems.Location = new Point(366, 42);
		lblItems.Name = "lblItems";
		lblItems.Size = new Size(364, 30);
		lblItems.TabIndex = 123;
		lblItems.Text = "Active Terminals";
		btnMoveUsed.BackColor = Color.FromArgb(61, 142, 185);
		btnMoveUsed.FlatAppearance.BorderSize = 0;
		btnMoveUsed.FlatStyle = FlatStyle.Flat;
		btnMoveUsed.Font = new Font("Microsoft Sans Serif", 12f);
		btnMoveUsed.ForeColor = SystemColors.ButtonFace;
		btnMoveUsed.ImeMode = ImeMode.NoControl;
		btnMoveUsed.Location = new Point(0, 608);
		btnMoveUsed.Name = "btnMoveUsed";
		btnMoveUsed.Size = new Size(365, 75);
		btnMoveUsed.TabIndex = 127;
		btnMoveUsed.Text = "Move to Active";
		btnMoveUsed.UseVisualStyleBackColor = false;
		btnMoveUsed.Click += btnMoveUsed_Click;
		btnRemoveUsed.BackColor = Color.FromArgb(235, 107, 86);
		btnRemoveUsed.FlatAppearance.BorderSize = 0;
		btnRemoveUsed.FlatStyle = FlatStyle.Flat;
		btnRemoveUsed.Font = new Font("Microsoft Sans Serif", 12f);
		btnRemoveUsed.ForeColor = SystemColors.ButtonFace;
		btnRemoveUsed.ImeMode = ImeMode.NoControl;
		btnRemoveUsed.Location = new Point(366, 608);
		btnRemoveUsed.Name = "btnRemoveUsed";
		btnRemoveUsed.Size = new Size(364, 75);
		btnRemoveUsed.TabIndex = 132;
		btnRemoveUsed.Text = "Make Inactive";
		btnRemoveUsed.UseVisualStyleBackColor = false;
		btnRemoveUsed.Click += btnRemoveUsed_Click;
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(685, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(44, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 236;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		btnDefaultOrderTypes.BackColor = Color.FromArgb(80, 203, 116);
		btnDefaultOrderTypes.FlatAppearance.BorderColor = Color.Black;
		btnDefaultOrderTypes.FlatAppearance.BorderSize = 0;
		btnDefaultOrderTypes.FlatAppearance.MouseDownBackColor = Color.White;
		btnDefaultOrderTypes.FlatStyle = FlatStyle.Flat;
		btnDefaultOrderTypes.Font = new Font("Microsoft Sans Serif", 10f);
		btnDefaultOrderTypes.ForeColor = Color.White;
		btnDefaultOrderTypes.ImeMode = ImeMode.NoControl;
		btnDefaultOrderTypes.Location = new Point(366, 527);
		btnDefaultOrderTypes.Margin = new Padding(3, 1, 3, 1);
		btnDefaultOrderTypes.MinimumSize = new Size(100, 60);
		btnDefaultOrderTypes.Name = "btnDefaultOrderTypes";
		btnDefaultOrderTypes.Size = new Size(364, 80);
		btnDefaultOrderTypes.TabIndex = 237;
		btnDefaultOrderTypes.Text = "SET DEFAULT ORDER TYPES";
		btnDefaultOrderTypes.TextImageRelation = TextImageRelation.ImageAboveText;
		btnDefaultOrderTypes.UseVisualStyleBackColor = false;
		btnDefaultOrderTypes.Click += btnDefaultOrderTypes_Click;
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.BackColor = Color.LemonChiffon;
		label3.Font = new Font("Microsoft Sans Serif", 10f);
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(0, 686);
		label3.Name = "label3";
		label3.Padding = new Padding(5);
		label3.Size = new Size(730, 79);
		label3.TabIndex = 238;
		label3.Text = componentResourceManager.GetString("label3.Text");
		label3.TextAlign = ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(734, 763);
		base.Controls.Add(label3);
		base.Controls.Add(btnDefaultOrderTypes);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(btnRemoveUsed);
		base.Controls.Add(btnMoveUsed);
		base.Controls.Add(lstUsed);
		base.Controls.Add(lblGroup);
		base.Controls.Add(lstUnused);
		base.Controls.Add(lblItems);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmManageTerminals";
		base.Opacity = 1.0;
		Text = "Manage Terminals";
		base.Load += frmManageTerminals_Load;
		((ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
