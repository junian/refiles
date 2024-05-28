using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAdminTaxSettings : frmMasterForm
{
	private int int_0;

	private int int_1;

	private IContainer icontainer_1;

	private Label label9;

	private TabControl tabControl1;

	private TabPage tabTaxCodes;

	internal Button btnShowKeyboard_TaxPercent;

	internal Button btnShowKeyboard_TaxCode;

	internal Button btnNew;

	private Label label10;

	private ListView lstSettings;

	internal Button btnCancel;

	private Label DkNaUlgRow;

	private Label label2;

	internal Button btnSave;

	private Label label1;

	private TabPage tabTaxRules;

	internal Button btnShowKeyboard_RuleName;

	internal Button btnNewRule;

	private Label label3;

	private ListView lstTaxRules;

	internal Button btnRuleDelete;

	private Label YaqaYjmcOV;

	internal Button button4;

	private Label label7;

	private FlowLayoutPanel pnlRules;

	private Button btnAddRuleOperation;

	private ColumnHeader columnHeader_0;

	private Label label5;

	private RadToggleSwitch chkActive;

	private Label label8;

	private RadToggleSwitch chkRuleActive;

	private RadTextBoxControl txtTaxPercent;

	private RadTextBoxControl txtTaxCode;

	private RadTextBoxControl txtRuleName;

	public frmAdminTaxSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		TheaTkiFof();
		new FormHelper().ResizeButtonFonts(this, 2f);
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (txtTaxCode.Text.Trim() == string.Empty)
		{
			new frmMessageBox(Resources.Name_is_required).ShowDialog(this);
			return;
		}
		if (string.IsNullOrEmpty(txtTaxPercent.Text.Trim()))
		{
			new frmMessageBox(Resources.Tax_Percentage_is_required).ShowDialog(this);
			return;
		}
		char value = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
		if (txtTaxPercent.Text != "0" && !txtTaxPercent.Text.Contains(value))
		{
			new frmMessageBox(Resources.Tax_Percentage_must_be_a_decim).ShowDialog(this);
			return;
		}
		decimal num = default(decimal);
		try
		{
			num = Convert.ToDecimal(txtTaxPercent.Text.Trim());
			if (num < 0m || num > 1m)
			{
				new frmMessageBox(Resources.Tax_Percentage_must_be_a_decim).ShowDialog(this);
				return;
			}
		}
		catch
		{
			new frmMessageBox(Resources.Tax_Percentage_must_be_a_decim).ShowDialog(this);
			return;
		}
		GClass6 gClass = new GClass6();
		if (int_0 == 0)
		{
			Tax tax = new Tax();
			tax.TaxCode = txtTaxCode.Text.Trim();
			tax.Percentage = Convert.ToDecimal(txtTaxPercent.Text.Trim());
			tax.Inactive = !chkActive.Value;
			tax.Synced = false;
			gClass.Taxes.InsertOnSubmit(tax);
			Helper.SubmitChangesWithCatch(gClass);
		}
		else
		{
			Tax tax = gClass.Taxes.Where((Tax s) => s.TaxID == int_0).FirstOrDefault();
			if (tax != null)
			{
				tax.Inactive = !chkActive.Value;
				tax.TaxCode = txtTaxCode.Text.Trim();
				tax.Percentage = Convert.ToDecimal(txtTaxPercent.Text.Trim());
				tax.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		method_3();
		new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void frmAdminTaxSettings_Load(object sender, EventArgs e)
	{
		method_3();
		XfSagycAkE();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		lstSettings.Clear();
		foreach (Tax item in gClass.Taxes.OrderBy((Tax s) => s.TaxCode).ToList())
		{
			lstSettings.Items.Add(new ListViewItem(new string[2]
			{
				item.TaxCode,
				item.TaxID.ToString()
			}));
		}
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		method_4();
		int_0 = 0;
	}

	private void method_4()
	{
		txtTaxCode.Text = string.Empty;
		txtTaxPercent.Text = string.Empty;
	}

	private void lstSettings_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		GClass6 gClass = new GClass6();
		if (lstSettings.SelectedItems.Count != 0)
		{
			int_0 = Convert.ToInt32(lstSettings.SelectedItems[0].SubItems[1].Text);
			Tax tax = gClass.Taxes.Where((Tax s) => s.TaxID == int_0).FirstOrDefault();
			txtTaxCode.Text = tax.TaxCode;
			txtTaxPercent.Text = tax.Percentage.ToString();
			chkActive.Value = !tax.Inactive;
		}
		else
		{
			txtTaxCode.Text = string.Empty;
			txtTaxPercent.Text = string.Empty;
			chkActive.Value = true;
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		int_0 = 0;
		txtTaxCode.Text = string.Empty;
		txtTaxPercent.Text = string.Empty;
		chkActive.Value = true;
		if (lstSettings.SelectedItems.Count > 0)
		{
			lstSettings.SelectedItems[0].Selected = false;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Tax_Code);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtTaxCode.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Tax_Percentage);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtTaxPercent.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
	}

	private void btnNewRule_Click(object sender, EventArgs e)
	{
		int_1 = 0;
		pnlRules.Controls.Clear();
		txtRuleName.Text = string.Empty;
		chkRuleActive.Value = true;
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtRuleName.Text.Trim()))
		{
			new NotificationLabel(this, "Rule name cannot be blank.", NotificationTypes.Notification).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		TaxRule taxRule;
		if (int_1 == 0)
		{
			taxRule = new TaxRule();
			gClass.TaxRules.InsertOnSubmit(taxRule);
		}
		else
		{
			taxRule = gClass.TaxRules.Where((TaxRule s) => s.TaxRuleId == int_1).FirstOrDefault();
			if (taxRule == null)
			{
				int_1 = 0;
				taxRule = new TaxRule();
				gClass.TaxRules.InsertOnSubmit(taxRule);
			}
		}
		taxRule.RuleName = txtRuleName.Text.Trim();
		taxRule.Active = chkRuleActive.Value;
		taxRule.Synced = false;
		Helper.SubmitChangesWithCatch(gClass);
		int_1 = taxRule.TaxRuleId;
		foreach (Control control in pnlRules.Controls)
		{
			if (control.GetType().ToString().Contains("TaxRuleControl") && !((TaxRuleControl)control).Save(taxRule.TaxRuleId))
			{
				return;
			}
		}
		foreach (Control control2 in pnlRules.Controls)
		{
			control2.Dispose();
		}
		new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
		XfSagycAkE();
		method_10(taxRule.RuleName);
	}

	private void XfSagycAkE()
	{
		GClass6 gClass = new GClass6();
		lstTaxRules.Clear();
		foreach (TaxRule item in gClass.TaxRules.OrderBy((TaxRule s) => s.RuleName).ToList())
		{
			lstTaxRules.Items.Add(new ListViewItem(new string[2]
			{
				item.RuleName,
				item.TaxRuleId.ToString()
			}));
		}
	}

	private void btnAddRuleOperation_Click(object sender, EventArgs e)
	{
		TaxRuleControl value = new TaxRuleControl(new Guid("58ff6ce4-00e9-47b4-97ba-3fe1179464d3"));
		pnlRules.Controls.Add(value);
	}

	private void lstTaxRules_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_10(string string_0 = "")
	{
		if (!string.IsNullOrEmpty(string_0) && lstTaxRules.SelectedItems.Count == 0)
		{
			ListViewItem listViewItem = lstTaxRules.FindItemWithText(string_0);
			if (listViewItem != null)
			{
				listViewItem.Selected = true;
			}
		}
		method_11();
		GClass6 gClass = new GClass6();
		if (lstTaxRules.SelectedItems.Count != 0)
		{
			int_1 = Convert.ToInt32(lstTaxRules.SelectedItems[0].SubItems[1].Text);
			TaxRule taxRule = gClass.TaxRules.Where((TaxRule s) => s.TaxRuleId == int_1).FirstOrDefault();
			if (taxRule != null)
			{
				txtRuleName.Text = taxRule.RuleName;
				chkRuleActive.Value = taxRule.Active;
				{
					foreach (TaxRuleOperation taxRuleOperation in taxRule.TaxRuleOperations)
					{
						TaxRuleControl taxRuleControl = new TaxRuleControl(taxRuleOperation.TaxRuleRequirementID);
						taxRuleControl.LoadValues(taxRuleOperation.TaxRuleOperatorId);
						pnlRules.Controls.Add(taxRuleControl);
					}
					return;
				}
			}
			new frmMessageBox(Resources.Something_went_wrong, Resources.An_error_has_occurred).ShowDialog(this);
		}
		else
		{
			method_11();
		}
	}

	private void btnRuleDelete_Click(object sender, EventArgs e)
	{
		if (lstTaxRules.SelectedItems.Count != 0)
		{
			int_1 = Convert.ToInt32(lstTaxRules.SelectedItems[0].SubItems[1].Text);
			if (new frmMessageBox(Resources.Are_you_sure_you_want_to_delet2, Resources.Delete_Confirmation, CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
			{
				return;
			}
			GClass6 gClass = new GClass6();
			TaxRule taxRule = gClass.TaxRules.Where((TaxRule s) => s.TaxRuleId == int_1).FirstOrDefault();
			if (taxRule != null)
			{
				foreach (TaxRuleOperation taxRuleOperation in taxRule.TaxRuleOperations)
				{
					gClass.TaxRuleOperations.DeleteOnSubmit(taxRuleOperation);
				}
				try
				{
					gClass.TaxRules.DeleteOnSubmit(taxRule);
					Helper.SubmitChangesWithCatch(gClass);
					gClass.TaxRules.FirstOrDefault().Synced = false;
					Helper.SubmitChangesWithCatch(gClass);
				}
				catch
				{
					new frmMessageBox(Resources.Unable_to_delete_this_rule_The, Resources.Unable_to_Delete_Rule).ShowDialog(this);
					return;
				}
				new frmMessageBox(Resources.Tax_Rule_has_been_deleted, Resources.Delete_Successful).ShowDialog(this);
				XfSagycAkE();
				method_11();
			}
			else
			{
				new frmMessageBox(Resources.Something_went_wrong, Resources.An_error_has_occurred).ShowDialog(this);
			}
		}
		else
		{
			method_11();
			new frmMessageBox(Resources.Please_select_a_Rule_to_delete, Resources.Unable_to_delete).ShowDialog(this);
		}
	}

	private void method_11()
	{
		txtRuleName.Text = string.Empty;
		chkActive.Value = true;
		ControlHelpers.ClearControlsInPanel(pnlRules);
		pnlRules.Controls.Clear();
	}

	private void btnShowKeyboard_TaxCode_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Tax_Code, 0, 10);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtTaxCode.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void btnShowKeyboard_TaxPercent_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Tax_Percentage, 5, 10, txtTaxPercent.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtTaxPercent.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
	}

	private void btnShowKeyboard_RuleName_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Rule_Name);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtRuleName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void txtRuleName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void label10_Click(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void TheaTkiFof()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAdminTaxSettings));
		tabControl1 = new TabControl();
		tabTaxCodes = new TabPage();
		txtTaxPercent = new RadTextBoxControl();
		txtTaxCode = new RadTextBoxControl();
		label8 = new Label();
		chkActive = new RadToggleSwitch();
		btnShowKeyboard_TaxPercent = new Button();
		btnShowKeyboard_TaxCode = new Button();
		btnNew = new Button();
		label10 = new Label();
		lstSettings = new ListView();
		btnCancel = new Button();
		DkNaUlgRow = new Label();
		label2 = new Label();
		btnSave = new Button();
		label1 = new Label();
		tabTaxRules = new TabPage();
		pnlRules = new FlowLayoutPanel();
		txtRuleName = new RadTextBoxControl();
		chkRuleActive = new RadToggleSwitch();
		btnAddRuleOperation = new Button();
		btnShowKeyboard_RuleName = new Button();
		btnNewRule = new Button();
		label3 = new Label();
		lstTaxRules = new ListView();
		columnHeader_0 = new ColumnHeader();
		btnRuleDelete = new Button();
		YaqaYjmcOV = new Label();
		button4 = new Button();
		label7 = new Label();
		label5 = new Label();
		label9 = new Label();
		tabControl1.SuspendLayout();
		tabTaxCodes.SuspendLayout();
		((ISupportInitialize)txtTaxPercent).BeginInit();
		((ISupportInitialize)txtTaxCode).BeginInit();
		((ISupportInitialize)chkActive).BeginInit();
		tabTaxRules.SuspendLayout();
		((ISupportInitialize)txtRuleName).BeginInit();
		((ISupportInitialize)chkRuleActive).BeginInit();
		SuspendLayout();
		tabControl1.Controls.Add(tabTaxCodes);
		tabControl1.Controls.Add(tabTaxRules);
		componentResourceManager.ApplyResources(tabControl1, "tabControl1");
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.SizeMode = TabSizeMode.Fixed;
		tabTaxCodes.Controls.Add(txtTaxPercent);
		tabTaxCodes.Controls.Add(txtTaxCode);
		tabTaxCodes.Controls.Add(label8);
		tabTaxCodes.Controls.Add(chkActive);
		tabTaxCodes.Controls.Add(btnShowKeyboard_TaxPercent);
		tabTaxCodes.Controls.Add(btnShowKeyboard_TaxCode);
		tabTaxCodes.Controls.Add(btnNew);
		tabTaxCodes.Controls.Add(label10);
		tabTaxCodes.Controls.Add(lstSettings);
		tabTaxCodes.Controls.Add(btnCancel);
		tabTaxCodes.Controls.Add(DkNaUlgRow);
		tabTaxCodes.Controls.Add(label2);
		tabTaxCodes.Controls.Add(btnSave);
		tabTaxCodes.Controls.Add(label1);
		componentResourceManager.ApplyResources(tabTaxCodes, "tabTaxCodes");
		tabTaxCodes.Name = "tabTaxCodes";
		componentResourceManager.ApplyResources(txtTaxPercent, "txtTaxPercent");
		txtTaxPercent.ForeColor = Color.FromArgb(40, 40, 40);
		txtTaxPercent.Name = "txtTaxPercent";
		txtTaxPercent.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtTaxPercent.Click += txtRuleName_Click;
		((RadTextBoxControlElement)txtTaxPercent.GetChildAt(0)).BorderWidth = 1f;
		((TextBoxViewElement)txtTaxPercent.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(txtTaxCode, "txtTaxCode");
		txtTaxCode.ForeColor = Color.FromArgb(40, 40, 40);
		txtTaxCode.Name = "txtTaxCode";
		txtTaxCode.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtTaxCode.Click += txtRuleName_Click;
		((RadTextBoxControlElement)txtTaxCode.GetChildAt(0)).BorderWidth = 1f;
		((TextBoxViewElement)txtTaxCode.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label8.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(label8, "label8");
		label8.Name = "label8";
		label8.UseWaitCursor = true;
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		chkActive.Name = "chkActive";
		chkActive.OffText = "NO";
		chkActive.OnText = "YES";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		btnShowKeyboard_TaxPercent.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_TaxPercent.DialogResult = DialogResult.OK;
		btnShowKeyboard_TaxPercent.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_TaxPercent.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_TaxPercent, "btnShowKeyboard_TaxPercent");
		btnShowKeyboard_TaxPercent.ForeColor = Color.White;
		btnShowKeyboard_TaxPercent.Name = "btnShowKeyboard_TaxPercent";
		btnShowKeyboard_TaxPercent.UseVisualStyleBackColor = false;
		btnShowKeyboard_TaxPercent.Click += btnShowKeyboard_TaxPercent_Click;
		btnShowKeyboard_TaxCode.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_TaxCode.DialogResult = DialogResult.OK;
		btnShowKeyboard_TaxCode.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_TaxCode.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_TaxCode, "btnShowKeyboard_TaxCode");
		btnShowKeyboard_TaxCode.ForeColor = Color.White;
		btnShowKeyboard_TaxCode.Name = "btnShowKeyboard_TaxCode";
		btnShowKeyboard_TaxCode.UseVisualStyleBackColor = false;
		btnShowKeyboard_TaxCode.Click += btnShowKeyboard_TaxCode_Click;
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.White;
		btnNew.FlatAppearance.MouseDownBackColor = Color.DodgerBlue;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		label10.BackColor = Color.FromArgb(213, 84, 1);
		label10.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label10.Click += label10_Click;
		lstSettings.AutoArrange = false;
		lstSettings.BorderStyle = BorderStyle.FixedSingle;
		lstSettings.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstSettings, "lstSettings");
		lstSettings.ForeColor = Color.Black;
		lstSettings.FullRowSelect = true;
		lstSettings.GridLines = true;
		lstSettings.Groups.AddRange(new ListViewGroup[2]
		{
			(ListViewGroup)componentResourceManager.GetObject("lstSettings.Groups"),
			(ListViewGroup)componentResourceManager.GetObject("lstSettings.Groups1")
		});
		lstSettings.HideSelection = false;
		lstSettings.MultiSelect = false;
		lstSettings.Name = "lstSettings";
		lstSettings.UseCompatibleStateImageBehavior = false;
		lstSettings.View = View.List;
		lstSettings.SelectedIndexChanged += lstSettings_SelectedIndexChanged;
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		DkNaUlgRow.BackColor = Color.FromArgb(53, 152, 220);
		DkNaUlgRow.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(DkNaUlgRow, "label6");
		DkNaUlgRow.ForeColor = Color.White;
		DkNaUlgRow.Name = "label6";
		label2.BackColor = Color.FromArgb(27, 188, 157);
		label2.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		btnSave.BackColor = Color.FromArgb(47, 204, 113);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.Green;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		label1.BackColor = Color.FromArgb(1, 110, 211);
		label1.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		tabTaxRules.Controls.Add(pnlRules);
		tabTaxRules.Controls.Add(txtRuleName);
		tabTaxRules.Controls.Add(chkRuleActive);
		tabTaxRules.Controls.Add(btnAddRuleOperation);
		tabTaxRules.Controls.Add(btnShowKeyboard_RuleName);
		tabTaxRules.Controls.Add(btnNewRule);
		tabTaxRules.Controls.Add(label3);
		tabTaxRules.Controls.Add(lstTaxRules);
		tabTaxRules.Controls.Add(btnRuleDelete);
		tabTaxRules.Controls.Add(YaqaYjmcOV);
		tabTaxRules.Controls.Add(button4);
		tabTaxRules.Controls.Add(label7);
		tabTaxRules.Controls.Add(label5);
		componentResourceManager.ApplyResources(tabTaxRules, "tabTaxRules");
		tabTaxRules.Name = "tabTaxRules";
		componentResourceManager.ApplyResources(pnlRules, "pnlRules");
		pnlRules.BorderStyle = BorderStyle.FixedSingle;
		pnlRules.Name = "pnlRules";
		componentResourceManager.ApplyResources(txtRuleName, "txtRuleName");
		txtRuleName.ForeColor = Color.FromArgb(40, 40, 40);
		txtRuleName.Name = "txtRuleName";
		txtRuleName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtRuleName.Click += txtRuleName_Click;
		((RadTextBoxControlElement)txtRuleName.GetChildAt(0)).BorderWidth = 1f;
		((TextBoxViewElement)txtRuleName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(chkRuleActive, "chkRuleActive");
		chkRuleActive.Name = "chkRuleActive";
		chkRuleActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkRuleActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkRuleActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkRuleActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkRuleActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkRuleActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkRuleActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		btnAddRuleOperation.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddRuleOperation, "btnAddRuleOperation");
		btnAddRuleOperation.Name = "btnAddRuleOperation";
		btnAddRuleOperation.UseVisualStyleBackColor = true;
		btnAddRuleOperation.Click += btnAddRuleOperation_Click;
		btnShowKeyboard_RuleName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_RuleName.DialogResult = DialogResult.OK;
		btnShowKeyboard_RuleName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_RuleName.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_RuleName, "btnShowKeyboard_RuleName");
		btnShowKeyboard_RuleName.ForeColor = Color.White;
		btnShowKeyboard_RuleName.Name = "btnShowKeyboard_RuleName";
		btnShowKeyboard_RuleName.UseVisualStyleBackColor = false;
		btnShowKeyboard_RuleName.Click += btnShowKeyboard_RuleName_Click;
		componentResourceManager.ApplyResources(btnNewRule, "btnNewRule");
		btnNewRule.BackColor = Color.FromArgb(61, 142, 185);
		btnNewRule.FlatAppearance.BorderColor = Color.Black;
		btnNewRule.FlatAppearance.BorderSize = 0;
		btnNewRule.FlatAppearance.MouseDownBackColor = Color.White;
		btnNewRule.ForeColor = Color.White;
		btnNewRule.Name = "btnNewRule";
		btnNewRule.UseVisualStyleBackColor = false;
		btnNewRule.Click += btnNewRule_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		lstTaxRules.AutoArrange = false;
		lstTaxRules.BorderStyle = BorderStyle.FixedSingle;
		lstTaxRules.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstTaxRules.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstTaxRules, "lstTaxRules");
		lstTaxRules.ForeColor = Color.Black;
		lstTaxRules.FullRowSelect = true;
		lstTaxRules.GridLines = true;
		lstTaxRules.Groups.AddRange(new ListViewGroup[2]
		{
			(ListViewGroup)componentResourceManager.GetObject("lstTaxRules.Groups"),
			(ListViewGroup)componentResourceManager.GetObject("lstTaxRules.Groups1")
		});
		lstTaxRules.HideSelection = false;
		lstTaxRules.MultiSelect = false;
		lstTaxRules.Name = "lstTaxRules";
		lstTaxRules.UseCompatibleStateImageBehavior = false;
		lstTaxRules.View = View.List;
		lstTaxRules.SelectedIndexChanged += lstTaxRules_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "columnHeader1");
		componentResourceManager.ApplyResources(btnRuleDelete, "btnRuleDelete");
		btnRuleDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnRuleDelete.FlatAppearance.BorderColor = Color.White;
		btnRuleDelete.FlatAppearance.BorderSize = 0;
		btnRuleDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnRuleDelete.ForeColor = Color.White;
		btnRuleDelete.Name = "btnRuleDelete";
		btnRuleDelete.UseVisualStyleBackColor = false;
		btnRuleDelete.Click += btnRuleDelete_Click;
		componentResourceManager.ApplyResources(YaqaYjmcOV, "label4");
		YaqaYjmcOV.BackColor = Color.FromArgb(132, 146, 146);
		YaqaYjmcOV.ForeColor = Color.White;
		YaqaYjmcOV.Name = "label4";
		componentResourceManager.ApplyResources(button4, "button4");
		button4.BackColor = Color.FromArgb(80, 203, 116);
		button4.FlatAppearance.BorderColor = Color.White;
		button4.FlatAppearance.BorderSize = 0;
		button4.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button4.ForeColor = Color.White;
		button4.Name = "button4";
		button4.UseVisualStyleBackColor = false;
		button4.Click += button4_Click;
		label7.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label9.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(tabControl1);
		base.Controls.Add(label9);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAdminTaxSettings";
		base.Opacity = 1.0;
		base.Load += frmAdminTaxSettings_Load;
		tabControl1.ResumeLayout(performLayout: false);
		tabTaxCodes.ResumeLayout(performLayout: false);
		((ISupportInitialize)txtTaxPercent).EndInit();
		((ISupportInitialize)txtTaxCode).EndInit();
		((ISupportInitialize)chkActive).EndInit();
		tabTaxRules.ResumeLayout(performLayout: false);
		tabTaxRules.PerformLayout();
		((ISupportInitialize)txtRuleName).EndInit();
		((ISupportInitialize)chkRuleActive).EndInit();
		ResumeLayout(performLayout: false);
	}
}
