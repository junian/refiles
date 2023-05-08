using System;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS.CustomControls;

public class CustomDateControl : DateTimePicker
{
	public CustomDateControl()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		base.MouseDown += CustomDateControl_MouseDown;
		base.Format = DateTimePickerFormat.Short;
		Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular);
		base.CalendarFont = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular);
	}

	private DateTime method_0(DateTime dateTime_0)
	{
		frmDateSelector frmDateSelector = new frmDateSelector(dateTime_0);
		if (frmDateSelector.ShowDialog() == DialogResult.OK)
		{
			FindForm().DialogResult = DialogResult.None;
			return frmDateSelector.returnDate;
		}
		FindForm().DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void CustomDateControl_MouseDown(object sender, MouseEventArgs e)
	{
		base.Value = method_0(base.Value);
	}
}
