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
		progressBar1.set_Maximum(100);
		progressBar1.set_Value1(0);
		timer_0.Tick += timer_0_Tick;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		progressBar1.set_Value1(int_0);
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
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLoadingBar));
		progressBar1 = new RadProgressBar();
		label1 = new Label();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		((ISupportInitialize)progressBar1).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(progressBar1, "progressBar1");
		((Control)(object)progressBar1).ForeColor = Color.White;
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
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(label1);
		base.Controls.Add((Control)(object)progressBar1);
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
