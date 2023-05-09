using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;

namespace CorePOS;

public class frmKioskOrderTypeSelection : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public GClass6 context;

		public System.Windows.Forms.Timer timer;

		public frmKioskOrderTypeSelection _003C_003E4__this;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}

		internal void _003CfrmKioskOrderTypeSelection_Load_003Eb__0()
		{
			MemoryLoadedObjects.ListOfPatronItemControlObject = new List<PatronItemControl>();
			foreach (Item item2 in context.Items.Where((Item a) => a.Active == true && a.isDeleted == false))
			{
				PatronItemControl item = new PatronItemControl(item2)
				{
					Name = item2.ItemID.ToString()
				};
				MemoryLoadedObjects.ListOfPatronItemControlObject.Add(item);
			}
		}

		internal void _003CfrmKioskOrderTypeSelection_Load_003Eb__1(object sender, MouseEventArgs e)
		{
			timer.Start();
		}

		internal void _003CfrmKioskOrderTypeSelection_Load_003Eb__2(object sender, MouseEventArgs e)
		{
			timer.Stop();
		}

		internal void _003CfrmKioskOrderTypeSelection_Load_003Eb__3(object sender, EventArgs e)
		{
			timer.Stop();
		}

		internal void _003CfrmKioskOrderTypeSelection_Load_003Eb__4(object sender, EventArgs e)
		{
			timer.Stop();
			List<string> roles = new List<string>
			{
				Roles.admin,
				Roles.manager
			};
			if (AuthMethods.ValidatePin(_003C_003E4__this, roles))
			{
				_003C_003E4__this.Close();
				_003C_003E4__this.frmPatron_0.Dispose();
			}
		}
	}

	private frmPatron frmPatron_0;

	private IContainer icontainer_1;

	internal Button btnToGo;

	internal Button LmdFnFuVqiQ;

	internal Button btnClose;

	internal Button btnLanguageChange;

	public frmKioskOrderTypeSelection()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("primary_language");
		string settingValueByKey2 = SettingsHelper.GetSettingValueByKey("secondary_language");
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = currentCulture;
		Thread.CurrentThread.CurrentUICulture = currentCulture;
		if (settingValueByKey != settingValueByKey2)
		{
			if (currentCulture.Name == settingValueByKey)
			{
				CultureInfo cultureInfo = new CultureInfo(settingValueByKey2);
				btnLanguageChange.Text = method_3(cultureInfo.NativeName.ToUpper());
				btnLanguageChange.Tag = settingValueByKey2;
				btnLanguageChange.Enabled = true;
			}
			else
			{
				CultureInfo cultureInfo2 = new CultureInfo(settingValueByKey);
				btnLanguageChange.Text = method_3(cultureInfo2.NativeName.ToUpper());
				btnLanguageChange.Tag = settingValueByKey;
				btnLanguageChange.Enabled = true;
			}
		}
		else
		{
			btnLanguageChange.Text = string.Empty;
			btnLanguageChange.Enabled = false;
		}
		frmPatron_0 = new frmPatron();
	}

	private string method_3(string string_0)
	{
		string[] array = string_0.Split(' ');
		string text = string.Empty;
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (!text2.Contains("(") && !text2.Contains(")"))
			{
				text += (string.IsNullOrEmpty(text) ? text2 : (" " + text2));
			}
		}
		return text;
	}

	private void LmdFnFuVqiQ_Click(object sender, EventArgs e)
	{
		method_4(OrderTypes.DineIn);
	}

	private void method_4(string string_0)
	{
		frmPatron_0.LoadFormData(null, "Walk In", string_0, 0);
		frmPatron_0.ShowDialog();
	}

	private void btnToGo_Click(object sender, EventArgs e)
	{
		method_4(OrderTypes.ToGo);
	}

	private void frmKioskOrderTypeSelection_Load(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.context = new GClass6();
		new Thread((ThreadStart)delegate
		{
			MemoryLoadedObjects.ListOfPatronItemControlObject = new List<PatronItemControl>();
			foreach (Item item2 in CS_0024_003C_003E8__locals0.context.Items.Where((Item a) => a.Active == true && a.isDeleted == false))
			{
				PatronItemControl item = new PatronItemControl(item2)
				{
					Name = item2.ItemID.ToString()
				};
				MemoryLoadedObjects.ListOfPatronItemControlObject.Add(item);
			}
		}).Start();
		CS_0024_003C_003E8__locals0.timer = new System.Windows.Forms.Timer();
		CS_0024_003C_003E8__locals0.timer.Interval = 1500;
		btnClose.MouseDown += delegate
		{
			CS_0024_003C_003E8__locals0.timer.Start();
		};
		btnClose.MouseUp += delegate
		{
			CS_0024_003C_003E8__locals0.timer.Stop();
		};
		btnClose.MouseLeave += delegate
		{
			CS_0024_003C_003E8__locals0.timer.Stop();
		};
		CS_0024_003C_003E8__locals0.timer.Tick += delegate
		{
			CS_0024_003C_003E8__locals0.timer.Stop();
			List<string> roles = new List<string>
			{
				Roles.admin,
				Roles.manager
			};
			if (AuthMethods.ValidatePin(CS_0024_003C_003E8__locals0._003C_003E4__this, roles))
			{
				CS_0024_003C_003E8__locals0._003C_003E4__this.Close();
				CS_0024_003C_003E8__locals0._003C_003E4__this.frmPatron_0.Dispose();
			}
		};
	}

	private void btnLanguageChange_Click(object sender, EventArgs e)
	{
		CultureInfo cultureInfo = new CultureInfo(btnLanguageChange.Tag.ToString());
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		Close();
		new frmKioskOrderTypeSelection().ShowDialog();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmKioskOrderTypeSelection));
		btnToGo = new Button();
		LmdFnFuVqiQ = new Button();
		btnClose = new Button();
		btnLanguageChange = new Button();
		SuspendLayout();
		componentResourceManager.ApplyResources(btnToGo, "btnToGo");
		btnToGo.BackColor = Color.Transparent;
		btnToGo.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnToGo.FlatAppearance.BorderSize = 0;
		btnToGo.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnToGo.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnToGo.ForeColor = Color.White;
		btnToGo.Name = "btnToGo";
		btnToGo.UseVisualStyleBackColor = false;
		btnToGo.Click += btnToGo_Click;
		componentResourceManager.ApplyResources(LmdFnFuVqiQ, "btnNewOrder");
		LmdFnFuVqiQ.BackColor = Color.Transparent;
		LmdFnFuVqiQ.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		LmdFnFuVqiQ.FlatAppearance.BorderSize = 0;
		LmdFnFuVqiQ.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		LmdFnFuVqiQ.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		LmdFnFuVqiQ.ForeColor = Color.White;
		LmdFnFuVqiQ.Name = "btnNewOrder";
		LmdFnFuVqiQ.UseVisualStyleBackColor = false;
		LmdFnFuVqiQ.Click += LmdFnFuVqiQ_Click;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.Transparent;
		btnClose.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(btnLanguageChange, "btnLanguageChange");
		btnLanguageChange.BackColor = Color.Transparent;
		btnLanguageChange.FlatAppearance.BorderColor = Color.FromArgb(35, 39, 56);
		btnLanguageChange.FlatAppearance.BorderSize = 0;
		btnLanguageChange.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 61, 85);
		btnLanguageChange.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 61, 85);
		btnLanguageChange.ForeColor = Color.White;
		btnLanguageChange.Name = "btnLanguageChange";
		btnLanguageChange.UseVisualStyleBackColor = false;
		btnLanguageChange.Click += btnLanguageChange_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(btnLanguageChange);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnToGo);
		base.Controls.Add(LmdFnFuVqiQ);
		base.Name = "frmKioskOrderTypeSelection";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmKioskOrderTypeSelection_Load;
		ResumeLayout(performLayout: false);
	}
}
