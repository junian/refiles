using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmManageCustomField : frmMasterForm
{
	private IContainer icontainer_1;

	private Label lblTitle;

	private Label label3;

	private Label label1;

	private ListView listCustomField;

	private Button btnDeleteField;

	private Button btnAdd;

	private Button btnDone;

	internal Button btnShowKeyboard_AddCustomField;

	private RadTextBoxControl txtField;

	private Button btnEdit;

	public frmManageCustomField()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmManageCustomField_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		listCustomField.Items.Clear();
		foreach (CustomField item in new GClass6().CustomFields.Select((CustomField tblCustomFields) => tblCustomFields))
		{
			listCustomField.Items.Add(item.Value);
		}
	}

	private bool method_4(string string_0)
	{
		foreach (CustomField item in new GClass6().CustomFields.Select((CustomField tblCustomFields) => tblCustomFields))
		{
			if (item.Value == string_0)
			{
				return true;
			}
		}
		return false;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		if (((Control)(object)txtField).Text != null && ((Control)(object)txtField).Text != "" && !method_4(((Control)(object)txtField).Text))
		{
			listCustomField.Items.Add(((Control)(object)txtField).Text);
			GClass6 gClass = new GClass6();
			CustomField entity = new CustomField
			{
				Value = ((Control)(object)txtField).Text
			};
			gClass.CustomFields.InsertOnSubmit(entity);
			try
			{
				Helper.SubmitChangesWithCatch(gClass);
				((Control)(object)txtField).Text = "";
				method_3();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnDeleteField_Click(object sender, EventArgs e)
	{
		if (listCustomField.SelectedItems.Count > 0)
		{
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.fieldToDelete = gClass.CustomFields.Where((CustomField c) => c.Value == listCustomField.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
			IEnumerable<ItemCustomFieldValue> enumerable = gClass.ItemCustomFieldValues.Where((ItemCustomFieldValue i) => i.CustomFieldId == CS_0024_003C_003E8__locals0.fieldToDelete.CustomFieldId);
			if (enumerable.Count() == 0)
			{
				gClass.CustomFields.DeleteOnSubmit(CS_0024_003C_003E8__locals0.fieldToDelete);
				try
				{
					Helper.SubmitChangesWithCatch(gClass);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				listCustomField.Items.Clear();
				method_3();
			}
			else
			{
				DialogResult dialogResult = new frmMessageBox(Resources.Warning_The_selected_Custom_Fi, Resources.WARNING, CustomMessageBoxButtons.YesNo).ShowDialog(this);
				if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.OK)
				{
					gClass.ItemCustomFieldValues.DeleteAllOnSubmit(enumerable);
					gClass.CustomFields.DeleteOnSubmit(CS_0024_003C_003E8__locals0.fieldToDelete);
					try
					{
						Helper.SubmitChangesWithCatch(gClass);
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
					}
					listCustomField.Items.Clear();
					method_3();
				}
			}
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnDone_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void btnShowKeyboard_AddCustomField_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Custom_Field, 1, 128, ((Control)(object)txtField).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtField).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtField_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnEdit_Click(object sender, EventArgs e)
	{
		if (listCustomField.SelectedItems.Count <= 0)
		{
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData("Edit Custom Field", 1, 128, listCustomField.SelectedItems[0].Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			GClass6 gClass = new GClass6();
			CustomField customField = gClass.CustomFields.Where((CustomField c) => c.Value == listCustomField.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
			customField.Value = MemoryLoadedObjects.Keyboard.textEntered;
			customField.Sycned = false;
			Helper.SubmitChangesWithCatch(gClass);
			((Control)(object)txtField).Text = "";
			method_3();
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
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManageCustomField));
		lblTitle = new Label();
		label3 = new Label();
		label1 = new Label();
		listCustomField = new ListView();
		btnDeleteField = new Button();
		btnAdd = new Button();
		btnDone = new Button();
		btnShowKeyboard_AddCustomField = new Button();
		txtField = new RadTextBoxControl();
		btnEdit = new Button();
		((ISupportInitialize)txtField).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		label3.BackColor = Color.LemonChiffon;
		label3.Cursor = Cursors.WaitCursor;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.Name = "label3";
		label3.UseWaitCursor = true;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = SystemColors.ButtonFace;
		label1.Name = "label1";
		listCustomField.BackColor = Color.White;
		listCustomField.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(listCustomField, "listCustomField");
		listCustomField.HideSelection = false;
		listCustomField.Name = "listCustomField";
		listCustomField.UseCompatibleStateImageBehavior = false;
		listCustomField.View = View.List;
		btnDeleteField.BackColor = Color.FromArgb(235, 107, 86);
		btnDeleteField.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDeleteField, "btnDeleteField");
		btnDeleteField.ForeColor = SystemColors.ButtonFace;
		btnDeleteField.Name = "btnDeleteField";
		btnDeleteField.UseVisualStyleBackColor = false;
		btnDeleteField.Click += btnDeleteField_Click;
		btnAdd.BackColor = Color.FromArgb(61, 142, 185);
		btnAdd.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = SystemColors.ButtonFace;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += btnAdd_Click;
		btnDone.BackColor = Color.FromArgb(80, 203, 116);
		btnDone.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDone, "btnDone");
		btnDone.ForeColor = SystemColors.ButtonFace;
		btnDone.Name = "btnDone";
		btnDone.UseVisualStyleBackColor = false;
		btnDone.Click += btnDone_Click;
		btnShowKeyboard_AddCustomField.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_AddCustomField.DialogResult = DialogResult.OK;
		btnShowKeyboard_AddCustomField.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_AddCustomField.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_AddCustomField, "btnShowKeyboard_AddCustomField");
		btnShowKeyboard_AddCustomField.ForeColor = Color.White;
		btnShowKeyboard_AddCustomField.Name = "btnShowKeyboard_AddCustomField";
		btnShowKeyboard_AddCustomField.UseVisualStyleBackColor = false;
		btnShowKeyboard_AddCustomField.Click += btnShowKeyboard_AddCustomField_Click;
		componentResourceManager.ApplyResources(txtField, "txtField");
		((Control)(object)txtField).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtField).Name = "txtField";
		((RadElement)((RadControl)txtField).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtField).Click += txtField_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtField).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtField).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		btnEdit.BackColor = Color.FromArgb(42, 102, 134);
		btnEdit.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnEdit, "btnEdit");
		btnEdit.ForeColor = SystemColors.ButtonFace;
		btnEdit.Name = "btnEdit";
		btnEdit.UseVisualStyleBackColor = false;
		btnEdit.Click += btnEdit_Click;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(btnEdit);
		base.Controls.Add((Control)(object)txtField);
		base.Controls.Add(btnShowKeyboard_AddCustomField);
		base.Controls.Add(btnDone);
		base.Controls.Add(btnAdd);
		base.Controls.Add(btnDeleteField);
		base.Controls.Add(listCustomField);
		base.Controls.Add(label1);
		base.Controls.Add(label3);
		base.Controls.Add(lblTitle);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmManageCustomField";
		base.Opacity = 1.0;
		base.Load += frmManageCustomField_Load;
		base.Controls.SetChildIndex(lblTitle, 0);
		base.Controls.SetChildIndex(label3, 0);
		base.Controls.SetChildIndex(label1, 0);
		base.Controls.SetChildIndex(listCustomField, 0);
		base.Controls.SetChildIndex(btnDeleteField, 0);
		base.Controls.SetChildIndex(btnAdd, 0);
		base.Controls.SetChildIndex(btnDone, 0);
		base.Controls.SetChildIndex(btnShowKeyboard_AddCustomField, 0);
		base.Controls.SetChildIndex((Control)(object)txtField, 0);
		base.Controls.SetChildIndex(PersistentNotification, 0);
		base.Controls.SetChildIndex(btnEdit, 0);
		((ISupportInitialize)txtField).EndInit();
		ResumeLayout(performLayout: false);
	}
}
