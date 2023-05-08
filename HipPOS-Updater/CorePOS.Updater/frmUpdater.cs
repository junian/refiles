using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Updater.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CorePOS.Updater;

public class frmUpdater : Form
{
	public class CheckForUpdatesPostData
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private byte byte_0;

		public string edition
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

		public string current_version
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string product_serial_key
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public byte build_type
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}

		public CheckForUpdatesPostData()
		{
			Class13.FLcy5UmzUUEfT();
			base._002Ector();
		}
	}

	public class StatusCodeResponse
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_0;

		public int code
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public string message
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

		public StatusCodeResponse()
		{
			Class13.FLcy5UmzUUEfT();
			base._002Ector();
		}
	}

	private int int_0;

	private int int_1;

	private bool bool_0;

	private string string_0;

	private int int_2;

	private int int_3;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private IContainer icontainer_0;

	private System.Windows.Forms.Timer timer_0;

	private System.Windows.Forms.Timer timer_1;

	private Panel panel1;

	private PictureBox pictureBox2;

	private Label lblVersion;

	private ProgressBar progressBar1;

	private Label lblProgress;

	public frmUpdater()
	{
		Class13.FLcy5UmzUUEfT();
		int_0 = 1;
		int_1 = 44;
		string_0 = "1.12.4";
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_4 = "https://www.hipposhq.com/downloads/restaurant/required/";
		base._002Ector();
		InitializeComponent();
		progressBar1.Maximum = 100;
		Common.appVersion = string_0;
		string_1 = "https://www.hipposhq.com/downloads/restaurant/updates/" + Common.appVersion + "/release/";
		CheckForUpdatesPostData checkForUpdatesPostData = new CheckForUpdatesPostData
		{
			edition = "restaurant",
			current_version = Common.appVersion,
			product_serial_key = new DBHelper().GetMachineProductKey()
		};
		if (string.IsNullOrEmpty(checkForUpdatesPostData.product_serial_key))
		{
			checkForUpdatesPostData.product_serial_key = getRegistryValue("Software\\DigitalCraft\\HipPOS", "ProductKey");
		}
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "pksubeval.key"))
		{
			if (MessageBox.Show(this, "Do you want the production release version?", "Version", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string_1 = "https://www.hipposhq.com/downloads/restaurant/updates/" + Common.appVersion + "/release/";
				checkForUpdatesPostData.build_type = 0;
			}
			else if (MessageBox.Show(this, "Do you want the staging version?", "Version", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string_1 = "https://www.hipposhq.com/downloads/restaurant/updates/" + Common.appVersion + "/staging/";
				checkForUpdatesPostData.build_type = 2;
			}
			else
			{
				string_1 = "https://www.hipposhq.com/downloads/restaurant/updates/" + Common.appVersion + "/dev/";
				checkForUpdatesPostData.build_type = 2;
			}
		}
		StatusCodeResponse updateUrl = GetUpdateUrl(checkForUpdatesPostData);
		if (updateUrl.code == 200 && !string.IsNullOrEmpty(updateUrl.message))
		{
			string_1 = updateUrl.message;
		}
		if (!method_8(string_1))
		{
			MessageBox.Show("Update path doesnt exist. Please contact Hippos Admin.", "Update Failed.");
			Application.Exit();
		}
		timer_0.Enabled = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		int int_ = int_1 - 4;
		if (bool_0)
		{
			return;
		}
		if (int_0 <= int_1)
		{
			switch (int_0)
			{
			case 1:
			{
				FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Hippos.exe");
				if (fileInfo.Exists && method_15(fileInfo))
				{
					timer_0.Enabled = false;
					for (int i = 0; i < 3; i++)
					{
						if (Process.GetProcessesByName("HipPOS").Length != 0)
						{
							Process[] processesByName = Process.GetProcessesByName("HipPOS");
							foreach (Process obj in processesByName)
							{
								obj.Kill();
								Thread.Sleep(500);
								if (obj.HasExited)
								{
									timer_0.Enabled = true;
									i = 4;
								}
							}
						}
						else
						{
							timer_0.Enabled = true;
							i = 4;
						}
					}
					if (!timer_0.Enabled)
					{
						Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Hippos-Updater.exe");
						Application.Exit();
					}
				}
				method_0();
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "CorePOS.Business.pdb", AppDomain.CurrentDomain.BaseDirectory + "CorePOS.Business.pdb");
				break;
			}
			case 2:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "CorePOS.Business.dll", AppDomain.CurrentDomain.BaseDirectory + "CorePOS.Business.dll");
				break;
			case 3:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "CorePOS.Data.pdb", AppDomain.CurrentDomain.BaseDirectory + "CorePOS.Data.pdb");
				break;
			case 4:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "CorePOS.Data.dll", AppDomain.CurrentDomain.BaseDirectory + "CorePOS.Data.dll");
				break;
			case 5:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "HipPOS.pdb", AppDomain.CurrentDomain.BaseDirectory + "HipPOS.pdb");
				break;
			case 6:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "HipPOS.exe", AppDomain.CurrentDomain.BaseDirectory + "HipPOS.exe");
				break;
			case 7:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "Hippos-Sync.exe", AppDomain.CurrentDomain.BaseDirectory + "Hippos-Sync.exe");
				break;
			case 8:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "Hippos-Sync.pdb", AppDomain.CurrentDomain.BaseDirectory + "Hippos-Sync.pdb");
				break;
			case 9:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "HipPOS-EULA.txt", AppDomain.CurrentDomain.BaseDirectory + "HipPOS-EULA.txt");
				break;
			case 10:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "CrashGrab.dll", AppDomain.CurrentDomain.BaseDirectory + "CrashGrab.dll");
				break;
			case 11:
				method_1("Telerik.WinControls.dll", int_);
				break;
			case 12:
				method_1("Telerik.WinControls.UI.dll", int_);
				break;
			case 13:
				method_1("Telerik.WinControls.UI.xml", int_);
				break;
			case 14:
				method_1("Telerik.WinControls.xml", int_);
				break;
			case 15:
				method_1("TelerikCommon.dll", int_);
				break;
			case 16:
				method_1("Telerik.WinControls.Themes.Windows8.dll", int_);
				break;
			case 17:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "UnitsNet.dll", AppDomain.CurrentDomain.BaseDirectory + "UnitsNet.dll");
				break;
			case 18:
				method_2("en-US", int_);
				break;
			case 19:
				method_2("fr-CA", int_);
				break;
			case 20:
				method_2("es-US", int_);
				break;
			case 21:
				bool_0 = true;
				lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_ + ")";
				method_9(string_1 + "ChangeLog.txt", AppDomain.CurrentDomain.BaseDirectory + "ChangeLog.txt");
				break;
			case 22:
				method_1("Microsoft.WindowsAzure.Configuration.dll", int_);
				break;
			case 23:
				method_1("Microsoft.WindowsAzure.Storage.DataMovement.dll", int_);
				break;
			case 24:
				method_1("Microsoft.WindowsAzure.Storage.DataMovement.xml", int_);
				break;
			case 25:
				method_1("Microsoft.WindowsAzure.Storage.dll", int_);
				break;
			case 26:
				method_1("Microsoft.WindowsAzure.Storage.xml", int_);
				break;
			case 27:
				bool_0 = true;
				lblProgress.Text = "Downloading && Installing (" + int_0 + " of " + int_ + ")";
				if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "lib"))
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "lib");
				}
				if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "lib\\vlclib"))
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "lib\\vlclib");
				}
				if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "lib\\vlclib\\plugins"))
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "lib\\vlclib\\plugins");
				}
				method_4(string_4, AppDomain.CurrentDomain.BaseDirectory);
				break;
			case 28:
				method_1("CloverConnector.dll", int_, bool_1: true);
				break;
			case 29:
				method_1("CloverConnector.xml", int_, bool_1: true);
				break;
			case 30:
				method_1("CloverWindowsSDK.dll", int_, bool_1: true);
				break;
			case 31:
				method_1("CloverWindowsTransport.dll", int_, bool_1: true);
				break;
			case 32:
				method_3("LibUsbDotNet.dll");
				method_3("LibUsbDotNet.xml");
				method_1("LibUsbDotNet.LibUsbDotNet.dll", int_, bool_1: true);
				break;
			case 33:
				method_1("WebSocket4Net.dll", int_, bool_1: true);
				break;
			case 34:
				method_1("SuperSocket.ClientEngine.dll", int_, bool_1: true);
				break;
			case 35:
				method_1("Traysoft.AddTapi.dll", int_);
				break;
			case 36:
				method_1("Traysoft.AddTapi.XML", int_);
				break;
			case 37:
				method_1("Traysoft.Internal.dll", int_);
				break;
			case 38:
				method_1("DeviceId.dll", int_);
				break;
			case 39:
				method_1("DeviceId.xml", int_);
				break;
			case 40:
				bool_0 = true;
				int_0++;
				bool_0 = false;
				break;
			case 41:
				method_7(bool_1: false);
				break;
			case 42:
				method_7(bool_1: true);
				break;
			case 43:
				bool_0 = true;
				method_16();
				progressBar1.Value = 100;
				int_0++;
				lblProgress.Text = Resources.Update_Complete;
				Thread.Sleep(1000);
				Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Hippos.exe");
				bool_0 = false;
				break;
			case 44:
				Application.Exit();
				break;
			}
		}
		else
		{
			System.Windows.Forms.Timer timer = timer_0;
			timer_1.Enabled = false;
			timer.Enabled = false;
			Application.Exit();
		}
	}

	private void method_0()
	{
		int num = 0;
		while (true)
		{
			if (num < 3)
			{
				ServiceController serviceController = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Hippos Sync Service");
				if (serviceController != null)
				{
					if (serviceController.Status == ServiceControllerStatus.Running)
					{
						serviceController.Stop();
						Thread.Sleep(2000);
					}
					else if (serviceController.Status == ServiceControllerStatus.Stopped)
					{
						break;
					}
					num++;
					continue;
				}
				break;
			}
			ServiceController serviceController2 = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Hippos Sync Service");
			if (serviceController2 != null && serviceController2.Status == ServiceControllerStatus.Running)
			{
				MessageBox.Show("Unable to update Hippos. Please restart your computer and try again.", "Update Failed.");
				Application.Exit();
			}
			break;
		}
	}

	private void method_1(string string_5, int int_4 = 0, bool bool_1 = false)
	{
		bool_0 = true;
		if (bool_1)
		{
			File.Delete(AppDomain.CurrentDomain.BaseDirectory + string_5);
			Thread.Sleep(2000);
		}
		lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_4 + ")";
		if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + string_5))
		{
			method_9(string_4 + string_5, AppDomain.CurrentDomain.BaseDirectory + string_5);
			return;
		}
		bool_0 = false;
		int_0++;
	}

	private void method_2(string string_5, int int_4 = 0)
	{
		bool_0 = true;
		lblProgress.Text = Resources.Downloading_Installing + int_0 + Resources._of + int_4 + ")";
		if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + string_5))
		{
			Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + string_5);
		}
		method_10(string_1 + "/" + string_5 + "/", AppDomain.CurrentDomain.BaseDirectory + string_5 + "\\");
	}

	private void method_3(string string_5)
	{
		if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + string_5))
		{
			File.Delete(AppDomain.CurrentDomain.BaseDirectory + string_5);
			Thread.Sleep(2000);
		}
	}

	private void method_4(string string_5, string string_6)
	{
		if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Core.dll"))
		{
			method_5(string_5 + "Vlc.DotNet.Core.dll", AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Core.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Core.Interops.dll"))
		{
			method_5(string_5 + "Vlc.DotNet.Core.Interops.dll", AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Core.Interops.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Forms.dll"))
		{
			method_5(string_5 + "Vlc.DotNet.Forms.dll", AppDomain.CurrentDomain.BaseDirectory + "Vlc.DotNet.Forms.dll");
		}
		else
		{
			int_3++;
		}
		string_5 += "/lib/vlclib/";
		string_6 += "lib\\vlclib\\";
		if (!File.Exists(string_6 + "libvlc.dll"))
		{
			method_5(string_5 + "libvlc.dll", string_6 + "libvlc.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "libvlccore.dll"))
		{
			method_5(string_5 + "libvlccore.dll", string_6 + "libvlccore.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libavcodec_plugin.dll"))
		{
			method_5(string_5 + "plugins/libavcodec_plugin.dll", string_6 + "plugins\\libavcodec_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libdrawable_plugin.dll"))
		{
			method_5(string_5 + "plugins/libdrawable_plugin.dll", string_6 + "plugins\\libdrawable_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libdummy_plugin.dll"))
		{
			method_5(string_5 + "plugins/libdummy_plugin.dll", string_6 + "plugins\\libdummy_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libfilesystem_plugin.dll"))
		{
			method_5(string_5 + "plugins/libfilesystem_plugin.dll", string_6 + "plugins\\libfilesystem_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libglwin32_plugin.dll"))
		{
			method_5(string_5 + "plugins/libglwin32_plugin.dll", string_6 + "plugins\\libglwin32_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\libmpeg_audio_plugin.dll"))
		{
			method_5(string_5 + "plugins/libmpeg_audio_plugin.dll", string_6 + "plugins\\libmpeg_audio_plugin.dll");
		}
		else
		{
			int_3++;
		}
		if (!File.Exists(string_6 + "plugins\\librawvideo_plugin.dll"))
		{
			method_5(string_5 + "plugins/librawvideo_plugin.dll", string_6 + "plugins\\librawvideo_plugin.dll");
			return;
		}
		int_3++;
		if (int_3 >= 12)
		{
			int_0++;
			bool_0 = false;
			int_3 = 0;
		}
	}

	private void method_5(string string_5, string string_6)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			webClient.DownloadFileCompleted += method_6;
			webClient.DownloadProgressChanged += method_13;
			webClient.DownloadFileAsync(new Uri(string_5), string_6);
		}
		catch
		{
			System.Windows.Forms.Timer timer = timer_0;
			timer_1.Enabled = false;
			timer.Enabled = false;
		}
	}

	private void method_6(object sender, AsyncCompletedEventArgs e)
	{
		int_3++;
		if (int_3 >= 12)
		{
			int_0++;
			bool_0 = false;
			int_3 = 0;
		}
	}

	private void method_7(bool bool_1)
	{
		lblProgress.Text = Resources.Updating + (bool_1 ? Resources.training : string.Empty) + Resources._databases;
		try
		{
			bool_0 = true;
			DBHelper dBHelper = new DBHelper();
			dBHelper.one_ten_four_to_one_ten_five(bool_1, string_0);
			dBHelper.one_ten_five_to_one_ten_six(bool_1, string_0);
			dBHelper.one_ten_six_to_one_ten_seven(bool_1, string_0);
			dBHelper.one_ten_seven_to_one_ten_eight(bool_1, string_0);
			dBHelper.one_ten_eight_to_one_ten_nine(bool_1, string_0);
			dBHelper.one_ten_eight_to_one_ten_nine(bool_1, string_0);
			dBHelper.one_ten_nine_to_one_eleven_zero(bool_1, string_0);
			dBHelper.one_eleven_zero_to_one_eleven_one(bool_1, string_0);
			dBHelper.one_eleven_one_to_one_eleven_two(bool_1, string_0);
			dBHelper.one_eleven_two_to_one_eleven_three(bool_1, string_0);
			dBHelper.one_eleven_three_to_one_eleven_four(bool_1, string_0);
			dBHelper.one_eleven_four_to_one_eleven_five(bool_1, string_0);
			dBHelper.one_eleven_five_to_one_eleven_six(bool_1, string_0);
			dBHelper.one_eleven_six_to_one_eleven_seven(bool_1, string_0);
			dBHelper.one_eleven_seven_to_one_eleven_eight(bool_1, string_0);
			dBHelper.DbUpdateTo_1_11_9(bool_1, string_0);
			dBHelper.DbUpdatedTo_1_12_0(bool_1, string_0);
			dBHelper.DbUpdatedTo_1_12_1(bool_1, string_0);
			dBHelper.DbUpdatedTo_1_12_2(bool_1, string_0);
			dBHelper.DbUpdatedTo_1_12_3(bool_1, string_0);
			dBHelper.DbUpdatedTo_1_12_4(bool_1, string_0);
			dBHelper.updateversion(bool_1, string_0);
			int_0++;
			bool_0 = false;
		}
		catch (Exception e)
		{
			System.Windows.Forms.Timer timer = timer_0;
			timer_1.Enabled = false;
			timer.Enabled = false;
			new frmSendErrorLog(e).Show(this);
		}
	}

	private bool method_8(string string_5)
	{
		WebRequest webRequest = WebRequest.Create(new Uri(string_5 + "CorePOS.Business.dll"));
		webRequest.Method = "HEAD";
		try
		{
			using WebResponse webResponse = webRequest.GetResponse();
			if (webResponse.ContentLength == 0L)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void method_9(string string_5, string string_6)
	{
		try
		{
			string_2 = string_5;
			string_3 = string_6;
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			webClient.DownloadFileCompleted += method_14;
			webClient.DownloadProgressChanged += method_13;
			webClient.DownloadFileAsync(new Uri(string_5), string_6);
		}
		catch (Exception e)
		{
			System.Windows.Forms.Timer timer = timer_0;
			timer_1.Enabled = false;
			timer.Enabled = false;
			new frmSendErrorLog(e).Show(this);
		}
	}

	private void method_10(string string_5, string string_6)
	{
		method_11(string_5 + "CorePOS.Business.resources.dll", string_6 + "CorePOS.Business.resources.dll");
		method_11(string_5 + "Hippos.resources.dll", string_6 + "Hippos.resources.dll");
		method_11(string_5 + "Hippos-Updater.resources.dll", string_6 + "Hippos-Updater.resources.dll");
		method_11(string_5 + "hippos_full_service_guide.pdf", string_6 + "hippos_full_service_guide.pdf");
		method_11(string_5 + "hippos_quick_service_guide.pdf", string_6 + "hippos_quick_service_guide.pdf");
	}

	private void method_11(string string_5, string string_6)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			webClient.DownloadFileCompleted += method_12;
			webClient.DownloadProgressChanged += method_13;
			webClient.DownloadFileAsync(new Uri(string_5), string_6);
		}
		catch (Exception e)
		{
			System.Windows.Forms.Timer timer = timer_0;
			timer_1.Enabled = false;
			timer.Enabled = false;
			new frmSendErrorLog(e).Show(this);
		}
	}

	public static StatusCodeResponse GetUpdateUrl(CheckForUpdatesPostData req)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://apps.hipposhq.com" + "/api/GetUpdateUrl");
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
			return JsonConvert.DeserializeObject<StatusCodeResponse>(streamReader.ReadToEnd());
		}
		catch
		{
			return new StatusCodeResponse
			{
				code = 400,
				message = "Unable to contact server"
			};
		}
	}

	public static string getRegistryValue(string registry, string valueName)
	{
		try
		{
			return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default)?.OpenSubKey(registry).GetValue(valueName).ToString();
		}
		catch
		{
			return null;
		}
	}

	private void method_12(object sender, AsyncCompletedEventArgs e)
	{
		int_2++;
		if (int_2 >= 5)
		{
			int_0++;
			bool_0 = false;
			int_2 = 0;
		}
	}

	private void method_13(object sender, DownloadProgressChangedEventArgs e)
	{
		progressBar1.Value = e.ProgressPercentage;
	}

	private void method_14(object sender, AsyncCompletedEventArgs e)
	{
		if (new FileInfo(string_3).Length == 0L && !string_3.Contains("pdb"))
		{
			method_9(string_2, string_3);
		}
		int_0++;
		bool_0 = false;
	}

	private bool method_15(FileInfo fileInfo_0)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = fileInfo_0.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
		}
		catch (IOException)
		{
			return true;
		}
		finally
		{
			fileStream?.Close();
		}
		return false;
	}

	private void method_16()
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "\\changelog.txt";
		if (File.Exists(text))
		{
			Process.Start(text);
		}
	}

	private void frmUpdater_Load(object sender, EventArgs e)
	{
		lblVersion.Text = Resources.Version + string_0;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.Updater.frmUpdater));
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_1 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.panel1 = new System.Windows.Forms.Panel();
		this.lblProgress = new System.Windows.Forms.Label();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.lblVersion = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.timer_0.Interval = 500;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.timer_1.Interval = 2000;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.lblProgress);
		this.panel1.Controls.Add(this.progressBar1);
		this.panel1.Controls.Add(this.lblVersion);
		this.panel1.Controls.Add(this.pictureBox2);
		componentResourceManager.ApplyResources(this.panel1, "panel1");
		this.panel1.Name = "panel1";
		this.lblProgress.BackColor = System.Drawing.Color.Transparent;
		this.lblProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.lblProgress, "lblProgress");
		this.lblProgress.ForeColor = System.Drawing.Color.White;
		this.lblProgress.Name = "lblProgress";
		this.lblProgress.UseMnemonic = false;
		this.progressBar1.ForeColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.progressBar1, "progressBar1");
		this.progressBar1.Name = "progressBar1";
		this.lblVersion.ForeColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.lblVersion, "lblVersion");
		this.lblVersion.Name = "lblVersion";
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmUpdater";
		base.Load += new System.EventHandler(frmUpdater_Load);
		this.panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
	}
}
