using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;

namespace CorePOS;

public class frmDateSelector : frmMasterForm
{
	[CompilerGenerated]
	private DateTime isNvqQuOjA;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private IContainer icontainer_1;

	internal Button btnNextMonth;

	private Label lblMonth;

	internal Button btnPrevMonth;

	private FlowLayoutPanel pnlCalendar;

	private Label label2;

	private Button btnCancel;

	public DateTime returnDate
	{
		[CompilerGenerated]
		get
		{
			return isNvqQuOjA;
		}
		[CompilerGenerated]
		set
		{
			isNvqQuOjA = value;
		}
	}

	public frmDateSelector(DateTime? selectedDate = null, bool withTime = false)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		if (selectedDate.HasValue)
		{
			dateTime_0 = selectedDate.Value;
		}
		else
		{
			dateTime_0 = DateTime.Now;
		}
		dateTime_1 = new DateTime(dateTime_0.Year, dateTime_0.Month, 1);
	}

	private void frmDateSelector_Load(object sender, EventArgs e)
	{
		method_3(dateTime_1);
	}

	private void method_3(DateTime dateTime_2)
	{
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		lblMonth.Text = currentCulture.DateTimeFormat.GetMonthName(dateTime_2.Date.Month).ToString() + " " + dateTime_2.Year;
		pnlCalendar.Controls.Clear();
		short num = (short)dateTime_2.DayOfWeek;
		DateTime dateTime = dateTime_2.AddDays(-num);
		for (int i = 0; i < 7; i++)
		{
			Label label = method_6(currentCulture.DateTimeFormat.GetDayName(dateTime.AddDays(i).DayOfWeek).ToString().Substring(0, 3)
				.ToUpper());
			label.BackColor = Color.FromArgb(50, 119, 155);
			label.Font = new Font(label.Font, FontStyle.Bold);
			pnlCalendar.Controls.Add(label);
		}
		int num2 = DateTime.DaysInMonth(dateTime_2.Year, dateTime_2.Month);
		int num3 = 0;
		int dayOfWeek = (int)dateTime_2.AddDays(num2).DayOfWeek;
		num3 = ((dayOfWeek != 0) ? (num + num2 + (7 - dayOfWeek)) : (num + num2));
		short num4 = (short)(num3 / 7);
		bool bool_ = true;
		if (num4 > 5)
		{
			bool_ = false;
		}
		for (int j = 0; j < num3; j++)
		{
			Button button = method_5(color_0: (dateTime.AddDays(j).Month == dateTime_2.Month) ? ((!(dateTime.AddDays(j).Date == dateTime_0.Date)) ? ((!(dateTime.AddDays(j).Date == DateTime.Now.Date)) ? Color.FromArgb(190, 195, 199) : HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"])) : HelperMethods.GetColor(HelperMethods.ButtonColors()["Yellow"])) : Color.FromArgb(150, 166, 166), string_0: dateTime.AddDays(j).Day.ToString(), string_1: dateTime.AddDays(j).Date.ToString(), eventHandler_0: method_4, bool_0: bool_);
			button.Name = button.Text;
			pnlCalendar.Controls.Add(button);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		DateTime dateTime = (returnDate = DateTime.Parse(((Button)sender).Tag.ToString()).Date);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private Button method_5(string string_0, Color color_0, string string_1, EventHandler eventHandler_0, bool bool_0 = true)
	{
		Button button = new Button();
		button.Text = string_0;
		button.Tag = string_1;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.BackColor = color_0;
		button.Click += eventHandler_0;
		int num = pnlCalendar.Width / 7 - 1;
		int num2 = pnlCalendar.Height / 5 - 6;
		if (bool_0)
		{
			button.Size = new Size(num, num2);
		}
		else
		{
			button.Size = new Size(num, pnlCalendar.Height / 6 - 5);
		}
		button.Font = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Regular);
		button.Margin = new Padding(1, 1, 0, 0);
		return button;
	}

	private Label method_6(string string_0)
	{
		int num = pnlCalendar.Width / 7 - 1;
		return new Label
		{
			Text = string_0,
			Tag = "lbl" + string_0,
			FlatStyle = FlatStyle.Flat,
			ForeColor = Color.White,
			BackColor = Color.FromArgb(47, 204, 113),
			TextAlign = ContentAlignment.MiddleCenter,
			Size = new Size(num, 30),
			Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular),
			Margin = new Padding(1, 1, 0, 0)
		};
	}

	private void btnNextMonth_Click(object sender, EventArgs e)
	{
		dateTime_1 = dateTime_1.AddMonths(1);
		method_3(dateTime_1);
	}

	private void btnPrevMonth_Click(object sender, EventArgs e)
	{
		dateTime_1 = dateTime_1.AddMonths(-1);
		method_3(dateTime_1);
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
		btnNextMonth = new Button();
		lblMonth = new Label();
		btnPrevMonth = new Button();
		pnlCalendar = new FlowLayoutPanel();
		label2 = new Label();
		btnCancel = new Button();
		SuspendLayout();
		btnNextMonth.BackColor = Color.FromArgb(61, 142, 185);
		btnNextMonth.FlatAppearance.BorderColor = Color.Black;
		btnNextMonth.FlatAppearance.BorderSize = 0;
		btnNextMonth.FlatAppearance.MouseDownBackColor = Color.White;
		btnNextMonth.FlatStyle = FlatStyle.Flat;
		btnNextMonth.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnNextMonth.ForeColor = Color.White;
		btnNextMonth.ImageAlign = ContentAlignment.MiddleRight;
		btnNextMonth.ImeMode = ImeMode.NoControl;
		btnNextMonth.Location = new Point(460, 31);
		btnNextMonth.Name = "btnNextMonth";
		btnNextMonth.Padding = new Padding(5, 0, 5, 0);
		btnNextMonth.Size = new Size(111, 48);
		btnNextMonth.TabIndex = 161;
		btnNextMonth.Text = "NEXT";
		btnNextMonth.TextAlign = ContentAlignment.MiddleLeft;
		btnNextMonth.UseVisualStyleBackColor = false;
		btnNextMonth.Click += btnNextMonth_Click;
		lblMonth.BackColor = Color.FromArgb(77, 174, 225);
		lblMonth.Font = new Font("Microsoft Sans Serif", 14f);
		lblMonth.ForeColor = Color.White;
		lblMonth.ImeMode = ImeMode.NoControl;
		lblMonth.Location = new Point(112, 31);
		lblMonth.Margin = new Padding(0, 0, 0, 1);
		lblMonth.MinimumSize = new Size(190, 48);
		lblMonth.Name = "lblMonth";
		lblMonth.Size = new Size(347, 48);
		lblMonth.TabIndex = 162;
		lblMonth.Text = "Items";
		lblMonth.TextAlign = ContentAlignment.MiddleCenter;
		btnPrevMonth.BackColor = Color.FromArgb(61, 142, 185);
		btnPrevMonth.FlatAppearance.BorderColor = Color.Black;
		btnPrevMonth.FlatAppearance.BorderSize = 0;
		btnPrevMonth.FlatAppearance.MouseDownBackColor = Color.White;
		btnPrevMonth.FlatStyle = FlatStyle.Flat;
		btnPrevMonth.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		btnPrevMonth.ForeColor = Color.White;
		btnPrevMonth.ImageAlign = ContentAlignment.MiddleLeft;
		btnPrevMonth.ImeMode = ImeMode.NoControl;
		btnPrevMonth.Location = new Point(0, 31);
		btnPrevMonth.Name = "btnPrevMonth";
		btnPrevMonth.Padding = new Padding(0, 0, 2, 0);
		btnPrevMonth.Size = new Size(111, 48);
		btnPrevMonth.TabIndex = 160;
		btnPrevMonth.Text = "PREV";
		btnPrevMonth.TextAlign = ContentAlignment.MiddleRight;
		btnPrevMonth.UseVisualStyleBackColor = false;
		btnPrevMonth.Click += btnPrevMonth_Click;
		pnlCalendar.BackColor = Color.Transparent;
		pnlCalendar.BorderStyle = BorderStyle.FixedSingle;
		pnlCalendar.Location = new Point(-1, 80);
		pnlCalendar.Margin = new Padding(0);
		pnlCalendar.Name = "pnlCalendar";
		pnlCalendar.Padding = new Padding(1);
		pnlCalendar.Size = new Size(572, 316);
		pnlCalendar.TabIndex = 158;
		label2.BackColor = Color.FromArgb(147, 101, 184);
		label2.Font = new Font("Microsoft Sans Serif", 13f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(0, 0);
		label2.MinimumSize = new Size(356, 30);
		label2.Name = "label2";
		label2.Size = new Size(571, 30);
		label2.TabIndex = 159;
		label2.Text = "Select Date";
		label2.TextAlign = ContentAlignment.MiddleCenter;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(330, 399);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(241, 60);
		btnCancel.TabIndex = 163;
		btnCancel.Text = "CANCEL";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(573, 462);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnNextMonth);
		base.Controls.Add(lblMonth);
		base.Controls.Add(btnPrevMonth);
		base.Controls.Add(pnlCalendar);
		base.Controls.Add(label2);
		base.Name = "frmDateSelector";
		base.Opacity = 1.0;
		Text = "Date Selector";
		base.Load += frmDateSelector_Load;
		ResumeLayout(performLayout: false);
	}
}
