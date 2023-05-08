using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.AdminPanel.Settings.OrderEntry;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class OrderEntrySettings : UserControl
{
	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Label lblAddImageSecondScreen;

	private Label label_secondScreen_desc;

	private PictureBox pictureBox12;

	private RadToggleSwitch chkSecondScreen;

	private Label label_secondScreen_title;

	private Label label_nowserving_desc;

	private PictureBox pictureBox10;

	private RadToggleSwitch chkNowServingKitchen;

	private Label label_nowserving_title;

	private Label label_stackoptions_desc;

	private RadToggleSwitch chkStackOptions;

	private Label label_stackoptions_title;

	private PictureBox pictureBox17;

	private PictureBox pictureBox18;

	private Label label_promptoption_desc;

	private RadToggleSwitch chkPromptChildOptions;

	private Label label_promptoption_title;

	private PictureBox pictureBox19;

	private Label label_addsolooptionprice_;

	private RadToggleSwitch chkAddSoloOptionMain;

	private Label label_addsolooptionprice_title;

	private PictureBox pictureBox22;

	private Label label_showitemprices_desc;

	private RadToggleSwitch chkShowItemPrice;

	private Label label_showitemprices_title;

	private Label label6;

	private PictureBox pictureBox6;

	private Label label_tipkitchen_desc;

	private Label label_tipkitchen_title;

	private Label lblTipSharing;

	private PictureBox pictureBox3;

	private Label label4;

	private RadToggleSwitch chkShowInstructions;

	private Label label5;

	private PictureBox pictureBox2;

	private Label label1;

	private RadToggleSwitch chkComboPotential;

	private Label label3;

	private PictureBox pictureBox7;

	private Label label9;

	private Label label10;

	private Label label11;

	private PictureBox pictureBox1;

	private Label label2;

	private RadToggleSwitch chkCustomDiscount;

	private Label label7;

	public OrderEntrySettings()
	{
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
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
			else if (!control.Name.Contains("lbl") && !control.Name.Contains("pictureBox") && !control.Name.Contains("label"))
			{
				list.Add(control);
			}
		}
		using (List<Control>.Enumerator enumerator3 = list.GetEnumerator())
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
					CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
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
				((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement().add_ValueChanged((EventHandler)method_1);
				((RadElement)((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement()).set_Tag(((Control)(RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag);
			}
		}
		bool_0 = false;
	}

	private void chkSecondScreen_Click(object sender, EventArgs e)
	{
	}

	private void lblAddImageSecondScreen_Click(object sender, EventArgs e)
	{
		new frmVideoUploader().Show(this);
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void method_1(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.chkToggle = (RadToggleSwitchElement)((sender is RadToggleSwitchElement) ? sender : null);
		Setting setting = iqueryable_0.Where((Setting s) => ((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
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
		if (!(((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().ToString() == ((Control)(object)chkSecondScreen).Tag.ToString()) && !(((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().ToString() == ((Control)(object)chkAddSoloOptionMain).Tag.ToString()))
		{
			return;
		}
		if (((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().ToString() == ((Control)(object)chkAddSoloOptionMain).Tag.ToString())
		{
			foreach (Terminal item in gclass6_0.Terminals.Where((Terminal x) => x.LastCheckedIn > DateTime.Now.AddMonths(-1) && x.SystemName != Environment.MachineName).ToList())
			{
				item.AppRestartRequired = true;
			}
			gclass6_0.SubmitChanges();
		}
		if (new frmMessageBox(Resources.Hippos_needs_to_be_restarted_f, Resources.Settings_changed, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			FormHelper.CleanupObjects();
			Application.Restart();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Kitchen Tip %", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Breakage Tip %", 2, 6, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void lblTipSharing_Click(object sender, EventArgs e)
	{
		new frmCustomTipSharing().ShowDialog();
	}

	private void label11_Click(object sender, EventArgs e)
	{
		new frmDeliveryFeeSettings().Show();
	}

	private void chkAddSoloOptionMain_ValueChanged(object sender, EventArgs e)
	{
	}

	private void chkSecondScreen_ValueChanged(object sender, EventArgs e)
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_0880: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Unknown result type (might be due to invalid IL or missing references)
		//IL_128c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Unknown result type (might be due to invalid IL or missing references)
		//IL_1307: Unknown result type (might be due to invalid IL or missing references)
		//IL_1334: Unknown result type (might be due to invalid IL or missing references)
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Unknown result type (might be due to invalid IL or missing references)
		//IL_154f: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_181f: Unknown result type (might be due to invalid IL or missing references)
		//IL_184c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1879: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.OrderEntrySettings));
		this.lblAddImageSecondScreen = new System.Windows.Forms.Label();
		this.label_secondScreen_desc = new System.Windows.Forms.Label();
		this.pictureBox12 = new System.Windows.Forms.PictureBox();
		this.chkSecondScreen = new RadToggleSwitch();
		this.label_secondScreen_title = new System.Windows.Forms.Label();
		this.label_nowserving_desc = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.chkNowServingKitchen = new RadToggleSwitch();
		this.label_nowserving_title = new System.Windows.Forms.Label();
		this.label_stackoptions_desc = new System.Windows.Forms.Label();
		this.chkStackOptions = new RadToggleSwitch();
		this.label_stackoptions_title = new System.Windows.Forms.Label();
		this.pictureBox17 = new System.Windows.Forms.PictureBox();
		this.pictureBox18 = new System.Windows.Forms.PictureBox();
		this.label_promptoption_desc = new System.Windows.Forms.Label();
		this.chkPromptChildOptions = new RadToggleSwitch();
		this.label_promptoption_title = new System.Windows.Forms.Label();
		this.pictureBox19 = new System.Windows.Forms.PictureBox();
		this.label_addsolooptionprice_ = new System.Windows.Forms.Label();
		this.chkAddSoloOptionMain = new RadToggleSwitch();
		this.label_addsolooptionprice_title = new System.Windows.Forms.Label();
		this.pictureBox22 = new System.Windows.Forms.PictureBox();
		this.label_showitemprices_desc = new System.Windows.Forms.Label();
		this.chkShowItemPrice = new RadToggleSwitch();
		this.label_showitemprices_title = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label_tipkitchen_desc = new System.Windows.Forms.Label();
		this.label_tipkitchen_title = new System.Windows.Forms.Label();
		this.lblTipSharing = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.label4 = new System.Windows.Forms.Label();
		this.chkShowInstructions = new RadToggleSwitch();
		this.label5 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.chkComboPotential = new RadToggleSwitch();
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.chkCustomDiscount = new RadToggleSwitch();
		this.label7 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkSecondScreen).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkNowServingKitchen).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkStackOptions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPromptChildOptions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAddSoloOptionMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox22).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowItemPrice).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowInstructions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkComboPotential).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkCustomDiscount).BeginInit();
		base.SuspendLayout();
		this.lblAddImageSecondScreen.BackColor = System.Drawing.Color.Transparent;
		componentResourceManager.ApplyResources(this.lblAddImageSecondScreen, "lblAddImageSecondScreen");
		this.lblAddImageSecondScreen.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblAddImageSecondScreen.Name = "lblAddImageSecondScreen";
		this.lblAddImageSecondScreen.Click += new System.EventHandler(lblAddImageSecondScreen_Click);
		componentResourceManager.ApplyResources(this.label_secondScreen_desc, "label_secondScreen_desc");
		this.label_secondScreen_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_secondScreen_desc.Name = "label_secondScreen_desc";
		this.label_secondScreen_desc.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox12, "pictureBox12");
		this.pictureBox12.Name = "pictureBox12";
		this.pictureBox12.TabStop = false;
		componentResourceManager.ApplyResources(this.chkSecondScreen, "chkSecondScreen");
		((System.Windows.Forms.Control)(object)this.chkSecondScreen).Name = "chkSecondScreen";
		((System.Windows.Forms.Control)(object)this.chkSecondScreen).Tag = "second_screen";
		this.chkSecondScreen.set_ThumbTickness(27);
		this.chkSecondScreen.set_ToggleStateMode((ToggleStateMode)1);
		this.chkSecondScreen.set_Value(false);
		this.chkSecondScreen.add_ValueChanged(new System.EventHandler(chkSecondScreen_ValueChanged));
		((System.Windows.Forms.Control)(object)this.chkSecondScreen).Click += new System.EventHandler(chkSecondScreen_Click);
		((RadToggleSwitchElement)((RadControl)this.chkSecondScreen).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkSecondScreen).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkSecondScreen).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSecondScreen).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSecondScreen).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkSecondScreen).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkSecondScreen).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_secondScreen_title.BackColor = System.Drawing.Color.Transparent;
		this.label_secondScreen_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_secondScreen_title, "label_secondScreen_title");
		this.label_secondScreen_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_secondScreen_title.Name = "label_secondScreen_title";
		componentResourceManager.ApplyResources(this.label_nowserving_desc, "label_nowserving_desc");
		this.label_nowserving_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_nowserving_desc.Name = "label_nowserving_desc";
		this.label_nowserving_desc.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		componentResourceManager.ApplyResources(this.chkNowServingKitchen, "chkNowServingKitchen");
		((System.Windows.Forms.Control)(object)this.chkNowServingKitchen).Name = "chkNowServingKitchen";
		((System.Windows.Forms.Control)(object)this.chkNowServingKitchen).Tag = "now_serving_screen";
		this.chkNowServingKitchen.set_ThumbTickness(27);
		this.chkNowServingKitchen.set_ToggleStateMode((ToggleStateMode)1);
		this.chkNowServingKitchen.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkNowServingKitchen).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_nowserving_title.BackColor = System.Drawing.Color.Transparent;
		this.label_nowserving_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_nowserving_title, "label_nowserving_title");
		this.label_nowserving_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_nowserving_title.Name = "label_nowserving_title";
		componentResourceManager.ApplyResources(this.label_stackoptions_desc, "label_stackoptions_desc");
		this.label_stackoptions_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_stackoptions_desc.Name = "label_stackoptions_desc";
		this.label_stackoptions_desc.Tag = "";
		componentResourceManager.ApplyResources(this.chkStackOptions, "chkStackOptions");
		((System.Windows.Forms.Control)(object)this.chkStackOptions).Name = "chkStackOptions";
		((System.Windows.Forms.Control)(object)this.chkStackOptions).Tag = "stack_options";
		this.chkStackOptions.set_ThumbTickness(27);
		this.chkStackOptions.set_ToggleStateMode((ToggleStateMode)1);
		this.chkStackOptions.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkStackOptions).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkStackOptions).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkStackOptions).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkStackOptions).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkStackOptions).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkStackOptions).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkStackOptions).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_stackoptions_title.BackColor = System.Drawing.Color.Transparent;
		this.label_stackoptions_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_stackoptions_title, "label_stackoptions_title");
		this.label_stackoptions_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_stackoptions_title.Name = "label_stackoptions_title";
		componentResourceManager.ApplyResources(this.pictureBox17, "pictureBox17");
		this.pictureBox17.Name = "pictureBox17";
		this.pictureBox17.TabStop = false;
		componentResourceManager.ApplyResources(this.pictureBox18, "pictureBox18");
		this.pictureBox18.Name = "pictureBox18";
		this.pictureBox18.TabStop = false;
		componentResourceManager.ApplyResources(this.label_promptoption_desc, "label_promptoption_desc");
		this.label_promptoption_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_promptoption_desc.Name = "label_promptoption_desc";
		this.label_promptoption_desc.Tag = "";
		componentResourceManager.ApplyResources(this.chkPromptChildOptions, "chkPromptChildOptions");
		((System.Windows.Forms.Control)(object)this.chkPromptChildOptions).Name = "chkPromptChildOptions";
		((System.Windows.Forms.Control)(object)this.chkPromptChildOptions).Tag = "prompt_option_child_item";
		this.chkPromptChildOptions.set_ThumbTickness(27);
		this.chkPromptChildOptions.set_ToggleStateMode((ToggleStateMode)1);
		this.chkPromptChildOptions.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPromptChildOptions).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_promptoption_title.BackColor = System.Drawing.Color.Transparent;
		this.label_promptoption_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_promptoption_title, "label_promptoption_title");
		this.label_promptoption_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_promptoption_title.Name = "label_promptoption_title";
		componentResourceManager.ApplyResources(this.pictureBox19, "pictureBox19");
		this.pictureBox19.Name = "pictureBox19";
		this.pictureBox19.TabStop = false;
		componentResourceManager.ApplyResources(this.label_addsolooptionprice_, "label_addsolooptionprice_");
		this.label_addsolooptionprice_.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_addsolooptionprice_.Name = "label_addsolooptionprice_";
		this.label_addsolooptionprice_.Tag = "";
		componentResourceManager.ApplyResources(this.chkAddSoloOptionMain, "chkAddSoloOptionMain");
		((System.Windows.Forms.Control)(object)this.chkAddSoloOptionMain).Name = "chkAddSoloOptionMain";
		((System.Windows.Forms.Control)(object)this.chkAddSoloOptionMain).Tag = "add_solo_option_main";
		this.chkAddSoloOptionMain.set_ThumbTickness(27);
		this.chkAddSoloOptionMain.set_ToggleStateMode((ToggleStateMode)1);
		this.chkAddSoloOptionMain.set_Value(false);
		this.chkAddSoloOptionMain.add_ValueChanged(new System.EventHandler(chkAddSoloOptionMain_ValueChanged));
		((RadToggleSwitchElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkAddSoloOptionMain).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_addsolooptionprice_title.BackColor = System.Drawing.Color.Transparent;
		this.label_addsolooptionprice_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_addsolooptionprice_title, "label_addsolooptionprice_title");
		this.label_addsolooptionprice_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_addsolooptionprice_title.Name = "label_addsolooptionprice_title";
		componentResourceManager.ApplyResources(this.pictureBox22, "pictureBox22");
		this.pictureBox22.Name = "pictureBox22";
		this.pictureBox22.TabStop = false;
		componentResourceManager.ApplyResources(this.label_showitemprices_desc, "label_showitemprices_desc");
		this.label_showitemprices_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showitemprices_desc.Name = "label_showitemprices_desc";
		this.label_showitemprices_desc.Tag = "";
		componentResourceManager.ApplyResources(this.chkShowItemPrice, "chkShowItemPrice");
		((System.Windows.Forms.Control)(object)this.chkShowItemPrice).Name = "chkShowItemPrice";
		((System.Windows.Forms.Control)(object)this.chkShowItemPrice).Tag = "item_button_price";
		this.chkShowItemPrice.set_ThumbTickness(27);
		this.chkShowItemPrice.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowItemPrice.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowItemPrice).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowItemPrice).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowItemPrice).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowItemPrice).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowItemPrice).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowItemPrice).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowItemPrice).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_showitemprices_title.BackColor = System.Drawing.Color.Transparent;
		this.label_showitemprices_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_showitemprices_title, "label_showitemprices_title");
		this.label_showitemprices_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_showitemprices_title.Name = "label_showitemprices_title";
		componentResourceManager.ApplyResources(this.label6, "label6");
		this.label6.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label6.ForeColor = System.Drawing.Color.White;
		this.label6.Name = "label6";
		componentResourceManager.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		componentResourceManager.ApplyResources(this.label_tipkitchen_desc, "label_tipkitchen_desc");
		this.label_tipkitchen_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tipkitchen_desc.Name = "label_tipkitchen_desc";
		this.label_tipkitchen_desc.Tag = "";
		this.label_tipkitchen_title.BackColor = System.Drawing.Color.Transparent;
		this.label_tipkitchen_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label_tipkitchen_title, "label_tipkitchen_title");
		this.label_tipkitchen_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tipkitchen_title.Name = "label_tipkitchen_title";
		componentResourceManager.ApplyResources(this.lblTipSharing, "lblTipSharing");
		this.lblTipSharing.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblTipSharing.Name = "lblTipSharing";
		this.lblTipSharing.Click += new System.EventHandler(lblTipSharing_Click);
		componentResourceManager.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		componentResourceManager.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		componentResourceManager.ApplyResources(this.chkShowInstructions, "chkShowInstructions");
		((System.Windows.Forms.Control)(object)this.chkShowInstructions).Name = "chkShowInstructions";
		((System.Windows.Forms.Control)(object)this.chkShowInstructions).Tag = "show_instruction_oe";
		this.chkShowInstructions.set_ThumbTickness(27);
		this.chkShowInstructions.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowInstructions.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowInstructions).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowInstructions).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowInstructions).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowInstructions).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowInstructions).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowInstructions).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowInstructions).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		componentResourceManager.ApplyResources(this.chkComboPotential, "chkComboPotential");
		((System.Windows.Forms.Control)(object)this.chkComboPotential).Name = "chkComboPotential";
		((System.Windows.Forms.Control)(object)this.chkComboPotential).Tag = "use_combo_potential";
		this.chkComboPotential.set_ThumbTickness(27);
		this.chkComboPotential.set_ToggleStateMode((ToggleStateMode)1);
		this.chkComboPotential.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkComboPotential).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkComboPotential).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkComboPotential).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkComboPotential).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkComboPotential).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkComboPotential).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkComboPotential).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		componentResourceManager.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		componentResourceManager.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		this.label9.Tag = "";
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		componentResourceManager.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
		this.label11.Name = "label11";
		this.label11.Click += new System.EventHandler(label11_Click);
		componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		this.label2.Tag = "";
		componentResourceManager.ApplyResources(this.chkCustomDiscount, "chkCustomDiscount");
		((System.Windows.Forms.Control)(object)this.chkCustomDiscount).Name = "chkCustomDiscount";
		((System.Windows.Forms.Control)(object)this.chkCustomDiscount).Tag = "enable_custom_discount";
		this.chkCustomDiscount.set_ThumbTickness(27);
		this.chkCustomDiscount.set_ToggleStateMode((ToggleStateMode)1);
		this.chkCustomDiscount.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkCustomDiscount).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkCustomDiscount).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkCustomDiscount).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCustomDiscount).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCustomDiscount).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCustomDiscount).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkCustomDiscount).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkCustomDiscount);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkComboPotential);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label4);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowInstructions);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.lblTipSharing);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.label_tipkitchen_desc);
		base.Controls.Add(this.label_tipkitchen_title);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.pictureBox22);
		base.Controls.Add(this.label_showitemprices_desc);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowItemPrice);
		base.Controls.Add(this.label_showitemprices_title);
		base.Controls.Add(this.pictureBox19);
		base.Controls.Add(this.label_addsolooptionprice_);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkAddSoloOptionMain);
		base.Controls.Add(this.label_addsolooptionprice_title);
		base.Controls.Add(this.pictureBox18);
		base.Controls.Add(this.label_promptoption_desc);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkPromptChildOptions);
		base.Controls.Add(this.label_promptoption_title);
		base.Controls.Add(this.pictureBox17);
		base.Controls.Add(this.label_stackoptions_desc);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkStackOptions);
		base.Controls.Add(this.label_stackoptions_title);
		base.Controls.Add(this.label_nowserving_desc);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkNowServingKitchen);
		base.Controls.Add(this.label_nowserving_title);
		base.Controls.Add(this.lblAddImageSecondScreen);
		base.Controls.Add(this.label_secondScreen_desc);
		base.Controls.Add(this.pictureBox12);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkSecondScreen);
		base.Controls.Add(this.label_secondScreen_title);
		base.Controls.Add(this.label11);
		base.Name = "OrderEntrySettings";
		componentResourceManager.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkSecondScreen).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkNowServingKitchen).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkStackOptions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPromptChildOptions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAddSoloOptionMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox22).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowItemPrice).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowInstructions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkComboPotential).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkCustomDiscount).EndInit();
		base.ResumeLayout(false);
	}
}
