using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class TaxRuleControl : UserControl
{
	private GClass6 gclass6_0;

	private int int_0;

	private Guid guid_0;

	private IContainer icontainer_0;

	private ComboBox cboOperators;

	private Label label1;

	private ComboBox cboTaxCodes;

	private Button btnRemove;

	internal Button btnShowKeyboard_Condition;

	private RadTextBoxControl txtCondition;

	private ComboBox ddlRequirements;

	public TaxRuleControl(Guid RequirementID)
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		// base._002Ector();
		InitializeComponent();
		guid_0 = RequirementID;
		method_0();
		method_1();
		method_2();
	}

	private void TaxRuleControl_Load(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		ddlRequirements.Items.Clear();
		List<TaxRuleRequirement> list = gclass6_0.TaxRuleRequirements.ToList();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (TaxRuleRequirement item in list)
		{
			dictionary.Add(item.TaxRuleRequirementId.ToString(), item.RequirementDesc);
		}
		ddlRequirements.DisplayMember = "Value";
		ddlRequirements.ValueMember = "Key";
		ddlRequirements.DataSource = new BindingSource(dictionary, null);
	}

	private void method_1()
	{
		cboTaxCodes.Items.Clear();
		List<Tax> list = gclass6_0.Taxes.OrderBy((Tax s) => s.TaxCode).ToList();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Tax item in list)
		{
			dictionary.Add(item.TaxID.ToString(), (!item.Inactive) ? item.TaxCode : (item.TaxCode + Resources._Inactive));
		}
		cboTaxCodes.DisplayMember = "Value";
		cboTaxCodes.ValueMember = "Key";
		cboTaxCodes.DataSource = new BindingSource(dictionary, null);
	}

	private void method_2()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("<", "Less Than");
		dictionary.Add("<=", "Less Than OR Equal To");
		dictionary.Add("=", "Equal To");
		dictionary.Add(">=", "Greater Than OR Equal To");
		dictionary.Add(">", "Greater Than");
		cboOperators.DisplayMember = "Value";
		cboOperators.ValueMember = "Key";
		cboOperators.DataSource = new BindingSource(dictionary, null);
	}

	public bool Save(int ruleID)
	{
		if (ruleID != 0)
		{
			try
			{
				if (txtCondition.Text.Trim() == string.Empty)
				{
					new frmMessageBox(Resources.Please_input_a_value_for_the_c, Resources.Missing_Value).ShowDialog(this);
					return false;
				}
				TaxRuleOperation taxRuleOperation;
				if (int_0 == 0)
				{
					taxRuleOperation = new TaxRuleOperation();
					gclass6_0.TaxRuleOperations.InsertOnSubmit(taxRuleOperation);
				}
				else
				{
					taxRuleOperation = gclass6_0.TaxRuleOperations.Where((TaxRuleOperation t) => t.TaxRuleOperatorId == int_0).FirstOrDefault();
					if (taxRuleOperation == null)
					{
						int_0 = 0;
						taxRuleOperation = new TaxRuleOperation();
						gclass6_0.TaxRuleOperations.InsertOnSubmit(taxRuleOperation);
					}
				}
				taxRuleOperation.TaxRuleRequirementID = new Guid(ddlRequirements.SelectedValue.ToString());
				taxRuleOperation.TaxRuleId = ruleID;
				taxRuleOperation.Operator = cboOperators.SelectedValue.ToString();
				taxRuleOperation.Condition = Convert.ToDecimal(txtCondition.Text.Trim());
				taxRuleOperation.TaxID = Convert.ToInt32(cboTaxCodes.SelectedValue);
				taxRuleOperation.Synced = false;
				Helper.SubmitChangesWithCatch(gclass6_0);
				return true;
			}
			catch (Exception)
			{
				new frmMessageBox(Resources.Unable_to_add_Tax_Rule_Operati, Resources.Unable_to_perform_operation).ShowDialog(this);
				return false;
			}
		}
		new frmMessageBox(Resources.Unable_to_add_Tax_Rule_Operati, Resources.Unable_to_perform_operation).ShowDialog(this);
		return false;
	}

	public void LoadValues(int _RuleOperationID)
	{
		int_0 = _RuleOperationID;
		TaxRuleOperation taxRuleOperation = new TaxRuleOperation();
		taxRuleOperation = gclass6_0.TaxRuleOperations.Where((TaxRuleOperation t) => t.TaxRuleOperatorId == int_0).FirstOrDefault();
		ddlRequirements.SelectedValue = taxRuleOperation.TaxRuleRequirementID.ToString();
		cboOperators.SelectedValue = taxRuleOperation.Operator;
		txtCondition.Text = taxRuleOperation.Condition.ToString();
		cboTaxCodes.SelectedValue = taxRuleOperation.TaxID.ToString();
	}

	private void btnRemove_Click(object sender, EventArgs e)
	{
		if (int_0 > 0 && new frmMessageBox(Resources.Are_you_sure_you_want_to_delet5, Resources.DELETE0, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			TaxRuleOperation taxRuleOperation = new TaxRuleOperation();
			taxRuleOperation = gclass6_0.TaxRuleOperations.Where((TaxRuleOperation t) => t.TaxRuleOperatorId == int_0 && t.TaxRuleOperatorId > 13).FirstOrDefault();
			if (taxRuleOperation != null)
			{
				gclass6_0.TaxRuleOperations.DeleteOnSubmit(taxRuleOperation);
				Helper.SubmitChangesWithCatch(gclass6_0);
				Dispose();
			}
			else
			{
				new frmMessageBox(Resources.You_cannot_delete_a_preconfigu).ShowDialog(this);
			}
		}
	}

	private void btnShowKeyboard_Condition_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Condition, 4);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtCondition.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void txtCondition_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.TaxRuleControl));
		this.cboOperators = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.cboTaxCodes = new System.Windows.Forms.ComboBox();
		this.btnRemove = new System.Windows.Forms.Button();
		this.btnShowKeyboard_Condition = new System.Windows.Forms.Button();
		this.txtCondition = new Telerik.WinControls.UI.RadTextBoxControl();
		this.ddlRequirements = new System.Windows.Forms.ComboBox();
		((System.ComponentModel.ISupportInitialize)this.txtCondition).BeginInit();
		base.SuspendLayout();
		this.cboOperators.BackColor = System.Drawing.Color.White;
		this.cboOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboOperators.DropDownWidth = 150;
		componentResourceManager.ApplyResources(this.cboOperators, "cboOperators");
		this.cboOperators.Name = "cboOperators";
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.Name = "label1";
		this.cboTaxCodes.BackColor = System.Drawing.Color.White;
		this.cboTaxCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(this.cboTaxCodes, "cboTaxCodes");
		this.cboTaxCodes.FormattingEnabled = true;
		this.cboTaxCodes.Name = "cboTaxCodes";
		this.btnRemove.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(this.btnRemove, "btnRemove");
		this.btnRemove.Name = "btnRemove";
		this.btnRemove.UseVisualStyleBackColor = true;
		this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
		this.btnShowKeyboard_Condition.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
		this.btnShowKeyboard_Condition.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnShowKeyboard_Condition.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnShowKeyboard_Condition.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(this.btnShowKeyboard_Condition, "btnShowKeyboard_Condition");
		this.btnShowKeyboard_Condition.ForeColor = System.Drawing.Color.White;
		this.btnShowKeyboard_Condition.Name = "btnShowKeyboard_Condition";
		this.btnShowKeyboard_Condition.UseVisualStyleBackColor = false;
		this.btnShowKeyboard_Condition.Click += new System.EventHandler(btnShowKeyboard_Condition_Click);
		this.txtCondition.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		componentResourceManager.ApplyResources(this.txtCondition, "txtCondition");
		this.txtCondition.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.txtCondition.Name = "txtCondition";
		this.txtCondition.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtCondition.Click += new System.EventHandler(txtCondition_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtCondition.GetChildAt(0)).BorderWidth = 1f;
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtCondition.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		this.ddlRequirements.BackColor = System.Drawing.Color.White;
		this.ddlRequirements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ddlRequirements.DropDownWidth = 150;
		componentResourceManager.ApplyResources(this.ddlRequirements, "ddlRequirements");
		this.ddlRequirements.Name = "ddlRequirements";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.Transparent;
		base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		base.Controls.Add(this.ddlRequirements);
		base.Controls.Add(this.txtCondition);
		base.Controls.Add(this.btnShowKeyboard_Condition);
		base.Controls.Add(this.btnRemove);
		base.Controls.Add(this.cboTaxCodes);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cboOperators);
		this.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		base.Name = "TaxRuleControl";
		componentResourceManager.ApplyResources(this, "$this");
		base.Load += new System.EventHandler(TaxRuleControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtCondition).EndInit();
		base.ResumeLayout(false);
	}
}
