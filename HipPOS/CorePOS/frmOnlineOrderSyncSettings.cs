using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmOnlineOrderSyncSettings : frmMasterForm
{
	private IContainer icontainer_1;

	private Label label5;

	private RadTextBoxControl txtApiKey;

	internal Button btnShowKeyboard_ApiKey;

	private Button ComglAgQy4;

	private Button btnSave;

	private Label label9;

	private Class19 ddlOnlineOrderProviders;

	private Label label1;

	private Label label3;

	private RadTextBoxControl txtUrl;

	internal Button btnShowKeyboard_Url;

	private Label label4;

	private Label label6;

	private RadToggleSwitch chkActive;

	private Class19 ddlInterval;

	private Label label7;

	public frmOnlineOrderSyncSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmOnlineOrderSyncSettings_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(OnlineOrderProviders.Hippos, OnlineOrderProviders.Hippos);
		dictionary.Add(OnlineOrderProviders.Moduurn, OnlineOrderProviders.Moduurn);
		ddlOnlineOrderProviders.DataSource = new BindingSource(dictionary, null);
		ddlOnlineOrderProviders.DisplayMember = "Value";
		ddlOnlineOrderProviders.ValueMember = "Key";
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		dictionary2.Add("10", "10 Seconds");
		dictionary2.Add("30", "30 Seconds");
		dictionary2.Add("60", "1 Minute");
		dictionary2.Add("120", "2 Minutes");
		dictionary2.Add("180", "3 Minutes");
		dictionary2.Add("300", "5 Minutes");
		ddlInterval.DataSource = new BindingSource(dictionary2, null);
		ddlInterval.DisplayMember = "Value";
		ddlInterval.ValueMember = "Key";
		OnlineOrderSettingObject onlineOrderSettingObject = SettingsHelper.OnlineOrderSettings.GetProviders(onlyActive: true).FirstOrDefault();
		if (onlineOrderSettingObject != null)
		{
			ddlOnlineOrderProviders.SelectedValue = onlineOrderSettingObject.Provider;
			if (onlineOrderSettingObject.Provider == OnlineOrderProviders.Hippos)
			{
				string text2 = (txtUrl.Text = (txtApiKey.Text = string.Empty));
				RadTextBoxControl radTextBoxControl = txtUrl;
				txtApiKey.Enabled = false;
				radTextBoxControl.Enabled = false;
				ddlInterval.SelectedValue = onlineOrderSettingObject.PollInterval.ToString();
				chkActive.Value = onlineOrderSettingObject.isActive;
			}
		}
	}

	private void ComglAgQy4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (ddlOnlineOrderProviders.SelectedValue.ToString() == OnlineOrderProviders.Moduurn && (string.IsNullOrEmpty(txtApiKey.Text.Trim()) || string.IsNullOrEmpty(txtUrl.Text.Trim())) && chkActive.Value)
		{
			new NotificationLabel(this, "All fields are required.", NotificationTypes.Warning).Show();
			return;
		}
		new GClass6();
		SettingsHelper.OnlineOrderSettings.Save(ddlOnlineOrderProviders.SelectedValue.ToString(), txtUrl.Text.Trim(), txtApiKey.Text.Trim(), Convert.ToInt32(ddlInterval.SelectedValue), chkActive.Value);
		new NotificationLabel(this, "Settings successfully saved.", NotificationTypes.Success).Show();
	}

	private void btnShowKeyboard_ApiKey_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("API Key", 1, 256, txtApiKey.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtApiKey.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Url_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Url", 1, 1024, txtUrl.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtUrl.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void ddlOnlineOrderProviders_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text2 = (txtUrl.Text = (txtApiKey.Text = string.Empty));
		if (ddlOnlineOrderProviders.SelectedValue.ToString() == OnlineOrderProviders.Hippos)
		{
			RadTextBoxControl radTextBoxControl = txtUrl;
			txtApiKey.Enabled = false;
			radTextBoxControl.Enabled = false;
			Class19 @class = ddlInterval;
			RadToggleSwitch radToggleSwitch = chkActive;
			btnSave.Enabled = true;
			radToggleSwitch.Enabled = true;
			@class.Enabled = true;
		}
		else
		{
			RadTextBoxControl radTextBoxControl2 = txtUrl;
			RadTextBoxControl radTextBoxControl3 = txtApiKey;
			Class19 class2 = ddlInterval;
			RadToggleSwitch radToggleSwitch2 = chkActive;
			btnSave.Enabled = true;
			radToggleSwitch2.Enabled = true;
			class2.Enabled = true;
			radTextBoxControl3.Enabled = true;
			radTextBoxControl2.Enabled = true;
		}
		OnlineOrderSettingObject onlineOrderSettingObject = SettingsHelper.OnlineOrderSettings.Get(ddlOnlineOrderProviders.SelectedValue.ToString());
		if (onlineOrderSettingObject != null)
		{
			txtUrl.Text = onlineOrderSettingObject.Url;
			txtApiKey.Text = onlineOrderSettingObject.ApiKey;
			ddlInterval.SelectedValue = onlineOrderSettingObject.PollInterval.ToString();
			chkActive.Value = onlineOrderSettingObject.isActive;
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmOnlineOrderSyncSettings));
		label5 = new Label();
		txtApiKey = new RadTextBoxControl();
		btnShowKeyboard_ApiKey = new Button();
		ComglAgQy4 = new Button();
		btnSave = new Button();
		label9 = new Label();
		ddlOnlineOrderProviders = new Class19();
		label1 = new Label();
		label3 = new Label();
		txtUrl = new RadTextBoxControl();
		btnShowKeyboard_Url = new Button();
		label4 = new Label();
		label6 = new Label();
		chkActive = new RadToggleSwitch();
		ddlInterval = new Class19();
		label7 = new Label();
		((ISupportInitialize)txtApiKey).BeginInit();
		((ISupportInitialize)txtUrl).BeginInit();
		((ISupportInitialize)chkActive).BeginInit();
		SuspendLayout();
		label5.AutoSize = true;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(5, 51);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(120, 35);
		label5.Name = "label5";
		label5.Size = new Size(120, 35);
		label5.TabIndex = 233;
		label5.Text = "Provider";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		txtApiKey.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtApiKey.ForeColor = Color.FromArgb(40, 40, 40);
		txtApiKey.Location = new Point(126, 123);
		txtApiKey.Name = "txtApiKey";
		txtApiKey.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtApiKey.Size = new Size(358, 35);
		txtApiKey.TabIndex = 232;
		((RadTextBoxControlElement)txtApiKey.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtApiKey.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_ApiKey.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_ApiKey.DialogResult = DialogResult.OK;
		btnShowKeyboard_ApiKey.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_ApiKey.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_ApiKey.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_ApiKey.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_ApiKey.ForeColor = Color.White;
		btnShowKeyboard_ApiKey.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_ApiKey.Image");
		btnShowKeyboard_ApiKey.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_ApiKey.Location = new Point(485, 123);
		btnShowKeyboard_ApiKey.Name = "btnShowKeyboard_ApiKey";
		btnShowKeyboard_ApiKey.Size = new Size(51, 35);
		btnShowKeyboard_ApiKey.TabIndex = 231;
		btnShowKeyboard_ApiKey.UseVisualStyleBackColor = false;
		btnShowKeyboard_ApiKey.Click += btnShowKeyboard_ApiKey_Click;
		ComglAgQy4.BackColor = Color.FromArgb(235, 107, 86);
		ComglAgQy4.DialogResult = DialogResult.OK;
		ComglAgQy4.FlatAppearance.BorderSize = 0;
		ComglAgQy4.FlatStyle = FlatStyle.Flat;
		ComglAgQy4.Font = new Font("Microsoft Sans Serif", 11.25f);
		ComglAgQy4.ForeColor = SystemColors.ButtonFace;
		ComglAgQy4.ImeMode = ImeMode.NoControl;
		ComglAgQy4.Location = new Point(268, 242);
		ComglAgQy4.Name = "btnCancel";
		ComglAgQy4.Size = new Size(268, 80);
		ComglAgQy4.TabIndex = 230;
		ComglAgQy4.Text = "CLOSE";
		ComglAgQy4.TextImageRelation = TextImageRelation.ImageBeforeText;
		ComglAgQy4.UseVisualStyleBackColor = false;
		ComglAgQy4.Click += ComglAgQy4_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(5, 242);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(262, 80);
		btnSave.TabIndex = 229;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(5, 4);
		label9.Name = "label9";
		label9.Size = new Size(531, 46);
		label9.TabIndex = 228;
		label9.Text = "ONLINE ORDER SYNC SETTINGS";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		ddlOnlineOrderProviders.BackColor = Color.White;
		ddlOnlineOrderProviders.DrawMode = DrawMode.OwnerDrawVariable;
		ddlOnlineOrderProviders.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlOnlineOrderProviders.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlOnlineOrderProviders.ForeColor = Color.FromArgb(40, 40, 40);
		ddlOnlineOrderProviders.FormattingEnabled = true;
		ddlOnlineOrderProviders.ItemHeight = 29;
		ddlOnlineOrderProviders.Location = new Point(125, 51);
		ddlOnlineOrderProviders.Margin = new Padding(4, 5, 4, 5);
		ddlOnlineOrderProviders.MinimumSize = new Size(50, 0);
		ddlOnlineOrderProviders.Name = "ddlOnlineOrderProviders";
		ddlOnlineOrderProviders.Size = new Size(411, 35);
		ddlOnlineOrderProviders.TabIndex = 234;
		ddlOnlineOrderProviders.Tag = "secondary_language";
		ddlOnlineOrderProviders.SelectedIndexChanged += ddlOnlineOrderProviders_SelectedIndexChanged;
		label1.AutoSize = true;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(5, 123);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(120, 35);
		label1.TabIndex = 235;
		label1.Text = "API Key";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label3.AutoSize = true;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(5, 87);
		label3.Margin = new Padding(4, 0, 4, 0);
		label3.MinimumSize = new Size(120, 35);
		label3.Name = "label3";
		label3.Size = new Size(120, 35);
		label3.TabIndex = 241;
		label3.Text = "Url";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		txtUrl.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtUrl.ForeColor = Color.FromArgb(40, 40, 40);
		txtUrl.Location = new Point(126, 87);
		txtUrl.Name = "txtUrl";
		txtUrl.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtUrl.Size = new Size(358, 35);
		txtUrl.TabIndex = 240;
		((RadTextBoxControlElement)txtUrl.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtUrl.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Url.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Url.DialogResult = DialogResult.OK;
		btnShowKeyboard_Url.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Url.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Url.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Url.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Url.ForeColor = Color.White;
		btnShowKeyboard_Url.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Url.Image");
		btnShowKeyboard_Url.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Url.Location = new Point(485, 87);
		btnShowKeyboard_Url.Name = "btnShowKeyboard_Url";
		btnShowKeyboard_Url.Size = new Size(51, 35);
		btnShowKeyboard_Url.TabIndex = 239;
		btnShowKeyboard_Url.UseVisualStyleBackColor = false;
		btnShowKeyboard_Url.Click += btnShowKeyboard_Url_Click;
		label4.AutoSize = true;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(5, 159);
		label4.Margin = new Padding(4, 0, 4, 0);
		label4.MinimumSize = new Size(120, 35);
		label4.Name = "label4";
		label4.Size = new Size(120, 35);
		label4.TabIndex = 242;
		label4.Text = "Polling Interval";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		label6.BackColor = Color.FromArgb(132, 146, 146);
		label6.Font = new Font("Microsoft Sans Serif", 12f);
		label6.ForeColor = Color.White;
		label6.ImeMode = ImeMode.NoControl;
		label6.Location = new Point(364, 159);
		label6.Margin = new Padding(4, 0, 4, 0);
		label6.MinimumSize = new Size(120, 35);
		label6.Name = "label6";
		label6.Size = new Size(165, 35);
		label6.TabIndex = 243;
		label6.Text = "Active";
		label6.TextAlign = ContentAlignment.MiddleLeft;
		chkActive.Location = new Point(464, 159);
		chkActive.Name = "chkActive";
		chkActive.OffText = "NO";
		chkActive.OnText = "YES";
		chkActive.Size = new Size(72, 35);
		chkActive.TabIndex = 244;
		chkActive.Tag = "";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = "YES";
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		ddlInterval.BackColor = Color.White;
		ddlInterval.DrawMode = DrawMode.OwnerDrawVariable;
		ddlInterval.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlInterval.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlInterval.ForeColor = Color.FromArgb(40, 40, 40);
		ddlInterval.FormattingEnabled = true;
		ddlInterval.ItemHeight = 29;
		ddlInterval.Location = new Point(125, 159);
		ddlInterval.Margin = new Padding(4, 5, 4, 5);
		ddlInterval.MinimumSize = new Size(50, 0);
		ddlInterval.Name = "ddlInterval";
		ddlInterval.Size = new Size(238, 35);
		ddlInterval.TabIndex = 245;
		ddlInterval.Tag = "";
		label7.BackColor = Color.LemonChiffon;
		label7.Cursor = Cursors.Default;
		label7.Font = new Font("Microsoft Sans Serif", 9f);
		label7.ImeMode = ImeMode.NoControl;
		label7.Location = new Point(5, 194);
		label7.Name = "label7";
		label7.Padding = new Padding(5);
		label7.Size = new Size(531, 47);
		label7.TabIndex = 258;
		label7.Text = "NOTE: Shorter intervals will consume greater internet bandwidth.  If you have slow internet connectivity, we recommend a longer polling interval.";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(540, 328);
		base.Controls.Add(label7);
		base.Controls.Add(ddlInterval);
		base.Controls.Add(chkActive);
		base.Controls.Add(label6);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(txtUrl);
		base.Controls.Add(btnShowKeyboard_Url);
		base.Controls.Add(label1);
		base.Controls.Add(ddlOnlineOrderProviders);
		base.Controls.Add(label5);
		base.Controls.Add(txtApiKey);
		base.Controls.Add(btnShowKeyboard_ApiKey);
		base.Controls.Add(ComglAgQy4);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmOnlineOrderSyncSettings";
		base.Opacity = 1.0;
		Text = "frmGiftCardSettings";
		base.Load += frmOnlineOrderSyncSettings_Load;
		((ISupportInitialize)txtApiKey).EndInit();
		((ISupportInitialize)txtUrl).EndInit();
		((ISupportInitialize)chkActive).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
