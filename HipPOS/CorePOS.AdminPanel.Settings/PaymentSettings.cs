using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.AdminPanel.Settings.Payment;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class PaymentSettings : UserControl
{
	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private PictureBox pictureBox1;

	private Label label_processor_desc;

	private Label label_processor_title;

	private RadToggleSwitch chkPaymentProcessor;

	private Label lblPaymentProcessor_ChangeSettings;

	private PictureBox pictureBox5;

	private Label xVbFbzjihnf;

	private Label label_transaction_fee_title;

	private PictureBox pictureBox10;

	private Label label_gc_processor_desc;

	private Label label_gc_processor_title;

	private Label lblGiftCardSettings;

	private RadToggleSwitch chkGiftCardProcessor;

	private PictureBox pictureBox11;

	private Label label_patt_desc;

	private Label label_patt_title;

	private Class19 ddlPATTServer;

	private Label lblLoyaltyCard;

	private PictureBox pictureBox13;

	private Label label_loyalty_processor_desc;

	private Label label_loyalty_processor_title;

	private RadToggleSwitch chkLoyaltyCardProcessor;

	private Label label6;

	private RadToggleSwitch chkHttpListener;

	private PictureBox pictureBox2;

	private Label label1;

	private Label label2;

	private Label lblConfigurePaymentTypes;

	private Label label8;

	private Label label7;

	private PictureBox pictureBox3;

	private RadToggleSwitch chkAutoSettlement;

	private Label lblChangeTime;

	private PictureBox pictureBox4;

	private Label label4;

	private Label label5;

	private Label lblAccessToken;

	private Label label_access_token;

	private PictureBox pictureBox6;

	private Label label3;

	private Label label10;

	private RadTextBoxControl txtStartPort;

	private RadTextBoxControl txtEndPort;

	private Label label11;

	private Label lblConfigureCard;

	public PaymentSettings()
	{
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Expected O, but got Unknown
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		Dictionary<string, string> dataSource = new Dictionary<string, string>
		{
			{ "en-US", "English" },
			{ "fr-CA", "Français" },
			{ "es-US", "Español" }
		};
		Dictionary<int, string> dictionary = new Dictionary<int, string> { { 0, "DISABLED" } };
		foreach (KeyValuePair<int, string> item in (from a in gclass6_0.Terminals
			where a.Status == TerminalStatus.active
			orderby a.SystemName
			select a).ToDictionary((Terminal a) => a.TerminalID, (Terminal a) => a.SystemName))
		{
			dictionary.Add(item.Key, item.Value);
		}
		ddlPATTServer.DisplayMember = "Value";
		ddlPATTServer.ValueMember = "Key";
		ddlPATTServer.DataSource = new BindingSource(dictionary, null);
		IEnumerator enumerator2 = base.Controls.GetEnumerator();
		Setting setting;
		try
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
				CS_0024_003C_003E8__locals0.ctrl = (Control)enumerator2.Current;
				if (CS_0024_003C_003E8__locals0.ctrl.Tag == null)
				{
					continue;
				}
				setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.ctrl.Tag.Equals(s.Key)).FirstOrDefault();
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
				}
				else if (!(CS_0024_003C_003E8__locals0.ctrl.Name == "ddlPrimaryLanguage") && !(CS_0024_003C_003E8__locals0.ctrl.Name == "ddlSecondaryLanguage"))
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl") && CS_0024_003C_003E8__locals0.ctrl.Name != "ddlPrimaryLanguage" && CS_0024_003C_003E8__locals0.ctrl.Name != "ddlSecondaryLanguage")
					{
						((ComboBox)CS_0024_003C_003E8__locals0.ctrl).Text = setting.Value.ToUpper();
						continue;
					}
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("txt"))
					{
						((Control)(RadTextBoxControl)CS_0024_003C_003E8__locals0.ctrl).Text = setting.Value;
						continue;
					}
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains(((Control)(object)chkHttpListener).Name))
					{
						if (setting.Value == "ON")
						{
							Label label = lblAccessToken;
							label_access_token.Visible = true;
							label.Visible = true;
						}
						else if (setting.Value == "OFF")
						{
							Label label2 = lblAccessToken;
							label_access_token.Visible = false;
							label2.Visible = false;
						}
					}
					else
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
				else
				{
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).DataSource = new BindingSource(dataSource, null);
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).DisplayMember = "Value";
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).ValueMember = "Key";
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).SelectedValue = setting.Value;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator2 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		setting = iqueryable_0.Where((Setting s) => s.Key == "http_port_range").FirstOrDefault();
		if (setting != null)
		{
			string[] array = setting.Value.Split('-');
			((Control)(object)txtStartPort).Text = array[0];
			((Control)(object)txtEndPort).Text = array[1];
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
		new frmSettingsEmail().ShowDialog();
	}

	private void method_2(object sender, EventArgs e)
	{
		new frmSettingsSMS().ShowDialog();
	}

	private void lblPaymentProcessor_ChangeSettings_Click(object sender, EventArgs e)
	{
		new frmSettingsPaymentProcessor().ShowDialog();
	}

	private void method_3(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Delivery Charge", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Card Transaction Fee", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Kitchen Tip %", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Breakage Tip %", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void lblGiftCardSettings_Click(object sender, EventArgs e)
	{
		new frmGiftCardSettings("gift_card_json").Show(this);
	}

	private void ddlPATTServer_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ddlPATTServer.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		setting.Value = ddlPATTServer.Text;
		gclass6_0.Terminals.ToList().ForEach(delegate(Terminal a)
		{
			a.AppRestartRequired = true;
		});
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	private void lblLoyaltyCard_Click(object sender, EventArgs e)
	{
		new frmGiftCardSettings("loyalty_card_json").Show(this);
	}

	private void method_7(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Delivery Charge per KM", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Free Delivery Charge Over", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void chkHttpListener_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkHttpListener).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.ToUpper().Equals("ON"))
			{
				setting.Value = "OFF";
				Label label = lblAccessToken;
				label_access_token.Visible = false;
				label.Visible = false;
			}
			else
			{
				setting.Value = "ON";
				Label label2 = lblAccessToken;
				label_access_token.Visible = true;
				label2.Visible = true;
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkHttpListener).Tag.ToString(), setting.Value);
		}
	}

	private void lblConfigurePaymentTypes_Click(object sender, EventArgs e)
	{
		new frmManagePaymentTypes().Show(base.ParentForm);
	}

	private void lblChangeTime_Click(object sender, EventArgs e)
	{
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "auto_settlement_time").FirstOrDefault();
		if (setting != null)
		{
			DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
			if (!string.IsNullOrEmpty(setting.Value))
			{
				time = Convert.ToDateTime(setting.Value);
			}
			frmTimePicker frmTimePicker = new frmTimePicker(time, 30);
			if (frmTimePicker.ShowDialog() == DialogResult.OK)
			{
				setting.Value = frmTimePicker.Time.ToString();
				gclass6_0.SubmitChanges();
				SettingsHelper.SetSettingValueByKey("auto_settlement_time", setting.Value);
			}
		}
	}

	private void lblAccessToken_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.lbl = (Label)sender;
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.lbl.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Access Token", 0, 128, setting.Value);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			string text2 = (setting.Value = (label_access_token.Text = MemoryLoadedObjects.Keyboard.textEntered));
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.lbl.Tag.ToString(), label_access_token.Text);
			if (new frmMessageBox(Resources.Hippos_needs_to_be_restarted_f, Resources.Settings_changed, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
			{
				FormHelper.CleanupObjects();
				Application.Restart();
			}
		}
	}

	private void txtStartPort_TextChanged(object sender, EventArgs e)
	{
		method_9();
	}

	private void txtEndPort_TextChanged(object sender, EventArgs e)
	{
		method_9();
	}

	private void method_9()
	{
		Setting setting = iqueryable_0.Where((Setting s) => s.Key == "http_port_range").FirstOrDefault();
		if (setting != null)
		{
			setting.Value = ((Control)(object)txtStartPort).Text + "-" + ((Control)(object)txtEndPort).Text;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey("http_port_range", setting.Value);
			new NotificationLabel(base.ParentForm, "Port Range Changed.", NotificationTypes.Success).Show();
		}
	}

	private void txtEndPort_Click(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Range Start Port", 0, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void lblConfigureCard_Click(object sender, EventArgs e)
	{
		new frmCardTransactionFee().ShowDialog();
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1006: Unknown result type (might be due to invalid IL or missing references)
		//IL_1033: Unknown result type (might be due to invalid IL or missing references)
		//IL_1347: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Unknown result type (might be due to invalid IL or missing references)
		//IL_140b: Unknown result type (might be due to invalid IL or missing references)
		//IL_142c: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.PaymentSettings));
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label_processor_desc = new System.Windows.Forms.Label();
		this.label_processor_title = new System.Windows.Forms.Label();
		this.chkPaymentProcessor = new RadToggleSwitch();
		this.lblPaymentProcessor_ChangeSettings = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.xVbFbzjihnf = new System.Windows.Forms.Label();
		this.label_transaction_fee_title = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.label_gc_processor_desc = new System.Windows.Forms.Label();
		this.label_gc_processor_title = new System.Windows.Forms.Label();
		this.lblGiftCardSettings = new System.Windows.Forms.Label();
		this.chkGiftCardProcessor = new RadToggleSwitch();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.label_patt_desc = new System.Windows.Forms.Label();
		this.label_patt_title = new System.Windows.Forms.Label();
		this.lblLoyaltyCard = new System.Windows.Forms.Label();
		this.pictureBox13 = new System.Windows.Forms.PictureBox();
		this.label_loyalty_processor_desc = new System.Windows.Forms.Label();
		this.label_loyalty_processor_title = new System.Windows.Forms.Label();
		this.chkLoyaltyCardProcessor = new RadToggleSwitch();
		this.label6 = new System.Windows.Forms.Label();
		this.chkHttpListener = new RadToggleSwitch();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.lblConfigurePaymentTypes = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.chkAutoSettlement = new RadToggleSwitch();
		this.lblChangeTime = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.lblAccessToken = new System.Windows.Forms.Label();
		this.label_access_token = new System.Windows.Forms.Label();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.txtStartPort = new RadTextBoxControl();
		this.txtEndPort = new RadTextBoxControl();
		this.label11 = new System.Windows.Forms.Label();
		this.ddlPATTServer = new Class19();
		this.lblConfigureCard = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPaymentProcessor).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkGiftCardProcessor).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkLoyaltyCardProcessor).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkHttpListener).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoSettlement).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStartPort).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndPort).BeginInit();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(this.label_processor_desc, "label_processor_desc");
		this.label_processor_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_processor_desc.Name = "label_processor_desc";
		this.label_processor_desc.Tag = "";
		this.label_processor_title.BackColor = System.Drawing.Color.Transparent;
		this.label_processor_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_processor_title, "label_processor_title");
		this.label_processor_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_processor_title.Name = "label_processor_title";
		componentResourceManager.ApplyResources(this.chkPaymentProcessor, "chkPaymentProcessor");
		((System.Windows.Forms.Control)(object)this.chkPaymentProcessor).Name = "chkPaymentProcessor";
		((System.Windows.Forms.Control)(object)this.chkPaymentProcessor).Tag = "use_payment_processor";
		this.chkPaymentProcessor.set_ThumbTickness(27);
		this.chkPaymentProcessor.set_ToggleStateMode((ToggleStateMode)1);
		this.chkPaymentProcessor.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPaymentProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this.lblPaymentProcessor_ChangeSettings, "lblPaymentProcessor_ChangeSettings");
		this.lblPaymentProcessor_ChangeSettings.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblPaymentProcessor_ChangeSettings.Name = "lblPaymentProcessor_ChangeSettings";
		this.lblPaymentProcessor_ChangeSettings.Click += new System.EventHandler(lblPaymentProcessor_ChangeSettings_Click);
		componentResourceManager.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		componentResourceManager.ApplyResources(this.xVbFbzjihnf, "label_transaction_fee_desc");
		this.xVbFbzjihnf.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.xVbFbzjihnf.Name = "label_transaction_fee_desc";
		this.xVbFbzjihnf.Tag = "";
		this.label_transaction_fee_title.BackColor = System.Drawing.Color.Transparent;
		this.label_transaction_fee_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_transaction_fee_title, "label_transaction_fee_title");
		this.label_transaction_fee_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_transaction_fee_title.Name = "label_transaction_fee_title";
		componentResourceManager.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		componentResourceManager.ApplyResources(this.label_gc_processor_desc, "label_gc_processor_desc");
		this.label_gc_processor_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_gc_processor_desc.Name = "label_gc_processor_desc";
		this.label_gc_processor_desc.Tag = "";
		this.label_gc_processor_title.BackColor = System.Drawing.Color.Transparent;
		this.label_gc_processor_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_gc_processor_title, "label_gc_processor_title");
		this.label_gc_processor_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_gc_processor_title.Name = "label_gc_processor_title";
		componentResourceManager.ApplyResources(this.lblGiftCardSettings, "lblGiftCardSettings");
		this.lblGiftCardSettings.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblGiftCardSettings.Name = "lblGiftCardSettings";
		this.lblGiftCardSettings.Click += new System.EventHandler(lblGiftCardSettings_Click);
		componentResourceManager.ApplyResources(this.chkGiftCardProcessor, "chkGiftCardProcessor");
		((System.Windows.Forms.Control)(object)this.chkGiftCardProcessor).Name = "chkGiftCardProcessor";
		((System.Windows.Forms.Control)(object)this.chkGiftCardProcessor).Tag = "gift_card_payment";
		this.chkGiftCardProcessor.set_ThumbTickness(27);
		this.chkGiftCardProcessor.set_ToggleStateMode((ToggleStateMode)1);
		this.chkGiftCardProcessor.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkGiftCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		componentResourceManager.ApplyResources(this.label_patt_desc, "label_patt_desc");
		this.label_patt_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_patt_desc.Name = "label_patt_desc";
		this.label_patt_desc.Tag = "";
		this.label_patt_title.BackColor = System.Drawing.Color.Transparent;
		this.label_patt_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_patt_title, "label_patt_title");
		this.label_patt_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_patt_title.Name = "label_patt_title";
		componentResourceManager.ApplyResources(this.lblLoyaltyCard, "lblLoyaltyCard");
		this.lblLoyaltyCard.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLoyaltyCard.Name = "lblLoyaltyCard";
		this.lblLoyaltyCard.Click += new System.EventHandler(lblLoyaltyCard_Click);
		componentResourceManager.ApplyResources(this.pictureBox13, "pictureBox13");
		this.pictureBox13.Name = "pictureBox13";
		this.pictureBox13.TabStop = false;
		componentResourceManager.ApplyResources(this.label_loyalty_processor_desc, "label_loyalty_processor_desc");
		this.label_loyalty_processor_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_loyalty_processor_desc.Name = "label_loyalty_processor_desc";
		this.label_loyalty_processor_desc.Tag = "";
		this.label_loyalty_processor_title.BackColor = System.Drawing.Color.Transparent;
		this.label_loyalty_processor_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_loyalty_processor_title, "label_loyalty_processor_title");
		this.label_loyalty_processor_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_loyalty_processor_title.Name = "label_loyalty_processor_title";
		componentResourceManager.ApplyResources(this.chkLoyaltyCardProcessor, "chkLoyaltyCardProcessor");
		((System.Windows.Forms.Control)(object)this.chkLoyaltyCardProcessor).Name = "chkLoyaltyCardProcessor";
		((System.Windows.Forms.Control)(object)this.chkLoyaltyCardProcessor).Tag = "loyalty_card_payment";
		this.chkLoyaltyCardProcessor.set_ThumbTickness(27);
		this.chkLoyaltyCardProcessor.set_ToggleStateMode((ToggleStateMode)1);
		this.chkLoyaltyCardProcessor.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkLoyaltyCardProcessor).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this.label6, "label6");
		this.label6.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label6.ForeColor = System.Drawing.Color.White;
		this.label6.Name = "label6";
		componentResourceManager.ApplyResources(this.chkHttpListener, "chkHttpListener");
		((System.Windows.Forms.Control)(object)this.chkHttpListener).Name = "chkHttpListener";
		((System.Windows.Forms.Control)(object)this.chkHttpListener).Tag = "enable_http_listener";
		this.chkHttpListener.set_ThumbTickness(27);
		this.chkHttpListener.set_ToggleStateMode((ToggleStateMode)1);
		this.chkHttpListener.set_Value(false);
		this.chkHttpListener.add_ValueChanged(new System.EventHandler(chkHttpListener_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkHttpListener).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkHttpListener).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkHttpListener).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkHttpListener).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkHttpListener).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkHttpListener).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkHttpListener).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		componentResourceManager.ApplyResources(this.lblConfigurePaymentTypes, "lblConfigurePaymentTypes");
		this.lblConfigurePaymentTypes.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblConfigurePaymentTypes.Name = "lblConfigurePaymentTypes";
		this.lblConfigurePaymentTypes.Click += new System.EventHandler(lblConfigurePaymentTypes_Click);
		componentResourceManager.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		this.label8.Tag = "";
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		componentResourceManager.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		componentResourceManager.ApplyResources(this.chkAutoSettlement, "chkAutoSettlement");
		((System.Windows.Forms.Control)(object)this.chkAutoSettlement).Name = "chkAutoSettlement";
		((System.Windows.Forms.Control)(object)this.chkAutoSettlement).Tag = "auto_settlement";
		this.chkAutoSettlement.set_ThumbTickness(27);
		this.chkAutoSettlement.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAutoSettlement.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkAutoSettlement).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAutoSettlement).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAutoSettlement).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoSettlement).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoSettlement).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAutoSettlement).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAutoSettlement).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this.lblChangeTime, "lblChangeTime");
		this.lblChangeTime.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblChangeTime.Name = "lblChangeTime";
		this.lblChangeTime.Click += new System.EventHandler(lblChangeTime_Click);
		componentResourceManager.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		componentResourceManager.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		componentResourceManager.ApplyResources(this.lblAccessToken, "lblAccessToken");
		this.lblAccessToken.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblAccessToken.Name = "lblAccessToken";
		this.lblAccessToken.Tag = "http_listener_access_token";
		this.lblAccessToken.Click += new System.EventHandler(lblAccessToken_Click);
		componentResourceManager.ApplyResources(this.label_access_token, "label_access_token");
		this.label_access_token.ForeColor = System.Drawing.Color.Gray;
		this.label_access_token.Name = "label_access_token";
		this.label_access_token.Tag = "http_listener_access_token";
		componentResourceManager.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		componentResourceManager.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		this.label3.Tag = "";
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		componentResourceManager.ApplyResources(this.txtStartPort, "txtStartPort");
		((System.Windows.Forms.Control)(object)this.txtStartPort).Name = "txtStartPort";
		((RadElement)((RadControl)this.txtStartPort).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtStartPort).Tag = "http_port_range_start";
		((System.Windows.Forms.Control)(object)this.txtStartPort).TextChanged += new System.EventHandler(txtStartPort_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtStartPort).Click += new System.EventHandler(txtEndPort_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtStartPort).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtStartPort).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		componentResourceManager.ApplyResources(this.txtEndPort, "txtEndPort");
		((System.Windows.Forms.Control)(object)this.txtEndPort).Name = "txtEndPort";
		((RadElement)((RadControl)this.txtEndPort).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtEndPort).Tag = "http_port_range_end";
		((System.Windows.Forms.Control)(object)this.txtEndPort).TextChanged += new System.EventHandler(txtEndPort_TextChanged);
		((System.Windows.Forms.Control)(object)this.txtEndPort).Click += new System.EventHandler(txtEndPort_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtEndPort).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtEndPort).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		this.label11.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.Black;
		this.label11.Name = "label11";
		this.ddlPATTServer.BackColor = System.Drawing.Color.White;
		this.ddlPATTServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlPATTServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(this.ddlPATTServer, "ddlPATTServer");
		this.ddlPATTServer.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlPATTServer.FormattingEnabled = true;
		this.ddlPATTServer.Name = "ddlPATTServer";
		this.ddlPATTServer.Tag = "patt_server";
		this.ddlPATTServer.SelectedIndexChanged += new System.EventHandler(ddlPATTServer_SelectedIndexChanged);
		componentResourceManager.ApplyResources(this.lblConfigureCard, "lblConfigureCard");
		this.lblConfigureCard.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblConfigureCard.Name = "lblConfigureCard";
		this.lblConfigureCard.Click += new System.EventHandler(lblConfigureCard_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.lblConfigureCard);
		base.Controls.Add(this.label11);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtEndPort);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtStartPort);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label_access_token);
		base.Controls.Add(this.lblAccessToken);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkAutoSettlement);
		base.Controls.Add(this.lblChangeTime);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.lblConfigurePaymentTypes);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label7);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkHttpListener);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkLoyaltyCardProcessor);
		base.Controls.Add(this.lblLoyaltyCard);
		base.Controls.Add(this.pictureBox13);
		base.Controls.Add(this.label_loyalty_processor_desc);
		base.Controls.Add(this.label_loyalty_processor_title);
		base.Controls.Add(this.ddlPATTServer);
		base.Controls.Add(this.pictureBox11);
		base.Controls.Add(this.label_patt_desc);
		base.Controls.Add(this.label_patt_title);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkGiftCardProcessor);
		base.Controls.Add(this.lblGiftCardSettings);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.label_gc_processor_desc);
		base.Controls.Add(this.label_gc_processor_title);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.xVbFbzjihnf);
		base.Controls.Add(this.label_transaction_fee_title);
		base.Controls.Add(this.lblPaymentProcessor_ChangeSettings);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkPaymentProcessor);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label_processor_desc);
		base.Controls.Add(this.label_processor_title);
		base.Name = "PaymentSettings";
		componentResourceManager.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPaymentProcessor).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkGiftCardProcessor).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkLoyaltyCardProcessor).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkHttpListener).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoSettlement).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStartPort).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndPort).EndInit();
		base.ResumeLayout(false);
	}
}
