using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmCashCounter : frmMasterForm
{
	private string[] string_0;

	private decimal decimal_0;

	public decimal amountEntered;

	private string string_1;

	private Dictionary<string, string> dictionary_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Label labelSuggestedPrice;

	private FlowLayoutPanel pnlBills;

	private Button btnCancel;

	private Button btnSave;

	internal Button btnOpenRegister;

	private Label sideLabel;

	internal Class18 txtTotal;

	internal Button btnShowKeyboard_Total;

	public frmCashCounter(decimal totalAmountInTil, Dictionary<string, string> billsAdded = null, string type = "SafeDrop")
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = new string[5] { "100", "50", "20", "10", "5" };
		// base._002Ector();
		InitializeComponent_1();
		decimal_0 = totalAmountInTil;
		dictionary_0 = billsAdded;
		string_1 = type;
		if (type != PayoutTypes.SafeDrop)
		{
			string_0 = new string[10] { "100", "50", "20", "10", "5", "2", "1", "0.25", "0.10", "0.05" };
			base.Height += pnlBills.Height;
		}
		if (type == PayoutTypes.Payout)
		{
			lblTitle.Text = "SELECT BILLS && COINS FOR PAYOUT";
			return;
		}
		if (type == PayoutTypes.ClosingBalance)
		{
			lblTitle.Text = "CLOSING BALANCE";
			return;
		}
		if (type == PayoutTypes.OpeningBalance)
		{
			lblTitle.Text = "OPENING BALANCE";
			return;
		}
		Class18 @class = txtTotal;
		Label label = sideLabel;
		btnShowKeyboard_Total.Enabled = false;
		label.Enabled = false;
		@class.Enabled = false;
		lblTitle.Text = "SELECT BILLS FOR SAFE DROP";
	}

	private void frmCashCounter_Load(object sender, EventArgs e)
	{
		string[] array = string_0;
		foreach (string text in array)
		{
			Label label = new Label();
			label.BackColor = Color.Gray;
			label.Name = "lbl" + text;
			label.Text = (text.Contains('.') ? (text.Replace("0.0", string.Empty).Replace("0.", string.Empty) + "¢") : ("$" + text));
			label.Size = new Size(110, 50);
			label.ForeColor = Color.White;
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.Margin = new Padding(0, 1, 1, 0);
			label.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);
			pnlBills.Controls.Add(label);
			RadTextBoxControl radTextBoxControl = new RadTextBoxControl();
			radTextBoxControl.Name = "txt" + text;
			if (dictionary_0 != null && dictionary_0.ContainsKey(text))
			{
				radTextBoxControl.Text = dictionary_0[text];
			}
			else
			{
				radTextBoxControl.Text = "0";
			}
			radTextBoxControl.Tag = text;
			radTextBoxControl.Size = new Size(125, 50);
			radTextBoxControl.Click += method_3;
			radTextBoxControl.ForeColor = Color.Black;
			radTextBoxControl.TextAlign = HorizontalAlignment.Center;
			radTextBoxControl.Margin = new Padding(0, 1, 1, 0);
			radTextBoxControl.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold);
			pnlBills.Controls.Add(radTextBoxControl);
			Button button = new Button();
			button.BackColor = Color.FromArgb(80, 203, 116);
			button.ForeColor = Color.White;
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.Name = "plus" + text;
			button.Text = "+";
			button.Tag = radTextBoxControl.Name;
			button.Size = new Size(80, 50);
			button.TextAlign = ContentAlignment.MiddleCenter;
			button.Margin = new Padding(0, 1, 1, 0);
			button.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Regular);
			button.Click += method_4;
			pnlBills.Controls.Add(button);
			Button button2 = new Button();
			button2.BackColor = Color.FromArgb(235, 107, 86);
			button2.ForeColor = Color.White;
			button2.FlatStyle = FlatStyle.Flat;
			button2.FlatAppearance.BorderSize = 0;
			button2.Name = "minus" + text;
			button2.Text = "-";
			button2.Tag = radTextBoxControl.Name;
			button2.Size = new Size(81, 50);
			button2.TextAlign = ContentAlignment.MiddleCenter;
			button2.Margin = new Padding(0, 1, 0, 0);
			button2.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Regular);
			button2.Click += method_5;
			pnlBills.Controls.Add(button2);
		}
		method_7();
	}

	private void method_3(object sender, EventArgs e)
	{
		RadTextBoxControl radTextBoxControl = sender as RadTextBoxControl;
		string text = radTextBoxControl.Tag.ToString();
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter $" + text + " bills Qty", 0, 5, radTextBoxControl.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			radTextBoxControl.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
			method_7();
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_4(object sender, EventArgs e)
	{
		Button button = sender as Button;
		RadTextBoxControl radTextBoxControl = (RadTextBoxControl)pnlBills.Controls.Find(button.Tag.ToString(), searchAllChildren: false).FirstOrDefault();
		if (radTextBoxControl != null)
		{
			int num = Convert.ToInt32(radTextBoxControl.Text);
			radTextBoxControl.Text = (num + 1).ToString();
			method_7();
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		Button button = sender as Button;
		RadTextBoxControl radTextBoxControl = (RadTextBoxControl)pnlBills.Controls.Find(button.Tag.ToString(), searchAllChildren: false).FirstOrDefault();
		if (radTextBoxControl != null)
		{
			int num = Convert.ToInt32(radTextBoxControl.Text);
			if (num > 0)
			{
				radTextBoxControl.Text = (num - 1).ToString();
				method_7();
			}
		}
	}

	private bool method_6()
	{
		if (decimal_0 < Convert.ToDecimal(txtTotal.Text))
		{
			if (new frmMessageBox("Amount entered for closing balance amount is greater than the Cash sales. Proceed?", "Proceed?", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private void method_7()
	{
		decimal num = default(decimal);
		foreach (object control in pnlBills.Controls)
		{
			if (control is RadTextBoxControl)
			{
				RadTextBoxControl obj = control as RadTextBoxControl;
				decimal num2 = Convert.ToDecimal(obj.Tag.ToString());
				int num3 = Convert.ToInt32(obj.Text);
				num += num2 * (decimal)num3;
			}
		}
		txtTotal.Text = num.ToString("0.00");
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		amountEntered = Convert.ToDecimal(txtTotal.Text);
		if (amountEntered > 0m)
		{
			if (string_1 != PayoutTypes.OpeningBalance && !method_6())
			{
				base.DialogResult = DialogResult.None;
				return;
			}
			GClass6 gClass = new GClass6();
			Payout entity = new Payout
			{
				Amount = amountEntered,
				Reason = string_1,
				DateCreated = DateTime.Now
			};
			gClass.Payouts.InsertOnSubmit(entity);
			gClass.SubmitChanges();
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnOpenRegister_Click(object sender, EventArgs e)
	{
		GClass8.OpenCashDrawer();
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Total_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Please enter amount", 2, 10, txtTotal.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtTotal.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString("0.00");
			base.DialogResult = DialogResult.None;
		}
	}

	private void txtTotal_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCashCounter));
		btnCancel = new Button();
		btnSave = new Button();
		pnlBills = new FlowLayoutPanel();
		labelSuggestedPrice = new Label();
		lblTitle = new Label();
		btnOpenRegister = new Button();
		sideLabel = new Label();
		btnShowKeyboard_Total = new Button();
		txtTotal = new Class18();
		SuspendLayout();
		btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(275, 341);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(133, 80);
		btnCancel.TabIndex = 246;
		btnCancel.Text = "CANCEL";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(141, 341);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(133, 80);
		btnSave.TabIndex = 245;
		btnSave.Text = "DONE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		pnlBills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
		pnlBills.Location = new Point(8, 87);
		pnlBills.Margin = new Padding(0);
		pnlBills.Name = "pnlBills";
		pnlBills.Size = new Size(400, 253);
		pnlBills.TabIndex = 244;
		labelSuggestedPrice.BackColor = Color.Gray;
		labelSuggestedPrice.Font = new Font("Microsoft Sans Serif", 14f);
		labelSuggestedPrice.ForeColor = Color.White;
		labelSuggestedPrice.ImeMode = ImeMode.NoControl;
		labelSuggestedPrice.Location = new Point(8, 43);
		labelSuggestedPrice.Margin = new Padding(4, 0, 4, 0);
		labelSuggestedPrice.MinimumSize = new Size(120, 35);
		labelSuggestedPrice.Name = "labelSuggestedPrice";
		labelSuggestedPrice.Padding = new Padding(0, 0, 5, 0);
		labelSuggestedPrice.Size = new Size(172, 43);
		labelSuggestedPrice.TabIndex = 234;
		labelSuggestedPrice.Text = "TOTAL AMOUNT";
		labelSuggestedPrice.TextAlign = ContentAlignment.MiddleRight;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(8, 7);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(400, 35);
		lblTitle.TabIndex = 233;
		lblTitle.Text = "SELECT BILLS TO SAFE DROP";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		btnOpenRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnOpenRegister.BackColor = Color.FromArgb(50, 119, 155);
		btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
		btnOpenRegister.FlatAppearance.BorderSize = 0;
		btnOpenRegister.FlatStyle = FlatStyle.Flat;
		btnOpenRegister.Font = new Font("Microsoft Sans Serif", 9f);
		btnOpenRegister.ForeColor = Color.White;
		btnOpenRegister.Image = (Image)componentResourceManager.GetObject("btnOpenRegister.Image");
		btnOpenRegister.ImageAlign = ContentAlignment.TopCenter;
		btnOpenRegister.ImeMode = ImeMode.NoControl;
		btnOpenRegister.Location = new Point(7, 341);
		btnOpenRegister.Name = "btnOpenRegister";
		btnOpenRegister.Padding = new Padding(0, 5, 0, 5);
		btnOpenRegister.Size = new Size(133, 80);
		btnOpenRegister.TabIndex = 247;
		btnOpenRegister.Text = "OPEN TIL";
		btnOpenRegister.TextAlign = ContentAlignment.BottomCenter;
		btnOpenRegister.UseVisualStyleBackColor = false;
		btnOpenRegister.Click += btnOpenRegister_Click;
		sideLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		sideLabel.BackColor = Color.White;
		sideLabel.Font = new Font("Microsoft Sans Serif", 28f);
		sideLabel.ForeColor = Color.Black;
		sideLabel.ImeMode = ImeMode.NoControl;
		sideLabel.Location = new Point(181, 43);
		sideLabel.Name = "sideLabel";
		sideLabel.Size = new Size(35, 43);
		sideLabel.TabIndex = 249;
		sideLabel.Text = "$";
		btnShowKeyboard_Total.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnShowKeyboard_Total.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Total.DialogResult = DialogResult.OK;
		btnShowKeyboard_Total.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Total.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Total.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Total.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Total.ForeColor = Color.White;
		btnShowKeyboard_Total.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Total.Image");
		btnShowKeyboard_Total.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Total.Location = new Point(357, 43);
		btnShowKeyboard_Total.Name = "btnShowKeyboard_Total";
		btnShowKeyboard_Total.Size = new Size(51, 43);
		btnShowKeyboard_Total.TabIndex = 250;
		btnShowKeyboard_Total.Tag = "product";
		btnShowKeyboard_Total.UseVisualStyleBackColor = false;
		btnShowKeyboard_Total.Click += btnShowKeyboard_Total_Click;
		txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		txtTotal.BorderStyle = BorderStyle.None;
		txtTotal.Font = new Font("Microsoft Sans Serif", 28f, FontStyle.Bold);
		txtTotal.Location = new Point(215, 43);
		txtTotal.Margin = new Padding(3, 3, 15, 3);
		txtTotal.MaxLength = 10;
		txtTotal.Name = "txtTotal";
		txtTotal.Size = new Size(141, 43);
		txtTotal.TabIndex = 248;
		txtTotal.Text = "0.00";
		txtTotal.TextAlign = HorizontalAlignment.Right;
		txtTotal.method_1("keyboard");
		txtTotal.Click += txtTotal_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(416, 430);
		base.Controls.Add(btnShowKeyboard_Total);
		base.Controls.Add(sideLabel);
		base.Controls.Add(txtTotal);
		base.Controls.Add(btnOpenRegister);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(pnlBills);
		base.Controls.Add(labelSuggestedPrice);
		base.Controls.Add(lblTitle);
		base.Name = "frmCashCounter";
		base.Opacity = 1.0;
		Text = "Cash Counter";
		base.Load += frmCashCounter_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
