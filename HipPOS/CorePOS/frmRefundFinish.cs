using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Properties;

namespace CorePOS;

public class frmRefundFinish : frmMasterForm
{
	private string string_0;

	private IContainer icontainer_1;

	internal Button btnDone;

	internal Label Label6;

	internal Button btnPrintReceipt;

	internal Label lblChange;

	public frmRefundFinish(decimal changeAmount, string refundNumber, string paymentMethod)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		lblChange.Text = Resources.res0 + changeAmount.ToString("0.00");
		string_0 = refundNumber;
		if (changeAmount > 0m && paymentMethod == Resources.CASH0)
		{
			GClass8.OpenCashDrawer();
		}
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnPrintReceipt_Click(object sender, EventArgs e)
	{
		new PrintHelper().GenerateRefundReceipt(string_0);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRefundFinish));
		btnDone = new Button();
		Label6 = new Label();
		btnPrintReceipt = new Button();
		lblChange = new Label();
		SuspendLayout();
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.DialogResult = DialogResult.OK;
		btnDone.FlatAppearance.BorderColor = Color.Black;
		btnDone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		Label6.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(Label6, "Label6");
		Label6.ForeColor = Color.White;
		Label6.Name = "Label6";
		btnPrintReceipt.BackColor = Color.FromArgb(255, 192, 128);
		btnPrintReceipt.DialogResult = DialogResult.OK;
		btnPrintReceipt.FlatAppearance.BorderColor = Color.Black;
		btnPrintReceipt.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnPrintReceipt, "btnPrintReceipt");
		btnPrintReceipt.ForeColor = Color.White;
		btnPrintReceipt.Name = "btnPrintReceipt";
		btnPrintReceipt.UseVisualStyleBackColor = false;
		btnPrintReceipt.Click += btnPrintReceipt_Click;
		lblChange.BackColor = Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(lblChange, "lblChange");
		lblChange.ForeColor = Color.FromArgb(235, 107, 86);
		lblChange.Name = "lblChange";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(lblChange);
		base.Controls.Add(btnPrintReceipt);
		base.Controls.Add(Label6);
		base.Controls.Add(btnDone);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmRefundFinish";
		base.Opacity = 1.0;
		ResumeLayout(performLayout: false);
	}
}
