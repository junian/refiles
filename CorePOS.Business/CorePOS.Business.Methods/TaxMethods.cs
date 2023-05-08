using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorePOS.Business.Enums;
using CorePOS.Data;

namespace CorePOS.Business.Methods;

public static class TaxMethods
{
	public static List<Tax> GetTaxList(Item item, List<Item> items)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.item = item;
		decimal num = default(decimal);
		List<Tax> list = new List<Tax>();
		foreach (TaxRuleOperation item2 in CS_0024_003C_003E8__locals0.item.TaxRule.TaxRuleOperations.Where((TaxRuleOperation a) => !a.Tax.Inactive).ToList())
		{
			if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.item_price)
			{
				if (smethod_0(item2, CS_0024_003C_003E8__locals0.item.ItemPrice) != null)
				{
					list.Add(item2.Tax);
				}
			}
			else if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.contains_prepared_food)
			{
				if (items.Where((Item i) => i.ItemTypeID == 2).ToList().Count() > 0)
				{
					num = items.Where((Item i) => i.ItemTypeID == 2 || i.ItemTypeID == 3).Sum((Item x) => x.ItemPrice * x.InventoryCount);
					if (smethod_0(item2, num) != null)
					{
						list.Add(item2.Tax);
					}
				}
			}
			else if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.not_contain_prepared_food)
			{
				if (items.Where((Item i) => i.ItemTypeID == 2).ToList().Count() == 0 && smethod_0(item2, CS_0024_003C_003E8__locals0.item.ItemPrice) != null)
				{
					list.Add(item2.Tax);
				}
			}
			else if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.all_prepared_and_snacks)
			{
				List<Item> source = items.Where((Item i) => i.ItemTypeID == 2 || i.ItemTypeID == 3).ToList();
				if (source.Count() > 0)
				{
					num = source.Sum((Item x) => x.ItemPrice * x.InventoryCount);
					if (smethod_0(item2, num) != null)
					{
						list.Add(item2.Tax);
					}
				}
			}
			else if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.item_quantity)
			{
				decimal decimal_ = items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).Sum((Item a) => a.InventoryCount);
				if (smethod_0(item2, decimal_) != null)
				{
					list.Add(item2.Tax);
				}
			}
			else if (item2.TaxRuleRequirementID.ToString().ToUpper() == TaxRequirements.subtotal_of_all_items)
			{
				decimal decimal_2 = items.Sum((Item a) => a.InventoryCount * a.ItemPrice);
				if (smethod_0(item2, decimal_2) != null)
				{
					list.Add(item2.Tax);
				}
			}
		}
		return list;
	}

	private static Tax smethod_0(TaxRuleOperation taxRuleOperation_0, decimal decimal_0)
	{
		switch (taxRuleOperation_0.Operator)
		{
		case ">":
			if (decimal_0 > taxRuleOperation_0.Condition)
			{
				return taxRuleOperation_0.Tax;
			}
			break;
		case ">=":
			if (decimal_0 >= taxRuleOperation_0.Condition)
			{
				return taxRuleOperation_0.Tax;
			}
			break;
		case "=":
			if (decimal_0 == taxRuleOperation_0.Condition)
			{
				return taxRuleOperation_0.Tax;
			}
			break;
		case "<=":
			if (decimal_0 <= taxRuleOperation_0.Condition)
			{
				return taxRuleOperation_0.Tax;
			}
			break;
		case "<":
			if (decimal_0 < taxRuleOperation_0.Condition)
			{
				return taxRuleOperation_0.Tax;
			}
			break;
		}
		return null;
	}

	public static Dictionary<Tax, decimal> getTaxDetail(decimal subtotal, List<Tax> listTax)
	{
		Dictionary<Tax, decimal> dictionary = new Dictionary<Tax, decimal>();
		decimal num = listTax.Sum((Tax x) => x.Percentage);
		Math.Round(subtotal * num, 2);
		decimal num2 = default(decimal);
		foreach (Tax item in listTax.Distinct())
		{
			decimal num3;
			decimal value = (num3 = Math.Round(subtotal * item.Percentage, 2));
			decimal num4 = Math.Round(subtotal * item.Percentage, 4);
			num2 += num4 - num3;
			if (num2 >= 0.005m)
			{
				value = num3 + 0.01m;
				num2 -= 0.005m;
			}
			dictionary.Add(item, value);
		}
		return dictionary;
	}

	public static Dictionary<string, string> getTaxRules()
	{
		DataManager dataManager = new DataManager();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (TaxRule item in from t in dataManager.DataContext.TaxRules
			where t.Active == true
			select t into x
			orderby x.RuleName
			select x)
		{
			dictionary.Add(item.TaxRuleId.ToString(), item.RuleName);
		}
		return dictionary;
	}

	public static decimal GetTaxWithRounding(List<Item> itemList)
	{
		decimal result = default(decimal);
		decimal rounding = default(decimal);
		foreach (Item item in itemList)
		{
			ItemTaxDetails itemTaxDetailsWithRounding = GetItemTaxDetailsWithRounding(itemList, item, rounding);
			result += itemTaxDetailsWithRounding.TaxValue;
			rounding = itemTaxDetailsWithRounding.Rounding;
		}
		return result;
	}

	public static ItemTaxDetails GetItemTaxDetailsWithRounding(List<Item> itemList, Item item, decimal rounding)
	{
		ItemTaxDetails itemTaxDetails = new ItemTaxDetails();
		List<Tax> taxList = GetTaxList(item, itemList.Where((Item a) => a.ItemPrice > 0m).ToList());
		decimal num = taxList.Select((Tax x) => x.Percentage).Sum();
		Dictionary<Tax, decimal> taxDetail = getTaxDetail(item.InventoryCount * item.ItemPrice, taxList);
		decimal num2 = Math.Round(item.ItemPrice * item.InventoryCount, 2, MidpointRounding.AwayFromZero);
		decimal num3 = Math.Round(num2 * num, 2);
		rounding += Math.Round(num2 * num, 4) - num3;
		bool flag = false;
		if (rounding >= 0.005m && !item.TaxesIncluded)
		{
			num3 += 0.01m;
			rounding -= 0.005m;
			flag = true;
		}
		StringBuilder stringBuilder = new StringBuilder();
		decimal num4 = default(decimal);
		decimal taxValue = default(decimal);
		foreach (Tax key in taxDetail.Keys)
		{
			num4 = taxDetail[key];
			if (flag)
			{
				num4 += 0.01m;
				flag = false;
				rounding = default(decimal);
			}
			stringBuilder.Append(key.TaxCode).Append(":").Append(num4.ToString())
				.Append("|");
			taxValue += num4;
		}
		itemTaxDetails.TaxDesc = stringBuilder.ToString();
		itemTaxDetails.TaxValue = taxValue;
		itemTaxDetails.Rounding = rounding;
		return itemTaxDetails;
	}

	public static decimal GetPreTaxPrice(List<Item> itemList, Item item)
	{
		decimal num = (from x in GetTaxList(item, itemList.Where((Item a) => a.ItemPrice > 0m).ToList())
			select x.Percentage).Sum();
		decimal num2 = Math.Round(item.ItemPrice / (1m + num) * num, 4);
		decimal num3 = item.ItemPrice - num2;
		decimal result = num3;
		if (Math.Round(num3, 2) - num3 >= 0.005m)
		{
			result = Math.Round(num3, 2) - 0.01m;
		}
		return result;
	}
}
