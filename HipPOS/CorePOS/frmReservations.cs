using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmReservations : frmMasterForm
{
	private DataManager dataManager_0;

	private FormHelper formHelper_0;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private GClass6 gclass6_0;

	private Button button_0;

	private long long_0;

	private int int_0;

	private bool bool_0;

	private List<BusinessHour> list_2;

	private int? nullable_0;

	private IContainer icontainer_1;

	internal ListView lstItems;

	internal ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	internal Button KeUzIgehbp;

	internal Button BtnClose;

	private ColumnHeader columnHeader_2;

	internal Button gmcziSlvhg;

	internal Button btnNextMonth;

	private Label lblMonth;

	internal Button btnPrevMonth;

	private FlowLayoutPanel pnlCalendar;

	private Label label2;

	private Label lblTrainingMode;

	private Label label12;

	private Label label1;

	private Label label8;

	private Label label7;

	private TextBox txtComments;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label9;

	private Label label14;

	private Label lblSelectedDate;

	internal Button btnNew;

	internal Button btnShowKeyboard_Comments;

	internal Button btnShowKeyboard_NumOfPeople;

	internal Button btnShowKeyboard_Phone;

	private Button btnShowKeyboard_Name;

	private Label label10;

	private RadTextBoxControl txtName;

	private RadTextBoxControl txtPhone;

	private RadTextBoxControl txtNumOfPeople;

	private RadToggleSwitch chkShowAll;

	private Label label13;

	private RadTextBoxControl txtEmail;

	internal Button btnShowKeyboard_Email;

	private ColumnHeader columnHeader_3;

	private Label label15;

	private Label label16;

	private Label label17;

	private Label label18;

	internal Button btnAssign;

	internal Button btnMove;

	private Label lblMoveMode;

	private ColumnHeader columnHeader_4;

	private Label label19;

	internal Button btnSendMail;

	internal Button btnSendText;

	private DateTimePicker startTimePicker;

	private Label label3;

	private Label label11;

	internal Button btnPrintInfo;

	public frmReservations(int _employeeID)
	{
		Class26.Ggkj0JxzN9YmC();
		dataManager_0 = new DataManager();
		formHelper_0 = new FormHelper();
		gclass6_0 = new GClass6();
		base._002Ector();
		Yewzlloqkn();
		new FormHelper().ResizeButtonFonts(this);
		list_2 = gclass6_0.BusinessHours.ToList();
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			chkShowAll.Font = new Font(chkShowAll.Font.FontFamily, chkShowAll.Font.Size - 1.25f);
			chkShowAll.OffText = "AFFICHER TOUS : NON";
			chkShowAll.OnText = "AFFICHER TOUS : OUI";
			method_16();
		}
		if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isCurrentlyTrainingMode"]))
		{
			lblTrainingMode.Visible = true;
		}
		else
		{
			lblTrainingMode.Visible = false;
		}
		dateTime_1 = DateTime.Now;
		lblSelectedDate.Text = dateTime_1.ToLongDateString();
		int_0 = _employeeID;
		KeUzIgehbp.Enabled = false;
		btnNew.Enabled = false;
		method_13();
	}

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private bool method_3(BusinessHour businessHour_0, DateTime dateTime_2)
	{
		DateTime dateTime = default(DateTime);
		DateTime dateTime2 = default(DateTime);
		string[] array = businessHour_0.LatestOpeningTime.Split(':');
		int num = Convert.ToInt32(array[0]);
		int num2 = Convert.ToInt32(array[1]);
		int num3 = Convert.ToInt32(array[2]);
		string[] array2 = businessHour_0.LatestClosingTime.Split(':');
		int num4 = Convert.ToInt32(array2[0]);
		int num5 = Convert.ToInt32(array2[1]);
		int num6 = Convert.ToInt32(array2[2]);
		dateTime = ((num >= 12) ? Convert.ToDateTime(lblSelectedDate.Text + " " + businessHour_0.LatestOpeningTime + " PM") : Convert.ToDateTime(lblSelectedDate.Text + " " + businessHour_0.LatestOpeningTime + " AM"));
		dateTime2 = ((num4 >= 12) ? Convert.ToDateTime(lblSelectedDate.Text + " " + businessHour_0.LatestClosingTime + " PM") : Convert.ToDateTime(lblSelectedDate.Text + " " + businessHour_0.LatestClosingTime + " AM"));
		if (num == num4)
		{
			if (num2 == num5)
			{
				if (num3 != num6 && num3 > num6)
				{
					dateTime2 = dateTime2.AddDays(1.0);
				}
			}
			else if (num2 > num5)
			{
				dateTime2 = dateTime2.AddDays(1.0);
			}
		}
		else if (num >= num4)
		{
			dateTime2 = dateTime2.AddDays(1.0);
		}
		if (dateTime_2 >= dateTime)
		{
			return dateTime_2 <= dateTime2;
		}
		return false;
	}

	private void KeUzIgehbp_Click(object sender, EventArgs e)
	{
		DateTime dateTime;
		try
		{
			dateTime = Convert.ToDateTime(lblSelectedDate.Text).Date.AddHours(startTimePicker.Value.Hour).AddMinutes(startTimePicker.Value.Minute);
		}
		catch
		{
			new frmMessageBox(Resources.Please_select_correct_date_and).ShowDialog(this);
			return;
		}
		if (txtName.Text.Length > 49)
		{
			new NotificationLabel(this, "Name should be less than 50 characters. ", NotificationTypes.Notification).Show();
		}
		else if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtNumOfPeople.Text))
		{
			if (dateTime < DateTime.Now)
			{
				new NotificationLabel(this, Resources.You_cannot_create_a_reservatio, NotificationTypes.Notification).Show();
				return;
			}
			if (Convert.ToInt32(txtNumOfPeople.Text) == 0)
			{
				new NotificationLabel(this, Resources.You_cannot_create_a_reservatio0, NotificationTypes.Notification).Show();
				return;
			}
			if (txtPhone.Text.Length < 10)
			{
				new NotificationLabel(this, Resources.Phone_number_should_be_at_leas, NotificationTypes.Notification).Show();
				return;
			}
			_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals0.dayOfWeek = dateTime.DayOfWeek.ToString();
			bool flag = true;
			foreach (BusinessHour item in list_2.Where((BusinessHour s) => s.DayOfTheWeek == CS_0024_003C_003E8__locals0.dayOfWeek).ToList())
			{
				if (flag = method_3(item, dateTime))
				{
					break;
				}
			}
			if (flag)
			{
				DataManager dataManager = new DataManager(gclass6_0);
				gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
				if (gclass6_0.Layouts.Where((Layout a) => (long?)a.AppointmentID == (long?)long_0).FirstOrDefault() != null)
				{
					new frmMessageBox(Resources.The_reservation_selected_has_b).ShowDialog(this);
					return;
				}
				if (!nullable_0.HasValue)
				{
					Customer customer = new Customer
					{
						CustomerName = txtName.Text.Trim(),
						CustomerCell = txtPhone.Text.Trim(),
						CustomerEmail = txtEmail.Text.Trim(),
						DateCreated = DateTime.Now,
						Active = true,
						EmployeeID = int_0,
						Address = string.Empty,
						LoyaltyCardNo = string.Empty,
						Synced = false,
						DeliveryTravelTimeMinutes = 0,
						LastModified = DateTime.Now
					};
					gclass6_0.Customers.InsertOnSubmit(customer);
					gclass6_0.SubmitChanges();
					nullable_0 = customer.CustomerID;
				}
				dataManager.reservationSave(dateTime, int_0, txtName.Text, txtPhone.Text, Convert.ToInt16(txtNumOfPeople.Text), txtComments.Text, txtEmail.Text, AppointmentTypes.reservation, nullable_0, long_0);
				new NotificationLabel(this, Resources.Reservation_has_been_successfu, NotificationTypes.Success).Show();
				UpdateList();
				method_7();
				KeUzIgehbp.Text = Resources.SAVE;
				btnAssign.Enabled = false;
				btnMove.Enabled = false;
				gmcziSlvhg.Enabled = false;
				long_0 = 0L;
				RadTextBoxControl radTextBoxControl = txtName;
				RadTextBoxControl radTextBoxControl2 = txtNumOfPeople;
				string text = (txtPhone.Text = string.Empty);
				string text4 = (radTextBoxControl.Text = (radTextBoxControl2.Text = text));
				method_6(dateTime_0);
				return;
			}
			string text5 = "";
			foreach (BusinessHour item2 in list_2.Where((BusinessHour s) => s.DayOfTheWeek == CS_0024_003C_003E8__locals0.dayOfWeek).ToList())
			{
				DateTime dateTime2 = Convert.ToDateTime(item2.LatestOpeningTime);
				DateTime dateTime3 = Convert.ToDateTime(item2.LatestClosingTime);
				text5 = text5 + " [" + dateTime2.ToString("hh:mm:ss tt") + " - " + dateTime3.ToString("hh:mm:ss tt") + "]";
			}
			new frmMessageBox(Resources.Hours_of_Operation_is_from + text5 + Resources._on + CS_0024_003C_003E8__locals0.dayOfWeek + "s.").ShowDialog(this);
		}
		else
		{
			new NotificationLabel(this, Resources.Please_make_sure_all_fields_ar0, NotificationTypes.Warning).Show();
		}
	}

	private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumberOnly(sender, e);
	}

	private void method_4(object sender, EventArgs e)
	{
		UpdateList();
	}

	private void method_5(object sender, EventArgs e)
	{
		UpdateList();
	}

	public void UpdateList()
	{
		if (chkShowAll.Value)
		{
			formHelper_0.addReservationsToList(lstItems);
		}
		else
		{
			formHelper_0.addReservationsToList(lstItems, Convert.ToDateTime(lblSelectedDate.Text));
		}
	}

	private void method_6(DateTime dateTime_2)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.firstOfMonth = dateTime_2;
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		lblMonth.Text = currentCulture.DateTimeFormat.GetMonthName(CS_0024_003C_003E8__locals0.firstOfMonth.Date.Month).ToString() + " " + CS_0024_003C_003E8__locals0.firstOfMonth.Year;
		pnlCalendar.Controls.Clear();
		short num = (short)CS_0024_003C_003E8__locals0.firstOfMonth.DayOfWeek;
		CS_0024_003C_003E8__locals0.calMonth = CS_0024_003C_003E8__locals0.firstOfMonth.AddDays(-num);
		for (int i = 0; i < 7; i++)
		{
			Label label = method_11(currentCulture.DateTimeFormat.GetDayName(CS_0024_003C_003E8__locals0.calMonth.AddDays(i).DayOfWeek).ToString().Substring(0, 3)
				.ToUpper());
			label.BackColor = Color.FromArgb(50, 119, 155);
			label.Font = new Font(label.Font, FontStyle.Bold);
			pnlCalendar.Controls.Add(label);
		}
		int num2 = DateTime.DaysInMonth(CS_0024_003C_003E8__locals0.firstOfMonth.Year, CS_0024_003C_003E8__locals0.firstOfMonth.Month);
		int num3 = 0;
		int dayOfWeek = (int)CS_0024_003C_003E8__locals0.firstOfMonth.AddDays(num2).DayOfWeek;
		num3 = ((dayOfWeek != 0) ? (num + num2 + (7 - dayOfWeek)) : (num + num2));
		short num4 = (short)(num3 / 7);
		bool bool_ = true;
		if (num4 > 5)
		{
			bool_ = false;
		}
		List<Appointment> source = gclass6_0.Appointments.Where((Appointment a) => a.StartDateTime.Month == CS_0024_003C_003E8__locals0.firstOfMonth.Month && a.isCancelled == false && a.AppointmentType == AppointmentTypes.reservation).ToList();
		_003C_003Ec__DisplayClass19_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass19_1();
		CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
		CS_0024_003C_003E8__locals1.x = 0;
		while (CS_0024_003C_003E8__locals1.x < num3)
		{
			new GClass6();
			List<Appointment> list = source.Where((Appointment a) => a.StartDateTime.Date == CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Date && !a.isCancelled && a.AppointmentType == AppointmentTypes.reservation).ToList();
			Button button = method_10(color_0: (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Month != CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.firstOfMonth.Month) ? ((list.Count == 0) ? Color.FromArgb(150, 166, 166) : Color.FromArgb(35, 158, 105)) : ((CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Date == DateTime.Now.Date) ? HelperMethods.GetColor(HelperMethods.ButtonColors()["Light-Blue"]) : ((list.Count == 0) ? Color.FromArgb(190, 195, 199) : HelperMethods.GetColor(HelperMethods.ButtonColors()["Green"]))), string_0: CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Day.ToString(), string_1: CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Date.ToString(), eventHandler_0: method_12, bool_1: bool_);
			if (CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.calMonth.AddDays(CS_0024_003C_003E8__locals1.x).Date == DateTime.Now.Date)
			{
				button_0 = button;
			}
			button.Name = button.Text;
			pnlCalendar.Controls.Add(button);
			CS_0024_003C_003E8__locals1.x++;
		}
		dateTime_1 = DateTime.Now.Date;
	}

	private void method_7()
	{
		txtPhone.Text = string.Empty;
		txtName.Text = string.Empty;
		txtComments.Text = string.Empty;
		txtNumOfPeople.Text = string.Empty;
		txtEmail.Text = string.Empty;
	}

	private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count > 0)
		{
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
			long_0 = Convert.ToInt32(lstItems.SelectedItems[0].SubItems[5].Text);
			Appointment appointment = gclass6_0.Appointments.Where((Appointment r) => (long)r.AppointmentID == long_0 && r.AppointmentType == AppointmentTypes.reservation).FirstOrDefault();
			if (appointment != null)
			{
				new DateTime(appointment.StartDateTime.Year, appointment.StartDateTime.Month, 1);
				txtPhone.Text = appointment.CustomerCell;
				txtName.Text = appointment.CustomerName;
				txtNumOfPeople.Text = appointment.NumOfPeople.ToString();
				txtComments.Text = appointment.Comments;
				txtEmail.Text = appointment.CustomerEmail;
				lblSelectedDate.Text = appointment.StartDateTime.ToLongDateString();
				startTimePicker.Value = appointment.StartDateTime;
				long_0 = appointment.AppointmentID;
				nullable_0 = appointment.CustomerID;
				btnMove.Enabled = true;
				btnAssign.Enabled = appointment.StartDateTime.Date == DateTime.Now.Date;
				gmcziSlvhg.Enabled = true;
			}
			else
			{
				btnMove.Enabled = false;
				btnAssign.Enabled = false;
				gmcziSlvhg.Enabled = false;
				long_0 = 0L;
				nullable_0 = null;
			}
		}
		else
		{
			btnMove.Enabled = false;
			btnAssign.Enabled = false;
			gmcziSlvhg.Enabled = false;
			KeUzIgehbp.Enabled = false;
			btnNew.Enabled = false;
			long_0 = 0L;
			nullable_0 = null;
		}
	}

	private void frmReservations_Load(object sender, EventArgs e)
	{
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstItems.SmallImageList = imageList;
		dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		method_6(dateTime_0);
		UpdateList();
	}

	private void gmcziSlvhg_Click(object sender, EventArgs e)
	{
		if (long_0 > 0L)
		{
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
			if (gclass6_0.Layouts.Where((Layout a) => (long?)a.AppointmentID == (long?)long_0).FirstOrDefault() != null)
			{
				new frmMessageBox(Resources.The_reservation_selected_has_b).ShowDialog(this);
			}
			else if (new frmMessageBox(Resources.Are_you_sure_you_want_to_cance, Resources.CANCEL_CONFIRMATION, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				dataManager_0.AppointmentCancel(long_0);
				UpdateList();
				method_7();
				method_13();
			}
		}
		else
		{
			new NotificationLabel(this, Resources.Please_select_a_reservation_fr, NotificationTypes.Notification).Show();
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void QjeqfMoDub(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_A_Number, 0);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPhone.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_A_Number, 0, 3);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtNumOfPeople.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private Button method_10(string string_0, Color color_0, string string_1, EventHandler eventHandler_0, bool bool_1 = true)
	{
		Button button = new Button();
		button.Text = string_0;
		button.Tag = string_1;
		button.FlatStyle = FlatStyle.Flat;
		button.ForeColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.BackColor = color_0;
		button.Click += eventHandler_0;
		int num = pnlCalendar.Width / 7 - 1;
		int num2 = pnlCalendar.Height / 5 - 6;
		if (bool_1)
		{
			button.Size = new Size(num, num2);
		}
		else
		{
			button.Size = new Size(num, pnlCalendar.Height / 6 - 5);
		}
		button.Font = new Font(FontFamily.GenericSansSerif, 9f, FontStyle.Regular);
		button.Margin = new Padding(1, 1, 0, 0);
		return button;
	}

	private Label method_11(string string_0)
	{
		int num = pnlCalendar.Width / 7 - 1;
		return new Label
		{
			Text = string_0,
			Tag = "lbl" + string_0,
			FlatStyle = FlatStyle.Flat,
			ForeColor = Color.White,
			BackColor = Color.FromArgb(47, 204, 113),
			TextAlign = ContentAlignment.MiddleCenter,
			Size = new Size(num, 30),
			Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular),
			Margin = new Padding(1, 1, 0, 0)
		};
	}

	private void method_12(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!bool_0)
		{
			if (button_0 != null)
			{
				_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass30_0();
				CS_0024_003C_003E8__locals0.prevSelectedDate = DateTime.Parse(button_0.Tag.ToString()).Date;
				List<Appointment> list = new GClass6().Appointments.Where((Appointment a) => a.StartDateTime.Date == CS_0024_003C_003E8__locals0.prevSelectedDate && a.isCancelled == false && a.AppointmentType == AppointmentTypes.reservation).ToList();
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
			startTimePicker.Value = dateTime_1.Date.AddHours(startTimePicker.Value.Hour).AddMinutes(startTimePicker.Value.Minute);
			button_0 = button;
			lblSelectedDate.Text = dateTime_1.ToLongDateString();
		}
		else if (new frmMessageBox(Resources.Are_you_sure_you_want_to_move_, Resources.Move_Reservation, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
			if (gclass6_0.Layouts.Where((Layout a) => (long?)a.AppointmentID == (long?)long_0).FirstOrDefault() != null)
			{
				new frmMessageBox(Resources.The_reservation_selected_has_b).ShowDialog(this);
				return;
			}
			DateTime dateTime = DateTime.Parse(button.Tag.ToString());
			Appointment appointment = gclass6_0.Appointments.Where((Appointment x) => (long)x.AppointmentID == long_0 && x.AppointmentType == AppointmentTypes.reservation).FirstOrDefault();
			DateTime dateTime2 = Convert.ToDateTime(dateTime.ToShortDateString() + " " + appointment.StartDateTime.ToString("hh:mm tt"));
			DateTime dateTime5 = (appointment.StartDateTime = (appointment.EndDateTime = dateTime2));
			appointment.NextNotifyDateTime = dateTime2.AddHours(-2.0);
			appointment.Synced = false;
			try
			{
				Helper.SubmitChangesWithCatch(gclass6_0);
			}
			catch (ChangeConflictException ex)
			{
				Console.WriteLine(ex.Message);
				foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
				}
			}
			new NotificationLabel(this, Resources.Reservation_successfully_moved, NotificationTypes.Success).Show();
			method_14(bool_1: false);
			method_15();
			method_6(dateTime_0);
		}
		UpdateList();
	}

	private void XiBzCeVcqO(object sender, EventArgs e)
	{
		method_13();
		method_7();
	}

	private void method_13()
	{
		long_0 = 0L;
		gmcziSlvhg.Enabled = false;
		btnAssign.Enabled = false;
		btnMove.Enabled = false;
		KeUzIgehbp.Text = Resources.SAVE;
		nullable_0 = null;
		startTimePicker.Value = dateTime_1.Date.AddHours(18.0);
	}

	private void txtNumOfPeople_TextChanged(object sender, EventArgs e)
	{
		new FormHelper().validateNumberOnlyTextBox(txtNumOfPeople);
	}

	private void txtPhone_TextChanged(object sender, EventArgs e)
	{
		new FormHelper().validateNumberOnlyTextBox(txtPhone);
		if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
		{
			Customer customerByPhone = CustomerMethods.GetCustomerByPhone(txtPhone.Text.Trim());
			if (customerByPhone != null)
			{
				txtName.Text = customerByPhone.CustomerName;
				txtEmail.Text = customerByPhone.CustomerEmail;
				nullable_0 = customerByPhone.CustomerID;
			}
			else
			{
				nullable_0 = null;
			}
		}
		else
		{
			nullable_0 = null;
		}
	}

	private void btnNextMonth_Click(object sender, EventArgs e)
	{
		dateTime_0 = dateTime_0.AddMonths(1);
		method_6(dateTime_0);
		if (bool_0)
		{
			method_14();
		}
	}

	private void btnPrevMonth_Click(object sender, EventArgs e)
	{
		dateTime_0 = dateTime_0.AddMonths(-1);
		method_6(dateTime_0);
		if (bool_0)
		{
			method_14();
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Customer_Name, 1, 49, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Phone_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Phone_Number, 0, 10, txtPhone.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPhone.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_NumOfPeople_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Number_of_People, 0, 3, txtNumOfPeople.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtNumOfPeople.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Comments_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Notes, 1, 128, txtComments.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtComments.Text = MemoryLoadedObjects.Keyboard.textEntered;
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Email_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Email, 1, 128, txtEmail.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtEmail.Text = MemoryLoadedObjects.Keyboard.textEntered;
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void chkShowAll_ValueChanged(object sender, EventArgs e)
	{
		UpdateList();
	}

	private void btnAssign_Click(object sender, EventArgs e)
	{
		if (long_0 == 0L)
		{
			return;
		}
		Appointment appointment = gclass6_0.Appointments.Where((Appointment r) => (long)r.AppointmentID == long_0 && r.AppointmentType == AppointmentTypes.reservation).FirstOrDefault();
		if (appointment == null)
		{
			return;
		}
		if (appointment.StartDateTime.Date == DateTime.Now.Date)
		{
			frmEditLayout frmEditLayout2 = new frmEditLayout(appointment.AppointmentID);
			frmEditLayout2.overridePin = true;
			if (frmEditLayout2.ShowDialog(this) == DialogResult.OK)
			{
				_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_0();
				CS_0024_003C_003E8__locals0.tableName = frmEditLayout2.returnTableName;
				gclass6_0.Layouts.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault().AppointmentID = appointment.AppointmentID;
				Helper.SubmitChangesWithCatch(gclass6_0);
				UpdateList();
			}
		}
		else
		{
			new frmMessageBox(Resources.This_reservation_is_not_for_to, Resources.Reservation_Not_For_Today).ShowDialog();
		}
	}

	private void btnMove_Click(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			bool_0 = true;
			btnMove.Text = Resources.CANCEL_MOVE;
			new NotificationLabel(this, Resources.Please_select_a_new_DATE_in_th, NotificationTypes.Notification).Show();
			method_14();
			KeUzIgehbp.Enabled = false;
			gmcziSlvhg.Enabled = false;
			btnNew.Enabled = false;
			btnAssign.Enabled = false;
			lstItems.Enabled = false;
		}
		else
		{
			lstItems.Enabled = true;
			gmcziSlvhg.Enabled = true;
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
			btnAssign.Enabled = true;
			bool_0 = false;
			btnMove.Text = Resources.MOVE_RESERVATION0;
		}
	}

	private void method_14(bool bool_1 = true)
	{
		foreach (Button item in pnlCalendar.Controls.OfType<Button>().ToList())
		{
			if (DateTime.Parse(item.Tag.ToString()).Date < DateTime.Now.Date)
			{
				item.Enabled = ((!bool_1) ? true : false);
			}
		}
	}

	private void method_15()
	{
		lstItems.Enabled = true;
		KeUzIgehbp.Enabled = true;
		btnNew.Enabled = true;
		bool_0 = false;
		btnMove.Text = Resources.MOVE_RESERVATION0;
		method_13();
		method_7();
	}

	private void alvzTlkcku(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
	}

	private void txtComments_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Notes", 1, 128, txtComments.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtComments.Text = MemoryLoadedObjects.Keyboard.textEntered;
			KeUzIgehbp.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_16()
	{
		Graphics graphics = CreateGraphics();
		int num = Convert.ToInt16(graphics.MeasureString(label6.Text, label6.Font).Width) + label6.Location.X + 1;
		int num2 = Convert.ToInt16(graphics.MeasureString(label5.Text, label5.Font).Width) + label6.Location.X - 1;
		int num3 = Convert.ToInt16(graphics.MeasureString(label4.Text, label5.Font).Width) + label6.Location.X - 1;
		label16.Location = new Point(num, label16.Location.Y);
		label17.Location = new Point(num2, label17.Location.Y);
		label18.Location = new Point(num3, label18.Location.Y);
	}

	private void btnSendText_Click(object sender, EventArgs e)
	{
		MailHelpers.SendSmsViaAppointment("reservation", Convert.ToInt32(long_0), txtPhone.Text, txtName.Text);
	}

	private void btnSendMail_Click(object sender, EventArgs e)
	{
		MailHelpers.SendEmailViaAppointment("reservation", Convert.ToInt32(long_0), txtEmail.Text, txtName.Text);
	}

	private void txtName_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtComments_TextChanged(object sender, EventArgs e)
	{
	}

	private void startTimePicker_ValueChanged(object sender, EventArgs e)
	{
	}

	private void startTimePicker_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_17(dateTimePicker.Value);
	}

	private DateTime method_17(DateTime dateTime_2)
	{
		frmTimePicker frmTimePicker2 = new frmTimePicker(dateTime_2, 15);
		if (frmTimePicker2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmTimePicker2.Time;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_2;
	}

	private void btnPrintInfo_Click(object sender, EventArgs e)
	{
		if (long_0 > 0L)
		{
			Appointment appointment = gclass6_0.Appointments.Where((Appointment a) => (long)a.AppointmentID == long_0).FirstOrDefault();
			if (appointment != null)
			{
				string text = "<div>Reservation</div><div>Date & Time: " + appointment.StartDateTime.ToString("MMM dd, yyyy hh:mm tt") + "</div>";
				text = text + "<div>Name: " + appointment.CustomerName + "</div>";
				text = text + "<div>Phone: " + appointment.CustomerHome + "</div>";
				text = text + "<div>Email: " + appointment.CustomerEmail + "</div>";
				text = text + "<div>Number of Guests: " + appointment.NumOfPeople + "</div>";
				new PrintHelper().PrintString(text);
			}
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

	private void Yewzlloqkn()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmReservations));
		label18 = new Label();
		label17 = new Label();
		label16 = new Label();
		label15 = new Label();
		btnShowKeyboard_Email = new Button();
		txtEmail = new RadTextBoxControl();
		label13 = new Label();
		chkShowAll = new RadToggleSwitch();
		txtNumOfPeople = new RadTextBoxControl();
		txtPhone = new RadTextBoxControl();
		txtName = new RadTextBoxControl();
		btnShowKeyboard_Comments = new Button();
		label14 = new Label();
		btnShowKeyboard_NumOfPeople = new Button();
		lblSelectedDate = new Label();
		btnShowKeyboard_Phone = new Button();
		label10 = new Label();
		btnShowKeyboard_Name = new Button();
		lblTrainingMode = new Label();
		btnNew = new Button();
		label9 = new Label();
		label4 = new Label();
		label5 = new Label();
		label6 = new Label();
		txtComments = new TextBox();
		label7 = new Label();
		label1 = new Label();
		label8 = new Label();
		label12 = new Label();
		btnNextMonth = new Button();
		lblMonth = new Label();
		btnPrevMonth = new Button();
		pnlCalendar = new FlowLayoutPanel();
		lstItems = new ListView();
		columnHeader_3 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		label2 = new Label();
		gmcziSlvhg = new Button();
		KeUzIgehbp = new Button();
		BtnClose = new Button();
		btnAssign = new Button();
		btnMove = new Button();
		lblMoveMode = new Label();
		label19 = new Label();
		btnSendMail = new Button();
		btnSendText = new Button();
		startTimePicker = new DateTimePicker();
		label3 = new Label();
		label11 = new Label();
		btnPrintInfo = new Button();
		((ISupportInitialize)txtEmail).BeginInit();
		((ISupportInitialize)chkShowAll).BeginInit();
		((ISupportInitialize)txtNumOfPeople).BeginInit();
		((ISupportInitialize)txtPhone).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		SuspendLayout();
		label18.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label18, "label18");
		label18.ForeColor = Color.White;
		label18.Name = "label18";
		label18.Tag = "5,5";
		componentResourceManager.ApplyResources(label17, "label17");
		label17.BackColor = Color.FromArgb(132, 146, 146);
		label17.ForeColor = Color.White;
		label17.Name = "label17";
		label17.Tag = "5,5";
		label16.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		label16.Tag = "5,5";
		label15.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		btnShowKeyboard_Email.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Email.DialogResult = DialogResult.OK;
		btnShowKeyboard_Email.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Email.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Email, "btnShowKeyboard_Email");
		btnShowKeyboard_Email.ForeColor = Color.White;
		btnShowKeyboard_Email.Name = "btnShowKeyboard_Email";
		btnShowKeyboard_Email.UseVisualStyleBackColor = false;
		btnShowKeyboard_Email.Click += btnShowKeyboard_Email_Click;
		txtEmail.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtEmail, "txtEmail");
		txtEmail.ForeColor = Color.FromArgb(40, 40, 40);
		txtEmail.Name = "txtEmail";
		txtEmail.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtEmail.Click += txtName_Click;
		((RadTextBoxControlElement)txtEmail.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtEmail.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label13.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		componentResourceManager.ApplyResources(chkShowAll, "chkShowAll");
		chkShowAll.Name = "chkShowAll";
		chkShowAll.OffText = "Show All : NO";
		chkShowAll.OnText = "Show All : YES";
		chkShowAll.Tag = "product";
		chkShowAll.ToggleStateMode = ToggleStateMode.Click;
		chkShowAll.ValueChanged += chkShowAll_ValueChanged;
		((RadToggleSwitchElement)chkShowAll.GetChildAt(0)).ThumbOffset = 110;
		((RadToggleSwitchElement)chkShowAll.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkShowAll.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkShowAll.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowAll.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowAll.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkShowAll.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		txtNumOfPeople.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtNumOfPeople, "txtNumOfPeople");
		txtNumOfPeople.ForeColor = Color.FromArgb(40, 40, 40);
		txtNumOfPeople.Name = "txtNumOfPeople";
		txtNumOfPeople.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtNumOfPeople.Tag = "product";
		txtNumOfPeople.TextAlign = HorizontalAlignment.Center;
		txtNumOfPeople.TextChanged += txtNumOfPeople_TextChanged;
		txtNumOfPeople.Click += txtName_Click;
		txtNumOfPeople.KeyPress += txtPhone_KeyPress;
		((RadTextBoxControlElement)txtNumOfPeople.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtNumOfPeople.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		txtPhone.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtPhone, "txtPhone");
		txtPhone.ForeColor = Color.FromArgb(40, 40, 40);
		txtPhone.Name = "txtPhone";
		txtPhone.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPhone.TextChanged += txtPhone_TextChanged;
		txtPhone.Click += txtName_Click;
		txtPhone.KeyPress += txtPhone_KeyPress;
		((RadTextBoxControlElement)txtPhone.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPhone.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		txtName.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.TextChanged += txtName_TextChanged;
		txtName.Click += txtName_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Comments.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Comments.DialogResult = DialogResult.OK;
		btnShowKeyboard_Comments.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Comments.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Comments, "btnShowKeyboard_Comments");
		btnShowKeyboard_Comments.ForeColor = Color.White;
		btnShowKeyboard_Comments.Name = "btnShowKeyboard_Comments";
		btnShowKeyboard_Comments.UseVisualStyleBackColor = false;
		btnShowKeyboard_Comments.Click += btnShowKeyboard_Comments_Click;
		label14.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		btnShowKeyboard_NumOfPeople.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_NumOfPeople.DialogResult = DialogResult.OK;
		btnShowKeyboard_NumOfPeople.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_NumOfPeople.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_NumOfPeople, "btnShowKeyboard_NumOfPeople");
		btnShowKeyboard_NumOfPeople.ForeColor = Color.White;
		btnShowKeyboard_NumOfPeople.Name = "btnShowKeyboard_NumOfPeople";
		btnShowKeyboard_NumOfPeople.UseVisualStyleBackColor = false;
		btnShowKeyboard_NumOfPeople.Click += btnShowKeyboard_NumOfPeople_Click;
		lblSelectedDate.BackColor = Color.LightGray;
		lblSelectedDate.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(lblSelectedDate, "lblSelectedDate");
		lblSelectedDate.ForeColor = Color.Black;
		lblSelectedDate.Name = "lblSelectedDate";
		btnShowKeyboard_Phone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Phone.DialogResult = DialogResult.OK;
		btnShowKeyboard_Phone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Phone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Phone, "btnShowKeyboard_Phone");
		btnShowKeyboard_Phone.ForeColor = Color.White;
		btnShowKeyboard_Phone.Name = "btnShowKeyboard_Phone";
		btnShowKeyboard_Phone.UseVisualStyleBackColor = false;
		btnShowKeyboard_Phone.Click += btnShowKeyboard_Phone_Click;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		componentResourceManager.ApplyResources(lblTrainingMode, "lblTrainingMode");
		lblTrainingMode.BackColor = Color.FromArgb(193, 57, 43);
		lblTrainingMode.ForeColor = Color.White;
		lblTrainingMode.Name = "lblTrainingMode";
		btnNew.BackColor = Color.FromArgb(61, 142, 185);
		btnNew.FlatAppearance.BorderColor = Color.Black;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.EnabledChanged += alvzTlkcku;
		btnNew.Click += XiBzCeVcqO;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(txtComments, "txtComments");
		txtComments.BackColor = Color.White;
		txtComments.BorderStyle = BorderStyle.None;
		txtComments.ForeColor = Color.FromArgb(40, 40, 40);
		txtComments.Name = "txtComments";
		txtComments.Click += txtComments_Click;
		txtComments.TextChanged += txtComments_TextChanged;
		label7.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		label1.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label8.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label12.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		btnNextMonth.BackColor = Color.FromArgb(61, 142, 185);
		btnNextMonth.FlatAppearance.BorderColor = Color.Black;
		btnNextMonth.FlatAppearance.BorderSize = 0;
		btnNextMonth.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnNextMonth, "btnNextMonth");
		btnNextMonth.ForeColor = Color.White;
		btnNextMonth.Name = "btnNextMonth";
		btnNextMonth.UseVisualStyleBackColor = false;
		btnNextMonth.Click += btnNextMonth_Click;
		lblMonth.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(lblMonth, "lblMonth");
		lblMonth.ForeColor = Color.White;
		lblMonth.Name = "lblMonth";
		btnPrevMonth.BackColor = Color.FromArgb(61, 142, 185);
		btnPrevMonth.FlatAppearance.BorderColor = Color.Black;
		btnPrevMonth.FlatAppearance.BorderSize = 0;
		btnPrevMonth.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnPrevMonth, "btnPrevMonth");
		btnPrevMonth.ForeColor = Color.White;
		btnPrevMonth.Name = "btnPrevMonth";
		btnPrevMonth.UseVisualStyleBackColor = false;
		btnPrevMonth.Click += btnPrevMonth_Click;
		pnlCalendar.BackColor = Color.Transparent;
		pnlCalendar.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(pnlCalendar, "pnlCalendar");
		pnlCalendar.Name = "pnlCalendar";
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[5] { columnHeader_3, columnHeader_0, columnHeader_4, columnHeader_2, columnHeader_1 });
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(20, 20);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_3, "colEmployee");
		componentResourceManager.ApplyResources(columnHeader_0, "colDateTime");
		componentResourceManager.ApplyResources(columnHeader_4, "colTable");
		componentResourceManager.ApplyResources(columnHeader_2, "colNumOfPeople");
		componentResourceManager.ApplyResources(columnHeader_1, "colName");
		label2.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		gmcziSlvhg.BackColor = Color.SandyBrown;
		gmcziSlvhg.FlatAppearance.BorderColor = Color.White;
		gmcziSlvhg.FlatAppearance.BorderSize = 0;
		gmcziSlvhg.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(gmcziSlvhg, "btnCancel");
		gmcziSlvhg.ForeColor = Color.White;
		gmcziSlvhg.Name = "btnCancel";
		gmcziSlvhg.UseVisualStyleBackColor = false;
		gmcziSlvhg.EnabledChanged += alvzTlkcku;
		gmcziSlvhg.Click += gmcziSlvhg_Click;
		KeUzIgehbp.BackColor = Color.FromArgb(80, 203, 116);
		KeUzIgehbp.FlatAppearance.BorderColor = Color.White;
		KeUzIgehbp.FlatAppearance.BorderSize = 0;
		KeUzIgehbp.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(KeUzIgehbp, "btnSave");
		KeUzIgehbp.ForeColor = Color.White;
		KeUzIgehbp.Name = "btnSave";
		KeUzIgehbp.UseVisualStyleBackColor = false;
		KeUzIgehbp.EnabledChanged += alvzTlkcku;
		KeUzIgehbp.Click += KeUzIgehbp_Click;
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.White;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		btnAssign.BackColor = Color.FromArgb(65, 168, 95);
		btnAssign.FlatAppearance.BorderColor = Color.White;
		btnAssign.FlatAppearance.BorderSize = 0;
		btnAssign.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAssign, "btnAssign");
		btnAssign.ForeColor = Color.White;
		btnAssign.Name = "btnAssign";
		btnAssign.UseVisualStyleBackColor = false;
		btnAssign.EnabledChanged += alvzTlkcku;
		btnAssign.Click += btnAssign_Click;
		btnMove.BackColor = Color.FromArgb(77, 174, 225);
		btnMove.FlatAppearance.BorderColor = Color.Black;
		btnMove.FlatAppearance.BorderSize = 0;
		btnMove.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnMove, "btnMove");
		btnMove.ForeColor = Color.White;
		btnMove.Name = "btnMove";
		btnMove.UseVisualStyleBackColor = false;
		btnMove.EnabledChanged += alvzTlkcku;
		btnMove.Click += btnMove_Click;
		componentResourceManager.ApplyResources(lblMoveMode, "lblMoveMode");
		lblMoveMode.BackColor = Color.FromArgb(193, 57, 43);
		lblMoveMode.ForeColor = Color.White;
		lblMoveMode.Name = "lblMoveMode";
		label19.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		componentResourceManager.ApplyResources(btnSendMail, "btnSendMail");
		btnSendMail.BackColor = Color.FromArgb(50, 119, 155);
		btnSendMail.FlatAppearance.BorderColor = Color.White;
		btnSendMail.FlatAppearance.BorderSize = 0;
		btnSendMail.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSendMail.ForeColor = Color.White;
		btnSendMail.Name = "btnSendMail";
		btnSendMail.UseVisualStyleBackColor = false;
		btnSendMail.Click += btnSendMail_Click;
		componentResourceManager.ApplyResources(btnSendText, "btnSendText");
		btnSendText.BackColor = Color.FromArgb(117, 81, 147);
		btnSendText.FlatAppearance.BorderColor = Color.White;
		btnSendText.FlatAppearance.BorderSize = 0;
		btnSendText.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSendText.ForeColor = Color.White;
		btnSendText.Name = "btnSendText";
		btnSendText.UseVisualStyleBackColor = false;
		btnSendText.Click += btnSendText_Click;
		startTimePicker.Checked = false;
		componentResourceManager.ApplyResources(startTimePicker, "startTimePicker");
		startTimePicker.Format = DateTimePickerFormat.Custom;
		startTimePicker.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
		startTimePicker.MinDate = new DateTime(2019, 1, 1, 0, 0, 0, 0);
		startTimePicker.Name = "startTimePicker";
		startTimePicker.ValueChanged += startTimePicker_ValueChanged;
		startTimePicker.MouseDown += startTimePicker_MouseDown;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label11.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		btnPrintInfo.BackColor = Color.FromArgb(61, 142, 185);
		btnPrintInfo.FlatAppearance.BorderColor = Color.Black;
		btnPrintInfo.FlatAppearance.BorderSize = 0;
		btnPrintInfo.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnPrintInfo, "btnPrintInfo");
		btnPrintInfo.ForeColor = Color.White;
		btnPrintInfo.Name = "btnPrintInfo";
		btnPrintInfo.UseVisualStyleBackColor = false;
		btnPrintInfo.Click += btnPrintInfo_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(btnPrintInfo);
		base.Controls.Add(label11);
		base.Controls.Add(label3);
		base.Controls.Add(startTimePicker);
		base.Controls.Add(lblTrainingMode);
		base.Controls.Add(btnSendMail);
		base.Controls.Add(btnSendText);
		base.Controls.Add(label19);
		base.Controls.Add(lblMoveMode);
		base.Controls.Add(btnMove);
		base.Controls.Add(btnAssign);
		base.Controls.Add(label18);
		base.Controls.Add(label17);
		base.Controls.Add(label16);
		base.Controls.Add(label15);
		base.Controls.Add(btnShowKeyboard_Email);
		base.Controls.Add(txtEmail);
		base.Controls.Add(label13);
		base.Controls.Add(chkShowAll);
		base.Controls.Add(txtNumOfPeople);
		base.Controls.Add(txtPhone);
		base.Controls.Add(txtName);
		base.Controls.Add(btnShowKeyboard_Comments);
		base.Controls.Add(label14);
		base.Controls.Add(btnShowKeyboard_NumOfPeople);
		base.Controls.Add(lblSelectedDate);
		base.Controls.Add(btnShowKeyboard_Phone);
		base.Controls.Add(label10);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(btnNew);
		base.Controls.Add(label9);
		base.Controls.Add(label4);
		base.Controls.Add(label5);
		base.Controls.Add(label6);
		base.Controls.Add(txtComments);
		base.Controls.Add(label7);
		base.Controls.Add(label1);
		base.Controls.Add(label8);
		base.Controls.Add(label12);
		base.Controls.Add(btnNextMonth);
		base.Controls.Add(lblMonth);
		base.Controls.Add(btnPrevMonth);
		base.Controls.Add(pnlCalendar);
		base.Controls.Add(lstItems);
		base.Controls.Add(label2);
		base.Controls.Add(gmcziSlvhg);
		base.Controls.Add(KeUzIgehbp);
		base.Controls.Add(BtnClose);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmReservations";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmReservations_Load;
		base.Controls.SetChildIndex(BtnClose, 0);
		base.Controls.SetChildIndex(KeUzIgehbp, 0);
		base.Controls.SetChildIndex(gmcziSlvhg, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(lstItems, 0);
		base.Controls.SetChildIndex(pnlCalendar, 0);
		base.Controls.SetChildIndex(btnPrevMonth, 0);
		base.Controls.SetChildIndex(lblMonth, 0);
		base.Controls.SetChildIndex(btnNextMonth, 0);
		base.Controls.SetChildIndex(label12, 0);
		base.Controls.SetChildIndex(label8, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(label7, 0);
		base.Controls.SetChildIndex(txtComments, 0);
		base.Controls.SetChildIndex(label6, 0);
		base.Controls.SetChildIndex(label5, 0);
		base.Controls.SetChildIndex(label4, 0);
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(btnNew, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Name, 0);
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Phone, 0);
		base.Controls.SetChildIndex(lblSelectedDate, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_NumOfPeople, 0);
		base.Controls.SetChildIndex(label14, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Comments, 0);
		base.Controls.SetChildIndex(txtName, 0);
		base.Controls.SetChildIndex(txtPhone, 0);
		base.Controls.SetChildIndex(txtNumOfPeople, 0);
		base.Controls.SetChildIndex(chkShowAll, 0);
		base.Controls.SetChildIndex(label13, 0);
		base.Controls.SetChildIndex(txtEmail, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Email, 0);
		base.Controls.SetChildIndex(label15, 0);
		base.Controls.SetChildIndex(label16, 0);
		base.Controls.SetChildIndex(label17, 0);
		base.Controls.SetChildIndex(label18, 0);
		base.Controls.SetChildIndex(btnAssign, 0);
		base.Controls.SetChildIndex(btnMove, 0);
		base.Controls.SetChildIndex(lblMoveMode, 0);
		base.Controls.SetChildIndex(label19, 0);
		base.Controls.SetChildIndex(btnSendText, 0);
		base.Controls.SetChildIndex(btnSendMail, 0);
		base.Controls.SetChildIndex(lblTrainingMode, 0);
		base.Controls.SetChildIndex(startTimePicker, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(label11, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(btnPrintInfo, 0);
		((ISupportInitialize)txtEmail).EndInit();
		((ISupportInitialize)chkShowAll).EndInit();
		((ISupportInitialize)txtNumOfPeople).EndInit();
		((ISupportInitialize)txtPhone).EndInit();
		((ISupportInitialize)txtName).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
