using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmSendReminders : frmMasterForm
{
	private bool bool_0;

	private IContainer icontainer_1;

	internal ListView lstItems;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Panel panel1;

	private Label label8;

	private Label lblDateTime;

	internal Button BtnClose;

	internal Button btnSend;

	private Label label15;

	private Timer timer_0;

	private ColumnHeader columnHeader_2;

	private Label label1;

	private Label label3;

	private ColumnHeader columnHeader_3;

	private Label label2;

	private Label lblTips;

	public frmSendReminders(bool _isManual = false)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		lblDateTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToShortTimeString();
		bool_0 = _isManual;
		if (_isManual)
		{
			btnSend.Visible = false;
			lblTips.Text = Resources.TIP_This_screen_only_shows_tom;
		}
		else
		{
			btnSend.Visible = true;
		}
	}

	private void frmSendReminders_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		IQueryable<Appointment> queryable = (bool_0 ? gClass.Appointments.Where((Appointment a) => a.StartDateTime.Date == DateTime.Now.AddDays(1.0).Date && a.isCancelled == false && a.CustomerCell == string.Empty && a.CustomerEmail == string.Empty) : gClass.Appointments.Where((Appointment a) => a.StartDateTime.Date == DateTime.Now.AddDays(1.0).Date && a.isCancelled == false && (a.CustomerCell != string.Empty || a.CustomerEmail != string.Empty) && (a.SMSSent == false || a.EmailSent == false)));
		foreach (Appointment item in queryable)
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(item.CustomerCell))
			{
				text = Resources.Cell + item.CustomerCell;
			}
			if (!string.IsNullOrEmpty(item.CustomerEmail))
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += " / ";
				}
				text = text + Resources.E_mail + item.CustomerEmail;
			}
			if (!string.IsNullOrEmpty(item.CustomerHome))
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += " / ";
				}
				text = text + Resources.Home + item.CustomerHome;
			}
			ListViewItem value = new ListViewItem(new string[5]
			{
				item.CustomerName,
				text,
				item.StartDateTime.ToShortTimeString(),
				string.Empty,
				item.AppointmentID.ToString()
			});
			lstItems.Items.Add(value);
		}
	}

	private void btnSend_Click(object sender, EventArgs e)
	{
		try
		{
			GClass6 gClass = new GClass6();
			CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
			Appointment appointment = null;
			string token = SyncMethods.GetToken();
			string text = Resources.Reminder + companySetup.Name + Resources._appointment_tomorrow_at_APPOI + companySetup.Phone + Resources._if_you_need_to_change_or_canc0;
			gClass.Settings.Where((Setting s) => s.Key.Contains("sms"));
			SMTPSettings sMTPSettings = NotificationMethods.GetSMTPSettings();
			for (int i = 0; i < lstItems.Items.Count; i++)
			{
				lstItems.Items[i].Selected = true;
				appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == Convert.ToInt32(lstItems.SelectedItems[0].SubItems[4].Text)).FirstOrDefault();
				if (!string.IsNullOrEmpty(appointment.CustomerCell))
				{
					if (NotificationMethods.SendSMS(token, appointment.CustomerCell, text.Replace("{APPOINTMENT_TIME}", lstItems.SelectedItems[0].SubItems[2].Text)))
					{
						lstItems.SelectedItems[0].SubItems[3].Text = lstItems.SelectedItems[0].SubItems[3].Text + Resources._TXT_Sent;
						appointment.SMSSent = true;
					}
					else
					{
						lstItems.SelectedItems[0].SubItems[3].Text = lstItems.SelectedItems[0].SubItems[3].Text + Resources._TXT_Failed;
					}
				}
				if (!string.IsNullOrEmpty(appointment.CustomerEmail))
				{
					string subject = Resources.Appointment_Reminder_for + companySetup.Name;
					text = Resources.This_is_a_friendly_reminder_fr + companySetup.Name + Resources._that_you_have_an_appointment_ + lstItems.SelectedItems[0].SubItems[2].Text + Resources._br_br_Please_call + companySetup.Phone + Resources._if_you_need_to_cancel_or_chan0 + companySetup.Name;
					if (string.IsNullOrEmpty(NotificationMethods.sendEmail(sMTPSettings, appointment.CustomerEmail, subject, text)))
					{
						lstItems.SelectedItems[0].SubItems[3].Text = lstItems.SelectedItems[0].SubItems[3].Text + Resources._EMAIL_Sent;
						appointment.EmailSent = true;
					}
					else
					{
						lstItems.SelectedItems[0].SubItems[3].Text = lstItems.SelectedItems[0].SubItems[3].Text + Resources._EMAIL_Failed;
					}
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		catch
		{
			new frmMessageBox(Resources.A_fatal_error_has_occurred).ShowDialog(this);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		lblDateTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToShortTimeString();
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSendReminders));
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		panel1 = new Panel();
		label8 = new Label();
		lblDateTime = new Label();
		BtnClose = new Button();
		btnSend = new Button();
		label15 = new Label();
		timer_0 = new Timer(icontainer_1);
		label1 = new Label();
		label3 = new Label();
		label2 = new Label();
		lblTips = new Label();
		panel1.SuspendLayout();
		SuspendLayout();
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[4] { columnHeader_0, columnHeader_1, columnHeader_3, columnHeader_2 });
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_0, "Customer");
		componentResourceManager.ApplyResources(columnHeader_1, "Appointments");
		componentResourceManager.ApplyResources(columnHeader_3, "Time");
		componentResourceManager.ApplyResources(columnHeader_2, "Status");
		panel1.BackColor = Color.FromArgb(234, 234, 234);
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(label8);
		panel1.Controls.Add(lblDateTime);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(label8, "label8");
		label8.Name = "label8";
		componentResourceManager.ApplyResources(lblDateTime, "lblDateTime");
		lblDateTime.Name = "lblDateTime";
		BtnClose.BackColor = Color.FromArgb(193, 57, 43);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		btnSend.BackColor = Color.FromArgb(47, 204, 113);
		btnSend.FlatAppearance.BorderColor = Color.Black;
		btnSend.FlatAppearance.BorderSize = 0;
		btnSend.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSend, "btnSend");
		btnSend.ForeColor = Color.White;
		btnSend.Name = "btnSend";
		btnSend.UseVisualStyleBackColor = false;
		btnSend.Click += btnSend_Click;
		componentResourceManager.ApplyResources(label15, "label15");
		label15.BackColor = Color.FromArgb(53, 73, 94);
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		timer_0.Enabled = true;
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.FromArgb(53, 73, 94);
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(53, 73, 94);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(53, 73, 94);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		lblTips.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(lblTips, "lblTips");
		lblTips.Name = "lblTips";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(lblTips);
		base.Controls.Add(label2);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(label15);
		base.Controls.Add(btnSend);
		base.Controls.Add(BtnClose);
		base.Controls.Add(panel1);
		base.Controls.Add(lstItems);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSendReminders";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.Load += frmSendReminders_Load;
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
