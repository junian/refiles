using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class WorkFlowSettings : UserControl
{
	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private PictureBox pictureBox6;

	private Label label_showQS_desc;

	private RadToggleSwitch chkShowQuickServiceScreen;

	private Label label_showQS_title;

	private PictureBox pictureBox8;

	private Label label_showfinal_desc;

	private RadToggleSwitch chkShowCashout;

	private Label label_showfinal_title;

	private Panel pnlQuickServiceScreen;

	private PictureBox pictureBox9;

	private Label label_lockstaff_title;

	private RadToggleSwitch chkLockTableStaff;

	private Label label_lockstaff_desc;

	private PictureBox pictureBox11;

	private RadToggleSwitch chkUpcScanning;

	private Label label_upc_desc;

	private Label label_upc_title;

	private Label label_autolocklayout_title;

	private RadToggleSwitch chkAutoLockLayout;

	private Label label_autolocklayout_desc;

	private PictureBox pictureBox13;

	private Panel pnlFullService;

	private Label label_autocleartable_title;

	private RadToggleSwitch chkAutoClearTable;

	private Label label_autocleartable_desc;

	private PictureBox pictureBox14;

	private PictureBox pictureBox16;

	private RadToggleSwitch chkAutoGratuity;

	private Label label_autogratuity_desc;

	private Label label_autogratuity_title;

	private Panel pnlAutoGratuity;

	private RadTextBoxControl txtAutoGratuityPercentage;

	private Label lblTipPercentage;

	private RadTextBoxControl txtAutoGratuityCount;

	private Label lblGuest;

	private PictureBox pictureBox21;

	private RadToggleSwitch chkVoidReason;

	private Label label_void_reason_desc;

	private Label label_void_reason_title;

	private PictureBox pictureBox23;

	private RadToggleSwitch chkMemberSelection;

	private Label label_memberselection_desc;

	private Label label_memberselection_title;

	private PictureBox pictureBox1;

	private RadToggleSwitch chkAutoTipCashBack;

	private Label label_autotip_desc;

	private Label label_autotip_title;

	private Label label16;

	private Panel pnlAll;

	private PictureBox pictureBox2;

	private RadToggleSwitch chkPromptCashoutPIN;

	private Label label1;

	private Label label2;

	private PictureBox pictureBox3;

	private RadToggleSwitch chkChitCashout;

	private Label label3;

	private Label label4;

	private PictureBox pictureBox4;

	private RadToggleSwitch chkConfirmOnlineOrder;

	private Label label5;

	private Label label6;

	private PictureBox pictureBox5;

	private Label label7;

	private RadToggleSwitch chkItemCourse;

	private Label label8;

	private PictureBox pictureBox7;

	private Label label9;

	private RadToggleSwitch chkAutoLogoutCloseOE;

	private Label label10;

	private RadToggleSwitch chkShowIfChange;

	private Label label12;

	private RadToggleSwitch chkTipTracking;

	private Label label_tiptracking_desc;

	private PictureBox pictureBox15;

	private Label label_tiptracking_title;

	private Label lblConfigSafeDrop;

	private Label label11;

	private RadToggleSwitch chkSafeDrop;

	private Label label13;

	private PictureBox pictureBox10;

	private Label label14;

	private Label label15;

	private RadToggleSwitch chkOpenCloseStore;

	private PictureBox pictureBox12;

	private RadToggleSwitch chkThresholdFul;

	private Label label17;

	private PictureBox pictureBox17;

	private Label label18;

	private Class19 ddlThresholdHours;

	private Class19 ddlPickupOrderTimeInc;

	private Label label22;

	private PictureBox pictureBox19;

	private Label label21;

	private PictureBox pictureBox18;

	private Label label19;

	private RadToggleSwitch chkAutoClearOrders;

	private Label label20;

	private RadToggleSwitch chkAutoLogoutCashout;

	private PictureBox pictureBox20;

	private Label label23;

	private Label label24;

	private PictureBox pictureBox22;

	private Label label25;

	private RadToggleSwitch chkOnlineOrdNotifSound;

	private Label label26;

	private PictureBox pictureBox24;

	private Label label27;

	private RadToggleSwitch chkOnlineOrdNotif;

	private Label label28;

	private PictureBox pictureBox25;

	private Label label29;

	private RadToggleSwitch chkShowEmployeeTable;

	private Label label30;

	private Class19 ddlIntervalTime;

	private PictureBox pictureBox26;

	private Label label31;

	private Label label32;

	public WorkFlowSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		if (iqueryable_0.Where((Setting a) => a.Key == "restaurant_mode").FirstOrDefault().Value == "Dine In")
		{
			chkAutoLockLayout.Value = ((iqueryable_0.Where((Setting x) => x.Key == "auto_lock_layout").FirstOrDefault().Value == "ON") ? true : false);
			chkAutoClearTable.Value = ((iqueryable_0.Where((Setting x) => x.Key == "auto_clear_table").FirstOrDefault().Value == "ON") ? true : false);
			chkTipTracking.Value = ((iqueryable_0.Where((Setting x) => x.Key == "tip_tracking").FirstOrDefault().Value == "ON") ? true : false);
			pnlFullService.Location = new Point(pnlAll.Location.X, pnlAll.Location.Y + pnlAll.Height);
			pnlFullService.Visible = true;
		}
		else
		{
			pnlQuickServiceScreen.Location = new Point(pnlAll.Location.X, pnlAll.Location.Y + pnlAll.Height);
			pnlQuickServiceScreen.Visible = true;
		}
		List<Control> list = new List<Control>();
		foreach (Control control in base.Controls)
		{
			if (control.Name.Contains("pnl"))
			{
				foreach (Control control2 in control.Controls)
				{
					list.Add(control2);
				}
			}
			else
			{
				list.Add(control);
			}
		}
		using (IEnumerator<Control> enumerator3 = list.Where((Control x) => x.Visible).GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
				CS_0024_003C_003E8__locals0.ctrl = enumerator3.Current;
				if (CS_0024_003C_003E8__locals0.ctrl.Tag == null)
				{
					continue;
				}
				Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.ctrl.Tag.Equals(s.Key)).FirstOrDefault();
				if (setting == null)
				{
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.GetType().Name == "Label")
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("label"))
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
					}
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl"))
				{
					string text = "";
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains(ddlThresholdHours.Name))
					{
						text = ((setting.Value == "0.5" || setting.Value == "1") ? " hour" : " hours");
					}
					CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value + text;
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("AutoGratuity") && setting.Value == "OFF")
				{
					pnlAutoGratuity.Visible = false;
				}
				else if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("AutoGratuity") && setting.Value == "ON")
				{
					pnlAutoGratuity.Visible = true;
					Setting setting2 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_count").FirstOrDefault();
					txtAutoGratuityCount.Text = setting2.Value;
					Setting setting3 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
					txtAutoGratuityPercentage.Text = setting3.Value;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains(chkThresholdFul.Name))
				{
					if (setting.Value == "ON")
					{
						ddlThresholdHours.Visible = true;
					}
					else
					{
						ddlThresholdHours.Visible = false;
					}
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name != chkShowCashout.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkUpcScanning.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkAutoClearTable.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkAutoGratuity.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkSafeDrop.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkOpenCloseStore.Name && CS_0024_003C_003E8__locals0.ctrl.Name != chkThresholdFul.Name)
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.ValueChanged += method_0;
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.Tag = ((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag;
				}
				if (setting.Value.Contains("ON"))
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = true;
				}
				else
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = false;
				}
			}
		}
		bool_0 = false;
	}

	private void method_0(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.chkToggle = sender as RadToggleSwitchElement;
		Console.Write(CS_0024_003C_003E8__locals0.chkToggle.Tag);
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.chkToggle.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.ToUpper().Equals("ON"))
			{
				setting.Value = "OFF";
			}
			else
			{
				setting.Value = "ON";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.chkToggle.Tag.ToString(), setting.Value);
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		new frmVideoUploader().Show(this);
	}

	private void chkShowCashout_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkShowCashout.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkShowCashout.Value)
			{
				setting.Value = "ON";
				RadToggleSwitch radToggleSwitch = chkShowIfChange;
				chkShowIfChange.Value = true;
				radToggleSwitch.Enabled = true;
			}
			else
			{
				setting.Value = "OFF";
				RadToggleSwitch radToggleSwitch2 = chkShowIfChange;
				chkShowIfChange.Value = false;
				radToggleSwitch2.Enabled = false;
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(chkShowCashout.Tag.ToString(), setting.Value);
		}
	}

	private void chkUpcScanning_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkUpcScanning.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkUpcScanning.Value)
			{
				setting.Value = "ON";
			}
			else
			{
				setting.Value = "OFF";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(chkUpcScanning.Tag.ToString(), setting.Value);
			if (new frmMessageBox("Hippos needs to be restarted for the UPC scanning setting to take effect.", Resources.Settings_changed, CustomMessageBoxButtons.YesNo)
			{
				yesButtonText = "Restart"
			}.ShowDialog(this) == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	private void chkAutoClearTable_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (chkAutoClearTable.Value && new frmMessageBox("All tables that currently waiting for a tip (green tables) will be cleared. Are you sure you want to continue?", "WARNING", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
		{
			chkAutoClearTable.ValueChanged -= chkAutoClearTable_ValueChanged;
			chkAutoClearTable.Value = false;
			chkAutoClearTable.ValueChanged += chkAutoClearTable_ValueChanged;
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkAutoClearTable.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkAutoClearTable.Value)
			{
				setting.Value = "ON";
			}
			else
			{
				setting.Value = "OFF";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(chkAutoClearTable.Tag.ToString(), setting.Value);
		}
	}

	private void chkAutoGratuity_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkAutoGratuity.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (!chkAutoGratuity.Value)
		{
			setting.Value = "OFF";
			pnlAutoGratuity.Visible = false;
		}
		else
		{
			setting.Value = "ON";
			pnlAutoGratuity.Visible = true;
			Setting setting2 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_count").FirstOrDefault();
			txtAutoGratuityCount.Text = setting2.Value;
			Setting setting3 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
			txtAutoGratuityPercentage.Text = setting3.Value;
		}
		setting.Synced = false;
		Helper.SubmitChangesWithCatch(gclass6_0);
		SettingsHelper.SetSettingValueByKey(chkAutoGratuity.Tag.ToString(), setting.Value);
	}

	private void txtAutoGratuityCount_TextChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		decimal result = default(decimal);
		if (!decimal.TryParse(txtAutoGratuityCount.Text, out result))
		{
			new frmMessageBox("You can only enter numerical values on this field.").ShowDialog(this);
			txtAutoGratuityCount.Text = "0";
			return;
		}
		if (txtAutoGratuityCount.Text.Contains("-"))
		{
			new frmMessageBox("Auto Gratuity guest count cannot be a negative value, please enter a new value.").ShowDialog(this);
			txtAutoGratuityCount.Text = "";
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_count").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = txtAutoGratuityCount.Text;
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey("auto_gratuity_count", setting.Value);
		}
	}

	private void txtAutoGratuityPercentage_TextChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		decimal result = default(decimal);
		if (!decimal.TryParse(txtAutoGratuityPercentage.Text, out result))
		{
			new frmMessageBox("You can only enter numerical values on this field.").ShowDialog(this);
			txtAutoGratuityPercentage.Text = "0";
			return;
		}
		if (txtAutoGratuityPercentage.Text.Contains("-"))
		{
			new frmMessageBox("Auto Gratuity percentage cannot be a negative value, please enter a new value.").ShowDialog(this);
			txtAutoGratuityPercentage.Text = "";
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = txtAutoGratuityPercentage.Text;
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey("auto_gratuity_percentage", setting.Value);
		}
	}

	private void txtAutoGratuityCount_Click(object sender, EventArgs e)
	{
		RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(radTextBoxControl.Tag.ToString(), 2, 6, radTextBoxControl.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void chkSafeDrop_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkSafeDrop.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (chkSafeDrop.Value)
		{
			setting.Value = "ON";
			if (!chkOpenCloseStore.Value)
			{
				chkOpenCloseStore.Value = true;
				new NotificationLabel(base.ParentForm, "'Opening && Closing Store' feature is automatically enabled.", NotificationTypes.Notification).Show();
			}
		}
		else
		{
			setting.Value = "OFF";
		}
		setting.Synced = false;
		gclass6_0.SubmitChanges();
		SettingsHelper.SetSettingValueByKey(chkSafeDrop.Tag.ToString(), setting.Value);
	}

	private void lblConfigSafeDrop_Click(object sender, EventArgs e)
	{
		new frmSafeDropSettings().ShowDialog(this);
	}

	private void chkOpenCloseStore_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkOpenCloseStore.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (chkOpenCloseStore.Value)
		{
			setting.Value = "ON";
		}
		else
		{
			setting.Value = "OFF";
			if (chkSafeDrop.Value)
			{
				chkSafeDrop.Value = false;
				new NotificationLabel(base.ParentForm, "'Safe Drop' is automatically disabled.", NotificationTypes.Notification).Show();
			}
		}
		setting.Synced = false;
		gclass6_0.SubmitChanges();
		SettingsHelper.SetSettingValueByKey(chkOpenCloseStore.Tag.ToString(), setting.Value);
	}

	private void chkThresholdFul_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkThresholdFul.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkThresholdFul.Value)
			{
				setting.Value = "ON";
				ddlThresholdHours.Visible = true;
			}
			else
			{
				setting.Value = "OFF";
				ddlThresholdHours.Visible = false;
			}
			setting.Synced = false;
			gclass6_0.SubmitChanges();
			SettingsHelper.SetSettingValueByKey(chkThresholdFul.Tag.ToString(), setting.Value);
		}
	}

	private void ddlThresholdHours_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlThresholdHours.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlThresholdHours.Text.Replace("hours", string.Empty).Replace("hour", string.Empty).Trim();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlThresholdHours.Tag.ToString(), setting.Value);
			}
		}
	}

	private void ddlPickupOrderTimeInc_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlPickupOrderTimeInc.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlPickupOrderTimeInc.Text.Trim();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlPickupOrderTimeInc.Tag.ToString(), setting.Value);
			}
		}
	}

	private void ddlIntervalTime_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlIntervalTime.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlIntervalTime.Text.Trim();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlIntervalTime.Tag.ToString(), setting.Value);
			}
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.WorkFlowSettings));
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label_showQS_desc = new System.Windows.Forms.Label();
		this.chkShowQuickServiceScreen = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_showQS_title = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label_showfinal_desc = new System.Windows.Forms.Label();
		this.chkShowCashout = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_showfinal_title = new System.Windows.Forms.Label();
		this.pnlQuickServiceScreen = new System.Windows.Forms.Panel();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.chkChitCashout = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.label_lockstaff_title = new System.Windows.Forms.Label();
		this.chkLockTableStaff = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_lockstaff_desc = new System.Windows.Forms.Label();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.chkUpcScanning = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_upc_desc = new System.Windows.Forms.Label();
		this.label_upc_title = new System.Windows.Forms.Label();
		this.label_autolocklayout_title = new System.Windows.Forms.Label();
		this.chkAutoLockLayout = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_autolocklayout_desc = new System.Windows.Forms.Label();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.pnlFullService = new System.Windows.Forms.Panel();
		this.pictureBox25 = new System.Windows.Forms.PictureBox();
		this.label29 = new System.Windows.Forms.Label();
		this.chkShowEmployeeTable = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label30 = new System.Windows.Forms.Label();
		this.chkAutoLogoutCashout = new Telerik.WinControls.UI.RadToggleSwitch();
		this.pictureBox20 = new System.Windows.Forms.PictureBox();
		this.label23 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.pictureBox14 = new System.Windows.Forms.PictureBox();
		this.label_autocleartable_title = new System.Windows.Forms.Label();
		this.chkAutoClearTable = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label8 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label_autocleartable_desc = new System.Windows.Forms.Label();
		this.chkAutoGratuity = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label7 = new System.Windows.Forms.Label();
		this.pnlAutoGratuity = new System.Windows.Forms.Panel();
		this.txtAutoGratuityPercentage = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtAutoGratuityCount = new Telerik.WinControls.UI.RadTextBoxControl();
		this.lblTipPercentage = new System.Windows.Forms.Label();
		this.lblGuest = new System.Windows.Forms.Label();
		this.chkItemCourse = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label9 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.pictureBox16 = new System.Windows.Forms.PictureBox();
		this.label_autogratuity_desc = new System.Windows.Forms.Label();
		this.chkAutoLogoutCloseOE = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label10 = new System.Windows.Forms.Label();
		this.label_autogratuity_title = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.chkAutoTipCashBack = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_autotip_desc = new System.Windows.Forms.Label();
		this.label_autotip_title = new System.Windows.Forms.Label();
		this.pictureBox21 = new System.Windows.Forms.PictureBox();
		this.chkVoidReason = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_void_reason_desc = new System.Windows.Forms.Label();
		this.label_void_reason_title = new System.Windows.Forms.Label();
		this.pictureBox23 = new System.Windows.Forms.PictureBox();
		this.chkMemberSelection = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label_memberselection_desc = new System.Windows.Forms.Label();
		this.label_memberselection_title = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.pnlAll = new System.Windows.Forms.Panel();
		this.ddlIntervalTime = new Class19();
		this.pictureBox26 = new System.Windows.Forms.PictureBox();
		this.label31 = new System.Windows.Forms.Label();
		this.label32 = new System.Windows.Forms.Label();
		this.pictureBox22 = new System.Windows.Forms.PictureBox();
		this.label25 = new System.Windows.Forms.Label();
		this.chkOnlineOrdNotifSound = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label26 = new System.Windows.Forms.Label();
		this.pictureBox24 = new System.Windows.Forms.PictureBox();
		this.label27 = new System.Windows.Forms.Label();
		this.chkOnlineOrdNotif = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label28 = new System.Windows.Forms.Label();
		this.pictureBox18 = new System.Windows.Forms.PictureBox();
		this.label19 = new System.Windows.Forms.Label();
		this.ddlPickupOrderTimeInc = new Class19();
		this.chkAutoClearOrders = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label22 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.pictureBox19 = new System.Windows.Forms.PictureBox();
		this.label21 = new System.Windows.Forms.Label();
		this.ddlThresholdHours = new Class19();
		this.chkThresholdFul = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label17 = new System.Windows.Forms.Label();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.label18 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.chkOpenCloseStore = new Telerik.WinControls.UI.RadToggleSwitch();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.lblConfigSafeDrop = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.chkSafeDrop = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label13 = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.chkShowIfChange = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label12 = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.chkTipTracking = new Telerik.WinControls.UI.RadToggleSwitch();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label_tiptracking_desc = new System.Windows.Forms.Label();
		this.chkPromptCashoutPIN = new Telerik.WinControls.UI.RadToggleSwitch();
		this.pictureBox15 = new System.Windows.Forms.PictureBox();
		this.label_tiptracking_title = new System.Windows.Forms.Label();
		this.chkConfirmOnlineOrder = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label5 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowQuickServiceScreen).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowCashout).BeginInit();
		this.pnlQuickServiceScreen.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkChitCashout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkLockTableStaff).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkUpcScanning).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLockLayout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).BeginInit();
		this.pnlFullService.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox25).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowEmployeeTable).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLogoutCashout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoClearTable).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoGratuity).BeginInit();
		this.pnlAutoGratuity.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAutoGratuityPercentage).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAutoGratuityCount).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemCourse).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLogoutCloseOE).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoTipCashBack).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkVoidReason).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkMemberSelection).BeginInit();
		this.pnlAll.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox22).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkOnlineOrdNotifSound).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkOnlineOrdNotif).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoClearOrders).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkThresholdFul).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkOpenCloseStore).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkSafeDrop).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowIfChange).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkTipTracking).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPromptCashoutPIN).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkConfirmOnlineOrder).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		resources.ApplyResources(this.label_showQS_desc, "label_showQS_desc");
		this.label_showQS_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showQS_desc.Name = "label_showQS_desc";
		this.label_showQS_desc.Tag = "";
		resources.ApplyResources(this.chkShowQuickServiceScreen, "chkShowQuickServiceScreen");
		this.chkShowQuickServiceScreen.Name = "chkShowQuickServiceScreen";
		this.chkShowQuickServiceScreen.Tag = "quickservice_screen";
		this.chkShowQuickServiceScreen.ThumbTickness = 27;
		this.chkShowQuickServiceScreen.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkShowQuickServiceScreen.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowQuickServiceScreen.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowQuickServiceScreen.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowQuickServiceScreen.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowQuickServiceScreen.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowQuickServiceScreen.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowQuickServiceScreen.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowQuickServiceScreen.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label_showQS_title.BackColor = System.Drawing.Color.Transparent;
		this.label_showQS_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_showQS_title, "label_showQS_title");
		this.label_showQS_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showQS_title.Name = "label_showQS_title";
		resources.ApplyResources(this.pictureBox8, "pictureBox8");
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.TabStop = false;
		resources.ApplyResources(this.label_showfinal_desc, "label_showfinal_desc");
		this.label_showfinal_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showfinal_desc.Name = "label_showfinal_desc";
		this.label_showfinal_desc.Tag = "";
		resources.ApplyResources(this.chkShowCashout, "chkShowCashout");
		this.chkShowCashout.Name = "chkShowCashout";
		this.chkShowCashout.Tag = "payfinish_screen";
		this.chkShowCashout.ThumbTickness = 27;
		this.chkShowCashout.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkShowCashout.Value = false;
		this.chkShowCashout.ValueChanged += new System.EventHandler(chkShowCashout_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowCashout.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowCashout.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowCashout.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowCashout.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowCashout.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowCashout.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowCashout.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label_showfinal_title.BackColor = System.Drawing.Color.Transparent;
		this.label_showfinal_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_showfinal_title, "label_showfinal_title");
		this.label_showfinal_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showfinal_title.Name = "label_showfinal_title";
		this.pnlQuickServiceScreen.Controls.Add(this.pictureBox3);
		this.pnlQuickServiceScreen.Controls.Add(this.chkChitCashout);
		this.pnlQuickServiceScreen.Controls.Add(this.label3);
		this.pnlQuickServiceScreen.Controls.Add(this.label4);
		this.pnlQuickServiceScreen.Controls.Add(this.label_showQS_title);
		this.pnlQuickServiceScreen.Controls.Add(this.chkShowQuickServiceScreen);
		this.pnlQuickServiceScreen.Controls.Add(this.label_showQS_desc);
		this.pnlQuickServiceScreen.Controls.Add(this.pictureBox6);
		resources.ApplyResources(this.pnlQuickServiceScreen, "pnlQuickServiceScreen");
		this.pnlQuickServiceScreen.Name = "pnlQuickServiceScreen";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		resources.ApplyResources(this.chkChitCashout, "chkChitCashout");
		this.chkChitCashout.Name = "chkChitCashout";
		this.chkChitCashout.Tag = "print_chit_cashout";
		this.chkChitCashout.ThumbTickness = 27;
		this.chkChitCashout.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkChitCashout.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkChitCashout.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkChitCashout.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkChitCashout.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkChitCashout.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkChitCashout.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkChitCashout.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkChitCashout.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		resources.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		resources.ApplyResources(this.pictureBox9, "pictureBox9");
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.TabStop = false;
		this.label_lockstaff_title.BackColor = System.Drawing.Color.Transparent;
		this.label_lockstaff_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_lockstaff_title, "label_lockstaff_title");
		this.label_lockstaff_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_lockstaff_title.Name = "label_lockstaff_title";
		resources.ApplyResources(this.chkLockTableStaff, "chkLockTableStaff");
		this.chkLockTableStaff.Name = "chkLockTableStaff";
		this.chkLockTableStaff.Tag = "lock_table_staff";
		this.chkLockTableStaff.ThumbTickness = 27;
		this.chkLockTableStaff.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkLockTableStaff.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkLockTableStaff.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkLockTableStaff.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkLockTableStaff.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkLockTableStaff.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkLockTableStaff.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkLockTableStaff.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkLockTableStaff.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_lockstaff_desc, "label_lockstaff_desc");
		this.label_lockstaff_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_lockstaff_desc.Name = "label_lockstaff_desc";
		this.label_lockstaff_desc.Tag = "";
		resources.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		resources.ApplyResources(this.chkUpcScanning, "chkUpcScanning");
		this.chkUpcScanning.Name = "chkUpcScanning";
		this.chkUpcScanning.Tag = "upc_scanning";
		this.chkUpcScanning.ThumbTickness = 27;
		this.chkUpcScanning.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkUpcScanning.Value = false;
		this.chkUpcScanning.ValueChanged += new System.EventHandler(chkUpcScanning_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkUpcScanning.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkUpcScanning.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkUpcScanning.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkUpcScanning.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkUpcScanning.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkUpcScanning.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkUpcScanning.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_upc_desc, "label_upc_desc");
		this.label_upc_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_upc_desc.Name = "label_upc_desc";
		this.label_upc_desc.Tag = "";
		this.label_upc_title.BackColor = System.Drawing.Color.Transparent;
		this.label_upc_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_upc_title, "label_upc_title");
		this.label_upc_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_upc_title.Name = "label_upc_title";
		this.label_autolocklayout_title.BackColor = System.Drawing.Color.Transparent;
		this.label_autolocklayout_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_autolocklayout_title, "label_autolocklayout_title");
		this.label_autolocklayout_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autolocklayout_title.Name = "label_autolocklayout_title";
		resources.ApplyResources(this.chkAutoLockLayout, "chkAutoLockLayout");
		this.chkAutoLockLayout.Name = "chkAutoLockLayout";
		this.chkAutoLockLayout.Tag = "auto_lock_layout";
		this.chkAutoLockLayout.ThumbTickness = 27;
		this.chkAutoLockLayout.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoLockLayout.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLockLayout.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLockLayout.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLockLayout.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLockLayout.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLockLayout.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLockLayout.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLockLayout.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_autolocklayout_desc, "label_autolocklayout_desc");
		this.label_autolocklayout_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autolocklayout_desc.Name = "label_autolocklayout_desc";
		this.label_autolocklayout_desc.Tag = "";
		resources.ApplyResources(this.pictureBox13, "pictureBox13");
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.TabStop = false;
		this.pnlFullService.Controls.Add(this.pictureBox25);
		this.pnlFullService.Controls.Add(this.label29);
		this.pnlFullService.Controls.Add(this.chkShowEmployeeTable);
		this.pnlFullService.Controls.Add(this.label30);
		this.pnlFullService.Controls.Add(this.chkAutoLogoutCashout);
		this.pnlFullService.Controls.Add(this.pictureBox20);
		this.pnlFullService.Controls.Add(this.label23);
		this.pnlFullService.Controls.Add(this.label24);
		this.pnlFullService.Controls.Add(this.pictureBox14);
		this.pnlFullService.Controls.Add(this.pictureBox13);
		this.pnlFullService.Controls.Add(this.label_autocleartable_title);
		this.pnlFullService.Controls.Add(this.label_autolocklayout_title);
		this.pnlFullService.Controls.Add(this.chkAutoClearTable);
		this.pnlFullService.Controls.Add(this.label8);
		this.pnlFullService.Controls.Add(this.pictureBox7);
		this.pnlFullService.Controls.Add(this.label_autocleartable_desc);
		this.pnlFullService.Controls.Add(this.label_lockstaff_desc);
		this.pnlFullService.Controls.Add(this.chkAutoGratuity);
		this.pnlFullService.Controls.Add(this.label7);
		this.pnlFullService.Controls.Add(this.chkLockTableStaff);
		this.pnlFullService.Controls.Add(this.pnlAutoGratuity);
		this.pnlFullService.Controls.Add(this.chkItemCourse);
		this.pnlFullService.Controls.Add(this.label9);
		this.pnlFullService.Controls.Add(this.pictureBox5);
		this.pnlFullService.Controls.Add(this.pictureBox16);
		this.pnlFullService.Controls.Add(this.label_lockstaff_title);
		this.pnlFullService.Controls.Add(this.chkAutoLockLayout);
		this.pnlFullService.Controls.Add(this.label_autolocklayout_desc);
		this.pnlFullService.Controls.Add(this.label_autogratuity_desc);
		this.pnlFullService.Controls.Add(this.chkAutoLogoutCloseOE);
		this.pnlFullService.Controls.Add(this.pictureBox9);
		this.pnlFullService.Controls.Add(this.label10);
		this.pnlFullService.Controls.Add(this.label_autogratuity_title);
		resources.ApplyResources(this.pnlFullService, "pnlFullService");
		this.pnlFullService.Name = "pnlFullService";
		resources.ApplyResources(this.pictureBox25, "pictureBox25");
		this.pictureBox25.Name = "pictureBox25";
		this.pictureBox25.TabStop = false;
		this.label29.BackColor = System.Drawing.Color.Transparent;
		this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label29, "label29");
		this.label29.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label29.Name = "label29";
		resources.ApplyResources(this.chkShowEmployeeTable, "chkShowEmployeeTable");
		this.chkShowEmployeeTable.Name = "chkShowEmployeeTable";
		this.chkShowEmployeeTable.Tag = "show_employee_table";
		this.chkShowEmployeeTable.ThumbTickness = 27;
		this.chkShowEmployeeTable.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkShowEmployeeTable.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowEmployeeTable.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowEmployeeTable.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowEmployeeTable.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowEmployeeTable.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowEmployeeTable.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowEmployeeTable.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowEmployeeTable.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label30, "label30");
		this.label30.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label30.Name = "label30";
		this.label30.Tag = "";
		resources.ApplyResources(this.chkAutoLogoutCashout, "chkAutoLogoutCashout");
		this.chkAutoLogoutCashout.Name = "chkAutoLogoutCashout";
		this.chkAutoLogoutCashout.Tag = "auto_logout_cashout";
		this.chkAutoLogoutCashout.ThumbTickness = 27;
		this.chkAutoLogoutCashout.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoLogoutCashout.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCashout.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCashout.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCashout.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCashout.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCashout.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCashout.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCashout.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.pictureBox20, "pictureBox20");
		this.pictureBox20.Name = "pictureBox20";
		this.pictureBox20.TabStop = false;
		this.label23.BackColor = System.Drawing.Color.Transparent;
		this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label23, "label23");
		this.label23.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label23.Name = "label23";
		resources.ApplyResources(this.label24, "label24");
		this.label24.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label24.Name = "label24";
		this.label24.Tag = "";
		resources.ApplyResources(this.pictureBox14, "pictureBox14");
		this.pictureBox14.Name = "pictureBox14";
		this.pictureBox14.TabStop = false;
		this.label_autocleartable_title.BackColor = System.Drawing.Color.Transparent;
		this.label_autocleartable_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_autocleartable_title, "label_autocleartable_title");
		this.label_autocleartable_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autocleartable_title.Name = "label_autocleartable_title";
		resources.ApplyResources(this.chkAutoClearTable, "chkAutoClearTable");
		this.chkAutoClearTable.Name = "chkAutoClearTable";
		this.chkAutoClearTable.Tag = "auto_clear_table";
		this.chkAutoClearTable.ThumbTickness = 27;
		this.chkAutoClearTable.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoClearTable.Value = false;
		this.chkAutoClearTable.ValueChanged += new System.EventHandler(chkAutoClearTable_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearTable.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearTable.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearTable.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearTable.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearTable.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearTable.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearTable.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		this.label8.Tag = "";
		resources.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		resources.ApplyResources(this.label_autocleartable_desc, "label_autocleartable_desc");
		this.label_autocleartable_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autocleartable_desc.Name = "label_autocleartable_desc";
		this.label_autocleartable_desc.Tag = "";
		resources.ApplyResources(this.chkAutoGratuity, "chkAutoGratuity");
		this.chkAutoGratuity.Name = "chkAutoGratuity";
		this.chkAutoGratuity.Tag = "auto_gratuity";
		this.chkAutoGratuity.ThumbTickness = 27;
		this.chkAutoGratuity.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoGratuity.Value = false;
		this.chkAutoGratuity.ValueChanged += new System.EventHandler(chkAutoGratuity_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoGratuity.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoGratuity.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoGratuity.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoGratuity.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoGratuity.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoGratuity.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoGratuity.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		this.pnlAutoGratuity.Controls.Add(this.txtAutoGratuityPercentage);
		this.pnlAutoGratuity.Controls.Add(this.txtAutoGratuityCount);
		this.pnlAutoGratuity.Controls.Add(this.lblTipPercentage);
		this.pnlAutoGratuity.Controls.Add(this.lblGuest);
		resources.ApplyResources(this.pnlAutoGratuity, "pnlAutoGratuity");
		this.pnlAutoGratuity.Name = "pnlAutoGratuity";
		resources.ApplyResources(this.txtAutoGratuityPercentage, "txtAutoGratuityPercentage");
		this.txtAutoGratuityPercentage.Name = "txtAutoGratuityPercentage";
		this.txtAutoGratuityPercentage.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtAutoGratuityPercentage.Tag = "Tip Percentage";
		this.txtAutoGratuityPercentage.TextChanged += new System.EventHandler(txtAutoGratuityPercentage_TextChanged);
		this.txtAutoGratuityPercentage.Click += new System.EventHandler(txtAutoGratuityCount_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtAutoGratuityPercentage.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtAutoGratuityPercentage.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		resources.ApplyResources(this.txtAutoGratuityCount, "txtAutoGratuityCount");
		this.txtAutoGratuityCount.Name = "txtAutoGratuityCount";
		this.txtAutoGratuityCount.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtAutoGratuityCount.Tag = "Minimum Number of Guest";
		this.txtAutoGratuityCount.TextChanged += new System.EventHandler(txtAutoGratuityCount_TextChanged);
		this.txtAutoGratuityCount.Click += new System.EventHandler(txtAutoGratuityCount_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtAutoGratuityCount.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtAutoGratuityCount.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		resources.ApplyResources(this.lblTipPercentage, "lblTipPercentage");
		this.lblTipPercentage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblTipPercentage.Name = "lblTipPercentage";
		this.lblTipPercentage.Tag = "";
		resources.ApplyResources(this.lblGuest, "lblGuest");
		this.lblGuest.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblGuest.Name = "lblGuest";
		this.lblGuest.Tag = "";
		resources.ApplyResources(this.chkItemCourse, "chkItemCourse");
		this.chkItemCourse.Name = "chkItemCourse";
		this.chkItemCourse.Tag = "course_selection";
		this.chkItemCourse.ThumbTickness = 27;
		this.chkItemCourse.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkItemCourse.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkItemCourse.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkItemCourse.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkItemCourse.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkItemCourse.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkItemCourse.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkItemCourse.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkItemCourse.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label9.BackColor = System.Drawing.Color.Transparent;
		this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		resources.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		resources.ApplyResources(this.pictureBox16, "pictureBox16");
		this.pictureBox16.Name = "pictureBox16";
		this.pictureBox16.TabStop = false;
		resources.ApplyResources(this.label_autogratuity_desc, "label_autogratuity_desc");
		this.label_autogratuity_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autogratuity_desc.Name = "label_autogratuity_desc";
		this.label_autogratuity_desc.Tag = "";
		resources.ApplyResources(this.chkAutoLogoutCloseOE, "chkAutoLogoutCloseOE");
		this.chkAutoLogoutCloseOE.Name = "chkAutoLogoutCloseOE";
		this.chkAutoLogoutCloseOE.Tag = "auto_logout_oe";
		this.chkAutoLogoutCloseOE.ThumbTickness = 27;
		this.chkAutoLogoutCloseOE.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoLogoutCloseOE.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCloseOE.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCloseOE.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoLogoutCloseOE.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCloseOE.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCloseOE.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCloseOE.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoLogoutCloseOE.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		this.label10.Tag = "";
		this.label_autogratuity_title.BackColor = System.Drawing.Color.Transparent;
		this.label_autogratuity_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_autogratuity_title, "label_autogratuity_title");
		this.label_autogratuity_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autogratuity_title.Name = "label_autogratuity_title";
		resources.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		resources.ApplyResources(this.chkAutoTipCashBack, "chkAutoTipCashBack");
		this.chkAutoTipCashBack.Name = "chkAutoTipCashBack";
		this.chkAutoTipCashBack.Tag = "auto_tip_cash_back";
		this.chkAutoTipCashBack.ThumbTickness = 27;
		this.chkAutoTipCashBack.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoTipCashBack.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoTipCashBack.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoTipCashBack.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoTipCashBack.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoTipCashBack.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoTipCashBack.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoTipCashBack.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoTipCashBack.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_autotip_desc, "label_autotip_desc");
		this.label_autotip_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autotip_desc.Name = "label_autotip_desc";
		this.label_autotip_desc.Tag = "";
		this.label_autotip_title.BackColor = System.Drawing.Color.Transparent;
		this.label_autotip_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_autotip_title, "label_autotip_title");
		this.label_autotip_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autotip_title.Name = "label_autotip_title";
		resources.ApplyResources(this.pictureBox21, "pictureBox21");
		this.pictureBox21.Name = "pictureBox21";
		this.pictureBox21.TabStop = false;
		resources.ApplyResources(this.chkVoidReason, "chkVoidReason");
		this.chkVoidReason.Name = "chkVoidReason";
		this.chkVoidReason.Tag = "prompt_void_orders_reason";
		this.chkVoidReason.ThumbTickness = 27;
		this.chkVoidReason.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkVoidReason.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkVoidReason.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkVoidReason.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkVoidReason.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkVoidReason.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkVoidReason.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkVoidReason.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkVoidReason.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_void_reason_desc, "label_void_reason_desc");
		this.label_void_reason_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_void_reason_desc.Name = "label_void_reason_desc";
		this.label_void_reason_desc.Tag = "";
		this.label_void_reason_title.BackColor = System.Drawing.Color.Transparent;
		this.label_void_reason_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_void_reason_title, "label_void_reason_title");
		this.label_void_reason_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_void_reason_title.Name = "label_void_reason_title";
		resources.ApplyResources(this.pictureBox23, "pictureBox23");
		this.pictureBox23.Name = "pictureBox23";
		this.pictureBox23.TabStop = false;
		resources.ApplyResources(this.chkMemberSelection, "chkMemberSelection");
		this.chkMemberSelection.Name = "chkMemberSelection";
		this.chkMemberSelection.Tag = "member_assign";
		this.chkMemberSelection.ThumbTickness = 27;
		this.chkMemberSelection.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkMemberSelection.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkMemberSelection.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkMemberSelection.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkMemberSelection.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkMemberSelection.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkMemberSelection.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkMemberSelection.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label_memberselection_desc, "label_memberselection_desc");
		this.label_memberselection_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_memberselection_desc.Name = "label_memberselection_desc";
		this.label_memberselection_desc.Tag = "";
		this.label_memberselection_title.BackColor = System.Drawing.Color.Transparent;
		this.label_memberselection_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_memberselection_title, "label_memberselection_title");
		this.label_memberselection_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_memberselection_title.Name = "label_memberselection_title";
		resources.ApplyResources(this.label16, "label16");
		this.label16.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label16.ForeColor = System.Drawing.Color.White;
		this.label16.Name = "label16";
		this.pnlAll.Controls.Add(this.ddlIntervalTime);
		this.pnlAll.Controls.Add(this.pictureBox26);
		this.pnlAll.Controls.Add(this.label31);
		this.pnlAll.Controls.Add(this.label32);
		this.pnlAll.Controls.Add(this.pictureBox22);
		this.pnlAll.Controls.Add(this.label25);
		this.pnlAll.Controls.Add(this.chkOnlineOrdNotifSound);
		this.pnlAll.Controls.Add(this.label26);
		this.pnlAll.Controls.Add(this.pictureBox24);
		this.pnlAll.Controls.Add(this.label27);
		this.pnlAll.Controls.Add(this.chkOnlineOrdNotif);
		this.pnlAll.Controls.Add(this.label28);
		this.pnlAll.Controls.Add(this.pictureBox18);
		this.pnlAll.Controls.Add(this.label19);
		this.pnlAll.Controls.Add(this.ddlPickupOrderTimeInc);
		this.pnlAll.Controls.Add(this.chkAutoClearOrders);
		this.pnlAll.Controls.Add(this.label22);
		this.pnlAll.Controls.Add(this.label20);
		this.pnlAll.Controls.Add(this.pictureBox19);
		this.pnlAll.Controls.Add(this.label21);
		this.pnlAll.Controls.Add(this.ddlThresholdHours);
		this.pnlAll.Controls.Add(this.chkThresholdFul);
		this.pnlAll.Controls.Add(this.label17);
		this.pnlAll.Controls.Add(this.pictureBox17);
		this.pnlAll.Controls.Add(this.label18);
		this.pnlAll.Controls.Add(this.label14);
		this.pnlAll.Controls.Add(this.label15);
		this.pnlAll.Controls.Add(this.chkOpenCloseStore);
		this.pnlAll.Controls.Add(this.pictureBox12);
		this.pnlAll.Controls.Add(this.lblConfigSafeDrop);
		this.pnlAll.Controls.Add(this.label11);
		this.pnlAll.Controls.Add(this.chkSafeDrop);
		this.pnlAll.Controls.Add(this.label13);
		this.pnlAll.Controls.Add(this.pictureBox10);
		this.pnlAll.Controls.Add(this.chkShowIfChange);
		this.pnlAll.Controls.Add(this.label12);
		this.pnlAll.Controls.Add(this.pictureBox4);
		this.pnlAll.Controls.Add(this.chkTipTracking);
		this.pnlAll.Controls.Add(this.pictureBox2);
		this.pnlAll.Controls.Add(this.label6);
		this.pnlAll.Controls.Add(this.label_tiptracking_desc);
		this.pnlAll.Controls.Add(this.chkPromptCashoutPIN);
		this.pnlAll.Controls.Add(this.pictureBox15);
		this.pnlAll.Controls.Add(this.label_tiptracking_title);
		this.pnlAll.Controls.Add(this.chkConfirmOnlineOrder);
		this.pnlAll.Controls.Add(this.label5);
		this.pnlAll.Controls.Add(this.label1);
		this.pnlAll.Controls.Add(this.label2);
		this.pnlAll.Controls.Add(this.pictureBox21);
		this.pnlAll.Controls.Add(this.label_showfinal_title);
		this.pnlAll.Controls.Add(this.pictureBox1);
		this.pnlAll.Controls.Add(this.pictureBox23);
		this.pnlAll.Controls.Add(this.chkShowCashout);
		this.pnlAll.Controls.Add(this.chkMemberSelection);
		this.pnlAll.Controls.Add(this.label_showfinal_desc);
		this.pnlAll.Controls.Add(this.label_memberselection_desc);
		this.pnlAll.Controls.Add(this.pictureBox8);
		this.pnlAll.Controls.Add(this.chkAutoTipCashBack);
		this.pnlAll.Controls.Add(this.label_memberselection_title);
		this.pnlAll.Controls.Add(this.label_upc_title);
		this.pnlAll.Controls.Add(this.label_upc_desc);
		this.pnlAll.Controls.Add(this.chkVoidReason);
		this.pnlAll.Controls.Add(this.chkUpcScanning);
		this.pnlAll.Controls.Add(this.label_void_reason_desc);
		this.pnlAll.Controls.Add(this.pictureBox11);
		this.pnlAll.Controls.Add(this.label_void_reason_title);
		this.pnlAll.Controls.Add(this.label_autotip_title);
		this.pnlAll.Controls.Add(this.label_autotip_desc);
		resources.ApplyResources(this.pnlAll, "pnlAll");
		this.pnlAll.Name = "pnlAll";
		this.ddlIntervalTime.BackColor = System.Drawing.Color.White;
		this.ddlIntervalTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlIntervalTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlIntervalTime, "ddlIntervalTime");
		this.ddlIntervalTime.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlIntervalTime.FormattingEnabled = true;
		this.ddlIntervalTime.Items.AddRange(new object[4]
		{
			resources.GetString("ddlIntervalTime.Items"),
			resources.GetString("ddlIntervalTime.Items1"),
			resources.GetString("ddlIntervalTime.Items2"),
			resources.GetString("ddlIntervalTime.Items3")
		});
		this.ddlIntervalTime.Name = "ddlIntervalTime";
		this.ddlIntervalTime.Tag = "online_order_notification_audio_time";
		this.ddlIntervalTime.SelectedIndexChanged += new System.EventHandler(ddlIntervalTime_SelectedIndexChanged);
		resources.ApplyResources(this.pictureBox26, "pictureBox26");
		this.pictureBox26.Name = "pictureBox26";
		this.pictureBox26.TabStop = false;
		this.label31.BackColor = System.Drawing.Color.Transparent;
		this.label31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label31, "label31");
		this.label31.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label31.Name = "label31";
		resources.ApplyResources(this.label32, "label32");
		this.label32.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label32.Name = "label32";
		this.label32.Tag = "";
		resources.ApplyResources(this.pictureBox22, "pictureBox22");
		this.pictureBox22.Name = "pictureBox22";
		this.pictureBox22.TabStop = false;
		this.label25.BackColor = System.Drawing.Color.Transparent;
		this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label25, "label25");
		this.label25.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label25.Name = "label25";
		resources.ApplyResources(this.chkOnlineOrdNotifSound, "chkOnlineOrdNotifSound");
		this.chkOnlineOrdNotifSound.Name = "chkOnlineOrdNotifSound";
		this.chkOnlineOrdNotifSound.Tag = "online_order_notification_all_audio";
		this.chkOnlineOrdNotifSound.ThumbTickness = 27;
		this.chkOnlineOrdNotifSound.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkOnlineOrdNotifSound.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotifSound.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotifSound.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotifSound.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotifSound.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotifSound.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotifSound.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotifSound.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label26, "label26");
		this.label26.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label26.Name = "label26";
		this.label26.Tag = "";
		resources.ApplyResources(this.pictureBox24, "pictureBox24");
		this.pictureBox24.Name = "pictureBox24";
		this.pictureBox24.TabStop = false;
		this.label27.BackColor = System.Drawing.Color.Transparent;
		this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label27, "label27");
		this.label27.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label27.Name = "label27";
		resources.ApplyResources(this.chkOnlineOrdNotif, "chkOnlineOrdNotif");
		this.chkOnlineOrdNotif.Name = "chkOnlineOrdNotif";
		this.chkOnlineOrdNotif.Tag = "online_order_notification_all";
		this.chkOnlineOrdNotif.ThumbTickness = 27;
		this.chkOnlineOrdNotif.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkOnlineOrdNotif.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotif.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotif.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOnlineOrdNotif.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotif.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotif.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotif.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOnlineOrdNotif.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label28, "label28");
		this.label28.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label28.Name = "label28";
		this.label28.Tag = "";
		resources.ApplyResources(this.pictureBox18, "pictureBox18");
		this.pictureBox18.Name = "pictureBox18";
		this.pictureBox18.TabStop = false;
		this.label19.BackColor = System.Drawing.Color.Transparent;
		this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label19, "label19");
		this.label19.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label19.Name = "label19";
		this.ddlPickupOrderTimeInc.BackColor = System.Drawing.Color.White;
		this.ddlPickupOrderTimeInc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlPickupOrderTimeInc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlPickupOrderTimeInc, "ddlPickupOrderTimeInc");
		this.ddlPickupOrderTimeInc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlPickupOrderTimeInc.FormattingEnabled = true;
		this.ddlPickupOrderTimeInc.Items.AddRange(new object[6]
		{
			resources.GetString("ddlPickupOrderTimeInc.Items"),
			resources.GetString("ddlPickupOrderTimeInc.Items1"),
			resources.GetString("ddlPickupOrderTimeInc.Items2"),
			resources.GetString("ddlPickupOrderTimeInc.Items3"),
			resources.GetString("ddlPickupOrderTimeInc.Items4"),
			resources.GetString("ddlPickupOrderTimeInc.Items5")
		});
		this.ddlPickupOrderTimeInc.Name = "ddlPickupOrderTimeInc";
		this.ddlPickupOrderTimeInc.Tag = "pickup_order_time_increment";
		this.ddlPickupOrderTimeInc.SelectedIndexChanged += new System.EventHandler(ddlPickupOrderTimeInc_SelectedIndexChanged);
		resources.ApplyResources(this.chkAutoClearOrders, "chkAutoClearOrders");
		this.chkAutoClearOrders.Name = "chkAutoClearOrders";
		this.chkAutoClearOrders.Tag = "auto_clear_orders";
		this.chkAutoClearOrders.ThumbTickness = 27;
		this.chkAutoClearOrders.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoClearOrders.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearOrders.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearOrders.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoClearOrders.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearOrders.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearOrders.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearOrders.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoClearOrders.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label22, "label22");
		this.label22.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label22.Name = "label22";
		this.label22.Tag = "";
		resources.ApplyResources(this.label20, "label20");
		this.label20.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label20.Name = "label20";
		this.label20.Tag = "";
		resources.ApplyResources(this.pictureBox19, "pictureBox19");
		this.pictureBox19.Name = "pictureBox19";
		this.pictureBox19.TabStop = false;
		this.label21.BackColor = System.Drawing.Color.Transparent;
		this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label21, "label21");
		this.label21.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label21.Name = "label21";
		this.ddlThresholdHours.BackColor = System.Drawing.Color.White;
		this.ddlThresholdHours.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlThresholdHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlThresholdHours, "ddlThresholdHours");
		this.ddlThresholdHours.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlThresholdHours.FormattingEnabled = true;
		this.ddlThresholdHours.Items.AddRange(new object[9]
		{
			resources.GetString("ddlThresholdHours.Items"),
			resources.GetString("ddlThresholdHours.Items1"),
			resources.GetString("ddlThresholdHours.Items2"),
			resources.GetString("ddlThresholdHours.Items3"),
			resources.GetString("ddlThresholdHours.Items4"),
			resources.GetString("ddlThresholdHours.Items5"),
			resources.GetString("ddlThresholdHours.Items6"),
			resources.GetString("ddlThresholdHours.Items7"),
			resources.GetString("ddlThresholdHours.Items8")
		});
		this.ddlThresholdHours.Name = "ddlThresholdHours";
		this.ddlThresholdHours.Tag = "fulfillment_threshold_time";
		this.ddlThresholdHours.SelectedIndexChanged += new System.EventHandler(ddlThresholdHours_SelectedIndexChanged);
		resources.ApplyResources(this.chkThresholdFul, "chkThresholdFul");
		this.chkThresholdFul.Name = "chkThresholdFul";
		this.chkThresholdFul.Tag = "fulfillment_threshold";
		this.chkThresholdFul.ThumbTickness = 27;
		this.chkThresholdFul.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkThresholdFul.Value = false;
		this.chkThresholdFul.ValueChanged += new System.EventHandler(chkThresholdFul_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkThresholdFul.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkThresholdFul.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkThresholdFul.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkThresholdFul.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkThresholdFul.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkThresholdFul.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkThresholdFul.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label17, "label17");
		this.label17.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label17.Name = "label17";
		this.label17.Tag = "";
		resources.ApplyResources(this.pictureBox17, "pictureBox17");
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.TabStop = false;
		this.label18.BackColor = System.Drawing.Color.Transparent;
		this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label18, "label18");
		this.label18.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label18.Name = "label18";
		this.label14.BackColor = System.Drawing.Color.Transparent;
		this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		resources.ApplyResources(this.label15, "label15");
		this.label15.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label15.Name = "label15";
		this.label15.Tag = "";
		resources.ApplyResources(this.chkOpenCloseStore, "chkOpenCloseStore");
		this.chkOpenCloseStore.Name = "chkOpenCloseStore";
		this.chkOpenCloseStore.Tag = "openclose_store";
		this.chkOpenCloseStore.ThumbTickness = 27;
		this.chkOpenCloseStore.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkOpenCloseStore.Value = false;
		this.chkOpenCloseStore.ValueChanged += new System.EventHandler(chkOpenCloseStore_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOpenCloseStore.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOpenCloseStore.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOpenCloseStore.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOpenCloseStore.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOpenCloseStore.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOpenCloseStore.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOpenCloseStore.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.pictureBox12, "pictureBox12");
		this.pictureBox12.Name = "pictureBox12";
		this.pictureBox12.TabStop = false;
		resources.ApplyResources(this.lblConfigSafeDrop, "lblConfigSafeDrop");
		this.lblConfigSafeDrop.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblConfigSafeDrop.Name = "lblConfigSafeDrop";
		this.lblConfigSafeDrop.Click += new System.EventHandler(lblConfigSafeDrop_Click);
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label11.Name = "label11";
		resources.ApplyResources(this.chkSafeDrop, "chkSafeDrop");
		this.chkSafeDrop.Name = "chkSafeDrop";
		this.chkSafeDrop.Tag = "safe_drop_setting";
		this.chkSafeDrop.ThumbTickness = 27;
		this.chkSafeDrop.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkSafeDrop.Value = false;
		this.chkSafeDrop.ValueChanged += new System.EventHandler(chkSafeDrop_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkSafeDrop.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkSafeDrop.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkSafeDrop.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkSafeDrop.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkSafeDrop.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkSafeDrop.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkSafeDrop.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		this.label13.Tag = "";
		resources.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		resources.ApplyResources(this.chkShowIfChange, "chkShowIfChange");
		this.chkShowIfChange.Name = "chkShowIfChange";
		this.chkShowIfChange.Tag = "payfinish_screen_ifchange";
		this.chkShowIfChange.ThumbTickness = 27;
		this.chkShowIfChange.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkShowIfChange.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowIfChange.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowIfChange.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkShowIfChange.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowIfChange.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowIfChange.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowIfChange.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkShowIfChange.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		this.label12.Tag = "";
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.chkTipTracking, "chkTipTracking");
		this.chkTipTracking.Name = "chkTipTracking";
		this.chkTipTracking.Tag = "tip_tracking";
		this.chkTipTracking.ThumbTickness = 27;
		this.chkTipTracking.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkTipTracking.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTipTracking.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTipTracking.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkTipTracking.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTipTracking.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTipTracking.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTipTracking.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkTipTracking.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		resources.ApplyResources(this.label6, "label6");
		this.label6.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label6.Name = "label6";
		this.label6.Tag = "";
		resources.ApplyResources(this.label_tiptracking_desc, "label_tiptracking_desc");
		this.label_tiptracking_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tiptracking_desc.Name = "label_tiptracking_desc";
		this.label_tiptracking_desc.Tag = "";
		resources.ApplyResources(this.chkPromptCashoutPIN, "chkPromptCashoutPIN");
		this.chkPromptCashoutPIN.Name = "chkPromptCashoutPIN";
		this.chkPromptCashoutPIN.Tag = "workflow_prompt_cashout_pin";
		this.chkPromptCashoutPIN.ThumbTickness = 27;
		this.chkPromptCashoutPIN.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkPromptCashoutPIN.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPromptCashoutPIN.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPromptCashoutPIN.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPromptCashoutPIN.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPromptCashoutPIN.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPromptCashoutPIN.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPromptCashoutPIN.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPromptCashoutPIN.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.pictureBox15, "pictureBox15");
		this.pictureBox15.Name = "pictureBox15";
		this.pictureBox15.TabStop = false;
		this.label_tiptracking_title.BackColor = System.Drawing.Color.Transparent;
		this.label_tiptracking_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_tiptracking_title, "label_tiptracking_title");
		this.label_tiptracking_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tiptracking_title.Name = "label_tiptracking_title";
		resources.ApplyResources(this.chkConfirmOnlineOrder, "chkConfirmOnlineOrder");
		this.chkConfirmOnlineOrder.Name = "chkConfirmOnlineOrder";
		this.chkConfirmOnlineOrder.Tag = "confirm_online_orders";
		this.chkConfirmOnlineOrder.ThumbTickness = 27;
		this.chkConfirmOnlineOrder.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkConfirmOnlineOrder.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkConfirmOnlineOrder.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkConfirmOnlineOrder.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkConfirmOnlineOrder.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkConfirmOnlineOrder.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkConfirmOnlineOrder.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkConfirmOnlineOrder.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkConfirmOnlineOrder.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		resources.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.pnlAll);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.pnlFullService);
		base.Controls.Add(this.pnlQuickServiceScreen);
		base.Name = "WorkFlowSettings";
		resources.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowQuickServiceScreen).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowCashout).EndInit();
		this.pnlQuickServiceScreen.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkChitCashout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkLockTableStaff).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkUpcScanning).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLockLayout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).EndInit();
		this.pnlFullService.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox25).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowEmployeeTable).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLogoutCashout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoClearTable).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoGratuity).EndInit();
		this.pnlAutoGratuity.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtAutoGratuityPercentage).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAutoGratuityCount).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemCourse).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoLogoutCloseOE).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoTipCashBack).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkVoidReason).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkMemberSelection).EndInit();
		this.pnlAll.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox22).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkOnlineOrdNotifSound).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkOnlineOrdNotif).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoClearOrders).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkThresholdFul).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkOpenCloseStore).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkSafeDrop).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowIfChange).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkTipTracking).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPromptCashoutPIN).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkConfirmOnlineOrder).EndInit();
		base.ResumeLayout(false);
	}
}
