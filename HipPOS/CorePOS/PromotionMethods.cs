using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class PromotionMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int itemID;

		public _003C_003Ec__DisplayClass0_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromoSaleItemById_003Eb__0(Promotion a)
		{
			if (a.GetDiscountUOM == "@" && a.String_0 == itemID.ToString() && a.GetQtyString == "IT" && IsPromotionTime(a, DateTime.Now))
			{
				return !a.IsDeleted;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public DateTime OrderDateCreated;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CIsPromotionTime_003Eb__0(string a)
		{
			return a.Contains(OrderDateCreated.DayOfWeek.ToString().ToUpper());
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Item itemToAdd;

		public string orderType;

		public DateTime OrderDateCreated;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromotion_003Eb__7(Promotion a)
		{
			if ((a.String_0.Split(',').Contains(itemToAdd.ItemID.ToString()) || a.String_0 == "-1") && a.GetQtyString == "IT" && a.OrderTypes.Contains(orderType))
			{
				return IsPromotionTime(a, OrderDateCreated);
			}
			return false;
		}

		internal bool _003CGetPromotion_003Eb__8(Promotion a)
		{
			if ((a.String_0.Split(',').Contains(itemToAdd.ItemID.ToString()) || a.String_0 == "-1") && a.OrderTypes.Contains(orderType))
			{
				return IsPromotionTime(a, DateTime.Now);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public List<ItemPriceOEIndex> itemsWithQty;

		public Promotion prom;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass4_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromotion_003Eb__1(Promotion a)
		{
			if ((a.String_0.Split(',').Intersect(itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString()).ToList()).Any() || a.String_0 == "-1") && a.String_1 != null && a.GetQtyString != "IT" && a.String_1.Split(',').Contains(CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) && a.OrderTypes.Contains(CS_0024_003C_003E8__locals1.orderType))
			{
				return IsPromotionTime(a, CS_0024_003C_003E8__locals1.OrderDateCreated);
			}
			return false;
		}

		internal bool _003CGetPromotion_003Eb__2(Promotion a)
		{
			if ((a.String_0.Split(',').Intersect(itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString()).ToList()).Any() || a.String_0 == "-1") && a.String_1 != null && a.GetQtyString != "IT" && (a.String_1.Split(',').Contains(CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) || a.String_1 == "-1") && a.OrderTypes.Contains(CS_0024_003C_003E8__locals1.orderType))
			{
				return IsPromotionTime(a, DateTime.Now);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public ListViewDataItem a;

		public _003C_003Ec__DisplayClass4_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromotion_003Eb__3(Item b)
		{
			return b.ItemID.ToString() == a.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_3
	{
		public Promotion promBuy;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass4_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromotion_003Eb__9(ItemPriceOEIndex a)
		{
			if (a.PromoId == CS_0024_003C_003E8__locals2.prom.PromoId && (CS_0024_003C_003E8__locals2.prom.String_1.Split(',').Contains(a.ItemId.ToString()) || CS_0024_003C_003E8__locals2.prom.String_1 == "-1"))
			{
				return IsPromotionTime(promBuy, a.DateCreated);
			}
			return false;
		}

		internal bool _003CGetPromotion_003Eb__11(ItemPriceOEIndex a)
		{
			if (!promBuy.String_1.Split(',').Contains(a.ItemId.ToString()))
			{
				return promBuy.String_1 == "-1";
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_4
	{
		public ItemPriceOEIndex lowestPricedExistingItem;

		public _003C_003Ec__DisplayClass4_3 CS_0024_003C_003E8__locals3;

		public _003C_003Ec__DisplayClass4_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CGetPromotion_003Eb__10(Promotion a)
		{
			if ((a.String_0.Split(',').Contains(lowestPricedExistingItem.ItemId.ToString()) || a.String_0 == "-1") && a.OrderTypes.Contains(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType))
			{
				return IsPromotionTime(a, CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.OrderDateCreated);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public DateTime OrderDateCreated;

		public string orderType;

		public List<ItemPriceOEIndex> itemsWithQty;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CUpdatePromotion_003Eb__1(Promotion a)
		{
			if ((IsPromotionTime(a, OrderDateCreated) || IsPromotionTime(a, DateTime.Now)) && a.OrderTypes.Contains(orderType))
			{
				if (!a.String_0.Split(',').Intersect(itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString())).Any())
				{
					if (!string.IsNullOrEmpty(a.String_1))
					{
						return a.String_1.Split(',').Intersect(itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString())).Any();
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public ListViewDataItem a;

		public _003C_003Ec__DisplayClass5_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CUpdatePromotion_003Eb__3(Item b)
		{
			return b.ItemID.ToString() == a.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass5_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CUpdatePromotion_003Eb__7(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_3
	{
		public int highestpriceIndex;

		public List<int> buyQtyIndexes;

		public Func<ItemPriceOEIndex, bool> _003C_003E9__13;

		public _003C_003Ec__DisplayClass5_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CUpdatePromotion_003Eb__13(ItemPriceOEIndex a)
		{
			if (a.isInGetQty && a.Index != highestpriceIndex)
			{
				return !buyQtyIndexes.Contains(a.Index);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_4
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass5_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CUpdatePromotion_003Eb__15(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public string orderType;

		public DateTime OrderDateCreated;

		public CustomListViewTelerik radListItems;

		public Func<ListViewDataItem, int> _003C_003E9__8;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal int _003CRecalculatePromotion_003Eb__8(ListViewDataItem a)
		{
			return radListItems.Items.IndexOf(a);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int promotionId;

		public Promotion prom;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass6_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__2(Promotion a)
		{
			if (a.PromoId == promotionId)
			{
				return a.String_0 != "-1";
			}
			return false;
		}

		internal bool _003CRecalculatePromotion_003Eb__3(Promotion a)
		{
			if (a.PromoId == promotionId && a.String_0 == "-1" && a.OrderTypes.Contains(CS_0024_003C_003E8__locals1.orderType))
			{
				return IsPromotionTime(a, CS_0024_003C_003E8__locals1.OrderDateCreated);
			}
			return false;
		}

		internal bool _003CRecalculatePromotion_003Eb__4(ListViewDataItem a)
		{
			if (a.SubItems[18].ToString() == prom.PromoId.ToString() && !a.Font.Strikeout && a.SubItems[16].ToString() == "MainItem")
			{
				return a.SubItems[21].ToString() == "False";
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_2
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass6_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__5(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_3
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass6_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__9(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_4
	{
		public ItemPriceOEIndex indexToChange;

		public _003C_003Ec__DisplayClass6_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__12(Item a)
		{
			return a.ItemID == indexToChange.ItemId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_5
	{
		public int prevComboId;

		public Func<ListViewDataItem, bool> _003C_003E9__14;

		public Func<ListViewDataItem, bool> _003C_003E9__16;

		public _003C_003Ec__DisplayClass6_5()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__14(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == prevComboId.ToString();
		}

		internal bool _003CRecalculatePromotion_003Eb__16(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == prevComboId.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_6
	{
		public int lastComboId;

		public Func<ListViewDataItem, bool> _003C_003E9__15;

		public _003C_003Ec__DisplayClass6_6()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__15(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == lastComboId.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_7
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass6_7()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__17(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_8
	{
		public ListViewDataItem lvdi;

		public _003C_003Ec__DisplayClass6_8()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CRecalculatePromotion_003Eb__19(Item a)
		{
			return a.ItemID.ToString() == lvdi.SubItems[4].ToString();
		}
	}

	public static Promotion GetPromoSaleItemById(int itemID)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals0.itemID = itemID;
		return MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => a.GetDiscountUOM == "@" && a.String_0 == CS_0024_003C_003E8__locals0.itemID.ToString() && a.GetQtyString == "IT" && IsPromotionTime(a, DateTime.Now) && !a.IsDeleted).FirstOrDefault();
	}

	public static bool CheckDateIntersect(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
	{
		if (aStart.Date <= bEnd.Date)
		{
			return bStart.Date <= aEnd.Date;
		}
		return false;
	}

	public static bool IsPromotionTime(Promotion prom, DateTime OrderDateCreated)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.OrderDateCreated = OrderDateCreated;
		bool result = false;
		if (prom.StartDate.HasValue)
		{
			result = ((prom.StartDate.Value.Date <= CS_0024_003C_003E8__locals0.OrderDateCreated && prom.EndDate.Value.Date.AddHours(23.0).AddMinutes(59.0) >= CS_0024_003C_003E8__locals0.OrderDateCreated) ? true : false);
		}
		if (!string.IsNullOrEmpty(prom.DayTimeOfWeek))
		{
			if (prom.DayTimeOfWeek.Contains(CS_0024_003C_003E8__locals0.OrderDateCreated.DayOfWeek.ToString().ToUpper()))
			{
				string[] array = (from a in prom.DayTimeOfWeek.Split('|').ToList()
					where a.Contains(CS_0024_003C_003E8__locals0.OrderDateCreated.DayOfWeek.ToString().ToUpper())
					select a).FirstOrDefault().Split('-');
				_ = array[0];
				string s = array[1];
				string s2 = array[2];
				DateTime dateTime = DateTime.ParseExact(s, "H:mm", null, DateTimeStyles.None);
				DateTime dateTime2 = DateTime.ParseExact(s2, "H:mm", null, DateTimeStyles.None);
				result = ((dateTime.TimeOfDay <= CS_0024_003C_003E8__locals0.OrderDateCreated.TimeOfDay && dateTime2.TimeOfDay >= CS_0024_003C_003E8__locals0.OrderDateCreated.TimeOfDay) ? true : false);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	public static PromotionCheck CalculatePromotionOff(Promotion prom, decimal itemPrice)
	{
		PromotionCheck promotionCheck = new PromotionCheck
		{
			IsPromotion = false,
			NewItemPrice = itemPrice,
			PromotionId = prom.PromoId,
			promoCode = prom.PromoCode
		};
		if (prom.GetDiscountUOM == "$")
		{
			promotionCheck.IsPromotion = true;
			promotionCheck.NewItemPrice = itemPrice - prom.GetDiscountAmount.Value;
			promotionCheck.DiscountAmount = prom.GetDiscountAmount.Value;
		}
		else if (prom.GetDiscountAmount.Value > 0m && prom.GetDiscountUOM == "%")
		{
			promotionCheck.IsPromotion = true;
			promotionCheck.DiscountAmount = itemPrice * (prom.GetDiscountAmount.Value / 100m);
			promotionCheck.NewItemPrice = itemPrice - promotionCheck.DiscountAmount;
		}
		else if (prom.GetDiscountUOM == "@")
		{
			promotionCheck.IsPromotion = true;
			promotionCheck.NewItemPrice = prom.GetDiscountAmount.Value;
			promotionCheck.DiscountAmount = itemPrice - prom.GetDiscountAmount.Value;
		}
		else
		{
			promotionCheck.IsPromotion = false;
			promotionCheck.NewItemPrice = itemPrice;
		}
		return promotionCheck;
	}

	public static PromotionCheck GetPromotion(CustomListViewTelerik radListItems, Item itemToAdd, string orderType, DateTime OrderDateCreated)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.itemToAdd = itemToAdd;
		_003C_003Ec__DisplayClass4_.orderType = orderType;
		_003C_003Ec__DisplayClass4_.OrderDateCreated = OrderDateCreated;
		IEnumerable<ListViewDataItem> enumerable = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[18].ToString() != "-1" && !a.Font.Strikeout && a.SubItems[21].ToString() == "False");
		PromotionCheck promotionCheck = new PromotionCheck
		{
			IsPromotion = false,
			NewItemPrice = 0m,
			promoCode = "",
			PromotionId = 0
		};
		if (_003C_003Ec__DisplayClass4_.itemToAdd != null && _003C_003Ec__DisplayClass4_.itemToAdd.ItemID > 0)
		{
			promotionCheck.NewItemPrice = GetTaxIncludedItemPrice(_003C_003Ec__DisplayClass4_.itemToAdd);
			if (MemoryLoadedObjects.all_active_promotions.Count > 0)
			{
				_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_1();
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
				CS_0024_003C_003E8__locals2.itemsWithQty = new List<ItemPriceOEIndex>();
				using (IEnumerator<ListViewDataItem> enumerator = enumerable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass4_2();
						CS_0024_003C_003E8__locals3.a = enumerator.Current;
						if (!(CS_0024_003C_003E8__locals3.a.SubItems[16].ToString() == "MainItem"))
						{
							continue;
						}
						Item item = MemoryLoadedData.all_active_items.Where((Item b) => b.ItemID.ToString() == CS_0024_003C_003E8__locals3.a.SubItems[4].ToString()).FirstOrDefault();
						if (item == null && CS_0024_003C_003E8__locals3.a.SubItems[4].ToString() != "-999")
						{
							item = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals3.a.SubItems[4].ToString()).FirstOrDefault();
						}
						if (item != null && Convert.ToInt32(CS_0024_003C_003E8__locals3.a.SubItems[18].ToString()) != -1)
						{
							CS_0024_003C_003E8__locals2.itemsWithQty.Add(new ItemPriceOEIndex
							{
								Qty = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals3.a[0].ToString()),
								ItemId = Convert.ToInt32(CS_0024_003C_003E8__locals3.a.SubItems[4].ToString()),
								ItemPrice = ((CS_0024_003C_003E8__locals3.a.SubItems[8].ToString() == "-1") ? item.ItemPrice : Convert.ToDecimal(CS_0024_003C_003E8__locals3.a.SubItems[8].ToString())),
								Index = radListItems.Items.IndexOf(CS_0024_003C_003E8__locals3.a),
								PromoId = Convert.ToInt32(CS_0024_003C_003E8__locals3.a.SubItems[18].ToString()),
								DateCreated = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.a.SubItems[19].ToString())) ? Convert.ToDateTime(CS_0024_003C_003E8__locals3.a.SubItems[19].ToString()) : DateTime.Now)
							});
						}
					}
				}
				CS_0024_003C_003E8__locals2.prom = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => (a.String_0.Split(',').Intersect(CS_0024_003C_003E8__locals2.itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString()).ToList()).Any() || a.String_0 == "-1") && a.String_1 != null && a.GetQtyString != "IT" && a.String_1.Split(',').Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) && a.OrderTypes.Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.OrderDateCreated)).FirstOrDefault();
				if (CS_0024_003C_003E8__locals2.prom == null)
				{
					CS_0024_003C_003E8__locals2.prom = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => (a.String_0.Split(',').Intersect(CS_0024_003C_003E8__locals2.itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString()).ToList()).Any() || a.String_0 == "-1") && a.String_1 != null && a.GetQtyString != "IT" && (a.String_1.Split(',').Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) || a.String_1 == "-1") && a.OrderTypes.Contains(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, DateTime.Now)).FirstOrDefault();
				}
				bool flag = false;
				if (CS_0024_003C_003E8__locals2.prom != null)
				{
					decimal num = default(decimal);
					decimal num2 = default(decimal);
					decimal num3 = default(decimal);
					decimal num4 = default(decimal);
					decimal num5 = Convert.ToDecimal(CS_0024_003C_003E8__locals2.prom.GetQtyString);
					decimal? buyQty;
					foreach (ListViewDataItem item2 in enumerable)
					{
						DateTime orderDateCreated = ((!string.IsNullOrEmpty(item2.SubItems[19].ToString())) ? Convert.ToDateTime(item2.SubItems[19].ToString()) : DateTime.Now);
						if (!(item2.SubItems[16].ToString() == "MainItem") || !IsPromotionTime(CS_0024_003C_003E8__locals2.prom, orderDateCreated))
						{
							continue;
						}
						decimal num6 = ((item2[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(item2[0].ToString()));
						bool flag2 = CS_0024_003C_003E8__locals2.prom.String_0 == "-1" || CS_0024_003C_003E8__locals2.prom.String_0.Split(',').Contains(item2.SubItems[4].ToString());
						bool flag3 = CS_0024_003C_003E8__locals2.prom.String_1 == "-1" || CS_0024_003C_003E8__locals2.prom.String_1.Split(',').Contains(item2.SubItems[4].ToString());
						if (item2.SubItems[18].ToString() == "0")
						{
							item2.SubItems[18] = CS_0024_003C_003E8__locals2.prom.PromoId.ToString();
						}
						for (int i = 0; (decimal)i < num6; i++)
						{
							if (flag2 && flag3)
							{
								decimal num7 = num2;
								buyQty = CS_0024_003C_003E8__locals2.prom.BuyQty;
								if ((num7 < buyQty.GetValueOrDefault()) & buyQty.HasValue)
								{
									goto IL_0610;
								}
							}
							if (!flag2 || flag3)
							{
								if (!(CS_0024_003C_003E8__locals2.prom.String_1 != null && flag3))
								{
									continue;
								}
								decimal num8 = num2;
								buyQty = CS_0024_003C_003E8__locals2.prom.BuyQty;
								if (((num8 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num4 < num5)
								{
									num3 += 1m;
									num4 += 1m;
									decimal num9 = num2;
									buyQty = CS_0024_003C_003E8__locals2.prom.BuyQty;
									if (((num9 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num4 >= num5)
									{
										num4 -= num5;
										num2 -= CS_0024_003C_003E8__locals2.prom.BuyQty.Value;
									}
								}
								continue;
							}
							goto IL_0610;
							IL_0610:
							num += 1m;
							num2 += 1m;
						}
					}
					decimal num10 = num2;
					buyQty = CS_0024_003C_003E8__locals2.prom.BuyQty;
					if (((num10 < buyQty.GetValueOrDefault()) & buyQty.HasValue) && num4 < num5)
					{
						flag = true;
					}
				}
				if (CS_0024_003C_003E8__locals2.prom == null || flag)
				{
					_003C_003Ec__DisplayClass4_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_3();
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals2;
					CS_0024_003C_003E8__locals0.promBuy = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => (a.String_0.Split(',').Contains(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) || a.String_0 == "-1") && a.GetQtyString == "IT" && a.OrderTypes.Contains(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.OrderDateCreated)).FirstOrDefault();
					if (CS_0024_003C_003E8__locals0.promBuy == null)
					{
						CS_0024_003C_003E8__locals0.promBuy = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => (a.String_0.Split(',').Contains(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemToAdd.ItemID.ToString()) || a.String_0 == "-1") && a.OrderTypes.Contains(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, DateTime.Now)).FirstOrDefault();
					}
					if (CS_0024_003C_003E8__locals0.promBuy != null)
					{
						if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.prom != null && flag)
						{
							_003C_003Ec__DisplayClass4_4 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_4();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lowestPricedExistingItem = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.itemsWithQty.Where((ItemPriceOEIndex a) => a.PromoId == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.prom.PromoId && (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.prom.String_1.Split(',').Contains(a.ItemId.ToString()) || CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.prom.String_1 == "-1") && IsPromotionTime(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.promBuy, a.DateCreated)).FirstOrDefault();
							if (CS_0024_003C_003E8__locals1.lowestPricedExistingItem != null)
							{
								if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.itemToAdd.ItemPrice >= CS_0024_003C_003E8__locals1.lowestPricedExistingItem.ItemPrice)
								{
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.prom = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.promBuy;
								}
								else
								{
									Promotion promotion = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => (a.String_0.Split(',').Contains(CS_0024_003C_003E8__locals1.lowestPricedExistingItem.ItemId.ToString()) || a.String_0 == "-1") && a.OrderTypes.Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.OrderDateCreated)).FirstOrDefault();
									if (promotion != null)
									{
										radListItems.Items[CS_0024_003C_003E8__locals1.lowestPricedExistingItem.Index].SubItems[18] = promotion.PromoId;
									}
								}
							}
						}
						else
						{
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.prom = CS_0024_003C_003E8__locals0.promBuy;
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.promBuy.String_1) && CS_0024_003C_003E8__locals0.promBuy.String_1 != "IT")
							{
								ItemPriceOEIndex itemPriceOEIndex = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.itemsWithQty.Where((ItemPriceOEIndex a) => CS_0024_003C_003E8__locals0.promBuy.String_1.Split(',').Contains(a.ItemId.ToString()) || CS_0024_003C_003E8__locals0.promBuy.String_1 == "-1").FirstOrDefault();
								if (itemPriceOEIndex != null)
								{
									radListItems.Items[itemPriceOEIndex.Index].SubItems[18] = CS_0024_003C_003E8__locals0.promBuy.PromoId;
								}
							}
						}
					}
				}
				if (CS_0024_003C_003E8__locals2.prom != null)
				{
					promotionCheck.IsPromotion = true;
					promotionCheck.PromotionId = CS_0024_003C_003E8__locals2.prom.PromoId;
					promotionCheck.promoCode = CS_0024_003C_003E8__locals2.prom.PromoCode;
				}
			}
			return promotionCheck;
		}
		return promotionCheck;
	}

	public static void UpdatePromotion(CustomListViewTelerik radListItems, string orderType, DateTime OrderDateCreated)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.OrderDateCreated = OrderDateCreated;
		CS_0024_003C_003E8__locals0.orderType = orderType;
		IEnumerable<ListViewDataItem> enumerable = radListItems.Items.Where((ListViewDataItem a) => a.SubItems[18].ToString() != "-1" && !a.Font.Strikeout && a.SubItems[21].ToString() == "False");
		CS_0024_003C_003E8__locals0.itemsWithQty = new List<ItemPriceOEIndex>();
		using (IEnumerator<ListViewDataItem> enumerator = enumerable.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass5_1();
				CS_0024_003C_003E8__locals2.a = enumerator.Current;
				if (!(CS_0024_003C_003E8__locals2.a.SubItems[16].ToString() == "MainItem"))
				{
					continue;
				}
				Item item = MemoryLoadedData.all_active_items.Where((Item b) => b.ItemID.ToString() == CS_0024_003C_003E8__locals2.a.SubItems[4].ToString()).FirstOrDefault();
				if (item == null && CS_0024_003C_003E8__locals2.a.SubItems[4].ToString() != "-999")
				{
					item = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals2.a.SubItems[4].ToString()).FirstOrDefault();
				}
				if (item != null)
				{
					decimal currentPrice = Convert.ToDecimal(CS_0024_003C_003E8__locals2.a[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals2.a.SubItems[15].ToString(), DiscountTypes.Promo);
					decimal itemPrice = GetCurrentPrice(item, currentPrice);
					if (CS_0024_003C_003E8__locals2.a.SubItems[8].ToString() != "-1")
					{
						itemPrice = Convert.ToDecimal(CS_0024_003C_003E8__locals2.a.SubItems[8].ToString());
					}
					CS_0024_003C_003E8__locals0.itemsWithQty.Add(new ItemPriceOEIndex
					{
						Qty = MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals2.a[0].ToString()),
						ItemId = Convert.ToInt32(CS_0024_003C_003E8__locals2.a.SubItems[4].ToString()),
						ItemPrice = itemPrice,
						Index = radListItems.Items.IndexOf(CS_0024_003C_003E8__locals2.a)
					});
				}
			}
		}
		foreach (Promotion item4 in (from a in MemoryLoadedObjects.all_active_promotions
			where (IsPromotionTime(a, CS_0024_003C_003E8__locals0.OrderDateCreated) || IsPromotionTime(a, DateTime.Now)) && a.OrderTypes.Contains(CS_0024_003C_003E8__locals0.orderType) && (a.String_0.Split(',').Intersect(CS_0024_003C_003E8__locals0.itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString())).Any() || (!string.IsNullOrEmpty(a.String_1) && a.String_1.Split(',').Intersect(CS_0024_003C_003E8__locals0.itemsWithQty.Select((ItemPriceOEIndex b) => b.ItemId.ToString())).Any()))
			select a into x
			orderby x.GetQtyString
			select x).ToList())
		{
			if (item4.GetQtyString != "IT")
			{
				decimal num = Convert.ToInt32(item4.GetQtyString);
				decimal num2 = default(decimal);
				decimal num3 = default(decimal);
				decimal num4 = default(decimal);
				decimal num5 = default(decimal);
				List<ItemPriceOEIndex> list = new List<ItemPriceOEIndex>();
				using (IEnumerator<ListViewDataItem> enumerator = enumerable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass5_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_2();
						CS_0024_003C_003E8__locals1.lvdi = enumerator.Current;
						DateTime orderDateCreated = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.lvdi.SubItems[19].ToString())) ? Convert.ToDateTime(CS_0024_003C_003E8__locals1.lvdi.SubItems[19].ToString()) : DateTime.Now);
						if (!(CS_0024_003C_003E8__locals1.lvdi.SubItems[16].ToString() == "MainItem") || !IsPromotionTime(item4, orderDateCreated))
						{
							continue;
						}
						decimal qty = ((CS_0024_003C_003E8__locals1.lvdi[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.lvdi[0].ToString()));
						bool flag = item4.String_0.Split(',').Contains(CS_0024_003C_003E8__locals1.lvdi.SubItems[4].ToString());
						bool flag2 = item4.String_1.Split(',').Contains(CS_0024_003C_003E8__locals1.lvdi.SubItems[4].ToString());
						Item item2 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals1.lvdi.SubItems[4].ToString()).FirstOrDefault();
						if (item2 == null && CS_0024_003C_003E8__locals1.lvdi.SubItems[4].ToString() != "-999")
						{
							item2 = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals1.lvdi.SubItems[4].ToString()).FirstOrDefault();
						}
						if (item2 == null || !(flag || flag2))
						{
							continue;
						}
						if (CS_0024_003C_003E8__locals1.lvdi.SubItems[18].ToString() == "0")
						{
							CS_0024_003C_003E8__locals1.lvdi.SubItems[18] = item4.PromoId.ToString();
						}
						if (!(CS_0024_003C_003E8__locals1.lvdi.SubItems[18].ToString() == "-1"))
						{
							decimal currentPrice2 = Convert.ToDecimal(CS_0024_003C_003E8__locals1.lvdi[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.lvdi.SubItems[15].ToString(), DiscountTypes.Promo);
							decimal itemPrice2 = GetCurrentPrice(item2, currentPrice2);
							if (CS_0024_003C_003E8__locals1.lvdi.SubItems[8].ToString() != "-1")
							{
								itemPrice2 = Convert.ToDecimal(CS_0024_003C_003E8__locals1.lvdi.SubItems[8].ToString());
							}
							PromotionCheck promotionCheck = CalculatePromotionOff(item4, itemPrice2);
							list.Add(new ItemPriceOEIndex
							{
								Qty = qty,
								ItemId = item2.ItemID,
								ItemName = item2.ItemName,
								ItemPrice = itemPrice2,
								DiscountedPrice = promotionCheck.NewItemPrice,
								isInBuyQty = flag,
								isInGetQty = flag2,
								Index = radListItems.Items.IndexOf(CS_0024_003C_003E8__locals1.lvdi),
								DiscountAmount = promotionCheck.DiscountAmount,
								PromoId = Convert.ToInt32(CS_0024_003C_003E8__locals1.lvdi.SubItems[18].ToString()),
								sortOrder = ((!flag && flag2) ? 1 : 0)
							});
						}
					}
				}
				decimal num6 = default(decimal);
				decimal num7 = default(decimal);
				decimal? buyQty;
				foreach (ItemPriceOEIndex item5 in list.OrderBy((ItemPriceOEIndex a) => a.sortOrder))
				{
					for (int i = 0; (decimal)i < item5.Qty; i++)
					{
						if (item5.isInBuyQty && item5.isInGetQty)
						{
							decimal num8 = num5;
							buyQty = item4.BuyQty;
							if ((num8 < buyQty.GetValueOrDefault()) & buyQty.HasValue)
							{
								goto IL_0877;
							}
						}
						if (!item5.isInBuyQty || item5.isInGetQty)
						{
							if (item4.String_1 == null || !item5.isInGetQty)
							{
								continue;
							}
							decimal num9 = num5;
							buyQty = item4.BuyQty;
							if (((num9 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num4 < num)
							{
								num2 += ((item5.Qty < 1m) ? item5.Qty : 1m);
								num4 += ((item5.Qty < 1m) ? item5.Qty : 1m);
								decimal num10 = num5;
								buyQty = item4.BuyQty;
								if (((num10 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num4 >= num)
								{
									num7 += item4.BuyQty.Value;
									num6 += num;
									num4 -= num;
									num5 -= item4.BuyQty.Value;
								}
							}
							continue;
						}
						goto IL_0877;
						IL_0877:
						num3 += ((item5.Qty < 1m) ? item5.Qty : 1m);
						num5 += ((item5.Qty < 1m) ? item5.Qty : 1m);
					}
				}
				decimal num11 = num3;
				buyQty = item4.BuyQty;
				if (!((num11 >= buyQty.GetValueOrDefault()) & buyQty.HasValue))
				{
					continue;
				}
				_003C_003Ec__DisplayClass5_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass5_3();
				foreach (ItemPriceOEIndex item6 in list)
				{
					radListItems.Items[item6.Index].SubItems[18] = "0";
					decimal num12 = ((radListItems.Items[item6.Index][0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(radListItems.Items[item6.Index][0].ToString()));
					radListItems.Items[item6.Index][2] = item6.ItemPrice.ToString("0.00");
					radListItems.Items[item6.Index][3] = (num12 * item6.ItemPrice).ToString("0.00");
					radListItems.Items[item6.Index].SubItems[13] = "";
					radListItems.Items[item6.Index].SubItems[15] = UpdateDiscountFromDiscountDescription(radListItems.Items[item6.Index].SubItems[15].ToString(), DiscountTypes.Promo, 0m);
				}
				CS_0024_003C_003E8__locals3.highestpriceIndex = 0;
				CS_0024_003C_003E8__locals3.buyQtyIndexes = new List<int>();
				foreach (ItemPriceOEIndex item7 in from a in list
					where a.isInBuyQty
					orderby a.ItemPrice descending
					select a)
				{
					if (num7 > 0m)
					{
						radListItems.Items[item7.Index].SubItems[18] = item4.PromoId;
						CS_0024_003C_003E8__locals3.highestpriceIndex = item7.Index;
						CS_0024_003C_003E8__locals3.buyQtyIndexes.Add(item7.Index);
						num7 -= item7.Qty;
					}
				}
				foreach (ItemPriceOEIndex item8 in from a in list
					where a.isInGetQty && a.Index != CS_0024_003C_003E8__locals3.highestpriceIndex && !CS_0024_003C_003E8__locals3.buyQtyIndexes.Contains(a.Index)
					orderby a.ItemPrice
					select a)
				{
					if (num6 > 0m)
					{
						radListItems.Items[item8.Index].SubItems[18] = item4.PromoId;
						num6 -= item8.Qty;
					}
				}
				enumerable = radListItems.Items.Where((ListViewDataItem a) => !a.Font.Strikeout);
			}
			else
			{
				if (!(item4.GetQtyString == "IT"))
				{
					continue;
				}
				using IEnumerator<ListViewDataItem> enumerator = enumerable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass5_4 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass5_4();
					CS_0024_003C_003E8__locals4.lvdi = enumerator.Current;
					DateTime orderDateCreated2 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals4.lvdi.SubItems[19].ToString())) ? Convert.ToDateTime(CS_0024_003C_003E8__locals4.lvdi.SubItems[19].ToString()) : DateTime.Now);
					if (!(CS_0024_003C_003E8__locals4.lvdi.SubItems[16].ToString() == "MainItem") || !IsPromotionTime(item4, orderDateCreated2))
					{
						continue;
					}
					if (!(CS_0024_003C_003E8__locals4.lvdi[0].ToString() == ""))
					{
						MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals4.lvdi[0].ToString());
					}
					if (!item4.String_0.Split(',').Contains(CS_0024_003C_003E8__locals4.lvdi.SubItems[4].ToString()))
					{
						continue;
					}
					Item item3 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals4.lvdi.SubItems[4].ToString()).FirstOrDefault();
					if (item3 == null && CS_0024_003C_003E8__locals4.lvdi.SubItems[4].ToString() != "-999")
					{
						item3 = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals4.lvdi.SubItems[4].ToString()).FirstOrDefault();
					}
					if (item3 != null && CS_0024_003C_003E8__locals4.lvdi.SubItems[18].ToString() == "0")
					{
						CS_0024_003C_003E8__locals4.lvdi.SubItems[18] = item4.PromoId.ToString();
					}
				}
			}
		}
	}

	public static void RecalculatePromotion(CustomListViewTelerik radListItems, string orderType, DateTime OrderDateCreated, ref short OeComboId)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.orderType = orderType;
		_003C_003Ec__DisplayClass6_.OrderDateCreated = OrderDateCreated;
		_003C_003Ec__DisplayClass6_.radListItems = radListItems;
		UpdatePromotion(_003C_003Ec__DisplayClass6_.radListItems, _003C_003Ec__DisplayClass6_.orderType, _003C_003Ec__DisplayClass6_.OrderDateCreated);
		List<int> list = (from a in _003C_003Ec__DisplayClass6_.radListItems.Items
			where a.SubItems[18].ToString() != "" && a.SubItems[18].ToString() != "0" && a.SubItems[18].ToString() != "-1" && !a.Font.Strikeout && a.SubItems[21].ToString() == "False"
			select Convert.ToInt32(a.SubItems[18].ToString())).Distinct().ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (int item6 in list)
		{
			_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass6_;
			CS_0024_003C_003E8__locals1.promotionId = item6;
			CS_0024_003C_003E8__locals1.prom = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => a.PromoId == CS_0024_003C_003E8__locals1.promotionId && a.String_0 != "-1").FirstOrDefault();
			if (CS_0024_003C_003E8__locals1.prom == null)
			{
				CS_0024_003C_003E8__locals1.prom = MemoryLoadedObjects.all_active_promotions.Where((Promotion a) => a.PromoId == CS_0024_003C_003E8__locals1.promotionId && a.String_0 == "-1" && a.OrderTypes.Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderType) && IsPromotionTime(a, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.OrderDateCreated)).FirstOrDefault();
			}
			if (CS_0024_003C_003E8__locals1.prom == null)
			{
				continue;
			}
			IEnumerable<ListViewDataItem> enumerable = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Where((ListViewDataItem a) => a.SubItems[18].ToString() == CS_0024_003C_003E8__locals1.prom.PromoId.ToString() && !a.Font.Strikeout && a.SubItems[16].ToString() == "MainItem" && a.SubItems[21].ToString() == "False");
			if (!CS_0024_003C_003E8__locals1.prom.OrderTypes.Contains(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderType))
			{
				using IEnumerator<ListViewDataItem> enumerator2 = enumerable.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass6_2 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_2();
					CS_0024_003C_003E8__locals6.lvdi = enumerator2.Current;
					DateTime orderDateCreated = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals6.lvdi.SubItems[19].ToString())) ? Convert.ToDateTime(CS_0024_003C_003E8__locals6.lvdi.SubItems[19].ToString()) : DateTime.Now);
					if (IsPromotionTime(CS_0024_003C_003E8__locals1.prom, orderDateCreated))
					{
						continue;
					}
					Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals6.lvdi.SubItems[4].ToString()).FirstOrDefault();
					if (item == null && CS_0024_003C_003E8__locals6.lvdi.SubItems[4].ToString() != "-999")
					{
						item = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals6.lvdi.SubItems[4].ToString()).FirstOrDefault();
					}
					if (item != null)
					{
						decimal currentPrice = Convert.ToDecimal(CS_0024_003C_003E8__locals6.lvdi[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals6.lvdi.SubItems[15].ToString(), DiscountTypes.Promo);
						decimal num = GetCurrentPrice(item, currentPrice);
						if (CS_0024_003C_003E8__locals6.lvdi.SubItems[8].ToString() != "-1")
						{
							num = Convert.ToDecimal(CS_0024_003C_003E8__locals6.lvdi.SubItems[8].ToString());
						}
						decimal num2 = ((CS_0024_003C_003E8__locals6.lvdi[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals6.lvdi[0].ToString()));
						CS_0024_003C_003E8__locals6.lvdi[2] = num.ToString("0.00", Thread.CurrentThread.CurrentCulture);
						CS_0024_003C_003E8__locals6.lvdi[3] = (num2 * num).ToString("0.00", Thread.CurrentThread.CurrentCulture);
						CS_0024_003C_003E8__locals6.lvdi.SubItems[13] = "";
						CS_0024_003C_003E8__locals6.lvdi.SubItems[18] = "0";
					}
				}
			}
			else if (CS_0024_003C_003E8__locals1.prom.GetQtyString != "IT")
			{
				decimal num3 = Convert.ToInt32(CS_0024_003C_003E8__locals1.prom.GetQtyString);
				decimal num4 = default(decimal);
				decimal num5 = default(decimal);
				decimal num6 = default(decimal);
				decimal num7 = default(decimal);
				List<ItemPriceOEIndex> list2 = new List<ItemPriceOEIndex>();
				foreach (ListViewDataItem item7 in enumerable)
				{
					decimal qty = ((item7[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(item7[0].ToString()));
					bool flag = CS_0024_003C_003E8__locals1.prom.String_0 == "-1" || CS_0024_003C_003E8__locals1.prom.String_0.Split(',').Contains(item7.SubItems[4].ToString());
					bool flag2 = CS_0024_003C_003E8__locals1.prom.String_1 == "-1" || CS_0024_003C_003E8__locals1.prom.String_1.Split(',').Contains(item7.SubItems[4].ToString());
					list2.Add(new ItemPriceOEIndex
					{
						Qty = qty,
						ItemId = Convert.ToInt32(item7.SubItems[4].ToString()),
						isInBuyQty = flag,
						isInGetQty = flag2,
						sortOrder = ((!flag && flag2) ? 1 : 0)
					});
				}
				int num8 = 0;
				decimal num9 = default(decimal);
				decimal? buyQty;
				foreach (ItemPriceOEIndex item8 in list2.OrderBy((ItemPriceOEIndex a) => a.sortOrder))
				{
					for (int i = 0; (decimal)i < item8.Qty; i++)
					{
						num9 += item8.Qty;
						if (item8.Qty < 1m && num9 < 1m)
						{
							continue;
						}
						num9 = default(decimal);
						if (item8.isInBuyQty && item8.isInGetQty)
						{
							decimal num10 = num7;
							buyQty = CS_0024_003C_003E8__locals1.prom.BuyQty;
							if ((num10 < buyQty.GetValueOrDefault()) & buyQty.HasValue)
							{
								goto IL_071e;
							}
						}
						if (!item8.isInBuyQty || item8.isInGetQty)
						{
							if (CS_0024_003C_003E8__locals1.prom.String_1 == null || !item8.isInGetQty)
							{
								continue;
							}
							decimal num11 = num7;
							buyQty = CS_0024_003C_003E8__locals1.prom.BuyQty;
							if (((num11 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num6 < num3)
							{
								num4 += ((item8.Qty < 1m) ? item8.Qty : 1m);
								num6 += ((item8.Qty < 1m) ? item8.Qty : 1m);
								decimal num12 = num7;
								buyQty = CS_0024_003C_003E8__locals1.prom.BuyQty;
								if (((num12 >= buyQty.GetValueOrDefault()) & buyQty.HasValue) && num6 >= num3)
								{
									num8 += (int)num3;
									num6 -= num3;
									num7 -= CS_0024_003C_003E8__locals1.prom.BuyQty.Value;
								}
							}
							continue;
						}
						goto IL_071e;
						IL_071e:
						num5 += ((item8.Qty < 1m) ? item8.Qty : 1m);
						num7 += ((item8.Qty < 1m) ? item8.Qty : 1m);
					}
				}
				decimal num13 = num5;
				buyQty = CS_0024_003C_003E8__locals1.prom.BuyQty;
				if ((num13 >= buyQty.GetValueOrDefault()) & buyQty.HasValue)
				{
					List<ItemPriceOEIndex> list3 = new List<ItemPriceOEIndex>();
					using (IEnumerator<ListViewDataItem> enumerator2 = enumerable.OrderByDescending((ListViewDataItem a) => CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.IndexOf(a)).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass6_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_3();
							CS_0024_003C_003E8__locals0.lvdi = enumerator2.Current;
							Item item2 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals0.lvdi.SubItems[4].ToString()).FirstOrDefault();
							if (item2 == null && CS_0024_003C_003E8__locals0.lvdi.SubItems[4].ToString() != "-999")
							{
								item2 = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals0.lvdi.SubItems[4].ToString()).FirstOrDefault();
							}
							if (item2 != null)
							{
								decimal currentPrice2 = Convert.ToDecimal(CS_0024_003C_003E8__locals0.lvdi[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals0.lvdi.SubItems[15].ToString(), DiscountTypes.Promo);
								decimal num14 = GetCurrentPrice(item2, currentPrice2);
								if (CS_0024_003C_003E8__locals0.lvdi.SubItems[8].ToString() != "-1")
								{
									num14 = Convert.ToDecimal(CS_0024_003C_003E8__locals0.lvdi.SubItems[8].ToString());
								}
								decimal num15 = ((CS_0024_003C_003E8__locals0.lvdi[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals0.lvdi[0].ToString()));
								CS_0024_003C_003E8__locals0.lvdi[2] = num14.ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals0.lvdi[3] = (num15 * num14).ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals0.lvdi.SubItems[13] = "";
								CS_0024_003C_003E8__locals0.lvdi.SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals0.lvdi.SubItems[15].ToString(), DiscountTypes.Promo, 0m);
								if (CS_0024_003C_003E8__locals1.prom.String_1 != null && (CS_0024_003C_003E8__locals1.prom.String_1.Split(',').Contains(item2.ItemID.ToString()) || CS_0024_003C_003E8__locals1.prom.String_1 == "-1"))
								{
									PromotionCheck promotionCheck = CalculatePromotionOff(CS_0024_003C_003E8__locals1.prom, num14);
									list3.Add(new ItemPriceOEIndex
									{
										ItemName = item2.ItemName,
										ItemId = item2.ItemID,
										ItemPrice = num14,
										DiscountedPrice = promotionCheck.NewItemPrice,
										Index = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.IndexOf(CS_0024_003C_003E8__locals0.lvdi),
										DiscountAmount = promotionCheck.DiscountAmount,
										Qty = num15
									});
								}
							}
						}
					}
					if (!(num4 >= num3))
					{
						continue;
					}
					bool flag3 = false;
					using (List<ItemPriceOEIndex>.Enumerator enumerator4 = list3.OrderBy((ItemPriceOEIndex a) => a.ItemPrice).ToList().GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							_003C_003Ec__DisplayClass6_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass6_4();
							CS_0024_003C_003E8__locals2.indexToChange = enumerator4.Current;
							if ((num8 <= 0 && (num8 - (int)CS_0024_003C_003E8__locals2.indexToChange.Qty >= 0 || !(CS_0024_003C_003E8__locals2.indexToChange.Qty > 1m))) || !(CS_0024_003C_003E8__locals2.indexToChange.Qty >= 1m))
							{
								continue;
							}
							if (CS_0024_003C_003E8__locals2.indexToChange.Qty > 1m && num8 - (int)CS_0024_003C_003E8__locals2.indexToChange.Qty < 0)
							{
								Item item3 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals2.indexToChange.ItemId).FirstOrDefault();
								if (item3 == null && CS_0024_003C_003E8__locals2.indexToChange.ItemId != -999)
								{
									item3 = new GClass6().Items.Where((Item x) => x.ItemID == CS_0024_003C_003E8__locals2.indexToChange.ItemId).FirstOrDefault();
								}
								if (item3 == null)
								{
									continue;
								}
								_003C_003Ec__DisplayClass6_5 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass6_5();
								if (num8 == 0)
								{
									num8 = 1;
								}
								decimal num16 = ((CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][0].ToString()));
								int index = CS_0024_003C_003E8__locals2.indexToChange.Index;
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][0] = 1.ToString("0.##");
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][2] = CS_0024_003C_003E8__locals2.indexToChange.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][3] = (CS_0024_003C_003E8__locals2.indexToChange.ItemPrice * 1m).ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[13] = "";
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[15].ToString(), DiscountTypes.Promo, 0m);
								CS_0024_003C_003E8__locals3.prevComboId = Convert.ToInt32(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[5].ToString());
								decimal num17 = Math.Abs(num8 - (int)CS_0024_003C_003E8__locals2.indexToChange.Qty);
								for (int j = 0; (decimal)j < num17; j++)
								{
									int num18 = 0;
									if (CS_0024_003C_003E8__locals3.prevComboId > 0)
									{
										OeComboId++;
										num18 = OeComboId;
									}
									PromotionCheck promotion = GetPromotion(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems, item3, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderType, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.OrderDateCreated);
									string[] values = new string[22]
									{
										1.ToString("0.##"),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][1].ToString(),
										CS_0024_003C_003E8__locals2.indexToChange.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture),
										(CS_0024_003C_003E8__locals2.indexToChange.ItemPrice * 1m).ToString("0.00", Thread.CurrentThread.CurrentCulture),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[4].ToString(),
										num18.ToString(),
										string.Empty,
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[7].ToString(),
										CS_0024_003C_003E8__locals2.indexToChange.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[9].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[10].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[11].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[12].ToString(),
										"",
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[14].ToString(),
										"",
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[16].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[17].ToString(),
										promotion.PromotionId.ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[19].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[20].ToString(),
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[21].ToString()
									};
									ListViewDataItem listViewDataItem = new ListViewDataItem("", values);
									listViewDataItem.Group = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].Group;
									listViewDataItem.Font = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].Font;
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Add(listViewDataItem);
									index = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.IndexOf(listViewDataItem);
									if (CS_0024_003C_003E8__locals3.prevComboId <= 0)
									{
										continue;
									}
									List<ComboQty> list4 = new List<ComboQty>();
									foreach (ListViewDataItem item9 in CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals3.prevComboId.ToString()))
									{
										if (item9 != CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index])
										{
											decimal qty2 = ((item9[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(item9[0].ToString())) / num16;
											list4.Add(new ComboQty
											{
												ComboIndex = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.IndexOf(item9),
												Qty = qty2,
												Font = item9.Font,
												ForeColor = item9.ForeColor
											});
										}
									}
									if (list4.Count <= 0)
									{
										continue;
									}
									foreach (ComboQty item10 in list4)
									{
										ListViewDataItem listViewDataItem2 = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item10.ComboIndex];
										string[] values2 = new string[23]
										{
											item10.Qty.ToString("0.##"),
											listViewDataItem2[1].ToString(),
											listViewDataItem2[2].ToString(),
											(listViewDataItem2[2].ToString() == "") ? "" : (Convert.ToDecimal(listViewDataItem2[2].ToString()) * item10.Qty).ToString("0.00", Thread.CurrentThread.CurrentCulture),
											listViewDataItem2.SubItems[4].ToString(),
											num18.ToString(),
											string.Empty,
											listViewDataItem2.SubItems[7].ToString(),
											listViewDataItem2.SubItems[8].ToString(),
											listViewDataItem2.SubItems[9].ToString(),
											listViewDataItem2.SubItems[10].ToString(),
											listViewDataItem2.SubItems[11].ToString(),
											listViewDataItem2.SubItems[12].ToString(),
											"",
											listViewDataItem2.SubItems[14].ToString(),
											"",
											listViewDataItem2.SubItems[16].ToString(),
											listViewDataItem2.SubItems[17].ToString(),
											listViewDataItem2.SubItems[18].ToString(),
											listViewDataItem2.SubItems[19].ToString(),
											listViewDataItem2.SubItems[20].ToString(),
											listViewDataItem2.SubItems[21].ToString(),
											listViewDataItem2.SubItems[22].ToString()
										};
										ListViewDataItem listViewDataItem3 = new ListViewDataItem("", values2);
										listViewDataItem3.Group = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].Group;
										listViewDataItem3.Font = item10.Font;
										listViewDataItem3.ForeColor = item10.ForeColor;
										CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Add(listViewDataItem3);
									}
								}
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index][0] = num8.ToString("0.##");
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index][2] = CS_0024_003C_003E8__locals2.indexToChange.DiscountedPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index][3] = (CS_0024_003C_003E8__locals2.indexToChange.DiscountedPrice * (decimal)num8).ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index].SubItems[13] = CS_0024_003C_003E8__locals1.prom.PromoCode;
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index].SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index].SubItems[15].ToString(), DiscountTypes.Promo, CS_0024_003C_003E8__locals2.indexToChange.DiscountAmount);
								if (OeComboId > 0)
								{
									_003C_003Ec__DisplayClass6_6 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_6();
									CS_0024_003C_003E8__locals4.lastComboId = OeComboId;
									foreach (ListViewDataItem item11 in CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals4.lastComboId.ToString()))
									{
										if (item11 != CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[index])
										{
											decimal num19 = ((item11[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(item11[0].ToString())) * (decimal)num8;
											item11[0] = num19.ToString("0.##");
											item11[3] = ((item11[2].ToString() == "") ? "" : (Convert.ToDecimal(item11[2].ToString()) * num19).ToString("0.00", Thread.CurrentThread.CurrentCulture));
										}
									}
								}
								if (CS_0024_003C_003E8__locals3.prevComboId > 0)
								{
									foreach (ListViewDataItem item12 in CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals3.prevComboId.ToString()))
									{
										if (item12 != CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index])
										{
											decimal num20 = ((item12[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(item12[0].ToString())) / num16;
											item12[0] = num20.ToString("0.##");
											item12[3] = ((item12[2].ToString() == "") ? "" : (Convert.ToDecimal(item12[2].ToString()) * num20).ToString("0.00", Thread.CurrentThread.CurrentCulture));
										}
									}
								}
								flag3 = true;
								MemoryLoadedObjects.OrderEntry.isSaved = false;
							}
							else
							{
								decimal num21 = ((CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][0].ToString()));
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][2] = CS_0024_003C_003E8__locals2.indexToChange.DiscountedPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index][3] = (CS_0024_003C_003E8__locals2.indexToChange.DiscountedPrice * num21).ToString("0.00", Thread.CurrentThread.CurrentCulture);
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[13] = CS_0024_003C_003E8__locals1.prom.PromoCode;
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[CS_0024_003C_003E8__locals2.indexToChange.Index].SubItems[15].ToString(), DiscountTypes.Promo, CS_0024_003C_003E8__locals2.indexToChange.DiscountAmount);
								num8 -= (int)CS_0024_003C_003E8__locals2.indexToChange.Qty;
								MemoryLoadedObjects.OrderEntry.isSaved = false;
							}
						}
					}
					if (flag3)
					{
						RecalculatePromotion(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderType, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.OrderDateCreated, ref OeComboId);
					}
					continue;
				}
				using IEnumerator<ListViewDataItem> enumerator2 = enumerable.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass6_7 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass6_7();
					CS_0024_003C_003E8__locals5.lvdi = enumerator2.Current;
					Item item4 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals5.lvdi.SubItems[4].ToString()).FirstOrDefault();
					if (item4 == null)
					{
						item4 = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals5.lvdi.SubItems[4].ToString()).FirstOrDefault();
					}
					if (item4 != null)
					{
						decimal currentPrice3 = Convert.ToDecimal(CS_0024_003C_003E8__locals5.lvdi[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals5.lvdi.SubItems[15].ToString(), DiscountTypes.Promo);
						decimal num22 = GetCurrentPrice(item4, currentPrice3);
						if (CS_0024_003C_003E8__locals5.lvdi.SubItems[8].ToString() != "-1")
						{
							num22 = Convert.ToDecimal(CS_0024_003C_003E8__locals5.lvdi.SubItems[8].ToString());
						}
						decimal num23 = ((CS_0024_003C_003E8__locals5.lvdi[0].ToString() == "") ? 0m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals5.lvdi[0].ToString()));
						CS_0024_003C_003E8__locals5.lvdi[2] = num22.ToString("0.00", Thread.CurrentThread.CurrentCulture);
						CS_0024_003C_003E8__locals5.lvdi[3] = (num23 * num22).ToString("0.00", Thread.CurrentThread.CurrentCulture);
						CS_0024_003C_003E8__locals5.lvdi.SubItems[13] = "";
						CS_0024_003C_003E8__locals5.lvdi.SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals5.lvdi.SubItems[15].ToString(), DiscountTypes.Promo, 0m);
						MemoryLoadedObjects.OrderEntry.isSaved = false;
					}
				}
			}
			else
			{
				if (!(CS_0024_003C_003E8__locals1.prom.GetQtyString == "IT"))
				{
					continue;
				}
				decimal num24 = default(decimal);
				int num25 = 0;
				List<ItemPriceOEIndex> list5 = new List<ItemPriceOEIndex>();
				using (IEnumerator<ListViewDataItem> enumerator2 = enumerable.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass6_8 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass6_8();
						CS_0024_003C_003E8__locals7.lvdi = enumerator2.Current;
						DateTime orderDateCreated2 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals7.lvdi.SubItems[19].ToString())) ? Convert.ToDateTime(CS_0024_003C_003E8__locals7.lvdi.SubItems[19].ToString()) : DateTime.Now);
						if (!IsPromotionTime(CS_0024_003C_003E8__locals1.prom, orderDateCreated2))
						{
							continue;
						}
						Item item5 = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID.ToString() == CS_0024_003C_003E8__locals7.lvdi.SubItems[4].ToString()).FirstOrDefault();
						if (item5 == null && CS_0024_003C_003E8__locals7.lvdi.SubItems[4].ToString() != "-999")
						{
							item5 = new GClass6().Items.Where((Item x) => x.ItemID.ToString() == CS_0024_003C_003E8__locals7.lvdi.SubItems[4].ToString()).FirstOrDefault();
						}
						decimal num26 = ((CS_0024_003C_003E8__locals7.lvdi[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(CS_0024_003C_003E8__locals7.lvdi[0].ToString()));
						if (CS_0024_003C_003E8__locals1.prom.String_0.Split(',').Contains(CS_0024_003C_003E8__locals7.lvdi.SubItems[4].ToString()) || CS_0024_003C_003E8__locals1.prom.String_0 == "-1")
						{
							num24 += num26;
							if (num24 >= CS_0024_003C_003E8__locals1.prom.BuyQty.Value)
							{
								decimal num27 = num24 % CS_0024_003C_003E8__locals1.prom.BuyQty.Value;
								num25 += (int)(num24 - num27);
								num24 = num27;
							}
						}
						decimal currentPrice4 = Convert.ToDecimal(CS_0024_003C_003E8__locals7.lvdi[2].ToString()) + OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals7.lvdi.SubItems[15].ToString(), DiscountTypes.Promo);
						decimal itemPrice = GetCurrentPrice(item5, currentPrice4);
						if (CS_0024_003C_003E8__locals7.lvdi.SubItems[8].ToString() != "-1")
						{
							itemPrice = Convert.ToDecimal(CS_0024_003C_003E8__locals7.lvdi.SubItems[8].ToString());
						}
						PromotionCheck promotionCheck2 = CalculatePromotionOff(CS_0024_003C_003E8__locals1.prom, itemPrice);
						list5.Add(new ItemPriceOEIndex
						{
							ItemName = item5.ItemName,
							ItemId = item5.ItemID,
							ItemPrice = itemPrice,
							DiscountedPrice = promotionCheck2.NewItemPrice,
							DiscountAmount = promotionCheck2.DiscountAmount,
							Index = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.IndexOf(CS_0024_003C_003E8__locals7.lvdi),
							Qty = num26
						});
					}
				}
				bool flag4 = false;
				foreach (ItemPriceOEIndex item13 in list5)
				{
					if (!CS_0024_003C_003E8__locals1.prom.String_0.Split(',').Contains(item13.ItemId.ToString()) && !(CS_0024_003C_003E8__locals1.prom.String_0 == "-1"))
					{
						continue;
					}
					decimal num28 = default(decimal);
					decimal qty3 = item13.Qty;
					if (num25 > 0 && qty3 >= 1m)
					{
						num28 = item13.DiscountedPrice;
						if ((decimal)num25 - qty3 < 0m && qty3 > 1m)
						{
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index][0] = num25.ToString("0.##", Thread.CurrentThread.CurrentCulture);
							int num29 = Convert.ToInt32(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[5].ToString());
							decimal num30 = Math.Abs(num25 - (int)qty3);
							int num31 = 0;
							if (num29 > 0)
							{
								OeComboId++;
								num31 = OeComboId;
							}
							string[] values3 = new string[19]
							{
								num30.ToString("0.##"),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index][1].ToString(),
								item13.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture),
								(item13.ItemPrice * num30).ToString("0.00", Thread.CurrentThread.CurrentCulture),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[4].ToString(),
								num31.ToString(),
								string.Empty,
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[7].ToString(),
								item13.ItemPrice.ToString("0.00", Thread.CurrentThread.CurrentCulture),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[9].ToString(),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[10].ToString(),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[11].ToString(),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[12].ToString(),
								"",
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[14].ToString(),
								"",
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[16].ToString(),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[17].ToString(),
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[18].ToString()
							};
							ListViewDataItem listViewDataItem4 = new ListViewDataItem("", values3);
							listViewDataItem4.Group = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].Group;
							listViewDataItem4.Font = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].Font;
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items.Add(listViewDataItem4);
							flag4 = true;
						}
						num25 -= (int)qty3;
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[15].ToString(), DiscountTypes.Promo, item13.DiscountAmount);
					}
					else
					{
						num28 = item13.ItemPrice;
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[15] = UpdateDiscountFromDiscountDescription(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[15].ToString(), DiscountTypes.Promo, 0m);
					}
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index][2] = num28.ToString("0.00", Thread.CurrentThread.CurrentCulture);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index][3] = (qty3 * num28).ToString("0.00", Thread.CurrentThread.CurrentCulture);
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems.Items[item13.Index].SubItems[13] = CS_0024_003C_003E8__locals1.prom.PromoCode;
					MemoryLoadedObjects.OrderEntry.isSaved = false;
				}
				if (flag4)
				{
					RecalculatePromotion(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.radListItems, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.orderType, CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.OrderDateCreated, ref OeComboId);
				}
			}
		}
	}

	public static string UpdateDiscountFromDiscountDescription(string DiscountDesc, string DiscountType, decimal value)
	{
		string text = "";
		if (DiscountDesc == null || !DiscountDesc.Contains(DiscountType))
		{
			text = ((!(value > 0m)) ? DiscountDesc : (DiscountDesc + DiscountType + "=" + value.ToString("0.000", Thread.CurrentThread.CurrentCulture) + "|"));
		}
		else if (!string.IsNullOrEmpty(DiscountDesc))
		{
			string[] array = DiscountDesc.Split('|');
			foreach (string text2 in array)
			{
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				if (text2.Contains(DiscountType))
				{
					if (value > 0m)
					{
						text = text + text2.Split('=')[0] + "=" + value.ToString("0.000", Thread.CurrentThread.CurrentCulture) + "|";
					}
				}
				else
				{
					text = text + text2 + "|";
				}
			}
		}
		return text;
	}

	public static decimal GetCurrentPrice(Item item, decimal currentPrice)
	{
		decimal taxIncludedItemPrice = GetTaxIncludedItemPrice(item);
		if (!(currentPrice > taxIncludedItemPrice))
		{
			return taxIncludedItemPrice;
		}
		return currentPrice;
	}

	public static decimal GetTaxIncludedItemPrice(Item item)
	{
		decimal result = item.ItemPrice;
		if (item.TaxesIncluded)
		{
			decimal inventoryCount = item.InventoryCount;
			item.InventoryCount = 1m;
			result = TaxMethods.GetPreTaxPrice(new List<Item> { item }, item);
			item.InventoryCount = inventoryCount;
		}
		return result;
	}

	public PromotionMethods()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
