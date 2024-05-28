using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAddInventoryBatches : frmMasterForm
{
	private int int_0;

	private decimal decimal_0;

	[CompilerGenerated]
	private string string_0;

	private IContainer icontainer_1;

	private Label label1;

	private Label label10;

	private RadTextBoxControl txtBatchNumber;

	private Label label2;

	private DateTimePicker pickerReceivedDate;

	private Label label3;

	private Label label4;

	private DateTimePicker pickerExpiryDate;

	private Button btnSave;

	private Button btnCancel;

	private Label lblItemName;

	internal Button btnShowKeyboard_BatchNumber;

	private Label label5;

	private Label lblBatchCount;

	internal Button btnShowDateSel_ReceivedDate;

	internal Button btnShowDateSel_ExpiryDate;

	public string BatchNumber
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

	public frmAddInventoryBatches(int ItemId, decimal InventoryChange)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = ItemId;
		decimal_0 = InventoryChange;
	}

	private void frmAddInventoryBatches_Load(object sender, EventArgs e)
	{
		Item item = new GClass6().Items.Where((Item a) => a.ItemID == int_0).FirstOrDefault();
		lblItemName.Text = item.ItemName;
		lblBatchCount.Text = decimal_0.ToString();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtBatchNumber.Text))
		{
			new NotificationLabel(this, "Please add a batch number.", NotificationTypes.Warning).Show();
			return;
		}
		if (pickerExpiryDate.Value < DateTime.Now)
		{
			new NotificationLabel(this, "Expiry Date already passed.", NotificationTypes.Warning).Show();
			return;
		}
		if (pickerExpiryDate.Value < pickerReceivedDate.Value)
		{
			new NotificationLabel(this, "Received date cannot be greater than Expiry Date.", NotificationTypes.Warning).Show();
			return;
		}
		GClass6 gClass = new GClass6();
		if (gClass.InventoryBatches.Where((InventoryBatch a) => a.BatchNumber.ToUpper() == txtBatchNumber.Text.ToUpper() && a.ItemID == int_0).FirstOrDefault() != null)
		{
			new NotificationLabel(this, "Batch Number already exist.", NotificationTypes.Warning).Show();
			return;
		}
		InventoryBatch inventoryBatch = new InventoryBatch
		{
			ItemID = int_0,
			BatchNumber = txtBatchNumber.Text,
			Decimal_0 = decimal_0,
			QTYRemaining = decimal_0,
			ReceivedDate = pickerReceivedDate.Value,
			ExpiryDate = pickerExpiryDate.Value
		};
		gClass.InventoryBatches.InsertOnSubmit(inventoryBatch);
		Helper.SubmitChangesWithCatch(gClass);
		BatchNumber = inventoryBatch.BatchNumber;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnShowKeyboard_BatchNumber_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Inventory Batch", 0, 256, txtBatchNumber.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtBatchNumber.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private DateTime method_3(DateTime dateTime_0)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_0);
		if (frmDateSelector2.ShowDialog() == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void btnShowDateSel_ReceivedDate_Click(object sender, EventArgs e)
	{
		pickerReceivedDate.Value = method_3(pickerReceivedDate.Value);
	}

	private void btnShowDateSel_ExpiryDate_Click(object sender, EventArgs e)
	{
		pickerExpiryDate.Value = method_3(pickerExpiryDate.Value);
	}

	private void pickerReceivedDate_MouseDown(object sender, MouseEventArgs e)
	{
		pickerReceivedDate.Value = method_3(pickerReceivedDate.Value);
	}

	private void pickerExpiryDate_MouseDown(object sender, MouseEventArgs e)
	{
		pickerExpiryDate.Value = method_3(pickerExpiryDate.Value);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddInventoryBatches));
		label1 = new Label();
		label10 = new Label();
		txtBatchNumber = new RadTextBoxControl();
		label2 = new Label();
		pickerReceivedDate = new DateTimePicker();
		label3 = new Label();
		label4 = new Label();
		pickerExpiryDate = new DateTimePicker();
		btnSave = new Button();
		btnCancel = new Button();
		lblItemName = new Label();
		btnShowKeyboard_BatchNumber = new Button();
		label5 = new Label();
		lblBatchCount = new Label();
		btnShowDateSel_ReceivedDate = new Button();
		btnShowDateSel_ExpiryDate = new Button();
		((ISupportInitialize)txtBatchNumber).BeginInit();
		SuspendLayout();
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(1, 35);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(145, 35);
		label1.TabIndex = 113;
		label1.Text = "Item Name";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label10.ForeColor = Color.White;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(2, -1);
		label10.Name = "label10";
		label10.Size = new Size(493, 35);
		label10.TabIndex = 117;
		label10.Text = "ADD INVENTORY BATCH";
		label10.TextAlign = ContentAlignment.MiddleCenter;
		txtBatchNumber.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtBatchNumber.Location = new Point(147, 107);
		txtBatchNumber.MaxLength = 255;
		txtBatchNumber.Name = "txtBatchNumber";
		txtBatchNumber.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtBatchNumber.Size = new Size(296, 35);
		txtBatchNumber.TabIndex = 118;
		txtBatchNumber.Click += btnShowKeyboard_BatchNumber_Click;
		((RadTextBoxControlElement)txtBatchNumber.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtBatchNumber.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(1, 107);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(145, 35);
		label2.TabIndex = 119;
		label2.Text = "Batch Number";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		pickerReceivedDate.CalendarFont = new Font("Microsoft Sans Serif", 25f);
		pickerReceivedDate.Font = new Font("Microsoft Sans Serif", 20f);
		pickerReceivedDate.Format = DateTimePickerFormat.Short;
		pickerReceivedDate.Location = new Point(146, 142);
		pickerReceivedDate.Name = "pickerReceivedDate";
		pickerReceivedDate.Size = new Size(298, 38);
		pickerReceivedDate.TabIndex = 121;
		pickerReceivedDate.MouseDown += pickerReceivedDate_MouseDown;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(1, 143);
		label3.Margin = new Padding(4, 0, 4, 0);
		label3.MinimumSize = new Size(120, 35);
		label3.Name = "label3";
		label3.Size = new Size(145, 36);
		label3.TabIndex = 122;
		label3.Text = "Received Date";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = Color.White;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(1, 180);
		label4.Margin = new Padding(4, 0, 4, 0);
		label4.MinimumSize = new Size(120, 35);
		label4.Name = "label4";
		label4.Size = new Size(145, 37);
		label4.TabIndex = 124;
		label4.Text = "Expiry Date";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		pickerExpiryDate.CalendarFont = new Font("Microsoft Sans Serif", 25f);
		pickerExpiryDate.Font = new Font("Microsoft Sans Serif", 20f);
		pickerExpiryDate.Format = DateTimePickerFormat.Short;
		pickerExpiryDate.Location = new Point(146, 179);
		pickerExpiryDate.Name = "pickerExpiryDate";
		pickerExpiryDate.Size = new Size(298, 38);
		pickerExpiryDate.TabIndex = 123;
		pickerExpiryDate.MouseDown += pickerExpiryDate_MouseDown;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(1, 218);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(246, 79);
		btnSave.TabIndex = 125;
		btnSave.Text = "SAVE";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(248, 218);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(245, 79);
		btnCancel.TabIndex = 126;
		btnCancel.Text = "CANCEL";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		lblItemName.BackColor = SystemColors.AppWorkspace;
		lblItemName.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblItemName.ImeMode = ImeMode.NoControl;
		lblItemName.Location = new Point(147, 35);
		lblItemName.Name = "lblItemName";
		lblItemName.Size = new Size(348, 35);
		lblItemName.TabIndex = 196;
		lblItemName.Text = "Item Name";
		lblItemName.TextAlign = ContentAlignment.MiddleLeft;
		btnShowKeyboard_BatchNumber.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_BatchNumber.DialogResult = DialogResult.OK;
		btnShowKeyboard_BatchNumber.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_BatchNumber.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_BatchNumber.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_BatchNumber.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_BatchNumber.ForeColor = Color.White;
		btnShowKeyboard_BatchNumber.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_BatchNumber.Image");
		btnShowKeyboard_BatchNumber.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_BatchNumber.Location = new Point(444, 107);
		btnShowKeyboard_BatchNumber.MinimumSize = new Size(52, 35);
		btnShowKeyboard_BatchNumber.Name = "btnShowKeyboard_BatchNumber";
		btnShowKeyboard_BatchNumber.Size = new Size(52, 35);
		btnShowKeyboard_BatchNumber.TabIndex = 197;
		btnShowKeyboard_BatchNumber.UseVisualStyleBackColor = false;
		btnShowKeyboard_BatchNumber.Click += btnShowKeyboard_BatchNumber_Click;
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = Color.White;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(1, 71);
		label5.Margin = new Padding(4, 0, 4, 0);
		label5.MinimumSize = new Size(120, 35);
		label5.Name = "label5";
		label5.Size = new Size(145, 35);
		label5.TabIndex = 198;
		label5.Text = "Batch Count";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		lblBatchCount.BackColor = SystemColors.AppWorkspace;
		lblBatchCount.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblBatchCount.ImeMode = ImeMode.NoControl;
		lblBatchCount.Location = new Point(147, 71);
		lblBatchCount.Name = "lblBatchCount";
		lblBatchCount.Size = new Size(348, 35);
		lblBatchCount.TabIndex = 199;
		lblBatchCount.Text = "0";
		lblBatchCount.TextAlign = ContentAlignment.MiddleLeft;
		btnShowDateSel_ReceivedDate.BackColor = Color.FromArgb(77, 174, 225);
		btnShowDateSel_ReceivedDate.DialogResult = DialogResult.OK;
		btnShowDateSel_ReceivedDate.FlatAppearance.BorderColor = Color.Black;
		btnShowDateSel_ReceivedDate.FlatAppearance.BorderSize = 0;
		btnShowDateSel_ReceivedDate.FlatStyle = FlatStyle.Flat;
		btnShowDateSel_ReceivedDate.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowDateSel_ReceivedDate.ForeColor = Color.White;
		btnShowDateSel_ReceivedDate.Image = (Image)componentResourceManager.GetObject("btnShowDateSel_ReceivedDate.Image");
		btnShowDateSel_ReceivedDate.ImeMode = ImeMode.NoControl;
		btnShowDateSel_ReceivedDate.Location = new Point(444, 143);
		btnShowDateSel_ReceivedDate.MinimumSize = new Size(52, 35);
		btnShowDateSel_ReceivedDate.Name = "btnShowDateSel_ReceivedDate";
		btnShowDateSel_ReceivedDate.Size = new Size(52, 35);
		btnShowDateSel_ReceivedDate.TabIndex = 200;
		btnShowDateSel_ReceivedDate.UseVisualStyleBackColor = false;
		btnShowDateSel_ReceivedDate.Click += btnShowDateSel_ReceivedDate_Click;
		btnShowDateSel_ExpiryDate.BackColor = Color.FromArgb(77, 174, 225);
		btnShowDateSel_ExpiryDate.DialogResult = DialogResult.OK;
		btnShowDateSel_ExpiryDate.FlatAppearance.BorderColor = Color.Black;
		btnShowDateSel_ExpiryDate.FlatAppearance.BorderSize = 0;
		btnShowDateSel_ExpiryDate.FlatStyle = FlatStyle.Flat;
		btnShowDateSel_ExpiryDate.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowDateSel_ExpiryDate.ForeColor = Color.White;
		btnShowDateSel_ExpiryDate.Image = (Image)componentResourceManager.GetObject("btnShowDateSel_ExpiryDate.Image");
		btnShowDateSel_ExpiryDate.ImeMode = ImeMode.NoControl;
		btnShowDateSel_ExpiryDate.Location = new Point(444, 179);
		btnShowDateSel_ExpiryDate.MinimumSize = new Size(52, 35);
		btnShowDateSel_ExpiryDate.Name = "btnShowDateSel_ExpiryDate";
		btnShowDateSel_ExpiryDate.Size = new Size(52, 37);
		btnShowDateSel_ExpiryDate.TabIndex = 201;
		btnShowDateSel_ExpiryDate.UseVisualStyleBackColor = false;
		btnShowDateSel_ExpiryDate.Click += btnShowDateSel_ExpiryDate_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(495, 301);
		base.Controls.Add(btnShowDateSel_ExpiryDate);
		base.Controls.Add(btnShowDateSel_ReceivedDate);
		base.Controls.Add(lblBatchCount);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowKeyboard_BatchNumber);
		base.Controls.Add(lblItemName);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label4);
		base.Controls.Add(pickerExpiryDate);
		base.Controls.Add(label3);
		base.Controls.Add(pickerReceivedDate);
		base.Controls.Add(txtBatchNumber);
		base.Controls.Add(label2);
		base.Controls.Add(label10);
		base.Controls.Add(label1);
		base.Name = "frmAddInventoryBatches";
		base.Opacity = 1.0;
		Text = "frmAddInventoryBatchcs";
		base.Load += frmAddInventoryBatches_Load;
		((ISupportInitialize)txtBatchNumber).EndInit();
		ResumeLayout(performLayout: false);
	}
}
