using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS;

public class frmSelectInventoryBatch : frmMasterForm
{
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	private IContainer icontainer_1;

	private FlowLayoutPanel pnlMain;

	public Label lblTitle;

	private Panel EheOhlNntd;

	private VerticalScrollControl verticalScrollControl1;

	public int BatchId
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public frmSelectInventoryBatch(int ItemId)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = ItemId;
		verticalScrollControl1.ConnectedPanel = pnlMain;
	}

	private void frmSelectInventoryBatch_Load(object sender, EventArgs e)
	{
		List<InventoryBatch> list = new GClass6().InventoryBatches.Where((InventoryBatch a) => a.ItemID == int_0 && a.QTYRemaining > 0m).ToList();
		if (list.Count() > 0)
		{
			Label label = lblTitle;
			label.Text = label.Text + ": " + list.FirstOrDefault().Item.ItemName;
			{
				foreach (InventoryBatch item in list)
				{
					Button button = new Button();
					button.BackColor = ((item.ExpiryDate.Date < DateTime.Now.Date) ? HelperMethods.GetColor(HelperMethods.ButtonColors()["Red"]) : HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]));
					button.FlatStyle = FlatStyle.Flat;
					button.TextAlign = ContentAlignment.MiddleCenter;
					button.FlatAppearance.BorderSize = 0;
					button.ForeColor = Color.White;
					button.Name = item.Id.ToString();
					button.TextAlign = ContentAlignment.MiddleLeft;
					button.Font = new Font(button.Font.FontFamily, 16f, FontStyle.Regular);
					button.Text = "BATCH: " + item.BatchNumber + "\nEXPIRY: " + item.ExpiryDate.ToShortDateString();
					button.Size = new Size(228, 140);
					button.Click += method_3;
					pnlMain.Controls.Add(button);
				}
				return;
			}
		}
		BatchId = 0;
		base.DialogResult = DialogResult.OK;
		Dispose();
		Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		BatchId = Convert.ToInt32(button.Name);
		base.DialogResult = DialogResult.OK;
		Dispose();
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
		pnlMain = new FlowLayoutPanel();
		lblTitle = new Label();
		EheOhlNntd = new Panel();
		verticalScrollControl1 = new VerticalScrollControl();
		EheOhlNntd.SuspendLayout();
		SuspendLayout();
		pnlMain.AutoScroll = true;
		pnlMain.Location = new Point(4, 44);
		pnlMain.Name = "pnlMain";
		pnlMain.Size = new Size(727, 408);
		pnlMain.TabIndex = 0;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(65, 168, 95);
		lblTitle.Font = new Font("Microsoft Sans Serif", 16f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(0, 0);
		lblTitle.Margin = new Padding(0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(758, 40);
		lblTitle.TabIndex = 49;
		lblTitle.Text = "Select Expiry Date";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		EheOhlNntd.BorderStyle = BorderStyle.FixedSingle;
		EheOhlNntd.Controls.Add(verticalScrollControl1);
		EheOhlNntd.Controls.Add(pnlMain);
		EheOhlNntd.Controls.Add(lblTitle);
		EheOhlNntd.Location = new Point(8, 8);
		EheOhlNntd.Name = "panel1";
		EheOhlNntd.Size = new Size(760, 457);
		EheOhlNntd.TabIndex = 50;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(705, 44);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 406);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 406);
		verticalScrollControl1.TabIndex = 213;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(778, 468);
		base.Controls.Add(EheOhlNntd);
		base.Name = "frmSelectInventoryBatch";
		base.Opacity = 1.0;
		Text = "frmSelectInventoryBatch";
		base.Load += frmSelectInventoryBatch_Load;
		EheOhlNntd.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
