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

public class frmCustomTipSharing : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int tipId;

		public _003C_003Ec__DisplayClass3_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int tipId;

		public _003C_003Ec__DisplayClass4_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int tipId;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private IContainer icontainer_1;

	internal Button btnShowKeyboard_TipSharing;

	private RadTextBoxControl txtTipSharing;

	private Label label10;

	internal Button btnDelete;

	internal Button btnAddNew;

	internal Button btnUpdate;

	private PictureBox pictureBox1;

	private Label lblHeaderTitle;

	private Label label12;

	private RadTextBoxControl txtName;

	private Label label2;

	internal Button btnShowKeyboard_Name;

	private Class19 ddlTipSharing;

	private Label label1;

	private Label label6;

	private Label label3;

	private Class19 ddlTipShareType;

	public frmCustomTipSharing()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmCustomTipSharing_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		GClass6 gClass = new GClass6();
		Dictionary<string, string> dictionary = new Dictionary<string, string> { { "0", "+ Add New" } };
		foreach (CustomTipSharing customTipSharing in gClass.CustomTipSharings)
		{
			dictionary.Add(customTipSharing.Id.ToString(), customTipSharing.TipName);
		}
		ddlTipSharing.DisplayMember = "Value";
		ddlTipSharing.ValueMember = "Key";
		ddlTipSharing.DataSource = new BindingSource(dictionary, null);
	}

	private void ddlTipSharing_SelectedIndexChanged(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.tipId = Convert.ToInt32(ddlTipSharing.SelectedValue.ToString());
		if (CS_0024_003C_003E8__locals0.tipId == 0)
		{
			txtName.Text = "";
			txtTipSharing.Text = "";
			ddlTipShareType.SelectedIndex = 0;
			return;
		}
		CustomTipSharing customTipSharing = new GClass6().CustomTipSharings.Where((CustomTipSharing a) => a.Id == CS_0024_003C_003E8__locals0.tipId).FirstOrDefault();
		if (customTipSharing != null)
		{
			txtName.Text = customTipSharing.TipName;
			txtTipSharing.Text = customTipSharing.Percentage.ToString("0.00");
			ddlTipShareType.SelectedIndex = customTipSharing.TipShareType - 1;
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.tipId = Convert.ToInt32(ddlTipSharing.SelectedValue.ToString());
		if (string.IsNullOrEmpty(txtName.Text))
		{
			new NotificationLabel(this, "Please add a name.", NotificationTypes.Warning).Show();
			return;
		}
		if (string.IsNullOrEmpty(txtTipSharing.Text))
		{
			new NotificationLabel(this, "Please add a percentage.", NotificationTypes.Warning).Show();
			return;
		}
		decimal num = Convert.ToDecimal(txtTipSharing.Text);
		if (!(num > 100m) && !(num <= 0m))
		{
			GClass6 gClass = new GClass6();
			short num2 = 1;
			num2 = (short)((ddlTipShareType.Text == "Tips Collected") ? 1 : 2);
			if (CS_0024_003C_003E8__locals0.tipId == 0)
			{
				CustomTipSharing entity = new CustomTipSharing
				{
					TipName = txtName.Text,
					Percentage = num,
					TipShareType = num2
				};
				gClass.CustomTipSharings.InsertOnSubmit(entity);
				Helper.SubmitChangesWithCatch(gClass);
			}
			else
			{
				CustomTipSharing customTipSharing = gClass.CustomTipSharings.Where((CustomTipSharing a) => a.Id == CS_0024_003C_003E8__locals0.tipId).FirstOrDefault();
				if (customTipSharing != null)
				{
					customTipSharing.TipName = txtName.Text;
					customTipSharing.Percentage = num;
					customTipSharing.TipShareType = num2;
					Helper.SubmitChangesWithCatch(gClass);
				}
			}
			new NotificationLabel(this, "Sucessfully saved", NotificationTypes.Success).Show();
			MemoryLoadedObjects.RefreshCustomTipSharings();
			method_3();
		}
		else
		{
			new NotificationLabel(this, "Percentage can only be between 0-100", NotificationTypes.Warning).Show();
		}
	}

	private void btnAddNew_Click(object sender, EventArgs e)
	{
		ddlTipSharing.SelectedIndex = 0;
		base.DialogResult = DialogResult.None;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.tipId = Convert.ToInt32(ddlTipSharing.SelectedValue.ToString());
		if (CS_0024_003C_003E8__locals0.tipId > 0)
		{
			GClass6 gClass = new GClass6();
			CustomTipSharing customTipSharing = gClass.CustomTipSharings.Where((CustomTipSharing a) => a.Id == CS_0024_003C_003E8__locals0.tipId).FirstOrDefault();
			if (customTipSharing != null)
			{
				gClass.CustomTipSharings.DeleteOnSubmit(customTipSharing);
				Helper.SubmitChangesWithCatch(gClass);
			}
			new NotificationLabel(this, "Tip Sharing Removed.", NotificationTypes.Success).Show();
			method_3();
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Name", 0, 256, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtTipSharing_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Percentage", 2, 5, txtTipSharing.Text, "", allowNegative: false, useNotifLabel: true);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtTipSharing.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCustomTipSharing));
		btnShowKeyboard_TipSharing = new Button();
		txtTipSharing = new RadTextBoxControl();
		label10 = new Label();
		btnDelete = new Button();
		btnAddNew = new Button();
		btnUpdate = new Button();
		pictureBox1 = new PictureBox();
		lblHeaderTitle = new Label();
		label12 = new Label();
		txtName = new RadTextBoxControl();
		label2 = new Label();
		btnShowKeyboard_Name = new Button();
		ddlTipSharing = new Class19();
		label1 = new Label();
		label6 = new Label();
		label3 = new Label();
		ddlTipShareType = new Class19();
		((ISupportInitialize)txtTipSharing).BeginInit();
		((ISupportInitialize)pictureBox1).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		SuspendLayout();
		btnShowKeyboard_TipSharing.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_TipSharing.DialogResult = DialogResult.OK;
		btnShowKeyboard_TipSharing.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_TipSharing.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_TipSharing.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_TipSharing.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_TipSharing.ForeColor = Color.White;
		btnShowKeyboard_TipSharing.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_TipSharing.Image");
		btnShowKeyboard_TipSharing.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_TipSharing.Location = new Point(285, 148);
		btnShowKeyboard_TipSharing.Margin = new Padding(2);
		btnShowKeyboard_TipSharing.Name = "btnShowKeyboard_TipSharing";
		btnShowKeyboard_TipSharing.Size = new Size(52, 34);
		btnShowKeyboard_TipSharing.TabIndex = 275;
		btnShowKeyboard_TipSharing.UseVisualStyleBackColor = false;
		btnShowKeyboard_TipSharing.Click += txtTipSharing_Click;
		txtTipSharing.Font = new Font("Microsoft Sans Serif", 15.75f);
		txtTipSharing.Location = new Point(140, 149);
		txtTipSharing.MaxLength = 255;
		txtTipSharing.Name = "txtTipSharing";
		txtTipSharing.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtTipSharing.Size = new Size(115, 33);
		txtTipSharing.TabIndex = 274;
		txtTipSharing.Tag = "tip_kitchen";
		txtTipSharing.Click += txtTipSharing_Click;
		((RadTextBoxControlElement)txtTipSharing.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtTipSharing.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label10.BackColor = Color.FromArgb(132, 146, 146);
		label10.Font = new Font("Microsoft Sans Serif", 12f);
		label10.ForeColor = SystemColors.ButtonFace;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(4, 149);
		label10.Margin = new Padding(2, 0, 2, 0);
		label10.Name = "label10";
		label10.Padding = new Padding(3, 0, 0, 0);
		label10.Size = new Size(135, 33);
		label10.TabIndex = 273;
		label10.Text = "Percentage";
		label10.TextAlign = ContentAlignment.MiddleLeft;
		btnDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnDelete.FlatAppearance.BorderColor = Color.White;
		btnDelete.FlatAppearance.BorderSize = 0;
		btnDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnDelete.FlatStyle = FlatStyle.Flat;
		btnDelete.Font = new Font("Microsoft Sans Serif", 9f);
		btnDelete.ForeColor = Color.White;
		btnDelete.Image = (Image)componentResourceManager.GetObject("btnDelete.Image");
		btnDelete.ImeMode = ImeMode.NoControl;
		btnDelete.Location = new Point(4, 183);
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new Size(135, 80);
		btnDelete.TabIndex = 272;
		btnDelete.Text = "DELETE";
		btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		btnAddNew.BackColor = Color.FromArgb(1, 110, 211);
		btnAddNew.DialogResult = DialogResult.OK;
		btnAddNew.FlatAppearance.BorderColor = Color.Black;
		btnAddNew.FlatAppearance.BorderSize = 0;
		btnAddNew.FlatStyle = FlatStyle.Flat;
		btnAddNew.Font = new Font("Microsoft Sans Serif", 9f);
		btnAddNew.ForeColor = Color.White;
		btnAddNew.Image = (Image)componentResourceManager.GetObject("btnAddNew.Image");
		btnAddNew.ImeMode = ImeMode.NoControl;
		btnAddNew.Location = new Point(140, 183);
		btnAddNew.Name = "btnAddNew";
		btnAddNew.Size = new Size(144, 80);
		btnAddNew.TabIndex = 271;
		btnAddNew.Text = "NEW";
		btnAddNew.TextImageRelation = TextImageRelation.ImageAboveText;
		btnAddNew.UseVisualStyleBackColor = false;
		btnAddNew.Click += btnAddNew_Click;
		btnUpdate.BackColor = Color.FromArgb(80, 203, 116);
		btnUpdate.FlatAppearance.BorderColor = Color.White;
		btnUpdate.FlatAppearance.BorderSize = 0;
		btnUpdate.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnUpdate.FlatStyle = FlatStyle.Flat;
		btnUpdate.Font = new Font("Microsoft Sans Serif", 9f);
		btnUpdate.ForeColor = Color.White;
		btnUpdate.Image = (Image)componentResourceManager.GetObject("btnUpdate.Image");
		btnUpdate.ImeMode = ImeMode.NoControl;
		btnUpdate.Location = new Point(285, 183);
		btnUpdate.Margin = new Padding(4, 5, 4, 5);
		btnUpdate.Name = "btnUpdate";
		btnUpdate.Size = new Size(201, 80);
		btnUpdate.TabIndex = 270;
		btnUpdate.Text = "SAVE";
		btnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
		btnUpdate.UseVisualStyleBackColor = false;
		btnUpdate.Click += btnUpdate_Click;
		pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox1.BackColor = Color.FromArgb(156, 89, 184);
		pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		pictureBox1.ImeMode = ImeMode.NoControl;
		pictureBox1.Location = new Point(443, 6);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(44, 37);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 269;
		pictureBox1.TabStop = false;
		pictureBox1.Click += pictureBox1_Click;
		lblHeaderTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblHeaderTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblHeaderTitle.ForeColor = Color.White;
		lblHeaderTitle.ImeMode = ImeMode.NoControl;
		lblHeaderTitle.Location = new Point(4, 4);
		lblHeaderTitle.Name = "lblHeaderTitle";
		lblHeaderTitle.Size = new Size(482, 38);
		lblHeaderTitle.TabIndex = 268;
		lblHeaderTitle.Text = "Manage Custom Tips";
		lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
		label12.BackColor = Color.White;
		label12.Font = new Font("Microsoft Sans Serif", 15.75f);
		label12.ForeColor = Color.Black;
		label12.ImeMode = ImeMode.NoControl;
		label12.Location = new Point(254, 149);
		label12.Name = "label12";
		label12.Size = new Size(30, 33);
		label12.TabIndex = 276;
		label12.Text = "%";
		label12.TextAlign = ContentAlignment.MiddleRight;
		txtName.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtName.ForeColor = Color.FromArgb(40, 40, 40);
		txtName.Location = new Point(140, 113);
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.Size = new Size(293, 35);
		txtName.TabIndex = 281;
		txtName.Click += btnShowKeyboard_Name_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = SystemColors.ButtonFace;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(4, 113);
		label2.Margin = new Padding(2, 0, 2, 0);
		label2.Name = "label2";
		label2.Padding = new Padding(3, 0, 0, 0);
		label2.Size = new Size(135, 35);
		label2.TabIndex = 280;
		label2.Text = "Name";
		label2.TextAlign = ContentAlignment.MiddleLeft;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Name.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Name.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Name.Image");
		btnShowKeyboard_Name.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Name.Location = new Point(434, 113);
		btnShowKeyboard_Name.Margin = new Padding(2);
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.Size = new Size(52, 35);
		btnShowKeyboard_Name.TabIndex = 279;
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		ddlTipSharing.BackColor = Color.White;
		ddlTipSharing.DrawMode = DrawMode.OwnerDrawVariable;
		ddlTipSharing.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlTipSharing.FlatStyle = FlatStyle.Flat;
		ddlTipSharing.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlTipSharing.FormattingEnabled = true;
		ddlTipSharing.ItemHeight = 28;
		ddlTipSharing.Items.AddRange(new object[1] { "**Please Select A Field Name**" });
		ddlTipSharing.Location = new Point(140, 43);
		ddlTipSharing.Margin = new Padding(2);
		ddlTipSharing.Name = "ddlTipSharing";
		ddlTipSharing.Size = new Size(346, 34);
		ddlTipSharing.TabIndex = 278;
		ddlTipSharing.SelectedIndexChanged += ddlTipSharing_SelectedIndexChanged;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = SystemColors.ButtonFace;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(4, 43);
		label1.Margin = new Padding(2, 0, 2, 0);
		label1.Name = "label1";
		label1.Padding = new Padding(3, 0, 0, 0);
		label1.Size = new Size(135, 34);
		label1.TabIndex = 277;
		label1.Text = "Tip Sharing List";
		label1.TextAlign = ContentAlignment.MiddleLeft;
		label6.BackColor = Color.Gray;
		label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		label6.ForeColor = Color.White;
		label6.ImeMode = ImeMode.NoControl;
		label6.Location = new Point(338, 149);
		label6.Name = "label6";
		label6.Padding = new Padding(5, 0, 0, 0);
		label6.Size = new Size(148, 33);
		label6.TabIndex = 282;
		label6.TextAlign = ContentAlignment.MiddleLeft;
		label6.UseWaitCursor = true;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label3.ForeColor = SystemColors.ButtonFace;
		label3.ImeMode = ImeMode.NoControl;
		label3.Location = new Point(4, 78);
		label3.Margin = new Padding(2, 0, 2, 0);
		label3.Name = "label3";
		label3.Padding = new Padding(3, 0, 0, 0);
		label3.Size = new Size(135, 34);
		label3.TabIndex = 283;
		label3.Text = "Calculate Tip Share From";
		label3.TextAlign = ContentAlignment.MiddleLeft;
		ddlTipShareType.BackColor = Color.White;
		ddlTipShareType.DrawMode = DrawMode.OwnerDrawVariable;
		ddlTipShareType.DropDownStyle = ComboBoxStyle.DropDownList;
		ddlTipShareType.FlatStyle = FlatStyle.Flat;
		ddlTipShareType.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		ddlTipShareType.FormattingEnabled = true;
		ddlTipShareType.ItemHeight = 28;
		ddlTipShareType.Items.AddRange(new object[2] { "Tips Collected", "Net Sales" });
		ddlTipShareType.Location = new Point(140, 78);
		ddlTipShareType.Margin = new Padding(2);
		ddlTipShareType.Name = "ddlTipShareType";
		ddlTipShareType.Size = new Size(346, 34);
		ddlTipShareType.TabIndex = 284;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(490, 274);
		base.Controls.Add(ddlTipShareType);
		base.Controls.Add(label3);
		base.Controls.Add(label6);
		base.Controls.Add(txtName);
		base.Controls.Add(label2);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(ddlTipSharing);
		base.Controls.Add(label1);
		base.Controls.Add(label12);
		base.Controls.Add(btnShowKeyboard_TipSharing);
		base.Controls.Add(txtTipSharing);
		base.Controls.Add(label10);
		base.Controls.Add(btnDelete);
		base.Controls.Add(btnAddNew);
		base.Controls.Add(btnUpdate);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(lblHeaderTitle);
		base.Name = "frmCustomTipSharing";
		base.Opacity = 1.0;
		Text = "frmCustomTipSharing";
		base.Load += frmCustomTipSharing_Load;
		((ISupportInitialize)txtTipSharing).EndInit();
		((ISupportInitialize)pictureBox1).EndInit();
		((ISupportInitialize)txtName).EndInit();
		ResumeLayout(performLayout: false);
	}
}
