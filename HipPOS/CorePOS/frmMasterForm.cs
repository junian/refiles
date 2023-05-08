using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS;

public class frmMasterForm : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Control ctrl;

		public frmMasterForm _003C_003E4__this;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CRefreshLockedControls_003Eb__5(LockedControl x)
		{
			return x.Name == ctrl.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public LockedControl locked;

		public _003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals1;

		public _003C_003Ec__DisplayClass12_1()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal bool _003CRefreshLockedControls_003Eb__7(SecurityMatrix x)
		{
			if (x.ModuleID == locked.ModuleId)
			{
				return x.IsAllow;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_2
	{
		public Delegate click;

		public _003C_003Ec__DisplayClass12_1 CS_0024_003C_003E8__locals2;

		public _003C_003Ec__DisplayClass12_2()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CRefreshLockedControls_003Eb__6(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			list = (from x in MemoryLoadedObjects.all_securityMatrixes
				where x.ModuleID == CS_0024_003C_003E8__locals2.locked.ModuleId && x.IsAllow
				select x into y
				select y.Role.RoleName).ToList();
			if (AuthMethods.ValidatePin(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, list))
			{
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Invoke(click);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Func<Control, bool> isMatch;

		public List<Control> matches;

		public Action<Control> filter;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}

		internal void _003CFilterControls_003Eb__0(Control c)
		{
			if (isMatch(c))
			{
				matches.Add(c);
			}
			foreach (Control control in c.Controls)
			{
				filter(control);
			}
		}
	}

	[CompilerGenerated]
	private static List<LockedControl> list_0;

	[CompilerGenerated]
	private static List<string> list_1;

	public bool darkenBg;

	public bool overridePin;

	public PersistentNotification PersistentNotification;

	private IContainer icontainer_0;

	public static List<LockedControl> lockedControls
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public static List<string> allowedRoles
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public frmMasterForm()
	{
		Class26.Ggkj0JxzN9YmC();
		darkenBg = true;
		base._002Ector();
		InitializeComponent();
		PersistentNotification = new PersistentNotification();
		base.Controls.Add(PersistentNotification);
	}

	public void RefreshLockedControls()
	{
		Employee employee = null;
		ErrorHelper.ScreenLeakErrorMessage = "Error at form " + base.Name;
		if (!AuthMethods.isFormAuthenticationRequired(base.Name) || overridePin)
		{
			return;
		}
		bool showRememberMe = true;
		if (base.Name == "frmAdmin")
		{
			showRememberMe = false;
		}
		allowedRoles = (from securityMatrix_0 in MemoryLoadedObjects.all_securityMatrixes
			where securityMatrix_0.ModulesAndFeature.ModuleName == base.Name && securityMatrix_0.IsAllow
			select securityMatrix_0 into y
			select y.Role.RoleName).ToList();
		employee = AuthMethods.EmployeeLoginBeforeFormControl(this, base.Name, autoClose: true, showRememberMe);
		if (employee == null)
		{
			Close();
			return;
		}
		Control control = method_0(this, (Control c) => c.Name == "btnAssignEmployee").FirstOrDefault();
		if (control != null)
		{
			control.Enabled = true;
		}
		short roleID = employee.Users.FirstOrDefault().RoleID;
		lockedControls = AuthMethods.ControlsToLock(base.Name, roleID);
		Control[] array = method_0(this, (Control c) => lockedControls.Select((LockedControl x) => x.Name).Contains(c.Name));
		for (int i = 0; i < array.Length; i++)
		{
			_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
			_003C_003Ec__DisplayClass12_._003C_003E4__this = this;
			_003C_003Ec__DisplayClass12_.ctrl = array[i];
			_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_2 = new _003C_003Ec__DisplayClass12_1();
			_003C_003Ec__DisplayClass12_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass12_;
			_003C_003Ec__DisplayClass12_2.locked = list_0.Where((LockedControl x) => x.Name == _003C_003Ec__DisplayClass12_2.CS_0024_003C_003E8__locals1.ctrl.Name).FirstOrDefault();
			if (!_003C_003Ec__DisplayClass12_2.locked.AllowCtrlOverride)
			{
				if (roleID != RoleIDs.employee && roleID != RoleIDs.manager && roleID != RoleIDs.supervisor)
				{
					if (roleID == RoleIDs.patron || roleID == RoleIDs.kiosk)
					{
						_003C_003Ec__DisplayClass12_2.CS_0024_003C_003E8__locals1.ctrl.Visible = false;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass12_2.CS_0024_003C_003E8__locals1.ctrl.Enabled = false;
				}
				continue;
			}
			_003C_003Ec__DisplayClass12_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_2();
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass12_2;
			if (((CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Name.Contains("btnClear") || CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Name.Contains("btnRemove") || CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Name.Contains("btnChangePrice") || CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Name.Contains("btnOrderDiscount")) && SettingsHelper.CurrentTerminalMode != "Kiosk") || (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Name == "btnClose" && SettingsHelper.CurrentTerminalMode == "Kiosk"))
			{
				continue;
			}
			object value = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
			EventHandlerList eventHandlerList = (EventHandlerList)typeof(Component).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl, null);
			CS_0024_003C_003E8__locals0.click = eventHandlerList[value];
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Click -= (EventHandler)CS_0024_003C_003E8__locals0.click;
			CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Click += delegate
			{
				List<string> list = new List<string>();
				list = (from x in MemoryLoadedObjects.all_securityMatrixes
					where x.ModuleID == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.locked.ModuleId && x.IsAllow
					select x into y
					select y.Role.RoleName).ToList();
				if (AuthMethods.ValidatePin(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, list))
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ctrl.Invoke(CS_0024_003C_003E8__locals0.click);
				}
			};
		}
	}

	private void frmMasterForm_Load(object sender, EventArgs e)
	{
		RefreshLockedControls();
		PersistentNotification.ShowOnlineOrderReceivedCheck(base.Name);
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void frmMasterForm_LostFocus(object sender, EventArgs e)
	{
		PersistentNotification.hasFocus = false;
	}

	private void frmMasterForm_GotFocus(object sender, EventArgs e)
	{
		PersistentNotification.hasFocus = true;
	}

	private Control[] method_0(Control control_0, Func<Control, bool> func_0)
	{
		_003C_003Ec__DisplayClass16_0 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_0();
		_003C_003Ec__DisplayClass16_.isMatch = func_0;
		_003C_003Ec__DisplayClass16_.matches = new List<Control>();
		_003C_003Ec__DisplayClass16_.filter = null;
		(_003C_003Ec__DisplayClass16_.filter = delegate(Control c)
		{
			if (_003C_003Ec__DisplayClass16_.isMatch(c))
			{
				_003C_003Ec__DisplayClass16_.matches.Add(c);
			}
			foreach (Control control in c.Controls)
			{
				_003C_003Ec__DisplayClass16_.filter(control);
			}
		})(control_0);
		return _003C_003Ec__DisplayClass16_.matches.ToArray();
	}

	private void frmMasterForm_FormClosing(object sender, EventArgs e)
	{
		if (PersistentNotification != null)
		{
			PersistentNotification.Dispose();
		}
		if (list_0 != null)
		{
			list_0.Clear();
		}
		lockedControls = null;
		if (list_1 != null)
		{
			list_1.Clear();
		}
		allowedRoles = null;
		Dispose();
		GC.Collect();
	}

	private void method_1(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.frmMasterForm));
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmMasterForm";
		base.Opacity = 0.0;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMasterForm_FormClosing);
		base.Load += new System.EventHandler(frmMasterForm_Load);
		base.GotFocus += new System.EventHandler(frmMasterForm_GotFocus);
		base.LostFocus += new System.EventHandler(frmMasterForm_LostFocus);
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_2(SecurityMatrix securityMatrix_0)
	{
		if (securityMatrix_0.ModulesAndFeature.ModuleName == base.Name)
		{
			return securityMatrix_0.IsAllow;
		}
		return false;
	}
}
