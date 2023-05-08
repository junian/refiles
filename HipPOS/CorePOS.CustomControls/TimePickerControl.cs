using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS.CustomControls;

public class TimePickerControl : UserControl
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	private int int_1;

	private int int_2;

	private IContainer icontainer_0;

	private RadioButton optPM;

	private RadioButton optAM;

	private Label lblHour;

	private Label lblMinute;

	internal Button btnHourUp;

	internal Button btnMinuteUp;

	internal Button btnMinuteDown;

	internal Button btnHourDown;

	public DateTime Time
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

	public string TimeString
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int MinuteIncrement
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public TimePickerControl()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent();
	}

	private DateTime method_0()
	{
		int num = (optPM.Checked ? (int_1 + 12) : int_1);
		return DateTime.Now.Date.AddHours(num).AddMinutes(int_2);
	}

	private void btnMinuteUp_Click(object sender, EventArgs e)
	{
	}

	private void btnHourUp_Click(object sender, EventArgs e)
	{
	}

	private void btnHourDown_Click(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.CustomControls.TimePickerControl));
		this.optPM = new System.Windows.Forms.RadioButton();
		this.optAM = new System.Windows.Forms.RadioButton();
		this.lblHour = new System.Windows.Forms.Label();
		this.lblMinute = new System.Windows.Forms.Label();
		this.btnHourUp = new System.Windows.Forms.Button();
		this.btnMinuteUp = new System.Windows.Forms.Button();
		this.btnMinuteDown = new System.Windows.Forms.Button();
		this.btnHourDown = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.optPM.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.optPM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.optPM.Checked = true;
		this.optPM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.optPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold);
		this.optPM.ForeColor = System.Drawing.Color.White;
		this.optPM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.optPM.Location = new System.Drawing.Point(206, 94);
		this.optPM.Name = "optPM";
		this.optPM.Padding = new System.Windows.Forms.Padding(10);
		this.optPM.Size = new System.Drawing.Size(110, 91);
		this.optPM.TabIndex = 39;
		this.optPM.TabStop = true;
		this.optPM.Text = "PM";
		this.optPM.UseVisualStyleBackColor = false;
		this.optAM.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.optAM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.optAM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.optAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold);
		this.optAM.ForeColor = System.Drawing.Color.White;
		this.optAM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.optAM.Location = new System.Drawing.Point(206, 2);
		this.optAM.Name = "optAM";
		this.optAM.Padding = new System.Windows.Forms.Padding(10);
		this.optAM.Size = new System.Drawing.Size(110, 91);
		this.optAM.TabIndex = 38;
		this.optAM.TabStop = true;
		this.optAM.Text = "AM";
		this.optAM.UseVisualStyleBackColor = false;
		this.lblHour.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 40f, System.Drawing.FontStyle.Bold);
		this.lblHour.ForeColor = System.Drawing.Color.White;
		this.lblHour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblHour.Location = new System.Drawing.Point(2, 51);
		this.lblHour.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.lblHour.Name = "lblHour";
		this.lblHour.Size = new System.Drawing.Size(101, 85);
		this.lblHour.TabIndex = 179;
		this.lblHour.Text = "00";
		this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblMinute.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.lblMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 40f, System.Drawing.FontStyle.Bold);
		this.lblMinute.ForeColor = System.Drawing.Color.White;
		this.lblMinute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblMinute.Location = new System.Drawing.Point(104, 51);
		this.lblMinute.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
		this.lblMinute.Name = "lblMinute";
		this.lblMinute.Size = new System.Drawing.Size(101, 85);
		this.lblMinute.TabIndex = 180;
		this.lblMinute.Text = "00";
		this.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.btnHourUp.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnHourUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnHourUp.FlatAppearance.BorderSize = 0;
		this.btnHourUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnHourUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHourUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold);
		this.btnHourUp.ForeColor = System.Drawing.Color.White;
		this.btnHourUp.Image = (System.Drawing.Image)resources.GetObject("btnHourUp.Image");
		this.btnHourUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnHourUp.Location = new System.Drawing.Point(2, 2);
		this.btnHourUp.Name = "btnHourUp";
		this.btnHourUp.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		this.btnHourUp.Size = new System.Drawing.Size(101, 48);
		this.btnHourUp.TabIndex = 181;
		this.btnHourUp.UseVisualStyleBackColor = false;
		this.btnHourUp.Click += new System.EventHandler(btnHourUp_Click);
		this.btnMinuteUp.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnMinuteUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnMinuteUp.FlatAppearance.BorderSize = 0;
		this.btnMinuteUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnMinuteUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMinuteUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold);
		this.btnMinuteUp.ForeColor = System.Drawing.Color.White;
		this.btnMinuteUp.Image = (System.Drawing.Image)resources.GetObject("btnMinuteUp.Image");
		this.btnMinuteUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnMinuteUp.Location = new System.Drawing.Point(104, 2);
		this.btnMinuteUp.Name = "btnMinuteUp";
		this.btnMinuteUp.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		this.btnMinuteUp.Size = new System.Drawing.Size(101, 48);
		this.btnMinuteUp.TabIndex = 182;
		this.btnMinuteUp.UseVisualStyleBackColor = false;
		this.btnMinuteUp.Click += new System.EventHandler(btnMinuteUp_Click);
		this.btnMinuteDown.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnMinuteDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnMinuteDown.FlatAppearance.BorderSize = 0;
		this.btnMinuteDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnMinuteDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMinuteDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold);
		this.btnMinuteDown.ForeColor = System.Drawing.Color.White;
		this.btnMinuteDown.Image = (System.Drawing.Image)resources.GetObject("btnMinuteDown.Image");
		this.btnMinuteDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnMinuteDown.Location = new System.Drawing.Point(104, 137);
		this.btnMinuteDown.Name = "btnMinuteDown";
		this.btnMinuteDown.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		this.btnMinuteDown.Size = new System.Drawing.Size(101, 48);
		this.btnMinuteDown.TabIndex = 184;
		this.btnMinuteDown.UseVisualStyleBackColor = false;
		this.btnHourDown.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnHourDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnHourDown.FlatAppearance.BorderSize = 0;
		this.btnHourDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnHourDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHourDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold);
		this.btnHourDown.ForeColor = System.Drawing.Color.White;
		this.btnHourDown.Image = (System.Drawing.Image)resources.GetObject("btnHourDown.Image");
		this.btnHourDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnHourDown.Location = new System.Drawing.Point(2, 137);
		this.btnHourDown.Name = "btnHourDown";
		this.btnHourDown.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
		this.btnHourDown.Size = new System.Drawing.Size(101, 48);
		this.btnHourDown.TabIndex = 183;
		this.btnHourDown.UseVisualStyleBackColor = false;
		this.btnHourDown.Click += new System.EventHandler(btnHourDown_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.btnMinuteDown);
		base.Controls.Add(this.btnHourDown);
		base.Controls.Add(this.btnMinuteUp);
		base.Controls.Add(this.btnHourUp);
		base.Controls.Add(this.lblMinute);
		base.Controls.Add(this.lblHour);
		base.Controls.Add(this.optPM);
		base.Controls.Add(this.optAM);
		base.Name = "TimePickerControl";
		base.Size = new System.Drawing.Size(321, 188);
		base.ResumeLayout(false);
	}
}
