using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using Telerik.WinControls;
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
		base._002Ector();
		InitializeComponent();
		form_0 = mainForm;
		((Control)(object)txtFrom).Text = From;
		((Control)(object)txtTo).Text = To;
		((Control)(object)txtChargePerKM).Text = ChangePerKM;
		method_0();
		((Control)(object)txtFrom).TextChanged += txtChargePerKM_TextChanged;
		((Control)(object)txtTo).TextChanged += txtChargePerKM_TextChanged;
		((Control)(object)txtChargePerKM).TextChanged += txtChargePerKM_TextChanged;
	}

	private void method_0()
	{
		ToValue = ((Control)(object)txtTo).Text.ToDecimalWithCleanUp();
		FromValue = ((Control)(object)txtFrom).Text.ToDecimalWithCleanUp();
		ChangePerKMValue = ((Control)(object)txtChargePerKM).Text.ToDecimalWithCleanUp();
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void txtChargePerKM_TextChanged(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		if (((Control)(object)val).Name == ((Control)(object)txtTo).Name || ((Control)(object)val).Name == ((Control)(object)txtFrom).Name)
		{
			decimal num = ((Control)(object)txtFrom).Text.ToDecimalWithCleanUp();
			decimal num2 = ((Control)(object)txtTo).Text.ToDecimalWithCleanUp();
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
		decimal num = Math.Round(((Control)(object)txtFrom).Text.ToDecimalWithCleanUp());
		decimal num2 = Math.Round(((Control)(object)txtTo).Text.ToDecimalWithCleanUp());
		decimal num3 = ((Control)(object)txtChargePerKM).Text.ToDecimalWithCleanUp();
		decimal num4 = ((sampleDistance > num2) ? ((num2 - num) * num3) : ((sampleDistance - num) * num3));
		num4 = ((num4 < 0m) ? 0m : num4);
		((Control)(object)txtSample).Text = num4.ToString();
		method_0();
		return num4;
	}

	private void txtChargePerKM_Click(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		int decimalspaces = 0;
		if (((Control)(object)val).Name == ((Control)(object)txtChargePerKM).Name)
		{
			decimalspaces = 2;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter " + ((Control)(object)val).Tag.ToString(), decimalspaces, 8, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.DeliveryFeeCalculationItemControl));
		this.txtFrom = new RadTextBoxControl();
		this.txtTo = new RadTextBoxControl();
		this.txtChargePerKM = new RadTextBoxControl();
		this.txtSample = new RadTextBoxControl();
		this.btnRemove = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.txtFrom).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtChargePerKM).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSample).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnRemove).BeginInit();
		base.SuspendLayout();
		((System.Windows.Forms.Control)(object)this.txtFrom).BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtFrom, "txtFrom");
		((System.Windows.Forms.Control)(object)this.txtFrom).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.Control)(object)this.txtFrom).Name = "txtFrom";
		((RadElement)((RadControl)this.txtFrom).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtFrom).Tag = "From Value";
		((System.Windows.Forms.Control)(object)this.txtFrom).Click += new System.EventHandler(txtChargePerKM_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtFrom).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtFrom).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		((System.Windows.Forms.Control)(object)this.txtTo).BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtTo, "txtTo");
		((System.Windows.Forms.Control)(object)this.txtTo).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.Control)(object)this.txtTo).Name = "txtTo";
		((RadElement)((RadControl)this.txtTo).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtTo).Tag = "To Value";
		((System.Windows.Forms.Control)(object)this.txtTo).Click += new System.EventHandler(txtChargePerKM_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtTo).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtTo).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		((System.Windows.Forms.Control)(object)this.txtChargePerKM).BackColor = System.Drawing.Color.White;
		componentResourceManager.ApplyResources(this.txtChargePerKM, "txtChargePerKM");
		((System.Windows.Forms.Control)(object)this.txtChargePerKM).ForeColor = System.Drawing.SystemColors.ControlText;
		((System.Windows.Forms.Control)(object)this.txtChargePerKM).Name = "txtChargePerKM";
		((RadElement)((RadControl)this.txtChargePerKM).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((System.Windows.Forms.Control)(object)this.txtChargePerKM).Tag = "Charge per KM";
		((System.Windows.Forms.Control)(object)this.txtChargePerKM).Click += new System.EventHandler(txtChargePerKM_Click);
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtChargePerKM).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtChargePerKM).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		((System.Windows.Forms.Control)(object)this.txtSample).BackColor = System.Drawing.Color.Silver;
		componentResourceManager.ApplyResources(this.txtSample, "txtSample");
		((System.Windows.Forms.Control)(object)this.txtSample).ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtSample.set_IsReadOnly(true);
		((System.Windows.Forms.Control)(object)this.txtSample).Name = "txtSample";
		((RadElement)((RadControl)this.txtSample).get_RootElement()).set_PositionOffset(new System.Drawing.SizeF(0f, 0f));
		((UIItemBase)(RadTextBoxControlElement)((RadControl)this.txtSample).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)this.txtSample).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new System.Drawing.SizeF(5f, 5f));
		this.btnRemove.BackColor = System.Drawing.Color.Transparent;
		componentResourceManager.ApplyResources(this.btnRemove, "btnRemove");
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.TabStop = false;
		this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtSample);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtChargePerKM);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtTo);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.txtFrom);
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
