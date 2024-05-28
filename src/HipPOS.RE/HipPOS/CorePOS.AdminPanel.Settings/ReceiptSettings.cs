using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.CommonForms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class ReceiptSettings : UserControl
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Control ctrl;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public RadToggleSwitchElement chkToggle;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Label lbl;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Label lblFooterMessage;

	private Label label11;

	private PictureBox yvnFfcZplnw;

	private Label label12;

	private RadToggleSwitch chkGratuityToReceipt;

	private Label odrFfTcaMnm;

	private Label label22;

	private PictureBox pictureBox11;

	private Class19 ddlReceiptLanguage;

	private Label label1;

	private PictureBox pictureBox3;

	private Label label6;

	private PictureBox pictureBox1;

	private Label label2;

	private Label label3;

	private Label btnUploadLogoReceipt;

	private RadToggleSwitch chkDisplayOptions;

	private Label label4;

	private Label label5;

	private PictureBox pictureBox2;

	private PictureBox pictureBox4;

	private RadToggleSwitch chkDisplayInstruction;

	private Label label7;

	private Label label8;

	private Class19 ddlReceiptSize;

	private Label label9;

	private PictureBox pictureBox7;

	private Label label13;

	private PictureBox pictureBox5;

	private RadToggleSwitch chkDisplayChildItems;

	private Label label10;

	private Label label14;

	private Label label16;

	private Label lblOrderTypeReceipt;

	private PictureBox pictureBox8;

	private Label label_tipkitchen_desc;

	private Label label_tipkitchen_title;

	private Class19 ddlFontSize;

	private Label label15;

	private PictureBox pictureBox9;

	private Label label17;

	public ReceiptSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		// base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		Dictionary<string, string> dataSource = new Dictionary<string, string>
		{
			{ "en-US", "English" },
			{ "fr-CA", "Français" },
			{ "es-US", "Español" }
		};
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
				else if (CS_0024_003C_003E8__locals0.ctrl.Name == "ddlReceiptLanguage")
				{
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).DataSource = new BindingSource(dataSource, null);
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).DisplayMember = "Value";
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).ValueMember = "Key";
					((ComboBox)CS_0024_003C_003E8__locals0.ctrl).SelectedValue = setting.Value;
				}
				else if (CS_0024_003C_003E8__locals0.ctrl.Name == "ddlFontSize")
				{
					if (setting.Value == "0")
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = "Small";
					}
					else if (setting.Value == "1")
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = "Medium";
					}
					else if (setting.Value == "2")
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = "Large";
					}
				}
				else if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl"))
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddlReceiptSize"))
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value + "mm";
					}
					else
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
					}
				}
				else
				{
					if (setting.Value.Contains("ON"))
					{
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = true;
					}
					else
					{
						((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = false;
					}
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.ValueChanged += method_0;
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.Tag = ((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag;
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

	private void lblFooterMessage_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals0.lbl = (Label)sender;
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.lbl.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
			MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_The_Receipt_Footer_Messa, 0, 1024, setting.Value, multiline: true);
			if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
			{
				setting.Value = MemoryLoadedObjects.Keyboard.textEntered;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.lbl.Tag.ToString(), setting.Value);
			}
		}
	}

	private void ddlReceiptLanguage_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlReceiptLanguage.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlReceiptLanguage.SelectedValue.ToString();
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlReceiptLanguage.Tag.ToString(), setting.Value);
			}
		}
	}

	private void btnUploadLogoReceipt_Click(object sender, EventArgs e)
	{
		new frmPhotoSelector("receipt_logo").Show(this);
	}

	private void ddlReceiptSize_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Setting setting = iqueryable_0.Where((Setting s) => ddlReceiptSize.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				setting.Value = ddlReceiptSize.Text.Replace("mm", string.Empty);
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey(ddlReceiptSize.Tag.ToString(), setting.Value);
			}
		}
	}

	private void lblOrderTypeReceipt_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => s.Key.ToUpper() == "order_type_receipt".ToUpper()).FirstOrDefault();
		if (setting != null)
		{
			string value = setting.Value;
			Dictionary<string, string> orderTypes = OrderTypesDictionary.OrderTypes;
			frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SET ORDER TYPES TO PRINT IN RECEIPT", orderTypes, value, 1);
			if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
			{
				value = frmChecklistSelector.returnValue;
				setting.Value = value;
				Helper.SubmitChangesWithCatch(gclass6_0);
				SettingsHelper.SetSettingValueByKey("order_type_receipt", setting.Value);
				new NotificationLabel(base.ParentForm, "Order Types Successfully Saved.", NotificationTypes.Success).Show();
			}
		}
	}

	private void ddlFontSize_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ddlFontSize.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (ddlFontSize.Text == "Small")
			{
				setting.Value = "0";
			}
			else if (ddlFontSize.Text == "Medium")
			{
				setting.Value = "1";
			}
			else if (ddlFontSize.Text == "Large")
			{
				setting.Value = "2";
			}
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(ddlFontSize.Tag.ToString(), setting.Value);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.ReceiptSettings));
		this.lblFooterMessage = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.yvnFfcZplnw = new System.Windows.Forms.PictureBox();
		this.label12 = new System.Windows.Forms.Label();
		this.chkGratuityToReceipt = new Telerik.WinControls.UI.RadToggleSwitch();
		this.odrFfTcaMnm = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.btnUploadLogoReceipt = new System.Windows.Forms.Label();
		this.chkDisplayOptions = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.chkDisplayInstruction = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label13 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.chkDisplayChildItems = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label10 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.lblOrderTypeReceipt = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label_tipkitchen_desc = new System.Windows.Forms.Label();
		this.label_tipkitchen_title = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.label17 = new System.Windows.Forms.Label();
		this.ddlFontSize = new Class19();
		this.ddlReceiptSize = new Class19();
		this.ddlReceiptLanguage = new Class19();
		((System.ComponentModel.ISupportInitialize)this.yvnFfcZplnw).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkGratuityToReceipt).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayOptions).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayInstruction).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayChildItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		base.SuspendLayout();
		resources.ApplyResources(this.lblFooterMessage, "lblFooterMessage");
		this.lblFooterMessage.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblFooterMessage.Name = "lblFooterMessage";
		this.lblFooterMessage.Tag = "receipt_footer_message";
		this.lblFooterMessage.Click += new System.EventHandler(lblFooterMessage_Click);
		this.label11.BackColor = System.Drawing.Color.Transparent;
		this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label11.Name = "label11";
		resources.ApplyResources(this.yvnFfcZplnw, "pictureBox6");
		this.yvnFfcZplnw.Name = "pictureBox6";
		this.yvnFfcZplnw.TabStop = false;
		resources.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		this.label12.Tag = "";
		resources.ApplyResources(this.chkGratuityToReceipt, "chkGratuityToReceipt");
		this.chkGratuityToReceipt.Name = "chkGratuityToReceipt";
		this.chkGratuityToReceipt.Tag = "print_gratuity_info";
		this.chkGratuityToReceipt.ThumbTickness = 27;
		this.chkGratuityToReceipt.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkGratuityToReceipt.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkGratuityToReceipt.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkGratuityToReceipt.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkGratuityToReceipt.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkGratuityToReceipt.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkGratuityToReceipt.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkGratuityToReceipt.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkGratuityToReceipt.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.odrFfTcaMnm, "label21");
		this.odrFfTcaMnm.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.odrFfTcaMnm.Name = "label21";
		this.odrFfTcaMnm.Tag = "";
		this.label22.BackColor = System.Drawing.Color.Transparent;
		this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label22, "label22");
		this.label22.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label22.Name = "label22";
		resources.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		resources.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		resources.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label6, "label6");
		this.label6.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label6.Name = "label6";
		resources.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		resources.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		this.label2.Tag = "";
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		resources.ApplyResources(this.btnUploadLogoReceipt, "btnUploadLogoReceipt");
		this.btnUploadLogoReceipt.ForeColor = System.Drawing.Color.RoyalBlue;
		this.btnUploadLogoReceipt.Name = "btnUploadLogoReceipt";
		this.btnUploadLogoReceipt.Tag = "receipt_footer_message";
		this.btnUploadLogoReceipt.Click += new System.EventHandler(btnUploadLogoReceipt_Click);
		resources.ApplyResources(this.chkDisplayOptions, "chkDisplayOptions");
		this.chkDisplayOptions.Name = "chkDisplayOptions";
		this.chkDisplayOptions.Tag = "display_option";
		this.chkDisplayOptions.ThumbTickness = 27;
		this.chkDisplayOptions.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkDisplayOptions.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayOptions.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayOptions.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayOptions.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayOptions.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayOptions.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayOptions.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayOptions.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.label4.Tag = "";
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		resources.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		resources.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		resources.ApplyResources(this.chkDisplayInstruction, "chkDisplayInstruction");
		this.chkDisplayInstruction.Name = "chkDisplayInstruction";
		this.chkDisplayInstruction.Tag = "display_instruction";
		this.chkDisplayInstruction.ThumbTickness = 27;
		this.chkDisplayInstruction.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkDisplayInstruction.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayInstruction.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayInstruction.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayInstruction.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayInstruction.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayInstruction.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayInstruction.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayInstruction.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		this.label7.Tag = "";
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		resources.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		this.label9.Tag = "";
		resources.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		this.label13.BackColor = System.Drawing.Color.Transparent;
		this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		resources.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		resources.ApplyResources(this.chkDisplayChildItems, "chkDisplayChildItems");
		this.chkDisplayChildItems.Name = "chkDisplayChildItems";
		this.chkDisplayChildItems.Tag = "receipt_display_child_items";
		this.chkDisplayChildItems.ThumbTickness = 27;
		this.chkDisplayChildItems.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkDisplayChildItems.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayChildItems.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayChildItems.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkDisplayChildItems.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayChildItems.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayChildItems.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayChildItems.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkDisplayChildItems.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		resources.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		this.label10.Tag = "";
		this.label14.BackColor = System.Drawing.Color.Transparent;
		this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		resources.ApplyResources(this.label16, "label16");
		this.label16.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label16.ForeColor = System.Drawing.Color.White;
		this.label16.Name = "label16";
		resources.ApplyResources(this.lblOrderTypeReceipt, "lblOrderTypeReceipt");
		this.lblOrderTypeReceipt.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblOrderTypeReceipt.Name = "lblOrderTypeReceipt";
		this.lblOrderTypeReceipt.Click += new System.EventHandler(lblOrderTypeReceipt_Click);
		resources.ApplyResources(this.pictureBox8, "pictureBox8");
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.TabStop = false;
		resources.ApplyResources(this.label_tipkitchen_desc, "label_tipkitchen_desc");
		this.label_tipkitchen_desc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tipkitchen_desc.Name = "label_tipkitchen_desc";
		this.label_tipkitchen_desc.Tag = "";
		this.label_tipkitchen_title.BackColor = System.Drawing.Color.Transparent;
		this.label_tipkitchen_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label_tipkitchen_title, "label_tipkitchen_title");
		this.label_tipkitchen_title.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label_tipkitchen_title.Name = "label_tipkitchen_title";
		resources.ApplyResources(this.label15, "label15");
		this.label15.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label15.Name = "label15";
		this.label15.Tag = "";
		resources.ApplyResources(this.pictureBox9, "pictureBox9");
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.TabStop = false;
		this.label17.BackColor = System.Drawing.Color.Transparent;
		this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		resources.ApplyResources(this.label17, "label17");
		this.label17.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label17.Name = "label17";
		this.ddlFontSize.BackColor = System.Drawing.Color.White;
		this.ddlFontSize.DisplayMember = "en-US,fr-CA";
		this.ddlFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlFontSize, "ddlFontSize");
		this.ddlFontSize.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlFontSize.FormattingEnabled = true;
		this.ddlFontSize.Items.AddRange(new object[3]
		{
			resources.GetString("ddlFontSize.Items"),
			resources.GetString("ddlFontSize.Items1"),
			resources.GetString("ddlFontSize.Items2")
		});
		this.ddlFontSize.Name = "ddlFontSize";
		this.ddlFontSize.Tag = "receipt_font_size_additional";
		this.ddlFontSize.ValueMember = "en-US,fr-CA";
		this.ddlFontSize.SelectedIndexChanged += new System.EventHandler(ddlFontSize_SelectedIndexChanged);
		this.ddlReceiptSize.BackColor = System.Drawing.Color.White;
		this.ddlReceiptSize.DisplayMember = "en-US,fr-CA";
		this.ddlReceiptSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlReceiptSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlReceiptSize, "ddlReceiptSize");
		this.ddlReceiptSize.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlReceiptSize.FormattingEnabled = true;
		this.ddlReceiptSize.Items.AddRange(new object[2]
		{
			resources.GetString("ddlReceiptSize.Items"),
			resources.GetString("ddlReceiptSize.Items1")
		});
		this.ddlReceiptSize.Name = "ddlReceiptSize";
		this.ddlReceiptSize.Tag = "receipt_size";
		this.ddlReceiptSize.ValueMember = "en-US,fr-CA";
		this.ddlReceiptSize.SelectedIndexChanged += new System.EventHandler(ddlReceiptSize_SelectedIndexChanged);
		this.ddlReceiptLanguage.BackColor = System.Drawing.Color.White;
		this.ddlReceiptLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlReceiptLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		resources.ApplyResources(this.ddlReceiptLanguage, "ddlReceiptLanguage");
		this.ddlReceiptLanguage.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlReceiptLanguage.FormattingEnabled = true;
		this.ddlReceiptLanguage.Name = "ddlReceiptLanguage";
		this.ddlReceiptLanguage.Tag = "receipt_language";
		this.ddlReceiptLanguage.SelectedIndexChanged += new System.EventHandler(ddlReceiptLanguage_SelectedIndexChanged);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.ddlFontSize);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.pictureBox9);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.lblOrderTypeReceipt);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.label_tipkitchen_desc);
		base.Controls.Add(this.label_tipkitchen_title);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.chkDisplayChildItems);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.ddlReceiptSize);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.chkDisplayInstruction);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.chkDisplayOptions);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.btnUploadLogoReceipt);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.ddlReceiptLanguage);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.chkGratuityToReceipt);
		base.Controls.Add(this.odrFfTcaMnm);
		base.Controls.Add(this.label22);
		base.Controls.Add(this.pictureBox11);
		base.Controls.Add(this.lblFooterMessage);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.yvnFfcZplnw);
		base.Controls.Add(this.label12);
		base.Name = "ReceiptSettings";
		resources.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.yvnFfcZplnw).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkGratuityToReceipt).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayOptions).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayInstruction).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkDisplayChildItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		base.ResumeLayout(false);
	}
}
