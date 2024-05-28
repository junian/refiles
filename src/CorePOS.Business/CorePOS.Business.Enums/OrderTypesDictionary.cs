using System.Collections.Generic;

namespace CorePOS.Business.Enums;

public static class OrderTypesDictionary
{
	public static readonly Dictionary<string, string> OrderTypes;

	static OrderTypesDictionary()
	{
		Class2.oOsq41PzvTVMr();
		OrderTypes = new Dictionary<string, string>
		{
			{ "Delivery", "Delivery" },
			{ "Delivery-Online", "Delivery-Online" },
			{ "Dine In", "Dine In" },
			{ "Dine-In-Online", "Dine-In-Online" },
			{ "Pick-Up", "Pick-Up" },
			{ "Pick-Up-Online", "Pick-Up-Online" },
			{ "Pick-Up-Curbside-Online", "Pick-Up-Curbside-Online" },
			{ "To-Go", "To-Go" },
			{ "Make To Stock", "Make To Stock" },
			{ "Catering", "Catering" }
		};
	}
}
