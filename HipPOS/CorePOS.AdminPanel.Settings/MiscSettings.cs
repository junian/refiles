using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using CorePOS.AdminPanel.Settings.Misc;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class MiscSettings : UserControl
{
	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private PictureBox pictureBox17;

	private RadToggleSwitch chkCapacity;

	private Label label_capacity_desc;

	private Label label_capacity_title;

	private Label lblEmailSettings;

	private Label label_emailSettings_title;

	private PictureBox pictureBox8;

	private Label label_emailSettings_desc;

	private Label label_primaryLanguage_desc;

	private PictureBox pictureBox2;

	private Label label_primaryLanguage_title;

	private Label label_secondaryLanguage_desc;

	private PictureBox pictureBox3;

	private Label label_secondaryLanguage_title;

	private Class19 ddlPrimaryLanguage;

	private Class19 ddlSecondaryLanguage;

	private Label label16;

	private PictureBox pictureBox6;

	private RadToggleSwitch chkPayout;

	private Label label11;

	private Label label12;

	private Label label1;

	private RadToggleSwitch chkPrintPayout;

	private PictureBox pictureBox4;

	private Label label4;

	private Label label5;

	private Label lblKioskSettings;

	private Class19 ddlScaleMake;

	private Label label9;

	private Label label10;

	private PictureBox pictureBox5;

	private Label lblTestScale;

	private Class19 class19_0;

	private Label label7;

	private Label label8;

	private PictureBox pictureBox7;

	private PictureBox pictureBox9;

	private RadToggleSwitch chkScaleFunctionality;

	private Label label6;

	private Label label13;

	private Class19 ddlScaleCOMPort;

	private Label lblScaleComPortDesc;

	private Label lblScaleComPortTitle;

	private PictureBox pictureBox10;

	private PictureBox pictureBox11;

	private RadToggleSwitch chkCoinSystem;

	private Label label14;

	private Label label15;

	private Label lblDeliveryManage;

	private Label lblDescDeliveryManage;

	private RadToggleSwitch chkDeliveryManagement;

	private PictureBox picDeliveryManage;

	public MiscSettings()
	{
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
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
		ddlScaleCOMPort.Items.Add("NONE");
		string[] portNames = SerialPort.GetPortNames();
		ComboBox.ObjectCollection items = ddlScaleCOMPort.Items;
		object[] items2 = portNames;
		items.AddRange(items2);
		ddlScaleMake.Items.Add(HWBrands.Scales.Generic);
		ddlScaleMake.Items.Add(HWBrands.Scales.Brecknell);
		IEnumerator enumerator = base.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
				CS_0024_003C_003E8__locals0.ctrl = (Control)enumerator.Current;
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
				}
				else if (!(CS_0024_003C_003E8__locals0.ctrl.Name == "ddlPrimaryLanguage") && !(CS_0024_003C_003E8__locals0.ctrl.Name == "ddlSecondaryLanguage"))
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl") && CS_0024_003C_003E8__locals0.ctrl.Name != "ddlPrimaryLanguage" && CS_0024_003C_003E8__locals0.ctrl.Name != "ddlSecondaryLanguage")
					{
						if (((ComboBox)CS_0024_003C_003E8__locals0.ctrl).Items.IndexOf(setting.Value) == -1)
						{
							if (((ComboBox)CS_0024_003C_003E8__locals0.ctrl).Items.Count > 0)
							{
								bool_0 = false;
								((ComboBox)CS_0024_003C_003E8__locals0.ctrl).SelectedIndex = 0;
								bool_0 = true;
							}
						}
						else
						{
							CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value.ToUpper();
						}
						continue;
					}
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("txt"))
					{
						((Control)(RadTextBoxControl)CS_0024_003C_003E8__locals0.ctrl).Text = setting.Value;
						continue;
					}
					if (setting.Value.Contains("ON"))
					{
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(true);
					}
					else
					{
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(false);
					}
					if (CS_0024_003C_003E8__locals0.ctrl.Name == "chkScaleFunctionality")
					{
						Class19 @class = ddlScaleCOMPort;
						bool enabled = (class19_0.Enabled = ((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_Value());
						@class.Enabled = enabled;
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement().add_ValueChanged((EventHandler)method_1);
					}
					else
					{
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement().add_ValueChanged((EventHandler)method_0);
						((RadElement)((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement()).set_Tag(((Control)(RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag);
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
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		Terminal this_terminal = MemoryLoadedObjects.this_terminal;
		if (this_terminal != null)
		{
			ddlScaleCOMPort.Text = this_terminal.Scale_ComPort;
		}
		if (!MemoryLoadedData.IsDeliveryManagement)
		{
			PictureBox pictureBox = picDeliveryManage;
			Label label = lblDeliveryManage;
			Label label2 = lblDescDeliveryManage;
			((Control)(object)chkDeliveryManagement).Visible = false;
			label2.Visible = false;
			bool enabled = false;
			label.Visible = false;
			pictureBox.Visible = false;
		}
		bool_0 = false;
	}

	private void lblEmailSettings_Click(object sender, EventArgs e)
	{
		new frmSettingsEmail().ShowDialog();
	}

	private void method_0(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
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
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ((Control)(object)chkScaleFunctionality).Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkScaleFunctionality.get_Value())
			{
				setting.Value = "ON";
				Label label = lblTestScale;
				Class19 @class = ddlScaleCOMPort;
				class19_0.Enabled = true;
				@class.Enabled = true;
				label.Enabled = true;
			}
			else
			{
				setting.Value = "OFF";
				Label label2 = lblTestScale;
				Class19 class2 = ddlScaleCOMPort;
				class19_0.Enabled = false;
				class2.Enabled = false;
				label2.Enabled = false;
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(((Control)(object)chkScaleFunctionality).Tag.ToString(), setting.Value);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		new frmSettingsPaymentProcessor().ShowDialog();
	}

	private void ddlPrimaryLanguage_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlPrimaryLanguage.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlPrimaryLanguage.SelectedValue.ToString();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlPrimaryLanguage.Tag.ToString(), setting.Value);
			}
		}
	}

	private void ddlSecondaryLanguage_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlSecondaryLanguage.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlSecondaryLanguage.SelectedValue.ToString();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlSecondaryLanguage.Tag.ToString(), setting.Value);
			}
		}
	}

	private void lblKioskSettings_Click(object sender, EventArgs e)
	{
		new frmKioskSettings().ShowDialog();
	}

	private void ddlScaleCOMPort_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Terminal terminal = gclass6_0.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (terminal != null)
			{
				terminal.Scale_ComPort = ddlScaleCOMPort.Text;
				gclass6_0.SubmitChanges();
				MemoryLoadedObjects.scale_comport = ddlScaleCOMPort.Text;
			}
		}
	}

	private void ddlScaleMake_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
			CS_0024_003C_003E8__locals0.ddl = (Class19)sender;
			Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.ddl.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = CS_0024_003C_003E8__locals0.ddl.Text;
				gclass6_0.SubmitChanges();
				SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.ddl.Tag.ToString(), setting.Value);
			}
		}
	}

	private void class19_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => class19_0.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = class19_0.Text;
				gclass6_0.SubmitChanges();
				SettingsHelper.SetSettingValueByKey(class19_0.Tag.ToString(), setting.Value);
			}
		}
	}

	private void lblTestScale_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Weight In: " + class19_0.Text, 4, 8, "", "", allowNegative: true);
		MemoryLoadedObjects.Numpad.ShowDialog(this);
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1540: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_156f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1590: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1617: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1818: Unknown result type (might be due to invalid IL or missing references)
		//IL_1845: Unknown result type (might be due to invalid IL or missing references)
		//IL_1872: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.MiscSettings));
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.chkCapacity = new RadToggleSwitch();
		this.label_capacity_desc = new System.Windows.Forms.Label();
		this.label_capacity_title = new System.Windows.Forms.Label();
		this.lblEmailSettings = new System.Windows.Forms.Label();
		this.label_emailSettings_title = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label_emailSettings_desc = new System.Windows.Forms.Label();
		this.label_primaryLanguage_desc = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label_primaryLanguage_title = new System.Windows.Forms.Label();
		this.label_secondaryLanguage_desc = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.label_secondaryLanguage_title = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.chkPayout = new RadToggleSwitch();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.chkPrintPayout = new RadToggleSwitch();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.lblKioskSettings = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.lblTestScale = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.chkScaleFunctionality = new RadToggleSwitch();
		this.label6 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.lblScaleComPortDesc = new System.Windows.Forms.Label();
		this.lblScaleComPortTitle = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.ddlScaleMake = new Class19();
		this.class19_0 = new Class19();
		this.ddlSecondaryLanguage = new Class19();
		this.ddlPrimaryLanguage = new Class19();
		this.ddlScaleCOMPort = new Class19();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.chkCoinSystem = new RadToggleSwitch();
		this.label14 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.lblDeliveryManage = new System.Windows.Forms.Label();
		this.lblDescDeliveryManage = new System.Windows.Forms.Label();
		this.chkDeliveryManagement = new RadToggleSwitch();
		this.picDeliveryManage = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkCapacity).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPayout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintPayout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkScaleFunctionality).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkCoinSystem).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkDeliveryManagement).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDeliveryManage).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.pictureBox17, "pictureBox17");
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.TabStop = false;
		resources.ApplyResources(this.chkCapacity, "chkCapacity");
		((System.Windows.Forms.Control)(object)this.chkCapacity).Name = "chkCapacity";
		((System.Windows.Forms.Control)(object)this.chkCapacity).Tag = "restaurant_capacity";
		this.chkCapacity.set_ThumbTickness(27);
		this.chkCapacity.set_ToggleStateMode((ToggleStateMode)1);
		this.chkCapacity.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkCapacity).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkCapacity).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkCapacity).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapacity).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapacity).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapacity).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkCapacity).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label_capacity_desc, "label_capacity_desc");
		this.label_capacity_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_capacity_desc.Name = "label_capacity_desc";
		this.label_capacity_desc.Tag = "";
		this.label_capacity_title.BackColor = System.Drawing.Color.Transparent;
		this.label_capacity_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_capacity_title, "label_capacity_title");
		this.label_capacity_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_capacity_title.Name = "label_capacity_title";
		resources.ApplyResources(this.lblEmailSettings, "lblEmailSettings");
		this.lblEmailSettings.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblEmailSettings.Name = "lblEmailSettings";
		this.lblEmailSettings.Click += new System.EventHandler(lblEmailSettings_Click);
		this.label_emailSettings_title.BackColor = System.Drawing.Color.Transparent;
		this.label_emailSettings_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_emailSettings_title, "label_emailSettings_title");
		this.label_emailSettings_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_emailSettings_title.Name = "label_emailSettings_title";
		resources.ApplyResources(this.pictureBox8, "pictureBox8");
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.TabStop = false;
		resources.ApplyResources(this.label_emailSettings_desc, "label_emailSettings_desc");
		this.label_emailSettings_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_emailSettings_desc.Name = "label_emailSettings_desc";
		this.label_emailSettings_desc.Tag = "";
		resources.ApplyResources(this.label_primaryLanguage_desc, "label_primaryLanguage_desc");
		this.label_primaryLanguage_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_primaryLanguage_desc.Name = "label_primaryLanguage_desc";
		this.label_primaryLanguage_desc.Tag = "";
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		this.label_primaryLanguage_title.BackColor = System.Drawing.Color.Transparent;
		this.label_primaryLanguage_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_primaryLanguage_title, "label_primaryLanguage_title");
		this.label_primaryLanguage_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_primaryLanguage_title.Name = "label_primaryLanguage_title";
		resources.ApplyResources(this.label_secondaryLanguage_desc, "label_secondaryLanguage_desc");
		this.label_secondaryLanguage_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_secondaryLanguage_desc.Name = "label_secondaryLanguage_desc";
		this.label_secondaryLanguage_desc.Tag = "";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		this.label_secondaryLanguage_title.BackColor = System.Drawing.Color.Transparent;
		this.label_secondaryLanguage_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_secondaryLanguage_title, "label_secondaryLanguage_title");
		this.label_secondaryLanguage_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_secondaryLanguage_title.Name = "label_secondaryLanguage_title";
		resources.ApplyResources(this.label16, "label16");
		this.label16.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label16.ForeColor = System.Drawing.Color.White;
		this.label16.Name = "label16";
		resources.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		resources.ApplyResources(this.chkPayout, "chkPayout");
		((System.Windows.Forms.Control)(object)this.chkPayout).Name = "chkPayout";
		((System.Windows.Forms.Control)(object)this.chkPayout).Tag = "show_payout_button";
		this.chkPayout.set_ThumbTickness(27);
		this.chkPayout.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPayout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPayout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPayout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPayout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPayout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPayout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPayout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label11.Name = "label11";
		this.label11.Tag = "";
		this.label12.BackColor = System.Drawing.Color.Transparent;
		this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		resources.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		resources.ApplyResources(this.chkPrintPayout, "chkPrintPayout");
		((System.Windows.Forms.Control)(object)this.chkPrintPayout).Name = "chkPrintPayout";
		((System.Windows.Forms.Control)(object)this.chkPrintPayout).Tag = "print_payout";
		this.chkPrintPayout.set_ThumbTickness(27);
		this.chkPrintPayout.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPrintPayout).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPrintPayout).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPrintPayout).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPrintPayout).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPrintPayout).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPrintPayout).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPrintPayout).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		resources.ApplyResources(this.lblKioskSettings, "lblKioskSettings");
		this.lblKioskSettings.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblKioskSettings.Name = "lblKioskSettings";
		this.lblKioskSettings.Click += new System.EventHandler(lblKioskSettings_Click);
		resources.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		this.label9.Tag = "";
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		resources.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		resources.ApplyResources(this.lblTestScale, "lblTestScale");
		this.lblTestScale.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblTestScale.Name = "lblTestScale";
		this.lblTestScale.Click += new System.EventHandler(lblTestScale_Click);
		resources.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		this.label7.Tag = "";
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		resources.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		resources.ApplyResources(this.pictureBox9, "pictureBox9");
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.TabStop = false;
		resources.ApplyResources(this.chkScaleFunctionality, "chkScaleFunctionality");
		((System.Windows.Forms.Control)(object)this.chkScaleFunctionality).Name = "chkScaleFunctionality";
		((System.Windows.Forms.Control)(object)this.chkScaleFunctionality).Tag = "scale_functionality";
		this.chkScaleFunctionality.set_ThumbTickness(27);
		this.chkScaleFunctionality.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkScaleFunctionality).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label6, "label6");
		this.label6.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label6.Name = "label6";
		this.label6.Tag = "";
		this.label13.BackColor = System.Drawing.Color.Transparent;
		this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		resources.ApplyResources(this.lblScaleComPortDesc, "lblScaleComPortDesc");
		this.lblScaleComPortDesc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblScaleComPortDesc.Name = "lblScaleComPortDesc";
		this.lblScaleComPortDesc.Tag = "";
		this.lblScaleComPortTitle.BackColor = System.Drawing.Color.Transparent;
		this.lblScaleComPortTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.lblScaleComPortTitle, "lblScaleComPortTitle");
		this.lblScaleComPortTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblScaleComPortTitle.Name = "lblScaleComPortTitle";
		resources.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		this.ddlScaleMake.BackColor = System.Drawing.Color.White;
		this.ddlScaleMake.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlScaleMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlScaleMake, "ddlScaleMake");
		this.ddlScaleMake.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlScaleMake.FormattingEnabled = true;
		this.ddlScaleMake.Name = "ddlScaleMake";
		this.ddlScaleMake.Tag = "scale_make";
		this.ddlScaleMake.SelectedIndexChanged += new System.EventHandler(ddlScaleMake_SelectedIndexChanged);
		this.class19_0.BackColor = System.Drawing.Color.White;
		this.class19_0.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.class19_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.class19_0, "ddlScaleUOM");
		this.class19_0.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.class19_0.FormattingEnabled = true;
		this.class19_0.Items.AddRange(new object[3]
		{
			resources.GetString("ddlScaleUOM.Items"),
			resources.GetString("ddlScaleUOM.Items1"),
			resources.GetString("ddlScaleUOM.Items2")
		});
		this.class19_0.Name = "ddlScaleUOM";
		this.class19_0.Tag = "scale_uom";
		this.class19_0.SelectedIndexChanged += new System.EventHandler(class19_0_SelectedIndexChanged);
		this.ddlSecondaryLanguage.BackColor = System.Drawing.Color.White;
		this.ddlSecondaryLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlSecondaryLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlSecondaryLanguage, "ddlSecondaryLanguage");
		this.ddlSecondaryLanguage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlSecondaryLanguage.FormattingEnabled = true;
		this.ddlSecondaryLanguage.Name = "ddlSecondaryLanguage";
		this.ddlSecondaryLanguage.Tag = "secondary_language";
		this.ddlSecondaryLanguage.SelectedIndexChanged += new System.EventHandler(ddlSecondaryLanguage_SelectedIndexChanged);
		this.ddlPrimaryLanguage.BackColor = System.Drawing.Color.White;
		this.ddlPrimaryLanguage.DisplayMember = "en-US,fr-CA";
		this.ddlPrimaryLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlPrimaryLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlPrimaryLanguage, "ddlPrimaryLanguage");
		this.ddlPrimaryLanguage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlPrimaryLanguage.FormattingEnabled = true;
		this.ddlPrimaryLanguage.Name = "ddlPrimaryLanguage";
		this.ddlPrimaryLanguage.Tag = "primary_language";
		this.ddlPrimaryLanguage.ValueMember = "en-US,fr-CA";
		this.ddlPrimaryLanguage.SelectedIndexChanged += new System.EventHandler(ddlPrimaryLanguage_SelectedIndexChanged);
		this.ddlScaleCOMPort.BackColor = System.Drawing.Color.White;
		this.ddlScaleCOMPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlScaleCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlScaleCOMPort, "ddlScaleCOMPort");
		this.ddlScaleCOMPort.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlScaleCOMPort.FormattingEnabled = true;
		this.ddlScaleCOMPort.Name = "ddlScaleCOMPort";
		this.ddlScaleCOMPort.Tag = "";
		this.ddlScaleCOMPort.SelectedIndexChanged += new System.EventHandler(ddlScaleCOMPort_SelectedIndexChanged);
		resources.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		resources.ApplyResources(this.chkCoinSystem, "chkCoinSystem");
		((System.Windows.Forms.Control)(object)this.chkCoinSystem).Name = "chkCoinSystem";
		((System.Windows.Forms.Control)(object)this.chkCoinSystem).Tag = "coin_system";
		this.chkCoinSystem.set_ThumbTickness(27);
		this.chkCoinSystem.set_ToggleStateMode((ToggleStateMode)1);
		this.chkCoinSystem.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkCoinSystem).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkCoinSystem).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkCoinSystem).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCoinSystem).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCoinSystem).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCoinSystem).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkCoinSystem).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		this.label14.Tag = "";
		this.label15.BackColor = System.Drawing.Color.Transparent;
		this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label15, "label15");
		this.label15.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label15.Name = "label15";
		this.lblDeliveryManage.BackColor = System.Drawing.Color.Transparent;
		this.lblDeliveryManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.lblDeliveryManage, "lblDeliveryManage");
		this.lblDeliveryManage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblDeliveryManage.Name = "lblDeliveryManage";
		resources.ApplyResources(this.lblDescDeliveryManage, "lblDescDeliveryManage");
		this.lblDescDeliveryManage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblDescDeliveryManage.Name = "lblDescDeliveryManage";
		this.lblDescDeliveryManage.Tag = "";
		resources.ApplyResources(this.chkDeliveryManagement, "chkDeliveryManagement");
		((System.Windows.Forms.Control)(object)this.chkDeliveryManagement).Name = "chkDeliveryManagement";
		((System.Windows.Forms.Control)(object)this.chkDeliveryManagement).Tag = "delivery_management";
		this.chkDeliveryManagement.set_ThumbTickness(27);
		this.chkDeliveryManagement.set_ToggleStateMode((ToggleStateMode)1);
		this.chkDeliveryManagement.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkDeliveryManagement).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.picDeliveryManage, "picDeliveryManage");
		this.picDeliveryManage.Name = "picDeliveryManage";
		this.picDeliveryManage.TabStop = false;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.pictureBox11);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkCoinSystem);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.ddlScaleMake);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.lblTestScale);
		base.Controls.Add(this.class19_0);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.pictureBox9);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkScaleFunctionality);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.ddlScaleCOMPort);
		base.Controls.Add(this.lblScaleComPortDesc);
		base.Controls.Add(this.lblScaleComPortTitle);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.lblKioskSettings);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.picDeliveryManage);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkDeliveryManagement);
		base.Controls.Add(this.lblDescDeliveryManage);
		base.Controls.Add(this.lblDeliveryManage);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkPrintPayout);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkPayout);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.ddlSecondaryLanguage);
		base.Controls.Add(this.ddlPrimaryLanguage);
		base.Controls.Add(this.label_secondaryLanguage_desc);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label_secondaryLanguage_title);
		base.Controls.Add(this.label_primaryLanguage_desc);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label_primaryLanguage_title);
		base.Controls.Add(this.pictureBox17);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkCapacity);
		base.Controls.Add(this.label_capacity_desc);
		base.Controls.Add(this.label_capacity_title);
		base.Controls.Add(this.lblEmailSettings);
		base.Controls.Add(this.label_emailSettings_title);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.label_emailSettings_desc);
		base.Name = "MiscSettings";
		resources.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkCapacity).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPayout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintPayout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkScaleFunctionality).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkCoinSystem).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkDeliveryManagement).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDeliveryManage).EndInit();
		base.ResumeLayout(false);
	}
}
