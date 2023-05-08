using System;
using System.IO;
using System.Net;
using CorePOS.Business.Objects;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods.PaymentProcessors;

public static class TapMangoMethods
{
	public static TapMangoLocationListResponse GetLocations(string tapMangoApi)
	{
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://openapi.tapmango.com:443/api/v1/Locations");
			obj.Method = "GET";
			obj.Headers.Add(HttpRequestHeader.Authorization, "ApiKey " + tapMangoApi);
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<TapMangoLocationListResponse>(streamReader.ReadToEnd());
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new TapMangoLocationListResponse
			{
				message = "ERROR: " + ex.Message
			};
		}
	}

	public static ActiveCustomerListResponse GetActiveCustomerByLocation(int locationId)
	{
		try
		{
			string text = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				text = cardProcessorSettingActiveOnly.ApiKey;
			}
			if (!string.IsNullOrEmpty(text))
			{
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://openapi.tapmango.com:443/api/v1/ActiveCustomers?locationId=" + locationId);
				obj.Method = "GET";
				obj.Headers.Add(HttpRequestHeader.Authorization, "ApiKey " + text);
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<ActiveCustomerListResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new ActiveCustomerListResponse
			{
				message = "ERROR: " + ex.Message
			};
		}
	}

	public static TapMangoCustomerResponse GetCustomerById(long customerId)
	{
		try
		{
			string text = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				text = cardProcessorSettingActiveOnly.ApiKey;
			}
			if (!string.IsNullOrEmpty(text))
			{
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://openapi.tapmango.com:443/api/v1/Customers/" + customerId + "?loadRelations=rewards");
				obj.Method = "GET";
				obj.Headers.Add(HttpRequestHeader.Authorization, "ApiKey " + text);
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)obj.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<TapMangoCustomerResponse>(streamReader.ReadToEnd());
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			return new TapMangoCustomerResponse
			{
				message = "ERROR: " + ex.Message
			};
		}
	}

	public static TapMangoEventSuccessResponse RedeemReward(long customerId, string rewardCode)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		try
		{
			string text = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				text = cardProcessorSettingActiveOnly.ApiKey;
			}
			if (!string.IsNullOrEmpty(text))
			{
				var anon = new
				{
					code = rewardCode
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://openapi.tapmango.com:443/api/v1/customers/" + customerId + "/events/Redeem");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "ApiKey " + text);
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
					streamWriter.Write(value);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode != HttpStatusCode.BadRequest && httpWebResponse.StatusCode != HttpStatusCode.NotFound)
				{
					using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					return JsonConvert.DeserializeObject<TapMangoEventSuccessResponse>(streamReader.ReadToEnd());
				}
				using StreamReader streamReader2 = new StreamReader(httpWebResponse.GetResponseStream());
				TapMangoErrorResponse tapMangoErrorResponse = JsonConvert.DeserializeObject<TapMangoErrorResponse>(streamReader2.ReadToEnd());
				TapMangoEventSuccessResponse tapMangoEventSuccessResponse = new TapMangoEventSuccessResponse();
				tapMangoEventSuccessResponse.data = new TapMangoSuccess();
				tapMangoEventSuccessResponse.data.type = tapMangoErrorResponse.type;
				tapMangoEventSuccessResponse.data.status = tapMangoErrorResponse.message;
				return tapMangoEventSuccessResponse;
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			TapMangoEventSuccessResponse tapMangoEventSuccessResponse2 = new TapMangoEventSuccessResponse();
			tapMangoEventSuccessResponse2.data = new TapMangoSuccess();
			tapMangoEventSuccessResponse2.data.type = "invalid_request";
			tapMangoEventSuccessResponse2.data.status = "ERROR: " + ex.Message;
			return tapMangoEventSuccessResponse2;
		}
	}

	public static TapMangoEventSuccessResponse ProcessPayment(long customerId, decimal amount, string method)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		try
		{
			string text = "";
			CardProcessorObject cardProcessorSettingActiveOnly = SettingsHelper.GetCardProcessorSettingActiveOnly("TapMango", "loyalty_card_json");
			if (cardProcessorSettingActiveOnly != null)
			{
				text = cardProcessorSettingActiveOnly.ApiKey;
			}
			if (!string.IsNullOrEmpty(text))
			{
				var anon = new { amount, method };
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://openapi.tapmango.com:443/api/v1/customers/" + customerId + "/events/Payment");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "ApiKey " + text);
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)anon, (Formatting)1, val);
					streamWriter.Write(value);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode != HttpStatusCode.BadRequest && httpWebResponse.StatusCode != HttpStatusCode.NotFound)
				{
					using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
					return JsonConvert.DeserializeObject<TapMangoEventSuccessResponse>(streamReader.ReadToEnd());
				}
				using StreamReader streamReader2 = new StreamReader(httpWebResponse.GetResponseStream());
				TapMangoErrorResponse tapMangoErrorResponse = JsonConvert.DeserializeObject<TapMangoErrorResponse>(streamReader2.ReadToEnd());
				TapMangoEventSuccessResponse tapMangoEventSuccessResponse = new TapMangoEventSuccessResponse();
				tapMangoEventSuccessResponse.data = new TapMangoSuccess();
				tapMangoEventSuccessResponse.data.type = tapMangoErrorResponse.type;
				tapMangoEventSuccessResponse.data.status = tapMangoErrorResponse.message;
				return tapMangoEventSuccessResponse;
			}
			return null;
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			TapMangoEventSuccessResponse tapMangoEventSuccessResponse2 = new TapMangoEventSuccessResponse();
			tapMangoEventSuccessResponse2.data = new TapMangoSuccess();
			tapMangoEventSuccessResponse2.data.type = "invalid_request";
			tapMangoEventSuccessResponse2.data.status = "ERROR: " + ex.Message;
			return tapMangoEventSuccessResponse2;
		}
	}
}
