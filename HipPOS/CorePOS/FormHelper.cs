using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class FormHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Order order;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public short comboID;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CChangeOrderEntryLVCellByIdentifier_003Eb__0(ListViewDataItem a)
		{
			return a.SubItems[5].ToString() == comboID.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Order order;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public Appointment res;

		public _003C_003Ec__DisplayClass15_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private bool bool_0;

	public bool IsDisposed => bool_0;

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			bool_0 = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public bool addItemsToList(ListView lstItems, string orderNumber, frmOrderEntry frm = null, float fontSize = 10f, bool isUnpaidOrdersOnly = false)
	{
		lstItems.Items.Clear();
		if (string.IsNullOrEmpty(orderNumber))
		{
			return false;
		}
		bool result = false;
		OrderMethods orderMethods = new OrderMethods();
		GClass6 gClass = new GClass6();
		List<Order> list = (from x in orderMethods.Orders(orderNumber)
			where !x.Void
			orderby (!x.LastDateModified.HasValue) ? x.DateCreated : x.LastDateModified
			select x).ThenBy((Order a) => a.ComboID).ToList();
		if (isUnpaidOrdersOnly)
		{
			list = list.Where((Order o) => !o.Void && !o.Paid).ToList();
		}
		if (list != null)
		{
			if ((short)list.Count((Order o) => o.Discount > 0m) == list.Count())
			{
				result = true;
			}
			int num = 0;
			using List<Order>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
				CS_0024_003C_003E8__locals0.order = enumerator.Current;
				if (CS_0024_003C_003E8__locals0.order.ItemName != null)
				{
					if (CS_0024_003C_003E8__locals0.order.Qty == 0m)
					{
						CS_0024_003C_003E8__locals0.order.Qty = 0.0001m;
					}
					string instructions = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Instructions)) ? CS_0024_003C_003E8__locals0.order.Instructions : string.Empty);
					string orderId = (CS_0024_003C_003E8__locals0.order.ShareItemID.HasValue ? (CS_0024_003C_003E8__locals0.order.OrderId.ToString() + "|" + CS_0024_003C_003E8__locals0.order.ShareItemID.Value) : CS_0024_003C_003E8__locals0.order.OrderId.ToString());
					int batchId = (CS_0024_003C_003E8__locals0.order.InventoryBatchId.HasValue ? CS_0024_003C_003E8__locals0.order.InventoryBatchId.Value : 0);
					Item item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
					decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(CS_0024_003C_003E8__locals0.order.DiscountDesc, DiscountTypes.Promo);
					decimal num2 = default(decimal);
					Promotion promoSaleItemById = PromotionMethods.GetPromoSaleItemById(CS_0024_003C_003E8__locals0.order.ItemID);
					num2 = ((item == null || promoSaleItemById == null || !item.OnSale) ? (CS_0024_003C_003E8__locals0.order.ItemSellPrice + CS_0024_003C_003E8__locals0.order.Discount / CS_0024_003C_003E8__locals0.order.Qty - discountFromDiscountDescription) : ((Math.Round(promoSaleItemById.GetDiscountAmount.Value, 2) == Math.Round(CS_0024_003C_003E8__locals0.order.ItemSellPrice, 2) || Math.Round(CS_0024_003C_003E8__locals0.order.Discount / CS_0024_003C_003E8__locals0.order.Qty + CS_0024_003C_003E8__locals0.order.ItemSellPrice, 2) == Math.Round(item.ItemPrice, 2)) ? promoSaleItemById.GetDiscountAmount.Value : (CS_0024_003C_003E8__locals0.order.ItemSellPrice + CS_0024_003C_003E8__locals0.order.Discount / CS_0024_003C_003E8__locals0.order.Qty - discountFromDiscountDescription)));
					if (gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.order.ItemID && i.ToBeDeleted == false).ToList().Count() > 0)
					{
						num++;
					}
					subAddItemsToList(lstItems, CS_0024_003C_003E8__locals0.order.Qty.ToString(), CS_0024_003C_003E8__locals0.order.ItemName + ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Options)) ? (" => " + CS_0024_003C_003E8__locals0.order.Options) : string.Empty), num2.ToString(MathHelper.FormatPriceDecimals(num2)), CS_0024_003C_003E8__locals0.order.ItemID, CS_0024_003C_003E8__locals0.order.ComboID, num, orderId, CS_0024_003C_003E8__locals0.order.Void, instructions, batchId, CS_0024_003C_003E8__locals0.order.OrderOnHoldTime, frm, fontSize, CS_0024_003C_003E8__locals0.order.ItemIdentifier, lstItems.Items.Count, CS_0024_003C_003E8__locals0.order.Discount, CS_0024_003C_003E8__locals0.order.DiscountDesc, CS_0024_003C_003E8__locals0.order.ItemOptionId.HasValue ? CS_0024_003C_003E8__locals0.order.ItemOptionId.Value : 0, CS_0024_003C_003E8__locals0.order.ItemCourse);
					continue;
				}
				return result;
			}
			return result;
		}
		return result;
	}

	public static void ChangeOrderEntryLVCellByIdentifier(RadListView rlv, ListViewDataItem view, float fontSize, string itemIdentifier)
	{
		if (string.IsNullOrEmpty(itemIdentifier))
		{
			itemIdentifier = "MainItem";
		}
		view.ForeColor = Color.Black;
		if (itemIdentifier == "MainItem")
		{
			view.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
			return;
		}
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		decimal num = 1m;
		CS_0024_003C_003E8__locals0.comboID = Convert.ToInt16(view.SubItems[5].ToString());
		if (CS_0024_003C_003E8__locals0.comboID > 0)
		{
			ListViewDataItem listViewDataItem = rlv.Items.Where((ListViewDataItem a) => a.SubItems[5].ToString() == CS_0024_003C_003E8__locals0.comboID.ToString()).FirstOrDefault();
			num = ((listViewDataItem == null) ? 1m : ((listViewDataItem[0].ToString() == "") ? 1m : MathHelper.FractionToDecimal(listViewDataItem[0].ToString())));
		}
		string fraction = ((view[0].ToString() == "") ? "1" : view[0].ToString());
		if (view[3].ToString() == "0.00" && view[0].ToString() == "1" && num >= MathHelper.FractionToDecimal(fraction))
		{
			view[0] = "";
			view[2] = "";
			view[3] = "";
		}
		else if (view[3].ToString() == "0.00")
		{
			view[2] = "";
			view[3] = "";
		}
		view.Font = new Font("Microsoft Sans Serif", fontSize - 1f, FontStyle.Regular);
		if (itemIdentifier == "OptionItem")
		{
			view.ForeColor = Color.DarkRed;
		}
	}

	public static void ChangeOrderEntryLVWinformsCellByIdentifier(ListView list, ListViewItem view, float fontSize, string itemIdentifier)
	{
		if (string.IsNullOrEmpty(itemIdentifier))
		{
			itemIdentifier = "MainItem";
		}
		view.ForeColor = Color.Black;
		if (itemIdentifier == "MainItem")
		{
			view.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
			return;
		}
		decimal num = 1m;
		short num2 = Convert.ToInt16(view.SubItems[5].Text);
		if (num2 > 0)
		{
			foreach (ListViewItem item in list.Items)
			{
				if (item.SubItems[5].Text == num2.ToString())
				{
					num = ((item.SubItems[0].Text == "") ? 1m : MathHelper.FractionToDecimal(item.SubItems[0].Text));
					break;
				}
			}
		}
		string fraction = ((view.SubItems[0].Text == "") ? "1" : view.SubItems[0].Text);
		if (view.SubItems[3].Text == "0.00" && view.SubItems[0].Text == "1" && num >= MathHelper.FractionToDecimal(fraction))
		{
			view.SubItems[0].Text = "";
			view.SubItems[2].Text = "";
			view.SubItems[3].Text = "";
		}
		else if (view.SubItems[3].Text == "0.00")
		{
			view.SubItems[2].Text = "";
			view.SubItems[3].Text = "";
		}
		view.Font = new Font("Microsoft Sans Serif", fontSize - 1f, FontStyle.Regular);
		if (itemIdentifier == "OptionItem")
		{
			view.ForeColor = Color.DarkRed;
		}
	}

	public bool addItemsToRadList(RadListView lstItems, string orderNumber, frmOrderEntry frm = null, float fontSize = 10f)
	{
		lstItems.Items.Clear();
		if (string.IsNullOrEmpty(orderNumber))
		{
			return false;
		}
		bool result = false;
		OrderMethods orderMethods = new OrderMethods();
		OrderHelper orderHelper = new OrderHelper();
		GClass6 gClass = new GClass6();
		List<Order> list = (from x in orderMethods.Orders(orderNumber)
			where !x.Void
			select x into o
			orderby o.DateCreated
			select o).ToList();
		if (list != null)
		{
			if ((short)list.Count((Order o) => o.Discount > 0m) == list.Count())
			{
				result = true;
			}
			int num = 0;
			using List<Order>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
				CS_0024_003C_003E8__locals0.order = enumerator.Current;
				if (CS_0024_003C_003E8__locals0.order.ItemName != null)
				{
					string instructions = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Instructions)) ? CS_0024_003C_003E8__locals0.order.Instructions : string.Empty);
					string orderId = (CS_0024_003C_003E8__locals0.order.ShareItemID.HasValue ? (CS_0024_003C_003E8__locals0.order.OrderId.ToString() + "|" + CS_0024_003C_003E8__locals0.order.ShareItemID.Value) : CS_0024_003C_003E8__locals0.order.OrderId.ToString());
					int batchId = orderHelper.CheckAndSelectBatchId(CS_0024_003C_003E8__locals0.order.ItemID);
					if (gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.order.ItemID && i.ToBeDeleted == false).ToList().Count() > 0)
					{
						num++;
					}
					subAddItemsToListTelerik(lstItems, CS_0024_003C_003E8__locals0.order.Qty.ToString(), "1", CS_0024_003C_003E8__locals0.order.ItemName + ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.Options)) ? (" => " + CS_0024_003C_003E8__locals0.order.Options) : string.Empty), CS_0024_003C_003E8__locals0.order.ItemSellPrice.ToString("0.00"), CS_0024_003C_003E8__locals0.order.ItemID, CS_0024_003C_003E8__locals0.order.ComboID, num, orderId, CS_0024_003C_003E8__locals0.order.Void, instructions, batchId, CS_0024_003C_003E8__locals0.order.ItemSellPrice, CS_0024_003C_003E8__locals0.order.OrderOnHoldTime, frm, CS_0024_003C_003E8__locals0.order.ItemOptionId.HasValue ? CS_0024_003C_003E8__locals0.order.ItemOptionId.Value : 0, fontSize, CS_0024_003C_003E8__locals0.order.ItemIdentifier, lstItems.Items.Count, 0, CS_0024_003C_003E8__locals0.order.Discount, CS_0024_003C_003E8__locals0.order.DiscountDesc, CS_0024_003C_003E8__locals0.order.OverridePrice);
					continue;
				}
				return result;
			}
			return result;
		}
		return result;
	}

	public bool subAddItemsToList(ListView list, string itemQty, string itemname, string itemprice, int itemID, int comboID, int optionComboId, string orderId, bool Void, string instructions, int batchId, int orderOnHold, frmOrderEntry frm, float fontSize = 10f, string itemIdentifier = "MainItem", int index = -1, decimal discount = 0m, string discountDesc = null, int itemOptionId = 0, string itemCourse = null, ListViewItem fromListViewItem = null)
	{
		itemQty = ((itemQty == "") ? "1" : itemQty);
		decimal num = MathHelper.FractionToDecimal(itemQty);
		itemprice = ((itemprice == "") ? "0.00" : itemprice);
		string[] array = new string[20];
		decimal num2 = default(decimal);
		int num3 = comboID;
		if (orderId.Contains("|"))
		{
			string text = orderId.Split('|')[1];
			foreach (ListViewItem item2 in list.Items)
			{
				if (item2.Font.Strikeout)
				{
					continue;
				}
				if (item2.SubItems[6].Text.Contains("|"))
				{
					if (!(item2.SubItems[6].Text.Split('|')[1] == text) && !(item2.SubItems[6].Text == text))
					{
						continue;
					}
					if (!item2.Font.Strikeout)
					{
						num += MathHelper.FractionToDecimal(item2.SubItems[0].Text);
						decimal num4 = Math.Abs((decimal)Convert.ToInt32(num) - num);
						if (num4 == 0.9999m || num4 == 0.0001m)
						{
							num = Convert.ToInt32(num);
						}
						if (num < 1m)
						{
							array[0] = MathHelper.DecimalToFraction(num);
						}
						else
						{
							array[0] = MathHelper.RemoveTrailingZeros(num.ToString());
						}
						if (!string.IsNullOrEmpty(item2.SubItems[15].ToString()) && !string.IsNullOrEmpty(discountDesc))
						{
							decimal discountFromDiscountDescription = OrderHelper.GetDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item);
							decimal discountFromDiscountDescription2 = OrderHelper.GetDiscountFromDiscountDescription(discountDesc, DiscountTypes.Order);
							decimal discountFromDiscountDescription3 = OrderHelper.GetDiscountFromDiscountDescription(item2.SubItems[15].ToString(), DiscountTypes.Item);
							decimal discountFromDiscountDescription4 = OrderHelper.GetDiscountFromDiscountDescription(item2.SubItems[15].ToString(), DiscountTypes.Order);
							discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item, discountFromDiscountDescription + discountFromDiscountDescription3);
							discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Order, discountFromDiscountDescription2 + discountFromDiscountDescription4);
							item2.SubItems[15].Text = discountDesc;
						}
						item2.SubItems[0].Text = array[0];
						num2 = Convert.ToDecimal(itemprice) * num;
						item2.SubItems[3].Text = num2.ToString("0.00");
						ChangeOrderEntryLVWinformsCellByIdentifier(list, item2, fontSize, itemIdentifier);
						return true;
					}
					num3 = comboID + 1;
				}
				else if (item2.SubItems[6].Text.Contains("|") || !(item2.SubItems[6].Text != text))
				{
					num += MathHelper.FractionToDecimal(item2.SubItems[0].Text);
					decimal num5 = Math.Abs((decimal)Convert.ToInt32(num) - num);
					if (num5 == 0.9999m || num5 == 0.0001m)
					{
						num = Convert.ToInt32(num);
					}
					if (num < 1m)
					{
						array[0] = MathHelper.DecimalToFraction(num);
					}
					else
					{
						array[0] = MathHelper.RemoveTrailingZeros(num.ToString());
					}
					if (!string.IsNullOrEmpty(item2.SubItems[15].ToString()) && !string.IsNullOrEmpty(discountDesc))
					{
						decimal discountFromDiscountDescription5 = OrderHelper.GetDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item);
						decimal discountFromDiscountDescription6 = OrderHelper.GetDiscountFromDiscountDescription(discountDesc, DiscountTypes.Order);
						decimal discountFromDiscountDescription7 = OrderHelper.GetDiscountFromDiscountDescription(item2.SubItems[15].Text, DiscountTypes.Item);
						decimal discountFromDiscountDescription8 = OrderHelper.GetDiscountFromDiscountDescription(item2.SubItems[15].Text, DiscountTypes.Order);
						discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Item, discountFromDiscountDescription5 + discountFromDiscountDescription7);
						discountDesc = OrderHelper.UpdateDiscountFromDiscountDescription(discountDesc, DiscountTypes.Order, discountFromDiscountDescription6 + discountFromDiscountDescription8);
						item2.SubItems[15].Text = discountDesc;
					}
					item2.SubItems[0].Text = array[0];
					num2 = Convert.ToDecimal(itemprice) * num;
					item2.SubItems[3].Text = num2.ToString("0.00");
					ChangeOrderEntryLVWinformsCellByIdentifier(list, item2, fontSize, itemIdentifier);
					return true;
				}
			}
		}
		else
		{
			foreach (ListViewItem item3 in list.Items)
			{
				if (item3.Font.Strikeout)
				{
					continue;
				}
				string text2 = item3.SubItems[6].Text;
				if ((!item3.SubItems[6].Text.Contains(orderId) || !item3.Font.Strikeout) && !string.IsNullOrEmpty(orderId) && item3.SubItems[6].Text.Contains(orderId) && fromListViewItem != null)
				{
					if (MathHelper.FractionToDecimal(fromListViewItem.SubItems[0].Text) == MathHelper.FractionToDecimal(itemQty))
					{
						item3.SubItems[6].Text = orderId;
						fromListViewItem.SubItems[6].Text = text2;
					}
					num += MathHelper.FractionToDecimal(item3.SubItems[0].Text);
					decimal num6 = Math.Abs((decimal)Convert.ToInt32(num) - num);
					if (num6 == 0.9999m || num6 == 0.0001m)
					{
						num = Convert.ToInt32(num);
					}
					if (num < 1m)
					{
						array[0] = MathHelper.DecimalToFraction(num);
					}
					else
					{
						array[0] = MathHelper.RemoveTrailingZeros(num.ToString());
					}
					item3.SubItems[0].Text = array[0];
					num2 = Convert.ToDecimal(itemprice) * num;
					item3.SubItems[3].Text = num2.ToString("0.00");
					ChangeOrderEntryLVWinformsCellByIdentifier(list, item3, fontSize, itemIdentifier);
					return true;
				}
			}
		}
		comboID = num3;
		decimal num7 = Math.Abs((decimal)Convert.ToInt32(num) - num);
		if (num7 == 0.9999m || num7 == 0.0001m)
		{
			num = Convert.ToInt32(num);
		}
		if (num < 1m)
		{
			array[0] = MathHelper.DecimalToFraction(num);
		}
		else
		{
			array[0] = MathHelper.RemoveTrailingZeros(num.ToString());
		}
		array[1] = itemname.Replace("&&", "&");
		try
		{
			array[2] = $"{itemprice:0.00}";
			if (array[2].Equals("0"))
			{
				array[2] = "0.00";
			}
			array[3] = (Convert.ToDecimal(itemprice) * num).ToString("0.00");
		}
		catch
		{
			array[2] = itemprice;
			array[3] = (Convert.ToDecimal(itemprice) * num).ToString("0.00");
		}
		array[4] = itemID.ToString();
		array[5] = comboID.ToString();
		array[6] = orderId.ToString();
		array[7] = instructions;
		array[8] = "-1";
		array[9] = batchId.ToString();
		array[10] = "0";
		array[11] = optionComboId.ToString();
		array[12] = false.ToString();
		array[13] = "";
		array[14] = orderOnHold.ToString();
		array[15] = discountDesc;
		array[16] = itemIdentifier;
		array[17] = itemOptionId.ToString();
		array[18] = "0";
		array[19] = itemCourse;
		ListViewItem item = new ListViewItem(array);
		if (index == -1)
		{
			index = list.Items.Count;
		}
		list.Items.Insert(index, item);
		list.Items[list.Items.Count - 1].ForeColor = Color.Black;
		ChangeOrderEntryLVWinformsCellByIdentifier(list, list.Items[list.Items.Count - 1], fontSize, itemIdentifier);
		if (Void)
		{
			list.Items[list.Items.Count - 1].ForeColor = Color.Red;
			list.Items[list.Items.Count - 1].Font = new Font(list.Items[list.Items.Count - 1].Font, list.Items[list.Items.Count - 1].Font.Style | FontStyle.Strikeout);
		}
		return true;
	}

	public bool subAddItemsToListTelerik(RadListView list, string mainItemQty, string optionItemQty, string itemname, string itemprice, int itemID, int comboID, int optionComboId, string orderId, bool Void, string instructions, int batchId, decimal originalPrice, int orderOnHold, frmOrderEntry frm, int itemOptionId, float fontSize = 10f, string itemIdentifier = "MainItem", int index = -1, int promoId = 0, decimal discount = 0m, string discountDesc = null, decimal? overridePrice = null, ListViewItem fromListViewItem = null)
	{
		decimal num = MathHelper.FractionToDecimal(mainItemQty);
		decimal num2 = MathHelper.FractionToDecimal(optionItemQty);
		decimal num3 = num * num2;
		string[] array = new string[22];
		decimal num4 = default(decimal);
		int num5 = comboID;
		if (orderId.Contains("|"))
		{
			string text = orderId.Split('|')[1];
			foreach (ListViewDataItem item in list.Items)
			{
				if (item.SubItems[6].ToString().Contains("|"))
				{
					if (!(item.SubItems[6].ToString().Split('|')[1] == text) && !(item.SubItems[6].ToString() == text))
					{
						continue;
					}
					if (!item.Font.Strikeout)
					{
						num3 += MathHelper.FractionToDecimal(item.SubItems[0].ToString());
						if (num3 == 0.9999m)
						{
							num3 = 1m;
						}
						if (num3 < 1m)
						{
							array[0] = MathHelper.DecimalToFraction(num3);
						}
						else
						{
							array[0] = MathHelper.RemoveTrailingZeros(num3.ToString());
						}
						item.SubItems[0] = array[0];
						num4 = Convert.ToDecimal(itemprice) * num3;
						item.SubItems[3] = num4.ToString("0.00");
						ChangeOrderEntryLVCellByIdentifier(list, item, fontSize, itemIdentifier);
						return true;
					}
					num5 = comboID + 1;
				}
				else if (item.SubItems[6].ToString().Contains("|") || !(item.SubItems[6].ToString() != text))
				{
					num3 += MathHelper.FractionToDecimal(item.SubItems[0].ToString());
					if (num3 == 0.9999m)
					{
						num3 = 1m;
					}
					if (num3 < 1m)
					{
						array[0] = MathHelper.DecimalToFraction(num3);
					}
					else
					{
						array[0] = MathHelper.RemoveTrailingZeros(num3.ToString());
					}
					item.SubItems[0] = array[0];
					num4 = Convert.ToDecimal(itemprice) * num3;
					item.SubItems[3] = num4.ToString("0.00");
					ChangeOrderEntryLVCellByIdentifier(list, item, fontSize, itemIdentifier);
					return true;
				}
			}
		}
		else
		{
			foreach (ListViewDataItem item2 in list.Items)
			{
				string text2 = item2.SubItems[6].ToString();
				if (item2.SubItems[6].ToString().Contains(orderId) && item2.Font != null)
				{
					_ = item2.Font.Strikeout;
				}
				if (!string.IsNullOrEmpty(orderId) && item2.SubItems[6].ToString().Contains(orderId) && fromListViewItem != null)
				{
					if (MathHelper.FractionToDecimal(fromListViewItem.SubItems[0].Text) == num3)
					{
						item2.SubItems[6] = orderId;
						fromListViewItem.SubItems[6].Text = text2;
					}
					num3 += MathHelper.FractionToDecimal(item2.SubItems[0].ToString());
					if (num3 == 0.9999m)
					{
						num3 = 1m;
					}
					if (num3 < 1m)
					{
						array[0] = MathHelper.DecimalToFraction(num3);
					}
					else
					{
						array[0] = MathHelper.RemoveTrailingZeros(num3.ToString());
					}
					item2.SubItems[0] = array[0];
					num4 = Convert.ToDecimal(itemprice) * num3;
					item2.SubItems[3] = num4.ToString("0.00");
					ChangeOrderEntryLVCellByIdentifier(list, item2, fontSize, itemIdentifier);
					return true;
				}
			}
		}
		comboID = num5;
		if (num3 == 0.9999m)
		{
			num3 = 1m;
		}
		if (num3 < 1m)
		{
			array[0] = MathHelper.DecimalToFraction(num3);
		}
		else
		{
			array[0] = MathHelper.RemoveTrailingZeros(num3.ToString());
		}
		if (SettingsHelper.GetSettingValueByKey("capitalize_item_group_text") == "ON")
		{
			itemname = itemname.ToUpper();
		}
		array[1] = itemname.Replace("&&", "&");
		try
		{
			array[2] = Convert.ToDecimal(itemprice).ToString("0.00");
			if (array[2].Equals("0"))
			{
				array[2] = "0.00";
			}
			array[3] = (Convert.ToDecimal(itemprice) * num3).ToString("0.00");
		}
		catch
		{
			array[2] = Convert.ToDecimal(itemprice).ToString("0.00");
			array[3] = (Convert.ToDecimal(itemprice) * num3).ToString("0.00");
		}
		array[4] = itemID.ToString();
		array[5] = comboID.ToString();
		array[6] = orderId.ToString();
		array[7] = instructions;
		array[8] = originalPrice.ToString("0.00");
		array[9] = batchId.ToString();
		array[10] = "0";
		array[11] = optionComboId.ToString();
		array[12] = false.ToString();
		array[13] = "";
		array[14] = orderOnHold.ToString();
		array[15] = "";
		array[16] = itemIdentifier;
		array[17] = itemOptionId.ToString();
		array[18] = promoId.ToString();
		array[19] = DateTime.Now.ToString();
		array[20] = (overridePrice.HasValue ? overridePrice.Value.ToString() : "");
		array[21] = false.ToString();
		ListViewDataItem listViewDataItem = new ListViewDataItem("", array);
		if (MemoryLoadedObjects.OptionScreen != null && MemoryLoadedObjects.OptionScreen.courseGroup != null && SettingsHelper.GetSettingValueByKey("course_selection") == "ON")
		{
			listViewDataItem.Group = MemoryLoadedObjects.OptionScreen.courseGroup;
		}
		if (index == -1)
		{
			index = list.Items.Count - 1;
		}
		list.Items.Insert(index, listViewDataItem);
		ChangeOrderEntryLVCellByIdentifier(list, list.Items[index], fontSize, itemIdentifier);
		if (Void)
		{
			list.Items[index].ForeColor = Color.Red;
			list.Items[index].Font = new Font(list.Items[index - 1].Font, list.Items[index - 1].Font.Style | FontStyle.Strikeout);
		}
		return true;
	}

	public void subAddItemsToStationList(ListView list, string time, string orderNumber, string orderType, string customer, string qty, string itemCourse, string item, bool Void, string orderid, Color rowColor, Color fontColor, float fontSize = 10f)
	{
		ListViewItem value = new ListViewItem(new string[8] { time, orderNumber, orderType, customer, qty, itemCourse, item, orderid });
		list.Items.Add(value);
		list.Items[list.Items.Count - 1].Font = new Font(list.Items[list.Items.Count - 1].Font.FontFamily.ToString(), fontSize, FontStyle.Bold);
		list.Items[list.Items.Count - 1].ForeColor = Color.Black;
		if (Void)
		{
			list.Items[list.Items.Count - 1].ForeColor = Color.Red;
			list.Items[list.Items.Count - 1].Font = new Font(list.Items[list.Items.Count - 1].Font, list.Items[list.Items.Count - 1].Font.Style | FontStyle.Strikeout);
		}
		list.Items[list.Items.Count - 1].ForeColor = fontColor;
		list.Items[list.Items.Count - 1].BackColor = rowColor;
	}

	public void subAddItemsToStationListTelerik(RadListView rv, string time, string orderNumber, string orderType, string customer, string qty, string itemCourse, bool Void, string item, string orderid, Color rowColor, Color fontColor, float fontSize = 10f)
	{
		Font font = new Font(rv.Font.FontFamily, fontSize, FontStyle.Bold);
		Color foreColor = fontColor;
		if (Void)
		{
			foreColor = Color.Red;
			font = new Font(font, font.Style | FontStyle.Strikeout);
		}
		ListViewDataItem listViewDataItem = new ListViewDataItem("", new string[8] { time, orderNumber, orderType, customer, qty, itemCourse, item, orderid });
		listViewDataItem.Font = font;
		listViewDataItem.BackColor = rowColor;
		listViewDataItem.ForeColor = foreColor;
		rv.Items.Add(listViewDataItem);
	}

	public void subAddItemsToStationChitTelerik(RadListView rv, string time, string qty, string item, bool Void, string itemIdentifier = "MainItem", float fontSize = 12f)
	{
		if (string.IsNullOrEmpty(itemIdentifier))
		{
			itemIdentifier = "MainItem";
		}
		Font font = new Font(rv.Font.FontFamily, fontSize, FontStyle.Regular);
		Color black = Color.Black;
		Color white = Color.White;
		ListViewDataItem listViewDataItem = new ListViewDataItem("", new string[2] { qty, item });
		listViewDataItem.BackColor = white;
		listViewDataItem.ForeColor = black;
		if (itemIdentifier == "MainItem")
		{
			listViewDataItem.Font = new Font("Microsoft Sans Serif", fontSize, FontStyle.Bold);
		}
		else
		{
			listViewDataItem[0] = ((listViewDataItem.SubItems[0].ToString() == "1") ? "" : listViewDataItem.SubItems[0]);
			listViewDataItem.Font = new Font("Microsoft Sans Serif", fontSize - 1f, FontStyle.Regular);
			if (itemIdentifier == "OptionItem")
			{
				listViewDataItem.ForeColor = Color.DarkRed;
			}
		}
		if (Void)
		{
			listViewDataItem.ForeColor = Color.Red;
			listViewDataItem.Font = new Font(font, font.Style | FontStyle.Strikeout);
		}
		rv.Items.Add(listViewDataItem);
	}

	public void subAddItemsToTakeoutChitTelerik(RadListView rv, string time, string qty, string item, string price, short comboId, bool Void, string itemIdentifier = "MainItem", float fontSize = 12f)
	{
		if (string.IsNullOrEmpty(itemIdentifier))
		{
			itemIdentifier = "MainItem";
		}
		Font font = new Font(rv.Font.FontFamily, fontSize, FontStyle.Regular);
		Color black = Color.Black;
		Color white = Color.White;
		ListViewDataItem listViewDataItem = new ListViewDataItem("", new string[6]
		{
			qty,
			item,
			price,
			price,
			null,
			comboId.ToString()
		});
		listViewDataItem.Font = font;
		listViewDataItem.BackColor = white;
		listViewDataItem.ForeColor = black;
		ChangeOrderEntryLVCellByIdentifier(rv, listViewDataItem, fontSize, itemIdentifier);
		rv.Items.Add(listViewDataItem);
	}

	public void addReservationsToList(ListView lstReservations, DateTime? date = null)
	{
		GClass6 gClass = new GClass6();
		lstReservations.Items.Clear();
		List<Appointment> upcomingReservations = new DataManager().getUpcomingReservations(date);
		if (upcomingReservations.Count() <= 0)
		{
			return;
		}
		using List<Appointment>.Enumerator enumerator = upcomingReservations.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
			CS_0024_003C_003E8__locals0.res = enumerator.Current;
			Employee employeeByID = UserMethods.GetEmployeeByID(CS_0024_003C_003E8__locals0.res.EmployeeID);
			DateTime startDateTime = CS_0024_003C_003E8__locals0.res.StartDateTime;
			string[] array = new string[6];
			if (employeeByID != null)
			{
				array[0] = (string.IsNullOrEmpty(employeeByID.FirstName) ? "" : employeeByID.FirstName) + " " + (string.IsNullOrEmpty(employeeByID.LastName) ? "" : employeeByID.LastName[0].ToString());
			}
			else
			{
				array[0] = "";
			}
			CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
			array[1] = cultureInfo.DateTimeFormat.GetDayName(startDateTime.DayOfWeek).ToString().Substring(0, 3) + ", " + startDateTime.ToString("MMM") + " " + startDateTime.Day + " @ " + CS_0024_003C_003E8__locals0.res.StartDateTime.ToShortTimeString();
			Layout layout = gClass.Layouts.Where((Layout a) => a.AppointmentID == (int?)CS_0024_003C_003E8__locals0.res.AppointmentID).FirstOrDefault();
			array[2] = ((layout != null) ? layout.TableName : "");
			array[3] = CS_0024_003C_003E8__locals0.res.NumOfPeople.ToString();
			array[4] = CS_0024_003C_003E8__locals0.res.CustomerName;
			array[5] = CS_0024_003C_003E8__locals0.res.AppointmentID.ToString();
			ListViewItem value = new ListViewItem(array);
			lstReservations.Items.Add(value);
		}
	}

	public void validateNumberOnlyTextBox(TextBox txtbox)
	{
		if (Regex.IsMatch(txtbox.Text, "[^0-9]"))
		{
			MessageBox.Show(Resources.Please_enter_only_numbers);
			txtbox.Text = txtbox.Text.Remove(txtbox.Text.Length - 1);
			txtbox.SelectionStart = txtbox.Text.Length;
		}
	}

	public void validateNumberOnlyTextBox(RadTextBoxControl txtbox)
	{
		if (Regex.IsMatch(txtbox.Text, "[^0-9]"))
		{
			MessageBox.Show(Resources.Please_enter_only_numbers);
			txtbox.Text = txtbox.Text.Remove(txtbox.Text.Length - 1);
			txtbox.SelectionStart = txtbox.Text.Length;
		}
	}

	public void ResizeButtonFonts(Control parentControl, float sizeReduction = 1f)
	{
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("en-US"))
		{
			return;
		}
		foreach (Panel item in parentControl.Controls.OfType<Panel>().Cast<Control>().ToList())
		{
			ResizeButtonFonts(item);
		}
		foreach (TabControl item2 in parentControl.Controls.OfType<TabControl>().Cast<Control>().ToList())
		{
			foreach (TabPage item3 in item2.Controls.OfType<TabPage>().Cast<Control>().ToList())
			{
				ResizeButtonFonts(item3);
			}
		}
		foreach (Button item4 in parentControl.Controls.OfType<Button>().Cast<Control>().ToList())
		{
			if (item4.Font.Size - sizeReduction > 6f)
			{
				item4.Font = new Font(item4.Font.FontFamily, item4.Font.Size - sizeReduction, item4.Font.Style);
			}
		}
		foreach (Label item5 in parentControl.Controls.OfType<Label>().Cast<Control>().ToList())
		{
			if (item5.Font.Size - sizeReduction > 6f)
			{
				item5.Font = new Font(item5.Font.FontFamily, item5.Font.Size - sizeReduction, item5.Font.Style);
			}
		}
	}

	public static void SimpleButtonEnableDisable_EnabledChange(Button sender, EventArgs e)
	{
		Button button = sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	public static void CleanupObjects()
	{
		frmQuickService frmQuickService2 = Application.OpenForms.OfType<frmQuickService>().FirstOrDefault();
		if (frmQuickService2 != null)
		{
			frmQuickService2.multipleBillsToCompare.Clear();
			frmQuickService2.multipleBillsToCompare = null;
			frmQuickService2.Dispose();
		}
		Application.OpenForms.OfType<frmQuickServiceListView>().FirstOrDefault()?.Dispose();
		Application.OpenForms.OfType<frmMultiBills>().FirstOrDefault()?.Dispose();
		Application.OpenForms.OfType<frmLayout>().FirstOrDefault()?.Dispose();
		Application.OpenForms.OfType<frmAdmin>().FirstOrDefault()?.CloseAdmin();
		Application.OpenForms.OfType<frmOrderEntryShowItems>().FirstOrDefault()?.Dispose();
		Application.OpenForms.OfType<frmStationServingScreen>().FirstOrDefault()?.Dispose();
		GC.Collect();
	}

	public FormHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
	}
}
