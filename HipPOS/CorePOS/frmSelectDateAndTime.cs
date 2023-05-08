using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;

namespace CorePOS;

public class frmSelectDateAndTime : frmMasterForm
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

	private DateTime? nullable_0;

	private string string_0;

	private int int_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private DateTimePicker startTimePicker;

	private Button btnCancel;

	private Button btnOkay;

	private DateTimePicker DatePick;

	public DateTime returnDate
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

	public DateTime returnTime
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

	public frmSelectDateAndTime(string title = "SELECT DATE && TIME", DateTime? MaxDate = null, string orderType = "", int timeIncrement = 15, DateTime? SelectedDateTime = null)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		int_0 = 15;
		base._002Ector();
		InitializeComponent_1();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("pickup_order_time_increment");
		if (title.Contains("FULFILLMENT"))
		{
			int_0 = int.Parse(settingValueByKey);
		}
		else
		{
			int_0 = timeIncrement;
		}
		lblTitle.Text = title;
		if (MaxDate.HasValue)
		{
			nullable_0 = MaxDate;
		}
		DateTime dateTime = ((!SelectedDateTime.HasValue) ? DateTime.Now : ((SelectedDateTime.Value > DateTime.Now) ? SelectedDateTime.Value : DateTime.Now));
		DateTime dateTime2 = dateTime;
		int num = dateTime2.Minute / timeIncrement;
		startTimePicker.Value = dateTime.AddMinutes(num * timeIncrement - dateTime2.Minute);
		if (startTimePicker.Value < DateTime.Now)
		{
			num++;
			startTimePicker.Value = dateTime.AddMinutes(num * timeIncrement - dateTime2.Minute);
		}
		DatePick.Value = dateTime;
		string_0 = orderType;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnOkay_Click(object sender, EventArgs e)
	{
		if (nullable_0.HasValue && nullable_0.Value < DatePick.Value)
		{
			if (lblTitle.Text == "SELECT FULFILLMENT DATE" && string_0 != OrderTypes.Catering)
			{
				new NotificationLabel(this, "Fulfillment date can only be up to 7 Days in advanced.", NotificationTypes.Notification).Show();
			}
			else
			{
				new NotificationLabel(this, "Date can only be up to " + (nullable_0.Value - DateTime.Now.Date).Days + " Days in advanced.", NotificationTypes.Notification).Show();
			}
			base.DialogResult = DialogResult.None;
		}
		else if (new DateTime(DatePick.Value.Year, DatePick.Value.Month, DatePick.Value.Day, startTimePicker.Value.Hour, startTimePicker.Value.Minute, 0) < DateTime.Now.AddMinutes(-1.0))
		{
			new NotificationLabel(this, "Date && Time selected is earlier than current time.", NotificationTypes.Notification).Show();
			base.DialogResult = DialogResult.None;
		}
		else
		{
			returnDate = DatePick.Value;
			returnTime = startTimePicker.Value;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private DateTime method_3(DateTime dateTime_2)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_2);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_2;
	}

	private DateTime method_4(DateTime dateTime_2)
	{
		frmTimePicker frmTimePicker2 = new frmTimePicker(dateTime_2, int_0);
		if (frmTimePicker2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmTimePicker2.Time;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_2;
	}

	private void agpoHjymhm(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_3(dateTimePicker.Value);
	}

	private void startTimePicker_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_4(dateTimePicker.Value);
	}

	private void DatePick_ValueChanged(object sender, EventArgs e)
	{
	}

	private void startTimePicker_ValueChanged(object sender, EventArgs e)
	{
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
		DatePick = new DateTimePicker();
		btnCancel = new Button();
		btnOkay = new Button();
		startTimePicker = new DateTimePicker();
		lblTitle = new Label();
		SuspendLayout();
		DatePick.CalendarFont = new Font("Microsoft Sans Serif", 25f);
		DatePick.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		DatePick.Format = DateTimePickerFormat.Short;
		DatePick.Location = new Point(7, 55);
		DatePick.Margin = new Padding(5);
		DatePick.MinimumSize = new Size(215, 54);
		DatePick.Name = "DatePick";
		DatePick.Size = new Size(215, 54);
		DatePick.TabIndex = 179;
		DatePick.ValueChanged += DatePick_ValueChanged;
		DatePick.MouseDown += agpoHjymhm;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(222, 109);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(214, 80);
		btnCancel.TabIndex = 178;
		btnCancel.Text = "Cancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		btnOkay.FlatStyle = FlatStyle.Flat;
		btnOkay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.ImeMode = ImeMode.NoControl;
		btnOkay.Location = new Point(7, 109);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(214, 80);
		btnOkay.TabIndex = 177;
		btnOkay.Text = "Okay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += btnOkay_Click;
		startTimePicker.CustomFormat = "hh:mm tt";
		startTimePicker.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		startTimePicker.Format = DateTimePickerFormat.Custom;
		startTimePicker.Location = new Point(222, 55);
		startTimePicker.Margin = new Padding(5);
		startTimePicker.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
		startTimePicker.MinDate = new DateTime(2015, 1, 1, 0, 0, 0, 0);
		startTimePicker.MinimumSize = new Size(215, 54);
		startTimePicker.Name = "startTimePicker";
		startTimePicker.Size = new Size(215, 54);
		startTimePicker.TabIndex = 176;
		startTimePicker.ValueChanged += startTimePicker_ValueChanged;
		startTimePicker.MouseDown += startTimePicker_MouseDown;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(7, 7);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(430, 46);
		lblTitle.TabIndex = 174;
		lblTitle.Text = "SELECT DATE && TIME";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(444, 202);
		base.Controls.Add(DatePick);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(startTimePicker);
		base.Controls.Add(lblTitle);
		base.Name = "frmSelectDateAndTime";
		base.Opacity = 1.0;
		Text = "frmSelectDateAndTime";
		ResumeLayout(performLayout: false);
	}
}
