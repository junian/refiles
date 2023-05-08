using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

internal class Class19 : ComboBox
{
	public Class19()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		base.DrawMode = DrawMode.OwnerDrawVariable;
		base.DrawItem += Class19_DrawItem;
	}

	private void Class19_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index < 0)
		{
			return;
		}
		Font font = Font;
		int num = base.ItemHeight / 6;
		string s = string.Empty;
		Type type = base.Items[e.Index].GetType();
		Type[] genericArguments = type.GetGenericArguments();
		if (type.IsGenericType && genericArguments[0].Name == "String")
		{
			s = ((KeyValuePair<string, string>)base.Items[e.Index]).Value;
		}
		else if (!type.IsGenericType || !(genericArguments[0].Name == "Int32"))
		{
			s = ((!type.IsGenericType || !(genericArguments[0].Name == "Object")) ? base.Items[e.Index].ToString() : ((KeyValuePair<object, string>)base.Items[e.Index]).Key.ToString());
		}
		else
		{
			KeyValuePair<int, string> keyValuePair = (KeyValuePair<int, string>)base.Items[e.Index];
			if (keyValuePair.Value != null)
			{
				s = keyValuePair.Value.ToString();
			}
		}
		if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
		{
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(212, 212, 212)), e.Bounds);
			e.Graphics.DrawString(s, font, new SolidBrush(Color.FromArgb(212, 212, 212)), new Point(e.Bounds.X, e.Bounds.Y + num));
		}
		else if ((e.State & DrawItemState.Focus) == 0)
		{
			e.Graphics.FillRectangle(Brushes.White, e.Bounds);
			e.Graphics.DrawString(s, font, new SolidBrush(ForeColor), new Point(e.Bounds.X, e.Bounds.Y + num));
		}
		else
		{
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), e.Bounds);
			e.Graphics.DrawString(s, font, new SolidBrush(Color.White), new Point(e.Bounds.X, e.Bounds.Y + num));
		}
	}
}
