using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public static class SettingsHelper
{
	public static class OnlineOrderSettings
	{
		public static OnlineOrderSettingObject Get(string provider)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass0_0();
			CS_0024_003C_003E8__locals0.provider = provider;
			if (HipposSettings.Count == 0)
			{
				SetAllSettings();
			}
			return (from a in JsonConvert.DeserializeObject<List<OnlineOrderSettingObject>>(HipposSettings.Where((SettingsObject a) => a.Key == "online_order_sync").First().Value)
				where a.Provider == CS_0024_003C_003E8__locals0.provider
				select a).FirstOrDefault();
		}

		public static List<OnlineOrderSettingObject> GetProviders(bool onlyActive = false)
		{
			if (HipposSettings.Count == 0)
			{
				SetAllSettings();
			}
			List<OnlineOrderSettingObject> list = JsonConvert.DeserializeObject<List<OnlineOrderSettingObject>>(HipposSettings.Where((SettingsObject a) => a.Key == "online_order_sync").First().Value);
			if (onlyActive)
			{
				return list.Where((OnlineOrderSettingObject a) => a.isActive).ToList();
			}
			return list;
		}

		public static void Save(string Provider, string Url, string ApiKey, int PollingInterval, bool isActive)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals0.Provider = Provider;
			if (HipposSettings.Count == 0)
			{
				SetAllSettings();
			}
			List<OnlineOrderSettingObject> list = JsonConvert.DeserializeObject<List<OnlineOrderSettingObject>>(HipposSettings.Where((SettingsObject a) => a.Key == "online_order_sync").First().Value);
			OnlineOrderSettingObject onlineOrderSettingObject = list.Where((OnlineOrderSettingObject x) => x.Provider == CS_0024_003C_003E8__locals0.Provider).FirstOrDefault();
			if (onlineOrderSettingObject != null)
			{
				onlineOrderSettingObject.Url = Url;
				onlineOrderSettingObject.ApiKey = ApiKey;
				onlineOrderSettingObject.PollInterval = PollingInterval;
				onlineOrderSettingObject.isActive = isActive;
			}
			else
			{
				onlineOrderSettingObject = new OnlineOrderSettingObject
				{
					Provider = CS_0024_003C_003E8__locals0.Provider,
					Url = Url,
					ApiKey = ApiKey,
					PollInterval = PollingInterval,
					isActive = isActive
				};
				list.Add(onlineOrderSettingObject);
			}
			string value = JsonConvert.SerializeObject((object)list);
			HipposSettings.Where((SettingsObject a) => a.Key == "online_order_sync").First().Value = value;
			GClass6 gClass = new GClass6();
			gClass.Settings.Where((Setting a) => a.Key == "online_order_sync").FirstOrDefault().Value = value;
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static class DeliveryFeeSettings
	{
		public static DeliveryFeeSettingsObject GetDeliveryFeeSettings()
		{
			return JsonConvert.DeserializeObject<DeliveryFeeSettingsObject>(HipposSettings.Where((SettingsObject a) => a.Key == "delivery_fee_settings_json").First().Value);
		}

		public static void SaveDeliveryFeeSettings(DeliveryFeeSettingsObject obj)
		{
			GClass6 gClass = new GClass6();
			Setting setting = gClass.Settings.Where((Setting a) => a.Key == "delivery_fee_settings_json").FirstOrDefault();
			setting.Value = JsonConvert.SerializeObject((object)obj);
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
			HipposSettings.Where((SettingsObject a) => a.Key == "delivery_fee_settings_json").First().Value = setting.Value;
		}

		public static void TransferOldDeliveryToNewDeliverySettings()
		{
			if (string.IsNullOrEmpty(HipposSettings.Where((SettingsObject a) => a.Key == "delivery_fee_settings_json").First().Value))
			{
				decimal chargePerKM = Convert.ToDecimal(GetSettingValueByKey("delivery_fee_km"));
				decimal baseRate = Convert.ToDecimal(GetSettingValueByKey("delivery_charge"));
				decimal freeDeliveryOver = default(decimal);
				try
				{
					freeDeliveryOver = Convert.ToDecimal(GetSettingValueByKey("free_delivery_over"));
				}
				catch
				{
				}
				string settingValueByKey = GetSettingValueByKey("delivery_distance_uom");
				List<DeliveryFeeFromToPerKM> list = new List<DeliveryFeeFromToPerKM>();
				list.Add(new DeliveryFeeFromToPerKM
				{
					FromDistance = 0m,
					ToDistance = 10000m,
					ChargePerKM = chargePerKM
				});
				SaveDeliveryFeeSettings(new DeliveryFeeSettingsObject
				{
					BaseRate = baseRate,
					FreeDeliveryOver = freeDeliveryOver,
					String_0 = settingValueByKey,
					ListOfFeeCalculation = list
				});
			}
		}
	}

	public static List<SettingsObject> HipposSettings;

	[CompilerGenerated]
	private static string string_0;

	[CompilerGenerated]
	private static bool bool_0;

	[CompilerGenerated]
	private static bool bool_1;

	public static string CurrentTerminalMode
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public static bool isVoidOrderAddOn
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public static bool hasGlobalOrderHistoryAddOn
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public static void SetAllSettings()
	{
		List<SettingsObject> list = new List<SettingsObject>();
		GClass6 gClass = new GClass6();
		foreach (Setting item in gClass.Settings.Where((Setting a) => a.Key != "encrypted_prodkey_sub" && a.Key != "encrypted_subs").ToList())
		{
			list.Add(new SettingsObject
			{
				Key = item.Key,
				Value = item.Value
			});
		}
		list.Add(new SettingsObject
		{
			Key = "void_order",
			Value = (bool_0 ? "Enabled" : "Disabled")
		});
		List<Station> source = gClass.Stations.ToList();
		if (source.Where((Station x) => x.StationName.ToUpper().Contains("BAR") && x.SendToStation).Any())
		{
			list.Add(new SettingsObject
			{
				Key = "layout_show_drink_icon",
				Value = "ON"
			});
		}
		else
		{
			list.Add(new SettingsObject
			{
				Key = "layout_show_drink_icon",
				Value = "OFF"
			});
		}
		if (source.Where((Station x) => !x.StationName.ToUpper().Contains("BAR") && x.SendToStation).Any())
		{
			list.Add(new SettingsObject
			{
				Key = "layout_show_food_icon",
				Value = "ON"
			});
		}
		else
		{
			list.Add(new SettingsObject
			{
				Key = "layout_show_food_icon",
				Value = "OFF"
			});
		}
		HipposSettings = list.ToList();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal != null)
		{
			CorePOS.Data.Properties.Settings.Default["CurrentTerminalID"] = terminal.TerminalID;
		}
	}

	public static void SetSettingValueByKey(string key, string value)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.key = key;
		HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.key).First().Value = value;
		GClass6 gClass = new GClass6();
		gClass.Terminals.Where((Terminal x) => !x.SystemName.Equals(Environment.MachineName)).ToList().ForEach(delegate(Terminal a)
		{
			a.SettingsRefreshedRequired = true;
		});
		Helper.SubmitChangesWithCatch(gClass);
		LogSettingsAudit(CS_0024_003C_003E8__locals0.key, "Changed to " + value);
	}

	public static void SetSettingsFontStyleValues(string settingKeyJSON, string style, int size, string color)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.settingKeyJSON = settingKeyJSON;
		string value = JsonConvert.SerializeObject((object)new FontStyleObject
		{
			Style = style,
			Size = size,
			Color = color
		});
		HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value = value;
		GClass6 gClass = new GClass6();
		gClass.Settings.Where((Setting a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).FirstOrDefault().Value = value;
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static FontStyleObject GetSettingFontStyleValues(string settingKeyJSON)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.settingKeyJSON = settingKeyJSON;
		string value = HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value;
		if (int.TryParse(value, out var result))
		{
			return new FontStyleObject
			{
				Style = "0",
				Size = result,
				Color = "255,255,255"
			};
		}
		return JsonConvert.DeserializeObject<FontStyleObject>(value);
	}

	public static CardProcessorObject GetCardProcessorSettingActiveOnly(string processorName, string settingKeyJSON)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.settingKeyJSON = settingKeyJSON;
		CS_0024_003C_003E8__locals0.processorName = processorName;
		if (CS_0024_003C_003E8__locals0.settingKeyJSON == "gift_card_json" && GetSettingValueByKey("gift_card_payment") == "OFF")
		{
			return null;
		}
		if (CS_0024_003C_003E8__locals0.settingKeyJSON == "loyalty_card_json" && GetSettingValueByKey("loyalty_card_payment") == "OFF")
		{
			return null;
		}
		return (from a in JsonConvert.DeserializeObject<List<CardProcessorObject>>(HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value)
			where a.Processor == CS_0024_003C_003E8__locals0.processorName && a.isActive
			select a).FirstOrDefault();
	}

	public static void SetCardProcessorSetting(string settingKeyJSON, string processorName, string apiKey, string Id, bool isActive)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0.settingKeyJSON = settingKeyJSON;
		CS_0024_003C_003E8__locals0.processorName = processorName;
		List<CardProcessorObject> list = JsonConvert.DeserializeObject<List<CardProcessorObject>>(HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value);
		CardProcessorObject cardProcessorObject = list.Where((CardProcessorObject a) => a.Processor == CS_0024_003C_003E8__locals0.processorName).FirstOrDefault();
		if (cardProcessorObject != null)
		{
			cardProcessorObject.ApiKey = apiKey;
			cardProcessorObject.isActive = isActive;
			cardProcessorObject.Id = Id;
		}
		else
		{
			cardProcessorObject = new CardProcessorObject
			{
				Processor = CS_0024_003C_003E8__locals0.processorName,
				ApiKey = apiKey,
				isActive = isActive,
				Id = Id
			};
			list.Add(cardProcessorObject);
		}
		string value = JsonConvert.SerializeObject((object)list);
		HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value = value;
		GClass6 gClass = new GClass6();
		gClass.Settings.Where((Setting a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).FirstOrDefault().Value = value;
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static CardProcessorObject GetCardProcessorSetting(string processorName, string settingKeyJSON)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.settingKeyJSON = settingKeyJSON;
		CS_0024_003C_003E8__locals0.processorName = processorName;
		return (from a in JsonConvert.DeserializeObject<List<CardProcessorObject>>(HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.settingKeyJSON).First().Value)
			where a.Processor == CS_0024_003C_003E8__locals0.processorName
			select a).FirstOrDefault();
	}

	public static string GetSettingValueByKey(string key)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.key = key;
		return HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.key).FirstOrDefault()?.Value;
	}

	public static SettingsObject GetSettingByKey(string key)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.key = key;
		return HipposSettings.Where((SettingsObject a) => a.Key == CS_0024_003C_003E8__locals0.key).First();
	}

	public static List<SettingsObject> GetEoDSettings(string key)
	{
		return HipposSettings.Where((SettingsObject a) => a.Key.Contains("eodreport")).ToList();
	}

	public static void StationsSettingsUpdatedLatest()
	{
		GClass6 gClass = new GClass6();
		if (GetSettingValueByKey("station_settings_changed") == "OFF")
		{
			Station station = gClass.Stations.Where((Station a) => a.StationID == 1).FirstOrDefault();
			SettingsObject settingsObject = HipposSettings.Where((SettingsObject a) => a.Key == "printer_kitchen").FirstOrDefault();
			if (settingsObject != null)
			{
				station.PrinterName = settingsObject.Value;
			}
			SettingsObject settingsObject2 = HipposSettings.Where((SettingsObject a) => a.Key == "print_to_kitchen").FirstOrDefault();
			if (settingsObject2 != null)
			{
				station.EnablePrint = ((!(settingsObject2.Value == "OFF")) ? true : false);
			}
			SettingsObject settingsObject3 = HipposSettings.Where((SettingsObject a) => a.Key == "print_kitchen_made").FirstOrDefault();
			if (settingsObject3 != null)
			{
				station.AutoPrint = ((!(settingsObject3.Value == "OFF")) ? true : false);
			}
			SettingsObject settingsObject4 = HipposSettings.Where((SettingsObject a) => a.Key == "send_orders_kitchen").FirstOrDefault();
			if (settingsObject4 != null)
			{
				station.SendToStation = ((!(settingsObject4.Value == "OFF")) ? true : false);
			}
			Station station2 = gClass.Stations.Where((Station a) => a.StationID == 2).FirstOrDefault();
			SettingsObject settingsObject5 = HipposSettings.Where((SettingsObject a) => a.Key == "printer_bar").FirstOrDefault();
			if (settingsObject5 != null)
			{
				station2.PrinterName = settingsObject5.Value;
			}
			SettingsObject settingsObject6 = HipposSettings.Where((SettingsObject a) => a.Key == "print_to_bar").FirstOrDefault();
			if (settingsObject6 != null)
			{
				station2.EnablePrint = ((!(settingsObject6.Value == "OFF")) ? true : false);
			}
			SettingsObject settingsObject7 = HipposSettings.Where((SettingsObject a) => a.Key == "print_bar_made").FirstOrDefault();
			if (settingsObject7 != null)
			{
				station2.AutoPrint = ((!(settingsObject7.Value == "OFF")) ? true : false);
			}
			SettingsObject settingsObject8 = HipposSettings.Where((SettingsObject a) => a.Key == "send_orders_bar").FirstOrDefault();
			if (settingsObject8 != null)
			{
				station2.SendToStation = ((!(settingsObject8.Value == "OFF")) ? true : false);
			}
			Helper.SubmitChangesWithCatch(gClass);
			Setting setting = gClass.Settings.Where((Setting s) => s.Key == "station_settings_changed").FirstOrDefault();
			if (setting != null)
			{
				setting.Value = "ON";
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		if (gClass.Stations.Where((Station a) => a.SystemDefinedID.HasValue).Count() == 2 || gClass.Stations.Where((Station a) => a.StationName.ToUpper() == "NO STATION").Count() > 0)
		{
			Station station3 = gClass.Stations.Where((Station a) => a.StationName.ToUpper() == "NO STATION" || a.SystemDefinedID == (int?)2).FirstOrDefault();
			if (station3 != null)
			{
				_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
				CS_0024_003C_003E8__locals0.NoStationId = station3.StationID.ToString();
				gClass.Items.Where((Item a) => a.StationID == CS_0024_003C_003E8__locals0.NoStationId).ToList().ForEach(delegate(Item a)
				{
					a.StationID = null;
				});
				gClass.Orders.Where((Order a) => a.StationID == CS_0024_003C_003E8__locals0.NoStationId).ToList().ForEach(delegate(Order a)
				{
					a.StationID = null;
				});
				Helper.SubmitChangesWithCatch(gClass);
				gClass.Stations.DeleteOnSubmit(station3);
				Helper.SubmitChangesWithCatch(gClass);
			}
			Station station4 = gClass.Stations.Where((Station a) => a.StationName.ToUpper() == "ALL STATIONS" || a.SystemDefinedID == (int?)1).FirstOrDefault();
			if (station4 != null)
			{
				_003C_003Ec__DisplayClass23_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass23_1();
				CS_0024_003C_003E8__locals1.allStationIds = (from a in gClass.Stations
					where a.SystemDefinedID.HasValue == false
					select a.StationID).ToList();
				CS_0024_003C_003E8__locals1.AllStationId = station4.StationID.ToString();
				gClass.Items.Where((Item a) => a.StationID == CS_0024_003C_003E8__locals1.AllStationId).ToList().ForEach(delegate(Item a)
				{
					a.StationID = string.Join(",", CS_0024_003C_003E8__locals1.allStationIds);
				});
				gClass.Orders.Where((Order a) => a.StationID == CS_0024_003C_003E8__locals1.AllStationId).ToList().ForEach(delegate(Order a)
				{
					a.StationID = string.Join(",", CS_0024_003C_003E8__locals1.allStationIds);
				});
				Helper.SubmitChangesWithCatch(gClass);
				gClass.Stations.DeleteOnSubmit(station4);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		Station station5 = gClass.Stations.Where((Station a) => a.StationName == "Kitchen").FirstOrDefault();
		if (station5 != null && !station5.DisplayFontSize.HasValue)
		{
			station5.DisplayFontSize = Convert.ToInt32(GetSettingValueByKey("font_size_kitchen"));
			Helper.SubmitChangesWithCatch(gClass);
		}
		Station station6 = gClass.Stations.Where((Station a) => a.StationName == "Bar").FirstOrDefault();
		if (station6 != null && !station6.DisplayFontSize.HasValue)
		{
			station6.DisplayFontSize = Convert.ToInt32(GetSettingValueByKey("font_size_bar"));
			Helper.SubmitChangesWithCatch(gClass);
		}
		if (gClass.Stations.Where((Station a) => a.ChitFontSize.HasValue == false).Count() > 0)
		{
			foreach (Station item in gClass.Stations.Where((Station a) => a.ChitFontSize.HasValue == false))
			{
				item.ChitFontSize = 8;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		if (gClass.Stations.Where((Station a) => a.DisplayFontSize.HasValue == false).Count() <= 0)
		{
			return;
		}
		foreach (Station item2 in gClass.Stations.Where((Station a) => a.DisplayFontSize.HasValue == false))
		{
			item2.DisplayFontSize = 8;
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static void ConstantItemsUpdatedLatest()
	{
		GClass6 gClass = new GClass6();
		if (gClass.Items.Where((Item a) => a.ItemName == ConstantItems.Delivery_Fee && a.isDeleted == false).Count() > 1)
		{
			gClass.Items.Where((Item a) => a.ItemName == ConstantItems.Delivery_Fee).ToList().ForEach(delegate(Item a)
			{
				a.isDeleted = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		if (gClass.Items.Where((Item a) => a.ItemName == ConstantItems.Delivery_Fee && a.Active == true && a.isDeleted == false).Count() == 0)
		{
			int taxruleID = gClass.TaxRules.Where((TaxRule a) => a.RuleName.Contains("Default")).FirstOrDefault()?.TaxRuleId ?? 9;
			AdminMethods.addNewItem(string.Empty, ConstantItems.Delivery_Fee, 0m, 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, taxruleID, string.Empty, 0, "150,166,166", active: true, 0m, disableIfSoldOut: false, 1, trackInventory: false, ItemClassifications.Product, "", "", "Uncategorized", -1, 0, TrackExpiry: false, ApplySaleComboOption: false, AutoResetQty: false, 0m, RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m);
		}
		if (gClass.Items.Where((Item a) => a.ItemName == ConstantItems.Custom && a.Active == true && a.isDeleted == false).Count() == 0)
		{
			int taxruleID2 = gClass.TaxRules.Where((TaxRule a) => a.RuleName.Contains("Default")).FirstOrDefault()?.TaxRuleId ?? 9;
			AdminMethods.addNewItem(string.Empty, ConstantItems.Custom, 0m, 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, taxruleID2, string.Empty, 0, "150,166,166", active: true, 0m, disableIfSoldOut: false, 1, trackInventory: false, ItemClassifications.Product, "", "", "Uncategorized", -1, 0, TrackExpiry: false, ApplySaleComboOption: false, AutoResetQty: false, 0m, RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m);
		}
	}

	public static void LogSettingsAudit(string key, string Action)
	{
		GClass6 gClass = new GClass6();
		SettingsAuditLog entity = new SettingsAuditLog
		{
			Key = key,
			Comment = Action,
			DateCreated = DateTime.Now,
			Synced = false
		};
		gClass.SettingsAuditLogs.InsertOnSubmit(entity);
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static CardTransactionFeeObject GetTransactionFeeSetting(string cardType)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals0.cardType = cardType;
		return (from a in JsonConvert.DeserializeObject<List<CardTransactionFeeObject>>(HipposSettings.Where((SettingsObject a) => a.Key == "card_transaction_fee_json").First().Value)
			where a.CardType == CS_0024_003C_003E8__locals0.cardType
			select a).FirstOrDefault();
	}

	public static void SetTransactionFeeSetting(string cardType, char tender, decimal amount)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.cardType = cardType;
		List<CardTransactionFeeObject> list = JsonConvert.DeserializeObject<List<CardTransactionFeeObject>>(HipposSettings.Where((SettingsObject a) => a.Key == "card_transaction_fee_json").First().Value);
		CardTransactionFeeObject cardTransactionFeeObject = list.Where((CardTransactionFeeObject a) => a.CardType == CS_0024_003C_003E8__locals0.cardType).FirstOrDefault();
		if (cardTransactionFeeObject != null)
		{
			cardTransactionFeeObject.TenderType = tender;
			cardTransactionFeeObject.Amount = amount;
		}
		else
		{
			cardTransactionFeeObject = new CardTransactionFeeObject
			{
				CardType = CS_0024_003C_003E8__locals0.cardType,
				TenderType = tender,
				Amount = amount
			};
			list.Add(cardTransactionFeeObject);
		}
		string value = JsonConvert.SerializeObject((object)list);
		HipposSettings.Where((SettingsObject a) => a.Key == "card_transaction_fee_json").First().Value = value;
		GClass6 gClass = new GClass6();
		gClass.Settings.Where((Setting a) => a.Key == "card_transaction_fee_json").FirstOrDefault().Value = value;
		Helper.SubmitChangesWithCatch(gClass);
	}

	static SettingsHelper()
	{
		Class2.oOsq41PzvTVMr();
		HipposSettings = new List<SettingsObject>();
	}
}
