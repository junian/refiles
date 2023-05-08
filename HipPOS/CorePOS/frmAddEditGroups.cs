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
		product = ((((RadDropDownList)ddlSelectClassification).get_SelectedValue() != null) ? ((RadDropDownList)ddlSelectClassification).get_SelectedValue().ToString() : ItemClassifications.Product);
		Dictionary<string, string> groups = AdminMethods.getGroups(product, withShowItems: false);
		((RadDropDownList)comboGroup).set_DisplayMember("Value");
		((RadDropDownList)comboGroup).set_ValueMember("Key");
		((RadDropDownList)comboGroup).set_DataSource((object)new BindingSource(groups, null));
		((RadDropDownList)comboGroup).set_SelectedIndex(0);
	}

	private void method_4()
	{
		Dictionary<string, string> groups = AdminMethods.getGroups(((RadDropDownList)ddlSelectClassification).get_SelectedValue().ToString());
		groups.Remove("0");
		groups.Add("0", "- " + Resources.No_Parent_Group + " -");
		if (short_0 > 0)
		{
			groups.Remove(short_0.ToString());
		}
		((RadDropDownList)ddlParentGroups).set_DisplayMember("Value");
		((RadDropDownList)ddlParentGroups).set_ValueMember("Key");
		((RadDropDownList)ddlParentGroups).set_DataSource((object)new BindingSource(groups, null));
		((RadDropDownList)ddlParentGroups).set_SelectedIndex(0);
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		if (((Control)(object)txtName).Text.Trim() == string.Empty)
		{
			new frmMessageBox(Resources.Name_is_mandatory).ShowDialog(this);
			return;
		}
		if (((Control)(object)txtName).Text.Length > 50)
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
			if (AdminMethods.groupExistCheck(isNewGroup: false, ((Control)(object)txtName).Text.Trim(), ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString(), short_0))
			{
				new frmMessageBox(Resources.Group_name_already_exists_Plea).ShowDialog(this);
				return;
			}
			if (AdminMethods.groupDataAssignedCheck(short_0, ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString()))
			{
				new frmMessageBox("You cannot change classification of this group, there are still items/options assigned to it.").ShowDialog(this);
				return;
			}
			AdminMethods.updateGroup(short_0, ((Control)(object)txtName).Text, ((RadDropDownList)ddlColors).get_SelectedValue().ToString(), checkBoxHighTraffic.get_Value(), chkActive.get_Value(), Convert.ToInt16(((RadDropDownList)ddlParentGroups).get_SelectedValue()), ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString(), Convert.ToInt16(((Control)(object)txtSortOrder).Text), radToggleSwitch_0.get_Value(), chkShowInPatron.get_Value());
			((Control)(object)txtName).Text = string.Empty;
			method_3();
			new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
		}
		else
		{
			if (AdminMethods.groupExistCheck(isNewGroup: true, ((Control)(object)txtName).Text.Trim(), ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString()))
			{
				new frmMessageBox(Resources.Group_name_already_exists_Plea).ShowDialog(this);
				return;
			}
			AdminMethods.addNewGroup(((Control)(object)txtName).Text, ((RadDropDownList)ddlColors).get_SelectedValue().ToString(), checkBoxHighTraffic.get_Value(), chkActive.get_Value(), Convert.ToInt16(((RadDropDownList)ddlParentGroups).get_SelectedValue()), ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString(), Convert.ToInt16(((Control)(object)txtSortOrder).Text), radToggleSwitch_0.get_Value(), chkShowInPatron.get_Value());
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
		if (((RadDropDownList)comboGroup).get_SelectedIndex() == 0)
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
		if (((RadDropDownList)comboGroup).get_SelectedItem() != null)
		{
			keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
		}
		else
		{
			((RadDropDownList)comboGroup).set_SelectedValue((object)"0");
			keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
		}
		if (short.Parse(keyValuePair.Key) > 0)
		{
			Group groupFromID = AdminMethods.getGroupFromID(short.Parse(keyValuePair.Key));
			short_0 = groupFromID.GroupID;
			((Control)(object)txtName).Text = groupFromID.GroupName;
			((RadDropDownList)ddlColors).set_SelectedValue((object)groupFromID.GroupColor);
			checkBoxHighTraffic.set_Value(groupFromID.HighTraffic);
			chkActive.set_Value(groupFromID.Active);
			((Control)(object)txtSortOrder).Text = groupFromID.SortOrder.ToString();
			((RadDropDownList)ddlClassifications).set_SelectedValue((object)groupFromID.GroupClassification);
			radToggleSwitch_0.set_Value(groupFromID.OrderEntryShow);
			chkShowInPatron.set_Value(groupFromID.ShowInPatronKiosk);
			method_4();
			((RadDropDownList)ddlParentGroups).set_SelectedValue((object)groupFromID.ParentGroupID.ToString());
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter_Group_Name, 1, 49, ((Control)(object)txtName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtName).Text = MemoryLoadedObjects.Keyboard.textEntered;
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
		((Control)(object)txtName).Text = string.Empty;
		Dictionary<string, string> dictionary = HelperMethods.ButtonColors(Thread.CurrentThread.CurrentCulture.Name);
		dictionary.Remove("Red");
		dictionary.Remove("Salmon");
		((RadDropDownList)ddlColors).set_DisplayMember("Key");
		((RadDropDownList)ddlColors).set_ValueMember("Value");
		((RadDropDownList)ddlColors).set_DataSource((object)new BindingSource(dictionary, null));
		((RadDropDownList)ddlColors).set_SelectedValue((object)dictionary.FirstOrDefault((KeyValuePair<string, string> x) => x.Value == "150,166,166"));
		chkActive.set_Value(true);
		checkBoxHighTraffic.set_Value(false);
		((RadDropDownList)ddlClassifications).set_SelectedIndex(((RadDropDownList)ddlSelectClassification).get_SelectedIndex());
		RadToggleSwitch obj = radToggleSwitch_0;
		chkShowInPatron.set_Value(true);
		obj.set_Value(true);
	}

	private void method_8()
	{
		method_7();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(ItemClassifications.Product, Resources.product);
		dictionary.Add(ItemClassifications.Material, Resources.material);
		dictionary.Add(ItemClassifications.Option, Resources.option);
		((RadDropDownList)ddlClassifications).get_Items().Clear();
		((RadDropDownList)ddlClassifications).set_DisplayMember("Value");
		((RadDropDownList)ddlClassifications).set_ValueMember("Key");
		((RadDropDownList)ddlClassifications).set_DataSource((object)new BindingSource(dictionary, null));
		((RadDropDownList)ddlClassifications).set_SelectedValue((object)ItemClassifications.Product);
		((RadDropDownList)ddlSelectClassification).get_Items().Clear();
		((RadDropDownList)ddlSelectClassification).set_DisplayMember("Value");
		((RadDropDownList)ddlSelectClassification).set_ValueMember("Key");
		((RadDropDownList)ddlSelectClassification).set_DataSource((object)new BindingSource(dictionary, null));
		((RadDropDownList)ddlSelectClassification).set_SelectedValue((object)ItemClassifications.Product);
	}

	private void btnAddNew_Click(object sender, EventArgs e)
	{
		bool_0 = true;
		method_7();
		((RadDropDownList)comboGroup).set_SelectedIndex(0);
		method_9(bool_1: true);
		method_4();
	}

	private void ddlClassifications_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadToggleSwitch obj = radToggleSwitch_0;
		((Control)(object)chkShowInPatron).Enabled = true;
		((Control)(object)obj).Enabled = true;
	}

	private void method_9(bool bool_1)
	{
		((Control)(object)txtName).Enabled = bool_1;
		((Control)(object)ddlColors).Enabled = bool_1;
		((Control)(object)ddlClassifications).Enabled = bool_1;
		((Control)(object)ddlParentGroups).Enabled = bool_1;
		((Control)(object)chkActive).Enabled = bool_1;
		((Control)(object)checkBoxHighTraffic).Enabled = bool_1;
		btnShowKeyboard_Name.Enabled = bool_1;
		RadToggleSwitch obj = radToggleSwitch_0;
		bool enabled = (((Control)(object)chkShowInPatron).Enabled = bool_1);
		((Control)(object)obj).Enabled = enabled;
	}

	private void btnShowKeyboard_SortOrder_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Sort Order", 0, 6, ((Control)(object)txtSortOrder).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtSortOrder).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		if (bool_0 || short_0 == 0 || new frmMessageBox("Are you sure you want to delete this group?", "Delete Group", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No || (AdminMethods.groupDataAssignedCheck(short_0, ((RadDropDownList)ddlClassifications).get_SelectedValue().ToString()) && new frmMessageBox("This Group has still Data assigned to it. Deleting this group will unassociate data assigned to it. Do you want to continue?", "Delete Group Waning", CustomMessageBoxButtons.YesNo).ShowDialog() == DialogResult.No))
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_0c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7f: Expected O, but got Unknown
		//IL_0e55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_121d: Unknown result type (might be due to invalid IL or missing references)
		//IL_124a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13de: Unknown result type (might be due to invalid IL or missing references)
		//IL_140b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1438: Unknown result type (might be due to invalid IL or missing references)
		//IL_1465: Unknown result type (might be due to invalid IL or missing references)
		//IL_148c: Unknown result type (might be due to invalid IL or missing references)
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
		((Control)(object)txtName).Name = "txtName";
		((RadElement)((RadControl)txtName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtName).TextChanged += txtName_TextChanged;
		((Control)(object)txtName).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
		componentResourceManager.ApplyResources(checkBoxHighTraffic, "checkBoxHighTraffic");
		((Control)(object)checkBoxHighTraffic).Name = "checkBoxHighTraffic";
		checkBoxHighTraffic.set_OffText("NO");
		checkBoxHighTraffic.set_OnText("YES");
		checkBoxHighTraffic.set_ToggleStateMode((ToggleStateMode)1);
		checkBoxHighTraffic.set_Value(false);
		((RadToggleSwitchElement)((RadControl)checkBoxHighTraffic).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)checkBoxHighTraffic).GetChildAt(0)).set_BorderWidth(1f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)checkBoxHighTraffic).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)checkBoxHighTraffic).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)checkBoxHighTraffic).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)checkBoxHighTraffic).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)checkBoxHighTraffic).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		((Control)(object)chkActive).Name = "chkActive";
		chkActive.set_OffText("NO");
		chkActive.set_OnText("YES");
		chkActive.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_BorderWidth(1f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text1"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		lblSubTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSubTitle, "lblSubTitle");
		lblSubTitle.ForeColor = Color.White;
		lblSubTitle.Name = "lblSubTitle";
		componentResourceManager.ApplyResources(ddlClassifications, "ddlClassifications");
		((Control)(object)ddlClassifications).BackColor = Color.White;
		((RadDropDownList)ddlClassifications).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlClassifications).set_EnableKineticScrolling(true);
		((Control)(object)ddlClassifications).Name = "ddlClassifications";
		((RadElement)((RadControl)ddlClassifications).get_RootElement()).set_MinSize(new Size(250, 0));
		((RadControl)ddlClassifications).set_ThemeName("Windows8");
		((RadDropDownList)ddlClassifications).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlClassifications_SelectedIndexChanged));
		componentResourceManager.ApplyResources(ddlSelectClassification, "ddlSelectClassification");
		((Control)(object)ddlSelectClassification).BackColor = Color.White;
		((RadDropDownList)ddlSelectClassification).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlSelectClassification).set_EnableKineticScrolling(true);
		((Control)(object)ddlSelectClassification).Name = "ddlSelectClassification";
		((RadElement)((RadControl)ddlSelectClassification).get_RootElement()).set_MinSize(new Size(250, 0));
		((RadControl)ddlSelectClassification).set_ThemeName("Windows8");
		((RadDropDownList)ddlSelectClassification).add_SelectedIndexChanged(new PositionChangedEventHandler(ddlSelectClassification_SelectedIndexChanged));
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
		((Control)(object)ddlParentGroups).BackColor = Color.White;
		((RadDropDownList)ddlParentGroups).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlParentGroups).set_EnableKineticScrolling(true);
		((Control)(object)ddlParentGroups).Name = "ddlParentGroups";
		((RadControl)ddlParentGroups).set_ThemeName("Windows8");
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
		((Control)(object)ddlColors).BackColor = Color.White;
		((RadDropDownList)ddlColors).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlColors).set_EnableKineticScrolling(true);
		((Control)(object)ddlColors).Name = "ddlColors";
		((RadControl)ddlColors).set_ThemeName("Windows8");
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		((Control)(object)comboGroup).BackColor = Color.White;
		((RadDropDownList)comboGroup).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)comboGroup).set_EnableKineticScrolling(true);
		((Control)(object)comboGroup).Name = "comboGroup";
		((RadControl)comboGroup).set_ThemeName("Windows8");
		((RadDropDownList)comboGroup).add_SelectedIndexChanged(new PositionChangedEventHandler(comboGroup_SelectedIndexChanged));
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
		((Control)(object)txtSortOrder).Name = "txtSortOrder";
		((RadElement)((RadControl)txtSortOrder).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtSortOrder).Tag = "";
		txtSortOrder.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtSortOrder).Click += btnShowKeyboard_SortOrder_Click;
		((Control)(object)txtSortOrder).KeyPress += txtSortOrder_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtSortOrder).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtSortOrder).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
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
		((Control)(object)radToggleSwitch_0).Name = "chkOEShow";
		radToggleSwitch_0.set_OffText("NO");
		radToggleSwitch_0.set_OnText("YES");
		radToggleSwitch_0.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)radToggleSwitch_0).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)radToggleSwitch_0).GetChildAt(0)).set_BorderWidth(1f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)radToggleSwitch_0).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)radToggleSwitch_0).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)radToggleSwitch_0).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)radToggleSwitch_0).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text2"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)radToggleSwitch_0).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)chkShowInPatron).Name = "chkShowInPatron";
		chkShowInPatron.set_OffText("NO");
		chkShowInPatron.set_OnText("YES");
		chkShowInPatron.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkShowInPatron).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkShowInPatron).GetChildAt(0)).set_BorderWidth(1f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkShowInPatron).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkShowInPatron).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkShowInPatron).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkShowInPatron).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text3"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkShowInPatron).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add((Control)(object)chkShowInPatron);
		base.Controls.Add(label13);
		base.Controls.Add(label12);
		base.Controls.Add((Control)(object)radToggleSwitch_0);
		base.Controls.Add(label11);
		base.Controls.Add(btnSortGroups);
		base.Controls.Add(btnDeleteGroup);
		base.Controls.Add((Control)(object)txtSortOrder);
		base.Controls.Add(btnShowKeyboard_SortOrder);
		base.Controls.Add(label9);
		base.Controls.Add(btnAddNew);
		base.Controls.Add((Control)(object)txtName);
		base.Controls.Add((Control)(object)checkBoxHighTraffic);
		base.Controls.Add((Control)(object)chkActive);
		base.Controls.Add(lblSubTitle);
		base.Controls.Add((Control)(object)ddlClassifications);
		base.Controls.Add((Control)(object)ddlSelectClassification);
		base.Controls.Add(label7);
		base.Controls.Add(label5);
		base.Controls.Add(btnShowKeyboard_Name);
		base.Controls.Add(label15);
		base.Controls.Add((Control)(object)ddlParentGroups);
		base.Controls.Add(label4);
		base.Controls.Add(label10);
		base.Controls.Add(btnUpdate);
		base.Controls.Add(btnCancel);
		base.Controls.Add(label3);
		base.Controls.Add((Control)(object)ddlColors);
		base.Controls.Add((Control)(object)comboGroup);
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
