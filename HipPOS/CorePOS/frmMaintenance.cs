using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorePOS.Business;
using CorePOS.Business.Enums;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmMaintenance : frmMasterForm
{
	private DataManager dataManager_0;

	private IContainer icontainer_1;

	private Label label9;

	private RadTextBoxControl txtQuestion;

	internal Button btnShowKeyboard_Question;

	private Label label1;

	private Label label11;

	private Label label2;

	private Class19 lyhNxejmDL;

	internal Button btnNew;

	internal Button btnCancel;

	internal Button btnSave;

	internal Button btnClose;

	private Label label15;

	private Label label3;

	internal ListView lstItems;

	private ColumnHeader columnHeader_0;

	internal ColumnHeader columnHeader_1;

	public frmMaintenance()
	{
		Class26.Ggkj0JxzN9YmC();
		dataManager_0 = new DataManager();
		base._002Ector();
		InitializeComponent_1();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnShowKeyboard_Question_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Question, 0, 512, ((Control)(object)txtQuestion).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtQuestion).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtQuestion_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void frmMaintenance_Load(object sender, EventArgs e)
	{
		lyhNxejmDL.Items.Add(SurveyAnswerTypes.ExecGoodAvePoor);
		lyhNxejmDL.Items.Add(SurveyAnswerTypes.YesNo);
		lyhNxejmDL.SelectedIndex = 0;
		method_3();
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		((Control)(object)txtQuestion).Text = string.Empty;
		lyhNxejmDL.SelectedIndex = 0;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (((Control)(object)txtQuestion).Text == "")
		{
			new frmMessageBox(Resources.The_question_should_not_be_emp).ShowDialog(this);
			return;
		}
		bool flag = false;
		foreach (ListViewItem item in lstItems.Items)
		{
			if (item.Text.ToUpper() == ((Control)(object)txtQuestion).Text.ToUpper())
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			dataManager_0.MaintenanceSave(((Control)(object)txtQuestion).Text, lyhNxejmDL.SelectedIndex, update: true);
		}
		else
		{
			dataManager_0.MaintenanceSave(((Control)(object)txtQuestion).Text, lyhNxejmDL.SelectedIndex);
		}
		method_3();
	}

	private void method_3()
	{
		lstItems.Items.Clear();
		foreach (Maintenance allMaintenance in dataManager_0.GetAllMaintenances())
		{
			string[] array = new string[2] { allMaintenance.Question, null };
			switch (allMaintenance.AnswerType)
			{
			case 1:
				array[1] = SurveyAnswerTypes.YesNo;
				break;
			case 0:
				array[1] = SurveyAnswerTypes.ExecGoodAvePoor;
				break;
			}
			lstItems.Items.Add(new ListViewItem(array));
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedItems.Count != 0)
		{
			dataManager_0.MaintenanceRemove(lstItems.SelectedItems[0].SubItems[0].Text);
			method_3();
		}
		else
		{
			new frmMessageBox(Resources.Please_select_a_question_to_re).ShowDialog(this);
		}
	}

	private void lstItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		if (lstItems.SelectedItems.Count != 0)
		{
			((Control)(object)txtQuestion).Text = lstItems.SelectedItems[0].SubItems[0].Text;
			lyhNxejmDL.Text = lstItems.SelectedItems[0].SubItems[1].Text;
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
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMaintenance));
		lstItems = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		label15 = new Label();
		label3 = new Label();
		btnClose = new Button();
		btnNew = new Button();
		btnCancel = new Button();
		btnSave = new Button();
		lyhNxejmDL = new Class19();
		label2 = new Label();
		label11 = new Label();
		txtQuestion = new RadTextBoxControl();
		btnShowKeyboard_Question = new Button();
		label1 = new Label();
		label9 = new Label();
		((ISupportInitialize)txtQuestion).BeginInit();
		SuspendLayout();
		lstItems.BorderStyle = BorderStyle.FixedSingle;
		lstItems.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		componentResourceManager.ApplyResources(lstItems, "lstItems");
		lstItems.FullRowSelect = true;
		lstItems.GridLines = true;
		lstItems.HeaderStyle = ColumnHeaderStyle.None;
		lstItems.HideSelection = false;
		lstItems.MultiSelect = false;
		lstItems.Name = "lstItems";
		lstItems.TileSize = new Size(20, 20);
		lstItems.UseCompatibleStateImageBehavior = false;
		lstItems.View = View.Details;
		lstItems.ItemSelectionChanged += lstItems_ItemSelectionChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "colQuestion");
		componentResourceManager.ApplyResources(columnHeader_1, "colAnswerType");
		label15.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label15, "label15");
		label15.ForeColor = Color.White;
		label15.Name = "label15";
		label3.BackColor = Color.FromArgb(50, 119, 155);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.FlatAppearance.BorderColor = Color.White;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.White;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		lyhNxejmDL.BackColor = Color.White;
		lyhNxejmDL.DrawMode = DrawMode.OwnerDrawVariable;
		lyhNxejmDL.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lyhNxejmDL, "cbbAnswerType");
		lyhNxejmDL.ForeColor = Color.FromArgb(40, 40, 40);
		lyhNxejmDL.FormattingEnabled = true;
		lyhNxejmDL.Name = "cbbAnswerType";
		lyhNxejmDL.Tag = "product";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label11.Tag = "5,5";
		componentResourceManager.ApplyResources(txtQuestion, "txtQuestion");
		((Control)(object)txtQuestion).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtQuestion).Name = "txtQuestion";
		((RadElement)((RadControl)txtQuestion).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtQuestion).Click += txtQuestion_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtQuestion).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtQuestion).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnShowKeyboard_Question.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Question.DialogResult = DialogResult.OK;
		btnShowKeyboard_Question.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Question.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Question, "btnShowKeyboard_Question");
		btnShowKeyboard_Question.ForeColor = Color.White;
		btnShowKeyboard_Question.Name = "btnShowKeyboard_Question";
		btnShowKeyboard_Question.UseVisualStyleBackColor = false;
		btnShowKeyboard_Question.Click += btnShowKeyboard_Question_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label9.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(lstItems);
		base.Controls.Add(label15);
		base.Controls.Add(label3);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnNew);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(lyhNxejmDL);
		base.Controls.Add(label2);
		base.Controls.Add(label11);
		base.Controls.Add((Control)(object)txtQuestion);
		base.Controls.Add(btnShowKeyboard_Question);
		base.Controls.Add(label1);
		base.Controls.Add(label9);
		base.Name = "frmMaintenance";
		base.Opacity = 1.0;
		base.Load += frmMaintenance_Load;
		((ISupportInitialize)txtQuestion).EndInit();
		ResumeLayout(performLayout: false);
	}
}
