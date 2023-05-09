using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using CorePOS.Business.Enums;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;

namespace CorePOS.Business.Methods;

public class GlobalSyncHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public string day;

		public _003C_003Ec__DisplayClass41_0()
		{
			Class2.oOsq41PzvTVMr();
			// base._002Ector();
		}
	}

	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private Timer timer_0;

	private Timer timer_1;

	private Timer timer_2;

	private Timer timer_3;

	private Timer timer_4;

	private Timer timer_5;

	private Timer timer_6;

	private Timer timer_7;

	private Timer timer_8;

	private Timer timer_9;

	private Timer timer_10;

	private Timer timer_11;

	private Timer timer_12;

	private Timer timer_13;

	public GlobalSyncHelper()
	{
		Class2.oOsq41PzvTVMr();
		string_0 = "";
		string_1 = "";
		timer_0 = new Timer();
		timer_1 = new Timer();
		timer_2 = new Timer();
		timer_3 = new Timer();
		timer_4 = new Timer();
		timer_5 = new Timer();
		timer_6 = new Timer();
		timer_7 = new Timer();
		timer_8 = new Timer();
		timer_9 = new Timer();
		timer_10 = new Timer();
		timer_11 = new Timer();
		timer_12 = new Timer();
		timer_13 = new Timer();
		// base._002Ector();
	}

	public void StartGlobalSync()
	{
		try
		{
			SyncMethods.WriteToSyncLog("Sync Service is Started");
			method_1();
			SyncMethods.CheckInternet();
			method_0();
			SettingsHelper.SetAllSettings();
			method_2();
			timer_0.Elapsed += timer_0_Elapsed;
			timer_0.Interval = 300000.0;
			timer_0.Enabled = true;
			timer_1.Elapsed += timer_1_Elapsed;
			timer_1.Interval = 60000.0;
			timer_1.Enabled = true;
			timer_2.Elapsed += timer_2_Elapsed;
			timer_2.Interval = 10000.0;
			timer_2.Enabled = false;
			timer_3.Elapsed += timer_3_Elapsed;
			timer_3.Interval = 30000.0;
			timer_3.Enabled = false;
			int num = 30000;
			List<OnlineOrderSettingObject> providers = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true);
			if (providers != null && providers.Count > 0)
			{
				num = providers[0].PollInterval * 1000;
			}
			timer_4.Elapsed += timer_4_Elapsed;
			timer_4.Interval = num;
			timer_4.Enabled = false;
			timer_6.Elapsed += timer_6_Elapsed;
			timer_6.Interval = 183000.0;
			timer_6.Enabled = true;
			timer_7.Elapsed += timer_7_Elapsed;
			timer_7.Interval = 30000.0;
			timer_7.Enabled = false;
			timer_8.Elapsed += timer_8_Elapsed;
			timer_8.Interval = 240000.0;
			timer_8.Enabled = false;
			timer_9.Elapsed += timer_9_Elapsed;
			timer_9.Interval = 300000.0;
			timer_9.Enabled = false;
			timer_10.Elapsed += timer_10_Elapsed;
			timer_10.Interval = 300000.0;
			timer_10.Enabled = false;
			timer_11.Elapsed += timer_11_Elapsed;
			timer_11.Interval = 60000.0;
			timer_11.Enabled = false;
			timer_12.Elapsed += timer_12_Elapsed;
			timer_12.Interval = 30000.0;
			timer_12.Enabled = false;
			timer_13.Elapsed += timer_13_Elapsed;
			timer_13.Interval = 1800000.0;
			timer_13.Enabled = true;
			timer_5.Elapsed += timer_5_Elapsed;
			timer_5.Interval = 5000.0;
			timer_5.Enabled = bool_1;
			string_0 = SyncMethods.GetToken();
			string_1 = SyncMethods.GetStation();
			if (!string.IsNullOrEmpty(string_0) && !string.IsNullOrEmpty(string_1) && string_1 == Environment.MachineName && (from x in SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true)
				where x.Provider != OnlineOrderProviders.Hippos
				select x).Count() > 0)
			{
				bool_0 = SyncMethods.ValidateToken();
			}
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog(ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void timer_0_Elapsed(object sender, ElapsedEventArgs e)
	{
		if (timer_1.Enabled)
		{
			return;
		}
		try
		{
			_ = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs";
			string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs\\synclogs\\SyncLogs_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
			if (File.Exists(path) && File.GetLastWriteTime(path).AddMinutes(5.0) < DateTime.Now)
			{
				timer_1.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog("Fail Safe Timer ERROR: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void timer_1_Elapsed(object sender, ElapsedEventArgs e)
	{
		method_3();
	}

	private void method_0()
	{
		try
		{
			Helper.SetConnectionString(StringCipher.Decrypt(Helper.GetEncryptedConnectionString(), "DigitalCraftHipPOS"));
			new GClass6().Taxes.FirstOrDefault();
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog(ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void method_1()
	{
		DebugSettings.syncServer = "https://apps.hipposhq.com";
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "pksubeval.key"))
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "devmode.txt";
			string path2 = AppDomain.CurrentDomain.BaseDirectory + "stagingmode.txt";
			if (File.Exists(path))
			{
				Servers.sync_server = (DebugSettings.syncServer = "https://appsdev.hipposhq.com");
			}
			else if (File.Exists(path2))
			{
				Servers.sync_server = (DebugSettings.syncServer = "https://appstaging.hipposhq.com");
			}
		}
	}

	private void method_2()
	{
		SyncMethods.WriteToSyncLog("Checking ThirdParty Subscription", "OnlineOrderSync_");
		GClass6 gClass = new GClass6();
		GetSubscriptionPostModel getSubscriptionPostModel = new GetSubscriptionPostModel();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (terminal == null)
		{
			bool_1 = false;
			return;
		}
		bool_1 = false;
		getSubscriptionPostModel.productkey = terminal.ProductKey;
		SubscriptionResponseData subscriptions = SyncMethods.GetSubscriptions(getSubscriptionPostModel);
		if (subscriptions.code == 200 && (subscriptions.subscription_ids.Contains(SubscriptionIDs.AddOns.Deliverect_Monthly) || subscriptions.subscription_ids.Contains(SubscriptionIDs.AddOns.SkipTheDishes_Monthly)))
		{
			SyncMethods.WriteToSyncLog("Checking ThirdParty Subscription ", "OnlineOrderSync_");
			bool_1 = true;
		}
	}

	private void method_3()
	{
		if (method_6())
		{
			SyncMethods.BeginSync(timer_2, timer_3);
			timer_10.Enabled = true;
		}
	}

	private void method_4(bool bool_2)
	{
		timer_9.Enabled = bool_2;
		timer_10.Enabled = bool_2;
		timer_8.Enabled = bool_2;
		timer_7.Enabled = bool_2;
	}

	private void method_5(bool bool_2)
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (settingValueByKey == "Disabled")
			{
				SyncMethods.WriteToSyncLog("Hippos Time add on is not enabled.");
				timer_12.Enabled = false;
				SyncMethods.employeeClockInOutSyncing = false;
			}
			else
			{
				SyncMethods.WriteToSyncLog("Hippos Time timer status change: " + bool_2);
				timer_12.Enabled = bool_2;
			}
		}
		else
		{
			SyncMethods.WriteToSyncLog("Hippos Time timer status change: " + bool_2);
			timer_12.Enabled = bool_2;
		}
		timer_11.Enabled = bool_2;
		timer_4.Enabled = bool_2 && SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).Count > 0;
		timer_5.Enabled = bool_1;
	}

	private bool method_6(bool bool_2 = false)
	{
		if (!SyncMethods.CheckInternet())
		{
			method_4(bool_2: false);
			method_5(bool_2: false);
			return false;
		}
		method_4(bool_2: true);
		string_1 = SyncMethods.GetStation();
		if (!SyncMethods.syncOverride && !bool_2 && !SyncMethods.IsCloudSyncTimerStarted())
		{
			return false;
		}
		if (string.IsNullOrEmpty(string_0))
		{
			if ((from x in SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true)
				where x.Provider != OnlineOrderProviders.Hippos
				select x).Count() == 0 || !bool_2)
			{
				timer_2.Enabled = false;
				SyncMethods.WriteToSyncLog("CloudSync not enabled.");
				return false;
			}
		}
		else
		{
			if (string.IsNullOrEmpty(string_1))
			{
				timer_2.Enabled = false;
				SyncMethods.WriteToSyncLog("CloudSync Failed: Sync Station does not exist or was not configured.");
				return false;
			}
			if (string_1 != Environment.MachineName)
			{
				timer_2.Enabled = false;
				SyncMethods.WriteToSyncLog("CloudSync not enabled for this station.");
				return false;
			}
			if (!bool_0)
			{
				bool_0 = SyncMethods.ValidateToken();
				if (!bool_0)
				{
					return false;
				}
			}
		}
		method_5(bool_2: true);
		SyncMethods.WriteToSyncLog("Check sync: OK");
		return true;
	}

	private void timer_2_Elapsed(object sender, EventArgs e)
	{
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			SyncMethods.WriteToSyncLog("CLOUDSYNC DISABLED DUE TO TRAINING MODE.");
			timer_2.Enabled = false;
			SyncMethods.sync_inprocess = false;
		}
		else
		{
			if (SyncMethods.orderSyncing || !SyncMethods.IsCloudSyncTimerStarted())
			{
				return;
			}
			Timer timer = timer_2;
			SyncMethods.orderSyncing = true;
			timer.Enabled = true;
			if (string.IsNullOrEmpty(string_0))
			{
				Timer timer2 = timer_2;
				SyncMethods.orderSyncing = false;
				timer2.Enabled = false;
				return;
			}
			if (SyncMethods.total_orders_to_sync > 0)
			{
				SyncMethods.SyncOrders(string_0, timer_2);
			}
			if (SyncMethods.total_refunds_to_sync > 0 && SyncMethods.total_orders_to_sync == 0)
			{
				SyncMethods.SyncRefunds(string_0, timer_2);
			}
			else if (SyncMethods.total_refunds_to_sync == 0 && SyncMethods.total_orders_to_sync == 0)
			{
				SyncMethods.SyncRefundsFromCloudsync(string_0, timer_2);
			}
			SyncMethods.orderSyncing = false;
		}
	}

	private void timer_3_Elapsed(object sender, EventArgs e)
	{
		if (!SyncMethods.sync_inprocess)
		{
			SyncMethods.SyncInventory(timer_3);
			SyncMethods.syncOverride = false;
		}
	}

	private void method_7(string string_2)
	{
		SyncMethods.WriteToSyncLog(string_2);
	}

	private void timer_4_Elapsed(object sender, EventArgs e)
	{
		try
		{
			SyncMethods.WriteToSyncLog("OrderSyncFromCloudsyncTimer Started", "OnlineOrderSync_");
			if (method_6(bool_2: true) && !(string_1 != Environment.MachineName))
			{
				int num = 30000;
				List<OnlineOrderSettingObject> providers = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true);
				if (providers != null && providers.Count > 0)
				{
					num = providers[0].PollInterval * 1000;
				}
				if ((double)num != timer_4.Interval)
				{
					timer_4.Interval = num;
				}
				SyncMethods.WriteToSyncLog("OrderSyncFromCloudsyncTimer POLL at " + num + " ms", "OnlineOrderSync_");
				SyncMethods.SyncOnlineOrders(timer_2);
				if (!SyncMethods.isSettingsSynced && !string.IsNullOrEmpty(string_0))
				{
					SyncMethods.SyncGiftLoyaltyCardSettings(string_0, timer_4);
				}
			}
			else
			{
				timer_4.Enabled = false;
			}
		}
		catch (Exception errorResponse)
		{
			SyncMethods.FailSync("Sync Orders From Cloudsync Failed", timer_4, errorResponse);
		}
	}

	private void timer_5_Elapsed(object sender, EventArgs e)
	{
		try
		{
			SyncMethods.WriteToSyncLog("ThirdPartyOrderQueuesSyncCloudsyncTimer Started", "OnlineOrderSync_");
			if (method_6(bool_2: true) && !(string_1 != Environment.MachineName))
			{
				int num = 5000;
				List<OnlineOrderSettingObject> providers = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true);
				if (providers != null && providers.Count > 0)
				{
					num = providers[0].PollInterval * 1000;
				}
				if ((double)num != timer_5.Interval)
				{
					timer_5.Interval = num;
				}
				SyncMethods.WriteToSyncLog("ThirdPartyOrderQueuesSyncCloudsyncTimer POLL at " + num + " ms", "OnlineOrderSync_");
				SyncMethods.SyncThirdPartyOrderQueues(timer_5);
			}
			else
			{
				timer_5.Enabled = false;
			}
		}
		catch (Exception errorResponse)
		{
			SyncMethods.FailSync("ThirdPartyOrderQueuesSyncCloudsyncTimer Failed", timer_5, errorResponse);
		}
	}

	private void timer_6_Elapsed(object sender, EventArgs e)
	{
		try
		{
			if (!SyncMethods.CheckInternet())
			{
				method_7("No internet");
				method_4(bool_2: false);
				method_5(bool_2: false);
				timer_1.Enabled = true;
				return;
			}
			method_7("General Timer Disabled for CheckSync");
			timer_1.Enabled = false;
			try
			{
				method_4(bool_2: true);
				method_5(bool_2: true);
				if (SyncMethods.IsCloudSyncTimerStarted() && !SyncMethods.syncOverride)
				{
					SyncMethods.syncOverride = true;
					if (!method_6())
					{
						timer_1.Enabled = true;
						return;
					}
					method_7("Check sync from cloudsync started.");
					SyncMethods.sync_inprocess = false;
					SyncMethods.BeginSync(timer_2, timer_3);
				}
			}
			catch (Exception errorResponse)
			{
				SyncMethods.FailSync("Error Check sync from cloudsync.", timer_3, errorResponse);
			}
			method_7("General Timer Enabled");
			timer_1.Enabled = true;
		}
		catch (Exception errorResponse2)
		{
			SyncMethods.FailSync("Error Check sync from cloudsync.", timer_3, errorResponse2);
			timer_1.Enabled = true;
		}
	}

	private void timer_8_Elapsed(object sender, EventArgs e)
	{
		if (method_6() && !Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]) && !SyncMethods.isImageDownloading)
		{
			SyncMethods.DownloadItemAndGroupImages(timer_8);
		}
	}

	private void timer_9_Elapsed(object sender, EventArgs e)
	{
		if (!SyncMethods.currentlyDownloading)
		{
			SyncMethods.DownloadVideos();
		}
	}

	private void timer_10_Elapsed(object sender, EventArgs e)
	{
		if (!SyncMethods.currentlyUploading)
		{
			SyncMethods.UploadVideos();
		}
	}

	private void timer_7_Elapsed(object sender, EventArgs e)
	{
		if (!SyncMethods.currentlyUploading)
		{
			SyncMethods.UploadImages();
		}
	}

	private void timer_11_Elapsed(object sender, EventArgs e)
	{
		if (!SyncMethods.currentlyDownloadingImagesFromCS)
		{
			SyncMethods.SyncSecondScreenImages(timer_11);
		}
	}

	private void timer_12_Elapsed(object sender, EventArgs e)
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
		if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey == "Disabled")
		{
			SyncMethods.WriteToSyncLog("Hippos Time add on is not enabled.");
			timer_12.Enabled = false;
			SyncMethods.employeeClockInOutSyncing = false;
			return;
		}
		SyncMethods.WriteToSyncLog("Hippos Time: isSyncing status: " + SyncMethods.employeeClockInOutSyncing);
		if (SyncMethods.employeeClockInOutSyncing)
		{
			return;
		}
		try
		{
			SyncMethods.SyncEmployeeClockInOut();
			SyncMethods.employeeClockInOutSyncing = true;
			if (new GClass6().EmployeeClockInOutQueues.Where((EmployeeClockInOutQueue a) => a.Synced == false && (a.Action == "hippos-clockin" || a.Action == "hippos-clockout")).Count() == 0)
			{
				SyncMethods.SyncEmployeeClockInOutFromHipposTime();
			}
			SyncMethods.employeeClockInOutSyncing = false;
		}
		catch
		{
			SyncMethods.WriteToSyncLog("Hippos Time: Employee Clock InOut Timer Failed.");
		}
		SyncMethods.employeeClockInOutSyncing = false;
	}

	private void timer_13_Elapsed(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		if (!method_6(bool_2: true))
		{
			return;
		}
		DateTime now = DateTime.Now;
		now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
		DateTime now2 = DateTime.Now;
		now2 = new DateTime(now2.Year, now2.Month, now2.Day, 23, 59, 59);
		CultureInfo cultureInfo = new CultureInfo("en-US");
		CS_0024_003C_003E8__locals0.day = cultureInfo.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
		GClass6 gClass = new GClass6();
		BusinessHour businessHour = gClass.BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek == CS_0024_003C_003E8__locals0.day.ToLower()).FirstOrDefault();
		if (businessHour != null)
		{
			string latestClosingTime = businessHour.LatestClosingTime;
			string latestOpeningTime = businessHour.LatestOpeningTime;
			now = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestOpeningTime);
			now2 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestClosingTime);
		}
		if (now2.Hour >= 23)
		{
			CS_0024_003C_003E8__locals0.day = cultureInfo.DateTimeFormat.GetDayName(DateTime.Today.AddDays(-1.0).DayOfWeek);
			businessHour = gClass.BusinessHours.Where((BusinessHour x) => x.DayOfTheWeek == CS_0024_003C_003E8__locals0.day.ToLower()).FirstOrDefault();
			if (businessHour != null)
			{
				string latestClosingTime2 = businessHour.LatestClosingTime;
				string latestOpeningTime2 = businessHour.LatestOpeningTime;
				now = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestOpeningTime2);
				now2 = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString() + " " + latestClosingTime2);
			}
			else
			{
				now = now.AddDays(-1.0);
				now2 = now2.AddDays(-1.0);
			}
		}
		if (!(DateTime.Now >= now2.AddHours(1.0)) || !(DateTime.Now <= now2.AddHours(1.0).AddMinutes(10.0)))
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < 2; i++)
		{
			if (flag = SyncMethods.CheckTotalOrderConfirmation(string_0, now, now2))
			{
				break;
			}
			method_3();
		}
		if (!flag)
		{
			string text = "Error: Total confirmation order has failed twice.";
			NotificationMethods.sendCrashStringOnly(POSVersion.AppVersion, Environment.OSVersion.VersionString, text);
			SyncMethods.WriteToSyncLog(text);
		}
	}
}
