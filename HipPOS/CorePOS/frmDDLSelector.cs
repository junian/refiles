using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS;

public class frmDDLSelector : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Class19 ddlSelect;

	private Button btnCancel;

	private Button btnSave;

	public string SelectedValue
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string SelectedDisplay
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public frmDDLSelector(string title, Dictionary<string, string> select, string selectedKey = "")
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		lblTitle.Text = title;
		ddlSelect.DataSource = new BindingSource(select, null);
		ddlSelect.DisplayMember = "Value";
		ddlSelect.ValueMember = "Key";
		if (!string.IsNullOrEmpty(selectedKey))
		{
			ddlSelect.SelectedValue = selectedKey;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		SelectedValue = ddlSelect.SelectedValue.ToString();
		SelectedDisplay = ddlSelect.Text;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
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
		lblTitle = new Label();
		ddlSelect = new Class19();
		btnCancel = new Button();
		btnSave = new Button();
		SuspendLayout();
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(1, 3);
		lblTitle.MinimumSize = new Size(0, 35);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(401, 35);
		lblTitle.TabIndex = 128;
		lblTitle.Text = "UOM CONVERSIONS";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		ddlSelect.BackColor = Color.White;
		ddlSelect.DrawMode = DrawMode.OwnerDrawVariable;
		ddlSelect.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlSelect.FlatStyle = FlatStyle.Flat;
		ddlSelect.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlSelect.ForeColor = Color.FromArgb(40, 40, 40);
		ddlSelect.FormattingEnabled = true;
		ddlSelect.ItemHeight = 27;
		ddlSelect.Items.AddRange(new object[2] { "Vertical", "Horizontal" });
		ddlSelect.Location = new Point(2, 39);
		ddlSelect.Margin = new Padding(4, 5, 4, 5);
		ddlSelect.Name = "ddlSelect";
		ddlSelect.Size = new Size(400, 33);
		ddlSelect.TabIndex = 220;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(199, 74);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(203, 80);
		btnCancel.TabIndex = 232;
		btnCancel.Text = "CANCEL";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(2, 73);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(196, 80);
		btnSave.TabIndex = 231;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(403, 156);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(ddlSelect);
		base.Controls.Add(lblTitle);
		base.Name = "frmDDLSelector";
		base.Opacity = 1.0;
		Text = "frmDDLSelector";
		ResumeLayout(performLayout: false);
	}
}
