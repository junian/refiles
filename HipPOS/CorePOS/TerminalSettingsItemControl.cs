using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.CommonForms;
using CorePOS.Data;
using Telerik.WinControls.UI;
using Traysoft.AddTapi;

namespace CorePOS;

public class TerminalSettingsItemControl : UserControl
{
	private Form form_0;

	private Terminal terminal_0;

	private GClass6 gclass6_0;

	private IContainer icontainer_0;

	private RadTextBoxControl txtProductKey;

	private PictureBox btnRemove;

	private Label lblIP;

	private Label lblDefaultOrderTypes;

	private PictureBox imgSetupPayment;

	private PictureBox imgSetupOrderTypes;

	private Class19 ddlModemDevices;

	private Label lblDeviceName;

	public TerminalSettingsItemControl(Form mainForm, Terminal terminal, GClass6 context)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent();
		form_0 = mainForm;
		terminal_0 = terminal;
		gclass6_0 = context;
		ddlModemDevices.Items.Add("NONE");
		try
		{
			TapiApp.SerialNumber = "44HEA5M-Q5M9D5K-WPCI8O2-KOUQD";
			TapiApp.Initialize("CallerID");
		}
		catch
		{
		}
		foreach (TapiLine line in TapiApp.Lines)
		{
			ddlModemDevices.Items.Add(line.Name);
		}
		if (terminal != null)
		{
			lblDeviceName.Text = terminal.SystemName;
			txtProductKey.Text = terminal.ProductKey;
			lblDefaultOrderTypes.Text = terminal.DefaultOrderTypes;
			ddlModemDevices.Text = terminal.PhoneModemDeviceName;
			lblIP.Text = terminal.PaymentTerminalAddress;
		}
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (terminal_0.Status == "active")
		{
			terminal_0.Status = "inactive";
			gclass6_0.SubmitChanges();
			new NotificationLabel(form_0, "Terminal has been made inactive.", NotificationTypes.Success).Show();
			Dispose();
		}
		else if (new frmMessageBox("Are you sure you want to permanently delete this terminal info?", "Permanently Delete?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			terminal_0.Status = "deleted";
			gclass6_0.SubmitChanges();
			Dispose();
		}
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

	private void TerminalSettingsItemControl_Load(object sender, EventArgs e)
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
			terminal_0 = gclass6_0.Terminals.Where((Terminal x) => x.SystemName.ToUpper() == lblDeviceName.Text.ToUpper()).FirstOrDefault();
			if (terminal_0 == null)
			{
				Dispose();
			}
		}
		terminal_0.SystemName = lblDeviceName.Text.ToUpper();
		terminal_0.ProductKey = txtProductKey.Text.ToUpper();
		terminal_0.DefaultOrderTypes = lblDefaultOrderTypes.Text;
		terminal_0.Status = "active";
	}

	private void imgSetupPayment_Click(object sender, EventArgs e)
	{
		method_0();
		frmSettingsPaymentProcessor obj = new frmSettingsPaymentProcessor();
		obj.terminal = terminal_0;
		obj.ShowDialog();
		lblIP.Text = terminal_0.PaymentTerminalAddress;
	}

	private void imgSetupOrderTypes_Click(object sender, EventArgs e)
	{
		if (terminal_0 == null)
		{
			return;
		}
		string defaultOrderTypes = terminal_0.DefaultOrderTypes;
		Dictionary<string, string> dictionary = OrderTypesDictionary.OrderTypes.ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> a) => a.Value);
		dictionary.Remove("Delivery-Online");
		dictionary.Remove("Pick-Up-Online");
		frmChecklistSelector frmChecklistSelector = new frmChecklistSelector("SET DEFAULT ORDER TYPES", dictionary, defaultOrderTypes, 1);
		if (frmChecklistSelector.ShowDialog() == DialogResult.OK)
		{
			defaultOrderTypes = frmChecklistSelector.returnValue;
			terminal_0.DefaultOrderTypes = defaultOrderTypes;
			Helper.SubmitChangesWithCatch(gclass6_0);
			if (terminal_0.SystemName == Environment.MachineName)
			{
				MemoryLoadedObjects.DefaultOrderTypes = terminal_0.DefaultOrderTypes;
			}
			lblDefaultOrderTypes.Text = terminal_0.DefaultOrderTypes;
			new NotificationLabel(form_0, "Default Order Types Successfully Saved.", NotificationTypes.Success).Show();
		}
	}

	private void ddlModemDevices_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (terminal_0 != null)
		{
			terminal_0.PhoneModemDeviceName = ddlModemDevices.Text;
			terminal_0.AppRestartRequired = true;
			Helper.SubmitChangesWithCatch(gclass6_0);
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.TerminalSettingsItemControl));
		this.txtProductKey = new Telerik.WinControls.UI.RadTextBoxControl();
		this.btnRemove = new System.Windows.Forms.PictureBox();
		this.lblIP = new System.Windows.Forms.Label();
		this.lblDefaultOrderTypes = new System.Windows.Forms.Label();
		this.imgSetupPayment = new System.Windows.Forms.PictureBox();
		this.imgSetupOrderTypes = new System.Windows.Forms.PictureBox();
		this.ddlModemDevices = new Class19();
		this.lblDeviceName = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.txtProductKey).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupOrderTypes).BeginInit();
		base.SuspendLayout();
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
		this.lblDefaultOrderTypes.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.lblDefaultOrderTypes, "lblDefaultOrderTypes");
		this.lblDefaultOrderTypes.Name = "lblDefaultOrderTypes";
		this.imgSetupPayment.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.imgSetupPayment, "imgSetupPayment");
		this.imgSetupPayment.Name = "imgSetupPayment";
		this.imgSetupPayment.TabStop = false;
		this.imgSetupPayment.Click += new System.EventHandler(imgSetupPayment_Click);
		this.imgSetupOrderTypes.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.imgSetupOrderTypes, "imgSetupOrderTypes");
		this.imgSetupOrderTypes.Name = "imgSetupOrderTypes";
		this.imgSetupOrderTypes.TabStop = false;
		this.imgSetupOrderTypes.Click += new System.EventHandler(imgSetupOrderTypes_Click);
		this.ddlModemDevices.BackColor = System.Drawing.Color.White;
		this.ddlModemDevices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlModemDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(this.ddlModemDevices, "ddlModemDevices");
		this.ddlModemDevices.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlModemDevices.FormattingEnabled = true;
		this.ddlModemDevices.Name = "ddlModemDevices";
		this.ddlModemDevices.Tag = "telephone_line_device";
		this.ddlModemDevices.SelectedIndexChanged += new System.EventHandler(ddlModemDevices_SelectedIndexChanged);
		this.lblDeviceName.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		componentResourceManager.ApplyResources(this.lblDeviceName, "lblDeviceName");
		this.lblDeviceName.Name = "lblDeviceName";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.lblDeviceName);
		base.Controls.Add(this.ddlModemDevices);
		base.Controls.Add(this.imgSetupOrderTypes);
		base.Controls.Add(this.imgSetupPayment);
		base.Controls.Add(this.lblDefaultOrderTypes);
		base.Controls.Add(this.lblIP);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add(this.txtProductKey);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "TerminalSettingsItemControl";
		base.Load += new System.EventHandler(TerminalSettingsItemControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtProductKey).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).EndInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.imgSetupOrderTypes).EndInit();
		base.ResumeLayout(false);
	}
}
