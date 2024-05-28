using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Methods.ThirdPartyAPIs.OnlineOrdering;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Microsoft.Win32;
using Traysoft.AddTapi;

namespace CorePOS;

public class frmSplash : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public ServiceController ctl;

		public frmSplash _003C_003E4__this;

		public _003C_003Ec__DisplayClass23_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRunSyncService_003Eb__1()
		{
			while (_003C_003E4__this.int_0 <= 2 && ctl.Status != ServiceControllerStatus.Running)
			{
				try
				{
					ctl.Start(new string[0]);
					Thread.Sleep(2000);
					ctl.Refresh();
					if (ctl.Status == ServiceControllerStatus.Running)
					{
						if (_003C_003E4__this.bool_5)
						{
							NotificationMethods.sendCrashStringOnly(AppSettings.AppVersion, Environment.OSVersion.VersionString, "SYNC SERVICE RESTART SUCCESSFULLY");
						}
						_003C_003E4__this.int_0 = -1;
						_003C_003E4__this.bool_5 = false;
						break;
					}
					_003C_003E4__this.int_0++;
					continue;
				}
				catch
				{
				}
				break;
			}
			ctl.Refresh();
			if (_003C_003E4__this.int_0 > 2 && ctl.Status != ServiceControllerStatus.Running)
			{
				NotificationMethods.sendCrashStringOnly(AppSettings.AppVersion, Environment.OSVersion.VersionString, "SYNC SERVICE START FAILED: Sync service failed to start after 3 attemptes. Hippos will attemp again in a few minutes.");
				_003C_003E4__this.int_0 = -1;
				_003C_003E4__this.bool_5 = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public object sender;

		public _003C_003Ec__DisplayClass29_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public int dayEndEmpId;

		public DateTime start;

		public DateTime end;

		public List<string> onlineOrderNumbers;

		public List<Order> all_onlineOrders;

		public GClass6 context;

		public _003C_003Ec__DisplayClass33_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnDayClosing_Click_003Eb__5(Order x)
		{
			if (!x.Paid && x.UserServed == (short)dayEndEmpId)
			{
				return x.DateCreated.Value > DateTime.Now.AddDays(-1.0);
			}
			return false;
		}

		internal void _003CbtnDayClosing_Click_003Eb__16()
		{
			using List<string>.Enumerator enumerator = onlineOrderNumbers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass33_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_2
				{
					onlineOrderNumber = enumerator.Current
				};
				List<Order> list = all_onlineOrders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.onlineOrderNumber).ToList();
				if (SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals0.onlineOrderNumber, "Completed", string.Empty, string.Empty, list.FirstOrDefault().Source).code != 200)
				{
					continue;
				}
				foreach (Order item in list)
				{
					item.DateCleared = DateTime.Now;
				}
				context.SubmitChanges();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_1
	{
		public int empId;

		public _003C_003Ec__DisplayClass33_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass33_2
	{
		public string onlineOrderNumber;

		public _003C_003Ec__DisplayClass33_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CbtnDayClosing_Click_003Eb__17(Order x)
		{
			return x.OrderNumber == onlineOrderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_0
	{
		public List<Guid> orderIDs;

		public _003C_003Ec__DisplayClass68_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_1
	{
		public List<string> onlineOrderCustomerPhoneNumbers;

		public _003C_003Ec__DisplayClass68_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_2
	{
		public OrderPostDataModel orderRes;

		public _003C_003Ec__DisplayClass68_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessHipposOnlineOrderingOrders_003Eb__9(Order a)
		{
			return a.OrderId.ToString() == orderRes.customer_order_id;
		}

		internal bool _003CProcessHipposOnlineOrderingOrders_003Eb__10(Item a)
		{
			return a.ItemID == orderRes.item_id;
		}

		internal bool _003CProcessHipposOnlineOrderingOrders_003Eb__11(Customer x)
		{
			if (!(x.CustomerCell == orderRes.customer_phone))
			{
				return x.CustomerHome == orderRes.customer_phone;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_3
	{
		public Order newOrder;

		public _003C_003Ec__DisplayClass68_3()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessHipposOnlineOrderingOrders_003Eb__12(OnlineOrderSourceObject a)
		{
			return a.OrderNumber == newOrder.OrderNumber;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass68_4
	{
		public OrderPostDataModel opdm;

		public _003C_003Ec__DisplayClass68_4()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessHipposOnlineOrderingOrders_003Eb__17(OrderPostDataModel a)
		{
			return a.order_number == opdm.order_number;
		}
	}

	private GClass6 gclass6_0;

	private string string_0;

	private DateTime dateTime_0;

	private bool GdfFoxLrArD;

	private SMTPSettings smtpsettings_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool bool_1;

	private List<int> list_0;

	private frmLayout frmLayout_0;

	private Terminal terminal_0;

	public PersistentNotification PersistentNotification;

	private Dictionary<string, DateTime> dictionary_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private int int_0;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private IContainer iMoFoirRqq0;

	internal Button btnClose;

	internal Button btnDayClosing;

	internal Button btnStation1;

	internal Button btnAdmin;

	internal Button btnPay;

	internal Button btnInventory;

	internal Button btnRefund;

	private Panel panel1;

	internal Button btnStation2;

	private Label lblVersion;

	private Label lblSystemMessage;

	private Label lblTrainingMode;

	private Label lblCompanyName;

	private System.Windows.Forms.Timer timer_0;

	private System.Windows.Forms.Timer timer_1;

	internal Button btnHelp;

	internal Button btnViewOrders;

	internal Button btnReports;

	private System.Windows.Forms.Timer timer_2;

	private Label lblEULA;

	private PictureBox pictureBox2;

	internal Button btnMembers;

	internal Button btnTimeAttendance;

	internal Button btnLanguageChange;

	internal Button btnLogOut;

	internal Button btnNowServing;

	private Label lblUsefulTips;

	private System.Windows.Forms.Timer timer_3;

	private System.Windows.Forms.Timer timer_4;

	internal System.Windows.Forms.Timer timer_5;

	internal System.Windows.Forms.Timer timer_6;

	private Label lblNoInternet;

	private Label label1;

	private Label label2;

	private System.Windows.Forms.Timer timer_7;

	private System.Windows.Forms.Timer timer_8;

	private System.Windows.Forms.Timer timer_9;

	private System.Windows.Forms.Timer timer_10;

	public System.Windows.Forms.Timer OnlineOrderNotifTimer;

	public System.Windows.Forms.Timer DuplicateOpenedPOSCheck;

	private System.Windows.Forms.Timer timer_11;

	public frmSplash()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		string_0 = string.Empty;
		string_1 = SyncMethods.GetToken();
		string_2 = SyncMethods.GetStation();
		dictionary_0 = new Dictionary<string, DateTime>();
		bool_4 = true;
		int_0 = -1;
		// base._002Ector();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("primary_language");
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("secondary_language");
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = currentCulture;
		Thread.CurrentThread.CurrentUICulture = currentCulture;
		InitializeComponent();
		base.Deactivate += frmSplash_Deactivate;
		if (settingValueByKey != settingValueByKey2)
		{
			if (currentCulture.Name == settingValueByKey)
			{
				CultureInfo cultureInfo = new CultureInfo(settingValueByKey2);
				btnLanguageChange.Text = method_4(cultureInfo.NativeName.ToUpper());
				btnLanguageChange.Tag = settingValueByKey2;
				btnLanguageChange.Enabled = true;
			}
			else
			{
				CultureInfo cultureInfo2 = new CultureInfo(settingValueByKey);
				btnLanguageChange.Text = method_4(cultureInfo2.NativeName.ToUpper());
				btnLanguageChange.Tag = settingValueByKey;
				btnLanguageChange.Enabled = true;
			}
		}
		else
		{
			btnLanguageChange.Text = string.Empty;
			btnLanguageChange.Enabled = false;
		}
		new FormHelper().ResizeButtonFonts(this);
		lblVersion.Text = Resources.Version1 + AppSettings.AppVersion + Resources._Build + AppSettings.Build;
		lblCompanyName.Text = Resources.By + " " + BrandingTerms.CompanyFullName;
		lblSystemMessage.MaximumSize = new Size(700, 0);
		int num = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("online_order_notification_audio_time"));
		OnlineOrderNotifTimer.Interval = num * 1000;
		if (!gclass6_0.CompanySetups.FirstOrDefault().isOpen)
		{
			btnDayClosing.Text = Resources.Open_Store;
		}
		timer_3_Tick(null, null);
		string_1 = SyncMethods.GetToken();
		string_2 = SyncMethods.GetStation();
		if (!string.IsNullOrEmpty(string_1) && !string.IsNullOrEmpty(string_2) && string_2 == Environment.MachineName && (from x in SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true)
			where x.Provider != OnlineOrderProviders.Hippos
			select x).Count() > 0)
		{
			bool_0 = SyncMethods.ValidateToken();
		}
		method_3();
		MemoryLoadedObjects.hasOnlineOrderOrModuurn = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).Any();
		if ((MemoryLoadedObjects.hasOnlineOrderOrModuurn || MemoryLoadedObjects.hasThirdPartyOnlineSub) && CheckSync())
		{
			if (SettingsHelper.GetSettingValueByKey("is_sql_dependency") == "ON")
			{
				method_0();
				timer_9.Enabled = false;
			}
			else
			{
				timer_11.Enabled = false;
				if (SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).Count > 0 && string_2 == Environment.MachineName)
				{
					timer_9.Enabled = true;
				}
				else
				{
					timer_9.Enabled = false;
				}
			}
		}
		PersistentNotification = new PersistentNotification();
		base.Controls.Add(PersistentNotification);
	}

	private void method_0()
	{
		if (MemoryLoadedObjects.hasThirdPartyOnlineSub)
		{
			method_15();
		}
		if (MemoryLoadedObjects.hasOnlineOrderOrModuurn)
		{
			method_14();
		}
		if (!Helper.GetConnectionString().Contains("AttachDbFilename"))
		{
			method_16();
			timer_11.Enabled = true;
		}
	}

	private void method_1(object sender, TapiEventArgs e)
	{
		try
		{
			MemoryLoadedObjects.callerID.Name = e.Call.CallerIDName;
			MemoryLoadedObjects.callerID.Number = e.Call.CallerID.Replace("+", string.Empty);
			if (MemoryLoadedObjects.callerID.Number.Length > 10 && MemoryLoadedObjects.callerID.Number.Substring(0, 1) == "1")
			{
				MemoryLoadedObjects.callerID.Number = MemoryLoadedObjects.callerID.Number.Substring(1, MemoryLoadedObjects.callerID.Number.Length - 1);
			}
			MemoryLoadedObjects.callerID.DateCreated = DateTime.Now;
			LogHelper.WriteLog("Tapi Call Received: " + MemoryLoadedObjects.callerID.Name + " Number:" + MemoryLoadedObjects.callerID.Number, LogTypes.call_log);
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog("Tapi Call Receive Failed: " + ex.Message + "\n" + ex.StackTrace, LogTypes.print_log);
		}
	}

	private void method_2(object sender, TapiCallInfoEventArgs e)
	{
		try
		{
			if ((e.CallInfoState & TapiCallInfoState.CallerID) != 0)
			{
				MemoryLoadedObjects.callerID.Name = e.Call.CallerIDName;
				MemoryLoadedObjects.callerID.Number = e.Call.CallerID.Replace("+", string.Empty);
				if (MemoryLoadedObjects.callerID.Number.Length > 10 && MemoryLoadedObjects.callerID.Number.Substring(0, 1) == "1")
				{
					MemoryLoadedObjects.callerID.Number = MemoryLoadedObjects.callerID.Number.Substring(1, MemoryLoadedObjects.callerID.Number.Length - 1);
				}
				MemoryLoadedObjects.callerID.DateCreated = DateTime.Now;
				LogHelper.WriteLog("Tapi Call Info Changed: " + MemoryLoadedObjects.callerID.Name + " Number:" + MemoryLoadedObjects.callerID.Number, LogTypes.call_log);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog("Tapi Call Receive Failed: " + ex.Message + "\n" + ex.StackTrace, LogTypes.call_log);
		}
	}

	private void method_3()
	{
		if (!Helper.GetConnectionString().Contains("AttachDbFilename") && !(SettingsHelper.GetSettingValueByKey("run_sync_service") == "OFF"))
		{
			_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
			CS_0024_003C_003E8__locals0._003C_003E4__this = this;
			bool_2 = true;
			CS_0024_003C_003E8__locals0.ctl = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Hippos Sync Service");
			if (!CheckSync())
			{
				if (CS_0024_003C_003E8__locals0.ctl != null && CS_0024_003C_003E8__locals0.ctl.Status == ServiceControllerStatus.Running)
				{
					CS_0024_003C_003E8__locals0.ctl.Stop();
				}
			}
			else if (CS_0024_003C_003E8__locals0.ctl == null)
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo("cmd.exe", "/c hippos-sync.exe -install")
				{
					FileName = "cmd.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
					RedirectStandardInput = true,
					UseShellExecute = false
				};
				process.Start();
				Thread.Sleep(5000);
				CS_0024_003C_003E8__locals0.ctl = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Hippos Sync Service");
			}
			else if (CS_0024_003C_003E8__locals0.ctl.Status != ServiceControllerStatus.Running)
			{
				new Thread((ThreadStart)delegate
				{
					while (CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 <= 2 && CS_0024_003C_003E8__locals0.ctl.Status != ServiceControllerStatus.Running)
					{
						try
						{
							CS_0024_003C_003E8__locals0.ctl.Start(new string[0]);
							Thread.Sleep(2000);
							CS_0024_003C_003E8__locals0.ctl.Refresh();
							if (CS_0024_003C_003E8__locals0.ctl.Status != ServiceControllerStatus.Running)
							{
								CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 = CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 + 1;
								continue;
							}
							if (CS_0024_003C_003E8__locals0._003C_003E4__this.bool_5)
							{
								NotificationMethods.sendCrashStringOnly(AppSettings.AppVersion, Environment.OSVersion.VersionString, "SYNC SERVICE RESTART SUCCESSFULLY");
							}
							CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 = -1;
							CS_0024_003C_003E8__locals0._003C_003E4__this.bool_5 = false;
						}
						catch
						{
						}
						break;
					}
					CS_0024_003C_003E8__locals0.ctl.Refresh();
					if (CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 > 2 && CS_0024_003C_003E8__locals0.ctl.Status != ServiceControllerStatus.Running)
					{
						NotificationMethods.sendCrashStringOnly(AppSettings.AppVersion, Environment.OSVersion.VersionString, "SYNC SERVICE START FAILED: Sync service failed to start after 3 attemptes. Hippos will attemp again in a few minutes.");
						CS_0024_003C_003E8__locals0._003C_003E4__this.int_0 = -1;
						CS_0024_003C_003E8__locals0._003C_003E4__this.bool_5 = true;
					}
				}).Start();
			}
			else
			{
				int_0 = -1;
			}
			return;
		}
		bool_2 = false;
		if (CheckSync() && !bool_3)
		{
			try
			{
				bool_3 = true;
				new GlobalSyncHelper().StartGlobalSync();
			}
			catch (Exception)
			{
				bool_3 = false;
			}
		}
	}

	private void frmSplash_Activated(object sender, EventArgs e)
	{
		frmStationServingScreen frmStationServingScreen2 = null;
		frmStationServingScreen2 = (frmStationServingScreen)Application.OpenForms["frmStationServingScreen"];
		if (SettingsHelper.GetSettingValueByKey("now_serving_screen") == "ON" && frmStationServingScreen2 != null)
		{
			btnNowServing.Text = "CLOSE NOW SERVING";
		}
		else if (!(SettingsHelper.GetSettingValueByKey("show_payout_button") == "ON") && !(SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON"))
		{
			if (SettingsHelper.GetSettingValueByKey("now_serving_screen") == "ON" && frmStationServingScreen2 == null)
			{
				btnNowServing.Text = Resources.NOW_SERVING;
				btnNowServing.Enabled = true;
			}
			else
			{
				btnNowServing.Text = "";
				btnNowServing.Enabled = false;
			}
		}
		else
		{
			if (SettingsHelper.GetSettingValueByKey("show_payout_button") == "ON" && SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON")
			{
				btnNowServing.Text = "PAYOUT/SAFE DROP";
			}
			else if (SettingsHelper.GetSettingValueByKey("show_payout_button") == "OFF" && SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON")
			{
				btnNowServing.Text = "SAFE DROP";
			}
			else if (SettingsHelper.GetSettingValueByKey("show_payout_button") == "ON" && SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "OFF")
			{
				btnNowServing.Text = "PAYOUT";
			}
			btnNowServing.Enabled = true;
		}
		if (terminal_0 != null)
		{
			Station station = MemoryLoadedObjects.all_stations.Where((Station station_0) => station_0.StationID == terminal_0.DefaultStation2).FirstOrDefault();
			if (SettingsHelper.GetSettingValueByKey("delivery_management") == "ON" && MemoryLoadedData.IsDeliveryManagement)
			{
				btnStation2.Text = "DELIVERY MANAGEMENT";
			}
			else if (station != null)
			{
				btnStation2.Text = station.StationName.ToUpper() + " DISPLAY";
			}
		}
		if (SettingsHelper.GetSettingValueByKey("auto_settlement") == "ON")
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("auto_settlement_time");
			if (!string.IsNullOrEmpty(settingValueByKey))
			{
				dateTime_0 = Convert.ToDateTime(settingValueByKey);
				timer_8.Enabled = true;
			}
		}
		else
		{
			timer_8.Enabled = false;
		}
		timer_10.Enabled = true;
		method_12();
		bool_4 = true;
	}

	private void frmSplash_Deactivate(object sender, EventArgs e)
	{
		timer_10.Enabled = false;
		bool_4 = false;
	}

	private string method_4(string string_3)
	{
		string[] array = string_3.Split(' ');
		string text = string.Empty;
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (!text2.Contains("(") && !text2.Contains(")"))
			{
				text += (string.IsNullOrEmpty(text) ? text2 : (" " + text2));
			}
		}
		return text;
	}

	private void frmSplash_Load(object sender, EventArgs e)
	{
		terminal_0 = MemoryLoadedObjects.this_terminal;
		bool_1 = SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "ON";
		if (terminal_0 != null)
		{
			Station station = MemoryLoadedObjects.all_stations.Where((Station station_0) => station_0.StationID == terminal_0.DefaultStation1).FirstOrDefault();
			Station station2 = MemoryLoadedObjects.all_stations.Where((Station station_0) => station_0.StationID == terminal_0.DefaultStation2).FirstOrDefault();
			if (station != null)
			{
				btnStation1.Text = station.StationName.ToUpper() + " DISPLAY";
			}
			if (SettingsHelper.GetSettingValueByKey("delivery_management") == "ON" && MemoryLoadedData.IsDeliveryManagement)
			{
				btnStation2.Text = "DELIVERY MANAGEMENT";
			}
			else if (station2 != null)
			{
				btnStation2.Text = station2.StationName.ToUpper() + " DISPLAY";
			}
			if (!string.IsNullOrEmpty(terminal_0.PhoneModemDeviceName) && terminal_0.PhoneModemDeviceName != "NONE")
			{
				try
				{
					TapiApp.SerialNumber = "44HEA5M-Q5M9D5K-WPCI8O2-KOUQD";
					TapiApp.Initialize("CallerID");
					TapiLine tapiLine = TapiApp.Lines.Where((TapiLine tapiLine_0) => tapiLine_0.Name == terminal_0.PhoneModemDeviceName).FirstOrDefault();
					if (tapiLine != null)
					{
						if (tapiLine.IsOpen)
						{
							return;
						}
						TapiApp.IncomingCall += method_1;
						TapiApp.CallInfo += method_2;
						tapiLine.RingsToAnswer = 0;
						tapiLine.Open(monitorIncomingCalls: true, null);
					}
				}
				catch
				{
					new NotificationLabel(this, "Unable to initialize phone modem, please check your settings.", NotificationTypes.Warning).Show();
				}
			}
		}
		if (SettingsHelper.CurrentTerminalMode == "Normal")
		{
			timer_2.Enabled = true;
			CompanySetup companySetup = gclass6_0.CompanySetups.FirstOrDefault();
			if (companySetup != null && companySetup.Capacity == 0)
			{
				gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues, companySetup);
				companySetup.Capacity = gclass6_0.Layouts.Where((Layout s) => s.Active == true && !s.TableName.Contains("wall ")).Sum((Layout x) => x.NumOfSeats.Value);
				method_10(gclass6_0);
			}
			ShowEmptyOrderEntrySecondScreen();
		}
		else if (SettingsHelper.CurrentTerminalMode == "Patron")
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN, 0);
			bool flag = false;
			do
			{
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					continue;
				}
				Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee != null)
				{
					if (employee.Users.FirstOrDefault().Role.RoleName == Roles.patron)
					{
						CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
						flag = true;
						MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Layout();
						MemoryLoadedObjects.Layout.LoadFormData();
						MemoryLoadedObjects.Layout.Show(this);
						Close();
					}
					else
					{
						new frmMessageBox("Please enter a 'patron' pin.", "PATRON PIN REQUIRED").ShowDialog(this);
						flag = false;
					}
				}
				else
				{
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag);
		}
		else if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN, 0);
			bool flag2 = false;
			do
			{
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					continue;
				}
				Employee employee2 = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee2 != null)
				{
					if (employee2.Users.FirstOrDefault().Role.RoleName == Roles.kiosk)
					{
						CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee2.EmployeeID;
						flag2 = true;
						new frmKioskOrderTypeSelection().ShowDialog();
					}
					else
					{
						new frmMessageBox(Resources.Please_enter_a_kiosk_pin, Resources.KIOSK_PIN_REQUIRED).ShowDialog(this);
						flag2 = false;
					}
				}
				else
				{
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag2);
		}
		btnLogOut.Enabled = true;
		method_13();
	}

	public void ShowEmptyOrderEntrySecondScreen()
	{
		Setting setting = gclass6_0.Settings.Where((Setting s) => s.Key.ToUpper() == "second_screen".ToUpper()).FirstOrDefault();
		if (setting != null)
		{
			if (AppSettings.ScreenCount >= 2 && setting.Value == "ON")
			{
				if (MemoryLoadedObjects.OrderEntrySecondScreen != null && !MemoryLoadedObjects.OrderEntrySecondScreen.IsDisposed)
				{
					MemoryLoadedObjects.OrderEntrySecondScreen.Show();
				}
				else
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntrySecondScreen();
					Rectangle bounds = AppSettings.SecondaryScreen.Bounds;
					MemoryLoadedObjects.OrderEntrySecondScreen.WindowState = FormWindowState.Normal;
					MemoryLoadedObjects.OrderEntrySecondScreen.TopMost = true;
					MemoryLoadedObjects.OrderEntrySecondScreen.Size = new Size(bounds.Width, bounds.Height);
					MemoryLoadedObjects.OrderEntrySecondScreen.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
					MemoryLoadedObjects.OrderEntrySecondScreen.StartPosition = FormStartPosition.Manual;
					MemoryLoadedObjects.OrderEntrySecondScreen.Show();
				}
				timer_4.Enabled = true;
			}
			else
			{
				MemoryLoadedObjects.OrderEntrySecondScreen = null;
			}
		}
		else
		{
			MemoryLoadedObjects.OrderEntrySecondScreen = null;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals0.sender = sender;
		ModulesAndFeature modulesAndFeature = new GClass6().ModulesAndFeatures.Where((ModulesAndFeature x) => x.ModuleName == "frmSplash" && x.ControlName == ((Button)CS_0024_003C_003E8__locals0.sender).Name).FirstOrDefault();
		if (modulesAndFeature != null)
		{
			List<SecurityMatrix> list = modulesAndFeature.SecurityMatrixes.Where((SecurityMatrix x) => x.IsAllow).ToList();
			List<string> list2 = new List<string>();
			using (List<SecurityMatrix>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					switch (enumerator.Current.RoleID)
					{
					case 1:
						list2.Add(Roles.admin);
						break;
					case 2:
						list2.Add(Roles.manager);
						break;
					case 3:
						list2.Add(Roles.employee);
						break;
					case 6:
						list2.Add(Roles.supervisor);
						break;
					}
				}
			}
			if (list2.Count() != 0 && AuthMethods.ValidatePin(this, list2, showRememberMe: false))
			{
				FormHelper.CleanupObjects();
				method_5();
				Application.ExitThread();
				Process.GetCurrentProcess().CloseMainWindow();
				method_19();
				Application.Exit();
			}
		}
		else
		{
			FormHelper.CleanupObjects();
			method_5();
			Application.ExitThread();
			Process.GetCurrentProcess().CloseMainWindow();
			method_19();
			Application.Exit();
		}
	}

	private void method_5()
	{
		ServiceController serviceController = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Hippos Sync Service");
		if (serviceController != null && serviceController.Status == ServiceControllerStatus.Running)
		{
			serviceController.Stop();
		}
	}

	private void btnNowServing_Click(object sender, EventArgs e)
	{
		frmStationServingScreen frmStationServingScreen2 = null;
		frmStationServingScreen2 = (frmStationServingScreen)Application.OpenForms["frmStationServingScreen"];
		if (SettingsHelper.GetSettingValueByKey("now_serving_screen") == "ON" && frmStationServingScreen2 != null)
		{
			ControlHelpers.CloseNowServingScreen();
			return;
		}
		if (!(SettingsHelper.GetSettingValueByKey("show_payout_button") == "ON") && !(SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON"))
		{
			if (SettingsHelper.GetSettingValueByKey("now_serving_screen") == "ON")
			{
				ControlHelpers.ShowNowServingScreen();
			}
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		MemoryLoadedObjects.Numpad.showRememberMe = false;
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		Employee employee = UserMethods.AuthenticateUser(MemoryLoadedObjects.Numpad.valueEntered);
		if (employee != null)
		{
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
			if (SettingsHelper.GetSettingValueByKey("safe_drop_setting") == "ON")
			{
				new frmPayoutSafeDrop(SettingsHelper.GetSettingValueByKey("show_payout_button") == "ON").ShowDialog(this);
			}
			else
			{
				MiscHelper.ProcessPayout(this);
			}
			AuthMethods.LogOutUser();
		}
	}

	public void ChangeNowServingText(string text)
	{
		btnNowServing.Text = text;
	}

	private void btnDayClosing_Click(object sender, EventArgs e)
	{
		Employee employee = AuthMethods.EmployeeLoginBeforeFormControl(this, "frmDayEndClosing");
		if (employee == null)
		{
			return;
		}
		if (btnDayClosing.Text == Resources.Open_Store)
		{
			GClass8.OpenCashDrawer();
			frmCashCounter frmCashCounter2 = new frmCashCounter(0m, null, PayoutTypes.OpeningBalance);
			if (frmCashCounter2.ShowDialog(this) == DialogResult.OK)
			{
				gclass6_0 = new GClass6();
				CompanySetup companySetup = gclass6_0.CompanySetups.FirstOrDefault();
				companySetup.isOpen = true;
				companySetup.OpeningBalance = frmCashCounter2.amountEntered;
				companySetup.ClosingBalance = 0m;
				gclass6_0.SubmitChanges();
				btnDayClosing.Text = Resources.End_of_day;
				AuthMethods.LogOutUser();
				new NotificationLabel(this, "Opening balance recorded.", NotificationTypes.Success).Show();
			}
			else
			{
				AuthMethods.LogOutUser();
			}
			return;
		}
		string latestOpeningTime = gclass6_0.CompanySetups.FirstOrDefault().LatestOpeningTime;
		string latestClosingTime = gclass6_0.CompanySetups.FirstOrDefault().LatestClosingTime;
		frmSelectDateSingle frmSelectDateSingle2 = new frmSelectDateSingle(Resources.Day_End_Closing_Report, latestOpeningTime, latestClosingTime);
		frmSelectDateSingle2.EmployeeId = employee.EmployeeID;
		if (frmSelectDateSingle2.ShowDialog(this) == DialogResult.OK)
		{
			_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass33_0();
			CS_0024_003C_003E8__locals1.context = new GClass6();
			CS_0024_003C_003E8__locals1.start = frmSelectDateSingle2.getOpenDateTime();
			CS_0024_003C_003E8__locals1.end = frmSelectDateSingle2.getEndDateWithTime();
			if (frmSelectDateSingle2.LastDayType == 0)
			{
				CS_0024_003C_003E8__locals1.end = frmSelectDateSingle2.getEndTime();
				if (CS_0024_003C_003E8__locals1.start > CS_0024_003C_003E8__locals1.end)
				{
					CS_0024_003C_003E8__locals1.end = CS_0024_003C_003E8__locals1.end.AddDays(1.0);
				}
				else if ((CS_0024_003C_003E8__locals1.end - CS_0024_003C_003E8__locals1.start).TotalHours > 24.0)
				{
					CS_0024_003C_003E8__locals1.end = CS_0024_003C_003E8__locals1.end.AddDays(-1.0);
				}
			}
			CS_0024_003C_003E8__locals1.dayEndEmpId = frmSelectDateSingle2.EmployeeId;
			int terminalId = frmSelectDateSingle2.TerminalId;
			if (frmSelectDateSingle2.LastDayType == 2)
			{
				new PrintHelper().PrintDeliveryCommission(CS_0024_003C_003E8__locals1.start, CS_0024_003C_003E8__locals1.end, CS_0024_003C_003E8__locals1.dayEndEmpId, ReportTypes.DeliveryCommission);
				return;
			}
			if (frmSelectDateSingle2.LastDayType == 3)
			{
				new PrintHelper().PrintDeliveryCommission(CS_0024_003C_003E8__locals1.start, CS_0024_003C_003E8__locals1.end, CS_0024_003C_003E8__locals1.dayEndEmpId, ReportTypes.DeliveryDrivers);
				return;
			}
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
			{
				bool flag = false;
				if ((CS_0024_003C_003E8__locals1.dayEndEmpId > 0) ? ((from x in new OrderMethods(CS_0024_003C_003E8__locals1.context).OpenOrders(OrderTypes.DineIn, 2)
					where !x.Paid && x.UserServed == (short)CS_0024_003C_003E8__locals1.dayEndEmpId && x.DateCreated.Value > DateTime.Now.AddDays(-1.0)
					select x).Count() > 0) : ((from x in new OrderMethods(CS_0024_003C_003E8__locals1.context).OpenOrders(OrderTypes.DineIn, 2)
					where !x.Paid && x.DateCreated.Value > DateTime.Now.AddDays(-1.0)
					select x).Count() > 0))
				{
					new frmMessageBox("Please close all your tables or assign them to another employee before proceeding with your end of day procedures.", "PENDING OPEN TABLES", CustomMessageBoxButtons.Ok).ShowDialog();
					return;
				}
			}
			string roleName = employee.Users.First().Role.RoleName;
			if (SettingsHelper.GetSettingValueByKey("openclose_store") == "ON" && (roleName == Roles.admin || roleName == Roles.manager) && new frmMessageBox("Do you want to close the store?", "Close Store", CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				GClass8.OpenCashDrawer();
				frmCashCounter frmCashCounter3 = new frmCashCounter(OrderMethods.GetTotalAmountInTil(), null, PayoutTypes.ClosingBalance);
				if (frmCashCounter3.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				CS_0024_003C_003E8__locals1.context = new GClass6();
				CompanySetup companySetup2 = CS_0024_003C_003E8__locals1.context.CompanySetups.FirstOrDefault();
				companySetup2.isOpen = false;
				companySetup2.ClosingBalance = frmCashCounter3.amountEntered;
				CS_0024_003C_003E8__locals1.context.SubmitChanges();
				btnDayClosing.Text = Resources.Open_Store;
				AuthMethods.LogOutUser();
				new NotificationLabel(this, "Closing balance recorded.", NotificationTypes.Success).Show();
			}
			ReceiptMethods.ParseDayEndTotals(CS_0024_003C_003E8__locals1.start, CS_0024_003C_003E8__locals1.end, CS_0024_003C_003E8__locals1.dayEndEmpId, terminalId);
			new PrintHelper().GenerateDayEndTotals(CS_0024_003C_003E8__locals1.start, CS_0024_003C_003E8__locals1.end, CS_0024_003C_003E8__locals1.dayEndEmpId, terminalId);
			List<ChitPrintQueue> entities = CS_0024_003C_003E8__locals1.context.ChitPrintQueues.Where((ChitPrintQueue x) => x.Printed == true).ToList();
			CS_0024_003C_003E8__locals1.context.ChitPrintQueues.DeleteAllOnSubmit(entities);
			Helper.SubmitChangesWithCatch(CS_0024_003C_003E8__locals1.context);
			if (SettingsHelper.GetSettingValueByKey("use_payment_processor") == "ON" && (roleName == Roles.admin || roleName == Roles.manager))
			{
				Terminal terminal = CS_0024_003C_003E8__locals1.context.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
				if (terminal != null && terminal.PaymentTerminalModel != PaymentTerminalModels.Clover.Flex && !string.IsNullOrEmpty(terminal.PaymentMerchantID) && !string.IsNullOrEmpty(terminal.PaymentProviderName) && !string.IsNullOrEmpty(terminal.PaymentTerminalAddress) && !string.IsNullOrEmpty(terminal.PaymentTerminalModel) && terminal.PaymentTerminalPort > 0 && (CS_0024_003C_003E8__locals1.start.Date == DateTime.Now.Date || CS_0024_003C_003E8__locals1.end.Date == DateTime.Now.Date || CS_0024_003C_003E8__locals1.start.Date == DateTime.Now.Date.AddDays(-1.0) || CS_0024_003C_003E8__locals1.end.Date == DateTime.Now.Date.AddDays(-1.0)) && new frmMessageBox(Resources.Would_you_like_to_perform_End_, Resources.PINPAD_SETTLEMENT, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
				{
					PaymentTransactionObject paymentTransactionObject = new PaymentTransactionObject();
					if (terminal.PaymentProviderName == PaymentProviderNames.FirstData)
					{
						if (terminal.PaymentTerminalModel == PaymentTerminalModels.Clover.Flex)
						{
							CloverTransactionObject.Request request = new CloverTransactionObject.Request();
							request.RequestType = "settlement";
							if ((from x in CS_0024_003C_003E8__locals1.context.PaymentTerminalTransactionLogs
								where x.DateCreated >= CS_0024_003C_003E8__locals1.start && x.DateCreated <= CS_0024_003C_003E8__locals1.end
								select x into y
								orderby y.DateCreated descending
								select y).FirstOrDefault() != null)
							{
								frmWaitingPaymentTerminal obj = new frmWaitingPaymentTerminal(PaymentProviderNames.FirstData, terminal.PaymentTerminalModel, terminal.PaymentTerminalAddress, terminal.PaymentTerminalPort, request, "");
								obj.ShowDialog();
								paymentTransactionObject = obj.transaction_objects.FirstOrDefault();
								if (paymentTransactionObject != null)
								{
									if (paymentTransactionObject.responsecode != null && paymentTransactionObject.responsecode.Equals("00"))
									{
										new PrintHelper();
									}
									else
									{
										new NotificationLabel(this, Resources.Unable_to_connect_to_pinpad_te, NotificationTypes.Warning).Show();
									}
								}
								else
								{
									new NotificationLabel(this, Resources.Unable_to_connect_to_pinpad_te, NotificationTypes.Warning).Show();
								}
							}
							else
							{
								new NotificationLabel(this, "There are no transactions to settle.", NotificationTypes.Notification).Show();
							}
						}
						else
						{
							string request2 = "transactiontype^settlement^clerkid^" + employee.EmployeeID + "^merchantid^" + terminal.PaymentMerchantID + "^transactiondate^" + DateTime.Now.ToString("MMddyy") + "^transactiontime^" + DateTime.Now.ToString("HHmmss") + "^";
							request2 = FirstData.addStringLength(request2);
							frmWaitingPaymentTerminal frmWaitingPaymentTerminal2 = new frmWaitingPaymentTerminal(terminal.PaymentProviderName, terminal.PaymentTerminalModel, terminal.PaymentTerminalAddress, terminal.PaymentTerminalPort, request2, parseObject: false, null, "");
							if (frmWaitingPaymentTerminal2.ShowDialog() == DialogResult.OK)
							{
								paymentTransactionObject = frmWaitingPaymentTerminal2.transaction_objects.FirstOrDefault();
								if (paymentTransactionObject.responsecode != null)
								{
									if (paymentTransactionObject.responsecode.Equals("00"))
									{
										string[] array = paymentTransactionObject.rawdata.Split('^');
										Dictionary<string, string> dictionary = new Dictionary<string, string>();
										for (int i = 0; i < array.Length - 1; i += 2)
										{
											dictionary.Add(array[i], array[i + 1] + "<br/>");
										}
										new PrintHelper().PrintString((from x in dictionary
											where x.Key == "settlementreport"
											select x into y
											select y.Value).FirstOrDefault(), 9, null, "Courier New");
									}
									else
									{
										new NotificationLabel(this, Resources.Unable_to_perform_settlement, NotificationTypes.Warning).Show();
									}
								}
								else
								{
									new NotificationLabel(this, Resources.Unable_to_connect_to_pinpad_te, NotificationTypes.Warning).Show();
								}
							}
						}
					}
					else
					{
						List<PaymentTransactionObject> trans_objects = new List<PaymentTransactionObject>();
						if (UIPaymentHelper.ProcessIngenico(terminal.PaymentProviderName, this, terminal, "settlement", 0, null, "", null, out trans_objects))
						{
							if (trans_objects.FirstOrDefault() != null)
							{
								string text = Ingenico.BuildSettlementReport(trans_objects.FirstOrDefault().rawdata);
								new PrintHelper().PrintString(text, 9, null, "Courier New", isBold: false, text.Contains("<br/>"));
							}
						}
						else
						{
							new NotificationLabel(this, Resources.Unable_to_connect_to_pinpad_te, NotificationTypes.Warning).Show();
						}
					}
				}
			}
			if (SettingsHelper.GetSettingValueByKey("use_order_ticket") == "ON" && (roleName == Roles.admin || roleName == Roles.manager) && new frmMessageBox("Do you want to reset the order ticket numbers?", "TICKET NUMBER RESET", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				OrderMethods.ResetOrderTicketNumbers();
				new NotificationLabel(this, "Order ticket # has been reset.", NotificationTypes.Success).Show();
			}
			if (CS_0024_003C_003E8__locals1.context.Items.Where((Item a) => a.AutoResetQty == true && a.TrackInventory == true).Count() > 0 && (roleName == Roles.admin || roleName == Roles.manager) && new frmMessageBox("Do you want to reset the inventory for items that have been configured to reset at the end of day?", "Auto Reset Inventory", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				foreach (Item item in CS_0024_003C_003E8__locals1.context.Items.Where((Item a) => a.AutoResetQty == true && a.TrackInventory == true).ToList())
				{
					decimal inventoryCount = item.InventoryCount;
					decimal resetQty = item.ResetQty;
					decimal num = resetQty - inventoryCount;
					int supplierId = 0;
					if (num > 0m)
					{
						List<Supplier> itemsSuppliers = AdminMethods.GetItemsSuppliers(item.ItemID);
						if (itemsSuppliers.Count > 0)
						{
							Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
							foreach (Supplier item2 in itemsSuppliers)
							{
								dictionary2.Add(item2.Id.ToString(), item2.Name);
							}
							frmDDLSelector frmDDLSelector2 = new frmDDLSelector("Select Supplier", dictionary2);
							if (frmDDLSelector2.ShowDialog(this) == DialogResult.OK)
							{
								supplierId = Convert.ToInt32(frmDDLSelector2.SelectedValue);
							}
						}
					}
					new InventoryMethods(CS_0024_003C_003E8__locals1.context).LogInventoryChange(item.ItemID, inventoryCount, num, resetQty, "Auto Reset", "Automatic Inventory Qty Reset", supplierId);
				}
			}
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
			if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey == "Enabled" && (roleName == Roles.admin || roleName == Roles.manager) && new frmMessageBox("Do you want to clock out all employees?", "CLOCK OUT EMPLOYEES", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				using List<int>.Enumerator enumerator3 = (from a in MemoryLoadedObjects.all_employees
					where a.isActive
					select a.EmployeeID).ToList().GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass33_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_1();
					CS_0024_003C_003E8__locals0.empId = enumerator3.Current;
					EmployeeClockInOutQueue employeeClockInOutQueue = (from a in CS_0024_003C_003E8__locals1.context.EmployeeClockInOutQueues
						where a.EmployeeId == (int?)CS_0024_003C_003E8__locals0.empId
						orderby a.Id descending
						select a).FirstOrDefault();
					if (employeeClockInOutQueue != null && employeeClockInOutQueue.Action == "hippos-clockin")
					{
						ETimeCardMethods.AddEmployeePunchInOutQueue(new HipposClockInOutRequestObject
						{
							cs_apikey = string_1,
							employee_pin = employeeClockInOutQueue.EmployeePin,
							timestamp = HelperMethods.getServerTime(toUTC: false).ToString("MMM dd yyyy hh:mm:ss tt"),
							action = "hippos-clockout",
							employee_id = CS_0024_003C_003E8__locals0.empId
						});
					}
				}
			}
			CS_0024_003C_003E8__locals1.all_onlineOrders = CS_0024_003C_003E8__locals1.context.Orders.Where((Order x) => x.DateCreated > DateTime.Now.AddDays(-1.0) && x.DateCleared.HasValue == false && (x.OrderType == OrderTypes.DeliveryOnline || x.OrderType == OrderTypes.PickUpOnline || x.OrderType == OrderTypes.PickUpCurbsideOnline || x.OrderType == OrderTypes.DineInOnline)).ToList();
			CS_0024_003C_003E8__locals1.onlineOrderNumbers = CS_0024_003C_003E8__locals1.all_onlineOrders.Select((Order x) => x.OrderNumber).Distinct().ToList();
			if (CS_0024_003C_003E8__locals1.onlineOrderNumbers.Count > 0 && new frmMessageBox("Would you like to automatically clear all uncleared PAID online orders?  Order Ready SMS notifications will not be sent.", "CLEAR ONLINE ORDERS?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				new Thread((ThreadStart)delegate
				{
					using List<string>.Enumerator enumerator4 = CS_0024_003C_003E8__locals1.onlineOrderNumbers.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						_003C_003Ec__DisplayClass33_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass33_2();
						CS_0024_003C_003E8__locals0.onlineOrderNumber = enumerator4.Current;
						List<Order> list = CS_0024_003C_003E8__locals1.all_onlineOrders.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals0.onlineOrderNumber).ToList();
						if (SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals0.onlineOrderNumber, "Completed", string.Empty, string.Empty, list.FirstOrDefault().Source).code == 200)
						{
							foreach (Order item3 in list)
							{
								item3.DateCleared = DateTime.Now;
							}
							CS_0024_003C_003E8__locals1.context.SubmitChanges();
						}
					}
				}).Start();
			}
		}
		AuthMethods.LogOutUser();
	}

	private void btnAdmin_Click(object sender, EventArgs e)
	{
		new frmAdmin(lblTrainingMode).Show();
	}

	private void btnInventory_Click(object sender, EventArgs e)
	{
		if (!MemoryLoadedObjects.isUserRemember && !(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0"))
		{
			bool flag = false;
			do
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN, 0);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					flag = true;
					continue;
				}
				Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee != null)
				{
					CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
					CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
					flag = true;
					if (!(employee.Users.FirstOrDefault().Role.RoleName == Roles.admin) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.manager) && !(employee.Users.FirstOrDefault().Role.RoleName == Roles.supervisor))
					{
						new frmInventoryView(employee.FirstName + " " + employee.LastName, _readOnly: true).ShowDialog(this);
					}
					else
					{
						new frmInventoryView(employee.FirstName + " " + employee.LastName, _readOnly: false).ShowDialog(this);
					}
				}
				else
				{
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag);
		}
		else
		{
			Employee employee2 = gclass6_0.Employees.Where((Employee a) => a.EmployeeID.ToString() == CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()).FirstOrDefault();
			if (employee2 != null)
			{
				if (!(employee2.Users.FirstOrDefault().Role.RoleName == Roles.admin) && !(employee2.Users.FirstOrDefault().Role.RoleName == Roles.manager) && !(employee2.Users.FirstOrDefault().Role.RoleName == Roles.supervisor))
				{
					new frmInventoryView(employee2.FirstName + " " + employee2.LastName, _readOnly: true).ShowDialog(this);
				}
				else
				{
					new frmInventoryView(employee2.FirstName + " " + employee2.LastName, _readOnly: false).ShowDialog(this);
				}
			}
		}
		GC.Collect();
	}

	public void btnPay_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.CurrentTerminalMode == "Kiosk")
		{
			new frmKioskOrderTypeSelection().ShowDialog();
		}
		else
		{
			gclass6_0 = new GClass6();
			if (!gclass6_0.CompanySetups.FirstOrDefault().isOpen)
			{
				new NotificationLabel(this, "Store is closed, please open the store.", NotificationTypes.Warning).Show();
				return;
			}
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("restaurant_mode");
			if (!string.IsNullOrEmpty(settingValueByKey))
			{
				if (!(settingValueByKey == "Dine In"))
				{
					if (settingValueByKey == "Quick Service" && AuthMethods.EmployeeLoginBeforeFormControl(this, "frmQuickService") != null)
					{
						ShowEmptyOrderEntrySecondScreen();
						if (SettingsHelper.GetSettingValueByKey("quickservice_screen") == "ON")
						{
							if (SettingsHelper.GetSettingValueByKey("quick_service_view") == "tile")
							{
								MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
								MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL");
								MemoryLoadedObjects.QuickService.Show();
							}
							else
							{
								MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickServiceListView();
								MemoryLoadedObjects.QuickServiceListView.LoadFormData();
								MemoryLoadedObjects.QuickServiceListView.Show();
							}
						}
						else
						{
							List<string> list = MemoryLoadedObjects.DefaultOrderTypes.Split(',').ToList();
							string systemOrderType = ((list.Count <= 1) ? list.FirstOrDefault() : ((!list.Contains(OrderTypes.ToGo)) ? list.FirstOrDefault() : OrderTypes.ToGo));
							MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
							if (MemoryLoadedObjects.OrderEntry.ReinitializeOrderEntryByOrderType(systemOrderType))
							{
								if (SettingsHelper.GetSettingValueByKey("quick_service_view") == "tile")
								{
									MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickService();
									MemoryLoadedObjects.QuickService.LoadFormData(string.Empty, "ALL", showOEOnClose: false);
									MemoryLoadedObjects.QuickService.Show();
								}
								else
								{
									MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.QuickServiceListView();
									MemoryLoadedObjects.QuickServiceListView.LoadFormData(showOEOnClose: false);
									MemoryLoadedObjects.QuickServiceListView.Show();
								}
							}
						}
					}
				}
				else
				{
					timer_1.Enabled = false;
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Layout();
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntry();
					if (!MemoryLoadedObjects.DefaultOrderTypes.Split(',').ToList().Contains(OrderTypes.DineIn))
					{
						if (MemoryLoadedObjects.OrderEntry.ReinitializeOrderEntryByOrderType(OrderTypes.ToGo))
						{
							MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.MultiBills();
							MemoryLoadedObjects.MultiBills.LoadFormData(MemoryLoadedObjects.Layout, OrderTypes.PickUp, OrderTypes.PickUp);
							MemoryLoadedObjects.MultiBills.ShowDialog();
						}
					}
					else if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmLayout") != null)
					{
						Employee userByID = UserMethods.GetUserByID(Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
						if (SettingsHelper.CurrentTerminalMode != "Patron" && userByID.Users.Where((User a) => a.Role.RoleName == "Patron").FirstOrDefault() != null)
						{
							new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog();
							AuthMethods.LogOutUser();
							return;
						}
						ShowEmptyOrderEntrySecondScreen();
						MemoryLoadedObjects.Layout.LoadFormData();
						MemoryLoadedObjects.Layout.LoadDefaultValues();
						MemoryLoadedObjects.Layout.Show(this);
					}
				}
			}
		}
		GC.Collect();
	}

	private void btnStation1_Click(object sender, EventArgs e)
	{
		terminal_0 = new GClass6().Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (SettingsHelper.GetSettingValueByKey("kitchen_station_view") == "list")
		{
			new frmStation(sender, (short)terminal_0.DefaultStation1).Show();
		}
		else
		{
			new frmStationTiles(sender, (short)terminal_0.DefaultStation1).Show();
		}
		GC.Collect();
	}

	private void btnStation2_Click(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("delivery_management") == "ON" && MemoryLoadedData.IsDeliveryManagement)
		{
			if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmDeliveryManagement") != null)
			{
				new frmDeliveryManagement().Show();
			}
		}
		else
		{
			terminal_0 = new GClass6().Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (SettingsHelper.GetSettingValueByKey("kitchen_station_view") == "list")
			{
				new frmStation(sender, (short)terminal_0.DefaultStation2).Show();
			}
			else
			{
				new frmStationTiles(sender, (short)terminal_0.DefaultStation2).Show();
			}
		}
		GC.Collect();
	}

	private void btnRefund_Click(object sender, EventArgs e)
	{
		if (!new GClass6().CompanySetups.FirstOrDefault().isOpen)
		{
			new NotificationLabel(this, "Store is closed, please open the store.", NotificationTypes.Warning).Show();
			return;
		}
		if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmRefund") != null)
		{
			new frmRefund().ShowDialog();
		}
		GC.Collect();
	}

	private bool method_6()
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
			lblSystemMessage.Text = Resources.Cloudsync_will_begin_at + settingValueByKey.Split('|')[1];
			return false;
		}
		return true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		try
		{
			method_3();
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	public bool CheckSync()
	{
		string_1 = SyncMethods.GetToken();
		if (string.IsNullOrEmpty(string_1))
		{
			lblSystemMessage.Text = Resources.CloudSync_not_enabled;
			return false;
		}
		if (!SyncMethods.CheckInternet())
		{
			method_9(bool_9: false);
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]))
			{
				lblNoInternet.Visible = true;
			}
			else
			{
				lblNoInternet.Visible = false;
			}
			return false;
		}
		method_9(bool_9: true);
		lblNoInternet.Visible = false;
		string_2 = SyncMethods.GetStation();
		if (string.IsNullOrEmpty(string_1) && (from x in SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true)
			where x.Provider != OnlineOrderProviders.Hippos
			select x).Count() == 0)
		{
			lblSystemMessage.Text = Resources.CloudSync_not_enabled;
			method_7();
			return false;
		}
		if (string.IsNullOrEmpty(string_2))
		{
			lblSystemMessage.Text = Resources.CloudSync_Failed_Sync_Station_;
			return false;
		}
		if (string_2 != Environment.MachineName)
		{
			lblSystemMessage.Text = Resources.CloudSync_not_enabled_for_this;
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
		return true;
	}

	private void method_7()
	{
		if (string_2 == Environment.MachineName && DateTime.Now.Hour > 10 && DateTime.Now.Hour < 23 && gclass6_0.Appointments.Where((Appointment a) => a.StartDateTime.Date == DateTime.Now.AddDays(1.0).Date && a.isCancelled == false && ((a.CustomerCell != string.Empty && a.SMSSent == false) || (a.CustomerEmail != string.Empty && a.EmailSent == false))).Count() > 0)
		{
			smtpsettings_0 = NotificationMethods.GetSMTPSettings();
			timer_1.Enabled = true;
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (!(SettingsHelper.GetSettingValueByKey("sms") == "Disabled") && !(string_2 != Environment.MachineName))
		{
			if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
			{
				return;
			}
			if (smtpsettings_0 != null)
			{
				method_7();
			}
			lblSystemMessage.Text = Resources.System_Message_Sending_reserva;
			string text = string.Empty;
			try
			{
				GClass6 gClass = new GClass6();
				CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
				string text2 = Resources.Reminder + companySetup.Name + Resources._reservation_tomorrow_at_APPOI + companySetup.Phone + Resources._if_you_need_to_change_or_canc;
				List<Appointment> source = gClass.Appointments.Where((Appointment a) => a.StartDateTime.Date == DateTime.Now.AddDays(1.0).Date && a.isCancelled == false && ((a.CustomerCell != string.Empty && a.SMSSent == false) || (a.CustomerEmail != string.Empty && a.EmailSent == false))).ToList();
				int num = source.Count();
				if (num > 20)
				{
					timer_1.Interval = 30000;
				}
				else if (num == 0)
				{
					timer_1.Enabled = false;
					lblSystemMessage.Text = Resources.System_Message_All_reservation;
				}
				else
				{
					timer_1.Interval = 300000;
				}
				foreach (Appointment item in source.Take(5))
				{
					if (!string.IsNullOrEmpty(string_1) && SettingsHelper.GetSettingValueByKey("sms") == "Enabled" && !string.IsNullOrEmpty(item.CustomerCell) && !item.SMSSent)
					{
						if (NotificationMethods.SendSMS(string_1, item.CustomerCell, text2.Replace("{APPOINTMENT_DATE}", item.StartDateTime.ToShortDateString()).Replace("{APPOINTMENT_TIME}", item.StartDateTime.ToShortTimeString())))
						{
							item.SMSSent = true;
							if (string_0.Contains(item.CustomerCell + "\r\n"))
							{
								string_0 = string_0.Replace(item.CustomerCell + "\r\n", string.Empty);
							}
						}
						else if (!string_0.Contains(item.CustomerCell))
						{
							text = text + item.CustomerCell + "\r\n";
							string_0 = string_0 + item.CustomerCell + "\r\n";
						}
						Thread.Sleep(500);
					}
					if (string.IsNullOrEmpty(item.CustomerEmail) || item.EmailSent)
					{
						continue;
					}
					if (smtpsettings_0 == null)
					{
						lblSystemMessage.Text = Resources.System_Message_E_mail_notifica;
					}
					else
					{
						if (string.IsNullOrEmpty(smtpsettings_0.password) || smtpsettings_0.port <= 0 || string.IsNullOrEmpty(smtpsettings_0.server) || string.IsNullOrEmpty(smtpsettings_0.username))
						{
							continue;
						}
						string subject = Resources.Reservation_Reminder_for + companySetup.Name;
						text2 = Resources.This_is_a_friendly_reminder_fr + companySetup.Name + Resources._that_you_have_a_reservation_t + item.StartDateTime.ToShortTimeString() + Resources._br_br_Please_call + companySetup.Phone + Resources._if_you_need_to_cancel_or_chan + companySetup.Name;
						string text3 = NotificationMethods.sendEmail(smtpsettings_0, item.CustomerEmail, subject, text2.Replace("{APPOINTMENT_DATE}", item.StartDateTime.ToShortDateString()));
						if (!string.IsNullOrEmpty(text3) && !(text3 == "Mail Sent."))
						{
							if (!string_0.Contains(item.CustomerCell))
							{
								text = text + item.CustomerEmail + "\r\n";
								string_0 = string_0 + item.CustomerCell + "\r\n";
							}
							if (text3.Contains("timed out"))
							{
								smtpsettings_0 = null;
							}
						}
						else
						{
							item.EmailSent = true;
							if (string_0.Contains(item.CustomerEmail + "\r\n"))
							{
								string_0 = string_0.Replace(item.CustomerEmail + "\r\n", string.Empty);
							}
						}
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
				if (text != string.Empty)
				{
					text = Resources.The_following_phone_or_e_mails + text;
					MessageBox.Show(text, Resources.Failed_Notifications);
				}
				else if (string_0 != string.Empty)
				{
					lblSystemMessage.Text = Resources.System_Message_Error_sending_r;
				}
				return;
			}
			catch (Exception)
			{
				MessageBox.Show(text, Resources.Failed_Notifications);
				lblSystemMessage.Text = Resources.System_Message_Error_sending_r;
				return;
			}
		}
		timer_1.Enabled = false;
	}

	private void btnViewOrders_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmAdminViewOrders") != null)
		{
			new frmAdminViewOrders().Show();
		}
	}

	private void btnHelp_Click(object sender, EventArgs e)
	{
		string text = ((SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In") ? "full_service" : "quick_service");
		string text2 = AppDomain.CurrentDomain.BaseDirectory + Thread.CurrentThread.CurrentCulture.Name + "\\hippos_" + text + "_guide.pdf";
		if (File.Exists(text2))
		{
			string text3 = smethod_0();
			if (text3 == string.Empty)
			{
				text3 = "iexplore";
			}
			Process process = new Process();
			try
			{
				process.StartInfo = new ProcessStartInfo(text3);
				process.StartInfo.Arguments = "\"" + text2 + "\"";
				process.Start();
				return;
			}
			catch
			{
				try
				{
					text3 = "chrome";
					process.StartInfo = new ProcessStartInfo(text3);
					process.StartInfo.Arguments = "\"" + text2 + "\"";
					process.Start();
					return;
				}
				catch
				{
					new NotificationLabel(this, "Please install an internet browser.", NotificationTypes.Warning).Show();
					return;
				}
			}
		}
		new frmMessageBox(Resources.Help_documentation_is_missing_, Resources.File_Missing_or_Corrupted).ShowDialog(this);
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		frmLoader frmLoader2 = Application.OpenForms.OfType<frmLoader>().FirstOrDefault();
		if (frmLoader2 != null)
		{
			try
			{
				frmLoader2?.checkForUpdates();
			}
			catch
			{
			}
		}
		GC.Collect();
	}

	private static string smethod_0()
	{
		string empty = string.Empty;
		RegistryKey registryKey = null;
		try
		{
			registryKey = Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", writable: false);
			if (registryKey == null)
			{
				registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\Shell\\Associations\\UrlAssociations\\http", writable: false);
			}
			if (registryKey != null)
			{
				empty = registryKey.GetValue(null).ToString().ToLower()
					.Replace("\"", "");
				if (!empty.EndsWith("exe"))
				{
					empty = empty.Substring(0, empty.LastIndexOf(".exe") + 4);
				}
				registryKey.Close();
				return empty;
			}
			return empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private void btnReports_Click(object sender, EventArgs e)
	{
		if (AuthMethods.EmployeeLoginBeforeFormControl(this, "frmAdminReports") != null)
		{
			new frmAdminReports().ShowDialog(this);
		}
		GC.Collect();
	}

	private void lblEULA_Click(object sender, EventArgs e)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "\\HipPOS-EULA.txt";
		if (File.Exists(text))
		{
			Process.Start(text);
		}
		else
		{
			new frmMessageBox(Resources.HipPOS_EULA_is_missing_or_corr, Resources.File_Missing_or_Corrupted).ShowDialog(this);
		}
	}

	private void btnMembers_Click(object sender, EventArgs e)
	{
		new frmCustomers(this).Show();
		GC.Collect();
	}

	private StatusCodeResponseLocation method_8()
	{
		StatusCodeResponseLocation locationData = ETimeCardMethods.GetLocationData(new LocationPostModel
		{
			token = SyncMethods.GetToken()
		});
		if (locationData.code == 200)
		{
			return locationData;
		}
		return null;
	}

	public string GetMACAddress()
	{
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		string text = string.Empty;
		NetworkInterface[] array = allNetworkInterfaces;
		foreach (NetworkInterface networkInterface in array)
		{
			if (text == string.Empty)
			{
				networkInterface.GetIPProperties();
				text = networkInterface.GetPhysicalAddress().ToString();
			}
		}
		return text;
	}

	private void btnTimeAttendance_Click(object sender, EventArgs e)
	{
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (settingValueByKey == "Disabled")
			{
				new frmMessageBox(Resources.This_add_on_has_not_been_enabl, Resources.Add_On_Not_Enabled).ShowDialog();
				return;
			}
			bool flag = false;
			do
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN_To_Clock_In_Out, 0);
				if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
				{
					flag = true;
					continue;
				}
				Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
				if (employee != null)
				{
					new frmEmployeePunchInOut(employee).ShowDialog(this);
					flag = true;
				}
				else
				{
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(this);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag);
			GC.Collect();
		}
		else
		{
			GClass6 gClass = new GClass6();
			Setting entity = new Setting
			{
				Key = "hippos_time",
				Value = "Disabled",
				ShowInSettings = false,
				ToolTip = string.Empty
			};
			gClass.Settings.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
			new frmMessageBox(Resources.This_add_on_has_not_been_enabl0, Resources.Add_On_Not_Enabled).ShowDialog();
		}
	}

	private void btnLanguageChange_Click(object sender, EventArgs e)
	{
		CultureInfo cultureInfo = new CultureInfo(btnLanguageChange.Tag.ToString());
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		Close();
		new frmSplash().Show();
		Dispose();
		MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
	}

	private void method_9(bool bool_9)
	{
		lblUsefulTips.Text = string.Empty;
		timer_2.Enabled = bool_9;
		if (SettingsHelper.GetSettingValueByKey("sms") == "Enabled")
		{
			timer_1.Enabled = bool_9;
		}
		timer_9.Enabled = bool_9 && SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).Count > 0;
	}

	private void timer_3_Tick(object sender, EventArgs e)
	{
		try
		{
			int count = new Random().Next(0, gclass6_0.UsefulTips.Count() - 1);
			UsefulTip usefulTip = gclass6_0.UsefulTips.Skip(count).Take(1).FirstOrDefault();
			if (usefulTip != null)
			{
				MemoryLoadedObjects.CurrentUsefulTip = "Useful Tips: " + usefulTip.Description;
				lblUsefulTips.Text = MemoryLoadedObjects.CurrentUsefulTip;
			}
			else
			{
				lblUsefulTips.Text = string.Empty;
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void timer_4_Tick(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("second_screen") == "ON" && MemoryLoadedObjects.OrderEntrySecondScreen == null && AppSettings.ScreenCount >= 2)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.OrderEntrySecondScreen();
			Rectangle bounds = AppSettings.SecondaryScreen.Bounds;
			MemoryLoadedObjects.OrderEntrySecondScreen.WindowState = FormWindowState.Normal;
			MemoryLoadedObjects.OrderEntrySecondScreen.TopMost = true;
			MemoryLoadedObjects.OrderEntrySecondScreen.Size = new Size(bounds.Width, bounds.Height);
			MemoryLoadedObjects.OrderEntrySecondScreen.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			MemoryLoadedObjects.OrderEntrySecondScreen.StartPosition = FormStartPosition.Manual;
			MemoryLoadedObjects.OrderEntrySecondScreen.Show();
		}
	}

	private void timer_5_Tick(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new OrderHelper().PrintAllHoldItemsPastTimeIndex();
			if (list != null && list.Count > 0)
			{
				((frmOrderEntry)Application.OpenForms["frmOrderEntry"])?.ReloadOrder(list);
			}
			if (!MemoryLoadedObjects.isHipposOnlineOrder || !bool_4)
			{
				return;
			}
			if (new GClass6().Orders.Where((Order a) => a.LastSynced >= DateTime.Now.AddMinutes(-30.0) && a.FlagID == 1 && a.Void == false && a.DateCleared.HasValue == false && (a.OrderType == OrderTypes.DeliveryOnline || a.OrderType == OrderTypes.PickUpOnline || a.OrderType == OrderTypes.PickUpCurbsideOnline || a.OrderType == OrderTypes.DineInOnline)).FirstOrDefault() != null)
			{
				frmLayout frmLayout2 = Application.OpenForms.OfType<frmLayout>().FirstOrDefault();
				frmQuickService frmQuickService2 = Application.OpenForms.OfType<frmQuickService>().FirstOrDefault();
				frmMultiBills frmMultiBills2 = Application.OpenForms.OfType<frmMultiBills>().FirstOrDefault();
				string message = "There were online orders received within the last 30 minutes.";
				if (frmLayout2 != null)
				{
					new NotificationLabel(frmLayout2, message, NotificationTypes.Success).Show();
					frmLayout2.ShowOnlineOrderNotification(show: true);
				}
				else if (frmQuickService2 != null)
				{
					new NotificationLabel(frmQuickService2, message, NotificationTypes.Success).Show();
				}
				else
				{
					new NotificationLabel(this, message, NotificationTypes.Success).Show();
				}
				if (frmMultiBills2 != null)
				{
					new NotificationLabel(frmMultiBills2, message, NotificationTypes.Success).Show();
				}
				if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.OrderEntry != null)
				{
					MemoryLoadedObjects.OrderEntry.ShowOnlineOrderNotification(show: true);
				}
			}
			else if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.OrderEntry != null)
			{
				MemoryLoadedObjects.OrderEntry.ShowOnlineOrderNotification(show: false);
			}
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void timer_6_Tick(object sender, EventArgs e)
	{
		if (bool_6)
		{
			return;
		}
		try
		{
			bool_6 = true;
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
			if (terminal != null && terminal.ItemsInGroupsRefreshRequired)
			{
				RefreshItemsMemory();
				MemoryLoadedObjects.RefreshItemOptions = true;
				terminal.ItemsInGroupsRefreshRequired = false;
				Helper.SubmitChangesWithCatch(gClass);
				((frmOrderEntry)Application.OpenForms["frmOrderEntry"])?.RefreshGroupsAndItems();
			}
			bool_6 = false;
		}
		catch
		{
			bool_6 = false;
		}
	}

	public void RefreshItemsMemory()
	{
		MemoryLoadedData.ListOfItemsInGroupMemory = new GClass6().ItemsInGroups.Where((ItemsInGroup a) => a.Item.isDeleted == false && a.Item.Active == true).ToList();
		MemoryLoadedObjects.FirstGetGroupIteration = true;
		MemoryLoadedObjects.RefreshGeneralOEData();
	}

	public void SetBtnLogOutText(string text)
	{
		btnLogOut.Text = text;
	}

	private void btnLogOut_Click(object sender, EventArgs e)
	{
		if (MemoryLoadedObjects.isUserRemember || CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0")
		{
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
			MemoryLoadedObjects.isUserRemember = false;
			btnLogOut.Text = "";
			new NotificationLabel(this, "User Logged out", NotificationTypes.Success).Show();
		}
	}

	private void method_10(GClass6 gclass6_1)
	{
		try
		{
			gclass6_1.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException)
		{
			foreach (ObjectChangeConflict changeConflict in gclass6_1.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	private void timer_7_Tick(object sender, EventArgs e)
	{
		PrintHelper.PrintReceiptCheck();
	}

	private void timer_8_Tick(object sender, EventArgs e)
	{
		if (!(SettingsHelper.GetSettingValueByKey("auto_settlement") == "ON"))
		{
			return;
		}
		if (!GdfFoxLrArD)
		{
			GdfFoxLrArD = true;
			if ((dateTime_0.Hour != DateTime.Now.Hour || dateTime_0.Minute != DateTime.Now.Minute) && (!terminal_0.LastDateSettlement.HasValue || !(terminal_0.LastDateSettlement.Value.AddDays(1.0) < DateTime.Now)))
			{
				return;
			}
			int num = 1;
			if (terminal_0.LastDateSettlement.HasValue && terminal_0.LastDateSettlement.Value.AddDays(2.0) <= DateTime.Now)
			{
				int num2 = (int)(DateTime.Now - terminal_0.LastDateSettlement.Value).TotalDays;
				num = ((num2 <= 1) ? 1 : num2);
			}
			for (int i = 1; i <= num; i++)
			{
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				if (!terminal_0.LastDateSettlement.HasValue)
				{
					frmSelectDateAndTime frmSelectDateAndTime2 = new frmSelectDateAndTime("Set Last Date Settlement");
					if (frmSelectDateAndTime2.ShowDialog(this) == DialogResult.Cancel)
					{
						break;
					}
					now = new DateTime(frmSelectDateAndTime2.returnDate.Year, frmSelectDateAndTime2.returnDate.Month, frmSelectDateAndTime2.returnDate.Day, frmSelectDateAndTime2.returnTime.Hour, frmSelectDateAndTime2.returnTime.Minute, frmSelectDateAndTime2.returnTime.Second);
				}
				else
				{
					now = terminal_0.LastDateSettlement.Value;
				}
				if (num == 1)
				{
					terminal_0.LastDateSettlement = (now2 = DateTime.Now);
				}
				else
				{
					terminal_0.LastDateSettlement = (now2 = DateTime.Now.AddDays(i - num));
				}
				Helper.SubmitChangesWithCatch(gclass6_0);
				ReceiptMethods.ParseDayEndTotals(now, now2, 0, terminal_0.TerminalID);
				new PrintHelper().GenerateDayEndTotals(now, now2, 0, terminal_0.TerminalID);
			}
		}
		else if (dateTime_0.Minute < DateTime.Now.Minute)
		{
			GdfFoxLrArD = false;
		}
	}

	private void method_11()
	{
		_003C_003Ec__DisplayClass68_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass68_0();
		SyncMethods.WriteToSyncLog("Hippos: Processing online orders started.", "OnlineOrderSync_");
		gclass6_0 = new GClass6();
		List<OnlineOrderSyncQueue> list = (from x in gclass6_0.OnlineOrderSyncQueues
			where x.Provider == OnlineOrderProviders.Hippos && !x.DateProcessed.HasValue
			select x into a
			orderby a.DateCreated
			select a).Take(5).ToList();
		List<OrderPostDataModel> ordersFromRawData = HipposOnlineOrderingMethods.GetOrdersFromRawData(list);
		CS_0024_003C_003E8__locals0.orderIDs = ordersFromRawData.Select((OrderPostDataModel x) => new Guid(x.customer_order_id)).ToList();
		List<Order> source = gclass6_0.Orders.Where((Order x) => CS_0024_003C_003E8__locals0.orderIDs.Contains(x.OrderId)).ToList();
		if (ordersFromRawData != null && ordersFromRawData.Count > 0)
		{
			_003C_003Ec__DisplayClass68_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass68_1();
			CS_0024_003C_003E8__locals4.onlineOrderCustomerPhoneNumbers = ordersFromRawData.Select((OrderPostDataModel x) => x.customer_phone).ToList();
			GClass6 gClass = new GClass6();
			List<Customer> source2 = gClass.Customers.Where((Customer x) => CS_0024_003C_003E8__locals4.onlineOrderCustomerPhoneNumbers.Contains(x.CustomerHome) || CS_0024_003C_003E8__locals4.onlineOrderCustomerPhoneNumbers.Contains(x.CustomerCell)).ToList();
			List<Guid> list2 = new List<Guid>();
			Customer customer = null;
			string text = string.Empty;
			int currentTerminalID = HelperMethods.GetCurrentTerminalID();
			List<OnlineOrderSourceObject> list3 = new List<OnlineOrderSourceObject>();
			using (List<OrderPostDataModel>.Enumerator enumerator = ordersFromRawData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass68_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass68_2();
					CS_0024_003C_003E8__locals1.orderRes = enumerator.Current;
					Order order = source.Where((Order a) => a.OrderId.ToString() == CS_0024_003C_003E8__locals1.orderRes.customer_order_id).FirstOrDefault();
					Item item = MemoryLoadedData.all_active_items.Where((Item a) => a.ItemID == CS_0024_003C_003E8__locals1.orderRes.item_id).FirstOrDefault();
					if (order != null)
					{
						SyncMethods.WriteToSyncLog("Hippos: Processing existing online order, order=" + order.OrderNumber, "OnlineOrderSync_");
						if (CS_0024_003C_003E8__locals1.orderRes.paid || CS_0024_003C_003E8__locals1.orderRes.date_refunded.HasValue)
						{
							order.OrderType = ((CS_0024_003C_003E8__locals1.orderRes.order_type == OrderTypes.TakeOutOnline) ? OrderTypes.PickUpOnline : CS_0024_003C_003E8__locals1.orderRes.order_type);
							order.OrderNumber = CS_0024_003C_003E8__locals1.orderRes.order_number;
							string text2 = "";
							text2 = CS_0024_003C_003E8__locals1.orderRes.source;
							if (string.IsNullOrEmpty(text2))
							{
								text2 = (CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("SKIP") ? OnlineOrderSource.Skip : (CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("UBER") ? OnlineOrderSource.UBER : ((!CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("WEB")) ? OnlineOrderSource.Unknown : OnlineOrderSource.Hippos)));
							}
							order.Source = text2;
							order.SubSource = CS_0024_003C_003E8__locals1.orderRes.sub_source;
							order.Customer = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.sub_source)) ? (CS_0024_003C_003E8__locals1.orderRes.sub_source.ToUpper() + "-" + CS_0024_003C_003E8__locals1.orderRes.order_number.Substring(CS_0024_003C_003E8__locals1.orderRes.order_number.Length - 4).ToUpper()) : (text2.ToUpper() + "-" + CS_0024_003C_003E8__locals1.orderRes.order_number.Substring(CS_0024_003C_003E8__locals1.orderRes.order_number.Length - 4).ToUpper()));
							order.CustomerInfoName = CS_0024_003C_003E8__locals1.orderRes.customer_name;
							order.CustomerInfo = CS_0024_003C_003E8__locals1.orderRes.customer_address;
							order.DateCreated = CS_0024_003C_003E8__locals1.orderRes.date_created;
							order.DatePaid = CS_0024_003C_003E8__locals1.orderRes.date_paid;
							order.GroupName = CS_0024_003C_003E8__locals1.orderRes.group_name;
							order.ItemID = CS_0024_003C_003E8__locals1.orderRes.item_id;
							order.ItemName = CS_0024_003C_003E8__locals1.orderRes.item_name;
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.item_instruction))
							{
								order.Instructions = CS_0024_003C_003E8__locals1.orderRes.item_instruction;
							}
							else
							{
								order.Instructions = string.Empty;
							}
							order.ItemPrice = CS_0024_003C_003E8__locals1.orderRes.item_price;
							order.ItemSellPrice = CS_0024_003C_003E8__locals1.orderRes.item_sell_price;
							order.ItemCost = CS_0024_003C_003E8__locals1.orderRes.item_cost;
							order.Qty = CS_0024_003C_003E8__locals1.orderRes.qty;
							if (!order.DateFilled.HasValue)
							{
								order.DateFilled = (CS_0024_003C_003E8__locals1.orderRes.date_refunded.HasValue ? new DateTime?(DateTime.Now) : CS_0024_003C_003E8__locals1.orderRes.date_filled);
							}
							order.DateRefunded = CS_0024_003C_003E8__locals1.orderRes.date_refunded;
							order.SortOrder = 0;
							order.StationID = ((item != null) ? item.StationID : CS_0024_003C_003E8__locals1.orderRes.station_id);
							order.Void = CS_0024_003C_003E8__locals1.orderRes.is_void;
							order.Paid = CS_0024_003C_003E8__locals1.orderRes.paid;
							order.Notified = false;
							order.PaymentMethods = CS_0024_003C_003E8__locals1.orderRes.payment_methods;
							order.TaxDesc = CS_0024_003C_003E8__locals1.orderRes.tax_desc;
							order.Discount = CS_0024_003C_003E8__locals1.orderRes.discount;
							order.DiscountReason = CS_0024_003C_003E8__locals1.orderRes.discount_reason;
							order.DiscountDesc = CS_0024_003C_003E8__locals1.orderRes.discount_desc;
							order.SubTotal = CS_0024_003C_003E8__locals1.orderRes.subtotal;
							order.TaxTotal = CS_0024_003C_003E8__locals1.orderRes.tax_total;
							order.Total = CS_0024_003C_003E8__locals1.orderRes.total;
							order.ComboID = CS_0024_003C_003E8__locals1.orderRes.combo_id;
							order.TipAmount = CS_0024_003C_003E8__locals1.orderRes.tip_amount;
							order.TipDesc = CS_0024_003C_003E8__locals1.orderRes.tip_desc;
							order.TipRecorded = ((CS_0024_003C_003E8__locals1.orderRes.tip_amount > 0m) ? true : false);
							order.OrderTicketNumber = CS_0024_003C_003E8__locals1.orderRes.order_ticket_number;
							order.OrderOnHoldTime = CS_0024_003C_003E8__locals1.orderRes.order_on_hold_time;
							order.FulfillmentAt = CS_0024_003C_003E8__locals1.orderRes.time_opt;
							order.GuestCount = CS_0024_003C_003E8__locals1.orderRes.guest_count;
							order.TipShareDesc = CS_0024_003C_003E8__locals1.orderRes.tip_share_desc;
							order.OrderNotes = CS_0024_003C_003E8__locals1.orderRes.order_instruction;
							order.Synced = true;
							order.LastSynced = DateTime.Now;
							CS_0024_003C_003E8__locals1.orderRes.is_new_online = false;
							if (order.DateCreated.Value < DateTime.Now.AddHours(-3.0) && CS_0024_003C_003E8__locals1.orderRes.order_type.Contains("Online"))
							{
								order.PrintedInKitchen = true;
								order.Notified = true;
							}
						}
						SyncMethods.WriteToSyncLog("Hippos: Processing existing online order, order=" + CS_0024_003C_003E8__locals1.orderRes.order_number + ", completed.", "OnlineOrderSync_");
					}
					else
					{
						_003C_003Ec__DisplayClass68_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass68_3();
						if (CS_0024_003C_003E8__locals1.orderRes.order_number != text)
						{
							text = CS_0024_003C_003E8__locals1.orderRes.order_number;
							if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.customer_phone))
							{
								customer = source2.Where((Customer x) => x.CustomerCell == CS_0024_003C_003E8__locals1.orderRes.customer_phone || x.CustomerHome == CS_0024_003C_003E8__locals1.orderRes.customer_phone).FirstOrDefault();
								if (customer == null)
								{
									customer = new Customer();
									customer.MemberNumber = string.Empty;
									customer.Active = true;
									customer.Address = CS_0024_003C_003E8__locals1.orderRes.customer_address;
									customer.CustomerCell = CS_0024_003C_003E8__locals1.orderRes.customer_phone;
									customer.CustomerEmail = CS_0024_003C_003E8__locals1.orderRes.customer_email;
									customer.CustomerName = CS_0024_003C_003E8__locals1.orderRes.customer_name;
									customer.DateCreated = DateTime.Now;
									customer.EmployeeID = MemoryLoadedObjects.all_employees.FirstOrDefault().EmployeeID;
									customer.Synced = false;
									customer.LoyaltyCardNo = string.Empty;
									customer.LastModified = DateTime.Now;
									if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.customer_address.Trim()))
									{
										TravelInfo totalDistanceFromDeliveryAddress = GoogleMethods.GetTotalDistanceFromDeliveryAddress(CS_0024_003C_003E8__locals1.orderRes.customer_address.Trim());
										if (totalDistanceFromDeliveryAddress.Distance > 0m && totalDistanceFromDeliveryAddress.TravelTime > 0)
										{
											customer.DeliveryTravelDistanceKM = totalDistanceFromDeliveryAddress.Distance;
											customer.DeliveryTravelTimeMinutes = totalDistanceFromDeliveryAddress.TravelTime;
										}
									}
									gClass.Customers.InsertOnSubmit(customer);
								}
								else if (customer.Address != CS_0024_003C_003E8__locals1.orderRes.customer_address)
								{
									customer.Address = CS_0024_003C_003E8__locals1.orderRes.customer_address;
									customer.LastModified = DateTime.Now;
									customer.Synced = false;
								}
								gClass.SubmitChanges();
							}
						}
						CS_0024_003C_003E8__locals2.newOrder = new Order();
						CS_0024_003C_003E8__locals2.newOrder.OrderId = new Guid(CS_0024_003C_003E8__locals1.orderRes.customer_order_id);
						CS_0024_003C_003E8__locals2.newOrder.OrderNumber = CS_0024_003C_003E8__locals1.orderRes.order_number;
						CS_0024_003C_003E8__locals2.newOrder.OrderTicketNumber = CS_0024_003C_003E8__locals1.orderRes.order_ticket_number;
						SyncMethods.WriteToSyncLog("Hippos: Processing new online order, order=" + CS_0024_003C_003E8__locals1.orderRes.order_number, "OnlineOrderSync_");
						CS_0024_003C_003E8__locals2.newOrder.OrderType = ((CS_0024_003C_003E8__locals1.orderRes.order_type == OrderTypes.TakeOutOnline) ? OrderTypes.PickUpOnline : CS_0024_003C_003E8__locals1.orderRes.order_type);
						if (customer != null)
						{
							CS_0024_003C_003E8__locals2.newOrder.CustomerID = customer.CustomerID;
						}
						string text3 = "";
						text3 = CS_0024_003C_003E8__locals1.orderRes.source;
						if (string.IsNullOrEmpty(text3))
						{
							text3 = (CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("SKIP") ? OnlineOrderSource.Skip : (CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("UBER") ? OnlineOrderSource.UBER : ((!CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("WEB")) ? OnlineOrderSource.Unknown : OnlineOrderSource.Hippos)));
						}
						CS_0024_003C_003E8__locals2.newOrder.Source = text3;
						CS_0024_003C_003E8__locals2.newOrder.SubSource = CS_0024_003C_003E8__locals1.orderRes.sub_source;
						string text4 = ((!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.sub_source)) ? CS_0024_003C_003E8__locals1.orderRes.sub_source : CS_0024_003C_003E8__locals1.orderRes.source).ToUpper();
						short num = 4;
						if (text4.Contains("UBER"))
						{
							num = 5;
						}
						if (CS_0024_003C_003E8__locals1.orderRes.order_number.Contains("WEB"))
						{
							CS_0024_003C_003E8__locals2.newOrder.Customer = text4 + ": " + CS_0024_003C_003E8__locals1.orderRes.customer_phone;
						}
						else
						{
							CS_0024_003C_003E8__locals2.newOrder.Customer = text4 + "#:" + CS_0024_003C_003E8__locals1.orderRes.order_number.Substring(CS_0024_003C_003E8__locals1.orderRes.order_number.Length - num);
						}
						CS_0024_003C_003E8__locals2.newOrder.CustomerInfoName = CS_0024_003C_003E8__locals1.orderRes.customer_name;
						CS_0024_003C_003E8__locals2.newOrder.CustomerInfoPhone = CS_0024_003C_003E8__locals1.orderRes.customer_phone;
						CS_0024_003C_003E8__locals2.newOrder.CustomerInfoEmail = CS_0024_003C_003E8__locals1.orderRes.customer_email;
						CS_0024_003C_003E8__locals2.newOrder.CustomerInfo = CS_0024_003C_003E8__locals1.orderRes.customer_address;
						CS_0024_003C_003E8__locals2.newOrder.CustomerID = 0;
						CS_0024_003C_003E8__locals2.newOrder.DateCreated = CS_0024_003C_003E8__locals1.orderRes.date_created;
						CS_0024_003C_003E8__locals2.newOrder.DatePaid = CS_0024_003C_003E8__locals1.orderRes.date_paid;
						CS_0024_003C_003E8__locals2.newOrder.CreatedByTerminalID = currentTerminalID;
						CS_0024_003C_003E8__locals2.newOrder.GroupName = CS_0024_003C_003E8__locals1.orderRes.group_name;
						CS_0024_003C_003E8__locals2.newOrder.ItemID = CS_0024_003C_003E8__locals1.orderRes.item_id;
						CS_0024_003C_003E8__locals2.newOrder.ItemName = CS_0024_003C_003E8__locals1.orderRes.item_name;
						CS_0024_003C_003E8__locals2.newOrder.ItemBarcode = ((item != null) ? item.Barcode : CS_0024_003C_003E8__locals1.orderRes.item_barcode);
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.orderRes.item_instruction))
						{
							CS_0024_003C_003E8__locals2.newOrder.Instructions = CS_0024_003C_003E8__locals1.orderRes.item_instruction;
						}
						else
						{
							CS_0024_003C_003E8__locals2.newOrder.Instructions = string.Empty;
						}
						CS_0024_003C_003E8__locals2.newOrder.ItemPrice = CS_0024_003C_003E8__locals1.orderRes.item_price;
						CS_0024_003C_003E8__locals2.newOrder.ItemSellPrice = CS_0024_003C_003E8__locals1.orderRes.item_sell_price;
						CS_0024_003C_003E8__locals2.newOrder.ItemCost = CS_0024_003C_003E8__locals1.orderRes.item_cost;
						CS_0024_003C_003E8__locals2.newOrder.Qty = CS_0024_003C_003E8__locals1.orderRes.qty;
						CS_0024_003C_003E8__locals2.newOrder.DateFilled = (CS_0024_003C_003E8__locals1.orderRes.date_refunded.HasValue ? new DateTime?(DateTime.Now) : CS_0024_003C_003E8__locals1.orderRes.date_filled);
						CS_0024_003C_003E8__locals2.newOrder.DateRefunded = CS_0024_003C_003E8__locals1.orderRes.date_refunded;
						CS_0024_003C_003E8__locals2.newOrder.SortOrder = 0;
						CS_0024_003C_003E8__locals2.newOrder.StationID = ((item != null) ? item.StationID : CS_0024_003C_003E8__locals1.orderRes.station_id);
						CS_0024_003C_003E8__locals2.newOrder.Void = CS_0024_003C_003E8__locals1.orderRes.is_void;
						CS_0024_003C_003E8__locals2.newOrder.Paid = CS_0024_003C_003E8__locals1.orderRes.paid;
						CS_0024_003C_003E8__locals2.newOrder.Notified = ((!CS_0024_003C_003E8__locals1.orderRes.order_type.Contains("Online")) ? true : false);
						CS_0024_003C_003E8__locals2.newOrder.PaymentMethods = CS_0024_003C_003E8__locals1.orderRes.payment_methods;
						CS_0024_003C_003E8__locals2.newOrder.TaxDesc = CS_0024_003C_003E8__locals1.orderRes.tax_desc;
						CS_0024_003C_003E8__locals2.newOrder.Discount = CS_0024_003C_003E8__locals1.orderRes.discount;
						CS_0024_003C_003E8__locals2.newOrder.DiscountReason = CS_0024_003C_003E8__locals1.orderRes.discount_reason;
						CS_0024_003C_003E8__locals2.newOrder.DiscountDesc = CS_0024_003C_003E8__locals1.orderRes.discount_desc;
						CS_0024_003C_003E8__locals2.newOrder.OrderNotes = CS_0024_003C_003E8__locals1.orderRes.order_instruction;
						if (CS_0024_003C_003E8__locals1.orderRes.discount_desc.Contains("order"))
						{
							CS_0024_003C_003E8__locals2.newOrder.IsDiscount = true;
						}
						CS_0024_003C_003E8__locals2.newOrder.SubTotal = CS_0024_003C_003E8__locals1.orderRes.subtotal;
						CS_0024_003C_003E8__locals2.newOrder.TaxTotal = CS_0024_003C_003E8__locals1.orderRes.tax_total;
						CS_0024_003C_003E8__locals2.newOrder.Total = CS_0024_003C_003E8__locals1.orderRes.total;
						CS_0024_003C_003E8__locals2.newOrder.TipAmount = CS_0024_003C_003E8__locals1.orderRes.tip_amount;
						CS_0024_003C_003E8__locals2.newOrder.TipDesc = CS_0024_003C_003E8__locals1.orderRes.tip_desc;
						CS_0024_003C_003E8__locals2.newOrder.ComboID = CS_0024_003C_003E8__locals1.orderRes.combo_id;
						CS_0024_003C_003E8__locals2.newOrder.OrderOnHoldTime = CS_0024_003C_003E8__locals1.orderRes.order_on_hold_time;
						CS_0024_003C_003E8__locals2.newOrder.FulfillmentAt = CS_0024_003C_003E8__locals1.orderRes.time_opt;
						CS_0024_003C_003E8__locals2.newOrder.TipShareDesc = CS_0024_003C_003E8__locals1.orderRes.tip_share_desc;
						CS_0024_003C_003E8__locals2.newOrder.VoidReason = CS_0024_003C_003E8__locals1.orderRes.void_reason;
						CS_0024_003C_003E8__locals2.newOrder.GuestCount = CS_0024_003C_003E8__locals1.orderRes.guest_count;
						CS_0024_003C_003E8__locals2.newOrder.PrintedInKitchen = false;
						if (CS_0024_003C_003E8__locals1.orderRes.item_name.Contains("OPT:") && CS_0024_003C_003E8__locals1.orderRes.combo_id > 0)
						{
							CS_0024_003C_003E8__locals2.newOrder.ItemIdentifier = "OptionItem";
						}
						else if ((CS_0024_003C_003E8__locals1.orderRes.item_name.Contains("   ") || CS_0024_003C_003E8__locals1.orderRes.item_name.Contains("---")) && !CS_0024_003C_003E8__locals1.orderRes.item_name.Contains("OPT:") && CS_0024_003C_003E8__locals1.orderRes.combo_id > 0 && CS_0024_003C_003E8__locals1.orderRes.item_sell_price == 0m)
						{
							CS_0024_003C_003E8__locals2.newOrder.ItemIdentifier = "ChildItem";
						}
						else
						{
							CS_0024_003C_003E8__locals2.newOrder.ItemIdentifier = "MainItem";
						}
						CS_0024_003C_003E8__locals2.newOrder.SeatNum = "0";
						CS_0024_003C_003E8__locals2.newOrder.Synced = true;
						CS_0024_003C_003E8__locals1.orderRes.is_new_online = true;
						CS_0024_003C_003E8__locals2.newOrder.LastSynced = DateTime.Now;
						CS_0024_003C_003E8__locals2.newOrder.ItemCourse = ItemCourses.Uncategorized;
						CS_0024_003C_003E8__locals2.newOrder.GuestCount = CS_0024_003C_003E8__locals1.orderRes.guest_count;
						CS_0024_003C_003E8__locals2.newOrder.ItemOptionId = CS_0024_003C_003E8__locals1.orderRes.item_options_id;
						CS_0024_003C_003E8__locals2.newOrder.FlagID = 1;
						if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
						{
							CS_0024_003C_003E8__locals2.newOrder.FlagID = 0;
							if (!list3.Where((OnlineOrderSourceObject a) => a.OrderNumber == CS_0024_003C_003E8__locals2.newOrder.OrderNumber).Any())
							{
								list3.Add(new OnlineOrderSourceObject
								{
									OrderNumber = CS_0024_003C_003E8__locals2.newOrder.OrderNumber,
									Source = CS_0024_003C_003E8__locals2.newOrder.Source
								});
							}
						}
						if (CS_0024_003C_003E8__locals2.newOrder.DateCreated.Value < DateTime.Now.AddHours(-3.0) && CS_0024_003C_003E8__locals1.orderRes.order_type.Contains("Online"))
						{
							CS_0024_003C_003E8__locals2.newOrder.PrintedInKitchen = true;
							CS_0024_003C_003E8__locals2.newOrder.Notified = true;
							CS_0024_003C_003E8__locals2.newOrder.StationPrinted = CS_0024_003C_003E8__locals2.newOrder.StationID;
						}
						gclass6_0.Orders.InsertOnSubmit(CS_0024_003C_003E8__locals2.newOrder);
						SyncMethods.WriteToSyncLog("Hippos: Processing new online order, order=" + CS_0024_003C_003E8__locals1.orderRes.order_number + ", completed.", "OnlineOrderSync_");
					}
					list2.Add(new Guid(CS_0024_003C_003E8__locals1.orderRes.customer_order_id));
				}
			}
			method_10(gclass6_0);
			foreach (OnlineOrderSourceObject item2 in from a in list3
				group a by a.OrderNumber into a
				select new OnlineOrderSourceObject
				{
					OrderNumber = a.Key,
					Source = a.FirstOrDefault().Source
				})
			{
				if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
				{
					SyncMethods.UpdateOrderStatusInOrdering(item2.OrderNumber, "ReceivedByKitchen", string.Empty, string.Empty, item2.Source, 30);
				}
			}
			if (ordersFromRawData.Count > 0)
			{
				CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: true);
				method_13();
			}
			string value = SyncMethods.SyncTask(new OrderConfirmationModel
			{
				token = string_1,
				CustomerOrderIds = list2
			}, "/api/Orders/ConfirmSyncOrders");
			List<OrderPostDataModel> list4 = (from a in ordersFromRawData
				group a by a.order_number into a
				select new OrderPostDataModel
				{
					order_number = a.Key,
					date_refunded = a.FirstOrDefault().date_refunded,
					order_rows_per_ordernumber = a.FirstOrDefault().order_rows_per_ordernumber,
					paid = a.FirstOrDefault().paid,
					is_new_online = (a.Any((OrderPostDataModel b) => b.is_new_online) ? true : false)
				}).ToList();
			list.ForEach(delegate(OnlineOrderSyncQueue a)
			{
				a.DateProcessed = DateTime.Now;
			});
			method_10(gclass6_0);
			SyncMethods.WriteToSyncLog("Hippos: Confirmed received online orders.", "OnlineOrderSync_");
			using (List<OrderPostDataModel>.Enumerator enumerator = list4.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass68_4 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass68_4();
					CS_0024_003C_003E8__locals3.opdm = enumerator.Current;
					try
					{
						if (!string.IsNullOrEmpty(value))
						{
							continue;
						}
						StatusCodeResponse statusCodeResponse = new StatusCodeResponse();
						if (CS_0024_003C_003E8__locals3.opdm == null || !CS_0024_003C_003E8__locals3.opdm.is_new_online || CS_0024_003C_003E8__locals3.opdm.date_refunded.HasValue || gclass6_0.Orders.Where((Order a) => a.OrderNumber == CS_0024_003C_003E8__locals3.opdm.order_number).Count() != CS_0024_003C_003E8__locals3.opdm.order_rows_per_ordernumber)
						{
							continue;
						}
						if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
						{
							if (CS_0024_003C_003E8__locals3.opdm.order_number.Contains("WEB"))
							{
								statusCodeResponse = SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals3.opdm.order_number, "ReceivedByKitchen");
							}
							OrderPostDataModel orderPostDataModel = ordersFromRawData.Where((OrderPostDataModel a) => a.order_number == CS_0024_003C_003E8__locals3.opdm.order_number).FirstOrDefault();
							if (orderPostDataModel != null)
							{
								OrderHelper orderHelper = new OrderHelper();
								string text5 = OnlineOrderProviders.Hippos + " Online Order";
								text5 = (CS_0024_003C_003E8__locals3.opdm.order_number.Contains("SKIP") ? "SKIP" : (CS_0024_003C_003E8__locals3.opdm.order_number.Contains("UBER") ? "UBER" : ((!CS_0024_003C_003E8__locals3.opdm.order_number.Contains("WEB")) ? OnlineOrderSource.Unknown : (OnlineOrderProviders.Hippos + " Online Order"))));
								SyncMethods.WriteToSyncLog("Hippos: Printing online order=" + orderPostDataModel.order_number + ".", "OnlineOrderSync_");
								orderHelper.OrderPrintMadeCheck("", orderPostDataModel.order_number, orderPostDataModel.order_type, orderPostDataModel.customer_name, orderPostDataModel.customer_phone, text5, ordersFromRawData.Count);
							}
						}
						if (CS_0024_003C_003E8__locals3.opdm.date_refunded.HasValue)
						{
							if (CS_0024_003C_003E8__locals3.opdm.order_number.Contains("WEB"))
							{
								statusCodeResponse = SyncMethods.UpdateOrderStatusInOrdering(CS_0024_003C_003E8__locals3.opdm.order_number, "Refunded");
							}
						}
						else if (statusCodeResponse.code != 200 && !string.IsNullOrEmpty(statusCodeResponse.message))
						{
							NotificationMethods.sendCrashStringOnly(POSVersion.AppVersion, Environment.OSVersion.VersionString, statusCodeResponse.message);
							DebugMethods.ShowErrorTextFile(statusCodeResponse.message);
						}
					}
					catch (Exception ex)
					{
						SyncMethods.WriteToSyncLog("Hippos Error Print Online order" + CS_0024_003C_003E8__locals3.opdm.order_number + ": " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
					}
				}
			}
			SyncMethods.WriteToSyncLog("Hippos: Processing online orders completed.", "OnlineOrderSync_");
		}
		else
		{
			SyncMethods.WriteToSyncLog("Hippos: No orders to process.", "OnlineOrderSync_");
		}
	}

	private void timer_9_Tick(object sender, EventArgs e)
	{
		if (bool_7)
		{
			return;
		}
		bool_7 = true;
		try
		{
			if (!CheckSync() || string_2 != Environment.MachineName)
			{
				SyncMethods.WriteToSyncLog("ProcessOrderQueuesTimer: Stopped, CheckSync failed or not sync station.", "OnlineOrderSync_");
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				bool_7 = false;
				return;
			}
			if (MemoryLoadedObjects.hasThirdPartyOnlineSub)
			{
				method_15();
			}
			if (MemoryLoadedObjects.hasOnlineOrderOrModuurn)
			{
				method_14();
			}
		}
		catch (Exception ex)
		{
			bool_7 = false;
			SyncMethods.WriteToSyncLog("Error: ProcessOrderQueuesTimer Splash. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
		}
		bool_7 = false;
	}

	private void timer_10_Tick(object sender, EventArgs e)
	{
		try
		{
			method_12();
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(POSVersion.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void method_12()
	{
		CompanySetup companySetup = new GClass6().CompanySetups.FirstOrDefault();
		if (!companySetup.isOpen)
		{
			btnDayClosing.Text = Resources.Open_Store;
		}
		else
		{
			btnDayClosing.Text = Resources.End_of_day;
		}
		if (!MemoryLoadedObjects.isHipposOnlineOrder || !bool_4)
		{
			return;
		}
		if (companySetup.hasUnconfirmedOnlineOrder)
		{
			Application.OpenForms.OfType<frmLayout>().FirstOrDefault()?.ShowOnlineOrderNotification(show: true);
			if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.OrderEntry != null)
			{
				MemoryLoadedObjects.OrderEntry.ShowOnlineOrderNotification(show: true);
			}
		}
		else if (SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Quick Service" && SettingsHelper.GetSettingValueByKey("quickservice_screen") == "OFF" && MemoryLoadedObjects.OrderEntry != null)
		{
			MemoryLoadedObjects.OrderEntry.ShowOnlineOrderNotification(show: false);
		}
	}

	private void method_13()
	{
		if (!(SettingsHelper.GetSettingValueByKey("online_order_notification_all") == "ON") || !CompanyHelper.CheckIfCompanyHasUnconfirmedOnlineOrder())
		{
			return;
		}
		foreach (Form openForm in Application.OpenForms)
		{
			if (openForm is frmMasterForm && openForm.ParentForm == null)
			{
				(openForm as frmMasterForm).PersistentNotification.ShowOnlineOrderReceivedCheck(openForm.Name);
				break;
			}
		}
		PersistentNotification.ShowOnlineOrderReceivedCheck(base.Name);
	}

	private void OnlineOrderNotifTimer_Tick(object sender, EventArgs e)
	{
		if (SettingsHelper.GetSettingValueByKey("online_order_notification_all") == "ON")
		{
			int num = Convert.ToInt32(SettingsHelper.GetSettingValueByKey("online_order_notification_audio_time"));
			if (OnlineOrderNotifTimer.Interval != num * 1000)
			{
				OnlineOrderNotifTimer.Interval = num * 1000;
			}
			method_13();
		}
	}

	private void DuplicateOpenedPOSCheck_Tick(object sender, EventArgs e)
	{
		if (bool_8)
		{
			return;
		}
		bool_8 = true;
		if (Process.GetProcessesByName("Hippos").Count() > 1)
		{
			new frmMessageBox("Another Instance of Hippos is Running. Application is exiting.", "APPLICATION ERROR", CustomMessageBoxButtons.Ok).ShowDialog();
			method_5();
			foreach (Process item in from x in Process.GetProcessesByName("Hippos")
				orderby x.StartTime
				select x)
			{
				item.Kill();
			}
		}
		bool_8 = false;
	}

	private void method_14()
	{
		MemoryLoadedObjects.chitPrintSelfCheck_running = true;
		try
		{
			if (string_2 != Environment.MachineName)
			{
				SyncMethods.WriteToSyncLog("ProcessModuurnAndOnlineOrders: Stopped, CheckSync failed or not sync station.", "OnlineOrderSync_");
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				return;
			}
			foreach (OnlineOrderSettingObject provider in SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true))
			{
				SyncMethods.WriteToSyncLog(provider.Provider + ": Online order processing started.", "OnlineOrderSync_");
				if (provider.Provider == OnlineOrderProviders.Hippos && !string.IsNullOrEmpty(string_1))
				{
					method_11();
				}
				else if (provider.Provider == OnlineOrderProviders.Moduurn)
				{
					List<OrderHeader> list = ModuurnMethods.ProcessOrderQueues();
					if (SettingsHelper.GetSettingValueByKey("confirm_online_orders") == "OFF")
					{
						OrderHelper orderHelper = new OrderHelper();
						foreach (OrderHeader item in list)
						{
							orderHelper.OrderPrintMadeCheck("", item.OrderNumber, item.OrderType, item.CustomerInfoName, item.Customer, item.Source, item.ItemCount);
						}
					}
					if (list.Count > 0)
					{
						CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: true);
					}
					method_13();
				}
				SyncMethods.WriteToSyncLog(provider.Provider + ": Processing online order(s) has ended.", "OnlineOrderSync_");
			}
			MemoryLoadedObjects.chitPrintSelfCheck_running = false;
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog("Error: ProcessModuurnAndOnlineOrders. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
			MemoryLoadedObjects.chitPrintSelfCheck_running = false;
		}
	}

	private void method_15()
	{
		try
		{
			if (string_2 != Environment.MachineName)
			{
				SyncMethods.WriteToSyncLog("ProcessThirdPartyOrders: Stopped, CheckSync failed or not sync station.", "OnlineOrderSync_");
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				bool_7 = false;
				return;
			}
			List<OrderHeader> list = snvFovqoUji();
			if (list.Count > 0)
			{
				if (!bool_1)
				{
					MemoryLoadedObjects.chitPrintSelfCheck_running = true;
					OrderHelper orderHelper = new OrderHelper();
					foreach (OrderHeader item in list)
					{
						orderHelper.OrderPrintMadeCheck("", item.OrderNumber, item.OrderType, item.CustomerInfoName, item.Customer, item.Source, item.ItemCount);
					}
					MemoryLoadedObjects.chitPrintSelfCheck_running = false;
				}
				else
				{
					CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: true);
					method_13();
				}
			}
			MemoryLoadedObjects.chitPrintSelfCheck_running = false;
		}
		catch (Exception ex)
		{
			SyncMethods.WriteToSyncLog("Error: ProcessThirdPartyOrders Splash. " + ex.Message + "\n" + ex.StackTrace, "OnlineOrderSync_");
			MemoryLoadedObjects.chitPrintSelfCheck_running = false;
		}
	}

	private static List<OrderHeader> snvFovqoUji()
	{
		List<OrderHeader> list = new List<OrderHeader>();
		List<OrderHeader> list2 = DeliverectMethods.ProcessDeliverect();
		if (list2 != null)
		{
			list.AddRange(list2);
		}
		List<OrderHeader> list3 = FlytMethods.ProcessFlytOrders();
		if (list3 != null)
		{
			list.AddRange(list3);
		}
		return list;
	}

	private void method_16()
	{
		SyncMethods.WriteToSyncLog("SQL Dependency Started ", "OnlineOrderSync_");
		SqlDependency.Start(Helper.GetConnectionString());
		method_17();
		method_20();
	}

	private void method_17()
	{
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		using SqlCommand sqlCommand = new SqlCommand("SELECT [Id],[Provider] ,[RawData],[DateCreated],[DateProcessed] FROM [dbo].[OnlineOrderSyncQueues]", sqlConnection);
		new SqlDependency(sqlCommand).OnChange += method_18;
		sqlConnection.Open();
		using (sqlCommand.ExecuteReader())
		{
		}
		sqlConnection.Close();
	}

	private void method_18(object sender, SqlNotificationEventArgs e)
	{
		method_17();
		if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Insert)
		{
			SyncMethods.WriteToSyncLog("SQL Dependency Fired Online Order Table", "OnlineOrderSync_");
			if (MemoryLoadedObjects.hasThirdPartyOnlineSub)
			{
				method_15();
			}
			if (MemoryLoadedObjects.hasOnlineOrderOrModuurn)
			{
				method_14();
			}
		}
	}

	private void method_19()
	{
		if ((MemoryLoadedObjects.hasOnlineOrderOrModuurn || MemoryLoadedObjects.hasThirdPartyOnlineSub) && CheckSync())
		{
			SyncMethods.WriteToSyncLog("SQL Dependency Stopped ", "OnlineOrderSync_");
			SqlDependency.Stop(Helper.GetConnectionString());
			timer_11.Enabled = false;
		}
	}

	private void timer_11_Tick(object sender, EventArgs e)
	{
		LttFoPpnnrs(bool_9: false);
	}

	private void LttFoPpnnrs(bool bool_9)
	{
		if (SettingsHelper.GetSettingValueByKey("is_sql_dependency") == "ON" && (SqlDependency.Start(Helper.GetConnectionString()) || bool_9) && (MemoryLoadedObjects.hasOnlineOrderOrModuurn || MemoryLoadedObjects.hasThirdPartyOnlineSub) && CheckSync())
		{
			method_0();
		}
	}

	private void method_20()
	{
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		using SqlCommand sqlCommand = new SqlCommand("SELECT [TerminalID] ,[SystemName],[LastCheckedIn],[DefaultLayoutSectionName] ,[PaymentProviderName] ,[PaymentMerchantID],[PaymentTerminalModel],[PaymentTerminalAddress] ,[PaymentTerminalPort] ,[OperatingMode],[AppRestartRequired],[Status],[ItemsInGroupsRefreshRequired] ,[LayoutZoomValue],[SettingsRefreshedRequired] ,[PaymentTerminalSerial],[DefaultStation1] ,[DefaultStation2] ,[DefaultOrderTypes],[LastDateSettlement] ,[CloverAuthCode] ,[ProductKey] ,[DefaultPrinter],[PhoneModemDeviceName],[ShowPrintError],[Scale_ComPort],[InstallationToken],[InstallationID],[SystemUID] ,[ProcessOnlineOrderQueueFlag] FROM [dbo].[Terminals]", sqlConnection);
		new SqlDependency(sqlCommand).OnChange += method_21;
		sqlConnection.Open();
		using (sqlCommand.ExecuteReader())
		{
		}
		sqlConnection.Close();
	}

	private void method_21(object sender, SqlNotificationEventArgs e)
	{
		method_20();
		if (e.Type == SqlNotificationType.Change)
		{
			SyncMethods.WriteToSyncLog("SQL Dependency Fired Terminals Table", "OnlineOrderSync_");
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
			if (terminal != null && terminal.ProcessOnlineOrderQueueFlag)
			{
				terminal.ProcessOnlineOrderQueueFlag = false;
				Helper.SubmitChangesWithCatch(gClass);
				LttFoPpnnrs(bool_9: true);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && iMoFoirRqq0 != null)
		{
			iMoFoirRqq0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.iMoFoirRqq0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.frmSplash));
		this.btnClose = new System.Windows.Forms.Button();
		this.btnDayClosing = new System.Windows.Forms.Button();
		this.btnStation1 = new System.Windows.Forms.Button();
		this.btnAdmin = new System.Windows.Forms.Button();
		this.btnPay = new System.Windows.Forms.Button();
		this.btnInventory = new System.Windows.Forms.Button();
		this.btnRefund = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.btnLanguageChange = new System.Windows.Forms.Button();
		this.btnLogOut = new System.Windows.Forms.Button();
		this.btnNowServing = new System.Windows.Forms.Button();
		this.btnTimeAttendance = new System.Windows.Forms.Button();
		this.btnMembers = new System.Windows.Forms.Button();
		this.btnHelp = new System.Windows.Forms.Button();
		this.btnViewOrders = new System.Windows.Forms.Button();
		this.btnReports = new System.Windows.Forms.Button();
		this.btnStation2 = new System.Windows.Forms.Button();
		this.lblVersion = new System.Windows.Forms.Label();
		this.lblSystemMessage = new System.Windows.Forms.Label();
		this.lblTrainingMode = new System.Windows.Forms.Label();
		this.lblCompanyName = new System.Windows.Forms.Label();
		this.timer_0 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_1 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_2 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.lblEULA = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.lblUsefulTips = new System.Windows.Forms.Label();
		this.timer_3 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_4 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_5 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_6 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.lblNoInternet = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.timer_7 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_8 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_9 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_10 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.OnlineOrderNotifTimer = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.DuplicateOpenedPOSCheck = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.timer_11 = new System.Windows.Forms.Timer(this.iMoFoirRqq0);
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.btnClose, "btnClose");
		this.btnClose.BackColor = System.Drawing.Color.FromArgb(235, 107, 86);
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnClose.FlatAppearance.BorderSize = 0;
		this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnClose.ForeColor = System.Drawing.Color.White;
		this.btnClose.Name = "btnClose";
		this.btnClose.UseVisualStyleBackColor = false;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		componentResourceManager.ApplyResources(this.btnDayClosing, "btnDayClosing");
		this.btnDayClosing.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.btnDayClosing.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnDayClosing.FlatAppearance.BorderSize = 0;
		this.btnDayClosing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnDayClosing.ForeColor = System.Drawing.Color.White;
		this.btnDayClosing.Name = "btnDayClosing";
		this.btnDayClosing.UseVisualStyleBackColor = false;
		this.btnDayClosing.Click += new System.EventHandler(btnDayClosing_Click);
		componentResourceManager.ApplyResources(this.btnStation1, "btnStation1");
		this.btnStation1.BackColor = System.Drawing.Color.SandyBrown;
		this.btnStation1.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnStation1.FlatAppearance.BorderSize = 0;
		this.btnStation1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnStation1.ForeColor = System.Drawing.Color.White;
		this.btnStation1.Name = "btnStation1";
		this.btnStation1.UseVisualStyleBackColor = false;
		this.btnStation1.Click += new System.EventHandler(btnStation1_Click);
		componentResourceManager.ApplyResources(this.btnAdmin, "btnAdmin");
		this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnAdmin.FlatAppearance.BorderSize = 0;
		this.btnAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnAdmin.ForeColor = System.Drawing.Color.White;
		this.btnAdmin.Name = "btnAdmin";
		this.btnAdmin.UseVisualStyleBackColor = false;
		this.btnAdmin.Click += new System.EventHandler(btnAdmin_Click);
		componentResourceManager.ApplyResources(this.btnPay, "btnPay");
		this.btnPay.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnPay.FlatAppearance.BorderSize = 0;
		this.btnPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnPay.ForeColor = System.Drawing.Color.White;
		this.btnPay.Name = "btnPay";
		this.btnPay.UseVisualStyleBackColor = false;
		this.btnPay.Click += new System.EventHandler(btnPay_Click);
		componentResourceManager.ApplyResources(this.btnInventory, "btnInventory");
		this.btnInventory.BackColor = System.Drawing.Color.FromArgb(95, 237, 136);
		this.btnInventory.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnInventory.FlatAppearance.BorderSize = 0;
		this.btnInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnInventory.ForeColor = System.Drawing.Color.White;
		this.btnInventory.Name = "btnInventory";
		this.btnInventory.UseVisualStyleBackColor = false;
		this.btnInventory.Click += new System.EventHandler(btnInventory_Click);
		componentResourceManager.ApplyResources(this.btnRefund, "btnRefund");
		this.btnRefund.BackColor = System.Drawing.Color.FromArgb(65, 168, 95);
		this.btnRefund.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnRefund.FlatAppearance.BorderSize = 0;
		this.btnRefund.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnRefund.ForeColor = System.Drawing.Color.White;
		this.btnRefund.Name = "btnRefund";
		this.btnRefund.UseVisualStyleBackColor = false;
		this.btnRefund.Click += new System.EventHandler(btnRefund_Click);
		componentResourceManager.ApplyResources(this.panel1, "panel1");
		this.panel1.Controls.Add(this.btnLanguageChange);
		this.panel1.Controls.Add(this.btnLogOut);
		this.panel1.Controls.Add(this.btnNowServing);
		this.panel1.Controls.Add(this.btnTimeAttendance);
		this.panel1.Controls.Add(this.btnMembers);
		this.panel1.Controls.Add(this.btnHelp);
		this.panel1.Controls.Add(this.btnViewOrders);
		this.panel1.Controls.Add(this.btnReports);
		this.panel1.Controls.Add(this.btnStation2);
		this.panel1.Controls.Add(this.btnClose);
		this.panel1.Controls.Add(this.btnAdmin);
		this.panel1.Controls.Add(this.btnInventory);
		this.panel1.Controls.Add(this.btnRefund);
		this.panel1.Controls.Add(this.btnPay);
		this.panel1.Controls.Add(this.btnDayClosing);
		this.panel1.Controls.Add(this.btnStation1);
		this.panel1.Name = "panel1";
		componentResourceManager.ApplyResources(this.btnLanguageChange, "btnLanguageChange");
		this.btnLanguageChange.BackColor = System.Drawing.Color.FromArgb(42, 102, 134);
		this.btnLanguageChange.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnLanguageChange.FlatAppearance.BorderSize = 0;
		this.btnLanguageChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnLanguageChange.ForeColor = System.Drawing.Color.White;
		this.btnLanguageChange.Name = "btnLanguageChange";
		this.btnLanguageChange.UseVisualStyleBackColor = false;
		this.btnLanguageChange.Click += new System.EventHandler(btnLanguageChange_Click);
		componentResourceManager.ApplyResources(this.btnLogOut, "btnLogOut");
		this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(53, 143, 79);
		this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnLogOut.FlatAppearance.BorderSize = 0;
		this.btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnLogOut.ForeColor = System.Drawing.Color.White;
		this.btnLogOut.Name = "btnLogOut";
		this.btnLogOut.UseVisualStyleBackColor = false;
		this.btnLogOut.Click += new System.EventHandler(btnLogOut_Click);
		componentResourceManager.ApplyResources(this.btnNowServing, "btnNowServing");
		this.btnNowServing.BackColor = System.Drawing.Color.FromArgb(198, 129, 71);
		this.btnNowServing.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnNowServing.FlatAppearance.BorderSize = 0;
		this.btnNowServing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnNowServing.ForeColor = System.Drawing.Color.White;
		this.btnNowServing.Name = "btnNowServing";
		this.btnNowServing.UseVisualStyleBackColor = false;
		this.btnNowServing.Click += new System.EventHandler(btnNowServing_Click);
		componentResourceManager.ApplyResources(this.btnTimeAttendance, "btnTimeAttendance");
		this.btnTimeAttendance.BackColor = System.Drawing.Color.FromArgb(122, 79, 148);
		this.btnTimeAttendance.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnTimeAttendance.FlatAppearance.BorderSize = 0;
		this.btnTimeAttendance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnTimeAttendance.ForeColor = System.Drawing.Color.White;
		this.btnTimeAttendance.Name = "btnTimeAttendance";
		this.btnTimeAttendance.UseVisualStyleBackColor = false;
		this.btnTimeAttendance.Click += new System.EventHandler(btnTimeAttendance_Click);
		componentResourceManager.ApplyResources(this.btnMembers, "btnMembers");
		this.btnMembers.BackColor = System.Drawing.Color.FromArgb(80, 203, 116);
		this.btnMembers.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnMembers.FlatAppearance.BorderSize = 0;
		this.btnMembers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnMembers.ForeColor = System.Drawing.Color.White;
		this.btnMembers.Name = "btnMembers";
		this.btnMembers.UseVisualStyleBackColor = false;
		this.btnMembers.Click += new System.EventHandler(btnMembers_Click);
		componentResourceManager.ApplyResources(this.btnHelp, "btnHelp");
		this.btnHelp.BackColor = System.Drawing.Color.FromArgb(176, 124, 219);
		this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnHelp.FlatAppearance.BorderSize = 0;
		this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnHelp.ForeColor = System.Drawing.Color.White;
		this.btnHelp.Name = "btnHelp";
		this.btnHelp.UseVisualStyleBackColor = false;
		this.btnHelp.Click += new System.EventHandler(btnHelp_Click);
		componentResourceManager.ApplyResources(this.btnViewOrders, "btnViewOrders");
		this.btnViewOrders.BackColor = System.Drawing.Color.FromArgb(50, 119, 155);
		this.btnViewOrders.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnViewOrders.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnViewOrders.FlatAppearance.BorderSize = 0;
		this.btnViewOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnViewOrders.ForeColor = System.Drawing.Color.White;
		this.btnViewOrders.Name = "btnViewOrders";
		this.btnViewOrders.UseVisualStyleBackColor = false;
		this.btnViewOrders.Click += new System.EventHandler(btnViewOrders_Click);
		componentResourceManager.ApplyResources(this.btnReports, "btnReports");
		this.btnReports.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnReports.FlatAppearance.BorderSize = 0;
		this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnReports.ForeColor = System.Drawing.Color.White;
		this.btnReports.Name = "btnReports";
		this.btnReports.UseVisualStyleBackColor = false;
		this.btnReports.Click += new System.EventHandler(btnReports_Click);
		componentResourceManager.ApplyResources(this.btnStation2, "btnStation2");
		this.btnStation2.BackColor = System.Drawing.Color.FromArgb(214, 142, 81);
		this.btnStation2.FlatAppearance.BorderColor = System.Drawing.Color.White;
		this.btnStation2.FlatAppearance.BorderSize = 0;
		this.btnStation2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnStation2.ForeColor = System.Drawing.Color.White;
		this.btnStation2.Name = "btnStation2";
		this.btnStation2.UseVisualStyleBackColor = false;
		this.btnStation2.Click += new System.EventHandler(btnStation2_Click);
		componentResourceManager.ApplyResources(this.lblVersion, "lblVersion");
		this.lblVersion.ForeColor = System.Drawing.Color.White;
		this.lblVersion.Name = "lblVersion";
		componentResourceManager.ApplyResources(this.lblSystemMessage, "lblSystemMessage");
		this.lblSystemMessage.BackColor = System.Drawing.Color.Transparent;
		this.lblSystemMessage.ForeColor = System.Drawing.Color.White;
		this.lblSystemMessage.Name = "lblSystemMessage";
		componentResourceManager.ApplyResources(this.lblTrainingMode, "lblTrainingMode");
		this.lblTrainingMode.BackColor = System.Drawing.Color.FromArgb(193, 57, 43);
		this.lblTrainingMode.ForeColor = System.Drawing.Color.White;
		this.lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(this.lblCompanyName, "lblCompanyName");
		this.lblCompanyName.ForeColor = System.Drawing.Color.DarkGray;
		this.lblCompanyName.Name = "lblCompanyName";
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 180000;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.timer_1.Interval = 300000;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.timer_2.Interval = 3600000;
		this.timer_2.Tick += new System.EventHandler(timer_2_Tick);
		componentResourceManager.ApplyResources(this.lblEULA, "lblEULA");
		this.lblEULA.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblEULA.ForeColor = System.Drawing.Color.DarkGray;
		this.lblEULA.Name = "lblEULA";
		this.lblEULA.Click += new System.EventHandler(lblEULA_Click);
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this.lblUsefulTips, "lblUsefulTips");
		this.lblUsefulTips.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblUsefulTips.ForeColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.lblUsefulTips.Name = "lblUsefulTips";
		this.timer_3.Enabled = true;
		this.timer_3.Interval = 600000;
		this.timer_3.Tick += new System.EventHandler(timer_3_Tick);
		this.timer_4.Interval = 30000;
		this.timer_4.Tick += new System.EventHandler(timer_4_Tick);
		this.timer_5.Enabled = true;
		this.timer_5.Interval = 60000;
		this.timer_5.Tick += new System.EventHandler(timer_5_Tick);
		this.timer_6.Enabled = true;
		this.timer_6.Interval = 600000;
		this.timer_6.Tick += new System.EventHandler(timer_6_Tick);
		this.lblNoInternet.BackColor = System.Drawing.Color.FromArgb(193, 57, 43);
		componentResourceManager.ApplyResources(this.lblNoInternet, "lblNoInternet");
		this.lblNoInternet.ForeColor = System.Drawing.Color.White;
		this.lblNoInternet.Name = "lblNoInternet";
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Name = "label1";
		componentResourceManager.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Name = "label2";
		this.timer_7.Enabled = true;
		this.timer_7.Interval = 1500;
		this.timer_7.Tick += new System.EventHandler(timer_7_Tick);
		this.timer_8.Interval = 600000;
		this.timer_8.Tick += new System.EventHandler(timer_8_Tick);
		this.timer_9.Enabled = true;
		this.timer_9.Interval = 29500;
		this.timer_9.Tick += new System.EventHandler(timer_9_Tick);
		this.timer_10.Enabled = true;
		this.timer_10.Interval = 60000;
		this.timer_10.Tick += new System.EventHandler(timer_10_Tick);
		this.OnlineOrderNotifTimer.Enabled = true;
		this.OnlineOrderNotifTimer.Interval = 60000;
		this.OnlineOrderNotifTimer.Tick += new System.EventHandler(OnlineOrderNotifTimer_Tick);
		this.DuplicateOpenedPOSCheck.Enabled = true;
		this.DuplicateOpenedPOSCheck.Interval = 5000;
		this.DuplicateOpenedPOSCheck.Tick += new System.EventHandler(DuplicateOpenedPOSCheck_Tick);
		this.timer_11.Interval = 60000;
		this.timer_11.Tick += new System.EventHandler(timer_11_Tick);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.lblNoInternet);
		base.Controls.Add(this.lblTrainingMode);
		base.Controls.Add(this.lblUsefulTips);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.lblEULA);
		base.Controls.Add(this.lblCompanyName);
		base.Controls.Add(this.lblSystemMessage);
		base.Controls.Add(this.lblVersion);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSplash";
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Activated += new System.EventHandler(frmSplash_Activated);
		base.Load += new System.EventHandler(frmSplash_Load);
		this.panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private bool method_22(Station station_0)
	{
		return station_0.StationID == terminal_0.DefaultStation2;
	}

	[CompilerGenerated]
	private bool method_23(Station station_0)
	{
		return station_0.StationID == terminal_0.DefaultStation1;
	}

	[CompilerGenerated]
	private bool method_24(Station station_0)
	{
		return station_0.StationID == terminal_0.DefaultStation2;
	}

	[CompilerGenerated]
	private bool method_25(TapiLine tapiLine_0)
	{
		return tapiLine_0.Name == terminal_0.PhoneModemDeviceName;
	}
}
