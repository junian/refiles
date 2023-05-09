using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using Telerik.WinControls.UI;

namespace CorePOS;

public class DeliveryFeeCalculationItemControl : UserControl
{
	public decimal FromValue;

	public decimal ToValue;

	public decimal ChangePerKMValue;

	private Form form_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0;

	private RadTextBoxControl txtFrom;

	private RadTextBoxControl txtTo;

	private RadTextBoxControl txtChargePerKM;

	private RadTextBoxControl txtSample;

	private PictureBox btnRemove;

	public event EventHandler CalculationOnChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DeliveryFeeCalculationItemControl(Form mainForm, string From, string To, string ChangePerKM)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent();
		form_0 = mainForm;
		txtFrom.Text = From;
		txtTo.Text = To;
		txtChargePerKM.Text = ChangePerKM;
		method_0();
		txtFrom.TextChanged += txtChargePerKM_TextChanged;
		txtTo.TextChanged += txtChargePerKM_TextChanged;
		txtChargePerKM.TextChanged += txtChargePerKM_TextChanged;
	}

	private void method_0()
	{
		ToValue = txtTo.Text.ToDecimalWithCleanUp();
		FromValue = txtFrom.Text.ToDecimalWithCleanUp();
		ChangePerKMValue = txtChargePerKM.Text.ToDecimalWithCleanUp();
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void txtChargePerKM_TextChanged(object sender, EventArgs e)
	{
		RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
		if (radTextBoxControl.Name == txtTo.Name || radTextBoxControl.Name == txtFrom.Name)
		{
			decimal num = txtFrom.Text.ToDecimalWithCleanUp();
			decimal num2 = txtTo.Text.ToDecimalWithCleanUp();
			if (num > num2)
			{
				new NotificationLabel(form_0, "From Value cannot be greater than To Value", NotificationTypes.Warning).Show();
				return;
			}
		}
		if (eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
	}

	public decimal CalculateChange(decimal sampleDistance)
	{
		decimal num = Math.Round(txtFrom.Text.ToDecimalWithCleanUp());
		decimal num2 = Math.Round(txtTo.Text.ToDecimalWithCleanUp());
		decimal num3 = txtChargePerKM.Text.ToDecimalWithCleanUp();
		decimal num4 = ((sampleDistance > num2) ? ((num2 - num) * num3) : ((sampleDistance - num) * num3));
		num4 = ((num4 < 0m) ? 0m : num4);
		txtSample.Text = num4.ToString();
		method_0();
		return num4;
	}

	private void txtChargePerKM_Click(object sender, EventArgs e)
	{
		RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
		int decimalspaces = 0;
		if (radTextBoxControl.Name == txtChargePerKM.Name)
		{
			decimalspaces = 2;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter " + radTextBoxControl.Tag.ToString(), decimalspaces, 8, radTextBoxControl.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.DeliveryFeeCalculationItemControl));
		this.txtFrom = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtTo = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtChargePerKM = new Telerik.WinControls.UI.RadTextBoxControl();
		this.txtSample = new Telerik.WinControls.UI.RadTextBoxControl();
		this.btnRemove = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.txtFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtChargePerKM).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSample).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).BeginInit();
		base.SuspendLayout();
		this.txtFrom.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtFrom, "txtFrom");
		this.txtFrom.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtFrom.Name = "txtFrom";
		this.txtFrom.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtFrom.Tag = "From Value";
		this.txtFrom.Click += new System.EventHandler(txtChargePerKM_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtFrom.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtFrom.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.txtTo.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtTo, "txtTo");
		this.txtTo.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtTo.Name = "txtTo";
		this.txtTo.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtTo.Tag = "To Value";
		this.txtTo.Click += new System.EventHandler(txtChargePerKM_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtTo.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtTo.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.txtChargePerKM.BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtChargePerKM, "txtChargePerKM");
		this.txtChargePerKM.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtChargePerKM.Name = "txtChargePerKM";
		this.txtChargePerKM.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtChargePerKM.Tag = "Charge per KM";
		this.txtChargePerKM.Click += new System.EventHandler(txtChargePerKM_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtChargePerKM.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtChargePerKM.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.txtSample.BackColor = System.Drawing.Color.Silver;
		componentResourceManager.ApplyResources(this.txtSample, "txtSample");
		this.txtSample.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtSample.IsReadOnly = true;
		this.txtSample.Name = "txtSample";
		this.txtSample.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtSample.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtSample.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.btnRemove.BackColor = System.Drawing.Color.Transparent;
		componentResourceManager.ApplyResources(this.btnRemove, "btnRemove");
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.TabStop = false;
		this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add(this.txtSample);
		base.Controls.Add(this.txtChargePerKM);
		base.Controls.Add(this.txtTo);
		base.Controls.Add(this.txtFrom);
		componentResourceManager.ApplyResources(this, "$this");
		base.Name = "DeliveryFeeCalculationItemControl";
		((System.ComponentModel.ISupportInitialize)this.txtFrom).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtChargePerKM).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSample).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).EndInit();
		base.ResumeLayout(false);
	}
}
