using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class frmKioskPayFinish : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblOrderNumber;

	private Label label1;

	internal Button btnDone;

	private Timer timer_0;

	public frmKioskPayFinish(string orderNumber)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		lblOrderNumber.Text = orderNumber;
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmKioskPayFinish));
		lblOrderNumber = new Label();
		label1 = new Label();
		btnDone = new Button();
		timer_0 = new Timer(icontainer_1);
		SuspendLayout();
		componentResourceManager.ApplyResources(lblOrderNumber, "lblOrderNumber");
		lblOrderNumber.ForeColor = Color.FromArgb(255, 255, 128);
		lblOrderNumber.Name = "lblOrderNumber";
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.BackColor = Color.Transparent;
		btnDone.DialogResult = DialogResult.OK;
		btnDone.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnDone.FlatAppearance.BorderSize = 0;
		btnDone.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnDone.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		timer_0.Enabled = true;
		timer_0.Interval = 25000;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnDone);
		base.Controls.Add(label1);
		base.Controls.Add(lblOrderNumber);
		base.Name = "frmKioskPayFinish";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
