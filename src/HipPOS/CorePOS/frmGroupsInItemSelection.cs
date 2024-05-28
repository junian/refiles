using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;

namespace CorePOS;

public class frmGroupsInItemSelection : frmMasterForm
{
	[CompilerGenerated]
	private int int_0;

	private int int_1;

	private short short_0;

	private short short_1;

	private string string_0;

	private IContainer icontainer_1;

	private Label lblTitle;

	private Panel pnlSelection;

	private PictureBox btnExit;

	private VerticalScrollControl verticalScrollControl1;

	public int returnItemId
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

	public frmGroupsInItemSelection(short _GroupId, string addedTitle = "")
	{
		Class26.Ggkj0JxzN9YmC();
		int_1 = 4;
		short_0 = 1;
		string_0 = "";
		// base._002Ector();
		InitializeComponent_1();
		short_1 = _GroupId;
		string_0 = addedTitle;
	}

	private void frmGroupsInItemSelection_Load(object sender, EventArgs e)
	{
		Group groupFromID = AdminMethods.getGroupFromID(short_1);
		lblTitle.Text = "Select " + groupFromID.GroupName + string_0;
		List<Item> list = new DataManager().GetItemsInGroup(short_1).ToList();
		if (list.Count > 16)
		{
			pnlSelection.Size = new Size(990, pnlSelection.Height);
		}
		else
		{
			pnlSelection.Size = new Size(972, pnlSelection.Height);
		}
		int num = 0;
		int num2 = 0;
		foreach (Item item in list)
		{
			method_3(item.ItemName.ToUpper(), num, num2, item.ItemID);
			if (num == int_1 - 1)
			{
				num2++;
				num = -1;
			}
			num++;
		}
		verticalScrollControl1.ConnectedPanel = pnlSelection;
	}

	private void method_3(string string_1, int int_2, int int_3, int int_4)
	{
		Button button = new Button();
		button.Name = int_4.ToString();
		button.Font = new Font("Arial", 9f, FontStyle.Regular);
		button.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gray"]);
		button.FlatStyle = FlatStyle.Flat;
		button.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		button.FlatAppearance.BorderColor = Color.White;
		button.FlatAppearance.BorderSize = 0;
		button.Margin = new Padding(1, 1, 1, 1);
		button.ForeColor = Color.White;
		int num = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlSelection.Width - 10) / (decimal)int_1)) - 4;
		int num2 = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(pnlSelection.Height - 12) / (decimal)int_1));
		button.Size = new Size(num, num2);
		button.Location = new Point(int_2 * num + (int_2 + 1) * short_0, int_3 * (num2 - 5) + (int_3 + 1) * short_0);
		button.Text = string_1.Replace("&", "&&");
		button.MouseDown += method_4;
		TransparentLabel transparentLabel = new TransparentLabel();
		transparentLabel.Text = button.Text;
		transparentLabel.Name = "Title " + button.Text;
		transparentLabel.transparentBackColor = Color.Black;
		transparentLabel.Size = new Size(button.Width, button.Height / 4);
		transparentLabel.Font = new Font(transparentLabel.Font.FontFamily, 8f);
		transparentLabel.ForeColor = Color.White;
		transparentLabel.BackColor = HelperMethods.GetColor("209, 72, 65");
		transparentLabel.FlatStyle = FlatStyle.Flat;
		transparentLabel.TextAlign = ContentAlignment.MiddleCenter;
		transparentLabel.Top = button.Height - button.Height / 4;
		transparentLabel.MinimumSize = new Size(transparentLabel.Width, 20);
		transparentLabel.Opacity = 80;
		button.Text = "";
		button.Controls.Add(transparentLabel);
		pnlSelection.Controls.Add(button);
	}

	private void method_4(object sender, MouseEventArgs e)
	{
		Button button = (Button)sender;
		returnItemId = Convert.ToInt32(button.Name);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnExit_Click(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmGroupsInItemSelection));
		verticalScrollControl1 = new VerticalScrollControl();
		btnExit = new PictureBox();
		lblTitle = new Label();
		pnlSelection = new Panel();
		((ISupportInitialize)btnExit).BeginInit();
		SuspendLayout();
		verticalScrollControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonDownEventOverride = null;
		verticalScrollControl1.ButtonLastEventOverride = null;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = null;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		verticalScrollControl1.Location = new Point(975, 41);
		verticalScrollControl1.MaximumSize = new Size(50, 2000);
		verticalScrollControl1.MinimumSize = new Size(50, 100);
		verticalScrollControl1.Name = "verticalScrollControl1";
		verticalScrollControl1.Size = new Size(50, 648);
		verticalScrollControl1.TabIndex = 238;
		btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btnExit.BackColor = Color.FromArgb(156, 89, 184);
		btnExit.Image = (Image)componentResourceManager.GetObject("btnExit.Image");
		btnExit.ImeMode = ImeMode.NoControl;
		btnExit.Location = new Point(985, 4);
		btnExit.Name = "btnExit";
		btnExit.Size = new Size(40, 35);
		btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
		btnExit.TabIndex = 237;
		btnExit.TabStop = false;
		btnExit.Click += btnExit_Click;
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(-1, 4);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(1026, 35);
		lblTitle.TabIndex = 232;
		lblTitle.Text = "SELECT OPTIONS";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		pnlSelection.AutoScroll = true;
		pnlSelection.BorderStyle = BorderStyle.FixedSingle;
		pnlSelection.Location = new Point(3, 43);
		pnlSelection.Margin = new Padding(4);
		pnlSelection.Name = "pnlSelection";
		pnlSelection.Size = new Size(972, 646);
		pnlSelection.TabIndex = 230;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1027, 692);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(btnExit);
		base.Controls.Add(lblTitle);
		base.Controls.Add(pnlSelection);
		base.Name = "frmGroupsInItemSelection";
		base.Opacity = 1.0;
		Text = "frmGroupsInItemSelection";
		base.Load += frmGroupsInItemSelection_Load;
		((ISupportInitialize)btnExit).EndInit();
		ResumeLayout(performLayout: false);
	}
}
