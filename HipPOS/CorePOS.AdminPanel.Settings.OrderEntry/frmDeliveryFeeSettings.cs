using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings.OrderEntry;

public class frmDeliveryFeeSettings : frmMasterForm
{
	public decimal SampleDistance;

	public decimal TotalSampleCalc;

	private DeliveryFeeCalculationHeaderControl deliveryFeeCalculationHeaderControl_0;

	private IContainer icontainer_1;

	private Label label9;

	private RadTextBoxControl txtBaseRate;

	private Label label1;

	private Label label22;

	internal Button btnShowKeyboard_SampleDistance;

	private RadTextBoxControl txtSampleDistance;

	private Label label2;

	internal Button btnAddToUnit;

	private Label label3;

	private FlowLayoutPanel pnlCalculations;

	public Label lblSampleCalculation;

	internal Button btnClose;

	internal Button btnSave;

	private Class19 ddlUOMDistance;

	internal Button btnShowKeyboard_BaseRate;

	internal Button btnShowKeyboard_FreeDeliveryChargeOver;

	private RadTextBoxControl txtFreeDeliveryChargeOver;

	private Label label5;

	private Label label37;

	private Label label4;

	public frmDeliveryFeeSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		deliveryFeeCalculationHeaderControl_0 = new DeliveryFeeCalculationHeaderControl();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmDeliveryFeeSettings_Load(object sender, EventArgs e)
	{
		pnlCalculations.Controls.Add(deliveryFeeCalculationHeaderControl_0);
		DeliveryFeeSettingsObject deliveryFeeSettings = SettingsHelper.DeliveryFeeSettings.GetDeliveryFeeSettings();
		txtBaseRate.Text = deliveryFeeSettings.BaseRate.ToString("0.00");
		txtFreeDeliveryChargeOver.Text = deliveryFeeSettings.FreeDeliveryOver.ToString("0.00");
		ddlUOMDistance.Text = deliveryFeeSettings.String_0;
		foreach (DeliveryFeeFromToPerKM item in deliveryFeeSettings.ListOfFeeCalculation)
		{
			DeliveryFeeCalculationItemControl deliveryFeeCalculationItemControl = new DeliveryFeeCalculationItemControl(this, Math.Round(item.FromDistance).ToString("0"), Math.Round(item.ToDistance).ToString("0"), item.ChargePerKM.ToString("0.00"));
			pnlCalculations.Controls.Add(deliveryFeeCalculationItemControl);
			deliveryFeeCalculationItemControl.CalculationOnChanged += txtSampleDistance_TextChanged;
		}
	}

	private void txtSampleDistance_TextChanged(object sender, EventArgs e)
	{
		SampleDistance = txtSampleDistance.Text.ToDecimalWithCleanUp();
		SampleDistance = Math.Ceiling(SampleDistance);
		TotalSampleCalc = default(decimal);
		foreach (Control control in pnlCalculations.Controls)
		{
			if (control is DeliveryFeeCalculationItemControl)
			{
				DeliveryFeeCalculationItemControl deliveryFeeCalculationItemControl = control as DeliveryFeeCalculationItemControl;
				TotalSampleCalc += deliveryFeeCalculationItemControl.CalculateChange(SampleDistance);
			}
		}
		TotalSampleCalc += txtBaseRate.Text.ToDecimalWithCleanUp();
		lblSampleCalculation.Text = "Total Calculation: $" + TotalSampleCalc.ToString("0.00");
	}

	private void btnAddToUnit_Click(object sender, EventArgs e)
	{
		DeliveryFeeCalculationItemControl deliveryFeeCalculationItemControl = new DeliveryFeeCalculationItemControl(this, "0", "0", "0");
		deliveryFeeCalculationItemControl.CalculationOnChanged += txtSampleDistance_TextChanged;
		pnlCalculations.Controls.Add(deliveryFeeCalculationItemControl);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		DeliveryFeeSettingsObject deliveryFeeSettingsObject = new DeliveryFeeSettingsObject();
		deliveryFeeSettingsObject.BaseRate = txtBaseRate.Text.ToDecimalWithCleanUp();
		deliveryFeeSettingsObject.FreeDeliveryOver = txtFreeDeliveryChargeOver.Text.ToDecimalWithCleanUp();
		deliveryFeeSettingsObject.String_0 = ddlUOMDistance.Text;
		List<DeliveryFeeFromToPerKM> list = new List<DeliveryFeeFromToPerKM>();
		foreach (Control control in pnlCalculations.Controls)
		{
			if (control is DeliveryFeeCalculationItemControl)
			{
				DeliveryFeeCalculationItemControl deliveryFeeCalculationItemControl = control as DeliveryFeeCalculationItemControl;
				list.Add(new DeliveryFeeFromToPerKM
				{
					ChargePerKM = deliveryFeeCalculationItemControl.ChangePerKMValue,
					FromDistance = Math.Round(deliveryFeeCalculationItemControl.FromValue),
					ToDistance = Math.Round(deliveryFeeCalculationItemControl.ToValue)
				});
			}
		}
		foreach (DeliveryFeeFromToPerKM item in list)
		{
			foreach (DeliveryFeeFromToPerKM item2 in list)
			{
				if (item2 != item && MathHelper.IsOverlapping(item2.FromDistance, item2.ToDistance, item.FromDistance, item.ToDistance, 1m))
				{
					new NotificationLabel(this, "There is an overlapping distance. Please change calculations.", NotificationTypes.Warning).Show();
					return;
				}
			}
		}
		deliveryFeeSettingsObject.ListOfFeeCalculation = list;
		SettingsHelper.DeliveryFeeSettings.SaveDeliveryFeeSettings(deliveryFeeSettingsObject);
		new NotificationLabel(this, "Saved.", NotificationTypes.Success).Show();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		ControlHelpers.ClearControlsInForm(this);
		Dispose();
		Close();
	}

	private void txtSampleDistance_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Sample Distance", 4, 8, txtSampleDistance.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtSampleDistance.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_BaseRate_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Base Rate", 2, 8, txtBaseRate.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtBaseRate.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void ddlUOMDistance_SelectedIndexChanged(object sender, EventArgs e)
	{
		deliveryFeeCalculationHeaderControl_0.lblCharge.Text = "CHARGE per " + ddlUOMDistance.Text;
	}

	private void btnShowKeyboard_FreeDeliveryChargeOver_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Total Amount For Free Delivery", 2, 8, txtFreeDeliveryChargeOver.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtFreeDeliveryChargeOver.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDeliveryFeeSettings));
		label9 = new Label();
		txtBaseRate = new RadTextBoxControl();
		label1 = new Label();
		label22 = new Label();
		btnShowKeyboard_SampleDistance = new Button();
		txtSampleDistance = new RadTextBoxControl();
		label2 = new Label();
		btnAddToUnit = new Button();
		label3 = new Label();
		pnlCalculations = new FlowLayoutPanel();
		lblSampleCalculation = new Label();
		btnClose = new Button();
		btnSave = new Button();
		ddlUOMDistance = new Class19();
		btnShowKeyboard_BaseRate = new Button();
		btnShowKeyboard_FreeDeliveryChargeOver = new Button();
		txtFreeDeliveryChargeOver = new RadTextBoxControl();
		label5 = new Label();
		label37 = new Label();
		label4 = new Label();
		((ISupportInitialize)txtBaseRate).BeginInit();
		((ISupportInitialize)txtSampleDistance).BeginInit();
		((ISupportInitialize)txtFreeDeliveryChargeOver).BeginInit();
		SuspendLayout();
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(9, 10);
		label9.Margin = new Padding(2, 0, 2, 0);
		label9.Name = "label9";
		label9.Size = new Size(511, 32);
		label9.TabIndex = 101;
		label9.Text = "DELIVERY FEE SETTINGS";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		txtBaseRate.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtBaseRate.Location = new Point(132, 43);
		txtBaseRate.MaxLength = 255;
		txtBaseRate.Name = "txtBaseRate";
		txtBaseRate.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtBaseRate.Size = new Size(69, 33);
		txtBaseRate.TabIndex = 112;
		txtBaseRate.Click += btnShowKeyboard_BaseRate_Click;
		((RadTextBoxControlElement)txtBaseRate.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtBaseRate.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 11f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(9, 43);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.Name = "label1";
		label1.Size = new Size(105, 33);
		label1.TabIndex = 113;
		label1.Text = "BASE RATE";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label22.BackColor = Color.FromArgb(132, 146, 146);
		label22.Font = new Font("Microsoft Sans Serif", 11f);
		label22.ForeColor = Color.White;
		label22.ImeMode = ImeMode.NoControl;
		label22.Location = new Point(9, 77);
		label22.Margin = new Padding(4, 0, 4, 0);
		label22.Name = "label22";
		label22.Size = new Size(125, 35);
		label22.TabIndex = 241;
		label22.Text = "DISTANCE UOM";
		label22.TextAlign = ContentAlignment.MiddleLeft;
		btnShowKeyboard_SampleDistance.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SampleDistance.DialogResult = DialogResult.OK;
		btnShowKeyboard_SampleDistance.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SampleDistance.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_SampleDistance.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_SampleDistance.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_SampleDistance.ForeColor = Color.White;
		btnShowKeyboard_SampleDistance.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_SampleDistance.Image");
		btnShowKeyboard_SampleDistance.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_SampleDistance.Location = new Point(469, 77);
		btnShowKeyboard_SampleDistance.Name = "btnShowKeyboard_SampleDistance";
		btnShowKeyboard_SampleDistance.Size = new Size(51, 35);
		btnShowKeyboard_SampleDistance.TabIndex = 248;
		btnShowKeyboard_SampleDistance.UseVisualStyleBackColor = false;
		btnShowKeyboard_SampleDistance.Click += txtSampleDistance_Click;
		txtSampleDistance.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtSampleDistance.Location = new Point(373, 77);
		txtSampleDistance.MaxLength = 255;
		txtSampleDistance.Name = "txtSampleDistance";
		txtSampleDistance.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSampleDistance.Size = new Size(95, 35);
		txtSampleDistance.TabIndex = 246;
		txtSampleDistance.TextChanged += txtSampleDistance_TextChanged;
		txtSampleDistance.Click += txtSampleDistance_Click;
		((RadTextBoxControlElement)txtSampleDistance.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSampleDistance.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 11f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(202, 77);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.Name = "label2";
		label2.Size = new Size(170, 35);
		label2.TabIndex = 245;
		label2.Text = "SAMPLE DISTANCE";
		label2.TextAlign = ContentAlignment.MiddleRight;
		btnAddToUnit.BackColor = Color.FromArgb(147, 101, 184);
		btnAddToUnit.FlatAppearance.BorderColor = Color.White;
		btnAddToUnit.FlatAppearance.BorderSize = 0;
		btnAddToUnit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddToUnit.FlatStyle = FlatStyle.Flat;
		btnAddToUnit.Font = new Font("Microsoft Sans Serif", 10f);
		btnAddToUnit.ForeColor = Color.White;
		btnAddToUnit.Image = (Image)componentResourceManager.GetObject("btnAddToUnit.Image");
		btnAddToUnit.ImeMode = ImeMode.NoControl;
		btnAddToUnit.Location = new Point(468, 116);
		btnAddToUnit.Name = "btnAddToUnit";
		btnAddToUnit.Padding = new Padding(5, 0, 5, 0);
		btnAddToUnit.Size = new Size(44, 35);
		btnAddToUnit.TabIndex = 247;
		btnAddToUnit.TextAlign = ContentAlignment.MiddleRight;
		btnAddToUnit.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnAddToUnit.UseVisualStyleBackColor = false;
		btnAddToUnit.Click += btnAddToUnit_Click;
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.BackColor = Color.FromArgb(147, 101, 184);
		label3.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(9, 113);
		label3.Name = "label3";
		label3.Size = new Size(511, 43);
		label3.TabIndex = 244;
		label3.Text = "CALCULATIONS";
		label3.TextAlign = ContentAlignment.MiddleCenter;
		pnlCalculations.AccessibleName = "";
		pnlCalculations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		pnlCalculations.AutoScroll = true;
		pnlCalculations.AutoScrollMargin = new Size(10, 0);
		pnlCalculations.Font = new Font("Microsoft Sans Serif", 10f);
		pnlCalculations.Location = new Point(9, 155);
		pnlCalculations.Margin = new Padding(0, 0, 20, 0);
		pnlCalculations.Name = "pnlCalculations";
		pnlCalculations.Padding = new Padding(0, 0, 20, 0);
		pnlCalculations.Size = new Size(511, 281);
		pnlCalculations.TabIndex = 250;
		lblSampleCalculation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblSampleCalculation.BackColor = Color.FromArgb(61, 142, 185);
		lblSampleCalculation.Font = new Font("Microsoft Sans Serif", 16f);
		lblSampleCalculation.ForeColor = Color.White;
		lblSampleCalculation.ImeMode = ImeMode.NoControl;
		lblSampleCalculation.Location = new Point(9, 428);
		lblSampleCalculation.Margin = new Padding(1);
		lblSampleCalculation.Name = "lblSampleCalculation";
		lblSampleCalculation.Size = new Size(511, 43);
		lblSampleCalculation.TabIndex = 253;
		lblSampleCalculation.Text = "SAMPLE CALCULATION";
		lblSampleCalculation.TextAlign = ContentAlignment.MiddleCenter;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 10f);
		btnClose.ForeColor = Color.White;
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(265, 472);
		btnClose.MinimumSize = new Size(121, 60);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(255, 75);
		btnClose.TabIndex = 252;
		btnClose.Text = "CLOSE";
		btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnSave.BackColor = Color.FromArgb(65, 168, 95);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 10f);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(9, 472);
		btnSave.MinimumSize = new Size(121, 60);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(255, 75);
		btnSave.TabIndex = 251;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		ddlUOMDistance.BackColor = Color.White;
		ddlUOMDistance.DrawMode = DrawMode.OwnerDrawVariable;
		ddlUOMDistance.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlUOMDistance.Font = new Font("Microsoft Sans Serif", 12.5f, FontStyle.Bold);
		ddlUOMDistance.ForeColor = Color.FromArgb(40, 40, 40);
		ddlUOMDistance.FormattingEnabled = true;
		ddlUOMDistance.ItemHeight = 28;
		ddlUOMDistance.Items.AddRange(new object[2] { "KM", "MI" });
		ddlUOMDistance.Location = new Point(134, 77);
		ddlUOMDistance.Margin = new Padding(4, 5, 4, 5);
		ddlUOMDistance.MinimumSize = new Size(50, 0);
		ddlUOMDistance.Name = "ddlUOMDistance";
		ddlUOMDistance.Size = new Size(67, 34);
		ddlUOMDistance.TabIndex = 293;
		ddlUOMDistance.Tag = "delivery_distance_uom";
		ddlUOMDistance.SelectedIndexChanged += ddlUOMDistance_SelectedIndexChanged;
		btnShowKeyboard_BaseRate.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_BaseRate.DialogResult = DialogResult.OK;
		btnShowKeyboard_BaseRate.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_BaseRate.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_BaseRate.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_BaseRate.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_BaseRate.ForeColor = Color.White;
		btnShowKeyboard_BaseRate.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_BaseRate.Image");
		btnShowKeyboard_BaseRate.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_BaseRate.Location = new Point(202, 43);
		btnShowKeyboard_BaseRate.Name = "btnShowKeyboard_BaseRate";
		btnShowKeyboard_BaseRate.Size = new Size(51, 33);
		btnShowKeyboard_BaseRate.TabIndex = 294;
		btnShowKeyboard_BaseRate.UseVisualStyleBackColor = false;
		btnShowKeyboard_BaseRate.Click += btnShowKeyboard_BaseRate_Click;
		btnShowKeyboard_FreeDeliveryChargeOver.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_FreeDeliveryChargeOver.DialogResult = DialogResult.OK;
		btnShowKeyboard_FreeDeliveryChargeOver.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_FreeDeliveryChargeOver.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_FreeDeliveryChargeOver.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_FreeDeliveryChargeOver.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_FreeDeliveryChargeOver.ForeColor = Color.White;
		btnShowKeyboard_FreeDeliveryChargeOver.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_FreeDeliveryChargeOver.Image");
		btnShowKeyboard_FreeDeliveryChargeOver.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_FreeDeliveryChargeOver.Location = new Point(469, 43);
		btnShowKeyboard_FreeDeliveryChargeOver.Name = "btnShowKeyboard_FreeDeliveryChargeOver";
		btnShowKeyboard_FreeDeliveryChargeOver.Size = new Size(51, 33);
		btnShowKeyboard_FreeDeliveryChargeOver.TabIndex = 297;
		btnShowKeyboard_FreeDeliveryChargeOver.UseVisualStyleBackColor = false;
		btnShowKeyboard_FreeDeliveryChargeOver.Click += btnShowKeyboard_FreeDeliveryChargeOver_Click;
		txtFreeDeliveryChargeOver.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtFreeDeliveryChargeOver.Location = new Point(391, 43);
		txtFreeDeliveryChargeOver.MaxLength = 255;
		txtFreeDeliveryChargeOver.Name = "txtFreeDeliveryChargeOver";
		txtFreeDeliveryChargeOver.Padding = new Padding(10, 0, 0, 0);
		txtFreeDeliveryChargeOver.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtFreeDeliveryChargeOver.Size = new Size(77, 33);
		txtFreeDeliveryChargeOver.TabIndex = 295;
		((RadTextBoxControlElement)txtFreeDeliveryChargeOver.GetChildAt(0)).BorderWidth = 0f;
		((RadTextBoxControlElement)txtFreeDeliveryChargeOver.GetChildAt(0)).Padding = new Padding(10, 0, 0, 0);
		((TextBoxViewElement)txtFreeDeliveryChargeOver.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 9f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(254, 43);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.Name = "label5";
		label5.Size = new Size(118, 33);
		label5.TabIndex = 296;
		label5.Text = "FREE IF ORDER IS GREATER THAN";
		label5.TextAlign = ContentAlignment.MiddleRight;
		label37.BackColor = Color.White;
		label37.Font = new Font("Microsoft Sans Serif", 15.75f);
		label37.ForeColor = Color.Black;
		label37.ImeMode = ImeMode.NoControl;
		label37.Location = new Point(373, 43);
		label37.Margin = new Padding(0);
		label37.Name = "label37";
		label37.Size = new Size(18, 33);
		label37.TabIndex = 298;
		label37.Text = "$";
		label37.TextAlign = ContentAlignment.MiddleLeft;
		label4.BackColor = Color.White;
		label4.Font = new Font("Microsoft Sans Serif", 15.75f);
		label4.ForeColor = Color.Black;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(115, 43);
		label4.Margin = new Padding(0);
		label4.Name = "label4";
		label4.Size = new Size(18, 33);
		label4.TabIndex = 299;
		label4.Text = "$";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(530, 558);
		base.Controls.Add(label4);
		base.Controls.Add(label37);
		base.Controls.Add(btnShowKeyboard_FreeDeliveryChargeOver);
		base.Controls.Add(txtFreeDeliveryChargeOver);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowKeyboard_BaseRate);
		base.Controls.Add(ddlUOMDistance);
		base.Controls.Add(lblSampleCalculation);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnSave);
		base.Controls.Add(pnlCalculations);
		base.Controls.Add(btnShowKeyboard_SampleDistance);
		base.Controls.Add(txtSampleDistance);
		base.Controls.Add(label2);
		base.Controls.Add(btnAddToUnit);
		base.Controls.Add(label3);
		base.Controls.Add(label22);
		base.Controls.Add(txtBaseRate);
		base.Controls.Add(label1);
		base.Controls.Add(label9);
		base.Name = "frmDeliveryFeeSettings";
		base.Opacity = 1.0;
		Text = "frmDeliveryFeeSettings";
		base.Load += frmDeliveryFeeSettings_Load;
		((ISupportInitialize)txtBaseRate).EndInit();
		((ISupportInitialize)txtSampleDistance).EndInit();
		((ISupportInitialize)txtFreeDeliveryChargeOver).EndInit();
		ResumeLayout(performLayout: false);
	}
}
