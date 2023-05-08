using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CorePOS.Updater;

public class frmLoader : Form
{
	private string string_0;

	private int int_0;

	private IContainer icontainer_0;

	public frmLoader()
	{
		Class13.FLcy5UmzUUEfT();
		string_0 = "https://www.hipposhq.com/downloads/restaurant/required/";
		base._002Ector();
		InitializeComponent();
	}

	private void frmLoader_Load(object sender, EventArgs e)
	{
		method_0();
		FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Hippos.exe");
		if (fileInfo.Exists && method_1(fileInfo))
		{
			Process[] processesByName = Process.GetProcessesByName("HipPOS");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}
		string text = new DBHelper().checkCorrectSoftwareType(isTraining: true);
		if (text == "error-connection")
		{
			MessageBox.Show("Unable to connect to training database. Please make sure the training database is the same name as the production database with a \"-Training\" suffix.", "Database Error", MessageBoxButtons.OK);
			Application.Exit();
		}
		text = new DBHelper().checkCorrectSoftwareType(isTraining: false);
		if (text == "error-connection")
		{
			MessageBox.Show("Unable to connect to production database.", "Database Error", MessageBoxButtons.OK);
			return;
		}
		if (text == "restaurant")
		{
			new frmUpdater().Show();
			return;
		}
		MessageBox.Show("You cannot run a Hippos Restaurant updater on an existing Hippos Retail database.  This updater will now terminate to avoid data corruption.", "Execution Error", MessageBoxButtons.OK);
		Application.Exit();
	}

	private void method_0()
	{
		new DBHelper().EncryptConnectionString();
	}

	private bool method_1(FileInfo fileInfo_0)
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

	private void method_2(string string_1)
	{
		method_3(string_0 + string_1, AppDomain.CurrentDomain.BaseDirectory + string_1);
	}

	private void method_3(string string_1, string string_2)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			webClient.DownloadFileCompleted += method_4;
			webClient.DownloadFileAsync(new Uri(string_1), string_2);
		}
		catch (Exception e)
		{
			new frmSendErrorLog(e).Show(this);
		}
	}

	private void method_4(object sender, AsyncCompletedEventArgs e)
	{
		if (int_0 == 0)
		{
			if (new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Newtonsoft.Json.dll").Length == 0L)
			{
				method_2("Newtonsoft.Json.dll");
			}
			else
			{
				int_0++;
			}
		}
		else if (new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Newtonsoft.Json.xml").Length == 0L)
		{
			method_2("Newtonsoft.Json.xml");
		}
		else
		{
			int_0++;
		}
		if (int_0 >= 2)
		{
			Thread.Sleep(2000);
			DBHelper dBHelper = new DBHelper();
			dBHelper.checkCorrectSoftwareType(isTraining: true);
			dBHelper.checkCorrectSoftwareType(isTraining: false);
			new frmUpdater().Show();
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.Updater.frmLoader));
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Silver;
		base.ClientSize = new System.Drawing.Size(41, 20);
		base.ControlBox = false;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLoader";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Loading...";
		base.TransparencyKey = System.Drawing.Color.Silver;
		base.WindowState = System.Windows.Forms.FormWindowState.Minimized;
		base.Load += new System.EventHandler(frmLoader_Load);
		base.ResumeLayout(false);
	}
}
