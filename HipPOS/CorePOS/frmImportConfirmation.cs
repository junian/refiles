using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class frmImportConfirmation : frmMasterForm
{
	private IContainer icontainer_1;

	internal Button btnUpdate;

	internal Button btnSkip;

	internal Button btnCancel;

	private Label lblMsg;

	private Label lblTitle;

	internal Button btnUpdateAll;

	public frmImportConfirmation(string message, bool allowUpdateAll = false)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		lblMsg.Text = message;
		btnUpdateAll.Visible = allowUpdateAll;
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnSkip_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Ignore;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Abort;
		Close();
	}

	private void btnUpdateAll_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmImportConfirmation));
		btnUpdate = new Button();
		btnSkip = new Button();
		btnCancel = new Button();
		lblMsg = new Label();
		lblTitle = new Label();
		btnUpdateAll = new Button();
		SuspendLayout();
		btnUpdate.BackColor = Color.FromArgb(50, 119, 155);
		btnUpdate.DialogResult = DialogResult.OK;
		btnUpdate.FlatAppearance.BorderColor = Color.White;
		btnUpdate.FlatAppearance.BorderSize = 0;
		btnUpdate.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnUpdate, "btnUpdate");
		btnUpdate.ForeColor = Color.White;
		btnUpdate.Name = "btnUpdate";
		btnUpdate.UseVisualStyleBackColor = false;
		btnUpdate.Click += btnUpdate_Click;
		btnSkip.BackColor = Color.FromArgb(80, 203, 116);
		btnSkip.DialogResult = DialogResult.Ignore;
		btnSkip.FlatAppearance.BorderColor = Color.White;
		btnSkip.FlatAppearance.BorderSize = 0;
		btnSkip.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSkip, "btnSkip");
		btnSkip.ForeColor = Color.White;
		btnSkip.Name = "btnSkip";
		btnSkip.UseVisualStyleBackColor = false;
		btnSkip.Click += btnSkip_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.Abort;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		lblMsg.BackColor = Color.White;
		componentResourceManager.ApplyResources(lblMsg, "lblMsg");
		lblMsg.ForeColor = Color.FromArgb(40, 40, 40);
		lblMsg.Name = "lblMsg";
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnUpdateAll.BackColor = Color.FromArgb(255, 128, 0);
		btnUpdateAll.DialogResult = DialogResult.Yes;
		btnUpdateAll.FlatAppearance.BorderColor = Color.White;
		btnUpdateAll.FlatAppearance.BorderSize = 0;
		btnUpdateAll.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnUpdateAll, "btnUpdateAll");
		btnUpdateAll.ForeColor = Color.White;
		btnUpdateAll.Name = "btnUpdateAll";
		btnUpdateAll.UseVisualStyleBackColor = false;
		btnUpdateAll.Click += btnUpdateAll_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(btnUpdateAll);
		base.Controls.Add(lblTitle);
		base.Controls.Add(lblMsg);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSkip);
		base.Controls.Add(btnUpdate);
		base.Name = "frmImportConfirmation";
		base.Opacity = 1.0;
		base.TopMost = true;
		ResumeLayout(performLayout: false);
	}
}
