using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Methods.PaymentProcessors;
using CorePOS.Business.Objects;
using CorePOS.Properties;

namespace CorePOS;

public class frmNumpad : frmMasterForm
{
	[CompilerGenerated]
	private decimal decimal_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_0;

	private string string_1;

	private int int_0;

	private string string_2;

	private bool bool_1;

	private int int_1;

	private string string_3;

	private SerialPort serialPort_0;

	private string string_4;

	private int int_2;

	private bool bool_2;

	private string string_5;

	private bool bool_3;

	private bool bool_4;

	private char char_0;

	private char char_1;

	private string string_6;

	private string string_7;

	private IContainer icontainer_1;

	internal TextBox txtInput;

	internal Button btnCancel;

	internal Button btnDone;

	internal Button btnDelete;

	internal Button ButtonDecimal;

	internal Button Button3;

	internal Button Button2;

	internal Button Button1;

	internal Button Button6;

	internal Button Button5;

	internal Button Button4;

	internal Button Button0;

	internal Button Button9;

	internal Button Button8;

	internal Button Button7;

	internal Button btnClear;

	private Label lblTitle;

	private PictureBox picLock;

	private Panel panel1;

	private Label sideLabel;

	private PictureBox picPhone;

	private PictureBox picGuest;

	private Label lblTipsPicture;

	internal Button btnPositiveNeg;

	private Label label1;

	private Class17 chkRememberMe;

	private System.Windows.Forms.Timer timer_0;

	public decimal numberEntered
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public string valueEntered
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool showRememberMe
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public string TextInput
	{
		get
		{
			return txtInput.Text;
		}
		set
		{
			txtInput.Text = value;
		}
	}

	public frmNumpad()
	{
		Class26.Ggkj0JxzN9YmC();
		string_1 = string.Empty;
		int_1 = 605;
		string_3 = string.Empty;
		string_4 = string.Empty;
		char_0 = Convert.ToChar(PaymentHelper.HexStringToByteArray("0a")[0]);
		char_1 = Convert.ToChar(PaymentHelper.HexStringToByteArray("0d")[0]);
		string_6 = HWBrands.Scales.Generic;
		string_7 = string.Empty;
		base._002Ector();
		InitializeComponent_1();
	}

	private void method_3(bool bool_5)
	{
		Button button = Button0;
		Button button2 = Button1;
		Button button3 = Button2;
		Button button4 = Button3;
		Button button5 = Button4;
		Button button6 = Button5;
		Button button7 = Button6;
		Button button8 = Button7;
		Button button9 = Button7;
		Button button10 = Button8;
		Button button11 = Button9;
		Button buttonDecimal = ButtonDecimal;
		Button button12 = btnPositiveNeg;
		bool flag2 = (btnDelete.Enabled = bool_5);
		bool flag4 = (button12.Enabled = flag2);
		bool flag6 = (buttonDecimal.Enabled = flag4);
		bool flag8 = (button11.Enabled = flag6);
		bool flag10 = (button10.Enabled = flag8);
		bool flag12 = (button9.Enabled = flag10);
		bool flag14 = (button8.Enabled = flag12);
		bool flag16 = (button7.Enabled = flag14);
		bool flag18 = (button6.Enabled = flag16);
		bool flag20 = (button5.Enabled = flag18);
		bool flag22 = (button4.Enabled = flag20);
		bool flag24 = (button3.Enabled = flag22);
		bool enabled = (button2.Enabled = flag24);
		button.Enabled = enabled;
	}

	public void LoadFormData(string Title, int decimalspaces = 2, int maxchar = 10, string number = "", string errorMessage = "", bool allowNegative = false, bool useNotifLabel = false, bool isPhoneShowInOE = false)
	{
		serialPort_0 = null;
		method_9();
		if (SettingsHelper.GetSettingValueByKey("scale_functionality") == "ON" && (Title.ToUpper().Contains("KG") || Title.ToUpper().Contains("GRAM") || Title.ToUpper().Contains("POUND") || Title.ToUpper().Contains("LB") || Title.ToUpper().Contains("OUNCE")))
		{
			string_5 = Title.Replace("Enter Weight In: ", string.Empty).Trim();
			string_3 = (string_4 = string.Empty);
			int_2 = 0;
			timer_0.Enabled = true;
			bool_2 = true;
			method_3(bool_5: false);
		}
		else
		{
			method_3(bool_5: true);
			timer_0.Enabled = false;
			bool_2 = false;
		}
		int_0 = ((decimalspaces > 0) ? (maxchar + decimalspaces) : maxchar);
		base.TopLevel = true;
		base.TopMost = true;
		Focus();
		bool_3 = isPhoneShowInOE;
		if (isPhoneShowInOE)
		{
			Application.OpenForms.OfType<frmOrderEntryShowItems>().FirstOrDefault()?.ShowPanelNumber(show: true);
		}
		showRememberMe = true;
		string_2 = errorMessage;
		btnPositiveNeg.Enabled = allowNegative;
		Text = Title;
		bool_1 = useNotifLabel;
		txtInput.Text = number;
		lblTitle.Padding = new Padding(0, 0, 0, 0);
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		txtInput.PasswordChar = '\0';
		txtInput.UseSystemPasswordChar = false;
		picLock.Visible = false;
		string_1 = string.Empty;
		if (Title.ToUpper().Contains(Resources.PHONE0))
		{
			showRememberMe = false;
			picPhone.Visible = true;
			lblTitle.Padding = new Padding(60, 0, 0, 0);
			lblTitle.TextAlign = ContentAlignment.MiddleLeft;
			Button button = btnPositiveNeg;
			ButtonDecimal.Enabled = false;
			button.Enabled = false;
		}
		if (Title.ToUpper().Contains(Resources.NUMBER_OF_GUEST))
		{
			showRememberMe = false;
			picGuest.Visible = true;
			lblTitle.Padding = new Padding(60, 0, 0, 0);
			lblTitle.TextAlign = ContentAlignment.MiddleLeft;
			Button button2 = btnPositiveNeg;
			ButtonDecimal.Enabled = false;
			button2.Enabled = false;
		}
		if (!Title.Contains(Resources.PIN_Required) && !Title.Contains(Resources.Please_Enter_PIN) && !Title.Contains(Resources.Enter_PIN) && !Title.Contains("PIN"))
		{
			if (decimalspaces == 0)
			{
				showRememberMe = false;
				if (allowNegative)
				{
					string_1 = "^-?\\d{0," + maxchar + "}?$";
				}
				else
				{
					string_1 = "^\\d{0," + maxchar + "}?$";
				}
				ButtonDecimal.Enabled = false;
			}
			else
			{
				showRememberMe = false;
				if (allowNegative)
				{
					string_1 = "^-?\\d{0," + maxchar + "}(\\.\\d{1," + decimalspaces + "})?$";
				}
				else
				{
					string_1 = "^\\d{0," + maxchar + "}(\\.\\d{1," + decimalspaces + "})?$";
				}
			}
		}
		else
		{
			txtInput.PasswordChar = '*';
			txtInput.UseSystemPasswordChar = true;
			picLock.Visible = true;
			lblTitle.Padding = new Padding(60, 0, 0, 0);
			lblTitle.TextAlign = ContentAlignment.MiddleLeft;
			Button button3 = btnPositiveNeg;
			ButtonDecimal.Enabled = false;
			button3.Enabled = false;
		}
		if (Title.Contains(Resources.Tip_Amount) || Title.Contains(Resources.Price))
		{
			showRememberMe = false;
			sideLabel.BringToFront();
			sideLabel.BackColor = Color.FromName("Window");
			sideLabel.ForeColor = Color.FromArgb(0, 0, 0);
			txtInput.Width = 348;
			txtInput.Location = new Point(41, 66);
			txtInput.TextAlign = HorizontalAlignment.Right;
			if (Title.Contains(Resources.Tip_Amount))
			{
				btnPositiveNeg.Enabled = false;
			}
		}
		if (Title.ToUpper() == Resources.ENTER_TIP_AMOUNT_TO_CLEAR_TABL)
		{
			showRememberMe = false;
			lblTipsPicture.Visible = true;
			lblTitle.Padding = new Padding(50, 0, 0, 0);
			btnPositiveNeg.Enabled = false;
		}
		ButtonDecimal.Text = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
		lblTitle.Text = Title;
	}

	private void method_4()
	{
		if (!bool_2)
		{
			return;
		}
		bool flag = false;
		string_6 = SettingsHelper.GetSettingValueByKey("scale_make");
		try
		{
			string_3 = string.Empty;
			if (serialPort_0 == null)
			{
				serialPort_0 = new SerialPort(MemoryLoadedObjects.scale_comport);
			}
			if (!serialPort_0.IsOpen)
			{
				serialPort_0.BaudRate = 9600;
				serialPort_0.Parity = Parity.None;
				serialPort_0.StopBits = StopBits.One;
				serialPort_0.DataBits = 8;
				serialPort_0.ReceivedBytesThreshold = 12;
				serialPort_0.ReadTimeout = 500;
				serialPort_0.WriteTimeout = 500;
				serialPort_0.ReadBufferSize = 12;
				serialPort_0.DataReceived += serialPort_0_DataReceived;
				serialPort_0.Open();
				serialPort_0.RtsEnable = true;
				serialPort_0.DtrEnable = true;
				if (serialPort_0.IsOpen)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag && string_6 == HWBrands.Scales.Brecknell)
			{
				byte[] array = PaymentHelper.HexStringToByteArray("0d");
				byte[] array2 = PaymentHelper.HexStringToByteArray("57");
				byte[] array3 = new byte[array2.Length + array.Length];
				array2.CopyTo(array3, 0);
				array.CopyTo(array3, array2.Length);
				serialPort_0.Write(array3, 0, array3.Length);
			}
		}
		catch (Exception ex)
		{
			DebugMethods.ShowErrorTextFile(ex.Message);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
		}
		if (!flag)
		{
			if (!bool_4)
			{
				new NotificationLabel(this, "Please check scale COM port settings.", NotificationTypes.Notification).Show();
				method_3(bool_5: true);
			}
			bool_4 = true;
			timer_0.Enabled = false;
			string_3 = string.Empty;
		}
	}

	private void serialPort_0_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		try
		{
			SerialPort serialPort = (SerialPort)sender;
			if (!serialPort.IsOpen || !bool_2)
			{
				return;
			}
			string_3 += serialPort.ReadExisting();
			serialPort.DiscardInBuffer();
			serialPort.DiscardOutBuffer();
			if (string_6 == HWBrands.Scales.Brecknell)
			{
				string_7 = string.Empty;
				string text = string_3;
				for (int i = 0; i < text.Length; i++)
				{
					char c2 = text[i];
					if (c2 != char_0)
					{
						string_7 += c2;
					}
					else if (c2 == char_1)
					{
						break;
					}
				}
				string_7 = method_5(new string(string_7.Where((char c) => char.IsDigit(c) || c == '.').ToArray()));
				string_3 = string.Empty;
				return;
			}
			string_3 = string_3.Replace("00.", "0.");
			string_3 = string_3.Replace(Convert.ToChar(32).ToString(), string.Empty);
			string_3 = string_3.Replace(Convert.ToChar(1).ToString(), string.Empty);
			string_3 = string_3.Replace(Convert.ToChar(2).ToString(), string.Empty);
			string_3 = string_3.Replace(Convert.ToChar(83).ToString(), string.Empty);
			string_3 = string_3.Replace(Convert.ToChar(115).ToString(), string.Empty);
			if (!string_3.Contains(".") && string_3.Contains("\n\r"))
			{
				string_3 = string_3.Replace("\n\r", string.Empty);
				string_3 = (Convert.ToDecimal(string_3) / 1000m).ToString();
			}
			string_3 = Regex.Replace(string_3, "[^\\u0020-\\u007F]", string.Empty);
			string_7 = method_5(new string(string_3.Where((char c) => char.IsDigit(c) || c == '.').ToArray()));
			if (Convert.ToDecimal(string_7) == 0m)
			{
				string_4 = string.Empty;
			}
			if (string_4 != string_7)
			{
				string_4 = string_7;
				int_2 = 0;
				try
				{
					Invoke((MethodInvoker)delegate
					{
						txtInput.Text = string_7;
					});
				}
				catch
				{
				}
				string_3 = string.Empty;
			}
			else
			{
				string_3 = string.Empty;
				if (int_2 == 5 && base.Visible)
				{
					Console.Beep(3000, 500);
				}
				int_2++;
			}
		}
		catch (Exception ex)
		{
			DebugMethods.ShowErrorTextFile(ex.Message);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			if (!bool_4)
			{
				new NotificationLabel(this, "Please check scale COM port settings.", NotificationTypes.Notification).Show();
				method_3(bool_5: true);
			}
		}
	}

	private string method_5(string string_8)
	{
		try
		{
			string settingValueByKey = SettingsHelper.GetSettingValueByKey("scale_uom");
			if (string_5.ToUpper().Contains(settingValueByKey))
			{
				return float.Parse(string_8).ToString();
			}
			decimal num = Convert.ToDecimal(string_8);
			if (settingValueByKey.Equals("GRAM"))
			{
				num /= 1000m;
			}
			else if (!settingValueByKey.Equals("LB") && !settingValueByKey.Equals("POUND"))
			{
				if (settingValueByKey.Equals("OUNCE"))
				{
					num /= 35.27396195m;
				}
			}
			else
			{
				num /= 2.20462262185m;
			}
			if (lblTitle.Text.ToUpper().Contains("GRAM"))
			{
				num *= 1000m;
			}
			else if (!lblTitle.Text.ToUpper().Contains("LB") && !lblTitle.Text.ToUpper().Contains("POUND"))
			{
				if (settingValueByKey.Equals("OUNCE"))
				{
					num *= 35.27396195m;
				}
			}
			else
			{
				num *= 2.20462262185m;
			}
			if (num.ToString().Contains("."))
			{
				string[] array = num.ToString().Split('.');
				return array[0] + "." + array[1].Substring(0, (array[1].Length > 4) ? 4 : array[1].Length);
			}
			return num.ToString();
		}
		catch
		{
			return "0.0000";
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		base.OnFormClosing(e);
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
	}

	private void method_6()
	{
		label1.Visible = false;
		chkRememberMe.Visible = false;
		base.Size = new Size(base.Width, int_1 - label1.Height + 4);
	}

	private void method_7()
	{
		label1.Visible = true;
		chkRememberMe.Visible = true;
		base.Size = new Size(base.Width, int_1);
	}

	private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btnDone.PerformClick();
		}
	}

	private void method_8()
	{
		if (serialPort_0 != null)
		{
			try
			{
				serialPort_0.DiscardInBuffer();
				serialPort_0.DiscardOutBuffer();
				serialPort_0.Close();
				serialPort_0.Dispose();
				string_4 = string.Empty;
				GC.Collect();
			}
			catch (Exception ex)
			{
				string_4 = string.Empty;
				LogHelper.WriteLog(ex.Message, LogTypes.error_log);
			}
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		if (txtInput.SelectionLength > 0)
		{
			txtInput.Text = string.Empty;
		}
		if (txtInput.Text.Length < int_0)
		{
			Button button = (Button)sender;
			txtInput.Text += button.Text;
			txtInput.Focus();
			txtInput.SelectionStart = txtInput.Text.Length;
			txtInput.SelectionLength = 0;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		method_8();
		Application.OpenForms.OfType<frmOrderEntryShowItems>().FirstOrDefault()?.ShowPanelNumber(show: false);
		MemoryLoadedObjects.isUserRemember = false;
		((frmSplash)Application.OpenForms["frmSplash"])?.SetBtnLogOutText("");
		GC.Collect();
		Hide();
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		try
		{
			method_8();
			Application.OpenForms.OfType<frmOrderEntryShowItems>().FirstOrDefault()?.ShowPanelNumber(show: false);
			decimal result = default(decimal);
			if (txtInput.Text.Length > int_0)
			{
				if (!bool_1)
				{
					new frmMessageBox(string.IsNullOrEmpty(string_2) ? "Input is too long/large." : string_2).Show(this);
				}
				else
				{
					new NotificationLabel(this, string.IsNullOrEmpty(string_2) ? "Input is too long/large." : string_2, NotificationTypes.Warning, 1);
				}
				if (lblTitle.Text.Contains("PIN"))
				{
					txtInput.Text = string.Empty;
				}
			}
			else if (txtInput.Text != string.Empty && decimal.TryParse(txtInput.Text, NumberStyles.Float, Thread.CurrentThread.CurrentCulture, out result))
			{
				if (!new Regex(string_1).Match(txtInput.Text.Replace(",", ".")).Success)
				{
					if (!bool_1)
					{
						new frmMessageBox(string.IsNullOrEmpty(string_2) ? Resources.The_input_text_is_not_valid : string_2).Show(this);
					}
					else
					{
						new NotificationLabel(this, string.IsNullOrEmpty(string_2) ? Resources.The_input_text_is_not_valid : string_2, NotificationTypes.Warning, 1);
					}
					if (lblTitle.Text.Contains("PIN"))
					{
						txtInput.Text = string.Empty;
					}
					return;
				}
				numberEntered = result;
				valueEntered = txtInput.Text;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				if (!bool_1)
				{
					new frmMessageBox(string.IsNullOrEmpty(string_2) ? Resources.The_input_text_is_not_valid : string_2).Show(this);
				}
				else
				{
					new NotificationLabel(this, string.IsNullOrEmpty(string_2) ? Resources.The_input_text_is_not_valid : string_2, NotificationTypes.Warning, 1);
				}
				if (lblTitle.Text.Contains("PIN"))
				{
					txtInput.Text = string.Empty;
				}
			}
			if (lblTitle.Text.Contains(Resources.PIN_Required) || lblTitle.Text.Contains(Resources.Please_Enter_PIN) || lblTitle.Text.Contains(Resources.Enter_PIN) || lblTitle.Text.Contains("PIN"))
			{
				frmSplash frmSplash2 = (frmSplash)Application.OpenForms["frmSplash"];
				if (chkRememberMe.Checked)
				{
					MemoryLoadedObjects.isUserRemember = true;
					frmSplash2?.SetBtnLogOutText("LOG ME OUT");
				}
				else
				{
					MemoryLoadedObjects.isUserRemember = false;
					frmSplash2?.SetBtnLogOutText("");
				}
			}
		}
		catch (Exception ex)
		{
			DebugMethods.ShowErrorTextFile(ex.Message);
			LogHelper.WriteLog(ex.Message, LogTypes.error_log);
		}
		if (!base.IsDisposed)
		{
			Hide();
		}
	}

	private void method_9()
	{
		lblTitle.Padding = new Padding(60, 0, 0, 0);
		lblTitle.TextAlign = ContentAlignment.MiddleLeft;
		Label label = lblTipsPicture;
		PictureBox pictureBox = picLock;
		PictureBox pictureBox2 = picGuest;
		picPhone.Visible = false;
		pictureBox2.Visible = false;
		pictureBox.Visible = false;
		label.Visible = false;
		Button button = btnPositiveNeg;
		ButtonDecimal.Enabled = true;
		button.Enabled = true;
		txtInput.UseSystemPasswordChar = false;
		sideLabel.SendToBack();
		txtInput.Width = 384;
		txtInput.Location = new Point(5, 66);
		txtInput.TextAlign = HorizontalAlignment.Left;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		if (txtInput.TextLength != 0 && selectionStart != 0)
		{
			txtInput.Text = txtInput.Text.Remove(selectionStart - 1, 1);
			txtInput.SelectionStart = selectionStart - 1;
			txtInput.SelectionLength = 0;
		}
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		txtInput.Text = string.Empty;
		txtInput.Select();
		method_4();
	}

	private void frmNumpad_Load(object sender, EventArgs e)
	{
		panel1.Location = new Point(base.Width / 2 - panel1.Width / 2, base.Height / 2 - panel1.Height / 2);
		if (!showRememberMe)
		{
			method_6();
		}
		else
		{
			method_7();
		}
		txtInput.Select();
		method_4();
	}

	private void method_10(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		txtInput.SelectionStart = ((selectionStart != 0) ? (selectionStart - 1) : 0);
		txtInput.SelectionLength = 0;
		txtInput.Focus();
	}

	private void method_11(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		txtInput.SelectionStart = ((selectionStart == txtInput.Text.Length) ? txtInput.Text.Length : (selectionStart + 1));
		txtInput.SelectionLength = 0;
		txtInput.Focus();
	}

	private void btnPositiveNeg_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtInput.Text))
		{
			try
			{
				txtInput.Text = (-1m * Convert.ToDecimal(txtInput.Text, Thread.CurrentThread.CurrentCulture)).ToString();
			}
			catch (Exception ex)
			{
				new NotificationLabel(this, ex.Message, NotificationTypes.Warning).Show();
			}
		}
	}

	private void txtInput_TextChanged(object sender, EventArgs e)
	{
		if (bool_3)
		{
			Application.OpenForms.OfType<frmOrderEntryShowItems>().FirstOrDefault()?.ChangePhoneNumber(txtInput.Text);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		method_4();
		txtInput.Text = string_7.ToString();
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmNumpad));
		panel1 = new Panel();
		chkRememberMe = new Class17();
		btnPositiveNeg = new Button();
		label1 = new Label();
		lblTipsPicture = new Label();
		picPhone = new PictureBox();
		picGuest = new PictureBox();
		picLock = new PictureBox();
		Button7 = new Button();
		lblTitle = new Label();
		Button8 = new Button();
		btnClear = new Button();
		Button9 = new Button();
		txtInput = new TextBox();
		Button0 = new Button();
		btnCancel = new Button();
		Button4 = new Button();
		btnDone = new Button();
		Button5 = new Button();
		btnDelete = new Button();
		Button6 = new Button();
		ButtonDecimal = new Button();
		Button1 = new Button();
		Button3 = new Button();
		Button2 = new Button();
		sideLabel = new Label();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		panel1.SuspendLayout();
		((ISupportInitialize)picPhone).BeginInit();
		((ISupportInitialize)picGuest).BeginInit();
		((ISupportInitialize)picLock).BeginInit();
		SuspendLayout();
		panel1.BackColor = Color.FromArgb(35, 39, 56);
		panel1.Controls.Add(chkRememberMe);
		panel1.Controls.Add(btnPositiveNeg);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(lblTipsPicture);
		panel1.Controls.Add(picPhone);
		panel1.Controls.Add(picGuest);
		panel1.Controls.Add(picLock);
		panel1.Controls.Add(Button7);
		panel1.Controls.Add(lblTitle);
		panel1.Controls.Add(Button8);
		panel1.Controls.Add(btnClear);
		panel1.Controls.Add(Button9);
		panel1.Controls.Add(txtInput);
		panel1.Controls.Add(Button0);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(Button4);
		panel1.Controls.Add(btnDone);
		panel1.Controls.Add(Button5);
		panel1.Controls.Add(btnDelete);
		panel1.Controls.Add(Button6);
		panel1.Controls.Add(ButtonDecimal);
		panel1.Controls.Add(Button1);
		panel1.Controls.Add(Button3);
		panel1.Controls.Add(Button2);
		panel1.Controls.Add(sideLabel);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(chkRememberMe, "chkRememberMe");
		chkRememberMe.Name = "chkRememberMe";
		chkRememberMe.UseVisualStyleBackColor = true;
		btnPositiveNeg.BackColor = Color.FromArgb(118, 130, 130);
		btnPositiveNeg.FlatAppearance.BorderColor = Color.Black;
		btnPositiveNeg.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnPositiveNeg, "btnPositiveNeg");
		btnPositiveNeg.ForeColor = Color.White;
		btnPositiveNeg.Name = "btnPositiveNeg";
		btnPositiveNeg.UseVisualStyleBackColor = false;
		btnPositiveNeg.Click += btnPositiveNeg_Click;
		label1.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		lblTipsPicture.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTipsPicture, "lblTipsPicture");
		lblTipsPicture.ForeColor = Color.FromArgb(64, 64, 64);
		lblTipsPicture.Name = "lblTipsPicture";
		picPhone.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(picPhone, "picPhone");
		picPhone.Name = "picPhone";
		picPhone.TabStop = false;
		picGuest.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(picGuest, "picGuest");
		picGuest.Name = "picGuest";
		picGuest.TabStop = false;
		picLock.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(picLock, "picLock");
		picLock.Name = "picLock";
		picLock.TabStop = false;
		Button7.BackColor = Color.FromArgb(164, 181, 181);
		Button7.FlatAppearance.BorderColor = Color.Black;
		Button7.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button7, "Button7");
		Button7.ForeColor = Color.White;
		Button7.Name = "Button7";
		Button7.UseVisualStyleBackColor = false;
		Button7.Click += Button2_Click;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		Button8.BackColor = Color.FromArgb(164, 181, 181);
		Button8.FlatAppearance.BorderColor = Color.Black;
		Button8.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button8, "Button8");
		Button8.ForeColor = Color.White;
		Button8.Name = "Button8";
		Button8.UseVisualStyleBackColor = false;
		Button8.Click += Button2_Click;
		btnClear.BackColor = Color.FromArgb(77, 174, 225);
		btnClear.FlatAppearance.BorderColor = Color.Black;
		btnClear.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.Click += btnClear_Click;
		Button9.BackColor = Color.FromArgb(164, 181, 181);
		Button9.FlatAppearance.BorderColor = Color.Black;
		Button9.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button9, "Button9");
		Button9.ForeColor = Color.White;
		Button9.Name = "Button9";
		Button9.UseVisualStyleBackColor = false;
		Button9.Click += Button2_Click;
		txtInput.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtInput, "txtInput");
		txtInput.Name = "txtInput";
		txtInput.TextChanged += txtInput_TextChanged;
		txtInput.KeyPress += txtInput_KeyPress;
		Button0.BackColor = Color.FromArgb(118, 130, 130);
		Button0.FlatAppearance.BorderColor = Color.Black;
		Button0.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button0, "Button0");
		Button0.ForeColor = Color.White;
		Button0.Name = "Button0";
		Button0.UseVisualStyleBackColor = false;
		Button0.Click += Button2_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		Button4.BackColor = Color.FromArgb(150, 166, 166);
		Button4.FlatAppearance.BorderColor = Color.Black;
		Button4.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button4, "Button4");
		Button4.ForeColor = Color.White;
		Button4.Name = "Button4";
		Button4.UseVisualStyleBackColor = false;
		Button4.Click += Button2_Click;
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.FlatAppearance.BorderColor = Color.Black;
		btnDone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		Button5.BackColor = Color.FromArgb(150, 166, 166);
		Button5.FlatAppearance.BorderColor = Color.Black;
		Button5.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button5, "Button5");
		Button5.ForeColor = Color.White;
		Button5.Name = "Button5";
		Button5.UseVisualStyleBackColor = false;
		Button5.Click += Button2_Click;
		btnDelete.BackColor = Color.FromArgb(61, 142, 185);
		btnDelete.FlatAppearance.BorderColor = Color.Black;
		btnDelete.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDelete, "btnDelete");
		btnDelete.ForeColor = Color.White;
		btnDelete.Name = "btnDelete";
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		Button6.BackColor = Color.FromArgb(150, 166, 166);
		Button6.FlatAppearance.BorderColor = Color.Black;
		Button6.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button6, "Button6");
		Button6.ForeColor = Color.White;
		Button6.Name = "Button6";
		Button6.UseVisualStyleBackColor = false;
		Button6.Click += Button2_Click;
		ButtonDecimal.BackColor = Color.FromArgb(118, 130, 130);
		ButtonDecimal.FlatAppearance.BorderColor = Color.Black;
		ButtonDecimal.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonDecimal, "ButtonDecimal");
		ButtonDecimal.ForeColor = Color.White;
		ButtonDecimal.Name = "ButtonDecimal";
		ButtonDecimal.UseVisualStyleBackColor = false;
		ButtonDecimal.Click += Button2_Click;
		Button1.BackColor = Color.FromArgb(132, 146, 146);
		Button1.FlatAppearance.BorderColor = Color.Black;
		Button1.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button1, "Button1");
		Button1.ForeColor = Color.White;
		Button1.Name = "Button1";
		Button1.UseVisualStyleBackColor = false;
		Button1.Click += Button2_Click;
		Button3.BackColor = Color.FromArgb(132, 146, 146);
		Button3.FlatAppearance.BorderColor = Color.Black;
		Button3.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button3, "Button3");
		Button3.ForeColor = Color.White;
		Button3.Name = "Button3";
		Button3.UseVisualStyleBackColor = false;
		Button3.Click += Button2_Click;
		Button2.BackColor = Color.FromArgb(132, 146, 146);
		Button2.FlatAppearance.BorderColor = Color.Black;
		Button2.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button2, "Button2");
		Button2.ForeColor = Color.White;
		Button2.Name = "Button2";
		Button2.UseVisualStyleBackColor = false;
		Button2.Click += Button2_Click;
		sideLabel.BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(sideLabel, "sideLabel");
		sideLabel.ForeColor = Color.White;
		sideLabel.Name = "sideLabel";
		timer_0.Interval = 300;
		timer_0.Tick += timer_0_Tick;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(panel1);
		base.Name = "frmNumpad";
		base.Opacity = 1.0;
		base.TopMost = true;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmNumpad_Load;
		base.Controls.SetChildIndex(panel1, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		((ISupportInitialize)picPhone).EndInit();
		((ISupportInitialize)picGuest).EndInit();
		((ISupportInitialize)picLock).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void method_12()
	{
		txtInput.Text = string_7;
	}
}
