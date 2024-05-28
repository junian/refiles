using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class KioskSettingsItemControl : UserControl
{
	private Form form_0;

	private Terminal terminal_0;

	private GClass6 gclass6_0;

	private IContainer icontainer_0;

	private RadTextBoxControl txtDeviceName;

	private RadTextBoxControl txtProductKey;

	private PictureBox btnRemove;

	private Label lblIP;

	private Label lblDefaultPrinter;

	private PictureBox imgSetupPrinter;

	private PictureBox imgSetupPayment;

	public KioskSettingsItemControl(Form mainForm, Terminal terminal, GClass6 context)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent();
		form_0 = mainForm;
		terminal_0 = terminal;
		gclass6_0 = context;
		if (terminal != null)
		{
			txtDeviceName.Text = terminal.SystemName;
			txtProductKey.Text = terminal.ProductKey;
			lblDefaultPrinter.Text = terminal.DefaultPrinter;
			lblIP.Text = terminal.PaymentTerminalAddress;
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void txtProductKey_Click(object sender, EventArgs e)
	{
		RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Enter " + radTextBoxControl.Tag.ToString(), 0, 50, radTextBoxControl.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void KioskSettingsItemControl_Load(object sender, EventArgs e)
	{
	}

	public void Save()
	{
		method_0();
		gclass6_0.SubmitChanges();
	}

	private void method_0()
	{
		if (terminal_0 == null)
		{
			terminal_0 = gclass6_0.Terminals.Where((Terminal x) => x.SystemName.ToUpper() == txtDeviceName.Text.ToUpper()).FirstOrDefault();
			if (terminal_0 == null)
			{
				terminal_0 = new Terminal();
				terminal_0.LastCheckedIn = DateTime.Now;
				terminal_0.DefaultLayoutSectionName = string.Empty;
				terminal_0.DefaultOrderTypes = "Dine In,To-Go";
				terminal_0.DefaultStation1 = 1;
				terminal_0.DefaultStation1 = 2;
				terminal_0.LayoutZoomValue = 5;
				gclass6_0.Terminals.InsertOnSubmit(terminal_0);
			}
		}
		terminal_0.SystemName = txtDeviceName.Text.ToUpper();
		terminal_0.ProductKey = txtProductKey.Text.ToUpper();
		terminal_0.DefaultPrinter = lblDefaultPrinter.Text;
		terminal_0.Status = "active";
		terminal_0.OperatingMode = "Kiosk";
	}

	private void imgSetupPrinter_Click(object sender, EventArgs e)
	{
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog(this) != DialogResult.Cancel)
		{
			lblDefaultPrinter.Text = printDialog.PrinterSettings.PrinterName;
		}
	}

	private void imgSetupPayment_Click(object sender, EventArgs e)
	{
		method_0();
		frmSettingsPaymentProcessor obj = new frmSettingsPaymentProcessor();
		obj.terminal = terminal_0;
		obj.ShowDialog();
		lblIP.Text = terminal_0.PaymentTerminalAddress;
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.KioskSettingsItemControl));
		this.txtDeviceName = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtProductKey = new Telerik.WinControls.UI.RadTextBoxControl();
		this.btnRemove = new System.Windows.Forms.PictureBox();
		this.lblIP = new System.Windows.Forms.Label();
		this.lblDefaultPrinter = new System.Windows.Forms.Label();
		this.imgSetupPrinter = new System.Windows.Forms.PictureBox();
		this.imgSetupPayment = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.txtDeviceName).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtProductKey).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPrinter).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPayment).BeginInit();
		base.SuspendLayout();
		this.txtDeviceName.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtDeviceName, "txtDeviceName");
		this.txtDeviceName.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtDeviceName.Name = "txtDeviceName";
		this.txtDeviceName.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtDeviceName.Tag = "Device Name";
		this.txtDeviceName.Click += new System.EventHandler(txtProductKey_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtDeviceName.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtDeviceName.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.txtProductKey.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtProductKey, "txtProductKey");
		this.txtProductKey.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtProductKey.Name = "txtProductKey";
		this.txtProductKey.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtProductKey.Tag = "Product Key";
		this.txtProductKey.Click += new System.EventHandler(txtProductKey_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtProductKey.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtProductKey.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.btnRemove.BackColor = System.Drawing.Color.Transparent;
		componentResourceManager.ApplyResources(this.btnRemove, "btnRemove");
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.TabStop = false;
		this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
		this.lblIP.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.lblIP, "lblIP");
		this.lblIP.Name = "lblIP";
		this.lblDefaultPrinter.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.lblDefaultPrinter, "lblDefaultPrinter");
		this.lblDefaultPrinter.Name = "lblDefaultPrinter";
		this.imgSetupPrinter.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.imgSetupPrinter, "imgSetupPrinter");
		this.imgSetupPrinter.Name = "imgSetupPrinter";
		this.imgSetupPrinter.TabStop = false;
		this.imgSetupPrinter.Click += new System.EventHandler(imgSetupPrinter_Click);
		this.imgSetupPayment.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.imgSetupPayment, "imgSetupPayment");
		this.imgSetupPayment.Name = "imgSetupPayment";
		this.imgSetupPayment.TabStop = false;
		this.imgSetupPayment.Click += new System.EventHandler(imgSetupPayment_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.imgSetupPayment);
		base.Controls.Add(this.imgSetupPrinter);
		base.Controls.Add(this.lblDefaultPrinter);
		base.Controls.Add(this.lblIP);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add(this.txtProductKey);
		base.Controls.Add(this.txtDeviceName);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "KioskSettingsItemControl";
		base.Load += new System.EventHandler(KioskSettingsItemControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtDeviceName).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtProductKey).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).EndInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPrinter).EndInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPayment).EndInit();
		base.ResumeLayout(false);
	}
}
