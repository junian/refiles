using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
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
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		if (iqueryable_0.Where((Setting a) => a.Key == "restaurant_mode").FirstOrDefault().Value == "Dine In")
		{
			chkAutoLockLayout.set_Value((iqueryable_0.Where((Setting x) => x.Key == "auto_lock_layout").FirstOrDefault().Value == "ON") ? true : false);
			chkAutoClearTable.set_Value((iqueryable_0.Where((Setting x) => x.Key == "auto_clear_table").FirstOrDefault().Value == "ON") ? true : false);
			chkTipTracking.set_Value((iqueryable_0.Where((Setting x) => x.Key == "tip_tracking").FirstOrDefault().Value == "ON") ? true : false);
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
					((Control)(object)txtAutoGratuityCount).Text = setting2.Value;
					Setting setting3 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
					((Control)(object)txtAutoGratuityPercentage).Text = setting3.Value;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains(((Control)(object)chkThresholdFul).Name))
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
				if (CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkShowCashout).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkUpcScanning).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkAutoClearTable).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkAutoGratuity).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkSafeDrop).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkOpenCloseStore).Name && CS_0024_003C_003E8__locals0.ctrl.Name != ((Control)(object)chkThresholdFul).Name)
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement().add_ValueChanged((EventHandler)method_0);
					((RadElement)((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement()).set_Tag(((Control)(RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag);
				}
				if (setting.Value.Contains("ON"))
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(true);
				}
				else
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(false);
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
		CS_0024_003C_003E8__locals0.chkToggle = (RadToggleSwitchElement)((sender is RadToggleSwitchElement) ? sender : null);
		Console.Write(((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag());
		Setting setting = iqueryable_0.Where((Setting s) => ((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().Equals(s.Key)).FirstOrDefault();
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
			SettingsHelper.SetSettingValueByKey(((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().ToString(), setting.Value);
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
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkShowCashout).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkShowCashout.get_Value())
			{
				setting.Value = "ON";
				RadToggleSwitch obj = chkShowIfChange;
				chkShowIfChange.set_Value(true);
				((Control)(object)obj).Enabled = true;
			}
			else
			{
				setting.Value = "OFF";
				RadToggleSwitch obj2 = chkShowIfChange;
				chkShowIfChange.set_Value(false);
				((Control)(object)obj2).Enabled = false;
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkShowCashout).Tag.ToString(), setting.Value);
		}
	}

	private void chkUpcScanning_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkUpcScanning).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkUpcScanning.get_Value())
			{
				setting.Value = "ON";
			}
			else
			{
				setting.Value = "OFF";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkUpcScanning).Tag.ToString(), setting.Value);
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
		if (chkAutoClearTable.get_Value() && new frmMessageBox("All tables that currently waiting for a tip (green tables) will be cleared. Are you sure you want to continue?", "WARNING", CustomMessageBoxButtons.YesNo).ShowDialog() != DialogResult.Yes)
		{
			chkAutoClearTable.remove_ValueChanged((EventHandler)chkAutoClearTable_ValueChanged);
			chkAutoClearTable.set_Value(false);
			chkAutoClearTable.add_ValueChanged((EventHandler)chkAutoClearTable_ValueChanged);
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkAutoClearTable).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkAutoClearTable.get_Value())
			{
				setting.Value = "ON";
			}
			else
			{
				setting.Value = "OFF";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkAutoClearTable).Tag.ToString(), setting.Value);
		}
	}

	private void chkAutoGratuity_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkAutoGratuity).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (!chkAutoGratuity.get_Value())
		{
			setting.Value = "OFF";
			pnlAutoGratuity.Visible = false;
		}
		else
		{
			setting.Value = "ON";
			pnlAutoGratuity.Visible = true;
			Setting setting2 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_count").FirstOrDefault();
			((Control)(object)txtAutoGratuityCount).Text = setting2.Value;
			Setting setting3 = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
			((Control)(object)txtAutoGratuityPercentage).Text = setting3.Value;
		}
		setting.Synced = false;
		Helper.SubmitChangesWithCatch(gclass6_0);
		SettingsHelper.SetSettingValueByKey(((Control)(object)chkAutoGratuity).Tag.ToString(), setting.Value);
	}

	private void txtAutoGratuityCount_TextChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		decimal result = default(decimal);
		if (!decimal.TryParse(((Control)(object)txtAutoGratuityCount).Text, out result))
		{
			new frmMessageBox("You can only enter numerical values on this field.").ShowDialog(this);
			((Control)(object)txtAutoGratuityCount).Text = "0";
			return;
		}
		if (((Control)(object)txtAutoGratuityCount).Text.Contains("-"))
		{
			new frmMessageBox("Auto Gratuity guest count cannot be a negative value, please enter a new value.").ShowDialog(this);
			((Control)(object)txtAutoGratuityCount).Text = "";
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_count").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = ((Control)(object)txtAutoGratuityCount).Text;
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
		if (!decimal.TryParse(((Control)(object)txtAutoGratuityPercentage).Text, out result))
		{
			new frmMessageBox("You can only enter numerical values on this field.").ShowDialog(this);
			((Control)(object)txtAutoGratuityPercentage).Text = "0";
			return;
		}
		if (((Control)(object)txtAutoGratuityPercentage).Text.Contains("-"))
		{
			new frmMessageBox("Auto Gratuity percentage cannot be a negative value, please enter a new value.").ShowDialog(this);
			((Control)(object)txtAutoGratuityPercentage).Text = "";
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "auto_gratuity_percentage").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = ((Control)(object)txtAutoGratuityPercentage).Text;
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey("auto_gratuity_percentage", setting.Value);
		}
	}

	private void txtAutoGratuityCount_Click(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(((Control)(object)val).Tag.ToString(), 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void chkSafeDrop_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkSafeDrop).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (chkSafeDrop.get_Value())
		{
			setting.Value = "ON";
			if (!chkOpenCloseStore.get_Value())
			{
				chkOpenCloseStore.set_Value(true);
				new NotificationLabel(base.ParentForm, "'Opening && Closing Store' feature is automatically enabled.", NotificationTypes.Notification).Show();
			}
		}
		else
		{
			setting.Value = "OFF";
		}
		setting.Synced = false;
		gclass6_0.SubmitChanges();
		SettingsHelper.SetSettingValueByKey(((Control)(object)chkSafeDrop).Tag.ToString(), setting.Value);
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
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkOpenCloseStore).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		if (chkOpenCloseStore.get_Value())
		{
			setting.Value = "ON";
		}
		else
		{
			setting.Value = "OFF";
			if (chkSafeDrop.get_Value())
			{
				chkSafeDrop.set_Value(false);
				new NotificationLabel(base.ParentForm, "'Safe Drop' is automatically disabled.", NotificationTypes.Notification).Show();
			}
		}
		setting.Synced = false;
		gclass6_0.SubmitChanges();
		SettingsHelper.SetSettingValueByKey(((Control)(object)chkOpenCloseStore).Tag.ToString(), setting.Value);
	}

	private void chkThresholdFul_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkThresholdFul).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkThresholdFul.get_Value())
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
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkThresholdFul).Tag.ToString(), setting.Value);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_087f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1029: Unknown result type (might be due to invalid IL or missing references)
		//IL_1056: Unknown result type (might be due to invalid IL or missing references)
		//IL_1083: Unknown result type (might be due to invalid IL or missing references)
		//IL_118b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_11db: Unknown result type (might be due to invalid IL or missing references)
		//IL_1208: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_1262: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_141c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Unknown result type (might be due to invalid IL or missing references)
		//IL_1476: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_190b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Unknown result type (might be due to invalid IL or missing references)
		//IL_193a: Unknown result type (might be due to invalid IL or missing references)
		//IL_195b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1988: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b23: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2028: Unknown result type (might be due to invalid IL or missing references)
		//IL_2055: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_228a: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2404: Unknown result type (might be due to invalid IL or missing references)
		//IL_2431: Unknown result type (might be due to invalid IL or missing references)
		//IL_245e: Unknown result type (might be due to invalid IL or missing references)
		//IL_248b: Unknown result type (might be due to invalid IL or missing references)
		//IL_25fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2614: Unknown result type (might be due to invalid IL or missing references)
		//IL_262b: Unknown result type (might be due to invalid IL or missing references)
		//IL_264c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2679: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2817: Unknown result type (might be due to invalid IL or missing references)
		//IL_282f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2846: Unknown result type (might be due to invalid IL or missing references)
		//IL_2867: Unknown result type (might be due to invalid IL or missing references)
		//IL_2894: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_369c: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_36cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_3719: Unknown result type (might be due to invalid IL or missing references)
		//IL_3746: Unknown result type (might be due to invalid IL or missing references)
		//IL_3773: Unknown result type (might be due to invalid IL or missing references)
		//IL_38b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3907: Unknown result type (might be due to invalid IL or missing references)
		//IL_3934: Unknown result type (might be due to invalid IL or missing references)
		//IL_3961: Unknown result type (might be due to invalid IL or missing references)
		//IL_398e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_3be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4018: Unknown result type (might be due to invalid IL or missing references)
		//IL_4045: Unknown result type (might be due to invalid IL or missing references)
		//IL_423a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4252: Unknown result type (might be due to invalid IL or missing references)
		//IL_4269: Unknown result type (might be due to invalid IL or missing references)
		//IL_428a: Unknown result type (might be due to invalid IL or missing references)
		//IL_42b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_42e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4311: Unknown result type (might be due to invalid IL or missing references)
		//IL_446d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4485: Unknown result type (might be due to invalid IL or missing references)
		//IL_449c: Unknown result type (might be due to invalid IL or missing references)
		//IL_44bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_4517: Unknown result type (might be due to invalid IL or missing references)
		//IL_4544: Unknown result type (might be due to invalid IL or missing references)
		//IL_4635: Unknown result type (might be due to invalid IL or missing references)
		//IL_464d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4664: Unknown result type (might be due to invalid IL or missing references)
		//IL_4685: Unknown result type (might be due to invalid IL or missing references)
		//IL_46b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_46df: Unknown result type (might be due to invalid IL or missing references)
		//IL_470c: Unknown result type (might be due to invalid IL or missing references)
		//IL_47fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4815: Unknown result type (might be due to invalid IL or missing references)
		//IL_482c: Unknown result type (might be due to invalid IL or missing references)
		//IL_484d: Unknown result type (might be due to invalid IL or missing references)
		//IL_487a: Unknown result type (might be due to invalid IL or missing references)
		//IL_48a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_48d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cb7: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.WorkFlowSettings));
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label_showQS_desc = new System.Windows.Forms.Label();
		this.chkShowQuickServiceScreen = new RadToggleSwitch();
		this.label_showQS_title = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label_showfinal_desc = new System.Windows.Forms.Label();
		this.chkShowCashout = new RadToggleSwitch();
		this.label_showfinal_title = new System.Windows.Forms.Label();
		this.pnlQuickServiceScreen = new System.Windows.Forms.Panel();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.chkChitCashout = new RadToggleSwitch();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.label_lockstaff_title = new System.Windows.Forms.Label();
		this.chkLockTableStaff = new RadToggleSwitch();
		this.label_lockstaff_desc = new System.Windows.Forms.Label();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.chkUpcScanning = new RadToggleSwitch();
		this.label_upc_desc = new System.Windows.Forms.Label();
		this.label_upc_title = new System.Windows.Forms.Label();
		this.label_autolocklayout_title = new System.Windows.Forms.Label();
		this.chkAutoLockLayout = new RadToggleSwitch();
		this.label_autolocklayout_desc = new System.Windows.Forms.Label();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.pnlFullService = new System.Windows.Forms.Panel();
		this.pictureBox25 = new System.Windows.Forms.PictureBox();
		this.label29 = new System.Windows.Forms.Label();
		this.chkShowEmployeeTable = new RadToggleSwitch();
		this.label30 = new System.Windows.Forms.Label();
		this.chkAutoLogoutCashout = new RadToggleSwitch();
		this.pictureBox20 = new System.Windows.Forms.PictureBox();
		this.label23 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.pictureBox14 = new System.Windows.Forms.PictureBox();
		this.label_autocleartable_title = new System.Windows.Forms.Label();
		this.chkAutoClearTable = new RadToggleSwitch();
		this.label8 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label_autocleartable_desc = new System.Windows.Forms.Label();
		this.chkAutoGratuity = new RadToggleSwitch();
		this.label7 = new System.Windows.Forms.Label();
		this.pnlAutoGratuity = new System.Windows.Forms.Panel();
		this.txtAutoGratuityPercentage = new RadTextBoxControl();
		this.txtAutoGratuityCount = new RadTextBoxControl();
		this.lblTipPercentage = new System.Windows.Forms.Label();
		this.lblGuest = new System.Windows.Forms.Label();
		this.chkItemCourse = new RadToggleSwitch();
		this.label9 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.pictureBox16 = new System.Windows.Forms.PictureBox();
		this.label_autogratuity_desc = new System.Windows.Forms.Label();
		this.chkAutoLogoutCloseOE = new RadToggleSwitch();
		this.label10 = new System.Windows.Forms.Label();
		this.label_autogratuity_title = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.chkAutoTipCashBack = new RadToggleSwitch();
		this.label_autotip_desc = new System.Windows.Forms.Label();
		this.label_autotip_title = new System.Windows.Forms.Label();
		this.pictureBox21 = new System.Windows.Forms.PictureBox();
		this.chkVoidReason = new RadToggleSwitch();
		this.label_void_reason_desc = new System.Windows.Forms.Label();
		this.label_void_reason_title = new System.Windows.Forms.Label();
		this.pictureBox23 = new System.Windows.Forms.PictureBox();
		this.chkMemberSelection = new RadToggleSwitch();
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
		this.chkOnlineOrdNotifSound = new RadToggleSwitch();
		this.label26 = new System.Windows.Forms.Label();
		this.pictureBox24 = new System.Windows.Forms.PictureBox();
		this.label27 = new System.Windows.Forms.Label();
		this.chkOnlineOrdNotif = new RadToggleSwitch();
		this.label28 = new System.Windows.Forms.Label();
		this.pictureBox18 = new System.Windows.Forms.PictureBox();
		this.label19 = new System.Windows.Forms.Label();
		this.ddlPickupOrderTimeInc = new Class19();
		this.chkAutoClearOrders = new RadToggleSwitch();
		this.label22 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.pictureBox19 = new System.Windows.Forms.PictureBox();
		this.label21 = new System.Windows.Forms.Label();
		this.ddlThresholdHours = new Class19();
		this.chkThresholdFul = new RadToggleSwitch();
		this.label17 = new System.Windows.Forms.Label();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.label18 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.chkOpenCloseStore = new RadToggleSwitch();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.lblConfigSafeDrop = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.chkSafeDrop = new RadToggleSwitch();
		this.label13 = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.chkShowIfChange = new RadToggleSwitch();
		this.label12 = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.chkTipTracking = new RadToggleSwitch();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label_tiptracking_desc = new System.Windows.Forms.Label();
		this.chkPromptCashoutPIN = new RadToggleSwitch();
		this.pictureBox15 = new System.Windows.Forms.PictureBox();
		this.label_tiptracking_title = new System.Windows.Forms.Label();
		this.chkConfirmOnlineOrder = new RadToggleSwitch();
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
		((System.Windows.Forms.Control)(object)this.chkShowQuickServiceScreen).Name = "chkShowQuickServiceScreen";
		((System.Windows.Forms.Control)(object)this.chkShowQuickServiceScreen).Tag = "quickservice_screen";
		this.chkShowQuickServiceScreen.set_ThumbTickness(27);
		this.chkShowQuickServiceScreen.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowQuickServiceScreen.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowQuickServiceScreen).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkShowCashout).Name = "chkShowCashout";
		((System.Windows.Forms.Control)(object)this.chkShowCashout).Tag = "payfinish_screen";
		this.chkShowCashout.set_ThumbTickness(27);
		this.chkShowCashout.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowCashout.set_Value(false);
		this.chkShowCashout.add_ValueChanged(new System.EventHandler(chkShowCashout_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkShowCashout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowCashout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowCashout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowCashout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowCashout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowCashout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowCashout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_showfinal_title.BackColor = System.Drawing.Color.Transparent;
		this.label_showfinal_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_showfinal_title, "label_showfinal_title");
		this.label_showfinal_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showfinal_title.Name = "label_showfinal_title";
		this.pnlQuickServiceScreen.Controls.Add(this.pictureBox3);
		this.pnlQuickServiceScreen.Controls.Add((System.Windows.Forms.Control)(object)this.chkChitCashout);
		this.pnlQuickServiceScreen.Controls.Add(this.label3);
		this.pnlQuickServiceScreen.Controls.Add(this.label4);
		this.pnlQuickServiceScreen.Controls.Add(this.label_showQS_title);
		this.pnlQuickServiceScreen.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowQuickServiceScreen);
		this.pnlQuickServiceScreen.Controls.Add(this.label_showQS_desc);
		this.pnlQuickServiceScreen.Controls.Add(this.pictureBox6);
		resources.ApplyResources(this.pnlQuickServiceScreen, "pnlQuickServiceScreen");
		this.pnlQuickServiceScreen.Name = "pnlQuickServiceScreen";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		resources.ApplyResources(this.chkChitCashout, "chkChitCashout");
		((System.Windows.Forms.Control)(object)this.chkChitCashout).Name = "chkChitCashout";
		((System.Windows.Forms.Control)(object)this.chkChitCashout).Tag = "print_chit_cashout";
		this.chkChitCashout.set_ThumbTickness(27);
		this.chkChitCashout.set_ToggleStateMode((ToggleStateMode)1);
		this.chkChitCashout.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkChitCashout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkChitCashout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkChitCashout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkChitCashout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkChitCashout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkChitCashout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkChitCashout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkLockTableStaff).Name = "chkLockTableStaff";
		((System.Windows.Forms.Control)(object)this.chkLockTableStaff).Tag = "lock_table_staff";
		this.chkLockTableStaff.set_ThumbTickness(27);
		this.chkLockTableStaff.set_ToggleStateMode((ToggleStateMode)1);
		this.chkLockTableStaff.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkLockTableStaff).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkLockTableStaff).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkLockTableStaff).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLockTableStaff).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLockTableStaff).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLockTableStaff).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkLockTableStaff).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label_lockstaff_desc, "label_lockstaff_desc");
		this.label_lockstaff_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_lockstaff_desc.Name = "label_lockstaff_desc";
		this.label_lockstaff_desc.Tag = "";
		resources.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		resources.ApplyResources(this.chkUpcScanning, "chkUpcScanning");
		((System.Windows.Forms.Control)(object)this.chkUpcScanning).Name = "chkUpcScanning";
		((System.Windows.Forms.Control)(object)this.chkUpcScanning).Tag = "upc_scanning";
		this.chkUpcScanning.set_ThumbTickness(27);
		this.chkUpcScanning.set_ToggleStateMode((ToggleStateMode)1);
		this.chkUpcScanning.set_Value(false);
		this.chkUpcScanning.add_ValueChanged(new System.EventHandler(chkUpcScanning_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkUpcScanning).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkUpcScanning).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkUpcScanning).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkUpcScanning).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkUpcScanning).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkUpcScanning).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkUpcScanning).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoLockLayout).Name = "chkAutoLockLayout";
		((System.Windows.Forms.Control)(object)this.chkAutoLockLayout).Tag = "auto_lock_layout";
		this.chkAutoLockLayout.set_ThumbTickness(27);
		this.chkAutoLockLayout.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoLockLayout.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoLockLayout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label_autolocklayout_desc, "label_autolocklayout_desc");
		this.label_autolocklayout_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_autolocklayout_desc.Name = "label_autolocklayout_desc";
		this.label_autolocklayout_desc.Tag = "";
		resources.ApplyResources(this.pictureBox13, "pictureBox13");
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.TabStop = false;
		this.pnlFullService.Controls.Add(this.pictureBox25);
		this.pnlFullService.Controls.Add(this.label29);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowEmployeeTable);
		this.pnlFullService.Controls.Add(this.label30);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoLogoutCashout);
		this.pnlFullService.Controls.Add(this.pictureBox20);
		this.pnlFullService.Controls.Add(this.label23);
		this.pnlFullService.Controls.Add(this.label24);
		this.pnlFullService.Controls.Add(this.pictureBox14);
		this.pnlFullService.Controls.Add(this.pictureBox13);
		this.pnlFullService.Controls.Add(this.label_autocleartable_title);
		this.pnlFullService.Controls.Add(this.label_autolocklayout_title);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoClearTable);
		this.pnlFullService.Controls.Add(this.label8);
		this.pnlFullService.Controls.Add(this.pictureBox7);
		this.pnlFullService.Controls.Add(this.label_autocleartable_desc);
		this.pnlFullService.Controls.Add(this.label_lockstaff_desc);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoGratuity);
		this.pnlFullService.Controls.Add(this.label7);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkLockTableStaff);
		this.pnlFullService.Controls.Add(this.pnlAutoGratuity);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkItemCourse);
		this.pnlFullService.Controls.Add(this.label9);
		this.pnlFullService.Controls.Add(this.pictureBox5);
		this.pnlFullService.Controls.Add(this.pictureBox16);
		this.pnlFullService.Controls.Add(this.label_lockstaff_title);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoLockLayout);
		this.pnlFullService.Controls.Add(this.label_autolocklayout_desc);
		this.pnlFullService.Controls.Add(this.label_autogratuity_desc);
		this.pnlFullService.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoLogoutCloseOE);
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
		((System.Windows.Forms.Control)(object)this.chkShowEmployeeTable).Name = "chkShowEmployeeTable";
		((System.Windows.Forms.Control)(object)this.chkShowEmployeeTable).Tag = "show_employee_table";
		this.chkShowEmployeeTable.set_ThumbTickness(27);
		this.chkShowEmployeeTable.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowEmployeeTable.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowEmployeeTable).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label30, "label30");
		this.label30.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label30.Name = "label30";
		this.label30.Tag = "";
		resources.ApplyResources(this.chkAutoLogoutCashout, "chkAutoLogoutCashout");
		((System.Windows.Forms.Control)(object)this.chkAutoLogoutCashout).Name = "chkAutoLogoutCashout";
		((System.Windows.Forms.Control)(object)this.chkAutoLogoutCashout).Tag = "auto_logout_cashout";
		this.chkAutoLogoutCashout.set_ThumbTickness(27);
		this.chkAutoLogoutCashout.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoLogoutCashout.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCashout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoClearTable).Name = "chkAutoClearTable";
		((System.Windows.Forms.Control)(object)this.chkAutoClearTable).Tag = "auto_clear_table";
		this.chkAutoClearTable.set_ThumbTickness(27);
		this.chkAutoClearTable.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoClearTable.set_Value(false);
		this.chkAutoClearTable.add_ValueChanged(new System.EventHandler(chkAutoClearTable_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkAutoClearTable).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoClearTable).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoClearTable).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearTable).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearTable).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearTable).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearTable).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoGratuity).Name = "chkAutoGratuity";
		((System.Windows.Forms.Control)(object)this.chkAutoGratuity).Tag = "auto_gratuity";
		this.chkAutoGratuity.set_ThumbTickness(27);
		this.chkAutoGratuity.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoGratuity.set_Value(false);
		this.chkAutoGratuity.add_ValueChanged(new System.EventHandler(chkAutoGratuity_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkAutoGratuity).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoGratuity).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoGratuity).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoGratuity).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoGratuity).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoGratuity).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoGratuity).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		this.pnlAutoGratuity.Controls.Add((System.Windows.Forms.Control)(object)this.txtAutoGratuityPercentage);
		this.pnlAutoGratuity.Controls.Add((System.Windows.Forms.Control)(object)this.txtAutoGratuityCount);
		this.pnlAutoGratuity.Controls.Add(this.lblTipPercentage);
		this.pnlAutoGratuity.Controls.Add(this.lblGuest);
		resources.ApplyResources(this.pnlAutoGratuity, "pnlAutoGratuity");
		this.pnlAutoGratuity.Name = "pnlAutoGratuity";
		resources.ApplyResources(this.txtAutoGratuityPercentage, "txtAutoGratuityPercentage");
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityPercentage).Name = "txtAutoGratuityPercentage";
		((RadElement)((RadControl)this.txtAutoGratuityPercentage).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityPercentage).Tag = "Tip Percentage";
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityPercentage).TextChanged += new System.EventHandler(txtAutoGratuityPercentage_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityPercentage).Click += new System.EventHandler(txtAutoGratuityCount_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtAutoGratuityPercentage).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtAutoGratuityPercentage).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		resources.ApplyResources(this.txtAutoGratuityCount, "txtAutoGratuityCount");
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityCount).Name = "txtAutoGratuityCount";
		((RadElement)((RadControl)this.txtAutoGratuityCount).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityCount).Tag = "Minimum Number of Guest";
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityCount).TextChanged += new System.EventHandler(txtAutoGratuityCount_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtAutoGratuityCount).Click += new System.EventHandler(txtAutoGratuityCount_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtAutoGratuityCount).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtAutoGratuityCount).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		resources.ApplyResources(this.lblTipPercentage, "lblTipPercentage");
		this.lblTipPercentage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblTipPercentage.Name = "lblTipPercentage";
		this.lblTipPercentage.Tag = "";
		resources.ApplyResources(this.lblGuest, "lblGuest");
		this.lblGuest.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblGuest.Name = "lblGuest";
		this.lblGuest.Tag = "";
		resources.ApplyResources(this.chkItemCourse, "chkItemCourse");
		((System.Windows.Forms.Control)(object)this.chkItemCourse).Name = "chkItemCourse";
		((System.Windows.Forms.Control)(object)this.chkItemCourse).Tag = "course_selection";
		this.chkItemCourse.set_ThumbTickness(27);
		this.chkItemCourse.set_ToggleStateMode((ToggleStateMode)1);
		this.chkItemCourse.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkItemCourse).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkItemCourse).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkItemCourse).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemCourse).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemCourse).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemCourse).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkItemCourse).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoLogoutCloseOE).Name = "chkAutoLogoutCloseOE";
		((System.Windows.Forms.Control)(object)this.chkAutoLogoutCloseOE).Tag = "auto_logout_oe";
		this.chkAutoLogoutCloseOE.set_ThumbTickness(27);
		this.chkAutoLogoutCloseOE.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoLogoutCloseOE.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoLogoutCloseOE).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoTipCashBack).Name = "chkAutoTipCashBack";
		((System.Windows.Forms.Control)(object)this.chkAutoTipCashBack).Tag = "auto_tip_cash_back";
		this.chkAutoTipCashBack.set_ThumbTickness(27);
		this.chkAutoTipCashBack.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoTipCashBack.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoTipCashBack).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkVoidReason).Name = "chkVoidReason";
		((System.Windows.Forms.Control)(object)this.chkVoidReason).Tag = "prompt_void_orders_reason";
		this.chkVoidReason.set_ThumbTickness(27);
		this.chkVoidReason.set_ToggleStateMode((ToggleStateMode)1);
		this.chkVoidReason.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkVoidReason).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkVoidReason).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkVoidReason).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkVoidReason).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkVoidReason).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkVoidReason).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkVoidReason).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkMemberSelection).Name = "chkMemberSelection";
		((System.Windows.Forms.Control)(object)this.chkMemberSelection).Tag = "member_assign";
		this.chkMemberSelection.set_ThumbTickness(27);
		this.chkMemberSelection.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkMemberSelection).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkMemberSelection).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkMemberSelection).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkMemberSelection).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkMemberSelection).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkMemberSelection).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkMemberSelection).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotifSound);
		this.pnlAll.Controls.Add(this.label26);
		this.pnlAll.Controls.Add(this.pictureBox24);
		this.pnlAll.Controls.Add(this.label27);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotif);
		this.pnlAll.Controls.Add(this.label28);
		this.pnlAll.Controls.Add(this.pictureBox18);
		this.pnlAll.Controls.Add(this.label19);
		this.pnlAll.Controls.Add(this.ddlPickupOrderTimeInc);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoClearOrders);
		this.pnlAll.Controls.Add(this.label22);
		this.pnlAll.Controls.Add(this.label20);
		this.pnlAll.Controls.Add(this.pictureBox19);
		this.pnlAll.Controls.Add(this.label21);
		this.pnlAll.Controls.Add(this.ddlThresholdHours);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkThresholdFul);
		this.pnlAll.Controls.Add(this.label17);
		this.pnlAll.Controls.Add(this.pictureBox17);
		this.pnlAll.Controls.Add(this.label18);
		this.pnlAll.Controls.Add(this.label14);
		this.pnlAll.Controls.Add(this.label15);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkOpenCloseStore);
		this.pnlAll.Controls.Add(this.pictureBox12);
		this.pnlAll.Controls.Add(this.lblConfigSafeDrop);
		this.pnlAll.Controls.Add(this.label11);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkSafeDrop);
		this.pnlAll.Controls.Add(this.label13);
		this.pnlAll.Controls.Add(this.pictureBox10);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowIfChange);
		this.pnlAll.Controls.Add(this.label12);
		this.pnlAll.Controls.Add(this.pictureBox4);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkTipTracking);
		this.pnlAll.Controls.Add(this.pictureBox2);
		this.pnlAll.Controls.Add(this.label6);
		this.pnlAll.Controls.Add(this.label_tiptracking_desc);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkPromptCashoutPIN);
		this.pnlAll.Controls.Add(this.pictureBox15);
		this.pnlAll.Controls.Add(this.label_tiptracking_title);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkConfirmOnlineOrder);
		this.pnlAll.Controls.Add(this.label5);
		this.pnlAll.Controls.Add(this.label1);
		this.pnlAll.Controls.Add(this.label2);
		this.pnlAll.Controls.Add(this.pictureBox21);
		this.pnlAll.Controls.Add(this.label_showfinal_title);
		this.pnlAll.Controls.Add(this.pictureBox1);
		this.pnlAll.Controls.Add(this.pictureBox23);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowCashout);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkMemberSelection);
		this.pnlAll.Controls.Add(this.label_showfinal_desc);
		this.pnlAll.Controls.Add(this.label_memberselection_desc);
		this.pnlAll.Controls.Add(this.pictureBox8);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoTipCashBack);
		this.pnlAll.Controls.Add(this.label_memberselection_title);
		this.pnlAll.Controls.Add(this.label_upc_title);
		this.pnlAll.Controls.Add(this.label_upc_desc);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkVoidReason);
		this.pnlAll.Controls.Add((System.Windows.Forms.Control)(object)this.chkUpcScanning);
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
		((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotifSound).Name = "chkOnlineOrdNotifSound";
		((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotifSound).Tag = "online_order_notification_all_audio";
		this.chkOnlineOrdNotifSound.set_ThumbTickness(27);
		this.chkOnlineOrdNotifSound.set_ToggleStateMode((ToggleStateMode)1);
		this.chkOnlineOrdNotifSound.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotifSound).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotif).Name = "chkOnlineOrdNotif";
		((System.Windows.Forms.Control)(object)this.chkOnlineOrdNotif).Tag = "online_order_notification_all";
		this.chkOnlineOrdNotif.set_ThumbTickness(27);
		this.chkOnlineOrdNotif.set_ToggleStateMode((ToggleStateMode)1);
		this.chkOnlineOrdNotif.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkOnlineOrdNotif).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkAutoClearOrders).Name = "chkAutoClearOrders";
		((System.Windows.Forms.Control)(object)this.chkAutoClearOrders).Tag = "auto_clear_orders";
		this.chkAutoClearOrders.set_ThumbTickness(27);
		this.chkAutoClearOrders.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoClearOrders.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoClearOrders).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkThresholdFul).Name = "chkThresholdFul";
		((System.Windows.Forms.Control)(object)this.chkThresholdFul).Tag = "fulfillment_threshold";
		this.chkThresholdFul.set_ThumbTickness(27);
		this.chkThresholdFul.set_ToggleStateMode((ToggleStateMode)1);
		this.chkThresholdFul.set_Value(false);
		this.chkThresholdFul.add_ValueChanged(new System.EventHandler(chkThresholdFul_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkThresholdFul).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkThresholdFul).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkThresholdFul).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkThresholdFul).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkThresholdFul).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkThresholdFul).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkThresholdFul).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkOpenCloseStore).Name = "chkOpenCloseStore";
		((System.Windows.Forms.Control)(object)this.chkOpenCloseStore).Tag = "openclose_store";
		this.chkOpenCloseStore.set_ThumbTickness(27);
		this.chkOpenCloseStore.set_ToggleStateMode((ToggleStateMode)1);
		this.chkOpenCloseStore.set_Value(false);
		this.chkOpenCloseStore.add_ValueChanged(new System.EventHandler(chkOpenCloseStore_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkOpenCloseStore).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkSafeDrop).Name = "chkSafeDrop";
		((System.Windows.Forms.Control)(object)this.chkSafeDrop).Tag = "safe_drop_setting";
		this.chkSafeDrop.set_ThumbTickness(27);
		this.chkSafeDrop.set_ToggleStateMode((ToggleStateMode)1);
		this.chkSafeDrop.set_Value(false);
		this.chkSafeDrop.add_ValueChanged(new System.EventHandler(chkSafeDrop_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkSafeDrop).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkSafeDrop).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkSafeDrop).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSafeDrop).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSafeDrop).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSafeDrop).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkSafeDrop).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		this.label13.Tag = "";
		resources.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		resources.ApplyResources(this.chkShowIfChange, "chkShowIfChange");
		((System.Windows.Forms.Control)(object)this.chkShowIfChange).Name = "chkShowIfChange";
		((System.Windows.Forms.Control)(object)this.chkShowIfChange).Tag = "payfinish_screen_ifchange";
		this.chkShowIfChange.set_ThumbTickness(27);
		this.chkShowIfChange.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowIfChange.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowIfChange).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowIfChange).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowIfChange).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowIfChange).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowIfChange).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowIfChange).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowIfChange).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		this.label12.Tag = "";
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.chkTipTracking, "chkTipTracking");
		((System.Windows.Forms.Control)(object)this.chkTipTracking).Name = "chkTipTracking";
		((System.Windows.Forms.Control)(object)this.chkTipTracking).Tag = "tip_tracking";
		this.chkTipTracking.set_ThumbTickness(27);
		this.chkTipTracking.set_ToggleStateMode((ToggleStateMode)1);
		this.chkTipTracking.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkTipTracking).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkTipTracking).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkTipTracking).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkTipTracking).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkTipTracking).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkTipTracking).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkTipTracking).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
		((System.Windows.Forms.Control)(object)this.chkPromptCashoutPIN).Name = "chkPromptCashoutPIN";
		((System.Windows.Forms.Control)(object)this.chkPromptCashoutPIN).Tag = "workflow_prompt_cashout_pin";
		this.chkPromptCashoutPIN.set_ThumbTickness(27);
		this.chkPromptCashoutPIN.set_ToggleStateMode((ToggleStateMode)1);
		this.chkPromptCashoutPIN.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPromptCashoutPIN).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.pictureBox15, "pictureBox15");
		this.pictureBox15.Name = "pictureBox15";
		this.pictureBox15.TabStop = false;
		this.label_tiptracking_title.BackColor = System.Drawing.Color.Transparent;
		this.label_tiptracking_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_tiptracking_title, "label_tiptracking_title");
		this.label_tiptracking_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tiptracking_title.Name = "label_tiptracking_title";
		resources.ApplyResources(this.chkConfirmOnlineOrder, "chkConfirmOnlineOrder");
		((System.Windows.Forms.Control)(object)this.chkConfirmOnlineOrder).Name = "chkConfirmOnlineOrder";
		((System.Windows.Forms.Control)(object)this.chkConfirmOnlineOrder).Tag = "confirm_online_orders";
		this.chkConfirmOnlineOrder.set_ThumbTickness(27);
		this.chkConfirmOnlineOrder.set_ToggleStateMode((ToggleStateMode)1);
		this.chkConfirmOnlineOrder.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkConfirmOnlineOrder).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
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
