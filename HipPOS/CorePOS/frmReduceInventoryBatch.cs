using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS;

public class frmReduceInventoryBatch : frmMasterForm
{
	private int int_0;

	private decimal decimal_0;

	private bool bool_0;

	[CompilerGenerated]
	private string string_0;

	private IContainer icontainer_1;

	private Label label10;

	private Label lblReductionCount;

	private Label label2;

	private Label TmawgtHjve;

	private Label wxlwtxWavW;

	private FlowLayoutPanel pnlBatch;

	private Label lblReductionCountRemaining;

	private Label label3;

	internal Button BtnClose;

	internal Button btnSave;

	private VerticalScrollControl verticalScrollControl1;

	public string BatchNumbers
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

	public frmReduceInventoryBatch(int ItemID, decimal ReductionCount)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		int_0 = ItemID;
		decimal_0 = ReductionCount;
		verticalScrollControl1.ConnectedPanel = pnlBatch;
	}

	private void frmReduceInventoryBatch_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Item item = gClass.Items.Where((Item a) => a.ItemID == int_0).FirstOrDefault();
		if (item != null)
		{
			bool_0 = item.UOM.isFractional;
			TmawgtHjve.Text = item.ItemName;
			lblReductionCount.Text = (bool_0 ? decimal_0.ToString() : decimal_0.ToString("N0"));
			lblReductionCountRemaining.Text = (bool_0 ? decimal_0.ToString() : decimal_0.ToString("N0"));
		}
		InventoryBatchReductionHeaderControl inventoryBatchReductionHeaderControl = new InventoryBatchReductionHeaderControl();
		inventoryBatchReductionHeaderControl.Name = "header";
		pnlBatch.Controls.Add(inventoryBatchReductionHeaderControl);
		foreach (InventoryBatch item2 in gClass.InventoryBatches.Where((InventoryBatch a) => a.ItemID == int_0 && a.QTYRemaining > 0m).ToList())
		{
			InventoryBatchReductionControl inventoryBatchReductionControl = new InventoryBatchReductionControl(item2.Id, item2.BatchNumber, item2.ReceivedDate, item2.ExpiryDate, item2.QTYRemaining);
			pnlBatch.Controls.Add(inventoryBatchReductionControl);
			inventoryBatchReductionControl.txtValueChanged += InventoryBatchReductionControl_ValueChanged;
		}
		btnSave.Enabled = false;
	}

	protected void InventoryBatchReductionControl_ValueChanged(object sender, EventArgs e)
	{
		Control control = (Control)sender;
		decimal num = default(decimal);
		foreach (Control control2 in pnlBatch.Controls)
		{
			if (control2.Name != "header")
			{
				InventoryBatchReductionControl inventoryBatchReductionControl = (InventoryBatchReductionControl)control2;
				num += inventoryBatchReductionControl.value;
			}
		}
		if (decimal_0 - num < 0m)
		{
			new NotificationLabel(this, "Value is over the reduction count, please use a lower value.", NotificationTypes.Warning).Show();
			control.Text = "0";
			return;
		}
		decimal num2 = decimal_0 - num;
		lblReductionCountRemaining.Text = (bool_0 ? num2.ToString() : num2.ToString("N0"));
		if (num2 <= 0m)
		{
			btnSave.Enabled = true;
		}
		else
		{
			btnSave.Enabled = false;
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		if (new frmMessageBox("Are you sure you want to Close without saving?", "Warning Close", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
		else
		{
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
		foreach (Control control in pnlBatch.Controls)
		{
			if (control.Name != "header")
			{
				InventoryBatchReductionControl inventoryBatchReductionControl = (InventoryBatchReductionControl)control;
				list.Add(inventoryBatchReductionControl.batchNumber);
				inventoryBatchReductionControl.Save();
			}
		}
		BatchNumbers = string.Join(",", list);
		new frmMessageBox("Inventory batch successfully saved.").ShowDialog();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnSave_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (frmMasterForm.lockedControls != null && frmMasterForm.lockedControls.Select((LockedControl x) => x.Name).Contains(button.Name) && button.Enabled)
		{
			button.Enabled = false;
		}
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmReduceInventoryBatch));
		BtnClose = new Button();
		lblReductionCountRemaining = new Label();
		label3 = new Label();
		pnlBatch = new FlowLayoutPanel();
		lblReductionCount = new Label();
		label2 = new Label();
		TmawgtHjve = new Label();
		wxlwtxWavW = new Label();
		label10 = new Label();
		btnSave = new Button();
		verticalScrollControl1 = new VerticalScrollControl();
		SuspendLayout();
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		BtnClose.FlatStyle = FlatStyle.Flat;
		BtnClose.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
		BtnClose.ForeColor = Color.White;
		BtnClose.Image = (Image)componentResourceManager.GetObject("BtnClose.Image");
		BtnClose.ImageAlign = ContentAlignment.MiddleLeft;
		BtnClose.ImeMode = ImeMode.NoControl;
		BtnClose.Location = new Point(642, 482);
		BtnClose.Name = "BtnClose";
		BtnClose.Padding = new Padding(0, 4, 0, 4);
		BtnClose.Size = new Size(154, 75);
		BtnClose.TabIndex = 210;
		BtnClose.Text = "CLOSE";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		lblReductionCountRemaining.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblReductionCountRemaining.BackColor = Color.FromArgb(156, 89, 184);
		lblReductionCountRemaining.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		lblReductionCountRemaining.ForeColor = Color.White;
		lblReductionCountRemaining.ImageAlign = ContentAlignment.TopLeft;
		lblReductionCountRemaining.ImeMode = ImeMode.NoControl;
		lblReductionCountRemaining.Location = new Point(97, 483);
		lblReductionCountRemaining.Name = "lblReductionCountRemaining";
		lblReductionCountRemaining.Size = new Size(161, 74);
		lblReductionCountRemaining.TabIndex = 208;
		lblReductionCountRemaining.Text = "0";
		lblReductionCountRemaining.TextAlign = ContentAlignment.MiddleCenter;
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.BackColor = Color.Gray;
		label3.Font = new Font("Microsoft Sans Serif", 10f);
		label3.ForeColor = Color.White;
		label3.ImageAlign = ContentAlignment.TopLeft;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(2, 483);
		label3.Name = "label3";
		label3.Padding = new Padding(5, 5, 0, 0);
		label3.Size = new Size(94, 74);
		label3.TabIndex = 207;
		label3.Text = "REDUCTION COUNT REMAINING";
		pnlBatch.AutoScroll = true;
		pnlBatch.BackColor = Color.FromArgb(35, 39, 56);
		pnlBatch.Location = new Point(0, 76);
		pnlBatch.Name = "pnlBatch";
		pnlBatch.Size = new Size(768, 405);
		pnlBatch.TabIndex = 206;
		lblReductionCount.BackColor = SystemColors.AppWorkspace;
		lblReductionCount.Font = new Font("Microsoft Sans Serif", 14.25f);
		lblReductionCount.ImeMode = ImeMode.NoControl;
		lblReductionCount.Location = new Point(669, 38);
		lblReductionCount.Name = "lblReductionCount";
		lblReductionCount.Size = new Size(127, 35);
		lblReductionCount.TabIndex = 205;
		lblReductionCount.Text = "0";
		lblReductionCount.TextAlign = ContentAlignment.MiddleLeft;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(523, 38);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(145, 35);
		label2.TabIndex = 204;
		label2.Text = "Reduction Count";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		TmawgtHjve.BackColor = SystemColors.AppWorkspace;
		TmawgtHjve.Font = new Font("Microsoft Sans Serif", 14.25f);
		TmawgtHjve.ImeMode = ImeMode.NoControl;
		TmawgtHjve.Location = new Point(147, 38);
		TmawgtHjve.Name = "lblItemName";
		TmawgtHjve.Size = new Size(375, 35);
		TmawgtHjve.TabIndex = 203;
		TmawgtHjve.Text = "Item Name";
		TmawgtHjve.TextAlign = ContentAlignment.MiddleLeft;
		wxlwtxWavW.BackColor = Color.FromArgb(132, 146, 146);
		wxlwtxWavW.Font = new Font("Microsoft Sans Serif", 12f);
		wxlwtxWavW.ForeColor = Color.White;
		wxlwtxWavW.ImeMode = ImeMode.NoControl;
		wxlwtxWavW.Location = new Point(1, 38);
		wxlwtxWavW.Margin = new Padding(4, 0, 4, 0);
		wxlwtxWavW.MinimumSize = new Size(120, 35);
		wxlwtxWavW.Name = "label1";
		wxlwtxWavW.Size = new Size(145, 35);
		wxlwtxWavW.TabIndex = 202;
		wxlwtxWavW.Text = "Item Name";
		wxlwtxWavW.TextAlign = ContentAlignment.MiddleLeft;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label10.ForeColor = Color.White;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(1, 3);
		label10.Name = "label10";
		label10.Size = new Size(795, 35);
		label10.TabIndex = 118;
		label10.Text = "UPDATE INVENTORY BATCH";
		label10.TextAlign = ContentAlignment.MiddleCenter;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 9f);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImageAlign = ContentAlignment.MiddleLeft;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(479, 481);
		btnSave.Margin = new Padding(0);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(161, 75);
		btnSave.TabIndex = 211;
		btnSave.Text = "SAVE";
		btnSave.TextAlign = ContentAlignment.MiddleLeft;
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.EnabledChanged += btnSave_EnabledChanged;
		btnSave.Click += btnSave_Click;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(746, 75);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 406);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 406);
		verticalScrollControl1.TabIndex = 212;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(799, 561);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnSave);
		base.Controls.Add(BtnClose);
		base.Controls.Add(lblReductionCountRemaining);
		base.Controls.Add(label3);
		base.Controls.Add(pnlBatch);
		base.Controls.Add(lblReductionCount);
		base.Controls.Add(label2);
		base.Controls.Add(TmawgtHjve);
		base.Controls.Add(wxlwtxWavW);
		base.Controls.Add(label10);
		base.Name = "frmReduceInventoryBatch";
		base.Opacity = 1.0;
		Text = "frmReduceInventoryBatch";
		base.Load += frmReduceInventoryBatch_Load;
		ResumeLayout(performLayout: false);
	}
}
