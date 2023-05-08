using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Data.Properties;
using CorePOS.Properties;

namespace CorePOS;

public static class AuthMethods
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string formName;

		public string ControlName;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CEmployeeAuthenticateControlDifferentForm_003Eb__0(SecurityObject a)
		{
			if (a.FormName == formName && a.ControlName == ControlName)
			{
				return a.isAllowed;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public string FormName;

		public string ControlName;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CIsPinRequired_003Eb__0(SecurityObject a)
		{
			if (a.FormName == FormName && a.ControlName == ControlName)
			{
				return a.isAllowed;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string FormName;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CisFormAuthenticationRequired_003Eb__0(SecurityObject a)
		{
			return a.FormName == FormName;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public string FormName;

		public short RoleID;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CControlsToLock_003Eb__0(SecurityObject a)
		{
			if (a.FormName == FormName && a.ControlName != null && a.RoleID == RoleID)
			{
				return !a.isAllowed;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public string FormName;

		public string ControlName;

		public _003C_003Ec__DisplayClass8_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CisUserAuthenticated_003Eb__0(SecurityObject a)
		{
			if (a.FormName == FormName)
			{
				return a.ControlName == ControlName;
			}
			return false;
		}

		internal bool _003CisUserAuthenticated_003Eb__3(SecurityObject a)
		{
			if (a.FormName == FormName && a.ControlName == ControlName)
			{
				return a.isAllowed;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Employee emp;

		public _003C_003Ec__DisplayClass8_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CisUserAuthenticated_003Eb__1(SecurityObject x)
		{
			if (x.RoleID == emp.Users.FirstOrDefault().RoleID)
			{
				return x.isAllowed;
			}
			return false;
		}
	}

	public static Employee EmployeeLoginFormControl(Form form, string ControlName)
	{
		if (Application.OpenForms.OfType<frmNumpad>().FirstOrDefault() != null)
		{
			return null;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		bool flag = false;
		do
		{
			if (MemoryLoadedObjects.Numpad.ShowDialog(form) != DialogResult.OK)
			{
				flag = true;
				form.Close();
				continue;
			}
			Employee employee = UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered));
			if (employee != null)
			{
				flag = true;
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
				if (isUserAuthenticated(form.Name))
				{
					return employee;
				}
				flag = false;
			}
			else
			{
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(form);
				MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				flag = true;
			}
		}
		while (!flag);
		return null;
	}

	public static Employee EmployeeLoginBeforeFormControl(Form callingForm, string FormName, bool autoClose = true, bool showRememberMe = true)
	{
		if (callingForm.Name == "frmSplash")
		{
			autoClose = false;
		}
		if (isUserAuthenticated(FormName, null, "", showMessage: false))
		{
			if (Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()) > 0)
			{
				return UserMethods.GetUserByID(Convert.ToInt16(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
			}
			return UserMethods.GetUserByID(1);
		}
		if (Application.OpenForms.OfType<frmNumpad>().FirstOrDefault() != null)
		{
			return null;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		MemoryLoadedObjects.Numpad.showRememberMe = showRememberMe;
		if (MemoryLoadedObjects.Numpad.ShowDialog(callingForm) == DialogResult.OK)
		{
			Employee employee = UserMethods.AuthenticateUser(MemoryLoadedObjects.Numpad.valueEntered);
			if (employee != null)
			{
				CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employee.EmployeeID;
				if (isUserAuthenticated(FormName))
				{
					GC.Collect();
					return employee;
				}
				if (autoClose)
				{
					callingForm.Close();
				}
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog();
			}
			else
			{
				if (autoClose)
				{
					callingForm.Close();
				}
				new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog();
			}
		}
		return null;
	}

	public static Employee EmployeeAuthenticateControl(Form form, string ControlName, bool replaceCurrentLogin = false)
	{
		return EmployeeAuthenticateControlDifferentForm(form, form.Name, ControlName, replaceCurrentLogin);
	}

	public static Employee EmployeeAuthenticateControlDifferentForm(Form form, string FormName, string ControlName, bool replaceCurrentLogin = false)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.ControlName = ControlName;
		List<string> list = new List<string>();
		CS_0024_003C_003E8__locals0.formName = FormName.Replace("TileView", string.Empty).Replace("ListView", string.Empty);
		foreach (SecurityObject item in SecurityHelper.SecuritySettings.Where((SecurityObject a) => a.FormName == CS_0024_003C_003E8__locals0.formName && a.ControlName == CS_0024_003C_003E8__locals0.ControlName && a.isAllowed).ToList())
		{
			if (item.RoleID == 1)
			{
				list.Add(Roles.admin);
			}
			else if (item.RoleID == 2)
			{
				list.Add(Roles.manager);
			}
			else if (item.RoleID == 3)
			{
				list.Add(Roles.employee);
			}
			else if (item.RoleID == 6)
			{
				list.Add(Roles.supervisor);
			}
			else if (item.RoleID == 4)
			{
				list.Add(Roles.patron);
			}
			else
			{
				list.Add(Roles.kiosk);
			}
		}
		if (list.Count > 0)
		{
			if (isUserAuthenticated(FormName, CS_0024_003C_003E8__locals0.ControlName, "", showMessage: false))
			{
				return EmployeeMethods.getEmployeeByID(Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()));
			}
			bool flag = false;
			do
			{
				MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
				MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
				MemoryLoadedObjects.Numpad.showRememberMe = false;
				if (MemoryLoadedObjects.Numpad.ShowDialog(form) != DialogResult.OK)
				{
					flag = true;
				}
				else if (UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered), list))
				{
					Employee employeeByPIN = UserMethods.GetEmployeeByPIN(MemoryLoadedObjects.Numpad.valueEntered);
					if (employeeByPIN != null)
					{
						flag = true;
						if (replaceCurrentLogin)
						{
							CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = employeeByPIN.EmployeeID;
						}
						return employeeByPIN;
					}
					new frmMessageBox(Resources.Invalid_PIN_entered).ShowDialog(form);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
				else
				{
					List<string> list2 = list.ToList();
					list2.Remove(Roles.kiosk);
					list2.Remove(Roles.patron);
					new frmMessageBox(Resources.Invalid_PIN_entered + " Please enter PIN with following roles: " + string.Join(", ", list2)).ShowDialog(form);
					MemoryLoadedObjects.Numpad.TextInput = string.Empty;
				}
			}
			while (!flag);
			return null;
		}
		return null;
	}

	public static bool IsPinRequired(string FormName, string ControlName)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.FormName = FormName;
		CS_0024_003C_003E8__locals0.ControlName = ControlName;
		if (SecurityHelper.SecuritySettings.Where((SecurityObject a) => a.FormName == CS_0024_003C_003E8__locals0.FormName && a.ControlName == CS_0024_003C_003E8__locals0.ControlName && a.isAllowed).ToList().Count >= 1)
		{
			return true;
		}
		return false;
	}

	public static bool isFormAuthenticationRequired(string FormName)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.FormName = FormName;
		if (SecurityHelper.SecuritySettings.Where((SecurityObject a) => a.FormName == CS_0024_003C_003E8__locals0.FormName).ToList().Count() > 0)
		{
			return true;
		}
		return false;
	}

	public static List<LockedControl> ControlsToLock(string FormName, short RoleID)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.FormName = FormName;
		CS_0024_003C_003E8__locals0.RoleID = RoleID;
		return (from a in SecurityHelper.SecuritySettings
			where a.FormName == CS_0024_003C_003E8__locals0.FormName && a.ControlName != null && a.RoleID == CS_0024_003C_003E8__locals0.RoleID && !a.isAllowed
			select a into x
			select new LockedControl
			{
				ModuleId = x.ModuleId,
				Name = x.ControlName,
				AllowCtrlOverride = x.AllowAdminCtrlOverride
			}).ToList();
	}

	public static void LogOutUser()
	{
		if (!MemoryLoadedObjects.isUserRemember)
		{
			CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
		}
	}

	public static bool isUserAuthenticated(string FormName, string ControlName = null, string password = "", bool showMessage = true)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.FormName = FormName;
		CS_0024_003C_003E8__locals0.ControlName = ControlName;
		if ((!string.IsNullOrEmpty(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString()) && CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString() != "0") || !string.IsNullOrEmpty(password))
		{
			_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass8_1();
			int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
			new GClass6();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.FormName))
			{
				if (num == 0)
				{
					CS_0024_003C_003E8__locals1.emp = UserMethods.AuthenticateUser(Convert.ToString(password));
					if (CS_0024_003C_003E8__locals1.emp == null)
					{
						CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
						return false;
					}
					num = CS_0024_003C_003E8__locals1.emp.EmployeeID;
				}
				else
				{
					CS_0024_003C_003E8__locals1.emp = EmployeeMethods.getEmployeeByID(num);
				}
				List<SecurityObject> source = SecurityHelper.SecuritySettings.Where((SecurityObject a) => a.FormName == CS_0024_003C_003E8__locals0.FormName && a.ControlName == CS_0024_003C_003E8__locals0.ControlName).ToList();
				new List<string>();
				if (source.Count() > 0)
				{
					if (source.Where((SecurityObject x) => x.RoleID == CS_0024_003C_003E8__locals1.emp.Users.FirstOrDefault().RoleID && x.isAllowed).Count() <= 0 && source.Where((SecurityObject x) => !x.isAllowed && (x.RoleID == 1 || x.RoleID == 2 || x.RoleID == 3)).Count() != 3)
					{
						return false;
					}
					return true;
				}
				return true;
			}
		}
		else if (CS_0024_003C_003E8__locals0.FormName != "frmLayout" && CS_0024_003C_003E8__locals0.FormName != "frmRefund" && SecurityHelper.SecuritySettings.Where((SecurityObject a) => a.FormName == CS_0024_003C_003E8__locals0.FormName && a.ControlName == CS_0024_003C_003E8__locals0.ControlName && a.isAllowed).Count() == 0)
		{
			return true;
		}
		CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] = 0;
		if (showMessage)
		{
			new frmMessageBox("User not authenticated.").ShowDialog();
		}
		return false;
	}

	public static bool ValidatePin(Form parent, List<string> roles, bool showRememberMe = true)
	{
		if (roles.Count() == 0)
		{
			new NotificationLabel(parent, Resources.Invalid_PIN_entered, NotificationTypes.Warning).Show();
			return false;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		int num = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
		if (num == 0)
		{
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
			MemoryLoadedObjects.Numpad.showRememberMe = showRememberMe;
			if (MemoryLoadedObjects.Numpad.ShowDialog(parent) == DialogResult.OK)
			{
				if (UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered), roles))
				{
					GC.Collect();
					return true;
				}
				new NotificationLabel(parent, Resources.Invalid_PIN_entered, NotificationTypes.Warning).Show();
				GC.Collect();
				return false;
			}
			GC.Collect();
			return false;
		}
		Employee employeeByID = UserMethods.GetEmployeeByID(num);
		if (employeeByID != null)
		{
			if (roles.Contains(employeeByID.Users.FirstOrDefault().Role.RoleName))
			{
				employeeByID = null;
				return true;
			}
			MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
			MemoryLoadedObjects.Numpad.showRememberMe = false;
			if (MemoryLoadedObjects.Numpad.ShowDialog(parent) == DialogResult.OK)
			{
				if (UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered), roles))
				{
					return true;
				}
				new NotificationLabel(parent, Resources.Invalid_PIN_entered, NotificationTypes.Warning).Show();
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool ValidateAdmin()
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		if (MemoryLoadedObjects.Numpad.ShowDialog() == DialogResult.OK)
		{
			List<string> list = new List<string>();
			list.Add(Roles.admin);
			if (UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered), list))
			{
				return true;
			}
		}
		return false;
	}

	public static bool ValidateAnyUser()
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_PIN);
		if (MemoryLoadedObjects.Numpad.ShowDialog() == DialogResult.OK && UserMethods.AuthenticateUser(Convert.ToString(MemoryLoadedObjects.Numpad.valueEntered)) != null)
		{
			return true;
		}
		return false;
	}
}
