using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS;

public class frmTimeRangeSelect : frmMasterForm
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

	private IContainer icontainer_1;

	private Label label9;

	private Label label7;

	private DateTimePicker endTimeRange;

	private DateTimePicker startTimeRange;

	private Button btnCancel;

	private Button btnOkay;

	public DateTime StartTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public DateTime EndTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_1;
		}
		[CompilerGenerated]
		set
		{
			dateTime_1 = value;
		}
	}

	public frmTimeRangeSelect()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmTimeRangeSelect_Load(object sender, EventArgs e)
	{
		startTimeRange.Value = DateTime.Now.Date;
		endTimeRange.Value = DateTime.Now.Date.AddHours(23.0);
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		StartTime = startTimeRange.Value;
		EndTime = endTimeRange.Value;
		base.DialogResult = DialogResult.OK;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTimeRangeSelect));
		label9 = new Label();
		label7 = new Label();
		endTimeRange = new DateTimePicker();
		startTimeRange = new DateTimePicker();
		btnCancel = new Button();
		btnOkay = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		endTimeRange.CalendarForeColor = Color.FromArgb(64, 64, 64);
		endTimeRange.CalendarTitleForeColor = Color.FromArgb(64, 64, 64);
		endTimeRange.Checked = false;
		componentResourceManager.ApplyResources(endTimeRange, "endTimeRange");
		endTimeRange.Format = DateTimePickerFormat.Time;
		endTimeRange.Name = "endTimeRange";
		endTimeRange.ShowUpDown = true;
		startTimeRange.CalendarForeColor = Color.FromArgb(64, 64, 64);
		startTimeRange.CalendarTitleForeColor = Color.FromArgb(64, 64, 64);
		startTimeRange.Checked = false;
		componentResourceManager.ApplyResources(startTimeRange, "startTimeRange");
		startTimeRange.Format = DateTimePickerFormat.Time;
		startTimeRange.Name = "startTimeRange";
		startTimeRange.ShowUpDown = true;
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
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label7);
		base.Controls.Add(endTimeRange);
		base.Controls.Add(startTimeRange);
		base.Controls.Add(label9);
		base.Name = "frmTimeRangeSelect";
		base.Opacity = 1.0;
		base.Load += frmTimeRangeSelect_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
