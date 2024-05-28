using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public static class TextFilters
{
	public static void NumbersWithSingleDecimalPoint(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
		{
			e.Handled = true;
		}
		if (!(sender is TextBox textBox))
		{
			RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
			if (e.KeyChar == '.' && radTextBoxControl.Text.Contains("."))
			{
				e.Handled = true;
			}
		}
		else if (e.KeyChar == '.' && textBox.Text.Contains("."))
		{
			e.Handled = true;
		}
	}

	public static void NumberOnly(object sender, KeyPressEventArgs e)
	{
		if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
		{
			e.Handled = true;
		}
	}

	public static string FirstCharToUpper(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			throw new ArgumentException("ARGH!");
		}
		return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));
	}

	public static string ToTitleCase(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return "";
		}
		return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower().Replace("_", " "));
	}

	public static string GetOrderNumberDisplay(Order order)
	{
		string orderNumber = order.OrderNumber;
		string orderType = order.OrderType;
		string orderTicketNumber = order.OrderTicketNumber;
		string subSource = order.SubSource;
		string text = orderNumber;
		if (!orderNumber.Contains("WEB") && !orderType.ToUpper().Contains("ONLINE"))
		{
			text = ((!(SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON")) ? orderNumber.ToUpper() : ((!string.IsNullOrEmpty(orderTicketNumber)) ? orderTicketNumber.ToUpper() : orderNumber.ToUpper()));
		}
		else
		{
			text = ((orderNumber.Length > 15) ? orderNumber.Substring(orderNumber.Length - 4, 4).ToUpper() : orderNumber.ToUpper());
			if (!string.IsNullOrEmpty(subSource) && !string.IsNullOrEmpty(orderTicketNumber))
			{
				text = orderTicketNumber.ToUpper();
			}
		}
		return text;
	}
}
