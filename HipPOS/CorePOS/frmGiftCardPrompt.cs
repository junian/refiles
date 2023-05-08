using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmGiftCardPrompt : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_1;

	private Label label1;

	private RadTextBoxControl txtCardNumber;

	internal Button btnShowKeyboard_CardNumber;

	private Button btnSave;

	internal Label label3;

	private Button btnCancel;

	private Button boDeAndfTT;

	public string CardNumber
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int CardType
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public frmGiftCardPrompt(string title = "", bool GCAndLoyalty = false, string closeButtonText = "CLOSE")
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		if (!string.IsNullOrEmpty(title))
		{
			label3.Text = title;
		}
		btnCancel.Text = closeButtonText;
		bool_0 = GCAndLoyalty;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		method_3(1);
	}

	private void GmAelxlksQ(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Dispose();
		Close();
	}

	private void frmGiftCardPrompt_Load(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			boDeAndfTT.Visible = false;
			btnSave.Size = new Size((base.Width - 10) / 2, btnSave.Height);
			btnCancel.Size = new Size((base.Width - 10) / 2, btnCancel.Height);
			btnCancel.Location = new Point(btnSave.Right + 1, btnCancel.Location.Y);
		}
		else
		{
			btnSave.Text = "GIFT CARD";
		}
		txtCardNumber.Select();
	}

	private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			if (txtCardNumber.Text.Contains(";") || txtCardNumber.Text.Contains("="))
			{
				txtCardNumber.Text = txtCardNumber.Text.Split('=')[0].Replace(";", "");
			}
			if (!bool_0)
			{
				btnSave_Click(null, null);
			}
		}
	}

	private void boDeAndfTT_Click(object sender, EventArgs e)
	{
		method_3(2);
	}

	private void method_3(int int_1)
	{
		if (string.IsNullOrEmpty(txtCardNumber.Text))
		{
			new NotificationLabel(this, "Please enter a card number.", NotificationTypes.Warning).Show();
			return;
		}
		CardNumber = txtCardNumber.Text;
		CardType = int_1;
		base.DialogResult = DialogResult.OK;
		Dispose();
		Close();
	}

	private void btnShowKeyboard_CardNumber_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("ENTER CARD NUMBER", 0, 24, txtCardNumber.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtCardNumber.Text = MemoryLoadedObjects.Keyboard.textEntered;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmGiftCardPrompt));
		boDeAndfTT = new Button();
		btnCancel = new Button();
		label3 = new Label();
		label1 = new Label();
		txtCardNumber = new RadTextBoxControl();
		btnShowKeyboard_CardNumber = new Button();
		btnSave = new Button();
		((ISupportInitialize)txtCardNumber).BeginInit();
		SuspendLayout();
		boDeAndfTT.BackColor = Color.FromArgb(50, 119, 155);
		boDeAndfTT.FlatAppearance.BorderSize = 0;
		boDeAndfTT.FlatStyle = FlatStyle.Flat;
		boDeAndfTT.Font = new Font("Microsoft Sans Serif", 11.25f);
		boDeAndfTT.ForeColor = SystemColors.ButtonFace;
		boDeAndfTT.ImeMode = ImeMode.NoControl;
		boDeAndfTT.Location = new Point(163, 85);
		boDeAndfTT.Name = "btnLoyalty";
		boDeAndfTT.Size = new Size(144, 80);
		boDeAndfTT.TabIndex = 249;
		boDeAndfTT.Text = "LOYALTY CARD";
		boDeAndfTT.TextImageRelation = TextImageRelation.ImageBeforeText;
		boDeAndfTT.UseVisualStyleBackColor = false;
		boDeAndfTT.Click += boDeAndfTT_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(308, 85);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(138, 80);
		btnCancel.TabIndex = 248;
		btnCancel.Text = "CLOSE";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += GmAelxlksQ;
		label3.BackColor = Color.FromArgb(156, 89, 184);
		label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(5, 4);
		label3.Name = "label3";
		label3.Size = new Size(441, 44);
		label3.TabIndex = 247;
		label3.Text = "GIFT CARD DETAILS";
		label3.TextAlign = ContentAlignment.MiddleCenter;
		label1.AutoSize = true;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(5, 49);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(120, 35);
		label1.TabIndex = 243;
		label1.Text = "Card Number";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		txtCardNumber.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		txtCardNumber.ForeColor = Color.FromArgb(40, 40, 40);
		txtCardNumber.Location = new Point(126, 49);
		txtCardNumber.Name = "txtCardNumber";
		txtCardNumber.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtCardNumber.Size = new Size(268, 35);
		txtCardNumber.TabIndex = 242;
		txtCardNumber.Click += btnShowKeyboard_CardNumber_Click;
		txtCardNumber.KeyPress += txtCardNumber_KeyPress;
		((RadTextBoxControlElement)txtCardNumber.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtCardNumber.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_CardNumber.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_CardNumber.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_CardNumber.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_CardNumber.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_CardNumber.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_CardNumber.ForeColor = Color.White;
		btnShowKeyboard_CardNumber.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_CardNumber.Image");
		btnShowKeyboard_CardNumber.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_CardNumber.Location = new Point(395, 49);
		btnShowKeyboard_CardNumber.Name = "btnShowKeyboard_CardNumber";
		btnShowKeyboard_CardNumber.Size = new Size(51, 35);
		btnShowKeyboard_CardNumber.TabIndex = 241;
		btnShowKeyboard_CardNumber.UseVisualStyleBackColor = false;
		btnShowKeyboard_CardNumber.Click += btnShowKeyboard_CardNumber_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(5, 85);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(157, 80);
		btnSave.TabIndex = 239;
		btnSave.Text = "SUBMIT";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(451, 170);
		base.Controls.Add(boDeAndfTT);
		base.Controls.Add(btnCancel);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(txtCardNumber);
		base.Controls.Add(btnShowKeyboard_CardNumber);
		base.Controls.Add(btnSave);
		base.Name = "frmGiftCardPrompt";
		base.Opacity = 1.0;
		Text = "frmGiftCardPrompt";
		base.Load += frmGiftCardPrompt_Load;
		((ISupportInitialize)txtCardNumber).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
