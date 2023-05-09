using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS;

public class InventoryBatchReductionHeaderControl : UserControl
{
	private IContainer icontainer_0;

	private Label lblExpiryDate;

	private Label lblReceivedDate;

	private Label lblBatchNumber;

	private Label label1;

	private Label label2;

	public InventoryBatchReductionHeaderControl()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent();
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
		this.lblExpiryDate = new System.Windows.Forms.Label();
		this.lblReceivedDate = new System.Windows.Forms.Label();
		this.lblBatchNumber = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblExpiryDate.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblExpiryDate.ForeColor = System.Drawing.SystemColors.Control;
		this.lblExpiryDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblExpiryDate.Location = new System.Drawing.Point(337, 0);
		this.lblExpiryDate.Name = "lblExpiryDate";
		this.lblExpiryDate.Size = new System.Drawing.Size(165, 30);
		this.lblExpiryDate.TabIndex = 204;
		this.lblExpiryDate.Text = "Expiry Date";
		this.lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblReceivedDate.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.lblReceivedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblReceivedDate.ForeColor = System.Drawing.SystemColors.Control;
		this.lblReceivedDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblReceivedDate.Location = new System.Drawing.Point(171, 0);
		this.lblReceivedDate.Name = "lblReceivedDate";
		this.lblReceivedDate.Size = new System.Drawing.Size(165, 30);
		this.lblReceivedDate.TabIndex = 203;
		this.lblReceivedDate.Text = "Rceived Date";
		this.lblReceivedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblBatchNumber.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.lblBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.lblBatchNumber.ForeColor = System.Drawing.SystemColors.Control;
		this.lblBatchNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblBatchNumber.Location = new System.Drawing.Point(0, 0);
		this.lblBatchNumber.Name = "lblBatchNumber";
		this.lblBatchNumber.Size = new System.Drawing.Size(170, 30);
		this.lblBatchNumber.TabIndex = 202;
		this.lblBatchNumber.Text = "Batch #";
		this.lblBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label1.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.label1.ForeColor = System.Drawing.SystemColors.Control;
		this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label1.Location = new System.Drawing.Point(503, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(71, 30);
		this.label1.TabIndex = 207;
		this.label1.Text = "Qty Rem.";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label2.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
		this.label2.ForeColor = System.Drawing.SystemColors.Control;
		this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label2.Location = new System.Drawing.Point(575, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(164, 30);
		this.label2.TabIndex = 208;
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(35, 39, 56);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.lblExpiryDate);
		base.Controls.Add(this.lblReceivedDate);
		base.Controls.Add(this.lblBatchNumber);
		base.Name = "InventoryBatchReductionHeaderControl";
		base.Size = new System.Drawing.Size(741, 30);
		base.ResumeLayout(false);
	}
}
