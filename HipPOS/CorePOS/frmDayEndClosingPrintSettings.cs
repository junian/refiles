using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDayEndClosingPrintSettings : frmMasterForm
{
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
		base._002Ector();
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
				Setting setting = iqueryable_0.Where((Setting x) => x.Key == ((Control)(object)CS_0024_003C_003E8__locals0.chk).Tag.ToString()).FirstOrDefault();
				if (setting != null)
				{
					CS_0024_003C_003E8__locals0.chk.set_Value((setting.Value == "ON") ? true : false);
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
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		iqueryable_0 = TurDzAjoFA.Settings.Where((Setting x) => x.Key.Contains("eodreport"));
		using (List<Control>.Enumerator enumerator = base.Controls.OfType<RadToggleSwitch>().Cast<Control>().ToList()
			.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
				CS_0024_003C_003E8__locals0.chk = (RadToggleSwitch)enumerator.Current;
				Setting setting = iqueryable_0.Where((Setting x) => x.Key == ((Control)(object)CS_0024_003C_003E8__locals0.chk).Tag.ToString()).FirstOrDefault();
				if (setting != null)
				{
					setting.Value = (CS_0024_003C_003E8__locals0.chk.get_Value() ? "ON" : "OFF");
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
		method_3(((Control)(object)cjokvWxObQ).Tag.ToString(), cjokvWxObQ.get_Value());
	}

	private void chkTenderSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkTenderSummary).Tag.ToString(), chkTenderSummary.get_Value());
	}

	private void chkSalesSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkSalesSummary).Tag.ToString(), chkSalesSummary.get_Value());
	}

	private void chkVoidSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkVoidSummary).Tag.ToString(), chkVoidSummary.get_Value());
	}

	private void chkRefundSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkRefundSummary).Tag.ToString(), chkRefundSummary.get_Value());
	}

	private void chkOtherInfo_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkOtherInfo).Tag.ToString(), chkOtherInfo.get_Value());
	}

	private void chkEmployeeSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkEmployeeSummary).Tag.ToString(), chkEmployeeSummary.get_Value());
	}

	private void chkTipShareSummary_ValueChanged(object sender, EventArgs e)
	{
		method_3(((Control)(object)chkTipShareSummary).Tag.ToString(), chkTipShareSummary.get_Value());
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
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_138c: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1409: Unknown result type (might be due to invalid IL or missing references)
		//IL_1436: Unknown result type (might be due to invalid IL or missing references)
		//IL_1463: Unknown result type (might be due to invalid IL or missing references)
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_1570: Unknown result type (might be due to invalid IL or missing references)
		//IL_1587: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1602: Unknown result type (might be due to invalid IL or missing references)
		//IL_162f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1650: Unknown result type (might be due to invalid IL or missing references)
		//IL_1724: Unknown result type (might be due to invalid IL or missing references)
		//IL_173c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1753: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_181c: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1908: Unknown result type (might be due to invalid IL or missing references)
		//IL_191f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1940: Unknown result type (might be due to invalid IL or missing references)
		//IL_196d: Unknown result type (might be due to invalid IL or missing references)
		//IL_199a: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db6: Unknown result type (might be due to invalid IL or missing references)
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
		((Control)(object)chkTenderSummary).Location = new Point(485, 86);
		((Control)(object)chkTenderSummary).Name = "chkTenderSummary";
		chkTenderSummary.set_OffText("HIDDEN");
		chkTenderSummary.set_OnText("SHOW");
		((Control)(object)chkTenderSummary).Size = new Size(100, 40);
		((Control)(object)chkTenderSummary).TabIndex = 251;
		((Control)(object)chkTenderSummary).Tag = "eodreport_tender_summary";
		chkTenderSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkTenderSummary.set_Value(false);
		chkTenderSummary.add_ValueChanged((EventHandler)chkTenderSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkTenderSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTenderSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTenderSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTenderSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTenderSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTenderSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTenderSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTenderSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)cjokvWxObQ).Location = new Point(485, 45);
		((Control)(object)cjokvWxObQ).Name = "chkCompanyInfo";
		cjokvWxObQ.set_OffText("HIDDEN");
		cjokvWxObQ.set_OnText("SHOW");
		((Control)(object)cjokvWxObQ).Size = new Size(100, 40);
		((Control)(object)cjokvWxObQ).TabIndex = 255;
		((Control)(object)cjokvWxObQ).Tag = "eodreport_company_info";
		cjokvWxObQ.set_ToggleStateMode((ToggleStateMode)1);
		cjokvWxObQ.set_Value(false);
		cjokvWxObQ.add_ValueChanged((EventHandler)cjokvWxObQ_ValueChanged);
		((RadToggleSwitchElement)((RadControl)cjokvWxObQ).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)cjokvWxObQ).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)cjokvWxObQ).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)cjokvWxObQ).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)cjokvWxObQ).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)cjokvWxObQ).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)cjokvWxObQ).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)cjokvWxObQ).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)chkSalesSummary).Location = new Point(485, 127);
		((Control)(object)chkSalesSummary).Name = "chkSalesSummary";
		chkSalesSummary.set_OffText("HIDDEN");
		chkSalesSummary.set_OnText("SHOW");
		((Control)(object)chkSalesSummary).Size = new Size(100, 40);
		((Control)(object)chkSalesSummary).TabIndex = 259;
		((Control)(object)chkSalesSummary).Tag = "eodreport_sales_summary";
		chkSalesSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkSalesSummary.set_Value(false);
		chkSalesSummary.add_ValueChanged((EventHandler)chkSalesSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkSalesSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkSalesSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkSalesSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSalesSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSalesSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkSalesSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkSalesSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkSalesSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)chkVoidSummary).Location = new Point(485, 168);
		((Control)(object)chkVoidSummary).Name = "chkVoidSummary";
		chkVoidSummary.set_OffText("HIDDEN");
		chkVoidSummary.set_OnText("SHOW");
		((Control)(object)chkVoidSummary).Size = new Size(100, 40);
		((Control)(object)chkVoidSummary).TabIndex = 256;
		((Control)(object)chkVoidSummary).Tag = "eodreport_void_summary";
		chkVoidSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkVoidSummary.set_Value(false);
		chkVoidSummary.add_ValueChanged((EventHandler)chkVoidSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkVoidSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkVoidSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkVoidSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkVoidSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkVoidSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkVoidSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkVoidSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkVoidSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkTipShareSummary).Location = new Point(485, 373);
		((Control)(object)chkTipShareSummary).Name = "chkTipShareSummary";
		chkTipShareSummary.set_OffText("HIDDEN");
		chkTipShareSummary.set_OnText("SHOW");
		((Control)(object)chkTipShareSummary).Size = new Size(100, 40);
		((Control)(object)chkTipShareSummary).TabIndex = 262;
		((Control)(object)chkTipShareSummary).Tag = "eodreport_tipshare_summary";
		chkTipShareSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkTipShareSummary.set_Value(false);
		chkTipShareSummary.add_ValueChanged((EventHandler)chkTipShareSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkTipShareSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTipShareSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTipShareSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTipShareSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTipShareSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTipShareSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTipShareSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTipShareSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkEmployeeSummary).Location = new Point(485, 332);
		((Control)(object)chkEmployeeSummary).Name = "chkEmployeeSummary";
		chkEmployeeSummary.set_OffText("HIDDEN");
		chkEmployeeSummary.set_OnText("SHOW");
		((Control)(object)chkEmployeeSummary).Size = new Size(100, 40);
		((Control)(object)chkEmployeeSummary).TabIndex = 263;
		((Control)(object)chkEmployeeSummary).Tag = "eodreport_employee_summary";
		chkEmployeeSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkEmployeeSummary.set_Value(false);
		chkEmployeeSummary.add_ValueChanged((EventHandler)chkEmployeeSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkEmployeeSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkEmployeeSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkEmployeeSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEmployeeSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEmployeeSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkEmployeeSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkEmployeeSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkEmployeeSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkRefundSummary).Location = new Point(485, 209);
		((Control)(object)chkRefundSummary).Name = "chkRefundSummary";
		chkRefundSummary.set_OffText("HIDDEN");
		chkRefundSummary.set_OnText("SHOW");
		((Control)(object)chkRefundSummary).Size = new Size(100, 40);
		((Control)(object)chkRefundSummary).TabIndex = 261;
		((Control)(object)chkRefundSummary).Tag = "eodreport_refund_summary";
		chkRefundSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkRefundSummary.set_Value(false);
		chkRefundSummary.add_ValueChanged((EventHandler)chkRefundSummary_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkRefundSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkRefundSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkRefundSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkRefundSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkRefundSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkRefundSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkRefundSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkRefundSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		((Control)(object)chkOtherInfo).Location = new Point(485, 291);
		((Control)(object)chkOtherInfo).Name = "chkOtherInfo";
		chkOtherInfo.set_OffText("HIDDEN");
		chkOtherInfo.set_OnText("SHOW");
		((Control)(object)chkOtherInfo).Size = new Size(100, 40);
		((Control)(object)chkOtherInfo).TabIndex = 260;
		((Control)(object)chkOtherInfo).Tag = "eodreport_other_info";
		chkOtherInfo.set_ToggleStateMode((ToggleStateMode)1);
		chkOtherInfo.set_Value(false);
		chkOtherInfo.add_ValueChanged((EventHandler)chkOtherInfo_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkOtherInfo).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkOtherInfo).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkOtherInfo).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOtherInfo).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOtherInfo).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkOtherInfo).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkOtherInfo).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkOtherInfo).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		panel1.Location = new Point(6, 47);
		panel1.Name = "panel1";
		panel1.Size = new Size(448, 671);
		panel1.TabIndex = 266;
		((Control)(object)chkPayoutSummary).Location = new Point(485, 250);
		((Control)(object)chkPayoutSummary).Name = "chkPayoutSummary";
		chkPayoutSummary.set_OffText("HIDDEN");
		chkPayoutSummary.set_OnText("SHOW");
		((Control)(object)chkPayoutSummary).Size = new Size(100, 40);
		((Control)(object)chkPayoutSummary).TabIndex = 267;
		((Control)(object)chkPayoutSummary).Tag = "eodreport_payout_summary";
		chkPayoutSummary.set_ToggleStateMode((ToggleStateMode)1);
		chkPayoutSummary.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkPayoutSummary).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkPayoutSummary).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkPayoutSummary).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPayoutSummary).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPayoutSummary).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkPayoutSummary).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkPayoutSummary).GetChildAt(0).GetChildAt(0)).set_Text("SHOW");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkPayoutSummary).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		base.Controls.Add((Control)(object)chkPayoutSummary);
		base.Controls.Add(label6);
		base.Controls.Add(panel1);
		base.Controls.Add((Control)(object)chkTipShareSummary);
		base.Controls.Add((Control)(object)chkEmployeeSummary);
		base.Controls.Add((Control)(object)chkVoidSummary);
		base.Controls.Add((Control)(object)chkRefundSummary);
		base.Controls.Add(label4);
		base.Controls.Add((Control)(object)chkOtherInfo);
		base.Controls.Add(label11);
		base.Controls.Add(label10);
		base.Controls.Add(label9);
		base.Controls.Add((Control)(object)chkSalesSummary);
		base.Controls.Add((Control)(object)cjokvWxObQ);
		base.Controls.Add(label5);
		base.Controls.Add((Control)(object)chkTenderSummary);
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
