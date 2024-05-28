using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAdminEmployees : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public frmAdminEmployees _003C_003E4__this;

		public User user;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public Role adminRole;

		public _003C_003Ec__DisplayClass6_1()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public bool isActive;

		public frmAdminEmployees _003C_003E4__this;

		public _003C_003Ec__DisplayClass11_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private int int_0;

	private GClass6 gclass6_0;

	private bool bool_0;

	private Employee employee_0;

	private short short_0;

	private IContainer icontainer_1;

	internal Button btnSave;

	private Label label1;

	internal Button btnCancel;

	private ListView lstEmployees;

	private Label label9;

	private Label label13;

	private Label label14;

	private Label label12;

	private Label label10;

	private Label label3;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label label2;

	internal Button btnNew;

	internal Button btnShowKeyboard_PIN;

	internal Button btnShowKeyboard_HomePhone;

	internal Button btnShowKeyboard_Cell;

	internal Button btnShowKeyboard_FirstName;

	internal Button btnShowKeyboard_LastName;

	private RadToggleSwitch chkEmployeeActive;

	private RadToggleSwitch chkPinActive;

	private RadTextBoxControl txtLastName;

	private RadTextBoxControl txtFirstName;

	private RadTextBoxControl txtHomePhone;

	private RadTextBoxControl txtCell;

	private RadTextBoxControl txtPIN;

	private RadToggleSwitch chkShowInActive;

	private Button btnSyncEmployeeToCloud;

	private Class20 ddlRoles;

	public frmAdminEmployees()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		short_0 = 1;
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			label3.Font = new Font(label3.Font.FontFamily, label3.Font.Size - 0.75f);
		}
		employee_0 = EmployeeMethods.getEmployeeByID(Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"]));
		short_0 = (short)(employee_0.Users.First().Role.RoleLevel.HasValue ? employee_0.Users.First().Role.RoleLevel.Value : 4);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		gclass6_0.Refresh(RefreshMode.OverwriteCurrentValues);
		if (!(txtPIN.Text == "") && txtPIN.Text != null)
		{
			if (!HelperMethods.IsDigitsOnly(txtPIN.Text))
			{
				new frmMessageBox(Resources.Please_use_only_digits_for_pin).ShowDialog(this);
			}
			else if (txtPIN.Text.Length > 10)
			{
				new frmMessageBox(Resources._10_digits_is_the_maximum_numb).ShowDialog(this);
			}
			else if (!(txtFirstName.Text.Trim() == string.Empty) && !(txtLastName.Text.Trim() == string.Empty))
			{
				Employee employee;
				if (int_0 == 0)
				{
					if (gclass6_0.Users.Where((User u) => u.PIN == txtPIN.Text.Trim()).Count() > 0)
					{
						new frmMessageBox(Resources.PIN_already_in_use_Please_sele).ShowDialog(this);
						return;
					}
					employee = new Employee();
					employee.EmployeeName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
					employee.FirstName = txtFirstName.Text.Trim();
					employee.LastName = txtLastName.Text.Trim();
					employee.isActive = chkEmployeeActive.Value;
					employee.Phone1 = txtCell.Text.Trim();
					employee.Phone2 = txtHomePhone.Text.Trim();
					employee.Synced = false;
					gclass6_0.Employees.InsertOnSubmit(employee);
					Helper.SubmitChangesWithCatch(gclass6_0);
					int_0 = employee.EmployeeID;
					CS_0024_003C_003E8__locals0.user = new User();
					CS_0024_003C_003E8__locals0.user.EmployeeID = int_0;
					CS_0024_003C_003E8__locals0.user.Active = chkPinActive.Value;
					CS_0024_003C_003E8__locals0.user.PIN = (string.IsNullOrEmpty(txtPIN.Text) ? "0" : txtPIN.Text.Trim());
					CS_0024_003C_003E8__locals0.user.RoleID = Convert.ToInt16(ddlRoles.SelectedValue);
					gclass6_0.Users.InsertOnSubmit(CS_0024_003C_003E8__locals0.user);
					Helper.SubmitChangesWithCatch(gclass6_0);
				}
				else
				{
					_003C_003Ec__DisplayClass6_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass6_1();
					employee = gclass6_0.Employees.Where((Employee s) => s.EmployeeID == int_0).FirstOrDefault();
					CS_0024_003C_003E8__locals0.user = gclass6_0.Users.Where((User u) => u.EmployeeID == int_0).FirstOrDefault();
					if (employee == null || CS_0024_003C_003E8__locals0.user == null)
					{
						new frmMessageBox(Resources.Something_went_wrong_saving_th).ShowDialog(this);
						return;
					}
					if (gclass6_0.Users.Where((User u) => u.PIN == txtPIN.Text.Trim() && u.UserID != CS_0024_003C_003E8__locals0.user.UserID).Count() > 0)
					{
						new frmMessageBox(Resources.PIN_already_in_use_Please_sele0).ShowDialog(this);
						return;
					}
					CS_0024_003C_003E8__locals1.adminRole = gclass6_0.Roles.Where((Role u) => u.RoleName == Roles.admin).FirstOrDefault();
					if (CS_0024_003C_003E8__locals1.adminRole != null && gclass6_0.Users.Where((User u) => u.Active == true && u.RoleID == CS_0024_003C_003E8__locals1.adminRole.RoleID).Count() == 1 && CS_0024_003C_003E8__locals0.user.RoleID == CS_0024_003C_003E8__locals1.adminRole.RoleID && (!chkEmployeeActive.Value || Convert.ToInt16(ddlRoles.SelectedValue) != CS_0024_003C_003E8__locals1.adminRole.RoleID))
					{
						new frmMessageBox(Resources.It_s_required_to_have_at_least).ShowDialog(this);
						return;
					}
					employee.FirstName = txtFirstName.Text.Trim();
					employee.LastName = txtLastName.Text.Trim();
					employee.EmployeeName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
					employee.isActive = chkEmployeeActive.Value;
					employee.Phone1 = txtCell.Text.Trim();
					employee.Phone2 = txtHomePhone.Text.Trim();
					employee.Synced = false;
					string text = CS_0024_003C_003E8__locals0.user.PIN.ToString().Trim();
					CS_0024_003C_003E8__locals0.user.Active = chkPinActive.Value;
					CS_0024_003C_003E8__locals0.user.PIN = txtPIN.Text.Trim();
					try
					{
						CS_0024_003C_003E8__locals0.user.RoleID = Convert.ToInt16(ddlRoles.SelectedValue);
					}
					catch
					{
						CS_0024_003C_003E8__locals0.user.Role = gclass6_0.Roles.Where((Role x) => x.RoleID == Convert.ToInt16(ddlRoles.SelectedValue)).FirstOrDefault();
					}
					if (SettingsHelper.GetSettingValueByKey("hippos_time") == "Enabled" && text != txtPIN.Text.Trim() && !method_4(text, txtPIN.Text.Trim(), CS_0024_003C_003E8__locals0.user.HipposTimeEmployeeID))
					{
						new NotificationLabel(this, Resources.Unable_to_Save_Employee_to_Hip, NotificationTypes.Warning).Show();
					}
					Helper.SubmitChangesWithCatch(gclass6_0);
				}
				string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
				if (!string.IsNullOrEmpty(settingValueByKey) && settingValueByKey == "Enabled" && !string.IsNullOrEmpty(SyncMethods.GetToken()))
				{
					CreateEmployeeAccountObject data = new CreateEmployeeAccountObject
					{
						cs_apikey = SyncMethods.GetToken(),
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						EmployeeNumber = employee.EmployeeID.ToString(),
						IsActive = employee.isActive,
						PIN = CS_0024_003C_003E8__locals0.user.PIN,
						Position = CS_0024_003C_003E8__locals0.user.Role.RoleName,
						PhoneNo = employee.Phone1,
						PinActive = CS_0024_003C_003E8__locals0.user.Active
					};
					EmployeeAccountPinResponseObject employeeAccountPinResponseObject = ETimeCardMethods.CheckEmployeeExist(data);
					if (employeeAccountPinResponseObject.code == 200)
					{
						if (employeeAccountPinResponseObject.message == "false")
						{
							if (new frmMessageBox("Do you want to add employee to Hippos Time?", "Sync Employee Hippos Time", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
							{
								EmployeeAccountPinResponseObject employeeAccountPinResponseObject2 = ETimeCardMethods.CreateEmployee(data);
								if (employeeAccountPinResponseObject2.code == 200)
								{
									CS_0024_003C_003E8__locals0.user.HipposTimeEmployeeID = employeeAccountPinResponseObject2.HipposTimeId;
									gclass6_0.SubmitChanges();
									new NotificationLabel(this, "Successfully Sync to Hippos Time.", NotificationTypes.Success).Show();
								}
								else
								{
									new NotificationLabel(this, employeeAccountPinResponseObject2.message, NotificationTypes.Warning).Show();
								}
							}
						}
						else
						{
							CS_0024_003C_003E8__locals0.user.HipposTimeEmployeeID = employeeAccountPinResponseObject.HipposTimeId;
							gclass6_0.SubmitChanges();
						}
					}
					else if (!string.IsNullOrEmpty(employeeAccountPinResponseObject.message))
					{
						new NotificationLabel(this, employeeAccountPinResponseObject.message, NotificationTypes.Warning).Show();
					}
				}
				method_5(bool_0);
				new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
				MemoryLoadedObjects.RefreshUsers();
				btnNew.Enabled = true;
			}
			else
			{
				new frmMessageBox(Resources.First_last_name_is_required).ShowDialog(this);
			}
		}
		else
		{
			new frmMessageBox(Resources.Please_enter_an_eight_digit_pi).ShowDialog(this);
		}
	}

	private StatusCodeResponseLocation method_3()
	{
		StatusCodeResponseLocation locationData = ETimeCardMethods.GetLocationData(new LocationPostModel
		{
			token = SyncMethods.GetToken()
		});
		if (locationData.code == 200)
		{
			return locationData;
		}
		return null;
	}

	private bool method_4(string string_0, string string_1, Guid? nullable_0)
	{
		if (ETimeCardMethods.UpdateEmployeeAccountPin(new EmployeeAccountPinRequestObject
		{
			cs_apikey = SyncMethods.GetToken(),
			oldPin = string_0,
			newPin = string_1
		}).code == 200)
		{
			return true;
		}
		return false;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		method_7();
		btnNew.Enabled = true;
	}

	private void frmAdminEmployees_Load(object sender, EventArgs e)
	{
		method_5(bool_0);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Role item in from a in gclass6_0.Roles
			where a.RoleLevel.HasValue == false || (a.RoleLevel.HasValue && (int?)a.RoleLevel >= (int?)short_0)
			orderby (a.RoleLevel.HasValue == false) ? int.MaxValue : a.RoleLevel.Value
			select a)
		{
			dictionary.Add(item.RoleID.ToString(), item.RoleName);
		}
		ddlRoles.DisplayMember = "Value";
		ddlRoles.ValueMember = "Key";
		ddlRoles.DataSource = new BindingSource(dictionary, null);
	}

	private void method_5(bool bool_1)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.isActive = bool_1;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(1, 25);
		lstEmployees.SmallImageList = imageList;
		lstEmployees.Clear();
		foreach (Employee item in (from o in gclass6_0.Employees
			where o.isActive == CS_0024_003C_003E8__locals0.isActive && (o.Users.First().Role.RoleLevel.HasValue == false || (o.Users.First().Role.RoleLevel.HasValue && (int?)o.Users.First().Role.RoleLevel >= (int?)short_0))
			select o into s
			orderby s.FirstName
			select s).ToList())
		{
			lstEmployees.Items.Add(new ListViewItem(new string[2]
			{
				item.FirstName + " " + item.LastName,
				item.EmployeeID.ToString()
			}));
		}
	}

	private void method_6()
	{
		RadTextBoxControl radTextBoxControl = txtFirstName;
		RadTextBoxControl radTextBoxControl2 = txtLastName;
		RadTextBoxControl radTextBoxControl3 = txtCell;
		RadTextBoxControl radTextBoxControl4 = txtHomePhone;
		string text = (txtPIN.Text = string.Empty);
		string text3 = (radTextBoxControl4.Text = text);
		string text5 = (radTextBoxControl3.Text = text3);
		string text7 = (radTextBoxControl2.Text = text5);
		radTextBoxControl.Text = text7;
	}

	private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_7()
	{
		GClass6 gClass = new GClass6();
		if (lstEmployees.SelectedItems.Count != 0)
		{
			int_0 = Convert.ToInt32(lstEmployees.SelectedItems[0].SubItems[1].Text);
			Employee employee = gClass.Employees.Where((Employee s) => s.EmployeeID == int_0).FirstOrDefault();
			User user = gClass.Users.Where((User u) => u.EmployeeID == int_0).FirstOrDefault();
			if (employee != null && user == null && user == null)
			{
				user = new User();
				user.EmployeeID = int_0;
				user.Active = false;
				user.PIN = "0";
				user.RoleID = 3;
				gClass.Users.InsertOnSubmit(user);
				Helper.SubmitChangesWithCatch(gClass);
			}
			if (employee != null && user != null)
			{
				txtFirstName.Text = employee.FirstName;
				txtLastName.Text = employee.LastName;
				txtCell.Text = employee.Phone1;
				txtHomePhone.Text = employee.Phone2;
				txtPIN.Text = user.PIN.ToString();
				chkEmployeeActive.Value = employee.isActive;
				chkPinActive.Value = user.Active;
				ddlRoles.SelectedValue = user.RoleID.ToString();
				btnNew.Enabled = true;
			}
			else
			{
				new frmMessageBox(Resources.Something_went_wrong_while_loa).ShowDialog(this);
			}
		}
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		method_6();
		int_0 = 0;
		btnNew.Enabled = false;
	}

	private void method_8(string string_0, RadTextBoxControl radTextBoxControl_0)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(string_0, 1, 64, radTextBoxControl_0.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl_0.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_9(string string_0, RadTextBoxControl radTextBoxControl_0, int int_1 = 2, int int_2 = 4)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(string_0, int_1, int_2, radTextBoxControl_0.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl_0.Text = MemoryLoadedObjects.Numpad.valueEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Cell_Click(object sender, EventArgs e)
	{
		method_9(Resources.Enter_Cell_Phone_Number, txtCell, 0, 10);
	}

	private void btnShowKeyboard_HomePhone_Click(object sender, EventArgs e)
	{
		method_9(Resources.Enter_Home_Phone_Number, txtHomePhone, 0, 10);
	}

	private void btnShowKeyboard_LastName_Click(object sender, EventArgs e)
	{
		method_8(Resources.Enter_Last_Name, txtLastName);
	}

	private void btnShowKeyboard_FirstName_Click(object sender, EventArgs e)
	{
		method_8(Resources.Enter_First_Name, txtFirstName);
	}

	private void btnShowKeyboard_PIN_Click(object sender, EventArgs e)
	{
		method_9(Resources.Enter_Employee_PIN, txtPIN, 0, 10);
	}

	private void method_10(object sender, EventArgs e)
	{
	}

	private void txtLastName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void chkShowInActive_ValueChanged(object sender, EventArgs e)
	{
		bool_0 = chkShowInActive.Value;
		method_5(bool_0);
	}

	private void btnSyncEmployeeToCloud_Click(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminEmployees));
		chkShowInActive = new RadToggleSwitch();
		txtPIN = new RadTextBoxControl();
		txtCell = new RadTextBoxControl();
		txtHomePhone = new RadTextBoxControl();
		txtFirstName = new RadTextBoxControl();
		txtLastName = new RadTextBoxControl();
		chkPinActive = new RadToggleSwitch();
		chkEmployeeActive = new RadToggleSwitch();
		btnShowKeyboard_LastName = new Button();
		btnShowKeyboard_PIN = new Button();
		btnShowKeyboard_HomePhone = new Button();
		btnShowKeyboard_Cell = new Button();
		btnShowKeyboard_FirstName = new Button();
		btnNew = new Button();
		label2 = new Label();
		label13 = new Label();
		label14 = new Label();
		label12 = new Label();
		label10 = new Label();
		label3 = new Label();
		label6 = new Label();
		label5 = new Label();
		label4 = new Label();
		label9 = new Label();
		lstEmployees = new ListView();
		btnCancel = new Button();
		btnSave = new Button();
		label1 = new Label();
		btnSyncEmployeeToCloud = new Button();
		ddlRoles = new Class20();
		((ISupportInitialize)chkShowInActive).BeginInit();
		((ISupportInitialize)txtPIN).BeginInit();
		((ISupportInitialize)txtCell).BeginInit();
		((ISupportInitialize)txtHomePhone).BeginInit();
		((ISupportInitialize)txtFirstName).BeginInit();
		((ISupportInitialize)txtLastName).BeginInit();
		((ISupportInitialize)chkPinActive).BeginInit();
		((ISupportInitialize)chkEmployeeActive).BeginInit();
		((ISupportInitialize)ddlRoles).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(chkShowInActive, "chkShowInActive");
		chkShowInActive.Name = "chkShowInActive";
		chkShowInActive.OffText = "INACTIVE EMPLOYEES";
		chkShowInActive.OnText = "ACTIVE EMPLOYEES";
		chkShowInActive.Tag = "product";
		chkShowInActive.ToggleStateMode = ToggleStateMode.Click;
		chkShowInActive.ValueChanged += chkShowInActive_ValueChanged;
		((RadToggleSwitchElement)chkShowInActive.GetChildAt(0)).ThumbOffset = 123;
		((RadToggleSwitchElement)chkShowInActive.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkShowInActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkShowInActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowInActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowInActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkShowInActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(txtPIN, "txtPIN");
		txtPIN.ForeColor = Color.FromArgb(40, 40, 40);
		txtPIN.Name = "txtPIN";
		txtPIN.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPIN.Click += txtLastName_Click;
		((RadTextBoxControlElement)txtPIN.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPIN.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtCell, "txtCell");
		txtCell.ForeColor = Color.FromArgb(40, 40, 40);
		txtCell.Name = "txtCell";
		txtCell.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtCell.Click += txtLastName_Click;
		((RadTextBoxControlElement)txtCell.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtCell.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtHomePhone, "txtHomePhone");
		txtHomePhone.ForeColor = Color.FromArgb(40, 40, 40);
		txtHomePhone.Name = "txtHomePhone";
		txtHomePhone.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtHomePhone.Click += txtLastName_Click;
		((RadTextBoxControlElement)txtHomePhone.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtHomePhone.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtFirstName, "txtFirstName");
		txtFirstName.ForeColor = Color.FromArgb(40, 40, 40);
		txtFirstName.Name = "txtFirstName";
		txtFirstName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtFirstName.Click += txtLastName_Click;
		((RadTextBoxControlElement)txtFirstName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtFirstName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtLastName, "txtLastName");
		txtLastName.ForeColor = Color.FromArgb(40, 40, 40);
		txtLastName.Name = "txtLastName";
		txtLastName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtLastName.Click += txtLastName_Click;
		((RadTextBoxControlElement)txtLastName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtLastName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(chkPinActive, "chkPinActive");
		chkPinActive.Name = "chkPinActive";
		chkPinActive.OffText = "NO";
		chkPinActive.OnText = "YES";
		chkPinActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkPinActive.GetChildAt(0)).ThumbOffset = 59;
		((RadToggleSwitchElement)chkPinActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkPinActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkPinActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPinActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPinActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text1");
		((ToggleSwitchPartElement)chkPinActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkEmployeeActive, "chkEmployeeActive");
		chkEmployeeActive.Name = "chkEmployeeActive";
		chkEmployeeActive.OffText = "NO";
		chkEmployeeActive.OnText = "YES";
		chkEmployeeActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkEmployeeActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkEmployeeActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkEmployeeActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkEmployeeActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEmployeeActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEmployeeActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text2");
		((ToggleSwitchPartElement)chkEmployeeActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		btnShowKeyboard_LastName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_LastName.DialogResult = DialogResult.OK;
		btnShowKeyboard_LastName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_LastName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_LastName, "btnShowKeyboard_LastName");
		btnShowKeyboard_LastName.ForeColor = Color.White;
		btnShowKeyboard_LastName.Name = "btnShowKeyboard_LastName";
		btnShowKeyboard_LastName.UseVisualStyleBackColor = false;
		btnShowKeyboard_LastName.Click += btnShowKeyboard_LastName_Click;
		btnShowKeyboard_PIN.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_PIN.DialogResult = DialogResult.OK;
		btnShowKeyboard_PIN.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_PIN.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_PIN, "btnShowKeyboard_PIN");
		btnShowKeyboard_PIN.ForeColor = Color.White;
		btnShowKeyboard_PIN.Name = "btnShowKeyboard_PIN";
		btnShowKeyboard_PIN.UseVisualStyleBackColor = false;
		btnShowKeyboard_PIN.Click += btnShowKeyboard_PIN_Click;
		btnShowKeyboard_HomePhone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_HomePhone.DialogResult = DialogResult.OK;
		btnShowKeyboard_HomePhone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_HomePhone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_HomePhone, "btnShowKeyboard_HomePhone");
		btnShowKeyboard_HomePhone.ForeColor = Color.White;
		btnShowKeyboard_HomePhone.Name = "btnShowKeyboard_HomePhone";
		btnShowKeyboard_HomePhone.UseVisualStyleBackColor = false;
		btnShowKeyboard_HomePhone.Click += btnShowKeyboard_HomePhone_Click;
		btnShowKeyboard_Cell.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Cell.DialogResult = DialogResult.OK;
		btnShowKeyboard_Cell.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Cell.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Cell, "btnShowKeyboard_Cell");
		btnShowKeyboard_Cell.ForeColor = Color.White;
		btnShowKeyboard_Cell.Name = "btnShowKeyboard_Cell";
		btnShowKeyboard_Cell.UseVisualStyleBackColor = false;
		btnShowKeyboard_Cell.Click += btnShowKeyboard_Cell_Click;
		btnShowKeyboard_FirstName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_FirstName.DialogResult = DialogResult.OK;
		btnShowKeyboard_FirstName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_FirstName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_FirstName, "btnShowKeyboard_FirstName");
		btnShowKeyboard_FirstName.ForeColor = Color.White;
		btnShowKeyboard_FirstName.Name = "btnShowKeyboard_FirstName";
		btnShowKeyboard_FirstName.UseVisualStyleBackColor = false;
		btnShowKeyboard_FirstName.Click += btnShowKeyboard_FirstName_Click;
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.White;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label13.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		label14.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		label12.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label10.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label9.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		lstEmployees.AutoArrange = false;
		lstEmployees.BackColor = Color.White;
		lstEmployees.BorderStyle = BorderStyle.None;
		lstEmployees.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstEmployees, "lstEmployees");
		lstEmployees.ForeColor = Color.FromArgb(40, 40, 40);
		lstEmployees.FullRowSelect = true;
		lstEmployees.GridLines = true;
		lstEmployees.Groups.AddRange(new ListViewGroup[2]
		{
			(ListViewGroup)componentResourceManager.GetObject("lstEmployees.Groups"),
			(ListViewGroup)componentResourceManager.GetObject("lstEmployees.Groups1")
		});
		lstEmployees.HideSelection = false;
		lstEmployees.MultiSelect = false;
		lstEmployees.Name = "lstEmployees";
		lstEmployees.UseCompatibleStateImageBehavior = false;
		lstEmployees.View = View.List;
		lstEmployees.SelectedIndexChanged += lstEmployees_SelectedIndexChanged;
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		label1.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnSyncEmployeeToCloud.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(btnSyncEmployeeToCloud, "btnSyncEmployeeToCloud");
		btnSyncEmployeeToCloud.FlatAppearance.BorderSize = 0;
		btnSyncEmployeeToCloud.ForeColor = SystemColors.ButtonFace;
		btnSyncEmployeeToCloud.Name = "btnSyncEmployeeToCloud";
		btnSyncEmployeeToCloud.UseVisualStyleBackColor = false;
		btnSyncEmployeeToCloud.Click += btnSyncEmployeeToCloud_Click;
		componentResourceManager.ApplyResources(ddlRoles, "ddlRoles");
		ddlRoles.BackColor = Color.White;
		ddlRoles.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlRoles.EnableKineticScrolling = true;
		ddlRoles.Name = "ddlRoles";
		ddlRoles.ThemeName = "Windows8";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(ddlRoles);
		base.Controls.Add(btnSyncEmployeeToCloud);
		base.Controls.Add(chkShowInActive);
		base.Controls.Add(txtPIN);
		base.Controls.Add(txtCell);
		base.Controls.Add(txtHomePhone);
		base.Controls.Add(txtFirstName);
		base.Controls.Add(txtLastName);
		base.Controls.Add(chkPinActive);
		base.Controls.Add(chkEmployeeActive);
		base.Controls.Add(btnShowKeyboard_LastName);
		base.Controls.Add(btnShowKeyboard_PIN);
		base.Controls.Add(btnShowKeyboard_HomePhone);
		base.Controls.Add(btnShowKeyboard_Cell);
		base.Controls.Add(btnShowKeyboard_FirstName);
		base.Controls.Add(btnNew);
		base.Controls.Add(label2);
		base.Controls.Add(label13);
		base.Controls.Add(label14);
		base.Controls.Add(label12);
		base.Controls.Add(label10);
		base.Controls.Add(label3);
		base.Controls.Add(label6);
		base.Controls.Add(label5);
		base.Controls.Add(label4);
		base.Controls.Add(label9);
		base.Controls.Add(lstEmployees);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminEmployees";
		base.Opacity = 1.0;
		base.Load += frmAdminEmployees_Load;
		((ISupportInitialize)chkShowInActive).EndInit();
		((ISupportInitialize)txtPIN).EndInit();
		((ISupportInitialize)txtCell).EndInit();
		((ISupportInitialize)txtHomePhone).EndInit();
		((ISupportInitialize)txtFirstName).EndInit();
		((ISupportInitialize)txtLastName).EndInit();
		((ISupportInitialize)chkPinActive).EndInit();
		((ISupportInitialize)chkEmployeeActive).EndInit();
		((ISupportInitialize)ddlRoles).EndInit();
		ResumeLayout(performLayout: false);
	}
}
