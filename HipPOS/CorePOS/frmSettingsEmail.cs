using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmSettingsEmail : frmMasterForm
{
	private GClass6 gclass6_0;

	private List<Setting> list_2;

	private bool bool_0;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnSave;

	private RadTextBoxControl txtUsername;

	internal Button btnShowKeyboard_Username;

	private Label label1;

	private RadTextBoxControl txtPassword;

	internal Button btnShowKeyboard_Password;

	private Label label2;

	private RadTextBoxControl txtPort;

	internal Button btnShowKeyboard_Port;

	private Label label3;

	private RadToggleSwitch radToggleSwitch_0;

	private Label label10;

	private Label label4;

	private Button btnShowCustomField;

	private RadTextBoxControl txtServer;

	internal Button btnShowKeyboard_Server;

	private Label label5;

	private Class19 ddlEmailServices;

	private Label label6;

	public frmSettingsEmail()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmSettingsEmail_Load(object sender, EventArgs e)
	{
		list_2 = gclass6_0.Settings.Where((Setting s) => s.Key.Contains("smtp")).ToList();
		txtServer.Text = list_2.Where((Setting s) => s.Key == "smtp_server").FirstOrDefault().Value;
		txtUsername.Text = list_2.Where((Setting s) => s.Key == "smtp_username").FirstOrDefault().Value;
		txtPort.Text = list_2.Where((Setting s) => s.Key == "smtp_port").FirstOrDefault().Value;
		radToggleSwitch_0.Value = Convert.ToBoolean(list_2.Where((Setting s) => s.Key == "smtp_use_ssl").FirstOrDefault().Value);
		if (txtServer.Text.ToLower().Contains("gmail"))
		{
			ddlEmailServices.Text = "Gmail";
		}
		else if (txtServer.Text.ToLower().Contains("yahoo"))
		{
			ddlEmailServices.Text = "Yahoo";
		}
		else if (txtServer.Text.ToLower().Contains("outlook"))
		{
			ddlEmailServices.Text = "Hotmail/Outlook";
		}
		else
		{
			ddlEmailServices.Text = "Other";
		}
		string text = StringCipher.Decrypt(list_2.Where((Setting s) => s.Key == "smtp_password").FirstOrDefault().Value, "DigitalCraftHipPOS");
		if (text == "false")
		{
			txtPassword.Text = list_2.Where((Setting s) => s.Key == "smtp_password").FirstOrDefault().Value;
			string value = StringCipher.Encrypt(txtPassword.Text, "DigitalCraftHipPOS");
			list_2.Where((Setting s) => s.Key == "smtp_password").FirstOrDefault().Value = value;
			try
			{
				Helper.SubmitChangesWithCatch(gclass6_0);
			}
			catch (Exception error)
			{
				NotificationMethods.sendCrash(AppSettings.AppVersion, Environment.OSVersion.VersionString, error);
			}
		}
		else
		{
			txtPassword.Text = text;
		}
		bool_0 = false;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnShowKeyboard_Username_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_SMTP_Username, 1, 128, txtUsername.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtUsername.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Password_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_SMTP_Password, 1, 128, txtPassword.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtPassword.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Server_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_SMTP_Server_Address, 1, 128, txtServer.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtServer.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Port_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_SMTP_Port_Number, 0, 5, txtPort.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPort.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		list_2.Where((Setting s) => s.Key == "smtp_server").FirstOrDefault().Value = txtServer.Text.Trim();
		list_2.Where((Setting s) => s.Key == "smtp_username").FirstOrDefault().Value = txtUsername.Text.Trim();
		list_2.Where((Setting s) => s.Key == "smtp_password").FirstOrDefault().Value = StringCipher.Encrypt(txtPassword.Text, "DigitalCraftHipPOS");
		list_2.Where((Setting s) => s.Key == "smtp_port").FirstOrDefault().Value = txtPort.Text.Trim();
		list_2.Where((Setting s) => s.Key == "smtp_use_ssl").FirstOrDefault().Value = radToggleSwitch_0.Value.ToString();
		Helper.SubmitChangesWithCatch(gclass6_0);
		new NotificationLabel(this, "E-mail settings saved.", NotificationTypes.Success).Show();
	}

	private void btnShowCustomField_Click(object sender, EventArgs e)
	{
		SMTPSettings sMTPSettings = new SMTPSettings();
		try
		{
			sMTPSettings.server = txtServer.Text;
			sMTPSettings.password = txtPassword.Text;
			sMTPSettings.port = Convert.ToInt32(txtPort.Text);
			sMTPSettings.sslEnable = radToggleSwitch_0.Value;
			sMTPSettings.username = txtUsername.Text;
			new frmMessageBox(NotificationMethods.sendEmail(sMTPSettings, sMTPSettings.username, Resources.Hippos_Test_Email, Resources.This_is_a_test_message_from_Hi), Resources.SMTP_Test_Result).ShowDialog();
		}
		catch (Exception ex)
		{
			new frmMessageBox(Resources.Email_error_please_check_your_ + ex.Message, Resources.Email_ERROR).ShowDialog();
		}
	}

	private void ddlEmailServices_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (ddlEmailServices.Text == "Other")
		{
			txtServer.Text = "";
			return;
		}
		method_4();
		if (ddlEmailServices.Text == "Gmail")
		{
			txtServer.Text = "smtp.gmail.com";
			txtPort.Text = "587";
			radToggleSwitch_0.Value = true;
		}
		else if (ddlEmailServices.Text == "Hotmail/Outlook")
		{
			txtServer.Text = "smtp-mail.outlook.com";
			txtPort.Text = "587";
			radToggleSwitch_0.Value = true;
		}
		else if (ddlEmailServices.Text == "Yahoo")
		{
			txtServer.Text = "smtp.mail.yahoo.com";
			txtPort.Text = "465";
			radToggleSwitch_0.Value = true;
		}
		else
		{
			method_4();
		}
	}

	private void method_3(bool bool_1)
	{
		RadTextBoxControl radTextBoxControl = txtServer;
		RadTextBoxControl radTextBoxControl2 = txtUsername;
		RadTextBoxControl radTextBoxControl3 = txtPassword;
		bool flag2 = (txtPort.Enabled = bool_1);
		bool flag4 = (radTextBoxControl3.Enabled = flag2);
		bool enabled = (radTextBoxControl2.Enabled = flag4);
		radTextBoxControl.Enabled = enabled;
	}

	private void method_4()
	{
		RadTextBoxControl radTextBoxControl = txtServer;
		RadTextBoxControl radTextBoxControl2 = txtUsername;
		RadTextBoxControl radTextBoxControl3 = txtPassword;
		string text = (txtPort.Text = string.Empty);
		string text3 = (radTextBoxControl3.Text = text);
		string text6 = (radTextBoxControl.Text = (radTextBoxControl2.Text = text3));
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSettingsEmail));
		btnShowCustomField = new Button();
		label4 = new Label();
		radToggleSwitch_0 = new RadToggleSwitch();
		label10 = new Label();
		txtPort = new RadTextBoxControl();
		btnShowKeyboard_Port = new Button();
		label3 = new Label();
		txtPassword = new RadTextBoxControl();
		btnShowKeyboard_Password = new Button();
		label2 = new Label();
		txtUsername = new RadTextBoxControl();
		btnShowKeyboard_Username = new Button();
		label1 = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		txtServer = new RadTextBoxControl();
		btnShowKeyboard_Server = new Button();
		label5 = new Label();
		ddlEmailServices = new Class19();
		label6 = new Label();
		((ISupportInitialize)radToggleSwitch_0).BeginInit();
		((ISupportInitialize)txtPort).BeginInit();
		((ISupportInitialize)txtPassword).BeginInit();
		((ISupportInitialize)txtUsername).BeginInit();
		((ISupportInitialize)txtServer).BeginInit();
		SuspendLayout();
		btnShowCustomField.BackColor = Color.FromArgb(50, 119, 155);
		btnShowCustomField.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowCustomField, "btnShowCustomField");
		btnShowCustomField.ForeColor = SystemColors.Control;
		btnShowCustomField.Name = "btnShowCustomField";
		btnShowCustomField.Tag = "product";
		btnShowCustomField.UseVisualStyleBackColor = false;
		btnShowCustomField.Click += btnShowCustomField_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(radToggleSwitch_0, "chkUseSSL");
		radToggleSwitch_0.Name = "chkUseSSL";
		radToggleSwitch_0.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)radToggleSwitch_0.GetChildAt(0)).ThumbOffset = 86;
		((RadToggleSwitchElement)radToggleSwitch_0.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(txtPort, "txtPort");
		txtPort.ForeColor = Color.FromArgb(40, 40, 40);
		txtPort.Name = "txtPort";
		txtPort.RootElement.PositionOffset = new SizeF(0f, 0f);
		((RadTextBoxControlElement)txtPort.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPort.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Port.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Port.DialogResult = DialogResult.OK;
		btnShowKeyboard_Port.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Port.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Port, "btnShowKeyboard_Port");
		btnShowKeyboard_Port.ForeColor = Color.White;
		btnShowKeyboard_Port.Name = "btnShowKeyboard_Port";
		btnShowKeyboard_Port.UseVisualStyleBackColor = false;
		btnShowKeyboard_Port.Click += btnShowKeyboard_Port_Click;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtPassword, "txtPassword");
		txtPassword.ForeColor = Color.FromArgb(40, 40, 40);
		txtPassword.Name = "txtPassword";
		txtPassword.RootElement.PositionOffset = new SizeF(0f, 0f);
		((RadTextBoxControlElement)txtPassword.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPassword.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Password.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Password.DialogResult = DialogResult.OK;
		btnShowKeyboard_Password.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Password.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Password, "btnShowKeyboard_Password");
		btnShowKeyboard_Password.ForeColor = Color.White;
		btnShowKeyboard_Password.Name = "btnShowKeyboard_Password";
		btnShowKeyboard_Password.UseVisualStyleBackColor = false;
		btnShowKeyboard_Password.Click += btnShowKeyboard_Password_Click;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(txtUsername, "txtUsername");
		txtUsername.ForeColor = Color.FromArgb(40, 40, 40);
		txtUsername.Name = "txtUsername";
		txtUsername.RootElement.PositionOffset = new SizeF(0f, 0f);
		((RadTextBoxControlElement)txtUsername.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtUsername.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Username.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Username.DialogResult = DialogResult.OK;
		btnShowKeyboard_Username.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Username.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Username, "btnShowKeyboard_Username");
		btnShowKeyboard_Username.ForeColor = Color.White;
		btnShowKeyboard_Username.Name = "btnShowKeyboard_Username";
		btnShowKeyboard_Username.UseVisualStyleBackColor = false;
		btnShowKeyboard_Username.Click += btnShowKeyboard_Username_Click;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(txtServer, "txtServer");
		txtServer.ForeColor = Color.FromArgb(40, 40, 40);
		txtServer.Name = "txtServer";
		txtServer.RootElement.PositionOffset = new SizeF(0f, 0f);
		((RadTextBoxControlElement)txtServer.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtServer.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Server.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Server.DialogResult = DialogResult.OK;
		btnShowKeyboard_Server.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Server.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Server, "btnShowKeyboard_Server");
		btnShowKeyboard_Server.ForeColor = Color.White;
		btnShowKeyboard_Server.Name = "btnShowKeyboard_Server";
		btnShowKeyboard_Server.UseVisualStyleBackColor = false;
		btnShowKeyboard_Server.Click += btnShowKeyboard_Server_Click;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		ddlEmailServices.BackColor = Color.White;
		ddlEmailServices.DrawMode = DrawMode.OwnerDrawVariable;
		componentResourceManager.ApplyResources(ddlEmailServices, "ddlEmailServices");
		ddlEmailServices.ForeColor = Color.FromArgb(40, 40, 40);
		ddlEmailServices.FormattingEnabled = true;
		ddlEmailServices.Items.AddRange(new object[4]
		{
			componentResourceManager.GetString("ddlEmailServices.Items"),
			componentResourceManager.GetString("ddlEmailServices.Items1"),
			componentResourceManager.GetString("ddlEmailServices.Items2"),
			componentResourceManager.GetString("ddlEmailServices.Items3")
		});
		ddlEmailServices.Name = "ddlEmailServices";
		ddlEmailServices.Tag = "";
		ddlEmailServices.SelectedIndexChanged += ddlEmailServices_SelectedIndexChanged;
		componentResourceManager.ApplyResources(label6, "label6");
		label6.BackColor = Color.FromArgb(132, 146, 146);
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(label6);
		base.Controls.Add(ddlEmailServices);
		base.Controls.Add(txtServer);
		base.Controls.Add(btnShowKeyboard_Server);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowCustomField);
		base.Controls.Add(label4);
		base.Controls.Add(radToggleSwitch_0);
		base.Controls.Add(label10);
		base.Controls.Add(txtPort);
		base.Controls.Add(btnShowKeyboard_Port);
		base.Controls.Add(label3);
		base.Controls.Add(txtPassword);
		base.Controls.Add(btnShowKeyboard_Password);
		base.Controls.Add(label2);
		base.Controls.Add(txtUsername);
		base.Controls.Add(btnShowKeyboard_Username);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmSettingsEmail";
		base.Opacity = 1.0;
		base.Load += frmSettingsEmail_Load;
		((ISupportInitialize)radToggleSwitch_0).EndInit();
		((ISupportInitialize)txtPort).EndInit();
		((ISupportInitialize)txtPassword).EndInit();
		((ISupportInitialize)txtUsername).EndInit();
		((ISupportInitialize)txtServer).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
