using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmEditLayoutTableEdit : frmMasterForm
{
	private bool bool_0;

	private string string_0;

	private int int_0;

	private TransparentLabel transparentLabel_0;

	private string string_1;

	private GClass6 gclass6_0;

	private Layout layout_0;

	private List<Layout> list_2;

	private IContainer icontainer_1;

	private Label label1;

	private Label lblRotation;

	private Label label3;

	private Label label19;

	internal Button btnCancel;

	internal Button btnSave;

	private Label label4;

	private Class19 lstSections;

	private Label label5;

	internal Button btnEditSection;

	private Label lblTitle;

	private RadToggleSwitch chkTableIsActive;

	private RadTextBoxControl txtTableName;

	private RadTextBoxControl txtSection;

	private RadTextBoxControl txtNumberSeats;

	private Class19 lstShapes;

	private Label label6;

	internal Button btnShowKeyboard_Section;

	private RadTextBoxControl txtAngleOfRotation;

	private Label label2;

	internal Button btnShowKeyboard_TableName;

	internal Button btnShowKeyboard_NumberSeats;

	internal Button jfcAyOjrXR;

	public Layout AddedTable => layout_0;

	public string NewTableName => ((Control)(object)txtTableName).Text;

	public frmEditLayoutTableEdit(TransparentLabel _btnTable, List<Layout> _currentLayout, string title = "EDIT TABLE")
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = "";
		string_1 = "";
		gclass6_0 = new GClass6();
		list_2 = new List<Layout>();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		string_0 = _btnTable.Text;
		transparentLabel_0 = _btnTable;
		string_1 = ((Control)(object)txtSection).Text;
		lstShapes.SelectedIndex = 0;
		list_2 = _currentLayout;
		lblTitle.Text = title;
	}

	private void frmEditLayoutTableEdit_Load(object sender, EventArgs e)
	{
		method_4();
		if (string_0 != Resources.New_Table)
		{
			Layout layout = list_2.Where((Layout layout_1) => layout_1.TableName == string_0).FirstOrDefault();
			int_0 = layout.TableID;
			((Control)(object)txtTableName).Text = layout.TableName;
			lstSections.SelectedIndex = lstSections.FindStringExact(layout.Section.ToString());
			if (layout.Round)
			{
				lstShapes.SelectedIndex = 1;
				((Control)(object)txtAngleOfRotation).Enabled = false;
			}
			else
			{
				lstShapes.SelectedIndex = 0;
				((Control)(object)txtAngleOfRotation).Enabled = true;
				((Control)(object)txtAngleOfRotation).Text = layout.AngleOfRotation.ToString();
			}
			((Control)(object)txtNumberSeats).Text = layout.NumOfSeats.Value.ToString();
			chkTableIsActive.set_Value(layout.Active);
		}
		else
		{
			lstSections.SelectedIndex = 0;
			((Control)(object)txtAngleOfRotation).Text = "0";
			((Control)(object)txtNumberSeats).Text = "1";
			chkTableIsActive.set_Value(true);
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		int result;
		if (((Control)(object)txtTableName).Text.ToUpper().Contains("TABLE"))
		{
			new frmMessageBox(Resources.Please_do_not_include_the_word, Resources.NAMING_ERROR).ShowDialog(this);
		}
		else if (((Control)(object)txtTableName).Text.IndexOfAny(GlobalConstants.SpecialChars) != -1)
		{
			new frmMessageBox("Table name should not contain special characters.", Resources.NAMING_ERROR).ShowDialog(this);
		}
		else if (((Control)(object)txtTableName).Text.Length >= 19)
		{
			new frmMessageBox("Table name is too long.", Resources.NAMING_ERROR).ShowDialog(this);
		}
		else if (string.IsNullOrEmpty(((Control)(object)txtTableName).Text))
		{
			new frmMessageBox(Resources.Please_input_a_table_name, Resources.NAMING_ERROR).ShowDialog(this);
		}
		else if (((Control)(object)txtSection).Visible && string.IsNullOrEmpty(((Control)(object)txtSection).Text))
		{
			new frmMessageBox(Resources.Please_input_a_new_section_nam, Resources.SECTION_NAME_ERROR).ShowDialog(this);
		}
		else if (!string.IsNullOrEmpty(((Control)(object)txtNumberSeats).Text) && int.TryParse(((Control)(object)txtNumberSeats).Text, out result))
		{
			if (!method_3(int_0, ((Control)(object)txtTableName).Text))
			{
				new frmMessageBox(Resources.Table_name_has_already_been_us, Resources.DUPLICATE_TABLE_NAME).ShowDialog(this);
				return;
			}
			int num = Convert.ToInt32(((Control)(object)txtNumberSeats).Text);
			if (num < 1)
			{
				new frmMessageBox(Resources.Table_cannot_seat_less_than_1_, Resources.MINIMUM_REQUIREMENT).ShowDialog(this);
				return;
			}
			if (num > 30)
			{
				new frmMessageBox(Resources.Table_cannot_seat_more_than_30, Resources.MAXIMUM_REQUIREMENT).ShowDialog(this);
				return;
			}
			CS_0024_003C_003E8__locals0.SectionSelected = ((lstSections.SelectedItem.ToString() == "Add New") ? ((Control)(object)txtSection).Text : lstSections.SelectedItem.ToString());
			if (lstSections.SelectedItem.ToString() != "Add New" && ((Control)(object)txtSection).Text != string_1 && !string.IsNullOrEmpty(((Control)(object)txtSection).Text))
			{
				List<Layout> list = gclass6_0.Layouts.Where((Layout l) => l.Section == CS_0024_003C_003E8__locals0.SectionSelected).ToList();
				CS_0024_003C_003E8__locals0.SectionSelected = ((Control)(object)txtSection).Text;
				foreach (Layout item in list)
				{
					item.Section = CS_0024_003C_003E8__locals0.SectionSelected;
				}
			}
			if (int_0 == 0)
			{
				Layout layout = new Layout();
				layout.TableName = ((Control)(object)txtTableName).Text.Trim();
				layout.AngleOfRotation = Convert.ToInt32(((Control)(object)txtAngleOfRotation).Text);
				layout.Rotation = 'H';
				layout.Section = CS_0024_003C_003E8__locals0.SectionSelected;
				layout.NumOfSeats = num;
				layout.X = transparentLabel_0.Location.X;
				layout.Y = transparentLabel_0.Location.Y;
				layout.Active = chkTableIsActive.get_Value();
				layout.Round = bool_0;
				layout.TableID = 1;
				if (list_2 != null && list_2.Count > 0)
				{
					layout.TableID = list_2.Max((Layout l) => l.TableID) + 1;
				}
				gclass6_0.Layouts.InsertOnSubmit(layout);
				layout_0 = layout;
			}
			else
			{
				_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_1();
				CS_0024_003C_003E8__locals1.tableToEdit = list_2.Where((Layout l) => l.TableName == CS_0024_003C_003E8__locals0._003C_003E4__this.string_0).FirstOrDefault();
				if ((from a in new OrderMethods().OccupiedTables().ToList()
					where a.TableName == CS_0024_003C_003E8__locals1.tableToEdit.TableName
					select a).FirstOrDefault() != null || CS_0024_003C_003E8__locals1.tableToEdit.CurrentGuests != 0)
				{
					new frmMessageBox(Resources.Table_cannot_be_edited_Table_i, Resources.Edit_Error).ShowDialog(this);
					return;
				}
				CS_0024_003C_003E8__locals1.tableToEdit.TableName = ((Control)(object)txtTableName).Text;
				CS_0024_003C_003E8__locals1.tableToEdit.Section = CS_0024_003C_003E8__locals0.SectionSelected;
				CS_0024_003C_003E8__locals1.tableToEdit.AngleOfRotation = Convert.ToInt32(((Control)(object)txtAngleOfRotation).Text);
				CS_0024_003C_003E8__locals1.tableToEdit.Rotation = 'H';
				CS_0024_003C_003E8__locals1.tableToEdit.NumOfSeats = num;
				CS_0024_003C_003E8__locals1.tableToEdit.X = transparentLabel_0.Location.X;
				CS_0024_003C_003E8__locals1.tableToEdit.Y = transparentLabel_0.Location.Y;
				CS_0024_003C_003E8__locals1.tableToEdit.Active = chkTableIsActive.get_Value();
				CS_0024_003C_003E8__locals1.tableToEdit.Round = bool_0;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			new frmMessageBox(Resources.Please_input_a_whole_number_of, Resources.INVALID_NUMBER).ShowDialog(this);
		}
	}

	private bool method_3(int int_1, string string_2)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.TableName = string_2;
		CS_0024_003C_003E8__locals0.TableID = int_1;
		return list_2.Where((Layout l) => l.TableName.ToUpper() == CS_0024_003C_003E8__locals0.TableName.ToUpper() && l.TableID != CS_0024_003C_003E8__locals0.TableID).FirstOrDefault() == null;
	}

	private void method_4()
	{
		lstSections.Items.Clear();
		foreach (string item in new GClass6().Layouts.Select((Layout l) => l.Section).Distinct().ToList())
		{
			lstSections.Items.Add(item);
		}
		lstSections.Items.Add("Add New");
	}

	private void lstSections_SelectedIndexChanged(object sender, EventArgs e)
	{
		btnEditSection.Visible = true;
		string_1 = lstSections.SelectedItem.ToString();
		((Control)(object)txtSection).Text = "";
		if (lstSections.SelectedItem.ToString() == "Add New")
		{
			btnShowKeyboard_Section.Visible = true;
			((Control)(object)txtSection).Visible = true;
			((Control)(object)txtSection).Focus();
			btnEditSection.Visible = false;
		}
		else
		{
			btnShowKeyboard_Section.Visible = false;
			((Control)(object)txtSection).Visible = false;
			btnEditSection.Visible = true;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (((Control)(object)txtSection).Text == string_1)
		{
			((Control)(object)txtSection).ForeColor = Color.Black;
		}
		if (string_1 == "Add New")
		{
			((Control)(object)txtSection).Text = "";
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (((Control)(object)txtSection).Text == string.Empty)
		{
			if (lstSections.SelectedItem.ToString() == "Add New")
			{
				((Control)(object)txtSection).Text = Resources.Enter_Section_Name;
			}
			else
			{
				((Control)(object)txtSection).Text = string_1;
			}
			((Control)(object)txtSection).ForeColor = Color.Gray;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
	}

	private void btnEditSection_Click(object sender, EventArgs e)
	{
		btnEditSection.Visible = false;
		((Control)(object)txtSection).Visible = true;
		btnShowKeyboard_Section.Visible = true;
		if (string_1 == "Add New")
		{
			((Control)(object)txtSection).Text = "";
			((Control)(object)txtSection).Focus();
		}
		else
		{
			((Control)(object)txtSection).Text = string_1;
			((Control)(object)txtSection).Focus();
			txtSection.set_SelectionStart((((Control)(object)txtSection).Text.Length > 0) ? ((Control)(object)txtSection).Text.Length : 0);
			txtSection.set_SelectionLength(0);
		}
		base.DialogResult = DialogResult.None;
	}

	private void lstShapes_TextChanged(object sender, EventArgs e)
	{
		if (lstShapes.SelectedItem.ToString() == Resources.Circle)
		{
			bool_0 = true;
			((Control)(object)txtAngleOfRotation).Enabled = false;
			lblRotation.Enabled = false;
		}
		else
		{
			bool_0 = false;
			((Control)(object)txtAngleOfRotation).Enabled = true;
			lblRotation.Enabled = true;
		}
	}

	private void lblRotation_EnabledChanged(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		if (!label.Enabled)
		{
			label.BackColor = Color.Gray;
		}
		else
		{
			label.BackColor = Color.FromArgb(150, 166, 166);
		}
	}

	private void btnShowKeyboard_Section_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Section_Name, 1, 128, ((Control)(object)txtSection).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSection).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtTableName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowKeyboard_TableName_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Table_Name, 1, 18, ((Control)(object)txtTableName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtTableName).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void jfcAyOjrXR_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Angle_of_Rotation, 0, 3, ((Control)(object)txtAngleOfRotation).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtAngleOfRotation).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_NumberSeats_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_No_of_Seat, 0, 2, ((Control)(object)txtNumberSeats).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtNumberSeats).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmEditLayoutTableEdit));
		jfcAyOjrXR = new Button();
		btnShowKeyboard_NumberSeats = new Button();
		btnShowKeyboard_TableName = new Button();
		label2 = new Label();
		txtAngleOfRotation = new RadTextBoxControl();
		btnShowKeyboard_Section = new Button();
		lstShapes = new Class19();
		label6 = new Label();
		txtNumberSeats = new RadTextBoxControl();
		txtSection = new RadTextBoxControl();
		txtTableName = new RadTextBoxControl();
		chkTableIsActive = new RadToggleSwitch();
		lblTitle = new Label();
		btnEditSection = new Button();
		label5 = new Label();
		lstSections = new Class19();
		label4 = new Label();
		btnCancel = new Button();
		btnSave = new Button();
		label19 = new Label();
		label3 = new Label();
		lblRotation = new Label();
		label1 = new Label();
		((ISupportInitialize)txtAngleOfRotation).BeginInit();
		((ISupportInitialize)txtNumberSeats).BeginInit();
		((ISupportInitialize)txtSection).BeginInit();
		((ISupportInitialize)txtTableName).BeginInit();
		((ISupportInitialize)chkTableIsActive).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(jfcAyOjrXR, "btnShowKeyboard_AngleOfRotation");
		jfcAyOjrXR.BackColor = Color.FromArgb(77, 174, 225);
		jfcAyOjrXR.DialogResult = DialogResult.OK;
		jfcAyOjrXR.FlatAppearance.BorderColor = Color.Black;
		jfcAyOjrXR.FlatAppearance.BorderSize = 0;
		jfcAyOjrXR.ForeColor = Color.White;
		jfcAyOjrXR.Name = "btnShowKeyboard_AngleOfRotation";
		jfcAyOjrXR.UseVisualStyleBackColor = false;
		jfcAyOjrXR.Click += jfcAyOjrXR_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_NumberSeats, "btnShowKeyboard_NumberSeats");
		btnShowKeyboard_NumberSeats.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_NumberSeats.DialogResult = DialogResult.OK;
		btnShowKeyboard_NumberSeats.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_NumberSeats.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_NumberSeats.ForeColor = Color.White;
		btnShowKeyboard_NumberSeats.Name = "btnShowKeyboard_NumberSeats";
		btnShowKeyboard_NumberSeats.UseVisualStyleBackColor = false;
		btnShowKeyboard_NumberSeats.Click += btnShowKeyboard_NumberSeats_Click;
		componentResourceManager.ApplyResources(btnShowKeyboard_TableName, "btnShowKeyboard_TableName");
		btnShowKeyboard_TableName.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_TableName.DialogResult = DialogResult.OK;
		btnShowKeyboard_TableName.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_TableName.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_TableName.ForeColor = Color.White;
		btnShowKeyboard_TableName.Name = "btnShowKeyboard_TableName";
		btnShowKeyboard_TableName.UseVisualStyleBackColor = false;
		btnShowKeyboard_TableName.Click += btnShowKeyboard_TableName_Click;
		label2.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(txtAngleOfRotation, "txtAngleOfRotation");
		((Control)(object)txtAngleOfRotation).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtAngleOfRotation).Name = "txtAngleOfRotation";
		((RadElement)((RadControl)txtAngleOfRotation).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtAngleOfRotation).Tag = "product";
		txtAngleOfRotation.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtAngleOfRotation).Click += txtTableName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtAngleOfRotation).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtAngleOfRotation).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(btnShowKeyboard_Section, "btnShowKeyboard_Section");
		btnShowKeyboard_Section.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Section.DialogResult = DialogResult.OK;
		btnShowKeyboard_Section.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Section.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_Section.ForeColor = Color.White;
		btnShowKeyboard_Section.Name = "btnShowKeyboard_Section";
		btnShowKeyboard_Section.UseVisualStyleBackColor = false;
		btnShowKeyboard_Section.Click += btnShowKeyboard_Section_Click;
		lstShapes.BackColor = Color.White;
		lstShapes.DrawMode = DrawMode.OwnerDrawVariable;
		lstShapes.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lstShapes, "lstShapes");
		lstShapes.ForeColor = Color.FromArgb(40, 40, 40);
		lstShapes.FormattingEnabled = true;
		lstShapes.Items.AddRange(new object[2]
		{
			componentResourceManager.GetString("lstShapes.Items"),
			componentResourceManager.GetString("lstShapes.Items1")
		});
		lstShapes.Name = "lstShapes";
		lstShapes.TextChanged += lstShapes_TextChanged;
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		componentResourceManager.ApplyResources(txtNumberSeats, "txtNumberSeats");
		((Control)(object)txtNumberSeats).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtNumberSeats).Name = "txtNumberSeats";
		((RadElement)((RadControl)txtNumberSeats).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtNumberSeats).Tag = "product";
		txtNumberSeats.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtNumberSeats).Click += txtTableName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtNumberSeats).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtNumberSeats).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(txtSection, "txtSection");
		((Control)(object)txtSection).ForeColor = Color.Silver;
		((Control)(object)txtSection).Name = "txtSection";
		((RadElement)((RadControl)txtSection).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSection).Click += txtTableName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSection).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSection).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(txtTableName, "txtTableName");
		((Control)(object)txtTableName).ForeColor = Color.FromArgb(40, 40, 40);
		((Control)(object)txtTableName).Name = "txtTableName";
		((RadElement)((RadControl)txtTableName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtTableName).Click += txtTableName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtTableName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtTableName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(chkTableIsActive, "chkTableIsActive");
		((Control)(object)chkTableIsActive).Name = "chkTableIsActive";
		chkTableIsActive.set_OffText("NO");
		chkTableIsActive.set_OnText("YES");
		chkTableIsActive.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkTableIsActive).GetChildAt(0)).set_ThumbOffset(85);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTableIsActive).GetChildAt(0)).set_BorderWidth(1f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTableIsActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTableIsActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTableIsActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTableIsActive).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTableIsActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.BackColor = Color.FromArgb(156, 89, 184);
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		btnEditSection.BackColor = Color.FromArgb(77, 174, 225);
		componentResourceManager.ApplyResources(btnEditSection, "btnEditSection");
		btnEditSection.DialogResult = DialogResult.OK;
		btnEditSection.FlatAppearance.BorderColor = Color.Black;
		btnEditSection.FlatAppearance.BorderSize = 0;
		btnEditSection.ForeColor = Color.White;
		btnEditSection.Name = "btnEditSection";
		btnEditSection.UseVisualStyleBackColor = false;
		btnEditSection.Click += btnEditSection_Click;
		label5.BackColor = Color.LemonChiffon;
		label5.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(label5, "label5");
		label5.Name = "label5";
		lstSections.BackColor = Color.White;
		lstSections.DrawMode = DrawMode.OwnerDrawVariable;
		lstSections.DropDownStyle = ComboBoxStyle.DropDownList;
		componentResourceManager.ApplyResources(lstSections, "lstSections");
		lstSections.ForeColor = Color.FromArgb(40, 40, 40);
		lstSections.FormattingEnabled = true;
		lstSections.Items.AddRange(new object[2]
		{
			componentResourceManager.GetString("lstSections.Items"),
			componentResourceManager.GetString("lstSections.Items1")
		});
		lstSections.Name = "lstSections";
		lstSections.SelectedIndexChanged += lstSections_SelectedIndexChanged;
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		btnCancel.BackColor = Color.FromArgb(235, 107, 86);
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
		label19.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label19, "label19");
		label19.ForeColor = Color.White;
		label19.Name = "label19";
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		lblRotation.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblRotation, "lblRotation");
		lblRotation.ForeColor = Color.White;
		lblRotation.Name = "lblRotation";
		lblRotation.EnabledChanged += lblRotation_EnabledChanged;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(jfcAyOjrXR);
		base.Controls.Add(btnShowKeyboard_NumberSeats);
		base.Controls.Add(btnShowKeyboard_TableName);
		base.Controls.Add(label2);
		base.Controls.Add((Control)(object)txtAngleOfRotation);
		base.Controls.Add(btnShowKeyboard_Section);
		base.Controls.Add(lstShapes);
		base.Controls.Add(label6);
		base.Controls.Add((Control)(object)txtNumberSeats);
		base.Controls.Add((Control)(object)txtSection);
		base.Controls.Add((Control)(object)txtTableName);
		base.Controls.Add((Control)(object)chkTableIsActive);
		base.Controls.Add(lblTitle);
		base.Controls.Add(btnEditSection);
		base.Controls.Add(label5);
		base.Controls.Add(lstSections);
		base.Controls.Add(label4);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSave);
		base.Controls.Add(label19);
		base.Controls.Add(label3);
		base.Controls.Add(lblRotation);
		base.Controls.Add(label1);
		base.Name = "frmEditLayoutTableEdit";
		base.Opacity = 1.0;
		base.Load += frmEditLayoutTableEdit_Load;
		((ISupportInitialize)txtAngleOfRotation).EndInit();
		((ISupportInitialize)txtNumberSeats).EndInit();
		((ISupportInitialize)txtSection).EndInit();
		((ISupportInitialize)txtTableName).EndInit();
		((ISupportInitialize)chkTableIsActive).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private bool method_8(Layout layout_1)
	{
		return layout_1.TableName == string_0;
	}
}
