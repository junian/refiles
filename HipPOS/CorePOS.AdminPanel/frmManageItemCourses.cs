using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS.AdminPanel;

public class frmManageItemCourses : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblTitle;

	private Label lblOrderType;

	private Label label1;

	private FlowLayoutPanel pnlItemCourses;

	internal Button btnExit;

	internal Button btnSave;

	public frmManageItemCourses()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageItemCourses_Load(object sender, EventArgs e)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		GClass6 gClass = new GClass6();
		pnlItemCourses.Controls.Clear();
		foreach (ItemCourse item in gClass.ItemCourses.ToList())
		{
			Label label = new Label();
			label.Name = "lbl" + item.Name;
			label.Size = new Size(253, 35);
			label.Margin = new Padding(0, 1, 0, 0);
			label.Text = item.Name;
			label.ForeColor = Color.White;
			label.BackColor = Color.FromArgb(132, 146, 146);
			label.FlatStyle = FlatStyle.Flat;
			label.BorderStyle = BorderStyle.None;
			label.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);
			label.Padding = new Padding(3, 3, 3, 3);
			pnlItemCourses.Controls.Add(label);
			RadTextBoxControl val = new RadTextBoxControl();
			((Control)(object)val).Name = "txt" + item.Name;
			((Control)(object)val).Size = new Size(189, 35);
			((Control)(object)val).Margin = new Padding(1, 1, 0, 0);
			((Control)(object)val).Text = item.OnHoldMinutes.ToString();
			((Control)(object)val).Click += method_3;
			((Control)(object)val).ForeColor = Color.Black;
			((Control)(object)val).Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular);
			((RadControl)val).set_Padding(new Padding(3, 3, 3, 3));
			((Control)(object)val).Tag = item.Name;
			pnlItemCourses.Controls.Add((Control)(object)val);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		RadTextBoxControl val = (RadTextBoxControl)((sender is RadTextBoxControl) ? sender : null);
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Delay On Hold for " + ((Control)(object)val).Tag.ToString(), 0, 3, ((Control)(object)val).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)val).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			GClass6 gClass = new GClass6();
			foreach (Control control in pnlItemCourses.Controls)
			{
				if (control is RadTextBoxControl)
				{
					_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
					CS_0024_003C_003E8__locals0.txtObj = (RadTextBoxControl)(object)((control is RadTextBoxControl) ? control : null);
					ItemCourse itemCourse = gClass.ItemCourses.Where((ItemCourse a) => a.Name == ((Control)(object)CS_0024_003C_003E8__locals0.txtObj).Tag.ToString()).FirstOrDefault();
					if (itemCourse != null)
					{
						itemCourse.OnHoldMinutes = Convert.ToInt32(((Control)(object)CS_0024_003C_003E8__locals0.txtObj).Text);
						gClass.SubmitChanges();
					}
				}
			}
			new NotificationLabel(this, "Courses saved.", NotificationTypes.Success).Show();
			base.DialogResult = DialogResult.None;
		}
		catch
		{
			new NotificationLabel(this, "Please Input a valid number.", NotificationTypes.Warning).Show();
			base.DialogResult = DialogResult.None;
		}
	}

	private void btnExit_Click(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageItemCourses));
		lblTitle = new Label();
		lblOrderType = new Label();
		label1 = new Label();
		pnlItemCourses = new FlowLayoutPanel();
		btnExit = new Button();
		btnSave = new Button();
		SuspendLayout();
		lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		lblTitle.ForeColor = Color.White;
		lblTitle.ImeMode = ImeMode.NoControl;
		lblTitle.Location = new Point(0, 0);
		lblTitle.Name = "lblTitle";
		lblTitle.Size = new Size(443, 35);
		lblTitle.TabIndex = 114;
		lblTitle.Text = "MANAGE ITEM COURSES";
		lblTitle.TextAlign = ContentAlignment.MiddleCenter;
		lblOrderType.BackColor = Color.FromArgb(61, 142, 185);
		lblOrderType.Font = new Font("Microsoft Sans Serif", 10f);
		lblOrderType.ForeColor = Color.White;
		lblOrderType.ImeMode = ImeMode.NoControl;
		lblOrderType.Location = new Point(0, 35);
		lblOrderType.Margin = new Padding(0, 0, 0, 1);
		lblOrderType.MinimumSize = new Size(0, 35);
		lblOrderType.Name = "lblOrderType";
		lblOrderType.Size = new Size(253, 35);
		lblOrderType.TabIndex = 141;
		lblOrderType.Text = "Item Course";
		lblOrderType.TextAlign = ContentAlignment.MiddleCenter;
		label1.BackColor = Color.FromArgb(61, 142, 185);
		label1.Font = new Font("Microsoft Sans Serif", 10f);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(254, 35);
		label1.Margin = new Padding(0, 0, 0, 1);
		label1.MinimumSize = new Size(0, 35);
		label1.Name = "label1";
		label1.Size = new Size(189, 35);
		label1.TabIndex = 142;
		label1.Text = "On Hold Delay";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		pnlItemCourses.Location = new Point(0, 69);
		pnlItemCourses.Name = "pnlItemCourses";
		pnlItemCourses.Size = new Size(443, 212);
		pnlItemCourses.TabIndex = 143;
		btnExit.BackColor = Color.FromArgb(235, 107, 86);
		btnExit.FlatAppearance.BorderColor = Color.White;
		btnExit.FlatAppearance.BorderSize = 0;
		btnExit.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnExit.FlatStyle = FlatStyle.Flat;
		btnExit.Font = new Font("Microsoft Sans Serif", 11f);
		btnExit.ForeColor = Color.White;
		btnExit.Image = (Image)componentResourceManager.GetObject("btnExit.Image");
		btnExit.ImageAlign = ContentAlignment.TopCenter;
		btnExit.ImeMode = ImeMode.NoControl;
		btnExit.Location = new Point(227, 282);
		btnExit.Name = "btnExit";
		btnExit.Padding = new Padding(0, 5, 0, 5);
		btnExit.Size = new Size(216, 87);
		btnExit.TabIndex = 260;
		btnExit.Text = "CLOSE";
		btnExit.TextAlign = ContentAlignment.BottomCenter;
		btnExit.UseVisualStyleBackColor = false;
		btnExit.Click += btnExit_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		btnSave.FlatStyle = FlatStyle.Flat;
		btnSave.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		btnSave.ForeColor = Color.White;
		btnSave.Image = (Image)componentResourceManager.GetObject("btnSave.Image");
		btnSave.ImeMode = ImeMode.NoControl;
		btnSave.Location = new Point(0, 281);
		btnSave.Margin = new Padding(4, 5, 4, 5);
		btnSave.Name = "btnSave";
		btnSave.Size = new Size(226, 88);
		btnSave.TabIndex = 259;
		btnSave.Text = "SAVE";
		btnSave.TextImageRelation = TextImageRelation.ImageAboveText;
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(442, 372);
		base.Controls.Add(btnExit);
		base.Controls.Add(btnSave);
		base.Controls.Add(label1);
		base.Controls.Add(lblOrderType);
		base.Controls.Add(lblTitle);
		base.Controls.Add(pnlItemCourses);
		base.Name = "frmManageItemCourses";
		base.Opacity = 1.0;
		Text = "frmManageItemCourses";
		base.Load += frmManageItemCourses_Load;
		ResumeLayout(performLayout: false);
	}
}
