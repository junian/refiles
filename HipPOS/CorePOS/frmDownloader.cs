using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDownloader : frmMasterForm
{
	private string string_0;

	private string VvoFhvNonLN;

	private IContainer icontainer_1;

	private Panel panel1;

	private PictureBox pictureBox2;

	private RadProgressBar progressBar1;

	public frmDownloader(string url, string save_path, string file_info)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		method_3(url, save_path);
		progressBar1.Text = Resources.Downloading + file_info + " ...";
		VvoFhvNonLN = file_info;
		string_0 = save_path;
	}

	private void method_3(string string_1, string string_2)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
			webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
			webClient.DownloadFileCompleted += method_5;
			webClient.DownloadProgressChanged += method_4;
			webClient.DownloadFileAsync(new Uri(string_1), string_2);
		}
		catch (Exception error)
		{
			NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
		}
	}

	private void method_4(object sender, DownloadProgressChangedEventArgs e)
	{
		progressBar1.Value1 = e.ProgressPercentage;
	}

	private void method_5(object sender, AsyncCompletedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void frmDownloader_Load(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDownloader));
		panel1 = new Panel();
		progressBar1 = new RadProgressBar();
		pictureBox2 = new PictureBox();
		panel1.SuspendLayout();
		((ISupportInitialize)progressBar1).BeginInit();
		((ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(progressBar1);
		panel1.Controls.Add(pictureBox2);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		progressBar1.ForeColor = Color.White;
		componentResourceManager.ApplyResources(progressBar1, "progressBar1");
		progressBar1.Name = "progressBar1";
		((RadProgressBarElement)progressBar1.GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor2 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor3 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor4 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderInnerColor = Color.FromArgb(21, 23, 33);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor2 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor3 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor4 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderBottomColor = Color.FromArgb(0, 0, 0);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor = Color.FromArgb(35, 39, 56);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).Visibility = ElementVisibility.Collapsed;
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor2 = Color.FromArgb(247, 192, 82);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor3 = Color.FromArgb(242, 182, 51);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor4 = Color.FromArgb(242, 182, 51);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor = Color.FromArgb(247, 192, 82);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).Visibility = ElementVisibility.Collapsed;
		componentResourceManager.ApplyResources(pictureBox2, "pictureBox2");
		pictureBox2.Name = "pictureBox2";
		pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(panel1);
		base.Name = "frmDownloader";
		base.Opacity = 1.0;
		base.Load += frmDownloader_Load;
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)progressBar1).EndInit();
		((ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(performLayout: false);
	}
}
