using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CorePOS.CommonForms;

public class frmFontSize : frmMasterForm
{
	[CompilerGenerated]
	private int int_0;

	private IContainer icontainer_1;

	private Panel panel1;

	private Label lblTitle;

	private PictureBox pb11;

	private Button btn16;

	private PictureBox pb16;

	private Button btn15;

	private PictureBox pb15;

	private Button btn14;

	private PictureBox pb14;

	private Button btn13;

	private PictureBox pb13;

	private Button btn12;

	private PictureBox pb12;

	private Button btn11;

	private PictureBox pbCheck;

	private PictureBox pictureBox1;

	private Button btn8;

	private PictureBox pb8;

	private Button btn9;

	private PictureBox pb9;

	private Button btn10;

	private PictureBox pb10;

	private Button btn7;

	private PictureBox pb7;

	private Button btn6;

	private PictureBox pb6;

	public int FontSize
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public frmFontSize(int _size)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		pbCheck.Visible = false;
		FontSize = _size;
		switch (_size)
		{
		case 6:
			method_3(pb6, btn6);
			break;
		case 7:
			method_3(pb7, btn7);
			break;
		case 8:
			method_3(pb8, btn8);
			break;
		case 9:
			method_3(pb9, btn9);
			break;
		case 10:
			method_3(pb10, btn10);
			break;
		case 11:
			method_3(pb11, btn11);
			break;
		case 12:
			method_3(pb12, btn12);
			break;
		case 13:
			method_3(pb13, btn13);
			break;
		case 14:
			method_3(pb14, btn14);
			break;
		case 15:
			method_3(pb15, btn15);
			break;
		case 16:
			method_3(pb16, btn16);
			break;
		}
	}

	private void method_3(PictureBox pictureBox_0, Button button_0)
	{
		pictureBox_0.Image = pbCheck.Image;
		button_0.BackColor = Color.FromArgb(80, 203, 116);
		if (pb6.Name != pictureBox_0.Name)
		{
			pb6.Image = null;
			btn6.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb7.Name != pictureBox_0.Name)
		{
			pb7.Image = null;
			btn7.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb8.Name != pictureBox_0.Name)
		{
			pb8.Image = null;
			btn8.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb9.Name != pictureBox_0.Name)
		{
			pb9.Image = null;
			btn9.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb10.Name != pictureBox_0.Name)
		{
			pb10.Image = null;
			btn10.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb11.Name != pictureBox_0.Name)
		{
			pb11.Image = null;
			btn11.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb12.Name != pictureBox_0.Name)
		{
			pb12.Image = null;
			btn12.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb13.Name != pictureBox_0.Name)
		{
			pb13.Image = null;
			btn13.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb14.Name != pictureBox_0.Name)
		{
			pb14.Image = null;
			btn14.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb15.Name != pictureBox_0.Name)
		{
			pb15.Image = null;
			btn15.BackColor = Color.FromArgb(235, 107, 86);
		}
		if (pb16.Name != pictureBox_0.Name)
		{
			pb16.Image = null;
			btn16.BackColor = Color.FromArgb(235, 107, 86);
		}
	}

	private void btn11_Click(object sender, EventArgs e)
	{
		method_3(pb11, btn11);
		FontSize = 11;
	}

	private void btn12_Click(object sender, EventArgs e)
	{
		method_3(pb12, btn12);
		FontSize = 12;
	}

	private void btn13_Click(object sender, EventArgs e)
	{
		method_3(pb13, btn13);
		FontSize = 13;
	}

	private void btn14_Click(object sender, EventArgs e)
	{
		method_3(pb14, btn14);
		FontSize = 14;
	}

	private void btn15_Click(object sender, EventArgs e)
	{
		method_3(pb15, btn15);
		FontSize = 15;
	}

	private void btn16_Click(object sender, EventArgs e)
	{
		method_3(pb16, btn16);
		FontSize = 16;
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btn10_Click(object sender, EventArgs e)
	{
		method_3(pb10, btn10);
		FontSize = 10;
	}

	private void btn9_Click(object sender, EventArgs e)
	{
		method_3(pb9, btn9);
		FontSize = 9;
	}

	private void btn8_Click(object sender, EventArgs e)
	{
		method_3(pb8, btn8);
		FontSize = 8;
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void btn7_Click(object sender, EventArgs e)
	{
		method_3(pb7, btn7);
		FontSize = 7;
	}

	private void btn6_Click(object sender, EventArgs e)
	{
		method_3(pb6, btn6);
		FontSize = 6;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmFontSize));
		panel1 = new Panel();
		btn6 = new Button();
		pb6 = new PictureBox();
		btn7 = new Button();
		pb7 = new PictureBox();
		btn8 = new Button();
		pb8 = new PictureBox();
		btn9 = new Button();
		pb9 = new PictureBox();
		btn10 = new Button();
		pb10 = new PictureBox();
		pictureBox1 = new PictureBox();
		pbCheck = new PictureBox();
		btn16 = new Button();
		pb16 = new PictureBox();
		btn15 = new Button();
		pb15 = new PictureBox();
		btn14 = new Button();
		pb14 = new PictureBox();
		btn13 = new Button();
		pb13 = new PictureBox();
		btn12 = new Button();
		pb12 = new PictureBox();
		btn11 = new Button();
		pb11 = new PictureBox();
		lblTitle = new Label();
		panel1.SuspendLayout();
		((ISupportInitialize)pb6).BeginInit();
		((ISupportInitialize)pb7).BeginInit();
		((ISupportInitialize)pb8).BeginInit();
		((ISupportInitialize)pb9).BeginInit();
		((ISupportInitialize)pb10).BeginInit();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)pbCheck).BeginInit();
		((ISupportInitialize)pb16).BeginInit();
		((ISupportInitialize)pb15).BeginInit();
		((ISupportInitialize)pb14).BeginInit();
		((ISupportInitialize)pb13).BeginInit();
		((ISupportInitialize)pb12).BeginInit();
		((ISupportInitialize)pb11).BeginInit();
		SuspendLayout();
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(btn6);
		panel1.Controls.Add(pb6);
		panel1.Controls.Add(btn7);
		panel1.Controls.Add(pb7);
		panel1.Controls.Add(btn8);
		panel1.Controls.Add(pb8);
		panel1.Controls.Add(btn9);
		panel1.Controls.Add(pb9);
		panel1.Controls.Add(btn10);
		panel1.Controls.Add(pb10);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(pbCheck);
		panel1.Controls.Add(btn16);
		panel1.Controls.Add(pb16);
		panel1.Controls.Add(btn15);
		panel1.Controls.Add(pb15);
		panel1.Controls.Add(btn14);
		panel1.Controls.Add(pb14);
		panel1.Controls.Add(btn13);
		panel1.Controls.Add(pb13);
		panel1.Controls.Add(btn12);
		panel1.Controls.Add(pb12);
		panel1.Controls.Add(btn11);
		panel1.Controls.Add(pb11);
		panel1.Controls.Add(lblTitle);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		panel1.Paint += panel1_Paint;
		btn6.BackColor = Color.FromArgb(235, 107, 86);
		btn6.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn6, "btn6");
		btn6.ForeColor = SystemColors.ButtonFace;
		btn6.Name = "btn6";
		btn6.UseVisualStyleBackColor = false;
		btn6.Click += btn6_Click;
		componentResourceManager.ApplyResources(pb6, "pb6");
		pb6.Name = "pb6";
		pb6.TabStop = false;
		btn7.BackColor = Color.FromArgb(235, 107, 86);
		btn7.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn7, "btn7");
		btn7.ForeColor = SystemColors.ButtonFace;
		btn7.Name = "btn7";
		btn7.UseVisualStyleBackColor = false;
		btn7.Click += btn7_Click;
		componentResourceManager.ApplyResources(pb7, "pb7");
		pb7.Name = "pb7";
		pb7.TabStop = false;
		btn8.BackColor = Color.FromArgb(235, 107, 86);
		btn8.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn8, "btn8");
		btn8.ForeColor = SystemColors.ButtonFace;
		btn8.Name = "btn8";
		btn8.UseVisualStyleBackColor = false;
		btn8.Click += btn8_Click;
		componentResourceManager.ApplyResources(pb8, "pb8");
		pb8.Name = "pb8";
		pb8.TabStop = false;
		btn9.BackColor = Color.FromArgb(235, 107, 86);
		btn9.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn9, "btn9");
		btn9.ForeColor = SystemColors.ButtonFace;
		btn9.Name = "btn9";
		btn9.UseVisualStyleBackColor = false;
		btn9.Click += btn9_Click;
		componentResourceManager.ApplyResources(pb9, "pb9");
		pb9.Name = "pb9";
		pb9.TabStop = false;
		btn10.BackColor = Color.FromArgb(235, 107, 86);
		btn10.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn10, "btn10");
		btn10.ForeColor = SystemColors.ButtonFace;
		btn10.Name = "btn10";
		btn10.UseVisualStyleBackColor = false;
		btn10.Click += btn10_Click;
		componentResourceManager.ApplyResources(pb10, "pb10");
		pb10.Name = "pb10";
		pb10.TabStop = false;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(pictureBox1, "pictureBox1");
		pictureBox1.Name = "pictureBox1";
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		componentResourceManager.ApplyResources(pbCheck, "pbCheck");
		pbCheck.Name = "pbCheck";
		pbCheck.TabStop = false;
		btn16.BackColor = Color.FromArgb(235, 107, 86);
		btn16.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn16, "btn16");
		btn16.ForeColor = SystemColors.ButtonFace;
		btn16.Name = "btn16";
		btn16.UseVisualStyleBackColor = false;
		btn16.Click += btn16_Click;
		componentResourceManager.ApplyResources(pb16, "pb16");
		pb16.Name = "pb16";
		pb16.TabStop = false;
		btn15.BackColor = Color.FromArgb(235, 107, 86);
		btn15.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn15, "btn15");
		btn15.ForeColor = SystemColors.ButtonFace;
		btn15.Name = "btn15";
		btn15.UseVisualStyleBackColor = false;
		btn15.Click += btn15_Click;
		componentResourceManager.ApplyResources(pb15, "pb15");
		pb15.Name = "pb15";
		pb15.TabStop = false;
		btn14.BackColor = Color.FromArgb(235, 107, 86);
		btn14.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn14, "btn14");
		btn14.ForeColor = SystemColors.ButtonFace;
		btn14.Name = "btn14";
		btn14.UseVisualStyleBackColor = false;
		btn14.Click += btn14_Click;
		componentResourceManager.ApplyResources(pb14, "pb14");
		pb14.Name = "pb14";
		pb14.TabStop = false;
		btn13.BackColor = Color.FromArgb(235, 107, 86);
		btn13.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn13, "btn13");
		btn13.ForeColor = SystemColors.ButtonFace;
		btn13.Name = "btn13";
		btn13.UseVisualStyleBackColor = false;
		btn13.Click += btn13_Click;
		componentResourceManager.ApplyResources(pb13, "pb13");
		pb13.Name = "pb13";
		pb13.TabStop = false;
		btn12.BackColor = Color.FromArgb(235, 107, 86);
		btn12.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn12, "btn12");
		btn12.ForeColor = SystemColors.ButtonFace;
		btn12.Name = "btn12";
		btn12.UseVisualStyleBackColor = false;
		btn12.Click += btn12_Click;
		componentResourceManager.ApplyResources(pb12, "pb12");
		pb12.Name = "pb12";
		pb12.TabStop = false;
		btn11.BackColor = Color.FromArgb(235, 107, 86);
		btn11.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btn11, "btn11");
		btn11.ForeColor = SystemColors.ButtonFace;
		btn11.Name = "btn11";
		btn11.UseVisualStyleBackColor = false;
		btn11.Click += btn11_Click;
		componentResourceManager.ApplyResources(pb11, "pb11");
		pb11.Name = "pb11";
		pb11.TabStop = false;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(panel1);
		base.Name = "frmFontSize";
		base.Opacity = 1.0;
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)pb6).EndInit();
		((ISupportInitialize)pb7).EndInit();
		((ISupportInitialize)pb8).EndInit();
		((ISupportInitialize)pb9).EndInit();
		((ISupportInitialize)pb10).EndInit();
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)pbCheck).EndInit();
		((ISupportInitialize)pb16).EndInit();
		((ISupportInitialize)pb15).EndInit();
		((ISupportInitialize)pb14).EndInit();
		((ISupportInitialize)pb13).EndInit();
		((ISupportInitialize)pb12).EndInit();
		((ISupportInitialize)pb11).EndInit();
		ResumeLayout(performLayout: false);
	}
}
