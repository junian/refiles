using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class InventoryBatchReductionControl : UserControl
{
	private int int_0;

	private string string_0;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private decimal decimal_0;

	private bool bool_0;

	[CompilerGenerated]
	private decimal decimal_1;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0;

	private Label lblBatchNumber;

	private Label lblReceivedDate;

	private Label lblExpiryDate;

	private Label txtQtyRemaining;

	private RadTextBoxControl txtValue;

	public decimal value
	{
		[CompilerGenerated]
		get
		{
			return decimal_1;
		}
		[CompilerGenerated]
		set
		{
			decimal_1 = value;
		}
	}

	public string batchNumber
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public event EventHandler txtValueChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler eventHandler3 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, eventHandler3, eventHandler2);
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
				EventHandler eventHandler3 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, eventHandler3, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public InventoryBatchReductionControl(int batchID, string batchNo, DateTime ReceivedDate, DateTime ExpiryDate, decimal qtyRemaining, bool isUOMFractional = false)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent();
		int_0 = batchID;
		string_0 = batchNo;
		dateTime_0 = ReceivedDate;
		dateTime_1 = ExpiryDate;
		decimal_0 = qtyRemaining;
		bool_0 = isUOMFractional;
	}

	private void InventoryBatchReductionControl_Load(object sender, EventArgs e)
	{
		value = 0m;
		lblBatchNumber.Text = string_0;
		lblReceivedDate.Text = dateTime_0.ToShortDateString();
		lblExpiryDate.Text = dateTime_1.ToShortDateString();
		txtQtyRemaining.Text = (bool_0 ? decimal_0.ToString() : decimal_0.ToString("N0"));
	}

	public void Save()
	{
		if (!string.IsNullOrEmpty(txtValue.Text))
		{
			decimal num = Convert.ToDecimal(txtValue.Text);
			GClass6 gClass = new GClass6();
			InventoryBatch inventoryBatch = gClass.InventoryBatches.Where((InventoryBatch a) => a.Id == int_0).FirstOrDefault();
			if (inventoryBatch != null)
			{
				inventoryBatch.QTYRemaining -= num;
				batchNumber = inventoryBatch.BatchNumber;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
	}

	private void txtValue_TextChanged(object sender, EventArgs e)
	{
		value = Convert.ToDecimal(txtValue.Text);
		if (eventHandler_0 != null)
		{
			eventHandler_0(sender, e);
		}
	}

	private void txtValue_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Reduction Count", 2, 6, txtValue.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtValue.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		this.lblBatchNumber = new System.Windows.Forms.Label();
		this.lblReceivedDate = new System.Windows.Forms.Label();
		this.lblExpiryDate = new System.Windows.Forms.Label();
		this.txtQtyRemaining = new System.Windows.Forms.Label();
		this.txtValue = new Telerik.WinControls.UI.RadTextBoxControl();
		((System.ComponentModel.ISupportInitialize)this.txtValue).BeginInit();
		base.SuspendLayout();
		this.lblBatchNumber.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.lblBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblBatchNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblBatchNumber.Location = new System.Drawing.Point(1, 0);
		this.lblBatchNumber.Name = "lblBatchNumber";
		this.lblBatchNumber.Size = new System.Drawing.Size(170, 30);
		this.lblBatchNumber.TabIndex = 193;
		this.lblBatchNumber.Text = "Batch #";
		this.lblBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblReceivedDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.lblReceivedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblReceivedDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblReceivedDate.Location = new System.Drawing.Point(172, 0);
		this.lblReceivedDate.Name = "lblReceivedDate";
		this.lblReceivedDate.Size = new System.Drawing.Size(165, 30);
		this.lblReceivedDate.TabIndex = 194;
		this.lblReceivedDate.Text = "Rceived Date";
		this.lblReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblExpiryDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblExpiryDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblExpiryDate.Location = new System.Drawing.Point(338, 0);
		this.lblExpiryDate.Name = "lblExpiryDate";
		this.lblExpiryDate.Size = new System.Drawing.Size(165, 30);
		this.lblExpiryDate.TabIndex = 195;
		this.lblExpiryDate.Text = "Expiry Date";
		this.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.txtQtyRemaining.BackColor = System.Drawing.Color.White;
		this.txtQtyRemaining.Enabled = false;
		this.txtQtyRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.txtQtyRemaining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.txtQtyRemaining.Location = new System.Drawing.Point(504, 0);
		this.txtQtyRemaining.Name = "txtQtyRemaining";
		this.txtQtyRemaining.Size = new System.Drawing.Size(71, 30);
		this.txtQtyRemaining.TabIndex = 198;
		this.txtQtyRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.txtValue.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.txtValue.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.txtValue.Location = new System.Drawing.Point(576, 0);
		this.txtValue.MaxLength = 128;
		this.txtValue.MinimumSize = new System.Drawing.Size(70, 30);
		this.txtValue.Name = "txtValue";
		this.txtValue.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
		this.txtValue.RootElement.MinSize = new System.Drawing.Size(70, 30);
		this.txtValue.RootElement.PositionOffset = new System.Drawing.SizeF(0f, 0f);
		this.txtValue.Size = new System.Drawing.Size(164, 30);
		this.txtValue.TabIndex = 201;
		this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtValue.TextChanged += new System.EventHandler(txtValue_TextChanged);
		this.txtValue.Click += new System.EventHandler(txtValue_Click);
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtValue.GetChildAt(0)).BorderWidth = 0f;
		((Telerik.WinControls.UI.RadTextBoxControlElement)this.txtValue.GetChildAt(0)).Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
		((Telerik.WinControls.UI.TextBoxViewElement)this.txtValue.GetChildAt(0).GetChildAt(0)).PositionOffset = new System.Drawing.SizeF(5f, 5f);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.txtValue);
		base.Controls.Add(this.txtQtyRemaining);
		base.Controls.Add(this.lblExpiryDate);
		base.Controls.Add(this.lblReceivedDate);
		base.Controls.Add(this.lblBatchNumber);
		base.Name = "InventoryBatchReductionControl";
		base.Size = new System.Drawing.Size(740, 30);
		base.Load += new System.EventHandler(InventoryBatchReductionControl_Load);
		((System.ComponentModel.ISupportInitialize)this.txtValue).EndInit();
		base.ResumeLayout(false);
	}
}
