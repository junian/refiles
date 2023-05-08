using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmLoadingBar : frmMasterForm
{
	private delegate void Delegate4();

	private static int int_0;

	private static frmLoadingBar frmLoadingBar_0;

	private IContainer icontainer_1;

	private RadProgressBar progressBar1;

	private Label label1;

	private System.Windows.Forms.Timer timer_0;

	private frmLoadingBar()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	public static void SetPercentage(int value)
	{
		int_0 = value;
	}

	public static void ShowSplashScreen()
	{
		if (frmLoadingBar_0 == null)
		{
			Thread thread = new Thread(smethod_0);
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
	}

	private static void smethod_0()
	{
		frmLoadingBar_0 = new frmLoadingBar();
		Application.Run(frmLoadingBar_0);
	}

	public static void CloseForm()
	{
		if (frmLoadingBar_0 != null)
		{
			frmLoadingBar_0.Invoke(new Delegate4(smethod_1));
		}
	}

	private static void smethod_1()
	{
		if (frmLoadingBar_0 != null)
		{
			frmLoadingBar_0.Stop_Timer();
			frmLoadingBar_0.Close();
			frmLoadingBar_0 = null;
			GC.Collect();
		}
		int_0 = 0;
	}

	public void Stop_Timer()
	{
		timer_0.Stop();
	}

	private void frmLoadingBar_Load(object sender, EventArgs e)
	{
		timer_0.Enabled = true;
		timer_0.Start();
		timer_0.Interval = 50;
		progressBar1.Maximum = 100;
		progressBar1.Value1 = 0;
		timer_0.Tick += timer_0_Tick;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		progressBar1.Value1 = int_0;
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLoadingBar));
		progressBar1 = new RadProgressBar();
		label1 = new Label();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		((ISupportInitialize)progressBar1).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(progressBar1, "progressBar1");
		progressBar1.ForeColor = Color.White;
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
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(label1);
		base.Controls.Add(progressBar1);
		base.Name = "frmLoadingBar";
		base.Opacity = 1.0;
		base.Load += frmLoadingBar_Load;
		((ISupportInitialize)progressBar1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	static frmLoadingBar()
	{
		Class26.Ggkj0JxzN9YmC();
	}
}
