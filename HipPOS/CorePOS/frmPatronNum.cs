using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Methods;

namespace CorePOS;

public class frmPatronNum : frmMasterForm
{
	private FormHelper formHelper_0;

	private short short_0;

	[CompilerGenerated]
	private short short_1;

	private IContainer icontainer_1;

	private Panel pnlOptions;

	private Label lblCaption;

	private PictureBox pbGuest;

	private PictureBox btnClose;

	public short seat
	{
		[CompilerGenerated]
		get
		{
			return short_1;
		}
		[CompilerGenerated]
		set
		{
			short_1 = value;
		}
	}

	public frmPatronNum(short _seat)
	{
		Class26.Ggkj0JxzN9YmC();
		formHelper_0 = new FormHelper();
		short_0 = 1;
		// base._002Ector();
		InitializeComponent_1();
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			lblCaption.Font = new Font(lblCaption.Font.FontFamily, lblCaption.Font.Size - 0.75f, FontStyle.Bold);
		}
		pbGuest.Visible = false;
		seat = _seat;
		method_3();
	}

	private void frmPatronNum_FormClosing(object sender, EventArgs e)
	{
		formHelper_0 = null;
		pnlOptions.Controls.Clear();
		foreach (Control control in base.Controls)
		{
			control.Dispose();
		}
		GC.Collect();
	}

	private void method_3()
	{
		int num = 0;
		int num2 = 0;
		int i = 1;
		int num3 = 0;
		for (int j = 3; j < 20; j++)
		{
			if (Convert.ToInt16(seat * 2) <= j * j)
			{
				num3 = j;
				int num4 = 0;
				int num5 = 0;
				switch (j)
				{
				case 3:
					num4 = -120;
					num5 = -80;
					break;
				case 4:
					num4 = 0;
					num5 = -10;
					break;
				case 5:
					num4 = 90;
					num5 = 60;
					break;
				default:
					num4 = 160 + 40 * (j - 6);
					num5 = 110 + 40 * (j - 6);
					break;
				}
				base.Width = pnlOptions.Width + num4;
				base.Height = pnlOptions.Height + num5;
				break;
			}
		}
		if (num3 == 0)
		{
			return;
		}
		for (; i <= num3 * num3; i++)
		{
			method_4(i.ToString(), num, num2, num3);
			if (num == num3 - 1)
			{
				num2++;
				num = -1;
			}
			num++;
		}
	}

	private void method_4(string string_0, int int_0, int int_1, int int_2)
	{
		Button button = new Button();
		button.Name = string_0.ToString();
		button.Text = string_0 + " x";
		button.TextAlign = ContentAlignment.MiddleLeft;
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.FlatAppearance.BorderColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.Image = pbGuest.Image;
		button.ImageAlign = ContentAlignment.MiddleRight;
		if (Convert.ToInt16(seat * 2) <= 9)
		{
			button.Padding = new Padding(25, 0, 25, 0);
			button.Font = new Font(Font.FontFamily, 20f);
		}
		else if (Convert.ToInt16(seat * 2) <= 16)
		{
			button.Padding = new Padding(15, 0, 15, 0);
			button.Font = new Font(Font.FontFamily, 18f);
		}
		else if (Convert.ToInt16(seat * 2) <= 25)
		{
			button.Padding = new Padding(10, 0, 10, 0);
			button.Font = new Font(Font.FontFamily, 16f);
		}
		else if (Convert.ToInt16(seat * 2) <= 36)
		{
			button.Padding = new Padding(7, 0, 7, 0);
			button.Font = new Font(Font.FontFamily, 16f);
		}
		else if (Convert.ToInt16(seat * 2) <= 49)
		{
			button.Padding = new Padding(5, 0, 5, 0);
			button.Font = new Font(Font.FontFamily, 14f);
		}
		if (Convert.ToInt16(string_0) <= Convert.ToInt16(seat * 2))
		{
			button.BackColor = Color.FromArgb(47, 204, 113);
		}
		else
		{
			button.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
			button.Enabled = false;
		}
		button.ForeColor = Color.White;
		int num = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlOptions.Width - 2) / (decimal)int_2));
		int num2 = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlOptions.Height - 2) / (decimal)int_2));
		button.Size = new Size(num, num2);
		button.Location = new Point(int_0 * num + (int_0 + 1) * short_0, int_1 * num2 + (int_1 + 1) * short_0);
		button.Click += method_5;
		pnlOptions.Controls.Add(button);
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void method_5(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		seat = Convert.ToInt16(button.Name);
		base.DialogResult = DialogResult.OK;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPatronNum));
		pnlOptions = new Panel();
		lblCaption = new Label();
		pbGuest = new PictureBox();
		btnClose = new PictureBox();
		((ISupportInitialize)pbGuest).BeginInit();
		((ISupportInitialize)btnClose).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlOptions, "pnlOptions");
		pnlOptions.Name = "pnlOptions";
		componentResourceManager.ApplyResources(lblCaption, "lblCaption");
		lblCaption.BackColor = Color.FromArgb(156, 89, 184);
		lblCaption.ForeColor = Color.White;
		lblCaption.Name = "lblCaption";
		componentResourceManager.ApplyResources(pbGuest, "pbGuest");
		pbGuest.Name = "pbGuest";
		pbGuest.TabStop = false;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.BackColor = Color.FromArgb(156, 89, 184);
		btnClose.Name = "btnClose";
		btnClose.TabStop = false;
		btnClose.Click += btnClose_Click;
		base.AutoScaleMode = AutoScaleMode.Inherit;
		BackColor = Color.FromArgb(35, 39, 56);
		componentResourceManager.ApplyResources(this, "$this");
		base.ControlBox = false;
		base.Controls.Add(btnClose);
		base.Controls.Add(pbGuest);
		base.Controls.Add(lblCaption);
		base.Controls.Add(pnlOptions);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmPatronNum";
		base.Opacity = 1.0;
		base.ShowInTaskbar = false;
		base.FormClosing += frmPatronNum_FormClosing;
		((ISupportInitialize)pbGuest).EndInit();
		((ISupportInitialize)btnClose).EndInit();
		ResumeLayout(performLayout: false);
	}
}
