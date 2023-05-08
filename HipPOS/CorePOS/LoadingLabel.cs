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
			progressBar1.Value1 = (int_0 = value);
			progressBar1.Text = (string_0 = loadingText);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		progressBar1.Value1 = int_0;
		progressBar1.Text = string_0;
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
		timer_0 = new Timer(icontainer_1);
		progressBar1 = new RadProgressBar();
		((ISupportInitialize)progressBar1).BeginInit();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Tick += timer_0_Tick;
		progressBar1.Font = new Font("Segoe UI", 12f);
		progressBar1.ForeColor = Color.White;
		progressBar1.Location = new Point(1, 3);
		progressBar1.Name = "progressBar1";
		progressBar1.Size = new Size(485, 28);
		progressBar1.TabIndex = 155;
		progressBar1.Text = "Loading ...";
		((RadProgressBarElement)progressBar1.GetChildAt(0)).Text = "Loading ...";
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
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(487, 33);
		base.Controls.Add(progressBar1);
		base.Name = "LoadingLabel";
		base.Opacity = 1.0;
		base.TopMost = true;
		((ISupportInitialize)progressBar1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
