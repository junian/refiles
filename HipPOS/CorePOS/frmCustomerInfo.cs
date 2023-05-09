using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmCustomerInfo : frmMasterForm
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private IContainer qqIeoyAjAu;

	private Label lblWIndowTitle;

	private Panel panel1;

	internal Button btnSaveOrder;

	internal Button BtnCancel;

	private RadTextBoxControl txtAddress;

	internal Button btnShowKeyboard_Address;

	private Label label2;

	private RadTextBoxControl txtPhone;

	internal Button btnShowKeyboard_Phone;

	private Label label1;

	private RadTextBoxControl txtName;

	internal Button btnShowKeyboard_Name;

	private Label lblMemberNo;

	public frmCustomerInfo(string customerName, string customerPhone, string customerAddress)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = string.Empty;
		string_1 = string.Empty;
		string_2 = string.Empty;
		string_3 = string.Empty;
		string_4 = string.Empty;
		string_5 = string.Empty;
		// base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			btnSaveOrder.Font = new Font(btnSaveOrder.Font.FontFamily, btnSaveOrder.Font.Size - 3f);
		}
		if (customerPhone == "Walk In")
		{
			txtName.Text = customerPhone;
			txtPhone.Text = "";
		}
		else
		{
			txtName.Text = customerName;
			txtPhone.Text = customerPhone;
		}
		txtAddress.Text = customerAddress;
		string_3 = customerName;
		string_4 = customerPhone;
		string_5 = customerAddress;
		btnSaveOrder.Enabled = false;
	}

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Name0, 0, 64, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Phone_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Phone_Number, 0, 20, txtPhone.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtPhone.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Address_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Address, 0, 128, txtAddress.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtAddress.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void btnSaveOrder_Click(object sender, EventArgs e)
	{
		string_0 = txtName.Text;
		string_1 = txtPhone.Text;
		string_2 = txtAddress.Text;
		if (!string.IsNullOrEmpty(string_1) && string_1.Length < 4)
		{
			new frmMessageBox(Resources.Phone_number_must_be_a_minimum, Resources.Invalid_Input).ShowDialog(this);
		}
		else if (!(string_2 != string_5) && !(string_1 != string_4) && !(string_0 != string_3))
		{
			base.DialogResult = DialogResult.Cancel;
		}
		else
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	private void txtName_TextChanged(object sender, EventArgs e)
	{
		btnSaveOrder.Enabled = true;
	}

	public string getCustomerName()
	{
		return string_0;
	}

	public string getCustomerPhone()
	{
		return string_1;
	}

	public string getCustomerAddress()
	{
		return string_2;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && qqIeoyAjAu != null)
		{
			qqIeoyAjAu.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCustomerInfo));
		panel1 = new Panel();
		btnSaveOrder = new Button();
		BtnCancel = new Button();
		txtAddress = new RadTextBoxControl();
		btnShowKeyboard_Address = new Button();
		label2 = new Label();
		txtPhone = new RadTextBoxControl();
		btnShowKeyboard_Phone = new Button();
		label1 = new Label();
		txtName = new RadTextBoxControl();
		btnShowKeyboard_Name = new Button();
		lblMemberNo = new Label();
		lblWIndowTitle = new Label();
		panel1.SuspendLayout();
		((ISupportInitialize)txtAddress).BeginInit();
		((ISupportInitialize)txtPhone).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(btnSaveOrder);
		panel1.Controls.Add(BtnCancel);
		panel1.Controls.Add(txtAddress);
		panel1.Controls.Add(btnShowKeyboard_Address);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(txtPhone);
		panel1.Controls.Add(btnShowKeyboard_Phone);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(txtName);
		panel1.Controls.Add(btnShowKeyboard_Name);
		panel1.Controls.Add(lblMemberNo);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		btnSaveOrder.BackColor = Color.FromArgb(65, 168, 95);
		btnSaveOrder.FlatAppearance.BorderColor = Color.Black;
		btnSaveOrder.FlatAppearance.BorderSize = 0;
		btnSaveOrder.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSaveOrder, "btnSaveOrder");
		btnSaveOrder.ForeColor = Color.White;
		btnSaveOrder.Name = "btnSaveOrder";
		btnSaveOrder.UseVisualStyleBackColor = false;
		btnSaveOrder.Click += btnSaveOrder_Click;
		BtnCancel.BackColor = Color.FromArgb(235, 107, 86);
		BtnCancel.FlatAppearance.BorderColor = Color.Sienna;
		BtnCancel.FlatAppearance.BorderSize = 0;
		BtnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		BtnCancel.ForeColor = Color.White;
		BtnCancel.Name = "BtnCancel";
		BtnCancel.UseVisualStyleBackColor = false;
		BtnCancel.Click += BtnCancel_Click;
		componentResourceManager.ApplyResources(txtAddress, "txtAddress");
		txtAddress.ForeColor = Color.FromArgb(40, 40, 40);
		txtAddress.Name = "txtAddress";
		txtAddress.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtAddress.TextChanged += txtName_TextChanged;
		txtAddress.Click += txtName_Click;
		((RadTextBoxControlElement)txtAddress.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtAddress.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Address.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Address.DialogResult = DialogResult.OK;
		btnShowKeyboard_Address.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Address.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Address, "btnShowKeyboard_Address");
		btnShowKeyboard_Address.ForeColor = Color.White;
		btnShowKeyboard_Address.Name = "btnShowKeyboard_Address";
		btnShowKeyboard_Address.Tag = "5,5";
		btnShowKeyboard_Address.UseVisualStyleBackColor = false;
		btnShowKeyboard_Address.Click += btnShowKeyboard_Address_Click;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label2.Tag = "2,1";
		componentResourceManager.ApplyResources(txtPhone, "txtPhone");
		txtPhone.ForeColor = Color.FromArgb(40, 40, 40);
		txtPhone.Name = "txtPhone";
		txtPhone.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtPhone.TextChanged += txtName_TextChanged;
		txtPhone.Click += txtName_Click;
		((RadTextBoxControlElement)txtPhone.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtPhone.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Phone.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Phone.DialogResult = DialogResult.OK;
		btnShowKeyboard_Phone.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Phone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Phone, "btnShowKeyboard_Phone");
		btnShowKeyboard_Phone.ForeColor = Color.White;
		btnShowKeyboard_Phone.Name = "btnShowKeyboard_Phone";
		btnShowKeyboard_Phone.Tag = "5,5";
		btnShowKeyboard_Phone.UseVisualStyleBackColor = false;
		btnShowKeyboard_Phone.Click += btnShowKeyboard_Phone_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.Tag = "2,1";
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.TextChanged += txtName_TextChanged;
		txtName.Click += txtName_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.Tag = "5,5";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		lblMemberNo.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblMemberNo, "lblMemberNo");
		lblMemberNo.ForeColor = Color.White;
		lblMemberNo.Name = "lblMemberNo";
		lblMemberNo.Tag = "2,1";
		lblWIndowTitle.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblWIndowTitle, "lblWIndowTitle");
		lblWIndowTitle.ForeColor = Color.White;
		lblWIndowTitle.Name = "lblWIndowTitle";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(panel1);
		base.Controls.Add(lblWIndowTitle);
		base.Name = "frmCustomerInfo";
		base.Opacity = 1.0;
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtAddress).EndInit();
		((ISupportInitialize)txtPhone).EndInit();
		((ISupportInitialize)txtName).EndInit();
		ResumeLayout(performLayout: false);
	}
}
