using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Properties;

namespace CorePOS;

public class frmMessageBox : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Color color_1;

	[CompilerGenerated]
	private Color color_2;

	private IContainer icontainer_1;

	internal Button btnYes;

	private Label lblMsg;

	internal Button btnNo;

	private Panel panel1;

	internal Button btnOK;

	private Label lblTitle;

	private Label lblFork;

	internal Button btnCancel;

	private Label lblInfoPicture;

	private Label lblErrorPicture;

	private Label lblTipsPicture;

	public string yesButtonText
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

	public string noButtonText
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

	public Color yesButtonColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public Color noButtonColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public Color cancelButtonColor
	{
		[CompilerGenerated]
		get
		{
			return color_2;
		}
		[CompilerGenerated]
		set
		{
			color_2 = value;
		}
	}

	public frmMessageBox(string Message, string Title = "", string Buttons = "Ok")
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		lblMsg.Text = Message;
		lblTitle.Text = (Text = ((Title == string.Empty) ? BrandingTerms.SoftwareName : Title).ToUpper());
		if (Buttons == CustomMessageBoxButtons.Ok)
		{
			btnOK.Visible = true;
			Button button = btnNo;
			Button button2 = btnYes;
			btnCancel.Visible = false;
			button2.Visible = false;
			button.Visible = false;
		}
		if (Buttons == CustomMessageBoxButtons.YesNoCancel)
		{
			Button button3 = btnNo;
			Button button4 = btnYes;
			btnCancel.Visible = true;
			button4.Visible = true;
			button3.Visible = true;
			btnYes.Location = new Point(btnYes.Location.X - 50, btnYes.Location.Y);
			btnNo.Location = new Point(btnNo.Location.X - 50, btnNo.Location.Y);
			btnCancel.Location = new Point(btnCancel.Location.X - 50, btnCancel.Location.Y);
			btnOK.Visible = false;
			btnOK.Dispose();
		}
		else if (Buttons == CustomMessageBoxButtons.DismissSnooze)
		{
			Button button5 = btnNo;
			btnYes.Visible = true;
			button5.Visible = true;
			btnNo.Text = Resources.Snooze;
			btnYes.Text = Resources.Dismiss;
			Button button6 = btnOK;
			btnCancel.Visible = false;
			button6.Visible = false;
			btnCancel.Dispose();
		}
		else if (Buttons == CustomMessageBoxButtons.YesNo)
		{
			Button button7 = btnNo;
			btnYes.Visible = true;
			button7.Visible = true;
			Button button8 = btnOK;
			btnCancel.Visible = false;
			button8.Visible = false;
			btnCancel.Dispose();
			btnOK.Dispose();
		}
		if (Message.Contains(Resources.Are_you_sure_you_want_to_clear))
		{
			lblFork.Visible = true;
		}
		if (Title == "" || Title.ToUpper().Contains(Resources.WARNING0) || Title.ToUpper().Contains(Resources._ERROR0))
		{
			if (Title.ToUpper().Contains(Resources.CAPACITY_REACHED) || Title.ToUpper().Contains(Resources.NEAR_CAPACITY))
			{
				lblTitle.Font = new Font("Microsoft Sans Serif", 14f);
			}
			lblErrorPicture.Visible = true;
		}
		if (Title.ToUpper() == Resources.TIPS)
		{
			lblTipsPicture.Visible = true;
		}
		panel1.Refresh();
	}

	private void btnYes_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
		Close();
	}

	private void frmMessageBox_Load(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(yesButtonText))
		{
			btnYes.Text = yesButtonText;
		}
		if (!string.IsNullOrEmpty(noButtonText))
		{
			btnNo.Text = noButtonText;
		}
		if (yesButtonColor.A != 0 || yesButtonColor.R != 0 || yesButtonColor.G != 0 || yesButtonColor.B != 0)
		{
			btnYes.BackColor = yesButtonColor;
		}
		if (noButtonColor.A != 0 || noButtonColor.R != 0 || noButtonColor.G != 0 || noButtonColor.B != 0)
		{
			btnNo.BackColor = noButtonColor;
		}
		if (cancelButtonColor.A != 0 || cancelButtonColor.R != 0 || cancelButtonColor.G != 0 || cancelButtonColor.B != 0)
		{
			btnCancel.BackColor = cancelButtonColor;
		}
		if (AppSettings.ScreenCount >= 2)
		{
			Rectangle bounds = AppSettings.MainScreen.Bounds;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			Activate();
			SetBounds(bounds.Width / 2 - base.Width / 2, bounds.Height / 2 - base.Height / 2, base.Width, base.Height);
		}
		else if (lblTitle.Text.ToUpper().Contains("PAIRING"))
		{
			base.TopMost = true;
			Activate();
		}
	}

	private void btnNo_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
		Close();
	}

	private void btnOK_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMessageBox));
		lblInfoPicture = new Label();
		lblFork = new Label();
		lblTitle = new Label();
		panel1 = new Panel();
		btnCancel = new Button();
		btnOK = new Button();
		btnNo = new Button();
		btnYes = new Button();
		lblMsg = new Label();
		lblErrorPicture = new Label();
		lblTipsPicture = new Label();
		panel1.SuspendLayout();
		SuspendLayout();
		lblInfoPicture.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblInfoPicture, "lblInfoPicture");
		lblInfoPicture.ForeColor = Color.FromArgb(64, 64, 64);
		lblInfoPicture.Name = "lblInfoPicture";
		lblFork.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblFork, "lblFork");
		lblFork.ForeColor = Color.FromArgb(64, 64, 64);
		lblFork.Name = "lblFork";
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		panel1.BackColor = Color.White;
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(btnOK);
		panel1.Controls.Add(btnNo);
		panel1.Controls.Add(btnYes);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.BackColor = Color.Gray;
		btnCancel.DialogResult = DialogResult.Cancel;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(btnOK, "btnOK");
		btnOK.BackColor = Color.FromArgb(80, 203, 116);
		btnOK.DialogResult = DialogResult.OK;
		btnOK.FlatAppearance.BorderColor = Color.White;
		btnOK.FlatAppearance.BorderSize = 0;
		btnOK.FlatAppearance.MouseDownBackColor = Color.White;
		btnOK.ForeColor = Color.White;
		btnOK.Name = "btnOK";
		btnOK.UseVisualStyleBackColor = false;
		btnOK.Click += btnOK_Click;
		componentResourceManager.ApplyResources(btnNo, "btnNo");
		btnNo.BackColor = Color.FromArgb(235, 107, 86);
		btnNo.FlatAppearance.BorderColor = Color.White;
		btnNo.FlatAppearance.BorderSize = 0;
		btnNo.FlatAppearance.MouseDownBackColor = Color.White;
		btnNo.ForeColor = Color.White;
		btnNo.Name = "btnNo";
		btnNo.UseVisualStyleBackColor = false;
		btnNo.Click += btnNo_Click;
		componentResourceManager.ApplyResources(btnYes, "btnYes");
		btnYes.BackColor = Color.FromArgb(80, 203, 116);
		btnYes.FlatAppearance.BorderColor = Color.White;
		btnYes.FlatAppearance.BorderSize = 0;
		btnYes.FlatAppearance.MouseDownBackColor = Color.White;
		btnYes.ForeColor = Color.White;
		btnYes.Name = "btnYes";
		btnYes.UseVisualStyleBackColor = false;
		btnYes.Click += btnYes_Click;
		lblMsg.BackColor = Color.White;
		componentResourceManager.ApplyResources(lblMsg, "lblMsg");
		lblMsg.ForeColor = Color.FromArgb(64, 64, 64);
		lblMsg.Name = "lblMsg";
		lblErrorPicture.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblErrorPicture, "lblErrorPicture");
		lblErrorPicture.ForeColor = Color.FromArgb(64, 64, 64);
		lblErrorPicture.Name = "lblErrorPicture";
		lblTipsPicture.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTipsPicture, "lblTipsPicture");
		lblTipsPicture.ForeColor = Color.FromArgb(64, 64, 64);
		lblTipsPicture.Name = "lblTipsPicture";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(lblTipsPicture);
		base.Controls.Add(lblErrorPicture);
		base.Controls.Add(lblInfoPicture);
		base.Controls.Add(lblFork);
		base.Controls.Add(lblTitle);
		base.Controls.Add(panel1);
		base.Controls.Add(lblMsg);
		base.MaximizeBox = false;
		base.Name = "frmMessageBox";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.TopMost = true;
		base.Load += frmMessageBox_Load;
		panel1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
