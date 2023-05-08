using System;

namespace CorePOS.Business.Methods;

public static class DateHelper
{
	public static string ToElapsedTime(this DateTime date)
	{
		TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
		double num = Math.Abs(timeSpan.TotalSeconds);
		if (num < 60.0)
		{
			if (timeSpan.Seconds != 1)
			{
				return timeSpan.Seconds + " seconds ago";
			}
			return "one second ago";
		}
		if (num < 120.0)
		{
			return "a minute ago";
		}
		if (num < 2700.0)
		{
			return timeSpan.Minutes + " minutes ago";
		}
		if (num < 5400.0)
		{
			return "an hour ago";
		}
		if (num < 86400.0)
		{
			return timeSpan.Hours + " hours ago";
		}
		return date.ToShortDateString();
	}
}
