using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel;

public class frmSafeDropSettings : frmMasterForm
{
	private IContainer icontainer_1;

	private Label label2;

	private RadTextBoxControl txtTil;

	internal Button btnShowKeyboard_Til;

	private Label label1;

	private RadTextBoxControl txtBill;

	internal Button btnShowKeyboard_Bill;

	private Button btnCancel;

	private Button btnSave;

	private Label label9;

	public frmSafeDropSettings()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmSafeDropSettings_Load(object sender, EventArgs e)
	{
		((Control)(object)txtBill).Text = SettingsHelper.GetSettingValueByKey("safe_drop_bill");
		((Control)(object)txtTil).Text = SettingsHelper.GetSettingValueByKey("safe_drop_til");
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AkfFizZltLD(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		Setting setting = gClass.Settings.Where((Setting s) => s.Key.Equals("safe_drop_bill")).FirstOrDefault();
		if (setting != null)
		{
			setting.Value = ((Control)(object)txtBill).Text;
			gClass.SubmitChanges();
			SettingsHelper.SetSettingValueByKey("safe_drop_bill", setting.Value);
		}
		Setting setting2 = gClass.Settings.Where((Setting s) => s.Key.Equals("safe_drop_til")).FirstOrDefault();
		if (setting2 != null)
		{
			setting2.Value = ((Control)(object)txtTil).Text;
			gClass.SubmitChanges();
			SettingsHelper.SetSettingValueByKey("safe_drop_til", setting2.Value);
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnShowKeyboard_Bill_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Bill Greater than", 4, 8, ((Control)(object)txtBill).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtBill).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_Til_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Til Greater than", 4, 8, ((Control)(object)txtTil).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtTil).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSafeDropSettings));
		label2 = new Label();
		txtTil = new RadTextBoxControl();
		btnShowKeyboard_Til = new Button();
		label1 = new Label();
		txtBill = new RadTextBoxControl();
		btnShowKeyboard_Bill = new Button();
		btnCancel = new Button();
		btnSave = new Button();
		label9 = new Label();
		((ISupportInitialize)txtTil).BeginInit();
		((ISupportInitialize)txtBill).BeginInit();
		SuspendLayout();
		label2.BackColor = Color.FromArgb(132, 146, 146);
		label2.Font = new Font("Microsoft Sans Serif", 12f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(-1, 86);
		label2.Margin = new Padding(4, 0, 4, 0);
		label2.MinimumSize = new Size(120, 35);
		label2.Name = "label2";
		label2.Size = new Size(330, 35);
		label2.TabIndex = 247;
		label2.Text = "Cash Amount in Til Greater Than or Equal To:";
		label2.TextAlign = ContentAlignment.MiddleRight;
		((Control)(object)txtTil).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtTil).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtTil).Location = new Point(330, 86);
		((Control)(object)txtTil).Name = "txtTil";
		((RadElement)((RadControl)txtTil).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtTil).Size = new Size(116, 35);
		((Control)(object)txtTil).TabIndex = 246;
		((Control)(object)txtTil).Click += btnShowKeyboard_Til_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtTil).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtTil).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Til.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Til.DialogResult = DialogResult.OK;
		btnShowKeyboard_Til.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Til.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Til.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Til.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Til.ForeColor = Color.White;
		btnShowKeyboard_Til.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Til.Image");
		btnShowKeyboard_Til.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Til.Location = new Point(447, 86);
		btnShowKeyboard_Til.Name = "btnShowKeyboard_Til";
		btnShowKeyboard_Til.Size = new Size(51, 35);
		btnShowKeyboard_Til.TabIndex = 245;
		btnShowKeyboard_Til.UseVisualStyleBackColor = false;
		btnShowKeyboard_Til.Click += btnShowKeyboard_Til_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		label1.Font = new Font("Microsoft Sans Serif", 12f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(-1, 50);
		label1.Margin = new Padding(4, 0, 4, 0);
		label1.MinimumSize = new Size(120, 35);
		label1.Name = "label1";
		label1.Size = new Size(330, 35);
		label1.TabIndex = 244;
		label1.Text = "Notes Larger Than or Equal To:";
		label1.TextAlign = ContentAlignment.MiddleRight;
		((Control)(object)txtBill).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		((Control)(object)txtBill).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtBill).Location = new Point(330, 50);
		((Control)(object)txtBill).Name = "txtBill";
		((RadElement)((RadControl)txtBill).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtBill).Size = new Size(116, 35);
		((Control)(object)txtBill).TabIndex = 243;
		((Control)(object)txtBill).Click += btnShowKeyboard_Bill_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtBill).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtBill).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Bill.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Bill.DialogResult = DialogResult.OK;
		btnShowKeyboard_Bill.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Bill.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Bill.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_Bill.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_Bill.ForeColor = Color.White;
		btnShowKeyboard_Bill.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_Bill.Image");
		btnShowKeyboard_Bill.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_Bill.Location = new Point(447, 50);
		btnShowKeyboard_Bill.Name = "btnShowKeyboard_Bill";
		btnShowKeyboard_Bill.Size = new Size(51, 35);
		btnShowKeyboard_Bill.TabIndex = 242;
		btnShowKeyboard_Bill.UseVisualStyleBackColor = false;
		btnShowKeyboard_Bill.Click += btnShowKeyboard_Bill_Click;
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.DialogResult = DialogResult.OK;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = FlatStyle.Flat;
		btnCancel.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.ImeMode = ImeMode.NoControl;
		btnCancel.Location = new Point(263, 122);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(235, 80);
		btnCancel.TabIndex = 241;
		btnCancel.Text = "CLOSE";
		btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f);
		btnSave.ForeColor = SystemColors.ButtonFace;
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(0, 121);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(262, 80);
		btnSave.TabIndex = 240;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += AkfFizZltLD;
		label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label9.BackColor = Color.FromArgb(147, 101, 184);
		label9.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label9.ForeColor = Color.White;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(-1, 4);
		label9.Name = "label9";
		label9.Size = new Size(499, 46);
		label9.TabIndex = 239;
		label9.Text = "SAFE DROP SETTINGS";
		label9.TextAlign = ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(499, 205);
		base.Controls.Add(label2);
		base.Controls.Add((Control)(object)txtTil);
		base.Controls.Add(btnShowKeyboard_Til);
		base.Controls.Add(label1);
		base.Controls.Add((Control)(object)txtBill);
		base.Controls.Add(btnShowKeyboard_Bill);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label9);
		base.Name = "frmSafeDropSettings";
		base.Opacity = 1.0;
		Text = "frmSafeDropSettings";
		base.Load += frmSafeDropSettings_Load;
		((ISupportInitialize)txtTil).EndInit();
		((ISupportInitialize)txtBill).EndInit();
		ResumeLayout(performLayout: false);
	}
}
