using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS.CommonForms;

public class frmSelectDateRange : frmMasterForm
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Label label1;

	private DateTimePicker endDate;

	private DateTimePicker startDate;

	private Button btnCancel;

	private Button btnOkay;

	public DateTime selectedStartDate
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

	public DateTime selectedEndDate
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

	public frmSelectDateRange()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private DateTime method_3(DateTime dateTime_2)
	{
		frmDateSelector frmDateSelector = new frmDateSelector(dateTime_2);
		if (frmDateSelector.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_2;
	}

	private void startDate_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_3(dateTimePicker.Value);
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		selectedStartDate = startDate.Value;
		selectedEndDate = endDate.Value;
		base.DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, EventArgs e)
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
		lblTitle = new Label();
		label1 = new Label();
		endDate = new DateTimePicker();
		startDate = new DateTimePicker();
		btnCancel = new Button();
		btnOkay = new Button();
		SuspendLayout();
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-13, 4);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(441, 46);
		lblTitle.TabIndex = 175;
		lblTitle.Text = "SELECT DATE RANGE";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 10f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(180, 51);
		label1.Name = "label1";
		label1.Size = new Size(60, 35);
		label1.TabIndex = 178;
		label1.Text = "TO";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		endDate.Font = new Font("Microsoft Sans Serif", 18f);
		endDate.Format = DateTimePickerFormat.Short;
		endDate.Location = new Point(241, 51);
		endDate.Name = "endDate";
		endDate.Size = new Size(180, 35);
		endDate.TabIndex = 177;
		endDate.MouseDown += startDate_MouseDown;
		startDate.Checked = false;
		startDate.CustomFormat = "MM/dd/yyyy";
		startDate.Font = new Font("Microsoft Sans Serif", 18f);
		startDate.Format = DateTimePickerFormat.Short;
		startDate.Location = new Point(-1, 51);
		startDate.Name = "startDate";
		startDate.Size = new Size(180, 35);
		startDate.TabIndex = 176;
		startDate.MouseDown += startDate_MouseDown;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(214, 88);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(214, 80);
		btnCancel.TabIndex = 180;
		btnCancel.Text = "Cancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		btnOkay.FlatStyle = FlatStyle.Flat;
		btnOkay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.ImeMode = ImeMode.NoControl;
		btnOkay.Location = new Point(-1, 87);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(214, 80);
		btnOkay.TabIndex = 179;
		btnOkay.Text = "Okay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(422, 171);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label1);
		base.Controls.Add(endDate);
		base.Controls.Add(startDate);
		base.Controls.Add(lblTitle);
		base.Name = "frmSelectDateRange";
		base.Opacity = 1.0;
		Text = "frmSelectDateRange";
		ResumeLayout(performLayout: false);
	}
}
