using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class LoadingLabel : frmMasterForm
{
	private int int_0;

	private string string_0;

	private Form form_0;

	private IContainer icontainer_1;

	private RadProgressBar progressBar1;

	private Timer timer_0;

	public LoadingLabel(Form parent)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		base._002Ector();
		InitializeComponent_1();
		form_0 = parent;
	}

	public void StartLoading()
	{
		Show(form_0);
	}

	public void EndLoading()
	{
		if (!base.IsDisposed)
		{
			Close();
		}
	}

	public void SetPercentage(int value, string loadingText = "Loading...")
	{
		if (value >= 100)
		{
			if (!base.IsDisposed)
			{
				Close();
			}
		}
		else
		{
			progressBar1.set_Value1(int_0 = value);
			((Control)(object)progressBar1).Text = (string_0 = loadingText);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		progressBar1.set_Value1(int_0);
		((Control)(object)progressBar1).Text = string_0;
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
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		timer_0 = new Timer(icontainer_1);
		progressBar1 = new RadProgressBar();
		((ISupportInitialize)progressBar1).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Tick += timer_0_Tick;
		((Control)(object)progressBar1).Font = new Font("Segoe UI", 12f);
		((Control)(object)progressBar1).ForeColor = Color.White;
		((Control)(object)progressBar1).Location = new Point(1, 3);
		((Control)(object)progressBar1).Name = "progressBar1";
		((Control)(object)progressBar1).Size = new Size(485, 28);
		((Control)(object)progressBar1).TabIndex = 155;
		((Control)(object)progressBar1).Text = "Loading ...";
		((RadItem)(RadProgressBarElement)((RadControl)progressBar1).GetChildAt(0)).set_Text("Loading ...");
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
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(487, 33);
		base.Controls.Add((Control)(object)progressBar1);
		base.Name = "LoadingLabel";
		base.Opacity = 1.0;
		base.TopMost = true;
		((ISupportInitialize)progressBar1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
