using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmCustomField : frmMasterForm
{
	public List<CustomFieldValueDisplay> itemCustomFieldValuesDisplay;

	private int int_0;

	private IContainer icontainer_1;

	private Label label9;

	private Button btnCancel;

	private Button btnOkay;

	internal Button YdhBknrOis;

	private Label label1;

	private Label label2;

	private Class19 listField;

	private Button btnAdd;

	private ListView listItemsCustomFieldValue;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private Button btnDeleteField;

	private Label label3;

	private RadTextBoxControl txtCustomField;

	public frmCustomField(int _itemID = 0, List<CustomFieldValueDisplay> _itemCustomFieldValuesDisplay = null)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		int_0 = _itemID;
		itemCustomFieldValuesDisplay = _itemCustomFieldValuesDisplay;
		method_3();
		method_4();
	}

	private void method_3()
	{
		IQueryable<CustomField> queryable = new GClass6().CustomFields.Select((CustomField tblCustomFields) => tblCustomFields);
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		foreach (CustomField item2 in queryable)
		{
			KeyValuePair<string, string> item = new KeyValuePair<string, string>(item2.CustomFieldId.ToString(), item2.Value);
			list.Add(item);
		}
		listField.DisplayMember = "Value";
		listField.ValueMember = "Key";
		listField.DataSource = new BindingSource(list, null);
	}

	private void method_4()
	{
		if (int_0 != 0 && itemCustomFieldValuesDisplay == null)
		{
			itemCustomFieldValuesDisplay = AdminMethods.getItemCustomField(int_0);
		}
		if (itemCustomFieldValuesDisplay == null)
		{
			return;
		}
		foreach (CustomFieldValueDisplay item in itemCustomFieldValuesDisplay)
		{
			ListViewItem value = new ListViewItem(new string[2] { item.FieldName, item.FieldValue });
			listItemsCustomFieldValue.Items.Add(value);
		}
	}

	private void frmCustomField_Load(object sender, EventArgs e)
	{
	}

	private void hbSaZohrtB(object sender, EventArgs e)
	{
		List<CustomFieldValueDisplay> list = new List<CustomFieldValueDisplay>();
		foreach (ListViewItem item2 in listItemsCustomFieldValue.Items)
		{
			CustomFieldValueDisplay item = new CustomFieldValueDisplay
			{
				FieldName = item2.SubItems[0].Text,
				FieldValue = item2.SubItems[1].Text
			};
			list.Add(item);
		}
		itemCustomFieldValuesDisplay = list;
		base.DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void YdhBknrOis_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Custom_Field_Value, 1, 128, txtCustomField.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtCustomField.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)listField.SelectedItem;
		if (keyValuePair.Key != "0" && txtCustomField.Text != "" && !method_5(keyValuePair.Value))
		{
			ListViewItem value = new ListViewItem(new string[2] { keyValuePair.Value, txtCustomField.Text });
			listItemsCustomFieldValue.Items.Add(value);
			btnAdd.Text = "Edit";
			return;
		}
		foreach (ListViewItem item in listItemsCustomFieldValue.Items)
		{
			if (item.SubItems[0].Text == keyValuePair.Value)
			{
				btnAdd.Text = "Edit";
				item.SubItems[1].Text = txtCustomField.Text;
			}
		}
	}

	private bool method_5(string string_0)
	{
		foreach (ListViewItem item in listItemsCustomFieldValue.Items)
		{
			if (item.SubItems[0].Text == string_0)
			{
				return true;
			}
		}
		return false;
	}

	private void btnDeleteField_Click(object sender, EventArgs e)
	{
		if (listItemsCustomFieldValue.SelectedItems.Count > 0)
		{
			listItemsCustomFieldValue.SelectedItems[0].Remove();
			btnAdd.Text = "Add";
		}
	}

	private void listItemsCustomFieldValue_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listItemsCustomFieldValue.SelectedItems.Count > 0)
		{
			btnAdd.Text = "Edit";
			txtCustomField.Text = listItemsCustomFieldValue.SelectedItems[0].SubItems[1].Text;
			listField.Text = listItemsCustomFieldValue.SelectedItems[0].SubItems[0].Text;
		}
	}

	private void listField_SelectedIndexChanged(object sender, EventArgs e)
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)listField.SelectedItem;
		if (!method_5(keyValuePair.Value))
		{
			btnAdd.Text = "Add";
			txtCustomField.Text = "";
			return;
		}
		foreach (ListViewItem item in listItemsCustomFieldValue.Items)
		{
			if (item.SubItems[0].Text == keyValuePair.Value)
			{
				btnAdd.Text = "Edit";
				txtCustomField.Text = item.SubItems[1].Text;
			}
		}
	}

	private void txtCustomField_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCustomField));
		label9 = new Label();
		btnCancel = new Button();
		btnOkay = new Button();
		YdhBknrOis = new Button();
		label1 = new Label();
		label2 = new Label();
		listField = new Class19();
		btnAdd = new Button();
		listItemsCustomFieldValue = new ListView();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		btnDeleteField = new Button();
		label3 = new Label();
		txtCustomField = new RadTextBoxControl();
		((ISupportInitialize)txtCustomField).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(label9, "label9");
		label9.BackColor = Color.FromArgb(156, 89, 184);
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
		btnCancel.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = SystemColors.ButtonFace;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		btnOkay.BackColor = Color.FromArgb(80, 203, 116);
		btnOkay.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnOkay, "btnOkay");
		btnOkay.ForeColor = SystemColors.ButtonFace;
		btnOkay.Name = "btnOkay";
		btnOkay.UseVisualStyleBackColor = false;
		btnOkay.Click += hbSaZohrtB;
		YdhBknrOis.BackColor = Color.FromArgb(77, 174, 225);
		YdhBknrOis.DialogResult = DialogResult.OK;
		YdhBknrOis.FlatAppearance.BorderColor = Color.Black;
		YdhBknrOis.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(YdhBknrOis, "btnShowKeyboard_CustomField");
		YdhBknrOis.ForeColor = Color.White;
		YdhBknrOis.Name = "btnShowKeyboard_CustomField";
		YdhBknrOis.UseVisualStyleBackColor = false;
		YdhBknrOis.Click += YdhBknrOis_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = SystemColors.ButtonFace;
		label1.Name = "label1";
		label2.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = SystemColors.ButtonFace;
		label2.Name = "label2";
		listField.BackColor = Color.White;
		listField.DrawMode = DrawMode.OwnerDrawVariable;
		listField.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(listField, "listField");
		listField.FormattingEnabled = true;
		listField.Items.AddRange(new object[1] { componentResourceManager.GetString("listField.Items") });
		listField.Name = "listField";
		listField.SelectedIndexChanged += listField_SelectedIndexChanged;
		btnAdd.BackColor = Color.FromArgb(61, 142, 185);
		btnAdd.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = SystemColors.ButtonFace;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += btnAdd_Click;
		listItemsCustomFieldValue.BackColor = Color.White;
		listItemsCustomFieldValue.BorderStyle = BorderStyle.None;
		listItemsCustomFieldValue.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		componentResourceManager.ApplyResources(listItemsCustomFieldValue, "listItemsCustomFieldValue");
		listItemsCustomFieldValue.ForeColor = Color.FromArgb(40, 40, 40);
		listItemsCustomFieldValue.FullRowSelect = true;
		listItemsCustomFieldValue.GridLines = true;
		listItemsCustomFieldValue.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listItemsCustomFieldValue.Name = "listItemsCustomFieldValue";
		listItemsCustomFieldValue.UseCompatibleStateImageBehavior = false;
		listItemsCustomFieldValue.View = View.Details;
		listItemsCustomFieldValue.SelectedIndexChanged += listItemsCustomFieldValue_SelectedIndexChanged;
		componentResourceManager.ApplyResources(columnHeader_0, "colFieldName");
		componentResourceManager.ApplyResources(columnHeader_1, "colFieldValue");
		btnDeleteField.BackColor = Color.SandyBrown;
		btnDeleteField.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDeleteField, "btnDeleteField");
		btnDeleteField.ForeColor = SystemColors.ButtonFace;
		btnDeleteField.Name = "btnDeleteField";
		btnDeleteField.UseVisualStyleBackColor = false;
		btnDeleteField.Click += btnDeleteField_Click;
		label3.BackColor = Color.LemonChiffon;
		label3.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.Name = "label3";
		componentResourceManager.ApplyResources(txtCustomField, "txtCustomField");
		txtCustomField.ForeColor = Color.FromArgb(40, 40, 40);
		txtCustomField.Name = "txtCustomField";
		txtCustomField.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtCustomField.Click += txtCustomField_Click;
		((RadTextBoxControlElement)txtCustomField.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtCustomField.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(txtCustomField);
		base.Controls.Add(label3);
		base.Controls.Add(btnDeleteField);
		base.Controls.Add(listItemsCustomFieldValue);
		base.Controls.Add(btnAdd);
		base.Controls.Add(listField);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(YdhBknrOis);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnOkay);
		base.Controls.Add(label9);
		base.Name = "frmCustomField";
		base.Opacity = 1.0;
		base.Load += frmCustomField_Load;
		((ISupportInitialize)txtCustomField).EndInit();
		ResumeLayout(performLayout: false);
	}
}
