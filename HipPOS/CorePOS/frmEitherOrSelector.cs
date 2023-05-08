using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CorePOS;

public class frmEitherOrSelector : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblTitle;

	private Button btnOr;

	private Button btnEither;

	private Button btnOpenOrders;

	private PictureBox picClose;

	public frmEitherOrSelector(string Title, Dictionary<DialogResult, string> Choices, bool showOpenOrder = false)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		lblTitle.Text = Title.ToUpper();
		btnEither.DialogResult = Choices.ElementAt(0).Key;
		btnEither.Text = Choices.ElementAt(0).Value.ToUpper();
		btnOr.DialogResult = Choices.ElementAt(1).Key;
		btnOr.Text = Choices.ElementAt(1).Value.ToUpper();
		if (!showOpenOrder)
		{
			base.Size = new Size(433, 153);
		}
		btnOpenOrders.Visible = showOpenOrder;
	}

	private void frmEitherOrSelector_Load(object sender, EventArgs e)
	{
	}

	private void btnOpenOrders_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Abort;
	}

	private void picClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEitherOrSelector));
		lblTitle = new Label();
		btnOr = new Button();
		btnEither = new Button();
		btnOpenOrders = new Button();
		picClose = new PictureBox();
		((ISupportInitialize)picClose).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnOr.BackColor = Color.FromArgb(61, 142, 185);
		btnOr.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOr, "btnOr");
		btnOr.ForeColor = SystemColors.ButtonFace;
		btnOr.Name = "btnOr";
		btnOr.UseVisualStyleBackColor = false;
		btnEither.BackColor = Color.FromArgb(77, 174, 225);
		btnEither.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnEither, "btnEither");
		btnEither.ForeColor = SystemColors.ButtonFace;
		btnEither.Name = "btnEither";
		btnEither.UseVisualStyleBackColor = false;
		btnOpenOrders.BackColor = Color.FromArgb(65, 168, 95);
		btnOpenOrders.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOpenOrders, "btnOpenOrders");
		btnOpenOrders.ForeColor = SystemColors.ButtonFace;
		btnOpenOrders.Name = "btnOpenOrders";
		btnOpenOrders.UseVisualStyleBackColor = false;
		btnOpenOrders.Click += btnOpenOrders_Click;
		componentResourceManager.ApplyResources(picClose, "picClose");
		picClose.BackColor = Color.FromArgb(156, 89, 184);
		picClose.Name = "picClose";
		picClose.TabStop = false;
		picClose.Click += picClose_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(picClose);
		base.Controls.Add(btnOpenOrders);
		base.Controls.Add(btnOr);
		base.Controls.Add(btnEither);
		base.Controls.Add(lblTitle);
		base.Name = "frmEitherOrSelector";
		base.Opacity = 1.0;
		base.TopMost = true;
		base.Load += frmEitherOrSelector_Load;
		((ISupportInitialize)picClose).EndInit();
		ResumeLayout(performLayout: false);
	}
}
