using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDayEndClosingPrintSettings : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public RadToggleSwitch chk;

		public _003C_003Ec__DisplayClass7_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public RadToggleSwitch chk;

		public _003C_003Ec__DisplayClass10_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private string YkgDqiEecd;

	private GClass6 TurDzAjoFA;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_1;

	private Label lblHeaderTitle;

	private Label label1;

	private Label label2;

	internal Button btnCancel;

	internal Button btnPreview;

	internal Button xKlkkkmysX;

	private Label label3;

	private RadToggleSwitch chkTenderSummary;

	private RadToggleSwitch cjokvWxObQ;

	private Label label5;

	private RadToggleSwitch chkSalesSummary;

	private Label label9;

	private Label label10;

	private Label label11;

	private Label label4;

	private RadToggleSwitch chkVoidSummary;

	private RadToggleSwitch chkTipShareSummary;

	private RadToggleSwitch chkEmployeeSummary;

	private RadToggleSwitch chkRefundSummary;

	private RadToggleSwitch chkOtherInfo;

	private Panel panel1;

	private RadToggleSwitch chkPayoutSummary;

	private Label label6;

	public frmDayEndClosingPrintSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		dateTime_0 = DateTime.Now.Date;
		dateTime_1 = DateTime.Now.Date.AddDays(1.0);
		TurDzAjoFA = new GClass6();
		bool_0 = true;
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmDayEndClosingPrintSettings_Load(object sender, EventArgs e)
	{
		YkgDqiEecd = dateTime_0.ToString() + "|" + dateTime_1.ToString();
		iqueryable_0 = TurDzAjoFA.Settings.Where((Setting x) => x.Key.Contains("eodreport"));
		using (List<RadToggleSwitch>.Enumerator enumerator = base.Controls.OfType<RadToggleSwitch>().Cast<RadToggleSwitch>().ToList()
			.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
				CS_0024_003C_003E8__locals0.chk = enumerator.Current;
				Setting setting = iqueryable_0.Where((Setting x) => x.Key == CS_0024_003C_003E8__locals0.chk.Tag.ToString()).FirstOrDefault();
				if (setting != null)
				{
					CS_0024_003C_003E8__locals0.chk.Value = ((setting.Value == "ON") ? true : false);
				}
			}
		}
		bool_0 = false;
	}

	private void btnPreview_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		GC.Collect();
		ReceiptMethods.ParseDayEndTotals(dateTime_0, dateTime_1, 0, 0);
		frmReport frmReport2 = new frmReport(YkgDqiEecd, ReportTypes.DayEndClosing, null, 0, 0);
		frmReport2.TopLevel = false;
		panel1.Controls.Add(frmReport2);
		frmReport2.FormBorderStyle = FormBorderStyle.None;
		frmReport2.Dock = DockStyle.Fill;
		frmReport2.Show();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		SettingsHelper.SetAllSettings();
		Close();
		GC.Collect();
	}

	private void xKlkkkmysX_Click(object sender, EventArgs e)
	{
		iqueryable_0 = TurDzAjoFA.Settings.Where((Setting x) => x.Key.Contains("eodreport"));
		using (List<Control>.Enumerator enumerator = base.Controls.OfType<RadToggleSwitch>().Cast<Control>().ToList()
			.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
				CS_0024_003C_003E8__locals0.chk = (RadToggleSwitch)enumerator.Current;
				Setting setting = iqueryable_0.Where((Setting x) => x.Key == CS_0024_003C_003E8__locals0.chk.Tag.ToString()).FirstOrDefault();
				if (setting != null)
				{
					setting.Value = (CS_0024_003C_003E8__locals0.chk.Value ? "ON" : "OFF");
				}
			}
		}
		Helper.SubmitChangesWithCatch(TurDzAjoFA);
		new NotificationLabel(this, "Report Settings Saved.", NotificationTypes.Success).Show();
		SettingsHelper.SetAllSettings();
	}

	private void method_3(string string_0, bool bool_1)
	{
		if (!bool_0)
		{
			SettingsHelper.GetSettingByKey(string_0).Value = (bool_1 ? "ON" : "OFF");
		}
	}

	private void cjokvWxObQ_ValueChanged(object sender, EventArgs e)
	{
		method_3(cjokvWxObQ.Tag.ToString(), cjokvWxObQ.Value);
	}

	private void chkTenderSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkTenderSummary.Tag.ToString(), chkTenderSummary.Value);
	}

	private void chkSalesSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkSalesSummary.Tag.ToString(), chkSalesSummary.Value);
	}

	private void chkVoidSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkVoidSummary.Tag.ToString(), chkVoidSummary.Value);
	}

	private void chkRefundSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkRefundSummary.Tag.ToString(), chkRefundSummary.Value);
	}

	private void chkOtherInfo_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkOtherInfo.Tag.ToString(), chkOtherInfo.Value);
	}

	private void chkEmployeeSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkEmployeeSummary.Tag.ToString(), chkEmployeeSummary.Value);
	}

	private void chkTipShareSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(chkTipShareSummary.Tag.ToString(), chkTipShareSummary.Value);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDayEndClosingPrintSettings));
		lblHeaderTitle = new Label();
		label1 = new Label();
		label2 = new Label();
		btnCancel = new Button();
		btnPreview = new Button();
		xKlkkkmysX = new Button();
		label3 = new Label();
		chkTenderSummary = new RadToggleSwitch();
		cjokvWxObQ = new RadToggleSwitch();
		label5 = new Label();
		chkSalesSummary = new RadToggleSwitch();
		label9 = new Label();
		label10 = new Label();
		label11 = new Label();
		label4 = new Label();
		chkVoidSummary = new RadToggleSwitch();
		chkTipShareSummary = new RadToggleSwitch();
		chkEmployeeSummary = new RadToggleSwitch();
		chkRefundSummary = new RadToggleSwitch();
		chkOtherInfo = new RadToggleSwitch();
		panel1 = new Panel();
		chkPayoutSummary = new RadToggleSwitch();
		label6 = new Label();
		((ISupportInitialize)chkTenderSummary).BeginInit();
		((ISupportInitialize)cjokvWxObQ).BeginInit();
		((ISupportInitialize)chkSalesSummary).BeginInit();
		((ISupportInitialize)chkVoidSummary).BeginInit();
		((ISupportInitialize)chkTipShareSummary).BeginInit();
		((ISupportInitialize)chkEmployeeSummary).BeginInit();
		((ISupportInitialize)chkRefundSummary).BeginInit();
		((ISupportInitialize)chkOtherInfo).BeginInit();
		((ISupportInitialize)chkPayoutSummary).BeginInit();
		SuspendLayout();
		lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(8, 4);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(758, 38);
		lblHeaderTitle.TabIndex = 237;
		lblHeaderTitle.Text = "DAY END CLOSING REPORT SETTINGS";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = SystemColors.ButtonFace;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(586, 45);
		label1.Margin = new Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Padding = new Padding(3, 0, 0, 0);
		label1.Size = new Size(180, 40);
		label1.TabIndex = 239;
		label1.Text = "Company Info";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = SystemColors.ButtonFace;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(586, 86);
		label2.Margin = new Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Padding = new Padding(3, 0, 0, 0);
		label2.Size = new Size(180, 40);
		label2.TabIndex = 242;
		label2.Text = "Tender Summary";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 13f);
		btnCancel.ForeColor = Color.White;
		btnCancel.Image = (Image)componentResourceManager.GetObject("btnCancel.Image");
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(485, 618);
		btnCancel.Margin = new Padding(0);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(281, 100);
		btnCancel.TabIndex = 246;
		btnCancel.Text = "CLOSE";
		btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnPreview.BackColor = Color.FromArgb(1, 110, 211);
		btnPreview.DialogResult = DialogResult.OK;
		btnPreview.FlatAppearance.BorderColor = Color.Black;
		btnPreview.FlatAppearance.BorderSize = 0;
		btnPreview.FlatStyle = FlatStyle.Flat;
		btnPreview.Font = new Font("Microsoft Sans Serif", 13f);
		btnPreview.ForeColor = Color.White;
		btnPreview.Image = (Image)componentResourceManager.GetObject("btnPreview.Image");
		btnPreview.ImeMode = ImeMode.NoControl;
		btnPreview.Location = new Point(485, 414);
		btnPreview.Margin = new Padding(0);
		btnPreview.Name = "btnPreview";
		btnPreview.Size = new Size(281, 100);
		btnPreview.TabIndex = 245;
		btnPreview.Text = "PREVIEW";
		btnPreview.TextImageRelation = TextImageRelation.ImageAboveText;
		btnPreview.UseVisualStyleBackColor = false;
		btnPreview.Click += btnPreview_Click;
		xKlkkkmysX.BackColor = Color.FromArgb(80, 203, 116);
		xKlkkkmysX.FlatAppearance.BorderColor = Color.White;
		xKlkkkmysX.FlatAppearance.BorderSize = 0;
		xKlkkkmysX.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		xKlkkkmysX.FlatStyle = FlatStyle.Flat;
		xKlkkkmysX.Font = new Font("Microsoft Sans Serif", 13f);
		xKlkkkmysX.ForeColor = Color.White;
		xKlkkkmysX.Image = (Image)componentResourceManager.GetObject("btnUpdate.Image");
		xKlkkkmysX.ImeMode = ImeMode.NoControl;
		xKlkkkmysX.Location = new Point(485, 516);
		xKlkkkmysX.Margin = new Padding(0);
		xKlkkkmysX.Name = "btnUpdate";
		xKlkkkmysX.Size = new Size(281, 100);
		xKlkkkmysX.TabIndex = 244;
		xKlkkkmysX.Text = "SAVE";
		xKlkkkmysX.TextImageRelation = TextImageRelation.ImageAboveText;
		xKlkkkmysX.UseVisualStyleBackColor = false;
		xKlkkkmysX.Click += xKlkkkmysX_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 12f);
		label3.ForeColor = SystemColors.ButtonFace;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(586, 209);
		label3.Margin = new Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Padding = new Padding(3, 0, 0, 0);
		label3.Size = new Size(180, 40);
		label3.TabIndex = 248;
		label3.Text = "Refund Summary";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		chkTenderSummary.Location = new Point(485, 86);
		chkTenderSummary.Name = "chkTenderSummary";
		chkTenderSummary.OffText = "HIDDEN";
		chkTenderSummary.OnText = "SHOW";
		chkTenderSummary.Size = new Size(100, 40);
		chkTenderSummary.TabIndex = 251;
		chkTenderSummary.Tag = "eodreport_tender_summary";
		chkTenderSummary.ToggleStateMode = ToggleStateMode.Click;
		chkTenderSummary.Value = false;
		chkTenderSummary.ValueChanged += chkTenderSummary_ValueChanged;
		((RadToggleSwitchElement)chkTenderSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkTenderSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkTenderSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkTenderSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkTenderSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTenderSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTenderSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkTenderSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		cjokvWxObQ.Location = new Point(485, 45);
		cjokvWxObQ.Name = "chkCompanyInfo";
		cjokvWxObQ.OffText = "HIDDEN";
		cjokvWxObQ.OnText = "SHOW";
		cjokvWxObQ.Size = new Size(100, 40);
		cjokvWxObQ.TabIndex = 255;
		cjokvWxObQ.Tag = "eodreport_company_info";
		cjokvWxObQ.ToggleStateMode = ToggleStateMode.Click;
		cjokvWxObQ.Value = false;
		cjokvWxObQ.ValueChanged += cjokvWxObQ_ValueChanged;
		((RadToggleSwitchElement)cjokvWxObQ.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)cjokvWxObQ.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)cjokvWxObQ.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)cjokvWxObQ.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)cjokvWxObQ.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)cjokvWxObQ.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)cjokvWxObQ.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)cjokvWxObQ.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label5.BackColor = Color.FromArgb(132, 146, 146);
		label5.Font = new Font("Microsoft Sans Serif", 12f);
		label5.ForeColor = SystemColors.ButtonFace;
		label5.ImeMode = ImeMode.NoControl;
		label5.Location = new Point(586, 168);
		label5.Margin = new Padding(2, 0, 2, 0);
		label5.Name = "label5";
		label5.Padding = new Padding(3, 0, 0, 0);
		label5.Size = new Size(180, 40);
		label5.TabIndex = 254;
		label5.Text = "Void Summary";
		label5.TextAlign = ContentAlignment.MiddleLeft;
		chkSalesSummary.Location = new Point(485, 127);
		chkSalesSummary.Name = "chkSalesSummary";
		chkSalesSummary.OffText = "HIDDEN";
		chkSalesSummary.OnText = "SHOW";
		chkSalesSummary.Size = new Size(100, 40);
		chkSalesSummary.TabIndex = 259;
		chkSalesSummary.Tag = "eodreport_sales_summary";
		chkSalesSummary.ToggleStateMode = ToggleStateMode.Click;
		chkSalesSummary.Value = false;
		chkSalesSummary.ValueChanged += chkSalesSummary_ValueChanged;
		((RadToggleSwitchElement)chkSalesSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkSalesSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkSalesSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkSalesSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkSalesSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSalesSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkSalesSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkSalesSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label9.BackColor = Color.FromArgb(132, 146, 146);
		label9.Font = new Font("Microsoft Sans Serif", 12f);
		label9.ForeColor = SystemColors.ButtonFace;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(586, 127);
		label9.Margin = new Padding(2, 0, 2, 0);
		label9.Name = "label9";
		label9.Padding = new Padding(3, 0, 0, 0);
		label9.Size = new Size(180, 40);
		label9.TabIndex = 260;
		label9.Text = "Sales Summary";
		label9.TextAlign = ContentAlignment.MiddleLeft;
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.Font = new Font("Microsoft Sans Serif", 12f);
		label10.ForeColor = SystemColors.ButtonFace;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(586, 291);
		label10.Margin = new Padding(2, 0, 2, 0);
		label10.Name = "label10";
		label10.Padding = new Padding(3, 0, 0, 0);
		label10.Size = new Size(180, 40);
		label10.TabIndex = 263;
		label10.Text = "Other Information";
		label10.TextAlign = ContentAlignment.MiddleLeft;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		label11.Font = new Font("Microsoft Sans Serif", 12f);
		label11.ForeColor = SystemColors.ButtonFace;
		label11.ImeMode = ImeMode.NoControl;
		label11.Location = new Point(586, 332);
		label11.Margin = new Padding(2, 0, 2, 0);
		label11.Name = "label11";
		label11.Padding = new Padding(3, 0, 0, 0);
		label11.Size = new Size(180, 40);
		label11.TabIndex = 264;
		label11.Text = "Employee Summary";
		label11.TextAlign = ContentAlignment.MiddleLeft;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		label4.Font = new Font("Microsoft Sans Serif", 12f);
		label4.ForeColor = SystemColors.ButtonFace;
		label4.ImeMode = ImeMode.NoControl;
		label4.Location = new Point(586, 373);
		label4.Margin = new Padding(2, 0, 2, 0);
		label4.Name = "label4";
		label4.Padding = new Padding(3, 0, 0, 0);
		label4.Size = new Size(180, 40);
		label4.TabIndex = 265;
		label4.Text = "Tip Share Summary";
		label4.TextAlign = ContentAlignment.MiddleLeft;
		chkVoidSummary.Location = new Point(485, 168);
		chkVoidSummary.Name = "chkVoidSummary";
		chkVoidSummary.OffText = "HIDDEN";
		chkVoidSummary.OnText = "SHOW";
		chkVoidSummary.Size = new Size(100, 40);
		chkVoidSummary.TabIndex = 256;
		chkVoidSummary.Tag = "eodreport_void_summary";
		chkVoidSummary.ToggleStateMode = ToggleStateMode.Click;
		chkVoidSummary.Value = false;
		chkVoidSummary.ValueChanged += chkVoidSummary_ValueChanged;
		((RadToggleSwitchElement)chkVoidSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkVoidSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkVoidSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkVoidSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkVoidSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkVoidSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkVoidSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkVoidSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		chkTipShareSummary.Location = new Point(485, 373);
		chkTipShareSummary.Name = "chkTipShareSummary";
		chkTipShareSummary.OffText = "HIDDEN";
		chkTipShareSummary.OnText = "SHOW";
		chkTipShareSummary.Size = new Size(100, 40);
		chkTipShareSummary.TabIndex = 262;
		chkTipShareSummary.Tag = "eodreport_tipshare_summary";
		chkTipShareSummary.ToggleStateMode = ToggleStateMode.Click;
		chkTipShareSummary.Value = false;
		chkTipShareSummary.ValueChanged += chkTipShareSummary_ValueChanged;
		((RadToggleSwitchElement)chkTipShareSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkTipShareSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkTipShareSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkTipShareSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkTipShareSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTipShareSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTipShareSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkTipShareSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		chkEmployeeSummary.Location = new Point(485, 332);
		chkEmployeeSummary.Name = "chkEmployeeSummary";
		chkEmployeeSummary.OffText = "HIDDEN";
		chkEmployeeSummary.OnText = "SHOW";
		chkEmployeeSummary.Size = new Size(100, 40);
		chkEmployeeSummary.TabIndex = 263;
		chkEmployeeSummary.Tag = "eodreport_employee_summary";
		chkEmployeeSummary.ToggleStateMode = ToggleStateMode.Click;
		chkEmployeeSummary.Value = false;
		chkEmployeeSummary.ValueChanged += chkEmployeeSummary_ValueChanged;
		((RadToggleSwitchElement)chkEmployeeSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkEmployeeSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkEmployeeSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkEmployeeSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkEmployeeSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEmployeeSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkEmployeeSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkEmployeeSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		chkRefundSummary.Location = new Point(485, 209);
		chkRefundSummary.Name = "chkRefundSummary";
		chkRefundSummary.OffText = "HIDDEN";
		chkRefundSummary.OnText = "SHOW";
		chkRefundSummary.Size = new Size(100, 40);
		chkRefundSummary.TabIndex = 261;
		chkRefundSummary.Tag = "eodreport_refund_summary";
		chkRefundSummary.ToggleStateMode = ToggleStateMode.Click;
		chkRefundSummary.Value = false;
		chkRefundSummary.ValueChanged += chkRefundSummary_ValueChanged;
		((RadToggleSwitchElement)chkRefundSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkRefundSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkRefundSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkRefundSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkRefundSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkRefundSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkRefundSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkRefundSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		chkOtherInfo.Location = new Point(485, 291);
		chkOtherInfo.Name = "chkOtherInfo";
		chkOtherInfo.OffText = "HIDDEN";
		chkOtherInfo.OnText = "SHOW";
		chkOtherInfo.Size = new Size(100, 40);
		chkOtherInfo.TabIndex = 260;
		chkOtherInfo.Tag = "eodreport_other_info";
		chkOtherInfo.ToggleStateMode = ToggleStateMode.Click;
		chkOtherInfo.Value = false;
		chkOtherInfo.ValueChanged += chkOtherInfo_ValueChanged;
		((RadToggleSwitchElement)chkOtherInfo.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkOtherInfo.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkOtherInfo.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkOtherInfo.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkOtherInfo.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkOtherInfo.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkOtherInfo.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkOtherInfo.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		panel1.Location = new Point(6, 47);
		panel1.Name = "panel1";
		panel1.Size = new Size(448, 671);
		panel1.TabIndex = 266;
		chkPayoutSummary.Location = new Point(485, 250);
		chkPayoutSummary.Name = "chkPayoutSummary";
		chkPayoutSummary.OffText = "HIDDEN";
		chkPayoutSummary.OnText = "SHOW";
		chkPayoutSummary.Size = new Size(100, 40);
		chkPayoutSummary.TabIndex = 267;
		chkPayoutSummary.Tag = "eodreport_payout_summary";
		chkPayoutSummary.ToggleStateMode = ToggleStateMode.Click;
		chkPayoutSummary.Value = false;
		((RadToggleSwitchElement)chkPayoutSummary.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkPayoutSummary.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkPayoutSummary.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkPayoutSummary.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkPayoutSummary.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPayoutSummary.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkPayoutSummary.GetChildAt(0).GetChildAt(0)).Text = "SHOW";
		((ToggleSwitchPartElement)chkPayoutSummary.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label6.BackColor = Color.FromArgb(132, 146, 146);
		label6.Font = new Font("Microsoft Sans Serif", 12f);
		label6.ForeColor = SystemColors.ButtonFace;
		label6.ImeMode = ImeMode.NoControl;
		label6.Location = new Point(586, 250);
		label6.Margin = new Padding(2, 0, 2, 0);
		label6.Name = "label6";
		label6.Padding = new Padding(3, 0, 0, 0);
		label6.Size = new Size(180, 40);
		label6.TabIndex = 268;
		label6.Text = "Payout Information";
		label6.TextAlign = ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(775, 723);
		base.Controls.Add(chkPayoutSummary);
		base.Controls.Add(label6);
		base.Controls.Add(panel1);
		base.Controls.Add(chkTipShareSummary);
		base.Controls.Add(chkEmployeeSummary);
		base.Controls.Add(chkVoidSummary);
		base.Controls.Add(chkRefundSummary);
		base.Controls.Add(label4);
		base.Controls.Add(chkOtherInfo);
		base.Controls.Add(label11);
		base.Controls.Add(label10);
		base.Controls.Add(label9);
		base.Controls.Add(chkSalesSummary);
		base.Controls.Add(cjokvWxObQ);
		base.Controls.Add(label5);
		base.Controls.Add(chkTenderSummary);
		base.Controls.Add(label3);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnPreview);
		base.Controls.Add(xKlkkkmysX);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmDayEndClosingPrintSettings";
		base.Opacity = 1.0;
		Text = "frmDayEndClosingPrintSettings";
		base.Load += frmDayEndClosingPrintSettings_Load;
		((ISupportInitialize)chkTenderSummary).EndInit();
		((ISupportInitialize)cjokvWxObQ).EndInit();
		((ISupportInitialize)chkSalesSummary).EndInit();
		((ISupportInitialize)chkVoidSummary).EndInit();
		((ISupportInitialize)chkTipShareSummary).EndInit();
		((ISupportInitialize)chkEmployeeSummary).EndInit();
		((ISupportInitialize)chkRefundSummary).EndInit();
		((ISupportInitialize)chkOtherInfo).EndInit();
		((ISupportInitialize)chkPayoutSummary).EndInit();
		ResumeLayout(performLayout: false);
	}
}
