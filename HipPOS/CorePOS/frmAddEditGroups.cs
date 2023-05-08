using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS;

public class frmAddEditGroups : frmMasterForm
{
	private short short_0;

	private bool bool_0;

	private IContainer icontainer_1;

	private Class20 comboGroup;

	private Label label8;

	internal Button btnCancel;

	internal Button btnUpdate;

	private Class20 ddlColors;

	private Label label6;

	private Label label2;

	private Label label1;

	private Label label10;

	private Label label3;

	private Class20 ddlParentGroups;

	private Label label4;

	internal Button btnShowKeyboard_Name;

	private Label label15;

	private Class20 ddlClassifications;

	private Label label7;

	private Class20 ddlSelectClassification;

	private Label label5;

	private Label lblSubTitle;

	private RadToggleSwitch chkActive;

	private RadToggleSwitch checkBoxHighTraffic;

	private RadTextBoxControl txtName;

	internal Button btnAddNew;

	private RadTextBoxControl txtSortOrder;

	internal Button btnShowKeyboard_SortOrder;

	private Label label9;

	internal Button btnDeleteGroup;

	internal Button btnSortGroups;

	private Label label11;

	private RadToggleSwitch radToggleSwitch_0;

	private Label label12;

	private Label label13;

	private RadToggleSwitch chkShowInPatron;

	public frmAddEditGroups()
	{
		Class26.Ggkj0JxzN9YmC();
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_8();
		}
		else
		{
			method_5();
		}
		method_9(bool_1: true);
	}

	private void frmAddEditGroups_Load(object sender, EventArgs e)
	{
		bool_0 = true;
		method_8();
		method_9(bool_1: true);
		method_4();
	}

	private void method_3()
	{
		string product = ItemClassifications.Product;
		product = ((ddlSelectClassification.SelectedValue != null) ? ddlSelectClassification.SelectedValue.ToString() : ItemClassifications.Product);
		Dictionary<string, string> groups = AdminMethods.getGroups(product, withShowItems: false);
		comboGroup.DisplayMember = "Value";
		comboGroup.ValueMember = "Key";
		comboGroup.DataSource = new BindingSource(groups, null);
		comboGroup.SelectedIndex = 0;
	}

	private void method_4()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(ddlSelectClassification.SelectedValue.ToString());
		groups.Remove("0");
		groups.Add("0", "- " + Resources.No_Parent_Group + " -");
		if (short_0 > 0)
		{
			groups.Remove(short_0.ToString());
		}
		ddlParentGroups.DisplayMember = "Value";
		ddlParentGroups.ValueMember = "Key";
		ddlParentGroups.DataSource = new BindingSource(groups, null);
		ddlParentGroups.SelectedIndex = 0;
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		if (txtName.Text.Trim() == string.Empty)
		{
			new frmMessageBox(Resources.Name_is_mandatory).ShowDialog(this);
			return;
		}
		if (txtName.Text.Length > 50)
		{
			new frmMessageBox("Group name is too long. Please shorten group name.").ShowDialog(this);
			return;
		}
		if (!bool_0)
		{
			if (short_0 == 0)
			{
				return;
			}
			if (AdminMethods.groupExistCheck(isNewGroup: false, txtName.Text.Trim(), ddlClassifications.SelectedValue.ToString(), short_0))
			{
				new frmMessageBox(Resources.Group_name_already_exists_Plea).ShowDialog(this);
				return;
			}
			if (AdminMethods.groupDataAssignedCheck(short_0, ddlClassifications.SelectedValue.ToString()))
			{
				new frmMessageBox("You cannot change classification of this group, there are still items/options assigned to it.").ShowDialog(this);
				return;
			}
			AdminMethods.updateGroup(short_0, txtName.Text, ddlColors.SelectedValue.ToString(), checkBoxHighTraffic.Value, chkActive.Value, Convert.ToInt16(ddlParentGroups.SelectedValue), ddlClassifications.SelectedValue.ToString(), Convert.ToInt16(txtSortOrder.Text), radToggleSwitch_0.Value, chkShowInPatron.Value);
			txtName.Text = string.Empty;
			method_3();
			new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
		}
		else
		{
			if (AdminMethods.groupExistCheck(isNewGroup: true, txtName.Text.Trim(), ddlClassifications.SelectedValue.ToString()))
			{
				new frmMessageBox(Resources.Group_name_already_exists_Plea).ShowDialog(this);
				return;
			}
			AdminMethods.addNewGroup(txtName.Text, ddlColors.SelectedValue.ToString(), checkBoxHighTraffic.Value, chkActive.Value, Convert.ToInt16(ddlParentGroups.SelectedValue), ddlClassifications.SelectedValue.ToString(), Convert.ToInt16(txtSortOrder.Text), radToggleSwitch_0.Value, chkShowInPatron.Value);
			method_3();
			new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
		}
		bool_0 = true;
		method_7();
		method_9(bool_1: true);
		MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
	}

	private void comboGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboGroup.SelectedIndex == 0)
		{
			bool_0 = true;
			method_7();
			method_9(bool_1: false);
		}
		else
		{
			bool_0 = false;
			method_9(bool_1: true);
		}
		method_5();
	}

	private void method_5()
	{
		KeyValuePair<string, string> keyValuePair;
		if (comboGroup.SelectedItem != null)
		{
			keyValuePair = (KeyValuePair<string, string>)comboGroup.SelectedItem.DataBoundItem;
		}
		else
		{
			comboGroup.SelectedValue = "0";
			keyValuePair = (KeyValuePair<string, string>)comboGroup.SelectedItem.DataBoundItem;
		}
		if (short.Parse(keyValuePair.Key) > 0)
		{
			Group groupFromID = AdminMethods.getGroupFromID(short.Parse(keyValuePair.Key));
			short_0 = groupFromID.GroupID;
			txtName.Text = groupFromID.GroupName;
			ddlColors.SelectedValue = groupFromID.GroupColor;
			checkBoxHighTraffic.Value = groupFromID.HighTraffic;
			chkActive.Value = groupFromID.Active;
			txtSortOrder.Text = groupFromID.SortOrder.ToString();
			ddlClassifications.SelectedValue = groupFromID.GroupClassification;
			radToggleSwitch_0.Value = groupFromID.OrderEntryShow;
			chkShowInPatron.Value = groupFromID.ShowInPatronKiosk;
			method_4();
			ddlParentGroups.SelectedValue = groupFromID.ParentGroupID.ToString();
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Group_Name, 1, 49, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void method_7()
	{
		txtName.Text = string.Empty;
		Dictionary<string, string> dictionary = HelperMethods.ButtonColors(Thread.CurrentThread.CurrentCulture.Name);
		dictionary.Remove("Red");
		dictionary.Remove("Salmon");
		ddlColors.DisplayMember = "Key";
		ddlColors.ValueMember = "Value";
		ddlColors.DataSource = new BindingSource(dictionary, null);
		ddlColors.SelectedValue = dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Value == "150,166,166");
		chkActive.Value = true;
		checkBoxHighTraffic.Value = false;
		ddlClassifications.SelectedIndex = ddlSelectClassification.SelectedIndex;
		RadToggleSwitch radToggleSwitch = radToggleSwitch_0;
		chkShowInPatron.Value = true;
		radToggleSwitch.Value = true;
	}

	private void method_8()
	{
		method_7();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(ItemClassifications.Product, Resources.product);
		dictionary.Add(ItemClassifications.Material, Resources.material);
		dictionary.Add(ItemClassifications.Option, Resources.option);
		ddlClassifications.Items.Clear();
		ddlClassifications.DisplayMember = "Value";
		ddlClassifications.ValueMember = "Key";
		ddlClassifications.DataSource = new BindingSource(dictionary, null);
		ddlClassifications.SelectedValue = ItemClassifications.Product;
		ddlSelectClassification.Items.Clear();
		ddlSelectClassification.DisplayMember = "Value";
		ddlSelectClassification.ValueMember = "Key";
		ddlSelectClassification.DataSource = new BindingSource(dictionary, null);
		ddlSelectClassification.SelectedValue = ItemClassifications.Product;
	}

	private void btnAddNew_Click(object sender, EventArgs e)
	{
		bool_0 = true;
		method_7();
		comboGroup.SelectedIndex = 0;
		method_9(bool_1: true);
		method_4();
	}

	private void ddlClassifications_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadToggleSwitch radToggleSwitch = radToggleSwitch_0;
		chkShowInPatron.Enabled = true;
		radToggleSwitch.Enabled = true;
	}

	private void method_9(bool bool_1)
	{
		txtName.Enabled = bool_1;
		ddlColors.Enabled = bool_1;
		ddlClassifications.Enabled = bool_1;
		ddlParentGroups.Enabled = bool_1;
		chkActive.Enabled = bool_1;
		checkBoxHighTraffic.Enabled = bool_1;
		btnShowKeyboard_Name.Enabled = bool_1;
		RadToggleSwitch radToggleSwitch = radToggleSwitch_0;
		bool enabled = (chkShowInPatron.Enabled = bool_1);
		radToggleSwitch.Enabled = enabled;
	}

	private void btnShowKeyboard_SortOrder_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Sort Order", 0, 6, txtSortOrder.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtSortOrder.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void label5_Click(object sender, EventArgs e)
	{
	}

	private void ddlSelectClassification_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		method_3();
	}

	private void label15_Click(object sender, EventArgs e)
	{
	}

	private void label10_Click(object sender, EventArgs e)
	{
	}

	private void txtName_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnDeleteGroup_Click(object sender, EventArgs e)
	{
		if (bool_0 || short_0 == 0 || new frmMessageBox("Are you sure you want to delete this group?", "Delete Group", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No || (AdminMethods.groupDataAssignedCheck(short_0, ddlClassifications.SelectedValue.ToString()) && new frmMessageBox("This Group has still Data assigned to it. Deleting this group will unassociate data assigned to it. Do you want to continue?", "Delete Group Waning", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No))
		{
			return;
		}
		GClass6 gClass = new GClass6();
		Group group = gClass.Groups.Where((Group a) => a.GroupID == short_0).FirstOrDefault();
		if (group != null)
		{
			group.Archived = true;
			group.Active = false;
			group.Synced = false;
			Helper.SubmitChangesWithCatch(gClass);
			List<Group> list = gClass.Groups.Where((Group a) => a.ParentGroupID == short_0).ToList();
			if (list.Count > 0)
			{
				foreach (Group item in list)
				{
					item.ParentGroupID = 0;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			List<ItemsWithOption> list2 = gClass.ItemsWithOptions.Where((ItemsWithOption a) => a.GroupID == short_0).ToList();
			if (list2.Count() > 0)
			{
				foreach (ItemsWithOption item2 in list2)
				{
					item2.GroupID = 0;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			AdminMethods.UnassociateItemsInGroup(short_0);
			AdminMethods.UnassociateItemsInGroupRecursion(short_0);
			new NotificationLabel(this, Resources.The_Group_is_successfully_dele, NotificationTypes.Success).Show();
			method_3();
			method_4();
			bool_0 = true;
			method_7();
			method_9(bool_1: true);
			MemoryLoadedObjects.ItemsAndGroupsStationsRefresh();
		}
		else
		{
			new NotificationLabel(this, "Group does not exist. Please select a group.", NotificationTypes.Warning).Show();
		}
	}

	private void btnSortGroups_Click(object sender, EventArgs e)
	{
		new frmEditGroupSortOrder().Show(this);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditGroups));
		btnAddNew = new Button();
		txtName = new RadTextBoxControl();
		checkBoxHighTraffic = new RadToggleSwitch();
		chkActive = new RadToggleSwitch();
		lblSubTitle = new Label();
		ddlClassifications = new Class20();
		ddlSelectClassification = new Class20();
		label7 = new Label();
		label5 = new Label();
		btnShowKeyboard_Name = new Button();
		label15 = new Label();
		ddlParentGroups = new Class20();
		label4 = new Label();
		label10 = new Label();
		btnUpdate = new Button();
		btnCancel = new Button();
		label3 = new Label();
		ddlColors = new Class20();
		comboGroup = new Class20();
		label6 = new Label();
		label8 = new Label();
		label2 = new Label();
		label1 = new Label();
		txtSortOrder = new RadTextBoxControl();
		btnShowKeyboard_SortOrder = new Button();
		label9 = new Label();
		btnDeleteGroup = new Button();
		btnSortGroups = new Button();
		label11 = new Label();
		radToggleSwitch_0 = new RadToggleSwitch();
		label12 = new Label();
		label13 = new Label();
		chkShowInPatron = new RadToggleSwitch();
		((ISupportInitialize)txtName).BeginInit();
		((ISupportInitialize)checkBoxHighTraffic).BeginInit();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)ddlClassifications).BeginInit();
		((ISupportInitialize)ddlSelectClassification).BeginInit();
		((ISupportInitialize)ddlParentGroups).BeginInit();
		((ISupportInitialize)ddlColors).BeginInit();
		((ISupportInitialize)comboGroup).BeginInit();
		((ISupportInitialize)txtSortOrder).BeginInit();
		((ISupportInitialize)radToggleSwitch_0).BeginInit();
		((ISupportInitialize)chkShowInPatron).BeginInit();
		SuspendLayout();
		btnAddNew.BackColor = Color.FromArgb(1, 110, 211);
		btnAddNew.DialogResult = DialogResult.OK;
		btnAddNew.FlatAppearance.BorderColor = Color.Black;
		btnAddNew.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddNew, "btnAddNew");
		btnAddNew.ForeColor = Color.White;
		btnAddNew.Name = "btnAddNew";
		btnAddNew.UseVisualStyleBackColor = false;
		btnAddNew.Click += btnAddNew_Click;
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.TextChanged += txtName_TextChanged;
		txtName.Click += txtName_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		componentResourceManager.ApplyResources(checkBoxHighTraffic, "checkBoxHighTraffic");
		checkBoxHighTraffic.Name = "checkBoxHighTraffic";
		checkBoxHighTraffic.OffText = "NO";
		checkBoxHighTraffic.OnText = "YES";
		checkBoxHighTraffic.ToggleStateMode = ToggleStateMode.Click;
		checkBoxHighTraffic.Value = false;
		((RadToggleSwitchElement)checkBoxHighTraffic.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)checkBoxHighTraffic.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)checkBoxHighTraffic.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)checkBoxHighTraffic.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)checkBoxHighTraffic.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)checkBoxHighTraffic.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)checkBoxHighTraffic.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		chkActive.Name = "chkActive";
		chkActive.OffText = "NO";
		chkActive.OnText = "YES";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text1");
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		lblSubTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSubTitle, "lblSubTitle");
		lblSubTitle.ForeColor = Color.White;
		lblSubTitle.Name = "lblSubTitle";
		componentResourceManager.ApplyResources(ddlClassifications, "ddlClassifications");
		ddlClassifications.BackColor = Color.White;
		ddlClassifications.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlClassifications.EnableKineticScrolling = true;
		ddlClassifications.Name = "ddlClassifications";
		ddlClassifications.RootElement.MinSize = new Size(250, 0);
		ddlClassifications.ThemeName = "Windows8";
		ddlClassifications.SelectedIndexChanged += ddlClassifications_SelectedIndexChanged;
		componentResourceManager.ApplyResources(ddlSelectClassification, "ddlSelectClassification");
		ddlSelectClassification.BackColor = Color.White;
		ddlSelectClassification.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlSelectClassification.EnableKineticScrolling = true;
		ddlSelectClassification.Name = "ddlSelectClassification";
		ddlSelectClassification.RootElement.MinSize = new Size(250, 0);
		ddlSelectClassification.ThemeName = "Windows8";
		ddlSelectClassification.SelectedIndexChanged += ddlSelectClassification_SelectedIndexChanged;
		label7.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		label5.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label5, "label5");
		label5.ForeColor = Color.White;
		label5.Name = "label5";
		label5.Click += label5_Click;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		label15.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(label15, "label15");
		label15.Name = "label15";
		label15.Click += label15_Click;
		componentResourceManager.ApplyResources(ddlParentGroups, "ddlParentGroups");
		ddlParentGroups.BackColor = Color.White;
		ddlParentGroups.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlParentGroups.EnableKineticScrolling = true;
		ddlParentGroups.Name = "ddlParentGroups";
		ddlParentGroups.ThemeName = "Windows8";
		label4.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label4, "label4");
		label4.ForeColor = Color.White;
		label4.Name = "label4";
		label10.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(label10, "label10");
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		label10.Click += label10_Click;
		btnUpdate.BackColor = Color.FromArgb(80, 203, 116);
		btnUpdate.FlatAppearance.BorderColor = Color.White;
		btnUpdate.FlatAppearance.BorderSize = 0;
		btnUpdate.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnUpdate, "btnUpdate");
		btnUpdate.ForeColor = Color.White;
		btnUpdate.Name = "btnUpdate";
		btnUpdate.UseVisualStyleBackColor = false;
		btnUpdate.Click += btnUpdate_Click;
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		label3.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(ddlColors, "ddlColors");
		ddlColors.BackColor = Color.White;
		ddlColors.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlColors.EnableKineticScrolling = true;
		ddlColors.Name = "ddlColors";
		ddlColors.ThemeName = "Windows8";
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		comboGroup.BackColor = Color.White;
		comboGroup.DropDownStyle = RadDropDownStyle.DropDownList;
		comboGroup.EnableKineticScrolling = true;
		comboGroup.Name = "comboGroup";
		comboGroup.ThemeName = "Windows8";
		comboGroup.SelectedIndexChanged += comboGroup_SelectedIndexChanged;
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		label2.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(txtSortOrder, "txtSortOrder");
		txtSortOrder.Name = "txtSortOrder";
		txtSortOrder.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtSortOrder.Tag = "";
		txtSortOrder.TextAlign = HorizontalAlignment.Center;
		txtSortOrder.Click += btnShowKeyboard_SortOrder_Click;
		txtSortOrder.KeyPress += txtSortOrder_KeyPress;
		((RadTextBoxControlElement)txtSortOrder.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtSortOrder.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		btnShowKeyboard_SortOrder.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_SortOrder.DialogResult = DialogResult.OK;
		btnShowKeyboard_SortOrder.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_SortOrder.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_SortOrder, "btnShowKeyboard_SortOrder");
		btnShowKeyboard_SortOrder.ForeColor = Color.White;
		btnShowKeyboard_SortOrder.Name = "btnShowKeyboard_SortOrder";
		btnShowKeyboard_SortOrder.UseVisualStyleBackColor = false;
		btnShowKeyboard_SortOrder.Click += btnShowKeyboard_SortOrder_Click;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label9.Tag = "product";
		btnDeleteGroup.BackColor = Color.FromArgb(235, 107, 86);
		btnDeleteGroup.FlatAppearance.BorderColor = Color.White;
		btnDeleteGroup.FlatAppearance.BorderSize = 0;
		btnDeleteGroup.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnDeleteGroup, "btnDeleteGroup");
		btnDeleteGroup.ForeColor = Color.White;
		btnDeleteGroup.Name = "btnDeleteGroup";
		btnDeleteGroup.UseVisualStyleBackColor = false;
		btnDeleteGroup.Click += btnDeleteGroup_Click;
		btnSortGroups.BackColor = Color.FromArgb(50, 119, 155);
		btnSortGroups.FlatAppearance.BorderColor = Color.White;
		btnSortGroups.FlatAppearance.BorderSize = 0;
		btnSortGroups.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSortGroups, "btnSortGroups");
		btnSortGroups.ForeColor = Color.White;
		btnSortGroups.Name = "btnSortGroups";
		btnSortGroups.UseVisualStyleBackColor = false;
		btnSortGroups.Click += btnSortGroups_Click;
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		componentResourceManager.ApplyResources(radToggleSwitch_0, "chkOEShow");
		radToggleSwitch_0.Name = "chkOEShow";
		radToggleSwitch_0.OffText = "NO";
		radToggleSwitch_0.OnText = "YES";
		radToggleSwitch_0.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)radToggleSwitch_0.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)radToggleSwitch_0.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text2");
		((ToggleSwitchPartElement)radToggleSwitch_0.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label12.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label12, "label12");
		label12.ForeColor = Color.White;
		label12.Name = "label12";
		label12.Tag = "product";
		label13.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label13, "label13");
		label13.ForeColor = Color.White;
		label13.Name = "label13";
		label13.Tag = "product";
		componentResourceManager.ApplyResources(chkShowInPatron, "chkShowInPatron");
		chkShowInPatron.Name = "chkShowInPatron";
		chkShowInPatron.OffText = "NO";
		chkShowInPatron.OnText = "YES";
		chkShowInPatron.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkShowInPatron.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkShowInPatron.GetChildAt(0)).BorderWidth = 1f;
		((ToggleSwitchPartElement)chkShowInPatron.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkShowInPatron.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowInPatron.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkShowInPatron.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text3");
		((ToggleSwitchPartElement)chkShowInPatron.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(chkShowInPatron);
		base.Controls.Add(label13);
		base.Controls.Add(label12);
		base.Controls.Add(radToggleSwitch_0);
		base.Controls.Add(label11);
		base.Controls.Add(btnSortGroups);
		base.Controls.Add(btnDeleteGroup);
		base.Controls.Add(txtSortOrder);
		base.Controls.Add(btnShowKeyboard_SortOrder);
		base.Controls.Add(label9);
		base.Controls.Add(btnAddNew);
		base.Controls.Add(txtName);
		base.Controls.Add(checkBoxHighTraffic);
		base.Controls.Add(chkActive);
		base.Controls.Add(lblSubTitle);
		base.Controls.Add(ddlClassifications);
		base.Controls.Add(ddlSelectClassification);
		base.Controls.Add(label7);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(label15);
		base.Controls.Add(ddlParentGroups);
		base.Controls.Add(label4);
		base.Controls.Add(label10);
		base.Controls.Add(btnUpdate);
		base.Controls.Add(btnCancel);
		base.Controls.Add(label3);
		base.Controls.Add(ddlColors);
		base.Controls.Add(comboGroup);
		base.Controls.Add(label6);
		base.Controls.Add(label8);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAddEditGroups";
		base.Opacity = 1.0;
		base.Load += frmAddEditGroups_Load;
		((ISupportInitialize)txtName).EndInit();
		((ISupportInitialize)checkBoxHighTraffic).EndInit();
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)ddlClassifications).EndInit();
		((ISupportInitialize)ddlSelectClassification).EndInit();
		((ISupportInitialize)ddlParentGroups).EndInit();
		((ISupportInitialize)ddlColors).EndInit();
		((ISupportInitialize)comboGroup).EndInit();
		((ISupportInitialize)txtSortOrder).EndInit();
		((ISupportInitialize)radToggleSwitch_0).EndInit();
		((ISupportInitialize)chkShowInPatron).EndInit();
		ResumeLayout(performLayout: false);
	}
}
