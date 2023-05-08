using System;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS.CustomControls;

public class CustomTimeControl : DateTimePicker
{
	public CustomTimeControl()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		base.MouseDown += CustomTimeControl_MouseDown;
		base.Format = DateTimePickerFormat.Time;
		Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular);
		base.CalendarFont = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular);
		base.ShowUpDown = true;
	}

	private DateTime method_0(DateTime dateTime_0)
	{
		frmTimePicker frmTimePicker = new frmTimePicker(dateTime_0);
		if (frmTimePicker.ShowDialog() == DialogResult.OK)
		{
			FindForm().DialogResult = DialogResult.None;
			return frmTimePicker.Time;
		}
		FindForm().DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void CustomTimeControl_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_0(dateTimePicker.Value);
	}
}
