using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmUOMConversions : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int convToRemove;

		public _003C_003Ec__DisplayClass12_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private List<int> list_2;

	private int int_0;

	private int int_1;

	private string string_0;

	private string string_1;

	private IContainer icontainer_1;

	private Label lblTitleBar;

	private Label label8;

	private Label label3;

	private FlowLayoutPanel pnlToUnits;

	internal Button btnSave;

	internal Button KwOrbYumDs;

	public Label lblSampleConversion;

	private Label label2;

	private RadTextBoxControl txtSampleQty;

	internal Button btnAddToUnit;

	internal Button btnNewBaseUnit;

	internal Button btnShowKeyboard_SampleQty;

	private Label lblStockUOMName;

	public frmUOMConversions(int _itemID, string _itemName, string _stockUOMID, string _stockUOMName)
	{
		Class26.Ggkj0JxzN9YmC();
		list_2 = new List<int>();
		base._002Ector();
		int_0 = _itemID;
		int_1 = Convert.ToInt32(_stockUOMID);
		string_0 = _itemName;
		string_1 = _stockUOMName;
		InitializeComponent_1();
	}

	private void SxKrlvctve(object sender, EventArgs e)
	{
		lblTitleBar.Text = lblTitleBar.Text + Resources._FOR + string_0;
		UOMConversionHeaderControl value = new UOMConversionHeaderControl(pnlToUnits);
		pnlToUnits.Controls.Add(value);
		lblStockUOMName.Text = string_1;
		foreach (GClass7 item in new GClass6().UOMUnitsConversions.Where((GClass7 x) => x.ItemID == (int?)int_0).ToList())
		{
			UOMConversionBodyControl uOMConversionBodyControl = new UOMConversionBodyControl(pnlToUnits, item, this);
			uOMConversionBodyControl.btnRemoveClick += UOMConvControl_btnRemoveClick;
			uOMConversionBodyControl.txtFactorChanged += UOMConvControl_txtFactorChanged;
			uOMConversionBodyControl.btnRemoveClick += UOMConvControl_btnRemoveClick;
			pnlToUnits.Controls.Add(uOMConversionBodyControl);
		}
	}

	private void txtSampleQty_TextChanged(object sender, EventArgs e)
	{
		triggerCalculations();
	}

	public void triggerCalculations()
	{
		if (!decimal.TryParse(txtSampleQty.Text, out var result))
		{
			return;
		}
		foreach (Control control in pnlToUnits.Controls)
		{
			if (control.GetType().ToString().Contains("UOMConversionBodyControl"))
			{
				UOMConversionBodyControl uomconversionBodyControl_ = (UOMConversionBodyControl)control;
				method_3(uomconversionBodyControl_, result);
			}
		}
	}

	private void method_3(UOMConversionBodyControl uomconversionBodyControl_0, decimal decimal_0)
	{
		string text = uomconversionBodyControl_0.ChangeSampleQuantity(decimal_0);
		if (text == "divzero")
		{
			lblSampleConversion.Text = Resources.Error_Division_by_zero_please_;
			return;
		}
		if (text == "no_value")
		{
			lblSampleConversion.Text = Resources.Please_add_a_factor;
			return;
		}
		lblSampleConversion.Text = decimal_0 + " " + lblStockUOMName.Text + " = " + text;
	}

	protected void UOMConvControl_btnRemoveClick(object sender, EventArgs e)
	{
		int num = (int)sender;
		if (num > 0)
		{
			list_2.Add(num);
		}
	}

	protected void UOMConvControl_txtFactorChanged(object sender, EventArgs e)
	{
		UOMConversionBodyControl uomconversionBodyControl_ = (UOMConversionBodyControl)sender;
		if (decimal.TryParse(txtSampleQty.Text, out var result))
		{
			method_3(uomconversionBodyControl_, result);
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		foreach (Control control in pnlToUnits.Controls)
		{
			if (control.GetType().ToString().Contains("UOMConversionBodyControl") && !((UOMConversionBodyControl)control).Save((short)int_1))
			{
				return;
			}
		}
		GClass6 gClass = new GClass6();
		UOM uOM = gClass.UOMs.Where((UOM a) => a.UOMID == int_1).FirstOrDefault();
		uOM.Name = lblStockUOMName.Text;
		uOM.Synced = false;
		using (List<int>.Enumerator enumerator2 = list_2.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
				CS_0024_003C_003E8__locals0.convToRemove = enumerator2.Current;
				GClass7 entity = gClass.UOMUnitsConversions.Where((GClass7 a) => a.Id == CS_0024_003C_003E8__locals0.convToRemove).FirstOrDefault();
				gClass.UOMUnitsConversions.DeleteOnSubmit(entity);
			}
		}
		Helper.SubmitChangesWithCatch(gClass);
		new NotificationLabel(this, Resources.Conversions_successfully_saved, NotificationTypes.Success).Show();
	}

	private void ftlrVmohYq(object sender, EventArgs e)
	{
		UOMConversionBodyControl uOMConversionBodyControl = new UOMConversionBodyControl(pnlToUnits, new GClass7
		{
			Id = 0,
			ItemID = int_0,
			BaseUnitId = (short)int_1,
			ToUnitId = 0,
			Factor = 1m,
			Operator = "*"
		}, this);
		uOMConversionBodyControl.btnRemoveClick += UOMConvControl_btnRemoveClick;
		uOMConversionBodyControl.txtFactorChanged += UOMConvControl_txtFactorChanged;
		uOMConversionBodyControl.btnRemoveClick += UOMConvControl_btnRemoveClick;
		pnlToUnits.Controls.Add(uOMConversionBodyControl);
	}

	private void txtSampleQty_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextFilters.NumbersWithSingleDecimalPoint(sender, e);
	}

	private void btnNewBaseUnit_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_New_Unit_of_Measure_Name, 2);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			GClass6 gClass = new GClass6();
			if (!(MemoryLoadedObjects.Keyboard.textEntered.ToUpper() == "LB") && !(MemoryLoadedObjects.Keyboard.textEntered.ToUpper() == "KG") && !(MemoryLoadedObjects.Keyboard.textEntered.ToUpper() == "OZ") && gClass.UOMs.Where((UOM x) => x.Name.ToUpper() == MemoryLoadedObjects.Keyboard.textEntered.Trim().ToUpper()).Count() <= 0)
			{
				UOM uOM = new UOM();
				uOM.Name = MemoryLoadedObjects.Keyboard.textEntered;
				uOM.isFractional = false;
				uOM.Synced = false;
				gClass.UOMs.InsertOnSubmit(uOM);
				Helper.SubmitChangesWithCatch(gClass);
				new NotificationLabel(this, Resources.UOM_has_successfully_been_save, NotificationTypes.Success).Show();
			}
			else
			{
				new NotificationLabel(this, Resources.The_UOM_you_entered_already_ex, NotificationTypes.Warning).Show();
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_4()
	{
		pnlToUnits.Controls.Clear();
		UOMConversionHeaderControl value = new UOMConversionHeaderControl(pnlToUnits);
		pnlToUnits.Controls.Add(value);
	}

	private void KwOrbYumDs_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.None;
		Close();
	}

	private void btnShowKeyboard_SampleQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Sample_Quantity, 4, 8, txtSampleQty.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtSampleQty.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmUOMConversions));
		lblTitleBar = new Label();
		label8 = new Label();
		label3 = new Label();
		pnlToUnits = new FlowLayoutPanel();
		btnSave = new Button();
		KwOrbYumDs = new Button();
		lblSampleConversion = new Label();
		label2 = new Label();
		txtSampleQty = new RadTextBoxControl();
		btnAddToUnit = new Button();
		btnNewBaseUnit = new Button();
		btnShowKeyboard_SampleQty = new Button();
		lblStockUOMName = new Label();
		((ISupportInitialize)txtSampleQty).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblTitleBar, "lblTitleBar");
		lblTitleBar.BackColor = Color.FromArgb(147, 101, 184);
		lblTitleBar.ForeColor = Color.White;
		lblTitleBar.Name = "lblTitleBar";
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(147, 101, 184);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(pnlToUnits, "pnlToUnits");
		pnlToUnits.Name = "pnlToUnits";
		btnSave.BackColor = Color.FromArgb(65, 168, 95);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		KwOrbYumDs.BackColor = Color.FromArgb(235, 107, 86);
		KwOrbYumDs.FlatAppearance.BorderColor = Color.Sienna;
		KwOrbYumDs.FlatAppearance.BorderSize = 0;
		KwOrbYumDs.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(KwOrbYumDs, "btnClose");
		KwOrbYumDs.ForeColor = Color.White;
		KwOrbYumDs.Name = "btnClose";
		KwOrbYumDs.UseVisualStyleBackColor = false;
		KwOrbYumDs.Click += KwOrbYumDs_Click;
		componentResourceManager.ApplyResources(lblSampleConversion, "lblSampleConversion");
		lblSampleConversion.BackColor = Color.FromArgb(61, 142, 185);
		lblSampleConversion.ForeColor = Color.White;
		lblSampleConversion.Name = "lblSampleConversion";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(txtSampleQty, "txtSampleQty");
		txtSampleQty.Name = "txtSampleQty";
		txtSampleQty.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSampleQty.TextChanged += txtSampleQty_TextChanged;
		txtSampleQty.Click += btnShowKeyboard_SampleQty_Click;
		txtSampleQty.KeyPress += txtSampleQty_KeyPress;
		((RadTextBoxControlElement)txtSampleQty.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSampleQty.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnAddToUnit.BackColor = Color.FromArgb(147, 101, 184);
		btnAddToUnit.FlatAppearance.BorderColor = Color.White;
		btnAddToUnit.FlatAppearance.BorderSize = 0;
		btnAddToUnit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddToUnit, "btnAddToUnit");
		btnAddToUnit.ForeColor = Color.White;
		btnAddToUnit.Name = "btnAddToUnit";
		btnAddToUnit.UseVisualStyleBackColor = false;
		btnAddToUnit.Click += ftlrVmohYq;
		btnNewBaseUnit.BackColor = Color.FromArgb(1, 110, 211);
		btnNewBaseUnit.FlatAppearance.BorderColor = Color.White;
		btnNewBaseUnit.FlatAppearance.BorderSize = 0;
		btnNewBaseUnit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNewBaseUnit, "btnNewBaseUnit");
		btnNewBaseUnit.ForeColor = Color.White;
		btnNewBaseUnit.Name = "btnNewBaseUnit";
		btnNewBaseUnit.UseVisualStyleBackColor = false;
		btnNewBaseUnit.Click += btnNewBaseUnit_Click;
		btnShowKeyboard_SampleQty.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SampleQty.DialogResult = DialogResult.OK;
		btnShowKeyboard_SampleQty.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SampleQty.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SampleQty, "btnShowKeyboard_SampleQty");
		btnShowKeyboard_SampleQty.ForeColor = Color.White;
		btnShowKeyboard_SampleQty.Name = "btnShowKeyboard_SampleQty";
		btnShowKeyboard_SampleQty.UseVisualStyleBackColor = false;
		btnShowKeyboard_SampleQty.Click += btnShowKeyboard_SampleQty_Click;
		lblStockUOMName.BackColor = Color.Gainsboro;
		componentResourceManager.ApplyResources(lblStockUOMName, "lblStockUOMName");
		lblStockUOMName.ForeColor = Color.Black;
		lblStockUOMName.Name = "lblStockUOMName";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(lblStockUOMName);
		base.Controls.Add(btnShowKeyboard_SampleQty);
		base.Controls.Add(btnNewBaseUnit);
		base.Controls.Add(txtSampleQty);
		base.Controls.Add(label2);
		base.Controls.Add(lblSampleConversion);
		base.Controls.Add(KwOrbYumDs);
		base.Controls.Add(btnSave);
		base.Controls.Add(pnlToUnits);
		base.Controls.Add(label8);
		base.Controls.Add(lblTitleBar);
		base.Controls.Add(btnAddToUnit);
		base.Controls.Add(label3);
		base.Name = "frmUOMConversions";
		base.Opacity = 1.0;
		base.Load += SxKrlvctve;
		((ISupportInitialize)txtSampleQty).EndInit();
		ResumeLayout(performLayout: false);
	}
}
