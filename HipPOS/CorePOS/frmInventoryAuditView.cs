using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmInventoryAuditView : frmMasterForm
{
	private int int_0;

	private string string_0;

	private string string_1;

	private IContainer icontainer_1;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private ColumnHeader columnHeader_5;

	internal ListView lstAudit;

	private Label label9;

	internal Button btnClose;

	private Label label1;

	private DateTimePicker dateFrom;

	private DateTimePicker xaLisZuyHQ;

	private Label bbYilEgbMA;

	private Label label3;

	private ColumnHeader columnHeader_6;

	public frmInventoryAuditView(int _itemID, string _itemName, string _inventoryType = "product")
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		int_0 = _itemID;
		string_0 = _inventoryType;
		string_1 = _itemName;
		DateTime now = DateTime.Now;
		dateFrom.Value = new DateTime(now.Year, now.Month, 1);
		xaLisZuyHQ.Value = dateFrom.Value.AddMonths(1).AddDays(-1.0);
	}

	private void frmInventoryAuditView_Load(object sender, EventArgs e)
	{
		label9.Text = "INVENTORY AUDIT LOG : " + string_1;
		filterAudits();
		lstAudit.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstAudit, 1.0);
		lstAudit.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstAudit, 1.0);
		lstAudit.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstAudit, 1.0);
		lstAudit.Columns[3].Width = ControlHelpers.ControlWidthFixer(lstAudit, 1.0);
		lstAudit.Columns[4].Width = ControlHelpers.ControlWidthFixer(lstAudit, 2.0);
		lstAudit.Columns[5].Width = ControlHelpers.ControlWidthFixer(lstAudit, 2.0);
		lstAudit.Columns[6].Width = ControlHelpers.ControlWidthFixer(lstAudit, 4.0);
	}

	public void filterAudits()
	{
		try
		{
			if (int_0 <= 0)
			{
				return;
			}
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			CS_0024_003C_003E8__locals0._003C_003E4__this = this;
			CS_0024_003C_003E8__locals0.dFrom = dateFrom.Value.Date;
			CS_0024_003C_003E8__locals0.dTo = xaLisZuyHQ.Value.Date.AddHours(24.0);
			GClass6 gClass = new GClass6();
			List<InventoryAudit> list = (from a in gClass.InventoryAudits
				where a.ItemID == int_0 && a.InventoryType == string_0 && a.DateCreated >= CS_0024_003C_003E8__locals0.dFrom && a.DateCreated <= CS_0024_003C_003E8__locals0.dTo
				select a into o
				orderby o.DateCreated descending
				select o).ToList();
			lstAudit.Items.Clear();
			using List<InventoryAudit>.Enumerator enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass5_1();
				CS_0024_003C_003E8__locals1.audit = enumerator.Current;
				ListViewItem value = new ListViewItem(new string[7]
				{
					CS_0024_003C_003E8__locals1.audit.DateCreated.ToShortDateString(),
					CS_0024_003C_003E8__locals1.audit.QtyStart.ToString("0.0000"),
					CS_0024_003C_003E8__locals1.audit.QtyChange.ToString("0.0000"),
					CS_0024_003C_003E8__locals1.audit.QtyNew.ToString("0.0000"),
					CS_0024_003C_003E8__locals1.audit.Owner,
					CS_0024_003C_003E8__locals1.audit.SupplierId.HasValue ? gClass.Suppliers.Where((Supplier a) => (int?)a.Id == CS_0024_003C_003E8__locals1.audit.SupplierId).FirstOrDefault().Name : "NONE",
					CS_0024_003C_003E8__locals1.audit.Comment
				});
				lstAudit.Items.Add(value);
			}
		}
		catch (Exception)
		{
			new frmMessageBox(Resources.Something_went_wrong, Resources._Error).ShowDialog(this);
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void dateFrom_ValueChanged(object sender, EventArgs e)
	{
		filterAudits();
	}

	private void xaLisZuyHQ_ValueChanged(object sender, EventArgs e)
	{
		filterAudits();
	}

	private DateTime method_3(DateTime dateTime_0)
	{
		frmDateSelector frmDateSelector2 = new frmDateSelector(dateTime_0);
		if (frmDateSelector2.ShowDialog(this) == DialogResult.OK)
		{
			base.DialogResult = DialogResult.None;
			return frmDateSelector2.returnDate;
		}
		base.DialogResult = DialogResult.None;
		return dateTime_0;
	}

	private void xaLisZuyHQ_MouseDown(object sender, MouseEventArgs e)
	{
		DateTimePicker dateTimePicker = (DateTimePicker)sender;
		dateTimePicker.Value = method_3(dateTimePicker.Value);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmInventoryAuditView));
		lstAudit = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		columnHeader_6 = new ColumnHeader();
		columnHeader_5 = new ColumnHeader();
		label9 = new Label();
		btnClose = new Button();
		label1 = new Label();
		dateFrom = new DateTimePicker();
		xaLisZuyHQ = new DateTimePicker();
		bbYilEgbMA = new Label();
		label3 = new Label();
		SuspendLayout();
		componentResourceManager.ApplyResources(lstAudit, "lstAudit");
		lstAudit.BorderStyle = BorderStyle.None;
		lstAudit.Columns.AddRange(new ColumnHeader[7] { columnHeader_0, columnHeader_1, columnHeader_2, columnHeader_3, columnHeader_4, columnHeader_6, columnHeader_5 });
		lstAudit.ForeColor = Color.FromArgb(40, 40, 40);
		lstAudit.FullRowSelect = true;
		lstAudit.GridLines = true;
		lstAudit.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lstAudit.HideSelection = false;
		lstAudit.MultiSelect = false;
		lstAudit.Name = "lstAudit";
		lstAudit.TileSize = new Size(50, 200);
		lstAudit.UseCompatibleStateImageBehavior = false;
		lstAudit.View = View.Details;
		componentResourceManager.ApplyResources(columnHeader_0, "Date");
		componentResourceManager.ApplyResources(columnHeader_1, "StartQTY");
		componentResourceManager.ApplyResources(columnHeader_2, "QtyChanged");
		componentResourceManager.ApplyResources(columnHeader_3, "NewQTY");
		componentResourceManager.ApplyResources(columnHeader_4, "OrderNumber");
		componentResourceManager.ApplyResources(columnHeader_6, "Supplier");
		componentResourceManager.ApplyResources(columnHeader_5, "Comments");
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		label1.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		dateFrom.CalendarForeColor = Color.FromArgb(40, 40, 40);
		dateFrom.CalendarMonthBackground = Color.White;
		componentResourceManager.ApplyResources(dateFrom, "dateFrom");
		dateFrom.Format = DateTimePickerFormat.Short;
		dateFrom.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateFrom.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		dateFrom.Name = "dateFrom";
		dateFrom.ValueChanged += dateFrom_ValueChanged;
		dateFrom.MouseDown += xaLisZuyHQ_MouseDown;
		xaLisZuyHQ.CalendarForeColor = Color.FromArgb(40, 40, 40);
		xaLisZuyHQ.CalendarMonthBackground = Color.White;
		componentResourceManager.ApplyResources(xaLisZuyHQ, "dateTo");
		xaLisZuyHQ.Format = DateTimePickerFormat.Short;
		xaLisZuyHQ.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		xaLisZuyHQ.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		xaLisZuyHQ.Name = "dateTo";
		xaLisZuyHQ.ValueChanged += xaLisZuyHQ_ValueChanged;
		xaLisZuyHQ.MouseDown += xaLisZuyHQ_MouseDown;
		bbYilEgbMA.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(bbYilEgbMA, "label2");
		bbYilEgbMA.ForeColor = Color.White;
		bbYilEgbMA.Name = "label2";
		componentResourceManager.ApplyResources(label3, "label3");
		label3.BackColor = Color.FromArgb(150, 166, 166);
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(dateFrom);
		base.Controls.Add(xaLisZuyHQ);
		base.Controls.Add(bbYilEgbMA);
		base.Controls.Add(btnClose);
		base.Controls.Add(label9);
		base.Controls.Add(lstAudit);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmInventoryAuditView";
		base.Opacity = 1.0;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmInventoryAuditView_Load;
		ResumeLayout(performLayout: false);
	}
}
