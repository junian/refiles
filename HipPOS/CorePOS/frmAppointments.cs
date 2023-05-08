using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public class frmAppointments : frmMasterForm
{
	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private Button button_0;

	private Dictionary<string, string> dictionary_0;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private int int_1;

	private IContainer icontainer_1;

	internal ListView lstItems;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	private ComboBox ddlEmployees;

	private Label label1;

	private Label label2;

	private FlowLayoutPanel pnlCalendar;

	internal Button btnPrevMonth;

	internal Button btnNextMonth;

	private Label lblMonth;

	private TextBox txtName;

	private Label label4;

	private Label label5;

	private TextBox txtCell;

	private Label label6;

	private ComboBox ddlStartTime;

	private ComboBox ddlEndTime;

	private Label label7;

	internal Button BtnClose;

	internal Button btnAppointments;

	internal Button btnCopy;

	internal Button btnSendReminder;

	internal Button btnListUnnotified;

	private Label label3;

	private TextBox txtHomePhone;

	private Label label10;

	private TextBox txtEmail;

	private Label label11;

	private Label label12;

	private Label lblSelectedDate;

	private Label label14;

	private Label label15;

	internal Button btnCancel;

	private ComboBox ddlAppointmentEmployees;

	private Label label13;

	internal Button btnSearch;

	internal Button btnMove;

	private Label label16;

	private TextBox txtComments;

	private CheckBox chkNoShow;

	private Label lblTrainingMode;

	internal Button btnShowKeyboard_Name;

	internal Button btnShowKeyboard_Cell;

	internal Button btnShowKeyboard_Home;

	internal Button btnShowKeyboard_Email;

	internal Button btnShowKeyboard_Comments;

	private Button btnGoToday;

	public frmAppointments()
	{
		Class26.Ggkj0JxzN9YmC();
		dictionary_0 = new Dictionary<string, string>();
		int_1 = -1;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
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
		lblSelectedDate.Text = DateTime.Now.ToLongDateString();
	}

	private void frmAppointments_Load(object sender, EventArgs e)
	{
		int_0 = 0;
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstItems.SmallImageList = imageList;
		Dictionary<string, string> employees = EmployeeMethods.getEmployees();
		ddlEmployees.DisplayMember = "Value";
		ddlEmployees.ValueMember = "Key";
		ddlEmployees.DataSource = new BindingSource(employees, null);
		ddlAppointmentEmployees.DisplayMember = "Value";
		ddlAppointmentEmployees.ValueMember = "Key";
		ddlAppointmentEmployees.DataSource = new BindingSource(employees, null);
		dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		method_3(dateTime_0);
		method_7();
		DateTime dateTime = dateTime_1.AddHours(8.0);
		while (dateTime <= dateTime_1.AddHours(20.0))
		{
			string text = dateTime.ToShortTimeString();
			if (text.Length < 8)
			{
				text = "0" + text;
			}
			dictionary_0.Add(text, text);
			dateTime = dateTime.AddMinutes(30.0);
		}
		ddlStartTime.DisplayMember = "Value";
		ddlEndTime.DisplayMember = "Value";
		ddlStartTime.ValueMember = "Key";
		ddlEndTime.ValueMember = "Key";
		ddlStartTime.DataSource = new BindingSource(dictionary_0, null);
		ddlEndTime.DataSource = new BindingSource(dictionary_0, null);
	}

	private void method_3(DateTime dateTime_2)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		lblMonth.Text = new DateTimeFormatInfo().GetMonthName(dateTime_2.Date.Month).ToString() + " " + dateTime_2.Year;
		pnlCalendar.Controls.Clear();
		short num = (short)dateTime_2.DayOfWeek;
		_003C_003Ec__DisplayClass10_.calMonth = dateTime_2.AddDays(-num);
		for (int i = 0; i < 7; i++)
		{
			Label value = method_4(_003C_003Ec__DisplayClass10_.calMonth.AddDays(i).DayOfWeek.ToString().Substring(0, 3).ToUpper());
			pnlCalendar.Controls.Add(value);
		}
		int num2 = DateTime.DaysInMonth(dateTime_2.Year, dateTime_2.Month);
		int num3 = 0;
		int dayOfWeek = (int)dateTime_2.AddDays(num2).DayOfWeek;
		num3 = ((dayOfWeek != 0) ? (num + num2 + (7 - dayOfWeek)) : (num + num2));
		short num4 = (short)(num3 / 7);
		bool bool_ = true;
		if (num4 > 5)
		{
			bool_ = false;
		}
		_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_1();
		CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
		CS_0024_003C_003E8__locals0.x = 0;
		while (true)
		{
			if (CS_0024_003C_003E8__locals0.x >= num3)
			{
				break;
			}
			List<Appointment> list = new GClass6().Appointments.Where((Appointment a) => a.StartDateTime.Date == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Date && a.isCancelled == false).ToList();
			Button value2 = method_5(color_0: (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Month != dateTime_2.Month) ? ((list.Count == 0) ? Color.FromArgb(150, 166, 166) : Color.FromArgb(35, 158, 105)) : ((CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Date == DateTime.Now.Date) ? HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"]) : ((list.Count == 0) ? Color.FromArgb(190, 195, 199) : HelperMethods.GetColor(HelperMethods.ButtonColors()["Green"]))), string_0: CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Day.ToString(), string_1: CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Date.ToString(), eventHandler_0: method_6, bool_2: bool_);
			if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals0.x).Date == DateTime.Now.Date)
			{
				button_0 = value2;
			}
			pnlCalendar.Controls.Add(value2);
			CS_0024_003C_003E8__locals0.x++;
		}
		dateTime_1 = DateTime.Now.Date;
	}

	private Label method_4(string string_0)
	{
		return new Label
		{
			Text = string_0,
			Tag = "lbl" + string_0,
			FlatStyle = FlatStyle.Flat,
			ForeColor = Color.White,
			BackColor = Color.FromArgb(47, 204, 113),
			TextAlign = ContentAlignment.MiddleCenter,
			Size = new Size(49, 32),
			Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular),
			Margin = new Padding(1, 1, 0, 0)
		};
	}

	private Button method_5(string string_0, Color color_0, string string_1, EventHandler eventHandler_0, bool bool_2 = true)
	{
		Button button = new Button();
		button.Text = string_0;
		button.Tag = string_1;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.BackColor = color_0;
		button.Click += eventHandler_0;
		if (bool_2)
		{
			button.Size = new Size(49, 63);
		}
		else
		{
			button.Size = new Size(49, 52);
		}
		button.Font = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Regular);
		button.Margin = new Padding(1, 1, 0, 0);
		return button;
	}

	private void method_6(object sender, EventArgs e)
	{
		int_1 = -1;
		Button button = (Button)sender;
		if (button_0 != null)
		{
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
			CS_0024_003C_003E8__locals0.prevSelectedDate = DateTime.Parse(button_0.Tag.ToString()).Date;
			List<Appointment> list = new GClass6().Appointments.Where((Appointment a) => a.StartDateTime.Date == CS_0024_003C_003E8__locals0.prevSelectedDate && a.isCancelled == false).ToList();
			if (dateTime_0.Month != CS_0024_003C_003E8__locals0.prevSelectedDate.Month)
			{
				if (list.Count != 0)
				{
					button_0.BackColor = Color.FromArgb(35, 158, 116);
				}
				else
				{
					button_0.BackColor = Color.FromArgb(150, 166, 166);
				}
			}
			else if (CS_0024_003C_003E8__locals0.prevSelectedDate == DateTime.Now.Date)
			{
				button_0.BackColor = Color.FromArgb(244, 156, 20);
			}
			else if (list.Count != 0)
			{
				button_0.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Green"]);
			}
			else
			{
				button_0.BackColor = Color.FromArgb(190, 195, 199);
			}
		}
		button.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"]);
		dateTime_1 = DateTime.Parse(button.Tag.ToString());
		button_0 = button;
		method_7();
		lblSelectedDate.Text = dateTime_1.ToLongDateString();
		if (!bool_0 && !bool_1)
		{
			int_0 = 0;
			Button button2 = btnCancel;
			Button button3 = btnMove;
			btnCopy.Enabled = false;
			button3.Enabled = false;
			button2.Enabled = false;
			Button button4 = btnMove;
			Button button5 = btnCancel;
			Color color2 = (btnCopy.BackColor = HelperMethods.GetColor("Gray"));
			Color color5 = (button4.BackColor = (button5.BackColor = color2));
			method_9();
		}
	}

	private void btnPrevMonth_Click(object sender, EventArgs e)
	{
		dateTime_0 = dateTime_0.AddMonths(-1);
		method_3(dateTime_0);
	}

	private void btnNextMonth_Click(object sender, EventArgs e)
	{
		dateTime_0 = dateTime_0.AddMonths(1);
		method_3(dateTime_0);
	}

	private void method_7()
	{
		if (dateTime_1 < DateTime.Now.AddYears(-10))
		{
			return;
		}
		lstItems.Items.Clear();
		List<Appointment> source = new GClass6().Appointments.Where((Appointment a) => a.StartDateTime.Date == dateTime_1.Date && a.isCancelled == false && a.EmployeeID == Convert.ToInt32(ddlEmployees.SelectedValue)).ToList();
		Color color = HelperMethods.GetColor(HelperMethods.ButtonColors()["Green"]);
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.sched = dateTime_1.AddHours(8.0);
		while (CS_0024_003C_003E8__locals0.sched <= dateTime_1.AddHours(20.0))
		{
			string text = CS_0024_003C_003E8__locals0.sched.ToShortTimeString();
			if (text.Length < 8)
			{
				text = "0" + text;
			}
			Appointment appointment = source.Where((Appointment a) => a.StartDateTime == CS_0024_003C_003E8__locals0.sched).FirstOrDefault();
			if (appointment != null)
			{
				HelperMethods.ButtonColors();
				ListViewItem value = new ListViewItem(new string[3]
				{
					text,
					appointment.CustomerName + " - " + (string.IsNullOrEmpty(appointment.CustomerCell) ? appointment.CustomerHome : appointment.CustomerCell),
					appointment.AppointmentID.ToString()
				});
				lstItems.Items.Add(value);
				lstItems.Items[lstItems.Items.Count - 1].BackColor = color;
				DateTime dateTime = CS_0024_003C_003E8__locals0.sched.AddMinutes(30.0);
				while (dateTime < appointment.EndDateTime.AddMinutes(-1.0))
				{
					CS_0024_003C_003E8__locals0.sched = dateTime;
					text = CS_0024_003C_003E8__locals0.sched.ToShortTimeString();
					if (text.Length < 8)
					{
						text = "0" + text;
					}
					value = new ListViewItem(new string[3]
					{
						text,
						"----",
						appointment.AppointmentID.ToString()
					});
					lstItems.Items.Add(value);
					lstItems.Items[lstItems.Items.Count - 1].BackColor = color;
					dateTime = dateTime.AddMinutes(30.0);
				}
			}
			else
			{
				ListViewItem value = new ListViewItem(new string[3]
				{
					text,
					string.Empty,
					string.Empty
				});
				lstItems.Items.Add(value);
				lstItems.Items[lstItems.Items.Count - 1].BackColor = Color.FromName("White");
			}
			CS_0024_003C_003E8__locals0.sched = CS_0024_003C_003E8__locals0.sched.AddMinutes(30.0);
		}
	}

	private void btnAppointments_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_8(DateTime? nullable_0 = null, DateTime? nullable_1 = null)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		if (txtName.Text == string.Empty)
		{
			new frmMessageBox(Resources.Customer_Name_cannot_be_empty).ShowDialog(this);
			return;
		}
		Regex regex = new Regex("^\\d{10}$");
		if (!string.IsNullOrEmpty(txtCell.Text) && !regex.Match(txtCell.Text).Success)
		{
			new frmMessageBox(Resources.Cell_phone_number_is_not_in_co).ShowDialog(this);
			return;
		}
		if (!string.IsNullOrEmpty(txtHomePhone.Text) && !regex.Match(txtHomePhone.Text).Success)
		{
			new frmMessageBox(Resources.Home_phone_number_is_not_in_co).ShowDialog(this);
			return;
		}
		if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase))
		{
			new frmMessageBox(Resources.E_mail_address_is_not_in_corre).ShowDialog(this);
			return;
		}
		CS_0024_003C_003E8__locals0.start = (nullable_0.HasValue ? nullable_0.Value : Convert.ToDateTime(dateTime_1.Date.ToLongDateString() + " " + ddlStartTime.SelectedValue));
		if (nullable_0.HasValue)
		{
			CS_0024_003C_003E8__locals0.start = nullable_0.Value;
		}
		CS_0024_003C_003E8__locals0.end = (nullable_1.HasValue ? nullable_1.Value : Convert.ToDateTime(dateTime_1.Date.ToLongDateString() + " " + ddlEndTime.SelectedValue).AddSeconds(-1.0));
		if (nullable_1.HasValue)
		{
			CS_0024_003C_003E8__locals0.end = nullable_1.Value;
		}
		if (!(CS_0024_003C_003E8__locals0.start < DateTime.Now) && !(CS_0024_003C_003E8__locals0.end < DateTime.Now))
		{
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.end = CS_0024_003C_003E8__locals0.end.AddSeconds(-1.0);
			Appointment appointment = gClass.Appointments.Where((Appointment a) => ((a.StartDateTime >= CS_0024_003C_003E8__locals0.start && a.StartDateTime <= CS_0024_003C_003E8__locals0.end) || (a.EndDateTime >= CS_0024_003C_003E8__locals0.start && a.EndDateTime <= CS_0024_003C_003E8__locals0.end)) && a.AppointmentID != int_0 && a.EmployeeID == Convert.ToInt32(ddlEmployees.SelectedValue) && a.isCancelled == false).FirstOrDefault();
			if (appointment != null)
			{
				new frmMessageBox(Resources.There_is_a_schedule_conflict_p).ShowDialog(this);
				return;
			}
			if (int_0 == 0)
			{
				appointment = new Appointment();
				gClass.Appointments.InsertOnSubmit(appointment);
			}
			else
			{
				appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == int_0).FirstOrDefault();
			}
			appointment.StartDateTime = CS_0024_003C_003E8__locals0.start;
			appointment.EndDateTime = CS_0024_003C_003E8__locals0.end;
			if (appointment.StartDateTime == appointment.EndDateTime)
			{
				new frmMessageBox(Resources.Start_end_time_cannot_be_the_s).ShowDialog(this);
				return;
			}
			if (appointment.StartDateTime > appointment.EndDateTime)
			{
				new frmMessageBox(Resources.Start_end_time_cannot_be_the_s).ShowDialog(this);
				return;
			}
			appointment.CustomerName = txtName.Text;
			appointment.CustomerCell = txtCell.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
				.Trim();
			appointment.CustomerHome = txtHomePhone.Text.Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty)
				.Trim();
			appointment.CustomerEmail = txtEmail.Text;
			appointment.Comments = txtComments.Text;
			appointment.DateCreated = DateTime.Now;
			appointment.EmployeeID = Convert.ToInt32(ddlAppointmentEmployees.SelectedValue);
			appointment.isNoShow = chkNoShow.Checked;
			appointment.SMSSent = false;
			appointment.EmailSent = false;
			Helper.SubmitChangesWithCatch(gClass);
			int_0 = appointment.AppointmentID;
			new frmMessageBox(Resources.Appointment_Saved).ShowDialog(this);
			method_9();
			method_7();
			bool_1 = false;
			bool_0 = false;
		}
		else
		{
			new frmMessageBox(Resources.The_date_and_time_selected_has).ShowDialog(this);
		}
	}

	private void method_9()
	{
		txtCell.Text = string.Empty;
		txtEmail.Text = string.Empty;
		txtHomePhone.Text = string.Empty;
		txtName.Text = string.Empty;
		txtComments.Text = string.Empty;
		chkNoShow.Checked = false;
		btnMove.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Blue"]);
		btnMove.Text = Resources.MOVE;
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedIndices.Count <= 0)
		{
			return;
		}
		if (!bool_0 && !bool_1)
		{
			if (lstItems.SelectedItems[0].SubItems[2].Text == string.Empty)
			{
				int_0 = 0;
			}
			else
			{
				int_0 = Convert.ToInt32(lstItems.SelectedItems[0].SubItems[2].Text);
			}
			if (int_0 > 0)
			{
				Appointment appointment = new GClass6().Appointments.Where((Appointment a) => a.AppointmentID == int_0).FirstOrDefault();
				if (appointment != null)
				{
					txtCell.Text = appointment.CustomerCell;
					txtEmail.Text = appointment.CustomerEmail;
					txtHomePhone.Text = appointment.CustomerHome;
					txtName.Text = appointment.CustomerName;
					txtComments.Text = appointment.Comments;
					ddlAppointmentEmployees.SelectedValue = appointment.EmployeeID.ToString();
					chkNoShow.Checked = appointment.isNoShow;
					ddlStartTime.SelectedValue = ((appointment.StartDateTime.ToShortTimeString().Length < 8) ? ("0" + appointment.StartDateTime.ToShortTimeString()) : appointment.StartDateTime.ToShortTimeString());
					ddlEndTime.SelectedValue = ((appointment.EndDateTime.AddMinutes(1.0).ToShortTimeString().Length < 8) ? ("0" + appointment.EndDateTime.AddMinutes(1.0).ToShortTimeString()) : appointment.EndDateTime.AddMinutes(1.0).ToShortTimeString());
					btnCancel.Enabled = true;
					btnCopy.Enabled = true;
					btnMove.Enabled = true;
					btnCancel.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Turquoise"]);
					btnCopy.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"]);
					btnMove.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Blue"]);
					if (Convert.ToDateTime(dateTime_1.ToLongDateString() + " " + ddlStartTime.SelectedValue) > DateTime.Now)
					{
						chkNoShow.Enabled = false;
					}
					else
					{
						chkNoShow.Enabled = true;
					}
				}
			}
			else
			{
				Button button = btnCancel;
				Button button2 = btnMove;
				btnCopy.Enabled = false;
				button2.Enabled = false;
				button.Enabled = false;
				Button button3 = btnMove;
				Button button4 = btnCancel;
				Color color2 = (btnCopy.BackColor = HelperMethods.GetColor("Gray"));
				Color color5 = (button3.BackColor = (button4.BackColor = color2));
				method_9();
				ddlStartTime.SelectedValue = lstItems.SelectedItems[0].SubItems[0].Text;
				if (lstItems.SelectedItems[0].Index == lstItems.Items.Count - 1)
				{
					ddlEndTime.SelectedValue = lstItems.Items[lstItems.SelectedItems[0].Index].SubItems[0].Text;
					ddlEndTime.SelectedIndex += 1;
				}
				else
				{
					ddlEndTime.SelectedValue = lstItems.Items[lstItems.SelectedItems[0].Index + 1].SubItems[0].Text;
				}
				chkNoShow.Enabled = false;
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(lstItems.SelectedItems[0].SubItems[1].Text.Trim()))
			{
				new frmMessageBox(Resources.Cannot_save_appointment_in_thi, Resources.Conflict).ShowDialog(this);
				return;
			}
			DateTime value = Convert.ToDateTime(dateTime_1.Date.ToLongDateString() + " " + lstItems.SelectedItems[0].SubItems[0].Text);
			DateTime value2 = value.AddMinutes(30.0);
			int_1 = lstItems.SelectedItems[0].Index;
			method_8(value, value2);
			lstItems.Items[int_1].Selected = true;
		}
		if (int_1 > -1)
		{
			if (lstItems.Items[int_1].SubItems[1].Text.Trim() != string.Empty)
			{
				lstItems.Items[int_1].BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Green"]);
			}
			else
			{
				lstItems.Items[int_1].BackColor = Color.FromName("White");
			}
		}
		lstItems.SelectedItems[0].BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"]);
		int_1 = lstItems.SelectedItems[0].Index;
	}

	private void method_10()
	{
	}

	private void ddlStartTime_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlEndTime.Items.Count <= 2 || ddlStartTime.SelectedIndex < ddlEndTime.SelectedIndex)
		{
			return;
		}
		if (ddlStartTime.SelectedIndex + 1 == ddlEndTime.Items.Count)
		{
			string text = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + dictionary_0.Last().Value).AddMinutes(30.0).ToShortTimeString();
			if (text.Length < 8)
			{
				text = "0" + text;
			}
			dictionary_0.Add(text, text);
			ddlEndTime.DataSource = new BindingSource(dictionary_0, null);
			ddlEndTime.SelectedIndex = ddlEndTime.Items.Count - 1;
		}
		else
		{
			ddlEndTime.SelectedIndex = ddlStartTime.SelectedIndex + 1;
		}
	}

	private void btnListUnnotified_Click(object sender, EventArgs e)
	{
		new frmSendReminders(_isManual: true).Show();
	}

	private void btnSendReminder_Click(object sender, EventArgs e)
	{
		new frmSendReminders().Show();
	}

	private void btnCopy_Click(object sender, EventArgs e)
	{
		if (int_0 == 0)
		{
			new frmMessageBox(Resources.Please_select_load_an_appointm, Resources.Warning1).ShowDialog(this);
			bool_1 = false;
		}
		else
		{
			int_0 = 0;
			new frmMessageBox(Resources.COPIED_Please_select_new_date_, Resources.Copy).ShowDialog(this);
			bool_1 = true;
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox(Resources.Are_you_sure_you_want_to_cance0, Resources.Warning_Cancel_Appointment, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			GClass6 gClass = new GClass6();
			Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == int_0).FirstOrDefault();
			if (appointment != null)
			{
				appointment.isCancelled = true;
				Helper.SubmitChangesWithCatch(gClass);
				method_7();
			}
		}
	}

	private void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
	{
		ddlAppointmentEmployees.SelectedValue = ddlEmployees.SelectedValue;
		method_7();
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		if (new frmSearchAppointments().ShowDialog(this) == DialogResult.OK)
		{
			method_7();
		}
	}

	private void btnMove_Click(object sender, EventArgs e)
	{
		if (int_0 == 0)
		{
			new frmMessageBox(Resources.Please_select_load_an_appointm, Resources.Warning1).ShowDialog(this);
			bool_0 = false;
		}
		else if (btnMove.Text == Resources.MOVE)
		{
			new frmMessageBox(Resources.Please_select_new_date_and_the, Resources.Move0).ShowDialog(this);
			bool_0 = true;
			btnMove.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Orange"]);
			btnMove.Text = Resources.CANCEL_MOVE;
		}
		else
		{
			bool_0 = false;
			btnMove.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Blue"]);
			btnMove.Text = Resources.MOVE;
		}
	}

	private void txtName_TextChanged(object sender, EventArgs e)
	{
	}

	protected void chkNoShow_Click(object sender, EventArgs e)
	{
		if (int_0 != 0)
		{
			GClass6 gClass = new GClass6();
			Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentID == int_0).FirstOrDefault();
			if (appointment != null)
			{
				appointment.isNoShow = chkNoShow.Checked;
				Helper.SubmitChangesWithCatch(gClass);
				new frmMessageBox(Resources._No_Show_info_saved, Resources.No_Show).ShowDialog(this);
			}
		}
	}

	private void btnShowKeyboard_Cell_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Cell_Phone_number0, 0, 11);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtCell.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void btnShowKeyboard_Home_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Home_Phone_number0, 0, 11);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtHomePhone.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Name);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void btnShowKeyboard_Email_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_E_mail);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtEmail.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void btnShowKeyboard_Comments_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Comments0);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtComments.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void txtComments_GotFocus(object sender, EventArgs e)
	{
	}

	private void btnGoToday_Click(object sender, EventArgs e)
	{
		dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		method_3(dateTime_0);
		method_7();
		lblSelectedDate.Text = DateTime.Now.ToLongDateString();
	}

	private void txtEmail_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAppointments));
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		ddlEmployees = new ComboBox();
		label1 = new Label();
		label2 = new Label();
		pnlCalendar = new FlowLayoutPanel();
		btnPrevMonth = new Button();
		btnNextMonth = new Button();
		lblMonth = new Label();
		txtName = new TextBox();
		label4 = new Label();
		label5 = new Label();
		txtCell = new TextBox();
		label6 = new Label();
		ddlStartTime = new ComboBox();
		ddlEndTime = new ComboBox();
		label7 = new Label();
		BtnClose = new Button();
		btnAppointments = new Button();
		btnCopy = new Button();
		btnSendReminder = new Button();
		btnListUnnotified = new Button();
		label3 = new Label();
		txtHomePhone = new TextBox();
		label10 = new Label();
		txtEmail = new TextBox();
		label11 = new Label();
		label12 = new Label();
		lblSelectedDate = new Label();
		label14 = new Label();
		label15 = new Label();
		btnCancel = new Button();
		ddlAppointmentEmployees = new ComboBox();
		label13 = new Label();
		btnSearch = new Button();
		btnMove = new Button();
		label16 = new Label();
		txtComments = new TextBox();
		chkNoShow = new CheckBox();
		lblTrainingMode = new Label();
		btnShowKeyboard_Name = new Button();
		btnShowKeyboard_Cell = new Button();
		btnShowKeyboard_Home = new Button();
		btnShowKeyboard_Email = new Button();
		btnShowKeyboard_Comments = new Button();
		btnGoToday = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(50, 200);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "Time");
		componentResourceManager.ApplyResources(columnHeader_1, "Appointments");
		ddlEmployees.BackColor = Color.WhiteSmoke;
		ddlEmployees.DropDownHeight = 200;
		ddlEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlEmployees, "ddlEmployees");
		ddlEmployees.FormattingEnabled = true;
		ddlEmployees.Name = "ddlEmployees";
		ddlEmployees.SelectedIndexChanged += ddlEmployees_SelectedIndexChanged;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.FromArgb(53, 73, 94);
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(53, 73, 94);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		pnlCalendar.BackColor = Color.Transparent;
		pnlCalendar.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(pnlCalendar, "pnlCalendar");
		pnlCalendar.Name = "pnlCalendar";
		btnPrevMonth.BackColor = Color.FromArgb(27, 188, 157);
		btnPrevMonth.FlatAppearance.BorderColor = Color.Black;
		btnPrevMonth.FlatAppearance.BorderSize = 0;
		btnPrevMonth.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnPrevMonth, "btnPrevMonth");
		btnPrevMonth.ForeColor = Color.White;
		btnPrevMonth.Name = "btnPrevMonth";
		btnPrevMonth.UseVisualStyleBackColor = false;
		btnPrevMonth.Click += btnPrevMonth_Click;
		btnNextMonth.BackColor = Color.FromArgb(27, 188, 157);
		btnNextMonth.FlatAppearance.BorderColor = Color.Black;
		btnNextMonth.FlatAppearance.BorderSize = 0;
		btnNextMonth.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnNextMonth, "btnNextMonth");
		btnNextMonth.ForeColor = Color.White;
		btnNextMonth.Name = "btnNextMonth";
		btnNextMonth.UseVisualStyleBackColor = false;
		btnNextMonth.Click += btnNextMonth_Click;
		lblMonth.BackColor = Color.FromArgb(244, 156, 20);
		componentResourceManager.ApplyResources(lblMonth, "lblMonth");
		lblMonth.ForeColor = Color.White;
		lblMonth.Name = "lblMonth";
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.BackColor = Color.White;
		txtName.BorderStyle = BorderStyle.FixedSingle;
		txtName.Name = "txtName";
		txtName.Click += txtEmail_Click;
		txtName.TextChanged += txtName_TextChanged;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.BackColor = Color.FromArgb(1, 110, 211);
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(label5, "label5");
		label5.BackColor = Color.FromArgb(53, 152, 220);
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(txtCell, "txtCell");
		txtCell.BackColor = Color.White;
		txtCell.BorderStyle = BorderStyle.FixedSingle;
		txtCell.Name = "txtCell";
		txtCell.Click += txtEmail_Click;
		txtCell.GotFocus += txtComments_GotFocus;
		componentResourceManager.ApplyResources(label6, "label6");
		label6.BackColor = Color.FromArgb(231, 126, 35);
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(ddlStartTime, "ddlStartTime");
		ddlStartTime.BackColor = Color.WhiteSmoke;
		ddlStartTime.DropDownHeight = 200;
		ddlStartTime.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlStartTime.FormattingEnabled = true;
		ddlStartTime.Name = "ddlStartTime";
		ddlStartTime.SelectedIndexChanged += ddlStartTime_SelectedIndexChanged;
		componentResourceManager.ApplyResources(ddlEndTime, "ddlEndTime");
		ddlEndTime.BackColor = Color.WhiteSmoke;
		ddlEndTime.DropDownHeight = 200;
		ddlEndTime.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlEndTime.FormattingEnabled = true;
		ddlEndTime.Name = "ddlEndTime";
		componentResourceManager.ApplyResources(label7, "label7");
		label7.BackColor = Color.FromArgb(156, 89, 184);
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.BackColor = Color.FromArgb(193, 57, 43);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		componentResourceManager.ApplyResources(btnAppointments, "btnAppointments");
		btnAppointments.BackColor = Color.FromArgb(47, 204, 113);
		btnAppointments.FlatAppearance.BorderColor = Color.Black;
		btnAppointments.FlatAppearance.BorderSize = 0;
		btnAppointments.FlatAppearance.MouseDownBackColor = Color.White;
		btnAppointments.ForeColor = Color.White;
		btnAppointments.Name = "btnAppointments";
		btnAppointments.UseVisualStyleBackColor = false;
		btnAppointments.Click += btnAppointments_Click;
		componentResourceManager.ApplyResources(btnCopy, "btnCopy");
		btnCopy.BackColor = Color.Gray;
		btnCopy.FlatAppearance.BorderColor = Color.Black;
		btnCopy.FlatAppearance.BorderSize = 0;
		btnCopy.FlatAppearance.MouseDownBackColor = Color.White;
		btnCopy.ForeColor = Color.White;
		btnCopy.Name = "btnCopy";
		btnCopy.UseVisualStyleBackColor = false;
		btnCopy.Click += btnCopy_Click;
		componentResourceManager.ApplyResources(btnSendReminder, "btnSendReminder");
		btnSendReminder.BackColor = Color.FromArgb(156, 89, 184);
		btnSendReminder.FlatAppearance.BorderColor = Color.Black;
		btnSendReminder.FlatAppearance.BorderSize = 0;
		btnSendReminder.FlatAppearance.MouseDownBackColor = Color.White;
		btnSendReminder.ForeColor = Color.White;
		btnSendReminder.Name = "btnSendReminder";
		btnSendReminder.UseVisualStyleBackColor = false;
		btnSendReminder.Click += btnSendReminder_Click;
		componentResourceManager.ApplyResources(btnListUnnotified, "btnListUnnotified");
		btnListUnnotified.BackColor = Color.FromArgb(143, 68, 173);
		btnListUnnotified.FlatAppearance.BorderColor = Color.Black;
		btnListUnnotified.FlatAppearance.BorderSize = 0;
		btnListUnnotified.FlatAppearance.MouseDownBackColor = Color.White;
		btnListUnnotified.ForeColor = Color.White;
		btnListUnnotified.Name = "btnListUnnotified";
		btnListUnnotified.UseVisualStyleBackColor = false;
		btnListUnnotified.Click += btnListUnnotified_Click;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(27, 188, 157);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtHomePhone, "txtHomePhone");
		txtHomePhone.BackColor = Color.White;
		txtHomePhone.BorderStyle = BorderStyle.FixedSingle;
		txtHomePhone.Name = "txtHomePhone";
		txtHomePhone.Click += txtEmail_Click;
		txtHomePhone.GotFocus += txtComments_GotFocus;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(47, 204, 113);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(txtEmail, "txtEmail");
		txtEmail.BackColor = Color.White;
		txtEmail.BorderStyle = BorderStyle.FixedSingle;
		txtEmail.Name = "txtEmail";
		txtEmail.Click += txtEmail_Click;
		txtEmail.GotFocus += txtComments_GotFocus;
		componentResourceManager.ApplyResources(label11, "label11");
		label11.BackColor = Color.FromArgb(53, 73, 94);
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		componentResourceManager.ApplyResources(label12, "label12");
		label12.BackColor = Color.FromArgb(53, 73, 94);
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		componentResourceManager.ApplyResources(lblSelectedDate, "lblSelectedDate");
		lblSelectedDate.BackColor = Color.WhiteSmoke;
		lblSelectedDate.ForeColor = Color.Black;
		lblSelectedDate.Name = "lblSelectedDate";
		componentResourceManager.ApplyResources(label14, "label14");
		label14.BackColor = Color.FromArgb(244, 156, 20);
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		componentResourceManager.ApplyResources(label15, "label15");
		label15.BackColor = Color.FromArgb(53, 73, 94);
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.BackColor = Color.Gray;
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(ddlAppointmentEmployees, "ddlAppointmentEmployees");
		ddlAppointmentEmployees.BackColor = Color.WhiteSmoke;
		ddlAppointmentEmployees.DropDownHeight = 200;
		ddlAppointmentEmployees.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlAppointmentEmployees.FormattingEnabled = true;
		ddlAppointmentEmployees.Name = "ddlAppointmentEmployees";
		componentResourceManager.ApplyResources(label13, "label13");
		label13.BackColor = Color.FromArgb(231, 126, 35);
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.BackColor = Color.FromArgb(52, 73, 94);
		btnSearch.FlatAppearance.BorderColor = Color.Black;
		btnSearch.FlatAppearance.BorderSize = 0;
		btnSearch.FlatAppearance.MouseDownBackColor = Color.White;
		btnSearch.ForeColor = Color.White;
		btnSearch.Name = "btnSearch";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += btnSearch_Click;
		componentResourceManager.ApplyResources(btnMove, "btnMove");
		btnMove.BackColor = Color.Gray;
		btnMove.FlatAppearance.BorderColor = Color.Black;
		btnMove.FlatAppearance.BorderSize = 0;
		btnMove.FlatAppearance.MouseDownBackColor = Color.White;
		btnMove.ForeColor = Color.White;
		btnMove.Name = "btnMove";
		btnMove.UseVisualStyleBackColor = false;
		btnMove.Click += btnMove_Click;
		componentResourceManager.ApplyResources(label16, "label16");
		label16.BackColor = Color.FromArgb(53, 73, 94);
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		componentResourceManager.ApplyResources(txtComments, "txtComments");
		txtComments.BackColor = Color.White;
		txtComments.BorderStyle = BorderStyle.FixedSingle;
		txtComments.Name = "txtComments";
		txtComments.GotFocus += txtComments_GotFocus;
		componentResourceManager.ApplyResources(chkNoShow, "chkNoShow");
		chkNoShow.Name = "chkNoShow";
		chkNoShow.UseVisualStyleBackColor = true;
		chkNoShow.Click += chkNoShow_Click;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.BackColor = Color.FromArgb(52, 73, 94);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Cell, "btnShowKeyboard_Cell");
		btnShowKeyboard_Cell.BackColor = Color.FromArgb(52, 73, 94);
		btnShowKeyboard_Cell.DialogResult = DialogResult.OK;
		btnShowKeyboard_Cell.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Cell.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Cell.ForeColor = Color.White;
		btnShowKeyboard_Cell.Name = "btnShowKeyboard_Cell";
		btnShowKeyboard_Cell.UseVisualStyleBackColor = false;
		btnShowKeyboard_Cell.Click += btnShowKeyboard_Cell_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Home, "btnShowKeyboard_Home");
		btnShowKeyboard_Home.BackColor = Color.FromArgb(52, 73, 94);
		btnShowKeyboard_Home.DialogResult = DialogResult.OK;
		btnShowKeyboard_Home.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Home.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Home.ForeColor = Color.White;
		btnShowKeyboard_Home.Name = "btnShowKeyboard_Home";
		btnShowKeyboard_Home.UseVisualStyleBackColor = false;
		btnShowKeyboard_Home.Click += btnShowKeyboard_Home_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Email, "btnShowKeyboard_Email");
		btnShowKeyboard_Email.BackColor = Color.FromArgb(52, 73, 94);
		btnShowKeyboard_Email.DialogResult = DialogResult.OK;
		btnShowKeyboard_Email.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Email.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Email.ForeColor = Color.White;
		btnShowKeyboard_Email.Name = "btnShowKeyboard_Email";
		btnShowKeyboard_Email.UseVisualStyleBackColor = false;
		btnShowKeyboard_Email.Click += btnShowKeyboard_Email_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_Comments, "btnShowKeyboard_Comments");
		btnShowKeyboard_Comments.BackColor = Color.FromArgb(52, 73, 94);
		btnShowKeyboard_Comments.DialogResult = DialogResult.OK;
		btnShowKeyboard_Comments.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Comments.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Comments.ForeColor = Color.White;
		btnShowKeyboard_Comments.Name = "btnShowKeyboard_Comments";
		btnShowKeyboard_Comments.UseVisualStyleBackColor = false;
		btnShowKeyboard_Comments.Click += btnShowKeyboard_Comments_Click;
		btnGoToday.BackColor = Color.FromArgb(244, 156, 20);
		btnGoToday.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnGoToday, "btnGoToday");
		btnGoToday.ForeColor = SystemColors.ButtonHighlight;
		btnGoToday.Name = "btnGoToday";
		btnGoToday.UseVisualStyleBackColor = false;
		btnGoToday.Click += btnGoToday_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.Controls.Add(btnGoToday);
		base.Controls.Add(btnShowKeyboard_Comments);
		base.Controls.Add(btnShowKeyboard_Email);
		base.Controls.Add(btnShowKeyboard_Home);
		base.Controls.Add(btnShowKeyboard_Cell);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(chkNoShow);
		base.Controls.Add(txtComments);
		base.Controls.Add(label16);
		base.Controls.Add(btnMove);
		base.Controls.Add(btnSearch);
		base.Controls.Add(ddlAppointmentEmployees);
		base.Controls.Add(label13);
		base.Controls.Add(btnCancel);
		base.Controls.Add(label15);
		base.Controls.Add(label14);
		base.Controls.Add(lblSelectedDate);
		base.Controls.Add(label12);
		base.Controls.Add(label11);
		base.Controls.Add(label10);
		base.Controls.Add(txtEmail);
		base.Controls.Add(label3);
		base.Controls.Add(txtHomePhone);
		base.Controls.Add(btnListUnnotified);
		base.Controls.Add(btnSendReminder);
		base.Controls.Add(btnCopy);
		base.Controls.Add(btnAppointments);
		base.Controls.Add(BtnClose);
		base.Controls.Add(ddlEndTime);
		base.Controls.Add(label7);
		base.Controls.Add(ddlStartTime);
		base.Controls.Add(label6);
		base.Controls.Add(label5);
		base.Controls.Add(txtCell);
		base.Controls.Add(label4);
		base.Controls.Add(txtName);
		base.Controls.Add(lblMonth);
		base.Controls.Add(btnNextMonth);
		base.Controls.Add(btnPrevMonth);
		base.Controls.Add(pnlCalendar);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(ddlEmployees);
		base.Controls.Add(lstItems);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAppointments";
		base.Opacity = 1.0;
		base.Load += frmAppointments_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
