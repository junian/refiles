using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Data;

namespace CorePOS;

public static class TapMangoHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public decimal subtotalAmount;

		public string pt;

		public string orderNumber;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public int customerId;

		public _003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass3_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CProcessTapMangoLoyalty_003Eb__2()
		{
			TapMangoMethods.ProcessPayment(customerId, CS_0024_003C_003E8__locals1.subtotalAmount, CS_0024_003C_003E8__locals1.pt);
			GClass6 gClass = new GClass6();
			GiftCardTransactionLog entity = new GiftCardTransactionLog
			{
				OrderNumber = CS_0024_003C_003E8__locals1.orderNumber,
				DateCreated = DateTime.Now,
				Type = "reponse",
				Data = customerId.ToString(),
				ProcessorName = "TapMango".ToUpper() + " LOYALTY CARD EARNED"
			};
			gClass.GiftCardTransactionLogs.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static decimal DiscountAmount;

	public static long CustomerId;

	public static string RewardCode;

	public static bool ProcessTapMangoLoyalty(Form form, string pt, decimal subtotalAmount = 0m, string orderNumber = "", decimal selectedItemAmount = 0m)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.subtotalAmount = subtotalAmount;
		_003C_003Ec__DisplayClass3_.pt = pt;
		_003C_003Ec__DisplayClass3_.orderNumber = orderNumber;
		string value = "";
		CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
		if (cardProcessorSettingActiveOnly != null)
		{
			value = cardProcessorSettingActiveOnly.ApiKey;
		}
		if (string.IsNullOrEmpty(value))
		{
			return true;
		}
		Dictionary<string, string> itemListWithId = smethod_0().ToDictionary((ActiveCustomerPayObject a) => a.customerId.ToString(), (ActiveCustomerPayObject a) => a.CustomerName);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
		MemoryLoadedObjects.ItemSelector.LoadForm(null, _withCustom: false, "Select TapMango Customer", _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: false, itemListWithId, smethod_0);
		if (MemoryLoadedObjects.ItemSelector.ShowDialog(form) == DialogResult.OK)
		{
			_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_1();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass3_;
			CS_0024_003C_003E8__locals0.customerId = Convert.ToInt32(MemoryLoadedObjects.ItemSelector.SingleSelectedKey);
			if (CS_0024_003C_003E8__locals0.customerId == 0)
			{
				return true;
			}
			if (form.Name != "frmPay")
			{
				DiscountAmount = default(decimal);
				CustomerId = CS_0024_003C_003E8__locals0.customerId;
				RewardCode = string.Empty;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				TapMangoCustomerResponse customerById = TapMangoMethods.GetCustomerById(CS_0024_003C_003E8__locals0.customerId);
				if (customerById != null && customerById.data != null && customerById.data.rewards.Count > 0)
				{
					dictionary.Add("0", "None");
					foreach (TapMangoCustomerRewards reward in customerById.data.rewards)
					{
						if (reward.name.Contains("$"))
						{
							dictionary.Add(reward.code, reward.name + " - " + reward.pointCost + " points");
						}
					}
					bool flag = true;
					do
					{
						flag = true;
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.ItemSelector();
						MemoryLoadedObjects.ItemSelector.LoadForm(null, _withCustom: false, "Select TapMango Reward", _IsMultipleSelect: false, _autoClose: false, _sameReasonForAll: false, dictionary);
						if (MemoryLoadedObjects.ItemSelector.ShowDialog() == DialogResult.OK)
						{
							if (!(MemoryLoadedObjects.ItemSelector.SingleSelectedKey != "0"))
							{
								continue;
							}
							DiscountObject discountObject = smethod_1(MemoryLoadedObjects.ItemSelector.SingleSelectedItem, MemoryLoadedObjects.ItemSelector.SingleSelectedKey);
							if (discountObject.DiscountType == DiscountTypes.Percentage)
							{
								if (selectedItemAmount == 0m)
								{
									new NotificationLabel(form, "Please select an item(drink) to discount.", NotificationTypes.Warning).Show();
									DiscountAmount = default(decimal);
									flag = false;
									continue;
								}
								DiscountAmount = selectedItemAmount * (discountObject.Amount / 100m);
							}
							RewardCode = MemoryLoadedObjects.ItemSelector.SingleSelectedKey;
							if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.subtotalAmount < DiscountAmount)
							{
								new NotificationLabel(form, "Subtotal amount cannot be less than the discount amount.", NotificationTypes.Warning).Show();
								DiscountAmount = default(decimal);
								flag = false;
								continue;
							}
							if (customerById.data.points.Value < customerById.data.rewards.Where((TapMangoCustomerRewards a) => a.code == MemoryLoadedObjects.ItemSelector.SingleSelectedKey).First().pointCost)
							{
								new NotificationLabel(form, "Not enough points.", NotificationTypes.Warning).Show();
								DiscountAmount = default(decimal);
								flag = false;
								continue;
							}
							return true;
						}
						return false;
					}
					while (!flag);
				}
				return false;
			}
			if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.subtotalAmount > 0m && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.pt))
			{
				new Thread((ThreadStart)delegate
				{
					TapMangoMethods.ProcessPayment(CS_0024_003C_003E8__locals0.customerId, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.subtotalAmount, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.pt);
					GClass6 gClass = new GClass6();
					GiftCardTransactionLog entity = new GiftCardTransactionLog
					{
						OrderNumber = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.orderNumber,
						DateCreated = DateTime.Now,
						Type = "reponse",
						Data = CS_0024_003C_003E8__locals0.customerId.ToString(),
						ProcessorName = "TapMango".ToUpper() + " LOYALTY CARD EARNED"
					};
					gClass.GiftCardTransactionLogs.InsertOnSubmit(entity);
					Helper.SubmitChangesWithCatch(gClass);
				}).Start();
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool RedeemLoyalty()
	{
		if (!string.IsNullOrEmpty(RewardCode) && CustomerId != 0L && !(DiscountAmount == 0m))
		{
			TapMangoEventSuccessResponse tapMangoEventSuccessResponse = TapMangoMethods.RedeemReward(CustomerId, RewardCode);
			if (tapMangoEventSuccessResponse != null && tapMangoEventSuccessResponse.data != null && tapMangoEventSuccessResponse.data.type == "invalid_request")
			{
				return false;
			}
			return true;
		}
		return true;
	}

	private static List<ActiveCustomerPayObject> smethod_0()
	{
		string value = "";
		CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
		if (cardProcessorSettingActiveOnly != null)
		{
			value = cardProcessorSettingActiveOnly.ApiKey;
		}
		if (string.IsNullOrEmpty(value))
		{
			return new List<ActiveCustomerPayObject>();
		}
		List<ActiveCustomerPayObject> list = new List<ActiveCustomerPayObject>();
		list.Add(new ActiveCustomerPayObject
		{
			customerId = 0L,
			CustomerName = "None"
		});
		ActiveCustomerListResponse activeCustomerByLocation = TapMangoMethods.GetActiveCustomerByLocation(Convert.ToInt32(cardProcessorSettingActiveOnly.Id));
		if (activeCustomerByLocation != null && activeCustomerByLocation.data != null && activeCustomerByLocation.data.Count > 0)
		{
			foreach (ActiveCustomer datum in activeCustomerByLocation.data)
			{
				TapMangoCustomerResponse customerById = TapMangoMethods.GetCustomerById(datum.customerId);
				list.Add(new ActiveCustomerPayObject
				{
					deviceName = datum.deviceName,
					customerId = datum.customerId,
					deviceId = datum.deviceId,
					CustomerName = ((customerById == null || customerById.data == null) ? "" : (customerById.data.name + "-" + customerById.data.phone))
				});
			}
			return list;
		}
		return list;
	}

	private static DiscountObject smethod_1(string string_0, string string_1)
	{
		DiscountObject discountObject = new DiscountObject();
		discountObject.Amount = 0m;
		discountObject.DiscountType = DiscountTypes.DollarAmount;
		if (!(string_1 == "TM3213R00019931") && !string_0.ToUpper().Contains("$1"))
		{
			if (!(string_1 == "TM3213R00019932") && !string_0.ToUpper().Contains("$2"))
			{
				if (!(string_1 == "TM3213R00019933") && !string_0.ToUpper().Contains("$3"))
				{
					if (!(string_1 == "TM3213R00019934") && !string_0.ToUpper().Contains("$4"))
					{
						if (!(string_1 == "TM3213R00019935") && !string_0.ToUpper().Contains("$5"))
						{
							if (string_0.ToUpper().Contains("50%"))
							{
								discountObject.Amount = 50m;
								discountObject.DiscountType = DiscountTypes.Percentage;
							}
							else if (string_0.ToUpper().Contains("100%") || string_0.ToUpper().Contains("FREE"))
							{
								discountObject.Amount = 100m;
								discountObject.DiscountType = DiscountTypes.Percentage;
							}
						}
						else
						{
							discountObject.Amount = 5m;
							discountObject.DiscountType = DiscountTypes.DollarAmount;
						}
					}
					else
					{
						discountObject.Amount = 4m;
						discountObject.DiscountType = DiscountTypes.DollarAmount;
					}
				}
				else
				{
					discountObject.Amount = 3m;
					discountObject.DiscountType = DiscountTypes.DollarAmount;
				}
			}
			else
			{
				discountObject.Amount = 2m;
				discountObject.DiscountType = DiscountTypes.DollarAmount;
			}
		}
		else
		{
			discountObject.Amount = 1m;
			discountObject.DiscountType = DiscountTypes.DollarAmount;
		}
		return discountObject;
	}

	static TapMangoHelper()
	{
		Class26.Ggkj0JxzN9YmC();
		DiscountAmount = default(decimal);
		CustomerId = 0L;
		RewardCode = "";
	}
}
