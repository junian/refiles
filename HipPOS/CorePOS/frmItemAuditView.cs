using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmItemAuditView : frmMasterForm
{
	private int int_0;

	private IContainer icontainer_1;

	private DataGridView AuditGridView;

	internal Button BtnClose;

	private Label label10;

	private DataGridViewTextBoxColumn auditDate;

	private DataGridViewTextBoxColumn AuditChangelog;

	public frmItemAuditView(int _itemID)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = _itemID;
		new ScrollBarCustom(AuditGridView, 40, AuditGridView.Height);
	}

	private void frmItemAuditView_Load(object sender, EventArgs e)
	{
		if (int_0 <= 0)
		{
			return;
		}
		List<ItemAuditLog> list = (from a in new GClass6().ItemAuditLogs
			where a.ItemID == int_0
			select a into o
			orderby o.DateCreated descending
			select o).ToList();
		foreach (ItemAuditLog item in list)
		{
			AuditGridView.Rows.Add(item.DateCreated.ToString(), Resources.Changes + item.Changelog);
		}
		if (list.Count < 20)
		{
			base.Controls.Find("customVScrollBar1", searchAllChildren: true).FirstOrDefault()?.Dispose();
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
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmItemAuditView));
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		AuditGridView = new DataGridView();
		auditDate = new DataGridViewTextBoxColumn();
		AuditChangelog = new DataGridViewTextBoxColumn();
		BtnClose = new Button();
		label10 = new Label();
		((ISupportInitialize)AuditGridView).BeginInit();
		SuspendLayout();
		AuditGridView.AllowUserToAddRows = false;
		AuditGridView.AllowUserToDeleteRows = false;
		AuditGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		AuditGridView.BackgroundColor = SystemColors.ButtonHighlight;
		AuditGridView.BorderStyle = BorderStyle.None;
		AuditGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		AuditGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		AuditGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		AuditGridView.Columns.AddRange(auditDate, AuditChangelog);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		AuditGridView.DefaultCellStyle = dataGridViewCellStyle2;
		componentResourceManager.ApplyResources(AuditGridView, "AuditGridView");
		AuditGridView.Name = "AuditGridView";
		AuditGridView.ReadOnly = true;
		AuditGridView.RowHeadersVisible = false;
		AuditGridView.RowTemplate.Height = 24;
		dataGridViewCellStyle3.BackColor = Color.White;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.5f);
		auditDate.DefaultCellStyle = dataGridViewCellStyle3;
		componentResourceManager.ApplyResources(auditDate, "auditDate");
		auditDate.Name = "auditDate";
		auditDate.ReadOnly = true;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.5f);
		AuditChangelog.DefaultCellStyle = dataGridViewCellStyle4;
		componentResourceManager.ApplyResources(AuditChangelog, "AuditChangelog");
		AuditChangelog.Name = "AuditChangelog";
		AuditChangelog.ReadOnly = true;
		BtnClose.BackColor = Color.FromArgb(235, 107, 86);
		BtnClose.FlatAppearance.BorderColor = Color.Sienna;
		BtnClose.FlatAppearance.BorderSize = 0;
		BtnClose.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(BtnClose, "BtnClose");
		BtnClose.ForeColor = Color.White;
		BtnClose.Name = "BtnClose";
		BtnClose.UseVisualStyleBackColor = false;
		BtnClose.Click += BtnClose_Click;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(label10);
		base.Controls.Add(BtnClose);
		base.Controls.Add(AuditGridView);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmItemAuditView";
		base.Opacity = 1.0;
		base.Load += frmItemAuditView_Load;
		((ISupportInitialize)AuditGridView).EndInit();
		ResumeLayout(performLayout: false);
	}
}
