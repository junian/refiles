using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Data.Properties;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel.Settings;

public class PrintSettings : UserControl
{
	private GClass6 gclass6_0;

	private IQueryable<Setting> iqueryable_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Label lblDefaultPrinter;

	private Label label6;

	private PictureBox pictureBox3;

	private Label label5;

	private Label label8;

	private PictureBox pictureBox4;

	private Label label7;

	private Label label11;

	private PictureBox pictureBox6;

	private Label label12;

	private RadToggleSwitch chkAutoPrintOnCashout;

	private Label label9;

	private PictureBox pictureBox7;

	private Label label13;

	private Class19 ddlChitPrintServer;

	private RadToggleSwitch chkPrintCancelled;

	private Label label14;

	private PictureBox pictureBox8;

	private Label label15;

	private Label label16;

	private Label lblChangePrintStationSetting;

	private RadToggleSwitch chkPrintChitClockOut;

	private Label lblPrintClockout2;

	private PictureBox pictureBox1;

	private Label lblPrintClockout;

	private Panel pnlTimeAttendance;

	private RadToggleSwitch chkAutoPrintMerchant;

	private Label lblPrintMerchantDesc;

	private PictureBox pictureBox2;

	private Label lblPrintMerchant;

	private Label lblConfigureDayEndClosingSettings;

	private Label label2;

	private PictureBox pictureBox5;

	private Label label3;

	private RadToggleSwitch btnAutoPrintOrderTicket;

	private Label lblOrderTicketDesc;

	private Label lblOrderTicketTitle;

	private Label lblManageTickets;

	private PictureBox pictureBox10;

	private Label label1;

	private RadToggleSwitch chkOrderTickets;

	private Label label4;

	private Panel pnlOrderTicket;

	private RadToggleSwitch chkOneChitPerTable;

	private Label label10;

	private PictureBox pictureBox9;

	private Label label17;

	private Panel pnlFullService;

	private PictureBox pictureBox11;

	private RadToggleSwitch chkPrintEoDClockOut;

	private Label label18;

	private Label label19;

	[DllImport("winspool.Drv", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultPrinter(string name);

	public PrintSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		gclass6_0 = new GClass6();
		bool_0 = true;
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		iqueryable_0 = gclass6_0.Settings;
		Dictionary<int, string> dictionary = new Dictionary<int, string> { { 0, "None" } };
		foreach (KeyValuePair<int, string> item in (from a in gclass6_0.Terminals
			where a.Status == TerminalStatus.active
			orderby a.SystemName
			select a).ToDictionary((Terminal a) => a.TerminalID, (Terminal a) => a.SystemName))
		{
			dictionary.Add(item.Key, item.Value);
		}
		ddlChitPrintServer.DisplayMember = "Value";
		ddlChitPrintServer.ValueMember = "Key";
		ddlChitPrintServer.DataSource = new BindingSource(dictionary, null);
		IEnumerator enumerator2 = base.Controls.GetEnumerator();
		Setting setting;
		try
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
				CS_0024_003C_003E8__locals0.ctrl = (Control)enumerator2.Current;
				if (CS_0024_003C_003E8__locals0.ctrl.Tag == null)
				{
					continue;
				}
				setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.ctrl.Tag.Equals(s.Key)).FirstOrDefault();
				if (setting == null)
				{
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.GetType().Name == "Label")
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("label"))
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
					}
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddl"))
				{
					if (CS_0024_003C_003E8__locals0.ctrl.Name.Contains("ddlReceiptSize"))
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value + "mm";
					}
					else
					{
						CS_0024_003C_003E8__locals0.ctrl.Text = setting.Value;
					}
					continue;
				}
				if (CS_0024_003C_003E8__locals0.ctrl.Name == chkOrderTickets.Name)
				{
					if (setting.Value == "ON")
					{
						pnlOrderTicket.Visible = true;
					}
					else
					{
						pnlOrderTicket.Visible = false;
					}
				}
				if (setting.Value.Contains("ON"))
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = true;
				}
				else
				{
					((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Value = false;
				}
				((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.ValueChanged += method_0;
				((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).ToggleSwitchElement.Tag = ((RadToggleSwitch)CS_0024_003C_003E8__locals0.ctrl).Tag;
			}
		}
		finally
		{
			IDisposable disposable = enumerator2 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		setting = iqueryable_0.Where((Setting s) => chkPrintChitClockOut.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.Contains("ON"))
			{
				chkPrintChitClockOut.Value = true;
			}
			else
			{
				chkPrintChitClockOut.Value = false;
			}
			chkPrintChitClockOut.ToggleSwitchElement.ValueChanged += method_0;
			chkPrintChitClockOut.ToggleSwitchElement.Tag = chkPrintChitClockOut.Tag;
		}
		setting = iqueryable_0.Where((Setting s) => chkPrintEoDClockOut.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.Contains("ON"))
			{
				chkPrintEoDClockOut.Value = true;
			}
			else
			{
				chkPrintEoDClockOut.Value = false;
			}
			chkPrintEoDClockOut.ToggleSwitchElement.ValueChanged += method_0;
			chkPrintEoDClockOut.ToggleSwitchElement.Tag = chkPrintEoDClockOut.Tag;
		}
		setting = iqueryable_0.Where((Setting s) => btnAutoPrintOrderTicket.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.Contains("ON"))
			{
				btnAutoPrintOrderTicket.Value = true;
			}
			else
			{
				btnAutoPrintOrderTicket.Value = false;
			}
			btnAutoPrintOrderTicket.ToggleSwitchElement.ValueChanged += method_0;
			btnAutoPrintOrderTicket.ToggleSwitchElement.Tag = btnAutoPrintOrderTicket.Tag;
		}
		string settingValueByKey = SettingsHelper.GetSettingValueByKey("hippos_time");
		if (!string.IsNullOrEmpty(settingValueByKey))
		{
			if (settingValueByKey == "Disabled")
			{
				pnlTimeAttendance.Visible = false;
			}
			else
			{
				pnlTimeAttendance.Visible = true;
			}
		}
		if (iqueryable_0.Where((Setting a) => a.Key == "restaurant_mode").FirstOrDefault().Value == "Dine In")
		{
			pnlFullService.Visible = true;
			setting = iqueryable_0.Where((Setting s) => chkOneChitPerTable.Tag.Equals(s.Key)).FirstOrDefault();
			if (setting != null)
			{
				if (setting.Value.Contains("ON"))
				{
					chkOneChitPerTable.Value = true;
				}
				else
				{
					chkOneChitPerTable.Value = false;
				}
			}
		}
		else
		{
			pnlFullService.Visible = false;
			pnlTimeAttendance.Location = new Point(pnlTimeAttendance.Location.X, pnlFullService.Location.Y);
		}
		bool_0 = false;
	}

	private void lblDefaultPrinter_Click(object sender, EventArgs e)
	{
		PrintDialog printDialog = new PrintDialog();
		if (printDialog.ShowDialog(this) != DialogResult.Cancel)
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			SetDefaultPrinter(printDialog.PrinterSettings.PrinterName);
			GClass6 gClass = new GClass6();
			Terminal terminal = gClass.Terminals.Where((Terminal x) => x.SystemName == Environment.MachineName).FirstOrDefault();
			if (terminal != null)
			{
				terminal.DefaultPrinter = printDialog.PrinterSettings.PrinterName;
				Helper.SubmitChangesWithCatch(gClass);
				MemoryLoadedObjects.RefreshTerminalData();
			}
			CS_0024_003C_003E8__locals0.employeeId = Convert.ToInt32(CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"].ToString());
			Employee employee = gClass.Employees.Where((Employee a) => a.EmployeeID == CS_0024_003C_003E8__locals0.employeeId).FirstOrDefault();
			if (employee != null)
			{
				LogHelper.WriteLog("Printer changed by " + employee.EmployeeName + " " + employee.FirstName + " " + employee.LastName + " to " + printDialog.PrinterSettings.PrinterName, LogTypes.print_log);
			}
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.chkToggle = sender as RadToggleSwitchElement;
		Setting setting = iqueryable_0.Where((Setting s) => CS_0024_003C_003E8__locals0.chkToggle.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (setting.Value.ToUpper().Equals("ON"))
			{
				setting.Value = "OFF";
			}
			else
			{
				setting.Value = "ON";
			}
			setting.Synced = false;
			Helper.SubmitChangesWithCatch(gclass6_0);
			SettingsHelper.SetSettingValueByKey(CS_0024_003C_003E8__locals0.chkToggle.Tag.ToString(), setting.Value);
		}
	}

	private void ddlChitPrintServer_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => ddlChitPrintServer.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting == null)
		{
			return;
		}
		setting.Value = ddlChitPrintServer.Text;
		gclass6_0.Terminals.ToList().ForEach(delegate(Terminal a)
		{
			a.AppRestartRequired = true;
		});
		try
		{
			gclass6_0.SubmitChanges(ConflictMode.ContinueOnConflict);
		}
		catch (ChangeConflictException ex)
		{
			Console.WriteLine(ex.Message);
			foreach (ObjectChangeConflict changeConflict in gclass6_0.ChangeConflicts)
			{
				changeConflict.Resolve(RefreshMode.OverwriteCurrentValues);
			}
		}
	}

	private void lblChangePrintStationSetting_Click(object sender, EventArgs e)
	{
		new frmManageStations().Show(base.ParentForm);
	}

	private void lblConfigureDayEndClosingSettings_Click(object sender, EventArgs e)
	{
		new frmDayEndClosingPrintSettings().Show(base.ParentForm);
	}

	private void lblManageTickets_Click(object sender, EventArgs e)
	{
		new frmManageOrderTickets().Show(this);
	}

	private void chkOneChitPerTable_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Setting setting = iqueryable_0.Where((Setting s) => chkOneChitPerTable.Tag.Equals(s.Key)).FirstOrDefault();
		if (setting != null)
		{
			if (chkOneChitPerTable.Value)
			{
				setting.Value = "ON";
			}
			else
			{
				setting.Value = "OFF";
			}
			setting.Synced = false;
			gclass6_0.SubmitChanges();
			SettingsHelper.SetSettingValueByKey(chkOneChitPerTable.Tag.ToString(), setting.Value);
		}
	}

	private void chkPrintEoDClockOut_ValueChanged(object sender, EventArgs e)
	{
	}

	private void chkPrintChitClockOut_ValueChanged(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.AdminPanel.Settings.PrintSettings));
		this.lblDefaultPrinter = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.label7 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.label12 = new System.Windows.Forms.Label();
		this.chkAutoPrintOnCashout = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label9 = new System.Windows.Forms.Label();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.label13 = new System.Windows.Forms.Label();
		this.chkPrintCancelled = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label14 = new System.Windows.Forms.Label();
		this.pictureBox8 = new System.Windows.Forms.PictureBox();
		this.label15 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.lblChangePrintStationSetting = new System.Windows.Forms.Label();
		this.chkPrintChitClockOut = new Telerik.WinControls.UI.RadToggleSwitch();
		this.lblPrintClockout2 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblPrintClockout = new System.Windows.Forms.Label();
		this.pnlTimeAttendance = new System.Windows.Forms.Panel();
		this.chkAutoPrintMerchant = new Telerik.WinControls.UI.RadToggleSwitch();
		this.lblPrintMerchantDesc = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.lblPrintMerchant = new System.Windows.Forms.Label();
		this.lblConfigureDayEndClosingSettings = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.label3 = new System.Windows.Forms.Label();
		this.btnAutoPrintOrderTicket = new Telerik.WinControls.UI.RadToggleSwitch();
		this.lblOrderTicketDesc = new System.Windows.Forms.Label();
		this.lblOrderTicketTitle = new System.Windows.Forms.Label();
		this.lblManageTickets = new System.Windows.Forms.Label();
		this.pictureBox10 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.chkOrderTickets = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label4 = new System.Windows.Forms.Label();
		this.pnlOrderTicket = new System.Windows.Forms.Panel();
		this.chkOneChitPerTable = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label10 = new System.Windows.Forms.Label();
		this.pictureBox9 = new System.Windows.Forms.PictureBox();
		this.label17 = new System.Windows.Forms.Label();
		this.ddlChitPrintServer = new Class19();
		this.pnlFullService = new System.Windows.Forms.Panel();
		this.pictureBox11 = new System.Windows.Forms.PictureBox();
		this.chkPrintEoDClockOut = new Telerik.WinControls.UI.RadToggleSwitch();
		this.label18 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoPrintOnCashout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintCancelled).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintChitClockOut).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.pnlTimeAttendance.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkAutoPrintMerchant).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnAutoPrintOrderTicket).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkOrderTickets).BeginInit();
		this.pnlOrderTicket.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkOneChitPerTable).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).BeginInit();
		this.pnlFullService.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintEoDClockOut).BeginInit();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.lblDefaultPrinter, "lblDefaultPrinter");
		this.lblDefaultPrinter.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblDefaultPrinter.Name = "lblDefaultPrinter";
		this.lblDefaultPrinter.Tag = "printer_default";
		this.lblDefaultPrinter.Click += new System.EventHandler(lblDefaultPrinter_Click);
		componentResourceManager.ApplyResources(this.label6, "label6");
		this.label6.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label6.Name = "label6";
		this.label6.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox3, "pictureBox3");
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.TabStop = false;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label5, "label5");
		this.label5.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label5.Name = "label5";
		componentResourceManager.ApplyResources(this.label8, "label8");
		this.label8.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label8.Name = "label8";
		this.label8.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox4, "pictureBox4");
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.TabStop = false;
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label7, "label7");
		this.label7.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label7.Name = "label7";
		componentResourceManager.ApplyResources(this.label11, "label11");
		this.label11.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label11.Name = "label11";
		this.label11.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox6, "pictureBox6");
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.TabStop = false;
		this.label12.BackColor = System.Drawing.Color.Transparent;
		this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label12, "label12");
		this.label12.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label12.Name = "label12";
		componentResourceManager.ApplyResources(this.chkAutoPrintOnCashout, "chkAutoPrintOnCashout");
		this.chkAutoPrintOnCashout.Name = "chkAutoPrintOnCashout";
		this.chkAutoPrintOnCashout.Tag = "auto_print_receipt";
		this.chkAutoPrintOnCashout.ThumbTickness = 27;
		this.chkAutoPrintOnCashout.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoPrintOnCashout.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintOnCashout.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintOnCashout.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintOnCashout.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintOnCashout.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintOnCashout.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintOnCashout.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintOnCashout.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.label9, "label9");
		this.label9.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label9.Name = "label9";
		this.label9.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox7, "pictureBox7");
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.TabStop = false;
		this.label13.BackColor = System.Drawing.Color.Transparent;
		this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label13, "label13");
		this.label13.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label13.Name = "label13";
		componentResourceManager.ApplyResources(this.chkPrintCancelled, "chkPrintCancelled");
		this.chkPrintCancelled.Name = "chkPrintCancelled";
		this.chkPrintCancelled.Tag = "print_chit_change_cancel";
		this.chkPrintCancelled.ThumbTickness = 27;
		this.chkPrintCancelled.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkPrintCancelled.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintCancelled.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintCancelled.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintCancelled.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintCancelled.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintCancelled.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintCancelled.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintCancelled.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.label14, "label14");
		this.label14.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label14.Name = "label14";
		this.label14.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox8, "pictureBox8");
		this.pictureBox8.Name = "pictureBox8";
		this.pictureBox8.TabStop = false;
		this.label15.BackColor = System.Drawing.Color.Transparent;
		this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label15, "label15");
		this.label15.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label15.Name = "label15";
		componentResourceManager.ApplyResources(this.label16, "label16");
		this.label16.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.label16.ForeColor = System.Drawing.Color.White;
		this.label16.Name = "label16";
		componentResourceManager.ApplyResources(this.lblChangePrintStationSetting, "lblChangePrintStationSetting");
		this.lblChangePrintStationSetting.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblChangePrintStationSetting.Name = "lblChangePrintStationSetting";
		this.lblChangePrintStationSetting.Click += new System.EventHandler(lblChangePrintStationSetting_Click);
		componentResourceManager.ApplyResources(this.chkPrintChitClockOut, "chkPrintChitClockOut");
		this.chkPrintChitClockOut.Name = "chkPrintChitClockOut";
		this.chkPrintChitClockOut.Tag = "print_clock_out";
		this.chkPrintChitClockOut.ThumbTickness = 27;
		this.chkPrintChitClockOut.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkPrintChitClockOut.Value = false;
		this.chkPrintChitClockOut.ValueChanged += new System.EventHandler(chkPrintChitClockOut_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintChitClockOut.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintChitClockOut.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintChitClockOut.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintChitClockOut.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintChitClockOut.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintChitClockOut.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintChitClockOut.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.lblPrintClockout2, "lblPrintClockout2");
		this.lblPrintClockout2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblPrintClockout2.Name = "lblPrintClockout2";
		this.lblPrintClockout2.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		this.lblPrintClockout.BackColor = System.Drawing.Color.Transparent;
		this.lblPrintClockout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.lblPrintClockout, "lblPrintClockout");
		this.lblPrintClockout.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblPrintClockout.Name = "lblPrintClockout";
		this.pnlTimeAttendance.Controls.Add(this.pictureBox11);
		this.pnlTimeAttendance.Controls.Add(this.chkPrintEoDClockOut);
		this.pnlTimeAttendance.Controls.Add(this.label18);
		this.pnlTimeAttendance.Controls.Add(this.label19);
		this.pnlTimeAttendance.Controls.Add(this.pictureBox1);
		this.pnlTimeAttendance.Controls.Add(this.chkPrintChitClockOut);
		this.pnlTimeAttendance.Controls.Add(this.lblPrintClockout);
		this.pnlTimeAttendance.Controls.Add(this.lblPrintClockout2);
		componentResourceManager.ApplyResources(this.pnlTimeAttendance, "pnlTimeAttendance");
		this.pnlTimeAttendance.Name = "pnlTimeAttendance";
		componentResourceManager.ApplyResources(this.chkAutoPrintMerchant, "chkAutoPrintMerchant");
		this.chkAutoPrintMerchant.Name = "chkAutoPrintMerchant";
		this.chkAutoPrintMerchant.Tag = "print_merchant_copy";
		this.chkAutoPrintMerchant.ThumbTickness = 27;
		this.chkAutoPrintMerchant.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkAutoPrintMerchant.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintMerchant.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintMerchant.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkAutoPrintMerchant.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintMerchant.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintMerchant.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintMerchant.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkAutoPrintMerchant.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.lblPrintMerchantDesc, "lblPrintMerchantDesc");
		this.lblPrintMerchantDesc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblPrintMerchantDesc.Name = "lblPrintMerchantDesc";
		this.lblPrintMerchantDesc.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox2, "pictureBox2");
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.TabStop = false;
		this.lblPrintMerchant.BackColor = System.Drawing.Color.Transparent;
		this.lblPrintMerchant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.lblPrintMerchant, "lblPrintMerchant");
		this.lblPrintMerchant.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblPrintMerchant.Name = "lblPrintMerchant";
		componentResourceManager.ApplyResources(this.lblConfigureDayEndClosingSettings, "lblConfigureDayEndClosingSettings");
		this.lblConfigureDayEndClosingSettings.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblConfigureDayEndClosingSettings.Name = "lblConfigureDayEndClosingSettings";
		this.lblConfigureDayEndClosingSettings.Click += new System.EventHandler(lblConfigureDayEndClosingSettings_Click);
		componentResourceManager.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label2.Name = "label2";
		this.label2.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox5, "pictureBox5");
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.TabStop = false;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label3, "label3");
		this.label3.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label3.Name = "label3";
		componentResourceManager.ApplyResources(this.btnAutoPrintOrderTicket, "btnAutoPrintOrderTicket");
		this.btnAutoPrintOrderTicket.Name = "btnAutoPrintOrderTicket";
		this.btnAutoPrintOrderTicket.Tag = "print_orderticket";
		this.btnAutoPrintOrderTicket.ThumbTickness = 27;
		this.btnAutoPrintOrderTicket.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.btnAutoPrintOrderTicket.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.btnAutoPrintOrderTicket.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.btnAutoPrintOrderTicket.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.btnAutoPrintOrderTicket.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.btnAutoPrintOrderTicket.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.btnAutoPrintOrderTicket.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.btnAutoPrintOrderTicket.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.btnAutoPrintOrderTicket.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.lblOrderTicketDesc, "lblOrderTicketDesc");
		this.lblOrderTicketDesc.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblOrderTicketDesc.Name = "lblOrderTicketDesc";
		this.lblOrderTicketDesc.Tag = "";
		this.lblOrderTicketTitle.BackColor = System.Drawing.Color.Transparent;
		this.lblOrderTicketTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.lblOrderTicketTitle, "lblOrderTicketTitle");
		this.lblOrderTicketTitle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.lblOrderTicketTitle.Name = "lblOrderTicketTitle";
		componentResourceManager.ApplyResources(this.lblManageTickets, "lblManageTickets");
		this.lblManageTickets.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblManageTickets.Name = "lblManageTickets";
		this.lblManageTickets.Click += new System.EventHandler(lblManageTickets_Click);
		componentResourceManager.ApplyResources(this.pictureBox10, "pictureBox10");
		this.pictureBox10.Name = "pictureBox10";
		this.pictureBox10.TabStop = false;
		componentResourceManager.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label1.Name = "label1";
		this.label1.Tag = "";
		componentResourceManager.ApplyResources(this.chkOrderTickets, "chkOrderTickets");
		this.chkOrderTickets.Name = "chkOrderTickets";
		this.chkOrderTickets.Tag = "use_order_ticket";
		this.chkOrderTickets.ThumbTickness = 27;
		this.chkOrderTickets.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkOrderTickets.Value = false;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOrderTickets.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOrderTickets.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOrderTickets.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOrderTickets.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOrderTickets.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOrderTickets.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOrderTickets.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label4, "label4");
		this.label4.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label4.Name = "label4";
		this.pnlOrderTicket.Controls.Add(this.lblOrderTicketTitle);
		this.pnlOrderTicket.Controls.Add(this.lblManageTickets);
		this.pnlOrderTicket.Controls.Add(this.lblOrderTicketDesc);
		this.pnlOrderTicket.Controls.Add(this.btnAutoPrintOrderTicket);
		componentResourceManager.ApplyResources(this.pnlOrderTicket, "pnlOrderTicket");
		this.pnlOrderTicket.Name = "pnlOrderTicket";
		componentResourceManager.ApplyResources(this.chkOneChitPerTable, "chkOneChitPerTable");
		this.chkOneChitPerTable.Name = "chkOneChitPerTable";
		this.chkOneChitPerTable.Tag = "group_chits_per_table";
		this.chkOneChitPerTable.ThumbTickness = 27;
		this.chkOneChitPerTable.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkOneChitPerTable.Value = false;
		this.chkOneChitPerTable.ValueChanged += new System.EventHandler(chkOneChitPerTable_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOneChitPerTable.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOneChitPerTable.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkOneChitPerTable.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOneChitPerTable.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOneChitPerTable.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOneChitPerTable.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkOneChitPerTable.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this.label10, "label10");
		this.label10.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label10.Name = "label10";
		this.label10.Tag = "";
		componentResourceManager.ApplyResources(this.pictureBox9, "pictureBox9");
		this.pictureBox9.Name = "pictureBox9";
		this.pictureBox9.TabStop = false;
		this.label17.BackColor = System.Drawing.Color.Transparent;
		this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label17, "label17");
		this.label17.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label17.Name = "label17";
		this.ddlChitPrintServer.BackColor = System.Drawing.Color.White;
		this.ddlChitPrintServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.ddlChitPrintServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(this.ddlChitPrintServer, "ddlChitPrintServer");
		this.ddlChitPrintServer.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.ddlChitPrintServer.FormattingEnabled = true;
		this.ddlChitPrintServer.Name = "ddlChitPrintServer";
		this.ddlChitPrintServer.Tag = "chit_print_server";
		this.ddlChitPrintServer.SelectedIndexChanged += new System.EventHandler(ddlChitPrintServer_SelectedIndexChanged);
		this.pnlFullService.Controls.Add(this.chkOneChitPerTable);
		this.pnlFullService.Controls.Add(this.label17);
		this.pnlFullService.Controls.Add(this.pictureBox9);
		this.pnlFullService.Controls.Add(this.label10);
		componentResourceManager.ApplyResources(this.pnlFullService, "pnlFullService");
		this.pnlFullService.Name = "pnlFullService";
		componentResourceManager.ApplyResources(this.pictureBox11, "pictureBox11");
		this.pictureBox11.Name = "pictureBox11";
		this.pictureBox11.TabStop = false;
		componentResourceManager.ApplyResources(this.chkPrintEoDClockOut, "chkPrintEoDClockOut");
		this.chkPrintEoDClockOut.Name = "chkPrintEoDClockOut";
		this.chkPrintEoDClockOut.Tag = "print_eod_clock_out";
		this.chkPrintEoDClockOut.ThumbTickness = 27;
		this.chkPrintEoDClockOut.ToggleStateMode = Telerik.WinControls.UI.ToggleStateMode.Click;
		this.chkPrintEoDClockOut.Value = false;
		this.chkPrintEoDClockOut.ValueChanged += new System.EventHandler(chkPrintEoDClockOut_ValueChanged);
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintEoDClockOut.GetChildAt(0)).ThumbTickness = 27;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintEoDClockOut.GetChildAt(0)).ThumbOffset = 0;
		((Telerik.WinControls.UI.RadToggleSwitchElement)this.chkPrintEoDClockOut.GetChildAt(0)).BorderWidth = 1.333333f;
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintEoDClockOut.GetChildAt(0).GetChildAt(0)).BackColor2 = System.Drawing.Color.FromArgb(247, 192, 82);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintEoDClockOut.GetChildAt(0).GetChildAt(0)).BackColor3 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintEoDClockOut.GetChildAt(0).GetChildAt(0)).BackColor4 = System.Drawing.Color.FromArgb(242, 182, 51);
		((Telerik.WinControls.UI.ToggleSwitchPartElement)this.chkPrintEoDClockOut.GetChildAt(0).GetChildAt(0)).BackColor = System.Drawing.Color.FromArgb(247, 192, 82);
		this.label18.BackColor = System.Drawing.Color.Transparent;
		this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.label18, "label18");
		this.label18.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label18.Name = "label18";
		componentResourceManager.ApplyResources(this.label19, "label19");
		this.label19.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
		this.label19.Name = "label19";
		this.label19.Tag = "";
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.Controls.Add(this.pnlFullService);
		base.Controls.Add(this.pictureBox10);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.chkOrderTickets);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.lblConfigureDayEndClosingSettings);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.chkAutoPrintMerchant);
		base.Controls.Add(this.lblPrintMerchantDesc);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.lblPrintMerchant);
		base.Controls.Add(this.pnlTimeAttendance);
		base.Controls.Add(this.lblChangePrintStationSetting);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.chkPrintCancelled);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.pictureBox8);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.ddlChitPrintServer);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.chkAutoPrintOnCashout);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.lblDefaultPrinter);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.pnlOrderTicket);
		base.Name = "PrintSettings";
		componentResourceManager.ApplyResources(this, "$this");
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkAutoPrintOnCashout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintCancelled).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintChitClockOut).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.pnlTimeAttendance.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkAutoPrintMerchant).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnAutoPrintOrderTicket).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkOrderTickets).EndInit();
		this.pnlOrderTicket.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkOneChitPerTable).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox9).EndInit();
		this.pnlFullService.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintEoDClockOut).EndInit();
		base.ResumeLayout(false);
	}
}
