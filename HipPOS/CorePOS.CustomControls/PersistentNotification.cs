using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using CorePOS.Business.Methods;

namespace CorePOS.CustomControls;

public class PersistentNotification : Label
{
	public bool hasFocus;

	private bool bool_0;

	private short short_0;

	private Timer timer_0;

	private SoundPlayer soundPlayer_0;

	public PersistentNotification()
	{
		Class26.Ggkj0JxzN9YmC();
		timer_0 = new Timer();
		soundPlayer_0 = new SoundPlayer();
		base._002Ector();
		base.Size = new Size(765, 61);
		base.Visible = false;
		base.Location = new Point(-100, -100);
		BackColor = Color.FromArgb(65, 168, 95);
		ForeColor = Color.White;
		TextAlign = ContentAlignment.MiddleCenter;
		Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular);
		base.Click += PersistentNotification_Click;
		base.TabIndex = 0;
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CorePOS.ring-bell.wav");
		soundPlayer_0 = new SoundPlayer(manifestResourceStream);
		timer_0.Interval = 2500;
		timer_0.Tick += timer_0_Tick;
		timer_0.Enabled = false;
	}

	private void PersistentNotification_Click(object sender, EventArgs e)
	{
		foreach (Form openForm in Application.OpenForms)
		{
			if (openForm is frmMasterForm)
			{
				(openForm as frmMasterForm).PersistentNotification.Visible = false;
			}
			else if (openForm is frmSplash)
			{
				(openForm as frmSplash).PersistentNotification.Visible = false;
			}
		}
		timer_0.Enabled = false;
		CompanyHelper.UpdateCompanyHasUnconfirmedOnlineOrder(status: false);
	}

	public void ShowOnlineOrderReceivedCheck(string frmName)
	{
		if (!(frmName == "frmMultiBills") && !(frmName == "frmLayout") && !(frmName == "frmOrderEntry") && !(frmName == "frmStation") && !(frmName == "frmStationTiles") && !(frmName == "frmQuickService") && !(frmName == "frmQuickServiceListView") && !(frmName == "frmAdmin"))
		{
			switch (frmName)
			{
			default:
				return;
			case "frmSplash":
			case "frmAdmin":
			case "frmAdminViewOrders":
			case "frmInventoryView":
				break;
			}
		}
		if (SettingsHelper.GetSettingValueByKey("online_order_notification_all") == "ON" && CompanyHelper.CheckIfCompanyHasUnconfirmedOnlineOrder())
		{
			Rectangle bounds = AppSettings.MainScreen.Bounds;
			string text2 = (Text = "ONLINE ORDERS RECEIVED");
			base.Location = new Point(bounds.Width / 2 - base.Width / 2, 20);
			base.Visible = true;
			BringToFront();
			if (SettingsHelper.GetSettingValueByKey("online_order_notification_all_audio") == "ON")
			{
				hasFocus = true;
				bool_0 = true;
				timer_0.Enabled = true;
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (hasFocus)
		{
			short_0++;
			if (short_0 >= 3)
			{
				bool_0 = CompanyHelper.CheckIfCompanyHasUnconfirmedOnlineOrder();
				short_0 = 0;
			}
			if (bool_0)
			{
				soundPlayer_0.Play();
				return;
			}
			Timer timer = timer_0;
			base.Visible = false;
			timer.Enabled = false;
			hasFocus = false;
		}
	}
}
