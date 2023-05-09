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
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Helpers;
using CorePOS.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmLoader : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public List<Option> optionsDeleted;

		public _003C_003Ec__DisplayClass14_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public List<string> orderNumberToCheck;

		public _003C_003Ec__DisplayClass43_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_1
	{
		public ChitPrintQueue queue;

		public _003C_003Ec__DisplayClass43_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessChitPrintQueue_003Eb__7(Station a)
		{
			return a.StationID == queue.StationID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_2
	{
		public Station station;

		public _003C_003Ec__DisplayClass43_1 CS_0024_003C_003E8__locals1;

		public Func<Order, bool> _003C_003E9__8;

		public _003C_003Ec__DisplayClass43_2()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CProcessChitPrintQueue_003Eb__8(Order x)
		{
			if (x.StationID != null && x.StationID != "" && x.StationID.Contains(station.StationID.ToString()))
			{
				return CS_0024_003C_003E8__locals1.queue.OrderNumber.Contains(x.OrderNumber);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public frmLoader _003C_003E4__this;

		public X509Certificate serverCertificate;

		public _003C_003Ec__DisplayClass49_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CRunServer_003Eb__0()
		{
			while (Application.OpenForms.Count > 0)
			{
				TcpClient tcpClient = new TcpClient();
				try
				{
					tcpClient = _003C_003E4__this.listener.AcceptTcpClient();
					new TCPHelper().ProcessClient(tcpClient, serverCertificate);
				}
				catch
				{
					tcpClient.Close();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public List<string> orderNums;

		public List<ChitPrintInfo> tempVar;

		public _003C_003Ec__DisplayClass53_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CChitPrintTimer_Tick_003Eb__1(ChitPrintInfo a)
		{
			return tempVar.Contains(a);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass53_1
	{
		public ChitPrintInfo chitToPrint;

		public _003C_003Ec__DisplayClass53_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CChitPrintTimer_Tick_003Eb__2(Order a)
		{
			return chitToPrint.orderIds.Contains(a.OrderId);
		}

		internal bool _003CChitPrintTimer_Tick_003Eb__3(Order a)
		{
			if (!(a.OrderNumber == chitToPrint.OrderNumber))
			{
				return chitToPrint.RelatedOrderNumbers.Contains(a.OrderNumber);
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public int thresholdTimeInMinutes;

		public List<string> chitsToPrint;

		public int terminalID;

		public _003C_003Ec__DisplayClass54_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CChitPrintSelfCheck_Tick_003Eb__3(Order x)
		{
			if (!chitsToPrint.Contains(x.OrderNumber) && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value <= DateTime.Now.AddMinutes(-x.OrderOnHoldTime))) && ((x.OrderType != OrderTypes.PickUpOnline && x.OrderType != OrderTypes.DeliveryOnline && x.DateCreated.Value <= DateTime.Now.AddMinutes(-2.0)) || ((x.OrderType == OrderTypes.PickUpOnline || x.OrderType == OrderTypes.DeliveryOnline) && x.LastSynced.HasValue && x.LastSynced.Value <= DateTime.Now.AddMinutes(-4.0))) && x.Qty >= 1m && !x.ShareItemID.HasValue && (x.FlagID == 0 || x.FlagID != 5) && x.StationID != null && x.StationID != string.Empty && (x.StationPrinted == null || x.StationPrinted == string.Empty) && x.CreatedByTerminalID.HasValue)
			{
				return x.CreatedByTerminalID == terminalID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_1
	{
		public Order order;

		public Func<Order, bool> _003C_003E9__5;

		public _003C_003Ec__DisplayClass54_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CChitPrintSelfCheck_Tick_003Eb__5(Order x)
		{
			return x.OrderNumber == order.OrderNumber;
		}
	}

	private int int_0;

	private int int_1;

	private int int_2;

	private bool bool_0;

	private bool bool_1;

	public TcpListener listener;

	public HttpListener http_listener;

	private bool bool_2;

	private SettingsObject settingsObject_0;

	private bool bool_3;

	private bool bool_4;

	private short short_0;

	private IContainer icontainer_0;

	private System.Windows.Forms.Timer timer_0;

	private System.Windows.Forms.Timer timer_1;

	private Label lblVersion;

	private Panel panel1;

	private RadProgressBar progressBar1;

	private PictureBox pictureBox2;

	private System.Windows.Forms.Timer timer_2;

	private System.Windows.Forms.Timer timer_3;

	private System.Windows.Forms.Timer timer_4;

	private System.Windows.Forms.Timer timer_5;

	private System.Windows.Forms.Timer timer_6;

	private System.Windows.Forms.Timer timer_7;

	private System.Windows.Forms.Timer timer_8;

	private System.Windows.Forms.Timer timer_9;

	[DllImport("User32")]
	private static extern int GetGuiResources(IntPtr intptr_0, int int_3);

	public frmLoader()
	{
		Class26.Ggkj0JxzN9YmC();
		int_1 = 14;
		// base._002Ector();
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
		currentCulture = (currentCulture.Name.Contains("en-") ? new CultureInfo("en-US") : (currentCulture.Name.Contains("fr-") ? new CultureInfo("fr-CA") : ((!currentCulture.Name.Contains("es-US")) ? new CultureInfo("en-US") : new CultureInfo("es-US"))));
		Thread.CurrentThread.CurrentCulture = currentCulture;
		Thread.CurrentThread.CurrentUICulture = currentCulture;
		InitializeComponent();
		progressBar1.Maximum = int_1;
		CorePOS.Data.Properties.Settings.Default["AppVersion"] = AppSettings.AppVersion;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (int_2 < int_1)
		{
			switch (int_0)
			{
			case 0:
				method_3();
				break;
			case 1:
				method_4();
				break;
			case 2:
				method_5();
				break;
			case 3:
				method_14();
				break;
			case 4:
				method_6();
				break;
			case 5:
				method_7();
				break;
			case 6:
				checkForUpdates();
				break;
			case 7:
				method_15();
				break;
			case 8:
				method_16();
				break;
			case 9:
				method_17();
				break;
			case 10:
			{
				bool_0 = true;
				string text = SQLLogMethods.RunLog();
				if (!string.IsNullOrEmpty(text))
				{
					new frmMessageBox(text, "CRASH RECOVERY", CustomMessageBoxButtons.Ok).ShowDialog();
				}
				int_0++;
				int_2++;
				progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
				bool_0 = false;
				break;
			}
			case 11:
				bool_0 = true;
				method_2();
				int_2++;
				int_0++;
				progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
				bool_0 = false;
				break;
			case 12:
				bool_0 = true;
				method_20();
				int_2++;
				int_0++;
				progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
				bool_0 = false;
				break;
			case 13:
				bool_0 = true;
				LogHelper.CleanAllLogs();
				method_28();
				TwkFkykdyq6();
				method_0();
				timer_8.Enabled = true;
				int_2++;
				int_0++;
				progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
				bool_0 = false;
				break;
			}
			return;
		}
		System.Windows.Forms.Timer timer = timer_0;
		timer_1.Enabled = false;
		timer.Enabled = false;
		Hide();
		if (SettingsHelper.CurrentTerminalMode != "KitchenDisplay" && SettingsHelper.CurrentTerminalMode != "BarDisplay")
		{
			new frmSplash().Show();
		}
		else
		{
			Terminal terminal = new GClass6().Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (SettingsHelper.GetSettingValueByKey("kitchen_station_view") == "list")
			{
				new frmStation(null, (short)terminal.DefaultStation1).Show();
			}
			else
			{
				new frmStationTiles(null, (short)terminal.DefaultStation1).Show();
			}
		}
		System.Windows.Forms.Timer timer2 = timer_2;
		timer_6.Enabled = true;
		timer2.Enabled = true;
		GC.Collect();
	}

	private void method_0()
	{
		string text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
		string cmdText = "DELETE FROM OnlineOrderSyncQueues WHERE DateCreated < '" + text + "'";
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		sqlConnection.Open();
		new SqlCommand(cmdText, sqlConnection).ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void method_1()
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
			sqlConnection.Open();
			new SqlCommand("UPDATE [Orders] SET CustomerInfoPhone = Customer, Synced = 0 where Len(Customer) = 10 AND (OrderType = 'Pick-Up' OR OrderType = 'Delivery' OR OrderType = 'Pick-Up-Online' OR OrderType = 'Delivery-Online') AND(CustomerInfoPhone = '' OR CustomerInfoPhone IS NULL)", sqlConnection).ExecuteNonQuery();
			sqlConnection.Close();
			Console.WriteLine("Finished");
		}
		catch (Exception ex)
		{
			DebugMethods.ShowExceptionTextFile(ex);
		}
	}

	private void method_2()
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.optionsDeleted = gClass.Options.Where((Option a) => a.Item.isDeleted == true).ToList();
		List<ItemsWithOption> list = gClass.ItemsWithOptions.Where((ItemsWithOption a) => CS_0024_003C_003E8__locals0.optionsDeleted.Select((Option b) => b.OptionID).Contains(a.OptionID.Value) && a.ToBeDeleted == false).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (ItemsWithOption item in list)
		{
			item.ToBeDeleted = true;
			item.Synced = true;
		}
		gClass.SubmitChanges();
	}

	private void method_3()
	{
		if (Process.GetProcessesByName("Hippos").Count() > 1)
		{
			Thread.Sleep(5000);
			if (Process.GetProcessesByName("Hippos").Count() > 1)
			{
				System.Windows.Forms.Timer timer = timer_0;
				timer_1.Enabled = false;
				timer.Enabled = false;
				if (new frmMessageBox(Resources.Another_instance_of_Hippos_exe, Resources.Warning1, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
				{
					foreach (Process item in from x in Process.GetProcessesByName("Hippos")
						orderby x.StartTime
						select x)
					{
						if (!item.HasExited)
						{
							item.Kill();
							if (item.HasExited)
							{
								System.Windows.Forms.Timer timer2 = timer_0;
								timer_1.Enabled = true;
								timer2.Enabled = true;
								break;
							}
							continue;
						}
						System.Windows.Forms.Timer timer3 = timer_0;
						timer_1.Enabled = true;
						timer3.Enabled = true;
						break;
					}
				}
				else
				{
					FormHelper.CleanupObjects();
					Application.Exit();
				}
			}
		}
		int_0++;
		int_2++;
	}

	private void method_4()
	{
		bool_0 = true;
		if (!method_10("SOFTWARE\\Microsoft\\Microsoft SQL Server") && !method_10("SOFTWARE\\Microsoft\\Microsoft SQL Server Local DB"))
		{
			if (new frmMessageBox(Resources.HIPPOS_will_need_to_download_a, Resources.MS_SQL_Required, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				string text = (Environment.Is64BitOperatingSystem ? "SqlLocalDB_64bit.msi" : "SqlLocalDB_32bit.msi");
				string url = Servers.downloads + "/" + text;
				string text2 = method_8() + "/" + text;
				if (!File.Exists(text2))
				{
					if (new frmDownloader(url, text2, text).ShowDialog(this) == DialogResult.OK)
					{
						method_9(text2);
					}
					else
					{
						new frmMessageBox(Resources.An_error_has_occurred_trying_t, Resources.Error_downloading).ShowDialog(this);
						Application.Exit();
					}
				}
				else
				{
					method_9(text2);
				}
				text = null;
				url = null;
				text2 = null;
			}
			else
			{
				Application.Exit();
			}
		}
		else
		{
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
		GC.Collect();
	}

	private void method_5()
	{
		bool_0 = true;
		try
		{
			Helper.SetConnectionString(StringCipher.Decrypt(Helper.GetEncryptedConnectionString(), "DigitalCraftHipPOS"));
			new GClass6().Taxes.FirstOrDefault();
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
		catch (Exception ex)
		{
			frmSQLSettings frmSQLSettings2 = new frmSQLSettings
			{
				darkenBg = false
			};
			if (ex.Message.Contains(Resources.version0))
			{
				frmMessageBox obj = new frmMessageBox(Resources.HIPPOS_can_only_run_on_SQL_Ser);
				obj.darkenBg = false;
				obj.ShowDialog(this);
				obj.Dispose();
			}
			else
			{
				frmMessageBox obj2 = new frmMessageBox(Resources.Unable_to_connect_to_SQL_Serve);
				obj2.darkenBg = false;
				obj2.ShowDialog(this);
				obj2.Dispose();
			}
			timer_0.Enabled = false;
			frmSQLSettings2.ShowDialog();
			frmSQLSettings2.Dispose();
			Hide();
			GC.Collect();
		}
		GC.Collect();
	}

	private void method_6()
	{
		bool_0 = true;
		int_0++;
		int_2++;
		progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
		bool_0 = false;
	}

	private void method_7()
	{
		bool_0 = true;
		if (!method_10("Software\\Wow6432Node\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx\\ReportViewer v10") && !method_10("SOFTWARE\\Wow6432Node\\Microsoft\\ReportViewer\\v10.0") && !method_10("SOFTWARE\\Microsoft\\ReportViewer\\v10.0"))
		{
			if (new frmMessageBox(Resources.HIPPOS_will_need_to_download_a0, Resources.MS_Report_Viewer_Required, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				string text = "ReportViewer10.exe";
				string url = Servers.downloads + "/" + text;
				string text2 = method_8() + "/" + text;
				if (!File.Exists(text2))
				{
					if (new frmDownloader(url, text2, text).ShowDialog(this) == DialogResult.OK)
					{
						method_9(text2);
					}
					else
					{
						new frmMessageBox(Resources.An_error_has_occurred_trying_t0, Resources.Error_downloading).ShowDialog(this);
						Application.Exit();
					}
				}
				else
				{
					method_9(text2);
				}
				text = null;
				url = null;
				text2 = null;
			}
			else
			{
				Application.Exit();
			}
		}
		else
		{
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
	}

	private string method_8()
	{
		return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
	}

	private void method_9(string string_0)
	{
		Process.Start(string_0);
		Application.Exit();
	}

	private bool method_10(string string_0)
	{
		RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
		string_0 = (Environment.Is64BitOperatingSystem ? string_0.Replace("SOFTWARE", "SOFTWARE\\Wow6432Node") : string_0);
		if (registryKey != null)
		{
			if (registryKey.OpenSubKey(string_0) != null)
			{
				registryKey = null;
				return true;
			}
			string_0 += " Local DB";
			if (registryKey.OpenSubKey(string_0) != null)
			{
				registryKey = null;
				return true;
			}
			registryKey = null;
			return false;
		}
		registryKey = null;
		return false;
	}

	public void checkForUpdates()
	{
		bool_0 = true;
		MemoryLoadedObjects.RefreshTerminalData();
		CheckForUpdatesPostData checkForUpdatesPostData = new CheckForUpdatesPostData();
		checkForUpdatesPostData.edition = "restaurant";
		checkForUpdatesPostData.current_version = AppSettings.AppVersion;
		checkForUpdatesPostData.build_number = AppSettings.Build;
		checkForUpdatesPostData.product_serial_key = MemoryLoadedObjects.this_terminal.ProductKey;
		if (MemoryLoadedObjects.isInternalDev)
		{
			checkForUpdatesPostData.build_type = 2;
		}
		else
		{
			checkForUpdatesPostData.build_type = 0;
		}
		StatusCodeResponseUpdate statusCodeResponseUpdate = SyncMethods.CheckForUpdate(checkForUpdatesPostData);
		if (statusCodeResponseUpdate.code == 200 && !string.IsNullOrEmpty(statusCodeResponseUpdate.message))
		{
			Setting setting = new GClass6().Settings.Where((Setting s) => s.Key == "db_version").FirstOrDefault();
			if (setting != null && !(setting.Value != AppSettings.AppVersion) && !statusCodeResponseUpdate.IsForceUpdate)
			{
				if (!bool_1)
				{
					bool_1 = true;
					base.TopMost = true;
					if (MessageBox.Show(this, Resources.A_newer_version_exist_for_Hipp, Resources.HIPPOS_Updates0, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
					{
						method_11(statusCodeResponseUpdate.message);
					}
					else
					{
						bool_1 = false;
						int_0++;
						int_2++;
						progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
						bool_0 = false;
					}
				}
			}
			else if (!bool_1)
			{
				bool_1 = true;
				string text = Resources.Another_station_has_already_up;
				if (statusCodeResponseUpdate.IsForceUpdate)
				{
					text = "This station will need to be updated to the latest version in order to function.";
				}
				base.TopMost = true;
				if (MessageBox.Show(this, text, Resources.Hippos_Updates, MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
				{
					method_11(statusCodeResponseUpdate.message);
				}
				else
				{
					FormHelper.CleanupObjects();
					Application.Exit();
				}
			}
			setting = null;
		}
		else
		{
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
		checkForUpdatesPostData = null;
		statusCodeResponseUpdate = null;
	}

	private void method_11(string string_0)
	{
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/HipPOS-Updater.exe"))
		{
			File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/HipPOS-Updater.exe");
		}
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/HipPOS-Updater.pdb"))
		{
			File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/HipPOS-Updater.pdb");
		}
		method_12(string_0.Replace(".exe", ".pdb"), AppDomain.CurrentDomain.BaseDirectory + "HipPOS-Updater.pdb");
		method_12(string_0, AppDomain.CurrentDomain.BaseDirectory + "HipPOS-Updater.exe");
	}

	private void method_12(string string_0, string string_1)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			if (string_1 == AppDomain.CurrentDomain.BaseDirectory + "HipPOS-Updater.exe")
			{
				webClient.DownloadFileCompleted += method_13;
			}
			webClient.DownloadFileAsync(new Uri(string_0), string_1);
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
	}

	private void method_13(object sender, AsyncCompletedEventArgs e)
	{
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/HipPOS-Updater.exe"))
		{
			Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\HipPOS-Updater.exe");
		}
		int_2++;
		progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
		bool_0 = false;
		Application.Exit();
	}

	private void method_14(bool bool_5 = false)
	{
		bool_0 = true;
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (terminal != null)
		{
			if (SyncMethods.CheckInternet())
			{
				string systemUIDCipher = MiscHelper.GetSystemUIDCipher();
				if (string.IsNullOrEmpty(terminal.ProductKey) || string.IsNullOrEmpty(terminal.InstallationToken) || string.IsNullOrEmpty(terminal.InstallationID) || string.IsNullOrEmpty(terminal.String_0))
				{
					terminal.ProductKey = MiscHelper.getRegistryValue("Software\\DigitalCraft\\HipPOS", "ProductKey");
					terminal.InstallationToken = MiscHelper.getRegistryValue("Software\\DigitalCraft\\HipPOS", "InstallToken");
					terminal.InstallationID = MiscHelper.getRegistryValue("Software\\DigitalCraft\\HipPOS", "InstallID");
					terminal.String_0 = StringCipher.Encrypt(MiscHelper.getRegistryValue("Software\\Microsoft\\Windows NT\\CurrentVersion", "ProductId"), systemUIDCipher);
					if (!string.IsNullOrEmpty(terminal.ProductKey) && !string.IsNullOrEmpty(terminal.InstallationToken) && !string.IsNullOrEmpty(terminal.InstallationID) && !string.IsNullOrEmpty(terminal.String_0))
					{
						Helper.SubmitChangesWithCatch(gClass);
					}
					else if (!bool_5)
					{
						new frmProductKey().ShowDialog();
					}
					else
					{
						Application.Exit();
					}
				}
				CryptoHelper cryptoHelper = new CryptoHelper();
				string[] array = cryptoHelper.Decrypt(terminal.InstallationToken, terminal.InstallationID).Split(';');
				string text = StringCipher.Decrypt(terminal.String_0, systemUIDCipher);
				if (string.IsNullOrEmpty(text) || text == "false")
				{
					new frmMessageBox(Resources.Unable_to_validate_license, Resources.Fatal_Error).ShowDialog();
					Application.Exit();
				}
				DateTime dateTime = DateTime.Now.AddDays(-1.0);
				try
				{
					dateTime = DateTime.ParseExact(array[2], "MM/dd/yyyy", CultureInfo.CurrentCulture);
				}
				catch
				{
					new frmMessageBox(Resources.Unable_to_validate_license, Resources.Fatal_Error).ShowDialog();
					Application.Exit();
				}
				if (SyncMethods.CheckInternet())
				{
					if (!string.IsNullOrEmpty(terminal.ProductKey) && !string.IsNullOrEmpty(terminal.InstallationToken) && !string.IsNullOrEmpty(terminal.InstallationID))
					{
						string text2 = MiscHelper.productkeyCheckHelper(required: false);
						if (text2 != string.Empty)
						{
							new frmMessageBox(text2).ShowDialog();
							if (!bool_5)
							{
								new frmProductKey().ShowDialog();
							}
							else
							{
								Application.Exit();
							}
						}
						else
						{
							array = cryptoHelper.Decrypt(terminal.InstallationToken, terminal.InstallationID).Split(';');
							text = StringCipher.Decrypt(terminal.String_0, systemUIDCipher);
							if (terminal.ProductKey == array[0] && text == array[1])
							{
								try
								{
									dateTime = DateTime.ParseExact(array[2], "MM/dd/yyyy", CultureInfo.CurrentCulture);
								}
								catch
								{
									new frmMessageBox(Resources.Unable_to_validate_license, Resources.Fatal_Error).ShowDialog();
									Application.Exit();
								}
								if (DateTime.Now.Date > dateTime)
								{
									new frmMessageBox(Resources.Your_license_has_expired_Pleas, Resources.License_Expired).ShowDialog();
									if (!bool_5)
									{
										new frmProductKey().ShowDialog();
									}
									else
									{
										Application.Exit();
									}
								}
								else
								{
									TimeSpan timeSpan = dateTime - DateTime.Now;
									if (timeSpan.Days == 0 && !bool_5)
									{
										new frmMessageBox(Resources.Your_license_will_expire_today, Resources.License_Expiry).ShowDialog();
									}
									else if (timeSpan.Days <= 7 && !bool_5)
									{
										new frmMessageBox(Resources.Your_license_will_expire_in + timeSpan.Days + Resources._days, Resources.License_Expiry).ShowDialog();
									}
								}
							}
							else
							{
								new frmMessageBox(Resources.Invalid_Product_Installation_P, Resources.Invalid_License).ShowDialog();
								if (!bool_5)
								{
									new frmProductKey().ShowDialog();
								}
								else
								{
									Application.Exit();
								}
							}
						}
					}
					else if (!bool_5)
					{
						new frmProductKey().ShowDialog();
					}
					else
					{
						Application.Exit();
					}
				}
				else if (dateTime.Date > DateTime.Now.Date)
				{
					TimeSpan timeSpan2 = dateTime - DateTime.Now;
					if (timeSpan2.Days == 0)
					{
						new frmMessageBox(Resources.Your_license_will_expire_today, Resources.License_Expiry).ShowDialog();
					}
					else if (timeSpan2.Days <= 7)
					{
						new frmMessageBox(Resources.Your_license_will_expire_in + timeSpan2.Days + Resources._days, Resources.License_Expiry).ShowDialog();
					}
				}
				else
				{
					new frmMessageBox("Unable to connect to our license server, please check internet connection.", Resources.License_Expired).ShowDialog();
				}
			}
		}
		else
		{
			new frmMessageBox(Resources.Invalid_Product_Installation_P, Resources.Invalid_License).ShowDialog();
			if (!bool_5)
			{
				new frmProductKey().ShowDialog();
			}
			else
			{
				Application.Exit();
			}
		}
		if (!bool_5)
		{
			int_0++;
			int_2++;
			progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
			bool_0 = false;
		}
		GC.Collect();
	}

	private void method_15()
	{
		bool_0 = true;
		int num = 0;
		foreach (ManagementObject item in new ManagementObjectSearcher("Select * from Win32_Keyboard").Get())
		{
			if (!item.GetPropertyValue("Name").Equals(string.Empty) && item.GetPropertyValue("Description").ToString().Contains("USB Input Device"))
			{
				num++;
			}
		}
		if (num > 0)
		{
			CorePOS.Properties.Settings.Default["KeyboardConnected"] = true;
		}
		else if (num == 0)
		{
			if (File.Exists("C:\\Program Files\\Common Files\\Microsoft Shared\\ink\\tabtip.exe"))
			{
				CorePOS.Properties.Settings.Default["KeyboardConnected"] = false;
			}
			else
			{
				CorePOS.Properties.Settings.Default["KeyboardConnected"] = true;
			}
		}
		foreach (ManagementObject item2 in new ManagementObjectSearcher("select * from Win32_Processor").Get())
		{
			if (!item2.GetPropertyValue("Name").Equals(string.Empty))
			{
				if (item2.GetPropertyValue("Name").ToString().Contains("Atom"))
				{
					CorePOS.Properties.Settings.Default["isTabletDevice"] = true;
				}
				else
				{
					CorePOS.Properties.Settings.Default["isTabletDevice"] = false;
				}
			}
		}
		HelperMethods.SetSystemTime();
		int_0++;
		int_2++;
		progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
		bool_0 = false;
		GC.Collect();
	}

	private void method_16()
	{
		bool_0 = true;
		string text = "free3of9.ttf";
		string text2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "includes", text);
		string text3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), text);
		if (!File.Exists(text3))
		{
			if (!File.Exists(text2))
			{
				text2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, text);
				if (!File.Exists(text2))
				{
					int_0++;
					int_2++;
					bool_0 = false;
					progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
					return;
				}
			}
			File.Copy(text2, text3);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts", "Free 3 or 9 Regular", text3, RegistryValueKind.String);
			if (new frmMessageBox(Resources.A_system_restart_is_required_t, Resources.Restart_Required, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				Process.Start(new ProcessStartInfo
				{
					WindowStyle = ProcessWindowStyle.Hidden,
					FileName = "cmd",
					Arguments = "/C shutdown -f -r -t 0"
				});
			}
		}
		int_0++;
		int_2++;
		progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
		bool_0 = false;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (method_10("Software\\Wow6432Node\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx\\ReportViewer v10") || method_10("SOFTWARE\\Wow6432Node\\Microsoft\\ReportViewer\\v10.0") || method_10("SOFTWARE\\Microsoft\\ReportViewer\\v10.0"))
		{
			timer_0.Enabled = true;
			timer_1.Enabled = false;
			bool_0 = false;
		}
	}

	private void YrfFkRwrjyZ(object sender, EventArgs e)
	{
		lblVersion.Text = Resources.Version1 + AppSettings.AppVersion + Resources._Build + AppSettings.Build;
	}

	private void method_17()
	{
		bool_0 = true;
		GClass6 gClass = new GClass6();
		SubscriptionResponseData subscriptionResponseData = new SubscriptionResponseData();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (terminal == null)
		{
			new frmMessageBox("An error occured while obtaining your subscription.  Please contact Hippos Support.", "Error Updating").ShowDialog(this);
			Application.Exit();
			return;
		}
		try
		{
			subscriptionResponseData = SyncMethods.GetSubscriptions(new GetSubscriptionPostModel
			{
				productkey = terminal.ProductKey
			});
			if (subscriptionResponseData.code == 200)
			{
				method_18(subscriptionResponseData.subscription_ids, subscriptionResponseData.prodkey_subscription_id);
			}
			else if (terminal.Status == TerminalStatus.inactive || terminal.Status == TerminalStatus.deleted)
			{
				terminal.Status = TerminalStatus.active;
				gClass.SubmitChanges();
				MemoryLoadedObjects.RefreshTerminals();
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		int_0++;
		int_2++;
		progressBar1.Value1 = ((int_2 > progressBar1.Maximum) ? progressBar1.Maximum : int_2);
		bool_0 = false;
		gClass = null;
		subscriptionResponseData = null;
	}

	private bool method_18(List<Guid> list_0, Guid guid_0)
	{
		if (list_0 == null || list_0.Count == 0 || guid_0 == Guid.Empty)
		{
			new frmMessageBox("Unable to obtain subscription.  Please contact Hippos.", "Invalid Subscription").ShowDialog(this);
			Application.Exit();
		}
		AckrooMethods.server = "https://api.ackroo.net";
		bool flag = false;
		GClass6 gClass = new GClass6();
		Setting setting = gClass.Settings.Where((Setting o) => o.Key.ToLower() == "restaurant_mode").FirstOrDefault();
		if (list_0.Contains(SubscriptionIDs.Licenses.Hippos_Internal))
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "pksubeval.key";
			List<Guid> list = new List<Guid>();
			if (File.Exists(path))
			{
				AckrooMethods.server = "https://api.sandbox.ackroolabs.com";
				MemoryLoadedObjects.isInternalDev = true;
				using (StreamReader streamReader = new StreamReader(path))
				{
					while (streamReader.Peek() >= 0)
					{
						Guid.TryParse(StringCipher.Decrypt(streamReader.ReadLine(), "DigitalCraftHipPOS"), out var result);
						if (result != Guid.Empty)
						{
							list.Add(result);
						}
					}
				}
				list_0 = list;
				flag = true;
				method_29();
			}
			else
			{
				new frmMessageBox("Please ask DEV to give you subscription file.", "Error updating").ShowDialog(this);
			}
		}
		if (!list_0.Contains(SubscriptionIDs.Licenses.FullService_Annual) && !list_0.Contains(SubscriptionIDs.Licenses.FullService_Monthly) && !list_0.Contains(SubscriptionIDs.Licenses.FullService_OneTimePurchase))
		{
			if (!list_0.Contains(SubscriptionIDs.Licenses.QuickService_Annual) && !list_0.Contains(SubscriptionIDs.Licenses.QuickService_Monthly) && !list_0.Contains(SubscriptionIDs.Licenses.QuickService_OneTimePurchase))
			{
				new frmMessageBox(Resources.An_error_occured_while_obtaini, Resources.Error_updating).ShowDialog(this);
				Application.Exit();
			}
			else
			{
				setting.Value = "Quick Service";
			}
		}
		else
		{
			setting.Value = "Dine In";
		}
		Helper.SubmitChangesWithCatch(gClass);
		Setting setting2 = gClass.Settings.Where((Setting o) => o.Key.ToLower() == "hippos_time").FirstOrDefault();
		if (list_0.Contains(SubscriptionIDs.AddOns.StaffManagement))
		{
			setting2.Value = "Enabled";
		}
		else
		{
			setting2.Value = "Disabled";
		}
		Helper.SubmitChangesWithCatch(gClass);
		Setting setting3 = gClass.Settings.Where((Setting o) => o.Key.ToLower() == "production_mode").FirstOrDefault();
		if (list_0.Contains(SubscriptionIDs.AddOns.ProductionMode))
		{
			setting3.Value = "Enabled";
		}
		else
		{
			setting3.Value = "Disabled";
		}
		Helper.SubmitChangesWithCatch(gClass);
		Setting setting4 = gClass.Settings.Where((Setting o) => o.Key.ToLower() == "sms").FirstOrDefault();
		if (list_0.Contains(SubscriptionIDs.AddOns.SMSNotifications))
		{
			setting4.Value = "Enabled";
		}
		else
		{
			setting4.Value = "Disabled";
		}
		Helper.SubmitChangesWithCatch(gClass);
		if (list_0.Contains(SubscriptionIDs.AddOns.Delivery_Management))
		{
			MemoryLoadedData.IsDeliveryManagement = true;
		}
		else
		{
			MemoryLoadedData.IsDeliveryManagement = false;
		}
		OnlineOrderSettingObject onlineOrderSettingObject = SettingsHelper.OnlineOrderSettings.Get(OnlineOrderProviders.Hippos);
		if (!list_0.Contains(SubscriptionIDs.AddOns.OnlineOrdering_Monthly) && !list_0.Contains(SubscriptionIDs.AddOns.OnlineOrdering_Annual) && !list_0.Contains(SubscriptionIDs.AddOns.SkipTheDishes_Monthly) && !list_0.Contains(SubscriptionIDs.AddOns.Deliverect_Monthly) && !flag)
		{
			MemoryLoadedObjects.isHipposOnlineOrder = false;
			if (onlineOrderSettingObject != null && onlineOrderSettingObject.isActive)
			{
				SettingsHelper.OnlineOrderSettings.Save(onlineOrderSettingObject.Provider, string.Empty, string.Empty, onlineOrderSettingObject.PollInterval, isActive: false);
			}
		}
		else
		{
			MemoryLoadedObjects.isHipposOnlineOrder = true;
			if (list_0.Contains(SubscriptionIDs.AddOns.Deliverect_Monthly) || list_0.Contains(SubscriptionIDs.AddOns.SkipTheDishes_Monthly) || flag)
			{
				MemoryLoadedObjects.hasThirdPartyOnlineSub = true;
			}
			if (onlineOrderSettingObject != null)
			{
				if (!onlineOrderSettingObject.isActive)
				{
					SettingsHelper.OnlineOrderSettings.Save(onlineOrderSettingObject.Provider, string.Empty, string.Empty, onlineOrderSettingObject.PollInterval, isActive: true);
				}
			}
			else
			{
				SettingsHelper.OnlineOrderSettings.Save(OnlineOrderProviders.Hippos, string.Empty, string.Empty, 30, isActive: true);
			}
		}
		if ((flag && (list_0.Contains(SubscriptionIDs.Licenses.Patron_Ordering_Annual) || list_0.Contains(SubscriptionIDs.Licenses.Patron_Ordering_Monthly))) || (!flag && (guid_0 == SubscriptionIDs.Licenses.Patron_Ordering_Annual || guid_0 == SubscriptionIDs.Licenses.Patron_Ordering_Monthly)))
		{
			SettingsHelper.CurrentTerminalMode = "Patron";
		}
		else if ((flag && list_0.Contains(SubscriptionIDs.Licenses.Kitchen_Display_System)) || (!flag && guid_0 == SubscriptionIDs.Licenses.Kitchen_Display_System))
		{
			SettingsHelper.CurrentTerminalMode = "KitchenDisplay";
		}
		else if ((flag && list_0.Contains(SubscriptionIDs.Licenses.Bar_Display_System)) || (!flag && guid_0 == SubscriptionIDs.Licenses.Bar_Display_System))
		{
			SettingsHelper.CurrentTerminalMode = "BarDisplay";
		}
		else if ((flag && (list_0.Contains(SubscriptionIDs.Licenses.Kiosk_Mode_Annual) || list_0.Contains(SubscriptionIDs.Licenses.Kiosk_Mode_Monthly))) || (!flag && (guid_0 == SubscriptionIDs.Licenses.Kiosk_Mode_Annual || guid_0 == SubscriptionIDs.Licenses.Kiosk_Mode_Monthly)))
		{
			SettingsHelper.CurrentTerminalMode = "Kiosk";
		}
		else
		{
			SettingsHelper.CurrentTerminalMode = "Normal";
		}
		Helper.SubmitChangesWithCatch(gClass);
		if (list_0.Contains(SubscriptionIDs.AddOns.VoidOrder))
		{
			bool_2 = true;
		}
		if (list_0.Contains(SubscriptionIDs.AddOns.GlobalOrderHistory))
		{
			SettingsHelper.hasGlobalOrderHistoryAddOn = true;
		}
		method_19();
		setting4 = null;
		return flag;
	}

	private void method_19()
	{
		bool flag = false;
		using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString()))
		{
			SqlCommand sqlCommand = new SqlCommand("SELECT * from Terminals where SystemName = @systemName", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@systemName", Environment.MachineName);
			sqlConnection.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.Read())
			{
				flag = true;
			}
			sqlDataReader.Close();
			sqlConnection.Close();
		}
		if (!flag)
		{
			using SqlConnection sqlConnection2 = new SqlConnection(Helper.GetConnectionString());
			SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO Terminals (SystemName,LastCheckedIn,DefaultLayoutSectionName, OperatingMode) VALUES (@val1, GETDATE(), @val3, @val4)", sqlConnection2);
			sqlCommand2.Parameters.AddWithValue("@val1", Environment.MachineName);
			sqlCommand2.Parameters.AddWithValue("@val3", "");
			sqlCommand2.Parameters.AddWithValue("@val4", SettingsHelper.CurrentTerminalMode);
			try
			{
				sqlConnection2.Open();
				sqlCommand2.ExecuteNonQuery();
			}
			catch (SqlException)
			{
				new frmMessageBox(Resources.An_error_has_occurred_trying_t2, Resources.Error_inserting).ShowDialog(this);
				Application.Exit();
			}
		}
		else
		{
			using SqlConnection sqlConnection3 = new SqlConnection(Helper.GetConnectionString());
			SqlCommand sqlCommand3 = new SqlCommand("Update Terminals set LastCheckedIn = GETDATE(), status='active', OperatingMode=@operatingMode where SystemName = @systemName", sqlConnection3);
			sqlCommand3.Parameters.AddWithValue("@systemName", Environment.MachineName);
			sqlCommand3.Parameters.AddWithValue("@operatingMode", SettingsHelper.CurrentTerminalMode);
			try
			{
				sqlConnection3.Open();
				sqlCommand3.ExecuteNonQuery();
			}
			catch (SqlException)
			{
				new frmMessageBox(Resources.An_error_has_occurred_trying_t1, Resources.Error_updating).ShowDialog(this);
				Application.Exit();
			}
		}
		GC.Collect();
	}

	private void TwkFkykdyq6()
	{
		CultureInfo cultureInfo = new CultureInfo(SettingsHelper.GetSettingValueByKey("primary_language"));
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		cultureInfo = null;
	}

	private void method_20()
	{
		SettingsHelper.isVoidOrderAddOn = bool_2;
		SettingsHelper.SetAllSettings();
		MemoryLoadedObjects.RefreshTerminals();
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
		if (SettingsHelper.GetSettingValueByKey("scale_comport") != null && SettingsHelper.GetSettingValueByKey("scale_comport") != "" && MemoryLoadedObjects.this_terminal != null && string.IsNullOrEmpty(MemoryLoadedObjects.this_terminal.Scale_ComPort) && terminal != null)
		{
			terminal.Scale_ComPort = SettingsHelper.GetSettingValueByKey("scale_comport");
			Setting setting = gClass.Settings.Where((Setting x) => x.Key == "scale_comport").FirstOrDefault();
			if (setting != null)
			{
				gClass.Settings.DeleteOnSubmit(setting);
				SettingsHelper.SetAllSettings();
			}
			gClass.SubmitChanges();
		}
		SecurityHelper.LoadSecuritySettings();
		CompanyHelper.SetCompany();
		if (CompanyHelper.CompanyDataSetup.TimeZoneName != TimeZone.CurrentTimeZone.StandardName)
		{
			MiscHelper.SetSystemTimeZone(CompanyHelper.CompanyDataSetup.TimeZoneName);
		}
		SettingsHelper.ConstantItemsUpdatedLatest();
		MemoryLoadedObjects.RefreshUsers();
		MemoryLoadedObjects.RefreshPromotions();
		MemoryLoadedObjects.RefreshGeneralOEData();
		MemoryLoadedObjects.RefreshItemImages();
		SettingsHelper.DeliveryFeeSettings.TransferOldDeliveryToNewDeliverySettings();
		MemoryLoadedData.ListOfItemsInGroupMemory = gClass.ItemsInGroups.Where((ItemsInGroup a) => a.Item.isDeleted == false && a.Item.Active == true).ToList();
		Setting setting2 = gClass.Settings.Where((Setting x) => x.Key == "chit_print_server").FirstOrDefault();
		if (setting2 != null)
		{
			Setting setting3 = gClass.Settings.Where((Setting x) => x.Key == "is_sql_dependency").FirstOrDefault();
			if (string.IsNullOrEmpty(setting2.Value))
			{
				setting2.Value = Environment.MachineName;
				Helper.SubmitChangesWithCatch(gClass);
			}
			if (setting2.Value == Environment.MachineName)
			{
				if (setting3.Value == "ON")
				{
					method_22();
				}
				else
				{
					timer_4.Enabled = true;
					timer_9.Enabled = false;
				}
			}
			else
			{
				timer_4.Enabled = false;
			}
			if (setting2.Value.ToUpper() == "NONE")
			{
				timer_5.Enabled = true;
			}
			else
			{
				timer_5.Enabled = false;
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
		gClass.Refresh(RefreshMode.OverwriteCurrentValues);
		if (terminal != null)
		{
			if (string.IsNullOrEmpty(terminal.DefaultOrderTypes))
			{
				terminal.DefaultOrderTypes = "Dine In,To-Go,Pick-Up,Delivery";
			}
			terminal.AppRestartRequired = false;
			terminal.SettingsRefreshedRequired = false;
			terminal.ItemsInGroupsRefreshRequired = false;
			Helper.SubmitChangesWithCatch(gClass);
			MemoryLoadedObjects.DefaultOrderTypes = terminal.DefaultOrderTypes;
			MemoryLoadedObjects.showPrintError = terminal.ShowPrintError;
		}
		timer_3.Enabled = true;
		MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
		MemoryLoadedObjects.OptionScreen = new frmOptions();
		if (SettingsHelper.GetSettingValueByKey("patt_server").ToUpper() == Environment.MachineName.ToUpper())
		{
			if (SettingsHelper.GetSettingValueByKey("use_payment_processor").ToUpper() == "ON")
			{
				method_27(bool_5: true);
			}
			if (SettingsHelper.GetSettingValueByKey("enable_http_listener") == "ON")
			{
				http_listener = new HttpListener();
				new HTTPHelper().method_0(http_listener);
			}
		}
		if (SyncMethods.CheckInternet())
		{
			method_21();
		}
		if (AppSettings.AppVersion == "1.12.0" && gClass.CustomTipSharings.Count() == 0)
		{
			CustomTipSharing entity = new CustomTipSharing
			{
				TipName = "Kitchen",
				Percentage = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("tip_kitchen"))
			};
			gClass.CustomTipSharings.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
			CustomTipSharing entity2 = new CustomTipSharing
			{
				TipName = "Breakage",
				Percentage = Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("tip_breakage"))
			};
			gClass.CustomTipSharings.InsertOnSubmit(entity2);
			Helper.SubmitChangesWithCatch(gClass);
		}
		if (SettingsHelper.GetSettingValueByKey("card_transaction_fee_json") == "[]")
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("card_transaction_fee");
			decimal amount = ((!string.IsNullOrEmpty(settingValueByKey)) ? Convert.ToDecimal(settingValueByKey) : 0m);
			SettingsHelper.SetTransactionFeeSetting("Debit", '%', amount);
			SettingsHelper.SetTransactionFeeSetting("Credit", '%', amount);
		}
	}

	private void method_21()
	{
		GClass6 gClass = new GClass6();
		UsefulTipsPostModel usefulTipsPostModel = new UsefulTipsPostModel();
		usefulTipsPostModel.ExistingTips = gClass.UsefulTips.Select((UsefulTip a) => a.Id).ToList();
		UsefulTipsResponseModel usefulTipsResponseModel = JsonConvert.DeserializeObject<UsefulTipsResponseModel>(SyncMethods.SyncTaskWithResponseData(usefulTipsPostModel, "/api/UsefulTips"));
		if (usefulTipsResponseModel.code != 200 || usefulTipsResponseModel.UsefulTips.Count <= 0)
		{
			return;
		}
		foreach (UsefulTipsResponseDataModel usefulTip in usefulTipsResponseModel.UsefulTips)
		{
			UsefulTip entity = new UsefulTip
			{
				Id = usefulTip.Id,
				Description = usefulTip.Description
			};
			gClass.UsefulTips.InsertOnSubmit(entity);
			Helper.SubmitChangesWithCatch(gClass);
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		GC.Collect();
		Process currentProcess = Process.GetCurrentProcess();
		long num = currentProcess.PrivateMemorySize64 / 1024L / 1024L;
		long num2 = GetGuiResources(currentProcess.Handle, 0);
		if (num > 2048L || num2 > 2000L)
		{
			frmMessageBox frmMessageBox2 = new frmMessageBox("Hippos is running a bit sluggish and needs to be restarted.  Would you like to restart?", "High Memory Usage", CustomMessageBoxButtons.YesNo);
			frmMessageBox2.TopMost = true;
			if (DialogResult.Yes == frmMessageBox2.ShowDialog())
			{
				Exception error = new Exception("Hippos has been restarted due to high memory consumption.  " + num + " MB used. " + num2 + " GDI consumed. Failed at screen " + ErrorHelper.ScreenLeakErrorMessage + " at application " + MiscHelper.getRegistryValue("Software\\DigitalCraft\\HipPOS", "ProductKey"));
				NotificationMethods.sendCrash(AppSettings.AppVersion + " Build " + AppSettings.Build, Environment.OSVersion.VersionString, error);
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	private void timer_3_Tick(object sender, EventArgs e)
	{
		if (bool_3)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
		if (terminal == null)
		{
			return;
		}
		if (terminal.AppRestartRequired)
		{
			bool_3 = true;
			DialogResult dialogResult = new frmMessageBox("Software settings have been changed by admin, Hippos will need to be restarted.", "Restart Required").ShowDialog();
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
				bool_3 = false;
			}
		}
		if (terminal.SettingsRefreshedRequired)
		{
			terminal.SettingsRefreshedRequired = false;
			Helper.SubmitChangesWithCatch(gClass);
			SettingsHelper.SetAllSettings();
		}
	}

	private void method_22()
	{
		method_23();
		if (!Helper.GetConnectionString().Contains("AttachDbFilename"))
		{
			method_24();
			timer_9.Enabled = true;
		}
		else
		{
			timer_4.Enabled = true;
			timer_9.Enabled = false;
		}
	}

	private void timer_4_Tick(object sender, EventArgs e)
	{
		method_23();
	}

	private void method_23()
	{
		string printerName = "";
		GClass6 gClass = new GClass6();
		try
		{
			_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass43_0();
			List<ChitPrintQueue> list = (from x in gClass.ChitPrintQueues
				where !MemoryLoadedData.LastChitPrintQueueIds.Contains(x.Id) && x.Printed == false
				select x into a
				orderby a.OrderNumber, a.Id
				select a).ToList();
			MemoryLoadedData.LastChitPrintQueueIds.AddRange(list.Select((ChitPrintQueue a) => a.Id).ToList());
			MemoryLoadedData.LastChitPrintQueueIds = MemoryLoadedData.LastChitPrintQueueIds.OrderByDescending((int a) => a).Take(10).ToList();
			List<string> list2 = list.Select((ChitPrintQueue x) => x.OrderNumber).ToList();
			CS_0024_003C_003E8__locals1.orderNumberToCheck = new List<string>();
			foreach (string item in list2)
			{
				CS_0024_003C_003E8__locals1.orderNumberToCheck.AddRange(item.Split(','));
			}
			CS_0024_003C_003E8__locals1.orderNumberToCheck = CS_0024_003C_003E8__locals1.orderNumberToCheck.Distinct().ToList();
			List<Order> source = gClass.Orders.Where((Order x) => CS_0024_003C_003E8__locals1.orderNumberToCheck.Contains(x.OrderNumber)).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			LogHelper.WriteLog("ChitPrintQueueTimer Started printing.", LogTypes.print_log);
			using List<ChitPrintQueue>.Enumerator enumerator2 = list.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass43_1 _003C_003Ec__DisplayClass43_ = new _003C_003Ec__DisplayClass43_1();
				_003C_003Ec__DisplayClass43_.queue = enumerator2.Current;
				_003C_003Ec__DisplayClass43_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_2();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass43_;
				CS_0024_003C_003E8__locals0.station = MemoryLoadedObjects.all_stations.Where((Station a) => a.StationID == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.StationID).FirstOrDefault();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.station.PrinterName))
				{
					printerName = CS_0024_003C_003E8__locals0.station.PrinterName;
				}
				LogHelper.WriteLog("Order number " + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.OrderNumber + " on station " + CS_0024_003C_003E8__locals0.station.StationName + " chit STARTED printing", LogTypes.print_log);
				new PrintHelper(printerName).PrintString(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.TextString, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.FontSize, CS_0024_003C_003E8__locals0.station);
				bool flag = ((!CS_0024_003C_003E8__locals0.station.SendToStation) ? true : false);
				foreach (Order item2 in source.Where((Order x) => x.StationID != null && x.StationID != "" && x.StationID.Contains(CS_0024_003C_003E8__locals0.station.StationID.ToString()) && CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.OrderNumber.Contains(x.OrderNumber)))
				{
					string[] array = item2.StationID.Split(',');
					string[] array2 = (string.IsNullOrEmpty(item2.StationPrinted) ? new string[0] : item2.StationPrinted.Split(','));
					if (array2.Length == 0)
					{
						item2.StationPrinted = CS_0024_003C_003E8__locals0.station.StationID.ToString();
					}
					else if (!array2.Contains(CS_0024_003C_003E8__locals0.station.StationID.ToString()))
					{
						item2.StationPrinted = item2.StationPrinted + ((!string.IsNullOrEmpty(item2.StationPrinted)) ? "," : string.Empty) + CS_0024_003C_003E8__locals0.station.StationID;
					}
					if (flag)
					{
						item2.StationMade = StationMethods.AddStationIdFromStationIds(item2.StationMade, CS_0024_003C_003E8__locals0.station.StationID.ToString());
					}
					if (array.Length == array2.Length)
					{
						item2.PrintedInKitchen = true;
					}
					if (!string.IsNullOrEmpty(item2.StationID) && !string.IsNullOrEmpty(item2.StationMade) && item2.StationMade.Split(',').Count() == item2.StationID.Split(',').Count())
					{
						item2.DateFilled = DateTime.Now;
					}
				}
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.Printed = true;
				Helper.SubmitChangesWithCatch(gClass);
				LogHelper.WriteLog("Order number " + CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.queue.OrderNumber + " on station " + CS_0024_003C_003E8__locals0.station.StationName + " chit FINISHED printing", LogTypes.print_log);
				Thread.Sleep(500);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog("ChitPrintQueueTimer crashed: " + ex.Message + "\n" + ex.StackTrace, LogTypes.print_log);
		}
	}

	private void method_24()
	{
		SqlDependency.Start(Helper.GetConnectionString());
		method_25();
	}

	private void method_25()
	{
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		using SqlCommand sqlCommand = new SqlCommand("SELECT [Id],[TextString] ,[FontSize],[StationID],[DateCreated],[Printed],[OrderNumber]  FROM [dbo].[ChitPrintQueues]", sqlConnection);
		new SqlDependency(sqlCommand).OnChange += method_26;
		sqlConnection.Open();
		using (sqlCommand.ExecuteReader())
		{
		}
		sqlConnection.Close();
	}

	private void method_26(object sender, SqlNotificationEventArgs e)
	{
		method_25();
		if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Insert)
		{
			SyncMethods.WriteToSyncLog("SQL Dependency Chit Print Queue Table", "OnlineOrderSync_");
			method_23();
		}
	}

	private void timer_9_Tick(object sender, EventArgs e)
	{
		CheckDependency(isClicked: false);
	}

	public void CheckDependency(bool isClicked)
	{
		if (SqlDependency.Start(Helper.GetConnectionString()) || isClicked)
		{
			Setting setting = new GClass6().Settings.Where((Setting x) => x.Key == "chit_print_server").FirstOrDefault();
			if (setting != null && setting.Value == Environment.MachineName)
			{
				method_22();
			}
		}
	}

	private void method_27(bool bool_5 = false)
	{
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.serverCertificate = null;
		try
		{
			if (bool_5)
			{
				CS_0024_003C_003E8__locals0.serverCertificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + "\\tmcpayattable.p12", "tmc");
			}
		}
		catch
		{
			new frmMessageBox("The Pay At The Table SSL certificate is missing.  Please contact Hippos.", "SSL Certicate Missing", CustomMessageBoxButtons.Ok).ShowDialog();
			Application.Exit();
		}
		listener = new TcpListener(IPAddress.Any, 4767);
		listener.Stop();
		listener.Start();
		new Thread((ThreadStart)delegate
		{
			while (Application.OpenForms.Count > 0)
			{
				TcpClient tcpClient = new TcpClient();
				try
				{
					tcpClient = CS_0024_003C_003E8__locals0._003C_003E4__this.listener.AcceptTcpClient();
					new TCPHelper().ProcessClient(tcpClient, CS_0024_003C_003E8__locals0.serverCertificate);
				}
				catch
				{
					tcpClient.Close();
				}
			}
		}).Start();
	}

	private void method_28()
	{
		if (SyncMethods.CheckIfMultipleLocation(new CheckForUpdatesPostData
		{
			edition = "restaurant",
			current_version = AppSettings.AppVersion,
			product_serial_key = MemoryLoadedObjects.this_terminal.ProductKey
		}).code == 200)
		{
			MemoryLoadedObjects.isMultipleLocation = true;
		}
	}

	private void timer_5_Tick(object sender, EventArgs e)
	{
		try
		{
			if (bool_4)
			{
				return;
			}
			int num = MemoryLoadedObjects.ListChitsToPrint.Count();
			if (num > 0)
			{
				_003C_003Ec__DisplayClass53_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass53_0();
				LogHelper.WriteLog("ChitPrintTimer has " + num + " print jobs.", LogTypes.print_log);
				short_0 = 0;
				if (SettingsHelper.GetSettingValueByKey("fulfillment_threshold") == "ON")
				{
					Math.Abs((int)(Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("fulfillment_threshold_time")) * 60m));
				}
				bool_4 = true;
				int num2 = 1;
				CS_0024_003C_003E8__locals0.tempVar = MemoryLoadedObjects.ListChitsToPrint.Take(5).ToList();
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.orderNums = new List<string>();
				foreach (ChitPrintInfo item in CS_0024_003C_003E8__locals0.tempVar)
				{
					CS_0024_003C_003E8__locals0.orderNums.Add(item.OrderNumber);
					if ((item.RelatedOrderNumbers != null) & (item.RelatedOrderNumbers.Count > 0))
					{
						CS_0024_003C_003E8__locals0.orderNums.AddRange(item.RelatedOrderNumbers);
					}
				}
				CS_0024_003C_003E8__locals0.orderNums = CS_0024_003C_003E8__locals0.orderNums.Distinct().ToList();
				List<Order> source = gClass.Orders.Where((Order x) => CS_0024_003C_003E8__locals0.orderNums.Contains(x.OrderNumber)).ToList();
				using (List<ChitPrintInfo>.Enumerator enumerator = CS_0024_003C_003E8__locals0.tempVar.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass53_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass53_1();
						CS_0024_003C_003E8__locals1.chitToPrint = enumerator.Current;
						LogHelper.WriteLog("ChitPrintTimer printing job " + num2 + " of " + num + ", printer=" + CS_0024_003C_003E8__locals1.chitToPrint.PrinterName + ".", LogTypes.print_log);
						new PrintHelper(CS_0024_003C_003E8__locals1.chitToPrint.PrinterName).PrintString(CS_0024_003C_003E8__locals1.chitToPrint.Message, CS_0024_003C_003E8__locals1.chitToPrint.FontSize, CS_0024_003C_003E8__locals1.chitToPrint.station);
						foreach (Order item2 in (from a in source.Where((Order a) => CS_0024_003C_003E8__locals1.chitToPrint.orderIds.Contains(a.OrderId)).ToList()
							where a.OrderNumber == CS_0024_003C_003E8__locals1.chitToPrint.OrderNumber || CS_0024_003C_003E8__locals1.chitToPrint.RelatedOrderNumbers.Contains(a.OrderNumber)
							select a).ToList())
						{
							string[] array = item2.StationID.Split(',');
							if (string.IsNullOrEmpty(item2.StationPrinted))
							{
								item2.StationPrinted = CS_0024_003C_003E8__locals1.chitToPrint.station.StationID.ToString();
							}
							else if (!item2.StationPrinted.Split(',').Contains(CS_0024_003C_003E8__locals1.chitToPrint.station.StationID.ToString()))
							{
								item2.StationPrinted = item2.StationPrinted + ((!string.IsNullOrEmpty(item2.StationPrinted)) ? "," : string.Empty) + CS_0024_003C_003E8__locals1.chitToPrint.station.StationID;
							}
							if (string.IsNullOrEmpty(item2.StationPrinted) && array.Length == item2.StationPrinted.Split(',').Length)
							{
								item2.PrintedInKitchen = true;
							}
							if (((!CS_0024_003C_003E8__locals1.chitToPrint.station.SendToStation) ? true : false) && item2.StationID.Contains(CS_0024_003C_003E8__locals1.chitToPrint.station.StationID.ToString()))
							{
								item2.StationMade = StationMethods.AddStationIdFromStationIds(item2.StationMade, CS_0024_003C_003E8__locals1.chitToPrint.station.StationID.ToString());
							}
						}
						Helper.SubmitChangesWithCatch(gClass);
						LogHelper.WriteLog("ChitPrintTimer completed job " + num2 + " of " + num + ".", LogTypes.print_log);
						num2++;
					}
				}
				MemoryLoadedObjects.ListChitsToPrint.RemoveAll((ChitPrintInfo a) => CS_0024_003C_003E8__locals0.tempVar.Contains(a));
				LogHelper.WriteLog("ChitPrintTimer cleared queue.", LogTypes.print_log);
				bool_4 = false;
			}
			else
			{
				short_0++;
				if (short_0 >= 10)
				{
					LogHelper.WriteLog("ChitPrintTimer has nothing to do.", LogTypes.print_log);
					short_0 = 0;
				}
				bool_4 = false;
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteLog("ChitPrintTimer crashed: " + ex.Message + "\n" + ex.StackTrace, LogTypes.print_log);
			bool_4 = false;
		}
	}

	private void timer_6_Tick(object sender, EventArgs e)
	{
		LogHelper.WriteLog("ChitPrintSelfCheck: Started.", LogTypes.print_log);
		if (!MemoryLoadedObjects.chitPrintSelfCheck_running)
		{
			try
			{
				_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass54_0();
				bool flag = false;
				if (SettingsHelper.GetSettingValueByKey("group_chits_per_table") == "ON" && SettingsHelper.GetSettingValueByKey("restaurant_mode") == "Dine In")
				{
					flag = true;
				}
				CS_0024_003C_003E8__locals0.thresholdTimeInMinutes = 0;
				if (SettingsHelper.GetSettingValueByKey("fulfillment_threshold") == "ON")
				{
					CS_0024_003C_003E8__locals0.thresholdTimeInMinutes = Math.Abs((int)(Convert.ToDecimal(SettingsHelper.GetSettingValueByKey("fulfillment_threshold_time")) * 60m));
				}
				LogHelper.WriteLog("ChitPrintSelfCheck: Running.", LogTypes.print_log);
				MemoryLoadedObjects.chitPrintSelfCheck_running = true;
				GClass6 gClass = new GClass6();
				CS_0024_003C_003E8__locals0.terminalID = HelperMethods.GetCurrentTerminalID();
				if (CS_0024_003C_003E8__locals0.terminalID == 0)
				{
					return;
				}
				CS_0024_003C_003E8__locals0.chitsToPrint = new List<string>();
				if (MemoryLoadedObjects.ListChitsToPrint != null && MemoryLoadedObjects.ListChitsToPrint.Count() > 0)
				{
					CS_0024_003C_003E8__locals0.chitsToPrint = MemoryLoadedObjects.ListChitsToPrint.Select((ChitPrintInfo y) => y.OrderNumber).ToList();
				}
				List<Order> first = gClass.Orders.Where((Order x) => x.DateCreated > DateTime.Now.AddDays(-1.0) && x.DateCleared.HasValue == false && x.DateCreated.Value > DateTime.Now.AddMinutes(-(20 + x.OrderOnHoldTime))).ToList();
				List<Order> second = gClass.Orders.Where((Order x) => x.FulfillmentAt.HasValue && x.FulfillmentAt <= DateTime.Now.AddMinutes(20 + CS_0024_003C_003E8__locals0.thresholdTimeInMinutes) && x.FulfillmentAt > DateTime.Now).ToList();
				List<Order> source = first.Union(second).ToList();
				source = source.Where((Order x) => !CS_0024_003C_003E8__locals0.chitsToPrint.Contains(x.OrderNumber) && (x.OrderOnHoldTime == 0 || x.OrderOnHoldTime == -1 || (x.OrderOnHoldTime != 0 && x.DateCreated.Value <= DateTime.Now.AddMinutes(-x.OrderOnHoldTime))) && ((x.OrderType != OrderTypes.PickUpOnline && x.OrderType != OrderTypes.DeliveryOnline && x.DateCreated.Value <= DateTime.Now.AddMinutes(-2.0)) || ((x.OrderType == OrderTypes.PickUpOnline || x.OrderType == OrderTypes.DeliveryOnline) && x.LastSynced.HasValue && x.LastSynced.Value <= DateTime.Now.AddMinutes(-4.0))) && x.Qty >= 1m && !x.ShareItemID.HasValue && (x.FlagID == 0 || x.FlagID != 5) && x.StationID != null && x.StationID != string.Empty && (x.StationPrinted == null || x.StationPrinted == string.Empty) && x.CreatedByTerminalID.HasValue && x.CreatedByTerminalID == CS_0024_003C_003E8__locals0.terminalID).ToList();
				if (SettingsHelper.GetSettingValueByKey("print_chit_change_cancel") == "OFF")
				{
					source = source.Where((Order x) => x.FlagID != 4 && x.FlagID != 3).ToList();
				}
				int count = source.Count;
				if (count > 0)
				{
					LogHelper.WriteLog("ChitPrintSelfCheck: " + count + " order items to print.", LogTypes.print_log);
					OrderHelper orderHelper = new OrderHelper();
					List<Order> list = new List<Order>();
					using (List<Order>.Enumerator enumerator = source.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass54_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass54_1();
							CS_0024_003C_003E8__locals1.order = enumerator.Current;
							string[] array = CS_0024_003C_003E8__locals1.order.StationID.Split(',');
							string[] source2 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.order.StationPrinted) ? new string[0] : CS_0024_003C_003E8__locals1.order.StationPrinted.Split(','));
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (source2.Contains(text))
								{
									continue;
								}
								Order order = list.Where((Order x) => x.OrderNumber == CS_0024_003C_003E8__locals1.order.OrderNumber).FirstOrDefault();
								if (order != null)
								{
									order.StationID.Split(',');
									if (!order.StationID.Split(',').Contains(text))
									{
										Order order2 = order;
										order2.StationID = order2.StationID + ((!string.IsNullOrEmpty(order.StationID)) ? "," : string.Empty) + text;
									}
								}
								else
								{
									order = new Order();
									order.OrderNumber = CS_0024_003C_003E8__locals1.order.OrderNumber;
									order.OrderType = CS_0024_003C_003E8__locals1.order.OrderType;
									order.CustomerInfoName = CS_0024_003C_003E8__locals1.order.CustomerInfoName;
									order.Customer = CS_0024_003C_003E8__locals1.order.Customer;
									Order order3 = order;
									order3.StationID = order3.StationID + ((!string.IsNullOrEmpty(order.StationID)) ? "," : string.Empty) + text;
									list.Add(order);
								}
								CS_0024_003C_003E8__locals1.order.PrintedInKitchen = false;
							}
						}
					}
					Helper.SubmitChangesWithCatch(gClass);
					List<string> list2 = new List<string>();
					foreach (Order item in list)
					{
						if (flag && item.OrderType == OrderTypes.DineIn)
						{
							if (list2.Contains(item.Customer))
							{
								continue;
							}
							list2.Add(item.Customer);
						}
						LogHelper.WriteLog("ChitPrintSelfCheck: Triggering self-check print for " + item.OrderNumber + " order.", LogTypes.print_log);
						string[] array2 = item.StationID.Split(',');
						foreach (string value in array2)
						{
							orderHelper.PrintToStation(item.OrderNumber, item.OrderType, item.CustomerInfoName + " - " + item.Customer, Convert.ToInt16(value), "SYSTEM", isOrderMade: false, reprint: false, printOnlyOne: false, item.Customer);
						}
					}
					Helper.SubmitChangesWithCatch(gClass);
				}
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
			}
			catch (Exception ex)
			{
				LogHelper.WriteLog("ChitPrintSelfCheck crashed: " + ex.Message + "\n" + ex.StackTrace, LogTypes.print_log);
				MemoryLoadedObjects.chitPrintSelfCheck_running = false;
			}
		}
		LogHelper.WriteLog("ChitPrintSelfCheck: Ended.", LogTypes.print_log);
	}

	private void timer_7_Tick(object sender, EventArgs e)
	{
		if (DateTime.Now.TimeOfDay >= new TimeSpan(4, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(6, 0, 0))
		{
			method_6();
		}
		else if (DateTime.Now.TimeOfDay >= new TimeSpan(15, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(17, 0, 0))
		{
			method_6();
		}
		if (DateTime.Now.TimeOfDay >= new TimeSpan(4, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(6, 0, 0))
		{
			method_6();
		}
		else if (DateTime.Now.TimeOfDay >= new TimeSpan(15, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(17, 0, 0))
		{
			method_6();
		}
	}

	private void method_29()
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

	private void timer_8_Tick(object sender, EventArgs e)
	{
		method_14(bool_5: true);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.frmLoader));
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_1 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.lblVersion = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.progressBar1 = new Telerik.WinControls.UI.RadProgressBar();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.timer_2 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_3 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_4 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_5 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_6 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_7 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_8 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_9 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.progressBar1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.timer_0.Enabled = true;
		this.timer_0.Interval = 500;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.timer_1.Interval = 2000;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.lblVersion.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.lblVersion, "lblVersion");
		this.lblVersion.Name = "lblVersion";
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.progressBar1);
		this.panel1.Controls.Add(this.pictureBox2);
		this.panel1.Controls.Add(this.lblVersion);
		resources.ApplyResources(this.panel1, "panel1");
		this.panel1.Name = "panel1";
		resources.ApplyResources(this.progressBar1, "progressBar1");
		this.progressBar1.ForeColor = System.Drawing.Color.White;
		this.progressBar1.Name = "progressBar1";
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).Text = resources.GetString("resource.Text");
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderColor = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderColor2 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderColor3 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderColor4 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderInnerColor = System.Drawing.Color.FromArgb(21, 23, 33);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BorderBottomColor = System.Drawing.Color.FromArgb(0, 0, 0);
		((Telerik.WinControls.UI.RadProgressBarElement)this.progressBar1.GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		((Telerik.WinControls.UI.ProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(0)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
		((Telerik.WinControls.UI.UpperProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(1)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.UpperProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(1)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.UpperProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(1)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.UpperProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(1)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.UpperProgressIndicatorElement)this.progressBar1.GetChildAt(0).GetChildAt(1)).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		this.timer_2.Interval = 300000;
		this.timer_2.Tick += new System.EventHandler(timer_2_Tick);
		this.timer_3.Interval = 180000;
		this.timer_3.Tick += new System.EventHandler(timer_3_Tick);
		this.timer_4.Interval = 5000;
		this.timer_4.Tick += new System.EventHandler(timer_4_Tick);
		this.timer_5.Interval = 3500;
		this.timer_5.Tick += new System.EventHandler(timer_5_Tick);
		this.timer_6.Interval = 30000;
		this.timer_6.Tick += new System.EventHandler(timer_6_Tick);
		this.timer_7.Enabled = true;
		this.timer_7.Interval = 3600000;
		this.timer_7.Tick += new System.EventHandler(timer_7_Tick);
		this.timer_8.Enabled = true;
		this.timer_8.Interval = 3600000;
		this.timer_8.Tick += new System.EventHandler(timer_8_Tick);
		this.timer_9.Interval = 60000;
		this.timer_9.Tick += new System.EventHandler(timer_9_Tick);
		resources.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLoader";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.Load += new System.EventHandler(YrfFkRwrjyZ);
		this.panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.progressBar1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
	}
}
