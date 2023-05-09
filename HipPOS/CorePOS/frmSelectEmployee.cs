using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS;

public class frmSelectEmployee : frmMasterForm
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_1;

	private FlowLayoutPanel pnlMain;

	public Label lblTitle;

	private Panel panel1;

	private VerticalScrollControl verticalScrollControl1;

	private PictureBox btnClose;

	public string employeeName
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

	public int employeeID
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

	public frmSelectEmployee(bool showBtnClose = false, bool showNoEmployeeBtn = false, string Title = "Select Employee")
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		verticalScrollControl1.ConnectedPanel = pnlMain;
		btnClose.Visible = showBtnClose;
		lblTitle.Text = Title;
		bool_0 = showNoEmployeeBtn;
	}

	private void DobrfEaLxZ(object sender, EventArgs e)
	{
		List<Employee> list = (from x in new GClass6().Employees
			where x.isActive == true
			select x into y
			orderby y.FirstName
			select y).ToList();
		if (list.Count() > 0)
		{
			foreach (Employee item in list)
			{
				Button button = new Button();
				button.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Asphalt"]);
				button.FlatStyle = FlatStyle.Flat;
				button.TextAlign = ContentAlignment.MiddleCenter;
				button.FlatAppearance.BorderSize = 0;
				button.ForeColor = Color.White;
				button.Name = item.EmployeeID + "_" + item.FirstName + "_" + item.LastName;
				button.TextAlign = ContentAlignment.MiddleCenter;
				button.Font = new Font(button.Font.FontFamily, 12f, FontStyle.Regular);
				button.Text = item.FirstName + ((!string.IsNullOrEmpty(item.LastName)) ? (" " + item.LastName) : string.Empty);
				button.Size = new Size(133, 96);
				button.Padding = new Padding(5, 0, 5, 0);
				button.Click += method_3;
				button.Tag = item.EmployeeID;
				pnlMain.Controls.Add(button);
			}
			if (bool_0)
			{
				Button button2 = new Button();
				button2.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
				button2.FlatStyle = FlatStyle.Flat;
				button2.TextAlign = ContentAlignment.MiddleCenter;
				button2.FlatAppearance.BorderSize = 0;
				button2.ForeColor = Color.White;
				button2.Name = "0_No Employee";
				button2.TextAlign = ContentAlignment.MiddleCenter;
				button2.Font = new Font(button2.Font.FontFamily, 12f, FontStyle.Regular);
				button2.Text = "No Employee";
				button2.Size = new Size(133, 96);
				button2.Padding = new Padding(5, 0, 5, 0);
				button2.Click += method_3;
				button2.Tag = 0;
				pnlMain.Controls.Add(button2);
			}
		}
		else
		{
			employeeName = string.Empty;
			employeeID = 0;
			base.DialogResult = DialogResult.OK;
			Dispose();
			Close();
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if ((int)button.Tag != 0)
		{
			employeeName = button.Text;
			employeeID = (int)button.Tag;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSelectEmployee));
		pnlMain = new FlowLayoutPanel();
		lblTitle = new Label();
		panel1 = new Panel();
		btnClose = new PictureBox();
		verticalScrollControl1 = new VerticalScrollControl();
		panel1.SuspendLayout();
		((ISupportInitialize)btnClose).BeginInit();
		SuspendLayout();
		pnlMain.AutoScroll = true;
		pnlMain.Location = new Point(4, 44);
		pnlMain.Name = "pnlMain";
		pnlMain.Size = new Size(727, 408);
		pnlMain.TabIndex = 0;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(65, 168, 95);
		lblTitle.Font = new Font("Microsoft Sans Serif", 16f);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(0, 0);
		lblTitle.Margin = new Padding(0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(758, 40);
		lblTitle.TabIndex = 49;
		lblTitle.Text = "Select an Employee";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		panel1.BorderStyle = BorderStyle.FixedSingle;
		panel1.Controls.Add(btnClose);
		panel1.Controls.Add(verticalScrollControl1);
		panel1.Controls.Add(pnlMain);
		panel1.Controls.Add(lblTitle);
		panel1.Location = new Point(8, 8);
		panel1.Name = "panel1";
		panel1.Size = new Size(760, 457);
		panel1.TabIndex = 50;
		btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnClose.BackColor = Color.FromArgb(65, 168, 95);
		btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(717, 1);
		btnClose.Name = "btnClose";
		btnClose.Size = new Size(40, 37);
		btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
		btnClose.TabIndex = 236;
		btnClose.TabStop = false;
		btnClose.Click += btnClose_Click;
		verticalScrollControl1.BackColor = Color.FromArgb(95, 95, 95);
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(705, 44);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 406);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 406);
		verticalScrollControl1.TabIndex = 213;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(778, 468);
		base.Controls.Add(panel1);
		base.Name = "frmSelectEmployee";
		base.Opacity = 1.0;
		Text = "frmSelectInventoryBatch";
		base.Load += DobrfEaLxZ;
		panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)btnClose).EndInit();
		ResumeLayout(performLayout: false);
	}
}
