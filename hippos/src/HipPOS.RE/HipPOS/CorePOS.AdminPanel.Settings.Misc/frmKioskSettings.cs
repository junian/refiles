using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;

namespace CorePOS.AdminPanel.Settings.Misc;

public class frmKioskSettings : frmMasterForm
{
	private KioskSettingsHeaderControl kioskSettingsHeaderControl_0;

	private GClass6 gclass6_0;

	private List<Terminal> list_2;

	private IContainer icontainer_1;

	internal Button btnAddToUnit;

	private Label label3;

	private FlowLayoutPanel pnlKioskSetups;

	internal Button btnClose;

	internal Button btnSave;

	public frmKioskSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		kioskSettingsHeaderControl_0 = new KioskSettingsHeaderControl();
		gclass6_0 = new GClass6();
		// base._002Ector();
		InitializeComponent_1();
	}

	private void frmKioskSettings_Load(object sender, EventArgs e)
	{
		pnlKioskSetups.Controls.Add(kioskSettingsHeaderControl_0);
		list_2 = gclass6_0.Terminals.Where((Terminal x) => x.OperatingMode == "Kiosk" && x.Status == TerminalStatus.active).ToList();
		foreach (Terminal item in list_2)
		{
			pnlKioskSetups.Controls.Add(new KioskSettingsItemControl(this, item, gclass6_0));
		}
	}

	private void btnAddToUnit_Click(object sender, EventArgs e)
	{
		pnlKioskSetups.Controls.Add(new KioskSettingsItemControl(this, null, gclass6_0));
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		foreach (Terminal item in gclass6_0.Terminals.Where((Terminal x) => x.OperatingMode == "Kiosk" && x.Status == "active").ToList())
		{
			item.Status = "inactive";
		}
		foreach (Control control in pnlKioskSetups.Controls)
		{
			try
			{
				((KioskSettingsItemControl)control).Save();
			}
			catch
			{
			}
		}
		gclass6_0.SubmitChanges();
		new NotificationLabel(this, "Saved.", NotificationTypes.Success).Show();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		ControlHelpers.ClearControlsInForm(this);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmKioskSettings));
		btnAddToUnit = new Button();
		label3 = new Label();
		pnlKioskSetups = new FlowLayoutPanel();
		btnClose = new Button();
		btnSave = new Button();
		SuspendLayout();
		btnAddToUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnAddToUnit.BackColor = Color.FromArgb(147, 101, 184);
		btnAddToUnit.FlatAppearance.BorderColor = Color.White;
		btnAddToUnit.FlatAppearance.BorderSize = 0;
		btnAddToUnit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnAddToUnit.FlatStyle = FlatStyle.Flat;
		btnAddToUnit.Font = new Font("Microsoft Sans Serif", 10f);
		btnAddToUnit.ForeColor = Color.White;
		btnAddToUnit.Image = (Image)componentResourceManager.GetObject("btnAddToUnit.Image");
		btnAddToUnit.ImeMode = ImeMode.NoControl;
		btnAddToUnit.Location = new Point(805, 12);
		btnAddToUnit.Name = "btnAddToUnit";
		btnAddToUnit.Padding = new Padding(5, 0, 5, 0);
		btnAddToUnit.Size = new Size(44, 35);
		btnAddToUnit.TabIndex = 247;
		btnAddToUnit.TextAlign = ContentAlignment.MiddleRight;
		btnAddToUnit.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnAddToUnit.UseVisualStyleBackColor = false;
		btnAddToUnit.Click += btnAddToUnit_Click;
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.BackColor = Color.FromArgb(147, 101, 184);
		label3.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(8, 9);
		label3.Name = "label3";
		label3.Size = new Size(843, 43);
		label3.TabIndex = 244;
		label3.Text = "KIOSK TERMINAL SETUP";
		label3.TextAlign = ContentAlignment.MiddleCenter;
		pnlKioskSetups.AccessibleName = "";
		pnlKioskSetups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		pnlKioskSetups.AutoScroll = true;
		pnlKioskSetups.AutoScrollMargin = new Size(10, 0);
		pnlKioskSetups.Font = new Font("Microsoft Sans Serif", 10f);
		pnlKioskSetups.Location = new Point(8, 51);
		pnlKioskSetups.Margin = new Padding(0, 0, 20, 0);
		pnlKioskSetups.Name = "pnlKioskSetups";
		pnlKioskSetups.Padding = new Padding(0, 0, 20, 0);
		pnlKioskSetups.Size = new Size(843, 471);
		pnlKioskSetups.TabIndex = 250;
		btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.Sienna;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.White;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 10f);
		btnClose.ForeColor = Color.White;
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(705, 528);
		btnClose.MinimumSize = new Size(121, 60);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(146, 75);
		btnClose.TabIndex = 252;
		btnClose.Text = "CLOSE";
		btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btnSave.BackColor = Color.FromArgb(65, 168, 95);
		btnSave.FlatAppearance.BorderColor = Color.Black;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.White;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 10f);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(558, 528);
		btnSave.MinimumSize = new Size(121, 60);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(146, 75);
		btnSave.TabIndex = 251;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(859, 611);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnSave);
		base.Controls.Add(pnlKioskSetups);
		base.Controls.Add(btnAddToUnit);
		base.Controls.Add(label3);
		base.Name = "frmKioskSettings";
		base.Opacity = 1.0;
		Text = "frmKioskSettings";
		base.Load += frmKioskSettings_Load;
		ResumeLayout(performLayout: false);
	}
}
