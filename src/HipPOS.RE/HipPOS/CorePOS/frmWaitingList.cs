using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmWaitingList : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Appointment waitingList;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal bool _003CPopulateWaitingList_003Eb__5(Layout x)
		{
			return x.AppointmentID == waitingList.AppointmentID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public string tableName;

		public _003C_003Ec__DisplayClass27_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private int int_0;

	private int? nullable_0;

	private int int_1;

	private IContainer FlaLkSbuWx;

	private Label label10;

	internal CustomListViewTelerik radListItems;

	internal Button btnShowKeyboard_Email;

	private RadTextBoxControl txtEmail;

	private Label label13;

	private RadTextBoxControl txtNumOfPeople;

	private RadTextBoxControl txtPhone;

	private RadTextBoxControl txtName;

	internal Button btnShowKeyboard_Comments;

	internal Button btnShowKeyboard_NumOfPeople;

	internal Button btnShowKeyboard_Phone;

	private Button btnShowKeyboard_Name;

	private Label label9;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label label11;

	internal Button btnSave;

	internal Button btnNew;

	internal Button BtnClose;

	internal Button btnClear;

	private Label label15;

	private Label label1;

	private Label label2;

	private Label label3;

	internal Button btnUndo;

	internal Button btnSendText;

	internal Button btnSendMail;

	private Label label16;

	private Label label8;

	private RadTextBoxControl txtComments;

	internal Button btnAssign;

	private Label label19;

	private int AppointmentId
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			method_5();
		}
	}

	public frmWaitingList(int employeeID)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = employeeID;
	}

	private void frmWaitingList_Load(object sender, EventArgs e)
	{
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("es-US"))
		{
			label2.Font = new Font(label2.Font.FontFamily, label2.Font.Size - 1f);
			label6.Font = new Font(label6.Font.FontFamily, label6.Font.Size - 0.5f);
			label16.Font = new Font(label16.Font.FontFamily, label16.Font.Size - 0.5f);
			label8.Font = new Font(label8.Font.FontFamily, label8.Font.Size - 0.5f);
			label16.Location = new Point(label4.Right - label16.Width, label16.Location.Y);
			label8.Location = new Point(label4.Right - label8.Width, label8.Location.Y);
			label13.Width = label13.PreferredWidth;
			txtEmail.Width = txtEmail.Right - label13.Right - 1;
			txtEmail.Location = new Point(label13.Right + 1, txtEmail.Location.Y);
			label5.Width = label13.Width;
			txtPhone.Width = txtEmail.Width;
			txtPhone.Location = new Point(txtEmail.Location.X, txtPhone.Location.Y);
			label6.Width = label4.Width;
			txtName.Width = txtNumOfPeople.Width;
			txtName.Location = new Point(txtNumOfPeople.Location.X, txtName.Location.Y);
		}
		method_3();
		method_4();
	}

	private void method_3()
	{
		radListItems.Items.Clear();
		GClass6 gClass = new GClass6();
		List<Appointment> list = (from a in gClass.Appointments
			where a.DateCreated > DateTime.Now.Date && a.AppointmentType == AppointmentTypes.waiting_list && a.IsCleared == false
			orderby a.DateCreated
			select a).ToList();
		List<Layout> source = gClass.Layouts.Where((Layout x) => x.AppointmentID.HasValue).ToList();
		int appointmentId = AppointmentId;
		int num = 1;
		using (List<Appointment>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
				CS_0024_003C_003E8__locals0.waitingList = enumerator.Current;
				Layout layout = source.Where((Layout x) => x.AppointmentID == CS_0024_003C_003E8__locals0.waitingList.AppointmentID).FirstOrDefault();
				ListViewDataItem listViewDataItem = new ListViewDataItem("", new string[6]
				{
					num.ToString(),
					CS_0024_003C_003E8__locals0.waitingList.CustomerName,
					CS_0024_003C_003E8__locals0.waitingList.NumOfPeople.ToString(),
					(layout != null) ? layout.TableName : string.Empty,
					CS_0024_003C_003E8__locals0.waitingList.DateCreated.ToShortTimeString(),
					CS_0024_003C_003E8__locals0.waitingList.AppointmentID.ToString()
				});
				listViewDataItem.Font = radListItems.Font;
				radListItems.Items.Add(listViewDataItem);
				num++;
			}
		}
		if ((from a in gClass.Appointments
			where a.AppointmentType == AppointmentTypes.waiting_list && a.IsCleared == true && a.DateCreated > DateTime.Now.Date
			orderby a.DateUpdated descending
			select a).Count() == 0)
		{
			btnUndo.Enabled = false;
		}
		else
		{
			btnUndo.Enabled = true;
		}
		if (appointmentId == 0)
		{
			return;
		}
		radListItems.SelectedItems.Clear();
		foreach (ListViewDataItem item in radListItems.Items)
		{
			if (item.SubItems[5].ToString() == appointmentId.ToString())
			{
				radListItems.Select(new ListViewDataItem[1] { item });
			}
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		DataManager dataManager = new DataManager();
		if (string.IsNullOrEmpty(txtName.Text))
		{
			new frmMessageBox("Customer Name is required.").ShowDialog();
		}
		else if (!string.IsNullOrEmpty(txtNumOfPeople.Text) && !(txtNumOfPeople.Text == "0"))
		{
			if (!nullable_0.HasValue)
			{
				GClass6 gClass = new GClass6();
				Customer customer = new Customer
				{
					CustomerName = txtName.Text.Trim(),
					CustomerCell = txtPhone.Text.Trim(),
					CustomerEmail = txtEmail.Text.Trim(),
					DateCreated = DateTime.Now,
					LastModified = DateTime.Now,
					Active = true,
					EmployeeID = int_0,
					Address = string.Empty,
					LoyaltyCardNo = string.Empty,
					Synced = false,
					DeliveryTravelTimeMinutes = 0
				};
				gClass.Customers.InsertOnSubmit(customer);
				gClass.SubmitChanges();
				nullable_0 = customer.CustomerID;
			}
			dataManager.reservationSave(DateTime.Now, int_0, txtName.Text, txtPhone.Text, Convert.ToInt16(txtNumOfPeople.Text), txtComments.Text, txtEmail.Text, AppointmentTypes.waiting_list, nullable_0, AppointmentId);
			dataManager.SubmitChangesToDatabase();
			if (AppointmentId != 0)
			{
				new frmMessageBox("Customer Information has been updated.", "Customer Updated").ShowDialog();
			}
			method_3();
		}
		else
		{
			new frmMessageBox("Number of Guests is required.").ShowDialog();
		}
	}

	private void radListItems_SelectedItemChanged(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count <= 0)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		AppointmentId = Convert.ToInt32(radListItems.SelectedItem.SubItems[5].ToString());
		if (AppointmentId != 0)
		{
			Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentType == AppointmentTypes.waiting_list && a.AppointmentID == AppointmentId).FirstOrDefault();
			txtName.Text = appointment.CustomerName;
			txtPhone.Text = appointment.CustomerCell;
			txtEmail.Text = appointment.CustomerEmail;
			txtNumOfPeople.Text = appointment.NumOfPeople.ToString();
			txtComments.Text = appointment.Comments;
			btnClear.Enabled = true;
			nullable_0 = appointment.CustomerID;
		}
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		if (radListItems.SelectedItems.Count > 0 && AppointmentId != 0)
		{
			GClass6 gClass = new GClass6();
			Appointment appointment = gClass.Appointments.Where((Appointment a) => a.AppointmentType == AppointmentTypes.waiting_list && a.AppointmentID == AppointmentId).FirstOrDefault();
			appointment.IsCleared = true;
			appointment.DateUpdated = DateTime.Now;
			Helper.SubmitChangesWithCatch(gClass);
			method_3();
			if (radListItems.SelectedItems.Count == 0)
			{
				method_4();
			}
		}
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		radListItems.SelectedItems.Clear();
		btnClear.Enabled = false;
		txtName.Text = "";
		txtEmail.Text = "";
		txtPhone.Text = "";
		txtComments.Text = "";
		txtNumOfPeople.Text = "0";
		AppointmentId = 0;
		nullable_0 = null;
	}

	private void btnClear_EnabledChanged(object sender, EventArgs e)
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

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Customer_Name, 1, 50, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
			btnSave.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void yycEfligPn(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Phone_Number, 0, 10, txtPhone.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPhone.Text = MemoryLoadedObjects.Numpad.valueEntered;
			btnSave.Enabled = true;
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
			btnSave.Enabled = true;
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
			btnSave.Enabled = true;
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
			btnSave.Enabled = true;
			btnNew.Enabled = true;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnUndo_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Appointment appointment = (from a in gClass.Appointments
			where a.AppointmentType == AppointmentTypes.waiting_list && a.IsCleared == true && a.DateCreated > DateTime.Now.Date
			orderby a.DateUpdated descending
			select a).FirstOrDefault();
		if (appointment != null)
		{
			appointment.IsCleared = false;
			appointment.DateUpdated = DateTime.Now;
			Helper.SubmitChangesWithCatch(gClass);
			method_3();
		}
	}

	private void btnSendText_Click(object sender, EventArgs e)
	{
		MailHelpers.SendSmsViaAppointment("waiting list", AppointmentId, txtPhone.Text, txtName.Text);
	}

	private void btnSendMail_Click(object sender, EventArgs e)
	{
		MailHelpers.SendEmailViaAppointment("waiting list", AppointmentId, txtEmail.Text, txtName.Text);
	}

	private void method_5()
	{
		if (AppointmentId == 0)
		{
			Button button = btnSendText;
			btnSendMail.Enabled = false;
			button.Enabled = false;
		}
		else
		{
			Button button2 = btnSendText;
			btnSendMail.Enabled = true;
			button2.Enabled = true;
		}
	}

	private void txtPhone_TextChanged(object sender, EventArgs e)
	{
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

	private void btnAssign_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (AppointmentId == 0)
		{
			return;
		}
		Appointment appointment = gClass.Appointments.Where((Appointment r) => r.AppointmentID == AppointmentId && r.AppointmentType == AppointmentTypes.waiting_list).FirstOrDefault();
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
				_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
				CS_0024_003C_003E8__locals0.tableName = frmEditLayout2.returnTableName;
				gClass.Layouts.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0.tableName).FirstOrDefault().AppointmentID = AppointmentId;
				Helper.SubmitChangesWithCatch(gClass);
				method_3();
			}
		}
		else
		{
			new frmMessageBox(Resources.This_reservation_is_not_for_to, Resources.Reservation_Not_For_Today).ShowDialog();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && FlaLkSbuWx != null)
		{
			FlaLkSbuWx.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmWaitingList));
		ListViewDetailColumn listViewDetailColumn = new ListViewDetailColumn("Column 0", "No.");
		ListViewDetailColumn listViewDetailColumn2 = new ListViewDetailColumn("Column 1", "Name");
		ListViewDetailColumn listViewDetailColumn3 = new ListViewDetailColumn("Column 2", "Guests");
		ListViewDetailColumn listViewDetailColumn4 = new ListViewDetailColumn("Column 3", "Logged");
		ListViewDetailColumn listViewDetailColumn5 = new ListViewDetailColumn("Column 4", "Column 4");
		txtComments = new RadTextBoxControl();
		label8 = new Label();
		label16 = new Label();
		btnSendMail = new Button();
		btnSendText = new Button();
		btnUndo = new Button();
		label3 = new Label();
		label2 = new Label();
		label1 = new Label();
		label15 = new Label();
		btnClear = new Button();
		BtnClose = new Button();
		btnNew = new Button();
		btnSave = new Button();
		btnShowKeyboard_Email = new Button();
		txtEmail = new RadTextBoxControl();
		label13 = new Label();
		txtNumOfPeople = new RadTextBoxControl();
		txtPhone = new RadTextBoxControl();
		txtName = new RadTextBoxControl();
		btnShowKeyboard_Comments = new Button();
		btnShowKeyboard_NumOfPeople = new Button();
		btnShowKeyboard_Phone = new Button();
		btnShowKeyboard_Name = new Button();
		label9 = new Label();
		label4 = new Label();
		label5 = new Label();
		label6 = new Label();
		label11 = new Label();
		label10 = new Label();
		radListItems = new CustomListViewTelerik();
		btnAssign = new Button();
		label19 = new Label();
		((ISupportInitialize)txtComments).BeginInit();
		((ISupportInitialize)txtEmail).BeginInit();
		((ISupportInitialize)txtNumOfPeople).BeginInit();
		((ISupportInitialize)txtPhone).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)radListItems).BeginInit();
		SuspendLayout();
		txtComments.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtComments, "txtComments");
		txtComments.ForeColor = Color.FromArgb(40, 40, 40);
		txtComments.Name = "txtComments";
		txtComments.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtComments.Click += txtName_Click;
		((RadTextBoxControlElement)txtComments.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtComments.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label8.Tag = "5,5";
		label16.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		label16.Tag = "5,5";
		btnSendMail.BackColor = Color.FromArgb(50, 119, 155);
		btnSendMail.FlatAppearance.BorderColor = Color.White;
		btnSendMail.FlatAppearance.BorderSize = 0;
		btnSendMail.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSendMail, "btnSendMail");
		btnSendMail.ForeColor = Color.White;
		btnSendMail.Name = "btnSendMail";
		btnSendMail.UseVisualStyleBackColor = false;
		btnSendMail.EnabledChanged += btnClear_EnabledChanged;
		btnSendMail.Click += btnSendMail_Click;
		btnSendText.BackColor = Color.FromArgb(117, 81, 147);
		btnSendText.FlatAppearance.BorderColor = Color.White;
		btnSendText.FlatAppearance.BorderSize = 0;
		btnSendText.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSendText, "btnSendText");
		btnSendText.ForeColor = Color.White;
		btnSendText.Name = "btnSendText";
		btnSendText.UseVisualStyleBackColor = false;
		btnSendText.EnabledChanged += btnClear_EnabledChanged;
		btnSendText.Click += btnSendText_Click;
		componentResourceManager.ApplyResources(btnUndo, "btnUndo");
		btnUndo.BackColor = Color.FromArgb(50, 119, 155);
		btnUndo.FlatAppearance.BorderColor = Color.White;
		btnUndo.FlatAppearance.BorderSize = 0;
		btnUndo.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnUndo.ForeColor = Color.White;
		btnUndo.Name = "btnUndo";
		btnUndo.UseVisualStyleBackColor = false;
		btnUndo.EnabledChanged += btnClear_EnabledChanged;
		btnUndo.Click += btnUndo_Click;
		label3.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label2.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label1.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label15.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.BackColor = Color.SandyBrown;
		btnClear.FlatAppearance.BorderColor = Color.White;
		btnClear.FlatAppearance.BorderSize = 0;
		btnClear.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.EnabledChanged += btnClear_EnabledChanged;
		btnClear.Click += btnClear_Click;
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.White;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		btnNew.BackColor = Color.FromArgb(61, 142, 185);
		btnNew.FlatAppearance.BorderColor = Color.Black;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
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
		txtNumOfPeople.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtNumOfPeople, "txtNumOfPeople");
		txtNumOfPeople.ForeColor = Color.FromArgb(40, 40, 40);
		txtNumOfPeople.Name = "txtNumOfPeople";
		txtNumOfPeople.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtNumOfPeople.Tag = "product";
		txtNumOfPeople.TextAlign = HorizontalAlignment.Center;
		txtNumOfPeople.Click += txtName_Click;
		((RadTextBoxControlElement)txtNumOfPeople.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtNumOfPeople.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		txtPhone.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtPhone, "txtPhone");
		txtPhone.ForeColor = Color.FromArgb(40, 40, 40);
		txtPhone.Name = "txtPhone";
		txtPhone.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPhone.TextChanged += txtPhone_TextChanged;
		txtPhone.Click += txtName_Click;
		((RadTextBoxControlElement)txtPhone.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPhone.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		txtName.BackColor = Color.White;
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
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
		btnShowKeyboard_NumOfPeople.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_NumOfPeople.DialogResult = DialogResult.OK;
		btnShowKeyboard_NumOfPeople.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_NumOfPeople.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_NumOfPeople, "btnShowKeyboard_NumOfPeople");
		btnShowKeyboard_NumOfPeople.ForeColor = Color.White;
		btnShowKeyboard_NumOfPeople.Name = "btnShowKeyboard_NumOfPeople";
		btnShowKeyboard_NumOfPeople.UseVisualStyleBackColor = false;
		btnShowKeyboard_NumOfPeople.Click += btnShowKeyboard_NumOfPeople_Click;
		btnShowKeyboard_Phone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Phone.DialogResult = DialogResult.OK;
		btnShowKeyboard_Phone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Phone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Phone, "btnShowKeyboard_Phone");
		btnShowKeyboard_Phone.ForeColor = Color.White;
		btnShowKeyboard_Phone.Name = "btnShowKeyboard_Phone";
		btnShowKeyboard_Phone.UseVisualStyleBackColor = false;
		btnShowKeyboard_Phone.Click += yycEfligPn;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
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
		label11.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		radListItems.AllowArbitraryItemHeight = true;
		radListItems.AllowEdit = false;
		radListItems.AllowRemove = false;
		componentResourceManager.ApplyResources(radListItems, "radListItems");
		listViewDetailColumn.HeaderText = "No.";
		listViewDetailColumn.Width = 50f;
		listViewDetailColumn2.HeaderText = "Name";
		listViewDetailColumn2.Width = 251f;
		listViewDetailColumn3.HeaderText = "Guests";
		listViewDetailColumn3.Width = 60f;
		listViewDetailColumn4.HeaderText = "Logged";
		listViewDetailColumn4.Width = 114f;
		listViewDetailColumn5.HeaderText = "Column 4";
		listViewDetailColumn5.Width = 85f;
		radListItems.Columns.AddRange(listViewDetailColumn, listViewDetailColumn2, listViewDetailColumn3, listViewDetailColumn4, listViewDetailColumn5);
		radListItems.EnableKineticScrolling = true;
		radListItems.GroupItemSize = new Size(200, 40);
		radListItems.ItemSize = new Size(200, 40);
		radListItems.ItemSpacing = -1;
		radListItems.Name = "radListItems";
		radListItems.ShowColumnHeaders = false;
		radListItems.ShowGridLines = true;
		radListItems.ViewType = ListViewType.DetailsView;
		radListItems.SelectedItemChanged += radListItems_SelectedItemChanged;
		componentResourceManager.ApplyResources(btnAssign, "btnAssign");
		btnAssign.BackColor = Color.FromArgb(65, 168, 95);
		btnAssign.FlatAppearance.BorderColor = Color.White;
		btnAssign.FlatAppearance.BorderSize = 0;
		btnAssign.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAssign.ForeColor = Color.White;
		btnAssign.Name = "btnAssign";
		btnAssign.UseVisualStyleBackColor = false;
		btnAssign.Click += btnAssign_Click;
		label19.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(label19);
		base.Controls.Add(btnAssign);
		base.Controls.Add(txtComments);
		base.Controls.Add(label8);
		base.Controls.Add(label16);
		base.Controls.Add(btnSendMail);
		base.Controls.Add(btnSendText);
		base.Controls.Add(btnUndo);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(label15);
		base.Controls.Add(btnClear);
		base.Controls.Add(BtnClose);
		base.Controls.Add(btnNew);
		base.Controls.Add(btnSave);
		base.Controls.Add(btnShowKeyboard_Email);
		base.Controls.Add(txtEmail);
		base.Controls.Add(label13);
		base.Controls.Add(txtNumOfPeople);
		base.Controls.Add(txtPhone);
		base.Controls.Add(txtName);
		base.Controls.Add(btnShowKeyboard_Comments);
		base.Controls.Add(btnShowKeyboard_NumOfPeople);
		base.Controls.Add(btnShowKeyboard_Phone);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(label9);
		base.Controls.Add(label4);
		base.Controls.Add(label5);
		base.Controls.Add(label6);
		base.Controls.Add(label11);
		base.Controls.Add(radListItems);
		base.Controls.Add(label10);
		base.Name = "frmWaitingList";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmWaitingList_Load;
		((ISupportInitialize)txtComments).EndInit();
		((ISupportInitialize)txtEmail).EndInit();
		((ISupportInitialize)txtNumOfPeople).EndInit();
		((ISupportInitialize)txtPhone).EndInit();
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)radListItems).EndInit();
		ResumeLayout(performLayout: false);
	}
}
