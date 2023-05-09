using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Properties;

namespace CorePOS;

public class frmKeyboard : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	private int int_0;

	private int int_1;

	private float float_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private Point point_0;

	public bool toggle_Shift;

	public bool toggle_Caps;

	public bool toggle_Fr;

	public char[] special_Char;

	private TransparentLabel CjwFlhkudbi;

	private IContainer icontainer_1;

	internal Button btnCancel;

	internal Button btnDone;

	internal Button Button34;

	internal Button Button31;

	internal Button Button29;

	internal Button ButtonPeriod;

	internal Button ButtonComma;

	internal Button ButtonM;

	internal Button ButtonN;

	internal Button ButtonB;

	internal Button ButtonV;

	internal Button ButtonC;

	internal Button ButtonX;

	internal Button ButtonZ;

	internal Button ButtonL;

	internal Button ButtonK;

	internal Button ButtonJ;

	internal Button ButtonH;

	internal Button ButtonG;

	internal Button ButtonF;

	internal Button ButtonD;

	internal Button ButtonS;

	internal Button ButtonA;

	internal Button ButtonP;

	internal Button ButtonO;

	internal Button ButtonI;

	internal Button ButtonU;

	internal Button ButtonY;

	internal Button ButtonT;

	internal Button ButtonR;

	internal Button ButtonE;

	internal Button ButtonW;

	internal Button ButtonQ;

	internal Button button1;

	internal Button button2;

	internal Button button3;

	internal Button button4;

	internal Button button5;

	internal Button button6;

	internal Button button7;

	internal Button button8;

	internal Button button9;

	internal Button button10;

	private Label lblTitle;

	private System.Windows.Forms.Timer timer_0;

	internal Button button11;

	internal Button selectedLeft;

	internal Button selectionRight;

	internal Button btnClear;

	private Panel panel1;

	internal Button btnExclamation;

	internal Button button_0;

	internal Button button_1;

	internal Button buttonSPacer;

	private Panel panel2;

	internal Button button23;

	internal Button button24;

	internal Button button25;

	internal Button button26;

	internal Button button27;

	internal Button button28;

	internal Button button30;

	internal Button button32;

	internal Button button33;

	internal Button button35;

	internal Button button13;

	internal Button button14;

	internal Button button15;

	internal Button button16;

	internal Button button17;

	internal Button button18;

	internal Button button19;

	internal Button button20;

	internal Button button21;

	internal Button button22;

	internal Button button12;

	internal Button button36;

	private Panel panel3;

	private Class18 txtInput;

	public string textEntered
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

	private void method_3(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btnDone.PerformClick();
		}
	}

	public void refresh_SHIFT()
	{
		panel1.Controls["Button1"].Text = (toggle_Shift ? ")" : "0");
		panel1.Controls["Button2"].Text = (toggle_Shift ? "(" : "9");
		panel1.Controls["Button3"].Text = (toggle_Shift ? "*" : "8");
		panel1.Controls["Button4"].Text = (toggle_Shift ? "&&" : "7");
		panel1.Controls["Button5"].Text = (toggle_Shift ? "^" : "6");
		panel1.Controls["Button6"].Text = (toggle_Shift ? "%" : "5");
		panel1.Controls["Button7"].Text = (toggle_Shift ? "$" : "4");
		panel1.Controls["Button8"].Text = (toggle_Shift ? "#" : "3");
		panel1.Controls["Button9"].Text = (toggle_Shift ? "@" : "2");
		panel1.Controls["Button10"].Text = (toggle_Shift ? "!" : "1");
		panel1.Controls["button36"].Text = (toggle_Shift ? "_" : "-");
	}

	public frmKeyboard()
	{
		Class26.Ggkj0JxzN9YmC();
		int_1 = 128;
		float_0 = 32f;
		int_2 = 50;
		int_3 = 500;
		point_0 = new Point(0, 0);
		toggle_Shift = true;
		special_Char = new char[11]
		{
			'!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
			'-'
		};
		CjwFlhkudbi = new TransparentLabel();
		// base._002Ector();
		InitializeComponent_1();
	}

	public void LoadFormData(string title, int _minlength = 0, int _maxlength = 128, string default_text = "", bool multiline = false)
	{
		Text = title;
		int_0 = _minlength;
		int_1 = _maxlength;
		txtInput.Text = default_text;
		lblTitle.Text = title;
		if (lblTitle.Text.ToUpper().Contains(Resources.Address.ToUpper()) && !lblTitle.Text.ToUpper().Contains("IP "))
		{
			txtInput.method_1(TextBoxTypes.address);
		}
		else
		{
			txtInput.method_1("");
			txtInput.method_2();
		}
		if (multiline)
		{
			txtInput.Multiline = true;
			txtInput.Height = int_2 * 4;
			txtInput.Font = new Font(txtInput.Font.FontFamily, float_0 - 2f);
			panel1.Location = new Point(panel1.Location.X, txtInput.Location.Y + txtInput.Height + 1);
			base.Height = int_3 + txtInput.Height - int_2;
			txtInput.ScrollBars = ScrollBars.Vertical;
			txtInput.WordWrap = true;
		}
		else
		{
			txtInput.Multiline = false;
			txtInput.Height = int_2;
			txtInput.Font = new Font(txtInput.Font.FontFamily, float_0);
			panel1.Location = new Point(panel1.Location.X, txtInput.Location.Y + txtInput.Height + 1);
			base.Height = int_3;
			txtInput.ScrollBars = ScrollBars.None;
			txtInput.WordWrap = false;
		}
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			btnClear.Font = new Font(btnClear.Font.FontFamily, btnClear.Font.Size - 0.9f, FontStyle.Bold);
			base.Size = new Size(859, multiline ? 700 : 650);
			panel1.Location = new Point(5, multiline ? 320 : 270);
			panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + (multiline ? 50 : 0));
			panel2.Size = new Size(849, 144);
			panel2.Visible = true;
		}
		foreach (Control control in panel2.Controls)
		{
			control.Text = control.Text.ToUpper();
		}
		if (int_0 == 0)
		{
			btnDone.Enabled = true;
		}
		point_0 = panel1.Location;
		int_4 = base.Height;
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		base.OnFormClosing(e);
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
			Hide();
		}
	}

	private void ButtonN_Click(object sender, EventArgs e)
	{
		if (txtInput.Text.Length >= int_1)
		{
			return;
		}
		int selectionStart = txtInput.SelectionStart;
		Button button = (Button)sender;
		txtInput.Text = txtInput.Text.Insert(txtInput.SelectionStart, (button.Text == "&&") ? "&" : button.Text);
		txtInput.Focus();
		txtInput.SelectionStart = selectionStart + 1;
		txtInput.SelectionLength = 0;
		if (toggle_Shift && !toggle_Caps)
		{
			toggle_Shift = false;
			foreach (Control control in panel1.Controls)
			{
				if (control.Name.Length == 7 && control.Name[1] == 'u')
				{
					control.Text = control.Text.ToLower();
				}
				refresh_SHIFT();
			}
			foreach (Control control2 in panel2.Controls)
			{
				control2.Text = control2.Text.ToLower();
			}
			panel1.Controls["ButtonSHIFT"].BackColor = (toggle_Shift ? Color.FromArgb(255, 77, 174, 100) : Color.FromArgb(255, 77, 174, 225));
		}
		if (!(txtInput.method_0() == TextBoxTypes.address))
		{
			return;
		}
		txtInput.method_2();
		if (!string.IsNullOrEmpty(txtInput.Text) && txtInput.Text.Length > 9 && txtInput.Text.Length <= 20)
		{
			List<string> suggestedAddress = GoogleMethods.GetSuggestedAddress(txtInput.Text);
			if (suggestedAddress.Any() && !string.IsNullOrEmpty(txtInput.Text))
			{
				txtInput.listBox_0.DataSource = suggestedAddress;
				txtInput.listBox_0.Show();
			}
		}
		else
		{
			txtInput.listBox_0.Hide();
		}
	}

	private void Button34_Click(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		if (txtInput.TextLength != 0 && selectionStart != 0)
		{
			txtInput.Text = txtInput.Text.Remove(selectionStart - 1, 1);
			txtInput.SelectionStart = selectionStart - 1;
			txtInput.SelectionLength = 0;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (txtInput.listBox_0 != null)
		{
			txtInput.listBox_0.Hide();
		}
		Hide();
	}

	private void frmKeyboard_Load(object sender, EventArgs e)
	{
		panel3.Location = new Point(base.Width / 2 - panel3.Width / 2, base.Height / 2 - panel3.Height / 2);
		txtInput.SelectionStart = ((txtInput.Text.Length > 0) ? txtInput.Text.Length : 0);
		txtInput.SelectionLength = 0;
		txtInput.Select();
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		if (txtInput.Text.Length >= int_0 && txtInput.Text.Length <= int_1)
		{
			if (lblTitle.Text.ToUpper().Contains(Resources.Address.ToUpper()))
			{
				txtInput.Text = txtInput.Text.Replace(";", string.Empty);
			}
			textEntered = txtInput.Text;
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			new frmMessageBox(Resources.Please_enter_a_minimum_of + int_0 + Resources._characters_and_a_maximum_of + int_1 + Resources._characters, Resources.Character_Length_Requirement).ShowDialog(this);
		}
		if (txtInput.listBox_0 != null)
		{
			txtInput.listBox_0.Hide();
		}
	}

	private void Button29_Click(object sender, EventArgs e)
	{
		int selectionStart = txtInput.SelectionStart;
		if (selectionStart == txtInput.Text.Length)
		{
			txtInput.Text += " ";
		}
		else
		{
			txtInput.Text = txtInput.Text.Insert(txtInput.SelectionStart, " ");
		}
		txtInput.Focus();
		txtInput.SelectionStart = selectionStart + 1;
		txtInput.SelectionLength = 0;
	}

	private void method_4(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		txtInput.Text += button.Text;
		txtInput.Focus();
	}

	private void FhtFljsKhix(object sender, EventArgs e)
	{
		if (txtInput.Text.Trim().Length >= int_0 && txtInput.Text.Trim().Length <= int_1)
		{
			btnDone.Enabled = true;
		}
		else
		{
			btnDone.Enabled = false;
		}
		if (lblTitle.Text.ToUpper() == Resources.ENTER_THE_CLOUDSYNC_API_KEY0)
		{
			txtInput.Text = txtInput.Text.Trim();
		}
		if (txtInput.method_0() == TextBoxTypes.address)
		{
			if (txtInput.listBox_0 != null && txtInput.listBox_0.Visible)
			{
				base.Height = int_4 + txtInput.listBox_0.Height;
				panel1.Location = new Point(point_0.X, txtInput.listBox_0.Location.Y + txtInput.listBox_0.Height);
			}
			else
			{
				base.Height = int_4;
				panel1.Location = point_0;
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (base.Opacity < 1.0)
		{
			base.Opacity += 0.1;
			return;
		}
		base.Opacity = 1.0;
		timer_0.Enabled = false;
	}

	private void method_5(object sender, EventArgs e)
	{
		txtInput.Text += "&";
	}

	private void selectedLeft_Click(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		txtInput.SelectionStart = ((selectionStart != 0) ? (selectionStart - 1) : 0);
		txtInput.SelectionLength = 0;
	}

	private void selectionRight_Click(object sender, EventArgs e)
	{
		txtInput.Focus();
		int selectionStart = txtInput.SelectionStart;
		txtInput.SelectionStart = ((selectionStart == txtInput.Text.Length) ? txtInput.Text.Length : (selectionStart + 1));
		txtInput.SelectionLength = 0;
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		txtInput.Text = string.Empty;
		txtInput.Select();
	}

	private void method_6(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		txtInput.Text += button.Text;
		txtInput.Focus();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		toggle_Shift = !toggle_Shift;
		((Button)sender).BackColor = (toggle_Shift ? Color.FromArgb(255, 77, 174, 100) : Color.FromArgb(255, 77, 174, 225));
		foreach (Control control3 in panel1.Controls)
		{
			if (control3.Name.Length == 7 && control3.Name[1] == 'u')
			{
				control3.Text = ((toggle_Shift || toggle_Caps) ? control3.Text.ToUpper() : control3.Text.ToLower());
			}
		}
		foreach (Control control4 in panel2.Controls)
		{
			control4.Text = ((toggle_Shift || toggle_Caps) ? control4.Text.ToUpper() : control4.Text.ToLower());
		}
		refresh_SHIFT();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		toggle_Caps = !toggle_Caps;
		((Button)sender).BackColor = (toggle_Caps ? Color.FromArgb(255, 77, 174, 100) : Color.FromArgb(255, 77, 174, 225));
		foreach (Control control3 in panel1.Controls)
		{
			if (control3.Name.Length == 7 && control3.Name[1] == 'u')
			{
				control3.Text = ((toggle_Shift || toggle_Caps) ? control3.Text.ToUpper() : control3.Text.ToLower());
			}
		}
		foreach (Control control4 in panel2.Controls)
		{
			control4.Text = ((toggle_Shift || toggle_Caps) ? control4.Text.ToUpper() : control4.Text.ToLower());
		}
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
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmKeyboard));
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		panel2 = new Panel();
		button23 = new Button();
		button24 = new Button();
		button25 = new Button();
		button26 = new Button();
		button27 = new Button();
		button28 = new Button();
		button30 = new Button();
		button32 = new Button();
		button33 = new Button();
		button35 = new Button();
		button13 = new Button();
		button14 = new Button();
		button15 = new Button();
		button16 = new Button();
		button17 = new Button();
		button18 = new Button();
		button19 = new Button();
		button20 = new Button();
		button21 = new Button();
		button22 = new Button();
		panel1 = new Panel();
		button36 = new Button();
		button12 = new Button();
		buttonSPacer = new Button();
		button_1 = new Button();
		button_0 = new Button();
		btnExclamation = new Button();
		button10 = new Button();
		btnClear = new Button();
		ButtonQ = new Button();
		selectionRight = new Button();
		ButtonW = new Button();
		selectedLeft = new Button();
		ButtonE = new Button();
		button11 = new Button();
		ButtonR = new Button();
		ButtonT = new Button();
		button1 = new Button();
		ButtonY = new Button();
		button2 = new Button();
		ButtonU = new Button();
		button3 = new Button();
		ButtonI = new Button();
		button4 = new Button();
		ButtonO = new Button();
		button5 = new Button();
		ButtonP = new Button();
		button6 = new Button();
		ButtonA = new Button();
		button7 = new Button();
		ButtonS = new Button();
		button8 = new Button();
		ButtonD = new Button();
		button9 = new Button();
		ButtonF = new Button();
		ButtonG = new Button();
		ButtonH = new Button();
		btnCancel = new Button();
		ButtonJ = new Button();
		btnDone = new Button();
		ButtonK = new Button();
		Button34 = new Button();
		ButtonL = new Button();
		Button31 = new Button();
		ButtonZ = new Button();
		Button29 = new Button();
		ButtonX = new Button();
		ButtonPeriod = new Button();
		ButtonC = new Button();
		ButtonComma = new Button();
		ButtonV = new Button();
		ButtonM = new Button();
		ButtonB = new Button();
		ButtonN = new Button();
		lblTitle = new Label();
		panel3 = new Panel();
		txtInput = new Class18();
		panel2.SuspendLayout();
		panel1.SuspendLayout();
		panel3.SuspendLayout();
		SuspendLayout();
		timer_0.Enabled = true;
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
		panel2.Controls.Add(button23);
		panel2.Controls.Add(button24);
		panel2.Controls.Add(button25);
		panel2.Controls.Add(button26);
		panel2.Controls.Add(button27);
		panel2.Controls.Add(button28);
		panel2.Controls.Add(button30);
		panel2.Controls.Add(button32);
		panel2.Controls.Add(button33);
		panel2.Controls.Add(button35);
		panel2.Controls.Add(button13);
		panel2.Controls.Add(button14);
		panel2.Controls.Add(button15);
		panel2.Controls.Add(button16);
		panel2.Controls.Add(button17);
		panel2.Controls.Add(button18);
		panel2.Controls.Add(button19);
		panel2.Controls.Add(button20);
		panel2.Controls.Add(button21);
		panel2.Controls.Add(button22);
		componentResourceManager.ApplyResources(panel2, "panel2");
		panel2.Name = "panel2";
		button23.BackColor = Color.FromArgb(77, 174, 200);
		button23.FlatAppearance.BorderColor = Color.Black;
		button23.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button23, "button23");
		button23.ForeColor = Color.White;
		button23.Name = "button23";
		button23.UseVisualStyleBackColor = false;
		button23.Click += ButtonN_Click;
		button24.BackColor = Color.FromArgb(77, 174, 200);
		button24.FlatAppearance.BorderColor = Color.Black;
		button24.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button24, "button24");
		button24.ForeColor = Color.White;
		button24.Name = "button24";
		button24.UseVisualStyleBackColor = false;
		button24.Click += ButtonN_Click;
		button25.BackColor = Color.FromArgb(77, 174, 200);
		button25.FlatAppearance.BorderColor = Color.Black;
		button25.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button25, "button25");
		button25.ForeColor = Color.White;
		button25.Name = "button25";
		button25.UseVisualStyleBackColor = false;
		button25.Click += ButtonN_Click;
		button26.BackColor = Color.FromArgb(77, 174, 200);
		button26.FlatAppearance.BorderColor = Color.Black;
		button26.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button26, "button26");
		button26.ForeColor = Color.White;
		button26.Name = "button26";
		button26.UseVisualStyleBackColor = false;
		button26.Click += ButtonN_Click;
		button27.BackColor = Color.FromArgb(77, 174, 200);
		button27.FlatAppearance.BorderColor = Color.Black;
		button27.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button27, "button27");
		button27.ForeColor = Color.White;
		button27.Name = "button27";
		button27.UseVisualStyleBackColor = false;
		button27.Click += ButtonN_Click;
		button28.BackColor = Color.FromArgb(77, 174, 200);
		button28.FlatAppearance.BorderColor = Color.Black;
		button28.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button28, "button28");
		button28.ForeColor = Color.White;
		button28.Name = "button28";
		button28.UseVisualStyleBackColor = false;
		button28.Click += ButtonN_Click;
		button30.BackColor = Color.FromArgb(77, 174, 200);
		button30.FlatAppearance.BorderColor = Color.Black;
		button30.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button30, "button30");
		button30.ForeColor = Color.White;
		button30.Name = "button30";
		button30.UseVisualStyleBackColor = false;
		button30.Click += ButtonN_Click;
		button32.BackColor = Color.FromArgb(77, 174, 200);
		button32.FlatAppearance.BorderColor = Color.Black;
		button32.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button32, "button32");
		button32.ForeColor = Color.White;
		button32.Name = "button32";
		button32.UseVisualStyleBackColor = false;
		button32.Click += ButtonN_Click;
		button33.BackColor = Color.FromArgb(77, 174, 200);
		button33.FlatAppearance.BorderColor = Color.Black;
		button33.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button33, "button33");
		button33.ForeColor = Color.White;
		button33.Name = "button33";
		button33.UseVisualStyleBackColor = false;
		button33.Click += ButtonN_Click;
		button35.BackColor = Color.FromArgb(77, 174, 200);
		button35.FlatAppearance.BorderColor = Color.Black;
		button35.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button35, "button35");
		button35.ForeColor = Color.White;
		button35.Name = "button35";
		button35.UseVisualStyleBackColor = false;
		button35.Click += ButtonN_Click;
		button13.BackColor = Color.FromArgb(77, 174, 200);
		button13.FlatAppearance.BorderColor = Color.Black;
		button13.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button13, "button13");
		button13.ForeColor = Color.White;
		button13.Name = "button13";
		button13.UseVisualStyleBackColor = false;
		button13.Click += ButtonN_Click;
		button14.BackColor = Color.FromArgb(77, 174, 200);
		button14.FlatAppearance.BorderColor = Color.Black;
		button14.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button14, "button14");
		button14.ForeColor = Color.White;
		button14.Name = "button14";
		button14.UseVisualStyleBackColor = false;
		button14.Click += ButtonN_Click;
		button15.BackColor = Color.FromArgb(77, 174, 200);
		button15.FlatAppearance.BorderColor = Color.Black;
		button15.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button15, "button15");
		button15.ForeColor = Color.White;
		button15.Name = "button15";
		button15.UseVisualStyleBackColor = false;
		button15.Click += ButtonN_Click;
		button16.BackColor = Color.FromArgb(77, 174, 200);
		button16.FlatAppearance.BorderColor = Color.Black;
		button16.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button16, "button16");
		button16.ForeColor = Color.White;
		button16.Name = "button16";
		button16.UseVisualStyleBackColor = false;
		button16.Click += ButtonN_Click;
		button17.BackColor = Color.FromArgb(77, 174, 200);
		button17.FlatAppearance.BorderColor = Color.Black;
		button17.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button17, "button17");
		button17.ForeColor = Color.White;
		button17.Name = "button17";
		button17.UseVisualStyleBackColor = false;
		button17.Click += ButtonN_Click;
		button18.BackColor = Color.FromArgb(77, 174, 200);
		button18.FlatAppearance.BorderColor = Color.Black;
		button18.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button18, "button18");
		button18.ForeColor = Color.White;
		button18.Name = "button18";
		button18.UseVisualStyleBackColor = false;
		button18.Click += ButtonN_Click;
		button19.BackColor = Color.FromArgb(77, 174, 200);
		button19.FlatAppearance.BorderColor = Color.Black;
		button19.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button19, "button19");
		button19.ForeColor = Color.White;
		button19.Name = "button19";
		button19.UseVisualStyleBackColor = false;
		button19.Click += ButtonN_Click;
		button20.BackColor = Color.FromArgb(77, 174, 200);
		button20.FlatAppearance.BorderColor = Color.Black;
		button20.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button20, "button20");
		button20.ForeColor = Color.White;
		button20.Name = "button20";
		button20.UseVisualStyleBackColor = false;
		button20.Click += ButtonN_Click;
		button21.BackColor = Color.FromArgb(77, 174, 200);
		button21.FlatAppearance.BorderColor = Color.Black;
		button21.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button21, "button21");
		button21.ForeColor = Color.White;
		button21.Name = "button21";
		button21.UseVisualStyleBackColor = false;
		button21.Click += ButtonN_Click;
		button22.BackColor = Color.FromArgb(77, 174, 200);
		button22.FlatAppearance.BorderColor = Color.Black;
		button22.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button22, "button22");
		button22.ForeColor = Color.White;
		button22.Name = "button22";
		button22.UseVisualStyleBackColor = false;
		button22.Click += ButtonN_Click;
		panel1.Controls.Add(button36);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(button12);
		panel1.Controls.Add(buttonSPacer);
		panel1.Controls.Add(button_1);
		panel1.Controls.Add(button_0);
		panel1.Controls.Add(btnExclamation);
		panel1.Controls.Add(button10);
		panel1.Controls.Add(btnClear);
		panel1.Controls.Add(ButtonQ);
		panel1.Controls.Add(selectionRight);
		panel1.Controls.Add(ButtonW);
		panel1.Controls.Add(selectedLeft);
		panel1.Controls.Add(ButtonE);
		panel1.Controls.Add(button11);
		panel1.Controls.Add(ButtonR);
		panel1.Controls.Add(ButtonT);
		panel1.Controls.Add(button1);
		panel1.Controls.Add(ButtonY);
		panel1.Controls.Add(button2);
		panel1.Controls.Add(ButtonU);
		panel1.Controls.Add(button3);
		panel1.Controls.Add(ButtonI);
		panel1.Controls.Add(button4);
		panel1.Controls.Add(ButtonO);
		panel1.Controls.Add(button5);
		panel1.Controls.Add(ButtonP);
		panel1.Controls.Add(button6);
		panel1.Controls.Add(ButtonA);
		panel1.Controls.Add(button7);
		panel1.Controls.Add(ButtonS);
		panel1.Controls.Add(button8);
		panel1.Controls.Add(ButtonD);
		panel1.Controls.Add(button9);
		panel1.Controls.Add(ButtonF);
		panel1.Controls.Add(ButtonG);
		panel1.Controls.Add(ButtonH);
		panel1.Controls.Add(btnCancel);
		panel1.Controls.Add(ButtonJ);
		panel1.Controls.Add(btnDone);
		panel1.Controls.Add(ButtonK);
		panel1.Controls.Add(Button34);
		panel1.Controls.Add(ButtonL);
		panel1.Controls.Add(Button31);
		panel1.Controls.Add(ButtonZ);
		panel1.Controls.Add(Button29);
		panel1.Controls.Add(ButtonX);
		panel1.Controls.Add(ButtonPeriod);
		panel1.Controls.Add(ButtonC);
		panel1.Controls.Add(ButtonComma);
		panel1.Controls.Add(ButtonV);
		panel1.Controls.Add(ButtonM);
		panel1.Controls.Add(ButtonB);
		panel1.Controls.Add(ButtonN);
		componentResourceManager.ApplyResources(panel1, "panel1");
		panel1.Name = "panel1";
		button36.BackColor = Color.FromArgb(77, 174, 225);
		button36.FlatAppearance.BorderColor = Color.Black;
		button36.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button36, "button36");
		button36.ForeColor = Color.White;
		button36.Name = "button36";
		button36.UseVisualStyleBackColor = false;
		button36.Click += ButtonN_Click;
		button12.BackColor = Color.FromArgb(77, 174, 225);
		button12.FlatAppearance.BorderColor = Color.Black;
		button12.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button12, "button12");
		button12.ForeColor = Color.White;
		button12.Name = "button12";
		button12.UseVisualStyleBackColor = false;
		button12.Click += ButtonN_Click;
		buttonSPacer.BackColor = Color.FromArgb(77, 174, 225);
		buttonSPacer.FlatAppearance.BorderColor = Color.Black;
		buttonSPacer.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(buttonSPacer, "buttonSPacer");
		buttonSPacer.ForeColor = Color.White;
		buttonSPacer.Name = "buttonSPacer";
		buttonSPacer.UseVisualStyleBackColor = false;
		button_1.BackColor = Color.FromArgb(77, 174, 225);
		button_1.FlatAppearance.BorderColor = Color.Black;
		button_1.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_1, "buttonCAPS");
		button_1.ForeColor = Color.White;
		button_1.Name = "buttonCAPS";
		button_1.UseVisualStyleBackColor = false;
		button_1.Click += button_1_Click;
		button_0.BackColor = Color.FromArgb(77, 174, 100);
		button_0.FlatAppearance.BorderColor = Color.Black;
		button_0.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button_0, "buttonSHIFT");
		button_0.ForeColor = Color.White;
		button_0.Name = "buttonSHIFT";
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		btnExclamation.BackColor = Color.FromArgb(77, 174, 225);
		btnExclamation.FlatAppearance.BorderColor = Color.Black;
		btnExclamation.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnExclamation, "btnExclamation");
		btnExclamation.ForeColor = Color.White;
		btnExclamation.Name = "btnExclamation";
		btnExclamation.UseVisualStyleBackColor = false;
		btnExclamation.Click += ButtonN_Click;
		button10.BackColor = Color.FromArgb(77, 174, 225);
		button10.FlatAppearance.BorderColor = Color.Black;
		button10.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button10, "button10");
		button10.ForeColor = Color.White;
		button10.Name = "button10";
		button10.UseVisualStyleBackColor = false;
		button10.Click += ButtonN_Click;
		btnClear.BackColor = Color.FromArgb(77, 174, 225);
		btnClear.FlatAppearance.BorderColor = Color.Black;
		btnClear.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.Click += btnClear_Click;
		ButtonQ.BackColor = Color.FromArgb(164, 181, 181);
		ButtonQ.FlatAppearance.BorderColor = Color.Black;
		ButtonQ.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonQ, "ButtonQ");
		ButtonQ.ForeColor = Color.White;
		ButtonQ.Name = "ButtonQ";
		ButtonQ.UseVisualStyleBackColor = false;
		ButtonQ.Click += ButtonN_Click;
		selectionRight.BackColor = Color.FromArgb(118, 130, 130);
		selectionRight.FlatAppearance.BorderColor = Color.Black;
		selectionRight.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(selectionRight, "selectionRight");
		selectionRight.ForeColor = Color.White;
		selectionRight.Name = "selectionRight";
		selectionRight.UseVisualStyleBackColor = false;
		selectionRight.Click += selectionRight_Click;
		ButtonW.BackColor = Color.FromArgb(164, 181, 181);
		ButtonW.FlatAppearance.BorderColor = Color.Black;
		ButtonW.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonW, "ButtonW");
		ButtonW.ForeColor = Color.White;
		ButtonW.Name = "ButtonW";
		ButtonW.UseVisualStyleBackColor = false;
		ButtonW.Click += ButtonN_Click;
		selectedLeft.BackColor = Color.FromArgb(118, 130, 130);
		selectedLeft.FlatAppearance.BorderColor = Color.Black;
		selectedLeft.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(selectedLeft, "selectedLeft");
		selectedLeft.ForeColor = Color.White;
		selectedLeft.Name = "selectedLeft";
		selectedLeft.UseVisualStyleBackColor = false;
		selectedLeft.Click += selectedLeft_Click;
		ButtonE.BackColor = Color.FromArgb(164, 181, 181);
		ButtonE.FlatAppearance.BorderColor = Color.Black;
		ButtonE.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonE, "ButtonE");
		ButtonE.ForeColor = Color.White;
		ButtonE.Name = "ButtonE";
		ButtonE.UseVisualStyleBackColor = false;
		ButtonE.Click += ButtonN_Click;
		button11.BackColor = Color.FromArgb(77, 174, 225);
		button11.FlatAppearance.BorderColor = Color.Black;
		button11.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button11, "button11");
		button11.ForeColor = Color.White;
		button11.Name = "button11";
		button11.UseVisualStyleBackColor = false;
		button11.Click += ButtonN_Click;
		ButtonR.BackColor = Color.FromArgb(164, 181, 181);
		ButtonR.FlatAppearance.BorderColor = Color.Black;
		ButtonR.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonR, "ButtonR");
		ButtonR.ForeColor = Color.White;
		ButtonR.Name = "ButtonR";
		ButtonR.UseVisualStyleBackColor = false;
		ButtonR.Click += ButtonN_Click;
		ButtonT.BackColor = Color.FromArgb(164, 181, 181);
		ButtonT.FlatAppearance.BorderColor = Color.Black;
		ButtonT.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonT, "ButtonT");
		ButtonT.ForeColor = Color.White;
		ButtonT.Name = "ButtonT";
		ButtonT.UseVisualStyleBackColor = false;
		ButtonT.Click += ButtonN_Click;
		button1.BackColor = Color.FromArgb(77, 174, 225);
		button1.FlatAppearance.BorderColor = Color.Black;
		button1.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button1, "button1");
		button1.ForeColor = Color.White;
		button1.Name = "button1";
		button1.UseVisualStyleBackColor = false;
		button1.Click += ButtonN_Click;
		ButtonY.BackColor = Color.FromArgb(164, 181, 181);
		ButtonY.FlatAppearance.BorderColor = Color.Black;
		ButtonY.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonY, "ButtonY");
		ButtonY.ForeColor = Color.White;
		ButtonY.Name = "ButtonY";
		ButtonY.UseVisualStyleBackColor = false;
		ButtonY.Click += ButtonN_Click;
		button2.BackColor = Color.FromArgb(77, 174, 225);
		button2.FlatAppearance.BorderColor = Color.Black;
		button2.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button2, "button2");
		button2.ForeColor = Color.White;
		button2.Name = "button2";
		button2.UseVisualStyleBackColor = false;
		button2.Click += ButtonN_Click;
		ButtonU.BackColor = Color.FromArgb(164, 181, 181);
		ButtonU.FlatAppearance.BorderColor = Color.Black;
		ButtonU.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonU, "ButtonU");
		ButtonU.ForeColor = Color.White;
		ButtonU.Name = "ButtonU";
		ButtonU.UseVisualStyleBackColor = false;
		ButtonU.Click += ButtonN_Click;
		button3.BackColor = Color.FromArgb(77, 174, 225);
		button3.FlatAppearance.BorderColor = Color.Black;
		button3.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button3, "button3");
		button3.ForeColor = Color.White;
		button3.Name = "button3";
		button3.UseVisualStyleBackColor = false;
		button3.Click += ButtonN_Click;
		ButtonI.BackColor = Color.FromArgb(164, 181, 181);
		ButtonI.FlatAppearance.BorderColor = Color.Black;
		ButtonI.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonI, "ButtonI");
		ButtonI.ForeColor = Color.White;
		ButtonI.Name = "ButtonI";
		ButtonI.UseVisualStyleBackColor = false;
		ButtonI.Click += ButtonN_Click;
		button4.BackColor = Color.FromArgb(77, 174, 225);
		button4.FlatAppearance.BorderColor = Color.Black;
		button4.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button4, "button4");
		button4.ForeColor = Color.White;
		button4.Name = "button4";
		button4.UseVisualStyleBackColor = false;
		button4.Click += ButtonN_Click;
		ButtonO.BackColor = Color.FromArgb(164, 181, 181);
		ButtonO.FlatAppearance.BorderColor = Color.Black;
		ButtonO.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonO, "ButtonO");
		ButtonO.ForeColor = Color.White;
		ButtonO.Name = "ButtonO";
		ButtonO.UseVisualStyleBackColor = false;
		ButtonO.Click += ButtonN_Click;
		button5.BackColor = Color.FromArgb(77, 174, 225);
		button5.FlatAppearance.BorderColor = Color.Black;
		button5.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button5, "button5");
		button5.ForeColor = Color.White;
		button5.Name = "button5";
		button5.UseVisualStyleBackColor = false;
		button5.Click += ButtonN_Click;
		ButtonP.BackColor = Color.FromArgb(164, 181, 181);
		ButtonP.FlatAppearance.BorderColor = Color.Black;
		ButtonP.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonP, "ButtonP");
		ButtonP.ForeColor = Color.White;
		ButtonP.Name = "ButtonP";
		ButtonP.UseVisualStyleBackColor = false;
		ButtonP.Click += ButtonN_Click;
		button6.BackColor = Color.FromArgb(77, 174, 225);
		button6.FlatAppearance.BorderColor = Color.Black;
		button6.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button6, "button6");
		button6.ForeColor = Color.White;
		button6.Name = "button6";
		button6.UseVisualStyleBackColor = false;
		button6.Click += ButtonN_Click;
		ButtonA.BackColor = Color.FromArgb(150, 166, 166);
		ButtonA.FlatAppearance.BorderColor = Color.Black;
		ButtonA.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonA, "ButtonA");
		ButtonA.ForeColor = Color.White;
		ButtonA.Name = "ButtonA";
		ButtonA.UseVisualStyleBackColor = false;
		ButtonA.Click += ButtonN_Click;
		button7.BackColor = Color.FromArgb(77, 174, 225);
		button7.FlatAppearance.BorderColor = Color.Black;
		button7.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button7, "button7");
		button7.ForeColor = Color.White;
		button7.Name = "button7";
		button7.UseVisualStyleBackColor = false;
		button7.Click += ButtonN_Click;
		ButtonS.BackColor = Color.FromArgb(150, 166, 166);
		ButtonS.FlatAppearance.BorderColor = Color.Black;
		ButtonS.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonS, "ButtonS");
		ButtonS.ForeColor = Color.White;
		ButtonS.Name = "ButtonS";
		ButtonS.UseVisualStyleBackColor = false;
		ButtonS.Click += ButtonN_Click;
		button8.BackColor = Color.FromArgb(77, 174, 225);
		button8.FlatAppearance.BorderColor = Color.Black;
		button8.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button8, "button8");
		button8.ForeColor = Color.White;
		button8.Name = "button8";
		button8.UseVisualStyleBackColor = false;
		button8.Click += ButtonN_Click;
		ButtonD.BackColor = Color.FromArgb(150, 166, 166);
		ButtonD.FlatAppearance.BorderColor = Color.Black;
		ButtonD.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonD, "ButtonD");
		ButtonD.ForeColor = Color.White;
		ButtonD.Name = "ButtonD";
		ButtonD.UseVisualStyleBackColor = false;
		ButtonD.Click += ButtonN_Click;
		button9.BackColor = Color.FromArgb(77, 174, 225);
		button9.FlatAppearance.BorderColor = Color.Black;
		button9.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(button9, "button9");
		button9.ForeColor = Color.White;
		button9.Name = "button9";
		button9.UseVisualStyleBackColor = false;
		button9.Click += ButtonN_Click;
		ButtonF.BackColor = Color.FromArgb(150, 166, 166);
		ButtonF.FlatAppearance.BorderColor = Color.Black;
		ButtonF.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonF, "ButtonF");
		ButtonF.ForeColor = Color.White;
		ButtonF.Name = "ButtonF";
		ButtonF.UseVisualStyleBackColor = false;
		ButtonF.Click += ButtonN_Click;
		ButtonG.BackColor = Color.FromArgb(150, 166, 166);
		ButtonG.FlatAppearance.BorderColor = Color.Black;
		ButtonG.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonG, "ButtonG");
		ButtonG.ForeColor = Color.White;
		ButtonG.Name = "ButtonG";
		ButtonG.UseVisualStyleBackColor = false;
		ButtonG.Click += ButtonN_Click;
		ButtonH.BackColor = Color.FromArgb(150, 166, 166);
		ButtonH.FlatAppearance.BorderColor = Color.Black;
		ButtonH.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonH, "ButtonH");
		ButtonH.ForeColor = Color.White;
		ButtonH.Name = "ButtonH";
		ButtonH.UseVisualStyleBackColor = false;
		ButtonH.Click += ButtonN_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderColor = Color.Black;
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		ButtonJ.BackColor = Color.FromArgb(150, 166, 166);
		ButtonJ.FlatAppearance.BorderColor = Color.Black;
		ButtonJ.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonJ, "ButtonJ");
		ButtonJ.ForeColor = Color.White;
		ButtonJ.Name = "ButtonJ";
		ButtonJ.UseVisualStyleBackColor = false;
		ButtonJ.Click += ButtonN_Click;
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.FlatAppearance.BorderColor = Color.Black;
		btnDone.FlatAppearance.BorderSize = 0;
		btnDone.ForeColor = Color.White;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		ButtonK.BackColor = Color.FromArgb(150, 166, 166);
		ButtonK.FlatAppearance.BorderColor = Color.Black;
		ButtonK.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonK, "ButtonK");
		ButtonK.ForeColor = Color.White;
		ButtonK.Name = "ButtonK";
		ButtonK.UseVisualStyleBackColor = false;
		ButtonK.Click += ButtonN_Click;
		Button34.BackColor = Color.FromArgb(61, 142, 185);
		Button34.FlatAppearance.BorderColor = Color.Black;
		Button34.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button34, "Button34");
		Button34.ForeColor = Color.White;
		Button34.Name = "Button34";
		Button34.UseVisualStyleBackColor = false;
		Button34.Click += Button34_Click;
		ButtonL.BackColor = Color.FromArgb(150, 166, 166);
		ButtonL.FlatAppearance.BorderColor = Color.Black;
		ButtonL.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonL, "ButtonL");
		ButtonL.ForeColor = Color.White;
		ButtonL.Name = "ButtonL";
		ButtonL.UseVisualStyleBackColor = false;
		ButtonL.Click += ButtonN_Click;
		Button31.BackColor = Color.FromArgb(77, 174, 225);
		Button31.FlatAppearance.BorderColor = Color.Black;
		Button31.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button31, "Button31");
		Button31.ForeColor = Color.White;
		Button31.Name = "Button31";
		Button31.UseVisualStyleBackColor = false;
		Button31.Click += ButtonN_Click;
		ButtonZ.BackColor = Color.FromArgb(132, 146, 146);
		ButtonZ.FlatAppearance.BorderColor = Color.Black;
		ButtonZ.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonZ, "ButtonZ");
		ButtonZ.ForeColor = Color.White;
		ButtonZ.Name = "ButtonZ";
		ButtonZ.UseVisualStyleBackColor = false;
		ButtonZ.Click += ButtonN_Click;
		Button29.BackColor = Color.FromArgb(118, 130, 130);
		Button29.FlatAppearance.BorderColor = Color.Black;
		Button29.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(Button29, "Button29");
		Button29.ForeColor = Color.White;
		Button29.Name = "Button29";
		Button29.UseVisualStyleBackColor = false;
		Button29.Click += Button29_Click;
		ButtonX.BackColor = Color.FromArgb(132, 146, 146);
		ButtonX.FlatAppearance.BorderColor = Color.Black;
		ButtonX.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonX, "ButtonX");
		ButtonX.ForeColor = Color.White;
		ButtonX.Name = "ButtonX";
		ButtonX.UseVisualStyleBackColor = false;
		ButtonX.Click += ButtonN_Click;
		ButtonPeriod.BackColor = Color.FromArgb(132, 146, 146);
		ButtonPeriod.FlatAppearance.BorderColor = Color.Black;
		ButtonPeriod.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonPeriod, "ButtonPeriod");
		ButtonPeriod.ForeColor = Color.White;
		ButtonPeriod.Name = "ButtonPeriod";
		ButtonPeriod.UseVisualStyleBackColor = false;
		ButtonPeriod.Click += ButtonN_Click;
		ButtonC.BackColor = Color.FromArgb(132, 146, 146);
		ButtonC.FlatAppearance.BorderColor = Color.Black;
		ButtonC.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonC, "ButtonC");
		ButtonC.ForeColor = Color.White;
		ButtonC.Name = "ButtonC";
		ButtonC.UseVisualStyleBackColor = false;
		ButtonC.Click += ButtonN_Click;
		ButtonComma.BackColor = Color.FromArgb(132, 146, 146);
		ButtonComma.FlatAppearance.BorderColor = Color.Black;
		ButtonComma.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonComma, "ButtonComma");
		ButtonComma.ForeColor = Color.White;
		ButtonComma.Name = "ButtonComma";
		ButtonComma.UseVisualStyleBackColor = false;
		ButtonComma.Click += ButtonN_Click;
		ButtonV.BackColor = Color.FromArgb(132, 146, 146);
		ButtonV.FlatAppearance.BorderColor = Color.Black;
		ButtonV.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonV, "ButtonV");
		ButtonV.ForeColor = Color.White;
		ButtonV.Name = "ButtonV";
		ButtonV.UseVisualStyleBackColor = false;
		ButtonV.Click += ButtonN_Click;
		ButtonM.BackColor = Color.FromArgb(132, 146, 146);
		ButtonM.FlatAppearance.BorderColor = Color.Black;
		ButtonM.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonM, "ButtonM");
		ButtonM.ForeColor = Color.White;
		ButtonM.Name = "ButtonM";
		ButtonM.UseVisualStyleBackColor = false;
		ButtonM.Click += ButtonN_Click;
		ButtonB.BackColor = Color.FromArgb(132, 146, 146);
		ButtonB.FlatAppearance.BorderColor = Color.Black;
		ButtonB.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonB, "ButtonB");
		ButtonB.ForeColor = Color.White;
		ButtonB.Name = "ButtonB";
		ButtonB.UseVisualStyleBackColor = false;
		ButtonB.Click += ButtonN_Click;
		ButtonN.BackColor = Color.FromArgb(132, 146, 146);
		ButtonN.FlatAppearance.BorderColor = Color.Black;
		ButtonN.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(ButtonN, "ButtonN");
		ButtonN.ForeColor = Color.White;
		ButtonN.Name = "ButtonN";
		ButtonN.UseVisualStyleBackColor = false;
		ButtonN.Click += ButtonN_Click;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		panel3.Controls.Add(txtInput);
		panel3.Controls.Add(lblTitle);
		panel3.Controls.Add(panel1);
		componentResourceManager.ApplyResources(panel3, "panel3");
		panel3.Name = "panel3";
		componentResourceManager.ApplyResources(txtInput, "txtInput");
		txtInput.Name = "txtInput";
		txtInput.method_1("keyboard");
		txtInput.TextChanged += FhtFljsKhix;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(panel3);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmKeyboard";
		base.Opacity = 1.0;
		base.TopMost = true;
		base.WindowState = FormWindowState.Maximized;
		base.Load += frmKeyboard_Load;
		base.Controls.SetChildIndex(panel3, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		panel2.ResumeLayout(performLayout: false);
		panel1.ResumeLayout(performLayout: false);
		panel3.ResumeLayout(performLayout: false);
		panel3.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
