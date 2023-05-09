using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmSearchAppointments : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string criteria;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int x;

		public frmSearchAppointments _003C_003E4__this;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int x;

		public frmSearchAppointments _003C_003E4__this;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Appointment selected_app;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public string criteria;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string criteria;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private IContainer icontainer_1;

	internal ListView lstItems;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private Panel panel1;

	private Label label8;

	private Label lblDateTime;

	internal Button BtnClose;

	private Label label15;

	private Timer timer_0;

	private Label label1;

	private ColumnHeader columnHeader_2;

	private Label label2;

	internal Button btnSearch;

	internal Button btnRemove;

	private Label label4;

	private TextBox txtCriteria;

	internal Button btnCancelAll;

	internal Button btnUncancel;

	internal Button btnPrint;

	private CheckBox chkOnlyNew;

	private ColumnHeader columnHeader_3;

	private Label label3;

	internal Button btnEmail;

	private Label lblTrainingMode;

	public frmSearchAppointments()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		lblDateTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToShortTimeString();
		if (Screen.PrimaryScreen.Bounds.Height <= 800)
		{
			base.WindowState = FormWindowState.Maximized;
		}
		else
		{
			base.WindowState = FormWindowState.Normal;
		}
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
	}

	private void frmSearchAppointments_Load(object sender, EventArgs e)
	{
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 35);
		lstItems.SmallImageList = imageList;
	}

	private void frmSearchAppointments_FormClosing(object sender, FormClosingEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		lblDateTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToShortTimeString();
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		lstItems.Items.Clear();
		CS_0024_003C_003E8__locals0.criteria = txtCriteria.Text.Trim();
		string text = string.Empty;
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.criteria))
		{
			IQueryable<Appointment> queryable = from a in new GClass6().Appointments
				where a.CustomerCell.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerHome.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerEmail.Contains(CS_0024_003C_003E8__locals0.criteria)
				select a into b
				orderby b.StartDateTime descending
				select b;
			if (chkOnlyNew.Checked)
			{
				queryable = queryable.Where((Appointment a) => a.StartDateTime.Date >= DateTime.Now.Date);
			}
			if (queryable.Count() > 0)
			{
				foreach (Appointment item in queryable)
				{
					string text2 = string.Empty;
					if (!string.IsNullOrEmpty(item.CustomerCell))
					{
						text2 = Resources.Cell + item.CustomerCell;
					}
					if (!string.IsNullOrEmpty(item.CustomerEmail))
					{
						if (!string.IsNullOrEmpty(text2))
						{
							text2 += " / ";
						}
						text2 = text2 + Resources.E_mail + item.CustomerEmail;
					}
					if (!string.IsNullOrEmpty(item.CustomerHome))
					{
						if (!string.IsNullOrEmpty(text2))
						{
							text2 += " / ";
						}
						text2 = text2 + Resources.Home + item.CustomerHome;
					}
					if (!string.IsNullOrEmpty(item.Comments))
					{
						text2 = text2 + Resources._Comments + item.Comments;
					}
					if (item.StartDateTime < DateTime.Now)
					{
						text = (item.isNoShow ? "No" : "Yes");
					}
					ListViewItem listViewItem = new ListViewItem(new string[5]
					{
						item.CustomerName,
						text2,
						item.StartDateTime.ToLongDateString() + " @ " + item.StartDateTime.ToShortTimeString(),
						text,
						item.AppointmentID.ToString()
					});
					if (item.isCancelled)
					{
						listViewItem.Font = new Font(lstItems.Font, FontStyle.Strikeout);
						listViewItem.ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Salmon"]);
					}
					else
					{
						listViewItem.Font = new Font(lstItems.Font, FontStyle.Regular);
						listViewItem.ForeColor = HelperMethods.GetColor("Black");
					}
					lstItems.Items.Add(listViewItem);
				}
				return;
			}
			ListViewItem value = new ListViewItem(new string[2]
			{
				string.Empty,
				Resources._No_Results_Found
			});
			lstItems.Items.Add(value);
		}
		else
		{
			new frmMessageBox(Resources.Please_enter_a_search_criteria).ShowDialog(this);
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (lstItems.Items.Count == 0)
		{
			new frmMessageBox(Resources.Nothing_to_cancel).ShowDialog(this);
			return;
		}
		if (lstItems.Items[0].SubItems[1].Text.Trim() == Resources._No_Results_Found)
		{
			new frmMessageBox(Resources.Nothing_to_cancel).ShowDialog(this);
			return;
		}
		if (lstItems.SelectedItems.Count == 0)
		{
			new frmMessageBox(Resources.Please_select_an_appointment_t).ShowDialog(this);
			return;
		}
		GClass6 gClass = new GClass6();
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.x = 0;
		while (CS_0024_003C_003E8__locals0.x < lstItems.SelectedItems.Count)
		{
			if (lstItems.SelectedItems[CS_0024_003C_003E8__locals0.x].SubItems[4] != null)
			{
				try
				{
					Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == Convert.ToInt32(lstItems.SelectedItems[CS_0024_003C_003E8__locals0.x].SubItems[4].Text)).FirstOrDefault();
					if (appointment != null)
					{
						appointment.isCancelled = true;
						Helper.SubmitChangesWithCatch(gClass);
						lstItems.SelectedItems[CS_0024_003C_003E8__locals0.x].Font = new Font(lstItems.SelectedItems[CS_0024_003C_003E8__locals0.x].Font, FontStyle.Strikeout);
						lstItems.SelectedItems[CS_0024_003C_003E8__locals0.x].ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Salmon"]);
						lstItems.SelectedIndices.Clear();
					}
				}
				catch
				{
				}
			}
			CS_0024_003C_003E8__locals0.x++;
		}
	}

	private void btnCancelAll_Click(object sender, EventArgs e)
	{
		if (lstItems.Items.Count == 0)
		{
			new frmMessageBox(Resources.Nothing_to_cancel).ShowDialog(this);
			return;
		}
		if (lstItems.Items[0].SubItems[1].Text.Trim() == Resources._No_Results_Found)
		{
			new frmMessageBox(Resources.Nothing_to_cancel).ShowDialog(this);
			return;
		}
		DialogResult dialogResult = new frmMessageBox(Resources.Are_you_sure_you_want_to_cance1, Resources.Warning_Cancel_All, CustomMessageBoxButtons.YesNo).ShowDialog(this);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.x = 0;
		while (CS_0024_003C_003E8__locals0.x < lstItems.Items.Count)
		{
			try
			{
				Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == Convert.ToInt32(lstItems.Items[CS_0024_003C_003E8__locals0.x].SubItems[4].Text)).FirstOrDefault();
				if (appointment != null)
				{
					appointment.isCancelled = true;
					Helper.SubmitChangesWithCatch(gClass);
					lstItems.Items[CS_0024_003C_003E8__locals0.x].Font = new Font(lstItems.Items[CS_0024_003C_003E8__locals0.x].Font, FontStyle.Strikeout);
					lstItems.Items[CS_0024_003C_003E8__locals0.x].ForeColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]);
					lstItems.SelectedIndices.Clear();
				}
			}
			catch
			{
			}
			CS_0024_003C_003E8__locals0.x++;
		}
	}

	private void btnUncancel_Click(object sender, EventArgs e)
	{
		if (lstItems.Items.Count == 0)
		{
			new frmMessageBox(Resources.Please_select_reservation_to_u).ShowDialog(this);
		}
		else if (lstItems.SelectedItems[0].SubItems[0].Font.Strikeout)
		{
			_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.selected_app = gClass.Appointments.Where((Appointment a) => a.AppointmentID == Convert.ToInt32(lstItems.SelectedItems[0].SubItems[4].Text)).FirstOrDefault();
			if (CS_0024_003C_003E8__locals0.selected_app.StartDateTime.Date < DateTime.Now.Date)
			{
				new frmMessageBox(Resources.Cannot_undo_cancellation_for_t, Resources.Undo_Cancel_Error).ShowDialog(this);
				return;
			}
			if (gClass.Appointments.Where((Appointment a) => ((a.StartDateTime >= CS_0024_003C_003E8__locals0.selected_app.StartDateTime && a.StartDateTime <= CS_0024_003C_003E8__locals0.selected_app.EndDateTime) || (a.EndDateTime >= CS_0024_003C_003E8__locals0.selected_app.StartDateTime && a.EndDateTime <= CS_0024_003C_003E8__locals0.selected_app.EndDateTime)) && a.AppointmentID != CS_0024_003C_003E8__locals0.selected_app.AppointmentID && a.EmployeeID == CS_0024_003C_003E8__locals0.selected_app.EmployeeID && a.isCancelled == false).FirstOrDefault() != null)
			{
				new frmMessageBox(Resources.This_appointment_cannot_be_un_, Resources.Uncancel_Error).ShowDialog(this);
				return;
			}
			CS_0024_003C_003E8__locals0.selected_app.isCancelled = false;
			Helper.SubmitChangesWithCatch(gClass);
			lstItems.SelectedItems[0].Font = new Font(lstItems.Font, FontStyle.Regular);
			lstItems.SelectedItems[0].ForeColor = HelperMethods.GetColor("Black");
			lstItems.SelectedItems.Clear();
		}
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count > 0)
		{
			if (lstItems.SelectedItems[0].SubItems[0].Font.Strikeout)
			{
				btnUncancel.Enabled = true;
				btnUncancel.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Turquoise"]);
			}
			else
			{
				btnUncancel.Enabled = false;
				btnUncancel.BackColor = HelperMethods.GetColor("Gray");
			}
		}
		else
		{
			btnUncancel.Enabled = false;
			btnUncancel.BackColor = HelperMethods.GetColor("Gray");
		}
	}

	private void btnPrint_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		if (lstItems.Items.Count == 0)
		{
			new frmMessageBox(Resources.Nothing_to_print).ShowDialog(this);
			return;
		}
		CS_0024_003C_003E8__locals0.criteria = txtCriteria.Text.Trim();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.criteria))
		{
			List<Appointment> appointments = (from a in new GClass6().Appointments
				where (a.CustomerCell.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerHome.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerEmail.Contains(CS_0024_003C_003E8__locals0.criteria)) && a.StartDateTime.Date >= DateTime.Now.Date && a.isCancelled == false
				select a into d
				orderby d.StartDateTime
				select d).ToList();
			new PrintHelper().PrintAppointments(appointments);
		}
	}

	private void btnEmail_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		if (lstItems.Items.Count == 0)
		{
			new frmMessageBox(Resources.Nothing_to_e_mail).ShowDialog(this);
			return;
		}
		CS_0024_003C_003E8__locals0.criteria = txtCriteria.Text.Trim();
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.criteria))
		{
			return;
		}
		GClass6 gClass = new GClass6();
		List<Appointment> list = (from a in gClass.Appointments
			where (a.CustomerCell.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerHome.Contains(CS_0024_003C_003E8__locals0.criteria) || a.CustomerEmail.Contains(CS_0024_003C_003E8__locals0.criteria)) && a.StartDateTime.Date >= DateTime.Now.Date && a.isCancelled == false
			select a into d
			orderby d.StartDateTime
			select d).ToList();
		string text = string.Empty;
		SMTPSettings sMTPSettings = NotificationMethods.GetSMTPSettings();
		string text2 = "<ul>";
		CompanySetup companySetup = gClass.CompanySetups.FirstOrDefault();
		foreach (Appointment item in list)
		{
			text2 = text2 + "<li>" + item.StartDateTime.ToLongDateString() + " @ " + item.StartDateTime.ToShortTimeString() + "</li>";
			if (!string.IsNullOrEmpty(item.CustomerEmail))
			{
				if (text == string.Empty)
				{
					text = item.CustomerEmail;
				}
				else if (text != item.CustomerEmail)
				{
					new frmMessageBox(Resources.Email_could_not_be_sent_becaus, Resources.E_mail0).ShowDialog(this);
					return;
				}
			}
		}
		text2 += "</ul>";
		string subject = Resources.Appointment_Reminder_for + companySetup.Name;
		string message = Resources.This_is_a_friendly_reminder_fr + companySetup.Name + Resources._that_you_have_appointments_on + text2 + Resources._br_br_Please_call0 + companySetup.Phone + Resources._if_you_need_to_cancel_or_chan0 + companySetup.Name;
		if (!string.IsNullOrEmpty(text))
		{
			if (string.IsNullOrEmpty(NotificationMethods.sendEmail(sMTPSettings, text, subject, message)))
			{
				new frmMessageBox(Resources.List_of_appointments_have_been, Resources.E_mail0).ShowDialog(this);
			}
		}
		else
		{
			new frmMessageBox(Resources.Could_not_send_e_mail_No_e_mai, Resources.E_mail0).ShowDialog(this);
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSearchAppointments));
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		panel1 = new Panel();
		label8 = new Label();
		lblDateTime = new Label();
		BtnClose = new Button();
		label15 = new Label();
		timer_0 = new Timer(icontainer_1);
		label1 = new Label();
		label2 = new Label();
		btnSearch = new Button();
		btnRemove = new Button();
		label4 = new Label();
		txtCriteria = new TextBox();
		btnCancelAll = new Button();
		btnUncancel = new Button();
		btnPrint = new Button();
		chkOnlyNew = new CheckBox();
		label3 = new Label();
		btnEmail = new Button();
		lblTrainingMode = new Label();
		panel1.SuspendLayout();
		SuspendLayout();
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[4] { columnHeader_0, columnHeader_1, columnHeader_2, columnHeader_3 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "Customer");
		componentResourceManager.ApplyResources(columnHeader_1, "Appointments");
		componentResourceManager.ApplyResources(columnHeader_2, "Time");
		componentResourceManager.ApplyResources(columnHeader_3, "NoShow");
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.BackColor = Color.FromArgb(234, 234, 234);
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(label8);
		panel1.Controls.Add(lblDateTime);
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(label8, "label8");
		label8.Name = "label8";
		componentResourceManager.ApplyResources(lblDateTime, "lblDateTime");
		lblDateTime.Name = "lblDateTime";
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.BackColor = Color.FromArgb(193, 57, 43);
		BtnClose.DialogResult = DialogResult.OK;
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
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
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(53, 73, 94);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.BackColor = Color.FromArgb(52, 73, 94);
		btnSearch.FlatAppearance.BorderColor = Color.Black;
		btnSearch.FlatAppearance.BorderSize = 0;
		btnSearch.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearch.ForeColor = Color.White;
		btnSearch.Name = "btnSearch";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += btnSearch_Click;
		componentResourceManager.ApplyResources(btnRemove, "btnRemove");
		btnRemove.BackColor = Color.FromArgb(53, 152, 220);
		btnRemove.FlatAppearance.BorderColor = Color.Sienna;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.White;
		btnRemove.ForeColor = Color.White;
		btnRemove.Name = "btnRemove";
		btnRemove.UseVisualStyleBackColor = false;
		btnRemove.Click += btnRemove_Click;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtCriteria, "txtCriteria");
		txtCriteria.Name = "txtCriteria";
		componentResourceManager.ApplyResources(btnCancelAll, "btnCancelAll");
		btnCancelAll.BackColor = Color.FromArgb(241, 196, 15);
		btnCancelAll.FlatAppearance.BorderColor = Color.Sienna;
		btnCancelAll.FlatAppearance.BorderSize = 0;
		btnCancelAll.FlatAppearance.MouseDownBackColor = Color.White;
		btnCancelAll.ForeColor = Color.White;
		btnCancelAll.Name = "btnCancelAll";
		btnCancelAll.UseVisualStyleBackColor = false;
		btnCancelAll.Click += btnCancelAll_Click;
		componentResourceManager.ApplyResources(btnUncancel, "btnUncancel");
		btnUncancel.BackColor = Color.Gray;
		btnUncancel.FlatAppearance.BorderColor = Color.Sienna;
		btnUncancel.FlatAppearance.BorderSize = 0;
		btnUncancel.FlatAppearance.MouseDownBackColor = Color.White;
		btnUncancel.ForeColor = Color.White;
		btnUncancel.Name = "btnUncancel";
		btnUncancel.UseVisualStyleBackColor = false;
		btnUncancel.Click += btnUncancel_Click;
		componentResourceManager.ApplyResources(btnPrint, "btnPrint");
		btnPrint.BackColor = Color.FromArgb(244, 156, 20);
		btnPrint.FlatAppearance.BorderColor = Color.Sienna;
		btnPrint.FlatAppearance.BorderSize = 0;
		btnPrint.FlatAppearance.MouseDownBackColor = Color.White;
		btnPrint.ForeColor = Color.White;
		btnPrint.Name = "btnPrint";
		btnPrint.UseVisualStyleBackColor = false;
		btnPrint.Click += btnPrint_Click;
		componentResourceManager.ApplyResources(chkOnlyNew, "chkOnlyNew");
		chkOnlyNew.Checked = true;
		chkOnlyNew.CheckState = CheckState.Checked;
		chkOnlyNew.Name = "chkOnlyNew";
		chkOnlyNew.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(53, 73, 94);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(btnEmail, "btnEmail");
		btnEmail.BackColor = Color.FromArgb(27, 188, 157);
		btnEmail.FlatAppearance.BorderColor = Color.Sienna;
		btnEmail.FlatAppearance.BorderSize = 0;
		btnEmail.FlatAppearance.MouseDownBackColor = Color.White;
		btnEmail.ForeColor = Color.White;
		btnEmail.Name = "btnEmail";
		btnEmail.UseVisualStyleBackColor = false;
		btnEmail.Click += btnEmail_Click;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(btnEmail);
		base.Controls.Add(label3);
		base.Controls.Add(chkOnlyNew);
		base.Controls.Add(btnPrint);
		base.Controls.Add(btnUncancel);
		base.Controls.Add(btnCancelAll);
		base.Controls.Add(label4);
		base.Controls.Add(txtCriteria);
		base.Controls.Add(btnSearch);
		base.Controls.Add(label2);
		base.Controls.Add(btnRemove);
		base.Controls.Add(label1);
		base.Controls.Add(label15);
		base.Controls.Add(BtnClose);
		base.Controls.Add(panel1);
		base.Controls.Add(lstItems);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSearchAppointments";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.FormClosing += frmSearchAppointments_FormClosing;
		base.Load += frmSearchAppointments_Load;
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
