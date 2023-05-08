using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CommonForms;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class StyleSettings : UserControl
{
	private GClass6 gclass6_0;

	private List<Setting> list_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Label lblItemsGroupFontSetting;

	private Label label_font_oe_desc;

	private PictureBox pictureBox20;

	private Label label_font_oe_title;

	private PictureBox pictureBox7;

	private Label label_placeholder_desc;

	private RadToggleSwitch chkShowPlaceholder;

	private Label label_placeholder_title;

	private Label label_itempaging_desc;

	private PictureBox pictureBox5;

	private RadToggleSwitch chkItemPaging;

	private Label label_itempaging_title;

	private Label label_grouppaging_desc;

	private PictureBox pictureBox4;

	private RadToggleSwitch chkGroupPaging;

	private Label label_grouppaging_title;

	private Class19 ddlGroups_Rows;

	private Label label9;

	private Class19 ddlGroups_Columns;

	private Label label_groupgrid_desc;

	private PictureBox pictureBox3;

	private Label label_groupgrid_title;

	private Label label12;

	private Label label13;

	private Class19 ddlItems_Rows;

	private Label label7;

	private Class19 ddlItems_Columns;

	private Label label_itemgrid_desc;

	private PictureBox pictureBox2;

	private Label label_itemgrid_title;

	private Label label_itemimages_desc;

	private PictureBox pictureBox1;

	private RadToggleSwitch chkItemImages;

	private Label label_itemimages_title;

	private Label label8;

	private Label label19;

	private Label label16;

	private Label lblFontSecondScreen;

	private Label label2;

	private PictureBox pictureBox6;

	private Label label3;

	private Class19 ddlOptions_Rows;

	private Label label1;

	private Class19 ddlOptions_Columns;

	private Label label4;

	private Label label5;

	private Label label6;

	private PictureBox pictureBox8;

	private Label label10;

	private PictureBox pictureBox9;

	private Label label11;

	private RadToggleSwitch chkPlaceHolderOptions;

	private Label label14;

	private RadToggleSwitch chkCapitalizeText;

	private Label label15;

	private PictureBox pictureBox10;

	private Label label17;

	public StyleSettings()
	{
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		_003C_003Ec__DisplayClass3_0 cS_0024_003C_003E8__locals = new _003C_003Ec__DisplayClass3_0();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		list_0 = gclass6_0.Settings.ToList();
		IEnumerator enumerator = base.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_1();
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1 = cS_0024_003C_003E8__locals;
				CS_0024_003C_003E8__locals0.ctrl = (Control)enumerator.Current;
				if (CS_0024_003C_003E8__locals0.ctrl.Tag == null)
				{
					continue;
				}
				CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting = list_0.Where((Setting s) => CS_0024_003C_003E8__locals0.ctrl.Tag.Equals(s.Key)).FirstOrDefault();
				if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting == null)
				{
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.GetType().Name == "Label")
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("label"))
					{
						Invoke((MethodInvoker)delegate
						{
							CS_0024_003C_003E8__locals0.ctrl.Text = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting.Value;
						});
					}
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl"))
				{
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).Text = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting.Value.ToUpper();
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("txt"))
				{
					((Control)(RadTextBoxControl)CS_0024_003C_003E8__locals0.ctrl).Text = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting.Value;
					continue;
				}
				if (CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.setting.Value.Contains("ON"))
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(true);
				}
				else
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).set_Value(false);
				}
				((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement().add_ValueChanged((EventHandler)method_0);
				((RadElement)((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).get_ToggleSwitchElement()).set_Tag(((Control)(RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag);
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
		Setting setting = list_0.Where((Setting s) => ((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().Equals(s.Key)).FirstOrDefault();
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
			if (((RadElement)CS_0024_003C_003E8__locals0.chkToggle).get_Tag().ToString() == ((Control)(object)chkItemImages).Tag.ToString())
			{
				MemoryLoadedObjects.RefreshItemImages();
			}
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

	private void lblItemsGroupFontSetting_Click(object sender, EventArgs e)
	{
		if (list_0.Where((Setting s) => s.Key.ToUpper() == "font_size_item_groups_oe".ToUpper()).FirstOrDefault() != null)
		{
			new frmFont("items").ShowDialog(this);
		}
	}

	private void ddlItems_Columns_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlItems_Columns.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlItems_Columns.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlItems_Columns.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
			}
		}
	}

	private void ddlItems_Rows_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlItems_Rows.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlItems_Rows.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlItems_Rows.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
			}
		}
	}

	private void ddlGroups_Columns_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlGroups_Columns.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlGroups_Columns.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlGroups_Columns.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
			}
		}
	}

	private void ddlGroups_Rows_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlGroups_Rows.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlGroups_Rows.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlGroups_Rows.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OrderEntry = new frmOrderEntry(null, null, "Dine In", 1);
			}
		}
	}

	private void lblFontSecondScreen_Click(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting s) => s.Key.ToUpper() == "font_size_second_screen".ToUpper()).FirstOrDefault();
			if (setting != null)
			{
				frmFontSize frmFontSize = new frmFontSize(Convert.ToInt16(setting.Value));
				frmFontSize.ShowDialog();
				setting.Value = frmFontSize.FontSize.ToString();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey("font_size_second_screen", frmFontSize.FontSize.ToString());
			}
		}
	}

	private void ddlOptions_Columns_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlOptions_Columns.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlOptions_Columns.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlOptions_Columns.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OptionScreen = new frmOptions();
			}
		}
	}

	private void ddlOptions_Rows_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = list_0.Where((Setting setting_0) => ddlOptions_Rows.Tag.Equals(setting_0.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlOptions_Rows.Text;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlOptions_Rows.Tag.ToString(), setting.Value);
				MemoryLoadedObjects.OptionScreen = new frmOptions();
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1294: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1311: Unknown result type (might be due to invalid IL or missing references)
		//IL_133e: Unknown result type (might be due to invalid IL or missing references)
		//IL_136b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9d: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.StyleSettings));
		this.lblItemsGroupFontSetting = new System.Windows.Forms.Label();
		this.label_font_oe_desc = new System.Windows.Forms.Label();
		this.pictureBox20 = new System.Windows.Forms.PictureBox();
		this.label_font_oe_title = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label_placeholder_desc = new System.Windows.Forms.Label();
		this.chkShowPlaceholder = new RadToggleSwitch();
		this.label_placeholder_title = new System.Windows.Forms.Label();
		this.label_itempaging_desc = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.chkItemPaging = new RadToggleSwitch();
		this.label_itempaging_title = new System.Windows.Forms.Label();
		this.label_grouppaging_desc = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.chkGroupPaging = new RadToggleSwitch();
		this.label_grouppaging_title = new System.Windows.Forms.Label();
		this.ddlGroups_Rows = new Class19();
		this.label9 = new System.Windows.Forms.Label();
		this.ddlGroups_Columns = new Class19();
		this.label_groupgrid_desc = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.label_groupgrid_title = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.ddlItems_Rows = new Class19();
		this.label7 = new System.Windows.Forms.Label();
		this.ddlItems_Columns = new Class19();
		this.label_itemgrid_desc = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label_itemgrid_title = new System.Windows.Forms.Label();
		this.label_itemimages_desc = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.chkItemImages = new RadToggleSwitch();
		this.label_itemimages_title = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.lblFontSecondScreen = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label3 = new System.Windows.Forms.Label();
		this.ddlOptions_Rows = new Class19();
		this.label1 = new System.Windows.Forms.Label();
		this.ddlOptions_Columns = new Class19();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label10 = new System.Windows.Forms.Label();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.label11 = new System.Windows.Forms.Label();
		this.chkPlaceHolderOptions = new RadToggleSwitch();
		this.label14 = new System.Windows.Forms.Label();
		this.chkCapitalizeText = new RadToggleSwitch();
		this.label15 = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.label17 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowPlaceholder).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemPaging).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkGroupPaging).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemImages).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPlaceHolderOptions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkCapitalizeText).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.lblItemsGroupFontSetting, "lblItemsGroupFontSetting");
		this.lblItemsGroupFontSetting.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblItemsGroupFontSetting.Name = "lblItemsGroupFontSetting";
		this.lblItemsGroupFontSetting.Click += new System.EventHandler(lblItemsGroupFontSetting_Click);
		resources.ApplyResources(this.label_font_oe_desc, "label_font_oe_desc");
		this.label_font_oe_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_font_oe_desc.Name = "label_font_oe_desc";
		this.label_font_oe_desc.Tag = "";
		resources.ApplyResources(this.pictureBox20, "pictureBox20");
		this.pictureBox20.Name = "pictureBox20";
		this.pictureBox20.TabStop = false;
		this.label_font_oe_title.BackColor = System.Drawing.Color.Transparent;
		this.label_font_oe_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_font_oe_title, "label_font_oe_title");
		this.label_font_oe_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_font_oe_title.Name = "label_font_oe_title";
		resources.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		resources.ApplyResources(this.label_placeholder_desc, "label_placeholder_desc");
		this.label_placeholder_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_placeholder_desc.Name = "label_placeholder_desc";
		this.label_placeholder_desc.Tag = "";
		resources.ApplyResources(this.chkShowPlaceholder, "chkShowPlaceholder");
		((System.Windows.Forms.Control)(object)this.chkShowPlaceholder).Name = "chkShowPlaceholder";
		((System.Windows.Forms.Control)(object)this.chkShowPlaceholder).Tag = "show_placeholder_buttons";
		this.chkShowPlaceholder.set_ThumbTickness(27);
		this.chkShowPlaceholder.set_ToggleStateMode((ToggleStateMode)1);
		this.chkShowPlaceholder.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkShowPlaceholder).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_placeholder_title.BackColor = System.Drawing.Color.Transparent;
		this.label_placeholder_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_placeholder_title, "label_placeholder_title");
		this.label_placeholder_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_placeholder_title.Name = "label_placeholder_title";
		resources.ApplyResources(this.label_itempaging_desc, "label_itempaging_desc");
		this.label_itempaging_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itempaging_desc.Name = "label_itempaging_desc";
		this.label_itempaging_desc.Tag = "";
		resources.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		resources.ApplyResources(this.chkItemPaging, "chkItemPaging");
		((System.Windows.Forms.Control)(object)this.chkItemPaging).Name = "chkItemPaging";
		((System.Windows.Forms.Control)(object)this.chkItemPaging).Tag = "items_paging";
		this.chkItemPaging.set_ThumbTickness(27);
		this.chkItemPaging.set_ToggleStateMode((ToggleStateMode)1);
		this.chkItemPaging.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkItemPaging).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkItemPaging).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkItemPaging).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemPaging).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemPaging).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemPaging).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkItemPaging).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_itempaging_title.BackColor = System.Drawing.Color.Transparent;
		this.label_itempaging_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_itempaging_title, "label_itempaging_title");
		this.label_itempaging_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itempaging_title.Name = "label_itempaging_title";
		resources.ApplyResources(this.label_grouppaging_desc, "label_grouppaging_desc");
		this.label_grouppaging_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_grouppaging_desc.Name = "label_grouppaging_desc";
		this.label_grouppaging_desc.Tag = "";
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.chkGroupPaging, "chkGroupPaging");
		((System.Windows.Forms.Control)(object)this.chkGroupPaging).Name = "chkGroupPaging";
		((System.Windows.Forms.Control)(object)this.chkGroupPaging).Tag = "groups_paging";
		this.chkGroupPaging.set_ThumbTickness(27);
		this.chkGroupPaging.set_ToggleStateMode((ToggleStateMode)1);
		this.chkGroupPaging.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkGroupPaging).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkGroupPaging).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkGroupPaging).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGroupPaging).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGroupPaging).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkGroupPaging).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkGroupPaging).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_grouppaging_title.BackColor = System.Drawing.Color.Transparent;
		this.label_grouppaging_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_grouppaging_title, "label_grouppaging_title");
		this.label_grouppaging_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_grouppaging_title.Name = "label_grouppaging_title";
		this.ddlGroups_Rows.BackColor = System.Drawing.Color.White;
		this.ddlGroups_Rows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlGroups_Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlGroups_Rows, "ddlGroups_Rows");
		this.ddlGroups_Rows.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlGroups_Rows.FormattingEnabled = true;
		this.ddlGroups_Rows.Items.AddRange(new object[9]
		{
			resources.GetString("ddlGroups_Rows.Items"),
			resources.GetString("ddlGroups_Rows.Items1"),
			resources.GetString("ddlGroups_Rows.Items2"),
			resources.GetString("ddlGroups_Rows.Items3"),
			resources.GetString("ddlGroups_Rows.Items4"),
			resources.GetString("ddlGroups_Rows.Items5"),
			resources.GetString("ddlGroups_Rows.Items6"),
			resources.GetString("ddlGroups_Rows.Items7"),
			resources.GetString("ddlGroups_Rows.Items8")
		});
		this.ddlGroups_Rows.Name = "ddlGroups_Rows";
		this.ddlGroups_Rows.Tag = "groups_number_of_rows";
		this.ddlGroups_Rows.SelectedIndexChanged += new System.EventHandler(ddlGroups_Rows_SelectedIndexChanged);
		resources.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		this.label9.Tag = "";
		this.ddlGroups_Columns.BackColor = System.Drawing.Color.White;
		this.ddlGroups_Columns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlGroups_Columns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlGroups_Columns, "ddlGroups_Columns");
		this.ddlGroups_Columns.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlGroups_Columns.FormattingEnabled = true;
		this.ddlGroups_Columns.Items.AddRange(new object[8]
		{
			resources.GetString("ddlGroups_Columns.Items"),
			resources.GetString("ddlGroups_Columns.Items1"),
			resources.GetString("ddlGroups_Columns.Items2"),
			resources.GetString("ddlGroups_Columns.Items3"),
			resources.GetString("ddlGroups_Columns.Items4"),
			resources.GetString("ddlGroups_Columns.Items5"),
			resources.GetString("ddlGroups_Columns.Items6"),
			resources.GetString("ddlGroups_Columns.Items7")
		});
		this.ddlGroups_Columns.Name = "ddlGroups_Columns";
		this.ddlGroups_Columns.Tag = "groups_number_of_columns";
		this.ddlGroups_Columns.SelectedIndexChanged += new System.EventHandler(ddlGroups_Columns_SelectedIndexChanged);
		resources.ApplyResources(this.label_groupgrid_desc, "label_groupgrid_desc");
		this.label_groupgrid_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_groupgrid_desc.Name = "label_groupgrid_desc";
		this.label_groupgrid_desc.Tag = "";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		this.label_groupgrid_title.BackColor = System.Drawing.Color.Transparent;
		this.label_groupgrid_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_groupgrid_title, "label_groupgrid_title");
		this.label_groupgrid_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_groupgrid_title.Name = "label_groupgrid_title";
		resources.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		this.label12.Tag = "";
		resources.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		this.label13.Tag = "";
		this.ddlItems_Rows.BackColor = System.Drawing.Color.White;
		this.ddlItems_Rows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlItems_Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlItems_Rows, "ddlItems_Rows");
		this.ddlItems_Rows.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlItems_Rows.FormattingEnabled = true;
		this.ddlItems_Rows.Items.AddRange(new object[8]
		{
			resources.GetString("ddlItems_Rows.Items"),
			resources.GetString("ddlItems_Rows.Items1"),
			resources.GetString("ddlItems_Rows.Items2"),
			resources.GetString("ddlItems_Rows.Items3"),
			resources.GetString("ddlItems_Rows.Items4"),
			resources.GetString("ddlItems_Rows.Items5"),
			resources.GetString("ddlItems_Rows.Items6"),
			resources.GetString("ddlItems_Rows.Items7")
		});
		this.ddlItems_Rows.Name = "ddlItems_Rows";
		this.ddlItems_Rows.Tag = "items_number_of_rows";
		this.ddlItems_Rows.SelectedIndexChanged += new System.EventHandler(ddlItems_Rows_SelectedIndexChanged);
		resources.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		this.label7.Tag = "";
		this.ddlItems_Columns.BackColor = System.Drawing.Color.White;
		this.ddlItems_Columns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlItems_Columns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlItems_Columns, "ddlItems_Columns");
		this.ddlItems_Columns.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlItems_Columns.FormattingEnabled = true;
		this.ddlItems_Columns.Items.AddRange(new object[8]
		{
			resources.GetString("ddlItems_Columns.Items"),
			resources.GetString("ddlItems_Columns.Items1"),
			resources.GetString("ddlItems_Columns.Items2"),
			resources.GetString("ddlItems_Columns.Items3"),
			resources.GetString("ddlItems_Columns.Items4"),
			resources.GetString("ddlItems_Columns.Items5"),
			resources.GetString("ddlItems_Columns.Items6"),
			resources.GetString("ddlItems_Columns.Items7")
		});
		this.ddlItems_Columns.Name = "ddlItems_Columns";
		this.ddlItems_Columns.Tag = "items_number_of_columns";
		this.ddlItems_Columns.SelectedIndexChanged += new System.EventHandler(ddlItems_Columns_SelectedIndexChanged);
		resources.ApplyResources(this.label_itemgrid_desc, "label_itemgrid_desc");
		this.label_itemgrid_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itemgrid_desc.Name = "label_itemgrid_desc";
		this.label_itemgrid_desc.Tag = "";
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		this.label_itemgrid_title.BackColor = System.Drawing.Color.Transparent;
		this.label_itemgrid_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_itemgrid_title, "label_itemgrid_title");
		this.label_itemgrid_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itemgrid_title.Name = "label_itemgrid_title";
		resources.ApplyResources(this.label_itemimages_desc, "label_itemimages_desc");
		this.label_itemimages_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itemimages_desc.Name = "label_itemimages_desc";
		this.label_itemimages_desc.Tag = "";
		resources.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		resources.ApplyResources(this.chkItemImages, "chkItemImages");
		((System.Windows.Forms.Control)(object)this.chkItemImages).Name = "chkItemImages";
		((System.Windows.Forms.Control)(object)this.chkItemImages).Tag = "item_images";
		this.chkItemImages.set_ThumbTickness(27);
		this.chkItemImages.set_ToggleStateMode((ToggleStateMode)1);
		this.chkItemImages.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkItemImages).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkItemImages).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkItemImages).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemImages).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemImages).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkItemImages).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkItemImages).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label_itemimages_title.BackColor = System.Drawing.Color.Transparent;
		this.label_itemimages_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_itemimages_title, "label_itemimages_title");
		this.label_itemimages_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_itemimages_title.Name = "label_itemimages_title";
		resources.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		this.label8.Tag = "";
		resources.ApplyResources(this.label19, "label19");
		this.label19.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label19.Name = "label19";
		this.label19.Tag = "";
		resources.ApplyResources(this.label16, "label16");
		this.label16.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label16.ForeColor = System.Drawing.Color.White;
		this.label16.Name = "label16";
		resources.ApplyResources(this.lblFontSecondScreen, "lblFontSecondScreen");
		this.lblFontSecondScreen.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblFontSecondScreen.Name = "lblFontSecondScreen";
		this.lblFontSecondScreen.Click += new System.EventHandler(lblFontSecondScreen_Click);
		resources.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		this.label2.Tag = "";
		resources.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		this.ddlOptions_Rows.BackColor = System.Drawing.Color.White;
		this.ddlOptions_Rows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlOptions_Rows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlOptions_Rows, "ddlOptions_Rows");
		this.ddlOptions_Rows.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlOptions_Rows.FormattingEnabled = true;
		this.ddlOptions_Rows.Items.AddRange(new object[6]
		{
			resources.GetString("ddlOptions_Rows.Items"),
			resources.GetString("ddlOptions_Rows.Items1"),
			resources.GetString("ddlOptions_Rows.Items2"),
			resources.GetString("ddlOptions_Rows.Items3"),
			resources.GetString("ddlOptions_Rows.Items4"),
			resources.GetString("ddlOptions_Rows.Items5")
		});
		this.ddlOptions_Rows.Name = "ddlOptions_Rows";
		this.ddlOptions_Rows.Tag = "options_number_of_rows";
		this.ddlOptions_Rows.SelectedIndexChanged += new System.EventHandler(ddlOptions_Rows_SelectedIndexChanged);
		resources.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		this.ddlOptions_Columns.BackColor = System.Drawing.Color.White;
		this.ddlOptions_Columns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlOptions_Columns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlOptions_Columns, "ddlOptions_Columns");
		this.ddlOptions_Columns.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlOptions_Columns.FormattingEnabled = true;
		this.ddlOptions_Columns.Items.AddRange(new object[5]
		{
			resources.GetString("ddlOptions_Columns.Items"),
			resources.GetString("ddlOptions_Columns.Items1"),
			resources.GetString("ddlOptions_Columns.Items2"),
			resources.GetString("ddlOptions_Columns.Items3"),
			resources.GetString("ddlOptions_Columns.Items4")
		});
		this.ddlOptions_Columns.Name = "ddlOptions_Columns";
		this.ddlOptions_Columns.Tag = "options_number_of_columns";
		this.ddlOptions_Columns.SelectedIndexChanged += new System.EventHandler(ddlOptions_Columns_SelectedIndexChanged);
		resources.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		resources.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		this.label5.Tag = "";
		resources.ApplyResources(this.label6, "label6");
		this.label6.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label6.Name = "label6";
		this.label6.Tag = "";
		resources.ApplyResources(this.pictureBox8, "pictureBox8");
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.TabStop = false;
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		resources.ApplyResources(this.pictureBox9, "pictureBox9");
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.TabStop = false;
		resources.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label11.Name = "label11";
		this.label11.Tag = "";
		resources.ApplyResources(this.chkPlaceHolderOptions, "chkPlaceHolderOptions");
		((System.Windows.Forms.Control)(object)this.chkPlaceHolderOptions).Name = "chkPlaceHolderOptions";
		((System.Windows.Forms.Control)(object)this.chkPlaceHolderOptions).Tag = "show_placeholder_options";
		this.chkPlaceHolderOptions.set_ThumbTickness(27);
		this.chkPlaceHolderOptions.set_ToggleStateMode((ToggleStateMode)1);
		this.chkPlaceHolderOptions.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkPlaceHolderOptions).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		this.label14.BackColor = System.Drawing.Color.Transparent;
		this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		resources.ApplyResources(this.chkCapitalizeText, "chkCapitalizeText");
		((System.Windows.Forms.Control)(object)this.chkCapitalizeText).Name = "chkCapitalizeText";
		((System.Windows.Forms.Control)(object)this.chkCapitalizeText).Tag = "capitalize_item_group_text";
		this.chkCapitalizeText.set_ThumbTickness(27);
		this.chkCapitalizeText.set_ToggleStateMode((ToggleStateMode)1);
		this.chkCapitalizeText.set_Value(false);
		((RadToggleSwitchElement)((RadControl)this.chkCapitalizeText).GetChildAt(0)).set_ThumbTickness(27);
		((RadToggleSwitchElement)((RadControl)this.chkCapitalizeText).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)this.chkCapitalizeText).GetChildAt(0)).set_BorderWidth(1.333333f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapitalizeText).GetChildAt(0).GetChildAt(0)).set_BackColor2(System.Drawing.Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapitalizeText).GetChildAt(0).GetChildAt(0)).set_BackColor3(System.Drawing.Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)this.chkCapitalizeText).GetChildAt(0).GetChildAt(0)).set_BackColor4(System.Drawing.Color.FromArgb(242, 182, 51));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)this.chkCapitalizeText).GetChildAt(0).GetChildAt(0)).set_BackColor(System.Drawing.Color.FromArgb(247, 192, 82));
		resources.ApplyResources(this.label15, "label15");
		this.label15.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label15.Name = "label15";
		this.label15.Tag = "";
		resources.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		this.label17.BackColor = System.Drawing.Color.Transparent;
		this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label17, "label17");
		this.label17.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label17.Name = "label17";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkCapitalizeText);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.pictureBox9);
		base.Controls.Add(this.label11);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkPlaceHolderOptions);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.ddlOptions_Rows);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.ddlOptions_Columns);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.lblFontSecondScreen);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.ddlGroups_Rows);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.ddlGroups_Columns);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.ddlItems_Rows);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.ddlItems_Columns);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label19);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.lblItemsGroupFontSetting);
		base.Controls.Add(this.label_font_oe_desc);
		base.Controls.Add(this.pictureBox20);
		base.Controls.Add(this.label_font_oe_title);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label_placeholder_desc);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkShowPlaceholder);
		base.Controls.Add(this.label_placeholder_title);
		base.Controls.Add(this.label_itempaging_desc);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkItemPaging);
		base.Controls.Add(this.label_itempaging_title);
		base.Controls.Add(this.label_grouppaging_desc);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkGroupPaging);
		base.Controls.Add(this.label_grouppaging_title);
		base.Controls.Add(this.label_groupgrid_desc);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label_groupgrid_title);
		base.Controls.Add(this.label_itemgrid_desc);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label_itemgrid_title);
		base.Controls.Add(this.label_itemimages_desc);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.chkItemImages);
		base.Controls.Add(this.label_itemimages_title);
		base.Name = "StyleSettings";
		resources.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkShowPlaceholder).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemPaging).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkGroupPaging).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkItemImages).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPlaceHolderOptions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkCapitalizeText).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private bool method_3(Setting setting_0)
	{
		return ddlItems_Columns.Tag.Equals(setting_0.Key);
	}

	[CompilerGenerated]
	private bool method_4(Setting setting_0)
	{
		return ddlItems_Rows.Tag.Equals(setting_0.Key);
	}

	[CompilerGenerated]
	private bool method_5(Setting setting_0)
	{
		return ddlGroups_Columns.Tag.Equals(setting_0.Key);
	}

	[CompilerGenerated]
	private bool method_6(Setting setting_0)
	{
		return ddlGroups_Rows.Tag.Equals(setting_0.Key);
	}

	[CompilerGenerated]
	private bool method_7(Setting setting_0)
	{
		return ddlOptions_Columns.Tag.Equals(setting_0.Key);
	}

	[CompilerGenerated]
	private bool method_8(Setting setting_0)
	{
		return ddlOptions_Rows.Tag.Equals(setting_0.Key);
	}
}
