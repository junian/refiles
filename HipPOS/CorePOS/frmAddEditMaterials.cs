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
			((RadDropDownList)comboGroup).set_DisplayMember("Value");
			((RadDropDownList)comboGroup).set_ValueMember("Key");
			((RadDropDownList)comboGroup).set_DataSource((object)new BindingSource(groups, null));
			((RadDropDownList)comboGroup).set_SelectedIndex(0);
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
		if (chkAutoResetInv.get_Value())
		{
			Label label = lblResetQty;
			RadTextBoxControl obj = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			((Control)(object)obj).Visible = true;
			label.Visible = true;
		}
		else
		{
			Label label2 = lblResetQty;
			RadTextBoxControl obj2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			((Control)(object)obj2).Visible = false;
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
		((RadDropDownList)ddlUOM).set_DisplayMember("Value");
		((RadDropDownList)ddlUOM).set_ValueMember("Key");
		((RadDropDownList)ddlUOM).set_DataSource((object)new BindingSource(dictionary, null));
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
			((RadDropDownList)comboGroup).set_SelectedIndex(0);
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
		((RadDropDownList)comboItems).set_DisplayMember("Value");
		((RadDropDownList)comboItems).set_ValueMember("Key");
		((RadDropDownList)comboItems).set_DataSource((object)new BindingSource(dataSource, null));
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
		KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
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
		if (((RadDropDownList)comboItems).get_SelectedItem() != null && ((KeyValuePair<string, string>)((RadDropDownList)comboItems).get_SelectedItem().get_DataBoundItem()).Key == "0")
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
			if (((Control)(object)txtName).Text.Replace(" ", "") == string.Empty)
			{
				list.Add("Name");
			}
			if (((Control)(object)txtItemCost).Text.Replace(" ", "") == string.Empty)
			{
				list.Add("Cost");
			}
			if (((Control)(object)txtInventoryQTY).Text.Replace(" ", "") == string.Empty)
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
				((Control)(object)txtName).Text = ((Control)(object)txtName).Text.Replace("&&", "&");
			}
			while (((Control)(object)txtName).Text.Contains("&&"));
			((Control)(object)txtName).Text.Trim();
			if (((Control)(object)txtItemCost).Text.Trim() == string.Empty)
			{
				((Control)(object)txtItemCost).Text = "0";
			}
			try
			{
				if (AdminMethods.itemNameExistCheck(((Control)(object)txtName).Text.Trim()))
				{
					new frmMessageBox(Resources.Item_name_already_exists_Pleas).ShowDialog(this);
					return;
				}
				AdminMethods.addNewItem(string.Empty, ((Control)(object)txtName).Text.Trim(), Convert.ToDecimal(((Control)(object)txtItemCost).Text), 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, 9, string.Empty, 0, "150,166,166", chkActive.get_Value(), Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text), chkDisableIfSoldOut.get_Value(), Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()), trackInventory: true, string_0, ((Control)(object)txtDescription).Text, ((Control)(object)txtNotes).Text, "Uncategorized", -1, 0, chkTrackExpiry.get_Value(), ApplySaleComboOption: false, chkAutoResetInv.get_Value(), Convert.ToDecimal(((Control)(object)txtResetQty).Text), RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m);
				Item item = gClass.Items.Where((Item tblItems) => tblItems.ItemName == ((Control)(object)txtName).Text).FirstOrDefault();
				if (list_2 != null)
				{
					AdminMethods.UpdateItemCustomField(item.ItemID, list_2);
				}
				if (list_4 != null)
				{
					AdminMethods.UpdateMaterialsInItems(list_4, item.ItemID);
				}
				if (chkTrackExpiry.get_Value() && Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text) > 0m)
				{
					new frmAddInventoryBatches(item.ItemID, Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text)).ShowDialog(this);
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
			if (((Control)(object)txtName).Text == string.Empty)
			{
				list2.Add("Name");
			}
			if (((Control)(object)txtItemCost).Text == string.Empty)
			{
				list2.Add("Cost");
			}
			if (((Control)(object)txtInventoryQTY).Text == string.Empty)
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
				((Control)(object)txtName).Text = ((Control)(object)txtName).Text.Replace("&&", "&");
			}
			while (((Control)(object)txtName).Text.Contains("&&"));
			((Control)(object)txtName).Text.Trim();
			if (int_0 == -1)
			{
				return;
			}
			if (((Control)(object)txtItemCost).Text.Trim() == string.Empty)
			{
				((Control)(object)txtItemCost).Text = "0";
			}
			try
			{
				if (AdminMethods.itemNameExistCheck(((Control)(object)txtName).Text.Trim(), int_0))
				{
					new frmMessageBox(string_1 + Resources._name_already_exists_Please_en).ShowDialog(this);
					return;
				}
				Item item2 = gClass.Items.Where((Item i) => i.ItemID == int_0).FirstOrDefault();
				gClass.Refresh(RefreshMode.OverwriteCurrentValues, item2);
				string inventoryUpdateReason = Resources.Update_Item;
				decimal num = Convert.ToDecimal(((Control)(object)txtInventoryQTY).Text);
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
				AdminMethods.updateItem(int_0, string.Empty, ((Control)(object)txtName).Text.Trim(), Convert.ToDecimal(((Control)(object)txtItemCost).Text), 0m, 0m, onsale: false, null, null, null, null, string.Empty, 1, 9, string.Empty, 0, "150,166,166", chkActive.get_Value(), num, chkDisableIfSoldOut.get_Value(), Convert.ToInt16(((RadDropDownList)ddlUOM).get_SelectedValue()), trackInventory: true, string_0, ((Control)(object)txtDescription).Text, ((Control)(object)txtNotes).Text, "Uncategorized", -1, 0, chkTrackExpiry.get_Value(), ApplySaleComboOption: false, 0, chkAutoResetInv.get_Value(), Convert.ToDecimal(((Control)(object)txtResetQty).Text), RedemptionLoyalty: true, UseSmartBarcode: false, AutoPromptOption: true, 1m, TaxesIncluded: false, -1m, 0m, inventoryUpdateReason);
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
					string selectedValue = ((RadDropDownList)comboItems).get_SelectedValue().ToString();
					((RadDropDownList)comboItems).set_SelectedValue((object)selectedValue);
					method_11();
				}
				if (chkTrackExpiry.get_Value() && num > inventoryCount)
				{
					new frmAddInventoryBatches(int_0, num - inventoryCount).ShowDialog(this);
				}
				if (chkTrackExpiry.get_Value() && num < inventoryCount)
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
		if (!bool_1 && ((RadDropDownList)comboItems).get_SelectedIndex() > -1)
		{
			int_0 = int.Parse(((KeyValuePair<string, string>)((RadDropDownList)comboItems).get_SelectedItem().get_DataBoundItem()).Key);
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
			((Control)(object)txtName).Text = item_0.ItemName;
			((Control)(object)txtItemCost).Text = item_0.ItemCost.ToString();
			chkActive.set_Value(item_0.Active);
			((Control)(object)txtInventoryQTY).Text = ((item_0.InventoryCount % 1m == 0m) ? MathHelper.RemoveTrailingZeros(item_0.InventoryCount.ToString()) : item_0.InventoryCount.ToString());
			if (item_0.UOMID == 1 || item_0.UOMID == 5 || item_0.UOMID == 6)
			{
				((Control)(object)txtInventoryQTY).Text = Math.Round(item_0.InventoryCount, 0).ToString();
			}
			((RadDropDownList)ddlUOM).set_SelectedValue((object)item_0.UOMID.ToString());
			list_2 = null;
			btnSave.Enabled = true;
			((Control)(object)txtDescription).Text = item_0.Description;
			((Control)(object)txtNotes).Text = item_0.Notes;
			chkTrackExpiry.set_Value(item_0.TrackExpiryDate);
			chkAutoResetInv.set_Value(item_0.AutoResetQty);
			((Control)(object)txtResetQty).Text = item_0.ResetQty.ToString("0.00");
			chkDisableIfSoldOut.set_Value(item_0.DisableSoldOutItems);
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
			((Control)(object)txtName).Text = string.Empty;
			((Control)(object)txtItemCost).Text = "0";
			chkActive.set_Value(false);
			chkDisableIfSoldOut.set_Value(false);
			((Control)(object)txtInventoryQTY).Text = string.Empty;
			((RadDropDownList)ddlUOM).set_SelectedValue((object)string.Empty);
			list_2 = null;
			btnSave.Enabled = false;
			chkAutoResetInv.set_Value(false);
			((Control)(object)txtResetQty).Text = "0";
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
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
		if (!decimal.TryParse(((Control)(object)txtInventoryQTY).Text.Trim(), out result))
		{
			new frmMessageBox("\"" + ((Control)(object)txtInventoryQTY).Text + Resources._is_not_a_valid_value_for_Inve, Resources.Invalid_Quantity_Entered).ShowDialog(this);
			Item oneItem = AdminMethods.getOneItem(int_0);
			if (oneItem != null)
			{
				((Control)(object)txtInventoryQTY).Text = oneItem.InventoryCount.ToString("0.00");
			}
		}
		try
		{
			decimal.TryParse(((Control)(object)txtInventoryQTY).Text.Trim(), out result);
			if (result >= 999999m)
			{
				new frmMessageBox(Resources.Inventory_limit_reached_Please, Resources.Invalid_Quantity_Entered).ShowDialog(this);
				((Control)(object)txtInventoryQTY).Text = ((Control)(object)txtInventoryQTY).Text.Substring(0, 6);
			}
		}
		catch
		{
		}
	}

	private void btnShowKeyboard_Name_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + Resources.Ingredient_Name, 0, 256, ((Control)(object)txtName).Text);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtName).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_InventoryQTY_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter_Inventory_Count, 2, 6, ((Control)(object)txtInventoryQTY).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtInventoryQTY).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnShowKeyboard_ItemCost_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData(Resources.Enter + string_1 + Resources._Cost_Price, 4, 8, ((Control)(object)txtItemCost).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtItemCost).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		((Control)(object)txtName).Focus();
		string_1 = "New Item";
		txtName_Click(txtName, e);
	}

	private void btnShowKeyboard_Description_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Description1, 0, 256, ((Control)(object)txtDescription).Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtDescription).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void method_17()
	{
		((Control)(object)txtName).Text = string.Empty;
		((Control)(object)txtDescription).Text = string.Empty;
		((Control)(object)txtNotes).Text = string.Empty;
		chkActive.set_Value(true);
		((Control)(object)txtItemCost).Text = "0";
		((Control)(object)txtInventoryQTY).Text = "0";
		chkAutoResetInv.set_Value(false);
		chkDisableIfSoldOut.set_Value(false);
		((Control)(object)txtResetQty).Text = "0";
		if (((RadDropDownList)ddlUOM).get_Items().get_Count() > 0)
		{
			((RadDropDownList)ddlUOM).set_SelectedIndex(0);
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
		if (((Control)(object)comboGroup).Visible)
		{
			((RadDropDownList)comboGroup).set_SelectedIndex(0);
		}
		method_6(AdminMethods.getAllItemsDictionary(string_0));
		string_1 = "New Item";
		method_17();
	}

	private void btnShowKeyboard_Notes_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_1 + Resources._Note, 0, 256, ((Control)(object)txtNotes).Text, multiline: true);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtNotes).Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnUOMConversion_Click(object sender, EventArgs e)
	{
		method_10(bool_1: false);
		new frmUOMConversions(int_0, ((Control)(object)txtName).Text, ((RadDropDownList)ddlUOM).get_SelectedValue().ToString(), ((Control)(object)ddlUOM).Text).ShowDialog(this);
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
		if (chkAutoResetInv.get_Value())
		{
			Label label = lblResetQty;
			RadTextBoxControl obj = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = true;
			((Control)(object)obj).Visible = true;
			label.Visible = true;
		}
		else
		{
			Label label2 = lblResetQty;
			RadTextBoxControl obj2 = txtResetQty;
			btnShowKeyboard_ResetQty.Visible = false;
			((Control)(object)obj2).Visible = false;
			label2.Visible = false;
		}
	}

	private void comboItems_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((Control)(object)comboItems).Visible)
		{
			method_11();
		}
	}

	private void comboGroup_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
	{
		if (((Control)(object)comboGroup).Visible)
		{
			KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)((RadDropDownList)comboGroup).get_SelectedItem().get_DataBoundItem();
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
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Reset Qty", 2, 6, ((Control)(object)txtResetQty).Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			((Control)(object)txtResetQty).Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
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
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_1076: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1386: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1429: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1459: Unknown result type (might be due to invalid IL or missing references)
		//IL_147a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1501: Unknown result type (might be due to invalid IL or missing references)
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c21: Expected O, but got Unknown
		//IL_1c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca1: Expected O, but got Unknown
		//IL_1f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_200a: Unknown result type (might be due to invalid IL or missing references)
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
		pnlItemInfo.Controls.Add((Control)(object)chkDisableIfSoldOut);
		pnlItemInfo.Controls.Add(lblInvDisable);
		pnlItemInfo.Controls.Add((Control)(object)chkAutoResetInv);
		pnlItemInfo.Controls.Add(btnShowKeyboard_ResetQty);
		pnlItemInfo.Controls.Add((Control)(object)txtResetQty);
		pnlItemInfo.Controls.Add(lblResetQty);
		pnlItemInfo.Controls.Add(label29);
		pnlItemInfo.Controls.Add((Control)(object)ddlUOM);
		pnlItemInfo.Controls.Add((Control)(object)chkTrackExpiry);
		pnlItemInfo.Controls.Add(label26);
		pnlItemInfo.Controls.Add(btnDelete);
		pnlItemInfo.Controls.Add(btnUOMConversion);
		pnlItemInfo.Controls.Add((Control)(object)txtNotes);
		pnlItemInfo.Controls.Add(label14);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Notes);
		pnlItemInfo.Controls.Add(btnNew);
		pnlItemInfo.Controls.Add(btnCopy);
		pnlItemInfo.Controls.Add((Control)(object)txtDescription);
		pnlItemInfo.Controls.Add(btnShowKeyboard_Description);
		pnlItemInfo.Controls.Add(label25);
		pnlItemInfo.Controls.Add(btnCancel);
		pnlItemInfo.Controls.Add((Control)(object)txtInventoryQTY);
		pnlItemInfo.Controls.Add((Control)(object)txtItemCost);
		pnlItemInfo.Controls.Add((Control)(object)chkActive);
		pnlItemInfo.Controls.Add((Control)(object)txtName);
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
		((Control)(object)chkAutoResetInv).Name = "chkAutoResetInv";
		chkAutoResetInv.set_OffText("NO");
		chkAutoResetInv.set_OnText("YES");
		((Control)(object)chkAutoResetInv).Tag = "product";
		chkAutoResetInv.set_ToggleStateMode((ToggleStateMode)1);
		chkAutoResetInv.add_ValueChanged((EventHandler)chkAutoResetInv_ValueChanged);
		((RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_ThumbOffset(52);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkAutoResetInv).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text1"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkAutoResetInv).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)txtResetQty).Name = "txtResetQty";
		((RadElement)((RadControl)txtResetQty).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtResetQty).Tag = "product";
		txtResetQty.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtResetQty).Click += txtResetQty_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtResetQty).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtResetQty).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		lblResetQty.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(lblResetQty, "lblResetQty");
		lblResetQty.ForeColor = Color.White;
		lblResetQty.Name = "lblResetQty";
		label29.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label29, "label29");
		label29.ForeColor = Color.White;
		label29.Name = "label29";
		componentResourceManager.ApplyResources(ddlUOM, "ddlUOM");
		((Control)(object)ddlUOM).BackColor = Color.White;
		((RadDropDownList)ddlUOM).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)ddlUOM).set_EnableKineticScrolling(true);
		((Control)(object)ddlUOM).Name = "ddlUOM";
		((RadControl)ddlUOM).set_ThemeName("Windows8");
		componentResourceManager.ApplyResources(chkTrackExpiry, "chkTrackExpiry");
		((Control)(object)chkTrackExpiry).Name = "chkTrackExpiry";
		chkTrackExpiry.set_OffText("NO");
		chkTrackExpiry.set_OnText("YES");
		((Control)(object)chkTrackExpiry).Tag = "product";
		chkTrackExpiry.set_ToggleStateMode((ToggleStateMode)1);
		chkTrackExpiry.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkTrackExpiry).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text2"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkTrackExpiry).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
		((Control)(object)txtNotes).Name = "txtNotes";
		((RadElement)((RadControl)txtNotes).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtNotes).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtNotes).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtNotes).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
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
		((Control)(object)txtDescription).ForeColor = Color.FromArgb(40, 40, 40);
		txtDescription.set_Multiline(true);
		((Control)(object)txtDescription).Name = "txtDescription";
		((RadElement)((RadControl)txtDescription).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtDescription).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtDescription).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtDescription).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
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
		((Control)(object)txtInventoryQTY).Name = "txtInventoryQTY";
		((RadElement)((RadControl)txtInventoryQTY).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtInventoryQTY).Tag = "product";
		txtInventoryQTY.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtInventoryQTY).Click += txtName_Click;
		((Control)(object)txtInventoryQTY).KeyPress += txtInventoryQTY_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtInventoryQTY).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtInventoryQTY).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(txtItemCost, "txtItemCost");
		((Control)(object)txtItemCost).Name = "txtItemCost";
		((RadElement)((RadControl)txtItemCost).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtItemCost).Tag = "";
		txtItemCost.set_TextAlign(HorizontalAlignment.Center);
		((Control)(object)txtItemCost).Click += txtName_Click;
		((Control)(object)txtItemCost).KeyPress += txtItemCost_KeyPress;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtItemCost).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtItemCost).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(0f, 5f));
		componentResourceManager.ApplyResources(chkActive, "chkActive");
		((Control)(object)chkActive).Name = "chkActive";
		chkActive.set_OffText("NO");
		chkActive.set_OnText("YES");
		((Control)(object)chkActive).Tag = "";
		chkActive.set_ToggleStateMode((ToggleStateMode)1);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_ThumbOffset(68);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkActive).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text3"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkActive).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
		componentResourceManager.ApplyResources(txtName, "txtName");
		((Control)(object)txtName).Name = "txtName";
		((RadElement)((RadControl)txtName).get_RootElement()).set_PositionOffset(new SizeF(0f, 0f));
		((Control)(object)txtName).Click += txtName_Click;
		((UIItemBase)(RadTextBoxControlElement)((RadControl)txtName).GetChildAt(0)).set_BorderWidth(0f);
		((RadElement)(TextBoxViewElement)((RadControl)txtName).GetChildAt(0).GetChildAt(0)).set_PositionOffset(new SizeF(5f, 5f));
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
		pnlGroups.Controls.Add((Control)(object)comboItems);
		pnlGroups.Controls.Add((Control)(object)comboGroup);
		pnlGroups.Controls.Add(label7);
		pnlGroups.Controls.Add(btnSearch);
		pnlGroups.Controls.Add(label9);
		pnlGroups.Controls.Add(label15);
		pnlGroups.Controls.Add(label8);
		componentResourceManager.ApplyResources(pnlGroups, "pnlGroups");
		pnlGroups.Name = "pnlGroups";
		componentResourceManager.ApplyResources(comboItems, "comboItems");
		((Control)(object)comboItems).BackColor = Color.White;
		((RadDropDownList)comboItems).set_DefaultItemsCountInDropDown(10);
		((RadDropDownList)comboItems).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)comboItems).set_EnableKineticScrolling(true);
		((Control)(object)comboItems).Name = "comboItems";
		((RadControl)comboItems).set_ThemeName("Windows8");
		((RadDropDownList)comboItems).add_SelectedIndexChanged(new PositionChangedEventHandler(comboItems_SelectedIndexChanged));
		componentResourceManager.ApplyResources(comboGroup, "comboGroup");
		((Control)(object)comboGroup).BackColor = Color.White;
		((RadDropDownList)comboGroup).set_DropDownStyle((RadDropDownStyle)2);
		((RadDropDownList)comboGroup).set_EnableKineticScrolling(true);
		((Control)(object)comboGroup).ForeColor = SystemColors.WindowText;
		((Control)(object)comboGroup).Name = "comboGroup";
		((RadControl)comboGroup).set_ThemeName("Windows8");
		((RadDropDownList)comboGroup).add_SelectedIndexChanged(new PositionChangedEventHandler(comboGroup_SelectedIndexChanged));
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
		((Control)(object)chkDisableIfSoldOut).Name = "chkDisableIfSoldOut";
		chkDisableIfSoldOut.set_OffText("NO");
		chkDisableIfSoldOut.set_OnText("YES");
		((Control)(object)chkDisableIfSoldOut).Tag = "product";
		chkDisableIfSoldOut.set_ToggleStateMode((ToggleStateMode)1);
		chkDisableIfSoldOut.set_Value(false);
		((RadToggleSwitchElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0)).set_ThumbTickness(20);
		((RadToggleSwitchElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0)).set_ThumbOffset(0);
		((UIItemBase)(RadToggleSwitchElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0)).set_BorderWidth(0.9999998f);
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_BackColor2(Color.FromArgb(247, 192, 82));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_BackColor3(Color.FromArgb(242, 182, 51));
		((UIItemBase)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_BackColor4(Color.FromArgb(242, 182, 51));
		((RadItem)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_Text(componentResourceManager.GetString("resource.Text"));
		((VisualElement)(ToggleSwitchPartElement)((RadControl)chkDisableIfSoldOut).GetChildAt(0).GetChildAt(0)).set_BackColor(Color.FromArgb(247, 192, 82));
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
