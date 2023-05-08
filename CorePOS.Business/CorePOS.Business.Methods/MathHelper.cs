using System;
using System.Data;
using System.Linq;
using System.Threading;

namespace CorePOS.Business.Methods;

public static class MathHelper
{
	public static string DecimalToFraction(decimal num, double epsilon = 0.0001, int maxIterations = 20)
	{
		if (num < 1m)
		{
			try
			{
				if (num % 1m == 0m)
				{
					return ((int)num).ToString();
				}
				decimal[] array = new decimal[maxIterations + 2];
				array[1] = 1m;
				decimal num2 = num;
				decimal num3 = 1m;
				int num4 = 1;
				if (num2 == 0m)
				{
					return "0";
				}
				int num5 = (int)num;
				decimal num6 = num - Convert.ToDecimal(num5);
				while (num4 < maxIterations && Math.Abs(num3 / array[num4] - num) > (decimal)epsilon)
				{
					num4++;
					num2 = 1m / (num2 - (decimal)(int)num2);
					array[num4] = array[num4 - 1] * (decimal)(int)num2 + array[num4 - 2];
					num3 = (int)(num6 * array[num4] + 0.5m);
				}
				return string.Format(((num5 > 0) ? (num5 + " ") : "") + "{0}/{1}", num3.ToString(), array[num4].ToString());
			}
			catch
			{
				return RemoveTrailingZeros(num.ToString());
			}
		}
		return RemoveTrailingZeros(num.ToString());
	}

	public static decimal FractionToDecimal(string fraction, int decimal_spaces = 4)
	{
		for (int i = 1; i <= 9; i++)
		{
			if (fraction.Length == 3)
			{
				fraction = fraction.Replace(i + "/" + i, string.Empty).Trim().Replace(",", ".");
			}
		}
		if (string.IsNullOrEmpty(fraction))
		{
			fraction = "1";
		}
		return Math.Round(Convert.ToDecimal(new DataTable().Compute(fraction, null)), decimal_spaces);
	}

	public static string RemoveTrailingZeros(string decimalString, int decimalspaces = 0)
	{
		char c = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
		if (decimalString.Contains(c))
		{
			string[] array = decimalString.Split(c);
			if (array[1].Length > 0)
			{
				bool flag = false;
				do
				{
					if (array[1].Length <= decimalspaces)
					{
						flag = true;
					}
					else if (array[1].Substring(array[1].Length - 1, 1) == "0")
					{
						array[1] = array[1].Remove(array[1].Length - 1, 1);
					}
					else
					{
						flag = true;
					}
				}
				while (!flag);
			}
			if (array[1].Length == 0)
			{
				return array[0];
			}
			return array[0] + c + array[1];
		}
		return decimalString;
	}

	public static string FormatPriceDecimals(decimal price)
	{
		string result = "0.00";
		if (price > 0m)
		{
			string[] array = price.ToString().Split('.');
			if (array.Count() == 2)
			{
				if (array[1].Length > 3 && array[1].Substring(array[1].Length - 1, 1) == "0")
				{
					array[1] = array[1].Substring(0, array[1].Length - 1);
				}
				if (array[1].Length > 2 && array[1].Substring(array[1].Length - 1, 1) != "0")
				{
					result = "0.000";
				}
			}
		}
		return result;
	}

	public static decimal ToDecimal(string number, decimal defaultValue = 0m)
	{
		if (string.IsNullOrEmpty(number))
		{
			return defaultValue;
		}
		if (decimal.TryParse(number.RemoveAllNonNumeric().Replace(",", ""), out var result))
		{
			return result;
		}
		return defaultValue;
	}

	public static int ToInt32(string number, int defaultValue = 0)
	{
		if (string.IsNullOrEmpty(number))
		{
			return defaultValue;
		}
		if (int.TryParse(number.RemoveAllNonNumeric().Replace(",", ""), out var result))
		{
			return result;
		}
		return defaultValue;
	}

	public static string RemoveAllNonNumeric(this string value)
	{
		value = string.Concat(value.Where((char c) => (c >= '0' && c <= '9') || c == ',' || c == '.' || c == '-'));
		if (string.IsNullOrEmpty(value))
		{
			value = "0";
		}
		return value;
	}

	public static decimal ToDecimalWithCleanUp(this string str)
	{
		return Convert.ToDecimal(str.RemoveAllNonNumeric());
	}

	public static decimal ConvertDistance(this decimal distanceInKM)
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("delivery_distance_uom");
		if (settingValueByKey != "KM" && settingValueByKey == "MI")
		{
			return distanceInKM * 0.6213m;
		}
		return distanceInKM;
	}

	public static bool IsOverlapping(int start1, int end1, int start2, int end2)
	{
		if (Math.Max(0, Math.Min(end1, end2) - Math.Max(start1, start2) + 1) > 0)
		{
			return true;
		}
		return false;
	}

	public static bool IsOverlapping(decimal start1, decimal end1, decimal start2, decimal end2, decimal overlappingValue = 0m)
	{
		if (Math.Max(0m, Math.Min(end1, end2) - Math.Max(start1, start2) + 1m) > overlappingValue)
		{
			return true;
		}
		return false;
	}
}
