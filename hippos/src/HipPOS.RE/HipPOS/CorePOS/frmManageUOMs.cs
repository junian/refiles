using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmManageUOMs : frmMasterForm
{
	private IContainer icontainer_1;

	private Label label10;

	private Label label9;

	private Class19 class19_0;

	internal Button btnAdd;

	private Label label3;

	private Label label11;

	internal Button btnSave;

	internal Button btnClose;

	private FlowLayoutPanel pnlConversions;

	private Label lblAlert;

	private Label label1;

	internal Button btnRemove;

	internal Button btnAddConversion;

	private Timer timer_0;

	private RadToggleSwitch chkFractional;

	private RadTextBoxControl txtName;

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_3()
	{
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageUOMs));
		label10 = new Label();
		label9 = new Label();
		class19_0 = new Class19();
		btnAdd = new Button();
		label3 = new Label();
		label11 = new Label();
		btnSave = new Button();
		btnClose = new Button();
		pnlConversions = new FlowLayoutPanel();
		lblAlert = new Label();
		label1 = new Label();
		btnRemove = new Button();
		btnAddConversion = new Button();
		timer_0 = new Timer(icontainer_1);
		chkFractional = new RadToggleSwitch();
		txtName = new RadTextBoxControl();
		((ISupportInitialize)chkFractional).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label9.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		class19_0.BackColor = Color.White;
		class19_0.DrawMode = DrawMode.OwnerDrawVariable;
		class19_0.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(class19_0, "comboUOMs");
		class19_0.FormattingEnabled = true;
		class19_0.Name = "comboUOMs";
		btnAdd.BackColor = Color.FromArgb(1, 110, 211);
		btnAdd.FlatAppearance.BorderColor = Color.White;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = Color.White;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		label3.Tag = "product";
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(pnlConversions, "pnlConversions");
		pnlConversions.BorderStyle = BorderStyle.FixedSingle;
		pnlConversions.Name = "pnlConversions";
		lblAlert.BackColor = Color.FromArgb(242, 182, 51);
		componentResourceManager.ApplyResources(lblAlert, "lblAlert");
		lblAlert.ForeColor = Color.White;
		lblAlert.Name = "lblAlert";
		label1.BackColor = Color.LemonChiffon;
		label1.Cursor = Cursors.WaitCursor;
		label1.FlatStyle = FlatStyle.Flat;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.Name = "label1";
		btnRemove.BackColor = Color.SandyBrown;
		btnRemove.FlatAppearance.BorderColor = Color.White;
		btnRemove.FlatAppearance.BorderSize = 0;
		btnRemove.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnRemove, "btnRemove");
		btnRemove.ForeColor = Color.White;
		btnRemove.Name = "btnRemove";
		btnRemove.UseVisualStyleBackColor = false;
		btnAddConversion.BackColor = Color.FromArgb(1, 110, 211);
		btnAddConversion.FlatAppearance.BorderColor = Color.White;
		btnAddConversion.FlatAppearance.BorderSize = 0;
		btnAddConversion.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnAddConversion, "btnAddConversion");
		btnAddConversion.ForeColor = Color.White;
		btnAddConversion.Name = "btnAddConversion";
		btnAddConversion.UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(chkFractional, "chkFractional");
		chkFractional.Name = "chkFractional";
		chkFractional.OffText = "NO";
		chkFractional.OnText = "YES";
		chkFractional.ToggleStateMode = ToggleStateMode.Click;
		chkFractional.Value = false;
		((RadToggleSwitchElement)chkFractional.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkFractional.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkFractional.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkFractional.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkFractional.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkFractional.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkFractional.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(txtName);
		base.Controls.Add(chkFractional);
		base.Controls.Add(lblAlert);
		base.Controls.Add(btnAddConversion);
		base.Controls.Add(label1);
		base.Controls.Add(btnRemove);
		base.Controls.Add(pnlConversions);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnSave);
		base.Controls.Add(label11);
		base.Controls.Add(label3);
		base.Controls.Add(btnAdd);
		base.Controls.Add(label9);
		base.Controls.Add(class19_0);
		base.Controls.Add(label10);
		base.Name = "frmManageUOMs";
		base.Opacity = 1.0;
		((ISupportInitialize)chkFractional).EndInit();
		((ISupportInitialize)txtName).EndInit();
		ResumeLayout(performLayout: false);
	}

	public frmManageUOMs()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}
