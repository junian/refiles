using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.ThirdPartyAPIs.OnlineOrdering;
using CorePOS.Data;

namespace CorePOS.Business.Methods.ThirdPartyAPIs.OnlineOrdering;

public static class ModuurnMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public OnlineOrderSyncQueue queue;

		public _003C_003Ec__DisplayClass1_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CQueueOrders_003Eb__1(OnlineOrderSyncQueue x)
		{
			return x.RawData == queue.RawData;
		}

		internal bool _003CQueueOrders_003Eb__2(OnlineOrderSyncQueue x)
		{
			return x.RawData == queue.RawData;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string orderNumber;

		public _003C_003Ec__DisplayClass2_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public ModuurnXMLObjects.Item mItem;

		public _003C_003Ec__DisplayClass2_1()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__3(Item x)
		{
			return x.Barcode == mItem.Id.Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_2
	{
		public ModuurnXMLObjects.Option option;

		public _003C_003Ec__DisplayClass2_2()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__4(Item x)
		{
			return x.Barcode == option.Id;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_3
	{
		public ModuurnXMLObjects.Subitem subitem;

		public _003C_003Ec__DisplayClass2_3()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__5(Item x)
		{
			return x.Barcode == subitem.Id.Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_4
	{
		public ModuurnXMLObjects.Item mItem;

		public _003C_003Ec__DisplayClass2_4()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__8(Item x)
		{
			return x.Barcode == mItem.Id.Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_5
	{
		public string[] Ids;

		public _003C_003Ec__DisplayClass2_5()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__6(Item x)
		{
			return x.Barcode == Ids[0].Trim();
		}

		internal bool _003CProcessOrderQueues_003Eb__7(Item x)
		{
			return x.Barcode == Ids[1].Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_6
	{
		public ModuurnXMLObjects.Option mOption;

		public _003C_003Ec__DisplayClass2_6()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__11(Item x)
		{
			return x.Barcode == mOption.Id.Trim();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_7
	{
		public ModuurnXMLObjects.Subitem subitem;

		public _003C_003Ec__DisplayClass2_7()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}

		internal bool _003CProcessOrderQueues_003Eb__10(Item x)
		{
			return x.Barcode == subitem.Id.Trim();
		}
	}

	public static bool GetOrders(string Url, string apiKey)
	{
		if (!string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(apiKey))
		{
			Url += apiKey;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
			httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
			httpWebRequest.Method = "POST";
			httpWebRequest.Proxy = null;
			try
			{
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				string text = streamReader.ReadToEnd().Replace("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>", string.Empty);
				text = text.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", string.Empty);
				if (text.Contains("<count>0</count><orders/>"))
				{
					SyncMethods.WriteToSyncLog("Moduurn Order\r\nXML RESPONSE: \r\n" + text, "OnlineOrderSync_");
				}
				else
				{
					SyncMethods.WriteToSyncLog("Moduurn Order ORDERS RECEIVED.", "OnlineOrderSync_");
				}
				ModuurnXMLObjects.Root root = (ModuurnXMLObjects.Root)new XmlSerializer(typeof(ModuurnXMLObjects.Root)).Deserialize(new StringReader(text));
				if (root.Count != "0")
				{
					smethod_0(root);
				}
				return true;
			}
			catch (Exception ex)
			{
				SyncMethods.WriteToSyncLog("Moduurn Order XML \r\nERROR: \r\n" + ex.Message, "OnlineOrderSync_");
				return false;
			}
		}
		return false;
	}

	private static void smethod_0(ModuurnXMLObjects.Root root_0)
	{
		GClass6 gClass = new GClass6();
		List<OnlineOrderSyncQueue> source = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue x) => x.Provider == OnlineOrderProviders.Moduurn && x.DateCreated > DateTime.Now.AddDays(-3.0)).ToList();
		List<OnlineOrderSyncQueue> list = new List<OnlineOrderSyncQueue>();
		foreach (ModuurnXMLObjects.Order order in root_0.Orders)
		{
			_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
			CS_0024_003C_003E8__locals0.queue = new OnlineOrderSyncQueue();
			CS_0024_003C_003E8__locals0.queue.DateCreated = DateTime.Now;
			CS_0024_003C_003E8__locals0.queue.DateProcessed = null;
			CS_0024_003C_003E8__locals0.queue.Provider = OnlineOrderProviders.Moduurn;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ModuurnXMLObjects.Order));
			using (StringWriter stringWriter = new StringWriter())
			{
				using XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
				xmlSerializer.Serialize(xmlWriter, order);
				CS_0024_003C_003E8__locals0.queue.RawData = stringWriter.ToString();
			}
			if (source.Where((OnlineOrderSyncQueue x) => x.RawData == CS_0024_003C_003E8__locals0.queue.RawData).Count() == 0 && list.Where((OnlineOrderSyncQueue x) => x.RawData == CS_0024_003C_003E8__locals0.queue.RawData).Count() == 0)
			{
				list.Add(CS_0024_003C_003E8__locals0.queue);
			}
		}
		gClass.OnlineOrderSyncQueues.InsertAllOnSubmit(list);
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static List<OrderHeader> ProcessOrderQueues()
	{
		GClass6 gClass = new GClass6();
		List<OrderHeader> list = new List<OrderHeader>();
		List<OnlineOrderSyncQueue> list2 = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue x) => x.Provider == OnlineOrderProviders.Moduurn && !x.DateProcessed.HasValue).ToList();
		List<Item> source = new GClass6().Items.Where((Item x) => x.Active == true && x.isDeleted == false).ToList();
		foreach (OnlineOrderSyncQueue item6 in list2)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass2_0();
			decimal num = default(decimal);
			ModuurnXMLObjects.Order order = (ModuurnXMLObjects.Order)new XmlSerializer(typeof(ModuurnXMLObjects.Order)).Deserialize(new StringReader(item6.RawData));
			SyncMethods.WriteToSyncLog("Moduurn: Processing order " + order.Order_id, "OnlineOrderSync_");
			string customerInfoName = order.Client_first_name + " " + order.Client_last_name;
			string client_phone = order.Client_phone;
			string client_address = order.Client_address;
			CS_0024_003C_003E8__locals7.orderNumber = order.Order_id;
			string pickUpOnline = OrderTypes.PickUpOnline;
			pickUpOnline = ((order.Type == "take_out") ? OrderTypes.PickUpOnline : ((!(order.Type == "table_service")) ? OrderTypes.DeliveryOnline : ((!(SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")) ? OrderTypes.DineIn : OrderTypes.ToGo)));
			string instructions = order.Instructions;
			decimal num2 = ((!string.IsNullOrEmpty(order.Tip)) ? smethod_1(order.Tip) : 0m);
			short num3 = 0;
			int currentTerminalID = HelperMethods.GetCurrentTerminalID();
			DateTime value = Convert.ToDateTime(order.Fulfill_at).ToLocalTime();
			if (gClass.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals7.orderNumber).Any())
			{
				SyncMethods.WriteToSyncLog("Moduurn: Order processing skipped, order already exist: " + order.Order_id, "OnlineOrderSync_");
				item6.DateProcessed = DateTime.Now;
				Helper.SubmitChangesWithCatch(gClass);
				continue;
			}
			int orderOnHoldTime = 0;
			bool flag = false;
			if (order.Payment != "LOCATION")
			{
				flag = true;
			}
			DateTime? datePaid = (flag ? new DateTime?(DateTime.Now) : null);
			DateTime? dateFilled = null;
			DateTime? dateRefunded = null;
			string paymentMethods = ((!flag) ? "SAVED ORDER" : order.Payment);
			decimal num4 = smethod_1(order.Delivery_fee);
			decimal rounding = default(decimal);
			short num5 = 0;
			short num6 = 0;
			List<Item> list3 = new List<Item>();
			using (List<ModuurnXMLObjects.Item>.Enumerator enumerator2 = order.Items.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_1();
					CS_0024_003C_003E8__locals0.mItem = enumerator2.Current;
					if (CS_0024_003C_003E8__locals0.mItem.Id == null)
					{
						continue;
					}
					Item item = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals0.mItem.Id.Trim()).FirstOrDefault();
					if (item == null)
					{
						continue;
					}
					list3.Add(item);
					using List<ModuurnXMLObjects.Option>.Enumerator enumerator3 = CS_0024_003C_003E8__locals0.mItem.Options.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						_003C_003Ec__DisplayClass2_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass2_2();
						CS_0024_003C_003E8__locals1.option = enumerator3.Current;
						if (CS_0024_003C_003E8__locals1.option.Subitems != null && CS_0024_003C_003E8__locals1.option.Subitems.Count > 0)
						{
							using List<ModuurnXMLObjects.Subitem>.Enumerator enumerator4 = CS_0024_003C_003E8__locals1.option.Subitems.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								_003C_003Ec__DisplayClass2_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass2_3();
								CS_0024_003C_003E8__locals2.subitem = enumerator4.Current;
								if (CS_0024_003C_003E8__locals2.subitem.Id != null)
								{
									Item item2 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals2.subitem.Id.Trim()).FirstOrDefault();
									if (item2 == null)
									{
										item2 = smethod_2();
										item2.ItemName = CS_0024_003C_003E8__locals1.option.Name;
										item2.ItemPrice = smethod_1(CS_0024_003C_003E8__locals1.option.Price);
									}
									list3.Add(item2);
								}
							}
						}
						else
						{
							Item item2 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals1.option.Id).FirstOrDefault();
							if (item2 == null)
							{
								item2 = smethod_2();
								item2.ItemName = CS_0024_003C_003E8__locals1.option.Name;
								item2.ItemPrice = smethod_1(CS_0024_003C_003E8__locals1.option.Price);
							}
							list3.Add(item2);
						}
					}
				}
			}
			List<Order> list4 = new List<Order>();
			DateTime now = DateTime.Now;
			string text = null;
			using (List<ModuurnXMLObjects.Item>.Enumerator enumerator2 = order.Items.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass2_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass2_4();
					CS_0024_003C_003E8__locals3.mItem = enumerator2.Current;
					_003C_003Ec__DisplayClass2_5 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass2_5();
					Item item3 = null;
					Item item4 = null;
					num5 = (short)(num5 + 1);
					CS_0024_003C_003E8__locals4.Ids = ((CS_0024_003C_003E8__locals3.mItem.Id != null) ? CS_0024_003C_003E8__locals3.mItem.Id.Trim().Split('|') : "".Split('|'));
					if (CS_0024_003C_003E8__locals4.Ids.Length > 1)
					{
						item4 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals4.Ids[0].Trim()).FirstOrDefault();
						if (item4 == null)
						{
							item4 = smethod_2();
							item4.ItemName = CS_0024_003C_003E8__locals3.mItem.Name;
						}
						item4.ItemPrice = smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
						list3.Add(item4);
						item3 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals4.Ids[1].Trim()).FirstOrDefault();
						item3.ItemPrice = smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
						list3.Add(item4);
						foreach (ModuurnXMLObjects.Option option in CS_0024_003C_003E8__locals3.mItem.Options)
						{
							option.Type_id = "1";
						}
						CS_0024_003C_003E8__locals3.mItem.Options.Add(new ModuurnXMLObjects.Option
						{
							Id = item3.Barcode,
							Group_name = ((item3.ItemsInGroups.FirstOrDefault() != null) ? item3.ItemsInGroups.FirstOrDefault().Group.GroupName : "Uncategorized"),
							Name = item3.ItemName,
							Price = "0",
							Quantity = CS_0024_003C_003E8__locals3.mItem.Quantity,
							Type_id = "0"
						});
					}
					else
					{
						if (list3 == null || list3.Count() <= 0 || CS_0024_003C_003E8__locals3.mItem.Id == null)
						{
							continue;
						}
						item4 = list3.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals3.mItem.Id.Trim()).FirstOrDefault();
						item4.ItemPrice = smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
					}
					Order order2 = new Order();
					order2.OrderId = Guid.NewGuid();
					order2.OrderNumber = CS_0024_003C_003E8__locals7.orderNumber;
					order2.OrderType = pickUpOnline;
					order2.Source = "Moduurn Online Order";
					order2.Customer = client_phone;
					order2.CustomerInfoName = customerInfoName;
					order2.CustomerInfo = client_address;
					order2.CustomerID = 0;
					order2.DateCreated = now.AddMilliseconds(num3 * 100);
					order2.DatePaid = datePaid;
					order2.DateFilled = dateFilled;
					order2.DateRefunded = dateRefunded;
					order2.Void = false;
					order2.Paid = flag;
					order2.Notified = false;
					order2.SortOrder = num6;
					num6 = (short)(num6 + 1);
					order2.ItemBarcode = item4.Barcode;
					order2.ItemID = item4.ItemID;
					order2.ItemName = item4.ItemName;
					order2.ItemPrice = smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
					order2.ItemSellPrice = smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
					order2.ItemCost = item4.ItemCost;
					order2.Qty = smethod_1(CS_0024_003C_003E8__locals3.mItem.Quantity);
					order2.StationID = item4.StationID;
					text = item4.StationID;
					order2.Discount = smethod_1(CS_0024_003C_003E8__locals3.mItem.Item_discount);
					order2.DiscountDesc = ((smethod_1(CS_0024_003C_003E8__locals3.mItem.Item_discount) > 0m) ? ("item=" + CS_0024_003C_003E8__locals3.mItem.Item_discount) : string.Empty);
					order2.SubTotal = smethod_1(CS_0024_003C_003E8__locals3.mItem.Quantity) * smethod_1(CS_0024_003C_003E8__locals3.mItem.Price);
					order2.TipAmount = num2;
					if (num2 > 0m)
					{
						order2.TipDesc = TipTypes.Card + "=" + num2.ToString("0.##") + "|";
					}
					order2.PaymentMethods = paymentMethods;
					order2.ComboID = num5;
					order2.OrderOnHoldTime = orderOnHoldTime;
					order2.FulfillmentAt = value;
					order2.ItemIdentifier = "MainItem";
					order2.SeatNum = "0";
					order2.Synced = true;
					order2.FlagID = 1;
					if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
					{
						order2.FlagID = 0;
					}
					order2.LastSynced = DateTime.Now;
					order2.ItemCourse = ItemCourses.Uncategorized;
					order2.CreatedByTerminalID = currentTerminalID;
					try
					{
						order2.GroupName = item4.ItemsInGroups.FirstOrDefault().Group.GroupName;
					}
					catch
					{
						order2.GroupName = "Uncategorized";
					}
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals3.mItem.Instructions))
					{
						order2.Instructions = CS_0024_003C_003E8__locals3.mItem.Instructions;
					}
					else
					{
						order2.Instructions = string.Empty;
					}
					order2.OrderNotes = instructions;
					item4.InventoryCount = smethod_1(CS_0024_003C_003E8__locals3.mItem.Quantity);
					ItemTaxDetails itemTaxDetailsWithRounding = TaxMethods.GetItemTaxDetailsWithRounding(list3, item4, rounding);
					order2.TaxTotal = itemTaxDetailsWithRounding.TaxValue;
					order2.TaxDesc = itemTaxDetailsWithRounding.TaxDesc;
					rounding = itemTaxDetailsWithRounding.Rounding;
					order2.Total = order2.SubTotal + order2.TaxTotal;
					num += order2.Total;
					list4.Add(order2);
					num3 = (short)(num3 + 1);
					using (IEnumerator<ModuurnXMLObjects.Option> enumerator5 = CS_0024_003C_003E8__locals3.mItem.Options.OrderBy((ModuurnXMLObjects.Option x) => x.Type).GetEnumerator())
					{
						while (enumerator5.MoveNext())
						{
							_003C_003Ec__DisplayClass2_6 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass2_6();
							CS_0024_003C_003E8__locals5.mOption = enumerator5.Current;
							if (CS_0024_003C_003E8__locals5.mOption.Subitems != null && CS_0024_003C_003E8__locals5.mOption.Subitems.Count > 0)
							{
								using List<ModuurnXMLObjects.Subitem>.Enumerator enumerator4 = CS_0024_003C_003E8__locals5.mOption.Subitems.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									_003C_003Ec__DisplayClass2_7 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass2_7();
									CS_0024_003C_003E8__locals6.subitem = enumerator4.Current;
									if (CS_0024_003C_003E8__locals6.subitem.Id != null)
									{
										Item item5 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals6.subitem.Id.Trim()).FirstOrDefault();
										if (item5 == null)
										{
											item5 = smethod_2();
											item5.ItemName = CS_0024_003C_003E8__locals6.subitem.Name;
										}
										item5.ItemPrice = smethod_1(CS_0024_003C_003E8__locals6.subitem.Price);
										ModuurnOptionObject moduurnOptionObject = new ModuurnOptionObject();
										moduurnOptionObject.Id = CS_0024_003C_003E8__locals6.subitem.Id.Trim();
										moduurnOptionObject.Price = CS_0024_003C_003E8__locals6.subitem.Price;
										moduurnOptionObject.Quantity = CS_0024_003C_003E8__locals6.subitem.Quantity;
										Order order3 = new Order();
										order3.OrderId = Guid.NewGuid();
										order3.OrderNumber = CS_0024_003C_003E8__locals7.orderNumber;
										order3.OrderType = pickUpOnline;
										order3.Source = "Moduurn Online Order";
										order3.Customer = client_phone;
										order3.CustomerInfoName = customerInfoName;
										order3.CustomerInfo = client_address;
										order3.CustomerID = 0;
										order3.DateCreated = now.AddMilliseconds(num3 * 100);
										order3.DatePaid = datePaid;
										order3.DateFilled = dateFilled;
										order3.DateRefunded = dateRefunded;
										order3.Void = false;
										order3.Paid = flag;
										order3.Notified = false;
										order3.SortOrder = num6;
										num6 = (short)(num6 + 1);
										order3.ItemBarcode = item5.Barcode;
										order3.ItemID = item5.ItemID;
										order3.ItemName = "OPT: " + item5.ItemName;
										order3.ItemPrice = item5.ItemPrice;
										order3.ItemSellPrice = smethod_1(moduurnOptionObject.Price);
										order3.ItemCost = item5.ItemCost;
										order3.Qty = smethod_1(moduurnOptionObject.Quantity);
										order3.Discount = 0m;
										order3.DiscountDesc = string.Empty;
										order3.SubTotal = order3.Qty * order3.ItemSellPrice;
										order3.TipAmount = num2;
										order3.PaymentMethods = paymentMethods;
										order3.ComboID = num5;
										order3.OrderOnHoldTime = orderOnHoldTime;
										order3.FulfillmentAt = value;
										order3.ItemIdentifier = "OptionItem";
										if (text != null && (item5.ItemName.ToUpper() == "SMALL" || item5.ItemName.ToUpper() == "MEDIUM" || item5.ItemName.ToUpper() == "LARGE"))
										{
											order3.StationID = text;
											text = null;
										}
										else
										{
											order3.StationID = item5.StationID;
										}
										order3.SeatNum = "0";
										order3.Synced = true;
										order3.FlagID = 1;
										if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
										{
											order3.FlagID = 0;
										}
										order3.LastSynced = DateTime.Now;
										order3.ItemCourse = ItemCourses.Uncategorized;
										try
										{
											order3.GroupName = item5.ItemsInGroups.FirstOrDefault().Group.GroupName;
										}
										catch
										{
											order2.GroupName = "Uncategorized";
										}
										item5.InventoryCount = order3.Qty;
										ItemTaxDetails itemTaxDetailsWithRounding2 = TaxMethods.GetItemTaxDetailsWithRounding(list3, item5, rounding);
										order3.TaxTotal = itemTaxDetailsWithRounding2.TaxValue;
										order3.TaxDesc = itemTaxDetailsWithRounding2.TaxDesc;
										rounding = itemTaxDetailsWithRounding.Rounding;
										order3.Total = order3.SubTotal + order3.TaxTotal;
										order3.CreatedByTerminalID = currentTerminalID;
										num += order3.Total;
										list4.Add(order3);
										num3 = (short)(num3 + 1);
									}
								}
							}
							else if (CS_0024_003C_003E8__locals5.mOption.Id != null)
							{
								Item item5 = source.Where((Item x) => x.Barcode == CS_0024_003C_003E8__locals5.mOption.Id.Trim()).FirstOrDefault();
								if (item5 == null)
								{
									item5 = smethod_2();
									item5.ItemName = CS_0024_003C_003E8__locals5.mOption.Name;
								}
								item5.ItemPrice = smethod_1(CS_0024_003C_003E8__locals5.mOption.Price);
								ModuurnOptionObject moduurnOptionObject = new ModuurnOptionObject();
								moduurnOptionObject.Id = CS_0024_003C_003E8__locals5.mOption.Id.Trim();
								moduurnOptionObject.Price = CS_0024_003C_003E8__locals5.mOption.Price;
								moduurnOptionObject.Quantity = CS_0024_003C_003E8__locals5.mOption.Quantity;
								Order order4 = new Order();
								order4.OrderId = Guid.NewGuid();
								order4.OrderNumber = CS_0024_003C_003E8__locals7.orderNumber;
								order4.OrderType = pickUpOnline;
								order4.Source = "Moduurn Online Order";
								order4.Customer = client_phone;
								order4.CustomerInfoName = customerInfoName;
								order4.CustomerInfo = client_address;
								order4.CustomerID = 0;
								order4.DateCreated = now.AddMilliseconds(num3 * 100);
								order4.DatePaid = datePaid;
								order4.DateFilled = dateFilled;
								order4.DateRefunded = dateRefunded;
								order4.Void = false;
								order4.Paid = flag;
								order4.Notified = false;
								order4.SortOrder = num6;
								num6 = (short)(num6 + 1);
								order4.ItemBarcode = item5.Barcode;
								order4.ItemID = item5.ItemID;
								order4.ItemName = "OPT: " + item5.ItemName;
								order4.ItemPrice = item5.ItemPrice;
								order4.ItemSellPrice = smethod_1(moduurnOptionObject.Price);
								order4.ItemCost = item5.ItemCost;
								order4.Qty = smethod_1(moduurnOptionObject.Quantity);
								order4.StationID = item5.StationID;
								order4.Discount = 0m;
								order4.DiscountDesc = string.Empty;
								order4.SubTotal = order4.Qty * order4.ItemSellPrice;
								order4.TipAmount = num2;
								order4.PaymentMethods = paymentMethods;
								order4.ComboID = num5;
								order4.OrderOnHoldTime = orderOnHoldTime;
								order4.FulfillmentAt = value;
								order4.ItemIdentifier = "OptionItem";
								order4.SeatNum = "0";
								order4.Synced = true;
								order4.FlagID = 1;
								if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
								{
									order4.FlagID = 0;
								}
								order4.LastSynced = DateTime.Now;
								order4.ItemCourse = ItemCourses.Uncategorized;
								try
								{
									order4.GroupName = item5.ItemsInGroups.FirstOrDefault().Group.GroupName;
								}
								catch
								{
									order2.GroupName = "Uncategorized";
								}
								item5.InventoryCount = order4.Qty;
								ItemTaxDetails itemTaxDetailsWithRounding3 = TaxMethods.GetItemTaxDetailsWithRounding(list3, item5, rounding);
								order4.TaxTotal = itemTaxDetailsWithRounding3.TaxValue;
								order4.TaxDesc = itemTaxDetailsWithRounding3.TaxDesc;
								rounding = itemTaxDetailsWithRounding.Rounding;
								order4.Total = order4.SubTotal + order4.TaxTotal;
								order4.CreatedByTerminalID = currentTerminalID;
								num += order4.Total;
								list4.Add(order4);
								num3 = (short)(num3 + 1);
							}
						}
					}
					num5 = (short)(num5 + 1);
				}
			}
			if (num4 > 0m)
			{
				Order order5 = new Order();
				order5.OrderId = Guid.NewGuid();
				order5.OrderNumber = CS_0024_003C_003E8__locals7.orderNumber;
				order5.OrderType = pickUpOnline;
				order5.Source = "Moduurn Online Order";
				order5.Customer = client_phone;
				order5.CustomerInfoName = customerInfoName;
				order5.CustomerInfo = client_address;
				order5.CustomerID = 0;
				order5.DateCreated = now.AddMilliseconds(num3 * 100);
				order5.DatePaid = datePaid;
				order5.DateFilled = dateFilled;
				order5.DateRefunded = dateRefunded;
				order5.Void = false;
				order5.Paid = flag;
				order5.Notified = false;
				order5.SortOrder = 0;
				order5.ItemID = -999;
				order5.ItemName = "DELIVERY FEE";
				order5.ItemPrice = num4;
				order5.ItemSellPrice = num4;
				order5.ItemCost = 0m;
				order5.Qty = 1m;
				order5.StationID = null;
				order5.Discount = 0m;
				order5.DiscountDesc = string.Empty;
				order5.SubTotal = num4;
				order5.TipAmount = 0m;
				order5.PaymentMethods = paymentMethods;
				order5.ComboID = 0;
				order5.OrderOnHoldTime = orderOnHoldTime;
				order5.FulfillmentAt = value;
				order5.ItemIdentifier = "MainItem";
				order5.SeatNum = "0";
				order5.Synced = false;
				order5.FlagID = 1;
				if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
				{
					order5.FlagID = 0;
				}
				order5.LastSynced = DateTime.Now;
				order5.ItemCourse = ItemCourses.Uncategorized;
				order5.CreatedByTerminalID = currentTerminalID;
				list3.FirstOrDefault().InventoryCount = 1m;
				ItemTaxDetails itemTaxDetailsWithRounding4 = TaxMethods.GetItemTaxDetailsWithRounding(list3, list3.FirstOrDefault(), rounding);
				order5.TaxTotal = itemTaxDetailsWithRounding4.TaxValue;
				order5.TaxDesc = itemTaxDetailsWithRounding4.TaxDesc;
				rounding = itemTaxDetailsWithRounding4.Rounding;
				order5.Total = order5.SubTotal + order5.TaxTotal;
				order5.GroupName = "Uncategorized";
				num += order5.Total;
				list4.Add(order5);
				num3 = (short)(num3 + 1);
			}
			list.Add(new OrderHeader
			{
				Source = "Moduurn Online Order",
				Customer = client_phone,
				CustomerInfo = client_address,
				CustomerInfoName = customerInfoName,
				isPaid = flag,
				OrderNumber = CS_0024_003C_003E8__locals7.orderNumber,
				OrderType = pickUpOnline,
				ItemCount = num3
			});
			foreach (Order item7 in list4)
			{
				if (flag)
				{
					item7.PaymentMethods = "MODUURN=" + (num + num2).ToString("0.00") + "|";
				}
				else
				{
					item7.PaymentMethods = "SAVED ORDER";
				}
			}
			item6.DateProcessed = DateTime.Now;
			gClass.Orders.InsertAllOnSubmit(list4);
			Helper.SubmitChangesWithCatch(gClass);
		}
		SyncMethods.WriteToSyncLog("Moduurn: Processing orders completed.", "OnlineOrderSync_");
		return list;
	}

	private static decimal smethod_1(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0.RemoveAllNonNumeric()))
		{
			return string_0.ToDecimalWithCleanUp();
		}
		return 0m;
	}

	private static Item smethod_2()
	{
		GClass6 gClass = new GClass6();
		Item item = gClass.Items.Where((Item a) => a.ItemName == ConstantItems.Custom).FirstOrDefault();
		if (item == null)
		{
			List<string> values = gClass.Stations.Select((Station x) => x.StationID.ToString()).ToList();
			string stationID = string.Join(",", values);
			item = new Item
			{
				Active = true,
				Synced = true,
				ItemName = "CUSTOM",
				AllowCustomPrice = false,
				Barcode = "",
				DisableSoldOutItems = false,
				ItemClassification = ItemClassifications.Product,
				ItemColor = "150,166,166",
				ItemCourse = ItemCourses.Uncategorized,
				ItemPrice = 0m,
				ItemTypeID = 1,
				LoyaltyRedemption = true,
				MaxFreeOptions = 0,
				MinFreeOptions = 0,
				StationID = stationID,
				Taxable = true,
				TaxRuleID = 9,
				TrackInventory = false,
				UOMID = 1
			};
			gClass.Items.InsertOnSubmit(item);
			Helper.SubmitChangesWithCatch(gClass);
		}
		return item;
	}
}
