using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Properties;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorePOS.CommonForms;

public class frmLoading : frmMasterForm
{
	private List<string> list_2;

	private string string_0;

	private IContainer icontainer_1;

	private Label lblMsg;

	private RadWaitingBar radWaitingBar1;

	private LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;

	public frmLoading(string message, string _todo, List<string> _info)
	{
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<string>();
		base._002Ector();
		InitializeComponent_1();
		radWaitingBar1.StartWaiting();
		lblMsg.Text = message;
		list_2 = _info;
		string_0 = _todo;
		if (AppSettings.ScreenCount >= 2)
		{
			Rectangle bounds = AppSettings.MainScreen.Bounds;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			SetBounds(bounds.Width / 2 - base.Width / 2, bounds.Height / 2 - base.Height / 2, base.Width, base.Height);
		}
	}

	private void frmLoading_Load(object sender, EventArgs e)
	{
		new Thread((ThreadStart)delegate
		{
			Thread.CurrentThread.IsBackground = true;
			try
			{
				if (string_0 == "sendEmail")
				{
					string text = AppDomain.CurrentDomain.BaseDirectory + list_2[0] + ".png";
					string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_language");
					new PrintHelper().PrintReceipt(settingValueByKey, list_2[0], printPaymentTransaction: false, 1, text, tipFlag: false, email: true);
					List<string> attachments = new List<string> { text };
					int num = 0;
					do
					{
						Thread.Sleep(100);
						num++;
					}
					while (!File.Exists(text) && num < 20);
					NotificationMethods.sendEmail(NotificationMethods.GetSMTPSettings(), list_2[1], Resources.Your_Order_Receipt, list_2[2], attachments);
				}
				base.DialogResult = DialogResult.OK;
			}
			catch
			{
				base.DialogResult = DialogResult.OK;
			}
		}).Start();
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
		lblMsg = new Label();
		radWaitingBar1 = new RadWaitingBar();
		lineRingWaitingBarIndicatorElement1 = new LineRingWaitingBarIndicatorElement();
		((ISupportInitialize)radWaitingBar1).BeginInit();
		SuspendLayout();
		lblMsg.BackColor = Color.FromArgb(35, 39, 56);
		lblMsg.Font = new Font("Microsoft Sans Serif", 25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblMsg.ForeColor = Color.White;
		lblMsg.ImeMode = ImeMode.NoControl;
		lblMsg.Location = new Point(153, 36);
		lblMsg.Name = "lblMsg";
		lblMsg.Padding = new Padding(5, 5, 5, 0);
		lblMsg.Size = new Size(374, 100);
		lblMsg.TabIndex = 23;
		lblMsg.Text = "SENDING EMAIL";
		lblMsg.TextAlign = ContentAlignment.MiddleCenter;
		radWaitingBar1.BackColor = Color.FromArgb(35, 39, 56);
		radWaitingBar1.Location = new Point(47, 37);
		radWaitingBar1.Name = "radWaitingBar1";
		radWaitingBar1.Size = new Size(100, 100);
		radWaitingBar1.TabIndex = 24;
		radWaitingBar1.Text = "radWaitingBar1";
		radWaitingBar1.WaitingIndicators.Add(lineRingWaitingBarIndicatorElement1);
		radWaitingBar1.WaitingSpeed = 50;
		radWaitingBar1.WaitingStyle = WaitingBarStyles.LineRing;
		lineRingWaitingBarIndicatorElement1.ElementColor = Color.FromArgb(252, 193, 0);
		lineRingWaitingBarIndicatorElement1.ElementColor2 = Color.FromArgb(251, 211, 64);
		lineRingWaitingBarIndicatorElement1.ElementColor3 = Color.FromArgb(252, 239, 175);
		lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
		lineRingWaitingBarIndicatorElement1.Radius = 40;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ClientSize = new Size(573, 176);
		base.Controls.Add(radWaitingBar1);
		base.Controls.Add(lblMsg);
		base.Name = "frmLoading";
		base.Opacity = 1.0;
		Text = "frmLoading";
		base.Load += frmLoading_Load;
		((ISupportInitialize)radWaitingBar1).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void method_3()
	{
		Thread.CurrentThread.IsBackground = true;
		try
		{
			if (string_0 == "sendEmail")
			{
				string text = AppDomain.CurrentDomain.BaseDirectory + list_2[0] + ".png";
				string settingValueByKey = SettingsHelper.GetSettingValueByKey("receipt_language");
				new PrintHelper().PrintReceipt(settingValueByKey, list_2[0], printPaymentTransaction: false, 1, text, tipFlag: false, email: true);
				List<string> attachments = new List<string> { text };
				int num = 0;
				do
				{
					Thread.Sleep(100);
					num++;
				}
				while (!File.Exists(text) && num < 20);
				NotificationMethods.sendEmail(NotificationMethods.GetSMTPSettings(), list_2[1], Resources.Your_Order_Receipt, list_2[2], attachments);
			}
			base.DialogResult = DialogResult.OK;
		}
		catch
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
