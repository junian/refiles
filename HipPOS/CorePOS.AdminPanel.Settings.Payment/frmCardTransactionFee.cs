using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings.Payment;

public class frmCardTransactionFee : frmMasterForm
{
	private IContainer icontainer_1;

	private Class19 ddlTender;

	private Label label2;

	private Class19 ddlCardType;

	private Label label5;

	private Button btnCancel;

	private Button btnSave;

	private Label label9;

	private Label label1;

	private RadTextBoxControl txtAmount;

	internal Button btnShowKeyboard_Amount;

	public frmCardTransactionFee()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmCardTransactionFee_Load(object sender, EventArgs e)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Debit", "Debit");
		dictionary.Add("Credit", "Credit");
		ddlCardType.DataSource = new BindingSource(dictionary, null);
		ddlCardType.DisplayMember = "Value";
		ddlCardType.ValueMember = "Key";
		ddlCardType.SelectedIndex = 0;
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		dictionary2.Add("$", "$");
		dictionary2.Add("%", "%");
		ddlTender.DataSource = new BindingSource(dictionary2, null);
		ddlTender.DisplayMember = "Value";
		ddlTender.ValueMember = "Key";
		ddlTender.SelectedIndex = 0;
		method_3();
	}

	private void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		if (ddlCardType.SelectedValue.ToString() == "Debit" || ddlCardType.SelectedValue.ToString() == "Credit")
		{
			CardTransactionFeeObject transactionFeeSetting = SettingsHelper.GetTransactionFeeSetting(ddlCardType.SelectedValue.ToString());
			ddlTender.SelectedValue = transactionFeeSetting.TenderType.ToString();
			((Control)(object)txtAmount).Text = transactionFeeSetting.Amount.ToString();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnShowKeyboard_Amount_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Amount", 1, 128, ((Control)(object)txtAmount).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtAmount).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		SettingsHelper.SetTransactionFeeSetting(ddlCardType.SelectedValue.ToString(), ddlTender.SelectedValue.ToString()[0], Convert.ToDecimal(((Control)(object)txtAmount).Text));
		new NotificationLabel(this, "Successfully Saved", NotificationTypes.Success);
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
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCardTransactionFee));
		ddlTender = new Class19();
		label2 = new Label();
		ddlCardType = new Class19();
		label5 = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		label1 = new Label();
		txtAmount = new RadTextBoxControl();
		btnShowKeyboard_Amount = new Button();
		((ISupportInitialize)txtAmount).BeginInit();
		SuspendLayout();
		ddlTender.BackColor = Color.White;
		ddlTender.DrawMode = DrawMode.OwnerDrawVariable;
		ddlTender.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlTender.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlTender.ForeColor = Color.FromArgb(40, 40, 40);
		ddlTender.FormattingEnabled = true;
		ddlTender.ItemHeight = 29;
		ddlTender.Location = new Point(153, 84);
		ddlTender.Margin = new Padding(4, 5, 4, 5);
		ddlTender.MinimumSize = new Size(50, 0);
		ddlTender.Name = "ddlTender";
		ddlTender.Size = new Size(380, 35);
		ddlTender.TabIndex = 255;
		ddlTender.Tag = "";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(1, 84);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(151, 35);
		label2.TabIndex = 254;
		label2.Text = "Type";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		ddlCardType.BackColor = Color.White;
		ddlCardType.DrawMode = DrawMode.OwnerDrawVariable;
		ddlCardType.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlCardType.Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold);
		ddlCardType.ForeColor = Color.FromArgb(40, 40, 40);
		ddlCardType.FormattingEnabled = true;
		ddlCardType.ItemHeight = 29;
		ddlCardType.Location = new Point(153, 48);
		ddlCardType.Margin = new Padding(4, 5, 4, 5);
		ddlCardType.MinimumSize = new Size(50, 0);
		ddlCardType.Name = "ddlCardType";
		ddlCardType.Size = new Size(380, 35);
		ddlCardType.TabIndex = 253;
		ddlCardType.Tag = "secondary_language";
		ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(1, 48);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(120, 35);
		label5.Name = "label5";
		label5.Size = new Size(151, 35);
		label5.TabIndex = 252;
		label5.Text = "Card Type";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(264, 156);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(268, 80);
		btnCancel.TabIndex = 251;
		btnCancel.Text = "CLOSE";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(1, 156);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(262, 80);
		btnSave.TabIndex = 250;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(1, 1);
		label9.Name = "label9";
		label9.Size = new Size(532, 46);
		label9.TabIndex = 249;
		label9.Text = "Card Transaction Fee";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		label1.AutoSize = true;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(1, 120);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(151, 35);
		label1.TabIndex = 257;
		label1.Text = "Amount/Percentage";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		((Control)(object)txtAmount).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtAmount).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtAmount).Location = new Point(154, 120);
		((Control)(object)txtAmount).Name = "txtAmount";
		((RadElement)((RadControl)txtAmount).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtAmount).Size = new Size(327, 35);
		((Control)(object)txtAmount).TabIndex = 256;
		((Control)(object)txtAmount).Click += btnShowKeyboard_Amount_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtAmount).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtAmount).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Amount.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Amount.DialogResult = DialogResult.OK;
		btnShowKeyboard_Amount.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Amount.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Amount.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Amount.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Amount.ForeColor = Color.White;
		btnShowKeyboard_Amount.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Amount.Image");
		btnShowKeyboard_Amount.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Amount.Location = new Point(482, 120);
		btnShowKeyboard_Amount.Name = "btnShowKeyboard_Amount";
		btnShowKeyboard_Amount.Size = new Size(51, 35);
		btnShowKeyboard_Amount.TabIndex = 258;
		btnShowKeyboard_Amount.UseVisualStyleBackColor = false;
		btnShowKeyboard_Amount.Click += btnShowKeyboard_Amount_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(537, 241);
		base.Controls.Add(btnShowKeyboard_Amount);
		base.Controls.Add(label1);
		base.Controls.Add((Control)(object)txtAmount);
		base.Controls.Add(ddlTender);
		base.Controls.Add(label2);
		base.Controls.Add(ddlCardType);
		base.Controls.Add(label5);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmCardTransactionFee";
		base.Opacity = 1.0;
		Text = "frmCardTransactionFee";
		base.Load += frmCardTransactionFee_Load;
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(label9, 0);
		base.Controls.SetChildIndex(btnSave, 0);
		base.Controls.SetChildIndex(btnCancel, 0);
		base.Controls.SetChildIndex(label5, 0);
		base.Controls.SetChildIndex(ddlCardType, 0);
		base.Controls.SetChildIndex(label2, 0);
		base.Controls.SetChildIndex(ddlTender, 0);
		base.Controls.SetChildIndex((Control)(object)txtAmount, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_Amount, 0);
		((ISupportInitialize)txtAmount).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
