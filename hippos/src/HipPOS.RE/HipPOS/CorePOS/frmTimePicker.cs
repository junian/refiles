using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS;

public class frmTimePicker : frmMasterForm
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private IContainer icontainer_1;

	private Button btnDone;

	internal Button btnMinuteDown;

	internal Button btnHourDown;

	internal Button btnMinuteUp;

	internal Button btnHourUp;

	private Label lblMinute;

	private Label lblHour;

	private Button btnCancel;

	private CheckBox optAM;

	private CheckBox optPM;

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

	public frmTimePicker(DateTime _Time, int _MinuteIncrement = 1)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = _MinuteIncrement;
		Time = _Time;
	}

	private void frmTimePicker_Load(object sender, EventArgs e)
	{
		int_1 = Time.Hour;
		int_2 = Time.Minute;
		if (int_1 >= 12)
		{
			if (int_1 > 12)
			{
				int_1 -= 12;
			}
			optPM.Checked = true;
			optAM.Checked = false;
		}
		else
		{
			if (int_1 == 0)
			{
				int_1 = 12;
			}
			optPM.Checked = false;
			optAM.Checked = true;
		}
		lblHour.Text = int_1.ToString();
		lblMinute.Text = ((int_2 < 10) ? ("0" + int_2) : int_2.ToString());
	}

	private void method_3(string string_1)
	{
		if (int_2 >= 60)
		{
			int_2 -= 60;
			int_1++;
		}
		else if (int_2 < 0)
		{
			int_2 += 60;
			int_1--;
		}
		if (int_1 > 12)
		{
			int_1 = 1;
		}
		else if (int_1 < 1)
		{
			int_1 = 12;
		}
		else if (int_1 == 12)
		{
			if (string_1 == "up")
			{
				if (optAM.Checked)
				{
					optPM.Checked = true;
					optAM.Checked = false;
				}
				else
				{
					optPM.Checked = false;
					optAM.Checked = true;
				}
			}
		}
		else if (int_1 == 11 && string_1 == "down")
		{
			if (optAM.Checked)
			{
				optPM.Checked = true;
				optAM.Checked = false;
			}
			else
			{
				optPM.Checked = false;
				optAM.Checked = true;
			}
		}
		lblHour.Text = int_1.ToString();
		lblMinute.Text = ((int_2 < 10) ? ("0" + int_2) : int_2.ToString());
	}

	private void method_4(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnMinuteUp_Click(object sender, EventArgs e)
	{
		int_2 += int_0;
		method_3("up");
	}

	private void btnMinuteDown_Click(object sender, EventArgs e)
	{
		int_2 -= int_0;
		method_3("down");
	}

	private void btnHourUp_Click(object sender, EventArgs e)
	{
		int_1++;
		method_3("up");
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void optAM_Click(object sender, EventArgs e)
	{
		optAM.Checked = true;
		optPM.Checked = false;
	}

	private void optPM_Click(object sender, EventArgs e)
	{
		optAM.Checked = false;
		optPM.Checked = true;
	}

	private void method_5(object sender, EventArgs e)
	{
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	private void btnHourDown_Click(object sender, EventArgs e)
	{
		int_1--;
		method_3("down");
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		int num = ((!optPM.Checked) ? ((int_1 != 12) ? int_1 : 0) : ((int_1 == 12) ? int_1 : (int_1 + 12)));
		Time = Time.Date.AddHours(num).AddMinutes(int_2);
		TimeString = lblHour.Text + ":" + lblMinute.Text + " " + (optAM.Checked ? "AM" : "PM");
		base.DialogResult = DialogResult.OK;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTimePicker));
		btnDone = new Button();
		btnMinuteDown = new Button();
		btnHourDown = new Button();
		btnMinuteUp = new Button();
		btnHourUp = new Button();
		lblMinute = new Label();
		lblHour = new Label();
		btnCancel = new Button();
		optAM = new CheckBox();
		optPM = new CheckBox();
		SuspendLayout();
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = SystemColors.ButtonFace;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		btnMinuteDown.BackColor = Color.FromArgb(61, 142, 185);
		btnMinuteDown.FlatAppearance.BorderColor = Color.Black;
		btnMinuteDown.FlatAppearance.BorderSize = 0;
		btnMinuteDown.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnMinuteDown, "btnMinuteDown");
		btnMinuteDown.ForeColor = Color.White;
		btnMinuteDown.Name = "btnMinuteDown";
		btnMinuteDown.UseVisualStyleBackColor = false;
		btnMinuteDown.Click += btnMinuteDown_Click;
		btnHourDown.BackColor = Color.FromArgb(61, 142, 185);
		btnHourDown.FlatAppearance.BorderColor = Color.Black;
		btnHourDown.FlatAppearance.BorderSize = 0;
		btnHourDown.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnHourDown, "btnHourDown");
		btnHourDown.ForeColor = Color.White;
		btnHourDown.Name = "btnHourDown";
		btnHourDown.UseVisualStyleBackColor = false;
		btnHourDown.Click += btnHourDown_Click;
		btnMinuteUp.BackColor = Color.FromArgb(61, 142, 185);
		btnMinuteUp.FlatAppearance.BorderColor = Color.Black;
		btnMinuteUp.FlatAppearance.BorderSize = 0;
		btnMinuteUp.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnMinuteUp, "btnMinuteUp");
		btnMinuteUp.ForeColor = Color.White;
		btnMinuteUp.Name = "btnMinuteUp";
		btnMinuteUp.UseVisualStyleBackColor = false;
		btnMinuteUp.Click += btnMinuteUp_Click;
		btnHourUp.BackColor = Color.FromArgb(61, 142, 185);
		btnHourUp.FlatAppearance.BorderColor = Color.Black;
		btnHourUp.FlatAppearance.BorderSize = 0;
		btnHourUp.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnHourUp, "btnHourUp");
		btnHourUp.ForeColor = Color.White;
		btnHourUp.Name = "btnHourUp";
		btnHourUp.UseVisualStyleBackColor = false;
		btnHourUp.Click += btnHourUp_Click;
		lblMinute.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(lblMinute, "lblMinute");
		lblMinute.ForeColor = Color.White;
		lblMinute.Name = "lblMinute";
		lblHour.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(lblHour, "lblHour");
		lblHour.ForeColor = Color.White;
		lblHour.Name = "lblHour";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		optAM.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(optAM, "optAM");
		optAM.ForeColor = Color.White;
		optAM.Name = "optAM";
		optAM.UseVisualStyleBackColor = false;
		optAM.Click += optAM_Click;
		optPM.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(optPM, "optPM");
		optPM.ForeColor = Color.White;
		optPM.Name = "optPM";
		optPM.UseVisualStyleBackColor = false;
		optPM.Click += optPM_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(optPM);
		base.Controls.Add(optAM);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnDone);
		base.Controls.Add(btnMinuteDown);
		base.Controls.Add(btnHourDown);
		base.Controls.Add(btnMinuteUp);
		base.Controls.Add(btnHourUp);
		base.Controls.Add(lblMinute);
		base.Controls.Add(lblHour);
		base.Name = "frmTimePicker";
		base.Opacity = 1.0;
		base.Load += frmTimePicker_Load;
		ResumeLayout(performLayout: false);
	}
}
