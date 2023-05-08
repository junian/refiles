using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;

namespace CorePOS;

public class frmUsefulTips : frmMasterForm
{
	private IContainer icontainer_1;

	private Label label9;

	private Button btnClose;

	private DataGridView UsefulTipGridView;

	private DataGridViewTextBoxColumn usefulTipNumber;

	private DataGridViewTextBoxColumn usefulTipDesc;

	public frmUsefulTips()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new ScrollBarCustom(UsefulTipGridView, 40, UsefulTipGridView.Height);
	}

	private void frmUsefulTips_Load(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		int num = 1;
		foreach (string item in gClass.UsefulTips.Select((UsefulTip a) => a.Description).ToList())
		{
			UsefulTipGridView.Rows.Add(num.ToString(), item);
			num++;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_3(object sender, EventArgs e)
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

	private void InitializeComponent_1()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmUsefulTips));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		btnClose = new Button();
		label9 = new Label();
		UsefulTipGridView = new DataGridView();
		usefulTipNumber = new DataGridViewTextBoxColumn();
		usefulTipDesc = new DataGridViewTextBoxColumn();
		((ISupportInitialize)UsefulTipGridView).BeginInit();
		SuspendLayout();
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = SystemColors.ButtonFace;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		UsefulTipGridView.AllowUserToAddRows = false;
		UsefulTipGridView.AllowUserToDeleteRows = false;
		UsefulTipGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		UsefulTipGridView.BackgroundColor = SystemColors.ButtonHighlight;
		UsefulTipGridView.BorderStyle = BorderStyle.None;
		UsefulTipGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		UsefulTipGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		UsefulTipGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		UsefulTipGridView.Columns.AddRange(usefulTipNumber, usefulTipDesc);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		UsefulTipGridView.DefaultCellStyle = dataGridViewCellStyle2;
		componentResourceManager.ApplyResources(UsefulTipGridView, "UsefulTipGridView");
		UsefulTipGridView.Name = "UsefulTipGridView";
		UsefulTipGridView.ReadOnly = true;
		UsefulTipGridView.RowHeadersVisible = false;
		UsefulTipGridView.RowTemplate.Height = 24;
		dataGridViewCellStyle3.BackColor = Color.White;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.5f);
		usefulTipNumber.DefaultCellStyle = dataGridViewCellStyle3;
		componentResourceManager.ApplyResources(usefulTipNumber, "usefulTipNumber");
		usefulTipNumber.Name = "usefulTipNumber";
		usefulTipNumber.ReadOnly = true;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.5f);
		usefulTipDesc.DefaultCellStyle = dataGridViewCellStyle4;
		componentResourceManager.ApplyResources(usefulTipDesc, "usefulTipDesc");
		usefulTipDesc.Name = "usefulTipDesc";
		usefulTipDesc.ReadOnly = true;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(UsefulTipGridView);
		base.Controls.Add(btnClose);
		base.Controls.Add(label9);
		base.Name = "frmUsefulTips";
		base.Opacity = 1.0;
		base.Load += frmUsefulTips_Load;
		((ISupportInitialize)UsefulTipGridView).EndInit();
		ResumeLayout(performLayout: false);
	}
}
