using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmGiftCardSettings : frmMasterForm
{
	private string string_0;

	private IContainer icontainer_1;

	private Label label5;

	private RadTextBoxControl txtApiKey;

	internal Button btnShowKeyboard_ApiKey;

	private Button btnCancel;

	private Button btnSave;

	private Label label9;

	private Class19 ddlGiftCards;

	private Label label1;

	private Label label2;

	private RadTextBoxControl txtDevice;

	internal Button btnShowKeyboard_Device;

	private RadToggleSwitch chkActive;

	private Label label21;

	private Label label13;

	private Class19 ddlLocations;

	internal Button btnDIsplayLocations;

	public frmGiftCardSettings(string cardTypeJSON)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		base._002Ector();
		InitializeComponent_1();
		string_0 = cardTypeJSON;
		if (cardTypeJSON == "gift_card_json")
		{
			label9.Text = "GIFT CARD SETTINGS";
		}
		else
		{
			label9.Text = "LOYALTY CARD SETTINGS";
		}
	}

	private void frmGiftCardSettings_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Ackroo", "Ackroo");
		dictionary.Add("TapMango", "TapMango");
		ddlGiftCards.DataSource = new BindingSource(dictionary, null);
		ddlGiftCards.DisplayMember = "Value";
		ddlGiftCards.ValueMember = "Key";
		method_3();
	}

	private void method_3()
	{
		if (ddlGiftCards.SelectedValue.ToString() == "Ackroo")
		{
			txtDevice.Visible = true;
			txtApiKey.Text = "Access token";
			ddlLocations.Visible = false;
			label2.Text = "Device Id";
			btnDIsplayLocations.Visible = false;
		}
		else if (ddlGiftCards.SelectedValue.ToString() == "TapMango")
		{
			txtDevice.Visible = false;
			txtApiKey.Text = "API Key";
			ddlLocations.Visible = true;
			label2.Text = "Location";
			btnDIsplayLocations.Visible = true;
		}
		txtApiKey.Text = "";
		txtDevice.Text = "";
		chkActive.Value = false;
		CardProcessorObject cardProcessorSetting = SettingsHelper.GetCardProcessorSetting(ddlGiftCards.SelectedValue.ToString(), string_0);
		if (cardProcessorSetting == null)
		{
			return;
		}
		chkActive.Value = cardProcessorSetting.isActive;
		if (cardProcessorSetting.Processor == "Ackroo")
		{
			List<string> list = cardProcessorSetting.ApiKey.Split('|').ToList();
			if (list.Count > 1)
			{
				txtApiKey.Text = list[0];
				txtDevice.Text = list[1];
			}
		}
		else if (cardProcessorSetting.Processor == "TapMango")
		{
			txtApiKey.Text = cardProcessorSetting.ApiKey;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (ddlGiftCards.SelectedValue.ToString() == "NONE")
		{
			new NotificationLabel(this, "Please select a Provider", NotificationTypes.Warning).Show();
			return;
		}
		if (ddlGiftCards.SelectedValue.ToString() == "")
		{
			new NotificationLabel(this, "Please select a Gift card provider.", NotificationTypes.Warning).Show();
			return;
		}
		if (string.IsNullOrEmpty(txtApiKey.Text))
		{
			new NotificationLabel(this, "Please add an api key", NotificationTypes.Warning).Show();
			return;
		}
		if (ddlGiftCards.SelectedValue.ToString() == "Ackroo")
		{
			if (string.IsNullOrEmpty(txtDevice.Text))
			{
				new NotificationLabel(this, "Please add a device.", NotificationTypes.Warning).Show();
				return;
			}
			SettingsHelper.SetCardProcessorSetting(string_0, ddlGiftCards.SelectedValue.ToString(), txtApiKey.Text + "|" + txtDevice.Text, "", chkActive.Value);
		}
		else if (ddlGiftCards.SelectedValue.ToString() == "TapMango")
		{
			if (ddlLocations.SelectedValue == null || ddlLocations.SelectedValue.ToString() == "")
			{
				new NotificationLabel(this, "Please choose a location.", NotificationTypes.Warning).Show();
				return;
			}
			SettingsHelper.SetCardProcessorSetting(string_0, ddlGiftCards.SelectedValue.ToString(), txtApiKey.Text, ddlLocations.SelectedValue.ToString(), chkActive.Value);
		}
		new NotificationLabel(this, "Settings successfully saved.", NotificationTypes.Success).Show();
	}

	private void btnShowKeyboard_ApiKey_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Access Token", 1, 128, txtApiKey.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtApiKey.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Device_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Device ID", 1, 128, txtDevice.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtDevice.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void ddlGiftCards_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3();
	}

	private void SvOtdThiVl()
	{
		if (!(ddlGiftCards.SelectedValue.ToString() == "TapMango"))
		{
			return;
		}
		TapMangoLocationListResponse locations = TapMangoMethods.GetLocations(txtApiKey.Text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (locations != null && locations.data != null && locations.data.Count > 0)
		{
			foreach (TapMangoLocation datum in locations.data)
			{
				dictionary.Add(datum.id.ToString(), datum.name + " - " + datum.address);
			}
			ddlLocations.DataSource = new BindingSource(dictionary, null);
			ddlLocations.DisplayMember = "Value";
			ddlLocations.ValueMember = "Key";
			CardProcessorObject cardProcessorSetting = SettingsHelper.GetCardProcessorSetting(ddlGiftCards.SelectedValue.ToString(), string_0);
			if (cardProcessorSetting != null)
			{
				ddlLocations.SelectedValue = cardProcessorSetting.Id.ToString();
			}
		}
		else
		{
			ddlLocations.DataSource = null;
		}
	}

	private void txtApiKey_TextChanged(object sender, EventArgs e)
	{
		SvOtdThiVl();
	}

	private void btnDIsplayLocations_Click(object sender, EventArgs e)
	{
		SvOtdThiVl();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmGiftCardSettings));
		label13 = new Label();
		chkActive = new RadToggleSwitch();
		label21 = new Label();
		label2 = new Label();
		txtDevice = new RadTextBoxControl();
		btnShowKeyboard_Device = new Button();
		label1 = new Label();
		ddlGiftCards = new Class19();
		label5 = new Label();
		txtApiKey = new RadTextBoxControl();
		btnShowKeyboard_ApiKey = new Button();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		ddlLocations = new Class19();
		btnDIsplayLocations = new Button();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)txtDevice).BeginInit();
		((ISupportInitialize)txtApiKey).BeginInit();
		SuspendLayout();
		label13.BackColor = Color.FromArgb(132, 146, 146);
		label13.Font = new Font("Microsoft Sans Serif", 12f);
		label13.ForeColor = Color.White;
		label13.ImeMode = ImeMode.NoControl;
		label13.Location = new Point(201, 161);
		label13.Margin = new Padding(4, 0, 4, 0);
		label13.Name = "label13";
		label13.Size = new Size(337, 35);
		label13.TabIndex = 247;
		label13.Tag = "product";
		label13.TextAlign = ContentAlignment.MiddleRight;
		chkActive.Location = new Point(128, 161);
		chkActive.Name = "chkActive";
		chkActive.OffText = "NO";
		chkActive.OnText = "YES";
		chkActive.Size = new Size(72, 35);
		chkActive.TabIndex = 239;
		chkActive.Tag = "product";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		chkActive.Value = false;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = "YES";
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label21.BackColor = Color.FromArgb(132, 146, 146);
		label21.Font = new Font("Microsoft Sans Serif", 12f);
		label21.ForeColor = Color.White;
		label21.ImeMode = ImeMode.NoControl;
		label21.Location = new Point(7, 161);
		label21.Margin = new Padding(4, 0, 4, 0);
		label21.MinimumSize = new Size(120, 35);
		label21.Name = "label21";
		label21.Size = new Size(120, 35);
		label21.TabIndex = 240;
		label21.Tag = "product";
		label21.Text = "Active";
		label21.TextAlign = ContentAlignment.MiddleLeft;
		label2.AutoSize = true;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(7, 125);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(120, 35);
		label2.TabIndex = 238;
		label2.Text = "Device Id";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		txtDevice.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtDevice.ForeColor = Color.FromArgb(40, 40, 40);
		txtDevice.Location = new Point(128, 125);
		txtDevice.Name = "txtDevice";
		txtDevice.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtDevice.Size = new Size(358, 35);
		txtDevice.TabIndex = 237;
		((RadTextBoxControlElement)txtDevice.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtDevice.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Device.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Device.DialogResult = DialogResult.OK;
		btnShowKeyboard_Device.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Device.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Device.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Device.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Device.ForeColor = Color.White;
		btnShowKeyboard_Device.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Device.Image");
		btnShowKeyboard_Device.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Device.Location = new Point(487, 125);
		btnShowKeyboard_Device.Name = "btnShowKeyboard_Device";
		btnShowKeyboard_Device.Size = new Size(51, 35);
		btnShowKeyboard_Device.TabIndex = 236;
		btnShowKeyboard_Device.UseVisualStyleBackColor = false;
		btnShowKeyboard_Device.Click += btnShowKeyboard_Device_Click;
		label1.AutoSize = true;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(7, 89);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(120, 35);
		label1.TabIndex = 235;
		label1.Text = "Access token";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		ddlGiftCards.BackColor = Color.White;
		ddlGiftCards.DrawMode = DrawMode.OwnerDrawVariable;
		ddlGiftCards.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlGiftCards.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlGiftCards.ForeColor = Color.FromArgb(40, 40, 40);
		ddlGiftCards.FormattingEnabled = true;
		ddlGiftCards.ItemHeight = 29;
		ddlGiftCards.Location = new Point(127, 53);
		ddlGiftCards.Margin = new Padding(4, 5, 4, 5);
		ddlGiftCards.MinimumSize = new Size(50, 0);
		ddlGiftCards.Name = "ddlGiftCards";
		ddlGiftCards.Size = new Size(411, 35);
		ddlGiftCards.TabIndex = 234;
		ddlGiftCards.Tag = "secondary_language";
		ddlGiftCards.SelectedIndexChanged += ddlGiftCards_SelectedIndexChanged;
		label5.AutoSize = true;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(7, 53);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(120, 35);
		label5.Name = "label5";
		label5.Size = new Size(120, 35);
		label5.TabIndex = 233;
		label5.Text = "Provider";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		txtApiKey.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtApiKey.ForeColor = Color.FromArgb(40, 40, 40);
		txtApiKey.Location = new Point(128, 89);
		txtApiKey.Name = "txtApiKey";
		txtApiKey.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtApiKey.Size = new Size(358, 35);
		txtApiKey.TabIndex = 232;
		txtApiKey.TextChanged += txtApiKey_TextChanged;
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
		btnShowKeyboard_ApiKey.Location = new Point(487, 89);
		btnShowKeyboard_ApiKey.Name = "btnShowKeyboard_ApiKey";
		btnShowKeyboard_ApiKey.Size = new Size(51, 35);
		btnShowKeyboard_ApiKey.TabIndex = 231;
		btnShowKeyboard_ApiKey.UseVisualStyleBackColor = false;
		btnShowKeyboard_ApiKey.Click += btnShowKeyboard_ApiKey_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(270, 197);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(268, 80);
		btnCancel.TabIndex = 230;
		btnCancel.Text = "CLOSE";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(7, 197);
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
		label9.Location = new Point(7, 6);
		label9.Name = "label9";
		label9.Size = new Size(532, 46);
		label9.TabIndex = 228;
		label9.Text = "GIFT CARD SETTINGS";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		ddlLocations.BackColor = Color.White;
		ddlLocations.DrawMode = DrawMode.OwnerDrawVariable;
		ddlLocations.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlLocations.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlLocations.ForeColor = Color.FromArgb(40, 40, 40);
		ddlLocations.FormattingEnabled = true;
		ddlLocations.ItemHeight = 29;
		ddlLocations.Location = new Point(127, 125);
		ddlLocations.Margin = new Padding(4, 5, 4, 5);
		ddlLocations.MinimumSize = new Size(50, 0);
		ddlLocations.Name = "ddlLocations";
		ddlLocations.Size = new Size(411, 35);
		ddlLocations.TabIndex = 248;
		ddlLocations.Tag = "secondary_language";
		btnDIsplayLocations.BackColor = Color.FromArgb(77, 174, 225);
		btnDIsplayLocations.DialogResult = DialogResult.OK;
		btnDIsplayLocations.FlatAppearance.BorderColor = Color.Black;
		btnDIsplayLocations.FlatAppearance.BorderSize = 0;
		btnDIsplayLocations.FlatStyle = FlatStyle.Flat;
		btnDIsplayLocations.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btnDIsplayLocations.ForeColor = Color.White;
		btnDIsplayLocations.ImeMode = ImeMode.NoControl;
		btnDIsplayLocations.Location = new Point(344, 161);
		btnDIsplayLocations.Name = "btnDIsplayLocations";
		btnDIsplayLocations.Size = new Size(193, 35);
		btnDIsplayLocations.TabIndex = 249;
		btnDIsplayLocations.Text = "Refresh Locations List";
		btnDIsplayLocations.UseVisualStyleBackColor = false;
		btnDIsplayLocations.Click += btnDIsplayLocations_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(545, 283);
		base.Controls.Add(btnDIsplayLocations);
		base.Controls.Add(ddlLocations);
		base.Controls.Add(label13);
		base.Controls.Add(chkActive);
		base.Controls.Add(label21);
		base.Controls.Add(label2);
		base.Controls.Add(txtDevice);
		base.Controls.Add(btnShowKeyboard_Device);
		base.Controls.Add(label1);
		base.Controls.Add(ddlGiftCards);
		base.Controls.Add(label5);
		base.Controls.Add(txtApiKey);
		base.Controls.Add(btnShowKeyboard_ApiKey);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmGiftCardSettings";
		base.Opacity = 1.0;
		Text = "frmGiftCardSettings";
		base.Load += frmGiftCardSettings_Load;
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)txtDevice).EndInit();
		((ISupportInitialize)txtApiKey).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
