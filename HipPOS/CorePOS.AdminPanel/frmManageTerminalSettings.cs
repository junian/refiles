using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel;

public class frmManageTerminalSettings : frmMasterForm
{
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
		CS_0024_003C_003E8__locals0.status = (chkActive.get_Value() ? "active" : "inactive");
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
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
		((Control)(object)chkActive).Location = new Point(12, 12);
		((Control)(object)chkActive).Name = "chkActive";
		chkActive.set_OffText("INACTIVE TERMINALS");
		chkActive.set_OnText("ACTIVE TERMINALS");
		((Control)(object)chkActive).Size = new Size(115, 35);
		((Control)(object)chkActive).TabIndex = 18;
		((Control)(object)chkActive).Tag = "";
		chkActive.set_ToggleStateMode((ToggleStateMode)1);
		chkActive.add_ValueChanged((EventHandler)cgkFmloNyDH);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbOffset(95);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_Text("ACTIVE TERMINALS");
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		base.Controls.Add((Control)(object)chkActive);
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
