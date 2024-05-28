using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS;

internal class Class16 : Button
{
	public PopupNavButtonDirection popupNavButtonDirection_0;

	private List<Button> list_0;

	private Form form_0;

	public Class16()
	{
		Class26.Ggkj0JxzN9YmC();
		list_0 = new List<Button>();
		// base._002Ector();
		base.Click += Class16_Click;
		base.LostFocus += Class16_LostFocus;
	}

	public void method_0(Button button_0)
	{
		button_0.LostFocus += Class16_LostFocus;
		button_0.Visible = false;
		list_0.Add(button_0);
	}

	public void method_1(Button button_0)
	{
		list_0.Remove(button_0);
	}

	public void method_2(Form form_1)
	{
		form_0 = form_1;
	}

	private void Class16_Click(object sender, EventArgs e)
	{
		form_0 = FindForm();
		int num = 0;
		foreach (Button item in list_0)
		{
			int num2 = 0;
			int num3 = 0;
			if (popupNavButtonDirection_0 == PopupNavButtonDirection.Right)
			{
				num2 = PointToScreen(Point.Empty).X + base.Width;
				num3 = PointToScreen(Point.Empty).Y + num;
			}
			item.Location = new Point(num2, (num > 0) ? (num3 - 3) : (num3 - 1));
			if (form_0.Controls.Find(item.Name, searchAllChildren: false).FirstOrDefault() == null)
			{
				form_0.Controls.Add(item);
				item.BringToFront();
			}
			num += item.Height;
		}
		if (list_0.FirstOrDefault() != null)
		{
			method_3(!list_0.FirstOrDefault().Visible);
		}
	}

	private void Class16_LostFocus(object sender, EventArgs e)
	{
		if (Focused || list_0.Count <= 0)
		{
			return;
		}
		bool flag = false;
		foreach (Button item in list_0)
		{
			if (item.Focused)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			method_3(bool_0: false);
		}
	}

	private void method_3(bool bool_0)
	{
		foreach (Button item in list_0)
		{
			item.Visible = bool_0;
		}
	}
}
