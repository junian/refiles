using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class frmTemplate : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblTitle;

	private Button btnCancel;

	private Button btnOk;

	public frmTemplate()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmTemplate_Load(object sender, EventArgs e)
	{
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTemplate));
		lblTitle = new Label();
		btnCancel = new Button();
		btnOk = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOk.BackColor = Color.FromArgb(80, 203, 116);
		btnOk.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOk, "btnOk");
		btnOk.ForeColor = SystemColors.ButtonFace;
		btnOk.Name = "btnOk";
		btnOk.UseVisualStyleBackColor = false;
		btnOk.Click += btnOk_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOk);
		base.Controls.Add(lblTitle);
		base.Name = "frmTemplate";
		base.Opacity = 1.0;
		base.Load += frmTemplate_Load;
		ResumeLayout(performLayout: false);
	}
}
