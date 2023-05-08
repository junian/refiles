using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Business.Objects.PaymentObjects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmSettingsPaymentProcessor : frmMasterForm
{
	public Terminal terminal;

	private GClass6 gclass6_0;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnSave;

	private Label label1;

	private Label label2;

	private RadTextBoxControl txtPort;

	internal Button btnShowKeyboard_Port;

	private Label label3;

	private Label label4;

	private Button btnTest;

	private RadTextBoxControl txtServer;

	internal Button btnShowKeyboard_Server;

	private Label label5;

	private Label label6;

	private RadTextBoxControl txtStation;

	private Class19 ddlProcessor;

	private Class19 ddlTerminalModel;

	private RadTextBoxControl txtMerchantID;

	internal Button btnShowKeyboard_MerchantID;

	private Label label7;

	private RadTextBoxControl txtSerialNumber;

	internal Button btnShowKeyboard_SerialNumber;

	private Label label10;

	public frmSettingsPaymentProcessor()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmSettingsPaymentProcessor_Load(object sender, EventArgs e)
	{
		Terminal terminal = ((this.terminal == null) ? gclass6_0.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault() : this.terminal);
		if (terminal != null)
		{
			((Control)(object)txtStation).Text = terminal.SystemName;
			if (!string.IsNullOrEmpty(terminal.PaymentProviderName))
			{
				ddlProcessor.Text = terminal.PaymentProviderName;
			}
			else
			{
				ddlProcessor.SelectedIndex = 0;
			}
			if (!string.IsNullOrEmpty(terminal.PaymentTerminalModel))
			{
				ddlTerminalModel.Text = terminal.PaymentTerminalModel;
			}
			else if (ddlTerminalModel.Items.Count > 0)
			{
				ddlTerminalModel.SelectedIndex = 0;
			}
			((Control)(object)txtMerchantID).Text = terminal.PaymentMerchantID;
			((Control)(object)txtServer).Text = terminal.PaymentTerminalAddress;
			((Control)(object)txtPort).Text = terminal.PaymentTerminalPort.ToString();
			((Control)(object)txtSerialNumber).Text = terminal.PaymentTerminalSerial;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnShowKeyboard_Server_Click(object sender, EventArgs e)
	{
		int maxlength = 15;
		if (ddlTerminalModel.Text == PaymentTerminalModels.Clover.Flex)
		{
			maxlength = 50;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Payment_Terminal_IP_Addr, 0, maxlength, ((Control)(object)txtServer).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtServer).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Port_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_SMTP_Port_Number, 0, 5, ((Control)(object)txtPort).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtPort).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			if (!method_3())
			{
				return;
			}
			if (this.terminal == null)
			{
				Terminal terminal = gclass6_0.Terminals.Where((Terminal x) => x.SystemName.Equals(Environment.MachineName)).FirstOrDefault();
				if (terminal == null)
				{
					terminal = new Terminal();
					gclass6_0.Terminals.InsertOnSubmit(terminal);
				}
				terminal.PaymentProviderName = ddlProcessor.Text;
				terminal.PaymentTerminalModel = ddlTerminalModel.Text;
				terminal.PaymentTerminalAddress = ((Control)(object)txtServer).Text.Trim();
				terminal.PaymentTerminalPort = (short)((!string.IsNullOrEmpty(((Control)(object)txtPort).Text)) ? Convert.ToInt16(((Control)(object)txtPort).Text) : 0);
				terminal.PaymentMerchantID = ((Control)(object)txtMerchantID).Text;
				terminal.PaymentTerminalSerial = ((Control)(object)txtSerialNumber).Text.Trim();
				Helper.SubmitChangesWithCatch(gclass6_0);
				new NotificationLabel(this, Resources.Payment_Terminal_Settings_Save, NotificationTypes.Success).Show();
			}
			else
			{
				this.terminal.PaymentProviderName = ddlProcessor.Text;
				this.terminal.PaymentTerminalModel = ddlTerminalModel.Text;
				this.terminal.PaymentTerminalAddress = ((Control)(object)txtServer).Text.Trim();
				this.terminal.PaymentTerminalPort = (short)((!string.IsNullOrEmpty(((Control)(object)txtPort).Text)) ? Convert.ToInt16(((Control)(object)txtPort).Text) : 0);
				this.terminal.PaymentMerchantID = ((Control)(object)txtMerchantID).Text;
				this.terminal.PaymentTerminalSerial = ((Control)(object)txtSerialNumber).Text.Trim();
				base.DialogResult = DialogResult.OK;
			}
			MemoryLoadedObjects.RefreshTerminals();
		}
		catch
		{
			new NotificationLabel(this, "Please fill up correct payment processor info.", NotificationTypes.Warning).Show();
		}
	}

	private void btnTest_Click(object sender, EventArgs e)
	{
		if (!method_3())
		{
			return;
		}
		new GClass6();
		if (string.IsNullOrEmpty(ddlProcessor.Text) || string.IsNullOrEmpty(ddlTerminalModel.Text) || string.IsNullOrEmpty(((Control)(object)txtServer).Text) || string.IsNullOrEmpty(((Control)(object)txtMerchantID).Text) || string.IsNullOrEmpty(((Control)(object)txtPort).Text))
		{
			return;
		}
		short result = 0;
		short.TryParse(((Control)(object)txtPort).Text, out result);
		string text = ((Control)(object)txtServer).Text;
		bool flag = false;
		if (ddlProcessor.Text == PaymentProviderNames.FirstData)
		{
			if (ddlTerminalModel.Text == PaymentTerminalModels.Ingenico.iCT250)
			{
				string text2 = "0";
				if (new frmMessageBox(Resources.Ping_with_terminal_log, Resources.Ping_Option, CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
				{
					text2 = "1";
				}
				string text3 = "transactiontype^ping^merchantid^" + ((Control)(object)txtMerchantID).Text.Trim() + "^transactiondate^" + DateTime.Now.ToString("MMddyy") + "^transactiontime^" + DateTime.Now.ToString("HHmmss") + "^terminallog^" + text2 + "^";
				string text4 = text3.Length.ToString();
				while (text4.Length < 5)
				{
					text4 = "0" + text4;
				}
				text3 = text4 + text3;
				frmWaitingPaymentTerminal obj = new frmWaitingPaymentTerminal(ddlProcessor.Text, ddlTerminalModel.Text, text, result, text3, parseObject: false, null, "");
				obj.ShowDialog();
				PaymentTransactionObject paymentTransactionObject = obj.transaction_objects.FirstOrDefault();
				if (paymentTransactionObject != null && paymentTransactionObject.rawdata != null)
				{
					string[] array = paymentTransactionObject.rawdata.Split('^');
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					for (int i = 0; i < array.Length - 1; i += 2)
					{
						dictionary.Add(array[i], array[i + 1]);
					}
					flag = ((!string.IsNullOrEmpty((from x in dictionary
						where x.Key == "responsecode"
						select x into y
						select y.Value).FirstOrDefault())) ? true : false);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				CloverTransactionObject.Request request = new CloverTransactionObject.Request();
				request.RequestType = "ping";
				MemoryLoadedObjects.Clover.IP = ((Control)(object)txtServer).Text.Trim();
				MemoryLoadedObjects.Clover.port = ((Control)(object)txtPort).Text.Trim();
				MemoryLoadedObjects.Clover.deviceSerialNumber = ((Control)(object)txtSerialNumber).Text.Trim();
				frmWaitingPaymentTerminal obj2 = new frmWaitingPaymentTerminal(ddlProcessor.Text, ddlTerminalModel.Text, text, result, request, "");
				obj2.ShowDialog();
				PaymentTransactionObject paymentTransactionObject2 = obj2.transaction_objects.FirstOrDefault();
				if (paymentTransactionObject2 != null && !paymentTransactionObject2.rawdata.ToLower().Contains("timed out") && !paymentTransactionObject2.rawdata.ToLower().Contains(HipposTransactionErrorMessages.staff_cancelled))
				{
					flag = true;
					btnSave_Click(this, e);
				}
			}
		}
		else
		{
			Terminal terminal = new Terminal();
			terminal.PaymentProviderName = ddlProcessor.Text;
			terminal.PaymentMerchantID = ((Control)(object)txtMerchantID).Text;
			terminal.PaymentTerminalAddress = text;
			terminal.PaymentTerminalModel = ddlTerminalModel.Text;
			terminal.PaymentTerminalPort = result;
			flag = UIPaymentHelper.PingIngenico(ddlProcessor.Text, this, terminal);
		}
		if (btnTest.Text == "TEST")
		{
			if (flag)
			{
				new frmMessageBox(Resources.Connection_was_successful, Resources.Payment_Terminal_Test, CustomMessageBoxButtons.Ok).ShowDialog();
			}
			else
			{
				new frmMessageBox(Resources.Test_failed, Resources.Payment_Terminal_Test, CustomMessageBoxButtons.Ok).ShowDialog();
			}
		}
		else if (flag)
		{
			new frmMessageBox(Resources.Connection_was_successful, Resources.Payment_Terminal_Test, CustomMessageBoxButtons.Ok).ShowDialog();
		}
		else
		{
			new frmMessageBox(Resources.Test_failed, Resources.Payment_Terminal_Test, CustomMessageBoxButtons.Ok).ShowDialog();
		}
	}

	private bool method_3()
	{
		if (ddlProcessor.Text.ToUpper() == "NONE")
		{
			new frmMessageBox("Please select a Provider.").ShowDialog();
			return false;
		}
		if (string.IsNullOrEmpty(ddlTerminalModel.Text))
		{
			new frmMessageBox("Please add a Model No.").ShowDialog();
			return false;
		}
		if (string.IsNullOrEmpty(((Control)(object)txtMerchantID).Text))
		{
			new frmMessageBox("Please add a Merchant Id.").ShowDialog();
			return false;
		}
		if (string.IsNullOrEmpty(((Control)(object)txtServer).Text))
		{
			new frmMessageBox("Please add a Terminal IP/Server.").ShowDialog();
			return false;
		}
		if (string.IsNullOrEmpty(((Control)(object)txtPort).Text))
		{
			new frmMessageBox("Please add a Port.").ShowDialog();
			return false;
		}
		return true;
	}

	private void btnShowKeyboard_MerchantID_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Merchant_ID, 0, 128, ((Control)(object)txtMerchantID).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtMerchantID).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void ddlProcessor_SelectedIndexChanged(object sender, EventArgs e)
	{
		ddlTerminalModel.Items.Clear();
		if (ddlProcessor.Text == "None")
		{
			ddlTerminalModel.Text = string.Empty;
			RadTextBoxControl obj = txtMerchantID;
			RadTextBoxControl obj2 = txtPort;
			RadTextBoxControl obj3 = txtServer;
			string text = (((Control)(object)txtSerialNumber).Text = string.Empty);
			string text3 = (((Control)(object)obj3).Text = text);
			string text6 = (((Control)(object)obj).Text = (((Control)(object)obj2).Text = text3));
		}
		else if (ddlProcessor.Text == "First Data")
		{
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Clover.Flex);
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.iCT250);
		}
		else if (ddlProcessor.Text == "Moneris")
		{
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.iCT250);
		}
		else if (!(ddlProcessor.Text == "Chase") && !(ddlProcessor.Text == "TD"))
		{
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.iCT250);
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.Desk5000);
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.Move5000);
		}
		else
		{
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.Desk5000);
			ddlTerminalModel.Items.Add(PaymentTerminalModels.Ingenico.Move5000);
		}
	}

	private void ddlTerminalModel_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlTerminalModel.Text == PaymentTerminalModels.Clover.Flex)
		{
			btnTest.Text = "PAIR";
		}
		else
		{
			btnTest.Text = "TEST";
		}
	}

	private void btnShowKeyboard_SerialNumber_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter Payment Terminal Serial Number", 0, 20, ((Control)(object)txtSerialNumber).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSerialNumber).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSettingsPaymentProcessor));
		btnTest = new Button();
		label4 = new Label();
		txtPort = new RadTextBoxControl();
		btnShowKeyboard_Port = new Button();
		label3 = new Label();
		label2 = new Label();
		label1 = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		txtServer = new RadTextBoxControl();
		btnShowKeyboard_Server = new Button();
		label5 = new Label();
		label6 = new Label();
		txtStation = new RadTextBoxControl();
		ddlProcessor = new Class19();
		ddlTerminalModel = new Class19();
		txtMerchantID = new RadTextBoxControl();
		btnShowKeyboard_MerchantID = new Button();
		label7 = new Label();
		txtSerialNumber = new RadTextBoxControl();
		btnShowKeyboard_SerialNumber = new Button();
		label10 = new Label();
		((ISupportInitialize)txtPort).BeginInit();
		((ISupportInitialize)txtServer).BeginInit();
		((ISupportInitialize)txtStation).BeginInit();
		((ISupportInitialize)txtMerchantID).BeginInit();
		((ISupportInitialize)txtSerialNumber).BeginInit();
		SuspendLayout();
		btnTest.BackColor = Color.FromArgb(50, 119, 155);
		btnTest.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnTest, "btnTest");
		btnTest.ForeColor = SystemColors.Control;
		btnTest.Name = "btnTest";
		btnTest.Tag = "product";
		btnTest.UseVisualStyleBackColor = false;
		btnTest.Click += btnTest_Click;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		componentResourceManager.ApplyResources(txtPort, "txtPort");
		((Control)(object)txtPort).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtPort).Name = "txtPort";
		((RadElement)((RadControl)txtPort).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtPort).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtPort).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Port.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Port.DialogResult = DialogResult.OK;
		btnShowKeyboard_Port.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Port.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Port, "btnShowKeyboard_Port");
		btnShowKeyboard_Port.ForeColor = Color.White;
		btnShowKeyboard_Port.Name = "btnShowKeyboard_Port";
		btnShowKeyboard_Port.UseVisualStyleBackColor = false;
		btnShowKeyboard_Port.Click += btnShowKeyboard_Port_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(label2, "label2");
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.ForeColor = Color.White;
		label2.Name = "label2";
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
		componentResourceManager.ApplyResources(label5, "label5");
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		componentResourceManager.ApplyResources(label6, "label6");
		label6.BackColor = Color.FromArgb(132, 146, 146);
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(txtStation, "txtStation");
		((Control)(object)txtStation).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtStation).Name = "txtStation";
		((RadElement)((RadControl)txtStation).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtStation).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtStation).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		ddlProcessor.BackColor = Color.White;
		ddlProcessor.DrawMode = DrawMode.OwnerDrawVariable;
		ddlProcessor.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlProcessor, "ddlProcessor");
		ddlProcessor.ForeColor = Color.FromArgb(40, 40, 40);
		ddlProcessor.FormattingEnabled = true;
		ddlProcessor.Items.AddRange(new object[7]
		{
			componentResourceManager.GetString("ddlProcessor.Items"),
			componentResourceManager.GetString("ddlProcessor.Items1"),
			componentResourceManager.GetString("ddlProcessor.Items2"),
			componentResourceManager.GetString("ddlProcessor.Items3"),
			componentResourceManager.GetString("ddlProcessor.Items4"),
			componentResourceManager.GetString("ddlProcessor.Items5"),
			componentResourceManager.GetString("ddlProcessor.Items6")
		});
		ddlProcessor.Name = "ddlProcessor";
		ddlProcessor.Tag = "payment_processor";
		ddlProcessor.SelectedIndexChanged += ddlProcessor_SelectedIndexChanged;
		ddlTerminalModel.BackColor = Color.White;
		ddlTerminalModel.DrawMode = DrawMode.OwnerDrawVariable;
		ddlTerminalModel.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(ddlTerminalModel, "ddlTerminalModel");
		ddlTerminalModel.ForeColor = Color.FromArgb(40, 40, 40);
		ddlTerminalModel.FormattingEnabled = true;
		ddlTerminalModel.Items.AddRange(new object[1] { componentResourceManager.GetString("ddlTerminalModel.Items") });
		ddlTerminalModel.Name = "ddlTerminalModel";
		ddlTerminalModel.Tag = "groups_number_of_columns";
		ddlTerminalModel.SelectedIndexChanged += ddlTerminalModel_SelectedIndexChanged;
		componentResourceManager.ApplyResources(txtMerchantID, "txtMerchantID");
		((Control)(object)txtMerchantID).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtMerchantID).Name = "txtMerchantID";
		((RadElement)((RadControl)txtMerchantID).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtMerchantID).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtMerchantID).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_MerchantID.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_MerchantID.DialogResult = DialogResult.OK;
		btnShowKeyboard_MerchantID.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_MerchantID.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_MerchantID, "btnShowKeyboard_MerchantID");
		btnShowKeyboard_MerchantID.ForeColor = Color.White;
		btnShowKeyboard_MerchantID.Name = "btnShowKeyboard_MerchantID";
		btnShowKeyboard_MerchantID.UseVisualStyleBackColor = false;
		btnShowKeyboard_MerchantID.Click += btnShowKeyboard_MerchantID_Click;
		componentResourceManager.ApplyResources(label7, "label7");
		label7.BackColor = Color.FromArgb(132, 146, 146);
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		componentResourceManager.ApplyResources(txtSerialNumber, "txtSerialNumber");
		((Control)(object)txtSerialNumber).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtSerialNumber).Name = "txtSerialNumber";
		((RadElement)((RadControl)txtSerialNumber).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSerialNumber).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSerialNumber).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_SerialNumber.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SerialNumber.DialogResult = DialogResult.OK;
		btnShowKeyboard_SerialNumber.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SerialNumber.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SerialNumber, "btnShowKeyboard_SerialNumber");
		btnShowKeyboard_SerialNumber.ForeColor = Color.White;
		btnShowKeyboard_SerialNumber.Name = "btnShowKeyboard_SerialNumber";
		btnShowKeyboard_SerialNumber.UseVisualStyleBackColor = false;
		btnShowKeyboard_SerialNumber.Click += btnShowKeyboard_SerialNumber_Click;
		label10.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		base.AutoScaleMode = AutoScaleMode.None;
		BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(this, "$this");
		base.Controls.Add((Control)(object)txtSerialNumber);
		base.Controls.Add(btnShowKeyboard_SerialNumber);
		base.Controls.Add(label10);
		base.Controls.Add((Control)(object)txtMerchantID);
		base.Controls.Add(btnShowKeyboard_MerchantID);
		base.Controls.Add(label7);
		base.Controls.Add(ddlTerminalModel);
		base.Controls.Add(ddlProcessor);
		base.Controls.Add((Control)(object)txtStation);
		base.Controls.Add(label6);
		base.Controls.Add((Control)(object)txtServer);
		base.Controls.Add(btnShowKeyboard_Server);
		base.Controls.Add(label5);
		base.Controls.Add(btnTest);
		base.Controls.Add(label4);
		base.Controls.Add((Control)(object)txtPort);
		base.Controls.Add(btnShowKeyboard_Port);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmSettingsPaymentProcessor";
		base.Opacity = 1.0;
		base.Load += frmSettingsPaymentProcessor_Load;
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(btnSave, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Port, 0);
		base.Controls.SetChildIndex((Control)(object)txtPort, 0);
		base.Controls.SetChildIndex(label4, 0);
		base.Controls.SetChildIndex(btnTest, 0);
		base.Controls.SetChildIndex(label5, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Server, 0);
		base.Controls.SetChildIndex((Control)(object)txtServer, 0);
		base.Controls.SetChildIndex(label6, 0);
		base.Controls.SetChildIndex((Control)(object)txtStation, 0);
		base.Controls.SetChildIndex(ddlProcessor, 0);
		base.Controls.SetChildIndex(ddlTerminalModel, 0);
		base.Controls.SetChildIndex(label7, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_MerchantID, 0);
		base.Controls.SetChildIndex((Control)(object)txtMerchantID, 0);
		base.Controls.SetChildIndex(label10, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_SerialNumber, 0);
		base.Controls.SetChildIndex((Control)(object)txtSerialNumber, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		((ISupportInitialize)txtPort).EndInit();
		((ISupportInitialize)txtServer).EndInit();
		((ISupportInitialize)txtStation).EndInit();
		((ISupportInitialize)txtMerchantID).EndInit();
		((ISupportInitialize)txtSerialNumber).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
