using System;
using System.Threading;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public class SaleMethods
{
	private static decimal smethod_0(Item item_0)
	{
		string text = DateTime.Now.DayOfWeek.ToString();
		string[] array = item_0.DaysSaleList.Split('|');
		int num = 0;
		string text2;
		while (true)
		{
			if (num < array.Length)
			{
				text2 = array[num];
				if (text.ToLower() == text2.Split(':')[0].ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			return 0m;
		}
		string obj = (string.IsNullOrEmpty(text2.Split(':')[1]) ? "0" : text2.Split(':')[1]);
		string currencyDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
		decimal num2 = Convert.ToDecimal(obj.Replace(".", currencyDecimalSeparator));
		return item_0.ItemPrice - item_0.ItemPrice * (num2 * Convert.ToDecimal(0.01));
	}

	public SaleMethods()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}
