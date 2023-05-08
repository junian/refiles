using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel;

public class frmManageTerminalSettings : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string status;

		public _003C_003Ec__DisplayClass5_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private TerminalSettingsHeaderControl terminalSettingsHeaderControl_0;

	private GClass6 gclass6_0;

	private List<Terminal> list_2;

	private IContainer icontainer_1;

	private Label label3;

	private FlowLayoutPanel pnlTerminals;

	private RadToggleSwitch chkActive;

	private PictureBox pictureBox1;

	public frmManageTerminalSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		terminalSettingsHeaderControl_0 = new TerminalSettingsHeaderControl();
		gclass6_0 = new GClass6();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageTerminalSettings_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
		pnlTerminals.Controls.Clear();
		pnlTerminals.Controls.Add(terminalSettingsHeaderControl_0);
		CS_0024_003C_003E8__locals0.status = (chkActive.Value ? "active" : "inactive");
		list_2 = gclass6_0.Terminals.Where((Terminal x) => x.OperatingMode == "Normal" && x.Status == CS_0024_003C_003E8__locals0.status).ToList();
		foreach (Terminal item in list_2)
		{
			pnlTerminals.Controls.Add(new TerminalSettingsItemControl(this, item, gclass6_0));
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		ControlHelpers.ClearControlsInForm(this);
		Dispose();
		Close();
	}

	private void cgkFmloNyDH(object sender, EventArgs e)
	{
		method_3();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageTerminalSettings));
		label3 = new Label();
		pnlTerminals = new FlowLayoutPanel();
		chkActive = new RadToggleSwitch();
		pictureBox1 = new PictureBox();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.BackColor = Color.FromArgb(156, 89, 184);
		label3.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label3.ForeColor = Color.White;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(8, 9);
		label3.Name = "label3";
		label3.Size = new Size(1008, 43);
		label3.TabIndex = 244;
		label3.Text = "TERMINAL SETUP";
		label3.TextAlign = ContentAlignment.MiddleCenter;
		pnlTerminals.AccessibleName = "";
		pnlTerminals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		pnlTerminals.AutoScroll = true;
		pnlTerminals.AutoScrollMargin = new Size(10, 0);
		pnlTerminals.Font = new Font("Microsoft Sans Serif", 10f);
		pnlTerminals.Location = new Point(8, 51);
		pnlTerminals.Margin = new Padding(0, 0, 20, 0);
		pnlTerminals.Name = "pnlTerminals";
		pnlTerminals.Padding = new Padding(0, 0, 20, 0);
		pnlTerminals.Size = new Size(1008, 708);
		pnlTerminals.TabIndex = 250;
		chkActive.Location = new Point(12, 12);
		chkActive.Name = "chkActive";
		chkActive.OffText = "INACTIVE TERMINALS";
		chkActive.OnText = "ACTIVE TERMINALS";
		chkActive.Size = new Size(115, 35);
		chkActive.TabIndex = 18;
		chkActive.Tag = "";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		chkActive.ValueChanged += cgkFmloNyDH;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 95;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = "ACTIVE TERMINALS";
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(968, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(44, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 251;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1024, 768);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(chkActive);
		base.Controls.Add(pnlTerminals);
		base.Controls.Add(label3);
		base.Name = "frmManageTerminalSettings";
		base.Opacity = 1.0;
		Text = "frmKioskSettings";
		base.Load += frmManageTerminalSettings_Load;
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
