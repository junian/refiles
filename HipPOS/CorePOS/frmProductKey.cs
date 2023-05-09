using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Properties;

namespace CorePOS;

public class frmProductKey : frmMasterForm
{
	private IContainer icontainer_1;

	internal Button btnYes;

	internal Button lbbqaxxylS;

	private Label label1;

	private MaskedTextBox txtProductKey;

	private Label label10;

	public frmProductKey()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void btnYes_Click(object sender, EventArgs e)
	{
		string text = MiscHelper.productkeyCheckHelper(txtProductKey.Text.Trim());
		if (text == string.Empty)
		{
			new frmMessageBox(Resources.Your_product_key_has_been_acti).ShowDialog(this);
			Close();
		}
		else
		{
			new frmMessageBox(text).ShowDialog(this);
		}
	}

	private void lbbqaxxylS_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void frmProductKey_Load(object sender, EventArgs e)
	{
	}

	private void txtProductKey_Click(object sender, EventArgs e)
	{
		frmKeyboard frmKeyboard2 = new frmKeyboard();
		frmKeyboard2.LoadFormData("Enter Product Key", 1, 256, txtProductKey.Text.Replace("-", "").Replace(" ", ""));
		if (frmKeyboard2.ShowDialog(this) == DialogResult.OK)
		{
			txtProductKey.Text = frmKeyboard2.textEntered;
		}
		base.DialogResult = DialogResult.None;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProductKey));
		btnYes = new Button();
		lbbqaxxylS = new Button();
		label1 = new Label();
		txtProductKey = new MaskedTextBox();
		label10 = new Label();
		SuspendLayout();
		btnYes.BackColor = Color.FromArgb(80, 203, 116);
		btnYes.FlatAppearance.BorderColor = Color.White;
		btnYes.FlatAppearance.BorderSize = 0;
		btnYes.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnYes, "btnYes");
		btnYes.ForeColor = Color.White;
		btnYes.Name = "btnYes";
		btnYes.UseVisualStyleBackColor = false;
		btnYes.Click += btnYes_Click;
		lbbqaxxylS.BackColor = Color.FromArgb(235, 107, 86);
		lbbqaxxylS.FlatAppearance.BorderColor = Color.White;
		lbbqaxxylS.FlatAppearance.BorderSize = 0;
		lbbqaxxylS.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(lbbqaxxylS, "btnNo");
		lbbqaxxylS.ForeColor = Color.White;
		lbbqaxxylS.Name = "btnNo";
		lbbqaxxylS.UseVisualStyleBackColor = false;
		lbbqaxxylS.Click += lbbqaxxylS_Click;
		label1.BackColor = Color.White;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.FromArgb(40, 40, 40);
		label1.Name = "label1";
		txtProductKey.BackColor = Color.White;
		txtProductKey.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtProductKey, "txtProductKey");
		txtProductKey.ForeColor = Color.FromArgb(40, 40, 40);
		txtProductKey.HidePromptOnLeave = true;
		txtProductKey.InsertKeyMode = InsertKeyMode.Insert;
		txtProductKey.Name = "txtProductKey";
		txtProductKey.Click += txtProductKey_Click;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(label10);
		base.Controls.Add(txtProductKey);
		base.Controls.Add(label1);
		base.Controls.Add(btnYes);
		base.Controls.Add(lbbqaxxylS);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmProductKey";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.Load += frmProductKey_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
