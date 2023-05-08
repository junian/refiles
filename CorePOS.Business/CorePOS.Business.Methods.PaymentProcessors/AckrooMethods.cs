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
			var value = new
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
				string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					MaxDepth = 2000
				});
				streamWriter.Write(value2);
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
			var value = new
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
				string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					MaxDepth = 2000
				});
				streamWriter.Write(value2);
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
			var value = new
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
				string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					MaxDepth = 2000
				});
				streamWriter.Write(value2);
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
			var value = new
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
				string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					MaxDepth = 2000
				});
				streamWriter.Write(value2);
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
			var value = new
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
				string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					MaxDepth = 2000
				});
				streamWriter.Write(value2);
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
				var value = new
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
					string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
					{
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
						MaxDepth = 2000
					});
					streamWriter.Write(value2);
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
				var value = new
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
					string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
					{
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
						MaxDepth = 2000
					});
					streamWriter.Write(value2);
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
				AckrooReversalRequest value = new AckrooReversalRequest
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
					string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
					{
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
						MaxDepth = 2000
					});
					streamWriter.Write(value2);
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
				var value = new
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
					string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
					{
						ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
						MaxDepth = 2000
					});
					streamWriter.Write(value2);
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
