namespace CorePOS.Business.Enums;

public static class TaxRequirements
{
	public static string item_price;

	public static string contains_prepared_food;

	public static string not_contain_prepared_food;

	public static string all_prepared_and_snacks;

	public static string item_quantity;

	public static string subtotal_of_all_items;

	static TaxRequirements()
	{
		Class2.oOsq41PzvTVMr();
		item_price = "58ff6ce4-00e9-47b4-97ba-3fe1179464d3".ToUpper();
		contains_prepared_food = "25116f4f-8273-4b5c-a6b4-555eef41a1e0".ToUpper();
		not_contain_prepared_food = "dc08ec92-50aa-4966-84b4-fc87917765f4".ToUpper();
		all_prepared_and_snacks = "2e3a1fe0-843b-40b1-9946-de876214e1bc".ToUpper();
		item_quantity = "0c75e459-7c5b-4c5c-976f-9600ca4f99d7".ToUpper();
		subtotal_of_all_items = "107126df-8faf-425a-a233-7fc9f7fae9f6".ToUpper();
	}
}
