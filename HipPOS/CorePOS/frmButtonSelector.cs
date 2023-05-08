using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;

namespace CorePOS;

public class frmButtonSelector : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	private Dictionary<string, string> dictionary_0;

	private IContainer icontainer_1;

	private FlowLayoutPanel pnlMain;

	public Label lblTitle;

	private Panel panel1;

	private PictureBox btnClose;

	private VerticalScrollControl verticalScrollControl1;

	public string SelectedValue
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string SelectedDisplay
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public frmButtonSelector(string title, Dictionary<string, string> select)
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		lblTitle.Text = title;
		dictionary_0 = select;
	}

	private void frmButtonSelector_Load(object sender, EventArgs e)
	{
		if (dictionary_0.Count() <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			Button button = new Button();
			button.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Asphalt"]);
			button.FlatStyle = FlatStyle.Flat;
			button.TextAlign = ContentAlignment.MiddleCenter;
			button.FlatAppearance.BorderSize = 0;
			button.ForeColor = Color.White;
			button.Name = item.Value;
			button.TextAlign = ContentAlignment.MiddleCenter;
			button.Font = new Font(button.Font.FontFamily, 12f, FontStyle.Regular);
			button.Text = item.Value;
			button.Size = new Size(133, 96);
			button.Padding = new Padding(5, 0, 5, 0);
			button.Click += method_3;
			button.Tag = item.Key;
			pnlMain.Controls.Add(button);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (button.Tag.ToString() != "0")
		{
			SelectedValue = button.Tag.ToString();
			SelectedDisplay = button.Text;
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			base.DialogResult = DialogResult.No;
		}
		Dispose();
		Close();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmButtonSelector));
		pnlMain = new FlowLayoutPanel();
		lblTitle = new Label();
		panel1 = new Panel();
		btnClose = new PictureBox();
		verticalScrollControl1 = new VerticalScrollControl();
		panel1.SuspendLayout();
		((ISupportInitialize)btnClose).BeginInit();
		SuspendLayout();
		pnlMain.AutoScroll = true;
		pnlMain.Location = new Point(2, 44);
		pnlMain.Name = "pnlMain";
		pnlMain.Size = new Size(727, 408);
		pnlMain.TabIndex = 0;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(65, 168, 95);
		lblTitle.Font = new Font("Microsoft Sans Serif", 16f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-2, 0);
		lblTitle.Margin = new Padding(0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(758, 40);
		lblTitle.TabIndex = 49;
		lblTitle.Text = "Employee Comission: Select an Employee";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(btnClose);
		panel1.Controls.Add(verticalScrollControl1);
		panel1.Controls.Add(pnlMain);
		panel1.Controls.Add(lblTitle);
		panel1.Location = new Point(3, -3);
		panel1.Name = "panel1";
		panel1.Size = new Size(760, 457);
		panel1.TabIndex = 51;
		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.BackColor = Color.FromArgb(65, 168, 95);
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(715, 1);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(40, 37);
		btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
		btnClose.TabIndex = 236;
		btnClose.TabStop = false;
		btnClose.Click += btnClose_Click;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(703, 44);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 406);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 406);
		verticalScrollControl1.TabIndex = 213;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(766, 456);
		base.Controls.Add(panel1);
		base.Name = "frmButtonSelector";
		base.Opacity = 1.0;
		Text = "frmButtonSelector";
		base.Load += frmButtonSelector_Load;
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)btnClose).EndInit();
		ResumeLayout(performLayout: false);
	}
}
