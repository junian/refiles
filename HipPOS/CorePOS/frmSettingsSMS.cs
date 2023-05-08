using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmSettingsSMS : frmMasterForm
{
	private GClass6 gclass6_0;

	private List<Setting> list_2;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnSave;

	private RadTextBoxControl txtServer;

	internal Button btnShowKeyboard_Server;

	private Label label1;

	private RadTextBoxControl txtCountryCode;

	internal Button btnShowKeyboard_CountryCode;

	private Label label3;

	private Label label10;

	private Label label4;

	private Button btnSendTest;

	private RadTextBoxControl radTextBoxControl_0;

	internal Button btnShowKeyboard_API;

	private Label label5;

	public frmSettingsSMS()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmSettingsSMS_Load(object sender, EventArgs e)
	{
		list_2 = gclass6_0.Settings.Where((Setting s) => s.Key.Contains("sms")).ToList();
		((Control)(object)radTextBoxControl_0).Text = list_2.Where((Setting s) => s.Key == "sms_token").FirstOrDefault().Value;
		((Control)(object)txtServer).Text = list_2.Where((Setting s) => s.Key == "sms_server").FirstOrDefault().Value;
		((Control)(object)txtCountryCode).Text = list_2.Where((Setting s) => s.Key == "sms_country_code").FirstOrDefault().Value;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnShowKeyboard_Server_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_SMS_Server_Address, 1, 128, ((Control)(object)txtServer).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtServer).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_API_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_SMS_Server_API_Key, 1, 128, ((Control)(object)radTextBoxControl_0).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)radTextBoxControl_0).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_CountryCode_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_SMS_Country_Code, 0, 5, ((Control)(object)txtCountryCode).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtCountryCode).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		list_2.Where((Setting s) => s.Key == "sms_token").FirstOrDefault().Value = ((Control)(object)radTextBoxControl_0).Text.Trim();
		list_2.Where((Setting s) => s.Key == "sms_server").FirstOrDefault().Value = ((Control)(object)txtServer).Text.Trim();
		list_2.Where((Setting s) => s.Key == "sms_country_code").FirstOrDefault().Value = ((Control)(object)txtCountryCode).Text.Trim();
		Helper.SubmitChangesWithCatch(gclass6_0);
	}

	private void btnSendTest_Click(object sender, EventArgs e)
	{
		new frmMessageBox(Resources.Feature_has_not_been_enabled_i, Resources.SMS_Test_Result).ShowDialog();
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
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSettingsSMS));
		btnSendTest = new Button();
		label4 = new Label();
		label10 = new Label();
		txtCountryCode = new RadTextBoxControl();
		btnShowKeyboard_CountryCode = new Button();
		label3 = new Label();
		txtServer = new RadTextBoxControl();
		btnShowKeyboard_Server = new Button();
		label1 = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		radTextBoxControl_0 = new RadTextBoxControl();
		btnShowKeyboard_API = new Button();
		label5 = new Label();
		((ISupportInitialize)txtCountryCode).BeginInit();
		((ISupportInitialize)txtServer).BeginInit();
		((ISupportInitialize)radTextBoxControl_0).BeginInit();
		SuspendLayout();
		btnSendTest.BackColor = Color.FromArgb(50, 119, 155);
		btnSendTest.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSendTest, "btnSendTest");
		btnSendTest.ForeColor = SystemColors.Control;
		btnSendTest.Name = "btnSendTest";
		btnSendTest.Tag = "product";
		btnSendTest.UseVisualStyleBackColor = false;
		btnSendTest.Click += btnSendTest_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label10.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(txtCountryCode, "txtCountryCode");
		((Control)(object)txtCountryCode).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtCountryCode).Name = "txtCountryCode";
		((RadElement)((RadControl)txtCountryCode).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtCountryCode).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtCountryCode).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_CountryCode.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_CountryCode.DialogResult = DialogResult.OK;
		btnShowKeyboard_CountryCode.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_CountryCode.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_CountryCode, "btnShowKeyboard_CountryCode");
		btnShowKeyboard_CountryCode.ForeColor = Color.White;
		btnShowKeyboard_CountryCode.Name = "btnShowKeyboard_CountryCode";
		btnShowKeyboard_CountryCode.UseVisualStyleBackColor = false;
		btnShowKeyboard_CountryCode.Click += btnShowKeyboard_CountryCode_Click;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtServer, "txtServer");
		((Control)(object)txtServer).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtServer).Name = "txtServer";
		((RadElement)((RadControl)txtServer).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtServer).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtServer).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Server.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Server.DialogResult = DialogResult.OK;
		btnShowKeyboard_Server.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Server.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Server, "btnShowKeyboard_Server");
		btnShowKeyboard_Server.ForeColor = Color.White;
		btnShowKeyboard_Server.Name = "btnShowKeyboard_Server";
		btnShowKeyboard_Server.UseVisualStyleBackColor = false;
		btnShowKeyboard_Server.Click += btnShowKeyboard_Server_Click;
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
		componentResourceManager.ApplyResources(radTextBoxControl_0, "txtAPIKey");
		((Control)(object)radTextBoxControl_0).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)radTextBoxControl_0).Name = "txtAPIKey";
		((UIItemBase)(RadTextBoxControlElement)((RadControl)radTextBoxControl_0).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)radTextBoxControl_0).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_API.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_API.DialogResult = DialogResult.OK;
		btnShowKeyboard_API.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_API.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_API, "btnShowKeyboard_API");
		btnShowKeyboard_API.ForeColor = Color.White;
		btnShowKeyboard_API.Name = "btnShowKeyboard_API";
		btnShowKeyboard_API.UseVisualStyleBackColor = false;
		btnShowKeyboard_API.Click += btnShowKeyboard_API_Click;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add((Control)(object)radTextBoxControl_0);
		base.Controls.Add(btnShowKeyboard_API);
		base.Controls.Add(label5);
		base.Controls.Add(btnSendTest);
		base.Controls.Add(label4);
		base.Controls.Add(label10);
		base.Controls.Add((Control)(object)txtCountryCode);
		base.Controls.Add(btnShowKeyboard_CountryCode);
		base.Controls.Add(label3);
		base.Controls.Add((Control)(object)txtServer);
		base.Controls.Add(btnShowKeyboard_Server);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmSettingsSMS";
		base.Opacity = 1.0;
		base.Load += frmSettingsSMS_Load;
		((ISupportInitialize)txtCountryCode).EndInit();
		((ISupportInitialize)txtServer).EndInit();
		((ISupportInitialize)radTextBoxControl_0).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
