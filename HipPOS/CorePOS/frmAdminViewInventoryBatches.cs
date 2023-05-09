using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;

namespace CorePOS;

public class frmAdminViewInventoryBatches : frmMasterForm
{
	private int int_0;

	private IContainer icontainer_1;

	private Label label9;

	private Label lblItemName;

	private Label label1;

	private ListView lstItems;

	private Label label2;

	private Label lblInvCount;

	internal Button BtnClose;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	public frmAdminViewInventoryBatches(int itemID)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = itemID;
	}

	private void frmAdminViewInventoryBatches_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Item item = gClass.Items.Where((Item a) => a.ItemID == int_0).FirstOrDefault();
		lblItemName.Text = item.ItemName;
		lblInvCount.Text = item.InventoryCount.ToString();
		foreach (InventoryBatch item2 in (from a in gClass.InventoryBatches
			where a.ItemID == int_0
			orderby a.ExpiryDate
			select a).ToList())
		{
			ListViewItem value = new ListViewItem(new string[4]
			{
				item2.BatchNumber,
				item2.ReceivedDate.ToShortDateString(),
				item2.ExpiryDate.ToShortDateString(),
				item2.QTYRemaining.ToString("0.00")
			});
			lstItems.Items.Add(value);
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		Close();
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
		label9 = new Label();
		lblItemName = new Label();
		label1 = new Label();
		lstItems = new ListView();
		label2 = new Label();
		lblInvCount = new Label();
		BtnClose = new Button();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		SuspendLayout();
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(-1, 0);
		label9.MinimumSize = new Size(720, 35);
		label9.Name = "label9";
		label9.Size = new Size(796, 35);
		label9.TabIndex = 113;
		label9.Text = "INVENTORY BATCH";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		lblItemName.BackColor = SystemColors.AppWorkspace;
		lblItemName.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblItemName.ImeMode = ImeMode.NoControl;
		lblItemName.Location = new Point(146, 35);
		lblItemName.Name = "lblItemName";
		lblItemName.Size = new Size(375, 35);
		lblItemName.TabIndex = 198;
		lblItemName.Text = "Item Name";
		lblItemName.TextAlign = ContentAlignment.MiddleLeft;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(0, 35);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(145, 35);
		label1.TabIndex = 197;
		label1.Text = "Item Name";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		lstItems.Columns.AddRange(new ColumnHeader[4] { columnHeader_0, columnHeader_1, columnHeader_2, columnHeader_3 });
		lstItems.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lstItems.GridLines = true;
		lstItems.Location = new Point(0, 70);
		lstItems.Name = "lstItems";
		lstItems.Size = new Size(795, 417);
		lstItems.TabIndex = 199;
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(522, 35);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(145, 35);
		label2.TabIndex = 200;
		label2.Text = "Inv. Count";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		lblInvCount.BackColor = SystemColors.AppWorkspace;
		lblInvCount.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblInvCount.ImeMode = ImeMode.NoControl;
		lblInvCount.Location = new Point(668, 35);
		lblInvCount.Name = "lblInvCount";
		lblInvCount.Size = new Size(127, 35);
		lblInvCount.TabIndex = 201;
		lblInvCount.Text = "0";
		lblInvCount.TextAlign = ContentAlignment.MiddleLeft;
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		BtnClose.FlatStyle = FlatStyle.Flat;
		BtnClose.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
		BtnClose.ForeColor = Color.White;
		BtnClose.ImageAlign = ContentAlignment.TopCenter;
		BtnClose.ImeMode = ImeMode.NoControl;
		BtnClose.Location = new Point(651, 490);
		BtnClose.Name = "BtnClose";
		BtnClose.Padding = new Padding(0, 4, 0, 4);
		BtnClose.Size = new Size(144, 75);
		BtnClose.TabIndex = 202;
		BtnClose.Text = "CLOSE";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		columnHeader_0.Text = "Batch #";
		columnHeader_0.Width = 212;
		columnHeader_1.Text = "Received Date";
		columnHeader_1.Width = 211;
		columnHeader_2.Text = "Expiry Date";
		columnHeader_2.Width = 255;
		columnHeader_3.Text = "Qty Remaining";
		columnHeader_3.Width = 109;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(797, 566);
		base.Controls.Add(BtnClose);
		base.Controls.Add(lblInvCount);
		base.Controls.Add(label2);
		base.Controls.Add(lstItems);
		base.Controls.Add(lblItemName);
		base.Controls.Add(label1);
		base.Controls.Add(label9);
		base.Name = "frmAdminViewInventoryBatches";
		base.Opacity = 1.0;
		Text = "frmAdminViewInventoryBatches";
		base.Load += frmAdminViewInventoryBatches_Load;
		ResumeLayout(performLayout: false);
	}
}
