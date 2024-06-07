using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CorePOS.AdminPanel;

public class frmSortReasons : frmMasterForm
{
	private string string_0;

	private IContainer icontainer_1;

	private Button btnCancel;

	private Button btnOkay;

	private VScrollBar vScrollBar1;

	internal Button btnUp;

	internal ListView lstOptions;

	internal ColumnHeader columnHeader_0;

	private Label lblTItle;

	internal Button btnDown;

	public frmSortReasons(string reasonType)
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		// base._002Ector();
		InitializeComponent_1();
		string_0 = reasonType;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSortReasons));
		btnCancel = new Button();
		btnOkay = new Button();
		vScrollBar1 = new VScrollBar();
		btnUp = new Button();
		lstOptions = new ListView();
		columnHeader_0 = new ColumnHeader();
		lblTItle = new Label();
		btnDown = new Button();
		SuspendLayout();
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(307, 401);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(265, 80);
		btnCancel.TabIndex = 243;
		btnCancel.Text = "CLOSE";
		btnCancel.UseVisualStyleBackColor = false;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		btnOkay.FlatStyle = FlatStyle.Flat;
		btnOkay.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.ImeMode = ImeMode.NoControl;
		btnOkay.Location = new Point(1, 401);
		btnOkay.Name = "btnOkay";
		btnOkay.Size = new Size(305, 80);
		btnOkay.TabIndex = 242;
		btnOkay.Text = "SAVE";
		btnOkay.UseVisualStyleBackColor = false;
		vScrollBar1.ImeMode = ImeMode.NoControl;
		vScrollBar1.Location = new Point(483, 36);
		vScrollBar1.Name = "vScrollBar1";
		vScrollBar1.Size = new Size(38, 362);
		vScrollBar1.TabIndex = 247;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnUp.FlatStyle = FlatStyle.Flat;
		btnUp.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnUp.ForeColor = Color.White;
		btnUp.Image = (Image)componentResourceManager.GetObject("btnUp.Image");
		btnUp.ImeMode = ImeMode.NoControl;
		btnUp.Location = new Point(522, 36);
		btnUp.Margin = new Padding(0, 0, 0, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(50, 193);
		btnUp.TabIndex = 246;
		btnUp.Tag = "";
		btnUp.TextAlign = ContentAlignment.BottomCenter;
		btnUp.UseVisualStyleBackColor = false;
		lstOptions.BorderStyle = BorderStyle.None;
		lstOptions.Columns.AddRange(new ColumnHeader[1] { columnHeader_0 });
		lstOptions.Font = new Font("Microsoft Sans Serif", 14f);
		lstOptions.FullRowSelect = true;
		lstOptions.GridLines = true;
		lstOptions.HeaderStyle = ColumnHeaderStyle.None;
		lstOptions.HideSelection = false;
		lstOptions.Location = new Point(1, 36);
		lstOptions.MinimumSize = new Size(410, 350);
		lstOptions.MultiSelect = false;
		lstOptions.Name = "lstOptions";
		lstOptions.Size = new Size(520, 364);
		lstOptions.TabIndex = 245;
		lstOptions.TileSize = new Size(50, 200);
		lstOptions.UseCompatibleStateImageBehavior = false;
		lstOptions.View = View.Details;
		columnHeader_0.Text = "Item Name";
		columnHeader_0.Width = 480;
		lblTItle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTItle.BackColor = Color.FromArgb(147, 101, 184);
		lblTItle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTItle.ForeColor = Color.White;
		lblTItle.ImeMode = ImeMode.NoControl;
		lblTItle.Location = new Point(0, 0);
		lblTItle.Name = "lblTItle";
		lblTItle.Size = new Size(572, 35);
		lblTItle.TabIndex = 248;
		lblTItle.Text = "Option tags";
		lblTItle.TextAlign = ContentAlignment.MiddleCenter;
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnDown.FlatStyle = FlatStyle.Flat;
		btnDown.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnDown.ForeColor = Color.White;
		btnDown.Image = (Image)componentResourceManager.GetObject("btnDown.Image");
		btnDown.ImeMode = ImeMode.NoControl;
		btnDown.Location = new Point(522, 230);
		btnDown.Margin = new Padding(0, 0, 0, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new Size(50, 170);
		btnDown.TabIndex = 249;
		btnDown.Tag = "";
		btnDown.TextAlign = ContentAlignment.BottomCenter;
		btnDown.UseVisualStyleBackColor = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(576, 485);
		base.Controls.Add(btnDown);
		base.Controls.Add(lblTItle);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(vScrollBar1);
		base.Controls.Add(btnUp);
		base.Controls.Add(lstOptions);
		base.Name = "frmSortReasons";
		Text = "frmSortReasons";
		ResumeLayout(performLayout: false);
	}
}
