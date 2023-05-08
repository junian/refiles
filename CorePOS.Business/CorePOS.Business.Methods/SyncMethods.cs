using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using CorePOS.Business.Enums;
using CorePOS.Business.Enums.ThirdParty;
using CorePOS.Business.Methods.ThirdPartyAPIs.OnlineOrdering;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.DataMovement;
using Newtonsoft.Json;

namespace CorePOS.Business.Methods;

public class SyncMethods
{
	public static List<Group> groups_to_sync;

	public static List<Item> items_to_sync;

	public static List<InventoryAudit> inventory_audits_to_sync;

	public static List<InventoryBatch> inventory_batches_to_sync;

	public static List<TaxRule> tax_rules_to_sync;

	public static List<Tax> tax_to_sync;

	public static List<TaxRuleOperation> tax_rules_operation_to_sync;

	public static List<ItemType> item_types_to_sync;

	public static List<Supplier> suppliers_to_sync;

	public static List<Appointment> appointments_to_sync;

	public static List<Employee> employees_to_sync;

	public static List<Reason> reasons_to_sync;

	public static List<Option> options_to_sync;

	public static List<ItemsWithOption> itemsWithOption_to_sync;

	public static List<SpecialInstruction> instructions_to_sync;

	public static List<Customer> members_to_sync;

	public static List<Station> stations_to_sync;

	public static List<Setting> settings_to_sync;

	public static List<CustomField> custom_field_to_sync;

	public static List<Promotion> promotions_to_sync;

	public static List<UOM> uoms_to_sync;

	public static List<CloudsyncDataArchiver> data_archivers_to_sync;

	public static List<CheckInventoryCountItemModel> check_inventory_items;

	public static List<int> itemsInItemToSyncParentIds;

	private static string string_0;

	public static int synced_count;

	public static int total_count;

	public static int total_orders_to_sync;

	public static int total_refunds_to_sync;

	public static bool inventorySyncResult;

	public static bool syncOverride;

	public static bool sync_inprocess;

	public static bool orderSyncing;

	public static bool isSyncingOrdersFromCS;

	public static bool isSyncingThirdPartyQueuesFromCS;

	public static bool isCountFinished;

	public static bool isSettingsSynced;

	public static bool isImageDownloading;

	public static bool currentlyDownloading;

	public static bool currentlyUploading;

	public static bool currentlyDownloadingImagesFromCS;

	public static string sync_token;

	public static bool employeeClockInOutSyncing;

	public static bool previousSyncError;

	private static Dictionary<string, DateTime> dictionary_0;

	private static bool bool_0;

	public static string GetToken()
	{
		GClass6 gClass = new GClass6();
		if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			return gClass.Settings.Where((Setting s) => s.Key == "cloudsync_api_key").FirstOrDefault().Value;
		}
		return "";
	}

	public static string GetStation()
	{
		GClass6 gClass = new GClass6();
		if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			return gClass.Settings.Where((Setting s) => s.Key == "cloudsync_station").FirstOrDefault().Value;
		}
		return "";
	}

	public static bool CheckInternet()
	{
		bool flag = false;
		try
		{
			Ping ping = new Ping();
			PingReply pingReply = ping.Send("google.com");
			if (pingReply != null && pingReply.Status == IPStatus.Success && pingReply.RoundtripTime < 500L)
			{
				flag = true;
			}
			else
			{
				pingReply = ping.Send("amazon.com");
				if (pingReply != null && pingReply.Status == IPStatus.Success && pingReply.RoundtripTime < 500L)
				{
					flag = true;
				}
				else
				{
					pingReply = ping.Send("yahoo.com");
					if (pingReply != null && pingReply.Status == IPStatus.Success && pingReply.RoundtripTime < 500L)
					{
						flag = true;
					}
				}
			}
			if (flag && !Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				return HealthCheck();
			}
			if (flag && Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				return true;
			}
		}
		catch
		{
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return false;
		}
		CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = true;
		return false;
	}

	public static bool HealthCheck()
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server);
		httpWebRequest.Timeout = 10000;
		httpWebRequest.Method = "GET";
		try
		{
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = true;
				return true;
			}
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return false;
		}
		catch
		{
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return false;
		}
	}

	public static StatusCodeResponseUpdate CheckForUpdate(CheckForUpdatesPostData req)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/checkforupdates");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.Proxy = null;
				httpWebRequest.Timeout = 10000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)req, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<StatusCodeResponseUpdate>(streamReader.ReadToEnd());
			}
			return new StatusCodeResponseUpdate
			{
				code = 400,
				IsForceUpdate = false,
				message = Resources.Unable_to_contact_server_check
			};
		}
		catch (Exception error)
		{
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new StatusCodeResponseUpdate
			{
				code = 400,
				IsForceUpdate = false,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static ValidateProductKeyResponse ValidateProductKey(ValidateProductKeyPostData key)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/validateproductkey");
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Method = "POST";
		httpWebRequest.Proxy = null;
		httpWebRequest.Timeout = 30000;
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			JsonSerializerSettings val = new JsonSerializerSettings();
			val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
			val.set_MaxDepth((int?)2000);
			string value = JsonConvert.SerializeObject((object)key, (Formatting)1, val);
			streamWriter.Write(value);
		}
		using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
		return JsonConvert.DeserializeObject<ValidateProductKeyResponse>(streamReader.ReadToEnd());
	}

	public static bool ValidateToken()
	{
		TokenObject tokenObject = new TokenObject();
		sync_token = GetToken();
		tokenObject.token = sync_token;
		string text = SyncTask(tokenObject, "/api/ValidateToken");
		if (!string.IsNullOrEmpty(text))
		{
			LogHelper.WriteLog(text, LogTypes.sync_log);
			return false;
		}
		return true;
	}

	public static SubscriptionResponseData GetSubscriptions(GetSubscriptionPostModel data)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				string syncServer = DebugSettings.syncServer;
				WriteToSyncLog("*** CheckThirdPartyOnlineOrderSubscription SERVER:" + syncServer, "OnlineOrderSync_");
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(syncServer + "/api/Subscriptions/GetSubscriptions");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Proxy = null;
				httpWebRequest.Timeout = 10000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject((object)data, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				return JsonConvert.DeserializeObject<SubscriptionResponseData>(streamReader.ReadToEnd());
			}
			return new SubscriptionResponseData
			{
				subscription_ids = null,
				code = 500,
				message = "[HIPPOS: RESTAURANT]\r[MESSAGE: Unable to reach Hippos Servers.\n " + DateTime.Now.ToString()
			};
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			SubscriptionResponseData subscriptionResponseData = new SubscriptionResponseData();
			subscriptionResponseData.subscription_ids = null;
			subscriptionResponseData.code = 500;
			subscriptionResponseData.message = "[HIPPOS: RESTAURANT]\r[MESSAGE: " + ex.Message + "\n " + ex.Source + "\n " + ex.StackTrace + "\n " + DateTime.Now.ToString();
			return subscriptionResponseData;
		}
	}

	public static StatusCodeResponse UpdateOrderStatusInOrdering(string OrderNumber, string Status, string CustomerOrderID = "", string paymentMethod = "", string source = "Hippos", int preptimeMinutes = -1, string ThirdPartyOrderId = "")
	{
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				DateTime? orderReadyTime = null;
				if (preptimeMinutes >= 0)
				{
					orderReadyTime = DateTime.Now.AddMinutes(preptimeMinutes);
				}
				short statusID = 0;
				if (source == OnlineOrderSource.Deliverect)
				{
					switch (Status)
					{
					case "Completed":
						statusID = Convert.ToInt16(DeliverectOrderStatusTag.finalized);
						break;
					case "OrderMade":
						statusID = Convert.ToInt16(DeliverectOrderStatusTag.ready_for_pickup);
						break;
					case "OrderRejected":
						statusID = Convert.ToInt16(DeliverectOrderStatusTag.rejected);
						break;
					case "ReceivedByKitchen":
						statusID = Convert.ToInt16(DeliverectOrderStatusTag.accepted);
						break;
					}
				}
				else
				{
					switch (Status)
					{
					case "Refunded":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.Refunded);
						break;
					case "ReceivedByStore":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.ReceivedByStore);
						break;
					case "InDelivery":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.InDelivery);
						break;
					case "ReadyForDelivery":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.ReadyForDelivery);
						break;
					case "ReadyForPickup":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.ReadyForPickup);
						break;
					case "Preparing":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.Preparing);
						break;
					case "ReceivedByKitchen":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.ReceivedByKitchen);
						break;
					case "OrderMade":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.OrderMade);
						break;
					case "Paid":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.Paid);
						break;
					case "Completed":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.Completed);
						break;
					case "OrderRejected":
						statusID = Convert.ToInt16(HipposOnlineOrderStatusID.OrderRejected);
						break;
					}
				}
				object obj = new
				{
					token = GetToken(),
					OrderNumber = OrderNumber,
					ThirdPartyOrderId = ThirdPartyOrderId,
					Status = Status,
					StatusID = statusID,
					CustomerOrderID = CustomerOrderID,
					PaymentMethod = paymentMethod,
					Source = source,
					OrderReadyTime = orderReadyTime,
					OrderReadyMinutes = preptimeMinutes
				};
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/Orders/UpdateOrderStatus");
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.Timeout = 10000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject(obj, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return JsonConvert.DeserializeObject<StatusCodeResponse>(streamReader.ReadToEnd());
			}
			return new StatusCodeResponse
			{
				code = 500,
				message = "Hippos Servers are offline."
			};
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new StatusCodeResponse
			{
				code = 500,
				message = Resources.Unable_to_contact_server_check
			};
		}
	}

	public static string SyncTask(object req, string url)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + url);
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.Proxy = null;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject(req, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				StatusCodeResponse statusCodeResponse = JsonConvert.DeserializeObject<StatusCodeResponse>(streamReader.ReadToEnd());
				if (statusCodeResponse.code == 200)
				{
					return string.Empty;
				}
				return Resources.Sync_failed + statusCodeResponse.message;
			}
			return "Hippos Servers are offline.";
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			DebugMethods.ShowExceptionTextFile(ex);
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return Resources.Unable_to_contact_server_check + ex.Message + ex.StackTrace;
		}
	}

	public static string SyncTaskWithResponseData(object req, string url)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + url);
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Method = "POST";
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Proxy = null;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					JsonSerializerSettings val = new JsonSerializerSettings();
					val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
					val.set_MaxDepth((int?)2000);
					string value = JsonConvert.SerializeObject(req, (Formatting)1, val);
					streamWriter.Write(value);
				}
				using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				return streamReader.ReadToEnd();
			}
			return "{\"code\": 500, \"message\": \"Hippos Servers are offline!\"}";
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			Console.WriteLine(ex.Message);
			DebugMethods.ShowExceptionTextFile(ex);
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return "{\"code\": 500, \"message\": \"" + ex.Message + "\"}";
		}
	}

	public static string GETSyncTaskWithResponseData(string url)
	{
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(Servers.sync_server + url);
				obj.ContentType = "application/json";
				obj.Method = "GET";
				obj.ServicePoint.Expect100Continue = false;
				obj.Proxy = null;
				using HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				return streamReader.ReadToEnd();
			}
			return "{\"code\": 500}";
		}
		catch (Exception ex)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, ex);
			}
			Console.WriteLine(ex.Message);
			CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"] = false;
			return "{\"code\": 500}";
		}
	}

	public static OtherLocInventoryCountResponseModel GetOtherLocsInventory(TokenItemObject req)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/GetOtherLocationInventory");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)req, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<OtherLocInventoryCountResponseModel>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new OtherLocInventoryCountResponseModel
			{
				code = 400,
				message = "Unable to contact server, check your connection."
			};
		}
	}

	public static StatusCodeResponse CheckIfMultipleLocation(CheckForUpdatesPostData req)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Servers.sync_server + "/api/CheckMultipleLocation");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				JsonSerializerSettings val = new JsonSerializerSettings();
				val.set_ReferenceLoopHandling((ReferenceLoopHandling)1);
				val.set_MaxDepth((int?)2000);
				string value = JsonConvert.SerializeObject((object)req, (Formatting)1, val);
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			return JsonConvert.DeserializeObject<StatusCodeResponseUpdate>(streamReader.ReadToEnd());
		}
		catch (Exception error)
		{
			if (DebugSettings.EnableHipchatNotificationError)
			{
				NotificationMethods.sendCrash("", Environment.OSVersion.VersionString, error);
			}
			return new StatusCodeResponse
			{
				code = 400,
				message = "Unable to contact server, check your connection."
			};
		}
	}

	public static OrderResponseModel GetOrdersFromCatering()
	{
		string token = GetToken();
		OrderResponseModel orderResponseModel = new OrderResponseModel();
		if (!string.IsNullOrEmpty(token))
		{
			OrderResponseModel orderResponseModel2 = JsonConvert.DeserializeObject<OrderResponseModel>(SyncTaskWithResponseData(new OrderPostResponseModel
			{
				token = token
			}, "/api/Orders/CateringOrders"));
			orderResponseModel.code = orderResponseModel2.code;
			orderResponseModel.message = orderResponseModel2.message;
			if (orderResponseModel2.code == 200)
			{
				orderResponseModel.orderList = orderResponseModel2.orderList;
			}
		}
		return orderResponseModel;
	}

	public static void BeginSync(System.Timers.Timer OrderSyncTimer, System.Timers.Timer InventorySyncTimer)
	{
		if (sync_inprocess)
		{
			return;
		}
		if (string.IsNullOrEmpty(sync_token))
		{
			sync_token = GetToken();
		}
		if (!Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			synced_count = 0;
			WriteToSyncLog("Begin Sync Process ...");
			GClass6 gClass = new GClass6();
			TimeSpan timeSpan = new TimeSpan(4, 0, 0);
			TimeSpan timeSpan2 = new TimeSpan(6, 0, 0);
			TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
			int num;
			int num2;
			int num3;
			if (timeOfDay > timeSpan && timeOfDay < timeSpan2)
			{
				num = (from o in gClass.Orders
					where o.Synced == false && o.Paid == true && o.DatePaid > DateTime.Now.AddMonths(-12) && o.DatePaid.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DatePaid descending
					select a).Take(100).Count();
				num2 = (from o in gClass.Orders
					where o.Synced == false && o.Void == true && o.DateCreated.Value > DateTime.Now.AddMonths(-12) && o.DateCreated.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).Count();
				num3 = (from o in gClass.Orders
					where o.Synced == false && o.OrderType == OrderTypes.Catering && o.PaymentMethods != "SAVED ORDER" && o.DateCreated.Value > DateTime.Now.AddMonths(-12) && o.DateCreated.Value < DateTime.Now.AddMinutes(-2.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).Count();
				total_refunds_to_sync = gClass.Refunds.Where((Refund r) => r.Order.Paid && r.Synced == false && r.DateCreated < DateTime.Now.AddMinutes(-5.0)).Count();
			}
			else
			{
				num = (from o in gClass.Orders
					where o.Synced == false && o.Paid == true && o.DatePaid > DateTime.Now.AddHours(-24.0) && o.DatePaid.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DatePaid descending
					select a).Take(100).Count();
				num2 = (from o in gClass.Orders
					where o.Synced == false && o.Void == true && o.DateCreated.Value > DateTime.Now.AddHours(-24.0) && o.DateCreated.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).Count();
				num3 = (from o in gClass.Orders
					where o.Synced == false && o.OrderType == OrderTypes.Catering && o.PaymentMethods != "SAVED ORDER" && o.DateCreated.Value > DateTime.Now.AddHours(-24.0) && o.DateCreated.Value < DateTime.Now.AddMinutes(-2.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).Count();
				total_refunds_to_sync = gClass.Refunds.Where((Refund r) => r.Order.Paid && r.Order.DatePaid.Value > DateTime.Now.AddHours(-24.0) && r.Order.DatePaid.Value < DateTime.Now.AddMinutes(-3.0) && r.Synced == false && r.DateCreated < DateTime.Now.AddMinutes(-5.0)).Count();
			}
			total_orders_to_sync = num + num2 + num3;
			if (total_orders_to_sync > 0)
			{
				WriteToSyncLog("Order Sync Process Begins... Total Orders to sync: " + total_orders_to_sync);
				sync_inprocess = true;
				OrderSyncTimer.Enabled = true;
				return;
			}
			if (total_refunds_to_sync > 0 && total_orders_to_sync == 0)
			{
				WriteToSyncLog("Refunds Sync Process Begins..Total Refunds to sync: " + total_refunds_to_sync);
				sync_inprocess = true;
				OrderSyncTimer.Enabled = true;
				return;
			}
			groups_to_sync = gClass.Groups.Where((Group g) => g.Synced == false).ToList();
			total_count = groups_to_sync.Count;
			itemsInItemToSyncParentIds = (from w in gClass.ItemsInItems
				where w.Synced == false
				select w.ParentItemID.Value).ToList();
			items_to_sync = gClass.Items.Where((Item g) => g.Synced == false || itemsInItemToSyncParentIds.Contains(g.ItemID)).ToList();
			gClass.ItemsInGroups.Select((ItemsInGroup i) => i.ItemID.Value).Distinct().ToList();
			inventory_audits_to_sync = gClass.InventoryAudits.Where((InventoryAudit g) => g.Synced == false).ToList();
			inventory_batches_to_sync = gClass.InventoryBatches.Where((InventoryBatch g) => g.Synced == false).ToList();
			tax_rules_to_sync = gClass.TaxRules.Where((TaxRule a) => a.Synced == false).ToList();
			tax_to_sync = gClass.Taxes.Where((Tax a) => a.Synced == false).ToList();
			tax_rules_operation_to_sync = gClass.TaxRuleOperations.Where((TaxRuleOperation a) => a.Synced == false).ToList();
			item_types_to_sync = gClass.ItemTypes.Where((ItemType t) => t.Synced == false).ToList();
			suppliers_to_sync = gClass.Suppliers.Where((Supplier t) => t.Synced == false).ToList();
			appointments_to_sync = gClass.Appointments.Where((Appointment r) => r.Synced == false).ToList();
			employees_to_sync = gClass.Employees.Where((Employee r) => r.Synced == false).ToList();
			options_to_sync = gClass.Options.Where((Option r) => r.Synced == false).ToList();
			reasons_to_sync = gClass.Reasons.Where((Reason a) => a.Synced == false).ToList();
			itemsWithOption_to_sync = gClass.ItemsWithOptions.Where((ItemsWithOption r) => r.Synced == false).ToList();
			instructions_to_sync = gClass.SpecialInstructions.Where((SpecialInstruction s) => s.Synced == false).ToList();
			members_to_sync = gClass.Customers.Where((Customer a) => a.Synced == false).ToList();
			stations_to_sync = gClass.Stations.Where((Station a) => a.Synced == false).ToList();
			settings_to_sync = gClass.Settings.Where((Setting a) => a.Synced == false).ToList();
			custom_field_to_sync = gClass.CustomFields.Where((CustomField a) => a.Sycned == false).ToList();
			promotions_to_sync = gClass.Promotions.Where((Promotion a) => a.Synced == false).ToList();
			uoms_to_sync = gClass.UOMs.Where((UOM a) => a.Synced == false).ToList();
			data_archivers_to_sync = gClass.CloudsyncDataArchivers.Where((CloudsyncDataArchiver a) => a.Synced == false).ToList();
			if (groups_to_sync.Count <= 0 && items_to_sync.Count <= 0 && inventory_audits_to_sync.Count <= 0 && tax_rules_to_sync.Count <= 0 && tax_to_sync.Count <= 0 && tax_rules_operation_to_sync.Count <= 0 && item_types_to_sync.Count <= 0 && suppliers_to_sync.Count <= 0 && appointments_to_sync.Count <= 0 && employees_to_sync.Count <= 0 && reasons_to_sync.Count <= 0 && options_to_sync.Count <= 0 && itemsWithOption_to_sync.Count <= 0 && instructions_to_sync.Count <= 0 && members_to_sync.Count <= 0 && stations_to_sync.Count <= 0 && settings_to_sync.Count <= 0 && custom_field_to_sync.Count <= 0 && promotions_to_sync.Count <= 0 && uoms_to_sync.Count <= 0 && data_archivers_to_sync.Count <= 0 && !syncOverride)
			{
				if (inventorySyncResult)
				{
					WriteToSyncLog("CLOUDSYNC COMPLETED");
				}
				else
				{
					WriteToSyncLog("CLOUDSYNC FAILED");
				}
			}
			else
			{
				InventorySyncTimer.Enabled = true;
			}
		}
		else
		{
			WriteToSyncLog("CloudSync disabled due to Training Mode.");
			sync_inprocess = false;
		}
	}

	public static void SyncOrders(string token, System.Timers.Timer OrderSyncTimer)
	{
		try
		{
			TimeSpan timeSpan = new TimeSpan(4, 0, 0);
			TimeSpan timeSpan2 = new TimeSpan(6, 0, 0);
			TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
			GClass6 gClass = new GClass6();
			List<Order> first;
			List<Order> second;
			List<Order> second2;
			if (timeOfDay > timeSpan && timeOfDay < timeSpan2)
			{
				first = (from o in gClass.Orders
					where o.Synced == false && o.Paid == true && o.DatePaid > DateTime.Now.AddMonths(-12) && o.DatePaid.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DatePaid descending
					select a).Take(100).ToList();
				second = (from o in gClass.Orders
					where o.Synced == false && o.Void == true && o.DateCreated.Value > DateTime.Now.AddMonths(-12) && o.DateCreated.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).ToList();
				second2 = (from o in gClass.Orders
					where o.Synced == false && o.OrderType == OrderTypes.Catering && o.PaymentMethods != "SAVED ORDER" && o.DateCreated.Value > DateTime.Now.AddMonths(-12) && o.DateCreated.Value < DateTime.Now.AddMinutes(-2.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).ToList();
			}
			else
			{
				first = (from o in gClass.Orders
					where o.Synced == false && o.Paid == true && o.DatePaid > DateTime.Now.AddHours(-24.0) && o.DatePaid.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DatePaid descending
					select a).Take(100).ToList();
				second = (from o in gClass.Orders
					where o.Synced == false && o.Void == true && o.DateCreated.Value > DateTime.Now.AddHours(-24.0) && o.DateCreated.Value < DateTime.Now.AddMinutes(-3.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).ToList();
				second2 = (from o in gClass.Orders
					where o.Synced == false && o.OrderType == OrderTypes.Catering && o.PaymentMethods != "SAVED ORDER" && o.DateCreated.Value > DateTime.Now.AddHours(-24.0) && o.DateCreated.Value < DateTime.Now.AddMinutes(-2.0)
					select o into a
					orderby a.DateCreated descending
					select a).Take(100).ToList();
			}
			List<Order> list = first.Union(second).Union(second2).Take(100)
				.ToList();
			WriteToSyncLog("Total Orders To Sync: " + list.Count());
			if (list.Any())
			{
				OrderPostModel orderPostModel = new OrderPostModel();
				orderPostModel.token = token;
				List<OrderPostDataModel> list2 = new List<OrderPostDataModel>();
				using (List<Order>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass61_0();
						CS_0024_003C_003E8__locals0.order = enumerator.Current;
						if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.GroupName))
						{
							ItemsInGroup itemsInGroup = gClass.ItemsInGroups.Where((ItemsInGroup i) => i.ItemID == (int?)CS_0024_003C_003E8__locals0.order.ItemID).FirstOrDefault();
							if (itemsInGroup != null)
							{
								CS_0024_003C_003E8__locals0.order.GroupName = itemsInGroup.Group.GroupName;
							}
							else
							{
								CS_0024_003C_003E8__locals0.order.GroupName = "Uncategorized";
							}
						}
						Employee employee = gClass.Employees.Where((Employee x) => (int?)x.EmployeeID == (int?)CS_0024_003C_003E8__locals0.order.UserCreated).FirstOrDefault();
						string user_created = string.Empty;
						if (employee != null)
						{
							user_created = employee.FirstName.Trim() + " " + employee.LastName.Trim();
						}
						OrderPostDataModel orderPostDataModel = new OrderPostDataModel();
						orderPostDataModel.customer_order_id = CS_0024_003C_003E8__locals0.order.OrderId.ToString();
						orderPostDataModel.date_created = (CS_0024_003C_003E8__locals0.order.DateCreated.HasValue ? CS_0024_003C_003E8__locals0.order.DateCreated.Value : DateTime.Now);
						orderPostDataModel.date_filled = CS_0024_003C_003E8__locals0.order.DateFilled;
						orderPostDataModel.date_refunded = CS_0024_003C_003E8__locals0.order.DateRefunded;
						orderPostDataModel.date_paid = CS_0024_003C_003E8__locals0.order.DatePaid;
						orderPostDataModel.discount = CS_0024_003C_003E8__locals0.order.Discount;
						orderPostDataModel.discount_desc = CS_0024_003C_003E8__locals0.order.DiscountDesc;
						orderPostDataModel.group_name = CS_0024_003C_003E8__locals0.order.GroupName;
						orderPostDataModel.is_void = CS_0024_003C_003E8__locals0.order.Void;
						orderPostDataModel.qty = Convert.ToDecimal(CS_0024_003C_003E8__locals0.order.Qty);
						orderPostDataModel.item_id = CS_0024_003C_003E8__locals0.order.ItemID;
						orderPostDataModel.item_name = CS_0024_003C_003E8__locals0.order.ItemName;
						orderPostDataModel.item_cost = CS_0024_003C_003E8__locals0.order.ItemCost;
						orderPostDataModel.item_price = CS_0024_003C_003E8__locals0.order.ItemPrice;
						orderPostDataModel.item_sell_price = CS_0024_003C_003E8__locals0.order.ItemSellPrice;
						orderPostDataModel.order_number = CS_0024_003C_003E8__locals0.order.OrderNumber;
						orderPostDataModel.order_ticket_number = CS_0024_003C_003E8__locals0.order.OrderTicketNumber;
						orderPostDataModel.order_type = CS_0024_003C_003E8__locals0.order.OrderType;
						orderPostDataModel.paid = CS_0024_003C_003E8__locals0.order.Paid;
						orderPostDataModel.payment_methods = CS_0024_003C_003E8__locals0.order.PaymentMethods;
						orderPostDataModel.station_id = CS_0024_003C_003E8__locals0.order.StationID;
						orderPostDataModel.subtotal = CS_0024_003C_003E8__locals0.order.SubTotal;
						orderPostDataModel.tax_desc = CS_0024_003C_003E8__locals0.order.TaxDesc;
						orderPostDataModel.tax_total = CS_0024_003C_003E8__locals0.order.TaxTotal;
						orderPostDataModel.total = CS_0024_003C_003E8__locals0.order.Total;
						orderPostDataModel.tip_amount = CS_0024_003C_003E8__locals0.order.TipAmount;
						orderPostDataModel.combo_id = CS_0024_003C_003E8__locals0.order.ComboID;
						orderPostDataModel.user_cancelled = CS_0024_003C_003E8__locals0.order.VoidBy;
						orderPostDataModel.user_created = user_created;
						orderPostDataModel.date_time_seated = CS_0024_003C_003E8__locals0.order.DateTimeSeated;
						orderPostDataModel.void_reason = CS_0024_003C_003E8__locals0.order.VoidReason;
						orderPostDataModel.guest_count = CS_0024_003C_003E8__locals0.order.GuestCount;
						orderPostDataModel.customer_name = CS_0024_003C_003E8__locals0.order.CustomerInfoName;
						orderPostDataModel.customer_address = CS_0024_003C_003E8__locals0.order.CustomerInfo;
						orderPostDataModel.customer_phone = CS_0024_003C_003E8__locals0.order.CustomerInfoPhone;
						orderPostDataModel.tip_desc = CS_0024_003C_003E8__locals0.order.TipDesc;
						orderPostDataModel.tip_share_desc = CS_0024_003C_003E8__locals0.order.TipShareDesc;
						orderPostDataModel.item_options_id = CS_0024_003C_003E8__locals0.order.ItemOptionId;
						orderPostDataModel.third_party_order_id = CS_0024_003C_003E8__locals0.order.ThirdPartyOrderId;
						if (CS_0024_003C_003E8__locals0.order.ItemIdentifier == "MainItem")
						{
							orderPostDataModel.item_identifier = 1;
						}
						else if (CS_0024_003C_003E8__locals0.order.ItemIdentifier == "ChildItem")
						{
							orderPostDataModel.item_identifier = 2;
						}
						else
						{
							orderPostDataModel.item_identifier = 3;
						}
						Employee employee2 = gClass.Employees.Where((Employee x) => (int?)x.EmployeeID == (int?)CS_0024_003C_003E8__locals0.order.UserCashout).FirstOrDefault();
						orderPostDataModel.user_cashout = ((employee2 != null) ? (employee2.FirstName.Trim() + " " + employee2.LastName.Trim()) : "");
						Employee employee3 = gClass.Employees.Where((Employee x) => (int?)x.EmployeeID == (int?)CS_0024_003C_003E8__locals0.order.UserServed).FirstOrDefault();
						orderPostDataModel.user_served = ((employee3 != null) ? (employee3.FirstName.Trim() + " " + employee3.LastName.Trim()) : "");
						orderPostDataModel.discount_reason = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.order.DiscountReason)) ? CS_0024_003C_003E8__locals0.order.DiscountReason : CS_0024_003C_003E8__locals0.order.DiscountReasonItem);
						orderPostDataModel.order_on_hold_time = CS_0024_003C_003E8__locals0.order.OrderOnHoldTime;
						orderPostDataModel.time_opt = CS_0024_003C_003E8__locals0.order.FulfillmentAt;
						orderPostDataModel.item_barcode = CS_0024_003C_003E8__locals0.order.ItemBarcode;
						list2.Add(orderPostDataModel);
					}
				}
				orderPostModel.ListOfOrder = list2;
				string text = SyncTask(orderPostModel, "/api/Orders/SyncOrders");
				if (!string.IsNullOrEmpty(text))
				{
					DateTime dateTime = (((from o in gClass.Orders
						where o.Synced == true && o.LastSynced.HasValue
						select o into d
						orderby d.LastSynced descending
						select d).FirstOrDefault() == null) ? DateTime.Now : (from o in gClass.Orders
						where o.Synced == true && o.LastSynced.HasValue
						select o into d
						orderby d.LastSynced descending
						select d).FirstOrDefault().LastSynced.Value);
					FailSync("CloudSync Failed: order sync, " + text + " Last synced on: " + dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString(), OrderSyncTimer, "CloudSync Failed: order sync,  Last synced on: " + dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString());
					orderSyncing = false;
					return;
				}
				foreach (Order item in list)
				{
					item.Synced = true;
					item.LastSynced = DateTime.Now;
					synced_count++;
				}
				Helper.SubmitChangesWithCatch(gClass);
				WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_orders_to_sync + " orders");
				orderSyncing = false;
			}
			if (synced_count >= total_orders_to_sync || total_orders_to_sync == 0 || !list.Any())
			{
				WriteToSyncLog("CloudSync completed: " + total_orders_to_sync + " order(s) synced.");
				sync_inprocess = false;
				orderSyncing = false;
				OrderSyncTimer.Enabled = false;
			}
		}
		catch (Exception ex)
		{
			FailSync("CloudSync Failed: orders, " + ex.Message, OrderSyncTimer, ex);
			sync_inprocess = false;
			orderSyncing = false;
			OrderSyncTimer.Enabled = false;
		}
	}

	public static bool SyncInventory(System.Timers.Timer InventorySyncTimer)
	{
		sync_inprocess = true;
		WriteToSyncLog("Sync Inventory Start");
		string text = "Finished ";
		try
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				InventorySyncTimer.Enabled = false;
				sync_inprocess = false;
				return false;
			}
			GClass6 gClass = new GClass6();
			synced_count = 0;
			CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
			if (groups_to_sync.Count > 0)
			{
				text = "Group";
				if (isCountFinished)
				{
					total_count = groups_to_sync.Count;
				}
				WriteToSyncLog("GROUPS TO SYNC: " + groups_to_sync.Count);
				inventorySyncResult = SyncGroups(sync_token, InventorySyncTimer);
			}
			else if (custom_field_to_sync.Count() > 0)
			{
				text = "Custom Fields.";
				inventorySyncResult = SyncCustomFields(sync_token, InventorySyncTimer);
			}
			else if (tax_rules_to_sync.Count <= 0 && tax_to_sync.Count <= 0 && tax_rules_operation_to_sync.Count <= 0)
			{
				if (companySetup != null && !companySetup.isSynced)
				{
					text = "Company Info";
					inventorySyncResult = SyncCompanyInfo(sync_token, InventorySyncTimer);
				}
				else if (item_types_to_sync.Count > 0)
				{
					text = "Item Types";
					inventorySyncResult = SyncItemTypes(sync_token, InventorySyncTimer);
				}
				else if (suppliers_to_sync.Count > 0)
				{
					text = "Suppliers";
					inventorySyncResult = SyncSuppliers(sync_token, InventorySyncTimer);
				}
				else if (items_to_sync.Count > 0)
				{
					text = "Items";
					if (isCountFinished)
					{
						total_count = items_to_sync.Count;
					}
					inventorySyncResult = SyncItems(sync_token, InventorySyncTimer);
				}
				else if (reasons_to_sync.Count > 0)
				{
					text = "Reasons";
					inventorySyncResult = SyncReasons(sync_token, InventorySyncTimer);
				}
				else if (options_to_sync.Count > 0)
				{
					text = "Options";
					inventorySyncResult = SyncOptions(sync_token, InventorySyncTimer);
				}
				else if (itemsWithOption_to_sync.Count > 0)
				{
					inventorySyncResult = SyncItemsWithOption(sync_token, InventorySyncTimer);
				}
				else if (instructions_to_sync.Count > 0)
				{
					text = "Instructions";
					inventorySyncResult = SyncInstructions(sync_token, InventorySyncTimer);
				}
				else if (members_to_sync.Count > 0)
				{
					text = "Members";
					inventorySyncResult = SyncMembers(sync_token, InventorySyncTimer);
				}
				else if (stations_to_sync.Count > 0)
				{
					text = "Stations";
					inventorySyncResult = SyncStations(sync_token, InventorySyncTimer);
				}
				else if (settings_to_sync.Count > 0)
				{
					text = "Settings";
					inventorySyncResult = SyncSettings(sync_token, InventorySyncTimer);
				}
				else if (promotions_to_sync.Count > 0)
				{
					text = "Promotions";
					inventorySyncResult = SyncPromotions(sync_token, InventorySyncTimer);
				}
				else if (uoms_to_sync.Count > 0)
				{
					text = "UOMs";
					inventorySyncResult = SyncUOM(sync_token, InventorySyncTimer);
				}
				else if (data_archivers_to_sync.Count > 0)
				{
					text = "SyncCloudsyncDataArchiver";
					inventorySyncResult = SyncCloudsyncDataArchiver(sync_token, InventorySyncTimer);
				}
				else if (employees_to_sync.Count > 0)
				{
					text = "Employees";
					inventorySyncResult = SyncEmployees(sync_token, InventorySyncTimer);
				}
				else
				{
					WriteToSyncLog("Syncing Data From Cloudsync...");
					text = "CS Company Info";
					inventorySyncResult = SyncCompanyInfoFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Suppliers";
					inventorySyncResult = SyncSuppliersFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Custom Fields";
					inventorySyncResult = SyncCustomFieldsFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Groups";
					inventorySyncResult = SyncGroupFromCloudSync(sync_token, InventorySyncTimer);
					text = "CS Item";
					inventorySyncResult = SyncItemFromCloudSync(sync_token, InventorySyncTimer);
					text = "CS Inv Audit";
					inventorySyncResult = SyncInventoryAudits(sync_token, InventorySyncTimer);
					text = "CS Inv Batches";
					inventorySyncResult = SyncInventoryBatches(sync_token, InventorySyncTimer);
					text = "CS Promotions";
					inventorySyncResult = SyncPromotionsFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Reasons";
					inventorySyncResult = SyncReasonsFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Options";
					inventorySyncResult = SyncOptionsFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Item Options";
					inventorySyncResult = SyncItemsWithOptionFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Instructions";
					inventorySyncResult = SyncInstructionsFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Reservations";
					inventorySyncResult = SyncReservations(sync_token, InventorySyncTimer);
					text = "CS Discount Codes";
					inventorySyncResult = SyncDiscountCodesFromCLoudsync(sync_token, InventorySyncTimer);
					text = "CS Members";
					inventorySyncResult = SyncMembersFromCloudsync(sync_token, InventorySyncTimer);
					text = "CS Settings";
					inventorySyncResult = SyncSettingsFromCloudsync(sync_token, InventorySyncTimer);
				}
			}
			else
			{
				text = "Tax Rules";
				inventorySyncResult = SyncTaxRules(sync_token, InventorySyncTimer);
			}
			WriteToSyncLog(text);
			syncOverride = false;
			sync_inprocess = false;
			InventorySyncTimer.Enabled = false;
			return true;
		}
		catch (Exception ex)
		{
			FailSync("CloudSync Failed: Failed to sync.", InventorySyncTimer, text + "\n" + ex.Message + "\n" + ex.StackTrace);
			return false;
		}
	}

	public static bool IsCloudSyncTimerStarted()
	{
		new GClass6();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("cloudsync_time_range");
		if (settingValueByKey != "OFF")
		{
			DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + settingValueByKey.Split('|')[1]);
			DateTime dateTime2 = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + settingValueByKey.Split('|')[2]);
			if (dateTime <= DateTime.Now && dateTime2 >= DateTime.Now)
			{
				return true;
			}
			if (dateTime > dateTime2 && dateTime <= DateTime.Now && dateTime2.AddDays(1.0) >= DateTime.Now)
			{
				return true;
			}
			WriteToSyncLog("Cloud sync will begin at: " + settingValueByKey.Split('|')[1]);
			return false;
		}
		return true;
	}

	public static void SyncOrdersFromCloudsync(string token, System.Timers.Timer OrderSyncTimer)
	{
		try
		{
			int num = 0;
			if (!isSyncingOrdersFromCS)
			{
				_003C_003Ec__DisplayClass64_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass64_0();
				WriteToSyncLog("Hippos: Online order sync started.", "OnlineOrderSync_");
				isSyncingOrdersFromCS = true;
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.res = JsonConvert.DeserializeObject<OrderResponseModel>(SyncTaskWithResponseData(new OrderPostResponseModel
				{
					token = token
				}, "/api/Orders/SyncOrdersFromCloudsync"));
				if (CS_0024_003C_003E8__locals0.res.code == 200)
				{
					num = CS_0024_003C_003E8__locals0.res.orderList.Count;
					WriteToSyncLog("Hippos: " + num + " order items received.", "OnlineOrderSync_");
					if (CS_0024_003C_003E8__locals0.res.orderList != null && num > 0)
					{
						OnlineOrderSyncQueue onlineOrderSyncQueue = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => a.Provider == OnlineOrderProviders.Hippos && a.RawData == JsonConvert.SerializeObject((object)CS_0024_003C_003E8__locals0.res.orderList)).FirstOrDefault();
						if (onlineOrderSyncQueue == null)
						{
							OnlineOrderSyncQueue entity = new OnlineOrderSyncQueue
							{
								Provider = OnlineOrderProviders.Hippos,
								DateCreated = DateTime.Now,
								RawData = JsonConvert.SerializeObject((object)CS_0024_003C_003E8__locals0.res.orderList)
							};
							gClass.OnlineOrderSyncQueues.InsertOnSubmit(entity);
							Helper.SubmitChangesWithCatch(gClass);
						}
						else
						{
							onlineOrderSyncQueue.RawData = JsonConvert.SerializeObject((object)CS_0024_003C_003E8__locals0.res.orderList);
							onlineOrderSyncQueue.DateCreated = DateTime.Now;
							onlineOrderSyncQueue.DateProcessed = null;
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
				}
				else
				{
					WriteToSyncLog("Hippos: Unable to sync online orders, response code=" + CS_0024_003C_003E8__locals0.res.code, "OnlineOrderSync_");
				}
			}
			isSyncingOrdersFromCS = false;
			WriteToSyncLog("Hippos: Order sync successful.", "OnlineOrderSync_");
		}
		catch (Exception ex)
		{
			FailSync("Cloudsync Failed: orders from cloudsync failed. " + ex.Message, OrderSyncTimer, ex);
			isSyncingOrdersFromCS = false;
			WriteToSyncLog("Hippos Order Sync: FAILED \r\n" + ex.Message, "OnlineOrderSync_");
		}
	}

	public static void SyncOnlineOrders(System.Timers.Timer OrderSyncTimer)
	{
		WriteToSyncLog("SyncOnlineOrders RUNNING", "OnlineOrderSync_");
		if (bool_0)
		{
			return;
		}
		try
		{
			bool_0 = true;
			using (List<OnlineOrderSettingObject>.Enumerator enumerator = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass67_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass67_0();
					CS_0024_003C_003E8__locals0.ooSetting = enumerator.Current;
					if (dictionary_0.Where((KeyValuePair<string, DateTime> x) => x.Key == CS_0024_003C_003E8__locals0.ooSetting.Provider).Count() == 0)
					{
						dictionary_0.Add(CS_0024_003C_003E8__locals0.ooSetting.Provider, DateTime.Now.AddMinutes(-10.0));
					}
					WriteToSyncLog(CS_0024_003C_003E8__locals0.ooSetting.Provider + ": Running online order sync.", "OnlineOrderSync_");
					if (dictionary_0.Where((KeyValuePair<string, DateTime> x) => x.Key == CS_0024_003C_003E8__locals0.ooSetting.Provider).FirstOrDefault().Value.AddSeconds(CS_0024_003C_003E8__locals0.ooSetting.PollInterval) <= DateTime.Now)
					{
						if (CS_0024_003C_003E8__locals0.ooSetting.Provider == OnlineOrderProviders.Hippos && !string.IsNullOrEmpty(sync_token))
						{
							SyncOrdersFromCloudsync(GetToken(), OrderSyncTimer);
						}
						else if (CS_0024_003C_003E8__locals0.ooSetting.Provider == OnlineOrderProviders.Moduurn)
						{
							ModuurnMethods.GetOrders(CS_0024_003C_003E8__locals0.ooSetting.Url, CS_0024_003C_003E8__locals0.ooSetting.ApiKey);
						}
						DateTime now = DateTime.Now;
					}
					WriteToSyncLog(CS_0024_003C_003E8__locals0.ooSetting.Provider + ": Processing queued online orders has completed.", "OnlineOrderSync_");
				}
			}
			bool_0 = false;
		}
		catch (Exception ex)
		{
			WriteToSyncLog("Error: SyncOnlineOrders Service. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
			bool_0 = false;
		}
	}

	public static void SyncThirdPartyOrderQueues(System.Timers.Timer ThirdPartyOrderQueuesSyncCloudsyncTimer)
	{
		WriteToSyncLog(" SyncThirdPartyOrderQueues RUNNING", "OnlineOrderSync_");
		if (isSyncingThirdPartyQueuesFromCS)
		{
			return;
		}
		try
		{
			isSyncingThirdPartyQueuesFromCS = true;
			GClass6 gClass = new GClass6();
			StatusCodeResponseOnlineOrderQueues statusCodeResponseOnlineOrderQueues = JsonConvert.DeserializeObject<StatusCodeResponseOnlineOrderQueues>(SyncTaskWithResponseData(new OrderPostResponseModel
			{
				token = sync_token
			}, "/api/Orders/SyncThirdPartyOrderQueues"));
			if (statusCodeResponseOnlineOrderQueues.code == 200)
			{
				if (statusCodeResponseOnlineOrderQueues.queueList.Count > 0)
				{
					using (List<OnlineOrderQueuePostDataModel>.Enumerator enumerator = statusCodeResponseOnlineOrderQueues.queueList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass68_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass68_0();
							CS_0024_003C_003E8__locals0.queue = enumerator.Current;
							OnlineOrderSyncQueue onlineOrderSyncQueue = gClass.OnlineOrderSyncQueues.Where((OnlineOrderSyncQueue a) => a.Provider == CS_0024_003C_003E8__locals0.queue.Provider && a.RawData == CS_0024_003C_003E8__locals0.queue.RawData).FirstOrDefault();
							if (onlineOrderSyncQueue == null)
							{
								onlineOrderSyncQueue = new OnlineOrderSyncQueue
								{
									DateCreated = DateTime.Now,
									Provider = CS_0024_003C_003E8__locals0.queue.Provider,
									RawData = CS_0024_003C_003E8__locals0.queue.RawData,
									Comment = CS_0024_003C_003E8__locals0.queue.Comment
								};
								gClass.OnlineOrderSyncQueues.InsertOnSubmit(onlineOrderSyncQueue);
								Helper.SubmitChangesWithCatch(gClass);
							}
						}
					}
					if (string.IsNullOrEmpty(SyncTask(new OnlineOrderQueueConfirmationModel
					{
						token = sync_token,
						CsIds = statusCodeResponseOnlineOrderQueues.queueList.Select((OnlineOrderQueuePostDataModel a) => a.CsId).ToList()
					}, "/api/Orders/ConfirmSyncThirdPartyOrderQueues")))
					{
						WriteToSyncLog("Processing Third Party queued online orders has completed.", "OnlineOrderSync_");
					}
				}
			}
			else
			{
				WriteToSyncLog("Error: SyncThirdPartyOrderQueues API. " + statusCodeResponseOnlineOrderQueues.message, "OnlineOrderSync_");
			}
		}
		catch (Exception ex)
		{
			WriteToSyncLog("Error: SyncThirdPartyOrderQueues Service. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
		}
		isSyncingThirdPartyQueuesFromCS = false;
	}

	public static void SyncRefunds(string token, System.Timers.Timer OrderSyncTimer)
	{
		try
		{
			TimeSpan timeSpan = new TimeSpan(4, 0, 0);
			TimeSpan timeSpan2 = new TimeSpan(6, 0, 0);
			TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
			GClass6 gClass = new GClass6();
			List<Refund> list = ((!(timeOfDay > timeSpan) || !(timeOfDay < timeSpan2)) ? (from o in gClass.Refunds
				where o.Order.Synced == true && o.Order.DatePaid > DateTime.Now.AddHours(-24.0) && o.Order.DatePaid < DateTime.Now.AddMinutes(-3.0) && o.Synced == false && o.Order.Paid == true && o.DateCreated < DateTime.Now.AddMinutes(-5.0)
				select o into a
				orderby a.DateCreated
				select a).Take(100).ToList() : (from o in gClass.Refunds
				where o.Order.Synced == true && o.Synced == false && o.Order.Paid == true && o.DateCreated < DateTime.Now.AddMinutes(-5.0)
				select o into a
				orderby a.DateCreated
				select a).Take(100).ToList());
			if (total_refunds_to_sync > 0 && list.Count() > 0)
			{
				RefundPostModel refundPostModel = new RefundPostModel();
				refundPostModel.token = token;
				List<RefundPostDataModel> list2 = new List<RefundPostDataModel>();
				using (List<Refund>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass69_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass69_0();
						CS_0024_003C_003E8__locals0.refund = enumerator.Current;
						Employee employee = gClass.Employees.Where((Employee x) => (int?)x.EmployeeID == CS_0024_003C_003E8__locals0.refund.EmployeeID).FirstOrDefault();
						string userCreated = string.Empty;
						if (employee != null)
						{
							userCreated = employee.FirstName.Trim() + " " + employee.LastName.Trim();
						}
						RefundPostDataModel item = new RefundPostDataModel
						{
							RefundAppId = CS_0024_003C_003E8__locals0.refund.RefundID,
							RefundNumber = CS_0024_003C_003E8__locals0.refund.RefundNumber,
							OrderId = CS_0024_003C_003E8__locals0.refund.OrderId,
							PaymentMethod = CS_0024_003C_003E8__locals0.refund.PaymentMethod,
							Qty = CS_0024_003C_003E8__locals0.refund.Qty,
							RefundReason = CS_0024_003C_003E8__locals0.refund.RefundReason,
							UserCreated = userCreated,
							AmountRefunded = CS_0024_003C_003E8__locals0.refund.AmountRefunded,
							DateCreated = CS_0024_003C_003E8__locals0.refund.DateCreated
						};
						list2.Add(item);
					}
				}
				refundPostModel.ListOfRefunds = list2;
				string text = SyncTask(refundPostModel, "/api/Orders/SyncRefunds");
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains("Order for the refund does not exist"))
					{
						using (List<Refund>.Enumerator enumerator = list.ToList().GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass69_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass69_1();
								CS_0024_003C_003E8__locals1.r = enumerator.Current;
								Order order = gClass.Orders.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals1.r.OrderId).FirstOrDefault();
								if (order != null)
								{
									order.Synced = false;
								}
							}
						}
						Helper.SubmitChangesWithCatch(gClass);
						WriteToSyncLog("CloudSync Update: refunds sync, Orders for a refund does not exist in cloud, Syncing respective orders will begin shortly...");
						sync_inprocess = false;
						orderSyncing = false;
						OrderSyncTimer.Enabled = false;
					}
					else
					{
						FailSync("CloudSync Failed: refunds sync, " + text + ".", OrderSyncTimer, text);
						orderSyncing = false;
					}
					return;
				}
				foreach (Refund item2 in list)
				{
					item2.Synced = true;
					Helper.SubmitChangesWithCatch(gClass);
					synced_count++;
					WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_refunds_to_sync + " refunds sync.");
					orderSyncing = false;
				}
			}
			if (synced_count >= total_refunds_to_sync || total_refunds_to_sync == 0)
			{
				WriteToSyncLog("CloudSync completed: " + total_refunds_to_sync + " refunds synced.");
				sync_inprocess = false;
				orderSyncing = false;
				OrderSyncTimer.Enabled = false;
			}
		}
		catch (Exception ex)
		{
			FailSync("CloudSync Failed: refunds, " + ex.Message, OrderSyncTimer, ex);
			sync_inprocess = false;
			orderSyncing = false;
			OrderSyncTimer.Enabled = false;
		}
	}

	public static void SyncRefundsFromCloudsync(string token, System.Timers.Timer OrderSyncTimer)
	{
		GClass6 gClass = new GClass6();
		RefundResponseModel refundResponseModel = JsonConvert.DeserializeObject<RefundResponseModel>(SyncTaskWithResponseData(new RefundPostResponseModel
		{
			token = token
		}, "/api/Orders/SyncRefundsFromCloudsync"));
		if (refundResponseModel.code == 200 && refundResponseModel.refundList != null && refundResponseModel.refundList.Count > 0)
		{
			List<Guid> list = new List<Guid>();
			using (List<RefundPostDataModel>.Enumerator enumerator = refundResponseModel.refundList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass70_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass70_0();
					CS_0024_003C_003E8__locals0.refundRes = enumerator.Current;
					Refund refund = gClass.Refunds.Where((Refund a) => a.RefundID == CS_0024_003C_003E8__locals0.refundRes.RefundAppId).FirstOrDefault();
					Order order = gClass.Orders.Where((Order a) => a.OrderId == CS_0024_003C_003E8__locals0.refundRes.OrderId).FirstOrDefault();
					if (refund == null && order != null)
					{
						Refund entity = new Refund
						{
							RefundID = CS_0024_003C_003E8__locals0.refundRes.RefundAppId,
							DateCreated = CS_0024_003C_003E8__locals0.refundRes.DateCreated,
							AmountRefunded = CS_0024_003C_003E8__locals0.refundRes.AmountRefunded,
							OrderId = CS_0024_003C_003E8__locals0.refundRes.OrderId,
							PaymentMethod = CS_0024_003C_003E8__locals0.refundRes.PaymentMethod,
							Qty = CS_0024_003C_003E8__locals0.refundRes.Qty,
							RefundNumber = CS_0024_003C_003E8__locals0.refundRes.RefundNumber,
							RefundReason = CS_0024_003C_003E8__locals0.refundRes.RefundReason,
							Synced = true
						};
						gClass.Refunds.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gClass);
					}
					if (order != null)
					{
						list.Add(CS_0024_003C_003E8__locals0.refundRes.RefundAppId);
					}
				}
			}
			string text = SyncTask(new RefundConfirmationModel
			{
				token = token,
				RefundAppIds = list
			}, "/api/Orders/ConfirmSyncRefunds");
			if (string.IsNullOrEmpty(text))
			{
				WriteToSyncLog("Refunds from Cloudsync Successfully Synced.");
			}
			else
			{
				FailSync("CloudSync Failed: refunds sync, " + text + ".", OrderSyncTimer, text);
			}
		}
		orderSyncing = false;
		sync_inprocess = false;
		OrderSyncTimer.Enabled = false;
	}

	public static void UpdateItemsInGroups(int ItemId, List<ItemInGroupData> GroupDataList)
	{
		_003C_003Ec__DisplayClass71_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass71_0();
		CS_0024_003C_003E8__locals0.ItemId = ItemId;
		GClass6 gClass = new GClass6();
		List<ItemsInGroup> list = gClass.ItemsInGroups.Where((ItemsInGroup tblItemsInGroup) => tblItemsInGroup.ItemID == (int?)CS_0024_003C_003E8__locals0.ItemId).ToList();
		if (GroupDataList != null && GroupDataList.Count > 0)
		{
			using (List<ItemInGroupData>.Enumerator enumerator = GroupDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass71_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass71_1();
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
					CS_0024_003C_003E8__locals1.eachGroupData = enumerator.Current;
					ItemsInGroup itemsInGroup = gClass.ItemsInGroups.Where((ItemsInGroup a) => a.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.ItemId && (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals1.eachGroupData.GroupId).FirstOrDefault();
					if (gClass.Groups.Where((Group a) => a.GroupID == CS_0024_003C_003E8__locals1.eachGroupData.GroupId).FirstOrDefault() != null)
					{
						if (itemsInGroup != null)
						{
							list.Remove(itemsInGroup);
							itemsInGroup.Color = CS_0024_003C_003E8__locals1.eachGroupData.Color;
							itemsInGroup.SortOrder = CS_0024_003C_003E8__locals1.eachGroupData.SortOrder;
							Helper.SubmitChangesWithCatch(gClass);
							continue;
						}
						ItemsInGroup entity = new ItemsInGroup
						{
							ItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.ItemId,
							Color = CS_0024_003C_003E8__locals1.eachGroupData.Color,
							GroupID = CS_0024_003C_003E8__locals1.eachGroupData.GroupId,
							SortOrder = CS_0024_003C_003E8__locals1.eachGroupData.SortOrder,
							Synced = true
						};
						gClass.ItemsInGroups.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				gClass.ItemsInGroups.DeleteAllOnSubmit(list);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		else if (list != null && list.Count > 0)
		{
			gClass.ItemsInGroups.DeleteAllOnSubmit(list);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	public static void AddItemsInItems(int ItemId, string ItemsInItemsList)
	{
		if (!(ItemsInItemsList != ""))
		{
			return;
		}
		GClass6 gClass = new GClass6();
		string[] array = ItemsInItemsList.Split(';');
		foreach (string text in array)
		{
			if (!(text != ""))
			{
				continue;
			}
			int num = Convert.ToInt32(text.Split('|')[0]);
			decimal value = Convert.ToDecimal(text.Split('|')[1]);
			if (num == -1)
			{
				_003C_003Ec__DisplayClass72_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass72_0();
				CS_0024_003C_003E8__locals0.CloudSyncItemId = Convert.ToInt32(text.Split('|')[2]);
				Item item = gClass.Items.Where((Item i) => i.CloudItemID == (long)CS_0024_003C_003E8__locals0.CloudSyncItemId).FirstOrDefault();
				if (item != null)
				{
					ItemsInItem entity = new ItemsInItem
					{
						ParentItemID = ItemId,
						ItemID = item.ItemID,
						Quantity = value,
						Synced = true
					};
					gClass.ItemsInItems.InsertOnSubmit(entity);
				}
			}
			else
			{
				ItemsInItem entity2 = new ItemsInItem
				{
					ParentItemID = ItemId,
					ItemID = num,
					Quantity = value,
					Synced = true
				};
				gClass.ItemsInItems.InsertOnSubmit(entity2);
			}
		}
	}

	public static void UpdateItemSupplier(int itemId, List<ItemSupplierData> SupplierData)
	{
		_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass73_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		GClass6 gClass = new GClass6();
		IQueryable<ItemsSupplier> queryable = gClass.ItemsSuppliers.Where((ItemsSupplier a) => a.ItemId == CS_0024_003C_003E8__locals0.itemId);
		if (queryable.Count() > 0)
		{
			gClass.ItemsSuppliers.DeleteAllOnSubmit(queryable);
			Helper.SubmitChangesWithCatch(gClass);
		}
		if (!((SupplierData != null) & (SupplierData.Count > 0)))
		{
			return;
		}
		foreach (ItemSupplierData SupplierDatum in SupplierData)
		{
			_003C_003Ec__DisplayClass73_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass73_1();
			CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals1.SupplierName = SupplierDatum.SupplierName;
			CS_0024_003C_003E8__locals1.sup = gClass.Suppliers.Where((Supplier a) => a.Name.ToUpper() == CS_0024_003C_003E8__locals1.SupplierName.ToUpper()).FirstOrDefault();
			if (CS_0024_003C_003E8__locals1.sup != null && gClass.ItemsSuppliers.Where((ItemsSupplier a) => a.ItemId == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemId && a.SupplierId == CS_0024_003C_003E8__locals1.sup.Id).FirstOrDefault() == null)
			{
				gClass.ItemsSuppliers.InsertOnSubmit(new ItemsSupplier
				{
					ItemId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.itemId,
					SupplierId = CS_0024_003C_003E8__locals1.sup.Id
				});
			}
		}
		gClass.SubmitChanges();
	}

	public static void UpdateItemCustomField(int itemId, List<ItemCustomFieldData> CustomFieldData)
	{
		_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass74_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		if (!((CustomFieldData != null) & (CustomFieldData.Count > 0)))
		{
			return;
		}
		GClass6 gClass = new GClass6();
		Item item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals0.itemId).FirstOrDefault();
		foreach (ItemCustomFieldData CustomFieldDatum in CustomFieldData)
		{
			_003C_003Ec__DisplayClass74_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass74_1();
			CS_0024_003C_003E8__locals1.CustomFieldName = CustomFieldDatum.CustomFieldName;
			CustomField customField = gClass.CustomFields.Where((CustomField a) => a.Value.ToUpper() == CS_0024_003C_003E8__locals1.CustomFieldName.ToUpper()).FirstOrDefault();
			if (customField != null)
			{
				ItemCustomFieldValue itemCustomFieldValue = item.ItemCustomFieldValues.Where((ItemCustomFieldValue a) => a.CustomField.Value == CS_0024_003C_003E8__locals1.CustomFieldName).FirstOrDefault();
				if (itemCustomFieldValue != null)
				{
					itemCustomFieldValue.Value = CustomFieldDatum.Value;
					continue;
				}
				gClass.ItemCustomFieldValues.InsertOnSubmit(new ItemCustomFieldValue
				{
					CustomFieldId = customField.CustomFieldId,
					ItemId = item.ItemID,
					Value = CustomFieldDatum.Value,
					Synced = false
				});
			}
		}
		gClass.SubmitChanges();
	}

	public static void UpdateMaterialsInItem(int itemId, List<MaterialInItemData> MaterialData)
	{
		_003C_003Ec__DisplayClass75_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass75_0();
		CS_0024_003C_003E8__locals0.itemId = itemId;
		CS_0024_003C_003E8__locals0.MaterialData = MaterialData;
		if (!((CS_0024_003C_003E8__locals0.MaterialData != null) & (CS_0024_003C_003E8__locals0.MaterialData.Count > 0)))
		{
			return;
		}
		GClass6 gClass = new GClass6();
		List<UOM> source = gClass.UOMs.ToList();
		UOM uOM = source.Where((UOM a) => a.Name.ToUpper() == "EACH").FirstOrDefault();
		List<MaterialsInItem> source2 = gClass.MaterialsInItems.Where((MaterialsInItem i) => i.ItemID == CS_0024_003C_003E8__locals0.itemId).ToList();
		List<Item> source3 = gClass.Items.Where((Item a) => CS_0024_003C_003E8__locals0.MaterialData.Select((MaterialInItemData b) => b.MaterialName.ToUpper()).Contains(a.ItemName.ToUpper())).ToList();
		using (List<MaterialInItemData>.Enumerator enumerator = CS_0024_003C_003E8__locals0.MaterialData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass75_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass75_1();
				CS_0024_003C_003E8__locals2.matData = enumerator.Current;
				_003C_003Ec__DisplayClass75_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass75_2();
				CS_0024_003C_003E8__locals1.materialItem = source3.Where((Item a) => a.ItemName.ToUpper() == CS_0024_003C_003E8__locals2.matData.MaterialName.ToUpper()).FirstOrDefault();
				if (CS_0024_003C_003E8__locals1.materialItem != null)
				{
					MaterialsInItem materialsInItem = source2.Where((MaterialsInItem a) => a.ItemMaterialID == CS_0024_003C_003E8__locals1.materialItem.ItemID).FirstOrDefault();
					UOM uOM2 = source.Where((UOM a) => a.Name.ToUpper() == CS_0024_003C_003E8__locals2.matData.UOM.ToUpper()).FirstOrDefault();
					if (materialsInItem != null)
					{
						materialsInItem.Quantity = CS_0024_003C_003E8__locals2.matData.Qty;
						materialsInItem.UOMID = uOM2?.UOMID ?? uOM.UOMID;
						materialsInItem.Comments = CS_0024_003C_003E8__locals2.matData.Comments;
						continue;
					}
					materialsInItem = new MaterialsInItem
					{
						Comments = CS_0024_003C_003E8__locals2.matData.Comments,
						UOMID = (uOM2?.UOMID ?? uOM.UOMID),
						ItemID = CS_0024_003C_003E8__locals0.itemId,
						ItemMaterialID = CS_0024_003C_003E8__locals1.materialItem.ItemID,
						Quantity = CS_0024_003C_003E8__locals2.matData.Qty
					};
					gClass.MaterialsInItems.InsertOnSubmit(materialsInItem);
				}
			}
		}
		gClass.SubmitChanges();
	}

	public static bool SyncItemFromCloudSync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Item From Cloudsync Started...");
		bool result = true;
		ItemResponseModel itemResponseModel = JsonConvert.DeserializeObject<ItemResponseModel>(SyncTaskWithResponseData(new ItemPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncItemsFromCloudSync"));
		if (itemResponseModel.code == 200)
		{
			GClass6 gClass = new GClass6();
			if (itemResponseModel.itemResponseList != null && itemResponseModel.itemResponseList.Count > 0)
			{
				_003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass76_0();
				CS_0024_003C_003E8__locals2.ListOfCloudsyncIdsToConfirm = new List<long>();
				using (List<ItemsPostDataModel>.Enumerator enumerator = itemResponseModel.itemResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass76_1 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass76_1();
						CS_0024_003C_003E8__locals3.itemRes = enumerator.Current;
						_003C_003Ec__DisplayClass76_2 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass76_2();
						CS_0024_003C_003E8__locals2.ListOfCloudsyncIdsToConfirm.Add(CS_0024_003C_003E8__locals3.itemRes.CloudSyncItemId);
						CS_0024_003C_003E8__locals4.existingItem = null;
						if (CS_0024_003C_003E8__locals3.itemRes.ItemID > 0)
						{
							CS_0024_003C_003E8__locals4.existingItem = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals3.itemRes.ItemID).FirstOrDefault();
						}
						else
						{
							CS_0024_003C_003E8__locals4.existingItem = gClass.Items.Where((Item i) => i.CloudItemID == CS_0024_003C_003E8__locals3.itemRes.CloudSyncItemId).FirstOrDefault();
						}
						short uOMID = ((gClass.UOMs.Where((UOM u) => u.Name == CS_0024_003C_003E8__locals3.itemRes.UOM).FirstOrDefault() != null) ? gClass.UOMs.Where((UOM u) => u.Name == CS_0024_003C_003E8__locals3.itemRes.UOM).FirstOrDefault().UOMID : Convert.ToInt16(1));
						if (CS_0024_003C_003E8__locals4.existingItem != null)
						{
							CS_0024_003C_003E8__locals4.existingItem.Active = CS_0024_003C_003E8__locals3.itemRes.Active;
							CS_0024_003C_003E8__locals4.existingItem.AllowCustomPrice = CS_0024_003C_003E8__locals3.itemRes.AllowCustomPrice;
							CS_0024_003C_003E8__locals4.existingItem.AllowProRated = CS_0024_003C_003E8__locals3.itemRes.AllowProRated;
							CS_0024_003C_003E8__locals4.existingItem.Barcode = CS_0024_003C_003E8__locals3.itemRes.Barcode;
							CS_0024_003C_003E8__locals4.existingItem.ItemColor = CS_0024_003C_003E8__locals3.itemRes.ItemColor;
							CS_0024_003C_003E8__locals4.existingItem.ItemCost = CS_0024_003C_003E8__locals3.itemRes.ItemCost;
							CS_0024_003C_003E8__locals4.existingItem.ItemID = CS_0024_003C_003E8__locals3.itemRes.ItemID;
							CS_0024_003C_003E8__locals4.existingItem.ItemName = CS_0024_003C_003E8__locals3.itemRes.ItemName;
							CS_0024_003C_003E8__locals4.existingItem.Description = CS_0024_003C_003E8__locals3.itemRes.Description;
							CS_0024_003C_003E8__locals4.existingItem.ItemPrice = CS_0024_003C_003E8__locals3.itemRes.ItemPrice;
							CS_0024_003C_003E8__locals4.existingItem.ItemSalePrice = CS_0024_003C_003E8__locals3.itemRes.ItemSalePrice;
							CS_0024_003C_003E8__locals4.existingItem.OnSale = CS_0024_003C_003E8__locals3.itemRes.OnSale;
							CS_0024_003C_003E8__locals4.existingItem.StartDateOnSale = CS_0024_003C_003E8__locals3.itemRes.StartDateOnSale;
							CS_0024_003C_003E8__locals4.existingItem.EndDateOnSale = CS_0024_003C_003E8__locals3.itemRes.EndDateOnSale;
							CS_0024_003C_003E8__locals4.existingItem.StartTimeOnSale = CS_0024_003C_003E8__locals3.itemRes.StartTimeOnSale;
							CS_0024_003C_003E8__locals4.existingItem.EndTimeOnSale = CS_0024_003C_003E8__locals3.itemRes.EndTimeOnSale;
							CS_0024_003C_003E8__locals4.existingItem.DaysSaleList = CS_0024_003C_003E8__locals3.itemRes.DaysSaleList;
							CS_0024_003C_003E8__locals4.existingItem.ItemTypeID = ((CS_0024_003C_003E8__locals3.itemRes.ItemTypeID == -1) ? 2 : CS_0024_003C_003E8__locals3.itemRes.ItemTypeID);
							CS_0024_003C_003E8__locals4.existingItem.SortOrder = CS_0024_003C_003E8__locals3.itemRes.SortOrder;
							CS_0024_003C_003E8__locals4.existingItem.StationID = CS_0024_003C_003E8__locals3.itemRes.StationID;
							CS_0024_003C_003E8__locals4.existingItem.TrackInventory = CS_0024_003C_003E8__locals3.itemRes.TrackInventory;
							CS_0024_003C_003E8__locals4.existingItem.TaxRuleID = CS_0024_003C_003E8__locals3.itemRes.TaxRuleId;
							CS_0024_003C_003E8__locals4.existingItem.UOMID = uOMID;
							CS_0024_003C_003E8__locals4.existingItem.isDeleted = CS_0024_003C_003E8__locals3.itemRes.isDeleted;
							CS_0024_003C_003E8__locals4.existingItem.ItemClassification = CS_0024_003C_003E8__locals3.itemRes.ItemClassification;
							CS_0024_003C_003E8__locals4.existingItem.MaxFreeOptions = CS_0024_003C_003E8__locals3.itemRes.MaxFreeOptions;
							CS_0024_003C_003E8__locals4.existingItem.MinFreeOptions = CS_0024_003C_003E8__locals3.itemRes.MinFreeOptions;
							CS_0024_003C_003E8__locals4.existingItem.TrackExpiryDate = CS_0024_003C_003E8__locals3.itemRes.TrackExpiryDate;
							CS_0024_003C_003E8__locals4.existingItem.ItemLongName = CS_0024_003C_003E8__locals3.itemRes.ItemLongName;
							CS_0024_003C_003E8__locals4.existingItem.TaxesIncluded = CS_0024_003C_003E8__locals3.itemRes.TaxesIncluded;
							CS_0024_003C_003E8__locals4.existingItem.Synced = false;
							CS_0024_003C_003E8__locals4.existingItem.CloudItemID = CS_0024_003C_003E8__locals3.itemRes.CloudSyncItemId;
							CS_0024_003C_003E8__locals4.existingItem.DisableSoldOutItems = CS_0024_003C_003E8__locals3.itemRes.DisableSoldOutItems;
							CS_0024_003C_003E8__locals4.existingItem.AutoPromptOptions = true;
							CS_0024_003C_003E8__locals4.existingItem.UseSmartBarcode = CS_0024_003C_003E8__locals3.itemRes.UseSmartBarcode;
							CS_0024_003C_003E8__locals4.existingItem.ReOrderLimit = CS_0024_003C_003E8__locals3.itemRes.ReOrderLimit;
							CS_0024_003C_003E8__locals4.existingItem.ReorderQty = CS_0024_003C_003E8__locals3.itemRes.ReOrderQty;
							CS_0024_003C_003E8__locals3.itemRes.ItemID = CS_0024_003C_003E8__locals4.existingItem.ItemID;
							UpdateItemsInGroups(CS_0024_003C_003E8__locals4.existingItem.ItemID, CS_0024_003C_003E8__locals3.itemRes.GroupData);
							UpdateItemSupplier(CS_0024_003C_003E8__locals4.existingItem.ItemID, CS_0024_003C_003E8__locals3.itemRes.SupplierData);
							UpdateItemCustomField(CS_0024_003C_003E8__locals4.existingItem.ItemID, CS_0024_003C_003E8__locals3.itemRes.CustomFieldData);
							UpdateMaterialsInItem(CS_0024_003C_003E8__locals4.existingItem.ItemID, CS_0024_003C_003E8__locals3.itemRes.MaterialData);
						}
						else
						{
							Item item = new Item
							{
								Barcode = CS_0024_003C_003E8__locals3.itemRes.Barcode,
								ItemName = CS_0024_003C_003E8__locals3.itemRes.ItemName,
								Description = CS_0024_003C_003E8__locals3.itemRes.Description,
								ItemCost = CS_0024_003C_003E8__locals3.itemRes.ItemCost,
								ItemPrice = CS_0024_003C_003E8__locals3.itemRes.ItemPrice,
								ItemSalePrice = CS_0024_003C_003E8__locals3.itemRes.ItemSalePrice,
								OnSale = CS_0024_003C_003E8__locals3.itemRes.OnSale,
								StartDateOnSale = CS_0024_003C_003E8__locals3.itemRes.StartDateOnSale,
								EndDateOnSale = CS_0024_003C_003E8__locals3.itemRes.EndDateOnSale,
								StartTimeOnSale = CS_0024_003C_003E8__locals3.itemRes.StartTimeOnSale,
								EndTimeOnSale = CS_0024_003C_003E8__locals3.itemRes.EndTimeOnSale,
								DaysSaleList = CS_0024_003C_003E8__locals3.itemRes.DaysSaleList,
								ItemTypeID = ((CS_0024_003C_003E8__locals3.itemRes.ItemTypeID == -1) ? 2 : CS_0024_003C_003E8__locals3.itemRes.ItemTypeID),
								TaxRuleID = ((CS_0024_003C_003E8__locals3.itemRes.TaxRuleId == -1) ? 9 : CS_0024_003C_003E8__locals3.itemRes.TaxRuleId),
								StationID = CS_0024_003C_003E8__locals3.itemRes.StationID,
								SortOrder = CS_0024_003C_003E8__locals3.itemRes.SortOrder,
								ItemColor = CS_0024_003C_003E8__locals3.itemRes.ItemColor,
								Active = CS_0024_003C_003E8__locals3.itemRes.Active,
								InventoryCount = CS_0024_003C_003E8__locals3.itemRes.InventoryCount,
								UOMID = uOMID,
								TrackInventory = CS_0024_003C_003E8__locals3.itemRes.TrackInventory,
								isDeleted = CS_0024_003C_003E8__locals3.itemRes.isDeleted,
								CloudItemID = CS_0024_003C_003E8__locals3.itemRes.CloudSyncItemId,
								ItemClassification = CS_0024_003C_003E8__locals3.itemRes.ItemClassification,
								MaxFreeOptions = CS_0024_003C_003E8__locals3.itemRes.MaxFreeOptions,
								MinFreeOptions = CS_0024_003C_003E8__locals3.itemRes.MinFreeOptions,
								TrackExpiryDate = CS_0024_003C_003E8__locals3.itemRes.TrackExpiryDate,
								ItemLongName = CS_0024_003C_003E8__locals3.itemRes.ItemLongName,
								TaxesIncluded = CS_0024_003C_003E8__locals3.itemRes.TaxesIncluded,
								DisableSoldOutItems = CS_0024_003C_003E8__locals3.itemRes.DisableSoldOutItems,
								AutoPromptOptions = true,
								ItemCourse = "Uncategorized",
								UseSmartBarcode = CS_0024_003C_003E8__locals3.itemRes.UseSmartBarcode,
								ReOrderLimit = CS_0024_003C_003E8__locals3.itemRes.ReOrderLimit,
								ReorderQty = CS_0024_003C_003E8__locals3.itemRes.ReOrderQty,
								Synced = false
							};
							gClass.Items.InsertOnSubmit(item);
							Helper.SubmitChangesWithCatch(gClass);
							CS_0024_003C_003E8__locals4.existingItem = item;
							CS_0024_003C_003E8__locals3.itemRes.ItemID = item.ItemID;
							UpdateItemsInGroups(item.ItemID, CS_0024_003C_003E8__locals3.itemRes.GroupData);
							InventoryAudit entity = new InventoryAudit
							{
								Comment = "HipPOS Cloudsync NEW ITEM",
								DateCreated = DateTime.Now,
								ItemID = item.ItemID,
								Owner = "",
								QtyStart = 0m,
								QtyChange = CS_0024_003C_003E8__locals3.itemRes.InventoryCount,
								QtyNew = CS_0024_003C_003E8__locals3.itemRes.InventoryCount,
								Synced = false,
								InventoryType = ItemClassifications.Product
							};
							gClass.InventoryAudits.InsertOnSubmit(entity);
							UpdateItemSupplier(item.ItemID, CS_0024_003C_003E8__locals3.itemRes.SupplierData);
							UpdateItemCustomField(item.ItemID, CS_0024_003C_003E8__locals3.itemRes.CustomFieldData);
							UpdateMaterialsInItem(item.ItemID, CS_0024_003C_003E8__locals3.itemRes.MaterialData);
						}
						Helper.SubmitChangesWithCatch(gClass);
						if (CS_0024_003C_003E8__locals4.existingItem.TrackInventory)
						{
							CheckInventoryCountItemModel checkInventoryCountItemModel = check_inventory_items.Where((CheckInventoryCountItemModel a) => a.ItemID == CS_0024_003C_003E8__locals4.existingItem.ItemID).FirstOrDefault();
							if (checkInventoryCountItemModel == null)
							{
								check_inventory_items.Add(new CheckInventoryCountItemModel
								{
									ItemID = CS_0024_003C_003E8__locals4.existingItem.ItemID,
									InventoryCount = CS_0024_003C_003E8__locals4.existingItem.InventoryCount
								});
							}
							else
							{
								checkInventoryCountItemModel.InventoryCount = CS_0024_003C_003E8__locals4.existingItem.InventoryCount;
							}
						}
					}
				}
				using (List<ItemsPostDataModel>.Enumerator enumerator = itemResponseModel.itemResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass76_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass76_3();
						CS_0024_003C_003E8__locals0.itemRes = enumerator.Current;
						List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem w) => w.ParentItemID == (int?)CS_0024_003C_003E8__locals0.itemRes.ItemID).ToList();
						if (list != null && list.Count > 0)
						{
							foreach (ItemsInItem item2 in list)
							{
								gClass.ItemsInItems.DeleteOnSubmit(item2);
							}
							Helper.SubmitChangesWithCatch(gClass);
						}
						AddItemsInItems(CS_0024_003C_003E8__locals0.itemRes.ItemID, CS_0024_003C_003E8__locals0.itemRes.ItemsInItemsList);
					}
				}
				ItemConfirmationModel itemConfirmationModel = new ItemConfirmationModel();
				List<Ids> itemIds = (from i in gClass.Items
					where CS_0024_003C_003E8__locals2.ListOfCloudsyncIdsToConfirm.Contains(i.CloudItemID) && i.Synced == false
					select i into l
					select new Ids
					{
						CloudSyncId = l.CloudItemID,
						PosId = l.ItemID
					}).ToList();
				itemConfirmationModel.token = token;
				itemConfirmationModel.ItemIds = itemIds;
				if (string.IsNullOrEmpty(SyncTask(itemConfirmationModel, "/api/inventory/ConfirmSyncItem")))
				{
					_003C_003Ec__DisplayClass76_4 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass76_4();
					CS_0024_003C_003E8__locals1.cloudItemIDs = itemConfirmationModel.ItemIds.Select((Ids c) => c.CloudSyncId).ToList();
					foreach (Item item3 in gClass.Items.Where((Item i) => CS_0024_003C_003E8__locals1.cloudItemIDs.Contains(i.CloudItemID) == true).ToList())
					{
						item3.Synced = true;
						item3.CloudItemID = 0L;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("CloudSync: Items edited from cloudsync are synced.");
					ItemsAndGroupsStationsRefresh();
				}
			}
			SyncImageItems(token, InventorySyncTimer);
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync items from cloudsync", InventorySyncTimer, "Sync items from cloudsync failed. " + itemResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncGroupFromCloudSync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Groups From Cloudsync Started...");
		bool result = true;
		GroupResponseModel groupResponseModel = JsonConvert.DeserializeObject<GroupResponseModel>(SyncTaskWithResponseData(new ItemPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncGroupsFromCloudSync"));
		if (groupResponseModel.code == 200)
		{
			GClass6 gClass = new GClass6();
			if (groupResponseModel.groupResponseList != null && groupResponseModel.groupResponseList.Count > 0)
			{
				_003C_003Ec__DisplayClass77_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass77_0();
				CS_0024_003C_003E8__locals2.cloudsyncIdsToSync = new List<int>();
				using (List<GroupsPostDataModel>.Enumerator enumerator = groupResponseModel.groupResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass77_1 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass77_1();
						CS_0024_003C_003E8__locals3.groupRes = enumerator.Current;
						_003C_003Ec__DisplayClass77_2 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass77_2();
						CS_0024_003C_003E8__locals2.cloudsyncIdsToSync.Add((int)CS_0024_003C_003E8__locals3.groupRes.CloudsyncId);
						CS_0024_003C_003E8__locals4.existingItem = null;
						if (CS_0024_003C_003E8__locals3.groupRes.GroupID > 0)
						{
							CS_0024_003C_003E8__locals4.existingItem = gClass.Groups.Where((Group i) => i.GroupID == CS_0024_003C_003E8__locals3.groupRes.GroupID).FirstOrDefault();
						}
						else
						{
							CS_0024_003C_003E8__locals4.existingItem = gClass.Groups.Where((Group i) => (long)i.CloudSyncId == CS_0024_003C_003E8__locals3.groupRes.CloudsyncId).FirstOrDefault();
						}
						if (CS_0024_003C_003E8__locals4.existingItem != null)
						{
							CS_0024_003C_003E8__locals4.existingItem.CloudSyncId = (int)CS_0024_003C_003E8__locals3.groupRes.CloudsyncId;
							CS_0024_003C_003E8__locals4.existingItem.GroupName = CS_0024_003C_003E8__locals3.groupRes.GroupName;
							CS_0024_003C_003E8__locals4.existingItem.GroupColor = CS_0024_003C_003E8__locals3.groupRes.GroupColor;
							CS_0024_003C_003E8__locals4.existingItem.HighTraffic = CS_0024_003C_003E8__locals3.groupRes.HighTraffic;
							CS_0024_003C_003E8__locals4.existingItem.AllowHalfOrder = CS_0024_003C_003E8__locals3.groupRes.AllowHalfOrder;
							CS_0024_003C_003E8__locals4.existingItem.ParentGroupID = CS_0024_003C_003E8__locals3.groupRes.ParentGroupID;
							CS_0024_003C_003E8__locals4.existingItem.Active = CS_0024_003C_003E8__locals3.groupRes.Active;
							CS_0024_003C_003E8__locals4.existingItem.GroupClassification = CS_0024_003C_003E8__locals3.groupRes.GroupClassification;
							CS_0024_003C_003E8__locals4.existingItem.Description = CS_0024_003C_003E8__locals3.groupRes.GroupDescription;
							CS_0024_003C_003E8__locals4.existingItem.Synced = false;
							CS_0024_003C_003E8__locals4.existingItem.Archived = CS_0024_003C_003E8__locals3.groupRes.Archived;
							CS_0024_003C_003E8__locals4.existingItem.OrderEntryShow = CS_0024_003C_003E8__locals3.groupRes.OrderEntryShow;
							CS_0024_003C_003E8__locals4.existingItem.SortOrder = CS_0024_003C_003E8__locals3.groupRes.SortOrder;
							if (CS_0024_003C_003E8__locals4.existingItem.Archived)
							{
								gClass.ItemsInGroups.DeleteAllOnSubmit(gClass.ItemsInGroups.Where((ItemsInGroup a) => (int?)a.GroupID == (int?)CS_0024_003C_003E8__locals4.existingItem.GroupID));
								Helper.SubmitChangesWithCatch(gClass);
							}
						}
						else
						{
							Group entity = new Group
							{
								CloudSyncId = (int)CS_0024_003C_003E8__locals3.groupRes.CloudsyncId,
								GroupName = CS_0024_003C_003E8__locals3.groupRes.GroupName,
								GroupColor = CS_0024_003C_003E8__locals3.groupRes.GroupColor,
								HighTraffic = CS_0024_003C_003E8__locals3.groupRes.HighTraffic,
								AllowHalfOrder = CS_0024_003C_003E8__locals3.groupRes.AllowHalfOrder,
								ParentGroupID = CS_0024_003C_003E8__locals3.groupRes.ParentGroupID,
								Active = CS_0024_003C_003E8__locals3.groupRes.Active,
								GroupClassification = CS_0024_003C_003E8__locals3.groupRes.GroupClassification,
								Description = CS_0024_003C_003E8__locals3.groupRes.GroupDescription,
								Synced = false,
								Archived = CS_0024_003C_003E8__locals3.groupRes.Archived,
								SortOrder = CS_0024_003C_003E8__locals3.groupRes.SortOrder,
								OrderEntryShow = CS_0024_003C_003E8__locals3.groupRes.OrderEntryShow
							};
							gClass.Groups.InsertOnSubmit(entity);
						}
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
				using (List<GroupsPostDataModel>.Enumerator enumerator = groupResponseModel.groupResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass77_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass77_3();
						CS_0024_003C_003E8__locals0.groupRes = enumerator.Current;
						if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.groupRes.ParentGroupName) || CS_0024_003C_003E8__locals0.groupRes.ParentGroupID != 0)
						{
							continue;
						}
						Group group = gClass.Groups.Where((Group a) => a.Archived == false && a.GroupName == CS_0024_003C_003E8__locals0.groupRes.ParentGroupName).FirstOrDefault();
						if (group != null)
						{
							gClass.Groups.Where((Group i) => i.GroupID == CS_0024_003C_003E8__locals0.groupRes.GroupID || (long)i.CloudSyncId == CS_0024_003C_003E8__locals0.groupRes.CloudsyncId).FirstOrDefault().ParentGroupID = group.GroupID;
						}
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
				ItemConfirmationModel itemConfirmationModel = new ItemConfirmationModel();
				List<Ids> list = (from i in gClass.Groups
					where CS_0024_003C_003E8__locals2.cloudsyncIdsToSync.Contains(i.CloudSyncId) && i.Synced == false
					select i into l
					select new Ids
					{
						CloudSyncId = l.CloudSyncId,
						PosId = l.GroupID
					}).ToList();
				itemConfirmationModel.token = token;
				itemConfirmationModel.ItemIds = list;
				if (string.IsNullOrEmpty(SyncTask(itemConfirmationModel, "/api/inventory/ConfirmSyncGroup")))
				{
					using (List<Ids>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass77_4 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass77_4();
							CS_0024_003C_003E8__locals1.group = enumerator2.Current;
							gClass.Groups.Where((Group i) => (long)i.CloudSyncId == CS_0024_003C_003E8__locals1.group.CloudSyncId).FirstOrDefault().Synced = true;
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
					WriteToSyncLog("CloudSync: Groups edited from cloudsync are synced.");
					ItemsAndGroupsStationsRefresh();
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync groups from cloudsync", InventorySyncTimer, "Sync groups from cloudsync failed. " + groupResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncGroups(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Group Sync Process Begins..");
		bool flag = true;
		isCountFinished = false;
		GroupsPostModel groupsPostModel = new GroupsPostModel();
		groupsPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Group> list = gClass.Groups.Where((Group g) => g.Synced == false).Take(40).ToList();
		List<GroupsPostDataModel> list2 = new List<GroupsPostDataModel>();
		if (list != null && list.Count == 0)
		{
			return true;
		}
		foreach (Group item in list)
		{
			GroupsPostDataModel groupsPostDataModel = new GroupsPostDataModel();
			groupsPostDataModel.CloudsyncId = item.CloudSyncId;
			groupsPostDataModel.Active = item.Active;
			groupsPostDataModel.AllowHalfOrder = item.AllowHalfOrder;
			groupsPostDataModel.GroupColor = item.GroupColor;
			groupsPostDataModel.GroupID = item.GroupID;
			groupsPostDataModel.GroupName = item.GroupName;
			groupsPostDataModel.HighTraffic = item.HighTraffic;
			groupsPostDataModel.ParentGroupID = item.ParentGroupID;
			groupsPostDataModel.GroupClassification = item.GroupClassification;
			groupsPostDataModel.Archived = item.Archived;
			groupsPostDataModel.SortOrder = item.SortOrder;
			groupsPostDataModel.OrderEntryShow = item.OrderEntryShow;
			list2.Add(groupsPostDataModel);
		}
		groupsPostModel.ListOfGroups = list2;
		string text = SyncTask(groupsPostModel, "/api/inventory/syncgroup");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(Group g)
			{
				g.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("CloudSync: " + synced_count + " of " + total_count + " groups.");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync groups", InventorySyncTimer, "sync groups failed. " + text);
			flag = false;
		}
		if (synced_count <= total_count && flag)
		{
			isCountFinished = true;
			WriteToSyncLog("CloudSync: All groups are synced.");
		}
		return flag;
	}

	public static bool SyncItems(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Item Sync Process Begins..");
		bool result = true;
		isCountFinished = false;
		ItemsPostModel itemsPostModel = new ItemsPostModel();
		itemsPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Item> list = gClass.Items.Where((Item g) => g.Synced == false || itemsInItemToSyncParentIds.Contains(g.ItemID)).Take(20).ToList();
		List<ItemsPostDataModel> list2 = new List<ItemsPostDataModel>();
		using (List<Item>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass79_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass79_0();
				CS_0024_003C_003E8__locals0.item = enumerator.Current;
				if (CS_0024_003C_003E8__locals0.item.TrackInventory)
				{
					CheckInventoryCountItemModel checkInventoryCountItemModel = check_inventory_items.Where((CheckInventoryCountItemModel a) => a.ItemID == CS_0024_003C_003E8__locals0.item.ItemID).FirstOrDefault();
					if (checkInventoryCountItemModel == null)
					{
						check_inventory_items.Add(new CheckInventoryCountItemModel
						{
							ItemID = CS_0024_003C_003E8__locals0.item.ItemID,
							InventoryCount = CS_0024_003C_003E8__locals0.item.InventoryCount
						});
					}
					else
					{
						checkInventoryCountItemModel.InventoryCount = CS_0024_003C_003E8__locals0.item.InventoryCount;
					}
				}
				ItemsPostDataModel itemsPostDataModel = new ItemsPostDataModel();
				itemsPostDataModel.CloudSyncItemId = CS_0024_003C_003E8__locals0.item.CloudItemID;
				itemsPostDataModel.Active = CS_0024_003C_003E8__locals0.item.Active;
				itemsPostDataModel.AllowCustomPrice = CS_0024_003C_003E8__locals0.item.AllowCustomPrice;
				itemsPostDataModel.AllowProRated = CS_0024_003C_003E8__locals0.item.AllowProRated;
				itemsPostDataModel.Barcode = CS_0024_003C_003E8__locals0.item.Barcode;
				itemsPostDataModel.ItemColor = CS_0024_003C_003E8__locals0.item.ItemColor;
				itemsPostDataModel.ItemCost = CS_0024_003C_003E8__locals0.item.ItemCost;
				itemsPostDataModel.ItemID = CS_0024_003C_003E8__locals0.item.ItemID;
				itemsPostDataModel.ItemName = CS_0024_003C_003E8__locals0.item.ItemName;
				itemsPostDataModel.Description = CS_0024_003C_003E8__locals0.item.Description;
				itemsPostDataModel.ItemPrice = CS_0024_003C_003E8__locals0.item.ItemPrice;
				itemsPostDataModel.ItemSalePrice = (CS_0024_003C_003E8__locals0.item.ItemSalePrice.HasValue ? CS_0024_003C_003E8__locals0.item.ItemSalePrice.Value : 0m);
				itemsPostDataModel.OnSale = CS_0024_003C_003E8__locals0.item.OnSale;
				itemsPostDataModel.StartDateOnSale = CS_0024_003C_003E8__locals0.item.StartDateOnSale;
				itemsPostDataModel.EndDateOnSale = CS_0024_003C_003E8__locals0.item.EndDateOnSale;
				itemsPostDataModel.StartTimeOnSale = CS_0024_003C_003E8__locals0.item.StartTimeOnSale;
				itemsPostDataModel.EndTimeOnSale = CS_0024_003C_003E8__locals0.item.EndTimeOnSale;
				itemsPostDataModel.DaysSaleList = CS_0024_003C_003E8__locals0.item.DaysSaleList;
				itemsPostDataModel.ItemTypeID = CS_0024_003C_003E8__locals0.item.ItemTypeID;
				itemsPostDataModel.SortOrder = CS_0024_003C_003E8__locals0.item.SortOrder;
				itemsPostDataModel.StationID = CS_0024_003C_003E8__locals0.item.StationID;
				itemsPostDataModel.TrackInventory = CS_0024_003C_003E8__locals0.item.TrackInventory;
				itemsPostDataModel.TaxRuleId = CS_0024_003C_003E8__locals0.item.TaxRuleID;
				itemsPostDataModel.isDeleted = CS_0024_003C_003E8__locals0.item.isDeleted;
				itemsPostDataModel.UOM = CS_0024_003C_003E8__locals0.item.UOM.Name;
				itemsPostDataModel.GroupData = new List<ItemInGroupData>();
				itemsPostDataModel.GroupInItemData = new List<GroupInItemData>();
				itemsPostDataModel.SupplierData = new List<ItemSupplierData>();
				itemsPostDataModel.CustomFieldData = new List<ItemCustomFieldData>();
				itemsPostDataModel.ItemsInItemsList = "";
				itemsPostDataModel.ItemClassification = CS_0024_003C_003E8__locals0.item.ItemClassification;
				itemsPostDataModel.MaxFreeOptions = CS_0024_003C_003E8__locals0.item.MaxFreeOptions;
				itemsPostDataModel.MinFreeOptions = CS_0024_003C_003E8__locals0.item.MinFreeOptions;
				itemsPostDataModel.TrackExpiryDate = CS_0024_003C_003E8__locals0.item.TrackExpiryDate;
				itemsPostDataModel.TaxesIncluded = CS_0024_003C_003E8__locals0.item.TaxesIncluded;
				itemsPostDataModel.ItemLongName = CS_0024_003C_003E8__locals0.item.ItemLongName;
				itemsPostDataModel.DisableSoldOutItems = CS_0024_003C_003E8__locals0.item.DisableSoldOutItems;
				itemsPostDataModel.UseSmartBarcode = CS_0024_003C_003E8__locals0.item.UseSmartBarcode;
				itemsPostDataModel.ReOrderLimit = CS_0024_003C_003E8__locals0.item.ReOrderLimit;
				itemsPostDataModel.ReOrderQty = (CS_0024_003C_003E8__locals0.item.ReorderQty.HasValue ? CS_0024_003C_003E8__locals0.item.ReorderQty.Value : 0m);
				if (CS_0024_003C_003E8__locals0.item.ItemsInGroups != null && CS_0024_003C_003E8__locals0.item.ItemsInGroups.Count > 0)
				{
					foreach (ItemsInGroup itemsInGroup in CS_0024_003C_003E8__locals0.item.ItemsInGroups)
					{
						itemsPostDataModel.GroupData.Add(new ItemInGroupData
						{
							GroupId = itemsInGroup.GroupID.Value,
							Color = itemsInGroup.Color,
							SortOrder = itemsInGroup.SortOrder
						});
						itemsInGroup.Synced = true;
					}
				}
				List<ItemsInItem> list3 = gClass.ItemsInItems.Where((ItemsInItem w) => w.ParentItemID == (int?)CS_0024_003C_003E8__locals0.item.ItemID).ToList();
				if (list3 != null && list3.Count > 0)
				{
					foreach (ItemsInItem item in list3)
					{
						ItemsPostDataModel itemsPostDataModel2 = itemsPostDataModel;
						itemsPostDataModel2.ItemsInItemsList = itemsPostDataModel2.ItemsInItemsList + item.ItemID + "|" + item.Quantity + "|" + item.UseChildItemPriceAndTax.ToString() + ";";
						item.Synced = true;
					}
				}
				List<GroupsInItem> list4 = CS_0024_003C_003E8__locals0.item.GroupsInItems.ToList();
				if (list4 != null && list4.Count > 0)
				{
					foreach (GroupsInItem item2 in list4)
					{
						itemsPostDataModel.GroupInItemData.Add(new GroupInItemData
						{
							GroupId = item2.GroupID,
							Qty = item2.Quantity,
							PromptOptions = item2.PromptItemOptions,
							SortOrder = item2.SortOrder
						});
					}
				}
				List<ItemsSupplier> list5 = gClass.ItemsSuppliers.Where((ItemsSupplier w) => w.ItemId == CS_0024_003C_003E8__locals0.item.ItemID).ToList();
				if (list5 != null && list5.Count > 0)
				{
					itemsPostDataModel.SupplierData = list5.Select((ItemsSupplier a) => new ItemSupplierData
					{
						SupplierName = a.Supplier.Name
					}).ToList();
				}
				List<ItemCustomFieldValue> list6 = gClass.ItemCustomFieldValues.Where((ItemCustomFieldValue a) => a.ItemId == CS_0024_003C_003E8__locals0.item.ItemID).ToList();
				if (list6 != null && list6.Count > 0)
				{
					itemsPostDataModel.CustomFieldData = list6.Select((ItemCustomFieldValue a) => new ItemCustomFieldData
					{
						Value = a.Value,
						CustomFieldName = a.CustomField.Value
					}).ToList();
				}
				list2.Add(itemsPostDataModel);
			}
		}
		itemsPostModel.ListOfItems = list2;
		string text = SyncTask(itemsPostModel, "/api/inventory/syncitem");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(Item i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " items.");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync items", InventorySyncTimer, "sync items failed. " + text);
			result = false;
		}
		if (synced_count <= total_count)
		{
			isCountFinished = true;
			WriteToSyncLog("CloudSync: All items are synced.");
		}
		return result;
	}

	public static void SyncImageItems(string token, System.Timers.Timer InventorySyncTimer)
	{
		ImageItemsResponseModel imageItemsResponseModel = JsonConvert.DeserializeObject<ImageItemsResponseModel>(SyncTaskWithResponseData(new ItemPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncItemImages"));
		if (imageItemsResponseModel.code == 200)
		{
			if (imageItemsResponseModel.itemImagesResponseList == null || imageItemsResponseModel.itemImagesResponseList.Count <= 0)
			{
				return;
			}
			List<Ids> list = new List<Ids>();
			GClass6 gClass = new GClass6();
			using (List<ImageItemsPostModel>.Enumerator enumerator = imageItemsResponseModel.itemImagesResponseList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass80_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass80_0();
					CS_0024_003C_003E8__locals0.iImage = enumerator.Current;
					ItemImage itemImage = gClass.ItemImages.Where((ItemImage a) => a.ItemID == CS_0024_003C_003E8__locals0.iImage.ItemId).FirstOrDefault();
					if (itemImage == null)
					{
						ItemImage entity = new ItemImage
						{
							ItemID = CS_0024_003C_003E8__locals0.iImage.ItemId,
							BlobName = CS_0024_003C_003E8__locals0.iImage.BlobName,
							BlobThumbnailName = CS_0024_003C_003E8__locals0.iImage.BlobThumbnailName,
							isNewImage = true
						};
						gClass.ItemImages.InsertOnSubmit(entity);
						Helper.SubmitChangesWithCatch(gClass);
					}
					else if (itemImage.BlobName != CS_0024_003C_003E8__locals0.iImage.BlobName)
					{
						itemImage.BlobName = CS_0024_003C_003E8__locals0.iImage.BlobName;
						itemImage.BlobThumbnailName = CS_0024_003C_003E8__locals0.iImage.BlobThumbnailName;
						itemImage.isNewImage = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					list.Add(new Ids
					{
						PosId = CS_0024_003C_003E8__locals0.iImage.ItemId
					});
					WriteToSyncLog("CloudSync: Item Images syncing...");
				}
			}
			WriteToSyncLog("CloudSync: All item images are synced.");
			if (string.IsNullOrEmpty(SyncTask(new ItemConfirmationModel
			{
				token = token,
				ItemIds = list
			}, "/api/inventory/ConfirmSyncItemImages")))
			{
				WriteToSyncLog("CloudSync: Items Images Confirmed Synced.");
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync item images", InventorySyncTimer, "sync items images failed. " + imageItemsResponseModel.message);
		}
	}

	public static bool SyncInventoryAudits(string token, System.Timers.Timer InventorySyncTimer)
	{
		_003C_003Ec__DisplayClass81_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass81_0();
		CS_0024_003C_003E8__locals0.InventorySyncTimer = InventorySyncTimer;
		WriteToSyncLog("CloudSync: Sync Iventory Audits From Cloudsync Started...");
		sync_inprocess = true;
		bool result = true;
		total_count = inventory_audits_to_sync.Count;
		GClass6 gClass = new GClass6();
		gClass.ItemsInGroups.Select((ItemsInGroup i) => i.ItemID.Value).Distinct().ToList();
		List<InventoryAudit> list = gClass.InventoryAudits.Where((InventoryAudit g) => g.Synced == false).Take(20).ToList();
		InventoryAuditsPostModel inventoryAuditsPostModel = new InventoryAuditsPostModel();
		List<InventoryAuditsPostDataModel> list2 = new List<InventoryAuditsPostDataModel>();
		inventoryAuditsPostModel.token = token;
		foreach (InventoryAudit item4 in list)
		{
			InventoryAuditsPostDataModel item = new InventoryAuditsPostDataModel
			{
				Comment = item4.Comment,
				DateCreated = item4.DateCreated,
				InventoryAuditId = item4.InventoryAuditId,
				ItemID = item4.ItemID,
				Owner = item4.Owner,
				QtyStart = item4.QtyStart,
				QtyChange = item4.QtyChange,
				QtyNew = item4.QtyNew,
				CloudSyncAuditId = item4.CloudInventoryAuditID
			};
			list2.Add(item);
		}
		inventoryAuditsPostModel.inventoryAuditListData = list2;
		CS_0024_003C_003E8__locals0.response = JsonConvert.DeserializeObject<InventoryAuditsResponseModel>(SyncTaskWithResponseData(inventoryAuditsPostModel, "/api/inventory/syncinventoryaudit"));
		if (CS_0024_003C_003E8__locals0.response.code == 200)
		{
			_003C_003Ec__DisplayClass81_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass81_1();
			foreach (InventoryAudit item5 in list)
			{
				item5.Synced = true;
				Helper.SubmitChangesWithCatch(gClass);
				synced_count++;
				WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " inventory audit logs.");
			}
			CS_0024_003C_003E8__locals1.existing_cs_ids = new List<long>();
			CS_0024_003C_003E8__locals1.existing_pos_ids = new List<int>();
			if (CS_0024_003C_003E8__locals0.response.inventoryAuditList != null)
			{
				_003C_003Ec__DisplayClass81_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass81_2();
				List<Item> source = gClass.Items.ToList();
				CS_0024_003C_003E8__locals2.cloud_ids = CS_0024_003C_003E8__locals0.response.inventoryAuditList.Select((InventoryAuditsPostDataModel x) => x.CloudSyncAuditId).ToList();
				CS_0024_003C_003E8__locals2.pos_ids = CS_0024_003C_003E8__locals0.response.inventoryAuditList.Select((InventoryAuditsPostDataModel x) => x.InventoryAuditId).ToList();
				CS_0024_003C_003E8__locals1.existing_cs_ids = (from x in gClass.InventoryAudits
					where CS_0024_003C_003E8__locals2.cloud_ids.Contains(x.CloudInventoryAuditID)
					select x.CloudInventoryAuditID).ToList();
				CS_0024_003C_003E8__locals1.existing_pos_ids = (from x in gClass.InventoryAudits
					where CS_0024_003C_003E8__locals2.pos_ids.Contains(x.InventoryAuditId)
					select x.InventoryAuditId).ToList();
				using IEnumerator<InventoryAuditsPostDataModel> enumerator2 = CS_0024_003C_003E8__locals0.response.inventoryAuditList.Where((InventoryAuditsPostDataModel x) => !CS_0024_003C_003E8__locals1.existing_cs_ids.Contains(x.CloudSyncAuditId) && !CS_0024_003C_003E8__locals1.existing_pos_ids.Contains(x.InventoryAuditId)).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass81_3 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass81_3();
					CS_0024_003C_003E8__locals3.log = enumerator2.Current;
					Item item2 = source.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals3.log.ItemID).FirstOrDefault();
					if (item2 != null)
					{
						InventoryAudit inventoryAudit = new InventoryAudit();
						inventoryAudit.Comment = CS_0024_003C_003E8__locals3.log.Comment;
						inventoryAudit.DateCreated = DateTime.Now;
						inventoryAudit.InventoryAuditId = CS_0024_003C_003E8__locals3.log.InventoryAuditId;
						inventoryAudit.CloudInventoryAuditID = CS_0024_003C_003E8__locals3.log.CloudSyncAuditId;
						inventoryAudit.ItemID = CS_0024_003C_003E8__locals3.log.ItemID;
						inventoryAudit.Owner = CS_0024_003C_003E8__locals3.log.Owner;
						inventoryAudit.QtyStart = item2.InventoryCount;
						inventoryAudit.QtyChange = CS_0024_003C_003E8__locals3.log.QtyChange;
						inventoryAudit.QtyNew = item2.InventoryCount + CS_0024_003C_003E8__locals3.log.QtyChange;
						inventoryAudit.Synced = false;
						inventoryAudit.InventoryType = item2.ItemClassification;
						gClass.InventoryAudits.InsertOnSubmit(inventoryAudit);
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
			}
			InventoryAuditConfirmationModel inventoryAuditConfirmationModel = new InventoryAuditConfirmationModel();
			CS_0024_003C_003E8__locals1.cloudIDs = (from i in gClass.InventoryAudits
				where i.CloudInventoryAuditID != 0L && i.Synced == false
				select i into l
				select l.CloudInventoryAuditID).ToList();
			inventoryAuditConfirmationModel.token = token;
			inventoryAuditConfirmationModel.CloudSyncIdList = CS_0024_003C_003E8__locals1.cloudIDs;
			if (string.IsNullOrEmpty(SyncTask(inventoryAuditConfirmationModel, "/api/inventory/confirmsyncinventoryaudit")))
			{
				foreach (InventoryAudit item6 in gClass.InventoryAudits.Where((InventoryAudit i) => CS_0024_003C_003E8__locals1.cloudIDs.Contains(i.CloudInventoryAuditID) == true).ToList())
				{
					item6.Synced = true;
					Helper.SubmitChangesWithCatch(gClass);
				}
			}
		}
		else if (CS_0024_003C_003E8__locals0.response.code == 405)
		{
			Item item3 = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.response.itemIdNotSynced).FirstOrDefault();
			if (item3 != null)
			{
				item3.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
				items_to_sync = gClass.Items.Where((Item g) => g.Synced == false || itemsInItemToSyncParentIds.Contains(g.ItemID)).ToList();
			}
			FailSync("CloudSync Failed: Failed to sync inventory audit logs", CS_0024_003C_003E8__locals0.InventorySyncTimer, "sync inventory audits failed, " + CS_0024_003C_003E8__locals0.response.message);
			result = false;
		}
		else if (CS_0024_003C_003E8__locals0.response.code == 400)
		{
			if (CS_0024_003C_003E8__locals0.response.inventoryAuditList != null)
			{
				_003C_003Ec__DisplayClass81_4 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass81_4();
				using (List<InventoryAuditsPostDataModel>.Enumerator enumerator3 = CS_0024_003C_003E8__locals0.response.inventoryAuditList.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						_003C_003Ec__DisplayClass81_5 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass81_5();
						CS_0024_003C_003E8__locals5.log = enumerator3.Current;
						_003C_003Ec__DisplayClass81_6 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass81_6();
						CS_0024_003C_003E8__locals6.item = gClass.Items.Where((Item i) => i.ItemID == CS_0024_003C_003E8__locals5.log.ItemID).FirstOrDefault();
						CS_0024_003C_003E8__locals6.item.Synced = false;
						foreach (InventoryAudit item7 in gClass.InventoryAudits.Where((InventoryAudit a) => a.ItemID == CS_0024_003C_003E8__locals6.item.ItemID))
						{
							item7.Synced = false;
						}
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
				CS_0024_003C_003E8__locals4.itemsInItemToSyncParentIds = (from w in gClass.ItemsInItems
					where w.Synced == false && w.ParentItemID.HasValue
					select w.ParentItemID.Value).ToList();
				items_to_sync = gClass.Items.Where((Item g) => (g.Synced == false && g.CloudItemID == 0L && g.ItemsInGroups.Where((ItemsInGroup i) => i.ItemID == (int?)g.ItemID).Count() > 0) || CS_0024_003C_003E8__locals4.itemsInItemToSyncParentIds.Contains(g.ItemID)).ToList();
			}
			FailSync("CloudSync Failed: Failed to sync inventory audit logs", CS_0024_003C_003E8__locals0.InventorySyncTimer, "sync inventory audits failed, " + CS_0024_003C_003E8__locals0.response.message);
			result = false;
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync inventory audit logs", CS_0024_003C_003E8__locals0.InventorySyncTimer, "sync inventory audits failed, " + CS_0024_003C_003E8__locals0.response.message);
			result = false;
		}
		System.Timers.Timer inventorySyncTimer = CS_0024_003C_003E8__locals0.InventorySyncTimer;
		sync_inprocess = false;
		inventorySyncTimer.Enabled = false;
		new Thread((ThreadStart)delegate
		{
			try
			{
				new InventoryMethods().ReconcileInventoryAuditLogs();
			}
			catch (Exception errorResponse)
			{
				FailSync("CloudSync Failed: Failed on reconcile inventory audit logs.", CS_0024_003C_003E8__locals0.InventorySyncTimer, errorResponse);
			}
		}).Start();
		WriteToSyncLog("CloudSync: All inventory audit logs are synced.");
		sync_inprocess = false;
		return result;
	}

	public static bool SyncInventoryBatches(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Inventory Batches From Cloudsync Started...");
		bool flag = true;
		InventoryBatchPostModel inventoryBatchPostModel = new InventoryBatchPostModel();
		inventoryBatchPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<InventoryBatch> list = gClass.InventoryBatches.Where((InventoryBatch g) => g.Synced == false).Take(100).ToList();
		total_count = inventory_batches_to_sync.Count;
		List<InventoryBatchPostDataModel> list2 = new List<InventoryBatchPostDataModel>();
		foreach (InventoryBatch item2 in list)
		{
			InventoryBatchPostDataModel item = new InventoryBatchPostDataModel
			{
				BatchId = item2.Id,
				BatchNumber = item2.BatchNumber,
				ReceivedDate = item2.ReceivedDate,
				ExpiryDate = item2.ExpiryDate,
				Decimal_0 = item2.Decimal_0,
				QTYRemaining = item2.QTYRemaining,
				ItemID = item2.ItemID
			};
			list2.Add(item);
		}
		inventoryBatchPostModel.BatchList = list2;
		InventoryBatchResponseModel inventoryBatchResponseModel = JsonConvert.DeserializeObject<InventoryBatchResponseModel>(SyncTaskWithResponseData(inventoryBatchPostModel, "/api/inventory/SyncInventoryBatches"));
		if (inventoryBatchResponseModel.code == 200)
		{
			list.ForEach(delegate(InventoryBatch i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + "Inventory Batches.");
			if (inventoryBatchResponseModel.BatchList.Count > 0)
			{
				_003C_003Ec__DisplayClass82_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass82_0();
				using (List<InventoryBatchPostDataModel>.Enumerator enumerator2 = inventoryBatchResponseModel.BatchList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass82_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass82_1();
						CS_0024_003C_003E8__locals1.bl = enumerator2.Current;
						if (gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.bl.ItemID).FirstOrDefault() != null)
						{
							InventoryBatch inventoryBatch = gClass.InventoryBatches.Where((InventoryBatch a) => a.Id == CS_0024_003C_003E8__locals1.bl.BatchId).FirstOrDefault();
							if (inventoryBatch != null)
							{
								inventoryBatch.BatchNumber = CS_0024_003C_003E8__locals1.bl.BatchNumber;
								inventoryBatch.ReceivedDate = CS_0024_003C_003E8__locals1.bl.ReceivedDate;
								inventoryBatch.ExpiryDate = CS_0024_003C_003E8__locals1.bl.ExpiryDate;
								inventoryBatch.Decimal_0 = CS_0024_003C_003E8__locals1.bl.Decimal_0;
								inventoryBatch.QTYRemaining = CS_0024_003C_003E8__locals1.bl.QTYRemaining;
								inventoryBatch.ItemID = CS_0024_003C_003E8__locals1.bl.ItemID;
							}
							else
							{
								inventoryBatch = new InventoryBatch
								{
									BatchNumber = CS_0024_003C_003E8__locals1.bl.BatchNumber,
									ReceivedDate = CS_0024_003C_003E8__locals1.bl.ReceivedDate,
									ExpiryDate = CS_0024_003C_003E8__locals1.bl.ExpiryDate,
									Decimal_0 = CS_0024_003C_003E8__locals1.bl.Decimal_0,
									QTYRemaining = CS_0024_003C_003E8__locals1.bl.QTYRemaining,
									ItemID = CS_0024_003C_003E8__locals1.bl.ItemID
								};
								gClass.InventoryBatches.InsertOnSubmit(inventoryBatch);
							}
							Helper.SubmitChangesWithCatch(gClass);
							CS_0024_003C_003E8__locals1.bl.BatchId = inventoryBatch.Id;
						}
					}
				}
				InventoryBatchConfirmationModel inventoryBatchConfirmationModel = new InventoryBatchConfirmationModel();
				CS_0024_003C_003E8__locals0.ids = (from a in inventoryBatchResponseModel.BatchList
					where a.BatchId != 0
					select new Ids
					{
						CloudSyncId = a.CloudsyncId,
						PosId = a.BatchId
					}).ToList();
				inventoryBatchConfirmationModel.idsList = CS_0024_003C_003E8__locals0.ids;
				inventoryBatchConfirmationModel.token = token;
				if (string.IsNullOrEmpty(SyncTask(inventoryBatchConfirmationModel, "/api/inventory/ConfirmSyncInventoryBatch")))
				{
					foreach (InventoryBatch item3 in gClass.InventoryBatches.Where((InventoryBatch a) => CS_0024_003C_003E8__locals0.ids.Select((Ids b) => b.PosId).Contains(a.Id)).ToList())
					{
						item3.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync items", InventorySyncTimer, "Sync Inventory Batch Failed. " + inventoryBatchResponseModel);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("CloudSync: All items are synced.");
		}
		return flag;
	}

	public static bool SyncCheckInventoryCount(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool result = true;
		sync_inprocess = true;
		GClass6 gClass = new GClass6();
		CheckInventoryCountResponseModel checkInventoryCountResponseModel = JsonConvert.DeserializeObject<CheckInventoryCountResponseModel>(SyncTaskWithResponseData(new CheckInventoryCountModel
		{
			token = token,
			Items = check_inventory_items
		}, "/api/inventory/CheckInventoryCount"));
		if (checkInventoryCountResponseModel.code == 200)
		{
			if (checkInventoryCountResponseModel.Items.Count > 0)
			{
				using (List<CheckInventoryCountItemModel>.Enumerator enumerator = checkInventoryCountResponseModel.Items.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass83_0();
						CS_0024_003C_003E8__locals0.invItem = enumerator.Current;
						_003C_003Ec__DisplayClass83_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass83_1();
						CS_0024_003C_003E8__locals1.item = gClass.Items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals0.invItem.ItemID).FirstOrDefault();
						if (CS_0024_003C_003E8__locals1.item == null)
						{
							continue;
						}
						if (CS_0024_003C_003E8__locals0.invItem.InventoryIsGood)
						{
							CS_0024_003C_003E8__locals1.item.LastGoodInventoryReconciledDate = DateTime.Now;
							continue;
						}
						IQueryable<InventoryAudit> source = gClass.InventoryAudits.Where((InventoryAudit a) => a.ItemID == CS_0024_003C_003E8__locals1.item.ItemID);
						if (CS_0024_003C_003E8__locals1.item.LastGoodInventoryReconciledDate.HasValue)
						{
							source = source.Where((InventoryAudit a) => a.DateCreated >= CS_0024_003C_003E8__locals1.item.LastGoodInventoryReconciledDate.Value);
						}
						foreach (InventoryAudit item in source.ToList())
						{
							item.Synced = false;
							item.isReconciled = false;
						}
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			check_inventory_items.Clear();
			WriteToSyncLog("CloudSync: Check inventory sync finished.");
		}
		else
		{
			WriteToSyncLog("CloudSync ERROR: Check inventory sync. " + checkInventoryCountResponseModel.message);
		}
		sync_inprocess = false;
		InventorySyncTimer.Enabled = false;
		return result;
	}

	public static bool SyncTaxRules(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Tax Sync Process Begins..");
		GClass6 gClass = new GClass6();
		bool flag = true;
		TaxRulePostModel taxRulePostModel = new TaxRulePostModel();
		taxRulePostModel.token = token;
		List<TaxRulePostDataModel> list = new List<TaxRulePostDataModel>();
		foreach (TaxRule item4 in gClass.TaxRules.ToList())
		{
			TaxRulePostDataModel item = new TaxRulePostDataModel
			{
				TaxRuleId = item4.TaxRuleId,
				RuleName = item4.RuleName,
				Active = item4.Active
			};
			list.Add(item);
			item4.Synced = true;
		}
		taxRulePostModel.ListOfTaxRule = list;
		string text = SyncTask(taxRulePostModel, "/api/TaxRules/SyncTaxRules");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("CloudSync: Tax Rules Sync Complete");
			flag = true;
			TaxPostModel taxPostModel = new TaxPostModel();
			taxPostModel.token = token;
			List<TaxPostDataModel> list2 = new List<TaxPostDataModel>();
			foreach (Tax item5 in gClass.Taxes.ToList())
			{
				TaxPostDataModel item2 = new TaxPostDataModel
				{
					TaxId = item5.TaxID,
					TaxCode = item5.TaxCode,
					Percentage = item5.Percentage,
					Description = item5.Description,
					Inactive = item5.Inactive
				};
				list2.Add(item2);
				item5.Synced = true;
			}
			taxPostModel.ListOfTax = list2;
			text = SyncTask(taxPostModel, "/api/TaxRules/SyncTax");
			if (string.IsNullOrEmpty(text))
			{
				Helper.SubmitChangesWithCatch(gClass);
				WriteToSyncLog("CloudSync: Taxes Sync Complete.");
				flag = true;
				TaxRuleOperationPostModel taxRuleOperationPostModel = new TaxRuleOperationPostModel();
				taxRuleOperationPostModel.token = token;
				List<TaxRuleOperationPostDataModel> list3 = new List<TaxRuleOperationPostDataModel>();
				foreach (TaxRuleOperation item6 in gClass.TaxRuleOperations.ToList())
				{
					TaxRuleOperationPostDataModel item3 = new TaxRuleOperationPostDataModel
					{
						TaxRuleOperatorId = item6.TaxRuleOperatorId,
						Condition = item6.Condition,
						Operator = item6.Operator,
						TaxID = item6.TaxID,
						TaxRuleId = item6.TaxRuleId,
						TaxRuleRequirementID = item6.TaxRuleRequirementID
					};
					list3.Add(item3);
					item6.Synced = true;
				}
				taxRuleOperationPostModel.ListOfTaxRuleOperation = list3;
				text = SyncTask(taxRuleOperationPostModel, "/api/TaxRules/SyncTaxRuleOperation");
				if (string.IsNullOrEmpty(text))
				{
					Helper.SubmitChangesWithCatch(gClass);
					WriteToSyncLog("CloudSync: Taxes Sync Complete.");
				}
				else
				{
					FailSync("CloudSync Failed: Failed to sync tax rule operation ", InventorySyncTimer, "sync tax rules operation failed, " + text);
					flag = false;
				}
				return flag;
			}
			FailSync("CloudSync Failed: Failed to sync tax ", InventorySyncTimer, "sync taxes failed, " + text);
			flag = false;
			return false;
		}
		FailSync("CloudSync Failed: Failed to sync tax rules", InventorySyncTimer, "sync tax rules failed, " + text);
		flag = false;
		return false;
	}

	public static bool SyncTaxRulesFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		GClass6 gClass = new GClass6();
		bool result = true;
		TaxRulesResponseModel taxRulesResponseModel = JsonConvert.DeserializeObject<TaxRulesResponseModel>(SyncTaskWithResponseData(new TaxResponsePostModel
		{
			token = token
		}, "/api/TaxRules/SyncTaxRulesFromCloudsync"));
		if (taxRulesResponseModel.code == 200)
		{
			if (taxRulesResponseModel.taxRulesResponseList.Count > 0)
			{
				List<Ids> list = new List<Ids>();
				using (List<TaxRulePostDataModel>.Enumerator enumerator = taxRulesResponseModel.taxRulesResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass85_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass85_0();
						CS_0024_003C_003E8__locals5.taxRes = enumerator.Current;
						TaxRule taxRule = gClass.TaxRules.Where((TaxRule a) => a.TaxRuleId == CS_0024_003C_003E8__locals5.taxRes.TaxRuleId).FirstOrDefault();
						if (taxRule != null && taxRule.TaxRuleId != 0)
						{
							taxRule.RuleName = CS_0024_003C_003E8__locals5.taxRes.RuleName;
							taxRule.Active = CS_0024_003C_003E8__locals5.taxRes.Active;
							Helper.SubmitChangesWithCatch(gClass);
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals5.taxRes.TaxRuleCloudsyncId,
								PosId = taxRule.TaxRuleId
							});
						}
						else
						{
							TaxRule taxRule2 = new TaxRule
							{
								RuleName = CS_0024_003C_003E8__locals5.taxRes.RuleName,
								Active = CS_0024_003C_003E8__locals5.taxRes.Active
							};
							gClass.TaxRules.InsertOnSubmit(taxRule2);
							Helper.SubmitChangesWithCatch(gClass);
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals5.taxRes.TaxRuleCloudsyncId,
								PosId = taxRule2.TaxRuleId
							});
						}
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new TaxConfirmationModel
				{
					token = token,
					TaxIds = list
				}, "/api/TaxRules/ConfirmSyncTaxRules")))
				{
					_003C_003Ec__DisplayClass85_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass85_1();
					CS_0024_003C_003E8__locals0.posIds = list.Select((Ids c) => c.PosId).ToList();
					foreach (TaxRule item in gClass.TaxRules.Where((TaxRule i) => CS_0024_003C_003E8__locals0.posIds.Contains(i.TaxRuleId) == true).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("CloudSync: Tax Rules edited from cloudsync are synced.");
				}
			}
			TaxResponseModel taxResponseModel = JsonConvert.DeserializeObject<TaxResponseModel>(SyncTaskWithResponseData(new TaxResponsePostModel
			{
				token = token
			}, "/api/TaxRules/SyncTaxFromCloudsync"));
			if (taxResponseModel.code == 200)
			{
				if (taxResponseModel.taxResponseList.Count > 0)
				{
					List<Ids> list2 = new List<Ids>();
					using (List<TaxPostDataModel>.Enumerator enumerator3 = taxResponseModel.taxResponseList.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							_003C_003Ec__DisplayClass85_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass85_2();
							CS_0024_003C_003E8__locals1.taxRes = enumerator3.Current;
							Tax tax = gClass.Taxes.Where((Tax a) => a.TaxID == CS_0024_003C_003E8__locals1.taxRes.TaxId).FirstOrDefault();
							if (tax != null && tax.TaxID != 0)
							{
								tax.TaxCode = CS_0024_003C_003E8__locals1.taxRes.TaxCode;
								tax.Description = CS_0024_003C_003E8__locals1.taxRes.Description;
								tax.Percentage = CS_0024_003C_003E8__locals1.taxRes.Percentage;
								tax.Inactive = CS_0024_003C_003E8__locals1.taxRes.Inactive;
								Helper.SubmitChangesWithCatch(gClass);
								list2.Add(new Ids
								{
									CloudSyncId = CS_0024_003C_003E8__locals1.taxRes.TaxCloudsyncId,
									PosId = tax.TaxID
								});
							}
							else
							{
								Tax tax2 = new Tax
								{
									TaxCode = CS_0024_003C_003E8__locals1.taxRes.TaxCode,
									Description = CS_0024_003C_003E8__locals1.taxRes.Description,
									Percentage = CS_0024_003C_003E8__locals1.taxRes.Percentage,
									Inactive = CS_0024_003C_003E8__locals1.taxRes.Inactive
								};
								gClass.Taxes.InsertOnSubmit(tax2);
								Helper.SubmitChangesWithCatch(gClass);
								list2.Add(new Ids
								{
									CloudSyncId = CS_0024_003C_003E8__locals1.taxRes.TaxCloudsyncId,
									PosId = tax2.TaxID
								});
							}
						}
					}
					if (string.IsNullOrEmpty(SyncTask(new TaxConfirmationModel
					{
						token = token,
						TaxIds = list2
					}, "/api/TaxRules/ConfirmSyncTax")))
					{
						_003C_003Ec__DisplayClass85_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass85_3();
						CS_0024_003C_003E8__locals2.posIds = list2.Select((Ids c) => c.PosId).ToList();
						foreach (Tax item2 in gClass.Taxes.Where((Tax i) => CS_0024_003C_003E8__locals2.posIds.Contains(i.TaxID) == true).ToList())
						{
							item2.Synced = true;
							Helper.SubmitChangesWithCatch(gClass);
						}
						WriteToSyncLog("CloudSync: Tax edited from cloudsync are synced.");
					}
				}
				TaxRuleOperationResponseModel taxRuleOperationResponseModel = JsonConvert.DeserializeObject<TaxRuleOperationResponseModel>(SyncTaskWithResponseData(new TaxResponsePostModel
				{
					token = token
				}, "/api/TaxRules/SyncTaxRuleOperationFromCloudsync"));
				if (taxRuleOperationResponseModel.code == 200)
				{
					if (taxRuleOperationResponseModel.taxRuleOperationResponseList.Count > 0)
					{
						List<Ids> list3 = new List<Ids>();
						using (List<TaxRuleOperationPostDataModel>.Enumerator enumerator5 = taxRuleOperationResponseModel.taxRuleOperationResponseList.GetEnumerator())
						{
							while (enumerator5.MoveNext())
							{
								_003C_003Ec__DisplayClass85_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass85_4();
								CS_0024_003C_003E8__locals3.taxRes = enumerator5.Current;
								TaxRuleOperation taxRuleOperation = gClass.TaxRuleOperations.Where((TaxRuleOperation a) => a.TaxRuleOperatorId == CS_0024_003C_003E8__locals3.taxRes.TaxRuleOperatorId).FirstOrDefault();
								if (taxRuleOperation != null && taxRuleOperation.TaxRuleOperatorId != 0)
								{
									taxRuleOperation.Condition = CS_0024_003C_003E8__locals3.taxRes.Condition;
									taxRuleOperation.Operator = CS_0024_003C_003E8__locals3.taxRes.Operator;
									taxRuleOperation.TaxRuleRequirementID = CS_0024_003C_003E8__locals3.taxRes.TaxRuleRequirementID;
									taxRuleOperation.TaxID = CS_0024_003C_003E8__locals3.taxRes.TaxID;
									taxRuleOperation.TaxRuleId = CS_0024_003C_003E8__locals3.taxRes.TaxRuleId;
									Helper.SubmitChangesWithCatch(gClass);
									list3.Add(new Ids
									{
										CloudSyncId = CS_0024_003C_003E8__locals3.taxRes.TaxRuleOperatorCloudsyncId,
										PosId = taxRuleOperation.TaxRuleOperatorId
									});
								}
								else
								{
									TaxRuleOperation taxRuleOperation2 = new TaxRuleOperation
									{
										Condition = CS_0024_003C_003E8__locals3.taxRes.Condition,
										Operator = CS_0024_003C_003E8__locals3.taxRes.Operator,
										TaxRuleRequirementID = CS_0024_003C_003E8__locals3.taxRes.TaxRuleRequirementID,
										TaxID = CS_0024_003C_003E8__locals3.taxRes.TaxID,
										TaxRuleId = CS_0024_003C_003E8__locals3.taxRes.TaxRuleId
									};
									gClass.TaxRuleOperations.InsertOnSubmit(taxRuleOperation2);
									Helper.SubmitChangesWithCatch(gClass);
									list3.Add(new Ids
									{
										CloudSyncId = CS_0024_003C_003E8__locals3.taxRes.TaxRuleOperatorCloudsyncId,
										PosId = taxRuleOperation2.TaxRuleOperatorId
									});
								}
							}
						}
						if (string.IsNullOrEmpty(SyncTask(new TaxConfirmationModel
						{
							token = token,
							TaxIds = list3
						}, "/api/TaxRules/ConfirmSyncTaxRuleOperation")))
						{
							_003C_003Ec__DisplayClass85_5 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass85_5();
							CS_0024_003C_003E8__locals4.posIds = list3.Select((Ids c) => c.PosId).ToList();
							foreach (TaxRuleOperation item3 in gClass.TaxRuleOperations.Where((TaxRuleOperation i) => CS_0024_003C_003E8__locals4.posIds.Contains(i.TaxRuleOperatorId) == true).ToList())
							{
								item3.Synced = true;
								Helper.SubmitChangesWithCatch(gClass);
							}
							WriteToSyncLog("CloudSync: Tax Rule Operations edited from cloudsync are synced.");
						}
					}
				}
				else
				{
					FailSync("CloudSync Failed: Failed to sync Tax Rule Operations from cloudsync", InventorySyncTimer, "Sync Tax Rule Operations from cloudsync failed. " + taxResponseModel.message);
					result = false;
				}
				return result;
			}
			FailSync("CloudSync Failed: Failed to sync tax from cloudsync", InventorySyncTimer, "Sync tax from cloudsync failed. " + taxResponseModel.message);
			result = false;
			return false;
		}
		FailSync("CloudSync Failed: Failed to sync tax rules from cloudsync.", InventorySyncTimer, "Sync tax rules from cloudsync failed. " + taxRulesResponseModel.message);
		result = false;
		return false;
	}

	public static bool SyncSuppliers(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Suppliers Sync Process Begins..");
		bool result = true;
		SupplierPostModel supplierPostModel = new SupplierPostModel();
		supplierPostModel.token = token;
		List<SupplierPostDataModel> list = new List<SupplierPostDataModel>();
		GClass6 gClass = new GClass6();
		List<Supplier> list2 = gClass.Suppliers.ToList();
		foreach (Supplier item2 in list2)
		{
			SupplierPostDataModel item = new SupplierPostDataModel
			{
				SupplierName = item2.Name
			};
			list.Add(item);
		}
		supplierPostModel.ListOfSupplier = list;
		string text = SyncTask(supplierPostModel, "/api/inventory/SyncSuppliers");
		if (string.IsNullOrEmpty(text))
		{
			list2.ForEach(delegate(Supplier a)
			{
				a.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("CloudSync: Suppliers Sync Complete");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to Suppliers types.", InventorySyncTimer, "sync Suppliers failed, " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncSuppliersFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Suppliers From Cloudsync Started...");
		bool result = true;
		SupplierResponseModel supplierResponseModel = JsonConvert.DeserializeObject<SupplierResponseModel>(SyncTaskWithResponseData(new SuppliersPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncSuppliersFromCloudsync"));
		if (supplierResponseModel.code == 200)
		{
			if (supplierResponseModel.SupplierList.Count > 0)
			{
				GClass6 gClass = new GClass6();
				if (supplierResponseModel.SupplierList.Count > 0)
				{
					List<string> list = new List<string>();
					using (List<SupplierPostDataModel>.Enumerator enumerator = supplierResponseModel.SupplierList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass87_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass87_0();
							CS_0024_003C_003E8__locals0.supRes = enumerator.Current;
							Supplier supplier = gClass.Suppliers.Where((Supplier a) => a.Name.ToUpper() == CS_0024_003C_003E8__locals0.supRes.SupplierName).FirstOrDefault();
							if (supplier == null)
							{
								supplier = new Supplier
								{
									Name = CS_0024_003C_003E8__locals0.supRes.SupplierName,
									Synced = true
								};
								gClass.Suppliers.InsertOnSubmit(supplier);
							}
							list.Add(CS_0024_003C_003E8__locals0.supRes.SupplierName);
						}
					}
					Helper.SubmitChangesWithCatch(gClass);
					if (string.IsNullOrEmpty(SyncTask(new SupplierConfirmationModel
					{
						token = token,
						SupplierNames = list
					}, "/api/inventory/ConfirmSyncSupplier")))
					{
						WriteToSyncLog("CloudSync: Sync Suppliers From Cloudsync Complete");
					}
				}
			}
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync reasons from cloudsync. ", InventorySyncTimer, "Sync Reasons from cloudsync failed, " + supplierResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncItemTypes(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Item Types Sync Process Begins..");
		bool result = true;
		ItemTypePostModel itemTypePostModel = new ItemTypePostModel();
		itemTypePostModel.token = token;
		List<ItemTypePostDataModel> list = new List<ItemTypePostDataModel>();
		GClass6 gClass = new GClass6();
		foreach (ItemType item2 in gClass.ItemTypes.ToList())
		{
			ItemTypePostDataModel item = new ItemTypePostDataModel
			{
				ItemTypeID = item2.ItemTypeID,
				ItemTypeName = item2.ItemTypeName
			};
			list.Add(item);
			item2.Synced = true;
		}
		itemTypePostModel.ListItemType = list;
		string text = SyncTask(itemTypePostModel, "/api/inventory/SyncItemTypes");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("CloudSync: Item Types Sync Complete");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync item types.", InventorySyncTimer, "sync item types failed, " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncReasons(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool result = true;
		ReasonsPostModel reasonsPostModel = new ReasonsPostModel();
		reasonsPostModel.token = token;
		List<ReasonsDataModel> list = new List<ReasonsDataModel>();
		GClass6 gClass = new GClass6();
		foreach (Reason item2 in gClass.Reasons.ToList())
		{
			ReasonsDataModel item = new ReasonsDataModel
			{
				Value = item2.Value,
				isDefault = item2.isDefault,
				ReasonType = item2.ReasonType
			};
			list.Add(item);
			item2.Synced = true;
		}
		reasonsPostModel.ListReasons = list;
		string text = SyncTask(reasonsPostModel, "/api/inventory/SyncReasons");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync reasons. ", InventorySyncTimer, "Sync Reasons failed," + text);
			result = false;
		}
		return result;
	}

	public static bool SyncReasonsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Reasons From Cloudsync Started...");
		bool result = true;
		ReasonsResponseModel reasonsResponseModel = JsonConvert.DeserializeObject<ReasonsResponseModel>(SyncTaskWithResponseData(new ReasonsPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncReasonsFromCloudsync"));
		if (reasonsResponseModel.code == 200)
		{
			if (reasonsResponseModel.reasonsList.Count > 0)
			{
				GClass6 gClass = new GClass6();
				using (List<ReasonsDataModel>.Enumerator enumerator = reasonsResponseModel.reasonsList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass90_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass90_0();
						CS_0024_003C_003E8__locals1.idmRes = enumerator.Current;
						Reason reason = gClass.Reasons.Where((Reason a) => a.ReasonType == CS_0024_003C_003E8__locals1.idmRes.ReasonType && a.Value.ToLower() == CS_0024_003C_003E8__locals1.idmRes.Value.ToLower()).FirstOrDefault();
						if (reason == null)
						{
							Reason entity = new Reason
							{
								Value = CS_0024_003C_003E8__locals1.idmRes.Value,
								isDefault = CS_0024_003C_003E8__locals1.idmRes.isDefault,
								ReasonType = CS_0024_003C_003E8__locals1.idmRes.ReasonType,
								Synced = false
							};
							gClass.Reasons.InsertOnSubmit(entity);
							Helper.SubmitChangesWithCatch(gClass);
						}
						else
						{
							reason.isDefault = CS_0024_003C_003E8__locals1.idmRes.isDefault;
							reason.Synced = false;
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
				}
				List<Reason> list = gClass.Reasons.Where((Reason a) => a.Synced == true).ToList();
				if (gClass.Reasons.ToList().Count > list.Count)
				{
					using List<Reason>.Enumerator enumerator2 = list.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass90_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass90_1();
						CS_0024_003C_003E8__locals0.reasonToDelete = enumerator2.Current;
						if (!(CS_0024_003C_003E8__locals0.reasonToDelete.ReasonType == ReasonTypes.option_tab) || gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ToBeDeleted == false && a.Tab.ToLower() == CS_0024_003C_003E8__locals0.reasonToDelete.Value.ToLower()).Count() <= 0)
						{
							gClass.Reasons.DeleteOnSubmit(CS_0024_003C_003E8__locals0.reasonToDelete);
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new ReasonsPostResponseModel
				{
					token = token
				}, "/api/inventory/ConfirmSyncReasons")))
				{
					foreach (Reason item in gClass.Reasons.Where((Reason a) => a.Synced == false).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					return result;
				}
			}
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync reasons from cloudsync. ", InventorySyncTimer, "Sync Reasons from cloudsync failed, " + reasonsResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncOptions(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool result = true;
		OptionsPostModel optionsPostModel = new OptionsPostModel();
		optionsPostModel.token = token;
		List<OptionsDataModel> list = new List<OptionsDataModel>();
		GClass6 gClass = new GClass6();
		foreach (Option item2 in gClass.Options.ToList())
		{
			OptionsDataModel item = new OptionsDataModel
			{
				OptionID = item2.OptionID,
				ItemID = item2.ItemID.Value,
				SpecialPrice = (item2.SpecialPrice.HasValue ? item2.SpecialPrice.Value : 0m),
				AllowAdditional = item2.AllowAdditional
			};
			list.Add(item);
			item2.Synced = true;
		}
		optionsPostModel.ListOptions = list;
		string text = SyncTask(optionsPostModel, "/api/inventory/SyncOptions");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("CloudSync: Options Sync Completed.");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Options.", InventorySyncTimer, "sync options failed, " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncOptionsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Child Options From Cloudsync Started...");
		bool result = true;
		OptionResponseModel optionResponseModel = JsonConvert.DeserializeObject<OptionResponseModel>(SyncTaskWithResponseData(new OptionPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncOptionsFromCloudSync"));
		if (optionResponseModel.code == 200)
		{
			if (optionResponseModel.optionsList.Count > 0)
			{
				GClass6 gClass = new GClass6();
				List<Ids> list = new List<Ids>();
				List<Option> source = gClass.Options.ToList();
				List<Item> source2 = gClass.Items.ToList();
				using (List<OptionsDataModel>.Enumerator enumerator = optionResponseModel.optionsList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass92_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass92_0();
						CS_0024_003C_003E8__locals1.optionRes = enumerator.Current;
						Option option = source.Where((Option i) => i.OptionID == CS_0024_003C_003E8__locals1.optionRes.OptionID).FirstOrDefault();
						Item item = source2.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.optionRes.ItemID).FirstOrDefault();
						if (option != null && CS_0024_003C_003E8__locals1.optionRes.OptionID != 0 && item != null)
						{
							option.ItemID = CS_0024_003C_003E8__locals1.optionRes.ItemID;
							Helper.SubmitChangesWithCatch(gClass);
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals1.optionRes.CloudsyncOptionId,
								PosId = option.OptionID
							});
						}
						else if ((option == null && CS_0024_003C_003E8__locals1.optionRes.OptionID != 0) || item == null)
						{
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals1.optionRes.CloudsyncOptionId,
								PosId = -1
							});
						}
						else
						{
							option = gClass.Options.Where((Option a) => a.ItemID == (int?)CS_0024_003C_003E8__locals1.optionRes.ItemID).FirstOrDefault();
							if (option == null)
							{
								Option option2 = new Option
								{
									ItemID = CS_0024_003C_003E8__locals1.optionRes.ItemID
								};
								gClass.Options.InsertOnSubmit(option2);
								Helper.SubmitChangesWithCatch(gClass);
								list.Add(new Ids
								{
									CloudSyncId = CS_0024_003C_003E8__locals1.optionRes.CloudsyncOptionId,
									PosId = option2.OptionID
								});
							}
							else
							{
								list.Add(new Ids
								{
									CloudSyncId = CS_0024_003C_003E8__locals1.optionRes.CloudsyncOptionId,
									PosId = option.OptionID
								});
							}
						}
						if (option != null && (item == null || (item != null && item.isDeleted)))
						{
							gClass.Options.DeleteOnSubmit(option);
						}
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new OptionConfirmationModel
				{
					token = token,
					OptionIds = list
				}, "/api/inventory/ConfirmSyncOptions")))
				{
					_003C_003Ec__DisplayClass92_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass92_1();
					CS_0024_003C_003E8__locals0.posIds = list.Select((Ids c) => c.PosId).ToList();
					foreach (Option item2 in gClass.Options.Where((Option i) => CS_0024_003C_003E8__locals0.posIds.Contains(i.OptionID) == true).ToList())
					{
						item2.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("CloudSync: Options edited from cloudsync are synced.");
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync options from cloudsync.", InventorySyncTimer, "Sync options from cloudsync failed. " + optionResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncItemsWithOption(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Item Options Sync Process Begins..");
		bool result = true;
		ItemsWithOptionPostModel itemsWithOptionPostModel = new ItemsWithOptionPostModel();
		itemsWithOptionPostModel.token = token;
		GClass6 gClass = new GClass6();
		List<ItemsWithOptionDataModel> list = new List<ItemsWithOptionDataModel>();
		total_count = itemsWithOption_to_sync.Count;
		List<ItemsWithOption> list2 = gClass.ItemsWithOptions.Where((ItemsWithOption g) => g.Synced == false).Take(100).ToList();
		foreach (ItemsWithOption item2 in list2)
		{
			ItemsWithOptionDataModel item = new ItemsWithOptionDataModel
			{
				Notes = item2.Notes,
				ItemWithOptionID = item2.ItemWithOptionID,
				OptionID = item2.OptionID.Value,
				ItemID = item2.ItemID.Value,
				Price = item2.Price,
				AllowAdditional = item2.AllowAdditional,
				Qty = item2.Qty,
				Tab = item2.Tab,
				GroupId = item2.GroupID,
				ToBeDeleted = item2.ToBeDeleted,
				MaxGroupOptions = item2.MaxGroupOptions,
				MinGroupOptions = item2.MinGroupOptions,
				GroupOrderTypes = item2.GroupOrderTypes,
				Preselect = item2.Preselect,
				Color = item2.Color,
				GroupDependency = item2.GroupDependency,
				OptionDependency = item2.OptionDependency,
				SortOrder = item2.SortOrder,
				MaxFreeOptionPerGroup = item2.MaxFreeOptionPerGroup,
				ExcludeFromFreeOption = item2.ExcludeFromFreeOption
			};
			list.Add(item);
			item2.Synced = true;
		}
		itemsWithOptionPostModel.ListItemsWithOption = list;
		string text = SyncTask(itemsWithOptionPostModel, "/api/inventory/SyncItemsWithOption");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
			int num = gClass.ItemsWithOptions.Where((ItemsWithOption g) => g.Synced == false).Count();
			synced_count = total_count - num;
			string text2 = "";
			text2 = ((total_count > synced_count) ? (synced_count + " out of " + total_count + " Item Options synced.") : "CloudSync: Item Options Sync Complete.");
			WriteToSyncLog(text2);
			List<ItemsWithOption> list3 = list2.Where((ItemsWithOption a) => a.ToBeDeleted).ToList();
			if (list3.Count > 0)
			{
				gClass.ItemsWithOptions.DeleteAllOnSubmit(list3);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Options on Items.", InventorySyncTimer, "sync options on items failed, " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncItemsWithOptionFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Item Options From Cloudsync Started...");
		bool result = true;
		ItemsWithOptionResponseModel itemsWithOptionResponseModel = JsonConvert.DeserializeObject<ItemsWithOptionResponseModel>(SyncTaskWithResponseData(new ItemsWithOptionPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncItemsWithOptionFromCloudsync"));
		if (itemsWithOptionResponseModel.code == 200)
		{
			if (itemsWithOptionResponseModel.itemsWithOptionList.Count > 0)
			{
				GClass6 gClass = new GClass6();
				List<Ids> list = new List<Ids>();
				using (List<ItemsWithOptionDataModel>.Enumerator enumerator = itemsWithOptionResponseModel.itemsWithOptionList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass94_0 _003C_003Ec__DisplayClass94_ = new _003C_003Ec__DisplayClass94_0();
						_003C_003Ec__DisplayClass94_.iwoRes = enumerator.Current;
						_003C_003Ec__DisplayClass94_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass94_1();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass94_;
						CS_0024_003C_003E8__locals1.existingIwo = gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemWithOptionID == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemWithOptionID).FirstOrDefault();
						if (CS_0024_003C_003E8__locals1.existingIwo == null)
						{
							CS_0024_003C_003E8__locals1.existingIwo = gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemID && i.OptionID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionID && i.ToBeDeleted == false && i.Tab.ToLower() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab.ToLower()).FirstOrDefault();
						}
						if (gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemID && i.OptionID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionID && i.ToBeDeleted == false && i.Tab.ToLower() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab.ToLower()).Count() > 1 && CS_0024_003C_003E8__locals1.existingIwo != null)
						{
							gClass.ItemsWithOptions.Where((ItemsWithOption i) => i.ItemID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemID && i.OptionID == (int?)CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionID && i.ToBeDeleted == false && i.Tab.ToLower() == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab.ToLower() && CS_0024_003C_003E8__locals1.existingIwo.ItemWithOptionID != i.ItemWithOptionID).ToList().ForEach(delegate(ItemsWithOption a)
							{
								a.ToBeDeleted = true;
							});
						}
						if (CS_0024_003C_003E8__locals1.existingIwo != null && CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemWithOptionID != 0)
						{
							CS_0024_003C_003E8__locals1.existingIwo.Notes = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Notes;
							CS_0024_003C_003E8__locals1.existingIwo.ItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemID;
							CS_0024_003C_003E8__locals1.existingIwo.OptionID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionID;
							CS_0024_003C_003E8__locals1.existingIwo.Price = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Price;
							CS_0024_003C_003E8__locals1.existingIwo.Qty = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Qty;
							CS_0024_003C_003E8__locals1.existingIwo.Tab = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab;
							CS_0024_003C_003E8__locals1.existingIwo.AllowAdditional = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.AllowAdditional;
							CS_0024_003C_003E8__locals1.existingIwo.ToBeDeleted = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ToBeDeleted;
							CS_0024_003C_003E8__locals1.existingIwo.GroupID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.GroupId;
							CS_0024_003C_003E8__locals1.existingIwo.MaxGroupOptions = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MaxGroupOptions;
							CS_0024_003C_003E8__locals1.existingIwo.MinGroupOptions = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MinGroupOptions;
							CS_0024_003C_003E8__locals1.existingIwo.GroupOrderTypes = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.GroupOrderTypes;
							CS_0024_003C_003E8__locals1.existingIwo.Color = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Color;
							CS_0024_003C_003E8__locals1.existingIwo.Preselect = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Preselect;
							CS_0024_003C_003E8__locals1.existingIwo.OptionDependency = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionDependency;
							CS_0024_003C_003E8__locals1.existingIwo.SortOrder = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.SortOrder;
							CS_0024_003C_003E8__locals1.existingIwo.MaxFreeOptionPerGroup = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MaxFreeOptionPerGroup;
							CS_0024_003C_003E8__locals1.existingIwo.ExcludeFromFreeOption = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ExcludeFromFreeOption;
							Helper.SubmitChangesWithCatch(gClass);
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.CloudsyncItemWithOptionID,
								PosId = CS_0024_003C_003E8__locals1.existingIwo.ItemWithOptionID
							});
							continue;
						}
						if (CS_0024_003C_003E8__locals1.existingIwo == null && CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemWithOptionID != 0)
						{
							list.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.CloudsyncItemWithOptionID,
								PosId = -1
							});
							continue;
						}
						Reason reason = gClass.Reasons.Where((Reason a) => a.Value == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab && a.ReasonType == ReasonTypes.option_tab).FirstOrDefault();
						if (reason == null)
						{
							reason = new Reason();
							reason.Value = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Tab;
							reason.ReasonType = ReasonTypes.option_tab;
							gClass.Reasons.InsertOnSubmit(reason);
							Helper.SubmitChangesWithCatch(gClass);
						}
						ItemsWithOption itemsWithOption = new ItemsWithOption
						{
							Notes = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Notes,
							ItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ItemID,
							OptionID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionID,
							Price = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Price,
							AllowAdditional = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.AllowAdditional,
							GroupID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.GroupId,
							Tab = reason.Value,
							Qty = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Qty,
							Synced = true,
							ToBeDeleted = false,
							MaxGroupOptions = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MaxGroupOptions,
							MinGroupOptions = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MinGroupOptions,
							GroupOrderTypes = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.GroupOrderTypes,
							Color = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Color,
							Preselect = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.Preselect,
							SortOrder = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.SortOrder,
							OptionDependency = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.OptionDependency,
							MaxFreeOptionPerGroup = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.MaxFreeOptionPerGroup,
							ExcludeFromFreeOption = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.ExcludeFromFreeOption
						};
						gClass.ItemsWithOptions.InsertOnSubmit(itemsWithOption);
						Helper.SubmitChangesWithCatch(gClass);
						list.Add(new Ids
						{
							CloudSyncId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.iwoRes.CloudsyncItemWithOptionID,
							PosId = itemsWithOption.ItemWithOptionID
						});
					}
				}
				gClass.ItemsWithOptions.DeleteAllOnSubmit(gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.ToBeDeleted == true));
				if (string.IsNullOrEmpty(SyncTask(new ItemsWithOptionConfirmationModel
				{
					token = token,
					ItemsWithOptionIds = list
				}, "/api/inventory/ConfirmSyncItemsWithOption")))
				{
					_003C_003Ec__DisplayClass94_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass94_2();
					CS_0024_003C_003E8__locals0.posIds = list.Select((Ids c) => c.PosId).ToList();
					foreach (ItemsWithOption item in gClass.ItemsWithOptions.Where((ItemsWithOption i) => CS_0024_003C_003E8__locals0.posIds.Contains(i.ItemWithOptionID) == true).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("CloudSync: Items With Options edited from cloudsync are synced.");
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Items with Options from cloudsync.", InventorySyncTimer, "Sync Items with Options from cloudsync failed. " + itemsWithOptionResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncInstructions(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Instructions Sync Process Begins..");
		bool result = true;
		InstructionsPostModel instructionsPostModel = new InstructionsPostModel();
		instructionsPostModel.token = token;
		List<InstructionsDataModel> list = new List<InstructionsDataModel>();
		GClass6 gClass = new GClass6();
		foreach (SpecialInstruction item2 in gClass.SpecialInstructions.ToList())
		{
			InstructionsDataModel item = new InstructionsDataModel
			{
				SpecialInstructionID = item2.SpecialInstructionID,
				Instruction = item2.Instruction
			};
			list.Add(item);
			item2.Synced = true;
		}
		instructionsPostModel.ListOfInstructions = list;
		string text = SyncTask(instructionsPostModel, "/api/inventory/SyncInstructions");
		if (string.IsNullOrEmpty(text))
		{
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("CloudSync: Instructions Sync Complete.");
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Instructions.", InventorySyncTimer, "sync instructions failed, " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncInstructionsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Instructions From Cloudsync Started...");
		bool result = true;
		InstructionsResponseModel instructionsResponseModel = JsonConvert.DeserializeObject<InstructionsResponseModel>(SyncTaskWithResponseData(new InstructionsPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncInstructionsFromCloudsync"));
		if (instructionsResponseModel.code == 200)
		{
			if (instructionsResponseModel.instructionsList.Count > 0)
			{
				_003C_003Ec__DisplayClass96_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass96_0();
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals1.idsToConfirm = new List<Ids>();
				using (List<InstructionsDataModel>.Enumerator enumerator = instructionsResponseModel.instructionsList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass96_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass96_1();
						CS_0024_003C_003E8__locals2.idmRes = enumerator.Current;
						SpecialInstruction specialInstruction = gClass.SpecialInstructions.Where((SpecialInstruction i) => i.SpecialInstructionID == CS_0024_003C_003E8__locals2.idmRes.SpecialInstructionID).FirstOrDefault();
						if (specialInstruction != null && CS_0024_003C_003E8__locals2.idmRes.SpecialInstructionID != 0)
						{
							specialInstruction.Instruction = CS_0024_003C_003E8__locals2.idmRes.Instruction;
							Helper.SubmitChangesWithCatch(gClass);
							CS_0024_003C_003E8__locals1.idsToConfirm.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals2.idmRes.CloudsyncInstructionID,
								PosId = specialInstruction.SpecialInstructionID
							});
						}
						else if (specialInstruction == null && CS_0024_003C_003E8__locals2.idmRes.SpecialInstructionID != 0)
						{
							CS_0024_003C_003E8__locals1.idsToConfirm.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals2.idmRes.CloudsyncInstructionID,
								PosId = -1
							});
						}
						else
						{
							SpecialInstruction specialInstruction2 = new SpecialInstruction
							{
								Instruction = CS_0024_003C_003E8__locals2.idmRes.Instruction
							};
							gClass.SpecialInstructions.InsertOnSubmit(specialInstruction2);
							Helper.SubmitChangesWithCatch(gClass);
							CS_0024_003C_003E8__locals1.idsToConfirm.Add(new Ids
							{
								CloudSyncId = CS_0024_003C_003E8__locals2.idmRes.CloudsyncInstructionID,
								PosId = specialInstruction2.SpecialInstructionID
							});
						}
					}
				}
				gClass.SpecialInstructions.DeleteAllOnSubmit(gClass.SpecialInstructions.Where((SpecialInstruction a) => !CS_0024_003C_003E8__locals1.idsToConfirm.Select((Ids b) => b.PosId).Contains(a.SpecialInstructionID)));
				if (string.IsNullOrEmpty(SyncTask(new InstructionConfirmationModel
				{
					token = token,
					InstructionIds = CS_0024_003C_003E8__locals1.idsToConfirm
				}, "/api/inventory/ConfirmSyncInstructions")))
				{
					_003C_003Ec__DisplayClass96_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass96_2();
					CS_0024_003C_003E8__locals0.posIds = CS_0024_003C_003E8__locals1.idsToConfirm.Select((Ids c) => c.PosId).ToList();
					foreach (SpecialInstruction item in gClass.SpecialInstructions.Where((SpecialInstruction i) => CS_0024_003C_003E8__locals0.posIds.Contains(i.SpecialInstructionID) == true).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("CloudSync: Instructions edited from cloudsync are synced.");
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Instructions from cloudsync.", InventorySyncTimer, "Sync instructions from cloudsync failed. " + instructionsResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncDiscountCodesFromCLoudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Discount Codes From Cloudsync Started...");
		bool result = true;
		StatusCodeResponseDiscountCodeStore statusCodeResponseDiscountCodeStore = JsonConvert.DeserializeObject<StatusCodeResponseDiscountCodeStore>(SyncTaskWithResponseData(new DiscountCodePostResponseModel
		{
			token = token
		}, "/api/inventory/SyncDiscountCodesFromCloudsync"));
		if (statusCodeResponseDiscountCodeStore.code == 200)
		{
			if (statusCodeResponseDiscountCodeStore.DicountCodeList.Count > 0)
			{
				_003C_003Ec__DisplayClass97_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass97_0();
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.idsToConfirm = new List<long>();
				using (List<DiscountCodeDataModelStore>.Enumerator enumerator = statusCodeResponseDiscountCodeStore.DicountCodeList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass97_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass97_1();
						CS_0024_003C_003E8__locals1.dcRes = enumerator.Current;
						DiscountCode discountCode = gClass.DiscountCodes.Where((DiscountCode a) => a.CloudsyncId == CS_0024_003C_003E8__locals1.dcRes.CloudsyncId).FirstOrDefault();
						if (discountCode == null)
						{
							discountCode = new DiscountCode();
							gClass.DiscountCodes.InsertOnSubmit(discountCode);
						}
						discountCode.Code = CS_0024_003C_003E8__locals1.dcRes.Code;
						discountCode.Description = CS_0024_003C_003E8__locals1.dcRes.Description;
						discountCode.AvailableInStore = CS_0024_003C_003E8__locals1.dcRes.AvailableInStore;
						discountCode.AvailableOnline = CS_0024_003C_003E8__locals1.dcRes.AvailableOnline;
						discountCode.CloudsyncId = CS_0024_003C_003E8__locals1.dcRes.CloudsyncId;
						discountCode.DiscountAmount = CS_0024_003C_003E8__locals1.dcRes.DiscountAmount;
						discountCode.String_0 = CS_0024_003C_003E8__locals1.dcRes.String_0;
						discountCode.StartDate = CS_0024_003C_003E8__locals1.dcRes.StartDate;
						discountCode.EndDate = CS_0024_003C_003E8__locals1.dcRes.EndDate;
						discountCode.DiscountCodeCount = CS_0024_003C_003E8__locals1.dcRes.DiscountCodeCount;
						discountCode.UsedCount = CS_0024_003C_003E8__locals1.dcRes.UsedCount;
						discountCode.OneTimeUse = CS_0024_003C_003E8__locals1.dcRes.OneTimeUse;
						Helper.SubmitChangesWithCatch(gClass);
						CS_0024_003C_003E8__locals0.idsToConfirm.Add(CS_0024_003C_003E8__locals1.dcRes.CloudsyncId);
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new DiscountCodeConfirmationModel
				{
					token = token,
					Ids = CS_0024_003C_003E8__locals0.idsToConfirm
				}, "/api/inventory/ConfirmSyncDiscountCodes")))
				{
					foreach (DiscountCode item in gClass.DiscountCodes.Where((DiscountCode i) => CS_0024_003C_003E8__locals0.idsToConfirm.Contains(i.CloudsyncId) == true).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("Cloudsync: Discount codes from cloudsync synced.");
				}
			}
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync discount codes.", InventorySyncTimer, "Cloudsync: Discount code sync failed " + statusCodeResponseDiscountCodeStore.message);
			result = false;
		}
		return result;
	}

	public static bool SyncReservations(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Reservations From Cloudsync Started...");
		bool flag = true;
		GClass6 gClass = new GClass6();
		AppointmentPostData appointmentPostData = new AppointmentPostData();
		appointmentPostData.token = token;
		appointmentPostData.ListOfAppointment = new List<AppointmentPostModel>();
		if (appointments_to_sync.Count > 0)
		{
			List<AppointmentPostModel> list = new List<AppointmentPostModel>();
			list = (appointmentPostData.ListOfAppointment = appointments_to_sync.Select((Appointment a) => new AppointmentPostModel
			{
				AppointmentID = a.AppointmentID,
				EmployeeID = a.EmployeeID,
				StartDateTime = a.StartDateTime,
				EndDateTime = a.EndDateTime,
				CustomerName = a.CustomerName,
				CustomerCell = a.CustomerCell,
				CustomerHome = a.CustomerHome,
				CustomerEmail = a.CustomerEmail,
				Comments = a.Comments,
				NumOfPeople = a.NumOfPeople,
				SMSSent = a.SMSSent,
				isNoShow = a.isNoShow,
				ReminderDismissed = a.ReminderDismissed,
				EmailSent = a.EmailSent,
				isCancelled = a.isCancelled,
				NextNotifyDateTime = a.NextNotifyDateTime,
				DateCreated = a.DateCreated,
				AppointmentType = a.AppointmentType,
				DateUpdated = a.DateUpdated,
				IsCleared = a.IsCleared
			}).ToList());
			WriteToSyncLog("CloudSync: Reservations Syncing...");
		}
		AppointmentResponseModel appointmentResponseModel = JsonConvert.DeserializeObject<AppointmentResponseModel>(SyncTaskWithResponseData(appointmentPostData, "/api/Reservation/SyncReservations"));
		if (appointmentResponseModel.code == 200)
		{
			if (appointmentPostData.ListOfAppointment != null && appointmentPostData.ListOfAppointment.Count > 0)
			{
				gClass.Appointments.Where((Appointment s) => s.Synced == false).ToList().ForEach(delegate(Appointment a)
				{
					a.Synced = true;
				});
				Helper.SubmitChangesWithCatch(gClass);
			}
			if (appointmentResponseModel.appointmentResponseList != null && appointmentResponseModel.appointmentResponseList.Count > 0)
			{
				_003C_003Ec__DisplayClass98_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass98_0();
				CS_0024_003C_003E8__locals0.reservationIds = new List<Ids>();
				using (List<AppointmentPostModel>.Enumerator enumerator = appointmentResponseModel.appointmentResponseList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass98_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass98_1();
						CS_0024_003C_003E8__locals1.rsrv = enumerator.Current;
						int num = 0;
						if (CS_0024_003C_003E8__locals1.rsrv.AppointmentID == 0)
						{
							Appointment appointment = new Appointment
							{
								AppointmentID = CS_0024_003C_003E8__locals1.rsrv.AppointmentID,
								EmployeeID = CS_0024_003C_003E8__locals1.rsrv.EmployeeID,
								StartDateTime = CS_0024_003C_003E8__locals1.rsrv.StartDateTime,
								EndDateTime = CS_0024_003C_003E8__locals1.rsrv.EndDateTime,
								CustomerName = CS_0024_003C_003E8__locals1.rsrv.CustomerName,
								CustomerCell = CS_0024_003C_003E8__locals1.rsrv.CustomerCell,
								CustomerHome = CS_0024_003C_003E8__locals1.rsrv.CustomerHome,
								CustomerEmail = CS_0024_003C_003E8__locals1.rsrv.CustomerEmail,
								Comments = CS_0024_003C_003E8__locals1.rsrv.Comments,
								NumOfPeople = CS_0024_003C_003E8__locals1.rsrv.NumOfPeople,
								SMSSent = CS_0024_003C_003E8__locals1.rsrv.SMSSent,
								isNoShow = CS_0024_003C_003E8__locals1.rsrv.isNoShow,
								ReminderDismissed = CS_0024_003C_003E8__locals1.rsrv.ReminderDismissed,
								EmailSent = CS_0024_003C_003E8__locals1.rsrv.EmailSent,
								isCancelled = CS_0024_003C_003E8__locals1.rsrv.isCancelled,
								NextNotifyDateTime = CS_0024_003C_003E8__locals1.rsrv.NextNotifyDateTime,
								DateCreated = CS_0024_003C_003E8__locals1.rsrv.DateCreated,
								AppointmentType = CS_0024_003C_003E8__locals1.rsrv.AppointmentType,
								IsCleared = CS_0024_003C_003E8__locals1.rsrv.IsCleared,
								DateUpdated = CS_0024_003C_003E8__locals1.rsrv.DateUpdated,
								Synced = false
							};
							gClass.Appointments.InsertOnSubmit(appointment);
							Helper.SubmitChangesWithCatch(gClass);
							num = appointment.AppointmentID;
						}
						else
						{
							Appointment appointment2 = gClass.Appointments.Where((Appointment a) => a.AppointmentID == CS_0024_003C_003E8__locals1.rsrv.AppointmentID).FirstOrDefault();
							appointment2.AppointmentID = CS_0024_003C_003E8__locals1.rsrv.AppointmentID;
							appointment2.EmployeeID = CS_0024_003C_003E8__locals1.rsrv.EmployeeID;
							appointment2.StartDateTime = CS_0024_003C_003E8__locals1.rsrv.StartDateTime;
							appointment2.EndDateTime = CS_0024_003C_003E8__locals1.rsrv.EndDateTime;
							appointment2.CustomerName = CS_0024_003C_003E8__locals1.rsrv.CustomerName;
							appointment2.CustomerCell = CS_0024_003C_003E8__locals1.rsrv.CustomerCell;
							appointment2.CustomerEmail = CS_0024_003C_003E8__locals1.rsrv.CustomerEmail;
							appointment2.CustomerHome = CS_0024_003C_003E8__locals1.rsrv.CustomerHome;
							appointment2.Comments = CS_0024_003C_003E8__locals1.rsrv.Comments;
							appointment2.NumOfPeople = CS_0024_003C_003E8__locals1.rsrv.NumOfPeople;
							appointment2.SMSSent = CS_0024_003C_003E8__locals1.rsrv.SMSSent;
							appointment2.isNoShow = CS_0024_003C_003E8__locals1.rsrv.isNoShow;
							appointment2.ReminderDismissed = CS_0024_003C_003E8__locals1.rsrv.ReminderDismissed;
							appointment2.EmailSent = CS_0024_003C_003E8__locals1.rsrv.EmailSent;
							appointment2.isCancelled = CS_0024_003C_003E8__locals1.rsrv.isCancelled;
							appointment2.NextNotifyDateTime = CS_0024_003C_003E8__locals1.rsrv.NextNotifyDateTime;
							appointment2.DateCreated = CS_0024_003C_003E8__locals1.rsrv.DateCreated;
							appointment2.DateUpdated = CS_0024_003C_003E8__locals1.rsrv.DateUpdated;
							appointment2.AppointmentType = CS_0024_003C_003E8__locals1.rsrv.AppointmentType;
							appointment2.IsCleared = CS_0024_003C_003E8__locals1.rsrv.IsCleared;
							appointment2.Synced = false;
							Helper.SubmitChangesWithCatch(gClass);
							num = appointment2.AppointmentID;
						}
						CS_0024_003C_003E8__locals0.reservationIds.Add(new Ids
						{
							CloudSyncId = CS_0024_003C_003E8__locals1.rsrv.CloudsyncAppointmentID,
							PosId = num
						});
					}
				}
				ConfirmSyncAppointmentModel confirmSyncAppointmentModel = new ConfirmSyncAppointmentModel();
				if (CS_0024_003C_003E8__locals0.reservationIds.Count > 0)
				{
					confirmSyncAppointmentModel.token = token;
					confirmSyncAppointmentModel.ListOfCloudsyncAppointmentId = CS_0024_003C_003E8__locals0.reservationIds;
					if (string.IsNullOrEmpty(SyncTask(confirmSyncAppointmentModel, "/api/Reservation/ConfirmSyncReservations")))
					{
						foreach (Appointment item in gClass.Appointments.Where((Appointment i) => CS_0024_003C_003E8__locals0.reservationIds.Select((Ids a) => a.PosId).Contains(i.AppointmentID) == true).ToList())
						{
							item.Synced = true;
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Reservations.", InventorySyncTimer, "sync reservations failed, " + appointmentResponseModel.message);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("CloudSync: All Reservations are synced.");
		}
		return flag;
	}

	public static bool SyncMembers(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("Members Sync Process Begins..");
		bool flag = true;
		CustomersPostModel customersPostModel = new CustomersPostModel();
		customersPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Customer> list = gClass.Customers.Where((Customer g) => g.Synced == false).Take(20).ToList();
		total_count = members_to_sync.Count;
		List<CustomersPostDataModel> list2 = new List<CustomersPostDataModel>();
		foreach (Customer item2 in list)
		{
			Guid? guid = null;
			guid = ((!item2.CloudsyncGUID.HasValue) ? new Guid?(Guid.NewGuid()) : item2.CloudsyncGUID);
			CustomersPostDataModel item = new CustomersPostDataModel
			{
				CustomerID = item2.CustomerID,
				EmployeeID = item2.EmployeeID,
				EmployeeName = item2.Employee.FirstName + " " + item2.Employee.LastName,
				CustomerEmail = item2.CustomerEmail,
				Active = item2.Active,
				Address = item2.Address,
				Comments = item2.Comments,
				CustomerCell = item2.CustomerCell,
				CustomerHome = item2.CustomerHome,
				CustomerName = item2.CustomerName,
				MemberNumber = item2.MemberNumber,
				LoyaltyCardNo = item2.LoyaltyCardNo,
				DateCreated = item2.DateCreated,
				CloudsyncGUID = guid
			};
			list2.Add(item);
		}
		customersPostModel.ListOfCustomers = list2;
		string text = SyncTask(customersPostModel, "/api/inventory/SyncMembers");
		if (string.IsNullOrEmpty(text))
		{
			foreach (Customer item3 in list)
			{
				item3.Synced = true;
			}
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " members");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync members", InventorySyncTimer, "Sync members failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All members are synced.");
		}
		return flag;
	}

	public static bool SyncMembersFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Customers From Cloudsync Started...");
		bool result = true;
		StatusCodeResponseMembers statusCodeResponseMembers = JsonConvert.DeserializeObject<StatusCodeResponseMembers>(SyncTaskWithResponseData(new DiscountCodePostResponseModel
		{
			token = token
		}, "/api/inventory/SyncMembersFromCloudsync"));
		if (statusCodeResponseMembers.code == 200)
		{
			if (statusCodeResponseMembers.CustomerList.Count > 0)
			{
				_003C_003Ec__DisplayClass100_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass100_0();
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.idsToConfirm = new List<MemberIdResponse>();
				List<Employee> source = gClass.Employees.ToList();
				Employee employee = source.Where((Employee a) => a.Users.Where((User b) => b.Role.RoleName == "Admin").Count() > 0).FirstOrDefault();
				using (List<CustomersPostDataModel>.Enumerator enumerator = statusCodeResponseMembers.CustomerList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass100_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass100_1();
						CS_0024_003C_003E8__locals1.cp = enumerator.Current;
						Customer customer = gClass.Customers.Where((Customer a) => a.CloudsyncGUID == CS_0024_003C_003E8__locals1.cp.CloudsyncGUID).FirstOrDefault();
						if (customer == null)
						{
							customer = gClass.Customers.Where((Customer a) => a.CustomerID == CS_0024_003C_003E8__locals1.cp.CustomerID && a.CustomerName == CS_0024_003C_003E8__locals1.cp.CustomerName).FirstOrDefault();
						}
						if (customer == null)
						{
							customer = new Customer();
							if (source.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals1.cp.EmployeeID).FirstOrDefault() != null)
							{
								customer.EmployeeID = CS_0024_003C_003E8__locals1.cp.EmployeeID;
							}
							else if (employee != null)
							{
								customer.EmployeeID = employee.EmployeeID;
							}
							else
							{
								customer.EmployeeID = source.FirstOrDefault().EmployeeID;
							}
							customer.DateCreated = DateTime.Now;
							gClass.Customers.InsertOnSubmit(customer);
						}
						customer.Active = CS_0024_003C_003E8__locals1.cp.Active;
						customer.Comments = CS_0024_003C_003E8__locals1.cp.Comments;
						customer.CustomerCell = CS_0024_003C_003E8__locals1.cp.CustomerCell;
						customer.CustomerEmail = CS_0024_003C_003E8__locals1.cp.CustomerEmail;
						customer.CustomerHome = CS_0024_003C_003E8__locals1.cp.CustomerHome;
						customer.CustomerName = CS_0024_003C_003E8__locals1.cp.CustomerName;
						customer.DateCreated = CS_0024_003C_003E8__locals1.cp.DateCreated;
						customer.LoyaltyCardNo = CS_0024_003C_003E8__locals1.cp.LoyaltyCardNo;
						customer.EmployeeID = CS_0024_003C_003E8__locals1.cp.EmployeeID;
						customer.Address = CS_0024_003C_003E8__locals1.cp.Address;
						customer.MemberNumber = CS_0024_003C_003E8__locals1.cp.MemberNumber;
						customer.CloudsyncGUID = CS_0024_003C_003E8__locals1.cp.CloudsyncGUID;
						customer.LastModified = DateTime.Now;
						Helper.SubmitChangesWithCatch(gClass);
						if (CS_0024_003C_003E8__locals1.cp.CloudsyncGUID.HasValue)
						{
							CS_0024_003C_003E8__locals0.idsToConfirm.Add(new MemberIdResponse
							{
								CloudsyncGuid = CS_0024_003C_003E8__locals1.cp.CloudsyncGUID.Value,
								AppId = CS_0024_003C_003E8__locals1.cp.CustomerID
							});
						}
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new CustomerConfirmationModel
				{
					token = token,
					CustomerIdList = CS_0024_003C_003E8__locals0.idsToConfirm
				}, "/api/inventory/ConfirmSyncMembers")))
				{
					foreach (Customer item in gClass.Customers.Where((Customer i) => i.CloudsyncGUID.HasValue && CS_0024_003C_003E8__locals0.idsToConfirm.Select((MemberIdResponse a) => a.CloudsyncGuid).Contains(i.CloudsyncGUID.Value) == true).ToList())
					{
						item.Synced = true;
						Helper.SubmitChangesWithCatch(gClass);
					}
					WriteToSyncLog("Cloudsync: Members from cloudsync synced.");
				}
			}
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync memebers.", InventorySyncTimer, "Cloudsync: Members sync failed " + statusCodeResponseMembers.message);
			result = false;
		}
		return result;
	}

	public static bool SyncStations(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		StationPostModel stationPostModel = new StationPostModel();
		stationPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Station> list = gClass.Stations.Where((Station g) => g.Synced == false).Take(20).ToList();
		total_count = stations_to_sync.Count;
		List<StationPostDataModel> list2 = new List<StationPostDataModel>();
		foreach (Station item2 in list)
		{
			StationPostDataModel item = new StationPostDataModel
			{
				StationId = item2.StationID,
				StationName = item2.StationName,
				PrinterName = item2.PrinterName,
				SendToStation = item2.SendToStation,
				AutoPrint = item2.AutoPrint,
				EnablePrint = item2.EnablePrint,
				PrintCopies = item2.PrintCopies,
				OrderTypes = item2.OrderTypes,
				PrintEachQty = item2.PrintEachQty,
				PrintItemQtyGreater = item2.PrintItemQtyGreater,
				ChitFontSize = item2.ChitFontSize,
				ChitFormat = item2.ChitFormat,
				DisplayFontSize = item2.DisplayFontSize,
				PaperSize = item2.PaperSize
			};
			list2.Add(item);
		}
		stationPostModel.ListOfStation = list2;
		string text = SyncTask(stationPostModel, "/api/inventory/SyncStations");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(Station i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " stations");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync stations", InventorySyncTimer, "Sync stations failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All stations are synced.");
		}
		return flag;
	}

	public static bool SyncEmployees(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Employees Started...");
		bool flag = true;
		GClass6 gClass = new GClass6();
		EmployeesPostData employeesPostData = new EmployeesPostData();
		employeesPostData.token = token;
		employeesPostData.ListOfEmployees = new List<EmployeesPostModel>();
		if (employees_to_sync.Count > 0)
		{
			List<EmployeesPostModel> list = new List<EmployeesPostModel>();
			list = (employeesPostData.ListOfEmployees = employees_to_sync.Select((Employee a) => new EmployeesPostModel
			{
				EmployeeID = a.EmployeeID,
				FirstName = a.FirstName,
				LastName = a.LastName,
				Address = a.Address,
				Phone1 = a.Phone1,
				Phone2 = a.Phone2,
				SIN = a.SIN,
				IsActive = a.isActive
			}).ToList());
			WriteToSyncLog("CloudSync: Employees Syncing...");
		}
		string text = SyncTask(employeesPostData, "/api/employee/SyncEmployees");
		if (string.IsNullOrEmpty(text))
		{
			gClass.Employees.Where((Employee s) => s.Synced == false).ToList().ForEach(delegate(Employee a)
			{
				a.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Employees.", InventorySyncTimer, "sync Employees failed, " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("CloudSync: All Employees are synced.");
		}
		return flag;
	}

	public static bool SyncSettings(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		SettingPostModel settingPostModel = new SettingPostModel();
		settingPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Setting> list = gClass.Settings.Where((Setting g) => g.Synced == false).Take(20).ToList();
		total_count = settings_to_sync.Count;
		List<SettingPostDataModel> list2 = new List<SettingPostDataModel>();
		foreach (Setting item2 in list)
		{
			SettingPostDataModel item = new SettingPostDataModel
			{
				Key = item2.Key,
				Value = item2.Value
			};
			list2.Add(item);
		}
		settingPostModel.ListOfSettings = list2;
		string text = SyncTask(settingPostModel, "/api/inventory/SyncSettings");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(Setting i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " settings");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync settings", InventorySyncTimer, "Sync settings failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All settings are synced.");
		}
		return flag;
	}

	public static bool SyncSettingsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Settings From Cloudsync Started...");
		bool result = true;
		SettingResponseModel settingResponseModel = JsonConvert.DeserializeObject<SettingResponseModel>(SyncTaskWithResponseData(new SettingPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncSettingsFromCloudsync"));
		if (settingResponseModel.code == 200)
		{
			if (settingResponseModel.SettingList.Count > 0)
			{
				GClass6 gClass = new GClass6();
				using (List<SettingPostDataModel>.Enumerator enumerator = settingResponseModel.SettingList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass104_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass104_0();
						CS_0024_003C_003E8__locals0.dataModel = enumerator.Current;
						Setting setting = gClass.Settings.Where((Setting a) => a.Key == CS_0024_003C_003E8__locals0.dataModel.Key).FirstOrDefault();
						if (setting != null)
						{
							setting.Value = CS_0024_003C_003E8__locals0.dataModel.Value;
						}
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
				if (string.IsNullOrEmpty(SyncTask(new ReasonsPostResponseModel
				{
					token = token
				}, "/api/inventory/ConfirmSyncSetting")))
				{
					_003C_003Ec__DisplayClass104_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass104_1();
					CS_0024_003C_003E8__locals1.keysToConfirm = settingResponseModel.SettingList.Select((SettingPostDataModel a) => a.Key).ToList();
					{
						foreach (Setting item in gClass.Settings.Where((Setting a) => CS_0024_003C_003E8__locals1.keysToConfirm.Contains(a.Key) && a.Synced == false).ToList())
						{
							item.Synced = true;
							Helper.SubmitChangesWithCatch(gClass);
						}
						return result;
					}
				}
			}
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync settings from cloudsync. ", InventorySyncTimer, "Sync Settings from cloudsync failed, " + settingResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncCustomFields(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		CustomFieldPostModel customFieldPostModel = new CustomFieldPostModel();
		customFieldPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<CustomField> list = gClass.CustomFields.Where((CustomField g) => g.Sycned == false).Take(20).ToList();
		total_count = custom_field_to_sync.Count();
		List<CustomFieldPostDataModel> list2 = new List<CustomFieldPostDataModel>();
		foreach (CustomField item2 in list)
		{
			CustomFieldPostDataModel item = new CustomFieldPostDataModel
			{
				AppId = item2.CustomFieldId,
				Name = item2.Value
			};
			list2.Add(item);
		}
		customFieldPostModel.ListOfCustomField = list2;
		string text = SyncTask(customFieldPostModel, "/api/inventory/SyncCustomFields");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(CustomField i)
			{
				i.Sycned = true;
			});
			gClass.SubmitChanges();
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " custom fields");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync custom fields", InventorySyncTimer, "Sync custom fields failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All custom fields are synced.");
		}
		return flag;
	}

	public static bool SyncCustomFieldsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Custom Field From Cloudsync Started...");
		bool result = true;
		CustomFieldResponseModel customFieldResponseModel = JsonConvert.DeserializeObject<CustomFieldResponseModel>(SyncTaskWithResponseData(new CustomFieldPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncCustomFieldsFromCloudsync"));
		GClass6 gClass = new GClass6();
		if (customFieldResponseModel.code == 200)
		{
			if (customFieldResponseModel.CustomFieldList.Count > 0)
			{
				List<Ids> list = new List<Ids>();
				using (List<CustomFieldPostDataModel>.Enumerator enumerator = customFieldResponseModel.CustomFieldList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass106_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass106_0();
						CS_0024_003C_003E8__locals0.cfRes = enumerator.Current;
						CustomField customField = null;
						customField = ((CS_0024_003C_003E8__locals0.cfRes.AppId <= 0) ? gClass.CustomFields.Where((CustomField i) => i.Value == CS_0024_003C_003E8__locals0.cfRes.Name).FirstOrDefault() : gClass.CustomFields.Where((CustomField i) => i.CustomFieldId == CS_0024_003C_003E8__locals0.cfRes.AppId).FirstOrDefault());
						if (customField != null)
						{
							customField.Value = CS_0024_003C_003E8__locals0.cfRes.Name;
						}
						else
						{
							customField = new CustomField
							{
								Value = CS_0024_003C_003E8__locals0.cfRes.Name,
								Sycned = false
							};
							gClass.CustomFields.InsertOnSubmit(customField);
						}
						list.Add(new Ids
						{
							CloudSyncId = (int)CS_0024_003C_003E8__locals0.cfRes.CloudsyncId,
							PosId = customField.CustomFieldId
						});
					}
				}
				gClass.SubmitChanges();
				if (string.IsNullOrEmpty(SyncTask(new CustomFieldConfirmationModel
				{
					token = token,
					cfIds = list
				}, "/api/inventory/ConfirmSyncCustomField")))
				{
					using (List<Ids>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass106_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass106_1();
							CS_0024_003C_003E8__locals1.cfId = enumerator2.Current;
							gClass.CustomFields.Where((CustomField i) => i.CustomFieldId == CS_0024_003C_003E8__locals1.cfId.PosId).FirstOrDefault().Sycned = true;
							gClass.SubmitChanges();
						}
					}
					WriteToSyncLog("CloudSync: Custom Fields edited from cloudsync are synced.");
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Custom Fields from cloudsync", InventorySyncTimer, "Sync Custom Fields from cloudsync failed. " + customFieldResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncCompanyInfo(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool result = true;
		CompanyInfoPostModel companyInfoPostModel = new CompanyInfoPostModel();
		GClass6 gClass = new GClass6();
		companyInfoPostModel.token = token;
		CompanySetup companySetup = gClass.CompanySetups.Where((CompanySetup x) => x.isSynced == false).FirstOrDefault();
		if (companySetup != null)
		{
			companyInfoPostModel.Company = companySetup;
			companyInfoPostModel.ListOfBusinessHours = gClass.BusinessHours.Select((BusinessHour a) => new BusinessHoursPostDataModel
			{
				Day = a.DayOfTheWeek,
				OpenTime = a.LatestOpeningTime,
				CloseTime = a.LatestClosingTime
			}).ToList();
			string text = SyncTask(companyInfoPostModel, "/api/company/SyncCompanyInfo");
			if (string.IsNullOrEmpty(text))
			{
				companySetup.isSynced = true;
				Helper.SubmitChangesWithCatch(gClass);
				WriteToSyncLog("CloudSync: Company Info Sync Complete.");
			}
			else
			{
				FailSync("CloudSync Failed: Failed to sync Company Info.", InventorySyncTimer, "sync company info failed, " + text);
				result = false;
			}
		}
		return result;
	}

	public static bool SyncCompanyInfoFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Company Info From Cloudsync Started...");
		bool result = true;
		CompanyResponseModel companyResponseModel = JsonConvert.DeserializeObject<CompanyResponseModel>(SyncTaskWithResponseData(new CompanyPostResponseModel
		{
			token = token
		}, "/api/company/SyncCompanyInfoFromCloudsync"));
		if (companyResponseModel.code == 200)
		{
			if (companyResponseModel.companyResponse != null)
			{
				GClass6 gClass = new GClass6();
				CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
				if (companySetup != null)
				{
					companySetup.String_0 = companyResponseModel.companyResponse.String_0;
					companySetup.Phone = companyResponseModel.companyResponse.Phone;
					companySetup.Address1 = companyResponseModel.companyResponse.Address1;
					companySetup.City = companyResponseModel.companyResponse.City;
					companySetup.Country = companyResponseModel.companyResponse.Country;
					companySetup.StateProv = companyResponseModel.companyResponse.StateProv;
					companySetup.ZIP = companyResponseModel.companyResponse.ZIP;
					Helper.SubmitChangesWithCatch(gClass);
					if (companyResponseModel.ListOfBusinessHours != null && companyResponseModel.ListOfBusinessHours.Count > 0)
					{
						IQueryable<BusinessHour> businessHours = gClass.BusinessHours;
						if (businessHours.Count() > 0)
						{
							gClass.BusinessHours.DeleteAllOnSubmit(businessHours);
							Helper.SubmitChangesWithCatch(gClass);
						}
						foreach (BusinessHoursPostDataModel listOfBusinessHour in companyResponseModel.ListOfBusinessHours)
						{
							BusinessHour entity = new BusinessHour
							{
								DayOfTheWeek = listOfBusinessHour.Day,
								LatestOpeningTime = listOfBusinessHour.OpenTime,
								LatestClosingTime = listOfBusinessHour.CloseTime
							};
							gClass.BusinessHours.InsertOnSubmit(entity);
							Helper.SubmitChangesWithCatch(gClass);
						}
					}
					WriteToSyncLog("Company Info Synced.");
				}
			}
		}
		else
		{
			FailSync("Failed to sync company info from cloudsync", InventorySyncTimer, "Company info failed to sync from cloudsync. " + companyResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncSecondScreenImages(string token, System.Timers.Timer SecondScreenImagesTimer)
	{
		bool result = true;
		LocationSecondScreenImagesPostModel locationSecondScreenImagesPostModel = new LocationSecondScreenImagesPostModel();
		locationSecondScreenImagesPostModel.token = token;
		GClass6 gClass = new GClass6();
		List<ImageScreen> list = gClass.ImageScreens.Where((ImageScreen g) => g.Synced == false && g.BlobName != null).Take(10).ToList();
		List<LocationSecondScreenImagesPostDataModel> list2 = new List<LocationSecondScreenImagesPostDataModel>();
		foreach (ImageScreen item2 in list)
		{
			if (item2.BlobName != null)
			{
				LocationSecondScreenImagesPostDataModel item = new LocationSecondScreenImagesPostDataModel
				{
					AppId = item2.Id,
					BlobName = item2.BlobName,
					BlobThumbnailName = ((item2.BlobThumbnailName == null) ? item2.BlobName : item2.BlobThumbnailName),
					ImageInterval = item2.Interval,
					ImageTitle = item2.ImageName,
					SortOrder = item2.SortOrder
				};
				list2.Add(item);
			}
		}
		locationSecondScreenImagesPostModel.ListOfSecondScreenImages = list2;
		string text = SyncTask(locationSecondScreenImagesPostModel, "/api/Location/SyncSecondScreenImages");
		WriteToSyncLog(text + " TEST");
		if (string.IsNullOrEmpty(text))
		{
			foreach (ImageScreen item3 in list)
			{
				item3.Synced = true;
			}
			Helper.SubmitChangesWithCatch(gClass);
			WriteToSyncLog("Cloudsync: Second Screen Images Sync.");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync second screen images", SecondScreenImagesTimer, "Sync second screen images failed " + text);
			result = false;
		}
		return result;
	}

	public static bool SyncSecondScreenImagesFromCloudsync(string token, System.Timers.Timer SecondScreenImagesTimer)
	{
		bool result = true;
		try
		{
			SecondScreenImagesResponseModel secondScreenImagesResponseModel = JsonConvert.DeserializeObject<SecondScreenImagesResponseModel>(SyncTaskWithResponseData(new ItemPostResponseModel
			{
				token = token
			}, "/api/Location/SyncSecondScreenImagesFromCloudsync"));
			if (secondScreenImagesResponseModel.code == 200)
			{
				GClass6 gClass = new GClass6();
				if (secondScreenImagesResponseModel.LocationImagesResponseList != null)
				{
					if (secondScreenImagesResponseModel.LocationImagesResponseList.Count > 0)
					{
						List<Ids> list = new List<Ids>();
						using (List<LocationSecondScreenImagesPostDataModel>.Enumerator enumerator = secondScreenImagesResponseModel.LocationImagesResponseList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass110_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass110_0();
								CS_0024_003C_003E8__locals1.locImage = enumerator.Current;
								Ids ids = new Ids();
								ids.CloudSyncId = CS_0024_003C_003E8__locals1.locImage.Id;
								if (CS_0024_003C_003E8__locals1.locImage.AppId == 0)
								{
									string imageAsText = "";
									ImageMethods imageMethods = new ImageMethods();
									string text = imageMethods.ConvertImageURLToBase64(CS_0024_003C_003E8__locals1.locImage.BlobThumbnailName);
									if (!string.IsNullOrEmpty(text))
									{
										imageAsText = text;
									}
									string text2 = imageMethods.ConvertImageURLToBase64(CS_0024_003C_003E8__locals1.locImage.BlobName);
									if (!string.IsNullOrEmpty(text2) && text2.Length <= 60000000)
									{
										imageAsText = text2;
									}
									ImageScreen imageScreen = new ImageScreen
									{
										ImageName = CS_0024_003C_003E8__locals1.locImage.ImageTitle,
										ImageType = MediaType.second_screen_photos,
										Interval = CS_0024_003C_003E8__locals1.locImage.ImageInterval,
										SortOrder = CS_0024_003C_003E8__locals1.locImage.SortOrder,
										ImageAsText = imageAsText,
										BlobName = CS_0024_003C_003E8__locals1.locImage.BlobName,
										BlobThumbnailName = CS_0024_003C_003E8__locals1.locImage.BlobThumbnailName,
										Synced = false
									};
									gClass.ImageScreens.InsertOnSubmit(imageScreen);
									Helper.SubmitChangesWithCatch(gClass);
									ids.PosId = imageScreen.Id;
									list.Add(ids);
									continue;
								}
								ImageScreen imageScreen2 = gClass.ImageScreens.Where((ImageScreen a) => a.Id == CS_0024_003C_003E8__locals1.locImage.AppId).FirstOrDefault();
								if (imageScreen2 != null)
								{
									ids.PosId = imageScreen2.Id;
									list.Add(ids);
									if (CS_0024_003C_003E8__locals1.locImage.isDeleted)
									{
										gClass.ImageScreens.DeleteOnSubmit(imageScreen2);
										Helper.SubmitChangesWithCatch(gClass);
										continue;
									}
									imageScreen2.ImageName = CS_0024_003C_003E8__locals1.locImage.ImageTitle;
									imageScreen2.Interval = CS_0024_003C_003E8__locals1.locImage.ImageInterval;
									imageScreen2.SortOrder = CS_0024_003C_003E8__locals1.locImage.SortOrder;
									Helper.SubmitChangesWithCatch(gClass);
								}
							}
						}
						SecondScreenImageConfirmationModel secondScreenImageConfirmationModel = new SecondScreenImageConfirmationModel();
						secondScreenImageConfirmationModel.token = token;
						secondScreenImageConfirmationModel.Ids = list;
						if (string.IsNullOrEmpty(SyncTask(secondScreenImageConfirmationModel, "/api/Location/ConfirmSyncSecondScreenImages")))
						{
							using (IEnumerator<int> enumerator2 = secondScreenImageConfirmationModel.Ids.Select((Ids a) => a.PosId).GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									_003C_003Ec__DisplayClass110_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass110_1();
									CS_0024_003C_003E8__locals0.imageId = enumerator2.Current;
									gClass.ImageScreens.Where((ImageScreen a) => a.Id == CS_0024_003C_003E8__locals0.imageId).FirstOrDefault().Synced = true;
									Helper.SubmitChangesWithCatch(gClass);
								}
							}
							WriteToSyncLog("CloudSync: Second Screen Images edited from cloudsync are synced.");
							return result;
						}
						return result;
					}
					return result;
				}
				return result;
			}
			FailSync("CloudSync Failed: Failed to sync second screen images from cloudsync", SecondScreenImagesTimer, "Sync second screen images from cloudsync failed. " + secondScreenImagesResponseModel.message);
			return false;
		}
		catch (Exception errorResponse)
		{
			FailSync("CloudSync Failed: Failed to Sync second screen images from cloudsync.", SecondScreenImagesTimer, errorResponse);
			return false;
		}
	}

	public static bool SyncGiftLoyaltyCardSettings(string token, System.Timers.Timer OrderSyncFromCloudsyncTimer)
	{
		bool result = true;
		GiftLoyaltyCardSettingsPostModel giftLoyaltyCardSettingsPostModel = new GiftLoyaltyCardSettingsPostModel();
		giftLoyaltyCardSettingsPostModel.token = token;
		giftLoyaltyCardSettingsPostModel.GiftSettings = "";
		giftLoyaltyCardSettingsPostModel.LoyaltySettings = "";
		if (SettingsHelper.GetSettingValueByKey("gift_card_payment") == "ON")
		{
			giftLoyaltyCardSettingsPostModel.GiftSettings = SettingsHelper.GetSettingValueByKey("gift_card_json");
		}
		if (SettingsHelper.GetSettingValueByKey("loyalty_card_payment") == "ON")
		{
			giftLoyaltyCardSettingsPostModel.LoyaltySettings = SettingsHelper.GetSettingValueByKey("loyalty_card_json");
		}
		string text = SyncTask(giftLoyaltyCardSettingsPostModel, "/api/Settings/SyncGiftLoyaltySettings");
		if (string.IsNullOrEmpty(text))
		{
			WriteToSyncLog("Cloudsync: Sync Gift and Loyalty Settings Completed.");
			isSettingsSynced = true;
		}
		else
		{
			FailSync("Cloudsync Failed: Failed to sync gift and loyalty settings.", OrderSyncFromCloudsyncTimer, "Sync gift and loyalty settings failed." + text);
			result = false;
		}
		return result;
	}

	public static void DownloadItemAndGroupImages(System.Timers.Timer DownloadImagesTimer)
	{
		isImageDownloading = true;
		try
		{
			GClass6 gClass = new GClass6();
			ItemImage itemImage = gClass.ItemImages.Where((ItemImage i) => i.isNewImage == true).FirstOrDefault();
			if (itemImage != null)
			{
				if (!string.IsNullOrEmpty(itemImage.ImageAsText) && itemImage.ImageAsText == "NoImage")
				{
					itemImage.ImageAsText = null;
					itemImage.ImageAsTextHighRes = null;
					itemImage.BlobName = "NoImage";
					itemImage.BlobThumbnailName = "NoImage";
					itemImage.isNewImage = false;
				}
				else if (!string.IsNullOrEmpty(itemImage.BlobName) && itemImage.BlobName != "NoImage")
				{
					ImageMethods imageMethods = new ImageMethods();
					string text = imageMethods.ConvertImageURLToBase64(itemImage.BlobThumbnailName);
					if (!string.IsNullOrEmpty(text))
					{
						itemImage.ImageAsText = text;
					}
					string text2 = imageMethods.ConvertImageURLToBase64(itemImage.BlobName);
					if (!string.IsNullOrEmpty(text2) && text2.Length <= 60000000)
					{
						itemImage.ImageAsTextHighRes = text2;
					}
					itemImage.isNewImage = false;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		catch (Exception ex)
		{
			if (ex.Message.Contains("Row not found"))
			{
				DownloadImagesTimer.Enabled = true;
			}
		}
		isImageDownloading = false;
	}

	public static void DownloadVideos()
	{
		try
		{
			currentlyDownloading = true;
			foreach (ImageScreen item in new GClass6().ImageScreens.Where((ImageScreen a) => a.ImageAsText != "" && a.ImageType == MediaType.second_screen_videos).ToList())
			{
				if (item == null)
				{
					continue;
				}
				if (!Directory.Exists(string_0))
				{
					Directory.CreateDirectory(string_0);
				}
				if (!File.Exists(string_0 + item.ImageName))
				{
					using WebClient webClient = new WebClient();
					webClient.DownloadFile(item.ImageAsText, string_0 + item.ImageName);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			FailSync("Fail to download second screen videos.", null, ex.Message + "\n" + ex.StackTrace);
			currentlyDownloading = false;
		}
	}

	public static void UploadVideos()
	{
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		try
		{
			currentlyUploading = true;
			if (!Directory.Exists(string_0))
			{
				Directory.CreateDirectory(string_0);
			}
			GClass6 gClass = new GClass6();
			foreach (ImageScreen item in gClass.ImageScreens.Where((ImageScreen a) => a.ImageAsText == "" && a.ImageType == MediaType.second_screen_videos).ToList())
			{
				if (item == null || !File.Exists(string_0 + item.ImageName))
				{
					continue;
				}
				AzureBlobKeyPostResponseModel azureBlobKeyPostResponseModel = JsonConvert.DeserializeObject<AzureBlobKeyPostResponseModel>(SyncTaskWithResponseData(new AzureBlobKeyPostDataModel
				{
					token = sync_token
				}, "/api/Azure/GetAzureBlobConnectionString"));
				if (azureBlobKeyPostResponseModel.code == 200)
				{
					CloudBlobClient obj = CloudStorageAccount.Parse(azureBlobKeyPostResponseModel.Key).CreateCloudBlobClient();
					string text = "hipposhq-videos";
					CloudBlobContainer containerReference = obj.GetContainerReference(text);
					try
					{
						FileStream fileStream = File.Open(string_0 + item.ImageName, FileMode.Open);
						string text2 = azureBlobKeyPostResponseModel.LocationId + "-second_screen_video-" + item.ImageName;
						CloudBlockBlob blockBlobReference = containerReference.GetBlockBlobReference(text2);
						((CloudBlob)blockBlobReference).DeleteIfExists((DeleteSnapshotsOption)0, (AccessCondition)null, (BlobRequestOptions)null, (OperationContext)null);
						TransferManager.get_Configurations().set_ParallelOperations(64);
						TransferManager.get_Configurations().set_BlockSize(4194304);
						SingleTransferContext val = new SingleTransferContext();
						TransferManager.UploadAsync((Stream)fileStream, (CloudBlob)(object)blockBlobReference, (UploadOptions)null, val);
						item.ImageAsText = "https://hipposhq.blob.core.windows.net/hipposhq-videos/" + text2;
						Helper.SubmitChangesWithCatch(gClass);
						break;
					}
					catch (Exception ex)
					{
						DebugMethods.ShowExceptionTextFile(ex);
						break;
					}
				}
			}
		}
		catch (Exception ex2)
		{
			FailSync("Fail to upload second screen videos.", null, ex2.Message + "\n" + ex2.StackTrace);
			currentlyUploading = false;
		}
	}

	public static void UploadImages()
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		try
		{
			currentlyUploading = true;
			GClass6 gClass = new GClass6();
			foreach (ImageScreen item in gClass.ImageScreens.Where((ImageScreen a) => a.ImageAsText != null && a.ImageAsText != "" && a.ImageType == MediaType.second_screen_photos && a.BlobName == null).ToList())
			{
				if (item == null)
				{
					continue;
				}
				using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(item.ImageAsText));
				AzureBlobKeyPostResponseModel azureBlobKeyPostResponseModel = JsonConvert.DeserializeObject<AzureBlobKeyPostResponseModel>(SyncTaskWithResponseData(new AzureBlobKeyPostDataModel
				{
					token = sync_token
				}, "/api/Azure/GetAzureBlobConnectionString"));
				if (azureBlobKeyPostResponseModel.code == 200)
				{
					CloudBlobClient obj = CloudStorageAccount.Parse(azureBlobKeyPostResponseModel.Key).CreateCloudBlobClient();
					string text = "hipposhq-item-images";
					CloudBlobContainer containerReference = obj.GetContainerReference(text);
					try
					{
						string text2 = "ss-img-" + azureBlobKeyPostResponseModel.LocationId + "_" + Guid.NewGuid().ToString() + ".png";
						CloudBlockBlob blockBlobReference = containerReference.GetBlockBlobReference(text2);
						((CloudBlob)blockBlobReference).DeleteIfExists((DeleteSnapshotsOption)0, (AccessCondition)null, (BlobRequestOptions)null, (OperationContext)null);
						TransferManager.get_Configurations().set_ParallelOperations(64);
						TransferManager.get_Configurations().set_BlockSize(4194304);
						SingleTransferContext val = new SingleTransferContext();
						TransferManager.UploadAsync((Stream)memoryStream, (CloudBlob)(object)blockBlobReference, (UploadOptions)null, val);
						item.BlobName = "https://hipposhq.blob.core.windows.net/hipposhq-item-images/" + text2;
						Helper.SubmitChangesWithCatch(gClass);
					}
					catch (Exception ex)
					{
						DebugMethods.ShowExceptionTextFile(ex);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			FailSync("Fail to upload Item Images", null, ex2.Message + "\n" + ex2.StackTrace);
		}
		currentlyUploading = false;
	}

	public static void SyncSecondScreenImages(System.Timers.Timer SecondScreenImagesTimer)
	{
		try
		{
			currentlyDownloadingImagesFromCS = true;
			int num = new GClass6().ImageScreens.Where((ImageScreen g) => g.ImageType == MediaType.second_screen_photos && g.Synced == false && g.BlobName != null).Count();
			if (string.IsNullOrEmpty(sync_token))
			{
				sync_token = GetToken();
			}
			if (num > 0)
			{
				SyncSecondScreenImages(sync_token, SecondScreenImagesTimer);
			}
			else
			{
				SyncSecondScreenImagesFromCloudsync(sync_token, SecondScreenImagesTimer);
			}
			currentlyDownloadingImagesFromCS = false;
		}
		catch (Exception ex)
		{
			currentlyDownloadingImagesFromCS = false;
			FailSync("CloudSync Failed: Failed to sync. Second screen images", SecondScreenImagesTimer, ex.Message + "\n" + ex.StackTrace);
		}
	}

	public static void SyncEmployeeClockInOut()
	{
		employeeClockInOutSyncing = true;
		try
		{
			WriteToSyncLog("Hippos Time Sync: Sync Employee Clock In and Out STARTED.");
			GClass6 gClass = new GClass6();
			List<EmployeeClockInOutQueue> list = (from a in gClass.EmployeeClockInOutQueues
				where a.Synced == false && (a.Action == "hippos-clockin" || a.Action == "hippos-clockout")
				orderby Convert.ToDateTime(a.Timestamp)
				select a).Take(40).ToList();
			if (list.Count > 0)
			{
				HipposClockInOutListPostObject hipposClockInOutListPostObject = new HipposClockInOutListPostObject();
				List<HipposClockInOutRequestObject> listOfClockInOut = list.Select((EmployeeClockInOutQueue a) => new HipposClockInOutRequestObject
				{
					id = a.Id,
					action = a.Action,
					employee_pin = a.EmployeePin,
					timestamp = a.Timestamp
				}).ToList();
				hipposClockInOutListPostObject.cs_apikey = sync_token;
				hipposClockInOutListPostObject.ListOfClockInOut = listOfClockInOut;
				ClocksInOutReponseObject clocksInOutReponseObject = ETimeCardMethods.SyncPunchInOut(hipposClockInOutListPostObject);
				if (clocksInOutReponseObject != null && clocksInOutReponseObject.code == 200)
				{
					list.ForEach(delegate(EmployeeClockInOutQueue a)
					{
						a.Synced = true;
					});
					gClass.SubmitChanges();
				}
				WriteToSyncLog("Hippos Time Sync: Sync Employee Clock In and Out COMPLETED.");
			}
			else
			{
				WriteToSyncLog("Hippos Time Sync: Sync Employee Clock In and Out NOTHING TO SYNC.");
			}
			employeeClockInOutSyncing = false;
		}
		catch (Exception ex)
		{
			FailSync("Fail to sync employee clock in and out.", null, ex.Message + "\n" + ex.StackTrace);
			employeeClockInOutSyncing = false;
		}
	}

	public static void SyncEmployeeClockInOutFromHipposTime()
	{
		employeeClockInOutSyncing = true;
		try
		{
			_003C_003Ec__DisplayClass118_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass118_0();
			WriteToSyncLog("Hippos Time Sync: Sync Employee Clock In and Out STARTED.");
			GClass6 gClass = new GClass6();
			HipposClockInOutRequestObject hipposClockInOutRequestObject = new HipposClockInOutRequestObject();
			hipposClockInOutRequestObject.cs_apikey = sync_token;
			CS_0024_003C_003E8__locals0.response = ETimeCardMethods.SyncPunchInOutFromHipposTime(hipposClockInOutRequestObject);
			if (CS_0024_003C_003E8__locals0.response.ListOfClockInOut != null && CS_0024_003C_003E8__locals0.response.ListOfClockInOut.Count > 0)
			{
				List<EmployeeClockInOutQueue> source = gClass.EmployeeClockInOutQueues.Where((EmployeeClockInOutQueue a) => CS_0024_003C_003E8__locals0.response.ListOfClockInOut.Select((HipposClockInOutRequestObject b) => b.id).Contains(a.Id)).ToList();
				List<Employee> source2 = gClass.Employees.Where((Employee a) => CS_0024_003C_003E8__locals0.response.ListOfClockInOut.Select((HipposClockInOutRequestObject b) => b.employee_pin).Contains(a.Users.First().PIN)).ToList();
				List<HipposClockInOutRequestObject> list = new List<HipposClockInOutRequestObject>();
				using (List<HipposClockInOutRequestObject>.Enumerator enumerator = CS_0024_003C_003E8__locals0.response.ListOfClockInOut.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass118_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass118_1();
						CS_0024_003C_003E8__locals1.clockInOut = enumerator.Current;
						EmployeeClockInOutQueue employeeClockInOutQueue = source.Where((EmployeeClockInOutQueue a) => a.Id == CS_0024_003C_003E8__locals1.clockInOut.id).FirstOrDefault();
						if (employeeClockInOutQueue != null && CS_0024_003C_003E8__locals1.clockInOut.id != 0)
						{
							employeeClockInOutQueue.Timestamp = CS_0024_003C_003E8__locals1.clockInOut.timestamp;
							employeeClockInOutQueue.Synced = true;
							gClass.SubmitChanges();
							list.Add(new HipposClockInOutRequestObject
							{
								id = employeeClockInOutQueue.Id,
								action = employeeClockInOutQueue.Action,
								employee_pin = employeeClockInOutQueue.EmployeePin,
								timestamp = employeeClockInOutQueue.Timestamp
							});
							continue;
						}
						Employee employee = source2.Where((Employee a) => a.Users.First().PIN == CS_0024_003C_003E8__locals1.clockInOut.employee_pin).FirstOrDefault();
						if (employee != null)
						{
							employeeClockInOutQueue = new EmployeeClockInOutQueue
							{
								EmployeeId = employee.EmployeeID,
								Action = CS_0024_003C_003E8__locals1.clockInOut.action,
								EmployeePin = CS_0024_003C_003E8__locals1.clockInOut.employee_pin,
								Timestamp = CS_0024_003C_003E8__locals1.clockInOut.timestamp,
								Synced = true
							};
							gClass.EmployeeClockInOutQueues.InsertOnSubmit(employeeClockInOutQueue);
							gClass.SubmitChanges();
							list.Add(new HipposClockInOutRequestObject
							{
								id = employeeClockInOutQueue.Id,
								action = employeeClockInOutQueue.Action,
								employee_pin = employeeClockInOutQueue.EmployeePin,
								timestamp = employeeClockInOutQueue.Timestamp
							});
						}
					}
				}
				if (list.Count > 0)
				{
					ClocksInOutReponseObject clocksInOutReponseObject = ETimeCardMethods.ConfirmPunchInOut(new HipposClockInOutListPostObject
					{
						cs_apikey = sync_token,
						ListOfClockInOut = list
					});
					if (clocksInOutReponseObject != null)
					{
						if (CS_0024_003C_003E8__locals0.response.code == 200)
						{
							WriteToSyncLog("Hippos Time Sync: Sync Clock In and Out FROM HIPPOS TIME COMPLETED.");
						}
						else
						{
							WriteToSyncLog("Hippos Time Sync: ERROR Sync Clock In and Out FROM HIPPOS TIME. " + clocksInOutReponseObject.message);
						}
					}
				}
			}
			else
			{
				WriteToSyncLog("Hippos Time Sync: Sync Clock In and Out FROM HIPPOS TIME, Nothing to Sync.");
			}
			employeeClockInOutSyncing = false;
		}
		catch (Exception ex)
		{
			FailSync("Fail to sync employee clock in and out.", null, ex.Message + "\n" + ex.StackTrace);
			employeeClockInOutSyncing = false;
		}
	}

	public static bool SyncPromotions(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		PromotionPostModel promotionPostModel = new PromotionPostModel();
		promotionPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<Promotion> list = gClass.Promotions.Where((Promotion g) => g.Synced == false).Take(20).ToList();
		total_count = list.Count();
		List<PromotionPostDataModel> list2 = new List<PromotionPostDataModel>();
		foreach (Promotion item2 in list)
		{
			PromotionPostDataModel item = new PromotionPostDataModel
			{
				PromoName = item2.PromoName,
				PromoCode = item2.PromoCode,
				Active = item2.Active,
				String_0 = item2.String_0,
				BuyQty = item2.BuyQty,
				GetQtyString = item2.GetQtyString,
				String_1 = item2.String_1,
				StartDate = item2.StartDate,
				EndDate = item2.EndDate,
				DateCreated = item2.DateCreated,
				GetDiscountAmount = item2.GetDiscountAmount,
				DateModified = item2.DateModified,
				DayTimeOfWeek = item2.DayTimeOfWeek,
				GetDiscountUOM = item2.GetDiscountUOM,
				OrderTypes = item2.OrderTypes,
				UserCreated = ((item2.Employee != null) ? (item2.Employee.FirstName + " " + item2.Employee.LastName) : ""),
				UserModified = ((item2.Employee1 != null) ? (item2.Employee1.FirstName + " " + item2.Employee1.LastName) : ""),
				IsDeleted = item2.IsDeleted
			};
			list2.Add(item);
		}
		promotionPostModel.ListOfPromotions = list2;
		string text = SyncTask(promotionPostModel, "/api/inventory/SyncPromotions");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(Promotion i)
			{
				i.Synced = true;
			});
			gClass.SubmitChanges();
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " promotions");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync promotions", InventorySyncTimer, "Sync promotionsfailed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All promotions are synced.");
		}
		return flag;
	}

	public static bool SyncPromotionsFromCloudsync(string token, System.Timers.Timer InventorySyncTimer)
	{
		WriteToSyncLog("CloudSync: Sync Promotions From Cloudsync Started...");
		bool result = true;
		PromotionResponseModel promotionResponseModel = JsonConvert.DeserializeObject<PromotionResponseModel>(SyncTaskWithResponseData(new PromotionPostResponseModel
		{
			token = token
		}, "/api/inventory/SyncPromotionsFromCloudsync"));
		GClass6 gClass = new GClass6();
		if (promotionResponseModel.code == 200)
		{
			if (promotionResponseModel.PromotionList.Count > 0)
			{
				List<string> list = new List<string>();
				using (List<PromotionPostDataModel>.Enumerator enumerator = promotionResponseModel.PromotionList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass120_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass120_0();
						CS_0024_003C_003E8__locals0.model = enumerator.Current;
						Promotion promotion = gClass.Promotions.Where((Promotion a) => a.PromoCode == CS_0024_003C_003E8__locals0.model.PromoCode).FirstOrDefault();
						if (promotion == null)
						{
							promotion = gClass.Promotions.Where((Promotion a) => a.PromoName == CS_0024_003C_003E8__locals0.model.PromoName).FirstOrDefault();
						}
						if (promotion == null)
						{
							promotion = new Promotion();
							promotion.DateCreated = CS_0024_003C_003E8__locals0.model.DateCreated;
							gClass.Promotions.InsertOnSubmit(promotion);
						}
						promotion.PromoName = CS_0024_003C_003E8__locals0.model.PromoName;
						promotion.PromoCode = CS_0024_003C_003E8__locals0.model.PromoCode;
						promotion.OrderTypes = CS_0024_003C_003E8__locals0.model.OrderTypes;
						promotion.String_0 = CS_0024_003C_003E8__locals0.model.String_0;
						promotion.BuyQty = CS_0024_003C_003E8__locals0.model.BuyQty;
						promotion.String_1 = CS_0024_003C_003E8__locals0.model.String_1;
						promotion.GetQtyString = CS_0024_003C_003E8__locals0.model.GetQtyString;
						promotion.GetDiscountUOM = CS_0024_003C_003E8__locals0.model.GetDiscountUOM;
						promotion.StartDate = CS_0024_003C_003E8__locals0.model.StartDate;
						promotion.EndDate = CS_0024_003C_003E8__locals0.model.EndDate;
						promotion.DateCreated = CS_0024_003C_003E8__locals0.model.DateCreated;
						promotion.DateModified = CS_0024_003C_003E8__locals0.model.DateModified;
						promotion.GetDiscountAmount = CS_0024_003C_003E8__locals0.model.GetDiscountAmount;
						promotion.DayTimeOfWeek = CS_0024_003C_003E8__locals0.model.DayTimeOfWeek;
						promotion.Active = CS_0024_003C_003E8__locals0.model.Active;
						promotion.IsDeleted = CS_0024_003C_003E8__locals0.model.IsDeleted;
						Helper.SubmitChangesWithCatch(gClass);
						list.Add(CS_0024_003C_003E8__locals0.model.PromoCode);
					}
				}
				if (string.IsNullOrEmpty(SyncTask(new PromotionConfirmationModel
				{
					token = token,
					PromoCodes = list
				}, "/api/inventory/ConfirmSyncPromotions")))
				{
					using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass120_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass120_1();
							CS_0024_003C_003E8__locals1.promoCode = enumerator2.Current;
							gClass.Promotions.Where((Promotion i) => i.PromoCode == CS_0024_003C_003E8__locals1.promoCode).FirstOrDefault().Synced = true;
						}
					}
					gClass.SubmitChanges();
					WriteToSyncLog("CloudSync: Promotions from cloudsync Synced.");
				}
			}
		}
		else
		{
			FailSync("CloudSync Failed: Failed to sync Promotions from cloudsync", InventorySyncTimer, "Sync Promotions from cloudsync failed. " + promotionResponseModel.message);
			result = false;
		}
		return result;
	}

	public static bool SyncUOM(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		UOMPostModel uOMPostModel = new UOMPostModel();
		uOMPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<UOM> list = gClass.UOMs.ToList();
		total_count = list.Count();
		List<UOMPostDataModel> list2 = new List<UOMPostDataModel>();
		foreach (UOM item2 in list)
		{
			UOMPostDataModel item = new UOMPostDataModel
			{
				UOMId = item2.UOMID,
				Name = item2.Name,
				isFractional = item2.isFractional
			};
			list2.Add(item);
		}
		uOMPostModel.List_0 = list2;
		string text = SyncTask(uOMPostModel, "/api/inventory/SyncUOM");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(UOM i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " UOMs");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync UOMs", InventorySyncTimer, "Sync UOMs failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All promotions are synced.");
		}
		return flag;
	}

	public static bool SyncCloudsyncDataArchiver(string token, System.Timers.Timer InventorySyncTimer)
	{
		bool flag = true;
		CloudsyncDataArchiverPostModel cloudsyncDataArchiverPostModel = new CloudsyncDataArchiverPostModel();
		cloudsyncDataArchiverPostModel.token = token;
		synced_count = 0;
		GClass6 gClass = new GClass6();
		List<CloudsyncDataArchiver> list = gClass.CloudsyncDataArchivers.Where((CloudsyncDataArchiver a) => a.Synced == false).ToList();
		total_count = list.Count();
		List<CloudsyncDataArchiverPostDataModel> list2 = new List<CloudsyncDataArchiverPostDataModel>();
		foreach (CloudsyncDataArchiver item2 in list)
		{
			CloudsyncDataArchiverPostDataModel item = new CloudsyncDataArchiverPostDataModel
			{
				PosId = item2.Id,
				UniqueIdentifier = item2.UniqueIdentifier,
				DataType = item2.DataType
			};
			list2.Add(item);
		}
		cloudsyncDataArchiverPostModel.listOfArchivables = list2;
		string text = SyncTask(cloudsyncDataArchiverPostModel, "/api/Location/SyncCloudsyncDataArchiver");
		if (string.IsNullOrEmpty(text))
		{
			list.ForEach(delegate(CloudsyncDataArchiver i)
			{
				i.Synced = true;
			});
			Helper.SubmitChangesWithCatch(gClass);
			synced_count += list.Count;
			WriteToSyncLog("Cloudsync: " + synced_count + " of " + total_count + " CloudsyncDataArchivers");
		}
		else
		{
			FailSync("Cloudsync: Failed to sync CloudsyncDataArchivers", InventorySyncTimer, "Sync CloudsyncDataArchivers failed " + text);
			flag = false;
		}
		if (flag)
		{
			WriteToSyncLog("All CloudsyncDataArchivers are synced.");
		}
		return flag;
	}

	public static bool CheckTotalOrderConfirmation(string token, DateTime StartDate, DateTime EndDate)
	{
		_003C_003Ec__DisplayClass123_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass123_0();
		CS_0024_003C_003E8__locals0.StartDate = StartDate;
		CS_0024_003C_003E8__locals0.EndDate = EndDate;
		try
		{
			TotalOrderPostModel totalOrderPostModel = new TotalOrderPostModel();
			totalOrderPostModel.token = token;
			var list = (from a in new GClass6().Orders
				where a.Paid == true && a.DatePaid.HasValue && a.DatePaid.Value >= CS_0024_003C_003E8__locals0.StartDate && a.DatePaid.Value <= CS_0024_003C_003E8__locals0.EndDate
				select new
				{
					totals = a.Total
				}).ToList();
			totalOrderPostModel.totals = list.Sum(a => a.totals);
			totalOrderPostModel.total_orders = list.Count;
			totalOrderPostModel.StartDate = CS_0024_003C_003E8__locals0.StartDate;
			totalOrderPostModel.EndDate = CS_0024_003C_003E8__locals0.EndDate;
			string text = SyncTask(totalOrderPostModel, "/api/Orders/TotalOrdersSyncedConfirmation");
			if (string.IsNullOrEmpty(text))
			{
				WriteToSyncLog("Cloudsync: Total Orders Confirmed");
				return true;
			}
			WriteToSyncLog("Cloudsync: Error confirming logs. " + text);
			return false;
		}
		catch (Exception ex)
		{
			FailSync("Fail to Check Total Order Confirmation", null, ex.Message + "\n" + ex.StackTrace);
			return false;
		}
	}

	public static void FailSync(string SystemMessage, System.Timers.Timer SyncTimerUsed, string ErrorResponse)
	{
		NotificationMethods.sendCrashStringOnly(POSVersion.AppVersion, Environment.OSVersion.VersionString, ErrorResponse);
		WriteToSyncLog(ErrorResponse);
		DebugMethods.ShowErrorTextFile(ErrorResponse);
		sync_inprocess = false;
		SyncTimerUsed.Enabled = false;
	}

	public static void FailSync(string SystemMessage, System.Timers.Timer SyncTimerUsed, Exception ErrorResponse)
	{
		NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, ErrorResponse);
		WriteToSyncLog(ErrorResponse.Message);
		DebugMethods.ShowExceptionTextFile(ErrorResponse);
		sync_inprocess = false;
		SyncTimerUsed.Enabled = false;
	}

	public static void ItemsAndGroupsStationsRefresh()
	{
		GClass6 gClass = new GClass6();
		foreach (Terminal item in gClass.Terminals.ToList())
		{
			item.ItemsInGroupsRefreshRequired = true;
		}
		Helper.SubmitChangesWithCatch(gClass);
	}

	public static void WriteToSyncLog(string Message, string file_prefix = "SyncLogs_")
	{
		_003C_003Ec__DisplayClass127_0 _003C_003Ec__DisplayClass127_ = new _003C_003Ec__DisplayClass127_0();
		_003C_003Ec__DisplayClass127_.Message = Message;
		_003C_003Ec__DisplayClass127_.file_prefix = file_prefix;
		new Thread((ThreadStart)delegate
		{
			try
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs";
				_003C_003Ec__DisplayClass127_.Message = "[" + DateTime.Now.ToLongTimeString() + "] " + _003C_003Ec__DisplayClass127_.Message;
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				string path2 = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs\\" + _003C_003Ec__DisplayClass127_.file_prefix + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
				if (!File.Exists(path2))
				{
					using (StreamWriter streamWriter = File.CreateText(path2))
					{
						streamWriter.WriteLine(_003C_003Ec__DisplayClass127_.Message);
						streamWriter.Close();
						return;
					}
				}
				using StreamWriter streamWriter2 = File.AppendText(path2);
				streamWriter2.WriteLine(_003C_003Ec__DisplayClass127_.Message);
			}
			catch (Exception)
			{
			}
		}).Start();
	}

	public static void WriteToTestLog(string Message)
	{
		string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs";
		Message = "[" + DateTime.Now.ToLongTimeString() + "] " + Message;
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		string path2 = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs\\Test_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
		if (!File.Exists(path2))
		{
			using (StreamWriter streamWriter = File.CreateText(path2))
			{
				streamWriter.WriteLine(Message);
				return;
			}
		}
		using StreamWriter streamWriter2 = File.AppendText(path2);
		streamWriter2.WriteLine(Message);
	}

	public SyncMethods()
	{
		Class2.oOsq41PzvTVMr();
		base._002Ector();
	}

	static SyncMethods()
	{
		Class2.oOsq41PzvTVMr();
		groups_to_sync = new List<Group>();
		items_to_sync = new List<Item>();
		inventory_audits_to_sync = new List<InventoryAudit>();
		inventory_batches_to_sync = new List<InventoryBatch>();
		tax_rules_to_sync = new List<TaxRule>();
		tax_to_sync = new List<Tax>();
		tax_rules_operation_to_sync = new List<TaxRuleOperation>();
		item_types_to_sync = new List<ItemType>();
		suppliers_to_sync = new List<Supplier>();
		appointments_to_sync = new List<Appointment>();
		employees_to_sync = new List<Employee>();
		reasons_to_sync = new List<Reason>();
		options_to_sync = new List<Option>();
		itemsWithOption_to_sync = new List<ItemsWithOption>();
		instructions_to_sync = new List<SpecialInstruction>();
		members_to_sync = new List<Customer>();
		stations_to_sync = new List<Station>();
		settings_to_sync = new List<Setting>();
		custom_field_to_sync = new List<CustomField>();
		promotions_to_sync = new List<Promotion>();
		uoms_to_sync = new List<UOM>();
		data_archivers_to_sync = new List<CloudsyncDataArchiver>();
		check_inventory_items = new List<CheckInventoryCountItemModel>();
		string_0 = AppDomain.CurrentDomain.BaseDirectory + "videos\\";
		synced_count = 1;
		total_count = 0;
		total_orders_to_sync = 0;
		total_refunds_to_sync = 0;
		inventorySyncResult = true;
		syncOverride = false;
		sync_inprocess = false;
		orderSyncing = false;
		isSyncingOrdersFromCS = false;
		isSyncingThirdPartyQueuesFromCS = false;
		isCountFinished = true;
		isSettingsSynced = false;
		isImageDownloading = false;
		currentlyDownloading = false;
		currentlyUploading = false;
		currentlyDownloadingImagesFromCS = false;
		employeeClockInOutSyncing = false;
		previousSyncError = false;
		dictionary_0 = new Dictionary<string, DateTime>();
		bool_0 = false;
	}
}
