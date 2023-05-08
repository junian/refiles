using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.AdminPanel.Settings;

namespace CorePOS;

public class frmSettings : Form
{
	private IContainer icontainer_0;

	private Panel panel1;

	internal Button btnOrderEntrySettings;

	internal Button btnPrinterSettings;

	internal Button btnReceiptSettings;

	internal Button btnMiscSettings;

	internal Button btnCloudSyncSettings;

	internal Button btnWorkFlowSettings;

	internal Button btnPaymentSettings;

	internal Button btnStyleSettings;

	private FlowLayoutPanel pnlArrows;

	internal Button btnPageUp;

	internal Button btnUp;

	internal Button btnDown;

	internal Button btnPageDown;

	public frmSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent();
		new FormHelper().ResizeButtonFonts(this);
		panel1.Height = pnlArrows.Height;
		method_0();
	}

	private void frmSettings_Load(object sender, EventArgs e)
	{
		panel1.Controls.Add(new CloudSyncSettings());
	}

	private void method_0()
	{
		int num = (int)Math.Round(Convert.ToDecimal((Convert.ToDecimal(base.Height) - 4m - 7m) / 8m), 0);
		foreach (Control control in base.Controls)
		{
			if (control.Name.Contains("btn"))
			{
				control.Height = num;
			}
		}
	}

	private void btnPageUp_Click(object sender, EventArgs e)
	{
		panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
		panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		try
		{
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value - panel1.Height / 5;
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value - panel1.Height / 5;
		}
		catch
		{
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		try
		{
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value + panel1.Height / 5;
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value + panel1.Height / 5;
		}
		catch
		{
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
		}
	}

	private void btnPageDown_Click(object sender, EventArgs e)
	{
		panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
		panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
	}

	private void btnCloudSyncSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new CloudSyncSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnOrderEntrySettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new OrderEntrySettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnReceiptSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new ReceiptSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnPrinterSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new PrintSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnMiscSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new MiscSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnPaymentSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new PaymentSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnWorkFlowSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new WorkFlowSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
	}

	private void btnStyleSettings_Click(object sender, EventArgs e)
	{
		panel1.Controls.Clear();
		panel1.Controls.Add(new StyleSettings());
		ControlHelpers.ToggleSwitchLanguageChange(this);
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
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.frmSettings));
		this.panel1 = new System.Windows.Forms.Panel();
		this.btnOrderEntrySettings = new System.Windows.Forms.Button();
		this.btnPrinterSettings = new System.Windows.Forms.Button();
		this.btnReceiptSettings = new System.Windows.Forms.Button();
		this.btnMiscSettings = new System.Windows.Forms.Button();
		this.btnCloudSyncSettings = new System.Windows.Forms.Button();
		this.btnWorkFlowSettings = new System.Windows.Forms.Button();
		this.btnPaymentSettings = new System.Windows.Forms.Button();
		this.btnStyleSettings = new System.Windows.Forms.Button();
		this.pnlArrows = new System.Windows.Forms.FlowLayoutPanel();
		this.btnPageUp = new System.Windows.Forms.Button();
		this.btnUp = new System.Windows.Forms.Button();
		this.btnDown = new System.Windows.Forms.Button();
		this.btnPageDown = new System.Windows.Forms.Button();
		this.pnlArrows.SuspendLayout();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.panel1, "panel1");
		this.panel1.Name = "panel1";
		componentResourceManager.ApplyResources(this.btnOrderEntrySettings, "btnOrderEntrySettings");
		this.btnOrderEntrySettings.BackColor = System.Drawing.Color.FromArgb(80, 203, 116);
		this.btnOrderEntrySettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnOrderEntrySettings.FlatAppearance.BorderSize = 0;
		this.btnOrderEntrySettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnOrderEntrySettings.ForeColor = System.Drawing.Color.White;
		this.btnOrderEntrySettings.Name = "btnOrderEntrySettings";
		this.btnOrderEntrySettings.UseVisualStyleBackColor = false;
		this.btnOrderEntrySettings.Click += new System.EventHandler(btnOrderEntrySettings_Click);
		componentResourceManager.ApplyResources(this.btnPrinterSettings, "btnPrinterSettings");
		this.btnPrinterSettings.BackColor = System.Drawing.Color.FromArgb(214, 142, 81);
		this.btnPrinterSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPrinterSettings.FlatAppearance.BorderSize = 0;
		this.btnPrinterSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnPrinterSettings.ForeColor = System.Drawing.Color.White;
		this.btnPrinterSettings.Name = "btnPrinterSettings";
		this.btnPrinterSettings.UseVisualStyleBackColor = false;
		this.btnPrinterSettings.Click += new System.EventHandler(btnPrinterSettings_Click);
		componentResourceManager.ApplyResources(this.btnReceiptSettings, "btnReceiptSettings");
		this.btnReceiptSettings.BackColor = System.Drawing.Color.SandyBrown;
		this.btnReceiptSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnReceiptSettings.FlatAppearance.BorderSize = 0;
		this.btnReceiptSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnReceiptSettings.ForeColor = System.Drawing.Color.White;
		this.btnReceiptSettings.Name = "btnReceiptSettings";
		this.btnReceiptSettings.UseVisualStyleBackColor = false;
		this.btnReceiptSettings.Click += new System.EventHandler(btnReceiptSettings_Click);
		componentResourceManager.ApplyResources(this.btnMiscSettings, "btnMiscSettings");
		this.btnMiscSettings.BackColor = System.Drawing.Color.FromArgb(147, 101, 184);
		this.btnMiscSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnMiscSettings.FlatAppearance.BorderSize = 0;
		this.btnMiscSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnMiscSettings.ForeColor = System.Drawing.Color.White;
		this.btnMiscSettings.Name = "btnMiscSettings";
		this.btnMiscSettings.UseVisualStyleBackColor = false;
		this.btnMiscSettings.Click += new System.EventHandler(btnMiscSettings_Click);
		componentResourceManager.ApplyResources(this.btnCloudSyncSettings, "btnCloudSyncSettings");
		this.btnCloudSyncSettings.BackColor = System.Drawing.Color.FromArgb(77, 174, 225);
		this.btnCloudSyncSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnCloudSyncSettings.FlatAppearance.BorderSize = 0;
		this.btnCloudSyncSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnCloudSyncSettings.ForeColor = System.Drawing.Color.White;
		this.btnCloudSyncSettings.Name = "btnCloudSyncSettings";
		this.btnCloudSyncSettings.UseVisualStyleBackColor = false;
		this.btnCloudSyncSettings.Click += new System.EventHandler(btnCloudSyncSettings_Click);
		componentResourceManager.ApplyResources(this.btnWorkFlowSettings, "btnWorkFlowSettings");
		this.btnWorkFlowSettings.BackColor = System.Drawing.Color.FromArgb(61, 142, 185);
		this.btnWorkFlowSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnWorkFlowSettings.FlatAppearance.BorderSize = 0;
		this.btnWorkFlowSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnWorkFlowSettings.ForeColor = System.Drawing.Color.White;
		this.btnWorkFlowSettings.Name = "btnWorkFlowSettings";
		this.btnWorkFlowSettings.UseVisualStyleBackColor = false;
		this.btnWorkFlowSettings.Click += new System.EventHandler(btnWorkFlowSettings_Click);
		componentResourceManager.ApplyResources(this.btnPaymentSettings, "btnPaymentSettings");
		this.btnPaymentSettings.BackColor = System.Drawing.Color.FromArgb(176, 124, 219);
		this.btnPaymentSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPaymentSettings.FlatAppearance.BorderSize = 0;
		this.btnPaymentSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnPaymentSettings.ForeColor = System.Drawing.Color.White;
		this.btnPaymentSettings.Name = "btnPaymentSettings";
		this.btnPaymentSettings.UseVisualStyleBackColor = false;
		this.btnPaymentSettings.Click += new System.EventHandler(btnPaymentSettings_Click);
		componentResourceManager.ApplyResources(this.btnStyleSettings, "btnStyleSettings");
		this.btnStyleSettings.BackColor = System.Drawing.Color.FromArgb(65, 168, 95);
		this.btnStyleSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnStyleSettings.FlatAppearance.BorderSize = 0;
		this.btnStyleSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
		this.btnStyleSettings.ForeColor = System.Drawing.Color.White;
		this.btnStyleSettings.Name = "btnStyleSettings";
		this.btnStyleSettings.UseVisualStyleBackColor = false;
		this.btnStyleSettings.Click += new System.EventHandler(btnStyleSettings_Click);
		componentResourceManager.ApplyResources(this.pnlArrows, "pnlArrows");
		this.pnlArrows.BackColor = System.Drawing.Color.Transparent;
		this.pnlArrows.Controls.Add(this.btnPageUp);
		this.pnlArrows.Controls.Add(this.btnUp);
		this.pnlArrows.Controls.Add(this.btnDown);
		this.pnlArrows.Controls.Add(this.btnPageDown);
		this.pnlArrows.Name = "pnlArrows";
		componentResourceManager.ApplyResources(this.btnPageUp, "btnPageUp");
		this.btnPageUp.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnPageUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPageUp.FlatAppearance.BorderSize = 0;
		this.btnPageUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnPageUp.ForeColor = System.Drawing.Color.White;
		this.btnPageUp.Name = "btnPageUp";
		this.btnPageUp.UseVisualStyleBackColor = false;
		this.btnPageUp.Click += new System.EventHandler(btnPageUp_Click);
		componentResourceManager.ApplyResources(this.btnUp, "btnUp");
		this.btnUp.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnUp.FlatAppearance.BorderSize = 0;
		this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnUp.ForeColor = System.Drawing.Color.White;
		this.btnUp.Name = "btnUp";
		this.btnUp.UseVisualStyleBackColor = false;
		this.btnUp.Click += new System.EventHandler(btnUp_Click);
		componentResourceManager.ApplyResources(this.btnDown, "btnDown");
		this.btnDown.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnDown.FlatAppearance.BorderSize = 0;
		this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnDown.ForeColor = System.Drawing.Color.White;
		this.btnDown.Name = "btnDown";
		this.btnDown.UseVisualStyleBackColor = false;
		this.btnDown.Click += new System.EventHandler(btnDown_Click);
		componentResourceManager.ApplyResources(this.btnPageDown, "btnPageDown");
		this.btnPageDown.BackColor = System.Drawing.Color.FromArgb(53, 152, 220);
		this.btnPageDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.btnPageDown.FlatAppearance.BorderSize = 0;
		this.btnPageDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
		this.btnPageDown.ForeColor = System.Drawing.Color.White;
		this.btnPageDown.Name = "btnPageDown";
		this.btnPageDown.UseVisualStyleBackColor = false;
		this.btnPageDown.Click += new System.EventHandler(btnPageDown_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		componentResourceManager.ApplyResources(this, "$this");
		base.Controls.Add(this.pnlArrows);
		base.Controls.Add(this.btnWorkFlowSettings);
		base.Controls.Add(this.btnPaymentSettings);
		base.Controls.Add(this.btnStyleSettings);
		base.Controls.Add(this.btnOrderEntrySettings);
		base.Controls.Add(this.btnPrinterSettings);
		base.Controls.Add(this.btnReceiptSettings);
		base.Controls.Add(this.btnMiscSettings);
		base.Controls.Add(this.btnCloudSyncSettings);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSettings";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Load += new System.EventHandler(frmSettings_Load);
		this.pnlArrows.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
