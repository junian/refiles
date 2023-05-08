using System;
using System.IO;
using System.Net;
using CorePOS.Business.Objects;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class AckrooMethods
{
	public static string server;

	public const string normalServer = "https://api.ackroo.net";

	public const string sandBoxServer = "https://api.sandbox.ackroolabs.com";

	public static AckrooGiftCardCreateResponse ActivateCard(string cardNumber)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
			}
			var anon = new
			{
				cardnumber = cardNumber.ToString(),
				access_token = access_token,
				device_id = device_id
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/device/card/activation.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooGiftCardCreateResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardCreateResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardClearCardResponse ClearCard(string cardNumber)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
			}
			var anon = new
			{
				cardnumber = cardNumber,
				access_token = access_token,
				device_id = device_id
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/card.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "DELETE";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooGiftCardClearCardResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardClearCardResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardFUNDResponse FundCard(string cardNumber, decimal amount)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
			}
			var anon = new
			{
				amount = amount.ToString(),
				cardnumber = cardNumber,
				access_token = access_token,
				device_id = device_id
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/gift/credit.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooGiftCardFUNDResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardFUNDResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardREDEEMResponse RedeemCard(string cardNumber, decimal amount)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
			}
			var anon = new
			{
				amount = amount.ToString(),
				cardnumber = cardNumber,
				access_token = access_token,
				device_id = device_id
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/gift/debit.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooGiftCardREDEEMResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardREDEEMResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardVoidResponse VoidTransaction(string transactionNumber)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
			}
			var anon = new
			{
				transaction_number = transactionNumber,
				access_token = access_token,
				device_id = device_id
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction.json");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "DELETE";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooGiftCardVoidResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardVoidResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardFUNDResponse FundLoyaltyPoints(string cardNumber, decimal amount, string description = "")
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
				var anon = new
				{
					amount = amount.ToString(),
					cardnumber = cardNumber,
					access_token = access_token,
					device_id = device_id,
					description = description
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/loyalty/credit.json");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<AckrooGiftCardFUNDResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardFUNDResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardFUNDResponse RefundLoyaltyPoints(string cardNumber, decimal amount)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
				var anon = new
				{
					amount = amount.ToString(),
					cardnumber = cardNumber,
					access_token = access_token,
					device_id = device_id
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/loyalty/refund.json");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<AckrooGiftCardFUNDResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardFUNDResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooReversalResponse ReverseTransaction(string transactionNumber, string settingKeyJson, string cardnumber = null, string description = null, string clerk_id = null)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", settingKeyJson);
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
				AckrooReversalRequest ackrooReversalRequest = new AckrooReversalRequest
				{
					transaction_number = transactionNumber,
					access_token = access_token,
					device_id = device_id,
					cardnumber = cardnumber,
					description = description,
					clerk_id = clerk_id
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/reversal.json");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)ackrooReversalRequest, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<AckrooReversalResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooReversalResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooGiftCardREDEEMResponse RedeemLoyaltyPoints(string cardNumber, decimal amount)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		try
		{
			string device_id = "";
			string access_token = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				string apiKey = cardProcessorSettingActiveOnly.ApiKey;
				if (!string.IsNullOrEmpty(apiKey))
				{
					access_token = apiKey.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
					device_id = apiKey.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				}
				var anon = new
				{
					amount = amount.ToString(),
					cardnumber = cardNumber,
					access_token = access_token,
					device_id = device_id
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(server + "/transaction/loyalty/debit.json");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<AckrooGiftCardREDEEMResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooGiftCardREDEEMResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	public static AckrooCardResponse CheckCardBalance(string cardNumber)
	{
		try
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string empty = string.Empty;
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "gift_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				empty = cardProcessorSettingActiveOnly.ApiKey;
			}
			else
			{
				cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("Ackroo", "loyalty_card_json");
				if (cardProcessorSettingActiveOnly == null)
				{
					return null;
				}
				empty = cardProcessorSettingActiveOnly.ApiKey;
			}
			if (!string.IsNullOrEmpty(empty))
			{
				text2 = empty.Split('|')[0].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
				text = empty.Split('|')[1].Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
			}
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(server + "/device/card.json?cardnumber=" + cardNumber + "&device_id=" + text);
			obj.Method = "GET";
			obj.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + text2);
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<AckrooCardResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new AckrooCardResponse
			{
				error = "ERROR: " + ex.Message
			};
		}
	}

	static AckrooMethods()
	{
		Class2.oOsq41PzvTVMr();
		server = "https://api.ackroo.net";
	}
}
