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
		((Control)(object)progressBar1).Text = Resources.Downloading + file_info + " ...";
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
		progressBar1.set_Value1(e.ProgressPercentage);
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDownloader));
		panel1 = new Panel();
		progressBar1 = new RadProgressBar();
		pictureBox2 = new PictureBox();
		panel1.SuspendLayout();
		((ISupportInitialize)progressBar1).BeginInit();
		((ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add((Control)(object)progressBar1);
		panel1.Controls.Add(pictureBox2);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		((Control)(object)progressBar1).ForeColor = Color.White;
		componentResourceManager.ApplyResources(progressBar1, "progressBar1");
		((Control)(object)progressBar1).Name = "progressBar1";
		((RadItem)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderColor(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderColor2(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderColor3(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderColor4(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderInnerColor(Color.FromArgb(21, 23, 33));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BackColor2(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BackColor3(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BackColor4(Color.FromArgb(35, 39, 56));
		((UIItemBase)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BorderBottomColor(Color.FromArgb(0, 0, 0));
		((VisualElement)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_BackColor(Color.FromArgb(35, 39, 56));
		((UIItemBase)(ProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((VisualElement)(ProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((RadElement)(ProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(0)).set_Visibility((ElementVisibility)2);
		((UIItemBase)(UpperProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(1)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(UpperProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(1)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(UpperProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(1)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((VisualElement)(UpperProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(1)).set_BackColor(Color.FromArgb(247, 192, 82));
		((RadElement)(UpperProgressIndicatorElement)((RadControl)progressBar1).GetChildAt(0).GetChildAt(1)).set_Visibility((ElementVisibility)2);
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
