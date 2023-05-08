using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace CorePOS;

public class frmAddEditMaterials : frmMasterForm
{
	private int int_0;

	private string string_0;

	private string string_1;

	private bool bool_0;

	private List<CustomFieldValueDisplay> list_2;

	private List<ItemsInItemsField> list_3;

	private List<MaterialsInItem> list_4;

	private IContainer icontainer_1;

	internal Button btnCancel;

	internal Button btnSave;

	private Label label8;

	private Label label9;

	private Label label1;

	private Label lblTitleBar;

	private Label label11;

	private Label lblInvCount;

	internal Button btnShowKeyboard_InventoryQTY;

	internal Button btnShowKeyboard_Name;

	private Label label15;

	internal Button btnShowKeyboard_ItemCost;

	private Label label17;

	private Panel pnlGroups;

	private Label label18;

	private Button btnSearch;

	private Label label7;

	private Button btnShowItemAuditLogs;

	private Label lblSubTitle;

	private Panel pnlItemInfo;

	private RadTextBoxControl txtName;

	private RadToggleSwitch chkActive;

	private RadTextBoxControl txtItemCost;

	private RadTextBoxControl txtInventoryQTY;

	internal Button btnCopy;

	private RadTextBoxControl txtDescription;

	internal Button btnShowKeyboard_Description;

	private Label label25;

	internal Button btnNew;

	private RadTextBoxControl txtNotes;

	private Label label14;

	internal Button btnShowKeyboard_Notes;

	internal Button btnUOMConversion;

	internal Button btnDelete;

	private RadToggleSwitch chkTrackExpiry;

	private Label label26;

	private Class20 comboGroup;

	private Class20 comboItems;

	private Class20 ddlUOM;

	internal Button btnShowKeyboard_ResetQty;

	private RadTextBoxControl txtResetQty;

	private Label lblResetQty;

	private RadToggleSwitch chkAutoResetInv;

	private Label label29;

	private RadToggleSwitch chkDisableIfSoldOut;

	private Label lblInvDisable;

	public frmAddEditMaterials(int itemID = -1)
	{
		Class26.Ggkj0JxzN9YmC();
		string_1 = "Item";
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this, 2f);
		int_0 = itemID;
		if (itemID != -1)
		{
			bool_0 = true;
			btnCancel.Text = Resources.CLOSE;
		}
		string_0 = ItemClassifications.Material;
	}

	private void frmAddEditMaterials_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		if (!bool_0)
		{
			Dictionary<string, string> groups = AdminMethods.getGroups(string_0);
			comboGroup.DisplayMember = "Value";
			comboGroup.ValueMember = "Key";
			comboGroup.DataSource = new BindingSource(groups, null);
			comboGroup.SelectedIndex = 0;
		}
		else
		{
			lblSubTitle.Visible = false;
			pnlItemInfo.Location = new Point(pnlGroups.Location.X, pnlGroups.Location.Y);
			pnlGroups.Visible = false;
		}
		method_6(AdminMethods.getAllItemsDictionary(string_0));
		method_4();
		if (int_0 != -1)
		{
			method_11(bool_1: true);
		}
		btnShowItemAuditLogs.Visible = false;
		btnCopy.Visible = false;
		if (chkAutoResetInv.Value)
		{
			Label label = lblResetQty;
			RadTextBoxControl radTextBoxControl = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			radTextBoxControl.Visible = true;
			label.Visible = true;
		}
		else
		{
			Label label2 = lblResetQty;
			RadTextBoxControl radTextBoxControl2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			radTextBoxControl2.Visible = false;
			label2.Visible = false;
		}
	}

	private void method_4(int int_1 = 0)
	{
		UOMMethods uOMMethods = new UOMMethods();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (UOM uOM in uOMMethods.GetUOMs(int_1))
		{
			dictionary.Add(uOM.UOMID.ToString(), uOM.Name);
		}
		ddlUOM.DisplayMember = "Value";
		ddlUOM.ValueMember = "Key";
		ddlUOM.DataSource = new BindingSource(dictionary, null);
	}

	private void method_5(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (btnCancel.Text == Resources.CLOSE)
		{
			Close();
			base.DialogResult = DialogResult.Cancel;
		}
		else if (method_9())
		{
			comboGroup.SelectedIndex = 0;
			method_17();
		}
		else
		{
			method_11();
		}
	}

	private async void method_6(Dictionary<string, string> dictionary_0, bool bool_1 = false)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass13_.items = dictionary_0;
		_003C_003Ec__DisplayClass13_.search = bool_1;
		_003C_003Ec__DisplayClass13_.selectItem = Resources._Select_An_Item_To_Edit;
		Dictionary<string, string> dataSource = await Task.Run(() => _003C_003Ec__DisplayClass13_._003C_003E4__this.method_7(_003C_003Ec__DisplayClass13_.items, _003C_003Ec__DisplayClass13_.search, _003C_003Ec__DisplayClass13_.selectItem));
		comboItems.DisplayMember = "Value";
		comboItems.ValueMember = "Key";
		comboItems.DataSource = new BindingSource(dataSource, null);
	}

	private Dictionary<string, string> method_7(Dictionary<string, string> dictionary_0, bool bool_1, string string_2)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (!bool_1)
		{
			dictionary.Add("0", string_2);
		}
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	private void method_8()
	{
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)comboGroup.SelectedItem.DataBoundItem;
		List<Item> list = ((!(keyValuePair.Key == "0")) ? AdminMethods.getItemsFromGroup(Convert.ToInt16(keyValuePair.Key)) : AdminMethods.getAllItems(string_0));
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Item item in list)
		{
			dictionary.Add(item.ItemID.ToString(), item.ItemName);
		}
		method_6(dictionary);
	}

	private bool method_9()
	{
		if (int_0 > 0)
		{
			return false;
		}
		if (comboItems.SelectedItem != null && ((KeyValuePair<string, string>)comboItems.SelectedItem.DataBoundItem).Key == "0")
		{
			return true;
		}
		if (int_0 == -2)
		{
			return true;
		}
		return false;
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_10(bool bool_1 = true)
	{
		GClass6 gClass = new GClass6();
		if (method_9())
		{
			List<string> list = new List<string>();
			if (txtName.Text.Replace(" ", "") == string.Empty)
			{
				list.Add("Name");
			}
			if (txtItemCost.Text.Replace(" ", "") == string.Empty)
			{
				list.Add("Cost");
			}
			if (txtInventoryQTY.Text.Replace(" ", "") == string.Empty)
			{
				list.Add("Inventory Count");
			}
			if (list.Count > 0)
			{
				string text = "";
				if (list.Count >= 2)
				{
					string text2 = list[list.Count - 2];
					string text3 = list[list.Count - 1];
					list.Remove(list.Last());
					list.Remove(list.Last());
					string text4 = ((list.Count > 0) ? (string.Join(", ", list) + ", ") : "");
					text = text + text4 + text2 + Resources._and + text3 + Resources._are_mandatory;
				}
				else
				{
					text = list[0] + Resources._is_mandatory;
				}
				new frmMessageBox(Resources.Item0 + text, Resources.Invalid_Input).ShowDialog(this);
				return;
			}
			do
			{
				txtName.Text = txtName.Text.Replace("&&", "&");
			}
			while (txtName.Text.Contains("&&"));
			txtName.Text.Trim();
			if (txtItemCost.Text.Trim() == string.Empty)
			{
				txtItemCost.Text = "0";
			}
			try
			{
				if (AdminMethods.itemNameExistCheck(txtName.Text.Trim()))
				{
					new frmMessageBox(Resources.Item_name_already_exists_Pleas).ShowDialog(this);
					return;
				}
				AdminMethods.addNewItem(string.Empty, txtName.Text.Trim(), Convert.ToDecimal(txtItemCost.Text), 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, 9, string.Empty, 0, "150,166,166", chkActive.Value, Convert.ToDecimal(txtInventoryQTY.Text), chkDisableIfSoldOut.Value, Convert.ToInt16(ddlUOM.SelectedValue), trackInventory: true, string_0, txtDescription.Text, txtNotes.Text, "Uncategorized", -1, 0, chkTrackExpiry.Value, ApplySaleComboOption: false, chkAutoResetInv.Value, Convert.ToDecimal(txtResetQty.Text), RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m);
				Item item = gClass.Items.Where((Item tblItems) => tblItems.ItemName == txtName.Text).FirstOrDefault();
				if (list_2 != null)
				{
					AdminMethods.UpdateItemCustomField(item.ItemID, list_2);
				}
				if (list_4 != null)
				{
					AdminMethods.UpdateMaterialsInItems(list_4, item.ItemID);
				}
				if (chkTrackExpiry.Value && Convert.ToDecimal(txtInventoryQTY.Text) > 0m)
				{
					new frmAddInventoryBatches(item.ItemID, Convert.ToDecimal(txtInventoryQTY.Text)).ShowDialog(this);
				}
				new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
			}
			catch
			{
				new NotificationLabel(this, Resources.Please_make_sure_all_fields_ar, NotificationTypes.Notification).Show();
				return;
			}
		}
		else
		{
			List<string> list2 = new List<string>();
			if (txtName.Text == string.Empty)
			{
				list2.Add("Name");
			}
			if (txtItemCost.Text == string.Empty)
			{
				list2.Add("Cost");
			}
			if (txtInventoryQTY.Text == string.Empty)
			{
				list2.Add("Inventory Count");
			}
			if (list2.Count > 0)
			{
				string text5 = "";
				if (list2.Count >= 2)
				{
					string text6 = list2[list2.Count - 2];
					string text7 = list2[list2.Count - 1];
					list2.Remove(list2.Last());
					list2.Remove(list2.Last());
					string text8 = ((list2.Count > 0) ? (string.Join(", ", list2) + ", ") : "");
					text5 = text5 + text8 + text6 + Resources._and + text7;
				}
				else
				{
					text5 = list2[0];
				}
				new frmMessageBox(Resources.Item0 + text5 + Resources._are_mandatory, Resources.Invalid_Input).ShowDialog(this);
				return;
			}
			do
			{
				txtName.Text = txtName.Text.Replace("&&", "&");
			}
			while (txtName.Text.Contains("&&"));
			txtName.Text.Trim();
			if (int_0 == -1)
			{
				return;
			}
			if (txtItemCost.Text.Trim() == string.Empty)
			{
				txtItemCost.Text = "0";
			}
			try
			{
				if (AdminMethods.itemNameExistCheck(txtName.Text.Trim(), int_0))
				{
					new frmMessageBox(string_1 + Resources._name_already_exists_Please_en).ShowDialog(this);
					return;
				}
				Item item2 = gClass.Items.Where((Item i) => i.ItemID == int_0).FirstOrDefault();
				gClass.Refresh(RefreshMode.OverwriteCurrentValues, item2);
				string inventoryUpdateReason = Resources.Update_Item;
				decimal num = Convert.ToDecimal(txtInventoryQTY.Text);
				decimal inventoryCount = item2.InventoryCount;
				if (num != inventoryCount)
				{
					MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
					MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Add_a_Note_for_the_Inventory_U);
					if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
					{
						inventoryUpdateReason = MemoryLoadedObjects.Keyboard.textEntered;
					}
				}
				AdminMethods.updateItem(int_0, string.Empty, txtName.Text.Trim(), Convert.ToDecimal(txtItemCost.Text), 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, 9, string.Empty, 0, "150,166,166", chkActive.Value, num, chkDisableIfSoldOut.Value, Convert.ToInt16(ddlUOM.SelectedValue), trackInventory: true, string_0, txtDescription.Text, txtNotes.Text, "Uncategorized", -1, 0, chkTrackExpiry.Value, ApplySaleComboOption: false, 0, chkAutoResetInv.Value, Convert.ToDecimal(txtResetQty.Text), RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m, inventoryUpdateReason);
				new NotificationLabel(this, Resources.The_record_has_been_updated, NotificationTypes.Success).Show();
				if (list_2 != null)
				{
					AdminMethods.UpdateItemCustomField(int_0, list_2);
				}
				if (list_4 != null)
				{
					AdminMethods.UpdateMaterialsInItems(list_4, int_0);
				}
				if (!bool_0)
				{
					int_0 = -1;
					string selectedValue = comboItems.SelectedValue.ToString();
					comboItems.SelectedValue = selectedValue;
					method_11();
				}
				if (chkTrackExpiry.Value && num > inventoryCount)
				{
					new frmAddInventoryBatches(int_0, num - inventoryCount).ShowDialog(this);
				}
				if (chkTrackExpiry.Value && num < inventoryCount)
				{
					new frmReduceInventoryBatch(int_0, inventoryCount - num).Show(this);
				}
			}
			catch
			{
				new NotificationLabel(this, Resources.Please_make_sure_all_fields_ar, NotificationTypes.Notification).Show();
				return;
			}
		}
		if (bool_1 && !bool_0)
		{
			method_6(AdminMethods.getAllItemsDictionary(string_0));
			comboGroup_SelectedIndexChanged(null, null);
		}
	}

	private void LoNoDokEZ(object sender, EventArgs e)
	{
		method_11();
	}

	private void method_11(bool bool_1 = false)
	{
		string_1 = "Item";
		if (!bool_1 && comboItems.SelectedIndex > -1)
		{
			int_0 = int.Parse(((KeyValuePair<string, string>)comboItems.SelectedItem.DataBoundItem).Key);
		}
		if (int_0 <= 0)
		{
			method_17();
			return;
		}
		btnShowItemAuditLogs.Visible = true;
		Button button = btnCopy;
		Button button2 = btnUOMConversion;
		btnDelete.Visible = true;
		button2.Visible = true;
		button.Visible = true;
		Item oneItem = AdminMethods.getOneItem(int_0);
		method_4(oneItem.ItemID);
		if (oneItem != null)
		{
			method_12(oneItem);
		}
	}

	private void method_12(Item item_0)
	{
		GClass6 gClass = new GClass6();
		try
		{
			txtName.Text = item_0.ItemName;
			txtItemCost.Text = item_0.ItemCost.ToString();
			chkActive.Value = item_0.Active;
			txtInventoryQTY.Text = ((item_0.InventoryCount % 1m == 0m) ? MathHelper.RemoveTrailingZeros(item_0.InventoryCount.ToString()) : item_0.InventoryCount.ToString());
			if (item_0.UOMID == 1 || item_0.UOMID == 5 || item_0.UOMID == 6)
			{
				txtInventoryQTY.Text = Math.Round(item_0.InventoryCount, 0).ToString();
			}
			ddlUOM.SelectedValue = item_0.UOMID.ToString();
			list_2 = null;
			btnSave.Enabled = true;
			txtDescription.Text = item_0.Description;
			txtNotes.Text = item_0.Notes;
			chkTrackExpiry.Value = item_0.TrackExpiryDate;
			chkAutoResetInv.Value = item_0.AutoResetQty;
			txtResetQty.Text = item_0.ResetQty.ToString("0.00");
			chkDisableIfSoldOut.Value = item_0.DisableSoldOutItems;
			List<ItemsInItem> list = gClass.ItemsInItems.Where((ItemsInItem tblItemsInItems) => tblItemsInItems.ParentItemID == (int?)int_0).ToList();
			if (list.Count != 0)
			{
				List<ItemsInItemsField> list2 = new List<ItemsInItemsField>();
				using (List<ItemsInItem>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
						CS_0024_003C_003E8__locals0.itemChild = enumerator.Current;
						AdminMethods.getOneItem(CS_0024_003C_003E8__locals0.itemChild.ItemID.Value);
						_ = CS_0024_003C_003E8__locals0.itemChild.Quantity.Value;
						ItemsInItemsField itemsInItemsField = new ItemsInItemsField();
						itemsInItemsField.ItemName = gClass.Items.Where((Item i) => (int?)i.ItemID == CS_0024_003C_003E8__locals0.itemChild.ItemID).FirstOrDefault().ItemName;
						itemsInItemsField.qty = CS_0024_003C_003E8__locals0.itemChild.Quantity.Value;
						ItemsInItemsField item = itemsInItemsField;
						list2.Add(item);
					}
				}
				list_3 = list2;
			}
			else
			{
				list_3 = null;
			}
			List<MaterialsInItem> list3 = gClass.MaterialsInItems.Where((MaterialsInItem i) => i.ItemID == int_0).ToList();
			if (list3.Count > 0)
			{
				list_4 = list3;
			}
			else
			{
				list_4 = new List<MaterialsInItem>();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			int_0 = 0;
			txtName.Text = string.Empty;
			txtItemCost.Text = "0";
			chkActive.Value = false;
			chkDisableIfSoldOut.Value = false;
			txtInventoryQTY.Text = string.Empty;
			ddlUOM.SelectedValue = string.Empty;
			list_2 = null;
			btnSave.Enabled = false;
			chkAutoResetInv.Value = false;
			txtResetQty.Text = "0";
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)comboGroup.SelectedItem.DataBoundItem;
			if (!(keyValuePair.Key == "0") && !(keyValuePair.Key == "-1"))
			{
				method_8();
			}
			else
			{
				method_6(AdminMethods.getAllItemsDictionary(string_0));
			}
		}
	}

	private void txtInventoryQTY_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
			return;
		}
		decimal result = default(decimal);
		if (!decimal.TryParse(txtInventoryQTY.Text.Trim(), out result))
		{
			new frmMessageBox("\"" + txtInventoryQTY.Text + Resources._is_not_a_valid_value_for_Inve, Resources.Invalid_Quantity_Entered).ShowDialog(this);
			Item oneItem = AdminMethods.getOneItem(int_0);
			if (oneItem != null)
			{
				txtInventoryQTY.Text = oneItem.InventoryCount.ToString("0.00");
			}
		}
		try
		{
			decimal.TryParse(txtInventoryQTY.Text.Trim(), out result);
			if (result >= 999999m)
			{
				new frmMessageBox(Resources.Inventory_limit_reached_Please, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				txtInventoryQTY.Text = txtInventoryQTY.Text.Substring(0, 6);
			}
		}
		catch
		{
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + Resources.Ingredient_Name, 0, 256, txtName.Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtName.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_InventoryQTY_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Inventory_Count, 2, 6, txtInventoryQTY.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtInventoryQTY.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_ItemCost_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter + string_1 + Resources._Cost_Price, 4, 8, txtItemCost.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtItemCost.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
		base.ParentForm.TopMost = true;
		base.ParentForm.BringToFront();
		base.ParentForm.TopMost = false;
	}

	private void txtItemCost_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		frmMaterialsInItem frmMaterialsInItem2 = new frmMaterialsInItem(int_0, list_4);
		frmMaterialsInItem2.ShowDialog(this);
		if (frmMaterialsInItem2.DialogResult == DialogResult.OK)
		{
			list_4 = frmMaterialsInItem2.returnMaterialsInItemList;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (Enumerable.Count(new GClass6().CustomFields.Select((CustomField tblCustomFields) => tblCustomFields)) != 0)
		{
			frmCustomField frmCustomField2 = new frmCustomField(int_0, list_2);
			if (frmCustomField2.ShowDialog(this) == DialogResult.OK)
			{
				list_2 = frmCustomField2.itemCustomFieldValuesDisplay;
			}
		}
		else
		{
			new frmMessageBox(Resources.Please_add_first_a_Custom_Fiel, Resources.Error_Custom_Field_s_is_Empty).ShowDialog(this);
		}
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Search + string_1, 3);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		IQueryable<Item> queryable = from i in new GClass6().Items
			where i.ItemName.Contains(MemoryLoadedObjects.Keyboard.textEntered) && i.ItemClassification.Equals(string_0) && i.isDeleted == false
			select i into o
			orderby o.ItemName
			select o;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (queryable.Count() > 0)
		{
			foreach (Item item in queryable)
			{
				dictionary.Add(item.ItemID.ToString(), item.ItemName);
			}
			method_6(dictionary, bool_1: true);
		}
		else
		{
			new NotificationLabel(this, Resources.No_item_could_be_found_with_yo, NotificationTypes.Success).Show();
		}
	}

	private void btnShowItemAuditLogs_Click(object sender, EventArgs e)
	{
		new frmItemAuditView(int_0).ShowDialog(this);
	}

	private void method_16(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void txtName_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnCopy_Click(object sender, EventArgs e)
	{
		int_0 = -2;
		txtName.Focus();
		string_1 = "New Item";
		txtName_Click(txtName, e);
	}

	private void btnShowKeyboard_Description_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Description1, 0, 256, txtDescription.Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtDescription.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_17()
	{
		txtName.Text = string.Empty;
		txtDescription.Text = string.Empty;
		txtNotes.Text = string.Empty;
		chkActive.Value = true;
		txtItemCost.Text = "0";
		txtInventoryQTY.Text = "0";
		chkAutoResetInv.Value = false;
		chkDisableIfSoldOut.Value = false;
		txtResetQty.Text = "0";
		if (ddlUOM.Items.Count > 0)
		{
			ddlUOM.SelectedIndex = 0;
		}
		btnShowItemAuditLogs.Visible = false;
		Button button = btnCopy;
		Button button2 = btnUOMConversion;
		btnDelete.Visible = false;
		button2.Visible = false;
		button.Visible = false;
	}

	private void btnNew_Click(object sender, EventArgs e)
	{
		if (comboGroup.Visible)
		{
			comboGroup.SelectedIndex = 0;
		}
		method_6(AdminMethods.getAllItemsDictionary(string_0));
		string_1 = "New Item";
		method_17();
	}

	private void btnShowKeyboard_Notes_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Note, 0, 256, txtNotes.Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtNotes.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnUOMConversion_Click(object sender, EventArgs e)
	{
		method_10(bool_1: false);
		new frmUOMConversions(int_0, txtName.Text, ddlUOM.SelectedValue.ToString(), ddlUOM.Text).ShowDialog(this);
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		if (!method_9() && new frmMessageBox("Are you sure you want to delete this ingredient?", Resources.Delete, CustomMessageBoxButtons.YesNo).ShowDialog(this) == DialogResult.Yes)
		{
			GClass6 gClass = new GClass6();
			Item item = gClass.Items.Where((Item a) => a.ItemID == int_0).FirstOrDefault();
			if (item != null)
			{
				item.isDeleted = true;
				item.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
			new NotificationLabel(this, "Ingredient Deleted.", NotificationTypes.Success).Show();
			if (!bool_0)
			{
				method_6(AdminMethods.getAllItemsDictionary(string_0));
				comboGroup_SelectedIndexChanged(null, null);
			}
		}
	}

	private void chkAutoResetInv_ValueChanged(object sender, EventArgs e)
	{
		if (chkAutoResetInv.Value)
		{
			Label label = lblResetQty;
			RadTextBoxControl radTextBoxControl = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			radTextBoxControl.Visible = true;
			label.Visible = true;
		}
		else
		{
			Label label2 = lblResetQty;
			RadTextBoxControl radTextBoxControl2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			radTextBoxControl2.Visible = false;
			label2.Visible = false;
		}
	}

	private void comboItems_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (comboItems.Visible)
		{
			method_11();
		}
	}

	private void comboGroup_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (comboGroup.Visible)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)comboGroup.SelectedItem.DataBoundItem;
			if (!(keyValuePair.Key == "0") && !(keyValuePair.Key == "-1"))
			{
				method_8();
			}
			else
			{
				method_6(AdminMethods.getAllItemsDictionary(string_0));
			}
		}
	}

	private void txtResetQty_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Reset Qty", 2, 6, txtResetQty.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtResetQty.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditMaterials));
		pnlItemInfo = new Panel();
		chkAutoResetInv = new RadToggleSwitch();
		btnShowKeyboard_ResetQty = new Button();
		txtResetQty = new RadTextBoxControl();
		lblResetQty = new Label();
		label29 = new Label();
		ddlUOM = new Class20();
		chkTrackExpiry = new RadToggleSwitch();
		label26 = new Label();
		btnDelete = new Button();
		btnUOMConversion = new Button();
		txtNotes = new RadTextBoxControl();
		label14 = new Label();
		btnShowKeyboard_Notes = new Button();
		btnNew = new Button();
		btnCopy = new Button();
		txtDescription = new RadTextBoxControl();
		btnShowKeyboard_Description = new Button();
		label25 = new Label();
		btnCancel = new Button();
		txtInventoryQTY = new RadTextBoxControl();
		txtItemCost = new RadTextBoxControl();
		chkActive = new RadToggleSwitch();
		txtName = new RadTextBoxControl();
		btnShowItemAuditLogs = new Button();
		label1 = new Label();
		label11 = new Label();
		label18 = new Label();
		btnSave = new Button();
		lblInvCount = new Label();
		btnShowKeyboard_ItemCost = new Button();
		label17 = new Label();
		btnShowKeyboard_InventoryQTY = new Button();
		btnShowKeyboard_Name = new Button();
		lblSubTitle = new Label();
		pnlGroups = new Panel();
		comboItems = new Class20();
		comboGroup = new Class20();
		label7 = new Label();
		btnSearch = new Button();
		label9 = new Label();
		label15 = new Label();
		label8 = new Label();
		lblTitleBar = new Label();
		chkDisableIfSoldOut = new RadToggleSwitch();
		lblInvDisable = new Label();
		pnlItemInfo.SuspendLayout();
		((ISupportInitialize)chkAutoResetInv).BeginInit();
		((ISupportInitialize)txtResetQty).BeginInit();
		((ISupportInitialize)ddlUOM).BeginInit();
		((ISupportInitialize)chkTrackExpiry).BeginInit();
		((ISupportInitialize)txtNotes).BeginInit();
		((ISupportInitialize)txtDescription).BeginInit();
		((ISupportInitialize)txtInventoryQTY).BeginInit();
		((ISupportInitialize)txtItemCost).BeginInit();
		((ISupportInitialize)chkActive).BeginInit();
		((ISupportInitialize)txtName).BeginInit();
		pnlGroups.SuspendLayout();
		((ISupportInitialize)comboItems).BeginInit();
		((ISupportInitialize)comboGroup).BeginInit();
		((ISupportInitialize)chkDisableIfSoldOut).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(pnlItemInfo, "pnlItemInfo");
		pnlItemInfo.Controls.Add(chkDisableIfSoldOut);
		pnlItemInfo.Controls.Add(lblInvDisable);
		pnlItemInfo.Controls.Add(chkAutoResetInv);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ResetQty);
		pnlItemInfo.Controls.Add(txtResetQty);
		pnlItemInfo.Controls.Add(lblResetQty);
		pnlItemInfo.Controls.Add(label29);
		pnlItemInfo.Controls.Add(ddlUOM);
		pnlItemInfo.Controls.Add(chkTrackExpiry);
		pnlItemInfo.Controls.Add(label26);
		pnlItemInfo.Controls.Add(btnDelete);
		pnlItemInfo.Controls.Add(btnUOMConversion);
		pnlItemInfo.Controls.Add(txtNotes);
		pnlItemInfo.Controls.Add(label14);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Notes);
		pnlItemInfo.Controls.Add(btnNew);
		pnlItemInfo.Controls.Add(btnCopy);
		pnlItemInfo.Controls.Add(txtDescription);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Description);
		pnlItemInfo.Controls.Add(label25);
		pnlItemInfo.Controls.Add(btnCancel);
		pnlItemInfo.Controls.Add(txtInventoryQTY);
		pnlItemInfo.Controls.Add(txtItemCost);
		pnlItemInfo.Controls.Add(chkActive);
		pnlItemInfo.Controls.Add(txtName);
		pnlItemInfo.Controls.Add(btnShowItemAuditLogs);
		pnlItemInfo.Controls.Add(label1);
		pnlItemInfo.Controls.Add(label11);
		pnlItemInfo.Controls.Add(label18);
		pnlItemInfo.Controls.Add(btnSave);
		pnlItemInfo.Controls.Add(lblInvCount);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ItemCost);
		pnlItemInfo.Controls.Add(label17);
		pnlItemInfo.Controls.Add(btnShowKeyboard_InventoryQTY);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Name);
		pnlItemInfo.Name = "pnlItemInfo";
		componentResourceManager.ApplyResources(chkAutoResetInv, "chkAutoResetInv");
		chkAutoResetInv.Name = "chkAutoResetInv";
		chkAutoResetInv.OffText = "NO";
		chkAutoResetInv.OnText = "YES";
		chkAutoResetInv.Tag = "product";
		chkAutoResetInv.ToggleStateMode = ToggleStateMode.Click;
		chkAutoResetInv.ValueChanged += chkAutoResetInv_ValueChanged;
		((RadToggleSwitchElement)chkAutoResetInv.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkAutoResetInv.GetChildAt(0)).ThumbOffset = 52;
		((RadToggleSwitchElement)chkAutoResetInv.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkAutoResetInv.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkAutoResetInv.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkAutoResetInv.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkAutoResetInv.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text1");
		((ToggleSwitchPartElement)chkAutoResetInv.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		btnShowKeyboard_ResetQty.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_ResetQty.DialogResult = DialogResult.OK;
		btnShowKeyboard_ResetQty.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_ResetQty.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_ResetQty, "btnShowKeyboard_ResetQty");
		btnShowKeyboard_ResetQty.ForeColor = Color.White;
		btnShowKeyboard_ResetQty.Name = "btnShowKeyboard_ResetQty";
		btnShowKeyboard_ResetQty.UseVisualStyleBackColor = false;
		btnShowKeyboard_ResetQty.Click += txtResetQty_Click;
		componentResourceManager.ApplyResources(txtResetQty, "txtResetQty");
		txtResetQty.Name = "txtResetQty";
		txtResetQty.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtResetQty.Tag = "product";
		txtResetQty.TextAlign = HorizontalAlignment.Center;
		txtResetQty.Click += txtResetQty_Click;
		((RadTextBoxControlElement)txtResetQty.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtResetQty.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		lblResetQty.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblResetQty, "lblResetQty");
		lblResetQty.ForeColor = Color.White;
		lblResetQty.Name = "lblResetQty";
		label29.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label29, "label29");
		label29.ForeColor = Color.White;
		label29.Name = "label29";
		componentResourceManager.ApplyResources(ddlUOM, "ddlUOM");
		ddlUOM.BackColor = Color.White;
		ddlUOM.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlUOM.EnableKineticScrolling = true;
		ddlUOM.Name = "ddlUOM";
		ddlUOM.ThemeName = "Windows8";
		componentResourceManager.ApplyResources(chkTrackExpiry, "chkTrackExpiry");
		chkTrackExpiry.Name = "chkTrackExpiry";
		chkTrackExpiry.OffText = "NO";
		chkTrackExpiry.OnText = "YES";
		chkTrackExpiry.Tag = "product";
		chkTrackExpiry.ToggleStateMode = ToggleStateMode.Click;
		chkTrackExpiry.Value = false;
		((RadToggleSwitchElement)chkTrackExpiry.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkTrackExpiry.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkTrackExpiry.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkTrackExpiry.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkTrackExpiry.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTrackExpiry.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkTrackExpiry.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text2");
		((ToggleSwitchPartElement)chkTrackExpiry.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		label26.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label26, "label26");
		label26.ForeColor = Color.White;
		label26.Name = "label26";
		btnDelete.BackColor = Color.FromArgb(235, 107, 86);
		btnDelete.FlatAppearance.BorderColor = Color.White;
		btnDelete.FlatAppearance.BorderSize = 0;
		btnDelete.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnDelete, "btnDelete");
		btnDelete.ForeColor = Color.White;
		btnDelete.Name = "btnDelete";
		btnDelete.UseVisualStyleBackColor = false;
		btnDelete.Click += btnDelete_Click;
		btnUOMConversion.BackColor = Color.FromArgb(50, 119, 155);
		btnUOMConversion.FlatAppearance.BorderColor = Color.White;
		btnUOMConversion.FlatAppearance.BorderSize = 0;
		btnUOMConversion.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnUOMConversion, "btnUOMConversion");
		btnUOMConversion.ForeColor = Color.White;
		btnUOMConversion.Name = "btnUOMConversion";
		btnUOMConversion.UseVisualStyleBackColor = false;
		btnUOMConversion.Click += btnUOMConversion_Click;
		componentResourceManager.ApplyResources(txtNotes, "txtNotes");
		txtNotes.Name = "txtNotes";
		txtNotes.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtNotes.Click += txtName_Click;
		((RadTextBoxControlElement)txtNotes.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtNotes.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		label14.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label14, "label14");
		label14.ForeColor = Color.White;
		label14.Name = "label14";
		btnShowKeyboard_Notes.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Notes.DialogResult = DialogResult.OK;
		btnShowKeyboard_Notes.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Notes.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Notes, "btnShowKeyboard_Notes");
		btnShowKeyboard_Notes.ForeColor = Color.White;
		btnShowKeyboard_Notes.Name = "btnShowKeyboard_Notes";
		btnShowKeyboard_Notes.UseVisualStyleBackColor = false;
		btnShowKeyboard_Notes.Click += btnShowKeyboard_Notes_Click;
		btnNew.BackColor = Color.FromArgb(1, 110, 211);
		btnNew.FlatAppearance.BorderColor = Color.White;
		btnNew.FlatAppearance.BorderSize = 0;
		btnNew.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnNew, "btnNew");
		btnNew.ForeColor = Color.White;
		btnNew.Name = "btnNew";
		btnNew.UseVisualStyleBackColor = false;
		btnNew.Click += btnNew_Click;
		btnCopy.BackColor = Color.FromArgb(25, 74, 114);
		btnCopy.FlatAppearance.BorderColor = Color.White;
		btnCopy.FlatAppearance.BorderSize = 0;
		btnCopy.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCopy, "btnCopy");
		btnCopy.ForeColor = Color.White;
		btnCopy.Name = "btnCopy";
		btnCopy.UseVisualStyleBackColor = false;
		btnCopy.Click += btnCopy_Click;
		componentResourceManager.ApplyResources(txtDescription, "txtDescription");
		txtDescription.ForeColor = Color.FromArgb(40, 40, 40);
		txtDescription.Multiline = true;
		txtDescription.Name = "txtDescription";
		txtDescription.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtDescription.Click += txtName_Click;
		((RadTextBoxControlElement)txtDescription.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtDescription.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowKeyboard_Description.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Description.DialogResult = DialogResult.OK;
		btnShowKeyboard_Description.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Description.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Description, "btnShowKeyboard_Description");
		btnShowKeyboard_Description.ForeColor = Color.White;
		btnShowKeyboard_Description.Name = "btnShowKeyboard_Description";
		btnShowKeyboard_Description.UseVisualStyleBackColor = false;
		btnShowKeyboard_Description.Click += btnShowKeyboard_Description_Click;
		label25.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label25, "label25");
		label25.ForeColor = Color.White;
		label25.Name = "label25";
		btnCancel.BackColor = Color.SandyBrown;
		btnCancel.FlatAppearance.BorderColor = Color.White;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnCancel, "btnCancel");
		btnCancel.ForeColor = Color.White;
		btnCancel.Name = "btnCancel";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += btnCancel_Click;
		componentResourceManager.ApplyResources(txtInventoryQTY, "txtInventoryQTY");
		txtInventoryQTY.Name = "txtInventoryQTY";
		txtInventoryQTY.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtInventoryQTY.Tag = "product";
		txtInventoryQTY.TextAlign = HorizontalAlignment.Center;
		txtInventoryQTY.Click += txtName_Click;
		txtInventoryQTY.KeyPress += txtInventoryQTY_KeyPress;
		((RadTextBoxControlElement)txtInventoryQTY.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtInventoryQTY.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		componentResourceManager.ApplyResources(txtItemCost, "txtItemCost");
		txtItemCost.Name = "txtItemCost";
		txtItemCost.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtItemCost.Tag = "";
		txtItemCost.TextAlign = HorizontalAlignment.Center;
		txtItemCost.Click += txtName_Click;
		txtItemCost.KeyPress += txtItemCost_KeyPress;
		((RadTextBoxControlElement)txtItemCost.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtItemCost.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		chkActive.Name = "chkActive";
		chkActive.OffText = "NO";
		chkActive.OnText = "YES";
		chkActive.Tag = "";
		chkActive.ToggleStateMode = ToggleStateMode.Click;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).ThumbOffset = 68;
		((RadToggleSwitchElement)chkActive.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text3");
		((ToggleSwitchPartElement)chkActive.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		componentResourceManager.ApplyResources(txtName, "txtName");
		txtName.Name = "txtName";
		txtName.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtName.Click += txtName_Click;
		((RadTextBoxControlElement)txtName.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtName.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowItemAuditLogs.BackColor = Color.FromArgb(50, 119, 155);
		btnShowItemAuditLogs.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowItemAuditLogs, "btnShowItemAuditLogs");
		btnShowItemAuditLogs.ForeColor = SystemColors.Control;
		btnShowItemAuditLogs.Name = "btnShowItemAuditLogs";
		btnShowItemAuditLogs.Tag = "product";
		btnShowItemAuditLogs.UseVisualStyleBackColor = false;
		btnShowItemAuditLogs.Click += btnShowItemAuditLogs_Click;
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label11.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label11, "label11");
		label11.ForeColor = Color.White;
		label11.Name = "label11";
		label18.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label18, "label18");
		label18.ForeColor = Color.White;
		label18.Name = "label18";
		btnSave.BackColor = Color.FromArgb(80, 203, 116);
		btnSave.FlatAppearance.BorderColor = Color.White;
		btnSave.FlatAppearance.BorderSize = 0;
		btnSave.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnSave, "btnSave");
		btnSave.ForeColor = Color.White;
		btnSave.Name = "btnSave";
		btnSave.UseVisualStyleBackColor = false;
		btnSave.Click += btnSave_Click;
		lblInvCount.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblInvCount, "lblInvCount");
		lblInvCount.ForeColor = Color.White;
		lblInvCount.Name = "lblInvCount";
		btnShowKeyboard_ItemCost.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_ItemCost.DialogResult = DialogResult.OK;
		btnShowKeyboard_ItemCost.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_ItemCost.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_ItemCost, "btnShowKeyboard_ItemCost");
		btnShowKeyboard_ItemCost.ForeColor = Color.White;
		btnShowKeyboard_ItemCost.Name = "btnShowKeyboard_ItemCost";
		btnShowKeyboard_ItemCost.UseVisualStyleBackColor = false;
		btnShowKeyboard_ItemCost.Click += btnShowKeyboard_ItemCost_Click;
		label17.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label17, "label17");
		label17.ForeColor = Color.White;
		label17.Name = "label17";
		btnShowKeyboard_InventoryQTY.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_InventoryQTY.DialogResult = DialogResult.OK;
		btnShowKeyboard_InventoryQTY.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_InventoryQTY.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_InventoryQTY, "btnShowKeyboard_InventoryQTY");
		btnShowKeyboard_InventoryQTY.ForeColor = Color.White;
		btnShowKeyboard_InventoryQTY.Name = "btnShowKeyboard_InventoryQTY";
		btnShowKeyboard_InventoryQTY.UseVisualStyleBackColor = false;
		btnShowKeyboard_InventoryQTY.Click += btnShowKeyboard_InventoryQTY_Click;
		btnShowKeyboard_Name.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_Name.DialogResult = DialogResult.OK;
		btnShowKeyboard_Name.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_Name.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowKeyboard_Name, "btnShowKeyboard_Name");
		btnShowKeyboard_Name.ForeColor = Color.White;
		btnShowKeyboard_Name.Name = "btnShowKeyboard_Name";
		btnShowKeyboard_Name.UseVisualStyleBackColor = false;
		btnShowKeyboard_Name.Click += btnShowKeyboard_Name_Click;
		lblSubTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblSubTitle, "lblSubTitle");
		lblSubTitle.ForeColor = Color.White;
		lblSubTitle.Name = "lblSubTitle";
		pnlGroups.BackColor = Color.Transparent;
		pnlGroups.Controls.Add(comboItems);
		pnlGroups.Controls.Add(comboGroup);
		pnlGroups.Controls.Add(label7);
		pnlGroups.Controls.Add(btnSearch);
		pnlGroups.Controls.Add(label9);
		pnlGroups.Controls.Add(label15);
		pnlGroups.Controls.Add(label8);
		componentResourceManager.ApplyResources(pnlGroups, "pnlGroups");
		pnlGroups.Name = "pnlGroups";
		componentResourceManager.ApplyResources(comboItems, "comboItems");
		comboItems.BackColor = Color.White;
		comboItems.DefaultItemsCountInDropDown = 10;
		comboItems.DropDownStyle = RadDropDownStyle.DropDownList;
		comboItems.EnableKineticScrolling = true;
		comboItems.Name = "comboItems";
		comboItems.ThemeName = "Windows8";
		comboItems.SelectedIndexChanged += comboItems_SelectedIndexChanged;
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		comboGroup.BackColor = Color.White;
		comboGroup.DropDownStyle = RadDropDownStyle.DropDownList;
		comboGroup.EnableKineticScrolling = true;
		comboGroup.ForeColor = SystemColors.WindowText;
		comboGroup.Name = "comboGroup";
		comboGroup.ThemeName = "Windows8";
		comboGroup.SelectedIndexChanged += comboGroup_SelectedIndexChanged;
		label7.BackColor = Color.FromArgb(64, 64, 64);
		componentResourceManager.ApplyResources(label7, "label7");
		label7.ForeColor = Color.White;
		label7.Name = "label7";
		btnSearch.BackColor = Color.FromArgb(77, 174, 225);
		btnSearch.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnSearch, "btnSearch");
		btnSearch.ForeColor = SystemColors.Control;
		btnSearch.Name = "btnSearch";
		btnSearch.Tag = "product";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += btnSearch_Click;
		label9.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label9, "label9");
		label9.ForeColor = Color.White;
		label9.Name = "label9";
		label15.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(label15, "label15");
		label15.Name = "label15";
		label8.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label8, "label8");
		label8.ForeColor = Color.White;
		label8.Name = "label8";
		lblTitleBar.BackColor = Color.FromArgb(156, 89, 184);
		componentResourceManager.ApplyResources(lblTitleBar, "lblTitleBar");
		lblTitleBar.ForeColor = Color.White;
		lblTitleBar.Name = "lblTitleBar";
		componentResourceManager.ApplyResources(chkDisableIfSoldOut, "chkDisableIfSoldOut");
		chkDisableIfSoldOut.Name = "chkDisableIfSoldOut";
		chkDisableIfSoldOut.OffText = "NO";
		chkDisableIfSoldOut.OnText = "YES";
		chkDisableIfSoldOut.Tag = "product";
		chkDisableIfSoldOut.ToggleStateMode = ToggleStateMode.Click;
		chkDisableIfSoldOut.Value = false;
		((RadToggleSwitchElement)chkDisableIfSoldOut.GetChildAt(0)).ThumbTickness = 20;
		((RadToggleSwitchElement)chkDisableIfSoldOut.GetChildAt(0)).ThumbOffset = 0;
		((RadToggleSwitchElement)chkDisableIfSoldOut.GetChildAt(0)).BorderWidth = 0.9999998f;
		((ToggleSwitchPartElement)chkDisableIfSoldOut.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ToggleSwitchPartElement)chkDisableIfSoldOut.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDisableIfSoldOut.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ToggleSwitchPartElement)chkDisableIfSoldOut.GetChildAt(0).GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((ToggleSwitchPartElement)chkDisableIfSoldOut.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		lblInvDisable.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblInvDisable, "lblInvDisable");
		lblInvDisable.ForeColor = Color.White;
		lblInvDisable.Name = "lblInvDisable";
		lblInvDisable.Tag = "product";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(pnlItemInfo);
		base.Controls.Add(lblSubTitle);
		base.Controls.Add(pnlGroups);
		base.Controls.Add(lblTitleBar);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAddEditMaterials";
		base.Opacity = 1.0;
		base.Load += frmAddEditMaterials_Load;
		pnlItemInfo.ResumeLayout(performLayout: false);
		((ISupportInitialize)chkAutoResetInv).EndInit();
		((ISupportInitialize)txtResetQty).EndInit();
		((ISupportInitialize)ddlUOM).EndInit();
		((ISupportInitialize)chkTrackExpiry).EndInit();
		((ISupportInitialize)txtNotes).EndInit();
		((ISupportInitialize)txtDescription).EndInit();
		((ISupportInitialize)txtInventoryQTY).EndInit();
		((ISupportInitialize)txtItemCost).EndInit();
		((ISupportInitialize)chkActive).EndInit();
		((ISupportInitialize)txtName).EndInit();
		pnlGroups.ResumeLayout(performLayout: false);
		((ISupportInitialize)comboItems).EndInit();
		((ISupportInitialize)comboGroup).EndInit();
		((ISupportInitialize)chkDisableIfSoldOut).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
