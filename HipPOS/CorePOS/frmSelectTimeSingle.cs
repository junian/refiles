using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Properties;

namespace CorePOS;

public class frmSelectTimeSingle : frmMasterForm
{
	private double double_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private DateTimePicker timePicker;

	private Button btnCancel;

	private Button btnOkay;

	public frmSelectTimeSingle(string t)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		timePicker.Value = Convert.ToDateTime(t);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		double_0 = TimeSpan.Parse(timePicker.Value.TimeOfDay.ToString()).TotalSeconds;
		if (double_0 == 0.0)
		{
			new NotificationLabel(this, Resources.It_must_be_greater_than_0_seco, NotificationTypes.Notification).Show();
		}
		else
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	public double getSeconds()
	{
		return double_0;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectTimeSingle));
		lblTitle = new Label();
		timePicker = new DateTimePicker();
		btnCancel = new Button();
		btnOkay = new Button();
		SuspendLayout();
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(timePicker, "timePicker");
		timePicker.Format = DateTimePickerFormat.Custom;
		timePicker.Name = "timePicker";
		timePicker.ShowUpDown = true;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOkay, "btnOkay");
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.Name = "btnOkay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(timePicker);
		base.Controls.Add(lblTitle);
		base.Name = "frmSelectTimeSingle";
		base.Opacity = 1.0;
		ResumeLayout(performLayout: false);
	}
}
