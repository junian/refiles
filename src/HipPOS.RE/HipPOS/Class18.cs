using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;

internal class Class18 : TextBox
{
	[CompilerGenerated]
	private string string_0;

	public ListBox listBox_0;

	[SpecialName]
	[CompilerGenerated]
	public string method_0()
	{
		return string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(string string_1)
	{
		string_0 = string_1;
	}

	public Class18()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		method_1(TextBoxTypes.keyboard);
		base.KeyPress += Class18_KeyPress;
	}

	public void method_2()
	{
		if (listBox_0 == null && method_0() == TextBoxTypes.address)
		{
			listBox_0 = new ListBox();
			base.Parent.Controls.Add(listBox_0);
			int left = base.Left;
			int num = base.Top + base.FontHeight;
			int num2 = base.Width;
			int num3 = base.Height + 15;
			listBox_0.SetBounds(left, num, num2, num3);
			listBox_0.Click += listBox_0_Click;
			listBox_0.Font = new Font("Microsoft Sans Serif", 22f, FontStyle.Regular);
			listBox_0.BringToFront();
		}
		else if (listBox_0 != null && method_0() != TextBoxTypes.address)
		{
			listBox_0.Hide();
			listBox_0 = null;
		}
	}

	private void Class18_KeyPress(object sender, KeyPressEventArgs e)
	{
		method_2();
		char c = '.';
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			c = ',';
		}
		if (method_0() == TextBoxTypes.numpad)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != c)
			{
				e.Handled = true;
			}
			if (e.KeyChar == c && (sender as TextBox).Text.IndexOf(c) > -1)
			{
				e.Handled = true;
			}
		}
		else if (method_0() == TextBoxTypes.numpad_no_decimal)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}
		else
		{
			if (!(method_0() == TextBoxTypes.address))
			{
				return;
			}
			if (!string.IsNullOrEmpty(Text) && Text.Length > 8 && Text.Length <= 20)
			{
				List<string> suggestedAddress = GoogleMethods.GetSuggestedAddress(Text);
				if (suggestedAddress.Any() && !string.IsNullOrEmpty(Text))
				{
					listBox_0.DataSource = suggestedAddress;
					listBox_0.Height = (base.FontHeight - 3) * suggestedAddress.Count();
					listBox_0.Show();
				}
			}
			else
			{
				listBox_0.Hide();
			}
		}
	}

	private void listBox_0_Click(object sender, EventArgs e)
	{
		listBox_0.Hide();
		Text = ((ListBox)sender).SelectedItem.ToString();
	}
}
